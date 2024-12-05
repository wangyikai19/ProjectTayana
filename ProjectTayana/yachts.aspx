<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="yachts.aspx.cs" Inherits="ProjectTayana.yachts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Scripts/jquery.ad-gallery.js"> </script>
<%--    <script  type="text/javascript">
        $(function () {
            var galleries = $('.ad-gallery').adGallery();
            gallerier[0].settings.effect = 'fade';
            if ($('banner1 input[type=hidden]').val()=="0") {
                $(".bannermasks").hide();
                $(".banner1").hide();
                $("#crumb1").css("top", "125px");
            }
        })
    </script>--%>
</asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--遮罩-->
<%--<div class="bannermasks"><img src="tayana/images/banner01_masks.png" alt="&quot;&quot;" /></div>--%>
<!--遮罩結束-->

<div class="banner1">
    <input type="hidden" name="HiddenField1" id="Gallery1_HiddenField1" value="1"/>
    <div id="gallery" class="ad-gallery">
        <div class="ad-image-wrapper">

        </div>
        <div class="ad-controls">

        </div>
        <div class="ad-nav">
            <div class="ad-thumbs">
                <ul class="ad-thumb-list">
                    <asp:Repeater ID="RepeaterImg" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# Eval("ImageUrl")%>'>
                                    <img src='<%# Eval("ImageUrl")%>' class="image0" alt="" height="59px"/>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
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

 

  
  <!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>
  </asp:Content>

