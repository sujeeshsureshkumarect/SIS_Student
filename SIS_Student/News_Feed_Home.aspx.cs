using System;
using System.Collections;
using System.Configuration;
using SIS_Student.DAL;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace SIS_Student
{
    public partial class News_Feed_Home : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        int CurrentRole = 0;
        string sName = "";
        string sNo = "";
        int iRegYear = 0;
        int iRegSem = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];

                    iRegYear = (int)Session["RegYear"];
                    iRegSem = (int)Session["RegSemester"];
                    //if(CurrentRole == 165 || CurrentRole==91)
                    //{

                    //}
                    //else
                    //{
                    //    Session["errMsg"] = "You don't have access to view this page. Please contact Administrator.";
                    //    Response.Redirect("ErrPage.aspx");
                    //}
                }
                else
                {
                    //showErr("Session is expired, Login again please...");
                    ClearSession();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentCampus"] != null)
                {
                    string sCampus = Session["CurrentCampus"].ToString();
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    //Campus_ddl.SelectedValue = ((int)Campus).ToString();
                    string sConn = "";
                    Connection_StringCLS ConnectionString;
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Males:
                            ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                            sConn = ConnectionString.Conn_string;
                            break;
                        case InitializeModule.EnumCampus.Females:
                            ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                            sConn = ConnectionString.Conn_string;
                            break;
                    }

                }
                if (Session["CurrentStudent"] != null)
                {
                    sNo = Session["CurrentStudent"].ToString();
                    sName = Session["CurrentStudentName"].ToString();

                    if (!IsPostBack)
                    {
                        bindcount();
                        bindtotal();
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }

        }


        public void ClearSession()
        {
            Session["CurrentUserName"] = null;
            Session["CurrentUserNo"] = null;
            Session["CurrentYear"] = null;
            Session["CurrentSemester"] = null;
            Session["CurrentCampus"] = null;
            Session["CurrentRole"] = null;
            Session["CurrentSystem"] = null;
            Session["CurrentLecturer"] = null;
            Session["MarkYear"] = null;
            Session["MarkSemester"] = null;
            Session["CurrentStudent"] = null;
            Session["CurrentStudentName"] = null;
            Session["CurrentMajorCampus"] = null;
        }
        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }

        public void bindtotal()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select * from ECT_SIS_News_Feed", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch(Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            bindtotal();
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select * from ECT_SIS_News_Feed where isActive='1'", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select * from ECT_SIS_News_Feed where isActive='0'", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }

        public void bindcount()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select count(iSerial) as Total from ECT_SIS_News_Feed;  select  count(iSerial) as Active from ECT_SIS_News_Feed where isActive='1';  select count(iSerial) as Inactive from ECT_SIS_News_Feed where isActive='0'", sc);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(ds);
                sc.Close();

                lbl_total.Text = ds.Tables[0].Rows[0]["Total"].ToString();
                lbl_Active.Text = ds.Tables[1].Rows[0]["Active"].ToString();
                lbl_Inactive.Text = ds.Tables[2].Rows[0]["Inactive"].ToString();
            }
            catch(Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }
    }
}