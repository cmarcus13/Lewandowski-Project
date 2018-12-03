<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="LewandowskiProject.AdminPage" %>
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
            height: 600px;
        }
        .SizeOfText{
            font-size: 110%;
        }
    </style>
    
    <div class="jumbotron">
        <h1>Admin Page</h1>
    </div>

     <cc1:ModalPopupExtender ID="mpe" runat="server" TargetControlId="AjaxFunctionalityEater"
        PopupControlID="ModalPanel" BackgroundCssClass="Background" />

    <h4>Please review the pending users below.</h4>
     <br /> <br />
     <asp:GridView ID="NewUsersGridView" runat="server" Width="900px" Height="70px" 
                    HorizontalAlign="Center" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="10" CellSpacing="3">
                    <Columns>
                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btnViewUserProfile" runat="server" Text="View More" OnClick="BtnViewUserProfile_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>           
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" Width="1000px" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
     </asp:GridView>
    
    <asp:HiddenField ID="AjaxFunctionalityEater" runat="server" />
    <cc1:ModalPopupExtender ID="UserModalPopupExtender" runat="server" TargetControlId="AjaxFunctionalityEater"
        PopupControlID="ModalPanel" BackgroundCssClass="Background" />
    <asp:Panel ID="ModalPanel" runat="server" Width="500px" CssClass="ProfilePopup">
        <h3>View Information</h3>
        <asp:HiddenField ID="userIdHiddenField" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="User Type: " Font-Bold="true"></asp:Label>
        <asp:Label ID="UserTypeLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="First Name: " Font-Bold="true"></asp:Label>
        <asp:Label ID="FirstNameLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Last Name: " Font-Bold="true"></asp:Label>
        <asp:Label ID="LastNameLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Suffix: " Font-Bold="true"></asp:Label>
        <asp:Label ID="SuffixLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label5" runat="server" Text="Title: " Font-Bold="true"></asp:Label>
        <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label6" runat="server" Text="Bio: " Font-Bold="true"></asp:Label>
        <asp:Label ID="BioLabel" runat="server" Text="" TextMode="multiline"></asp:Label>
        <br /><br />
        <asp:Label ID="Label7" runat="server" Text="City: " Font-Bold="true"></asp:Label>
        <asp:Label ID="CityLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label8" runat="server" Text="State: " Font-Bold="true"></asp:Label>
        <asp:Label ID="StateLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label9" runat="server" Text="Gender: " Font-Bold="true"></asp:Label>
        <asp:Label ID="GenderLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="Label10" runat="server" Text="Email: " Font-Bold="true"></asp:Label>
        <asp:Label ID="EmailLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:HiddenField ID="passwordHiddenField" runat="server" />
        <br /><br />
        <asp:Button ID="acceptUser" runat="server" Text="Accept" OnClick="acceptUser_Click" />
        <br />
        <asp:Button ID="denyUser" runat="server" Text="Deny" OnClick="denyUser_Click" />
        <br /><br />
        <asp:Button ID="CloseButton" runat="server" Text="Close" OnClick="CloseButton_Click" />
        <br /><br />
    </asp:Panel>
</asp:Content>
