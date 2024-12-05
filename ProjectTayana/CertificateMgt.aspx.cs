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
using static ProjectTayana.CertificateMgt;

namespace ProjectTayana
{
    public partial class CertificateMgt : System.Web.UI.Page
    {
        private List<ImageNameH> saveNameListH = new List<ImageNameH>();
        private List<ImageNameV> saveNameListV = new List<ImageNameV>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadImageHList();
                loadImageVList();
            }
        }
        public class ImageNameH
        {
            public string SaveName { get; set; }
        }
        public class ImageNameV
        {
            public string SaveName { get; set; }
        }
        private void loadImageHList()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT certificatHorizontalImgJSON FROM Company";
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
            string sqlLoad = "SELECT certificatVerticalImgJSON FROM Company";
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
            RadioButtonListH.Items.Clear();
            loadImageHList();
        }

        protected void UploadVBtn_Click(object sender, EventArgs e)
        {
            if (imageUploadV.HasFile)
            {
                loadImageVList();
                string savePath = Server.MapPath("~/images/");
                foreach (HttpPostedFile postedFile in imageUploadV.PostedFiles)
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
                    saveNameListV.Add(new ImageNameV { SaveName = fileName });

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

                string fileNameJsonStr = JsonConvert.SerializeObject(saveNameListV);
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
                string sql = "UPDATE Company SET certificatVerticalImgJSON = @fileNameJsonStr WHERE id = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@fileNameJsonStr", fileNameJsonStr);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                RadioButtonListV.Items.Clear();
                loadImageVList();
            }
        }
        protected void RadioButtonListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelVImageBtn.Visible = true;
        }

        protected void DelVImageBtn_Click(object sender, EventArgs e)
        {

        }
    }
}