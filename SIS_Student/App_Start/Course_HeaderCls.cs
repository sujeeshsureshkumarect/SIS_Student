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
public class Course_Header
{
//Creation Date: 11/05/2010 11:18:19 AM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private int m_byteForm; 
private int m_intFormNumber; 
private string m_lngStudentNumber; 
private DateTime m_dateForm; 
private int m_lngTransaction; 
private int m_intFY; 
private int m_byteJournal; 
private string m_strVoucherNumber; 
private double m_curFees; 
private string m_isChecked; 
private DateTime m_dateChecked; 
private string m_sCheckedBy; 
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
public int byteSemester
{
get { return  m_byteSemester; }
set {m_byteSemester  = value ; }
}
public int byteForm
{
get { return  m_byteForm; }
set {m_byteForm  = value ; }
}
public int intFormNumber
{
get { return  m_intFormNumber; }
set {m_intFormNumber  = value ; }
}
public string lngStudentNumber
{
get { return  m_lngStudentNumber; }
set {m_lngStudentNumber  = value ; }
}
public DateTime dateForm
{
get { return  m_dateForm; }
set {m_dateForm  = value ; }
}
public int lngTransaction
{
get { return  m_lngTransaction; }
set {m_lngTransaction  = value ; }
}
public int intFY
{
get { return  m_intFY; }
set {m_intFY  = value ; }
}
public int byteJournal
{
get { return  m_byteJournal; }
set {m_byteJournal  = value ; }
}
public string strVoucherNumber
{
get { return  m_strVoucherNumber; }
set {m_strVoucherNumber  = value ; }
}
public double curFees
{
get { return  m_curFees; }
set {m_curFees  = value ; }
}
public string isChecked
{
get { return  m_isChecked; }
set {m_isChecked  = value ; }
}
public DateTime dateChecked
{
get { return  m_dateChecked; }
set {m_dateChecked  = value ; }
}
public string sCheckedBy
{
get { return  m_sCheckedBy; }
set {m_sCheckedBy  = value ; }
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
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public Course_Header()
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
public class Course_HeaderDAL : Course_Header
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_byteFormFN ;
private string m_intFormNumberFN ;
private string m_lngStudentNumberFN ;
private string m_dateFormFN ;
private string m_lngTransactionFN ;
private string m_intFYFN ;
private string m_byteJournalFN ;
private string m_strVoucherNumberFN ;
private string m_curFeesFN ;
private string m_isCheckedFN ;
private string m_dateCheckedFN ;
private string m_sCheckedByFN ;
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
public string byteSemesterFN 
{
get { return  m_byteSemesterFN; }
set {m_byteSemesterFN  = value ; }
}
public string byteFormFN 
{
get { return  m_byteFormFN; }
set {m_byteFormFN  = value ; }
}
public string intFormNumberFN 
{
get { return  m_intFormNumberFN; }
set {m_intFormNumberFN  = value ; }
}
public string lngStudentNumberFN 
{
get { return  m_lngStudentNumberFN; }
set {m_lngStudentNumberFN  = value ; }
}
public string dateFormFN 
{
get { return  m_dateFormFN; }
set {m_dateFormFN  = value ; }
}
public string lngTransactionFN 
{
get { return  m_lngTransactionFN; }
set {m_lngTransactionFN  = value ; }
}
public string intFYFN 
{
get { return  m_intFYFN; }
set {m_intFYFN  = value ; }
}
public string byteJournalFN 
{
get { return  m_byteJournalFN; }
set {m_byteJournalFN  = value ; }
}
public string strVoucherNumberFN 
{
get { return  m_strVoucherNumberFN; }
set {m_strVoucherNumberFN  = value ; }
}
public string curFeesFN 
{
get { return  m_curFeesFN; }
set {m_curFeesFN  = value ; }
}
public string isCheckedFN 
{
get { return  m_isCheckedFN; }
set {m_isCheckedFN  = value ; }
}
public string dateCheckedFN 
{
get { return  m_dateCheckedFN; }
set {m_dateCheckedFN  = value ; }
}
public string sCheckedByFN 
{
get { return  m_sCheckedByFN; }
set {m_sCheckedByFN  = value ; }
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
public Course_HeaderDAL()
{
try
{
this.TableName = "Reg_Course_Header";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.byteFormFN = m_TableName + ".byteForm";
this.intFormNumberFN = m_TableName + ".intFormNumber";
this.lngStudentNumberFN = m_TableName + ".lngStudentNumber";
this.dateFormFN = m_TableName + ".dateForm";
this.lngTransactionFN = m_TableName + ".lngTransaction";
this.intFYFN = m_TableName + ".intFY";
this.byteJournalFN = m_TableName + ".byteJournal";
this.strVoucherNumberFN = m_TableName + ".strVoucherNumber";
this.curFeesFN = m_TableName + ".curFees";
this.isCheckedFN = m_TableName + ".isChecked";
this.dateCheckedFN = m_TableName + ".dateChecked";
this.sCheckedByFN = m_TableName + ".sCheckedBy";
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
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteFormFN;
sSQL += " , " + intFormNumberFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + dateFormFN;
sSQL += " , " + lngTransactionFN;
sSQL += " , " + intFYFN;
sSQL += " , " + byteJournalFN;
sSQL += " , " + strVoucherNumberFN;
sSQL += " , " + curFeesFN;
sSQL += " , " + isCheckedFN;
sSQL += " , " + dateCheckedFN;
sSQL += " , " + sCheckedByFN;
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
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=intStudyYearFN;
sSQL += " , " + byteSemesterFN;
sSQL += " , " + byteFormFN;
sSQL += " , " + intFormNumberFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + dateFormFN;
sSQL += " , " + lngTransactionFN;
sSQL += " , " + intFYFN;
sSQL += " , " + byteJournalFN;
sSQL += " , " + strVoucherNumberFN;
sSQL += " , " + curFeesFN;
sSQL += " , " + isCheckedFN;
sSQL += " , " + dateCheckedFN;
sSQL += " , " + sCheckedByFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN) + "=@byteSemester";
sSQL += " , " + LibraryMOD.GetFieldName(byteFormFN) + "=@byteForm";
sSQL += " , " + LibraryMOD.GetFieldName(intFormNumberFN) + "=@intFormNumber";
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
sSQL += " , " + LibraryMOD.GetFieldName(dateFormFN) + "=@dateForm";
sSQL += " , " + LibraryMOD.GetFieldName(lngTransactionFN) + "=@lngTransaction";
sSQL += " , " + LibraryMOD.GetFieldName(intFYFN) + "=@intFY";
sSQL += " , " + LibraryMOD.GetFieldName(byteJournalFN) + "=@byteJournal";
sSQL += " , " + LibraryMOD.GetFieldName(strVoucherNumberFN) + "=@strVoucherNumber";
sSQL += " , " + LibraryMOD.GetFieldName(curFeesFN) + "=@curFees";
sSQL += " , " + LibraryMOD.GetFieldName(isCheckedFN) + "=@isChecked";
sSQL += " , " + LibraryMOD.GetFieldName(dateCheckedFN) + "=@dateChecked";
sSQL += " , " + LibraryMOD.GetFieldName(sCheckedByFN) + "=@sCheckedBy";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(intStudyYearFN)+"=@intStudyYear";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteSemesterFN)+"=@byteSemester";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteFormFN)+"=@byteForm";
sSQL +=  " And " + LibraryMOD.GetFieldName(intFormNumberFN)+"=@intFormNumber";
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
sSQL += " , " + LibraryMOD.GetFieldName(byteSemesterFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteFormFN);
sSQL += " , " + LibraryMOD.GetFieldName(intFormNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateFormFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngTransactionFN);
sSQL += " , " + LibraryMOD.GetFieldName(intFYFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteJournalFN);
sSQL += " , " + LibraryMOD.GetFieldName(strVoucherNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(curFeesFN);
sSQL += " , " + LibraryMOD.GetFieldName(isCheckedFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateCheckedFN);
sSQL += " , " + LibraryMOD.GetFieldName(sCheckedByFN);
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
sSQL += " ,@byteSemester";
sSQL += " ,@byteForm";
sSQL += " ,@intFormNumber";
sSQL += " ,@lngStudentNumber";
sSQL += " ,@dateForm";
sSQL += " ,@lngTransaction";
sSQL += " ,@intFY";
sSQL += " ,@byteJournal";
sSQL += " ,@strVoucherNumber";
sSQL += " ,@curFees";
sSQL += " ,@isChecked";
sSQL += " ,@dateChecked";
sSQL += " ,@sCheckedBy";
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
sSQL += LibraryMOD.GetFieldName(intStudyYearFN)+"=@intStudyYear";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteSemesterFN)+"=@byteSemester";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteFormFN)+"=@byteForm";
sSQL +=  " And " +  LibraryMOD.GetFieldName(intFormNumberFN)+"=@intFormNumber";
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
public List< Course_Header> GetCourse_Header(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Course_Header
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
List<Course_Header> results = new List<Course_Header>();
try
{
//Default Value
Course_Header myCourse_Header = new Course_Header();
if (isDeafaultIncluded)
{
//Change the code here
myCourse_Header.intStudyYear = 0;
myCourse_Header.byteSemester = 0;
myCourse_Header.byteForm = 0;
myCourse_Header.intFormNumber = 0;
myCourse_Header.lngStudentNumber = "Select Course_Header ...";
results.Add(myCourse_Header);
}
while (reader.Read())
{
myCourse_Header = new Course_Header();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myCourse_Header.intStudyYear = 0;
}
else
{
myCourse_Header.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myCourse_Header.byteSemester = 0;
}
else
{
myCourse_Header.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteFormFN)].Equals(DBNull.Value))
{
myCourse_Header.byteForm = 0;
}
else
{
myCourse_Header.byteForm = int.Parse(reader[LibraryMOD.GetFieldName( byteFormFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intFormNumberFN)].Equals(DBNull.Value))
{
myCourse_Header.intFormNumber = 0;
}
else
{
myCourse_Header.intFormNumber = int.Parse(reader[LibraryMOD.GetFieldName( intFormNumberFN) ].ToString());
}
myCourse_Header.lngStudentNumber =reader[LibraryMOD.GetFieldName( lngStudentNumberFN) ].ToString();
if (!reader[dateFormFN].Equals(DBNull.Value))
{
myCourse_Header.dateForm = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateFormFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(lngTransactionFN)].Equals(DBNull.Value))
{
myCourse_Header.lngTransaction = 0;
}
else
{
myCourse_Header.lngTransaction = int.Parse(reader[LibraryMOD.GetFieldName( lngTransactionFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intFYFN)].Equals(DBNull.Value))
{
myCourse_Header.intFY = 0;
}
else
{
myCourse_Header.intFY = int.Parse(reader[LibraryMOD.GetFieldName( intFYFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteJournalFN)].Equals(DBNull.Value))
{
myCourse_Header.byteJournal = 0;
}
else
{
myCourse_Header.byteJournal = int.Parse(reader[LibraryMOD.GetFieldName( byteJournalFN) ].ToString());
}
myCourse_Header.strVoucherNumber =reader[LibraryMOD.GetFieldName( strVoucherNumberFN) ].ToString();
myCourse_Header.isChecked =reader[LibraryMOD.GetFieldName( isCheckedFN) ].ToString();
if (!reader[dateCheckedFN].Equals(DBNull.Value))
{
myCourse_Header.dateChecked = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCheckedFN) ].ToString());
}
myCourse_Header.sCheckedBy =reader[LibraryMOD.GetFieldName( sCheckedByFN) ].ToString();
myCourse_Header.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[dateCreateFN].Equals(DBNull.Value))
{
myCourse_Header.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myCourse_Header.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[dateLastSaveFN].Equals(DBNull.Value))
{
myCourse_Header.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myCourse_Header.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myCourse_Header.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myCourse_Header);
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
public int IsHeaderExists(InitializeModule.EnumCampus Campus, int intStudyYear, int byteSemester, int byteForm, string lngStudentNumber)//int intFormNumber)
{
    int iFormNumber = -1;
    
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {
        Conn.Open();
        Course_Header theCourse_Header = new Course_Header();
        string sql = "SELECT intFormNumber";
        sql += " FROM Reg_Course_Header";
        sql += " WHERE intStudyYear=" + intStudyYear + " AND ";
        sql += " byteSemester=" + byteSemester + " AND byteForm=" + byteForm;
        sql += " AND lngStudentNumber='" + lngStudentNumber + "'";
        SqlCommand Cmd = new SqlCommand(sql, Conn);

        SqlDataReader dr = Cmd.ExecuteReader();

        if (dr.HasRows)
        {
            dr.Read();
            iFormNumber = int.Parse(dr["intFormNumber"].ToString());
        }

        Conn.Close();
        dr.Close();

    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }

    return iFormNumber;
}
public int UpdateCourse_Header(InitializeModule.EnumCampus Campus, int iMode,int intStudyYear,int byteSemester,int byteForm,int intFormNumber,string lngStudentNumber,DateTime dateForm,int lngTransaction,int intFY,int byteJournal,string strVoucherNumber,double curFees,string isChecked,DateTime dateChecked,string sCheckedBy,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Course_Header theCourse_Header = new Course_Header();
//'Updates the  table
switch(iMode) 
  {
  case  (int) InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int) InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@byteForm",byteForm));
Cmd.Parameters.Add(new SqlParameter("@intFormNumber",intFormNumber));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));
Cmd.Parameters.Add(new SqlParameter("@dateForm",dateForm));
Cmd.Parameters.Add(new SqlParameter("@lngTransaction",lngTransaction));
Cmd.Parameters.Add(new SqlParameter("@intFY",intFY));
Cmd.Parameters.Add(new SqlParameter("@byteJournal",byteJournal));
Cmd.Parameters.Add(new SqlParameter("@strVoucherNumber",strVoucherNumber));
Cmd.Parameters.Add(new SqlParameter("@curFees",curFees));
Cmd.Parameters.Add(new SqlParameter("@isChecked",isChecked));
Cmd.Parameters.Add(new SqlParameter("@dateChecked",dateChecked));
Cmd.Parameters.Add(new SqlParameter("@sCheckedBy",sCheckedBy));
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
public int DeleteCourse_Header( InitializeModule.EnumCampus Campus,string intStudyYear,string byteSemester,string byteForm,string intFormNumber)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@intStudyYear", intStudyYear ));
Cmd.Parameters.Add(new SqlParameter("@byteSemester", byteSemester ));
Cmd.Parameters.Add(new SqlParameter("@byteForm", byteForm ));
Cmd.Parameters.Add(new SqlParameter("@intFormNumber", intFormNumber ));
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
DataTable dt = new DataTable("Course_Header");
DataView dv = new DataView();
List<Course_Header> myCourse_Headers = new List<Course_Header>();
try
{
myCourse_Headers = GetCourse_Header( InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3 = new DataColumn("byteForm", Type.GetType("smallint"));
dt.Columns.Add(col3);
DataColumn col4 = new DataColumn("intFormNumber", Type.GetType("smallint"));
dt.Columns.Add(col4);
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));
dt.Constraints.Add(new UniqueConstraint(col4));

