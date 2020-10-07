using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Globalization;

namespace SIS_Student
{
    public partial class DocsUpload : System.Web.UI.Page
    {
        User myUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CurrentURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "ihabadm" || txtUser.Text == "mousah" || txtUser.Text == "Suhib" || txtUser.Text == "MohammadShaath" || txtUser.Text == "ESM2009001")
            {
                try
                {
                    ClearSession();
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
                                divLogin.Visible = false;
                                upload.Visible = true;

                                Tab1.CssClass = "Clicked";
                                Tab2.CssClass = "Initial";
                                MainView.ActiveViewIndex = 0;

                                lbl_Msg2.Visible = false;
                                getstudentdetials();
                                Context.ApplicationInstance.CompleteRequest(); // end response
                            }
                        }
                        else
                        {
                            lblMsg.Text = "This User Name is inactive...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex.Message);
                }
            }
            else
            {
                lblMsg.Text = "Access Denied";
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
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            String constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;//ECTDataNewConnectionString
            SqlConnection sc = new SqlConnection(constr);
            if (Session["CurrentUserName"] != null)
            {

                SqlCommand cmd1 = new SqlCommand("select * from ECT_Doc_Reference where sReference=@sReference", sc);
                cmd1.Parameters.AddWithValue("@sReference", txt_Refernce.Text.Trim());
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                try
                {
                    sc.Open();
                    da1.Fill(dt1);
                    sc.Close();

                    if (dt1.Rows.Count > 0)
                    {
                        lbl_Msg2.Text = "Document Exists Already.";
                        lbl_Msg2.Visible = true;
                    }
                    else
                    {
                        string CurrentUserName = Session["CurrentUserName"].ToString();
                        string path = "";
                        if (flp_Upload.HasFile)
                        {
                            string extension = Path.GetExtension(flp_Upload.PostedFile.FileName);
                            string filename = DateTime.Now.ToString("ddMMyyyy") + "_" + drp_StudentID.SelectedItem.Value + "_" + txt_Refernce.Text.Trim();
                            flp_Upload.SaveAs(Server.MapPath("~/StudentDocs/" + filename + extension));
                            path = "StudentDocs/" + filename + extension;
                        }

                        //byte[] thepath = Encoding.UTF8.GetBytes(path);

                        SqlCommand cmd = new SqlCommand("insert into ECT_Doc_Reference values(@sStudentID,@sDesc,@sReference,@sURL,@dIssueDate,@dValidTo,@sUploadedBy)", sc);
                        cmd.Parameters.AddWithValue("@sStudentID", drp_StudentID.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@sDesc", txt_Description.Text.Trim());
                        cmd.Parameters.AddWithValue("@sReference", txt_Refernce.Text.Trim());
                        cmd.Parameters.AddWithValue("@sURL", path);
                        cmd.Parameters.AddWithValue("@dIssueDate", DateTime.Now);
                        DateTime date = DateTime.ParseExact(txt_Expiry.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        cmd.Parameters.AddWithValue("@dValidTo", date);
                        cmd.Parameters.AddWithValue("@sUploadedBy", CurrentUserName);
                        try
                        {
                            sc.Open();
                            cmd.ExecuteNonQuery();
                            sc.Close();
                            lbl_Msg2.Visible = true;
                            lbl_Msg2.Text = "Document Added Successfully";
                        }
                        catch (Exception ex)
                        {
                            sc.Close();
                            //throw ex;
                            lbl_Msg2.Text = ex.Message;
                            Console.WriteLine("{0} Exception caught.", ex.Message);
                        }
                        finally
                        {
                            sc.Close();
                            drp_StudentID.SelectedIndex = 0;
                            txt_Refernce.Text = "";
                            txt_Description.Text = "";
                            txt_Expiry.Text = DateTime.Now.AddMonths(6).ToString("dd/MM/yyyy");
                        }
                    }
                }
                catch (Exception ex)
                {
                    sc.Close();
                    lbl_Msg2.Text = ex.Message;
                }
                finally
                {
                    sc.Close();
                }


            }
            else
            {
                ClearSession();
                divLogin.Visible = true;
                upload.Visible = false;
                lblMsg.Text = "Session is expired, Login again please...";
            }
        }
        public void getstudentdetials()
        {
            string constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT  (A.lngStudentNumber + '-' + SD.strLastDescEn) AS Name,      A.lngStudentNumber, SD.strLastDescEn FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial WHERE (SD.byteShift = 3 OR SD.byteShift = 4 OR SD.byteShift = 8) AND (A.byteCancelReason IS NULL OR A.byteCancelReason = 3 OR A.byteCancelReason = 25 OR A.byteCancelReason = 20) UNION SELECT (A.lngStudentNumber + '-' + SD.strLastDescEn) AS Name, A.lngStudentNumber, SD.strLastDescEn FROM  SQL_SERVER.ECTDATA.DBO.Reg_Applications AS A INNER JOIN SQL_SERVER.ECTDATA.DBO.Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial WHERE  (SD.byteShift = 1 OR SD.byteShift = 2 OR SD.byteShift = 9) AND (A.byteCancelReason IS NULL OR A.byteCancelReason = 3 OR A.byteCancelReason = 25 OR A.byteCancelReason = 20)", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();
                if (dt.Rows.Count > 0)
                {
                    drp_StudentID.DataSource = dt;
                    drp_StudentID.DataTextField = "Name";
                    drp_StudentID.DataValueField = "lngStudentNumber";
                    drp_StudentID.DataBind();

                    drp_StudentID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select a Student---", "---Select a Student---"));

                    txt_Expiry.Text = DateTime.Now.AddMonths(6).ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                //throw ex;
                lbl_Msg2.Text = ex.Message;
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            ClearSession();
            divLogin.Visible = true;
            upload.Visible = false;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            MainView.ActiveViewIndex = 1;
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            String constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ECT_Doc_Reference WHERE (sReference = @sReference or sStudentID=@sStudentID)", sc);
            cmd.Parameters.AddWithValue("@sReference", txt_Search.Text.Trim());
            cmd.Parameters.AddWithValue("@sStudentID", txt_Search.Text.Trim());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    lbl_Msg.Visible = false;
                    Results.Visible = true;
                    RepterDetails.DataSource = dt;
                    RepterDetails.DataBind();
                }
                else
                {
                    lbl_Msg.Visible = true;
                    lbl_Msg.Text = "No results found...";
                    Results.Visible = false;
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                //throw ex;
                lbl_Msg.Text = ex.Message;
            }
            finally
            {
                sc.Close();
            }
        }

        protected void OnDelete(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int iEntry = int.Parse((item.FindControl("lbliEntry") as Label).Text);
            string sUrl = (item.FindControl("lblsURL") as Label).Text;

            String constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("delete from [ECT_Doc_Reference] where iEntry=@iEntry"))
                {
                    cmd.Parameters.AddWithValue("@iEntry", iEntry);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    if ((System.IO.File.Exists(Server.MapPath("~/" + sUrl))))
                    {
                        System.IO.File.Delete(Server.MapPath("~/" + sUrl));
                    }
                }
            }
            this.btn_Search_Click(null, null);
            lbl_Msg.Visible = true;
            lbl_Msg.Text = "Deleted Successfully";
        }
    }
}