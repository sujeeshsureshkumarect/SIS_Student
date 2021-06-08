<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_SAR_SCDA_FRM_003.aspx.cs" Inherits="SIS_Student.ECT_SAR_SCDA_FRM_003" MasterPageFile="~/Student.Master"%>

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
                <style>
                    .details {
                        /* font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
                        border-collapse: collapse;
                        width: 100%;
                    }

                    td {
                        width: 25%;
                    }

                    .details td, .details th {
                        border: 1px solid #ddd;
                        padding: 5px;
                    }

                    /*#details tr:nth-child(even){background-color: #f2f2f2;}

#details tr:hover {background-color: #ddd;}*/

                    .details th {
                        padding-top: 12px;
                        padding-bottom: 12px;
                        text-align: left;
                        background-color: #4CAF50;
                        color: white;
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
                            <div id="form" align="center">

                                <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">

                                    <div class="alert alert-success alert-dismissible " role="alert" runat="server" id="div_Alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Request Generated Successfully" Visible="false" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>

                                <table style="width: 100%">
                                    <tr>
                                        <th style="text-align: left; padding-left: 10px">Issue: 09/12/2013</th>
                                        <th style="text-align: right;">Revision Date: 31/01/2018</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-SAR-SCDA-FRM.003</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                          <%--  <p style="text-align: center; font-size: 23px; font-weight: bold;">Career Service Request<br />
                                           طلب خدمة الدعم المهني
                                            </p>--%>
                                            <asp:Label ID="lbl_En" runat="server" Style="display: block; margin: 0 auto; text-align: center !important; font-size: 23px; font-weight: bold;"></asp:Label>
                                            <asp:Label ID="lbl_Ar" runat="server" Style="display: block; margin: 0 auto; text-align: center !important; font-size: 23px; font-weight: bold; direction: rtl;"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service ID</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceID" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceNameEn" runat="server" Style="text-transform: capitalize;" />
                                            <br />
                                            <asp:Label ID="lbl_ServiceNameAr" runat="server" Style="font-size: 13px; font-weight: bold">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Academic Year</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_AcademicYear" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Current Semester</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Semester" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Student Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_StudentName" runat="server" Text="Student Name"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اسم الطالب</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Student ID #</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_StudentID" runat="server" Text="Student ID"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>الرقم الجامعي</b>
                                        </td>
                                    </tr>       
                                       <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Major</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Major" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>التخصص الحالي </b>
                                        </td>
                                    </tr>                                          
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Student Contact #</b>
                                        </td>
                                        <td align="center">                                                                                        
                                            <asp:Label ID="lbl_StudentContact" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>رقم الموبايل</b>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Student Email</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_StudentEmail" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>البريد الإلكتروني للطالب</b>
                                        </td>
                                    </tr>
                      
                 
                             
                                  
                                
                                       <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Career Development Activities (Workshop/Seminar)</b>
                                        </td>
                                        <td align="center">
                                              <asp:CheckBoxList ID="chk_CareerActivities" runat="server">
                                               <asp:ListItem Text="&nbsp;&nbsp;Career Orientation" Value="Career Orientation"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;CV Writing" Value="CV Writing"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Job Search Techniques" Value="Job Search Techniques"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Interviewing" Value="Interviewing"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Beyond the Interview" Value="Beyond the Interview"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Business Etiquette" Value="Business Etiquette"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Career Development Stages" Value="Career Development Stages"></asp:ListItem>
                                                  <asp:ListItem Text="&nbsp;&nbsp;Others (Please specify in Comments)" Value="Others"></asp:ListItem>
                                           </asp:CheckBoxList> 
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>أنشطة التطوير الوظيفي (ورشة عمل / ندوة)</b>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Career Service</b>
                                        </td>
                                        <td align="center">
                                             <asp:CheckBoxList ID="chk_OtherActivities" runat="server">
                                               <asp:ListItem Text="&nbsp;&nbsp;Career Interest Assessment" Value="Career Interest Assessment"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Career Advising" Value="Career Advising"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Job Search Assistance" Value="Job Search Assistance"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Mock Interview" Value="Mock Interview"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Summer Training" Value="Summer Training"></asp:ListItem>   
                                                 <asp:ListItem Text="&nbsp;&nbsp;Non Academic Internship" Value="Non Academic Internship"></asp:ListItem>
                                                  <asp:ListItem Text="&nbsp;&nbsp;Others (Please specify in Comments)" Value="Others"></asp:ListItem>
                                           </asp:CheckBoxList> 
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>نشاطات أخرى</b>
                                        </td>
                                    </tr>
                                         <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Comments</b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Comments" runat="server" TextMode="MultiLine" placeholder="Enter Comments / أدخل الملاحظات" Height="100px" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>تعليقات</b>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                           <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Preferred Timing<span style="color: red">*</span></b>
                                        </td>
                                       <td >
                                            <asp:Label ID="Label1" runat="server" Text="From" ></asp:Label>
                                            <asp:TextBox ID="txt_From" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Time Required" ControlToValidate="txt_From" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                            <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                                            <asp:TextBox ID="txt_To" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Time Required" ControlToValidate="txt_To" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>                                          
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>التوقيت المفضل</b>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Preferred Day(s) </b>
                                        </td>
                                        <td align="center">
                                             <asp:CheckBoxList ID="chk_PreferedDays" runat="server">
                                               <asp:ListItem Text="&nbsp;&nbsp;Sunday" Value="Sunday"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Monday" Value="Monday"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Tuesday" Value="Tuesday"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Wednesday" Value="Wednesday"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Thursday" Value="Thursday"></asp:ListItem>   
                                                 <asp:ListItem Text="&nbsp;&nbsp;Friday" Value="Friday"></asp:ListItem>
                                                  <asp:ListItem Text="&nbsp;&nbsp;Saturday" Value="Saturday"></asp:ListItem>
                                           </asp:CheckBoxList> 
                                             <asp:CustomValidator ID="CustomValidator1" ErrorMessage="*Please select at least one Day."
    ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" Display="Dynamic" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اليوم المفضلة</b>
                                        </td>
                                    </tr>
                                    <tr id="tdlanguage" runat="server">
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Language</b>
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList runat="server" ID="ddlLanguage" CssClass="form-control">
                                                <asp:ListItem Text="Arabic" Value="Arabic" Selected></asp:ListItem>
                                                <asp:ListItem Text="English" Value="English" ></asp:ListItem>                                                
                                            </asp:DropDownList>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اللغة</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Fees</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Fess" runat="server" Text="AED 0.00"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>الرسوم</b>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Suggest a Workshop/Seminar/ Other Services</b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Remarks" runat="server" TextMode="MultiLine"  Height="100px" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اقتراح ورشة / ندوة / خدمات أخرى</b>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Proof of Payment<span style="color: red">*</span></b><br />
                                           
                                        </td>
                                        <td align="center">
                                            <asp:FileUpload ID="flp_Upload" runat="server"/>
                                            <br /> <small style="color:red;">(Only .pdf, .jpg and .png files are allowed / يُسمح فقط بملفات pdf و jpg و png)</small>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Document Required (.pdf/.jpg/.png)" ControlToValidate="flp_Upload" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                          
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>إثبات دفع</b><br />                                            
                                        </td>
                                    </tr>--%>
                                </table>
                                <asp:HiddenField ID="hdf_Price" runat="server" Visible="false"/>
                                 <asp:HiddenField ID="hdf_StudentEmail" runat="server" Visible="false"/>
                                <br />
                                <asp:LinkButton ID="lnk_Generate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="lnk_Generate_Click"><i class="fa fa-send"> </i> Generate Request</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            <script type="text/javascript">
        function ValidateCheckBoxList(sender, args) {
            var checkBoxList = document.getElementById("<%=chk_PreferedDays.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
            </script>
</asp:Content>
