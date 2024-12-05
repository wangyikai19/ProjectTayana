using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTayana
{
    public partial class NewsContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
            }
        }
        protected void getData()
        {
            String id = Convert.ToString(Request.QueryString["sno"]);

                Dictionary<string, object> aDict = new Dictionary<string, object>();
                aDict.Add("sno", id);
                DataHelper objDH = new DataHelper();
                DataTable objDT = objDH.queryData(@"
            SELECT *
            From Notice N 
            Where ID=@sno", aDict);
                //lb_SDate.Text = "發布日期：" + Convert.ToDateTime(objDT.Rows[0]["CreateDT"]).ToString("yyyy-MM-dd");
                lb_Title.Text = objDT.Rows[0]["Title"].ToString();
                lb_Info.Text = getMark(HttpUtility.HtmlDecode(objDT.Rows[0]["Info"].ToString()));
            Literal1.Text=getMark(HttpUtility.HtmlDecode(objDT.Rows[0]["Info"].ToString()));
        }
        public string getMark(string Data)
        {
            string s = Data;
            int x = s.IndexOf("marker-yellow");
            if (x > 0)
            {
                s = s.Replace("class=\"marker-yellow\"", "class=\"marker-yellow\" style=\"background-color:#fdfd77\"");
            }

            x = s.IndexOf("marker-green");
            if (x > 0)
            {
                s = s.Replace("class=\"marker-green\"", "class=\"marker-green\" style=\"background-color:#63f963\"");
            }

            x = s.IndexOf("marker-pink");
            if (x > 0)
            {
                s = s.Replace("class=\"marker-pink\"", "class=\"marker-pink\" style=\"background-color:#fc7999\"");
            }

            x = s.IndexOf("marker-blue");
            if (x > 0)
            {
                s = s.Replace("class=\"marker-blue\"", "class=\"marker-blue\" style=\"background-color:#72cdfd\"");
            }
            x = s.IndexOf("pen-red");
            if (x > 0)
            {
                s = s.Replace("class=\"pen-red\"", "class=\"pen-red\" style=\"background-color:transparent;color:#e91313\"");
            }
            x = s.IndexOf("pen-green");
            if (x > 0)
            {
                s = s.Replace("class=\"pen-green\"", "class=\"pen-green\" style=\"background-color:transparent;color:#118800\"");
            }
            return s;
        }
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("news.aspx");
        }
    }
}