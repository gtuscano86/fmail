<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxPage.aspx.cs" Inherits="Project3.InboxPage" %>

<!DOCTYPE html>
<style>
    body{
        background-color: lightskyblue;
        font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
    }
    #form1 {
        height: 527px;
    }
    .auto-style1 {
        width: 154px;
        height: 247px;
        position: absolute;
        top: -110px;
        left: 53px;
        z-index: 1;
    }
    img {
        width: 75px;
    }
    .auto-style2 {
        position: absolute;
        top: 265px;
        left: 949px;
        z-index: 1;
        width: 223px;
        height: 49px;
    }
    .auto-style3 {
        bottom: 440px;
    }
    .auto-style4 {
        z-index: 1;
        left: 951px;
        top: 206px;
        position: absolute;
        width: 224px;
        height: 53px;
    }
    .auto-style5 {
        position: absolute;
        top: 142px;
        left: 379px;
        z-index: 1;
    }
    .auto-style6 {
        position: absolute;
        top: 253px;
        left: 376px;
        z-index: 1;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnFlag" runat="server" BackColor="#FFFFCC" OnClick="btnFlag_Click" Text="Flag Selected Emails" Font-Size="Large" CssClass="auto-style4" />
            <asp:Button ID="btnSignOut" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" OnClick="btnSignOut_Click" style="z-index: 1; left: 935px; top: 21px; position: absolute; height: 50px; width: 133px" Text="Sign Out" />
        </div>
        <h2><asp:Label ID="lblTo" runat="server" style="z-index: 1; left: 207px; top: 203px; position: absolute" Text="To:" Visible="False"></asp:Label>
            <asp:Button ID="btnBack" runat="server" BackColor="#FFFFCC" Font-Size="Large" OnClick="btnBack_Click" style="z-index: 1; left: 958px; top: 152px; position: absolute; height: 42px; width: 91px; right: 178px" Text="Back" Visible="False" CssClass="auto-style3" />
            <asp:Button ID="btnDelete" runat="server" BackColor="#FFFFCC" Font-Size="Large" OnClick="btnDelete_Click" style="z-index: 1; left: 830px; top: 83px; position: absolute; height: 54px;" Text="Delete" />
            <asp:TextBox ID="txtSearch" runat="server" style="z-index: 1; left: 491px; top: 110px; position: absolute; width: 199px">Search Here</asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" BackColor="#FFFFCC" Font-Size="Large" OnClick="btnSearch_Click" style="z-index: 1; left: 723px; top: 84px; position: absolute; height: 53px;" Text="Search" />
            <asp:Label ID="lblFolder" runat="server" style="z-index: 1; left: 208px; top: 107px; position: absolute"></asp:Label>
            <asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="False" CssClass="auto-style1" BackColor="LightSkyBlue" ForeColor="LightSkyBlue" GridLines="None">
                <Columns>
                    <asp:ImageField DataImageUrlField="Avatar" HeaderText="Avatar">
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnRead" runat="server" BackColor="#FFFFCC" CssClass="auto-style2" Font-Bold="False" Font-Size="Large" OnClick="btnRead_Click" Text="Read Selected Email" />
            <asp:Label ID="lblFromExtension" runat="server" CssClass="auto-style5" Text="@fmail.com" Visible="False"></asp:Label>
            <asp:Label ID="lblToExtension" runat="server" CssClass="auto-style6" Text="@fmail.com" Visible="False"></asp:Label>
        </h2>
        <asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="False"  style="z-index: 1; left: 205px; top: 145px; position: absolute; height: 153px; width: 738px; margin-right: 6px;" BackColor="White">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SenderId" HeaderText="From" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                <asp:BoundField DataField="EmailBody" HeaderText="Content" />
                <asp:BoundField DataField="CreatedTime" HeaderText="Time" />
                <asp:TemplateField HeaderText="Flag">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkFlag" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <h1><asp:Label ID="lblWelcome" runat="server" style="z-index: 1; left: 151px; top: 48px; position: absolute" Text="Welcome!"></asp:Label>
            <asp:Button ID="btnCreateEmail" runat="server" BackColor="#FFFFCC" style="z-index: 1; left: 29px; top: 117px; position: absolute; height: 55px; width: 154px" Text="Create Email" OnClick="btnCreateEmail_Click" Font-Size="Large" />
            <asp:TextBox ID="txtBody" TextMode="MultiLine" runat="server" style="z-index: 1; left: 211px; top: 435px; position: absolute; height: 248px; width: 734px" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtFrom" runat="server" style="z-index: 1; left: 207px; top: 146px; position: absolute" Visible="False"></asp:TextBox>
        </h1>
        <h2><asp:Label ID="lblFrom" runat="server" Text="From:" style="z-index: 1; left: 204px; top: 107px; position: absolute" Visible="False"></asp:Label>
            <asp:Button ID="btnInbox" runat="server" BackColor="#FFFFCC" Font-Size="Large" OnClick="btnInbox_Click" style="z-index: 1; left: 33px; top: 191px; position: absolute; height: 47px; width: 144px" Text="Inbox" />
        </h2>
        <asp:TextBox ID="txtTo" runat="server" style="z-index: 1; left: 202px; top: 258px; position: absolute" Visible="False"></asp:TextBox>
        <h2><asp:Label ID="lblContent" runat="server" style="z-index: 1; left: 212px; top: 386px; position: absolute" Text="Content:" Visible="False"></asp:Label>
            <asp:Button ID="btnSent" runat="server" BackColor="#FFFFCC" Font-Size="Large" OnClick="btnSent_Click" style="z-index: 1; left: 35px; top: 254px; position: absolute; height: 47px; width: 141px" Text="Sent Mail" />
        </h2>
        <asp:Button ID="btnSend" runat="server" BackColor="#FFFFCC" style="z-index: 1; left: 501px; top: 706px; position: absolute; height: 46px; width: 144px" Text="Send" Visible="False" Font-Size="Large" OnClick="btnSend_Click" />
        <h2><asp:Label ID="lblSubject" runat="server" style="z-index: 1; left: 213px; top: 290px; position: absolute" Text="Subject:" Visible="False"></asp:Label>
            <asp:Button ID="btnTrash" runat="server" BackColor="#FFFFCC" Font-Size="Large" OnClick="btnTrash_Click" style="z-index: 1; left: 36px; top: 317px; position: absolute; width: 138px; height: 50px; bottom: 210px;" Text="Trash" />
            <asp:Label ID="lblEmailSent" runat="server" style="z-index: 1; left: 487px; top: 355px; position: absolute" Text="Email sent!" Visible="False"></asp:Label>
        </h2>
        <asp:TextBox ID="txtSubject" runat="server" style="z-index: 1; left: 206px; top: 334px; position: absolute" Visible="False"></asp:TextBox>
        <asp:Button ID="btnJunk" runat="server" BackColor="#FFFFCC" Font-Size="Large" OnClick="btnJunk_Click" style="z-index: 1; left: 39px; top: 380px; position: absolute; width: 132px; height: 51px;" Text="Junk" />
    </form>
</body>
</html>
