<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OutOfApplyDate.aspx.vb" Inherits="Pages_OutOfApplyDate" %>

<%@ Register src="../foot.ascx" tagname="foot" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/cssstyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="wrapper1">
                <div id="header1">
                    <div id="fromtitle">
                        <img src="../Images/write.png" alt="" />
                    </div>
                </div>
    <div id="main1">
    <form id="form1" runat="server">
    <div>
    <div class="intro" >
                                現在非線上申請作業期間，無法進行線上申請，若有疑問，請洽本基金會。
                                
							</div>
    </div>
    </div>
    </div>
    <uc1:foot ID="foot1" runat="server" />
    </form>
</body>
</html>
