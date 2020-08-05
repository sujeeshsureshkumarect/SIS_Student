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
public class Courses
{
    //Creation Date: 22/02/2010 6:54:29 PM
    //Programmer Name : ihab
    //-----Decleration --------------
    #region "Decleration"
    private string m_strCourse;
    private string m_strEquivalent;

    private string m_sUnified;
    private string m_sDispalyUnified;

    private string m_strCourseDescEn;
    private string m_strCourseDescAr;
    private int m_byteCreditHours;
    private string m_bEffectGPA;
    private string m_bChargeFree;
    private int m_byteParticularHours;
    private int m_byteTheoreticalHours;
    private string m_strCollege;
    private string m_strParallel;
    private string m_bLab;
    private string m_bExtraLab;
    private int m_byteGradeSystem;
    private string m_IsActive;
    private string m_strUserCreate;
    private DateTime m_dateCreate;
    private string m_strUserSave;
    private DateTime m_dateLastSave;
    private string m_strMachine;
    private string m_strNUser;
    #endregion
    #region "Puplic Properties"
    //'-----------------------------------------------------
    public string strCourse
    {
        get { return m_strCourse; }
        set { m_strCourse = value; }
    }
    public string strEquivalent
    {
        get { return m_strEquivalent; }
        set { m_strEquivalent = value; }
    }
    public string sUnified
    {
        get { return m_sUnified; }
        set { m_sUnified = value; }
    }
    public string sDispalyUnified
    {
        get { return m_sDispalyUnified; }
        set { m_sDispalyUnified = value; }
    }
  
    public string strCourseDescEn
    {
        get { return m_strCourseDescEn; }
        set { m_strCourseDescEn = value; }
    }
    public string strCourseDescAr
    {
        get { return m_strCourseDescAr; }
        set { m_strCourseDescAr = value; }
    }
    public int byteCreditHours
    {
        get { return m_byteCreditHours; }
        set { m_byteCreditHours = value; }
    }
    public string bEffectGPA
    {
        get { return m_bEffectGPA; }
        set { m_bEffectGPA = value; }
    }
    public string bChargeFree
    {
        get { return m_bChargeFree; }
        set { m_bChargeFree = value; }
    }
    public int byteParticularHours
    {
        get { return m_byteParticularHours; }
        set { m_byteParticularHours = value; }
    }
    public int byteTheoreticalHours
    {
        get { return m_byteTheoreticalHours; }
        set { m_byteTheoreticalHours = value; }
    }
    public string strCollege
    {
        get { return m_strCollege; }
        set { m_strCollege = value; }
    }
    public string strParallel
    {
        get { return m_strParallel; }
        set { m_strParallel = value; }
    }
    public string bLab
    {
        get { return m_bLab; }
        set { m_bLab = value; }
    }
    public string bExtraLab
    {
        get { return m_bExtraLab; }
        set { m_bExtraLab = value; }
    }
    public int byteGradeSystem
    {
        get { return m_byteGradeSystem; }
        set { m_byteGradeSystem = value; }
    }
    public string IsActive
    {
        get { return m_IsActive; }
        set { m_IsActive = value; }
    }
    public string strUserCreate
    {
        get { return m_strUserCreate; }
        set { m_strUserCreate = value; }
    }
    public DateTime dateCreate
    {
        get { return m_dateCreate; }
        set { m_dateCreate = value; }
    }
    public string strUserSave
    {
        get { return m_strUserSave; }
        set { m_strUserSave = value; }
    }
    public DateTime dateLastSave
    {
        get { return m_dateLastSave; }
        set { m_dateLastSave = value; }
    }
    public string strMachine
    {
        get { return m_strMachine; }
        set { m_strMachine = value; }
    }
    public string strNUser
    {
        get { return m_strNUser; }
        set { m_strNUser = value; }
    }
    #endregion
    //'-----------------------------------------------------
    public Courses()
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
public class CoursesDAL : Courses
{
    #region "Decleration"
    private string m_TableName;
    private string m_strCourseFN;
    private string m_strEquivalentFN;
   
    private string m_sUnifiedFN;
    private string m_sDispalyUnifiedFN;

    private string m_strCourseDescEnFN;
    private string m_strCourseDescArFN;
    private string m_byteCreditHoursFN;
    private string m_bEffectGPAFN;
    private string m_bChargeFreeFN;
    private string m_byteParticularHoursFN;
    private string m_byteTheoreticalHoursFN;
    private string m_strCollegeFN;
    private string m_strParallelFN;
    private string m_bLabFN;
    private string m_bExtraLabFN;
    private string m_byteGradeSystemFN;
    private string m_IsActiveFN;
    private string m_strUserCreateFN;
    private string m_dateCreateFN;
    private string m_strUserSaveFN;
    private string m_dateLastSaveFN;
    private string m_strMachineFN;
    private string m_strNUserFN;
    #endregion
    //'-----------------------------------------------------
    #region "Puplic Properties"
    public string TableName
    {
        get { return m_TableName; }
        set { m_TableName = value; }
    }
    public string strCourseFN
    {
        get { return m_strCourseFN; }
        set { m_strCourseFN = value; }
    }
    public string strEquivalentFN
    {
        get { return m_strEquivalentFN; }
        set { m_strEquivalentFN = value; }
    }
    public string sUnifiedFN
    {
        get { return m_sUnifiedFN; }
        set { m_sUnifiedFN = value; }
    }
    public string sDispalyUnifiedFN
    {
        get { return m_sDispalyUnifiedFN; }
        set { m_sDispalyUnifiedFN = value; }
    }
   
