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
using System.Collections.Generic;
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Applications
{
//Creation Date: 28/02/2010 8:59:37 AM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private string m_strApplicationNumber; 
private string m_lngStudentNumber; 
private DateTime m_dateApplication; 
private int m_lngSerial; 
private string m_strCollege; 
private string m_strDegree; 
private string m_strSpecialization; 
private int m_WantedMajorID;
private int m_WantedMajorID2;
private int m_WantedMajorID3;
private int m_byteSemester; 
private string m_bOwnAccount; 
private string m_bAccepted; 
private DateTime m_dateAccepted; 
private string m_strDecisionNumber; 
private int m_intGraduationYear; 
private int m_byteGraduationSemester; 
private int m_byteCancelReason; 
private int m_byteMainReason; 
private int m_byteSubReason; 
private string m_strNotes; 
private int m_byteMinGPA; 
private string m_bActive; 
private string m_bContinue; 
private string m_strGraduation; 
private string m_dateGraduation1; 
private DateTime m_dateGraduation2; 
private int m_lngTransaction; 
private string m_bOtherCollege; 
private int m_byteRefCollege; 
private string m_strAccountNo; 
private int m_intAdvisor; 
private string m_strCancelNote; 
private int m_byteStudentType;
private int m_IsCompleteBAFromOtherInstitution;
private int m_IsCompleteMasterFromOtherInstitution;
private int m_iEnrollmentSource;
private int m_iEnrollmentSource2;
private string m_sEnrollmentNotes;
private int m_iRegisteredThrough;
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int intStudyYear
{
get { return  m_intStudyYear; }
set {m_intStudyYear  = value ; }
}
public string strApplicationNumber
{
get { return  m_strApplicationNumber; }
set {m_strApplicationNumber  = value ; }
}
public string lngStudentNumber
{
get { return  m_lngStudentNumber; }
set {m_lngStudentNumber  = value ; }
}
public DateTime dateApplication
{
get { return  m_dateApplication; }
set {m_dateApplication  = value ; }
}
public int lngSerial
{
get { return  m_lngSerial; }
set {m_lngSerial  = value ; }
}
public string strCollege
{
get { return  m_strCollege; }
set {m_strCollege  = value ; }
}
public string strDegree
{
get { return  m_strDegree; }
set {m_strDegree  = value ; }
}
public string strSpecialization
{
get { return  m_strSpecialization; }
set {m_strSpecialization  = value ; }
}
public int WantedMajorID
{
get { return  m_WantedMajorID; }
set {m_WantedMajorID  = value ; }
}
public int WantedMajorID2
{
    get { return m_WantedMajorID2; }
    set { m_WantedMajorID2 = value; }
}
public int WantedMajorID3
{
    get { return m_WantedMajorID3; }
    set { m_WantedMajorID3 = value; }
}
public int byteSemester
{
get { return  m_byteSemester; }
set {m_byteSemester  = value ; }
}
public string bOwnAccount
{
get { return  m_bOwnAccount; }
set {m_bOwnAccount  = value ; }
}
public string bAccepted
{
get { return  m_bAccepted; }
set {m_bAccepted  = value ; }
}
public DateTime dateAccepted
{
get { return  m_dateAccepted; }
set {m_dateAccepted  = value ; }
}
public string strDecisionNumber
{
get { return  m_strDecisionNumber; }
set {m_strDecisionNumber  = value ; }
}
public int intGraduationYear
{
get { return  m_intGraduationYear; }
set {m_intGraduationYear  = value ; }
}
public int byteGraduationSemester
{
get { return  m_byteGraduationSemester; }
set {m_byteGraduationSemester  = value ; }
}
public int byteCancelReason
{
get { return  m_byteCancelReason; }
set {m_byteCancelReason  = value ; }
}
public int byteMainReason
{
get { return  m_byteMainReason; }
set {m_byteMainReason  = value ; }
}
public int byteSubReason
{
get { return  m_byteSubReason; }
set {m_byteSubReason  = value ; }
}
public string strNotes
{
get { return  m_strNotes; }
set {m_strNotes  = value ; }
}
public int byteMinGPA
{
get { return  m_byteMinGPA; }
set {m_byteMinGPA  = value ; }
}
public string bActive
{
get { return  m_bActive; }
set {m_bActive  = value ; }
}
public string bContinue
{
get { return  m_bContinue; }
set {m_bContinue  = value ; }
}
public string strGraduation
{
get { return  m_strGraduation; }
set {m_strGraduation  = value ; }
}
public string dateGraduation1
{
get { return  m_dateGraduation1; }
set {m_dateGraduation1  = value ; }
}
public DateTime dateGraduation2
{
get { return  m_dateGraduation2; }
set {m_dateGraduation2  = value ; }
}
public int lngTransaction
{
get { return  m_lngTransaction; }
set {m_lngTransaction  = value ; }
}
public string bOtherCollege
{
get { return  m_bOtherCollege; }
set {m_bOtherCollege  = value ; }
}
public int byteRefCollege
{
get { return  m_byteRefCollege; }
set {m_byteRefCollege  = value ; }
}
public string strAccountNo
{
get { return  m_strAccountNo; }
set {m_strAccountNo  = value ; }
}
public int intAdvisor
{
get { return  m_intAdvisor; }
set {m_intAdvisor  = value ; }
}
public string strCancelNote
{
get { return  m_strCancelNote; }
set {m_strCancelNote  = value ; }
}
public int byteStudentType
{
get { return  m_byteStudentType; }
set {m_byteStudentType  = value ; }
}
public int IsCompleteBAFromOtherInstitution
{
get { return  m_IsCompleteBAFromOtherInstitution; }
set {m_IsCompleteBAFromOtherInstitution  = value ; }
}
public int IsCompleteMasterFromOtherInstitution
{
get { return  m_IsCompleteMasterFromOtherInstitution; }
set {m_IsCompleteMasterFromOtherInstitution  = value ; }
}
public int iEnrollmentSource
{
get { return  m_iEnrollmentSource; }
set {m_iEnrollmentSource  = value ; }
}
public int iEnrollmentSource2
{
    get { return m_iEnrollmentSource2; }
    set { m_iEnrollmentSource2 = value; }
}
public int iRegisteredThrough
{
    get { return m_iRegisteredThrough; }
    set { m_iRegisteredThrough = value; }
}

public string sEnrollmentNotes
{
get { return  m_sEnrollmentNotes; }
set {m_sEnrollmentNotes  = value ; }
}
public string strUserCreate
{
get { return  m_strUserCreate; }
set {m_strUserCreate  = value ; }
}
public DateTime dateCreate
{
get { return  m_dateCreate; }
set {m_dateCreate  = value ; }
}
public string strUserSave
{
get { return  m_strUserSave; }
set {m_strUserSave  = value ; }
}
public DateTime dateLastSave
{
get { return  m_dateLastSave; }
set {m_dateLastSave  = value ; }
}
public string strMachine
{
get { return  m_strMachine; }
set {m_strMachine  = value ; }
}
public string strNUser
{
get { return  m_strNUser; }
set {m_strNUser  = value ; }
}
#endregion
//'-----------------------------------------------------
public Applications()
{
try
{
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
//end first class
}
public class ApplicationsDAL : Applications
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_strApplicationNumberFN ;
private string m_lngStudentNumberFN ;
private string m_dateApplicationFN ;
private string m_lngSerialFN ;
private string m_strCollegeFN ;
private string m_strDegreeFN ;
private string m_strSpecializationFN ;
private string m_WantedMajorIDFN ;
private string m_WantedMajorID2FN;
private string m_WantedMajorID3FN;
private string m_byteSemesterFN ;
private string m_bOwnAccountFN ;
private string m_bAcceptedFN ;
private string m_dateAcceptedFN ;
private string m_strDecisionNumberFN ;
private string m_intGraduationYearFN ;
private string m_byteGraduationSemesterFN ;
private string m_byteCancelReasonFN ;
private string m_byteMainReasonFN ;
private string m_byteSubReasonFN ;
private string m_strNotesFN ;
private string m_byteMinGPAFN ;
private string m_bActiveFN ;
private string m_bContinueFN ;
private string m_strGraduationFN ;
private string m_dateGraduation1FN ;
private string m_dateGraduation2FN ;
private string m_lngTransactionFN ;
private string m_bOtherCollegeFN ;
private string m_byteRefCollegeFN ;
private string m_strAccountNoFN ;
private string m_intAdvisorFN ;
private string m_strCancelNoteFN ;
private string m_byteStudentTypeFN ;
private string m_IsCompleteBAFromOtherInstitutionFN;
private string m_IsCompleteMasterFromOtherInstitutionFN;
    
private string m_iEnrollmentSourceFN;
private string m_iEnrollmentSource2FN;
private string m_iRegisteredThroughFN;
private string m_sEnrollmentNotesFN;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string intStudyYearFN 
{
get { return  m_intStudyYearFN; }
set {m_intStudyYearFN  = value ; }
}
public string strApplicationNumberFN 
{
get { return  m_strApplicationNumberFN; }
set {m_strApplicationNumberFN  = value ; }
}
public string lngStudentNumberFN 
{
get { return  m_lngStudentNumberFN; }
set {m_lngStudentNumberFN  = value ; }
}
public string dateApplicationFN 
{
get { return  m_dateApplicationFN; }
set {m_dateApplicationFN  = value ; }
}
public string lngSerialFN 
{
get { return  m_lngSerialFN; }
set {m_lngSerialFN  = value ; }
}
public string strCollegeFN 
{
get { return  m_strCollegeFN; }
set {m_strCollegeFN  = value ; }
}
public string strDegreeFN 
{
get { return  m_strDegreeFN; }
set {m_strDegreeFN  = value ; }
}
public string strSpecializationFN 
{
get { return  m_strSpecializationFN; }
set {m_strSpecializationFN  = value ; }
}
public string WantedMajorIDFN 
{
get { return  m_WantedMajorIDFN; }
set {m_WantedMajorIDFN  = value ; }
}
public string WantedMajorID2FN
{
    get { return m_WantedMajorID2FN; }
    set { m_WantedMajorID2FN = value; }
}
public string WantedMajorID3FN
{
    get { return m_WantedMajorID3FN; }
    set { m_WantedMajorID3FN = value; }
}
public string byteSemesterFN 
{
get { return  m_byteSemesterFN; }
set {m_byteSemesterFN  = value ; }
}
public string bOwnAccountFN 
{
get { return  m_bOwnAccountFN; }
set {m_bOwnAccountFN  = value ; }
}
public string bAcceptedFN 
{
get { return  m_bAcceptedFN; }
set {m_bAcceptedFN  = value ; }
}
public string dateAcceptedFN 
{
get { return  m_dateAcceptedFN; }
set {m_dateAcceptedFN  = value ; }
}
public string strDecisionNumberFN 
{
get { return  m_strDecisionNumberFN; }
set {m_strDecisionNumberFN  = value ; }
}
public string intGraduationYearFN 
{
get { return  m_intGraduationYearFN; }
set {m_intGraduationYearFN  = value ; }
}
public string byteGraduationSemesterFN 
{
get { return  m_byteGraduationSemesterFN; }
set {m_byteGraduationSemesterFN  = value ; }
}
public string byteCancelReasonFN 
{
get { return  m_byteCancelReasonFN; }
set {m_byteCancelReasonFN  = value ; }
}
public string byteMainReasonFN 
{
get { return  m_byteMainReasonFN; }
set {m_byteMainReasonFN  = value ; }
}
public string byteSubReasonFN 
{
get { return  m_byteSubReasonFN; }
set {m_byteSubReasonFN  = value ; }
}
public string strNotesFN 
{
get { return  m_strNotesFN; }
set {m_strNotesFN  = value ; }
}
public string byteMinGPAFN 
{
get { return  m_byteMinGPAFN; }
set {m_byteMinGPAFN  = value ; }
}
public string bActiveFN 
{
get { return  m_bActiveFN; }
set {m_bActiveFN  = value ; }
}
public string bContinueFN 
{
get { return  m_bContinueFN; }
set {m_bContinueFN  = value ; }
}
public string strGraduationFN 
{
get { return  m_strGraduationFN; }
set {m_strGraduationFN  = value ; }
}
public string dateGraduation1FN 
{
get { return  m_dateGraduation1FN; }
set {m_dateGraduation1FN  = value ; }
}
public string dateGraduation2FN 
{
get { return  m_dateGraduation2FN; }
set {m_dateGraduation2FN  = value ; }
}
public string lngTransactionFN 
{
get { return  m_lngTransactionFN; }
set {m_lngTransactionFN  = value ; }
}
public string bOtherCollegeFN 
{
get { return  m_bOtherCollegeFN; }
set {m_bOtherCollegeFN  = value ; }
}
public string byteRefCollegeFN 
{
get { return  m_byteRefCollegeFN; }
set {m_byteRefCollegeFN  = value ; }
}
public string strAccountNoFN 
{
get { return  m_strAccountNoFN; }
set {m_strAccountNoFN  = value ; }
}
public string intAdvisorFN 
{
get { return  m_intAdvisorFN; }
set {m_intAdvisorFN  = value ; }
}
public string strCancelNoteFN 
{
get { return  m_strCancelNoteFN; }
set {m_strCancelNoteFN  = value ; }
}
public string byteStudentTypeFN 
{
get { return  m_byteStudentTypeFN; }
set {m_byteStudentTypeFN  = value ; }
}

public string IsCompleteBAFromOtherInstitutionFN 
{
get { return  m_IsCompleteBAFromOtherInstitutionFN; }
set {m_IsCompleteBAFromOtherInstitutionFN  = value ; }
}
public string IsCompleteMasterFromOtherInstitutionFN 
{
get { return  m_IsCompleteMasterFromOtherInstitutionFN; }
set {m_IsCompleteMasterFromOtherInstitutionFN  = value ; }
}
    
public string iEnrollmentSourceFN 
{
get { return  m_iEnrollmentSourceFN; }
set {m_iEnrollmentSourceFN  = value ; }
}
public string iEnrollmentSource2FN
{
    get { return m_iEnrollmentSource2FN; }
    set { m_iEnrollmentSource2FN = value; }
}
public string iRegisteredThroughFN
{
    get { return m_iRegisteredThroughFN; }
    set { m_iRegisteredThroughFN = value; }
}  
public string sEnrollmentNotesFN 
{
get { return  m_sEnrollmentNotesFN; }
set {m_sEnrollmentNotesFN  = value ; }
}
public string strUserCreateFN 
{
get { return  m_strUserCreateFN; }
set {m_strUserCreateFN  = value ; }
}
public string dateCreateFN 
{
get { return  m_dateCreateFN; }
set {m_dateCreateFN  = value ; }
}
public string strUserSaveFN 
{
get { return  m_strUserSaveFN; }
set {m_strUserSaveFN  = value ; }
}
public string dateLastSaveFN 
{
get { return  m_dateLastSaveFN; }
set {m_dateLastSaveFN  = value ; }
}
public string strMachineFN 
{
get { return  m_strMachineFN; }
set {m_strMachineFN  = value ; }
}
public string strNUserFN 
{
get { return  m_strNUserFN; }
set {m_strNUserFN  = value ; }
}
#endregion
//================End Properties ===================
public ApplicationsDAL()
{
try
{
this.TableName = "Reg_Applications";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.strApplicationNumberFN = m_TableName + ".strApplicationNumber";
this.lngStudentNumberFN = m_TableName + ".lngStudentNumber";
this.dateApplicationFN = m_TableName + ".dateApplication";
this.lngSerialFN = m_TableName + ".lngSerial";
this.strCollegeFN = m_TableName + ".strCollege";
this.strDegreeFN = m_TableName + ".strDegree";
this.strSpecializationFN = m_TableName + ".strSpecialization";
this.WantedMajorIDFN = m_TableName + ".WantedMajorID";
this.WantedMajorID2FN = m_TableName + ".WantedMajorID2";
this.WantedMajorID3FN = m_TableName + ".WantedMajorID3";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.bOwnAccountFN = m_TableName + ".bOwnAccount";
this.bAcceptedFN = m_TableName + ".bAccepted";
this.dateAcceptedFN = m_TableName + ".dateAccepted";
this.strDecisionNumberFN = m_TableName + ".strDecisionNumber";
this.intGraduationYearFN = m_TableName + ".intGraduationYear";
this.byteGraduationSemesterFN = m_TableName + ".byteGraduationSemester";
this.byteCancelReasonFN = m_TableName + ".byteCancelReason";
this.byteMainReasonFN = m_TableName + ".byteMainReason";
this.byteSubReasonFN = m_TableName + ".byteSubReason";
this.strNotesFN = m_TableName + ".strNotes";
this.byteMinGPAFN = m_TableName + ".byteMinGPA";
this.bActiveFN = m_TableName + ".bActive";
this.bContinueFN = m_TableName + ".bContinue";
this.strGraduationFN = m_TableName + ".strGraduation";
this.dateGraduation1FN = m_TableName + ".dateGraduation1";
this.dateGraduation2FN = m_TableName + ".dateGraduation2";
this.lngTransactionFN = m_TableName + ".lngTransaction";
this.bOtherCollegeFN = m_TableName + ".bOtherCollege";
this.byteRefCollegeFN = m_TableName + ".byteRefCollege";
this.strAccountNoFN = m_TableName + ".strAccountNo";
this.intAdvisorFN = m_TableName + ".intAdvisor";
this.strCancelNoteFN = m_TableName + ".strCancelNote";
this.byteStudentTypeFN = m_TableName + ".byteStudentType";
this.IsCompleteBAFromOtherInstitutionFN = m_TableName + ".IsCompleteBAFromOtherInstitution";
this.IsCompleteMasterFromOtherInstitutionFN = m_TableName + ".IsCompleteMasterFromOtherInstitution";
this.iEnrollmentSourceFN = m_TableName + ".iEnrollmentSource";
this.iEnrollmentSource2FN = m_TableName + ".iEnrollmentSource2";
this.iRegisteredThroughFN  = m_TableName + ".iRegisteredThrough";
this.sEnrollmentNotesFN = m_TableName + ".sEnrollmentNotes";

this.strUserCreateFN = m_TableName + ".strUserCreate";
this.dateCreateFN = m_TableName + ".dateCreate";
this.strUserSaveFN = m_TableName + ".strUserSave";
this.dateLastSaveFN = m_TableName + ".dateLastSave";
this.strMachineFN = m_TableName + ".strMachine";
this.strNUserFN = m_TableName + ".strNUser";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
#region "Data Access Layer"
//-----Get SQl Function ---------------------------------
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL += intStudyYearFN;
sSQL += " , " + strApplicationNumberFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + dateApplicationFN;
sSQL += " , " + lngSerialFN;
sSQL += " , " + strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strSpecializationFN;
sSQL += " , " + WantedMajorIDFN;
sSQL += " , " + WantedMajorID2FN;
sSQL += " , " + WantedMajorID3FN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + bOwnAccountFN;
sSQL += " , " + bAcceptedFN;
sSQL += " , " + dateAcceptedFN;
sSQL += " , " + strDecisionNumberFN;
sSQL += " , " + intGraduationYearFN;
sSQL += " , " + byteGraduationSemesterFN;
sSQL += " , " + byteCancelReasonFN;
sSQL += " , " + byteMainReasonFN;
sSQL += " , " + byteSubReasonFN;
sSQL += " , " + strNotesFN;
sSQL += " , " + byteMinGPAFN;
sSQL += " , " + bActiveFN;
sSQL += " , " + bContinueFN;
sSQL += " , " + strGraduationFN;
sSQL += " , " + dateGraduation1FN;
sSQL += " , " + dateGraduation2FN;
sSQL += " , " + lngTransactionFN;
sSQL += " , " + bOtherCollegeFN;
sSQL += " , " + byteRefCollegeFN;
sSQL += " , " + strAccountNoFN;
sSQL += " , " + intAdvisorFN;
sSQL += " , " + strCancelNoteFN;
sSQL += " , " + byteStudentTypeFN;
sSQL += " , " + IsCompleteBAFromOtherInstitutionFN;
sSQL += " , " + IsCompleteMasterFromOtherInstitutionFN;
sSQL += " , " + iEnrollmentSourceFN;
sSQL += " , " + iEnrollmentSource2FN;
sSQL += " , " + sEnrollmentNotesFN;
sSQL += " , " + iRegisteredThroughFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += "  FROM " + m_TableName;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}

public string GetListSQL(string sCondition)
{
    string sSQL = "";
    try
    {
        sSQL = "SELECT ";
        sSQL += lngStudentNumberFN;
        sSQL += " , " + lngSerialFN;
        sSQL += " , " + strCollegeFN;
        sSQL += " , " + strDegreeFN;
        sSQL += " , " + strSpecializationFN;
        sSQL += " , " + intStudyYearFN;
        sSQL += " , " + byteSemesterFN;
        sSQL += "  FROM " + m_TableName;
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL+=" Where "+sCondition;
        }
    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
    return sSQL;
}

public List<Applications> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
    
    //' returns a list of Classes instances based on the
    //' data in the Lecturers
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL(sCondition);

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Applications> results = new List<Applications>();
    try
    {
        //Default Value
        Applications myStudents = new Applications();
        if (isDeafaultIncluded)
        {
            //Change the code here
            myStudents.lngStudentNumber = "Select Student";
            myStudents.lngSerial = 0;
            myStudents.strCollege = "00";
            myStudents.strDegree = "00";
            myStudents.strSpecialization = "00";
            myStudents.intStudyYear = 0;
            myStudents.byteSemester = 0;
            
            results.Add(myStudents);
        }

        while (reader.Read())
        {
            myStudents = new Applications();
            myStudents.lngStudentNumber = reader[LibraryMOD.GetFieldName(lngStudentNumberFN)].ToString();
            myStudents.lngSerial = int.Parse(reader[LibraryMOD.GetFieldName(lngSerialFN)].ToString());
            myStudents.strCollege = reader[LibraryMOD.GetFieldName(strCollegeFN)].ToString();
            myStudents.strDegree = reader[LibraryMOD.GetFieldName(strDegreeFN)].ToString();
            myStudents.strSpecialization  = reader[LibraryMOD.GetFieldName(strSpecializationFN)].ToString();
            
            if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
            {
                myStudents.intStudyYear = 0;
            }
            else
            {
                myStudents.intStudyYear =int.Parse( reader[LibraryMOD.GetFieldName(intStudyYearFN)].ToString());
            }

            if (reader[LibraryMOD.GetFieldName(byteSemesterFN )].Equals(DBNull.Value))
            {
                myStudents.byteSemester = 0;
            }
            else
            {
                myStudents.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName(byteSemesterFN)].ToString());
            }

            results.Add(myStudents);
        }
    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        reader.Close();
        reader.Dispose();
        Conn.Close();
        Conn.Dispose();
    }
    return results;
}
public int GetSerial(InitializeModule.EnumCampus Campus, string sID)
{

    int iSerial = 0;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL("lngStudentNumber='" + sID +"'");

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    try
    {
        while (reader.Read())
        {
            iSerial = int.Parse(reader["lngSerial"].ToString());
        }
    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        reader.Close();
        reader.Dispose();
        Conn.Close();
        Conn.Dispose();
    }
    return iSerial;
}
public string  GetDegree(InitializeModule.EnumCampus Campus, string sID)
{

    string sDegree ="";
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL("lngStudentNumber='" + sID + "'");

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    try
    {
        while (reader.Read())
        {
            sDegree = reader["strDegree"].ToString();
        }
    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        reader.Close();
        reader.Dispose();
        Conn.Close();
        Conn.Dispose();
    }
    return sDegree;
}
public string GetMajor(InitializeModule.EnumCampus Campus, string sID)
{

    string sMajor = "";
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    string sSQL = GetListSQL("lngStudentNumber='" + sID + "'");

    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    try
    {
        while (reader.Read())
        {
            sMajor = reader["strSpecialization"].ToString();
        }
    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        reader.Close();
        reader.Dispose();
        Conn.Close();
        Conn.Dispose();
    }
    return sMajor;
}

