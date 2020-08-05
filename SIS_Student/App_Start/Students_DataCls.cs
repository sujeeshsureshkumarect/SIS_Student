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

public class Students_Data
{
//Creation Date: 29/03/2010 5:55:04 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_lngSerial; 
private string m_strFirstDescEn; 
private string m_strSecondDescEn; 
private string m_strThirdDescEn; 
private string m_strLastDescEn; 
private string m_strFirstDescAr; 
private string m_strSecondDescAr; 
private string m_strThirdDescAr; 
private string m_strLastDescAr; 
private bool m_bSex; 
private DateTime m_dateBirth; 
private int m_byteBirthCountry; 
private int m_byteBirthCity; 
private int m_byteNationality; 
private int m_byteReligion; 
private int m_byteIDType; 
private string m_strID; 
private int m_byteIDCountry; 
private DateTime m_dateEndID; 
private int m_byteMilitaryStatus; 
private string m_strMilitaryID; 
private DateTime m_dateMilitaryPostpone; 
private string m_strReleaseReason; 
private string m_strPostponeReason; 
private DateTime m_dateMilitaryStart; 
private DateTime m_dateMilitaryEnd; 
private int m_byteHomeCountry; 
private int m_byteHomeCity; 
private int m_byteOriginCountry; 
private int m_byteOriginCity; 
private string m_strPOBox; 
private string m_strPhone1; 
private string m_strPhone2; 
private string m_strFax; 
private string m_strTelex; 
private string m_strEmail;
private string m_sECTemail; 
private string m_strZipCode; 
private string m_lngStudentNumber; 
private string m_strCollege; 
private string m_strDegree; 
private string m_strSpecialization; 
private string m_strNationalNumber; 
private string m_strAddress; 
private string m_strMilitarySource; 
private string m_strAgreement; 
private DateTime m_dateAgreement; 
private string m_bCourse; 
private int m_byteShift; 
private string m_strNationalID; 
private int m_intWorkPlace; 
private string m_strWorkPhone; 
private string m_strJopTitle; 
private int m_intDelegation; 
private int m_intSponsor; 
private DateTime m_dateEndSponsorship; 
private string m_strUserCreate; 
private DateTime m_dateCreate; 
private string m_strUserSave; 
private DateTime m_dateLastSave; 
private string m_strMachine; 
private string m_strNUser; 
private string m_strStudentPic;
private bool m_isWorking;
private string m_EthbaraNo;
private bool m_FitnessStatus;
private int m_MaritalStatus;
private int m_NationalityofMother;
private int m_EmploymentSector;

#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int lngSerial
{
get { return  m_lngSerial; }
set {m_lngSerial  = value ; }
}
public string strFirstDescEn
{
get { return  m_strFirstDescEn; }
set {m_strFirstDescEn  = value ; }
}
public string strSecondDescEn
{
get { return  m_strSecondDescEn; }
set {m_strSecondDescEn  = value ; }
}
public string strThirdDescEn
{
get { return  m_strThirdDescEn; }
set {m_strThirdDescEn  = value ; }
}
public string strLastDescEn
{
get { return  m_strLastDescEn; }
set {m_strLastDescEn  = value ; }
}
public string strFirstDescAr
{
get { return  m_strFirstDescAr; }
set {m_strFirstDescAr  = value ; }
}
public string strSecondDescAr
{
get { return  m_strSecondDescAr; }
set {m_strSecondDescAr  = value ; }
}
public string strThirdDescAr
{
get { return  m_strThirdDescAr; }
set {m_strThirdDescAr  = value ; }
}
public string strLastDescAr
{
get { return  m_strLastDescAr; }
set {m_strLastDescAr  = value ; }
}
public bool bSex
{
get { return  m_bSex; }
set {m_bSex  = value ; }
}
public DateTime dateBirth
{
get { return  m_dateBirth; }
set {m_dateBirth  = value ; }
}
public int byteBirthCountry
{
get { return  m_byteBirthCountry; }
set {m_byteBirthCountry  = value ; }
}
public int byteBirthCity
{
get { return  m_byteBirthCity; }
set {m_byteBirthCity  = value ; }
}
public int byteNationality
{
get { return  m_byteNationality; }
set {m_byteNationality  = value ; }
}
public int byteReligion
{
get { return  m_byteReligion; }
set {m_byteReligion  = value ; }
}
public int byteIDType
{
get { return  m_byteIDType; }
set {m_byteIDType  = value ; }
}
public string strID
{
get { return  m_strID; }
set {m_strID  = value ; }
}
public int byteIDCountry
{
get { return  m_byteIDCountry; }
set {m_byteIDCountry  = value ; }
}
public DateTime dateEndID
{
get { return  m_dateEndID; }
set {m_dateEndID  = value ; }
}
public int byteMilitaryStatus
{
get { return  m_byteMilitaryStatus; }
set {m_byteMilitaryStatus  = value ; }
}
public string strMilitaryID
{
get { return  m_strMilitaryID; }
set {m_strMilitaryID  = value ; }
}
public DateTime dateMilitaryPostpone
{
get { return  m_dateMilitaryPostpone; }
set {m_dateMilitaryPostpone  = value ; }
}
public string strReleaseReason
{
get { return  m_strReleaseReason; }
set {m_strReleaseReason  = value ; }
}
public string strPostponeReason
{
get { return  m_strPostponeReason; }
set {m_strPostponeReason  = value ; }
}
public DateTime dateMilitaryStart
{
get { return  m_dateMilitaryStart; }
set {m_dateMilitaryStart  = value ; }
}
public DateTime dateMilitaryEnd
{
get { return  m_dateMilitaryEnd; }
set {m_dateMilitaryEnd  = value ; }
}
public int byteHomeCountry
{
get { return  m_byteHomeCountry; }
set {m_byteHomeCountry  = value ; }
}
public int byteHomeCity
{
get { return  m_byteHomeCity; }
set {m_byteHomeCity  = value ; }
}
public int byteOriginCountry
{
get { return  m_byteOriginCountry; }
set {m_byteOriginCountry  = value ; }
}
public int byteOriginCity
{
get { return  m_byteOriginCity; }
set {m_byteOriginCity  = value ; }
}
public string strPOBox
{
get { return  m_strPOBox; }
set {m_strPOBox  = value ; }
}
public string strPhone1
{
get { return  m_strPhone1; }
set {m_strPhone1  = value ; }
}
public string strPhone2
{
get { return  m_strPhone2; }
set {m_strPhone2  = value ; }
}
public string strFax
{
get { return  m_strFax; }
set {m_strFax  = value ; }
}
public string strTelex
{
get { return  m_strTelex; }
set {m_strTelex  = value ; }
}
public string strEmail
{
get { return  m_strEmail; }
set {m_strEmail  = value ; }
}
public string sECTemail
{
    get { return m_sECTemail; }
    set { m_sECTemail = value; }
}   
public string strZipCode
{
get { return  m_strZipCode; }
set {m_strZipCode  = value ; }
}
public string lngStudentNumber
{
get { return  m_lngStudentNumber; }
set {m_lngStudentNumber  = value ; }
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
public string strNationalNumber
{
get { return  m_strNationalNumber; }
set {m_strNationalNumber  = value ; }
}
public string strAddress
{
get { return  m_strAddress; }
set {m_strAddress  = value ; }
}
public string strMilitarySource
{
get { return  m_strMilitarySource; }
set {m_strMilitarySource  = value ; }
}
public string strAgreement
{
get { return  m_strAgreement; }
set {m_strAgreement  = value ; }
}
public DateTime dateAgreement
{
get { return  m_dateAgreement; }
set {m_dateAgreement  = value ; }
}
public string bCourse
{
get { return  m_bCourse; }
set {m_bCourse  = value ; }
}
public int byteShift
{
get { return  m_byteShift; }
set {m_byteShift  = value ; }
}
public string strNationalID
{
get { return  m_strNationalID; }
set {m_strNationalID  = value ; }
}
public int intWorkPlace
{
get { return  m_intWorkPlace; }
set {m_intWorkPlace  = value ; }
}
public string strWorkPhone
{
get { return  m_strWorkPhone; }
set {m_strWorkPhone  = value ; }
}
public string strJopTitle
{
get { return  m_strJopTitle; }
set {m_strJopTitle  = value ; }
}
public int intDelegation
{
get { return  m_intDelegation; }
set {m_intDelegation  = value ; }
}
public int intSponsor
{
get { return  m_intSponsor; }
set {m_intSponsor  = value ; }
}
public DateTime dateEndSponsorship
{
get { return  m_dateEndSponsorship; }
set {m_dateEndSponsorship  = value ; }
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
public string strStudentPic
{
get { return  m_strStudentPic; }
set {m_strStudentPic  = value ; }
}
public string EthbaraNo
{
    get { return m_EthbaraNo; }
    set { m_EthbaraNo = value; }
}
public bool FitnessStatus
{
    get { return m_FitnessStatus; }
    set { m_FitnessStatus = value; }
}
public bool isWorking
{
    get { return m_isWorking; }
    set { m_isWorking = value; }
}
public int MaritalStatus
{
    get { return m_MaritalStatus; }
    set { m_MaritalStatus = value; }
}
public int NationalityofMother
{
    get { return m_NationalityofMother; }
    set { m_NationalityofMother = value; }
}
public int EmploymentSector
{
    get { return m_EmploymentSector; }
    set { m_EmploymentSector = value; }
}
#endregion
//'-----------------------------------------------------
public Students_Data()
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
public class Students_DataDAL : Students_Data
{
#region "Decleration"
private string m_TableName;
private string m_lngSerialFN;
private string m_strFirstDescEnFN ;
private string m_strSecondDescEnFN ;
private string m_strThirdDescEnFN ;
private string m_strLastDescEnFN ;
private string m_strFirstDescArFN ;
private string m_strSecondDescArFN ;
private string m_strThirdDescArFN ;
private string m_strLastDescArFN ;
private string m_bSexFN ;
private string m_dateBirthFN ;
private string m_byteBirthCountryFN ;
private string m_byteBirthCityFN ;
private string m_byteNationalityFN ;
private string m_byteReligionFN ;
private string m_byteIDTypeFN ;
private string m_strIDFN ;
private string m_byteIDCountryFN ;
private string m_dateEndIDFN ;
private string m_byteMilitaryStatusFN ;
private string m_strMilitaryIDFN ;
private string m_dateMilitaryPostponeFN ;
private string m_strReleaseReasonFN ;
private string m_strPostponeReasonFN ;
private string m_dateMilitaryStartFN ;
private string m_dateMilitaryEndFN ;
private string m_byteHomeCountryFN ;
private string m_byteHomeCityFN ;
private string m_byteOriginCountryFN ;
private string m_byteOriginCityFN ;
private string m_strPOBoxFN ;
private string m_strPhone1FN ;
private string m_strPhone2FN ;
private string m_strFaxFN ;
private string m_strTelexFN ;
private string m_strEmailFN ;
private string m_sECTemailFN;
private string m_strZipCodeFN ;
private string m_lngStudentNumberFN ;
private string m_strCollegeFN ;
private string m_strDegreeFN ;
private string m_strSpecializationFN ;
private string m_strNationalNumberFN ;
private string m_strAddressFN ;
private string m_strMilitarySourceFN ;
private string m_strAgreementFN ;
private string m_dateAgreementFN ;
private string m_bCourseFN ;
private string m_byteShiftFN ;
private string m_strNationalIDFN ;
private string m_intWorkPlaceFN ;
private string m_strWorkPhoneFN ;
private string m_strJopTitleFN ;
private string m_intDelegationFN ;
private string m_intSponsorFN ;
private string m_dateEndSponsorshipFN ;
private string m_strUserCreateFN ;
private string m_dateCreateFN ;
private string m_strUserSaveFN ;
private string m_dateLastSaveFN ;
private string m_strMachineFN ;
private string m_strNUserFN ;
private string m_strStudentPicFN ;
private string m_isWorkingFN;
private string m_EthbaraNoFN;
private string m_FitnessStatusFN;
private string m_MaritalStatusFN;
private string m_NationalityofMotherFN;
private string m_EmploymentSectorFN;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string lngSerialFN 
{
get { return  m_lngSerialFN; }
set {m_lngSerialFN  = value ; }
}
public string strFirstDescEnFN 
{
get { return  m_strFirstDescEnFN; }
set {m_strFirstDescEnFN  = value ; }
}
public string strSecondDescEnFN 
{
get { return  m_strSecondDescEnFN; }
set {m_strSecondDescEnFN  = value ; }
}
public string strThirdDescEnFN 
{
get { return  m_strThirdDescEnFN; }
set {m_strThirdDescEnFN  = value ; }
}
public string strLastDescEnFN 
{
get { return  m_strLastDescEnFN; }
set {m_strLastDescEnFN  = value ; }
}
public string strFirstDescArFN 
{
get { return  m_strFirstDescArFN; }
set {m_strFirstDescArFN  = value ; }
}
public string strSecondDescArFN 
{
get { return  m_strSecondDescArFN; }
set {m_strSecondDescArFN  = value ; }
}
public string strThirdDescArFN 
{
get { return  m_strThirdDescArFN; }
set {m_strThirdDescArFN  = value ; }
}
public string strLastDescArFN 
{
get { return  m_strLastDescArFN; }
set {m_strLastDescArFN  = value ; }
}
public string bSexFN 
{
get { return  m_bSexFN; }
set {m_bSexFN  = value ; }
}
public string dateBirthFN 
{
get { return  m_dateBirthFN; }
set {m_dateBirthFN  = value ; }
}
public string byteBirthCountryFN 
{
get { return  m_byteBirthCountryFN; }
set {m_byteBirthCountryFN  = value ; }
}
public string byteBirthCityFN 
{
get { return  m_byteBirthCityFN; }
set {m_byteBirthCityFN  = value ; }
}
public string byteNationalityFN 
{
get { return  m_byteNationalityFN; }
set {m_byteNationalityFN  = value ; }
}
public string byteReligionFN 
{
get { return  m_byteReligionFN; }
set {m_byteReligionFN  = value ; }
}
public string byteIDTypeFN 
{
get { return  m_byteIDTypeFN; }
set {m_byteIDTypeFN  = value ; }
}
public string strIDFN 
{
get { return  m_strIDFN; }
set {m_strIDFN  = value ; }
}
public string byteIDCountryFN 
{
get { return  m_byteIDCountryFN; }
set {m_byteIDCountryFN  = value ; }
}
public string dateEndIDFN 
{
get { return  m_dateEndIDFN; }
set {m_dateEndIDFN  = value ; }
}
public string byteMilitaryStatusFN 
{
get { return  m_byteMilitaryStatusFN; }
set {m_byteMilitaryStatusFN  = value ; }
}
public string strMilitaryIDFN 
{
get { return  m_strMilitaryIDFN; }
set {m_strMilitaryIDFN  = value ; }
}
public string dateMilitaryPostponeFN 
{
get { return  m_dateMilitaryPostponeFN; }
set {m_dateMilitaryPostponeFN  = value ; }
}
public string strReleaseReasonFN 
{
get { return  m_strReleaseReasonFN; }
set {m_strReleaseReasonFN  = value ; }
}
public string strPostponeReasonFN 
{
get { return  m_strPostponeReasonFN; }
set {m_strPostponeReasonFN  = value ; }
}
public string dateMilitaryStartFN 
{
get { return  m_dateMilitaryStartFN; }
set {m_dateMilitaryStartFN  = value ; }
}
public string dateMilitaryEndFN 
{
get { return  m_dateMilitaryEndFN; }
set {m_dateMilitaryEndFN  = value ; }
}
public string byteHomeCountryFN 
{
get { return  m_byteHomeCountryFN; }
set {m_byteHomeCountryFN  = value ; }
}
public string byteHomeCityFN 
{
get { return  m_byteHomeCityFN; }
set {m_byteHomeCityFN  = value ; }
}
public string byteOriginCountryFN 
{
get { return  m_byteOriginCountryFN; }
set {m_byteOriginCountryFN  = value ; }
}
public string byteOriginCityFN 
{
get { return  m_byteOriginCityFN; }
set {m_byteOriginCityFN  = value ; }
}
public string strPOBoxFN 
{
get { return  m_strPOBoxFN; }
set {m_strPOBoxFN  = value ; }
}
public string strPhone1FN 
{
get { return  m_strPhone1FN; }
set {m_strPhone1FN  = value ; }
}
public string strPhone2FN 
{
get { return  m_strPhone2FN; }
set {m_strPhone2FN  = value ; }
}
public string strFaxFN 
{
get { return  m_strFaxFN; }
set {m_strFaxFN  = value ; }
}
public string strTelexFN 
{
get { return  m_strTelexFN; }
set {m_strTelexFN  = value ; }
}
public string strEmailFN 
{
get { return  m_strEmailFN; }
set {m_strEmailFN  = value ; }
}
public string sECTemailFN 
{
    get { return m_sECTemailFN; }
    set { m_sECTemailFN = value; }
}   
public string strZipCodeFN 
{
get { return  m_strZipCodeFN; }
set {m_strZipCodeFN  = value ; }
}
public string lngStudentNumberFN 
{
get { return  m_lngStudentNumberFN; }
set {m_lngStudentNumberFN  = value ; }
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
public string strNationalNumberFN 
{
get { return  m_strNationalNumberFN; }
set {m_strNationalNumberFN  = value ; }
}
public string strAddressFN 
{
get { return  m_strAddressFN; }
set {m_strAddressFN  = value ; }
}
public string strMilitarySourceFN 
{
get { return  m_strMilitarySourceFN; }
set {m_strMilitarySourceFN  = value ; }
}
public string strAgreementFN 
{
get { return  m_strAgreementFN; }
set {m_strAgreementFN  = value ; }
}
public string dateAgreementFN 
{
get { return  m_dateAgreementFN; }
set {m_dateAgreementFN  = value ; }
}
public string bCourseFN 
{
get { return  m_bCourseFN; }
set {m_bCourseFN  = value ; }
}
public string byteShiftFN 
{
get { return  m_byteShiftFN; }
set {m_byteShiftFN  = value ; }
}
public string strNationalIDFN 
{
get { return  m_strNationalIDFN; }
set {m_strNationalIDFN  = value ; }
}
public string intWorkPlaceFN 
{
get { return  m_intWorkPlaceFN; }
set {m_intWorkPlaceFN  = value ; }
}
public string strWorkPhoneFN 
{
get { return  m_strWorkPhoneFN; }
set {m_strWorkPhoneFN  = value ; }
}
public string strJopTitleFN 
{
get { return  m_strJopTitleFN; }
set {m_strJopTitleFN  = value ; }
}
public string intDelegationFN 
{
get { return  m_intDelegationFN; }
set {m_intDelegationFN  = value ; }
}
public string intSponsorFN 
{
get { return  m_intSponsorFN; }
set {m_intSponsorFN  = value ; }
}
public string dateEndSponsorshipFN 
{
get { return  m_dateEndSponsorshipFN; }
set {m_dateEndSponsorshipFN  = value ; }
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
public string strStudentPicFN 
{
get { return  m_strStudentPicFN; }
set {m_strStudentPicFN  = value ; }
}
public string isWorkingFN 
{
get { return  m_isWorkingFN; }
set {m_isWorkingFN  = value ; }
}
public string EthbaraNoFN 
{
get { return  m_EthbaraNoFN; }
set {m_EthbaraNoFN  = value ; }
}
public string FitnessStatusFN 
{
get { return  m_FitnessStatusFN; }
set {m_FitnessStatusFN  = value ; }
}
public string MaritalStatusFN 
{
get { return  m_MaritalStatusFN; }
set {m_MaritalStatusFN  = value ; }
}
public string NationalityofMotherFN 
{
get { return  m_NationalityofMotherFN; }
set {m_NationalityofMotherFN  = value ; }
}
public string EmploymentSectorFN 
{
get { return  m_EmploymentSectorFN; }
set {m_EmploymentSectorFN  = value ; }
}
 
#endregion
//================End Properties ===================
public Students_DataDAL()
{
try
{
this.TableName = "Reg_Students_Data";
this.lngSerialFN = m_TableName + ".lngSerial";
this.strFirstDescEnFN = m_TableName + ".strFirstDescEn";
this.strSecondDescEnFN = m_TableName + ".strSecondDescEn";
this.strThirdDescEnFN = m_TableName + ".strThirdDescEn";
this.strLastDescEnFN = m_TableName + ".strLastDescEn";
this.strFirstDescArFN = m_TableName + ".strFirstDescAr";
this.strSecondDescArFN = m_TableName + ".strSecondDescAr";
this.strThirdDescArFN = m_TableName + ".strThirdDescAr";
this.strLastDescArFN = m_TableName + ".strLastDescAr";
this.bSexFN = m_TableName + ".bSex";
this.dateBirthFN = m_TableName + ".dateBirth";
this.byteBirthCountryFN = m_TableName + ".byteBirthCountry";
this.byteBirthCityFN = m_TableName + ".byteBirthCity";
this.byteNationalityFN = m_TableName + ".byteNationality";
this.byteReligionFN = m_TableName + ".byteReligion";
this.byteIDTypeFN = m_TableName + ".byteIDType";
this.strIDFN = m_TableName + ".strID";
this.byteIDCountryFN = m_TableName + ".byteIDCountry";
this.dateEndIDFN = m_TableName + ".dateEndID";
this.byteMilitaryStatusFN = m_TableName + ".byteMilitaryStatus";
this.strMilitaryIDFN = m_TableName + ".strMilitaryID";
this.dateMilitaryPostponeFN = m_TableName + ".dateMilitaryPostpone";
this.strReleaseReasonFN = m_TableName + ".strReleaseReason";
this.strPostponeReasonFN = m_TableName + ".strPostponeReason";
this.dateMilitaryStartFN = m_TableName + ".dateMilitaryStart";
this.dateMilitaryEndFN = m_TableName + ".dateMilitaryEnd";
this.byteHomeCountryFN = m_TableName + ".byteHomeCountry";
this.byteHomeCityFN = m_TableName + ".byteHomeCity";
this.byteOriginCountryFN = m_TableName + ".byteOriginCountry";
this.byteOriginCityFN = m_TableName + ".byteOriginCity";
this.strPOBoxFN = m_TableName + ".strPOBox";
this.strPhone1FN = m_TableName + ".strPhone1";
this.strPhone2FN = m_TableName + ".strPhone2";
this.strFaxFN = m_TableName + ".strFax";
this.strTelexFN = m_TableName + ".strTelex";
this.strEmailFN = m_TableName + ".strEmail";
this.sECTemailFN = m_TableName + ".sECTemail";
this.strZipCodeFN = m_TableName + ".strZipCode";
this.lngStudentNumberFN = m_TableName + ".lngStudentNumber";
this.strCollegeFN = m_TableName + ".strCollege";
this.strDegreeFN = m_TableName + ".strDegree";
this.strSpecializationFN = m_TableName + ".strSpecialization";
this.strNationalNumberFN = m_TableName + ".strNationalNumber";
this.strAddressFN = m_TableName + ".strAddress";
this.strMilitarySourceFN = m_TableName + ".strMilitarySource";
this.strAgreementFN = m_TableName + ".strAgreement";
this.dateAgreementFN = m_TableName + ".dateAgreement";
this.bCourseFN = m_TableName + ".bCourse";
this.byteShiftFN = m_TableName + ".byteShift";
this.strNationalIDFN = m_TableName + ".strNationalID";
this.intWorkPlaceFN = m_TableName + ".intWorkPlace";
this.strWorkPhoneFN = m_TableName + ".strWorkPhone";
this.strJopTitleFN = m_TableName + ".strJopTitle";
this.intDelegationFN = m_TableName + ".intDelegation";
this.intSponsorFN = m_TableName + ".intSponsor";
this.dateEndSponsorshipFN = m_TableName + ".dateEndSponsorship";
this.strUserCreateFN = m_TableName + ".strUserCreate";
this.dateCreateFN = m_TableName + ".dateCreate";
this.strUserSaveFN = m_TableName + ".strUserSave";
this.dateLastSaveFN = m_TableName + ".dateLastSave";
this.strMachineFN = m_TableName + ".strMachine";
this.strNUserFN = m_TableName + ".strNUser";
this.strStudentPicFN = m_TableName + ".strStudentPic";

this.isWorkingFN = m_TableName + ".isWorking";
this.EthbaraNoFN = m_TableName + ".EthbaraNo";
this.FitnessStatusFN = m_TableName + ".FitnessStatus";
this.MaritalStatusFN = m_TableName + ".MaritalStatus";
this.NationalityofMotherFN = m_TableName + ".NationalityofMother";
this.EmploymentSectorFN = m_TableName + ".EmploymentSector";

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
sSQL +=lngSerialFN;
sSQL += " , " + strFirstDescEnFN;
sSQL += " , " + strSecondDescEnFN;
sSQL += " , " + strThirdDescEnFN;
sSQL += " , " + strLastDescEnFN;
sSQL += " , " + strFirstDescArFN;
sSQL += " , " + strSecondDescArFN;
sSQL += " , " + strThirdDescArFN;
sSQL += " , " + strLastDescArFN;
sSQL += " , " + bSexFN;
sSQL += " , " + dateBirthFN;
sSQL += " , " + byteBirthCountryFN;
sSQL += " , " + byteBirthCityFN;
sSQL += " , " + byteNationalityFN;
sSQL += " , " + byteReligionFN;
sSQL += " , " + byteIDTypeFN;
sSQL += " , " + strIDFN;
sSQL += " , " + byteIDCountryFN;
sSQL += " , " + dateEndIDFN;
sSQL += " , " + byteMilitaryStatusFN;
sSQL += " , " + strMilitaryIDFN;
sSQL += " , " + dateMilitaryPostponeFN;
sSQL += " , " + strReleaseReasonFN;
sSQL += " , " + strPostponeReasonFN;
sSQL += " , " + dateMilitaryStartFN;
sSQL += " , " + dateMilitaryEndFN;
sSQL += " , " + byteHomeCountryFN;
sSQL += " , " + byteHomeCityFN;
sSQL += " , " + byteOriginCountryFN;
sSQL += " , " + byteOriginCityFN;
sSQL += " , " + strPOBoxFN;
sSQL += " , " + strPhone1FN;
sSQL += " , " + strPhone2FN;
sSQL += " , " + strFaxFN;
sSQL += " , " + strTelexFN;
sSQL += " , " + strEmailFN;
sSQL += " , " + sECTemailFN;
sSQL += " , " + strZipCodeFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strSpecializationFN;
sSQL += " , " + strNationalNumberFN;
sSQL += " , " + strAddressFN;
sSQL += " , " + strMilitarySourceFN;
sSQL += " , " + strAgreementFN;
sSQL += " , " + dateAgreementFN;
sSQL += " , " + bCourseFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strNationalIDFN;
sSQL += " , " + intWorkPlaceFN;
sSQL += " , " + strWorkPhoneFN;
sSQL += " , " + strJopTitleFN;
sSQL += " , " + intDelegationFN;
sSQL += " , " + intSponsorFN;
sSQL += " , " + dateEndSponsorshipFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += " , " + strStudentPicFN;
sSQL += " , " + isWorkingFN;
sSQL += " , " + EthbaraNoFN;
sSQL += " , " + FitnessStatusFN;
sSQL += " , " + MaritalStatusFN;
sSQL += " , " + NationalityofMotherFN;
sSQL += " , " + EmploymentSectorFN;
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
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=lngSerialFN;
sSQL += " , " + strFirstDescEnFN;
sSQL += " , " + strSecondDescEnFN;
sSQL += " , " + strThirdDescEnFN;
sSQL += " , " + strLastDescEnFN;
sSQL += " , " + strFirstDescArFN;
sSQL += " , " + strSecondDescArFN;
sSQL += " , " + strThirdDescArFN;
sSQL += " , " + strLastDescArFN;
sSQL += " , " + bSexFN;
sSQL += " , " + dateBirthFN;
sSQL += " , " + byteBirthCountryFN;
sSQL += " , " + byteBirthCityFN;
sSQL += " , " + byteNationalityFN;
sSQL += " , " + byteReligionFN;
sSQL += " , " + byteIDTypeFN;
sSQL += " , " + strIDFN;
sSQL += " , " + byteIDCountryFN;
sSQL += " , " + dateEndIDFN;
sSQL += " , " + byteMilitaryStatusFN;
sSQL += " , " + strMilitaryIDFN;
sSQL += " , " + dateMilitaryPostponeFN;
sSQL += " , " + strReleaseReasonFN;
sSQL += " , " + strPostponeReasonFN;
sSQL += " , " + dateMilitaryStartFN;
sSQL += " , " + dateMilitaryEndFN;
sSQL += " , " + byteHomeCountryFN;
sSQL += " , " + byteHomeCityFN;
sSQL += " , " + byteOriginCountryFN;
sSQL += " , " + byteOriginCityFN;
sSQL += " , " + strPOBoxFN;
sSQL += " , " + strPhone1FN;
sSQL += " , " + strPhone2FN;
sSQL += " , " + strFaxFN;
sSQL += " , " + strTelexFN;
sSQL += " , " + strEmailFN;
sSQL += " , " + sECTemailFN;
sSQL += " , " + strZipCodeFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + strCollegeFN;
sSQL += " , " + strDegreeFN;
sSQL += " , " + strSpecializationFN;
sSQL += " , " + strNationalNumberFN;
sSQL += " , " + strAddressFN;
sSQL += " , " + strMilitarySourceFN;
sSQL += " , " + strAgreementFN;
sSQL += " , " + dateAgreementFN;
sSQL += " , " + bCourseFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + strNationalIDFN;
sSQL += " , " + intWorkPlaceFN;
sSQL += " , " + strWorkPhoneFN;
sSQL += " , " + strJopTitleFN;
sSQL += " , " + intDelegationFN;
sSQL += " , " + intSponsorFN;
sSQL += " , " + dateEndSponsorshipFN;
sSQL += " , " + strUserCreateFN;
sSQL += " , " + dateCreateFN;
sSQL += " , " + strUserSaveFN;
sSQL += " , " + dateLastSaveFN;
sSQL += " , " + strMachineFN;
sSQL += " , " + strNUserFN;
sSQL += " , " + strStudentPicFN;
sSQL += " , " + isWorkingFN;
sSQL += " , " + EthbaraNoFN;
sSQL += " , " + FitnessStatusFN;
sSQL += " , " + MaritalStatusFN;
sSQL += " , " + NationalityofMotherFN;
sSQL += " , " + EmploymentSectorFN;
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
//sSQL += LibraryMOD.GetFieldName(lngSerialFN) + "=@lngSerial";
sSQL += LibraryMOD.GetFieldName(strFirstDescEnFN) + "=@strFirstDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strSecondDescEnFN) + "=@strSecondDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strThirdDescEnFN) + "=@strThirdDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strLastDescEnFN) + "=@strLastDescEn";
sSQL += " , " + LibraryMOD.GetFieldName(strFirstDescArFN) + "=@strFirstDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(strSecondDescArFN) + "=@strSecondDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(strThirdDescArFN) + "=@strThirdDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(strLastDescArFN) + "=@strLastDescAr";
sSQL += " , " + LibraryMOD.GetFieldName(bSexFN) + "=@bSex";
sSQL += " , " + LibraryMOD.GetFieldName(dateBirthFN) + "=@dateBirth";
sSQL += " , " + LibraryMOD.GetFieldName(byteBirthCountryFN) + "=@byteBirthCountry";
sSQL += " , " + LibraryMOD.GetFieldName(byteBirthCityFN) + "=@byteBirthCity";
sSQL += " , " + LibraryMOD.GetFieldName(byteNationalityFN) + "=@byteNationality";
sSQL += " , " + LibraryMOD.GetFieldName(byteReligionFN) + "=@byteReligion";
sSQL += " , " + LibraryMOD.GetFieldName(byteIDTypeFN) + "=@byteIDType";
sSQL += " , " + LibraryMOD.GetFieldName(strIDFN) + "=@strID";
sSQL += " , " + LibraryMOD.GetFieldName(byteIDCountryFN) + "=@byteIDCountry";
sSQL += " , " + LibraryMOD.GetFieldName(dateEndIDFN) + "=@dateEndID";
sSQL += " , " + LibraryMOD.GetFieldName(byteMilitaryStatusFN) + "=@byteMilitaryStatus";
sSQL += " , " + LibraryMOD.GetFieldName(strMilitaryIDFN) + "=@strMilitaryID";
sSQL += " , " + LibraryMOD.GetFieldName(dateMilitaryPostponeFN) + "=@dateMilitaryPostpone";
sSQL += " , " + LibraryMOD.GetFieldName(strReleaseReasonFN) + "=@strReleaseReason";
sSQL += " , " + LibraryMOD.GetFieldName(strPostponeReasonFN) + "=@strPostponeReason";
sSQL += " , " + LibraryMOD.GetFieldName(dateMilitaryStartFN) + "=@dateMilitaryStart";
sSQL += " , " + LibraryMOD.GetFieldName(dateMilitaryEndFN) + "=@dateMilitaryEnd";
sSQL += " , " + LibraryMOD.GetFieldName(byteHomeCountryFN) + "=@byteHomeCountry";
sSQL += " , " + LibraryMOD.GetFieldName(byteHomeCityFN) + "=@byteHomeCity";
sSQL += " , " + LibraryMOD.GetFieldName(byteOriginCountryFN) + "=@byteOriginCountry";
sSQL += " , " + LibraryMOD.GetFieldName(byteOriginCityFN) + "=@byteOriginCity";
sSQL += " , " + LibraryMOD.GetFieldName(strPOBoxFN) + "=@strPOBox";
sSQL += " , " + LibraryMOD.GetFieldName(strPhone1FN) + "=@strPhone1";
sSQL += " , " + LibraryMOD.GetFieldName(strPhone2FN) + "=@strPhone2";
sSQL += " , " + LibraryMOD.GetFieldName(strFaxFN) + "=@strFax";
sSQL += " , " + LibraryMOD.GetFieldName(strTelexFN) + "=@strTelex";
sSQL += " , " + LibraryMOD.GetFieldName(strEmailFN) + "=@strEmail";
sSQL += " , " + LibraryMOD.GetFieldName(sECTemailFN) + "=@sECTemail";
sSQL += " , " + LibraryMOD.GetFieldName(strZipCodeFN) + "=@strZipCode";
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN) + "=@strDegree";
sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN) + "=@strSpecialization";
sSQL += " , " + LibraryMOD.GetFieldName(strNationalNumberFN) + "=@strNationalNumber";
sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN) + "=@strAddress";
sSQL += " , " + LibraryMOD.GetFieldName(strMilitarySourceFN) + "=@strMilitarySource";
sSQL += " , " + LibraryMOD.GetFieldName(strAgreementFN) + "=@strAgreement";
sSQL += " , " + LibraryMOD.GetFieldName(dateAgreementFN) + "=@dateAgreement";
sSQL += " , " + LibraryMOD.GetFieldName(bCourseFN) + "=@bCourse";
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
sSQL += " , " + LibraryMOD.GetFieldName(strNationalIDFN) + "=@strNationalID";
sSQL += " , " + LibraryMOD.GetFieldName(intWorkPlaceFN) + "=@intWorkPlace";
sSQL += " , " + LibraryMOD.GetFieldName(strWorkPhoneFN) + "=@strWorkPhone";
sSQL += " , " + LibraryMOD.GetFieldName(strJopTitleFN) + "=@strJopTitle";
sSQL += " , " + LibraryMOD.GetFieldName(intDelegationFN) + "=@intDelegation";
sSQL += " , " + LibraryMOD.GetFieldName(intSponsorFN) + "=@intSponsor";
sSQL += " , " + LibraryMOD.GetFieldName(dateEndSponsorshipFN) + "=@dateEndSponsorship";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " , " + LibraryMOD.GetFieldName(strStudentPicFN) + "=@strStudentPic";
sSQL += " , " + LibraryMOD.GetFieldName(isWorkingFN) + "=@isWorking";
sSQL += " , " + LibraryMOD.GetFieldName(EthbaraNoFN) + "=@EthbaraNo";
sSQL += " , " + LibraryMOD.GetFieldName(FitnessStatusFN) + "=@FitnessStatus";
sSQL += " , " + LibraryMOD.GetFieldName(MaritalStatusFN) + "=@MaritalStatus";
sSQL += " , " + LibraryMOD.GetFieldName(NationalityofMotherFN) + "=@NationalityofMother";
sSQL += " , " + LibraryMOD.GetFieldName(EmploymentSectorFN) + "=@EmploymentSector";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(lngSerialFN)+"=@lngSerial";
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
//sSQL +=LibraryMOD.GetFieldName(lngSerialFN);
sSQL += LibraryMOD.GetFieldName(strFirstDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSecondDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strThirdDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strLastDescEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(strFirstDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSecondDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(strThirdDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(strLastDescArFN);
sSQL += " , " + LibraryMOD.GetFieldName(bSexFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateBirthFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteBirthCountryFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteBirthCityFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteNationalityFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteReligionFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteIDTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteIDCountryFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateEndIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteMilitaryStatusFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMilitaryIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateMilitaryPostponeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strReleaseReasonFN);
sSQL += " , " + LibraryMOD.GetFieldName(strPostponeReasonFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateMilitaryStartFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateMilitaryEndFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteHomeCountryFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteHomeCityFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteOriginCountryFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteOriginCityFN);
sSQL += " , " + LibraryMOD.GetFieldName(strPOBoxFN);
sSQL += " , " + LibraryMOD.GetFieldName(strPhone1FN);
sSQL += " , " + LibraryMOD.GetFieldName(strPhone2FN);
sSQL += " , " + LibraryMOD.GetFieldName(strFaxFN);
sSQL += " , " + LibraryMOD.GetFieldName(strTelexFN);
sSQL += " , " + LibraryMOD.GetFieldName(strEmailFN);
sSQL += " , " + LibraryMOD.GetFieldName(sECTemailFN);
sSQL += " , " + LibraryMOD.GetFieldName(strZipCodeFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strDegreeFN);
sSQL += " , " + LibraryMOD.GetFieldName(strSpecializationFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNationalNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(strAddressFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMilitarySourceFN);
sSQL += " , " + LibraryMOD.GetFieldName(strAgreementFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateAgreementFN);
sSQL += " , " + LibraryMOD.GetFieldName(bCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNationalIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(intWorkPlaceFN);
sSQL += " , " + LibraryMOD.GetFieldName(strWorkPhoneFN);
sSQL += " , " + LibraryMOD.GetFieldName(strJopTitleFN);
sSQL += " , " + LibraryMOD.GetFieldName(intDelegationFN);
sSQL += " , " + LibraryMOD.GetFieldName(intSponsorFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateEndSponsorshipFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
sSQL += " , " + LibraryMOD.GetFieldName(strStudentPicFN);
sSQL += " , " + LibraryMOD.GetFieldName(isWorkingFN);
sSQL += " , " + LibraryMOD.GetFieldName(EthbaraNoFN);
sSQL += " , " + LibraryMOD.GetFieldName(FitnessStatusFN);
sSQL += " , " + LibraryMOD.GetFieldName(MaritalStatusFN);
sSQL += " , " + LibraryMOD.GetFieldName(NationalityofMotherFN);
sSQL += " , " + LibraryMOD.GetFieldName(EmploymentSectorFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
//sSQL += " @lngSerial";
sSQL += " @strFirstDescEn";
sSQL += " ,@strSecondDescEn";
sSQL += " ,@strThirdDescEn";
sSQL += " ,@strLastDescEn";
sSQL += " ,@strFirstDescAr";
sSQL += " ,@strSecondDescAr";
sSQL += " ,@strThirdDescAr";
sSQL += " ,@strLastDescAr";
sSQL += " ,@bSex";
sSQL += " ,@dateBirth";
sSQL += " ,@byteBirthCountry";
sSQL += " ,@byteBirthCity";
sSQL += " ,@byteNationality";
sSQL += " ,@byteReligion";
sSQL += " ,@byteIDType";
sSQL += " ,@strID";
sSQL += " ,@byteIDCountry";
sSQL += " ,@dateEndID";
sSQL += " ,@byteMilitaryStatus";
sSQL += " ,@strMilitaryID";
sSQL += " ,@dateMilitaryPostpone";
sSQL += " ,@strReleaseReason";
sSQL += " ,@strPostponeReason";
sSQL += " ,@dateMilitaryStart";
sSQL += " ,@dateMilitaryEnd";
sSQL += " ,@byteHomeCountry";
sSQL += " ,@byteHomeCity";
sSQL += " ,@byteOriginCountry";
sSQL += " ,@byteOriginCity";
sSQL += " ,@strPOBox";
sSQL += " ,@strPhone1";
sSQL += " ,@strPhone2";
sSQL += " ,@strFax";
sSQL += " ,@strTelex";
sSQL += " ,@strEmail";
sSQL += " ,@sECTemail";
sSQL += " ,@strZipCode";
sSQL += " ,@lngStudentNumber";
sSQL += " ,@strCollege";
sSQL += " ,@strDegree";
sSQL += " ,@strSpecialization";
sSQL += " ,@strNationalNumber";
sSQL += " ,@strAddress";
sSQL += " ,@strMilitarySource";
sSQL += " ,@strAgreement";
sSQL += " ,@dateAgreement";
sSQL += " ,@bCourse";
sSQL += " ,@byteShift";
sSQL += " ,@strNationalID";
sSQL += " ,@intWorkPlace";
sSQL += " ,@strWorkPhone";
sSQL += " ,@strJopTitle";
sSQL += " ,@intDelegation";
sSQL += " ,@intSponsor";
sSQL += " ,@dateEndSponsorship";
sSQL += " ,@strUserCreate";
sSQL += " ,@dateCreate";
sSQL += " ,@strUserSave";
sSQL += " ,@dateLastSave";
sSQL += " ,@strMachine";
sSQL += " ,@strNUser";
sSQL += " ,@strStudentPic";
sSQL += " ,@isWorking";
sSQL += " ,@EthbaraNo";
sSQL += " ,@FitnessStatus";
sSQL += " ,@MaritalStatus";
sSQL += " ,@NationalityofMother";
sSQL += " ,@EmploymentSector";
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
sSQL += LibraryMOD.GetFieldName(lngSerialFN)+"=@lngSerial";
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
public List< Students_Data> GetStudents_Data(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Students_Data
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
List<Students_Data> results = new List<Students_Data>();
try
{
//Default Value
Students_Data myStudents_Data = new Students_Data();
if (isDeafaultIncluded)
{
//Change the code here
myStudents_Data.lngSerial = 0;
myStudents_Data.strFirstDescEn = "Select Students_Data ...";
results.Add(myStudents_Data);
}
while (reader.Read())
{
myStudents_Data = new Students_Data();
if (reader[LibraryMOD.GetFieldName(lngSerialFN)].Equals(DBNull.Value))
{
myStudents_Data.lngSerial = 0;
}
else
{
myStudents_Data.lngSerial = int.Parse(reader[LibraryMOD.GetFieldName( lngSerialFN) ].ToString());
}
myStudents_Data.strFirstDescEn =reader[LibraryMOD.GetFieldName( strFirstDescEnFN) ].ToString();
myStudents_Data.strSecondDescEn =reader[LibraryMOD.GetFieldName( strSecondDescEnFN) ].ToString();
myStudents_Data.strThirdDescEn =reader[LibraryMOD.GetFieldName( strThirdDescEnFN) ].ToString();
myStudents_Data.strLastDescEn =reader[LibraryMOD.GetFieldName( strLastDescEnFN) ].ToString();
myStudents_Data.strFirstDescAr =reader[LibraryMOD.GetFieldName( strFirstDescArFN) ].ToString();
myStudents_Data.strSecondDescAr =reader[LibraryMOD.GetFieldName( strSecondDescArFN) ].ToString();
myStudents_Data.strThirdDescAr =reader[LibraryMOD.GetFieldName( strThirdDescArFN) ].ToString();
myStudents_Data.strLastDescAr =reader[LibraryMOD.GetFieldName( strLastDescArFN) ].ToString();
myStudents_Data.bSex =(bool)reader[LibraryMOD.GetFieldName( bSexFN) ];
if (!reader[LibraryMOD.GetFieldName(dateBirthFN)].Equals(DBNull.Value))
{
myStudents_Data.dateBirth = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateBirthFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteBirthCountryFN)].Equals(DBNull.Value))
{
myStudents_Data.byteBirthCountry = 0;
}
else
{
myStudents_Data.byteBirthCountry = int.Parse(reader[LibraryMOD.GetFieldName( byteBirthCountryFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteBirthCityFN)].Equals(DBNull.Value))
{
myStudents_Data.byteBirthCity = 0;
}
else
{
myStudents_Data.byteBirthCity = int.Parse(reader[LibraryMOD.GetFieldName( byteBirthCityFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteNationalityFN)].Equals(DBNull.Value))
{
myStudents_Data.byteNationality = 0;
}
else
{
myStudents_Data.byteNationality = int.Parse(reader[LibraryMOD.GetFieldName( byteNationalityFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteReligionFN)].Equals(DBNull.Value))
{
myStudents_Data.byteReligion = 0;
}
else
{
myStudents_Data.byteReligion = int.Parse(reader[LibraryMOD.GetFieldName( byteReligionFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteIDTypeFN)].Equals(DBNull.Value))
{
myStudents_Data.byteIDType = 0;
}
else
{
myStudents_Data.byteIDType = int.Parse(reader[LibraryMOD.GetFieldName( byteIDTypeFN) ].ToString());
}
myStudents_Data.strID =reader[LibraryMOD.GetFieldName( strIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteIDCountryFN)].Equals(DBNull.Value))
{
myStudents_Data.byteIDCountry = 0;
}
else
{
myStudents_Data.byteIDCountry = int.Parse(reader[LibraryMOD.GetFieldName( byteIDCountryFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(dateEndIDFN)].Equals(DBNull.Value))
{
myStudents_Data.dateEndID = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateEndIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteMilitaryStatusFN)].Equals(DBNull.Value))
{
myStudents_Data.byteMilitaryStatus = 0;
}
else
{
myStudents_Data.byteMilitaryStatus = int.Parse(reader[LibraryMOD.GetFieldName( byteMilitaryStatusFN) ].ToString());
}
myStudents_Data.strMilitaryID =reader[LibraryMOD.GetFieldName( strMilitaryIDFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateMilitaryPostponeFN)].Equals(DBNull.Value))
{
myStudents_Data.dateMilitaryPostpone = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateMilitaryPostponeFN) ].ToString());
}
myStudents_Data.strReleaseReason =reader[LibraryMOD.GetFieldName( strReleaseReasonFN) ].ToString();
myStudents_Data.strPostponeReason =reader[LibraryMOD.GetFieldName( strPostponeReasonFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateMilitaryStartFN)].Equals(DBNull.Value))
{
myStudents_Data.dateMilitaryStart = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateMilitaryStartFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(dateMilitaryEndFN)].Equals(DBNull.Value))
{
myStudents_Data.dateMilitaryEnd = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateMilitaryEndFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteHomeCountryFN)].Equals(DBNull.Value))
{
myStudents_Data.byteHomeCountry = 0;
}
else
{
myStudents_Data.byteHomeCountry = int.Parse(reader[LibraryMOD.GetFieldName( byteHomeCountryFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteHomeCityFN)].Equals(DBNull.Value))
{
myStudents_Data.byteHomeCity = 0;
}
else
{
myStudents_Data.byteHomeCity = int.Parse(reader[LibraryMOD.GetFieldName( byteHomeCityFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteOriginCountryFN)].Equals(DBNull.Value))
{
myStudents_Data.byteOriginCountry = 0;
}
else
{
myStudents_Data.byteOriginCountry = int.Parse(reader[LibraryMOD.GetFieldName( byteOriginCountryFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteOriginCityFN)].Equals(DBNull.Value))
{
myStudents_Data.byteOriginCity = 0;
}
else
{
myStudents_Data.byteOriginCity = int.Parse(reader[LibraryMOD.GetFieldName( byteOriginCityFN) ].ToString());
}
myStudents_Data.strPOBox =reader[LibraryMOD.GetFieldName( strPOBoxFN) ].ToString();
myStudents_Data.strPhone1 =reader[LibraryMOD.GetFieldName( strPhone1FN) ].ToString();
myStudents_Data.strPhone2 =reader[LibraryMOD.GetFieldName( strPhone2FN) ].ToString();
myStudents_Data.strFax =reader[LibraryMOD.GetFieldName( strFaxFN) ].ToString();
myStudents_Data.strTelex =reader[LibraryMOD.GetFieldName( strTelexFN) ].ToString();
myStudents_Data.strEmail =reader[LibraryMOD.GetFieldName( strEmailFN) ].ToString();
myStudents_Data.sECTemail = reader[LibraryMOD.GetFieldName(sECTemailFN)].ToString();
myStudents_Data.strZipCode =reader[LibraryMOD.GetFieldName( strZipCodeFN) ].ToString();
myStudents_Data.lngStudentNumber =reader[LibraryMOD.GetFieldName( lngStudentNumberFN) ].ToString();
myStudents_Data.strCollege =reader[LibraryMOD.GetFieldName( strCollegeFN) ].ToString();
myStudents_Data.strDegree =reader[LibraryMOD.GetFieldName( strDegreeFN) ].ToString();
myStudents_Data.strSpecialization =reader[LibraryMOD.GetFieldName( strSpecializationFN) ].ToString();
myStudents_Data.strNationalNumber =reader[LibraryMOD.GetFieldName( strNationalNumberFN) ].ToString();
myStudents_Data.strAddress =reader[LibraryMOD.GetFieldName( strAddressFN) ].ToString();
myStudents_Data.strMilitarySource =reader[LibraryMOD.GetFieldName( strMilitarySourceFN) ].ToString();
myStudents_Data.strAgreement =reader[LibraryMOD.GetFieldName( strAgreementFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateAgreementFN)].Equals(DBNull.Value))
{
myStudents_Data.dateAgreement = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateAgreementFN) ].ToString());
}
myStudents_Data.bCourse =reader[LibraryMOD.GetFieldName( bCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myStudents_Data.byteShift = 0;
}
else
{
myStudents_Data.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
myStudents_Data.strNationalID =reader[LibraryMOD.GetFieldName( strNationalIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(intWorkPlaceFN)].Equals(DBNull.Value))
{
myStudents_Data.intWorkPlace = 0;
}
else
{
myStudents_Data.intWorkPlace = int.Parse(reader[LibraryMOD.GetFieldName( intWorkPlaceFN) ].ToString());
}
myStudents_Data.strWorkPhone =reader[LibraryMOD.GetFieldName( strWorkPhoneFN) ].ToString();
myStudents_Data.strJopTitle =reader[LibraryMOD.GetFieldName( strJopTitleFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(intDelegationFN)].Equals(DBNull.Value))
{
myStudents_Data.intDelegation = 0;
}
else
{
myStudents_Data.intDelegation = int.Parse(reader[LibraryMOD.GetFieldName( intDelegationFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intSponsorFN)].Equals(DBNull.Value))
{
myStudents_Data.intSponsor = 0;
}
else
{
myStudents_Data.intSponsor = int.Parse(reader[LibraryMOD.GetFieldName( intSponsorFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(dateEndSponsorshipFN)].Equals(DBNull.Value))
{
myStudents_Data.dateEndSponsorship = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateEndSponsorshipFN) ].ToString());
}
myStudents_Data.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
{
myStudents_Data.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myStudents_Data.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
{
myStudents_Data.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myStudents_Data.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myStudents_Data.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
myStudents_Data.strStudentPic =reader[LibraryMOD.GetFieldName( strStudentPicFN) ].ToString();
myStudents_Data.isWorking = (bool)reader[LibraryMOD.GetFieldName(isWorkingFN)];
myStudents_Data.FitnessStatus = (bool)reader[LibraryMOD.GetFieldName(FitnessStatusFN)];
myStudents_Data.EthbaraNo = reader[LibraryMOD.GetFieldName(EthbaraNoFN)].ToString();
if (reader[LibraryMOD.GetFieldName(MaritalStatusFN)].Equals(DBNull.Value))
{
    myStudents_Data.MaritalStatus = 0;
}
else
{
    myStudents_Data.MaritalStatus = int.Parse(reader[LibraryMOD.GetFieldName(MaritalStatusFN)].ToString());
}
if (reader[LibraryMOD.GetFieldName(NationalityofMotherFN)].Equals(DBNull.Value))
{
    myStudents_Data.NationalityofMother = 0;
}
else
{
    myStudents_Data.NationalityofMother = int.Parse(reader[LibraryMOD.GetFieldName(NationalityofMotherFN)].ToString());
}

if (reader[LibraryMOD.GetFieldName(EmploymentSectorFN)].Equals(DBNull.Value))
{
    myStudents_Data.EmploymentSector = 0;
}
else
{
    myStudents_Data.EmploymentSector = int.Parse(reader[LibraryMOD.GetFieldName(EmploymentSectorFN)].ToString());
}

 results.Add(myStudents_Data);
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
public int UpdateStudents_Data(InitializeModule.EnumCampus Campus, int iMode,
    int lngSerial,string strFirstDescEn,string strSecondDescEn,
    string strThirdDescEn,string strLastDescEn,string strFirstDescAr,
    string strSecondDescAr,string strThirdDescAr,string strLastDescAr,
    bool bSex,DateTime dateBirth,int byteBirthCountry,int byteBirthCity,
    int byteNationality,int byteReligion,int byteIDType,string strID,
    int byteIDCountry,DateTime dateEndID,int byteMilitaryStatus,string strMilitaryID,
    DateTime dateMilitaryPostpone,string strReleaseReason,string strPostponeReason,
    DateTime dateMilitaryStart,DateTime dateMilitaryEnd,int byteHomeCountry,
    int byteHomeCity,int byteOriginCountry,int byteOriginCity,string strPOBox,
    string strPhone1,string strPhone2,string strFax,string strTelex,
    string strEmail, string  sECTemail, string strZipCode, string lngStudentNumber,
    string strCollege,string strDegree,string strSpecialization,
    string strNationalNumber,string strAddress,string strMilitarySource,
    string strAgreement,DateTime dateAgreement,string bCourse,int byteShift,
    string strNationalID,int intWorkPlace,string strWorkPhone,
    string strJopTitle,int intDelegation,int intSponsor,DateTime dateEndSponsorship,
    string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,
    string strMachine,string strNUser,string strStudentPic,bool bisWorking,bool bFitnessStatus,
    string EthbaraNo, int MaritalStatus, int NationalityofMother, int EmploymentSector)

{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Students_Data theStudents_Data = new Students_Data();
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
Cmd.Parameters.Add(new SqlParameter("@lngSerial",lngSerial));
Cmd.Parameters.Add(new SqlParameter("@strFirstDescEn",strFirstDescEn));
Cmd.Parameters.Add(new SqlParameter("@strSecondDescEn",strSecondDescEn));
Cmd.Parameters.Add(new SqlParameter("@strThirdDescEn",strThirdDescEn));
Cmd.Parameters.Add(new SqlParameter("@strLastDescEn",strLastDescEn));
Cmd.Parameters.Add(new SqlParameter("@strFirstDescAr",strFirstDescAr));
Cmd.Parameters.Add(new SqlParameter("@strSecondDescAr",strSecondDescAr));
Cmd.Parameters.Add(new SqlParameter("@strThirdDescAr",strThirdDescAr));
Cmd.Parameters.Add(new SqlParameter("@strLastDescAr",strLastDescAr));
Cmd.Parameters.Add(new SqlParameter("@bSex",bSex));

DateTime dateDefaultDate = Convert.ToDateTime("01/01/1900");
if (dateBirth != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateBirth", dateBirth.ToLongDateString ()));
}
else
{
    SqlParameter theRiskID = new SqlParameter( "@dateBirth", SqlDbType.DateTime, 16,LibraryMOD.GetFieldName (dateBirthFN ) );

    theRiskID.Value = dateDefaultDate;

    Cmd.Parameters.Add(theRiskID);



    //Cmd.Parameters.Add(new SqlParameter("@dateBirth", null    ));
   

}

if (dateEndID != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateEndID", dateEndID.ToLongDateString()));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateEndID", dateDefaultDate));
}

if (dateEndSponsorship != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateEndSponsorship", dateEndSponsorship.ToLongDateString()));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateEndSponsorship", dateDefaultDate));
}
if (dateMilitaryEnd != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateMilitaryEnd", dateMilitaryEnd.ToLongDateString()));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateMilitaryEnd", dateDefaultDate));
}

if (dateMilitaryStart != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateMilitaryStart", dateMilitaryStart.ToLongDateString()));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateMilitaryStart", dateDefaultDate));
}
if (dateAgreement != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateAgreement", dateAgreement.ToLongDateString()));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateAgreement", dateDefaultDate));
}

if (dateMilitaryPostpone != DateTime.MinValue)
{
    Cmd.Parameters.Add(new SqlParameter("@dateMilitaryPostpone", dateMilitaryPostpone.ToLongDateString()));
}
else
{
    Cmd.Parameters.Add(new SqlParameter("@dateMilitaryPostpone", dateDefaultDate));
}
Cmd.Parameters.Add(new SqlParameter("@byteBirthCountry",byteBirthCountry));
Cmd.Parameters.Add(new SqlParameter("@byteBirthCity",byteBirthCity));
Cmd.Parameters.Add(new SqlParameter("@byteNationality",byteNationality));
Cmd.Parameters.Add(new SqlParameter("@byteReligion",byteReligion));
Cmd.Parameters.Add(new SqlParameter("@byteIDType",byteIDType));
Cmd.Parameters.Add(new SqlParameter("@strID",strID));
Cmd.Parameters.Add(new SqlParameter("@byteIDCountry",byteIDCountry));

Cmd.Parameters.Add(new SqlParameter("@byteMilitaryStatus",byteMilitaryStatus));
Cmd.Parameters.Add(new SqlParameter("@strMilitaryID",strMilitaryID));
Cmd.Parameters.Add(new SqlParameter("@strReleaseReason",strReleaseReason));
Cmd.Parameters.Add(new SqlParameter("@strPostponeReason",strPostponeReason));

Cmd.Parameters.Add(new SqlParameter("@byteHomeCountry",byteHomeCountry));
Cmd.Parameters.Add(new SqlParameter("@byteHomeCity",byteHomeCity));
Cmd.Parameters.Add(new SqlParameter("@byteOriginCountry",byteOriginCountry));
Cmd.Parameters.Add(new SqlParameter("@byteOriginCity",byteOriginCity));
Cmd.Parameters.Add(new SqlParameter("@strPOBox",strPOBox));
Cmd.Parameters.Add(new SqlParameter("@strPhone1",strPhone1));
Cmd.Parameters.Add(new SqlParameter("@strPhone2",strPhone2));
Cmd.Parameters.Add(new SqlParameter("@strFax",strFax));
Cmd.Parameters.Add(new SqlParameter("@strTelex",strTelex));
Cmd.Parameters.Add(new SqlParameter("@strEmail",strEmail));
Cmd.Parameters.Add(new SqlParameter("@sECTemail", sECTemail));
Cmd.Parameters.Add(new SqlParameter("@strZipCode",strZipCode));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));
Cmd.Parameters.Add(new SqlParameter("@strCollege",strCollege));
Cmd.Parameters.Add(new SqlParameter("@strDegree",strDegree));
Cmd.Parameters.Add(new SqlParameter("@strSpecialization",strSpecialization));
Cmd.Parameters.Add(new SqlParameter("@strNationalNumber",strNationalNumber));
Cmd.Parameters.Add(new SqlParameter("@strAddress",strAddress));
Cmd.Parameters.Add(new SqlParameter("@strMilitarySource",strMilitarySource));
Cmd.Parameters.Add(new SqlParameter("@strAgreement",strAgreement));

