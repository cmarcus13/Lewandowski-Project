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

            <asp:GridView ID="PractitionerGridView" runat="server" Width="500px" Height="500px" HorizontalAlign="Center">
                <Columns>
                    <asp:ButtonField Text="View Full Profile" HeaderText="More Practitioner Information" />
                </Columns>
            </asp:GridView>

            <cc1:ModalPopupExtender ID="PractitionerGridView_ModalPopupExtender" runat="server" BehaviorID="PractitionerGridView_ModalPopupExtender" DynamicServicePath="" TargetControlID="AjaxFunctionalityEater" PopupControlID="PractitionerModalPanel">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="PractitionerModalPanel" runat="server" Width="500px" CssClass="ProfilePopup">
            
                <h3>Practitioner Profile</h3>

                <h2>Personal Information:</h2>
            <p>
                <asp:Label ID="PractitionerFirstNameLabel" runat="server">First Name: <br /></asp:Label><%--First Name: <br />--%>
                <%--<input id="PractitionerFirstNameInput" type="text" />--%>
                <asp:TextBox ID="PractitionerFirstName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerLastNameLabel" runat="server">Last Name: <br /> </asp:Label>
                <%--<input id="PractitionerLastName" type="text" />--%>
                <asp:TextBox ID="PractitionerLastName" runat="server"></asp:TextBox>
            </p>
             <p>
                 <asp:Label ID="PractitionerGenderRadioButtonListLabel" runat="server">Gender:</asp:Label>
                 <asp:RadioButtonList ID="PractitionerGenderRadioButtonList" runat="server">
                     <asp:ListItem>Female</asp:ListItem>
                     <asp:ListItem>Male</asp:ListItem>
                 </asp:RadioButtonList>
                 <%--<input id="PractitionerFemale" type="radio" />Female
                 <input id="PractitionerMale" type="radio" />Male--%>
            </p> 
            <p>
                <asp:Label ID="PractitionerPhoneNumberLabel" runat="server">Phone Number: <br /></asp:Label> 
                <asp:TextBox ID="PractitionerPhoneNumber" runat="server"></asp:TextBox>
                <%--<input id="PractitionerPhoneNumber" type="text" />--%>
            </p>
             <p>
                 <asp:Label ID="PractitionerEmailLabel" runat="server">Email: <br /></asp:Label>
                 <asp:TextBox ID="PractitionerEmail" runat="server"></asp:TextBox>
               <%-- <input id="PractitionerEmail" type="text" />--%>
            </p> 
             <p>
                 <asp:Label ID="PractitionerCityLabel" runat="server">City: <br /></asp:Label>
                 <asp:TextBox ID="PractitionerCity" runat="server"></asp:TextBox>
                <%--<input id="PractitionerCity" type="text" />--%>
            </p> 
             <p>
                 <asp:Label ID="PractitionerPersonalInformationStateDropDownListLabel" runat="server">State: <br /></asp:Label>
                 <asp:DropDownList ID="PractitionerPersonalInformationStateDropDownList" runat="server">
                     <asp:ListItem>--Pick a state--</asp:ListItem>
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
            <asp:Button ID="PractitionerPersonalInfoSaveButton" runat="server" Text="save" OnClick="PractitionerPersonalInfoSaveButton_Click" />
                <h2>Education:</h2>
            <p>
                <asp:DropDownList ID="PractitionerAddEducationDropDownList" runat="server">
                    <asp:listitem>Add education...</asp:listitem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationSchoolNameTextLabel" runat="server">School Name: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationSchoolNameText" runat="server"></asp:TextBox>
                <%--<input id="PractitionerEducationSchoolNameText" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationYearInLabel" runat="server">Year In School: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationYearInText" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationGradYearTextLabel" runat="server">Graduation Year:<br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationGradYearText" runat="server" placeholder="yyyy"></asp:TextBox>
                <%--<input id="PractitionerEducationGradYearText" type="text" placeholder="ex: yyyy" />--%>
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
                <asp:Label ID="PractitionerEducationExpertiseTextLabel" runat="server">Degree Earned in/Major: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationExpertiseText" runat="server"></asp:TextBox>
               <%--<input id="PractitionerEducationExpertiseText" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerEducationMinorTextLabel" runat="server">Minor: <br /></asp:Label>
                <asp:TextBox ID="PractitionerEducationMinorText" runat="server"></asp:TextBox>

                <h2>Internships/Residencies/Fellowships:</h2>
            <p>
                <asp:DropDownList ID="PractitionerAddInternshipsDropDownList" runat="server">
                    <asp:ListItem>Add Internships/Residencies/Fellowships...</asp:ListItem>
                </asp:DropDownList>
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
                <%--<input id="PractitionerInternshipName/Title" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsAreaDropDownListLabel" runat="server">Area of Expertise: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerInternshipsAreaDropDownList" runat="server">
                    <asp:ListItem>--Pick one--</asp:ListItem>
                    <asp:ListItem>Dentistry</asp:ListItem>
                    <asp:ListItem>Surgery</asp:ListItem>
                    <asp:ListItem>Etc...</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsInstituteNameTextLabel" runat="server">Name of institute: <br /></asp:Label>
                <asp:TextBox ID="PractitionerInternshipsInstituteNameText" runat="server"></asp:TextBox>
                <%--<input id="PractitionerInternshipsInstituteNameText" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsInstituteCityLabel" runat="server">City: <br /></asp:Label>
                <asp:TextBox ID="PractitionerInternshipsInstituteCity" runat="server"></asp:TextBox>
               <%-- <input id="PractitionerInternshipsInstituteCity" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerInternshipsInstituteStateDropDownListLabel" runat="server">State: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerInternshipsInstituteStateDropDownList" runat="server">
                     <asp:ListItem>--Pick a state--</asp:ListItem>
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
                <%--<textarea id="PractitionerInternshipsTextArea" cols="20" rows="2"></textarea>--%>
            </p>
           
            <p>
                <asp:Label ID="PractitionerInternshipsCurrentRadioButtonListLabel" runat="server">Currently working here?<br /></asp:Label>
                <asp:RadioButtonList ID="PractitionerInternshipsCurrentRadioButtonList" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>

                <h2>Profession:</h2>
            <p>
                <asp:DropDownList ID="PractitionerAddPrfessionDropDownList" runat="server">
                    <asp:ListItem>Add Profession...</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionNameOrTitleLabel" runat="server">Name/Title: <br /></asp:Label>
                <asp:TextBox ID="PractitionerProfessionNameOrTitle" runat="server"></asp:TextBox>
                <%--<input id="PractitionerProfessionName/Title" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionDropDownListLabel" runat="server">Area of Expertise: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerProfessionDropDownList" runat="server">
                    <asp:ListItem>--Pick one--</asp:ListItem>
                    <asp:ListItem>Dentistry</asp:ListItem>
                    <asp:ListItem>Surgery</asp:ListItem>
                    <asp:ListItem>Etc...</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionLocationTextLabel" runat="server">Name of company: <br /></asp:Label>
                <asp:TextBox ID="PractitionerProfessionLocationText" runat="server"></asp:TextBox>
                <%--<input id="PractitionerProfessionLocationText" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionCityLabel" runat="server">City: <br /></asp:Label>
                <asp:TextBox ID="PractitionerProfessionCity" runat="server"></asp:TextBox>
                <%--<input id="PractitionerProfessionCity" type="text" />--%>
            </p>
            <p><asp:Label ID="PractitionerProfessionStateDropDownListLabel" runat="server">State: <br /></asp:Label>
                <asp:DropDownList ID="PractitionerProfessionStateDropDownList" runat="server">
                     <asp:ListItem>--Pick a state--</asp:ListItem>
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
                <%--<input id="PractitionerProfessionSpecialty" type="text" />--%>
            </p>
            <p>
                <asp:Label ID="PractitionerProfessionCurrentRadioButtonListLabel" runat="server">Currently working here?<br /></asp:Label>
                <asp:RadioButtonList ID="PractitionerProfessionCurrentRadioButtonList" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>
                <%--<asp:RadioButton ID="PractitionerProfessionRadioButtonYes" runat="server" />Yes
                <asp:RadioButton ID="PractitionerProfessionRadioButtonNo" runat="server" />No--%>
            </p>
            <p>
                <asp:Label ID="PractitionerYearsInLabel" runat="server">Years In Profession:<br /></asp:Label>
                <asp:TextBox ID="PractitionerYearsInLabelText" runat="server"></asp:TextBox>        
            </p>
                <h2>Bio & Interests</h2>
        <asp:TextBox ID="TextBox1" TextMode="multiline" columns="40" Rows="5" placeholder="Add bio/interests..." runat="server"></asp:TextBox>

                <asp:Button ID="PractitionerCloseButton" runat="server" Text="Close" OnClick="PractitionerCloseButton_Click" />
                </asp:Panel>

            </div>
        </section>
    </div>
    <br />
</asp:Content>