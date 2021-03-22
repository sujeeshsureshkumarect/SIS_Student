<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SIS_Student.Dashboard" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3>Welcome To Emirates College of Technology (ECT)</h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }     
                                    A[href=""], A[href="#"] {
  display: none;
}
                                </style>
                                <%--  <div class="title_right">
                <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                      <button class="btn btn-default" type="button">Go!</button>
                    </span>
                  </div>
                </div>
              </div>--%>
                            </div>
                            <div class="clearfix"></div> 
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-home"></i> Home</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div class="col-md-5 col-sm-12">
                                                <div class="col-md-12 col-sm-12">
                                                    <a class="weatherwidget-io" href="https://forecast7.com/en/24d4554d38/abu-dhabi/" data-label_1="ABU DHABI" data-label_2="WEATHER" data-theme="original" data-basecolor="#2a3f54" data-textcolor="#e7e7e7">ABU DHABI WEATHER</a>
                                                    <script>
                                                        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = 'https://weatherwidget.io/js/widget.min.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'weatherwidget-io-js');
                                                    </script>
                                                </div>
                                                <div class="col-md-12 col-sm-12">
                                                    <br />
                                                    <div class="x_panel">
                                                        <div class="x_title">
                                                            <h2><i class="fa fa-info-circle"></i></h2>
                                                            <ul class="nav navbar-right panel_toolbox">
                                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                                </li>

                                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                                </li>
                                                            </ul>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="x_content">
                                                            <div>
                                                                <style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
  color:#5a738e !important;
}

tr:nth-child(even) {
  background-color: #dddddd;
}
</style>

<table>
  <tr>
    <td><b>Student ID</b></td>
    <td><asp:Label ID="lbl_Student_ID" runat="server"></asp:Label></td>   
  </tr>
  <tr>
    <td><b>Email ID</b></td>
    <td><asp:Label ID="lbl_Email_ID" runat="server"></asp:Label></td>   
  </tr>
  <tr>
    <td><b>Acceptance Type</b></td>
    <td><asp:Label ID="lbl_Acceptance_Type" runat="server"></asp:Label></td>   
  </tr>  
     <tr>
    <td><b>Acceptance Condition</b></td>
    <td><asp:Label ID="lbl_Acceptance_Condition" runat="server"></asp:Label></td>   
  </tr>
      <tr>
    <td><b>Current Major</b></td>
    <td><asp:Label ID="lbl_Current_Major" runat="server"></asp:Label></td>   
  </tr>
     <tr>
    <td><b>Status</b></td>
    <td><asp:Label ID="lbl_Status" runat="server"></asp:Label></td>   
  </tr>
</table>
                                                            </div>
                                                        </div>
                                                    </div>



                                                </div>

                                            </div> 
                                            <div class="col-md-7" style="width:100%;overflow-y:scroll;max-height:550px;">
                <div class="x_panel">
                  <div class="x_title">
                    <h2><i class="fa fa-volume-up"></i> ECT Announcements</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                     
                      <li><a class="close-link"><i class="fa fa-close"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                   <div>

                        <h4>Latest News</h4>

                        <!-- end of user messages -->
                        <ul class="messages">
                            <asp:Repeater ID="RepeaterNews" runat="server">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <img src="https://lms.ectmoodle.ae/theme/image.php/ect/theme/1595326309/favicon" class="avatar" alt="Avatar">
                                        <div class="message_date">
                                            <h3 class="date text-info"><%# Eval("dDate", "{0:dd}") %></h3>
                                            <p class="month"><%# Eval("dDate", "{0:MMM}") %></p>
                                            <p class="month"><%# Eval("dDate", "{0:yyyy}") %></p>
                                        </div>
                                        <div class="message_wrapper">
                                            <h4 class="heading"><a href="<%#Eval("sLink") %>?header=link" target="_blank"><%#Eval("sHeader") %></a></h4>
                                            <blockquote class="message" style="text-align: justify;text-justify: inter-word;"><%#Eval("sDetail") %></blockquote>
                                            <br>
                                            <p class="url">
                                                <span class="fs1 text-info" aria-hidden="true" data-icon=""></span>
                                                <a href="<%#Eval("sAttachment") %>" target="_blank" style="color: blue;"><u><i class="fa fa-paperclip"></i> <%#Eval("sAttachment") %></u></a>
                                            </p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate></FooterTemplate>
                            </asp:Repeater>
                        </ul>
                        <!-- end of user messages -->


                      </div>
                  </div>
                </div>
              </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>