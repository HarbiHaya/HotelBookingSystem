using System;
using System.Data;

public partial class Pages_RoomManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireAdmin();

        if (!IsPostBack)
        {
            // fill dropdown with enum names
            ddlType.DataSource = Enum.GetNames(typeof(RoomType));
            ddlType.DataBind();

            BindRooms();
        }
    }

    private void BindRooms()
    {
        rptRooms.DataSource = RoomManager.GetAllRooms();
        rptRooms.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            RoomManager.AddRoom(
                int.Parse(txtRoomId.Text),
                (RoomType)Enum.Parse(typeof(RoomType), ddlType.SelectedValue),
                chkAvailable.Checked,
                txtNotes.Text
            );
            lblMsg.Text = "Room added.";
            BindRooms();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            RoomManager.UpdateRoom(
                int.Parse(txtRoomId.Text),
                (RoomType)Enum.Parse(typeof(RoomType), ddlType.SelectedValue),
                chkAvailable.Checked,
                txtNotes.Text
            );
            lblMsg.Text = "Room updated.";
            BindRooms();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            RoomManager.DeleteRoom(int.Parse(txtRoomId.Text));
            lblMsg.Text = "Room deleted.";
            BindRooms();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
