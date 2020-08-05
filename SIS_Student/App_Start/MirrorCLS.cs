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
using System.Collections;

/// <summary>
/// Summary description for MirrorCLS
/// /summary>
/// 
public class StudentCourses
{
    public struct StudentMirror
    {
        public int iStudyYear;
        public int iSemester;
        public string sCourse;
        public string sGrade;
        public int iCredit;
        public decimal dPoint;
        public int iCanceledYear;
        public int iCanceledSemester;
        public bool isPassed;
        public bool isCalculated;
        public bool isDisactivated;
        public bool isRecommended;
        public int iOrder;
        public int iClass;
        public int RegTerm;
    }
}
public class MirrorCLS
{
    private int _Serial;
    private string _StudentNumber;
    private string _Name;
    private int _iPeriod;
    private string _Period;
    private string _sDegree;
    private string _sMajor;
    private string _Major;
    private decimal _CGPA;
    private string _sSection;
    private decimal _SGPA;
    private string _ENG;
    private decimal _Score;
    private int _LTR;
    private int _Remind;
    private string _Phone1;
    private string _Phone2;
    private string _Status;
    private int _Hours;
    private int _Passed;
    private int _RegTerm;
    private int _MaxESL;
    private string _Advisor;
    private string _Note;   
    private bool _isENGRequired;
    private bool _isAccWanted;
    private StudentCourses.StudentMirror[] _Mirror;
    private List<Advised.Courses> _Recommended;
    
//SELECT sStudentNumber, sCourse, sGrade, bPassIt, byteOrder
//FROM dbo.Web_Max_Grades AS MG
//ORDER BY byteOrder, sStudentNumber

    public MirrorCLS()
    {
        

    }

    public MirrorCLS(int Serial, string StudentNumber, string Name, int iPeriod, string Period, string Major,string sDegree,string sMajor, decimal CGPA, string ENG, decimal Score, int LTR,int Remind, string Phone1, string Phone2,string Status, int Hours, int Passed, int MaxESL,bool isENGRequired, string Advisor,int iRegTerm, StudentCourses.StudentMirror[] Mirror, List<Advised.Courses> Recommended)
	{
        _Serial=Serial;
        _StudentNumber = StudentNumber;
        _Name = Name;
        _Period = Period;
        _iPeriod = iPeriod;
        _Major = Major;
        _sDegree = sDegree;
        _sMajor = sMajor;
        _CGPA = CGPA;
        _sSection=SSection;
        _SGPA = SGPA;
        _ENG = ENG;
        _Score = Score;
        _LTR = LTR;
        _Phone1 = Phone1;
        _Phone2 = Phone2;
        _Status = Status;
        _Hours = Hours;
        _Passed = Passed;
        _RegTerm = iRegTerm;
        _MaxESL = MaxESL;
        _Advisor = Advisor;
        _isENGRequired = isENGRequired;
        _Mirror = Mirror;
        _Recommended = Recommended;
        _Remind = Remind;
        _Note = Note;
	}



    public int Serial
    {
        get { return _Serial; }
        set { _Serial = value; }
    }