    public string strCourseDescEnFN
    {
        get { return m_strCourseDescEnFN; }
        set { m_strCourseDescEnFN = value; }
    }
    public string strCourseDescArFN
    {
        get { return m_strCourseDescArFN; }
        set { m_strCourseDescArFN = value; }
    }
    public string byteCreditHoursFN
    {
        get { return m_byteCreditHoursFN; }
        set { m_byteCreditHoursFN = value; }
    }
    public string bEffectGPAFN
    {
        get { return m_bEffectGPAFN; }
        set { m_bEffectGPAFN = value; }
    }
    public string bChargeFreeFN
    {
        get { return m_bChargeFreeFN; }
        set { m_bChargeFreeFN = value; }
    }
    public string byteParticularHoursFN
    {
        get { return m_byteParticularHoursFN; }
        set { m_byteParticularHoursFN = value; }
    }
    public string byteTheoreticalHoursFN
    {
        get { return m_byteTheoreticalHoursFN; }
        set { m_byteTheoreticalHoursFN = value; }
    }
    public string strCollegeFN
    {
        get { return m_strCollegeFN; }
        set { m_strCollegeFN = value; }
    }
    public string strParallelFN
    {
        get { return m_strParallelFN; }
        set { m_strParallelFN = value; }
    }
    public string bLabFN
    {
        get { return m_bLabFN; }
        set { m_bLabFN = value; }
    }
    public string bExtraLabFN
    {
        get { return m_bExtraLabFN; }
        set { m_bExtraLabFN = value; }
    }
    public string byteGradeSystemFN
    {
        get { return m_byteGradeSystemFN; }
        set { m_byteGradeSystemFN = value; }
    }
    public string IsActiveFN
    {
        get { return m_IsActiveFN; }
        set { m_IsActiveFN = value; }
    }
    public string strUserCreateFN
    {
        get { return m_strUserCreateFN; }
        set { m_strUserCreateFN = value; }
    }
    public string dateCreateFN
    {
        get { return m_dateCreateFN; }
        set { m_dateCreateFN = value; }
    }
    public string strUserSaveFN
    {
        get { return m_strUserSaveFN; }
        set { m_strUserSaveFN = value; }
    }
    public string dateLastSaveFN
    {
        get { return m_dateLastSaveFN; }
        set { m_dateLastSaveFN = value; }
    }
    public string strMachineFN
    {
        get { return m_strMachineFN; }
        set { m_strMachineFN = value; }
    }
    public string strNUserFN
    {
        get { return m_strNUserFN; }
        set { m_strNUserFN = value; }
    }
    #endregion
    //================End Properties ===================
    public CoursesDAL()
    {
        try
        {
            this.TableName = "Reg_Courses";
            this.strCourseFN = m_TableName + ".strCourse";
            this.strEquivalentFN = m_TableName + ".strEquivalent";
            this.sUnifiedFN = m_TableName + ".sUnified";
            this.sDispalyUnifiedFN = m_TableName + ".sDispalyUnified";
            
            this.strCourseDescEnFN = m_TableName + ".strCourseDescEn";
            this.strCourseDescArFN = m_TableName + ".strCourseDescAr";
            this.byteCreditHoursFN = m_TableName + ".byteCreditHours";
            this.bEffectGPAFN = m_TableName + ".bEffectGPA";
            this.bChargeFreeFN = m_TableName + ".bChargeFree";
            this.byteParticularHoursFN = m_TableName + ".byteParticularHours";
            this.byteTheoreticalHoursFN = m_TableName + ".byteTheoreticalHours";
            this.strCollegeFN = m_TableName + ".strCollege";
            this.strParallelFN = m_TableName + ".strParallel";
            this.bLabFN = m_TableName + ".bLab";
            this.bExtraLabFN = m_TableName + ".bExtraLab";
            this.byteGradeSystemFN = m_TableName + ".byteGradeSystem";
            this.IsActiveFN = m_TableName + ".IsActive";
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
    public string GetSQL()
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += strCourseFN;
            sSQL += " , " + strEquivalentFN;
            sSQL += " , " + sUnifiedFN;
            sSQL += " , " + sDispalyUnifiedFN;
            sSQL += " , " + strCourseDescEnFN;
            sSQL += " , " + strCourseDescArFN;
            sSQL += " , " + byteCreditHoursFN;
            sSQL += " , " + bEffectGPAFN;
            sSQL += " , " + bChargeFreeFN;
            sSQL += " , " + byteParticularHoursFN;
            sSQL += " , " + byteTheoreticalHoursFN;
            sSQL += " , " + strCollegeFN;
            sSQL += " , " + strParallelFN;
            sSQL += " , " + bLabFN;
            sSQL += " , " + bExtraLabFN;
            sSQL += " , " + byteGradeSystemFN;
            sSQL += " , " + IsActiveFN;
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
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += strCourseFN;
            sSQL += " , " + strEquivalentFN;
            sSQL += " , " + sUnifiedFN;
            sSQL += " , " + sDispalyUnifiedFN;
            sSQL += " , " + strCourseDescEnFN;
            sSQL += " , " + strCourseDescArFN;
            sSQL += " , " + byteCreditHoursFN;
            sSQL += " , " + bEffectGPAFN;
            sSQL += " , " + bChargeFreeFN;
            sSQL += " , " + byteParticularHoursFN;
            sSQL += " , " + byteTheoreticalHoursFN;
            sSQL += " , " + strCollegeFN;
            sSQL += " , " + strParallelFN;
            sSQL += " , " + bLabFN;
            sSQL += " , " + bExtraLabFN;
            sSQL += " , " + byteGradeSystemFN;
            sSQL += " , " + IsActiveFN;
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
    public string GetListSQL(string sWhere)
    {
        string sSQL = "";
        try
        {
            sSQL = "SELECT ";
            sSQL += strCourseFN;
            sSQL += " , " + strEquivalentFN;
            sSQL += " , " + sUnifiedFN;
            sSQL += " , " + sDispalyUnifiedFN;
            sSQL += " , " + strCourseDescEnFN;
            sSQL += "  FROM " + m_TableName;
            if (!string.IsNullOrEmpty(sWhere))
            {
                sSQL += " WHERE " + sWhere;
            }
            sSQL += " ORDER BY " + strCourseFN;


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
    public Array GetOtherUnifidCourses(string sCourse,int iYear, int iSem)
    {
        string sSQL;
        string sUnfiedCourses = "";
        string[] arr = null;

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        try
        {
            

            sSQL = "SELECT DISTINCT ";
            sSQL += " strCourse ";
            sSQL += "  FROM Reg_Available_Courses";
            sSQL += "  WHERE strUnified ='" + sCourse + "'";
            sSQL += "  AND intStudyYear = " + iYear;
            sSQL += "  AND byteSemester = " + iSem;
            sSQL += " UNION ";
            sSQL += " SELECT DISTINCT ";
            sSQL += " AV.strCourse ";
            sSQL += "  FROM SQL_Server.ECTData.dbo.Reg_Available_Courses AV";
            sSQL += "  WHERE AV.strUnified ='" + sCourse + "'";
            sSQL += "  AND AV.intStudyYear = " + iYear;
            sSQL += "  AND AV.byteSemester = " + iSem;
            sSQL += " ORDER BY strCourse";
        
            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);

          
       
            int index = 0;
       
           
            while (datReader.Read())
            {
                sUnfiedCourses = datReader.GetString(0);
                
                Array.Resize(ref arr, index +1);
                arr[index] = sUnfiedCourses;
                index++; 
                
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

        return arr;
       
    }
    public List<Courses> GetList(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Lecturers
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetListSQL(sCondition);

        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Courses> results = new List<Courses>();
        try
        {
            //Default Value
            Courses myCourses = new Courses();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCourses.strCourse = "Select Course ...";
                myCourses.strCourseDescEn = "Select Course ...";

                results.Add(myCourses);
            }
            while (reader.Read())
            {
                myCourses = new Courses();
                myCourses.strCourse = reader[LibraryMOD.GetFieldName(strCourseFN)].ToString();
                myCourses.strCourseDescEn = reader[LibraryMOD.GetFieldName(strCourseDescEnFN)].ToString();
                myCourses.strEquivalent = reader[LibraryMOD.GetFieldName(strEquivalentFN)].ToString();
                myCourses.sUnified= reader[LibraryMOD.GetFieldName(sUnifiedFN)].ToString();
                myCourses.sDispalyUnified = reader[LibraryMOD.GetFieldName(sDispalyUnifiedFN )].ToString();
                
                results.Add(myCourses);
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
    //-----Get GetUpdateCommand Function -----------------------
    public string GetUpdateCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "UPDATE " + TableName;
            sSQL += " SET ";
            sSQL += LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
            sSQL += " , " + LibraryMOD.GetFieldName(strEquivalentFN) + "=@strEquivalent";
            sSQL += " , " + LibraryMOD.GetFieldName(sUnifiedFN) + "=@sUnified";
            sSQL += " , " + LibraryMOD.GetFieldName(sDispalyUnifiedFN) + "=@sDispalyUnified";
            sSQL += " , " + LibraryMOD.GetFieldName(strCourseDescEnFN) + "=@strCourseDescEn";
            sSQL += " , " + LibraryMOD.GetFieldName(strCourseDescArFN) + "=@strCourseDescAr";
            sSQL += " , " + LibraryMOD.GetFieldName(byteCreditHoursFN) + "=@byteCreditHours";
            sSQL += " , " + LibraryMOD.GetFieldName(bEffectGPAFN) + "=@bEffectGPA";
            sSQL += " , " + LibraryMOD.GetFieldName(bChargeFreeFN) + "=@bChargeFree";
            sSQL += " , " + LibraryMOD.GetFieldName(byteParticularHoursFN) + "=@byteParticularHours";
            sSQL += " , " + LibraryMOD.GetFieldName(byteTheoreticalHoursFN) + "=@byteTheoreticalHours";
            sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN) + "=@strCollege";
            sSQL += " , " + LibraryMOD.GetFieldName(strParallelFN) + "=@strParallel";
            sSQL += " , " + LibraryMOD.GetFieldName(bLabFN) + "=@bLab";
            sSQL += " , " + LibraryMOD.GetFieldName(bExtraLabFN) + "=@bExtraLab";
            sSQL += " , " + LibraryMOD.GetFieldName(byteGradeSystemFN) + "=@byteGradeSystem";
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN) + "=@IsActive";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN) + "=@strUserCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN) + "=@dateCreate";
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN) + "=@strUserSave";
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN) + "=@dateLastSave";
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN) + "=@strMachine";
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN) + "=@strNUser";
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
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
            sSQL = "INSERT INTO " + TableName;
            sSQL += "( ";
            sSQL += LibraryMOD.GetFieldName(strCourseFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strEquivalentFN);
            sSQL += " , " + LibraryMOD.GetFieldName(sUnifiedFN );
            sSQL += " , " + LibraryMOD.GetFieldName(sDispalyUnifiedFN );
            sSQL += " , " + LibraryMOD.GetFieldName(strCourseDescEnFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCourseDescArFN);
            sSQL += " , " + LibraryMOD.GetFieldName(byteCreditHoursFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bEffectGPAFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bChargeFreeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(byteParticularHoursFN);
            sSQL += " , " + LibraryMOD.GetFieldName(byteTheoreticalHoursFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strCollegeFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strParallelFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bLabFN);
            sSQL += " , " + LibraryMOD.GetFieldName(bExtraLabFN);
            sSQL += " , " + LibraryMOD.GetFieldName(byteGradeSystemFN);
            sSQL += " , " + LibraryMOD.GetFieldName(IsActiveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateCreateFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strUserSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(dateLastSaveFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strMachineFN);
            sSQL += " , " + LibraryMOD.GetFieldName(strNUserFN);
            sSQL += ")";
            sSQL += " VALUES ";
            sSQL += "( ";
            sSQL += " @strCourse";
            sSQL += " ,@strEquivalent";
            sSQL += " ,@sUnified";
            sSQL += " ,@sDispalyUnified";
            sSQL += " ,@strCourseDescEn";
            sSQL += " ,@strCourseDescAr";
            sSQL += " ,@byteCreditHours";
            sSQL += " ,@bEffectGPA";
            sSQL += " ,@bChargeFree";
            sSQL += " ,@byteParticularHours";
            sSQL += " ,@byteTheoreticalHours";
            sSQL += " ,@strCollege";
            sSQL += " ,@strParallel";
            sSQL += " ,@bLab";
            sSQL += " ,@bExtraLab";
            sSQL += " ,@byteGradeSystem";
            sSQL += " ,@IsActive";
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
    public string GetDeleteCommand()
    {
        string sSQL = "";
        try
        {
            sSQL = "DELETE FROM " + TableName;
            sSQL += " WHERE ";
            sSQL += LibraryMOD.GetFieldName(strCourseFN) + "=@strCourse";
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
    public List<Courses> GetCourses(InitializeModule.EnumCampus Campus, string sCondition, bool isDeafaultIncluded)
    {
        //' returns a list of Classes instances based on the
        //' data in the Courses
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
        List<Courses> results = new List<Courses>();
        try
        {
            //Default Value
            Courses myCourses = new Courses();
            if (isDeafaultIncluded)
            {
                //Change the code here
                myCourses.strCourse = "0";
                myCourses.strEquivalent = "Select Course ...";
                results.Add(myCourses);
            }
            while (reader.Read())
            {
                myCourses = new Courses();

                myCourses.strCourse = reader[LibraryMOD.GetFieldName(strCourseFN)].ToString();
                myCourses.strEquivalent = reader[LibraryMOD.GetFieldName(strEquivalentFN)].ToString();
                myCourses.sUnified= reader[LibraryMOD.GetFieldName(sUnifiedFN)].ToString();
                myCourses.sDispalyUnified = reader[LibraryMOD.GetFieldName(sDispalyUnifiedFN )].ToString();
                myCourses.strCourseDescEn = reader[LibraryMOD.GetFieldName(strCourseDescEnFN)].ToString();
                myCourses.strCourseDescAr = reader[LibraryMOD.GetFieldName(strCourseDescArFN)].ToString();
                
                if (reader[LibraryMOD.GetFieldName(byteCreditHoursFN)].Equals(DBNull.Value))
                {
                    myCourses.byteCreditHours = 0;
                }
                else
                {
                    myCourses.byteCreditHours = int.Parse(reader[LibraryMOD.GetFieldName(byteCreditHoursFN)].ToString());
                }

                myCourses.bEffectGPA = reader[LibraryMOD.GetFieldName(bEffectGPAFN)].ToString();
                myCourses.bChargeFree = reader[LibraryMOD.GetFieldName(bChargeFreeFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(byteParticularHoursFN)].Equals(DBNull.Value))
                {
                    myCourses.byteParticularHours = 0;
                }
                else
                {
                    myCourses.byteParticularHours = int.Parse(reader[LibraryMOD.GetFieldName(byteParticularHoursFN)].ToString());
                }
                if (reader[LibraryMOD.GetFieldName(byteTheoreticalHoursFN)].Equals(DBNull.Value))
                {
                    myCourses.byteTheoreticalHours = 0;
                }
                else
                {
                    myCourses.byteTheoreticalHours = int.Parse(reader[LibraryMOD.GetFieldName(byteTheoreticalHoursFN)].ToString());
                }
                myCourses.strCollege = reader[LibraryMOD.GetFieldName(strCollegeFN)].ToString();
                myCourses.strParallel = reader[LibraryMOD.GetFieldName(strParallelFN)].ToString();
                myCourses.bLab = reader[LibraryMOD.GetFieldName(bLabFN)].ToString();
                myCourses.bExtraLab = reader[LibraryMOD.GetFieldName(bExtraLabFN)].ToString();
                if (reader[LibraryMOD.GetFieldName(byteGradeSystemFN)].Equals(DBNull.Value))
                {
                    myCourses.byteGradeSystem = 0;
                }
                else
                {
                    myCourses.byteGradeSystem = int.Parse(reader[LibraryMOD.GetFieldName(byteGradeSystemFN)].ToString());
                }
                
                myCourses.IsActive = reader[LibraryMOD.GetFieldName(IsActiveFN)].ToString();

                myCourses.strUserCreate = reader[LibraryMOD.GetFieldName(strUserCreateFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateCreateFN)].Equals(DBNull.Value))
                {
                    myCourses.dateCreate = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateCreateFN)].ToString());
                }
                myCourses.strUserSave = reader[LibraryMOD.GetFieldName(strUserSaveFN)].ToString();
                if (!reader[LibraryMOD.GetFieldName(dateLastSaveFN)].Equals(DBNull.Value))
                {
                    myCourses.dateLastSave = DateTime.Parse(reader[LibraryMOD.GetFieldName(dateLastSaveFN)].ToString());
                }
                myCourses.strMachine = reader[LibraryMOD.GetFieldName(strMachineFN)].ToString();
                myCourses.strNUser = reader[LibraryMOD.GetFieldName(strNUserFN)].ToString();
                results.Add(myCourses);
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
    public int UpdateCourses(InitializeModule.EnumCampus Campus, int iMode, string strCourse, string strEquivalent, string strCourseDescEn, string strCourseDescAr, int byteCreditHours, string bEffectGPA, string bChargeFree, int byteParticularHours, int byteTheoreticalHours, string strCollege, string strParallel, string bLab, string bExtraLab, int byteGradeSystem, string IsActive, string strUserCreate, DateTime dateCreate, string strUserSave, DateTime dateLastSave, string strMachine, string strNUser)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            Conn.Open();
            string sql = "";
            Courses theCourses = new Courses();
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
            Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse));
            Cmd.Parameters.Add(new SqlParameter("@strEquivalent", strEquivalent));
            Cmd.Parameters.Add(new SqlParameter("@sUnified", sUnifiedFN));
            Cmd.Parameters.Add(new SqlParameter("@sDispalyUnified", sDispalyUnifiedFN));
            Cmd.Parameters.Add(new SqlParameter("@strCourseDescEn", strCourseDescEn));
            Cmd.Parameters.Add(new SqlParameter("@strCourseDescAr", strCourseDescAr));
            Cmd.Parameters.Add(new SqlParameter("@byteCreditHours", byteCreditHours));
            Cmd.Parameters.Add(new SqlParameter("@bEffectGPA", bEffectGPA));
            Cmd.Parameters.Add(new SqlParameter("@bChargeFree", bChargeFree));
            Cmd.Parameters.Add(new SqlParameter("@byteParticularHours", byteParticularHours));
            Cmd.Parameters.Add(new SqlParameter("@byteTheoreticalHours", byteTheoreticalHours));
            Cmd.Parameters.Add(new SqlParameter("@strCollege", strCollege));
            Cmd.Parameters.Add(new SqlParameter("@strParallel", strParallel));
            Cmd.Parameters.Add(new SqlParameter("@bLab", bLab));
            Cmd.Parameters.Add(new SqlParameter("@bExtraLab", bExtraLab));
            Cmd.Parameters.Add(new SqlParameter("@byteGradeSystem", byteGradeSystem));
            Cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
            Cmd.Parameters.Add(new SqlParameter("@strUserCreate", strUserCreate));
            Cmd.Parameters.Add(new SqlParameter("@dateCreate", dateCreate));
            Cmd.Parameters.Add(new SqlParameter("@strUserSave", strUserSave));
            Cmd.Parameters.Add(new SqlParameter("@dateLastSave", dateLastSave));
            Cmd.Parameters.Add(new SqlParameter("@strMachine", strMachine));
            Cmd.Parameters.Add(new SqlParameter("@strNUser", strNUser));
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
    public int DeleteCourses(InitializeModule.EnumCampus Campus, string strCourse)
    {
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            string sSQL = GetDeleteCommand();
            //sSQL += sCondition;
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            Cmd.Parameters.Add(new SqlParameter("@strCourse", strCourse));
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
    public DataView GetDataView(bool isFromRole, int PK, string sCondition)
    {
        DataTable dt = new DataTable("Courses");
        DataView dv = new DataView();
        List<Courses> myCoursess = new List<Courses>();
        try
        {
            myCoursess = GetCourses(InitializeModule.EnumCampus.ECTNew, sCondition, false);
            DataColumn col1 = new DataColumn("strCourse", Type.GetType("nvarchar"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("strEquivalent", Type.GetType("nvarchar"));
            dt.Columns.Add(col2);
            DataColumn col3 = new DataColumn("strCourseDescEn", Type.GetType("nvarchar"));
            dt.Columns.Add(col3);
            dt.Constraints.Add(new UniqueConstraint(col1));

            DataRow dr;
            for (int i = 0; i < myCoursess.Count; i++)
            {
                dr = dt.NewRow();
                dr[1] = myCoursess[i].strCourse;
                dr[2] = myCoursess[i].strEquivalent;
                dr[3] = myCoursess[i].strCourseDescEn;
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
            myCoursess.Clear();
        }
        return dv;
    }
    
    public string GetDisplayUnified(InitializeModule.EnumCampus Campus, string sCourse)
    {
        String sSQL;
        String sDisplayUnified = "";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {

            sSQL = "SELECT ";
            sSQL += sDispalyUnifiedFN ;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + strCourseFN  + "='" + sCourse + "'";

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


            if (datReader.Read())
            {
                sDisplayUnified = datReader.GetString(0);
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

        return sDisplayUnified;
    }
    public string GetCourseName(InitializeModule.EnumCampus Campus, string sCourse)
    {
        String sSQL;
        String sCourseName = "";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {

            sSQL = "SELECT ";
            sSQL += strCourseDescEnFN  ;
            sSQL += "  FROM " + m_TableName;
            sSQL += "  WHERE " + strCourseFN  + "='" + sCourse + "'";

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
            System.Data.SqlClient.SqlDataReader datReader;
            datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


            if (datReader.Read())
            {
                sCourseName = datReader.GetString(0);
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

        return sCourseName;
    }
    //'-------Populate  -----------------------------
    public DataTable Populate(SqlConnection con)
    {
        string sSQL = "";
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
public class CoursesCls : CoursesDAL
{
    #region "Decleration"
    private int m_lngCurRow = 0;
    public SqlDataAdapter daCourses;
    private DataSet m_dsCourses;
    public DataRow CoursesDataRow;
    #endregion
    #region "Puplic Properties"
    public DataSet dsCourses
    {
        get { return m_dsCourses; }
        set { m_dsCourses = value; }
    }
    //-----------------------------------------------------
    public int lngCurRow
    {
        get { return m_lngCurRow; }
        set { m_lngCurRow = value; }
    }
    #endregion
    public CoursesCls()
    {
        try
        {
            dsCourses = new DataSet();

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
    public virtual SqlDataAdapter GetCoursesDataAdapter(string sCondition, SqlConnection con)
    {
        string sSQL = "";
        try
        {
            sSQL = GetSQL();
            sSQL += " " + sCondition;
            //-----------------------------------------
            daCourses = new SqlDataAdapter(sSQL, con);
            // Create command builder. This line automatically generates the update commands for you, so you don't
            // have to provide or create your own.
            SqlCommandBuilder myDataRowsCommandBuilder = new SqlCommandBuilder(daCourses);
            //Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            // key + unique key information to be retrieved unless AddWithKey is specified.
            daCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCourses;
    }
    public virtual SqlDataAdapter GetCoursesDataAdapter(SqlConnection con)
    {
        try
        {
            daCourses = new SqlDataAdapter();
            //''Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
            //'' key + unique key information to be retrieved unless AddWithKey is specified.
            daCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-----------------------------------------
            SqlParameter Parmeter = default(SqlParameter);
            //[SELECT COMMAND]
            SqlCommand cmdCourses;
            cmdCourses = new SqlCommand(GetSelectCommand(), con);
            //'cmdRolePermission.Parameters.Add("@strCourse", SqlDbType.Int, 4, "strCourse" );
            daCourses.SelectCommand = cmdCourses;
            //'Add Handlers
            //'RowUpdating,RowUpdated
            AddDAEventHandler();
            //'[UPDATE COMMAND].
            cmdCourses = new SqlCommand(GetUpdateCommand(), con);
            //'Delete PK Parameteres from here. b/c its declared below
            cmdCourses.Parameters.Add("@strCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strCourseFN));
            cmdCourses.Parameters.Add("@strEquivalent", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strEquivalentFN));
            cmdCourses.Parameters.Add("@strCourseDescEn", SqlDbType.NVarChar, 140, LibraryMOD.GetFieldName(strCourseDescEnFN));
            cmdCourses.Parameters.Add("@strCourseDescAr", SqlDbType.NVarChar, 120, LibraryMOD.GetFieldName(strCourseDescArFN));
            cmdCourses.Parameters.Add("@byteCreditHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteCreditHoursFN));
            cmdCourses.Parameters.Add("@bEffectGPA", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bEffectGPAFN));
            cmdCourses.Parameters.Add("@bChargeFree", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bChargeFreeFN));
            cmdCourses.Parameters.Add("@byteParticularHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteParticularHoursFN));
            cmdCourses.Parameters.Add("@byteTheoreticalHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteTheoreticalHoursFN));
            cmdCourses.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdCourses.Parameters.Add("@strParallel", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strParallelFN));
            cmdCourses.Parameters.Add("@bLab", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bLabFN));
            cmdCourses.Parameters.Add("@bExtraLab", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bExtraLabFN));
            cmdCourses.Parameters.Add("@byteGradeSystem", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteGradeSystemFN));
            cmdCourses.Parameters.Add("@IsActive", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(IsActiveFN));
            cmdCourses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdCourses.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdCourses.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdCourses.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdCourses.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdCourses.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));


            Parmeter = cmdCourses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            //'Its should be none for batch updating
            //'UpdateCommand, InsertCommand, and DeleteCommand 
            //'should be set to None or OutputParameters
            daCourses.UpdateCommand = cmdCourses;
            daCourses.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            //'-------------------------
            //'/INSERT COMMAND
            cmdCourses = new SqlCommand(GetInsertCommand(), con);
            cmdCourses.Parameters.Add("@strCourse", SqlDbType.NVarChar, 24, LibraryMOD.GetFieldName(strCourseFN));
            cmdCourses.Parameters.Add("@strEquivalent", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strEquivalentFN));
            cmdCourses.Parameters.Add("@strCourseDescEn", SqlDbType.NVarChar, 140, LibraryMOD.GetFieldName(strCourseDescEnFN));
            cmdCourses.Parameters.Add("@strCourseDescAr", SqlDbType.NVarChar, 120, LibraryMOD.GetFieldName(strCourseDescArFN));
            cmdCourses.Parameters.Add("@byteCreditHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteCreditHoursFN));
            cmdCourses.Parameters.Add("@bEffectGPA", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bEffectGPAFN));
            cmdCourses.Parameters.Add("@bChargeFree", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bChargeFreeFN));
            cmdCourses.Parameters.Add("@byteParticularHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteParticularHoursFN));
            cmdCourses.Parameters.Add("@byteTheoreticalHours", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteTheoreticalHoursFN));
            cmdCourses.Parameters.Add("@strCollege", SqlDbType.NVarChar, 12, LibraryMOD.GetFieldName(strCollegeFN));
            cmdCourses.Parameters.Add("@strParallel", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strParallelFN));
            cmdCourses.Parameters.Add("@bLab", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bLabFN));
            cmdCourses.Parameters.Add("@bExtraLab", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(bExtraLabFN));
            cmdCourses.Parameters.Add("@byteGradeSystem", SqlDbType.Int, 2, LibraryMOD.GetFieldName(byteGradeSystemFN));
            cmdCourses.Parameters.Add("@IsActive", SqlDbType.Bit, 1, LibraryMOD.GetFieldName(IsActiveFN));
            cmdCourses.Parameters.Add("@strUserCreate", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strUserCreateFN));
            cmdCourses.Parameters.Add("@dateCreate", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateCreateFN));
            cmdCourses.Parameters.Add("@strUserSave", SqlDbType.Char, 10, LibraryMOD.GetFieldName(strUserSaveFN));
            cmdCourses.Parameters.Add("@dateLastSave", SqlDbType.DateTime, 16, LibraryMOD.GetFieldName(dateLastSaveFN));
            cmdCourses.Parameters.Add("@strMachine", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strMachineFN));
            cmdCourses.Parameters.Add("@strNUser", SqlDbType.NVarChar, 100, LibraryMOD.GetFieldName(strNUserFN));
            Parmeter.SourceVersion = DataRowVersion.Current;
            daCourses.InsertCommand = cmdCourses;
            daCourses.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            //'------------------------
            //'/DELETE COMMAND
            cmdCourses = new SqlCommand(GetDeleteCommand(), con);
            Parmeter = cmdCourses.Parameters.Add("@strCourse", SqlDbType.Int, 4, LibraryMOD.GetFieldName(strCourseFN));
            Parmeter.SourceVersion = DataRowVersion.Original;
            daCourses.DeleteCommand = cmdCourses;
            daCourses.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            //'Batch Size
            //'Set the batch size.
            daCourses.UpdateBatchSize = InitializeModule.BATCH_SIZE;
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
        }
        return daCourses;
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
                    dr = dsCourses.Tables[TableName].NewRow();
                    dr[LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    dr[LibraryMOD.GetFieldName(strEquivalentFN)] = strEquivalent;
                    dr[LibraryMOD.GetFieldName(strCourseDescEnFN)] = strCourseDescEn;
                    dr[LibraryMOD.GetFieldName(strCourseDescArFN)] = strCourseDescAr;
                    dr[LibraryMOD.GetFieldName(byteCreditHoursFN)] = byteCreditHours;
                    dr[LibraryMOD.GetFieldName(bEffectGPAFN)] = bEffectGPA;
                    dr[LibraryMOD.GetFieldName(bChargeFreeFN)] = bChargeFree;
                    dr[LibraryMOD.GetFieldName(byteParticularHoursFN)] = byteParticularHours;
                    dr[LibraryMOD.GetFieldName(byteTheoreticalHoursFN)] = byteTheoreticalHours;
                    dr[LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    dr[LibraryMOD.GetFieldName(strParallelFN)] = strParallel;
                    dr[LibraryMOD.GetFieldName(bLabFN)] = bLab;
                    dr[LibraryMOD.GetFieldName(bExtraLabFN)] = bExtraLab;
                    dr[LibraryMOD.GetFieldName(byteGradeSystemFN)] = byteGradeSystem;
                    dr[LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
                    dr[LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    dr[LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    dr[LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    dr[LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    dr[LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    dr[LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
                    //dr[LibraryMOD.GetFieldName(CreationUserIDFN)] = InitializeModule.gUserNo;
                    //dr[LibraryMOD.GetFieldName(CreationDateFN)] = DateTime.Now; //' CreationDate
                    //dr[LibraryMOD.GetFieldName(LastUpdateUserIDFN)] = InitializeModule.gUserNo;  //'LastUpdateUserID
                    //dr[LibraryMOD.GetFieldName(LastUpdateDateFN)] = DateTime.Now; //'LastUpdateDate
                    //dr[LibraryMOD.GetFieldName(PCNameFN)] = InitializeModule.gPCName;
                    //dr[LibraryMOD.GetFieldName(NetUserNameFN)]= InitializeModule.gNetUserName;
                    dsCourses.Tables[TableName].Rows.Add(dr);
                    break;
                case (int)InitializeModule.enumModes.EditMode:
                    DataRow[] drAry = null;
                    drAry = dsCourses.Tables[TableName].Select(LibraryMOD.GetFieldName(strCourseFN) + "=" + strCourse);
                    //'its return array of rows and we can access the first by index 0
                    drAry[0][LibraryMOD.GetFieldName(strCourseFN)] = strCourse;
                    drAry[0][LibraryMOD.GetFieldName(strEquivalentFN)] = strEquivalent;
                    drAry[0][LibraryMOD.GetFieldName(strCourseDescEnFN)] = strCourseDescEn;
                    drAry[0][LibraryMOD.GetFieldName(strCourseDescArFN)] = strCourseDescAr;
                    drAry[0][LibraryMOD.GetFieldName(byteCreditHoursFN)] = byteCreditHours;
                    drAry[0][LibraryMOD.GetFieldName(bEffectGPAFN)] = bEffectGPA;
                    drAry[0][LibraryMOD.GetFieldName(bChargeFreeFN)] = bChargeFree;
                    drAry[0][LibraryMOD.GetFieldName(byteParticularHoursFN)] = byteParticularHours;
                    drAry[0][LibraryMOD.GetFieldName(byteTheoreticalHoursFN)] = byteTheoreticalHours;
                    drAry[0][LibraryMOD.GetFieldName(strCollegeFN)] = strCollege;
                    drAry[0][LibraryMOD.GetFieldName(strParallelFN)] = strParallel;
                    drAry[0][LibraryMOD.GetFieldName(bLabFN)] = bLab;
                    drAry[0][LibraryMOD.GetFieldName(bExtraLabFN)] = bExtraLab;
                    drAry[0][LibraryMOD.GetFieldName(byteGradeSystemFN)] = byteGradeSystem;
                    drAry[0][LibraryMOD.GetFieldName(IsActiveFN)] = IsActive;
                    drAry[0][LibraryMOD.GetFieldName(strUserCreateFN)] = strUserCreate;
                    drAry[0][LibraryMOD.GetFieldName(dateCreateFN)] = dateCreate;
                    drAry[0][LibraryMOD.GetFieldName(strUserSaveFN)] = strUserSave;
                    drAry[0][LibraryMOD.GetFieldName(dateLastSaveFN)] = dateLastSave;
                    drAry[0][LibraryMOD.GetFieldName(strMachineFN)] = strMachine;
                    drAry[0][LibraryMOD.GetFieldName(strNUserFN)] = strNUser;
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
    public int CommitCourses()
    {
        //CommitCourses= InitializeModule.FAIL_RET;
        try
        {
            //'' Update Database with SqlDataAdapter
            daCourses.Update(dsCourses, TableName);
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
            FindInMultiPKey(strCourse);
            if ((CoursesDataRow != null))
            {
                CoursesDataRow.Delete();
                CommitCourses();
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
            if (CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)] == System.DBNull.Value)
            {
                strCourse = "";
            }
            else
            {
                strCourse = (string)CoursesDataRow[LibraryMOD.GetFieldName(strCourseFN)];
            }

            if (CoursesDataRow[LibraryMOD.GetFieldName(strEquivalentFN)] == System.DBNull.Value)
            {
                strEquivalent = "";
            }
            else
            {
                strEquivalent = (string)CoursesDataRow[LibraryMOD.GetFieldName(strEquivalentFN)];
            }

            if (CoursesDataRow[LibraryMOD.GetFieldName(sUnifiedFN )] == System.DBNull.Value)
            {
                sUnified = "";
            }
            else
            {
                sUnified = (string)CoursesDataRow[LibraryMOD.GetFieldName(sUnifiedFN)];
            }

            if (CoursesDataRow[LibraryMOD.GetFieldName(sDispalyUnifiedFN )] == System.DBNull.Value)
            {
                sDispalyUnified = "";
            }
            else
            {
                sDispalyUnified = (string)CoursesDataRow[LibraryMOD.GetFieldName(sDispalyUnifiedFN)];
            }

            if (CoursesDataRow[LibraryMOD.GetFieldName(strCourseDescEnFN)] == System.DBNull.Value)
            {
                strCourseDescEn = "";
            }
            else
            {
                strCourseDescEn = (string)CoursesDataRow[LibraryMOD.GetFieldName(strCourseDescEnFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(strCourseDescArFN)] == System.DBNull.Value)
            {
                strCourseDescAr = "";
            }
            else
            {
                strCourseDescAr = (string)CoursesDataRow[LibraryMOD.GetFieldName(strCourseDescArFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(byteCreditHoursFN)] == System.DBNull.Value)
            {
                byteCreditHours = 0;
            }
            else
            {
                byteCreditHours = (int)CoursesDataRow[LibraryMOD.GetFieldName(byteCreditHoursFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(bEffectGPAFN)] == System.DBNull.Value)
            {
                bEffectGPA = "";
            }
            else
            {
                bEffectGPA = (string)CoursesDataRow[LibraryMOD.GetFieldName(bEffectGPAFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(bChargeFreeFN)] == System.DBNull.Value)
            {
                bChargeFree = "";
            }
            else
            {
                bChargeFree = (string)CoursesDataRow[LibraryMOD.GetFieldName(bChargeFreeFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(byteParticularHoursFN)] == System.DBNull.Value)
            {
                byteParticularHours = 0;
            }
            else
            {
                byteParticularHours = (int)CoursesDataRow[LibraryMOD.GetFieldName(byteParticularHoursFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(byteTheoreticalHoursFN)] == System.DBNull.Value)
            {
                byteTheoreticalHours = 0;
            }
            else
            {
                byteTheoreticalHours = (int)CoursesDataRow[LibraryMOD.GetFieldName(byteTheoreticalHoursFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(strCollegeFN)] == System.DBNull.Value)
            {
                strCollege = "";
            }
            else
            {
                strCollege = (string)CoursesDataRow[LibraryMOD.GetFieldName(strCollegeFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(strParallelFN)] == System.DBNull.Value)
            {
                strParallel = "";
            }
            else
            {
                strParallel = (string)CoursesDataRow[LibraryMOD.GetFieldName(strParallelFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(bLabFN)] == System.DBNull.Value)
            {
                bLab = "";
            }
            else
            {
                bLab = (string)CoursesDataRow[LibraryMOD.GetFieldName(bLabFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(bExtraLabFN)] == System.DBNull.Value)
            {
                bExtraLab = "";
            }
            else
            {
                bExtraLab = (string)CoursesDataRow[LibraryMOD.GetFieldName(bExtraLabFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(byteGradeSystemFN)] == System.DBNull.Value)
            {
                byteGradeSystem = 0;
            }
            else
            {
                byteGradeSystem = (int)CoursesDataRow[LibraryMOD.GetFieldName(byteGradeSystemFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(IsActiveFN)] == System.DBNull.Value)
            {
                IsActive= "";
            }
            else
            {
                IsActive = (string)CoursesDataRow[LibraryMOD.GetFieldName(IsActiveFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)] == System.DBNull.Value)
            {
                strUserCreate = "";
            }
            else
            {
                strUserCreate = (string)CoursesDataRow[LibraryMOD.GetFieldName(strUserCreateFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(dateCreateFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateCreate = (DateTime)CoursesDataRow[LibraryMOD.GetFieldName(dateCreateFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)] == System.DBNull.Value)
            {
                strUserSave = "";
            }
            else
            {
                strUserSave = (string)CoursesDataRow[LibraryMOD.GetFieldName(strUserSaveFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)] == System.DBNull.Value)
            {
            }
            else
            {
                dateLastSave = (DateTime)CoursesDataRow[LibraryMOD.GetFieldName(dateLastSaveFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(strMachineFN)] == System.DBNull.Value)
            {
                strMachine = "";
            }
            else
            {
                strMachine = (string)CoursesDataRow[LibraryMOD.GetFieldName(strMachineFN)];
            }
            if (CoursesDataRow[LibraryMOD.GetFieldName(strNUserFN)] == System.DBNull.Value)
            {
                strNUser = "";
            }
            else
            {
                strNUser = (string)CoursesDataRow[LibraryMOD.GetFieldName(strNUserFN)];
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
    public int FindInMultiPKey(string PKstrCourse)
    {
        //FindInMultiPKey= InitializeModule.FAIL_RET;
        try
        {
            //' Create an array for the key values to find.
            object[] findTheseVals = new object[1];
            //' Set the values of the keys to find.
            findTheseVals[0] = PKstrCourse;
            CoursesDataRow = dsCourses.Tables[TableName].Rows.Find(findTheseVals);
            if ((CoursesDataRow != null))
            {
                lngCurRow = dsCourses.Tables[TableName].Rows.IndexOf(CoursesDataRow);
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
            lngCurRow = dsCourses.Tables[TableName].Rows.Count - 1; //'Zero based index
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
            lngCurRow = Math.Min(lngCurRow + 1, dsCourses.Tables[TableName].Rows.Count - 1);
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
            if (lngCurRow >= 0 & dsCourses.Tables[TableName].Rows.Count > 0)
            {
                CoursesDataRow = dsCourses.Tables[TableName].Rows[lngCurRow];
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
            daCourses.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCourses.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
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
            daCourses.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
            daCourses.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
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
