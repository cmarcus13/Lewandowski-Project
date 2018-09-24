<%@ Page Title="Student Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="Lewandowski_Project.Account.StudentProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="Image1" runat="server" />
    <br />
    <asp:Button ID="UpdateImageButton" runat="server" Text="UpdateImage" />
    <br />
    <br />
    <asp:Label ID="FirstNameLabel" runat="server" Text="First Name: "></asp:Label>
    <asp:TextBox ID="FirstNameTextbox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ClassLabel" runat="server" Text="Class Year: "></asp:Label>

    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>2019</asp:ListItem>
        <asp:ListItem>2020</asp:ListItem>
        <asp:ListItem>2021</asp:ListItem>
        <asp:ListItem>2022</asp:ListItem>
    </asp:DropDownList>

    <br />
    <asp:Label ID="MajorLabel" runat="server" Text="Major: "></asp:Label>
    <asp:TextBox ID="MajorTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="EmailLabel" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="SubmitButton" runat="server" Text="Submit Changes" />
</asp:Content>
