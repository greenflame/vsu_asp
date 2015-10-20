<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutesEdit.aspx.cs" Inherits="strpo_app.Admin.WebForm1" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Edit route form--%>
    <h2 runat="server" id="label">Edit route</h2>
     
    <p>Name</p>
    <asp:TextBox runat="server" ID="textBox_name"></asp:TextBox>
    <p>Description</p>
    <asp:TextBox runat="server" ID="textBox_description"></asp:TextBox>
    <br />
    <br />
    <asp:Button runat="server" ID="button_update" Text="Update" OnClick="button_update_Click" />
    <asp:Button runat="server" ID="button_back" Text="Back" OnClick="button_back_Click" />

    <%--Status labbel--%>
    <br />
    <br />
    <p runat="server" id="statusLabel"></p>

</asp:Content>
