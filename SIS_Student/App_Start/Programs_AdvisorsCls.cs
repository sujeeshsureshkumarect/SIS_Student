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
//using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class Programs_Advisors
{
//Creation Date: 13/04/2010 11:42:21 AM
//Programmer Name : ihab awad
//-----Decleration --------------
#region "Decleration"
private int m_iEntry; 
private string m_strProgram; 
private int m_iAdvisor;
private string m_sAdvisor; 
private int m_byteCategory; 
private string m_isWeekend; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int iEntry
{
get { return  m_iEntry; }
set {m_iEntry  = value ; }
}
public string strProgram
{
get { return  m_strProgram; }
set {m_strProgram  = value ; }
}
public int iAdvisor
{
get { return  m_iAdvisor; }
set {m_iAdvisor  = value ; }
}

public string SAdvisor
{
    get { return m_sAdvisor; }
    set { m_sAdvisor = value; }
}
public int byteCategory
{
get { return  m_byteCategory; }
set {m_byteCategory  = value ; }
}
public string isWeekend
{
get { return  m_isWeekend; }
set {m_isWeekend  = value ; }
}
#endregion
//'-----------------------------------------------------
public Programs_Advisors()
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
public class Programs_AdvisorsDAL : Programs_Advisors
{
#region "Decleration"
private string m_TableName;
private string m_iEntryFN ;
private string m_strProgramFN ;
private string m_iAdvisorFN ;
private string m_byteCategoryFN ;
private string m_isWeekendFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string iEntryFN 
{
get { return  m_iEntryFN; }
set {m_iEntryFN  = value ; }
}
public string strProgramFN 
{
get { return  m_strProgramFN; }
set {m_strProgramFN  = value ; }
}
public string iAdvisorFN 
{
get { return  m_iAdvisorFN; }
set {m_iAdvisorFN  = value ; }
}
public string byteCategoryFN 
{
get { return  m_byteCategoryFN; }
set {m_byteCategoryFN  = value ; }
}
public string isWeekendFN 
{
get { return  m_isWeekendFN; }
set {m_isWeekendFN  = value ; }
}
#endregion
//================End Properties ===================
public Programs_AdvisorsDAL()
{
try
{
this.TableName = "Reg_Programs_Advisors";
this.iEntryFN = m_TableName + ".iEntry";
this.strProgramFN = m_TableName + ".strProgram";
this.iAdvisorFN = m_TableName + ".iAdvisor";
this.byteCategoryFN = m_TableName + ".byteCategory";
this.isWeekendFN = m_TableName + ".isWeekend";
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
sSQL +=iEntryFN;
sSQL += " , " + strProgramFN;
sSQL += " , " + iAdvisorFN;
sSQL += " , " + byteCategoryFN;
sSQL += " , " + isWeekendFN;
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
sSQL +=iEntryFN;
sSQL += " , " + strProgramFN;
sSQL += " , " + iAdvisorFN;
sSQL += " , " + byteCategoryFN;
sSQL += " , " + isWeekendFN;
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
sSQL += LibraryMOD.GetFieldName(iEntryFN) + "=@iEntry";
sSQL += " , " + LibraryMOD.GetFieldName(strProgramFN) + "=@strProgram";
sSQL += " , " + LibraryMOD.GetFieldName(iAdvisorFN) + "=@iAdvisor";
sSQL += " , " + LibraryMOD.GetFieldName(byteCategoryFN) + "=@byteCategory";
sSQL += " , " + LibraryMOD.GetFieldName(isWeekendFN) + "=@isWeekend";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(iEntryFN)+"=@iEntry";
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
sSQL +=LibraryMOD.GetFieldName(iEntryFN);
sSQL += " , " + LibraryMOD.GetFieldName(strProgramFN);
sSQL += " , " + LibraryMOD.GetFieldName(iAdvisorFN);
sSQL += " , " + LibraryMOD.GetFieldName(byteCategoryFN);
sSQL += " , " + LibraryMOD.GetFieldName(isWeekendFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @iEntry";
sSQL += " ,@strProgram";
sSQL += " ,@iAdvisor";
sSQL += " ,@byteCategory";
sSQL += " ,@isWeekend";
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
sSQL += LibraryMOD.GetFieldName(iEntryFN)+"=@iEntry";
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
public List< Programs_Advisors> GetPrograms_Advisors(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Programs_Advisors
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
List<Programs_Advisors> results = new List<Programs_Advisors>();
try
{
//Default Value
Programs_Advisors myPrograms_Advisors = new Programs_Advisors();
if (isDeafaultIncluded)
{
//Change the code here
myPrograms_Advisors.iEntry = 0;
myPrograms_Advisors.strProgram = "Select Programs_Advisors ...";
results.Add(myPrograms_Advisors);
}
while (reader.Read())
{
myPrograms_Advisors = new Programs_Advisors();
if (reader[LibraryMOD.GetFieldName(iEntryFN)].Equals(DBNull.Value))
{
myPrograms_Advisors.iEntry = 0;
}
else
{
myPrograms_Advisors.iEntry = int.Parse(reader[LibraryMOD.GetFieldName( iEntryFN) ].ToString());
}
myPrograms_Advisors.strProgram =reader[LibraryMOD.GetFieldName( strProgramFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(iAdvisorFN)].Equals(DBNull.Value))
{
myPrograms_Advisors.iAdvisor = 0;
}
else
{
myPrograms_Advisors.iAdvisor = int.Parse(reader[LibraryMOD.GetFieldName( iAdvisorFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(byteCategoryFN)].Equals(DBNull.Value))
{
myPrograms_Advisors.byteCategory = 0;
}
else
{
myPrograms_Advisors.byteCategory = int.Parse(reader[LibraryMOD.GetFieldName( byteCategoryFN) ].ToString());
}
myPrograms_Advisors.isWeekend =reader[LibraryMOD.GetFieldName( isWeekendFN) ].ToString();
 results.Add(myPrograms_Advisors);
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

public List<Programs_Advisors> GetPrograms_Advisors(InitializeModule.EnumCampus Campus, string sMajor)
{
    //' returns a list of Classes instances based on the
    //' data in the Programs_Advisors
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    
    string sSQL = "SELECT PA.iAdvisor, A.strLecturerDescEn AS sAdvisor, PA.byteCategory AS bCategory, S.strSpecialization";
    sSQL += " FROM Reg_Programs_Advisors AS PA INNER JOIN Reg_Lecturers AS A ON PA.iAdvisor = A.intLecturer INNER JOIN";
    sSQL += " Reg_Specializations AS S ON PA.strProgram = S.sAdvisingProgram";
    sSQL += " WHERE S.strSpecialization ='"+sMajor+"'";

    
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Programs_Advisors> results = new List<Programs_Advisors>();
    try
    {
        //Default Value
        Programs_Advisors myPrograms_Advisors = new Programs_Advisors();
        
        while (reader.Read())
        {
            myPrograms_Advisors = new Programs_Advisors();
            if (reader["iAdvisor"].Equals(DBNull.Value))
            {
                myPrograms_Advisors.iAdvisor = 0;
            }
            else
            {
                myPrograms_Advisors.iAdvisor = int.Parse(reader["iAdvisor"].ToString());
            }

            myPrograms_Advisors.SAdvisor = reader["sAdvisor"].ToString();

            if (reader["bCategory"].Equals(DBNull.Value))
            {
                myPrograms_Advisors.byteCategory = 0;
            }
            else
            {
                myPrograms_Advisors.byteCategory = byte.Parse(reader["bCategory"].ToString());
            }
            
            results.Add(myPrograms_Advisors);
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

public List<Programs_Advisors> GetPrograms_Advisors(InitializeModule.EnumCampus Campus,string  sDegree, string sMajor)
{
    //' returns a list of Classes instances based on the
    //' data in the Programs_Advisors
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

    string sSQL = "SELECT PA.iAdvisor, A.strLecturerDescEn AS sAdvisor, PA.byteCategory AS bCategory, S.strSpecialization";
    sSQL += " FROM Reg_Programs_Advisors AS PA INNER JOIN Reg_Lecturers AS A ON PA.iAdvisor = A.intLecturer INNER JOIN";
    sSQL += " Reg_Specializations AS S ON PA.strProgram = S.sAdvisingProgram";
    sSQL += " WHERE S.strSpecialization ='" + sMajor + "' and S.strDegree ='" + sDegree + "'";


    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Programs_Advisors> results = new List<Programs_Advisors>();
    try
    {
        //Default Value
        Programs_Advisors myPrograms_Advisors = new Programs_Advisors();

        while (reader.Read())
        {
            myPrograms_Advisors = new Programs_Advisors();
            if (reader["iAdvisor"].Equals(DBNull.Value))
            {
                myPrograms_Advisors.iAdvisor = 0;
            }
            else
            {
                myPrograms_Advisors.iAdvisor = int.Parse(reader["iAdvisor"].ToString());
            }

            myPrograms_Advisors.SAdvisor = reader["sAdvisor"].ToString();

            if (reader["bCategory"].Equals(DBNull.Value))
            {
                myPrograms_Advisors.byteCategory = 0;
            }
            else
            {
                myPrograms_Advisors.byteCategory = byte.Parse(reader["bCategory"].ToString());
            }

            results.Add(myPrograms_Advisors);
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

public int UpdatePrograms_Advisors(InitializeModule.EnumCampus Campus, int iMode,int iEntry,string strProgram,int iAdvisor,int byteCategory,string isWeekend)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Programs_Advisors thePrograms_Advisors = new Programs_Advisors();
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
Cmd.Parameters.Add(new SqlParameter("@iEntry",iEntry));
Cmd.Parameters.Add(new SqlParameter("@strProgram",strProgram));
Cmd.Parameters.Add(new SqlParameter("@iAdvisor",iAdvisor));
Cmd.Parameters.Add(new SqlParameter("@byteCategory",byteCategory));
Cmd.Parameters.Add(new SqlParameter("@isWeekend",isWeekend));
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
public int DeletePrograms_Advisors(InitializeModule.EnumCampus Campus,string iEntry)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@iEntry", iEntry ));
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
DataTable dt = new DataTable("Programs_Advisors");
DataView dv = new DataView();
List<Programs_Advisors> myPrograms_Advisorss = new List<Programs_Advisors>();
try
{
myPrograms_Advisorss = GetPrograms_Advisors(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("iEntry", Type.GetType("int identity"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("strProgram", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("iAdvisor", Type.GetType("smallint"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myPrograms_Advisorss.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myPrograms_Advisorss[i].iEntry;
  dr[2] = myPrograms_Advisorss[i].strProgram;
  dr[3] = myPrograms_Advisorss[i].iAdvisor;
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
myPrograms_Advisorss.Clear();
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
sSQL += iEntryFN;
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
public class Programs_AdvisorsCls : Programs_AdvisorsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daPrograms_Advisors;
private DataSet m_dsPrograms_Advisors;
public DataRow Programs_AdvisorsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsPrograms_Advisors
{
get { return m_dsPrograms_Advisors ; }
set { m_dsPrograms_Advisors = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public Programs_AdvisorsCls()
{
try
{
dsPrograms_Advisors= new DataSet();

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
public virtual SqlDataAdapter GetPrograms_AdvisorsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daPrograms_Advisors = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daPrograms_Advisors);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daPrograms_Advisors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrograms_Advisors;
}
public virtual SqlDataAdapter GetPrograms_AdvisorsDataAdapter(SqlConnection con)  
{
try
{
daPrograms_Advisors = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daPrograms_Advisors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdPrograms_Advisors;
cmdPrograms_Advisors = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@iEntry", SqlDbType.Int, 4, "iEntry" );
daPrograms_Advisors.SelectCommand = cmdPrograms_Advisors;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdPrograms_Advisors = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdPrograms_Advisors.Parameters.Add("@iEntry", SqlDbType.Int,4, LibraryMOD.GetFieldName(iEntryFN));
cmdPrograms_Advisors.Parameters.Add("@strProgram", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strProgramFN));
cmdPrograms_Advisors.Parameters.Add("@iAdvisor", SqlDbType.Int,2, LibraryMOD.GetFieldName(iAdvisorFN));
cmdPrograms_Advisors.Parameters.Add("@byteCategory", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCategoryFN));
cmdPrograms_Advisors.Parameters.Add("@isWeekend", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isWeekendFN));


Parmeter = cmdPrograms_Advisors.Parameters.Add("@iEntry", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iEntryFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daPrograms_Advisors.UpdateCommand = cmdPrograms_Advisors;
daPrograms_Advisors.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdPrograms_Advisors = new SqlCommand(GetInsertCommand(), con);
cmdPrograms_Advisors.Parameters.Add("@iEntry", SqlDbType.Int,4, LibraryMOD.GetFieldName(iEntryFN));
cmdPrograms_Advisors.Parameters.Add("@strProgram", SqlDbType.NVarChar,12, LibraryMOD.GetFieldName(strProgramFN));
cmdPrograms_Advisors.Parameters.Add("@iAdvisor", SqlDbType.Int,2, LibraryMOD.GetFieldName(iAdvisorFN));
cmdPrograms_Advisors.Parameters.Add("@byteCategory", SqlDbType.Int,2, LibraryMOD.GetFieldName(byteCategoryFN));
cmdPrograms_Advisors.Parameters.Add("@isWeekend", SqlDbType.Bit,1, LibraryMOD.GetFieldName(isWeekendFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daPrograms_Advisors.InsertCommand =cmdPrograms_Advisors;
daPrograms_Advisors.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdPrograms_Advisors = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdPrograms_Advisors.Parameters.Add("@iEntry", SqlDbType.Int, 4, LibraryMOD.GetFieldName(iEntryFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daPrograms_Advisors.DeleteCommand =cmdPrograms_Advisors;
daPrograms_Advisors.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daPrograms_Advisors.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrograms_Advisors;
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
dr = dsPrograms_Advisors.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(iEntryFN)]=iEntry;
dr[LibraryMOD.GetFieldName(strProgramFN)]=strProgram;
dr[LibraryMOD.GetFieldName(iAdvisorFN)]=iAdvisor;
dr[LibraryMOD.GetFieldName(byteCategoryFN)]=byteCategory;
dr[LibraryMOD.GetFieldName(isWeekendFN)]=isWeekend;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsPrograms_Advisors.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsPrograms_Advisors.Tables[TableName].Select(LibraryMOD.GetFieldName(iEntryFN)  + "=" + iEntry);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(iEntryFN)]=iEntry;
drAry[0][LibraryMOD.GetFieldName(strProgramFN)]=strProgram;
drAry[0][LibraryMOD.GetFieldName(iAdvisorFN)]=iAdvisor;
drAry[0][LibraryMOD.GetFieldName(byteCategoryFN)]=byteCategory;
drAry[0][LibraryMOD.GetFieldName(isWeekendFN)]=isWeekend;
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
public int CommitPrograms_Advisors()  
{
//CommitPrograms_Advisors= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daPrograms_Advisors.Update(dsPrograms_Advisors, TableName);
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
FindInMultiPKey(iEntry);
if (( Programs_AdvisorsDataRow != null)) 
{
Programs_AdvisorsDataRow.Delete();
CommitPrograms_Advisors();
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
if (Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(iEntryFN)]== System.DBNull.Value)
{
  iEntry=0;
}
else
{
  iEntry = (int)Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(iEntryFN)];
}
if (Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(strProgramFN)]== System.DBNull.Value)
{
  strProgram="";
}
else
{
  strProgram = (string)Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(strProgramFN)];
}
if (Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(iAdvisorFN)]== System.DBNull.Value)
{
  iAdvisor=0;
}
else
{
  iAdvisor = (int)Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(iAdvisorFN)];
}
if (Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(byteCategoryFN)]== System.DBNull.Value)
{
  byteCategory=0;
}
else
{
  byteCategory = (int)Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(byteCategoryFN)];
}
if (Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(isWeekendFN)]== System.DBNull.Value)
{
  isWeekend="";
}
else
{
  isWeekend = (string)Programs_AdvisorsDataRow[LibraryMOD.GetFieldName(isWeekendFN)];
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
public int FindInMultiPKey(int PKiEntry) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKiEntry;
Programs_AdvisorsDataRow = dsPrograms_Advisors.Tables[TableName].Rows.Find(findTheseVals);
if  ((Programs_AdvisorsDataRow !=null)) 
{
lngCurRow = dsPrograms_Advisors.Tables[TableName].Rows.IndexOf(Programs_AdvisorsDataRow);
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
  lngCurRow = dsPrograms_Advisors.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsPrograms_Advisors.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsPrograms_Advisors.Tables[TableName].Rows.Count > 0) 
{
  Programs_AdvisorsDataRow = dsPrograms_Advisors.Tables[TableName].Rows[lngCurRow];
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
daPrograms_Advisors.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrograms_Advisors.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daPrograms_Advisors.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrograms_Advisors.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
