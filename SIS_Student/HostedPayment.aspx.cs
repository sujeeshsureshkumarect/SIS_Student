using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SIS_Student
{
    public partial class HostedPayment : System.Web.UI.Page
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
                //Initiate Payment
                Session["PmtSession"] = null;
                Session["PmtOrder"] = null;
                Session["PmtResultIndicator"] = null;
                Session["PmtResult"] = null;
                Session["PmtDesc"] = null;
                Session["PmtAmount"] = null;
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

                hdnSID.Value = Session["CurrentStudent"].ToString();
                hdnName.Value = Session["CurrentStudentName"].ToString();
                hdnACC.Value = Session["CurrentAccount"].ToString();
                decimal dAmount = Convert.ToDecimal(Session["CurrentAmount"].ToString());
                hdnAmount.Value = string.Format("{0:f}", dAmount);
                lblPayment.Text = hdnAmount.Value + " AED";
                hdnFees.Value = Session["CurrentFees"].ToString();

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

        public void SessionCreate(string orderid, double amount, string desc)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://eu-gateway.mastercard.com/api/nvp/version/56"))
                {

                    var contentList = new List<string>();
                    contentList.Add("apiOperation=CREATE_CHECKOUT_SESSION");
                    contentList.Add("apiPassword=deeb63937d9daf76831ef22114223968");
                    contentList.Add("interaction.operation=PURCHASE");
                    //contentList.Add("interaction.returnUrl=https://localhost:44387/Result");
                    //contentList.Add("apiUsername=merchant.TEST7006448");
                    contentList.Add("apiUsername=merchant.7006448");
                    //contentList.Add("merchant=TEST7006448");
                    contentList.Add("merchant=7006448");
                    contentList.Add("order.id=" + orderid + "");
                    contentList.Add("order.amount=" + amount + "");
                    contentList.Add("order.currency=AED");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    string[] sessionresult = s.Split('&');

                    //Session Results Display
                    string[] sessionidpart = sessionresult[2].Split('=');
                    string sessionid = sessionidpart[1];

                    string[] sessionresultpart = sessionresult[1].Split('=');
                    string sessionresults = sessionresultpart[1];

                    string[] sessionsuccessIndicatorpart = sessionresult[5].Split('=');
                    string sessionsuccessIndicator = sessionsuccessIndicatorpart[1];

                    string[] sessionsessionVersionpart = sessionresult[4].Split('=');
                    string sessionsessionVersion = sessionsessionVersionpart[1];

                    string[] sessionupdatestatuspart = sessionresult[3].Split('=');
                    string sessionupdatestatus = sessionupdatestatuspart[1];
                    Session["PmtSession"] = sessionid;
                    Session["PmtOrder"] = orderid;

                    Session["PmtResultIndicator"] = sessionsuccessIndicator;
                    Session["PmtResult"] = sessionresults;
                    Session["PmtDesc"] = desc;
                    Session["PmtAmount"] = amount;

                    Response.Redirect("HostedCheckOut.aspx?sessionid=" + sessionid + "&sessionresults=" + sessionresults + "&successindicator=" + sessionsuccessIndicator + "&sessionversion=" + sessionsessionVersion + "&sessionupdate=" + sessionupdatestatus + "&orderid=" + orderid + "&desc=" + desc + "&amount=" + amount + "");
                }
            }
        }

        private string getOrderID()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);

            return finalString;
        }

        protected void chkAgree_CheckedChanged(object sender, EventArgs e)
        {

            string orderid = getOrderID();
            if (orderid == "")
            {
                return;
            }
            string sDesc = hdnFees.Value + ";" + hdnSID.Value + ";" + hdnACC.Value + ";" + hdnName.Value;
            double amount = Convert.ToDouble(hdnAmount.Value);
            string description = sDesc.Trim();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            SessionCreate(orderid, amount, description);
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
    }
}