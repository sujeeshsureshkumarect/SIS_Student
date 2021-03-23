using System;
using System.Collections;
using System.Configuration;
using System.Data;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Drawing;
using SelectPdf;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Security;
using Microsoft.SharePoint.Client;

namespace SIS_Student
{
    public partial class StudentRegistration : System.Web.UI.Page
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

                    //sNamelbl.Text = "Welcome ...  " + Session["CurrentStudentName"].ToString();

                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            showErr("Sorry, you don't have the permission to view this page...");
                        }

                        if(Session["Student_AT"].ToString()== "Permanently Accepted" && Session["Student_AC"].ToString()== "All conditions have been met")
                        {
                            
                        }
                        else
                        {
                            string msg = "Sorry, you cannot register | نأسف, لا يمكنك التسجيل";
                            string sRegMsg = "<br />Contact the registration please | يرجى مراجعة التسجيل";
                            msg = msg+"<br />"+sRegMsg;
                            showErr(msg);
                        }

                    }
                }
                else
                {
                    // showErr("Session is expired, Login again please...");
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
                    TmDS.ConnectionString = sConn;
                    RegDS.ConnectionString = sConn;
                }

                if (Session["CurrentStudent"] != null)
                {

                    sNo = Session["CurrentStudent"].ToString();
                    sName = Session["CurrentStudentName"].ToString();
                }
                else
                {
                    showErr("Login as student please...");
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
                    Get_Student_Advising();

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                        InitializeModule.enumPrivilege.ViewAllRegCourses, CurrentRole) != true)
                    {

                        FillStudentCourses();
                    }
                    else
                    {
                        FillCourses();
                    }

                    //==========================
                    //Print student time table
                    if (Request.QueryString["TimeTable"] != null)
                    {
                        Retrieve();
                        ExportStudentTimeTable();
                    }

                    //==========================


                    //Session["ReportDS"] = null;
                }
                else
                {
                    if (Session["myList"] != null)
                    {
                        myList = (List<MirrorCLS>)Session["myList"];
                        System.Web.UI.WebControls.Table myTable = Create_Table(myList[0]);
                        divDetail.Controls.Clear();
                        divDetail.Controls.Add(myTable);
                        hdnStudentNumber.Value = myList[0].StudentNumber;
                    }
                }
                Reg_grd.DataBind();
                TmDS.DataBind();

                if (Session["ReportDS"] != null)
                {
                    DataSet rptDS;
                    rptDS = (DataSet)Session["ReportDS"];
                    if (rptDS.Tables.Count > 0)
                    {
                        DataTable dt = rptDS.Tables[0];
                        TimeTable_Grd.DataSource = dt;
                        TimeTable_Grd.DataBind();
                    }
                }
                double dCGPA = 0;//Convert.ToDouble(String.Format("{0:0.00}", LibraryMOD.GetCGPA(Campus, sNo)));
                dCGPA = Convert.ToDouble(this.myList[0].CGPA);
                lblAcademicAdvisorNameAr.Text = this.myList[0].Advisor;
                lblAcademicAdvisorNameEn.Text = LibraryMOD.GetAdvisorEmail(this.myList[0].Advisor);
                if (dCGPA <= 2.2)
                {
                    lblVisitAcademicAdvisor.Visible = true;
                    lblVisitAcademicAdvisorEn.Visible = true;
                }
                else
                {
                    lblVisitAcademicAdvisor.Visible = false;
                    lblVisitAcademicAdvisorEn.Visible = false;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

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
            Session["myBookSearch"] = null;
            Session["BooksBasket"] = null;
            Session["LibarayBooks"] = null;

        }
        private void FillStudentCourses()
        {

            List<Advised.Courses> recommendedCourses = this.myList[0].Recommended;
            bool isElectiveAdded = false;
            try
            {
                Course_ddl.ClearSelection();
                bool isToeflRequired = this.myList[0].IsENGRequired;
                float Score = float.Parse(this.myList[0].Score.ToString());
                int iMaxESL = this.myList[0].MaxESL;
                bool isToeflPassed = LibraryMOD.isENGPassed(Score, this.myList[0].ENG, this.myList[0].SDegree, this.myList[0].SMajor);

                ////Add ESLs--This is what Available execludes the foundation students
                //if (isToeflRequired && !isToeflPassed && this.myList[0].StudentNumber.Substring(0, 1) != "F")
                //{
                //    //switch (iMaxESL)
                //    //{
                //    //    case 0:
                //    //        Course_ddl.Items.Add(new ListItem("ESL100", "ESL100"));
                //    //    break;
                //    //    case 1:
                //    //    case 2:
                //    //    case 3:
                //    //        Course_ddl.Items.Add(new ListItem("ESL102", "ESL102"));
                //    //    break;

                //    //}

                //    //Course_ddl.Items.Add(new ListItem("ESL101", "ESL101"));                
                //    //Course_ddl.Items.Add(new ListItem("ESL101A", "ESL101A"));
                //    Course_ddl.Items.Add(new ListItem("ESL_Gen", "ESL_Gen"));
                //}

                foreach (Advised.Courses C in recommendedCourses)
                {

                    //if (C.sCourse.Contains("ESL") != true)
                    //{
                    Course_ddl.Items.Add(new System.Web.UI.WebControls.ListItem(C.sCourse, C.sCourse));
                    //if ((C.sCourse == "ELECT1" || C.sCourse == "ELECT2" || C.sCourse == "MELECT1" || C.sCourse == "MELECT2" || C.sCourse == "MELECT3") && (!isElectiveAdded))
                    //{
                    //    Fill_Elective();
                    //    isElectiveAdded = true;
                    //}
                    //}
                }

            }

            catch (Exception ex)
            {


                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {
                //recommendedCourses.Clear();

            }


        }
        private void FillCourses()
        {
            List<Courses> myCourses = new List<Courses>();
            CoursesDAL myCoursesDAL = new CoursesDAL();
            try
            {
                myCourses = myCoursesDAL.GetList(InitializeModule.EnumCampus.Males, "", true);
                for (int i = 0; i < myCourses.Count; i++)
                {
                    Course_ddl.Items.Add(new System.Web.UI.WebControls.ListItem(myCourses[i].strCourse, myCourses[i].strCourse));
                }

            }
            catch (Exception ex)
            {


                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {
                myCourses.Clear();

            }
        }
        private void Get_Student_Advising()
        {
            List<MirrorCLS> myMirror = new List<MirrorCLS>();
            Advising myAdvising = new Advising();
            Plans Plan = new Plans();
            try
            {
                //Campus = (InitializeModule.EnumCampus)int.Parse(Campus_ddl.SelectedValue);
                if (Request.QueryString["selectedCampus"] != null)
                    Campus = (InitializeModule.EnumCampus)int.Parse(Request.QueryString["selectedCampus"].ToString());
                else if (Session["CurrentCampus"] != null)
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];

                int iYear = iRegYear;
                int iSem = iRegSem;
                //Is Grades Hidden
                bool isHidden = LibraryMOD.isGradesHidden(Campus);
                myMirror = myAdvising.GetAdvising(sNo, true, iYear, iSem, true, isHidden, out Plan, Campus, Session["sCSemester"].ToString());
                System.Web.UI.WebControls.Table myTable = Create_Table(myMirror[0]);
                divDetail.Controls.Clear();
                divDetail.Controls.Add(myTable);
                int i = myMirror.Count;
                int iRec = myMirror[0].Recommended.Count;

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
            finally
            {
                myMirror = myList;
                Session["myList"] = myMirror;
                Session["myPlan"] = Plan;
                Enable_Disable(myMirror[0].Recommended.Count > 0);


            }

        }



        private void Enable_Disable(bool isEnabled)
        {
            try
            {
                //Print_btn.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Print, isEnabled);
                //Reg_btn.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Setting, isEnabled);
                //Print_btn.Enabled = isEnabled;
                //Reg_btn.Enabled = isEnabled;
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
            finally
            {

            }
        }

        private System.Web.UI.WebControls.Table Create_Table(MirrorCLS myMirror)
        {
            System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();
            try
            {
                myList.Add(myMirror);
                //First Row
                //MyTable.Width = 800;
                MyTable.Width = Unit.Percentage(100);
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Horizontal;
                MyTable.ID = "Student_Info";

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();
                TableCell Hd = new TableCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Student Information";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                //No
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "No : ";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = sNo;
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);
                //Name
                Hc = new TableHeaderCell();
                Hc.Text = "Name : ";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = sName;
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);


                //Second Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "Major : ";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.ColumnSpan = 3;
                Hd.Text = myMirror.Major;
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);
                //----------------------------------------
                //Hc = new TableHeaderCell();
                //Hc.Text = "Registered Courses : ";
                //Hr.Cells.Add(Hc);

                //Hd = new TableCell();
                ////Hd.ColumnSpan = 3;
                //Hd.Text = Convert.ToString(LibraryMOD.GetRegCoursesPrevSem(sNo, iRegYear, iRegSem, (InitializeModule.EnumCampus)Campus));

                //Hr.Cells.Add(Hd);

                //MyTable.Rows.Add(Hr);
                //-------------------------------------------
                //Third Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "CGPA : ";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                if (myMirror.CGPA != 101)
                {
                    Hd.Text = string.Format("{0:F}", myMirror.CGPA);
                }
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                Hc = new TableHeaderCell();
                Hc.Text = "Advisor : ";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = LibraryMOD.GetAdvisorEmail(myMirror.Advisor);
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);
                MyTable.Rows.Add(Hr);

                ////Get Max Esl
                //for (int i = 0; i < 5; i++)
                //{
                //    if (myMirror.Mirror[i].isPassed)
                //    {
                //        Hd.Text = myMirror.Mirror[i].sCourse;
                //        myList[0].MaxESL = i;
                //    }

                //}

                //Fourth Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "ENG : ";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = myMirror.ENG;
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                Hc = new TableHeaderCell();
                Hc.Text = "Score : ";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);

                Hd = new TableCell();

                Hd.Text = string.Format("{0:F}", myMirror.Score); ;
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);

                ////Fifth Row
                //Hr = new TableHeaderRow();

                //Hc = new TableHeaderCell();
                //Hc.Text = "Advisor : ";
                //Hr.Cells.Add(Hc);

                //Hd = new TableCell();
                //Hd.ColumnSpan = 3;
                //Hd.Text = myMirror.Advisor;
                //Hr.Cells.Add(Hd);

                //MyTable.Rows.Add(Hr);


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return MyTable;
        }

        private void Export()
        {
            ReportDocument myReport = new ReportDocument();
            List<Programs_Advisors> myAdvisors = new List<Programs_Advisors>();
            Programs_AdvisorsDAL myAdvisorsDAL = new Programs_AdvisorsDAL();
            RecommendationDAL myRecommendationDAL = new RecommendationDAL();

            try
            {
                MirrorCLS myMirror = new MirrorCLS();
                myMirror = myList[0];

                DataSet rptDS = new DataSet();


                rptDS = myRecommendationDAL.Prepare_RecommendationReport(myMirror);

                string reportPath = Server.MapPath("Reports/Recommended_Report3.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                TextObject txt;
                int iCount = myMirror.Mirror.Length;
                if (iCount > 60) iCount = 60;
                for (int i = 0; i < 60; i++)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["h" + (i + 1).ToString()];
                    txt.Text = "";
                    txt.Color = Color.White;
                    txt.Color = Color.White;
                    txt.Border.BorderColor = Color.White;
                    txt.Border.BackgroundColor = Color.White;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["g" + (i + 1).ToString()];
                    txt.Text = "";
                    txt.Color = Color.White;
                    txt.Border.BorderColor = Color.White;
                    txt.Border.BackgroundColor = Color.White;
                }

                for (int i = 0; i < iCount; i++)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["h" + (i + 1).ToString()];
                    txt.Text = myMirror.Mirror[i].sCourse;
                    switch (myMirror.Mirror[i].iClass)
                    {
                        case 9://MEelect
                            txt.Text = myMirror.Mirror[i].sCourse + "*";
                            break;
                        case 11://CEelect
                            txt.Text = myMirror.Mirror[i].sCourse + "#";
                            break;
                    }
                    txt.Color = Color.Black;
                    txt.Border.BorderColor = Color.Black;
                    txt.Border.BackgroundColor = Color.Silver;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["g" + (i + 1).ToString()];
                    txt.Text = myMirror.Mirror[i].sGrade;
                    txt.Color = Color.Black;
                    txt.Border.BorderColor = Color.Black;
                    txt.Border.BackgroundColor = Color.White;
                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Major_txt"];
                txt.Text = myMirror.Major;

                //Previous Semester
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtregisteredCourseInPrevSem"];
                if (iRegSem == 4)
                {
                    int iRegCoursesPrevSem = 0;
                    iRegCoursesPrevSem = LibraryMOD.GetRegCoursesPrevSem(myMirror.StudentNumber, iRegYear, iRegSem, Campus);

                    txt.Text = "Previous Semester Courses : " + iRegCoursesPrevSem.ToString();
                }
                else
                {
                    txt.Text = "";
                    txt.Width = 0;
                }


                txt = (TextObject)myReport.ReportDefinition.ReportObjects["cgpa_txt"];
                if (myMirror.CGPA != 101)
                {
                    txt.Text = string.Format("{0:f}", myMirror.CGPA);
                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["esl_txt"];
                txt.Text = myMirror.Mirror[myMirror.MaxESL].sCourse;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["eng_txt"];
                txt.Text = myMirror.ENG;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["score_txt"];
                txt.Text = string.Format("{0:f}", myMirror.Score);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Session_txt"];
                txt.Text = myMirror.Period;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Term_txt"];
                string sTerm = LibraryMOD.GetTermDesc(iRegYear, iRegSem);

                txt.Text = sTerm;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Advisor_txt"];
                txt.Text = LibraryMOD.GetAdvisorEmail(myMirror.Advisor);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                txt.Text = myMirror.StudentNumber + " - " + myMirror.Name;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = sUserName;

                //coordinator_txt

                //advisors_txt

                string sCoordinator = "";
                string sAdvisors = "";
                string sMajor = "";
                List<Applications> myStudent = new List<Applications>();
                ApplicationsDAL myApplicationsDAL = new ApplicationsDAL();
                myStudent = myApplicationsDAL.GetList(Campus, " lngStudentNumber='" + myMirror.StudentNumber + "'", false);
                if (myStudent.Count > 0)
                {
                    sMajor = myStudent[0].strSpecialization;
                }
                myStudent.Clear();

                myAdvisors = myAdvisorsDAL.GetPrograms_Advisors(Campus, sMajor);
                for (int i = 0; i < myAdvisors.Count; i++)
                {
                    if (myAdvisors[i].byteCategory == 1)
                    {
                        sCoordinator += LibraryMOD.GetAdvisorEmail(myAdvisors[i].SAdvisor);
                    }
                    else
                    {
                        sAdvisors += LibraryMOD.GetAdvisorEmail(myAdvisors[i].SAdvisor) + ",";
                    }

                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["coordinator_txt"];
                txt.Text = sCoordinator;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["advisors_txt"];
                txt.Text = sAdvisors;

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
            finally
            {
                myAdvisors.Clear();
                myReport.Close();
                myReport.Dispose();
            }
        }

        //private DataSet Prepare_Report(MirrorCLS myMirror)
        //{

        //    DataTable dt = new DataTable();
        //    DataTable dtMirror = new DataTable();

        //    DataRow dr;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        DataColumn dc;

        //        dc = new DataColumn("StudentID", Type.GetType("System.String"));
        //        dtMirror.Columns.Add(dc);
        //        dc = new DataColumn("Course", Type.GetType("System.String"));
        //        dtMirror.Columns.Add(dc);
        //        dc = new DataColumn("Grade", Type.GetType("System.String"));
        //        dtMirror.Columns.Add(dc);

        //        dc = new DataColumn("StudentID", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("iOrder", Type.GetType("System.Int32"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sCourse", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sDesc", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("bShift", Type.GetType("System.Int16"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sTimeFrom", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sTimeTo", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sDays", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("bClass", Type.GetType("System.Int16"));
        //        dt.Columns.Add(dc);
        //        dc = new DataColumn("sLecturer", Type.GetType("System.String"));
        //        dt.Columns.Add(dc);

        //        int iCount = myMirror.Mirror.Length;


        //        for (int m = 0; m < iCount; m++)
        //        {
        //            dr = dtMirror.NewRow();

        //            dr["StudentID"] = myMirror.StudentNumber;
        //            dr["Course"] = myMirror.Mirror[m].sCourse;
        //            dr["Grade"] = myMirror.Mirror[m].sGrade;

        //            dtMirror.Rows.Add(dr);
        //        }

        //        int iRecommended = myMirror.Recommended.Count;

        //        for (int i = 0; i < iRecommended; i++)
        //        {
        //            dr = dt.NewRow();

        //            dr["StudentID"] = myMirror.StudentNumber;
        //            dr["iOrder"] = i + 1;
        //            dr["sCourse"] = myMirror.Recommended[i].sCourse;
        //            dr["sDesc"] = myMirror.Recommended[i].sDesc;
        //            dr["bShift"] = 0;
        //            dr["sTimeFrom"] = ".";
        //            dr["sTimeTo"] = ".";
        //            if (myMirror.Recommended[i].isOver)
        //            {
        //                dr["sDays"] = "أخرى تم ترشيحها - Other";
        //            }
        //            else if (myMirror.Recommended[i].isLow)
        //            {
        //                dr["sDays"] = "ينصح بشدة - High";
        //            }
        //            else
        //            {
        //                dr["sDays"] = "ينصح به - Recommended";
        //            }
        //            dr["bClass"] = 0;
        //            dr["sLecturer"] = ".";

        //            dt.Rows.Add(dr);
        //        }
        //        //Add 3 Empty Rows
        //        for (int i = iRecommended; i < iRecommended + 2; i++)
        //        {
        //            dr = dt.NewRow();

        //            dr["iOrder"] = i + 1;
        //            dr["sCourse"] = "-";
        //            dr["sDesc"] = "-";
        //            dr["bShift"] = 0;
        //            dr["sTimeFrom"] = ".";
        //            dr["sTimeTo"] = ".";
        //            dr["sDays"] = ".";
        //            dr["bClass"] = 0;
        //            dr["sLecturer"] = ".";

        //            dt.Rows.Add(dr);
        //            //Collect Additional Times
        //        }
        //        dt.TableName = "Recommended";
        //        dt.AcceptChanges();
        //        ds.Tables.Add(dt);

        //        dtMirror.TableName = "Mirror";
        //        dtMirror.AcceptChanges();
        //        ds.Tables.Add(dtMirror);

        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //    }
        //    finally
        //    {

        //    }
        //    return ds;
        //}
        private DataSet Prepare_TimeTable_Report(List<TimeTable> myTimeTable)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iPeriod", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPeriod", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDesc", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iClass", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dFrom", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dTo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iLecturer", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sLecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iDays", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDay", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sHall", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("seBookCode", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                int Serial = 0;
                for (int i = 0; i < myTimeTable.Count; i++)
                {
                    dr = dt.NewRow();
                    Serial += 1;
                    dr["iSerial"] = Serial;
                    dr["sPeriod"] = myTimeTable[i].SPeriod;
                    dr["sCourse"] = myTimeTable[i].SCourse;
                    dr["sDesc"] = myTimeTable[i].SDesc;
                    dr["iClass"] = myTimeTable[i].IClass;
                    //add Times
                    dr["sLecturer"] = myTimeTable[i].ClassTimes[0]._sLecturer;
                    dr["dFrom"] = myTimeTable[i].ClassTimes[0]._dFrom.ToShortTimeString();
                    dr["dTo"] = myTimeTable[i].ClassTimes[0]._dTo.ToShortTimeString();
                    dr["iDays"] = myTimeTable[i].ClassTimes[0]._iDays;
                    dr["sDay"] = myTimeTable[i].ClassTimes[0]._sDays + "  " + myTimeTable[i].ClassTimes[0]._sNotes;
                    dr["sHall"] = myTimeTable[i].ClassTimes[0]._sHall + " | " + myTimeTable[i].ClassTimes[0]._sCampus;
                    dr["seBookCode"] = myTimeTable[i].ClassTimes[0]._seBookCode;
                    dt.Rows.Add(dr);
                    //Collect Additional Times
                    for (int j = 1; j < myTimeTable[i].ClassTimes.Count; j++)
                    {
                        dr = dt.NewRow();
                        Serial += 1;
                        dr["iSerial"] = Serial;
                        dr["sPeriod"] = myTimeTable[i].SPeriod;
                        dr["sCourse"] = myTimeTable[i].SCourse;
                        dr["sDesc"] = myTimeTable[i].SDesc;
                        dr["iClass"] = myTimeTable[i].IClass;
                        dr["sLecturer"] = myTimeTable[i].ClassTimes[j]._sLecturer;
                        dr["dFrom"] = myTimeTable[i].ClassTimes[j]._dFrom.ToShortTimeString();
                        dr["dTo"] = myTimeTable[i].ClassTimes[j]._dTo.ToShortTimeString();
                        dr["iDays"] = myTimeTable[i].ClassTimes[j]._iDays;
                        dr["sDay"] = myTimeTable[i].ClassTimes[j]._sDays + "  " + myTimeTable[i].ClassTimes[j]._sNotes;
                        dr["sHall"] = myTimeTable[i].ClassTimes[j]._sHall + " | " + myTimeTable[i].ClassTimes[0]._sCampus;
                        dt.Rows.Add(dr);
                    }


                }
                dt.TableName = "StudentTimeTable";
                dt.AcceptChanges();
                ds.Tables.Add(dt);
                TimeTable_Grd.PageIndex = 0;
                TimeTable_Grd.DataSource = dt;
                TimeTable_Grd.DataBind();

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
            return ds;
        }

        private void Retrieve()
        {
            List<TimeTable> myTimeTables = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();
            DataSet Ds = new DataSet();
            try
            {
                int iYear = iRegYear;
                int iSem = iRegSem;
                string sStudentNumber = this.sNo;

                myTimeTables = myTimeTableDAL.GetStudentTimeTable(sStudentNumber, iYear, iSem, this.Campus);
                Ds = Prepare_TimeTable_Report(myTimeTables);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

                Session["ReportDS"] = Ds;

            }

        }
        protected void Print_btn_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Advising,
                    InitializeModule.enumPrivilege.Print, this.CurrentRole) != true)
            {
                showmsg("Sorry, You don't have the permission to print...");
                return;
            }
            Export();
        }
        protected void Reg_btn_Click(object sender, ImageClickEventArgs e)
        {

        }

        //private System.Web.UI.WebControls.Table Create_Rec_Table(MirrorCLS myMirror)
        //{
        //    System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();
        //    try
        //    {
        //        myList.Add(myMirror);
        //        //First Row
        //        MyTable.Width = Unit.Percentage(100);
        //        MyTable.BorderWidth = 1;
        //        MyTable.GridLines = GridLines.Horizontal;

        //        TableHeaderRow Hr = new TableHeaderRow();
        //        TableHeaderCell Hc = new TableHeaderCell();

        //        //Fifth
        //        Hr = new TableHeaderRow();
        //        Hc = new TableHeaderCell();
        //        Hc.ColumnSpan = 4;
        //        Hc.Text = "Student Mirror";
        //        Hr.Cells.Add(Hc);
        //        MyTable.Rows.Add(Hr);

        //        Hr = new TableHeaderRow();
        //        Hc = new TableHeaderCell();
        //        Hc.ColumnSpan = 4;
        //        Hc.Text = "General Courses";
        //        Hr.Cells.Add(Hc);
        //        MyTable.Rows.Add(Hr);

        //        TableRow Tr = new TableRow();
        //        TableCell Tc = new TableCell();
        //        Tc.ColumnSpan = 4;


        //        string sPath = "";
        //        string sTable = "<table align='left' border='1' >";
        //        sTable += "<tr>";

        //        int iMax = 0;
        //        string sDegree = myMirror.SDegree;
        //        string sMajor = myMirror.SMajor;
        //        //Get the count of general courses
        //        iMax = LibraryMOD.GetMajorGeneralIndex(sDegree, sMajor);

        //        for (int i = 0; i < iMax; i++)
        //        {
        //            sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
        //            sTable += "<td><img alt='' src='" + sPath + "' /></td>";
        //        }
        //        sTable += "</tr>";
        //        sTable += "<tr>";
        //        for (int i = 0; i < iMax; i++)
        //        {

        //            if (myMirror.Mirror[i].isRecommended)
        //            {
        //                sTable += "<td bgcolor='#CC3300'>" + myMirror.Mirror[i].sGrade + "</td>";
        //            }
        //            else
        //            {
        //                sTable += "<td>" + myMirror.Mirror[i].sGrade + "</td>";
        //            }
        //        }
        //        sTable += "</tr>";
        //        sTable += "</table>";

        //        Literal Lt = new Literal();
        //        Lt.Text = sTable;
        //        Tc.Controls.Add(Lt);
        //        Tr.Cells.Add(Tc);

        //        MyTable.Rows.Add(Tr);


        //        //Sixth
        //        Hr = new TableHeaderRow();
        //        Hc = new TableHeaderCell();
        //        Hc.ColumnSpan = 4;
        //        Hc.Text = "Other Courses";
        //        Hr.Cells.Add(Hc);
        //        MyTable.Rows.Add(Hr);

        //        Tr = new TableRow();
        //        Tc = new TableCell();
        //        Tc.ColumnSpan = 4;

        //        int iCourses = 0;
        //        iCourses = myMirror.Mirror.Length;

        //        sPath = "";
        //        sTable = "<table align='left' border='1' >";
        //        sTable += "<tr>";
        //        for (int i = iMax; i < iCourses; i++)
        //        {
        //            sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
        //            sTable += "<td><img alt='' src='" + sPath + "' /></td>";
        //        }
        //        sTable += "</tr>";
        //        sTable += "<tr>";
        //        for (int i = iMax; i < iCourses; i++)
        //        {

        //            if (myMirror.Mirror[i].isRecommended)
        //            {
        //                sTable += "<td bgcolor='#CC3300'>" + myMirror.Mirror[i].sGrade + "</td>";
        //            }
        //            else
        //            {
        //                sTable += "<td>" + myMirror.Mirror[i].sGrade + "</td>";
        //            }
        //        }
        //        sTable += "</tr>";
        //        sTable += "</table>";

        //        Lt = new Literal();
        //        Lt.Text = sTable;
        //        Tc.Controls.Add(Lt);
        //        Tr.Cells.Add(Tc);

        //        MyTable.Rows.Add(Tr);
        //        //Majoe Electives & Free Electives
        //        MirrorDAL myMirrorDAL = new MirrorDAL();


        //        string MElective = myMirrorDAL.GetMajorElectiveCourses(myMirror.StudentNumber, Campus);
        //        string FElective = myMirrorDAL.GetFreeElectiveCourses(myMirror.StudentNumber, Campus);
        //        if (MElective.Length > 0 || FElective.Length > 0)
        //        {
        //            Hr = new TableHeaderRow();
        //            Hc = new TableHeaderCell();
        //            Hc.ColumnSpan = 4;
        //        }
        //        Hc.Text = "";
        //        if (MElective.Length > 0)
        //        {
        //            Hc.Text += "Major Electives: " + "[ " + MElective + " ]";
        //        }

        //        if (FElective.Length > 0)
        //        {
        //            if (MElective.Length > 0)
        //            {
        //                Hc.Text += " --- ";
        //            }
        //            Hc.Text += "Free Electives [" + FElective + " ]";
        //        }
        //        if (MElective.Length > 0 || FElective.Length > 0)
        //        {
        //            Hr.Cells.Add(Hc);
        //            MyTable.Rows.Add(Hr);
        //        }
        //        //Recommended
        //        Hr = new TableHeaderRow();
        //        Hc = new TableHeaderCell();
        //        Hc.ColumnSpan = 4;
        //        Hc.Text = "Recommended Courses";
        //        Hr.Cells.Add(Hc);
        //        MyTable.Rows.Add(Hr);

        //        int iRegCoursesPrevSem = 0;
        //        int iAllowedCourses = 0;
        //        iRegCoursesPrevSem = LibraryMOD.GetRegCoursesPrevSem(sNo, iRegYear, iRegSem, (InitializeModule.EnumCampus)Campus);
        //        if (iRegCoursesPrevSem < 4)
        //        {
        //            iAllowedCourses = 4 - iRegCoursesPrevSem;
        //        }

        //        int iCompletedHours = LibraryMOD.GetCompletedHours(sNo, Campus);

        //        for (int i = 0; i < myMirror.Recommended.Count; i++)
        //        {
        //            if ((iCompletedHours < 99 && myMirror.Recommended[i].sCourse.Contains("415") && myMirror.Recommended[i].sCourse != "RTV415") || (iCompletedHours < 99 && myMirror.Recommended[i].sCourse.Contains("419")))
        //            {
        //                //dont add Internship & graduation project in completed hours less than 99 credit hours
        //            }
        //            else
        //            {
        //                Tr = new TableRow();
        //                if (myMirror.Recommended[i].isOver)
        //                {
        //                    Tr.CssClass = "R_Critical";
        //                }
        //                else
        //                {
        //                    if (i % 2 == 0)
        //                    {
        //                        Tr.CssClass = "R_NormalWhite";
        //                    }
        //                    else
        //                    {
        //                        Tr.CssClass = "R_NormalGray";
        //                    }
        //                }
        //                Tc = new TableCell();
        //                Tc.Text = (i + 1).ToString();
        //                Tc.HorizontalAlign = HorizontalAlign.Center;
        //                Tr.Cells.Add(Tc);

        //                Tc = new TableCell();
        //                Tc.Text = myMirror.Recommended[i].sCourse;
        //                Tc.HorizontalAlign = HorizontalAlign.Center;
        //                Tr.Cells.Add(Tc);

        //                Tc = new TableCell();
        //                Tc.ColumnSpan = 2;
        //                Tc.Text = myMirror.Recommended[i].sDesc;
        //                Tc.HorizontalAlign = HorizontalAlign.Left;
        //                Tr.Cells.Add(Tc);

        //                MyTable.Rows.Add(Tr);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LibraryMOD.ShowErrorMessage(ex);

        //    }
        //    finally
        //    {


        //    }
        //    return MyTable;
        //}

        private System.Web.UI.WebControls.Table Create_Rec_Table(MirrorCLS myMirror)
        {
            System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();
            try
            {
                myList.Add(myMirror);
                //First Row
                MyTable.Width = Unit.Percentage(100);
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Horizontal;


                TableRow tr = new TableRow();
                TableCell td = new TableCell();


                //Fifth
                tr.CssClass = "th";
                td.ColumnSpan = 4;
                td.Text = "Student Mirror";
                tr.Cells.Add(td);
                MyTable.Rows.Add(tr);

                tr = new TableRow();
                td = new TableCell();
                td.ColumnSpan = 4;


                string sPath = "";
                string sTable = "<table align='left' border='1' >";
                sTable += "<tr>";

                int iMax = 0;
                string sDegree = myMirror.SDegree;
                string sMajor = myMirror.SMajor;
                //Get the count of general courses
                iMax = LibraryMOD.GetMajorGeneralIndex(sDegree, sMajor);

                for (int i = 0; i < iMax; i++)
                {
                    sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    sTable += "<td><img alt='' src='" + sPath + "' /></td>";
                }
                sTable += "</tr>";
                sTable += "<tr>";

                for (int i = 0; i < iMax; i++)
                {

                    if (myMirror.Mirror[i].isRecommended)
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top; background-color: #F2B702'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                    else
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                }
                sTable += "</tr>";
                sTable += "</table>";

                Literal Lt = new Literal();
                Lt.Text = sTable;
                td.Controls.Add(Lt);
                tr.Cells.Add(td);

                MyTable.Rows.Add(tr);

                tr = new TableRow();
                td = new TableCell();
                td.ColumnSpan = 4;

                int iCourses = 0;
                iCourses = myMirror.Mirror.Length;

                sPath = "";
                sTable = "<table align='left' border='1' >";
                sTable += "<tr>";
                for (int i = iMax; i < iCourses; i++)
                {
                    sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    sTable += "<td><img alt='' src='" + sPath + "' /></td>";
                }
                sTable += "</tr>";
                sTable += "<tr>";
                for (int i = iMax; i < iCourses; i++)
                {

                    if (myMirror.Mirror[i].isRecommended)
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top; background-color: #F2B702'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                    else
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                }
                sTable += "</tr>";
                sTable += "</table>";

                Lt = new Literal();
                Lt.Text = sTable;
                td.Controls.Add(Lt);
                tr.Cells.Add(td);

                MyTable.Rows.Add(tr);

                //Majoe Electives & Free Electives
                MirrorDAL myMirrorDAL = new MirrorDAL();

                tr = new TableRow();
                td = new TableCell();
                td.ColumnSpan = 4;

                string MElective = myMirrorDAL.GetMajorElectiveCourses(myMirror.StudentNumber, Campus);
                string FElective = myMirrorDAL.GetFreeElectiveCourses(myMirror.StudentNumber, Campus);
                if (MElective.Length > 0 || FElective.Length > 0)
                {
                    tr = new TableRow();
                    td = new TableCell();
                    td.ColumnSpan = 4;
                }
                td.Text = "";
                if (MElective.Length > 0)
                {
                    td.Text += "Major Electives: " + "[ " + MElective + " ]";
                }

                if (FElective.Length > 0)
                {
                    if (MElective.Length > 0)
                    {
                        td.Text += " --- ";
                    }
                    td.Text += "Free Electives [" + FElective + " ]";
                }
                if (MElective.Length > 0 || FElective.Length > 0)
                {
                    tr.Cells.Add(td);
                    MyTable.Rows.Add(tr);
                }

                //Recommended
                tr = new TableRow();
                td = new TableCell();

                tr.CssClass = "th";
                td.ColumnSpan = 4;
                td.Text = "Recommended Courses";

                tr.Cells.Add(td);
                MyTable.Rows.Add(tr);

                int iCompletedHours = LibraryMOD.GetCompletedHours(sNo, Campus);

                //Tr=new TableRow();
                for (int i = 0; i < myMirror.Recommended.Count; i++)
                {
                    if ((iCompletedHours < 99 && myMirror.Recommended[i].sCourse.Contains("415") && myMirror.Recommended[i].sCourse != "RTV415") || (iCompletedHours < 99 && myMirror.Recommended[i].sCourse.Contains("419")))
                    {
                        //dont add Internship & graduation project in completed hours less than 99 credit hours
                    }
                    else
                    {
                        tr = new TableRow();
                        if (myMirror.Recommended[i].isOver)
                        {
                            tr.CssClass = "R_Critical";
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                tr.CssClass = "R_NormalWhite";
                            }
                            else
                            {
                                tr.CssClass = "R_NormalGray";
                            }
                        }
                        td = new TableCell();
                        td.Text = (i + 1).ToString();
                        td.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = myMirror.Recommended[i].sCourse;
                        td.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.ColumnSpan = 2;
                        td.Text = myMirror.Recommended[i].sDesc;
                        td.HorizontalAlign = HorizontalAlign.Left;
                        tr.Cells.Add(td);

                        MyTable.Rows.Add(tr);
                    }
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return MyTable;
        }

        public void htmltoimage(string htmltext)
        {
            // read parameters from the webpage
            string htmlString = htmltext;
            string baseUrl = "";

            string image_format = "jpg";
            ImageFormat imageFormat = ImageFormat.Png;
            if (image_format == "jpg")
            {
                imageFormat = ImageFormat.Jpeg;
            }
            else if (image_format == "bmp")
            {
                imageFormat = ImageFormat.Bmp;
            }

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(webPageWidth);
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(webPageHeight);
            }
            catch { }

            // instantiate a html to image converter object
            HtmlToImage imgConverter = new HtmlToImage();

            // set converter options
            imgConverter.WebPageWidth = webPageWidth;
            imgConverter.WebPageHeight = webPageHeight;

            // create a new image converting an url
            System.Drawing.Image image =
                imgConverter.ConvertHtmlString(htmlString, baseUrl);

            string filename = Session["CurrentStudent"].ToString() + "_" + DateTime.Now.ToString("ddMMyyyy") + "." + image_format;


            string imagePath = Server.MapPath("~/StudentAcceptance/" + filename);

            // send image to browser
            //Response.Clear();
            //Response.ClearHeaders();
            //Response.AddHeader("Content-Type", "image/" +
            //    imageFormat.ToString().ToLower());
            //Response.AppendHeader("content-disposition",
            //    "attachment;filename=\""+ filename + "." + image_format + "\"");
            image.Save(imagePath, imageFormat);
            // Response.End();
        }

        protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
        {
            try
            {
                if (Wizard1.ActiveStepIndex == 1)
                {
                    string html1 = String.Empty;
                    using (TextWriter myTextWriter1 = new StringWriter(new StringBuilder()))
                    {
                        using (HtmlTextWriter myWriter1 = new HtmlTextWriter(myTextWriter1))
                        {
                            divDetail.RenderControl(myWriter1);
                            html1 = myTextWriter1.ToString();
                        }
                    }

                    string html = String.Empty;
                    using (TextWriter myTextWriter = new StringWriter(new StringBuilder()))
                    {
                        using (HtmlTextWriter myWriter = new HtmlTextWriter(myTextWriter))
                        {
                            WizardStep1.RenderControl(myWriter);
                            html = html1 + "<br/><hr/><br/>" + myTextWriter.ToString();
                            htmltoimage(html);
                        }
                    }

                    System.Web.UI.WebControls.Table Advising_tbl = Create_Rec_Table(myList[0]);
                    Advising_pnl.Controls.Clear();
                    Advising_pnl.Controls.Add(Advising_tbl);


                }
                else if (Wizard1.ActiveStepIndex == 2)
                {
                    if (Enable_Disable(sNo, Campus))
                    {
                        Session["iFormNumber"] = this.CreateHeader();
                    }
                    else
                    {
                        Wizard1.ActiveStepIndex = 3;
                    }
                }
                else if (Wizard1.ActiveStepIndex == 3)
                {
                    Retrieve();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        private void ExportStudentTimeTable()
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                DataSet rptDS = new DataSet();

                rptDS = (DataSet)Session["ReportDS"];

                string reportPath = Server.MapPath("Reports/StudentTimeTable_eBooksRPT.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                int iSemester = Convert.ToInt32("0" + Session["RegSemester"].ToString());
                int iRegYear = Convert.ToInt32("0" + Session["RegYear"].ToString());
                string sNo = Session["CurrentStudent"].ToString();

                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];
                txt.Text = GetCaption();
                txt.Text += "     -   Total Credit Hours: [ " + LibraryMOD.GetStudentRegisteredCredit(iRegYear, iSemester, sNo, Convert.ToInt32((InitializeModule.EnumCampus)this.Campus)).ToString() + " ]";

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtMajor"];
                txt.Text = LibraryMOD.GetStudentMajor(this.Campus, sNo);

                string sSemester = LibraryMOD.GetSemesterString(iSemester);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtAcademicYear"];
                txt.Text += " - " + iRegYear.ToString() + " / " + (iRegYear + 1).ToString() + " " + sSemester;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = "/ " + sUserName;


                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }
        private string GetCaption()
        {
            string sCaption = "";
            try
            {
                string sNo = Session["CurrentStudent"].ToString();
                string sName = Session["CurrentStudentName"].ToString();
                sCaption = sNo.Replace(".", "") + " - " + sName;
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }

            return sCaption;

        }
        private int CreateHeader()
        {
            int iFormNumber = 0;
            try
            {
                string sStudentNumber = "";

                if (Session["myList"] != null)
                {
                    List<MirrorCLS> myList = (List<MirrorCLS>)Session["myList"];
                    sStudentNumber = myList[0].StudentNumber;
                }
                else
                {
                    showmsg("Mirror is empty.");
                    return -1;
                }

                int iYear = iRegYear;
                int iSemester = iRegSem;

                Course_HeaderDAL myCourseHeader = new Course_HeaderDAL();
                iFormNumber = myCourseHeader.IsHeaderExists(this.Campus, iYear, iSemester, 1, sStudentNumber);



                if (iFormNumber == -1)
                {
                    Connection_StringCLS MyConnection_string = new Connection_StringCLS(this.Campus);
                    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
                    Conn.Open();
                    iFormNumber = LibraryMOD.GetMaxID(Conn, "intFormNumber", "Reg_Course_Header", "intStudyYear=" + iYear + " AND byteSemester=" + iSemester + " AND byteForm=1");
                    iFormNumber++;
                    Conn.Close();

                    int iMode = (int)InitializeModule.enumModes.NewMode;

                    string sPCName = "ECTSIS";//Session["CurrentPCName"].ToString();
                    string sUserName = Session["CurrentUserName"].ToString();
                    string sNetUserName = Session["CurrentNetUserName"].ToString();

                    int iSuccess = myCourseHeader.UpdateCourse_Header(this.Campus, iMode, iYear, iSemester, 1, iFormNumber, sStudentNumber, DateTime.Now, 0, 0, 0, "", 0, "", DateTime.Now, "", "", DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);

                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return iFormNumber;

        }
        protected void Read_chk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Read_chk.Checked)
                {
                    Read_txt.Text = "Skip";
                }
                else
                {
                    Read_txt.Text = "";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }


        }

        //handling add link in GridView1
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                        InitializeModule.enumPrivilege.AddCourse, this.CurrentRole) != true)
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to add a course.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }


                int iSelectedIndex = GridView1.SelectedIndex;

                int iYear = iRegYear;
                int iSemester = iRegSem;

                string sCourse = GridView1.DataKeys[iSelectedIndex].Values["strCourse"].ToString();


                //Check if it is Internship Course
                if (sCourse == "ACC204" || sCourse == "BAF207" || sCourse == "BIS200"
                    || sCourse == "HRM208" || sCourse == "MAR205" || sCourse == "MCPR207"
                    || sCourse == "JOR308" || sCourse == "MCPR208A" || sCourse == "MGN208" || sCourse == "PRD308" || sCourse == "RTV308"
                    || sCourse == "BUS419" || sCourse == "ACC419" || sCourse == "BAF419" || sCourse == "IBAF419"
                    || sCourse == "HRM419" || sCourse == "HIM419" || sCourse == "BIM419")
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to add an internship course,The registrar only can add it for you.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }
                //Check if it is graduation project Course
                if (sCourse == "ACC415" || sCourse == "BAF415" || sCourse == "BIT415" || sCourse == "IBAF415"
                    || sCourse == "HRM415" || sCourse == "HIM415" || sCourse == "BIM415" || sCourse == "BUS415"
                    || sCourse == "PRD407" || sCourse == "RTV407" || sCourse == "JOR407"
                   )
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to add a graduation project course,The registrar only can add it for you.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }
                int iClass = int.Parse(GridView1.DataKeys[iSelectedIndex].Values["byteClass"].ToString());
                int iShift = int.Parse(GridView1.DataKeys[iSelectedIndex].Values["byteShift"].ToString());

                int iFormNumber = int.Parse(Session["iFormNumber"].ToString());
                string sStudentNumber = Session["CurrentStudent"].ToString();

                //=========================================================
                int iPeriod = 0;
                InitializeModule.EnumCampus CourseCampus = LibraryMOD.SyncCampusAndSession(iShift.ToString(), out iPeriod);
                if (CourseCampus != Campus)
                {
                    Campus = CourseCampus;
                    Get_Student_Advising();
                    Session["iFormNumber"] = this.CreateHeader();
                }
                //=========================================================
                MirrorCLS myMirror = ((List<MirrorCLS>)Session["myList"])[0];
                Plans myPlan = (Plans)Session["myPlan"];
                RegValidation validation = new RegValidation(this.Campus, this.CurrentRole, myMirror, myPlan, sCourse, iYear, iSemester, iShift, iClass);


                if (validation.isHasCorequisites() && !sCourse.Contains("ESL"))
                {
                    //update student mirror
                    Get_Student_Advising();
                    //MirrorCLS myMirror = myList[0];
                    if (!validation.isCorequisites_Registered())
                    {
                        string sScript = "$(function(){ $('#divConfirmation').html('Course co-requisite is not registered.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                        return;
                    }
                }

                //iRegYear = (int)Session["RegYear"];
                //iRegSem = (int)Session["RegSemester"];

                if (validation.validate(Page, iRegYear, iRegSem))
                {
                    Connection_StringCLS MyConnection_string = new Connection_StringCLS(this.Campus);
                    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
                    Conn.Open();
                    int iTrans = LibraryMOD.GetMaxID(Conn, "byteTrans", "Reg_Course_Detail", "intStudyYear=" + iYear + " AND byteSemester=" + iSemester + " AND byteForm=1 AND intFormNumber=" + iFormNumber + " AND strCourse='" + sCourse + "' AND byteClass=" + iClass + " AND byteShift=" + iShift);
                    iTrans++;
                    Conn.Close();
                    int iMode = (int)InitializeModule.enumModes.NewMode;
                    string sPCName = "ECTSIS"; //Session["CurrentPCName"].ToString();
                    string sUserName = Session["CurrentUserName"].ToString();
                    string sNetUserName = Session["CurrentURL"].ToString();//Session["CurrentNetUserName"].ToString();

                    Course_DetailDAL myCourseDetail = new Course_DetailDAL();
                    myCourseDetail.UpdateCourse_Detail(this.Campus, iMode, iYear, iSemester, 1, iFormNumber, sCourse, iClass, iShift, iTrans, "True", "", "", 0, sUserName, DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);
                    if (sCourse == "ESL100" || sCourse == "ESL102")
                    {
                        switch (sCourse)
                        {
                            case "ESL100":
                                sCourse = "ESL101 50%";
                                break;
                            case "ESL102":
                                sCourse = "ESL103 50%";
                                break;
                        }
                        myCourseDetail.UpdateCourse_Detail(this.Campus, iMode, iYear, iSemester, 1, iFormNumber, sCourse, iClass, iShift, iTrans, "True", "", "", 0, sUserName, DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);
                    }
                    Reg_grd.DataBind();
                    if (Reg_grd.Rows.Count > 0)
                    {
                        //Update Registration Status - Status Registered

                        //Check Email exists or not
                        string studentid = Session["CurrentStudent"].ToString();
                        var services = new DAL.DAL();
                        Connection_StringCLS connstr = new Connection_StringCLS(Campus);
                        DataTable dtStudentServices = services.GetStudentDetailsID(studentid, connstr.Conn_string);
                        string emailid= dtStudentServices.Rows[0]["sECTemail"].ToString();
                        string fname= dtStudentServices.Rows[0]["strFirstDescEn"].ToString();
                        string lname = dtStudentServices.Rows[0]["strSecondDescEn"].ToString();
                        hdnStudentMajor.Value= dtStudentServices.Rows[0]["strCaption"].ToString();

                        if (emailid!=""&&emailid!=null)
                        {
                            //Don't Call Email Creation function
                        }
                        else
                        {
                            string sSID = Session["CurrentStudent"].ToString();
                            int iSerial = GetSerial(sSID);
                            Session["StudentSerialNo"] = iSerial;
                            hdnSerial.Value = iSerial.ToString();
                            int iCSem = 0;
                            int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
                            Session["CurrentYear"] = iCYear;
                            Session["CurrentSemester"] = iCSem;
                            int iRegisteredHours = LibraryMOD.GetCurrentRegisteredCourses(this.Campus, sSID, iCYear, iCSem);
                            if (iRegisteredHours == 0)
                            {
                                //lbl_Msg.Text = "Student must register courses before creating email.";
                                //div_msg.Visible = true;
                                return;
                            }
                            //======= Generate Student email
                            CreateStudentEmail(lname);
                            if (hdnStudentEmail.Value.Length < 17)
                            {
                                return;
                            }
                            //======= Create email in Office365 & AD 
                            CreateStudentEmailAD(this.Campus, sSID);

                            //======= Create Moodle Account
                            if (ClsMoodleAPI.CreateUpdateMoodleAccount(hdnStudentEmail.Value, sSID) == InitializeModule.SUCCESS_RET)
                            {
                                hdnMsg.Value += " & Moodle";
                            }
                            //======== Enroll student in Moodle courses
                            if (ClsMoodleAPI.EnrollStudentinMoodleCourses(hdnStudentEmail.Value, sSID) == InitializeModule.SUCCESS_RET)
                            {
                                hdnMsg.Value += ", Student enrolled in Moodle courses";
                            }
                            //======= Create Zoom Account
                            string sFirstName = fname + " " + lname;
                            string sLastName = " - " + sSID;
                            CreateZoomAccount(hdnStudentEmail.Value, sFirstName, sLastName);
                        }

                        //API Call-Update Registration Status
                        apicall_UpdateRegistrationStatus(Reg_grd.Rows.Count, Session["CurrentStudent"].ToString());

                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){ $('#divConfirmation').text('Course " + sCourse + " added successfully.').slideToggle('slow'); });", true);
                }
                else
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('" + validation.ErrorMessage + "').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
        }
        public void CreateZoomAccount(string email, string firstname, string lastname)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string userid = "";

            //string JWTaccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IktUUUpsM1ZiU0k2aVBPNDl0VmVma1EiLCJleHAiOjE3MzU3MTEyMDAsImlhdCI6MTYwMDI0NDY5MX0.GgRVMlmMsmf0j_d5TUY4jKKO-4xZfSt7u5hmQb9QFks";
            string JWTaccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IktUUUpsM1ZiU0k2aVBPNDl0VmVma1EiLCJleHAiOjE2NzUxODA4MDAsImlhdCI6MTYxNDA2OTU5Mn0.co_ApVI-0jkM3quY7igEvSZOsJIDkITCoRI0aoquHl8";
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.zoom.us/v2/users"))
                {
                    request.Headers.TryAddWithoutValidation("authorization", "Bearer " + JWTaccessToken + "");

                    request.Content = new StringContent("{\"action\":\"create\",\"user_info\":{\"email\":\"" + email + "\",\"type\":1,\"first_name\":\"" + firstname + "\",\"last_name\":\"" + lastname + "\"}}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    var x = JObject.Parse(s);
                    var uID = x["id"];
                    if (uID != null) //added by bahaa 25-09-2020 //
                    {
                        userid = uID.ToString();
                        hdnMsg.Value += ",Zoom Account Created";
                    }
                }
            }

            if (userid != "" && userid != null)
            {
                string groupid = "OU8bD5WPTxSpMLMvtG5H4w";//Group Name-Student
                string emailID = email;

                AddZoomGroupMemebers(groupid, emailID, userid, JWTaccessToken);

                //string IMGroupID = "W6jUNfWfSuC-vY7VqWpwOQ";//Default IM Group - Restricted 
                //if (Gender == "Males")
                //{
                //    IMGroupID = "seOLrQ4DQFWA7WMZzqwZhQ";//Males Studnets         
                //}
                //else if (Gender == "Females")
                //{
                //    IMGroupID = "1ShdTaaERVKs3KZmgO6JuQ";//Females Studnet
                //}
                //else
                //{
                //    IMGroupID = "W6jUNfWfSuC-vY7VqWpwOQ";//Default IM Group - Restricted 
                //}
                //addZoomIMGroupMembers(IMGroupID, emailID, userid);

                //deleteZoomIMGroupMemeber("W6jUNfWfSuC-vY7VqWpwOQ", userid);//Remove the User from Default IM Group - Restricted 
                hdnMsg.Value += ",Zoom Account User Added to Group";
            }
        }
        public void AddZoomGroupMemebers(string groupid, string email, string userid, string JWTaccessToken)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.zoom.us/v2/groups/" + groupid + "/members"))
                {
                    request.Headers.TryAddWithoutValidation("authorization", "Bearer " + JWTaccessToken + "");

                    request.Content = new StringContent("{\"members\":[{\"id\":\"" + userid + "\",\"email\":\"" + email + "\"}]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        public void CreateStudentEmailAD(InitializeModule.EnumCampus Campus, string sStudentID)
        {
            string sSQL = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Con = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                sSQL = "SELECT  SD.strFirstDescEn + ' ' + SD.strSecondDescEn AS [Given_Name]";
                sSQL += ", ' - ' + REPLACE(A.lngStudentNumber, '.', '') AS Surname";
                sSQL += ", SD.strFirstDescEn + ' ' + SD.strSecondDescEn AS [Display_Name]";
                sSQL += ", SD.sECTemail AS [Email_Addresses], LEFT(SD.sECTemail, LEN(SD.sECTemail) - 10) AS [Sam_Account_Name]";
                sSQL += ", 'ect@12345' AS Password, 'ect@12345' AS [User_Password], 'ect@12345' AS ChangePasswordOnNextLogon";
                sSQL += ", 'SMTP:' + SD.sECTemail AS [Proxy_Addresses], 'Student' AS [Personal_Title]";
                sSQL += ", M.strMajor AS Department, (CASE WHEN iCampus = 1 THEN 'Males Campus' ";
                sSQL += " WHEN iCampus = 2 THEN 'Females Campus' ";
                sSQL += " WHEN iCampus = 3 AND bSex = 1 THEN 'Media-Males Campus' ";
                sSQL += " WHEN iCampus = 3 AND bSex = 0 THEN 'Media-Females Campus' END) AS Description";
                sSQL += ", 'Emirates College of Technology' AS Company ";
                sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ";
                sSQL += " ON A.lngSerial = SD.lngSerial INNER JOIN Reg_Specializations AS M ";
                sSQL += " ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree ";
                sSQL += " AND A.strSpecialization = M.strSpecialization LEFT OUTER JOIN Last_Time_Registered ";
                sSQL += " ON A.lngStudentNumber = Last_Time_Registered.Student LEFT OUTER JOIN Lkp_Reasons ";
                sSQL += " ON A.byteCancelReason = Lkp_Reasons.byteReason ";
                sSQL += " WHERE  (SD.sECTemail IS NOT NULL) AND SD.sECTemail <> '' ";
                //if (sStudentID.Contains("M"))
                //{
                //    sSQL += " AND (SD.bSex = 1)";
                //}
                //else
                //{
                //    sSQL += " AND (SD.bSex = 0)";
                //}
                sSQL += " AND (SD.IsEmailCreationRequired = 1) ";
                sSQL += " AND A.lngStudentNumber ='" + sStudentID + "'";
                sSQL += " ORDER BY SD.iUnifiedID";

                SqlCommand cmd = new SqlCommand(sSQL, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                Con.Open();
                da.Fill(dt);
                Con.Close();

                if (dt.Rows.Count > 0)
                {
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{  
                    int i = 0;
                    CreateUserEmailAD(dt.Rows[i]["Given_Name"].ToString(), dt.Rows[i]["Surname"].ToString(), dt.Rows[i]["Display_Name"].ToString(), dt.Rows[i]["Description"].ToString(), dt.Rows[i]["Email_Addresses"].ToString(), dt.Rows[i]["Sam_Account_Name"].ToString(), dt.Rows[i]["Department"].ToString(), dt.Rows[i]["Company"].ToString(), true);
                    //}
                    UpdateEmailCreationRequired(Con, Convert.ToInt32(hdnSerial.Value));
                    hdnMsg.Value += ",Students Email Created Successfully in Office365";
                    //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    //div_msg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Con.Close();
                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }
        public void UpdateEmailCreationRequired(SqlConnection Con, int iSerialNo)
        {

            string sSQL = "";

            try
            {
                sSQL = "UPDATE Reg_Students_Data set IsEmailCreationRequired = 0";
                sSQL += " WHERE IsEmailCreationRequired = 1";
                sSQL += " AND lngSerial=" + iSerialNo;

                SqlCommand cmd = new SqlCommand(sSQL, Con);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }
        public int CreateUserEmailAD(string firstName, string lastName, string displayname, string description, string emailAddress, string userLogonName, string department, string company, bool enabled)
        {
            string Ounames = "Females";
            if (description == "Females Campus")
            {
                Ounames = "Females";
            }
            else
            {
                Ounames = "Males";
            }
            // Creating the PrincipalContext
            PrincipalContext principalContext = null;
            string adminusername = "ets.services.admin";
            string adminpassword = "Ser71ces@328";
            string userdomainLdappath = "OU=" + Ounames + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            string Server = "ectuae";
            try
            {
                principalContext = new PrincipalContext(ContextType.Domain, Server, userdomainLdappath, adminusername, adminpassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Check if user object already exists in the AD
            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr != null)
            {
                //User Already Exists
            }
            else
            {
                //Create New User
                DirectoryEntry myLdapConnection = DirectEntry(Ounames);
                DirectoryEntry user = myLdapConnection.Children.Add("CN=" + userLogonName + " ", "user");

                // User name (Domain-Based)   
                user.Properties["userprincipalname"].Add(userLogonName + "@" + "ectuae.com");

                // User name (Older-Systems)  
                user.Properties["samaccountname"].Add(userLogonName);

                // Surname  
                user.Properties["sn"].Add(lastName);

                // Given-Name  
                user.Properties["givenname"].Add(firstName);

                // Display-Name  
                user.Properties["displayname"].Add(displayname);

                // Description  
                user.Properties["description"].Add(description);

                // E-mail  
                user.Properties["mail"].Add(emailAddress);

                // Department  
                user.Properties["department"].Add(department);

                // Company  
                user.Properties["company"].Add(company);

                // Personal-Title  
                user.Properties["personalTitle"].Add("Student");

                // Proxy-Addresses  
                user.Properties["proxyAddresses"].Add("SMTP:" + emailAddress + "");

                // User-Password  
                user.Properties["userPassword"].Add("ect@12345");

                user.CommitChanges();
                user.Invoke("SetPassword", "ect@12345");

                //Force Password Change on Next Login
                //user.Properties["pwdLastSet"].Value = 0;

                if (enabled)
                    user.Invoke("Put", new object[] { "userAccountControl", "544" });

                user.CommitChanges();

                //AddUserToGroup(userLogonName, "Males");
                AddUserToGroup(userLogonName, Ounames);

                //Call Sharepoint function New Student
                sentdatatoSPLIstNewStudentsTracking(emailAddress);
            }
            return 0;
        }
        public void sentdatatoSPLIstNewStudentsTracking(string mailid)
        {
            int sem = 0;
            int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

            int iYear = Year;
            int iSem = sem;
            string sSemester = LibraryMOD.GetSemesterString(iSem);
            int iTerm = iYear * 10 + iSem;

            string Addedby = mailid;
            //SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("select * from HR_Employee_Academic_Admin_Managers where EmployeeID='" + Session["EmployeeID"].ToString() + "'", sc);
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //try
            //{
            //    sc.Open();
            //    da.Fill(dt);
            //    sc.Close();

            //    if (dt.Rows.Count > 0)
            //    {
            //        Addedby = dt.Rows[0]["EmployeeEmail"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    sc.Close();
            //    Console.WriteLine("{0} Exception caught.", ex.Message);
            //}
            //finally
            //{
            //    sc.Close();
            //}


            string SIS_PWD = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc1 = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd1 = new SqlCommand("SELECT strPhone1,strPhone2,strStudentName,strOnlinePWD from Reg_Student_Accounts where lngStudentNumber=@lngStudentNumber", sc1);
            cmd1.Parameters.AddWithValue("@lngStudentNumber", Session["CurrentStudent"].ToString());
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            try
            {
                sc1.Open();
                da1.Fill(dt1);
                sc1.Close();

                if (dt1.Rows.Count > 0)
                {
                    SIS_PWD = dt1.Rows[0]["strOnlinePWD"].ToString();
                }
            }
            catch (Exception ex)
            {
                sc1.Close();
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc1.Close();
            }

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("New Students Tracking");
            ListItemCreationInformation itemInfo = new ListItemCreationInformation();
            Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);
            myItem["Title"] = iTerm;//Term                     
            myItem["SID"] = Session["CurrentStudent"].ToString();//SID
            myItem["Email"] = clientContext.Web.EnsureUser(mailid);//Student Email   
            //myItem["Email"] = clientContext.Web.EnsureUser("sujeesh.sureshkumar@ect.ac.ae");//Student Email  
            myItem["Password"] = SIS_PWD;//SIS Password
            myItem["Phone1"] = dt1.Rows[0]["strPhone1"].ToString();//Phone1
            myItem["Phone2"] = dt1.Rows[0]["strPhone2"].ToString();//Phone2  
            myItem["Author"] = clientContext.Web.EnsureUser(Addedby);//Added By
            //myItem["Author"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");//Addedby
            myItem["FirstUpdate"] = null;//1st Update
            myItem["SecondUpdate"] = null;//2nd Update
            myItem["ThirdUpdate"] = null;//3rd Update
            myItem["Remarks"] = "";//Remarks
            myItem["Status"] = "Initiated";//Status
            myItem["StudentName"] = dt1.Rows[0]["strStudentName"].ToString();//Student Name
            //myItem["Modified"] = null;//Updated
            //myItem["Created"] = DateTime.Now;//Created
            myItem["Editor"] = clientContext.Web.EnsureUser(Addedby);//Updated By
            //myItem["AlertTo"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");//AlertTo  
            //myItem["AlertTo"] = clientContext.Web.EnsureUser(AlertTo);
            try
            {
                myItem.Update();
                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                clientContext.Credentials = onlineCredentials;
                clientContext.ExecuteQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
        }
        public static DirectoryEntry DirectEntry(string ouname)
        {
            DirectoryEntry ldapConnection = new DirectoryEntry("rch");
            //ldapConnection.Path = "LDAP://OU=Males,OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            ldapConnection.Path = "LDAP://OU=" + ouname + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            ldapConnection.Username = "ets.services.admin";
            ldapConnection.Password = "Ser71ces@328";
            return ldapConnection;
        }
        public static void AddUserToGroup(string userId, string groupName)
        {
            string adminusername = "ets.services.admin";
            string adminpassword = "Ser71ces@328";
            string Server = "ectuae";
            //string userdomainLdappath = "OU=Males,OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            string userdomainLdappath = "OU=" + groupName + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, Server, userdomainLdappath, adminusername, adminpassword))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                    group.Members.Add(pc, IdentityType.SamAccountName, userId);
                    group.Save();
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //doSomething with E.Message.ToString(); 
            }
        }
        private void CreateStudentEmail(string lname)
        {
            //if (txtECTEmail.Text.Length > 17) 
            //{
            //    return;
            //    btnCreateEmail.Enabled = false;
            //}
            string sFName = "";
            string sECTEmail = "";
            if (lname.Trim().Length <= 1)
            {
                hdnMsg.Value = "Please enter correct name in (Last Name) ";
                //div_msg.Visible = true;
                return;
            }
            int iUnifiedID = LibraryMOD.GetMaxUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
            //update Unified ID
            if (iUnifiedID > 0)
            {
                LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), iUnifiedID);
                //check reference number
                if (LibraryMOD.UpdateStudentUnifiedIDIfHasRefID(Campus, Convert.ToInt32(hdnSerial.Value)) == true)
                {
                    //Get updated UnifiedID
                    iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value));
                }
            }
            else
            {
                iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
                if (iUnifiedID == 0)
                {
                    iUnifiedID = LibraryMOD.GetMaxUnifiedID_withoutCheckRefID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
                }
                LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), iUnifiedID);
            }
            //Update student email    
            sECTEmail = sFName.ToString().Trim().Replace(" ", string.Empty) + iUnifiedID.ToString().PadLeft(6, Convert.ToChar("0")) + "@ect.ac.ae";
            if (LibraryMOD.UpdateStudentEmail(Campus, Convert.ToInt32(hdnSerial.Value), sECTEmail) == true)
            {
                hdnMsg.Value = "Student email has been created successfully";
                //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                //div_msg.Visible = true;
                hdnStudentEmail.Value = sECTEmail;
            }
            else
            {
                hdnMsg.Value = "The student's email has not been created";
                //div_msg.Visible = true;
            }
            //btnCreateEmail.Enabled = false;
        }
        private int GetSerial(string sNumber)
        {
            int iserial = 0;
            try
            {
                ApplicationsDAL myapp = new ApplicationsDAL();
                iserial = myapp.GetSerial(Campus, sNumber);
            }
            catch (Exception ex)
            {
            }
            return iserial;
        }
        public void apicall_UpdateRegistrationStatus(int count,string sSID)
        {
            string registrationstatus = "Registered";
            string retention_status = "Opened";
            string numberofregisteredcourses = "0";
            string cgpa = "0";
            string ect_student_id = sSID;
            string financialbalance = "A";
            string sisusername = sSID;
            string sispassword = "ect@12345";
            string ectemailpassword = "ect@12345";
            string major = hdnStudentMajor.Value;
            string Credit_Completed = "0";
            string contactid = "0";




            if (count>0)
            {
                registrationstatus= "Registered";
                retention_status = "Registered";
                numberofregisteredcourses = count.ToString();
            }
            else
            {
                registrationstatus = "Unregistered";
                retention_status = "Opened";
                numberofregisteredcourses = "0";
            }
            int iCSem = 0;
            int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
            int hrs = 18;
            if(iCSem==1 || iCSem==2)//Fall & Spring
            {
                hrs = 18;
            }
            else if (iCSem == 3 || iCSem == 4)//Summer 1 & Summer 2
            {
                hrs = 9;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT  A.lngStudentNumber AS SID, dbo.Completed_Successfully(A.lngStudentNumber, "+ iCYear + ", "+ iCSem + ", A.strDegree, A.strSpecialization) AS Completed, dbo.GetSARFinanceCategory("+ iCYear + ", "+ iCSem + ", A.lngStudentNumber, "+ hrs + ") AS Balance, ISNULL(G.GPA, 0) AS CGPA, SD.sECTemail AS EMail, ISNULL(AC.intOnlineUser, 0) AS [User] FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial LEFT OUTER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber LEFT OUTER JOIN GPA_Until AS G ON A.lngStudentNumber = G.lngStudentNumber WHERE (A.lngStudentNumber = @lngStudentNumber);SELECT  [UserNo],[UserName],[Password] FROM [ECTDataNew].[dbo].[Cmn_User] where UserNo in (SELECT intOnlineUser from [ECTData].[dbo].[Reg_Student_Accounts] where lngStudentNumber=@lngStudentNumber);SELECT GPA FROM GPA_Until WHERE lngStudentNumber=@lngStudentNumber;  select icontactid FROM [ECTData].[dbo].[Reg_Applications] where lngStudentNumber=@lngStudentNumber", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber", sSID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(ds);
                sc.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Credit_Completed = ds.Tables[0].Rows[0]["Completed"].ToString();
                    financialbalance = ds.Tables[0].Rows[0]["Balance"].ToString();
                }
                if (ds.Tables[1].Rows.Count>0)
                {
                    sisusername = ds.Tables[1].Rows[0]["UserName"].ToString();
                    sispassword = ds.Tables[1].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    cgpa = ds.Tables[2].Rows[0]["GPA"].ToString();
                }
                else
                {
                    cgpa = "0";
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    contactid = ds.Tables[3].Rows[0]["icontactid"].ToString();
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

            //API Call
            
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string accessToken = InitializeModule.CxPwd;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://ect.custhelp.com/services/rest/connect/v1.4/contacts/" + contactid + ""))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                    request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                    request.Content = new StringContent("{\n    \"customFields\": {\n        \"c\": {\n            \"registrationstatus\": {\n                \"lookupName\": \"" + registrationstatus + "\"\n            },\n            \"numberofregisteredcourses\": " + numberofregisteredcourses + ",\n            \"cgpa\": " + cgpa + ",\n            \"retention_status\": {\n                \"lookupName\": \"" + retention_status + "\"\n            },\n            \"ect_student_id\": \"" + ect_student_id + "\",\n            \"financialbalance\": \"" + financialbalance + "\",\n            \"sisusername\": \"" + sisusername + "\",\n            \"sispassword\": \"" + sispassword + "\",\n            \"ectemailpassword\": \"" + ectemailpassword + "\"\n        },\n        \"CO\": {\n            \"Major\": \"" + major + "\",\n            \"Credit_Completed\": " + Credit_Completed + "\n        }\n    }\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    //If Status 200
                    if (response.IsSuccessStatusCode == true)
                    {
                        hdnMsg.Value += ", API Call-Update Registration Status-SUCCESS";
                    }

                }
            }
        }
        //handling drop link in Reg_grd
        protected void Reg_grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                InitializeModule.enumPrivilege.DropCourse, CurrentRole) != true)
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to drop a course.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }
                int iSelectedIndex = Reg_grd.SelectedIndex;
                int iYear = iRegYear;
                int iSemester = iRegSem;
                string sCourse = Reg_grd.DataKeys[iSelectedIndex].Values["strCourse"].ToString();
                int iClass = int.Parse(Reg_grd.DataKeys[iSelectedIndex].Values["byteClass"].ToString());
                int iShift = int.Parse(Reg_grd.DataKeys[iSelectedIndex].Values["byteShift"].ToString());
                int iFormNumber = int.Parse(Session["iFormNumber"].ToString());

                string sStudentNumber = Session["CurrentStudent"].ToString();
                //=========================================================
                int iPeriod = 0;
                InitializeModule.EnumCampus CourseCampus = LibraryMOD.SyncCampusAndSession(iShift.ToString(), out iPeriod);
                if (CourseCampus != Campus)
                {
                    Campus = CourseCampus;
                    Get_Student_Advising();
                    Session["iFormNumber"] = this.CreateHeader();
                }

                if (sCourse.Contains("ESL"))
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to drop ESL course.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }

                //Co-requisiste =====================================
                //Check if the dropped course is a co-requisite for registered course
                string sCorequisite = "";
                RegValidation TheValidation = new RegValidation();

                sCorequisite = TheValidation.IsCorequisiteofRegisteredCourse(iRegYear, iRegSem, sStudentNumber, sCourse);

                if (sCorequisite != "")
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you can not drop co-requisite course. before dropping:" + sCorequisite + "').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }
                //===================================

                //Check if it is Internship Course
                if (sCourse == "ACC204" || sCourse == "BAF207" || sCourse == "BIS200"
                    || sCourse == "HRM208" || sCourse == "MAR205" || sCourse == "MCPR207"
                    || sCourse == "JOR308" || sCourse == "MCPR208A" || sCourse == "PRD308" || sCourse == "RTV308"
                    || sCourse == "BUS419" || sCourse == "ACC419" || sCourse == "BAF419" || sCourse == "IBAF419"
                    || sCourse == "HRM419" || sCourse == "HIM419" || sCourse == "BIM419")
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to drop an internship course,The registrar only can drop it for you.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }
                //Check if it is graduation project Course
                if (sCourse == "ACC415" || sCourse == "BAF415" || sCourse == "BIT415" || sCourse == "IBAF415"
                    || sCourse == "HRM415" || sCourse == "HIM415" || sCourse == "BIM415" || sCourse == "BUS415"
                    || sCourse == "PRD407" || sCourse == "RTV407" || sCourse == "JOR407"
                   )
                {
                    string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to drop a graduation project course,The registrar only can drop it for you.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    return;
                }

                Plans myPlan = (Plans)Session["myPlan"];
                if (myPlan.Degree == "3" && myPlan.Major == "11")
                {
                    if (sCourse.Equals("MTH001"))
                    {
                        string sScript = "$(function(){ $('#divConfirmation').html('Sorry you are not allowed to drop MTH001 course.').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                        return;
                    }
                }

                Connection_StringCLS MyConnection_string = new Connection_StringCLS(this.Campus);
                SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
                Conn.Open();
                int iTrans = LibraryMOD.GetMaxID(Conn, "byteTrans", "Reg_Course_Detail", "intStudyYear=" + iYear + " AND byteSemester=" + iSemester + " AND byteForm=1 AND intFormNumber=" + iFormNumber + " AND strCourse='" + sCourse + "' AND byteClass=" + iClass + " AND byteShift=" + iShift);
                iTrans++;
                Conn.Close();
                int iMode = (int)InitializeModule.enumModes.NewMode;
                string sPCName = "ECTSIS";// System.Net.Dns.GetHostName();
                string sUserName = Session["CurrentUserName"].ToString();
                string sNetUserName = Session["CurrentURL"].ToString(); //Session["CurrentNetUserName"].ToString();

                Course_DetailDAL myCourseDetail = new Course_DetailDAL();

                myCourseDetail.UpdateCourse_Detail(this.Campus, iMode, iYear, iSemester, 1, iFormNumber, sCourse, iClass, iShift, iTrans, "False", "", "", 0, sUserName, DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);
                if (sCourse == "ESL100" || sCourse == "ESL102")
                {
                    switch (sCourse)
                    {
                        case "ESL100":
                            sCourse = "ESL101 50%";
                            break;
                        case "ESL102":
                            sCourse = "ESL103 50%";
                            break;
                    }
                    myCourseDetail.UpdateCourse_Detail(this.Campus, iMode, iYear, iSemester, 1, iFormNumber, sCourse, iClass, iShift, iTrans, "False", "", "", 0, sUserName, DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);
                }

                Reg_grd.DataBind();
                if(Reg_grd.Rows.Count<=0)
                {
                    string studentid = Session["CurrentStudent"].ToString();
                    var services = new DAL.DAL();
                    Connection_StringCLS connstr = new Connection_StringCLS(Campus);
                    DataTable dtStudentServices = services.GetStudentDetailsID(studentid, connstr.Conn_string);
                    //string emailid = dtStudentServices.Rows[0]["sECTemail"].ToString();
                    //string fname = dtStudentServices.Rows[0]["strFirstDescEn"].ToString();
                    //string lname = dtStudentServices.Rows[0]["strSecondDescEn"].ToString();
                    hdnStudentMajor.Value = dtStudentServices.Rows[0]["strCaption"].ToString();
                    //Update Registration Status
                    //API Call-Update Registration Status
                    apicall_UpdateRegistrationStatus(Reg_grd.Rows.Count, Session["CurrentStudent"].ToString());
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){ $('#divConfirmation').text('Course " + sCourse + " dropped successfully.').slideToggle('slow'); });", true);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }

        }
        protected void RunCMD_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Enable_Disable(false);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
        }


        protected void Course_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showmsg(string sMsg)
        {

            runScr("showmsg('" + sMsg + "');");

        }

        private void runScr(string sScr)
        {
            string str = "<script>" + sScr + "</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
        }
        protected void Print_TimeTable_Click(object sender, EventArgs e)
        {

            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Advising,
                    InitializeModule.enumPrivilege.Print, this.CurrentRole) != true)
            {
                showmsg("Sorry, You don't have the permission to print...");
                return;
            }
            ExportStudentTimeTable();
        }

        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }

        private bool Enable_Disable(string sSNo, InitializeModule.EnumCampus Campus)
        {
            bool isEnable = false;
            string sMSG = "";

            try
            {

                string sRegMsg = "<br />Contact the registration please | يرجى مراجعة التسجيل";

                string sAccMsg = "<br/>Please contact the Accounting & Finance Department | يرجى مراجعة المحاسبة";
                sAccMsg += "<br/>Phone Number (1): +971504188086";
                sAccMsg += "<br/>Phone Number (2): +971544413928";
                sAccMsg += "<br/>WhatsApp Messages: +971564065904";
                sAccMsg += "<br/>Email: student.receivable@ect.ac.ae";

                bool isFinance = true;
                //20042020
                int iFinCat = 0;
                string sOAcc = "";
                iFinCat = LibraryMOD.getFinanceCategory(sSNo, out sOAcc);
                Session["CurrentFinCat"] = iFinCat;
                isFinance = (iFinCat > 1);

                bool isActive = true;
                bool isMissing = true;
                int iIsFileVerified = 0;

                int iStatus = 0;


                bool flag1 = false, flag2 = false;


                //isFinance = LibraryMOD.isFinanceProblems(Campus, sSNo);

                isActive = LibraryMOD.isActiveStudent(Campus, sSNo);

                isMissing = LibraryMOD.isMissingStudent(Campus, sSNo);

                iStatus = LibraryMOD.GetStudentStatus(Campus, sSNo);

                iIsFileVerified = LibraryMOD.IsFileVerifiedFromRegistrar(sSNo, Campus);

                if (iIsFileVerified == 0 || !isActive || !isMissing || iStatus > 0)
                {
                    flag1 = true;
                    sMSG += sRegMsg;
                }

                if (isFinance || string.IsNullOrEmpty(sSNo))
                {
                    flag2 = true;
                    sMSG += sAccMsg;
                }


                isEnable = !(flag1 || flag2);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                return false;
            }
            finally
            {
                if (sMSG != "")
                {
                    sMSG = "Sorry, you cannot register | نأسف, لا يمكنك التسجيل" + sMSG;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "errorSession", "$(function(){Sexy.error('" + sMSG + "'); });", true);
                    showErr(sMSG);
                }
            }

            return isEnable;
        }


        private bool isPaid(string sSID)
        {
            bool isIt = false;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
            conn.Open();
            try
            {
                double iPaid = 0;
                string sSQL = "SELECT SA.lngStudentNumber, SUM(VD.curCredit) AS Paid";
                sSQL += " FROM Acc_Voucher_Header AS VH INNER JOIN Acc_Voucher_Detail AS VD ON VH.intFy = VD.intFy AND VH.byteFSemester = VD.byteFSemester";
                sSQL += " AND VH.strVoucherNo = VD.strVoucherNo INNER JOIN Reg_Student_Accounts AS SA ON VH.strAccountNo = SA.strAccountNo";
                sSQL += " WHERE (VD.byteStatus < 2)";
                sSQL += " GROUP BY SA.lngStudentNumber";
                sSQL += " HAVING (SA.lngStudentNumber = '" + sSID + "')";

                SqlCommand cmd = new SqlCommand(sSQL, conn);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    iPaid = Convert.ToDouble(rd["Paid"].ToString());
                }
                rd.Close();
                //iPaid = 2000;
                isIt = (iPaid >= 3500);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return isIt;
        }
    }
}