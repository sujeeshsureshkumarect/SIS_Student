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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.IO;

namespace SIS_Student
{
    public partial class StudentProfile : System.Web.UI.Page
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

        //protected void btnReset_Click(object sender, EventArgs e)
        //{

        //}
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

                txt_AcademicYear.Text = iYear.ToString();
                txt_CurrentSemester.Text = sSemester.ToString();

                txtFisrtName.Text = dtStudentProfile.Rows[0]["strLastDescEn"].ToString();
                txtDateofBirth.Text = Convert.ToDateTime(dtStudentProfile.Rows[0]["dateBirth"]).ToString("dd/MM/yyyy");
                txtEmail.Text = dtStudentProfile.Rows[0]["sECTemail"].ToString();
                txtPhoneNumber.Text = dtStudentProfile.Rows[0]["Phone"].ToString();
                txt_StudentID.Text = dtStudentProfile.Rows[0]["lngStudentNumber"].ToString();
                txt_Major.Text= dtStudentProfile.Rows[0]["strCaption"].ToString();
                txt_Nationality.Text = dtStudentProfile.Rows[0]["strNationalityDescEn"].ToString();
                string sPic = dtStudentProfile.Rows[0]["strStudentPic"].ToString();
                hdfiUnifiedID.Value= dtStudentProfile.Rows[0]["iUnifiedID"].ToString();
                string sDir = "Students";
                if (sCampus == "Males")
                {
                    txt_Gender.Text = "Male";
                }
                else
                {
                    txt_Gender.Text = "Female";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sPath = "";
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            if (ProfileFileUpload.HasFile)
            {
                string iUnifiedID = hdfiUnifiedID.Value;               
                string sCampus = Session["CurrentCampus"].ToString();
                string gender = "";
                if(sCampus == "Males")
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }

                string sFileName = gender+iUnifiedID;
                //string sfname = "PIC" + sFileName+".JPEG";
                sPath = CreateImage(Convert.ToBase64String(ProfileFileUpload.FileBytes), sFileName);

                SqlConnection sc = new SqlConnection(connstr.Conn_string);
                SqlConnection sc1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
                SqlCommand cmd = new SqlCommand("update Reg_Students_Data set strStudentPic=@strStudentPic where iUnifiedID=@iUnifiedID", sc);
                cmd.Parameters.AddWithValue("@strStudentPic", sFileName);
                cmd.Parameters.AddWithValue("@iUnifiedID", iUnifiedID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    SqlCommand cmd2 = new SqlCommand("update ACMS_User set PicPath=@PicPath,PIC=@PIC where Personnelnr=@Personnelnr", sc1);
                    cmd2.Parameters.AddWithValue("@PicPath", sPath);
                    cmd2.Parameters.AddWithValue("@PIC", sFileName);
                    cmd2.Parameters.AddWithValue("@Personnelnr", sFileName);
                    try
                    {
                        sc1.Open();
                        cmd2.ExecuteNonQuery();
                        sc1.Close();

                        lbl_Msg.Visible = true;
                        div_msg.Visible = true;
                    }
                    catch(Exception ex)
                    {
                        sc1.Close();
                        Console.WriteLine("{0} Exception caught.", ex.Message);
                    }
                    finally
                    {
                        sc1.Close();
                    }
                }
                catch(Exception ex)
                {
                    sc.Close();                    
                    Console.WriteLine("{0} Exception caught.", ex.Message);
                }
                finally
                {
                   sc.Close();
                }
            }

        }

        private string CreateImage(string base64String, string sPic)
        {
            string sFilePath = "";
            try
            {
                //***Save Base64 Encoded string as Image File***//
                //Convert Base64 Encoded string to Byte Array.
                byte[] imageBytes = Convert.FromBase64String(base64String);
                //Save the Byte Array as Image File.
                string filePath = Server.MapPath(ProfileFileUpload.FileName);
                string sDir = "Students";
                //System.IO.File.WriteAllBytes(filePath, imageBytes);
                sFilePath = "\\\\management-m\\ETSD\\ETS\\Images\\" + sDir + "\\PIC" + sPic + ".jpeg";
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(sFilePath);
                System.IO.File.WriteAllBytes(sFilePath, imageBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

            }
            return sFilePath;
        }

    }

}