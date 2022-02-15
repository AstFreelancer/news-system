<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_news.aspx.cs" Inherits="manage_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Управление новостями</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" PostBackUrl="default.aspx">На главную страницу</asp:LinkButton>
        <br />
        <table border="1">
        <tr>
            <td><b>Автор</b></td>
            <td><b>Текст</b></td>
            <td><b>Дата добавления</b></td>
            <td><b>Подтверждение</b></td>
            <td><b>Удалить</b></td>
        </tr>
        <% ShowNews(); %>
        </table>        
        <br />
    </div>
    </form>
</body>
</html>
