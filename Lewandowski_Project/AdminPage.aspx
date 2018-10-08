<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Lewandowski_Project.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="usersListView" runat="server">
         <ItemTemplate>
            <div>
                <asp:Label ID="UserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
           </div>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <asp:Label ID="UserLabel" runat="server" Text="User:"></asp:Label>
&nbsp;<asp:TextBox ID="UserTextBox" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="NameLabel" runat="server" Text="Name:"></asp:Label>
&nbsp;<asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>
&nbsp;<asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="PhoneLabel" runat="server" Text="Phone:"></asp:Label>
&nbsp;<asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox><br /><br />

    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Add" />
&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Update" />
&nbsp;
    <asp:Button ID="Button3" runat="server" Text="Delete" />

</asp:Content>