//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=intStudyYearFN;
sSQL += " , " + strApplicationNumberFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + dateApplicationFN;
sSQL += " , " + lngSerialFN;
sSQL += " , " + strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strSpecializationFN;
sSQL += " , " + WantedMajorIDFN;
sSQL += " , " + WantedMajorID2FN;
sSQL += " , " + WantedMajorID3FN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + bOwnAccountFN;
sSQL += " , " + bAcceptedFN;
sSQL += " , " + dateAcceptedFN;
sSQL += " , " + strDecisionNumberFN;
sSQL += " , " + intGraduationYearFN;
sSQL += " , " + byteGraduationSemesterFN;
sSQL += " , " + byteCancelReasonFN;
sSQL += " , " + byteMainReasonFN;
sSQL += " , " + byteSubReasonFN;
sSQL += " , " + strNotesFN;
sSQL += " , " + byteMinGPAFN;
sSQL += " , " + bActiveFN;
sSQL += " , " + bContinueFN;
sSQL += " , " + strGraduationFN;
sSQL += " , " + dateGraduation1FN;
sSQL += " , " + dateGraduation2FN;
sSQL += " , " + lngTransactionFN;
sSQL += " , " + bOtherCollegeFN;
sSQL += " , " + byteRefCollegeFN;
sSQL += " , " + strAccountNoFN;
sSQL += " , " + intAdvisorFN;
sSQL += " , " + strCancelNoteFN;
sSQL += " , " + byteStudentTypeFN;
sSQL += " , " + IsCompleteBAFromOtherInstitutionFN;
sSQL += " , " + IsCompleteMasterFromOtherInstitutionFN;
sSQL += " , " + iEnrollmentSourceFN;
sSQL += " , " + iEnrollmentSource2FN;
sSQL += " , " + sEnrollmentNotesFN;
sSQL += " , " + iRegisteredThroughFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += "  FROM " + m_TableName;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
//-----Get GetUpdateCommand Function -----------------------
public string GetUpdateCommand()  
{
string sSQL  = "";
try
{
sSQL = "UPDATE " + TableName;
sSQL += " SET ";
sSQL += LibraryMOD.GetFieldName(intStudyYearFN) + "=@intStudyYear";
sSQL += " , " + LibraryMOD.GetFieldName(strApplicationNumberFN) + "=@strApplicationNumber";
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
sSQL += " , " + LibraryMOD.GetFieldName(dateApplicationFN) + "=@dateApplication";
sSQL += " , " + LibraryMOD.GetFieldName(lngSerialFN) + "=@lngSerial";
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
sSQL += " , " + LibraryMOD.GetFieldName(WantedMajorIDFN) + "=@WantedMajorID";
sSQL += " , " + LibraryMOD.GetFieldName(WantedMajorID2FN) + "=@WantedMajorID2";
sSQL += " , " + LibraryMOD.GetFieldName(WantedMajorID3FN) + "=@WantedMajorID3";
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
sSQL += " , " + LibraryMOD.GetFieldName(bOwnAccountFN) + "=@bOwnAccount";
sSQL += " , " + LibraryMOD.GetFieldName(bAcceptedFN) + "=@bAccepted";
sSQL += " , " + LibraryMOD.GetFieldName(dateAcceptedFN) + "=@dateAccepted";
sSQL += " , " + LibraryMOD.GetFieldName(strDecisionNumberFN) + "=@strDecisionNumber";
sSQL += " , " + LibraryMOD.GetFieldName(intGraduationYearFN) + "=@intGraduationYear";
sSQL += " , " + LibraryMOD.GetFieldName(byteGraduationSemesterFN) + "=@byteGraduationSemester";
sSQL += " , " + LibraryMOD.GetFieldName(byteCancelReasonFN) + "=@byteCancelReason";
sSQL += " , " + LibraryMOD.GetFieldName(byteMainReasonFN) + "=@byteMainReason";
sSQL += " , " + LibraryMOD.GetFieldName(byteSubReasonFN) + "=@byteSubReason";
sSQL += " , " + LibraryMOD.GetFieldName(strNotesFN) + "=@strNotes";
sSQL += " , " + LibraryMOD.GetFieldName(byteMinGPAFN) + "=@byteMinGPA";
sSQL += " , " + LibraryMOD.GetFieldName(bActiveFN) + "=@bActive";
sSQL += " , " + LibraryMOD.GetFieldName(bContinueFN) + "=@bContinue";
sSQL += " , " + LibraryMOD.GetFieldName(strGraduationFN) + "=@strGraduation";
sSQL += " , " + LibraryMOD.GetFieldName(dateGraduation1FN) + "=@dateGraduation1";
sSQL += " , " + LibraryMOD.GetFieldName(dateGraduation2FN) + "=@dateGraduation2";
sSQL += " , " + LibraryMOD.GetFieldName(lngTransactionFN) + "=@lngTransaction";
sSQL += " , " + LibraryMOD.GetFieldName(bOtherCollegeFN) + "=@bOtherCollege";
sSQL += " , " + LibraryMOD.GetFieldName(byteRefCollegeFN) + "=@byteRefCollege";
sSQL += " , " + LibraryMOD.GetFieldName(strAccountNoFN) + "=@strAccountNo";
sSQL += " , " + LibraryMOD.GetFieldName(intAdvisorFN) + "=@intAdvisor";
sSQL += " , " + LibraryMOD.GetFieldName(strCancelNoteFN) + "=@strCancelNote";
sSQL += " , " + LibraryMOD.GetFieldName(byteStudentTypeFN) + "=@byteStudentType";
sSQL += " , " + LibraryMOD.GetFieldName(IsCompleteBAFromOtherInstitutionFN) + "=@IsCompleteBAFromOtherInstitution";
sSQL += " , " + LibraryMOD.GetFieldName(IsCompleteMasterFromOtherInstitutionFN) + "=@IsCompleteMasterFromOtherInstitution";
sSQL += " , " + LibraryMOD.GetFieldName(iEnrollmentSourceFN) + "=@iEnrollmentSource";
sSQL += " , " + LibraryMOD.GetFieldName(iEnrollmentSourceFN) + "=@iEnrollmentSource2";
sSQL += " , " + LibraryMOD.GetFieldName(sEnrollmentNotesFN) + "=@sEnrollmentNotes";
sSQL += " , " + LibraryMOD.GetFieldName(iRegisteredThroughFN) + "=@iRegisteredThrough";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
//-----Get GetInsertCommand Function -----------------------
public string GetInsertCommand()  
{
string sSQL= "";
try
{
sSQL = "INSERT intO "  + TableName;
sSQL += "( ";
sSQL +=LibraryMOD.GetFieldName(intStudyYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(strApplicationNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateApplicationFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngSerialFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN);
sSQL += " , " + LibraryMOD.GetFieldName(WantedMajorIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(WantedMajorID2FN);
sSQL += " , " + LibraryMOD.GetFieldName(WantedMajorID3FN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(bOwnAccountFN);
sSQL += " , " + LibraryMOD.GetFieldName(bAcceptedFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateAcceptedFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDecisionNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(intGraduationYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteGraduationSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteCancelReasonFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMainReasonFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteSubReasonFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNotesFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMinGPAFN);
sSQL += " , " + LibraryMOD.GetFieldName(bActiveFN);
sSQL += " , " + LibraryMOD.GetFieldName(bContinueFN);
sSQL += " , " + LibraryMOD.GetFieldName(strGraduationFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateGraduation1FN);
sSQL += " , " + LibraryMOD.GetFieldName(dateGraduation2FN);
sSQL += " , " + LibraryMOD.GetFieldName(lngTransactionFN);
sSQL += " , " + LibraryMOD.GetFieldName(bOtherCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteRefCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strAccountNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(intAdvisorFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCancelNoteFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteStudentTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsCompleteBAFromOtherInstitutionFN);
sSQL += " , " + LibraryMOD.GetFieldName(IsCompleteMasterFromOtherInstitutionFN);
sSQL += " , " + LibraryMOD.GetFieldName(iEnrollmentSourceFN);
sSQL += " , " + LibraryMOD.GetFieldName(iEnrollmentSource2FN);
sSQL += " , " + LibraryMOD.GetFieldName(sEnrollmentNotesFN);
sSQL += " , " + LibraryMOD.GetFieldName(iRegisteredThroughFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intStudyYear";
sSQL += " ,@strApplicationNumber";
sSQL += " ,@lngStudentNumber";
sSQL += " ,@dateApplication";
sSQL += " ,@lngSerial";
sSQL += " ,@strCollege";
sSQL += " ,@strDegree";
sSQL += " ,@strSpecialization";
sSQL += " ,@WantedMajorID";
sSQL += " ,@byteSemester";
sSQL += " ,@bOwnAccount";
sSQL += " ,@bAccepted";
sSQL += " ,@dateAccepted";
sSQL += " ,@strDecisionNumber";
sSQL += " ,@intGraduationYear";
sSQL += " ,@byteGraduationSemester";
sSQL += " ,@byteCancelReason";
sSQL += " ,@byteMainReason";
sSQL += " ,@byteSubReason";
sSQL += " ,@strNotes";
sSQL += " ,@byteMinGPA";
sSQL += " ,@bActive";
sSQL += " ,@bContinue";
sSQL += " ,@strGraduation";
sSQL += " ,@dateGraduation1";
sSQL += " ,@dateGraduation2";
sSQL += " ,@lngTransaction";
sSQL += " ,@bOtherCollege";
sSQL += " ,@byteRefCollege";
sSQL += " ,@strAccountNo";
sSQL += " ,@intAdvisor";
sSQL += " ,@strCancelNote";
sSQL += " ,@byteStudentType";
sSQL += " ,@IsCompleteBAFromOtherInstitution";
sSQL += " ,@IsCompleteMasterFromOtherInstitution";
sSQL += " ,@iEnrollmentSource";
sSQL += " ,@iEnrollmentSource2";
sSQL += " ,@sEnrollmentNotes";
sSQL += " ,@iRegisteredThrough";
sSQL += " ,@strUserCreate";
sSQL += " ,@dateCreate";
sSQL += " ,@strUserSave";
sSQL += " ,@dateLastSave";
sSQL += " ,@strMachine";
sSQL += " ,@strNUser";
sSQL += ") ";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
//-----Get GetDeleteCommand Function -----------------------
public string  GetDeleteCommand()
{
string sSQL= "";
try
{
sSQL = "DELETE FROM "  + TableName;
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(lngSerialFN) + "=@lngSerial";
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return sSQL;
}
#endregion
public List< Applications> GetApplications(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Applications
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string  sSQL = GetSQL();
if (!string.IsNullOrEmpty(sCondition))
{
sSQL += sCondition;
}
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<Applications> results = new List<Applications>();
try
{
//Default Value
Applications myApplications = new Applications();
if (isDeafaultIncluded)
{
//Change the code here
myApplications.strApplicationNumber = "0";
myApplications.strApplicationNumber = "Select Applications ...";
results.Add(myApplications);
}
while (reader.Read())
{
myApplications = new Applications();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myApplications.intStudyYear = 0;
}
else
{
myApplications.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
myApplications.strApplicationNumber =reader[LibraryMOD.GetFieldName( strApplicationNumberFN) ].ToString();
myApplications.lngStudentNumber =reader[LibraryMOD.GetFieldName( lngStudentNumberFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateApplicationFN)].Equals(DBNull.Value))
{
myApplications.dateApplication = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateApplicationFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(lngSerialFN)].Equals(DBNull.Value))
{
myApplications.lngSerial = 0;
}
else
{
myApplications.lngSerial = int.Parse(reader[LibraryMOD.GetFieldName( lngSerialFN) ].ToString());
}
myApplications.strCollege =reader[LibraryMOD.GetFieldName( strCollegeFN) ].ToString();
myApplications.strDegree =reader[LibraryMOD.GetFieldName( strDegreeFN) ].ToString();
myApplications.strSpecialization =reader[LibraryMOD.GetFieldName( strSpecializationFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(WantedMajorIDFN)].Equals(DBNull.Value))
{
myApplications.WantedMajorID = 0;
}
else
{
myApplications.WantedMajorID = int.Parse(reader[LibraryMOD.GetFieldName( WantedMajorIDFN) ].ToString());
}

if (reader[LibraryMOD.GetFieldName(WantedMajorID2FN)].Equals(DBNull.Value))
{
    myApplications.WantedMajorID2 = 0;
}
else
{
    myApplications.WantedMajorID2 = int.Parse(reader[LibraryMOD.GetFieldName(WantedMajorID2FN)].ToString());
}

if (reader[LibraryMOD.GetFieldName(WantedMajorID3FN)].Equals(DBNull.Value))
{
    myApplications.WantedMajorID3 = 0;
}
else
{
    myApplications.WantedMajorID3 = int.Parse(reader[LibraryMOD.GetFieldName(WantedMajorID3FN)].ToString());
}


if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myApplications.byteSemester = 0;
}
else
{
myApplications.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
myApplications.bOwnAccount =reader[LibraryMOD.GetFieldName( bOwnAccountFN) ].ToString();
myApplications.bAccepted =reader[LibraryMOD.GetFieldName( bAcceptedFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateAcceptedFN)].Equals(DBNull.Value))
{
myApplications.dateAccepted = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateAcceptedFN) ].ToString());
}
myApplications.strDecisionNumber =reader[LibraryMOD.GetFieldName( strDecisionNumberFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(intGraduationYearFN)].Equals(DBNull.Value))
{
myApplications.intGraduationYear = 0;
}
else
{
myApplications.intGraduationYear = int.Parse(reader[LibraryMOD.GetFieldName( intGraduationYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteGraduationSemesterFN)].Equals(DBNull.Value))
{
myApplications.byteGraduationSemester = 0;
}
else
{
myApplications.byteGraduationSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteGraduationSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteCancelReasonFN)].Equals(DBNull.Value))
{
myApplications.byteCancelReason = 0;
}
else
{
myApplications.byteCancelReason = int.Parse(reader[LibraryMOD.GetFieldName( byteCancelReasonFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteMainReasonFN)].Equals(DBNull.Value))
{
myApplications.byteMainReason = 0;
}
else
{
myApplications.byteMainReason = int.Parse(reader[LibraryMOD.GetFieldName( byteMainReasonFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSubReasonFN)].Equals(DBNull.Value))
{
myApplications.byteSubReason = 0;
}
else
{
myApplications.byteSubReason = int.Parse(reader[LibraryMOD.GetFieldName( byteSubReasonFN) ].ToString());
}
myApplications.strNotes =reader[LibraryMOD.GetFieldName( strNotesFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteMinGPAFN)].Equals(DBNull.Value))
{
myApplications.byteMinGPA = 0;
}
else
{
myApplications.byteMinGPA = int.Parse(reader[LibraryMOD.GetFieldName( byteMinGPAFN) ].ToString());
}
myApplications.bActive =reader[LibraryMOD.GetFieldName( bActiveFN) ].ToString();
myApplications.bContinue =reader[LibraryMOD.GetFieldName( bContinueFN) ].ToString();
myApplications.strGraduation =reader[LibraryMOD.GetFieldName( strGraduationFN) ].ToString();
myApplications.dateGraduation1 =reader[LibraryMOD.GetFieldName( dateGraduation1FN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateGraduation2FN)].Equals(DBNull.Value))
{
myApplications.dateGraduation2 = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateGraduation2FN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(lngTransactionFN)].Equals(DBNull.Value))
{
myApplications.lngTransaction = 0;
}
else
{
myApplications.lngTransaction = int.Parse(reader[LibraryMOD.GetFieldName( lngTransactionFN) ].ToString());
}
myApplications.bOtherCollege =reader[LibraryMOD.GetFieldName( bOtherCollegeFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteRefCollegeFN)].Equals(DBNull.Value))
{
myApplications.byteRefCollege = 0;
}
else
{
myApplications.byteRefCollege = int.Parse(reader[LibraryMOD.GetFieldName( byteRefCollegeFN) ].ToString());
}
myApplications.strAccountNo =reader[LibraryMOD.GetFieldName( strAccountNoFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(intAdvisorFN)].Equals(DBNull.Value))
{
myApplications.intAdvisor = 0;
}
else
{
myApplications.intAdvisor = int.Parse(reader[LibraryMOD.GetFieldName( intAdvisorFN) ].ToString());
}
myApplications.strCancelNote =reader[LibraryMOD.GetFieldName( strCancelNoteFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteStudentTypeFN)].Equals(DBNull.Value))
{
myApplications.byteStudentType = 0;
}
else
{
myApplications.byteStudentType = int.Parse(reader[LibraryMOD.GetFieldName( byteStudentTypeFN) ].ToString());
}

if (reader[LibraryMOD.GetFieldName(IsCompleteBAFromOtherInstitutionFN)].Equals(DBNull.Value))
{
myApplications.IsCompleteBAFromOtherInstitution = 0;
}
else
{
myApplications.IsCompleteBAFromOtherInstitution = int.Parse(reader[LibraryMOD.GetFieldName( IsCompleteBAFromOtherInstitutionFN) ].ToString());
}

if (reader[LibraryMOD.GetFieldName(IsCompleteMasterFromOtherInstitutionFN)].Equals(DBNull.Value))
{
myApplications.IsCompleteMasterFromOtherInstitution = 0;
}
else
{
myApplications.IsCompleteMasterFromOtherInstitution = int.Parse(reader[LibraryMOD.GetFieldName( IsCompleteMasterFromOtherInstitutionFN) ].ToString());
}

if (reader[LibraryMOD.GetFieldName(iEnrollmentSourceFN)].Equals(DBNull.Value))
{
    myApplications.iEnrollmentSource = 0;
}
else
{
    myApplications.iEnrollmentSource = int.Parse(reader[LibraryMOD.GetFieldName(iEnrollmentSourceFN)].ToString());
}
if (reader[LibraryMOD.GetFieldName(iEnrollmentSource2FN)].Equals(DBNull.Value))
{
    myApplications.iEnrollmentSource2 = 0;
}
else
{
    myApplications.iEnrollmentSource2 = int.Parse(reader[LibraryMOD.GetFieldName(iEnrollmentSource2FN)].ToString());
}
if (reader[LibraryMOD.GetFieldName(iRegisteredThroughFN)].Equals(DBNull.Value))
{
    myApplications.iRegisteredThrough = 0;
}
else
{
    myApplications.iRegisteredThrough = int.Parse(reader[LibraryMOD.GetFieldName(iRegisteredThroughFN)].ToString());
}   

myApplications.sEnrollmentNotes = reader[LibraryMOD.GetFieldName(sEnrollmentNotesFN)].ToString();


myApplications.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myApplications.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myApplications.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myApplications.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myApplications.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myApplications.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myApplications);
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
reader.Close();
reader.Dispose();
Conn.Close();
Conn.Dispose();
}
return results;
}
public int UpdateAdvisor(InitializeModule.EnumCampus Campus, int iMode, string lngStudentNumber, int intAdvisor)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Applications theApplications = new Applications();
//'Updates the  table

switch(iMode) 
  {
        

  case  (int)InitializeModule.enumModes.EditMode:
          sql = "UPDATE " + TableName;
          sql += " SET ";
          sql += LibraryMOD.GetFieldName(intAdvisorFN) + "=@intAdvisor";
          sql += " WHERE ";
          sql += LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
     
      break ;
  
  }

SqlCommand Cmd = new SqlCommand(sql, Conn);


Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));
Cmd.Parameters.Add(new SqlParameter("@intAdvisor",intAdvisor));

