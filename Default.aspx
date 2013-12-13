<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DxButtonLinkTest.Default" %>
<%@ Register TagPrefix="dxx" Namespace="DXX" Assembly="DxButtonLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DxButtonLink</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxx:ButtonLink runat="server"
            Text="Derived from DevExpress ASPxButton Class"
            NavigateUrl="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxEditorsASPxButtontopic" />
    </div>
    </form>
</body>
</html>
