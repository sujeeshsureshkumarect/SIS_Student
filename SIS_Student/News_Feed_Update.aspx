<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News_Feed_Update.aspx.cs" Inherits="SIS_Student.News_Feed_Update" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3><i class="fa fa-globe"></i> News Feed</h3>
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
                                            <h2><i class="fa fa-plus"></i> Update News Feed</h2>
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

                                    <div class="alert alert-success alert-dismissible " role="alert" runat="server" id="div_Alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="News Feed Updated Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-6 ">
                                                <div class="form-group row">
                                                    <label>Header *</label>                                                    
                                                    <asp:TextBox ID="txt_Header" runat="server" CssClass="form-control" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Header Required" ControlToValidate="txt_Header" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Details *</label>
                                                    <asp:TextBox ID="txt_Detail" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Details Required" ControlToValidate="txt_Detail" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                                                          <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
                $j("#txt_Date").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>
                                                <div class="form-group row">
                                                    <label>Date *</label>
                                                    <asp:TextBox ID="txt_Date" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Date Required" ControlToValidate="txt_Date" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Link</label>
                                                    <asp:TextBox ID="txt_Link" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Attachment</label>
                                                    <asp:FileUpload ID="flp_Upload" runat="server" CssClass="form-control"/>
                                                    <br />
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Font-Underline="true" ForeColor="Blue"></asp:HyperLink>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Status *</label>
                                                    <asp:DropDownList ID="drp_Status" runat="server" CssClass="form-control">
                                                         <asp:ListItem Text="Active" Value="1" Selected/>
                                                         <asp:ListItem Text="Inactive" Value="0" />
                                                    </asp:DropDownList>                                                    
                                                </div>
                                                <div class="form-group row">
                                                <asp:Button id="btn_Create" runat="server" Text="Update" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="btn_Create_Click"/>
                                                <asp:Button id="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-sm"/>
                                                    </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>