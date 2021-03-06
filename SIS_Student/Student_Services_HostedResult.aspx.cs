﻿using System;
using System.Collections;
using System.Configuration;
using SIS_Student.DAL;
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
using System.Data.SqlClient;
using System.Drawing;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;
using System.Security;
using System.IO;
using Microsoft.Online.SharePoint.TenantAdministration;
using System.Text;
using System.Linq;
using CrystalDecisions.ReportAppServer.ClientDoc;


namespace SIS_Student
{
    public partial class Student_Services_HostedResult : System.Web.UI.Page
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
                    double dGrossAmount= Convert.ToDouble(Session["PmtAmount"]);
                    double dPmtAmount = Math.Round((dGrossAmount/1.05),2);

                    int iPaidfor =Convert.ToInt32(Session["FeesType"]);
                    double dVAT = Math.Round((dGrossAmount - dPmtAmount),2);
                    string sVoucher = "";


                    lblOrderID.Text = sPmtOrder;
                    lblDesc.Text = sPmtDesc;
                    lblAmount.Text = string.Format("{0:f}", dGrossAmount);

                    lblPRef.Text = sPmtResultIndicator;
                    lblPStatus.Text = sPmtResult;

                    string sAccMsg = "Please contact the Accounting & Finance Department | يرجى مراجعة المحاسبة";
                    sAccMsg += "<br/>Phone Number (1): +971504188086";
                    sAccMsg += "<br/>Phone Number (2): +971544413928";
                    sAccMsg += "<br/>WhatsApp Messages: +971564065904";
                    sAccMsg += "<br/>Email: student.receivable@ect.ac.ae";

