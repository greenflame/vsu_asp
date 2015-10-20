<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutesView.aspx.cs" Inherits="strpo_app.Admin.Routes" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Table with routes--%>
    <h2>Routes</h2>

    <asp:GridView runat="server" id="gridView_routes" AutoGenerateColumns="false"
        OnRowDeleting="gridView_routes_RowDeleting" OnRowEditing="gridView_routes_RowEditing" DataKeyNames="Name, Description" CellPadding="10">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:ButtonField Text="Edit" CommandName="Edit" />
            <asp:ButtonField Text="Delete" CommandName="Delete" />
        </Columns>
    </asp:GridView>

    <%--Add route form--%>
    <h2>Add route</h2>
     
    <p>Name</p>
    <asp:TextBox runat="server" ID="textBox_name"></asp:TextBox>
    <p>Description</p>
    <asp:TextBox runat="server" ID="textBox_description"></asp:TextBox>
    <br />
    <br />
    <asp:Button runat="server" ID="button_add" Text="Add" OnClick="button_add_Click" />

    <%--Status labbel--%>
    <br />
    <br />
    <p runat="server" id="statusLabel"></p>

</asp:Content>
