<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="DealerUpdate.aspx.cs" Inherits="ProjectTayana.DearlerUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="col-md-6 col-xl-12" >
    <table class="table table-hover">
                <tr>
            <th><i class="fa fa-star"></i>Image</th>
            <td>
                <asp:Image ID="Image1" runat="server" />
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Country</th>
            <td>
                <asp:Label ID="lb_Country" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Area</th>
            <td>
                <asp:Label ID="lb_Area" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Image</th>
            <td>
                <asp:FileUpload ID="imageUpload" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
                <asp:Button ID="UploadImgBtn" runat="server" Text="Upload" class="btn btn-primary" OnClick="UploadImgBtn_Click" />
                <asp:Label ID="LabUploadImg" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Name</th>
            <td>
                <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Contact</th>
            <td>
                <asp:TextBox ID="txt_Contact" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Address</th>
            <td>
                <asp:TextBox ID="txt_Address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Tel</th>
            <td>
                <asp:TextBox ID="txt_Tel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Fax</th>
            <td>
                <asp:TextBox ID="txt_Fax" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>Email</th>
            <td>
                <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th><i class="fa fa-star"></i>AddDealer</th>
            <td>
                <asp:Button ID="btn_AddDealer" runat="server" Text="修改" OnClick="btn_AddDealer_Click" />
            </td>

        </tr>
    </table>
</div>
</asp:Content>

