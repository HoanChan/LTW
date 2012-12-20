<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divLogin" runat="server">
        <table>
            <tr>
                <th>Username: </th>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" />
                </td>
            </tr>
            <tr>
                <th>Password: </th>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <asp:CheckBox ID="chkRemember" runat="server" Text="Remember" />
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lblThongBao" runat="server" ForeColor="Red" />
    <asp:LinkButton ID="btnThoat" runat="server" onclick="btnThoat_Click">Đăng xuất</asp:LinkButton>
</asp:Content>