iEffected = Cmd.ExecuteNonQuery();
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
return iEffected;
}
public int UpdateApplications(InitializeModule.EnumCampus Campus, int iMode,int intStudyYear,string strApplicationNumber,string lngStudentNumber,DateTime dateApplication,int lngSerial,string strCollege,string strDegree,string strSpecialization,int WantedMajorID,int byteSemester,string bOwnAccount,string bAccepted,DateTime dateAccepted,string strDecisionNumber,int intGraduationYear,int byteGraduationSemester,int byteCancelReason,int byteMainReason,int byteSubReason,string strNotes,int byteMinGPA,string bActive,string bContinue,string strGraduation,string dateGraduation1,DateTime dateGraduation2,int lngTransaction,string bOtherCollege,int byteRefCollege,string strAccountNo,int intAdvisor,string strCancelNote,int byteStudentType,int IsCompleteBAFromOtherInstitution,int IsCompleteMasterFromOtherInstitution,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Applications theApplications = new Applications();
//'Updates the  table
switch(iMode) 
  {
  case  (int)InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }

SqlCommand Cmd = new SqlCommand(sql, Conn);

Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
Cmd.Parameters.Add(new SqlParameter("@strApplicationNumber",strApplicationNumber));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));

DateTime dateDefaultDate = Convert.ToDateTime("01/01/1900");


