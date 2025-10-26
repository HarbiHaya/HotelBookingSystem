using System;

public partial class MasterPages_Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = AuthHelper.CurrentUser();
        if (user != null)
        {
            lblUser.Text = $"{user.FullName} ({user.Role})";
        }
        else
        {
            lblUser.Text = "";
        }

        // hide logout if not logged in
        btnLogout.Visible = user != null;
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        AuthHelper.SignOut();
        Response.Redirect("~/Pages/Login.aspx");
    }
}
