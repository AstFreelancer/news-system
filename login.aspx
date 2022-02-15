<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Лабораторная работа 3-4</title>
</head>
<body>
<script language="Javascript" src="md5.js" type="text/javascript"></script>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Имя"></asp:Label>
        &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="LoginTextBox" runat="server" Width="148px" MaxLength="12"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label>&nbsp;
        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password" Width="148px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="LoginButton" runat="server" Text="Войти" OnClick="LoginButton_Click" />
        <asp:Label ID="Label3" runat="server" Text="Label" Width="70px"></asp:Label><br />
        <asp:LinkButton ID="RegButton" runat="server" OnClick="RegButton_Click" PostBackUrl="~/register.aspx">Регистрация</asp:LinkButton>
    </div>
        <asp:HiddenField ID="NumberField" runat="server" OnValueChanged="NumberField_ValueChanged" />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="default.aspx">На главную страницу</asp:LinkButton>
    </form>
</body>
</html>
