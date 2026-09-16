<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="OLDSite.MainSearch" %>

<asp:Content runat="server" ID="HeaderContent" ContentPlaceHolderID="HeadContent">

    <script type="text/javascript" src="/Scripts/jquery-1.11.3.min.js"></script> 
    <script type="text/javascript" src="/Scripts/jquery-ui-1.11.4.min.js"></script> 
    <script type="text/javascript" src="/Scripts/jquery.multiselect.min.js"></script> 
    <script type="text/javascript" src="/Scripts/prettify.js"></script> 
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery(function () {
                jQuery("#UCStyle1 select").multiselect({
                    header: true,
                    height: 175,
                    minWidth: 331,
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
                $("#UCStyle2 select").multiselect({
                    header: false,
                    height: 175,
                    minWidth: 331,
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
                jQuery("#UCStyle3 select").multiselect({
                    header: false,
                    height: 175,
                    minWidth: 125,
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

</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <center>

    <h3>Search :</h3>
        </center>
    <table align="center">
        <tr>
            <td> 
                 My Gender:
            </td>
            <td>
                <div id="UCStyle3">
                    <asp:ListBox ID="MyGender" SelectionMode="Multiple" runat="server">
                    </asp:ListBox>
                </div>
            </td>
            <td>
                Looking for:
            </td>
            <td>
                <div id="UCStyle3">
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
                <div id="UCStyle3">
                    <asp:ListBox ID="MinAge" SelectionMode="Multiple" runat="server">
                    </asp:ListBox>
                </div>
            </td>
            <td>
                To:
            </td>
            <td>
                <div id="UCStyle3">
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
                <div id="UCStyle2">
                    <asp:ListBox ID="sCountry" SelectionMode="Multiple" runat="server">
                    </asp:ListBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                State:
            </td>
            <td colspan="3">
                <div id="UCStyle1">
                    <asp:ListBox ID="sState" SelectionMode="Multiple" runat="server">
                    </asp:ListBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                From:
            </td>
            <td>
                <div id="UCStyle3">
                    <asp:ListBox ID="MinHeight" SelectionMode="Multiple" runat="server">
                    </asp:ListBox>
                </div>
            </td>
            <td>
                To:
            </td>
            <td>
                <div id="UCStyle3">
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
                <div id="UCStyle1">
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
                <div id="UCStyle1">
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
                <div id="UCStyle1">
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
                <div id="UCStyle1">
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
                <div id="UCStyle1">
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
                <div id="UCStyle1">
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
                <div id="UCStyle1">
                    <asp:ListBox ID="Ethnicity" SelectionMode="Multiple" runat="server">
                    </asp:ListBox>
                </div>
            </td>
        </tr>
    </table>

    <p>&nbsp;</p>
    <center>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    </center>


</asp:Content>
