<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Balance.aspx.cs" Inherits="SIS_Student.Balance" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <%--<h3>Welcome To Emirates College Of Technology (ECT)</h3>--%>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                </style> 
                                  <style type="text/css">
        #divBalance
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
        .style1
        {
            height: 20px;
        }
         td, th {
  border: 1px solid #dddddd;
  /*text-align: left;*/
  padding: 9px;
}
          td {
                        width: 25%;
                    }
    </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-calculator"></i> Balance & Payment</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <%--<div class="col-md-6">--%>
                                             <div id="divBalance" runat="server">
        <div runat="server" align="center">               
            <asp:MultiView ID="mtvBalance" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server" >                                     
                <%--    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" 
                        ForeColor="Red" Text="For Testing Only (It will be available soon...)" 
                        Visible="False"></asp:Label>
                    <br />--%>
                    <table width="100%" align="center" style="border: 1px solid #ddd">
                        <tr>
                            <th colspan="3" align="center" style="font-size:16px"><i class="fa fa-credit-card"></i> Balance</th>
                        </tr>
                        <tr>
                            <td align="center" colspan="2"
                                
                                style="  font-size: 13px; font-weight: bold; text-transform: capitalize; vertical-align: middle; text-align: center; border-bottom-width: thin; border-bottom-color: #ddd; border-bottom-style: solid;">
                                The presented balance is subject to change during registration until one week after the end of the add/drop period for the semester
                            </td>
                               <td align="center" colspan="1"
                                
                                style=" font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; text-transform: capitalize; vertical-align: middle; text-align: center; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #ddd;">
                                الرصيد الموضح قابل للتعديل خلال التسجيل وحتى اسبوع بعد انتهاء فترة السحب والإضافة للفصل الدراسي</td>
                            
                        </tr>
                     <%--   <tr>
                            <td align="center" colspan="2" 
                                
                                style="background-color: #f7f7f7; font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; text-transform: capitalize; vertical-align: middle; text-align: center; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #ddd;">
                                الرصيد الموضح قابل للتعديل خلال التسجيل وحتى اسبوع بعد انتهاء فترة السحب والإضافة للفصل الدراسي</td>
                        </tr>--%>
                        <tr align="center">
                            <td align="center" style="background-color: #f2f2f2;">
                                <asp:Label ID="Label3" runat="server" Text="Balance Amount (AED)" Width="100%" 
                                    Font-Bold="True"  ForeColor="Red" 
                                    ToolTip="مبلغ الرصيد (درهم)" CssClass="title"></asp:Label>
                               
                            </td>
                            <td align="center">
                                 <asp:Label ID="lblOBalanceVATBTS" runat="server" Text="0.00" Width="100%" 
                                    Font-Bold="True"  ForeColor="Red" 
                                    ToolTip="المبلغ الاجمالي المستحق" CssClass="title" ></asp:Label>
                            </td>
                             <td align="center" style="background-color: #f2f2f2;">
                                 <asp:Label ID="Label2" runat="server" Text="مبلغ الرصيد (درهم)" Width="100%" 
                                    Font-Bold="True"  ForeColor="Red" 
                                    ToolTip="مبلغ الرصيد (درهم)" CssClass="title" ></asp:Label>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td colspan="2"><hr /></td>
                        </tr>--%>
                        <tr align="center">
                            <td align="center" style="background-color: #f2f2f2;">

                                <asp:Label ID="Label1" runat="server" Text="Payment Amount (AED)" 
                                Font-Bold="true"    ToolTip="قيمة الدفعة"></asp:Label><span style="color: red">*</span>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtPayment" runat="server" 
                                    ValidationGroup="Payment"  style="text-align: center"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtPayment" Display="Dynamic" 
                                    ErrorMessage="Payment Amount is required" SetFocusOnError="True" 
                                    style="color: #FF0000" ValidationGroup="Payment">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                    ControlToValidate="txtPayment" Display="Dynamic" 
                                    ErrorMessage="Positive numbers only " MaximumValue="100000" MinimumValue="0" 
                                    SetFocusOnError="True" style="color: #FF0000" Type="Currency" 
                                    ValidationGroup="Payment">*</asp:RangeValidator>
                            </td>
                            <td align="center" style="background-color: #f2f2f2;">

                                <span style="color: red">*</span><asp:Label ID="Label4" runat="server" Text="مبلغ الدفع (درهم)" 
                                Font-Bold="true"     ToolTip="مبلغ الدفع (درهم)"></asp:Label>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td colspan="2"><hr /></td>
                        </tr>--%>
                        <tr align="center">
                              <td colspan="1" class="style1">
                            <p>Accepted Card Types</p>
                          <img src="gentelella-master/production/images/visa.png" alt="Visa">
                          <img src="gentelella-master/production/images/mastercard.png" />
                                 </td>
                            <td colspan="1" class="style1">
                                <asp:LinkButton ID="lnkPayNow" runat="server" CssClass="btn btn-success btn-sm" 
                                    Font-Size="Medium" onclick="lnkPayNow_Click" ToolTip="المتابعة للدفع" 
                                    ValidationGroup="Payment"><i class="fa fa-money"></i> Proceed to Payment</asp:LinkButton>
                                <br />
                                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        Font-Size="Medium" ForeColor="Red" style="color: #FF0000" 
                        ValidationGroup="Payment" />
                            </td>
                             <td colspan="1" class="style1">
                            <p>أنواع البطاقات المقبولة</p>
                          <img src="gentelella-master/production/images/visa.png" alt="Visa">
                          <img src="gentelella-master/production/images/mastercard.png" />
                                 </td>
                        </tr>
                       
                         
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <br />
                    <br />
                    <br />
                </asp:View>
            </asp:MultiView>                
           
        </div>
    </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                   
    </asp:Content>