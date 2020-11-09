using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// == Moodle
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClsMoodleAPI
/// </summary>
public class ClsMoodleAPI
{
	public ClsMoodleAPI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  
    public class MoodleGetUSer
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class MoodleException
    {
        public string exception { get; set; }
        public string errorcode { get; set; }
        public string message { get; set; }
        public string debuginfo { get; set; }
    }
    public class MoodleCreatedUser
    {
        public int id { get; set; }
        public string username { get; set; }
    }

    public class UserInfo
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string fullname { get; set; }
        public int firstaccess { get; set; }
        public int lastaccess { get; set; }
        public bool suspended { get; set; }
        public string description { get; set; }
        public int descriptionformat { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string profileimageurlsmall { get; set; }
        public string profileimageurl { get; set; }

    }
   
    public class ListOfUsers
    {
        public List<UserInfo> users { get; set; }
        public List<object> warnings { get; set; }
    }
    public class MoodleCreateUser
    {
        public string username { get; set; }
        public string password { get; set; }
        //public string createpassword { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string auth { get; set; }
        public int suspended { get; set; }
        //public string idnumber { get; set; }
        //public string lang { get; set; }
        //public string calendartype { get; set; }
        //public string theme { get; set; }
        //public string timezone { get; set; }
        public string mailformat { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string firstnamephonetic { get; set; }
        public string lastnamephonetic { get; set; }
        public string middlename { get; set; }
        public string alternatename { get; set; }
    }
    public class MoodleUpdateUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        //public string createpassword { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string auth { get; set; }
        public int suspended { get; set; }
        //public string idnumber { get; set; }
        //public string lang { get; set; }
        //public string calendartype { get; set; }
        //public string theme { get; set; }
        //public string timezone { get; set; }
        public string mailformat { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string firstnamephonetic { get; set; }
        public string lastnamephonetic { get; set; }
        public string middlename { get; set; }
        public string alternatename { get; set; }
    }
   
