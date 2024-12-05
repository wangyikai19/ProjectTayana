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
using static ProjectTayana.yachts;

namespace ProjectTayana
{
    public partial class Yachts_Layout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //會先跑 Content 頁的 Page_Load 才跑 Master 頁的 Page_Load
            if (!IsPostBack)
            {
                loadContent();
                loadLeftMenu(); //讀取並渲染左側型號邊欄
                loadTopMenu(); //讀取並渲染型號內容上方標題及分頁列
                loadBanner();
            }
        }
        private void loadContent()
        {
            //取得 Session 共用 Guid，Session 物件需轉回字串
            string guidStr = Session["guid"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            //依 Guid 取得型號資料
            string sql = "SELECT layoutDeckPlanImgPathJSON FROM Yacht WHERE guid = @guidStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder layoutHtmlStr = new StringBuilder();
            List<LayoutPath> saveImagPathList = new List<LayoutPath>();
            if (reader.Read())
            {
                string loadImgJson = HttpUtility.HtmlDecode(reader["layoutDeckPlanImgPathJSON"].ToString());
                //加入頁面組圖 HTML
                saveImagPathList = JsonConvert.DeserializeObject<List<LayoutPath>>(loadImgJson);
                if(saveImagPathList != null)
                {
                    foreach (var item in saveImagPathList)
                    {
                        //加入每張圖片
                        layoutHtmlStr.Append($"<li><img src='Tayanahtml/upload/Images/{item.SavePath}' alt='layout' Width='670px' /></li>");
                    }
                }

                //渲染畫面
                ContentHtml.Text = layoutHtmlStr.ToString();
            }
            connection.Close();

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
                if (saveRowList != null)
                {
                    if (saveRowList.Count>0)
                    {
                        topMenuHtmlStr.Append($"<li><a class='menu_yli04' href='Yachts_Video.aspx?id={guidStr}' >Video</a></li>");
                    }
                }


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
        //表格欄位 JSON 資料
        public class RowData
        {
            public string SaveItem { get; set; }
            public string SaveValue { get; set; }
        }

        //頁面組圖 JSON 資料
        public class LayoutPath
        {
            public string SavePath { get; set; }
        }
    }
}