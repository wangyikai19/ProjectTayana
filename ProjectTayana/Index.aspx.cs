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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBanner();
                loadNews();
            }
        }
        private void loadBanner()
        {
            List<ImagePath> savePathList = new List<ImagePath>();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT * FROM Yacht ORDER BY id DESC";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder bannerHtml = new StringBuilder();
            StringBuilder bannerNumHtml = new StringBuilder();
            while (reader.Read())
            {
                string loadJson = HttpUtility.HtmlDecode(reader["bannerImgPathJSON"].ToString());
                savePathList = JsonConvert.DeserializeObject<List<ImagePath>>(loadJson);
                string imgNameStr = "";
                if (savePathList?.Count > 0)
                {
                    imgNameStr = savePathList[0].SavePath;
                }
                string[] modelArr = reader["yachtModel"].ToString().Split(' ');
                string isNewDesignStr = reader["isNewDesign"].ToString();
                string isNewBuildingStr = reader["isNewBuilding"].ToString();
                string newTagStr = ""; 
                string displayNewStr = "0";
                if (isNewDesignStr.Equals("True"))
                {
                    displayNewStr = "1";
                    newTagStr = "tayana/html/images/new01.png";
                }
                else if (isNewBuildingStr.Equals("True"))
                {
                    displayNewStr = "1";
                    newTagStr = "tayana/html/images/new01.png";
                }
                bannerHtml.Append($"<li class='info' style='border-radius: 5px;height: 424px;width: 978px;'><a href='' target='_blank'><img src='/Tayanahtml/upload/Images/{imgNameStr}' style='width: 978px;height: 424px;border-radius: 5px;'/></a><div class='wordtitle'>{modelArr[0]} <span>{modelArr[1]}</span><br /><p>SPECIFICATION SHEET</p></div><div class='new' style='overflow: hidden;border-radius:10px;'><img src='{newTagStr}' alt='' /></div><input type='hidden' value='{displayNewStr}' /></li>");
                bannerNumHtml.Append($"<li><div><p class='bannerimg_p'><img  src='/Tayanahtml/upload/Images/{imgNameStr}' style='width: 100px;height: 60px;' alt='&quot;&quot;' /></p></div></li>");

            }
            connection.Close();
            LitBanner.Text = bannerHtml.ToString();
            LitBannerNum.Text = bannerNumHtml.ToString();
        }
        private void loadNews()
        {
            DateTime nowTime = DateTime.Now;
            string nowDate = nowTime.ToString("yyyy-MM-dd");
            int startDate = -1;
            DateTime limitTime = nowTime.AddMonths(startDate);
            string limitDate = limitTime.ToString("yyyy-MM-dd");

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT COUNT(id) FROM Notice WHERE CreateDT >= @limitDate AND CreateDT <= @nowDate";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nowDate", nowDate);
            command.Parameters.AddWithValue("@limitDate", limitDate);
            connection.Open();

            int newsNum = Convert.ToInt32(command.ExecuteScalar());

            while (newsNum < 3)
            {
                startDate--;
                limitTime = nowTime.AddDays(startDate);
                limitDate = limitTime.ToString("yyyy-MM-dd");
                SqlCommand command2 = new SqlCommand(sql, connection);
                command2.Parameters.AddWithValue("@nowDate", nowDate);
                command2.Parameters.AddWithValue("@limitDate", limitDate);
                newsNum = Convert.ToInt32(command2.ExecuteScalar());
            }
            connection.Close();

            connection.Open();
            string sql2 = "SELECT TOP 3 * FROM Notice WHERE CreateDT >= @limitDate AND CreateDT <= @nowDate ORDER BY OrderSeq DESC, CreateDT DESC";
            SqlCommand command3 = new SqlCommand(sql2, connection);
            command3.Parameters.AddWithValue("@nowDate", nowDate);
            command3.Parameters.AddWithValue("@limitDate", limitDate);
            SqlDataReader reader = command3.ExecuteReader();
            int count = 1; 
            while (reader.Read())
            {
                string isTopStr = "True";
                string guidStr = reader["ID"].ToString();
                if (count == 1)
                {

                    string newsImg = reader["TkURL_Pic"].ToString();
                    LiteralNewsImg1.Text = $"<img id='thumbnail_Image1' src='{newsImg}' style='border-width: 0px;width:95px;height:95px' />";
                    DateTime dateTimeTitle = DateTime.Parse(reader["CreateDT"].ToString());
                    LabNewsDate1.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews1.Text = reader["Title"].ToString();
                    HLinkNews1.NavigateUrl = $"NewsContent.aspx?sno={guidStr}";
                    if (isTopStr.Equals("True"))
                    {
                        ImgIsTop1.Visible = true;
                    }
                }
                else if (count == 2)
                {

                    string newsImg = reader["TkURL_Pic"].ToString();
                    LiteralNewsImg2.Text = $"<img id='thumbnail_Image2' src='{newsImg}' style='border-width: 0px;width:95px;height:95px' />";
                    DateTime dateTimeTitle = DateTime.Parse(reader["CreateDT"].ToString());
                    LabNewsDate2.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews2.Text = reader["Title"].ToString();
                    HLinkNews2.NavigateUrl = $"NewsContent.aspx?sno={guidStr}";
                    if (isTopStr.Equals("True"))
                    {
                        ImgIsTop2.Visible = true;
                    }
                }
                else if (count == 3)
                {

                    string newsImg = reader["TkURL_Pic"].ToString();
                    LiteralNewsImg3.Text = $"<img id='thumbnail_Image3' src='{newsImg}' style='border-width: 0px;width:95px;height:95px' />";
                    DateTime dateTimeTitle = DateTime.Parse(reader["CreateDT"].ToString());
                    LabNewsDate3.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews3.Text = reader["Title"].ToString();
                    HLinkNews3.NavigateUrl = $"NewsContent.aspx?sno={guidStr}";
                    if (isTopStr.Equals("True"))
                    {
                        ImgIsTop3.Visible = true;
                    }
                }
                else break; 
                count++;
            }
            connection.Close();
        }

        public class ImagePath
        {
            public string SavePath { get; set; }
        }
    }
}