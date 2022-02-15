<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_news.aspx.cs" Inherits="add_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Добавление новостей</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Добавить новость"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="109px" MaxLength="1000" TextMode="MultiLine"
            Width="342px"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" /><br />
        Новость будет добавлена на сайт только после одобрения администратором<br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="default.aspx">На главную страницу</asp:LinkButton></div>
    </form>
</body>
</html>
