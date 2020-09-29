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
                    //int i = Convert.ToInt32(Session["RegYear"]);
                    //i = Convert.ToInt32(Session["RegSemester"]);
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Current_TimeTable,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        showErr("Sorry, you don't have the permission to view this page...");
                    }

                    lblTerm.Text = getRegTerm();
                    showdata();

                }



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

        protected void PrintCMD_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Current_TimeTable,
                InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                showmsg(InitializeModule.MsgPrintAuthorization);
                return;
            }

            Export(InitializeModule.ECT_Buttons.Print);
        }

        private void Export(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                if (Session["rptDS"] == null)
                {
                    return;
                }
                DataSet rptDS = new DataSet();


                rptDS = (DataSet)Session["rptDS"]; //Prepare_Report(Retrieve(iSession));
                int iSession = Convert.ToInt32(rbnSession.SelectedValue);

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
                Print_btn.Visible = (dt.Rows.Count > 0);
                grdTM.DataSource = dt;
                grdTM.DataBind();

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

        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }

        protected void showdata()
        {
            int iSession = Convert.ToInt32(rbnSession.SelectedValue);
            DataSet rptDS = new DataSet();

            rptDS = Prepare_Report(Retrieve(iSession));
            Session["rptDS"] = rptDS;
        }
        protected void rbnSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            showdata();
        }
        protected void Print_btn_Click(object sender, ImageClickEventArgs e)
        {
            Export(InitializeModule.ECT_Buttons.Print);
        }

        protected void PrintFM_CMD_Click(object sender, EventArgs e)
        {
            Export(InitializeModule.ECT_Buttons.Print);
        }
    }

}