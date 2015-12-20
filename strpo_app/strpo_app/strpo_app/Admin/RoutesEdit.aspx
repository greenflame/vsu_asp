<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutesEdit.aspx.cs" Inherits="strpo_app.Admin.WebForm1" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit route</h2>
     
    <uc:RoutesControl ID="routesControl" runat="server" /> <br /> <br />

    <asp:Button runat="server" ID="button_update" Text="Update" OnClick="button_update_Click" />
    <asp:Button runat="server" ID="button_back" Text="Back" OnClick="button_back_Click" /> <br /> <br />

    <p runat="server" id="statusLabel"></p>

</asp:Content>
