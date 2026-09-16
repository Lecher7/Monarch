using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Account
{
    public partial class Manage : Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public string CurrUser = System.Web.HttpContext.Current.User.Identity.Name;
        public string MyPath = "D:/Monarch/Images/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
                LoadCountries();
                LoadStates();
                LoadUserGender();
                LoadMatchGender();
                LoadGoal();
                LoadIntent();
                LoadStatus();
                LoadEducation();
                LoadOccupation();
                LoadIncome();
                LoadChildren();
                LoadPets();
                LoadHeight();
                LoadBodyType();
                LoadHairColor();
                LoadEyeColor();
                LoadDrinking();
                LoadSmoking();
                LoadEthnicity();
                LoadReligion();
                LoadZodiac();
                LoadRelationship();
                LoadInterests();

                LoadUser();
                ReadPhotoInfo();
                //sCountry.SelectedValue = "US";
                //MyGender.SelectedValue = "M";
                //MatchGender.SelectedValue = "F";
                //Email.Attributes["type"] = "email";
                LoadCities_Leave('x',e);
            }
            else
            {

            }
        }

        protected void LoadUser()
        {
            // Get the current logged in user's ID
            using (SqlConnection con2 = new SqlConnection(strCon1))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM vw_tmpUsers WHERE UserName = '" + CurrUser + "'", con2))
            {
                con2.Open();
                using (SqlDataReader DT2 = cmd.ExecuteReader())
                {
                    while (DT2.Read())
                    {
                        UserName.Text = (DT2["UserName"].ToString());
                        txtUserID.Text = (DT2["UserID"].ToString());
                        Email.Text = (DT2["UserEmail"].ToString());
                        FName.Text = (DT2["FName"].ToString());
                        sCountry.SelectedValue = (DT2["UserCountry"].ToString());
                        sState.SelectedValue = (DT2["UserState"].ToString());
                        City.SelectedValue = (DT2["UserCity"].ToString());
                        Zipcode.Text = (DT2["UserZip"].ToString());
                        DOB.Text = (DT2["UserDOB"].ToString());
                        MyGender.SelectedValue = (DT2["UserGender"].ToString());
                        //MatchGender.SelectedValue = (DT2["UserCountry"].ToString());
                        Goal.SelectedValue = (DT2["UserGoal"].ToString());
                        Intent.SelectedValue = (DT2["UserIntent"].ToString());
                        uStatus.SelectedValue = (DT2["UserStatus"].ToString());
                        Education.SelectedValue = (DT2["UserEducation"].ToString());
                        Occupation.SelectedValue = (DT2["UserOccupation"].ToString());
                        Income.SelectedValue = (DT2["UserIncome"].ToString());
                        Children.SelectedValue = (DT2["UserChildren"].ToString());
                        //Pets.SelectedValue = (DT2["UserPet"].ToString());
                        MyHeight.SelectedValue = (DT2["UserHeight"].ToString());
                        BodyType.SelectedValue = (DT2["UserBodyType"].ToString());
                        HairColor.SelectedValue = (DT2["UserHairColor"].ToString());
                        EyeColor.SelectedValue = (DT2["UserEyeColor"].ToString());
                        Drinking.SelectedValue = (DT2["UserDrinking"].ToString());
                        Smoking.SelectedValue = (DT2["UserSmoking"].ToString());
                        Ethnicity.SelectedValue = (DT2["UserEthnicity"].ToString());
                        Religion.SelectedValue = (DT2["UserReligion"].ToString());
                        Zodiac.SelectedValue = (DT2["UserZodiac"].ToString());
                        Relationships.SelectedValue = (DT2["UserRelationship"].ToString());
                        //Interests.SelectedValue = (DT2["UserCountry"].ToString());

                        UserTitle.Text = (DT2["UserTitle"].ToString());
                        UserBody.Text = (DT2["UserBody"].ToString());
                        UserAboutMyMatch.Text = (DT2["UserAboutMyMatch"].ToString());
                        UserAfterWork.Text = (DT2["UserAfterWork"].ToString());
                        UserDesertIsle.Text = (DT2["UserDesertIsle"].ToString());
                        UserFaveArts.Text = (DT2["UserFaveArts"].ToString());
                        Password.Text = (DT2["UserPass"].ToString());

                        //Disable the Zodiac dropdown
                        Zodiac.Attributes.Add("disabled", "true");

                        //Fill MatchGender based on table values
                        string strSQL = "SELECT MatchValue FROM tmpUsermatch WHERE MatchField = 'MatchGender' AND UserID = '" + (DT2["UserID"].ToString()) + "'";
                        MatchGender.SelectionMode = ListSelectionMode.Multiple;
                        using (var con = new SqlConnection(strCon1))
                        using (var adapter = new SqlDataAdapter(strSQL, con))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                for (int i = 0; i < MatchGender.Items.Count; i++)
                                {
                                    if (row["MatchValue"].ToString() == MatchGender.Items[i].Value)
                                    {
                                        MatchGender.Items[i].Selected = true;
                                    }
                                }
                            }
                        }

                        //Fill MatchPets based on table values
                        string strSQL1 = "SELECT MatchValue FROM tmpUsermatch WHERE MatchField = 'MatchPets' AND UserID = '" + (DT2["UserID"].ToString()) + "'";
                        Pets.SelectionMode = ListSelectionMode.Multiple;
                        using (var con = new SqlConnection(strCon1))
                        using (var adapter1 = new SqlDataAdapter(strSQL1, con))
                        {
                            DataTable dt1 = new DataTable();
                            adapter1.Fill(dt1);
                            foreach (DataRow row in dt1.Rows)
                            {
                                for (int i = 0; i < Pets.Items.Count; i++)
                                {
                                    if (row["MatchValue"].ToString() == Pets.Items[i].Value)
                                    {
                                        Pets.Items[i].Selected = true;
                                    }
                                }
                            }
                        }

                        //Fill Interests based on table values
                        string strSQL2 = "SELECT MatchValue FROM tmpUsermatch WHERE MatchField = 'MatchInterests' AND UserID = '" + (DT2["UserID"].ToString()) + "'";
                        Interests.SelectionMode = ListSelectionMode.Multiple;
                        using (var con = new SqlConnection(strCon1))
                        using (var adapter2 = new SqlDataAdapter(strSQL2, con))
                        {
                            DataTable dt2 = new DataTable();
                            adapter2.Fill(dt2);
                            foreach (DataRow row in dt2.Rows)
                            {
                                for (int i = 0; i < Interests.Items.Count; i++)
                                {
                                    if (row["MatchValue"].ToString() == Interests.Items[i].Value)
                                    {
                                        Interests.Items[i].Selected = true;
                                    }
                                }
                            }
                        }


                    }
                }
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(MyPath + txtUserID.Text + "[" + fileName);
                WritePhotoInfo(fileName);
                ReadPhotoInfo();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        public void WritePhotoInfo(string FN)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd2 = new SqlCommand("sp_WritePhotoInfo", conn))
                    {
                        //Run the Stored Procedure first
                        //SqlConnection connection2 = new SqlConnection(strCon1);
                        //SqlCommand cmd2 = new SqlCommand();
                        cmd2.CommandType = CommandType.StoredProcedure;
                        //cmd2.CommandText = "sp_WritePhotoInfo";
                        cmd2.Connection = conn;

                        cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = txtUserID.Text;
                        cmd2.Parameters.Add("@FileName", SqlDbType.VarChar).Value = txtUserID.Text + '[' + FN;
                        cmd2.Parameters.Add("@PhotoInfo", SqlDbType.VarChar).Value = txtPhotoInfo.Text;

                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        //var SearchAdapter = new SqlDataAdapter(cmd2);
                        //var ds = new DataSet();
                        //SearchAdapter.Fill(ds);

                        conn.Close();

                        lblErrorMsg.Text = "Complete!";
                        lblErrorMsg.Visible = true;
                    }
                }

                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                    lblErrorMsg.Visible = true;

                }
            }
        }

        public void ReadPhotoInfo()
        {
            // Get the current logged in user's ID
            using (SqlConnection con2 = new SqlConnection(strCon1))
            using (SqlCommand cmd = new SqlCommand("SELECT uFileName, PhotoInfo FROM tmpUserPhotos WHERE UserID = '" + txtUserID.Text + "'", con2))
            {
                //Set up the default image
                igImage1.Src = "ImageCSharp.aspx?FileName=dflt.jpg";
                igImage2.Src = "ImageCSharp.aspx?FileName=dflt.jpg";
                igImage3.Src = "ImageCSharp.aspx?FileName=dflt.jpg";
                igImage4.Src = "ImageCSharp.aspx?FileName=dflt.jpg";
                igImage5.Src = "ImageCSharp.aspx?FileName=dflt.jpg";
                igImage6.Src = "ImageCSharp.aspx?FileName=dflt.jpg";

                con2.Open();
                using (SqlDataReader DT2 = cmd.ExecuteReader())
                {
                    int X = 1;
                    while (DT2.Read())
                    {
                        if (X == 1)
                        {
                            igImage1.Src = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage1.Alt = DT2["PhotoInfo"].ToString();
                            igHide1.Visible = true;
                        }
                        if (X == 2)
                        {
                            igImage2.Src = "ImageCSharp.aspx?FileName=" + DT2["uFileName"].ToString();
                            igImage2.Alt = DT2["PhotoInfo"].ToString();
                            igHide2.Visible = true;
                        }
                        if (X == 3)
                        {
                            igImage3.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            igImage3.Alt = DT2["PhotoInfo"].ToString();
                            igHide3.Visible = true;
                        }
                        if (X == 4)
                        {
                            igImage4.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            igImage4.Alt = DT2["PhotoInfo"].ToString();
                            igHide4.Visible = true;
                        }
                        if (X == 5)
                        {
                            igImage5.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            igImage5.Alt = DT2["PhotoInfo"].ToString();
                            igHide5.Visible = true;
                        }
                        if (X == 6)
                        {
                            igImage6.Src = "ImageCSharp.aspx?FileName=" + "[" + DT2["uFileName"].ToString();
                            igImage6.Alt = DT2["PhotoInfo"].ToString();
                            igHide6.Visible = true;
                        }


                        X = X + 1;
                    }
                }
            }
        }

        protected void btnChgPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/ChangePassword.aspx");
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (!OpenAuth.IsLocalUrl(continueUrl))
            //{
            //    continueUrl = "~/";
            //}
            //Response.Redirect(continueUrl);
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sCountry.SelectedValue == "US")
            {
                LoadStates();
            }
            else
            {
                sState.DataSource = "";
                sState.DataBind();
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlUserGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlMatchGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            lblErrorMsg.Visible = false;

            //Check all inputs
            //if (DOB.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out a birth date");
            //    return;
            //}
            //else if (UserName.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out a UserName");
            //    return;
            //}
            //else if (Email.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out an Email address");
            //    return;
            //}
            //else if (Zipcode.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out a Zip Code");
            //    return;
            //}
            //else if (UserTitle.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out a Headline");
            //    return;
            //}
            //else if (UserBody.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out the 'A Little About Me' section");
            //    return;
            //}
            //else if (UserAboutMyMatch.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out the 'About My Match' section");
            //    return;
            //}
            //else if (UserAfterWork.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out the 'Once Work Is Done' section");
            //    return;
            //}
            //else if (UserDesertIsle.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out the 'Desert Island Possessions' section");
            //    return;
            //}
            //else if (UserFaveArts.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out the 'Favorite Movies/Music' section");
            //    return;
            //}
            //else if (Password.Text == "")
            //{
            //    UnsuccessfulReg("Please fill out a password");
            //    return;
            //}
            //else if (Password.Text != ConfirmPassword.Text)
            //{
            //    UnsuccessfulReg("Make sure your password is confirmed!");
            //    return;
            //}
            //else
            //{
            //}

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        var selectedMatchGender = MatchGender.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
                        string strMatchGender = String.Join(",", selectedMatchGender).TrimEnd();

                        var selectedPets = Pets.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
                        string strPets = String.Join(",", selectedPets).TrimEnd();

                        var selectedInterests = Interests.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
                        string strInterests = String.Join(",", selectedInterests).TrimEnd();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                            cmd.Parameters.Add("@UserID", SqlDbType.Char).Value = txtUserID.Text;
                            cmd.Parameters.Add("@UserName", SqlDbType.Char).Value = UserName.Text;
                            cmd.Parameters.Add("@Email", SqlDbType.Char).Value = Email.Text;
                            cmd.Parameters.Add("@FName", SqlDbType.Char).Value = FName.Text;
                            cmd.Parameters.Add("@Country", SqlDbType.Char).Value = sCountry.SelectedValue;
                            cmd.Parameters.Add("@uState", SqlDbType.Char).Value = sState.SelectedValue;
                            cmd.Parameters.Add("@City", SqlDbType.Char).Value = City.SelectedValue;
                            cmd.Parameters.Add("@Zipcode", SqlDbType.Char).Value = Zipcode.Text;
                            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DOB.Text;
                            cmd.Parameters.Add("@UserGender", SqlDbType.Char).Value = MyGender.SelectedValue;
                            cmd.Parameters.Add("@MatchGender", SqlDbType.Char).Value = strMatchGender;

                            cmd.Parameters.Add("@Goal", SqlDbType.Char).Value = Goal.SelectedValue;
                            cmd.Parameters.Add("@Intent", SqlDbType.Char).Value = Intent.SelectedValue;
                            cmd.Parameters.Add("@uStatus", SqlDbType.Char).Value = uStatus.SelectedValue;
                            cmd.Parameters.Add("@Education", SqlDbType.Char).Value = Education.SelectedValue;
                            cmd.Parameters.Add("@Occupation", SqlDbType.Char).Value = Occupation.SelectedValue;
                            cmd.Parameters.Add("@Income", SqlDbType.Char).Value = Income.SelectedValue;
                            cmd.Parameters.Add("@Children", SqlDbType.Char).Value = Children.SelectedValue;
                            cmd.Parameters.Add("@Pets", SqlDbType.Char).Value = strPets;
                            cmd.Parameters.Add("@MyHeight", SqlDbType.Char).Value = MyHeight.SelectedValue;
                            cmd.Parameters.Add("@BodyType", SqlDbType.Char).Value = BodyType.SelectedValue;
                            cmd.Parameters.Add("@HairColor", SqlDbType.Char).Value = HairColor.SelectedValue;
                            cmd.Parameters.Add("@EyeColor", SqlDbType.Char).Value = EyeColor.SelectedValue;
                            cmd.Parameters.Add("@Drinking", SqlDbType.Char).Value = Drinking.SelectedValue;
                            cmd.Parameters.Add("@Smoking", SqlDbType.Char).Value = Smoking.SelectedValue;
                            cmd.Parameters.Add("@Ethnicity", SqlDbType.Char).Value = Ethnicity.SelectedValue;
                            cmd.Parameters.Add("@Religion", SqlDbType.Char).Value = Religion.SelectedValue;
                            cmd.Parameters.Add("@Relationships", SqlDbType.Char).Value = Relationships.SelectedValue;
                            cmd.Parameters.Add("@Interests", SqlDbType.Char).Value = strInterests;

                            cmd.Parameters.Add("@UserTitle", SqlDbType.Char).Value = UserTitle.Text;
                            cmd.Parameters.Add("@UserBody", SqlDbType.Char).Value = UserBody.Text;
                            cmd.Parameters.Add("@UserAboutMyMatch", SqlDbType.Char).Value = UserAboutMyMatch.Text;
                            cmd.Parameters.Add("@UserAfterWork", SqlDbType.Char).Value = UserAfterWork.Text;
                            cmd.Parameters.Add("@UserDesertIsle", SqlDbType.Char).Value = UserDesertIsle.Text;
                            cmd.Parameters.Add("@UserFaveArts", SqlDbType.Char).Value = UserFaveArts.Text;

                            //cmd.Parameters.Add("@Password", SqlDbType.Char).Value = Password.Text;


                            string[] date = DOB.Text.Split('/');            
                            string Zodiac = Findzodiac(Convert.ToString((date[0])), Convert.ToInt32(date[1]));

                            cmd.Parameters.Add("@Zodiac", SqlDbType.Char).Value = Zodiac;
                        

                        conn.Open();
                        //  returnValue = (int)cmd.ExecuteScalar();

                        Console.WriteLine(cmd.ToString());
                        cmd.ExecuteNonQuery();
                        
                    }

                    //Reg was successful
                    SuccessfulReg();
                }
                catch(Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                    lblErrorMsg.Visible = true;

                }
            }
        }

        public static string Findzodiac(string month, int day)        
        {            
            string str = string.Empty;            
            if (((month == "3") && (day >= 21 || day <= 31)) || ((month == "4") && (day >= 01 || day <= 20)))            
            {
                return "1";
                //return "Aires";            
            }            
            if (((month == "4") && (day >= 21 || day <= 31)) || ((month == "5") && (day >= 01 || day <= 21)))            
            {
                return "2";
                //return "Taurus";            
            }            
            if (((month == "5") && (day >= 22 || day <= 31)) || ((month == "6") && (day >= 01 || day <= 21)))            
            {
                return "3";
                //return "Gemini";            
            }            
            if (((month == "6") && (day >= 22 || day <= 31)) || ((month == "7") && (day >= 01 || day <= 22)))            
            {
                return "4";
                //return "Cancer";            
            }            
            if (((month == "7") && (day >= 23 || day <= 31)) || ((month == "8") && (day >= 01 || day <= 22)))            
            {
                return "5";
                //return "Leo";            
            }            
            if (((month == "8") && (day >= 23 || day <= 31)) || ((month == "9") && (day >= 01 || day <= 23)))            
            {
                return "6";
                //return "Virgo";            
            } 
            if (((month == "9") && (day >= 24 || day <= 31)) || ((month == "10") && (day >= 01 || day <= 23)))
            {
                return "7";
                //return "Libra";
            }
            if (((month == "10") && (day >= 24 || day <= 31)) || ((month == "11") && (day >= 01 || day <= 22)))
            {
                return "8";
                //return "Scorpio";
            }
            if (((month == "11") && (day >= 23 || day <= 31)) || ((month == "12") && (day >= 01 || day <= 21)))
            {
                return "9";
                //return "Sagittarius";
            }
            if (((month == "12") && (day >= 22 || day <= 31)) || ((month == "1") && (day >= 01 || day <= 20)))
            {
                return "10";
                //return "Capricorn";
            }
            if (((month == "1") && (day >= 21 || day <= 31)) || ((month == "2") && (day >= 01 || day <= 19)))
            {
                return "11";
                //return "Aquarius";
            }
            if (((month == "02") && (day >= 20 || day <= 31)) || ((month == "03") && (day >= 01 || day <= 20)))
            {
                return "12";
                //return "Pisces";
            }
            else
            {
                return "";
            }
        }

        protected void SuccessfulReg()
        {
            //Reset all values
            //UserName.Text = "";
            //Email.Text = "";
            //FName.Text = "";
            //Zipcode.Text = "";
            //ddlUserGender.SelectedValue = 1;
            //ddlMatchGender.SelectedValue = 2;
            //DOB.Text = "";
            //UserTitle.Text = "";
            //UserBody.Text = "";
            //UserAfterWork.Text = "";
            //UserAboutMyMatch.Text = "";
            //UserDesertIsle.Text = "";
            //UserFaveArts.Text = "";
            //Password.Text = "";
            //ConfirmPassword.Text = "";

            lblErrorMsg.Text = "Congratulations!  Your registration has completed successfully!";
            lblErrorMsg.Visible = true;
        }

        protected void UnsuccessfulReg(string Reason)
        {
            lblErrorMsg.Text = Reason;
            lblErrorMsg.Visible = true;
        }

        protected void LoadCountries()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLCountry = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlCountry' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLCountry);
                        sCountry.DataSource = DDLCountry;
                        sCountry.DataTextField = "DDLValue";
                        sCountry.DataValueField = "StoredValue";
                        sCountry.DataBind();
                    }
                    //ddlCountry.Items.Insert(0, new ListItem("Select a Country", "0"));
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadStates()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLState = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlState' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLState);
                        sState.DataSource = DDLState;
                        sState.DataTextField = "DDLValue";
                        sState.DataValueField = "StoredValue";
                        sState.DataBind();
                    }
                    //ddlState.Items.Insert(0, new ListItem("Select a State", "0"));
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadCities_Leave(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLCity = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [Place] from [tmpZipCodes] WHERE ZipCode = '" + Zipcode.Text + "' ORDER BY [Place] ASC", conn);
                        adapter.Fill(DDLCity);
                        City.DataSource = DDLCity;
                        City.DataTextField = "Place";
                        City.DataValueField = "Place";
                        City.DataBind();
                    }
                    //ddlCountry.Items.Insert(0, new ListItem("Select a Country", "0"));
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    conn.Close();
                }
            }

        }

        protected void LoadUserGender()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLUserGender = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlUserGender' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLUserGender);
                        MyGender.DataSource = DDLUserGender;
                        MyGender.DataTextField = "DDLValue";
                        MyGender.DataValueField = "StoredValue";
                        MyGender.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadMatchGender()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLMatchGender = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlMatchGender' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLMatchGender);
                        MatchGender.DataSource = DDLMatchGender;
                        MatchGender.DataTextField = "DDLValue";
                        MatchGender.DataValueField = "StoredValue";
                        MatchGender.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadGoal()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLGoal = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlGoal' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLGoal);
                        Goal.DataSource = DDLGoal;
                        Goal.DataTextField = "DDLValue";
                        Goal.DataValueField = "StoredValue";
                        Goal.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadIntent()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLIntent = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlIntent' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLIntent);
                        Intent.DataSource = DDLIntent;
                        Intent.DataTextField = "DDLValue";
                        Intent.DataValueField = "StoredValue";
                        Intent.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadStatus()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLStatus = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlStatus' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLStatus);
                        uStatus.DataSource = DDLStatus;
                        uStatus.DataTextField = "DDLValue";
                        uStatus.DataValueField = "StoredValue";
                        uStatus.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadEducation()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLEducation = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlEducation' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLEducation);
                        Education.DataSource = DDLEducation;
                        Education.DataTextField = "DDLValue";
                        Education.DataValueField = "StoredValue";
                        Education.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadOccupation()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLOccupation = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlOccupation' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLOccupation);
                        Occupation.DataSource = DDLOccupation;
                        Occupation.DataTextField = "DDLValue";
                        Occupation.DataValueField = "StoredValue";
                        Occupation.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadIncome()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLIncome = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlIncome' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLIncome);
                        Income.DataSource = DDLIncome;
                        Income.DataTextField = "DDLValue";
                        Income.DataValueField = "StoredValue";
                        Income.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadChildren()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLChildren = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlChildren' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLChildren);
                        Children.DataSource = DDLChildren;
                        Children.DataTextField = "DDLValue";
                        Children.DataValueField = "StoredValue";
                        Children.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadPets()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLPets = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlPets' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLPets);
                        Pets.DataSource = DDLPets;
                        Pets.DataTextField = "DDLValue";
                        Pets.DataValueField = "StoredValue";
                        Pets.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadHeight()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLHeight = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlHeight' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLHeight);
                        MyHeight.DataSource = DDLHeight;
                        MyHeight.DataTextField = "DDLValue";
                        MyHeight.DataValueField = "StoredValue";
                        MyHeight.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadBodyType()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLBodyType = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlBodyType' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLBodyType);
                        BodyType.DataSource = DDLBodyType;
                        BodyType.DataTextField = "DDLValue";
                        BodyType.DataValueField = "StoredValue";
                        BodyType.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadHairColor()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLHairColor = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlHairColor' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLHairColor);
                        HairColor.DataSource = DDLHairColor;
                        HairColor.DataTextField = "DDLValue";
                        HairColor.DataValueField = "StoredValue";
                        HairColor.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadEyeColor()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLEyeColor = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlEyeColor' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLEyeColor);
                        EyeColor.DataSource = DDLEyeColor;
                        EyeColor.DataTextField = "DDLValue";
                        EyeColor.DataValueField = "StoredValue";
                        EyeColor.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadDrinking()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLDrinking = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlDrinking' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLDrinking);
                        Drinking.DataSource = DDLDrinking;
                        Drinking.DataTextField = "DDLValue";
                        Drinking.DataValueField = "StoredValue";
                        Drinking.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadSmoking()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLSmoking = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlSmoking' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLSmoking);
                        Smoking.DataSource = DDLSmoking;
                        Smoking.DataTextField = "DDLValue";
                        Smoking.DataValueField = "StoredValue";
                        Smoking.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadEthnicity()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLEthnicity = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlEthnicity' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLEthnicity);
                        Ethnicity.DataSource = DDLEthnicity;
                        Ethnicity.DataTextField = "DDLValue";
                        Ethnicity.DataValueField = "StoredValue";
                        Ethnicity.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadReligion()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLReligion = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlReligion' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLReligion);
                        Religion.DataSource = DDLReligion;
                        Religion.DataTextField = "DDLValue";
                        Religion.DataValueField = "StoredValue";
                        Religion.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadZodiac()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLZodiac = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlZodiac' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLZodiac);
                        Zodiac.DataSource = DDLZodiac;
                        Zodiac.DataTextField = "DDLValue";
                        Zodiac.DataValueField = "StoredValue";
                        Zodiac.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadRelationship()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLRelationship = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlRelationship' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLRelationship);
                        Relationships.DataSource = DDLRelationship;
                        Relationships.DataTextField = "DDLValue";
                        Relationships.DataValueField = "StoredValue";
                        Relationships.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadInterests()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLInterests = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlInterests' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLInterests);
                        Interests.DataSource = DDLInterests;
                        Interests.DataTextField = "DDLValue";
                        Interests.DataValueField = "StoredValue";
                        Interests.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }


    }
}