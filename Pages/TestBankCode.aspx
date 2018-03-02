<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestBankCode.aspx.vb" Inherits="Pages_TestBankCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
    <!--Jay-->
    <link href="../jqueryui/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Site.css" rel="stylesheet" type="text/css" />
    <!--Jay-->
    <link href="../Style/ApplySheet.css" rel="Stylesheet" type="text/css" />
    <link href="../Style/ConfirmMsg.css" rel="Stylesheet" type="text/css" />

    <script src="../scripts/jquery-1.8.3.min.js" type="text/javascript"> </script>

    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="txtCZipCode" style="font-size: larger"></div>
    </div>
    <!--Jay-->
    <script src="../scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery.unobtrusive-ajax.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <script src="../jqueryui/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../jqueryui/datepickeroption.js" type="text/javascript"></script>
    <!--jQuery要放在bootstrap之前Just put jquery-ui plugins before bootstrap.js-->
    <script src="../scripts/bootstrap.min.js" type="text/javascript"></script>
    <!--jQuery驗證-->
    <script src="../scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../jqueryui/jquery.validate.messages_zh-TW.js" type="text/javascript"></script>
    <!--Boostrap alert;confirm-->
    <script src="../Scripts/bootbox.min.js" type="text/javascript"></script>
    <!--twzipcode-->
    <!--<script src="../scripts/jquery-twzipcode/jquery.twzipcode.min.js" type="text/javascript"></script>-->
    <script src="../scripts/jquery-BankCode/jquery.BankCode.js" type="text/javascript"></script>
    <!--Jay-->
    <script>
    $(function () {
        Init();
    });
    
    function Init()
    {
        //連絡地址
        $('#txtCZipCode').TWBankCode({
          'css': ['county', 'district', 'zipcode'],
          'readonly':true,
        });
     }//Init
     
     //合併到地址欄位
      function setAddress(source,target,zip){       
        //target.val('');
        zip.val('');
        var county = source.twzipcode('get').county.val();
        var district = source.twzipcode('get').district.val(); 
        var zipcode = source.twzipcode('get').zipcode.val(); 
                                       
        if(zipcode)
        {   
            //避免已有地址資料被清空
            if(target.val() == "")
            {
                target.val(county + district);
            }
            
            zip.val(zipcode);                
        }
    }//setAddress
        
    function Button1_onclick() {
         $('#txtCZipCode').TWBankCode('set','0040152');//台灣銀行新竹分行
    }
    </script>
    </form>
    <p>
        <input id="Button1" type="button" value="button" onclick="return Button1_onclick()" /></p>
</body>
</html>
