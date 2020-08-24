using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIS_Student.DAL
{
    public class DAL
    {
        public DataTable GetMenuData(int roleid)
        {
            DataTable dt = GetData("SELECT O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel, COUNT(RP.PrivilegeID) AS [Privileges] FROM Cmn_RolePermissions AS RP INNER JOIN Cmn_PrivilegeObjects AS O ON RP.ObjectID = O.ObjectID Where RP.RoleID = "+roleid+ " and O.SystemID = 10 GROUP BY O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel Order by O.iLevel,O.ShowOrder asc");
            return dt;
        }
        public DataTable GetStudentServices()
        {
            DataTable dt = GetData("SELECT     S.ServiceID, S.ServiceEn, S.ServiceAr, S.ServiceDescEn, S.ServiceDescAr, S.Audience, S.Host, S.HostDesc, S.FeesType, S.RequestList, S.RequestLink, S.ExampleLink, ISNULL(F.curAmount, 0) AS Fees, ISNULL(F.curVAT, 0) AS VAT,ISNULL((F.curAmount + F.curVAT),0) as Sum, S.DataNeeded FROM         ECT_Services AS S LEFT OUTER JOIN (SELECT     bytePaymentFor, curAmount, curVAT FROM          ECTData.dbo.Acc_Payment_For AS ACCP) AS F ON S.FeesType = F.bytePaymentFor where S.Audience='Students' ORDER BY S.ServiceID asc");
            return dt;
        }
        public DataTable GetStudentServicesbyID(string serviceid)
        {
            DataTable dt = GetData("SELECT     S.ServiceID, S.ServiceEn, S.ServiceAr, S.ServiceDescEn, S.ServiceDescAr, S.Audience, S.Host, S.HostDesc, S.FeesType, S.RequestList, S.RequestLink, S.ExampleLink, ISNULL(F.curAmount, 0) AS Fees, ISNULL(F.curVAT, 0) AS VAT,ISNULL((F.curAmount + F.curVAT),0) as Sum, S.DataNeeded FROM         ECT_Services AS S LEFT OUTER JOIN (SELECT     bytePaymentFor, curAmount, curVAT FROM          ECTData.dbo.Acc_Payment_For AS ACCP) AS F ON S.FeesType = F.bytePaymentFor where S.Audience='Students' and S.ServiceID='"+ serviceid + "' ORDER BY S.ServiceID asc");
            return dt;
        }

        public DataTable GetStudentDetailsID(string studentid, string connStr)
        {
            DataTable dt = GetData("SELECT        Reg_Applications.lngStudentNumber, Reg_Students_Data.strLastDescEn, Reg_Specializations.strCaption, dbo.cleanphone(Reg_Students_Data.strPhone1) AS Phone, Reg_Students_Data.sECTemail,Reg_Applications.byteCancelReason FROM Reg_Applications INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial INNER JOIN Reg_Specializations ON Reg_Applications.strCollege = Reg_Specializations.strCollege AND Reg_Applications.strDegree = Reg_Specializations.strDegree AND Reg_Applications.strSpecialization = Reg_Specializations.strSpecialization where Reg_Applications.lngStudentNumber='" + studentid+"'", connStr);
            return dt;
        }

        public DataTable GetCoursesbyStudentId(string studentid, string connStr,int year,int sem)
        {
            DataTable dt = GetData("SELECT  Course_Balance_View_BothSides.iYear, Course_Balance_View_BothSides.Sem, Course_Balance_View_BothSides.Student, Course_Balance_View_BothSides.Course AS Code, Course_Balance_View_BothSides.Course + N'-' + Reg_Courses.strCourseDescEn AS Course, Reg_Lecturers.strLecturerDescEn FROM            Course_Balance_View_BothSides INNER JOIN Reg_Courses ON Course_Balance_View_BothSides.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule ON Course_Balance_View_BothSides.iYear = Reg_CourseTime_Schedule.intStudyYear AND Course_Balance_View_BothSides.Sem = Reg_CourseTime_Schedule.byteSemester AND Course_Balance_View_BothSides.Course = Reg_CourseTime_Schedule.strCourse INNER JOIN Reg_Lecturers ON Reg_CourseTime_Schedule.intLecturer = Reg_Lecturers.intLecturer WHERE        (Course_Balance_View_BothSides.iYear = "+year+") AND (Course_Balance_View_BothSides.Sem = "+sem+") AND (Course_Balance_View_BothSides.Student = N'"+studentid+"') AND (Reg_CourseTime_Schedule.bLab = 0)", connStr);
            return dt;
        }

        public DataTable GetCoursesbyCourseId(string studentid, string connStr, int year, int sem,string courseid)
        {
            DataTable dt = GetData("SELECT  Course_Balance_View_BothSides.iYear, Course_Balance_View_BothSides.Sem, Course_Balance_View_BothSides.Student, Course_Balance_View_BothSides.Course AS Code, Course_Balance_View_BothSides.Course + N'-' + Reg_Courses.strCourseDescEn AS Course, Reg_Lecturers.strLecturerDescEn FROM            Course_Balance_View_BothSides INNER JOIN Reg_Courses ON Course_Balance_View_BothSides.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule ON Course_Balance_View_BothSides.iYear = Reg_CourseTime_Schedule.intStudyYear AND Course_Balance_View_BothSides.Sem = Reg_CourseTime_Schedule.byteSemester AND Course_Balance_View_BothSides.Course = Reg_CourseTime_Schedule.strCourse INNER JOIN Reg_Lecturers ON Reg_CourseTime_Schedule.intLecturer = Reg_Lecturers.intLecturer WHERE        (Course_Balance_View_BothSides.iYear = " + year + ") AND (Course_Balance_View_BothSides.Sem = " + sem + ") AND (Course_Balance_View_BothSides.Student = N'" + studentid + "') AND (Reg_CourseTime_Schedule.bLab = 0) AND Course_Balance_View_BothSides.Course='"+courseid+"' ", connStr);
            return dt;
        }

        public DataTable GetMajors(string connStr)
        {
            DataTable dt = GetData("SELECT distinct(strCaption) FROM Reg_Specializations WHERE (bAvailable = 1) and strCaption not in ('Diploma in Public Relations','Visiting Students') ORDER BY strCaption asc",connStr);
            return dt;
        }

        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

        public DataTable GetData(string query,string connStr)
        {
            DataTable dt = new DataTable();
            string constr = connStr;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
    }

}