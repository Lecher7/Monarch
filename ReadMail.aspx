<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReadMail.aspx.cs" Inherits="OLDSite.ReadMail" %>

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
                    <asp:MenuItem Text="Mail" NavigateUrl="~/frmMessages.aspx"/>
                    <asp:MenuItem Text="Winks" NavigateUrl="~/frmMessages.aspx"/>
                </Items>
            </asp:Menu>
        </div>

        <table>
            <tr>
                <td><asp:Label ID="lblCurrUser" runat="server" Text="MyText" Visible="false"></asp:Label><asp:Label ID="lblMatchUser" runat="server" Text="MyText" Visible="false"></asp:Label></td>
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
                                                <td style="width:95px"> 
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width:110px"> 
                                                    <asp:Label ID="lblFromH" runat="server" Text="From"></asp:Label>
                                                </td>
                                                <td style="width:317px">
                                                    <asp:Label ID="lblReceivedH" runat="server" Text="Received"></asp:Label>
                                                </td>
                                                <td style="width:118px"> 
                                                    <asp:Label ID="lblViewedH" runat="server" width="120px" Text="Viewed"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFlaggedH" runat="server" Text="Flagged"></asp:Label>
                                                </td>
                                            </tr>
                                      </table>
                                </HeaderTemplate> 
                                <ItemTemplate>
                                    <asp:Panel ID="Panel3" runat="server" BackColor="#ffffff" Style="margin-left: 1px;margin-bottom: 2px" Width="790px" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">            
                                        <table style="width:760px">
                                            <tr style="color:White; background-color:#007ACC">
                                                <td rowspan="3" style="width:65px; vertical-align:top"><asp:HyperLink runat="server" ID="hlThumbnail" NavigateUrl='<%# "../UserTemplate.aspx?U=" + Eval("UserID") %>'><img src='<%# "ImageCSharp.aspx?FileName=" + Eval("UserImg") %>' id="igImage1" runat="server" alt="" height="65" width="65" /></asp:HyperLink></td>  
                                            </tr>
                                            <tr style="height:7px">
                                                <td style="width:120px"> 
                                                    <asp:Label ID="lblAcctNum" runat="server" width="120px" Text='<%#Eval("MessagerName") %>'></asp:Label>
                                                </td>
                                                <td style="width:350px">
                                                    <asp:Label ID="lblDOS" runat="server" Text='<%#Eval("MessageDate") %>'></asp:Label>
                                                </td>
                                                <td style="width:120px"> 
                                                    <asp:Label ID="lblViewed" runat="server" width="120px" Text='<%#Eval("MsgViewed") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFlagged" runat="server" Text='<%#Eval("MsgFlagged") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("uMessage") %>'></asp:Label>
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