Cmd.Parameters.Add(new SqlParameter("@bCourse",bCourse));
Cmd.Parameters.Add(new SqlParameter("@byteShift",byteShift));
Cmd.Parameters.Add(new SqlParameter("@strNationalID",strNationalID));
Cmd.Parameters.Add(new SqlParameter("@intWorkPlace",intWorkPlace));
Cmd.Parameters.Add(new SqlParameter("@strWorkPhone",strWorkPhone));
Cmd.Parameters.Add(new SqlParameter("@strJopTitle",strJopTitle));
Cmd.Parameters.Add(new SqlParameter("@intDelegation",intDelegation));
Cmd.Parameters.Add(new SqlParameter("@intSponsor",intSponsor));

    

Cmd.Parameters.Add(new SqlParameter("@strUserCreate",strUserCreate));
Cmd.Parameters.Add(new SqlParameter("@dateCreate",dateCreate));
Cmd.Parameters.Add(new SqlParameter("@strUserSave",strUserSave));
Cmd.Parameters.Add(new SqlParameter("@dateLastSave",dateLastSave));
Cmd.Parameters.Add(new SqlParameter("@strMachine",strMachine));
Cmd.Parameters.Add(new SqlParameter("@strNUser",strNUser));
Cmd.Parameters.Add(new SqlParameter("@strStudentPic",strStudentPic));

