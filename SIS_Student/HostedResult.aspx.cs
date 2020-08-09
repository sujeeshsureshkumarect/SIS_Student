using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SIS_Student
{
    public partial class HostedResult : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus CurrentCampus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentCampus"] != null)
            {
                CurrentCampus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
            }
            else
            {
                //showErr("Session is expired, Login again...");
                ClearSession();
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Session["PmtResultIndicator"] != null && Session["CurrentAccount"] != null)
                {
                    //string q = Request.Url.PathAndQuery;
                    //string[] sessionresult = q.Split('/');

                    //string sPmtOrder = sessionresult[2];
                    //string sPmtSession = sessionresult[3];
                    //string sPmtDesc = sessionresult[4];
                    //double dPmtAmount = Convert.ToDouble( sessionresult[5]);
                    //string sPmtResultIndicator = sessionresult[6];
                    //string sPmtResult = sessionresult[7];
                    string sAcc = Session["CurrentAccount"].ToString();
                    string sSID = Session["CurrentStudent"].ToString();
                    string sPmtSession = Session["PmtSession"].ToString();
                    string sPmtOrder = Session["PmtOrder"].ToString();
                    string sPmtResultIndicator = Session["PmtResultIndicator"].ToString();
                    string sPmtResult = Session["PmtResult"].ToString();
                    string sPmtDesc = Session["PmtDesc"].ToString();
                    double dPmtAmount = Convert.ToDouble(Session["PmtAmount"]);
                    int iPaidfor = 0;
                    double dVAT = 0;
                    string sVoucher = "";


                    lblOrderID.Text = sPmtOrder;
                    lblDesc.Text = sPmtDesc;
                    lblAmount.Text = string.Format("{0:f}", dPmtAmount);

                    lblPRef.Text = sPmtResultIndicator;
                    lblPStatus.Text = sPmtResult;

                    string sAccMsg = "Please contact the Accounting & Finance Department | يرجى مراجعة المحاسبة";
                    sAccMsg += "<br/>Phone Number (1): +971504188086";
                    sAccMsg += "<br/>Phone Number (2): +971544413928";
                    sAccMsg += "<br/>WhatsApp Messages: +971564065904";
                    sAccMsg += "<br/>Email: student.receivable@ect.ac.ae";

                    if (sPmtResult == "SUCCESS")
                    {
                        sVoucher = AddVoucher(sAcc, sSID, sPmtSession, "Order:" + sPmtOrder);
                        lblReceiptNo.Text = sVoucher;
                        if (sVoucher != "")
                        {

                            int iEffected = AddPayment(sVoucher, sPmtSession, "Order:" + sPmtOrder, iPaidfor, dPmtAmount, dVAT);
                            if (iEffected == 0)
                            {
                                lblResult.Text = "Error: Payment not registered in the system.";
                                divMsg.InnerHtml = sAccMsg;
                            }
                            else
                            {
                                lblResult.Text = "Payment registered in the system successfully.";
                                divMsg.InnerHtml = "";
                                Session["PmtSession"] = null;
                                Session["PmtOrder"] = null;
                                Session["PmtResultIndicator"] = null;
                                Session["PmtResult"] = null;
                                Session["PmtDesc"] = null;
                                Session["PmtAmount"] = null;
                            }
                        }
                        else
                        {
                            lblResult.Text = "Error: Payment not registered in the system.";
                            divMsg.InnerHtml = sAccMsg;
                        }
                    }
                    else
                    {
                        lblResult.Text = "Error: Payment not received.";
                        divMsg.InnerHtml = sAccMsg;
                    }


                }
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
        //Called from HostedCheckOut (completeCallback)
        [System.Web.Services.WebMethod]
        public static void SetPayment(string orderId, string sessionId, string desc, string amount, string resultIndicator, string result)
        {
            HttpContext.Current.Session["PmtSession"] = sessionId;
            HttpContext.Current.Session["PmtOrder"] = orderId;
            HttpContext.Current.Session["PmtDesc"] = desc;
            HttpContext.Current.Session["PmtAmount"] = amount;
            HttpContext.Current.Session["PmtResultIndicator"] = resultIndicator;
            HttpContext.Current.Session["PmtResult"] = result;
            //HttpContext.Current.Response.Redirect("HostedResult.aspx");
            //return "Hello " + HttpContext.Current.Session["Name"] + Environment.NewLine + "The Current Time is: " + DateTime.Now.ToString();
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

        private int AddPayment(string sVoucher, string sPmtSession, string sPmtOrder, int iPaidFor, double dAmount, double dVat)
        {
            int iEffected = 0;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "INSERT INTO Acc_Voucher_Detail";
                sSQL += " (intFy, byteFSemester, strVoucherNo, lngEntryNo, strAccountNo, datePayment, curDebit, curCredit, byteStatus, bytePaymentWay";
                sSQL += " , strUserCreate,dateCreate, strMachine, strNUser, intCampus, bytePaymentFor, curVat,LastAudit)";
                sSQL += " SELECT intFy, byteFSemester, strVoucherNo, 1 AS lngEntryNo, strAccountNo, GETDATE() AS datePayment, 0 AS curDebit, " + dAmount + " AS curCredit, 0 AS byteStatus, 6 AS bytePaymentWay,";
                sSQL += " strUserCreate, GETDATE() AS dateCreate, 'ECTSIS' AS strMachine, '" + sPmtOrder + "' AS strNUser, " + (int)CurrentCampus + " AS intCampus, " + iPaidFor + " AS bytePaymentFor, " + dVat + " AS curVat,0 as LastAudit";
                sSQL += " FROM  Acc_Voucher_Header";
                sSQL += " WHERE(strVoucherNo = '" + sVoucher + "')";


                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                iEffected = Cmd.ExecuteNonQuery();
                //if (iEffected == 0)
                //{
                //    showErr("Payment Error");
                //}

            }
            catch (Exception exp)
            {
                //showErr("Payment Error");
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iEffected;
        }

        private string AddVoucher(string sAcc, string sSID, string sPmtSession, string sPmtOrder)
        {
            string sVoucher = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                int iCYear = Convert.ToInt32(Session["CurrentYear"]);
                int iCSem = Convert.ToInt32(Session["CurrentSemester"]);
                sVoucher = NewVoucher(iCYear, iCSem);
                //,[strRemark],[strMachine],[strNUser]
                string sSQL = "INSERT INTO Acc_Voucher_Header";
                sSQL += " (intFy,byteFSemester,strVoucherNo,dateVoucher,strAccountNo,lngStudentNumber,isPrinted,strUserCreate,dateCreate,strMachine,strNUser,strRemark)";
                sSQL += " VALUES(" + iCYear + "," + iCSem + ",'" + sVoucher + "',GetDate(),'" + sAcc;
                sSQL += "','" + sSID + "',0,'" + sSID + "',GetDate(),'ECTSIS','" + sPmtSession + "','" + sPmtOrder + "')";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                int iEffected = Cmd.ExecuteNonQuery();
                if (iEffected == 0)
                {
                    sVoucher = "";
                }

            }
            catch (Exception exp)
            {
                divMsg.InnerText = exp.Message;
                sVoucher = "";
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sVoucher;
        }
        private string NewVoucher(int iCYear, int iCSem)
        {
            string sVoucher = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                int iCampus = (int)CurrentCampus;
                string sCampus = string.Format("{0:00}", iCampus);

                string sSQL = "SELECT dateStartSemester FROM Reg_Semesters AS S WHERE intStudyYear =" + iCYear + " AND byteSemester =" + iCSem;
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = sSQL;
                SqlDataReader Rd = Cmd.ExecuteReader();
                DateTime dDate = DateTime.Today.Date;
                while (Rd.Read())
                {
                    dDate = Convert.ToDateTime(Rd["dateStartSemester"]);
                }
                Rd.Close();
                string sDate = string.Format("{0:yy}", dDate) + string.Format("{0:MM}", dDate);
                sSQL = "SELECT MAX(CONVERT(INT, RIGHT(strVoucherNo, 5))) AS Voucher";
                sSQL += " FROM Acc_Voucher_Header";
                sSQL += " WHERE intFy = " + iCYear + " AND byteFSemester = " + iCSem;
                Cmd.CommandText = sSQL;
                int iMax = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString()) + 1;

                sVoucher = sCampus + sDate + string.Format("{0:00000}", iMax);

            }
            catch (Exception exp)
            {
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sVoucher;

        }
    }
}