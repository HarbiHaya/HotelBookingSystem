using System;

public partial class Pages_AdminDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireAdmin();

        if (!IsPostBack)
        {
            rptAllBookings.DataSource = BookingManager.GetAllBookings();
            rptAllBookings.DataBind();
        }
    }
}
