using System;
using System.Data.SqlClient;


public partial class Pages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // don't force login here; this is the login page
        if (AuthHelper.IsLoggedIn())
        {
            // redirect based on role
            var u = AuthHelper.CurrentUser();
            if (u.Role == UserRole.Admin)
                Response.Redirect("~/Pages/AdminDashboard.aspx");
            else
                Response.Redirect("~/Pages/Dashboard.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        var u = DataManager.GetUser(txtEmail.Text.Trim(), txtPassword.Text.Trim());

        if (u == null)
        {
            lblError.Text = "Invalid email or password.";
            return;
        }

        AuthHelper.SignIn(u);

        if (u.Role == UserRole.Admin)
            Response.Redirect("~/Pages/AdminDashboard.aspx");
        else
            Response.Redirect("~/Pages/Dashboard.aspx");
    }
}
