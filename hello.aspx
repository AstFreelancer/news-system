<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="hello.aspx.cs" validateRequest="false" Inherits="_hello" Culture="tt-RU" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Лабораторная работа №2</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Height="60px" TextMode="MultiLine" ToolTip="Введите текст" Width="293px">hello world</asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="     ---}     " OnClick="Button1_Click" ToolTip="Замена первых букв каждого слова" />
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="60px" TextMode="MultiLine" ToolTip="Это преобразованный текст" Width="293px"></asp:TextBox><br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="default.aspx">На главную страницу</asp:LinkButton></div>
    </form>
</body>
</html>
