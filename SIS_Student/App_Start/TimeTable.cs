using System;
using System.Data;
using System.Configuration;
////using System.Linq;
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
/// Summary description for TimeTable
/// </summary>
/// 
public class Classes
{
    public enum Days
    {
        dSat = 1,
        dSun = 2,
        dMon = 4,
        dTus = 8,
        dWed = 16,
        dThu = 32,
        dFri = 64
    } 

    public struct Students
    {
        public int _Serial;
        public string _StudentNumber;
        public string _Name;
        public string _Period;
        public string _Major;
        public decimal _CGPA;
        public string _ENG;
        public decimal _Score;
        public string _Phone1;
        public string _Phone2;
        public string _sECTemail;
        public string _Grade;
        public string _RegDate;

    }
    public struct Times
    {
        public  int _iLecturer;
        public  string _sLecturer;
        public  DateTime _dFrom;
        public DateTime _dTo;
        public int _iDays;
        public string _sDays;
        public string _sNotes;
        public string _sHall;
        public string _seBookCode;

        public string _sCampus;
        public decimal _dTeachingHours;
    }
    

}
public class TimeTable
{
    //SELECT AV.byteShift, P.strShortcut AS sPeriod, AV.strCourse AS sCourse, dbo.Reg_Courses.strCourseDescEn AS sDesc, AV.byteClass AS iClass, 
    //L.strLecturerDescEn AS sLecturer, CT.intLecturer,CT.dateTimeFrom, CT.dateTimeTo, CT.byteDay, CT.strHall, H.intMaxSeats AS Max
    //FROM dbo.Reg_Available_Courses AS AV INNER JOIN dbo.Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND 
    //AV.strCourse = CT.strCourse AND AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN
    //dbo.Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN dbo.Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN
    //dbo.Reg_Courses ON AV.strCourse = dbo.Reg_Courses.strCourse INNER JOIN dbo.Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer
    //WHERE (AV.intStudyYear = 2009) AND (AV.byteSemester = 2)

#region "Decleration"

    private int _iPeriod;
    private string _sPeriod;
    private string _sCourse;
    private string _sUnified;
    private string _sDispalyUnified;
    private string _sCollege;
    private int _CommitteeID;
    private string _sDesc;
    private string _seBookCode;
    private int _iClass;
    private int _iMax;
    private int _iCapacity;
    private decimal _dCreditHours;
    private List<Classes.Times> _ClassTimes;
    private List<Classes.Students> _ClassStudents;
    
#endregion
#region "Puplic Properties"

    public int IPeriod
    {
        get { return _iPeriod; }
        set { _iPeriod = value; }
    }

    public string SPeriod
    {
        get { return _sPeriod; }
        set { _sPeriod = value; }
    }

    public string SCourse
    {
        get { return _sCourse; }
        set { _sCourse = value; }
    }
    public string sUnified
    {
        get { return _sUnified; }
        set { _sUnified = value; }
    }
    public string sDispalyUnified
    {
        get { return _sDispalyUnified; }
        set { _sDispalyUnified = value; }
    }
    public string sCollege
    {
        get { return _sCollege; }
        set { _sCollege = value; }
    }

    public int iCommitteeID
    {
        get { return _CommitteeID; }
        set { _CommitteeID = value; }
    }
    public string SDesc
    {
        get { return _sDesc; }
        set { _sDesc = value; }
    }
    public string seBookCode
    {
        get { return _seBookCode; }
        set { _seBookCode = value; }
    }

    public int IClass
    {
        get { return _iClass; }
        set { _iClass = value; }
    }
    
    public int IMax
    {
        get { return _iMax; }
        set { _iMax = value; }
    }

    public int ICapacity
    {
        get { return _iCapacity; }
        set { _iCapacity = value; }
    }

    public decimal DCreditHours
    {
        get { return _dCreditHours; }
        set { _dCreditHours = value; }
    }

    public List<Classes.Times> ClassTimes
    {
        get { return _ClassTimes; }
        set { _ClassTimes = value; }
    } 

    public List<Classes.Students> ClassStudents
    {
        get { return _ClassStudents; }
        set { _ClassStudents = value; }
    }

#endregion

	public TimeTable()
	{
		
	}
    public TimeTable(int iPeriod, string sPeriod, string sCourse, string sUnified, string sDispalyUnified, string sCollege, int iCommitteeID, string sDesc, string seBookCode, int iClass,
    int iMax, int iCapacity, decimal dCreditHours, List<Classes.Times> ClassTimes, List<Classes.Students> ClassStudents)
    {
        _iPeriod = iPeriod;
        _sPeriod = sPeriod;
        _sCourse = sCourse;
        _sUnified = sUnified;
        _sDispalyUnified = sDispalyUnified;
        _sCollege = sCollege;
        _CommitteeID = iCommitteeID; 
        _sDesc = sDesc;
        _seBookCode = seBookCode;
        _iClass = iClass;
        _iMax = iMax;
        _iCapacity = iCapacity;
        _ClassTimes = ClassTimes;
        _ClassStudents = ClassStudents;
        _dCreditHours = dCreditHours;

    }
}

