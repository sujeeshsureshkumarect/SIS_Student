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

public class Connection_StringCLS
{

    public string Conn_string;


    public Connection_StringCLS()
    {
        Conn_string = "Data Source=10.20.10.9;Initial Catalog=ECTData;Persist Security Info=True;MultipleActiveResultSets=True;User ID=ECTDeveloper;Password=D!v@328";
    }

    public Connection_StringCLS(InitializeModule.EnumCampus Campus)
    {
        switch (Campus)
        {
            case InitializeModule.EnumCampus.Males:
                Conn_string = "Data Source=localect;Initial Catalog=ECTData;Persist Security Info=True;MultipleActiveResultSets=True;User ID=ECTDeveloper;Password=D!v@328";
                break;
            case InitializeModule.EnumCampus.Females:
                Conn_string = "Data Source=SQL_SERVER;Initial Catalog=ECTData;Persist Security Info=True;MultipleActiveResultSets=True;User ID=ECTDeveloper;Password=D!v@328";
                break;
            case InitializeModule.EnumCampus.ECTNew:
                Conn_string = "Data Source=localect;Initial Catalog=ECTDataNew;Persist Security Info=True;MultipleActiveResultSets=True;User ID=ECTDeveloper;Password=D!v@328";
                break;
            

        }
    }

    public Connection_StringCLS(string Source, string Catalog, bool isSecure, string UserID, string Password)
    {
        if (isSecure)
        {
            Conn_string = "Data Source=" + Source + ";Initial Catalog=" + Catalog + ";Persist Security Info=True;MultipleActiveResultSets=True;User ID=" + UserID + ";Password=" + Password;
        }
        else
        {
            Conn_string = "Data Source=" + Source + ";Initial Catalog=" + Catalog + ";Integrated Security=True";
        }
    }

}

