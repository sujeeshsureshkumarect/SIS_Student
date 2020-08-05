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
using System.Collections.Generic;
//using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for Advising
/// </summary>
/// 
public class Advised
{
    public struct Courses
    {
        public int iOrder;
        public string sCourse;
        public string sDesc;
        public int iShift;
        public byte bClass;
        public bool isOver;
        public bool isLow;
        public int[] iTimes;
    }
}
public class Advising
{
    public Advising()
    {

    }

    public List<MirrorCLS> GetAdvising(string sNo, bool isIncluded, int Year, int Semester, bool isRegisteredPassed, bool isHidden, out Plans Plan, InitializeModule.EnumCampus Campus)
    {
        List<MirrorCLS> myMirror = new List<MirrorCLS>();
        MirrorDAL myMirrorDAL = new MirrorDAL();
        //Plans Plan;
        Plan = new Plans();
        try
        {
            string sCollege = "";
            string sDegree = "";
            string sMajor = "";
            string sCondition = "";

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

            List<Applications> myStudent = new List<Applications>();
            ApplicationsDAL myApplicationsDAL = new ApplicationsDAL();
            myStudent = myApplicationsDAL.GetList(Campus, " lngStudentNumber='" + sNo + "'", false);
            if (myStudent.Count > 0)
            {
                sCollege = myStudent[0].strCollege;
                sDegree = myStudent[0].strDegree;
                sMajor = myStudent[0].strSpecialization;
            }
            myMirror = myMirrorDAL.GetMirrorForAdvising(sCollege, sDegree, sMajor, 0, sNo, 0, out Plan, Campus, true);

            #region "Fill Elective Grades Courses"
            for (int i = 0; i < myMirror.Count; i++)
            {
                ArrayList GradeElect = new ArrayList();

                string SqlElect = "SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder ";
                SqlElect += " FROM Web_Max_Ellective ";
                SqlElect += " WHERE strCollege='" + sCollege + "' AND strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "' AND sStudentNumber='" + myMirror[i].StudentNumber + "'";
                SqlElect += " AND (intCourseClass =2 or intCourseClass=9)";
                SqlElect += " Union ";
                SqlElect += " SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder";
                SqlElect += " FROM Web_Ellective_No_Grades ";
                SqlElect += " WHERE strCollege='" + sCollege + "' AND strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "' AND sStudentNumber='" + myMirror[i].StudentNumber + "'";
                SqlElect += " AND (intCourseClass =2 or intCourseClass=9)";
                SqlElect += " ORDER BY lngSerial, byteOrder";


                SqlCommand Cmd = new SqlCommand(SqlElect, Conn);
                Conn.Open();
                SqlDataReader RdElect = Cmd.ExecuteReader();

                while (RdElect.Read())
                {
                    GradeElect.Add(RdElect["sGrade"].ToString());
                }
                RdElect.Close();
                Conn.Close();
                if (GradeElect.Count > 0)
                {
                    for (int j = 0; j < myMirror[i].Mirror.Length; j++)
                    {
                        if (myMirror[i].Mirror[j].sCourse == "ELECT1" || myMirror[i].Mirror[j].sCourse == "MELECT1")
                            myMirror[i].Mirror[j].sGrade = GradeElect[0].ToString();
                        if ((myMirror[i].Mirror[j].sCourse == "ELECT2" || myMirror[i].Mirror[j].sCourse == "MELECT2") && GradeElect.Count > 1)
                            myMirror[i].Mirror[j].sGrade = GradeElect[1].ToString();
                        if ((myMirror[i].Mirror[j].sCourse == "MELECT3") && GradeElect.Count > 2)
                            myMirror[i].Mirror[j].sGrade = GradeElect[2].ToString();
                    }
                }
            }
            #endregion

            #region "Fill Core Elective Grades Courses"
            for (int i = 0; i < myMirror.Count; i++)
            {
                ArrayList GradeElect = new ArrayList();

                string SqlElect = "SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder ";
                SqlElect += " FROM Web_Max_Ellective ";
                SqlElect += " WHERE strCollege='" + sCollege + "' AND strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "' AND sStudentNumber='" + myMirror[i].StudentNumber + "'";
                SqlElect += " AND intCourseClass =11";
                SqlElect += " Union ";
                SqlElect += " SELECT lngSerial,sStudentNumber,sCourse,sGrade,bPassIt,byteOrder";
                SqlElect += " FROM Web_Ellective_No_Grades ";
                SqlElect += " WHERE strCollege='" + sCollege + "' AND strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "' AND sStudentNumber='" + myMirror[i].StudentNumber + "'";
                SqlElect += " AND intCourseClass =11";
                SqlElect += " ORDER BY lngSerial, byteOrder";


                SqlCommand Cmd = new SqlCommand(SqlElect, Conn);
                Conn.Open();
                SqlDataReader RdElect = Cmd.ExecuteReader();

                while (RdElect.Read())
                {
                    GradeElect.Add(RdElect["sGrade"].ToString());
                }
                RdElect.Close();
                Conn.Close();
                if (GradeElect.Count > 0)
                {
                    for (int j = 0; j < myMirror[i].Mirror.Length; j++)
                    {
                        if (myMirror[i].Mirror[j].sCourse == "CELECT1")
                            myMirror[i].Mirror[j].sGrade = GradeElect[0].ToString();
                        if ((myMirror[i].Mirror[j].sCourse == "CELECT2") && GradeElect.Count > 1)
                            myMirror[i].Mirror[j].sGrade = GradeElect[1].ToString();
                        if ((myMirror[i].Mirror[j].sCourse == "CELECT3") && GradeElect.Count > 2)
                            myMirror[i].Mirror[j].sGrade = GradeElect[2].ToString();
                        if ((myMirror[i].Mirror[j].sCourse == "CELECT4") && GradeElect.Count > 3)
                            myMirror[i].Mirror[j].sGrade = GradeElect[3].ToString();
                        if ((myMirror[i].Mirror[j].sCourse == "CELECT5") && GradeElect.Count > 4)
                            myMirror[i].Mirror[j].sGrade = GradeElect[4].ToString();
                        if ((myMirror[i].Mirror[j].sCourse == "CELECT6") && GradeElect.Count > 5)
                            myMirror[i].Mirror[j].sGrade = GradeElect[5].ToString();
                    }
                }
            }
            #endregion
            decimal CGPA = myMirror[0].CGPA;
            bool isAccWanted = myMirror[0].IsAccWanted;
            //bool isHidden = false;

            myMirror[0].Major = Plan.SDisplay;
            myMirror[0].SDegree = sDegree;
            myMirror[0].SMajor = sMajor;
            //Include Recommended Courses
            int iPreFounded = 0;
            int iPre = 0;
            int iPreIndex = 0;
            int iHours = 0;
            int iCredit = 0;
            bool isPassed = false;
            int iSemMax = 0;


            isPassed = LibraryMOD.isENGPassed((float)myMirror[0].Score, myMirror[0].ENG, sDegree, sMajor);
            iSemMax = LibraryMOD.GetMaxHours(Semester, myMirror[0].IsENGRequired, isPassed, myMirror[0].MaxESL, (float)myMirror[0].CGPA, sDegree, sMajor);

            ////MCPR Arabic with TOEFL
            //if (sDegree == "1" && sMajor == "24")
            //{
            //    iSemMax = LibraryMOD.GetMaxHours(Semester, myMirror[0].IsENGRequired, isPassed, myMirror[0].MaxESL, (float)myMirror[0].CGPA,sDegree,sMajor);
            //}
            ////MCPR Arabic without TOEFL                
            //else if ((sDegree == "1" && sMajor == "25") || (sDegree == "3" && sMajor == "21"))
            //{
            //    isPassed = false;
            //    //iSemMax = 12;
            //    iSemMax = LibraryMOD.GetMaxHours(Semester, myMirror[0].IsENGRequired, isPassed, myMirror[0].MaxESL, (float)myMirror[0].CGPA, sDegree, sMajor);
            //}
            ////Other Majors
            //else
            //{               
            //}            

            myMirror[0].Recommended = new List<Advised.Courses>();
            if (isIncluded)
            {
                bool isToeflPassed = LibraryMOD.isENGPassed(float.Parse(myMirror[0].Score.ToString()), myMirror[0].ENG, myMirror[0].SDegree, myMirror[0].SMajor);
                bool isToeflRequired = myMirror[0].IsENGRequired;
                Advised.Courses Rec;
                int iShift = myMirror[0].IPeriod;
                bool isExempted = false;
                isExempted = ((myMirror[0].SDegree == "1" && myMirror[0].SMajor == "24") || (myMirror[0].SDegree == "3" && myMirror[0].SMajor == "4") || (myMirror[0].SDegree == "3" && myMirror[0].SMajor == "5") || (myMirror[0].SDegree == "3" && myMirror[0].SMajor == "6") || (myMirror[0].SDegree == "2" && myMirror[0].SMajor == "2"));
                //Add ESLs--This is what Available execludes the foundation students
                if (isToeflRequired && !isToeflPassed && isExempted == false)
                {
                    Rec = new Advised.Courses();
                    Rec.iOrder = 0;
                    Rec.isOver = false;
                    Rec.isLow = false;
                    Rec.sCourse = "ESL_Gen";
                    Rec.sDesc = "English as a second language - General";
                    Rec.iShift = iShift;
                    myMirror[0].Recommended.Add(Rec);
                }
                bool isRecommended = false;
                bool isRegistered = false;
                isPassed = false;
                bool isLow = false;
                int iOrder = 0;
                bool isAvailable = false;
                bool isEmpty = false;
                bool isOver = false;
                bool isWEW = false;
                int iAlternativeCourses = 6;
                if (Semester >= 3)
                {
                    iAlternativeCourses = 6;
                }

                for (int i = 0; i < Plan.Courses.Count; i++)
                {
                    isRecommended = false;
                    isRegistered = false;
                    isPassed = false;
                    isLow = false;
                    isEmpty = false;
                    isWEW = false;

                    //is Registered Courses Considered as Passed Courses
                    //|| myMirror[0].Mirror[i].sGrade == "@S1" || myMirror[0].Mirror[i].sGrade == "@S2"

                    //Current Semester Reg Cosidered as Passed
                    string sCSemester = "@W";
                    //if reg year semester > current semester
                    switch (Semester)
                    {
                        case 1:
                            sCSemester = "@S2";
                            break;
                        case 2:
                            sCSemester = "@F";
                            break;
                        case 3:
                            sCSemester = "@W";
                            break;
                        case 4:
                            sCSemester = "@S1";
                            break;
                    }

                    isRegistered = (myMirror[0].Mirror[i].sGrade.Contains(sCSemester) == true);
                    bool isShown = (myMirror[0].Mirror[i].sGrade.Contains("@") == true);
                    if (isRegisteredPassed)
                    {
                        isPassed = (myMirror[0].Mirror[i].isPassed || isRegistered);
                    }
                    else
                    {
                        isPassed = (myMirror[0].Mirror[i].isPassed);
                    }
                    //Must Repeate 6 Credit of F & D at least
                    isLow = ((myMirror[0].Mirror[i].sGrade == "D" || myMirror[0].Mirror[i].sGrade == "F") && CGPA < 2);
                    string sCourse = myMirror[0].Mirror[i].sCourse;
                    isRecommended = ((!isPassed) || (isLow));
                    isEmpty = (myMirror[0].Mirror[i].sGrade == ".");
                    //Hide mark if there is fainancial problem
                    //if it is EW OR W then should be shown
                    isWEW = (myMirror[0].Mirror[i].sGrade == "W" || myMirror[0].Mirror[i].sGrade == "EW");
                    if (isAccWanted || isHidden)
                    {
                        //if (!isRegistered && !isRecommended && ! isEmpty)
                        if (!isShown && !isEmpty && !isWEW)
                        {
                            myMirror[0].Mirror[i].sGrade = "*";
                        }
                    }

                    //Must Tracked Every Year

                    isAvailable = LibraryMOD.isCourseAvailable(Year, Semester, myMirror[0].Mirror[i].sCourse, Campus);
                    //isAvailable = true;

                    iCredit = myMirror[0].Mirror[i].iCredit;
                    isOver = (iHours + iCredit > iSemMax);
                    //Execlude ESL FROM Recomended && myMirror[0].Mirror[i].sCourse.Substring(0,3)!="ESL"

                    if (isRecommended && isAvailable && (iHours + iCredit <= (iSemMax + iAlternativeCourses)))//add 3 course as alternative
                    {
                        //Not Registered

                        iPreFounded = 0;
                        iPre = Plan.Courses[i].iPre.Count;

                        for (int j = 0; j < iPre; j++)
                        {
                            iPreIndex = Plan.Courses[i].iPre[j] - 1;
                            if (isRegisteredPassed)
                            {
                                if ((myMirror[0].Mirror[iPreIndex].isPassed == true) || (myMirror[0].Mirror[iPreIndex].sGrade.Contains(sCSemester) == true))
                                {
                                    iPreFounded++;
                                }
                            }
                            else
                            {
                                if (myMirror[0].Mirror[iPreIndex].isPassed == true)
                                {
                                    iPreFounded++;
                                }
                            }

                        }

                        if (iPreFounded == iPre)
                        {
                            //if (iHours + myMirror[0].Mirror[i].iCredit <= iSemMax)
                            //{
                            iOrder++;
                            myMirror[0].Mirror[i].isRecommended = true;
                            iHours += iCredit;
                            Rec = new Advised.Courses();
                            Rec.iOrder = iOrder;
                            Rec.isOver = isOver;
                            Rec.isLow = isLow;
                            Rec.sCourse = myMirror[0].Mirror[i].sCourse;

                            Rec.sDesc = Plan.Courses[i].sDesc;
                            Rec.iShift = iShift;
                            myMirror[0].Recommended.Add(Rec);

                            //removed by bahaa 30-01-2020 dont force to recommend corequisiste 
                            //if (Plan.Courses[i].sParallel != "-" )
                            //{
                            //    iOrder++;
                            //    Rec = new Advised.Courses();
                            //    Rec.iOrder = iOrder;
                            //    Rec.sCourse = Plan.Courses[i].sParallel;
                            //    Rec.sDesc = Plan.Courses[i + 1].sDesc; 
                            //    Rec.iShift = iShift;
                            //    Rec.isOver = isOver;
                            //    Rec.isLow = isLow;
                            //    myMirror[0].Recommended.Add(Rec);

                            //}

                            //}
                        }
                        //if (iHours == iSemMax)
                        //{
                        //    return myMirror;
                        //}

                    }

                }

            }


        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);

        }
        finally
        {


        }
        return myMirror;

    }


    public List<Advised.Courses> Advise(int Year, int Semester, int iShift, string sNo, string sCollege, string sDegree, string sMajor, bool isRegisteredPassed, decimal CGPA, int iSemMax, StudentCourses.StudentMirror[] myMirror, InitializeModule.EnumCampus Campus)
    {
        List<Advised.Courses> myAdvise = new List<Advised.Courses>();

        List<Plans> myPlans = new List<Plans>();
        PlansDAL myPlansDAL = new PlansDAL();
        Plans myPlan = new Plans();
        try
        {

            myPlans = myPlansDAL.GetPlans(sCollege, sDegree, sMajor, true, Campus);
            myPlan = myPlans[0];

            int iPreFounded = 0;
            int iPre = 0;
            int iPreIndex = 0;
            int iHours = 0;
            int iCredit = 0;
            bool isPassed = false;
            bool isRecommended = false;
            bool isRegistered = false;
            bool isLow = false;
            Advised.Courses Rec;
            int iOrder = 0;
            bool isEmpty = false;
            bool isOver = false;

            for (int i = 0; i < myPlan.Courses.Count; i++)
            {
                isRecommended = false;
                isRegistered = false;
                isPassed = false;
                isLow = false;
                isEmpty = false;

                string sCSemester = "@W";

                switch (Semester)
                {
                    case 1:
                        sCSemester = "@S2";
                        break;
                    case 2:
                        sCSemester = "@F";
                        break;
                    case 3:
                        sCSemester = "@W";
                        break;
                    case 4:
                        sCSemester = "@S1";
                        break;
                }
                //is Registered Courses Considered as Passed Courses
                isRegistered = (myMirror[i].sGrade.Contains(sCSemester) == true);

                if (isRegisteredPassed)
                {
                    isPassed = (myMirror[i].isPassed || isRegistered);
                }
                else
                {
                    isPassed = (myMirror[i].isPassed);
                }
                myMirror[i].isPassed = isPassed;

                //Must Repeate 6 Credit of F & D at least
                isLow = ((myMirror[i].sGrade == "D" || myMirror[i].sGrade == "F") && CGPA < 2);
                isRecommended = ((!isPassed) || (isLow));
                isEmpty = (myMirror[i].sGrade == ".");

                iCredit = myMirror[i].iCredit;
                isOver = (iHours + iCredit > iSemMax);
                if (isRecommended && (iHours + iCredit <= (iSemMax + 6)))//changed to 1 for summer//add 3 course as alternative
                {
                    //Not Registered

                    iPreFounded = 0;
                    iPre = myPlan.Courses[i].iPre.Count;

                    for (int j = 0; j < iPre; j++)
                    {
                        iPreIndex = myPlan.Courses[i].iPre[j] - 1;
                        if (myMirror[iPreIndex].isPassed == true)
                        {
                            iPreFounded++;
                        }
                    }

                    if (iPreFounded == iPre)
                    {
                        iOrder++;
                        myMirror[i].isRecommended = true;
                        iHours += iCredit;
                        Rec = new Advised.Courses();
                        Rec.iOrder = iOrder;
                        Rec.isOver = isOver;
                        Rec.isLow = isLow;
                        Rec.sCourse = myMirror[i].sCourse;

                        Rec.sDesc = myPlan.Courses[i].sDesc;
                        Rec.iShift = iShift;
                        myAdvise.Add(Rec);
                        //removed by bahaa 29-01-2020 dont force to recommend the corequisiste courses

                        //if (myPlan.Courses[i].sParallel != "-")
                        //{
                        //    iOrder++;
                        //    Rec = new Advised.Courses();
                        //    Rec.iOrder = iOrder;
                        //    Rec.sCourse = myPlan.Courses[i].sParallel;
                        //    Rec.sDesc = myPlan.Courses[i + 1].sDesc;
                        //    Rec.iShift = iShift;
                        //    Rec.isOver = isOver;
                        //    Rec.isLow = isLow;
                        //    myAdvise.Add(Rec);
                        //    i = 4;
                        //}

                    }


                }

            }




        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);

        }
        finally
        {
            myPlans.Clear();
        }
        return myAdvise;

    }



    //List<MirrorCLS> GetMirrorForAdvising
}
