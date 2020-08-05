using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Collections.Generic;

public class InitializeModule
{
    LibraryMOD myLibraryMOD = new LibraryMOD();
    //String Constant 
    public const string MCam_serverName = "localect";
    public const string FCam_serverName = "sql_server";
    public const string New_DB="ECTData_New";
    public const string MCam_DB = "ECTData";
    public const string FCam_DB = "ECTData";
    public const string merchantId = "7006448";//"TEST7006448";

    public const string APP_TITLE = "ECT System";
    public const string POSSIBLE_CONDITION = "1=1";
    public const string IMPOSSIBLE_CONDITION = "1=2";
    public const string UPDATES_DIR_NAME = "Updates";

    public const string ALL = "All";
    public const int SUCCESS_RET = 0;
    public const int FAIL_RET = -1;

    public const int TRUE_VALUE = 1;
    public const int FALSE_VALUE = 0;

    public const int ARABIC_LANG_ID = 1256;
    public const int ENGLISH_LANG_ID = 1252;

    public const int SPACE = 3;

    public const int BATCH_SIZE = 10;

    public static int gUserNo;
    public static string gUserName;
    public static int gRoleID;
    public static int gEmpID;

    public static string gPCName;
    public static string gNetUserName;

    public static int gAcademicYear;
    public static int gAcademicSemester;

    //Masseges
    public const string MsgAddNewAuthorization = "Sorry you are not Authorized to add in this page!";
    public const string MsgEditAuthorization = "Sorry you are not Authorized to Edit or Update in this page!";
    public const string MsgDeleteAuthorization = "Sorry you are not Authorized to Delete in this page!";
    public const string MsgPrintAuthorization = "Sorry you are not Authorized to Print in this page!";
    public const string MsgTransferToExcelAuthorization = "Sorry you are not Authorized to Transfer to Excel in this page!";
    public const string MsgTransferToWordAuthorization = "Sorry you are not Authorized to Transfer to Word in this page!";
    public const string MsgViewAuthorization = "Sorry you are not Authorized to view this page!";
    public const string MsgChangeGrades = "Sorry you are not Allowed to Change Grades for this Semester!";

    public enum EnumReasonBlock : int
    {
        UnderProbation = 1,
        MissingDocument = 2
    }

    public enum EnumSystems : int
    {
        Registration = 1,
        Accounting = 2,
        HumanResource = 3,
        Library = 4,
        CRM = 5,
        PA = 6,
        ECTLocal = 10
    }

    public enum EnumCRM_EntryType : int
    {
        Calls = 0,
        WalkIn = 1,
        SchoolVisit = 2,
        Exhibition = 3,
        Website = 4
    }

    public enum EnumColleges : int
    { 
        Accounting=9,
        ACF=22,
        HIM=15,
        BAF=8,
        BA=3,
        BIT_BACIS=2,
        GDA=7,
        Gen_Fnd=11,
        HRM=5,
        IM=4,
        PR=13,
        Engineering=24


    }
    public enum EnumSubSystems : int
    {
        HREXE = 1,
        UpdatingTool = 2,
        TransferAttendanceTool = 3

    }

