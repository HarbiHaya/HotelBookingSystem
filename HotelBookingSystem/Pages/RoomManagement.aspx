<%@ Page Title="Room Management"
    Language="C#"
    MasterPageFile="~/MasterPages/Site.Master"
    AutoEventWireup="true"
    CodeFile="RoomManagement.aspx.cs"
    Inherits="Pages_RoomManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 class="mb-3">Room Management</h3>

    <asp:Label ID="lblMsg" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

    <div class="card mb-4 p-3">
        <div class="row g-3">
            <div class="col-md-2">
                <label class="form-label">Room ID</label>
                <asp:TextBox ID="txtRoomId" runat="server" CssClass="form-control" />
            </div>

            <div class="col-md-3">
                <label class="form-label">Type</label>
                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select" />
            </div>

            <div class="col-md-2">
                <label class="form-label">Available?</label><br />
                <asp:CheckBox ID="chkAvailable" runat="server" CssClass="form-check-input" />
            </div>

            <div class="col-md-5">
                <label class="form-label">Notes / Maintenance</label>
                <asp:TextBox ID="txtNotes" runat="server" CssClass="form-control" />
            </div>

            <div class="col-md-12 d-flex gap-2 flex-wrap">
                <asp:Button ID="btnAdd" runat="server" Text="Add"
                    CssClass="btn btn-success" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update"
                    CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete"
                    CssClass="btn btn-danger" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>

    <asp:Repeater ID="rptRooms" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered table-striped">
                <thead class="table-dark">
                    <tr>
                        <th>ID</th>
                        <th>Type</th>
                        <th>Available</th>
                        <th>Notes</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("RoomId") %></td>
                <td><%# Eval("Type") %></td>
                <td><%# (bool)Eval("IsAvailable") ? "Yes" : "No" %></td>
                <td><%# Eval("Notes") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
