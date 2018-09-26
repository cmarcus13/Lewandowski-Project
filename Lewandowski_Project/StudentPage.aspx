<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="Lewandowski_Project.Account.StudentProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Student Profile</h1>
    </div>
    <div>
        <h1>Search People Here</h1>
        <asp:ListView ID="usersListView" runat="server">
             <ItemTemplate>
                <div>
                    <asp:Label ID="UserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
               </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="row">
        <div class="col-md-4">
            <p>Name: <br />
                <input type="text" />
            </p> 
            <p>Email: <br />
                <input type="text" />
            </p>
            <p>Phone Number: <br />
                <input type="text" />
            </p>
        </div>
    </div>
    <br /><br />

    <input id="UpdateProfileButton" type="submit" value="update" />
</asp:Content>
