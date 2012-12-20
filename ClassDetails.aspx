<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClassDetails.aspx.cs" Inherits="ClassDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>Lớp: <span id="Class"></span></p>
    <p>Giáo viên: <span id="Teacher"></span></p>
    <p>Mô tả: <span id="Details"></span></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Ma" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Ma" HeaderText="Mã" InsertVisible="False" ReadOnly="True" SortExpression="Ma" />
            <asp:BoundField DataField="Ten" HeaderText="Tên bài tập" SortExpression="Ten" />
            <asp:BoundField DataField="MoTa" HeaderText="Mô tả" SortExpression="MoTa" />
            <asp:BoundField DataField="HanNop" HeaderText="Hạn nộp" SortExpression="HanNop" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NopBaiTapVeNhaConnectionString %>" SelectCommand="SELECT [Ten], [MoTa], [HanNop], [Ma] FROM [BaiTap] WHERE ([MaLop] = @MaLop)">
        <SelectParameters>
            <asp:QueryStringParameter Name="MaLop" QueryStringField="ID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

