<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="yachtMgt.aspx.cs" Inherits="ProjectTayana.yachtMgt"validateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.9.359/pdf.min.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="input-group my-3">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="yachtModel" DataValueField="id" Width="50%" Font-Bold="True" class="btn btn-outline-primary dropdown-toggle" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" SelectCommand="SELECT [yachtModel], [id] FROM [Yacht]"></asp:SqlDataSource>
    <asp:FileUpload ID="imageUpload" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
    <asp:Button ID="UploadBtn" runat="server" Text="Upload" class="btn btn-primary" OnClick="UploadBtn_Click" />
</div>
<hr />
<h6>Banner Image List :</h6>
<h6><span class="badge badge-pill badge-success text-dark">* The first image will be the home page banner !</span></h6>
<h6>Step1. To upload one image to be the home page banner.</h6>
<h6>Step2. Then upload other images.</h6>
<asp:RadioButtonList ID="RadioButtonList" runat="server" class="my-3 mx-auto" AutoPostBack="True" CellPadding="10" RepeatColumns="5" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonListH_SelectedIndexChanged" ></asp:RadioButtonList>
<asp:Button ID="DelImageBtn" runat="server" Text="Delete Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" OnClick="DelHImageBtn_Click" />

<asp:CheckBox ID="CBoxNewDesign" runat="server" Text="NewDesign" Width="50%" />
<asp:CheckBox ID="CBoxNewBuilding" runat="server" Text="NewBuilding" Width="50%" />
<div class="input-group mb-3">
    <asp:TextBox ID="TBoxAddYachtModel" runat="server" type="text" class="form-control" placeholder="Model" Width="30%" ></asp:TextBox>
    <asp:TextBox ID="TBoxAddYachtLength" runat="server" type="text" class="form-control" placeholder="Length" ></asp:TextBox>
    <div class="input-group-append">
        <asp:Button ID="BtnAddYacht" runat="server" Text="Add" class="btn btn-outline-primary btn-block" OnClick="BtnAddYacht_Click" />
    </div>
</div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDeleted="DeletedModel" OnRowUpdated="UpdatedModel" OnRowDeleting="DeletingModel" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
  <Columns>
      <asp:CommandField ButtonType="Button" CancelText="Cancel" DeleteText="Delete" EditText="Edit" HeaderText="Edit" InsertText="Insert" NewText="New" SelectText="Select" ShowEditButton="True"  ControlStyle-CssClass='btn btn-primary btn-block' ControlStyle-BorderColor="#66CCFF" ControlStyle-BorderStyle="Solid" ControlStyle-BorderWidth="1px" ControlStyle-ForeColor="White" >
      <ControlStyle BorderColor="#66CCFF" BorderWidth="1px" BorderStyle="Solid" CssClass="btn btn-primary btn-block" ForeColor="White"></ControlStyle>
      </asp:CommandField>
      <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
      <asp:BoundField DataField="yachtModel" HeaderText="Yacht Model" SortExpression="yachtModel" />
      <asp:CheckBoxField DataField="isNewDesign" HeaderText="New Design" SortExpression="isNewDesign" />
      <asp:CheckBoxField DataField="isNewBuilding" HeaderText="New Building" SortExpression="isNewBuilding" />
<%--      <asp:BoundField DataField="initDate" HeaderText="Creation Date" SortExpression="initDate" InsertVisible="False" ReadOnly="True" />--%>
      <asp:TemplateField HeaderText="Delete" ShowHeader="False">
          <ItemTemplate>
              <asp:LinkButton ID="BtnDeleteCountry" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete？')" CausesValidation="False"></asp:LinkButton>
          </ItemTemplate>
          <ControlStyle BorderColor="#66CCFF" BorderStyle="Solid" BorderWidth="1px" CssClass="btn btn-danger btn-block" ForeColor="White" />
      </asp:TemplateField>
  </Columns>
  <FooterStyle BackColor="White" ForeColor="#000066" />
  <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
  <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
  <RowStyle ForeColor="#000066" />
  <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
  <SortedAscendingCellStyle BackColor="#F1F1F1" />
  <SortedAscendingHeaderStyle BackColor="#007DBB" />
  <SortedDescendingCellStyle BackColor="#CAC9C9" />
  <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" SelectCommand="SELECT [id], [yachtModel], [isNewDesign], [isNewBuilding], [initDate] FROM [Yacht]" DeleteCommand="DELETE FROM [Specification] WHERE [yachtModel_ID] = @id; DELETE FROM [Yacht] WHERE [id] = @id" UpdateCommand="UPDATE [Yacht] SET [yachtModel] = @yachtModel, [isNewDesign] = @isNewDesign, [isNewBuilding] = @isNewBuilding WHERE [id] = @id">
  <DeleteParameters>
      <asp:Parameter Name="id" Type="Int32" />
  </DeleteParameters>
  <UpdateParameters>
      <asp:Parameter Name="isNewBuilding" Type="Boolean" />
      <asp:Parameter Name="isNewDesign" Type="Boolean" />
      <asp:Parameter Name="yachtModel" Type="String" />
      <asp:Parameter Name="id" Type="Int32" />
  </UpdateParameters>
</asp:SqlDataSource>
</asp:Content>

