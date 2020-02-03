<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailLogin.aspx.cs" Inherits="Project3.EmailLogin" %>

<!DOCTYPE html>
    <style>
        body {
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            height: 309px;
            background-color: lightskyblue;
        }
        .auto-style1 {
            position: absolute;
            top: 103px;
            left: 361px;
            z-index: 1;
        }
    </style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div>
            <h1><asp:Label ID="lblWelcome" runat="server" Text="Welcome to Fmail, Please Log In" style="z-index: 1; left: 22px; top: 27px; position: absolute"></asp:Label></h1>
        </div>
        <h2><asp:Label ID="lblUsername" runat="server" style="z-index: 1; left: 24px; top: 100px; position: absolute" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" style="z-index: 1; left: 187px; top: 101px; position: absolute; height: 30px"></asp:TextBox>
        </h2>
        <h2><asp:Label ID="lblPassword" runat="server" style="z-index: 1; left: 24px; top: 170px; position: absolute" Text="Password:"></asp:Label>
            <asp:Label ID="lblExtension" runat="server" CssClass="auto-style1" Text="@fmail.com"></asp:Label>
        </h2>
        <asp:TextBox ID="txtPassword" runat="server" style="z-index: 1; left: 187px; top: 170px; position: absolute; height: 29px"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" BackColor="#FFFFCC" OnClick="btnLogin_Click" style="z-index: 1; left: 26px; top: 224px; position: absolute; width: 332px; height: 36px" Text="Sign In" />
        <asp:Button ID="btnNewAccount" runat="server" BackColor="#FFFFCC" style="z-index: 1; left: 27px; top: 268px; position: absolute; width: 330px; height: 35px" Text="Create New Account" OnClick="btnNewAccount_Click" />
    </form>
</body>
</html>
