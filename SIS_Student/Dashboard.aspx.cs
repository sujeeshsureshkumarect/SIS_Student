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
    public partial class Dashboard : System.Web.UI.Page
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
                        bindnewsfeed();
                        loadstudentprofile();
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

        public void bindnewsfeed()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select TOP (5) * from ECT_SIS_News_Feed where isActive=1 order by dDate desc", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                RepeaterNews.DataSource = dt;
                RepeaterNews.DataBind();
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

        public void loadstudentprofile()
        {
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            string studentid = Session["CurrentStudent"].ToString();
            var services = new DAL.DAL();
            DataTable dtStudentProfile = services.GetStudentDetailsForProfile(studentid, connstr.Conn_string);
            string sCampus = Session["CurrentCampus"].ToString();
            if (dtStudentProfile.Rows.Count > 0)
            {

                int sem = 0;
                int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

                int iYear = Year;
                int iSem = sem;
                string sSemester = LibraryMOD.GetSemesterString(iSem);

                //txt_AcademicYear.Text = iYear.ToString();
                //txt_CurrentSemester.Text = sSemester.ToString();

                //txtFisrtName.Text = dtStudentProfile.Rows[0]["strLastDescEn"].ToString();
                //txtDateofBirth.Text = Convert.ToDateTime(dtStudentProfile.Rows[0]["dateBirth"]).ToString("dd/MM/yyyy");
                lbl_Email_ID.Text = dtStudentProfile.Rows[0]["sECTemail"].ToString();
                //txtPhoneNumber.Text = dtStudentProfile.Rows[0]["Phone"].ToString();
                lbl_Student_ID.Text = dtStudentProfile.Rows[0]["lngStudentNumber"].ToString();
                lbl_Current_Major.Text = dtStudentProfile.Rows[0]["strCaption"].ToString();


                string acceptance_type = "";
                string acceptance_condition = "";

                if (dtStudentProfile.Rows[0]["iAcceptanceType"].ToString() == "1")
                {
                    acceptance_type = "Permanently Accepted";
                }
                else if (dtStudentProfile.Rows[0]["iAcceptanceType"].ToString() == "2")
                {
                    acceptance_type = "One Academic Semester(Conditional)";
                }
                else if (dtStudentProfile.Rows[0]["iAcceptanceType"].ToString() == "3")
                {
                    acceptance_type = "Two Academic Semesters(Conditional)";
                }
                else if (dtStudentProfile.Rows[0]["iAcceptanceType"].ToString() == "4")
                {
                    acceptance_type = "One Academic Year(Conditional)";
                }

                if (dtStudentProfile.Rows[0]["iAcceptanceCondition"].ToString() == "1")
                {
                    acceptance_condition = "All conditions have been met";
                }
                else if (dtStudentProfile.Rows[0]["iAcceptanceCondition"].ToString() == "2")
                {
                    acceptance_condition = "High school equivalency needed";
                }
                else if (dtStudentProfile.Rows[0]["iAcceptanceCondition"].ToString() == "3")
                {
                    acceptance_condition = "EmSAT needed";
                }
                else if (dtStudentProfile.Rows[0]["iAcceptanceCondition"].ToString() == "4")
                {
                    acceptance_condition = "Major requirements are not met";
                }

                lbl_Acceptance_Type.Text = acceptance_type;
                lbl_Acceptance_Condition.Text = acceptance_condition;

                Session["Student_AT"]= acceptance_type;
                Session["Student_AC"]= acceptance_condition;

                if(dtStudentProfile.Rows[0]["byteCancelReason"].ToString()=="")
                {
                    lbl_Status.Text = "Active";
                }
                else
                {
                    SqlConnection sc = new SqlConnection(connstr.Conn_string);
                    SqlCommand cmd = new SqlCommand("select strReasonDesc from Lkp_Reasons where byteReason=@byteReason", sc);
                    cmd.Parameters.AddWithValue("@byteReason", dtStudentProfile.Rows[0]["byteCancelReason"].ToString());
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        sc.Open();
                        da.Fill(dt);
                        sc.Close();

                        if(dt.Rows.Count>0)
                        {
                            lbl_Status.Text = dt.Rows[0]["strReasonDesc"].ToString(); ;
                        }
                        else
                        {
                            lbl_Status.Text = "Active";
                        }
                    }
                    catch(Exception ex)
                    {
                        sc.Close();
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sc.Close();
                    }
                }


                //txt_Nationality.Text = dtStudentProfile.Rows[0]["strNationalityDescEn"].ToString();
                //string sPic = dtStudentProfile.Rows[0]["strStudentPic"].ToString();
                //hdfiUnifiedID.Value = dtStudentProfile.Rows[0]["iUnifiedID"].ToString();
                //string sDir = "Students";
                //if (sCampus == "Males")
                //{
                //    txt_Gender.Text = "Male";
                //}
                //else
                //{
                //    txt_Gender.Text = "Female";
                //}
            }
        }
    }
}