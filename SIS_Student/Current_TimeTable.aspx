<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Current_TimeTable.aspx.cs" Inherits="SIS_Student.Current_TimeTable" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3>Courses Time Table</h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                    TABLE TH {
    border-right: white thin solid;
    border-top: white thin solid;
    font-weight: bold;
    vertical-align: middle;
    text-transform: capitalize;
    border-left: white thin solid;
    color: #ffffff;
    border-bottom: white thin solid;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #2a3f54;
    text-align: center;
    line-height: 2;
    font-size: small;
}
                                </style>  
                                
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-calendar"></i>   <asp:Label ID="lblTerm" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#73879C"></asp:Label></h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <asp:LinkButton ID="FM_lnk" runat="server" OnClick="FM_lnk_Click" CssClass="btn btn-success">Females Morning</asp:LinkButton>
                                            <asp:LinkButton ID="FE_lnk" runat="server" OnClick="FE_lnk_Click" CssClass="btn btn-success">Females Evening</asp:LinkButton>
                                            <asp:LinkButton ID="WEF_lnk" runat="server" OnClick="WEF_lnk_Click" CssClass="btn btn-success">Females Weekend</asp:LinkButton>
                                            <asp:LinkButton ID="ME_lnk" runat="server" OnClick="ME_lnk_Click" CssClass="btn btn-success">Males Evening</asp:LinkButton>
                                            <asp:LinkButton ID="WEM_lnk" runat="server" OnClick="WEM_lnk_Click" CssClass="btn btn-success">Males Weekend</asp:LinkButton>
                                            <hr />
                                            <style>
                                                .alert-info {
    background-color: #d9edf7;
    border-color: #bce8f1;
    color: #3a87ad;
}
                                            </style>
                                            <div>
                            <asp:MultiView ID="TM_mtv" runat="server">
                                <asp:View ID="ViewFM" runat="server">
                                    <div class="pull-left">
                                        <h3>Females Morning</h3> 
                                    </div>
                                    <div class="pull-right">                                  
                                        <asp:LinkButton ID="PrintFM_CMD" runat="server" CssClass="btn btn-warning btn-sm pull-right" style="margin-right: 5px;" OnClick="PrintCMD_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
                                    </div>
                                   
                                    <div id="divfm" class="viewdiv" align="center">                                         
                                        
                                        <asp:DataList ID="DataListFM" runat="server" CellPadding="4" 
                                            DataSourceID="TM_FM_DS" Font-Size="Small" ForeColor="#333333" 
                                            Width="100%">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="White" />
                                            <ItemStyle BackColor="#EFF3FB" />
                                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <ItemTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <th>
                                                            Course</th>
                                                        <th>
                                                            Session</th>
                                                        <th>
                                                            Section</th>
                                                        <th>
                                                            <asp:Label ID="byteShiftLabel" runat="server" Text='<%# Eval("byteShift") %>' 
                                                                Visible="False" />
                                                            Times</th>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="strCourseLabel" runat="server" 
                                                                Text='<%# Eval("strCourse") %>' />
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="strShortcutLabel" runat="server" 
                                                                Text='<%# Eval("strShortcut") %>' />
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="byteClassLabel" runat="server" 
                                                                Text='<%# Eval("byteClass") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                                CellPadding="4" DataSourceID="Timing_ds" Font-Size="Smaller" 
                                                                ForeColor="#333333" GridLines="None" Width="100%">
                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                                        SortExpression="Lecturer" />
                                                                    <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                    <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                                        HeaderText="From" SortExpression="TimeFrom" />
                                                                    <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}" 
                                                                        HeaderText="To" SortExpression="TimeTo" />
                                                                    <asp:TemplateField HeaderText="Sat" SortExpression="Sat">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image2" runat="server" Height="20px" 
                                                                                ImageUrl="~/Images/Icons/correct.gif" 
                                                                                Visible='<%# Convert.ToBoolean(Eval("Sat")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Sat") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image3" runat="server" Height="20px" 
                                                                                ImageUrl="~/Images/Icons/correct.gif" 
                                                                                Visible='<%# Convert.ToBoolean(Eval("Sun")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Sun") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image4" runat="server" Height="20px" 
                                                                                ImageUrl="~/Images/Icons/correct.gif" 
                                                                                Visible='<%# Convert.ToBoolean(Eval("Mon")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Mon") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image5" runat="server" Height="20px" 
                                                                                ImageUrl="~/Images/Icons/correct.gif" 
                                                                                Visible='<%# Convert.ToBoolean(Eval("Tus")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Tus") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image6" runat="server" Height="20px" 
                                                                                ImageUrl="~/Images/Icons/correct.gif" 
                                                                                Visible='<%# Convert.ToBoolean(Eval("Wed")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Wed") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image7" runat="server" Height="20px" 
                                                                                ImageUrl="~/Images/Icons/correct.gif" 
                                                                                Visible='<%# Convert.ToBoolean(Eval("Thu")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Thu") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image8" runat="server" Height="20px" 
                                                                                ImageUrl="~/Images/Icons/correct.gif" 
                                                                                Visible='<%# Convert.ToBoolean(Eval("Fri")) %>' Width="20px" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Fri") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <EditRowStyle BackColor="#999999" />
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                            </asp:GridView>
                                                            <asp:SqlDataSource ID="Timing_ds" runat="server" 
                                                                ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                                
                                                                SelectCommand="SELECT Lecturer, Hall, TimeFrom, TimeTo, Sat, Sun, Mon, Tus, Wed, Thu, Fri FROM Time_Table_Times WHERE (byteShift = @byteShift) AND (strCourse = @strCourse) AND (byteClass = @byteClass) AND (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester)" 
                                                                ProviderName="<%$ ConnectionStrings:ECTDataFemales.ProviderName %>">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="byteShiftLabel" DefaultValue="0" 
                                                                        Name="byteShift" PropertyName="Text" Type="Int16" />
                                                                    <asp:ControlParameter ControlID="strCourseLabel" DefaultValue="" 
                                                                        Name="strCourse" PropertyName="Text" Type="String" />
                                                                    <asp:ControlParameter ControlID="byteClassLabel" DefaultValue="0" 
                                                                        Name="byteClass" PropertyName="Text" Type="Int16" />
                                                                    <asp:SessionParameter DefaultValue="0" Name="intStudyYear" 
                                                                        SessionField="RegYear" />
                                                                    <asp:SessionParameter DefaultValue="0" Name="byteSemester" 
                                                                        SessionField="RegSemester" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </ItemTemplate>
                                        </asp:DataList>
                                                                                
                                    </div>
                                    
                                    
                                </asp:View>
                                <asp:View ID="ViewFE" runat="server">
                                     <div class="pull-left">
                                        <h3>Females Evening</h3> 
                                    </div>
                                    <div class="pull-right">                                  
                                        <asp:LinkButton ID="PrintFE_CMD" runat="server" CssClass="btn btn-warning btn-sm pull-right" style="margin-right: 5px;" OnClick="PrintCMD_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
                                    </div>
                                    <div id="divfe" class="viewdiv" align="center">

                                 <%--   <asp:ImageButton ID="PrintFE_CMD" runat="server" ImageUrl="~/Images/Icons/Print.gif"
                                    ToolTip="Print as PDF" onclick="PrintCMD_Click" CssClass="btCommand" />
                                    <br />--%>

                                    
                                    <asp:DataList ID="DataListFE" runat="server" CellPadding="4" 
                                        DataSourceID="TM_FE_DS" Font-Size="Small" ForeColor="#333333" 
                                        Width="100%">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingItemStyle BackColor="White" />
                                        <ItemStyle BackColor="#EFF3FB" />
                                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <ItemTemplate>
                                            <table width="100%" >
                                                <tr>
                                                    <th>
                                                        Course</th>
                                                    <th>
                                                        Session</th>
                                                    <th>
                                                        Section</th>
                                                    <th>
                                                        <asp:Label ID="byteShiftLabel" runat="server" Text='<%# Eval("byteShift") %>' 
                                                            Visible="False" />
                                                        Times</th>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="strCourseLabel" runat="server" 
                                                            Text='<%# Eval("strCourse") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="strShortcutLabel" runat="server" 
                                                            Text='<%# Eval("strShortcut") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="byteClassLabel" runat="server" 
                                                            Text='<%# Eval("byteClass") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                            CellPadding="4" DataSourceID="Timing_ds" Font-Size="Smaller" 
                                                            ForeColor="#333333" GridLines="None" Width="100%">
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                                    SortExpression="Lecturer" />
                                                                <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="From" SortExpression="TimeFrom" />
                                                                <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="To" SortExpression="TimeTo" />
                                                                <asp:TemplateField HeaderText="Sat" SortExpression="Sat">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Sat")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Sat") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Sun")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Sun") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Mon")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Mon") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Tus")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tus") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Wed")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Wed") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Thu")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Thu") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Fri")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Fri") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="Timing_ds" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                            
                                                            
                                                            SelectCommand="SELECT Lecturer, Hall, TimeFrom, TimeTo, Sat, Sun, Mon, Tus, Wed, Thu, Fri FROM Time_Table_Times WHERE (byteShift = @byteShift) AND (strCourse = @strCourse) AND (byteClass = @byteClass) AND (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="byteShiftLabel" DefaultValue="0" 
                                                                    Name="byteShift" PropertyName="Text" Type="Int16" />
                                                                <asp:ControlParameter ControlID="strCourseLabel" DefaultValue="" 
                                                                    Name="strCourse" PropertyName="Text" Type="String" />
                                                                <asp:ControlParameter ControlID="byteClassLabel" DefaultValue="0" 
                                                                    Name="byteClass" PropertyName="Text" Type="Int16" />
                                                                <asp:SessionParameter DefaultValue="0" Name="intStudyYear" 
                                                                    SessionField="RegYear" />
                                                                <asp:SessionParameter DefaultValue="0" Name="byteSemester" 
                                                                    SessionField="RegSemester" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewWEF" runat="server">
                                     <div class="pull-left">
                                        <h3>Females Weekend</h3> 
                                    </div>
                                    <div class="pull-right">                                  
                                        <asp:LinkButton ID="PrintWEF_CMD" runat="server" CssClass="btn btn-warning btn-sm pull-right" style="margin-right: 5px;" OnClick="PrintCMD_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
                                    </div>
                                    <div id="divwef" class="viewdiv" align="center">
                                        <%--<asp:ImageButton ID="PrintWEF_CMD" runat="server" ImageUrl="~/Images/Icons/Print.gif"
                                        ToolTip="Print as PDF" onclick="PrintCMD_Click" CssClass="btCommand" />--%>
                                   <%-- <br />--%>
                                    <asp:DataList ID="DataListWEF" runat="server" CellPadding="4" 
                                        DataSourceID="TM_WEF_DS" Font-Size="Small" ForeColor="#333333" 
                                        Width="100%">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingItemStyle BackColor="White" />
                                        <ItemStyle BackColor="#EFF3FB" />
                                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <ItemTemplate>
                                            <table width="100%" >
                                                <tr>
                                                    <th>
                                                        Course</th>
                                                    <th>
                                                        Session</th>
                                                    <th>
                                                        Section</th>
                                                    <th>
                                                        <asp:Label ID="byteShiftLabel" runat="server" Text='<%# Eval("byteShift") %>' 
                                                            Visible="False" />
                                                        Times</th>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="strCourseLabel" runat="server" 
                                                            Text='<%# Eval("strCourse") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="strShortcutLabel" runat="server" 
                                                            Text='<%# Eval("strShortcut") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="byteClassLabel" runat="server" 
                                                            Text='<%# Eval("byteClass") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                                            CellPadding="4" DataSourceID="Timing_ds" Font-Size="Smaller" 
                                                            ForeColor="#333333" GridLines="None" Width="100%">
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                                    SortExpression="Lecturer" />
                                                                <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="From" SortExpression="TimeFrom" />
                                                                <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="To" SortExpression="TimeTo" />
                                                                <asp:TemplateField HeaderText="Sat" SortExpression="Sat">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Sat")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Sat") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Sun")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Sun") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Mon")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Mon") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Tus")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tus") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Wed")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Wed") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Thu")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Thu") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Fri")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Fri") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="Timing_ds" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                                            
                                                            
                                                            SelectCommand="SELECT Lecturer, Hall, TimeFrom, TimeTo, Sat, Sun, Mon, Tus, Wed, Thu, Fri FROM Time_Table_Times WHERE (byteShift = @byteShift) AND (strCourse = @strCourse) AND (byteClass = @byteClass) AND (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="byteShiftLabel" DefaultValue="0" 
                                                                    Name="byteShift" PropertyName="Text" Type="Int16" />
                                                                <asp:ControlParameter ControlID="strCourseLabel" DefaultValue="" 
                                                                    Name="strCourse" PropertyName="Text" Type="String" />
                                                                <asp:ControlParameter ControlID="byteClassLabel" DefaultValue="0" 
                                                                    Name="byteClass" PropertyName="Text" Type="Int16" />
                                                                <asp:SessionParameter DefaultValue="0" Name="intStudyYear" 
                                                                    SessionField="RegYear" />
                                                                <asp:SessionParameter DefaultValue="0" Name="byteSemester" 
                                                                    SessionField="RegSemester" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewME" runat="server">
                                     <div class="pull-left">
                                        <h3>Males Evening</h3> 
                                    </div>
                                    <div class="pull-right">                                  
                                        <asp:LinkButton ID="PrintME_CMD" runat="server" CssClass="btn btn-warning btn-sm pull-right" style="margin-right: 5px;" OnClick="PrintCMD_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
                                    </div>
                                    <div id="divme" class="viewdiv" align="center">
                                        <%--<asp:ImageButton ID="PrintME_CMD" runat="server" ImageUrl="~/Images/Icons/Print.gif"                                         
                                        ToolTip="Print as PDF" onclick="PrintCMD_Click" CssClass="btCommand" />--%>
                                   <%-- <br />--%>
                                    <asp:DataList ID="DataListME" runat="server" CellPadding="4" 
                                        DataSourceID="TM_ME_DS" Font-Size="Small" ForeColor="#333333" 
                                        Width="100%">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingItemStyle BackColor="White" />
                                        <ItemStyle BackColor="#EFF3FB" />
                                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <ItemTemplate>
                                            <table width="100%" >
                                                <tr>
                                                    <th>
                                                        Course</th>
                                                    <th>
                                                        Session</th>
                                                    <th>
                                                        Section</th>
                                                    <th>
                                                        <asp:Label ID="byteShiftLabel" runat="server" Text='<%# Eval("byteShift") %>' 
                                                            Visible="False" />
                                                        Times</th>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="strCourseLabel" runat="server" Text='<%# Eval("strCourse") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="strShortcutLabel" runat="server" 
                                                            Text='<%# Eval("strShortcut") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="byteClassLabel" runat="server" Text='<%# Eval("byteClass") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                                            CellPadding="4" DataSourceID="Timing_ds" Font-Size="Smaller" 
                                                            ForeColor="#333333" GridLines="None" Width="100%">
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                                    SortExpression="Lecturer" />
                                                                <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="From" SortExpression="TimeFrom" />
                                                                <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="To" SortExpression="TimeTo" />
                                                                <asp:TemplateField HeaderText="Sat" SortExpression="Sat">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Sat")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Sat") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Sun")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Sun") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Mon")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Mon") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Tus")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tus") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Wed")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Wed") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Thu")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Thu") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Fri")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Fri") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="Timing_ds" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                            ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
                                                            
                                                            
                                                            SelectCommand="SELECT Lecturer, Hall, TimeFrom, TimeTo, Sat, Sun, Mon, Tus, Wed, Thu, Fri FROM Time_Table_Times WHERE (byteShift = @byteShift) AND (strCourse = @strCourse) AND (byteClass = @byteClass) AND (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="byteShiftLabel" DefaultValue="0" 
                                                                    Name="byteShift" PropertyName="Text" Type="Int16" />
                                                                <asp:ControlParameter ControlID="strCourseLabel" DefaultValue="" 
                                                                    Name="strCourse" PropertyName="Text" Type="String" />
                                                                <asp:ControlParameter ControlID="byteClassLabel" DefaultValue="0" 
                                                                    Name="byteClass" PropertyName="Text" Type="Int16" />
                                                                <asp:SessionParameter DefaultValue="0" Name="intStudyYear" 
                                                                    SessionField="RegYear" />
                                                                <asp:SessionParameter DefaultValue="0" Name="byteSemester" 
                                                                    SessionField="RegSemester" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewWEM" runat="server">
                                     <div class="pull-left">
                                        <h3>Males Weekend</h3> 
                                    </div>
                                    <div class="pull-right">                                  
                                        <asp:LinkButton ID="PrintWEM_CMD" runat="server" CssClass="btn btn-warning btn-sm pull-right" style="margin-right: 5px;" OnClick="PrintCMD_Click" data-toggle="tooltip" data-placement="top" title="" data-original-title="Print as PDF"><i class="fa fa-print"></i> Print as PDF</asp:LinkButton>                                       
                                    </div>
                                    <div id="divwem" class="viewdiv" align="center">

                                        <%--<asp:ImageButton ID="PrintWEM_CMD" runat="server" ImageUrl="~/Images/Icons/Print.gif"
 
                                        ToolTip="Print as PDF" onclick="PrintCMD_Click" CssClass="btCommand" />
                                    
                                    <br />--%>
                                    <asp:DataList ID="DataListWEM" runat="server" CellPadding="4" 
                                        DataSourceID="TM_WEM_DS" Font-Size="Small" ForeColor="#333333" 
                                        Width="100%" onselectedindexchanged="DataListWEM_SelectedIndexChanged">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingItemStyle BackColor="White" />
                                        <ItemStyle BackColor="#EFF3FB" />
                                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <ItemTemplate>
                                            <table width="100%" >
                                                <tr>
                                                    <th>
                                                        Course</th>
                                                    <th>
                                                        Session</th>
                                                    <th>
                                                        Section</th>
                                                    <th>
                                                        <asp:Label ID="byteShiftLabel" runat="server" Text='<%# Eval("byteShift") %>' 
                                                            Visible="False" />
                                                        Times</th>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="strCourseLabel" runat="server" Text='<%# Eval("strCourse") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="strShortcutLabel" runat="server" 
                                                            Text='<%# Eval("strShortcut") %>' />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="byteClassLabel" runat="server" Text='<%# Eval("byteClass") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                                                            CellPadding="4" DataSourceID="Timing_ds" Font-Size="Smaller" 
                                                            ForeColor="#333333" GridLines="None" Width="100%">
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" 
                                                                    SortExpression="Lecturer" />
                                                                <asp:BoundField DataField="Hall" HeaderText="Hall" SortExpression="Hall" />
                                                                <asp:BoundField DataField="TimeFrom" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="From" SortExpression="TimeFrom" />
                                                                <asp:BoundField DataField="TimeTo" DataFormatString="{0:hh:mm tt}" 
                                                                    HeaderText="To" SortExpression="TimeTo" />
                                                                <asp:TemplateField HeaderText="Sat" SortExpression="Sat"><ItemTemplate><asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif"  
                                                                            Width="20px" Visible='<%# Convert.ToBoolean(Eval("Sat")) %>' /></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Sat") %>'></asp:TextBox></EditItemTemplate></asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sun" SortExpression="Sun">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Sun")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Sun") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mon" SortExpression="Mon">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Mon")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Mon") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tus" SortExpression="Tus">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Tus")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tus") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Wed" SortExpression="Wed">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Wed")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Wed") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Thu" SortExpression="Thu">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Thu")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Thu") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fri" SortExpression="Fri">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                                            ImageUrl="~/Images/Icons/correct.gif" 
                                                                            Visible='<%# Convert.ToBoolean(Eval("Fri")) %>' Width="20px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Fri") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="Timing_ds" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                            ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
                                                            
                                                            SelectCommand="SELECT Lecturer, Hall, TimeFrom, TimeTo, Sat, Sun, Mon, Tus, Wed, Thu, Fri FROM Time_Table_Times WHERE (byteShift = @byteShift) AND (strCourse = @strCourse) AND (byteClass = @byteClass) AND (intStudyYear = @intStudyYear) AND (byteSemester = @byteSemester)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="byteShiftLabel" DefaultValue="0" 
                                                                    Name="byteShift" PropertyName="Text" Type="Int16" />
                                                                <asp:ControlParameter ControlID="strCourseLabel" DefaultValue="" 
                                                                    Name="strCourse" PropertyName="Text" Type="String" />
                                                                <asp:ControlParameter ControlID="byteClassLabel" DefaultValue="0" 
                                                                    Name="byteClass" PropertyName="Text" Type="Int16" />
                                                                <asp:SessionParameter DefaultValue="0" Name="intStudyYear" 
                                                                    SessionField="RegYear" />
                                                                <asp:SessionParameter DefaultValue="0" Name="byteSemester" 
                                                                    SessionField="RegSemester" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </div>
                                </asp:View>
                            </asp:MultiView>

                                            </div>
                                            <div id="divDetail" runat="server">
    
           
        
        <asp:SqlDataSource ID="TM_FM_DS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
            
            
            
            
            
            
            
            SelectCommand="SELECT     strCourse, byteShift, strShortcut, byteClass
