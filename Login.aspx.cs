using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLDSite
{
    public partial class Login : System.Web.UI.Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public string CurrUser = System.Web.HttpContext.Current.User.Identity.Name;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string Usernm = UserName.Text;
            string Passwd = Password.Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))

                try
                {
                    String str = ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
                    string selectSQL = "SELECT * FROM tmpUsers where UserName = '" + Usernm + "' AND UserPass = '" + Passwd + "'";

                    SqlConnection con = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand(selectSQL, con);
                    SqlDataReader reader;
                    con.Open();
                    reader = cmd.ExecuteReader();
                    //read first line
                    reader.Read();
                    if (reader.HasRows == true)
                    {
                        // TODO: Log in the user...
                        // TODO: Redirect them to the appropriate page
                        reader.Close();

                        //Refresh the user LastLogged time
                        DateTime CurrDate = DateTime.Now;

                        SqlConnection con2 = new SqlConnection(str);
                        SqlDataAdapter adp = new SqlDataAdapter("update tmpUsers set LastLoginDate=@LoginDt where UserName=@id", con);

                        adp.SelectCommand.Parameters.AddWithValue("@LoginDt", CurrDate);
                        adp.SelectCommand.Parameters.AddWithValue("@id", Usernm);

                        DataSet ds2 = new DataSet();
                        adp.Fill(ds2);

                        FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked);
                        Response.Redirect("OLDMain.aspx");
                        Response.End();
                        Response.Clear();

                    }
                    else
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            InvalidCredentialsMessage.Visible = true;

        }
    }
}