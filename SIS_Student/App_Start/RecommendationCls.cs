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
public class Recommendation
{
//Creation Date: 05/04/2010 9:48:39 AM
//Programmer Name : Ihab Awad
//-----Decleration --------------
#region "Decleration"
private int m_intStudyYear; 
private int m_byteSemester; 
private int m_byteShift; 
private string m_strCourse;
private string m_strDesc;
private string m_lngStudentNumber; 
private int m_bytOrder; 
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
public int byteShift
{
get { return  m_byteShift; }
set {m_byteShift  = value ; }
}
public string strCourse
{
get { return  m_strCourse; }
set {m_strCourse  = value ; }
}

public string StrDesc
{
    get { return m_strDesc; }
    set { m_strDesc = value; }
} 
public string lngStudentNumber
{
get { return  m_lngStudentNumber; }
set {m_lngStudentNumber  = value ; }
}
public int bytOrder
{
get { return  m_bytOrder; }
set {m_bytOrder  = value ; }
}
#endregion
//'-----------------------------------------------------
public Recommendation()
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
public class RecommendationDAL : Recommendation
{
#region "Decleration"
private string m_TableName;
private string m_intStudyYearFN ;
private string m_byteSemesterFN ;
private string m_byteShiftFN ;
private string m_strCourseFN ;
private string m_lngStudentNumberFN ;
private string m_bytOrderFN ;
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
public string byteShiftFN 
{
get { return  m_byteShiftFN; }
set {m_byteShiftFN  = value ; }
}
public string strCourseFN 
{
get { return  m_strCourseFN; }
set {m_strCourseFN  = value ; }
}
public string lngStudentNumberFN 
{
get { return  m_lngStudentNumberFN; }
set {m_lngStudentNumberFN  = value ; }
}
public string bytOrderFN 
{
get { return  m_bytOrderFN; }
set {m_bytOrderFN  = value ; }
}
#endregion
//================End Properties ===================
public RecommendationDAL()
{
try
{
this.TableName = "Reg_Recommendation";
this.intStudyYearFN = m_TableName + ".intStudyYear";
this.byteSemesterFN = m_TableName + ".byteSemester";
this.byteShiftFN = m_TableName + ".byteShift";
this.strCourseFN = m_TableName + ".strCourse";
this.lngStudentNumberFN = m_TableName + ".lngStudentNumber";
this.bytOrderFN = m_TableName + ".bytOrder";
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
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + bytOrderFN;
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
sSQL += " , " + byteShiftFN;
sSQL += " , " + strCourseFN;
sSQL += " , " + lngStudentNumberFN;
sSQL += " , " + bytOrderFN;
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
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN) + "=@byteShift";
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN) + "=@lngStudentNumber";
sSQL += " , " + LibraryMOD.GetFieldName(bytOrderFN) + "=@bytOrder";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(lngStudentNumberFN)+"=@lngStudentNumber";
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
sSQL += " , " + LibraryMOD.GetFieldName(byteShiftFN);
sSQL += " , " + LibraryMOD.GetFieldName(strCourseFN);
sSQL += " , " + LibraryMOD.GetFieldName(lngStudentNumberFN);
sSQL += " , " + LibraryMOD.GetFieldName(bytOrderFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @intStudyYear";
sSQL += " ,@byteSemester";
sSQL += " ,@byteShift";
sSQL += " ,@strCourse";
sSQL += " ,@lngStudentNumber";
sSQL += " ,@bytOrder";
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
sSQL += LibraryMOD.GetFieldName(lngStudentNumberFN)+"=@lngStudentNumber";
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
public List< Recommendation> GetRecommendation(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Recommendation
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
List<Recommendation> results = new List<Recommendation>();
try
{
//Default Value
Recommendation myRecommendation = new Recommendation();
if (isDeafaultIncluded)
{
//Change the code here
myRecommendation.lngStudentNumber = "Select Student";

results.Add(myRecommendation);
}
while (reader.Read())
{
myRecommendation = new Recommendation();
if (reader[LibraryMOD.GetFieldName(intStudyYearFN)].Equals(DBNull.Value))
{
myRecommendation.intStudyYear = 0;
}
else
{
myRecommendation.intStudyYear = int.Parse(reader[LibraryMOD.GetFieldName( intStudyYearFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteSemesterFN)].Equals(DBNull.Value))
{
myRecommendation.byteSemester = 0;
}
else
{
myRecommendation.byteSemester = int.Parse(reader[LibraryMOD.GetFieldName( byteSemesterFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteShiftFN)].Equals(DBNull.Value))
{
myRecommendation.byteShift = 0;
}
else
{
myRecommendation.byteShift = int.Parse(reader[LibraryMOD.GetFieldName( byteShiftFN) ].ToString());
}
myRecommendation.strCourse =reader[LibraryMOD.GetFieldName( strCourseFN) ].ToString();
myRecommendation.lngStudentNumber =reader[LibraryMOD.GetFieldName( lngStudentNumberFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(bytOrderFN)].Equals(DBNull.Value))
{
myRecommendation.bytOrder = 0;
}
else
{
myRecommendation.bytOrder = int.Parse(reader[LibraryMOD.GetFieldName( bytOrderFN) ].ToString());
}
 results.Add(myRecommendation);
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


public int UpdateRecommendation(InitializeModule.EnumCampus Campus, int iMode,int intStudyYear,int byteSemester,int byteShift,string strCourse,string lngStudentNumber,int bytOrder)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Recommendation theRecommendation = new Recommendation();
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
Cmd.Parameters.Add(new SqlParameter("@byteShift",byteShift));
Cmd.Parameters.Add(new SqlParameter("@strCourse",strCourse));
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber",lngStudentNumber));
Cmd.Parameters.Add(new SqlParameter("@bytOrder",bytOrder));
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
public int DeleteRecommendation(InitializeModule.EnumCampus Campus,string lngStudentNumber)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@lngStudentNumber", lngStudentNumber ));
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
DataTable dt = new DataTable("Recommendation");
DataView dv = new DataView();
List<Recommendation> myRecommendations = new List<Recommendation>();
try
{
myRecommendations = GetRecommendation(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("intStudyYear", Type.GetType("smallint"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("byteSemester", Type.GetType("smallint"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("byteShift", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myRecommendations.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myRecommendations[i].intStudyYear;
  dr[2] = myRecommendations[i].byteSemester;
  dr[3] = myRecommendations[i].byteShift;
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
myRecommendations.Clear();
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
sSQL += lngStudentNumberFN;
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


public DataSet Prepare_RecommendationReport(MirrorCLS myMirror)
{

    DataTable dt = new DataTable();
    DataTable dtMirror = new DataTable();
    DataTable dtMirror2 = new DataTable();

    DataRow dr;
    DataSet ds = new DataSet();
    try
    {
        DataColumn dc;

        //dc = new DataColumn("StudentID", Type.GetType("System.String"));
        //dtMirror.Columns.Add(dc);
        //dc = new DataColumn("Course", Type.GetType("System.String"));
        //dtMirror.Columns.Add(dc);
        //dc = new DataColumn("Grade", Type.GetType("System.String"));
        //dtMirror.Columns.Add(dc);

        //dc = new DataColumn("StudentID", Type.GetType("System.String"));
        //dtMirror2.Columns.Add(dc);
        //dc = new DataColumn("Course", Type.GetType("System.String"));
        //dtMirror2.Columns.Add(dc);
        //dc = new DataColumn("Grade", Type.GetType("System.String"));
        //dtMirror2.Columns.Add(dc);

        dc = new DataColumn("StudentID", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("iOrder", Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sCourse", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sDesc", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("bShift", Type.GetType("System.Int16"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sTimeFrom", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sTimeTo", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sDays", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("bClass", Type.GetType("System.Int16"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sLecturer", Type.GetType("System.String"));
        dt.Columns.Add(dc);

        //int iCount = myMirror.Mirror.Length;

        //int iCountMirror1 = 0;
        //int iCountMirror2 = 0;

        //if (iCount > 31)
        //{
        //    iCountMirror1 = 31;
        //    iCountMirror2 = iCount - iCountMirror1;
        //}
        //else
        //{
        //    iCountMirror1 = iCount;
        //    iCountMirror2 = 0;
        //}

        //for (int m = 0; m < iCountMirror1; m++)
        //{
        //    dr = dtMirror.NewRow();

        //    dr["StudentID"] = myMirror.StudentNumber;
        //    dr["Course"] = myMirror.Mirror[m].iOrder + ":" + myMirror.Mirror[m].sCourse;
        //    dr["Grade"] = myMirror.Mirror[m].sGrade;

        //    dtMirror.Rows.Add(dr);
        //}

        //for (int m = 0; m < iCountMirror2; m++)
        //{
        //    dr = dtMirror.NewRow();

        //    dr["StudentID"] = myMirror.StudentNumber;
        //    dr["Course"] = myMirror.Mirror[m].iOrder + ":" + myMirror.Mirror[m].sCourse;
        //    dr["Grade"] = myMirror.Mirror[m].sGrade;

        //    dtMirror2.Rows.Add(dr);
        //}

        int iRecommended = myMirror.Recommended.Count;

        for (int i = 0; i < iRecommended; i++)
        {
            dr = dt.NewRow();

            dr["StudentID"] = myMirror.StudentNumber;
            dr["iOrder"] = i + 1;

            dr["sCourse"] = myMirror.Recommended[i].sCourse;
            dr["sDesc"] = myMirror.Recommended[i].sDesc;
            dr["bShift"] = i;
            dr["sTimeFrom"] = GetString(i, "-");
            dr["sTimeTo"] = GetString(i, "-");
            if (myMirror.Recommended[i].isOver)
            {
                dr["sDays"] = i.ToString() + " " + "اخرى - Other";
            }
            else if (myMirror.Recommended[i].isLow)
            {
                dr["sDays"] = i.ToString() + " " + "ينصح بشدة - High";
            }
            else
            {
                dr["sDays"] = i.ToString() + " " + "ينصح به - Recommended";
            }
            dr["bClass"] = i;
            dr["sLecturer"] = GetString(i, "-");

            dt.Rows.Add(dr);
        }
        //Add 3 Empty Rows
        int iTimes = 0;
        for (int i = iRecommended; i < iRecommended + 2; i++)
        {
            dr = dt.NewRow();
            dr["StudentID"] = myMirror.StudentNumber;
            dr["iOrder"] = i + 1;

            iTimes += 1;
            dr["sCourse"] = GetString(iTimes, ".");
            dr["sDesc"] = GetString(iTimes, ".");

            dr["bShift"] = i;
            dr["sTimeFrom"] = GetString(i, "-");
            dr["sTimeTo"] = GetString(i, "-");
            dr["sDays"] = GetString(iTimes - 1, ".");
            dr["bClass"] = i;
            dr["sLecturer"] = GetString(i, "-"); ;

            dt.Rows.Add(dr);
            //Collect Additional Times
        }

        dt.TableName = "Recommended";
        dt.AcceptChanges();
        ds.Tables.Add(dt);

        //dtMirror.TableName = "Mirror";
        //dtMirror.AcceptChanges();
        //ds.Tables.Add(dtMirror);

        //dtMirror2.TableName = "Mirror2";
        //dtMirror2.AcceptChanges();
        //ds.Tables.Add(dtMirror2);

    }
    catch (Exception exp)
    {
        Console.WriteLine("{0} Exception caught.", exp);
    }
    finally
    {

    }
    return ds;
}
public DataSet Prepare_RecommendationReport(string sID)
{

    DataTable dt = new DataTable();
    DataTable dtMirror = new DataTable();
    DataTable dtMirror2 = new DataTable();

    DataRow dr;
    DataSet ds = new DataSet();
    try
    {
        DataColumn dc;

        dc = new DataColumn("StudentID", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("iOrder", Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sCourse", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sDesc", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("bShift", Type.GetType("System.Int16"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sTimeFrom", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sTimeTo", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sDays", Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("bClass", Type.GetType("System.Int16"));
        dt.Columns.Add(dc);
        dc = new DataColumn("sLecturer", Type.GetType("System.String"));
        dt.Columns.Add(dc);

       
                
        
        for (int i = 0; i < 7 ; i++)
        {
            dr = dt.NewRow();
            dr["StudentID"] = sID.Replace(".", "");
            dr["iOrder"] = i + 1;

            dr["sCourse"] = "-";
            dr["sDesc"] = "-";

            dr["bShift"] = 0;
            dr["sTimeFrom"] = "-";
            dr["sTimeTo"] = "-";
            dr["sDays"] = "-";
            dr["bClass"] = 0;
            dr["sLecturer"] = "-";

            dt.Rows.Add(dr);
            //Collect Additional Times
        }

        dt.TableName = "Recommended";
        dt.AcceptChanges();
        ds.Tables.Add(dt);

        //dtMirror.TableName = "Mirror";
        //dtMirror.AcceptChanges();
        //ds.Tables.Add(dtMirror);

        //dtMirror2.TableName = "Mirror2";
        //dtMirror2.AcceptChanges();
        //ds.Tables.Add(dtMirror2);

    }
    catch (Exception exp)
    {
        Console.WriteLine("{0} Exception caught.", exp);
    }
    finally
    {

    }
    return ds;
}
private string GetString(int i, string s)
{
    string sValue = "";
    for (int j = 0; j <= i; j++)
    {
        sValue += s;
    }
    return sValue;
}
    //end class tow

}
public class RecommendationCls : RecommendationDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daRecommendation;
private DataSet m_dsRecommendation;
public DataRow RecommendationDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsRecommendation
{
get { return m_dsRecommendation ; }
set { m_dsRecommendation = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public RecommendationCls()
{
try
{
dsRecommendation= new DataSet();

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
public virtual SqlDataAdapter GetRecommendationDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daRecommendation = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daRecommendation);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daRecommendation.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daRecommendation;
}
public virtual SqlDataAdapter GetRecommendationDataAdapter(SqlConnection con)  
{
try
{
daRecommendation = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daRecommendation.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdRecommendation;
cmdRecommendation = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, "lngStudentNumber" );
daRecommendation.SelectCommand = cmdRecommendation;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdRecommendation = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdRecommendation.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdRecommendation.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdRecommendation.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdRecommendation.Parameters.Add("@strCourse", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCourseFN));
cmdRecommendation.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdRecommendation.Parameters.Add("@bytOrder", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytOrderFN));


Parmeter = cmdRecommendation.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngStudentNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daRecommendation.UpdateCommand = cmdRecommendation;
daRecommendation.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdRecommendation = new SqlCommand(GetInsertCommand(), con);
cmdRecommendation.Parameters.Add("@intStudyYear", SqlDbType.Int,2, LibraryMOD.GetFieldName(intStudyYearFN));
cmdRecommendation.Parameters.Add("@byteSemester", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteSemesterFN));
cmdRecommendation.Parameters.Add("@byteShift", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteShiftFN));
cmdRecommendation.Parameters.Add("@strCourse", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(strCourseFN));
cmdRecommendation.Parameters.Add("@lngStudentNumber", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(lngStudentNumberFN));
cmdRecommendation.Parameters.Add("@bytOrder", SqlDbType.Int,2, LibraryMOD.GetFieldName(bytOrderFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daRecommendation.InsertCommand =cmdRecommendation;
daRecommendation.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdRecommendation = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdRecommendation.Parameters.Add("@lngStudentNumber", SqlDbType.Int, 4, LibraryMOD.GetFieldName(lngStudentNumberFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daRecommendation.DeleteCommand =cmdRecommendation;
daRecommendation.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daRecommendation.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daRecommendation;
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
dr = dsRecommendation.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
dr[LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
dr[LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
dr[LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
dr[LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
dr[LibraryMOD.GetFieldName(bytOrderFN)]=bytOrder;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsRecommendation.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsRecommendation.Tables[TableName].Select(LibraryMOD.GetFieldName(lngStudentNumberFN)  + "=" + lngStudentNumber);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(intStudyYearFN)]=intStudyYear;
drAry[0][LibraryMOD.GetFieldName(byteSemesterFN)]=byteSemester;
drAry[0][LibraryMOD.GetFieldName(byteShiftFN)]=byteShift;
drAry[0][LibraryMOD.GetFieldName(strCourseFN)]=strCourse;
drAry[0][LibraryMOD.GetFieldName(lngStudentNumberFN)]=lngStudentNumber;
drAry[0][LibraryMOD.GetFieldName(bytOrderFN)]=bytOrder;
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
public int CommitRecommendation()  
{
//CommitRecommendation= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daRecommendation.Update(dsRecommendation, TableName);
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
FindInMultiPKey(lngStudentNumber);
if (( RecommendationDataRow != null)) 
{
RecommendationDataRow.Delete();
CommitRecommendation();
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
if (RecommendationDataRow[LibraryMOD.GetFieldName(intStudyYearFN)]== System.DBNull.Value)
{
  intStudyYear=0;
}
else
{
  intStudyYear = (int)RecommendationDataRow[LibraryMOD.GetFieldName(intStudyYearFN)];
}
if (RecommendationDataRow[LibraryMOD.GetFieldName(byteSemesterFN)]== System.DBNull.Value)
{
  byteSemester=0;
}
else
{
  byteSemester = (int)RecommendationDataRow[LibraryMOD.GetFieldName(byteSemesterFN)];
}
if (RecommendationDataRow[LibraryMOD.GetFieldName(byteShiftFN)]== System.DBNull.Value)
{
  byteShift=0;
}
else
{
  byteShift = (int)RecommendationDataRow[LibraryMOD.GetFieldName(byteShiftFN)];
}
if (RecommendationDataRow[LibraryMOD.GetFieldName(strCourseFN)]== System.DBNull.Value)
{
  strCourse="";
}
else
{
  strCourse = (string)RecommendationDataRow[LibraryMOD.GetFieldName(strCourseFN)];
}
if (RecommendationDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)]== System.DBNull.Value)
{
  lngStudentNumber="";
}
else
{
  lngStudentNumber = (string)RecommendationDataRow[LibraryMOD.GetFieldName(lngStudentNumberFN)];
}
if (RecommendationDataRow[LibraryMOD.GetFieldName(bytOrderFN)]== System.DBNull.Value)
{
  bytOrder=0;
}
else
{
  bytOrder = (int)RecommendationDataRow[LibraryMOD.GetFieldName(bytOrderFN)];
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
public int FindInMultiPKey(string PKlngStudentNumber) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKlngStudentNumber;
RecommendationDataRow = dsRecommendation.Tables[TableName].Rows.Find(findTheseVals);
if  ((RecommendationDataRow !=null)) 
{
lngCurRow = dsRecommendation.Tables[TableName].Rows.IndexOf(RecommendationDataRow);
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
  lngCurRow = dsRecommendation.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsRecommendation.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsRecommendation.Tables[TableName].Rows.Count > 0) 
{
  RecommendationDataRow = dsRecommendation.Tables[TableName].Rows[lngCurRow];
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
daRecommendation.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daRecommendation.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daRecommendation.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daRecommendation.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
