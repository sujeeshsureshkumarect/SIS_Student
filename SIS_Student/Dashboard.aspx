<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SIS_Student.Dashboard" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3>Welcome To Emirates College of Technology (ECT)</h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }                                    
                                </style>
                                <%--  <div class="title_right">
                <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                      <button class="btn btn-default" type="button">Go!</button>
                    </span>
                  </div>
                </div>
              </div>--%>
                            </div>
                            <div class="clearfix"></div> 
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-home"></i> Home</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div class="col-md-4 col-sm-12">
                                                <a class="weatherwidget-io" href="https://forecast7.com/en/24d4554d38/abu-dhabi/" data-label_1="ABU DHABI" data-label_2="WEATHER" data-theme="original" data-basecolor="#2a3f54" data-textcolor="#e7e7e7">ABU DHABI WEATHER</a>
                                                <script>
                                                    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = 'https://weatherwidget.io/js/widget.min.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'weatherwidget-io-js');
                                                </script>                                                
                                            </div> 
                                            <div class="col-md-8">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>ECT Announcements</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                     
                      <li><a class="close-link"><i class="fa fa-close"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                   <div>

                        <h4>Latest News</h4>

                        <!-- end of user messages -->
                        <ul class="messages">
                          <li>
                            <img src="https://lms.ectmoodle.ae/theme/image.php/ect/theme/1595326309/favicon" class="avatar" alt="Avatar">
                            <div class="message_date">
                              <h3 class="date text-info">16</h3>
                              <p class="month">May</p>
                            </div>
                            <div class="message_wrapper">
                              <h4 class="heading">PERSONALIZED MEDICINE AND NOVEL THERAPY DATE MAY 18 2020</h4>
                              <blockquote class="message">Every person has a unique variation of the human genome. Although most of the variation between individuals has no effect on health...</blockquote>
                              <br>
                              <p class="url">
                                <span class="fs1 text-info" aria-hidden="true" data-icon=""></span>
                                <a href="#"><i class="fa fa-paperclip"></i> User Acceptance Test.doc </a>
                              </p>
                            </div>
                          </li>
                          <li>
                            <img src="https://lms.ectmoodle.ae/theme/image.php/ect/theme/1595326309/favicon" class="avatar" alt="Avatar">
                            <div class="message_date">
                              <h3 class="date text-error">9</h3>
                              <p class="month">May</p>
                            </div>
                            <div class="message_wrapper">
                              <h4 class="heading">ECT would like to express its sincere gratitude to UAE’s international Aikido coach</h4>
                              <blockquote class="message">Emirates College of Technology would like to express its sincere gratitude to UAE's international Aikido coach “Captain Dhiyab Al-Asiri” for his great performance on our digital platform...</blockquote>
                              <br>
                              <p class="url">
                                <span class="fs1" aria-hidden="true" data-icon=""></span>
                                <a href="#" data-original-title="">Download</a>
                              </p>
                            </div>
                          </li>
                          <li>
                            <img src="https://lms.ectmoodle.ae/theme/image.php/ect/theme/1595326309/favicon" class="avatar" alt="Avatar">
                            <div class="message_date">
                              <h3 class="date text-info">17</h3>
                              <p class="month">May</p>
                            </div>
                            <div class="message_wrapper">
                              <h4 class="heading">President Sabouni Weekly-Message Wk9 -17 May 2020</h4>
                              <blockquote class="message">Greetings to you all in this weekly briefing which marks the completion of two months of full successful operation in “distance working & learning”. I pray to the Almighty God that you are all doing well and in good health...</blockquote>
                              <br>
                              <p class="url">
                                <span class="fs1 text-info" aria-hidden="true" data-icon=""></span>
                                <a href="#"><i class="fa fa-paperclip"></i> User Acceptance Test.doc </a>
                              </p>
                            </div>
                          </li>
                        </ul>
                        <!-- end of user messages -->


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
    </asp:Content>