public class TimeTableDAL
{
    public string GetDays(int iDays)
    {

        string sDays = "";

        try
        {
            //var x = 0;
            //x = (10 & 1);
            //x = (10 & 2);

            if ((iDays & (int)Classes.Days.dSat) != 0)
            {
                sDays += "Sat.";
            }

            if ((iDays & (int)Classes.Days.dSun) != 0)
            {
                sDays += "Sun.";
            }

            if ((iDays & (int)Classes.Days.dMon) != 0)
            {
                sDays += "Mon.";
            }

            if ((iDays & (int)Classes.Days.dTus) != 0)
            {
                sDays += "Tus.";
            }

            if ((iDays & (int)Classes.Days.dWed) != 0)
            {
                sDays += "Wed.";
            }

            if ((iDays & (int)Classes.Days.dThu) != 0)
            {
                sDays += "Thu.";
            }

            if ((iDays & (int)Classes.Days.dFri) != 0)
            {
                sDays += "Fri.";
            }




        }
        catch (Exception ex)
        {
            //Interaction.MsgBox(ex.Message);
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sDays;
    }

    public string GetDays(int iDays, out int iCount)
    {

        string sDays = "";
        iCount = 0;
        try
        {
            //var x = 0;
            //x = (10 & 1);
            //x = (10 & 2);

            if ((iDays & (int)Classes.Days.dSat) != 0)
            {
                sDays += "Sat.";
                iCount++;
            }

            if ((iDays & (int)Classes.Days.dSun) != 0)
            {
                sDays += "Sun.";
                iCount++;
            }

            if ((iDays & (int)Classes.Days.dMon) != 0)
            {
                sDays += "Mon.";
                iCount++;
            }

            if ((iDays & (int)Classes.Days.dTus) != 0)
            {
                sDays += "Tus.";
                iCount++;
            }

            if ((iDays & (int)Classes.Days.dWed) != 0)
            {
                sDays += "Wed.";
                iCount++;
            }

            if ((iDays & (int)Classes.Days.dThu) != 0)
            {
                sDays += "Thu.";
                iCount++;
            }

            if ((iDays & (int)Classes.Days.dFri) != 0)
            {
                sDays += "Fri.";
                iCount++;
            }
       }
        catch (Exception ex)
        {
            //Interaction.MsgBox(ex.Message);
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {

        }
        return sDays;
    }

    public List<TimeTable> GetTimeTable(int iYear, int iSemester, int iPeriod, string sCourse, int iClass, int iLecturer, string sHall, string sUnit, bool isStudentsIncluded, bool isHiddenShown, InitializeModule.EnumCampus Campus, bool IsShowEngPassedOnly)
    {
        List<TimeTable> Result = new List<TimeTable>();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT AV.byteShift AS iPeriod, P.strShortcut AS sPeriod ";
            sSQL += " ,AV.strCourse AS sCourse, C.strCourseDescEn AS sDesc";
            sSQL += " , AV.byteClass AS iClass,L.strLecturerDescEn AS sLecturer";
            sSQL += " , CT.intLecturer AS iLecturer, CT.dateTimeFrom AS dFrom";
            sSQL += " , CT.dateTimeTo AS dTo, CT.byteDay AS iDays, CT.Notes";
            sSQL += " , CT.strHall AS sHall,strBuilding as sCampus, (CASE WHEN H.intMaxSeats < MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS iMax, ISNULL(CCU.RegCapacity, 0) AS sCount";
            sSQL += " , CT.bLab,AV.strUnified AS sUnified,C.strCollege AS sCollege,C.CommitteeID,C.sDispalyUnified ";

            sSQL += " FROM  Reg_Available_Courses AS AV INNER JOIN";
            sSQL += " Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND ";
            sSQL += " AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN";
            sSQL += " Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN";
            sSQL += " Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN";
            if (IsShowEngPassedOnly == true)
            {
                sSQL += " ClassCapacity_Unified_Eng_Fail AS CCU ";
            }
            else
            {
                sSQL += " ClassCapacity_Unified AS CCU ";
            }

            sSQL += " ON AV.intStudyYear = CCU.iYear AND AV.byteSemester = CCU.Sem AND AV.strUnified = CCU.strUnified AND ";
            sSQL += " AV.byteClass = CCU.Class AND AV.byteShift = CCU.Shift";

            sSQL += " WHERE 1=1";
            if (iYear > 0)
            {
                sSQL += " AND AV.intStudyYear=" + iYear;
            }
            if (iSemester > 0)
            {
                sSQL += " AND AV.byteSemester=" + iSemester;
            }
            if (!isHiddenShown)
            {
                sSQL += " AND AV.byteClass<100";
            }

            //sSQL += " AND H.iCampus=3";
            if (iPeriod != 0)
            {
                if (iPeriod < 0)
                {
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            sSQL += " AND (AV.byteShift=1 or AV.byteShift=2 or AV.byteShift=9)";
                            break;

                        case InitializeModule.EnumCampus.Males:
                            sSQL += " AND (AV.byteShift=3 or AV.byteShift=4 or AV.byteShift=8)";
                            break;
                    }
                }
                else
                {
                    sSQL += " AND AV.byteShift=" + iPeriod;
                }
            }
            if (!string.IsNullOrEmpty(sCourse))
            {
                //get Unified course code
                CoursesDAL my_Courses = new CoursesDAL();

                string sDisplayUnified = my_Courses.GetDisplayUnified(Campus, sCourse);

                sSQL += " AND C.sDispalyUnified ='" + sDisplayUnified + "'";
                //sSQL += " AND AV.strCourse='" + sCourse + "'";
            }

            if (iClass > 0)
            {
                sSQL += " AND AV.byteClass=" + iClass;

            }
            if (iLecturer > 0)
            {
                sSQL += " AND CT.intLecturer=" + iLecturer;
            }
            if (!string.IsNullOrEmpty(sHall))
            {
                sSQL += " AND CT.strHall='" + sHall + "'";
            }
            if (!string.IsNullOrEmpty(sUnit))
            {
                //sSQL += " AND L.strCollege='" + sUnit + "'";
                sSQL += " AND C.strCollege='" + sUnit + "'";
            }

            sSQL += " AND AV.byteShift<>11";//Private

            //sSQL += " Order By AV.byteShift,C.strCollege,C.CommitteeID,AV.strUnified,AV.byteClass,AV.strCourse,CT.byteDay,CT.dateTimeFrom";
            sSQL += " Order By C.strCollege,C.CommitteeID,AV.byteShift,C.sDispalyUnified,AV.strCourse,AV.byteClass,CT.byteDay,CT.dateTimeFrom";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            SqlDataReader Rd = Cmd.ExecuteReader();
            int _iPeriod = 0;
            string _sCourse = "";
            int _iClass = 0;

            int iRdPeriod = 0;
            string sRdCourse = "";
            string sRdUnified = "";
            string sRdDispalyUnified = "";
            string sRdCollege = "";
            int iRdCommitteeID = 0;
            int iRdClass = 0;

            TimeTable myTimeTable = new TimeTable();

            Available_CoursesDAL myAvailable_Courses = new Available_CoursesDAL();
            //Add Begin
            myTimeTable.IPeriod = 0;
            myTimeTable.SCourse = "Begin";
            Classes.Times myTimes;
            Classes.Students myStudents;
            bool isLab = false;
            while (Rd.Read())
            {
                iRdPeriod = int.Parse(Rd["iPeriod"].ToString());
                sRdCourse = Rd["sCourse"].ToString();
                sRdUnified = Rd["sUnified"].ToString();
                sRdDispalyUnified = Rd["sDispalyUnified"].ToString();
                sRdCollege = Rd["sCollege"].ToString();
                iRdCommitteeID = int.Parse(Rd["CommitteeID"].ToString());
                iRdClass = int.Parse(Rd["iClass"].ToString());

                int IsOffered = InitializeModule.FALSE_VALUE;
                IsOffered = myAvailable_Courses.IsCourseOffered(Campus, sRdDispalyUnified, iYear, iSemester, iRdClass, iRdPeriod);

                if ((_iPeriod != iRdPeriod) || (_sCourse != sRdCourse) || (_iClass != iRdClass))
                {
                    //Add Previous Record
                    Result.Add(myTimeTable);
                    //New Record
                    myTimeTable = new TimeTable();
                    _iPeriod = iRdPeriod;
                    _sCourse = sRdCourse;
                    _iClass = iRdClass;

                    myTimeTable.IPeriod = iRdPeriod;
                    myTimeTable.SCourse = sRdCourse;
                    myTimeTable.sUnified = sRdUnified;
                    myTimeTable.sDispalyUnified = sRdDispalyUnified;
                    myTimeTable.sCollege = sRdCollege;
                    myTimeTable.iCommitteeID = iRdCommitteeID;
                    myTimeTable.IClass = iRdClass;
                    myTimeTable.SPeriod = Rd["sPeriod"].ToString();
                    myTimeTable.SDesc = Rd["sDesc"].ToString();


                    //if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse  && IsOffered == InitializeModule.FALSE_VALUE))
                    //{
                    myTimeTable.IMax = int.Parse(Rd["iMax"].ToString());

                    if (!Rd["sCount"].Equals(DBNull.Value))
                    {
                        myTimeTable.ICapacity = int.Parse(Rd["sCount"].ToString());
                    }
                    else
                    {
                        myTimeTable.ICapacity = 0;
                    }
                    //}

                    //else
                    //{
                    //    myTimeTable.ICapacity = 0;
                    //}


                    myTimeTable.ClassTimes = new List<Classes.Times>();
                    if (isStudentsIncluded)
                    {
                        myTimeTable.ClassStudents = new List<Classes.Students>();
                        myTimeTable.ClassStudents = Get_Students(iYear, iSemester, iRdPeriod, sRdCourse, iRdClass, Campus);
                    }

                }
                //================== hide equivelant courses details (class,lecturer,time,days,max,capacity)

                myTimes = new Classes.Times();
                //-------------------------------------------
                myTimes._sHall = Rd["sHall"].ToString();
                myTimes._sCampus = Rd["sCampus"].ToString();
                myTimes._iDays = int.Parse(Rd["iDays"].ToString());
                if (!Rd["bLab"].Equals(DBNull.Value))
                {
                    isLab = bool.Parse(Rd["bLab"].ToString());
                }
                else
                {
                    isLab = false;
                }
                if (isLab)
                {
                    myTimes._sDays = GetDays(myTimes._iDays) + " (Lab)";
                }
                else
                {
                    myTimes._sDays = GetDays(myTimes._iDays);
                }
                myTimes._dFrom = DateTime.Parse(Rd["dFrom"].ToString());
                myTimes._dTo = DateTime.Parse(Rd["dTo"].ToString());
                //--------------------------------------------
                // if (sRdUnified == sRdCourse)
                if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse && IsOffered == InitializeModule.FALSE_VALUE))
                {
                    myTimes._iLecturer = int.Parse(Rd["iLecturer"].ToString());
                    myTimes._sLecturer = Rd["sLecturer"].ToString();
                }

                else
                {
                    myTimes._iLecturer = 0;
                    myTimes._sLecturer = "";
                    //myTimes._sHall = "";
                    //myTimes._iDays = 0;
                    //myTimes._sDays = "";
                    //myTimes._dFrom = DateTime.Parse("");
                    //myTimes._dTo = DateTime.Parse("");
                }

                myTimeTable.ClassTimes.Add(myTimes);
            }

