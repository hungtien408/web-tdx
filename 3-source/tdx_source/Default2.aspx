<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register TagPrefix="asp" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="scEditor">
    </asp:ScriptManager>
    <asp:RadButton runat="server" ID="button1" OnClientClicking="alertContent" Text="Modify content"
        AutoPostBack="false">
    </asp:RadButton>
    <br />
    <asp:RadEditor runat="server" ID="editor1">
        <Content>
        <html>
        <body>

        <h1>My test Heading</h1>

        <p>My test paragraph.</p>

        </body>
        </html>
        </Content>
    </asp:RadEditor>
    <script type="text/javascript">
        function alertContent() {
            var editor = $find("<%=editor1.ClientID %>");
            //to get formatted html code (looks cleaner and is lowercase, therefore xhtml compliant)
            //if this is of no concern you can remove the mode changes
            editor.set_mode(2);
            //the correct method to get the html content
            var someContent = editor.get_html();
            alert(someContent);
            //return to design mode. There could be a flicker for the user, though
            editor.set_mode(1);
            //the editor adds the content just before the </body> tag as I am not implementing any logic in the editing process
            //and content cannot exist after the </html> tag
            //You can see the initial position if you do not set the mode back to design
            someContent += "more content";
            //set the content back in the editor
            editor.set_html(someContent);
        }
    </script>
    </form>
</body>
</html>
