using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;


namespace SIS_Student
{
    public partial class LibBookSearch : System.Web.UI.Page
    {
        int CurrentRole;

        public struct Book
        {
            public string BookID;
            public string AccNo;
            public string Title;
            public string Author;
            public string Publisher;
            public string Subject;
            public string Edition;
            public string Published;
            public string Library;
            public string Status;
            public string iStatus;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Book> myBooks = new List<Book>();

            string sAccNo = "";
            try
            {
                //Security

                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                }
                else
                {
                    //showErr("Session is expired, Login again please...");
                    ClearSession();
                    Response.Redirect("Login.aspx");

                }

                if (!IsPostBack)
                {
                    //int i = Convert.ToInt32(Session["RegYear"]);
                    //i = Convert.ToInt32(Session["RegSemester"]);
                    //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Lib_BookSearch,
                    //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    //{
                    //    showErr("Sorry, you don't have the permission to view this page...");

                    //}
                    //else
                    //{
                    int iAdded = 0;
                    if (Session["LibarayBooks"] != null && Session["myBookSearch"] != null)
                    {
                        myBooks = (List<Book>)Session["LibarayBooks"];
                        txtCriteria.Text = Session["myBookSearch"].ToString();
                        showBooks(getFoundedBooks(myBooks, txtCriteria.Text), false);
                    }
                    else
                    {
                        myBooks = getBooks();
                        showBooks(myBooks, true);
                        Session["LibarayBooks"] = myBooks;
                    }
                    if (Request.QueryString.Count != 0)
                    {
                        sAccNo = Request.QueryString["accno"].ToString();
                        if (sAccNo != "")
                        {
                            iAdded = addtoBasket(sAccNo, myBooks);
                        }
                    }
                    //myBooks.Clear();

                    if (iAdded > 0)
                    {
                        lblResult.Text = "1 Book added to the basket,click on the basket to print or search again to add more...";
                    }
                    else
                    {
                        lblResult.Text = "Enter search criteria then click on search above ...";
                    }
                    //}

                }
                else
                {
                    if (Session["LibarayBooks"] != null && txtCriteria.Text != "")
                    {
                        myBooks = (List<Book>)Session["LibarayBooks"];
                        showBooks(getFoundedBooks(myBooks, txtCriteria.Text), false);
                        Session["myBookSearch"] = txtCriteria.Text;
                    }
                    else
                    {
                        //myBooks.Clear();
                        showBooks(myBooks, true);
                        lblResult.Text = "Enter search criteria then click on search above ...";
                    }
                }

