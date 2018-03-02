<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Apply_Save.aspx.vb" Inherits="Pages_Apply_Save" %>

<%@ Register src="rpt1.ascx" tagname="rpt1" tagprefix="uc1" %>

<%@ Register src="rpt2.ascx" tagname="rpt2" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>    
    <uc1:rpt1 ID="rpt11" runat="server" Visible="false" />
    <uc2:rpt2 ID="rpt21" runat="server" Visible="false" />    
    </form>
</body>
</html>