    //===============================
    public class MoodleManualEnrol
    {
        public int roleid { get; set; }
        public int userid { get; set; }
        public int courseid { get; set; }
        public int suspend { get; set; }
    }
    public class MoodleGroupsAddMember
    {
        public int groupid { get; set; }
        public int userid { get; set; }
    }
    public class MoodleGetCourseGroup
    {
        public int courseid { get; set; }
    }
    public class MoodleGetCourseGroupResponse
    {
        public int id { get; set; }
        public string courseid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string descriptionformat { get; set; }
        public string enrolmentkey { get; set; }
        public string idnumber { get; set; }
    }
    private static int GetGroupIDFromGroupName(string token, int iCourseID, string sGroupName)
    {
        int iGroupID = 0;

        //Start Check if any groups were present in the imported course or not; if yes delete all existing groups
        ClsMoodleAPI.MoodleGetCourseGroup GetCourse = new ClsMoodleAPI.MoodleGetCourseGroup();
        GetCourse.courseid = iCourseID;
        List<ClsMoodleAPI.MoodleGetCourseGroup> CourseGroupList = new List<ClsMoodleAPI.MoodleGetCourseGroup>();
        CourseGroupList.Add(GetCourse);
        Array arrCourseGroup = CourseGroupList.ToArray();
        String postCourseGroup = String.Format("courseid={0}", GetCourse.courseid);
        string createRequestCourseGroup = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_group_get_course_groups");
        // Call Moodle REST Service
        HttpWebRequest reqCourseGroup = (HttpWebRequest)WebRequest.Create(createRequestCourseGroup);
        reqCourseGroup.Timeout = 200000;  //added by bahaa to solve reqImport.GetResponse() timeout error
        reqCourseGroup.Method = "POST";

        reqCourseGroup.ContentType = "application/x-www-form-urlencoded";
        // Encode the parameters as form data:
        byte[] formCourseGroup =
            UTF8Encoding.UTF8.GetBytes(postCourseGroup);
        reqCourseGroup.ContentLength = formCourseGroup.Length;
        // Write out the form Data to the request:
        using (Stream postImportCourseGroup = reqCourseGroup.GetRequestStream())
        {
            postImportCourseGroup.Write(formCourseGroup, 0, formCourseGroup.Length);
        }
        // Get the Response
        HttpWebResponse respImportCourseGroup = (HttpWebResponse)reqCourseGroup.GetResponse();
        Stream resStreamImportCourseGroup = respImportCourseGroup.GetResponseStream();
        StreamReader readerImportCourseGroup = new StreamReader(resStreamImportCourseGroup);
        string contentsImportCourseGroup = readerImportCourseGroup.ReadToEnd();
        JavaScriptSerializer serializerImportCourseGroup = new JavaScriptSerializer();
        if (contentsImportCourseGroup.Contains("exception"))
        {
            // Error
            ClsMoodleAPI.MoodleException moodleError = serializerImportCourseGroup.Deserialize<ClsMoodleAPI.MoodleException>(contentsImportCourseGroup);
            // lblFailResults.Text += "Error in getting course groups -- " + contentsImportCourseGroup;
        }
        else
        {
            // Good
            List<ClsMoodleAPI.MoodleGetCourseGroupResponse> newCourseGroup = serializerImportCourseGroup.Deserialize<List<ClsMoodleAPI.MoodleGetCourseGroupResponse>>(contentsImportCourseGroup);
            int groupid = 0;
            string groupname = "";
            foreach (var value in newCourseGroup)
            {
                groupid = value.id;
                groupname = value.name;
                if (groupname == sGroupName)
                {
                    iGroupID = groupid;
                }
            }
        }

        return iGroupID;
    }
    private static string core_group_add_group_members(int groupid, int userid)
    {
        //members[0][groupid]= int
        //members[0][userid]= int

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        //===========
        //to fix the following error:
        //The underlying connection was closed: A connection that was expected to be kept alive was closed by the server.
        ServicePointManager.DefaultConnectionLimit = 100;
        ServicePointManager.MaxServicePointIdleTime = 200000;

        //req.KeepAlive = false;
        //=====================

        String token = "1b4cb9114197a84985695b19b1164d0a";

        ClsMoodleAPI.MoodleGroupsAddMember groups = new ClsMoodleAPI.MoodleGroupsAddMember();
        groups.groupid = groupid;
        groups.userid = userid;//HttpUtility.UrlEncode(userid)

        List<ClsMoodleAPI.MoodleGroupsAddMember> groupsList = new List<ClsMoodleAPI.MoodleGroupsAddMember>();
        groupsList.Add(groups);

        Array arrGroups = groupsList.ToArray();

        String postData = String.Format("members[0][groupid]={0}&members[0][userid]={1}", groups.groupid, groups.userid);
        string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_group_add_group_members");
        // Call Moodle REST Service
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(createRequest);
        req.Timeout = 200000;  //added by bahaa to solve reqImport.GetResponse() timeout error
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";

        // Encode the parameters as form data:
        byte[] formData =
            UTF8Encoding.UTF8.GetBytes(postData);
        req.ContentLength = formData.Length;

        // Write out the form Data to the request:
        using (Stream post = req.GetRequestStream())
        {
            post.Write(formData, 0, formData.Length);
        }

        // Get the Response
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream resStream = resp.GetResponseStream();
        StreamReader reader = new StreamReader(resStream);
        string contents = reader.ReadToEnd();
        return contents;
    }
    private static string enrol_manual_enrol_users(ClsMoodleAPI.MoodleManualEnrol enrol)
    {
        //enrolments[0][roleid]= int
        //enrolments[0][userid]= int
        //enrolments[0][courseid]= int
        //enrolments[0][timestart]= int
        //enrolments[0][timeend]= int
        //enrolments[0][suspend]= int

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        //===========
        //to fix the following error:
        //The underlying connection was closed: A connection that was expected to be kept alive was closed by the server.
        ServicePointManager.DefaultConnectionLimit = 100;
        ServicePointManager.MaxServicePointIdleTime = 200000;

        //req.KeepAlive = false;
        //=====================

        String token = "1b4cb9114197a84985695b19b1164d0a";


        //List<MoodleManualEnrol> groupsList = new List<MoodleManualEnrol>();
        //groupsList.Add(enrol);

        //Array arrGroups = groupsList.ToArray();

        String postData = String.Format("enrolments[0][roleid]={0}&enrolments[0][userid]={1}&enrolments[0][courseid]={2}&enrolments[0][suspend]={3}", enrol.roleid, enrol.userid, enrol.courseid, enrol.suspend);
        string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "enrol_manual_enrol_users");
        // Call Moodle REST Service
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(createRequest);
        req.Timeout = 200000;  //added by bahaa to solve reqImport.GetResponse() timeout error

