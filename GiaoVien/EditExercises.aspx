<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditExercises.aspx.cs" Inherits="GiaoVien_EditExercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <b>Sử thông tin bài tập lớp: <% Response.Write(TenLop); %></b>
    <p>Mã bài tập: </p>
    <p>Mô tả:</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="80px" TextMode="MultiLine" Width="233px"></asp:TextBox>
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
        <asp:Button ID="btnEdit" runat="server" Text="Cập nhật" />
    </p>
    </form>
</asp:Content>

