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
public class Available_Courses
{
//Creation Date: 05/04/2010 9:54:37 AM
//Programmer Name : Ihab Awad
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private string m_strCourse; 
private int m_byteClass; 
private int m_byteShift; 
private int m_byteGroup; 
private int m_intLecturer; 
private int m_intLecturer2; 
private int m_byteType; 
private int m_intMax; 
private DateTime m_dateBegin; 
private string m_strNotes; 
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
public int byteGroup
{
get { return  m_byteGroup; }
set {m_byteGroup  = value ; }
}
public int intLecturer
{
get { return  m_intLecturer; }
set {m_intLecturer  = value ; }
}
public int intLecturer2
{
get { return  m_intLecturer2; }
set {m_intLecturer2  = value ; }
}
public int byteType
{
get { return  m_byteType; }
set {m_byteType  = value ; }
}
public int intMax
{
get { return  m_intMax; }
set {m_intMax  = value ; }
}
public DateTime dateBegin
{
get { return  m_dateBegin; }
set {m_dateBegin  = value ; }
}
public string strNotes
{
get { return  m_strNotes; }
set {m_strNotes  = value ; }
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
public Available_Courses()
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
public class Available_CoursesDAL : Available_Courses
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_strCourseFN ;
private string m_strUnifiedFN;
private string m_byteClassFN ;
private string m_byteShiftFN ;
private string m_byteGroupFN ;
private string m_intLecturerFN ;
private string m_intLecturer2FN ;
private string m_byteTypeFN ;
private string m_intMaxFN ;
private string m_dateBeginFN ;
private string m_strNotesFN ;
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
public string strCourseFN 
{
get { return  m_strCourseFN; }
set {m_strCourseFN  = value ; }
}
public string strUnifiedFN 
    {
        get { return m_strUnifiedFN; }
        set { m_strUnifiedFN = value; }
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
public string byteGroupFN 
{
get { return  m_byteGroupFN; }
set {m_byteGroupFN  = value ; }
}
public string intLecturerFN 
{
get { return  m_intLecturerFN; }
set {m_intLecturerFN  = value ; }
}
public string intLecturer2FN 
{
get { return  m_intLecturer2FN; }
set {m_intLecturer2FN  = value ; }
}
public string byteTypeFN 
{
get { return  m_byteTypeFN; }
set {m_byteTypeFN  = value ; }
}
public string intMaxFN 
{
get { return  m_intMaxFN; }
set {m_intMaxFN  = value ; }
}
public string dateBeginFN 
{
get { return  m_dateBeginFN; }
set {m_dateBeginFN  = value ; }
}
public string strNotesFN 
{
get { return  m_strNotesFN; }
set {m_strNotesFN  = value ; }
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
public Available_CoursesDAL()
{
try
{
this.TableName = "Reg_Available_Courses";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.strCourseFN = m_TableName + ".strCourse";
this.strUnifiedFN = m_TableName + ".strUnified";
this.byteClassFN = m_TableName + ".byteClass";
this.byteShiftFN = m_TableName + ".byteShift";
this.byteGroupFN = m_TableName + ".byteGroup";
this.intLecturerFN = m_TableName + ".intLecturer";
this.intLecturer2FN = m_TableName + ".intLecturer2";
this.byteTypeFN = m_TableName + ".byteType";
this.intMaxFN = m_TableName + ".intMax";
this.dateBeginFN = m_TableName + ".dateBegin";
this.strNotesFN = m_TableName + ".strNotes";
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
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + byteGroupFN;
sSQL += " , " + intLecturerFN;
sSQL += " , " + intLecturer2FN;
sSQL += " , " + byteTypeFN;
sSQL += " , " + intMaxFN;
sSQL += " , " + dateBeginFN;
sSQL += " , " + strNotesFN;
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
sSQL += " , " + strCourseFN;
sSQL += " , " + byteClassFN;
sSQL += " , " + byteShiftFN;
sSQL += " , " + byteGroupFN;
sSQL += " , " + intLecturerFN;
sSQL += " , " + intLecturer2FN;
sSQL += " , " + byteTypeFN;
sSQL += " , " + intMaxFN;
sSQL += " , " + dateBeginFN;
sSQL += " , " + strNotesFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN) + "=@byteClass";
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
sSQL += " , " + LibraryMOD.GetFieldName(byteGroupFN) + "=@byteGroup";
sSQL += " , " + LibraryMOD.GetFieldName(intLecturerFN) + "=@intLecturer";
sSQL += " , " + LibraryMOD.GetFieldName(intLecturer2FN) + "=@intLecturer2";
sSQL += " , " + LibraryMOD.GetFieldName(byteTypeFN) + "=@byteType";
sSQL += " , " + LibraryMOD.GetFieldName(intMaxFN) + "=@intMax";
sSQL += " , " + LibraryMOD.GetFieldName(dateBeginFN) + "=@dateBegin";
sSQL += " , " + LibraryMOD.GetFieldName(strNotesFN) + "=@strNotes";
sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " + LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
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
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteClassFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteGroupFN);
sSQL += " , " + LibraryMOD.GetFieldName(intLecturerFN);
sSQL += " , " + LibraryMOD.GetFieldName(intLecturer2FN);
sSQL += " , " + LibraryMOD.GetFieldName(byteTypeFN);
sSQL += " , " + LibraryMOD.GetFieldName(intMaxFN);
sSQL += " , " + LibraryMOD.GetFieldName(dateBeginFN);
sSQL += " , " + LibraryMOD.GetFieldName(strNotesFN);
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
sSQL += " ,@strCourse";
sSQL += " ,@byteClass";
sSQL += " ,@byteShift";
sSQL += " ,@byteGroup";
sSQL += " ,@intLecturer";
sSQL += " ,@intLecturer2";
sSQL += " ,@byteType";
sSQL += " ,@intMax";
sSQL += " ,@dateBegin";
sSQL += " ,@strNotes";
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
sSQL += LibraryMOD.GetFieldName(strCourseFN)+"=@strCourse";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteClassFN)+"=@byteClass";
sSQL +=  " And " +  LibraryMOD.GetFieldName(byteShiftFN)+"=@byteShift";
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
public List< Available_Courses> GetAvailable_Courses(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Available_Courses
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
List<Available_Courses> results = new List<Available_Courses>();
try
{
//Default Value
Available_Courses myAvailable_Courses = new Available_Courses();
if (isDeafaultIncluded)
{
//Change the code here
    myAvailable_Courses.strCourse = "Select Available_Courses ...";
myAvailable_Courses.byteClass = 0;
myAvailable_Courses.byteShift = 0;
results.Add(myAvailable_Courses);
}
while (reader.Read())
{
myAvailable_Courses = new Available_Courses();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myAvailable_Courses.intStudyYear = 0;
}
else
{
myAvailable_Courses.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myAvailable_Courses.byteSemester = 0;
}
else
{
myAvailable_Courses.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
myAvailable_Courses.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(byteClassFN)].Equals(DBNull.Value))
{
myAvailable_Courses.byteClass = 0;
}
else
{
myAvailable_Courses.byteClass = int.Parse(reader[LibraryMOD.GetFieldName( byteClassFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myAvailable_Courses.byteShift = 0;
}
else
{
myAvailable_Courses.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteGroupFN)].Equals(DBNull.Value))
{
myAvailable_Courses.byteGroup = 0;
}
else
{
myAvailable_Courses.byteGroup = int.Parse(reader[LibraryMOD.GetFieldName( byteGroupFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intLecturerFN)].Equals(DBNull.Value))
{
myAvailable_Courses.intLecturer = 0;
}
else
{
myAvailable_Courses.intLecturer = int.Parse(reader[LibraryMOD.GetFieldName( intLecturerFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intLecturer2FN)].Equals(DBNull.Value))
{
myAvailable_Courses.intLecturer2 = 0;
}
else
{
myAvailable_Courses.intLecturer2 = int.Parse(reader[LibraryMOD.GetFieldName( intLecturer2FN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteTypeFN)].Equals(DBNull.Value))
{
myAvailable_Courses.byteType = 0;
}
else
{
myAvailable_Courses.byteType = int.Parse(reader[LibraryMOD.GetFieldName( byteTypeFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(intMaxFN)].Equals(DBNull.Value))
{
myAvailable_Courses.intMax = 0;
}
else
{
myAvailable_Courses.intMax = int.Parse(reader[LibraryMOD.GetFieldName( intMaxFN) ].ToString());
}
if (!reader[dateBeginFN].Equals(DBNull.Value))
{
myAvailable_Courses.dateBegin = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateBeginFN) ].ToString());
}
myAvailable_Courses.strNotes =reader[LibraryMOD.GetFieldName( strNotesFN) ].ToString();
myAvailable_Courses.strUserCreate =reader[LibraryMOD.GetFieldName( strUserCreateFN) ].ToString();
if (!reader[dateCreateFN].Equals(DBNull.Value))
{
myAvailable_Courses.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateCreateFN) ].ToString());
}
myAvailable_Courses.strUserSave =reader[LibraryMOD.GetFieldName( strUserSaveFN) ].ToString();
if (!reader[dateLastSaveFN].Equals(DBNull.Value))
{
myAvailable_Courses.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName( dateLastSaveFN) ].ToString());
}
myAvailable_Courses.strMachine =reader[LibraryMOD.GetFieldName( strMachineFN) ].ToString();
myAvailable_Courses.strNUser =reader[LibraryMOD.GetFieldName( strNUserFN) ].ToString();
 results.Add(myAvailable_Courses);
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
public int UpdateAvailable_Courses(InitializeModule.EnumCampus Campus, int iMode,int intStudyYear,int byteSemester,string strCourse,int byteClass,int byteShift,int byteGroup,int intLecturer,int intLecturer2,int byteType,int intMax,DateTime dateBegin,string strNotes,string strUserCreate,DateTime dateCreate,string strUserSave,DateTime dateLastSave,string strMachine,string strNUser)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Available_Courses theAvailable_Courses = new Available_Courses();
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
Cmd.Parameters.Add(new SqlParameter("@byteSemester",byteSemester));
Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
Cmd.Parameters.Add(new SqlParameter("@byteClass",byteClass));
Cmd.Parameters.Add(new SqlParameter("@byteShift",byteShift));
Cmd.Parameters.Add(new SqlParameter("@byteGroup",byteGroup));
Cmd.Parameters.Add(new SqlParameter("@intLecturer",intLecturer));
Cmd.Parameters.Add(new SqlParameter("@intLecturer2",intLecturer2));
Cmd.Parameters.Add(new SqlParameter("@byteType",byteType));
Cmd.Parameters.Add(new SqlParameter("@intMax",intMax));
Cmd.Parameters.Add(new SqlParameter("@dateBegin",dateBegin));
Cmd.Parameters.Add(new SqlParameter("@strNotes",strNotes));
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
public int DeleteAvailable_Courses(InitializeModule.EnumCampus Campus,string strCourse,string byteClass,string byteShift)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse ));
Cmd.Parameters.Add(new SqlParameter("@byteClass", byteClass ));
Cmd.Parameters.Add(new SqlParameter("@byteShift", byteShift ));
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
DataTable dt = new DataTable("Available_Courses");
DataView dv = new DataView();
List<Available_Courses> myAvailable_Coursess = new List<Available_Courses>();
try
{
myAvailable_Coursess = GetAvailable_Courses(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("strCourse", Type.GetType("nvarchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));
dt.Constraints.Add(new UniqueConstraint(col3));

DataRow dr;
for (int i = 0; i < myAvailable_Coursess.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myAvailable_Coursess[i].intStudyYear;
  dr[2] = myAvailable_Coursess[i].byteSemester;
  dr[3] = myAvailable_Coursess[i].strCourse;
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
myAvailable_Coursess.Clear();
}
 return dv;
}

public int IsCourseOffered(InitializeModule.EnumCampus Campus, string sCourse, int iYear, int iSem,int iClass,int iSession)
{
    String sSQL;
    int IsOffered = InitializeModule.FALSE_VALUE  ;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += strUnifiedFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + strCourseFN + "='" + sCourse + "'";
        sSQL += "  AND " + intStudyYearFN  + "=" + iYear ;
        sSQL += "  AND " + byteSemesterFN  + "=" + iSem ;
        sSQL += "  AND " + byteClassFN  + "=" + iClass ;
        sSQL += "  AND " + byteShiftFN + "=" + iSession;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);

        if (datReader.Read())
        {
            IsOffered = InitializeModule.TRUE_VALUE;
        }
        datReader.Close();

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

    return IsOffered;
}

public string GetUnified(InitializeModule.EnumCampus Campus,string sCourse,int iYear,int iSem)
{
    String sSQL;
    String sUnified = "";
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += strUnifiedFN;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + strCourseFN + "='" + sCourse + "'";
        sSQL += "  AND " + intStudyYearFN  + "=" + iYear ;
        sSQL += "  AND " + byteSemesterFN  + "=" + iSem ;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            sUnified = datReader.GetString(0);
        }
        datReader.Close();

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

    return sUnified;
}
//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += strCourseFN;
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
public class Available_CoursesCls : Available_CoursesDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daAvailable_Courses;
private DataSet m_dsAvailable_Courses;
public DataRow Available_CoursesDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsAvailable_Courses
{
get { return m_dsAvailable_Courses ; }
set { m_dsAvailable_Courses = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Available_CoursesCls()
{
try
{
dsAvailable_Courses= new DataSet();

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
public virtual SqlDataAdapter GetAvailable_CoursesDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daAvailable_Courses = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daAvailable_Courses);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daAvailable_Courses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAvailable_Courses;
}
public virtual SqlDataAdapter GetAvailable_CoursesDataAdapter(SqlConnection con)  
{
try
{
daAvailable_Courses = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daAvailable_Courses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdAvailable_Courses;
cmdAvailable_Courses = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
//'cmdRolePermission.Parameters.Add("@byteClass", SqlDbType.Int, 4, "byteClass" );
//'cmdRolePermission.Parameters.Add("@byteShift", SqlDbType.Int, 4, "byteShift" );
daAvailable_Courses.SelectCommand = cmdAvailable_Courses;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdAvailable_Courses = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdAvailable_Courses.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdAvailable_Courses.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdAvailable_Courses.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdAvailable_Courses.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdAvailable_Courses.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdAvailable_Courses.Parameters.Add("@byteGroup", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGroupFN));
cmdAvailable_Courses.Parameters.Add("@intLecturer", SqlDbType.Int,2, LibraryMOD.GetFieldName(intLecturerFN));
cmdAvailable_Courses.Parameters.Add("@intLecturer2", SqlDbType.Int,2, LibraryMOD.GetFieldName(intLecturer2FN));
cmdAvailable_Courses.Parameters.Add("@byteType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteTypeFN));
cmdAvailable_Courses.Parameters.Add("@intMax", SqlDbType.Int,2, LibraryMOD.GetFieldName(intMaxFN));
cmdAvailable_Courses.Parameters.Add("@dateBegin", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateBeginFN));
cmdAvailable_Courses.Parameters.Add("@strNotes", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNotesFN));
cmdAvailable_Courses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdAvailable_Courses.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdAvailable_Courses.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdAvailable_Courses.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdAvailable_Courses.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdAvailable_Courses.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));


Parmeter = cmdAvailable_Courses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdAvailable_Courses.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdAvailable_Courses.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daAvailable_Courses.UpdateCommand = cmdAvailable_Courses;
daAvailable_Courses.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdAvailable_Courses = new SqlCommand(GetInsertCommand(), con);
cmdAvailable_Courses.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdAvailable_Courses.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdAvailable_Courses.Parameters.Add("@strCourse", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(strCourseFN));
cmdAvailable_Courses.Parameters.Add("@byteClass", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteClassFN));
cmdAvailable_Courses.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdAvailable_Courses.Parameters.Add("@byteGroup", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteGroupFN));
cmdAvailable_Courses.Parameters.Add("@intLecturer", SqlDbType.Int,2, LibraryMOD.GetFieldName(intLecturerFN));
cmdAvailable_Courses.Parameters.Add("@intLecturer2", SqlDbType.Int,2, LibraryMOD.GetFieldName(intLecturer2FN));
cmdAvailable_Courses.Parameters.Add("@byteType", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteTypeFN));
cmdAvailable_Courses.Parameters.Add("@intMax", SqlDbType.Int,2, LibraryMOD.GetFieldName(intMaxFN));
cmdAvailable_Courses.Parameters.Add("@dateBegin", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateBeginFN));
cmdAvailable_Courses.Parameters.Add("@strNotes", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNotesFN));
cmdAvailable_Courses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strUserCreateFN));
cmdAvailable_Courses.Parameters.Add("@dateCreate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateCreateFN));
cmdAvailable_Courses.Parameters.Add("@strUserSave", SqlDbType.Char,10, LibraryMOD.GetFieldName(strUserSaveFN));
cmdAvailable_Courses.Parameters.Add("@dateLastSave", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(dateLastSaveFN));
cmdAvailable_Courses.Parameters.Add("@strMachine", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strMachineFN));
cmdAvailable_Courses.Parameters.Add("@strNUser", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strNUserFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daAvailable_Courses.InsertCommand =cmdAvailable_Courses;
daAvailable_Courses.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdAvailable_Courses = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdAvailable_Courses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
Parmeter = cmdAvailable_Courses.Parameters.Add("@byteClass", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteClassFN));
Parmeter = cmdAvailable_Courses.Parameters.Add("@byteShift", SqlDbType.Int, 4, LibraryMOD.GetFieldName(byteShiftFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daAvailable_Courses.DeleteCommand =cmdAvailable_Courses;
daAvailable_Courses.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daAvailable_Courses.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daAvailable_Courses;
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
dr = dsAvailable_Courses.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
dr[LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
dr[LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
dr[LibraryMOD.GetFieldName(byteGroupFN)]=byteGroup;
dr[LibraryMOD.GetFieldName(intLecturerFN)]=intLecturer;
dr[LibraryMOD.GetFieldName(intLecturer2FN)]=intLecturer2;
dr[LibraryMOD.GetFieldName(byteTypeFN)]=byteType;
dr[LibraryMOD.GetFieldName(intMaxFN)]=intMax;
dr[LibraryMOD.GetFieldName(dateBeginFN)]=dateBegin;
dr[LibraryMOD.GetFieldName(strNotesFN)]=strNotes;
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
dsAvailable_Courses.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsAvailable_Courses.Tables[TableName].Select(LibraryMOD.GetFieldName(strCourseFN)  + "=" + strCourse  + " AND " + LibraryMOD.GetFieldName(byteClassFN) + "=" + byteClass  + " AND " + LibraryMOD.GetFieldName(byteShiftFN) + "=" + byteShift);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
drAry[0][LibraryMOD.GetFieldName(byteClassFN)]=byteClass;
drAry[0][LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
drAry[0][LibraryMOD.GetFieldName(byteGroupFN)]=byteGroup;
drAry[0][LibraryMOD.GetFieldName(intLecturerFN)]=intLecturer;
drAry[0][LibraryMOD.GetFieldName(intLecturer2FN)]=intLecturer2;
drAry[0][LibraryMOD.GetFieldName(byteTypeFN)]=byteType;
drAry[0][LibraryMOD.GetFieldName(intMaxFN)]=intMax;
drAry[0][LibraryMOD.GetFieldName(dateBeginFN)]=dateBegin;
drAry[0][LibraryMOD.GetFieldName(strNotesFN)]=strNotes;
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
public int CommitAvailable_Courses()  
{
//CommitAvailable_Courses= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daAvailable_Courses.Update(dsAvailable_Courses, TableName);
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
FindInMultiPKey(strCourse,byteClass,byteShift);
if (( Available_CoursesDataRow != null)) 
{
Available_CoursesDataRow.Delete();
CommitAvailable_Courses();
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
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)]== System.DBNull.Value)
{
  strCourse="";
}
else
{
  strCourse = (string)Available_CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(byteClassFN)]== System.DBNull.Value)
{
  byteClass=0;
}
else
{
  byteClass = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(byteClassFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(byteShiftFN)]== System.DBNull.Value)
{
  byteShift=0;
}
else
{
  byteShift = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(byteShiftFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(byteGroupFN)]== System.DBNull.Value)
{
  byteGroup=0;
}
else
{
  byteGroup = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(byteGroupFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(intLecturerFN)]== System.DBNull.Value)
{
  intLecturer=0;
}
else
{
  intLecturer = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(intLecturerFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(intLecturer2FN)]== System.DBNull.Value)
{
  intLecturer2=0;
}
else
{
  intLecturer2 = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(intLecturer2FN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(byteTypeFN)]== System.DBNull.Value)
{
  byteType=0;
}
else
{
  byteType = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(byteTypeFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(intMaxFN)]== System.DBNull.Value)
{
  intMax=0;
}
else
{
  intMax = (int)Available_CoursesDataRow[LibraryMOD.GetFieldName(intMaxFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(dateBeginFN)]== System.DBNull.Value)
{
}
else
{
  dateBegin = (DateTime)Available_CoursesDataRow[LibraryMOD.GetFieldName(dateBeginFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(strNotesFN)]== System.DBNull.Value)
{
  strNotes="";
}
else
{
  strNotes = (string)Available_CoursesDataRow[LibraryMOD.GetFieldName(strNotesFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)]== System.DBNull.Value)
{
  strUserCreate="";
}
else
{
  strUserCreate = (string)Available_CoursesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(dateCreateFN)]== System.DBNull.Value)
{
}
else
{
  dateCreate = (DateTime)Available_CoursesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)]== System.DBNull.Value)
{
  strUserSave="";
}
else
{
  strUserSave = (string)Available_CoursesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)]== System.DBNull.Value)
{
}
else
{
  dateLastSave = (DateTime)Available_CoursesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(strMachineFN)]== System.DBNull.Value)
{
  strMachine="";
}
else
{
  strMachine = (string)Available_CoursesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
}
if (Available_CoursesDataRow[LibraryMOD.GetFieldName(strNUserFN)]== System.DBNull.Value)
{
  strNUser="";
}
else
{
  strNUser = (string)Available_CoursesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
public int FindInMultiPKey(string PKstrCourse,int PKbyteClass,int PKbyteShift) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKstrCourse;
findTheseVals[1] = PKbyteClass;
findTheseVals[2] = PKbyteShift;
Available_CoursesDataRow = dsAvailable_Courses.Tables[TableName].Rows.Find(findTheseVals);
if  ((Available_CoursesDataRow !=null)) 
{
lngCurRow = dsAvailable_Courses.Tables[TableName].Rows.IndexOf(Available_CoursesDataRow);
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
  lngCurRow = dsAvailable_Courses.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsAvailable_Courses.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsAvailable_Courses.Tables[TableName].Rows.Count > 0) 
{
  Available_CoursesDataRow = dsAvailable_Courses.Tables[TableName].Rows[lngCurRow];
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
daAvailable_Courses.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAvailable_Courses.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daAvailable_Courses.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daAvailable_Courses.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
