<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdvising.aspx.cs" Inherits="SIS_Student.StudentAdvising" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3>Registration</h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
/*                                    TABLE TH {
    border-right: white thin solid;
    border-top: white thin solid;
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    border-left: white thin solid;
    color: #ECF0F1;
    border-bottom: white thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2a3f54;
    text-align: center;
    line-height: 2;
     font-size: 13px;
}
                                    .th {
    border: 0;
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
                                     .R_NormalWhite {
    border-right: #073772 thin solid;
    border-top: #073772 thin solid;
    vertical-align: middle;
    border-left: #073772 thin solid;
    color: #000000;
    border-bottom: #073772 thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #F7F6F3;
    text-align: left;
    font-size: 13px;
}
        .R_NormalGray {
    border-right: #073772 thin solid;
    border-top: #073772 thin solid;
    vertical-align: middle;
    border-left: #073772 thin solid;
    color: #284775;
    border-bottom: #073772 thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: White;
    text-align: left;
    font-size: 13px;
}
        .R_Critical {
    border-right: #073772 thin solid;
    border-top: #073772 thin solid;
    vertical-align: middle;
    border-left: #073772 thin solid;
    color: #000000;
    border-bottom: #073772 thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #F2B702;
    text-align: left;
    font-weight: bold;
     font-size: 13px;
}*/
        #ContentPlaceHolder1_tblDetail {
  width: 100%;
}
                                </style>
                                <style type="text/css">
        #divAdvising
        {
            text-align: center;
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
                                            <h2><i class="fa fa-users"></i> Student Advising</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
                                                <div id="divAdvising">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:HiddenField runat="server" ID="hdnStudentNumber"></asp:HiddenField>
                        <div runat="server" id="divDetail" width="100%" align="center" style="overflow-x:auto;"></div></td>
                </tr>
                <tr>
                    <td>
                        <div id="divMirror" runat="server"></div>
                        <asp:Panel runat="server" ID="Advising_pnl">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                      <%--  <asp:ImageButton runat="server" ImageUrl="~/Images/Icons/Print.gif" 
                            ToolTip="Print" ID="Print_btn" OnClick="Print_btn_Click" CssClass="btCommand">
                        </asp:ImageButton>--%>
                        <br />
                        <asp:LinkButton ID="Print_btn" runat="server" CssClass="btn btn-success btn-sm"  OnClick="Print_btn_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
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
                    </div>
    </asp:Content>
