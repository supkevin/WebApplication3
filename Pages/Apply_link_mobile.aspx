<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Apply_link_mobile.aspx.vb" Inherits="Pages_Apply_link" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Apply_index</title>
    <!--Jay-->
    <link href="../jqueryui/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Site.css" rel="stylesheet" type="text/css" />
    <!--Jay-->
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Style/ApplySheet.css" rel="Stylesheet" type="text/css" />
    <link href="../Style/ConfirmMsg.css" rel="Stylesheet" type="text/css" />
    <!--kevin-->
    <link href="../Style/css/apply-sheet-mobile.css" rel="Stylesheet" type="text/css" />

    <script src="../scripts/jquery-1.8.3.min.js" type="text/javascript"> </script>
    <link href="../Style/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Style/css/apply-link.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         body{
            background-color:#f3d39a;
        }
         .centered{
    float: none;
    margin: 0 auto;
}
        #Lb_Apply_cate{
                font-size:24px;
                font-weight:bold;
            }
        .login-clean form {
            max-width: 500px;
            width: 90%;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 40px;
            border-radius: 4px;
            color: #505e6c;
            box-shadow: 1px 1px 5px rgba(0,0,0,0.1);
        }
        .table1{
            margin:0px;
            padding:0px;
        }

        .login-clean {
            padding: 80px 0;
        }

        @media (max-width:767px) {
            body{
            background-color:#ffffff;
        }
            .login-clean {
                padding: 0px 0;
            }
                .login-clean form {
                    width: 100%;
                    margin: 0 auto;
                    background-color: #ffffff;
                    padding: 40px;
                }
            #Lb_Apply_cate{
                font-size:18px;
                font-weight:bold;
            }
        }
        }
    </style>
</head>

<body>
      <div class=" login-clean">
    <form id="form1" runat="server">
          
            <div class="row">
                <div class="col-md-12">
                    <h3><img src="../Images/logo.jpg" class="img-fluid"></h3>
                    <h3 class="text-center">2015陽光獎助學金<br></h3>
                </div>
            </div>
            <div class="row" id="light-bc">
                <div class="col-12 col-md-6"><img src="../Images/write.png"><a class="btn btn-info" role="button" href="../Pages/apply_sheet_mobile.aspx?m=0">陽光獎助學金線上申請作業</a></div>
                <div class="col-12 col-md-6"><img src="../Images/write.png"><a class="btn btn-primary" role="button" href="../Pages/apply_sheet_mobile.aspx?m=1">仁寶獎助學金線上申請作業</a></div>
                <div class="col-12 col-md-12"  align="center">
                    <hr><img src="../Images/quiry.png"><a class="btn btn-secondary" role="button" href="../Pages/Apply_inquiry_mobile.aspx">獎助學金申請進度查詢</a></div>
                <div class="col-12 col-md-12" >
                    <hr>
                    <p>財團法人陽光社會福利基金會　<br>郵政劃撥帳號：05583335　<br>戶名：陽光社會福利基金會<br>104台北市南京東路三段91號3樓　　<br>TEL：(02)2507-8006　　<br>FAX：(02)2507-0251　<br></p>
                </div>
            </div>



    </form>        </div>
</body>

</html>
  