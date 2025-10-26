using System;
using System.Linq;

public partial class Pages_CreateBooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireLogin();

        if (!IsPostBack)
        {
            // Populate rooms dropdown
            ddlRoom.DataSource = RoomManager.GetAllRooms()
                .Select(r => new
                {
                    Text = $"Room {r.RoomId} ({r.Type}) {(r.IsAvailable ? "" : "[UNAVAILABLE]")}",
                    Value = r.RoomId.ToString()
                })
                .ToList();

            ddlRoom.DataTextField = "Text";
            ddlRoom.DataValueField = "Value";
            ddlRoom.DataBind();

            // Populate services checkbox list
            cblServices.DataSource = DataManager.Services
                .Select(s => new
                {
                    Text = $"{s.Name} (+{s.Price} SAR)",
                    Value = s.Name
                })
                .ToList();

            cblServices.DataTextField = "Text";
            cblServices.DataValueField = "Value";
            cblServices.DataBind();
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            var u = AuthHelper.CurrentUser();
            if (u == null)
            {
                // should not happen because RequireLogin() already redirected,
                // but just in case:
                Response.Redirect("~/Pages/Login.aspx");
                return;
            }

            var selectedServices = cblServices.Items
                .Cast<System.Web.UI.WebControls.ListItem>()
                .Where(i => i.Selected)
                .Select(i => i.Value)
                .ToList();

            var booking = BookingManager.CreateBooking(
                guestEmail: u.Email,
                guestName: txtName.Text.Trim(),
                phone: txtPhone.Text.Trim(),
                roomId: int.Parse(ddlRoom.SelectedValue),
                checkIn: DateTime.Parse(txtCheckIn.Text),
                checkOut: DateTime.Parse(txtCheckOut.Text),
                selectedServiceNames: selectedServices
            );

            NotificationManager.SendNotification(
                u.Email,
                $"Your booking {booking.BookingId} is created as {booking.Status}."
            );

            Response.Redirect($"BookingDetails.aspx?id={booking.BookingId}");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
