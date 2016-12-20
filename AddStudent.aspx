<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" MasterPageFile="~/AlgonquinMasterPage2.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1>Register Students</h1>
        <asp:Panel runat="server" ID="pnlRegisterStudents" CssClass="displayPanel">
            <div class="row">
                <asp:Label ID="lblRegisterStudentsList" runat="server" CssClass="label" Text="Course Offering:"></asp:Label>
                <asp:DropDownList ID="drpRegisterStudentsList" runat="server" OnSelectedIndexChanged="drpRegisterStudentsList_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="-1">Select a Course Offering ...</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rqdFieldValidator_RegisterStudentsList" ControlToValidate="drpRegisterStudentsList"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="lblStudentNumber" runat="server" CssClass="label" Text="Student Number:"></asp:Label>
                <asp:TextBox runat="server" ID="txtStudentNumber" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_tblStudentNumber" ControlToValidate="txtStudentNumber"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="lblStudentName" runat="server" CssClass="label" Text="Student Name:"></asp:Label>
                <asp:TextBox runat="server" ID="txtStudentName" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_StudentName" ControlToValidate="txtStudentName"></asp:RequiredFieldValidator>
            </div>
            <asp:RadioButtonList ID="rdbStudentType" runat="server" onSelectedIndexChanged="rdbStudentType_SelectedIndexChanged" CausesValidation="false" AutoPostBack="true">
                <asp:ListItem Selected="True" value="FullTime">Full Time</asp:ListItem>
                <asp:ListItem value="PartTime">Part Time</asp:ListItem>
                <asp:ListItem Value="Coop">Co-op</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button runat="server" ID="btnAddToCourseOffering" Text="Add to course offering" OnClick="btnAddToCourseOffering_Click"/>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlCourseOfferingDisplay_ForRegisterStudent">
            <div class="row">
                <asp:Label ID="lblCourseOfferingDisplay_forRegisterStudent" runat="server" CssClass="listLabel" Text="The selected course offering has the following registered students:"></asp:Label>
                <asp:Table runat="server" ID="tblCourseOfferingRegisteredStudent" CssClass="table">
                    <asp:TableRow>
                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Name</asp:TableHeaderCell>    
                        <asp:TableHeaderCell>Type</asp:TableHeaderCell> 
                        <asp:TableHeaderCell>Tuition</asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </asp:Panel>
    </asp:Content>

