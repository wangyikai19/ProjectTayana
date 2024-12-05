<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="ProjectTayana.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script type="text/javascript">
<%--        function _goPage(pageNumber) {
            document.getElementById("<%=txt_Page.ClientID%>").value = pageNumber;
            document.getElementById("<%=btnPage.ClientID%>").click();
        }--%>
         </script>
    <style>
       .dashed-border tr {
        border-top: 1px dashed black;
        border-bottom: 1px dashed black;
    }

    table {
        border-collapse: collapse;
    }
</style>
    <!--遮罩-->
<div class="bannermasks"><img src="tayana/images/banner02_masks.png" alt="&quot;&quot;" /></div>
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
<p><span>NEWS</span></p>
<ul>
<li><a href="#">News & Events</a></li>

</ul>



</div>




</div>







<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="#">Home</a> >> <a href="#">News </a> >> <a href="#"><span class="on1">News & Events</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span>News & Events</span></div>
  
<!--------------------------------內容開始----------------------------------------------------> 
<div class="box2_list"> 
<ul>
 <asp:Literal ID="LitNews" runat="server"></asp:Literal>
<%--<li>
  <div class="list01">
  <ul>
  <li><div><p><img src="images/pit006.jpg" alt="&quot;&quot;" /></p></div></li>
  <li>  <span>2012-01-28</span><br />
Tayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are available</li>  
  <li>availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are available</li>
  </ul>
  </div>
</li>

<li>
  <div class="list01">
  <ul>
  <li><div><p><img src="images/pit007.jpg" alt="&quot;&quot;" /></p>
  </div></li>
  <li>  <span>2012-01-28</span><br />
Tayana 58 CE Certificates are available</li>  
  </ul></div>
</li>

<li>
  <div class="list01">
  <ul>
  <li><div><p><img src="images/pit008.jpg" alt="&quot;&quot;"/></p></div></li>
  <li>  <span>2012-01-28</span><br />
Tayana 58 CE Certificates are available</li>  
  </ul></div>
</li>

<li>
  <div class="list01">
  <ul>
  <li><div><p><img src="images/pit006.jpg" alt="&quot;&quot;" width="300" /></p></div></li>
  <li>  <span>2012-01-28</span><br />
Tayana 58 CE Certificates are available</li>  
  </ul></div>
</li>

<li>
  <div class="list01">
  <ul>
  <li><div><p><img src="images/pit006.jpg" alt="&quot;&quot;" width="300" /></p></div></li>
  <li>  <span>2012-01-28</span><br />
Tayana 58 CE Certificates are available</li>  
  </ul></div>
</li>--%>
</ul>

<div class="pagenumber"> | <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
  <div class="pagenumber1"> Items：<span>89</span>  |  Pages：<span>1/9</span></div>


</div>

 
<!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>
</asp:Content>
