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
public class _Role
{
//Creation Date: 13/12/2009 1:21:36 PM
//Programmer Name : 
//-----Decleration --------------
#region "Decleration"
private int m_RoleID; 
private string m_RoleNameAR; 
private string m_RoleNameEn; 
private int m_MarksYear; 
private int m_MarksSemester; 
private int m_SystemID; 
private string m_SiteMapProvider; 
private int m_CreationUserID; 
private DateTime m_CreationDate; 
private int m_LastUpdateUserID; 
private DateTime m_LastUpdateDate; 
private string m_PCName; 
private string m_NetUserName; 

#endregion
#region "Puplic Properties"
//'-----------------------------------------------------
public int RoleID
{
get { return  m_RoleID; }
set {m_RoleID  = value ; }
}
public string RoleNameAR
{
get { return  m_RoleNameAR; }
set {m_RoleNameAR  = value ; }
}
public string RoleNameEn
{
get { return  m_RoleNameEn; }
set {m_RoleNameEn  = value ; }
}
public int MarksYear
{
get { return  m_MarksYear; }
set {m_MarksYear  = value ; }
}
public int MarksSemester
{
get { return  m_MarksSemester; }
set {m_MarksSemester  = value ; }
}
public int SystemID
{
get { return  m_SystemID; }
set {m_SystemID  = value ; }
}
public string SiteMapProvider
{
get { return  m_SiteMapProvider; }
set {m_SiteMapProvider  = value ; }
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

#endregion
//'-----------------------------------------------------
public _Role()
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
public class RoleDAL : _Role
{
    #region "Decleration"
    private string m_TableName;
    private string m_RoleIDFN;
    private string m_RoleNameARFN;
    private string m_RoleNameEnFN;
    private string m_MarksYearFN;
    private string m_MarksSemesterFN;
    private string m_SystemIDFN;
    private string m_SiteMapProviderFN;
    private string m_CreationUserIDFN;
    private string m_CreationDateFN;
    private string m_LastUpdateUserIDFN;
    private string m_LastUpdateDateFN;
    private string m_PCNameFN;
    private string m_NetUserNameFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string RoleIDFN
    {
        get { return m_RoleIDFN; }
        set { m_RoleIDFN = value; }
    }
    public string RoleNameARFN
    {
        get { return m_RoleNameARFN; }
        set { m_RoleNameARFN = value; }
    }
    public string RoleNameEnFN
    {
        get { return m_RoleNameEnFN; }
        set { m_RoleNameEnFN = value; }
    }
    public string MarksYearFN
    {
        get { return m_MarksYearFN; }
        set { m_MarksYearFN = value; }
    }
    public string MarksSemesterFN
    {
        get { return m_MarksSemesterFN; }
        set { m_MarksSemesterFN = value; }
    }
    public string SystemIDFN
    {
        get { return m_SystemIDFN; }
        set { m_SystemIDFN = value; }
    }
    public string SiteMapProviderFN
    {
        get { return m_SiteMapProviderFN; }
        set { m_SiteMapProviderFN = value; }
    }
    public string CreationUserIDFN
    {
        get { return m_CreationUserIDFN; }
        set { m_CreationUserIDFN = value; }
    }
    public string CreationDateFN
    {
        get { return m_CreationDateFN; }
        set { m_CreationDateFN = value; }
    }
    public string LastUpdateUserIDFN
    {
        get { return m_LastUpdateUserIDFN; }
        set { m_LastUpdateUserIDFN = value; }
    }
    public string LastUpdateDateFN
    {
        get { return m_LastUpdateDateFN; }
        set { m_LastUpdateDateFN = value; }
    }
    public string PCNameFN
    {
        get { return m_PCNameFN; }
        set { m_PCNameFN = value; }
    }
    public string NetUserNameFN
    {
        get { return m_NetUserNameFN; }
        set { m_NetUserNameFN = value; }
    }
    #endregion
    //================End Properties ===================
    #region "Data Access Layer"
    //-----Get SQl Function ---------------------------------
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += RoleIDFN;
            sSQL += " , " + RoleNameARFN;
            sSQL += " , " + RoleNameEnFN;
            sSQL += " , " + MarksYearFN;
            sSQL += " , " + MarksSemesterFN;
            sSQL += " , " + SystemIDFN;
            sSQL += " , " + SiteMapProviderFN;
            sSQL += " , " + CreationUserIDFN;
            sSQL += " , " + CreationDateFN;
            sSQL += " , " + LastUpdateUserIDFN;
            sSQL += " , " + LastUpdateDateFN;
            sSQL += " , " + PCNameFN;
            sSQL += " , " + NetUserNameFN;
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
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += RoleIDFN;
            sSQL += " , " + RoleNameARFN;
            sSQL += " , " + RoleNameEnFN;
            sSQL += " , " + MarksYearFN;
            sSQL += " , " + MarksSemesterFN;
            sSQL += " , " + SystemIDFN;
            sSQL += " , " + SiteMapProviderFN;
            sSQL += " , " + CreationUserIDFN;
            sSQL += " , " + CreationDateFN;
            sSQL += " , " + LastUpdateUserIDFN;
            sSQL += " , " + LastUpdateDateFN;
            sSQL += " , " + PCNameFN;
            sSQL += " , " + NetUserNameFN;
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
        string sSQL = "";
        try
        {
            sSQL = "UPDATE " + TableName;
            sSQL += " SET ";
            sSQL += LibraryMOD.GetFieldName(RoleIDFN) + "=@RoleID";
            sSQL += " , " + LibraryMOD.GetFieldName(RoleNameARFN) + "=@RoleNameAR";
            sSQL += " , " + LibraryMOD.GetFieldName(RoleNameEnFN) + "=@RoleNameEn";
            sSQL += " , " + LibraryMOD.GetFieldName(MarksYearFN) + "=@MarksYear";
            sSQL += " , " + LibraryMOD.GetFieldName(MarksSemesterFN) + "=@MarksSemester";
            sSQL += " , " + LibraryMOD.GetFieldName(SystemIDFN) + "=@SystemID";
            sSQL += " , " + LibraryMOD.GetFieldName(SiteMapProviderFN) + "=@SiteMapProvider";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(RoleIDFN) + "=@RoleID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(RoleNameARFN)+"=@RoleNameAR";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(RoleNameEnFN)+"=@RoleNameEn";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(MarksYearFN)+"=@MarksYear";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(MarksSemesterFN)+"=@MarksSemester";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(SystemIDFN)+"=@SystemID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(SiteMapProviderFN)+"=@SiteMapProvider";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(CreationUserIDFN)+"=@CreationUserID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(CreationDateFN)+"=@CreationDate";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(LastUpdateUserIDFN)+"=@LastUpdateUserID";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(LastUpdateDateFN)+"=@LastUpdateDate";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(PCNameFN)+"=@PCName";
            //sSQL +=  " And " + LibraryMOD.GetFieldName(NetUserNameFN)+"=@NetUserName";
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
        string sSQL = "";
        try
        {
            sSQL = "INSERT intO " + TableName;
            sSQL += "( ";
            sSQL += LibraryMOD.GetFieldName(RoleIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(RoleNameARFN);
            sSQL += " , " + LibraryMOD.GetFieldName(RoleNameEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MarksYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MarksSemesterFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SystemIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SiteMapProviderFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @RoleID";
            sSQL += " ,@RoleNameAR";
            sSQL += " ,@RoleNameEn";
            sSQL += " ,@MarksYear";
            sSQL += " ,@MarksSemester";
            sSQL += " ,@SystemID";
            sSQL += " ,@SiteMapProvider";
            sSQL += " ,@CreationUserID";
            sSQL += " ,@CreationDate";
            sSQL += " ,@LastUpdateUserID";
            sSQL += " ,@LastUpdateDate";
            sSQL += " ,@PCName";
            sSQL += " ,@NetUserName";
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
    public string GetDeleteCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "DELETE FROM " + TableName;
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(RoleIDFN) + "=@RoleID";
            sSQL += " And " + LibraryMOD.GetFieldName(RoleNameARFN) + "=@RoleNameAR";
            sSQL += " And " + LibraryMOD.GetFieldName(RoleNameEnFN) + "=@RoleNameEn";
            sSQL += " And " + LibraryMOD.GetFieldName(MarksYearFN) + "=@MarksYear";
            sSQL += " And " + LibraryMOD.GetFieldName(MarksSemesterFN) + "=@MarksSemester";
            sSQL += " And " + LibraryMOD.GetFieldName(SystemIDFN) + "=@SystemID";
            sSQL += " And " + LibraryMOD.GetFieldName(SiteMapProviderFN) + "=@SiteMapProvider";
            sSQL += " And " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " And " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " And " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " And " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " And " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " And " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
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
    public RoleDAL()
    {
        try
        {
            this.TableName = "Cmn_Role";
            this.RoleIDFN = m_TableName + ".RoleID";
            this.RoleNameARFN = m_TableName + ".RoleNameAR";
            this.RoleNameEnFN = m_TableName + ".RoleNameEn";
            this.MarksYearFN = m_TableName + ".MarksYear";
            this.MarksSemesterFN = m_TableName + ".MarksSemester";
            this.SystemIDFN = m_TableName + ".SystemID";
            this.SiteMapProviderFN = m_TableName + ".SiteMapProvider";
            this.CreationUserIDFN = m_TableName + ".CreationUserID";
            this.CreationDateFN = m_TableName + ".CreationDate";
            this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
            this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
            this.PCNameFN = m_TableName + ".PCName";
            this.NetUserNameFN = m_TableName + ".NetUserName";


        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
    }
    public List<_Role> GetRole(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Role
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetSQL();
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<_Role> results = new List<_Role>();
        try
        {
            //Default Value
            _Role myRole = new _Role();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myRole.RoleID = 0;
                myRole.RoleNameEn = "Select Role ...";
                results.Add(myRole);
            }
            while (reader.Read())
            {
                myRole = new _Role();
                if (reader[LibraryMOD.GetFieldName(RoleIDFN)].Equals(DBNull.Value))
                {
                    myRole.RoleID = 0;
                }
                else
                {
                    myRole.RoleID = int.Parse(reader[LibraryMOD.GetFieldName(RoleIDFN)].ToString());
                }
                myRole.RoleNameAR = reader[LibraryMOD.GetFieldName(RoleNameARFN)].ToString();
                myRole.RoleNameEn = reader[LibraryMOD.GetFieldName(RoleNameEnFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(MarksYearFN)].Equals(DBNull.Value))
                {
                    myRole.MarksYear = 0;
                }
                else
                {
                    myRole.MarksYear = int.Parse(reader[LibraryMOD.GetFieldName(MarksYearFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(MarksSemesterFN)].Equals(DBNull.Value))
                {
                    myRole.MarksSemester = 0;
                }
                else
                {
                    myRole.MarksSemester = int.Parse(reader[LibraryMOD.GetFieldName(MarksSemesterFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(SystemIDFN)].Equals(DBNull.Value))
                {
                    myRole.SystemID = 0;
                }
                else
                {
                    myRole.SystemID = int.Parse(reader[LibraryMOD.GetFieldName(SystemIDFN)].ToString());
                }
                myRole.SiteMapProvider = reader[LibraryMOD.GetFieldName(SiteMapProviderFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
                {
                    myRole.CreationUserID = 0;
                }
                else
                {
                    myRole.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName(CreationUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
                {
                    myRole.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(CreationDateFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
                {
                    myRole.LastUpdateUserID = 0;
                }
                else
                {
                    myRole.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].ToString());
                }
                if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
                {
                    myRole.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].ToString());
                }
                myRole.PCName = reader[LibraryMOD.GetFieldName(PCNameFN)].ToString();
                myRole.NetUserName = reader[LibraryMOD.GetFieldName(NetUserNameFN)].ToString();
                results.Add(myRole);
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
    public int UpdateRole(InitializeModule.EnumCampus Campus, int iMode, int RoleID, string RoleNameAR, string RoleNameEn, int MarksYear, int MarksSemester, int SystemID, string SiteMapProvider, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            _Role theRole = new _Role();
            //'Updates the  table
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    sql = GetUpdateCommand();
                    break;
                case (int)InitializeModule.enumModes.NewMode:
                    sql = GetInsertCommand();
                    break;
            }
            SqlCommand Cmd = new SqlCommand(sql, Conn);
            Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
            Cmd.Parameters.Add(new SqlParameter("@RoleNameAR", RoleNameAR));
            Cmd.Parameters.Add(new SqlParameter("@RoleNameEn", RoleNameEn));
            Cmd.Parameters.Add(new SqlParameter("@MarksYear", MarksYear));
            Cmd.Parameters.Add(new SqlParameter("@MarksSemester", MarksSemester));
            Cmd.Parameters.Add(new SqlParameter("@SystemID", SystemID));
            Cmd.Parameters.Add(new SqlParameter("@SiteMapProvider", SiteMapProvider));
            Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
            Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", LastUpdateDate));
            Cmd.Parameters.Add(new SqlParameter("@PCName", PCName));
            Cmd.Parameters.Add(new SqlParameter("@NetUserName", NetUserName));
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
    public int DeleteRole(InitializeModule.EnumCampus Campus, string RoleID, string RoleNameAR, string RoleNameEn, string MarksYear, string MarksSemester, string SystemID, string SiteMapProvider, string CreationUserID, string CreationDate, string LastUpdateUserID, string LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
            Cmd.Parameters.Add(new SqlParameter("@RoleNameAR", RoleNameAR));
            Cmd.Parameters.Add(new SqlParameter("@RoleNameEn", RoleNameEn));
            Cmd.Parameters.Add(new SqlParameter("@MarksYear", MarksYear));
            Cmd.Parameters.Add(new SqlParameter("@MarksSemester", MarksSemester));
            Cmd.Parameters.Add(new SqlParameter("@SystemID", SystemID));
            Cmd.Parameters.Add(new SqlParameter("@SiteMapProvider", SiteMapProvider));
            Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
            Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", LastUpdateDate));
            Cmd.Parameters.Add(new SqlParameter("@PCName", PCName));
            Cmd.Parameters.Add(new SqlParameter("@NetUserName", NetUserName));
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
        DataTable dt = new DataTable("Roles");
        DataView dv = new DataView();
        List<_Role> myRoles = new List<_Role>();
        try
        {
            myRoles = GetRole(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("RoleID", Type.GetType("int"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("RoleNameAR", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("RoleNameEn", Type.GetType("varchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));


            DataRow dr;
            for (int i = 0; i < myRoles.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myRoles[i].RoleID;
                dr[2] = myRoles[i].RoleNameAR;
                dr[3] = myRoles[i].RoleNameEn;
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
            myRoles.Clear();
        }
        return dv;
    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con)
    {
        string sSQL = "";
        DataTable table = new DataTable();
        try
        {
            sSQL = "SELECT";
            sSQL += RoleIDFN;
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
    public int AddPermissionToRole(int RoleID, int ObjectID, int PrivilegeID, int PrivilegeEffect, SqlConnection Conn, string sUser)
    {
        int iEffected = 0;

        try
        {

            //SELECT RoleID,ObjectID,PrivilegeID,PrivilegeEffect FROM Cmn_RolePermissions

            string sSQL = "INSERT INTO Cmn_RolePermissions (RoleID,ObjectID,PrivilegeID,PrivilegeEffect)";
            sSQL += " VALUES (@RoleID,@ObjectID,@PrivilegeID,@PrivilegeEffect)";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
            Cmd.Parameters.Add(new SqlParameter("@ObjectID", ObjectID));
            Cmd.Parameters.Add(new SqlParameter("@PrivilegeID", PrivilegeID));
            Cmd.Parameters.Add(new SqlParameter("@PrivilegeEffect", PrivilegeEffect));


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

    public int DeletePermissionFromRole(string sCondition, SqlConnection Conn, string sUser)
    {
        int iEffected = 0;

        try
        {


            string sSQL = "Delete from Cmn_RolePermissions";
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

    public int AddObjectToRole(int RoleID, int ObjectID, SqlConnection Conn, string sUser,bool bDefaultOnly )
    {
        int iEffected = 0;

        try
        {
            

            string sSQL = "INSERT INTO Cmn_RolePermissions (RoleID,ObjectID,PrivilegeID,PrivilegeEffect)";
            sSQL += " SELECT @RoleID,ObjectID,Cmn_Privilege.PrivilegeID,1 ";
            sSQL += " FROM Cmn_Permissions ";
            if (bDefaultOnly)
            {
                sSQL += " INNER JOIN Cmn_Privilege ";
                sSQL += " ON Cmn_Permissions.PrivilegeID = Cmn_Privilege.PrivilegeID";
            }
            sSQL += " WHERE ObjectID=@ObjectID";

            if (bDefaultOnly)
            {
                sSQL += " AND dbo.Cmn_Privilege.DefaultEffect = 1";
            }

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
            Cmd.Parameters.Add(new SqlParameter("@ObjectID", ObjectID));

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

    public int DeleteObjectFromRole(int RoleID, int ObjectID, SqlConnection Conn, string sUser)
    {
        int iEffected = 0;

        try
        {
            string sSQL = "Delete From Cmn_RolePermissions";
            sSQL += " Where RoleID=@RoleID and ObjectID=@ObjectID";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
            Cmd.Parameters.Add(new SqlParameter("@ObjectID", ObjectID));

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



    public List<PrivilegeObjects> GetRoleObjects(int RoleID)
    {

        InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
        //iCampus = InitializeModule.EnumCampus.ECTNew;
        Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

        string sSQL = "SELECT O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel, COUNT(RP.PrivilegeID) AS [Privileges]";
        sSQL += " FROM Cmn_RolePermissions AS RP INNER JOIN Cmn_PrivilegeObjects AS O ON RP.ObjectID = O.ObjectID";
        sSQL += " Where RP.RoleID=" + RoleID;
        sSQL += " GROUP BY O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel";
        sSQL += " Order by O.iLevel,O.ShowOrder desc";


        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<PrivilegeObjects> results = new List<PrivilegeObjects>();

        //int i = 0;
        try
        {
            while (Rd.Read())
            {
                PrivilegeObjects MyMap = new PrivilegeObjects();
                MyMap.ObjectID = int.Parse(Rd["ObjectID"].ToString());
                MyMap.ObjectNameEn = Rd["ObjectNameEn"].ToString();
                MyMap.DisplayObjectName = Rd["DisplayObjectName"].ToString();
                MyMap.ShowOrder = int.Parse(Rd["ShowOrder"].ToString());
                MyMap.SystemID = int.Parse(Rd["SystemID"].ToString());

                if (Rd["ParentID"].Equals(DBNull.Value))
                {
                    MyMap.ParentID = MyMap.ObjectID;
                }
                else
                {
                    MyMap.ParentID = int.Parse(Rd["ParentID"].ToString());
                }

                if (Rd["sURL"].Equals(DBNull.Value))
                {
                    MyMap.sURL = MyMap.ObjectNameEn;
                }
                else
                {
                    MyMap.sURL = Rd["sURL"].ToString();
                }

                if (Rd["iLevel"].Equals(DBNull.Value))
                {
                    MyMap.iLevel = 0;
                }
                else
                {
                    MyMap.iLevel = int.Parse(Rd["iLevel"].ToString());
                }

                results.Add(MyMap);
                //i += 1;

            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
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
    public List<Privilege> GetRoleObjPermissions(int ObjectID, int RoleID)
    {

        InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
        Connection_StringCLS sConn = new Connection_StringCLS(iCampus);

        string sSQL = "SELECT P.PrivilegeID, P.PriviligeNameEn, P.DefaultEffect, RP.ObjectID, RP.RoleID";
        sSQL += " FROM dbo.Cmn_Privilege AS P INNER JOIN dbo.Cmn_RolePermissions AS RP ON P.PrivilegeID = RP.PrivilegeID";

        sSQL += " Where RP.ObjectID=" + ObjectID + " AND RP.RoleID=" + RoleID;
        //if (isDefaultOnly)
        //{
        //    sSQL += " AND P.DefaultEffect=" + InitializeModule.TRUE_VALUE;
        //}
        sSQL += " Order By P.PrivilegeID";

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
                MyPrivilege.PriviligeNameEn = Rd["PriviligeNameEn"].ToString();
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

    public string GetRoleDesc(int RoleID)
    {
        string sRole = "";
        InitializeModule.EnumCampus iCampus = InitializeModule.EnumCampus.ECTNew;
        //iCampus = InitializeModule.EnumCampus.ECTNew;
        Connection_StringCLS sConn = new Connection_StringCLS();


        string sSQL = "SELECT RoleNameEn";
        sSQL += " FROM Cmn_Role";
        sSQL += " Where RoleID=" + RoleID;

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        try
        {

            Conn.Open();

            sRole += Cmd.ExecuteScalar().ToString();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            ////'Response.Write(ex.Message) 

            //Rd.Close();
            //Rd = null;
            Conn.Close();
            Conn.Dispose();
        }
        return sRole;
    }
    //end class tow
}
public class RoleCls : RoleDAL
{
#region "Decleration"
private int m_lngCurRow=0;
public SqlDataAdapter daRole;
private DataSet m_dsRole;
public DataRow RoleDataRow ;
#endregion
#region "Puplic Properties"
public DataSet dsRole
{
get { return m_dsRole ; }
set { m_dsRole = value ; }
}
//-----------------------------------------------------
public int lngCurRow 
{
get { return  m_lngCurRow ; }
set {m_lngCurRow = value ; }
}
#endregion
public RoleCls()
{
try
{
dsRole= new DataSet();

}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
}
//-------Get DataAdapter  ----------------------------------------
#region "DataAdapter"
public virtual SqlDataAdapter GetRoleDataAdapter(string sCondition ,SqlConnection con ) 
{
string sSQL =""; 
try
{
sSQL = GetSQL();
sSQL += " " + sCondition;
//-----------------------------------------
daRole = new SqlDataAdapter(sSQL, con);
// Create command builder. This line automatically generates the update commands for you, so you don't
// have to provide or create your own.
SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daRole);
//Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
// key + unique key information to be retrieved unless AddWithKey is specified.
daRole.MissingSchemaAction = MissingSchemaAction.AddWithKey;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daRole;
}
public virtual SqlDataAdapter GetRoleDataAdapter(SqlConnection con)  
{
try
{
daRole = new SqlDataAdapter();
//''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
//'' key + unique key information to be retrieved unless AddWithKey is specified.
daRole.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//-----------------------------------------
SqlParameter Parmeter = default(SqlParameter); 
//[SELECT COMMAND]
SqlCommand cmdRole;
cmdRole = new SqlCommand(GetSelectCommand(), con);
//'cmdRolePermission.Parameters.Add("@RoleID", SqlDbType.Int, 4, "RoleID" );
daRole.SelectCommand = cmdRole;
//'Add Handlers
//'RowUpdating,RowUpdated
AddDAEventHandler();
//'[UPDATE COMMAND].
cmdRole = new SqlCommand(GetUpdateCommand(), con);
//'Delete PK Parameteres from here. b/c its declared below
cmdRole.Parameters.Add("@RoleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(RoleIDFN));
cmdRole.Parameters.Add("@RoleNameAR", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(RoleNameARFN));
cmdRole.Parameters.Add("@RoleNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(RoleNameEnFN));
cmdRole.Parameters.Add("@MarksYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(MarksYearFN));
cmdRole.Parameters.Add("@MarksSemester", SqlDbType.Int,4, LibraryMOD.GetFieldName(MarksSemesterFN));
cmdRole.Parameters.Add("@SystemID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SystemIDFN));
cmdRole.Parameters.Add("@SiteMapProvider", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(SiteMapProviderFN));
cmdRole.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdRole.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdRole.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdRole.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdRole.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdRole.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));


Parmeter = cmdRole.Parameters.Add("@RoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RoleIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
//'Its should be none for batch updating
//'UpdateCommand, InsertCommand, and DeleteCommand 
//'should be set to None or OutputParameters
daRole.UpdateCommand = cmdRole;
daRole.UpdateCommand.UpdatedRowSource  = UpdateRowSource.None ;
//'-------------------------
//'/INSERT COMMAND
 cmdRole = new SqlCommand(GetInsertCommand(), con);
cmdRole.Parameters.Add("@RoleID", SqlDbType.Int,4, LibraryMOD.GetFieldName(RoleIDFN));
cmdRole.Parameters.Add("@RoleNameAR", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(RoleNameARFN));
cmdRole.Parameters.Add("@RoleNameEn", SqlDbType.VarChar,50, LibraryMOD.GetFieldName(RoleNameEnFN));
cmdRole.Parameters.Add("@MarksYear", SqlDbType.Int,4, LibraryMOD.GetFieldName(MarksYearFN));
cmdRole.Parameters.Add("@MarksSemester", SqlDbType.Int,4, LibraryMOD.GetFieldName(MarksSemesterFN));
cmdRole.Parameters.Add("@SystemID", SqlDbType.Int,4, LibraryMOD.GetFieldName(SystemIDFN));
cmdRole.Parameters.Add("@SiteMapProvider", SqlDbType.NVarChar,100, LibraryMOD.GetFieldName(SiteMapProviderFN));
cmdRole.Parameters.Add("@CreationUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(CreationUserIDFN));
cmdRole.Parameters.Add("@CreationDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(CreationDateFN));
cmdRole.Parameters.Add("@LastUpdateUserID", SqlDbType.Int,4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
cmdRole.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime,16, LibraryMOD.GetFieldName(LastUpdateDateFN));
cmdRole.Parameters.Add("@PCName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(PCNameFN));
cmdRole.Parameters.Add("@NetUserName", SqlDbType.NVarChar,32, LibraryMOD.GetFieldName(NetUserNameFN));
Parmeter.SourceVersion = DataRowVersion.Current;
daRole.InsertCommand =cmdRole;
daRole.InsertCommand.UpdatedRowSource  = UpdateRowSource.None;
//'------------------------
//'/DELETE COMMAND
 cmdRole = new SqlCommand(GetDeleteCommand(), con);
Parmeter = cmdRole.Parameters.Add("@RoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RoleIDFN));
Parmeter.SourceVersion = DataRowVersion.Original;
daRole.DeleteCommand =cmdRole;
daRole.DeleteCommand.UpdatedRowSource  = UpdateRowSource.None;
//'Batch Size
//'Set the batch size.
daRole.UpdateBatchSize = InitializeModule.BATCH_SIZE;
}
catch (Exception ex)
{
LibraryMOD.ShowErrorMessage(ex);
}
finally
{
}
return daRole;
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
dr = dsRole.Tables[TableName].NewRow();
dr[LibraryMOD.GetFieldName(RoleIDFN)]=RoleID;
dr[LibraryMOD.GetFieldName(RoleNameARFN)]=RoleNameAR;
dr[LibraryMOD.GetFieldName(RoleNameEnFN)]=RoleNameEn;
dr[LibraryMOD.GetFieldName(MarksYearFN)]=MarksYear;
dr[LibraryMOD.GetFieldName(MarksSemesterFN)]=MarksSemester;
dr[LibraryMOD.GetFieldName(SystemIDFN)]=SystemID;
dr[LibraryMOD.GetFieldName(SiteMapProviderFN)]=SiteMapProvider;
dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
dsRole.Tables[TableName].Rows.Add(dr);
break;
case (int)InitializeModule.enumModes.EditMode:
 DataRow[] drAry = null;
drAry = dsRole.Tables[TableName].Select(LibraryMOD.GetFieldName(RoleIDFN)  + "=" + RoleID);
//'its return array of rows and we can access the first by index 0
drAry[0][LibraryMOD.GetFieldName(RoleIDFN)]=RoleID;
drAry[0][LibraryMOD.GetFieldName(RoleNameARFN)]=RoleNameAR;
drAry[0][LibraryMOD.GetFieldName(RoleNameEnFN)]=RoleNameEn;
drAry[0][LibraryMOD.GetFieldName(MarksYearFN)]=MarksYear;
drAry[0][LibraryMOD.GetFieldName(MarksSemesterFN)]=MarksSemester;
drAry[0][LibraryMOD.GetFieldName(SystemIDFN)]=SystemID;
drAry[0][LibraryMOD.GetFieldName(SiteMapProviderFN)]=SiteMapProvider;
drAry[0][LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
drAry[0][LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
drAry[0][LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
drAry[0][LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
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
public int CommitRole()  
{
//CommitRole= InitializeModule.FAIL_RET;
try
{
//'' Update Database with SqlDataAdapter
daRole.Update(dsRole, TableName);
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
FindInMultiPKey(RoleID);
if (( RoleDataRow != null)) 
{
RoleDataRow.Delete();
CommitRole();
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
if (RoleDataRow[LibraryMOD.GetFieldName(RoleIDFN)]== System.DBNull.Value)
{
  RoleID=0;
}
else
{
  RoleID = (int)RoleDataRow[LibraryMOD.GetFieldName(RoleIDFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(RoleNameARFN)]== System.DBNull.Value)
{
  RoleNameAR="";
}
else
{
  RoleNameAR = (string)RoleDataRow[LibraryMOD.GetFieldName(RoleNameARFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(RoleNameEnFN)]== System.DBNull.Value)
{
  RoleNameEn="";
}
else
{
  RoleNameEn = (string)RoleDataRow[LibraryMOD.GetFieldName(RoleNameEnFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(MarksYearFN)]== System.DBNull.Value)
{
  MarksYear=0;
}
else
{
  MarksYear = (int)RoleDataRow[LibraryMOD.GetFieldName(MarksYearFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(MarksSemesterFN)]== System.DBNull.Value)
{
  MarksSemester=0;
}
else
{
  MarksSemester = (int)RoleDataRow[LibraryMOD.GetFieldName(MarksSemesterFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(SystemIDFN)]== System.DBNull.Value)
{
  SystemID=0;
}
else
{
  SystemID = (int)RoleDataRow[LibraryMOD.GetFieldName(SystemIDFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(SiteMapProviderFN)]== System.DBNull.Value)
{
  SiteMapProvider="";
}
else
{
  SiteMapProvider = (string)RoleDataRow[LibraryMOD.GetFieldName(SiteMapProviderFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)]== System.DBNull.Value)
{
  CreationUserID=0;
}
else
{
  CreationUserID = (int)RoleDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(CreationDateFN)]== System.DBNull.Value)
{
}
else
{
  CreationDate = (DateTime)RoleDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)]== System.DBNull.Value)
{
  LastUpdateUserID=0;
}
else
{
  LastUpdateUserID = (int)RoleDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)]== System.DBNull.Value)
{
}
else
{
  LastUpdateDate = (DateTime)RoleDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(PCNameFN)]== System.DBNull.Value)
{
  PCName="";
}
else
{
  PCName = (string)RoleDataRow[LibraryMOD.GetFieldName(PCNameFN)];
}
if (RoleDataRow[LibraryMOD.GetFieldName(NetUserNameFN)]== System.DBNull.Value)
{
  NetUserName="";
}
else
{
  NetUserName = (string)RoleDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
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
//' -------FindInMultiPKey  --------------------------------------
public int FindInMultiPKey(int PKRoleID) 
{
//FindInMultiPKey= InitializeModule.FAIL_RET;
try
{
//' Create an array for the key values to find.
object[] findTheseVals = new object[1] ; 
//' Set the values of the keys to find.
findTheseVals[0] = PKRoleID;
RoleDataRow = dsRole.Tables[TableName].Rows.Find(findTheseVals);
if  ((RoleDataRow !=null)) 
{
lngCurRow = dsRole.Tables[TableName].Rows.IndexOf(RoleDataRow);
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
  lngCurRow = dsRole.Tables[TableName].Rows.Count - 1; //'Zero based index
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
  lngCurRow = Math.Min(lngCurRow + 1, dsRole.Tables[TableName].Rows.Count - 1);
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
  if (lngCurRow >= 0 & dsRole.Tables[TableName].Rows.Count > 0) 
{
  RoleDataRow = dsRole.Tables[TableName].Rows[lngCurRow];
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
daRole.RowUpdating+= new SqlRowUpdatingEventHandler(OnRowUpdating);
daRole.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
daRole.RowUpdating-= new SqlRowUpdatingEventHandler(OnRowUpdating);
daRole.RowUpdated-= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
