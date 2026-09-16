using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using System.Math;
using System.Runtime;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace OLDSite
{
    public partial class MainPage : System.Web.UI.Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public string CurrUser = System.Web.HttpContext.Current.User.Identity.Name;
        //public string CurrUser;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string CurrUser = User.Identity.Name;

            if (Request.IsAuthenticated)
            {
                if (Page.IsPostBack == false)
                {
                    LoadUserGender();
                    LoadMatchGender();
                    LoadMinAge();
                    LoadMaxAge();
                    LoadCountries();
                    //LoadStates();
                    LoadMinHeight();
                    LoadMaxHeight();
                    LoadBodyType();
                    LoadIntent();
                    LoadEducation();
                    LoadZodiac();
                    LoadSmoking();
                    LoadReligion();
                    LoadEthnicity();
                    LoadRadius();
                    GetCurrentUser();
                    Show_Data();
                    //LoadGroups();

                    //  This will be used to populate the listboxes with the user's preferences
                    //// Read the value of Sys_Dcmnt_Chg from the table and select the appropriate values
                    ////   in the multi-select list box ddlSysDocChg
                    //for (int i = 0; i < ddlSysDocChg.Items.Count; i++)
                    //{
                    //    foreach (string SysDoc in DT["Sys_Dcmnt_Chg"].ToString().Split(','))
                    //    {
                    //        if (SysDoc != ddlSysDocChg.Items[i].Text) continue;
                    //        ddlSysDocChg.Items[i].Selected = true;
                    //        break;
                    //    }
                    //}
                }


            }
            else
            {
                if (Page.IsPostBack == false)
                {
                    LoadUserGender();
                    LoadMatchGender();
                    LoadMinAge();
                    LoadMaxAge();
                    LoadCountries();
                    //LoadStates();
                    LoadMinHeight();
                    LoadMaxHeight();
                    LoadBodyType();
                    LoadIntent();
                    LoadEducation();
                    LoadZodiac();
                    LoadSmoking();
                    LoadReligion();
                    LoadEthnicity();
                    LoadRadius();
                    lblCurrUser.Text = Convert.ToString(0);
                    Show_Data();

                    //Auto-populate the dropdowns
                    sCountry.SelectedValue = "US";

                    //foreach (ListItem li in sState.Items)
                    //{
                    //    li.Selected = true;
                    //}

                    MyGender.SelectedValue = "1";
                    MatchGender.SelectedValue = "2";
                    MinAge.SelectedValue = "18";
                    MaxAge.SelectedValue = "99";
                    MinHeight.SelectedValue = "48";
                    MaxHeight.SelectedValue = "84";

                    foreach (ListItem li in BodyType.Items)
                    {
                        li.Selected = true;
                    }

                    foreach (ListItem li in Intent.Items)
                    {
                        li.Selected = true;
                    }

                    foreach (ListItem li in Education.Items)
                    {
                        li.Selected = true;
                    }

                    foreach (ListItem li in Zodiac.Items)
                    {
                        li.Selected = true;
                    }

                    foreach (ListItem li in Smoking.Items)
                    {
                        li.Selected = true;
                    }

                    foreach (ListItem li in Religion.Items)
                    {
                        li.Selected = true;
                    }

                    foreach (ListItem li in Ethnicity.Items)
                    {
                        li.Selected = true;
                    }

                    txtZipCode.Text = "";
                    lstRadius.SelectedValue = "5";
                }
            }


        }

        public void GetCurrentUser()
        {
            lblCurrUser.Text = Convert.ToString("0");
            // Get the current logged in user's ID
            using (SqlConnection con2 = new SqlConnection(strCon1))
            using (SqlCommand cmd = new SqlCommand("SELECT UserID, UserZip FROM vw_tmpUsers WHERE UserName = '" + CurrUser + "'", con2))
            {
                //lblCurrUser.Text = Convert.ToString(0);
                con2.Open();
                using (SqlDataReader DT2 = cmd.ExecuteReader())
                {
                    while (DT2.Read())
                    {
                        lblCurrUser.Text = (DT2["UserID"].ToString());
                        txtZipCode.Text = (DT2["UserZip"].ToString());
                    }
                }
            }
        }

        protected void SearchPanel_Load(object sender, EventArgs e)
        {
            //Panel1Time.Text = "UpdatePanel1 time: " + DateTime.Now.ToString();
            Show_Data();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Read the selected items from the listbox
            //var selectedQuery = ListBox2.Items.Cast<ListItem>().Where(item => item.Selected);
            //string txtSysDocChg = String.Join(",", selectedQuery).TrimEnd();

            //Run the Stored Procedure first
            SqlConnection connection2 = new SqlConnection(strCon1);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "sp_Search";
            cmd2.Connection = connection2;

            // Find all the selected items from the listboxes
            var selectedMyGender = MyGender.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strMyGender = String.Join(",", selectedMyGender).TrimEnd();

            var selectedMatchGender = MatchGender.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strMatchGender = String.Join(",", selectedMatchGender).TrimEnd();

            var selectedMinAge = MinAge.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strMinAge = String.Join(",", selectedMinAge).TrimEnd();

            var selectedMaxAge = MaxAge.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strMaxAge = String.Join(",", selectedMaxAge).TrimEnd();

            var selectedCountry = sCountry.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strCountry = String.Join(",", selectedCountry).TrimEnd();

            //var selectedState = sState.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            //string strState = String.Join(",", selectedState).TrimEnd();

            var selectedMinHeight = MinHeight.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strMinHeight = String.Join(",", selectedMinHeight).TrimEnd();

            var selectedMaxHeight = MaxHeight.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strMaxHeight = String.Join(",", selectedMaxHeight).TrimEnd();

            var selectedBodyType = BodyType.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strBodyType = String.Join(",", selectedBodyType).TrimEnd();

            var selectedIntent = Intent.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strIntent = String.Join(",", selectedIntent).TrimEnd();

            var selectedEducation = Education.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strEducation = String.Join(",", selectedEducation).TrimEnd();

            var selectedZodiac = Zodiac.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strZodiac = String.Join(",", selectedZodiac).TrimEnd();

            var selectedSmoking = Smoking.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strSmoking = String.Join(",", selectedSmoking).TrimEnd();

            var selectedReligion = Religion.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strReligion = String.Join(",", selectedReligion).TrimEnd();

            var selectedEthnicity = Ethnicity.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strEthnicity = String.Join(",", selectedEthnicity).TrimEnd();

            var selectedRadius = lstRadius.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            string strRadius = String.Join(",", selectedRadius).TrimEnd();

            string ZipLen = txtZipCode.Text;
            if (ZipLen.Length != 5)
            {
                txtZipCode.Text = "90210";
            }

            // Now add the parameters for the SProc
            cmd2.Parameters.Add("@MyGender", SqlDbType.VarChar).Value = strMyGender;
            cmd2.Parameters.Add("@MatchGender", SqlDbType.VarChar).Value = strMatchGender;
            cmd2.Parameters.Add("@MinAge", SqlDbType.VarChar).Value = strMinAge;
            cmd2.Parameters.Add("@MaxAge", SqlDbType.VarChar).Value = strMaxAge;
            cmd2.Parameters.Add("@Country", SqlDbType.VarChar).Value = strCountry;
            //cmd2.Parameters.Add("@uState", SqlDbType.VarChar).Value = strState;
            cmd2.Parameters.Add("@MinHeight", SqlDbType.VarChar).Value = strMinHeight;
            cmd2.Parameters.Add("@MaxHeight", SqlDbType.VarChar).Value = strMaxHeight;
            cmd2.Parameters.Add("@BodyType", SqlDbType.VarChar).Value = strBodyType;
            cmd2.Parameters.Add("@Intent", SqlDbType.VarChar).Value = strIntent;
            cmd2.Parameters.Add("@Education", SqlDbType.VarChar).Value = strEducation;
            cmd2.Parameters.Add("@Zodiac", SqlDbType.VarChar).Value = strZodiac;
            cmd2.Parameters.Add("@Smoking", SqlDbType.VarChar).Value = strSmoking;
            cmd2.Parameters.Add("@Religion", SqlDbType.VarChar).Value = strReligion;
            cmd2.Parameters.Add("@Ethnicity", SqlDbType.VarChar).Value = strEthnicity;
            cmd2.Parameters.Add("@Radius", SqlDbType.VarChar).Value = strRadius;
            cmd2.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = txtZipCode.Text;
            cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = lblCurrUser.Text;

            connection2.Open();

            var SearchAdapter = new SqlDataAdapter(cmd2);
            var ds = new DataSet();
            SearchAdapter.Fill(ds);

            AcctRepeater.DataSource = ds;
            AcctRepeater.DataBind();

            //Refresh the user LastLogged time
            DateTime CurrDate = DateTime.Now;

            SqlConnection con = new SqlConnection(strCon1);
            SqlDataAdapter adp = new SqlDataAdapter("update tmpUsers set LastLoginDate=@LoginDt where UserID=@id", con);

            adp.SelectCommand.Parameters.AddWithValue("@LoginDt", CurrDate);
            adp.SelectCommand.Parameters.AddWithValue("@id", lblCurrUser.Text);

            DataSet ds2 = new DataSet();
            adp.Fill(ds2);


        }

        protected void AcctRepeater_DataBinding(object sender, RepeaterItemEventArgs e)
        {

            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    DropDownList MyDropDown = (DropDownList)e.Item.FindControl("cboAcctGrp");
            //    if (MyDropDown != null)
            //    {
            //        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString);
            //        //string strSQL = "SELECT * FROM dbo.tmpUsers ORDER BY LastOnline;";
            //        string strSQL = "select *, DATEDIFF(hour,UserDOB,GETDATE())/8766 AS UserAge, '10' as NumInterests from [tmpUsers];";

            //        SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn);
            //        DataSet GrpNames = new DataSet();
            //        adapter.Fill(GrpNames);

            //        //MyDropDown.DataSource = GrpNames;
            //        //MyDropDown.DataTextField = "ACCT_GRP";
            //        //MyDropDown.DataValueField = "ACCT_GRP_PK";
            //        //MyDropDown.DataBind();

            //    }
            //}
        }

        public void Show_Data()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString);
            //string srtOrder = cboSortBy.Text;
            //SqlDataAdapter adp = new SqlDataAdapter("select [ACCT_LIST].*, [ACCT_GRP_LIST].ACCT_GRP from [ACCT_LIST] LEFT JOIN [ACCT_GRP_LIST] on [ACCT_GRP_LIST].ACCT_GRP_PK = [ACCT_LIST].ACCT_GRP_FK ORDER BY " + srtOrder + "", con);
            //SqlDataAdapter adp = new SqlDataAdapter("select *, '10' as NumInterests from [vw_tmpUsers] WHERE UserID <> '" + lblCurrUser.Text + "'", conn);

            string MySQL = "SELECT VU.*, COALESCE(UI.UserImg, 'dflt.jpg') as UserImg, COALESCE(CI.Interests, 0) as NumInterests ";
            MySQL = MySQL + "FROM [vw_tmpUsers] VU ";
            MySQL = MySQL + "LEFT JOIN (";
            MySQL = MySQL + "SELECT [tmpUserPhotos].UserID, Max([tmpUserPhotos].uFileName) as UserImg FROM [tmpUserPhotos] GROUP BY UserID) UI ";
            MySQL = MySQL + "ON VU.UserID = UI.UserID ";
            MySQL = MySQL + "LEFT JOIN (";
            MySQL = MySQL + "SELECT T1.UserID, Count(t1.matchvalue) AS Interests ";
            MySQL = MySQL + "FROM [tmpUserMatch] T1 ";
            MySQL = MySQL + "INNER JOIN [tmpUserMatch] T2 ";
            MySQL = MySQL + "ON T1.matchvalue = T2.matchvalue ";
            MySQL = MySQL + "WHERE T2.userid = '" + lblCurrUser.Text + "' AND T1.UserID <> '" + lblCurrUser.Text + "' AND T1.matchfield = 'MatchInterests' ";
            MySQL = MySQL + "GROUP BY T1.UserID) CI ";
            MySQL = MySQL + "ON VU.UserID = CI.UserID ";
            MySQL = MySQL + "WHERE VU.UserID <> '" + lblCurrUser.Text + "' ";
            MySQL = MySQL + "ORDER BY VU.LastLoginDate DESC";


            SqlDataAdapter adp = new SqlDataAdapter(MySQL, conn);

            DataSet ds = new DataSet();
            adp.Fill(ds, "OLDPages");

            //Pagination code so only a set number of records loads at a time.
            //  Done to speed up the loading, since this list gets really long.
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables["OLDPages"].DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;

            int currentPage;

            if (Request.QueryString["page"] != null)
            {
                currentPage = Int32.Parse(Request.QueryString["page"]);
            }
            else
            {
                currentPage = 1;
            }

            pds.CurrentPageIndex = currentPage - 1;
            //Label1.Text = "Page " + currentPage + " of " + pds.PageCount;

            if (!pds.IsFirstPage)
            {
                MenuItem itemMessage = NavMenu.FindItem("First");
                itemMessage.NavigateUrl = Request.CurrentExecutionFilePath + "?page=1";
            }

            AcctRepeater.DataSource = pds;
            AcctRepeater.DataBind();

            CreatePagingControl(pds.PageCount, pds.CurrentPageIndex);
            // End of Pagination code

            conn.Close();
        }

        private void CreatePagingControl(int PCount, int PIndex)
        {
            int PIndex2 = 0;
            int SCounter = PIndex + 1;
            int RowCount = PCount;

            //Allow the pagination menu to always start 5 less than the current page you're on
            if (PIndex < 5)
            {
                PIndex2 = 0;
            }
            else
            {
                PIndex2 = PIndex - 5;
            }

            // Show 10 total page numbers.  You can increase or shrink that range by changing the 10 to whatever number you want
            for (int i = PIndex2; i < PIndex2 + 10 && i < PCount; i++)
            {
                NavMenu.Items.Add(new MenuItem
                {
                    Text = (i + 1).ToString(),
                    NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + (i + 1).ToString()
                });

                // Now determine the selected item so the proper CSS can be applied
                foreach (MenuItem item in NavMenu.Items)
                {
                    item.Selected = item.Text.Equals(SCounter.ToString());
                }
            }

            NavMenu.Items.Add(new MenuItem
            {
                Text = "Last",
                NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + (PCount)
            });
        } 

        protected void AcctRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Show_Data();
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
                    //sCountry.Items.Insert(0, new ListItem("Select a Country", "0"));
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    //conn.Close;
                }
            }
            //conn.Close;
        }

        //protected void LoadStates()
        //{
        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
        //    {
        //        try
        //        {
        //            DataTable DDLState = new DataTable();
        //            {
        //                SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlState' ORDER BY [SortOrder] ASC", conn);
        //                adapter.Fill(DDLState);
        //                sState.DataSource = DDLState;
        //                sState.DataTextField = "DDLValue";
        //                sState.DataValueField = "StoredValue";
        //                sState.DataBind();
        //            }
        //            //sCountry.Items.Insert(0, new ListItem("Select a State", "0"));
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.Write(ex);
        //        }
        //    }
        //}

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

        protected void LoadMinAge()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLMinAge = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlAge' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLMinAge);
                        MinAge.DataSource = DDLMinAge;
                        MinAge.DataTextField = "DDLValue";
                        MinAge.DataValueField = "StoredValue";
                        MinAge.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadMaxAge()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLMaxAge = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlAge' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLMaxAge);
                        MaxAge.DataSource = DDLMaxAge;
                        MaxAge.DataTextField = "DDLValue";
                        MaxAge.DataValueField = "StoredValue";
                        MaxAge.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadMinHeight()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLMinHeight = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlHeight' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLMinHeight);
                        MinHeight.DataSource = DDLMinHeight;
                        MinHeight.DataTextField = "DDLValue";
                        MinHeight.DataValueField = "StoredValue";
                        MinHeight.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void LoadMaxHeight()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLMaxHeight = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlHeight' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLMaxHeight);
                        MaxHeight.DataSource = DDLMaxHeight;
                        MaxHeight.DataTextField = "DDLValue";
                        MaxHeight.DataValueField = "StoredValue";
                        MaxHeight.DataBind();
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

        protected void LoadRadius()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString))
            {
                try
                {
                    DataTable DDLRadius = new DataTable();
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("Select [DDLValue], [StoredValue] from [tmpDropdowns] WHERE DDLName = 'ddlRadius' ORDER BY [SortOrder] ASC", conn);
                        adapter.Fill(DDLRadius);
                        lstRadius.DataSource = DDLRadius;
                        lstRadius.DataTextField = "DDLValue";
                        lstRadius.DataValueField = "StoredValue";
                        lstRadius.DataBind();
                    }
                    //sCountry.Items.Insert(0, new ListItem("Select a State", "0"));
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        public double getDistanceFromLatLon(double lat1,double lon1, double lat2, double lon2) {
            var R = 6371; // Radius of the earth in km
            var dLat = deg2rad(lat2-lat1);  // deg2rad below
            var dLon = deg2rad(lon2-lon1); 
            var a = 
                Math.Sin(dLat/2) * Math.Sin(dLat/2) +
                Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * 
                Math.Sin(dLon/2) * Math.Sin(dLon/2)
            ; 
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a)); 
            var d = R * c;
            var getDistance = d / 1.609344;

            return getDistance;

        }

        //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: 
        //::  This function converts decimal degrees to radians             ::: 
        //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: 

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }


        //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: 
        //::  This function converts radians to decimal degrees             ::: 
        //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: 

        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        } 



    }
}