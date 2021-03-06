﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;

public class RegValidation
{
    private int CurrentRole = 0;
    private InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
    private MirrorCLS myMirror = null;
    private Plans myPlan = null;
    private string sCourse = "";
    private int iStudyYear = 0;
    private int iSemester = 0;
    public int iCurrentCR = 0;
    public double iTotal = 0.0;
    public int iMaxESL = 0;
    private int iShift = 0;
    private int iClass = 0;

    List<CourseTimes> myCreditHoursTimes = new List<CourseTimes>();

    //validation error message
    private string sErrorMessage = "<b><u>Error in registration:</u></b>";

    public string ErrorMessage
    {
        get { return sErrorMessage; }
        set { sErrorMessage = value; }
    }

    public struct CourseTimes
    {
        public DateTime TimeFrom;
        public DateTime TimeTo;
        public int Day;
    }
    public RegValidation()
    {

    }

    public RegValidation(InitializeModule.EnumCampus Campus, int CurrentRole, MirrorCLS myMirror, Plans myPlan, string sCourse, int iStudyYear, int iSemester, int iShift, int iClass)
    {
        this.CurrentRole = CurrentRole;
        this.Campus = Campus;
        this.myMirror = myMirror;
        this.myPlan = myPlan;
        this.sCourse = sCourse;
        this.iStudyYear = iStudyYear;
        this.iSemester = iSemester;
        //this.iTotal = iTotal;
        this.iShift = iShift;
        this.iClass = iClass;
    }

