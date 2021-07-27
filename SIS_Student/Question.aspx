<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="SIS_Student.Std_Vac_Stat" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Emirates College of Technology</title>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="shortcut icon" href="images/favicon32.png" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login_v9/css/util.css">
    <link rel="stylesheet" type="text/css" href="Login_v9/css/main.css">
    <!--===============================================================================================-->
</head>
<body>

    <style>
        .wrap-login100{
            width:80% !important;
        }

        #lbl_lable1,#Label1{
            font-family: SourceSansPro-Bold;
    font-size: 16px;
    color: #4b2354;
    line-height: 1.2;
    display: block;
    width: 100%;
    
    background: transparent;
    padding: 0 20px 0 23px;
        }
    </style>
    <div class="container-login100" style="background-image: url('Login_v9/images/bg_02.jpg');">
        <div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
            <form class="login100-form validate-form" runat="server">
                <div style="text-align:center">
                     <img src="images/ECT Logo.png" style="height:auto !important;width:70%;text-align: center;">
                </div>
               
                <span class="login100-form-title p-b-37">
                </span>
               <div id="form1" runat="server">
                <div class="wrap-input100  m-b-20">
                    <asp:Label ID="lbl_lable1" runat="server" Text="هل اخذت لقاح كورونا (كوفيد 19)؟<br><br>Did you get Corona (Covid-19) vaccine? " ClientIDMode="Static" style="float:left"></asp:Label>
                    <%--<asp:Label ID="Label1" runat="server" Text="هل اخذت لقاح كورونا (كوفيد 19)؟" ClientIDMode="Static" style="direction:rtl;float:right"></asp:Label>--%>
                    <%--<asp:TextBox ID="txtUser" runat="server" name="username" placeholder="Username" CssClass="input100" required></asp:TextBox>--%>
                    <br /> <br />
                    <div style="padding: 50px 20px 0 23px">
                        
                    <asp:RadioButton ID="rdb_Yes" runat="server" Text="Yes" GroupName="r1" />
                    <asp:RadioButton ID="rdb_No" runat="server" Text="No" GroupName="r1"/>
                    </div>                                        
                </div>

                <div class="wrap-input100  m-b-25">
                    <asp:TextBox ID="txt_Comment" runat="server" name="comment" placeholder="Comments" CssClass="input100"  TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <%--<div class="wrap-input100  m-b-20">
                    <asp:TextBox ID="txt_mobile" runat="server" name="mobile" placeholder="Mobile No" CssClass="input100"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>--%>
                <div class="container-login100-form-btn">
                    <asp:Button ID="Btn_Signin" runat="server" Text="Submit" CssClass="login100-form-btn" OnClick="Btn_Signin_Click" />                    
                </div>
               </div>
                <div class="text-center">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                    

              <%--  <div class="text-center p-t-57 p-b-20">
					<span class="txt1">
						Developed by Educational Technology Services
					</span>
				</div>--%>
            </form>
        </div>
       </div>
      
    
    <style>


.navbar {
  overflow: hidden;
  background-color: #1c518f;
  position: fixed;
  bottom: 0;
  width: 70%;
  left:15%;
}

.navbar a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding: 0px 0px;
  text-decoration: none;
  font-size: 14px;
}

.navbar a:hover {
  background: #ffc107;
  color: black;
}

/*.navbar a.active {
  background-color: #4CAF50;
  color: white;
}*/


</style>
    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="Login_v9/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="Login_v9/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="Login_v9/vendor/bootstrap/js/popper.js"></script>
    <script src="Login_v9/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="Login_v9/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="Login_v9/vendor/daterangepicker/moment.min.js"></script>
    <script src="Login_v9/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="Login_v9/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="Login_v9/js/main.js"></script>

</body>
</html>