                if (Session["BooksBasket"] != null)
                {
                    imgCart.Visible = (((List<Book>)Session["BooksBasket"]).Count > 0);
                }

            }
            catch (Exception exp)
            {
                //showErr("Somthing went wrong, login again please...");
                ClearSession();
                Response.Redirect("Login.aspx");
            }
            finally
            {

            }
        }
        private List<Book> getBooks()
        {
            List<Book> myBooks = new List<Book>();

            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
            conn.Open();
            try
            {

                string sSQL = "SELECT B.BookID, B.AccesstionNo, B.Title, B.Author, B.Publisher, B.Subject, B.Edition, B.PublishedYear, B.Campus AS Library, S.strBookStatusEn AS Status";
                sSQL += " FROM Library_Search_Web AS B INNER JOIN LibBooksStatuses AS S ON B.BookStatusID = S.BookStatusID";
                sSQL += " ORDER BY B.PublishedYear DESC, B.Title";

                SqlCommand cmd = new SqlCommand(sSQL, conn);

                SqlDataReader rd = cmd.ExecuteReader();
                Book myBook = new Book();
                while (rd.Read())
                {
                    myBook = new Book();
                    myBook.BookID = rd["BookID"].ToString();
                    myBook.AccNo = rd["AccesstionNo"].ToString();
                    myBook.Title = rd["Title"].ToString();
                    myBook.Author = rd["Author"].ToString();
                    myBook.Publisher = rd["Publisher"].ToString();
                    myBook.Subject = rd["Subject"].ToString();
                    myBook.Edition = rd["Edition"].ToString();
                    myBook.Published = rd["PublishedYear"].ToString();
                    myBook.Library = rd["Library"].ToString();
                    myBook.Status = rd["Status"].ToString();
                    if (rd["Status"].ToString() == "Available")
                    {
                        myBook.iStatus = "1";
                    }
                    else
                    {
                        myBook.iStatus = "0";
                    }
                    myBooks.Add(myBook);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return myBooks;

        }

        private List<Book> getFoundedBooks(List<Book> myLibrary, string myCriteria)
        {
            List<Book> myBooks = new List<Book>();

            try
            {
                myBooks = myLibrary.FindAll(delegate (Book B) { return B.Title.ToLower().Contains(myCriteria.ToLower()) || B.Publisher.ToLower().Contains(myCriteria.ToLower()) || B.Subject.ToLower().Contains(myCriteria.ToLower()) || B.Author.ToLower().Contains(myCriteria.ToLower()); });
                lblResult.Text = myBooks.Count.ToString() + " book(s) found...";
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

            }
            return myBooks;

        }
        private void showBooks(List<Book> myBooks, bool HeaderOnly)
        {

            try
            {
                //string sLink = "";
                string myTable = "";
                //int iStatus = 0;
                //myTable += "<thead><tr class='headings'><th>#</th><th>Add?</th><th >Accesstion No</th><th>Title</th><th>Author</th><th >Publisher</th><th >Subject</th><th>Edition</th><th >Published</th><th>Library</th ><th>Status</th></tr></thead>";
                if (!HeaderOnly)
                {
                    //string cssClass = "even pointer";

                    //for (int i = 0; i < myBooks.Count; i++)
                    //{
                    //    if (i % 2 == 0)
                    //    {
                    //        cssClass = "R_NormalWhite";
                    //    }
                    //    else
                    //    {
                    //        cssClass = "R_NormalGray";
                    //    }
                    //    myTable += "<tr class='" + cssClass + "'>";
                    //    myTable += "<td>" + (i + 1).ToString() + "</td>";
                    //    iStatus = 0;
                    //    if (myBooks[i].Status == "Available")
                    //    {
                    //        iStatus = 1;
                    //    }
                    //    myTable += "<td ><input id='btn" + (i + 1).ToString() + "' type='button' value='Add to basket' onclick='addtobasket(" + myBooks[i].AccNo + "," + iStatus + ");'></input></td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].AccNo + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Title + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Author + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Publisher + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Subject + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Edition + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Published + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Library + "</td>";
                    //    myTable += "<td style='font-size: small'>" + myBooks[i].Status + "</td>";

                    //    myTable += "</tr>";
                    //}
                    //myTable += "</table>";

                    ////Literal1.Text = myTable;
                    if(myBooks.Count>0)
                    {
                        divResult.Visible = true;
                        RepterDetails.Visible = true;
                       
                        RepterDetails.DataSource = myBooks;
                        RepterDetails.DataBind();
                    }
                    else
                    {
                        divResult.Visible = true;
                        RepterDetails.Visible = false;
                        RepterDetails.DataSource = myBooks;
                        RepterDetails.DataBind();
                    }

                }
                else
                {
                    //myTable = "No Results found...";

                    //Literal1.Text = myTable;
                    // divResult.InnerHtml = myTable;

                    DataTable dt = new DataTable();
                    RepterDetails.DataSource = dt;
                    RepterDetails.DataBind();
                    RepterDetails.Visible = false;
                }

                //myTable += "</table>";

                ////Literal1.Text = myTable;
                //divResult.InnerHtml = myTable;

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

            }

        }
        //private void showBooks(List<Book> myBooks, bool HeaderOnly)
        //{

        //    try
        //    {
        //        string sLink = "";
        //        string myTable = "<table class='table table-striped jambo_table bulk_action' width='100%'>";
        //        int iStatus = 0;
        //        myTable += "<thead><tr class='headings'><th class='column-title'>#</th><th class='column-title'>Add?</th><th class='column-title'>Accesstion No</th><th class='column-title'>Title</th><th>Author</th><th class='column-title'>Publisher</th><th class='column-title'>Subject</th><th class='column-title'>Edition</th><th class='column-title'>Published</th><th>Library</th class='column-title'><th>Status</th></tr></thead>";
        //        if (!HeaderOnly)
        //        {
        //            string cssClass = "even pointer";

        //            for (int i = 0; i < myBooks.Count; i++)
        //            {
        //                if (i % 2 == 0)
        //                {
        //                    cssClass = "even pointer";
        //                }
        //                else
        //                {
        //                    cssClass = "odd pointer";
        //                }
        //                myTable += "<tr class='" + cssClass + "'>";
        //                myTable += "<td>" + (i + 1).ToString() + "</td>";
        //                iStatus = 0;
        //                if (myBooks[i].Status == "Available")
        //                {
        //                    iStatus = 1;
        //                }
        //                myTable += "<td class='a-center '><input id='btn" + (i + 1).ToString() + "' type='button' value='Add to basket' onclick='addtobasket(" + myBooks[i].AccNo + "," + iStatus + ");'/></td>";
        //                myTable += "<td >" + myBooks[i].AccNo + "</td>";
        //                myTable += "<td>" + myBooks[i].Title + "</td>";
        //                myTable += "<td>" + myBooks[i].Author + "</td>";
        //                myTable += "<td>" + myBooks[i].Publisher + "</td>";
        //                myTable += "<td>" + myBooks[i].Subject + "</td>";
        //                myTable += "<td>" + myBooks[i].Edition + "</td>";
        //                myTable += "<td >" + myBooks[i].Published + "</td>";
        //                myTable += "<td>" + myBooks[i].Library + "</td>";
        //                myTable += "<td>" + myBooks[i].Status + "</td>";

        //                myTable += "</tr>";
        //            }

        //        }

        //        myTable += "</table>";

        //        //Literal1.Text = myTable;
        //        divResult.InnerHtml = myTable;

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{0} Exception caught.", ex.Message);
        //    }
        //    finally
        //    {

        //    }

        //}

        private DataSet getBasket(List<Book> myBasket)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("Serial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("AccNo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Title", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Author", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Publisher", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Subject", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Edition", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Published", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Library", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                int Serial = 0;
                for (int i = 0; i < myBasket.Count; i++)
                {

                    dr = dt.NewRow();
                    Serial += 1;
                    dr["Serial"] = Serial;
                    dr["AccNo"] = myBasket[i].AccNo;
                    dr["Title"] = myBasket[i].Title;
                    dr["Author"] = myBasket[i].Author;
                    dr["Publisher"] = myBasket[i].Publisher;
                    dr["Subject"] = myBasket[i].Subject;
                    dr["Edition"] = myBasket[i].Edition;
                    dr["Published"] = myBasket[i].Published;
                    dr["Library"] = myBasket[i].Library;

                    dt.Rows.Add(dr);

                }
                dt.TableName = "Books";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
            return ds;
        }

        private void Export(InitializeModule.ECT_Buttons iExport, List<Book> myCart)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                DataSet rptDS = new DataSet();
                string reportPath = "";

                rptDS = getBasket(myCart);

                reportPath = Server.MapPath("Reports/BooksBasket.rpt");

                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

            }
        }


