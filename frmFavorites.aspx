<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFavorites.aspx.cs" Inherits="OLDSite.frmFavorites" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="UserPlate" style="width:800px; background-color:whitesmoke; margin-left:20px">
        <div class="clear hideSkiplink" id="TopMenu" style="width:800px">
            <asp:Menu ID="ContactMenu" runat="server" CssClass="menu" 
                IncludeStyleBlock="False" Orientation="Horizontal" width="500px"
                BackColor="#CC3300" onmenuitemclick="ContactMenu_MenuItemClick">
                <Items> 
                    <asp:MenuItem Text="My Favorites"/>
                    <asp:MenuItem Text="Favorited Me"/>
           <%--         <asp:MenuItem Text="Common Interests"/>   --%>
                </Items>
            </asp:Menu>
        </div>
        <table>
            <tr>
                <td><asp:Label ID="lblCurrUser" runat="server" Text="Favorites" Visible="false"></asp:Label></td>
            </tr>
            <tr>
                <td><h1><asp:Label ID="lblMailbox" runat="server" style="color:cornflowerblue; font-size:x-large; font-weight:bold" Text="MyText"></asp:Label></h1></td>
            </tr>
            <tr>
                <td>

                    <asp:UpdatePanel ID="SearchPanel" runat="server">

                        <ContentTemplate>
                            <asp:Repeater ID="MailRepeater" runat="server" onitemcommand="MailRepeater_ItemCommand" OnItemDataBound="MailRepeater_DataBinding">
                                 <HeaderTemplate>  
                                     <table>
                                            <tr style="height:7px">
                                                <td style="width:190px"> 
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width:160px">
                                                    <asp:Label ID="lblFlaggedH" runat="server" Text="Date Faved"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="# of Views"></asp:Label>
                                                </td>
                                            </tr>
                                      </table>
                                </HeaderTemplate> 
                                <ItemTemplate>
                                    <asp:Panel ID="Panel3" runat="server" BackColor="#ffffff" Height="76px" Style="margin-left: 1px;margin-bottom: 2px" Width="790px" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">            
                                        <table style="width:760px">
                                            <tr style="color:White; background-color:#007ACC">
                                                <td rowspan="3" style="width:65px"><asp:HyperLink runat="server" ID="hlThumbnail" NavigateUrl='<%# "../UserTemplate.aspx?U=" + Eval("OtherUserID") %>'><img src='<%# "ImageCSharp.aspx?FileName=" + Eval("UserImg") %>' id="igImage1" runat="server" alt="" height="65" width="65" /></asp:HyperLink></td>  
                                            </tr>
                                            <tr style="height:7px">
                                                <td style="width:100px"> 
                                                    <asp:Label ID="lblAcctNum" runat="server" width="120px" Text='<%#Eval("FaverName") %>'></asp:Label>
                                                </td>
                                                <td style="width:170px">
                                                    <asp:Label ID="lblDOS" runat="server" Text='<%#Eval("DateLastFaved") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblContacts" runat="server" Text='<%#Eval("Views") %>' ></asp:Label>
                                                </td>
                                            </tr> 
                                        </table>
                                        </asp:Panel>
                                </ItemTemplate>
                                <SeparatorTemplate>  

                               </SeparatorTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

