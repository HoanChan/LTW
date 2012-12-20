<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DetailsExe.aspx.cs" Inherits="GiaoVien_DetailsExe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>Lịch sử nộp bài:</p> <b><%Response.Write(TenBai); %></b></b> Lớp: <b><%Response.Write(TenLop);%></b> <b>(<%Response.Write(MaLop); %>)</b>
    <p>Các lần nộp bài của sinh viên: <%Response.Write(SV); %></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Ma" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Ma" HeaderText="Mã nộp" />
            <asp:BoundField DataField="GioNop" HeaderText="Giờ nộp" />
            <asp:HyperLinkField DataNavigateUrlFields="FileLuu" DataNavigateUrlFormatString="/{0}" HeaderText="File Lưu" Text="Tải về" />
            <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" />
        </Columns>
    </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NopBaiTapVeNhaConnectionString %>" SelectCommand="SELECT * FROM [BaiNop] WHERE ([Username] = @UID and [MaBaiTap] = @EID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="UID" QueryStringField="UID" Type="String" />
            <asp:QueryStringParameter Name="EID" QueryStringField="EID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

