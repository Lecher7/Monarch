<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OLDMain.aspx.cs" Inherits="OLDSite.MainPage" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/Scripts/jquery-1.11.3.min.js"></script> 
    <script type="text/javascript" src="/Scripts/jquery-ui-1.11.4.min.js"></script> 
    <script type="text/javascript" src="/Scripts/jquery.multiselect.min.js"></script> 
    <script type="text/javascript" src="/Scripts/prettify.js"></script> 
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery(function () {
                jQuery(".UCStyle1 select").multiselect({
                    header: true,
                    height: 175,
                    minWidth: 240,
                    size: 3,
                    classes: '',
                    checkAllText: 'Check all',
                    uncheckAllText: 'Uncheck all',
                    noneSelectedText: '0 Selected',
                    selectedText: '# selected',
                    selectedList: 0,
                    show: null,
                    hide: null,
                    autoOpen: false,
                    multiple: true,
                    position: {},
                    appendTo: "body"
                });
            });

            $(function () {
                $(".UCStyle2 select").multiselect({
                    header: false,
                    height: 175,
                    minWidth: 104,
                    size: 3,
                    classes: '',
                    /* checkAllText: 'Check all', */
                    /* uncheckAllText: 'Uncheck all', */
                    noneSelectedText: '0 Selected',
                    /* selectedText: '# selected', */
                    selectedList: 1,
                    show: null,
                    hide: null,
                    autoOpen: false,
                    multiple: false,
                    position: {},
                    appendTo: "body"
                });
            });

            jQuery(function () {
                jQuery(".UCStyle3 select").multiselect({
                    header: false,
                    height: 175,
                    minWidth: 240,
                    size: 3,
                    classes: '',
                    /* checkAllText: 'Check all',  */
                    /* uncheckAllText: 'Uncheck all',  */
                    noneSelectedText: '0 Selected',
                    /* selectedText: '# selected',  */
                    selectedList: 1,
                    show: null,
                    hide: null,
                    autoOpen: false,
                    multiple: false,
                    position: {},
                    appendTo: "body"
                });
            });

            jQuery(function () {
                jQuery('input').filter('.datepicker').datepicker({
                    yearRange: "-20:+0",
                    showOn: 'button',
                    buttonImageOnly: true,
                    buttonImage: '../Images/Calendar2.png',
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-90:+0"
                });
            });

        });
    </script>

    <style type="text/css"> 
      td.thickBorder
      { 
          border: solid #fff 1px;
      } 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>

    <table>
        <tr>
            <td style="vertical-align:top">
                <table>
                    <tr>
                        <td> 
                             My Gender:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle3">
                                <asp:ListBox ID="MyGender" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Looking for:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="MatchGender" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            From Age:
                        </td>
                        <td>
                            <div class="UCStyle2">
                                <asp:ListBox ID="MinAge" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                        <td>
                            To:
                        </td>
                        <td>
                            <div class="UCStyle2">
                                <asp:ListBox ID="MaxAge" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Country:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle3">
                                <asp:ListBox ID="sCountry" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            From:
                        </td>
                        <td>
                            <div class="UCStyle2">
                                <asp:ListBox ID="MinHeight" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                        <td>
                            To:
                        </td>
                        <td>
                            <div class="UCStyle2">
                                <asp:ListBox ID="MaxHeight" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Body Type:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="BodyType" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Intent:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="Intent" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Education:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="Education" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Zodiac:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="Zodiac" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Smoking:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="Smoking" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Religion:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="Religion" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ethnicity:
                        </td>
                        <td colspan="3">
                            <div class="UCStyle1">
                                <asp:ListBox ID="Ethnicity" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Zip Code:
                        </td>
                        <td>
                            <div class="UCStyle2">
                                <asp:TextBox ID="txtZipCode" Text="" Width="104px" runat="server">
                                </asp:TextBox>
                            </div>
                        </td>
                        <td>
                            
                        </td>
                        <td>
                            <div class="UCStyle2">
                                <asp:ListBox ID="lstRadius" SelectionMode="Multiple" runat="server">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                </table>

                <center>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                </center>
                <asp:Label ID="lblCurrUser" runat="server" Text="MyText" Visible="false"></asp:Label>
            </td>
            <td class="thickBorder" style="width:800px; vertical-align:top">

                <asp:UpdatePanel ID="SearchPanel" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="NavMenu" />
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>

                    <ContentTemplate>
                        <asp:Repeater ID="AcctRepeater" runat="server" onitemcommand="AcctRepeater_ItemCommand" OnItemDataBound="AcctRepeater_DataBinding">
                             <HeaderTemplate>  

                            </HeaderTemplate> 
                            <ItemTemplate>
                                <asp:Panel ID="Panel3" runat="server" BackColor="#ffffff" Height="126px" Style="margin-left: 1px;margin-bottom: 2px" Width="800px" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">            
                                    <table style="width:790px">
                                        <tr style="color:White; background-color:white">
                                            <td rowspan="5" style="width:115px"><asp:HyperLink runat="server" ID="hlThumbnail" NavigateUrl='<%# "../UserTemplate.aspx?U=" + Eval("UserID") %>'><img src='<%# "ImageCSharp.aspx?FileName=" + Eval("UserImg") %>' id="igImage1" runat="server" alt="" height="118" width="118" /></asp:HyperLink></td>  
                                        </tr>
                                        <tr style="height:7px">
                                            <td style="width:120px"> 
                                                <asp:Label ID="lblAcctNum" runat="server" width="120px" Font-Bold="true" Text='<%#Eval("UserName") %>'></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblDOS" runat="server" Font-Bold="true" ForeColor="CornflowerBlue" Text='<%#Eval("UserTitle") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height:7px">
                                            <td colspan="3">
                                                <asp:Label ID="lblLocation" runat="server" Font-Bold="true" ForeColor="DarkSlateGray" Text='<%# "Age: " + Eval("UserAge") + "  |  " + Eval("UserCity") + ", " + Eval("MemberState") + "  |  " + Eval("LastLoginDate", "{0:d}")  %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height:7px">
                                            <td colspan="3">
                                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("UserBody2") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height:7px">
                                            <td colspan = "2">
                                                <asp:Label ID="lblIntent" runat="server" Font-Bold="true" Text='<%#Eval("UIntent") %>'></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInCommon" runat="server" ForeColor="DarkGreen" Text='<%#Eval("NumInterests") + " Mutual Interests" %>'></asp:Label> 
                                            </td>
                                        </tr>   
                                    </table>
                                    </asp:Panel>
                            </ItemTemplate>
                            <SeparatorTemplate>  
                            <p></p>
                           </SeparatorTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="clear hideSkiplink" id="NavDiv" style="margin:0 auto; display: table;">
                    <asp:Menu ID="NavMenu" runat="server" CssClass="menu" 
                        IncludeStyleBlock="false" Orientation="Horizontal" width="703px"
                        BackColor="#CC3300" EnableViewState="true">
                        <Items> 
                            <asp:MenuItem NavigateUrl="~/Default.aspx" Text="First" Selectable="true" />
                        </Items>
                    </asp:Menu>
                </div>
            </td>
        </tr>
    </table>


</asp:Content>