if ( dateApplication != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateApplication", dateApplication ));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateApplication", dateDefaultDate));
}

Cmd.Parameters.Add(new SqlParameter("@lngSerial",lngSerial));
Cmd.Parameters.Add(new SqlParameter("@strCollege",strCollege));
Cmd.Parameters.Add(new SqlParameter("@strDegree",strDegree));
Cmd.Parameters.Add(new SqlParameter("@strSpecialization",strSpecialization));
Cmd.Parameters.Add(new SqlParameter("@WantedMajorID",WantedMajorID));
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@bOwnAccount",bOwnAccount));
Cmd.Parameters.Add(new SqlParameter("@bAccepted",bAccepted));

if (dateAccepted != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateAccepted", dateAccepted));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateAccepted", dateDefaultDate));
}

Cmd.Parameters.Add(new SqlParameter("@strDecisionNumber",strDecisionNumber));
Cmd.Parameters.Add(new SqlParameter("@intGraduationYear",intGraduationYear));
Cmd.Parameters.Add(new SqlParameter("@byteGraduationSemester",byteGraduationSemester));
Cmd.Parameters.Add(new SqlParameter("@byteCancelReason",byteCancelReason));
Cmd.Parameters.Add(new SqlParameter("@byteMainReason",byteMainReason));
Cmd.Parameters.Add(new SqlParameter("@byteSubReason",byteSubReason));
Cmd.Parameters.Add(new SqlParameter("@strNotes",strNotes));
Cmd.Parameters.Add(new SqlParameter("@byteMinGPA",byteMinGPA));
Cmd.Parameters.Add(new SqlParameter("@bActive",bActive));
Cmd.Parameters.Add(new SqlParameter("@bContinue",bContinue));
Cmd.Parameters.Add(new SqlParameter("@strGraduation",strGraduation));
Cmd.Parameters.Add(new SqlParameter("@dateGraduation1",dateGraduation1));