            if (Rd.HasRows)
            {
                Result.Add(myTimeTable);
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

    public List<TimeTable> GetTimeTable(int iYear, int iSemester, int iPeriod, string sCourse, int iClass, int iLecturer, string sHall, string sUnit, bool isStudentsIncluded, bool isHiddenShown, InitializeModule.EnumCampus Campus)
    {
        List<TimeTable> Result = new List<TimeTable>();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT AV.byteShift AS iPeriod, P.strShortcut AS sPeriod ";
            sSQL += " ,AV.strCourse AS sCourse, C.strCourseDescEn AS sDesc";
            sSQL += " , AV.byteClass AS iClass,L.strLecturerDescEn AS sLecturer";
            sSQL += " , CT.intLecturer AS iLecturer, CT.dateTimeFrom AS dFrom";
            sSQL += " , CT.dateTimeTo AS dTo, CT.byteDay AS iDays, CT.Notes";
            sSQL += " , CT.strHall AS sHall,strBuilding as sCampus, (CASE WHEN H.intMaxSeats < MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS iMax, ISNULL(CCU.RegCapacity, 0) AS sCount";
            sSQL += " , CT.bLab,AV.strUnified AS sUnified,C.strCollege AS sCollege,C.CommitteeID,C.sDispalyUnified ";
           
            sSQL += " FROM  Reg_Available_Courses AS AV INNER JOIN"; 
            sSQL += " Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND ";
            sSQL += " AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN";
            sSQL += " Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN";
            sSQL += " Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN";
            sSQL += " ClassCapacity_Unified AS CCU ON AV.intStudyYear = CCU.iYear AND AV.byteSemester = CCU.Sem AND AV.strUnified = CCU.strUnified AND ";
            sSQL += " AV.byteClass = CCU.Class AND AV.byteShift = CCU.Shift";
                       
            //string sSQL = "SELECT AV.byteShift AS iPeriod, P.strShortcut AS sPeriod, AV.strCourse AS sCourse, C.strCourseDescEn AS sDesc, AV.byteClass AS iClass,";
            //sSQL += " L.strLecturerDescEn AS sLecturer, CT.intLecturer AS iLecturer,CT.dateTimeFrom AS dFrom, CT.dateTimeTo AS dTo, CT.byteDay AS iDays,CT.Notes, CT.strHall AS sHall, convert(int,H.intMaxSeats * C.CapFactor) AS iMax,Counts.sCount,CT.bLab";
            //sSQL += " FROM dbo.Reg_Available_Courses AS AV INNER JOIN dbo.Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND ";
            //sSQL += " AV.strCourse = CT.strCourse AND AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN dbo.Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN";
            //sSQL += " dbo.Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN dbo.Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN";
            //sSQL += " dbo.Reg_Shifts AS P ON AV.byteShift = P.byteShift LEFT OUTER JOIN dbo.Courses_Counts AS Counts ON AV.intStudyYear = Counts.iYear AND AV.byteSemester = Counts.Sem AND AV.strCourse = Counts.Course AND ";
            //sSQL += " AV.byteClass = Counts.Class AND AV.byteShift = Counts.Shift";
            sSQL += " WHERE AV.intStudyYear=" + iYear;
            sSQL += " AND AV.byteSemester=" + iSemester;

            if (!isHiddenShown)
            {
                sSQL += " AND AV.byteClass<100";
            }

            //sSQL += " AND H.iCampus=3";
            if (iPeriod != 0)
            {
                if (iPeriod < 0)
                {
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            sSQL += " AND (AV.byteShift=1 or AV.byteShift=2 or AV.byteShift=9)";
                            break;

                        case InitializeModule.EnumCampus.Males:
                            sSQL += " AND (AV.byteShift=3 or AV.byteShift=4 or AV.byteShift=8)";
                            break;
                    }
                }
                else
                {
                    sSQL += " AND AV.byteShift=" + iPeriod;
                }
            }
            if (!string.IsNullOrEmpty(sCourse))
            {
                //get Unified course code
                CoursesDAL my_Courses = new CoursesDAL();

                string sDisplayUnified = my_Courses.GetDisplayUnified (Campus, sCourse);

                sSQL += " AND C.sDispalyUnified ='" + sDisplayUnified + "'";
                //sSQL += " AND AV.strCourse='" + sCourse + "'";
            }

            if (iClass > 0)
            {
                sSQL += " AND AV.byteClass=" + iClass;

            }
            if (iLecturer > 0)
            {
                sSQL += " AND CT.intLecturer=" + iLecturer;
            }
            if (!string.IsNullOrEmpty(sHall))
            {
                sSQL += " AND CT.strHall='" + sHall + "'";
            }
            if (!string.IsNullOrEmpty(sUnit))
            {
                //sSQL += " AND L.strCollege='" + sUnit + "'";
                sSQL += " AND C.strCollege='" + sUnit + "'";
            }

            sSQL += " AND AV.byteShift<>11";//Private

            //sSQL += " Order By AV.byteShift,C.strCollege,C.CommitteeID,AV.strUnified,AV.byteClass,AV.strCourse,CT.byteDay,CT.dateTimeFrom";
            sSQL += " Order By C.strCollege,C.CommitteeID,AV.byteShift,C.sDispalyUnified,AV.strCourse,AV.byteClass,CT.byteDay,CT.dateTimeFrom";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            SqlDataReader Rd = Cmd.ExecuteReader();
            int _iPeriod = 0;
            string _sCourse = "";
            int _iClass = 0;

            int iRdPeriod = 0;
            string sRdCourse = "";
            string sRdUnified = "";
            string sRdDispalyUnified = "";
            string sRdCollege = "";
            int iRdCommitteeID = 0;
            int iRdClass = 0;

            TimeTable myTimeTable = new TimeTable();

            Available_CoursesDAL myAvailable_Courses = new Available_CoursesDAL ();
            //Add Begin
            myTimeTable.IPeriod = 0;
            myTimeTable.SCourse = "Begin";
            Classes.Times myTimes;
            Classes.Students myStudents;
            bool isLab = false;
            while (Rd.Read())
            {
                iRdPeriod = int.Parse(Rd["iPeriod"].ToString());
                sRdCourse = Rd["sCourse"].ToString();
                sRdUnified = Rd["sUnified"].ToString();
                sRdDispalyUnified = Rd["sDispalyUnified"].ToString();
                sRdCollege = Rd["sCollege"].ToString();
                iRdCommitteeID =int.Parse( Rd["CommitteeID"].ToString()); 
                iRdClass = int.Parse(Rd["iClass"].ToString());

                int IsOffered =InitializeModule.FALSE_VALUE  ;
                IsOffered = myAvailable_Courses.IsCourseOffered(Campus, sRdDispalyUnified, iYear, iSemester, iRdClass, iRdPeriod);

                if ((_iPeriod != iRdPeriod) || (_sCourse != sRdCourse) || (_iClass != iRdClass))
                {
                    //Add Previous Record
                    Result.Add(myTimeTable);
                    //New Record
                    myTimeTable = new TimeTable();
                    _iPeriod = iRdPeriod;
                    _sCourse = sRdCourse;
                    _iClass = iRdClass;

                    myTimeTable.IPeriod = iRdPeriod;
                    myTimeTable.SCourse = sRdCourse;
                    myTimeTable.sUnified = sRdUnified;
                    myTimeTable.sDispalyUnified  = sRdDispalyUnified;
                    myTimeTable.sCollege= sRdCollege;
                    myTimeTable.iCommitteeID = iRdCommitteeID;
                    myTimeTable.IClass = iRdClass;
                    myTimeTable.SPeriod = Rd["sPeriod"].ToString();
                    myTimeTable.SDesc = Rd["sDesc"].ToString();

                     
                    //if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse  && IsOffered == InitializeModule.FALSE_VALUE))
                    //{
                        myTimeTable.IMax = int.Parse(Rd["iMax"].ToString());

                        if (!Rd["sCount"].Equals(DBNull.Value))
                        {
                            myTimeTable.ICapacity = int.Parse(Rd["sCount"].ToString());
                        }
                        else
                        {
                            myTimeTable.ICapacity = 0;
                        }
                    //}
                  
                    //else
                    //{
                    //    myTimeTable.ICapacity = 0;
                    //}
                    

                    myTimeTable.ClassTimes = new List<Classes.Times>();
                    if (isStudentsIncluded)
                    {
                        myTimeTable.ClassStudents = new List<Classes.Students>();
                        myTimeTable.ClassStudents = Get_Students(iYear, iSemester, iRdPeriod, sRdCourse, iRdClass, Campus);
                    }
                      
                }
                 //================== hide equivelant courses details (class,lecturer,time,days,max,capacity)

                 myTimes = new Classes.Times();
                //-------------------------------------------
                    myTimes._sHall = Rd["sHall"].ToString();
                    myTimes._sCampus = Rd["sCampus"].ToString();
                    myTimes._iDays = int.Parse(Rd["iDays"].ToString());
                    if (!Rd["bLab"].Equals(DBNull.Value))
                    {
                        isLab = bool.Parse(Rd["bLab"].ToString());
                    }
                    else
                    {
                        isLab = false;
                    }
                    if (isLab)
                    {
                        myTimes._sDays = GetDays(myTimes._iDays) + " (Lab)";
                    }
                    else
                    {
                        myTimes._sDays = GetDays(myTimes._iDays);
                    }
                    myTimes._dFrom = DateTime.Parse(Rd["dFrom"].ToString());
                    myTimes._dTo = DateTime.Parse(Rd["dTo"].ToString());
                //--------------------------------------------
               // if (sRdUnified == sRdCourse)
                 if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse && IsOffered == InitializeModule.FALSE_VALUE))   
                {
                  
                    myTimes._iLecturer = int.Parse(Rd["iLecturer"].ToString());
                    myTimes._sLecturer = Rd["sLecturer"].ToString();
                   

                }

