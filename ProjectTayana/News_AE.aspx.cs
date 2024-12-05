using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTayana
{
    public partial class News_AE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindNews(1);
            }
        }



        protected void btn_delfile2_Click(object sender, EventArgs e)
        {

        }
        protected void bindNews(int page)
        {
            if (page < 1) page = 1;
            int pageRecord = 10;

            String sql = @"Select * from Notice";
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData(sql, aDict);
            Repeater1.DataSource = objDT.DefaultView;
            Repeater1.DataBind();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dealerId = btn.CommandArgument; // 取得傳遞過來的 id

            // 這裡可以進行查詢或其他處理，然後將 id 透過 QueryString 傳遞到 DealerMgt.aspx
            Response.Redirect($"NewsEdit.aspx?id={dealerId}");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dealerId = btn.CommandArgument;
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            aDict.Add("@id", dealerId);
            String sql = @"Delete from Notice where id=@id";
            DataTable objDT = objDH.queryData(sql, aDict);
            Repeater1.DataSource = objDT.DefaultView;
            Repeater1.DataBind();
        }
    }
}