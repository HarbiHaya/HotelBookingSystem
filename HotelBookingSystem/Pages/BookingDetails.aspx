<%@ Page Title="Booking Details"
    MasterPageFile="~/MasterPages/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeFile="BookingDetails.aspx.cs"
    Inherits="Pages_BookingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblError" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

    <div class="card shadow-sm mb-4">
        <div class="card-header bg-dark text-white d-flex justify-content-between">
            <span>Booking <asp:Literal ID="litBookingId" runat="server" /></span>
            <span class="badge bg-info"><asp:Literal ID="litStatus" runat="server" /></span>
        </div>
        <div class="card-body row g-3">
            <div class="col-md-4">
                <strong>Guest:</strong>
                <div><asp:Literal ID="litGuestName" runat="server" /></div>
                <div><asp:Literal ID="litGuestEmail" runat="server" /></div>
                <div><asp:Literal ID="litPhone" runat="server" /></div>
            </div>

            <div class="col-md-4">
                <strong>Room:</strong>
                <div><asp:Literal ID="litRoom" runat="server" /></div>

                <strong>Dates:</strong>
                <div><asp:Literal ID="litDates" runat="server" /></div>
            </div>

            <div class="col-md-4">
                <strong>Cost Details:</strong>
                <div>Nightly Rate: <asp:Literal ID="litNightly" runat="server" /> SAR</div>
                <div>Total: <asp:Literal ID="litTotal" runat="server" /> SAR</div>

                <strong>Services:</strong>
                <div><asp:Literal ID="litServices" runat="server" /></div>
            </div>
        </div>
    </div>

    <asp:Panel ID="pnlGuestActions" runat="server" CssClass="mb-4">
        <h5>Guest Actions</h5>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel Booking"
            CssClass="btn btn-danger"
            OnClick="btnCancel_Click" />
        <asp:Label ID="lblCancelResult" runat="server"
                   CssClass="d-block mt-2 fw-bold"></asp:Label>
    </asp:Panel>

    <asp:Panel ID="pnlAdmin" runat="server" CssClass="mb-4 border-top pt-3">
        <h5>Admin Panel</h5>

        <div class="row g-3">
            <div class="col-md-4">
                <label class="form-label">Update Status</label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:Button ID="btnUpdateStatus" runat="server" Text="Save Status"
                    CssClass="btn btn-primary mt-2"
                    OnClick="btnUpdateStatus_Click" />
            </div>

            <div class="col-md-8">
                <label class="form-label">Add Internal Comment</label>
                <asp:TextBox ID="txtComment" runat="server" CssClass="form-control"
                             TextMode="MultiLine" Rows="3" />
                <asp:Button ID="btnAddComment" runat="server"
                    Text="Add Comment" CssClass="btn btn-secondary mt-2"
                    OnClick="btnAddComment_Click" />
            </div>
        </div>

        <div class="mt-4">
            <h6>Existing Comments</h6>
            <asp:BulletedList ID="bltComments" runat="server" CssClass="ps-3"></asp:BulletedList>
        </div>
    </asp:Panel>

</asp:Content>
