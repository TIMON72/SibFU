<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Button ID="ButtonForUser" runat="server" Text="User" OnClick="ButtonForUser_Click" />
        </p>
        <p>
            <asp:Button ID="ButtonForAdmin" runat="server" Text="Admin" OnClick="ButtonForAdmin_Click" />
        </p>
        <p>
            <asp:Button ID="ButtonBack" runat="server" Text="Вернуться к авторизации" OnClick="ButtonBack_Click" />
        </p>
    </form>
</body>
</html>
