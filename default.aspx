<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="view_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Просмотр новостей</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="delete.aspx">Удалить свою учетную запись</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="manage_news.aspx">Управление новостями</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="manage_users.aspx">Управление пользователями</asp:LinkButton>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Вы не вошли в систему"></asp:Label>
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" PostBackUrl="login.aspx">Вход/выход</asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="register.aspx">Регистрация</asp:LinkButton><br />
        <asp:Label ID="Label2" runat="server" Text="У вас полномочия администратора" Width="305px"></asp:Label>
        <br />
        <br />
        <table border="1">
        <tr>
            <td><b>Автор</b></td>
            <td><b>Текст</b></td>
            <td><b>Дата добавления</b></td>
        </tr>
        <% ShowNews(); %>
        </table>        
        <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="add_news.aspx">Добавить</asp:LinkButton></div>
    </form>
</body>
</html>
