<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoutesControl.ascx.cs" Inherits="strpo_app.Admin.RoutesControl" %>
<%@ Register Src="~/Controls/StopsDropDown.ascx" TagPrefix="uc" TagName="StopsDropDown" %>

<p>Name</p>
<asp:TextBox runat="server" ID="textBox_name"></asp:TextBox>
<p>Description</p>
<asp:TextBox runat="server" ID="textBox_description"></asp:TextBox>
<p>Start stop</p>
<uc:StopsDropDown runat="server" ID="beginStop"></uc:StopsDropDown>
<p>End stop</p>
<uc:StopsDropDown runat="server" ID="endStop"></uc:StopsDropDown>
