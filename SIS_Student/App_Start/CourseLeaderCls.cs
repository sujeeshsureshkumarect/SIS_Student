using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class CourseLeader
{
//Creation Date: 10/09/2020 1:01:58 PM
//Programmer Name : Bahaa Addin Ghaleb
//-----Decleration --------------
#region "Decleration"
private int m_AcademicYear; 
private int m_SemesterID; 
private string m_CourseID; 
private int m_CourseLeaderID; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 
private string m_TemplateCourse; 
private int m_MoodleCourseNo; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int AcademicYear
{
get { return  m_AcademicYear; }
set {m_AcademicYear  = value ; }
}
public int SemesterID
{
get { return  m_SemesterID; }
set {m_SemesterID  = value ; }
}
public string CourseID
{
get { return  m_CourseID; }
set {m_CourseID  = value ; }
}
public int CourseLeaderID
{
get { return  m_CourseLeaderID; }
set {m_CourseLeaderID  = value ; }
}
public int CreationUserID
{
get { return  m_CreationUserID; }
set {m_CreationUserID  = value ; }
}
public DateTime CreationDate
{
get { return  m_CreationDate; }
set {m_CreationDate  = value ; }
}
public int LastUpdateUserID
{
get { return  m_LastUpdateUserID; }
set {m_LastUpdateUserID  = value ; }
}
public DateTime LastUpdateDate
{
get { return  m_LastUpdateDate; }
set {m_LastUpdateDate  = value ; }
}
public string PCName
{
get { return  m_PCName; }
set {m_PCName  = value ; }
}
public string NetUserName
{
get { return  m_NetUserName; }
set {m_NetUserName  = value ; }
}
public string TemplateCourse
{
get { return  m_TemplateCourse; }
set {m_TemplateCourse  = value ; }
}
public int MoodleCourseNo
{
get { return  m_MoodleCourseNo; }
set {m_MoodleCourseNo  = value ; }
}
//'-----------------------------------------------------
#endregion
//'-----------------------------------------------------
public CourseLeader()
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
public class CourseLeaderDAL : CourseLeader
{
#region "Decleration"
private string m_TableName;
private string m_AcademicYearFN ;
private string m_SemesterIDFN ;
private string m_CourseIDFN ;
private string m_CourseLeaderIDFN ;
private string m_CreationUserIDFN ;
private string m_CreationDateFN ;
private string m_LastUpdateUserIDFN ;
private string m_LastUpdateDateFN ;
private string m_PCNameFN ;
private string m_NetUserNameFN ;
private string m_TemplateCourseFN ;
private string m_MoodleCourseNoFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string AcademicYearFN 
{
get { return  m_AcademicYearFN; }
set {m_AcademicYearFN  = value ; }
}
public string SemesterIDFN 
{
get { return  m_SemesterIDFN; }
set {m_SemesterIDFN  = value ; }
}
public string CourseIDFN 
{
get { return  m_CourseIDFN; }
set {m_CourseIDFN  = value ; }
}
public string CourseLeaderIDFN 
{
get { return  m_CourseLeaderIDFN; }
set {m_CourseLeaderIDFN  = value ; }
}
public string CreationUserIDFN 
{
get { return  m_CreationUserIDFN; }
set {m_CreationUserIDFN  = value ; }
}
public string CreationDateFN 
{
get { return  m_CreationDateFN; }
set {m_CreationDateFN  = value ; }
}
public string LastUpdateUserIDFN 
{
get { return  m_LastUpdateUserIDFN; }
set {m_LastUpdateUserIDFN  = value ; }
}
public string LastUpdateDateFN 
{
get { return  m_LastUpdateDateFN; }
set {m_LastUpdateDateFN  = value ; }
}
public string PCNameFN 
{
get { return  m_PCNameFN; }
set {m_PCNameFN  = value ; }
}
public string NetUserNameFN 
{
get { return  m_NetUserNameFN; }
set {m_NetUserNameFN  = value ; }
}
public string TemplateCourseFN 
{
get { return  m_TemplateCourseFN; }
set {m_TemplateCourseFN  = value ; }
}
public string MoodleCourseNoFN 
{
get { return  m_MoodleCourseNoFN; }
set {m_MoodleCourseNoFN  = value ; }
}
#endregion
//================End Properties ===================
public CourseLeaderDAL()
{
try
{
this.TableName = "Reg_CourseLeader";
this.AcademicYearFN = m_TableName + ".AcademicYear";
this.SemesterIDFN = m_TableName + ".SemesterID";
this.CourseIDFN = m_TableName + ".CourseID";
this.CourseLeaderIDFN = m_TableName + ".CourseLeaderID";
this.CreationUserIDFN = m_TableName + ".CreationUserID";
this.CreationDateFN = m_TableName + ".CreationDate";
this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
this.PCNameFN = m_TableName + ".PCName";
this.NetUserNameFN = m_TableName + ".NetUserName";
this.TemplateCourseFN = m_TableName + ".TemplateCourse";
this.MoodleCourseNoFN = m_TableName + ".MoodleCourseNo";
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
sSQL +=AcademicYearFN;
sSQL += " , " + SemesterIDFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + CourseLeaderIDFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += " , " + TemplateCourseFN;
sSQL += " , " + MoodleCourseNoFN;
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
//-----GetListSQl Function ---------------------------------
public string  GetListSQL(string sCondition) 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=AcademicYearFN;
sSQL += " , " + SemesterIDFN;
sSQL += " , " + CourseIDFN;
sSQL += "  FROM " + m_TableName;
sSQL += " WHERE 1=1";
if (sCondition != "")
{
    sSQL += sCondition;
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
//-----Get GetSelectCommand Function -----------------------
public string GetSelectCommand() 
{
string sSQL= "";
try
{
sSQL = "SELECT ";
sSQL +=AcademicYearFN;
sSQL += " , " + SemesterIDFN;
sSQL += " , " + CourseIDFN;
sSQL += " , " + CourseLeaderIDFN;
sSQL += " , " + CreationUserIDFN;
sSQL += " , " + CreationDateFN;
sSQL += " , " + LastUpdateUserIDFN;
sSQL += " , " + LastUpdateDateFN;
sSQL += " , " + PCNameFN;
sSQL += " , " + NetUserNameFN;
sSQL += " , " + TemplateCourseFN;
sSQL += " , " + MoodleCourseNoFN;
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
sSQL += LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
sSQL += " , " + LibraryMOD.GetFieldName(SemesterIDFN) + "=@SemesterID";
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN) + "=@CourseID";
sSQL += " , " + LibraryMOD.GetFieldName(CourseLeaderIDFN) + "=@CourseLeaderID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
sSQL += " , " + LibraryMOD.GetFieldName(TemplateCourseFN) + "=@TemplateCourse";
sSQL += " , " + LibraryMOD.GetFieldName(MoodleCourseNoFN) + "=@MoodleCourseNo";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(AcademicYearFN)+"=@AcademicYear";
sSQL +=  " And " + LibraryMOD.GetFieldName(SemesterIDFN)+"=@SemesterID";
sSQL +=  " And " + LibraryMOD.GetFieldName(CourseIDFN)+"=@CourseID";
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
sSQL +=LibraryMOD.GetFieldName(AcademicYearFN);
sSQL += " , " + LibraryMOD.GetFieldName(SemesterIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CourseIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CourseLeaderIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(TemplateCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(MoodleCourseNoFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @AcademicYear";
sSQL += " ,@SemesterID";
sSQL += " ,@CourseID";
sSQL += " ,@CourseLeaderID";
sSQL += " ,@CreationUserID";
sSQL += " ,@CreationDate";
sSQL += " ,@LastUpdateUserID";
sSQL += " ,@LastUpdateDate";
sSQL += " ,@PCName";
sSQL += " ,@NetUserName";
sSQL += " ,@TemplateCourse";
sSQL += " ,@MoodleCourseNo";
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
sSQL += LibraryMOD.GetFieldName(AcademicYearFN)+"=@AcademicYear";
sSQL +=  " And " +  LibraryMOD.GetFieldName(SemesterIDFN)+"=@SemesterID";
sSQL +=  " And " +  LibraryMOD.GetFieldName(CourseIDFN)+"=@CourseID";
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
public List< CourseLeader> GetCourseLeader(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the CourseLeader
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
List<CourseLeader> results = new List<CourseLeader>();
try
{
//Default Value
CourseLeader myCourseLeader = new CourseLeader();
if (isDeafaultIncluded)
{
//Change the code here
myCourseLeader.AcademicYear = 0;
myCourseLeader.SemesterID = 0;
myCourseLeader.CourseID = "";
myCourseLeader.CourseID = "Select CourseLeader ...";
results.Add(myCourseLeader);
}
while (reader.Read())
{
myCourseLeader = new CourseLeader();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myCourseLeader.AcademicYear = 0;
}
else
{
myCourseLeader.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterIDFN)].Equals(DBNull.Value))
{
myCourseLeader.SemesterID = 0;
}
else
{
myCourseLeader.SemesterID = int.Parse(reader[LibraryMOD.GetFieldName( SemesterIDFN) ].ToString());
}
myCourseLeader.CourseID =reader[LibraryMOD.GetFieldName( CourseIDFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(CourseLeaderIDFN)].Equals(DBNull.Value))
{
myCourseLeader.CourseLeaderID = 0;
}
else
{
myCourseLeader.CourseLeaderID = int.Parse(reader[LibraryMOD.GetFieldName( CourseLeaderIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
{
myCourseLeader.CreationUserID = 0;
}
else
{
myCourseLeader.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
{
myCourseLeader.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
{
myCourseLeader.LastUpdateUserID = 0;
}
else
{
myCourseLeader.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
}
if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
{
myCourseLeader.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
}
myCourseLeader.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
myCourseLeader.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
myCourseLeader.TemplateCourse =reader[LibraryMOD.GetFieldName( TemplateCourseFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(MoodleCourseNoFN)].Equals(DBNull.Value))
{
myCourseLeader.MoodleCourseNo = 0;
}
else
{
myCourseLeader.MoodleCourseNo = int.Parse(reader[LibraryMOD.GetFieldName( MoodleCourseNoFN) ].ToString());
}
 results.Add(myCourseLeader);
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
public List< CourseLeader > GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
{
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string sSQL = GetListSQL(sCondition);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<CourseLeader> results = new List<CourseLeader>();
try
{
//Default Value
CourseLeader myCourseLeader= new CourseLeader();
if (isDeafaultIncluded)
 {
//Change the code here
 myCourseLeader.AcademicYear = -1;
 myCourseLeader.SemesterID = -1;
 myCourseLeader.CourseID = "Select Course";
    
results.Add(myCourseLeader);
 }
while (reader.Read())
{
myCourseLeader = new CourseLeader();
if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
{
myCourseLeader.AcademicYear = 0;
}
else
{
myCourseLeader.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SemesterIDFN)].Equals(DBNull.Value))
{
myCourseLeader.SemesterID = 0;
}
else
{
myCourseLeader.SemesterID = int.Parse(reader[LibraryMOD.GetFieldName( SemesterIDFN) ].ToString());
}
myCourseLeader.CourseID =reader[LibraryMOD.GetFieldName( CourseIDFN) ].ToString();
 results.Add(myCourseLeader);
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
public int UpdateCourseLeader(InitializeModule.EnumCampus Campus, int iMode,int AcademicYear,int SemesterID,string CourseID,int CourseLeaderID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName,string TemplateCourse,int MoodleCourseNo)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
CourseLeader theCourseLeader = new CourseLeader();
//'Updates the  table
switch(iMode) 
  {
  case  (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
      sql = GetUpdateCommand();
      break ;
  case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
      sql = GetInsertCommand();
      break ;
  }
SqlCommand Cmd = new SqlCommand(sql, Conn);
Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
Cmd.Parameters.Add(new SqlParameter("@SemesterID",SemesterID));
Cmd.Parameters.Add(new SqlParameter("@CourseID",CourseID));
Cmd.Parameters.Add(new SqlParameter("@CourseLeaderID",CourseLeaderID));
Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
Cmd.Parameters.Add(new SqlParameter("@TemplateCourse",TemplateCourse));
Cmd.Parameters.Add(new SqlParameter("@MoodleCourseNo",MoodleCourseNo));
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
public int DeleteCourseLeader(InitializeModule.EnumCampus Campus,string AcademicYear,string SemesterID,string CourseID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear ));
Cmd.Parameters.Add(new SqlParameter("@SemesterID", SemesterID ));
Cmd.Parameters.Add(new SqlParameter("@CourseID", CourseID ));
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
DataTable dt = new DataTable("CourseLeader");
DataView dv = new DataView();
List<CourseLeader> myCourseLeaders = new List<CourseLeader>();
try
{
myCourseLeaders = GetCourseLeader(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col0= new DataColumn("AcademicYear", Type.GetType("int"));
dt.Columns.Add(col0 );
DataColumn col1= new DataColumn("SemesterID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("CourseID", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
dt.Constraints.Add(new UniqueConstraint(col0));
dt.Constraints.Add(new UniqueConstraint(col1));
dt.Constraints.Add(new UniqueConstraint(col2));

DataRow dr;
for (int i = 0; i < myCourseLeaders.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myCourseLeaders[i].AcademicYear;
  dr[2] = myCourseLeaders[i].SemesterID;
  dr[3] = myCourseLeaders[i].CourseID;
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
myCourseLeaders.Clear();
}
 return dv;
}
public Boolean IsCourseExist(string sCourse, int iyear, int isem)
{
    String sSQL;
    Boolean isExist = false;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew );
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += CourseIDFN ;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + CourseIDFN + "='" + sCourse + "'";
        sSQL += "  AND " + AcademicYearFN  + "=" + iyear;
        sSQL += "  AND " + SemesterIDFN  + "=" + isem;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            isExist = true;
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

    return isExist;
}
//'-------Populate  -----------------------------
public DataTable Populate(SqlConnection con) 
{
string sSQL =""; 
DataTable table = new DataTable();
try
{
sSQL = "SELECT";
sSQL += AcademicYearFN;
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
public class CourseLeaderCls : CourseLeaderDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daCourseLeader;
private DataSet m_dsCourseLeader;
public DataRow CourseLeaderDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsCourseLeader
{
get { return m_dsCourseLeader ; }
set { m_dsCourseLeader = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public CourseLeaderCls()
{
try
{
dsCourseLeader= new DataSet();

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
public virtual SqlDataAdapter GetCourseLeaderDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daCourseLeader = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCourseLeader);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daCourseLeader.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCourseLeader;
}
public virtual SqlDataAdapter GetCourseLeaderDataAdapter(SqlConnection con)  
{
try
{
daCourseLeader = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daCourseLeader.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdCourseLeader;
cmdCourseLeader = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, "AcademicYear" );
//'cmdRolePermission.Parameters.Add("@SemesterID", SqlDbType.Int, 4, "SemesterID" );
//'cmdRolePermission.Parameters.Add("@CourseID", SqlDbType.Int, 4, "CourseID" );
daCourseLeader.SelectCommand = cmdCourseLeader;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdCourseLeader = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
//cmdCourseLeader.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
//cmdCourseLeader.Parameters.Add("@SemesterID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterIDFN));
//cmdCourseLeader.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdCourseLeader.Parameters.Add("@CourseLeaderID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CourseLeaderIDFN));
cmdCourseLeader.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdCourseLeader.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdCourseLeader.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdCourseLeader.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdCourseLeader.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdCourseLeader.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
cmdCourseLeader.Parameters.Add("@TemplateCourse", SqlDbType.NVarChar,44, LibraryMOD.GetFieldName(TemplateCourseFN));
cmdCourseLeader.Parameters.Add("@MoodleCourseNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(MoodleCourseNoFN));


Parmeter = cmdCourseLeader.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
Parmeter = cmdCourseLeader.Parameters.Add("@SemesterID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterIDFN));
Parmeter = cmdCourseLeader.Parameters.Add("@CourseID", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(CourseIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daCourseLeader.UpdateCommand = cmdCourseLeader;
daCourseLeader.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------------------------------------------------------
//'/INSERT COMMAND
 cmdCourseLeader = new SqlCommand(GetInsertCommand(), con);
cmdCourseLeader.Parameters.Add("@AcademicYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(AcademicYearFN));
cmdCourseLeader.Parameters.Add("@SemesterID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SemesterIDFN));
cmdCourseLeader.Parameters.Add("@CourseID", SqlDbType.NVarChar,24, LibraryMOD.GetFieldName(CourseIDFN));
cmdCourseLeader.Parameters.Add("@CourseLeaderID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CourseLeaderIDFN));
cmdCourseLeader.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdCourseLeader.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdCourseLeader.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdCourseLeader.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdCourseLeader.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdCourseLeader.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
cmdCourseLeader.Parameters.Add("@TemplateCourse", SqlDbType.NVarChar,44, LibraryMOD.GetFieldName(TemplateCourseFN));
cmdCourseLeader.Parameters.Add("@MoodleCourseNo", SqlDbType.Int,4, LibraryMOD.GetFieldName(MoodleCourseNoFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daCourseLeader.InsertCommand =cmdCourseLeader;
daCourseLeader.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdCourseLeader = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdCourseLeader.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
Parmeter = cmdCourseLeader.Parameters.Add("@SemesterID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterIDFN));
Parmeter = cmdCourseLeader.Parameters.Add("@CourseID", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(CourseIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daCourseLeader.DeleteCommand =cmdCourseLeader;
daCourseLeader.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daCourseLeader.UpdateBatchSize = ECTGlobalDll.InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daCourseLeader;
}
//'-------SaveData  -----------------------------
public int SaveData(int lFormMode  )  
{
//SaveData= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
switch (lFormMode)
{
case (int)ECTGlobalDll.InitializeModule.enumModes.NewMode:
 DataRow  dr = default(DataRow); 
dr = dsCourseLeader.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
dr[LibraryMOD.GetFieldName(SemesterIDFN)]=SemesterID;
dr[LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
dr[LibraryMOD.GetFieldName(CourseLeaderIDFN)]=CourseLeaderID;
dr[LibraryMOD.GetFieldName(TemplateCourseFN)]=TemplateCourse;
dr[LibraryMOD.GetFieldName(MoodleCourseNoFN)]=MoodleCourseNo;
dsCourseLeader.Tables[TableName].Rows.Add(dr);
break;
case (int)ECTGlobalDll.InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsCourseLeader.Tables[TableName].Select(LibraryMOD.GetFieldName(AcademicYearFN)  + "=" + AcademicYear  + " AND " + LibraryMOD.GetFieldName(SemesterIDFN) + "=" + SemesterID  + " AND " + LibraryMOD.GetFieldName(CourseIDFN) + "=" + CourseID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)]=AcademicYear;
drAry[0][LibraryMOD.GetFieldName(SemesterIDFN)]=SemesterID;
drAry[0][LibraryMOD.GetFieldName(CourseIDFN)]=CourseID;
drAry[0][LibraryMOD.GetFieldName(CourseLeaderIDFN)]=CourseLeaderID;
drAry[0][LibraryMOD.GetFieldName(TemplateCourseFN)]=TemplateCourse;
drAry[0][LibraryMOD.GetFieldName(MoodleCourseNoFN)]=MoodleCourseNo;
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
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------Commit  -----------------------------
public int CommitCourseLeader()  
{
//CommitCourseLeader= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daCourseLeader.Update(dsCourseLeader, TableName);
//'Sent Update to database.
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------DeleteRow  -----------------------------
public int DeleteRow() 
{
//DeleteRow= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
FindInMultiPKey(AcademicYear,SemesterID,CourseID);
if (( CourseLeaderDataRow != null)) 
{
CourseLeaderDataRow.Delete();
CommitCourseLeader();
if (MoveNext() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
#endregion
//'-------SynchronizeDataRowToClass  -----------------------------
private int SynchronizeDataRowToClass()  
{
try
{
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(AcademicYearFN)]== System.DBNull.Value)
{
  AcademicYear=0;
}
else
{
  AcademicYear = (int)CourseLeaderDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(SemesterIDFN)]== System.DBNull.Value)
{
  SemesterID=0;
}
else
{
  SemesterID = (int)CourseLeaderDataRow[LibraryMOD.GetFieldName(SemesterIDFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(CourseIDFN)]== System.DBNull.Value)
{
  CourseID="";
}
else
{
  CourseID = (string)CourseLeaderDataRow[LibraryMOD.GetFieldName(CourseIDFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(CourseLeaderIDFN)]== System.DBNull.Value)
{
  CourseLeaderID=0;
}
else
{
  CourseLeaderID = (int)CourseLeaderDataRow[LibraryMOD.GetFieldName(CourseLeaderIDFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)CourseLeaderDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)CourseLeaderDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)CourseLeaderDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)CourseLeaderDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)CourseLeaderDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)CourseLeaderDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(TemplateCourseFN)]== System.DBNull.Value)
{
  TemplateCourse="";
}
else
{
  TemplateCourse = (string)CourseLeaderDataRow[LibraryMOD.GetFieldName(TemplateCourseFN)];
}
if (CourseLeaderDataRow[LibraryMOD.GetFieldName(MoodleCourseNoFN)]== System.DBNull.Value)
{
  MoodleCourseNo=0;
}
else
{
  MoodleCourseNo = (int)CourseLeaderDataRow[LibraryMOD.GetFieldName(MoodleCourseNoFN)];
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------FindInMultiPKey  -----------------------------
public int FindInMultiPKey(int PKAcademicYear,int PKSemesterID,string PKCourseID) 
{
//FindInMultiPKey= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKAcademicYear;
findTheseVals[1] = PKSemesterID;
findTheseVals[2] = PKCourseID;
CourseLeaderDataRow = dsCourseLeader.Tables[TableName].Rows.Find(findTheseVals);
if  ((CourseLeaderDataRow !=null)) 
{
lngCurRow = dsCourseLeader.Tables[TableName].Rows.IndexOf(CourseLeaderDataRow);
SynchronizeDataRowToClass();
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.FAIL_RET;
}
#region "Navigation"
//'-------MoveFirst  -----------------------------
public int  MoveFirst()  
{
//MoveFirst= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = 0;
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------MovePrevious  -----------------------------
public int  MovePrevious()  
{
//MovePrevious= InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Max(lngCurRow - 1, 0);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------MoveLast  -----------------------------
public int  MoveLast()  
{
//MoveLast= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = dsCourseLeader.Tables[TableName].Rows.Count - 1; //'Zero based index
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------MoveNext  -----------------------------
public int  MoveNext() 
{
//MoveNext= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  lngCurRow = Math.Min(lngCurRow + 1, dsCourseLeader.Tables[TableName].Rows.Count - 1);
  if (GoToCurrentRow() == ECTGlobalDll.InitializeModule.FAIL_RET ) return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------GoToCurrentRow  -----------------------------
public int  GoToCurrentRow() 
{
//GoToCurrentRow= ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
  if (lngCurRow >= 0 & dsCourseLeader.Tables[TableName].Rows.Count > 0) 
{
  CourseLeaderDataRow = dsCourseLeader.Tables[TableName].Rows[lngCurRow];
  SynchronizeDataRowToClass();
}
  else  return ECTGlobalDll.InitializeModule.FAIL_RET;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
#endregion
#region "Events"
//'-------AddDAEventHandler  -----------------------------
public int AddDAEventHandler()  
{
// ECTGlobalDll.InitializeModule.FAIL_RET;
try
{
daCourseLeader.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCourseLeader.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
}
//'-------RemoveDAEventHandler  -----------------------------
public int RemoveDAEventHandler() 
{
// InitializeModule.FAIL_RET;
try
{
daCourseLeader.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daCourseLeader.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return ECTGlobalDll.InitializeModule.SUCCESS_RET;
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
