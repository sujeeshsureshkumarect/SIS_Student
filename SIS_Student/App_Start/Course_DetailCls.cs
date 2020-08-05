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

public class Course_Detail
{
//Creation Date: 12/05/2010 8:50:32 AM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private int m_byteForm; 
private int m_intFormNumber; 
private string m_strCourse; 
private int m_byteClass; 
private int m_byteShift; 
private int m_byteTrans; 
private string m_bAddSub; 
private string m_strMemo; 
private string m_bTmp; 
private int m_byteHours; 
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
public string strCourse
{
get { return  m_strCourse; }
set {m_strCourse  = value ; }
}
public int byteClass
{
get { return  m_byteClass; }
set {m_byteClass  = value ; }
}
public int byteShift
{
get { return  m_byteShift; }
set {m_byteShift  = value ; }
}
public int byteTrans
{
get { return  m_byteTrans; }
set {m_byteTrans  = value ; }
}
public string bAddSub
{
get { return  m_bAddSub; }
set {m_bAddSub  = value ; }
}
public string strMemo
{
get { return  m_strMemo; }
set {m_strMemo  = value ; }
}
public string bTmp
{
get { return  m_bTmp; }
set {m_bTmp  = value ; }
}
public int byteHours
{
get { return  m_byteHours; }
set {m_byteHours  = value ; }
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
public Course_Detail()
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
public class Course_DetailDAL : Course_Detail
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_byteFormFN ;
private string m_intFormNumberFN ;
private string m_strCourseFN ;
private string m_byteClassFN ;
private string m_byteShiftFN ;
private string m_byteTransFN ;
private string m_bAddSubFN ;
private string m_strMemoFN ;
private string m_bTmpFN ;
private string m_byteHoursFN ;
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
public string strCourseFN 
{
get { return  m_strCourseFN; }
set {m_strCourseFN  = value ; }
}
public string byteClassFN 
{
get { return  m_byteClassFN; }
set {m_byteClassFN  = value ; }
}
public string byteShiftFN 
{
get { return  m_byteShiftFN; }
set {m_byteShiftFN  = value ; }
}
public string byteTransFN 
{
get { return  m_byteTransFN; }
set {m_byteTransFN  = value ; }
}
public string bAddSubFN 
{
get { return  m_bAddSubFN; }
set {m_bAddSubFN  = value ; }
}
public string strMemoFN 
{
get { return  m_strMemoFN; }
set {m_strMemoFN  = value ; }
}
public string bTmpFN 
{
get { return  m_bTmpFN; }
set {m_bTmpFN  = value ; }
}
public string byteHoursFN 
{
get { return  m_byteHoursFN; }
set {m_byteHoursFN  = value ; }
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
public Course_DetailDAL()
{
try
{
this.TableName = "Reg_Course_Detail";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.byteFormFN = m_TableName + ".byteForm";
this.intFormNumberFN = m_TableName + ".intFormNumber";
this.strCourseFN = m_TableName + ".strCourse";
this.byteClassFN = m_TableName + ".byteClass";
this.byteShiftFN = m_TableName + ".byteShift";
this.byteTransFN = m_TableName + ".byteTrans";
this.bAddSubFN = m_TableName + ".bAddSub";
this.strMemoFN = m_TableName + ".strMemo";
this.bTmpFN = m_TableName + ".bTmp";
this.byteHoursFN = m_TableName + ".byteHours";
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
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + byteTransFN;
sSQL += " , " + bAddSubFN;
sSQL += " , " + strMemoFN;
sSQL += " , " + bTmpFN;
sSQL += " , " + byteHoursFN;
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
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + byteTransFN;
sSQL += " , " + bAddSubFN;
sSQL += " , " + strMemoFN;
sSQL += " , " + bTmpFN;
sSQL += " , " + byteHoursFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN) + "=@byteClass";
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
sSQL += " , " + LibraryMOD.GetFieldName(byteTransFN) + "=@byteTrans";
sSQL += " , " + LibraryMOD.GetFieldName(bAddSubFN) + "=@bAddSub";
sSQL += " , " + LibraryMOD.GetFieldName(strMemoFN) + "=@strMemo";
sSQL += " , " + LibraryMOD.GetFieldName(bTmpFN) + "=@bTmp";
sSQL += " , " + LibraryMOD.GetFieldName(byteHoursFN) + "=@byteHours";
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
sSQL +=  " And " + LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteTransFN)+"=@byteTrans";
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
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteTransFN);
sSQL += " , " + LibraryMOD.GetFieldName(bAddSubFN);
sSQL += " , " + LibraryMOD.GetFieldName(strMemoFN);
sSQL += " , " + LibraryMOD.GetFieldName(bTmpFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteHoursFN);
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
sSQL += " ,@strCourse";
sSQL += " ,@byteClass";
sSQL += " ,@byteShift";
sSQL += " ,@byteTrans";
sSQL += " ,@bAddSub";
sSQL += " ,@strMemo";
sSQL += " ,@bTmp";
sSQL += " ,@byteHours";
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
sSQL +=  " And " +  LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteTransFN)+"=@byteTrans";
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
public List <Course_Detail> GetCourse_Detail(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Course_Detail
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
List<Course_Detail> results = new List<Course_Detail>();
try
{
//Default Value
Course_Detail myCourse_Detail = new Course_Detail();
if (isDeafaultIncluded)
{
//Change the code here
myCourse_Detail.intStudyYear = 0;
myCourse_Detail.byteSemester = 0;
myCourse_Detail.byteForm = 0;
myCourse_Detail.intFormNumber = 0;
myCourse_Detail.strCourse = "";
myCourse_Detail.byteClass = 0;
myCourse_Detail.byteShift = 0;
myCourse_Detail.byteTrans = 0;
myCourse_Detail.bAddSub = "Select Course_Detail ...";
results.Add(myCourse_Detail);
}
while (reader.Read())
{
myCourse_Detail = new Course_Detail();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myCourse_Detail.intStudyYear = 0;
}
else
{
myCourse_Detail.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myCourse_Detail.byteSemester = 0;
}
else
{
myCourse_Detail.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteFormFN)].Equals(DBNull.Value))
{
myCourse_Detail.byteForm = 0;
}
else
{
myCourse_Detail.byteForm = int.Parse(reader[LibraryMOD.GetFieldName( byteFormFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intFormNumberFN)].Equals(DBNull.Value))
{
myCourse_Detail.intFormNumber = 0;
}
else
{
myCourse_Detail.intFormNumber = int.Parse(reader[LibraryMOD.GetFieldName( intFormNumberFN) ].ToString());
}
myCourse_Detail.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteClassFN)].Equals(DBNull.Value))
{
myCourse_Detail.byteClass = 0;
}
else
{
myCourse_Detail.byteClass = int.Parse(reader[LibraryMOD.GetFieldName( byteClassFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myCourse_Detail.byteShift = 0;
}
else
{
myCourse_Detail.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteTransFN)].Equals(DBNull.Value))
{
myCourse_Detail.byteTrans = 0;
}
else
{
myCourse_Detail.byteTrans = int.Parse(reader[LibraryMOD.GetFieldName( byteTransFN) ].ToString());
}
myCourse_Detail.bAddSub =reader[LibraryMOD.GetFieldName( bAddSubFN) ].ToString();
myCourse_Detail.strMemo =reader[LibraryMOD.GetFieldName( strMemoFN) ].ToString();
myCourse_Detail.bTmp =reader[LibraryMOD.GetFieldName( bTmpFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteHoursFN)].Equals(DBNull.Value))
{
myCourse_Detail.byteHours = 0;
}
else
{
myCourse_Detail.byteHours = int.Parse(reader[LibraryMOD.GetFieldName( byteHoursFN) ].ToString());
}
myCourse_Detail.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[dateCreateFN].Equals(DBNull.Value))
{
myCourse_Detail.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myCourse_Detail.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[dateLastSaveFN].Equals(DBNull.Value))
{
myCourse_Detail.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myCourse_Detail.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myCourse_Detail.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myCourse_Detail);
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
public int UpdateCourse_Detail(InitializeModule.EnumCampus Campus, int iMode, int intStudyYear, int byteSemester, int byteForm, int intFormNumber, string strCourse, int byteClass, int byteShift, int byteTrans, string bAddSub, string strMemo, string bTmp, int byteHours, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Course_Detail theCourse_Detail = new Course_Detail();
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
    int iAddSub = 0;
    if (bAddSub.ToUpper().Equals("True".ToUpper()))
        iAddSub = 1;

SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@intStudyYear",intStudyYear));
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@byteForm",byteForm));
Cmd.Parameters.Add(new SqlParameter("@intFormNumber",intFormNumber));
Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
Cmd.Parameters.Add(new SqlParameter("@byteClass",byteClass));
Cmd.Parameters.Add(new SqlParameter("@byteShift",byteShift));
Cmd.Parameters.Add(new SqlParameter("@byteTrans",byteTrans));
Cmd.Parameters.Add(new SqlParameter("@bAddSub",iAddSub));
Cmd.Parameters.Add(new SqlParameter("@strMemo",strMemo));
Cmd.Parameters.Add(new SqlParameter("@bTmp",bTmp));
Cmd.Parameters.Add(new SqlParameter("@byteHours",byteHours));
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
public int DeleteCourse_Detail( InitializeModule.EnumCampus Campus,string intStudyYear,string byteSemester,string byteForm,string intFormNumber,string strCourse,string byteClass,string byteShift,string byteTrans)
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
Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse ));
Cmd.Parameters.Add(new SqlParameter("@byteClass", byteClass ));
Cmd.Parameters.Add(new SqlParameter("@byteShift", byteShift ));
Cmd.Parameters.Add(new SqlParameter("@byteTrans", byteTrans ));
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
DataTable dt = new DataTable("Course_Detail");
DataView dv = new DataView();
List<Course_Detail> myCourse_Details = new List<Course_Detail>();
try
{
myCourse_Details = GetCourse_Detail( InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3 = new DataColumn("byteForm", Type.GetType("smallint"));
dt.Columns.Add(col3);
DataColumn col4 = new DataColumn("intFormNumber", Type.GetType("smallint"));
dt.Columns.Add(col4);
DataColumn col5 = new DataColumn("strCourse", Type.GetType("nvarchar"));
dt.Columns.Add(col5);
DataColumn col6 = new DataColumn("byteClass", Type.GetType("smallint"));
dt.Columns.Add(col6);
DataColumn col7 = new DataColumn("byteShift", Type.GetType("smallint"));
dt.Columns.Add(col7);
DataColumn col8 = new DataColumn("byteTrans", Type.GetType("smallint"));
dt.Columns.Add(col8);

dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));
dt.Constraints.Add(new UniqueConstraint(col4));
dt.Constraints.Add(new UniqueConstraint(col5));
dt.Constraints.Add(new UniqueConstraint(col6));
dt.Constraints.Add(new UniqueConstraint(col7));
dt.Constraints.Add(new UniqueConstraint(col8));

