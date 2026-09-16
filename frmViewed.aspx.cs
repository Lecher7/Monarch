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
    public partial class frmViewed : System.Web.UI.Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public string CurrUser = System.Web.HttpContext.Current.User.Identity.Name;
        protected bool LinkVisible { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblCurrUser.Text = Convert.ToString("0");
            if (Request.IsAuthenticated)
            {
                if (Page.IsPostBack == false)
                {
                    lblMailbox.Text = "Viewed By Others";
                    GetCurrentUser();
                    Show_Data();
                }
            }
        }

        protected void ContactMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (((Menu)sender).SelectedItem.Text == "Users Who I Viewed")
            {
                lblMailbox.Text = "Users Who I Viewed";
                LinkVisible = true;

                int UserID;

                if (lblCurrUser.Text == "0")
                {
                    UserID = 0;
                }
                else
                {
                    UserID = int.Parse(lblCurrUser.Text);
                }

                //Run the Stored Procedure first
                SqlConnection connection2 = new SqlConnection(strCon1);
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "sp_ViewedByMe";
                cmd2.Connection = connection2;

                cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = UserID;

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
                LinkVisible = true;

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

                ////Update the Viewed flag
                //SqlConnection con = new SqlConnection(strCon1);
                //SqlDataAdapter adp = new SqlDataAdapter("update tmpMessaged set MessageViewed=1 where MessagedUserID=@id", con);

                //adp.SelectCommand.Parameters.AddWithValue("@id", lblCurrUser.Text);

                //DataSet ds2 = new DataSet();
                //adp.Fill(ds2);

            }
            if (((Menu)sender).SelectedItem.Text == "Winks Sent")
            {
                lblMailbox.Text = "Winks Sent";
                LinkVisible = false;

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
            if (((Menu)sender).SelectedItem.Text == "Users Who Viewed Me")
            {
                lblMailbox.Text = "Users Who Viewed Me";
                LinkVisible = false;

                int UserID;

                if (lblCurrUser.Text == "0")
                {
                    UserID = 0;
                }
                else
                {
                    UserID = int.Parse(lblCurrUser.Text);
                }

                //Run the Stored Procedure first
                SqlConnection connection2 = new SqlConnection(strCon1);
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "sp_ViewedByOthers";
                cmd2.Connection = connection2;

                cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = UserID;

                connection2.Open();

                var SearchAdapter = new SqlDataAdapter(cmd2);
                var ds = new DataSet();
                SearchAdapter.Fill(ds);

                MailRepeater.DataSource = ds;
                MailRepeater.DataBind();

                ////Update the Viewed flag
                //SqlConnection con = new SqlConnection(strCon1);
                //SqlDataAdapter adp = new SqlDataAdapter("update tmpWinked set WinkViewed=1 where WinkedUserID=@id", con);

                //adp.SelectCommand.Parameters.AddWithValue("@id", lblCurrUser.Text);

                //DataSet ds2 = new DataSet();
                //adp.Fill(ds2);
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
            lblMailbox.Text = "Users Who Viewed Me";
            LinkVisible = true;
            //Run the Stored Procedure first
            SqlConnection connection2 = new SqlConnection(strCon1);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "sp_ViewedByOthers";
            cmd2.Connection = connection2;

            cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = lblCurrUser.Text;

            connection2.Open();

            var SearchAdapter = new SqlDataAdapter(cmd2);
            var ds = new DataSet();
            SearchAdapter.Fill(ds);

            MailRepeater.DataSource = ds;
            MailRepeater.DataBind();
            connection2.Close();



            ////Update the Viewed flag
            //SqlConnection con = new SqlConnection(strCon1);
            //SqlDataAdapter adp2 = new SqlDataAdapter("update tmpMessaged set MessageViewed=1 where MessagedUserID=@id", con);

            //adp2.SelectCommand.Parameters.AddWithValue("@id", lblCurrUser.Text);

            //DataSet ds2 = new DataSet();
            //adp2.Fill(ds2);
            //con.Close();
        }

        public void GetCurrentUser()
        {
            try
            {
                lblCurrUser.Text = Convert.ToString("0");
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
            catch
            {
            }
        }
    }
}