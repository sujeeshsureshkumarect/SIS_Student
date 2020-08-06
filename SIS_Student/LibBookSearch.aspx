<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibBookSearch.aspx.cs" Inherits="SIS_Student.LibBookSearch" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3>Library</h3>
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
                                            <h2><i class="fa fa-book"></i> Book Search</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div class="col=md-6">

                                            </div>
                                            <div id="divLibSearch" runat="server">
        <div id="Div1" runat="server" align="center">
            <table width="100%">
                <tr>
                    <td align="right" width="60%" valign="middle">
                                           <asp:TextBox ID="txtCriteria" runat="server" Width="250px" AutoPostBack="True" 
                            style="text-align: center"></asp:TextBox>
&nbsp;
                    </td>
                    <td align="left" width="40%" style="vertical-align: middle; text-align: left" valign="middle">
     
                        <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-success btn-sm"><i class="fa fa-search"></i> Search</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center" width="40%" colspan="2" style="width: 100%">
                        <%--<asp:ImageButton ID="imgCart" runat="server" Height="30px" ImageUrl="~/images/Icons/Cart.png" 
                            ToolTip="Show basket content" Width="30px" Visible="False" 
                            onclick="imgCart_Click" />--%>
                         <asp:LinkButton ID="imgCart" runat="server" Visible="False" CssClass="btn btn-success btn-sm"  OnClick="imgCart_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Show Basket Content"><i class="fa fa-trash"></i> Show Basket Content</asp:LinkButton>                                       
                    </td>
                </tr>
                <tr>
                    <td align="center" width="40%" colspan="2" style="width: 100%">
                        <asp:Label ID="lblResult" runat="server" Font-Bold="False" Font-Size="Small" 
                            ForeColor="Red" Text="Enter search criteria then click on search above ..."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" width="40%" colspan="2" class="style1">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </td>
                </tr>
            <%--  <tr>
                    <td align="center" colspan="2">
                        
                    </td>
                </tr>--%>
            </table>
        </div>
                                                
                                                <div id="divResult" runat="server" class="table-responsive"> 
                        </div>
                                                    </div>
    
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    <style>
        TABLE TH {
/*    border-right: white thin solid;*/
/*    border-top: white thin solid;*/
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
/*    border-left: white thin solid;*/
    color: #ffffff;
/*    border-bottom: white thin solid;*/
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2A3F54;
    text-align: center;
    line-height: 2;
    font-size: small;
    padding-right:10px;
}
        .R_NormalWhite {
    border-right: #073772 thin solid;
    border-top: #073772 thin solid;
    vertical-align: middle;
    border-left: #073772 thin solid;
    color: #000000;
    border-bottom: #073772 thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #F7F6F3;
    text-align: left;
    font-size: small;
}
        .R_NormalGray {
    border-right: #073772 thin solid;
    border-top: #073772 thin solid;
    vertical-align: middle;
    border-left: #073772 thin solid;
    color: #284775;
    border-bottom: #073772 thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: White;
    text-align: left;
    font-size: small;
}

        table.dataTable thead>tr>th.sorting_asc, table.dataTable thead>tr>th.sorting_desc, table.dataTable thead>tr>th.sorting, table.dataTable thead>tr>td.sorting_asc, table.dataTable thead>tr>td.sorting_desc, table.dataTable thead>tr>td.sorting {
    padding-right: 10px;
}
    </style>
   
    <script type="text/javascript">

        function addtobasket(accno,status) {
            if (status == 0) {
                alert('Book is not available');
            }
            else {
//                alert(accno);
                sPath = window.location.href.toString();
                sPath = sPath.substr(0, sPath.indexOf("?"));
                window.location.href = sPath + "?accno=" + accno;
            }            
        }
    </script>
    
    </asp:Content>