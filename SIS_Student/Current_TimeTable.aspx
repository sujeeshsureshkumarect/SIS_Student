<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Current_TimeTable.aspx.cs" Inherits="SIS_Student.Current_TimeTable" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3><i class="fa fa-clock-o"></i> Courses Time Table</h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                    /*TABLE TH {
    border-right: white thin solid;
    border-top: white thin solid;
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    border-left: white thin solid;
    color: #ffffff;
    border-bottom: white thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2a3f54;
    text-align: center;
    line-height: 2;
    font-size: small;
}*/
                                      td, th {
  border: 1px solid #dddddd;
  /*text-align: left;*/
  padding: 9px;
}
                                </style>  
                                  <style type="text/css">
        #divTimeTable
        {
            text-align: center;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
        .viewdiv
        {
            width:100%;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-calendar"></i>   <asp:Label ID="lblTerm" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#73879C"></asp:Label></h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                  <div id="divTimeTable" align="center">
        <div>
        <div align="center">
                    
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                                           <asp:RadioButtonList ID="rbnSession" runat="server" AutoPostBack="True" 
                                RepeatDirection="Horizontal" 
                        onselectedindexchanged="rbnSession_SelectedIndexChanged" >
                                <asp:ListItem Selected="True" Value="1" class="btn btn-success">&nbsp;<i class="fa fa-female"></i> Females Morning</asp:ListItem>
                                <asp:ListItem Value="2" class="btn btn-success">&nbsp;<i class="fa fa-female"></i> Females Evening</asp:ListItem>
                                <asp:ListItem Value="9" class="btn btn-success">&nbsp;<i class="fa fa-female"></i> Females Weekend</asp:ListItem>
                                <asp:ListItem Value="4" class="btn btn-success">&nbsp;<i class="fa fa-male"></i> Males Evening</asp:ListItem>
                                <asp:ListItem Value="8" class="btn btn-success">&nbsp;<i class="fa fa-male"></i> Males Weekend</asp:ListItem>
                            </asp:RadioButtonList>
                       <%-- <asp:ImageButton runat="server" ImageUrl="~/Images/Icons/Print.gif" 
                            ToolTip="Print" ID="Print_btn" OnClick="Print_btn_Click" CssClass="btCommand">
                        </asp:ImageButton>--%>
                    <br />
             <div class="pull-right">                                  
                                        <asp:LinkButton ID="Print_btn" runat="server" CssClass="btn btn-success btn-sm pull-right" style="margin-right: 5px;" OnClick="PrintFM_CMD_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
                                    </div>
                        <br />

                        <br />
                    <asp:GridView ID="grdTM" runat="server" AutoGenerateColumns="False" 
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="iSerial" HeaderText="#" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCourse" HeaderText="Code" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sDesc" HeaderText="Course" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="iClass" HeaderText="Class" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                
                            </asp:BoundField>
                            <asp:BoundField DataField="sTFrom" HeaderText="From" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="sTTo" HeaderText="To" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sDay" HeaderText="Days" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sHall" HeaderText="Hall" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sLecturer" HeaderText="Lecturer" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>

                        <br />
            
        </div>        
            
                
                
    
    
          
    <div id="divDetail" runat="server">
    
           
        
        <br />
    </div>
    </div>
    </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                                           <style>
                                                .alert-info {
    background-color: #d9edf7;
    border-color: #bce8f1;
    color: #3a87ad;
}
                                            </style>
    </asp:Content>