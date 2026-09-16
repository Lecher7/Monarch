<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Account.Register" %>

<asp:Content runat="server" ID="HeaderContent" ContentPlaceHolderID="HeadContent">
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
                    minWidth: 220,
                    classes: '',
                    checkAllText: 'Check all',
                    uncheckAllText: 'Uncheck all',
                    noneSelectedText: 'Select',
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
                    minWidth: 220,
                    classes: '',
                    /* checkAllText: 'Check all', */
                    /* uncheckAllText: 'Uncheck all', */
                    noneSelectedText: 'Select',
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
                    minWidth: 220,
                    classes: '',
                    /* checkAllText: 'Check all',  */
                    /* uncheckAllText: 'Uncheck all',  */
                    noneSelectedText: 'Select',
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


</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="width: 950px; vertical-align: top; margin-left: 22px;">
        <table>
            <tr>
                <td>
                    <h1><%: Title %>.</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <h2>Use the form below to create a new account.  All fields must be completed.</h2>
                </td>
            </tr>

        </table>


                    <p class="message-info">
                        <asp:Label ID="lblErrorMsg" runat="server" Text="Passwords are required to be a minimum of 6 characters in length." Visible="False" />
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        
                            <table>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:TextBox runat="server" ID="UserName" width="220"/>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:TextBox runat="server" ID="Email" width="220" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label7" runat="server" AssociatedControlID="FName">First name</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:TextBox runat="server" ID="FName" width="220"/>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="lblCountry" runat="server" AssociatedControlID="sCountry">Country:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle3">
                                            <asp:ListBox ID="sCountry" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label8" runat="server" AssociatedControlID="sState">State:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle3">
                                            <asp:ListBox ID="sState" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label9" runat="server" AssociatedControlID="City">City:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle3">
                                            <asp:ListBox ID="City" SelectionMode="Multiple" runat="server" Enabled="True">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label4" runat="server" AssociatedControlID="Zipcode">Zip Code</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:TextBox runat="server" ID="Zipcode" width="220"  OnTextChanged="LoadCities_Leave" AutoPostBack="true"/>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label3" runat="server" AssociatedControlID="DOB">Date Of Birth</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:TextBox id="DOB" runat="server" class="datepicker" style="height: 14px; width: 202px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label1" runat="server" AssociatedControlID="MyGender">I am a:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle3">
                                            <asp:ListBox ID="MyGender" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label2" runat="server" AssociatedControlID="MatchGender">I am looking for a:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle1">
                                            <asp:ListBox ID="MatchGender" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label10" runat="server" AssociatedControlID="Goal">Goal:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Goal" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label11" runat="server" AssociatedControlID="Intent">Intent:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Intent" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label12" runat="server" AssociatedControlID="uStatus">Status:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="uStatus" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label13" runat="server" AssociatedControlID="Education">Education:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Education" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label14" runat="server" AssociatedControlID="Occupation">Occupation:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Occupation" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label15" runat="server" AssociatedControlID="Income">Income:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Income" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label16" runat="server" AssociatedControlID="Children">Children:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Children" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label17" runat="server" AssociatedControlID="Pets">Pets:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle1">
                                            <asp:ListBox ID="Pets" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label5" runat="server" AssociatedControlID="MyHeight">Height:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="MyHeight" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label6" runat="server" AssociatedControlID="BodyType">Body Type:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="BodyType" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label18" runat="server" AssociatedControlID="HairColor">Hair Color:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="HairColor" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label19" runat="server" AssociatedControlID="EyeColor">Eye Color:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="EyeColor" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label20" runat="server" AssociatedControlID="Drinking">Drinking:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Drinking" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label21" runat="server" AssociatedControlID="Smoking">Smoking:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Smoking" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label22" runat="server" AssociatedControlID="Ethnicity">Ethnicity:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Ethnicity" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label23" runat="server" AssociatedControlID="Religion">Religion:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Religion" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label26" runat="server" AssociatedControlID="Interests">Interests:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle1">
                                            <asp:ListBox ID="Interests" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label ID="Label25" runat="server" AssociatedControlID="Relationships">Relationships:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Relationships" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label ID="Label24" runat="server" AssociatedControlID="Zodiac">Zodiac:</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <div class="UCStyle2">
                                            <asp:ListBox ID="Zodiac" SelectionMode="Multiple" runat="server">
                                            </asp:ListBox>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td style="width:190px; vertical-align:top">
                                        <asp:Label ID="Label27" runat="server" AssociatedControlID="UserTitle">Headline:</asp:Label>
                                    </td>
                                    <td style="width:600px">
                                            <asp:TextBox runat="server" ID="UserTitle" width="600" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:190px; vertical-align:top">
                                        <asp:Label ID="Label28" runat="server" AssociatedControlID="UserBody">A Little About Me...:</asp:Label>
                                    </td>
                                    <td style="width:600px">
                                            <asp:TextBox runat="server" ID="UserBody" width="600" TextMode="MultiLine" Rows="6" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:190px; vertical-align:top">
                                        <asp:Label ID="Label29" runat="server" AssociatedControlID="UserAboutMyMatch">A Little About My Match...:</asp:Label>
                                    </td>
                                    <td style="width:600px">
                                            <asp:TextBox runat="server" ID="UserAboutMyMatch" width="600" TextMode="MultiLine" Rows="6" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:190px; vertical-align:top">
                                        <asp:Label ID="Label30" runat="server" AssociatedControlID="UserAfterWork">Once work is done, I love to...:</asp:Label>
                                    </td>
                                    <td style="width:600px">
                                            <asp:TextBox runat="server" ID="UserAfterWork" width="600" TextMode="MultiLine" Rows="6" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:190px; vertical-align:top">
                                        <asp:Label ID="Label31" runat="server" AssociatedControlID="UserDesertIsle">My 5 Desert Island Possessions...:</asp:Label>
                                    </td>
                                    <td style="width:600px">
                                            <asp:TextBox runat="server" ID="UserDesertIsle" width="600" TextMode="MultiLine" Rows="6" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:190px; vertical-align:top">
                                        <asp:Label ID="Label32" runat="server" AssociatedControlID="UserFaveArts">Favorite Movies/Music...:</asp:Label>
                                    </td>
                                    <td style="width:600px">
                                            <asp:TextBox runat="server" ID="UserFaveArts" width="600" TextMode="MultiLine" Rows="6" />
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td style="width:160px">
                                        <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:TextBox runat="server" ID="Password" width="220" TextMode="Password" /> 
                                    </td>
                                    <td style="width:180px">
                                        <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:TextBox runat="server" ID="ConfirmPassword" width="220" TextMode="Password" />                               
                                    </td>
                                </tr>


                            </table>
   
                       <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                    </fieldset>

        </div>

</asp:Content>