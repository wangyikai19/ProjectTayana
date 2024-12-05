<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="CertificateMgt.aspx.cs" Inherits="ProjectTayana.CertificateMgt" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManagerMenuContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h6>Upload Horizontal Group Image :</h6>
        <div class="input-group my-3">
            <asp:FileUpload ID="imageUploadH" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
            <asp:Button ID="UploadHBtn" runat="server" Text="Upload" class="btn btn-primary" OnClick="UploadHBtn_Click" />
        </div>
        <h6>Horizontal Image List :</h6>
        <asp:RadioButtonList ID="RadioButtonListH" runat="server" class="my-3" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListH_SelectedIndexChanged" CellPadding="10" RepeatColumns="2" RepeatDirection="Horizontal"></asp:RadioButtonList>
        <asp:Button ID="DelHImageBtn" runat="server" Text="Delete Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" OnClick="DelHImageBtn_Click" />
    </div>
       <div>
       <h6>Upload Vertical  Group Image :</h6>
       <div class="input-group my-3">
           <asp:FileUpload ID="imageUploadV" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
           <asp:Button ID="UploadVBtn" runat="server" Text="Upload" class="btn btn-primary" OnClick="UploadVBtn_Click" />
       </div>
       <h6>Vertical Image List :</h6>
       <asp:RadioButtonList ID="RadioButtonListV" runat="server" class="my-3" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListV_SelectedIndexChanged" CellPadding="10" RepeatColumns="2" RepeatDirection="Vertical"></asp:RadioButtonList>
       <asp:Button ID="DelVImageBtn" runat="server" Text="Delete Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" OnClick="DelVImageBtn_Click" />
   </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ManagerMainContentPlaceHolder" runat="server">
</asp:Content>