DataRow dr;
for (int i = 0; i < myCourse_Details.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCourse_Details[i].intStudyYear;
  dr[2] = myCourse_Details[i].byteSemester;
  dr[3] = myCourse_Details[i].byteForm;
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
myCourse_Details.Clear();
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
public class Course_DetailCls : Course_DetailDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daCourse_Detail;
private DataSet m_dsCourse_Detail;
public DataRow Course_DetailDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsCourse_Detail
{
get { return m_dsCourse_Detail ; }
set { m_dsCourse_Detail = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Course_DetailCls()
{
try
{
dsCourse_Detail= new DataSet();

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
public virtual SqlDataAdapter GetCourse_DetailDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daCourse_Detail = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCourse_Detail);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daCourse_Detail.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCourse_Detail;
}
public virtual SqlDataAdapter GetCourse_DetailDataAdapter(SqlConnection con)  
{
try
{
daCourse_Detail = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daCourse_Detail.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdCourse_Detail;
cmdCourse_Detail = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, "intStudyYear" );
//'cmdRolePermission.Parameters.Add("@byteSemester", SqlDbType.Int, 4, "byteSemester" );
//'cmdRolePermission.Parameters.Add("@byteForm", SqlDbType.Int, 4, "byteForm" );
//'cmdRolePermission.Parameters.Add("@intFormNumber", SqlDbType.Int, 4, "intFormNumber" );
//'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
//'cmdRolePermission.Parameters.Add("@byteClass", SqlDbType.Int, 4, "byteClass" );
//'cmdRolePermission.Parameters.Add("@byteShift", SqlDbType.Int, 4, "byteShift" );
//'cmdRolePermission.Parameters.Add("@byteTrans", SqlDbType.Int, 4, "byteTrans" );
daCourse_Detail.SelectCommand = cmdCourse_Detail;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdCourse_Detail = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdCourse_Detail.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdCourse_Detail.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdCourse_Detail.Parameters.Add("@byteForm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormFN));
cmdCourse_Detail.Parameters.Add("@intFormNumber", SqlDbType.Int,2, LibraryMOD.GetFieldName(intFormNumberFN));
cmdCourse_Detail.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdCourse_Detail.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdCourse_Detail.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdCourse_Detail.Parameters.Add("@byteTrans", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteTransFN));
cmdCourse_Detail.Parameters.Add("@bAddSub", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bAddSubFN));
cmdCourse_Detail.Parameters.Add("@strMemo", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(strMemoFN));
cmdCourse_Detail.Parameters.Add("@bTmp", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bTmpFN));
cmdCourse_Detail.Parameters.Add("@byteHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteHoursFN));
cmdCourse_Detail.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdCourse_Detail.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdCourse_Detail.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdCourse_Detail.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdCourse_Detail.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdCourse_Detail.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdCourse_Detail.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteForm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFormFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@intFormNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intFormNumberFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteTrans", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteTransFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daCourse_Detail.UpdateCommand = cmdCourse_Detail;
daCourse_Detail.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdCourse_Detail = new SqlCommand(GetInsertCommand(), con);
cmdCourse_Detail.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdCourse_Detail.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdCourse_Detail.Parameters.Add("@byteForm", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteFormFN));
cmdCourse_Detail.Parameters.Add("@intFormNumber", SqlDbType.Int,2, LibraryMOD.GetFieldName(intFormNumberFN));
cmdCourse_Detail.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdCourse_Detail.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdCourse_Detail.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdCourse_Detail.Parameters.Add("@byteTrans", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteTransFN));
cmdCourse_Detail.Parameters.Add("@bAddSub", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bAddSubFN));
cmdCourse_Detail.Parameters.Add("@strMemo", SqlDbType.NText,2147483646, LibraryMOD.GetFieldName(strMemoFN));
cmdCourse_Detail.Parameters.Add("@bTmp", SqlDbType.Bit,1, LibraryMOD.GetFieldName(bTmpFN));
cmdCourse_Detail.Parameters.Add("@byteHours", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteHoursFN));
cmdCourse_Detail.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdCourse_Detail.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdCourse_Detail.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdCourse_Detail.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdCourse_Detail.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdCourse_Detail.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daCourse_Detail.InsertCommand =cmdCourse_Detail;
daCourse_Detail.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdCourse_Detail = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdCourse_Detail.Parameters.Add("@intStudyYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intStudyYearFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteSemesterFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteForm", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteFormFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@intFormNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(intFormNumberFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter = cmdCourse_Detail.Parameters.Add("@byteTrans", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteTransFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daCourse_Detail.DeleteCommand =cmdCourse_Detail;
daCourse_Detail.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daCourse_Detail.UpdateBatchSize =  InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCourse_Detail;
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
dr = dsCourse_Detail.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(byteFormFN)]=byteForm;
dr[LibraryMOD.GetFieldName(intFormNumberFN)]=intFormNumber;
dr[LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
dr[LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
dr[LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
dr[LibraryMOD.GetFieldName(byteTransFN)]=byteTrans;
dr[LibraryMOD.GetFieldName(bAddSubFN)]=bAddSub;
dr[LibraryMOD.GetFieldName(strMemoFN)]=strMemo;
dr[LibraryMOD.GetFieldName(bTmpFN)]=bTmp;
dr[LibraryMOD.GetFieldName(byteHoursFN)]=byteHours;
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
dsCourse_Detail.Tables[TableName].Rows.Add(dr);
break;
case (int) InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsCourse_Detail.Tables[TableName].Select(LibraryMOD.GetFieldName(intStudyYearFN)  + "=" + intStudyYear  + " AND " + LibraryMOD.GetFieldName(byteSemesterFN) + "=" + byteSemester  + " AND " + LibraryMOD.GetFieldName(byteFormFN) + "=" + byteForm  + " AND " + LibraryMOD.GetFieldName(intFormNumberFN) + "=" + intFormNumber  + " AND " + LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse  + " AND " + LibraryMOD.GetFieldName(byteClassFN) + "=" + byteClass  + " AND " + LibraryMOD.GetFieldName(byteShiftFN) + "=" + byteShift  + " AND " + LibraryMOD.GetFieldName(byteTransFN) + "=" + byteTrans);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(byteFormFN)]=byteForm;
drAry[0][LibraryMOD.GetFieldName(intFormNumberFN)]=intFormNumber;
drAry[0][LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
drAry[0][LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
drAry[0][LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
drAry[0][LibraryMOD.GetFieldName(byteTransFN)]=byteTrans;
drAry[0][LibraryMOD.GetFieldName(bAddSubFN)]=bAddSub;
drAry[0][LibraryMOD.GetFieldName(strMemoFN)]=strMemo;
drAry[0][LibraryMOD.GetFieldName(bTmpFN)]=bTmp;
drAry[0][LibraryMOD.GetFieldName(byteHoursFN)]=byteHours;
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
public int CommitCourse_Detail()  
{
//CommitCourse_Detail=  InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daCourse_Detail.Update(dsCourse_Detail, TableName);
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
FindInMultiPKey(intStudyYear,byteSemester,byteForm,intFormNumber,strCourse,byteClass,byteShift,byteTrans);
if (( Course_DetailDataRow != null)) 
{
Course_DetailDataRow.Delete();
CommitCourse_Detail();
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
if (Course_DetailDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(byteFormFN)]== System.DBNull.Value)
{
  byteForm=0;
}
else
{
  byteForm = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(byteFormFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(intFormNumberFN)]== System.DBNull.Value)
{
  intFormNumber=0;
}
else
{
  intFormNumber = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(intFormNumberFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(strCourseFN)]== System.DBNull.Value)
{
  strCourse="";
}
else
{
  strCourse = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(strCourseFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(byteClassFN)]== System.DBNull.Value)
{
  byteClass=0;
}
else
{
  byteClass = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(byteClassFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(byteShiftFN)]== System.DBNull.Value)
{
  byteShift=0;
}
else
{
  byteShift = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(byteShiftFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(byteTransFN)]== System.DBNull.Value)
{
  byteTrans=0;
}
else
{
  byteTrans = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(byteTransFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(bAddSubFN)]== System.DBNull.Value)
{
  bAddSub="";
}
else
{
  bAddSub = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(bAddSubFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(strMemoFN)]== System.DBNull.Value)
{
  strMemo="";
}
else
{
  strMemo = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(strMemoFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(bTmpFN)]== System.DBNull.Value)
{
  bTmp="";
}
else
{
  bTmp = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(bTmpFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(byteHoursFN)]== System.DBNull.Value)
{
  byteHours=0;
}
else
{
  byteHours = (int)Course_DetailDataRow[LibraryMOD.GetFieldName(byteHoursFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Course_DetailDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Course_DetailDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Course_DetailDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Course_DetailDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(int PKintStudyYear,int PKbyteSemester,int PKbyteForm,int PKintFormNumber,string PKstrCourse,int PKbyteClass,int PKbyteShift,int PKbyteTrans) 
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
findTheseVals[4] = PKstrCourse;
findTheseVals[5] = PKbyteClass;
findTheseVals[6] = PKbyteShift;
findTheseVals[7] = PKbyteTrans;
Course_DetailDataRow = dsCourse_Detail.Tables[TableName].Rows.Find(findTheseVals);
if  ((Course_DetailDataRow !=null)) 
{
lngCurRow = dsCourse_Detail.Tables[TableName].Rows.IndexOf(Course_DetailDataRow);
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
  lngCurRow = dsCourse_Detail.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsCourse_Detail.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsCourse_Detail.Tables[TableName].Rows.Count > 0) 
{
  Course_DetailDataRow = dsCourse_Detail.Tables[TableName].Rows[lngCurRow];
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
daCourse_Detail.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCourse_Detail.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daCourse_Detail.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCourse_Detail.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