//if (dateGraduation1  != DateTime.MinValue)
//{
//    Cmd.Parameters.Add(new SqlParameter("@dateGraduation1", dateAccepted));
//}
//else
//{
//    Cmd.Parameters.Add(new SqlParameter("@dateGraduation1", null));
//}
if (dateGraduation2 != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateGraduation2", dateGraduation2));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateGraduation2", dateDefaultDate));
}

Cmd.Parameters.Add(new SqlParameter("@lngTransaction",lngTransaction));
Cmd.Parameters.Add(new SqlParameter("@bOtherCollege",bOtherCollege));
Cmd.Parameters.Add(new SqlParameter("@byteRefCollege",byteRefCollege));
Cmd.Parameters.Add(new SqlParameter("@strAccountNo",strAccountNo));
Cmd.Parameters.Add(new SqlParameter("@intAdvisor",intAdvisor));
Cmd.Parameters.Add(new SqlParameter("@strCancelNote",strCancelNote));
Cmd.Parameters.Add(new SqlParameter("@byteStudentType",byteStudentType));

Cmd.Parameters.Add(new SqlParameter("@IsCompleteBAFromOtherInstitution",IsCompleteBAFromOtherInstitution));
Cmd.Parameters.Add(new SqlParameter("@IsCompleteMasterFromOtherInstitution",IsCompleteMasterFromOtherInstitution));