        //protected void lnkPrint_Command(object sender, CommandEventArgs e)
        //{
        //    Export(InitializeModule.ECT_Buttons.Print, Convert.ToInt32( e.CommandArgument)); 
        //}

        //Example:Calling server function by client
        //[System.Web.Services.WebMethod]
        //public static string GetCurrentTime(string name)
        //{
        //    return "Hello " + name + Environment.NewLine + "The Current Time is: "
        //        + DateTime.Now.ToString();
        //}

        private int addtoBasket(string accno, List<Book> myLibrary)
        {
            int iAdded = 0;
            List<Book> mySelected = new List<Book>();
            List<Book> myBasket = new List<Book>();
            try
            {

                mySelected = myLibrary.FindAll(delegate (Book B) { return B.AccNo == accno; });
                if (Session["BooksBasket"] != null)
                {
                    myBasket = (List<Book>)Session["BooksBasket"];
                }
                for (int i = 0; i < mySelected.Count; i++)
                {
                    iAdded++;
                    myBasket.Add(mySelected[i]);
                }
                Session["BooksBasket"] = myBasket;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

            }


            return iAdded;
        }
        protected void imgCart_Click(object sender, EventArgs e)
        {
            List<Book> myBasket;
            if (Session["BooksBasket"] != null)
            {
                myBasket = (List<Book>)Session["BooksBasket"];
                Export(InitializeModule.ECT_Buttons.Print, myBasket);
            }

        }
    }
}