using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIS_Student
{
    public partial class Link : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sCode = Request.QueryString["q"];
                if (sCode != null)
                {
                    bindlink(sCode);
                }
            }
        }
        public void bindlink(string sCode)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from ECT_Link_Management where sCode=@sCode", sc);
            cmd.Parameters.AddWithValue("@sCode", sCode);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["isActive"]);
                    int boolInt = isActive ? 1 : 0;
                    if(boolInt==1)//Active
                    {
                        DateTime dExpiry = Convert.ToDateTime(dt.Rows[0]["dExpiry"]);
                        TimeSpan remaintime = dExpiry - DateTime.Now;
                        if (remaintime.TotalSeconds <= 0)
                        {
                            //Expired 
                            SqlCommand cmd1 = new SqlCommand("insert into ECT_Link_Tracking values (@iLink,@dClicked,@isRedirected)", sc);
                            cmd1.Parameters.AddWithValue("@iLink", dt.Rows[0]["iLink"]);
                            cmd1.Parameters.AddWithValue("@dClicked", DateTime.Now);
                            cmd1.Parameters.AddWithValue("@isRedirected", 0);
                            try
                            {
                                sc.Open();
                                cmd1.ExecuteNonQuery();
                                sc.Close();
                            }
                            catch(Exception ex)
                            {
                                sc.Close();
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                sc.Close();
                                Response.Redirect(dt.Rows[0]["sAlternativeURL"].ToString());//Redirect to sAlternativeURL
                            }
                        }
                        else
                        {
                            //Active and Valid
                            SqlCommand cmd1 = new SqlCommand("insert into ECT_Link_Tracking values (@iLink,@dClicked,@isRedirected)", sc);
                            cmd1.Parameters.AddWithValue("@iLink", dt.Rows[0]["iLink"]);
                            cmd1.Parameters.AddWithValue("@dClicked", DateTime.Now);
                            cmd1.Parameters.AddWithValue("@isRedirected", 1);
                            try
                            {
                                sc.Open();
                                cmd1.ExecuteNonQuery();
                                sc.Close();
                            }
                            catch (Exception ex)
                            {
                                sc.Close();
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                sc.Close();
                                Response.Redirect(dt.Rows[0]["sURL"].ToString());//Redirect to sURL
                            }
                        }
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into ECT_Link_Tracking values (@iLink,@dClicked,@isRedirected)", sc);
                        cmd1.Parameters.AddWithValue("@iLink", dt.Rows[0]["iLink"]);
                        cmd1.Parameters.AddWithValue("@dClicked", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@isRedirected", 0);
                        try
                        {
                            sc.Open();
                            cmd1.ExecuteNonQuery();
                            sc.Close();
                        }
                        catch (Exception ex)
                        {
                            sc.Close();
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            sc.Close();
                            Response.Redirect(dt.Rows[0]["sAlternativeURL"].ToString());//Redirect to sAlternativeURL
                        }
                    }
                }
                else
                {
                    Response.Redirect("https://ect.ac.ae/");
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }
    }
}