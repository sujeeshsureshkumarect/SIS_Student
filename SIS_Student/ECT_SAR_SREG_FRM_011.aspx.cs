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
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;
using System.Security;
using System.IO;
using Microsoft.Online.SharePoint.TenantAdministration;
using System.Text;

namespace SIS_Student
{
    public partial class ECT_SAR_SREG_FRM_011 : System.Web.UI.Page
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
                        getservicedetails();
                        getdetails();
                        getcourses();
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

        public void getcourses()
        {
            var services = new DAL.DAL();
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            int sem = 0;
            int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

            int iYear = Year;
            int iSem = sem;
            string studentid = Session["CurrentStudent"].ToString();
            DataTable dt = services.GetCoursesbyStudentId(studentid, connstr.Conn_string, iYear,iSem);
            if (dt.Rows.Count > 0)
            {
                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();

                //drp_Course.DataSource = dt; 
                //drp_Course.DataTextField = "Course";  
                //drp_Course.DataValueField = "Code"; 
                //drp_Course.DataBind();

                //drp_Course.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select a Course---", "---Select a Course---"));
            }
            //else
            //{
            //    drp_Course.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select a Course---", "---Select a Course---"));
            //}
        }
        public void getdetails()
        {
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            int sem = 0;
            int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

            int iYear = Year;
            int iSem = sem;
            string sSemester = LibraryMOD.GetSemesterString(iSem);

            lbl_AcademicYear.Text = iYear.ToString();
            lbl_Semester.Text = sSemester.ToString();

            string studentid = Session["CurrentStudent"].ToString();
            var services = new DAL.DAL();
            DataTable dtStudentServices = services.GetStudentDetailsID(studentid, connstr.Conn_string);
            if (dtStudentServices.Rows.Count > 0)
            {
                lbl_StudentName.Text = dtStudentServices.Rows[0]["strLastDescEn"].ToString();
                lbl_StudentID.Text = dtStudentServices.Rows[0]["lngStudentNumber"].ToString();
                lbl_StudentContact.Text = dtStudentServices.Rows[0]["Phone"].ToString();
                hdf_StudentEmail.Value = dtStudentServices.Rows[0]["sECTemail"].ToString();
            }

        }
        public void getservicedetails()
        {
            string serviceid = Request.QueryString["ServiceID"];
            var services = new DAL.DAL();
            DataTable dtStudentServices = services.GetStudentServicesbyID(serviceid);
            if (dtStudentServices.Rows.Count > 0)
            {
                lbl_ServiceID.Text = serviceid;
                lbl_ServiceNameEn.Text = dtStudentServices.Rows[0]["ServiceEn"].ToString();
                lbl_ServiceNameAr.Text = dtStudentServices.Rows[0]["ServiceAr"].ToString();
                lbl_Fess.Text = "AED " + Convert.ToDouble(dtStudentServices.Rows[0]["Sum"]).ToString("N");
                hdf_Price.Value = dtStudentServices.Rows[0]["Sum"].ToString();
                Session["FeesType"] = dtStudentServices.Rows[0]["FeesType"].ToString();
                Session["HostEmail"] = dtStudentServices.Rows[0]["Host"].ToString();
                Session["FinanceEmail"] = dtStudentServices.Rows[0]["Finance"].ToString();
                Session["LanguageOption"] = dtStudentServices.Rows[0]["LanguageOption"].ToString();

                if (dtStudentServices.Rows[0]["LanguageOption"].ToString()=="True")
                {
                    tdlanguage.Visible = true;
                }
                else
                {
                    tdlanguage.Visible = false;
                }
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

        protected void lnk_Generate_Click(object sender, EventArgs e)
        {
            string header = "<table style='width: 100 %; border: 1px solid #000' align='center'  id='tblContacts'><tbody><tr><td align='center' style='background-color: #f2f2f2; color: #000;'><b>Has an Exam in<br>(لديه لديها امتحان في مادة)</b></td><td align='center' style='background-color: #f2f2f2; color: #000;'><b>Course Code<br>(رمز المادة)</b></td><td align='center' style='background-color: #f2f2f2; color: #000;'><b>Instructor’s Name<br>(اســم مدرس المادة)</b></td><td align='center' style='background-color: #f2f2f2; color: #000;'><b>Exam Day<br>(يوم الامتحان)</b></td><td align='center' style='background-color: #f2f2f2; color: #000;'><b>Exam Date <br>(الموافق لتاريخ)</b></td><td align='center' style='background-color: #f2f2f2; color: #000;'><b>Time of Exam <br>(الساعة)</b></td></tr>";
            string request = "";
            string footer = "</tbody></table>";
            foreach (RepeaterItem item in RepterDetails.Items)
            {
                if (((CheckBox)item.FindControl("chk")).Checked)
                {
                    //Do something
                    var lbl_exam = (Label)item.FindControl("lbl_exam") as Label;
                    var lbl_code = (Label)item.FindControl("lbl_code") as Label;
                    var lbl_instructor = (Label)item.FindControl("lbl_instructor") as Label;
                    var txt_Date = (TextBox)item.FindControl("txt_Date") as TextBox;
                    string day = Convert.ToDateTime(txt_Date.Text).ToString("dddd");
                    var txt_Time = (TextBox)item.FindControl("txt_Time") as TextBox;
                    request = request + "<tr><td align='center'> " + lbl_exam.Text + "</td><td align='center'> " + lbl_code.Text + "</td><td align='center'> " + lbl_instructor.Text + "</td><td align='center'> " + day + "</td><td align='center'> " + txt_Date.Text + "</td><td align='center'> " + txt_Time.Text + "</td></tr>";
                }
            }
            string htmltext = header + request + footer;

            //if (drp_Course.SelectedItem.Value != "---Select a Course---")
            //{
                //sentdatatoSPLIst();   
                int sem = 0;
                int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

                int iYear = Year;
                int iSem = sem;
                string sSemester = LibraryMOD.GetSemesterString(iSem);
                string refno = Create16DigitString();
                //string day = Convert.ToDateTime(txt_ExamDate.Text).ToString("dddd");
                string sACC = "0200000";
                if (Session["CurrentCampus"].ToString() == "Males")
                {
                    sACC = "0100000";
                }
                else
                {
                    sACC = "0200000";
                }

            string languageoption = "";
            if (Session["LanguageOption"].ToString() == "True")
            {
                languageoption="<b>Language:</b> " + ddlLanguage.SelectedItem.Text + "";
            }


            // Create a DataTable  
            DataTable dtSPList = new DataTable();
                dtSPList.Clear();
                dtSPList.Columns.Add("Title");
                dtSPList.Columns.Add("Year");
                dtSPList.Columns.Add("Semester");
                dtSPList.Columns.Add("Request");
                dtSPList.Columns.Add("RequestNote");
                dtSPList.Columns.Add("ServiceID");
                dtSPList.Columns.Add("Fees");
                dtSPList.Columns.Add("Requester");
                dtSPList.Columns.Add("StudentID");
                dtSPList.Columns.Add("StudentName");
                dtSPList.Columns.Add("Contact");
                dtSPList.Columns.Add("Finance");
                dtSPList.Columns.Add("FinanceAction");
                dtSPList.Columns.Add("FinanceNote");
                dtSPList.Columns.Add("Host");
                dtSPList.Columns.Add("HostAction");
                dtSPList.Columns.Add("HostNote");
                dtSPList.Columns.Add("ProviderAction");
                dtSPList.Columns.Add("ProviderNote");
                dtSPList.Columns.Add("Status");

                // Add items using Add method   
                DataRow dr = dtSPList.NewRow();
                dr["Title"] = refno;
                dr["Year"] = iYear;
                dr["Semester"] = iSem;
                dr["Request"] = "<b>Service ID:</b> " + lbl_ServiceID.Text + "<br/> <b>Service Name:</b> " + lbl_ServiceNameEn.Text + " (" + lbl_ServiceNameAr.Text + " )<br/>" + languageoption + "<br/><b><u>Service Request:</u></b><br/><br/>" + htmltext+"";
                dr["RequestNote"] = txt_Remarks.Text.Trim();
                dr["ServiceID"] = lbl_ServiceID.Text;
                dr["Fees"] = hdf_Price.Value;
                //dr["Requester"] = "sujeesh.sureshkumar@ect.ac.ae";
                dr["Requester"] = hdf_StudentEmail.Value;
                dr["StudentID"] = lbl_StudentID.Text;
                dr["StudentName"] = lbl_StudentName.Text;
                dr["Contact"] = lbl_StudentContact.Text;
                //dr["Finance"] = "ihab.awad@ect.ac.ae";
                dr["Finance"] = Session["FinanceEmail"].ToString();
                dr["FinanceAction"] = "Initiate";
                dr["FinanceNote"] = "";
                //dr["Host"] = "ihab.awad@ect.ac.ae";
                dr["Host"] = Session["HostEmail"].ToString();
                dr["HostAction"] = "Initiate";
                dr["HostNote"] = "";
                dr["ProviderAction"] = "Initiate";
                dr["ProviderNote"] = "";
                dr["Status"] = "Finance Approval Needed";
                dtSPList.Rows.Add(dr);

                //sentdatatoSPLIst();

                Session["CurrentService"] = "Student Services: " + lbl_ServiceID.Text + "";
                Session["CurrentServiceName"] = lbl_ServiceNameEn.Text;
                Session["CurrentServiceAmount"] = string.Format("{0:f}", hdf_Price.Value);
                Session["CurrentdtSPList"] = dtSPList;
                Session["CurrentAccount"] = sACC;
                Session["cancelpage"] = "ECT_SAR_SREG_FRM_011.aspx?ServiceID="+ lbl_ServiceID.Text + "";
                Response.Redirect("Student_Services_HostedPayment.aspx");
            //}                
        }

        //public void sentdatatoSPLIst()
        //{
        //    int sem = 0;
        //    int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

        //    int iYear = Year;
        //    int iSem = sem;
        //    string sSemester = LibraryMOD.GetSemesterString(iSem);

        //    string day = Convert.ToDateTime(txt_ExamDate.Text).ToString("dddd");

        //    string login = "ets.services.admin@ect.ac.ae"; //give your username here  
        //    string password = "Ser71ces@328"; //give your password  
        //    var securePassword = new SecureString();
        //    foreach (char c in password)
        //    {
        //        securePassword.AppendChar(c);
        //    }
        //    string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
        //    ClientContext clientContext = new ClientContext(siteUrl);
        //    Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("Students_Requests");
        //    ListItemCreationInformation itemInfo = new ListItemCreationInformation();
        //    Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);
        //    string refno = Create16DigitString();
        //    myItem["Title"] = refno;
        //    //myItem["RequestID"] = refno;
        //    myItem["Year"] = iYear;
        //    myItem["Semester"] = iSem;
        //    myItem["Request"] = "<b>Service ID:</b> " + lbl_ServiceID.Text + "<br/> <b>Service Name:</b> " + lbl_ServiceNameEn.Text + " (" + lbl_ServiceNameAr.Text + " )<br/><b>Has an Exam in:</b> " + drp_Course.SelectedItem.Text + "<br/><b>Course Code:</b> " + lbl_CourseCode.Text + "<br/><b>Exam Day:</b> " + day + "<br/><b>Exam Date:</b> " + txt_ExamDate.Text + "<br/><b>Time of Exam:</b> " + txt_ExamTime.Text + "<br/><b>Instructor’s Name:</b> " + lbl_Instructor.Text + "";
        //    myItem["RequestNote"] = txt_Remarks.Text.Trim();
        //    myItem["ServiceID"] = lbl_ServiceID.Text;
        //    myItem["Fees"] = hdf_Price.Value;
        //    //myItem["Requester"] = clientContext.Web.EnsureUser(hdf_StudentEmail.Value);
        //    myItem["Requester"] = clientContext.Web.EnsureUser("sujeesh.sureshkumar@ect.ac.ae");
        //    myItem["StudentID"] = lbl_StudentID.Text;
        //    myItem["StudentName"] = lbl_StudentName.Text;
        //    myItem["Contact"] = lbl_StudentContact.Text;
        //    myItem["Finance"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");
        //    myItem["FinanceAction"] = "Initiate";
        //    myItem["FinanceNote"] = "";
        //    myItem["Host"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");
        //    myItem["HostAction"] = "Initiate";
        //    myItem["HostNote"] = "";
        //    //myItem["Provider"] = "";
        //    myItem["ProviderAction"] = "Initiate";
        //    myItem["ProviderNote"] = "";
        //    myItem["Status"] = "Finance Approval Needed";
        //    //myItem["Modified"] = DateTime.Now;
        //    //myItem["Created"] = DateTime.Now;
        //    //myItem["Created By"] = hdf_StudentEmail.Value;
        //    //myItem["Modified By"] = hdf_StudentEmail.Value;
        //    try
        //    {
        //        myItem.Update();

        //        //if (flp_Upload.HasFile)
        //        //{
        //        //    var attachment = new AttachmentCreationInformation();

        //        //    flp_Upload.SaveAs(Server.MapPath("~/Upload/" + flp_Upload.FileName));
        //        //    string FileUrl = Server.MapPath("~/Upload/" + flp_Upload.FileName);

        //        //    string filePath = FileUrl;
        //        //    attachment.FileName = Path.GetFileName(filePath);
        //        //    attachment.ContentStream = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
        //        //    Attachment att = myItem.AttachmentFiles.Add(attachment);
        //        //}

        //        var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
        //        clientContext.Credentials = onlineCredentials;
        //        clientContext.ExecuteQuery();

        //        //string FileUrls = Server.MapPath("~/Upload/" + flp_Upload.FileName);
        //        //System.IO.File.Delete(FileUrls);

        //        lbl_Msg.Text = "Request (ID# " + refno + ") Generated Successfully";
        //        lbl_Msg.Visible = true;
        //        div_msg.Visible = true;
        //        lnk_Generate.Enabled = false;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    //Console.ReadLine();
        //}

        public string Create16DigitString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString.ToString();
        }

        //protected void drp_Course_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(drp_Course.SelectedItem.Value!= "---Select a Course---")
        //    {
        //        var services = new DAL.DAL();
        //        Connection_StringCLS connstr = new Connection_StringCLS(Campus);
        //        int sem = 0;
        //        int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

        //        int iYear = Year;
        //        int iSem = sem;
        //        string studentid = Session["CurrentStudent"].ToString();
        //        DataTable dt = services.GetCoursesbyCourseId(studentid, connstr.Conn_string, iYear, iSem, drp_Course.SelectedItem.Value);
        //        if (dt.Rows.Count > 0)
        //        {
        //            lbl_CourseCode.Text = drp_Course.SelectedItem.Value;
        //            lbl_Instructor.Text = dt.Rows[0]["strLecturerDescEn"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        lbl_CourseCode.Text = "";
        //        lbl_Instructor.Text = "";
        //    }
        //}
    }
}