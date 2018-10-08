<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PractitionerPage.aspx.cs" Inherits="Lewandowski_Project.Account.PractitionerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Practitioner Profile</h1>
    </div>
    
        <h2>Personal Information:</h2>
            <p>Full Name: <br />
                <input id="FullName" type="text" />
            </p>
             <p>Gender: <br />
                 <input id="female" type="radio" />Female
                 <input id="male" type="radio" />Male
            </p> 
            <p> Phone Number: <br />
                <input id="PhoneNumber" type="text" />
            </p>
             <p>Email: <br />
                <input id="Email" type="text" />
            </p> 
             <p>City: <br />
                <input id="City" type="text" />
            </p> 
             <p>State: <br />
                <input id="State" type="text" />
            </p> 
            <p>Zip Code: <br />
                <input id="ZipCode" type="text" />
            </p>

        <h2>Education:</h2>
            <p><b>Undergrad School:</b><br /></p>
            <p>School Name: <br />
                <input id="UndergradName" type="text" />
            </p>
            <p>Graduation Year: <br />
                <input id="UnderGradYear" type="text" />
            </p>
            <p> Degree Earned:<br />
                <asp:DropDownList ID="UndergradDegreeEarnedDropDownList" runat="server">
                    <asp:ListItem>Associates</asp:ListItem>
                    <asp:ListItem>Bachelors</asp:ListItem>
                </asp:DropDownList>
            </p>

            <p><b>Graduate School:</b><br /></p>
            <p>School Name: <br />
                <input id="GradSchoolName" type="text" />
            </p>
            <p>Graduation Year: <br />
                <input id="GradSchoolGradYear" type="text" />
            </p>
            <p> Degree Earned:<br />
                <asp:DropDownList ID="GradSchoolDropDownList" runat="server">
                    <asp:ListItem>Associates</asp:ListItem>
                    <asp:ListItem>Bachelors</asp:ListItem>
                    <asp:ListItem>Masters</asp:ListItem>
                    <asp:ListItem>Doctorate</asp:ListItem>
                </asp:DropDownList>
            </p>

            <p><b>Medical School:</b><br /></p>
            <p>School Name:<br />
                <input id="MedSchool" type="text" />
            </p>
            <p>Graduation Year: <br />
                <input id="MedSchoolGradYear" type="text" />
            </p>
            <p> Degree Earned:<br />
                <asp:DropDownList ID="MedSchoolDropDownList" runat="server">
                    <asp:ListItem>Associates</asp:ListItem>
                    <asp:ListItem>Bachelors</asp:ListItem>
                    <asp:ListItem>Masters</asp:ListItem>
                    <asp:ListItem>Doctorate</asp:ListItem>
                </asp:DropDownList>
            </p>

    <h2>Experience:</h2>
            <p><b>Residency:</b><br /></p>
            <p>Name:<br />
                <input id="ResidencyName" type="text" />
            </p>
            <p>Location:<br />
                <input id="ResidencyLocation" type="text" />
            </p>
            <p>Duration:<br />
                <input id="ResidencyDuration" type="text" />
            </p>
            <p> Description: <br />
                <input id="ResidencyDescription" type="text" />
            </p>

            <p><b>Fellowship: </b><br /></p>
            <p>Name:<br />
                <input id="FellowshipName" type="text" />
            </p>
            <p>Location: <br />
                <input id="FellowshipLocation" type="text" />
            </p>
            <p>Duration:<br />
                <input id="FellowshipDuration" type="text" />
            </p>
            <p>Description: <br />
                <textarea id="FellowshipDescriptionTextArea" cols="40" rows="5"></textarea>
            </p>

            <p><b>Profession: </b> <br /></p>
            <p>Title:<br />
                <input id="ProfessionTitle" type="text" />
            </p> 
            <p>Location: <br />
                <input id="ProfessionLocation" type="text" />
            </p>
            <p> Duration: <br />
                <input id="ProfessionDuration" type="text" />
            </p>
            <p> Description: <br />
                <textarea id="ProfessionDescriptionTextArea" cols="40" rows="5"></textarea>
            </p>

    <h2>Bio & Interests</h2>
    <textarea id="BioTextArea" cols="40" rows="5">Add Bio/Interests...</textarea>
    <br /><br />

    <input id="UpdateProfileButton" type="submit" value="update" />


</asp:Content>
