<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="SIS_Student.ChangePwd" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3>Security</h3>
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
                                            <h2><i class="fa fa-key"></i> Change Password</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           <div class="col-md-4">
                                               
            
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                
                        <asp:Label ID="Label3" runat="server" Text="User Name" CssClass="Header"></asp:Label>
                    
                        <asp:TextBox ID="TxtUserName" runat="server" ReadOnly="True"  CssClass="form-control" required></asp:TextBox>
                   
                        <asp:RequiredFieldValidator ID="OldPwdRequiredFieldValidator0" runat="server" 
                            ControlToValidate="TxtUserName" Display="Dynamic" 
                            ErrorMessage="Login is required" ForeColor="Red" ValidationGroup="pwd">Login is required</asp:RequiredFieldValidator>
                       <br />
                        <asp:Label ID="Label4" runat="server" Text="Old Password" CssClass="Header"></asp:Label>
                    
                        <asp:TextBox ID="TxtOldPwd" runat="server" TextMode="Password"  CssClass="form-control" required></asp:TextBox>
                   
                        <asp:RequiredFieldValidator ID="OldPwdRequiredFieldValidator" runat="server" 
                            ControlToValidate="TxtOldPwd" Display="Dynamic" 
                            ErrorMessage="Old Password is required" ForeColor="Red" 
                            SetFocusOnError="True" ValidationGroup="pwd">Old Password is required</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label>
                   
                        <asp:TextBox ID="TxtNewPWD" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
                  
                        <asp:RequiredFieldValidator ID="NewPwdRequiredFieldValidator" runat="server" 
                            ControlToValidate="TxtNewPWD" Display="Dynamic" 
                            ErrorMessage="New Password is required" ForeColor="Red" 
                            SetFocusOnError="True" ValidationGroup="pwd">New Password is required</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Confirm Password"></asp:Label>
                  
                        <asp:TextBox ID="TxtConfirmPwd" runat="server" TextMode="Password" 
                           CssClass="form-control" required></asp:TextBox>
                   
                        <asp:CompareValidator ID="NewPwdCompareValidator" runat="server" 
                            ControlToCompare="TxtConfirmPwd" ControlToValidate="TxtNewPWD" 
                            ErrorMessage="Retype the same password" Display="Dynamic" ForeColor="Red" 
                            SetFocusOnError="True" ValidationGroup="pwd"></asp:CompareValidator>
             
                   <br />
                        <asp:LinkButton ID="LinkSave" runat="server"  onclick="ButSubmit_Click" 
                           CssClass="btn btn-success" ValidationGroup="pwd">Save</asp:LinkButton>
                    <br />
 <asp:Label ID="lblMsgs" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>

            
                 </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>