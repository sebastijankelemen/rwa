<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewPerson.aspx.cs" Inherits="RWA_MI1_IvanKozul_2RP1.NewPerson" meta:resourcekey="PageResource1" %>
<%@ MasterType virtualpath="~/Master.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSheets" runat="server">
    <style>
        .form-group span{
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">
        <span id="spanSendStatus" style="color:darkblue;font-weight:bold;">
            <asp:Literal ID="literalSendStatus" runat="server" meta:resourcekey="literalSendStatusResource1"></asp:Literal>
        </span>
        <div class="formContainer row">
            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="form-group">
                    <span>
                        <asp:Label ID="Label1" runat="server" Text="Name:" meta:resourcekey="Label1Resource1"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validatori" runat="server" ErrorMessage="Name is required!" Text="*" ControlToValidate="tbName" ValidationGroup="formGroup" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    </span>
                    <asp:TextBox ID="tbName" runat="server" CssClass="form-control" meta:resourcekey="tbNameResource1"></asp:TextBox>
                    
                </div>
                <div class="form-group">
                    <span>
                        <asp:Label ID="Label2" runat="server" Text="Surname:" meta:resourcekey="Label2Resource1"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validatori" runat="server" ErrorMessage="Surname is required!" Text="*" ControlToValidate="tbSurname" ValidationGroup="formGroup" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                    </span>
                    <asp:TextBox ID="tbSurname" runat="server" CssClass="form-control" meta:resourcekey="tbSurnameResource1"></asp:TextBox>
                    
                    
                </div>
                <div class="form-group">
                    <div>
                        <span>
                            <asp:Label ID="Label3" runat="server" Text="Email:" meta:resourcekey="Label3Resource1"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validatori" runat="server" ErrorMessage="Email is required!" Text="*" ControlToValidate="tbEmail" ValidationGroup="formGroup" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                        </span>

                        <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" meta:resourcekey="tbEmailResource1"></asp:TextBox>
                            <asp:TextBox ID="tbEmail2" runat="server" CssClass="form-control hide" meta:resourcekey="tbEmail2Resource1"></asp:TextBox>
                            <asp:TextBox ID="tbEmail3" runat="server" CssClass="form-control hide" meta:resourcekey="tbEmail3Resource1"></asp:TextBox>
                        <asp:LinkButton ID="lbAddEmail" runat="server" OnClick="lbAddEmail_Click" meta:resourcekey="lbAddEmailResource1">Add More Email Adresses</asp:LinkButton>
                        
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="form-group">
                    <span>
                        <asp:Label ID="Label4" runat="server" Text="Telephone:" meta:resourcekey="Label4Resource1"></asp:Label></span>
                    <asp:TextBox ID="tbTelephone" runat="server" CssClass="form-control" meta:resourcekey="tbTelephoneResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <span>
                        <asp:Label ID="Label5" runat="server" Text="City:" meta:resourcekey="Label5Resource1"></asp:Label></span>
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" meta:resourcekey="ddlCityResource1">
                        <asp:ListItem meta:resourcekey="ListItemResource1">Zagreb</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource2">Varaždin</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource3">Split</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource4">Rijeka</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource5">Pula</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource6">Osijek</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource7">Dubrovnik</asp:ListItem>
                    </asp:DropDownList>
                    
                </div>
                <div class="form-group">
                    <span>
                        <asp:Label ID="Label6" runat="server" Text="Role:" meta:resourcekey="Label6Resource1"></asp:Label></span>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" meta:resourcekey="ddlRoleResource1">
                        <asp:ListItem meta:resourcekey="ListItemResource8">Korisnik</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource9">Administrator</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="form-group">
                    <span>
                        <asp:Label ID="Label7" runat="server" Text="Password:" meta:resourcekey="Label7Resource1"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validatori" runat="server" ErrorMessage="Password is required!" Text="*" ControlToValidate="tbPassword" ValidationGroup="formGroup" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                    </span>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password" meta:resourcekey="tbPasswordResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <span>
                        <asp:Label ID="Label8" runat="server" Text="Confirm password:" meta:resourcekey="Label8Resource1"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="validatori" runat="server" ErrorMessage="Password Confirmation is required!" Text="*" ControlToValidate="tbPasswordConfirm" ValidationGroup="formGroup" meta:resourcekey="RequiredFieldValidator5Resource1"></asp:RequiredFieldValidator>
                    </span>
                     <asp:TextBox ID="tbPasswordConfirm" runat="server" CssClass="form-control" TextMode="Password" meta:resourcekey="tbPasswordConfirmResource1"></asp:TextBox>
                </div>
                <asp:LinkButton ID="sendBtn" runat="server" CssClass="btn btn-primary" OnClick="sendBtn_Click" meta:resourcekey="sendBtnResource1">Add</asp:LinkButton>
            </div>
        </div>
        <span>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="formGroup" CssClass="validatori" Font-Bold="False" ForeColor="Red" meta:resourcekey="ValidationSummary1Resource1" />
        </span>
    </div>
</asp:Content>
