using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIS_Student.DAL
{
    public class DAL
    {
        public DataTable GetMenuData(int roleid)
        {
            DataTable dt = GetData("SELECT O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel, COUNT(RP.PrivilegeID) AS [Privileges] FROM Cmn_RolePermissions AS RP INNER JOIN Cmn_PrivilegeObjects AS O ON RP.ObjectID = O.ObjectID Where RP.RoleID = "+roleid+ " and O.SystemID = 10 GROUP BY O.ObjectID, O.ObjectNameEn, O.DisplayObjectName, O.ShowOrder, O.SystemID, O.ParentID, O.sURL, O.iLevel Order by O.iLevel,O.ShowOrder asc");
            return dt;
        }
        public DataTable GetStudentServices()
        {
            DataTable dt = GetData("SELECT     S.ServiceID, S.ServiceEn, S.ServiceAr, S.ServiceDescEn, S.ServiceDescAr, S.Audience, S.Host, S.HostDesc, S.FeesType, S.RequestList, S.RequestLink, S.ExampleLink, ISNULL(F.curAmount, 0) AS Fees, ISNULL(F.curVAT, 0) AS VAT,(F.curAmount + F.curVAT) as Sum, S.DataNeeded FROM         ECT_Services AS S LEFT OUTER JOIN (SELECT     bytePaymentFor, curAmount, curVAT FROM          ECTData.dbo.Acc_Payment_For AS ACCP) AS F ON S.FeesType = F.bytePaymentFor where S.Audience='Students' ORDER BY S.ServiceID asc");
            return dt;
        }
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
    }

}