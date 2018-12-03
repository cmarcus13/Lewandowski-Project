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
        .SizeOfText{
            font-size: 110%;
            width: 170%;
            padding-left: 1em;
            padding-right: 1em;
            text-align: center;
        }
    </style>
    
    <div class="jumbotron">
        <h2>Student Profile</h2>
    </div>

    <asp:HiddenField ID="AjaxFunctionalityEater" runat="server" />
     <cc1:ModalPopupExtender ID="mpe" runat="server" TargetControlId="AjaxFunctionalityEater"
        PopupControlID="ModalPanel" BackgroundCssClass="Background" />
    <asp:Button ID="ClientButton" runat="server" Text="Edit Profile" OnClick="ClientButton_Click" />
    <asp:Panel ID="ModalPanel" runat="server" Height="350px" Width="500px" CssClass="ProfilePopup">
        <h3>Edit Profile</h3>
       
        <asp:Label ID="EmailLabel" runat="server" Text="Email: "></asp:Label>
        <br /><br />     
        <asp:Label ID="FNameLabel" runat="server" Text="First Name:"></asp:Label>
        &nbsp;<asp:TextBox ID="FNameTextBox" runat="server"></asp:TextBox><br /><br />
        
        <asp:Label ID="LNameLabel" runat="server" Text="Last Name:"></asp:Label>
        &nbsp;<asp:TextBox ID="LNameTextBox" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="BioLabel" runat="server" Text="Bio: "></asp:Label>
        <asp:Textbox id="BioTextArea" runat="server" placeholder="Add Bio" cols="55" rows="5" Height="93px" TextMode="MultiLine" Width="270px"></asp:Textbox>
        <br /><br />
        <asp:Button ID="CloseButton" runat="server" Text="Close" OnClick="CloseButton_Click" />
    </asp:Panel>
