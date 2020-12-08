<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocsUpload.aspx.cs" Inherits="SIS_Student.DocsUpload" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Document Upload</title>
    <link rel="shortcut icon" href="images/favicon32.png" />
   
    <!-- Bootstrap -->
    <link href="gentelella-master/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="gentelella-master/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="gentelella-master/vendors/nprogress/nprogress.css" rel="stylesheet">
    <%--    <link href="gentelella-master/production/css/maps/jquery-jvectormap-2.0.3.css" rel="stylesheet" />--%>
    <!-- Custom Theme Style -->
    <link href="gentelella-master/build/css/custom.min.css" rel="stylesheet">

     <!-- Datatables -->
    
    <link href="gentelella-master/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet">
    <link href="gentelella-master/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet">
    <link href="gentelella-master/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet">
    <link href="gentelella-master/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet">
    <link href="gentelella-master/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet">

     <!-- jQuery custom content scroller -->
    <link href="gentelella-master/vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>
</head>

<body class="nav-md">
    <form id="form1" runat="server">
        <div class="container body">
            <div class="main_container">
                <div class="col-md-3 left_col menu_fixed">
                    <div class="left_col scroll-view">
                        <div class="navbar nav_title" style="border: 0;">
                            <%--<a href="Dashboard" class="site_title"><i class="fa fa-globe"></i><span> ECT SIS</span></a>--%>
                            <a href="#" class="site_title">
                                <i>
                                <img src="https://lms.ectmoodle.ae/theme/image.php/ect/theme/1595326309/favicon"/></i>
                                <span> ECT SIS</span>
                            </a>
                        </div>

                        <div class="clearfix"></div>

                        <!-- menu profile quick info -->
                        
                        <!-- /menu profile quick info -->

                        <br />

                        <!-- sidebar menu -->
                         <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
                            <div class="menu_section">
                                <h3>General</h3>
                                <ul class="nav side-menu">
                                    <li><a href="Login"><i class="fa fa-home"></i>ECT SIS</a></li>                                    
                                    <li><a href="https://lms.ectmoodle.ae/login/index.php" target="_blank"><i class="fa fa-desktop"></i>E-Learning</a></li>
                                    <li><a href="https://ect.ac.ae/" target="_blank"><i class="fa fa-globe"></i>ECT Website</a></li>
                                    <li><a href="https://ect.ac.ae/en/about-ect-2/" target="_blank"><i class="fa fa-info-circle"></i>About Us</a></li>
                                    <li><a href="https://ect.ac.ae/en/contact-us/" target="_blank"><i class="fa fa-phone"></i>Contact Us</a></li>                                   
                                </ul>
                            </div>


                        </div>
                        <!-- /sidebar menu -->

                        <!-- /menu footer buttons -->

                        <!-- /menu footer buttons -->
                    </div>
                </div>

                <!-- top navigation -->
                <!-- top navigation -->
                <div class="top_nav">
                    <div class="nav_menu">
                        <div class="nav toggle">
                            <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                        </div>
                        </div>
                    </div>
                <!-- /top navigation -->

                <!-- page content -->
             <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                </style>                              
                            </div>
                             <style type="text/css">
        #divLogin {
            text-align: center;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }

        .viewdiv {
            width: 100%;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }

        .details td, .details th {
            padding: 5px;
        }
        /*      .sss td {
                        width: 25%;
                        
                    }*/
        .sss {
            /* font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
            border-collapse: collapse;
        }

            .sss td, .sss th {
                border: 1px solid #ddd;
                padding: 5px;
            }
    </style>

                              <div id="divLogin" runat="server" align="center" visible="true">
        <table style="border: 1px solid #e5e5e5" align="center" class="details">
            <tr>
                <td colspan="2" align="center">
                    <h2>Login</h2>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_Username" runat="server" Text="Username"></asp:Label>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtUser" runat="server" Height="25px" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="25px" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btn_Login" runat="server" Text="Login" Height="25px" Width="70px" OnClick="btn_Login_Click" /><br />
                    <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
    </div>

                             <div id="upload" runat="server" visible="false" align="center">
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Document Upload</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
                                            
                                               <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
                $j("#txt_Expiry").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>
        <script type="text/javascript" src="Scripts/jquery.searchabledropdown.js"></script>
        <script type="text/javascript">
            var $i = jQuery.noConflict();
            $i(document).ready(function () {
                $i("select").searchable({
                    maxListSize: 200, // if list size are less than maxListSize, show them all
                    maxMultiMatch: 300, // how many matching entries should be displayed
                    exactMatch: false, // Exact matching on search
                    wildcards: true, // Support for wildcard characters (*, ?)
                    ignoreCase: true, // Ignore case sensitivity
                    latency: 200, // how many millis to wait until starting search
                    warnMultiMatch: 'top {0} matches ...',
                    warnNoMatch: 'no matches ...',
                    zIndex: 'auto'
                });
            });

        </script>
        <br />



        <table width="100%" align="center">
            <tr>
                <td>
                    <asp:Button Text="Upload Document" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
                        OnClick="Tab1_Click" />
                    <asp:Button Text="Document Search" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                        OnClick="Tab2_Click" />
                    <p align="right">
                     <asp:Button ID="btn_Logout" runat="server" Text="Logout" Height="25px" Width="90px" align="right" OnClick="btn_Logout_Click" />
</p>
                    <asp:MultiView ID="MainView" runat="server">
                        <asp:View ID="View1" runat="server" >
                             <div id="Div1" runat="server"  align="center">
                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid" align="center" class="sss">
                                <tr>
                                    <td>
                                        <br />
                                        <h1 style="text-align:center;">Upload Document Details</h1>
                                        <table style="border: 1px solid #e5e5e5;width:100%;" align="center" class="sss">
                                          <%--  <tr>
                                                <td colspan="2" align="right">
                                                   
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="center" style="background-color: #073772; color: white">Student ID
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drp_StudentID" runat="server" Height="25px" Width="204px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="drp_StudentID" InitialValue="---Select a Student---" ErrorMessage="*Please select a Student to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="background-color: #073772; color: white">Reference No.
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txt_Refernce" Height="25px" Width="200px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Reference Number Required" ControlToValidate="txt_Refernce" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="background-color: #073772; color: white">Description
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txt_Description" TextMode="MultiLine" Height="70px" Width="203px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="background-color: #073772; color: white">Upload Doc
                                                </td>
                                                <td>
                                                    <asp:FileUpload runat="server" ID="flp_Upload"></asp:FileUpload>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Document Required (.pdf/.jpg/.png)" ControlToValidate="flp_Upload" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="background-color: #073772; color: white">Expiry Date
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txt_Expiry" Height="25px" Width="200px" ClientIDMode="Static"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Expiry Date Required" ControlToValidate="txt_Expiry" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button runat="server" ID="btn_Save" Text="Save" Height="25px" Width="70px" OnClick="btn_Save_Click" ValidationGroup="no"></asp:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Label runat="server" ID="lbl_Msg2" Text="Document Added Successfully" ForeColor="red" Font-Bold="true" Visible="false"></asp:Label>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                                 </div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                <tr>
                                    <td>
                                        <div id="Div2" runat="server"  align="center">
        <div id="div3" runat="server" align="center" visible="true">
            <br />
            <h1>Document Search</h1>
            <br />
  <table  align="center" class="details">
            <tr>
                <td align="center">
                    Enter Reference No. / Student ID
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txt_Search" placeholder="Enter Document Reference No./Student ID" Height="25px"  Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_Search" runat="server" Text="Search" Height="25px" Width="70px" OnClick="btn_Search_Click"/>
                </td>                
            </tr>
      <tr>
          <td align="center" colspan="3">
                    <asp:Label ID="lbl_Msg" runat="server" ForeColor="Red" Text="No results found..." Font-Bold="true" Visible="false"></asp:Label>
                </td>
      </tr>
      </table>
            <hr />

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
                              <asp:Label ID="lbliEntry" runat="server" Text='<%# Eval("iEntry") %>' Visible = "false" />
                             <asp:Label ID="lblsURL" runat="server" Text='<%# Eval("sURL") %>' Visible = "false" />
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
                                <a href=" <%#Eval("sURL") %>" target="_blank" style="color: blue;"><u>Download/View</u></a>  &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete this Document?');" Font-Underline="true" ForeColor="Blue"/>
                         </td>
                     </tr>
        </ItemTemplate>
                 <FooterTemplate>  
    </table>  
    </FooterTemplate>  
    </asp:Repeater>  
             </div>
       
    </div>
                                            </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                
    <style type="text/css">
        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            background: url("../images/InitialImage.png") no-repeat right top;
            color: Black;
            font-weight: bold;
        }

            .Initial:hover {
                color: White;
                background: url("../images/SelectedButton.png") no-repeat right top;
            }

        .Clicked {
            float: left;
            display: block;
            background: url("../images/SelectedButton.png") no-repeat right top;
            padding: 4px 18px 4px 18px;
            color: Black;
            font-weight: bold;
            color: White;
        }
    </style>
                <!-- /page content -->
                <button onclick="topFunction()" id="myBtn" title="Go to top">▲ Top</button>
                <script>
//Get the button
var mybutton = document.getElementById("myBtn");

// When the user scrolls down 25px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
  if (document.body.scrollTop > 25 || document.documentElement.scrollTop > 25) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}
                </script>
                <style>
                    #myBtn {
  display: none;
  position: fixed;
  bottom: 20px;
  right: 30px;
  z-index: 99;
  font-size: 18px;
  border: none;
  outline: none;
  background-color: #2a3f54;
  color: white;
  cursor: pointer;
  padding: 10px;
  border-radius: 4px;
}

#myBtn:hover {
  background-color: #ffc107;
}
.site_title i {
    border: 1px solid #EAEAEA;
    padding: 7px 7px;
    border-radius: 50%;
    background: white;
}

                    .alert-danger, .alert-error {
                        color: #ffffff;
                    }
</style>
               
                <!-- footer content -->
                <footer>
                    <div class="pull-left">
                        Copyright © <%=DateTime.Now.Year%> <a href="https://ect.ac.ae" target="_blank">Emirates College of Technology</a>                        
                    </div>
                    <div class="pull-right">
                        Developed by <a href="https://ect.ac.ae" target="_blank">ETS Team</a>
                    </div>
                    <div class="clearfix"></div>
                </footer>
                <!-- /footer content -->
            </div>
        </div>
        <style>
            #lblUser {
    font-size: 14px;
    color: #ECF0F1;
    margin: 0;
    font-weight: 300;
}
          TABLE TH {
   /* border-right: white thin solid;
    border-top: white thin solid;*/
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
   /* border-left: white thin solid;*/
    color: #ECF0F1;
   /* border-bottom: white thin solid;*/
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2a3f54;
    text-align: center;
    line-height: 2;
    font-size: 13px;
}         
     .R_Critical {
   /* border-right: #073772 thin solid;
    border-top: #073772 thin solid;*/
    vertical-align: middle;
    /*border-left: #073772 thin solid;*/
    color: #000000;
  /*  border-bottom: #073772 thin solid;*/
    font-family: Arial, Helvetica, sans-serif;
    background-color: #F2B702;
    text-align: left;
    font-weight: bold;
    font-size: 13px;
}  
  .R_NormalWhite {
    /*border-right: #073772 thin solid;
    border-top: #073772 thin solid;*/
    vertical-align: middle;
   /* border-left: #073772 thin solid;*/
    color: #000000;
    /*border-bottom: #073772 thin solid;*/
    font-family: Arial, Helvetica, sans-serif;
    background-color: #F7F6F3;
    text-align: left;
    font-size: 13px;
}
  .R_NormalGray {
    /*border-right: #073772 thin solid;
    border-top: #073772 thin solid;*/
    vertical-align: middle;
   /* border-left: #073772 thin solid;*/
    color: #284775;
   /* border-bottom: #073772 thin solid;*/
    font-family: Arial, Helvetica, sans-serif;
    background-color: White;
    text-align: left;
    font-size: 13px;
}
  .th {
   /* border: 0;*/
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    color: #ECF0F1;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2a3f54;
    text-align: center;
    line-height: 2;
    font-size: 13px;
}
           
        </style>
        <!-- jQuery -->
        <script src="gentelella-master/vendors/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap -->
        <script src="gentelella-master/vendors/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
        <!-- FastClick -->
        <script src="gentelella-master/vendors/fastclick/lib/fastclick.js"></script>
        <!-- NProgress -->
        <script src="gentelella-master/vendors/nprogress/nprogress.js"></script>
        <!-- Datatables -->
    <script src="gentelella-master/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-buttons/js/buttons.flash.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="gentelella-master/vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
    <script src="gentelella-master/vendors/datatables.net-scroller/js/dataTables.scroller.min.js"></script>
    <script src="gentelella-master/vendors/jszip/dist/jszip.min.js"></script>
    <script src="gentelella-master/vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="gentelella-master/vendors/pdfmake/build/vfs_fonts.js"></script>
        <!-- Custom Theme Scripts -->
        <script src="gentelella-master/build/js/custom.min.js"></script>

         <!-- jQuery custom content scroller -->
    <script src="gentelella-master/vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>
    </form>
</body>
</html>
