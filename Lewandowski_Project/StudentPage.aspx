<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="Lewandowski_Project.Account.StudentProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Student Profile</h1>
    </div>

    <asp:Button ID="ClientButton" runat="server" Text="Launch Modal Popup (Client)" />

    <asp:Panel ID="ModalPanel" runat="server" Width="500px">
        this is so cool if it is working
        <br />
        <asp:Button ID="OKButton" runat="server" Text="Close" />
    </asp:Panel>

    <cc1:ModalPopupExtender ID="mpe" runat="server" TargetControlId="ClientButton"
        PopupControlID="ModalPanel" OkControlID="OkButton" />

    <div style="background-color:#EEEEEE; padding-bottom:10px">
        <div class="row" style="margin:10px">
        <div class="col-md-4">
            <h2>Edit Profile</h2>
            <p>JCU Email: default@jcu.edu</p>
            <div style="display:flex">
            <section style="flex:1; padding:0, 5px, 5px, 5px">
                <p>Name: <br />
                <input type="text" />
                </p> 
                 <p>Year: <br />
                 <asp:DropDownList ID="SchoolYear" runat="server">
                        <asp:ListItem>Select Year</asp:ListItem>
                        <asp:ListItem>Freshman</asp:ListItem>
                        <asp:ListItem>Sophomore</asp:ListItem>
                        <asp:ListItem>Junior</asp:ListItem>
                        <asp:ListItem>Senior</asp:ListItem>
                </asp:DropDownList>
            </p>
            </section>
            <section style="flex:1; padding:0, 5px, 5px, 5px">
            <p>Major(s): <br />
                <input type="text" />
            </p>
             <p>Minor(s): <br />
                <input type="text" />
            </p>
            </section>
            <section style="flex:1; padding:0, 5px, 5px, 5px">
            <textarea id="BioTextArea" placeholder="Add Bio" cols="55" rows="5"></textarea>
            </section>
           </div>
        </div>
    </div>
    <br />
    <input id="UpdateProfileButton" type="submit" value="Update" />
    </div>

<br />
<br />

    <div style="padding:10px">
        <h2>Explore Alumni</h2>
        <asp:TextBox ID="searchTextBox" placeholder="Search Alumni" width="200px" runat="server"></asp:TextBox>
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
                <asp:TableCell>Pharmacist</asp:TableCell>
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