        //req.KeepAlive = false;

        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";

        // Encode the parameters as form data:
        byte[] formData =
            UTF8Encoding.UTF8.GetBytes(postData);
        req.ContentLength = formData.Length;

        // Write out the form Data to the request:
        using (Stream post = req.GetRequestStream())
        {
            post.Write(formData, 0, formData.Length);
        }

        // Get the Response
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream resStream = resp.GetResponseStream();
        StreamReader reader = new StreamReader(resStream);
        string contents = reader.ReadToEnd();
        return contents;
    }
    public static int EnrollStudentinMoodleCourses(string sEmail,string sStudentID)
    {
        int iResult = InitializeModule.FAIL_RET;
        string sSQL = "";
        DataTable dtUser = new DataTable("User");
        DataSet dsUser = new DataSet();


        sSQL = "SELECT username, password, firstname, lastname";
        sSQL += ", course1, role1, group1, email, auth";
        sSQL += ", country, city, department,MoodleUserNo,MoodleCourseNo";
        sSQL += " FROM Moodle_Import_Students_M_F_Step4";
        sSQL += " WHERE email='" + sEmail + "'";
        //sSQL += " ORDER By course1,username ASC";


        //sSQL = "SELECT  S.username, S.password, S.firstname";
        //sSQL += ", S.lastname";
        //sSQL += ", S.course1";
        //sSQL += ", S.role1";
        //sSQL += ", S.group1, S.email";
        //sSQL += ", S.auth, S.country";
        //sSQL += ", S.city, S.department";
        //sSQL += ", S.MoodleUserNo, S.MoodleCourseNo";
        //sSQL += " FROM Moodle_Import_Students_M_F_Step4 AS S INNER JOIN";
        //sSQL += " AddTransactionsFromDate_MF ON S.sStudentNumber = AddTransactionsFromDate_MF.lngStudentNumber";
        //sSQL += " ORDER BY S.course1, S.username";

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        Conn.Open();
        SqlDataAdapter adapter;

        adapter = new SqlDataAdapter(sSQL, Conn);
        adapter.SelectCommand.CommandTimeout = 2000;
        dsUser.Tables.Add(dtUser);
        adapter.Fill(dtUser);
        adapter.Dispose();

        ClsMoodleAPI.MoodleManualEnrol enroluser = new ClsMoodleAPI.MoodleManualEnrol();

        int iSuspend = 0;
        int iUserID = 0;
        string sUsername = "";
        string sCourse = "";
        int iCourseID = 0;
        string sGroupName = "";
        int iGroupID = 0;
        iSuspend = 0;

        DataSet dsGroups = new DataSet();


        string Token = "1b4cb9114197a84985695b19b1164d0a";

        for (int i = 0; i < dsUser.Tables["User"].Rows.Count; i++) //i < dsUser.Tables["User"].Rows.Count
        {

            enroluser.roleid = Convert.ToInt32(dsUser.Tables["User"].Rows[i]["role1"].ToString());
            //get userid from username

            sUsername = dsUser.Tables["User"].Rows[i]["username"].ToString();
            iUserID = Convert.ToInt32("0" + dsUser.Tables["User"].Rows[i]["MoodleUserNo"].ToString());
            if (iUserID == 0)
            {
                iUserID = LibraryMOD.GetStudentMoodleUserNo(sStudentID);
            }

            iCourseID = Convert.ToInt32("0" + dsUser.Tables["User"].Rows[i]["MoodleCourseNo"].ToString());

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            enroluser.userid = iUserID;
            sCourse = dsUser.Tables["User"].Rows[i]["course1"].ToString();
            enroluser.courseid = iCourseID;
            enroluser.suspend = iSuspend;
            if (iCourseID == 2455) //ESL_Gen_20201
            {
                //enroll student in course 2541
                iCourseID = 2541; // ESL_Gen_155_20201
                enroluser.courseid = iCourseID;
            }
            iGroupID = 0;
            string contents = enrol_manual_enrol_users(enroluser);
            // Deserialize
            serializer = new JavaScriptSerializer();
            if (contents.Contains("exception"))
            {
                // Error
                ClsMoodleAPI.MoodleException moodleError = serializer.Deserialize<ClsMoodleAPI.MoodleException>(contents);
                //lbl_results.Text += "Error in enrolling user in course: " + enroluser.courseid + " / " + contents;
            }
            else
            {
                // Good
                List<string> newGroups = serializer.Deserialize<List<string>>(contents);
                // lbl_results.Text += "User Enrolled Successfuly - ";
                sGroupName = dsUser.Tables["User"].Rows[i]["group1"].ToString().Trim();

                if (iGroupID == 0)
                {
                    //get group no from moodle
                    iGroupID = GetGroupIDFromGroupName(Token, iCourseID, sGroupName);
                }
                //add to group

                contents = core_group_add_group_members(iGroupID, iUserID);

                //Deserialize
                serializer = new JavaScriptSerializer();
                if (contents.Contains("exception"))
                {
                    // Error
                    ClsMoodleAPI.MoodleException moodleError = serializer.Deserialize<ClsMoodleAPI.MoodleException>(contents);
                    // lbl_results.Text += "Error in adding member to group:" + sGroupName + "in course:" + sCourse + " / " + contents;
                }
                else
                {
                    // Good
                    //List<string> newGroups = serializer.Deserialize<List<string>>(contents);
                    // lbl_results.Text += "Member Added Successfuly";
                    iResult = InitializeModule.SUCCESS_RET;
                }
            }
        } //for
        return iResult;
    }
    public static int CreateUpdateMoodleAccount(string sEmail,string sStudentID)
    {
        int iReturnValue = 0;

        string sSQL = "";
        DataTable dtUser = new DataTable("User");
        DataSet dsUser = new DataSet();


        sSQL = "SELECT distinct username, password, firstname, lastname";
        sSQL += ", email, auth";
        sSQL += ", country, city, department,userno,moodleuserno";
        sSQL += " FROM Moodle_Import_Students_M_F_Step4";
        sSQL += " WHERE email='" + sEmail + "'";

        //sSQL += " ORDER By userno DESC";

        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        Conn.Open();
        SqlDataAdapter adapter;

        adapter = new SqlDataAdapter(sSQL, Conn);
        adapter.SelectCommand.CommandTimeout = 2000;
        dsUser.Tables.Add(dtUser);
        adapter.Fill(dtUser);
        adapter.Dispose();

        ClsMoodleAPI.MoodleCreateUser CreateUser = new ClsMoodleAPI.MoodleCreateUser();

        int iMoodleUserNo = 0;
        int iUserNo = 0;
        int iRequiredToUpdateMoodleUserinDB = 0;

        for (int i = 0; i < dsUser.Tables["User"].Rows.Count; i++) //
        {
            iUserNo = Convert.ToInt32("0" + dsUser.Tables["User"].Rows[i]["userno"].ToString());
            if (iUserNo == 0)
            {
                iUserNo = LibraryMOD.GetStudentUserNo(sStudentID); 
            }
            iMoodleUserNo = Convert.ToInt32("0" + dsUser.Tables["User"].Rows[i]["moodleuserno"].ToString());
            if (iMoodleUserNo == 0)
            {
                iRequiredToUpdateMoodleUserinDB = 1;
            }
            CreateUser.username = dsUser.Tables["User"].Rows[i]["username"].ToString();// + "test"
            CreateUser.email = dsUser.Tables["User"].Rows[i]["email"].ToString();// + "test"

            CreateUser.password = dsUser.Tables["User"].Rows[i]["password"].ToString();

            //CreateUser.createpassword = HttpUtility.UrlEncode(createpassword);
            CreateUser.firstname = dsUser.Tables["User"].Rows[i]["firstname"].ToString();
            CreateUser.lastname = dsUser.Tables["User"].Rows[i]["lastname"].ToString();


            CreateUser.auth = "oidc"; // oidc or manual
            CreateUser.suspended = 0;
            //CreateUser.idnumber = HttpUtility.UrlEncode(idnumber);
            //CreateUser.lang = HttpUtility.UrlEncode(lang);
            //CreateUser.calendartype = HttpUtility.UrlEncode(calendartype);
            //CreateUser.theme = HttpUtility.UrlEncode(theme);
            //CreateUser.timezone = HttpUtility.UrlEncode(timezone);
            CreateUser.mailformat = "1";
            CreateUser.description = "";
            CreateUser.city = "Abu Dhabi";
            CreateUser.country = "AE";
            CreateUser.firstnamephonetic = "";
            CreateUser.lastnamephonetic = "";
            CreateUser.middlename = "";
            CreateUser.alternatename = "";

            if (CreateUser.email != "")
            {
                iMoodleUserNo = ClsMoodleAPI.CreateUserInMoodleCheckIfExist(CreateUser);

            }

            if (iMoodleUserNo > 0 && iRequiredToUpdateMoodleUserinDB == 1)
            {
                //save Moodle user number in ECT database
                UpdateMoodleUserNo(iUserNo, iMoodleUserNo);
                iReturnValue = InitializeModule.SUCCESS_RET;
            }
            iRequiredToUpdateMoodleUserinDB = 0;

        }
        return iReturnValue;
    }
    private static int UpdateMoodleUserNo(int iUserNo, int iMoodleUserNo)
    {
        int iUpdated = 0;

        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
        conn.Open();
        try
        {
            string sSQL = "";

            sSQL = "UPDATE Cmn_User";
            sSQL += " SET MoodleUserNo =" + iMoodleUserNo;
            sSQL += " WHERE UserNo =" + iUserNo;

            SqlCommand cmd = new SqlCommand(sSQL, conn);

            iUpdated = cmd.ExecuteNonQuery();
            return iUpdated;
        }
        catch (Exception ex)
        {
            return iUpdated;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    private static int CreateUserInMoodleCheckIfExist(ClsMoodleAPI.MoodleCreateUser CreateUser)
    {
        int iResult = InitializeModule.FAIL_RET;
        //Start Check if user exists or not

        string get_users = core_user_get_users("username", CreateUser.username.Trim());
        // Deserialize
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        if (get_users.Contains("exception"))
        {
            // Error
            ClsMoodleAPI.MoodleException moodleError = serializer.Deserialize<ClsMoodleAPI.MoodleException>(get_users);
            // lbl_results.Text += " Error in get user:" + CreateUser.username + "/" + get_users;
        }
        else
        {
            // Good
            ClsMoodleAPI.ListOfUsers myDeserializedClass = JsonConvert.DeserializeObject<ClsMoodleAPI.ListOfUsers>(get_users);
            if (myDeserializedClass.users.Count > 0)
            {
                //string sReturnedUserName = myDeserializedClass.users[0].username;
                ClsMoodleAPI.MoodleUpdateUser UpdateUser = new ClsMoodleAPI.MoodleUpdateUser();
                UpdateUser.id = myDeserializedClass.users[0].id;
                iResult = UpdateUser.id;

                UpdateUser.suspended = 0;
                UpdateUser.username = CreateUser.username;
                UpdateUser.email = CreateUser.email;
                UpdateUser.password = CreateUser.password;
                //UpdateUser.=CreateUser.createpassword ;
                UpdateUser.firstname = CreateUser.firstname;
                UpdateUser.lastname = CreateUser.lastname;
                UpdateUser.auth = CreateUser.auth; // oidc or manual
                UpdateUser.suspended = CreateUser.suspended;
                //UpdateUser.idnumber =CreateUser.idnumber ;
                //UpdateUser.lang=CreateUser.lang;
                //UpdateUser.calendartype =CreateUser.calendartype ;
                //UpdateUser.theme =CreateUser.theme;
                //UpdateUser.timezone=CreateUser.timezone;
                UpdateUser.mailformat = CreateUser.mailformat;
                UpdateUser.description = myDeserializedClass.users[0].description; //CreateUser.description;
                UpdateUser.city = CreateUser.city;
                UpdateUser.country = CreateUser.country;
                UpdateUser.firstnamephonetic = CreateUser.firstnamephonetic;
                UpdateUser.lastnamephonetic = CreateUser.lastnamephonetic;
                UpdateUser.middlename = CreateUser.middlename;
                UpdateUser.alternatename = CreateUser.alternatename;
                //if (CreateUser.username.Trim() == sReturnedUserName)
                //{
                //    lbl_results.Text = "User Exists Already";
                //    //should update the User
                //}
                //else
                //{ //else start

                //If user not exists then create a new user with below parameters;
                string created_user = core_user_update_users(UpdateUser);//txt_Username.Text.Trim(), txt_Password.Text.Trim(), txt_FirstName.Text.Trim(), txt_LastName.Text.Trim(), txt_Email.Text.Trim(), txt_Auth.Text.Trim(), txt_Mailformat.Text.Trim(), txt_Description.Text.Trim(), txt_City.Text.Trim(), txt_Country.Text.Trim(), txt_firstnamephonetic.Text.Trim(), txt_lastnamephonetic.Text.Trim(), txt_middlename.Text.Trim(), txt_alternatename.Text.Trim());
                //core_user_update_users 
                // Deserialize
                JavaScriptSerializer serializercreated_user = new JavaScriptSerializer();
                if (created_user.Contains("exception"))
                {
                    // Error
                    ClsMoodleAPI.MoodleException moodleError = serializercreated_user.Deserialize<ClsMoodleAPI.MoodleException>(created_user);
                    //lbl_results.Text += "Error in updating user:" + CreateUser.username + " / " + created_user;
                }
                else
                {
                    List<ClsMoodleAPI.MoodleCreatedUser> newImport = serializercreated_user.Deserialize<List<ClsMoodleAPI.MoodleCreatedUser>>(created_user);
                    //  lbl_results.Text += "User profile Updated Successfully" ;
                }
                //} //else end
            }
            else
            {
                //If user not exists then create a new user with below parameters;
                string created_user = core_user_create_users(CreateUser);//txt_Username.Text.Trim(), txt_Password.Text.Trim(), txt_FirstName.Text.Trim(), txt_LastName.Text.Trim(), txt_Email.Text.Trim(), txt_Auth.Text.Trim(), txt_Mailformat.Text.Trim(), txt_Description.Text.Trim(), txt_City.Text.Trim(), txt_Country.Text.Trim(), txt_firstnamephonetic.Text.Trim(), txt_lastnamephonetic.Text.Trim(), txt_middlename.Text.Trim(), txt_alternatename.Text.Trim());
                // Deserialize
                JavaScriptSerializer serializercreated_user = new JavaScriptSerializer();
                if (created_user.Contains("exception"))
                {
                    // Error
                    ClsMoodleAPI.MoodleException moodleError = serializercreated_user.Deserialize<ClsMoodleAPI.MoodleException>(created_user);
                    //lbl_results.Text += "Error in updating:" + CreateUser.username + " / " + created_user;
                }
                else
                {

                    List<ClsMoodleAPI.MoodleCreatedUser> myserializercreated_user = serializercreated_user.Deserialize<List<ClsMoodleAPI.MoodleCreatedUser>>(created_user);

                    foreach (var value in myserializercreated_user)
                    {
                        iResult = value.id;
                    }
                    // lbl_results.Text += "User:" + iResult.ToString() + " / " + CreateUser.username + " Created Successfully";
                }
            }


        }

        // iResult = InitializeModule.SUCCESS_RET;
        return iResult;
    }
    private static string core_user_get_users(string key, string value)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        //===========
        //to fix the following error:
        //The underlying connection was closed: A connection that was expected to be kept alive was closed by the server.
        ServicePointManager.DefaultConnectionLimit = 100;
        ServicePointManager.MaxServicePointIdleTime = 200000;

        //req.KeepAlive = false;
        //=====================
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        String token = "1b4cb9114197a84985695b19b1164d0a";

        ClsMoodleAPI.MoodleGetUSer getusers = new ClsMoodleAPI.MoodleGetUSer();
        getusers.key = HttpUtility.UrlEncode(key);
        getusers.value = HttpUtility.UrlEncode(value);

        List<ClsMoodleAPI.MoodleGetUSer> groupsList = new List<ClsMoodleAPI.MoodleGetUSer>();
        groupsList.Add(getusers);

        Array arrGroups = groupsList.ToArray();

        //String postData = String.Format("field={0}&values[0]={1}", getusers.key, getusers.value);
        //string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_user_get_users_by_field");

        String postData = String.Format("criteria[0][key]={0}&criteria[0][value]={1}", getusers.key, getusers.value);
        string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_user_get_users");
        // Call Moodle REST Service
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(createRequest);
        req.Timeout = 200000;  //added by bahaa to solve reqImport.GetResponse() timeout error
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";

        //req.KeepAlive = false;

        // Encode the parameters as form data:
        byte[] formData =
            UTF8Encoding.UTF8.GetBytes(postData);
        req.ContentLength = formData.Length;

        // Write out the form Data to the request:
        using (Stream post = req.GetRequestStream())
        {
            post.Write(formData, 0, formData.Length);
        }


        // Get the Response
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream resStream = resp.GetResponseStream();
        StreamReader reader = new StreamReader(resStream);
        string contents = reader.ReadToEnd();
        return contents;
    }

    private static string core_user_update_users(ClsMoodleAPI.MoodleUpdateUser UpdateUser)//string username, string password, string firstname, string lastname, string email, string auth, string mailformat, string description, string city, string country, string firstnamephonetic, string lastnamephonetic, string middlename, string alternatename)
    {
        //users[0][id]= int                //Add
        //users[0][username]= string
        //users[0][password]= string
        //users[0][firstname]= string
        //users[0][lastname]= string
        //users[0][email]= string
        //users[0][auth]= string
        //users[0][suspended]= int        //Add
        //users[0][idnumber]= string
        //users[0][lang]= string
        //users[0][calendartype]= string
        //users[0][theme]= string
        //users[0][timezone]= string
        //users[0][mailformat]= int
        //users[0][description]= string
        //users[0][city]= string
        //users[0][country]= string
        //users[0][firstnamephonetic]= string
        //users[0][lastnamephonetic]= string
        //users[0][middlename]= string
        //users[0][alternatename]= string
        //users[0][userpicture]= int
        //users[0][customfields][0][type]= string
        //users[0][customfields][0][value]= string
        //users[0][preferences][0][type]= string
        //users[0][preferences][0][value]= string

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        //===========
        //to fix the following error:
        //The underlying connection was closed: A connection that was expected to be kept alive was closed by the server.
        ServicePointManager.DefaultConnectionLimit = 100;
        ServicePointManager.MaxServicePointIdleTime = 200000;

        //req.KeepAlive = false;
        //=====================


        String token = "1b4cb9114197a84985695b19b1164d0a";


        List<ClsMoodleAPI.MoodleUpdateUser> groupsList = new List<ClsMoodleAPI.MoodleUpdateUser>();
        groupsList.Add(UpdateUser);

        Array arrGroups = groupsList.ToArray();

        String postData = String.Format("users[0][id]={0}&users[0][username]={1}&users[0][password]={2}&users[0][firstname]={3}&users[0][lastname]={4}&users[0][email]={5}&users[0][auth]={6}&users[0][suspended]={7}&users[0][mailformat]={8}&users[0][description]={9}&users[0][city]={10}&users[0][country]={11}&users[0][firstnamephonetic]={12}&users[0][lastnamephonetic]={13}&users[0][middlename]={14}&users[0][alternatename]={15}", UpdateUser.id, UpdateUser.username, UpdateUser.password, UpdateUser.firstname, UpdateUser.lastname, UpdateUser.email, UpdateUser.auth, UpdateUser.suspended, UpdateUser.mailformat, UpdateUser.description, UpdateUser.city, UpdateUser.country, UpdateUser.firstnamephonetic, UpdateUser.lastnamephonetic, UpdateUser.middlename, UpdateUser.alternatename);
        string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_user_update_users");
        // Call Moodle REST Service
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(createRequest);
        req.Timeout = 200000;  //added by bahaa to solve reqImport.GetResponse() timeout error
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";

        // Encode the parameters as form data:
        byte[] formData =
            UTF8Encoding.UTF8.GetBytes(postData);
        req.ContentLength = formData.Length;

        // Write out the form Data to the request:
        using (Stream post = req.GetRequestStream())
        {
            post.Write(formData, 0, formData.Length);
        }

        // Get the Response
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream resStream = resp.GetResponseStream();
        StreamReader reader = new StreamReader(resStream);
        string contents = reader.ReadToEnd();
        return contents;
    }

    private static string core_user_create_users(ClsMoodleAPI.MoodleCreateUser CreateUser)//string username, string password, string firstname, string lastname, string email, string auth, string mailformat, string description, string city, string country, string firstnamephonetic, string lastnamephonetic, string middlename, string alternatename)
    {
        //users[0][username]= string
        //users[0][password]= string
        //users[0][createpassword]= int
        //users[0][firstname]= string
        //users[0][lastname]= string
        //users[0][email]= string
        //users[0][auth]= string
        //users[0][idnumber]= string
        //users[0][lang]= string
        //users[0][calendartype]= string
        //users[0][theme]= string
        //users[0][timezone]= string
        //users[0][mailformat]= int
        //users[0][description]= string
        //users[0][city]= string
        //users[0][country]= string
        //users[0][firstnamephonetic]= string
        //users[0][lastnamephonetic]= string
        //users[0][middlename]= string
        //users[0][alternatename]= string
        //users[0][preferences][0][type]= string
        //users[0][preferences][0][value]= string
        //users[0][customfields][0][type]= string
        //users[0][customfields][0][value]= string


        ServicePointManager.Expect100Continue = true;
        ServicePointManager.DefaultConnectionLimit = 9999;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        //===========
        //to fix the following error:
        //The underlying connection was closed: A connection that was expected to be kept alive was closed by the server.
        ServicePointManager.DefaultConnectionLimit = 100;
        ServicePointManager.MaxServicePointIdleTime = 200000;

        //req.KeepAlive = false;
        //=====================

        String token = "1b4cb9114197a84985695b19b1164d0a";


        List<ClsMoodleAPI.MoodleCreateUser> groupsList = new List<ClsMoodleAPI.MoodleCreateUser>();
        groupsList.Add(CreateUser);

        Array arrGroups = groupsList.ToArray();

        String postData = String.Format("users[0][username]={0}&users[0][password]={1}&users[0][firstname]={2}&users[0][lastname]={3}&users[0][email]={4}&users[0][auth]={5}&users[0][mailformat]={6}&users[0][description]={7}&users[0][city]={8}&users[0][country]={9}&users[0][firstnamephonetic]={10}&users[0][lastnamephonetic]={11}&users[0][middlename]={12}&users[0][alternatename]={13}", CreateUser.username, CreateUser.password, CreateUser.firstname, CreateUser.lastname, CreateUser.email, CreateUser.auth, CreateUser.mailformat, CreateUser.description, CreateUser.city, CreateUser.country, CreateUser.firstnamephonetic, CreateUser.lastnamephonetic, CreateUser.middlename, CreateUser.alternatename);
        string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_user_create_users");
        // Call Moodle REST Service
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(createRequest);
        req.Timeout = 200000;  //added by bahaa to solve reqImport.GetResponse() timeout error
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";

        // Encode the parameters as form data:
        byte[] formData =
            UTF8Encoding.UTF8.GetBytes(postData);
        req.ContentLength = formData.Length;

        // Write out the form Data to the request:
        using (Stream post = req.GetRequestStream())
        {
            post.Write(formData, 0, formData.Length);
        }

        // Get the Response
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream resStream = resp.GetResponseStream();
        StreamReader reader = new StreamReader(resStream);
        string contents = reader.ReadToEnd();
        return contents;
    }

}