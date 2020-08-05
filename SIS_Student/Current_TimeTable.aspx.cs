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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;

namespace SIS_Student
{
    public partial class Current_TimeTable : System.Web.UI.Page
    {
        int CurrentRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Security

                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                }
                else
                {
                    //showErr("Session is expired, Login again please...");
                    ClearSession();
                    Response.Redirect("Login.aspx");

                }

                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Current_TimeTable,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        //showErr("Sorry, you don't have the permission to view this page...");
                    }

                    lblTerm.Text = getRegTerm();

                }

                Connection_StringCLS ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                string sConn = ConnectionString.Conn_string;
                TM_FM_DS.ConnectionString = sConn;
                TM_FE_DS.ConnectionString = sConn;
                TM_WEF_DS.ConnectionString = sConn;
                ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                sConn = ConnectionString.Conn_string;
                TM_ME_DS.ConnectionString = sConn;
                TM_WEM_DS.ConnectionString = sConn;
            }
            catch (Exception exp)
            {
                //showErr("Somthing went wrong, login again please...");
                ClearSession();
                Response.Redirect("Login.aspx");
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
        private string getRegTerm()
        {
            string sRegTerm = "";
            try
            {
                int iYear = Convert.ToInt32(Session["RegYear"]);
                int iSem = Convert.ToInt32(Session["RegSemester"]);
                sRegTerm = LibraryMOD.GetTermDesc(iYear, iSem);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                //myTimeTable.Clear();
            }
            return (sRegTerm);
        }

        protected void FM_lnk_Click(object sender, EventArgs e)
        {
            TM_mtv.ActiveViewIndex = 0;
            FM_lnk.CssClass = "btn btn-primary";
            FE_lnk.CssClass = "btn btn-success";
            WEF_lnk.CssClass = "btn btn-success";
            ME_lnk.CssClass = "btn btn-success";
            WEM_lnk.CssClass = "btn btn-success";
        }

        protected void FE_lnk_Click(object sender, EventArgs e)
        {
            TM_mtv.ActiveViewIndex = 1;
            FM_lnk.CssClass = "btn btn-success";
            FE_lnk.CssClass = "btn btn-primary";
            WEF_lnk.CssClass = "btn btn-success";
            ME_lnk.CssClass = "btn btn-success";
            WEM_lnk.CssClass = "btn btn-success";
        }

        protected void WEF_lnk_Click(object sender, EventArgs e)
        {
            TM_mtv.ActiveViewIndex = 2;
            FM_lnk.CssClass = "btn btn-success";
            FE_lnk.CssClass = "btn btn-success";
            WEF_lnk.CssClass = "btn btn-primary";
            ME_lnk.CssClass = "btn btn-success";
            WEM_lnk.CssClass = "btn btn-success";
        }

        protected void ME_lnk_Click(object sender, EventArgs e)
        {
            TM_mtv.ActiveViewIndex = 3;
            FM_lnk.CssClass = "btn btn-success";
            FE_lnk.CssClass = "btn btn-success";
            WEF_lnk.CssClass = "btn btn-success";
            ME_lnk.CssClass = "btn btn-primary";
            WEM_lnk.CssClass = "btn btn-success";
        }

        protected void WEM_lnk_Click(object sender, EventArgs e)
        {
            TM_mtv.ActiveViewIndex = 4;
            FM_lnk.CssClass = "btn btn-success";
            FE_lnk.CssClass = "btn btn-success";
            WEF_lnk.CssClass = "btn btn-success";
            ME_lnk.CssClass = "btn btn-success";
            WEM_lnk.CssClass = "btn btn-primary";
        }
        protected void TM_WEF_DS_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 90;
        }
        protected void TM_ME_DS_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 90;
        }
        protected void TM_FM_DS_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 90;
        }
        protected void TM_FE_DS_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 90;
        }
        protected void TM_WEM_DS_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 90;
        }

        protected void PrintCMD_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Current_TimeTable,
            InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                //showmsg(InitializeModule.MsgPrintAuthorization);
                return;
            }

            int iSession = 0;
            LinkButton btn = (LinkButton)sender;
            switch (btn.ID)
            {
                case "PrintFM_CMD":
                    iSession = 1;
                    break;
                case "PrintFE_CMD":
                    iSession = 2;
                    break;
                case "PrintME_CMD":
                    iSession = 4;
                    break;
                case "PrintWEM_CMD":
                    iSession = 8;
                    break;
                case "PrintWEF_CMD":
                    iSession = 9;
                    break;
            }

            Export(iSession, InitializeModule.ECT_Buttons.Print);
        }
        private void Export(int iSession, InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {

                DataSet rptDS = new DataSet();


                rptDS = Prepare_Report(Retrieve(iSession));

                string reportPath = Server.MapPath("Reports/CurrentTimeTable_rpt.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                txt.Text = GetCaption(iSession);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = "/ " + sUserName;

                switch (iExport)
                {
                    case InitializeModule.ECT_Buttons.Print:
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");
                        break;
                    case InitializeModule.ECT_Buttons.ToExcel:
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Page.Response, true, "ECTReport");
                        break;
                    case InitializeModule.ECT_Buttons.ToWord:
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Page.Response, true, "ECTReport");
                        break;

                }



            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }
        private List<TimeTable> Retrieve(int iSession)
        {
            List<TimeTable> myTimeTable = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();
            DataSet Ds = new DataSet();
            try
            {

                InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
                int iCampus = 0;
                switch (iSession)
                {
                    case 1:
                    case 2:
                    case 9:
                        Campus = InitializeModule.EnumCampus.Females;
                        iCampus = 2;
                        break;
                    case 4:
                    case 8:
                        Campus = InitializeModule.EnumCampus.Males;
                        iCampus = 1;
                        break;
                }

                int iTerm = 0;
                int iSem = 0;
                int iYear = 0;

                iTerm = LibraryMOD.GetRegTerm();
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);


                //if(Session["CurrentMajorCampus"]!=null)
                //{
                //    iCampus=Convert.ToInt32(Session["CurrentMajorCampus"]);                                                    
                //}
                myTimeTable = myTimeTableDAL.GetTimeTable(iYear, iSem, iSession, "", 0, 0, "", "", false, false, iCampus, Campus);



            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }
            return myTimeTable;
        }

        private DataSet Prepare_Report(List<TimeTable> myTimeTable)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDesc", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iClass", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sTFrom", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sTTo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iDay", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDay", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sHall", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sLecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                int Serial = 0;
                for (int i = 1; i < myTimeTable.Count; i++)
                {
                    if (myTimeTable[i].IMax > myTimeTable[i].ICapacity)
                    {
                        dr = dt.NewRow();
                        Serial += 1;
                        dr["iSerial"] = Serial;
                        dr["sCourse"] = myTimeTable[i].SCourse;
                        dr["sDesc"] = myTimeTable[i].SDesc;
                        dr["iClass"] = myTimeTable[i].IClass;
                        dr["sTFrom"] = myTimeTable[i].ClassTimes[0]._dFrom.ToShortTimeString();
                        dr["sTTo"] = myTimeTable[i].ClassTimes[0]._dTo.ToShortTimeString();
                        dr["iDay"] = myTimeTable[i].ClassTimes[0]._iDays;
                        dr["sDay"] = myTimeTable[i].ClassTimes[0]._sDays + "  " + myTimeTable[i].ClassTimes[0]._sNotes;
                        dr["sHall"] = myTimeTable[i].ClassTimes[0]._sHall;
                        dr["sLecturer"] = myTimeTable[i].ClassTimes[0]._sLecturer;
                        dt.Rows.Add(dr);
                        //Collect Additional Times
                        for (int j = 1; j < myTimeTable[i].ClassTimes.Count; j++)
                        {
                            dr = dt.NewRow();
                            Serial += 1;
                            dr["iSerial"] = Serial;
                            dr["sCourse"] = myTimeTable[i].SCourse;
                            dr["sDesc"] = myTimeTable[i].SDesc;
                            dr["iClass"] = myTimeTable[i].IClass;
                            dr["sTFrom"] = myTimeTable[i].ClassTimes[j]._dFrom.ToShortTimeString();
                            dr["sTTo"] = myTimeTable[i].ClassTimes[j]._dTo.ToShortTimeString();
                            dr["iDay"] = myTimeTable[i].ClassTimes[j]._iDays;
                            dr["sDay"] = myTimeTable[i].ClassTimes[j]._sDays + "  " + myTimeTable[i].ClassTimes[j]._sNotes;
                            dr["sHall"] = myTimeTable[i].ClassTimes[j]._sHall;
                            dr["sLecturer"] = myTimeTable[i].ClassTimes[j]._sLecturer;
                            dt.Rows.Add(dr);
                        }
                    }


                }
                dt.TableName = "TimeTable";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                myTimeTable.Clear();
            }
            return ds;
        }

        private string GetCaption(int iSession)
        {
            string sCaption = "";
            switch (iSession)
            {
                case 1:
                    sCaption = "Females Morning";
                    break;
                case 2:
                    sCaption = "Females Evening";
                    break;
                case 9:
                    sCaption = "Weekend Females";
                    break;
                case 4:
                    sCaption = "Males Evening";
                    break;
                case 8:
                    sCaption = "Weekend Males";
                    break;
            }

            return sCaption;
        }
        protected void DataListWEM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }       
    }
}