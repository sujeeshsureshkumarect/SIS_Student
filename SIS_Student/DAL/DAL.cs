﻿using System;
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
            DataTable dt = GetData("SELECT O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel, COUNT(RP.PrivilegeID) AS [Privileges] FROM Cmn_RolePermissions AS RP INNER JOIN Cmn_PrivilegeObjects AS O ON RP.ObjectID = O.ObjectID Where RP.RoleID = "+roleid+ " and O.SystemID = 10 and O.isVisible=1 GROUP BY O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel Order by O.iLevel,O.ShowOrder asc");
            return dt;
        }
        public DataTable GetStudentServices()
        {
            DataTable dt = GetData("SELECT     S.Finance,S.ServiceID, S.ServiceEn, S.ServiceAr, S.ServiceDescEn, S.ServiceDescAr, S.Audience, S.Host, S.HostDesc, S.FeesType, S.RequestList, S.RequestLink, S.ExampleLink, ISNULL(F.curAmount, 0) AS Fees, ISNULL(F.curVAT, 0) AS VAT,ISNULL((F.curAmount + F.curVAT),0) as Sum, S.DataNeeded,S.LanguageOption FROM         ECT_Services AS S LEFT OUTER JOIN (SELECT     bytePaymentFor, curAmount, curVAT FROM          ECTData.dbo.Acc_Payment_For AS ACCP) AS F ON S.FeesType = F.bytePaymentFor where S.Audience='Students' and isActive=1 ORDER BY S.ServiceID asc");
            return dt;
        }
        public DataTable GetStudentServicesbyID(string serviceid)
        {
            DataTable dt = GetData("SELECT     S.ServiceHeaderEn,S.ServiceHeaderAr,S.Finance,S.ServiceID, S.ServiceEn, S.ServiceAr, S.ServiceDescEn, S.ServiceDescAr, S.Audience, S.Host, S.HostDesc, S.FeesType, S.RequestList, S.RequestLink, S.ExampleLink, ISNULL(F.curAmount, 0) AS Fees, ISNULL(F.curVAT, 0) AS VAT,ISNULL((F.curAmount + F.curVAT),0) as Sum, S.DataNeeded,S.LanguageOption FROM         ECT_Services AS S LEFT OUTER JOIN (SELECT     bytePaymentFor, curAmount, curVAT FROM          ECTData.dbo.Acc_Payment_For AS ACCP) AS F ON S.FeesType = F.bytePaymentFor where S.Audience='Students' and S.ServiceID='" + serviceid + "' ORDER BY S.ServiceID asc");
            return dt;
        }

        public DataTable GetStudentDetailsID(string studentid, string connStr)
        {
            DataTable dt = GetData("SELECT     Reg_Applications.strDegree,Reg_Applications.lngStudentNumber, Reg_Students_Data.strLastDescEn, Reg_Specializations.strCaption, dbo.cleanphone(Reg_Students_Data.strPhone1) AS Phone, Reg_Students_Data.sECTemail,Reg_Applications.byteCancelReason,Reg_Students_Data.strNationalID AS EID,Reg_Students_Data.strFirstDescEn, Reg_Students_Data.strSecondDescEn, Reg_Students_Data.strThirdDescEn FROM Reg_Applications INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial INNER JOIN Reg_Specializations ON Reg_Applications.strCollege = Reg_Specializations.strCollege AND Reg_Applications.strDegree = Reg_Specializations.strDegree AND Reg_Applications.strSpecialization = Reg_Specializations.strSpecialization where Reg_Applications.lngStudentNumber='" + studentid+"'", connStr);
            return dt;
        }

        public DataTable GetStudentDetailsIDbyNationality(string studentid, string connStr)
        {
            DataTable dt = GetData("SELECT Reg_Applications.lngStudentNumber, Reg_Students_Data.strLastDescEn, Reg_Specializations.strCaption, dbo.CleanPhone(Reg_Students_Data.strPhone1) AS Phone, Reg_Students_Data.sECTemail, Reg_Applications.byteCancelReason,Reg_Applications.intGraduationYear,Reg_Applications.byteGraduationSemester,  Reg_Students_Data.strNationalID AS EID, Lkp_Nationalities.strNationalityDescEn, Reg_Students_Data.dateBirth FROM Reg_Applications INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial INNER JOIN Reg_Specializations ON Reg_Applications.strCollege = Reg_Specializations.strCollege AND Reg_Applications.strDegree = Reg_Specializations.strDegree AND Reg_Applications.strSpecialization = Reg_Specializations.strSpecialization INNER JOIN Lkp_Nationalities ON Reg_Students_Data.byteNationality = Lkp_Nationalities.byteNationality where Reg_Applications.lngStudentNumber='" + studentid + "'", connStr);
            return dt;
        }

        public DataTable GetStudentDetailsForProfile(string studentid, string connStr)
        {
            DataTable dt = GetData("SELECT Reg_Applications.byteCancelReason,Reg_Applications.iAcceptanceType,Reg_Applications.iAcceptanceCondition,Reg_Applications.lngStudentNumber, Reg_Students_Data.strLastDescEn, Reg_Specializations.strCaption, dbo.CleanPhone(Reg_Students_Data.strPhone1) AS Phone, Reg_Students_Data.sECTemail, Reg_Applications.byteCancelReason,Reg_Applications.intGraduationYear,Reg_Applications.byteGraduationSemester,  Reg_Students_Data.strNationalID, Lkp_Nationalities.strNationalityDescEn, Reg_Students_Data.dateBirth,Reg_Students_Data.lngSerial, Reg_Students_Data.lngStudentNumber, Reg_Students_Data.iUnifiedID, Reg_Students_Data.strStudentPic  FROM Reg_Applications INNER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial INNER JOIN Reg_Specializations ON Reg_Applications.strCollege = Reg_Specializations.strCollege AND Reg_Applications.strDegree = Reg_Specializations.strDegree AND Reg_Applications.strSpecialization = Reg_Specializations.strSpecialization INNER JOIN Lkp_Nationalities ON Reg_Students_Data.byteNationality = Lkp_Nationalities.byteNationality where Reg_Applications.lngStudentNumber='" + studentid + "'", connStr);
            return dt;
        }

        public DataTable GetCoursesbyStudentId(string studentid, string connStr,int year,int sem)
        {//SELECT        Course_Balance_View_BothSides.iYear, Course_Balance_View_BothSides.Sem, Course_Balance_View_BothSides.Student, Course_Balance_View_BothSides.Course AS Code, Course_Balance_View_BothSides.Course + N'-' + Reg_Courses.strCourseDescEn AS Course, Reg_Lecturers.strLecturerDescEn, Reg_CourseTime_Schedule.bLab FROM Course_Balance_View_BothSides INNER JOIN Reg_Courses ON Course_Balance_View_BothSides.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule ON Course_Balance_View_BothSides.iYear = Reg_CourseTime_Schedule.intStudyYear AND Course_Balance_View_BothSides.Sem = Reg_CourseTime_Schedule.byteSemester AND Course_Balance_View_BothSides.Course = Reg_CourseTime_Schedule.strCourse AND Course_Balance_View_BothSides.Class = Reg_CourseTime_Schedule.byteClass AND                         Course_Balance_View_BothSides.Shift = Reg_CourseTime_Schedule.byteShift INNER JOIN                        Reg_Lecturers ON Reg_CourseTime_Schedule.intLecturer = Reg_Lecturers.intLecturer WHERE        (Course_Balance_View_BothSides.iYear = "+year+") AND (Course_Balance_View_BothSides.Sem = "+sem+") AND (Course_Balance_View_BothSides.Student = N'"+studentid+"') AND (Reg_CourseTime_Schedule.bLab = 0) AND (Course_Balance_View_BothSides.Course <> N'ESL_Gen')
            DataTable dt = GetData("SELECT        Course_Balance_View_BothSides.iYear, Course_Balance_View_BothSides.Sem, Course_Balance_View_BothSides.Student, Course_Balance_View_BothSides.Course AS Code, Course_Balance_View_BothSides.Course + N'-' + Reg_Courses.strCourseDescEn AS Course, Reg_Lecturers.strLecturerDescEn, Reg_CourseTime_Schedule.bLab FROM Course_Balance_View_BothSides INNER JOIN Reg_Courses ON Course_Balance_View_BothSides.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule ON Course_Balance_View_BothSides.iYear = Reg_CourseTime_Schedule.intStudyYear AND Course_Balance_View_BothSides.Sem = Reg_CourseTime_Schedule.byteSemester AND Course_Balance_View_BothSides.Course = Reg_CourseTime_Schedule.strCourse AND Course_Balance_View_BothSides.Class = Reg_CourseTime_Schedule.byteClass AND                         Course_Balance_View_BothSides.Shift = Reg_CourseTime_Schedule.byteShift INNER JOIN                        Reg_Lecturers ON Reg_CourseTime_Schedule.intLecturer = Reg_Lecturers.intLecturer WHERE        (Course_Balance_View_BothSides.iYear = " + year + ") AND (Course_Balance_View_BothSides.Sem = " + sem + ") AND (Course_Balance_View_BothSides.Student = N'" + studentid + "') AND (Reg_CourseTime_Schedule.bLab = 0) AND (Course_Balance_View_BothSides.Course <> N'ESL_Gen')", connStr);
            //DataTable dt = GetData("SELECT  Course_Balance_View_BothSides.iYear, Course_Balance_View_BothSides.Sem, Course_Balance_View_BothSides.Student, Course_Balance_View_BothSides.Course AS Code, Course_Balance_View_BothSides.Course + N'-' + Reg_Courses.strCourseDescEn AS Course, Reg_Lecturers.strLecturerDescEn FROM            Course_Balance_View_BothSides INNER JOIN Reg_Courses ON Course_Balance_View_BothSides.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule ON Course_Balance_View_BothSides.iYear = Reg_CourseTime_Schedule.intStudyYear AND Course_Balance_View_BothSides.Sem = Reg_CourseTime_Schedule.byteSemester AND Course_Balance_View_BothSides.Course = Reg_CourseTime_Schedule.strCourse INNER JOIN Reg_Lecturers ON Reg_CourseTime_Schedule.intLecturer = Reg_Lecturers.intLecturer WHERE        (Course_Balance_View_BothSides.iYear = " + year + ") AND (Course_Balance_View_BothSides.Sem = " + sem + ") AND (Course_Balance_View_BothSides.Student = N'" + studentid + "') AND (Reg_CourseTime_Schedule.bLab = 0)", connStr);
            return dt;
        }

        public DataTable GetSemestersbyTerm(int year, int sem)
        {
            int term = (year * 10) + sem;
            DataTable dt = GetData("SELECT  top 4   AcademicYear, Semester, LongDesc, AcademicYear * 10 + Semester AS Term FROM Reg_Semester where term<="+term+" ORDER BY AcademicYear DESC, Semester DESC");
            return dt;
        }

        public DataTable GetCoursesbyCourseId(string studentid, string connStr, int year, int sem,string courseid)
        {
            //DataTable dt = GetData("SELECT  Course_Balance_View_BothSides.iYear, Course_Balance_View_BothSides.Sem, Course_Balance_View_BothSides.Student, Course_Balance_View_BothSides.Course AS Code, Course_Balance_View_BothSides.Course + N'-' + Reg_Courses.strCourseDescEn AS Course, Reg_Lecturers.strLecturerDescEn FROM            Course_Balance_View_BothSides INNER JOIN Reg_Courses ON Course_Balance_View_BothSides.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule ON Course_Balance_View_BothSides.iYear = Reg_CourseTime_Schedule.intStudyYear AND Course_Balance_View_BothSides.Sem = Reg_CourseTime_Schedule.byteSemester AND Course_Balance_View_BothSides.Course = Reg_CourseTime_Schedule.strCourse INNER JOIN Reg_Lecturers ON Reg_CourseTime_Schedule.intLecturer = Reg_Lecturers.intLecturer WHERE        (Course_Balance_View_BothSides.iYear = " + year + ") AND (Course_Balance_View_BothSides.Sem = " + sem + ") AND (Course_Balance_View_BothSides.Student = N'" + studentid + "') AND (Reg_CourseTime_Schedule.bLab = 0) AND Course_Balance_View_BothSides.Course='"+courseid+"' ", connStr);
            DataTable dt = GetData("SELECT        Course_Balance_View_BothSides.iYear, Course_Balance_View_BothSides.Sem, Course_Balance_View_BothSides.Student, Course_Balance_View_BothSides.Course AS Code, Course_Balance_View_BothSides.Course + N'-' + Reg_Courses.strCourseDescEn AS Course, Reg_Lecturers.strLecturerDescEn, Reg_CourseTime_Schedule.bLab FROM Course_Balance_View_BothSides INNER JOIN Reg_Courses ON Course_Balance_View_BothSides.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule ON Course_Balance_View_BothSides.iYear = Reg_CourseTime_Schedule.intStudyYear AND Course_Balance_View_BothSides.Sem = Reg_CourseTime_Schedule.byteSemester AND Course_Balance_View_BothSides.Course = Reg_CourseTime_Schedule.strCourse AND Course_Balance_View_BothSides.Class = Reg_CourseTime_Schedule.byteClass AND                         Course_Balance_View_BothSides.Shift = Reg_CourseTime_Schedule.byteShift INNER JOIN                        Reg_Lecturers ON Reg_CourseTime_Schedule.intLecturer = Reg_Lecturers.intLecturer WHERE        (Course_Balance_View_BothSides.iYear = " + year + ") AND (Course_Balance_View_BothSides.Sem = " + sem + ") AND (Course_Balance_View_BothSides.Student = N'" + studentid + "') AND (Reg_CourseTime_Schedule.bLab = 0) AND (Course_Balance_View_BothSides.Course <> N'ESL_Gen') AND Course_Balance_View_BothSides.Course='" + courseid+"' ", connStr);
            return dt;
        }

        public DataTable GetMajors(string connStr)
        {
            DataTable dt = GetData("SELECT distinct(strCaption) FROM Reg_Specializations WHERE (bAvailable = 1) and strCaption not in ('Diploma in Public Relations','Visiting Students') ORDER BY strCaption asc",connStr);
            return dt;
        }

        public DataTable GetStudentAcademicAdvisor(string studentid, string connStr)
        {
            DataTable dt = GetData("SELECT Reg_Applications.lngStudentNumber, Reg_Lecturers.strLecturerDescEn FROM Reg_Applications LEFT OUTER JOIN Reg_Lecturers ON Reg_Applications.intAdvisor = Reg_Lecturers.intLecturer WHERE Reg_Applications.lngStudentNumber='" + studentid + "'", connStr);
            return dt;
        }

        public DataTable GetMainReasons()
        {
            DataTable dt = GetData("SELECT [byteMainReason],[strMainReasonEn],[strMainReasonAr], ISNULL([strMainReasonEn],'') + ' (' + ISNULL([strMainReasonAr],'')+' )' as MainReason FROM [ECTData].[dbo].[Lkp_MainReasons] where byteMainReason !=0");
            return dt;
        }

        public DataTable GetSubReasons(int MainReasonId)
        {
            DataTable dt = GetData("SELECT byteMainReason, byteSubReson,ISNULL(strSubReasonEn,'') + ' (' + ISNULL(strSubReasonAr,'')+' )' as SubReason FROM Lkp_SubReasons where byteSubReson!=0 and byteMainReason="+ MainReasonId + "");
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