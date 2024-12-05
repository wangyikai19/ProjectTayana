<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="company1.aspx.cs" Inherits="ProjectTayana.company1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .box3 {
        text-align: left;
    }

    .box3 .pit ul {
        list-style-type: none;
        padding: 0;
    }

    .box3 .pit ul li {
        display: inline-block;
        margin-right: 10px;
        vertical-align: top;
    }
</style>
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
<li><a href="Company.aspx">About Us</a></li>
<li><a href="Company1.aspx">Certificat</a></li>

</ul>
</div>

</div>
<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="#">Home</a> >> <a href="#">Company  </a> >> <a href="#"><span class="on1">Certificate</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span>Certificate</span></div>
  
<!--------------------------------內容開始----------------------------------------------------> 

    <div class="box3">
        <asp:Literal ID="ContentText" runat="server"></asp:Literal>
        <br />
        <br />
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
