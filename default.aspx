<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="view_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�������� ��������</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="delete.aspx">������� ���� ������� ������</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="manage_news.aspx">���������� ���������</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="manage_users.aspx">���������� ��������������</asp:LinkButton>
        <br />
        <asp:Label ID="Label1" runat="server" Text="�� �� ����� � �������"></asp:Label>
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" PostBackUrl="login.aspx">����/�����</asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="register.aspx">�����������</asp:LinkButton><br />
        <asp:Label ID="Label2" runat="server" Text="� ��� ���������� ��������������" Width="305px"></asp:Label>
        <br />
        <br />
        <table border="1">
        <tr>
            <td><b>�����</b></td>
            <td><b>�����</b></td>
            <td><b>���� ����������</b></td>
        </tr>
        <% ShowNews(); %>
        </table>        
        <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="add_news.aspx">��������</asp:LinkButton></div>
    </form>
</body>
</html>