    public static string[] aOperators = { "EqualTo", "GreaterThan", "GreaterThanOrEqualTo", "LessThan", "LessThanOrEqualTo", "NotEqualTo", "Between" };
    public static string[] aOptions = { "At", "Before", "After", "Between" };
    public static string[] aSemesters = { "F", "W", "S1 & S2 Combined", "S2" };
    public static string[] aDays = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
    public enum CeComparisonOperator
    {
        EqualTo,
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo,
        NotEqualTo,
        Between
    }
    public enum enumEvaluationStatus : int
    {
        Initial = 1,
        Editing = 2,
        EditingCompleted = 3,
        ApprovedByHead = 4,
        WaitingForHRApproval = 5,
        ApprovedByHR = 6,
        Rejected = 7,
        ObtainedSignature = 8
    }
    public enum enumEvaluationTypes : int
    {
        EmployeeOverallEvaluation = 1,
        StudentCourseEvaluation = 2,
        EvaluationOfInstructionBySupervisor = 3,
        EvaluationOfInstructionBySelf = 4,
        EvaluationOfInstructorByPeers = 5,
        InstructorCoursePortfolioAssessment = 6,
        CompletingStudentsLearningOutcomeSelfassessment = 7,
        GraduatesEvaluationByEmployer = 8,
        FacultyCourseEvaluation = 9,
        StudentFacultyEvaluation = 10,
        StudentsSatisfactionQuestionnaire = 11,
        FacultySatisfactionQuestionnaire = 12,
        ClassVisitEvaluation=13,
	    CourseLeaderEvaluation=14,
	    ProgramCoordinatorEvaluation=15,
        TeachingLearningEvaluatebyStudent=16,
        StudentsSatisfactionQuestionnaireNew= 17,
        EmployeeSatisfactionQuestionnaire_18_11_2011 = 18,
        FacultySatisfactionQuestionnaire_18_11_2011 =19,
        BAIndustrialManagement = 20
    }
    public enum enumQuestionType : int
    {
        MultipleChoice = 1,
        Text = 2,
        MultipleChoice_RadioButton = 4,
        MultipleChoice_CheckBox = 3
    }
    public enum EnumOptions
    {
        at,
        before,
        after,
        between
    }
    public enum EnumGender : int
    {
        Male = 1,
        Female = 2
    }
    public enum EnumCampus : int
    {
        Males = 1,
        Females = 2,
        ECTNew = 3,
        ACMS=4
    }
    public enum EnumDegree : int
    {
        Diploma = 1,
        FoundationCertificate = 2,
        Bachelor = 3
    }
    public enum EnumGradeDMType : int
    {
        Entry = 1,
        View = 2
    }
    public enum enumVacationType : int
    {
        Annual = 1,
        ExtraDays = 2,
        Sick = 3,
        //'ExtraDays_2Hours = 6
        //'ExtraDays_HalfDay = 7
    }
   
    public enum EnumEmpGroup : int
    {
        Administrative = 1,
        Academic = 2
    }
    public enum EnumMaritalStatus : int
    {
        iSingle = 1,
        Married = 2,
        Widow = 3,
        Divorced = 4
    }
    public enum enumLanguage : int
    {
        English = 1252,
        Arabic = 1256
    }
    public enum Grds : int
    {
        AllMReg = 0,
        OldMReg = 1,
        BaOldMReg = 2,

        NewMReg = 3,
        BaNewMReg = 4,

        BaExtendedMReg = 5,
        ESLExtendedMReg = 6,
        DiplomaExtendedMReg = 7,
        FndOMReg =8,
        FndNMReg = 9,
        EslOMReg = 10,
        EslNMReg = 11,
        
        
        AllFReg = 12,
        OldFReg = 13,
        BaOldFReg = 14,

        NewFReg = 15,
        BaNewFReg = 16,
        
        BaExtendedFReg = 17,
        ESLExtendedFReg = 18,
        DiplomaExtendedFReg = 19,

        FndOFReg = 20,
        FndNFReg = 21,
        EslOFReg = 22,
        EslNFReg = 23,
        
        //================Unregister Males & Females
        AllMNReg = 24,
        OldMNReg = 25,
        BaOldMNReg = 26,
        
        NewMNReg = 27,
        BaNewMNReg = 28,
        
        BaExtendedMNReg = 29,
        ESLExtendedMnReg=30,
        DiplomaExtendedMnReg = 31,

        FndOMNReg = 32,
        FndNMNReg = 33,
        EslOMNReg = 34,
        EslNMNReg = 35,
        

        AllFNReg = 36,
        OldFNReg = 37,
        BaOldFNReg = 38,
        
        NewFNReg = 39,
        BaNewFNReg = 40,
        
        DiplomaExtendedFnReg = 41,
        BaExtendedFNReg = 42,
        ESLExtendedFNReg = 43,

