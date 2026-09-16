using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace OLDSite
{
    public partial class Account : Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public Control btnLogin { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        //protected void btnLogin_Click()
        //{
        //    string Usernm = UserName.Text;
        //    string Passwd = Password.Text;

        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))

        //        try
        //        {
        //            String str = ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        //            string selectSQL = "SELECT b.DISP, a.QUANTIFIER_IND FROM [mos_Map_Disp] a inner join mos_disp b on a.DISP_ID = b.DISP_ID where QUANTIFIER_IND > 0 and ROLE_ID = " + RoleID;

        //            SqlConnection con = new SqlConnection(str);
        //            SqlCommand cmd = new SqlCommand(selectSQL, con);
        //            SqlDataReader reader;
        //            con.Open();
        //            reader = cmd.ExecuteReader();
        //            //read first line
        //            reader.Read();
        //            if (reader.HasRows == true)
        //            {
        //            }
        //        }
        //        catch
        //        {
        //        }
        


        //}

    }
}