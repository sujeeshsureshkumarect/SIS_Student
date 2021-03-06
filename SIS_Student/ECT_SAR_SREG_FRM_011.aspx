﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_SAR_SREG_FRM_011.aspx.cs" Inherits="SIS_Student.ECT_SAR_SREG_FRM_011" MasterPageFile="~/Student.Master"%>

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
                    .td1 {
                        width: 16%;
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

                                    <div class="alert alert-success alert-dismissible " role="alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Request Generated Successfully" Visible="false" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>

                                <table style="width: 100%">
                                    <tr>
                                        <th style="text-align: left; padding-left: 10px">Issue: 18/08/2011</th>
                                        <th style="text-align: right;">Revision Date: 10/06/2015</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-SAR-SREG-FRM.011</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <%--<p style="text-align: center; font-size: 23px; font-weight: bold;">Exam Proof Request<br />
                                               طلب إفادة امتحان
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
                                            <b>Student Contact #</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_StudentContact" runat="server" Text="0501234567"></asp:Label>
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
                                </table>
                                <hr />
                                <asp:Repeater ID="RepterDetails" runat="server">
                                    <HeaderTemplate>
                                        <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details" id="tblContacts">



                                            <tr>
                                                <td align="center" style="background-color: #f2f2f2; color: #73879C;"><b>✅</b></td>
                                                <td align="center" style="background-color: #f2f2f2; color: #73879C;"><b>Has an Exam in<br />
                                                    (لديه\ لديها امتحان في مادة)</b></td>
                                                <td align="center" style="background-color: #f2f2f2; color: #73879C;"><b>Course Code
                                                    <br />
                                                    (رمز المادة)</b></td>
                                                <td align="center" style="background-color: #f2f2f2; color: #73879C;"><b>Instructor’s Name
                                                    <br />
                                                    (اســم مدرس المادة)</b></td>
                                                <td align="center" style="background-color: #f2f2f2; color: #73879C;"><b>Exam Date <span style="color: red">*</span><br />
                                                    (الموافق لتاريخ)</b></td>
                                                <td align="center" style="background-color: #f2f2f2; color: #73879C;"><b>Time of Exam <span style="color: red">*</span><br />
                                                    (الساعة)</b></td>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                <asp:CheckBox ID="chk" runat="server" /></td>
                                            <td align="center">
                                                <asp:Label ID="lbl_exam" runat="server" Text='<%#Eval("Course") %>'></asp:Label></td>
                                            <td align="center">
                                                <asp:Label ID="lbl_code" runat="server" Text='<%#Eval("Code") %>'></asp:Label></td>
                                            <td align="center">
                                                <asp:Label ID="lbl_instructor" runat="server" Text='<%#Eval("strLecturerDescEn") %>'></asp:Label></td>
                                            <td align="center">
                                                <asp:TextBox ID="txt_Date" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Exam Date Required" ControlToValidate="txt_Date" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txt_Time" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*Please select at least one Course."
    ClientValidationFunction="Validate" ForeColor="Red" ValidationGroup="no" Display="Dynamic"></asp:CustomValidator>
                                <script type="text/javascript">
                                    function Validate(sender, args) {
                                        var gridView = document.getElementById("tblContacts");
                                        var checkBoxes = gridView.getElementsByTagName("input");
                                        for (var i = 0; i < checkBoxes.length; i++) {
                                            if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
                                                args.IsValid = true;
                                                return;
                                            }
                                        }
                                        args.IsValid = false;
                                    }
                                </script>

                                <hr />

                               <%-- <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Has an Exam in<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList ID="drp_Course" runat="server" CssClass="form-control" OnSelectedIndexChanged="drp_Course_SelectedIndexChanged" AutoPostBack="true" required>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="drp_Course" InitialValue="---Select a Course---" ErrorMessage="*Please select a course to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no" />
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>لديه\ لديها امتحان في مادة</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Course Code</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_CourseCode" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>رمز المادة </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Exam Date<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_ExamDate" runat="server" TextMode="Date" CssClass="form-control" required></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Exam Date Required" ControlToValidate="txt_ExamDate" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>الموافق لتاريخ  </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Time of Exam<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_ExamTime" runat="server" TextMode="Time" CssClass="form-control" required></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Exam Time Required" ControlToValidate="txt_ExamTime" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>الساعة  </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Instructor’s Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Instructor" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اســم مدرس المادة</b>
                                        </td>
                                    </tr>
                                </table>
                                <hr />--%>
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
                                            <b>Remarks</b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Remarks" runat="server" TextMode="MultiLine" placeholder="Enter Remarks / أدخل الملاحظات" Height="100px" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>ملاحظات</b>
                                        </td>
                                    </tr>
                                 <%--   <tr>
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
                                <asp:LinkButton ID="lnk_Generate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="lnk_Generate_Click"><i class="fa fa-money"> </i> Proceed to Payment</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