        FndOFNReg = 44,
        FndNFNReg = 45,
        EslOFNReg = 46,
        EslNFNReg = 47,
       
        //===========registered Media Males & Females
        AllMediaMReg = 48,
        OldMediaMReg = 49,
        BaMediaOldMReg = 50,

        NewMediaMReg = 51,
        BaMediaNewMReg = 52,
        
        BaMediaExtendedMReg = 53,
        ESLMediaExtendedMReg = 54,
        DiplomaMediaExtendedMReg = 55,

        FndMediaOMReg = 56,
        FndMediaNMReg = 57,
        EslMediaOMReg = 58,
        EslMediaNMReg = 59,

        AllMediaFReg =60,
        OldMediaFReg = 61,
        BaMediaOldFReg = 62,

        NewMediaFReg = 63,
        BaMediaNewFReg = 64,
        
        BaMediaExtendedFReg = 65,
        ESLMediaExtendedFReg = 66,
        DiplomaMediaExtendedFReg = 67,

        FndMediaOFReg = 68,
        FndMediaNFReg = 69,
        EslMediaOFReg = 70,
        EslMediaNFReg = 71,
       
        //================Unregister Media Males & Females
        AllMediaMNReg = 72,
        OldMediaMNReg = 73,
        BaMediaOldMNReg = 74,

        NewMediaMNReg = 75,
        BaMediaNewMNReg = 76,
       
        BaMediaExtendedMNReg = 77,
        ESLMediaExtendedMNReg = 78,
        DiplomaMediaExtendedMNReg = 79,
 
        FndMediaOMNReg = 80,
        FndMediaNMNReg = 81,
        EslMediaOMNReg = 82,
        EslMediaNMNReg = 83,

        AllMediaFNReg = 84,
        OldMediaFNReg = 85,
        BaMediaOldFNReg = 86,
        NewMediaFNReg = 87,
        BaMediaNewFNReg = 88,

        BaMediaExtendedFNReg = 89,
        ESLMediaExtendedFNReg = 90,
        DiplomaMediaExtendedFnReg = 91,

        FndMediaOFNReg = 92,
        FndMediaNFNReg = 93,
        EslMediaOFNReg = 94,
        EslMediaNFNReg = 95,

        AllGraduatedDiploma = 96,
        AllExtendedToBA = 97,
        //AllM_NotExtendedBA=,
        //AllF_NotExtendedBA=,
        OldDiplomaRetention_LastYear=98,
        OldDiplomaRetention_LastSem=99,
        OldBARetention_LastYear=100,
        OldBARetention_LastSem=101,
        AllOldRetention_LastYear=102,
        AllOldRetention_LastSem=103,
        AllOldUnregister_LastYear = 104,
        AllOldUnregister_LastSem = 105,

        AllPostponed =106,
        AllPostponed_LastYear = 107,
        AllPostponed_LastSem = 108,

        AllPotentialNotExtendedBA_Last2Years = 109,
        AllPotentialNotExtendedBA_LastYear = 110,
        AllPotentialNotExtendedBA_LastSem = 111,

        AllDiplomaGraduated_Last2Years=112,
        AllDiplomaGraduated_LastYear = 113,
        AllDiplomaGraduated_LastSem = 114,

        VisitingNewMReg = 115,
        VisitingNewFReg = 116,
        VisitingMediaNMReg = 117,
        VisitingMediaNFReg = 118,
        VisitingOldMReg = 119,
        VisitingOldFReg = 120,
        VisitingMediaOldMReg = 121,
        VisitingMediaOldFReg = 122
    }

    public enum enumPrivilege : int
    {
        ShowBrowse = 1,
        AddNew = 2,
        EditUpdate = 3,
        Delete = 4,
        Print = 5,
        TransferToExcel = 38,
        TransferToWord = 39,
        ShowPhones = 40,

