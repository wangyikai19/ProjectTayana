using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTayana
{
    public partial class Web : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getGuid();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void getGuid()
        {
            //取得網址傳值的型號對應 GUID
            string guidStr = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sql = "SELECT TOP 1 guid FROM Yacht";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //如果無網址傳值就用第一筆遊艇型號的 GUID
                if (String.IsNullOrEmpty(guidStr))
                {
                    guidStr = reader["guid"].ToString().Trim();
                }
            }
            connection.Close();
            //將 GUID 存入 Session 供上方列表共用
            Session["guid"] = guidStr;
        }
    }
}