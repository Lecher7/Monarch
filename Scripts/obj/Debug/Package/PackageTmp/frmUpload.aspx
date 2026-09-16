<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="frmUpload.aspx.cs" Inherits="OLDSite.frmUpload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblCurrUser" runat="server" Text="MyText" Visible="false"></asp:Label>
<p></p>
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:TextBox ID="txtPhotoInfo" runat="server" />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
<hr />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
    <Columns>
        <asp:BoundField DataField="Text" />
        <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
    </Columns>
</asp:GridView>

<table>
    <tr>
        <td runat="server" id="igHide1"><img src="Image1" id="igImage1" runat="server" alt=""/></td>
        <td runat="server" id="igHide2"><img src="Image2" id="igImage2" runat="server" alt=""/></td>
        <td runat="server" id="igHide3"><img src="Image3" id="igImage3" runat="server" alt=""/></td>    
        <td runat="server" id="igHide4"><img src="Image4" id="igImage4" runat="server" alt=""/></td>
        <td runat="server" id="igHide5"><img id="igImage5" src="Image5" runat="server" alt=""/></td>
        <td runat="server" id="igHide6"><img id="igImage6" src="Image6" runat="server" alt="" /></td>    
    </tr>

</table>

<asp:Label Text="" ID="lblErrorMsg" runat="server" Visible="false" Width="500"></asp:Label>
</asp:Content>

