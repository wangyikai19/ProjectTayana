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
    public partial class DearlerUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id=Request.QueryString["ID"];
                bindData(id);
            }
        }
        protected void bindData(string id)
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
                lb_Country.Text = objDT.Rows[0]["countrySort"].ToString();
                lb_Area.Text = objDT.Rows[0]["areaName"].ToString();
                //txt_Image.Text= objDT.Rows[0]["dealerImgPath"].ToString();
                txt_Name.Text = objDT.Rows[0]["name"].ToString();
                txt_Contact.Text = objDT.Rows[0]["contact"].ToString();
                txt_Address.Text = objDT.Rows[0]["address"].ToString();
                txt_Tel.Text = objDT.Rows[0]["tel"].ToString();
                txt_Fax.Text = objDT.Rows[0]["fax"].ToString();
                txt_Email.Text = objDT.Rows[0]["email"].ToString();
                Image1.ImageUrl = $"Tayanahtml/upload/Images/{objDT.Rows[0]["dealerImgPath"]}";
            }
        }

        protected void btn_AddDealer_Click(object sender, EventArgs e)
        {
            String sql = @" update Dealers set dealerImgPath=@dealerImgPath,[name]=@name,contact=@contact,[address]=@address,tel=@tel,fax=@fax,email=@email where id=@id ";
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            //aDict.Add("@dealerImgPath", txt_Image.Text );
            aDict.Add("@name", txt_Name.Text);
            aDict.Add("@contact", txt_Contact.Text);
            aDict.Add("@address", txt_Address.Text);
            aDict.Add("@tel", txt_Tel.Text);
            aDict.Add("@fax", txt_Fax.Text);
            aDict.Add("@email", txt_Email.Text);
            aDict.Add("@id", Request.QueryString["ID"]);

        }

        protected void UploadImgBtn_Click(object sender, EventArgs e)
        {
            //設定存檔路徑，需填完整路徑，結尾反斜線如果沒加要用 Path.Combine() 可自動添加
            string savePath = Server.MapPath("~/Tayanahtml/upload/Images/");

            //判斷有選檔案才可上傳
            if (imageUpload.HasFile)
            {
                //取得選擇區域名稱
                string id = Request.QueryString["ID"];

                //先執行刪除舊圖檔
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
                string sqlDel = "SELECT dealerImgPath FROM Dealers WHERE ID = @id";
                SqlCommand commandDel = new SqlCommand(sqlDel, connection);
                commandDel.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = commandDel.ExecuteReader();
                if (reader.Read())
                {
                    string delFileName = reader["dealerImgPath"].ToString();
                    //有舊圖才執行刪除
                    if (!String.IsNullOrEmpty(delFileName))
                    {
                        File.Delete(savePath + delFileName);
                    }
                }
                connection.Close();

                //儲存圖片檔案及圖片名稱
                //檢查專案資料夾內有無同名檔案，有同名就加流水號
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                //取得選取檔案名稱
                string fileName = imageUpload.FileName;
                string[] fileNameArr = fileName.Split('.');
                int count = 0;
                foreach (var fileItem in directoryInfo.GetFiles())
                {
                    if (fileItem.Name.Contains(fileNameArr[0]))
                    {
                        count++;
                    }
                }
                fileName = fileNameArr[0] + $"({count + 1})." + fileNameArr[1];
                imageUpload.SaveAs(savePath + fileName);

                //渲染畫面
                DateTime nowtime = DateTime.Now;
                LabUploadImg.Visible = true;
                LabUploadImg.ForeColor = Color.Green;
                LabUploadImg.Text = "*Upload Success! - " + nowtime.ToString("G");

                //更新資料庫資料
                string sql = "UPDATE Dealers SET dealerImgPath = @fileName WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@fileName", fileName);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                //渲染畫面
                //showDealerListTable();
            }
            else
            {
                //警告沒有選取檔案
                LabUploadImg.Visible = true;
                LabUploadImg.ForeColor = Color.Red;
                LabUploadImg.Text = "*Need Choose File!";
            }
        }
    }
}