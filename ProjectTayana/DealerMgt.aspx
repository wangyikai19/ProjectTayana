<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="DealerMgt.aspx.cs" Inherits="ProjectTayana.DealerMgt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="col-md-6 col-xl-12" >
        <table class="table table-hover">
            <tr>
                <th><i class="fa fa-star"></i>Country</th>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="CountrySort" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddl_AddDealerCountry_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th><i class="fa fa-star"></i>Area</th>
                <td>
                    <asp:DropDownList ID="ddlArea" runat="server" DataTextField="areaName" DataValueField="id" ></asp:DropDownList>
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
                    <asp:Button ID="btn_AddDealer" runat="server" Text="" OnClick="btn_AddDealer_Click" />
                </td>

            </tr>
        </table>
    </div>
</asp:Content>
