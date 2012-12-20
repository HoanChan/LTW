<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FileList.aspx.cs" Inherits="FileList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>Danh sách bài nộp của bài tập:  </p><b><% Response.Write(TenBai); %></b> Lớp: <b><%Response.Write(TenLop);%></b> <b>(<%Response.Write(MaLop); %>)</b>
    <p>Danh sách sinh viên nộp bài</p>

    <asp:GridView runat="server" AutoGenerateColumns="False" DataKeyNames="Ma" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Ma" HeaderText="Mã nộp" />
            <asp:BoundField DataField="Username" HeaderText="Sinh Viên" />
            <asp:BoundField DataField="GioNop" HeaderText="Giờ nộp" />
            <asp:BoundField DataField="FileLuu" HeaderText="File Lưu" />
            <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" />
            <asp:HyperLinkField DataNavigateUrlFields="Username" DataNavigateUrlFormatString="/GiaoVien/DetailsExe.aspx?ID={0}" HeaderText="" Text="Chi tiết" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NopBaiTapVeNhaConnectionString %>" SelectCommand="SELECT * FROM [BaiNop] WHERE ([MaBaiTap] = @MaBT)">
        <SelectParameters>
            <asp:QueryStringParameter Name="MaBT" QueryStringField="ID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

