using System;
using System.Data;
using System.Configuration;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for Plans
/// </summary>
/// 
///
public class PlanCourses
{
    public struct Crs
    {
        public string sCourse;
        public string sDesc;
        public bool isElectve;
        public int iCredit;
        public string sParallel;
        public List<string> sElectives;
        public List<int> iPre;
        public int iOrder;
        public int iClass;
    }

}
public class Plans
{

    private int _Plan;
    private string _PlanDesc;
    private string _sDisplay;
    private string _College;
    private string _Degree;
    private string _Major;
    private List<PlanCourses.Crs> _Courses;
    private int _StudyHours;
    private int _Elective;
    

	public Plans()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Plans(int Plan, string PlanDesc, string sDisplay, string College, string Degree, string Major, List<PlanCourses.Crs> Courses, int StudyHours, int Elective)
    {
        _Plan = Plan;
        _PlanDesc = PlanDesc;
        _sDisplay = sDisplay;
        _College = College;
        _Degree = Degree;
        _Major = Major;
        _Courses = Courses;
        _StudyHours = StudyHours;
        _Elective = Elective;
    }

    public int Plan
    {
        get { return _Plan; }
        set { _Plan = value; }
    }

    public string PlanDesc
    {
        get { return _PlanDesc; }
        set { _PlanDesc = value; }
    }

    public string SDisplay
    {
        get { return _sDisplay; }
        set { _sDisplay = value; }
    }

    public string College
    {
        get { return _College; }
        set { _College = value; }
    }

    public string Degree
    {
        get { return _Degree; }
        set { _Degree = value; }
    }

    public string Major
    {
        get { return _Major; }
        set { _Major = value; }
    }

    public List<PlanCourses.Crs> Courses
    {
        get { return _Courses; }
        set { _Courses = value; }
    }

    public int StudyHours
    {
        get { return _StudyHours; }
        set { _StudyHours = value; }
    }

