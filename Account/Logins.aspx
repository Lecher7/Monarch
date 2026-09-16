<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logins.aspx.cs" Inherits="OLDSite.Account" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="HeaderContent" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="width: 750px; vertical-align: top; margin-left: 22px;">
        <table>
            <tr>
                <td>
                    <h1><%: Title %>.</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <h2>Use the form below to log in.</h2>
                </td>
            </tr>

        </table>
    <section id="loginForm">
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <table>
                        <tr>
                            <td style="width:150px">
                                <asp:Label runat="server" AssociatedControlID="UserName">User name:</asp:Label>
                            </td>
                            <td style="width:250px">
                                <asp:TextBox runat="server" ID="UserName" width="200"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:150px">
                                <asp:Label runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td style="width:250px">
                                <asp:TextBox runat="server" ID="Password" width="200" TextMode="Password" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember Me?</asp:Label>
                            </td>
                        </tr>
                    </table>

                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log in" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>
        </div>
</asp:Content>
