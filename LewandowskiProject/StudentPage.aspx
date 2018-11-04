<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="LewandowskiProject.StudentPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style type="text/css">
        .Background{
            background-color:black;
            filter:alpha(opacity=90);
            opacity:0.8;
        }
        .ProfilePopup{
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left:10px;
            width: 400px;
            height: 500px;
        }
    </style>
    
    <%--view alumni table--%>
    <div class="jumbotron">
        <h1>Student Profile</h1>
    </div>

    <%--Edit student profile modal--%>
    <asp:HiddenField ID="AjaxFunctionalityEater" runat="server" />
     <cc1:ModalPopupExtender ID="mpe" runat="server" TargetControlId="AjaxFunctionalityEater"
        PopupControlID="ModalPanel" BackgroundCssClass="Background" />
    <asp:Button ID="ClientButton" runat="server" Text="Edit Profile" OnClick="ClientButton_Click" />
    <asp:Panel ID="ModalPanel" runat="server" Width="500px" CssClass="ProfilePopup">
        <h3>Edit Profile</h3>
       
        <asp:Label ID="EmailLabel" runat="server" Text="JCU Email:"></asp:Label>
        &nbsp;<asp:Label ID="Email" runat="server" Text="default@jcu.edu"></asp:Label><br /><br />
        
        <asp:Label ID="FNameLabel" runat="server" Text="First Name:"></asp:Label>
        &nbsp;<asp:TextBox ID="FNameTextBox" runat="server"></asp:TextBox><br /><br />
        
        <asp:Label ID="LNameLabel" runat="server" Text="Last Name:"></asp:Label>
        &nbsp;<asp:TextBox ID="LNameTextBox" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="YearInSchoolLabel" runat="server" Text="Year In School:"></asp:Label>
        &nbsp;<asp:DropDownList ID="YearDropDownList" runat="server">
            <asp:ListItem>Select Year</asp:ListItem>
            <asp:ListItem>Freshman</asp:ListItem>
            <asp:ListItem>Sophomore</asp:ListItem>
            <asp:ListItem>Junior</asp:ListItem>
            <asp:ListItem>Senior</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="graduationLabel" runat="server" Text="Graduation Year:"></asp:Label>
        &nbsp;<asp:TextBox ID="GraduationYearTextbox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="MajorLabel" runat="server" Text="Major(s):"></asp:Label>
        &nbsp;<asp:TextBox ID="MajorTextBox" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="MinorLabel" runat="server" Text="Minor(s):"></asp:Label>
        &nbsp;<asp:TextBox ID="MinorTextBox" runat="server"></asp:TextBox><br /><br />

        <asp:Textbox id="BioTextArea" runat="server" placeholder="Add Bio" cols="55" rows="5"></asp:Textbox>
        <br /><br />
        <asp:Button ID="CloseButton" runat="server" Text="Close" OnClick="CloseButton_Click" />
    </asp:Panel>
