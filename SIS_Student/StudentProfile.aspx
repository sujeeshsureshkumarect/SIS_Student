<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="SIS_Student.StudentProfile" MasterPageFile="~/Student.Master" %>

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
                    .bg-primary {
    background-color: #2a3f54!important;
}
                </style>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-user"></i> My Profile</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">                           
                 
                             <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">

                                    <div class="alert alert-success alert-dismissible " role="alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Profile Updated Successfully" Visible="false" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>

                            <div class="card">  
                <div class="card-header bg-primary text-white">  
                    <h5 class="card-title">Student Information</h5>  
                </div>  
                <div class="card-body">  
                    <div class="row">  
                        <div class="col-sm-9 col-md-9 col-xs-12">  

                        

                            <div class="row">  
                                       <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Student ID</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-user"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txt_StudentID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rvfLastName" ValidationGroup="no" ControlToValidate="txtLastName" CssClass="text-danger" runat="server" ErrorMessage="Last Name is required."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div> 
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Student Name</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-user"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtFisrtName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                       <%-- <asp:RequiredFieldValidator ID="rfvFirstName" ValidationGroup="no" ControlToValidate="txtFisrtName" CssClass="text-danger" runat="server" ErrorMessage="First Name is required."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div> 
                                <asp:HiddenField ID="hdfiUnifiedID" runat="server" />
                          
                            </div> 
                        
                                        <div class="row">  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Academic Year</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-graduation-cap"></i></span>  
                                            </div>  
                                              <asp:TextBox ID="txt_AcademicYear" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>   
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvGender" ValidationGroup="no" ControlToValidate="ddlGender" InitialValue="-1" CssClass="text-danger" runat="server" ErrorMessage="Choose gender."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Current Semester</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-calendar-o"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txt_CurrentSemester" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvDateofBith" ValidationGroup="no" ControlToValidate="txtDateofBirth" CssClass="text-danger" runat="server" ErrorMessage="Choose date of birth."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                            </div> 

                            <div class="row">  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Gender</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-user"></i></span>  
                                            </div>  
                                              <asp:TextBox ID="txt_Gender" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>   
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvGender" ValidationGroup="no" ControlToValidate="ddlGender" InitialValue="-1" CssClass="text-danger" runat="server" ErrorMessage="Choose gender."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Date of Birth</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-calendar"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtDateofBirth" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvDateofBith" ValidationGroup="no" ControlToValidate="txtDateofBirth" CssClass="text-danger" runat="server" ErrorMessage="Choose date of birth."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                            </div> 
                                  <div class="row">  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Major</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-book"></i></span>  
                                            </div>  
                                              <asp:TextBox ID="txt_Major" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>   
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvGender" ValidationGroup="no" ControlToValidate="ddlGender" InitialValue="-1" CssClass="text-danger" runat="server" ErrorMessage="Choose gender."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Nationality</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-globe"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txt_Nationality" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvDateofBith" ValidationGroup="no" ControlToValidate="txtDateofBirth" CssClass="text-danger" runat="server" ErrorMessage="Choose date of birth."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                            </div>  

                           

                            <div class="row">  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Contact Number</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-phone"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvPhoneNumber" ControlToValidate="txtPhoneNumber" CssClass="text-danger" runat="server" ErrorMessage="Phone Number is required."  Display="Dynamic" ValidationGroup="no"></asp:RequiredFieldValidator>  
                                        <asp:RegularExpressionValidator ID="revPhoneNumber" ControlToValidate="txtPhoneNumber" runat="server" ErrorMessage="Please enter digit only" Display="Dynamic" ValidationExpression="^([7-9]{1})([0-9]{9})$" ValidationGroup="no" CssClass="text-danger"></asp:RegularExpressionValidator>  --%>
                                    </div>  
                                </div>  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Email</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-envelope"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true" style = "text-transform:lowercase;"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" CssClass="text-danger" runat="server" ErrorMessage="Email is required." Display="Dynamic" ValidationGroup="no"></asp:RequiredFieldValidator>  
                                        <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please enter valid email" Display="Dynamic" CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="no"></asp:RegularExpressionValidator>  --%>
                                    </div>  
                                </div>  
                            </div>  
                        </div>
                        <style>
                            .img_description {
                                position: absolute;
                                top: 0;
                                bottom: 0;
                                left: 0;
                                right: 0;
                                /*background: rgba(29, 106, 154, 0.72);*/
                                background: rgba(42, 63, 84, 0.72);
                                padding-top: 50px;
                                padding-bottom: 50px;
                                color: #fff;
                                visibility: hidden;
                                opacity: 0;
                                /* transition effect. not necessary */
                                transition: opacity .2s, visibility .2s;
                            }

                            .img_wrap:hover .img_description {
                                visibility: visible;
                                opacity: 1;
                            }

                            .img_wrap {
                                position: relative;
                                height: 190px;
                                width: 150px;
                            }
                        </style>
                        <div class="col-sm-3 col-md-3 col-xs-12" align="center">
                            <div class="img_wrap">
                                <asp:Image ID="imagePreview" runat="server" CssClass="img-thumbnail" ImageUrl="Handler1.ashx" Width="150" Height="175" ClientIDMode="Static" />
                                <p class="img_description" style="text-align: center; font-weight: bold">Click on the Below Browse Button to Change the Profile Picture.</p>
                            </div>

                            <div class="form-group">  
                                <label>Profile Picture</label>  
                                <div class="custom-file">  
                                    <asp:FileUpload ID="ProfileFileUpload" runat="server" CssClass="custom-file-input"  ToolTip="Change Profile Pictire"/>  
                                    <label class="custom-file-label"></label>  
                                </div>  
                                <asp:RequiredFieldValidator ID="rfvProfileFileUpload" ControlToValidate="ProfileFileUpload" runat="server" CssClass="text-danger" ErrorMessage="Choose image to upload" ValidationGroup="no"></asp:RequiredFieldValidator>  
                            </div>  
                            <asp:Button ID="btnSubmit" runat="server" Text="Update Profile" CssClass="btn btn-success btn-sm" OnClick="btnSubmit_Click" ValidationGroup="no"/>  
                        </div>  
                    </div>  
                  <%--  <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-info rounded-0" OnClick="btnReset_Click" />  --%>
                    
                </div>  
            </div>  
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>  
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">  
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>  
    <script type="text/javascript">  
        //Image Upload Preview  
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imagePreview').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        //Date of Birth datepicker         
    </script>  --%>
</asp:Content>
