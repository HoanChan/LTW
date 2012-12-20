<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="GiaoVien_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>Lớp: <b><% Response.Write(TenLop); %></b></p>
    <p>Giáo viên: <b><% Response.Write(GiaoVien); %></b></p>
    <p>Mô tả: <% Response.Write(MoTa); %></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Ma" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Ma" HeaderText="Mã" InsertVisible="False" ReadOnly="True" SortExpression="Ma" />
            <asp:BoundField DataField="Ten" HeaderText="Tên bài tập" SortExpression="Ten" />
            <asp:BoundField DataField="MoTa" HeaderText="Mô tả" SortExpression="MoTa" HtmlEncode="False" HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="HanNop" HeaderText="Hạn nộp" SortExpression="HanNop" />
            <asp:HyperLinkField DataNavigateUrlFields="ma" DataNavigateUrlFormatString="/AttackFiles.aspx?ID={0}" HeaderText="File đính kèm" Text="File đính kèm" />
            <asp:HyperLinkField HeaderText="Sửa bài tập" DataNavigateUrlFields="ma" DataNavigateUrlFormatString="/EditExcercises.aspx?ID={0}" Text="Sửa bài tập" />
            <asp:HyperLinkField HeaderText="Danh sách nộp bài" DataNavigateUrlFields="ma" DataNavigateUrlFormatString="/FileList.aspx?ID={0}" Text="Danh sách nộp bài" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NopBaiTapVeNhaConnectionString %>" SelectCommand="SELECT [Ten], [MoTa], [HanNop], [Ma] FROM [BaiTap] WHERE ([MaLop] = @MaLop)">
        <SelectParameters>
            <asp:QueryStringParameter Name="MaLop" QueryStringField="ID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

