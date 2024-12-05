using NetVips;
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

namespace ProjectTayana
{
    public partial class news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindData(1);
        }
        protected void bindData(int page)
        {
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            String sql = "SELECT ROW_NUMBER() OVER (ORDER BY OrderSeq DESC) ROW_NO,* from Notice";
            DataTable objDT = objDH.queryData(sql, aDict);
            StringBuilder newsHtml = new StringBuilder();
            StringBuilder bannerNumHtml = new StringBuilder();
            if (objDT.Rows.Count > 0)
            {
                foreach (DataRow row in objDT.Rows)
                {
                    newsHtml.Append($"<li><div class=\"list01\"><ul><li><div><p><img src={row["TkURL_Pic"]} style='width: 200px;height: 150px;' alt=\"&quot;&quot;\" /></p></div></li><li>  <span>{row["CreateDT"]}</span><br /><a href='newscontent?sno={row["ID"]}'  rel=\"noopener noreferrer\">{row["Title"]}</a></li></ul></div></li>");
                }
            }

             LitNews.Text = newsHtml.ToString();
            //if (page < 1) page = 1;
            //int pageRecord = 5;
            //Dictionary<string, object> aDict = new Dictionary<string, object>();
            //DataHelper objDH = new DataHelper();
            //String sql = "SELECT ROW_NUMBER() OVER (ORDER BY OrderSeq DESC) ROW_NO,* from Notice";

            //DataTable objDT = objDH.queryData(sql, aDict);
            //int maxPageNumber = (objDT.Rows.Count - 1) / pageRecord + 1;
            //if (page > maxPageNumber) page = maxPageNumber;
            //objDT.DefaultView.RowFilter = String.Format("ROW_NO>={0} AND ROW_NO<={1}", (page - 1) * pageRecord + 1, page * pageRecord);
            //rpt_NoticeMore.DataSource = objDT.DefaultView;
            //rpt_NoticeMore.DataBind();
            //ltl_PageNumber.Text = Utility.showPageNumber(objDT.Rows.Count, page, pageRecord);

        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            //int page = 1;
            //int.TryParse(txt_Page.Value, out page);
            //bindData(page);
        }
    }
}