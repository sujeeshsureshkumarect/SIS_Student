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
                   .details td {
                        width: 25%;
                    }
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
                                                        <td align="center" style="border: 1px solid #e5e5e5"><span class="badge badge-success" style="font-size:100%"><%#Eval("dFrom") %></span></td>
                                                        <td align="center" style="border: 1px solid #e5e5e5"><span class="badge badge-success" style="font-size:100%"><%#Eval("dTo") %></span></td>
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
                                            <br />
                                            <hr />
                                            <br />
                                            <div id="notes">
                                                           <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td style="background-color: #f2f2f2;">
                                            <p style="text-align: left; font-size: 16px; font-weight: bold;">
                                                <u>Important Notes:</u></p>
                                        </td>
                                        <td style="background-color: #f2f2f2;">
                                             <p style="text-align: right; font-size: 16px; font-weight: bold;direction: rtl;">
                                                <u>ملحظات هامة:</u></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ul style="text-align: left;">
                                                <li>Taking attendance will be from the first day of the semester.</li>
                                                <li>Attendance warning will be issued for the students after:-
                                                    <ol>1. Being absent for 10% of the semester's total days (First Warning).</ol>
                                                     <ol>2. Being absent for 20% of the semester's total days (Second Warning).</ol>
                                                    <ol>3. Being absent for 30% of the semester's total days (Third Warning).</ol>
                                                </li>
                                                <li>Afetr getting the third warning,the student will be forced to withdraw from the course without refund of the fees.</li>
                                                <li>Students should provide a documented excuse not more than three days after being absent.</li>
                                     <br />                                                
                                                <li>Drop and add period: Two weeks from the first day of the regular semester and one week from the first day of the summer semester</li>
                                                <li>Fees are not refundable after drop/add period for whatever reason.</li>
                                                <li> Fees are not refundable if the student has been dismissed because of poor academic performance or misconduct during anytime in the semester</li>
                                            </ul>
                                        </td>
                                        <td>
                                             <ul style="text-align: right; direction: rtl;font-size:13px;">
                                                <li> يتم حساب الغياب من اليوم الول لبدأ الدراسة</li>
                                                <li>تكرار الغياب يؤدي للحصول على النذار أو الحرمان من المادة في حال تجاوز نسبة الغياب 30.
                                                    <ol>1.يستحق الطالب / الطالبة النذار الول في حال تجاوز نسبة الغياب 10 %من مجمل اليام الدراسية للفصل الدراسي.</ol>
                                                    <ol>2.يستحق الطالب / الطالبة النذار الثاني في حال تجاوز نسبة الغياب 20 %من مجمل اليام الدراسية للفصل الدراسي.
                                                    </ol>
                                                    <ol>
                                                        3.يستحق الطالب / الطالبة النذار الثالث في حال تجاوز نسبة الغياب 30 %من مجمل اليام الدراسية للفصل الدراسي.
                                                    </ol>
                                                </li>
                                                <li> بعد الحصول على النذار الثالث يسحب المساق إجباريا دون استرداد الرسوم المدفوعة.</li>
                                                <li> على الطالب تزويد قسم شؤون الطلبة بعذر الغياب موقع حسب الصول في مدة أقصاها ثلثة أيام.</li>
                                                 <br />

                                                 <li>
                                                      فترة السحب والضافة : أسبوعان من بداية الفصول الدراسية الول والثاني
 وأسبوع واحد فقط من بداية الفصل الصيفي .
                                                 </li>
                                                 <li>
                                                     ل يمكن استرداد اي نوع من الرسوم بعد انتهاء فترة السحب والضافة مهما كانت السباب .
                                                 </li>
                                                 <li>
                                                     ل يحق للطالب استرداد اية رسوم في حالة الفصل من الكلية بسبب ضعف الداء الكاديمي
 او سوء السلوك في اي وقت خلل الفصل الدراسي .
                                                 </li>
                                                
                                            </ul>
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
    </asp:Content>