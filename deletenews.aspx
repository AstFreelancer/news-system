<%@ Page Language="C#" AutoEventWireup="true" CodeFile="deletenews.aspx.cs" Inherits="delete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�������� �������</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="������� ������� ���������� �������"></asp:Label><br />
        <asp:TextBox ID="TextBox1" runat="server" Height="61px" TextMode="MultiLine" Width="262px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="�������"
            Width="117px" />
        <asp:Label ID="Label1" runat="server" Text="�� �� ����� ���  �������������"></asp:Label>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="manage_news.aspx">��������� � ������ ��������</asp:LinkButton><br />
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="default.aspx">�� ������� ��������</asp:LinkButton>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></div>
    </form>
</body>
</html>
