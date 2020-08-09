<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HostedCheckOut.aspx.cs" Inherits="SIS_Student.HostedCheckOut" MasterPageFile="~/Student.Master"%>

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
                                           
                                               <div>
        <h3>Please wait while you are redirected to the gateway you choose to make payment.</h3>
        <br />
        <script src="https://eu-gateway.mastercard.com/checkout/version/56/checkout.js"
            data-error="errorCallback"
            data-cancel="cancelCallback"
            data-complete="completeCallback"
            data-beforeRedirect="beforeRedirect"
            data-afterRedirect="afterRedirect">
        </script>

        <script src="Scripts/jquery-1.10.2.min.js"></script>

        <script type="text/javascript">

            var urlParams;
            (window.onpopstate = function () {
                var match,
                    pl = /\+/g,  // Regex for replacing addition symbol with a space
                    search = /([^&=]+)=?([^&]*)/g,
                    decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
                    query = window.location.search.substring(1);

                urlParams = {};
                while (match = search.exec(query))
                    urlParams[decode(match[1])] = decode(match[2]);
            })();

            var sessionId = (urlParams["sessionid"]);
            var successIndicator = (urlParams["successindicator"]);
            var sessionVersion = (urlParams["sessionversion"]);
            var sessionresults = (urlParams["sessionresults"]);
            var orderId = (urlParams["orderid"]);                
            var desc = (urlParams["desc"]);
            var amount = (urlParams["amount"]);
            var merchantId = 'TEST7006448';

            //var resultIndicator = null;
            //var successIndicator = null;
            //var orderId = 'AQWERT1473694521';
            //var sessionVersion = null;
            //var merchantId = 'TEST7006448';
            //var sessionId = null;
            //// This method preserves the current state of successIndicator and orderId, so they're not overwritten when we return to this page after redirect


            function SetPayment(orderId, sessionId, desc, amount, resultIndicator, result) {
                
                var request;
                if (window.XMLHttpRequest) {
                    //New browsers.
                    request = new XMLHttpRequest();
                }
                else if (window.ActiveXObject) {
                    //Old IE Browsers.
                    request = new ActiveXObject("Microsoft.XMLHTTP");
                }
                if (request != null) {
                    var url = "HostedResult.aspx/SetPayment";
                    request.open("POST", url, false);
                    var params = "{orderId: '" + orderId + "',sessionId:'" + sessionId + "',desc:'" + desc + "',amount:'" + amount + "',resultIndicator:'" + resultIndicator + "',result:'" + result + "'}";
                    request.setRequestHeader("Content-Type", "application/json");
                    request.onreadystatechange = function () {
                        if (request.readyState == 4 && request.status == 200) {
                            //alert(JSON.parse(request.responseText).d);
                        }
                    };
                    request.send(params);
                }
            }
            

            function beforeRedirect() {
                console.log("beforeRedirect");
                return {
                    successIndicator: successIndicator,
                    orderId: orderId
                };
            }
            function errorCallback(error) {
                console.log(JSON.stringify(error));
            }
            //function cancelCallback() {
            //    console.log('Payment cancelled');
            //}
            function cancelCallback() {
                console.log('Payment cancelled');
                resultIndicator = "CANCELED";
                // Reload the page to generate a new session ID - the old one is out of date as soon as the lightbox is invoked
                //window.location.reload(true);
                window.location.href = "/Balance.aspx";
            }

            // This handles the response from Hosted Checkout and redirects to the appropriate endpoint
            function completeCallback(response) {
                console.log("completeCallback", response);
                // Save the resultIndicator
                resultIndicator = response;
                var result = (resultIndicator === successIndicator) ? "SUCCESS" : "ERROR";
                SetPayment(orderId, sessionId, desc, amount, resultIndicator, result);
                //window.location.href = "/HostedResult.aspx/" + orderId + "/" + sessionId + "/" + desc + "/" + amount + "/" + resultIndicator + "/" + result;
                window.location.href = "/HostedResult.aspx";
            }

            // This method is specifically for the full payment page option. Because we leave this page and return to it, we need to preserve the
            // state of successIndicator and orderId using the beforeRedirect/afterRedirect option
            function afterRedirect(data) {
                console.log("afterRedirect", data);
                // Compare with the resultIndicator saved in the completeCallback() method
                if (resultIndicator === "CANCELED") {
                    return;
                }
                else if (resultIndicator) {
                    var result = (resultIndicator === data.successIndicator) ? "SUCCESS" : "ERROR";
                    //SetPayment(orderId, sessionId, desc, amount, resultIndicator, result);
                    ////window.location.href = "/HostedResult.aspx/" + orderId + "/" + sessionId + "/" + desc + "/" + amount + "/" + resultIndicator + "/" + result;
                    //window.location.href = "/HostedResult.aspx";
                }
                else {
                    successIndicator = data.successIndicator;
                    orderId = data.orderId;
                    sessionId = data.sessionId;
                    sessionVersion = data.sessionVersion;
                    merchantId = data.merchantId;

                    // window.location.href = "/Result/" + data.orderId + "/" + data.successIndicator + "/" + data.sessionId;
                    //SetPayment(orderId, sessionId, desc, amount, resultIndicator, result);
                    ////window.location.href = "/HostedResult.aspx/" + orderId + "/" + sessionId + "/" + desc + "/" + amount + "/" + resultIndicator + "/" + result;
                    //window.location.href = "/HostedResult.aspx";
                }

            }

            Checkout.configure({
                merchant: merchantId,
                order: {
                    amount: amount ,
                    currency: 'AED',
                    description: desc,
                    id: orderId
                },  
                session: {
                    id: sessionId
                },
                interaction: {
                    operation: 'PURCHASE', // set this field to 'PURCHASE' for Hosted Checkout to perform a Pay Operation.
                    merchant: {
                        name: 'Emirates College of Technology',
                        address: {
                            line1: 'Abu Dhabi , Najda St.',
                            line2: 'Bani yas Tower B'
                        },
                        email: 'order@yourMerchantEmailAddress.com',
                        phone: '+971 2 6266010',
                        logo: 'https://420751-1322545-raikfcquaxqncofqfm.stackpathdns.com/wp-content/uploads/2020/04/resolution-logo-ect-60.png'
                    },
                    locale: 'en_US',
                    theme: 'default',
                    displayControl: {
                        billingAddress: 'HIDE',
                        customerEmail: 'MANDATORY',
                        orderSummary: 'SHOW',
                        shipping: 'HIDE'
                    }
                }
            });

            window.onload = function () {
                Checkout.showPaymentPage();
            };
        </script>
    
      <%--  <input type="button" value="Pay with Lightbox" onclick="Checkout.showLightbox();" />--%>
        <%--<input type="button" value="Pay with Payment Page" onclick="Checkout.showPaymentPage();" />--%>


    </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>