        ChangePasswordOnly = 6,
        ChangeActivity = 8,
        ChangeStudentStatus = 7,
        AcceptStudent = 9,
        ChangeOtherLecturerMarks = 10,
        ChangeRegistrationYearSem = 11,
        AddCourse = 12,
        DropCourse = 13,
        SkipStudentActive = 14,
        SkipStudentMissingDocuments = 15,
        SkipStudentFinanceProblem = 16,
        DropDFCourses = 17,
        SkipTimeConflict = 18,
        SkipPrerequisite = 19,
        SkipDFRepeatPolicy = 20,
        SkipHallCapacity = 21,
        SkipMaxCapacity = 22,
        SkipAcademicLoad = 23,
        SkipVacationBalance = 24,
        AllowEditingVacationDaysCount = 25,
        SkipLeavePeriod = 26,
        SkipTotalLeavePeriod = 27,
        ShiftChangeAcademicYear = 28,
        ChangeFinanceProblem = 29,
        ChangeCampus = 30,
        ShowAllCalls = 31,
        ChangeHeadApproval = 32,
        ChangeHRApproval = 33,
        ChangeDirectorApproval = 34,
        CheckLeaveBalance = 37,
        DeleteAttendanceWarning = 41,
        ESLCalc = 42,
        ViewAllRegCourses = 43,
        SkipAddingCreditNotAllowed = 44,

        ChangeGrades = 45,
        ShowFinalGrades = 46,
        ShowAllLecturer = 47,
        ShowUnitLecturer = 48,
        AllowGradesFromAnyPC = 49,
        ChangeMajor=50,
        AddQualification=51,
        DeleteQualification=52,
        UpdateStudentData=53,
        CopyStudent=54,
        ImportGrades=55,
        ChangeID=56,
        ShowAll = 57,
        SeekGradesbyStudent=58,
        SkipESLs=59,
        //Statuses 
        StatusWithdrawn	=	60	,
        StatusTransferred	=	61	,
        StatusGraduated	=	62	,
        StatusReadmitted	=	63	,
        StatusUnderProbation	=	64	,
        StatusDismissedfromtheCollege	=	65	,
        StatusDiscontinued	=	66	,
        StatusSuspended	=	67	,
        StatusAbsent	=	68	,
        StatusInActive	=	69	,
        StatusPostponed	=	70	,
        StatusVisitingStudents	=	71	,
        StatusCanceled	=	72	,
        StatusTOEFLEnterRequired	=	73	,
        StatusTOEFLExitRequired	=	74	,
        StatusNoStatus	=	75	,
        StatusNoContact	=	76	,
        StatusNoAnswer	=	77	,
        StatusIntendtoregister	=	78	,
        StatusNeverRegistered	=	79	,
        StatusFoundationCompelete	=	80	,
        StatusExpectedtoGraduate	=	81	,
        StatusDismissedfromtheProgram	=	82	,
        StatusConverttoBachelor	=	83	,
        StatusConverttoDiploma	=	84	,
        //Reg Status
        ShowRetention=85,
        ShowUnRegisteredStudents=86,
        ShowUnRegisteredNewStudents=87,
        //---------------------
        EnglishCertificateScore = 88,
        EnglishCertificateAdd=89,
        EnglishCertificateEdit=90,
        HSCertificateAdd=91,
        HSCertificateEdit=92,
        SkipMaxBorrowedBooks=93,
        ShowAllMajors=94,
        ShowReminderSuggested = 95, 
        MakeAllPassed=96,
        ChangeStudentName=97,
        ChangePreferredMajor=149,
        ShowAdmissionVerification = 98,
        ShowRegistrarVerification = 99,
        AllowEditGradeAfterSubmitting = 100,
        ChangeGrade_F = 101,
        ChangeGrade_EW_W=102,
        ChangeGrade_I = 103,
        ChangeGrade_NG=104,
        TestimoniesPrinting=105,
        ChangeOnlineStatus=106,
        ACCManageStDiscounts=107,
        ACCManageStFees=108,
        ACCAddStPayment=109,
        ACCManageStPayment=110,
        ACCCancelStPayment=111,
        ACCChequePaid=112,
        ACCChequeReturned=113,
        ACCChequeCanceled=114,
        ACCChequeInsurance=115,
        ACCCashPayment=116,
        ACCCreditPayment=117,
        ACCChequePayment=118,
        SkipOutOfMajor=119,
        ShowRetention_Extra=120,
        ACCChangeCash=121,
        ACCSkipPrinted=122,
        Testimonies_Reg=123,
        Testimonies_Final=124,
        Testimonies_Training=125,
        Testimonies_Admission=126,
        Testimonies_Graduation=148,
        Transcript_ShowSignature=127,
        AllowRepeatPassedCoursesNot_D = 128,
        AllowRepeatPassedCourses_D = 129,
        SkipMaxMajorElective=130,
        SkipMaxFreeElective=131,
        ChangeAuditor=132,
        ShowAllDepartments=133,
        ShowDirectorVerification=134,
        ShowCRMCalls=135,
        ShowCRMWalkIn=136,
 		ShowCRMSchoolVisit=137,
        ShowCRMExhibition=138,
		ShowCRMWebsite=139,
        ImportSMSContactFromSearch=140,
        ImportSMSContactFromCourse=141,
        ImportSMSContactFromPSMS=142,
        ImportSMSContactFromAttWarning=143,
        ShowBalance=144,
        ShowECTemail=145,
        RunFullDistribution=146,
        RunPartialDistribution=147,
        ShowAllFaculties=150,
        Skip99=151,
        ChangePicture=152,
        ShowStudentSurvey=153,
        ShowFacultyStaffSurvey=154,
        ShowAdminStaffSurvey=155
    }

