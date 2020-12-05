<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="RWA_MI1_IvanKozul_2RP1.Setup" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType virtualpath="~/Master.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSheets" runat="server">
    <style>

        .form-group span{
            font-weight:bold;
        }
        .formContainer {
    width: 300px;
    margin: auto;
    padding: 15px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="formContainer">
        <div class="form-group">
            <span id="lblTheme">
                <asp:Label ID="Label1" runat="server" Text="Theme:" meta:resourcekey="Label1Resource1"></asp:Label>
            </span>
              <asp:DropDownList ID="ddlTheme" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged" meta:resourcekey="ddlThemeResource1">
                <asp:ListItem meta:resourcekey="ListItemResource1">--------------Choose--------------</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource2">Default</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource3">Blue</asp:ListItem>
                  <asp:ListItem meta:resourcekey="ListItemResource4">Red</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <span id="lblCulture">
                <asp:Label ID="Label2" runat="server" Text="Language:" meta:resourcekey="Label2Resource1"></asp:Label>
            </span>
             <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" meta:resourcekey="ddlLanguageResource1">
                <asp:ListItem meta:resourcekey="ListItemResource5">--------------Choose--------------</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource6">Croatian</asp:ListItem>
                <asp:ListItem meta:resourcekey="ListItemResource7">English</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <span id="lblRepo">
                <asp:Label ID="Label3" runat="server" Text="Repository:" meta:resourcekey="Label3Resource1"></asp:Label></span>
            <asp:DropDownList ID="ddlRepository" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" meta:resourcekey="ddlRepositoryResource1">
                <asp:ListItem meta:resourcekey="ListItemResource8">--------------Choose--------------</asp:ListItem>
                <asp:ListItem Text="DataBase" Value="DataBase" meta:resourcekey="ListItemResource9"></asp:ListItem>
                <asp:ListItem Value="TextFile" Text="Text File" meta:resourcekey="ListItemResource10"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

</asp:Content>
