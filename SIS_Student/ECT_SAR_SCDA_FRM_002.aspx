<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_SAR_SCDA_FRM_002.aspx.cs" Inherits="SIS_Student.ECT_SAR_SCDA_FRM_002" MasterPageFile="~/Student.Master"%>

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
                                       <%-- <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>--%>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Request Generated Successfully" Visible="false" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>

                                <table style="width: 100%">
                                    <tr>
                                        <th style="text-align: left; padding-left: 10px">Issue: 07/05/2013</th>
                                        <th style="text-align: right;">Revision Date: 10/06/2015</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-SAR-SCDA-FRM.002</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Internship Letter Request<br />
                                           طلب خطاب تدريب عملي
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
                                </table>
                                <hr />                                      

                                   <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Company Name<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_CompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Company Name Required" ControlToValidate="txt_CompanyName" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>اسم الشركة</b>
                                        </td>
                                    </tr>
                                            <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Supervisor Name<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_ProjectTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Contact Person Required" ControlToValidate="txt_ProjectTitle" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>اسم المشرف على التدريب</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Supervisor Official Email<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Address" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Supervisor Official Email Required" ControlToValidate="txt_Address" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>البريد الإلكتروني للمشرف</b>
                                        </td>
                                    </tr>  
                                       <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Supervisor Contact Number<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_SupervisorContactNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Supervisor Contact Number Required" ControlToValidate="txt_Address" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>رقم الموبايل للمشرف</b>
                                        </td>
                                    </tr>    
                                          <tr style="display:none;">
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Internship Duration<span style="color: red">*</span></b>
                                        </td>
                                       <td >
                                            <asp:Label ID="Label1" runat="server" Text="From" ></asp:Label>
                                            <asp:TextBox ID="txt_From" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Date Required" ControlToValidate="txt_From" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                            <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                                            <asp:TextBox ID="txt_To" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Date Required" ControlToValidate="txt_To" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" ValidationGroup="no" ForeColor="Red"
                                                runat="server" ControlToValidate="txt_From" ControlToCompare="txt_To"
                                                Operator="LessThan" Type="Date" ErrorMessage="Start date must be less than End date." Display="Dynamic"></asp:CompareValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>وقت التدريب</b>
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
                                            <b>Request Details<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Remarks" runat="server" TextMode="MultiLine" placeholder="Enter Request Details / أدخل تفاصيل الطلب" Height="100px" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Request Details Required" ControlToValidate="txt_Remarks" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>تفاصيل الطلب</b>
                                        </td>
                                    </tr>
                                  <%--  <tr>
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