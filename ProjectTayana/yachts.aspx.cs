﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ProjectTayana
{
    public partial class yachts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGallery(); //讀取並渲染上方相簿輪播
                loadLeftMenu(); //讀取並渲染左側型號邊欄
                loadTopMenu(); //讀取並渲染型號內容上方標題及分頁列
            }
        }
        private void loadGallery()
        {
            //建立資料表存資料
            DataTable dataTable = new DataTable();
            //新增表格欄位，預設從 1 開始, 設定欄位名稱
            dataTable.Columns.AddRange(new DataColumn[1] { new DataColumn("ImageUrl") });

            //取得 Session 共用 GUID，Session 物件需轉回字串
            string guidStr = Session["guid"].ToString();
            //依 GUID 取得遊艇輪播圖片資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT bannerImgPathJSON FROM Yacht WHERE guid = @guidStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ImagePath> savePathList = new List<ImagePath>();
            if (reader.Read())
            {
                string loadJson = HttpUtility.HtmlDecode(reader["bannerImgPathJSON"].ToString());
                savePathList = JsonConvert.DeserializeObject<List<ImagePath>>(loadJson);
                if (savePathList != null)
                {
                    foreach (var item in savePathList)
                    {
                        //逐一填入圖片路徑欄位值
                        dataTable.Rows.Add($"upload/Images/{item.SavePath}");
                    }
                }

            }
            connection.Close();

            //輪播圖片必須用 Repeater 送不然 JavaScript 抓不到 HTML 標籤會失敗
            //設定用 Eval 綁定的輪播圖片路徑資料
            RepeaterImg.DataSource = dataTable; //設定資料來源
            RepeaterImg.DataBind(); //刷新圖片資料
        }
        private void loadLeftMenu()
        {
            string urlPathStr = System.IO.Path.GetFileName(Request.PhysicalPath);
            urlPathStr= "Yachts_OverView";
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
                //if(saveRowList != null)
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

        //表格欄位 JSON 資料
        public class RowData
        {
            public string SaveItem { get; set; }
            public string SaveValue { get; set; }
        }

        //型號輪播圖片 JSON 資料
        public class ImagePath
        {
            public string SavePath { get; set; }
        }
    }
}