Cmd.Parameters.Add(new SqlParameter("@isWorking", isWorking));
Cmd.Parameters.Add(new SqlParameter("@EthbaraNo", EthbaraNo));
Cmd.Parameters.Add(new SqlParameter("@FitnessStatus", FitnessStatus));
Cmd.Parameters.Add(new SqlParameter("@MaritalStatus", MaritalStatus));
Cmd.Parameters.Add(new SqlParameter("@NationalityofMother", NationalityofMother));
Cmd.Parameters.Add(new SqlParameter("@EmploymentSector", EmploymentSector));

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
public int DeleteStudents_Data(InitializeModule.EnumCampus Campus,int lngSerial)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@lngSerial", lngSerial ));
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
DataTable dt = new DataTable("Students_Data");
DataView dv = new DataView();
List<Students_Data> myStudents_Datas = new List<Students_Data>();
try
{
myStudents_Datas = GetStudents_Data(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("lngSerial", Type.GetType("int identity"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strFirstDescEn", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strSecondDescEn", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myStudents_Datas.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myStudents_Datas[i].lngSerial;
  dr[2] = myStudents_Datas[i].strFirstDescEn;
  dr[3] = myStudents_Datas[i].strSecondDescEn;
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
myStudents_Datas.Clear();
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
sSQL += lngSerialFN;
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
public class Students_DataCls : Students_DataDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daStudents_Data;
private DataSet m_dsStudents_Data;
public DataRow Students_DataDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsStudents_Data
{
get { return m_dsStudents_Data ; }
set { m_dsStudents_Data = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Students_DataCls()
{
try
{
dsStudents_Data= new DataSet();

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
public virtual SqlDataAdapter GetStudents_DataDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daStudents_Data = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daStudents_Data);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daStudents_Data.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudents_Data;
}
public virtual SqlDataAdapter GetStudents_DataDataAdapter(SqlConnection con)  
{
try
{
daStudents_Data = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daStudents_Data.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdStudents_Data;
cmdStudents_Data = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@lngSerial", SqlDbType.Int, 4, "lngSerial" );
daStudents_Data.SelectCommand = cmdStudents_Data;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdStudents_Data = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdStudents_Data.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
cmdStudents_Data.Parameters.Add("@strFirstDescEn", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strFirstDescEnFN));
cmdStudents_Data.Parameters.Add("@strSecondDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSecondDescEnFN));
cmdStudents_Data.Parameters.Add("@strThirdDescEn", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strThirdDescEnFN));
cmdStudents_Data.Parameters.Add("@strLastDescEn", SqlDbType.NVarChar,180, LibraryMOD.GetFieldName(strLastDescEnFN));
cmdStudents_Data.Parameters.Add("@strFirstDescAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strFirstDescArFN));
cmdStudents_Data.Parameters.Add("@strSecondDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSecondDescArFN));
cmdStudents_Data.Parameters.Add("@strThirdDescAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strThirdDescArFN));
cmdStudents_Data.Parameters.Add("@strLastDescAr", SqlDbType.NVarChar,140, LibraryMOD.GetFieldName(strLastDescArFN));
cmdStudents_Data.Parameters.Add("@bSex", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bSexFN));
cmdStudents_Data.Parameters.Add("@dateBirth", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateBirthFN));
cmdStudents_Data.Parameters.Add("@byteBirthCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteBirthCountryFN));
cmdStudents_Data.Parameters.Add("@byteBirthCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteBirthCityFN));
cmdStudents_Data.Parameters.Add("@byteNationality", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteNationalityFN));
cmdStudents_Data.Parameters.Add("@byteReligion", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteReligionFN));
cmdStudents_Data.Parameters.Add("@byteIDType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteIDTypeFN));
cmdStudents_Data.Parameters.Add("@strID", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strIDFN));
cmdStudents_Data.Parameters.Add("@byteIDCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteIDCountryFN));
cmdStudents_Data.Parameters.Add("@dateEndID", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateEndIDFN));
cmdStudents_Data.Parameters.Add("@byteMilitaryStatus", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMilitaryStatusFN));
cmdStudents_Data.Parameters.Add("@strMilitaryID", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strMilitaryIDFN));
cmdStudents_Data.Parameters.Add("@dateMilitaryPostpone", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateMilitaryPostponeFN));
cmdStudents_Data.Parameters.Add("@strReleaseReason", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strReleaseReasonFN));
cmdStudents_Data.Parameters.Add("@strPostponeReason", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strPostponeReasonFN));
cmdStudents_Data.Parameters.Add("@dateMilitaryStart", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateMilitaryStartFN));
cmdStudents_Data.Parameters.Add("@dateMilitaryEnd", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateMilitaryEndFN));
cmdStudents_Data.Parameters.Add("@byteHomeCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteHomeCountryFN));
cmdStudents_Data.Parameters.Add("@byteHomeCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteHomeCityFN));
cmdStudents_Data.Parameters.Add("@byteOriginCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteOriginCountryFN));
cmdStudents_Data.Parameters.Add("@byteOriginCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteOriginCityFN));
cmdStudents_Data.Parameters.Add("@strPOBox", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strPOBoxFN));
cmdStudents_Data.Parameters.Add("@strPhone1", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strPhone1FN));
cmdStudents_Data.Parameters.Add("@strPhone2", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strPhone2FN));
cmdStudents_Data.Parameters.Add("@strFax", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strFaxFN));
cmdStudents_Data.Parameters.Add("@strTelex", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strTelexFN));
cmdStudents_Data.Parameters.Add("@strEmail", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strEmailFN));
cmdStudents_Data.Parameters.Add("@strZipCode", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strZipCodeFN));
cmdStudents_Data.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdStudents_Data.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
cmdStudents_Data.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdStudents_Data.Parameters.Add("@strSpecialization", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strSpecializationFN));
cmdStudents_Data.Parameters.Add("@strNationalNumber", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(strNationalNumberFN));
cmdStudents_Data.Parameters.Add("@strAddress", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strAddressFN));
cmdStudents_Data.Parameters.Add("@strMilitarySource", SqlDbType.NVarChar,140, LibraryMOD.GetFieldName(strMilitarySourceFN));
cmdStudents_Data.Parameters.Add("@strAgreement", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strAgreementFN));
cmdStudents_Data.Parameters.Add("@dateAgreement", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateAgreementFN));
cmdStudents_Data.Parameters.Add("@bCourse", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bCourseFN));
cmdStudents_Data.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdStudents_Data.Parameters.Add("@strNationalID", SqlDbType.NVarChar,36, LibraryMOD.GetFieldName(strNationalIDFN));
cmdStudents_Data.Parameters.Add("@intWorkPlace", SqlDbType.Int,4, LibraryMOD.GetFieldName(intWorkPlaceFN));
cmdStudents_Data.Parameters.Add("@strWorkPhone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strWorkPhoneFN));
cmdStudents_Data.Parameters.Add("@strJopTitle", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strJopTitleFN));
cmdStudents_Data.Parameters.Add("@intDelegation", SqlDbType.Int,4, LibraryMOD.GetFieldName(intDelegationFN));
cmdStudents_Data.Parameters.Add("@intSponsor", SqlDbType.Int,4, LibraryMOD.GetFieldName(intSponsorFN));
cmdStudents_Data.Parameters.Add("@dateEndSponsorship", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateEndSponsorshipFN));
cmdStudents_Data.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdStudents_Data.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdStudents_Data.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdStudents_Data.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdStudents_Data.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdStudents_Data.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
cmdStudents_Data.Parameters.Add("@strStudentPic", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(strStudentPicFN));