FROM         (SELECT     AV.strCourse, AV.byteShift, P.strShortcut, AV.byteClass, ISNULL(CC.RegCapacity, 0) AS Capacity, CONVERT(int, 
                                              FLOOR((CASE WHEN H.intMaxSeats &lt; LCC.MaxCapacity THEN H.intMaxSeats ELSE LCC.MaxCapacity END) * H.cSharedFactor)) AS intMaxSeats
                       FROM          Reg_Available_Courses AS AV INNER JOIN
                                              Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN
                                              Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND 
                                              AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN
                                              Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN
                                              Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN
                                              Lkp_Course_Classes AS LCC ON C.byteCourseClass = LCC.byteCourseClass LEFT OUTER JOIN
                                              ClassCapacity AS CC ON AV.strCourse = CC.Course AND AV.intStudyYear = CC.iYear AND AV.byteSemester = CC.Sem AND AV.byteClass = CC.Class AND 
                                              AV.byteShift = CC.Shift
                       WHERE      (AV.intStudyYear = @Year) AND (AV.byteSemester = @Semester) AND (AV.byteShift = @iShift)) AS TM
WHERE     (intMaxSeats &gt; Capacity) AND (byteClass &lt; 100)
ORDER BY strCourse, byteShift, byteClass
" 
            onselecting="TM_FM_DS_Selecting">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="Year" SessionField="RegYear" />
                <asp:SessionParameter DefaultValue="0" Name="Semester" 
                    SessionField="RegSemester" />
                <asp:Parameter DefaultValue="1" Name="iShift" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="TM_FE_DS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
            
            
            
            
            
            
            
            SelectCommand="SELECT     strCourse, byteShift, strShortcut, byteClass
