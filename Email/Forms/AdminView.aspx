<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminView.aspx.cs" Inherits="Project3.AdminView" %>

<!DOCTYPE html>

<style>
    body{
        background-color: lightskyblue;
        font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
    }
    img{
        width: 50px;
    }
    .auto-style1 {
        z-index: 1;
        left: 19px;
        top: 195px;
        position: absolute;
        height: 175px;
        width: 816px;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="lblWelcome" runat="server"></asp:Label>
                <asp:Button ID="btnSignOut" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" OnClick="btnSignOut_Click" style="z-index: 1; left: 888px; top: 20px; position: absolute; height: 48px" Text="Sign Out" />
            </h1>
        </div>
        <asp:Button ID="btnClear" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" OnClick="btnClear_Click" style="z-index: 1; left: 407px; top: 91px; position: absolute; height: 72px; width: 118px" Text="Clear" />
        <asp:Button ID="btnUsers" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 9px; top: 90px; position: absolute; height: 76px; width: 158px" Text="View Users" OnClick="btnUsers_Click" />
        <asp:Button ID="btnFlags" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 206px; top: 91px; position: absolute; height: 74px; width: 161px" Text="View Flags" OnClick="btnFlags_Click" />
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" style="z-index: 1; left: 24px; top: 211px; position: absolute; height: 175px; width: 1130px" Visible="False" BackColor="White">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBan" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="NewEmail" HeaderText="Email" />
                <asp:BoundField DataField="ContactEmail" HeaderText="Contact Email" />
                <asp:ImageField DataImageUrlField="Avatar" HeaderText="Avatar">
                </asp:ImageField>
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Active" HeaderText="Active" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvFlags" runat="server" AutoGenerateColumns="False" Visible="False" BackColor="White" CssClass="auto-style1">
            <Columns>
                <asp:BoundField DataField="SenderId" HeaderText="Sender" />
                <asp:BoundField DataField="RecieverId" HeaderText="Receiver" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                <asp:BoundField DataField="EmailBody" HeaderText="Body" />
                <asp:BoundField DataField="CreatedTime" HeaderText="Created Time" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnBan" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" OnClick="btnBan_Click" style="z-index: 1; left: 552px; top: 6px; position: relative; height: 73px" Text="Ban Selected User" Visible="False" />
        <asp:Button ID="btnUnBan" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" OnClick="btnUnBan_Click" style="z-index: 1; left: 823px; top: 91px; position: absolute; height: 70px; width: 298px" Text="Unban Selected User" Visible="False" />
    </form>
</body>
</html>
