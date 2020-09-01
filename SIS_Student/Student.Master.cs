using SIS_Student.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_Student
{
    public partial class Student : System.Web.UI.MasterPage
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        DataTable Menus = new DataTable();
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CurrentURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
            if (Session["isRunning"] != null)
            {
                if (Convert.ToInt32(Session["isRunning"]) == 0)
                {
                    //setlogin();
                    //return;
                    //showErr("Session is expired, Login again please...");
                    ClearSession();
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                // showErr("Session is expired, Login again please...");
                ClearSession();
                Response.Redirect("Login.aspx");
            }
            if (Session["CurrentCampus"] != null)
            {
                string sCampus = Session["CurrentCampus"].ToString();
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                //Campus_ddl.SelectedValue = ((int)Campus).ToString();
                string sConn = "";
                Connection_StringCLS ConnectionString;
                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                        sConn = ConnectionString.Conn_string;
                        break;
                    case InitializeModule.EnumCampus.Females:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                        sConn = ConnectionString.Conn_string;
                        break;
                }

            }

            if (!IsPostBack)
            {
                //Session.RemoveAll();

                int iRSem = 0;
                int iRYear = LibraryMOD.SeperateTerm(LibraryMOD.GetRegTerm(), out iRSem);

                Session["RegYear"] = iRYear;
                Session["RegSemester"] = iRSem;

                int iCSem = 0;
                int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
                Session["CurrentYear"] = iCYear;
                Session["CurrentSemester"] = iCSem;

                Generate_Menu();
                if (Session["CurrentStudentName"] == null)
                {
                    Session["CurrentStudentName"] = "Student";
                }
                lblUser.Text = Session["CurrentStudentName"].ToString();
                lblUser1.Text = Session["CurrentStudentName"].ToString();
                getprofilepic();
            }

           

            if (Session["MainRoot"] != null)
            {
               // myRoot = (TreeNode)Session["MainRoot"];
            }
            if (Session["CurrentUserName"] != null)
            {
                //lnkLogin.Text = "Logout";
            }
            else
            {
                //lnkLogin.Text = "Login";
            }
        }
        public void Generate_Menu()
        {
            int RoleId = 0;
            
                if (Session["CurrentRole"] != null)
                {
                    RoleId = (int)Session["CurrentRole"];
                }
          
            var Menu =new DAL.DAL();
            Menus = Menu.GetMenuData(RoleId);
            DataView view = new DataView(Menus);
            view.RowFilter = "iLevel=0";
            this.rptCategories.DataSource = view;
            this.rptCategories.DataBind();
        }
        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }
        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (Menus != null)
                    {
                        DataRowView drv = e.Item.DataItem as DataRowView;
                        string ID = drv["ObjectID"].ToString();
                        string Title = drv["DisplayObjectName"].ToString();
                        DataRow[] rows = Menus.Select("ParentID='" + ID +"' AND iLevel <> 0");
                       // DataRow[] rows = Menus.Select("ParentID=" + ID);
                        if (rows.Length > 0)
                        {

                            StringBuilder sb = new StringBuilder();
                            sb.Append("<ul class='nav child_menu'>");
                            foreach (var item in rows)
                            {
                                string parentId = item["ObjectID"].ToString();
                                string parentTitle = item["DisplayObjectName"].ToString();
                                

                                DataRow[] parentRow = Menus.Select("ParentID=" + parentId);

                                if (parentRow.Count() > 0)
                                {
                                    sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");
                                    //sb.Append("</li>");
                                }
                                else
                                {                                    
                                    string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                                    //sb.Append("<li><a href='" + item["sURL"] + "'>" + item["DisplayObjectName"] + "</a>"); old with aspx
                                    sb.Append("<li><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "</a>");
                                    //sb.Append("</li>");
                                }
                                sb = CreateChild(sb, parentId, parentTitle, parentRow);
                            }
                            sb.Append("</li>");
                            sb.Append("</ul>");
                            (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                        }
                    }
                }
            }
        }
        private StringBuilder CreateChild(StringBuilder sb, string parentId, string parentTitle, DataRow[] parentRows)
        {
            if (parentRows.Length > 0)
            {
                //sb.Append("<ul class='nav child_menu'>");sub_menu
                sb.Append("<ul class='nav child_menu'>");
                foreach (var item in parentRows)
                {
                    string childId = item["ObjectID"].ToString();
                    string childTitle = item["DisplayObjectName"].ToString();
                    DataRow[] childRow = Menus.Select("ParentID=" + childId);

                    if (childRow.Count() > 0)
                    {                        
                        sb.Append("<li><a>" + item["DisplayObjectName"] + "<span class='fa fa-chevron-down'></span></a>");

                        //sb.Append("</li>");
                    }
                    else
                    {
                        //sb.Append("<li  class='sub_menu'><a href='" + item["sURL"] + "'>" + item["DisplayObjectName"] + "</a>"); old with aspx
                        string strUrl = item["sURL"].ToString().Replace(".aspx", "");
                        sb.Append("<li  class='sub_menu'><a href='" + strUrl + "'>" + item["DisplayObjectName"] + "</a>");
                        // sb.Append("</li>");
                    }
                    CreateChild(sb, childId, childTitle, childRow);
                }
                sb.Append("</li>");
                sb.Append("</ul>");
            }
            return sb;
        }
        public void logUserOut()
        {
            ClearSession();            
            Response.Redirect("Login.aspx");
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

        protected void lnk_Logout_Click(object sender, EventArgs e)
        {
            logUserOut();
        }

        public void getprofilepic()
        {
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            string studentid = Session["CurrentStudent"].ToString();
            var services = new DAL.DAL();
            DataTable dtStudentProfile = services.GetStudentDetailsForProfile(studentid, connstr.Conn_string);
            if (dtStudentProfile.Rows.Count > 0)
            {                
                Session["ProfilePIc"] = dtStudentProfile.Rows[0]["strStudentPic"].ToString();
            }
        }
    }
}