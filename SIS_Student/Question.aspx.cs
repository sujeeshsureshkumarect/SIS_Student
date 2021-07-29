using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SIS_Student
{
    public partial class Std_Vac_Stat : System.Web.UI.Page
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["q"] != null && Request.QueryString["i"] != null)
                {
                    SqlCommand cmd = new SqlCommand("select * from ECT_Question_STD_Response where sSID=@sSID and iQuestion=@iQuestion and iResponse<>0", sc);
                    cmd.Parameters.AddWithValue("@sSID", Request.QueryString["i"]);
                    cmd.Parameters.AddWithValue("@iQuestion", Request.QueryString["q"]);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        sc.Open();
                        da.Fill(dt);
                        sc.Close();

                        if (dt.Rows.Count > 0)
                        {
                            lblMsg.Text = "Already Submitted";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            form1.Visible = false;
                        }
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
            }          
        }

        protected void Btn_Signin_Click(object sender, EventArgs e)
        {
            int iResponse = 0;
            if(rdb_Yes.Checked==true)
            {
                iResponse = 1;
            }
            if(rdb_No.Checked==true)
            {
                iResponse = 2;
            }
            if((rdb_Yes.Checked==true)||(rdb_No.Checked==true))
            {
                if (Request.QueryString["q"] != null && Request.QueryString["i"] != "")
                {
                    SqlCommand cmd = new SqlCommand("update ECT_Question_STD_Response set iResponse=@iResponse,sComment=@sComment,dDate=@dDate where sSID=@sSID and iQuestion=@iQuestion", sc);
                    //cmd.Parameters.AddWithValue("@sMobile", txt_mobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@iResponse", iResponse);
                    cmd.Parameters.AddWithValue("@sComment", txt_Comment.Text.Trim());
                    cmd.Parameters.AddWithValue("@dDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@sSID", Request.QueryString["i"]);
                    cmd.Parameters.AddWithValue("@iQuestion", Request.QueryString["q"]);
                    try
                    {
                        sc.Open();
                        cmd.ExecuteNonQuery();
                        sc.Close();

                        lblMsg.Text = "Submitted Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        form1.Visible = false;

                        if(Request.QueryString["f"]=="s")
                        {
                            Response.Redirect("Dashboard");
                        }
                    }
                    catch(Exception ex)
                    {
                        sc.Close();
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sc.Close();
                    }
                }                
            }
            else
            {
                lblMsg.Text = "Please select any option";
            }
        }
    }
}