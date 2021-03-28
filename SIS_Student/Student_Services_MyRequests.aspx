<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Services_MyRequests.aspx.cs" Inherits="SIS_Student.Student_Services_MyRequests" MasterPageFile="~/Student.Master"%>

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
                                            <h2><i class="fa fa-files-o"></i> My Requests <asp:LinkButton ID="lnk_refresh" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_refresh_Click" ToolTip="Refresh"><i class="fa fa-refresh"></i></asp:LinkButton></h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                                                            <a href="Student_Services.aspx"  class="btn btn-success btn-sm"><i class="glyphicon glyphicon-plus"></i> Create New Service</a>
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">                                                

                                            <div class="clearfix"></div>                                           
                         <div id="datatable_wrapper" class="table-responsive">
                     <style>                      
                        #datatable tbody td div{
width:490px;
max-height:100px !important;
overflow:scroll;
white-space: nowrap;
}

                    </style>
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                <table id="datatable" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Service Name</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending">Detail</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Created on</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td><%#Eval("ServiceID")%></td>                                                                                                         
                                                    <td><%#Eval("Status")%></td>                                                                                                        
                                                    <td><span style="display: none;"><%#Eval("Created","{0:yyyyMMdd}")%></span><%#Eval("Created","{0:dd/MM/yyyy hh:mm tt}")%></td>
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
               var status = table.rows[i].cells[2].textContent;               
               if (status == "Completed") {
                   table.rows[i].cells[2].innerHTML = '<span class="badge badge-success">Completed</span>';
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
    </style>
    </asp:Content>