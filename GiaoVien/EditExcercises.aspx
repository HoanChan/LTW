<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditExcercises.aspx.cs" Inherits="EditExcercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <b>Sử thông tin bài tập lớp: <% Response.Write(TenLop); %> (<%Response.Write(MaLop); %></b>
    <p>Mã bài tập: <b><%Response.Write(MaBT); %></b></p>
    <p>Tên bài tập: <asp:TextBox ID="txtTenBT" runat="server"></asp:TextBox></p>
    < <p>
        <asp:Label ID="lblKQ" runat="server"></asp:Label>
    </p>
    <p>Mô tả:</p>
    <p>
        <asp:TextBox ID="txtMoTa" runat="server" Height="80px" TextMode="MultiLine" Width="233px" HtmlEncodeFormatString="False" HtmlEncode="False"></asp:TextBox>
    </p>
    <p>
        Hạn nộp:
        <asp:TextBox ID="txtHanNop" runat="server"></asp:TextBox>
    </p>

    <%--<p>File đính kèm:</p>

    <form action="CreateExercises.aspx" enctype="multipart/form-data" method="post">
        <asp:FileUpload runat="server" ID="fUpLoad" />
        <input type="submit" value="UpLoad"
    </form>--%>
    <p>
      <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Tạo người dùng" />
    </p>
    </form>
</asp:Content>

