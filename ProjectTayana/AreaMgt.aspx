<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="AreaMgt.aspx.cs" Inherits="ProjectTayana.AreaMgt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManagerMenuContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="col-xl-12">
        <div class="card">
            <div class="card-body">
                <h6 class="mb-4">Country List</h6>
                <div class="row d-flex align-items-center">
                    <div class="col-12">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:CommandField ButtonType="Button" CancelText="Cancel" DeleteText="Delete" EditText="修改" HeaderText="Edit" InsertText="Insert"  ControlStyle-CssClass="btn btn-primary" NewText="New" SelectText="Select" ShowEditButton="True">
                                </asp:CommandField>
                                <asp:BoundField DataField="countrySort" HeaderText="countrySort" SortExpression="countrySort" />
                                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnDeleteCountry" runat="server" CommandName="Delete" Text="刪除" OnClientClick="return confirm('Are you sure you want to delete？')" CausesValidation="False"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" SelectCommand="SELECT * FROM [CountrySort]" DeleteCommand="DELETE FROM [Dealers] WHERE [country_ID] = @id; DELETE FROM [CountrySort] WHERE [id] = @id" UpdateCommand="UPDATE [CountrySort] SET [countrySort] = @countrySort WHERE [id] = @id"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="card-body">
                <h6 class="mb-4">Add Country</h6>
                <div class="row d-flex align-items-center">
                    <div class="col-9">
                        <asp:TextBox ID="TBoxAddCountry" runat="server" PlaceHolder="Enter country name"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xl-12">
        <div class="card">
            <div class="card-body">
                <h6 class="mb-4">Area List</h6>
                <div class="row d-flex align-items-center">
                    <div class="col-12">
                        <asp:DropDownList ID="ddl_Country" runat="server" DataTextField="CountrySort" DataValueField="id" AutoPostBack="True" CssClass="btn btn-outline-primary dropdown-toggle" OnSelectedIndexChanged="ddl_Country_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-12">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="btn_Delete_Click"/>
                    </div>

                </div>
            </div>
            <div class="card-body">
                <h6 class="mb-4">Add Area</h6>
                <div class="row d-flex align-items-center">
                    <div class="col-9">
                        <asp:TextBox ID="txt_Area" runat="server" PlaceHolder="Enter area name" ></asp:TextBox>
                        <asp:Button ID="Btn_AddArea" runat="server" Text="Add"  CssClass="btn btn-primary"  OnClick="Btn_AddArea_Click1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ManagerMainContentPlaceHolder" runat="server">
</asp:Content>
