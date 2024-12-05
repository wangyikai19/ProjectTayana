<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="News_AE.aspx.cs" Inherits="ProjectTayana.News_AE" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField ID="Work" runat="server" />
     <asp:HiddenField ID="txt_ID" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <input name="btnInsert" type="button" value="新增" class="btn btn-primary" onclick="location.href = 'NewsAdd.aspx?Work=N'" />
        <div class="col-md-6 col-xl-12">
        <table class="table table-striped">
            <tr id="tbl_CoursePlanningClass" runat="server">
                <th>ID</th>
                <th>標題</th>
                <th>日期</th>
                <th>編輯</th>
                <th>刪除</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("id") %></td>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("CreateDT") %></td>
                        <td>
                            <asp:Button
                                ID="btnEdit"
                                runat="server"
                                Text="修改"
                                OnClick="btnEdit_Click"
                                class="btn btn-primary"
                                CommandArgument='<%# Eval("id") %>' />
                        </td>
                                                <td>
                            <asp:Button
                                ID="btnDelete"
                                runat="server"
                                Text="刪除"
                                OnClick="btnDelete_Click"
                                class="btn btn-primary"
                                CommandArgument='<%# Eval("id") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
