<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTemplate.aspx.cs" Inherits="OLDSite.WebForm1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.11.3.min.js"></script> 
    <script type="text/javascript" src="../Scripts/jquery.fancybox.pack.js"></script> 
    <link href="../Styles/jquery.fancybox.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function() {
            $(".fancybox").fancybox({
                parent: "form:first",
		        openEffect	: 'none',
		        closeEffect : 'none',
		        prevEffect	: 'none',
		        nextEffect	: 'none',
		        helpers		: {
			        title	: { type : 'inside' },
			        buttons	: {}
		        }

	        });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="UserPlate" style="width:820px; background-color:#f5f5f5; margin-left:20px">
        <table>
            <tr>
                <td runat="server" id="igHide1" visible="false"><a runat="server" id="fbImg1" class="fancybox" rel="ProfileImg" href="" title=""><img src="" id="igImage1" runat="server" alt="" height="100" width="100" /></a></td>
                <td runat="server" id="igHide2" visible="false"><a runat="server" id="fbImg2" class="fancybox" rel="ProfileImg" href="" title=""><img src="" id="igImage2" runat="server" alt="" height="100" width="100" /></a></td>
                <td runat="server" id="igHide3" visible="false"><a runat="server" id="fbImg3" class="fancybox" rel="ProfileImg" href="" title=""><img src="" id="igImage3" runat="server" alt="" height="100" width="100" /></a></td>    
                <td runat="server" id="igHide4" visible="false"><a runat="server" id="fbImg4" class="fancybox" rel="ProfileImg" href="" title=""><img src="" id="igImage4" runat="server" alt="" height="100" width="100" /></a></td>
                <td runat="server" id="igHide5" visible="false"><a runat="server" id="fbImg5" class="fancybox" rel="ProfileImg" href="" title=""><img src="" id="igImage5" runat="server" alt="" height="100" width="100" /></a></td>
                <td runat="server" id="igHide6" visible="false"><a runat="server" id="fbImg6" class="fancybox" rel="ProfileImg" href="" title=""><img src="" id="igImage6" runat="server" alt="" height="100" width="100" /></a></td>    
            </tr>
        </table>

        <div class="clear hideSkiplink" id="TopMenu" style="width:820px">

            <asp:Menu ID="ContactMenu" runat="server" CssClass="menu" 
                IncludeStyleBlock="False" Orientation="Horizontal" width="500px"
                BackColor="#CC3300" onmenuitemclick="ContactMenu_MenuItemClick">
                <Items> 
                    <asp:MenuItem Text="Wink"/>
                <%--    <asp:MenuItem NavigateUrl="../UserChat.aspx?U=" Text="Chat"/>  --%>
                <%--    <asp:MenuItem NavigateUrl="../UserMessage.aspx?U=" Text="Message"/>  --%>
                    <asp:MenuItem Text="Add To Favorites"/>
                    <asp:MenuItem NavigateUrl="../OLDMain.aspx" Text="Back To Search" />
                </Items>
            </asp:Menu>
        </div>

        <table>
            <tr>
                <td>
                    <h1><asp:Label ID="lblUserName" runat="server" style="color:#6495ed; font-size:x-large; font-weight:bold" Text="MyText"></asp:Label></h1>
                </td>
                <td style="width:300px"></td>
                <td style="text-align:right"><asp:Label ID="lblMessagingMessages" runat="server" visible="false" Text="MyText" style="color:red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblUserAge" runat="server" Text="MyText"></asp:Label> year old <asp:Label ID="lblGender" runat="server" Text="MyText"></asp:Label>  . : ' : .  <asp:Label ID="lblCity" runat="server" Text="MyText"></asp:Label>, <asp:Label ID="lblState" runat="server" Text="MyText"></asp:Label>, <asp:Label ID="lblCountry" runat="server" Text="MyText"></asp:Label>
                </td>
            </tr>
        </table>
        <hr />
        <div>
            <asp:Panel ID="Panel3" runat="server" Height="275px" Style="float: left; margin-left: 1px; background-color:#f5f5f5" Width="335px" BorderColor="LightSteelBlue" BorderStyle="Solid" BorderWidth="1px">
            <table>
                <tr>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:Label ID="lblUserStatus" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Ethnicity:
                    </td>
                    <td>
                        <asp:Label ID="lblEthnicity" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Body Type:
                    </td>
                    <td>
                        <asp:Label ID="lblBodyType" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Height:
                    </td>
                    <td>
                        <asp:Label ID="lblHeight" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Religion:
                    </td>
                    <td>
                        <asp:Label ID="lblReligion" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Smoke:
                    </td>
                    <td>
                        <asp:Label ID="lblSmoker" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Drink:
                    </td>
                    <td>
                        <asp:Label ID="lblDrinker" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Zodiac:
                    </td>
                    <td>
                        <asp:Label ID="lblZodiac" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Education:
                    </td>
                    <td>
                        <asp:Label ID="lblEducation" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        Income:
                    </td>
                    <td>
                        <asp:Label ID="lblIncome" runat="server" Text="MyText"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Viewed:
                    </td>
                    <td>
                        <asp:Label ID="lblLastViewed" runat="server" Text="MyText" ForeColor="SlateGray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Winked:
                    </td>
                    <td>
                        <asp:Label ID="lblLastWinked" runat="server" Text="MyText" ForeColor="SlateGray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Messaged:
                    </td>
                    <td>
                        <asp:Label ID="lblLastMessaged" runat="server" Text="MyText" ForeColor="SlateGray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCurrUser" runat="server" Text="MyText" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUserID" runat="server" Text="MyText" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="Panel4" runat="server" Height="275px" ScrollBars="Vertical" Style="float: left; margin-left: 2px; background-color:#f5f5f5" Width="468px" BorderColor="LightSteelBlue" BorderStyle="Solid" BorderWidth="1px">
                <table style="width:450px">
                    <tr style="border-bottom: 1px solid #6495ed;">
                        <td style="background-color:#e6e6e6">
                            <asp:Label ID="lblHeadline" runat="server" style="text-align:center;font-weight:600;color:#483d8b" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAboutMeX" runat="server" style="text-align:left; font-size:larger; color:#6495ed" Text="A Little About Me..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid #6495ed;">
                        <td>
                            <asp:Label ID="lblAboutMe" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAboutMyMatchx" runat="server" style="text-align:left; font-size:larger; color:#6495ed" Text="A Little About My Match..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid #6495ed;">
                        <td>
                            <asp:Label ID="lblAboutMyMatch" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAfterWorkx" runat="server" style="text-align:left; font-size:larger; color:#6495ed" Text="Once work is done, I love to..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid #6495ed;">
                        <td>
                            <asp:Label ID="lblAfterWork" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDesertIslex" runat="server" style="text-align:left; font-size:larger; color:#6495ed" Text="5 Desert Island Possessions..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid #6495ed;">
                        <td>
                            <asp:Label ID="lblDesertIsle" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFaveArtsx" runat="server" style="text-align:left; font-size:larger; color:#6495ed" Text="My Favorite Movies/Music..."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFaveArts" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </div>
        <div style="clear"></div>
        <p></p>

        <asp:label ID="lblInterests" runat="server" Text="Interests" Width="807px" BackColor="#e6e6e6" ForeColor="#483d8b" style="text-align:center" />
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="100px" ScrollBars="Vertical" Style="float: left; margin-left: 1px; background-color:#f5f5f5" Width="807px" BorderColor="LightSteelBlue" BorderStyle="Solid" BorderWidth="1px">
                <div id="div1" runat="server" class="clear" style="border-width:1px; margin-left:10px; margin-top:10px;"></div>
            </asp:Panel>
        </div>

        <div style="clear"></div>
        
