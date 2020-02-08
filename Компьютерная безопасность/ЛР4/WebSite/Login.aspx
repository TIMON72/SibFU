<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        #Text2 {
            width: 186px;
            margin-left: 16px;
            margin-top: 0px;
        }

        #Text1 {
            width: 186px;
            margin-left: 42px;
        }
    </style>
    <script src='https://www.google.com/recaptcha/api.js'></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login:<asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
        </div>
        <div>
            Password:<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        </div>
        <div class="g-recaptcha" data-sitekey="6LcmoCMUAAAAAA7NcvkXnXT7zXpz5862jIJnxHA-"></div>
        <div>
            <asp:Button ID="ButtonLogin" runat="server" Height="25px" OnClick="ButtonLogin_Click" Text="login" />
        </div>
    </form>
</body>
</html>
