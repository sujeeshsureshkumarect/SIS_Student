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
public class User
{
    //Creation Date: 13/12/2009 12:50:00 PM
    //Programmer Name : 
    //-----Decleration --------------
    #region "Decleration"
    private int m_UserNo;
    private string m_UserName;
    private string m_Password;
    private int m_EmployeeID;
    private int m_UILanguage;
    private int m_AcademicYear;
    private int m_Semester;
    private int m_MarksYear;
    private int m_MarksSemester;
    private string m_GradesPCName;
    private string m_ADUserName;
    private int m_IsActive;
    private DateTime  m_LastLoginDate;
    private int m_LastLoginTime;
    private int m_AllowedCampus;
    private int m_LecturerID;
    
    private Boolean m_IsLecturer;
    private byte m_IsChangingRequired;
    private int m_Campus;
    private int m_CreationUserID;
    private DateTime m_CreationDate;
    private int m_LastUpdateUserID;
    private DateTime m_LastUpdateDate;
    private string m_PCName;
    private string m_NetUserName;
    //private int m_RoleID; 

    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public int UserNo
    {
        get { return m_UserNo; }
        set { m_UserNo = value; }
    }
    public string UserName
    {
        get { return m_UserName; }
        set { m_UserName = value; }
    }
    public string Password
    {
        get { return m_Password; }
        set { m_Password = value; }
    }
    public int EmployeeID
    {
        get { return m_EmployeeID; }
        set { m_EmployeeID = value; }
    }
    public int UILanguage
    {
        get { return m_UILanguage; }
        set { m_UILanguage = value; }
    }
    public int AcademicYear
    {
        get { return m_AcademicYear; }
        set { m_AcademicYear = value; }
    }
    public int Semester
    {
        get { return m_Semester; }
        set { m_Semester = value; }
    }
    public int MarksYear
    {
        get { return m_MarksYear; }
        set { m_MarksYear = value; }
    }
    public int MarksSemester
    {
        get { return m_MarksSemester; }
        set { m_MarksSemester = value; }
    }

    public string GradesPCName
    {
        get { return m_GradesPCName; }
        set { m_GradesPCName = value; }
    }
    public string ADUserName
    {
        get { return m_ADUserName; }
        set { m_ADUserName = value; }
    }
    public int IsActive
    {
        get { return m_IsActive; }
        set { m_IsActive = value; }
    }
    public DateTime  LastLoginDate
    {
        get { return m_LastLoginDate; }
        set { m_LastLoginDate = value; }
    }
    public int LastLoginTime
    {
        get { return m_LastLoginTime; }
        set { m_LastLoginTime = value; }
    }

    public int AllowedCampus
    {
        get { return m_AllowedCampus; }
        set { m_AllowedCampus = value; }
    }

    public int LecturerID
    {
        get { return m_LecturerID; }
        set { m_LecturerID = value; }
    }

    public Boolean IsLecturer
    {
        get { return m_IsLecturer; }
        set { m_IsLecturer = value; }
    }
    public byte  IsChangingRequired
    {
        get { return m_IsChangingRequired; }
        set { m_IsChangingRequired = value; }
    }

    public int Campus
    {
        get { return m_Campus; }
        set { m_Campus = value; }
    }

    public int CreationUserID
    {
        get { return m_CreationUserID; }
        set { m_CreationUserID = value; }
    }
    public DateTime CreationDate
    {
        get { return m_CreationDate; }
        set { m_CreationDate = value; }
    }
    public int LastUpdateUserID
    {
        get { return m_LastUpdateUserID; }
        set { m_LastUpdateUserID = value; }
    }
    public DateTime LastUpdateDate
    {
        get { return m_LastUpdateDate; }
        set { m_LastUpdateDate = value; }
    }
    public string PCName
    {
        get { return m_PCName; }
        set { m_PCName = value; }
    }
    public string NetUserName
    {
        get { return m_NetUserName; }
        set { m_NetUserName = value; }
    }
    //public int RoleID
    //{
    //get { return  m_RoleID; }
    //set {m_RoleID  = value ; }
    //}

    #endregion
    //'-----------------------------------------------------
    public User()
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
public class UserDAL : User
{
    #region "Decleration"
    private string m_TableName;
    private string m_UserNoFN;
    private string m_UserNameFN;
    private string m_PasswordFN;
    private string m_EmployeeIDFN;
    private string m_UILanguageFN;
    private string m_AcademicYearFN;
    private string m_SemesterFN;
    private string m_MarksYearFN;
    private string m_MarksSemesterFN;
    private string m_GradesPCNameFN;
    private string m_ADUserNameFN;
    private string m_IsActiveFN;
    private string m_LastLoginDateFN;
    private string m_LastLoginTimeFN;
    private string m_AllowedCampusFN;
    private string m_LecturerIDFN;

    private string m_IsLecturerFN;
    private string m_IsChangingRequiredFN;
    private string m_CampusFN;

