<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="SIS_Student.StudentProfile" MasterPageFile="~/Student.Master"%>

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
                                              <%--<h3>This page is under construction.</h3>    --%>  
                                            <input style="display:none" type="file" id="fileupload1" />
                                            <div class="col-lg-12 col-md-12">
<div class="card">
<div class="card-body">
<div class="mx-auto d-block">
<img class="rounded-circle mx-auto d-block" src="Handler1.ashx?f=PICM11961" alt="Card image cap" runat="server" id="profieimage">
<h5 class="text-sm-center mt-2 mb-1">Bader Nedal A.A Awad</h5>
<div class="location text-sm-center"><%--<i class="fa fa-map-marker"></i> United Arab Emirates<br />--%>
    <%--<input type="" class="button" id="btnUpload" onclick='$("#fileupload1").click()' value="Upload" />--%>
    <a id="btnUpload" onclick='$("#fileupload1").click()' title="Change Profile Photo" style="color:#20a8d8;font-weight:bold" href="#">Change Profile Photo</a><br />
    <span id="spnName"></span>
    </div>
</div>
<hr>
<div class="card-text text-sm-center">
 <div>
                                                    <h3>This page is under construction.</h3>
                                                </div>
</div>
</div>
</div>

                                               
</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#fileupload1").change(function () {
                $("#spnName").html($("#fileupload1").val().substring($("#fileupload1").val().lastIndexOf('\\') + 1));
            });
        });
    </script>
    </asp:Content>