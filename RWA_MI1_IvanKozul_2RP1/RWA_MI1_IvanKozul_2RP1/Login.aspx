<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RWA_MI1_IvanKozul_2RP1.Login" meta:resourcekey="PageResource1"  %>
<%@ MasterType virtualpath="~/Master.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSheets" runat="server">
        <link href="Content/Style/Login.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="formContainer">
                <div class="form-group">
                    <span id="lblEmail"><asp:Label ID="Label3" runat="server" Text="E-mail:" meta:resourcekey="Label3Resource1"></asp:Label></span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required!" ForeColor="Red" ValidationGroup="LoginCheckGroup" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
<%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" class="validatori" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" ToolTip="Email is Required!">*</asp:RequiredFieldValidator>--%>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="LoginCheckGroup" meta:resourcekey="txtEmailResource1"></asp:TextBox>                 
                </div>

                <div class="form-group">
                    <span id="lblLozinka"><asp:Label ID="Label2" runat="server" Text="Password:" meta:resourcekey="Label2Resource1"></asp:Label></span>
<%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLozinka" ErrorMessage="*" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validatori" runat="server" ControlToValidate="txtLozinka" ErrorMessage="Password is required!" ForeColor="Red" ValidationGroup="LoginCheckGroup" Text="*" ValidateRequestMode="Enabled" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtLozinka" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="LoginCheckGroup" meta:resourcekey="txtLozinkaResource1"></asp:TextBox>
                </div>

                <div class="checkbox">
                    <label>
                        <asp:CheckBox ID="cbRememberMe" runat="server" meta:resourcekey="cbRememberMeResource1" />
                        <asp:Label ID="Label1" runat="server" Text="Zapamti me" meta:resourcekey="Label1Resource1"></asp:Label>
                        </label>
                </div>

                <asp:Button ID="cbtnLogin" runat="server" Text="Enter" CssClass="btn btn-primary" OnClick="AttemptLogin" ValidateRequestMode="Enabled" ValidationGroup="LoginCheckGroup" meta:resourcekey="cbtnLoginResource1"/>
                <div style="margin-top:20px;">  
                    
                <div>
                    <div id="ValidationSummary2" class="validatori" style="display:inherit;">
                        <asp:ValidationSummary CssClass="validatori" ID="ValidationSummary1" runat="server" Font-Bold="False" ForeColor="Red" ValidationGroup="LoginCheckGroup" meta:resourcekey="ValidationSummary1Resource1" />
                    </div>
                </div>

                    <span id="lblInfo" style="color:red;font-weight:normal;">
                        <asp:Literal ID="lieralLoginError" runat="server" meta:resourcekey="lieralLoginErrorResource1"></asp:Literal>
                    </span>
                </div>
            </div>
</asp:Content>
