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
using System.Linq;
using CrystalDecisions.ReportAppServer.ClientDoc;

namespace SIS_Student
{
    public partial class ECT_SAR_SCDA_FRM_003 : System.Web.UI.Page
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
            DataTable dtStudentServices = services.GetStudentDetailsIDbyNationality(studentid, connstr.Conn_string);
            if (dtStudentServices.Rows.Count > 0)
            {
                lbl_StudentName.Text = dtStudentServices.Rows[0]["strLastDescEn"].ToString();
                lbl_StudentID.Text = dtStudentServices.Rows[0]["lngStudentNumber"].ToString();
                lbl_StudentContact.Text = dtStudentServices.Rows[0]["Phone"].ToString();
                hdf_StudentEmail.Value = dtStudentServices.Rows[0]["sECTemail"].ToString();
                lbl_Major.Text = dtStudentServices.Rows[0]["strCaption"].ToString();
                string cancelreason = dtStudentServices.Rows[0]["byteCancelReason"].ToString();
                if (cancelreason != "3")
                {
                    div_Alert.Attributes["class"] = "alert alert-danger alert-dismissible ";
                    lbl_Msg.Text = "You are not allowed to generate this request at this time (Only for Graduated Students)";
                    lbl_Msg.Visible = true;
                    div_msg.Visible = true;
                    lnk_Generate.Enabled = false;
                }
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
            sentdatatoSPLIst();
        }

        public void sentdatatoSPLIst()
        {
            string careeractivities = "";
            string otheractivities = "";
            string prefereddays = "";
            string preferedtime = "";
            string k = "";
            for (int i = 0; i < chk_CareerActivities.Items.Count; i++)
            {
                if (chk_CareerActivities.Items[i].Selected)
                {
                    k = k + chk_CareerActivities.Items[i].Value + ";";
                }

            }
            careeractivities = k;

            string j = "";
            for (int n = 0; n < chk_OtherActivities.Items.Count; n++)
            {
                if (chk_OtherActivities.Items[n].Selected)
                {
                    j = j + chk_OtherActivities.Items[n].Value + ";";
                }

            }
            otheractivities = j;

            string a = "";
            for (int q = 0; q < chk_PreferedDays.Items.Count; q++)
            {
                if (chk_PreferedDays.Items[q].Selected)
                {
                    a = a + chk_PreferedDays.Items[q].Value + ";";
                }

            }
            prefereddays = a;

            preferedtime = "From: "+Convert.ToDateTime(txt_From.Text).ToString("hh:mm tt")+" To: "+ Convert.ToDateTime(txt_To.Text).ToString("hh:mm tt") + "";

            int sem = 0;
            int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

            int iYear = Year;
            int iSem = sem;
            string sSemester = LibraryMOD.GetSemesterString(iSem);

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("Students_Requests");
            ListItemCreationInformation itemInfo = new ListItemCreationInformation();
            Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);
            string refno = Create16DigitString();
            myItem["Title"] = refno;
            //myItem["RequestID"] = refno;
            myItem["Year"] = iYear;
            myItem["Semester"] = iSem;
            myItem["Request"] = "<b>Service ID:</b> " + lbl_ServiceID.Text + "<br/> <b>Service Name:</b> " + lbl_ServiceNameEn.Text + " (" + lbl_ServiceNameAr.Text + " )<br/><b>Major:</b> " + lbl_Major.Text + "<br/><b>Student Contact #:</b> " + lbl_StudentContact.Text + "<br/><b>Career Development Activities (Workshop/Seminar):</b> " + careeractivities + "<br/><b>Career Service:</b> " + otheractivities + "<br/><b>Comments:</b> " + txt_Comments.Text + "<br/><b>Prefered Timing:</b> " + preferedtime + "<br/><b>Prefered Days:</b> " + prefereddays + "<br/><b>Other Suggestion for Alumni services & Activities:</b> " + txt_Remarks.Text + "<br/>";
            myItem["RequestNote"] = txt_Remarks.Text.Trim();
            myItem["ServiceID"] = lbl_ServiceID.Text;
            myItem["Fees"] = hdf_Price.Value;
            //myItem["Requester"] = clientContext.Web.EnsureUser(hdf_StudentEmail.Value);
            myItem["Requester"] = clientContext.Web.EnsureUser("sujeesh.sureshkumar@ect.ac.ae");
            myItem["StudentID"] = lbl_StudentID.Text;
            myItem["StudentName"] = lbl_StudentName.Text;
            myItem["Contact"] = lbl_StudentContact.Text;
            myItem["Finance"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");
            myItem["FinanceAction"] = "Initiate";
            myItem["FinanceNote"] = "";
            myItem["Host"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");
            myItem["HostAction"] = "Initiate";
            myItem["HostNote"] = "";
            //myItem["Provider"] = "";
            myItem["ProviderAction"] = "Initiate";
            myItem["ProviderNote"] = "";
            myItem["Status"] = "Finance Approval Needed";
            //myItem["Modified"] = DateTime.Now;
            //myItem["Created"] = DateTime.Now;
            //myItem["Created By"] = hdf_StudentEmail.Value;
            //myItem["Modified By"] = hdf_StudentEmail.Value;
            try
            {
                myItem.Update();

                //if (flp_Upload.HasFile)
                //{
                //    var attachment = new AttachmentCreationInformation();

                //    flp_Upload.SaveAs(Server.MapPath("~/Upload/" + flp_Upload.FileName));
                //    string FileUrl = Server.MapPath("~/Upload/" + flp_Upload.FileName);

                //    string filePath = FileUrl;
                //    attachment.FileName = Path.GetFileName(filePath);
                //    attachment.ContentStream = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
                //    Attachment att = myItem.AttachmentFiles.Add(attachment);
                //}

                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                clientContext.Credentials = onlineCredentials;
                clientContext.ExecuteQuery();

                //string FileUrls = Server.MapPath("~/Upload/" + flp_Upload.FileName);
                //System.IO.File.Delete(FileUrls);

                lbl_Msg.Text = "Request (ID# " + refno + ") Generated Successfully";
                lbl_Msg.Visible = true;
                div_msg.Visible = true;
                lnk_Generate.Enabled = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
        }

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
    }
}