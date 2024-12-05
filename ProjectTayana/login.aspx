<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectTayana.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card-body">
        <h4 class="text-center f-w-500 mt-4 mb-3">Login</h4>
        <div class="form-group mb-3">
            &nbsp;<asp:TextBox ID="Account" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            &nbsp;<asp:TextBox ID="Password" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <div class="text-center mt-4">
            <asp:Button ID="Button1" runat="server" Text="登入" class="" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
         </div>
</asp:Content>