cmdStudents_Data.Parameters.Add("@isWorking", SqlDbType.Bit , 1, LibraryMOD.GetFieldName(isWorkingFN));
cmdStudents_Data.Parameters.Add("@FitnessStatus", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(FitnessStatusFN));
cmdStudents_Data.Parameters.Add("@EthbaraNo", SqlDbType.VarChar, 30, LibraryMOD.GetFieldName(EthbaraNoFN));
cmdStudents_Data.Parameters.Add("@MaritalStatus", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaritalStatusFN));
cmdStudents_Data.Parameters.Add("@NationalityofMother", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NationalityofMotherFN));
cmdStudents_Data.Parameters.Add("@EmploymentSector", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmploymentSectorFN));
//m_isWorkingFN;
//m_EthbaraNoFN;
//m_FitnessStatusFN;
//m_MaritalStatusFN;
//m_NationalityofMotherFN;
//m_EmploymentSectorFN;

Parmeter = cmdStudents_Data.Parameters.Add("@lngSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngSerialFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daStudents_Data.UpdateCommand = cmdStudents_Data;
daStudents_Data.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdStudents_Data = new SqlCommand(GetInsertCommand(), con);
cmdStudents_Data.Parameters.Add("@lngSerial", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngSerialFN));
cmdStudents_Data.Parameters.Add("@strFirstDescEn", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strFirstDescEnFN));
cmdStudents_Data.Parameters.Add("@strSecondDescEn", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSecondDescEnFN));
cmdStudents_Data.Parameters.Add("@strThirdDescEn", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strThirdDescEnFN));
cmdStudents_Data.Parameters.Add("@strLastDescEn", SqlDbType.NVarChar,180, LibraryMOD.GetFieldName(strLastDescEnFN));
cmdStudents_Data.Parameters.Add("@strFirstDescAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strFirstDescArFN));
cmdStudents_Data.Parameters.Add("@strSecondDescAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strSecondDescArFN));
cmdStudents_Data.Parameters.Add("@strThirdDescAr", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strThirdDescArFN));
cmdStudents_Data.Parameters.Add("@strLastDescAr", SqlDbType.NVarChar,140, LibraryMOD.GetFieldName(strLastDescArFN));
cmdStudents_Data.Parameters.Add("@bSex", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bSexFN));
cmdStudents_Data.Parameters.Add("@dateBirth", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateBirthFN));
cmdStudents_Data.Parameters.Add("@byteBirthCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteBirthCountryFN));
cmdStudents_Data.Parameters.Add("@byteBirthCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteBirthCityFN));
cmdStudents_Data.Parameters.Add("@byteNationality", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteNationalityFN));
cmdStudents_Data.Parameters.Add("@byteReligion", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteReligionFN));
cmdStudents_Data.Parameters.Add("@byteIDType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteIDTypeFN));
cmdStudents_Data.Parameters.Add("@strID", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strIDFN));
cmdStudents_Data.Parameters.Add("@byteIDCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteIDCountryFN));
cmdStudents_Data.Parameters.Add("@dateEndID", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateEndIDFN));
cmdStudents_Data.Parameters.Add("@byteMilitaryStatus", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteMilitaryStatusFN));
cmdStudents_Data.Parameters.Add("@strMilitaryID", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strMilitaryIDFN));
cmdStudents_Data.Parameters.Add("@dateMilitaryPostpone", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateMilitaryPostponeFN));
cmdStudents_Data.Parameters.Add("@strReleaseReason", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strReleaseReasonFN));
cmdStudents_Data.Parameters.Add("@strPostponeReason", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strPostponeReasonFN));
cmdStudents_Data.Parameters.Add("@dateMilitaryStart", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateMilitaryStartFN));
cmdStudents_Data.Parameters.Add("@dateMilitaryEnd", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateMilitaryEndFN));
cmdStudents_Data.Parameters.Add("@byteHomeCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteHomeCountryFN));
cmdStudents_Data.Parameters.Add("@byteHomeCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteHomeCityFN));
cmdStudents_Data.Parameters.Add("@byteOriginCountry", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteOriginCountryFN));
cmdStudents_Data.Parameters.Add("@byteOriginCity", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteOriginCityFN));
cmdStudents_Data.Parameters.Add("@strPOBox", SqlDbType.NVarChar,60, LibraryMOD.GetFieldName(strPOBoxFN));
cmdStudents_Data.Parameters.Add("@strPhone1", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strPhone1FN));
cmdStudents_Data.Parameters.Add("@strPhone2", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strPhone2FN));
cmdStudents_Data.Parameters.Add("@strFax", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strFaxFN));
cmdStudents_Data.Parameters.Add("@strTelex", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strTelexFN));
cmdStudents_Data.Parameters.Add("@strEmail", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strEmailFN));
cmdStudents_Data.Parameters.Add("@strZipCode", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strZipCodeFN));
cmdStudents_Data.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdStudents_Data.Parameters.Add("@strCollege", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strCollegeFN));
cmdStudents_Data.Parameters.Add("@strDegree", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strDegreeFN));
cmdStudents_Data.Parameters.Add("@strSpecialization", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strSpecializationFN));
cmdStudents_Data.Parameters.Add("@strNationalNumber", SqlDbType.NVarChar,20, LibraryMOD.GetFieldName(strNationalNumberFN));
cmdStudents_Data.Parameters.Add("@strAddress", SqlDbType.NVarChar,200, LibraryMOD.GetFieldName(strAddressFN));
cmdStudents_Data.Parameters.Add("@strMilitarySource", SqlDbType.NVarChar,140, LibraryMOD.GetFieldName(strMilitarySourceFN));
cmdStudents_Data.Parameters.Add("@strAgreement", SqlDbType.NVarChar,40, LibraryMOD.GetFieldName(strAgreementFN));
cmdStudents_Data.Parameters.Add("@dateAgreement", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateAgreementFN));
cmdStudents_Data.Parameters.Add("@bCourse", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bCourseFN));
cmdStudents_Data.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdStudents_Data.Parameters.Add("@strNationalID", SqlDbType.NVarChar,36, LibraryMOD.GetFieldName(strNationalIDFN));
cmdStudents_Data.Parameters.Add("@intWorkPlace", SqlDbType.Int,4, LibraryMOD.GetFieldName(intWorkPlaceFN));
cmdStudents_Data.Parameters.Add("@strWorkPhone", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strWorkPhoneFN));
cmdStudents_Data.Parameters.Add("@strJopTitle", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strJopTitleFN));
cmdStudents_Data.Parameters.Add("@intDelegation", SqlDbType.Int,4, LibraryMOD.GetFieldName(intDelegationFN));
cmdStudents_Data.Parameters.Add("@intSponsor", SqlDbType.Int,4, LibraryMOD.GetFieldName(intSponsorFN));
cmdStudents_Data.Parameters.Add("@dateEndSponsorship", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateEndSponsorshipFN));
cmdStudents_Data.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdStudents_Data.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdStudents_Data.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdStudents_Data.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdStudents_Data.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdStudents_Data.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
cmdStudents_Data.Parameters.Add("@strStudentPic", SqlDbType.VarChar,100, LibraryMOD.GetFieldName(strStudentPicFN));

