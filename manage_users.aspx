<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_users.aspx.cs" Inherits="manage_users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Управление пользователями</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" PostBackUrl="default.aspx">На главную страницу</asp:LinkButton>
<table border="1">
    <tr>
        <td>Имя</td>
        <td>E-mail</td>
        <td>Удалить</td>
    </tr>
    <% ShowUsers(); %>
    </table>    
    </div>
    </form>
</body>
</html>
