<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance_Warning.aspx.cs" Inherits="SIS_Student.Attendance_Warning" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                     <h3><%--<i class="fa fa-user"></i> News Feed--%></h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                </style>                              
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-warning"></i> Attendance Warnings</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                                                            
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">                                                
                                            
                                <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="true" >

                                    <div class="alert alert-danger alert-dismissible " role="alert" runat="server" id="div_Alert">
                                        <%--<i class="fa fa-warning" style="float:left;font-size:50px"></i>--%>
                                        <div align="left">
                                        <asp:Label ID="lbl_Msg" runat="server" Visible="true" Font-Bold="true" Text="&quot;Dear Student... If you miss 10% of your lectures in any of your classes, you will receive a yellow warning in the &quot;Status&quot; column. When your absence reaches 20%, you will receive a second &quot;orange color&quot; warning, and when your absence reaches 30%, you will receive your final &quot;red&quot; warning in the &quot;Status&quot; column. If you miss any class beyond the 30% threshold, your class will be withdrawn, and you will receive an EW grade. The table below shows where you stand this semester in all your registered classes.&quot;" Font-Size="16px"></asp:Label>
                                        <br /><br />
                                            </div>
                                        <div align="right">
                                        <asp:Label ID="Label5" runat="server" Visible="true" Font-Bold="true" Text="%" Font-Size="16px" style="direction:rtl"></asp:Label><asp:Label ID="Label1" runat="server" Visible="true" Font-Bold="true" Text="عزيزي الطالب ... إذا فاتك 10٪ من محاضراتك في أي مساق، سيصلك تحذير أصفر في عمود الحالة . عندما يصل غيابك إلى 20" Font-Size="16px" style="direction:rtl"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" Visible="true" Font-Bold="true" Text="ستتلقى تحذيرًا ثانيًا برتقالي اللون. وعندما يصل غيابك إلى مستوى 30٪  فستتلقى تحذيرا أخيرا باللون الأحمر في عمود الحالة" Font-Size="16px" style="direction:rtl"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Visible="true" Font-Bold="true" Text="EW أي تجاوز  في غياباتك بعد وصولك حد ال 30% المسموح به سيؤدي الى سحب المساق، وإعطائك درجة" Font-Size="16px" style="direction:rtl"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label4" runat="server" Visible="true" Font-Bold="true" Text="يوضح الجدول أدناه مستوى غياباتك في هذا الفصل الدراسي في جميع مساقاتك المسجلة" Font-Size="16px" style="direction:rtl"></asp:Label>
                                            </div>
                                    </div>
                                </div>

                                            <div class="clearfix"></div>                                           
                         <div id="datatable_wrapper" class="table-responsive">
                     
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                <table id="datatable" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Courses</th>                                            
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Status</th>   
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Message</th>  
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td><%#Eval("Course")%></td>                                                                                                         
                                                    <td><%#Eval("Warning")%></td>  
                                                    <td><%#Eval("Warning")%></td>      
                                                </tr>
                                        
                                   </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>                          
                            </div>
                        </div>
                  
                    </div>
                        </div>

                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
       <script>
       var table = document.getElementById("datatable");
       if (table != null) {
           for (var i = 1; i < table.rows.length; i++) {              
               var warning = table.rows[i].cells[2].textContent;               
               if (warning == "1") {
                   table.rows[i].cells[2].innerHTML = '<span class="badge badge-warning1">First Warning</span>';
                   table.rows[i].cells[3].innerHTML = 'Your absence has reached 10%';
               }   
               else if (warning == "2") {
                   table.rows[i].cells[2].innerHTML = '<span class="badge badge-warning2">Second Warning</span>';
                   table.rows[i].cells[3].innerHTML = 'Your absence has reached 20%';
               } 
               else if (warning == "3") {
                   table.rows[i].cells[2].innerHTML = '<span class="badge badge-warning3">Third Warning</span>';
                   table.rows[i].cells[3].innerHTML = 'Your absence has reached 30%';
               } 
               else if (warning == "4") {
                   table.rows[i].cells[2].innerHTML = '<span class="badge badge-warningEW">EW</span>';
                   table.rows[i].cells[3].innerHTML = '<span class="badge badge-warningEW">You have been withdrawn from the course because you have exceeded the 30% threshold</span>';
               } 
               else {
                   table.rows[i].cells[2].innerHTML = '-';
                   table.rows[i].cells[3].innerHTML = '<span class="badge badge-success1">No Warning</span>';
               }

           }
       }
       </script>

                    <style>
                         .badge {
            font-size: 100%;
        }
                   .alert-info1 {
    color: #fff;
    background-color: #2b9ad6;
    border-color: #268ec5;
}
.dashboard-stat.red-intense {
    background-color: #e35b5a;
}
.dashboard-stat {
    display: block;
    margin-bottom: 25px;
    overflow: hidden;
    -webkit-border-radius: 8px;
    -moz-border-radius: 8px;
    -ms-border-radius: 8px;
    -o-border-radius: 8px;
    border-radius: 8px;
}

.dashboard-stat .visual {
    width: 80px;
    height: 80px;
    display: block;
    float: left;
    padding-top: 10px;
    padding-left: 15px;
    margin-bottom: 15px;
    font-size: 35px;
    line-height: 35px;
}
.dashboard-stat .positionchane {
    width: 80px;
    height: 80px;
    display: block;
    float: left;
    padding-top: 10px;
    padding-left: 15px;
    margin-bottom: 15px;
    font-size: 35px;
    line-height: 35px;
}
.dashboard-stat .details {
    position: absolute;
    right: 15px;
    padding-right: 15px;
    color: #FFFFFF;
}
.dashboard-stat .details .number {
    padding-top: 13px;
    text-align: right;
    line-height: 36px;
    letter-spacing: -1px;
    margin-bottom: 0px;
    font-weight: 300;
    font-size: 26px;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.dashboard-stat .details .desc {
    text-align: right;
    font-size: 16px;
    letter-spacing: 0px;
    font-weight: 300;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.fa1 {
    display: inline-block;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
    font-style: normal;
    font-weight: normal;
    line-height: 1;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}
.dashboard-stat .visual > i {
    margin-left: -35px;
    font-size: 110px;
    line-height: 110px;
}
.dashboard-stat .positionchane > i {
    margin-left: -50px;
    font-size: 40px;
    line-height: 40px;
}
.dashboard-stat.red-intense .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.purple-plum .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.blue-madison .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.red-intense .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.orange_clr {
    background: #EA9852 !important;
}
.dashboard-stat.blue-madison {
    background-color: #578ebe;
}
.dashboard-stat.purple-plum {
    background-color: #73A839;
}
.dashboard-stat.blue-madison .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.purple-plum .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.red-intense .more {
    color: #FFFFFF;
    background-color: #e04a49;
}
.dashboard-stat .more {
    clear: both;
    display: block;
    padding: 6px 10px 6px 10px;
    position: relative;
    text-transform: uppercase;
    font-weight: 300;
    font-size: 11px;
    opacity: 0.7;
    filter: alpha(opacity=70);
}
.badge-warning1 {
    color: #212529;
    background-color: #ffff8a;/*light yellow*/
}
.badge-warning2 {
    color: #212529;
    background-color: #f7ca79;/*light orange*/
}
.badge-warning3 {
    color: #212529;
    background-color: #ea6254;/*red*/
}
.badge-warningEW {
    color: red;/*text red bold*/
    font-weight:bold;
}
.badge-success1 {
    color: #212529;
    background-color: #90ee90;/*light green*/
}
    </style>
    </asp:Content>