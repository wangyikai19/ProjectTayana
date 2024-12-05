using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ProjectTayana.CertificateMgt;

namespace ProjectTayana
{
    public partial class CompanyMgt : System.Web.UI.Page
    {
        private List<ImageNameH> saveNameListH = new List<ImageNameH>();
        private List<ImageNameV> saveNameListV = new List<ImageNameV>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
                loadImageHList();
                loadImageVList();
                loadCertificatContent();
            }
        }
        #region Company
        protected void btnOK_Click(object sender, EventArgs e)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            aDict.Add("aboutUsHtml", HttpUtility.HtmlDecode(editor1.Value)); //內容
            string Strsql = "";
            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData(@"SELECT * from [Company]", aDict);
            if (objDT.Rows.Count > 0)
            {
                Strsql = @"update Company set[aboutUsHtml]=@aboutUsHtml";
            }
            else
            {
                Strsql = @"Insert into Company ([aboutUsHtml]) VAlues(@aboutUsHtml)";
            }
            DataTable dt = objDH.queryData(Strsql, aDict);
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('修改成功');window.location ='CompanyMgt.aspx';", true);
        }
        protected void getData()
        {
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData(@"SELECT * from [Company]", aDict);
            if (objDT.Rows.Count > 0)
            {
                editor1.Value = Convert.ToString(objDT.Rows[0]["aboutUsHtml"]).Replace("font-family:\"新細明體\",serif;", "");
                editor1.Value = Convert.ToString(editor1.Value.Replace("font-family:\"微軟正黑體\",sans-serif;", ""));
                editor1.Value = Convert.ToString(editor1.Value.Replace("roman\"; mso-bidi-font-size:12.0pt; mso-font-kerning:0pt; \"", ""));
                editor1.Value = Convert.ToString(editor1.Value.Replace("mso-bidi-font-family:", ""));
                editor1.Value = Convert.ToString(editor1.Value.Replace("Times New Roman", ""));
                editor1.Value = Convert.ToString(editor1.Value.Replace(";mso-bidi-font-size:12.0pt;mso-font-kerning:0pt;", ""));
                editor1.Value = Convert.ToString(editor1.Value.Replace("\"\"", ""));
            }
        }
        #endregion
        private void loadImageHList()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT certificatHorizontalImgJSON FROM Company WHERE id = 1";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string loadJson = reader["certificatHorizontalImgJSON"].ToString();
                saveNameListH = JsonConvert.DeserializeObject<List<ImageNameH>>(loadJson);
            }
            connection.Close();
            if (saveNameListH?.Count > 0)
            {
                foreach (var item in saveNameListH)
                {
                    ListItem listItem = new ListItem($"<img src='/images/{item.SaveName}' alt='thumbnail' class='img-thumbnail' width='230px'/>", item.SaveName);
                    RadioButtonListH.Items.Add(listItem);
                }
            }
            DelHImageBtn.Visible = false;
        }
        private void loadImageVList()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT certificatVerticalImgJSON FROM Company WHERE id = 1";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string loadJson = reader["certificatVerticalImgJSON"].ToString();
                saveNameListV = JsonConvert.DeserializeObject<List<ImageNameV>>(loadJson);
            }
            connection.Close();
            if (saveNameListV?.Count > 0)
            {
                foreach (var item in saveNameListV)
                {
                    ListItem listItem = new ListItem($"<img src='/images/{item.SaveName}' alt='thumbnail' class='img-thumbnail' width='230px'/>", item.SaveName);
                    RadioButtonListV.Items.Add(listItem);
                }
            }
            DelVImageBtn.Visible = false;
        }


        protected void UploadHBtn_Click(object sender, EventArgs e)
        {
            List<ImageNameH> saveNameListH = new List<ImageNameH>();
            if (imageUploadH.HasFile)
            {
                loadImageHList();
                string savePath = Server.MapPath("~/images/");
                foreach (HttpPostedFile postedFile in imageUploadH.PostedFiles)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                    string fileName = postedFile.FileName;
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
                    postedFile.SaveAs(savePath + "temp" + fileName);
                    saveNameListH.Add(new ImageNameH { SaveName = fileName });
                    var img = NetVips.Image.NewFromFile(savePath + "temp" + fileName);
                    if (img.Width > 214 * 2)
                    {
                        var newImg = img.Resize(0.5);
                        while (newImg.Width > 214 * 2)
                        {
                            newImg = newImg.Resize(0.5);
                        }
                        newImg.WriteToFile(savePath + fileName);
                    }
                    else
                    {
                        postedFile.SaveAs(savePath + fileName);
                    }
                    File.Delete(savePath + "temp" + fileName);
                }

                string fileNameJsonStr = JsonConvert.SerializeObject(saveNameListH);
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
                string sql = "UPDATE Company SET certificatHorizontalImgJSON = @fileNameJsonStr WHERE id = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@fileNameJsonStr", fileNameJsonStr);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                RadioButtonListH.Items.Clear();
                loadImageHList();
            }
        }
        protected void RadioButtonListH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelHImageBtn.Visible = true;
        }

        protected void DelHImageBtn_Click(object sender, EventArgs e)
        {
            loadImageHList();
            string selHImageStr = RadioButtonListH.SelectedValue;

            string savePath = Server.MapPath("~/images/");
            File.Delete(savePath + selHImageStr);

            for (int i = 0; i < saveNameListH.Count; i++)
            {
                if (saveNameListH[i].SaveName.Equals(selHImageStr))
                {
                    saveNameListH.RemoveAt(i);
                }
            }

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string saveNameJsonStr = JsonConvert.SerializeObject(saveNameListH);
            string sql = "UPDATE Company SET certificatHorizontalImgJSON = @saveNameJsonStr WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@saveNameJsonStr", saveNameJsonStr);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染畫面
            RadioButtonListH.Items.Clear();
            loadImageHList();
        }

        protected void UploadVBtn_Click(object sender, EventArgs e)
        {
            List<ImageNameV> saveNameListV = new List<ImageNameV>();
            //有選擇檔案才執行
            if (imageUploadV.HasFile)
            {
                //先讀取資料庫原有資料
                loadImageVList();
                string savePath = Server.MapPath("~/images/");

                //添加圖檔資料
                //逐一讀取選擇的圖片檔案
                foreach (HttpPostedFile postedFile in imageUploadV.PostedFiles)
                {
                    //儲存圖片檔案及圖片名稱
                    //檢查專案資料夾內有無同名檔案，有同名就加流水號
                    DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                    string fileName = postedFile.FileName;
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
                    //在圖片名稱前加入 temp 標示並儲存圖片檔案
                    postedFile.SaveAs(savePath + "temp" + fileName);
                    //新增 JSON 資料
                    saveNameListV.Add(new ImageNameV { SaveName = fileName });
                    //使用 NetVips 套件進行壓縮圖檔
                    //判斷儲存的原始圖片寬度是否大於設定寬度的 2 倍
                    var img = NetVips.Image.NewFromFile(savePath + "temp" + fileName);
                    if (img.Width > 214 * 2)
                    {
                        //產生原使圖片一半大小的新圖片
                        var newImg = img.Resize(0.5);
                        //如果新圖片寬度還是大於原始圖片設定寬度的 2 倍就持續縮減
                        while (newImg.Width > 214 * 2)
                        {
                            newImg = newImg.Resize(0.5);
                        }
                        //儲存正式名稱的新圖片
                        newImg.WriteToFile(savePath + fileName);
                    }
                    else
                    {
                        postedFile.SaveAs(savePath + fileName);
                    }
                    //刪除原始圖片
                    File.Delete(savePath + "temp" + fileName);
                }

                //更新新增後的圖片名稱 JSON 存入資料庫
                string fileNameJsonStr = JsonConvert.SerializeObject(saveNameListV);
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
                string sql = "UPDATE Company SET certificatVerticalImgJSON = @fileNameJsonStr WHERE id = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@fileNameJsonStr", fileNameJsonStr);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                //渲染畫面
                RadioButtonListV.Items.Clear();
                loadImageVList();
            }
        }

        protected void DelVImageBtn_Click(object sender, EventArgs e)
        {
            //先讀取資料庫原有資料
            loadImageVList();
            //取得選取項目的值
            string selVImageStr = RadioButtonListV.SelectedValue;

            //刪除圖片檔案
            string savePath = Server.MapPath("~/images/");
            File.Delete(savePath + selVImageStr);

            //逐一比對原始資料 List<saveNameListH> 中的檔案名稱
            for (int i = 0; i < saveNameListV.Count; i++)
            {
                //與刪除的選項相同名稱
                if (saveNameListV[i].SaveName.Equals(selVImageStr))
                {
                    //移除 List 中同名的資料
                    saveNameListV.RemoveAt(i);
                }
            }

            //更新刪除後的圖片名稱 JSON 存入資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string saveNameJsonStr = JsonConvert.SerializeObject(saveNameListV);
            string sql = "UPDATE Company SET certificatVerticalImgJSON = @saveNameJsonStr WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@saveNameJsonStr", saveNameJsonStr);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染畫面
            RadioButtonListV.Items.Clear();
            loadImageVList();
        }
        protected void RadioButtonListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //顯示刪除按鈕
            DelVImageBtn.Visible = true;
        }

        protected void uploadCertificatBtn_Click(object sender, EventArgs e)
        {
            //更新 Certificat 頁文字說明資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "UPDATE Company SET certificatContent = @certificatContent WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@certificatContent", certificatTbox.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染畫面提示
            DateTime nowtime = DateTime.Now;
            uploadCertificatLab.Visible = true;
            uploadCertificatLab.Text = "*Upload Success! - " + nowtime.ToString("G");
        }
        private void loadCertificatContent()
        {
            //取得 Certificat 頁文字說明資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT certificatContent FROM Company WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                certificatTbox.Text = reader["certificatContent"].ToString();
            }
            connection.Close();
        }
    }
}