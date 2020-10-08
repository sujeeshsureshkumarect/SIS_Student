<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibBookSearch.aspx.cs" Inherits="SIS_Student.LibBookSearch" MasterPageFile="~/Student.Master" %>

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
                            <div class="col-md-6">
                            </div>
                            <div id="divLibSearch" runat="server">
                                <div id="Div1" runat="server" align="center">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" width="60%" valign="middle">
                                                <asp:TextBox ID="txtCriteria" runat="server" Width="250px" AutoPostBack="True"
                                                    Style="text-align: center"></asp:TextBox>
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
                                                <asp:LinkButton ID="imgCart" runat="server" Visible="False" CssClass="btn btn-success btn-sm" OnClick="imgCart_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Show Basket Content"><i class="fa fa-trash"></i> Show Basket Content</asp:LinkButton>
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
                                <hr />
                                <div id="divResult" runat="server" class="table-responsive">



                                    <asp:Repeater ID="RepterDetails" runat="server">
                                        <HeaderTemplate>
                                            <table id='datatable' class='table table-striped table-bordered' style='width: 100%'>
                                                <thead>
                                                    <tr class='headings'>
                                                        <th>#</th>
                                                        <th>Add?</th>
                                                        <th>Accesstion No</th>
                                                        <th>Title</th>
                                                        <th>Author</th>
                                                        <th>Publisher</th>
                                                        <th>Subject</th>
                                                        <th>Edition</th>
                                                        <th>Published</th>
                                                        <th>Library</th>
                                                        <th>Status</th>
                                                        <%-- <th>Status</th>--%>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align='center'><%# Container.ItemIndex+1 %></td>
                                                <td data-toggle="tooltip" data-placement="right" data-original-title="Add to Basket">
                                                    <input id='btn<%# Container.ItemIndex+1 %>' type='button' value='Add to basket' onclick='addtobasket(<%# ((Book)Container.DataItem).AccNo %>,<%# ((Book)Container.DataItem).iStatus %>);'></input></td>
                                                <td align='center' data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).AccNo %>"><%# ((Book)Container.DataItem).AccNo %></td>
                                                <td data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Title %>"><%# ((Book)Container.DataItem).Title %></td>
                                                <td data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Author %>"><%# ((Book)Container.DataItem).Author %></td>
                                                <td data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Publisher %>"><%# ((Book)Container.DataItem).Publisher %></td>
                                                <td data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Subject %>"><%# ((Book)Container.DataItem).Subject %></td>
                                                <td data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Edition %>"><%# ((Book)Container.DataItem).Edition %></td>
                                                <td align='center' data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Published %>"><%# ((Book)Container.DataItem).Published %></td>
                                                <td data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Library %>"><%# ((Book)Container.DataItem).Library %></td>
                                                <td id="Status" data-toggle="tooltip" data-placement="right" data-original-title="<%# ((Book)Container.DataItem).Status %>"><%# ((Book)Container.DataItem).Status %></td>
                                                <%-- <td style='font-size: small'><%# ((Book)Container.DataItem).Status %></td> --%>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>  
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style>
        table.dataTable thead > tr > th.sorting_asc, table.dataTable thead > tr > th.sorting_desc, table.dataTable thead > tr > th.sorting, table.dataTable thead > tr > td.sorting_asc, table.dataTable thead > tr > td.sorting_desc, table.dataTable thead > tr > td.sorting {
            padding-right: 10px;
        }

        .table td, .table th {
            padding: .25rem;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
        }

        .badge {
            font-size: 100%;
        }
    </style>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <%--<script src="gentelella-master/vendors/datatables.net/js/jquery.dataTables.min.js"></script>--%>
    <script type="text/javascript">

        function addtobasket(accno, status) {
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

        //$(function () {
        //    $("#datatable tr").each(function (i, row) {
        //        if ($(row).children("td#Status").html() == "Available") // Any condition here
        //        {
        //            $(row).children("td#Status").html("<span class='badge badge-success'>Available</span>");
        //        }
        //        else if ($(row).children("td#Status").html() == "Borrowed") {
        //            $(row).children("td#Status").html("<span class='badge badge-danger'>Borrowed</span>");
        //        }
        //    });
        //});
    </script>
   <script>
       var table = document.getElementById("datatable");
       if (table != null) {
           for (var i = 1; i < table.rows.length; i++) {
               var appr1 = table.rows[i].cells[10].textContent;


               if (appr1 == "Available") {
                   table.rows[i].cells[10].innerHTML = '<span class="badge badge-success">Available</span>';
               }
               else if (appr1 == "Borrowed") {
                   table.rows[i].cells[10].innerHTML = '<span class="badge badge-danger">Borrowed</span>';
               }                                              
           }
       }
   </script>
</asp:Content>
