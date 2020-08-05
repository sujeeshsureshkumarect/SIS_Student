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
public class Privilege
{
//Creation Date: 22/11/2009 9:29:49 AM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_PrivilegeID; 
private string m_PrivilegeNameAr; 
private string m_PriviligeNameEn; 
private int m_DefaultEffect; 
#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int PrivilegeID
{
get { return  m_PrivilegeID; }
set {m_PrivilegeID  = value ; }
}
public string PrivilegeNameAr
{
get { return  m_PrivilegeNameAr; }
set {m_PrivilegeNameAr  = value ; }
}
public string PriviligeNameEn
{
get { return  m_PriviligeNameEn; }
set {m_PriviligeNameEn  = value ; }
}
public int DefaultEffect
{
get { return  m_DefaultEffect; }
set {m_DefaultEffect  = value ; }
}
#endregion
//'-----------------------------------------------------
public Privilege()
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
public class PrivilegeDAL : Privilege
{
#region "Decleration"
private string m_TableName;
private string m_PrivilegeIDFN ;
private string m_PrivilegeNameArFN ;
private string m_PriviligeNameEnFN ;
private string m_DefaultEffectFN ;
#endregion
//'-----------------------------------------------------
#region "Puplic Properties"
public string TableName 
{
get { return m_TableName; }
set { m_TableName = value; }
}
public string PrivilegeIDFN 
{
get { return  m_PrivilegeIDFN; }
set {m_PrivilegeIDFN  = value ; }
}
public string PrivilegeNameArFN 
{
get { return  m_PrivilegeNameArFN; }
set {m_PrivilegeNameArFN  = value ; }
}
public string PriviligeNameEnFN 
{
get { return  m_PriviligeNameEnFN; }
set {m_PriviligeNameEnFN  = value ; }
}
public string DefaultEffectFN 
{
get { return  m_DefaultEffectFN; }
set {m_DefaultEffectFN  = value ; }
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
sSQL +=PrivilegeIDFN;
sSQL += " , " + PrivilegeNameArFN;
sSQL += " , " + PriviligeNameEnFN;
sSQL += " , " + DefaultEffectFN;
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
sSQL +=PrivilegeIDFN;
sSQL += " , " + PrivilegeNameArFN;
sSQL += " , " + PriviligeNameEnFN;
sSQL += " , " + DefaultEffectFN;
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
sSQL += LibraryMOD.GetFieldName(PrivilegeIDFN) + "=@PrivilegeID";
sSQL += " , " + LibraryMOD.GetFieldName(PrivilegeNameArFN) + "=@PrivilegeNameAr";
sSQL += " , " + LibraryMOD.GetFieldName(PriviligeNameEnFN) + "=@PriviligeNameEn";
sSQL += " , " + LibraryMOD.GetFieldName(DefaultEffectFN) + "=@DefaultEffect";
sSQL += " WHERE ";
sSQL += LibraryMOD.GetFieldName(PrivilegeIDFN)+"=@PrivilegeID";
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
sSQL +=LibraryMOD.GetFieldName(PrivilegeIDFN);
sSQL += " , " + LibraryMOD.GetFieldName(PrivilegeNameArFN);
sSQL += " , " + LibraryMOD.GetFieldName(PriviligeNameEnFN);
sSQL += " , " + LibraryMOD.GetFieldName(DefaultEffectFN);
sSQL += ")";
sSQL += " VALUES ";
sSQL += "( ";
sSQL += " @PrivilegeID";
sSQL += " ,@PrivilegeNameAr";
sSQL += " ,@PriviligeNameEn";
sSQL += " ,@DefaultEffect";
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
sSQL += LibraryMOD.GetFieldName(PrivilegeIDFN)+"=@PrivilegeID";
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
public PrivilegeDAL()
{
    try
    {
        this.TableName = "Cmn_Privilege";
        this.PrivilegeIDFN = m_TableName + ".PrivilegeID";
        this.PrivilegeNameArFN = m_TableName + ".PrivilegeNameAr";
        this.PriviligeNameEnFN = m_TableName + ".PriviligeNameEn";
        this.DefaultEffectFN = m_TableName + ".DefaultEffect";
        

    }
    catch (Exception ex)
    {
        LibraryMOD.ShowErrorMessage(ex);
    }
    finally
    {
    }
}
public int GetPriviliegDefault(int iPrivilieg)
{
    String sSQL;
    int iValue = InitializeModule.FALSE_VALUE;
    Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    try
    {

        sSQL = "SELECT ";
        sSQL += DefaultEffectFN ;
        sSQL += "  FROM " + m_TableName;
        sSQL += "  WHERE " + PrivilegeIDFN  + "=" + iPrivilieg;

        Conn.Open();

        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        System.Data.SqlClient.SqlDataReader datReader;
        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        if (datReader.Read())
        {
            iValue = datReader.GetInt32(0);
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

    return iValue ;
}
public List< Privilege> GetPrivilege(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
{
//' returns a list of Classes instances based on the
//' data in the Privilege
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
List<Privilege> results = new List<Privilege>();
try
{
//Default Value
Privilege myPrivilege = new Privilege();
if (isDeafaultIncluded)
{
//Change the code here
myPrivilege.PrivilegeID = 0;
myPrivilege.PriviligeNameEn = "Select Privilege ...";
results.Add(myPrivilege);
}
while (reader.Read())
{
myPrivilege = new Privilege();
if (reader[LibraryMOD.GetFieldName(PrivilegeIDFN)].Equals(DBNull.Value))
{
myPrivilege.PrivilegeID = 0;
}
else
{
myPrivilege.PrivilegeID = int.Parse(reader[LibraryMOD.GetFieldName( PrivilegeIDFN) ].ToString());
}
myPrivilege.PrivilegeNameAr =reader[LibraryMOD.GetFieldName( PrivilegeNameArFN) ].ToString();
myPrivilege.PriviligeNameEn =reader[LibraryMOD.GetFieldName( PriviligeNameEnFN) ].ToString();
if (reader[LibraryMOD.GetFieldName(DefaultEffectFN)].Equals(DBNull.Value))
{
myPrivilege.DefaultEffect = 0;
}
else
{
myPrivilege.DefaultEffect = int.Parse(reader[LibraryMOD.GetFieldName( DefaultEffectFN) ].ToString());
}
 results.Add(myPrivilege);
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
public int UpdatePrivilege(InitializeModule.EnumCampus Campus, int iMode,int PrivilegeID,string PrivilegeNameAr,string PriviligeNameEn,int DefaultEffect)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
Conn.Open();
string sql = "";
Privilege thePrivilege = new Privilege();
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
Cmd.Parameters.Add(new SqlParameter("@PrivilegeID",PrivilegeID));
Cmd.Parameters.Add(new SqlParameter("@PrivilegeNameAr",PrivilegeNameAr));
Cmd.Parameters.Add(new SqlParameter("@PriviligeNameEn",PriviligeNameEn));
Cmd.Parameters.Add(new SqlParameter("@DefaultEffect",DefaultEffect));
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
public int DeletePrivilege(InitializeModule.EnumCampus Campus,string PrivilegeID)
{
int iEffected = 0;
Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
try
{
string sSQL = GetDeleteCommand();
//sSQL += sCondition;
SqlCommand Cmd = new SqlCommand(sSQL, Conn);
Cmd.Parameters.Add(new SqlParameter("@PrivilegeID", PrivilegeID ));
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
public DataView GetDataView(string sCondition)
{
DataTable dt = new DataTable("Privileges");
DataView dv = new DataView();
List<Privilege> myPrivileges = new List<Privilege>();
try
{
myPrivileges = GetPrivilege(InitializeModule.EnumCampus.ECTNew,sCondition,false);
DataColumn col1= new DataColumn("PrivilegeID", Type.GetType("int"));
dt.Columns.Add(col1 );
DataColumn col2= new DataColumn("PrivilegeNameAr", Type.GetType("nvarchar"));
dt.Columns.Add(col2 );
DataColumn col3= new DataColumn("PriviligeNameEn", Type.GetType("varchar"));
dt.Columns.Add(col3 );
dt.Constraints.Add(new UniqueConstraint(col1));

DataRow dr;
for (int i = 0; i < myPrivileges.Count; i++)
{
dr = dt.NewRow();
  dr[1] = myPrivileges[i].PrivilegeID;
  dr[2] = myPrivileges[i].PrivilegeNameAr;
  dr[3] = myPrivileges[i].PriviligeNameEn;
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
myPrivileges.Clear();
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
sSQL += PrivilegeIDFN;
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
public int AddPrivilegeToObject(int ObjectID, int PrivilegeID, SqlConnection Conn, string sUser)
{
    int iEffected = 0;

    try
    {

        string sSQL = "INSERT INTO Cmn_Permissions (ObjectID,PrivilegeID)";
        sSQL += " VALUES (@ObjectID,@PrivilegeID)";

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);

        Cmd.Parameters.Add(new SqlParameter("@ObjectID", ObjectID));
        Cmd.Parameters.Add(new SqlParameter("@PrivilegeID", PrivilegeID));


        iEffected = Cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        Console.WriteLine("{0} Exception caught.", ex.Message);
    }
    finally
    {
        //Conn.Close();

    }
    return iEffected;
}

public int DeletePrivilegeFromObject(string sCondition, SqlConnection Conn, string sUser)
{
    int iEffected = 0;

    try
    {


        string sSQL = "Delete from Cmn_Permissions";
        sSQL += sCondition;



        SqlCommand Cmd = new SqlCommand(sSQL, Conn);


        iEffected = Cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        Console.WriteLine("{0} Exception caught.", ex.Message);
    }
    finally
    {
        //Conn.Close();

    }
    return iEffected;
}

public List<Privilege> GetObjectPrivileges(string sCondition)
{

    InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
    //iCampus = InitializeModule.EnumCampus.ECTNew;
    Connection_StringCLS sConn = new Connection_StringCLS(iCampus);


    //, OP.ObjectID
    string sSQL = "SELECT P.PrivilegeID, P.PriviligeNameEn, P.DefaultEffect";
    sSQL += " FROM dbo.Cmn_Privilege AS P INNER JOIN dbo.Cmn_Permissions AS OP ON P.PrivilegeID = OP.PrivilegeID";

    sSQL += sCondition;

    sSQL = sSQL + " Order By P.PrivilegeID";

    SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

    SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    Conn.Open();
    SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    List<Privilege> results = new List<Privilege>();

    //int i = 0;
    try
    {
        while (Rd.Read())
        {
            Privilege MyPrivilege = new Privilege();
            MyPrivilege.PrivilegeID = int.Parse(Rd["PrivilegeID"].ToString());
            MyPrivilege.PriviligeNameEn  = Rd["PriviligeNameEn"].ToString();
            MyPrivilege.DefaultEffect = int.Parse(Rd["DefaultEffect"].ToString());
            //MyPrivilege.isDataChanged = false;
            //MyPrivilege.iDataStatus = 1;//Old 2:New Recored

            results.Add(MyPrivilege);
            //i += 1;

        }
    }
    catch (Exception ex)
    {
    }
    finally
    {
        //'Response.Write(ex.Message) 

        Rd.Close();
        Rd.Dispose();
        Conn.Close();
        Conn.Dispose();
    }
    //myStatus.Clear() 

    return results;

}
//end class tow
}
public class PrivilegeCls : PrivilegeDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daPrivilege;
private DataSet m_dsPrivilege;
public DataRow PrivilegeDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsPrivilege
{
get { return m_dsPrivilege ; }
set { m_dsPrivilege = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public PrivilegeCls()
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
public virtual SqlDataAdapter GetPrivilegeDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daPrivilege = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daPrivilege);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daPrivilege.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrivilege;
}
public virtual SqlDataAdapter GetPrivilegeDataAdapter(SqlConnection con)  
{
try
{
daPrivilege = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daPrivilege.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdPrivilege;
cmdPrivilege = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@PrivilegeID", SqlDbType.Int, 4, "PrivilegeID" );
daPrivilege.SelectCommand = cmdPrivilege;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdPrivilege = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdPrivilege.Parameters.Add("@PrivilegeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(PrivilegeIDFN));
cmdPrivilege.Parameters.Add("@PrivilegeNameAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PrivilegeNameArFN));
cmdPrivilege.Parameters.Add("@PriviligeNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(PriviligeNameEnFN));
cmdPrivilege.Parameters.Add("@DefaultEffect", SqlDbType.Int,4, LibraryMOD.GetFieldName(DefaultEffectFN));


Parmeter = cmdPrivilege.Parameters.Add("@PrivilegeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PrivilegeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daPrivilege.UpdateCommand = cmdPrivilege;
daPrivilege.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdPrivilege = new SqlCommand(GetInsertCommand(), con);
cmdPrivilege.Parameters.Add("@PrivilegeID", SqlDbType.Int,4, LibraryMOD.GetFieldName(PrivilegeIDFN));
cmdPrivilege.Parameters.Add("@PrivilegeNameAr", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(PrivilegeNameArFN));
cmdPrivilege.Parameters.Add("@PriviligeNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(PriviligeNameEnFN));
cmdPrivilege.Parameters.Add("@DefaultEffect", SqlDbType.Int,4, LibraryMOD.GetFieldName(DefaultEffectFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daPrivilege.InsertCommand =cmdPrivilege;
daPrivilege.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdPrivilege = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdPrivilege.Parameters.Add("@PrivilegeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(PrivilegeIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daPrivilege.DeleteCommand =cmdPrivilege;
daPrivilege.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daPrivilege.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daPrivilege;
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
dr = dsPrivilege.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(PrivilegeIDFN)]=PrivilegeID;
dr[LibraryMOD.GetFieldName(PrivilegeNameArFN)]=PrivilegeNameAr;
dr[LibraryMOD.GetFieldName(PriviligeNameEnFN)]=PriviligeNameEn;
dr[LibraryMOD.GetFieldName(DefaultEffectFN)]=DefaultEffect;
//dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
//dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
//dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
//dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
//dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
//dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsPrivilege.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsPrivilege.Tables[TableName].Select(LibraryMOD.GetFieldName(PrivilegeIDFN)  + "=" + PrivilegeID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(PrivilegeIDFN)]=PrivilegeID;
drAry[0][LibraryMOD.GetFieldName(PrivilegeNameArFN)]=PrivilegeNameAr;
drAry[0][LibraryMOD.GetFieldName(PriviligeNameEnFN)]=PriviligeNameEn;
drAry[0][LibraryMOD.GetFieldName(DefaultEffectFN)]=DefaultEffect;
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
public int CommitPrivilege()  
{
//CommitPrivilege= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daPrivilege.Update(dsPrivilege, TableName);
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
FindInMultiPKey(PrivilegeID);
if (( PrivilegeDataRow != null)) 
{
PrivilegeDataRow.Delete();
CommitPrivilege();
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
if (PrivilegeDataRow[LibraryMOD.GetFieldName(PrivilegeIDFN)]== System.DBNull.Value)
{
  PrivilegeID=0;
}
else
{
  PrivilegeID = (int)PrivilegeDataRow[LibraryMOD.GetFieldName(PrivilegeIDFN)];
}
if (PrivilegeDataRow[LibraryMOD.GetFieldName(PrivilegeNameArFN)]== System.DBNull.Value)
{
  PrivilegeNameAr="";
}
else
{
  PrivilegeNameAr = (string)PrivilegeDataRow[LibraryMOD.GetFieldName(PrivilegeNameArFN)];
}
if (PrivilegeDataRow[LibraryMOD.GetFieldName(PriviligeNameEnFN)]== System.DBNull.Value)
{
  PriviligeNameEn="";
}
else
{
  PriviligeNameEn = (string)PrivilegeDataRow[LibraryMOD.GetFieldName(PriviligeNameEnFN)];
}
if (PrivilegeDataRow[LibraryMOD.GetFieldName(DefaultEffectFN)]== System.DBNull.Value)
{
  DefaultEffect=0;
}
else
{
  DefaultEffect = (int)PrivilegeDataRow[LibraryMOD.GetFieldName(DefaultEffectFN)];
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
public int FindInMultiPKey( int PKPrivilegeID) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKPrivilegeID;
PrivilegeDataRow = dsPrivilege.Tables[TableName].Rows.Find(findTheseVals);
if  ((PrivilegeDataRow !=null)) 
{
lngCurRow = dsPrivilege.Tables[TableName].Rows.IndexOf(PrivilegeDataRow);
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
  lngCurRow = dsPrivilege.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsPrivilege.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsPrivilege.Tables[TableName].Rows.Count > 0) 
{
  PrivilegeDataRow = dsPrivilege.Tables[TableName].Rows[lngCurRow];
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
daPrivilege.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrivilege.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daPrivilege.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daPrivilege.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
