using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace SIS_Student
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string f = context.Request.QueryString.Get("f");
            f = "//management-m/ETSD/ETS/Images/Students/" + f + ".jpeg";
            Image image = Image.FromFile(f);
            context.Response.Clear();
            context.Response.ClearHeaders();
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            context.Response.ContentType = "image/jpeg";
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}