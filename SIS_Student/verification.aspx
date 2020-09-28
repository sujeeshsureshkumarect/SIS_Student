<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verification.aspx.cs" Inherits="SIS_Student.verification" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Verification</title> 
    <meta name="keywords" content="" />
    <meta name="description" content="" />

    <link href="ECT_style.css" rel="stylesheet" type="text/css" media="all"/>

   <%-- <script language="javascript" type="text/javascript">
        
        function getcoordinate() {
            var x = event.clientX;
            var y = event.clientY;
            
            if (x >= 0 && x <= 30 && y >= 140) {
                showsidebar();
            }

        }


        function hidemsg() {
            document.getElementById("divMsg").style.display = "none";
        }
        function showmsg(msg) {
            document.getElementById("divMsg").style.display = "block";
            document.getElementById("divMsgText").innerHTML = msg;
        }

        function showsidebar() {

            document.getElementById("CenterDIV").style.display = "block";

        }

        function hidesidebar() {
            document.getElementById("CenterDIV").style.display = "none";
        }

        /*function hidelogin() {
            showsidebar();
            document.getElementById("divLogIn").style.display = "none";
            document.getElementById("divLogOut").style.display = "block";
        }*/
        function showlogin() {
            showsidebar();
            document.getElementById("divLogIn").style.display = "block";
            /*document.getElementById("divLogOut").style.display = "none";*/
        }

    </script>--%>
 

    <style type="text/css">
  
#wrapper
{
    background-color: #CCCCCC;
    vertical-align: top;
    text-align: center;
}


#CenterContent
{    
    text-align: center;
    background-color: White;
    width: 100%;
    vertical-align: top;
}

/* Header */
/*rgba(7, 55, 114, 1)=#073772*/
#header
{
    width: 100%;
    height: 90px;
    margin: 0 auto;
    background-color: #073772;
    text-align: center;
    vertical-align: top;
}

/* Logo */    
        #logo {
            /* float: left;*/
            width: 270px;
            height: 105px;
            margin: 0px;
        }




/* Footer */

#footer
{
    margin: 0 auto;
    padding: 20px 0px;
    background: #000000;
    color: #C0C0C0;
}
#footer {
  position: absolute;
  bottom: 0;
  width: 100%;
}
#footer p {
	margin: 0;
	text-align: center;
	font-size: 77%;
}

#footer a {
	text-decoration: underline;
	color: #A1A1A1;
}

#footer a:hover {
	text-decoration: none;
}

        

        
    </style>    
</head>



<body>
    <div id="wrapper">
        
      <div id="header">
        <div id="logo">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/New_Logo.png" 
            Width="380px" Height="90px" />
      </div>
        <!-- end div#logo -->
      </div>
    
    
         </div>
    <!-- end div#wrapper --> 
    <div id="CenterContent">
         <form id="Form1" runat="server">     
        <div id="divLogin" runat="server" align="center" visible="true">
            <br />
            <h1>Document Verification</h1>
            <br />
  <table  align="center" class="details">
            <tr>
                <td align="center">
                    Reference No.
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txt_Search" placeholder="Enter Document Reference No." Height="25px" required Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_Search" runat="server" Text="Verify" Height="25px" Width="70px" OnClick="btn_Search_Click"/>
                </td>                
            </tr>
      <tr>
          <td align="center" colspan="3">
                    <asp:Label ID="lbl_Msg" runat="server" ForeColor="Red" Text="No results found..." Font-Bold="true" Visible="false"></asp:Label>
                </td>
      </tr>
      </table>
            <hr />
       
    </div>
             <style>
                  .result {
                        /* font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
                        border-collapse: collapse;
                        width: 100%;
                    }

                  /*  .result td {
                        width: 25%;
                    }*/

                    .result td, .result th {
                        border: 1px solid #ddd;
                        padding: 5px;
                    }
             </style>
             <div id="Results" runat="server" align="center" visible="false">
                 <br />
                  <asp:Repeater ID="RepterDetails" runat="server">  
    <HeaderTemplate>  
                 <table style="border: 1px solid #e5e5e5" align="center" class="result">
                     <tr>
                         <th>SR No.</th>
                         <th>Student ID</th>
                         <th>Reference No.</th>
                         <th>Description</th>
                         <th>Issue Date</th>
                         <th>Expiry Date</th>
                         <th>Actions</th>
                     </tr>
                     </HeaderTemplate>  
    <ItemTemplate> 
                     <tr>
                         <td align="center">
                           <%# Container.ItemIndex + 1 %>
                         </td>
                         <td align="center">
                            <%#Eval("sStudentID") %>
                         </td>
                            <td align="center">
                             <%#Eval("sReference") %>
                         </td>
                            <td align="center">
                             <%#Eval("sDesc") %>
                         </td>
                            <td align="center">
                             <%# Eval("dIssueDate", "{0:dd/MM/yyyy}") %>
                         </td>
                            <td align="center">
                             <%# Eval("dValidTo", "{0:dd/MM/yyyy}") %>
                         </td>
                            <td align="center">
                                <a href=" <%#Eval("sURL") %>" target="_blank">Download/View</a>                            
                         </td>
                     </tr>
        </ItemTemplate>
                 <FooterTemplate>  
    </table>  
    </FooterTemplate>  
    </asp:Repeater>  
             </div>
             </form>
     </div>
    <div id="footer">     
       <p>Copyright ©  <a href="http://ect.ac.ae" target="_blank">Emirates College of Technology</a> - Design: <a href="http://ect.ac.ae" target="_blank">ETS Team</a></p>
    </div>
      <!-- end div#footer -->
      
 
    
</body>
    <%--<asp:ContentPlaceHolder ID="MainContent" runat="server"/>--%>
</html>
