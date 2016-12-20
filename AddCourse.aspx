<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" MasterPageFile="~/AlgonquinMasterPage2.master"%>


    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
            .form{
                height:595px;
                width:663px;
            }
            .row {
                margin:10px;
            }
            .label {
                display:inline-block;
                text-align:right;
                width:120px;
                padding-right:5px;
            }
            .textBox{
                height:350px;
                display:block;
            }
            .error{
                color:red;
            }
        </style>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1>Add New Course</h1>
        <asp:Panel runat="server" ID="pnlCourseInfo" CssClass="displayPanel">
            <div class="row">
                <asp:Label ID="lblCourseNumber" runat="server" CssClass="label" Text="Course Number:"></asp:Label>
                <asp:TextBox runat="server" ID="txtCourseNumber" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_tblCourseNumber" ControlToValidate="txtCourseNumber"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="lblCourseName" runat="server" CssClass="label" Text="Course Name:"></asp:Label>
                <asp:TextBox runat="server" ID="txtCourseName" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_tblCourseName" ControlToValidate="txtCourseName" ></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="lblCourseWklyHours" runat="server" CssClass="label" Text="Weekly Hours:"></asp:Label>
                <asp:TextBox runat="server" ID="txtCourseWklyHours" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_tblCourseWklyHours" ControlToValidate="txtCourseName" ></asp:RequiredFieldValidator>
            </div>
            <asp:Button runat="server" ID="btnSumitCourseInfo" Text="Submit Course Information" OnClick="btnSumitCourseInfo_Click"/>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlCourseInfoDisplay" >
        <div class="row">
            <asp:Label ID="lblCourseInfoDisplay" runat="server" CssClass="listLabel" Text="Following courses are currently in the system:"></asp:Label>
            <asp:Table runat="server" ID="tblCourseInfo" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Title</asp:TableHeaderCell>    
                    <asp:TableHeaderCell>Weekly Hours</asp:TableHeaderCell> 
                </asp:TableRow>
            </asp:Table>
        </div>
        </asp:Panel>

    </asp:Content>
    
