<%@ Page Title="Create Booking"
    Language="C#"
    MasterPageFile="~/MasterPages/Site.Master"
    AutoEventWireup="true"
    CodeFile="CreateBooking.aspx.cs"
    Inherits="Pages_CreateBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 class="mb-4">New Booking</h3>

    <asp:Label ID="lblMsg" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

    <div class="row g-3">
        <div class="col-md-4">
            <label class="form-label">Full Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        </div>

        <div class="col-md-4">
            <label class="form-label">Phone</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
        </div>

        <div class="col-md-4">
            <label class="form-label">Room</label>
            <asp:DropDownList ID="ddlRoom" runat="server" CssClass="form-select" />
        </div>

        <div class="col-md-3">
            <label class="form-label">Check-In</label>
            <asp:TextBox ID="txtCheckIn" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="col-md-3">
            <label class="form-label">Check-Out</label>
            <asp:TextBox ID="txtCheckOut" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="col-md-6">
            <label class="form-label">Additional Services</label><br />
            <asp:CheckBoxList ID="cblServices" runat="server" CssClass="form-check" />
        </div>

        <div class="col-12">
            <asp:Button ID="btnCreate" runat="server"
                Text="Create Booking"
                CssClass="btn btn-success"
                OnClick="btnCreate_Click" />
        </div>
    </div>

</asp:Content>
