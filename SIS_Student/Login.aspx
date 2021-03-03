<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIS_Student.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Emirates College of Technology: Log in to the site</title>
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


    <div class="container-login100" style="background-image: url('Login_v9/images/bg_02.jpg');">
        <div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
            <form class="login100-form validate-form" runat="server">
                <img src="images/ECT Logo.png" style="height:100%;width:100%">
                <span class="login100-form-title p-b-37">
                </span>

                <div class="wrap-input100 validate-input m-b-20" data-validate="Enter username">
                    <asp:TextBox ID="txtUser" runat="server" name="username" placeholder="Username" CssClass="input100" required></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>

                <div class="wrap-input100 validate-input m-b-25" data-validate="Enter password">
                    <asp:TextBox ID="txtPassword" runat="server" name="pass" placeholder="Password" CssClass="input100" required TextMode="Password"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>

                <div class="container-login100-form-btn">
                    <asp:Button ID="Btn_Signin" runat="server" Text="Sign In" CssClass="login100-form-btn" OnClick="Btn_Signin_Click" />                    
                </div>
                <div class="text-center">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </div>
                    

              <%--  <div class="text-center p-t-57 p-b-20">
					<span class="txt1">
						Developed by Educational Technology Services
					</span>
				</div>--%>
            </form>
        </div>
        <div class="navbar">
            <a href="https://lms.ectmoodle.ae/login/index.php" target="_blank">E-Learning</a>
            <a href="https://ect.ac.ae/" target="_blank">ECT Website</a>
            <a href="https://ect.ac.ae/en/about-ect-2/" target="_blank">About Us</a>
            <a href="https://ect.ac.ae/en/contact-us/" target="_blank">Contact Us</a>
            <a href="Conditionss.aspx" target="_blank">Terms & Conditions</a>
            <img src="images/SSL.png" style="height:32px"/>
            <%--<img src="gentelella-master/production/images/visa.png" alt="Visa" title="Accepted Payment Methods">
            <img src="gentelella-master/production/images/mastercard.png" alt="Mastercard" title="Accepted Payment Methods">--%>
            <img src="images/1Cards.png" alt="Visa" title="Accepted Payment Methods">
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
