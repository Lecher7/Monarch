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
    public partial class MainSearch : Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //sCountry.Attributes["multiple"] = "multiple";
                //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
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

                sCountry.SelectedValue = "US";
                MyGender.SelectedValue = "M";
                MatchGender.SelectedValue = "F";
                MinAge.SelectedValue = "30";
                MaxAge.SelectedValue = "45";
                MinHeight.SelectedValue = "60";
                MaxHeight.SelectedValue = "68";
            }
            else
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MaxHeight.SelectedValue = "68";
            String Blah = Zodiac.SelectedValue;
            Response.Redirect("OldMain.aspx");

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

    }
}