<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PractitionerPage.aspx.cs" Inherits="LewandowskiProject.PractitionerPage" %>
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
                 <asp:DropDownList ID="StateDropDownList" runat="server">
                     <asp:ListItem>--Pick a state--</asp:ListItem>
                     <asp:ListItem>Alabama</asp:ListItem>
                     <asp:ListItem>Alaska</asp:ListItem>
                     <asp:ListItem>Arizona</asp:ListItem>
                     <asp:ListItem>Arkansas</asp:ListItem>
                     <asp:ListItem>California</asp:ListItem>
                     <asp:ListItem>Colorado</asp:ListItem>
                     <asp:ListItem>Connecticut</asp:ListItem>
                     <asp:ListItem>Delaware</asp:ListItem>
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
                     <asp:ListItem>Rhode Island</asp:ListItem>
                     <asp:ListItem>South Carolina</asp:ListItem>
                     <asp:ListItem>South Dakota</asp:ListItem>
                     <asp:ListItem>Tennessee</asp:ListItem>
                     <asp:ListItem>Texas</asp:ListItem>
                     <asp:ListItem>Utah</asp:ListItem>
                     <asp:ListItem>Vermont</asp:ListItem>
                     <asp:ListItem>Virginia</asp:ListItem>
                     <asp:ListItem>Washington</asp:ListItem>
                     <asp:ListItem>West Virginia</asp:ListItem>
                     <asp:ListItem>Wisconsin</asp:ListItem>
                     <asp:ListItem>Wyoming</asp:ListItem>
                 </asp:DropDownList>
            </p> 

        <%--<h2>Education:</h2>
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
            <p> Degree Earned in: <br />
                <input id="UndergradDegreeEarnedIn" type="text" />
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
            </p>--%>
    <h2>Education:</h2>
            <p>School Name: <br />
                <input id="SchoolNameText" type="text" />
            </p>
            <p>Graduation Year:<br />
                <input id="GradYearText" type="text" placeholder="ex: yyyy" />
            </p>
            <p>Degree Earned:<br />
                <asp:DropDownList ID="DegreeEarnedDropDownList" runat="server">
                    <asp:ListItem>Associates</asp:ListItem>
                    <asp:ListItem>Bachelors</asp:ListItem>
                    <asp:ListItem>Masters</asp:ListItem>
                    <asp:ListItem>Doctorate</asp:ListItem>
                    <asp:ListItem>Medical School</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>Degree Earned in: <br />
               <input id="ExpertiseText" type="text" />
            </p>
    <p><b>Add more Education + </b></p>

   <%-- <h2>Experience:</h2>
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
            </p>--%>

     <h2>Internships/Residencies/Fellowships:</h2>
            <p>Type of experience: <br />
                <asp:DropDownList ID="InternshipsDropDownList" runat="server">
                    <asp:ListItem>Internship</asp:ListItem>
                    <asp:ListItem>Residency</asp:ListItem>
                    <asp:ListItem>Fellowship</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>Name/Title: <br />
                <input id="InternshipName/Title" type="text" />
            </p>
            <p>Area of Expertise: <br />
                <asp:DropDownList ID="InternshipsAreaDropDownList" runat="server">
                    <asp:ListItem>--Pick one--</asp:ListItem>
                    <asp:ListItem>Dentistry</asp:ListItem>
                    <asp:ListItem>Surgery</asp:ListItem>
                    <asp:ListItem>Etc...</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>Name of institute: <br />
                <input id="InternshipInstituteNameText" type="text" />
            </p>
            <p>City: <br />
                <input id="InstituteCity" type="text" />
            </p>
            <p>State: <br />
                <asp:DropDownList ID="InstituteStateDropDownList" runat="server">
                     <asp:ListItem>--Pick a state--</asp:ListItem>
                     <asp:ListItem>Alabama</asp:ListItem>
                     <asp:ListItem>Alaska</asp:ListItem>
                     <asp:ListItem>Arizona</asp:ListItem>
                     <asp:ListItem>Arkansas</asp:ListItem>
                     <asp:ListItem>California</asp:ListItem>
                     <asp:ListItem>Colorado</asp:ListItem>
                     <asp:ListItem>Connecticut</asp:ListItem>
                     <asp:ListItem>Delaware</asp:ListItem>
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
                     <asp:ListItem>Rhode Island</asp:ListItem>
                     <asp:ListItem>South Carolina</asp:ListItem>
                     <asp:ListItem>South Dakota</asp:ListItem>
                     <asp:ListItem>Tennessee</asp:ListItem>
                     <asp:ListItem>Texas</asp:ListItem>
                     <asp:ListItem>Utah</asp:ListItem>
                     <asp:ListItem>Vermont</asp:ListItem>
                     <asp:ListItem>Virginia</asp:ListItem>
                     <asp:ListItem>Washington</asp:ListItem>
                     <asp:ListItem>West Virginia</asp:ListItem>
                     <asp:ListItem>Wisconsin</asp:ListItem>
                     <asp:ListItem>Wyoming</asp:ListItem>
                 </asp:DropDownList>
            </p>
            <p>Description: <br />
                <textarea id="InternshipTextArea" cols="20" rows="2"></textarea>
            </p>
           
            <p>Currently working here?<br />
                <asp:RadioButton ID="InternshipRadioButtonYes" runat="server" />Yes
                <asp:RadioButton ID="InternshipRadioButtonNo" runat="server" />No
            </p>
    <p><b>Add more experience + </b></p>

    <h2>Profession:</h2>
            <p>Name/Title: <br />
                <input id="ProfessionName/Title" type="text" />
            </p>
            <p>Area of Expertise: <br />
                <asp:DropDownList ID="ProfessionDropDownList" runat="server">
                    <asp:ListItem>--Pick one--</asp:ListItem>
                    <asp:ListItem>Dentistry</asp:ListItem>
                    <asp:ListItem>Surgery</asp:ListItem>
                    <asp:ListItem>Etc...</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>Name of company: <br />
                <input id="ProfessionLocationText" type="text" />
            </p>
            <p>City: <br />
                <input id="ProfessionCity" type="text" />
            </p>
            <p>State: <br />
                <asp:DropDownList ID="ProfessionStateDropDownList" runat="server">
                     <asp:ListItem>--Pick a state--</asp:ListItem>
                     <asp:ListItem>Alabama</asp:ListItem>
                     <asp:ListItem>Alaska</asp:ListItem>
                     <asp:ListItem>Arizona</asp:ListItem>
                     <asp:ListItem>Arkansas</asp:ListItem>
                     <asp:ListItem>California</asp:ListItem>
                     <asp:ListItem>Colorado</asp:ListItem>
                     <asp:ListItem>Connecticut</asp:ListItem>
                     <asp:ListItem>Delaware</asp:ListItem>
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
                     <asp:ListItem>Rhode Island</asp:ListItem>
                     <asp:ListItem>South Carolina</asp:ListItem>
                     <asp:ListItem>South Dakota</asp:ListItem>
                     <asp:ListItem>Tennessee</asp:ListItem>
                     <asp:ListItem>Texas</asp:ListItem>
                     <asp:ListItem>Utah</asp:ListItem>
                     <asp:ListItem>Vermont</asp:ListItem>
                     <asp:ListItem>Virginia</asp:ListItem>
                     <asp:ListItem>Washington</asp:ListItem>
                     <asp:ListItem>West Virginia</asp:ListItem>
                     <asp:ListItem>Wisconsin</asp:ListItem>
                     <asp:ListItem>Wyoming</asp:ListItem>
                 </asp:DropDownList>
            </p>
            <p>Specialty: <br />
                <input id="ProfessionSpecialty" type="text" />
            </p>
            <p>Currently working here?<br />
                <asp:RadioButton ID="ProfessionRadioButtonYes" runat="server" />Yes
                <asp:RadioButton ID="ProfessionRadioButtonNo" runat="server" />No
            </p>
    <p><b>Add more Professions + </b></p>

    <h2>Bio & Interests</h2>
    <textarea id="BioTextArea" cols="40" rows="5">Add Bio/Interests...</textarea>
    <br /><br />

    <input id="UpdatePractitionerProfileButton" type="submit" value="update" />


</asp:Content>
