<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCourseOffering.aspx.cs" Inherits="AddCourseOffering" MasterPageFile="~/AlgonquinMasterPage2.master"%>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1>Add New Course Offering</h1>
        <asp:Panel runat="server" ID="pnlCourseOffering" CssClass="displayPanel">
            <div class="row">
                <asp:Label ID="lblCourseOfferingList" runat="server" CssClass="label" Text="Course:"></asp:Label>
                <asp:DropDownList ID="drpCourseOfferingList" runat="server" OnSelectedIndexChanged="drpCourseOfferingList_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="-1">Select a Course ...</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rqdFieldValidator_CourseOfferingList" ControlToValidate="drpCourseOfferingList"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="lblOfferInYr" runat="server" CssClass="label" Text="Offer in Year:"></asp:Label>
                <asp:DropDownList ID="drpOfferInYr" runat="server" OnSelectedIndexChanged="drpOfferInYr_SelectedIndexChanged" AutoPostBack="true" >
                    <asp:ListItem Value="-1">Select ...</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rqdFieldValidator_OfferInYr" ControlToValidate="drpOfferInYr"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="lblSemest" runat="server" CssClass="label" Text="Semest:"></asp:Label>
                <asp:DropDownList ID="drpSemester" runat="server" OnSelectedIndexChanged="drpSemester_SelectedIndexChanged" AutoPostBack="true" >
                    <asp:ListItem Value="-1">Select ...</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rqdFieldValidator_Semest" ControlToValidate="drpSemester"></asp:RequiredFieldValidator>
            </div>
            <asp:Button runat="server" ID="btnAddCourseOffering" Text="Add course offering" OnClick="btnAddCourseOffering_Click"/>
        </asp:Panel>

         <asp:Panel runat="server" ID="pnlCourseOfferingDisplay" >
        <div class="row">
            <asp:Label ID="lblCourseOfferingDisplay" runat="server" CssClass="listLabel" Text="There are following course offerings:"></asp:Label>
            <asp:Table runat="server" ID="tblCourseOffering" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Title</asp:TableHeaderCell>    
                    <asp:TableHeaderCell>Year</asp:TableHeaderCell> 
                    <asp:TableHeaderCell>Semester</asp:TableHeaderCell> 
                </asp:TableRow>
            </asp:Table>
        </div>
    </asp:Panel>
 </asp:Content>
  