                    if (sPmtResult == "SUCCESS")
                    {
                        updateonlinepayment_beforevoucher(sPmtOrder);
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
                                updateonlinepayment(sPmtOrder, sVoucher);
                                sentdatatoSPLIst(sVoucher);                                
                                lblResult.Text = "Payment registered in the system successfully.";
                                divMsg.InnerHtml = "";
                                Session["PmtSession"] = null;
                                Session["PmtOrder"] = null;
                                Session["PmtResultIndicator"] = null;
                                Session["PmtResult"] = null;
                                Session["PmtDesc"] = null;
                                Session["PmtAmount"] = null;
                                Session["CurrentService"] = null;
                                Session["CurrentServiceName"] = null;
                                Session["CurrentServiceAmount"] = null;
                                Session["CurrentdtSPList"] = null;
                                Session["filePath"] = null;
                                Session["CurrentAccount"] = null;
                                Session["cancelpage"] = null;
                                Session["FeesType"] = null;
                                Session["HostEmail"] = null;
                                //Print_btn.Visible = true;
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
        public void updateonlinepayment_beforevoucher(string sOrder)
        {
            CurrentCampus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
            Connection_StringCLS connstr = new Connection_StringCLS(CurrentCampus);
            SqlConnection sc = new SqlConnection(connstr.Conn_string);
            SqlCommand cmd = new SqlCommand("update [ECTData].[dbo].[Acc_Payment_Order] set isCaptured=@isCaptured,dCaptured=@dCaptured,isCanceled=@isCanceled where sOrder=@sOrder", sc);
            cmd.Parameters.AddWithValue("@isCaptured", true);
            cmd.Parameters.AddWithValue("@dCaptured", DateTime.Now);
            //cmd.Parameters.AddWithValue("@sVoucherNo", sVoucherNo);
            cmd.Parameters.AddWithValue("@isCanceled", false);
            cmd.Parameters.AddWithValue("@sOrder", sOrder);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        public void updateonlinepayment(string sOrder, string sVoucherNo)
        {
            CurrentCampus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
            Connection_StringCLS connstr = new Connection_StringCLS(CurrentCampus);
            SqlConnection sc = new SqlConnection(connstr.Conn_string);
            SqlCommand cmd = new SqlCommand("update [ECTData].[dbo].[Acc_Payment_Order] set sVoucherNo=@sVoucherNo,tOrder=@tOrder where sOrder=@sOrder", sc);
            //cmd.Parameters.AddWithValue("@isCaptured", true);
            //cmd.Parameters.AddWithValue("@dCaptured", DateTime.Now);
            cmd.Parameters.AddWithValue("@sVoucherNo", sVoucherNo);
            //cmd.Parameters.AddWithValue("@isCanceled", false);
            cmd.Parameters.AddWithValue("@sOrder", sOrder);
            cmd.Parameters.AddWithValue("@tOrder", DBNull.Value);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }
        //public void generatepdf()
        //{
        //    string html1 = String.Empty;
        //    using (TextWriter myTextWriter1 = new StringWriter(new StringBuilder()))
        //    {
        //        using (HtmlTextWriter myWriter1 = new HtmlTextWriter(myTextWriter1))
        //        {
        //            fulldiv.RenderControl(myWriter1);
        //            html1 = myTextWriter1.ToString();
        //        }
        //    }
        //    html1 = "<div>< img src = 'images/ECT Logo.png' style = 'height:100%;width:30%;margin-left: auto;margin-right: auto; display: block;' /></ div ><br/><hr/> " + html1+"<br/><hr/>";
        //    StringReader sr = new StringReader(html1);

        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
        //        pdfDoc.Open();

        //        htmlparser.Parse(sr);
        //        pdfDoc.Close();

        //        byte[] bytes = memoryStream.ToArray();
        //        memoryStream.Close();

        //        // Clears all content output from the buffer stream                 
        //        Response.Clear();
        //        // Gets or sets the HTTP MIME type of the output stream.
        //        Response.ContentType = "application/pdf";
        //        // Adds an HTTP header to the output stream
        //        Response.AddHeader("Content-Disposition", "attachment; filename=Student_Services_PaymentReceipt.pdf");

        //        //Gets or sets a value indicating whether to buffer output and send it after
        //        // the complete response is finished processing.
        //        Response.Buffer = true;
        //        // Sets the Cache-Control header to one of the values of System.Web.HttpCacheability.
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        // Writes a string of binary characters to the HTTP output stream. it write the generated bytes .
        //        Response.BinaryWrite(bytes);
        //        // Sends all currently buffered output to the client, stops execution of the
        //        // page, and raises the System.Web.HttpApplication.EndRequest event.

        //        Response.End();
        //        // Closes the socket connection to a client. it is a necessary step as you must close the response after doing work.its best approach.
        //        Response.Close();
        //    }


        //}
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        public void sentdatatoSPLIst(string sVoucher)
        {
            DataTable CurrentdtSPList = Session["CurrentdtSPList"] as DataTable;

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("Students_Requests");
            ListItemCreationInformation itemInfo = new ListItemCreationInformation();
            Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);
            //string refno = Create16DigitString();
            myItem["Title"] = CurrentdtSPList.Rows[0]["Title"].ToString();
            //myItem["RequestID"] = refno;
            myItem["Year"] = CurrentdtSPList.Rows[0]["Year"].ToString();
            myItem["Semester"] = CurrentdtSPList.Rows[0]["Semester"].ToString();
            myItem["Request"] = CurrentdtSPList.Rows[0]["Request"].ToString();
            myItem["RequestNote"] = CurrentdtSPList.Rows[0]["RequestNote"].ToString();
            myItem["ServiceID"] = CurrentdtSPList.Rows[0]["ServiceID"].ToString();
            myItem["Fees"] = CurrentdtSPList.Rows[0]["Fees"].ToString();
            //myItem["Requester"] = clientContext.Web.EnsureUser(hdf_StudentEmail.Value);
            myItem["Requester"] = clientContext.Web.EnsureUser(CurrentdtSPList.Rows[0]["Requester"].ToString());
            myItem["StudentID"] = CurrentdtSPList.Rows[0]["StudentID"].ToString();
            myItem["StudentName"] = CurrentdtSPList.Rows[0]["StudentName"].ToString();
            myItem["Contact"] = CurrentdtSPList.Rows[0]["Contact"].ToString();
            myItem["Finance"] = clientContext.Web.EnsureUser(CurrentdtSPList.Rows[0]["Finance"].ToString());
            myItem["FinanceAction"] = CurrentdtSPList.Rows[0]["FinanceAction"].ToString();
            myItem["FinanceNote"] = "";
            myItem["Host"] = clientContext.Web.EnsureUser(CurrentdtSPList.Rows[0]["Host"].ToString());
            myItem["HostAction"] = CurrentdtSPList.Rows[0]["HostAction"].ToString();
            myItem["HostNote"] = "";
            //myItem["Provider"] = "";
            myItem["ProviderAction"] = CurrentdtSPList.Rows[0]["ProviderAction"].ToString();
            myItem["ProviderNote"] = "";
            myItem["Status"] = CurrentdtSPList.Rows[0]["Status"].ToString();
            myItem["Payment_Ref"] = sVoucher;
            //myItem["Modified"] = DateTime.Now;
            //myItem["Created"] = DateTime.Now;
            //myItem["Created By"] = hdf_StudentEmail.Value;
            //myItem["Modified By"] = hdf_StudentEmail.Value;
            try
            {
                myItem.Update();

                if (Session["filePath"]!=null)
                {
                    var attachment = new AttachmentCreationInformation();

                    //flp_Upload.SaveAs(Server.MapPath("~/Upload/" + flp_Upload.FileName));
                    //string FileUrl = Server.MapPath("~/Upload/" + flp_Upload.FileName);

                    string filePath = Session["filePath"].ToString();
                    attachment.FileName = Path.GetFileName(filePath);
                    attachment.ContentStream = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
                    Attachment att = myItem.AttachmentFiles.Add(attachment);
                }

                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                clientContext.Credentials = onlineCredentials;
                clientContext.ExecuteQuery();

                //string FileUrls = Server.MapPath("~/Upload/" + flp_Upload.FileName);
                //System.IO.File.Delete(FileUrls);
                if (Session["filePath"] != null)
                {
                    string FileUrls = Session["filePath"].ToString();
                    System.IO.File.Delete(FileUrls);
                }

                lbl_Msg.Text = "Request (ID# " + CurrentdtSPList.Rows[0]["Title"].ToString() + ") Generated Successfully";
                lbl_Msg.Visible = true;
                div_msg1.Visible = true;                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
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
                sSQL += "','" + sSID + "',0,'" + sSID + "',GetDate(),'ECTSIS','" + sPmtSession + "','" + sPmtOrder + "-"+ Session["CurrentService"].ToString() + "')";
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

        //protected void Print_btn_Click(object sender, EventArgs e)
        //{
        //    generatepdf();
        //}
    }
}