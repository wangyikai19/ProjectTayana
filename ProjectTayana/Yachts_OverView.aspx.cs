using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class Yachts_OverView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBanner();
                loadContent();
                loadLeftMenu(); //讀取並渲染左側型號邊欄
                loadTopMenu(); //讀取並渲染型號內容上方標題及分頁列
            }
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
                    foreach(var item in savePathList)
                    {
                        imgNameStr = item.SavePath;
                        bannerNumHtml.Append($" <li><a href='/Tayanahtml/upload/Images/{imgNameStr}' ><img src='/Tayanahtml/upload/Images/{imgNameStr}' style='width: 100px;height: 60px;'></a></li>");
                    }
                }

            }
            connection.Close();
            LitBannerNum.Text = bannerNumHtml.ToString();
        }
        private void loadContent()
        {
            string guidStr = Session["guid"].ToString();
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            aDict.Add("guidStr", guidStr);
            DataTable objDT = objDH.queryData(@"SELECT * FROM Yacht WHERE guid = @guidStr", aDict);

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT * FROM Yacht WHERE guid = @guidStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder dimensionsTableHtmlStr = new StringBuilder();
            List<RowData> saveRowList = new List<RowData>();
            if (reader.Read())
            {
                string yachtModelStr = reader["yachtModel"].ToString();
                string contentHtmlStr = HttpUtility.HtmlDecode(reader["overviewContentHtml"].ToString());
                string loadJson = HttpUtility.HtmlDecode(reader["overviewDimensionsJSON"].ToString());
                string dimensionsImgPathStr = reader["overviewDimensionsImgPath"].ToString();
                string downloadsFilePathStr = reader["overviewDownloadsFilePath"].ToString();
                saveRowList = JsonConvert.DeserializeObject<List<RowData>>(loadJson);

                ContentHtml.Text = contentHtmlStr;
                string[] yachtModelArr = yachtModelStr.Split(' ');
                dimensionTitle.InnerText = yachtModelArr[1] + " DIMENSIONS";
                if (objDT.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension1"].ToString()))
                    {
                        Label1.Text = objDT.Rows[0]["Dimension1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension2"].ToString()))
                    {
                        Label2.Text = objDT.Rows[0]["Dimension2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension3"].ToString()))
                    {
                        Label3.Text = objDT.Rows[0]["Dimension3"].ToString();
                    }
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension4"].ToString()))
                    {
                        Label4.Text = objDT.Rows[0]["Dimension4"].ToString();
                    }
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension5"].ToString()))
                    {
                        Label5.Text = objDT.Rows[0]["Dimension5"].ToString();
                    }
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension6"].ToString()))
                    {
                        Label6.Text = objDT.Rows[0]["Dimension6"].ToString();
                    }
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension7"].ToString()))
                    {
                        Label7.Text = objDT.Rows[0]["Dimension7"].ToString();
                    }
                    if (!string.IsNullOrEmpty(objDT.Rows[0]["Dimension8"].ToString()))
                    {
                        Label8.Text = objDT.Rows[0]["Dimension8"].ToString();
                    }

                }
                //渲染尺寸表格圖片內容，無圖片時不執行
                if (!String.IsNullOrEmpty(dimensionsImgPathStr))
                {
                    DimensionsImgHtml.Text = $"<td><img alt='{yachtModelStr}' src='Tayanahtml/upload/Images/{dimensionsImgPathStr}' Width='278px' /></td>";
                }
                if (saveRowList?.Count > 2)
                {
                }
                else
                {
                }
                dimensionTable.Visible = true;

                //渲染下方 Downloads 區塊
                if (!String.IsNullOrEmpty(downloadsFilePathStr))
                {
                    DownloadsHtml.Text = $"<a id='HyperLink1' href='Tayanahtml/upload/files/{downloadsFilePathStr}' target='blank' >{downloadsFilePathStr}</a>";      
                }
                else
                {
                    divDownload.Visible = false;
                }
            }
            connection.Close();
        }
        private void loadLeftMenu()
        {
            string urlPathStr = System.IO.Path.GetFileName(Request.PhysicalPath);
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
            LeftMenuHtml.Text = leftMenuHtml.ToString();
        }
        private void loadTopMenu()
        {
            string guidStr = Session["guid"].ToString();
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

                topMenuHtmlStr.Append($"<li><a class='menu_yli01' href='Yachts_OverView.aspx?id={guidStr}' >OverView</a></li>");
                topMenuHtmlStr.Append($"<li><a class='menu_yli02' href='Yachts_Layout.aspx?id={guidStr}' >Layout & deck plan</a></li>");
                topMenuHtmlStr.Append($"<li><a class='menu_yli03' href='Yachts_Specification.aspx?id={guidStr}' >Specification</a></li>");

                saveRowList = JsonConvert.DeserializeObject<List<RowData>>(loadJson);
                if (saveRowList != null)
                {

                }
                LabLink.InnerText = yachtModelStr;
                LabTitle.InnerText = yachtModelStr;
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