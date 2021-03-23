using System;
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
using System.Net;
using System.Security;

namespace SIS_Student
{
    public partial class Student_Services_MyRequests : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        int CurrentRole = 0;
        string sName = "";
        string sNo = "";
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
                }
                else
                {
                    //showErr("Session is expired, Login again please...");
                    ClearSession();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentStudent"] != null)
                {
                    sNo = Session["CurrentStudent"].ToString();
                    sName = Session["CurrentStudentName"].ToString();

                    if (!IsPostBack)
                    {
                        bindmyrequests();
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
        public void bindmyrequests()
        {
            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
            clientContext.Credentials = onlineCredentials;            
            List list = clientContext.Web.Lists.GetByTitle("Students_Requests");
            CamlQuery query = new CamlQuery();
            string mail = Session["sEmail"].ToString();

            Microsoft.SharePoint.Client.User user = clientContext.Web.EnsureUser(mail);
            clientContext.Load(user, x => x.Id);
            clientContext.ExecuteQuery();
            //string thisWillBeUsersLoginName = user.Id;
            int userid = user.Id;

            //clientContext.Web.EnsureUser(mail)
            query.ViewXml = "<View><Query><Where><Eq><FieldRef Name='Requester' LookupId='TRUE'/><Value Type='User'>"+ userid + "</Value></Eq></Where></Query><RowLimit>100</RowLimit></View>";
            //query.ViewXml = "<View></View>";
            Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(query);
            clientContext.Load(list);
            clientContext.Load(items);
            clientContext.ExecuteQuery();

            // create a data table
            DataTable LDT = new DataTable();
            LDT.Columns.Add("Title");
            LDT.Columns.Add("Status");
            LDT.Columns.Add("ServiceID");
            LDT.Columns.Add("Requester");
            LDT.Columns.Add("Created");
            //fill datatatable
            foreach (Microsoft.SharePoint.Client.ListItem item in items)
            {
                //var userValue = (FieldUserValue)item["Requester"];
                //var user = clientContext.Web.GetUserById(userValue.LookupId);
                //clientContext.Load(user, x => x.LoginName);
                //clientContext.ExecuteQuery();
                //string thisWillBeUsersLoginName = user.LoginName;
                //string request = item["Request"].ToString();
                LDT.Rows.Add(item["Title"], item["Status"], item["Request"], item["Requester"], item["Created"]);
            }
            Repeater1.DataSource = LDT;
            Repeater1.DataBind();
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

        protected void lnk_refresh_Click(object sender, EventArgs e)
        {
            bindmyrequests();
        }
    }
}