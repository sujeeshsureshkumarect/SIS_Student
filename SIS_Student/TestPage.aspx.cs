﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_Student
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void generatepdf()
        {
            //try
            //{
            //    Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
            //    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //    pdfDoc.Open();
            //    Paragraph Text = new Paragraph("This is test file");
            //    pdfDoc.Add(Text);
            //    pdfWriter.CloseStream = false;
            //    pdfDoc.Close();
            //    Response.Buffer = true;
            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
            //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //    Response.Write(pdfDoc);
            //    Response.End();
            //}
            //catch (Exception ex)
            //{ 
            //    Response.Write(ex.Message); 
            //}

        }
    }

   
}