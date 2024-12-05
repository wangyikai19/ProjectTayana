<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="Dealers_AE.aspx.cs" Inherits="ProjectTayana.Dealers_AE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6 col-xl-12">
        <input name="btnInsert" type="button" value="新增" class="btn btn-primary" onclick="location.href = 'DealerMgt.aspx?Work=N'" />
        <table class="table table-striped">
            <tr id="tbl_CoursePlanningClass" runat="server">
                <th>ID</th>
                <th>國家</th>
                <th>地區</th>
                <th>名稱</th>
                <th>聯絡人</th>
                <th>地址</th>
                <th>電話</th>
                <th>Email</th>
                <th>編輯</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("id") %></td>
                        <td><%# Eval("countrySort") %></td>
                        <td><%# Eval("areaName") %></td>
                        <td><%# Eval("name") %></td>
                        <td><%# Eval("contact") %></td>
                        <td><%# Eval("address") %></td>
                        <td><%# Eval("tel") %></td>
                        <td><%# Eval("email") %></td>
                        <td>
                            <asp:Button
                                ID="btnEdit"
                                runat="server"
                                Text="修改"
                                OnClick="btnEdit_Click"
                                class="btn btn-primary"
                                CommandArgument='<%# Eval("id") %>' />
                            <asp:Button
                                ID="btnDelete"
                                runat="server"
                                Text="刪除"
                                OnClick="btnDelete_Click"
                                class="btn btn-primary"
                                CommandArgument='<%# Eval("id") %>' 
                                OnClientClick="return confirm('確定要刪除這筆資料嗎？');"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

    </div>


</asp:Content>