<br />

    <%--view alumni table--%>
    <div style="padding:10px">
        <h2>Explore Alumni  <asp:TextBox ID="searchTextBox" placeholder="Search Alumni" width="200px" runat="server"></asp:TextBox>
        <asp:Button ID="searchButton" runat="server" Text="Go" />
        <asp:DropDownList ID="sortDropDown" runat="server" style="margin:5px">
            <asp:ListItem>Sort by</asp:ListItem>
            <asp:ListItem>Name</asp:ListItem>
            <asp:ListItem>Graduation</asp:ListItem>
            <asp:ListItem>City</asp:ListItem>
            <asp:ListItem>State</asp:ListItem>
            <asp:ListItem>Profession</asp:ListItem>
        </asp:DropDownList>
        <br />
        <section style="display:flex; margin-top:5px">
        <div style="margin:5px,5px,5px,0; flex:1; background-color:#EAEAEA">
            <asp:Label ID="filter" runat="server" Text="filter" style="margin:5px">Filter</asp:Label>
            <br /> 
            <asp:DropDownList ID="graduationYearDropDown" runat="server" style="margin:5px">
                <asp:ListItem>Select Graduation Year</asp:ListItem>
                <asp:ListItem>2015-2017</asp:ListItem>
                <asp:ListItem>2010-2014</asp:ListItem>
                <asp:ListItem>2005-2009</asp:ListItem>
                <asp:ListItem>2000-2004</asp:ListItem>
                <asp:ListItem>1995-1999</asp:ListItem>
                <asp:ListItem>1990-1994</asp:ListItem>
                <asp:ListItem>1985-1989</asp:ListItem>
                <asp:ListItem>1980-1984</asp:ListItem>
                <asp:ListItem>1975-1979</asp:ListItem>
                <asp:ListItem>1970-1974</asp:ListItem>
                <asp:ListItem>1965-1969</asp:ListItem>
                <asp:ListItem>1960-1964</asp:ListItem>        
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="cityDropDown" runat="server" style="margin:5px">
                <asp:ListItem>Select City</asp:ListItem>
                <asp:ListItem>Buffalo</asp:ListItem>
                <asp:ListItem>Chicago</asp:ListItem>
                <asp:ListItem>Cleveland</asp:ListItem>
                <asp:ListItem>Columbus</asp:ListItem>
                <asp:ListItem>Detroit</asp:ListItem>
                <asp:ListItem>Rochester</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="stateDropDown" runat="server" style="margin:5px">
                <asp:ListItem>Select State</asp:ListItem>
                <asp:ListItem>IL</asp:ListItem>
                <asp:ListItem>MI</asp:ListItem>
                <asp:ListItem>NY</asp:ListItem>
                <asp:ListItem>OH</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="professionDropDown" runat="server" style="margin:5px">
                <asp:ListItem>Select Profession</asp:ListItem>
                <asp:ListItem>Dentist</asp:ListItem>
                <asp:ListItem>Pharmacist</asp:ListItem>
                <asp:ListItem>Optometrist</asp:ListItem>
                <asp:ListItem>Veterinarian</asp:ListItem>
                <asp:ListItem>Cardiologist</asp:ListItem>
                <asp:ListItem>Pediatrician</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div style="padding:5px; flex:3">

        <asp:Table ID="alumniTable" runat="server" Width="90%" CellPadding="5">
            <asp:TableHeaderRow runat="server" Font-Bold="true" BackColor="#BBBBBB">
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Graduation</asp:TableHeaderCell>
                <asp:TableHeaderCell>City</asp:TableHeaderCell>
                <asp:TableHeaderCell>State</asp:TableHeaderCell>
                <asp:TableHeaderCell>Profession</asp:TableHeaderCell>
                <asp:TableHeaderCell>View</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow runat="server">
                <asp:TableCell>John Doe</asp:TableCell>
                <asp:TableCell>2001</asp:TableCell>
                <asp:TableCell>Cleveland</asp:TableCell>
                <asp:TableCell>OH</asp:TableCell>
                <asp:TableCell>Dentist</asp:TableCell>
                <asp:TableCell Font-Underline="True" ForeColor="#0000FF">View Full Profile</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell>Mary Smith</asp:TableCell>
                <asp:TableCell>2014</asp:TableCell>
                <asp:TableCell>Columbus</asp:TableCell>
                <asp:TableCell>OH</asp:TableCell>
                <asp:TableCell>Pediatrician</asp:TableCell>
                <asp:TableCell Font-Underline="True" ForeColor="#0000FF">View Full Profile</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell>Tom Miller</asp:TableCell>
                <asp:TableCell>1994</asp:TableCell>
                <asp:TableCell>Pittsburgh</asp:TableCell>
                <asp:TableCell>PA</asp:TableCell>
                <asp:TableCell>Pharmacist</asp:TableCell>
                <asp:TableCell Font-Underline="True" ForeColor="#0000FF">View Full Profile</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
            </div>
        </section>
    </div>
    <br />
</asp:Content>