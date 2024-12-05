<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="contactUs.aspx.cs" Inherits="ProjectTayana.contactUs" %>

<%@ Register Assembly="Recaptcha.Web" Namespace="Recaptcha.Web.UI.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--遮罩-->
<div class="bannermasks"><img src="tayana/html%20_old/images/contact.jpg"  alt="&quot;&quot;" width="967" height="371" /></div>
<!--遮罩結束-->

<!--------------------------------換圖開始----------------------------------------------------> 

<div class="banner">
<ul>
<li><img src="tayana/html%20_old/images/newbanner.jpg" alt="Tayana Yachts" /></li>
</ul>

</div> 
<!--------------------------------換圖結束----------------------------------------------------> 




<div class="conbg"> 
<!--------------------------------左邊選單開始----------------------------------------------------> 
<div class="left"> 

<div class="left1">
<p><span>CONTACT</span></p>
<ul>
<li><a href="#">contacts</a></li>
</ul>



</div>




</div>







<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="#">Home</a> >> <a href="#"><span class="on1">Contact</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span>Contact</span></div>
  
<!--------------------------------內容開始----------------------------------------------------> 
<!--表單-->
<div class="from01"><p> Please Enter your contact information<span class="span01">*Required</span>
</p><br />
  <table>
    <tr>
      <td class="from01td01">Name :</td>
      <td><span>*</span><asp:TextBox runat="server" name="Name" type="text" ID="Name" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr>
      <td class="from01td01">Email :</td>
      <td><span>*</span><asp:TextBox runat="server" name="Email" type="text" ID="Email" class="{validate:{required:true, email:true, messages:{required:'Required', email:'Please check the E-mail format is correct'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr>
      <td class="from01td01">Phone :</td>
      <td><span>*</span><asp:TextBox runat="server" name="Phone" type="text" ID="Phone" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr>
      <td class="from01td01">Country :</td>
      <td><span>*</span><asp:DropDownList name="Country" id="Country" runat="server" DataTextField="countrySort" DataValueField="countrySort" DataSourceID="SqlDataSource1"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" SelectCommand="SELECT [countrySort] FROM [CountrySort]"></asp:SqlDataSource></td>
    </tr>
    <tr>
      <td colspan="2" ><span>*</span>Brochure of interest  *Which Brochure would you like to view?</td>
      </tr>
    <tr>
      <td class="from01td01">&nbsp;</td>
      <td><asp:DropDownList name="Yachts" id="Yachts" runat="server" DataTextField="type" DataValueField="type"></asp:DropDownList></td>
    </tr>
    <tr>
      <td class="from01td01">Comments:</td>
      <td><asp:TextBox runat="server" TextMode="MultiLine" name="Comments" Rows="2" cols="20" ID="Comments" Style="height: 150px; width: 330px;" MaxLength="500"></asp:TextBox></td>
    </tr>
          <tr>
      <td class="from01td01"></td>
      <td>
          <cc1:RecaptchaApiScript ID="RecaptchaApiScript1" runat="server" />
          <cc1:RecaptchaWidget ID="Recaptcha1" runat="server" RecaptchaApiScript="False"/>
          <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red"></asp:Label>
      </td>
    </tr>
    <tr>
      <td class="from01td01">&nbsp;</td>
     <td class="f_right">
                <asp:ImageButton runat="server" type="image" name="ImageButton1" id="ImageButton1" src="tayana/images/buttom03.gif" style="border-width: 0px;" Height="25px" OnClick="ImageButton1_Click"/>
            </td>
    </tr>
  </table>  
</div>
<!--表單-->

<div class="box1">
<span class="span02">Contact with us</span><br />
Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
</div>

<div class="list03">
<p><span>TAYANA HEAD OFFICE</span><br />
NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
  tel. +886(7)641 2422<br />
  fax. +886(7)642 3193<br />
  info@tayanaworld.com<br /></p>
</div>


<div class="list03">
<p><span>SALES DEPT.</span><br />
+886(7)641 2422  ATTEN. Mr.Basil Lin<br /><br /></p>
</div>

<div class="box4">
<h4>Location</h4>
<p>
  <iframe width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d117949.74216689494!2d120.24621908612743!3d22.506830282923886!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3471e27e95b90d0f%3A0x74605e8fd6269514!2zODMy6auY6ZuE5biC5p6X5ZyS5Y2A!5e0!3m2!1szh-TW!2stw!4v1730704661564!5m2!1szh-TW!2stw;source=s_d&amp;saddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E5%B0%8F%E6%B8%AF%E5%8D%80%E4%B8%AD%E5%B1%B1%E5%9B%9B%E8%B7%AF%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F%E5%A0%B4&amp;daddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;hl=zh-en&amp;geocode=FRthWAEdwlwsByGxkQ4S1t-ckinNS9aM0xxuNDELEXJZh6Soqg%3BFRRmVwEdMKssBym5azbzl-JxNDGd62mwtzGaDw&amp;aq=0&amp;oq=%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F&amp;sll=22.50498,120.36792&amp;sspn=0.008356,0.016512&amp;g=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;mra=ls&amp;ie=UTF8&amp;t=m&amp;ll=22.537135,120.360718&amp;spn=0.08213,0.119133&amp;z=13&amp;output=embed"></iframe>
</p>

  </div>




<!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>
</asp:Content>
