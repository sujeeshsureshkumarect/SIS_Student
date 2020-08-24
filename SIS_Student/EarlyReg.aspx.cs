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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.ClientServices;
using System.IO;
using System.Text;

namespace SIS_Student
{
    public partial class EarlyReg : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus CurrentCampus;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////Security
                //if (Session["CurrentRole"] != null)
                //{
                //    CurrentRole = (int)Session["CurrentRole"];
                //}
                //else
                //{
                //    showErr("Session is expired, Login again...");
                //}



            }
            catch (Exception ex)
            {
                showErr(ex.Message);
            }
        }

        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }
    }
}