    private string m_CreationUserIDFN;
    private string m_CreationDateFN;
    private string m_LastUpdateUserIDFN;
    private string m_LastUpdateDateFN;
    private string m_PCNameFN;
    private string m_NetUserNameFN;
    private string m_RoleIDFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    //'-----------------------------------------------------
    public string UserNoFN
    {
        get { return m_UserNoFN; }
        set { m_UserNoFN = value; }
    }
    public string UserNameFN
    {
        get { return m_UserNameFN; }
        set { m_UserNameFN = value; }
    }
    public string PasswordFN
    {
        get { return m_PasswordFN; }
        set { m_PasswordFN = value; }
    }
    public string EmployeeIDFN
    {
        get { return m_EmployeeIDFN; }
        set { m_EmployeeIDFN = value; }
    }
    public string UILanguageFN
    {
        get { return m_UILanguageFN; }
        set { m_UILanguageFN = value; }
    }
    public string AcademicYearFN
    {
        get { return m_AcademicYearFN; }
        set { m_AcademicYearFN = value; }
    }
    public string SemesterFN
    {
        get { return m_SemesterFN; }
        set { m_SemesterFN = value; }
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
    public string GradesPCNameFN
    {
        get { return m_GradesPCNameFN; }
        set { m_GradesPCNameFN = value; }
    }
    public string ADUserNameFN
    {
        get { return m_ADUserNameFN; }
        set { m_ADUserNameFN = value; }
    }
    public string IsActiveFN
    {
        get { return m_IsActiveFN; }
        set { m_IsActiveFN = value; }
    }
    public string LastLoginDateFN
    {
        get { return m_LastLoginDateFN; }
        set { m_LastLoginDateFN = value; }
    }
    public string LastLoginTimeFN
    {
        get { return m_LastLoginTimeFN; }
        set { m_LastLoginTimeFN = value; }
    }

    public string AllowedCampusFN
    {
        get { return m_AllowedCampusFN; }
        set { m_AllowedCampusFN = value; }
    }
    public string LecturerIDFN
    {
        get { return m_LecturerIDFN; }
        set { m_LecturerIDFN = value; }
    }

    public string IsLecturerFN
    {
        get { return m_IsLecturerFN; }
        set { m_IsLecturerFN = value; }
    }
    public string IsChangingRequiredFN
    {
        get { return m_IsChangingRequiredFN; }
        set { m_IsChangingRequiredFN = value; }
    }

    public string CampusFN
    {
        get { return m_CampusFN; }
        set { m_CampusFN = value; }
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
    public string RoleIDFN
    {
        get { return m_RoleIDFN; }
        set { m_RoleIDFN = value; }
    }
    #endregion
    //================End Properties ===================
    public UserDAL()
    {
        try
        {
            this.TableName = "Cmn_User";
            this.UserNoFN = m_TableName + ".UserNo";
            this.UserNameFN = m_TableName + ".UserName";
            this.PasswordFN = m_TableName + ".Password";
            this.EmployeeIDFN = m_TableName + ".EmployeeID";
            this.UILanguageFN = m_TableName + ".UILanguage";
            this.AcademicYearFN = m_TableName + ".AcademicYear";
            this.SemesterFN = m_TableName + ".Semester";
            this.MarksYearFN = m_TableName + ".MarksYear";
            this.MarksSemesterFN = m_TableName + ".MarksSemester";
            this.GradesPCNameFN = m_TableName + ".GradesPCName";
            this.ADUserNameFN = m_TableName + ".ADUserName";
            this.IsActiveFN = m_TableName + ".IsActive";
            this.LastLoginDateFN = m_TableName + ".LastLoginDate";
            this.LastLoginTimeFN = m_TableName + ".LastLoginTime";
            this.AllowedCampusFN = m_TableName + ".AllowedCampus";
            this.LecturerIDFN = m_TableName + ".LecturerID";

            this.IsLecturerFN = m_TableName + ".isLecturer";
            this.IsChangingRequiredFN = m_TableName + ".isChangingRequired";
            this.CampusFN = m_TableName + ".Campus";

            this.CreationUserIDFN = m_TableName + ".CreationUserID";
            this.CreationDateFN = m_TableName + ".CreationDate";
            this.LastUpdateUserIDFN = m_TableName + ".LastUpdateUserID";
            this.LastUpdateDateFN = m_TableName + ".LastUpdateDate";
            this.PCNameFN = m_TableName + ".PCName";
            this.NetUserNameFN = m_TableName + ".NetUserName";
            //this.RoleIDFN = m_TableName + ".RoleID";
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
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += UserNoFN;
            sSQL += " , " + UserNameFN;
            sSQL += " , " + PasswordFN;
            sSQL += " , " + EmployeeIDFN;
            sSQL += " , " + UILanguageFN;
            sSQL += " , " + AcademicYearFN;
            sSQL += " , " + SemesterFN;
            sSQL += " , " + MarksYearFN;
            sSQL += " , " + MarksSemesterFN;
            sSQL += " , " + GradesPCNameFN;
            sSQL += " , " + ADUserNameFN;
            sSQL += " , " + IsActiveFN;
            sSQL += " , " + LastLoginDateFN;
            sSQL += " , " + LastLoginTimeFN;
            sSQL += " , " + AllowedCampusFN;
            sSQL += " , " + LecturerIDFN;

            sSQL += " , " + IsLecturerFN;
            sSQL += " , " + IsChangingRequiredFN;
            sSQL += " , " + CampusFN;

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

    public string GetListSQL(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += UserNoFN;
            sSQL += " , " + UserNameFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += sWhere;
            sSQL += " Order By " + UserNameFN;
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

    public string GetFactorsSQL(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += UserNoFN;
            sSQL += " , " + AcademicYearFN;
            sSQL += " , " + SemesterFN;
            sSQL += " , " + CampusFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += sWhere;
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

    public string GetRoleUsersSQL(int RoleID, string sCondition)
    {
        string sSQL = "SELECT U.UserNo, U.UserName, U.Password, U.EmployeeID, U.UILanguage, U.AcademicYear,";
        sSQL += " U.Semester, U.MarksYear, U.MarksSemester,U.GradesPCName, U.IsActive,U.LecturerID, U.isLecturer, U.isChangingRequired,U.Campus, ";
        sSQL += " U.LastLoginDate, U.LastLoginTime";
        sSQL += " FROM Cmn_User AS U INNER JOIN Cmn_UserRoles AS UR ON U.UserNo = UR.UserNo";
        sSQL += " Where UR.RoleID=" + RoleID;
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }

        sSQL += " Order By U.UserName";

        return sSQL;
    }
    //-----Get GetSelectCommand Function -----------------------
    public string GetSelectCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += UserNoFN;
            sSQL += " , " + UserNameFN;
            sSQL += " , " + PasswordFN;
            sSQL += " , " + EmployeeIDFN;
            sSQL += " , " + UILanguageFN;
            sSQL += " , " + AcademicYearFN;
            sSQL += " , " + SemesterFN;
            sSQL += " , " + MarksYearFN;
            sSQL += " , " + MarksSemesterFN;
            sSQL += " , " + GradesPCNameFN;
            sSQL += " , " + ADUserNameFN;
            sSQL += " , " + IsActiveFN;
            sSQL += " , " + LastLoginDateFN;
            sSQL += " , " + LastLoginTimeFN;
            sSQL += " , " + AllowedCampusFN;
            sSQL += " , " + LecturerIDFN;

            sSQL += " , " + IsLecturerFN;
            sSQL += " , " + IsChangingRequiredFN;
            sSQL += " , " + CampusFN;

            sSQL += " , " + CreationUserIDFN;
            sSQL += " , " + CreationDateFN;
            sSQL += " , " + LastUpdateUserIDFN;
            sSQL += " , " + LastUpdateDateFN;
            sSQL += " , " + PCNameFN;
            sSQL += " , " + NetUserNameFN;
            //sSQL += " , " + RoleIDFN;
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
    public string GetUpdateCommand(string Password)
    {
        string sSQL = "";
        try
        {
            sSQL = "UPDATE " + TableName;
            sSQL += " SET ";
            sSQL += LibraryMOD.GetFieldName(UserNoFN) + "=@UserNo";
            sSQL += " , " + LibraryMOD.GetFieldName(UserNameFN) + "=@UserName";

            if (Password != "" && Password !=null )
            {
               sSQL += " , " + LibraryMOD.GetFieldName(PasswordFN) + "=@Password";
            }
                 
            sSQL += " , " + LibraryMOD.GetFieldName(EmployeeIDFN) + "=@EmployeeID";
            sSQL += " , " + LibraryMOD.GetFieldName(UILanguageFN) + "=@UILanguage";
            sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN) + "=@AcademicYear";
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN) + "=@Semester";
            sSQL += " , " + LibraryMOD.GetFieldName(MarksYearFN) + "=@MarksYear";
            sSQL += " , " + LibraryMOD.GetFieldName(MarksSemesterFN) + "=@MarksSemester";
            sSQL += " , " + LibraryMOD.GetFieldName(GradesPCNameFN) + "=@GradesPCName";
            sSQL += " , " + LibraryMOD.GetFieldName(ADUserNameFN) + "=@ADUserName";
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
            sSQL += " , " + LibraryMOD.GetFieldName(LastLoginDateFN) + "=@LastLoginDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastLoginTimeFN) + "=@LastLoginTime";
            sSQL += " , " + LibraryMOD.GetFieldName(AllowedCampusFN) + "=@AllowedCampus";
            sSQL += " , " + LibraryMOD.GetFieldName(LecturerIDFN) + "=@LecturerID";

            sSQL += " , " + LibraryMOD.GetFieldName(IsLecturerFN) + "=@IsLecturer";
            sSQL += " , " + LibraryMOD.GetFieldName(IsChangingRequiredFN) + "=@IsChangingRequired";
            sSQL += " , " + LibraryMOD.GetFieldName(CampusFN) + "=@Campus";

            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN) + "=@CreationUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN) + "=@CreationDate";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN) + "=@LastUpdateUserID";
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN) + "=@LastUpdateDate";
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN) + "=@PCName";
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN) + "=@NetUserName";
            //sSQL += " , " + LibraryMOD.GetFieldName(RoleIDFN) + "=@RoleID";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(UserNoFN) + "=@UserNo";
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
            sSQL += LibraryMOD.GetFieldName(UserNoFN);
            sSQL += " , " + LibraryMOD.GetFieldName(UserNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PasswordFN);
            sSQL += " , " + LibraryMOD.GetFieldName(EmployeeIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(UILanguageFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AcademicYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(SemesterFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MarksYearFN);
            sSQL += " , " + LibraryMOD.GetFieldName(MarksSemesterFN);
            sSQL += " , " + LibraryMOD.GetFieldName(GradesPCNameFN) ;
            sSQL += " , " + LibraryMOD.GetFieldName(ADUserNameFN);

            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastLoginDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastLoginTimeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(AllowedCampusFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LecturerIDFN);

            sSQL += " , " + LibraryMOD.GetFieldName(IsLecturerFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsChangingRequiredFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CampusFN);

            sSQL += " , " + LibraryMOD.GetFieldName(CreationUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(CreationDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateUserIDFN);
            sSQL += " , " + LibraryMOD.GetFieldName(LastUpdateDateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(PCNameFN);
            sSQL += " , " + LibraryMOD.GetFieldName(NetUserNameFN);
            //sSQL += " , " + LibraryMOD.GetFieldName(RoleIDFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @UserNo";
            sSQL += " ,@UserName";
            sSQL += " ,@Password";
            sSQL += " ,@EmployeeID";
            sSQL += " ,@UILanguage";
            sSQL += " ,@AcademicYear";
            sSQL += " ,@Semester";
            sSQL += " ,@MarksYear";
            sSQL += " ,@MarksSemester";
            sSQL += " ,@GradesPCName";
            sSQL += " ,@ADUserName";
            sSQL += " ,@IsActive";
            sSQL += " ,@LastLoginDate";
            sSQL += " ,@LastLoginTime";
            sSQL += " ,@AllowedCampus";
            sSQL += " ,@LecturerID";

            sSQL += " ,@IsLecturer";
            sSQL += " ,@IsChangingRequired";
            sSQL += " ,@Campus";

            sSQL += " ,@CreationUserID";
            sSQL += " ,@CreationDate";
            sSQL += " ,@LastUpdateUserID";
            sSQL += " ,@LastUpdateDate";
            sSQL += " ,@PCName";
            sSQL += " ,@NetUserName";
            //sSQL += " ,@RoleID";
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
            sSQL += LibraryMOD.GetFieldName(UserNoFN) + "=@UserNo";
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



    //    public List< User> GetUser(InitializeModule.EnumCampus Campus ,string sCondition,bool isDeafaultIncluded)
    //{
    ////' returns a list of Classes instances based on the
    ////' data in the User
    //Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    //string  sSQL = GetSQL();
    //if (!string.IsNullOrEmpty(sCondition))
    //{
    //sSQL += sCondition;
    //}
    //SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    //SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    //Conn.Open();
    //SqlDataReader reader  = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //List<User> results = new List<User>();
    //try
    //{
    ////Default Value
    //User myUser = new User();
    //if (isDeafaultIncluded)
    //{
    ////Change the code here
    //myUser.UserNo = 0;
    //myUser.UserName = "Select User ...";
    //results.Add(myUser);
    //}
    //while (reader.Read())
    //{
    //myUser = new User();
    //if (reader[LibraryMOD.GetFieldName(UserNoFN)].Equals(DBNull.Value))
    //{
    //myUser.UserNo = 0;
    //}
    //else
    //{
    //myUser.UserNo = int.Parse(reader[LibraryMOD.GetFieldName( UserNoFN) ].ToString());
    //}
    //myUser.UserName =reader[LibraryMOD.GetFieldName( UserNameFN) ].ToString();
    //myUser.Password =reader[LibraryMOD.GetFieldName( PasswordFN) ].ToString();
    //if (reader[LibraryMOD.GetFieldName(EmployeeIDFN)].Equals(DBNull.Value))
    //{
    //myUser.EmployeeID = 0;
    //}
    //else
    //{
    //myUser.EmployeeID = int.Parse(reader[LibraryMOD.GetFieldName( EmployeeIDFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(UILanguageFN)].Equals(DBNull.Value))
    //{
    //myUser.UILanguage = 0;
    //}
    //else
    //{
    //myUser.UILanguage = int.Parse(reader[LibraryMOD.GetFieldName( UILanguageFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(AcademicYearFN)].Equals(DBNull.Value))
    //{
    //myUser.AcademicYear = 0;
    //}
    //else
    //{
    //myUser.AcademicYear = int.Parse(reader[LibraryMOD.GetFieldName( AcademicYearFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(SemesterFN)].Equals(DBNull.Value))
    //{
    //myUser.Semester = 0;
    //}
    //else
    //{
    //myUser.Semester = int.Parse(reader[LibraryMOD.GetFieldName( SemesterFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(MarksYearFN)].Equals(DBNull.Value))
    //{
    //myUser.MarksYear = 0;
    //}
    //else
    //{
    //myUser.MarksYear = int.Parse(reader[LibraryMOD.GetFieldName( MarksYearFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(MarksSemesterFN)].Equals(DBNull.Value))
    //{
    //myUser.MarksSemester = 0;
    //}
    //else
    //{
    //myUser.MarksSemester = int.Parse(reader[LibraryMOD.GetFieldName( MarksSemesterFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(IsActiveFN)].Equals(DBNull.Value))
    //{
    //myUser.IsActive = 0;
    //}
    //else
    //{
    //myUser.IsActive = int.Parse(reader[LibraryMOD.GetFieldName( IsActiveFN) ].ToString());
    //}
    //myUser.LastLoginDate =reader[LibraryMOD.GetFieldName( LastLoginDateFN) ].ToString();
    //if (reader[LibraryMOD.GetFieldName(LastLoginTimeFN)].Equals(DBNull.Value))
    //{
    //myUser.LastLoginTime = 0;
    //}
    //else
    //{
    //myUser.LastLoginTime = int.Parse(reader[LibraryMOD.GetFieldName( LastLoginTimeFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(LecturerIDFN)].Equals(DBNull.Value))
    //{
    //myUser.LecturerID = 0;
    //}
    //else
    //{
    //myUser.LecturerID = int.Parse(reader[LibraryMOD.GetFieldName( LecturerIDFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(CreationUserIDFN)].Equals(DBNull.Value))
    //{
    //myUser.CreationUserID = 0;
    //}
    //else
    //{
    //myUser.CreationUserID = int.Parse(reader[LibraryMOD.GetFieldName( CreationUserIDFN) ].ToString());
    //}
    //if (!reader[LibraryMOD.GetFieldName(CreationDateFN)].Equals(DBNull.Value))
    //{
    //myUser.CreationDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( CreationDateFN) ].ToString());
    //}
    //if (reader[LibraryMOD.GetFieldName(LastUpdateUserIDFN)].Equals(DBNull.Value))
    //{
    //myUser.LastUpdateUserID = 0;
    //}
    //else
    //{
    //myUser.LastUpdateUserID = int.Parse(reader[LibraryMOD.GetFieldName( LastUpdateUserIDFN) ].ToString());
    //}
    //if (!reader[LibraryMOD.GetFieldName(LastUpdateDateFN)].Equals(DBNull.Value))
    //{
    //myUser.LastUpdateDate = DateTime.Parse(reader[LibraryMOD.GetFieldName( LastUpdateDateFN) ].ToString());
    //}
    //myUser.PCName =reader[LibraryMOD.GetFieldName( PCNameFN) ].ToString();
    //myUser.NetUserName =reader[LibraryMOD.GetFieldName( NetUserNameFN) ].ToString();
    //if (reader[LibraryMOD.GetFieldName(RoleIDFN)].Equals(DBNull.Value))
    //{
    //myUser.RoleID = 0;
    //}
    //else
    //{
    //myUser.RoleID = int.Parse(reader[LibraryMOD.GetFieldName( RoleIDFN) ].ToString());
    //}
    // results.Add(myUser);
    //}
    //}
    //catch (Exception ex)
    //{
    //LibraryMOD.ShowErrorMessage(ex);
    //}
    //finally
    //{
    //reader.Close();
    //reader.Dispose();
    //Conn.Close();
    //Conn.Dispose();
    //}
    //return results;
    //}
    //public int UpdateUser(InitializeModule.EnumCampus Campus, int iMode,int UserNo,string UserName,string Password,int EmployeeID,int UILanguage,int AcademicYear,int Semester,int MarksYear,int MarksSemester,int IsActive,string LastLoginDate,int LastLoginTime,int LecturerID,int CreationUserID,DateTime CreationDate,int LastUpdateUserID,DateTime LastUpdateDate,string PCName,string NetUserName,int RoleID)
    //{
    //int iEffected = 0;
    //Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    //SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    //try
    //{
    //Conn.Open();
    //string sql = "";
    //User theUser = new User();
    ////'Updates the  table
    //switch(iMode) 
    //  {
    //  case  (int)InitializeModule.enumModes.EditMode:
    //      sql = GetUpdateCommand();
    //      break ;
    //  case (int)InitializeModule.enumModes.NewMode:
    //      sql = GetInsertCommand();
    //      break ;
    //  }
    //SqlCommand Cmd = new SqlCommand(sql, Conn);
    //Cmd.Parameters.Add(new SqlParameter("@UserNo",UserNo));
    //Cmd.Parameters.Add(new SqlParameter("@UserName",UserName));
    //Cmd.Parameters.Add(new SqlParameter("@Password",Password));
    //Cmd.Parameters.Add(new SqlParameter("@EmployeeID",EmployeeID));
    //Cmd.Parameters.Add(new SqlParameter("@UILanguage",UILanguage));
    //Cmd.Parameters.Add(new SqlParameter("@AcademicYear",AcademicYear));
    //Cmd.Parameters.Add(new SqlParameter("@Semester",Semester));
    //Cmd.Parameters.Add(new SqlParameter("@MarksYear",MarksYear));
    //Cmd.Parameters.Add(new SqlParameter("@MarksSemester",MarksSemester));
    //Cmd.Parameters.Add(new SqlParameter("@IsActive",IsActive));
    //Cmd.Parameters.Add(new SqlParameter("@LastLoginDate",LastLoginDate));
    //Cmd.Parameters.Add(new SqlParameter("@LastLoginTime",LastLoginTime));
    //Cmd.Parameters.Add(new SqlParameter("@LecturerID",LecturerID));
    //Cmd.Parameters.Add(new SqlParameter("@CreationUserID",CreationUserID));
    //Cmd.Parameters.Add(new SqlParameter("@CreationDate",CreationDate));
    //Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID",LastUpdateUserID));
    //Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate",LastUpdateDate));
    //Cmd.Parameters.Add(new SqlParameter("@PCName",PCName));
    //Cmd.Parameters.Add(new SqlParameter("@NetUserName",NetUserName));
    //Cmd.Parameters.Add(new SqlParameter("@RoleID",RoleID));
    //iEffected = Cmd.ExecuteNonQuery();
    //}
    //catch (Exception ex)
    //{
    //LibraryMOD.ShowErrorMessage(ex);
    //}
    //finally
    //{
    //Conn.Close();
    //Conn.Dispose();
    //}
    //return iEffected;
    //}
    //public int DeleteUser(InitializeModule.EnumCampus Campus,string UserNo)
    //{
    //int iEffected = 0;
    //Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
    //SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
    //try
    //{
    //string sSQL = GetDeleteCommand();
    ////sSQL += sCondition;
    //SqlCommand Cmd = new SqlCommand(sSQL, Conn);
    //Cmd.Parameters.Add(new SqlParameter("@UserNo", UserNo ));
    //Conn.Open();
    //iEffected = Cmd.ExecuteNonQuery();
    //}
    //catch (Exception ex)
    //{
    //LibraryMOD.ShowErrorMessage(ex);
    //}
    //finally
    //{
    //Conn.Close();
    //Conn.Dispose();
    //}
    //return iEffected;
    //}
    //public DataView GetDataView(bool isFromRole,int PK,string sCondition)
    //{
    //DataTable dt = new DataTable("User");
    //DataView dv = new DataView();
    //List<User> myUsers = new List<User>();
    //try
    //{
    //myUsers = GetUser(InitializeModule.EnumCampus.ECTNew,sCondition,false);
    //DataColumn col1= new DataColumn("UserNo", Type.GetType("int"));
    //dt.Columns.Add(col1 );
    //DataColumn col2= new DataColumn("UserName", Type.GetType("nvarchar"));
    //dt.Columns.Add(col2 );
    //DataColumn col3= new DataColumn("Password", Type.GetType("nvarchar"));
    //dt.Columns.Add(col3 );
    //dt.Constraints.Add(new UniqueConstraint(col1));

    //DataRow dr;
    //for (int i = 0; i < myUsers.Count(); i++)
    //{
    //dr = dt.NewRow();
    //  dr[1] = myUsers[i].UserNo;
    //  dr[2] = myUsers[i].UserName;
    //  dr[3] = myUsers[i].Password;
    //  dt.Rows.Add(dr);
    //}
    //dt.AcceptChanges();
    //dv.Table = dt;
    //}
    //catch (Exception ex)
    //{
    //LibraryMOD.ShowErrorMessage(ex);
    //}
    //finally
    //{
    //myUsers.Clear();
    //}
    // return dv;
    //}



    public List<User> GetUser(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the User
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

        string sSQL = GetSQL();
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<User> result = new List<User>();
        try
        {
            //Default Value
            User myUser = new User();
            if (isDeafaultIncluded)
            {
                myUser.UserNo = 0;
                myUser.UserName = "Select User ...";
                result.Add(myUser);
            }
            while (Rd.Read())
            {
                myUser = new User();
                myUser.UserNo = int.Parse(Rd["UserNo"].ToString());
                myUser.UserName = Rd["UserName"].ToString();
                myUser.Password = Rd["Password"].ToString();
                if (Rd["EmployeeID"].Equals(DBNull.Value))
                {
                    myUser.EmployeeID = 0;
                }
                else
                {
                    myUser.EmployeeID = int.Parse(Rd["EmployeeID"].ToString());
                }

                if (Rd["UILanguage"].Equals(DBNull.Value))
                {
                    myUser.UILanguage = 0;
                }
                else
                {
                    myUser.UILanguage = int.Parse(Rd["UILanguage"].ToString());
                }


                if (Rd["AcademicYear"].Equals(DBNull.Value))
                {
                    myUser.AcademicYear = 0;
                }
                else
                {
                    myUser.AcademicYear = int.Parse(Rd["AcademicYear"].ToString());
                }

                if (Rd["Semester"].Equals(DBNull.Value))
                {
                    myUser.Semester = 0;
                }
                else
                {
                    myUser.Semester = int.Parse(Rd["Semester"].ToString());
                }

                if (Rd["MarksYear"].Equals(DBNull.Value))
                {
                    myUser.MarksYear = 0;
                }
                else
                {
                    myUser.MarksYear = int.Parse(Rd["MarksYear"].ToString());
                }

                if (Rd["MarksSemester"].Equals(DBNull.Value))
                {
                    myUser.MarksSemester = 0;
                }
                else
                {
                    myUser.MarksSemester = int.Parse(Rd["MarksSemester"].ToString());
                }

                if (Rd["GradesPCName"].Equals(DBNull.Value))
                {
                    myUser.GradesPCName = "";
                }
                else
                {
                    myUser.GradesPCName = Rd["GradesPCName"].ToString();
                }
                if (Rd["ADUserName"].Equals(DBNull.Value))
                {
                    myUser.ADUserName = "";
                }
                else
                {
                    myUser.ADUserName = Rd["ADUserName"].ToString();
                }

                if (Rd["IsActive"].Equals(DBNull.Value))
                {
                    myUser.IsActive = 0;
                }
                else
                {
                    myUser.IsActive = int.Parse(Rd["IsActive"].ToString());
                }

                if (!Rd["LastLoginDate"].Equals(DBNull.Value))
                {
                    myUser.LastLoginDate = DateTime.Parse(Rd["LastLoginDate"].ToString());
                }


                if (!Rd["LastLoginTime"].Equals(DBNull.Value))
                {
                    myUser.LastLoginTime = 0; //DateTime.Parse(Rd["LastLoginTime"].ToString());
                }
                
                if (Rd["AllowedCampus"].Equals(DBNull.Value))
                {
                    myUser.AllowedCampus = -1;
                }
                else
                {
                    myUser.AllowedCampus = int.Parse(Rd["AllowedCampus"].ToString());
                }
                if (Rd["LecturerID"].Equals(DBNull.Value))
                {
                    myUser.LecturerID = 0;
                }
                else
                {
                    myUser.LecturerID = int.Parse(Rd["LecturerID"].ToString());
                }


                if (Rd["IsLecturer"].Equals(DBNull.Value))
                {
                    myUser.IsLecturer = false;
                }
                else
                {
                    myUser.IsLecturer = Convert.ToBoolean(Rd["IsLecturer"]);
                }


                if (Rd["IsChangingRequired"].Equals(DBNull.Value))
                {
                    myUser.IsChangingRequired = 0;
                }
                else
                {
                    myUser.IsChangingRequired = Convert.ToByte(Rd["IsChangingRequired"]);
                }

                if (Rd["Campus"].Equals(DBNull.Value))
                {
                    myUser.Campus = 1;
                }
                else
                {
                    myUser.Campus = Convert.ToInt32(Rd["Campus"]);
                }

                if (Rd["CreationUserID"].Equals(DBNull.Value))
                {
                    myUser.CreationUserID = 0;
                }
                else
                {
                    myUser.CreationUserID = int.Parse(Rd["CreationUserID"].ToString());
                }

                if (!Rd["CreationDate"].Equals(DBNull.Value))
                {
                    myUser.CreationDate = DateTime.Parse(Rd["CreationDate"].ToString());
                }

                if (Rd["LastUpdateUserID"].Equals(DBNull.Value))
                {
                    myUser.LastUpdateUserID = 0;
                }
                else
                {
                    myUser.LastUpdateUserID = int.Parse(Rd["LastUpdateUserID"].ToString());
                }

                if (!Rd["LastUpdateDate"].Equals(DBNull.Value))
                {
                    myUser.LastUpdateDate = DateTime.Parse(Rd["LastUpdateDate"].ToString());
                }

                myUser.PCName = Rd["PCName"].ToString();
                myUser.NetUserName = Rd["NetUserName"].ToString();
                result.Add(myUser);
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }

        finally
        {
            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return result;
    }

    public List<User> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the User
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

        string sSQL = GetListSQL(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<User> result = new List<User>();
        try
        {
            //Default Value
            User myUser = new User();
            if (isDeafaultIncluded)
            {
                myUser.UserNo = 0;
                myUser.UserName = "Select User ...";
                result.Add(myUser);
            }
            while (Rd.Read())
            {
                myUser = new User();
                myUser.UserNo = int.Parse(Rd["UserNo"].ToString());
                myUser.UserName = Rd["UserName"].ToString();
                result.Add(myUser);
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }

        finally
        {
            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return result;
    }

    public List<User> GetUserFactors(int iUser)
    {
        //' returns a list of Classes instances based on the
        //' data in the User
        Connection_StringCLS MyConnection_string = new Connection_StringCLS( InitializeModule.EnumCampus.ECTNew );

        string sSQL = GetFactorsSQL(" Where " + LibraryMOD.GetFieldName(UserNoFN) + "=" + iUser);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<User> result = new List<User>();
        try
        {
            //Default Value
            User myUser = new User();
            
            while (Rd.Read())
            {
                myUser = new User();
                myUser.UserNo = int.Parse(Rd["UserNo"].ToString());
                myUser.AcademicYear =Convert.ToInt32( Rd["AcademicYear"]);
                myUser.Semester = Convert.ToInt32(Rd["Semester"]);
                myUser.Campus = Convert.ToInt32(Rd["Campus"]);
                result.Add(myUser);
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }

        finally
        {
            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return result;
    }
    public int UpdateUser(InitializeModule.EnumCampus Campus, int iMode, int UserNo,
        string UserName, string Password, int EmployeeID, int UILanguage, 
        int AcademicYear, int Semester, int MarksYear, int MarksSemester,
        string GradesPCName, string sADUserName, int IsActive, byte IsChangingPasswordRequired, DateTime LastLoginDate, 
        int LastLoginTime,int iAllowedCampus, int LecturerID, int CreationUserID, DateTime CreationDate, 
        int LastUpdateUserID, DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            //InitializeModule.EnumCampus iCampus ; 
            //iCampus = Campus;

            Conn.Open();
            string sSQL = "";
            UserCls theUser = new UserCls();
            //'Updates the  table
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    sSQL = GetUpdateCommand(Password);
                    break;
                case (int)InitializeModule.enumModes.NewMode:
                    sSQL = GetInsertCommand();
                    break;
            }


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    if (Password != "" && Password != null)
                    {
                        Cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    }
                    break;

                default:
                    Cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    break;

            }

     
            Cmd.Parameters.Add(new SqlParameter("@UserNo", UserNo));
            Cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
            
            Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
            Cmd.Parameters.Add(new SqlParameter("@UILanguage", UILanguage));
            Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear));
            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
            Cmd.Parameters.Add(new SqlParameter("@MarksYear", MarksYear));
            Cmd.Parameters.Add(new SqlParameter("@MarksSemester", MarksSemester));
            Cmd.Parameters.Add(new SqlParameter("@GradesPCName", GradesPCName));
            Cmd.Parameters.Add(new SqlParameter("@ADUserName", sADUserName));
            Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
            Cmd.Parameters.Add(new SqlParameter("@isChangingRequired", IsChangingPasswordRequired));
            
            Cmd.Parameters.Add(new SqlParameter("@LastLoginDate", DateTime.Now));
            Cmd.Parameters.Add(new SqlParameter("@LastLoginTime", LastLoginTime));
            Cmd.Parameters.Add(new SqlParameter("@AllowedCampus", iAllowedCampus));
            Cmd.Parameters.Add(new SqlParameter("@LecturerID", LecturerID));

            Cmd.Parameters.Add(new SqlParameter("@IsLecturer", IsLecturer));
           
            Cmd.Parameters.Add(new SqlParameter("@Campus",(int) Campus));

            Cmd.Parameters.Add(new SqlParameter("@CreationUserID", CreationUserID));
            Cmd.Parameters.Add(new SqlParameter("@CreationDate", CreationDate));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateUserID", LastUpdateUserID));
            Cmd.Parameters.Add(new SqlParameter("@LastUpdateDate", DateTime.Now));
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
    
    public int UpdateUser(InitializeModule.EnumCampus Campus, int iMode, int UserNo, string UserName, 
        string Password, int EmployeeID, int UILanguage, int AcademicYear, int Semester, int MarksYear,
        int MarksSemester, string GradesPCName, string sADUserName, int IsActive, DateTime LastLoginDate, int LastLoginTime, int AllowedCampus, int LecturerID, Boolean IsLecturer,
        byte IsChangingRequired,int UserCampus, int CreationUserID, DateTime CreationDate, int LastUpdateUserID, 
        DateTime LastUpdateDate, string PCName, string NetUserName)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            //InitializeModule.EnumCampus iCampus ; 
            //iCampus = Campus;

            Conn.Open();
            string sSQL = "";
            UserCls theUser = new UserCls();
            //'Updates the  table
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    sSQL = GetUpdateCommand(Password);
                    break;
                case (int)InitializeModule.enumModes.NewMode:
                    sSQL = GetInsertCommand();
                    break;
            }
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            switch (iMode)
            {
                case (int)InitializeModule.enumModes.EditMode:
                    if (Password != "" && Password != null)
                    {
                        Cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    }
                    break;

                default:
                    Cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    break;

            }

 
            Cmd.Parameters.Add(new SqlParameter("@UserNo", UserNo));
            Cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
            
            Cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
            Cmd.Parameters.Add(new SqlParameter("@UILanguage", UILanguage));
            Cmd.Parameters.Add(new SqlParameter("@AcademicYear", AcademicYear));
            Cmd.Parameters.Add(new SqlParameter("@Semester", Semester));
            Cmd.Parameters.Add(new SqlParameter("@MarksYear", MarksYear));
            Cmd.Parameters.Add(new SqlParameter("@MarksSemester", MarksSemester));
            Cmd.Parameters.Add(new SqlParameter("@GradesPCName", GradesPCName));
            Cmd.Parameters.Add(new SqlParameter("@ADUserName", sADUserName));
            Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
            Cmd.Parameters.Add(new SqlParameter("@LastLoginDate", LastLoginDate));
            Cmd.Parameters.Add(new SqlParameter("@LastLoginTime", LastLoginTime));
            Cmd.Parameters.Add(new SqlParameter("@AllowedCampus", AllowedCampus));
            Cmd.Parameters.Add(new SqlParameter("@LecturerID", LecturerID));

            Cmd.Parameters.Add(new SqlParameter("@IsLecturer", IsLecturer));
            Cmd.Parameters.Add(new SqlParameter("@IsChangingRequired", IsChangingRequired));
            Cmd.Parameters.Add(new SqlParameter("@Campus", UserCampus));

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

    public int DeleteUser(InitializeModule.EnumCampus Campus, int UserNo)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();

            string sSQL = GetDeleteCommand();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@UserNo", UserNo));

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
    public DataView GetDataView(bool isFromRole, int RoleID, string sCondition)
    {
        DataTable dt = new DataTable("Users");
        DataView dv = new DataView();
        List<User> myUsers = new List<User>();
        try
        {
            if (!isFromRole)
            {
                myUsers = GetList(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            }
            else
            {
                myUsers = GetRoleUsers(InitializeModule.EnumCampus.ECTNew, RoleID, sCondition, false);
            }

            DataColumn col1 = new DataColumn("UserNo", Type.GetType("System.Int32"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("UserName", Type.GetType("System.String"));
            dt.Columns.Add(col2);
            dt.Constraints.Add(new UniqueConstraint(col1));

            //DataColumn col3= new DataColumn("Password", Type.GetType("nvarchar"));
            //dt.Columns.Add(col3 );

            DataRow dr;
            for (int i = 0; i < myUsers.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = myUsers[i].UserNo;
                dr[1] = myUsers[i].UserName;
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
            myUsers.Clear();
        }
        return dv;
    }
    public List<User> GetRoleUsers(InitializeModule.EnumCampus Campus, int RoleID, string sCondition, bool isDefaultIncluded)
    {

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

        string sSQL = GetRoleUsersSQL(RoleID, sCondition);
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<User> result = new List<User>();
        try
        {
            User myUser = new User();
            if (isDefaultIncluded)
            {
                myUser.UserNo = 0;
                myUser.UserName = "Select User ...";
                result.Add(myUser);
            }
            while (Rd.Read())
            {
                myUser = new UserCls();

                myUser.UserNo = int.Parse(Rd["UserNo"].ToString());
                myUser.UserName = Rd["UserName"].ToString();
                myUser.Password = Rd["Password"].ToString();


                if (Rd["EmployeeID"].Equals(DBNull.Value))
                {
                    myUser.EmployeeID = 0;
                }
                else
                {
                    myUser.EmployeeID = int.Parse(Rd["EmployeeID"].ToString());
                }

                if (Rd["UILanguage"].Equals(DBNull.Value))
                {
                    myUser.UILanguage = 0;
                }
                else
                {
                    myUser.UILanguage = int.Parse(Rd["UILanguage"].ToString());
                }


                if (Rd["AcademicYear"].Equals(DBNull.Value))
                {
                    myUser.AcademicYear = 0;
                }
                else
                {
                    myUser.AcademicYear = int.Parse(Rd["AcademicYear"].ToString());
                }

                if (Rd["Semester"].Equals(DBNull.Value))
                {
                    myUser.Semester = 0;
                }
                else
                {
                    myUser.Semester = int.Parse(Rd["Semester"].ToString());
                }

                if (Rd["MarksYear"].Equals(DBNull.Value))
                {
                    myUser.MarksYear = 0;
                }
                else
                {
                    myUser.MarksYear = int.Parse(Rd["MarksYear"].ToString());
                }

                if (Rd["MarksSemester"].Equals(DBNull.Value))
                {
                    myUser.MarksSemester = 0;
                }
                else
                {
                    myUser.MarksSemester = int.Parse(Rd["MarksSemester"].ToString());
                }

                myUser.GradesPCName = Rd["GradesPCName"].ToString();

                if (Rd["IsActive"].Equals(DBNull.Value))
                {
                    myUser.IsActive = 0;
                }
                else
                {
                    myUser.IsActive = int.Parse(Rd["IsActive"].ToString());
                }

                if (!Rd["LastLoginDate"].Equals(DBNull.Value))
                {
                    myUser.LastLoginDate =  DateTime.Parse(Rd["LastLoginDate"].ToString());
                }


                if (!Rd["LastLoginTime"].Equals(DBNull.Value))
                {
                    myUser.LastLoginTime = 0;//DateTime.Parse(Rd["LastLoginTime"].ToString());
                }

                if (Rd["AllowedCampus"].Equals(DBNull.Value))
                {
                    myUser.AllowedCampus = -1;
                }
                else
                {
                    myUser.AllowedCampus = int.Parse(Rd["AllowedCampus"].ToString());
                }

                if (Rd["LecturerID"].Equals(DBNull.Value))
                {
                    myUser.LecturerID = 0;
                }
                else
                {
                    myUser.LecturerID = int.Parse(Rd["LecturerID"].ToString());
                }

                if (Rd["IsLecturer"].Equals(DBNull.Value))
                {
                    myUser.IsLecturer = false;
                }
                else
                {
                    myUser.IsLecturer = Convert.ToBoolean(Rd["IsLecturer"]);
                }

                if (Rd["IsChangingRequired"].Equals(DBNull.Value))
                {
                    myUser.IsChangingRequired= 0;
                }
                else
                {
                    myUser.IsChangingRequired = Convert.ToByte(Rd["IsChangingRequired"]);
                }

                if (Rd["Campus"].Equals(DBNull.Value))
                {
                    myUser.Campus = 1;
                }
                else
                {
                    myUser.Campus= Convert.ToInt32 (Rd["Campus"]);
                }

                //if (Rd["CreationUserID"].Equals(DBNull.Value))
                //{
                //    myUser.CreationUserID = 0;
                //}
                //else
                //{
                //    myUser.CreationUserID = int.Parse(Rd["CreationUserID"].ToString());
                //}

                //if (!Rd["CreationDate"].Equals(DBNull.Value))
                //{
                //    myUser.CreationDate = DateTime.Parse(Rd["CreationDate"].ToString());
                //}

                //if (Rd["LastUpdateUserID"].Equals(DBNull.Value))
                //{
                //    myUser.LastUpdateUserID = 0;
                //}
                //else
                //{
                //    myUser.LastUpdateUserID = int.Parse(Rd["LastUpdateUserID"].ToString());
                //}

                //if (!Rd["LastUpdateDate"].Equals(DBNull.Value))
                //{
                //    myUser.LastUpdateDate = DateTime.Parse(Rd["LastUpdateDate"].ToString());
                //}

                //myUser.PCName = Rd["PCName"].ToString();
                //myUser.NetUserName = Rd["NetUserName"].ToString();
                result.Add(myUser);
            }
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }

        finally
        {
            Rd.Close();
            Rd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
        return result;
    }
    public int AddUsersToRole(int UserNo, int RoleID, SqlConnection Conn, string sUser)
    {
        int iEffected = 0;

        try
        {
            string sCheck = "Select UserNo From Cmn_UserRoles";
            sCheck += " Where UserNo=" + UserNo + " And RoleID=" + RoleID;
            SqlCommand Cmd = new SqlCommand(sCheck, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            if (Rd.HasRows == true)
            {
                iEffected = -1;
                Rd.Close();
                return iEffected;
            }
            Rd.Close();


            string sSQL = "INSERT INTO Cmn_UserRoles (UserNo,RoleID)";
            sSQL += " VALUES (@UserNo,@RoleID)";

            Cmd.CommandText = sSQL;

            Cmd.Parameters.Add(new SqlParameter("@UserNo", UserNo));
            Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));


            iEffected = Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            //Conn.Close();

        }
        return iEffected;
    }
    public int DeleteUsersFromRole(string sCondition, SqlConnection Conn, string sUser)
    {
        int iEffected = 0;

        try
        {


            string sSQL = "Delete from Cmn_UserRoles";
            if (!string.IsNullOrEmpty(sCondition))
            {
                sSQL += sCondition;
            }


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);


            iEffected = Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            //Conn.Close();

        }
        return iEffected;
    }
    public int GetUserRole(int UserID, int SystemID)
    {
        int RoleID = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT UR.RoleID ";
            sSQL += " FROM dbo.Cmn_UserRoles AS UR INNER JOIN dbo.Cmn_Role AS R ON UR.RoleID = R.RoleID";
            sSQL += " WHERE (UR.UserNo = " + UserID + ") AND (R.SystemID = " + SystemID + ")";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            int iReturn = 0;
            iReturn = int.Parse(Cmd.ExecuteScalar().ToString());
            RoleID = iReturn;
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
        return RoleID;

    }
    public int GetUserEmpID(int iUserNo)
    {
        int EmpID = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSQL = "";
            sSQL = "SELECT ";
            sSQL += EmployeeIDFN;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + UserNoFN + "=" + iUserNo;


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            int iReturn = 0;
            iReturn = int.Parse(Cmd.ExecuteScalar().ToString());
            EmpID = iReturn;
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
        return EmpID;

    }
    public string  GetUserGradesPCName(int iUserNo)
    {
        
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        string sReturn = "";
        try
        {

            string sSQL = "";
            sSQL = "SELECT ";
            sSQL += GradesPCNameFN ;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + UserNoFN + "=" + iUserNo;


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            

            sReturn = Cmd.ExecuteScalar().ToString();
           
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
        return sReturn;

    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con)
    {
        string sSQL = "";
        DataTable table = new DataTable();
        try
        {
            sSQL = "SELECT";
            sSQL += UserNoFN;
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
public class UserCls : UserDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daUser;
    private DataSet m_dsUser;
    public DataRow UserDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsUser
    {
        get { return m_dsUser; }
        set { m_dsUser = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public UserCls()
    {
        try
        {
            dsUser = new DataSet();

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
    public virtual SqlDataAdapter GetUserDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daUser = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daUser);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daUser.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daUser;
    }
    public virtual SqlDataAdapter GetUserDataAdapter(SqlConnection con)
    {
        try
        {
            daUser = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daUser.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdUser;
            cmdUser = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@UserNo", SqlDbType.Int, 4, "UserNo" );
            daUser.SelectCommand = cmdUser;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdUser = new SqlCommand(GetUpdateCommand(Password), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdUser.Parameters.Add("@UserNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(UserNoFN));
            cmdUser.Parameters.Add("@UserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(UserNameFN));
            cmdUser.Parameters.Add("@Password", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PasswordFN));
            cmdUser.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
            cmdUser.Parameters.Add("@UILanguage", SqlDbType.Int, 4, LibraryMOD.GetFieldName(UILanguageFN));
            cmdUser.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            cmdUser.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            cmdUser.Parameters.Add("@MarksYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MarksYearFN));
            cmdUser.Parameters.Add("@MarksSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MarksSemesterFN));
            cmdUser.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            cmdUser.Parameters.Add("@LastLoginDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastLoginDateFN));
            cmdUser.Parameters.Add("@LastLoginTime", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastLoginTimeFN));
            cmdUser.Parameters.Add("@LecturerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerIDFN));

            cmdUser.Parameters.Add("@IsLecturer", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsLecturerFN));
            cmdUser.Parameters.Add("@IsChangingRequired", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsChangingRequiredFN));

            cmdUser.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdUser.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdUser.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdUser.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdUser.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdUser.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            cmdUser.Parameters.Add("@RoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RoleIDFN));


            Parmeter = cmdUser.Parameters.Add("@UserNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(UserNoFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daUser.UpdateCommand = cmdUser;
            daUser.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------
            //'/INSERT COMMAND
            cmdUser = new SqlCommand(GetInsertCommand(), con);
            cmdUser.Parameters.Add("@UserNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(UserNoFN));
            cmdUser.Parameters.Add("@UserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(UserNameFN));
            cmdUser.Parameters.Add("@Password", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PasswordFN));
            cmdUser.Parameters.Add("@EmployeeID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(EmployeeIDFN));
            cmdUser.Parameters.Add("@UILanguage", SqlDbType.Int, 4, LibraryMOD.GetFieldName(UILanguageFN));
            cmdUser.Parameters.Add("@AcademicYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(AcademicYearFN));
            cmdUser.Parameters.Add("@Semester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(SemesterFN));
            cmdUser.Parameters.Add("@MarksYear", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MarksYearFN));
            cmdUser.Parameters.Add("@MarksSemester", SqlDbType.Int, 4, LibraryMOD.GetFieldName(MarksSemesterFN));
            cmdUser.Parameters.Add("@IsActive", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsActiveFN));
            cmdUser.Parameters.Add("@LastLoginDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastLoginDateFN));
            cmdUser.Parameters.Add("@LastLoginTime", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastLoginTimeFN));
            cmdUser.Parameters.Add("@LecturerID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LecturerIDFN));

            cmdUser.Parameters.Add("@IsLecturer", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsLecturerFN));
            cmdUser.Parameters.Add("@IsChangingRequired", SqlDbType.Int, 4, LibraryMOD.GetFieldName(IsChangingRequiredFN));

            cmdUser.Parameters.Add("@CreationUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(CreationUserIDFN));
            cmdUser.Parameters.Add("@CreationDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(CreationDateFN));
            cmdUser.Parameters.Add("@LastUpdateUserID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(LastUpdateUserIDFN));
            cmdUser.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(LastUpdateDateFN));
            cmdUser.Parameters.Add("@PCName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(PCNameFN));
            cmdUser.Parameters.Add("@NetUserName", SqlDbType.NVarChar, 32, LibraryMOD.GetFieldName(NetUserNameFN));
            cmdUser.Parameters.Add("@RoleID", SqlDbType.Int, 4, LibraryMOD.GetFieldName(RoleIDFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daUser.InsertCommand = cmdUser;
            daUser.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdUser = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdUser.Parameters.Add("@UserNo", SqlDbType.Int, 4, LibraryMOD.GetFieldName(UserNoFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daUser.DeleteCommand = cmdUser;
            daUser.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daUser.UpdateBatchSize = InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daUser;
    }
    //'-------SaveData  -----------------------------
    public int SaveData(int lFormMode)
    {
        //SaveData= InitializeModule.FAIL_RET;
        try
        {
            switch (lFormMode)
            {
                case (int)InitializeModule.enumModes.NewMode:
                    DataRow dr = default(DataRow);
                    dr = dsUser.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(UserNoFN)] = UserNo;
                    dr[LibraryMOD.GetFieldName(UserNameFN)] = UserName;
                    dr[LibraryMOD.GetFieldName(PasswordFN)] = Password;
                    dr[LibraryMOD.GetFieldName(EmployeeIDFN)] = EmployeeID;
                    dr[LibraryMOD.GetFieldName(UILanguageFN)] = UILanguage;
                    dr[LibraryMOD.GetFieldName(AcademicYearFN)] = AcademicYear;
                    dr[LibraryMOD.GetFieldName(SemesterFN)] = Semester;
                    dr[LibraryMOD.GetFieldName(MarksYearFN)] = MarksYear;
                    dr[LibraryMOD.GetFieldName(MarksSemesterFN)] = MarksSemester;
                    dr[LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
                    dr[LibraryMOD.GetFieldName(LastLoginDateFN)] = LastLoginDate;
                    dr[LibraryMOD.GetFieldName(LastLoginTimeFN)] = LastLoginTime;
                    dr[LibraryMOD.GetFieldName(LecturerIDFN)] = LecturerID;

                    dr[LibraryMOD.GetFieldName(IsLecturerFN)] = IsLecturer;
                    dr[LibraryMOD.GetFieldName(IsChangingRequiredFN)] = IsChangingRequiredFN;

                    //dr[LibraryMOD.GetFieldName(RoleIDFN)]=RoleID;
                    dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    dr[LibraryMOD.GetFieldName(NetUserNameFN)] = InitializeModule.gNetUserName;
                    dsUser.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsUser.Tables[TableName].Select(LibraryMOD.GetFieldName(UserNoFN) + "=" + UserNo);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(UserNoFN)] = UserNo;
                    drAry[0][LibraryMOD.GetFieldName(UserNameFN)] = UserName;
                    drAry[0][LibraryMOD.GetFieldName(PasswordFN)] = Password;
                    drAry[0][LibraryMOD.GetFieldName(EmployeeIDFN)] = EmployeeID;
                    drAry[0][LibraryMOD.GetFieldName(UILanguageFN)] = UILanguage;
                    drAry[0][LibraryMOD.GetFieldName(AcademicYearFN)] = AcademicYear;
                    drAry[0][LibraryMOD.GetFieldName(SemesterFN)] = Semester;
                    drAry[0][LibraryMOD.GetFieldName(MarksYearFN)] = MarksYear;
                    drAry[0][LibraryMOD.GetFieldName(MarksSemesterFN)] = MarksSemester;
                    drAry[0][LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
                    drAry[0][LibraryMOD.GetFieldName(LastLoginDateFN)] = LastLoginDate;
                    drAry[0][LibraryMOD.GetFieldName(LastLoginTimeFN)] = LastLoginTime;
                    drAry[0][LibraryMOD.GetFieldName(LecturerIDFN)] = LecturerID;

                    drAry[0][LibraryMOD.GetFieldName(IsLecturerFN)] = IsLecturer;
                    drAry[0][LibraryMOD.GetFieldName(IsChangingRequiredFN)] = IsChangingRequired;

                    //drAry[0][LibraryMOD.GetFieldName(RoleIDFN)]=RoleID;
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
    public int CommitUser()
    {
        //CommitUser= InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daUser.Update(dsUser, TableName);
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
            FindInMultiPKey(UserNo);
            if ((UserDataRow != null))
            {
                UserDataRow.Delete();
                CommitUser();
                if (MoveNext() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
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
            if (UserDataRow[LibraryMOD.GetFieldName(UserNoFN)] == System.DBNull.Value)
            {
                UserNo = 0;
            }
            else
            {
                UserNo = (int)UserDataRow[LibraryMOD.GetFieldName(UserNoFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(UserNameFN)] == System.DBNull.Value)
            {
                UserName = "";
            }
            else
            {
                UserName = (string)UserDataRow[LibraryMOD.GetFieldName(UserNameFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(PasswordFN)] == System.DBNull.Value)
            {
                Password = "";
            }
            else
            {
                Password = (string)UserDataRow[LibraryMOD.GetFieldName(PasswordFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)] == System.DBNull.Value)
            {
                EmployeeID = 0;
            }
            else
            {
                EmployeeID = (int)UserDataRow[LibraryMOD.GetFieldName(EmployeeIDFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(UILanguageFN)] == System.DBNull.Value)
            {
                UILanguage = 0;
            }
            else
            {
                UILanguage = (int)UserDataRow[LibraryMOD.GetFieldName(UILanguageFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(AcademicYearFN)] == System.DBNull.Value)
            {
                AcademicYear = 0;
            }
            else
            {
                AcademicYear = (int)UserDataRow[LibraryMOD.GetFieldName(AcademicYearFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(SemesterFN)] == System.DBNull.Value)
            {
                Semester = 0;
            }
            else
            {
                Semester = (int)UserDataRow[LibraryMOD.GetFieldName(SemesterFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(MarksYearFN)] == System.DBNull.Value)
            {
                MarksYear = 0;
            }
            else
            {
                MarksYear = (int)UserDataRow[LibraryMOD.GetFieldName(MarksYearFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(MarksSemesterFN)] == System.DBNull.Value)
            {
                MarksSemester = 0;
            }
            else
            {
                MarksSemester = (int)UserDataRow[LibraryMOD.GetFieldName(MarksSemesterFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(GradesPCNameFN )] == System.DBNull.Value)
            {
                GradesPCName = "";
            }
            else
            {
                GradesPCName = (string)UserDataRow[LibraryMOD.GetFieldName(GradesPCNameFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(ADUserNameFN)] == System.DBNull.Value)
            {
                ADUserName = "";
            }
            else
            {
                ADUserName = (string)UserDataRow[LibraryMOD.GetFieldName(ADUserNameFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(IsActiveFN)] == System.DBNull.Value)
            {
                IsActive = 0;
            }
            else
            {
                IsActive = (int)UserDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(LastLoginDateFN)] == System.DBNull.Value)
            {
               
            }
            else
            {
                LastLoginDate = (DateTime)UserDataRow[LibraryMOD.GetFieldName(LastLoginDateFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(LastLoginTimeFN)] == System.DBNull.Value)
            {
                LastLoginTime = 0;
            }
            else
            {
                LastLoginTime = (int)UserDataRow[LibraryMOD.GetFieldName(LastLoginTimeFN)];
            }

            if (UserDataRow[LibraryMOD.GetFieldName(AllowedCampusFN)] == System.DBNull.Value)
            {
                AllowedCampus = -1;
            }
            else
            {
                AllowedCampus = (int)UserDataRow[LibraryMOD.GetFieldName(AllowedCampusFN)];
            }
            

            if (UserDataRow[LibraryMOD.GetFieldName(LecturerIDFN)] == System.DBNull.Value)
            {
                LecturerID = 0;
            }
            else
            {
                LecturerID = (int)UserDataRow[LibraryMOD.GetFieldName(LecturerIDFN)];
            }

            if (UserDataRow[LibraryMOD.GetFieldName(IsLecturerFN)] == System.DBNull.Value)
            {
                IsLecturer = false;
            }
            else
            {
                IsLecturer = Convert.ToBoolean(UserDataRow[LibraryMOD.GetFieldName(IsLecturerFN)]);
            }

            if (UserDataRow[LibraryMOD.GetFieldName(IsChangingRequiredFN)] == System.DBNull.Value)
            {
                IsChangingRequired = 0;
            }
            else
            {
                IsChangingRequired = Convert.ToByte(UserDataRow[LibraryMOD.GetFieldName(IsChangingRequiredFN)]);
            }

            if (UserDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)] == System.DBNull.Value)
            {
                CreationUserID = 0;
            }
            else
            {
                CreationUserID = (int)UserDataRow[LibraryMOD.GetFieldName(CreationUserIDFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(CreationDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                CreationDate = (DateTime)UserDataRow[LibraryMOD.GetFieldName(CreationDateFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] == System.DBNull.Value)
            {
                LastUpdateUserID = 0;
            }
            else
            {
                LastUpdateUserID = (int)UserDataRow[LibraryMOD.GetFieldName(LastUpdateUserIDFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                LastUpdateDate = (DateTime)UserDataRow[LibraryMOD.GetFieldName(LastUpdateDateFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(PCNameFN)] == System.DBNull.Value)
            {
                PCName = "";
            }
            else
            {
                PCName = (string)UserDataRow[LibraryMOD.GetFieldName(PCNameFN)];
            }
            if (UserDataRow[LibraryMOD.GetFieldName(NetUserNameFN)] == System.DBNull.Value)
            {
                NetUserName = "";
            }
            else
            {
                NetUserName = (string)UserDataRow[LibraryMOD.GetFieldName(NetUserNameFN)];
            }
            //if (UserDataRow[LibraryMOD.GetFieldName(RoleIDFN)]== System.DBNull.Value)
            //{
            //  RoleID=0;
            //}
            //else
            //{
            //  RoleID = (int)UserDataRow[LibraryMOD.GetFieldName(RoleIDFN)];
            //}
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
    public int FindInMultiPKey(int PKUserNo)
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKUserNo;
            UserDataRow = dsUser.Tables[TableName].Rows.Find(findTheseVals);
            if ((UserDataRow != null))
            {
                lngCurRow = dsUser.Tables[TableName].Rows.IndexOf(UserDataRow);
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
    public int MoveFirst()
    {
        //MoveFirst= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = 0;
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
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
    public int MovePrevious()
    {
        //MovePrevious= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Max(lngCurRow - 1, 0);
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
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
    public int MoveLast()
    {
        //MoveLast= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = dsUser.Tables[TableName].Rows.Count - 1; //'Zero based index
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
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
    public int MoveNext()
    {
        //MoveNext= InitializeModule.FAIL_RET;
        try
        {
            lngCurRow = Math.Min(lngCurRow + 1, dsUser.Tables[TableName].Rows.Count - 1);
            if (GoToCurrentRow() == InitializeModule.FAIL_RET) return InitializeModule.FAIL_RET;
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
    public int GoToCurrentRow()
    {
        //GoToCurrentRow= InitializeModule.FAIL_RET;
        try
        {
            if (lngCurRow >= 0 & dsUser.Tables[TableName].Rows.Count > 0)
            {
                UserDataRow = dsUser.Tables[TableName].Rows[lngCurRow];
                SynchronizeDataRowToClass();
            }
            else return InitializeModule.FAIL_RET;
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
            daUser.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daUser.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daUser.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daUser.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            if (args.StatementType == StatementType.Delete)
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
    private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs args)
    {
        try
        {
            if (args.Status == UpdateStatus.ErrorsOccurred)
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