FROM         (SELECT     AV.strCourse, AV.byteShift, P.strShortcut, AV.byteClass, ISNULL(CC.RegCapacity, 0) AS Capacity, CONVERT(int, 
                                              FLOOR((CASE WHEN H.intMaxSeats &lt; LCC.MaxCapacity THEN H.intMaxSeats ELSE LCC.MaxCapacity END) * H.cSharedFactor)) AS intMaxSeats
                       FROM          Reg_Available_Courses AS AV INNER JOIN
                                              Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN
                                              Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND 
                                              AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN
                                              Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN
                                              Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN
                                              Lkp_Course_Classes AS LCC ON C.byteCourseClass = LCC.byteCourseClass LEFT OUTER JOIN
                                              ClassCapacity AS CC ON AV.strCourse = CC.Course AND AV.intStudyYear = CC.iYear AND AV.byteSemester = CC.Sem AND AV.byteClass = CC.Class AND 
                                              AV.byteShift = CC.Shift
                       WHERE      (AV.intStudyYear = @Year) AND (AV.byteSemester = @Semester) AND (AV.byteShift = @iShift)) AS TM
WHERE     (intMaxSeats &gt; Capacity) AND (byteClass &lt; 100)
ORDER BY strCourse, byteShift, byteClass
" 
            onselecting="TM_FE_DS_Selecting">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="Year" SessionField="RegYear" />
                <asp:SessionParameter DefaultValue="0" Name="Semester" 
                    SessionField="RegSemester" />
                <asp:Parameter DefaultValue="2" Name="iShift" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="TM_WEF_DS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
            
            
            
            
            
            
            
            SelectCommand="SELECT     strCourse, byteShift, strShortcut, byteClass
