<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_SAR_SCDA_FRM_005.aspx.cs" Inherits="SIS_Student.ECT_SAR_SCDA_FRM_005" MasterPageFile="~/Student.Master"%>

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
                                        <th style="text-align: left; padding-left: 10px">Issue: 31/01/2018</th>
                                        <th style="text-align: right;">Revision Date: </th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-SAR-SCDA-FRM.005</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Alumni Data Update Form<br />
                                            نموذج تحديث بيانات الخريجين
                                            </p>
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
                                            <b>Date of Birth</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_DOB" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>تاريخ الولادة</b>
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
                                            <b>Graduation Semester</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_GraduationSemester" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>فصل التخرج</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Graduation Year</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_GraduationYear" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>سنة التخرج</b>
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
                                            <b>التخصص الحالي</b>
                                        </td>
                                    </tr>
                                           <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Address</b>
                                        </td>
                                        <td align="center">
                                             <asp:TextBox ID="txt_Address" runat="server" TextMode="MultiLine" Height="100px" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>عنوان المنزل</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Student Contact #1<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">                                           
                                              <asp:TextBox ID="txt_StudentContact1" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Contact Number Required" ControlToValidate="txt_StudentContact1" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>رقم الموبايل</b>
                                        </td>
                                    </tr>
                                        <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Student Contact #2</b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_StudentContact2" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>رقم الموبايل</b>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Email<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Email" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Email Address Required" ControlToValidate="txt_Email" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Email"
                                                ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                Display="Dynamic" ErrorMessage="*Invalid Email Address" ValidationGroup="no" />
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>عنوان البريد الالكترونى</b>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Work Place</b>
                                        </td>
                                        <td align="center">
                                             <asp:TextBox ID="txt_WorkPlace" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>مكان العمل</b>
                                        </td>
                                    </tr>
                                        <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Job Title</b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_JobTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>عنوان وظيفي</b>
                                        </td>
                                    </tr>
                                       <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Direct Supervisor Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_DirSupName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اسم المشرف المباشر</b>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Direct Supervisor Job Title</b>
                                        </td>
                                        <td align="center">
                                             <asp:TextBox ID="txt_DirSupJobtitle" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>المسمى الوظيفي للمشرف المباشر</b>
                                        </td>
                                    </tr>
                                        <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Contact Details</b>
                                        </td>
                                        <td align="center">
                                             <asp:TextBox ID="txt_ContactDetails" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>معلومات للتواصل</b>
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
                                               <asp:ListItem Text="&nbsp;&nbsp;Business Etiquette" Value="Business Etiquette"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Career Development Stages" Value="Career Development Stages"></asp:ListItem>
                                                  <asp:ListItem Text="&nbsp;&nbsp;Others (Please specify in remarks)" Value="Others"></asp:ListItem>
                                           </asp:CheckBoxList> 
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>أنشطة التطوير الوظيفي (ورشة عمل / ندوة)</b>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Other Activities</b>
                                        </td>
                                        <td align="center">
                                             <asp:CheckBoxList ID="chk_OtherActivities" runat="server">
                                               <asp:ListItem Text="&nbsp;&nbsp;Sports" Value="Sports"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Cultural" Value="Cultural"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Community" Value="Community"></asp:ListItem>
                                                   <asp:ListItem Text="&nbsp;&nbsp;Volunteering" Value="Volunteering"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Mentoring Students" Value="Mentoring Students"></asp:ListItem>                                               
                                           </asp:CheckBoxList> 
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>نشاطات أخرى</b>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
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
                                            <b>Other Suggestion for Alumni services & Activities</b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Remarks" runat="server" TextMode="MultiLine" placeholder="Enter Remarks / أدخل الملاحظات" Height="100px" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اقتراحات أخرى لخدمات وأنشطة الخريجين</b>
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
</asp:Content>
