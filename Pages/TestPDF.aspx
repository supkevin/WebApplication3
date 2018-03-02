<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestPDF.aspx.vb" Inherits="Pages_TestPDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="rpt0" runat="server" Text="rpt0" />
    
    </div>
    </form>
    <table class="style1">
        <tr>
            <td rowspan="2">
                0</td>
            <td>
                1</td>
            <td rowspan="2">
                3</td>
        </tr>
        <tr>
            <td>
                2</td>
        </tr>
    </table>
</body>
</html>
