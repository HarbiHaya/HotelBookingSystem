<%@ Page Title="Admin Dashboard"
    MasterPageFile="~/MasterPages/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeFile="AdminDashboard.aspx.cs"
    Inherits="Pages_AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 class="mb-3">All Bookings (Admin)</h3>

    <asp:Repeater ID="rptAllBookings" runat="server">
        <HeaderTemplate>
            <table class="table table-hover table-bordered align-middle">
                <thead class="table-dark">
                    <tr>
                        <th>Guest</th>
                        <th>Room</th>
                        <th>Dates</th>
                        <th>Status</th>
                        <th>Total (SAR)</th>
                        <th>Comments</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("GuestName") %><br/>
                    <small><%# Eval("GuestEmail") %></small><br/>
                    <small><%# Eval("Phone") %></small>
                </td>
                <td>
                    <%# Eval("RoomId") %> (<%# Eval("RoomType") %>)
                </td>
                <td>
                    <%# ((DateTime)Eval("CheckIn")).ToString("yyyy-MM-dd") %> →
                    <%# ((DateTime)Eval("CheckOut")).ToString("yyyy-MM-dd") %>
                </td>
                <td><%# Eval("Status") %></td>
                <td><%# String.Format("{0:0.00}", Eval("FinalPriceTotal")) %></td>
                <td>
                    <td>
    <asp:Repeater ID="rptComments" runat="server" DataSource='<%# ((Booking)Container.DataItem).AdminComments %>'>
        <ItemTemplate>
            <div>- <%# Container.DataItem %></div>
        </ItemTemplate>
    </asp:Repeater>
</td>

                </td>
                <td>
                    <a class="btn btn-sm btn-primary mb-1 d-block"
                       href='BookingDetails.aspx?id=<%# Eval("BookingId") %>'>Open</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <a class="btn btn-secondary" href="RoomManagement.aspx">Room Management</a>

</asp:Content>