                 else
                 {
                     myTimes._iLecturer = 0;
                     myTimes._sLecturer = "";
                     //myTimes._sHall = "";
                     //myTimes._iDays = 0;
                     //myTimes._sDays = "";
                     //myTimes._dFrom = DateTime.Parse("");
                     //myTimes._dTo = DateTime.Parse("");
                 }

                 myTimeTable.ClassTimes.Add(myTimes);
            }

            if (Rd.HasRows)
            {
                Result.Add(myTimeTable);
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

    public List<TimeTable> GetTimeTable(int iYear, int iSemester, int iPeriod, string sCourse, int iClass, int iLecturer, string sHall, string sUnit, bool isStudentsIncluded, bool isHiddenShown, int iCampus, InitializeModule.EnumCampus Campus)
    {
        List<TimeTable> Result = new List<TimeTable>();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT AV.byteShift AS iPeriod, P.strShortcut AS sPeriod ";
            sSQL += " ,AV.strCourse AS sCourse, C.strCourseDescEn AS sDesc";
            sSQL += " , AV.byteClass AS iClass,L.strLecturerDescEn AS sLecturer";
            sSQL += " , CT.intLecturer AS iLecturer, CT.dateTimeFrom AS dFrom";
            sSQL += " , CT.dateTimeTo AS dTo, CT.byteDay AS iDays, CT.Notes";
            sSQL += " , CT.strHall AS sHall,strBuilding as sCampus, H.intMaxSeats AS iMax, ISNULL(CC.RegCapacity, 0) AS sCount";
            sSQL += " , CT.bLab,AV.strUnified AS sUnified,C.strCollege AS sCollege,C.CommitteeID,C.sDispalyUnified ";
                              
            sSQL += " FROM Reg_Available_Courses AS AV INNER JOIN Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND ";
            sSQL += " AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN";
            sSQL += " Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN";
            sSQL += " Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN ClassCapacity AS CC ON AV.intStudyYear = CC.iYear AND AV.byteSemester = CC.Sem AND AV.strCourse = CC.Course AND AV.byteClass = CC.Class AND ";
            sSQL += " AV.byteShift = CC.Shift";
                       
            sSQL += " WHERE AV.intStudyYear=" + iYear;
            sSQL += " AND AV.byteSemester=" + iSemester;
            sSQL += " AND H.iCampus="+iCampus;

            if (!isHiddenShown)
            {
                sSQL += " AND AV.byteClass<100";
            }

            if (iPeriod != 0)
            {
                if (iPeriod < 0)
                {
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            sSQL += " AND (AV.byteShift=1 or AV.byteShift=2 or AV.byteShift=9)";
                            break;

                        case InitializeModule.EnumCampus.Males:
                            sSQL += " AND (AV.byteShift=3 or AV.byteShift=4 or AV.byteShift=8)";
                            break;
                    }
                }
                else
                {
                    sSQL += " AND AV.byteShift=" + iPeriod;
                }
            }
            if (!string.IsNullOrEmpty(sCourse))
            {
                //get Unified course code
                CoursesDAL my_Courses = new CoursesDAL();

                string sDisplayUnified = my_Courses.GetDisplayUnified(Campus, sCourse);

                sSQL += " AND C.sDispalyUnified ='" + sDisplayUnified + "'";
                //sSQL += " AND AV.strCourse='" + sCourse + "'";
            }

            if (iClass > 0)
            {
                sSQL += " AND AV.byteClass=" + iClass;

            }
            if (iLecturer > 0)
            {
                sSQL += " AND CT.intLecturer=" + iLecturer;
            }
            if (!string.IsNullOrEmpty(sHall))
            {
                sSQL += " AND CT.strHall='" + sHall + "'";
            }
            if (!string.IsNullOrEmpty(sUnit))
            {
                //sSQL += " AND L.strCollege='" + sUnit + "'";
                sSQL += " AND C.strCollege='" + sUnit + "'";
            }

            sSQL += " AND AV.byteShift<>11";//Private

            //sSQL += " Order By AV.byteShift,C.strCollege,C.CommitteeID,AV.strUnified,AV.byteClass,AV.strCourse,CT.byteDay,CT.dateTimeFrom";
            sSQL += " Order By C.strCollege,C.CommitteeID,AV.byteShift,C.sDispalyUnified,AV.byteClass,AV.strCourse,CT.byteDay,CT.dateTimeFrom";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            SqlDataReader Rd = Cmd.ExecuteReader();
            int _iPeriod = 0;
            string _sCourse = "";
            int _iClass = 0;

            int iRdPeriod = 0;
            string sRdCourse = "";
            string sRdUnified = "";
            string sRdDispalyUnified = "";
            string sRdCollege = "";
            int iRdCommitteeID = 0;
            int iRdClass = 0;

            TimeTable myTimeTable = new TimeTable();

            Available_CoursesDAL myAvailable_Courses = new Available_CoursesDAL();
            //Add Begin
            myTimeTable.IPeriod = 0;
            myTimeTable.SCourse = "Begin";
            Classes.Times myTimes;
            Classes.Students myStudents;
            bool isLab = false;
            while (Rd.Read())
            {
                iRdPeriod = int.Parse(Rd["iPeriod"].ToString());
                sRdCourse = Rd["sCourse"].ToString();
                sRdUnified = Rd["sUnified"].ToString();
                sRdDispalyUnified = Rd["sDispalyUnified"].ToString();
                sRdCollege = Rd["sCollege"].ToString();
                iRdCommitteeID = int.Parse(Rd["CommitteeID"].ToString());
                iRdClass = int.Parse(Rd["iClass"].ToString());

                int IsOffered = InitializeModule.FALSE_VALUE;
                IsOffered = myAvailable_Courses.IsCourseOffered(Campus, sRdDispalyUnified, iYear, iSemester, iRdClass, iRdPeriod);

                if ((_iPeriod != iRdPeriod) || (_sCourse != sRdCourse) || (_iClass != iRdClass))
                {
                    //Add Previous Record
                    Result.Add(myTimeTable);
                    //New Record
                    myTimeTable = new TimeTable();
                    _iPeriod = iRdPeriod;
                    _sCourse = sRdCourse;
                    _iClass = iRdClass;

                    myTimeTable.IPeriod = iRdPeriod;
                    myTimeTable.SCourse = sRdCourse;
                    myTimeTable.sUnified = sRdUnified;
                    myTimeTable.sDispalyUnified = sRdDispalyUnified;
                    myTimeTable.sCollege = sRdCollege;
                    myTimeTable.iCommitteeID = iRdCommitteeID;
                    myTimeTable.IClass = iRdClass;
                    myTimeTable.SPeriod = Rd["sPeriod"].ToString();
                    myTimeTable.SDesc = Rd["sDesc"].ToString();


                    //if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse  && IsOffered == InitializeModule.FALSE_VALUE))
                    //{
                    myTimeTable.IMax = int.Parse(Rd["iMax"].ToString());

                    if (!Rd["sCount"].Equals(DBNull.Value))
                    {
                        myTimeTable.ICapacity = int.Parse(Rd["sCount"].ToString());
                    }
                    else
                    {
                        myTimeTable.ICapacity = 0;
                    }
                    //}

                    //else
                    //{
                    //    myTimeTable.ICapacity = 0;
                    //}


                    myTimeTable.ClassTimes = new List<Classes.Times>();
                    if (isStudentsIncluded)
                    {
                        myTimeTable.ClassStudents = new List<Classes.Students>();
                        myTimeTable.ClassStudents = Get_Students(iYear, iSemester, iRdPeriod, sRdCourse, iRdClass, Campus);
                    }

                }
                //================== hide equivelant courses details (class,lecturer,time,days,max,capacity)

                myTimes = new Classes.Times();
                //-------------------------------------------
                myTimes._sHall = Rd["sHall"].ToString();
                myTimes._sCampus = Rd["sCampus"].ToString();
                myTimes._iDays = int.Parse(Rd["iDays"].ToString());
                if (!Rd["bLab"].Equals(DBNull.Value))
                {
                    isLab = bool.Parse(Rd["bLab"].ToString());
                }
                else
                {
                    isLab = false;
                }
                if (isLab)
                {
                    myTimes._sDays = GetDays(myTimes._iDays) + " (Lab)";
                }
                else
                {
                    myTimes._sDays = GetDays(myTimes._iDays);
                }
                myTimes._dFrom = DateTime.Parse(Rd["dFrom"].ToString());
                myTimes._dTo = DateTime.Parse(Rd["dTo"].ToString());
                //--------------------------------------------
                // if (sRdUnified == sRdCourse)
                if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse && IsOffered == InitializeModule.FALSE_VALUE))
                {

                    myTimes._iLecturer = int.Parse(Rd["iLecturer"].ToString());
                    myTimes._sLecturer = Rd["sLecturer"].ToString();


                }

                else
                {
                    myTimes._iLecturer = 0;
                    myTimes._sLecturer = "";
                    //myTimes._sHall = "";
                    //myTimes._iDays = 0;
                    //myTimes._sDays = "";
                    //myTimes._dFrom = DateTime.Parse("");
                    //myTimes._dTo = DateTime.Parse("");
                }

                myTimeTable.ClassTimes.Add(myTimes);
            }

            if (Rd.HasRows)
            {
                Result.Add(myTimeTable);
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
       

    public List<TimeTable> GetStudentTimeTable(string sStudentNumber, int iYear, int iSemester, InitializeModule.EnumCampus Campus)
    {
        List<TimeTable> Result = new List<TimeTable>();

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            //Males
            string sSQL = "SELECT P.strShortcut AS sPeriod, CT.strCourse AS sCourse, C.strCourseDescEn AS sDesc, CT.byteClass AS iClass, L.strLecturerDescEn AS sLecturer,";
            sSQL += " CT.strHall AS sHall,H.strBuilding AS sCampus, CT.dateTimeFrom AS dFrom, CT.dateTimeTo AS dTo, dbo.ExtractDays(COALESCE (CT.byteDay, 0)) ";
            sSQL += " + (CASE CT.bLab WHEN 1 THEN ' (Lab)' ELSE '' END) AS iDays, CT.Notes,eBook.eBookCode,CT.byteDay";
            sSQL +=" FROM LOCALECT.ECTData.dbo.Course_Balance_View AS CV INNER JOIN";
            sSQL += " LOCALECT.ECTData.dbo.Reg_Courses AS C ON CV.Course = C.strCourse INNER JOIN";
            sSQL += " LOCALECT.ECTData.dbo.Reg_CourseTime_Schedule AS CT INNER JOIN";
            sSQL += " LOCALECT.ECTData.dbo.Reg_Shifts AS P ON CT.byteShift = P.byteShift INNER JOIN";
            sSQL += " LOCALECT.ECTData.dbo.Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer ON CV.iYear = CT.intStudyYear AND CV.Sem = CT.byteSemester AND CV.Shift = CT.byteShift AND ";
            sSQL += " CV.Course = CT.strCourse AND CV.Class = CT.byteClass INNER JOIN";
            sSQL += " LOCALECT.ECTData.dbo.Lkp_Halls AS H ON CT.strHall = H.strHall LEFT OUTER JOIN";
            sSQL += " LOCALECT.ECTData.dbo.Reg_Student_eBooks AS eBook ON CV.iYear = eBook.AcademicYear ";
            sSQL += " AND CV.Sem = eBook.Semester AND CV.Course = eBook.CourseID ";
            sSQL += " AND CV.Student = eBook.StudentID";
            sSQL += " WHERE (CT.intStudyYear = " + iYear + ") AND (CT.byteSemester = " + iSemester + ") AND (CV.Student = '" + sStudentNumber + "')";
            //Females
            sSQL += " UNION ";
            sSQL += " SELECT P.strShortcut AS sPeriod, CT.strCourse AS sCourse, C.strCourseDescEn AS sDesc, CT.byteClass AS iClass, L.strLecturerDescEn AS sLecturer,";
            sSQL += " CT.strHall AS sHall,H.strBuilding AS sCampus, CT.dateTimeFrom AS dFrom, CT.dateTimeTo AS dTo, dbo.ExtractDays(COALESCE (CT.byteDay, 0)) ";
            sSQL += " + (CASE CT.bLab WHEN 1 THEN ' (Lab)' ELSE '' END) AS iDays, CT.Notes,eBook.eBookCode,CT.byteDay";
            sSQL += " FROM SQL_SERVER.ECTData.dbo.Course_Balance_View AS CV INNER JOIN";
            sSQL += " SQL_SERVER.ECTData.dbo.Reg_Courses AS C ON CV.Course = C.strCourse INNER JOIN";
            sSQL += " SQL_SERVER.ECTData.dbo.Reg_CourseTime_Schedule AS CT INNER JOIN";
            sSQL += " SQL_SERVER.ECTData.dbo.Reg_Shifts AS P ON CT.byteShift = P.byteShift INNER JOIN";
            sSQL += " SQL_SERVER.ECTData.dbo.Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer ON CV.iYear = CT.intStudyYear AND CV.Sem = CT.byteSemester AND CV.Shift = CT.byteShift AND ";
            sSQL += " CV.Course = CT.strCourse AND CV.Class = CT.byteClass INNER JOIN";
            sSQL += " SQL_SERVER.ECTData.dbo.Lkp_Halls AS H ON CT.strHall = H.strHall LEFT OUTER JOIN";
            sSQL += " SQL_SERVER.ECTData.dbo.Reg_Student_eBooks AS eBook ON CV.iYear = eBook.AcademicYear ";
            sSQL += " AND CV.Sem = eBook.Semester AND CV.Course = eBook.CourseID ";
            sSQL += " AND CV.Student = eBook.StudentID";
            sSQL += " WHERE (CT.intStudyYear = " + iYear + ") AND (CT.byteSemester = " + iSemester + ") AND (CV.Student = '" + sStudentNumber + "')";
 

            sSQL += " ORDER BY sCourse, CT.byteDay, dFrom";
                       
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            
           
            //Add Begin
            //myTimeTable.IPeriod = 0;
            //myTimeTable.SCourse = "Begin";
            Classes.Times myTimes;
            
            while (Rd.Read())
            {
                TimeTable myTimeTable = new TimeTable();
               // myTimeTable.IPeriod = int.Parse(Rd["iPeriod"].ToString());
                myTimeTable.SCourse = Rd["sCourse"].ToString();
                myTimeTable.SDesc = Rd["sDesc"].ToString();
                myTimeTable.IClass = int.Parse(Rd["iClass"].ToString());
                myTimeTable.SPeriod = Rd["sPeriod"].ToString();

                myTimeTable.ClassTimes = new List<Classes.Times>();
                myTimes = new Classes.Times();
                //myTimes._iLecturer = int.Parse(Rd["iLecturer"].ToString());
                myTimes._sLecturer = Rd["sLecturer"].ToString();
                myTimes._sHall = Rd["sHall"].ToString();
                myTimes._sCampus = Rd["sCampus"].ToString();
                //myTimes._iDays = int.Parse(Rd["iDays"].ToString());
                //myTimes._sDays = GetDays(myTimes._iDays) + "  " + Rd["Notes"].ToString();
                myTimes._sDays = Rd["iDays"].ToString();
                myTimes._dFrom = DateTime.Parse(Rd["dFrom"].ToString());
                myTimes._dTo = DateTime.Parse(Rd["dTo"].ToString());
                myTimes._seBookCode = Rd["eBookCode"].ToString();
                myTimeTable.ClassTimes.Add(myTimes);

                Result.Add(myTimeTable);
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

    public List<TimeTable> GetFacultyLoads(int iYear, int iSemester, int iPeriod, string sCourse, int iClass, int iLecturer, string sHall, string sUnit, bool isStudentsIncluded, InitializeModule.EnumCampus Campus)
    {
        List<TimeTable> Result = new List<TimeTable>();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "";


            sSQL = "SELECT AV.byteShift AS iPeriod, P.strShortcut AS sPeriod, C.sUnified AS sCourse, U.strCourseDescEn AS sDesc, AV.byteClass AS iClass,";
            sSQL += " L.strLecturerDescEn AS sLecturer, CT.intLecturer AS iLecturer,CT.dateTimeFrom AS dFrom, CT.dateTimeTo AS dTo,";
            sSQL += " CT.byteDay AS iDays, CT.strHall AS sHall, H.intMaxSeats AS iMax,Counts.sCount, C.byteCreditHours, DATEDIFF(minute, CT.dateTimeFrom, CT.dateTimeTo) as minutes";
            sSQL += " FROM Reg_Available_Courses AS AV INNER JOIN Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND ";
            sSQL += " AV.strCourse = CT.strCourse AND AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN ";
            sSQL += " Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN ";
            sSQL += " Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN Reg_Courses AS U ON C.sUnified = U.strCourse LEFT OUTER JOIN ";
            sSQL += " Courses_Counts AS Counts ON AV.intStudyYear = Counts.iYear AND AV.byteSemester = Counts.Sem AND AV.strCourse = Counts.Course AND ";
            sSQL += " AV.byteClass = Counts.Class AND AV.byteShift = Counts.Shift";

            sSQL += " WHERE AV.intStudyYear=" + iYear;
            sSQL += " AND AV.byteSemester=" + iSemester;
            
            if (iPeriod != 0)
            {
                if (iPeriod < 0)
                {
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            sSQL += " AND (AV.byteShift=1 or AV.byteShift=2 or AV.byteShift=9)";
                            break;

                        case InitializeModule.EnumCampus.Males:
                            sSQL += " AND (AV.byteShift=3 or AV.byteShift=4 or AV.byteShift=8)";
                            break;
                    }
                }
                else
                {
                    sSQL += " AND AV.byteShift=" + iPeriod;
                }
            }
            if (!string.IsNullOrEmpty(sCourse))
            {
                sSQL += " AND AV.strCourse='" + sCourse + "'";
            }
            if (iClass > 0)
            {
                sSQL += " AND AV.byteClass=" + iClass;

            }
            if (iLecturer > 0)
            {
                sSQL += " AND CT.intLecturer=" + iLecturer;
            }
            if (!string.IsNullOrEmpty(sHall))
            {
                sSQL += " AND CT.strHall='" + sHall + "'";
            }
            if (!string.IsNullOrEmpty(sUnit))
            {
                sSQL += " AND L.strCollege='" + sUnit + "'";
            }

            sSQL += " Order By AV.byteShift,AV.strCourse,AV.byteClass,CT.byteDay,CT.dateTimeFrom";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            SqlDataReader Rd = Cmd.ExecuteReader();
            int _iPeriod = 0;
            string _sCourse = "";
            int _iClass = 0;

            int iRdPeriod = 0;
            string sRdCourse = "";
            int iRdClass = 0;

            TimeTable myTimeTable = new TimeTable();
            //Add Begin
            myTimeTable.IPeriod = 0;
            myTimeTable.SCourse = "Begin";
            Classes.Times myTimes;
            Classes.Students myStudents;

            while (Rd.Read())
            {
                iRdPeriod = int.Parse(Rd["iPeriod"].ToString());
                sRdCourse = Rd["sCourse"].ToString();
                iRdClass = int.Parse(Rd["iClass"].ToString());

                if ((_iPeriod != iRdPeriod) || (_sCourse != sRdCourse) || (_iClass != iRdClass))
                {
                    //Add Previous Record
                    Result.Add(myTimeTable);
                    //New Record
                    myTimeTable = new TimeTable();
                    _iPeriod = iRdPeriod;
                    _sCourse = sRdCourse;
                    _iClass = iRdClass;
                    myTimeTable.IPeriod = iRdPeriod;
                    myTimeTable.SCourse = sRdCourse;
                    myTimeTable.IClass = iRdClass;
                    myTimeTable.DCreditHours = decimal.Parse(Rd["byteCreditHours"].ToString());
                    myTimeTable.SPeriod = Rd["sPeriod"].ToString();
                    myTimeTable.SDesc = Rd["sDesc"].ToString();
                    myTimeTable.IMax = int.Parse(Rd["iMax"].ToString());
                    if (!Rd["sCount"].Equals(DBNull.Value))
                    {
                        myTimeTable.ICapacity = int.Parse(Rd["sCount"].ToString());
                    }
                    else
                    {
                        myTimeTable.ICapacity = 0;
                    }
                    myTimeTable.ClassTimes = new List<Classes.Times>();
                    if (isStudentsIncluded)
                    {
                        myTimeTable.ClassStudents = new List<Classes.Students>();
                        myTimeTable.ClassStudents = Get_Students(iYear, iSemester, iRdPeriod, sRdCourse, iRdClass, Campus);
                    }
                }
                myTimes = new Classes.Times();
                myTimes._iLecturer = int.Parse(Rd["iLecturer"].ToString());
                myTimes._sLecturer = Rd["sLecturer"].ToString();
                myTimes._sHall = Rd["sHall"].ToString();
                myTimes._iDays = int.Parse(Rd["iDays"].ToString());
                int iCount = 0;
                myTimes._sDays = GetDays(myTimes._iDays, out iCount);

                myTimes._dFrom = DateTime.Parse(Rd["dFrom"].ToString());
                myTimes._dTo = DateTime.Parse(Rd["dTo"].ToString());
                decimal dTeachingHours = decimal.Parse(Rd["minutes"].ToString());
                dTeachingHours = (dTeachingHours / 60) * iCount;
                myTimes._dTeachingHours = dTeachingHours;

                myTimeTable.ClassTimes.Add(myTimes);

            }

            if (Rd.HasRows)
            {
                Result.Add(myTimeTable);
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

    public List<Classes.Students> Get_Students(int iYear, int iSem, int iPeriod, string sCourse, int iClass, InitializeModule.EnumCampus Campus)
    {
        List<Classes.Students> Result = new List<Classes.Students>();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT A.lngStudentNumber AS sNo, SD.strLastDescEn AS sName, P.strShortcut AS sPeriod, M.strMajor AS sMajor,";
            sSQL += "  G.GPA AS CGPA, E.strCert AS ENG,E.Mark AS Score, SD.strPhone1 AS sPhone1, SD.strPhone2 AS sPhone2,SD.sECTemail, GH.strGrade";

            sSQL += " ,CONVERT(VARCHAR,DAY(CH.dateCreate)) + '-' + CONVERT(VARCHAR, MONTH(CH.dateCreate)) + '-' + CONVERT(VARCHAR, YEAR(CH.dateCreate)) AS RegDate";

            sSQL += " FROM Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN";
            sSQL += " Course_Balance_View AS CB ON A.lngStudentNumber = CB.Student INNER JOIN Reg_Specializations AS M ";
            sSQL += " ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization ";
            sSQL += " INNER JOIN Reg_Shifts AS P ON SD.byteShift = P.byteShift ";
            sSQL += " INNER JOIN dbo.Reg_Course_Header AS CH ";
            sSQL += " ON CB.iYear = CH.intStudyYear AND CB.Sem = CH.byteSemester AND CB.Student = CH.lngStudentNumber";
            sSQL += " LEFT OUTER JOIN Reg_Grade_Header AS GH ";
            sSQL += " ON CB.iYear = GH.intStudyYear AND CB.Sem = GH.byteSemester AND CB.Course = GH.strCourse AND ";
            sSQL += " CB.Student = GH.lngStudentNumber LEFT OUTER JOIN MaxEngCertMark AS E ON CB.Student = E.lngStudentNumber LEFT OUTER JOIN";
            sSQL += " GPA_Until AS G ON CB.Student = G.lngStudentNumber";
            sSQL += " WHERE CB.iYear =" + iYear;
            sSQL += " AND CB.Sem =" + iSem;
            sSQL += " AND CB.Shift =" + iPeriod;
            sSQL += " AND CB.Course ='" + sCourse + "'";
            sSQL += " AND CB.Class =" + iClass;
            sSQL += " ORDER BY SD.strLastDescEn";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            SqlDataReader Rd = Cmd.ExecuteReader();
            Classes.Students myStudent; 
            int iSerial=0;
            while (Rd.Read())
            {
                iSerial+=1;
                myStudent = new Classes.Students();
                myStudent._Serial=iSerial;
                myStudent._StudentNumber = Rd["sNo"].ToString();
                myStudent._Name = Rd["sName"].ToString();
                myStudent._Period = Rd["sPeriod"].ToString();
                myStudent._Major = Rd["sMajor"].ToString();
                myStudent._sECTemail = Rd["sECTemail"].ToString();
                myStudent._RegDate = Rd["RegDate"].ToString();
                if (!Rd["strGrade"].Equals(DBNull.Value))
                {
                    myStudent._Grade = Rd["strGrade"].ToString();
                }
                if (!Rd["sPhone1"].Equals(DBNull.Value))
                {
                    myStudent._Phone1 = Rd["sPhone1"].ToString();
                }
                if (!Rd["sPhone2"].Equals(DBNull.Value))
                {
                    myStudent._Phone2 = Rd["sPhone2"].ToString();
                }
                if (!Rd["CGPA"].Equals(DBNull.Value))
                {
                    myStudent._CGPA = decimal.Parse(Rd["CGPA"].ToString());
                }
                else 
                {
                    myStudent._CGPA = 101;
                }
                if (!Rd["Score"].Equals(DBNull.Value))
                {
                    myStudent._Score = decimal.Parse(Rd["Score"].ToString());
                }
                if (!Rd["ENG"].Equals(DBNull.Value))
                {
                    myStudent._ENG = Rd["ENG"].ToString();
                }
                Result.Add(myStudent);

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

    public List<Classes.Students> Get_Students(int iYear, int iSem, int iPeriod, string sCourse, int iClass, InitializeModule.EnumCampus Campus, bool isDefaultIncluded)
    {
        List<Classes.Students> Result = new List<Classes.Students>();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT A.lngStudentNumber as sNo, SD.strLastDescEn as sName";
            sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN"; 
            sSQL += " Course_Balance_View AS CB ON A.lngStudentNumber = CB.Student";            
            sSQL += " WHERE CB.iYear =" + iYear;
            sSQL += " AND CB.Sem =" + iSem;
            sSQL += " AND CB.Shift =" + iPeriod;
            sSQL += " AND CB.Course ='" + sCourse +"'";
            sSQL += " AND CB.Class =" + iClass;
            sSQL += " ORDER BY SD.strLastDescEn";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            SqlDataReader Rd = Cmd.ExecuteReader();
            Classes.Students myStudent;
            if (isDefaultIncluded)
            {
                myStudent = new Classes.Students();
                myStudent._StudentNumber = "0";
                myStudent._Name = "Select Student ...";
                Result.Add(myStudent);
            }
           
            while (Rd.Read())
            {
                myStudent = new Classes.Students();
                myStudent._StudentNumber = Rd["sNo"].ToString();
                myStudent._Name = Rd["sName"].ToString();
                Result.Add(myStudent);

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

    public List<TimeTable> GetTimeTable(int iYear, int iSemester, int iPeriod, string sCourse, int iClass, int iLecturer, string sHall, string sUnit, bool isStudentsIncluded, InitializeModule.EnumCampus Campus,string sCampus)
    {
        List<TimeTable> Result = new List<TimeTable>();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT AV.byteShift AS iPeriod, P.strShortcut AS sPeriod ";
            sSQL += " ,AV.strCourse AS sCourse, C.strCourseDescEn AS sDesc";
            sSQL += " , AV.byteClass AS iClass,L.strLecturerDescEn AS sLecturer";
            sSQL += " , CT.intLecturer AS iLecturer, CT.dateTimeFrom AS dFrom";
            sSQL += " , CT.dateTimeTo AS dTo, CT.byteDay AS iDays, CT.Notes";
            sSQL += " , CT.strHall AS sHall,strBuilding as sCampus, H.intMaxSeats AS iMax, ISNULL(ClassCapacity.RegCapacity, 0) AS sCount";
            sSQL += " , CT.bLab,AV.strUnified AS sUnified,C.strCollege AS sCollege,C.CommitteeID,C.sDispalyUnified ";
            sSQL += " FROM Reg_Available_Courses AS AV INNER JOIN Reg_CourseTime_Schedule AS CT";
            sSQL += " ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester ";
            sSQL += " AND AV.strCourse = CT.strCourse AND AV.byteClass = CT.byteClass ";
            sSQL += " AND AV.byteShift = CT.byteShift INNER JOIN Lkp_Halls AS H ";
            sSQL += " ON CT.strHall = H.strHall INNER JOIN Reg_Lecturers AS L ";
            sSQL += " ON CT.intLecturer = L.intLecturer INNER JOIN";
            sSQL += " Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN Reg_Shifts AS P ON AV.byteShift = P.byteShift LEFT OUTER JOIN";
            sSQL += " ClassCapacity ON AV.intStudyYear = ClassCapacity.iYear AND AV.byteSemester = ClassCapacity.Sem AND AV.strCourse = ClassCapacity.Course AND ";
            sSQL += " AV.byteClass = ClassCapacity.Class AND AV.byteShift = ClassCapacity.Shift";

            //string sSQL = "SELECT AV.byteShift AS iPeriod, P.strShortcut AS sPeriod, AV.strCourse AS sCourse, C.strCourseDescEn AS sDesc, AV.byteClass AS iClass,";
            //sSQL += " L.strLecturerDescEn AS sLecturer, CT.intLecturer AS iLecturer,CT.dateTimeFrom AS dFrom, CT.dateTimeTo AS dTo, CT.byteDay AS iDays,CT.Notes, CT.strHall AS sHall, convert(int,H.intMaxSeats * C.CapFactor) AS iMax,Counts.sCount,CT.bLab";
            //sSQL += " FROM dbo.Reg_Available_Courses AS AV INNER JOIN dbo.Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND ";
            //sSQL += " AV.strCourse = CT.strCourse AND AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN dbo.Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN";
            //sSQL += " dbo.Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN dbo.Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN";
            //sSQL += " dbo.Reg_Shifts AS P ON AV.byteShift = P.byteShift LEFT OUTER JOIN dbo.Courses_Counts AS Counts ON AV.intStudyYear = Counts.iYear AND AV.byteSemester = Counts.Sem AND AV.strCourse = Counts.Course AND ";
            //sSQL += " AV.byteClass = Counts.Class AND AV.byteShift = Counts.Shift";
            sSQL += " WHERE AV.intStudyYear=" + iYear;
            sSQL += " AND AV.byteSemester=" + iSemester;
            //sSQL += " AND H.iCampus=3";
            if (iPeriod != 0)
            {
                if (iPeriod < 0)
                {
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            sSQL += " AND (AV.byteShift=1 or AV.byteShift=2 or AV.byteShift=9)";
                            break;

                        case InitializeModule.EnumCampus.Males:
                            sSQL += " AND (AV.byteShift=3 or AV.byteShift=4 or AV.byteShift=8)";
                            break;
                    }
                }
                else
                {
                    sSQL += " AND AV.byteShift=" + iPeriod;
                }
            }
            if (!string.IsNullOrEmpty(sCourse))
            {
                //get Unified course code
                CoursesDAL my_Courses = new CoursesDAL();

                string sDisplayUnified = my_Courses.GetDisplayUnified(Campus, sCourse);

                sSQL += " AND C.sDispalyUnified ='" + sDisplayUnified + "'";
                //sSQL += " AND AV.strCourse='" + sCourse + "'";
            }

            if (iClass > 0)
            {
                sSQL += " AND AV.byteClass=" + iClass;

            }
            if (iLecturer > 0)
            {
                sSQL += " AND CT.intLecturer=" + iLecturer;
            }
            if (!string.IsNullOrEmpty(sHall))
            {
                sSQL += " AND CT.strHall='" + sHall + "'";
            }
            if (!string.IsNullOrEmpty(sUnit))
            {
                //sSQL += " AND L.strCollege='" + sUnit + "'";
                sSQL += " AND C.strCollege='" + sUnit + "'";
            }

            sSQL += " AND AV.byteShift<>11";//Private

            sSQL += sCampus;

            //sSQL += " Order By AV.byteShift,C.strCollege,C.CommitteeID,AV.strUnified,AV.byteClass,AV.strCourse,CT.byteDay,CT.dateTimeFrom";
            sSQL += " Order By C.strCollege,C.CommitteeID,AV.byteShift,C.sDispalyUnified,AV.strCourse,AV.byteClass,CT.byteDay,CT.dateTimeFrom";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            SqlDataReader Rd = Cmd.ExecuteReader();
            int _iPeriod = 0;
            string _sCourse = "";
            int _iClass = 0;

            int iRdPeriod = 0;
            string sRdCourse = "";
            string sRdUnified = "";
            string sRdDispalyUnified = "";
            string sRdCollege = "";
            int iRdCommitteeID = 0;
            int iRdClass = 0;

            TimeTable myTimeTable = new TimeTable();

            Available_CoursesDAL myAvailable_Courses = new Available_CoursesDAL();
            //Add Begin
            myTimeTable.IPeriod = 0;
            myTimeTable.SCourse = "Begin";
            Classes.Times myTimes;
            Classes.Students myStudents;
            bool isLab = false;
            while (Rd.Read())
            {
                iRdPeriod = int.Parse(Rd["iPeriod"].ToString());
                sRdCourse = Rd["sCourse"].ToString();
                sRdUnified = Rd["sUnified"].ToString();
                sRdDispalyUnified = Rd["sDispalyUnified"].ToString();
                sRdCollege = Rd["sCollege"].ToString();
                iRdCommitteeID = int.Parse(Rd["CommitteeID"].ToString());
                iRdClass = int.Parse(Rd["iClass"].ToString());

                int IsOffered = InitializeModule.FALSE_VALUE;
                IsOffered = myAvailable_Courses.IsCourseOffered(Campus, sRdDispalyUnified, iYear, iSemester, iRdClass, iRdPeriod);

                if ((_iPeriod != iRdPeriod) || (_sCourse != sRdCourse) || (_iClass != iRdClass))
                {
                    //Add Previous Record
                    Result.Add(myTimeTable);
                    //New Record
                    myTimeTable = new TimeTable();
                    _iPeriod = iRdPeriod;
                    _sCourse = sRdCourse;
                    _iClass = iRdClass;

                    myTimeTable.IPeriod = iRdPeriod;
                    myTimeTable.SCourse = sRdCourse;
                    myTimeTable.sUnified = sRdUnified;
                    myTimeTable.sDispalyUnified = sRdDispalyUnified;
                    myTimeTable.sCollege = sRdCollege;
                    myTimeTable.iCommitteeID = iRdCommitteeID;
                    myTimeTable.IClass = iRdClass;
                    myTimeTable.SPeriod = Rd["sPeriod"].ToString();
                    myTimeTable.SDesc = Rd["sDesc"].ToString();


                    //if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse  && IsOffered == InitializeModule.FALSE_VALUE))
                    //{
                    myTimeTable.IMax = int.Parse(Rd["iMax"].ToString());

                    if (!Rd["sCount"].Equals(DBNull.Value))
                    {
                        myTimeTable.ICapacity = int.Parse(Rd["sCount"].ToString());
                    }
                    else
                    {
                        myTimeTable.ICapacity = 0;
                    }
                    //}

                    //else
                    //{
                    //    myTimeTable.ICapacity = 0;
                    //}


                    myTimeTable.ClassTimes = new List<Classes.Times>();
                    if (isStudentsIncluded)
                    {
                        myTimeTable.ClassStudents = new List<Classes.Students>();
                        myTimeTable.ClassStudents = Get_Students(iYear, iSemester, iRdPeriod, sRdCourse, iRdClass, Campus);
                    }

                }
                //================== hide equivelant courses details (class,lecturer,time,days,max,capacity)

                myTimes = new Classes.Times();
                //-------------------------------------------
                myTimes._sHall = Rd["sHall"].ToString();
                myTimes._sCampus = Rd["sCampus"].ToString();
                myTimes._iDays = int.Parse(Rd["iDays"].ToString());
                if (!Rd["bLab"].Equals(DBNull.Value))
                {
                    isLab = bool.Parse(Rd["bLab"].ToString());
                }
                else
                {
                    isLab = false;
                }
                if (isLab)
                {
                    myTimes._sDays = GetDays(myTimes._iDays) + " (Lab)";
                }
                else
                {
                    myTimes._sDays = GetDays(myTimes._iDays);
                }
                myTimes._dFrom = DateTime.Parse(Rd["dFrom"].ToString());
                myTimes._dTo = DateTime.Parse(Rd["dTo"].ToString());
                //--------------------------------------------
                // if (sRdUnified == sRdCourse)
                if ((sRdDispalyUnified == sRdCourse && IsOffered == InitializeModule.TRUE_VALUE) || (sRdUnified == sRdCourse && IsOffered == InitializeModule.FALSE_VALUE))
                {

                    myTimes._iLecturer = int.Parse(Rd["iLecturer"].ToString());
                    myTimes._sLecturer = Rd["sLecturer"].ToString();


                }

                else
                {
                    myTimes._iLecturer = 0;
                    myTimes._sLecturer = "";
                    //myTimes._sHall = "";
                    //myTimes._iDays = 0;
                    //myTimes._sDays = "";
                    //myTimes._dFrom = DateTime.Parse("");
                    //myTimes._dTo = DateTime.Parse("");
                }

                myTimeTable.ClassTimes.Add(myTimes);
            }

            if (Rd.HasRows)
            {
                Result.Add(myTimeTable);
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