<br />
        <section style="display:flex; margin-top:5px">
        <div style="margin:5px,5px,5px,0; flex:1; background-color:#EAEAEA" class="SizeOfText">
            <b>
                <asp:Label ID="filter" runat="server" Text="Search for a Professional Partner" style="margin:5px" Font-Size="Larger"></asp:Label>
            </b>
            <br />
            <br />
        <asp:Button ID="searchButton" runat="server" Text="Go" Height="28px" />
        &nbsp;<asp:Button ID="resetButton" runat="server" Text="Reset List" OnClick="resetButton_Click" Height="29px" />
            &nbsp;Reset List to start a new search.<br />
            <br />
            Explore Professional Partners By First or Last Name  <asp:TextBox ID="searchTextBox" placeholder="Search Alumni" width="800px" runat="server" OnTextChanged="searchTextBox_TextChanged"></asp:TextBox>
            <br />
            <br />
            Search by City  <asp:TextBox ID="cityTextBox" runat="server" width="500px" placeholder="Search City" OnTextChanged="cityTextBox_TextChanged"></asp:TextBox>
            <br />
            <br />
            Search by Graduation Year  <asp:TextBox ID="yearTextBox" runat="server" width="241px" placeholder="Search Year" OnTextChanged="yearTextBox_TextChanged"></asp:TextBox>
            <br />
            <br /> 
            <asp:DropDownList ID="stateDropDown" runat="server" style="margin:5px" OnSelectedIndexChanged="stateDropDown_SelectedIndexChanged">
                <asp:ListItem>Select State</asp:ListItem>
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
            <asp:DropDownList ID="professionDropDown" runat="server" style="margin:5px" OnSelectedIndexChanged="professionDropDown_SelectedIndexChanged">
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
            <div style="padding-left:5px; flex:3; position:relative">

             <asp:GridView ID="PractitionerGridView" runat="server" Width="900px" Height="70px" 
                HorizontalAlign="Center" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="10" CellSpacing="3">
                <Columns>
                    <asp:TemplateField >
                     <ItemTemplate>
                         <asp:Button ID="btnViewPractitionerProfile" runat="server" Text="View Full Profile" OnClick="BtnViewPractitionerProfile_Click"/>
                     </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#0A4068" Font-Bold="True" ForeColor="#E9B820" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" Width="1000px" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
            
            <cc1:ModalPopupExtender ID="PractitionerGridView_ModalPopupExtender" runat="server"
                TargetControlID="AjaxFunctionalityEater" PopupControlID="PractitionerModalPanel">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="PractitionerModalPanel" runat="server" Width="500px" Height="650px" CssClass="ProfilePopup">
            <div id="Div1" runat="server" style="max-height: 600px; overflow: auto;">
                <h2>Practitioner Profile</h2>

                <h4><b>Personal Information:</b></h4>
            <p>
                <asp:Label ID="PractitionerFirstNameLabel" runat="server">First Name: </asp:Label>      
            <br />
                <asp:Label ID="PractitionerLastNameLabel" runat="server">Last Name:  </asp:Label>                
            <br />             
                 <asp:Label ID="PractitionerGenderLabel" runat="server">Gender: </asp:Label>
            <br />
                <asp:Label ID="PractitionerPhoneNumberLabel" runat="server">Phone Number: </asp:Label> 
            <br />
                 <asp:Label ID="PractitionerEmailLabel" runat="server">Email: </asp:Label>
            <br />
                 <asp:Label ID="PractitionerCityLabel" runat="server">City: </asp:Label>
            <br />
                 <asp:Label ID="PractitionerStateLabel" runat="server">State: </asp:Label> <br />

                <asp:Label ID="PractitionerAcceptsStudents" runat="server">Currently Accepting Students: </asp:Label>

            </p>                

                <h4><b>Education:</b></h4>
            <p>
                <asp:Label ID="PractitionerSchoolNameLabel" runat="server">Educational Experiences: </asp:Label>
                <asp:DropDownList ID="PractitionerAddEducationDropDownList" runat="server" Height="20px" Width="218px" OnSelectedIndexChanged="PractitionerAddEducationDropDownList_SelectedIndexChanged" AutoPostBack ="true"/>
          <br />   
                <asp:Label ID="PractitionerEducationYearInLabel" runat="server">Year In School: </asp:Label>          
          <br />
                <asp:Label ID="PractitionerEducationGradYearTextLabel" runat="server">Graduation Year: </asp:Label>
          <br />
                <asp:Label ID="PractitionerEducationDegreeEarnedDropDownListLabel" runat="server">Degree Earned: </asp:Label>                
          <br />
                <asp:Label ID="PractitionerEducationMajorLabel" runat="server">Degree Earned in/Major: </asp:Label>
          <br />
                <asp:Label ID="PractitionerEducationMinorTextLabel" runat="server">Minor: </asp:Label>
            </p>

     <h4><b>Internships/Residencies/Fellowships:</b></h4>
            <p>
                <asp:Label ID="PractitionerInternshipsDropDownListLabel" runat="server">Professional Health Experiences: </asp:Label>
                <asp:DropDownList ID="PractitionerAddInternshipsDropDownList" runat="server" OnSelectedIndexChanged="PractitionerAddInternshipsDropDownList_SelectedIndexChanged" AutoPostBack ="true" Width="250px" />
            <br />              
                <asp:Label ID="PractitionerExperiencesLabel" runat="server">Type of Experience: </asp:Label>                
            <br />
                <asp:Label ID="PractitionerInternshipNameOrTitleLabel" runat="server">Name/Title: </asp:Label>               
            <br />
                <asp:Label ID="PractitionerInternshipsAreaDropDownListLabel" runat="server">Area of Expertise: </asp:Label>
            <br />            
                <asp:Label ID="PractitionerInternshipsInstituteNameTextLabel" runat="server">Name of Institute: </asp:Label>
            <br />                
                <asp:Label ID="PractitionerInternshipsInstituteCityLabel" runat="server">City: </asp:Label>
            <br />
                <asp:Label ID="PractitionerInternshipsInstituteStateDropDownListLabel" runat="server">State: </asp:Label>                
           <br />
                <asp:Label ID="PractitionerInternshipsTextAreaLabel" runat="server">Description: </asp:Label>
           <br />
                <asp:Label ID="PractitionerInternshipsCurrentRadioButtonListLabel" runat="server">Currently Working at This Position: </asp:Label>                
            </p>

    <h4><b>Professions:</b></h4>
            <p>
                <asp:Label ID="ProfessionsListLabel" runat="server">Professions: </asp:Label>
                <asp:DropDownList ID="PractitionerAddPrfessionDropDownList" runat="server" OnSelectedIndexChanged="PractitionerAddPrfessionDropDownList_SelectedIndexChanged" AutoPostBack ="true" Width="151px" />
                <br />
                <asp:Label ID="PractitionerProfessionNameOrTitleLabel" runat="server">Name/Title: </asp:Label>
                <br />
                <asp:Label ID="PractitionerProfessionDropDownListLabel" runat="server">Area of Expertise: </asp:Label>
                <br />
                <asp:Label ID="PractitionerProfessionLocationTextLabel" runat="server">Company Name: </asp:Label>
                <br />
                <asp:Label ID="PractitionerProfessionCityLabel" runat="server">City: </asp:Label>
                <br />
            <asp:Label ID="PractitionerProfessionStateDropDownListLabel" runat="server">State: </asp:Label>
                <br />
                <asp:Label ID="PractitionerProfessionSpecialtyLabel" runat="server">Specialty: </asp:Label>
                <br />
                <asp:Label ID="PractitionerProfessionCurrentRadioButtonListLabel" runat="server">Currently Working at This Position: </asp:Label>
                <br />
                <asp:Label ID="PractitionerYearsInLabel" runat="server">Years In Profession: </asp:Label>       
            </p>

    <h4><b>Bio & Interests:</b></h4>
        <asp:TextBox ID="PractitionerBioTextArea" TextMode="multiline" columns="40" Rows="5" placeholder="Add bio/interests..." runat="server" ReadOnly="true"></asp:TextBox>
     <br /><br />
                <asp:Button ID="PractitionerCloseButton" runat="server" Text="Close" OnClick="PractitionerCloseButton_Click" />
                </div> 
                </asp:Panel>
            </div>
        </section>
    <br />
</asp:Content>
