using System;
using System.Collections;
using System.Configuration;
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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Drawing;

namespace SIS_Student
{
    public partial class SServices : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        int CurrentRole = 0;
        List<MirrorCLS> myList = new List<MirrorCLS>();
        Plans myPlan = new Plans();
        string sNo = "";
        string sName = "";
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

                    //TermCBO.SelectedValue = iRegYear.ToString() + iRegSem.ToString();
                    //sNamelbl.Text = "Welcome ...  " + Session["CurrentStudentName"].ToString();

                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Advising,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            showErr("Sorry, you don't have the permission to view this page...");
                        }

                    }
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
                }

                if (!IsPostBack)
                {
                    //if (!isPaid(sNo))//Must pay 3500
                    //{
                    //    string sAccMsg = "Sorry... You must pay first;";
                    //    sAccMsg += "<br/>Please contact the Accounting & Finance Department | يرجى مراجعة المحاسبة";
                    //    sAccMsg += "<br/>Phone Number (1): +971504188086";
                    //    sAccMsg += "<br/>Phone Number (2): +971544413928";
                    //    sAccMsg += "<br/>WhatsApp Messages: +971564065904";
                    //    sAccMsg += "<br/>Email: student.receivable@ect.ac.ae";
                    //    showErr(sAccMsg);
                    //}

                    Session["ReportDS"] = null;
                    Session["myList"] = null;
                    Session["myPlan"] = null;                    
                }
                else
                {
                    if (Session["myList"] != null)
                    {
                        myList = (List<MirrorCLS>)Session["myList"];
                        //System.Web.UI.WebControls.Table myTable = Create_Table(myList[0]);
                        //divDetail.Controls.Clear();
                        //divDetail.Controls.Add(myTable);
                        //hdnStudentNumber.Value = myList[0].StudentNumber;
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
    }
}