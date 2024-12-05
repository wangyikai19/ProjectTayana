using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTayana
{
    public partial class SpecificationMgt : System.Web.UI.Page
    {
        //宣告 List<T> 方便用 Add 依序添加資料
        private List<ImagePath> savePathList = new List<ImagePath>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DListModel.DataBind(); //先取得型號預設選取值
                DListDetailTitle.DataBind(); //先取得細節標題預設選取值
                loadImageList(); //取得 Layout 組圖
                loadDetailList(); //取得標題細節
            }
        }
        #region Group Image List
        private void loadImageList()
        {
            //依型號取得組圖圖片資料
            string selectModel_id = DListModel.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT layoutDeckPlanImgPathJSON FROM Yacht WHERE id = @selectModel_id";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //將特殊符號解碼
                string loadJson = HttpUtility.HtmlDecode(reader["layoutDeckPlanImgPathJSON"].ToString());
                //反序列化JSON格式
                savePathList = JsonConvert.DeserializeObject<List<ImagePath>>(loadJson);
            }
            connection.Close();

            //渲染圖片選項
            if (savePathList?.Count > 0)
            {
                foreach (var item in savePathList)
                {
                    ListItem listItem = new ListItem($"<img src='/Tayanahtml/upload/Images/{item.SavePath}' alt='thumbnail' class='img-thumbnail' width='250px'/>", item.SavePath);
                    RadioButtonListImg.Items.Add(listItem);
                }
            }

            DelImageBtn.Visible = false; //刪除鈕有選擇圖片時才顯示
        }

        protected void UploadImgBtn_Click(object sender, EventArgs e)
        {
            List<ImagePath> savePathList = new List<ImagePath>();
            if (imageUpload.HasFile)
            {
                int fileSize = imageUpload.PostedFile.ContentLength;
                if (fileSize < 1024 * 1000 * 10)
                {
                    loadImageList();
                    string savePath = Server.MapPath("~/Tayanahtml/upload/Images/");
                    foreach (HttpPostedFile postedFile in imageUpload.PostedFiles)
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
                        savePathList.Add(new ImagePath { SavePath = fileName });

                        var image = NetVips.Image.NewFromFile(savePath + "temp" + fileName);
                        if (image.Width > 672 * 2)
                        {
                            var newImg = image.Resize(0.5);
                            while (newImg.Width > 672 * 2)
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

                    string selectModel_id = DListModel.SelectedValue;
                    string savePathJsonStr = JsonConvert.SerializeObject(savePathList);
                    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
                    string sql = "UPDATE Yacht SET layoutDeckPlanImgPathJSON = @layoutDeckPlanImgPathJSON WHERE id = @selectModel_id";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@layoutDeckPlanImgPathJSON", savePathJsonStr);
                    command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    RadioButtonListImg.Items.Clear();
                    loadImageList();
                }
                else
                {
                    Response.Write("<script>alert('*The maximum upload size is 10MB!');</script>");
                }

            }
        }
        public class ImagePath
        {
            public string SavePath { get; set; }
        }

        protected void RadioButtonListImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelImageBtn.Visible = true;
        }

        protected void DelImageBtn_Click(object sender, EventArgs e)
        {
            loadImageList();
            string selImageStr = RadioButtonListImg.SelectedValue;
            string savePath = Server.MapPath("~/Tayanahtml/upload/Images/");
            File.Delete(savePath + selImageStr);
            for (int i = 0; i < savePathList.Count; i++)
            {
                if (savePathList[i].SavePath.Equals(selImageStr))
                {
                    savePathList.RemoveAt(i);
                }
            }

            string savePathJsonStr = JsonConvert.SerializeObject(savePathList);
            string selectModel_id = DListModel.SelectedValue;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "UPDATE Yacht SET layoutDeckPlanImgPathJSON = @layoutDeckPlanImgPathJSON WHERE id = @selectModel_id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@layoutDeckPlanImgPathJSON", savePathJsonStr);
            command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            RadioButtonListImg.Items.Clear();
            loadImageList();
        }
        #endregion
        private void loadDetailList()
        {
            string selectModel_id = DListModel.SelectedValue;
            string selectTitle_id = DListDetailTitle.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT detail FROM Specification WHERE yachtModel_ID = @selectModel_id AND detailTitleSort_ID = @selectTitle_id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
            command.Parameters.AddWithValue("@selectTitle_id", selectTitle_id);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string detail = reader["detail"].ToString();
                ListItem listItem = new ListItem(HttpUtility.HtmlDecode(detail), detail);
                RadioButtonListDetail.Items.Add(listItem);
            }
            connection.Close();
            BtnDelDetail.Visible = false;
        }

        protected void BtnAddNewTitle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBoxAddNewTitle.Text))
            {
                string newTitleStr = TBoxAddNewTitle.Text;
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
                string sql = "INSERT INTO DetailTitleSort (detailTitleSort) VALUES(@newTitleStr)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@newTitleStr", newTitleStr);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                GridView1.DataBind();
                DListDetailTitle.DataBind();
                DListDetailTitle.SelectedIndex = DListDetailTitle.Items.Count - 1;
                TBoxAddNewTitle.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('輸入不得為空！');", true);
            }
            
        }
        protected void DeltedTitle(object sender, GridViewDeletedEventArgs e)
        {
            DListDetailTitle.DataBind();
            RadioButtonListDetail.Items.Clear();
            RadioButtonListDetail.DataBind();
            loadDetailList();
        }
        protected void UpdatedTitle(object sender, GridViewUpdatedEventArgs e)
        {
            DListDetailTitle.DataBind();
            RadioButtonListDetail.Items.Clear();
            RadioButtonListDetail.DataBind();
            loadDetailList();
        }

        protected void BtnAddDetail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TboxDetail.Text))
            {
                string newDetailStr = TboxDetail.Text;
                newDetailStr = newDetailStr.Replace("\r\n", "<br>");
                string selectModel_id = DListModel.SelectedValue;
                string selectTitle_id = DListDetailTitle.SelectedValue;
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
                string sql = "INSERT INTO Specification (yachtModel_ID, detailTitleSort_ID, detail) VALUES (@selectModel_id, @selectTitle_id, @detail)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
                command.Parameters.AddWithValue("@selectTitle_id", selectTitle_id);
                command.Parameters.AddWithValue("@detail", HttpUtility.HtmlEncode(newDetailStr));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                ListItem listItem = new ListItem(newDetailStr, newDetailStr);
                RadioButtonListDetail.Items.Add(listItem);
                TboxDetail.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('輸入不得為空！');", true);
            }
           
        }

        protected void BtnDelDetail_Click(object sender, EventArgs e)
        {
            string selectModel_id = DListModel.SelectedValue;
            string selectTitle_id = DListDetailTitle.SelectedValue;
            string selectDetailStr = RadioButtonListDetail.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "DELETE FROM Specification WHERE yachtModel_ID = @selectModel_id AND detailTitleSort_ID = @selectTitle_id AND detail = @selectDetailStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
            command.Parameters.AddWithValue("@selectTitle_id", selectTitle_id);
            command.Parameters.AddWithValue("@selectDetailStr", selectDetailStr);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            RadioButtonListDetail.Items.Clear();
            loadDetailList();
        }
        protected void RadioButtonListD_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnDelDetail.Visible = true;
        }
        protected void DListDetailTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonListDetail.Items.Clear();
            loadDetailList();
        }
        protected void DListModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonListImg.Items.Clear();
            RadioButtonListDetail.Items.Clear();
            loadImageList();
            loadDetailList();
        }
    }
}