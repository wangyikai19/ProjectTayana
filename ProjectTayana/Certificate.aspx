<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Certificate.aspx.cs" Inherits="ProjectTayana.Certificate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
<p><span>COMPANY </span></p>
<ul>
<li><a href="#">About Us</a></li>
<li><a href="#">Certificat</a></li>

</ul>
</div>

</div>
<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="#">Home</a> >> <a href="#">Company  </a> >> <a href="#"><span class="on1">About Us</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span>About Us</span></div>
  
<!--------------------------------內容開始----------------------------------------------------> 
    <div class="box3">
        <asp:Literal ID="ContentText" runat="server"></asp:Literal>
        <br/>
        <br/>
        <div class="pit">
            <ul>
               <asp:Literal ID="ContentImgV" runat="server"></asp:Literal>
                <asp:Literal ID="ContentImgH" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
<!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>

</asp:Content>
