<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExportToPDF._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="ExportToPDF" runat="server" OnClick="ExportToPDF_OnClick" Text="Export To PDF" />

</asp:Content>
