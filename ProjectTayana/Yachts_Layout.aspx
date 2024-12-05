<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Yachts_Layout.aspx.cs" Inherits="ProjectTayana.Yachts_Layout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" type="text/css" href="tayana/html/css/jquery.ad-gallery.css">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="tayana/html/Scripts/jquery.ad-gallery.js"></script>
    <script type="text/javascript">
        $(function () {
            var galleries = $('.ad-gallery').adGallery();
            galleries[0].settings.effect = 'slide-hori';
        });
    </script>
    <link href="tayana/html_old/css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="tayana/html_old/css/reset.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bannermasks"><img src="tayana/html/images/banner01_masks.png" alt="&quot;&quot;" /></div>
    <div class="banner">
<div id="gallery" class="ad-gallery">
      <div class="ad-image-wrapper">
      </div>
      <div class="ad-controls" style="display:none">
      </div>
      <div class="ad-nav">
        <div class="ad-thumbs">
          <ul class="ad-thumb-list">
            <asp:Literal ID="LitBannerNum" runat="server"></asp:Literal>                 
          </ul>
        </div>
      </div>
    </div>
    </div>
    <div class="conbg"> 
<!--------------------------------左邊選單開始----------------------------------------------------> 
<div class="left"> 

<div class="left1">
<p><span>YACHTS</span></p>
<ul>
    <asp:Literal ID="LeftMenuHtml" runat="server"></asp:Literal>
</ul>



</div>




</div>







<!--------------------------------左邊選單結束----------------------------------------------------> 
<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb1"><a href="index.aspx">Home</a> >> <a href="#">Yachts</a> >> <a href="Yatchs_OverView.aspx"><span class="on1" id="LabLink" runat="server">Tayana 37</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span  id="LabTitle" runat="server">Tayana 37</span></div>
  
<!--------------------------------內容開始----------------------------------------------------> 

<!--次選單-->
<div class="menu_y">
<ul>
<li class="menu_y00">YACHTS</li>
    <asp:Literal ID="TopMenuLinkHtml" runat="server"></asp:Literal>
</ul>
</div> 
<!--次選單-->
    <div class="box6">
        <p> Layout & deck plan </p>
        <ul>
            <asp:Literal ID="ContentHtml" runat="server"></asp:Literal>
        </ul>
    </div>
    <div class="clear"></div>
    <p class="topbuttom">
        <img src="tayana/html/images/top.gif" /></p>
      <!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>
</asp:Content>
