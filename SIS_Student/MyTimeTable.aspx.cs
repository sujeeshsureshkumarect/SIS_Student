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

namespace SIS_Student
{
    public partial class MyTimeTable : System.Web.UI.Page
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
                    //TmDS.ConnectionString = sConn;
                    //RegDS.ConnectionString = sConn;
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
                    Session["ReportDS"] = null;
                    Session["myList"] = null;
                    Session["myPlan"] = null;               

                    //==========================
                    //Print student time table
                    //if (Request.QueryString["TimeTable"] != null)
                    //{
                        Retrieve();
                        //ExportStudentTimeTable();
                    //}

                    //==========================
                    //Session["ReportDS"] = null;
                }
                else
                {
                    
                }

                if (Session["ReportDS"] != null)
                {
                    DataSet rptDS;
                    rptDS = (DataSet)Session["ReportDS"];
                    if (rptDS.Tables.Count > 0)
                    {
                        DataTable dt = rptDS.Tables[0];
                        //TimeTable_Grd.DataSource = dt;
                        //TimeTable_Grd.DataBind();
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);

            }
        }

        private void Retrieve()
        {
            List<TimeTable> myTimeTables = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();
            DataSet Ds = new DataSet();
            try
            {

                int sem = 0;
                int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

                int iYear = Year;
                int iSem = sem;
                string sSemester = LibraryMOD.GetSemesterString(iSem);

                string sStudentNumber = this.sNo;

                int iSemester = Convert.ToInt32("0" + iSem.ToString());
                int iRegYear = Convert.ToInt32("0" + iYear.ToString());

                lbl_TitleYearSem.Text = " - " + iRegYear.ToString() + " / " + (iRegYear + 1).ToString() + " " + sSemester;
                lbl_TitleStudent.Text = GetCaption();
                lbl_TitleStudent.Text += "     -   Total Credit Hours: [ " + LibraryMOD.GetStudentRegisteredCredit(iRegYear, iSemester, sNo, Convert.ToInt32((InitializeModule.EnumCampus)this.Campus)).ToString() + " ]";
                lbl_TitleMajor.Text = LibraryMOD.GetStudentMajor(this.Campus, sNo);

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
                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();

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

                int sem = 0;
                int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

                int iYear = Year;
                int iSem = sem;
                string sSemester = LibraryMOD.GetSemesterString(iSem);

                int iSemester = Convert.ToInt32("0" + iSem.ToString());
                int iRegYear = Convert.ToInt32("0" + iYear.ToString());
                string sNo = Session["CurrentStudent"].ToString();

                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];
                txt.Text = GetCaption();
                txt.Text += "     -   Total Credit Hours: [ " + LibraryMOD.GetStudentRegisteredCredit(iRegYear, iSemester, sNo, Convert.ToInt32((InitializeModule.EnumCampus)this.Campus)).ToString() + " ]";

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtMajor"];
                txt.Text = LibraryMOD.GetStudentMajor(this.Campus, sNo);

                //string sSemester = LibraryMOD.GetSemesterString(iSemester);

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

        protected void PrintFM_CMD_Click(object sender, EventArgs e)
        {
            ExportStudentTimeTable();
        }
    }
}