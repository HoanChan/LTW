<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateUsers.aspx.cs" Inherits="Admin_CreateUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>TRANG TẠO NGƯỜI DÙNG</p>
    <p>
        <asp:Label ID="lblKQ" runat="server"></asp:Label>
    </p>
    <p>Điền các thông tin để tạo người dùng. Các ô có dấu * là bắt buộc</p>.
    <p>Quyền:
        <asp:DropDownList ID="ddlQuyen" runat="server" AutoPostBack="True" DataSourceID="sourceQuyen"
            DataTextField="TenQuyen" DataValueField="MaQuyen" Height="34px" Width="226px">
        </asp:DropDownList>
    </p>
    <p>Username:*<asp:TextBox ID="txtUser" runat="server" Width="221px"></asp:TextBox></p>
    <p>Password:*<asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="217px"></asp:TextBox></p>
    <p>Nhập lại Password:*<asp:TextBox ID="txtPass1" runat="server" TextMode="Password" Width="214px"></asp:TextBox></p>
    <p>Email:*<asp:TextBox ID="txtEmail" runat="server" Width="216px"></asp:TextBox></p>
    <p>
        Họ:<asp:TextBox ID="txtHo" runat="server" Width="214px"></asp:TextBox>
    </p>
    <p>
        tên:<asp:TextBox ID="txtTen" runat="server" Width="214px"></asp:TextBox>
    </p>
    <p>Giới tính:
          <asp:RadioButton ID="RaNam" runat="server" Text="Nam" GroupName="Source" />
          
          <asp:RadioButton ID="RaNu" runat="server" Text="Nữ" GroupName="Source" />
    </p>
    <p>Ngày sinh:
        <asp:TextBox ID="txtNgaySinh" runat="server"  Width="211px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Tạo người dùng" />
    </p>
    <p>
         <asp:SqlDataSource ID="sourceQuyen" runat="server" SelectCommand="SELECT * FROM Quyen"
            ConnectionString="<%$ConnectionStrings:NopBaiTapVeNha%>"></asp:SqlDataSource>
        
    </p>
</asp:Content>

