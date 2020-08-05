using System;
using System.Data;
using System.Configuration;
////////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//////using System.Xml.Linq;
using System.Collections.Generic;
//using ECTGlobalDll;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public class PrivilegeObjects
{
//Creation Date: 22/11/2009 10:36:22 AM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_ObjectID; 
private string m_ObjectNameAr; 
private string m_ObjectNameEn; 
private string m_DisplayObjectName; 
private int m_ShowOrder; 
private int m_SystemID; 
private int m_ParentID; 
private string m_sURL; 
private int m_iLevel; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int ObjectID
{
get { return  m_ObjectID; }
set {m_ObjectID  = value ; }
}
public string ObjectNameAr
{
get { return  m_ObjectNameAr; }
set {m_ObjectNameAr  = value ; }
}
public string ObjectNameEn
{
get { return  m_ObjectNameEn; }
set {m_ObjectNameEn  = value ; }
}
public string DisplayObjectName
{
get { return  m_DisplayObjectName; }
set {m_DisplayObjectName  = value ; }
}
public int ShowOrder
{
get { return  m_ShowOrder; }
set {m_ShowOrder  = value ; }
}
public int SystemID
{
get { return  m_SystemID; }
set {m_SystemID  = value ; }
}
public int ParentID
{
get { return  m_ParentID; }
set {m_ParentID  = value ; }
}
public string sURL
{
get { return  m_sURL; }
set {m_sURL  = value ; }
}
public int iLevel
{
get { return  m_iLevel; }
set {m_iLevel  = value ; }
}
#endregion
//'-----------------------------------------------------
public PrivilegeObjects()
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
public class PrivilegeObjectsDAL : PrivilegeObjects
{
#region "Decleration"
private string m_TableName;
private string m_ObjectIDFN ;
private string m_ObjectNameArFN ;
private string m_ObjectNameEnFN ;
private string m_DisplayObjectNameFN ;
private string m_ShowOrderFN ;
private string m_SystemIDFN ;
private string m_ParentIDFN ;
private string m_sURLFN ;
private string m_iLevelFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string ObjectIDFN 
{
get { return  m_ObjectIDFN; }
set {m_ObjectIDFN  = value ; }
}
public string ObjectNameArFN 
{
get { return  m_ObjectNameArFN; }
set {m_ObjectNameArFN  = value ; }
}
public string ObjectNameEnFN 
{
get { return  m_ObjectNameEnFN; }
set {m_ObjectNameEnFN  = value ; }
}
public string DisplayObjectNameFN 
{
get { return  m_DisplayObjectNameFN; }
set {m_DisplayObjectNameFN  = value ; }
}
public string ShowOrderFN 
{
get { return  m_ShowOrderFN; }
set {m_ShowOrderFN  = value ; }
}
public string SystemIDFN 
{
get { return  m_SystemIDFN; }
set {m_SystemIDFN  = value ; }
}
public string ParentIDFN 
{
get { return  m_ParentIDFN; }
set {m_ParentIDFN  = value ; }
}
public string sURLFN 
{
get { return  m_sURLFN; }
set {m_sURLFN  = value ; }
}
public string iLevelFN 
{
get { return  m_iLevelFN; }
set {m_iLevelFN  = value ; }
}
#endregion
//================End Properties ===================
#region "Data Access Layer"
//-----Get SQl Function ---------------------------------
public string  GetSQL() 
{
string sSQL  = "";
try
{
sSQL = "SELECT ";
sSQL +=ObjectIDFN;
sSQL += " , " + ObjectNameArFN;
sSQL += " , " + ObjectNameEnFN;
sSQL += " , " + DisplayObjectNameFN;
sSQL += " , " + ShowOrderFN;
sSQL += " , " + SystemIDFN;
sSQL += " , " + ParentIDFN;
sSQL += " , " + sURLFN;
sSQL += " , " + iLevelFN;
sSQL += "  FROM " + m_TableName;
//sSQL += "  Order By " + iLevelFN + "," + ShowOrderFN + " DESC";
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
sSQL +=ObjectIDFN;
sSQL += " , " + ObjectNameArFN;
sSQL += " , " + ObjectNameEnFN;
sSQL += " , " + DisplayObjectNameFN;
sSQL += " , " + ShowOrderFN;
sSQL += " , " + SystemIDFN;
sSQL += " , " + ParentIDFN;
sSQL += " , " + sURLFN;
sSQL += " , " + iLevelFN;
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
sSQL += LibraryMOD.GetFieldName(ObjectIDFN) + "=@ObjectID";
sSQL += " , " + LibraryMOD.GetFieldName(ObjectNameArFN) + "=@ObjectNameAr";
sSQL += " , " + LibraryMOD.GetFieldName(ObjectNameEnFN) + "=@ObjectNameEn";
sSQL += " , " + LibraryMOD.GetFieldName(DisplayObjectNameFN) + "=@DisplayObjectName";
sSQL += " , " + LibraryMOD.GetFieldName(ShowOrderFN) + "=@ShowOrder";
sSQL += " , " + LibraryMOD.GetFieldName(SystemIDFN) + "=@SystemID";
sSQL += " , " + LibraryMOD.GetFieldName(ParentIDFN) + "=@ParentID";
sSQL += " , " + LibraryMOD.GetFieldName(sURLFN) + "=@sURL";
sSQL += " , " + LibraryMOD.GetFieldName(iLevelFN) + "=@iLevel";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(ObjectIDFN)+"=@ObjectID";
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
sSQL +=LibraryMOD.GetFieldName(ObjectIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ObjectNameArFN);
sSQL += " , " + LibraryMOD.GetFieldName(ObjectNameEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(DisplayObjectNameFN);
sSQL += " , " + LibraryMOD.GetFieldName(ShowOrderFN);
sSQL += " , " + LibraryMOD.GetFieldName(SystemIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(ParentIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(sURLFN);
sSQL += " , " + LibraryMOD.GetFieldName(iLevelFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @ObjectID";
sSQL += " ,@ObjectNameAr";
sSQL += " ,@ObjectNameEn";
sSQL += " ,@DisplayObjectName";
sSQL += " ,@ShowOrder";
sSQL += " ,@SystemID";
sSQL += " ,@ParentID";
sSQL += " ,@sURL";
sSQL += " ,@iLevel";
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
sSQL += LibraryMOD.GetFieldName(ObjectIDFN)+"=@ObjectID";
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
public PrivilegeObjectsDAL()
{
    try
    {
        this.TableName = "Cmn_PrivilegeObjects";
        this.ObjectIDFN = m_TableName + ".ObjectID";
        this.ObjectNameArFN = m_TableName + ".ObjectNameAr";
        this.ObjectNameEnFN = m_TableName + ".ObjectNameEn";
        this.DisplayObjectNameFN = m_TableName + ".DisplayObjectName";
        this.ShowOrderFN = m_TableName + ".ShowOrder";
        this.SystemIDFN = m_TableName + ".SystemID";
        this.ParentIDFN = m_TableName + ".ParentID";
        this.sURLFN = m_TableName + ".sURL";
        this.iLevelFN = m_TableName + ".iLevel";
        

    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
}
public List< PrivilegeObjects> GetPrivilegeObjects(InitializeModule.EnumCampus Campus ,string sCondition,string sOrder,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the PrivilegeObjects
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
string  sSQL = GetSQL();
if (!string.IsNullOrEmpty(sCondition))
{
sSQL += sCondition;
sSQL += sOrder;
}
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Conn.Open();
SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
List<PrivilegeObjects> results = new List<PrivilegeObjects>();
try
{
//Default Value
PrivilegeObjects myPrivilegeObjects = new PrivilegeObjects();
if (isDeafaultIncluded)
{
//Change the code here
    myPrivilegeObjects.ObjectID  = 0;
    myPrivilegeObjects.ObjectNameEn  = "Select Object ...";
results.Add(myPrivilegeObjects);
}
while (reader.Read())
{
myPrivilegeObjects = new PrivilegeObjects();
if (reader[LibraryMOD.GetFieldName(ObjectIDFN)].Equals(DBNull.Value))
{
myPrivilegeObjects.ObjectID = 0;
}
else
{
myPrivilegeObjects.ObjectID = int.Parse(reader[LibraryMOD.GetFieldName( ObjectIDFN) ].ToString());
}
myPrivilegeObjects.ObjectNameAr =reader[LibraryMOD.GetFieldName( ObjectNameArFN) ].ToString();
myPrivilegeObjects.ObjectNameEn =reader[LibraryMOD.GetFieldName( ObjectNameEnFN) ].ToString();
myPrivilegeObjects.DisplayObjectName =reader[LibraryMOD.GetFieldName( DisplayObjectNameFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(ShowOrderFN)].Equals(DBNull.Value))
{
myPrivilegeObjects.ShowOrder = 0;
}
else
{
myPrivilegeObjects.ShowOrder = int.Parse(reader[LibraryMOD.GetFieldName( ShowOrderFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(SystemIDFN)].Equals(DBNull.Value))
{
myPrivilegeObjects.SystemID = 0;
}
else
{
myPrivilegeObjects.SystemID = int.Parse(reader[LibraryMOD.GetFieldName( SystemIDFN) ].ToString());
}
if (reader[LibraryMOD.GetFieldName(ParentIDFN)].Equals(DBNull.Value))
{
myPrivilegeObjects.ParentID = 0;
}
else
{
myPrivilegeObjects.ParentID = int.Parse(reader[LibraryMOD.GetFieldName( ParentIDFN) ].ToString());
}
myPrivilegeObjects.sURL =reader[LibraryMOD.GetFieldName( sURLFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(iLevelFN)].Equals(DBNull.Value))
{
myPrivilegeObjects.iLevel = 0;
}
else
{
myPrivilegeObjects.iLevel = int.Parse(reader[LibraryMOD.GetFieldName( iLevelFN) ].ToString());
}
 results.Add(myPrivilegeObjects);
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
public int UpdatePrivilegeObjects(InitializeModule.EnumCampus Campus, int iMode,int ObjectID,string ObjectNameAr,string ObjectNameEn,string DisplayObjectName,int ShowOrder,int SystemID,int ParentID,string sURL,int iLevel)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
PrivilegeObjects thePrivilegeObjects = new PrivilegeObjects();
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
Cmd.Parameters.Add(new SqlParameter("@ObjectID",ObjectID));
Cmd.Parameters.Add(new SqlParameter("@ObjectNameAr",ObjectNameAr));
Cmd.Parameters.Add(new SqlParameter("@ObjectNameEn",ObjectNameEn));
Cmd.Parameters.Add(new SqlParameter("@DisplayObjectName",DisplayObjectName));
Cmd.Parameters.Add(new SqlParameter("@ShowOrder",ShowOrder));
Cmd.Parameters.Add(new SqlParameter("@SystemID",SystemID));
Cmd.Parameters.Add(new SqlParameter("@ParentID",ParentID));
Cmd.Parameters.Add(new SqlParameter("@sURL",sURL));
Cmd.Parameters.Add(new SqlParameter("@iLevel",iLevel));
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
public int DeletePrivilegeObjects(InitializeModule.EnumCampus Campus,int ObjectID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@ObjectID", ObjectID ));
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
public DataView GetDataView(string sCondition, string sOrder)
{
    DataTable dt = new DataTable("Objects");
    DataView dv = new DataView();
    List<PrivilegeObjects> myPrivilegeObjects = new List<PrivilegeObjects>();
    
try
{
myPrivilegeObjects = GetPrivilegeObjects(InitializeModule.EnumCampus.ECTNew,sCondition,sOrder,false);
DataColumn col1= new DataColumn("ObjectID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("ObjectNameAr", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("ObjectNameEn", Type.GetType("varchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myPrivilegeObjects.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myPrivilegeObjects[i].ObjectID;
  dr[2] = myPrivilegeObjects[i].ObjectNameAr;
  dr[3] = myPrivilegeObjects[i].ObjectNameEn;
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
myPrivilegeObjects.Clear();
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
sSQL += ObjectIDFN;
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
public int iMaxLevel(string sCondition)
{
    InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;

    Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

    string sSQL = "SELECT Max(iLevel) as Depth FROM Cmn_PrivilegeObjects";

    sSQL += sCondition;

    SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    int iDepth = 0;

    try
    {
        iDepth = int.Parse(Cmd.ExecuteScalar().ToString());

    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
        //'Response.Write(ex.Message) 

        Conn.Close();
        Conn.Dispose();
    }
    //myStatus.Clear() 

    return iDepth;
}
public int GetNewOrder(int iLevel, int iSystem)
{
    int iOrder = 1;
    SqlConnection Conn = new SqlConnection();

    try
    {
        InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
        //iCampus = InitializeModule.EnumCampus.ECTNew;
        Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

        string sSQL = "SELECT Max(ShowOrder) FROM Cmn_PrivilegeObjects";

        sSQL += " Where SystemID=" + iSystem + " And iLevel=" + iLevel;

        Conn.ConnectionString = sConn.Conn_string.ToString();
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();

        iOrder += (int)Cmd.ExecuteScalar();
    }
    catch (Exception ex)
    {
        Console.WriteLine("{0} Exception caught.", ex.Message);
    }
    finally
    {
        //Conn.Close();

    }
    return iOrder;
}
//end class tow
}
public class PrivilegeObjectsCls : PrivilegeObjectsDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daPrivilegeObjects;
private DataSet m_dsPrivilegeObjects;
public DataRow PrivilegeObjectsDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsPrivilegeObjects
{
get { return m_dsPrivilegeObjects ; }
set { m_dsPrivilegeObjects = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public PrivilegeObjectsCls()
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
//-------Get DataAdapter  -----------------------------
#region "DataAdapter"
public virtual SqlDataAdapter GetPrivilegeObjectsDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daPrivilegeObjects = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daPrivilegeObjects);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daPrivilegeObjects.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrivilegeObjects;
}
public virtual SqlDataAdapter GetPrivilegeObjectsDataAdapter(SqlConnection con)  
{
try
{
daPrivilegeObjects = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daPrivilegeObjects.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdPrivilegeObjects;
cmdPrivilegeObjects = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@ObjectID", SqlDbType.Int, 4, "ObjectID" );
daPrivilegeObjects.SelectCommand = cmdPrivilegeObjects;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdPrivilegeObjects = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdPrivilegeObjects.Parameters.Add("@ObjectID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ObjectIDFN));
cmdPrivilegeObjects.Parameters.Add("@ObjectNameAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(ObjectNameArFN));
cmdPrivilegeObjects.Parameters.Add("@ObjectNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(ObjectNameEnFN));
cmdPrivilegeObjects.Parameters.Add("@DisplayObjectName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(DisplayObjectNameFN));
cmdPrivilegeObjects.Parameters.Add("@ShowOrder", SqlDbType.Int,4, LibraryMOD.GetFieldName(ShowOrderFN));
cmdPrivilegeObjects.Parameters.Add("@SystemID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SystemIDFN));
cmdPrivilegeObjects.Parameters.Add("@ParentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ParentIDFN));
cmdPrivilegeObjects.Parameters.Add("@sURL", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sURLFN));
cmdPrivilegeObjects.Parameters.Add("@iLevel", SqlDbType.Int,4, LibraryMOD.GetFieldName(iLevelFN));


Parmeter = cmdPrivilegeObjects.Parameters.Add("@ObjectID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ObjectIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daPrivilegeObjects.UpdateCommand = cmdPrivilegeObjects;
daPrivilegeObjects.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdPrivilegeObjects = new SqlCommand(GetInsertCommand(), con);
cmdPrivilegeObjects.Parameters.Add("@ObjectID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ObjectIDFN));
cmdPrivilegeObjects.Parameters.Add("@ObjectNameAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(ObjectNameArFN));
cmdPrivilegeObjects.Parameters.Add("@ObjectNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(ObjectNameEnFN));
cmdPrivilegeObjects.Parameters.Add("@DisplayObjectName", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(DisplayObjectNameFN));
cmdPrivilegeObjects.Parameters.Add("@ShowOrder", SqlDbType.Int,4, LibraryMOD.GetFieldName(ShowOrderFN));
cmdPrivilegeObjects.Parameters.Add("@SystemID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SystemIDFN));
cmdPrivilegeObjects.Parameters.Add("@ParentID", SqlDbType.Int,4, LibraryMOD.GetFieldName(ParentIDFN));
cmdPrivilegeObjects.Parameters.Add("@sURL", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(sURLFN));
cmdPrivilegeObjects.Parameters.Add("@iLevel", SqlDbType.Int,4, LibraryMOD.GetFieldName(iLevelFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daPrivilegeObjects.InsertCommand =cmdPrivilegeObjects;
daPrivilegeObjects.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdPrivilegeObjects = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdPrivilegeObjects.Parameters.Add("@ObjectID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(ObjectIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daPrivilegeObjects.DeleteCommand =cmdPrivilegeObjects;
daPrivilegeObjects.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daPrivilegeObjects.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrivilegeObjects;
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
dr = dsPrivilegeObjects.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(ObjectIDFN)]=ObjectID;
dr[LibraryMOD.GetFieldName(ObjectNameArFN)]=ObjectNameAr;
dr[LibraryMOD.GetFieldName(ObjectNameEnFN)]=ObjectNameEn;
dr[LibraryMOD.GetFieldName(DisplayObjectNameFN)]=DisplayObjectName;
dr[LibraryMOD.GetFieldName(ShowOrderFN)]=ShowOrder;
dr[LibraryMOD.GetFieldName(SystemIDFN)]=SystemID;
dr[LibraryMOD.GetFieldName(ParentIDFN)]=ParentID;
dr[LibraryMOD.GetFieldName(sURLFN)]=sURL;
dr[LibraryMOD.GetFieldName(iLevelFN)]=iLevel;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsPrivilegeObjects.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsPrivilegeObjects.Tables[TableName].Select(LibraryMOD.GetFieldName(ObjectIDFN)  + "=" + ObjectID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(ObjectIDFN)]=ObjectID;
drAry[0][LibraryMOD.GetFieldName(ObjectNameArFN)]=ObjectNameAr;
drAry[0][LibraryMOD.GetFieldName(ObjectNameEnFN)]=ObjectNameEn;
drAry[0][LibraryMOD.GetFieldName(DisplayObjectNameFN)]=DisplayObjectName;
drAry[0][LibraryMOD.GetFieldName(ShowOrderFN)]=ShowOrder;
drAry[0][LibraryMOD.GetFieldName(SystemIDFN)]=SystemID;
drAry[0][LibraryMOD.GetFieldName(ParentIDFN)]=ParentID;
drAry[0][LibraryMOD.GetFieldName(sURLFN)]=sURL;
drAry[0][LibraryMOD.GetFieldName(iLevelFN)]=iLevel;
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
public int CommitPrivilegeObjects()  
{
//CommitPrivilegeObjects= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daPrivilegeObjects.Update(dsPrivilegeObjects, TableName);
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
FindInMultiPKey(ObjectID);
if (( PrivilegeObjectsDataRow != null)) 
{
PrivilegeObjectsDataRow.Delete();
CommitPrivilegeObjects();
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
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ObjectIDFN)]== System.DBNull.Value)
{
  ObjectID=0;
}
else
{
  ObjectID = (int)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ObjectIDFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ObjectNameArFN)]== System.DBNull.Value)
{
  ObjectNameAr="";
}
else
{
  ObjectNameAr = (string)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ObjectNameArFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ObjectNameEnFN)]== System.DBNull.Value)
{
  ObjectNameEn="";
}
else
{
  ObjectNameEn = (string)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ObjectNameEnFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(DisplayObjectNameFN)]== System.DBNull.Value)
{
  DisplayObjectName="";
}
else
{
  DisplayObjectName = (string)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(DisplayObjectNameFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ShowOrderFN)]== System.DBNull.Value)
{
  ShowOrder=0;
}
else
{
  ShowOrder = (int)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ShowOrderFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(SystemIDFN)]== System.DBNull.Value)
{
  SystemID=0;
}
else
{
  SystemID = (int)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(SystemIDFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ParentIDFN)]== System.DBNull.Value)
{
  ParentID=0;
}
else
{
  ParentID = (int)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(ParentIDFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(sURLFN)]== System.DBNull.Value)
{
  sURL="";
}
else
{
  sURL = (string)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(sURLFN)];
}
if (PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(iLevelFN)]== System.DBNull.Value)
{
  iLevel=0;
}
else
{
  iLevel = (int)PrivilegeObjectsDataRow[LibraryMOD.GetFieldName(iLevelFN)];
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
public int FindInMultiPKey( int PKObjectID) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKObjectID;
PrivilegeObjectsDataRow = dsPrivilegeObjects.Tables[TableName].Rows.Find(findTheseVals);
if  ((PrivilegeObjectsDataRow !=null)) 
{
lngCurRow = dsPrivilegeObjects.Tables[TableName].Rows.IndexOf(PrivilegeObjectsDataRow);
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
  lngCurRow = dsPrivilegeObjects.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsPrivilegeObjects.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsPrivilegeObjects.Tables[TableName].Rows.Count > 0) 
{
  PrivilegeObjectsDataRow = dsPrivilegeObjects.Tables[TableName].Rows[lngCurRow];
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
daPrivilegeObjects.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrivilegeObjects.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daPrivilegeObjects.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrivilegeObjects.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
