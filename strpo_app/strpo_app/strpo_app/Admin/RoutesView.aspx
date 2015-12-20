<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutesView.aspx.cs" Inherits="strpo_app.Admin.Routes" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Table with routes--%>
    <h2>Routes</h2>

    <asp:GridView runat="server" id="gridView_routes" AutoGenerateColumns="false"
        OnRowDeleting="gridView_routes_RowDeleting" OnRowEditing="gridView_routes_RowEditing" DataKeyNames="Name"
        CellPadding="10">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Begin_stop" HeaderText="Begin stop" />
            <asp:BoundField DataField="End_stop" HeaderText="End stop" />
            <asp:ButtonField Text="Edit" CommandName="Edit" />
            <asp:ButtonField Text="Delete" CommandName="Delete" />
        </Columns>
    </asp:GridView>
    
    <%--Paging--%>
    <asp:LinkButton ID="linkButton_back" Text="<- " runat="server" OnClick="linkButton_back_Click"></asp:LinkButton>
    <asp:Label ID="label_curPage" Text="init me" runat="server"></asp:Label>
    <asp:LinkButton ID="linkButton_forward" Text=" ->" runat="server" OnClick="linkButton_forward_Click"></asp:LinkButton>

    <br /> <br />

    <%--Add button--%>
    <asp:Button ID="button_add" Text="Add" OnClick="button_add_Click" runat="server" /> <br /> <br />

    <%--Status label--%>
    <p ID="statusLabel" runat="server"></p>

    <%--Sorting--%>
    <asp:HiddenField ID="SortBy" runat="server" />
    <asp:HiddenField ID="SortDir" runat="server" />

    <script>
        $(function () {
            var grid = $("#<%=gridView_routes.ClientID%>");

            var th_elems = grid.find("th");
            console.log("Sort by = " + $("#<%=SortBy.ClientID%>").val());
            console.log("Sort dir = " + $("#<%=SortDir.ClientID%>").val());

            console.log(th_elems);
            th_elems.each(function (i) {
                if (i < 4) {
                    if ($("#<%=SortBy.ClientID%>").val() == (i).toString()) {
                        var sortIndicator = $("#<%=SortDir.ClientID%>").val() == "0" ? "▼" : "▲";
                        $(this).html($(this).html() + " " + sortIndicator);
                    }

                    $(this).click(function () {
                        $("#<%=SortBy.ClientID%>").val(i);

                        var sortDir = $("#<%=SortDir.ClientID%>").val() == "0" ? 1 : 0;
                        $("#<%=SortDir.ClientID%>").val(sortDir);

                        $("form").submit();
                    });
                }
            });
        });
    </script>

</asp:Content>
