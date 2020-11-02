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
    public partial class Balance : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus CurrentCampus;
        string sSID = "";
        string sACC = "";
        string sName = "";
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
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Payment,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        //showmsg("Sorry, You don't have the permission to view this page...");
                        //runScr("hidesidebar();");
                        showErr("Sorry, You don't have the permission to view this page...");
                    }

                    CurrentCampus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    sSID = Session["CurrentStudent"].ToString();
                    sName = Session["CurrentStudentName"].ToString();
                    getStdAcc();
                    Session["CurrentAccount"] = sACC;
                    decimal dAmount = 0;
                    if(Request.QueryString["amt"]!=null && Request.QueryString["amt"] != "")
                    {
                        dAmount = Convert.ToDecimal(Request.QueryString["amt"]);
                    }
                    else
                    {
                        dAmount = LibraryMOD.GetStudentBalanceBTS(sSID, CurrentCampus);
                    }

                    int iCurrentTerm = LibraryMOD.GetCurrentTerm();
                    if (isHidden(sSID, iCurrentTerm))
                    {
                        lblOBalanceVATBTS.Text = "-----";
                    }
                    else
                    {
                        lblOBalanceVATBTS.Text = string.Format("{0:f}", dAmount);
                    }

                    if (dAmount < 0) { dAmount = 1; }

                    txtPayment.Text = string.Format("{0:f}", dAmount);
                }



                //switch(CurrentCampus)
                //{
                //    case InitializeModule.EnumCampus.Females:
                //        mtvBalance.ActiveViewIndex = 0;

                //        break;
                //    case InitializeModule.EnumCampus.Males:
                //        mtvBalance.ActiveViewIndex = 1;

                //        break;


                //}

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

        private void getStdAcc()
        {
            Connection_StringCLS connstr = new Connection_StringCLS(CurrentCampus);
            SqlConnection conn = new SqlConnection(connstr.Conn_string);
            conn.Open();
            try
            {
                //SELECT strAccountNo FROM Reg_Student_Accounts WHERE lngStudentNumber=''
                sACC = LibraryMOD.GetColValue(conn, "strAccountNo", "Reg_Student_Accounts", "lngStudentNumber='" + sSID + "'");
            }

            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        //protected void lnkPayNow_Click(object sender, EventArgs e)
        //{
        //    Session["CurrentAmount"] = string.Format("{0:f}", txtPayment.Text);
        //    Response.Redirect("Terms.aspx");
        //}

        private bool isHidden(string sSID, int iCurrent)
        {
            bool hide = false;
            try
            {
                int iLTR = LibraryMOD.GetLTRBTS(sSID, CurrentCampus);
                hide = (iLTR > iCurrent);
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {

            }

            return hide;
        }

        protected void lnkPayNow_Click(object sender, EventArgs e)
        {
            Session["CurrentFees"] = "Tution Fees";
            Session["CurrentAmount"] = string.Format("{0:f}", txtPayment.Text);
            Response.Redirect("HostedPayment.aspx");
        }
    }
}