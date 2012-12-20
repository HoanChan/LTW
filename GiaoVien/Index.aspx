<%@ Page Title="Giáo viên" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="GiaoVien_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>Danh sách các lớp học trên website</p>
    <p>
        <asp:GridView ID="gvListClass" runat="server" DataSourceID="sourceClass"
            BackColor="White"
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="STT" />
                <asp:BoundField HeaderText="Mã lớp" DataField="MaLop" />
                <asp:BoundField HeaderText="Tên lớp" DataField="TenLop" />
                <asp:BoundField HeaderText="Giáo viên" DataField="GiaoVien" />
                <asp:BoundField HeaderText="Mô tả" DataField="MoTa"/>
                 <asp:CommandField ShowSelectButton="true" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

    </p>
    <p>
        <asp:SqlDataSource ID="sourceClass" runat="server" SelectCommand="SELECT * FROM LopHoc"
            ConnectionString="<%$ConnectionStrings:NopBaiTapVeNha%>"></asp:SqlDataSource>
    </p>
</asp:Content>

