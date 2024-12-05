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
using static ProjectTayana.SpecificationMgt;

namespace ProjectTayana
{
    public partial class Yachts_Specification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadLeftMenu();
                loadContent();
                loadTopMenu();
                loadBanner();
            }
        }
        private void loadContent()
        {
            string guidStr = Session["guid"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT Yacht.guid, Specification.detail, DetailTitleSort.detailTitleSort"
                        + " FROM DetailTitleSort INNER JOIN"
                            + " Specification ON DetailTitleSort.id = Specification.detailTitleSort_ID INNER JOIN"
                            + " Yacht ON Specification.yachtModel_ID = Yacht.id WHERE Yacht.guid = @guidStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder detailHtmlStr = new StringBuilder();
            //用於檢查 Title 是否相同
            string checkTitle = "";
            while (reader.Read())
            {
                string detailTitle = reader["detailTitleSort"].ToString();
                //需使用 HtmlDecode ，因為存入時有使用 HtmlEncode 轉換換行用標籤 <br>
                string detailStr = HttpUtility.HtmlDecode(reader["detail"].ToString());
                // 加入第一個標題，並更新檢查用變數
                if (String.IsNullOrEmpty(checkTitle))
                {
                    detailHtmlStr.Append($"<p>{detailTitle}</p><ul>");
                    checkTitle = detailTitle;
                }
                // Title 不相同時就更新確認用變數並加入 Title 的 HTML 語法
                else if (!checkTitle.Equals(detailTitle))
                {
                    checkTitle = detailTitle;
                    detailHtmlStr.Append($"</ul><p>{detailTitle}</p><ul>");
                }
                detailHtmlStr.Append($"<li>{detailStr}</li>");
            }
            connection.Close();
            //結束 HTML 字串並渲染畫面
            detailHtmlStr.Append($"</ul>");
            ContentHtml.Text = detailHtmlStr.ToString();
        }
        private void loadBanner()
        {
            List<ImagePath> savePathList = new List<ImagePath>();
            string guidStr = Session["guid"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlLoad = "SELECT * FROM Yacht where guid = @guidStr";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            command.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder bannerHtml = new StringBuilder();
            StringBuilder bannerNumHtml = new StringBuilder();
            while (reader.Read())
            {
                string loadJson = HttpUtility.HtmlDecode(reader["bannerImgPathJSON"].ToString());
                savePathList = JsonConvert.DeserializeObject<List<ImagePath>>(loadJson);
                string imgNameStr = "";
                string[] modelArr = reader["yachtModel"].ToString().Split(' ');
                string newTagStr = "";
                string displayNewStr = "0";
                if (savePathList?.Count > 0)
                {
                    foreach (var item in savePathList)
                    {
                        imgNameStr = item.SavePath;
                        bannerNumHtml.Append($" <li><a href='/Tayanahtml/upload/Images/{imgNameStr}' ><img src='/Tayanahtml/upload/Images/{imgNameStr}' style='width: 100px;height: 60px;'></a></li>");
                    }
                }

            }
            connection.Close();
            LitBannerNum.Text = bannerNumHtml.ToString();
        }
        private void loadLeftMenu()
        {
            string urlPathStr = System.IO.Path.GetFileName(Request.PhysicalPath);
            //取得遊艇型號資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT * FROM Yacht";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder leftMenuHtml = new StringBuilder();
            while (reader.Read())
            {
                string yachtModelStr = reader["yachtModel"].ToString();
                string isNewDesignStr = reader["isNewDesign"].ToString();
                string isNewBuildingStr = reader["isNewBuilding"].ToString();
                string guidStr = reader["guid"].ToString();
                string isNewStr = "";
                //依是否為新建或新設計加入標註
                if (isNewDesignStr.Equals("True"))
                {
                    isNewStr = "(New Design)";
                }
                else if (isNewBuildingStr.Equals("True"))
                {
                    isNewStr = "(New Building)";
                }
                leftMenuHtml.Append($"<li><a href='{urlPathStr}?id={guidStr}'>{yachtModelStr} {isNewStr}</a></li>");
            }
            connection.Close();

            //渲染左側遊艇型號選單
            LeftMenuHtml.Text = leftMenuHtml.ToString();
        }
        private void loadTopMenu()
        {
            //取得 Session 共用 GUID，Session 物件需轉回字串
            string guidStr = Session["guid"].ToString();
            //依 GUID 取得遊艇資料
            List<RowData> saveRowList = new List<RowData>();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT * FROM Yacht WHERE guid = @guidStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder topMenuHtmlStr = new StringBuilder();
            StringBuilder dimensionsTableHtmlStr = new StringBuilder();
            if (reader.Read())
            {
                string yachtModelStr = reader["yachtModel"].ToString();
                string contentHtmlStr = HttpUtility.HtmlDecode(reader["overviewContentHtml"].ToString());
                string loadJson = HttpUtility.HtmlDecode(reader["overviewDimensionsJSON"].ToString());
                string dimensionsImgPathStr = reader["overviewDimensionsImgPath"].ToString();
                string downloadsFilePathStr = reader["overviewDownloadsFilePath"].ToString();

                //加入渲染型號內容上方分類連結列表
                topMenuHtmlStr.Append($"<li><a class='menu_yli01' href='Yachts_OverView.aspx?id={guidStr}' >OverView</a></li>");
                topMenuHtmlStr.Append($"<li><a class='menu_yli02' href='Yachts_Layout.aspx?id={guidStr}' >Layout & deck plan</a></li>");
                topMenuHtmlStr.Append($"<li><a class='menu_yli03' href='Yachts_Specification.aspx?id={guidStr}' >Specification</a></li>");
                //加入渲染型號內容上方分類連結列表 Video 分頁標籤，有存影片連結網址才渲染
                saveRowList = JsonConvert.DeserializeObject<List<RowData>>(loadJson);
                //if (saveRowList != null)
                //{
                //    if (!String.IsNullOrEmpty(saveRowList[0].SaveValue))
                //    {
                //        topMenuHtmlStr.Append($"<li><a class='menu_yli04' href='Yachts_Video.aspx?id={guidStr}' >Video</a></li>");
                //    }
                //}


                //渲染畫面
                //渲染上方小連結
                LabLink.InnerText = yachtModelStr;
                //渲染標題
                LabTitle.InnerText = yachtModelStr;
                //渲染型號內容上方分類連結列表
                TopMenuLinkHtml.Text = topMenuHtmlStr.ToString();
            }
            connection.Close();
        }
        public class RowData
        {
            public string SaveItem { get; set; }
            public string SaveValue { get; set; }
        }
    }
}