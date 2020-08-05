using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SIS_Student
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Session["errMsg"] = "";
            Session["isRunning"] = 1;
            Session["CurrentCampus"] = null;
            Session["CurrentYear"] = null;
            Session["CurrentSemester"] = null;
            Session["RegYear"] = null;
            Session["RegSemester"] = null;
            Session["MarkYear"] = null;
            Session["MarkSemester"] = null;
            Session["CurrentUserName"] = null;
            Session["CurrentUserNo"] = null;
            Session["CurrentRole"] = null;
            Session["CurrentSystem"] = null;
            Session["MainRoot"] = null;
            Session["UsersDV"] = null;
            Session["ObjectsRoot"] = null;
            Session["myValuePath"] = null;
            Session["RoleRoot"] = null;
            Session["ValuePath"] = null;
            Session["ObjArr"] = null;
            Session["RoleObjArr"] = null;
            Session["MirrorTable"] = null;
            Session["RCount"] = null;
            Session["LibarayBooks"] = null;
            Session["myBookSearch"] = null;
            Session["BooksBasket"] = null;
            Session["myPlan"] = null;
            Session["myList"] = null;
            Session["StudentSerialNo"] = null;
            Session["CurrentStudent"] = null;
            Session["CurrentStudentName"] = null;
            Session["CurrentAccount"] = null;
            Session["CurrentAmount"] = null;
            Session["CurrentFees"] = null;
            Session["CurrentConnection"] = null;
            Session["CurrentSession"] = null;
            Session["CurrentCourse"] = null;
            Session["CurrentClass"] = null;
            Session["CurrentMsg"] = null;
            Session["PmtSession"] = null;
            Session["PmtOrder"] = null;
            Session["PmtResultIndicator"] = null;
            Session["PmtResult"] = null;
            Session["PmtDesc"] = null;
            Session["PmtAmount"] = null;

            //Session["CurrentMajorCampus"] = null;

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            Session["errMsg"] = "";
            Session["isRunning"] = 0;
            Session["CurrentCampus"] = null;
            Session["CurrentYear"] = null;
            Session["CurrentSemester"] = null;
            Session["RegYear"] = null;
            Session["RegSemester"] = null;
            Session["MarkYear"] = null;
            Session["MarkSemester"] = null;
            Session["CurrentUserName"] = null;
            Session["CurrentUserNo"] = null;
            Session["CurrentRole"] = null;
            Session["CurrentSystem"] = null;
            Session["MainRoot"] = null;
            Session["UsersDV"] = null;
            Session["ObjectsRoot"] = null;
            Session["myValuePath"] = null;
            Session["RoleRoot"] = null;
            Session["ValuePath"] = null;
            Session["ObjArr"] = null;
            Session["RoleObjArr"] = null;
            Session["MirrorTable"] = null;
            Session["RCount"] = null;
            Session["LibarayBooks"] = null;
            Session["myBookSearch"] = null;
            Session["BooksBasket"] = null;
            Session["myPlan"] = null;
            Session["myList"] = null;
            Session["StudentSerialNo"] = null;
            Session["CurrentStudent"] = null;
            Session["CurrentStudentName"] = null;
            Session["CurrentAccount"] = null;
            Session["CurrentAmount"] = null;
            Session["CurrentFees"] = null;
            Session["CurrentConnection"] = null;
            Session["CurrentSession"] = null;
            Session["CurrentCourse"] = null;
            Session["CurrentClass"] = null;
            Session["CurrentMsg"] = null;
            Session["PmtSession"] = null;
            Session["PmtOrder"] = null;
            Session["PmtResultIndicator"] = null;
            Session["PmtResult"] = null;
            Session["PmtDesc"] = null;
            Session["PmtAmount"] = null;

            //Session["CurrentMajorCampus"] = null;

        }
    }
}