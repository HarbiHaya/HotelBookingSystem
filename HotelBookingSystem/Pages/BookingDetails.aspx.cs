using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using HotelBookingSystem;

public partial class Pages_BookingDetails : System.Web.UI.Page
{
    Booking current;

    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireLogin();

        Guid id;
        if (!Guid.TryParse(Request.QueryString["id"], out id))
        {
            lblError.Text = "Invalid booking ID.";
            HidePanels();
            return;
        }

        current = BookingManager.GetBooking(id);
        if (current == null)
        {
            lblError.Text = "Booking not found.";
            HidePanels();
            return;
        }

        var u = AuthHelper.CurrentUser();
        bool canView = (u.Role == UserRole.Admin) ||
                       (current.GuestEmail.Equals(u.Email, StringComparison.OrdinalIgnoreCase));

        if (!canView)
        {
            lblError.Text = "Access denied.";
            HidePanels();
            return;
        }

        if (!IsPostBack)
        {
            BindBooking();
            BindAdminControls(u);
        }
    }

    void HidePanels()
    {
        pnlGuestActions.Visible = false;
        pnlAdmin.Visible = false;
    }

    void BindBooking()
    {
        litBookingId.Text = current.BookingId.ToString();
        litStatus.Text = current.Status.ToString();

        litGuestName.Text = current.GuestName;
        litGuestEmail.Text = current.GuestEmail;
        litPhone.Text = current.Phone;

        litRoom.Text = $"Room {current.RoomId} ({current.RoomType})";

        litDates.Text = $"{current.CheckIn:yyyy-MM-dd} → {current.CheckOut:yyyy-MM-dd}";

        litNightly.Text = current.BasePricePerNight.ToString("0.00");
        litTotal.Text = current.FinalPriceTotal.ToString("0.00");

        if (current.SelectedServices.Any())
            litServices.Text = string.Join(", ",
                current.SelectedServices.Select(s => $"{s.Name} ({s.Price} SAR)"));
        else
            litServices.Text = "None";

        bltComments.Items.Clear();
        foreach (var c in current.AdminComments)
            bltComments.Items.Add(c);
    }

    void BindAdminControls(User u)
    {
        pnlAdmin.Visible = (u.Role == UserRole.Admin);
        pnlGuestActions.Visible = (u.Role == UserRole.Guest && current.Status != BookingStatus.Cancelled);

        if (u.Role == UserRole.Admin)
        {
            ddlStatus.DataSource = Enum.GetNames(typeof(BookingStatus));
            ddlStatus.DataBind();
            ddlStatus.SelectedValue = current.Status.ToString();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            decimal penalty;
            BookingManager.CancelBooking(current.BookingId, out penalty);

            lblCancelResult.Text = $"Booking cancelled. Penalty: {penalty:0.00} SAR";

            NotificationManager.SendNotification(
                current.GuestEmail,
                $"Your booking {current.BookingId} was cancelled. Penalty {penalty:0.00} SAR."
            );

            BindBooking();
        }
        catch (Exception ex)
        {
            lblCancelResult.Text = ex.Message;
        }
    }

    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        if (!AuthHelper.IsAdmin()) return;

        BookingManager.UpdateStatus(
            current.BookingId,
            (BookingStatus)Enum.Parse(typeof(BookingStatus), ddlStatus.SelectedValue)
        );

        NotificationManager.SendNotification(
            current.GuestEmail,
            $"Status for booking {current.BookingId} updated to {ddlStatus.SelectedValue}."
        );

        BindBooking();
    }

    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        if (!AuthHelper.IsAdmin()) return;

        if (!string.IsNullOrWhiteSpace(txtComment.Text))
        {
            BookingManager.AddAdminComment(current.BookingId, txtComment.Text.Trim());
            txtComment.Text = string.Empty;
            BindBooking();
        }
    }
}
