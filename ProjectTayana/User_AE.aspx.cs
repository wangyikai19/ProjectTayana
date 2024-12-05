using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Konscious.Security.Cryptography;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace ProjectTayana
{
    public partial class User_AE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindUser();
            }
        }
        protected void bindUser()
        {
            String sql = @"SELECT * from [User]";
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            DataTable objDT = objDH.queryData(sql, aDict);
            Repeater1.DataSource = objDT.DefaultView;
            Repeater1.DataBind();
        }
        protected void AddUser_Click(object sender, EventArgs e)
        {
            String errorMessage = "";
            if (Account.Text.Length == 0) errorMessage += "帳號欄位為必填\\n";
            if (Password.Text.Length == 0) errorMessage += "密碼欄位為必填\\n";
            //errorMessage非空，傳送錯誤訊息至Client
            if (!String.IsNullOrEmpty(errorMessage))
            {
                Utility.showMessage(Page, "ErrorMessage", errorMessage);
                return;
            }
            bool haveSameAccount = false;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString);
            string sqlCheck = "SELECT * FROM [User] WHERE account = @account";
            string sqlAdd = "INSERT INTO [User] (account, password, salt) VALUES(@account, @password, @salt)";
            SqlCommand commandCheck = new SqlCommand(sqlCheck, connection);
            SqlCommand commandAdd = new SqlCommand(sqlAdd, connection);

            //檢查有無重複帳號
            commandCheck.Parameters.AddWithValue("@account", Account.Text);
            connection.Open();
            SqlDataReader readerCountry = commandCheck.ExecuteReader();
            if (readerCountry.Read())
            {
                haveSameAccount = true;
                LabelAdd.Visible = true; //帳號重複通知
            }
            connection.Close();

            //無重複帳號才執行加入
            if (!haveSameAccount)
            {
                //Hash 加鹽加密
                string password = Password.Text;
                var salt = CreateSalt();
                string saltStr = Convert.ToBase64String(salt); //將 byte 改回字串存回資料表
                var hash = HashPassword(password, salt);
                string hashPassword = Convert.ToBase64String(hash);

                commandAdd.Parameters.AddWithValue("@account", Account.Text);
                commandAdd.Parameters.AddWithValue("@password", hashPassword);
                commandAdd.Parameters.AddWithValue("@salt", saltStr);

                connection.Open();
                commandAdd.ExecuteNonQuery();
                connection.Close();
                //畫面渲染
                bindUser();
                //清空輸入欄位
                Account.Text = "";
                Password.Text = "";
                LabelAdd.Visible = false;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dealerId = btn.CommandArgument; // 取得傳遞過來的 id
            Dictionary<string, object> aDict = new Dictionary<string, object>();
            DataHelper objDH = new DataHelper();
            aDict.Add("@ID", dealerId);
            DataTable objDT = objDH.queryData(@"Delete  from [User] where ID=@ID", aDict);
            Response.Redirect($"User_AE.aspx?");
        }
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        // Hash 處理加鹽的密碼功能
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            //底下這些數字會影響運算時間，而且驗證時要用一樣的值
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // 4 核心就設成 8
            argon2.Iterations = 4; // 迭代運算次數
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }
    }
}