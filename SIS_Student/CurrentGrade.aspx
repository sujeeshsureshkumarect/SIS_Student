<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentGrade.aspx.cs" Inherits="SIS_Student.CurrentGrade" MasterPageFile="~/Student.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <%-- <h3>Welcome To Emirates College Of Technology (ECT)</h3>--%>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                </style>  
                                 <style type="text/css">
        #divGrades
        {
            text-align: center;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
        .viewdiv
        {
            width:100%;
            background-color: #FFF;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-file-text-o"></i> Mark Sheet</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
                                             <div id="divGrades" runat="server">
        <div runat="server" align="center">               
            <asp:MultiView ID="Grades_mtv" runat="server">
                <asp:View ID="View1" runat="server" >
                    <asp:Label ID="Females_Emptylbl" runat="server" Text="No Data to Preview ..." CssClass="NoData"></asp:Label>
                    <br />
                    <asp:DataList ID="Females_dlt" runat="server" CellPadding="4" 
                        DataKeyField="intStudyYear" DataSourceID="Grades_Females_ds" 
                        ForeColor="#333333" Width="100%">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <ItemTemplate>
                            <asp:Label ID="Year_lbl" runat="server" 
                                Text='<%# Eval("intStudyYear") %>' Visible="False" />
                            <asp:Label ID="Semester_lbl" runat="server" Text='<%# Eval("byteSemester") %>' 
                                Visible="False" />
                            <asp:Label ID="Number_lbl" runat="server" 
                                Text='<%# Eval("lngStudentNumber") %>' Visible="False" />
                            <br />
                            <div align="center">
                            <table width="70%" align="center">
                                <tr>
                                    <th>
                                        Academic Year</th>
                                    <th>
                                        Academic Semester</th>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="intStudyYearLabel" runat="server" 
                                                
                                                
                                            Text='<%# Eval("intStudyYear")+"/"+(Convert.ToInt32(Eval("intStudyYear"))+1) %>' 
                                            Visible='<%# Convert.ToInt32(Eval("intStudyYear"))>0 %>' 
                                            Font-Bold="True" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="SemesterDescLabel" runat="server" 
                                            Text='<%# Eval("SemesterDesc") %>' Font-Bold="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr /></td>
                                </tr>
                                <tr align="center">
                                    <td colspan="2" align="center">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            CellPadding="4" DataSourceID="Grades_Detail_ds" ForeColor="#333333" 
                                            GridLines="None" Width="100%">
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <Columns>
                                                <asp:BoundField DataField="strCourse" HeaderText="Code" 
                                                    SortExpression="strCourse" />
                                                <asp:BoundField DataField="CourseDesc" HeaderText="Course" 
                                                    SortExpression="CourseDesc" />
                                                <asp:BoundField DataField="strGrade" HeaderText="Grade" 
                                                    SortExpression="strGrade" />
                                                <asp:TemplateField HeaderText="Repeated" SortExpression="bDisActivated">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                            Visible='<%# Convert.ToBoolean(Eval("bDisactivated")) %>' Width="20px" />
                                                        <asp:Image ID="Image2" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Delete.gif" 
                                                            Visible='<%# !Convert.ToBoolean(Eval("bDisactivated")) %>' Width="20px" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" 
                                                            Checked='<%# Bind("bDisActivated") %>' />
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Major Changed" SortExpression="bCanceled">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                            Visible='<%# Convert.ToBoolean(Eval("bCanceled")) %>' Width="20px" />
                                                        <asp:Image ID="Image2" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Delete.gif" 
                                                            Visible='<%# !Convert.ToBoolean(Eval("bCanceled")) %>' Width="20px" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" 
                                                            Checked='<%# Bind("bCanceled") %>' />
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Calculated" SortExpression="bCalculated">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                            Visible='<%# Convert.ToBoolean(Eval("bCalculated")) %>' Width="20px" />
                                                        <asp:Image ID="Image2" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Delete.gif" 
                                                            Visible='<%# !Convert.ToBoolean(Eval("bCalculated")) %>' Width="20px" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("bCalculated") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="Grades_Detail_ds" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                            SelectCommand="SELECT Reg_Grade_Header.strCourse, Reg_Courses.strCourseDescEn AS CourseDesc, Reg_Grade_Header.strGrade, Reg_Grade_Header.bDisActivated, Reg_Grade_Header.bCanceled, CASE WHEN (bDisActivated = 1 OR bCanceled = 1) THEN 0 ELSE 1 END AS bCalculated FROM Reg_Grade_Header INNER JOIN Reg_Courses ON Reg_Grade_Header.strCourse = Reg_Courses.strCourse WHERE (Reg_Grade_Header.intStudyYear = @intStudyYear) AND (Reg_Grade_Header.byteSemester = @byteSemester) AND (Reg_Grade_Header.lngStudentNumber = @lngStudentNumber) ORDER BY Reg_Grade_Header.strCourse">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="Year_lbl" DefaultValue="0" Name="intStudyYear" 
                                                    PropertyName="Text" />
                                                <asp:ControlParameter ControlID="Semester_lbl" DefaultValue="0" 
                                                    Name="byteSemester" PropertyName="Text" />
                                                <asp:ControlParameter ControlID="Number_lbl" DefaultValue="" 
                                                    Name="lngStudentNumber" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                            </table>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="Grades_Females_ds" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                        
                        SelectCommand="SELECT Reg_Grade_Header.intStudyYear, Reg_Grade_Header.byteSemester, Lkp_Semesters.strSemesterDescEn AS SemesterDesc, COUNT(Reg_Grade_Header.strCourse) AS Courses, Reg_Grade_Header.lngStudentNumber FROM Reg_Grade_Header INNER JOIN Lkp_Semesters ON Reg_Grade_Header.byteSemester = Lkp_Semesters.byteSemester WHERE (Reg_Grade_Header.intStudyYear * 10 + Reg_Grade_Header.byteSemester &gt; 0) GROUP BY Reg_Grade_Header.intStudyYear, Reg_Grade_Header.byteSemester, Lkp_Semesters.strSemesterDescEn, Reg_Grade_Header.lngStudentNumber HAVING (Reg_Grade_Header.lngStudentNumber = @lngStudentNumber) AND (Reg_Grade_Header.intStudyYear = @intStudyYear) AND (Reg_Grade_Header.byteSemester &lt; @byteSemester) OR (Reg_Grade_Header.lngStudentNumber = @lngStudentNumber) AND (Reg_Grade_Header.intStudyYear &lt; @intStudyYear) ORDER BY Reg_Grade_Header.intStudyYear, Reg_Grade_Header.byteSemester">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="" Name="lngStudentNumber" 
                                SessionField="CurrentStudent" />
                            <asp:SessionParameter DefaultValue="0" Name="intStudyYear" 
                                SessionField="MarkYear" />
                            <asp:SessionParameter DefaultValue="0" Name="byteSemester" 
                                SessionField="MarkSemester" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:DetailsView ID="CGPA_Females_dlt" runat="server" AutoGenerateRows="False" 
                        CellPadding="4" DataSourceID="CGPA_ds" ForeColor="#333333" GridLines="None" 
                        Height="50px" Width="50%" HorizontalAlign="Center">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Bold="True" 
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="Column1" HeaderText="Last CGPA" ReadOnly="True" 
                                SortExpression="Column1" />
                        </Fields>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="CGPA_ds" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                            
                        SelectCommand="SELECT CONVERT(decimal(10,2), [GPA]) FROM [GPA_Until] WHERE ([lngStudentNumber] = @lngStudentNumber)">
                        <SelectParameters>
                            <asp:SessionParameter Name="lngStudentNumber" SessionField="CurrentStudent" 
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="Males_Emptylbl" runat="server" Text="No Data to Preview ..." CssClass="NoData"></asp:Label>
                    <br />
                    <asp:DataList ID="Males_dlt" runat="server" CellPadding="4" 
                        DataKeyField="intStudyYear" DataSourceID="Grades_Males_ds" 
                        ForeColor="#333333" Width="100%">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <ItemTemplate>
                            <asp:Label ID="Year_lbl" runat="server" Text='<%# Eval("intStudyYear") %>' 
                                Visible="False" />
                            <asp:Label ID="Semester_lbl" runat="server" Text='<%# Eval("byteSemester") %>' 
                                Visible="False" />
                            <asp:Label ID="Number_lbl" runat="server" 
                                Text='<%# Eval("lngStudentNumber") %>' Visible="False" />
                            <br />
                            <div align="center">
                            <table width="70%" align="center">
                                <tr>
                                    <th>
                                        Academic Year</th>
                                    <th>
                                        Academic Semester</th>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="intStudyYearLabel" runat="server" 
                                            Text='<%# Eval("intStudyYear")+"/"+(Convert.ToInt32(Eval("intStudyYear"))+1) %>' 
                                            Visible='<%# Convert.ToInt32(Eval("intStudyYear"))>0 %>' 
                                            Font-Bold="True" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="SemesterDescLabel" runat="server" 
                                            Text='<%# Eval("SemesterDesc") %>' Font-Bold="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                            CellPadding="4" DataSourceID="Grades_Detail" ForeColor="#333333" 
                                            GridLines="None" Width="100%">
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <Columns>
                                                <asp:BoundField DataField="strCourse" HeaderText="Code" 
                                                    SortExpression="strCourse" />
                                                <asp:BoundField DataField="CourseDesc" HeaderText="Course" 
                                                    SortExpression="CourseDesc" />
                                                <asp:BoundField DataField="strGrade" HeaderText="Grade" 
                                                    SortExpression="strGrade" />
                                                <asp:TemplateField HeaderText="Repeated" SortExpression="bDisActivated">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image3" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                            Visible='<%# Convert.ToBoolean(Eval("bDisactivated")) %>' Width="20px" />
                                                        <asp:Image ID="Image4" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Delete.gif" 
                                                            Visible='<%# !Convert.ToBoolean(Eval("bDisactivated")) %>' Width="20px" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox3" runat="server" 
                                                            Checked='<%# Bind("bDisActivated") %>' />
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Major Changed" SortExpression="bCanceled">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image5" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                            Visible='<%# Convert.ToBoolean(Eval("bCanceled")) %>' Width="20px" />
                                                        <asp:Image ID="Image6" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Delete.gif" 
                                                            Visible='<%# !Convert.ToBoolean(Eval("bCanceled")) %>' Width="20px" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox4" runat="server" 
                                                            Checked='<%# Bind("bCanceled") %>' />
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Calculated" SortExpression="bCalculated">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image7" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Correct.gif" 
                                                            Visible='<%# Convert.ToBoolean(Eval("bCalculated")) %>' Width="20px" />
                                                        <asp:Image ID="Image8" runat="server" Height="20px" 
                                                            ImageUrl="~/Images/Icons/Delete.gif" 
                                                            Visible='<%# !Convert.ToBoolean(Eval("bCalculated")) %>' Width="20px" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("bCalculated") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="Grades_Detail" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                            ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
                                            SelectCommand="SELECT Reg_Grade_Header.strCourse, Reg_Courses.strCourseDescEn AS CourseDesc, Reg_Grade_Header.strGrade, Reg_Grade_Header.bDisActivated, Reg_Grade_Header.bCanceled, CASE WHEN (bDisActivated = 1 OR bCanceled = 1) THEN 0 ELSE 1 END AS bCalculated FROM Reg_Grade_Header INNER JOIN Reg_Courses ON Reg_Grade_Header.strCourse = Reg_Courses.strCourse WHERE (Reg_Grade_Header.intStudyYear = @intStudyYear) AND (Reg_Grade_Header.byteSemester = @byteSemester) AND (Reg_Grade_Header.lngStudentNumber = @lngStudentNumber) ORDER BY Reg_Grade_Header.strCourse">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="Year_lbl" DefaultValue="0" Name="intStudyYear" 
                                                    PropertyName="Text" />
                                                <asp:ControlParameter ControlID="Semester_lbl" DefaultValue="0" 
                                                    Name="byteSemester" PropertyName="Text" />
                                                <asp:ControlParameter ControlID="Number_lbl" DefaultValue="" 
                                                    Name="lngStudentNumber" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                            </table>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="Grades_Males_ds" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                        ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
                        
                        SelectCommand="SELECT Reg_Grade_Header.intStudyYear, Reg_Grade_Header.byteSemester, Lkp_Semesters.strSemesterDescEn AS SemesterDesc, COUNT(Reg_Grade_Header.strCourse) AS Courses, Reg_Grade_Header.lngStudentNumber FROM Reg_Grade_Header INNER JOIN Lkp_Semesters ON Reg_Grade_Header.byteSemester = Lkp_Semesters.byteSemester WHERE (Reg_Grade_Header.intStudyYear * 10 + Reg_Grade_Header.byteSemester &gt; 0) GROUP BY Reg_Grade_Header.intStudyYear, Reg_Grade_Header.byteSemester, Lkp_Semesters.strSemesterDescEn, Reg_Grade_Header.lngStudentNumber HAVING (Reg_Grade_Header.lngStudentNumber = @lngStudentNumber) AND (Reg_Grade_Header.intStudyYear = @intStudyYear) AND (Reg_Grade_Header.byteSemester &lt; @byteSemester) OR (Reg_Grade_Header.lngStudentNumber = @lngStudentNumber) AND (Reg_Grade_Header.intStudyYear &lt; @intStudyYear) ORDER BY Reg_Grade_Header.intStudyYear, Reg_Grade_Header.byteSemester">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="" Name="lngStudentNumber" 
                                SessionField="CurrentStudent" />
                            <asp:SessionParameter DefaultValue="0" Name="intStudyYear" 
                                SessionField="MarkYear" />
                            <asp:SessionParameter DefaultValue="0" Name="byteSemester" 
                                SessionField="MarkSemester" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:DetailsView ID="CGPA_Males_dlt" runat="server" AutoGenerateRows="False" 
                        CellPadding="4" DataSourceID="CGPA_Males_ds" ForeColor="#333333" 
                        GridLines="None" Height="50px" Width="50%" HorizontalAlign="Center">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Bold="True" 
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="Column1" HeaderText="Last CGPA" ReadOnly="True" 
                                SortExpression="Column1" />
                        </Fields>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" 
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="CGPA_Males_ds" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                        ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
                        SelectCommand="SELECT CONVERT(decimal(10,2), [GPA]) FROM [GPA_Until] WHERE ([lngStudentNumber] = @lngStudentNumber)">
                        <SelectParameters>
                            <asp:SessionParameter Name="lngStudentNumber" SessionField="CurrentStudent" 
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </asp:View>
            </asp:MultiView>                
           
        </div>
    </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>