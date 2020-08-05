using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AdmissionRequirments
/// </summary>
public class AdmissionRequirments
{
    //enum RemedialCourseRequirment
    //{
    //    HS = "HS",
    //    Remedial = "Remedial",
    //    HSandRemedial = "HS and Remedial",
    //    HSorRemedial = "HS or Remedial",
    //    Graduation = "Graduation",
    //    None = "None"
    //}

    //public AdmissionRequirments()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}
    public static bool IsFulfilledAdmissionRequirements(InitializeModule.EnumCampus Campus, string StudentID, out bool IsMTH001Required, out bool IsCHEM001Required, out bool IsBIOL001Required, out bool IsPHYS001Required)
    {
        bool IsFulfilledRequirements = false;

        //IsMTH001Required = false;
        //IsCHEM001Required = false;
        //IsBIOL001Required = false;
        //IsPHYS001Required = false;
        
        IsMTH001Required = true;
        IsCHEM001Required = true;
        IsBIOL001Required = true;
        IsPHYS001Required = true;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus );
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sQuery = "";
            sQuery = "SELECT  HSR.iHSMajor, HSR.cMinCRSScore";
            sQuery += " , HSR.MTH001, HSR.CHEM001, HSR.PHYS001, HSR.BIOL001, HSR.HSScience";
            sQuery += " , HSR.sHSTrack, HSR.sDesc, HSR.isFNDReplacement, HSR.cHSMinScore"; 
            sQuery += " ,HSR.cHSMaxScore, HSR.strCollege, HSR.strDegree, HSR.strSpecialization";
            sQuery += " , Q.intCertificate, Q.sngGrade, A.lngStudentNumber";
            sQuery += " , Q.ScoreOfMath, Q.ScoreOfChemistry, Q.ScoreOfBiology,Q.ScoreOfPhysics";

            sQuery += " FROM dbo.Reg_Student_Qualifications AS Q INNER JOIN";
            sQuery += " dbo.Reg_Applications AS A ON Q.lngSerial = A.lngSerial INNER JOIN";
            sQuery += " dbo.HighSchool_AdmissionRequirments AS HSR ON A.strCollege = HSR.strCollege ";
            sQuery += " AND A.strDegree = HSR.strDegree AND A.strSpecialization = HSR.strSpecialization ";
            sQuery += " AND Q.intMajor = HSR.iHSMajor AND Q.sngGrade >= HSR.cHSMinScore ";
            sQuery += " AND Q.sngGrade < HSR.cHSMaxScore";
            sQuery += " WHERE A.lngStudentNumber ='" + StudentID + "'";
            sQuery += " AND Q.intCertificate = 1";

                    
            int iHSMajor = 0;
            int iScoreofMath = 0;
            int iScoreofChem = 0;
            int iScoreofBiol = 0;
            int iScoreofPhys = 0;
            decimal dFoundationCourseMinScore = 0;

            string sMTH001_Requirment = "None";
            string sCHEM001_Requirment = "None";
            string sPHYS001_Requirment = "None";
            string sBIOL001_Requirment = "None";
           
