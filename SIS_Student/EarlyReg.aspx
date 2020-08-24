<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EarlyReg.aspx.cs" Inherits="SIS_Student.EarlyReg" MasterPageFile="~/Student.Master"%>

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
        #divTerms
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
                                            
        td, th {
 /* border: 1px solid #dddddd;*/
  /*text-align: left;*/
  padding: 9px;
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
                                           
                                             <div id="divTerms" runat="server">
        <div id="Div1" runat="server" align="center">
                        
            <table width="100%" align="center">
                <tr>
                    <th colspan="2" align="center" style="font-size:16px;">Early Registration Offer terms &amp; conditions</th>
                </tr>
                <tr>
                    <th colspan="2" align="center" 
                        style="font-family: Arial, Helvetica, sans-serif; font-size: medium">شروط وأحكام 
                        منحة التسجيل المبكر</th>
                </tr>
                <tr>
                    <td colspan="2" align="center" 
                        style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FF0000">Read the following...</td>
                </tr>
                <tr>
                    <td colspan="2" align="center" 
                        style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FF0000">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" align="center" 
                        style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #FF0000">
                        <asp:LinkButton ID="lnkProceed" runat="server" CssClass="btrn btn-success btn-sm" 
                             PostBackUrl="~/StudentRegistration.aspx"><i class="fa fa-check-square-o"></i> Proceed to Registration</asp:LinkButton>   
                        <br />&nbsp;
                    </td>
                </tr>
                <tr >
                    <td align="left" >
                        <div width="100%"
                            style="padding: 10px 0px 0px 10px; margin: 0px; border-width:1px;border-style: solid; border-color: #C0C0C0; font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: normal; font-style: normal; text-transform: capitalize; color: #000000; vertical-align: top; text-align: left; width: 100%; height: 650px;  " 
                            id="divEn" align="left" lang="en" dir="ltr">
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">Terms & Conditions</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            1.	10% additional SSFA will be offered to students as long as the current semester / previous balance is paid in full.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            2.	Students must register at least four courses in the Fall / Spring semester, and two courses in the Summer.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            3.	In case students registered additional courses during the add/drop period or before from the time of the first full payment, the student must pay the remaining balance immediately.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            4.	Students with a scholarship can get any other scholarships provided by the Emirates College of Technology if applicable.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            5.	If the student has another scholarship but has been removed due to not meeting the terms and conditions for that specific scholarship, then the remaining balance for the semester must be paid immediately.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            6.	The offer duration will be on April 19th, 2020 to April 27th, 2020.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            7.	The offer is applicable for the Faculty of Business and Media only.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            8.	The offer is valid for Summer (I) 2020 semester.</p>                            
                                                        
                        </div>
                    </td>
                    <td align="right" width="50%">
                        <div width="100%"
                            style="padding: 10px 10px 0px 0px; margin: 0px;border-width:1px; border-style: solid; border-color: #C0C0C0; font-family: 'Arabic Typesetting'; font-size: medium; font-weight: normal; font-style: normal; text-transform: capitalize; color: #000000; vertical-align: top; text-align: right; width: 100%; height: 650px;  " 
                            id="div2" align="right" lang="ar" dir="rtl">

                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif; font-size: large; font-weight: bold; text-transform: capitalize; color: #73879C; text-decoration: underline;">الشروط والاحكام</p>
                            <br />
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            1.	يسري العرض للفصل الصيفي الأول 2020 فقط.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            2.	10% خصم إضافي في حال دفع الرسوم السابقة بالإضافة إلى رسوم الفصل القادم (الصيفي الأول  2020) كاملا.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            3.	على الطالب تسجيل ما لايقل عن أربعة مواد في الفصل الأول/ الثاني ومادتين في الفصل الصيفي.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            4.	في حالة تسجيل الطالب لمواد إضافية قبل او خلال فترة السحب والإضافة، يتوجب على الطالب دفع الرصيد المتبقي للفصل الدراسي على الفور.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            5.	يمكن للطلبة الحاصلين على منحة التسجيل المبكر ,الحصول على منح دراسية أخرى مقدمة من كلية الإمارات للتكنولوجيا –إن وجدت-.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            6.	إذا كان الطالب حاصلاً على منحة دراسية أخرى ولم تحتسب لعدم استيفاء الشروط والأحكام، يتوجب على الطالب دفع الرصيد المتبقي للفصل الدراسي على الفور.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            7.	يسري العرض من تاريخ 19/04/2020 وحتى تاريخ 27/04/2020.</p>
                            <p style="font-family: Arial, Helvetica, sans-serif;  font-weight: normal; text-transform: capitalize; color: #73879C">
                            8.	يسري العرض على تخصصات كلية الأعمال وتخصصات كلية الإعلام فقط.</p>
                         </div>
                    </td>
                </tr>
                
                </table>
            
            <br />
        </div>
        <div runat="server">
            
        </div>
    </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>