    public enum enumPrivilegeObjects : int
    {

        Employee = 300,
        ChangeDatabase = 301,
        YearSemesterSetup = 302,
        FirmSetup = 303,
        Nationality = 304,
        CountriesCities = 305,
        SystemConstant = 306,
        Permissions = 307,
        UserSetting = 308,
        VacationTypes = 309,
        JobTitle = 310,
        Vacation = 311,
        Leave = 312,
        ImportAttendanceData = 320,
        SetVersion = 321,
        ChangeAcademicYear = 322,
        ShiftSetup = 323,

        Banks = 21,
        EmployeeBonus = 324,
        BonusLookup = 325,

        EmployeeBanks = 326,
        Deduction = 327,
        Warning = 328,
        Absent = 329,
        Grades = 330,


        HolidaySetup = 331,
        AttendanceEdit = 332,

        HolidayLookup = 333,

        GradesBonus = 334,
        ServiceGrautity = 335,
        Periods = 336,
        CalculateSalary = 337,
        AddExtraDays = 338,

        AttendanceReport = 400,
        VacationsReport = 401,
        LeavesReport = 402,
        EmployeeInfoReport = 403,
        EmployeesDocumentsReport = 404,
        AbsentReport = 405,
        OverTimereport = 406,
        SalaryTransferToBanks = 407,
        //CheckLeaveBalance = 408,

        //Added by Ihab ***
        CRM_Customers = 1154,
        CRM_Calls = 1155,
        CRM_Tracking = 1156,
        CRM_Admission = 1157,

        CRM_DailyCalls=1216,
        //***
        CRM_FirmSetup = 801,
        CRM_SystemConstant = 802,
        CRM_UserSetting = 803,
        CRM_Permissions = 804,
        CRM_CallerConcerned = 805,
        CRM_options = 806,
        CRM_CallsMonitor = 807,


         //PA
        PA_NewAppraisal = 600,
        PA_EmployeeEvaluation = 601,
        PA_StudentCourseEvaluation = 602,
        PA_InstructorSupervisorEvaluation = 603,
        PA_InstructorSelf = 604,
        PA_InstructorPeer = 605,
        PA_InstructorCoursePortfolio = 606,
        PA_StudentOutcome = 607,
        PA_GraduateEmployer = 608,
        PA_CoruseEvaluation = 609,
        PA_StudentEvaluation = 610,
        PA_StudentsSatisfactionQuestionnaire=611,
        PA_FacultySatisfactionQuestionnaire = 612,
        PA_StudentInstructorMultiEvalSummery=613,
        PA_InstructorEvaluations = 620,
        PA_BAIndustrialManagement = 690,