    public bool validate(System.Web.UI.Page page, int iRegYear, int iRegSem)
    {
        int iErrorCounter = 0;
        bool isValid = false;
        int iMaxESL = this.myMirror.MaxESL;
        //ESL 50%
        bool is50 = sCourse.Contains("%");
        bool isESL = sCourse.Contains("ESL");

        string sReturn = "";

        MirrorDAL myMirrorDAL = new MirrorDAL();

        int iMElective = myMirrorDAL.GetMajorElectiveCoursesCount(myMirror.StudentNumber, Campus);
        int iFElective = myMirrorDAL.GetFreeElectiveCoursesCount(myMirror.StudentNumber, Campus);

        if (isESL && isESLRegistered())
        {
            iErrorCounter++;
            this.ErrorMessage += "<br />*ESL is already registered";
        }
        if (!isESL)
        {
            //&& iMaxESL < 4  Canceled
            if (isESLRequired(out sReturn) && !isESLRegistered() && this.myMirror.StudentNumber.Substring(0, 1) != "F")
            {
                iErrorCounter++;
                this.ErrorMessage += "<br />*You should register " + sReturn + " first";
            }
        }
        //Is must register MTH001
        bool isMTH001 = sCourse.Contains("MTH001");
        bool isCHEM001 = sCourse.Contains("CHEM001");
        bool isBIOL001 = sCourse.Contains("BIOL001");
        bool isPHYS001 = sCourse.Contains("PHYS001");

        bool IsMTH001Required = false;
        bool IsCHEM001Required = false;
        bool IsBIOL001Required = false;
        bool IsPHYS001Required = false;
        string sFndCourse = "";
        //if (isFNDCoursesRequired(myMirror.StudentNumber, out IsMTH001Required, out IsCHEM001Required, out IsBIOL001Required, out IsPHYS001Required))
        if (AdmissionRequirments.IsFulfilledAdmissionRequirements(Campus, myMirror.StudentNumber, out IsMTH001Required, out IsCHEM001Required, out IsBIOL001Required, out IsPHYS001Required))
        {
            sFndCourse = "MTH001";
            if (!isMTH001 && IsMTH001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Math less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
            sFndCourse = "CHEM001";
            if (!isCHEM001 && IsCHEM001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Chemistry less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
            sFndCourse = "BIOL001";
            if (!isBIOL001 && IsBIOL001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Biology less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
            sFndCourse = "PHYS001";
            if (!isPHYS001 && IsPHYS001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Physics less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
        }
        //if (is50)
        //{
        //    sCourse = sCourse.Substring(0, 6);
        //}



        int iSelectedCourseCR = 0;
        double iRegisteredCoursesCR = LibraryMOD.GetStudentRegisteredCredit(this.iStudyYear, iSemester, this.myMirror.StudentNumber, (int)this.Campus);

        if (!is50)
        {
            if (isCourseTimeConflicts(out iSelectedCourseCR))
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                InitializeModule.enumPrivilege.SkipTimeConflict, CurrentRole) != true)
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Course time conflict.";
                }
                else
                {
                    page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('There is a course time conflict, but you passed it because you have the privilege.');", true);

                }

            }
        }

        this.iCurrentCR = iSelectedCourseCR;
        this.iTotal = iRegisteredCoursesCR;
        float CGPA = float.Parse(this.myMirror.CGPA.ToString());
        bool isToeflRequired = this.myMirror.IsENGRequired;
        float Score = float.Parse(this.myMirror.Score.ToString());
        bool isToeflPassed = LibraryMOD.isENGPassed(Score, this.myMirror.ENG, this.myMirror.SDegree, this.myMirror.SMajor);

        //int iRegCoursesPrevSem = 0;

        //if (iRegSem == 4)
        //{   
        //    iRegCoursesPrevSem = LibraryMOD.GetRegCoursesPrevSem(myMirror.StudentNumber, iRegYear, iRegSem, this.Campus);
        //}

        int iHours = LibraryMOD.GetMaxHours(iSemester, isToeflRequired, isToeflPassed, iMaxESL, CGPA, this.myMirror.SDegree, this.myMirror.SMajor);
        if (!((iTotal + iCurrentCR) <= iHours))
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
            InitializeModule.enumPrivilege.SkipAcademicLoad, CurrentRole) != true)
            {
                iErrorCounter++;
                this.ErrorMessage += "<br />*Registered courses credit hours exceed semester limit.";
            }
            else
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Credit hours exceeded, but you passed it because you have the privilege.');", true);
            }

        }

        //if Two Summers

        if (iSemester > 2)
        {
            //max two courses each summer semester
            //if (!((iTotal + iCurrentCR) <= 6))
            //{
            //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
            //InitializeModule.enumPrivilege.SkipAcademicLoad, CurrentRole) != true)
            //{
            //iErrorCounter++;
            //this.ErrorMessage += "<br />*Registered courses credit hours exceed semester limit.";
            //}
            //else
            //{
            //    page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Credit hours exceeded semester limit, but you passed it because you have the privilege.');", true);
            //}
            //}
            int iSummers = LibraryMOD.GetSummersHours(this.iStudyYear, this.myMirror.StudentNumber, Campus);

            if (!((iSummers + iCurrentCR) <= 12))
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                InitializeModule.enumPrivilege.SkipAcademicLoad, CurrentRole) != true)
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Registered courses credit hours exceed the two summers limit.";
                }
                else
                {
                    page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Credit hours exceeded the two summers limit, but you passed it because you have the privilege.');", true);
                }

            }

        }

        //if (!this.isAddingCreditAllowed(iRegYear, iRegSem))
        //{
        //    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
        //    InitializeModule.enumPrivilege.SkipAddingCreditNotAllowed, CurrentRole) != true)
        //    {
        //        iErrorCounter++;
        //        this.ErrorMessage += "<br />*Adding credit hours is not allowed.";
        //    }
        //    else
        //    {
        //        page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Adding credit hours was not allowed, but you passed it because you have the privilege.');", true);
        //    }

        //}

        //free elective courses - not in major plan and not major elective ourse
        if (!isCourseInPlan() && !is50)
        {

            //major elective
            if (isMajorElectiveCourse(sCourse, myMirror.SDegree, myMirror.SMajor) != false)
            {
                if (iMElective > 2)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.SkipMaxMajorElective, CurrentRole) != true)
                    {
                        iErrorCounter++;
                        this.ErrorMessage += "<br />*You already registered maximum major elective courses.";
                    }
                    else
                    {
                        page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('You already registered maximum major elective courses.');", true);
                    }


                }
            }
            else
            { //free elective
                if (iFElective > 2)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.SkipMaxFreeElective, CurrentRole) != true)
                    {
                        iErrorCounter++;
                        this.ErrorMessage += "<br />*You already registered maximum allowed of free elective courses.";
                    }
                    else
                    {
                        page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('You already registered maximum allowed of free elective courses.');", true);
                    }

                }
            }
        }

        if (!this.isCourseInPlan() && !is50 && !isESL)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
            InitializeModule.enumPrivilege.SkipAcademicLoad, CurrentRole) != true)
            {
                iErrorCounter++;
                this.ErrorMessage += "<br />*Course is not in student\"s plan.";

                //isCourseElective

            }
            else
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Course is not in student\"s plan, but you passed it because you have the privilege.');", true);

            }

        }

        else
        {
            if (this.isCourseRegistered())
            {
                iErrorCounter++;
                this.ErrorMessage += "<br />*Course is already registered.";
            }

            if (!is50 && !isESL)
            {
                if (!this.isPrerequisitePassed(iRegSem))
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                    InitializeModule.enumPrivilege.SkipPrerequisite, CurrentRole) != true)
                    {
                        iErrorCounter++;
                        this.ErrorMessage += "<br />*Course prerequisite(s) are not passed.";
                    }
                    else
                    {
                        page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Course prerequisite(s) are not passed, but you passed it because you have the privilege.');", true);
                    }

                }
                if (!this.isCorequisites_Registered())
                {
                    //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                    //InitializeModule.enumPrivilege.SkipPrerequisite, CurrentRole) != true)
                    //{
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Course co-requisite is not registered.";
                    //}
                    //else
                    //{
                    //    page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Course prerequisite(s) are not passed, but you passed it because you have the privilege.');", true);
                    //}

                }
                if (!this.isCourseRegisterable())
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                    InitializeModule.enumPrivilege.AllowRepeatPassedCoursesNot_D, CurrentRole) != true)
                    {
                        iErrorCounter++;
                        this.ErrorMessage += "<br />*Course is passed with a grade that is not D";
                    }
                    else
                    {

                        page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Course is passed with a grade that is not D, but you passed it because you have the privilege.');", true);
                    }

                }
            }
            if (this.isClassFull())
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                InitializeModule.enumPrivilege.SkipMaxCapacity, CurrentRole) != true || LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                InitializeModule.enumPrivilege.SkipHallCapacity, CurrentRole) != true)
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Class is full.";
                }
                else
                {
                    page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Class is full, but you passed it because you have the privilege.');", true);
                }

            }
        }

        string sMsg = "";
        if (this.isInactiveOrHasFinanceProblems(iRegYear, iRegSem,out sMsg))
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
              InitializeModule.enumPrivilege.SkipStudentFinanceProblem, CurrentRole) != true || LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
              InitializeModule.enumPrivilege.SkipStudentActive, CurrentRole) != true)
            {
                iErrorCounter++;
                this.ErrorMessage += sMsg;
            }
            else
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Student is inactive or having financial problems, but you passed it because you have the privilege.');", true);
            }
        }




        if (!isGraduationAllowed(this.sCourse))
        {
            //dont add Internship & graduation project in completed hours less than 99 credit hours
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_RegisterOnline,
                    InitializeModule.enumPrivilege.Skip99, CurrentRole) != true)
            {
                iErrorCounter++;
                this.ErrorMessage += "<br />*Graduation Project & Internship courses can be registered after completing 99 Ch Only";
            }
            else
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('Graduation Project & Internship courses can be registered after completing 99 Ch Only, but you passed it because you have the privilege.');", true);
            }

        }



        if (iErrorCounter <= 0)
            isValid = true;

        return isValid;
    }

    ////check if the prerequisiste of elective course passed

    public bool isPrerequisiteofElectiveCoursePassed(int iRegSemester)
    {
        bool isPassed = true;
        //Current Semester Reg Cosidered as Passed
        string sCSemester = "@";
        switch (iRegSemester)
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


        bool isRegisteredCurrentSem = false;

        List<int> iPreElective = new List<int>();
        PlansDAL myPlan = new PlansDAL();
        iPreElective = myPlan.GetPrerequisiteofElectiveCourse("1", this.myMirror.SDegree, this.myMirror.SMajor, this.sCourse, Campus);

        StudentCourses.StudentMirror[] myStudentMirror = this.myMirror.Mirror;

        if (iPreElective.Count == 0)
        {
            return isPassed;
        }
        foreach (int x in iPreElective)
        {
            isRegisteredCurrentSem = myStudentMirror[x - 1].sGrade.Contains(sCSemester) == true;

            if (!myStudentMirror[x - 1].isPassed && !isRegisteredCurrentSem)
            {
                isPassed = false;
                return isPassed;
            }

        }

        return isPassed;
    }
    public bool isPrerequisitePassed(int iRegSemester)
    {
        bool isPassed = true;
        //Current Semester Reg Cosidered as Passed
        string sCSemester = "@";
        switch (iRegSemester)
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


        bool isRegisteredCurrentSem = false;

        List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
        int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == this.sCourse; });
        if (iIndex < 0)
        {
            //the course not in student plan
            return isPassed;
        }
        List<int> iPre = myCrs[iIndex].iPre;
        StudentCourses.StudentMirror[] myStudentMirror = this.myMirror.Mirror;

        if (iPre.Count == 0)
        {
            return isPassed;
        }
        foreach (int x in iPre)
        {
            isRegisteredCurrentSem = myStudentMirror[x - 1].sGrade.Contains(sCSemester) == true;

            if (!myStudentMirror[x - 1].isPassed && !isRegisteredCurrentSem)
            {
                isPassed = false;
                return isPassed;
            }

        }

        return isPassed;
    }
    public bool isHasCorequisites()
    {

        bool bHasCorequisites = false;


        List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
        int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == this.sCourse; });

        string sCo_requisite = myCrs[iIndex].sParallel;

        if (sCo_requisite == "-")
        {
            bHasCorequisites = false;
        }
        else
        {
            iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == sCo_requisite; });

            StudentCourses.StudentMirror[] myStudentMirror = this.myMirror.Mirror;

            if (sCo_requisite.Length > 1)
            {
                bHasCorequisites = true;
            }
        }
        return bHasCorequisites;
    }
    public bool isCorequisites_Registered()
    {

        bool isPassed = true;
        // Reg Cosidered as Passed

        string sCSemester = "@";

        bool isRegisteredCurrentSem = false;

        List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
        int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == this.sCourse; });

        string sCo_requisite = myCrs[iIndex].sParallel;

        iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == sCo_requisite; });

        StudentCourses.StudentMirror[] myStudentMirror = this.myMirror.Mirror;

        if (sCo_requisite.Length <= 1)
        {
            return isPassed;
        }
        if (iIndex >= 0)
        {
            isRegisteredCurrentSem = myStudentMirror[iIndex].sGrade.Contains(sCSemester) == true;

            if (!myStudentMirror[iIndex].isPassed && !isRegisteredCurrentSem)
            {
                isPassed = false;
                return isPassed;
            }
        }
        return isPassed;
    }
    public string IsCorequisiteofRegisteredCourse(int iRegYear, int iRegSem, string sStudentID, string sCourse)
    {
        string IsCorequisite = "";
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT  CBS.Course, CBS.iYear, CBS.Sem, C.strParallel, CBS.Student";
            sSQL += " FROM dbo.Course_Balance_View_BothSides AS CBS INNER JOIN";
            sSQL += " dbo.Reg_Courses AS C ON CBS.Course = C.strCourse";
            sSQL += " WHERE C.strParallel ='" + sCourse + "'";
            sSQL += " AND CBS.Student ='" + sStudentID + "'";
            sSQL += " AND CBS.iYear = " + iRegYear;
            sSQL += " AND CBS.Sem = " + iRegSem;

            //supposed to check now it it's an elective course or not
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                IsCorequisite = Rd["Course"].ToString();
            }
            Rd.Close();
        }
        catch (Exception Ex)
        {
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return IsCorequisite;

    }

    public bool isCourseRegisterable()
    {
        bool isRegisterable = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            //string sSQL = "SELECT GS.bPassIt AS IsPassed,GH.strGrade";
            //sSQL += " FROM Reg_Grade_Header AS GH INNER JOIN Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade";
            //sSQL += " WHERE (GH.strCourse = '" + this.sCourse + "')";
            //sSQL += " AND (GH.lngStudentNumber = '" + this.myMirror.StudentNumber + "')";
            //sSQL += " AND (GH.bDisActivated = 0) AND (GH.bCanceled = 0)";

            string sSQL = "SELECT TOP(1) GS.bPassIt AS IsPassed, GH.strGrade";
            sSQL += " FROM Reg_Grade_Header AS GH INNER JOIN Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade INNER JOIN";
            sSQL += " Reg_Courses AS CG ON GH.strCourse = CG.strCourse INNER JOIN Reg_Courses AS C ON CG.sUnified = C.sUnified";
            sSQL += " WHERE GH.lngStudentNumber = '" + this.myMirror.StudentNumber + "' AND GH.bDisActivated = 0";
            sSQL += " AND GH.bCanceled = 0 AND C.strCourse = '" + this.sCourse + "'";

            bool isPassed = false;
            string sGrade = "";


            //List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
            //int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == this.sCourse; });

            //if (iIndex == -1)
            //{
            //supposed to check now it it's an elective course or not
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                isPassed = Convert.ToBoolean(Rd["IsPassed"].ToString());
                sGrade = Rd["strGrade"].ToString();
            }
            Rd.Close();

            if (!isPassed)
            {
                isRegisterable = true;
            }
            else
            {
                if (isPassed && sGrade.ToLower() == "d" && this.myMirror.CGPA < 2)
                {
                    isRegisterable = true;
                }
                //else
                //{
                //    isRegisterable= false;
                //}
            }

            //}
            //StudentCourses.StudentMirror[] myStudentMirror = this.myMirror.Mirror;

            //if (myStudentMirror[iIndex].isPassed)
            //{
            //    if (this.myMirror.CGPA < 2)
            //    {
            //        isRegisterable = (myStudentMirror[iIndex].sGrade.ToLower().Equals("d") || myStudentMirror[iIndex].isRecommended);
            //    }
            //}
            //else
            //{
            //    isRegisterable = true;
            //}
        }
        catch (Exception Ex)
        {
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isRegisterable;

    }
    public bool isCourseInPlan()
    {
        List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
        int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == this.sCourse; });

        bool isInPlan = (iIndex != -1);
        return isInPlan;
    }
    public string isCourseElective()
    {
        List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
        int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == this.sCourse; });
        string isElective = "";
        if (iIndex != -1)
        {
            isElective = myCrs[iIndex].isElectve.ToString() + myCrs[iIndex].sElectives.ToString();
        }

        return isElective;
    }
    public bool isCourseRegistered()
    {
        bool isRegistered = false;

        isRegistered = LibraryMOD.isRegistered(this.iStudyYear, this.iSemester, this.sCourse, this.myMirror.StudentNumber, InitializeModule.EnumCampus.Males);
        if (isRegistered == false)
        {
            isRegistered = LibraryMOD.isRegistered(this.iStudyYear, this.iSemester, this.sCourse, this.myMirror.StudentNumber, InitializeModule.EnumCampus.Females);
        }
        //List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
        //int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == this.sCourse; });

        //StudentCourses.StudentMirror[] myStudentMirror = this.myMirror.Mirror;

        //isRegistered = (myStudentMirror[iIndex].sGrade.Substring(0, 1) == "@");
        return isRegistered;
    }
    public bool isCourseRegistered(string sCourseParam)
    {
        bool isRegistered = false;
        isRegistered = LibraryMOD.isRegistered(this.iStudyYear, this.iSemester, sCourseParam, this.myMirror.StudentNumber, InitializeModule.EnumCampus.Males);
        if (isRegistered == false)
        {
            isRegistered = LibraryMOD.isRegistered(this.iStudyYear, this.iSemester, this.sCourse, this.myMirror.StudentNumber, InitializeModule.EnumCampus.Females);
        }

        //List<PlanCourses.Crs> myCrs = this.myPlan.Courses;
        //int iIndex = myCrs.FindIndex(delegate(PlanCourses.Crs C) { return C.sCourse == sCourseParam; });

        //StudentCourses.StudentMirror[] myStudentMirror = myMirror.Mirror;

        //isRegistered = (myStudentMirror[iIndex].sGrade.Substring(0, 1) == "@");
        return isRegistered;
    }

    //private int getRegisteredCoursesHours()
    //{
    //    int iTotalRegisteredHours = 0;
    //     Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
    //    SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

    //    string sSql = "SELECT sum(reg_Courses.byteCreditHours) AS TotalRegisteredHours";
    //    sSql +=" FROM Course_Balance_View INNER JOIN";
    //    sSql +=" Reg_Courses ON Course_Balance_View.Course = Reg_Courses.strCourse INNER JOIN";
    //    sSql +=" Reg_CourseTime_Schedule AS CT INNER JOIN";
    //    sSql +=" Reg_Shifts ON CT.byteShift = Reg_Shifts.byteShift INNER JOIN";
    //    sSql +=" Reg_Lecturers ON CT.intLecturer = Reg_Lecturers.intLecturer";
    //    sSql +=" ON Course_Balance_View.iYear = CT.intStudyYear AND";
    //    sSql +=" Course_Balance_View.Sem = CT.byteSemester AND Course_Balance_View.Shift = CT.byteShift AND Course_Balance_View.Course = CT.strCourse AND ";
    //    sSql +=" Course_Balance_View.Class = CT.byteClass";
    //    sSql +=" WHERE intStudyYear="+this.iStudyYear+" AND byteSemester="+ this.iSemester +" AND Student='" + this.myMirror.StudentNumber + "'";

    //    Conn.Open();
    //    SqlCommand Cmd = new SqlCommand(sSql, Conn);
    //    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

    //    while (reader.Read())
    //    {
    //        iTotalRegisteredHours = int.Parse(reader["TotalRegisteredHours"].ToString());
    //    }
    //    return iTotalRegisteredHours;
    //}
    public int EnglishPolicy() //maxESL 0 -- 4  .. GPA 2.8 for ex
    {
        double CGPA = double.Parse(this.myMirror.CGPA.ToString());
        int iMaxESL = this.myMirror.MaxESL;
        bool isToeflRequired = this.myMirror.IsENGRequired;
        bool isToeflPassed = this.myMirror.Mirror[0].isPassed;

        int iEngCounter, iRSem, iEnglishPolicy;
        iRSem = (this.iSemester <= 0 ? 1 : this.iSemester);
        iEngCounter = (iRSem < 3 ? 18 : 9);

        iEnglishPolicy = iEngCounter;
        if (isToeflRequired && !isToeflPassed)
        {
            switch (iMaxESL)
            {
                case 0:
                    iEngCounter = 6; //ESL100 + ISC100
                    break;
                case 1:
                case 2:
                case 3:
                    iEngCounter = 6; //ESL + 2 Courses
                    break;
                case 4:
                    iEngCounter = 3; //ESL104 + 1 Course
                    break;
                case 5: //ESL104 Passed
                    if (CGPA < 3)
                    {
                        iEngCounter = (iRSem < 3 ? 12 : 6);
                    }
                    else if (CGPA >= 3 && CGPA <= 4)
                    {
                        iEngCounter = (iRSem < 3 ? 15 : 9);
                    }
                    break;

            }
        }
        else
        {
            if (CGPA >= 3.7)
                iEngCounter = (iRSem < 3 ? 21 : 12);
            else if (CGPA >= 2.5 && CGPA < 3.7)
                iEngCounter = (iRSem < 3 ? 18 : 9);
            else if (CGPA >= 2 && CGPA < 2.5)
                iEngCounter = (iRSem < 3 ? 15 : 9);
            else if (CGPA >= 0 && CGPA < 2)
                iEngCounter = (iRSem < 3 ? 12 : 6);
            else
                iEngCounter = (iRSem < 3 ? 15 : 9);
        }

        iEnglishPolicy = iEngCounter;

        return iEnglishPolicy;
    }

    public bool isInactiveOrHasFinanceProblems(int iRegYear, int iRegSem,out string sMsg)
    {
        bool isInvalid = false;
        bool isActive = false;
        bool isFinance = false;
        bool isThereFinanceProblems = true;
        int iAllowedReg = 0;
        bool isNotAllowed = false;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        sMsg = "";
        try
        {
            
            string sRegMsg = "<br/>Contact the registration please | يرجى مراجعة التسجيل";

            string sAccMsg = "<br/>Please contact the Accounting & Finance Department | يرجى مراجعة المحاسبة";
            sAccMsg += "<br/>Phone Number (1): +971504188086";
            sAccMsg += "<br/>Phone Number (2): +971544413928";
            sAccMsg += "<br/>WhatsApp Messages: +971564065904";
            sAccMsg += "<br/>Email: student.receivable@ect.ac.ae";

           
            string sSql = "SELECT A.bOtherCollege,A.bActive, ISNULL(AC.intRegYear * 10 + AC.byteRegSem, 0) AS iReg";
            sSql += " FROM Reg_Applications AS A LEFT OUTER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber";
            sSql += " WHERE A.lngStudentNumber='" + this.myMirror.StudentNumber + "'";


            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                iAllowedReg = Convert.ToInt32(reader["iReg"]);
                isActive = bool.Parse(reader["bActive"].ToString());
                //isFinance = bool.Parse(reader["bOtherCollege"].ToString());
            }

            //20042020
            int iFinCat = 0;
            string sOAcc = "";
            iFinCat = LibraryMOD.getFinanceCategory(this.myMirror.StudentNumber, out sOAcc);
            //Session["CurrentFinCat"] = iFinCat;
            isFinance = (iFinCat > 1);

            isNotAllowed = (iAllowedReg != iRegYear * 10 + iRegSem);

            isThereFinanceProblems = (isNotAllowed || isFinance);
            if (!isActive)
            {
                sMsg += sRegMsg;
            }
            if (isThereFinanceProblems)
            {
                sMsg += sAccMsg;
            }

            isInvalid = (!isActive || isThereFinanceProblems);
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return isInvalid;
    }

    //currentCR: Credit of el course elly beynzel delwa2ty .. 
    //iTotal kol el mawad elly mesagelha
    public bool isAddingCreditAllowed(int iRegYear, int iRegSem)
    {
        double iCredit;
        double curCGPA = 0;
        bool isAddingCreditAllowed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();

        try
        {
            iCredit = (this.iTotal <= 0 ? 0 : this.iTotal);
            string sSql = "SELECT GPA FROM GPA_Until ";
            sSql += "WHERE lngStudentNumber='" + this.myMirror.StudentNumber + "'";


            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                curCGPA = double.Parse(reader["GPA"].ToString());
            }

            switch (this.iSemester)
            {
                case 1:
                case 2:
                    if (curCGPA >= 0 && curCGPA < 2)
                        isAddingCreditAllowed = ((this.iCurrentCR + iCredit) <= 12);
                    else if (curCGPA < 0)
                        isAddingCreditAllowed = ((this.iCurrentCR + iCredit) <= 15);
                    else if (curCGPA >= 2 && curCGPA < 3.7)
                        isAddingCreditAllowed = ((this.iCurrentCR + iCredit) <= 18);
                    else
                        isAddingCreditAllowed = ((this.iCurrentCR + iCredit) <= 21);
                    break;
                case 3:
                case 4:
                    if (curCGPA >= 0 && curCGPA < 2)
                        isAddingCreditAllowed = ((this.iCurrentCR + iCredit) <= 6);
                    else
                        isAddingCreditAllowed = ((this.iCurrentCR + iCredit) <= 9);

                    int iRegCoursesPrevSem = 0;

                    iRegCoursesPrevSem = LibraryMOD.GetRegCoursesPrevSem(this.myMirror.StudentNumber, iRegYear, iRegSem, (InitializeModule.EnumCampus)this.Campus);

                    isAddingCreditAllowed = ((iRegCoursesPrevSem * 3) + (this.iCurrentCR + iCredit)) <= 12;

                    break;
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return isAddingCreditAllowed;
    }

    public bool isStudentOld()
    {
        bool isOld = false;
        DateTime applicationDate;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSql = "SELECT MIN(dateApplication) as AppDate";
            sSql += " FROM Reg_Applications";
            //sSql += " WHERE lngStudentNumber='" + this.sStudentNumber +"'"; // +" AND byteSemester=" + iSemester;
            sSql += " WHERE lngStudentNumber='" + this.myMirror.StudentNumber + "'";


            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                reader.Read();
            }
            applicationDate = DateTime.Parse(reader["AppDate"].ToString());
            int iJoinYear = applicationDate.Year;
            int iCurrentYear = DateTime.Now.Year;

            isOld = iCurrentYear - iJoinYear > 4;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return isOld;
    }
    public bool isClassFull()
    {
        bool isFull = true;
        int iCapacity = 0;
        int iMaxSeats = 0;
        //int iMaxCapacity = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            //string sSql = "SELECT COALESCE (CC.RegCapacity, 0) AS RegCapacity";
            //sSql += " , H.intMaxSeats AS MaxSeats, C.byteCourseClass";
            //sSql += " , dbo.Lkp_Course_Classes.strClassDescEn"; 
            //sSql += " , dbo.Lkp_Course_Classes.MaxCapacity";
            string sSQL = "Select COALESCE (CC.RegCapacity, 0) AS RegCapacity, convert(int,floor( (CASE WHEN MaxCapacity < intMaxSeats THEN MaxCapacity ELSE intMaxSeats END)*H.cSharedFactor)) AS iMax";
            sSQL += " FROM dbo.Reg_CourseTime_Schedule AS CT INNER JOIN";
            sSQL += " dbo.Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear ";
            sSQL += " AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse ";
            sSQL += " AND CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift ";
            sSQL += " INNER JOIN dbo.Lkp_Halls AS H ON CT.strHall = H.strHall ";
            sSQL += " INNER JOIN dbo.Reg_Courses AS C ON CT.strCourse = C.strCourse ";
            sSQL += " INNER JOIN dbo.Lkp_Course_Classes ON C.byteCourseClass = dbo.Lkp_Course_Classes.byteCourseClass ";
            sSQL += " LEFT OUTER JOIN dbo.ClassCapacity AS CC ON CT.intStudyYear = CC.iYear ";
            sSQL += " AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course ";
            sSQL += " AND CT.byteClass = CC.Class AND CT.byteShift = CC.Shift";

            sSQL += " WHERE CT.byteShift = " + this.iShift;
            sSQL += " AND CT.intStudyYear = " + this.iStudyYear;
            sSQL += " AND CT.byteSemester = " + this.iSemester;
            sSQL += " AND CT.strCourse = '" + this.sCourse + "'";
            sSQL += " AND CT.byteClass=" + this.iClass;


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                iCapacity = int.Parse(reader["RegCapacity"].ToString());
                iMaxSeats = int.Parse(reader["iMax"].ToString());
                //iMaxCapacity = int.Parse(reader["MaxCapacity"].ToString());
            }
            reader.Close();
            //isFull = ((iMaxSeats - iCapacity) < 1);
            //Updated based on email from Dr. Sammouda [Class size new policy] 15-7-2015
            //if (iMaxSeats < iMaxCapacity)
            //{
            //    iMaxCapacity = iMaxSeats;
            //}

            //Online classes +[Class size new policy] 15-7-2015
            isFull = ((iMaxSeats - iCapacity) < 1);

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isFull;
    }
    //public bool isCourseTimeConflicts(out int iSelectedCourseCR, out int iRegisteredCoursesCR)
    public bool isCourseTimeConflicts(out int iSelectedCourseCR)
    {
        iSelectedCourseCR = 0;
        //iRegisteredCoursesCR = 0;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            int iLogical = 0;
            //Get the selected course times
            string sSql = "";


            sSql = "SELECT C.byteCreditHours, CT.dateTimeFrom, CT.dateTimeTo, CT.byteDay,CT.strCourse, CT.byteShift";
            sSql += " FROM SQL_SERVER.ECTData.dbo.Reg_Courses AS C ";
            sSql += " INNER JOIN SQL_SERVER.ECTData.dbo.Reg_CourseTime_Schedule AS CT ";
            sSql += " ON C.strCourse = CT.strCourse";
            sSql += " WHERE CT.intStudyYear=" + this.iStudyYear;
            sSql += " AND CT.byteSemester=" + this.iSemester;
            sSql += " AND CT.strCourse='" + this.sCourse + "'";
            sSql += " AND CT.byteShift=" + this.iShift;
            sSql += " AND CT.byteClass=" + this.iClass;

            sSql += " UNION ";

            sSql += " SELECT C.byteCreditHours, CT.dateTimeFrom, CT.dateTimeTo, CT.byteDay,CT.strCourse, CT.byteShift";
            sSql += " FROM LOCALECT.ECTData.dbo.Reg_Courses AS C ";
            sSql += " INNER JOIN LOCALECT.ECTData.dbo.Reg_CourseTime_Schedule AS CT ";
            sSql += " ON C.strCourse = CT.strCourse";
            sSql += " WHERE CT.intStudyYear=" + this.iStudyYear;
            sSql += " AND CT.byteSemester=" + this.iSemester;
            sSql += " AND CT.strCourse='" + this.sCourse + "'";
            sSql += " AND CT.byteShift=" + this.iShift;
            sSql += " AND CT.byteClass=" + this.iClass;
            sSql += " ORDER BY CT.strCourse, CT.byteShift";


            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<CourseTimes> myCourseTimesList = new List<CourseTimes>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    iSelectedCourseCR = int.Parse(reader["byteCreditHours"].ToString());
                    CourseTimes myCourseTimes = new CourseTimes();
                    myCourseTimes.TimeFrom = DateTime.Parse(reader["dateTimeFrom"].ToString());
                    myCourseTimes.TimeTo = DateTime.Parse(reader["dateTimeTo"].ToString());
                    myCourseTimes.Day = int.Parse(reader["byteDay"].ToString());
                    myCourseTimesList.Add(myCourseTimes);
                }

                reader.Close();

                //Get the student's registered courses

                sSql = "SELECT C.byteCreditHours, CT.dateTimeTo, CT.dateTimeFrom, CT.byteDay";
                sSql += " FROM SQL_SERVER.ECTData.dbo.Course_Balance_View AS CBV INNER JOIN";
                sSql += " SQL_SERVER.ECTData.dbo.Reg_Courses AS C ON CBV.Course = C.strCourse INNER JOIN";
                sSql += " SQL_SERVER.ECTData.dbo.Reg_CourseTime_Schedule AS CT ON CBV.iYear = CT.intStudyYear AND CBV.Sem = CT.byteSemester AND";
                sSql += " CBV.Shift = CT.byteShift AND CBV.Course = CT.strCourse AND CBV.Class = CT.byteClass";
                sSql += " WHERE CT.intStudyYear=" + this.iStudyYear;
                sSql += " AND CT.byteSemester=" + this.iSemester;
                sSql += " AND CBV.Student='" + this.myMirror.StudentNumber + "'";

                // if student Diploma or bachelor dont check conflicts with ESL level
                if (this.myMirror.SDegree == "1" || this.myMirror.SDegree == "3")
                {
                    sSql += " AND CBV.Course NOT LIKE '%ESL%'";
                }

                sSql += " UNION ";

                sSql += " SELECT C.byteCreditHours, CT.dateTimeTo, CT.dateTimeFrom, CT.byteDay";
                sSql += " FROM LOCALECT.ECTData.dbo.Course_Balance_View AS CBV INNER JOIN";
                sSql += " LOCALECT.ECTData.dbo.Reg_Courses AS C ON CBV.Course = C.strCourse INNER JOIN";
                sSql += " LOCALECT.ECTData.dbo.Reg_CourseTime_Schedule AS CT ON CBV.iYear = CT.intStudyYear AND CBV.Sem = CT.byteSemester AND";
                sSql += " CBV.Shift = CT.byteShift AND CBV.Course = CT.strCourse AND CBV.Class = CT.byteClass";
                sSql += " WHERE CT.intStudyYear=" + this.iStudyYear;
                sSql += " AND CT.byteSemester=" + this.iSemester;
                sSql += " AND CBV.Student='" + this.myMirror.StudentNumber + "'";

                // if student Diploma or bachelor dont check conflicts with ESL level
                if (this.myMirror.SDegree == "1" || this.myMirror.SDegree == "3")
                {
                    sSql += " AND CBV.Course NOT LIKE '%ESL%'";
                }

                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                Cmd = new SqlCommand(sSql, Conn);
                reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

                List<CourseTimes> myStudentTimesList = new List<CourseTimes>();

                while (reader.Read())
                {
                    CourseTimes myCourseTimes = new CourseTimes();
                    int iCreditHours = int.Parse(reader["byteCreditHours"].ToString());
                    myCourseTimes.TimeFrom = DateTime.Parse(reader["dateTimeFrom"].ToString());
                    myCourseTimes.TimeTo = DateTime.Parse(reader["dateTimeTo"].ToString());
                    myCourseTimes.Day = int.Parse(reader["byteDay"].ToString());
                    myStudentTimesList.Add(myCourseTimes);
                    //iRegisteredCoursesCR += iCreditHours;
                }
                reader.Close();

                foreach (CourseTimes C in myCourseTimesList)
                {
                    foreach (CourseTimes S in myStudentTimesList)
                    {
                        iLogical = (S.Day & C.Day);

                        if (iLogical > 0)
                        {

                            //1]
                            if (C.TimeFrom.TimeOfDay <= S.TimeFrom.TimeOfDay && C.TimeTo.TimeOfDay >= S.TimeTo.TimeOfDay)
                                return true;
                            //2]
                            if (C.TimeFrom.TimeOfDay <= S.TimeFrom.TimeOfDay && C.TimeTo.TimeOfDay > S.TimeFrom.TimeOfDay)
                                return true;
                            //3]
                            if (C.TimeFrom.TimeOfDay < S.TimeFrom.TimeOfDay && C.TimeTo.TimeOfDay >= S.TimeTo.TimeOfDay)
                                return true;
                            //4]
                            if (C.TimeFrom.TimeOfDay >= S.TimeFrom.TimeOfDay && C.TimeTo.TimeOfDay <= S.TimeTo.TimeOfDay)
                                return true;
                            //5]
                            if (C.TimeFrom.TimeOfDay >= S.TimeFrom.TimeOfDay && C.TimeFrom.TimeOfDay < S.TimeTo.TimeOfDay)
                                return true;


                        }

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
            Conn.Close();
            Conn.Dispose();
        }
        return false;
    }
    //public bool isFNDCoursesRequired(string StudentID, out bool IsMTH001Required, out bool IsCHEM001Required,out bool IsBIOL001Required, out bool IsPHYS001Required)
    //{
    //    bool isRequired = false;

    //    IsMTH001Required = false;
    //    IsCHEM001Required = false;
    //    IsBIOL001Required = false;
    //    IsPHYS001Required = false;

    //    Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
    //    SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
    //    Conn.Open();
    //    try
    //    {
    //        string sQuery = "";

    //        //Check if its scientific HS and student get score in math >=70
    //        //if not should register MTH001
    //        sQuery = "SELECT Q.intMajor, Q.ScoreOfMath ";
    //        sQuery += " , Q.ScoreOfChemistry, Q.ScoreOfPhysics, Q.ScoreOfBiology";
    //        sQuery += " , Q.HSSystem, Q.G12_Stream,A.strSpecialization";
    //        sQuery += " FROM  dbo.Reg_Student_Qualifications AS Q ";
    //        sQuery += " INNER JOIN dbo.Reg_Applications AS A ON Q.lngSerial = A.lngSerial";
    //        sQuery += " WHERE (Q.intCertificate = 1 ) ";
    //        sQuery += " AND (Q.lngSerial =" + LibraryMOD.GetStudentSerialNo(StudentID, (int)Campus).ToString() + ")";
    //        sQuery += " AND (A.strDegree = N'3') ";


    //        int iMajor = 0;
    //        int iScoreofMath = 0;
    //        int iScoreofChem = 0;
    //        int iScoreofBiol = 0;
    //        int iScoreofPhys = 0;
    //        int iHSSystem = 0;
    //        int iG12_Stream = 0;
    //        string sStudentMajor = "";

    //        SqlCommand Cmd = new SqlCommand(sQuery, Conn);
    //        SqlDataReader Rd = Cmd.ExecuteReader();

    //        while (Rd.Read())
    //        {
    //            iMajor = int.Parse("0" + Rd["intMajor"].ToString());
    //            iScoreofMath = int.Parse("0" + Rd["ScoreOfMath"].ToString());
    //            iScoreofChem = int.Parse("0" + Rd["ScoreOfChemistry"].ToString());
    //            iScoreofBiol = int.Parse("0" + Rd["ScoreOfBiology"].ToString());
    //            iScoreofPhys = int.Parse("0" + Rd["ScoreOfPhysics"].ToString());
    //            iHSSystem = int.Parse("0" + Rd["HSSystem"].ToString());
    //            iG12_Stream = int.Parse("0" + Rd["G12_Stream"].ToString());

    //            sStudentMajor = Rd["strSpecialization"].ToString();
    //        }
    //        Rd.Close();

    //        //HIM & HCM majors
    //        //MOE system science or advance
    //        if ((sStudentMajor == "11" || sStudentMajor == "45") && iHSSystem == (int)InitializeModule.enumHSSystem.MOE && (iG12_Stream == (int)InitializeModule.enumG12Stream.Advanced || iG12_Stream == (int)InitializeModule.enumG12Stream.Science))
    //        {
    //            if (iScoreofMath < 70)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //        }
    //        //if not MOE system 
    //        if ((sStudentMajor == "11" || sStudentMajor == "45") && iHSSystem != (int)InitializeModule.enumHSSystem.MOE )
    //        {
    //            if (iScoreofMath < 70)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //        }
    //        //if ADEC stream
    //        if ((sStudentMajor == "11" || sStudentMajor == "45") && iG12_Stream == (int)InitializeModule.enumG12Stream.ADEC)
    //        {
    //            if (iScoreofMath < 70)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }

    //        }
    //        //if MOE system general stream
    //        if ((sStudentMajor == "11" || sStudentMajor == "45") && iHSSystem == (int)InitializeModule.enumHSSystem.MOE && iG12_Stream == (int)InitializeModule.enumG12Stream.General)
    //        {
    //            isRequired = true;
    //            IsMTH001Required=true;
    //            IsCHEM001Required = true;
    //            IsBIOL001Required = true;
    //        }
    //        //if Commercial or Technical or Industrial
    //        if ((sStudentMajor == "11" || sStudentMajor == "45") && (iMajor == (int)InitializeModule.enumHS_Major.Commercial || iMajor == (int)InitializeModule.enumHS_Major.Industrial || iMajor == (int)InitializeModule.enumHS_Major.Technical || iMajor == (int)InitializeModule.enumHS_Major.GeneralStream))
    //        {
    //            isRequired = true;
    //            IsMTH001Required=true;
    //            IsCHEM001Required = true;
    //            IsBIOL001Required = true;
    //        }


    //        //MLS & MDI majors
    //        //MOE system science or advance
    //        if ((sStudentMajor == "46" || sStudentMajor == "47") && iHSSystem == (int)InitializeModule.enumHSSystem.MOE && (iG12_Stream == (int)InitializeModule.enumG12Stream.Advanced || iG12_Stream == (int)InitializeModule.enumG12Stream.Science))
    //        {
    //            if (iScoreofMath < 80)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 80)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required = true;
    //            }
    //            if (iScoreofBiol < 80)
    //            {
    //                isRequired = true;
    //                IsBIOL001Required = true;
    //            }
    //        }
    //        //if not MOE system 
    //        if ((sStudentMajor == "46" || sStudentMajor == "47") && iHSSystem != (int)InitializeModule.enumHSSystem.MOE)
    //        {
    //            if (iScoreofMath < 80)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 80)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required  = true;
    //            }
    //            if (iScoreofBiol < 80)
    //            {
    //                isRequired = true;
    //                IsBIOL001Required = true;
    //            }
    //        }
    //        //if ADEC stream
    //        if ((sStudentMajor == "46" || sStudentMajor == "47") && iG12_Stream == (int)InitializeModule.enumG12Stream.ADEC)
    //        {
    //            if (iScoreofMath < 80)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 80)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required = true;
    //            }
    //            if (iScoreofBiol < 80)
    //            {
    //                isRequired = true;
    //                IsBIOL001Required = true;
    //            }

    //        }
    //        //if MOE system general stream
    //        if ((sStudentMajor == "46" || sStudentMajor == "47") && iHSSystem == (int)InitializeModule.enumHSSystem.MOE && iG12_Stream == (int)InitializeModule.enumG12Stream.General)
    //        {
    //            if (iScoreofMath < 85)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 85)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required = true;
    //            }
    //            if (iScoreofBiol < 85)
    //            {
    //                isRequired = true;
    //                IsBIOL001Required = true;
    //            }
    //        }
    //        //if Commercial or Technical or Industrial
    //        if ((sStudentMajor == "46" || sStudentMajor == "47") && (iMajor == (int)InitializeModule.enumHS_Major.Commercial || iMajor == (int)InitializeModule.enumHS_Major.Industrial || iMajor == (int)InitializeModule.enumHS_Major.Technical || iMajor == (int)InitializeModule.enumHS_Major.GeneralStream))
    //        {
    //            isRequired = true;
    //            IsMTH001Required = true;
    //            IsCHEM001Required = true;
    //            IsBIOL001Required = true;
    //        }
    //        //Engineering
    //        //CE, ME & IE 
    //        //MOE system science or advance
    //        if ((sStudentMajor == "48" || sStudentMajor == "49" || sStudentMajor == "50") && iHSSystem == (int)InitializeModule.enumHSSystem.MOE && (iG12_Stream == (int)InitializeModule.enumG12Stream.Advanced || iG12_Stream == (int)InitializeModule.enumG12Stream.Science))
    //        {
    //            if (iScoreofMath < 80)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 80)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required = true;
    //            }
    //            if (iScoreofPhys < 80)
    //            {
    //                isRequired = true;
    //                IsPHYS001Required = true;
    //            }
    //        }
    //        //if not MOE system 
    //        if ((sStudentMajor == "48" || sStudentMajor == "49" || sStudentMajor == "50") && iHSSystem != (int)InitializeModule.enumHSSystem.MOE)
    //        {
    //            if (iScoreofMath < 80)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 80)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required = true;
    //            }
    //            if (iScoreofPhys < 80)
    //            {
    //                isRequired = true;
    //                IsPHYS001Required = true;
    //            }
    //        }
    //        //if ADEC stream
    //        if ((sStudentMajor == "48" || sStudentMajor == "49" || sStudentMajor == "50") && iG12_Stream == (int)InitializeModule.enumG12Stream.ADEC)
    //        {
    //            if (iScoreofMath < 80)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 80)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required = true;
    //            }
    //            if (iScoreofPhys < 80)
    //            {
    //                isRequired = true;
    //                IsPHYS001Required = true;
    //            }

    //        }
    //        //if MOE system general stream
    //        if ((sStudentMajor == "48" || sStudentMajor == "49" || sStudentMajor == "50") && iHSSystem == (int)InitializeModule.enumHSSystem.MOE && iG12_Stream == (int)InitializeModule.enumG12Stream.General)
    //        {
    //            if (iScoreofMath < 85)
    //            {
    //                isRequired = true;
    //                IsMTH001Required = true;
    //            }
    //            if (iScoreofChem < 85)
    //            {
    //                isRequired = true;
    //                IsCHEM001Required = true;
    //            }
    //            if (iScoreofPhys < 85)
    //            {
    //                isRequired = true;
    //                IsPHYS001Required = true;
    //            }
    //        }
    //        //if Commercial or Technical or Industrial
    //        if ((sStudentMajor == "48" || sStudentMajor == "49" || sStudentMajor == "50") && (iMajor == (int)InitializeModule.enumHS_Major.Commercial || iMajor == (int)InitializeModule.enumHS_Major.Industrial || iMajor == (int)InitializeModule.enumHS_Major.Technical || iMajor == (int)InitializeModule.enumHS_Major.GeneralStream))
    //        {
    //            isRequired = true;
    //            IsMTH001Required = true;
    //            IsCHEM001Required = true;
    //            IsPHYS001Required = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        LibraryMOD.ShowErrorMessage(ex);
    //        isRequired = true;
    //    }
    //    finally
    //    {
    //        Conn.Close();
    //        Conn.Dispose();
    //    }
    //    return isRequired;
    //}

    public bool isFndCourseRegistered(string sFndCourse)
    {
        bool isRegistered = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSQL = "SELECT Course FROM Course_Balance_View";
            sSQL += " WHERE Sem = " + this.iSemester + " AND iYear = " + this.iStudyYear;
            sSQL += " AND Student = '" + this.myMirror.StudentNumber + "'";
            sSQL += " AND Course = '" + sFndCourse + "'";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                isRegistered = true;
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isRegistered = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isRegistered;

    }
    public bool isFndCoursePassed(string sFndCourse)
    {
        bool isPassed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT Reg_Grade_System.bPassIt";
            sSQL += " FROM Reg_Grade_System INNER JOIN";
            sSQL += " Reg_Grade_Header ON Reg_Grade_System.strGrade = Reg_Grade_Header.strGrade";
            sSQL += " WHERE Reg_Grade_Header.lngStudentNumber = '" + this.myMirror.StudentNumber + "'";
            sSQL += " AND dbo.Reg_Grade_Header.strCourse = '" + sFndCourse + "'";
            sSQL += " AND Reg_Grade_System.bPassIt = 1";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                isPassed = true;
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isPassed = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isPassed;

    }
    public bool isESLRequired(out string sReturn)
    {
        bool isRequired = false;
        sReturn = "";
        try
        {
            bool isToeflRequired = this.myMirror.IsENGRequired;
            float Score = float.Parse(this.myMirror.Score.ToString());
            bool isToeflPassed = LibraryMOD.isENGPassed(Score, this.myMirror.ENG, this.myMirror.SDegree, this.myMirror.SMajor);
            if (isToeflRequired && !isToeflPassed)
            {
                //for (int i = 0; i <= 1; i++)
                //{
                //    sReturn = myMirror.Recommended[i].sCourse;
                //    if (sReturn.Contains("ESL"))
                //    {
                //        isRequired = !isCourseRegistered(sReturn);
                //        if (isRequired)
                //        {
                //            return isRequired;
                //        }
                //    }
                //}
                isRequired = true;
                sReturn = "ESL";
            }
        }
        catch (Exception ex)
        {

            LibraryMOD.ShowErrorMessage(ex);
            isRequired = true;
        }
        finally
        {

        }
        return isRequired;
    }

    public bool isESLRegistered()
    {
        bool isRegistered = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSQL = "SELECT Course FROM Course_Balance_View";
            sSQL += " WHERE Sem = " + this.iSemester + " AND iYear = " + this.iStudyYear;
            sSQL += " AND Student = '" + this.myMirror.StudentNumber + "'";
            sSQL += " AND Course LIKE 'ESL%' OR Course='LTS101' OR Course='LTS102'";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                isRegistered = true;
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isRegistered = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isRegistered;

    }

    public bool isAllowedElectiveCourse()
    {
        bool isAllowed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSQL = "SELECT Course FROM Course_Balance_View";
            //sSQL += " WHERE Sem = " + this.iSemester + " AND iYear = " + this.iStudyYear;
            //sSQL += " AND Student = '" + this.myMirror.StudentNumber + "'";
            //sSQL += " AND Course LIKE 'ESL%' OR Course='LTS101' OR Course='LTS102'";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                isAllowed = true;
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isAllowed = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isAllowed;

    }

    public bool isMajorElectiveCourse(string sCourse, string sDegree, string sMajor)
    {
        bool isTrue = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSQL = "SELECT sEelecive FROM Reg_Specialization_Elective";
            sSQL += " WHERE sDegree ='" + sDegree + "'";
            sSQL += " AND sMajor ='" + sMajor + "'";
            sSQL += " AND sEelecive ='" + sCourse + "'";


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                isTrue = true;
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isTrue = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isTrue;

    }

    public bool isGraduationAllowed(string sCourse)
    {
        bool isTrue = true;

        try
        {
            int iCompletedHours = 0;

            if ((sCourse.Contains("415") && sCourse != "RTV415") || (sCourse.Contains("419")))
            {
                iCompletedHours = LibraryMOD.GetCompletedHours(this.myMirror.StudentNumber, Campus);
                if (iCompletedHours < 99)
                {
                    isTrue = false;
                }
            }

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isTrue = false;
        }
        finally
        {

        }
        return isTrue;

    }

    public bool validateAdvising(System.Web.UI.Page page, int iRegYear, int iRegSem)
    {
        int iErrorCounter = 0;
        bool isValid = false;
        int iMaxESL = this.myMirror.MaxESL;
        //ESL 50%
        bool is50 = sCourse.Contains("%");
        bool isESL = sCourse.Contains("ESL");
        //Is must register MTH001

        string sReturn = "";

        MirrorDAL myMirrorDAL = new MirrorDAL();

        int iMElective = myMirrorDAL.GetMajorElectiveCoursesCount(myMirror.StudentNumber, Campus);
        int iFElective = myMirrorDAL.GetFreeElectiveCoursesCount(myMirror.StudentNumber, Campus);

        if (isESL && isESLRegistered())
        {
            iErrorCounter++;
            this.ErrorMessage += "<br />*ESL is already registered";
        }
        if (!isESL)
        {
            //&& iMaxESL < 4  Canceled
            if (isESLRequired(out sReturn) && !isESLRegistered() && this.myMirror.StudentNumber.Substring(0, 1) != "F")
            {
                iErrorCounter++;
                this.ErrorMessage += "<br />*You should register " + sReturn + " first";
            }
        }
        bool isMTH001 = sCourse.Contains("MTH001");
        bool isCHEM001 = sCourse.Contains("CHEM001");
        bool isBIOL001 = sCourse.Contains("BIOL001");
        bool isPHYS001 = sCourse.Contains("PHYS001");

        bool IsMTH001Required = false;
        bool IsCHEM001Required = false;
        bool IsBIOL001Required = false;
        bool IsPHYS001Required = false;
        string sFndCourse = "";


        //if (isFNDCoursesRequired(myMirror.StudentNumber,out IsMTH001Required, out IsCHEM001Required, out IsBIOL001Required, out IsPHYS001Required))
        if (AdmissionRequirments.IsFulfilledAdmissionRequirements(Campus, myMirror.StudentNumber, out IsMTH001Required, out IsCHEM001Required, out IsBIOL001Required, out IsPHYS001Required))
        {
            sFndCourse = "MTH001";
            if (!isMTH001 && IsMTH001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Math less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
            sFndCourse = "CHEM001";
            if (!isCHEM001 && IsCHEM001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Chemistry less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
            sFndCourse = "BIOL001";
            if (!isBIOL001 && IsBIOL001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Biology less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
            sFndCourse = "PHYS001";
            if (!isPHYS001 && IsPHYS001Required)
            {
                if (!isFndCourseRegistered(sFndCourse) && !isFndCoursePassed(sFndCourse))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*Your score in Physics less than admission requirment, You must register " + sFndCourse + " first";
                }
            }
        }

        int iSelectedCourseCR = 0;
        double iRegisteredCoursesCR = LibraryMOD.GetStudentRegisteredCredit(this.iStudyYear, iSemester, this.myMirror.StudentNumber, (int)this.Campus);

        //if (!is50)
        //{
        //    if (isCourseTimeConflicts(out iSelectedCourseCR))
        //    {
        //        iErrorCounter++;
        //        this.ErrorMessage += "<br />*Course time conflict.";

        //    }
        //}

        this.iCurrentCR = iSelectedCourseCR;
        this.iTotal = iRegisteredCoursesCR;
        //float CGPA = float.Parse(this.myMirror.CGPA.ToString());
        //bool isToeflRequired = this.myMirror.IsENGRequired;
        //float Score = float.Parse(this.myMirror.Score.ToString());
        //bool isToeflPassed = LibraryMOD.isENGPassed(Score, this.myMirror.ENG, this.myMirror.SDegree, this.myMirror.SMajor);


        //int iHours = LibraryMOD.GetMaxHours(iSemester, isToeflRequired, isToeflPassed, iMaxESL, CGPA, this.myMirror.SDegree, this.myMirror.SMajor);
        //if (!((iTotal + iCurrentCR) <= iHours))
        //{
        //    iErrorCounter++;
        //    this.ErrorMessage += "<br />*Registered courses credit hours exceed semester limit.";

        //}

        ////if Two Summers

        //if (iSemester > 2)
        //{

        //    int iSummers = LibraryMOD.GetSummersHours(this.iStudyYear, this.myMirror.StudentNumber, Campus);

        //    if (!((iSummers + iCurrentCR) <= 12))
        //    {

        //        iErrorCounter++;
        //        this.ErrorMessage += "<br />*Registered courses credit hours exceed the two summers limit.";

        //    }

        //}


        //free elective courses - not in major plan and not major elective ourse
        if (!isCourseInPlan() && !is50)
        {
            //major elective
            if (isMajorElectiveCourse(sCourse, myMirror.SDegree, myMirror.SMajor) != false)
            {
                if (iMElective > 2)
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*You already registered maximum major elective courses.";
                }
                //check if the prerequisiste of elective course passed
                if (!this.isPrerequisiteofElectiveCoursePassed(iRegSem))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*The prerequisite(s) of major elective Course are not passed.";
                }
            }
            else
            { //free elective
                if (iFElective > 2)
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*You already registered maximum allowed of free elective courses.";
                }
                if (!this.isPrerequisiteofElectiveCoursePassed(iRegSem))
                {
                    iErrorCounter++;
                    this.ErrorMessage += "<br />*The prerequisite(s) of free elective Course are not passed.";
                }
            }
        }


        //if (this.isCourseRegistered())
        //{
        //    iErrorCounter++;
        //    this.ErrorMessage += "<br />*Course is already registered.";
        //}

        if (!is50 && !isESL)
        {
            if (!this.isPrerequisitePassed(iRegSem))
            {

                iErrorCounter++;
                this.ErrorMessage += "<br />*Course prerequisite(s) are not passed.";

            }

            if (!this.isCourseRegisterable())
            {
                iErrorCounter++;
                this.ErrorMessage += "<br />*Course is passed with a grade that is not D";
            }

        }

        if (!isGraduationAllowed(this.sCourse))
        {
            //dont add Internship & graduation project in completed hours less than 99 credit hours

            iErrorCounter++;
            this.ErrorMessage += "<br />*Graduation Project & Internship courses can be registered after completing 99 Ch Only";

        }

        if (iErrorCounter <= 0)
            isValid = true;

        return isValid;
    }

}