DataRow dr;
for (int i = 0; i < myCourse_Headers.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCourse_Headers[i].intStudyYear;
  dr[2] = myCourse_Headers[i].byteSemester;
  dr[3] = myCourse_Headers[i].byteForm;
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
myCourse_Headers.Clear();
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
sSQL += intStudyYearFN;
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
public class Course_HeaderCls : Course_HeaderDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daCourse_Header;
private DataSet m_dsCourse_Header;
public DataRow Course_HeaderDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsCourse_Header
{
get { return m_dsCourse_Header ; }
set { m_dsCourse_Header = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Course_HeaderCls()
{
try
{
dsCourse_Header= new DataSet();

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
public virtual SqlDataAdapter GetCourse_HeaderDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daCourse_Header = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCourse_Header);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daCourse_Header.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCourse_Header;
}
public virtual SqlDataAdapter GetCourse_HeaderDataAdapter(SqlConnection con)  
{
try
{
daCourse_Header = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daCourse_Header.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdCourse_Header;
cmdCourse_Header = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, "intStudyYear" );
//'cmdRolePermission.Parameters.Add("@byteSemester", SqlDbType.Int, 4, "byteSemester" );
//'cmdRolePermission.Parameters.Add("@byteForm", SqlDbType.Int, 4, "byteForm" );
//'cmdRolePermission.Parameters.Add("@intFormNumber", SqlDbType.Int, 4, "intFormNumber" );
daCourse_Header.SelectCommand = cmdCourse_Header;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdCourse_Header = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdCourse_Header.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdCourse_Header.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdCourse_Header.Parameters.Add("@byteForm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormFN));
cmdCourse_Header.Parameters.Add("@intFormNumber", SqlDbType.Int,2, LibraryMOD.GetFieldName(intFormNumberFN));
cmdCourse_Header.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdCourse_Header.Parameters.Add("@dateForm", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateFormFN));
cmdCourse_Header.Parameters.Add("@lngTransaction", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngTransactionFN));
cmdCourse_Header.Parameters.Add("@intFY", SqlDbType.Int,2, LibraryMOD.GetFieldName(intFYFN));
cmdCourse_Header.Parameters.Add("@byteJournal", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteJournalFN));
cmdCourse_Header.Parameters.Add("@strVoucherNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strVoucherNumberFN));
cmdCourse_Header.Parameters.Add("@curFees", SqlDbType.Money,21, LibraryMOD.GetFieldName(curFeesFN));
cmdCourse_Header.Parameters.Add("@isChecked", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isCheckedFN));
cmdCourse_Header.Parameters.Add("@dateChecked", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCheckedFN));
cmdCourse_Header.Parameters.Add("@sCheckedBy", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sCheckedByFN));
cmdCourse_Header.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdCourse_Header.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdCourse_Header.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdCourse_Header.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdCourse_Header.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdCourse_Header.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdCourse_Header.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdCourse_Header.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdCourse_Header.Parameters.Add("@byteForm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFormFN));
Parmeter = cmdCourse_Header.Parameters.Add("@intFormNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intFormNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daCourse_Header.UpdateCommand = cmdCourse_Header;
daCourse_Header.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdCourse_Header = new SqlCommand(GetInsertCommand(), con);
cmdCourse_Header.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdCourse_Header.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdCourse_Header.Parameters.Add("@byteForm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormFN));
cmdCourse_Header.Parameters.Add("@intFormNumber", SqlDbType.Int,2, LibraryMOD.GetFieldName(intFormNumberFN));
cmdCourse_Header.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdCourse_Header.Parameters.Add("@dateForm", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateFormFN));
cmdCourse_Header.Parameters.Add("@lngTransaction", SqlDbType.Int,4, LibraryMOD.GetFieldName(lngTransactionFN));
cmdCourse_Header.Parameters.Add("@intFY", SqlDbType.Int,2, LibraryMOD.GetFieldName(intFYFN));
cmdCourse_Header.Parameters.Add("@byteJournal", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteJournalFN));
cmdCourse_Header.Parameters.Add("@strVoucherNumber", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strVoucherNumberFN));
cmdCourse_Header.Parameters.Add("@curFees", SqlDbType.Money,21, LibraryMOD.GetFieldName(curFeesFN));
cmdCourse_Header.Parameters.Add("@isChecked", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isCheckedFN));
cmdCourse_Header.Parameters.Add("@dateChecked", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCheckedFN));
cmdCourse_Header.Parameters.Add("@sCheckedBy", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sCheckedByFN));
cmdCourse_Header.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdCourse_Header.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdCourse_Header.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdCourse_Header.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdCourse_Header.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdCourse_Header.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daCourse_Header.InsertCommand =cmdCourse_Header;
daCourse_Header.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdCourse_Header = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdCourse_Header.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdCourse_Header.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdCourse_Header.Parameters.Add("@byteForm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFormFN));
Parmeter = cmdCourse_Header.Parameters.Add("@intFormNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intFormNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daCourse_Header.DeleteCommand =cmdCourse_Header;
daCourse_Header.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daCourse_Header.UpdateBatchSize =  InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCourse_Header;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData=  InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int) InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsCourse_Header.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(byteFormFN)]=byteForm;
dr[LibraryMOD.GetFieldName(intFormNumberFN)]=intFormNumber;
dr[LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
dr[LibraryMOD.GetFieldName(dateFormFN)]=dateForm;
dr[LibraryMOD.GetFieldName(lngTransactionFN)]=lngTransaction;
dr[LibraryMOD.GetFieldName(intFYFN)]=intFY;
dr[LibraryMOD.GetFieldName(byteJournalFN)]=byteJournal;
dr[LibraryMOD.GetFieldName(strVoucherNumberFN)]=strVoucherNumber;
dr[LibraryMOD.GetFieldName(curFeesFN)]=curFees;
dr[LibraryMOD.GetFieldName(isCheckedFN)]=isChecked;
dr[LibraryMOD.GetFieldName(dateCheckedFN)]=dateChecked;
dr[LibraryMOD.GetFieldName(sCheckedByFN)]=sCheckedBy;
dr[LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
dr[LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
dr[LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
dr[LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
dr[LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
dr[LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] =  InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] =  InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] =  InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]=  InitializeModule.gNetUserName;
dsCourse_Header.Tables[TableName].Rows.Add(dr);
break;
case (int) InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsCourse_Header.Tables[TableName].Select(LibraryMOD.GetFieldName(intStudyYearFN)  + "=" + intStudyYear  + " AND " + LibraryMOD.GetFieldName(byteSemesterFN) + "=" + byteSemester  + " AND " + LibraryMOD.GetFieldName(byteFormFN) + "=" + byteForm  + " AND " + LibraryMOD.GetFieldName(intFormNumberFN) + "=" + intFormNumber);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(byteFormFN)]=byteForm;
drAry[0][LibraryMOD.GetFieldName(intFormNumberFN)]=intFormNumber;
drAry[0][LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
drAry[0][LibraryMOD.GetFieldName(dateFormFN)]=dateForm;
drAry[0][LibraryMOD.GetFieldName(lngTransactionFN)]=lngTransaction;
drAry[0][LibraryMOD.GetFieldName(intFYFN)]=intFY;
drAry[0][LibraryMOD.GetFieldName(byteJournalFN)]=byteJournal;
drAry[0][LibraryMOD.GetFieldName(strVoucherNumberFN)]=strVoucherNumber;
drAry[0][LibraryMOD.GetFieldName(curFeesFN)]=curFees;
drAry[0][LibraryMOD.GetFieldName(isCheckedFN)]=isChecked;
drAry[0][LibraryMOD.GetFieldName(dateCheckedFN)]=dateChecked;
drAry[0][LibraryMOD.GetFieldName(sCheckedByFN)]=sCheckedBy;
drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)]=strUserCreate;
drAry[0][LibraryMOD.GetFieldName(dateCreateFN)]=dateCreate;
drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)]=strUserSave;
drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)]=dateLastSave;
drAry[0][LibraryMOD.GetFieldName(strMachineFN)]=strMachine;
drAry[0][LibraryMOD.GetFieldName(strNUserFN)]=strNUser;
//drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] =  InitializeModule.gUserNo;  //'LastUpdateUserID
//drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//drAry[0][LibraryMOD.GetFieldName(PCNameFN)] =  InitializeModule.gPCName;
//drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] =  InitializeModule.gNetUserName;
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
return  InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitCourse_Header()  
{
//CommitCourse_Header=  InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daCourse_Header.Update(dsCourse_Header, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow=  InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(intStudyYear,byteSemester,byteForm,intFormNumber);
if (( Course_HeaderDataRow != null)) 
{
Course_HeaderDataRow.Delete();
CommitCourse_Header();
if (MoveNext() ==  InitializeModule.FAIL_RET ) return  InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)Course_HeaderDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)Course_HeaderDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(byteFormFN)]== System.DBNull.Value)
{
  byteForm=0;
}
else
{
  byteForm = (int)Course_HeaderDataRow[LibraryMOD.GetFieldName(byteFormFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(intFormNumberFN)]== System.DBNull.Value)
{
  intFormNumber=0;
}
else
{
  intFormNumber = (int)Course_HeaderDataRow[LibraryMOD.GetFieldName(intFormNumberFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)]== System.DBNull.Value)
{
  lngStudentNumber="";
}
else
{
  lngStudentNumber = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(dateFormFN)]== System.DBNull.Value)
{
}
else
{
  dateForm = (DateTime)Course_HeaderDataRow[LibraryMOD.GetFieldName(dateFormFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(lngTransactionFN)]== System.DBNull.Value)
{
  lngTransaction=0;
}
else
{
  lngTransaction = (int)Course_HeaderDataRow[LibraryMOD.GetFieldName(lngTransactionFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(intFYFN)]== System.DBNull.Value)
{
  intFY=0;
}
else
{
  intFY = (int)Course_HeaderDataRow[LibraryMOD.GetFieldName(intFYFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(byteJournalFN)]== System.DBNull.Value)
{
  byteJournal=0;
}
else
{
  byteJournal = (int)Course_HeaderDataRow[LibraryMOD.GetFieldName(byteJournalFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(strVoucherNumberFN)]== System.DBNull.Value)
{
  strVoucherNumber="";
}
else
{
  strVoucherNumber = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(strVoucherNumberFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(curFeesFN)]== System.DBNull.Value)
{
}
else
{
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(isCheckedFN)]== System.DBNull.Value)
{
  isChecked="";
}
else
{
  isChecked = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(isCheckedFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(dateCheckedFN)]== System.DBNull.Value)
{
}
else
{
  dateChecked = (DateTime)Course_HeaderDataRow[LibraryMOD.GetFieldName(dateCheckedFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(sCheckedByFN)]== System.DBNull.Value)
{
  sCheckedBy="";
}
else
{
  sCheckedBy = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(sCheckedByFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Course_HeaderDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Course_HeaderDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Course_HeaderDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Course_HeaderDataRow[LibraryMOD.GetFieldName(strNUserFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(int PKintStudyYear,int PKbyteSemester,int PKbyteForm,int PKintFormNumber) 
{
//FindInMultiPKey=  InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKintStudyYear;
findTheseVals[1] = PKbyteSemester;
findTheseVals[2] = PKbyteForm;
findTheseVals[3] = PKintFormNumber;
Course_HeaderDataRow = dsCourse_Header.Tables[TableName].Rows.Find(findTheseVals);
if  ((Course_HeaderDataRow !=null)) 
{
lngCurRow = dsCourse_Header.Tables[TableName].Rows.IndexOf(Course_HeaderDataRow);
SynchronizeDataRowToClass();
return  InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst=  InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() ==  InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() ==  InitializeModule.FAIL_RET ) return  InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast=  InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsCourse_Header.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() ==  InitializeModule.FAIL_RET ) return  InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext=  InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsCourse_Header.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() ==  InitializeModule.FAIL_RET ) return  InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow=  InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsCourse_Header.Tables[TableName].Rows.Count > 0) 
{
  Course_HeaderDataRow = dsCourse_Header.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return  InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
//  InitializeModule.FAIL_RET;
try
{
daCourse_Header.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCourse_Header.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daCourse_Header.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCourse_Header.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return  InitializeModule.SUCCESS_RET;
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