FROM         (SELECT     AV.strCourse, AV.byteShift, P.strShortcut, AV.byteClass, ISNULL(CC.RegCapacity, 0) AS Capacity, CONVERT(int, 
                                              FLOOR((CASE WHEN H.intMaxSeats &lt; LCC.MaxCapacity THEN H.intMaxSeats ELSE LCC.MaxCapacity END) * H.cSharedFactor)) AS intMaxSeats
                       FROM          Reg_Available_Courses AS AV INNER JOIN
                                              Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN
                                              Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND 
                                              AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN
                                              Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN
                                              Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN
                                              Lkp_Course_Classes AS LCC ON C.byteCourseClass = LCC.byteCourseClass LEFT OUTER JOIN
                                              ClassCapacity AS CC ON AV.strCourse = CC.Course AND AV.intStudyYear = CC.iYear AND AV.byteSemester = CC.Sem AND AV.byteClass = CC.Class AND 
                                              AV.byteShift = CC.Shift
                       WHERE      (AV.intStudyYear = @Year) AND (AV.byteSemester = @Semester) AND (AV.byteShift = @iShift)) AS TM
WHERE     (intMaxSeats &gt; Capacity) AND (byteClass &lt; 100)
ORDER BY strCourse, byteShift, byteClass
" 
            onselecting="TM_WEF_DS_Selecting">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="Year" SessionField="RegYear" />
                <asp:SessionParameter DefaultValue="0" Name="Semester" 
                    SessionField="RegSemester" />
                <asp:Parameter DefaultValue="9" Name="iShift" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="TM_ME_DS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
            
            
            SelectCommand="SELECT     strCourse, byteShift, strShortcut, byteClass
