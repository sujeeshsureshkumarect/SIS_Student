<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_SAR_SARO_FRM_011.aspx.cs" Inherits="SIS_Student.ECT_SAR_SARO_FRM_011" MasterPageFile="~/Student.Master"%>

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
                                        <th style="text-align: left; padding-left: 10px">Issue: 15/03/2014</th>
                                        <th style="text-align: right;">Revision Date: 10/06/2015</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-SAR-SARO-FRM.012</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Graduation Photos/Videos Request<br />
                                         طلب صور فيديو التخرج
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
                                            <b>Graduate’s Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_StudentName" runat="server" Text="Student Name"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>اسم الخريج</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Graduate’s ID #</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_StudentID" runat="server" Text="Student ID"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>رقم تعريف الخريج</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Graduate’s Contact #</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_StudentContact" runat="server" Text="0501234567"></asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>رقم اتصال الخريج</b>
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
                                </table>
                         
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                       <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Request Type<span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                           <asp:CheckBoxList ID="chk_Types" runat="server">
                                               <asp:ListItem Text="&nbsp;&nbsp;Photos" Value="Photos"></asp:ListItem>
                                               <asp:ListItem Text="&nbsp;&nbsp;Videos" Value="Videos"></asp:ListItem>
                                           </asp:CheckBoxList> 
                               <asp:CustomValidator ID="CustomValidator1" ErrorMessage="*Please select at least one Type."
    ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" Display="Dynamic" ValidationGroup="no"/>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>نوع الطلب</b>
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
                                            <b>لغة</b>
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
                                            <b><span style="color: red">*</span>طلب تفاصيل</b>
                                        </td>
                                    </tr>
                               <%--     <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Proof of Payment<span style="color: red">*</span></b>
                                           
                                        </td>
                                        <td align="center">
                                            <asp:FileUpload ID="flp_Upload" runat="server"/>
                                            <br /> <small style="color:red;">(Only .pdf, .jpg and .png files are allowed / يُسمح فقط بملفات pdf و jpg و png)</small>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Document Required (.pdf/.jpg/.png)" ControlToValidate="flp_Upload" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>                                           
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b><span style="color: red">*</span>إثبات دفع</b>                                           
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
        <script type="text/javascript">
        function ValidateCheckBoxList(sender, args) {
            var checkBoxList = document.getElementById("<%=chk_Types.ClientID %>");
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