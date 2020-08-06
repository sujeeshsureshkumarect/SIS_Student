using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Collections.Generic;

namespace SIS_Student
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        int UserNumber;
        User myUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!Page.IsPostBack)
                {

                    int UserNumber = 0;

                    if (Session["CurrentUserName"] != null && Session["CurrentUserNo"] != null)
                    {
                        lblMsg.Text = Session["errMsg"].ToString();
                        TxtUserName.Text = Session["CurrentUserName"].ToString();
                        UserNumber = Convert.ToInt32(Session["CurrentUserNo"]);
                    }
                }
            }
            else
            {
                //showErr("Session is expired, Login again please...");
                ClearSession();
                Response.Redirect("Login.aspx");
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

        protected void ButSubmit_Click(object sender, EventArgs e)
        {
            if (LinkSave.Text == "Save")
            {
                List<User> myUsers = new List<User>();
                UserDAL myUserDAL = new UserDAL();
                int iUserIndex = -1;

                UserNumber = Convert.ToInt32(Session["CurrentUserNo"]);

                //string sCondition = " Where UserName='" + TxtUserName.Text + "' AND UserNo = " + UserNumber.ToString();
                string sCondition = " Where 1=1";
                myUsers = myUserDAL.GetUser(InitializeModule.EnumCampus.ECTNew, sCondition, false);

                iUserIndex = myUsers.FindIndex(delegate (User U) { return U.UserNo == UserNumber; });

                //int status = (int)InitializeModule.enumModes.EditMode;
                if (iUserIndex >= 0)
                {
                    myUser = myUsers[iUserIndex];
                    string sOldPwd = myUser.Password;
                    //Password Encryption 
                    EncryptionCls theEncryption = new EncryptionCls();


                    if (theEncryption.verifyMd5Hash(TxtOldPwd.Text, sOldPwd) || sOldPwd == TxtOldPwd.Text)
                    {

                        //myUsers[0].Password = TxtNewPWD.Text;
                        myUser.Password = TxtNewPWD.Text;

                        //myUser.IsChangingRequired = 0;

                        //int affectedrows = myUserDAL.UpdateUser(InitializeModule.EnumCampus.ECTNew, status,
                        //    myUser.UserNo, myUser.UserName, myUser.Password, myUser.EmployeeID,
                        //    myUser.UILanguage, myUser.AcademicYear, myUser.Semester, myUser.MarksYear,
                        //    myUser.MarksSemester, myUser.GradesPCName, myUser.ADUserName, myUser.IsActive,
                        //    DateTime.Now, 0, myUser.AllowedCampus, myUser.LecturerID, myUser.IsLecturer,
                        //    myUser.IsChangingRequired, myUser.Campus, myUser.CreationUserID, myUser.CreationDate,
                        //    myUser.LastUpdateUserID, DateTime.Today.Date, myUser.PCName, myUser.NetUserName);
                        if (isPwdChanged(myUser.UserName, myUser.Password, (InitializeModule.EnumCampus)myUser.Campus) > 0)
                        {
                            lblMsgs.Text = "Your password is changed successfully";
                            this.OldPwdRequiredFieldValidator.Enabled = false;
                            this.NewPwdCompareValidator.Enabled = false;
                            this.NewPwdRequiredFieldValidator.Enabled = false;
                            this.LinkSave.Enabled = false;
                            LinkSave.Text = "Saved";
                        }
                    }
                    else
                    {
                        lblMsgs.Text = "Your old password is worng";
                    }
                }
            }
            else
            {
                Response.Redirect("Dashboard");
            }
        }
        private void showmsg(string sMsg)
        {
            //divMsgText.InnerHtml = sMsg;
            runScr("showmsg('" + sMsg + "');");
            //divMsg.Visible = true;
        }

        private void runScr(string sScr)
        {
            string str = "<script>" + sScr + "</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
        }

        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }

        private int isPwdChanged(string sSID, string sPWD, InitializeModule.EnumCampus Campus)
        {
            int iEffected = 0;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "UPDATE Cmn_User  SET Password = '" + sPWD + "' WHERE UserName='" + sSID + "'";
                SqlCommand cmd = new SqlCommand(sSQL, Conn);
                iEffected += cmd.ExecuteNonQuery();
                Conn.Close();

                myConnection_String = new Connection_StringCLS(Campus);
                Conn = new SqlConnection(myConnection_String.Conn_string);
                Conn.Open();
                sSQL = "UPDATE Reg_Student_Accounts SET strOnlinePWD = '" + sPWD + "' WHERE lngStudentNumber='" + sSID + "'";
                cmd = new SqlCommand(sSQL, Conn);
                iEffected += cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                showmsg(ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iEffected;

        }
    }
}