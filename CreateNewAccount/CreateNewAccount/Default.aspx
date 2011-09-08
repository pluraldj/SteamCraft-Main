<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CreateNewAccount._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Email Address:
        <asp:TextBox ID="textEmailAddress" runat="server"></asp:TextBox>
        <br />
        <br />
        First Name:
        <asp:TextBox ID="textFirstName" runat="server"></asp:TextBox>
        <br />
        <br />
        Last Name:
        <asp:TextBox ID="textLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:
        <asp:TextBox ID="textPassword" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="goButton" runat="server" onclick="goButton_Click" Text="Go!" />
    
    </div>
    </form>
</body>
</html>
