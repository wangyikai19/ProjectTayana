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

namespace ProjectTayana
{
    public partial class DealerMgt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String work = "";
                if (Request.QueryString["Work"] != null) work = Request.QueryString["Work"];
                setDDL(ddlCountry, "");
                SetEventClass(ddlCountry, "請選擇");
                if (work.Equals("N"))
                {
                    btn_AddDealer.Text = "新增";
                }
                else
                {
                    bindData(1);
                    btn_AddDealer.Text = "修改";
                }
            }
        }
        public static void SetEventClass(DropDownList ddl, string DefaultString = null)
        {
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData("Select * from CountrySort ", aDict);
            ddl.DataSource = objDT;
            ddl.DataBind();
            if (DefaultString != null)
            {
                ddl.Items.Insert(0, new ListItem(DefaultString, ""));
            }
        }
        protected void bindData(int id)
        {
            String sql = @"SELECT [Dealers].id,CountrySort.countrySort,area.Name as 'areaName',dealerImgPath,[Dealers].[name],contact,[address],tel,fax,email,link,[Dealers].initDate FROM [Tayana].[dbo].[Dealers] 
left join  Area on Dealers.country_ID=Area.countryID and Dealers.area=Area.ID 
left join CountrySort on [Dealers].country_ID=countrySort.id where Dealers.id=@ID ";
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            aDict.Add("@ID", id);
            DataTable objDT = objDH.queryData(sql, aDict);
            if (objDT.Rows.Count > 0)
            {
                ddlCountry.SelectedValue = Convert.ToString(objDT.Rows[0]["countrySort"]);
                ddlArea.SelectedValue = Convert.ToString(objDT.Rows[0]["areaName"]);
                txt_Name.Text= objDT.Rows[0]["name"].ToString();
                txt_Contact.Text = objDT.Rows[0]["contact"].ToString();
                txt_Address.Text = objDT.Rows[0]["address"].ToString();
                txt_Tel.Text= objDT.Rows[0]["tel"].ToString();
                txt_Fax.Text = objDT.Rows[0]["fax"].ToString();
                txt_Email.Text = objDT.Rows[0]["email"].ToString();
            }
        }
        public static void setDDL(System.Web.UI.WebControls.DropDownList ddl, String DefaultString = null)
        {

            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData("  SELECT id,CountrySort from CountrySort", null);

            ddl.DataSource = objDT;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--請選擇--", ""));
        }
        protected void ddl_AddDealerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataHelper objDH = new DataHelper();
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            string selCountry_id = ddlCountry.SelectedValue;
            string sql = "select countryID as 'id',countrySort,[Name] as 'areaName' from CountrySort left join Area on CountrySort.id=Area.countryID where [countryID]=@countryID";
            aDict.Add("@countryID", selCountry_id);
            DataTable objDT = objDH.queryData(sql, aDict);
            ddlArea.DataSource = objDT;
            ddlArea.DataBind();
        }

        protected void btn_AddDealer_Click(object sender, EventArgs e)
        {
                Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            // init 錯誤訊息
            String errorMessage = "";
            if (string.IsNullOrEmpty(ddlCountry.SelectedValue)) errorMessage += "請選擇國家！\\n";
            if (string.IsNullOrEmpty(ddlArea.SelectedValue)) errorMessage += "請選擇地區！\\n";
            if (string.IsNullOrEmpty(txt_Name.Text)) errorMessage += "請輸入Name！\\n";
            if (string.IsNullOrEmpty(txt_Contact.Text)) errorMessage += "請輸入Contact！\\n";
            if (string.IsNullOrEmpty(txt_Address.Text)) errorMessage += "請輸入Address！\\n";
            if (string.IsNullOrEmpty(txt_Tel.Text)) errorMessage += "請輸入Tel！\\n";
            if (string.IsNullOrEmpty(txt_Fax.Text)) errorMessage += "請輸入Fax！\\n";
            if (string.IsNullOrEmpty(txt_Email.Text)) errorMessage += "請輸入Email！\\n";
            if (!String.IsNullOrEmpty(errorMessage))
            {
                Utility.showMessage(Page, "ErrorMessage", errorMessage);
                return;
            }
            string selCountry_id = ddlCountry.SelectedValue;
            string Area = ddlArea.SelectedValue;
            string name = txt_Name.Text;
            string Contact = txt_Contact.Text;
            string Address = txt_Address.Text;
            string Tel = txt_Tel.Text;
            string Fax = txt_Fax.Text;
            string Email = txt_Email.Text;
            string sql = "SELECT 1 from Dealers where country_ID=@countryID and area=@Area and name=@name";
            
            aDict.Add("@countryID", selCountry_id);
            aDict.Add("@area", Area);
            //aDict.Add("@dealerImgPath", @"tayana\images\"+ fileName);
            aDict.Add("@name", name);
            aDict.Add("@Contact", Contact);
            aDict.Add("@Address", Address);
            aDict.Add("@Tel", Tel);
            aDict.Add("@Fax", Fax);
            aDict.Add("@Email", Email);
            DataTable objDT = objDH.queryData(sql, aDict);
            if (objDT.Rows.Count > 0)
            {
                errorMessage = "此地區已有此經銷商";
                Utility.showMessage(Page, "ErrorMessage", errorMessage);
                return;
            }
            else
            {
                string AddSQL = @"  insert into[Dealers]([country_ID],[area],[name],[contact],[address],[tel],[fax],[email])
                    values(@countryID,@area,@name,@Contact,@Address,@Tel,@Fax,@Email)";
                objDT = objDH.queryData(AddSQL, aDict);
            }
            string successrMessage = "新增完成";
            Utility.showMessage(Page, "ErrorMessage", successrMessage);
            return;
            }

        //protected void UploadImgBtn_Click(object sender, EventArgs e)
        //{
        //    //設定存檔路徑，需填完整路徑，結尾反斜線如果沒加要用 Path.Combine() 可自動添加
        //    string savePath = Server.MapPath("~/Tayanahtml/upload/Images/");

        //    //判斷有選檔案才可上傳
        //    if (imageUpload.HasFile)
        //    {
        //        //取得選擇區域名稱
        //        string selAreaStr = ddlCountry.SelectedValue;

        //        //先執行刪除舊圖檔
        //        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
        //        string sqlDel = "SELECT dealerImgPath FROM Dealers WHERE area = @selAreaStr";
        //        SqlCommand commandDel = new SqlCommand(sqlDel, connection);
        //        commandDel.Parameters.AddWithValue("@selAreaStr", selAreaStr);
        //        connection.Open();
        //        SqlDataReader reader = commandDel.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            string delFileName = reader["dealerImgPath"].ToString();
        //            //有舊圖才執行刪除
        //            if (!String.IsNullOrEmpty(delFileName))
        //            {
        //                File.Delete(savePath + delFileName);
        //            }
        //        }
        //        connection.Close();

        //        //儲存圖片檔案及圖片名稱
        //        //檢查專案資料夾內有無同名檔案，有同名就加流水號
        //        DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
        //        //取得選取檔案名稱
        //        string fileName = imageUpload.FileName;
        //        string[] fileNameArr = fileName.Split('.');
        //        int count = 0;
        //        foreach (var fileItem in directoryInfo.GetFiles())
        //        {
        //            if (fileItem.Name.Contains(fileNameArr[0]))
        //            {
        //                count++;
        //            }
        //        }
        //        fileName = fileNameArr[0] + $"({count + 1})." + fileNameArr[1];
        //        imageUpload.SaveAs(savePath + fileName);

        //        //渲染畫面
        //        DateTime nowtime = DateTime.Now;
        //        LabUploadImg.Visible = true;
        //        LabUploadImg.ForeColor = Color.Green;
        //        LabUploadImg.Text = "*Upload Success! - " + nowtime.ToString("G");

        //        //更新資料庫資料
        //        string sql = "UPDATE Dealers SET dealerImgPath = @fileName WHERE area = @selAreaStr";
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        command.Parameters.AddWithValue("@fileName", fileName);
        //        command.Parameters.AddWithValue("@selAreaStr", selAreaStr);
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //        connection.Close();

        //        //渲染畫面
        //        //showDealerListTable();
        //    }
        //    else
        //    {
        //        //警告沒有選取檔案
        //        LabUploadImg.Visible = true;
        //        LabUploadImg.ForeColor = Color.Red;
        //        LabUploadImg.Text = "*Need Choose File!";
        //    }
        //}
    }
}