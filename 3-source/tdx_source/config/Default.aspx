<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="config_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnLock" runat="server" Text="Lock" onclick="btnLock_Click" />
        <asp:Button ID="btnUnLock" runat="server" Text="UnLock" 
            onclick="btnUnLock_Click" />
    </div>
    </form>
</body>
</html>