<!--  ************************************  -->
        <asp:modalpopupextender id="MdlCommentsExtender" runat="server" 
                targetcontrolid="btnReportUser" popupcontrolid="pnlComments"
                popupdraghandlecontrolid="PopupHeader" drag="True"
                backgroundcssclass="ModalPopupBG" Enabled="False"  >
        </asp:modalpopupextender>
 
        <asp:panel id="pnlComments" style="display: none" runat="server" BackColor="White" CssClass="modalPopup">
                <div class="HellowWorldPopup">
                        <div class="PopupHeader" id="Div3" style="border: thin solid #000000; vertical-align: middle; text-align: center; background-color: #C0C0C0; color: #000000; font-weight: bold; height: 40px;" ><br />Report User</div>
                                <div class="PopupBody" style="background-color: #FFFFFF">
                                        <table style="width: 300px">
                                                <tr style="text-align:left">
                                                        <td style="padding:4px"><asp:Label ID="rlblIDLabel" runat="server" Text="User ID:"></asp:Label></td>
                                                        <td style="padding:4px"><asp:Label ID="rlblUserID" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr style="text-align:left">
                                                        <td style="padding:4px"><asp:Label ID="rlblNameLabel" runat="server" Text="User Name:"></asp:Label></td>
                                                        <td style="padding:4px"><asp:Label ID="rlblUserName" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr style="text-align:left">
                                                        <td style="padding:4px" colspan="2"><asp:Label ID="rlblCommentBox" runat="server" Text="Comment:"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                        <td style="padding:4px" colspan="2">
                                                                <asp:TextBox ID="txtCommentBox" TextMode="MultiLine" CssClass="textbox" Wrap="True" Height="70px" Width="270px" Font-Size="Small" Rows="3" runat="server" />
                                                        </td>
                                                </tr> 
                                        </table>
                                </div>
                                <div class="Controls">
                                        <table style="width: 300px">
                                                <tr>
                                                   <td style="vertical-align: middle; text-align: center"> <asp:Button ID="mdlCmntsOk_Click" runat="server" Text="Submit" CssClass="textbox" Height="28px" Width="75px" OnClick="mdlCommentsOk_Click" /></td>
                                                   <td style="vertical-align: middle; text-align: center"> <asp:Button ID="mdlCmntsCancel_Click" runat="server" Text="Cancel" CssClass="textbox" Height="28px" Width="75px" OnClick="mdlCommentsCancel_Click" /></td>
                                                </tr>
                                        </table>
                                </div>
                        </div>
                </div> 
        </asp:panel>
<!--  ************************************  -->

        <table width="830px">
            <tr>
            <%--  <td><b><a runat="server" id="rtfLink" href="">Report This Profile</a></b></td>  --%>
                <td align="right"><asp:Button id="btnReportUser" runat="server" OnClick="btnPopup_Click" Text="Report This Profile" /></td>
            </tr>
        </table>

        <div style="clear: left;"></div>
        <div style="width: 820px">
        <center>
            <table>
                <tr>
                    <td>
                        <h1>Send <asp:Label ID="lblPrompt" runat="server" style="text-align:left" Text="Send Prompt" /> a message now!</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblErrorMsg" runat="server" style="text-align:left; color:blue" Visible="false" Text="Send Prompt" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="SendEmail" width="600" TextMode="MultiLine" Rows="6" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnSendEmail" OnClick="btnSendEmail_Click" Text="Send!"/>
                    </td>
                </tr>
            </table>
        </center>
        </div>
    </div>
    <br />
</asp:Content>
