using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLDSite
{
    public partial class frmUpload : System.Web.UI.Page
    {
        string strCon1 = System.Configuration.ConfigurationManager.ConnectionStrings["OLDSiteConn"].ConnectionString;
        public string CurrUser = System.Web.HttpContext.Current.User.Identity.Name;
        protected bool LinkVisible { get; set; }
        protected string filename { get; set; }
        public string MyPath = "D:/Monarch/Images/";

        protected void Page_Load(object sender, EventArgs e)
        {
            GetCurrentUser();
            ReadPhotoInfo();
            if (!IsPostBack)

            {
                string[] filePaths = Directory.GetFiles(MyPath);
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new ListItem(fileName, MyPath + fileName));
                }
                //GridView1.DataSource = files;
                //GridView1.DataBind();
            }
            //{

            //    string[] filePaths = Directory.GetFiles(MyPath);
            //    List<ListItem> files = new List<ListItem>();
            //    foreach (string filePath in filePaths)
            //    {

            //        string fileName = Path.GetFileName(filePath);
            //        char[] delimiterChars = { '[', '\t' };
            //        string[] words = fileName.Split(delimiterChars);
            //        string webRootPathToFolder = ResolveUrl("~/Images/");

            //        //If the first piece of the filename is the user's ID, this is a record we want to keep
            //        if (words[0] == (lblCurrUser.Text))
            //        {
            //            files.Add(new ListItem(fileName, filePath));
            //        }
            //    }
            //    GridView1.DataSource = files;
            //    GridView1.DataBind();
            //}
            
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(MyPath + lblCurrUser.Text + "[" + fileName);
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

                        cmd2.Parameters.Add("@MyID", SqlDbType.Int).Value = lblCurrUser.Text;
                        cmd2.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FN;
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
            using (SqlCommand cmd = new SqlCommand("SELECT uFileName, PhotoInfo FROM tmpUserPhotos WHERE UserID = '" + lblCurrUser.Text + "'", con2))
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
                            igImage1.Src = "ImageCSharp.aspx?FileName=" + lblCurrUser.Text + "[" + DT2["uFileName"].ToString();
                            igImage1.Alt = DT2["PhotoInfo"].ToString();
                            igHide1.Visible = true;
                        }
                        if (X == 2)
                        {
                            igImage2.Src = "ImageCSharp.aspx?FileName=" + lblCurrUser.Text + "[" + DT2["uFileName"].ToString();
                            igImage2.Alt = DT2["PhotoInfo"].ToString();
                            igHide2.Visible = true;
                        }
                        if (X == 3)
                        {
                            igImage3.Src = "ImageCSharp.aspx?FileName=" + lblCurrUser.Text + "[" + DT2["uFileName"].ToString();
                            igImage3.Alt = DT2["PhotoInfo"].ToString();
                            igHide3.Visible = true;
                        }
                        if (X == 4)
                        {
                            igImage4.Src = "ImageCSharp.aspx?FileName=" + lblCurrUser.Text + "[" + DT2["uFileName"].ToString();
                            igImage4.Alt = DT2["PhotoInfo"].ToString();
                            igHide4.Visible = true;
                        }
                        if (X == 5)
                        {
                            igImage5.Src = "ImageCSharp.aspx?FileName=" + lblCurrUser.Text + "[" + DT2["uFileName"].ToString();
                            igImage5.Alt = DT2["PhotoInfo"].ToString();
                            igHide5.Visible = true;
                        }
                        if (X == 6)
                        {
                            igImage6.Src = "ImageCSharp.aspx?FileName=" + lblCurrUser.Text + "[" + DT2["uFileName"].ToString();
                            igImage6.Alt = DT2["PhotoInfo"].ToString();
                            igHide6.Visible = true;
                        }


                        X = X + 1;
                    }
                }
            }
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
                        lblCurrUser.Text = (DT2["UserID"].ToString());
                    }
                }
            }
        }
    }
}