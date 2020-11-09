using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//////using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
//using office = Microsoft.Office.Core;
using System.Text.RegularExpressions;
//using Microsoft.Office.Interop.Word;
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
//using DocumentFormat.OpenXml.Packaging;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



public class LibraryMOD
{
    public static int ExecuteSqlStatement(string ConnectionString, string SqlStatement)
    {
        int AffectedRows = 0;
        SqlConnection con = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand(SqlStatement, con);

        if (con.State != ConnectionState.Open)
            con.Open();

        AffectedRows = cmd.ExecuteNonQuery();

        if (con.State != ConnectionState.Closed)
            con.Close();
        return AffectedRows;
    }

    public static int GetMaxID(SqlConnection con, string ColName, string TableName)
    {
        int functionReturnValue = 0;
        try
        {
            string sSQL = null;

            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            SqlCommand CommSQL = new SqlCommand();
            CommSQL.Connection = con;

            sSQL = "SELECT Max(" + ColName + " ) as MaxID FROM " + TableName + "";

            CommSQL.CommandText = sSQL;

            int iMax = int.Parse("0" + CommSQL.ExecuteScalar().ToString());
            functionReturnValue = iMax;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }
    public static int GetStudentMoodleUserNo(string sUserName)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {

            sUserName = sUserName.Replace(".", "").Trim();
            string sSQL = "SELECT MoodleUserNo FROM Cmn_User WHERE UserName = '" + sUserName + "'";

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception ex)
        {
            return 0;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public static int GetStudentUserNo(string sUserName)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {

            sUserName = sUserName.Replace(".", "").Trim();
            string sSQL = "SELECT UserNo FROM Cmn_User WHERE UserName = '" + sUserName + "'";

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception ex)
        {
            return 0;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public static int GetMaxUnifiedID(InitializeModule.EnumCampus Campus, int iSerialNo, out string FName)
    {
        int functionReturnValue = 0;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        string sFName = "";

        try
        {
            string sSQL = null;

            sSQL = "SELECT LUnified.MUnifiedID, SD.strFirstDescEn";
            //sSQL += ",SD.lngSerial";
            //sSQL += ", SD.strLastDescEn AS Name, SD.iUnifiedID, A.intStudyYear * 10 + A.byteSemester AS Term, A.lngStudentNumber";
            sSQL += " FROM     Reg_Students_Data AS SD INNER JOIN";
            sSQL += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial LEFT OUTER JOIN";
            sSQL += " Reg_Applications AS A0 ON A.sReference = A0.lngStudentNumber CROSS JOIN";
            sSQL += " (SELECT  MAX(iUnifiedID) + 1 AS MUnifiedID";
            sSQL += " FROM     Reg_Students_Data AS SD) AS LUnified";
            sSQL += " WHERE  (SD.iUnifiedID IS NULL) AND (A0.lngStudentNumber IS NULL) ";
            if (Campus == InitializeModule.EnumCampus.Males)
            {
                sSQL += " AND (SD.byteShift = 3 OR";
                sSQL += " SD.byteShift = 4 OR";
                sSQL += " SD.byteShift = 8)";
            }
            else
            {
                sSQL += " AND (SD.byteShift = 1 OR";
                sSQL += " SD.byteShift = 2 OR";
                sSQL += " SD.byteShift = 9)";
            }
            sSQL += " AND (SD.lngSerial = " + iSerialNo + ")";


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader rd = Cmd.ExecuteReader();
            int iMax = 0;

            while (rd.Read())
            {
                iMax = int.Parse("0" + rd["MUnifiedID"].ToString());
                sFName = rd["strFirstDescEn"].ToString();
            }
            rd.Close();

            //FName = sFName;
            functionReturnValue = iMax;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        FName = sFName;
        return functionReturnValue;
    }
    public static bool UpdateStudentUnifiedID(InitializeModule.EnumCampus Campus, int iSerialNo, int iUnifiedID)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        bool isChanged = false;
        try
        {

            string sSQL = "UPDATE Reg_Students_Data";
            sSQL += " SET iUnifiedID = " + iUnifiedID;
            sSQL += " WHERE lngSerial=" + iSerialNo;

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            int iEffected = 0;

            iEffected = Cmd.ExecuteNonQuery();
            isChanged = (iEffected > 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isChanged;
    }
    public static bool UpdateStudentUnifiedIDIfHasRefID(InitializeModule.EnumCampus Campus, int iSerialNo)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        bool isChanged = false;
        try
        {

            string sSQL = "UPDATE SD SET SD.iUnifiedID=SD0.iUnifiedID";
            sSQL += " FROM Reg_Students_Data AS SD INNER JOIN";
            sSQL += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN";
            sSQL += " Reg_Applications AS A0 ON A.sReference = A0.lngStudentNumber INNER JOIN";
            sSQL += " Reg_Students_Data AS SD0 ON A0.lngSerial = SD0.lngSerial";
            sSQL += " WHERE (SD.iUnifiedID IS NULL OR";
            sSQL += " SD.iUnifiedID <> SD0.iUnifiedID) ";
            if (Campus == InitializeModule.EnumCampus.Males)
            {
                sSQL += " AND (SD.byteShift = 3 OR SD.byteShift = 4 OR SD.byteShift = 8)";
            }
            else
            {
                sSQL += " AND (SD.byteShift = 1 OR SD.byteShift = 2 OR SD.byteShift = 9)";
            }
            sSQL += " AND (SD0.iUnifiedID IS NOT NULL) ";
            sSQL += " AND (SD.sECTemail IS NULL)";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            int iEffected = 0;

            iEffected = Cmd.ExecuteNonQuery();
            isChanged = (iEffected > 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isChanged;
    }
    public static int GetUnifiedID(InitializeModule.EnumCampus Campus, int iSerialNo)
    {
        int functionReturnValue = 0;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();


        try
        {
            string sSQL = null;

            sSQL = "SELECT SD.iUnifiedID";
            sSQL += " FROM Reg_Students_Data AS SD";
            sSQL += " WHERE (SD.lngSerial = " + iSerialNo + ")";


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader rd = Cmd.ExecuteReader();
            int iUID = 0;

            while (rd.Read())
            {
                iUID = int.Parse("0" + rd["iUnifiedID"].ToString());
            }
            rd.Close();


            functionReturnValue = iUID;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }
    public static int GetUnifiedID(InitializeModule.EnumCampus Campus, int iSerialNo, out string FName)
    {
        int functionReturnValue = 0;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();

        string sFName = "";
        try
        {
            string sSQL = null;

            sSQL = "SELECT SD.iUnifiedID, SD.strFirstDescEn";
            sSQL += " FROM Reg_Students_Data AS SD";
            sSQL += " WHERE (SD.lngSerial = " + iSerialNo + ")";


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader rd = Cmd.ExecuteReader();
            int iUID = 0;

            while (rd.Read())
            {
                iUID = int.Parse("0" + rd["iUnifiedID"].ToString());
                sFName = rd["strFirstDescEn"].ToString();
            }
            rd.Close();


            functionReturnValue = iUID;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        FName = sFName;
        return functionReturnValue;
    }
    public static int GetMaxUnifiedID_withoutCheckRefID(InitializeModule.EnumCampus Campus, int iSerialNo, out string FName)
    {
        int functionReturnValue = 0;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        string sFName = "";

        try
        {
            string sSQL = null;

            sSQL = "SELECT LUnified.MUnifiedID, SD.strFirstDescEn";
            //sSQL += ",SD.lngSerial";
            //sSQL += ", SD.strLastDescEn AS Name, SD.iUnifiedID, A.intStudyYear * 10 + A.byteSemester AS Term, A.lngStudentNumber";
            sSQL += " FROM     Reg_Students_Data AS SD INNER JOIN";
            sSQL += " Reg_Applications AS A ON SD.lngSerial = A.lngSerial";
            sSQL += " CROSS JOIN";
            sSQL += " (SELECT  MAX(iUnifiedID) + 1 AS MUnifiedID";
            sSQL += " FROM     Reg_Students_Data AS SD) AS LUnified";
            sSQL += " WHERE  (SD.iUnifiedID IS NULL) ";
            if (Campus == InitializeModule.EnumCampus.Males)
            {
                sSQL += " AND (SD.byteShift = 3 OR";
                sSQL += " SD.byteShift = 4 OR";
                sSQL += " SD.byteShift = 8)";
            }
            else
            {
                sSQL += " AND (SD.byteShift = 1 OR";
                sSQL += " SD.byteShift = 2 OR";
                sSQL += " SD.byteShift = 9)";
            }
            sSQL += " AND (SD.lngSerial = " + iSerialNo + ")";


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader rd = Cmd.ExecuteReader();
            int iMax = 0;

            while (rd.Read())
            {
                iMax = int.Parse("0" + rd["MUnifiedID"].ToString());
                sFName = rd["strFirstDescEn"].ToString();
            }
            rd.Close();

            //FName = sFName;
            functionReturnValue = iMax;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        FName = sFName;
        return functionReturnValue;
    }
    public static bool UpdateStudentEmail(InitializeModule.EnumCampus Campus, int iSerialNo, string sEmail)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        bool isChanged = false;
        try
        {

            string sSQL = "UPDATE Reg_Students_Data";
            sSQL += " SET sECTemail = '" + sEmail + "'";
            sSQL += " ,IsEmailCreationRequired =1";
            sSQL += " WHERE lngSerial=" + iSerialNo;

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            int iEffected = 0;

            iEffected = Cmd.ExecuteNonQuery();
            isChanged = (iEffected > 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isChanged;
    }
    public static int GetCurrentRegisteredCourses(InitializeModule.EnumCampus Campus, string sNo, int iYear, int iSem)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        int iCurrentReg = 0;
        try
        {


            string sSQL = "SELECT MCRS + FCRS AS Reg FROM Reg_Both_Side ";
            sSQL += " WHERE Student='" + sNo + "'";
            sSQL += " AND (iYear = " + iYear + ") AND (Sem = " + iSem + ")";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            iCurrentReg = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString());

        }
        catch (Exception exp)
        {

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return iCurrentReg;
    }
    public static int GetMaxID(SqlConnection con, string ColName, string sPKCol, int iPKColValue, string TableName)
    {
        int functionReturnValue = 0;
        try
        {
            string sSQL = null;

            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            SqlCommand CommSQL = new SqlCommand();
            CommSQL.Connection = con;

            sSQL = "SELECT Max(" + ColName + " ) as MaxID FROM " + TableName + "";
            sSQL += " WHERE " + sPKCol + "=" + iPKColValue;
            sSQL += " GROUP BY " + sPKCol;

            CommSQL.CommandText = sSQL;

            object Result = CommSQL.ExecuteScalar();

            if (Result != null)
                functionReturnValue = Convert.ToInt32(Result);
            else
                functionReturnValue = 0;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }

    public static int GetMaxID(SqlConnection con, string ColMaxName, string ColGroup, string Condition, string TableName)
    {
        int functionReturnValue = 0;
        try
        {
            string sSQL = null;

            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            SqlCommand CommSQL = new SqlCommand();
            CommSQL.Connection = con;

            sSQL = "SELECT MAX(CONVERT(int, " + ColMaxName + ")) AS MaxID FROM " + TableName + "";
            sSQL += " WHERE " + Condition;

            if (ColGroup != "")
            {
                sSQL += " GROUP BY " + ColGroup;
            }

            CommSQL.CommandText = sSQL;

            object Result = CommSQL.ExecuteScalar();

            if (Result != null)
                functionReturnValue = Convert.ToInt32(Result);
            else
                functionReturnValue = 0;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }

    public static int GetMaxID(SqlConnection con, string ColName, string TableName, string sCondition)
    {
        int functionReturnValue = 0;
        try
        {
            string sSQL = null;

            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            SqlCommand CommSQL = new SqlCommand();
            CommSQL.Connection = con;

            sSQL = "SELECT COALESCE(Max(" + ColName + "), 0) as MaxID FROM " + TableName + "";
            if (!string.IsNullOrEmpty(sCondition))
            {
                sSQL += " Where " + sCondition;
            }
            CommSQL.CommandText = sSQL;

            int iMax = int.Parse(CommSQL.ExecuteScalar().ToString());
            functionReturnValue = iMax;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }

    public static string GetColValue(SqlConnection con, string ColName, string TableName, string sWhere)
    {
        SqlCommand CommSQL = new SqlCommand();

        string functionReturnValue = "";
        try
        {
            string sSQL = null;

            //Dim CommSQL As New SqlClient.SQLDbCommand(sSQL, conn) 
            CommSQL.Connection = con;

            sSQL = "SELECT " + ColName + " as ColValue FROM " + TableName + "";
            sSQL += " Where " + sWhere;

            CommSQL.CommandText = sSQL;

            string ColValue = CommSQL.ExecuteScalar().ToString();
            functionReturnValue = ColValue;

        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return functionReturnValue;
    }

    public static string RemoveSeperator(string sString, string sSeperator)
    {
        int lPos = 0;
        string sResult = sString;

        try
        {

            lPos = sString.IndexOf(sSeperator);

            while (lPos > 0)
            {
                if (lPos > 0)
                {
                    sResult = sResult.Substring(0, lPos) + sResult.Substring(lPos + 1);
                }
                else
                {
                    //"." not found in the string 
                    sResult = sString;
                }
                lPos = sResult.IndexOf(sSeperator);

            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }

        return sResult;
    }
    public static string GetSelectedOperator(int iOperator)
    {
        string selectedOperator = "";
        switch (iOperator)
        {
            case 1:
                selectedOperator = "=";
                break;
            case 2:
                selectedOperator = ">";
                break;
            case 3:
                selectedOperator = ">=";
                break;
            case 4:
                selectedOperator = "<";
                break;
            case 5:
                selectedOperator = "<=";
                break;
            case 6:
                selectedOperator = "<>";
                break;
            case 7:
                selectedOperator = "Between";
                break;
        }
        return selectedOperator;
    }

    public static Array ParseString(string sString, string sSeperator)
    {
        int lPos = 0;
        string sResult = sString;
        string[] arr = null;
        string sPart = "";
        int index = 0;
        try
        {

            lPos = sString.IndexOf(sSeperator);

            while (lPos > -1)
            {
                if (lPos > -1)
                {
                    sPart = sResult.Substring(0, lPos);
                    sResult = sResult.Substring(lPos + 1);
                }
                else
                {
                    //"." not found in the string 
                    sResult = sString;
                }
                Array.Resize(ref arr, index + 1);
                arr[index] = sPart;

                lPos = sResult.IndexOf(sSeperator);
                index = index + 1;

            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }

        return arr;
    }
    public static string GetFieldName(string sString)
    {
        int lPos = 0;
        string sResult = "";

        try
        {
            lPos = sString.IndexOf(".");

            if (lPos > 0)
            {
                sResult = sString.Substring(lPos + 1);
            }
            else
            {
                //"." not found in the string 
                sResult = sString;

            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }

        return sResult;
    }
    //public static bool IsUserHavePermission(int lRoleID, int lObjectID, int lPermID)
    //{

    //    bool functionReturnValue = false;
    //    string sSQL = null;
    //    SqlCommand cmdRolePermission = new SqlCommand();

    //    sSQL = "SELECT " + theRolePermission.PrivilegeEffectFN;
    //    sSQL += " FROM " + theRolePermission.TableName;
    //    sSQL += " WHERE " + theRolePermission.RoleIDFN + "=" + lRoleID;
    //    sSQL += " AND " + theRolePermission.ObjectIDFN + "=" + lObjectID;
    //    sSQL += " AND " + theRolePermission.PrivilegeIDFN + "=" + lPermID;

    //    cmdRolePermission.Connection = conn;
    //    cmdRolePermission.CommandText = sSQL;
    //    //----------------------------------------- 
    //    SqlClient.SqlDataReader datReader = default(SqlClient.SqlDataReader);

    //    datReader = cmdRolePermission.ExecuteReader();

    //    if (datReader.Read)
    //    {
    //        functionReturnValue = (bool)datReader.GetInt32(0);
    //    }
    //    datReader.Close();
    //    datReader = null;
    //    cmdRolePermission = null;
    //    return functionReturnValue;
    //}

    public static void ShowErrorMessage(Exception excp)
    {
        string sMsg = null;

        sMsg = "Error in " + excp.Source + ".";
        sMsg += "\n Description: " + excp.Message;
        Console.WriteLine("{0} Exception caught.", sMsg);
    }

    public static int DateToNumber(System.DateTime pDate)
    {
        int functionReturnValue = 0;
        int llngDateNumber = 0;
        string lDate = null;
        try
        {
            lDate = pDate.ToString("{0:d}");
            //llngDateNumber = (DatePart(DateInterval.Year, (System.DateTime)lDate) * 100 + DatePart(DateInterval.Month, (System.DateTime)lDate)) * 100 + DatePart(DateInterval.Day, (System.DateTime)lDate);
            llngDateNumber = (((pDate.Year * 100) + pDate.Month) * 100) + pDate.Day;

            //format(pDate,"yyyy/MM/dd") 
            functionReturnValue = llngDateNumber;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }
        return functionReturnValue;
    }

    public static int TimeToNumber(System.DateTime pTime)
    {

        int functionReturnValue = 0;
        int llngTimeNumber = 0;
        string lTime = null;

        try
        {
            lTime = pTime.ToString("{0:t}");
            llngTimeNumber = pTime.Hour * 100 + pTime.Minute;

            functionReturnValue = llngTimeNumber;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }
        return functionReturnValue;
    }
    //public static int TimeToNumber(string sTime)
    //{

    //    int functionReturnValue = 0;
    //    int llngTimeNumber = 0;
    //    string lTime = null;

    //    try
    //    {
    //        lTime = Strings.Format((System.DateTime)sTime, "HH:mm");
    //        llngTimeNumber = (Hour(lTime) * 100 + Minute(lTime));

    //        functionReturnValue = llngTimeNumber;
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowErrorMessage(ex.InnerException);
    //    }
    //    finally
    //    {

    //    }
    //    return functionReturnValue;
    //}

    public static string NumberToDate(int pDate)
    {

        int llngDateNumber = 0;
        string sDate = "";
        string lstrYear = null;
        string lstrMonth = null;
        string lstrDay = null;
        try
        {
            llngDateNumber = pDate;
            lstrYear = (llngDateNumber / 10000).ToString().Trim();
            llngDateNumber -= int.Parse(lstrYear) * 10000;
            lstrMonth = (llngDateNumber / 100).ToString().Trim();
            llngDateNumber -= int.Parse(lstrMonth) * 100;
            lstrDay = llngDateNumber.ToString().Trim();
            //llngDateNumber = pDate;
            if (llngDateNumber == 0) return "";

            //lstrYear = Conversion.Str(llngDateNumber / 10000).Trim;
            //llngDateNumber = llngDateNumber - Conversion.Val(lstrYear) * 10000;

            //lstrMonth = Conversion.Str(llngDateNumber / 100);
            //llngDateNumber = llngDateNumber - Conversion.Val(lstrMonth) * 100;

            //lstrDay = Conversion.Str(llngDateNumber);
            //sDate = String.Trim(lstrDay).PadLeft(2, "0") + "/" + String.Trim(lstrMonth).PadLeft(2, "0") + "/" + String.Trim(lstrYear);
            sDate = lstrDay.PadLeft(2, '0') + "/" + lstrMonth.PadLeft(2, '0') + "/" + lstrYear;

            //sDate = Strings.Trim(lstrDay).PadLeft(2, "0") + "/" + Strings.Trim(lstrMonth).PadLeft(2, "0") + "/" + Strings.Trim(lstrYear);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }

        //if (!Information.IsDate(sDate))
        //{
        //    string sNewDate = null;
        //    sNewDate = pDate;

        //    sDate = ValidateDate(sNewDate);
        //}
        return sDate;
    }
    public static string NumberToDate(int pDate, string sDateSeperator)
    {

        int llngDateNumber = 0;
        string sDate = "";
        string lstrYear = null;
        string lstrMonth = null;
        string lstrDay = null;
        try
        {
            llngDateNumber = pDate;
            lstrYear = (llngDateNumber / 10000).ToString().Trim();
            llngDateNumber -= int.Parse(lstrYear) * 10000;
            lstrMonth = (llngDateNumber / 100).ToString().Trim();
            llngDateNumber -= int.Parse(lstrMonth) * 100;
            lstrDay = llngDateNumber.ToString().Trim();
            //llngDateNumber = pDate;
            if (llngDateNumber == 0) return "";

            //lstrYear = Conversion.Str(llngDateNumber / 10000).Trim;
            //llngDateNumber = llngDateNumber - Conversion.Val(lstrYear) * 10000;

            //lstrMonth = Conversion.Str(llngDateNumber / 100);
            //llngDateNumber = llngDateNumber - Conversion.Val(lstrMonth) * 100;

            //lstrDay = Conversion.Str(llngDateNumber);
            //sDate = String.Trim(lstrDay).PadLeft(2, "0") + "/" + String.Trim(lstrMonth).PadLeft(2, "0") + "/" + String.Trim(lstrYear);
            sDate = lstrDay.PadLeft(2, '0') + sDateSeperator + lstrMonth.PadLeft(2, '0') + sDateSeperator + lstrYear;

            //sDate = Strings.Trim(lstrDay).PadLeft(2, "0") + "/" + Strings.Trim(lstrMonth).PadLeft(2, "0") + "/" + Strings.Trim(lstrYear);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }

        //if (!Information.IsDate(sDate))
        //{
        //    string sNewDate = null;
        //    sNewDate = pDate;

        //    sDate = ValidateDate(sNewDate);
        //}
        return sDate;
    }
    public static string NumberToDateMMddYYYY(int pDate)
    {

        int llngDateNumber = 0;
        string sDate = "";
        string lstrYear = null;
        string lstrMonth = null;
        string lstrDay = null;
        try
        {
            llngDateNumber = pDate;
            lstrYear = (llngDateNumber / 10000).ToString().Trim();
            llngDateNumber -= int.Parse(lstrYear) * 10000;
            lstrMonth = (llngDateNumber / 100).ToString().Trim();
            llngDateNumber -= int.Parse(lstrMonth) * 100;
            lstrDay = llngDateNumber.ToString().Trim();
            //llngDateNumber = pDate;
            //if (llngDateNumber == 0) return "";

            //lstrYear = Conversion.Str(llngDateNumber / 10000).Trim;
            //llngDateNumber = llngDateNumber - Conversion.Val(lstrYear) * 10000;

            //lstrMonth = Conversion.Str(llngDateNumber / 100);
            //llngDateNumber = llngDateNumber - Conversion.Val(lstrMonth) * 100;

            //lstrDay = Conversion.Str(llngDateNumber);
            //sDate = String.Trim(lstrDay).PadLeft(2, "0") + "/" + String.Trim(lstrMonth).PadLeft(2, "0") + "/" + String.Trim(lstrYear);
            sDate = lstrMonth.PadLeft(2, '0') + "/" + lstrDay.PadLeft(2, '0') + "/" + lstrYear;

            //sDate = Strings.Trim(lstrDay).PadLeft(2, "0") + "/" + Strings.Trim(lstrMonth).PadLeft(2, "0") + "/" + Strings.Trim(lstrYear);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }

        //if (!Information.IsDate(sDate))
        //{
        //    string sNewDate = null;
        //    sNewDate = pDate;

        //    sDate = ValidateDate(sNewDate);
        //}
        return sDate;
    }
    public static int DayFromDate(int pDate)
    {

        int llngDateNumber = 0;

        int iYear = 0;
        int iMonth = 0;
        int iDay = 0;
        try
        {
            llngDateNumber = pDate;
            if (llngDateNumber == 0) return 0;

            iYear = llngDateNumber / 10000;
            llngDateNumber -= (iYear * 10000);

            iMonth = llngDateNumber / 100;

            llngDateNumber -= (iMonth * 100);


            iDay = llngDateNumber;
        }
        catch (Exception ex)
        {

            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }

        return iDay;
    }

    public static int MonthFromDate(int pDate)
    {

        int llngDateNumber = 0;

        int iYear = 0;
        int iMonth = 0;

        try
        {
            llngDateNumber = pDate;
            if (llngDateNumber == 0) return 0;

            iYear = llngDateNumber / 10000;
            llngDateNumber -= (iYear * 10000);

            iMonth = llngDateNumber / 100;
        }
        catch (Exception ex)
        {


            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }

        return iMonth;
    }
    public static int YearFromDate(int pDate)
    {

        int llngDateNumber = 0;

        int iYear = 0;

        try
        {
            llngDateNumber = pDate;
            if (llngDateNumber == 0) return 0;


            iYear = llngDateNumber / 10000;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }

        return iYear;
    }


    public static string ValidateDate(string sDate)
    {
        string sday = null;
        string sMonth = null;
        string sYear = null;

        switch (sDate.Length)
        {
            case 6:


                //sday = Microsoft.VisualBasic.Left(sDate, 1).PadLeft(2, "0");
                sday = sDate.Substring(0, 1).PadLeft(2, '0');
                //sMonth = Microsoft.VisualBasic.Mid(sDate, 2, 1).PadLeft(2, "0");                               
                sMonth = sDate.Substring(1, 1).PadLeft(2, '0');
                //sYear = Microsoft.VisualBasic.Right(sDate, 4);
                sYear = sDate.Substring(2, 4);
                sDate = sday + "/" + sMonth + "/" + sYear;

                break;
            case 7:


                sday = sDate.Substring(0, 2);
                if (int.Parse(sday) > 31)
                {
                    sday = sDate.Substring(0, 1).PadLeft(2, '0');
                    sMonth = sDate.Substring(1, 2).PadLeft(2, '0');
                }

                sMonth = sDate.Substring(2, 1).PadLeft(2, '0'); ;

                sYear = sDate.Substring(3, 4);

                if (int.Parse(sMonth) == 2 & int.Parse(sday) > 29)
                {
                    switch (int.Parse(sYear) % 4)
                    {
                        case 0:
                            sday = "29";
                            break;
                        default:
                            sday = "28";
                            break;
                    }
                }



                sDate = sday + "/" + sMonth + "/" + sYear;
                break;
            case 8:

                System.DateTime mDate = default(System.DateTime);

                sday = sDate.Substring(0, 2);
                sMonth = sDate.Substring(2, 2);
                sYear = sDate.Substring(4, 4);

                if (int.Parse(sYear) >= 1900 & int.Parse(sYear) <= 2100)
                {

                }
                else
                {
                    //sday = Microsoft.VisualBasic.Right(sDate, 2);
                    //sMonth = Microsoft.VisualBasic.Mid(sDate, 5, 2);

                    sYear = sDate.Substring(0, 4);
                    sMonth = sDate.Substring(4, 2);
                    sday = sDate.Substring(6, 2);
                }


                //================ 
                sDate = sday + "/" + sMonth + "/" + sYear;

                mDate = DateTime.Parse(sDate);
                sDate = mDate.ToString("{0:d}");

                break;


        }

        return sDate;
    }
    public static string NumberToDateAr(int pDate)
    {

        int llngDateNumber = 0;
        string lDate = "";
        string lstrYear = null;
        string lstrMonth = null;
        string lstrDay = null;
        try
        {
            llngDateNumber = pDate;
            if (llngDateNumber == 0) return "";

            lstrYear = (llngDateNumber / 10000).ToString().Trim();
            llngDateNumber -= int.Parse(lstrYear) * 10000;

            lstrMonth = (llngDateNumber / 100).ToString().Trim();
            llngDateNumber -= int.Parse(lstrMonth) * 100;

            lstrDay = llngDateNumber.ToString().Trim();


            lDate = lstrYear + "/" + lstrMonth + "/" + lstrDay;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }
        return lDate;
    }
    public static string NumberToDateAr(int pDate, string sSeperator)
    {

        int llngDateNumber = 0;
        string lDate = "";
        string lstrYear = null;
        string lstrMonth = null;
        string lstrDay = null;
        try
        {
            llngDateNumber = pDate;
            if (llngDateNumber == 0) return "";

            lstrYear = (llngDateNumber / 10000).ToString().Trim();
            llngDateNumber -= int.Parse(lstrYear) * 10000;

            lstrMonth = (llngDateNumber / 100).ToString().Trim();
            llngDateNumber -= int.Parse(lstrMonth) * 100;

            lstrDay = llngDateNumber.ToString().Trim();


            lDate = lstrYear + sSeperator + lstrMonth + sSeperator + lstrDay;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }
        return lDate;
    }
    public static string NumberToTime(int pTime)
    {

        int llngTimeNumber = 0;
        string lTime = "";
        string lstrHour = null;
        string lstrMinute = null;
        try
        {
            llngTimeNumber = pTime;
            //lstrHour = 2 'space 
            lstrHour = (llngTimeNumber / 100).ToString().Trim();
            llngTimeNumber -= int.Parse(lstrHour) * 100;

            //lstrMinute = SPACE$(2) 
            lstrMinute = llngTimeNumber.ToString().Trim();

            //lTime = SPACE$(5) 

            lTime = lstrHour + ":" + lstrMinute.PadLeft(2, '0');
        }
        catch (Exception ex)
        {

            ShowErrorMessage(ex.InnerException);
        }
        finally
        {

        }
        lTime = DateTime.Parse(lTime).ToShortTimeString();

        return lTime;
    }

    //public static string ReturnTempDirectory()
    //{
    //    string sPath = "";
    //    try
    //    {


    //        sPath = My.Computer.FileSystem.SpecialDirectories.Temp;
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowErrorMessage(ex.InnerException);
    //    }
    //    finally
    //    {

    //    }
    //    return sPath;
    //}


    //public static string ReturnApplicationDataDirectory()
    //{
    //    string sPath = "";
    //    try
    //    {


    //        sPath = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData;
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowErrorMessage(ex.InnerException);
    //    }
    //    finally
    //    {

    //    }
    //    return sPath;
    //}
    //public static string ReturnDesktopDirectory()
    //{
    //    string sPath = "";
    //    try
    //    {


    //        sPath = My.Computer.FileSystem.SpecialDirectories.Desktop;
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowErrorMessage(ex.InnerException);
    //    }
    //    finally
    //    {

    //    }
    //    return sPath;
    //}
    //public static string ReturnComputerName()
    //{
    //    string sTemp = "";
    //    try
    //    {


    //        sTemp = My.Computer.Name;
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowErrorMessage(ex.InnerException);
    //    }
    //    finally
    //    {

    //    }
    //    return sTemp;
    //}
    //public static string ReturnUserName()
    //{
    //    string sTemp = "";
    //    try
    //    {

    //        sTemp = My.User.Name;
    //        int lSlashPosition = sTemp.LastIndexOf("\\");

    //        sTemp = sTemp.Substring(lSlashPosition + 1);
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowErrorMessage(ex.InnerException);
    //    }
    //    finally
    //    {

    //    }
    //    return sTemp;
    //}
    public static string GetSemesterString(int iSemesterID)
    {
        switch (iSemesterID)
        {
            case 1:
                return "Fall";
            case 2:
                return "Spring";
            case 3:
                return "Summer 1";
            case 4:
                return "Summer 2";
            default:
                return "";
        }
    }
    public static string GetSpecialization_FullName_Display(string sMajorCode, InitializeModule.EnumCampus Campus)
    {
        string result = "";
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);

        string sSQL = "Select strDisplay from Reg_Specializations";
        sSQL += " Where strMajor='" + sMajorCode + "'";
        
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

        try
        {

            while (reader.Read())
            {
                result = reader["strDisplay"].ToString();
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
        return result;
    }

    public static string GetTermDesc(int iYear, int iSemester)
    {
        string sTerm = "";
        string sSem = "";
        string sYear = "";

        switch (iSemester)
        {
            case 1:
                sSem = "Fall";
                break;
            case 2:
                sSem = "Spring";
                break;
            case 3:
                sSem = "Summer 1";
                break;
            case 4:
                sSem = "Summer 2";
                break;
        }
        if (iSemester > 1)
        {
            sYear = (iYear + 1).ToString();
        }
        else
        {
            sYear = iYear.ToString();
        }

        sTerm = sYear + " " + sSem;

        return sTerm;
    }
    public static string GetTermDescSem_Year(int iYear, int iSemester)
    {
        string sTerm = "";
        string sSem = "";
        string sYear = "";

        switch (iSemester)
        {
            case 1:
                sSem = "Fall";
                break;
            case 2:
                sSem = "Spring";
                break;
            case 3:
                sSem = "Summer 1";
                break;
            case 4:
                sSem = "Summer 2";
                break;
        }
        if (iSemester > 1)
        {
            sYear = (iYear + 1).ToString();
        }
        else
        {
            sYear = iYear.ToString();
        }

        sTerm =sSem  + " " + sYear;

        return sTerm;
    }
    public static int GetMaxInGrid(DataView dvGrid, string sFieldName)
    {
        int iMax = 0;
        int iTemp = 0;

        int i = 0;
        for (i = 0; i <= dvGrid.Count - 1; i++)
        {

            if (dvGrid[i][sFieldName] == System.DBNull.Value)
            {
                iTemp = 0;
            }
            else
            {
                iTemp = (int)dvGrid[i][sFieldName];
            }
            if (iTemp > iMax)
            {
                iMax = iTemp;

            }
        }
        return iMax;
    }

    public static string CorrectDateFormat(string sDate)
    {

        System.DateTime mDate = default(System.DateTime);
        try
        {
            if (sDate == "")
            {
                sDate = "";
                return sDate;
            }
            if (sDate.IndexOf("/") == -1)
            {
                sDate = ValidateDate(sDate);
            }



            mDate = DateTime.Parse(sDate);
            sDate = mDate.ToString("{0:d}");


            sDate = RemoveSeperator(sDate, "/");
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }

        return sDate;
    }

    public static int SeperateTerm(int Term, out int Semester)
    {
        int localTerm = Term;
        int localYear = localTerm / 10;
        Semester = localTerm - (localYear * 10);

        return localYear;
    }

    public static InitializeModule.EnumCampus SyncCampusAndSession(string sPeriod, out int iPeriod)
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        iPeriod = int.Parse(sPeriod);
        try
        {
            switch (iPeriod)
            {
                case 1:
                case 2:
                case 9:
                case -1:

                    Campus = InitializeModule.EnumCampus.Females;
                    break;

                case 3:
                case 4:
                case 8:
                case -2:
                    Campus = InitializeModule.EnumCampus.Males;
                    break;
            }

            if (iPeriod < 0)
            {
                iPeriod = 0;
            }


        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
        }
        return Campus;
    }

    public static int GetTerm(int AcadimecYear, int Semester)
    {

        int localTerm = (AcadimecYear * 10) + Semester;

        return localTerm;

    }



    public static bool isRoleAuthorized(InitializeModule.enumPrivilegeObjects ObjID, InitializeModule.enumPrivilege PrivilegeID, int RoleId)
    {
        List<Privilege> myPrivileges = new List<Privilege>();
        RoleDAL myRoleDAL = new RoleDAL();
        bool isIt = false;
        try
        {
            myPrivileges = myRoleDAL.GetRoleObjPermissions((int)ObjID, RoleId);
            for (int i = 0; i < myPrivileges.Count; i++)
            {
                if ((int)PrivilegeID == myPrivileges[i].PrivilegeID)
                {
                    isIt = true;
                    return isIt;
                }
            }

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            myPrivileges.Clear();
        }
        return isIt;
    }

    public static string GetButtonImageURL(InitializeModule.ECT_Buttons Button, bool isEnabled)
    {
        string sURL = "";
        try
        {

            if (isEnabled)
            {
                switch (Button)
                {
                    case InitializeModule.ECT_Buttons.Print:
                        sURL = "Images/Icons/Print.gif";
                        break;
                    case InitializeModule.ECT_Buttons.ToExcel:
                        sURL = "Images/Icons/toExcel.gif";
                        break;
                    case InitializeModule.ECT_Buttons.ToWord:
                        sURL = "Images/Icons/toWord.gif";
                        break;
                    case InitializeModule.ECT_Buttons.Delete:
                        sURL = "Images/Icons/Delete.gif";
                        break;
                    case InitializeModule.ECT_Buttons.Save:
                        sURL = "Images/Icons/Save.gif";
                        break;
                    case InitializeModule.ECT_Buttons.New:
                        sURL = "Images/Icons/New_File.gif";
                        break;
                    case InitializeModule.ECT_Buttons.Run:
                        sURL = "Images/Icons/Run.gif";
                        break;
                    case InitializeModule.ECT_Buttons.Setting:
                        sURL = "Images/Icons/Setting.gif";
                        break;
                }
            }
            else
            {
                switch (Button)
                {
                    case InitializeModule.ECT_Buttons.Print:
                        sURL = "Images/Icons/Print_BW.jpg";
                        break;
                    case InitializeModule.ECT_Buttons.ToExcel:
                        sURL = "Images/Icons/toExcel_BW.jpg";
                        break;
                    case InitializeModule.ECT_Buttons.ToWord:
                        sURL = "Images/Icons/toWord_BW.jpg";
                        break;
                    case InitializeModule.ECT_Buttons.Delete:
                        sURL = "Images/Icons/Delete_BW.jpg";
                        break;
                    case InitializeModule.ECT_Buttons.Save:
                        sURL = "Images/Icons/Save_BW.jpg";
                        break;
                    case InitializeModule.ECT_Buttons.New:
                        sURL = "Images/Icons/New_File_BW.jpg";
                        break;
                    case InitializeModule.ECT_Buttons.Run:
                        sURL = "Images/Icons/Run_BW.jpg";
                        break;
                    case InitializeModule.ECT_Buttons.Setting:
                        sURL = "Images/Icons/Setting_BW.gif";
                        break;
                }
            }


        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {

        }
        return sURL;
    }

    public static int Sync_Days(DayOfWeek dDay)
    {
        int iDay = 0;
        try
        {
            switch (dDay)
            {
                case DayOfWeek.Saturday:
                    iDay = 1;
                    break;
                case DayOfWeek.Sunday:
                    iDay = 2;
                    break;
                case DayOfWeek.Monday:
                    iDay = 3;
                    break;
                case DayOfWeek.Tuesday:
                    iDay = 4;
                    break;
                case DayOfWeek.Wednesday:
                    iDay = 5;
                    break;
                case DayOfWeek.Thursday:
                    iDay = 6;
                    break;
                case DayOfWeek.Friday:
                    iDay = 7;
                    break;

            }

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {

        }
        return iDay;
    }

    public static DateTime GetDateFromString(string sDate)
    {

        DateTime dDate = DateTime.Today.Date;
        try
        {
            string[] aDateParts = new string[3];
            int iIndex = sDate.LastIndexOf("/");
            if (iIndex == 5)
            {
                aDateParts = sDate.Split('/');
                dDate = new DateTime(int.Parse(aDateParts[2]), int.Parse(aDateParts[1]), int.Parse(aDateParts[0]));
            }

        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }

        return dDate;
    }

    public static string GetOperator(InitializeModule.CeComparisonOperator iOperator)
    {
        string sOperator = "=";
        try
        {

            switch (iOperator)
            {
                case InitializeModule.CeComparisonOperator.EqualTo:
                    sOperator = "=";
                    break;
                case InitializeModule.CeComparisonOperator.GreaterThan:
                    sOperator = ">";
                    break;
                case InitializeModule.CeComparisonOperator.GreaterThanOrEqualTo:
                    sOperator = ">=";
                    break;
                case InitializeModule.CeComparisonOperator.LessThan:
                    sOperator = "<";
                    break;
                case InitializeModule.CeComparisonOperator.LessThanOrEqualTo:
                    sOperator = "<=";
                    break;
                case InitializeModule.CeComparisonOperator.NotEqualTo:
                    sOperator = "<>";
                    break;
                case InitializeModule.CeComparisonOperator.Between:
                    sOperator = "Between";
                    break;
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return sOperator;
    }

    public static string GetOption(InitializeModule.EnumOptions iOption)
    {
        string sOption = "=";
        try
        {
            switch (iOption)
            {
                case InitializeModule.EnumOptions.at:
                    sOption = "=";
                    break;
                case InitializeModule.EnumOptions.after:
                    sOption = ">";
                    break;
                case InitializeModule.EnumOptions.before:
                    sOption = "<";
                    break;
                case InitializeModule.EnumOptions.between:
                    sOption = "Between";
                    break;
            }


        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return sOption;
    }

    public static string GetUniversalDate(string sDate)
    {
        string sResult = "";

        try
        {
            sDate = ValidateDate(sDate);
            string sDay = sDate.Substring(0, 2);
            string sMonth = sDate.Substring(3, 2);
            string sYear = sDate.Substring(6, 4);
            sResult = sYear + sMonth + sDay;

        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return sResult;
    }

    public static string Major_Key(string sCollege, string sDegree, string sMajor)
    {
        string sResult = "";

        try
        {

            if (sMajor.Length > 1)
            {
                sResult = "0" + sCollege + "0" + sDegree + sMajor;
            }
            else
            {
                sResult = "0" + sCollege + "0" + sDegree + "0" + sMajor;
            }

        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return sResult;
    }

    public static int GetMaxHours(int iSemester, bool isENGRequired, bool isENGPassed, int iMaxESL, float CGPA, string sDegree, string sMajor)
    {
        int iMax = 0;
        int iENG = 0;
        //int[,]Hours={{12,9,9,6},{21,18,15,12}};
        // int[,] Hours = { { 12, 9, 9, 6 }, { 18, 18, 15, 12 } }; 29-7-2013
        //21 allowed for students if its last 7 courses


        //PR without TOEFL 450
        if ((sDegree == "1" && sMajor == "25") || (sDegree == "3" && sMajor == "21"))
        {
            if (iSemester < 3)
            {
                iMax = 12;
            }
            else
            {
                iMax = 3;
            }
            return iMax;
        }

        //ESL
        if ((sDegree == "2" && sMajor == "1"))
        {
            if (iSemester < 3)
            {
                iMax = 6;
            }
            else
            {
                iMax = 3;
            }
            return iMax;
        }

        //int[,] Hours = { { 9, 9, 6, 6 }, { 18, 18, 15, 12 } };
        int[,] Hours = { { 6, 6, 6, 6 }, { 18, 18, 15, 12 } };
        int iSemseterTmp = 0;
        try
        {

            if (iSemester < 3)
            {
                iMax = 18;
            }
            else if (iSemester == 3)
            {
                iMax = 6;
            }
            else
            {
                iMax = 6;
            }

            if (isENGRequired && !(isENGPassed))
            {
                if (iSemester < 3)
                {
                    iENG = 12;
                    switch (iMaxESL)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3://2ESL+2COURSES
                            iENG = 6;
                            break;
                        case 4://ESL104+2COURSE
                            iENG = 6;
                            break;
                        case 5://ESL04 Passed 3
                            if (CGPA >= 2)
                            {
                                iENG = 15;
                            }
                            else
                            {
                                iENG = 12;
                            }
                           break;
                    }
                }
                else
                {
                    iENG = 3;
                }
   
                
            }
            else
            {

                if (iSemester > 2)
                {
                    iSemseterTmp = 0;
                }
                else
                {
                    iSemseterTmp = 1;
                }

                if (CGPA >= 3.7 && CGPA <= 4)
                {
                    iENG = Hours[iSemseterTmp, 0];
                }
                else if (CGPA >= 2.5 && CGPA < 3.7)
                {
                    iENG = Hours[iSemseterTmp, 1];
                }
                else if (CGPA >= 2 && CGPA < 2.5)
                {
                    iENG = Hours[iSemseterTmp, 2];
                }
                else if (CGPA >= 0 && CGPA < 2)
                {
                    iENG = Hours[iSemseterTmp, 3];
                }
                else
                {
                    iENG = Hours[iSemseterTmp, 2];
                }

            }


            if (iENG < iMax)
            {
                iMax = iENG;
            }


        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {

        }
        return iMax;
    }

    public static bool isENGPassed(float Score, string sENG, string sDegree, string sMajor)
    {
        Connection_StringCLS MyConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
        Conn.Open();
        bool isPassed = false;
        //TOEFL Paper,IELTS Paper,TOEFL Computer,TOEFL Internet,TOEIC,PTE,Cambridge,IESOL,EMSAT
        double[] ENGs = { 500, 5, 173, 61, 550,44,154,500,1100 };


        try
        {
            string sSQL = "SELECT cTOEFLPass FROM Reg_Specializations WHERE strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "'";
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            double dPassScore = Double.Parse("0" + Cmd.ExecuteScalar().ToString());
            if (dPassScore == 0)
            {
                return false;
            }
            else if (dPassScore == 450)
            {
                ENGs[0] = 450;
                ENGs[1] = 4.5;
                ENGs[2] = 133;
                ENGs[3] = 45;
                ENGs[4] = 480;
                ENGs[5] = 38;
                ENGs[6] = 147;
                ENGs[7] = 450;
                ENGs[8] = 950;
            }


            switch (sENG.ToLower())
            {

                case "toefl paper":
                    isPassed = (Score >= ENGs[0]);
                    break;
                case "ielts paper":
                    isPassed = (Score >= ENGs[1]);
                    break;
                case "toefl computer":
                    isPassed = (Score >= ENGs[2]);
                    break;
                case "toefl internet":
                    isPassed = (Score >= ENGs[3]);
                    break;
                case "toeic":
                    isPassed = (Score >= ENGs[4]);
                    break;
                case "pte":
                    isPassed = (Score >= ENGs[5]);
                    break;
                case "cambridge":
                    isPassed = (Score >= ENGs[6]);
                    break;
                case "iesol":
                    isPassed = (Score >= ENGs[7]);
                    break;
                case "emsat english test":
                    isPassed = (Score >= ENGs[8]);
                    break;

            }
 

        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isPassed;
    }
    public static string GetStudentID(int SerialNo, int iCampus)
    {
        System.Data.SqlClient.SqlCommand sqlCmd;

        sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetStudentID";


        System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@SerialNo";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = SerialNo;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);



        //'====================================
        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@StudentID";
        parameter.IsNullable = true;
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Size = 12;
        parameter.Direction = ParameterDirection.Output;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);


        Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        Conn.Open();

        sqlCmd.Connection = Conn;


        //System.Data.SqlClient.SqlDataReader reader;
        //reader = sqlCmd.ExecuteReader();

        sqlCmd.ExecuteNonQuery();
        string sStudentID = sqlCmd.Parameters["@StudentID"].Value.ToString();

        Conn.Close();
        return sStudentID;

    }
    public static int GetStudentSerialNo(string sStudentID, int iCampus)
    {
        System.Data.SqlClient.SqlCommand sqlCmd;

        sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetStudentSerialNo";


        System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@StudentID";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Char;
        parameter.Size = 12;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = sStudentID;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);



        //'====================================
        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@SerialNo";
        parameter.IsNullable = true;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 8;
        parameter.Direction = ParameterDirection.Output;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);


        Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        Conn.Open();

        sqlCmd.Connection = Conn;


        //System.Data.SqlClient.SqlDataReader reader;
        //reader = sqlCmd.ExecuteReader();

        sqlCmd.ExecuteNonQuery();
        int iStudentSerialNo = Convert.ToInt32("0" + sqlCmd.Parameters["@SerialNo"].Value);

        Conn.Close();
        return iStudentSerialNo;

    }
    public static string GetStudentNameById(InitializeModule.EnumCampus Campus, string sStudentId)
    {
        Connection_StringCLS sConn = new Connection_StringCLS(Campus);

        string sSQL = "SELECT Reg_Students_Data.strLastDescEn ";
        sSQL += "FROM Reg_Applications INNER JOIN ";
        sSQL += "Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial ";
        sSQL += "WHERE Reg_Applications.lngStudentNumber = '" + sStudentId + "'";

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

        string sStudentName = "";
        try
        {
            if (Rd.HasRows)
            {
                Rd.Read();
                sStudentName = Rd[0].ToString();
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


        return sStudentName;
    }
    public static string GetStudentRefID(string sStudentID, int iCampus)
    {
        System.Data.SqlClient.SqlCommand sqlCmd;

        sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetStudentRefID";


        System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@StudentID";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Char;
        parameter.Size = 12;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = sStudentID;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);



        //'====================================
        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@RefID";
        parameter.IsNullable = true;
        parameter.SqlDbType = SqlDbType.Char;
        parameter.Size = 12;
        parameter.Direction = ParameterDirection.Output;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);


        Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        Conn.Open();

        sqlCmd.Connection = Conn;


        //System.Data.SqlClient.SqlDataReader reader;
        //reader = sqlCmd.ExecuteReader();

        sqlCmd.ExecuteNonQuery();
        string sStudentRefID = Convert.ToString(sqlCmd.Parameters["@RefID"].Value);

        Conn.Close();
        return sStudentRefID;

    }
    public static int GetStudentCertLevel(int CertNo, decimal Mark, int iCampus)
    {
        System.Data.SqlClient.SqlCommand sqlCmd;

        sqlCmd = new System.Data.SqlClient.SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetStudentCertLevel";


        System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@CertNo";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = CertNo;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);


        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@Mark";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Money;
        parameter.Size = 8;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = Mark;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);
        //'====================================
        parameter = new System.Data.SqlClient.SqlParameter();
        parameter.ParameterName = "@Level";
        parameter.IsNullable = true;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Output;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);


        Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        Conn.Open();

        sqlCmd.Connection = Conn;


        //System.Data.SqlClient.SqlDataReader reader;
        //reader = sqlCmd.ExecuteReader();

        sqlCmd.ExecuteNonQuery();
        int iStudentLevel = Convert.ToInt32("0" + sqlCmd.Parameters["@Level"].Value);

        Conn.Close();
        return iStudentLevel;

    }
    public static StreamWriter exportToExcel(DataSet source, string filePath)
    {

        StreamWriter excelDoc;
        excelDoc = new StreamWriter(filePath);
        const string startExcelXML = "<xml version>\r\n<Workbook " +
              "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
              " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
              "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
              "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
              "office:spreadsheet\">\r\n <Styles>\r\n " +
              "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
              "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
              "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
              "\r\n <Protection/>\r\n </Style>\r\n " +
              "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
              "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
              "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
              " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
              "ss:ID=\"Decimal\">\r\n <NumberFormat " +
              "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
              "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
              "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
              "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
              "ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n " +
              "</Styles>\r\n ";
        const string endExcelXML = "</Workbook>";

        int rowCount = 0;
        int sheetCount = 1;

        excelDoc.Write(startExcelXML);
        excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
        excelDoc.Write("<Table>");
        excelDoc.Write("<Row>");
        for (int x = 0; x < source.Tables[0].Columns.Count; x++)
        {
            excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
            excelDoc.Write(source.Tables[0].Columns[x].ColumnName);
            excelDoc.Write("</Data></Cell>");
        }
        excelDoc.Write("</Row>");
        foreach (DataRow x in source.Tables[0].Rows)
        {
            rowCount++;
            //if the number of rows is > 64000 create a new page to continue output

            if (rowCount == 64000)
            {
                rowCount = 0;
                sheetCount++;
                excelDoc.Write("</Table>");
                excelDoc.Write(" </Worksheet>");
                excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                excelDoc.Write("<Table>");
            }
            excelDoc.Write("<Row>"); //ID=" + rowCount + "

            for (int y = 0; y < source.Tables[0].Columns.Count; y++)
            {
                System.Type rowType;
                rowType = x[y].GetType();
                switch (rowType.ToString())
                {
                    case "System.String":
                        string XMLstring = x[y].ToString();
                        XMLstring = XMLstring.Trim();
                        XMLstring = XMLstring.Replace("&", "&");
                        XMLstring = XMLstring.Replace(">", ">");
                        XMLstring = XMLstring.Replace("<", "<");
                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                       "<Data ss:Type=\"String\">");
                        excelDoc.Write(XMLstring);
                        excelDoc.Write("</Data></Cell>");
                        break;
                    case "System.DateTime":
                        //Excel has a specific Date Format of YYYY-MM-DD followed by  

                        //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000

                        //The Following Code puts the date stored in XMLDate 

                        //to the format above

                        DateTime XMLDate = (DateTime)x[y];
                        string XMLDatetoString = ""; //Excel Converted Date

                        XMLDatetoString = XMLDate.Year.ToString() +
                             "-" +
                             (XMLDate.Month < 10 ? "0" +
                             XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                             "-" +
                             (XMLDate.Day < 10 ? "0" +
                             XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                             "T" +
                             (XMLDate.Hour < 10 ? "0" +
                             XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                             ":" +
                             (XMLDate.Minute < 10 ? "0" +
                             XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                             ":" +
                             (XMLDate.Second < 10 ? "0" +
                             XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                             ".000";
                        excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                     "<Data ss:Type=\"DateTime\">");
                        excelDoc.Write(XMLDatetoString);
                        excelDoc.Write("</Data></Cell>");
                        break;
                    case "System.Boolean":
                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                    "<Data ss:Type=\"String\">");
                        excelDoc.Write(x[y].ToString());
                        excelDoc.Write("</Data></Cell>");
                        break;
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                "<Data ss:Type=\"Number\">");
                        excelDoc.Write(x[y].ToString());
                        excelDoc.Write("</Data></Cell>");
                        break;
                    case "System.Decimal":
                    case "System.Double":
                        excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                              "<Data ss:Type=\"Number\">");
                        excelDoc.Write(x[y].ToString());
                        excelDoc.Write("</Data></Cell>");
                        break;
                    case "System.DBNull":
                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                              "<Data ss:Type=\"String\">");
                        excelDoc.Write("");
                        excelDoc.Write("</Data></Cell>");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + " not handled."));
                }
            }
            excelDoc.Write("</Row>");
        }
        excelDoc.Write("</Table>");
        excelDoc.Write(" </Worksheet>");
        excelDoc.Write(endExcelXML);
        excelDoc.Close();
        return excelDoc;
    }
   


    public static int Path(string sPath, out string sFileName, out string sExt)
    {
        //Return . dot position
        int iDot = 0;
        sFileName = "";
        sExt = "";
        try
        {
            iDot = sPath.IndexOf('.');
            sFileName = sPath.Substring(0, iDot);
            int ilength = sPath.Length - (sFileName.Length);
            sExt = sPath.Substring(iDot, ilength);
            int iStart = sFileName.LastIndexOf('\\') + 1;
            ilength = sFileName.Length - iStart;
            sFileName = sFileName.Substring(iStart, ilength);
        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {

        }
        return iDot;
    }
    public static double GetStudentRegisteredCredit(int iYear, int iSemester, string sStudentNo, int iCampus)
    {
        double iCredit = 0.0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        try
        {
            string sSQL = "SELECT SUM(Reg_Courses.byteCreditHours) AS Credit";
            sSQL += " FROM Course_Balance_View INNER JOIN";
            sSQL += " Reg_Courses ON Course_Balance_View.Course = Reg_Courses.strCourse";
            sSQL += " WHERE Course_Balance_View.iYear = " + iYear;
            sSQL += " AND Course_Balance_View.Sem = " + iSemester;
            sSQL += " AND Course_Balance_View.Student = '" + sStudentNo + "'";

            Conn.Open();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.HasRows)
            {
                dr.Read();
                iCredit = double.Parse(dr[0].ToString());
            }
            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {


            Conn.Close();
            Conn.Dispose();

        }
        return iCredit;
    }

    public static int GetRegTerm()
    {
        int iYear = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        try
        {
            string sSQL = "SELECT (intRegYear*10)+byteRegSemester as iYear";
            sSQL += " FROM Cmn_Firm";

            Conn.Open();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                iYear = int.Parse(dr["iYear"].ToString());
            }

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {


            Conn.Close();
            Conn.Dispose();

        }
        return iYear;
    }


    public static int GetCurrentTerm()
    {
        int iYear = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        try
        {
            string sSQL = "SELECT intCurrentYear * 10 + byteCurrentSemester AS iYear";
            sSQL += " FROM Cmn_Firm";

            Conn.Open();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                iYear = int.Parse(dr["iYear"].ToString());
            }

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {


            Conn.Close();
            Conn.Dispose();

        }
        return iYear;

    }


    public static bool isRegistered(int iYear, int iSem, string sCourse, string sStudent, InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        bool isReg = false;
        try
        {

            string sSQL = "SELECT Class";
            sSQL += " FROM Course_Balance_View";
            sSQL += " where iYear=" + iYear;
            sSQL += " AND Sem=" + iSem;
            sSQL += " AND [Course]='" + sCourse + "'";
            sSQL += " AND [Student]='" + sStudent + "'";

            Conn.Open();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            isReg = dr.HasRows;

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {


            Conn.Close();
            Conn.Dispose();

        }
        return isReg;

    }
    public static bool isRegistered(int iYear, int iSem, string sStudent, InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        bool isReg = false;
        try
        {

            string sSQL = "SELECT Course";
            sSQL += " FROM Course_Balance_View";
            sSQL += " where iYear=" + iYear;
            sSQL += " AND Sem=" + iSem;
            sSQL += " AND [Student]='" + sStudent + "'";

            Conn.Open();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            isReg = dr.HasRows;

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {


            Conn.Close();
            Conn.Dispose();

        }
        return isReg;

    }

    public static bool isCourseAvailable(int iYear, int iSemester, string sCourse, InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        bool isAvailable = false;

        try
        {

            string sSQL = "SELECT Count([strCourse]) FROM [Reg_CourseTime_Schedule]";
            sSQL += " WHERE byteShift<>11";
            sSQL += " AND [intStudyYear]=" + iYear;
            sSQL += " AND [byteSemester]=" + iSemester;
            if (sCourse == "ESL101" || sCourse == "ESL103")
            {
                sSQL += " AND [strCourse]='" + sCourse + " 50%" + "'";
            }
            else
            {
                sSQL += " AND [strCourse]='" + sCourse + "'";
            }

            Conn.Open();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            isAvailable = ((int)Cmd.ExecuteScalar() > 0);

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {


            Conn.Close();
            Conn.Dispose();

        }
        return isAvailable;

    }
    public static bool isGradesHidden(InitializeModule.EnumCampus Campus)
    {

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        bool isHidden = false;

        try
        {

            string sSQL = "SELECT byteGrades FROM Cmn_Firm";

            Conn.Open();

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            int iStatus = int.Parse(Cmd.ExecuteScalar().ToString());
            isHidden = (iStatus > 1);

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {


            Conn.Close();
            Conn.Dispose();

        }
        return isHidden;

    }
    public static int GetRegCoursesPrevSem(string sID, int iRegYear, int iRegSem, InitializeModule.EnumCampus Camups)
    {
        int iReturn = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Camups);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();

        try
        {

            int iPrevRegSem = 0;


            if (iRegSem == 4)
            {
                iPrevRegSem = 3;
                string sSQL = "";
                sSQL = "SELECT ";
                sSQL += " CCount ";
                sSQL += "  FROM Registration_Hours ";
                sSQL += "  WHERE lngStudentNo='" + sID + "'";
                sSQL += " AND intStudyYear=" + iRegYear;
                sSQL += " AND byteSemester =" + iPrevRegSem;


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                iReturn = int.Parse(Cmd.ExecuteScalar().ToString());


            }



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
        return iReturn;

    }
    public static double GetEmployeeInitialVacationBalance(int iEmployeeNo, int iVacationType, SqlConnection con) 
    {    
        SqlCommand sqlCmd ;

        sqlCmd = new SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetEmployeeInitialVacationBalance";


        SqlParameter parameter =new SqlParameter ();
        parameter.ParameterName = "@EmpNo";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iEmployeeNo;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        parameter = new SqlParameter () ;
        parameter.ParameterName = "@VacationType";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iVacationType;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);
        sqlCmd.Connection = con;
        SqlDataReader reader =sqlCmd.ExecuteReader();
    
        double dblVacation =0;
        if (reader.Read() )
        {
            dblVacation = Convert.ToDouble ( reader["OpenBalance"]);
        }
        reader.Close();
        sqlCmd.Dispose();

        return dblVacation;
        }

    public static double GetEmployeeVacationBalance(int iEmployeeNo, int iVacationType, SqlConnection con) 
    {
        SqlCommand sqlCmd ;

        sqlCmd = new SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetEmployeeVacationBalance";


        SqlParameter parameter =new SqlParameter();
        parameter.ParameterName = "@EmpNo";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iEmployeeNo;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.ParameterName = "@VacationType";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iVacationType;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        sqlCmd.Connection = con;
        SqlDataReader reader = sqlCmd.ExecuteReader();
       

        Double dblVacation=0 ;
        if (reader.Read())
        {
            dblVacation = Convert.ToDouble ( reader["DaysCount"]);
        }
        reader.Close();
        sqlCmd.Dispose();

        return dblVacation;
}

    public static double GetEmployeeVacationBalanceByDate(int iEmployeeNo, int iVacationType, int iFromDate, SqlConnection con)
    {
         SqlCommand sqlCmd ;

        sqlCmd = new SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "GetEmployeeVacationBalanceByDate";


        SqlParameter parameter =new SqlParameter();
        parameter.ParameterName = "@EmpNo";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iEmployeeNo;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.ParameterName = "@VacationType";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iVacationType;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.ParameterName = "@FromDate";
        parameter.IsNullable = false;
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Size = 4;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = iFromDate;

        //' Add the parameter to the Parameters collection.
        sqlCmd.Parameters.Add(parameter);

        sqlCmd.Connection = con;
        SqlDataReader reader = sqlCmd.ExecuteReader();
      

        Double dblVacation=0;
        if (reader.Read ())
        {
            dblVacation = Convert.ToDouble( reader["DaysCount"]);
        }
        reader.Close();
        sqlCmd.Dispose ();

        return dblVacation;
}

    

    public static decimal GetClassMarksAVG(int iYear, byte bSem, byte bShift, string sCourse, byte bClass, InitializeModule.EnumCampus Camups)
    {
        decimal dAvg = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Camups);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT SUM(curUseMark) AS Marks, COUNT(lngStudentNumber) AS Students";
            sSQL += " FROM dbo.Reg_Grade_Header";
            sSQL += " Where intStudyYear=" + iYear;
            sSQL += " AND byteSemester=" + bSem;
            sSQL += " AND byteShift=" + bShift;
            sSQL += " AND strCourse='" + sCourse + "'";
            sSQL += " AND byteClass=" + bClass;
            sSQL += " AND (strGrade <> 'W') AND (strGrade <> 'EW') AND (strGrade <> 'EQ') AND (strGrade <> 'NG') AND (strGrade <> 'I') AND (strGrade IS NOT NULL)";
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            decimal dSum = 0;
            decimal dCount = 0;
            while (Rd.Read())
            {
                dSum = Convert.ToDecimal(Rd["Marks"]);
                dCount = Convert.ToDecimal(Rd["Students"]);
            }
            Rd.Close();
            if (dCount > 0)
            {
                dAvg = dSum / dCount;
            }

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {

            Conn.Close();
            Conn.Dispose();

        }

        return dAvg;
    }

    public static string ConvertMarktoGrade(decimal dMark)
    {
        string sGrade = "";
        try
        {
            if (dMark < 60)
            {
                sGrade = "F";
            }
            else if (dMark >= 60 && dMark < 64)
            {
                sGrade = "D";
            }

            else if (dMark >= 64 && dMark < 67)
            {
                sGrade = "D+";
            }
            else if (dMark >= 67 && dMark < 70)
            {
                sGrade = "C-";
            }
            else if (dMark >= 70 && dMark < 74)
            {
                sGrade = "C";
            }
            else if (dMark >= 74 && dMark < 77)
            {
                sGrade = "C+";
            }
            else if (dMark >= 77 && dMark < 80)
            {
                sGrade = "B-";
            }
            else if (dMark >= 80 && dMark < 84)
            {
                sGrade = "B";
            }
            else if (dMark >= 84 && dMark < 87)
            {
                sGrade = "B+";
            }
            else if (dMark >= 87 && dMark < 90)
            {
                sGrade = "A-";
            }
            else if (dMark >= 90)
            {
                sGrade = "A";
            }
        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {

        }
        return sGrade;
    }

    public static bool isFinanceProblems(InitializeModule.EnumCampus Campus, string StudentNumber)
    {

        bool isThereFinanceProblems = true;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSql = "SELECT bOtherCollege";
            sSql += " FROM Reg_Applications";
            sSql += " WHERE lngStudentNumber='" + StudentNumber + "'";

            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                isThereFinanceProblems = bool.Parse(reader["bOtherCollege"].ToString());
            }

            reader.Close();

        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return isThereFinanceProblems;
    }

    public static bool isFinanceProblems(InitializeModule.EnumCampus Campus, string StudentNumber,int RegTerm)
    {
        bool isFinance = true;
        bool isThereFinanceProblems = true;
        int iAllowedTerm = 0;
        bool isNotAllowed = true ;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            
            string sSql = "SELECT A.bOtherCollege, ISNULL(AC.intRegYear * 10 + AC.byteRegSem, 0) AS iReg";
            sSql += " FROM Reg_Applications AS A LEFT OUTER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber";
            sSql += " WHERE A.lngStudentNumber='" + StudentNumber + "'";

            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                isFinance = bool.Parse(reader["bOtherCollege"].ToString());
                iAllowedTerm = Convert.ToInt32(reader["iReg"]);
            }

            reader.Close();

            isNotAllowed = (RegTerm != iAllowedTerm);

            isThereFinanceProblems = (isNotAllowed || isFinance);

        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return isThereFinanceProblems;
    }
    public static bool isActiveStudent(InitializeModule.EnumCampus Campus, string StudentNumber)
    {

        bool isHeActive = true;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSql = "SELECT bActive";
            sSql += " FROM Reg_Applications";
            sSql += " WHERE lngStudentNumber='" + StudentNumber + "'";

            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                isHeActive = bool.Parse(reader["bActive"].ToString());
            }

            reader.Close();

        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return isHeActive;
    }

    public static string GetSIDFromUser(InitializeModule.EnumCampus Campus, int iUser)
    {

        string SID = "";
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSql = "SELECT lngStudentNumber FROM Reg_Student_Accounts";
            sSql += " WHERE intOnlineUser=" + iUser;

            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                SID = reader["lngStudentNumber"].ToString();
            }

            reader.Close();

        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return SID;
    }

    public static bool isMissingStudent(InitializeModule.EnumCampus Campus, string StudentNumber)
    {

        bool isHeMissing = true;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSql = "SELECT bContinue";
            sSql += " FROM Reg_Applications";
            sSql += " WHERE lngStudentNumber='" + StudentNumber + "'";

            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                isHeMissing = !bool.Parse(reader["bContinue"].ToString());
            }

            reader.Close();

        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return isHeMissing;
    }

    public static int GetMajorGeneralIndex(string sDegree, string sMajor)
    {
        int iIndex = 0;
        try
        {
            //Foundation
            if (sDegree == "2" && sMajor == "2")
            {
                iIndex = 5;
            }
            if (sDegree == "2" && sMajor == "1")
            {
                iIndex = 7;
            }
            //PR With TOEFL 450
            else if (sDegree == "1" && sMajor == "24")
            {
                iIndex = 11;
            }
            //PR Without TOEFL 450
            else if (sDegree == "1" && sMajor == "25")
            {
                iIndex = 13;
            }
            //Other Majors
            else
            {
                iIndex = 9;
            }
        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {

        }
        return iIndex;
    }
    public static int GetLecturerCampus(int iLecturerID, out int iLecID)
    {
        int iLecturerCampus = 0;
        int iLecturerMaleID = 0;
        int iLecturerFemaleID = 0;
        Connection_StringCLS myConnection_String;
        SqlConnection Conn;
        SqlConnection Con;
        //try
        //{
            
            
            myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.Males);

            Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew );
            Con = new SqlConnection(myConnection_String.Conn_string);
            Con.Open();

            iLecturerMaleID = GetLecturerMaleID(Con, iLecturerID);

            string sSQL = "SELECT iCampus";
            sSQL += " FROM Reg_Lecturers";
            sSQL += " WHERE intLecturer = " + iLecturerMaleID;

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            iLecID = 0;

            while (dr.Read())
            {
                iLecturerCampus = int.Parse(dr["iCampus"].ToString());
            }

            if (iLecturerCampus == 2 || iLecturerCampus  == 4)
            {
                //Con = new SqlConnection(myConnection_String.Conn_string);
                //Con.Open();
                iLecturerFemaleID  = GetLecturerFemaleID(Con, iLecturerID);
            }
           

            dr.Close();

            if (iLecturerCampus == 2 || iLecturerCampus == 4)
            {
                iLecID = iLecturerFemaleID;
            }
            else
            {
                iLecID = iLecturerMaleID;
            }
        //}
        //catch (Exception exp)
        //{
        //    Console.WriteLine("{0} Exception caught.", exp);
         
        //}
        //finally
        //{

        //}
        
        return iLecturerCampus;

    }
    public static int GetLecturerFemaleID(SqlConnection Conn, int iLecturerID)
    {
        int iLecturerFID = 0;

        try
        {



            string sSQL = "SELECT FCampusID";
            sSQL += " FROM Reg_Lecturers";
            sSQL += " WHERE LecturerID = " + iLecturerID;


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                iLecturerFID = int.Parse(dr["FCampusID"].ToString());
            }

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {

        }
        return iLecturerFID;

    }
    public static int GetLecturerMaleID(SqlConnection Conn, int iLecturerID)
    {

        int iLecturerMID = 0;
        try
        {



            string sSQL = "SELECT MCampusID";
            sSQL += " FROM Reg_Lecturers";
            sSQL += " WHERE LecturerID = " + iLecturerID;


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                iLecturerMID = int.Parse(dr["MCampusID"].ToString());
            }

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {

        }
        return iLecturerMID;

    }
    public static int GetLecturerID(int iFirstCampus, int iSecondCampus, int iLecturerIDForFirstCampus)
    {

        int iLecturerIDForSecondCampus = 0;
        try
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);

            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            string sSQL = "SELECT MCampusID,FCampusID";
            sSQL += " FROM Reg_Lecturers";
            if (iFirstCampus == 1)
            {
                sSQL += " WHERE MCampusID = " + iLecturerIDForFirstCampus;
            }
            if (iFirstCampus == 2)
            {
                sSQL += " WHERE FCampusID = " + iLecturerIDForFirstCampus;
            }

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                if (iFirstCampus == 1)
                    iLecturerIDForSecondCampus = int.Parse(dr["FCampusID"].ToString());
                else
                    iLecturerIDForSecondCampus = int.Parse(dr["MCampusID"].ToString());


            }

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {

        }
        return iLecturerIDForSecondCampus;

    }
    public static int GetAllowedCampus(int iUserNumber)
    {

        int iAllowedCampus = -1;
        try
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew );

            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string );
            Conn.Open();

            string sSQL = "SELECT AllowedCampus";
            sSQL += " FROM Cmn_User";
            sSQL += " WHERE UserNo = " + iUserNumber;
           

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                iAllowedCampus = int.Parse(dr["AllowedCampus"].ToString());  
            }

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {

        }
        return iAllowedCampus;

    }
    public static int GetNationalityMaleFemaleID(SqlConnection Conn, int iNationalityID, InitializeModule.EnumGender IsMale)
    {

        int iNationalityMFID = 0;
        try
        {



            string sSQL = "SELECT ";
            if (IsMale == InitializeModule.EnumGender.Male)
            {
                sSQL += " NationalityMaleID";
            }
            else
            {
                sSQL += " NationalityFemaleID";
            }
            sSQL += " FROM Lkp_Nationality";
            sSQL += " WHERE NationalityID = " + iNationalityID;


            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                if (IsMale == InitializeModule.EnumGender.Male)
                {
                    iNationalityMFID = int.Parse(dr["NationalityMaleID"].ToString());
                }
                else
                {
                    iNationalityMFID = int.Parse(dr["NationalityFemaleID"].ToString());
                }

            }

            dr.Close();

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {

        }
        return iNationalityMFID;

    }
    public static int GetStudentStatus(InitializeModule.EnumCampus Campus, string StudentNumber)
    {

        int iStatus = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {

            string sSql = "SELECT byteCancelReason";
            sSql += " FROM Reg_Applications";
            sSql += " WHERE lngStudentNumber='" + StudentNumber + "'";

            SqlCommand Cmd = new SqlCommand(sSql, Conn);
            SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                if (reader["byteCancelReason"].Equals(DBNull.Value))
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = int.Parse(reader["byteCancelReason"].ToString());
                }
            }

            reader.Close();

        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return iStatus;
    }
    public static double GetCGPA(InitializeModule.EnumCampus Campus, string sID)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        double CGPA = 0;
        try
        {
            string sSQL = "SELECT GPA FROM GPA_Until WHERE lngStudentNumber='" + sID + "'";
            SqlCommand cmd = new SqlCommand(sSQL, Conn);
            CGPA = Convert.ToDouble("0" + cmd.ExecuteScalar().ToString());
        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return CGPA;
    }
    public static InitializeModule.enumPrivilege GetStatusPrivilege(int iStatus)
    {

        InitializeModule.enumPrivilege StatusPrivilege = InitializeModule.enumPrivilege.StatusNoStatus;
        try
        {
            switch (iStatus)
            {
                case 1://	Withdrawn
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusWithdrawn;
                    break;
                case 2://	Transferred
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusTransferred;
                    break;
                case 3://	Graduated
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusGraduated;
                    break;
                case 4://	Readmitted
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusReadmitted;
                    break;
                case 5://	Under Probation
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusUnderProbation;
                    break;
                case 6://	Dismissed from the College
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusDismissedfromtheCollege;
                    break;
                case 7://	Discontinued
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusDiscontinued;
                    break;
                case 8://	Suspended
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusSuspended;
                    break;
                case 9://	Absent
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusAbsent;
                    break;
                case 10://	InActive
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusInActive;
                    break;
                case 11://	Postponed
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusPostponed;
                    break;
                case 12://	Visiting Students
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusVisitingStudents;
                    break;
                case 100://	Canceled
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusCanceled;
                    break;
                case 13://	TOEFL Enter Required
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusTOEFLEnterRequired;
                    break;
                case 14://	TOEFL Exit Required
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusTOEFLExitRequired;
                    break;
                case 0://	No Status
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusNoStatus;
                    break;
                case 15://	No Contact
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusNoContact;
                    break;
                case 16://	No Answer
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusNoAnswer;
                    break;
                case 17://	Intend to register
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusIntendtoregister;
                    break;
                case 18://	Never Registered
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusNeverRegistered;
                    break;
                case 20://	Foundation Compelete
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusFoundationCompelete;
                    break;
                case 25://	Expected to Graduate
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusExpectedtoGraduate;
                    break;
                case 26://	Dismissed from the Program
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusDismissedfromtheProgram;
                    break;
                case 27://	Convert to Bachelor
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusConverttoBachelor;
                    break;
                case 28://	Convert to Diploma
                    StatusPrivilege = InitializeModule.enumPrivilege.StatusConverttoDiploma;
                    break;
            }

        }

        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
            StatusPrivilege = InitializeModule.enumPrivilege.StatusNoStatus;
        }
        finally
        {

        }

        return StatusPrivilege;
    }

    public static int GetNoOfPagesPDF(string FileName, int iDefault)
    {
        int result = iDefault;
        try
        {


            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);

            StreamReader r = new StreamReader(fs);

            string pdfText = r.ReadToEnd();



            System.Text.RegularExpressions.Regex regx = new Regex(@"/Type\s*/Page[^s]");

            System.Text.RegularExpressions.MatchCollection matches = regx.Matches(pdfText);

            result = matches.Count;


        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
            //divMsg.InnerText = exp.Message;
            return iDefault;
        }
        finally
        {

        }
        return result;

    }

    //public static int GetNoOfPagesDOC(string FileName, int iDefault)
    //{

    //    int result = iDefault;

    //    object fileName = FileName;

    //    object readOnly = false;

    //    object isVisible = true;

    //    object objDNS = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;

    //    try
    //    {
    //        Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();

    //        // give any file name of your choice. 

    //        //  the way to handle parameters you don't care about in .NET 

    //        object missing = System.Reflection.Missing.Value;

    //        //   Make word visible, so you can see what's happening 

    //        //WordApp.Visible = true; 

    //        //   Open the document that was chosen by the dialog 

    //        Microsoft.Office.Interop.Word.Document aDoc = WordApp.Documents.Open(ref fileName,

    //                                ref missing, ref readOnly, ref missing,

    //                                ref missing, ref missing, ref missing,

    //                                ref missing, ref missing, ref missing,

    //                                 ref missing, ref isVisible,

    //                                 ref missing, ref missing, ref missing, ref missing);

    //        Microsoft.Office.Interop.Word.WdStatistic stat = Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages;

    //        result = aDoc.ComputeStatistics(stat, ref missing);

    //        WordApp.Quit(ref objDNS, ref missing, ref missing);

    //        aDoc = null;

    //        WordApp = null;

    //        GC.Collect();

    //    }

    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("{0} Exception caught.", ex.Message);
    //        return iDefault;

    //    }

    //    return result;



    //}

    //public static int GetNoOfSlides(string FileName, int iDefault)
    //{

    //    int result = iDefault;

    //    Microsoft.Office.Interop.PowerPoint.Application app = new Microsoft.Office.Interop.PowerPoint.Application();
    //    Microsoft.Office.Core.MsoTriState ofalse = Microsoft.Office.Core.MsoTriState.msoFalse;
    //    Microsoft.Office.Core.MsoTriState otrue = Microsoft.Office.Core.MsoTriState.msoTrue;
    //    PowerPoint.Presentation pptPresentation = null;

    //    try
    //    {
    //        pptPresentation = app.Presentations.Open2007(FileName, otrue, ofalse,ofalse, otrue);
    //        result = pptPresentation.Slides.Count;

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("{0} Exception caught.", ex.Message);
    //        return iDefault;

    //    }
    //    finally
    //    {
    //        app.Quit();
    //        app = null;
    //        pptPresentation = null;
    //        GC.Collect();
    //    }

    //    return result;



    //}


    //public static int GetNoOfPagesDOC(string FileName, int iDefault)
    //{

    //    int result = iDefault;
    //    WordprocessingDocument doc = null;
    //    try
    //    {


    //        doc = WordprocessingDocument.Open(FileName, false);

    //        result = Convert.ToInt32(doc.ExtendedFilePropertiesPart.Properties.Pages.Text);


    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("{0} Exception caught.", ex.Message);
    //        return iDefault;

    //    }
    //    finally
    //    {
    //        doc.Close();
    //        doc.Dispose();
    //        GC.Collect();
    //    }

    //    return result;
    //}


    //public static int GetNoOfSlides(string FileName, int iDefault)
    //{

    //    int result = iDefault;
    //    PresentationDocument doc = null;
    //    try
    //    {


    //        doc = PresentationDocument.Open(FileName, false);
    //        PresentationPart part = doc.PresentationPart;
    //        if (part != null)
    //        {

    //            result = part.SlideParts.Count();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("{0} Exception caught.", ex.Message);
    //        return iDefault;

    //    }
    //    finally
    //    {
    //        doc.Close();
    //        doc.Dispose();
    //        GC.Collect();
    //    }

    //    return result;



    //}

    public static string GetComputerName(string clientIP)
    {
        try
        {
            var hostEntry = Dns.GetHostEntry(clientIP);
           
            string[] computer_name = hostEntry.HostName.Split(new Char[] { '.' });
            return "" + computer_name[0].ToString().ToLower();
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }

    public static string GetCurrentNtUserName()
    {
        try
        {
            string sName = HttpContext.Current.User.Identity.Name;

            //string[] names = hostEntry.HostName.Split(new Char[] { '.' });
            return sName;
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }

    public static string GetCurrentUserPcName(int iUser)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            string sSQL = "SELECT GradesPCName FROM Cmn_User WHERE UserNo=" + iUser;
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return "" + cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public static int GetCurrentStCampus(string sSno, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            string sSQL = "SELECT M.iCampus";
            sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization";
            sSQL += " WHERE A.lngStudentNumber='" + sSno + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return 0 + (int)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            return 0;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public static MirrorCLS GetStudentFactors(string sNo, InitializeModule.EnumCampus Campus)
    {
        MirrorCLS Result = new MirrorCLS();
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "";
            sSQL += "SELECT lngSerial, Period, No, Name, ENG, Score, Phone1, Phone2,Status, LTR, CGPA, byteShift AS iPeriod,Advisor,AcceptedTerm,isAccWanted,MESL,RMD,Major,strNotes";
            sSQL += " FROM Web_Student_Data";
            sSQL += " Where No='" + sNo + "'";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            int iSerial = 1;
            while (Rd.Read())
            {

                Result.Serial = iSerial;
                Result.StudentNumber = Rd["No"].ToString();
                Result.Name = Rd["Name"].ToString();
                Result.IPeriod = int.Parse(Rd["iPeriod"].ToString());
                Result.Period = Rd["Period"].ToString();
                Result.ENG = Rd["ENG"].ToString();
                Result.Advisor = Rd["Advisor"].ToString();
                Result.Major = Rd["Major"].ToString();
                if (!Rd["Score"].Equals(DBNull.Value))
                {
                    Result.Score = decimal.Parse(Rd["Score"].ToString());
                }
                if (!Rd["CGPA"].Equals(DBNull.Value))
                {
                    Result.CGPA = decimal.Parse(Rd["CGPA"].ToString());
                }
                else
                {
                    Result.CGPA = 101;
                }
                if (!Rd["LTR"].Equals(DBNull.Value))
                {
                    Result.LTR = int.Parse(Rd["LTR"].ToString());
                }
                else
                {
                    Result.LTR = 0;
                }
                Result.Phone1 = Rd["Phone1"].ToString();
                Result.Phone2 = Rd["Phone2"].ToString();
                Result.Status = Rd["Status"].ToString();

                Result.IsENGRequired = (int.Parse(Rd["AcceptedTerm"].ToString()) >= 20062);
                Result.IsAccWanted = bool.Parse(Rd["isAccWanted"].ToString());

                if (!Rd["MESL"].Equals(DBNull.Value))
                {
                    Result.MaxESL = int.Parse(Rd["MESL"].ToString());
                }
                else
                {
                    Result.MaxESL = 0;
                }

                if (!Rd["RMD"].Equals(DBNull.Value))
                {
                    Result.Remind = int.Parse(Rd["RMD"].ToString());
                }
                Result.Note = Rd["strNotes"].ToString();

            }

            Rd.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex.Message);
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return Result;
    }

    public static int GetSummersHours(int iYear, string sSno, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            //, SUM(CCount) AS Courses
            string sSQL = "SELECT SUM(Hours) AS Credits";
            sSQL += " FROM Registration_Hours";
            sSQL += " WHERE  lngStudentNo = '" + sSno + "' AND intStudyYear = " + iYear + " AND byteSemester > 2";
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return 0 + (int)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            return 0;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }
    public static int GetCompletedHours(string sStudentID, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        int iCompletedHours = 0;
        try
        {
            int iTerm = Convert.ToInt32(LibraryMOD.GetRegTerm());
            int iSem = 0;
            int iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "SELECT dPRegistered, dCRegistered,dCompleted FROM [ECTData].[dbo].[Term_Factors](@iYear,@bSem,@sNo)";
            Cmd.CommandType = CommandType.Text;
            Cmd.Parameters.AddWithValue("iYear", iYear);
            Cmd.Parameters.AddWithValue("bSem", iSem);
            Cmd.Parameters.AddWithValue("sNo", sStudentID);

            SqlDataReader rd = Cmd.ExecuteReader();
            while (rd.Read())
            {
                iCompletedHours = int.Parse(rd["dCompleted"].ToString());
            }
            rd.Close();
        }
        catch (Exception exp)
        {
            //Console.WriteLine("{0} Exception caught.", exp);
            //divMsg.InnerText = exp.Message;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return iCompletedHours;
    }
    public static int GetCompleted(string sSID, int iYear, int iSem, string sDegree, string sMajor, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            //, SUM(CCount) AS Courses
            string sSQL = "SELECT dbo.Completed_Successfully('" + sSID + "', " + iYear + ", " + iSem + ", '" + sDegree + "', '" + sMajor + "') AS Completed";

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return int.Parse("0" + cmd.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            return 0;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }

    public static string GetTheUserEmpName(string sUser)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            //, SUM(CCount) AS Courses
            string sSQL = "SELECT  EmployeeName FROM Cmn_User WHERE UserName = '" + sUser + "'";

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            return "";
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }

    public static string GetECTId(string sSID, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            string sSQL = "";
            
            if (string.IsNullOrEmpty(sSID))
            {
                sSQL = "SELECT sECTID FROM NewECTIDs";
            }
            else
            {
                sSQL = "SELECT sECTId FROM Reg_Applications WHERE lngStudentNumber = '"+sSID+"'";
            }

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            return "";
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }

    public static bool isMilitaryService(string sSID)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            string sSQL = "";

            sSQL = "SELECT isMilitaryService FROM Reg_Applications WHERE lngStudentNumber = '" + sSID + "'";
            
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return Convert.ToBoolean(cmd.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            return false;   
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }

    public static bool isACCWanted(string sSID, InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            string sSQL = "";

            sSQL = "SELECT isACCWanted FROM Reg_Applications WHERE lngStudentNumber = '" + sSID + "'";

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return Convert.ToBoolean(cmd.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }
    public static string CanRegCourse(string sCourse,int iYear,int iSem ,InitializeModule.EnumCampus Campus)
    {
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            string sSQL = "";

            //if (string.IsNullOrEmpty(sSID))
            //{
            //    sSQL = "SELECT sECTID FROM NewECTIDs";
            //}
            //else
            //{
            //    sSQL = "SELECT sECTId FROM Reg_Applications WHERE lngStudentNumber = '" + sSID + "'";
            //}

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            return cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            return "";
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }

    public static int IsFileVerifiedFromRegistrar(string sStudentID, InitializeModule.EnumCampus Campus)
    {
        int iResult = InitializeModule.TRUE_VALUE  ;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
       
        try
        {
            string sSQL = "";

            sSQL = "SELECT Certificate, StudentID,Name, sngGrade";
            sSQL = sSQL + " ,strCertificateSource,dateENG";
            sSQL = sSQL + " ,VerifiedByAdmission,AdmissionComments";
            sSQL = sSQL + " ,VerifiedByRegistrar,RegistrarComments";
            sSQL = sSQL + " ,intGraduationYear,intStudyYear,byteSemester";
            sSQL = sSQL + " ,strUserCreate ,strUserSave";
            sSQL = sSQL + " ,IsActive,LTR,Registered";
            sSQL = sSQL + " ,lngSerial,byteQualification,intCertificate";
            sSQL = sSQL + " ,intMajor,intMinor,byteInstituteCountry,byteStudentType";
            sSQL = sSQL + " ,RefStudentID,RefYear,RefSem,RefReason";
            sSQL = sSQL + " FROM TOEFL_HS_Verifications";
            sSQL = sSQL + " WHERE StudentID='" + sStudentID + "'";

            int iYear = 0;
            int iSem = 0;
            int iTerm = 0;
            string sRefStudentID = "";
            int iRefReason = 0;
            int iRefYear = 0;
            int iRefSem = 0;

            SqlCommand Cmd = new SqlCommand(sSQL, conn);
            SqlDataReader Rd = Cmd.ExecuteReader();
            int iStudentType = 0;
            while (Rd.Read())
            {
                iStudentType = Convert.ToInt32(Rd["byteStudentType"]);
                iYear = Convert.ToInt32(Rd["intStudyYear"]);
                iSem = Convert.ToInt32(Rd["byteSemester"]);
                iTerm = (iYear * 10) + iSem;
                sRefStudentID = "" + Rd["RefStudentID"].ToString();
                iRefReason = Convert.ToInt32("0" + Rd["RefReason"]);

                if (iTerm <= 20161) //ignore verfication before Spring 2017
                {
                    //iResult = InitializeModule.TRUE_VALUE;
                    iResult = 2;
                    return iResult;
                }
                if (iStudentType == 1 || iStudentType == 5 || iStudentType == 2)
                {
                    //ignore verfication for visiting students, Foundation and ESL students
                    //iResult = InitializeModule.TRUE_VALUE;
                    iResult = 2;
                    return iResult;
                }
                if (sRefStudentID != "" && (iRefReason == 3 || iRefReason == 25))
                {
                    //Ignore verfification for extended students ( graduated or expected to gradute)
                    iResult = 2;
                    return iResult;
                }
                iResult = Convert.ToInt32(Rd["VerifiedByRegistrar"]);
                if (iResult == InitializeModule.FALSE_VALUE)
                {
                    return iResult;
                }
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            return InitializeModule.FALSE_VALUE;
        }
        finally
        {
            conn.Close();
            conn.Dispose();

        }
        return iResult;
    }

    public string strArabNumWord(long lngNumValue, string strSinName, string strPluName)
    {
        string strReturn = "";
        long lngPart;

        if (lngNumValue >= 1 && lngNumValue <= 12)
        {
            strReturn = strArbGetDigit(lngNumValue, lngNumValue, strSinName, strPluName, "");
        }
        else if (lngNumValue >= 13 && lngNumValue <= 99)
        {
            strReturn = strArbGetTens(lngNumValue, strSinName, strPluName);
        }
        else if (lngNumValue >= 100 && lngNumValue <= 999)
        {
            strReturn = strArbGetHun(lngNumValue, strSinName, strPluName);
        }
        else if (lngNumValue >= 1000 && lngNumValue <= 999999)
        {
            lngPart = Convert.ToInt32( (lngNumValue / 1000));
            strReturn = strArabNumWord(lngPart, "ألف", "آلاف");
            lngPart = lngNumValue - lngPart * 1000;

            if(lngPart != 0)
            {
                strReturn +=" و" + strArabNumWord(lngPart, strSinName, strPluName);
            }
            else
            {
                strReturn +=" " + strSinName;
            }
            
        }
        else if (lngNumValue >= 1000000 && lngNumValue <= 999999999)
        {
            lngPart = Convert.ToInt32(lngNumValue / 1000000);
            strReturn = strArabNumWord(lngPart, "مليون", "ملايين");
            lngPart = lngNumValue - lngPart * 1000000;

            if (lngPart != 0)
            {
                strReturn += " و" + strArabNumWord(lngPart, strSinName, strPluName);
            }
            else
            {
                strReturn += " " + strSinName;
            }

        }
        
        return strReturn;
    }

    private string strArbGetDigit(long lngNumValue, long LongDigit, string strSinName, string strPluName, string strAnd)
    {
        string strReturn = "";

        switch (LongDigit)
        {
            case 0 :
                strReturn = strSinName;
                break;
            case 1 :
                if (LongDigit == lngNumValue)
                {
                    strReturn = strSinName; //+ " واحد ";
                }
                else
                {
                    strReturn = "واحد " + strAnd + strSinName;
                }
                break;

            case 2:
                if (LongDigit == lngNumValue)
                {
                    strReturn = strSinName + "ين";
                }
                else
                {
                    strReturn = "اثنان " + strAnd + strSinName;
                }
                break;

            case 3:
                strReturn = "ثلاثة " + strAnd + strPluName;
                break;
            case 4:
                strReturn = "أربعة " + strAnd + strPluName;
                break;
            case 5:
                strReturn = "خمسة " + strAnd + strPluName;
                break;
            case 6:
                strReturn = "ستة " + strAnd + strPluName;
                break;
            case 7:
                strReturn = "سبعة " + strAnd + strPluName;
                break;
            case 8:
                strReturn = "ثمانية " + strAnd + strPluName;
                break;
            case 9:
                strReturn = "تسعة " + strAnd + strPluName;
                break;
            case 10:
                strReturn = "عشرة " + strAnd + strPluName;
                break;
            case 11:
                strReturn = "أحد عشر " + strAnd + strSinName;
                break;
            case 12:
                strReturn = "اثنا عشر " + strAnd + strSinName;
                break;  
            
        }
        
        return strReturn;
    }

    private string strArbGetTens(long lngNumValue, string strSinName, string strPluName)
    {
        string strReturn = "";
        string  sCalc="";
        long lngDigit;
        string strAnd="";
        string sNum=lngNumValue.ToString();

        strAnd = "و";
        lngDigit =Convert.ToInt32( sNum.Substring(sNum.Length - 1, 1));

        switch (sNum.Substring(0,1)) 
        {
            case "1":
                sCalc = "عشر ";
                strAnd = "";
                break;
            case "2":
                sCalc = "عشرون ";
                break;
            case "3":
                sCalc = "ثلاثون ";
                break;
            case "4":
                sCalc = "أربعون ";
                break;
            case "5":
                sCalc = "خمسون ";
                break;
            case "6":
                sCalc = "ستون ";
                break;
            case "7":
                sCalc = "سبعون ";
                break;
            case "8":
                sCalc = "ثمانون ";
                break;
            case "9":
                sCalc = "تسعون ";
                break;
        }
        
        strReturn = strArbGetDigit(lngNumValue, lngDigit, sCalc + strSinName, sCalc + strSinName, strAnd);
        return strReturn;
    }

    private string strArbGetHun(long lngNumValue, string strSinName, string strPluName)
    {
        string strReturn = "";
        string strDigit;
        string sValue = lngNumValue.ToString();

        strDigit = sValue.Substring(0, 1);
        switch (strDigit)
        {
            case "1":
                strReturn = "مائة";
                break;
            case "2":
                strReturn = "مائتي";
                break;
            case "3":
                strReturn = "ثلاثمائة";
                break;
            case "4":
                strReturn = "أربعمائة";
                break;
            case "5":
                strReturn = "خمسمائة";
                break;
            case "6":
                strReturn = "ستمائة";
                break;
            case "7":
                strReturn = "سبعمائة";
                break;
            case "8":
                strReturn = "ثمانمائة";
                break;
            case "9":
                strReturn = "تسعمائة";
                break;

        }

        if (Convert.ToInt32(strDigit) * 100 != lngNumValue)
        {
            strReturn += " و" + strArabNumWord(Convert.ToInt32(sValue.Substring(sValue.Length -2, 2)), strSinName, strPluName);
        }
        else
        {
            strReturn += " " + strSinName;
        }
        
        return strReturn;
    }
    public static int UpdateCRM_StudentID(string sStudentID, string sPhone)
    {
        String sSQL;
        int iEffected = 0;
        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        try
        {
            if (sPhone.Trim().ToString() == "")
            {
                return iEffected;
            }
            sPhone = CleanPhone(sPhone);

            sSQL = "UPDATE CRM_Customer";
            sSQL += " SET StudentID='" + sStudentID + "'";
            sSQL += " WHERE ContactNo ='" + sPhone + "'";

            Conn.Open();

            System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);

            iEffected = CommandSQL.ExecuteNonQuery();
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
    public static string CleanPhone( string sPhone)
    {
        try
        {
            if (sPhone.Trim().ToString() == "" || sPhone == "-")
            {
                return sPhone;
            }
            sPhone = RemoveSeperator(sPhone, "-");
            sPhone = RemoveSeperator(sPhone, "_");
            sPhone = RemoveSeperator(sPhone, "/");
            sPhone = RemoveSeperator(sPhone, " ");

            if (sPhone.Substring(0, 1) != "0")
            {
                sPhone += "0";
            }

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
        }
        finally
        {
           
        }

        return sPhone;
    }

    public static decimal GetStudentBalance(string sAccount, InitializeModule.EnumCampus Campus)
    {
        decimal cBalance = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        try
        {
            Conn.Open();

            string sSQL = "SELECT curDebitSum - curCreditSum + curVATSum AS Balance FROM AccBalanceSumAll AS B";
            sSQL += " WHERE (B.sAccount = '" + sAccount + "')";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            cBalance = Convert.ToDecimal('0'+Cmd.ExecuteScalar().ToString());                   
           

        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();

        }
        return cBalance;
    }

    public static decimal GetStudentBalanceBTS(string sSID, InitializeModule.EnumCampus Campus)
    {
        decimal cBalance = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        try
        {
            Conn.Open();

            string sSQL = "SELECT Debit-Credit+VAT AS Balance FROM AccBalanceSTBothSide";
            sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            string sBalance = Cmd.ExecuteScalar().ToString();
            if (sBalance != "")
            {
                cBalance = Convert.ToDecimal(sBalance);
            }
            else
            {
                cBalance = 0;
            }


        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();

        }
        return cBalance;
    }

    public static decimal GetStudentUptodateBalanceBTS(string sSID, InitializeModule.EnumCampus Campus)
    {
        decimal cBalance = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        try
        {
            Conn.Open();

            string sSQL = "SELECT COALESCE(([Debit]-[Credit]+[VAT]),0) + (SELECT COALESCE(sum(curCredit),0) FROM [ACC_Future_PCheque_BTS] where [lngStudentNumber]='" + sSID + "') as uptodatebalance FROM AccBalanceSTBothSide where [lngStudentNumber]='" + sSID + "'";
            //sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            string sBalance = Cmd.ExecuteScalar().ToString();
            if (sBalance != "")
            {
                cBalance = Convert.ToDecimal(sBalance);
            }
            else
            {
                cBalance = 0;
            }


        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();

        }
        return cBalance;
    }

    public static int GetLTRBTS(string sSID, InitializeModule.EnumCampus Campus)
    {
        int iLTR = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);

        try
        {
            Conn.Open();

            string sSQL = "SELECT MaxYear FROM Last_Time_Registered";
            sSQL += " WHERE (Student = '" + sSID + "')";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            //iLTR = Convert.ToInt32('0' + Cmd.ExecuteScalar().ToString());
            iLTR = Convert.ToInt32('0' + (string)Cmd.ExecuteScalar());


        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();

        }
        return iLTR;
    }

    public static string GetStudentMajor(InitializeModule.EnumCampus Campus, string sStudentId)
    {
        Connection_StringCLS sConn = new Connection_StringCLS(Campus);


        string sSQL = "SELECT M.strSpecializationDescEn ";
        sSQL += " FROM Reg_Applications AS A INNER JOIN ";
        sSQL += " Reg_Specializations AS M ON A.strCollege = M.strCollege ";
        sSQL += " AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization";
        sSQL += " WHERE A.lngStudentNumber = '" + sStudentId + "'";

        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());

        SqlCommand Cmd = new SqlCommand(sSQL, Conn);
        Conn.Open();
        SqlDataReader Rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

        string sStudentMajor = "";
        try
        {
            if (Rd.HasRows)
            {
                Rd.Read();
                sStudentMajor = Rd[0].ToString();
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

        return sStudentMajor;
    }

    public class CheckoutSessionModel
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string SuccessIndicator { get; set; }

        public static CheckoutSessionModel toCheckoutSessionModel(string response)
        {
            JObject jObject = JObject.Parse(response);
            CheckoutSessionModel model = jObject["session"].ToObject<CheckoutSessionModel>();
            model.SuccessIndicator = jObject["successIndicator"] != null ? jObject["successIndicator"].ToString() : "";
            return model;

        }
    }

    public static int getFinanceCategory(string sSID, out string sACC)
    {
        int iFinCat = 0;
        sACC = "";
        InitializeModule.EnumCampus Cmps = InitializeModule.EnumCampus.Males;
        if (sSID.Contains("AF") || sSID.Contains("SF"))
        {
            Cmps = InitializeModule.EnumCampus.Females;
        }
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Cmps);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT A.lngStudentNumber, AC.strAccountNo, AC.intFinanceCategory";
            sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber";
            sSQL += " Where A.lngStudentNumber='" + sSID + "'";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader rd = Cmd.ExecuteReader();
            while (rd.Read())
            {
                sACC = rd["strAccountNo"].ToString();
                iFinCat = Convert.ToInt32(rd["intFinanceCategory"].ToString());
            }
            rd.Close();
        }
        catch (Exception exp)
        {

        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return iFinCat;
    }

    public static string GetAdvisorEmail(string sName)
    {

        Connection_StringCLS sConn = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection Conn = new SqlConnection(sConn.Conn_string.ToString());
        Conn.Open();
        string sEmail = "";
        try
        {
            string sSQL = "SELECT  H.LecturerID, L.LecturerNameEn, H.InternalEmail AS email";
            sSQL += " FROM Hr_EmployeeProfileRpt AS H INNER JOIN Reg_Lecturers AS L ON H.LecturerID = L.LecturerID";
            sSQL += " WHERE (H.LecturerID > 0) AND (L.IsActive = 1)and L.LecturerNameEn = '" + sName + "'";
                

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                sEmail = Rd["email"].ToString();
            }

            Rd.Close();
                                    
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

        return sEmail;
    }
}

