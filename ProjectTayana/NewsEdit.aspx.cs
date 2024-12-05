using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTayana
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                bindData(id);
            }
        }
        protected void bindData(string id)
        {
            String sql = @"SELECT * from Notice where ID=@ID ";
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            aDict.Add("@ID", id);
            DataTable objDT = objDH.queryData(sql, aDict);
            if (objDT.Rows.Count > 0)
            {
                lb_ID.Text = objDT.Rows[0]["ID"].ToString();
                txt_Title.Text = objDT.Rows[0]["Title"].ToString();
                if (!string.IsNullOrEmpty(objDT.Rows[0]["Info"].ToString()))
                {
                    editor1.Value = Convert.ToString(objDT.Rows[0]["Info"]).Replace("font-family:\"新細明體\",serif;", "");
                    editor1.Value = Convert.ToString(editor1.Value.Replace("font-family:\"微軟正黑體\",sans-serif;", ""));
                    editor1.Value = Convert.ToString(editor1.Value.Replace("roman\"; mso-bidi-font-size:12.0pt; mso-font-kerning:0pt; \"", ""));
                    editor1.Value = Convert.ToString(editor1.Value.Replace("mso-bidi-font-family:", ""));
                    editor1.Value = Convert.ToString(editor1.Value.Replace("Times New Roman", ""));
                    editor1.Value = Convert.ToString(editor1.Value.Replace(";mso-bidi-font-size:12.0pt;mso-font-kerning:0pt;", ""));
                    editor1.Value = Convert.ToString(editor1.Value.Replace("\"\"", ""));
                    editor1.Value = HttpUtility.HtmlDecode(editor1.Value);
                }
                Image1.ImageUrl = $"{objDT.Rows[0]["TkURL_Pic"]}";
            }
        }

        protected void btn_UpdateNews_Click(object sender, EventArgs e)
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
            string Strsql = @"
            update Notice set Title=@Title,Info=@Info,CreateDT=@CreateDT";
            if(fileup_Document2.FileName != null && fileup_Document2.FileName != "")
            {
                string FileName1 = fileup_Document2.FileName;
                string URL = Server.MapPath(" /Toolkits") + "/";
                string TkURL_Pic = "/Toolkits" + "/" + FileName1;
                uploadFiles(URL);
                aDict.Add("TkURL_Pic", TkURL_Pic);
                Strsql += @",TkURL_Pic=@TkURL_Pic";
            }
           

            aDict.Add("ID", lb_ID.Text);
            Strsql += @" where ID=@ID";
            DataTable dt = objDH.queryData(Strsql, aDict);


            Response.Write("<script>alert('修改成功!'); </script>");
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
        protected void UploadImgBtn_Click(object sender, EventArgs e)
        {

        }

        protected void btn_delfile2_Click(object sender, EventArgs e)
        {

        }
    }
}