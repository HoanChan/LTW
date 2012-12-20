<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateUsers.aspx.cs" Inherits="Admin_CreateUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>TRANG TẠO NGƯỜI DÙNG</p>
    <p>
        <asp:Label ID="lblKQ" runat="server"></asp:Label>
    </p>
    <p>Điền các thông tin để tạo người dùng. Các ô có dấu * là bắt buộc</p>.
    <p>Quyền:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlQuyen" runat="server" AutoPostBack="True" DataSourceID="sourceQuyen"
            DataTextField="TenQuyen" DataValueField="MaQuyen" Height="34px" Width="226px">
        </asp:DropDownList>
    </p>
    <p>Username:*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtUser" runat="server" Width="221px"></asp:TextBox></p>
    <p>Password:*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="217px"></asp:TextBox></p>
    <p>Nhập lại Password:*&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPass1" runat="server" TextMode="Password" Width="214px"></asp:TextBox></p>
    <p>Email:*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtEmail" runat="server" Width="216px"></asp:TextBox></p>
    <p>
     </p>
    <p>
        Họ tên:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtHoTen" runat="server" Width="214px"></asp:TextBox>
    </p>
    <p>Giới tính:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RadioButton ID="RaNam" runat="server" Text="Nam" GroupName="Source" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RadioButton ID="RaNu" runat="server" Text="Nữ" GroupName="Source" />
    </p>
    <p>Ngày sinh:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtNgaySinh" runat="server"  Width="211px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Tạo người dùng" />
    </p>
    <p>
         <asp:SqlDataSource ID="sourceQuyen" runat="server" SelectCommand="SELECT * FROM Quyen"
            ConnectionString="<%$ConnectionStrings:NopBaiTapVeNha%>"></asp:SqlDataSource>
        &nbsp;
    </p>
</asp:Content>

