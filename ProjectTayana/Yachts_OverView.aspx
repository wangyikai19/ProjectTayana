<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Yachts_OverView.aspx.cs" Inherits="ProjectTayana.Yachts_OverView" %>
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
    <!--遮罩-->
<div class="bannermasks"><img src="tayana/html/images/banner01_masks.png" alt="&quot;&quot;" /></div>
<!--遮罩結束-->

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
<div id="crumb1"><a href="index.aspx">Home</a> >> <a href="#">Yachts</a> >> <span class="on1" id="LabLink" runat="server">Tayana 37</span></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span  id="LabTitle" runat="server">Tayana 37</span></div> 
    <!--次選單-->
<div class="menu_y">
<ul>
<li class="menu_y00">YACHTS</li>
    <asp:Literal ID="TopMenuLinkHtml" runat="server"></asp:Literal>
</ul>
</div> 
<!--次選單-->
    <div class="box1">
        <asp:Literal ID="ContentHtml" runat="server"></asp:Literal>
        &nbsp;
    </div>
    <div class="box3" id="dimensionTable" runat="server">
        <h4 id="dimensionTitle" runat="server"></h4>
        <div style="display:flex">
        <table class="table02" style="width:50%">
            <tbody>
                <tr>
                    <td class="table02td01">
                        <table>
                               <thead></thead>
                            <tbody>
                                <asp:Literal ID="LitDimensionsHtml" runat="server"></asp:Literal>

                                <tr>
                                    <th>
                                        <p class="">Hull length</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <p class="">L.W.L.</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <p class="">B. MAX</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <p class="">Standard draft</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <p class="">Ballast</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <p class="">Displacement</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label6" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <p class="">Sail area</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <p class="">Cutter</p>
                                    </th>
                                    <td>
                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                    </td>
                                </tr>


<%--                                <tr>
                                    <th>
                                        <p class="d-inline-block m-r-20">Dimensions Image</p>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TBoxDimImg" runat="server" type="text" class="form-control"></asp:TextBox>
                                    </td>
                                </tr>--%>
                            </tbody>
                        </table>
                    </td>
                    
                </tr>
            </tbody>
        </table>
<%--            <asp:Image ID="Image1" runat="server" />--%>
            <asp:Literal ID="DimensionsImgHtml" runat="server"></asp:Literal>
<%--            <img src="https://web.archive.org/web/20160915011659im_/http://www.tayanaworld.com/upload/images/37.gif" />--%>
        </div>
    </div>

    <!--下載開始-->
    <div id="divDownload" class="downloads" runat="server">
        <p><img src="tayana/html/images/downloads.gif" alt="&quot;&quot;" /></p>
        <ul>
            <li>
                <asp:Literal ID="DownloadsHtml" runat="server"></asp:Literal>
            </li>
        </ul>
    </div>
    <!--下載結束-->
        <p class="topbuttom"><img src="tayana/html/images/top.gif" alt="top" /></p>
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>
</asp:Content>
