using System;
using System.Linq;

public partial class Pages_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireLogin();

        if (!IsPostBack)
        {
            var u = AuthHelper.CurrentUser();
            if (u == null)
            {
                // safety check. RequireLogin() should already redirect if not logged in.
                Response.Redirect("~/Pages/Login.aspx");
                return;
            }

            // Bookings list for this user
            rptBookings.DataSource = BookingManager.GetBookingsForUser(u.Email);
            rptBookings.DataBind();

            // Notifications for this user
            rptNotifications.DataSource = NotificationManager.GetForUser(u.Email).ToList();
            rptNotifications.DataBind();
        }
    }
}