Cmd.Parameters.Add(new SqlParameter("@iEnrollmentSource", iEnrollmentSource));
Cmd.Parameters.Add(new SqlParameter("@iEnrollmentSource2", iEnrollmentSource2));
Cmd.Parameters.Add(new SqlParameter("@sEnrollmentNotes",sEnrollmentNotes));
Cmd.Parameters.Add(new SqlParameter("@iRegisteredThrough", iRegisteredThrough));    

Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));

iEffected = Cmd.ExecuteNonQuery();
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
return iEffected;
}
public int DeleteApplications(InitializeModule.EnumCampus Campus, int lngSerial)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@lngSerial", lngSerial));
Conn.Open();
iEffected = Cmd.ExecuteNonQuery();
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
return iEffected;
}
public DataView GetDataView(bool isFromRole,int PK,string sCondition)
{
DataTable dt = new DataTable("Applications");
DataView dv = new DataView();
List<Applications> myApplicationss = new List<Applications>();
try
{
myApplicationss = GetApplications(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strApplicationNumber", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("lngStudentNumber", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myApplicationss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myApplicationss[i].intStudyYear;
  dr[2] = myApplicationss[i].strApplicationNumber;
  dr[3] = myApplicationss[i].lngStudentNumber;
  dt.Rows.Add(dr);
}
dt.AcceptChanges();
dv.Table = dt;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
myApplicationss.Clear();
}
 return dv;
}
//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += strApplicationNumberFN;
//sSQL += " , " + ";
sSQL += "  FROM " + m_TableName;
SqlDataAdapter adapter = new SqlDataAdapter(sSQL, con);
//'table.Locale = System.Globalization.CultureInfo.InvariantCulture
adapter.Fill(table);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return table;
}
//end class tow
}
public class ApplicationsCls : ApplicationsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daApplications;
private DataSet m_dsApplications;
public DataRow ApplicationsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsApplications
{
get { return m_dsApplications ; }
set { m_dsApplications = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public ApplicationsCls()
{
try
{
dsApplications= new DataSet();

}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
//-------Get DataAdapter  -----------------------------
#region "DataAdapter"
public virtual SqlDataAdapter GetApplicationsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daApplications = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daApplications);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daApplications.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daApplications;
}
public virtual SqlDataAdapter GetApplicationsDataAdapter(SqlConnection con)  
{
try
{
daApplications = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daApplications.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdApplications;
cmdApplications = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@strApplicationNumber", SqlDbType.Int, 4, "strApplicationNumber" );
daApplications.SelectCommand = cmdApplications;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdApplications = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdApplications.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdApplications.Parameters.Add("@strApplicationNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strApplicationNumberFN));
cmdApplications.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdApplications.Parameters.Add("@dateApplication", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateApplicationFN));
cmdApplications.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
cmdApplications.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
cmdApplications.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdApplications.Parameters.Add("@strSpecialization", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strSpecializationFN));
cmdApplications.Parameters.Add("@WantedMajorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(WantedMajorIDFN));
cmdApplications.Parameters.Add("@WantedMajorID2", SqlDbType.Int, 4, LibraryMOD.GetFieldName(WantedMajorID2FN));
cmdApplications.Parameters.Add("@WantedMajorID3", SqlDbType.Int, 4, LibraryMOD.GetFieldName(WantedMajorID3FN));
cmdApplications.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdApplications.Parameters.Add("@bOwnAccount", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bOwnAccountFN));
cmdApplications.Parameters.Add("@bAccepted", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bAcceptedFN));
cmdApplications.Parameters.Add("@dateAccepted", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateAcceptedFN));
cmdApplications.Parameters.Add("@strDecisionNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strDecisionNumberFN));
cmdApplications.Parameters.Add("@intGraduationYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intGraduationYearFN));
cmdApplications.Parameters.Add("@byteGraduationSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGraduationSemesterFN));
cmdApplications.Parameters.Add("@byteCancelReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCancelReasonFN));
cmdApplications.Parameters.Add("@byteMainReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMainReasonFN));
cmdApplications.Parameters.Add("@byteSubReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSubReasonFN));
cmdApplications.Parameters.Add("@strNotes", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strNotesFN));
cmdApplications.Parameters.Add("@byteMinGPA", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinGPAFN));
cmdApplications.Parameters.Add("@bActive", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bActiveFN));
cmdApplications.Parameters.Add("@bContinue", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bContinueFN));
cmdApplications.Parameters.Add("@strGraduation", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strGraduationFN));
cmdApplications.Parameters.Add("@dateGraduation1", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(dateGraduation1FN));
cmdApplications.Parameters.Add("@dateGraduation2", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateGraduation2FN));
cmdApplications.Parameters.Add("@lngTransaction", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngTransactionFN));
cmdApplications.Parameters.Add("@bOtherCollege", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bOtherCollegeFN));
cmdApplications.Parameters.Add("@byteRefCollege", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRefCollegeFN));
cmdApplications.Parameters.Add("@strAccountNo", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strAccountNoFN));
cmdApplications.Parameters.Add("@intAdvisor", SqlDbType.Int,2, LibraryMOD.GetFieldName(intAdvisorFN));
cmdApplications.Parameters.Add("@strCancelNote", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strCancelNoteFN));
cmdApplications.Parameters.Add("@byteStudentType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudentTypeFN));

cmdApplications.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdApplications.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdApplications.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdApplications.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdApplications.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdApplications.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdApplications.Parameters.Add("@strApplicationNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strApplicationNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daApplications.UpdateCommand = cmdApplications;
daApplications.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdApplications = new SqlCommand(GetInsertCommand(), con);
cmdApplications.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdApplications.Parameters.Add("@strApplicationNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strApplicationNumberFN));
cmdApplications.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdApplications.Parameters.Add("@dateApplication", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateApplicationFN));
cmdApplications.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
cmdApplications.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
cmdApplications.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdApplications.Parameters.Add("@strSpecialization", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strSpecializationFN));
cmdApplications.Parameters.Add("@WantedMajorID", SqlDbType.Int,4, LibraryMOD.GetFieldName(WantedMajorIDFN));
cmdApplications.Parameters.Add("@WantedMajorID2", SqlDbType.Int, 4, LibraryMOD.GetFieldName(WantedMajorID2FN));
cmdApplications.Parameters.Add("@WantedMajorID3", SqlDbType.Int, 4, LibraryMOD.GetFieldName(WantedMajorID3FN));
cmdApplications.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdApplications.Parameters.Add("@bOwnAccount", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bOwnAccountFN));
cmdApplications.Parameters.Add("@bAccepted", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bAcceptedFN));
cmdApplications.Parameters.Add("@dateAccepted", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateAcceptedFN));
cmdApplications.Parameters.Add("@strDecisionNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strDecisionNumberFN));
cmdApplications.Parameters.Add("@intGraduationYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intGraduationYearFN));
cmdApplications.Parameters.Add("@byteGraduationSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGraduationSemesterFN));
cmdApplications.Parameters.Add("@byteCancelReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCancelReasonFN));
cmdApplications.Parameters.Add("@byteMainReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMainReasonFN));
cmdApplications.Parameters.Add("@byteSubReason", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSubReasonFN));
cmdApplications.Parameters.Add("@strNotes", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strNotesFN));
cmdApplications.Parameters.Add("@byteMinGPA", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMinGPAFN));
cmdApplications.Parameters.Add("@bActive", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bActiveFN));
cmdApplications.Parameters.Add("@bContinue", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bContinueFN));
cmdApplications.Parameters.Add("@strGraduation", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strGraduationFN));
cmdApplications.Parameters.Add("@dateGraduation1", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(dateGraduation1FN));
cmdApplications.Parameters.Add("@dateGraduation2", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateGraduation2FN));
cmdApplications.Parameters.Add("@lngTransaction", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngTransactionFN));
cmdApplications.Parameters.Add("@bOtherCollege", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bOtherCollegeFN));
cmdApplications.Parameters.Add("@byteRefCollege", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteRefCollegeFN));
cmdApplications.Parameters.Add("@strAccountNo", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strAccountNoFN));
cmdApplications.Parameters.Add("@intAdvisor", SqlDbType.Int,2, LibraryMOD.GetFieldName(intAdvisorFN));
cmdApplications.Parameters.Add("@strCancelNote", SqlDbType.Text,2147483647, LibraryMOD.GetFieldName(strCancelNoteFN));
cmdApplications.Parameters.Add("@byteStudentType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteStudentTypeFN));

cmdApplications.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdApplications.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdApplications.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdApplications.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdApplications.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdApplications.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daApplications.InsertCommand =cmdApplications;
daApplications.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdApplications = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdApplications.Parameters.Add("@strApplicationNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strApplicationNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daApplications.DeleteCommand =cmdApplications;
daApplications.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daApplications.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daApplications;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsApplications.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(strApplicationNumberFN)]=strApplicationNumber;
dr[LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
dr[LibraryMOD.GetFieldName(dateApplicationFN)]=dateApplication;
dr[LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
dr[LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
dr[LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
dr[LibraryMOD.GetFieldName(strSpecializationFN)]=strSpecialization;
dr[LibraryMOD.GetFieldName(WantedMajorIDFN)]=WantedMajorID;
dr[LibraryMOD.GetFieldName(WantedMajorID2FN)] = WantedMajorID2;
dr[LibraryMOD.GetFieldName(WantedMajorID3FN)] = WantedMajorID3;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(bOwnAccountFN)]=bOwnAccount;
dr[LibraryMOD.GetFieldName(bAcceptedFN)]=bAccepted;
dr[LibraryMOD.GetFieldName(dateAcceptedFN)]=dateAccepted;
dr[LibraryMOD.GetFieldName(strDecisionNumberFN)]=strDecisionNumber;
dr[LibraryMOD.GetFieldName(intGraduationYearFN)]=intGraduationYear;
dr[LibraryMOD.GetFieldName(byteGraduationSemesterFN)]=byteGraduationSemester;
dr[LibraryMOD.GetFieldName(byteCancelReasonFN)]=byteCancelReason;
dr[LibraryMOD.GetFieldName(byteMainReasonFN)]=byteMainReason;
dr[LibraryMOD.GetFieldName(byteSubReasonFN)]=byteSubReason;
dr[LibraryMOD.GetFieldName(strNotesFN)]=strNotes;
dr[LibraryMOD.GetFieldName(byteMinGPAFN)]=byteMinGPA;
dr[LibraryMOD.GetFieldName(bActiveFN)]=bActive;
dr[LibraryMOD.GetFieldName(bContinueFN)]=bContinue;
dr[LibraryMOD.GetFieldName(strGraduationFN)]=strGraduation;
dr[LibraryMOD.GetFieldName(dateGraduation1FN)]=dateGraduation1;
dr[LibraryMOD.GetFieldName(dateGraduation2FN)]=dateGraduation2;
dr[LibraryMOD.GetFieldName(lngTransactionFN)]=lngTransaction;
dr[LibraryMOD.GetFieldName(bOtherCollegeFN)]=bOtherCollege;
dr[LibraryMOD.GetFieldName(byteRefCollegeFN)]=byteRefCollege;
dr[LibraryMOD.GetFieldName(strAccountNoFN)]=strAccountNo;
dr[LibraryMOD.GetFieldName(intAdvisorFN)]=intAdvisor;
dr[LibraryMOD.GetFieldName(strCancelNoteFN)]=strCancelNote;
dr[LibraryMOD.GetFieldName(byteStudentTypeFN)]=byteStudentType;

dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsApplications.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsApplications.Tables[TableName].Select(LibraryMOD.GetFieldName(strApplicationNumberFN)  + "=" + strApplicationNumber);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(strApplicationNumberFN)]=strApplicationNumber;
drAry[0][LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
drAry[0][LibraryMOD.GetFieldName(dateApplicationFN)]=dateApplication;
drAry[0][LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
drAry[0][LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
drAry[0][LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
drAry[0][LibraryMOD.GetFieldName(strSpecializationFN)]=strSpecialization;
drAry[0][LibraryMOD.GetFieldName(WantedMajorIDFN)]=WantedMajorID;
drAry[0][LibraryMOD.GetFieldName(WantedMajorID2FN)] = WantedMajorID2;
drAry[0][LibraryMOD.GetFieldName(WantedMajorID3FN)] = WantedMajorID3;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(bOwnAccountFN)]=bOwnAccount;
drAry[0][LibraryMOD.GetFieldName(bAcceptedFN)]=bAccepted;
drAry[0][LibraryMOD.GetFieldName(dateAcceptedFN)]=dateAccepted;
drAry[0][LibraryMOD.GetFieldName(strDecisionNumberFN)]=strDecisionNumber;
drAry[0][LibraryMOD.GetFieldName(intGraduationYearFN)]=intGraduationYear;
drAry[0][LibraryMOD.GetFieldName(byteGraduationSemesterFN)]=byteGraduationSemester;
drAry[0][LibraryMOD.GetFieldName(byteCancelReasonFN)]=byteCancelReason;
drAry[0][LibraryMOD.GetFieldName(byteMainReasonFN)]=byteMainReason;
drAry[0][LibraryMOD.GetFieldName(byteSubReasonFN)]=byteSubReason;
drAry[0][LibraryMOD.GetFieldName(strNotesFN)]=strNotes;
drAry[0][LibraryMOD.GetFieldName(byteMinGPAFN)]=byteMinGPA;
drAry[0][LibraryMOD.GetFieldName(bActiveFN)]=bActive;
drAry[0][LibraryMOD.GetFieldName(bContinueFN)]=bContinue;
drAry[0][LibraryMOD.GetFieldName(strGraduationFN)]=strGraduation;
drAry[0][LibraryMOD.GetFieldName(dateGraduation1FN)]=dateGraduation1;
drAry[0][LibraryMOD.GetFieldName(dateGraduation2FN)]=dateGraduation2;
drAry[0][LibraryMOD.GetFieldName(lngTransactionFN)]=lngTransaction;
drAry[0][LibraryMOD.GetFieldName(bOtherCollegeFN)]=bOtherCollege;
drAry[0][LibraryMOD.GetFieldName(byteRefCollegeFN)]=byteRefCollege;
drAry[0][LibraryMOD.GetFieldName(strAccountNoFN)]=strAccountNo;
drAry[0][LibraryMOD.GetFieldName(intAdvisorFN)]=intAdvisor;
drAry[0][LibraryMOD.GetFieldName(strCancelNoteFN)]=strCancelNote;
drAry[0][LibraryMOD.GetFieldName(byteStudentTypeFN)]=byteStudentType;

drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
break;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitApplications()  
{
//CommitApplications= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daApplications.Update(dsApplications, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow= InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(strApplicationNumber);
if (( ApplicationsDataRow != null)) 
{
ApplicationsDataRow.Delete();
CommitApplications();
if (MoveNext() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (ApplicationsDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strApplicationNumberFN)]== System.DBNull.Value)
{
  strApplicationNumber="";
}
else
{
  strApplicationNumber = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strApplicationNumberFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)]== System.DBNull.Value)
{
  lngStudentNumber="";
}
else
{
  lngStudentNumber = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(dateApplicationFN)]== System.DBNull.Value)
{
}
else
{
  dateApplication = (DateTime)ApplicationsDataRow[LibraryMOD.GetFieldName(dateApplicationFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(lngSerialFN)]== System.DBNull.Value)
{
  lngSerial=0;
}
else
{
  lngSerial = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(lngSerialFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strCollegeFN)]== System.DBNull.Value)
{
  strCollege="";
}
else
{
  strCollege = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strDegreeFN)]== System.DBNull.Value)
{
  strDegree="";
}
else
{
  strDegree = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strDegreeFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strSpecializationFN)]== System.DBNull.Value)
{
  strSpecialization="";
}
else
{
  strSpecialization = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strSpecializationFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(WantedMajorIDFN)]== System.DBNull.Value)
{
  WantedMajorID=0;
}
else
{
  WantedMajorID = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(WantedMajorIDFN)];
}

