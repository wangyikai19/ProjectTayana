<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjectTayana.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="tayana/html/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="tayana/html/Scripts/jquery.cycle.all.2.74.js"></script>
    <script type="text/javascript">


        $(function () {
            $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq(0).show();
            $('.title ul li:eq(0)').addClass('on');
            // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
            var $block = $('#abgne-block-20110111'),
                timrt, speed = 4000;


            // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
            var $li = $('.title ul li', $block).hover(function () {
                // 當滑鼠移上時加上 .over 樣式
                $(this).addClass('over').siblings('.over').removeClass('over');
            }, function () {
                // 當滑鼠移出時移除 .over 樣式
                $(this).removeClass('over');
            }).click(function () {
                // 當滑鼠點擊時, 顯示相對應的 div.info
                // 並加上 .on 樣式

                $(this).addClass('on').siblings('.on').removeClass('on');
                $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq($(this).index()).fadeIn(1000);
            });

            // 幫 $block 加上 hover() 事件
            $block.hover(function () {
                // 當滑鼠移上時停止計時器
                clearTimeout(timer);
            }, function () {
                // 當滑鼠移出時啟動計時器
                timer = setTimeout(move, speed);
            });

            // 控制輪播
            function move() {
                var _index = $('.title ul li.on', $block).index();
                _index = (_index + 1) % $li.length;
                $li.eq(_index).click();

                timer = setTimeout(move, speed);
            }

            // 啟動計時器
            timer = setTimeout(move, speed);

        });


    </script>
    <link href="tayana/html_old/css/style.css" rel="stylesheet" type="text/css" />
    <link href="tayana/html_old/css/reset.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <!--遮罩-->
    <div class="bannermasks">
        <img src="tayana/html/images/banner00_masks.png" alt="" />
    </div>
    <!--遮罩結束-->


    <!--------------------------------換圖開始---------------------------------------------------->
    <div id="abgne-block-20110111">
        <div class="bd">
            <div class="banner">

                <ul>
                    <asp:Literal ID="LitBanner" runat="server"></asp:Literal>
                </ul>

                <!--小圖開始-->
                <div class="bannerimg title" style="background-image:none">
                    <ul>
                        <asp:Literal ID="LitBannerNum" runat="server"></asp:Literal>
                    </ul>
                </div>
                <!--小圖結束-->
            </div>
        </div>
    </div>
    <!--------------------------------換圖結束---------------------------------------------------->


    <!--------------------------------最新消息---------------------------------------------------->
    <div class="news">
        <div class="newstitle">
            <p class="newstitlep1">
                <img src="tayana/html/images/news.gif" alt="news" />
            </p><p class="newstitlep2"><a href="News">More>></a></p>
        </div>
        <ul>
            <li>
                <div class="news01">            
                <!--TOP標籤-->
                    <div class="newstop">
                        <asp:Image ID="ImgIsTop1" runat="server" AlternateText="&quot;&quot;" Visible="false" ImageUrl="tayana/html/images/new_top01.png" />
                    </div>
                    <!--TOP標籤結束-->
                       <div class="news02p1">
                        <p class="news02p1img">
                            <asp:Literal ID="LiteralNewsImg1" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>
                            <asp:Literal ID="LabNewsDate1" runat="server"></asp:Literal>
                        </span>
                        <span>
                            <asp:HyperLink ID="HLinkNews1" runat="server"></asp:HyperLink>
                        </span>
                    </p>
                </div>
                <div class="news01">
                     <div class="newstop"><asp:Image ID="ImgIsTop2" runat="server" AlternateText="&quot;&quot;" Visible="false" ImageUrl="tayana/html/images/new_top01.png" /></div>
                    <div class="news02p1">
                        <p class="news02p1img">
                            <asp:Literal ID="LiteralNewsImg2" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>
                            <asp:Literal ID="LabNewsDate2" runat="server"></asp:Literal>
                        </span>
                        <span>
                            <asp:HyperLink ID="HLinkNews2" runat="server"></asp:HyperLink>
                        </span>
                    </p>
                </div>
                <div class="news01">
                    <!--TOP標籤-->
                    <div class="newstop"> <asp:Image ID="ImgIsTop3" runat="server" AlternateText="&quot;&quot;" Visible="false" ImageUrl="tayana/html/images/new_top01.png" /></div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <asp:Literal ID="LiteralNewsImg3" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>
                            <asp:Literal ID="LabNewsDate3" runat="server"></asp:Literal>
                        </span>
                        <span>
                            <asp:HyperLink ID="HLinkNews3" runat="server"></asp:HyperLink>
                        </span>
                    </p>
                </div>
            </li>
        </ul>
    </div>
    <!--------------------------------最新消息結束---------------------------------------------------->





</asp:Content>
