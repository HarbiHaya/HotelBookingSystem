<%@ Page Title="Dashboard"
    Language="C#"
    MasterPageFile="~/MasterPages/Site.Master"
    AutoEventWireup="true"
    CodeFile="Dashboard.aspx.cs"
    Inherits="HotelBookingSystem.Pages.Dashboard"" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 class="mb-4">My Bookings</h3>

    <asp:Repeater ID="rptBookings" runat="server">
        <HeaderTemplate>
            <table class="table table-striped table-bordered align-middle">
                <thead class="table-dark">
                    <tr>
                        <th>ID</th>
                        <th>Room</th>
                        <th>Dates</th>
                        <th>Status</th>
                        <th>Total (SAR)</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("BookingId") %></td>
                <td>Room <%# Eval("RoomId") %> (<%# Eval("RoomType") %>)</td>
                <td>
                    <%# ((DateTime)Eval("CheckIn")).ToString("yyyy-MM-dd") %> →
                    <%# ((DateTime)Eval("CheckOut")).ToString("yyyy-MM-dd") %>
                </td>
                <td><%# Eval("Status") %></td>
                <td><%# String.Format("{0:0.00}", Eval("FinalPriceTotal")) %></td>
                <td>
                    <a class="btn btn-sm btn-outline-primary"
                       href='BookingDetails.aspx?id=<%# Eval("BookingId") %>'>View</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <a class="btn btn-success" href="CreateBooking.aspx">+ New Booking</a>

    <hr class="my-4" />

    <h4>Notifications</h4>
    <asp:Repeater ID="rptNotifications" runat="server">
        <ItemTemplate>
            <div class="alert alert-info p-2 my-2">
                <small class="text-muted">
                    <%# ((DateTime)Eval("SentAt")).ToString("yyyy-MM-dd HH:mm") %>
                </small><br />
                <%# Eval("Message") %>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
