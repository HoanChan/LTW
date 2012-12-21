<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateExercises.aspx.cs" Inherits="GiaoVien_CreateExercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <b>Tạo bài tập mới cho lớp: <% Response.Write(TenLop); %></b>
    <p>
        Tên bài tập: 
        <asp:TextBox ID="txtTenBai" runat="server"></asp:TextBox>
    </p>
    <p>Mô tả:</p>
    <p>
        <asp:TextBox ID="txtMota" runat="server" Height="80px" TextMode="MultiLine" Width="307px"></asp:TextBox>
    </p>
    <p>
        Hạn nộp:
        <asp:TextBox ID="txtHanNop" runat="server"></asp:TextBox>
    </p>

    <p>File đính kèm:</p>

    <form action="CreateExercises.aspx" enctype="multipart/form-data" method="post">
        <asp:FileUpload runat="server" ID="fUpLoad" />
    </form>
     <p>
        <asp:Label ID="lblKQ" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnCreate" runat="server" Text="Tạo bài tập" OnClick="btnCreate_Click" />
    </p>
</asp:Content>

