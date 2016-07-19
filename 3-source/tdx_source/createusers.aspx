<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createusers.aspx.cs" Inherits="createusers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
        <asp:Button ID="btnCreateRole" runat="server" Text="Tạo role" 
            onclick="btnCreateRole_Click" />
        <br />
        <br />
        Choose role to add user:
        <br />
        <asp:DropDownList ID="ddlrole" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnDelrole" runat="server" Text="Xóa role" 
            onclick="btnDelrole_Click" />
        <br />
        
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            oncreateduser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        <br />
        <asp:Button ID="btnDelUser" runat="server" Text="Xóa User" 
            onclick="btnDelUser_Click" />
    </div>
    </form>
</body>
</html>
