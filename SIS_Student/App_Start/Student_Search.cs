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

/// <summary>
/// Summary description for Student_Search
/// </summary>
public class Student_Search
{
#region "Decleration"
    private int _iSerial;
    private string _sNo;
    private string _sName;
    private string _sAccount;
    private int _iYear;
    private byte _bSemester;
    private int _iTerm;
    private string _sCollege;
    private string _sDegree;
    private string _sMajor;
    private byte _bShift;
    private byte _bType;
    private string _sPhone1;
    private string _sPhone2;
#endregion

#region "Puplic Properties"

    public int ISerial
    {
        get { return _iSerial; }
        set { _iSerial = value; }
    }

    public string SNo
    {
        get { return _sNo; }
        set { _sNo = value; }
    }

    public string SName
    {
        get { return _sName; }
        set { _sName = value; }
    }

    public string SAccount
    {
        get { return _sAccount; }
        set { _sAccount = value; }
    }

    public int IYear
    {
        get { return _iYear; }
        set { _iYear = value; }
    }

    public byte BSemester
    {
        get { return _bSemester; }
        set { _bSemester = value; }
    }

    public int ITerm
    {
        get { return _iTerm; }
        set { _iTerm = value; }
    }

    public string SCollege
    {
        get { return _sCollege; }
        set { _sCollege = value; }
    }

    public string SDegree
    {
        get { return _sDegree; }
        set { _sDegree = value; }
    }
    public string SMajor
    {
        get { return _sMajor; }
        set { _sMajor = value; }
    }

    public byte BShift
    {
        get { return _bShift; }
        set { _bShift = value; }
    }

    public byte BType
    {
        get { return _bType; }
        set { _bType = value; }
    }

    public string SPhone1
    {
        get { return _sPhone1; }
        set { _sPhone1 = value; }
    }

    public string SPhone2
    {
        get { return _sPhone2; }
        set { _sPhone2 = value; }
    }

#endregion

    public Student_Search()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
public class Student_SearchDAL
{
    private string GetSQL()
    {
        string sSQL = "";
        sSQL="SELECT iSerial, sNo, sName, sAccount, iYear, bSemester, sCollege,";
        sSQL += " sDegree, sMajor, bShift, bType, sPhone1, sPhone2";
        sSQL += " FROM Web_Students_Search";
        return sSQL;
    }

    public List<Student_Search> GetList(InitializeModule.EnumCampus Campus, string sCondition)
    {
        List<Student_Search> Result = new List<Student_Search>(); 
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
        string sSQL = GetSQL();
        if (!string.IsNullOrEmpty(sCondition))
        {
            sSQL += sCondition;
        }
        sSQL += " Order By sName";
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        try
        {
            Student_Search myStudent;
            while (reader.Read())
            {
                myStudent = new Student_Search();
                myStudent.ISerial = int.Parse( reader["iSerial"].ToString());
                myStudent.SNo = reader["sNo"].ToString();
                myStudent.SName = reader["sName"].ToString();
                myStudent.SAccount = reader["sAccount"].ToString();
                if (!reader["iYear"].Equals(DBNull.Value))
                {
                    myStudent.IYear = int.Parse(reader["iYear"].ToString());
                    myStudent.BSemester = byte.Parse(reader["bSemester"].ToString());
                    myStudent.ITerm = myStudent.IYear * 10 + myStudent.BSemester;
                }
                myStudent.SCollege = reader["sCollege"].ToString();
                myStudent.SDegree = reader["sDegree"].ToString();
                myStudent.SMajor = reader["sMajor"].ToString();

                if (!reader["bShift"].Equals(DBNull.Value))
                {
                    myStudent.BSemester = byte.Parse(reader["bShift"].ToString());
                }

                if (!reader["bType"].Equals(DBNull.Value))
                {
                    myStudent.BType = byte.Parse(reader["bType"].ToString());
                }
                else
                {
                    //Regular Sudents
                    myStudent.BType = 0;
                }
                myStudent.SPhone1 = reader["sPhone1"].ToString();
                myStudent.SPhone2 = reader["sPhone2"].ToString();

                Result.Add(myStudent);


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
        return Result;
    }

    public string Sync_Students_No(InitializeModule.EnumCampus Campus,string sNo)
    {
        string sName="";
        List<Student_Search> myStudent = new List<Student_Search>();
        try
        {
            string sCondition=" Where sNo='"+ sNo +"'";
            myStudent = GetList(Campus, sCondition);
            if (myStudent.Count > 0)
            {
                sName = myStudent[0].SName;
            }
            
        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
            myStudent.Clear();
            
        }
        return sName;
    }
}