            SqlCommand Cmd = new SqlCommand(sQuery, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                iHSMajor = int.Parse("0" + Rd["iHSMajor"].ToString());
                iScoreofMath = int.Parse("0" + Rd["ScoreOfMath"].ToString());
                iScoreofChem = int.Parse("0" + Rd["ScoreOfChemistry"].ToString());
                iScoreofBiol = int.Parse("0" + Rd["ScoreOfBiology"].ToString());
                iScoreofPhys = int.Parse("0" + Rd["ScoreOfPhysics"].ToString());
                
                sMTH001_Requirment = Rd["MTH001"].ToString();
                sCHEM001_Requirment = Rd["CHEM001"].ToString();
                sPHYS001_Requirment = Rd["PHYS001"].ToString();
                sBIOL001_Requirment = Rd["BIOL001"].ToString();
                
                dFoundationCourseMinScore = decimal.Parse("0" + Rd["cMinCRSScore"].ToString());
            }
            Rd.Close();
            string sFndCourse = "MTH001";
            IsMTH001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sMTH001_Requirment, iScoreofMath, dFoundationCourseMinScore);
            if (IsMTH001Required) { IsFulfilledRequirements = false; }
            //=====================================================
            sFndCourse = "CHEM001";
            IsCHEM001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sCHEM001_Requirment, iScoreofChem, dFoundationCourseMinScore);
            if (IsCHEM001Required) { IsFulfilledRequirements = false; }
            //=====================================================
            sFndCourse = "BIOL001";
            IsBIOL001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sBIOL001_Requirment, iScoreofBiol, dFoundationCourseMinScore);
            if (IsBIOL001Required) { IsFulfilledRequirements = false; }
            //=====================================================
            sFndCourse = "PHYS001";
            IsPHYS001Required = IsFndCourseRequired(Campus, StudentID, sFndCourse, sPHYS001_Requirment, iScoreofPhys, dFoundationCourseMinScore);
            if (IsPHYS001Required) { IsFulfilledRequirements = false; }

          
        }
        catch (Exception ex)
        {

            LibraryMOD.ShowErrorMessage(ex);
            IsFulfilledRequirements = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return IsFulfilledRequirements;
    }
    public static bool IsFndCourseRequired(InitializeModule.EnumCampus Campus, string StudentID, string sFndCourse, string sRequirment, int iScoreofFndCourse, decimal dFoundationCourseMinScore)
    {
        bool isRequired = false;
        try
        {
        switch (sRequirment)
        {
            case "HS":
                if (iScoreofFndCourse < dFoundationCourseMinScore)
                {
                    isRequired = true;
                }
                break;
            case "Remedial":
                if (!isFndCoursePassed(Campus, StudentID, sFndCourse))
                {
                    isRequired = true;
                }
                break;
            case "HS and Remedial":

                if (iScoreofFndCourse < dFoundationCourseMinScore || !isFndCoursePassed(Campus, StudentID, sFndCourse))
                {
                    isRequired = true;
                }

                break;
            case "HS or Remedial":
                if (iScoreofFndCourse < dFoundationCourseMinScore && !isFndCoursePassed(Campus, StudentID, sFndCourse))
                {
                    isRequired = true;
                }
                break;
            case "Graduation":
                //allow to change major from ESL to academic program, can register remedial + major courses
                isRequired = false;
                break;
            case "None":
                isRequired = false;
                break;
        }
        }
        catch (Exception ex)
        {

            LibraryMOD.ShowErrorMessage(ex);
            isRequired = true;
        }
        finally
        {
            
        }
        return isRequired;
    }

    public static bool isFndCoursePassed(InitializeModule.EnumCampus Campus, string StudentID, string sFndCourse)
    {
        bool isPassed = false;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        Conn.Open();
        try
        {
            string sSQL = "SELECT Reg_Grade_System.bPassIt";
            sSQL += " FROM Reg_Grade_System INNER JOIN";
            sSQL += " Reg_Grade_Header ON Reg_Grade_System.strGrade = Reg_Grade_Header.strGrade";
            sSQL += " WHERE Reg_Grade_Header.lngStudentNumber = '" + StudentID + "'";
            sSQL += " AND dbo.Reg_Grade_Header.strCourse = '" + sFndCourse + "'";
            sSQL += " AND Reg_Grade_System.bPassIt = 1";

            SqlCommand Cmd = new SqlCommand(sSQL, Conn);
            SqlDataReader Rd = Cmd.ExecuteReader();

            while (Rd.Read())
            {
                isPassed = true;
            }
            Rd.Close();

        }
        catch (Exception ex)
        {
            LibraryMOD.ShowErrorMessage(ex);
            isPassed = false;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }
        return isPassed;

    }
}