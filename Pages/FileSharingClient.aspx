﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileSharingClient.aspx.cs" Inherits="fileSharing.Pages.fileSharingClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Izvelēties failu kopīgošanai:<INPUT id="oFile" type="file" runat="server" NAME="oFile"  Height="39px" Width="250px">
    Norādiet ē-pastu:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    Ievadiet komentāru:
    <asp:TextBox ID="TextBox2" runat="server" Height="48px" Width="150px"></asp:TextBox>
    <br />
    noradiet paroli (Ta ir 123): <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Height="38px" OnClick="Button1_Click" Text="Dalīties!" Width="78px" />
    <br />
    <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
    <asp:GridView ID="dataGridViewLogfile" class="table" runat="server">
    </asp:GridView>

</asp:Content>
