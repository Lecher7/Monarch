<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OLDSite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="LoginPanel" runat="server" BackColor="#ffffff" Height="136px" Style="margin-left: 10px;margin-bottom: 2px" Width="270px" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">

        <table style="padding:4px">
            <tr>
                <td colspan="2" style="text-align:center">
                    <h1>Login</h1>
                </td>
            </tr>
            <tr>
                <td>
                    Username:
                </td>
                <td>
                    <asp:TextBox ID="UserName" runat="server" width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="Password" runat="server" width="150px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" />
                </td>
            </tr>
        </table>
            <p></p>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /> </p>
        <p>
            <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid. Please try again."
                Visible="False"></asp:Label> </p>
    </asp:Panel>
</asp:Content>
