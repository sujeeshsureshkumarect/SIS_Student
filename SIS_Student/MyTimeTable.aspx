<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTimeTable.aspx.cs" Inherits="SIS_Student.MyTimeTable" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3</h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                </style>  
                                           <style>
                    .details,#timetable {
                        /* font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
                        border-collapse: collapse;
                        width: 100%;
                    }

                  /*  td {
                        width: 25%;
                    }*/

                    .details td, .details th {
                        border: 1px solid #ddd;
                        padding: 5px;
                    }

                     #timetable td, #timetable th {
                        border: 1px solid #e5e5e5;
                        padding: 5px;
                    }

                    /*#details tr:nth-child(even){background-color: #f2f2f2;}

#details tr:hover {background-color: #ddd;}*/
/*
                    .details th {
                        padding-top: 12px;
                        padding-bottom: 12px;
                        text-align: left;
                        background-color: #4CAF50;
                        color: white;
                    }*/
                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-calendar"></i> My Time Table</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            
                                            <div id="form" align="center">


                                                <table style="width: 100%; border: 1px solid #e5e5e5" class="details">
                                                    <tr>
                                                        <th style="text-align: center; padding-left: 10px">
                                                            <h2><b>My Time Table</b>
                                                                <asp:Label ID="lbl_TitleYearSem" runat="server" Text="" Font-Bold="true"></asp:Label></h2>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="background-color: #f2f2f2;">
                                                            <asp:Label ID="lbl_TitleStudent" runat="server" Text=""  Font-Size="12" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="background-color: #f2f2f2;">
                                                            <asp:Label ID="lbl_TitleMajor" runat="server" Text="" Font-Size="12" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <hr />
                                                <div class="pull-right">                                  
                                        <asp:LinkButton ID="PrintFM_CMD" runat="server" CssClass="btn btn-success btn-sm pull-right" style="margin-right: 5px;" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF" OnClick="PrintFM_CMD_Click"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
                                    </div>
                                                <asp:Repeater ID="RepterDetails" runat="server">  
    <HeaderTemplate>  
                                                <table id="timetable" style="width: 100%; border: 1px solid #e5e5e5">
                                                    <tr>
                                                        <th align="center" style="border: 1px solid #e5e5e5">Session</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">Course Code</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">Course Name</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">Section #</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">From</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">To</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">Lecturer</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">Days</th>
                                                        <th align="center" style="border: 1px solid #e5e5e5">Hall</th>
                                                    </tr>
                                                    </HeaderTemplate>  
    <ItemTemplate> 
                                                    <tr>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("sPeriod") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("sCourse") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("sDesc") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("iClass") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("dFrom") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("dTo") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("sLecturer") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("sDay") %></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><%#Eval("sHall") %></td>
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
    </asp:Content>