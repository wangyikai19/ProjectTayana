using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTayana
{
    public partial class Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadContentText();
                loadContentImgV();
                loadContentImgH();
            }
        }
        private void loadContentText()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlCountry = "SELECT TOP 1 certificatContent FROM Company";
            SqlCommand command = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ContentText.Text = reader["certificatContent"].ToString();
            }
            connection.Close();
        }
        private void loadContentImgV()
        {
            StringBuilder ImgVHtml = new StringBuilder();
            List<ImagePathV> savePathListV = new List<ImagePathV>();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT TOP 1 certificatVerticalImgJSON FROM Company";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string loadJson = HttpUtility.HtmlDecode(reader["certificatVerticalImgJSON"].ToString());
                savePathListV = JsonConvert.DeserializeObject<List<ImagePathV>>(loadJson);
            }
            connection.Close();
            if (savePathListV?.Count > 0)
            {
                foreach (var item in savePathListV)
                {
                    ImgVHtml.Append($"<li><p><img src='images/{item.SaveName}' alt='Tayana ' /></p></li>");
                }
            }
            ContentImgV.Text = ImgVHtml.ToString();
        }
        private void loadContentImgH()
        {
            StringBuilder ImgHHtml = new StringBuilder();
            List<ImagePathH> savePathListH = new List<ImagePathH>();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT TOP 1 certificatHorizontalImgJSON FROM Company";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string loadJson = HttpUtility.HtmlDecode(reader["certificatHorizontalImgJSON"].ToString());
                savePathListH = JsonConvert.DeserializeObject<List<ImagePathH>>(loadJson);
            }
            connection.Close();
            if (savePathListH?.Count > 0)
            {
                foreach (var item in savePathListH)
                {
                    ImgHHtml.Append($"<li><p><img src='images/{item.SaveName}' alt='Tayana ' width='319px' height='234px' /></p></li>");
                }
            }
            ContentImgH.Text = ImgHHtml.ToString();
        }
        public class ImagePathH
        {
            public string SaveName { get; set; }
        }

        public class ImagePathV
        {
            public string SaveName { get; set; }
        }
    }
}