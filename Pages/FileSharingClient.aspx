<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileSharingClient.aspx.cs" Inherits="fileSharing.Pages.fileSharingClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-fluid">
    <div class="form-group">
        <label class="custom-file-label" for="customFile" style="margin-top: 30px;">
            Izvelēties failu kopīgošanai:</label>
    <INPUT id="oFile" type="file" runat="server" NAME="oFile"  Height="39px" Width="250px">
    </div>

    <div class="form-group">
    <label for="TextBox1">Norādiet ē-pastu: </label>
    <asp:TextBox type="email" class="form-control" ID="TextBox1" runat="server" aria-describedby="emailHelp" placeholder="Enter email"></asp:TextBox>
    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
    <div class="form-group"> 
        <label for="TextBox2">Ievadiet komentāru:</label>
    <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="1 line comment"></asp:TextBox>
    </div>
    <div class="form-group">
    <label for="PasswordBox">noradiet paroli (Ta ir 123):</label>
    <asp:TextBox type="password" class="form-control" ID="PasswordBox" placeholder="Password" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
    <asp:Button ID="Button1" runat="server" Height="38px" OnClick="Button1_Click" Text="Dalīties!" Width="78px" />
    </div>
    <div class="form-group">
    <asp:Label id="lblUploadResult" class="label label-warning" Runat="server"></asp:Label>
    </div>
        
    <div class="col-12">
    <asp:GridView class="table" ID="dataGridViewLogfile" runat="server">
    </asp:GridView>
        </div>
   </div>
</asp:Content>