    public int Elective
    {
        get { return _Elective; }
        set { _Elective = value; }
    }
       
    
}
public class PlansDAL
{
    public List<Plans> GetPlans(string sCollege, string sDegree, string sMajor,bool isPreIncluded,InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String=new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        SqlCommand Cmd, CmdCourses, CmdElect, CmdPre;
        SqlDataReader Rd, RdCourses, RdElect, RdPre;
        List<Plans> Result = new List<Plans>();
        try
        {
            string sSQL = "SELECT S.strCollege,S.strDegree,S.strSpecialization,S.strMajor,S.strDisplay,S.intStudyHours,S.ElectiveCreditHours";
            sSQL += " FROM dbo.Reg_Specializations AS S ";
            sSQL += " WHERE (1 = 1)";

            if (!string.IsNullOrEmpty(sCollege))
            {
                sSQL += " AND strCollege ='" + sCollege + "'";
            }
            if (!string.IsNullOrEmpty(sDegree))
            {
                sSQL += " AND strDegree ='" + sDegree + "'";
            }
            if (!string.IsNullOrEmpty(sMajor))
            {
                sSQL += " AND strSpecialization ='" + sMajor + "'";
            }

            Cmd = new SqlCommand(sSQL, Conn); 
            Rd = Cmd.ExecuteReader();
            int iPlan = 0;
            Plans Plan;
            PlanCourses.Crs Cr;
            string sCCollege = "";
            string sCDegree = "";
            string sCMajor = "";

            while (Rd.Read())
            {
               
                iPlan += 1;
                Plan = new Plans();
                Plan.College = Rd["strCollege"].ToString();
                Plan.Degree = Rd["strDegree"].ToString();
                Plan.Major = Rd["strSpecialization"].ToString();

                sCCollege = Plan.College;
                sCDegree = Plan.Degree;
                sCMajor = Plan.Major;

                Plan.PlanDesc = Rd["strMajor"].ToString();
                Plan.SDisplay = Rd["strDisplay"].ToString();
                Plan.Plan = iPlan;
                Plan.StudyHours = int.Parse(Rd["intStudyHours"].ToString());
                Plan.Elective = int.Parse(Rd["ElectiveCreditHours"].ToString()); 
                //Collect Plan Courses
                Plan.Courses = new List<PlanCourses.Crs>();
                Plan.Courses = GetCourses(sCCollege, sCDegree, sCMajor,isPreIncluded, Campus);
                
                Result.Add(Plan);
            }
            Rd.Close();


        }

        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            Conn.Close();

        }
        return Result;

    }

    public List<PlanCourses.Crs> GetCourses(string sCollege, string sDegree, string sMajor,bool isPreIncluded, InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        SqlCommand Cmd;
        SqlDataReader Rd;

        List<PlanCourses.Crs> Result = new List<PlanCourses.Crs>();
        PlanCourses.Crs Cr;
        int iOrder = 0;
        try{

            string sCrsSQL = "Select SC.byteOrder, SC.strCourse, C.byteCreditHours, C.strCourseDescEn AS sDesc, C.strParallel, C.bExtraLab,SC.byteCourseClass";
            sCrsSQL += " FROM dbo.Reg_Specialization_Courses AS SC INNER JOIN dbo.Reg_Courses AS C ON SC.strCourse = C.strCourse";
            sCrsSQL += " Where SC.strCollege='" + sCollege + "' and SC.strDegree='" + sDegree + "' and SC.strSpecialization='" + sMajor + "'";
            sCrsSQL += " ORDER BY SC.byteOrder";

            Cmd = new SqlCommand(sCrsSQL, Conn);
            Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                iOrder += 1;
                Cr = new PlanCourses.Crs();
                Cr.sCourse = Rd["strCourse"].ToString();
                Cr.sDesc=Rd["sDesc"].ToString();
                Cr.sParallel = Rd["strParallel"].ToString();
                Cr.iOrder = int.Parse(Rd["byteOrder"].ToString());
                Cr.iClass = int.Parse(Rd["byteCourseClass"].ToString());

                if(!Rd["byteCreditHours"].Equals(DBNull.Value))
                {
                    Cr.iCredit=int.Parse(Rd["byteCreditHours"].ToString());
                }
                else
                {
                    Cr.iCredit=0;
                }
                //Collect Elective Options
                if (Cr.sCourse == "ELECT1" || Cr.sCourse == "ELECT2" || Cr.sCourse == "MELECT1" || Cr.sCourse == "MELECT2" || Cr.sCourse == "MELECT3")
                {
                    Cr.isElectve = true;
                    Cr.sElectives = new List<string>();
                    Cr.sElectives = GetElective(sCollege, sDegree, sMajor, iOrder, Campus);
                }
                //Collect Courses Prerequisites
                if (isPreIncluded == true)
                {
                    Cr.iPre = new List<int>();
                    Cr.iPre = GetPrerequisite(sCollege, sDegree, sMajor, Cr.sCourse, Campus);
                }
                Result.Add(Cr);
            }
            Rd.Close();
           
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            
            Conn.Close();
            Conn.Dispose();
        }
        return Result;
        
    }

    public List<string> GetElective(string sCollege, string sDegree, string sMajor,int iOrder ,InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        SqlCommand Cmd;
        SqlDataReader Rd;

        List<string> Result = new List<string>();
        
        try
        {
            string sElectSQL = "SELECT sEelecive FROM dbo.Reg_Specialization_Elective AS E";
            sElectSQL += " WHERE sMajor ='" + sMajor + "' AND sDegree='" + sDegree + "' AND sCollege ='" + sCollege + "' AND intOrder =" + iOrder;
            Cmd = new SqlCommand(sElectSQL, Conn);
            Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                Result.Add(Rd["sEelecive"].ToString());
            }
            Rd.Close();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            
            Conn.Close();
            Conn.Dispose();
        }
        return Result;

    }
   
    public List<int> GetPrerequisiteofElectiveCourse(string sCollege, string sDegree, string sMajor, string sCourse, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        SqlCommand Cmd;
        SqlDataReader Rd;

        List<int> Result = new List<int>();

        try
        {
            string sPreSQL = "SELECT PSC.byteOrder";
            sPreSQL += " FROM dbo.Reg_Prerequisites AS P INNER JOIN";
            sPreSQL += " dbo.Reg_Specialization_Courses AS PSC ON P.strCollege = PSC.strCollege ";
            sPreSQL += " AND P.strDegree = PSC.strDegree AND P.strSpecialization = PSC.strSpecialization ";
            sPreSQL += " AND P.strPrerequisite = PSC.strCourse";
            sPreSQL += " WHERE (P.strCollege = '" + sCollege + "')";
            sPreSQL += " AND (P.strDegree = '" + sDegree + "') ";
            sPreSQL += " AND (P.strSpecialization = '" + sMajor + "')";
            sPreSQL += " AND (P.strCourse = '" + sCourse + "')";   
            sPreSQL += " Order by PSC.byteOrder";

            Cmd = new SqlCommand(sPreSQL, Conn);
            Rd = Cmd.ExecuteReader();
            
            while (Rd.Read())
            {
                Result.Add(int.Parse(Rd["byteOrder"].ToString()));
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            
            Conn.Close();
            Conn.Dispose();
        }
        return Result;

    }

    public List<int> GetPrerequisite(string sCollege, string sDegree, string sMajor, string sCourse, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        SqlCommand Cmd;
        SqlDataReader Rd;

        List<int> Result = new List<int>();

        try
        {
            string sPreSQL = "SELECT PSC.byteOrder, P.strPrerequisite";
            sPreSQL += " FROM  dbo.Reg_Specialization_Courses AS SC INNER JOIN dbo.Reg_Prerequisites AS P ON SC.strCourse = P.strCourse AND SC.strCollege = P.strCollege AND SC.strDegree = P.strDegree AND";
            sPreSQL += " SC.strSpecialization = P.strSpecialization INNER JOIN dbo.Reg_Specialization_Courses AS PSC ON P.strCollege = PSC.strCollege AND P.strDegree = PSC.strDegree AND  P.strSpecialization = PSC.strSpecialization AND P.strPrerequisite = PSC.strCourse";
            sPreSQL += " WHERE (SC.strCollege = '" + sCollege + "') AND (SC.strDegree = '" + sDegree + "') AND (SC.strSpecialization = '" + sMajor + "') AND (SC.strCourse = '" + sCourse + "')";
            sPreSQL += " Order by PSC.byteOrder";
            Cmd = new SqlCommand(sPreSQL, Conn);
            Rd = Cmd.ExecuteReader();
            
            while (Rd.Read())
            {
                Result.Add(int.Parse(Rd["byteOrder"].ToString()));
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            
            Conn.Close();
            Conn.Dispose();
        }
        return Result;

    }

    

    
}
