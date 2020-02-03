<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAccountPage.aspx.cs" Inherits="Project3.NewAccountPage" %>

<!DOCTYPE html>
<style>
    body{
        font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        background-color: lightskyblue;
    }

    .auto-style1 {
        width: 50px;
        z-index: 1;
        left: 248px;
        top: 542px;
        position: absolute;
    }

    .auto-style2 {
        width: 50px;
        z-index: 1;
        left: 338px;
        top: 542px;
        position: absolute;
    }

    .auto-style3 {
        width: 50px;
        z-index: 1;
        left: 425px;
        top: 544px;
        position: absolute;
    }

    .auto-style4 {
        width: 50px;
        z-index: 1;
        left: 516px;
        top: 541px;
        position: absolute;
    }

    .auto-style5 {
        width: 50px;
        z-index: 1;
        left: 608px;
        top: 541px;
        position: absolute;
    }

    .auto-style6 {
        width: 50px;
        position: absolute;
        top: 541px;
        left: 695px;
        z-index: 1;
    }

    .auto-style10 {
        width: 50px;
        position: absolute;
        top: 543px;
        left: 774px;
        z-index: 1;
    }

    .auto-style12 {
        width: 50px;
        position: absolute;
        top: 543px;
        left: 853px;
        z-index: 1;
    }

    .auto-style15 {
        width: 50px;
        position: absolute;
        top: 543px;
        left: 933px;
        z-index: 1;
    }

    .auto-style17 {
        z-index: 1;
        left: 983px;
        top: 559px;
        position: absolute;
    }

    .auto-style18 {
        width: 50px;
        position: absolute;
        top: 542px;
        left: 1011px;
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
            <h1><asp:Label ID="lblCreate" runat="server" Text="Create a New Account"></asp:Label></h1>
        </div>
        <h2>
            <asp:TextBox ID="txtName" runat="server" style="z-index: 1; left: 123px; top: 82px; position: absolute; height: 30px; width: 188px"></asp:TextBox>
            <asp:Label ID="lblName" runat="server" style="z-index: 1; left: 19px; top: 82px; position: absolute" Text="Name:"></asp:Label></h2>
        <h2><asp:Label ID="lblAddress" runat="server" style="z-index: 1; left: 19px; top: 136px; position: absolute" Text="Address:"></asp:Label>
            </h2>
        <h1><asp:Label ID="lblSuccess" runat="server" style="z-index: 1; left: 421px; top: 205px; position: absolute" Text="Account Created!" Visible="False"></asp:Label></h1>
        <asp:Label ID="lblStreet" runat="server" style="z-index: 1; left: 23px; top: 188px; position: absolute; height: 27px; width: 64px;" Text="Street:"></asp:Label>
        <asp:TextBox ID="txtStreet" runat="server" style="z-index: 1; left: 96px; top: 187px; position: absolute; height: 21px; width: 175px;"></asp:TextBox>
        <asp:Label ID="lblCity" runat="server" Text="City:" style="z-index: 1; left: 23px; top: 227px; position: absolute"></asp:Label>
        <asp:TextBox ID="txtCity" runat="server" style="z-index: 1; left: 96px; top: 227px; position: absolute; width: 176px"></asp:TextBox>
        <h2><asp:Label ID="lblPhoneNumber" runat="server" style="z-index: 1; left: 20px; top: 350px; position: absolute" Text="Phone Number:"></asp:Label>
            <asp:Button ID="btnBack" runat="server" BackColor="#FFFFCC" Font-Size="Medium" OnClick="btnBack_Click" style="z-index: 1; left: 320px; top: 725px; position: absolute; height: 51px; width: 184px; right: 691px" Text="Back to Login" />
        </h2>
        <asp:TextBox ID="txtState" runat="server" style="z-index: 1; left: 95px; top: 269px; position: absolute; width: 173px"></asp:TextBox>
        <asp:Label ID="lblState" runat="server" Text="State:" style="z-index: 1; left: 23px; top: 265px; position: absolute; right: 1713px"></asp:Label>
        <asp:Label ID="lblZipCode" runat="server" Text="Zipcode:" style="z-index: 1; left: 21px; top: 304px; position: absolute"></asp:Label>
        <h2><asp:Label ID="lblNewEmail" runat="server" style="z-index: 1; left: 19px; top: 409px; position: absolute" Text="New Email Address:"></asp:Label>
            <asp:TextBox ID="txtZip" runat="server" style="z-index: 1; left: 109px; top: 306px; position: absolute; width: 90px"></asp:TextBox>
            </h2>
        <h2><asp:Label ID="lblContactEmail" runat="server" style="z-index: 1; left: 21px; top: 471px; position: absolute" Text="Contact Email Address:"></asp:Label>
            <img alt="" class="auto-style6" src="images/avatar6.jpg" /></h2>
        <h2><asp:Label ID="lblPassword" runat="server" style="z-index: 1; left: 23px; top: 619px; position: absolute" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 247px; top: 354px; position: absolute; height: 28px"></asp:TextBox>
            <asp:TextBox ID="txtNewEmail" runat="server" style="z-index: 1; left: 304px; top: 413px; position: absolute; height: 29px"></asp:TextBox>
            <asp:Label ID="lblEmailExtension" runat="server" style="z-index: 1; left: 481px; top: 413px; position: absolute" Text="@fmail.com"></asp:Label>
           
            <img alt="" class="auto-style5" src="images/avatar5.jpg" />
            <img alt="" class="auto-style10" src="images/avatar7.jpg" />
            <img alt="" class="auto-style18" src="images/avatar10.jpg" /></h2>
        <h2><asp:Label ID="lblType" runat="server" style="z-index: 1; left: 28px; top: 686px; position: absolute" Text="Type:"></asp:Label>
            

            
            <asp:Label ID="lblAvatar" runat="server" style="z-index: 1; left: 17px; top: 544px; position: absolute" Text="Profile Picture:"></asp:Label>
            
        <asp:TextBox ID="txtContactEmail" runat="server" style="z-index: 1; left: 351px; top: 475px; position: absolute; height: 28px; width: 174px"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server" style="z-index: 1; left: 173px; top: 622px; position: absolute; height: 29px"></asp:TextBox>
        <asp:DropDownList ID="ddlUserType" runat="server" style="z-index: 1; left: 124px; top: 692px; position: absolute; height: 31px; width: 171px; right: 900px">
            <asp:ListItem>Standard User</asp:ListItem>
            <asp:ListItem>Administrator</asp:ListItem>
        </asp:DropDownList>
        <asp:RadioButton ID="radioAvatar1" runat="server" style="z-index: 1; left: 228px; top: 546px; position: absolute" GroupName="Avatar" value="images/avatar1.jpg"/>
        <asp:RadioButton ID="radioAvatar2" runat="server" style="z-index: 1; left: 314px; top: 546px; position: absolute" GroupName="Avatar" value="images/avatar2.jpg"/>
        <asp:RadioButton ID="radioAvatar3" runat="server" style="z-index: 1; left: 399px; top: 548px; position: absolute" GroupName="Avatar" value="images/avatar3.jpg"/>
        <asp:RadioButton ID="radioAvatar4" runat="server" style="z-index: 1; left: 489px; top: 548px; position: absolute" GroupName="Avatar" value="images/avatar4.jpg"/>    
        <asp:RadioButton ID="radioAvatar5" runat="server" style="z-index: 1; left: 579px; top: 550px; position: absolute" GroupName="Avatar" value="images/avatar5.jpg"/>
        <asp:RadioButton ID="radioAvatar6" runat="server" style="z-index: 1; left: 669px; top: 549px; position: absolute" GroupName="Avatar" value="images/avatar6.jpg"/>
        <asp:RadioButton ID="radioAvatar7" runat="server" style="z-index: 1; left: 745px; top: 549px; position: absolute" GroupName="Avatar" value="images/avatar7.jpg"/>
        <asp:RadioButton ID="radioAvatar8" runat="server" style="z-index: 1; left: 827px; top: 549px; position: absolute" GroupName="Avatar" value="images/avatar8.jpg"/>  
        <asp:RadioButton ID="radioAvatar9" runat="server" style="z-index: 1; left: 907px; top: 549px; position: absolute" GroupName="Avatar" value="images/avatar9.jpg"/>   
        <asp:RadioButton ID="radioAvatar10" runat="server" CssClass="auto-style17" GroupName="Avatar" value="images/avatar10.jpg"/>  
            <img alt="" class="auto-style2" src="images/avatar2.jpg" /><img alt="" class="auto-style3" src="images/avatar3.jpg" /><img alt="" class="auto-style4" src="images/avatar4.jpg" /><p>
            <asp:Button ID="btnCreateAccount" runat="server" BackColor="#FFFFCC" OnClick="btnCreateAccount_Click" style="z-index: 1; left: 26px; top: 742px; position: absolute; width: 261px; height: 35px" Text="Create Account" />
         
            <img alt="" class="auto-style15" src="images/avatar9.jpg" /></p>
        <img alt="" class="auto-style1" src="images/avatar1.jpg" />
    </form>
    <p>
        <img alt="" class="auto-style12" src="images/avatar8.jpg" /></p>
</body>
</html>
