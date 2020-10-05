<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Services_HostedResult.aspx.cs" Inherits="SIS_Student.Student_Services_HostedResult" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3></h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                </style>  
                                 <style type="text/css">
        #divResult
        {
            text-align: center;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
        
         .auto-style1 {
             height: 18px;
         }
             TABLE TH {
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
}
    </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2></h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                               <div class="x_content bs-example-popovers" id="div_msg1" runat="server" visible="false">

                                    <div class="alert alert-success alert-dismissible " role="alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Request Generated Successfully" Visible="false" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                             <div id="divResult" runat="server">
        <div runat="server" align="center">    
            <table width="70%" align="center">
                <tr>
                    <th colspan="2" align="center">Payment Result</th>
                </tr>
                <tr>
                    <td align="right" width="50%">  
                                
                        <asp:Label ID="lbl_OrderID" runat="server" Text="Payment ID :" style="font-weight: 700"></asp:Label>  
                                
                    </td>
                    <td align="left" style="margin-left:20px">  
                                
                        <asp:Label ID="lblOrderID" runat="server"></asp:Label>
                                
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">  
                                
                        <asp:Label ID="lbl_OrderID0" runat="server" Text="Payment Details :" style="font-weight: 700"></asp:Label>  
                                
                    </td>
                    <td align="left" style="margin-left:20px" class="auto-style1">  
                                
                        <asp:Label ID="lblDesc" runat="server"></asp:Label>
                                
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">  
                                
                        <asp:Label ID="lbl_OrderID2" runat="server" Text="Payment Receipt No :" style="font-weight: 700"></asp:Label>  
                                
                    </td>
                    <td align="left" style="margin-left:20px" class="auto-style1">  
                                
                        <asp:Label ID="lblReceiptNo" runat="server"></asp:Label>
                                
                    </td>
                </tr>
                <tr>
                    <td align="right">  
                                
                        <asp:Label ID="lbl_OrderID1" runat="server" Text="Payment Amount (AED) :" style="font-weight: 700"></asp:Label>  
                                
                    </td>
                    <td align="left" style="margin-left:20px">  
                                
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">  
                                
                        <asp:Label ID="lbl_PaymentReference" runat="server" Text="Payment Reference :" style="font-weight: 700"></asp:Label>  
                                
                    </td>
                    <td align="left" style="margin-left:20px" class="auto-style1">  
                                
                        <asp:Label ID="lblPRef" runat="server"></asp:Label>
                                
                    </td>
                </tr>
                <tr>
                    <td align="right">  
                                
                        <asp:Label ID="lbl_PaymentStatus" runat="server" Text="Payment Status :" style="font-weight: 700"></asp:Label>  
                                
                    </td>
                    <td align="left" style="margin-left:20px">  
                                
                        <asp:Label ID="lblPStatus" runat="server"></asp:Label>
                                
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">  
                                
                       <hr /></td>
                </tr>
                <tr>
                    <td align="center" colspan="2"style="background-color: #FFFFCC; font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; vertical-align: middle; text-align: center; border-bottom-width: thin; border-bottom-color: #C0C0C0; border-bottom-style: solid; color:red;">  
                                
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2"style="background-color: #FFFFCC; font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; vertical-align: middle; text-align: center; border-bottom-width: thin; border-bottom-color: #C0C0C0; border-bottom-style: solid; color:red;">  
                        <div id="divMsg" runat="server"></div>           
                     </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">  
                                
                        <hr /></td>
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