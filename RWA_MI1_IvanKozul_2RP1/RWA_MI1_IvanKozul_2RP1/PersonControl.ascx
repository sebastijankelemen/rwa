<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonControl.ascx.cs" Inherits="RWA_MI1_IvanKozul_2RP1.PersonControl" %>
<script src="Scripts/jquery-3.0.0.js" type="text/javascript"></script>
<script src="Scripts/bootstrap.js" type="text/javascript"></script>
<link href="Content/bootstrap.css" rel="stylesheet" />
<script src="Scripts/toastr.js" type="text/javascript"></script>
<link href="Content/toastr.css" rel="stylesheet" />
<link href="Content/Style/PersonControl.css" rel="stylesheet" />

<div class="osoba">
    <script type="text/javascript">
        function show_Toast(m) {
            toastr.success(m);
        }
        function show_ToastDelete(m) {
            toastr.info(m);
        }
    </script>
    <table>
        <tbody><tr>
            <td>
                <span>
                    <asp:Label ID="Label1" runat="server" Text="Name:" meta:resourcekey="Label1Resource1"></asp:Label></span>
            </td>
            <td>
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control" meta:resourcekey="tbNameResource1"></asp:TextBox>
            </td>
            <td>
                <span class="validatori" style="display:none;">*</span>
            </td>
        </tr>
        <tr>
            <td>
                <span>
                    <asp:Label ID="Label2" runat="server" Text="Surname:" meta:resourcekey="Label2Resource1"></asp:Label></span>
            </td>
            <td>
                <asp:TextBox ID="tbSurname" runat="server" CssClass="form-control" meta:resourcekey="tbSurnameResource1"></asp:TextBox>
            </td>
            <td>
                <span class="validatori" style="display:none;">*</span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlEmail" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEmail_SelectedIndexChanged" meta:resourcekey="ddlEmailResource1"></asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <span>
                    <asp:Label ID="Label3" runat="server" Text="E-mail:" meta:resourcekey="Label3Resource1"></asp:Label></span>
            </td>
            <td>
                <div class="input-group">
                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control input-sm" meta:resourcekey="tbEmailResource1"></asp:TextBox>
                   <span class="input-group-btn">
                           <asp:LinkButton ID="lbEmail" runat="server" CssClass="btn btn-default btn-sm" OnClick="lbEmail_Click" meta:resourcekey="lbEmailResource1" >
                               <span class="glyphicon glyphicon-save" style="padding:0; color:dodgerblue"></span>
                           </asp:LinkButton>
                   </span>
                </div>
                
            </td>
            <td>
                <span class="validatori" style="display:none;" >*</span>
                
            </td>
        </tr>
        <tr>
            <td>
                <span>
                    <asp:Label ID="Label4" runat="server" Text="Telephone:" meta:resourcekey="Label4Resource1"></asp:Label></span>
            </td>
            <td>
                <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control" meta:resourcekey="tbPhoneResource1"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <span>
                    <asp:Label ID="Label5" runat="server" Text="Password:" meta:resourcekey="Label5Resource1"></asp:Label></span>
            </td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" meta:resourcekey="tbPasswordResource1"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <span>
                    <asp:Label ID="Label6" runat="server" Text="Role:" meta:resourcekey="Label6Resource1"></asp:Label></span>
            </td>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" meta:resourcekey="ddlRoleResource1">
                    <asp:ListItem meta:resourcekey="ListItemResource1">Korisnik</asp:ListItem>
                    <asp:ListItem meta:resourcekey="ListItemResource2">Administrator</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <span>
                    <asp:Label ID="Label7" runat="server" Text="City:" meta:resourcekey="Label7Resource1"></asp:Label></span>
            </td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" meta:resourcekey="ddlCityResource1">
                    <asp:ListItem meta:resourcekey="ListItemResource3">Zagreb</asp:ListItem>
                    <asp:ListItem meta:resourcekey="ListItemResource4">Varaždin</asp:ListItem>
                    <asp:ListItem meta:resourcekey="ListItemResource5">Split</asp:ListItem>
                    <asp:ListItem meta:resourcekey="ListItemResource6">Rijeka</asp:ListItem>
                    <asp:ListItem meta:resourcekey="ListItemResource7">Pula</asp:ListItem>
                    <asp:ListItem meta:resourcekey="ListItemResource8">Osijek</asp:ListItem>
                    <asp:ListItem meta:resourcekey="ListItemResource9">Dubrovnik</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="lbEdit" runat="server" CssClass="btn btn-default btn-primary btnForm" OnClick="lbEdit_Click" meta:resourcekey="lbEditResource1">Edit</asp:LinkButton>
                <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-default btn-warning btnForm" OnClick="lbDelete_Click" meta:resourcekey="lbDeleteResource1">Delete</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </tbody></table>
</div>