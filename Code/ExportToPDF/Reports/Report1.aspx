﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report1.aspx.cs" Inherits="Klat.Example.Reports.Report1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="ExportToPdfMergeRowButton" runat="server" Text="Export to PDF With Merge Row" OnClick="ExportToPdfMergeRowButton_Click" />
</asp:Content>
