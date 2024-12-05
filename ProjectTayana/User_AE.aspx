<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="User_AE.aspx.cs" Inherits="ProjectTayana.User_AE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xl-8 col-md-6">
 <table class="table table-striped">
     <tr id="tbl_User" runat="server">
         <th>ID</th>
         <th>帳號</th>
         <th>刪除</th>
     </tr>
     <asp:Repeater ID="Repeater1" runat="server">
         <ItemTemplate>
             <tr>
                 <td><%# Eval("id") %></td>
                 <td><%# Eval("account") %></td>
                 <td>
                     <asp:Button
                         ID="btnEdit"
                         runat="server"
                         Text="刪除"
                         OnClick="btnDelete_Click"
                         class="btn btn-primary"
                         CommandArgument='<%# Eval("id") %>' 
                          OnClientClick="return confirm('確定要刪除這筆資料嗎？');" />
                 </td>
             </tr>
         </ItemTemplate>
     </asp:Repeater>
 </table>
        <p><span>新增管理者</span></p>
        <div class="input-group mb-3" style="display:block">
            <div class="input-group mb-3" style="width:200px">
                <asp:TextBox ID="Account" runat="server" type="text" class="form-control" placeholder="帳號" ></asp:TextBox>

            </div>
            <div class="input-group mb-3" style="width:200px" >
                <asp:TextBox ID="Password" runat="server" type="text" class="form-control" placeholder="密碼"></asp:TextBox>
            </div>
        </div>
        <div class="input-group-append">
            <asp:Button ID="AddUser" runat="server" Text="Add" class="btn btn-outline-primary btn-block" OnClick="AddUser_Click" />
            <asp:Label ID="LabelAdd" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
