<%@ Page Language="C#" AutoEventWireup="true" CodeFile="check_news.aspx.cs" Inherits="check_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Подтверждение новости</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Вы не вошли как  администратор"></asp:Label>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="manage_news.aspx">Вернуться к списку новостей</asp:LinkButton><br />
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="default.aspx">На главную страницу</asp:LinkButton>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></div>
    </form>
</body>
</html>
