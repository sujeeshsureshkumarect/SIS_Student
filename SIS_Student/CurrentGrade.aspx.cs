using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace SIS_Student
{
    public partial class CurrentGrade : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus CurrentCampus;
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
                    //showErr("Session is expired, Login again...");
                    ClearSession();
                    Response.Redirect("Login.aspx");
                }


                if (!Page.IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_MarkSheet,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        //showmsg("Sorry, You don't have the permission to view this page...");
                        //runScr("hidesidebar();");
                        showErr("Sorry, You don't have the permission to view this page...");
                    }


                }

                CurrentCampus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                string sSID = Session["CurrentStudent"].ToString();
                bool isEnable = Enable_Disable(sSID, CurrentCampus);
                if (isEnable)
                {
                    switch (CurrentCampus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            Grades_mtv.ActiveViewIndex = 0;
                            Females_Emptylbl.Visible = (Females_dlt.Items.Count == 0);
                            break;
                        case InitializeModule.EnumCampus.Males:
                            Grades_mtv.ActiveViewIndex = 1;
                            Males_Emptylbl.Visible = (Males_dlt.Items.Count == 0);
                            break;


                    }
                }





            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
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
        private void showmsg(string sMsg)
        {

            runScr("showmsg('" + sMsg + "');");

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

        private bool Enable_Disable(string sSNo, InitializeModule.EnumCampus Campus)
        {
            bool isEnable = false;
            string sMSG = "";
            try
            {

                string sRegMsg = "<br/>Contact the registration please | يرجى مراجعة التسجيل";

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


                isFinance = LibraryMOD.isFinanceProblems(Campus, sSNo);

                //isActive = LibraryMOD.isActiveStudent(Campus, sSNo);

                //isMissing = LibraryMOD.isMissingStudent(Campus, sSNo);

                //iStatus = LibraryMOD.GetStudentStatus(Campus, sSNo);

                //iIsFileVerified = LibraryMOD.IsFileVerifiedFromRegistrar(sSNo, Campus);

                //if (iIsFileVerified == 0 || !isActive || !isMissing || (iStatus > 0 && iStatus != 25))
                //{
                //    flag1 = true;
                //    sMSG += sRegMsg;
                //}

                if (isFinance || string.IsNullOrEmpty(sSNo))
                {
                    flag2 = true;
                    sMSG += sAccMsg;
                }


                isEnable = !(flag2);


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
                    sMSG = "Sorry, you cannot view marks | نأسف, لا يمكنك مشاهدة العلامات" + sMSG;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "errorSession", "$(function(){Sexy.error('" + sMSG + "'); });", true);
                    showErr(sMSG);
                }
            }

            return isEnable;
        }
    }
}