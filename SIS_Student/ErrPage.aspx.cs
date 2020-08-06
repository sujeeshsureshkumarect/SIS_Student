using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_Student
{
    public partial class ErrPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sMsg = Session["errMsg"].ToString();
            divMsg.InnerHtml = sMsg;
            Session["errMsg"] = "";
        }
    }
}