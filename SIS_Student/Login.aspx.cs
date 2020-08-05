using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.AccountManagement;
using System.Net;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace SIS_Student
{
    public partial class Login : System.Web.UI.Page
    {
        User myUser = new User(); 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CurrentURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
        }

        protected void Btn_Signin_Click(object sender, EventArgs e)
        {
            try
            {

                ClearSession();

                //if (lnkLogin.Text == "Login")
                //{
                    bool itIs = isAuthorized();
                    if (itIs)
                    {

                        int iAdded = add_log(Session["CurrentUserName"].ToString(), "ECTSIS", Session["CurrentNetUserName"].ToString(), Convert.ToInt32(Session["CurrentUserNo"]), Session["CurrentURL"].ToString());

                    if (myUser.IsActive == 1)
                    {

                        if (Convert.ToBoolean(myUser.IsChangingRequired))
                        {
                            Session["errMsg"] = "You have to change your passoword...";
                            Response.Redirect("ChangePwd");
                        }
                        else
                        {
                            //BuildMainTree();
                            //lnkLogin.Text = "Logout";
                            Response.Redirect("Dashboard", false);
                            Context.ApplicationInstance.CompleteRequest(); // end response
                        }
                    }
                    else
                        {
                            //showmsg("This User Name is inactive...");
                        lblMsg.Text = "This User Name is inactive...";
                        }
                    }
                //}
                //else
                //{
                //    lnkLogin.Text = "Login";

                //    logUserOut();
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }

        }
        private int add_log(string sUser, string sPCName, string sNtUser, int iUserID, string sURL)
        {
            int iAdded = 0;

            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
            conn.Open();
            try
            {
                string sSQL = "";

                sSQL = "INSERT INTO ECT_User_Log (sUser,dTime,sPCName,sNtUser,iUserID,sURL) VALUES ('" + sUser + "',GETDATE(),'" + sPCName + "','" + sNtUser + "'," + iUserID + ",'" + sURL + "')";

                SqlCommand cmd = new SqlCommand(sSQL, conn);

                iAdded = cmd.ExecuteNonQuery();
                return iAdded;
            }
            catch (Exception ex)
            {
                return iAdded;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private bool isAuthorized()
        {
            bool isIt = false;
            List<User> myUsers = new List<User>();
            List<Applications> myApplication = new List<Applications>();
            UserDAL myUserDAL = new UserDAL();
            InitializeModule.EnumCampus CMPS;
            try
            {
                string sPassword = "";
                int iUserNo = 0;
                int iSystem = (int)InitializeModule.EnumSystems.ECTLocal;
                int iRole = 0;
                int iLecturer = 0;
                int iYear = 2019;
                int iSem = 2;
                int iCampus = 0;
                string sName = "";
                string sNo = "";
                int iMarkYear = 0;
                int iMarkSem = 0;
                int iUserIndex = -1;

                EncryptionCls theEncryption = new EncryptionCls();
                //string sCondition = " Where UserName='" + txtUser.Text + "'";
                string sCondition = " Where 1=1";

                myUsers = myUserDAL.GetUser(InitializeModule.EnumCampus.ECTNew, sCondition, false);
                iUserIndex = myUsers.FindIndex(delegate (User U) { return U.UserName.ToLower() == txtUser.Text.ToLower(); });
                if (iUserIndex >= 0)
                {
                    myUser = myUsers[iUserIndex];
                    iUserNo = myUser.UserNo;
                    sPassword = myUser.Password;
                    iLecturer = myUser.LecturerID;
                    iYear = myUser.AcademicYear;
                    iSem = myUser.Semester;
                    iCampus = myUser.Campus;
                    iMarkYear = myUser.MarksYear;
                    iMarkSem = myUser.MarksSemester;
                    Session["EmployeeID"] = myUser.EmployeeID;
                }
                else
                {
                    //showmsg("Wrong user name ...");
                    lblMsg.Text = "Wrong user name ...";
                    txtUser.Focus();
                    return isIt;
                }

                if (theEncryption.verifyMd5Hash(txtPassword.Text, sPassword) || sPassword == txtPassword.Text)
                {

                    iRole = myUserDAL.GetUserRole(iUserNo, iSystem);
                    if (iRole > 0)
                    {
                        Session["CurrentUserName"] = myUser.UserName;//txtUser.Text;
                        Session["CurrentUserNo"] = iUserNo;
                        CMPS = (InitializeModule.EnumCampus)iCampus;
                        Session["CurrentYear"] = iYear;
                        Session["CurrentSemester"] = iSem;
                        Session["CurrentCampus"] = CMPS;
                        Session["CurrentRole"] = iRole;
                        Session["CurrentSystem"] = iSystem;
                        Session["CurrentLecturer"] = iLecturer;
                        Session["MarkYear"] = iMarkYear;
                        Session["MarkSemester"] = iMarkSem;

                        //server name
                        Session["CurrentPCName"] = LibraryMOD.GetComputerName(Request.UserHostAddress);
                        Session["CurrentNetUserName"] = LibraryMOD.GetCurrentNtUserName();


                        if (iRole == 105 || iRole == 111)
                        {
                            Student_SearchDAL mySearch = new Student_SearchDAL();

                            sNo = LibraryMOD.GetSIDFromUser((InitializeModule.EnumCampus)iCampus, iUserNo);
                            //bool isEnable = Enable_Disable(sNo, (InitializeModule.EnumCampus)iCampus);
                            //if (!isEnable)
                            //{
                            //    return false;
                            //}

                            sName = mySearch.Sync_Students_No((InitializeModule.EnumCampus)iCampus, sNo);
                            CMPS = (InitializeModule.EnumCampus)iCampus;
                            Session["CurrentCampus"] = CMPS;
                            Session["CurrentStudent"] = sNo;
                            Session["CurrentStudentName"] = sName;
                            Session["CurrentYear"] = Session["RegYear"];
                            Session["CurrentSemester"] = Session["RegSemester"];
                            int iCurrentMajorCampus = LibraryMOD.GetCurrentStCampus(sNo, (InitializeModule.EnumCampus)iCampus);
                            Session["CurrentMajorCampus"] = iCurrentMajorCampus;

                        }

                        isIt = true;
                        //showmsg("Welcome ...  " + Session["CurrentStudentName"].ToString());
                    }
                    else
                    {
                        //showmsg("User not in system role");
                        lblMsg.Text = "User not in system role";
                    }
                }
                else
                {
                    //showmsg("Wrong user password ...");
                    lblMsg.Text = "Wrong user password ...";
                    txtPassword.Focus();
                }


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsgText.InnerText = exp.Message;
            }
            finally
            {
                myUsers.Clear();
                myApplication.Clear();
            }
            return isIt;
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
    }
}