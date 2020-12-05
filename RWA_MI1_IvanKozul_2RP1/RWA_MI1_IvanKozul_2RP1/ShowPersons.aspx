<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShowPersons.aspx.cs" Inherits="RWA_MI1_IvanKozul_2RP1.ShowPersons" meta:resourcekey="PageResource1" %>
<%@ MasterType virtualpath="~/Master.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSheets" runat="server">
    <link href="Content/Style/ShowPersons.css" rel="stylesheet" />
    <script>
        function HidePanel(s) {
            var div = document.getElementById(s);
            div.setAttribute('class', 'panel-body panel-collapse collapse hide');
        }
        function ShowPanel(s) {
            var div = document.getElementById(s);
            div.setAttribute('class', 'panel-body panel-collapse collapse in');
        }
    </script>
    <style>
        .gwInput {
    width: 120px;
    padding: 3px;
    border: 1px solid #ccc;
}
        #gridView td{
            padding:5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="panel-group accordion"></div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:LinkButton ID="lbGridView" runat="server" OnClick="lbGridView_Click" meta:resourcekey="lbGridViewResource1">Grid View</asp:LinkButton>
        </div>
        <div class="panel-body panel-collapse collapse in gridItem" id="gridView">
            <asp:GridView runat="server" ID="gwPersons"
                ItemType="RWA_MI1_IvanKozul_2RP1.Person" DataKeyNames="ID"
                AutoGenerateColumns="False" BorderStyle="None" GridLines="Horizontal" BorderColor="LightGray" OnRowDeleting="gwPersons_RowDeleting" OnRowUpdating="gwPersons_RowUpdating" OnRowCancelingEdit="gwPersons_RowCancelingEdit" OnRowEditing="gwPersons_RowEditing" OnSelectedIndexChanging="gwPersons_SelectedIndexChanging" OnRowDeleted="gwPersons_RowDeleted" meta:resourcekey="gwPersonsResource1">
                <Columns>
                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Name" SortExpression="Name" meta:resourcekey="TemplateFieldResource1">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbName" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control gwInput" meta:resourcekey="tbNameResource1"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="Name" />
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Surname" SortExpression="Name" meta:resourcekey="TemplateFieldResource2">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbSurname" runat="server" Text='<%# Bind("Surname") %>' CssClass="form-control gwInput" meta:resourcekey="tbSurnameResource1"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DynamicControl ID="DynamicControl43" runat="server" DataField="Surname" />
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Email" SortExpression="Email" HeaderStyle-Width="35%" meta:resourcekey="TemplateFieldResource3">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control gwInput" meta:resourcekey="tbEmailResource1"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <a href="mailto:">
                                <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="Email" />
                            </a>
                            <br />
                            <a href="mailto:">
                                <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="Email2" />
                            </a>
                            <br />
                            <a href="mailto:">
                                <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="Email2" />
                            </a>
                        </ItemTemplate>

                        <HeaderStyle Width="30%"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Phone" SortExpression="Phone" meta:resourcekey="TemplateFieldResource4">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbPhone" runat="server" Text='<%# Bind("Phone") %>' CssClass="form-control gwInput" meta:resourcekey="tbPhoneResource1"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DynamicControl ID="DynamicControl433" runat="server" DataField="Phone" />
                        </ItemTemplate>
                        <HeaderStyle Width="20%" />
                    </asp:TemplateField>

                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Phone" SortExpression="Phone" meta:resourcekey="TemplateFieldResource5">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control gwInput" DataSource=<%# rolesList %> meta:resourcekey="ddlRoleResource1"> </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control gwInput" DataSource=<%# rolesList %> Enabled="False" meta:resourcekey="ddlRoleResource2"> </asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                    </asp:TemplateField>

                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" meta:resourcekey="CommandFieldResource1" />
                </Columns>
                <HeaderStyle BackColor="#333" BorderStyle="None" Font-Bold="False" 
                    ForeColor="White" Height="30px"  BorderWidth="0px"/>
            </asp:GridView>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:LinkButton ID="lbRepeater" runat="server" OnClick="lbRepeater_Click" meta:resourcekey="lbRepeaterResource1">Repeater</asp:LinkButton>
        </div>
        <div class="panel-body panel-collapse collapse in" id="repeater">
            <asp:Repeater ID="repeaterPersons" runat="server">
                <HeaderTemplate>
        <table class="table table-condensed table-hover tblPrikazOsoba">
            <tr style="background-color:#333; color:white; font-weight:normal;">
                <th scope="col" style="width: 15%">
                    
                    <asp:Label ID="Label4" runat="server" Text="Name" meta:resourcekey="Label4Resource1"></asp:Label>
                </th>
                <th scope="col" style="width: 15%">
                    <asp:Label ID="Label3" runat="server" Text="Surname" meta:resourcekey="Label3Resource1"></asp:Label>
                    
                </th>
                <th scope="col" style="width: 30%">
                    <asp:Label ID="Label2" runat="server" Text="Email" meta:resourcekey="Label2Resource1"></asp:Label>
                    
                </th>
                <th scope="col" style="width: 12%">
                    <asp:Label ID="Label1" runat="server" Text="Telephone" meta:resourcekey="Label1Resource1"></asp:Label>
                </th>
                <th scope="col" style="width: 12%">
                    
                    <asp:Label ID="Label5" runat="server" Text="Role" meta:resourcekey="Label5Resource1"></asp:Label>
                </th>
                <th scope="col" style="width: 12%">
                    <asp:Label ID="Label6" runat="server" Text="City" meta:resourcekey="Label6Resource1"></asp:Label>
                    
                </th>
                <th scope="col" style="width: 9%">
                    
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' meta:resourcekey="lblNameResource1" />
            </td>
            <td>
                <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("Surname") %>' meta:resourcekey="lblSurnameResource1" />
            </td>
            <td>
                <asp:Label ID="lblEmails" runat="server" Text='<%# "<a href=mailTo:"+ Eval("Email")+">"+ Eval("Email") + "</a>" +"<br/>"+"<a href=mailTo:"+ Eval("Email2")+">"+ Eval("Email2") + "</a>"+"<br/>"+"<a href=mailTo:"+ Eval("Email3")+">"+ Eval("Email3") + "</a>" %>' meta:resourcekey="lblEmailsResource1" />
            </td>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>' meta:resourcekey="lblPhoneResource1" />
            </td>
            <td>
                <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role") %>' meta:resourcekey="lblRoleResource1" />
            </td>
            <td>
                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>' meta:resourcekey="lblCityResource1" />
            </td>
            <td>
                <asp:LinkButton Text="Edit" CommandName='<%# Eval("ID") %>'  runat="server" CssClass="btn btn-primary" OnClick="EditBtnClick"/>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
