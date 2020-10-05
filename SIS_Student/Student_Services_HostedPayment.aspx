<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Services_HostedPayment.aspx.cs" Inherits="SIS_Student.Student_Services_HostedPayment" MasterPageFile="~/Student.Master"%>

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
        td, th {
 /* border: 1px solid #dddddd;*/
  /*text-align: left;*/
  padding: 9px;
}                           </style>                              
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-money"></i></h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                      <div class="col-md-12">                    
    <div id="divPayment" runat="server">
        <div id="Div1" runat="server" align="center">
            <div id="divMsg" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold; color: #FF0000"></div>  
            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Larger" 
                ForeColor="Red" Text="For Testing Only (It will be available soon...)" 
                Visible="False"></asp:Label>
          
            <table width="100%" align="center">
                <%--<tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>--%>
                <tr>
                    <th align="center" style="font-size:16px">Payment (<asp:Label runat="server" ID="lbl_Service"></asp:Label>)</th>
                </tr>
               <%-- <tr align="center">
                    <td>
                        &nbsp;</td>
                </tr>--%>
                <tr  align="center">

                    <td>
                        <asp:Label ID="lblPayment" runat="server" Text="0.00" Width="20%" 
                            Font-Bold="True" Font-Size="Large" ToolTip="المبلغ الاجمالي المستحق" 
                            ForeColor="Red" align="center"></asp:Label>
                        
                    </td>
                    
                </tr>
                <%--<tr>
                    <td><hr /></td>
                </tr>--%>
                <tr align="center">
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="th" Text="Scroll down to accept the Terms &amp; Conditions to Proceed" ToolTip="إنزل للاسفل وأقبل الشروط و الأحكام"></asp:Label>
                    </td>
                </tr>
            </table>
    <div id="divTerms" runat="server">
        <div id="Div2" runat="server" align="center">
            
            
            <table width="100%" align="center">
               <%-- <tr>
                    <th colspan="2" align="center">Terms &amp; Conditions</th>
                </tr>--%>
                <tr>
                    <td align="left" colspan="2">
                        <div width="100%"
                            style="padding: 10px 0px 0px 10px; margin: 0px; border-style: solid; border-color: #C0C0C0; font-family: Arial, Helvetica, sans-serif;  font-weight: normal; font-style: normal; text-transform: capitalize; color: #73879C; vertical-align: top; text-align: left; width: 100%; height: 250px; overflow: scroll; " 
                            id="divEn" align="left" lang="en" dir="ltr">
                            <%--font-size: medium;--%>
                            <br />
                            
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Terms & Conditions</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">1. Using the online payment facilities on our website indicates that you accept these terms. If you do not accept these terms do not use our online payment facilities. All online payments are subject to these conditions.</p>

                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">2. Your payment confirmation will normally reach ECT bank account within one/two working days. ECT cannot accept any liability for delayed payments.</p>

                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">3. ECT cannot accept liability for payments being recorded on the wrong account if you supply inaccurate information, but will make every effort to reallocate any such payments if they arise.</p>

                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">4. ECT cannot accept liability if payment is refused or declined by your credit/debit card supplier for any reason.</p>

                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">5. If your card supplier declines payment, ECT is under no obligation to bring this fact to your attention. You should check with your bank/credit/debit card supplier that payment has been deducted from your account.</p>

                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">6. ECT may change these terms from time to time without notice. Changes will apply to any subsequent transactions with the ECT.</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Privacy Policy</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">1. The data that you provide during online payment transactions is securely held by ECT or our e-commerce provider and will only be used for the purpose of recording your payment and for accounting processes. Your data will be treated confidentially and with the utmost care and respect. ECT ensure that the data is used for no other purposes and is disclosed to no third party, except in respect of data that it is necessary to provide to the College’s e-commerce provider who will process this information on the College's behalf. Our e-commerce provider will retain some personal information so that ECT can access payment records in the event of queries or incomplete payment information. Any credit or debit card details given by you will not be retained in their entirety. Information will only be retained for a reasonable period and then destroyed securely.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">2. In no event will ECT be liable for any damages whatsoever arising out of the use, inability to use, or the results of use of this site, any websites linked to this site, or the materials or information contained at any or all such sites, whether based on warranty, contract, tort or any other legal theory and whether or not advised of the possibility of such damages.</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Items/Products</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">Education Tuition and Fees are all available at the college website:</p>
                            <a href="https://ect.ac.ae/en/admissions/tuition-and-other-fees-list/" 
                                target="_blank"><B>tuition and other fees</B></a>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">In addition to other student service fees available in ECT Learning Management System (LMS)</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Method of Payments/Card types accepted and currency</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">ECT accept payments online using Visa and MasterCard credit/debit card in AED.<img alt="Visa/MasterCard" src="images/Cards.png" /></p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Shipping Policy</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C"><B>Not Applicable</B></p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Refund/Return Policy</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">1. An amount of AED 3,500 Admission advance fees is not refundable.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">2. During the drop and add period the students is allowed to refund payments for registered courses.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">3. No fees to be refunded in case of registered student want to withdraw after the Drop and Add period.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">4. No fees to be refunded in case of student registered on the last registration day and applied to withdraw the next day after closing of the Add and Drop period.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">5. Registered students have to pay the full tuition fees in case they decided to withdraw or postpone after the drop and add period.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">6. No fees to be refunded after registration completed and an official letter assuring registration has been issued towards any official organization.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">7. No fees to be refunded in case of dismissal due to disciplinary issues or failure in the academic performance.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">Note: Drop and Add period starts on the beginning of each semester for duration of two weeks for the fall and winter semesters and one week for the summer semester. Refunds, if applicable, will be made to the debit/credit card used for the original transaction or by issuing a cheque under the student name. Any refunds will be made in line with the College Tuition Fees Refund Policy.</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Cancellation & Replacement Policy</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C"><B>Not Applicable</B></p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Dispute & Resolution Policy</p>
                            <br />                            
                            <p style="font-family: Arial, Helvetica, sans-serif; font-weight: normal; text-transform: capitalize; color: #73879C">Any dispute or concerns from students can report to the Accounting and Finance Management.</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Country of merchant domicile</p>
                            <br /> 
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">United Arab Emirates</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Governing Law and Jurisdiction</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">[Law governing the Merchants business, the Customer and the transactions carried out while the customer is using the Ecommerce website]</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C"><b>This website is governed by the UAE law</b></p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">FAQs</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C"><B>Not Applicable</B></p>
                            <%--<br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Check out Window</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; color: #73879C">Declaration check box “click to accept” is available in the payment check out page</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Enabling SSL</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; color: #73879C">It is mandatory the website to be enabled with SSL.</p>--%>
                            

                            
                                                        
                            </div>
                    </td>
                   <%-- <td align="right">
                        <%--<div width="0%" 
                            style="border-style: ridge; border-color: #C0C0C0; font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: normal; font-style: normal; text-transform: capitalize; color: #73879C; vertical-align: top; text-align: right; text-indent: 20px; width: 100%; height: 150px; overflow: scroll;" 
                            id="divAr" align="right" lang="en" dir="rtl">
                            </div>
                    </td>--%>
                </tr>
                
                </table>
            
            <br />
        </div>
        <div runat="server">
            <asp:CheckBox ID="chkAgree" runat="server" Font-Bold="True" Font-Size="Large" 
                            Text="I read and I agree about all the above" 
    
                            ToolTip="قرأت وموافق على الشروط والأحكام" AutoPostBack="True" OnCheckedChanged="chkAgree_CheckedChanged" />
        </div>
    </div>
            &nbsp;&nbsp;<asp:HiddenField ID="hdnSession" runat="server" />
            <asp:HiddenField ID="hdnSID" runat="server" />
            <asp:HiddenField ID="hdnName" runat="server" />
            <asp:HiddenField ID="hdnACC" runat="server" />
            <asp:HiddenField ID="hdnAmount" runat="server" />
            <asp:HiddenField ID="hdnFees" runat="server" />
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