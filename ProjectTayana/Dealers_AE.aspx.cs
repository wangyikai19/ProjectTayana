using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjectTayana
{
    public partial class Dealers_AE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDealer(1);
                //showDealerList();
            }

        }
        protected void bindDealer(int page)
        {
            if (page < 1) page = 1;
            int pageRecord = 10;

            String sql = @"SELECT [Dealers].id,CountrySort.countrySort,area.Name as 'areaName',dealerImgPath,[Dealers].[name],contact,[address],tel,fax,email,link,[Dealers].initDate FROM [Tayana].[dbo].[Dealers] 
left join  Area on Dealers.country_ID=Area.countryID and Dealers.area=Area.ID 
left join CountrySort on [Dealers].country_ID=countrySort.id";
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData(sql, aDict);
            Repeater1.DataSource = objDT.DefaultView;
            Repeater1.DataBind();
        }
        protected void gv_Dealers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dealerId = btn.CommandArgument; // 取得傳遞過來的 id

            // 這裡可以進行查詢或其他處理，然後將 id 透過 QueryString 傳遞到 DealerMgt.aspx
            Response.Redirect($"DealerUpdate.aspx?id={dealerId}");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dealerId = btn.CommandArgument;
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            string sql = "Delete from Dealers where id=@ID";
            aDict.Add("@ID", dealerId);
            DataTable objDT = objDH.queryData(sql, aDict);
            string successrMessage = "刪除完成";
            Utility.showMessage(Page, "ErrorMessage", successrMessage);
            bindDealer(1);
            return;
        }

        protected void btn_AddDealer_Click(object sender, EventArgs e)
        {
            //Dictionary<string, object> aDict = new Dictionary<string, object>();
            //DataHelper objDH = new DataHelper();
            //// init 錯誤訊息
            //String errorMessage = "";
            //if (string.IsNullOrEmpty(ddlCountry.SelectedValue)) errorMessage += "請選擇國家！\\n";
            //if (string.IsNullOrEmpty(ddlArea.SelectedValue)) errorMessage += "請選擇地區！\\n";
            //if (string.IsNullOrEmpty(txt_Name.Text)) errorMessage += "請輸入Name！\\n";
            //if (string.IsNullOrEmpty(txt_Contact.Text)) errorMessage += "請輸入Contact！\\n";
            //if (string.IsNullOrEmpty(txt_Address.Text)) errorMessage += "請輸入Address！\\n";
            //if (string.IsNullOrEmpty(txt_Tel.Text)) errorMessage += "請輸入Tel！\\n";
            //if (string.IsNullOrEmpty(txt_Fax.Text)) errorMessage += "請輸入Fax！\\n";
            //if (string.IsNullOrEmpty(txt_Email.Text)) errorMessage += "請輸入Email！\\n";
            //if (!String.IsNullOrEmpty(errorMessage))
            //{
            //    Utility.showMessage(Page, "ErrorMessage", errorMessage);
            //    return;
            //}
            //string selCountry_id = ddlCountry.SelectedValue;
            //string Area = ddlArea.SelectedValue;
            //string name = txt_Name.Text;
            //string Contact = txt_Contact.Text;
            //string Address = txt_Address.Text;
            //string Tel = txt_Tel.Text;
            //string Fax = txt_Fax.Text;
            //string Email = txt_Email.Text;
            //string sql = "SELECT 1 from Dealers where country_ID=@countryID and area=@Area and name=@name";
            //aDict.Add("@countryID", selCountry_id);
            //aDict.Add("@area", Area);
            //aDict.Add("@dealerImgPath", "");
            //aDict.Add("@name", name);
            //aDict.Add("@Contact", Contact);
            //aDict.Add("@Address", Address);
            //aDict.Add("@Tel", Tel);
            //aDict.Add("@Fax", Fax);
            //aDict.Add("@Email", Email);
            //DataTable objDT = objDH.queryData(sql, aDict);
            //if (objDT.Rows.Count > 0)
            //{
            //    errorMessage = "此地區已有此經銷商";
            //    Utility.showMessage(Page, "ErrorMessage", errorMessage);
            //    return;
            //}
            //else
            //{
            //    string AddSQL = @"  insert into[Dealers]([country_ID],[area],[dealerImgPath],[name],[contact],[address],[tel],[fax],[email])
            //        values(@countryID,@area,@dealerImgPath,@name,@Contact,@Address,@Tel,@Fax,@Email)";
            //    objDT = objDH.queryData(AddSQL, aDict);
            //}
            //bindDealer(1);
            //string successrMessage = "新增完成";
            //Utility.showMessage(Page, "ErrorMessage", successrMessage);
            //return;
        }
    }
}