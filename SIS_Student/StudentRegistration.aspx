<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="SIS_Student.StudentRegistration" MasterPageFile="~/Student.Master" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
    $(document).ready(function(){
    $("#divConfirmation").hide();
    });
    function DropConfirm() {
            var b = confirm('Are you sure ?');
            return b;
    }
     </script>
    <style type="text/css">
        
        #divReg
        {
            text-align: center;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
        #divDetail
        {
            width: 100%;
        }
        .viewdiv
        {
            width:100%;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
       
               
        #divConfirmation
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size:small;
        	background-color: #F2B702;
        	margin: 3px;
            padding: 3px;
            -moz-border-radius: 5px;  
            -webkit-border-radius: 5px;  
            -khtml-border-radius: 5px;  
        }
        .error
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size:small;
        	background-color: #fff;
        	border: 2px solid red;
        	color: red;
        }
/*          TABLE TH {
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
    font-size: small;
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
    font-size: small;
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
    font-size: small;
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
    font-size: small;
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
    font-size: small;
}*/
  .WSideBar {
    padding: 10px;
    width: 20%;
    height: 100%;
    border-right: white thin solid;
    border-top: white thin solid;
    font-weight: normal;
    vertical-align: top;
    text-transform: capitalize;
    border-left: white thin solid;
    color: #ECF0F1;
    border-bottom: white thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2a3f54;
    text-align: left;
    line-height: 2;
    font-size: 13px;
    border-color: #C0C0C0;
} 
        </style>

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
                                      #ContentPlaceHolder1_Student_Info td, th {
  border: 1px solid #dddddd;
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
                                            <h2><i class="fa fa-user"></i> Register Online</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
                                            
                                            <div id="divReg" runat="server">
        <div runat="server" align="center">
            <div id="divDetail" runat="server" >
            </div>             
            <asp:Wizard ID="Wizard1" runat="server" BackColor="#EFF3FB" 
                BorderColor="#B5C7DE" BorderWidth="1px"  Font-Size="0.8em" 
                Height="100%" Width="100%" ActiveStepIndex="0" 
                            onactivestepchanged="Wizard1_ActiveStepChanged">
                <StepStyle Font-Size="0.8em" ForeColor="#333333" HorizontalAlign="Left" 
                    VerticalAlign="Top"/>
                <WizardSteps>
                    <asp:WizardStep ID="WizardStep1" runat="server" title="Terms &amp; Conditions" >
                        <table width="100%" align="right">
                            <tr>
                                <th colspan="2" class="th">
                                    Terms &amp; Conditions</th>
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;</td>
                                <td align="right">
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;" >
                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-size: small" 
                                        Text="Attendance follow-up will be from the first day of the semester." 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-family: Arial" Text="متابعة الحضور والغياب يبدأ مع بداية الفصل الدراسي" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-size: small" 
                                    
                                        Text="Attendance warning will be issued for the students after the following" 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="سوف يتم انشاء انذارات الحضور و الغياب بناءً على التالي" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label13" runat="server" Font-Bold="False" Font-Size="Small" 
                                        Text="Being absent for 10% of the semester's total days (First Warning)" 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label12" runat="server" Font-Bold="False" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="يتم اصدار الانذار الاول عند وصول الغياب الى 10% من مجموع محاضرات الفصل الدراسي" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label15" runat="server" Font-Bold="False" Font-Size="Small" 
                                        Text="Being absent for 20%of the semester's total days (Second Warning)" 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label14" runat="server" Font-Bold="False" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="يتم اصدار الانذار الثاني عند وصول الغياب الى 20% من مجموع محاضرات الفصل الدراسي" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label17" runat="server" Font-Bold="False" Font-Size="Small" 
                                        Text="Being absent for 30% of the semester's total days (Third Warning)." 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label16" runat="server" Font-Bold="False" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="يتم اصدار الانذار الثالث عند وصول الغياب الى 30% من مجموع محاضرات الفصل الدراسي" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label27" runat="server" Font-Bold="False" Font-Size="Small" 
                                        Text="After getting The Third warning, the student will be forced to withdraw from the course without refund of the fees" 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label18" runat="server" Font-Bold="False" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="بعد الحصول على الانذار الثالث سوف يكون هناك سحب اجباري للمساق وذلك بدون ارجاع الرسوم" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    &nbsp;</td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-size: small" 
                                        Text="Students should provide a documented excuse not more than three days after being absent." 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="على الطالب ابراز حجة الغياب قبل مرور ثلاثة ايام على الغياب" Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-size: small" 
                                        Text="Drop and add period : Two weeks from the first day of the regular" 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="فترة السحب و الاضافة : اسبوعان من بداية الفصول الدراسية الاول و الثاني" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-size: small" 
                                        Text="and one week from the first day of the summer semester" Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-family: Arial" Text="واسبوع واحد فقط من بداية الفصل الصيفي" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-size: small" 
                                        Text="Fees is non refundable after drop/add period for whatever reason." 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        style="font-family: Arial" 
                                        Text="حيث لا يمكن استرداد اي نوع من الرسوم بعد انتهاء فترة السحب والاضافة مهما كانت الاسباب" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="#CC3300" style="font-size: small" 
                                        Text="If books are not requested/picked up within 4 weeks after the semester’s Add/Drop period, books fees become non-refundable" 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="#CC3300" style="font-family: Arial" 
                                        Text="إذا الطالب لم يطلب الكتب خلال الأربع الأسابيع الأولى بعد فترة السحب و الإضافة, تصبح رسوم الكتب غير مستردة" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="#CC3300" style="font-size: small" 
                                        Text="After semester’s Add/Drop period, any financial balance on the student’s account becomes required and obligated on the student to clear" 
                                        Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="#CC3300" style="font-family: Arial" 
                                        Text="أي مبلغ مسجل في حساب الطالب بعد فترة السحب و الإضافة يصبح مبلغ مستحق على الطالب للكلية و ملزم بدفعه" 
                                        Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    &nbsp;</td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="lblAcademicAdvisorEn" runat="server" Font-Bold="True" 
                                        Font-Size="Medium" style="font-family: Arial; color: #000000;" 
                                        Text="Your academic advisor:" Width="330px"></asp:Label>
                                </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="lblAcademicAdvisor" runat="server" Font-Bold="True" 
                                        Font-Size="Medium" style="font-family: Arial; color: #000000;" 
                                        Text="مرشدك الأكاديمي" Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                <asp:Label ID="lblAcademicAdvisorNameEn" runat="server" Font-Bold="True" 
                                    Font-Size="Medium" style="font-family: Arial; color: #000000;" Width="330px"></asp:Label>
                            </td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    <asp:Label ID="lblAcademicAdvisorNameAr" runat="server" Font-Bold="True" 
                                        Font-Size="Medium" style="font-family: Arial; color: #000000;" Width="330px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="padding: 0px 0px 0px 50px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    &nbsp;</td>
                                <td align="right" 
                                    style="padding: 0px 50px 0px 0px; font-family: Arial, Helvetica, sans-serif; margin: 0px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:TextBox ID="Read_txt" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                </td>
                                <td align="right">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    <asp:Label ID="lblVisitAcademicAdvisor" runat="server" Font-Size="X-Large" 
                                        ForeColor="#FF3300" style="font-family: Arial" 
                                        Text="الرجاء مراجعة مرشدك الأكاديمي لتدني معدلك التراكمي" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    <asp:Label ID="lblVisitAcademicAdvisorEn" runat="server" Font-Size="X-Large" 
                                        ForeColor="#FF3300" 
                                        style="font-family: Arial; color: #003399; font-size: medium;" 
                                        Text="Please visit your academic advisor because of your low GPA" 
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="2" style="text-align: center;">
                                    &nbsp;</td>
                            </tr>--%>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    <asp:CheckBox ID="Read_chk" runat="server" AutoPostBack="True" 
                                        OnCheckedChanged="Read_chk_CheckedChanged" style="font-size: large" 
                                        Text="I agree to the terms and conditions -  أوافق على الشروط" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="Read_txt" Display="Dynamic" 
                                        ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td  colspan="2" style="text-align: center;">
                                    <asp:Label ID="Label4" runat="server" Font-Size="X-Large" ForeColor="#FF3300" 
                                        style="font-family: Arial" 
                                        Text="يعتبر هذا التسجيل غير ساري المفعول مالم يتم تفعيله من قبل المحاسب." 
                                        Visible="False"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label7" runat="server" Font-Size="Large" ForeColor="#FF3300" 
                                        Text="This registration is considered inactive unless it's activated by the accountant." 
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep2" runat="server" title="Advising">
                        <table width="100%">
                            <tr>
                                <th class="th">
                                    Advising</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Advising_pnl" runat="server">
                                    </asp:Panel>
                                </td>
                            
                            </tr>
                            <tr>
                                <td align="center">
                                   <%-- <asp:ImageButton ID="Print_btn" runat="server" 
                                        ImageUrl="~/Images/Icons/Print.gif" OnClick="Print_btn_Click" 
                                        ToolTip="Print" CssClass="btCommand" />--%>
                                    <br />
                                    <asp:LinkButton ID="Print_btn" runat="server" CssClass="btn btn-success btn-sm"  OnClick="Print_btn_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print"><i class="fa fa-print"></i> Print</asp:LinkButton>                                       
                                <br />
                                <br />                                    
                                </td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep3" runat="server" Title="Registration">
                        <table width="100%">
                            <tr>
                                <th class="th">
                                    Registration</th>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%">
                                                <tr>
                                                    <th colspan="2" class="th">
                                                        Time Table</th>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 5px" width="10%">
                                                        <asp:Label ID="Label1" runat="server" Text="Session :" style="font-size: small"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Period_ddl" runat="server" DataSourceID="PeriodDS" 
                                                            DataTextField="strShiftEn" DataValueField="byteShift" AutoPostBack="True" 
                                                            Width="150px" Height="25px">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="PeriodDS" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                            SelectCommand="SELECT [byteShift], [strShiftEn] FROM [Reg_Shifts] WHERE ([intCampus] = @intCampus) ORDER BY [byteShift]">
                                                            <SelectParameters>
                                                                <asp:SessionParameter DefaultValue="0" Name="intCampus" 
                                                                    SessionField="CurrentCampus" Type="Int16" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 5px">
                                                        <asp:Label ID="Label2" runat="server" Text="Course :" style="font-size: small"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Course_ddl" runat="server" AutoPostBack="True" 
                                                            Width="150px" OnSelectedIndexChanged="Course_ddl_SelectedIndexChanged" Height="25px">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="CoursesDS" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                        
                                                            SelectCommand="SELECT strCourse, COUNT(byteClass) AS Classes FROM Reg_Available_Courses WHERE (intStudyYear = @iYear) AND (byteSemester = @iSem) AND (byteShift = @iPeriod) GROUP BY strCourse ORDER BY strCourse">
                                                            <SelectParameters>
                                                                <asp:SessionParameter DefaultValue="0" Name="iYear" 
                                                                    SessionField="CurrentYear" />
                                                                <asp:SessionParameter DefaultValue="0" Name="iSem" 
                                                                    SessionField="CurrentSemester" />
                                                                <asp:ControlParameter ControlID="Period_ddl" DefaultValue="0" Name="iPeriod" 
                                                                    PropertyName="SelectedValue" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                        <asp:Label ID="Label3" runat="server" ForeColor="#000066" 
                                                            style="font-size: small" Text="Select Courses to be Added ..."></asp:Label>
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                            DataKeyNames="intStudyYear,byteSemester,strCourse,byteClass,byteShift" 
                                                            DataSourceID="TmDS" EmptyDataText="No data to preview ,Select another course or session." 
                                                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" 
                                                            CellPadding="4" ForeColor="#333333" GridLines="None">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                                            CommandArgument='<%# Eval("byteClass") %>' CommandName="Select" Text="Add" 
                                                                            ToolTip='<%# Bind("CourseDesc") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="strCourse" HeaderText="Code" 
                                                                    SortExpression="strCourse" />
                                                                <asp:BoundField DataField="byteClass" HeaderText="Section" 
                                                                    SortExpression="byteClass" />
                                                                <asp:BoundField DataField="strLecturerDescEn" HeaderText="Lecturer" 
                                                                    SortExpression="strLecturerDescEn" />
                                                                <asp:BoundField DataField="dateTimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="From" SortExpression="dateTimeFrom" />
                                                                <asp:BoundField DataField="dateTimeTo" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="To" SortExpression="dateTimeTo" />
                                                                <asp:BoundField DataField="strDays" HeaderText="Days" ReadOnly="True" 
                                                                    SortExpression="strDays" />
                                                                <asp:BoundField DataField="strHall" HeaderText="Hall" 
                                                                    SortExpression="strHall" />
                                                                <asp:BoundField DataField="Max" HeaderText="Max" SortExpression="Max" 
                                                                    Visible="False" />
                                                                <asp:BoundField DataField="Capacity" HeaderText="Capacity" ReadOnly="True" 
                                                                    SortExpression="Capacity" Visible="False" />
                                                            </Columns>
                                                            <EditRowStyle BackColor="#F2B702" />
                                                            <EmptyDataRowStyle Font-Size="Small" ForeColor="Red" HorizontalAlign="Left" 
                                                                VerticalAlign="Middle" />
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" Font-Size="Small" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    <%--ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" --%>
                                                        
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:SqlDataSource ID="TmDS" runat="server" 
                                                            ProviderName="<%$ ConnectionStrings:ECTDataFemales.ProviderName %>" 
                                                        
                                                            SelectCommand="SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass, byteCreditHours, strLecturerDescEn, dateTimeFrom, dateTimeTo, strDays, strHall, Max, Capacity, CourseDesc FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn, CT.dateTimeFrom, CT.dateTimeTo, dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall, CONVERT (int, FLOOR((CASE WHEN H.intMaxSeats &lt; MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) * H.cSharedFactor)) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity, C.strCourseDescEn AS CourseDesc FROM Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND CT.byteShift = CC.Shift WHERE (CT.intStudyYear = @iYear) AND (CT.byteSemester = @bSem) AND (CT.strCourse = @sCourse) AND (CT.byteShift = @bShift) AND (H.iCampus = @iCampus)) AS TM WHERE (Max &gt; Capacity) AND (byteClass &lt; 100)" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>">
                                                            <SelectParameters>
                                                                <asp:SessionParameter DefaultValue="0" Name="iYear" 
                                                                    SessionField="RegYear" />
                                                                <asp:SessionParameter DefaultValue="0" Name="bSem" 
                                                                    SessionField="RegSemester" />
                                                                <asp:ControlParameter ControlID="Course_ddl" DefaultValue="0" Name="sCourse" 
                                                                    PropertyName="SelectedValue" />
                                                                <asp:ControlParameter ControlID="Period_ddl" DefaultValue="0" Name="bShift" 
                                                                    PropertyName="SelectedValue" />
                                                                <asp:SessionParameter DefaultValue="1" Name="iCampus" 
                                                                    SessionField="CurrentMajorCampus" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        &nbsp;
                                                        <asp:HiddenField ID="hdnStudentNumber" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                    
                                            <br />
                                            <hr />
                                            <div id="divConfirmation"></div>
                                            <hr />
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <th class="th">
                                                        Registered</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <asp:Label ID="Label6" runat="server" ForeColor="#000066" 
                                                            Text="Select Courses to be Dropped ..." style="font-size: small"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="Reg_grd" runat="server" AutoGenerateColumns="False" 
                                                            CellPadding="4" DataSourceID="RegDS" ForeColor="#333333" GridLines="None" 
                                                            Width="100%" EmptyDataText="No data to preview ..." 
                                                            OnSelectedIndexChanged="Reg_grd_SelectedIndexChanged"
                                                            DataKeyNames="intStudyYear,byteSemester,strCourse,byteClass,byteShift" >
                                                            <%--
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#EFF3FB" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />--%><Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                                            CommandName="Select" Text="Drop" ToolTip='<%# Bind("CourseDesc") %>' 
                                                                            onclientclick="return DropConfirm();"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="strShortcut" HeaderText="Session" 
                                                                    SortExpression="strShortcut" />
                                                                <asp:BoundField DataField="strCourse" HeaderText="Code" 
                                                                    SortExpression="strCourse" />
                                                                <asp:BoundField DataField="byteClass" HeaderText="Section" 
                                                                    SortExpression="byteClass" />
                                                                <asp:BoundField DataField="strLecturerDescEn" HeaderText="Lecturer" 
                                                                    SortExpression="strLecturerDescEn" />
                                                                <asp:BoundField DataField="dateTimeFrom" HeaderText="From" 
                                                                    SortExpression="dateTimeFrom" DataFormatString="{0:hh:mm tt}" />
                                                                <asp:BoundField DataField="dateTimeTo" HeaderText="To" 
                                                                    SortExpression="dateTimeTo" DataFormatString="{0:hh:mm tt}" />
                                                                <asp:BoundField DataField="byteDay" HeaderText="Days" 
                                                                    SortExpression="byteDay" />
                                                                <asp:BoundField DataField="strHall" HeaderText="Hall" 
                                                                    SortExpression="strHall" />
                                                            </Columns>
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <EmptyDataRowStyle Font-Size="Small" ForeColor="Red" HorizontalAlign="Left" 
                                                                VerticalAlign="Middle" />
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" Font-Size="Small" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                    
                                                        <%--ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>"--%>
                                                        <asp:SqlDataSource ID="RegDS" runat="server" 
                                                        
                                                            SelectCommand="SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, Reg_Shifts.strShortcut, CT.strCourse, CT.byteClass, Reg_Lecturers.strLecturerDescEn, CT.strHall, CT.dateTimeFrom, CT.dateTimeTo, dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS byteDay, Reg_Courses.strEquivalent, Course_Balance_View.Student, Reg_Courses.byteCreditHours, Reg_Courses.strCourseDescEn AS CourseDesc FROM Course_Balance_View INNER JOIN Reg_Courses ON Course_Balance_View.Course = Reg_Courses.strCourse INNER JOIN Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Shifts ON CT.byteShift = Reg_Shifts.byteShift INNER JOIN Reg_Lecturers ON CT.intLecturer = Reg_Lecturers.intLecturer ON Course_Balance_View.iYear = CT.intStudyYear AND Course_Balance_View.Sem = CT.byteSemester AND Course_Balance_View.Shift = CT.byteShift AND Course_Balance_View.Course = CT.strCourse AND Course_Balance_View.Class = CT.byteClass WHERE (CT.intStudyYear = @Year) AND (CT.byteSemester = @Semester) AND (Course_Balance_View.Student = @Student) ORDER BY CT.strCourse, CT.byteShift" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>">
                                                            <SelectParameters>
                                                                <asp:SessionParameter DefaultValue="0" Name="Year" 
                                                                    SessionField="RegYear" />
                                                                <asp:SessionParameter DefaultValue="0" Name="Semester" 
                                                                    SessionField="RegSemester" />
                                                                <asp:ControlParameter ControlID="hdnStudentNumber" DefaultValue="0" 
                                                                    Name="Student" PropertyName="Value" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                </td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep4" runat="server" Title="Time Table">
                        <table width="100%">
                            <tr>
                                <th class="th">
                                    Time Table</th>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="TimeTable_Grd" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                    <Columns>
                                                        <asp:BoundField DataField="sPeriod" HeaderText="Session" 
                                                            SortExpression="sPeriod" />
                                                        <asp:BoundField DataField="sCourse" HeaderText="Code" 
                                                            SortExpression="sCourse" />
                                                        <asp:BoundField DataField="sDesc" HeaderText="Course" 
                                                            SortExpression="sDesc" />
                                                        <asp:BoundField DataField="sLecturer" HeaderText="Lecturer" 
                                                            SortExpression="sLecturer" />
                                                        <asp:BoundField DataField="dFrom" HeaderText="From" SortExpression="dFrom" />
                                                        <asp:BoundField DataField="dTo" HeaderText="To" SortExpression="dTo" />
                                                        <asp:BoundField DataField="iDays" HeaderText="Days" ReadOnly="True" 
                                                            SortExpression="iDays" />
                                                        <asp:BoundField DataField="iClass" HeaderText="Section" 
                                                            SortExpression="iClass" />
                                                        <asp:BoundField DataField="sHall" HeaderText="Hall" SortExpression="sHall" />
                                                    </Columns>
                                                    <EditRowStyle BackColor="#999999" />
                                                    <EmptyDataRowStyle Font-Size="Small" ForeColor="Red" HorizontalAlign="Center" 
                                                        VerticalAlign="Middle" />
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" Font-Size="Small" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                </asp:GridView>
                                                <br />
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                              <%--  <asp:ImageButton ID="Print_TimeTable" runat="server" 
                                                    ImageUrl="~/Images/Icons/Print.gif" OnClick="Print_TimeTable_Click" 
                                                    ToolTip="Print" CssClass="btCommand" />--%>
                                                 <br />
                                    <asp:LinkButton ID="Print_TimeTable" runat="server" CssClass="btn btn-success btn-sm"  OnClick="Print_TimeTable_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print"><i class="fa fa-print"></i> Print</asp:LinkButton>                                       
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                </WizardSteps>
                <NavigationStyle Font-Bold="False" Font-Names="Arial" Font-Size="Medium" 
                    HorizontalAlign="Center" />
                <StartNextButtonStyle CssClass="bt" />
                <SideBarButtonStyle  
                    ForeColor="#ECF0F1" />
                <NavigationButtonStyle 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Medium" 
                    CssClass="bt" Font-Bold="False" />
                <SideBarStyle Font-Size="14px" VerticalAlign="Top" 
                    HorizontalAlign="Left" CssClass="WSideBar" Font-Bold="false" 
                    Wrap="False" />
                <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" 
                    BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" 
                    HorizontalAlign="Center" />
            </asp:Wizard>
            
        </div>
    </div>
<style>
    .bt{
            color: #ffffff;    
    font-family: Arial;
    font-size: Medium;
    font-weight: normal;
    background: #2a3f54;
    border: 1px solid #2a3f54;
}
    .bt:hover {
  background-color: #ffc107; /* Green */
  color: white;
}
    select{
    margin: 0;
    font-family: inherit;
    font-size: 12px;
    line-height: inherit;
}
</style>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>