cmdStudents_Data.Parameters.Add("@isWorking", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(isWorkingFN));
cmdStudents_Data.Parameters.Add("@FitnessStatus", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(FitnessStatusFN));
cmdStudents_Data.Parameters.Add("@EthbaraNo", SqlDbType.VarChar, 30, LibraryMOD.GetFieldName(EthbaraNoFN));
cmdStudents_Data.Parameters.Add("@MaritalStatus", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MaritalStatusFN));
cmdStudents_Data.Parameters.Add("@NationalityofMother", SqlDbType.Int, 4, LibraryMOD.GetFieldName(NationalityofMotherFN));
cmdStudents_Data.Parameters.Add("@EmploymentSector", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmploymentSectorFN));


Parmeter.SourceVersion = DataRowVersion.Current;
daStudents_Data.InsertCommand =cmdStudents_Data;
daStudents_Data.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdStudents_Data = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdStudents_Data.Parameters.Add("@lngSerial", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngSerialFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daStudents_Data.DeleteCommand =cmdStudents_Data;
daStudents_Data.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daStudents_Data.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daStudents_Data;
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
dr = dsStudents_Data.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
dr[LibraryMOD.GetFieldName(strFirstDescEnFN)]=strFirstDescEn;
dr[LibraryMOD.GetFieldName(strSecondDescEnFN)]=strSecondDescEn;
dr[LibraryMOD.GetFieldName(strThirdDescEnFN)]=strThirdDescEn;
dr[LibraryMOD.GetFieldName(strLastDescEnFN)]=strLastDescEn;
dr[LibraryMOD.GetFieldName(strFirstDescArFN)]=strFirstDescAr;
dr[LibraryMOD.GetFieldName(strSecondDescArFN)]=strSecondDescAr;
dr[LibraryMOD.GetFieldName(strThirdDescArFN)]=strThirdDescAr;
dr[LibraryMOD.GetFieldName(strLastDescArFN)]=strLastDescAr;
dr[LibraryMOD.GetFieldName(bSexFN)]=bSex;
dr[LibraryMOD.GetFieldName(dateBirthFN)]=dateBirth;
dr[LibraryMOD.GetFieldName(byteBirthCountryFN)]=byteBirthCountry;
dr[LibraryMOD.GetFieldName(byteBirthCityFN)]=byteBirthCity;
dr[LibraryMOD.GetFieldName(byteNationalityFN)]=byteNationality;
dr[LibraryMOD.GetFieldName(byteReligionFN)]=byteReligion;
dr[LibraryMOD.GetFieldName(byteIDTypeFN)]=byteIDType;
dr[LibraryMOD.GetFieldName(strIDFN)]=strID;
dr[LibraryMOD.GetFieldName(byteIDCountryFN)]=byteIDCountry;
dr[LibraryMOD.GetFieldName(dateEndIDFN)]=dateEndID;
dr[LibraryMOD.GetFieldName(byteMilitaryStatusFN)]=byteMilitaryStatus;
dr[LibraryMOD.GetFieldName(strMilitaryIDFN)]=strMilitaryID;
dr[LibraryMOD.GetFieldName(dateMilitaryPostponeFN)]=dateMilitaryPostpone;
dr[LibraryMOD.GetFieldName(strReleaseReasonFN)]=strReleaseReason;
dr[LibraryMOD.GetFieldName(strPostponeReasonFN)]=strPostponeReason;
dr[LibraryMOD.GetFieldName(dateMilitaryStartFN)]=dateMilitaryStart;
dr[LibraryMOD.GetFieldName(dateMilitaryEndFN)]=dateMilitaryEnd;
dr[LibraryMOD.GetFieldName(byteHomeCountryFN)]=byteHomeCountry;
dr[LibraryMOD.GetFieldName(byteHomeCityFN)]=byteHomeCity;
dr[LibraryMOD.GetFieldName(byteOriginCountryFN)]=byteOriginCountry;
dr[LibraryMOD.GetFieldName(byteOriginCityFN)]=byteOriginCity;
dr[LibraryMOD.GetFieldName(strPOBoxFN)]=strPOBox;
dr[LibraryMOD.GetFieldName(strPhone1FN)]=strPhone1;
dr[LibraryMOD.GetFieldName(strPhone2FN)]=strPhone2;
dr[LibraryMOD.GetFieldName(strFaxFN)]=strFax;
dr[LibraryMOD.GetFieldName(strTelexFN)]=strTelex;
dr[LibraryMOD.GetFieldName(strEmailFN)]=strEmail;
dr[LibraryMOD.GetFieldName(strZipCodeFN)]=strZipCode;
dr[LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
dr[LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
dr[LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
dr[LibraryMOD.GetFieldName(strSpecializationFN)]=strSpecialization;
dr[LibraryMOD.GetFieldName(strNationalNumberFN)]=strNationalNumber;
dr[LibraryMOD.GetFieldName(strAddressFN)]=strAddress;
dr[LibraryMOD.GetFieldName(strMilitarySourceFN)]=strMilitarySource;
dr[LibraryMOD.GetFieldName(strAgreementFN)]=strAgreement;
dr[LibraryMOD.GetFieldName(dateAgreementFN)]=dateAgreement;
dr[LibraryMOD.GetFieldName(bCourseFN)]=bCourse;
dr[LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
dr[LibraryMOD.GetFieldName(strNationalIDFN)]=strNationalID;
dr[LibraryMOD.GetFieldName(intWorkPlaceFN)]=intWorkPlace;
dr[LibraryMOD.GetFieldName(strWorkPhoneFN)]=strWorkPhone;
dr[LibraryMOD.GetFieldName(strJopTitleFN)]=strJopTitle;
dr[LibraryMOD.GetFieldName(intDelegationFN)]=intDelegation;
dr[LibraryMOD.GetFieldName(intSponsorFN)]=intSponsor;
dr[LibraryMOD.GetFieldName(dateEndSponsorshipFN)]=dateEndSponsorship;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
dr[LibraryMOD.GetFieldName(strStudentPicFN)]=strStudentPic;

dr[LibraryMOD.GetFieldName(isWorkingFN)] = isWorking;
dr[LibraryMOD.GetFieldName(EthbaraNoFN)] = EthbaraNo;
dr[LibraryMOD.GetFieldName(FitnessStatusFN)] = FitnessStatus;
dr[LibraryMOD.GetFieldName(MaritalStatusFN)] = MaritalStatus;
dr[LibraryMOD.GetFieldName(NationalityofMotherFN)] = NationalityofMother;
dr[LibraryMOD.GetFieldName(EmploymentSectorFN)] = EmploymentSector;

//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsStudents_Data.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsStudents_Data.Tables[TableName].Select(LibraryMOD.GetFieldName(lngSerialFN)  + "=" + lngSerial);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(lngSerialFN)]=lngSerial;
drAry[0][LibraryMOD.GetFieldName(strFirstDescEnFN)]=strFirstDescEn;
drAry[0][LibraryMOD.GetFieldName(strSecondDescEnFN)]=strSecondDescEn;
drAry[0][LibraryMOD.GetFieldName(strThirdDescEnFN)]=strThirdDescEn;
drAry[0][LibraryMOD.GetFieldName(strLastDescEnFN)]=strLastDescEn;
drAry[0][LibraryMOD.GetFieldName(strFirstDescArFN)]=strFirstDescAr;
drAry[0][LibraryMOD.GetFieldName(strSecondDescArFN)]=strSecondDescAr;
drAry[0][LibraryMOD.GetFieldName(strThirdDescArFN)]=strThirdDescAr;
drAry[0][LibraryMOD.GetFieldName(strLastDescArFN)]=strLastDescAr;
drAry[0][LibraryMOD.GetFieldName(bSexFN)]=bSex;
drAry[0][LibraryMOD.GetFieldName(dateBirthFN)]=dateBirth;
drAry[0][LibraryMOD.GetFieldName(byteBirthCountryFN)]=byteBirthCountry;
drAry[0][LibraryMOD.GetFieldName(byteBirthCityFN)]=byteBirthCity;
drAry[0][LibraryMOD.GetFieldName(byteNationalityFN)]=byteNationality;
drAry[0][LibraryMOD.GetFieldName(byteReligionFN)]=byteReligion;
drAry[0][LibraryMOD.GetFieldName(byteIDTypeFN)]=byteIDType;
drAry[0][LibraryMOD.GetFieldName(strIDFN)]=strID;
drAry[0][LibraryMOD.GetFieldName(byteIDCountryFN)]=byteIDCountry;
drAry[0][LibraryMOD.GetFieldName(dateEndIDFN)]=dateEndID;
drAry[0][LibraryMOD.GetFieldName(byteMilitaryStatusFN)]=byteMilitaryStatus;
drAry[0][LibraryMOD.GetFieldName(strMilitaryIDFN)]=strMilitaryID;
drAry[0][LibraryMOD.GetFieldName(dateMilitaryPostponeFN)]=dateMilitaryPostpone;
drAry[0][LibraryMOD.GetFieldName(strReleaseReasonFN)]=strReleaseReason;
drAry[0][LibraryMOD.GetFieldName(strPostponeReasonFN)]=strPostponeReason;
drAry[0][LibraryMOD.GetFieldName(dateMilitaryStartFN)]=dateMilitaryStart;
drAry[0][LibraryMOD.GetFieldName(dateMilitaryEndFN)]=dateMilitaryEnd;
drAry[0][LibraryMOD.GetFieldName(byteHomeCountryFN)]=byteHomeCountry;
drAry[0][LibraryMOD.GetFieldName(byteHomeCityFN)]=byteHomeCity;
drAry[0][LibraryMOD.GetFieldName(byteOriginCountryFN)]=byteOriginCountry;
drAry[0][LibraryMOD.GetFieldName(byteOriginCityFN)]=byteOriginCity;
drAry[0][LibraryMOD.GetFieldName(strPOBoxFN)]=strPOBox;
drAry[0][LibraryMOD.GetFieldName(strPhone1FN)]=strPhone1;
drAry[0][LibraryMOD.GetFieldName(strPhone2FN)]=strPhone2;
drAry[0][LibraryMOD.GetFieldName(strFaxFN)]=strFax;
drAry[0][LibraryMOD.GetFieldName(strTelexFN)]=strTelex;
drAry[0][LibraryMOD.GetFieldName(strEmailFN)]=strEmail;
drAry[0][LibraryMOD.GetFieldName(strZipCodeFN)]=strZipCode;
drAry[0][LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
drAry[0][LibraryMOD.GetFieldName(strCollegeFN)]=strCollege;
drAry[0][LibraryMOD.GetFieldName(strDegreeFN)]=strDegree;
drAry[0][LibraryMOD.GetFieldName(strSpecializationFN)]=strSpecialization;
drAry[0][LibraryMOD.GetFieldName(strNationalNumberFN)]=strNationalNumber;
drAry[0][LibraryMOD.GetFieldName(strAddressFN)]=strAddress;
drAry[0][LibraryMOD.GetFieldName(strMilitarySourceFN)]=strMilitarySource;
drAry[0][LibraryMOD.GetFieldName(strAgreementFN)]=strAgreement;
drAry[0][LibraryMOD.GetFieldName(dateAgreementFN)]=dateAgreement;
drAry[0][LibraryMOD.GetFieldName(bCourseFN)]=bCourse;
drAry[0][LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
drAry[0][LibraryMOD.GetFieldName(strNationalIDFN)]=strNationalID;
drAry[0][LibraryMOD.GetFieldName(intWorkPlaceFN)]=intWorkPlace;
drAry[0][LibraryMOD.GetFieldName(strWorkPhoneFN)]=strWorkPhone;
drAry[0][LibraryMOD.GetFieldName(strJopTitleFN)]=strJopTitle;
drAry[0][LibraryMOD.GetFieldName(intDelegationFN)]=intDelegation;
drAry[0][LibraryMOD.GetFieldName(intSponsorFN)]=intSponsor;
drAry[0][LibraryMOD.GetFieldName(dateEndSponsorshipFN)]=dateEndSponsorship;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
drAry[0][LibraryMOD.GetFieldName(strStudentPicFN)]=strStudentPic;

drAry[0][LibraryMOD.GetFieldName(isWorkingFN)] = isWorking;
drAry[0][LibraryMOD.GetFieldName(EthbaraNoFN)] = EthbaraNo;
drAry[0][LibraryMOD.GetFieldName(FitnessStatusFN)] = FitnessStatus;
drAry[0][LibraryMOD.GetFieldName(MaritalStatusFN)] = MaritalStatus;
drAry[0][LibraryMOD.GetFieldName(NationalityofMotherFN)] = NationalityofMother;
drAry[0][LibraryMOD.GetFieldName(EmploymentSectorFN)] = EmploymentSector;

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
public int CommitStudents_Data()  
{
//CommitStudents_Data= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daStudents_Data.Update(dsStudents_Data, TableName);
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
FindInMultiPKey(lngSerial);
if (( Students_DataDataRow != null)) 
{
Students_DataDataRow.Delete();
CommitStudents_Data();
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
if (Students_DataDataRow[LibraryMOD.GetFieldName(lngSerialFN)]== System.DBNull.Value)
{
  lngSerial=0;
}
else
{
  lngSerial = (int)Students_DataDataRow[LibraryMOD.GetFieldName(lngSerialFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strFirstDescEnFN)]== System.DBNull.Value)
{
  strFirstDescEn="";
}
else
{
  strFirstDescEn = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strFirstDescEnFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strSecondDescEnFN)]== System.DBNull.Value)
{
  strSecondDescEn="";
}
else
{
  strSecondDescEn = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strSecondDescEnFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strThirdDescEnFN)]== System.DBNull.Value)
{
  strThirdDescEn="";
}
else
{
  strThirdDescEn = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strThirdDescEnFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strLastDescEnFN)]== System.DBNull.Value)
{
  strLastDescEn="";
}
else
{
  strLastDescEn = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strLastDescEnFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strFirstDescArFN)]== System.DBNull.Value)
{
  strFirstDescAr="";
}
else
{
  strFirstDescAr = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strFirstDescArFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strSecondDescArFN)]== System.DBNull.Value)
{
  strSecondDescAr="";
}
else
{
  strSecondDescAr = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strSecondDescArFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strThirdDescArFN)]== System.DBNull.Value)
{
  strThirdDescAr="";
}
else
{
  strThirdDescAr = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strThirdDescArFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strLastDescArFN)]== System.DBNull.Value)
{
  strLastDescAr="";
}
else
{
  strLastDescAr = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strLastDescArFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(bSexFN)]== System.DBNull.Value)
{
  bSex=false;
}
else
{
  bSex = (bool)Students_DataDataRow[LibraryMOD.GetFieldName(bSexFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateBirthFN)]== System.DBNull.Value)
{
}
else
{
  dateBirth = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateBirthFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteBirthCountryFN)]== System.DBNull.Value)
{
  byteBirthCountry=0;
}
else
{
  byteBirthCountry = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteBirthCountryFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteBirthCityFN)]== System.DBNull.Value)
{
  byteBirthCity=0;
}
else
{
  byteBirthCity = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteBirthCityFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteNationalityFN)]== System.DBNull.Value)
{
  byteNationality=0;
}
else
{
  byteNationality = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteNationalityFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteReligionFN)]== System.DBNull.Value)
{
  byteReligion=0;
}
else
{
  byteReligion = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteReligionFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteIDTypeFN)]== System.DBNull.Value)
{
  byteIDType=0;
}
else
{
  byteIDType = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteIDTypeFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strIDFN)]== System.DBNull.Value)
{
  strID="";
}
else
{
  strID = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strIDFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteIDCountryFN)]== System.DBNull.Value)
{
  byteIDCountry=0;
}
else
{
  byteIDCountry = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteIDCountryFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateEndIDFN)]== System.DBNull.Value)
{
}
else
{
  dateEndID = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateEndIDFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteMilitaryStatusFN)]== System.DBNull.Value)
{
  byteMilitaryStatus=0;
}
else
{
  byteMilitaryStatus = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteMilitaryStatusFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strMilitaryIDFN)]== System.DBNull.Value)
{
  strMilitaryID="";
}
else
{
  strMilitaryID = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strMilitaryIDFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateMilitaryPostponeFN)]== System.DBNull.Value)
{
}
else
{
  dateMilitaryPostpone = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateMilitaryPostponeFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strReleaseReasonFN)]== System.DBNull.Value)
{
  strReleaseReason="";
}
else
{
  strReleaseReason = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strReleaseReasonFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strPostponeReasonFN)]== System.DBNull.Value)
{
  strPostponeReason="";
}
else
{
  strPostponeReason = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strPostponeReasonFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateMilitaryStartFN)]== System.DBNull.Value)
{
}
else
{
  dateMilitaryStart = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateMilitaryStartFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateMilitaryEndFN)]== System.DBNull.Value)
{
}
else
{
  dateMilitaryEnd = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateMilitaryEndFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteHomeCountryFN)]== System.DBNull.Value)
{
  byteHomeCountry=0;
}
else
{
  byteHomeCountry = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteHomeCountryFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteHomeCityFN)]== System.DBNull.Value)
{
  byteHomeCity=0;
}
else
{
  byteHomeCity = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteHomeCityFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteOriginCountryFN)]== System.DBNull.Value)
{
  byteOriginCountry=0;
}
else
{
  byteOriginCountry = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteOriginCountryFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteOriginCityFN)]== System.DBNull.Value)
{
  byteOriginCity=0;
}
else
{
  byteOriginCity = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteOriginCityFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strPOBoxFN)]== System.DBNull.Value)
{
  strPOBox="";
}
else
{
  strPOBox = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strPOBoxFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strPhone1FN)]== System.DBNull.Value)
{
  strPhone1="";
}
else
{
  strPhone1 = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strPhone1FN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strPhone2FN)]== System.DBNull.Value)
{
  strPhone2="";
}
else
{
  strPhone2 = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strPhone2FN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strFaxFN)]== System.DBNull.Value)
{
  strFax="";
}
else
{
  strFax = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strFaxFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strTelexFN)]== System.DBNull.Value)
{
  strTelex="";
}
else
{
  strTelex = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strTelexFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strEmailFN)]== System.DBNull.Value)
{
  strEmail="";
}
else
{
  strEmail = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strEmailFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(sECTemailFN)] == System.DBNull.Value)
{
    sECTemail = "";
}
else
{
    sECTemail = (string)Students_DataDataRow[LibraryMOD.GetFieldName(sECTemailFN)];
}   
if (Students_DataDataRow[LibraryMOD.GetFieldName(strZipCodeFN)]== System.DBNull.Value)
{
  strZipCode="";
}
else
{
  strZipCode = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strZipCodeFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)]== System.DBNull.Value)
{
  lngStudentNumber="";
}
else
{
  lngStudentNumber = (string)Students_DataDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strCollegeFN)]== System.DBNull.Value)
{
  strCollege="";
}
else
{
  strCollege = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strDegreeFN)]== System.DBNull.Value)
{
  strDegree="";
}
else
{
  strDegree = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strDegreeFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strSpecializationFN)]== System.DBNull.Value)
{
  strSpecialization="";
}
else
{
  strSpecialization = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strSpecializationFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strNationalNumberFN)]== System.DBNull.Value)
{
  strNationalNumber="";
}
else
{
  strNationalNumber = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strNationalNumberFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strAddressFN)]== System.DBNull.Value)
{
  strAddress="";
}
else
{
  strAddress = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strAddressFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strMilitarySourceFN)]== System.DBNull.Value)
{
  strMilitarySource="";
}
else
{
  strMilitarySource = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strMilitarySourceFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strAgreementFN)]== System.DBNull.Value)
{
  strAgreement="";
}
else
{
  strAgreement = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strAgreementFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateAgreementFN)]== System.DBNull.Value)
{
}
else
{
  dateAgreement = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateAgreementFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(bCourseFN)]== System.DBNull.Value)
{
  bCourse="";
}
else
{
  bCourse = (string)Students_DataDataRow[LibraryMOD.GetFieldName(bCourseFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(byteShiftFN)]== System.DBNull.Value)
{
  byteShift=0;
}
else
{
  byteShift = (int)Students_DataDataRow[LibraryMOD.GetFieldName(byteShiftFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strNationalIDFN)]== System.DBNull.Value)
{
  strNationalID="";
}
else
{
  strNationalID = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strNationalIDFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(intWorkPlaceFN)]== System.DBNull.Value)
{
  intWorkPlace=0;
}
else
{
  intWorkPlace = (int)Students_DataDataRow[LibraryMOD.GetFieldName(intWorkPlaceFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strWorkPhoneFN)]== System.DBNull.Value)
{
  strWorkPhone="";
}
else
{
  strWorkPhone = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strWorkPhoneFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strJopTitleFN)]== System.DBNull.Value)
{
  strJopTitle="";
}
else
{
  strJopTitle = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strJopTitleFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(intDelegationFN)]== System.DBNull.Value)
{
  intDelegation=0;
}
else
{
  intDelegation = (int)Students_DataDataRow[LibraryMOD.GetFieldName(intDelegationFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(intSponsorFN)]== System.DBNull.Value)
{
  intSponsor=0;
}
else
{
  intSponsor = (int)Students_DataDataRow[LibraryMOD.GetFieldName(intSponsorFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateEndSponsorshipFN)]== System.DBNull.Value)
{
}
else
{
  dateEndSponsorship = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateEndSponsorshipFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Students_DataDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strNUserFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(strStudentPicFN)]== System.DBNull.Value)
{
  strStudentPic="";
}
else
{
  strStudentPic = (string)Students_DataDataRow[LibraryMOD.GetFieldName(strStudentPicFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(isWorkingFN)] == System.DBNull.Value)
{
    isWorking = false;
}
else
{
    isWorking = (bool)Students_DataDataRow[LibraryMOD.GetFieldName(isWorkingFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(FitnessStatusFN)] == System.DBNull.Value)
{
    FitnessStatus = false;
}
else
{
    FitnessStatus = (bool)Students_DataDataRow[LibraryMOD.GetFieldName(FitnessStatusFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(EthbaraNoFN)] == System.DBNull.Value)
{
    EthbaraNo = "";
}
else
{
    EthbaraNo = (string)Students_DataDataRow[LibraryMOD.GetFieldName(EthbaraNoFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(MaritalStatusFN)] == System.DBNull.Value)
{
    MaritalStatus = 0;
}
else
{
    MaritalStatus = (int)Students_DataDataRow[LibraryMOD.GetFieldName(MaritalStatusFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(NationalityofMotherFN)] == System.DBNull.Value)
{
    NationalityofMother = 0;
}
else
{
    NationalityofMother = (int)Students_DataDataRow[LibraryMOD.GetFieldName(NationalityofMotherFN)];
}
if (Students_DataDataRow[LibraryMOD.GetFieldName(EmploymentSectorFN)] == System.DBNull.Value)
{
    EmploymentSector = 0;
}
else
{
    EmploymentSector = (int)Students_DataDataRow[LibraryMOD.GetFieldName(EmploymentSectorFN)];
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
public int FindInMultiPKey(int PKlngSerial) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKlngSerial;
Students_DataDataRow = dsStudents_Data.Tables[TableName].Rows.Find(findTheseVals);
if  ((Students_DataDataRow !=null)) 
{
lngCurRow = dsStudents_Data.Tables[TableName].Rows.IndexOf(Students_DataDataRow);
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
  lngCurRow = dsStudents_Data.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsStudents_Data.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsStudents_Data.Tables[TableName].Rows.Count > 0) 
{
  Students_DataDataRow = dsStudents_Data.Tables[TableName].Rows[lngCurRow];
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
daStudents_Data.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudents_Data.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daStudents_Data.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daStudents_Data.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
