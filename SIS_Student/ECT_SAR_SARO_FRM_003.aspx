<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_SAR_SARO_FRM_003.aspx.cs" Inherits="SIS_Student.ECT_SAR_SARO_FRM_003" MasterPageFile="~/Student.Master"%>

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
                                        <th style="text-align: left; padding-left: 10px">Issue: 18/08/2011</th>
                                        <th style="text-align: right;">Revision Date: 04/08/2019</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-SAR-SARO-FRM.003</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Re-Examination Letter<br />
                                  طلب إعادة أمتحانات فصلية
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
                                            <asp:Label ID="lbl_StudentName" runat="server" Text=""></asp:Label>
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
                                            <asp:Label ID="lbl_StudentID" runat="server" Text=""></asp:Label>
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
                                            <asp:Label ID="lbl_StudentContact" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>رقم الموبايل</b>
                                        </td>
                                    </tr>                
                                </table>
                                    <hr />   
                                
                                 <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Course Title<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                           <asp:DropDownList ID="drp_Course" runat="server" CssClass="form-control" OnSelectedIndexChanged="drp_Course_SelectedIndexChanged" AutoPostBack="true" required>                                                
                                           </asp:DropDownList>
                                           
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_Course" InitialValue="---Select a Course---" ErrorMessage="*Please select a course to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>عنوان الدورة</b>
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
                                            <b>The above-mentioned student missed the<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                           <asp:DropDownList ID="drp_Missed" runat="server" CssClass="form-control">
                                           <asp:ListItem Text="---Select Any---" Value="---Select Any---" />
                                               <asp:ListItem Text="Exam" Value="Exam" />
                                               <asp:ListItem Text="Assignment" Value="Assignment" />
                                               <asp:ListItem Text="Group work in the above-mentioned course" Value="Group work in the above-mentioned course" />
                                           </asp:DropDownList>
                                             <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_Missed" InitialValue="---Select Any---" ErrorMessage="*Please select to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>لقد فات الطالب المذكور ما يلي</b>
                                        </td>
                                    </tr> 
                                                   <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Date of Absence<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_ExamDate" runat="server" TextMode="Date" CssClass="form-control" required></asp:TextBox> 
                                              <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Date Required" ControlToValidate="txt_ExamDate" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>تاريخ الغياب  </b>
                                        </td>
                                    </tr>
                                       <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Reason of his/her Absence<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList ID="drp_Reason" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="---Select Any Reason---" Value="--Select Any Reason---" />
                                                <asp:ListItem Text="Sickness and provided a medical report stamped by the Ministry of Health" Value="Sickness and provided a medical report stamped by the Ministry of Health" />
                                               <asp:ListItem Text="Death of a member of his/her family" Value="Death of a member of his/her family" />
                                               <asp:ListItem Text="Work Reasons" Value="Work Reasons" />
                                                <asp:ListItem Text="Natural causes such as heavy storms" Value="Natural causes such as heavy storms " />
                                                <asp:ListItem Text="Others (as specified in Remarks)" Value="Others (as specified in Remarks)" />
                                           </asp:DropDownList>
                                             <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_Reason" InitialValue="--Select Any Reason---" ErrorMessage="*Please select a Reason to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>سبب الغياب</b>
                                        </td>
                                    </tr> 
                                </table>
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
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
                                            <b>Remarks<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Remarks" runat="server" TextMode="MultiLine" placeholder="Kindly provide further details / يرجى تقديم مزيد من التفاصيل" Height="100px" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Remarks Required" ControlToValidate="txt_Remarks" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>ملاحظات</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Proof of Payment</b><br />
                                           
                                        </td>
                                        <td align="center">
                                            <asp:FileUpload ID="flp_Upload" runat="server"/>
                                            <br /> <small style="color:red;">(Only .pdf, .jpg and .png files are allowed / يُسمح فقط بملفات pdf و jpg و png)</small>                                            
                                           <%-- <br />
                                              <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only PDF,JPG,PNG files are allowed!" ValidationExpression="^([a-z]|[A-Z]|[0-9]|[ ]|[-]|[_]|[(0-9)+]+)+\.(jpg|JPG|JPEG|jpeg|png|PNG|pdf|PDF)$" ControlToValidate="flp_Upload" ForeColor="Red" ValidationGroup="no"></asp:RegularExpressionValidator>--%>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>إثبات دفع</b><br />                                            
                                        </td>
                                    </tr>
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