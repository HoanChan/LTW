<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateExercises.aspx.cs" Inherits="GiaoVien_CreateExercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <b>Tạo bài tập mới cho lớp: <% Response.Write(TenLop); %></b>
    <p>
        Tên bài tập: 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>Mô tả:</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Height="80px" TextMode="MultiLine" Width="307px"></asp:TextBox>
    </p>
    <p>
        Hạn nộp:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>

    <p>File đính kèm:</p>

    <form action="CreateExercises.aspx" enctype="multipart/form-data" method="post">
        <asp:FileUpload runat="server" ID="fUpLoad" />
        <input type="submit" value="UpLoad"
    </form>

    <p>
        <asp:Button ID="btnCreate" runat="server" Text="Tạo bài tập" />
    </p>
</asp:Content>

