﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PractitionerProfile.aspx.cs" Inherits="Lewandowski_Project.Account.PractitionerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="jumbotron">
        <h1>Med School Tool</h1>
        <p class="lead">Practioner Profile</p>
    </div>
    
    <input id="profilePicture" type="file" />

    <div class="row">
        <div class="col-md-4">
            <p>Full Name: <br />
                <input id="FullName" type="text" />
            </p>
            <p>Graduation Year: <br />
                 <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>1996</asp:ListItem>
                        <asp:ListItem>1997</asp:ListItem>
                        <asp:ListItem>1998</asp:ListItem>
                        <asp:ListItem>1999</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>
        <div class="col-md-4">
            <p>Profession: <br />
                <input id="Profession" type="text" />
            </p> 
            <p>Email: <br />
                <input id="Email" type="text" />
            </p>
        </div>
    </div>
    <textarea id="BioTextArea" cols="40" rows="5">Add Bio</textarea>
    <br /><br />

    <input id="SubmitProfile" type="submit" value="submit" />
</asp:Content>
