<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_SAR_SARO_FRM_004.aspx.cs" Inherits="SIS_Student.ECT_SAR_SARO_FRM_004" MasterPageFile="~/Student.Master"%>

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
                                        <th style="text-align: left; padding-left: 10px">Issue: 29/05/2014</th>
                                        <th style="text-align: right;">Revision Date: 28/01/2016</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-SAR-SARO-FRM.004</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <%--<p style="text-align: center; font-size: 23px; font-weight: bold;">Change Status Request<br />
                                  طلب تغيير حالة الطالب
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
                                            <b>Major</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_CurrentMajor" runat="server" Text=""></asp:Label>
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
                                </table>
                                    <hr />   
                                
                                 <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Student Status Request<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                           <asp:DropDownList ID="drp_StatusReuqest" runat="server" CssClass="form-control">                                                
                                            <asp:ListItem Text="---Select a Status Request---" Value="---Select a Status Request---" />
                                                <asp:ListItem Text="Withdrawn (منسحب)" Value="1" />
                                                <asp:ListItem Text="Postponed (مأجل)" Value="11" />
                                           </asp:DropDownList>
                                           
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_StatusReuqest" InitialValue="---Select a Status Request---" ErrorMessage="*Please select a Status Request to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>طلب حالة الطالب</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Main Reason<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                           <asp:DropDownList ID="drp_MainReason" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_MainReason_SelectedIndexChanged"> </asp:DropDownList>
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_MainReason" InitialValue="---Select a Main Reason---" ErrorMessage="*Please select a Main Reason to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>سبب رئيسي</b>
                                        </td>
                                    </tr> 
                                         <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Sub Reason<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                           <asp:DropDownList ID="drp_SubReason" runat="server" CssClass="form-control"> </asp:DropDownList>
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="drp_SubReason" InitialValue="---Select a Sub Reason---" ErrorMessage="*Please select a Sub Reason to continue" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>السبب الفرعي</b>
                                        </td>
                                    </tr>                                           
                                </table>
                                <hr />
                                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>How would you describe your experience in ECT?<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                CssClass="labels">
                                                <asp:ListItem Text="&nbsp;&nbsp;Excellent&nbsp;&nbsp;" Value="Excellent"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Very Good&nbsp;&nbsp;" Value="Very Good"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Good&nbsp;&nbsp;" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Satisfactory&nbsp;&nbsp;" Value="Satisfactory"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Unsatisfactory&nbsp;&nbsp;" Value="Unsatisfactory"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator runat="server" ID="genderRequired" Display="Dynamic" ForeColor="Red"
                                                ControlToValidate="RadioButtonList1" ErrorMessage="*Please select an answer" ValidationGroup="no"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>كيف تصف تجربتك مع كلية الإمارات للتكنولوجيا؟</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>How would you rate your major?<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                          <asp:RadioButtonList runat="server" ID="RadioButtonList2" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                CssClass="labels">
                                                <asp:ListItem Text="&nbsp;&nbsp;Excellent&nbsp;&nbsp;" Value="Excellent"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Very Good&nbsp;&nbsp;" Value="Very Good"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Good&nbsp;&nbsp;" Value="Good"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Satisfactory&nbsp;&nbsp;" Value="Satisfactory"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Unsatisfactory&nbsp;&nbsp;" Value="Unsatisfactory"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="Red"
                                                ControlToValidate="RadioButtonList2" ErrorMessage="*Please select an answer" ValidationGroup="no"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>كيف تقيم تخصصك؟</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Which of the following is the most satisfying aspect or your experience in ECT?<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">         
                                            <asp:RadioButtonList runat="server" ID="RadioButtonList3" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                CssClass="labels">
                                                <asp:ListItem Text="&nbsp;&nbsp;Instruction&nbsp;&nbsp;" Value="Instruction"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Preparation to work&nbsp;&nbsp;" Value="Preparation to work"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;IT services&nbsp;&nbsp;" Value="IT services"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Student Services&nbsp;&nbsp;" Value="Student Services"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Location&nbsp;&nbsp;" Value="Location"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Others&nbsp;&nbsp;" Value="Others"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="Red"
                                                ControlToValidate="RadioButtonList3" ErrorMessage="*Please select an answer" ValidationGroup="no"></asp:RequiredFieldValidator>

                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>أي مما يلي يعتبر أكثر الجوانب أو التجربة إرضاء لك في كلية الإمارات للتكنولوجيا؟</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Which of the following is the least satisfying aspect or your experience in ECT?<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                 <asp:RadioButtonList runat="server" ID="RadioButtonList4" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                CssClass="labels">
                                                <asp:ListItem Text="&nbsp;&nbsp;Instruction&nbsp;&nbsp;" Value="Instruction"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Preparation to work&nbsp;&nbsp;" Value="Preparation to work"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;IT services&nbsp;&nbsp;" Value="IT services"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Student Services&nbsp;&nbsp;" Value="Student Services"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Location&nbsp;&nbsp;" Value="Location"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;&nbsp;Others&nbsp;&nbsp;" Value="Others"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" Display="Dynamic" ForeColor="Red"
                                                ControlToValidate="RadioButtonList4" ErrorMessage="*Please select an answer" ValidationGroup="no"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>أي مما يلي هو أقل الجوانب إرضاءً أو هو تجربتك في كلية الإمارات للتكنولوجيا؟</b>
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
                                   <%-- <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Proof of Payment</b><br />
                                           
                                        </td>
                                        <td align="center">
                                            <asp:FileUpload ID="flp_Upload" runat="server"/>
                                            <br /> <small style="color:red;">(Only .pdf, .jpg and .png files are allowed / يُسمح فقط بملفات pdf و jpg و png)</small>                                                                                      
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>إثبات دفع</b><br />                                            
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