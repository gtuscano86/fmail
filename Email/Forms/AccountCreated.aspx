<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountCreated.aspx.cs" Inherits="Project3.AccountCreated" %>

<!DOCTYPE html>
<style>
    body{
        background-color: lightskyblue;
        font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
    }
    .auto-style1 {
        position: absolute;
        top: 256px;
        left: 416px;
        z-index: 1;
    }
    .auto-style2 {
        position: absolute;
        top: 444px;
        left: 540px;
        z-index: 1;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 1175px; height: 49px">
    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="lblAccountCreated" runat="server" Text="Account Created!" CssClass="auto-style1"></asp:Label></h1>
        </div>
        <asp:Button ID="btnBack" runat="server" BackColor="#FFFFCC" CssClass="auto-style2" Font-Bold="True" Font-Size="Large" OnClick="btnBack_Click" Text="Back" />
    </form>
</body>
</html>
