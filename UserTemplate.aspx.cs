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
using System.Web.UI.HtmlControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace OLDSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public string CurrUser = System.Web.HttpContext.Current.User.Identity.Name;
        //int UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Because the UserID is stored as an INT, you have to request the string and then
            //   convert it to an INT
            string UserIDs = Request.QueryString["U"].ToString();
            int UserID = Convert.ToInt32(UserIDs);

            string CurrUser = User.Identity.Name;

            lblMessagingMessages.Visible = false;

            if (!Page.IsPostBack)
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

                ReadPhotoInfo(UserID);
                //rtfLink.HRef = "../frmReportProfile.aspx?U=" + UserID;

                // Load up all the user's info
                using (SqlConnection con = new SqlConnection(strCon1))
                {

                    int User1 = UserID;
                    int User2;

                    if (lblCurrUser.Text == "0")
                    {
                        User2 = 0;
                    }
                    else
                    {
                        User2 = int.Parse(lblCurrUser.Text);
                    }

                    //using (SqlCommand cmd = new SqlCommand("SELECT *, DATEDIFF(hour,UserDOB,GETDATE())/8766 AS UserAge FROM vw_tmpUsers WHERE UserID = " + UserID, con))
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_UserTemplate";
                    cmd.Connection = con;
                    cmd.Parameters.Add("@User1", SqlDbType.Int).Value = User1;
                    cmd.Parameters.Add("@User2", SqlDbType.Int).Value = User2;

                    {
                        con.Open();
                        using (SqlDataReader DT1 = cmd.ExecuteReader())
                        {
                            while (DT1.Read())
                            {
                                lblUserID.Text = UserIDs;
                                //lblCurrUser.Text = CurrUser;
                                lblUserName.Text = (DT1["UserName"].ToString());
                                lblUserAge.Text = (DT1["UserAge"].ToString());
                                lblGender.Text = (DT1["UGender"].ToString());
                                lblCity.Text = (DT1["UserCity"].ToString());
                                lblState.Text = (DT1["MemberState"].ToString());
                                lblCountry.Text = (DT1["UCountry"].ToString());

                                lblUserStatus.Text = (DT1["UStatus"].ToString());
                                lblEthnicity.Text = (DT1["UEthnicity"].ToString());
                                lblBodyType.Text = (DT1["UBodyType"].ToString());
                                lblHeight.Text = (DT1["UHeight"].ToString());
                                lblReligion.Text = (DT1["UReligion"].ToString());

                                lblSmoker.Text = (DT1["USmoking"].ToString());
                                lblDrinker.Text = (DT1["UDrinking"].ToString());
                                lblZodiac.Text = (DT1["UZodiac"].ToString());
                                lblEducation.Text = (DT1["UEducation"].ToString());
                                lblIncome.Text = (DT1["UIncome"].ToString());
                                lblPrompt.Text = (DT1["UserName"].ToString());

                                lblLastViewed.Text = (DT1["LastTimeViewed"].ToString());
                                lblLastWinked.Text = (DT1["LastTimeWinked"].ToString());
                                lblLastMessaged.Text = (DT1["LastTimeMessaged"].ToString());

                                // If these guys aren't filled in, let the default message be visible
                                lblHeadline.Text = (DT1["UserTitle"].ToString());
                                if ((DT1["UserBody"].ToString()) == "")
                                {
                                }
                                else
                                {
                                    lblAboutMe.Text = (DT1["UserBody"].ToString());
                                }

                                if ((DT1["UserAboutMyMatch"].ToString()) == "")
                                {
                                }
                                else
                                {
                                    lblAboutMyMatch.Text = (DT1["UserAboutMyMatch"].ToString());
                                }

                                if ((DT1["UserAfterWork"].ToString()) == "")
                                {
                                }
                                else
                                {
                                    lblAfterWork.Text = (DT1["UserAfterWork"].ToString());
                                }

                                if ((DT1["UserDesertIsle"].ToString()) == "")
                                {
                                }
                                else
                                {
                                    lblDesertIsle.Text = (DT1["UserDesertIsle"].ToString());
                                }

                                if ((DT1["UserFaveArts"].ToString()) == "")
                                {
                                }
                                else
                                {
                                    lblFaveArts.Text = (DT1["UserFaveArts"].ToString());
                                }

                            }
                        }
                    }

                }

                LoadInterests();
                //con.Close;

                // Add to Viewed table, as long as it's an actual user
                if (lblCurrUser.Text != "0")
                {
                    using (SqlConnection con3 = new SqlConnection(strCon1))
                    //using (SqlCommand cmd3 = new SqlCommand("SELECT UserID FROM vw_tmpUsers WHERE UserName = '" + CurrUser + "'", con3))
                    {
                        con3.Open();

                        DateTime CurrDate = DateTime.Now;

                        SqlDataAdapter adp = new SqlDataAdapter("INSERT INTO tmpViewed (ViewerUserID, ViewedUserID, DateViewed) VALUES(@ViewerID, @ViewedID, @CurrDate)", con3);

                        adp.SelectCommand.Parameters.AddWithValue("@ViewerID", lblCurrUser.Text);
                        adp.SelectCommand.Parameters.AddWithValue("@ViewedID", UserID);
                        adp.SelectCommand.Parameters.AddWithValue("@CurrDate", CurrDate);

                        DataSet ds = new DataSet();
                        adp.Fill(ds);

                    }
                }
            }

            LoadNavMenu();
        }

        public void UpdateLoginDate()
        {
            using (SqlConnection con2 = new SqlConnection(strCon1))
            {
                            //Refresh the user LastLogged time
                            DateTime CurrDate = DateTime.Now;

                            //SqlConnection con2 = new SqlConnection(strCon1);
                            SqlDataAdapter adp = new SqlDataAdapter("update tmpUsers set LastLoginDate=@LoginDt where UserName=@id", con2);

                            adp.SelectCommand.Parameters.AddWithValue("@LoginDt", CurrDate);
                            adp.SelectCommand.Parameters.AddWithValue("@id", CurrUser);

                            DataSet ds2 = new DataSet();
                            adp.Fill(ds2);
            }
        }



        public void ReadPhotoInfo(int UserID)
        {
            // Get the current logged in user's ID
            using (SqlConnection con2 = new SqlConnection(strCon1))
            using (SqlCommand cmd = new SqlCommand("SELECT uFileName, PhotoInfo FROM tmpUserPhotos WHERE UserID = '" + UserID + "'", con2))
            {
                //Set up the default image
                igImage1.Src = "ImageCSharp.aspx?FileName=dflt2.jpg";
                igImage2.Src = "ImageCSharp.aspx?FileName=dflt2.jpg";
                igImage3.Src = "ImageCSharp.aspx?FileName=dflt2.jpg";
                igImage4.Src = "ImageCSharp.aspx?FileName=dflt2.jpg";
                igImage5.Src = "ImageCSharp.aspx?FileName=dflt2.jpg";
                igImage6.Src = "ImageCSharp.aspx?FileName=dflt2.jpg";

                con2.Open();
                using (SqlDataReader DT2 = cmd.ExecuteReader())
                {
                    int X = 1;
                    while (DT2.Read())
                    {
                        if (X == 1)
                        {
                            igImage1.Src = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            fbImg1.HRef = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage1.Alt = DT2["PhotoInfo"].ToString();
                            fbImg1.Title = DT2["PhotoInfo"].ToString();
                            igHide1.Visible = true;
                        }
                        if (X == 2)
                        {
                            igImage2.Src = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            fbImg2.HRef = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage2.Alt = DT2["PhotoInfo"].ToString();
                            fbImg2.Title = DT2["PhotoInfo"].ToString();
                            igHide2.Visible = true;
                        }
                        if (X == 3)
                        {
                            igImage3.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            fbImg3.HRef = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage3.Alt = DT2["PhotoInfo"].ToString();
                            fbImg3.Title = DT2["PhotoInfo"].ToString();
                            igHide3.Visible = true;
                        }
                        if (X == 4)
                        {
                            igImage4.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            fbImg4.HRef = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage4.Alt = DT2["PhotoInfo"].ToString();
                            fbImg4.Title = DT2["PhotoInfo"].ToString();
                            igHide4.Visible = true;
                        }
                        if (X == 5)
                        {
                            igImage5.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            fbImg5.HRef = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage5.Alt = DT2["PhotoInfo"].ToString();
                            fbImg5.Title = DT2["PhotoInfo"].ToString();
                            igHide5.Visible = true;
                        }
                        if (X == 6)
                        {
                            igImage6.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            fbImg6.HRef = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage6.Alt = DT2["PhotoInfo"].ToString();
                            fbImg6.Title = DT2["PhotoInfo"].ToString();
                            igHide6.Visible = true;
                        }


                        X = X + 1;
                        
                    }
                }
            }
        }

        protected void ContactMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            // Because the UserID is stored as an INT, you have to request the string and then
            //   convert it to an INT
            string UserIDs = Request.QueryString["U"].ToString();
            int UserID = Convert.ToInt32(UserIDs);

            if (((Menu)sender).SelectedItem.Text == "Wink")
            {
                //First make sure they're not winking at themselves
                string MyID = lblCurrUser.Text;
                string ToID = lblUserID.Text;

                //First check to make sure a user is a member
                if (MyID == "0")
                {
                    lblMessagingMessages.Visible = true;
                    lblMessagingMessages.Text = "You must be a member to wink at someone.";
                    return;
                }

                //First check to make sure a user isn't trying to message themselves
                if (MyID == ToID)
                {
                    lblMessagingMessages.Visible = true;
                    lblMessagingMessages.Text = "That's silly!  Why would you want to wink at yourself??  :o)";
                    return;
                }

                //If you passed, continue processing...
                using (SqlConnection con3 = new SqlConnection(strCon1))
                //using (SqlCommand cmd3 = new SqlCommand("SELECT UserID FROM vw_tmpUsers WHERE UserName = '" + CurrUser + "'", con3))
                {
                    con3.Open();

                    DateTime CurrDate = DateTime.Now;

                    SqlDataAdapter adp = new SqlDataAdapter("INSERT INTO tmpWinked (WinkerUserID, WinkedUserID, DateWinked) VALUES(@WinkerID, @WinkedID, @CurrDate)", con3);

                    adp.SelectCommand.Parameters.AddWithValue("@WinkerID", lblCurrUser.Text);
                    adp.SelectCommand.Parameters.AddWithValue("@WinkedID", UserID);
                    adp.SelectCommand.Parameters.AddWithValue("@CurrDate", CurrDate);

                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    lblMessagingMessages.Visible = true;
                    lblMessagingMessages.Text = "Congratulations!  You have sent " + lblUserName.Text + " a wink.";
                    UpdateLoginDate();
                }
                return;
            }
            if (((Menu)sender).SelectedItem.Text == "Add To Favorites")
            {
                //First make sure they're not adding themselves to their favorites
                string MyID = lblCurrUser.Text;
                string ToID = lblUserID.Text;

                //First check to make sure a user is a member
                if (MyID == "0")
                {
                    lblMessagingMessages.Visible = true;
                    lblMessagingMessages.Text = "You must be a member to add a favorite.";
                    return;
                }

                //First check to make sure a user isn't trying to message themselves
                if (MyID == ToID)
                {
                    lblMessagingMessages.Visible = true;
                    lblMessagingMessages.Text = "That's silly!  Why would you want to favorite yourself??  :o)";
                    return;
                }

                //If they passed, keep processing...
                using (SqlConnection con3 = new SqlConnection(strCon1))
                //using (SqlCommand cmd3 = new SqlCommand("SELECT UserID FROM vw_tmpUsers WHERE UserName = '" + CurrUser + "'", con3))
                {
                    con3.Open();

                    DateTime CurrDate = DateTime.Now;

                    SqlDataAdapter adp = new SqlDataAdapter("INSERT INTO tmpFaved (FaverUserID, FavedUserID, DateFaved) VALUES(@FaverID, @FavedID, @CurrDate)", con3);

                    adp.SelectCommand.Parameters.AddWithValue("@FaverID", lblCurrUser.Text);
                    adp.SelectCommand.Parameters.AddWithValue("@FavedID", UserID);
                    adp.SelectCommand.Parameters.AddWithValue("@CurrDate", CurrDate);

                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    lblMessagingMessages.Visible = true;
                    lblMessagingMessages.Text = "Congratulations!  You have added " + lblUserName.Text + " to your Favorites list.";
                    UpdateLoginDate();
                }
                return;
            }
        }

        protected void LoadNavMenu()
        {
            //MenuItem itemEmail = ContactMenu.FindItem("Email");
            //itemEmail.NavigateUrl = "~/UserEmail.aspx?U=" + lblUserID.Text;

            //MenuItem itemWink = ContactMenu.FindItem("Wink");
            //itemWink.NavigateUrl = "~/UserWink.aspx?U=" + lblUserID.Text;

            //MenuItem itemMessage = ContactMenu.FindItem("Message");
            //itemMessage.NavigateUrl = "~/UserMessage.aspx?U=" + lblUserID.Text;

            //MenuItem itemChat = ContactMenu.FindItem("Chat");
            //itemChat.NavigateUrl = "~/UserChat.aspx?U=" + lblUserID.Text;

            //MenuItem itemFave = ContactMenu.FindItem("Add To Favorites");
            //itemFave.NavigateUrl = "~/UserFaveAdd.aspx?U=" + lblUserID.Text;
        }

        protected void LoadInterests()
        {
           
            //Fill Interests based on table values
            string strSQL2 = "SELECT UM.MatchValue,	DD.DDLValue FROM tmpUsermatch UM ";
            strSQL2 = strSQL2 + "INNER JOIN (SELECT StoredValue, DDLValue FROM tmpDropdowns WHERE ddlName = 'ddlInterests') DD ";
	        strSQL2 = strSQL2 + "ON UM.MatchValue = DD.StoredValue ";
            strSQL2 = strSQL2 + "WHERE MatchField = 'MatchInterests'  AND UserID = '" + lblUserID.Text + "'";
            using (var con = new SqlConnection(strCon1))
            using (var adapter2 = new SqlDataAdapter(strSQL2, con))
            {
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                foreach (DataRow row in dt2.Rows)
                {
                    Label dynamicLabel = new Label();
                    dynamicLabel.ID = "lbl" + row["DDLValue"].ToString();
                    dynamicLabel.Text = row["DDLValue"].ToString();
                    dynamicLabel.CssClass = "lbl interests";
                    div1.Controls.Add(dynamicLabel);
                }
            }
        }

        protected void btnPopup_Click(object sender, EventArgs e)
        {
                //onSubmit();
                rlblUserID.Text = lblUserID.Text;
                rlblUserName.Text = lblUserName.Text;
                MdlCommentsExtender.Enabled = true;
                MdlCommentsExtender.Show();
                ScriptManager.GetCurrent(this).SetFocus(this.txtCommentBox);
        }

 
        protected void mdlCommentsOk_Click(object sender, EventArgs e)
        {
                //clearconfirm();
                //ModalPopupExtender1.Hide();
                //hfCommentBox.Value = txtCommentBox.Text;
                MdlCommentsExtender.Enabled = false;
                //TreeView1_SelectedNodeChanged1(sender, e);
        }

        protected void mdlCommentsCancel_Click(object sender, EventArgs e)
        {
            //clearconfirm();
            //ModalPopupExtender1.Hide();
            //hfCommentBox.Value = txtCommentBox.Text;
            MdlCommentsExtender.Enabled = false;
            //TreeView1_SelectedNodeChanged1(sender, e);
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            // Because the UserID is stored as an INT, you have to request the string and then
            //   convert it to an INT
            string UserIDs = Request.QueryString["U"].ToString();
            int UserID = Convert.ToInt32(UserIDs);

            string MyID = lblCurrUser.Text;
            string ToID = lblUserID.Text;

            //First check to make sure a user is a member
            if (MyID == "0")
            {
                lblMessagingMessages.Visible = true;
                lblMessagingMessages.Text = "You must be a member to message someone.";
                return;
            }

            //First check to make sure a user isn't trying to message themselves
            if (MyID == ToID)
            {
                lblMessagingMessages.Visible = true;
                lblMessagingMessages.Text = "That's silly!  Why would you want to message yourself??  :o)";
                return;
            }

            //First check sp_MutualWink to make sure a message is allowed to be sent
            //Run the Stored Procedure first
            SqlConnection connection2 = new SqlConnection(strCon1);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "sp_MutualWink";
            cmd2.Connection = connection2;

            // Now add the parameters for the SProc
            cmd2.Parameters.Add("@User1", SqlDbType.Int).Value = MyID;
            cmd2.Parameters.Add("@User2", SqlDbType.Int).Value = ToID;

            connection2.Open();

            using (SqlDataReader DT1 = cmd2.ExecuteReader())
            {
                // If the SQL returns any records, process the info
                if (!DT1.HasRows)
                {
                    lblMessagingMessages.Visible = true;
                    lblMessagingMessages.Text = "We're sorry.  :o(  You do not currently have a Mutual Wink with " + lblUserName.Text + ".  Give them a wink and see if they'll wink back!";
                    return;
                }
            }

            //Send message 
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_MessageUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            cmd.Parameters.Add("@MyID", SqlDbType.Int).Value = MyID;
                            cmd.Parameters.Add("@ToID", SqlDbType.Int).Value = ToID;
                            cmd.Parameters.Add("@Message", SqlDbType.Char).Value = SendEmail.Text;
                        conn.Open();
                        //  returnValue = (int)cmd.ExecuteScalar();

                        Console.WriteLine(cmd.ToString());
                        cmd.ExecuteNonQuery();

                    }
                    lblErrorMsg.Text = "Your message has been sent!" ;
                    lblErrorMsg.Visible = true;
                    SendEmail.Text = "";
                    UpdateLoginDate();
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                    lblErrorMsg.Visible = true;

                }
            }
        }
    }
}