FROM         (SELECT     AV.strCourse, AV.byteShift, P.strShortcut, AV.byteClass, ISNULL(CC.RegCapacity, 0) AS Capacity, CONVERT(int, 
                                              FLOOR((CASE WHEN H.intMaxSeats &lt; LCC.MaxCapacity THEN H.intMaxSeats ELSE LCC.MaxCapacity END) * H.cSharedFactor)) AS intMaxSeats
                       FROM          Reg_Available_Courses AS AV INNER JOIN
                                              Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN
                                              Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND 
                                              AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN
                                              Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN
                                              Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN
                                              Lkp_Course_Classes AS LCC ON C.byteCourseClass = LCC.byteCourseClass LEFT OUTER JOIN
                                              ClassCapacity AS CC ON AV.strCourse = CC.Course AND AV.intStudyYear = CC.iYear AND AV.byteSemester = CC.Sem AND AV.byteClass = CC.Class AND 
                                              AV.byteShift = CC.Shift
                       WHERE      (AV.intStudyYear = @Year) AND (AV.byteSemester = @Semester) AND (AV.byteShift = @iShift)) AS TM
WHERE     (intMaxSeats &gt; Capacity) AND (byteClass &lt; 100)
ORDER BY strCourse, byteShift, byteClass
" 
            ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
            onselecting="TM_ME_DS_Selecting">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="Year" SessionField="RegYear" />
                <asp:SessionParameter DefaultValue="0" Name="Semester" 
                    SessionField="RegSemester" />
                <asp:Parameter DefaultValue="4" Name="iShift" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="TM_WEM_DS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
            
            
            
            
            
            
            
            SelectCommand="SELECT     strCourse, byteShift, strShortcut, byteClass
