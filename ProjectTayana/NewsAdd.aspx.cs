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
    public partial class NewsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            String errorMessage = "";
            if (txt_Title.Text.Length == 0) errorMessage += "標題字數錯誤\\n";

            //errorMessage非空，傳送錯誤訊息至Client
            if (!String.IsNullOrEmpty(errorMessage))
            {
                Utility.showMessage(Page, "ErrorMessage", errorMessage);
                return;
            }

            Dictionary<string, object> aDict = new Dictionary<string, object>();
            aDict.Add("Title", txt_Title.Text);
            aDict.Add("Info", HttpUtility.HtmlEncode(editor1.Value));
            aDict.Add("CreateDT", Convert.ToDateTime(DateTime.Now));
            DataHelper objDH = new DataHelper();
            string FileName1 = fileup_Document2.FileName;
            string URL = Server.MapPath("/Toolkits") + "/";
            string TkURL_Pic = "/Toolkits" + "/" + FileName1;
            uploadFiles(URL);
            aDict.Add("TkURL_Pic", TkURL_Pic);
            if (RadioButton1.Checked)
            {
                aDict.Add("IsTop", "1");
            }
            else
            {
                aDict.Add("IsTop", "0");
            }

            string OrderSeq = "";
            string OrderSeqV = "";
            string Strsql = @"
            Insert Into Notice(Title,Info,TkURL_Pic,IsTop,CreateDT" + OrderSeq + @") 
            Values(@Title,@Info,@TkURL_Pic,@IsTop,@CreateDT" + OrderSeqV + @") 
            SELECT @@IDENTITY AS 'Identity'";

            DataTable dt = objDH.queryData(Strsql, aDict);


            Response.Write("<script>alert('新增成功!'); </script>");

        }
        protected void uploadFiles(string folderPath)
        {
            Literal lt1 = ((Literal)Master.FindControl("ContentPlaceHolder1").FindControl("lt_file2"));
            FileUpload fu1 = ((FileUpload)Master.FindControl("ContentPlaceHolder1").FindControl("fileup_Document2"));
            if (fu1.HasFile)
            {
                fu1.SaveAs(folderPath + fu1.FileName);
            }
            if (lt1.Visible == false)
            {
                FileInfo fileInfo1 = new FileInfo(folderPath + lt1.Text);
                if (fileInfo1.Exists) fileInfo1.Delete();
            }

        }

        protected void btn_delfile2_Click(object sender, EventArgs e)
        {

        }
    }
}