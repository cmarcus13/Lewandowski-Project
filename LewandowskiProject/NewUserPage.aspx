<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewUserPage.aspx.cs" Inherits="LewandowskiProject.NewUserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>New User Registration</h2>
    </div>

    <div>
        <h4>Please complete form. You will be notified by the Pre-Health Office if you are granted access.</h4>
    </div>
    <div id="wrapper">
        <div id="left">
            <h3>Personal Information: </h3>
            <asp:Label ID="userTypeLabel" runat="server" Text="User Type:"></asp:Label>
            <asp:RadioButtonList ID="userTypeRadioButtonList" runat="server">
                <asp:ListItem Value="0">Student</asp:ListItem>
                <asp:ListItem Value="1">Practitioner</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="userTypeRadioButtonList"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The user type field is required." />
            <br />
            <asp:Label ID="firstNameLabel" runat="server" Text="First Name: "></asp:Label>
            <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="firstNameTextBox"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The first name field is required." />
            <br />
            <asp:Label ID="lastNameLabel" runat="server" Text="Last Name: "></asp:Label>
            <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="lastNameTextBox"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The last name field is required." />
            <br />
            <asp:Label ID="suffixLabel" runat="server" Text="Suffix: "></asp:Label>
            <asp:TextBox ID="suffixTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="suffixTextBox"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The suffix field is required." />
            <br />
            <asp:Label ID="titleLabel" runat="server" Text="Label: "></asp:Label>
            <asp:TextBox ID="titleTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="titleTextBox"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The title field is required." />
            <br />
            <asp:Label ID="genderLabel" runat="server" Text="Gender:"></asp:Label>
            <asp:RadioButtonList ID="genderRadioButtonList" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="genderRadioButtonList"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The gender field is required." />
            <br />
            <asp:Label ID="cityLabel" runat="server" Text="City: "></asp:Label>
            <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="cityTextBox"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The city field is required." />
            <br />
            <asp:Label ID="stateLabel" runat="server" Text="State:"></asp:Label>
            <br />
            <asp:DropDownList ID="stateDropDownList" runat="server">
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
            <asp:RequiredFieldValidator runat="server" ControlToValidate="stateDropDownList"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The state field is required." />
            <br />
            <asp:Label ID="bioLabel" runat="server" Text="Bio: "></asp:Label>
            <br />
            <asp:TextBox ID="bioTextArea" TextMode="multiline" columns="40" Rows="5" placeholder="Add bio/interests..." runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="bioTextArea"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The state field is required." />
        </div>
        <div id="right">
            <h3>User Login Credentials: </h3>
            <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label> 
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator runat="server" ControlToValidate="emailTextBox"
                        CssClass="text-danger" ErrorMessage="The email field is required." />
            <br />
            <asp:Label ID="passwordLabel" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="passwordTextBox"
                       CssClass="text-danger" ErrorMessage="The password field is required." />
            <br />
            <asp:Label ID="passwordConfirmLabel" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="confirmPasswordTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPasswordTextBox"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="passwordTextBox" ControlToValidate="confirmPasswordTextBox"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
        </div>
        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
    </div>
</asp:Content>