        //ECT OBJECTS
        ECT_Attendance = 1001,
        ECT_GradesEntry = 1002,
        ECT_GradesView = 1003,
        ECT_TimeLine = 1006,
        ECT_ClassList = 1007,
        ECT_TimeTable = 1008,
        ECT_FacultyLoads = 1009,
        ECT_Att_Detail = 1011,
        ECT_Att_Summary = 1012,
        ECT_Advising = 1014,
        ECT_ProgramMirror = 1015,
        ECT_RegisteredMirror = 1022,
        ECT_RecommendedMirror = 1023,
        ECT_ExpectedMirror = 1024,
        ECT_FollowInquiry = 1028,
        ECT_Registration_Status = 1030,
        ECT_Halls = 1047,
        ECT_Lecturers = 1048,
        ECT_LookupHD = 1050,
        ECT_Accepted_Students = 1051,
        ECT_Nationalities = 1052,
        ECT_Countries_Cities = 1053,
        ECT_Attendance_Status = 1054,
        ECT_Certifications = 1055,
        ECT_Requested_Forms = 1056,
        ECT_Student_Data = 1057,
        ECT_Specialization = 1058,
        ECT_Courses = 1059,
        ECT_Prerequisites_Course = 1060,
        ECT_Grade_Type_Course = 1061,
        ECT_Semester = 1062,
        ECT_GradeType = 1064,
        ECT_Title = 1065,
        ECT_Reasons = 1067,
        ECT_WarningAttend = 1071,
        ECT_WarningAttendReport = 1074,
        ECT_StudentSearch = 1072,
        ECT_RegisterOnline = 1073,
        ECT_AdvisingManagement = 1070,
        ECT_AttendanceDetailsRpt = 1075,
        ECT_GradesEdit = 1076,
        ECT_MarkSheet = 1078,
        ECT_StudentBook = 1080,
        ECT_CourseCalc = 1081,
        ECT_AttendanceFollowUp = 1083,
        CheckLeaveBalance = 1085,
        ECT_LecturerTimeLine = 1087,
        ECT_HallTimeLine = 1089,
        ECT_RegistrationBlock = 1090,
        ECT_StudentGraduatesCount = 1150,
        ECT_EmployeeSetup = 1109,
        ECT_Student_Advising = 1117,
        ECT_Track_Classes = 1121,
        ECT_Track_View = 1132,
        ECT_CGPAs = 1135,
        ECT_Status_Statistics = 1136,
        ECT_Transcript=1141,
        ECT_Grades_Statistics = 1146,
        ECT_Grades_List = 1138,
        ECT_Completion = 1147,
        ECT_Enrolled_Statistics = 1148,
        ECT_GPA_Statistics = 1149,
        ECT_Attrition_Rate = 1151,
        ECT_Major_History = 1152,
        ECT_Programs_Advisors = 1158,
        ECT_Registration = 1159,
        ECT_Avg_Courses=1160,
        ECT_LecturerOfficeHours = 1161,
        ECT_StudentsBooks = 1163,
        ECT_MajorCourse = 1164,
        ECT_AlternativeSetup=1165,
        ECT_StudentStauts = 1166,
        ECT_ChangingStatus=1167,
        ECT_Committee = 1168,
        ECT_EngTestList=1183,
        ECT_FinalExam=1184,
        ECT_FinalExamConflics = 1185,
        ECT_FinalExamCoursesCounts =1186,
        ECT_MissingDocuments = 1187,
        ECT_Printing_Request=1188,
        ECT_Printing_Request_Download=1189,
        ECT_DataAuditing=1190,
        ECT_VerfiyTOEFL_HS=1191,
        ECT_GradesAudit = 1192,
        ECT_GraduatesSetting=1193,
        ECT_StudentCenter=1194,
        ECT_Graduated_AMRICON=1195,
        ECT_Security_Reports=1196,
        ECT_Roles_Permissions = 1197,
        ECT_EnrolledStudents_Embassy=1203,
        ECT_TOEFL_IELTS_Exams=1209,
        ECT_SendEmail = 1211,
        ECT_ProgramsTargets=1212,
        ECT_AllStudentsAtRisk=1213,
        ECT_AdvisingSetting=1217,
        ECT_SMS_Request = 1218,
        ECT_SMS_Request_View = 1219,
        ECT_Registration_Tracking=1220,
        ECT_Cohort_Tracking=1224,
        ECT_Graduaes_Tracking = 1225,
        ECT_Registered_Tracking=1226,
        ECT_PC_Daily_Checkup = 1227,
        ECT_PC_Check_Tracking = 1228,
        ECT_Applicants_Tracking = 1229,
        ECT_Reg_Balance=1230,
        ECT_Reg_Fees = 1231,
        ECT_Reg_Discount = 1232,
        ECT_Balance_Tracking = 1233,
        ECT_PhonesExtensions=1234,
        ECT_Daily_Receipt = 1235,
        ECT_TransferBooks=1238,
        ECT_MyTimeTable=1239,
        ECT_ACMS=1240,
        ECT_ActiveEmployees=1241,
        ECT_AccessDoors=1242,
        ECT_AccessDoorsCategories=1243,
        ECT_CancelBooks = 1244,
        ECT_ACMS_Transactions=1245,
        ECT_ACMS_AttendanceReport = 1246,
        ECT_ACMS_Users = 1247,
        ECT_Surveys = 1248,
        ECT_Payment=1253,
     