FROM         (SELECT     AV.strCourse, AV.byteShift, P.strShortcut, AV.byteClass, ISNULL(CC.RegCapacity, 0) AS Capacity, CONVERT(int, 
                                              FLOOR((CASE WHEN H.intMaxSeats &lt; LCC.MaxCapacity THEN H.intMaxSeats ELSE LCC.MaxCapacity END) * H.cSharedFactor)) AS intMaxSeats
                       FROM          Reg_Available_Courses AS AV INNER JOIN
                                              Reg_Shifts AS P ON AV.byteShift = P.byteShift INNER JOIN
                                              Reg_CourseTime_Schedule AS CT ON AV.intStudyYear = CT.intStudyYear AND AV.byteSemester = CT.byteSemester AND AV.strCourse = CT.strCourse AND 
                                              AV.byteClass = CT.byteClass AND AV.byteShift = CT.byteShift INNER JOIN
                                              Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN
                                              Reg_Courses AS C ON AV.strCourse = C.strCourse INNER JOIN
                                              Lkp_Course_Classes AS LCC ON C.byteCourseClass = LCC.byteCourseClass LEFT OUTER JOIN
                                              ClassCapacity AS CC ON AV.strCourse = CC.Course AND AV.intStudyYear = CC.iYear AND AV.byteSemester = CC.Sem AND AV.byteClass = CC.Class AND 
                                              AV.byteShift = CC.Shift
                       WHERE      (AV.intStudyYear = @Year) AND (AV.byteSemester = @Semester) AND (AV.byteShift = @iShift)) AS TM
WHERE     (intMaxSeats &gt; Capacity) AND (byteClass &lt; 100)
ORDER BY strCourse, byteShift, byteClass
" 
            onselecting="TM_WEM_DS_Selecting">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="Year" SessionField="RegYear" />
                <asp:SessionParameter DefaultValue="0" Name="Semester" 
                    SessionField="RegSemester" />
                <asp:Parameter DefaultValue="8" Name="iShift" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
    </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>