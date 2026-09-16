<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTemplate.aspx.cs" Inherits="OLDSite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="UserPlate" style="width:800px; background-color:whitesmoke; margin-left:20px">
        <table>
            <tr>
                <td>
                    <asp:Image ID="UserImage1" runat="server" Height="115px" CommandArgument='<%#Eval("UserImg1") %>'></asp:Image>
                    <asp:Image ID="UserImage2" runat="server" Height="115px" CommandArgument='<%#Eval("UserImg2") %>'></asp:Image>
                    <asp:Image ID="UserImage3" runat="server" Height="115px" CommandArgument='<%#Eval("UserImg3") %>'></asp:Image>
                    <asp:Image ID="UserImage4" runat="server" Height="115px" CommandArgument='<%#Eval("UserImg4") %>'></asp:Image>
                    <asp:Image ID="UserImage5" runat="server" Height="115px" CommandArgument='<%#Eval("UserImg5") %>'></asp:Image>
                    <asp:Image ID="UserImage6" runat="server" Height="115px" CommandArgument='<%#Eval("UserImg6") %>'></asp:Image>
                </td>
            </tr>
        </table>

        <div class="clear hideSkiplink" id="TopMenu" style="width:800px">
            <asp:Menu ID="ContactMenu" runat="server" CssClass="menu" 
                IncludeStyleBlock="False" Orientation="Horizontal" width="500px"
                BackColor="#CC3300" onmenuitemclick="ContactMenu_MenuItemClick">
                <Items> 
                    <asp:MenuItem Text="Wink"/>
                    <asp:MenuItem NavigateUrl="../UserMessage.aspx?U=" Text="Message"/>
                    <asp:MenuItem NavigateUrl="../UserChat.aspx?U=" Text="Chat"/>
                    <asp:MenuItem Text="Add To Favorites"/>
                    <asp:MenuItem NavigateUrl="../OLDMain.aspx" Text="Back To Search" />
                </Items>
            </asp:Menu>
        </div>

        <table>
            <tr>
                <td>
                    <h1><asp:Label ID="lblUserName" runat="server" style="color:cornflowerblue; font-size:x-large; font-weight:bold" Text="MyText"></asp:Label></h1>
                </td>
                <td style="width:300px"></td>
                <td style="text-align:right"><asp:Label ID="lblMessagingMessages" runat="server" visible="false" Text="MyText" style="color:red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblUserAge" runat="server" Text="MyText"></asp:Label> year old <asp:Label ID="lblGender" runat="server" Text="MyText"></asp:Label>  . : ' : .  <asp:Label ID="lblState" runat="server" Text="MyText"></asp:Label>, <asp:Label ID="lblCountry" runat="server" Text="MyText"></asp:Label>
                </td>
            </tr>
        </table>
        <hr />
        <div>
            <asp:Panel ID="Panel3" runat="server" Height="275px" Style="float: left; margin-left: 1px; background-color:whitesmoke" Width="335px" BorderColor="LightSteelBlue" BorderStyle="Solid" BorderWidth="1px">
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
            <asp:Panel ID="Panel4" runat="server" Height="275px" Style="float: left; margin-left: 2px; background-color:whitesmoke" Width="458px" BorderColor="LightSteelBlue" BorderStyle="Solid" BorderWidth="1px">
                <table style="width:450px">
                    <tr style="border-bottom: 1px solid cornflowerblue;">
                        <td>
                            <asp:Label ID="lblHeadline" runat="server" style="text-align:center;font-weight:600;color:darkslateblue" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAboutMeX" runat="server" style="text-align:left; font-size:larger; color:cornflowerblue" Text="A Little About Me..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid cornflowerblue;">
                        <td>
                            <asp:Label ID="lblAboutMe" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAboutMyMatchx" runat="server" style="text-align:left; font-size:larger; color:cornflowerblue" Text="A Little About My Match..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid cornflowerblue;">
                        <td>
                            <asp:Label ID="lblAboutMyMatch" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAfterWorkx" runat="server" style="text-align:left; font-size:larger; color:cornflowerblue" Text="Once work is done, I love to..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid cornflowerblue;">
                        <td>
                            <asp:Label ID="lblAfterWork" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDesertIslex" runat="server" style="text-align:left; font-size:larger; color:cornflowerblue" Text="5 Desert Island Possessions..."></asp:Label>
                        </td>
                    </tr>
                    <tr style="border-bottom: 1px solid cornflowerblue;">
                        <td>
                            <asp:Label ID="lblDesertIsle" runat="server" style="text-align:left" Text="The user did not answer this question"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFaveArtsx" runat="server" style="text-align:left; font-size:larger; color:cornflowerblue" Text="My Favorite Movies/Music..."></asp:Label>
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
        <center>
        <h1>Send <asp:Label ID="lblPrompt" runat="server" style="text-align:left" Text="Send Prompt" /> a message now!</h1>
        <br /><asp:Label ID="lblErrorMsg" runat="server" style="text-align:left; color:blue" Visible="false" Text="Send Prompt" />
        <p></p>
        <asp:TextBox runat="server" ID="SendEmail" width="600" TextMode="MultiLine" Rows="6" />
        <p></p>
        <asp:Button runat="server" ID="btnSendEmail" OnClick="btnSendEmail_Click" Text="Send!"/>
        </center>
    </div>
    <br />
</asp:Content>
