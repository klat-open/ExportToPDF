<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pdf.aspx.cs" Inherits="Klat.Example.Pdf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="ExportToPdfButton" runat="server" Text="Export to PDF" OnClick="ExportToPdfButton_Click" />
    <asp:Button ID="ExportToPdfMergeRowButton" runat="server" Text="Export to PDF With Merge Row" OnClick="ExportToPdfMergeRowButton_Click" />
</asp:Content>
