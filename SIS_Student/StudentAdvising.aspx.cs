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
    public partial class StudentAdvising : System.Web.UI.Page
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
                    Get_Student_Advising();
                    System.Web.UI.WebControls.Table Advising_tbl = Create_Rec_Table(myList[0]);
                    //Advising_pnl.Controls.Clear();
                    //Advising_pnl.Controls.Add(Advising_tbl);
                    divMirror.Controls.Clear();
                    divMirror.Controls.Add(Advising_tbl);
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
                myMirror = myAdvising.GetAdvising(sNo, true, iYear, iSem, true, isHidden, out Plan, Campus);
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

        private System.Web.UI.WebControls.Table Create_Table(MirrorCLS myMirror)
        {
            System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();
            try
            {
                myList.Add(myMirror);
                //First Row
                //MyTable.Width = 70%;
                MyTable.Width = Unit.Percentage(70);
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Horizontal;
                MyTable.ID = "tblDetail";

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();
                TableCell Hd = new TableCell();

                Hc.ColumnSpan = 4;
                Hc.Text = "Student Info";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                //No
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "No : ";
                //Hc.HorizontalAlign = HorizontalAlign.Center; 
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = sNo.Replace(".", "");
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);
                //Name
                Hc = new TableHeaderCell();
                Hc.Text = "Name : ";
                //Hc.HorizontalAlign = HorizontalAlign.Center; 
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
                //Hc.HorizontalAlign = HorizontalAlign.Center; 
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.ColumnSpan = 3;
                Hd.Text = myMirror.Major;
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);

                //Third Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "CGPA : ";
                //Hc.HorizontalAlign = HorizontalAlign.Center; 
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
                //Hc.HorizontalAlign = HorizontalAlign.Center; 
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                //Get Max Esl (Advisor Now)
                Hd.HorizontalAlign = HorizontalAlign.Center;

                Hd.Text = LibraryMOD.GetAdvisorEmail(myMirror.Advisor);

                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);

                //Fourth Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "ENG : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = myMirror.ENG;
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                Hc = new TableHeaderCell();
                Hc.Text = "Score : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();

                Hd.Text = string.Format("{0:F}", myMirror.Score);
                Hd.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);




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
                MirrorDAL myMirrorDAL = new MirrorDAL();
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
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
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
                txt.Text = myMirror.Advisor;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["eng_txt"];
                txt.Text = myMirror.ENG;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["score_txt"];
                txt.Text = string.Format("{0:f}", myMirror.Score);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Major_Free_Elective_txt"];
                string MElective = myMirrorDAL.GetMajorElectiveCourses(myMirror.StudentNumber, Campus);
                string FElective = myMirrorDAL.GetFreeElectiveCourses(myMirror.StudentNumber, Campus);
                txt.Text = "";
                if (MElective.Length > 0)
                {
                    txt.Text += "Major Electives: " + "[ " + MElective + " ]";

                }
                if (FElective.Length > 0)
                {
                    if (MElective.Length > 0)
                    {
                        txt.Text += " --- ";
                    }
                    txt.Text += "Free Electives [" + FElective + " ]";
                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Session_txt"];
                txt.Text = myMirror.Period;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Term_txt"];
                string sTerm = LibraryMOD.GetTermDesc(iRegYear, iRegSem);

                txt.Text = sTerm;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Advisor_txt"];
                txt.Text = LibraryMOD.GetAdvisorEmail(myMirror.Advisor);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                txt.Text = myMirror.StudentNumber.Replace(".", "") + " - " + myMirror.Name;

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