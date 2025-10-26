<%@ Page Title="Login"
    Language="C#"
    MasterPageFile="~/MasterPages/Site.Master"
    AutoEventWireup="true"
    CodeFile="Login.aspx.cs"
    Inherits="Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center">
        <div class="card p-4 shadow" style="min-width:320px;max-width:380px;">
            <h4 class="mb-3 text-center">Hotel Booking Login</h4>

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" runat="server"
                             CssClass="form-control" TextMode="Password" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Sign in"
                        CssClass="btn btn-primary w-100"
                        OnClick="btnLogin_Click" />

            <asp:Label ID="lblError" runat="server"
                       CssClass="text-danger mt-3 d-block" />
        </div>
    </div>

</asp:Content>
