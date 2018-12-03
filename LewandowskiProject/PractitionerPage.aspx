<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PractitionerPage.aspx.cs" Inherits="LewandowskiProject.PractitionerPage" maintainScrollPositionOnPostBack="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Practitioner Profile</h1>
    </div>
    
        <h2>Personal Information:</h2>
            <p>
                <asp:Label ID="PractitionerFirstNameLabel" runat="server">First Name: <br /></asp:Label>
                <asp:TextBox ID="PractitionerFirstName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerLastNameLabel" runat="server">Last Name: <br /> </asp:Label>
                <asp:TextBox ID="PractitionerLastName" runat="server"></asp:TextBox>
            </p>
             <p>
                 <asp:Label ID="PractitionerGenderRadioButtonListLabel" runat="server">Gender:</asp:Label>
                 <asp:RadioButtonList ID="PractitionerGenderRadioButtonList" runat="server">
                     <asp:ListItem>Female</asp:ListItem>
                     <asp:ListItem>Male</asp:ListItem>
                 </asp:RadioButtonList>
            </p> 
            <p>
                <asp:Label ID="PractitionerPhoneNumberLabel" runat="server">Phone Number: <br /></asp:Label> 
                <asp:TextBox ID="PractitionerPhoneNumber" runat="server"></asp:TextBox>
            </p>
             <p>
                 <asp:Label ID="PractitionerEmailLabel" runat="server">Email: <br /></asp:Label>
                 <asp:TextBox ID="PractitionerEmail" runat="server"></asp:TextBox>
            </p> 
             <p>
                 <asp:Label ID="PractitionerCityLabel" runat="server">City: <br /></asp:Label>
                 <asp:TextBox ID="PractitionerCity" runat="server"></asp:TextBox>                
                 <br />
                 <asp:Label ID="PractitionerPersonalInformationStateDropDownListLabel" runat="server">State: <br /></asp:Label>
                 <asp:DropDownList ID="PractitionerPersonalInformationStateDropDownList" runat="server">
                     <asp:ListItem>Alabama</asp:ListItem>
                     <asp:ListItem>Alaska</asp:ListItem>
                     <asp:ListItem>Arizona</asp:ListItem>
                     <asp:ListItem>Arkansas</asp:ListItem>
                     <asp:ListItem>California</asp:ListItem>
                     <asp:ListItem>Colorado</asp:ListItem>
                     <asp:ListItem>Connecticut</asp:ListItem>
                     <asp:ListItem>Delaware</asp:ListItem>
                     <asp:ListItem>District of Columbia</asp:ListItem>
                     <asp:ListItem>Florida</asp:ListItem>
                     <asp:ListItem>Georgia</asp:ListItem>
                     <asp:ListItem>Hawaii</asp:ListItem>
                     <asp:ListItem>Idaho</asp:ListItem>
                     <asp:ListItem>Illinois</asp:ListItem>
                     <asp:ListItem>Indiana</asp:ListItem>
                     <asp:ListItem>Iowa</asp:ListItem>
                     <asp:ListItem>Kansas</asp:ListItem>
                     <asp:ListItem>Kentucky</asp:ListItem>
                     <asp:ListItem>Louisiana</asp:ListItem>
                     <asp:ListItem>Maine</asp:ListItem>
                     <asp:ListItem>Maryland</asp:ListItem>
                     <asp:ListItem>Massachusetts</asp:ListItem>
                     <asp:ListItem>Michigan</asp:ListItem>
                     <asp:ListItem>Minnesota</asp:ListItem>
                     <asp:ListItem>Mississippi</asp:ListItem>
                     <asp:ListItem>Missouri</asp:ListItem>
                     <asp:ListItem>Montana</asp:ListItem>
                     <asp:ListItem>Nebraska</asp:ListItem>
                     <asp:ListItem>Nevada</asp:ListItem>
                     <asp:ListItem>New Hampshire</asp:ListItem>
                     <asp:ListItem>New Jersey</asp:ListItem>
                     <asp:ListItem>New Mexico</asp:ListItem>
                     <asp:ListItem>New York</asp:ListItem>
                     <asp:ListItem>North Carolina</asp:ListItem>
                     <asp:ListItem>North Dakota</asp:ListItem>
                     <asp:ListItem>Ohio</asp:ListItem>
                     <asp:ListItem>Oklahoma</asp:ListItem>
                     <asp:ListItem>Oregon</asp:ListItem>
                     <asp:ListItem>Pennsylvania</asp:ListItem>
                     <asp:ListItem>Puerto Rico</asp:ListItem>
                     <asp:ListItem>Rhode Island</asp:ListItem>
                     <asp:ListItem>South Carolina</asp:ListItem>
                     <asp:ListItem>South Dakota</asp:ListItem>
                     <asp:ListItem>Tennessee</asp:ListItem>
                     <asp:ListItem>Texas</asp:ListItem>
                     <asp:ListItem>Utah</asp:ListItem>
                     <asp:ListItem>Vermont</asp:ListItem>
                     <asp:ListItem>Virginia</asp:ListItem>
                     <asp:ListItem>Virgin Islands</asp:ListItem>
                     <asp:ListItem>Washington</asp:ListItem>
                     <asp:ListItem>West Virginia</asp:ListItem>
                     <asp:ListItem>Wisconsin</asp:ListItem>
                     <asp:ListItem>Wyoming</asp:ListItem>
                 </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="AcceptingStudentsLabel" runat="server">Currently Accepting Students:</asp:Label>
                 <asp:RadioButtonList ID="AcceptingStudentsRadioButton" runat="server">
                     <asp:ListItem>Yes</asp:ListItem>
                     <asp:ListItem>No</asp:ListItem>
                 </asp:RadioButtonList>

            <asp:Button ID="PractitionerPersonalInfoSaveButton" runat="server" Text="save" OnClick="PractitionerPersonalInfoSaveButton_Click"/>
       
    <h2>Education:</h2>
            <p>
                <asp:DropDownList ID="PractitionerAddEducationDropDownList" runat="server" Height="20px" Width="218px" OnSelectedIndexChanged="PractitionerAddEducationDropDownList_SelectedIndexChanged" AutoPostBack ="true"/>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationSchoolNameTextLabel" runat="server">School Name: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationSchoolNameText" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationYearInLabel" runat="server">Year In School: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationYearInText" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationGradYearTextLabel" runat="server">Graduation Year:<br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationGradYearText" runat="server" placeholder="yyyy"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationDegreeEarnedDropDownListLabel" runat="server">Degree Earned:<br /></asp:Label>
                <asp:DropDownList ID="PractitionerEducationDegreeEarnedDropDownList" runat="server">
                    <asp:ListItem>Associates</asp:ListItem>
                    <asp:ListItem>Bachelors</asp:ListItem>
                    <asp:ListItem>Masters</asp:ListItem>
                    <asp:ListItem>Doctorate</asp:ListItem>
                    <asp:ListItem>Medical School</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationMajortLabel" runat="server">Degree Earned in/Major: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationMajorText" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationMinorTextLabel" runat="server">Minor: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationMinorText" runat="server"></asp:TextBox>
            </p>
        <asp:Button ID="PractitionerEducationAddButton" runat="server" Text="add" OnClick="PractitionerEducationAddButton_Click" /> &nbsp &nbsp
        <asp:Button ID="PractitionerEducationUpdateButton" runat="server" Text="update" OnClick="PractitionerEducationUpdateButton_Click" /> &nbsp &nbsp
        <asp:Button ID="PractitionerEducationDeleteButton" runat="server" Text="delete" OnClick="PractitionerEducationDeleteButton_Click" /> <br />
        <asp:Button ID="PractitionerEducationClearButton" runat="server" Text="add another record" OnClick="PractitionerEducationClearButton_Click"/> <br />

     <h2>Internships/Residencies/Fellowships:</h2>
            <p>
                <asp:DropDownList ID="PractitionerAddInternshipsDropDownList" runat="server" OnSelectedIndexChanged="PractitionerAddInternshipsDropDownList_SelectedIndexChanged" AutoPostBack ="true" Width="151px" />
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsDropDownListLabel" runat="server">Type of experience: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerInternshipsDropDownList" runat="server">
                    <asp:ListItem>Internship</asp:ListItem>
                    <asp:ListItem>Residency</asp:ListItem>
                    <asp:ListItem>Fellowship</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipNameOrTitleLabel" runat="server">Name/Title: <br /></asp:Label>
                <asp:TextBox ID="PractitionerInternshipNameOrTitle" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsAreaDropDownListLabel" runat="server">Area of Expertise: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerInternshipsAreaDropDownList" runat="server">
                    <asp:ListItem>Dentistry</asp:ListItem>
                    <asp:ListItem>Surgery</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsInstituteNameTextLabel" runat="server">Name of institute: <br /></asp:Label>
                <asp:TextBox ID="PractitionerInternshipsInstituteNameText" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsInstituteCityLabel" runat="server">City: <br /></asp:Label>
                <asp:TextBox ID="PractitionerInternshipsInstituteCity" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsInstituteStateDropDownListLabel" runat="server">State: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerInternshipsInstituteStateDropDownList" runat="server">
                     <asp:ListItem>Alabama</asp:ListItem>
                     <asp:ListItem>Alaska</asp:ListItem>
                     <asp:ListItem>Arizona</asp:ListItem>
                     <asp:ListItem>Arkansas</asp:ListItem>
                     <asp:ListItem>California</asp:ListItem>
                     <asp:ListItem>Colorado</asp:ListItem>
                     <asp:ListItem>Connecticut</asp:ListItem>
                     <asp:ListItem>Delaware</asp:ListItem>
                     <asp:ListItem>District of Columbia</asp:ListItem>
                     <asp:ListItem>Florida</asp:ListItem>
                     <asp:ListItem>Georgia</asp:ListItem>
                     <asp:ListItem>Hawaii</asp:ListItem>
                     <asp:ListItem>Idaho</asp:ListItem>
                     <asp:ListItem>Illinois</asp:ListItem>
                     <asp:ListItem>Indiana</asp:ListItem>
                     <asp:ListItem>Iowa</asp:ListItem>
                     <asp:ListItem>Kansas</asp:ListItem>
                     <asp:ListItem>Kentucky</asp:ListItem>
                     <asp:ListItem>Louisiana</asp:ListItem>
                     <asp:ListItem>Maine</asp:ListItem>
                     <asp:ListItem>Maryland</asp:ListItem>
                     <asp:ListItem>Massachusetts</asp:ListItem>
                     <asp:ListItem>Michigan</asp:ListItem>
                     <asp:ListItem>Minnesota</asp:ListItem>
                     <asp:ListItem>Mississippi</asp:ListItem>
                     <asp:ListItem>Missouri</asp:ListItem>
                     <asp:ListItem>Montana</asp:ListItem>
                     <asp:ListItem>Nebraska</asp:ListItem>
                     <asp:ListItem>Nevada</asp:ListItem>
                     <asp:ListItem>New Hampshire</asp:ListItem>
                     <asp:ListItem>New Jersey</asp:ListItem>
                     <asp:ListItem>New Mexico</asp:ListItem>
                     <asp:ListItem>New York</asp:ListItem>
                     <asp:ListItem>North Carolina</asp:ListItem>
                     <asp:ListItem>North Dakota</asp:ListItem>
                     <asp:ListItem>Ohio</asp:ListItem>
                     <asp:ListItem>Oklahoma</asp:ListItem>
                     <asp:ListItem>Oregon</asp:ListItem>
                     <asp:ListItem>Pennsylvania</asp:ListItem>
                     <asp:ListItem>Puerto Rico</asp:ListItem>
                     <asp:ListItem>Rhode Island</asp:ListItem>
                     <asp:ListItem>South Carolina</asp:ListItem>
                     <asp:ListItem>South Dakota</asp:ListItem>
                     <asp:ListItem>Tennessee</asp:ListItem>
                     <asp:ListItem>Texas</asp:ListItem>
                     <asp:ListItem>Utah</asp:ListItem>
                     <asp:ListItem>Vermont</asp:ListItem>
                     <asp:ListItem>Virginia</asp:ListItem>
                     <asp:ListItem>Virgin Islands</asp:ListItem>
                     <asp:ListItem>Washington</asp:ListItem>
                     <asp:ListItem>West Virginia</asp:ListItem>
                     <asp:ListItem>Wisconsin</asp:ListItem>
                     <asp:ListItem>Wyoming</asp:ListItem>
                 </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsTextAreaLabel" runat="server">Description: <br /></asp:Label>
                <asp:TextBox ID="PractitionerInternshipsTextArea" TextMode="MultiLine" cols="20" Rows="2" runat="server"></asp:TextBox>

            </p>
           
            <p>
                <asp:Label ID="PractitionerInternshipsCurrentRadioButtonListLabel" runat="server">Currently working here?<br /></asp:Label>
                <asp:RadioButtonList ID="PractitionerInternshipsCurrentRadioButtonList" runat="server" Width="49px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>
            </p>
        <asp:Button ID="PractitionerInternshipsAddButton" runat="server" Text="add" OnClick="PractitionerInternshipsAddButton_Click" /> &nbsp &nbsp
        <asp:Button ID="PractitionerInternshipsUpdateButton" runat="server" Text="update" OnClick="PractitionerInternshipsUpdateButton_Click" /> &nbsp &nbsp
        <asp:Button ID="PractitionerInternshipsDeleteButton" runat="server" Text="delete" OnClick="PractitionerInternshipsDeleteButton_Click" /> <br />
        <asp:Button ID="PractitionerInternshipsClearButton" runat="server" Text="add another record" OnClick="PractitionerInternshipsClearButton_Click" /> <br />
    

    <h2>Profession:</h2>
            <p>
                <asp:DropDownList ID="PractitionerAddPrfessionDropDownList" runat="server" OnSelectedIndexChanged="PractitionerAddPrfessionDropDownList_SelectedIndexChanged" AutoPostBack ="true" Width="151px" />
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionNameOrTitleLabel" runat="server">Name/Title: <br /></asp:Label>
                <asp:TextBox ID="PractitionerProfessionNameOrTitle" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionDropDownListLabel" runat="server">Area of Expertise: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerProfessionDropDownList" runat="server">
                    <asp:ListItem>Dentistry</asp:ListItem>
                    <asp:ListItem>Surgery</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionLocationTextLabel" runat="server">Name of company: <br /></asp:Label>
                <asp:TextBox ID="PractitionerProfessionLocationText" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionCityLabel" runat="server">City: <br /></asp:Label>
                <asp:TextBox ID="PractitionerProfessionCity" runat="server"></asp:TextBox>

            </p>
            <p><asp:Label ID="PractitionerProfessionStateDropDownListLabel" runat="server">State: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerProfessionStateDropDownList" runat="server">
                     <asp:ListItem>Alabama</asp:ListItem>
                     <asp:ListItem>Alaska</asp:ListItem>
                     <asp:ListItem>Arizona</asp:ListItem>
                     <asp:ListItem>Arkansas</asp:ListItem>
                     <asp:ListItem>California</asp:ListItem>
                     <asp:ListItem>Colorado</asp:ListItem>
                     <asp:ListItem>Connecticut</asp:ListItem>
                     <asp:ListItem>Delaware</asp:ListItem>
                     <asp:ListItem>District of Columbia</asp:ListItem>
                     <asp:ListItem>Florida</asp:ListItem>
                     <asp:ListItem>Georgia</asp:ListItem>
                     <asp:ListItem>Hawaii</asp:ListItem>
                     <asp:ListItem>Idaho</asp:ListItem>
                     <asp:ListItem>Illinois</asp:ListItem>
                     <asp:ListItem>Indiana</asp:ListItem>
                     <asp:ListItem>Iowa</asp:ListItem>
                     <asp:ListItem>Kansas</asp:ListItem>
                     <asp:ListItem>Kentucky</asp:ListItem>
                     <asp:ListItem>Louisiana</asp:ListItem>
                     <asp:ListItem>Maine</asp:ListItem>
                     <asp:ListItem>Maryland</asp:ListItem>
                     <asp:ListItem>Massachusetts</asp:ListItem>
                     <asp:ListItem>Michigan</asp:ListItem>
                     <asp:ListItem>Minnesota</asp:ListItem>
                     <asp:ListItem>Mississippi</asp:ListItem>
                     <asp:ListItem>Missouri</asp:ListItem>
                     <asp:ListItem>Montana</asp:ListItem>
                     <asp:ListItem>Nebraska</asp:ListItem>
                     <asp:ListItem>Nevada</asp:ListItem>
                     <asp:ListItem>New Hampshire</asp:ListItem>
                     <asp:ListItem>New Jersey</asp:ListItem>
                     <asp:ListItem>New Mexico</asp:ListItem>
                     <asp:ListItem>New York</asp:ListItem>
                     <asp:ListItem>North Carolina</asp:ListItem>
                     <asp:ListItem>North Dakota</asp:ListItem>
                     <asp:ListItem>Ohio</asp:ListItem>
                     <asp:ListItem>Oklahoma</asp:ListItem>
                     <asp:ListItem>Oregon</asp:ListItem>
                     <asp:ListItem>Pennsylvania</asp:ListItem>
                     <asp:ListItem>Puerto Rico</asp:ListItem>
                     <asp:ListItem>Rhode Island</asp:ListItem>
                     <asp:ListItem>South Carolina</asp:ListItem>
                     <asp:ListItem>South Dakota</asp:ListItem>
                     <asp:ListItem>Tennessee</asp:ListItem>
                     <asp:ListItem>Texas</asp:ListItem>
                     <asp:ListItem>Utah</asp:ListItem>
                     <asp:ListItem>Vermont</asp:ListItem>
                     <asp:ListItem>Virginia</asp:ListItem>
                     <asp:ListItem>Virgin Islands</asp:ListItem>
                     <asp:ListItem>Washington</asp:ListItem>
                     <asp:ListItem>West Virginia</asp:ListItem>
                     <asp:ListItem>Wisconsin</asp:ListItem>
                     <asp:ListItem>Wyoming</asp:ListItem>
                 </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionSpecialtyLabel" runat="server">Specialty: <br /></asp:Label>
                <asp:TextBox ID="PractitionerProfessionSpecialty" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionCurrentRadioButtonListLabel" runat="server">Currently working here?<br /></asp:Label>
                <asp:RadioButtonList ID="PractitionerProfessionCurrentRadioButtonList" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>
            </p>
            <p>
                <asp:Label ID="PractitionerYearsInLabel" runat="server">Years In Profession:<br /></asp:Label>
                <asp:TextBox ID="PractitionerYearsInLabelText" runat="server"></asp:TextBox>        
            </p>
        <asp:Button ID="PractitionerProfessionAddButton" runat="server" Text="add" OnClick="PractitionerProfessionAddButton_Click" /> &nbsp &nbsp
        <asp:Button ID="PractitionerProfessionUpdateButton" runat="server" Text="update" OnClick="PractitionerProfessionUpdateButton_Click" /> &nbsp &nbsp
        <asp:Button ID="PractitionerProfessionDeleteButton" runat="server" Text="delete" OnClick="PractitionerProfessionDeleteButton_Click" /> <br />
        <asp:Button ID="PractitionerProfessionClearButton" runat="server" Text="add another record" OnClick="PractitionerProfessionClearButton_Click" /> <br />
    

    <h2>Bio & Interests</h2>
        <asp:TextBox ID="BioTextArea" TextMode="multiline" columns="40" Rows="5" placeholder="Add bio/interests..." runat="server"></asp:TextBox>
    <br /><br />
        <asp:Button ID="PractitionerBioButton" runat="server" Text="save" OnClick="PractitionerBioButton_Click" />
    </>

</asp:Content>