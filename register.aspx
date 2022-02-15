<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>
<%@ Register TagName="Captcha" TagPrefix="Controls" Src="~/Captcha.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Регистрация</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Имя"></asp:Label>
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp;<asp:TextBox ID="LoginTextBox" runat="server" Width="150px" MaxLength="12"></asp:TextBox>
    <asp:Label ID="LoginErrorLabel" runat="server" Font-Strikeout="False" Font-Underline="False"
            ForeColor="Red" Visible="False"
            Width="413px"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="PassTextBox" runat="server" TextMode="Password" Width="150px" MaxLength="8"></asp:TextBox>
    <asp:Label ID="PassErrorLabel" runat="server" Font-Strikeout="False" Font-Underline="False"
                        ForeColor="Red" Visible="False" Width="411px"></asp:Label><br />
    <asp:Label ID="Label3" runat="server" Text="Опять пароль"></asp:Label>&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:TextBox ID="PassAgainTextBox" runat="server" TextMode="Password" Width="150px" MaxLength="8"></asp:TextBox>
    <asp:Label ID="PassAgainErrorLabel" runat="server" Font-Strikeout="False" Font-Underline="False"
                        ForeColor="Red" Visible="False" Width="409px"></asp:Label>
        &nbsp;<br />
    <asp:Label ID="Label4" runat="server" Text="Число с картинки"></asp:Label>
        &nbsp;&nbsp; &nbsp;<asp:TextBox ID="CaptchaTextBox" runat="server" Width="151px"></asp:TextBox>
    <asp:Label ID="CaptchaErrorLabel" runat="server" Font-Strikeout="False" Font-Underline="False"
                        ForeColor="Red" Visible="False" Width="407px"></asp:Label><br />
        <br />
        &nbsp;<asp:Label ID="Label5" runat="server" Text="E-mail"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        &nbsp;<Controls:Captcha ID="captcha" runat="server"></Controls:Captcha>
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" runat="server" Text="Зарегистрироваться" Width="150px" OnClick="Button1_Click" /><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="default.aspx">На главную страницу</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    &nbsp;
    </div>
    </form>
</body>
</html>
