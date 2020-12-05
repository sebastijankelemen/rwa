<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditData.aspx.cs" Inherits="RWA_MI1_IvanKozul_2RP1.EditData" meta:resourcekey="PageResource1" %>
<%@ MasterType virtualpath="~/Master.master" %>
<%@ Register Src="~/PersonControl.ascx" TagPrefix="uc1" TagName="PersonControl" %>
<%@ Reference Control="~/PersonControl.ascx" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="StyleSheets" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="row">
        <asp:PlaceHolder ID="phPersons" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
