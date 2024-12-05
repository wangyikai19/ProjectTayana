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
    public partial class AreaMgt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDDL(ddl_Country, "");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //1.連線資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            //2.sql語法
            string sql = "INSERT INTO CountrySort (countrySort,initDate) VALUES(@countryName,@initDate)";
            string checkSQL = "SELECT 1 from CountrySort where countrySort=@countryName=";
            //3.創建command物件
            SqlCommand command = new SqlCommand(sql, connection);
            //4.參數化避免攻擊
            command.Parameters.AddWithValue("@countryName", TBoxAddCountry.Text);
            command.Parameters.AddWithValue("@initDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            //5.資料庫連線開啟
            connection.Open();
            //6.執行sql (新增刪除修改)
            command.ExecuteNonQuery(); //無回傳值
                                       //7.資料庫關閉
            connection.Close();
            //畫面渲染
            GridView1.DataBind();
            //DropDownList1.DataBind();
            //清空輸入欄位
            TBoxAddCountry.Text = "";
        }
        private void showDealerList()
        {
            //依下拉選單選取國家的值 (id) 取得地區分類
            string selCountry_id = ddl_Country.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT [Name] FROM Area left join CountrySort on area.countryID=CountrySort.id WHERE CountrySort.id = @selCountry_id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            //取得地區分類
            connection.Open();
            SqlDataReader readerCountry = command.ExecuteReader();
            while (readerCountry.Read())
            {
                string typeStr = readerCountry["Name"].ToString();
                // RadioButtonList 增加方式
                ListItem listItem = new ListItem();
                listItem.Text = typeStr;
                listItem.Value = typeStr;
                RadioButtonList1.Items.Add(listItem);
            }
            connection.Close();
        }
        protected void ddl_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList1.Items.Clear();
            showDealerList();
        }
        protected void ddl_AddDealerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public static void setDDL(System.Web.UI.WebControls.DropDownList ddl, String DefaultString = null)
        {

            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData("  SELECT id,CountrySort from CountrySort", null);

            ddl.DataSource = objDT;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--請選擇--", ""));
        }

        protected void Btn_AddArea_Click1(object sender, EventArgs e)
        {
            //取得下拉選單國家的值 (id)
            string selCountry_id = ddl_Country.SelectedValue;
            //取得輸入欄內的文字
            string areaStr = txt_Area.Text;
            //判斷是否重複用
            bool isRepeat = false;

            //取得地區分類
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = $"SELECT [Name] FROM Area left join CountrySort on area.countryID=CountrySort.id WHERE CountrySort.id= @selCountry_id and [Name]=@selCountry_id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            command.Parameters.AddWithValue("@Name", areaStr);
            connection.Open();
            SqlDataReader readerCountry = command.ExecuteReader();
            while (readerCountry.Read())
            {
                string typeStr = readerCountry["name"].ToString();
                //判斷有無重複名稱
                if (areaStr.Equals(typeStr))
                {
                    isRepeat = true;
                    //重複警告
                    txt_Area.ForeColor = Color.Red;
                    txt_Area.Text = "The area name is repeated!";
                }
            }
            connection.Close();

            //輸入的區域名稱不重複才執行
            if (!isRepeat)
            {
                txt_Area.ForeColor = Color.Black;
                //新增區域
                string sql2 = "INSERT INTO [Area] (countryID, [name]) VALUES(@selCountry_id, @areaStr)";
                SqlCommand command2 = new SqlCommand(sql2, connection);
                command2.Parameters.AddWithValue("@selCountry_id", selCountry_id);
                command2.Parameters.AddWithValue("@areaStr", areaStr);
                connection.Open();
                command2.ExecuteNonQuery();
                connection.Close();

                //畫面渲染
                RadioButtonList1.Items.Clear(); //清掉舊的
                //BtnDelArea.Visible = false;
                //DealerList.Visible = false;
                //LabUploadImg.Visible = false;
                //UpdateDealerListLab.Visible = false;
                showDealerList(); //讀取新的

                //清空輸入欄位
                txt_Area.Text = "";
            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            //取得選取資料的值
            string selAreaStr = RadioButtonList1.SelectedValue;

            //刪除實際圖檔檔案
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT dealerImgPath FROM Dealers WHERE area = @selAreaStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selAreaStr", selAreaStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string imgPath = reader["dealerImgPath"].ToString();
                if (!imgPath.Equals(""))
                {
                    string savePath = Server.MapPath($"~/Tayanahtml/upload/Images/{imgPath}");
                    File.Delete(savePath);
                }
            }
            connection.Close();

            //刪除資料庫該筆資料
            string sqlDel = "DELETE FROM Dealers WHERE area = @selAreaStr";
            SqlCommand commandDel = new SqlCommand(sqlDel, connection);
            commandDel.Parameters.AddWithValue("@selAreaStr", selAreaStr);
            connection.Open();
            commandDel.ExecuteNonQuery();
            connection.Close();

            //畫面渲染
            RadioButtonList1.Items.Clear(); //清掉舊的
            //BtnDelArea.Visible = false;
            //DealerList.Visible = false;
            //LabUploadImg.Visible = false;
            //UpdateDealerListLab.Visible = false;
            showDealerList(); //讀取新的
            txt_Area.ForeColor = Color.Black;
            txt_Area.Text = "";
        }
    }
}