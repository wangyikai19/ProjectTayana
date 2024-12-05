<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="NewsContent.aspx.cs" Inherits="ProjectTayana.NewsContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
      <div class="row">
      <div class="col-12">
          <div class="tab-content" id="myTableData">
              <asp:Label ID="lb_Title" runat="server" Text="" style="font-size: 30px; font-weight: bold;">></asp:Label>           

              <table class="table table-striped">
                  <tr>
                      <th class="w7 txtL">
                          <asp:Label ID="lb_Name" class="control-label" runat="server"></asp:Label></th>
                      <th class="w3 txtL">

                  </tr>
                  <tr>
                      <td colspan="2" class="padding20">
                          <asp:Label ID="lb_Info" class="control-label" runat="server"></asp:Label>
                          <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                      </td>
                  </tr>
              </table>
          </div>
      </div>
  </div>
        <div class="center pages both w10">
        <asp:Button runat="server" class="btn btn-success" ID="btn_Back" Text="回上頁" OnClick="btn_Back_Click" />
        
    </div>
    </div>
    </div>
    </div>
</asp:Content>
