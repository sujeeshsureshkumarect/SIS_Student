using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

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
                                checkfirstpayment(sAcc);//checking that its first payment done by student or not
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

        public void checkfirstpayment(string sAcc)
        {
            //checking that its first payment done by student or not
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT count(strAccountNo) as Count FROM [ECTData].[dbo].[Acc_Voucher_Detail] where strAccountNo=@strAccountNo", sc);
            cmd.Parameters.AddWithValue("@strAccountNo", sAcc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["Count"]);
                    if(count==1)//First Payment
                    {
                        int opportunityid = 0;
                        string sSID = Session["CurrentStudent"].ToString();
                        int iSerial = GetSerial(sSID);
                        Session["StudentSerialNo"] = iSerial;
                        SqlCommand cmd1 = new SqlCommand("select iOpportunityID from Reg_Applications where lngSerial=@lngSerial", sc);
                        cmd1.Parameters.AddWithValue("@lngSerial", iSerial);
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        try
                        {
                            sc.Open();
                            da1.Fill(dt1);
                            sc.Close();

                            if(dt1.Rows.Count>0)
                            {
                                opportunityid =Convert.ToInt32(dt1.Rows[0]["iOpportunityID"]);
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

                        
                        //Check Payment >= Payment Value
                        SqlCommand cmd2 = new SqlCommand("select iAdmissionPaymentType,cAdmissionPaymentValue from Reg_Student_Accounts where strAccountNo=@strAccountNo", sc);
                        cmd2.Parameters.AddWithValue("@strAccountNo", sAcc);
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        try
                        {
                            sc.Open();
                            da2.Fill(dt2);
                            sc.Close();

                            if(dt2.Rows.Count>0)
                            {
                                double paymentvalue = Convert.ToDouble(dt2.Rows[0]["cAdmissionPaymentValue"]);
                                if(Convert.ToDouble(Session["PmtAmount"])>= paymentvalue)
                                {
                                    //Call API Function Update Opportunity
                                    lnkOpportunity_Command(opportunityid);
                                    updateuserole(sAcc);
                                }
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
                    }
                }
            }
            catch(Exception ex)
            {
                sc.Close();
                divMsg.InnerText = ex.Message;
            }
            finally
            {
                sc.Close();
            }
        }
        public void updateuserole(string sAcc)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                string sSQL = "";
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                int iStatus = 2;

                Cmd.CommandText = "Create_Online_User";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = Session["CurrentStudent"].ToString();
                Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 105;
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();


                int iRSem = 0;
                int iRYear = LibraryMOD.SeperateTerm(LibraryMOD.GetRegTerm(), out iRSem);

                sSQL = "UPDATE Reg_Student_Accounts";
                sSQL += " SET intOnlineStatus =" + iStatus;
                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate(),intRegYear=" + iRYear + ",byteRegSem=" + iRSem + " ";
                sSQL += " Where strAccountNo='" + sAcc + "'";
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = sSQL;
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);                
                //lbl_Msg.Text = "Online Status not updated";
                //div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }
        private int GetSerial(string sNumber)
        {
            int iserial = 0;
            try
            {
                ApplicationsDAL myapp = new ApplicationsDAL();
                iserial = myapp.GetSerial(CurrentCampus, sNumber);
            }
            catch (Exception ex)
            {
            }
            return iserial;
        }
        public void lnkOpportunity_Command(int opportunityid)
        {
            string sSID = Session["CurrentStudent"].ToString();
            int iOpportunity = 0;
            if (isOpportunitySet(sSID, out iOpportunity))
            {
               
            }
            else
            {
                if (iOpportunity > 0 && iOpportunity.ToString() == opportunityid.ToString())
                {
                    //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "setOpportunity();", true);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.DefaultConnectionLimit = 9999;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string accessToken = InitializeModule.CxPwd;

                    using (var httpClient = new HttpClient())
                    {
                        using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/" + opportunityid + ""))
                        {
                            request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                            request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                            request.Content = new StringContent("{\n\t\"customFields\": {\n\t\t\"c\": {\n\t\t\t\"paymentstatus\": {\n                \"id\": 1094,\n                \"lookupName\": \"Payment Succeeded\"\n            }\n\t\t}\n\t},\n\t\"statusWithType\": {\n        \"status\": {\n            \"id\": 11\n        }\n    }\n}");
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                            var task = httpClient.SendAsync(request);
                            task.Wait();
                            var response = task.Result;
                            string s = response.Content.ReadAsStringAsync().Result;
                            //If Status 200
                            if (response.IsSuccessStatusCode == true)
                            {
                                SetOpportunity(sSID);
                            }
                        }
                    }
                }
                else
                {
                    divMsg.InnerText = "Opportunity ID must be saved first.";
                    //div_msg.Visible = true;
                }
            }
        }
        private bool isOpportunitySet(string sSID, out int iOpportunity)
        {
            bool isSet = false;
            iOpportunity = 0;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "SELECT iOpportunityID, isOpportunitySet";
                sSQL += " FROM Reg_Applications";
                sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    iOpportunity = Convert.ToInt32(Rd["iOpportunityID"].ToString());
                    isSet = Convert.ToBoolean(Rd["isOpportunitySet"].ToString());
                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                divMsg.InnerText = ex.Message;
                //div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isSet;
        }
        public static bool SetOpportunity(string sSID)
        {
            bool isSet = false;
            //U cannot use var from out of the scope. (Campus)
            InitializeModule.EnumCampus campus = InitializeModule.EnumCampus.Males;
            if (sSID.Contains("AF") || sSID.Contains("ESF"))
            {
                campus = InitializeModule.EnumCampus.Females;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "UPDATE Reg_Applications SET isOpportunitySet=1";
                sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                isSet = (Cmd.ExecuteNonQuery() > 0);


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isSet;
        }
    }
}