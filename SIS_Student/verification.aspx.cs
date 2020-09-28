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
    public partial class verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string refno = Request.QueryString["ref"];
                if (refno != null)
                {
                    txt_Search.Text = refno;
                    btn_Search_Click(null, null);
                }
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            String constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ECT_Doc_Reference WHERE sReference = @sReference", sc);
            cmd.Parameters.AddWithValue("@sReference", txt_Search.Text.Trim());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    lbl_Msg.Visible = false;
                    Results.Visible = true;
                    RepterDetails.DataSource = dt;
                    RepterDetails.DataBind();
                }
                else
                {
                    lbl_Msg.Visible = true;
                    Results.Visible = false;
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                //throw ex;
                lbl_Msg.Text = ex.Message;
            }
            finally
            {
                sc.Close();
            }
        }
    }
}