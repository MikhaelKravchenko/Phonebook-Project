<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="PhoneBook2.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Logout</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Logout successful."></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">
            You will redirect in 5 seconds. If you didnt, click here to redirect.</asp:HyperLink>
    </div>
    </form>
</body>
</html> 