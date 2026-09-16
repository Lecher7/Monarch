using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLDSite
{
    public partial class ReadMail : System.Web.UI.Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public string CurrUser = System.Web.HttpContext.Current.User.Identity.Name;
        //protected bool LinkVisible { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
        // Because the UserID is stored as an INT, you have to request the string and then
        //   convert it to an INT
        string UserIDs = Request.QueryString["M"].ToString();
        int MatchUserID = Convert.ToInt32(UserIDs);
        lblMatchUser.Text = UserIDs;

            if (Request.IsAuthenticated)
            {
                if (Page.IsPostBack == false)
                {
                    GetCurrentUser();
                    Show_Data();
                }
            }
        }

        protected void ContactMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (((Menu)sender).SelectedItem.Text == "Mail")
            {
                lblMailbox.Text = "Mail";
                //LinkVisible = true;

                //Run the Stored Procedure first
                SqlConnection connection2 = new SqlConnection(strCon1);
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "sp_MailReceivedSummary";
                cmd2.Connection = connection2;

                cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = lblCurrUser.Text;

                connection2.Open();

                var SearchAdapter = new SqlDataAdapter(cmd2);
                var ds = new DataSet();
                SearchAdapter.Fill(ds);

                MailRepeater.DataSource = ds;
                MailRepeater.DataBind();

            }
            if (((Menu)sender).SelectedItem.Text == "Mail Received")
            {
                lblMailbox.Text = "Mail Received";
                //LinkVisible = true;

                //Run the Stored Procedure first
                SqlConnection connection2 = new SqlConnection(strCon1);
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "sp_MailReceived";
                cmd2.Connection = connection2;

                cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = lblCurrUser.Text;

                connection2.Open();

                var SearchAdapter = new SqlDataAdapter(cmd2);
                var ds = new DataSet();
                SearchAdapter.Fill(ds);

                MailRepeater.DataSource = ds;
                MailRepeater.DataBind();

                //Update the Viewed flag
                SqlConnection con = new SqlConnection(strCon1);
                SqlDataAdapter adp = new SqlDataAdapter("update tmpMessaged set MessageViewed=1 where MessagedUserID=@id", con);

                adp.SelectCommand.Parameters.AddWithValue("@id", lblCurrUser.Text);

                DataSet ds2 = new DataSet();
                adp.Fill(ds2);

            }
            if (((Menu)sender).SelectedItem.Text == "Winks Sent")
            {
                lblMailbox.Text = "Winks Sent";
                //LinkVisible = false;

                //Run the Stored Procedure first
                SqlConnection connection2 = new SqlConnection(strCon1);
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "sp_WinkSent";
                cmd2.Connection = connection2;

                cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = lblCurrUser.Text;

                connection2.Open();

                var SearchAdapter = new SqlDataAdapter(cmd2);
                var ds = new DataSet();
                SearchAdapter.Fill(ds);

                MailRepeater.DataSource = ds;
                MailRepeater.DataBind();

            }
            if (((Menu)sender).SelectedItem.Text == "Winks")
            {
                lblMailbox.Text = "Winks";
                //LinkVisible = false;

                //Run the Stored Procedure first
                SqlConnection connection2 = new SqlConnection(strCon1);
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "sp_WinkReceivedSummary";
                cmd2.Connection = connection2;

                cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = lblCurrUser.Text;

                connection2.Open();

                var SearchAdapter = new SqlDataAdapter(cmd2);
                var ds = new DataSet();
                SearchAdapter.Fill(ds);

                MailRepeater.DataSource = ds;
                MailRepeater.DataBind();

                //Update the Viewed flag
                SqlConnection con = new SqlConnection(strCon1);
                SqlDataAdapter adp = new SqlDataAdapter("update tmpWinked set WinkViewed=1 where WinkedUserID=@id", con);

                adp.SelectCommand.Parameters.AddWithValue("@id", lblCurrUser.Text);

                DataSet ds2 = new DataSet();
                adp.Fill(ds2);
            }

        }

        protected void MailRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Show_Data();
        }

        protected void MailRepeater_DataBinding(object sender, RepeaterItemEventArgs e)
        {

        }

        public void Show_Data()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString);
            //string srtOrder = cboSortBy.Text;
            //SqlDataAdapter adp = new SqlDataAdapter("select [ACCT_LIST].*, [ACCT_GRP_LIST].ACCT_GRP from [ACCT_LIST] LEFT JOIN [ACCT_GRP_LIST] on [ACCT_GRP_LIST].ACCT_GRP_PK = [ACCT_LIST].ACCT_GRP_FK ORDER BY " + srtOrder + "", con);
            //
            //SqlDataAdapter adp = new SqlDataAdapter("SELECT T1.*, Mgr.UserName as MessagerName, Mgr.UserID as UserID, Mgr.UserImg1 as MgrImg1, COALESCE(Mgr.UserImg1, 'dflt.jpg') as UserImg, Mgd.UserName as MessagedName, Mgd.UserImg1 as MgdImg1, T1.[Message] [uMessage], CASE WHEN T1.MessageViewed IS NULL THEN 'No' ELSE 'Yes' END as MsgViewed,	CASE WHEN T1.MessageFlag IS NULL THEN 'No' ELSE 'Yes' END as MsgFlagged FROM [dbo].[tmpMessaged] T1 LEFT JOIN [dbo].[tmpUsers] Mgr ON T1.[MessagerUserID] = Mgr.[UserID] LEFT JOIN [dbo].[tmpUsers] Mgd ON T1.[MessagedUserID] = Mgd.[UserID] WHERE (Mgr.UserID = @UserID and Mgd.UserID = @MatchID) OR (Mgr.UserID = @MatchID and Mgd.UserID = @UserID) ORDER BY T1.MessageDate ASC", conn);
            //adp.SelectCommand.Parameters.AddWithValue("@UserID", lblCurrUser.Text);
            //adp.SelectCommand.Parameters.AddWithValue("@MatchID", lblMatchUser.Text);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "sp_AllMail";
            cmd2.Connection = conn;

            cmd2.Parameters.Add("@UserID", SqlDbType.Int).Value = lblCurrUser.Text;
            cmd2.Parameters.Add("@MatchID", SqlDbType.Int).Value = lblMatchUser.Text;

            conn.Open();

            var SearchAdapter = new SqlDataAdapter(cmd2);
            var ds = new DataSet();
            SearchAdapter.Fill(ds);


            DataRow dr = ds.Tables[0].Rows[0];
            if (lblCurrUser.Text == dr["UserID"].ToString())
            {
                lblMailbox.Text = "Correspondence with " + dr["MessagedName"].ToString();
            }
            else
            {
                lblMailbox.Text = "Correspondence with " + dr["MessagerName"].ToString();
            }
            MailRepeater.DataSource = ds;
            MailRepeater.DataBind();
            conn.Close();

            ////Update the Viewed flag
            //SqlConnection con = new SqlConnection(strCon1);
            //SqlDataAdapter adp2 = new SqlDataAdapter("update tmpMessaged set MessageViewed=1 where MessagedUserID=@id", con);

            //adp2.SelectCommand.Parameters.AddWithValue("@id", lblCurrUser.Text);

            //DataSet ds2 = new DataSet();
            //adp2.Fill(ds2);
        }

        public void GetCurrentUser()
        {
            // Get the current logged in user's ID
            using (SqlConnection con2 = new SqlConnection(strCon1))
            using (SqlCommand cmd = new SqlCommand("SELECT UserID FROM vw_tmpUsers WHERE UserName = '" + CurrUser + "'", con2))
            {
                con2.Open();
                using (SqlDataReader DT2 = cmd.ExecuteReader())
                {
                    while (DT2.Read())
                    {
                        lblCurrUser.Text = (DT2["UserID"].ToString()); ;
                    }
                }
            }
        }
    }
}