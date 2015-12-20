<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutesAdd.aspx.cs" Inherits="strpo_app.Admin.RoutesAdd" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Add route</h2>
 
        <uc:RoutesControl ID="routesControl" runat="server"/> <br /> <br />
        
        <asp:Button runat="server" ID="button_add" Text="Add" OnClick="button_add_Click" />
        <asp:Button runat="server" ID="button_back" Text="Back" OnClick="button_back_Click" /> <br /> <br />

        <p ID="statusLabel" runat="server"></p>

</asp:Content>