        //ECT Library
        Lib_Authers = 1093,
        Lib_Places = 1094,
        Lib_Publishers = 1095,
        Lib_Classifications = 1096,
        Lib_Supplier = 1097,
        Lib_BookStatus = 1098,
        Lib_TransType = 1099,
        Lib_Book = 1103,
        Lib_BookSearch = 1104,
        Lib_JourFreq = 1105,
        Lib_AuthorRole = 1108,
        Lib_Material = 1110,
        Lib_Subject = 1111,
        Lib_Series = 1116,
        Lib_Transaction = 1118,
        Lib_PrintBarcode = 1122,
        Lib_RepBookUsers = 1128,
        Lib_RepBookClass = 1129,
        Lib_RepBookTrans = 1130,
        Lib_RepBookBorrowed = 1131,

        Sto_BookStu = 1162,
        Sto_PurchaseInvoice = 1210,

        ECT_StudentWarning = 1112,
        ECT_Current_TimeTable = 1113,
        ECT_ACC_Search=1199,
        
        
        //ECT Security
        ECT_MapsManager = 1018,
        ECT_RolesManager = 1019,
        ECT_UsersSetup = 1020,
        ECT_ChangePassword = 1021,
        ECT_TimeSheetRpt = 1084,
        ECT_SetInstructorPc=1200,
        ECT_PA_Transcript = 1202,
        ECT_PA_Registration = 1205,
        ECT_PA_Advising = 1206,
        ECT_PA_TimeTable = 1207,

        //ACMS
        ECT_Active_Employees = 1241,
        ECT_Access = 1242,
        ECT_Access_Categories = 1243

    }

    public enum enumEmployeeGroups : int
    {
        Administrative = 1,
        Academic = 2
    }

    public enum enumModes : int
    {
        VeiwMode = 1,
        NewMode = 2,
        EditMode = 3,
        SaveMode = 4,
        FormSheetMode = 5
    }

    public enum enumTruevalue : int
    {
        TrueValue = 1,
        FalseValue = 0
    }

