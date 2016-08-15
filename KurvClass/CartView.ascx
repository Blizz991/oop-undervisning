<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartView.ascx.cs" Inherits="KurvClass.CartView" %>

<asp:Repeater ID="CartView_Repeater" runat="server" OnItemCommand="CartView_Repeater_ItemCommand">
    <HeaderTemplate>
        <table>
            <thead>
                <th>Navn</th>
                <th>Pris</th>
                <th>Antal</th>
                <th>I alt</th>
                <th></th>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("Name") %></td>
            <td><%#Eval("Price") %></td>
            <td>
                <asp:Button ID="Subtract_One_Item_Button" Text="-" CommandName="minus" CommandArgument='<%#Eval("Id") %>' runat="server" />
                <%#Eval("Amount") %>
                <asp:Button ID="Add_One_Item_Button" Text="+" CommandName="plus" CommandArgument='<%#Eval("Id") %>' runat="server" /></td>
            </td>
            <td><%#Eval("TotalPrice") %></td>
            <td></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>

<asp:Button ID="Empty_Cart_Button" Text="Tøm Kurv" OnClick="Empty_Cart_Button_Click" runat="server" />
<asp:Button ID="Checkout_Cart_Button" Text="Gå til betaling" OnClick="Checkout_Cart_Button_Click" runat="server" />
