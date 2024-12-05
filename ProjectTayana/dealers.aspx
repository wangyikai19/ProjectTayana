<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="dealers.aspx.cs" Inherits="ProjectTayana.dealers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <script type="text/javascript">
        function _goPage(pageNumber) {
            document.getElementById("<%=txt_Page.ClientID%>").value = pageNumber;
            document.getElementById("<%=btnPage.ClientID%>").click();
        }
             </script>
    <!--遮罩-->
<div class="bannermasks"><img src="tayana/html%20_old/images/DEALERS.jpg" alt="&quot;&quot;" width="967" height="371" /></div>
<!--遮罩結束-->
<!--------------------------------換圖開始----------------------------------------------------> 

<div class="banner">
<ul>
<li><img src="tayana/images/newbanner.jpg" alt="Tayana Yachts" /></li>
</ul>

</div> 
<!--------------------------------換圖結束----------------------------------------------------> 




<div class="conbg"> 
<!--------------------------------左邊選單開始----------------------------------------------------> 
<div class="left"> 
<div class="left1">
<p><span>DEALERS</span></p>
<ul>
    <asp:Literal ID="LeftMenu" runat="server"></asp:Literal>
</ul>
</div>
</div>
<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="index.aspx">Home</a> >> <a href="#">Dealers </a> >> <a href="#"><span class="on1" id="LabLink" runat="server">USA</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span id="LitTitle" runat="server">USA</span></div>
<!--------------------------------內容開始----------------------------------------------------> 
<div class="box2_list"> 
<ul>
    <asp:Literal ID="DealerList" runat="server"></asp:Literal>
</ul>

   <div class="pagenumber"><asp:Literal ID="ltl_PageNumber" runat="server"></asp:Literal></div>
   <asp:HiddenField ID="txt_Page" runat="server"/>
<asp:Button ID="btnPage" runat="server" Text="查詢" OnClick="btnPage_Click" Style="display: none;" />



</div>
 
<!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>
</asp:Content>