    public enum enumLookupType : int
    {
        //map lookup major id 
        Semester = 10,
        IDType = 15,
        MissingDocuments = 20,
        WarningType = 25,
        Religion = 30,
        College = 40,
        ForeignColleges = 45,
        Degree = 50,
        Specialization = 60,
        DayOfWeek = 70,
        Days = 75,
        MaritalStatus = 80,
        Gender = 85,
        CountryGroup = 90,
        Status = 100,

        CertificateType = 120,

        CertificateSource = 130,
        GradeCalculationType = 140,
        CourseClasses = 150,
        QualificationType = 165,

        ECTSystems = 200,
        MirrorStatus = 300,

        ExperienceType = 135,
        StudyType = 160,
        Grade = 170,
        BloodType = 310,
        SuspendReason = 320,
        EndReason = 330,
        EmployeeGroup = 340,

        Department = 360,
        RelationShip = 370,
        NoteType = 380,


        Building = 400,
        Campus = 401,
        HallType = 500,

        Hr_Shift = 600,
        AttendanceTerminal = 605,
        HR_ShiftTimes,

        AttendProcedureType = 610,
        Language = 1200,
        PermissionType = 2000,

        PaymentWay = 700,
        SalaryPaymentType = 750,

        LetterSubject = 760,

        DeductionType = 800,
        HRWarningType = 820,
        PunishmentType = 850,
        GradeCircle = 900,
        PayFrequency = 950,
        PayYear = 940,

        MainConcerned = 3000,
        CRMStatus = 3003,
        CRMReferences = 3004,
        CRMStaff=3005,
        CRMEntryType=3006,

        TransferTo,


        Lkp_Country,
        Lkp_City,
        Lkp_Hall,
        Lkp_Session,
        Lkp_GradeTypes,
        Lkp_VacationTypes,
        Lkp_Holiday,
        Lkp_Certificate,
        Lkp_Nationality,
        Lkp_JobTitle,
        Lkp_CallerConcerned,

        Cmn_Currency,
        PR_Bonus,
        PR_Grades,
        Hr_InsuraneCompany,
        Hr_Employee,

        Reg_Semester,
        Reg_GradeSystem,
        Reg_Lecturers,

        Reg_Course,
        Reg_CourseFull,
        Reg_CourseCodeOnly,

        Reg_Student,
        Acc_StudentAccount,
        Acc_FeesType,
        Acc_Banks

    }

    public enum ECT_Buttons : int
    {
        Print = 0,
        ToExcel = 1,
        ToWord = 2,
        Run = 3,
        New = 4,
        Save = 5,
        Delete = 6,
        Setting = 7
    }

    public enum enumRequestedFormTypes : int
    {
        ChangeMajorForm = 4,
        IncompleteGradeForm = 5,
        WithdrawalFromCourseForm = 6,
        PetitionForm = 7,
        GraduationForm = 8,
        EnforcedWithdrawalForm = 9

    }
    public enum enumG12Stream : int
    {
        Not_Applicable = 0,
        Advanced = 1,
        General = 2,
        Science = 3,
        Arts = 4,
        ADEC = 5

    }
     public enum enumHSSystem : int
    {
        Other = 0,
        MOE = 1,
        American = 2,
        Australian = 3,
        Bangladeshi = 4,
        British = 5,
        Canadian =6,
        CBSE =7,
        ENC =8,
        French =9,
        German =10,
        Indian =11,
        International_Baccalaureate =12,
        Iranian =13,
        Japanese =14,
        Pakistani =15,
        Philippines =16,
        Russian =17,
        SABIS =18,
        Singapore =19
    }
    public enum enumHS_Major : int
    {
        Generalsecondaryschool	=1	,
	    Diploma	=2,
	    Sience	=3,
	    Literary=4,
	    Accounting=7,
	    Technical=8,
	    Marketing=9,
	    InformationTechnology=11,
	    Commercial=14,
	    Industrial=15,
	    Agricultural=16,
	    Other=12,
	    HRM=13,
	    AppliedTechnology=17,
	    AdvanceStream=19,
	    GeneralStream=20,
	    ADECStream=21,
	    Enjaz=18
    }
}