if (ApplicationsDataRow[LibraryMOD.GetFieldName(WantedMajorID2FN)] == System.DBNull.Value)
{
    WantedMajorID2 = 0;
}
else
{
    WantedMajorID2 = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(WantedMajorID2FN)];
}

if (ApplicationsDataRow[LibraryMOD.GetFieldName(WantedMajorID3FN)] == System.DBNull.Value)
{
    WantedMajorID3 = 0;
}
else
{
    WantedMajorID3 = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(WantedMajorID3FN)];
}


if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(bOwnAccountFN)]== System.DBNull.Value)
{
  bOwnAccount="";
}
else
{
  bOwnAccount = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(bOwnAccountFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(bAcceptedFN)]== System.DBNull.Value)
{
  bAccepted="";
}
else
{
  bAccepted = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(bAcceptedFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(dateAcceptedFN)]== System.DBNull.Value)
{
}
else
{
  dateAccepted = (DateTime)ApplicationsDataRow[LibraryMOD.GetFieldName(dateAcceptedFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strDecisionNumberFN)]== System.DBNull.Value)
{
  strDecisionNumber="";
}
else
{
  strDecisionNumber = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strDecisionNumberFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(intGraduationYearFN)]== System.DBNull.Value)
{
  intGraduationYear=0;
}
else
{
  intGraduationYear = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(intGraduationYearFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteGraduationSemesterFN)]== System.DBNull.Value)
{
  byteGraduationSemester=0;
}
else
{
  byteGraduationSemester = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteGraduationSemesterFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteCancelReasonFN)]== System.DBNull.Value)
{
  byteCancelReason=0;
}
else
{
  byteCancelReason = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteCancelReasonFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteMainReasonFN)]== System.DBNull.Value)
{
  byteMainReason=0;
}
else
{
  byteMainReason = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteMainReasonFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteSubReasonFN)]== System.DBNull.Value)
{
  byteSubReason=0;
}
else
{
  byteSubReason = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteSubReasonFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strNotesFN)]== System.DBNull.Value)
{
  strNotes="";
}
else
{
  strNotes = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strNotesFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteMinGPAFN)]== System.DBNull.Value)
{
  byteMinGPA=0;
}
else
{
  byteMinGPA = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteMinGPAFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(bActiveFN)]== System.DBNull.Value)
{
  bActive="";
}
else
{
  bActive = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(bActiveFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(bContinueFN)]== System.DBNull.Value)
{
  bContinue="";
}
else
{
  bContinue = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(bContinueFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strGraduationFN)]== System.DBNull.Value)
{
  strGraduation="";
}
else
{
  strGraduation = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strGraduationFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(dateGraduation1FN)]== System.DBNull.Value)
{
  dateGraduation1="";
}
else
{
  dateGraduation1 = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(dateGraduation1FN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(dateGraduation2FN)]== System.DBNull.Value)
{
}
else
{
  dateGraduation2 = (DateTime)ApplicationsDataRow[LibraryMOD.GetFieldName(dateGraduation2FN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(lngTransactionFN)]== System.DBNull.Value)
{
  lngTransaction=0;
}
else
{
  lngTransaction = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(lngTransactionFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(bOtherCollegeFN)]== System.DBNull.Value)
{
  bOtherCollege="";
}
else
{
  bOtherCollege = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(bOtherCollegeFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteRefCollegeFN)]== System.DBNull.Value)
{
  byteRefCollege=0;
}
else
{
  byteRefCollege = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteRefCollegeFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strAccountNoFN)]== System.DBNull.Value)
{
  strAccountNo="";
}
else
{
  strAccountNo = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strAccountNoFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(intAdvisorFN)]== System.DBNull.Value)
{
  intAdvisor=0;
}
else
{
  intAdvisor = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(intAdvisorFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strCancelNoteFN)]== System.DBNull.Value)
{
  strCancelNote="";
}
else
{
  strCancelNote = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strCancelNoteFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(byteStudentTypeFN)]== System.DBNull.Value)
{
  byteStudentType=0;
}
else
{
  byteStudentType = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(byteStudentTypeFN)];
}

    if (ApplicationsDataRow[LibraryMOD.GetFieldName(IsCompleteBAFromOtherInstitutionFN)]== System.DBNull.Value)
{
  IsCompleteBAFromOtherInstitution=0;
}
else
{
  IsCompleteBAFromOtherInstitution = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(IsCompleteBAFromOtherInstitutionFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(IsCompleteMasterFromOtherInstitutionFN)]== System.DBNull.Value)
{
  IsCompleteMasterFromOtherInstitution=0;
}
else
{
  IsCompleteMasterFromOtherInstitution = (int)ApplicationsDataRow[LibraryMOD.GetFieldName(IsCompleteMasterFromOtherInstitutionFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)ApplicationsDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)ApplicationsDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (ApplicationsDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)ApplicationsDataRow[LibraryMOD.GetFieldName(strNUserFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(string PKstrApplicationNumber) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKstrApplicationNumber;
ApplicationsDataRow = dsApplications.Tables[TableName].Rows.Find(findTheseVals);
if  ((ApplicationsDataRow !=null)) 
{
lngCurRow = dsApplications.Tables[TableName].Rows.IndexOf(ApplicationsDataRow);
SynchronizeDataRowToClass();
return InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst= InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast= InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsApplications.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsApplications.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow= InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsApplications.Tables[TableName].Rows.Count > 0) 
{
  ApplicationsDataRow = dsApplications.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
// InitializeModule.FAIL_RET;
try
{
daApplications.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daApplications.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daApplications.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daApplications.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return InitializeModule.SUCCESS_RET;
}
//'-------OnRowUpdating  -----------------------------
private static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs args)
{
try
{
if (args.StatementType == StatementType.Delete )
{
System.IO.TextWriter tw = System.IO.File.AppendText("Delete.log");
tw.Close();
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
//'-------OnRowUpdated  -----------------------------
private static void  OnRowUpdated( object sender, SqlRowUpdatedEventArgs args)
{
try
{
if (args.Status == UpdateStatus.ErrorsOccurred )
{
args.Row.RowError = args.Errors.Message;
System.IO.File.AppendText("Delete.log");
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
#endregion
//end third class
}