    public string StudentNumber
    {
        get { return _StudentNumber; }
        set { _StudentNumber = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public int IPeriod
    {
        get { return _iPeriod; }
        set { _iPeriod = value; }
    }

    public string Period
    {
        get { return _Period; }
        set { _Period = value; }
    }

    public string Major
    {
        get { return _Major; }
        set { _Major = value; }
    }

    public string SDegree
    {
        get { return _sDegree; }
        set { _sDegree = value; }
    }

    public string SMajor
    {
        get { return _sMajor; }
        set { _sMajor = value; }
    }

    public decimal CGPA
    {
        get { return _CGPA; }
        set { _CGPA = value; }
    }

    public string SSection
    {
        get { return _sSection; }
        set { _sSection = value; }
    }

    public decimal SGPA
    {
        get { return _SGPA; }
        set { _SGPA = value; }
    }

    public string ENG
    {
        get { return _ENG; }
        set { _ENG = value; }
    }

    public decimal Score
    {
        get { return _Score; }
        set { _Score = value; }
    }

    public int LTR
    {
        get { return _LTR; }
        set { _LTR = value; }
    }

    public int Remind
    {
        get { return _Remind; }
        set { _Remind = value; }
    }

    public string Phone1
    {
        get { return _Phone1; }
        set { _Phone1 = value; }
    }

    public string Phone2
    {
        get { return _Phone2; }
        set { _Phone2 = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }


    public int Hours
    {
        get { return _Hours; }
        set { _Hours = value; }
    }

    public int Passed
    {
        get { return _Passed; }
        set { _Passed = value; }
    }
    public int RegTerm
    {
        get { return _RegTerm; }
        set { _RegTerm = value; }
    }
    
    public int MaxESL
    {
        get { return _MaxESL; }
        set { _MaxESL = value; }
    }

    public string Advisor
    {
        get { return _Advisor; }
        set { _Advisor = value; }
    }

    public bool IsENGRequired
    {
        get { return _isENGRequired; }
        set { _isENGRequired = value; }
    }

    public bool IsAccWanted
    {
        get { return _isAccWanted; }
        set { _isAccWanted = value; }
    }

    public string Note
    {
        get { return _Note; }
        set { _Note = value; }
    }

    public StudentCourses.StudentMirror[] Mirror
    {
        get { return _Mirror; }
        set { _Mirror = value; }
    }

    public List<Advised.Courses> Recommended
    {
        get { return _Recommended; }
        set { _Recommended = value; }
    }

}
public class MirrorDAL
{
    public enum MirrorsType : int
    {
        ProgramMirror = 1,
        ExpectedMirror = 2
    }

    public List<MirrorCLS> GetGeneralMirror(string sCollege, string sDegree, string sMajor,int Reason,int Period,string sNo, InitializeModule.EnumCampus Campus)
    {
        List<MirrorCLS> Result = new List<MirrorCLS>();
        List<Plans> Plan = new List<Plans>();
        PlansDAL myPlansDAL = new PlansDAL();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "select * from GetGrades('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
            sSQL+=" union all";
            sSQL += " select * from GetRegistered('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
            sSQL+=" union all";
            sSQL += " select * from GetEllective('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
            sSQL += " order by lngSerial,byteOrder";
            
            Plan = myPlansDAL.GetPlans(sCollege, sDegree, sMajor, false, Campus);
            int iPlan = Plan[0].Courses.Count;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            string sSno = "";
            MirrorCLS myMirror = new MirrorCLS(); ;
            myMirror.StudentNumber = "Begin";
            myMirror.Serial = 0;
            int iSerial = 0;
            int iIndex = 0;

            while (Rd.Read())
            {
                if (sSno != Rd["sStudentNumber"].ToString())
                {
                    Result.Add(myMirror);
                    iSerial += 1;
                    myMirror = new MirrorCLS();
                    myMirror.StudentNumber = Rd["sStudentNumber"].ToString();
                    sSno = myMirror.StudentNumber;
                    myMirror.Serial = iSerial;
                    myMirror.Mirror = new StudentCourses.StudentMirror[iPlan];
                    myMirror.Hours = Plan[0].StudyHours ;
                    myMirror.Passed = 0;
                    for (int i = 0; i < iPlan; i++)
                    {
                        myMirror.Mirror[i].sCourse = Plan[0].Courses[i].sCourse;
                        myMirror.Mirror[i].iCredit = Plan[0].Courses[i].iCredit;
                        myMirror.Mirror[i].iOrder= Plan[0].Courses[i].iOrder;
                        myMirror.Mirror[i].iClass = Plan[0].Courses[i].iClass;
                    }
                }
                iIndex = int.Parse(Rd["byteOrder"].ToString()) - 1;
                //myMirror.Mirror[iIndex].sCourse = Rd["sCourse"].ToString();

               
                myMirror.Mirror[iIndex].sGrade = Rd["sGrade"].ToString();
                

                if (Rd["bPassIt"].Equals(DBNull.Value))
                {
                    myMirror.Mirror[iIndex].isPassed = false;
                }
                else
                {
                    myMirror.Mirror[iIndex].isPassed = bool.Parse(Rd["bPassIt"].ToString());
                }

                //if (myMirror.IsAccWanted && myMirror.Mirror[iIndex].isPassed)
                //{
                //    myMirror.Mirror[iIndex].sGrade = "*";
                //}
            }
            //Add the last
            Result.Add(myMirror);
            Rd.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            Plan.Clear();
            Conn.Close();
            Conn.Dispose();
        }
        return Result;
    }

    private List<MirrorCLS> GetStudentData(string sCollege, string sDegree, string sMajor, int Reason, int Period, string sNo, int iAdvisor, int CancelTerm, Plans Plan, InitializeModule.EnumOptions iOption, SqlConnection Conn, InitializeModule.EnumCampus Campus)
    {
        List<MirrorCLS> Result = new List<MirrorCLS>();
        try
        {
            string sSQL = GetSDSQL(sCollege, sDegree, sMajor, Reason, Period, sNo, iAdvisor, CancelTerm, iOption);

            //List<Plans> Plan = new List<Plans>();
            //PlansDAL myPlansDAL = new PlansDAL();
            //Plan = myPlansDAL.GetPlans(sCollege, sDegree, sMajor, false, Campus);
            //int iPlan = Plan[0].Courses.Count;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            MirrorCLS myMirror;
            int iSerial = 0;
            while (Rd.Read())
            {
                iSerial += 1;
                myMirror = new MirrorCLS();
                 
                myMirror.Serial = iSerial;
                myMirror.StudentNumber = Rd["No"].ToString();
                myMirror.Name = Rd["Name"].ToString();
                myMirror.IPeriod=int.Parse (Rd["iPeriod"].ToString());
                myMirror.Period = Rd["Period"].ToString();
                myMirror.ENG = Rd["ENG"].ToString();
                myMirror.Advisor = Rd["Advisor"].ToString();
                myMirror.SSection=Rd["Section"].ToString();
                if (!Rd["sngGrade"].Equals(DBNull.Value))
                {
                    myMirror.SGPA = decimal.Parse(Rd["sngGrade"].ToString());
                }

                if (!Rd["Score"].Equals(DBNull.Value))
                {
                    myMirror.Score = decimal.Parse(Rd["Score"].ToString());
                }
                if (!Rd["CGPA"].Equals(DBNull.Value))
                {
                    myMirror.CGPA = decimal.Parse(Rd["CGPA"].ToString());
                }
                else
                {
                    myMirror.CGPA = 101;
                }
                if (!Rd["LTR"].Equals(DBNull.Value))
                {
                    myMirror.LTR = int.Parse(Rd["LTR"].ToString());
                }
                else
                {
                    myMirror.LTR = 0;
                }
                myMirror.Phone1 = Rd["Phone1"].ToString();
                myMirror.Phone2 = Rd["Phone2"].ToString();
                myMirror.Status = Rd["Status"].ToString();
               
                myMirror.IsENGRequired =( int.Parse(Rd["AcceptedTerm"].ToString())>=20062);
                myMirror.IsAccWanted = bool.Parse(Rd["isAccWanted"].ToString());

                if (!Rd["MESL"].Equals(DBNull.Value))
                {
                    myMirror.MaxESL = int.Parse(Rd["MESL"].ToString());
                }
                else
                {
                    myMirror.MaxESL = 0;
                }

                if (!Rd["RMD"].Equals(DBNull.Value))
                {
                    myMirror.Remind = int.Parse(Rd["RMD"].ToString());
                }
                

                myMirror.Mirror = new StudentCourses.StudentMirror[Plan.Courses.Count];
                for (int i = 0; i < Plan.Courses.Count; i++)
                {
                    myMirror.Mirror[i].sCourse = Plan.Courses[i].sCourse;
                    myMirror.Mirror[i].iCredit = Plan.Courses[i].iCredit;
                    myMirror.Mirror[i].sGrade = ".";
                    myMirror.Mirror[i].isPassed = false;
                    myMirror.Mirror[i].RegTerm = 0;
                }
                Result.Add(myMirror);
            }
            //Add the last

            Rd.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return Result;
    }

    public List<MirrorCLS> GetMirrorWithSD(string sCollege, string sDegree, string sMajor, int Reason, int Period, string sNo, int iAdvisor, int CancelTerm, InitializeModule.EnumOptions iOption, MirrorsType iType, InitializeModule.EnumCampus Campus, out int iHours, bool iRegisteredPassed)
    {
        List<MirrorCLS> Result = new List<MirrorCLS>();
        List<Plans> MyPlans = new List<Plans>();
        Plans myPlan = new Plans(); 
        PlansDAL myPlansDAL = new PlansDAL();

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        iHours = 0;
        try
        {
            
            MyPlans = myPlansDAL.GetPlans(sCollege, sDegree, sMajor, false, Campus);
            myPlan = MyPlans[0];
            int iPlan = myPlan.Courses.Count;

            Result = GetStudentData(sCollege, sDegree, sMajor, Reason, Period, sNo,iAdvisor, CancelTerm, myPlan, iOption, Conn, Campus);
            iHours = myPlan.StudyHours;
            if (Result.Count > 0)
            {
                //string sSQL = "select * from GetGrades('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
                //sSQL += " union all";
                //sSQL += " select * from GetRegistered('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
                //sSQL += " union all";
                //sSQL += " select * from GetEllective('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
                //sSQL += " order by lngSerial,byteOrder";

                string sSQL = GetMirrorSQL( iType, sCollege, sDegree, sMajor, Reason, Period, sNo,iAdvisor, CancelTerm, iOption,iRegisteredPassed );

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                int iIndex = 0;
                int iCrsIndex = 0;
                string sSno = "";
                int iCourseregTerm = 0;
                int iRegTerm = LibraryMOD.GetRegTerm();
 
                while (Rd.Read())
                {
                    if (sSno != Rd["sStudentNumber"].ToString())
                    {
                        sSno = Rd["sStudentNumber"].ToString();
                        iIndex = Result.FindIndex(delegate(MirrorCLS M) { return M.StudentNumber == sSno; });
                        if (iIndex >= 0)
                        {
                            //Result[iIndex].Mirror = new StudentCourses.StudentMirror[iPlan];
                            Result[iIndex].Passed = 0;
                            Result[iIndex].Hours = iHours;
                            for (int i = 0; i < iPlan; i++)
                            {
                                Result[iIndex].Mirror[i].iClass = myPlan.Courses[i].iClass;
                            }
                        }
                    }
                    if (iIndex >= 0)
                    {
                        iCrsIndex = int.Parse(Rd["byteOrder"].ToString()) - 1;
                       
                        //Result[iIndex].Mirror[iCrsIndex].sCourse = Rd["sCourse"].ToString
                        //Student has Fainance Problem
                        
                        Result[iIndex].Mirror[iCrsIndex].sGrade = Rd["sGrade"].ToString();
                        iCourseregTerm = int.Parse(Rd["RegTerm"].ToString());
                        
                        if (Rd["bPassIt"].Equals(DBNull.Value))
                        {
                            Result[iIndex].Mirror[iCrsIndex].isPassed = false;
                        }
                        else
                        {
                            if (iCourseregTerm >= iRegTerm)
                            {
                                Result[iIndex].Mirror[iCrsIndex].isPassed = false;
                            }
                            else
                            {
                                Result[iIndex].Mirror[iCrsIndex].isPassed = bool.Parse(Rd["bPassIt"].ToString());
                            }
                        }

                        //if (Result[iIndex].IsAccWanted && Result[iIndex].Mirror[iCrsIndex].isPassed)
                        //{
                        //    Result[iIndex].Mirror[iCrsIndex].sGrade = "*";
                        //}

                    }
                } Rd.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
            
        }
        finally
        {
            MyPlans.Clear();
            Conn.Close();
            Conn.Dispose();
        }
        return Result;
    }

    private string GetMirrorSQL(MirrorsType itype, string sCollege, string sDegree, string sMajor, int Reason, int Period, string sNo, int iAdvisor, int CancelTerm, InitializeModule.EnumOptions iOption,bool isRegisteredPassed)
    {
        string sSQL = "";
        try
        {
            switch (itype)
            {
                case MirrorsType.ProgramMirror:
                    sSQL = GetProgramMirrorSQL(sCollege, sDegree, sMajor, Reason, Period, sNo, iAdvisor, CancelTerm, iOption,isRegisteredPassed);
                    break;
                case MirrorsType.ExpectedMirror:
                    sSQL = GetExpectedMirrorSQL(sCollege, sDegree, sMajor, Reason, Period, sNo, CancelTerm, iOption);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
        
        }
        return sSQL;
    }

    private string GetProgramMirrorSQL(string sCollege, string sDegree, string sMajor, int Reason, int Period, string sNo, int iAdvisor, int CancelTerm, InitializeModule.EnumOptions iOption, bool isRegisteredPassed)
    {
        string sSQL = "";
        try
        {
           
            string sCondition = GetCondition(sCollege, sDegree, sMajor, Reason, Period, sNo, iAdvisor, CancelTerm, iOption);
           
            sSQL += "SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,0 AS Regterm,byteOrder,CONVERT (int, 1, 102) as Priority";
            sSQL += " FROM Web_Max_Grades";
            sSQL += sCondition;
         
            //sSQL += " AND     (sStudentNumber = 'AM08090101')";
            //sSQL += " union all";

            //sSQL += " SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder,CONVERT (int, 2, 102) as Priority";
            //sSQL += " FROM Web_Max_Ellective";
            //sSQL += sCondition;
            //sSQL += " AND     (sStudentNumber = 'AM08090101')";
            sSQL += " union all";

            sSQL += " SELECT lngSerial,sStudentNumber,sCourse,sGrade";
            if (isRegisteredPassed )
            {
                sSQL += " ,CONVERT (bit, 1, 102)";
            }
            else
            {
                sSQL += " ,CONVERT (bit, 0, 102)";
            }

            sSQL += " ,Regterm,byteOrder,CONVERT (int, 3, 102) as Priority";
            sSQL += " FROM Web_Registered_No_Grades";
            sSQL += sCondition;
            //sSQL += " AND RegTerm < " + LibraryMOD.GetRegTerm(); 

            //sSQL += " AND     (sStudentNumber = 'AM08090101')";
            sSQL += " ORDER BY lngSerial,byteOrder,Priority";
            							


        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sSQL;
    }

    private string GetMajorElectiveSQL(  string sNo)
    {
        string sSQL = "";
        try
        {
           
           

            sSQL += " SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder,CONVERT (int, 2, 102) as Priority";
            sSQL += " FROM Web_Max_Ellective";

            sSQL += " WHERE sStudentNumber ='" + sNo + "'";
         
            sSQL += " ORDER BY lngSerial,byteOrder,Priority";



        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sSQL;
    }
    public string GetMajorElectiveCourses(string sNo, InitializeModule.EnumCampus Campus)
    {
         string sSQL = "";
         string sResult = "";
        try
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            sSQL = GetMajorElectiveSQL(sNo);

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            
         
            while (Rd.Read())
                {
                    sResult += Rd["sCourse"].ToString() + " , ";
                }
            sResult = sResult.Substring(0, sResult.Length - 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sResult ;
    }
    public int GetMajorElectiveCoursesCount(string sNo, InitializeModule.EnumCampus Campus)
    {
        string sSQL = "";
        int iResult = 0;
        try
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            sSQL = GetMajorElectiveSQL(sNo);

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                iResult += 1;
            }
           
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return iResult;
    }

    private string GetFreeElectiveSQL(string sNo)
    {
        string sSQL = "";
        try
        {


           
            sSQL += " SELECT strCourse,strGrade,sAlt";
            sSQL += " FROM Free_ElectiveCourses";

            sSQL += " WHERE lngStudentNumber ='" + sNo + "'";


        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sSQL;
    }
    public string GetFreeElectiveCourses(string sNo, InitializeModule.EnumCampus Campus)
    {
        string sSQL = "";
        string sResult = "";
        try
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            sSQL = GetFreeElectiveSQL(sNo);

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();


            while (Rd.Read())
            {
                sResult += Rd["strCourse"].ToString() + " , " ;
            }
            sResult = sResult.Substring(0, sResult.Length - 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sResult;
    }
    public int GetFreeElectiveCoursesCount(string sNo, InitializeModule.EnumCampus Campus)
    {
        string sSQL = "";
        int iResult = 0;
        try
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            sSQL = GetFreeElectiveSQL(sNo);

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                iResult += 1;
            }
          
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return iResult;
    }
    private string GetExpectedMirrorSQL(string sCollege, string sDegree, string sMajor, int Reason, int Period, string sNo, int CancelTerm, InitializeModule.EnumOptions iOption )
    {
        string sSQL = "";
        try
        {
            string sCondition = GetCondition(sCollege, sDegree, sMajor, Reason, Period, sNo,0, CancelTerm, iOption);

            sSQL += "SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,0 AS Regterm,byteOrder,CONVERT (int, 1, 102) as Priority";
            sSQL += " FROM Web_Max_Grades";
            sSQL += sCondition;
            // sSQL += " AND     (sStudentNumber = 'AF07090070')";

            //sSQL += " union all";
            //sSQL += " SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder,CONVERT (int, 2, 102) as Priority";
            //sSQL += " FROM Web_Max_Ellective";
            //sSQL += sCondition;
            //sSQL += " AND     (sStudentNumber = 'AF07090070')";


            sSQL += " union all";
            sSQL += " SELECT lngSerial,sStudentNumber,sCourse,sGrade";
           
            sSQL += " ,CONVERT (bit, 1, 102)";

            sSQL += " ,Regterm,byteOrder,CONVERT (int, 3, 102) as Priority";
            sSQL += " FROM Web_Registered_No_Grades";
            sSQL += sCondition;
            //sSQL += " AND     (sStudentNumber = 'AF07090070')";
            sSQL += " ORDER BY lngSerial,byteOrder,Priority";

            //sSQL += " SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder";
            //sSQL += " FROM Web_Mirror_Data_Min";
            //sSQL += sCondition;
            ////sSQL += " AND     (sStudentNumber = 'am08020034')";
            //sSQL += " ORDER BY lngSerial,byteOrder";
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sSQL;
    }

    private string GetSDSQL(string sCollege, string sDegree, string sMajor, int Reason, int Period, string sNo, int iAdvisor, int CancelTerm, InitializeModule.EnumOptions iOption)
    {
        string sSQL = "";
        try
        {
            string sCondition = GetCondition(sCollege, sDegree, sMajor, Reason, Period, sNo, iAdvisor, CancelTerm, iOption);


            sSQL += "SELECT lngSerial, Period, No, Name,Section,sngGrade, ENG, Score, Phone1, Phone2,Status, LTR, CGPA, byteShift AS iPeriod,Advisor,AcceptedTerm,isAccWanted,MESL,RMD";
            sSQL += " FROM Web_Student_Data";
            sSQL += sCondition;
            //sSQL += " AND No='AM08090170'";
            sSQL += " ORDER BY Name";


            ////Selected Creteria REF in Specific Major
            //sSQL += "SELECT WD.lngSerial, WD.Period, WD.No, WD.Name, WD.ENG, WD.Score, WD.Phone1, WD.Phone2, WD.Status, WD.LTR, WD.CGPA, WD.byteShift AS iPeriod, WD.Advisor, WD.AcceptedTerm, WD.isAccWanted, WD.MESL, WD.RMD";
            //sSQL += " FROM Reg_Applications AS A2 INNER JOIN Reg_Applications AS A1 ON A2.lngStudentNumber = A1.sReference INNER JOIN Web_Student_Data AS WD ON A1.lngStudentNumber = WD.No";
            //sSQL += " WHERE (A2.strCollege = N'1') AND (A2.strDegree = N'1') AND (A2.strSpecialization = N'18') AND (A1.strCollege = N'1') AND (A1.strDegree = N'3') AND ";
            //sSQL += " (A1.strSpecialization = N'6') AND (A1.byteCancelReason IS NULL)";
            //sSQL += " ORDER BY Name";

            ////Selected Creteria No REF
            //sSQL += "SELECT WD.lngSerial, WD.Period, WD.No, WD.Name, WD.ENG, WD.Score, WD.Phone1, WD.Phone2, WD.Status, WD.LTR, WD.CGPA, WD.byteShift AS iPeriod, WD.Advisor,WD.AcceptedTerm, WD.isAccWanted, WD.MESL, WD.RMD";
            //sSQL += " FROM Reg_Applications AS A1 INNER JOIN Web_Student_Data AS WD ON A1.lngStudentNumber = WD.No";
            //sSQL += " WHERE   (A1.strCollege = N'1') AND (A1.strDegree = N'3') AND (A1.strSpecialization = N'5') AND (A1.byteCancelReason IS NULL) AND (A1.sReference IS NULL)";
            //sSQL += " ORDER BY Name";
            

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sSQL;
    }

    public string GetCondition(string sCollege, string sDegree, string sMajor, int Reason, int Period, string sNo, int iAdvisor, int CancelTerm, InitializeModule.EnumOptions iOption)
    {
        string sCondition = "";
        
        try
        {
            sCondition = " WHERE strCollege='"+ sCollege +"'";
            sCondition += " AND strDegree='"+ sDegree+"'";
            sCondition += " AND strSpecialization='" + sMajor + "'";
            if (iAdvisor > 0)
            {
                sCondition += " AND intAdvisor=" + iAdvisor;
            }
            if (sNo != "0")
            {

                sCondition += " AND sStudentNumber='" + sNo + "'";
            }
            else
            {
                if (Reason > 0)
                {
                    // (byteCancelReason is null OR
                    sCondition += " AND byteCancelReason=" + Reason;// + "";
                    if (CancelTerm > 0)
                    {
                        sCondition += " AND CancelTerm ";
                        string sOption = LibraryMOD.GetOption(iOption);
                        sCondition += sOption + CancelTerm;
                    }
                }
                else
                {
                    switch (Reason)
                    {
                        case 0://No Reason
                            sCondition += " AND byteCancelReason is null";
                            break;
                        case -1://Not Graduated
                            sCondition += " AND (byteCancelReason <>3 or byteCancelReason is null)";
                            break;
                    }
                    
                }

                if (Period > 0)
                {
                    sCondition += " AND byteShift=" + Period;
                }

            }
            
            //if (CGPA > 0)
            //{
            //    sCondition += " AND CGPA ";
            //    string sOperator = LibraryMOD.GetOperator(iOperator);
            //}

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sCondition;
    }

    public List<MirrorCLS> GetMirrorForAdvising(string sCollege, string sDegree, string sMajor, int Period, string sNo,int iAdvisor,out Plans Plan, InitializeModule.EnumCampus Campus, bool isRegisteredPassed)
    {
        List<MirrorCLS> Result = new List<MirrorCLS>();
        Plan = new Plans();
        List<Plans> myPlans = new List<Plans>();
        PlansDAL myPlansDAL = new PlansDAL();

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            myPlans = myPlansDAL.GetPlans(sCollege, sDegree, sMajor,true, Campus);
            int iPlan = myPlans[0].Courses.Count;
            Plan = myPlans[0];

            Result = GetStudentData(sCollege, sDegree, sMajor, 0, Period, sNo,0, 0,Plan, 0, Conn, Campus);
            if (Result.Count > 0)
            {
                //string sSQL = "select * from GetGrades('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
                //sSQL += " union all";
                //sSQL += " select * from GetRegistered('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
                //sSQL += " union all";
                //sSQL += " select * from GetEllective('" + sCollege + "','" + sDegree + "','" + sMajor + "'," + Reason + "," + Period + ",'" + sNo + "')";
                //sSQL += " order by lngSerial,byteOrder";

                string sSQL = GetMirrorSQL(MirrorsType.ProgramMirror, sCollege, sDegree, sMajor, 0, Period, sNo, iAdvisor, 0, 0, isRegisteredPassed);

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                int iIndex = 0;
                int iCrsIndex = 0;
                string sSno = "";
                int iCourseregTerm = 0;
                int iRegTerm = LibraryMOD.GetRegTerm();
 
                while (Rd.Read())
                {
                    if (sSno != Rd["sStudentNumber"].ToString())
                    {
                        sSno = Rd["sStudentNumber"].ToString();
                        iIndex = Result.FindIndex(delegate(MirrorCLS M) { return M.StudentNumber == sSno; });
                        if (iIndex >= 0)
                        {
                            //Result[iIndex].Mirror = new StudentCourses.StudentMirror[iPlan];
                            Result[iIndex].Passed = 0;
                            Result[iIndex].Hours = Plan.StudyHours;
                            for (int i = 0; i < iPlan; i++)
                            {
                                Result[iIndex].Mirror[i].iClass = Plan.Courses[i].iClass;
                                //Result[iIndex].Mirror[i].iCredit = Plan.Courses[i].iCredit;
                                //Result[iIndex].Mirror[i].sGrade = ".";
                                //Result[iIndex].Mirror[i].isPassed = false;
                            }
                        }
                    }
                    if (iIndex >= 0)
                    {
                        iCrsIndex = int.Parse(Rd["byteOrder"].ToString()) - 1;
                        //Result[iIndex].Mirror[iCrsIndex].sCourse = Rd["sCourse"].ToString
                       
                        Result[iIndex].Mirror[iCrsIndex].sGrade = Rd["sGrade"].ToString();
                        Result[iIndex].Mirror[iCrsIndex].iOrder = Convert.ToInt32 (  Rd["byteOrder"].ToString());
                        
                        iCourseregTerm = int.Parse(Rd["RegTerm"].ToString());

                        if (Rd["bPassIt"].Equals(DBNull.Value))
                        {
                            Result[iIndex].Mirror[iCrsIndex].isPassed = false;
                        }
                        else
                        {
                            if (iCourseregTerm > 0)
                            {
                                if (iCourseregTerm < iRegTerm && isRegisteredPassed == true)
                                {
                                    Result[iIndex].Mirror[iCrsIndex].isPassed = true;
                                }
                                else
                                {
                                    Result[iIndex].Mirror[iCrsIndex].isPassed = false;
                                }
                            }
                            else
                            {
                                Result[iIndex].Mirror[iCrsIndex].isPassed = bool.Parse(Rd["bPassIt"].ToString());
                            }
                        }

                        //if (Result[iIndex].IsAccWanted && Result[iIndex].Mirror[iCrsIndex].isPassed)
                        //{
                        //    Result[iIndex].Mirror[iCrsIndex].sGrade = "*";
                        //}

                    }
                }
                Rd.Close();
            }

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
