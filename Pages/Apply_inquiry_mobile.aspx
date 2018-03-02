<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Apply_inquiry_mobile.aspx.vb" Inherits="Pages_Apply_inquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="WULoading.ascx" TagName="WULoading" TagPrefix="uc2" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <!--kevin-->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>陽光獎助學金線上申請作業-手機版</title>
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
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
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

<script language="javascript" type="text/javascript">
    function changeCode() {
        var imgNode = document.getElementById("vimg");
        imgNode.src = "BuildVerifyChart.aspx?t=" + (new Date()).valueOf(); 
    }  
</script>
    
<body>
    <div class="login-clean">
    <form id="form1" runat="server" role="form" method="post">
        <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </Ajax:ToolkitScriptManager>

        <div id="header">
            <nav class="navbar navbar-light navbar-expand-md navigation-clean" style="background-color: rgb(248,137,6);">
                <a class="navbar-brand" href="#" style="color: rgb(248,245,245);">
                    <img src="../Images/quiry.png" alt="" />
                    <asp:Label ID="Lb_Apply_cate" runat="server" Text="獎助學金申請進度查詢"></asp:Label></a>
            </nav>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="table1">
                    <p style="color: Red;">
                        請輸入查詢條件：
                    </p>
                    <table>
                        <tr>
                            <td>收件編號：
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="Txt_ApplyNo" runat="server" placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                身分證號後五碼：
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="Txt_No" runat="server"  placeholder="請輸入"  CssClass="form-control"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                圖形認證碼：
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TxtBox_VerifyCode" runat="server"  MaxLength="5" placeholder="請輸入"  CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center"></br>
                                <label>
                                    <img src="BuildVerifyChart.aspx" id="vimg" onclick="changeCode()" alt="" runat="server" /></label>
                            </td> 
                            <td></br>
                                <input type="button" class="btn btn-primary" value="重新產生" onclick="changeCode()" title="重新產生" />
                            </td>
                        </tr>
                        <tr>
                            <td></br>
                                <div align="right"><label>
                                    <asp:Button ID="Btn_Ok" runat="server" Text="送出資料" OnClientClick="return submit1();"
                                        CssClass="btn btn-primary" /></label></div>
                                
                            </td>
                        </tr>
                    </table>
                    </div>
                    <center><asp:Button ID="Btn_ShowMsg" runat="server" Text="ShowMsg" CssClass="Btn" Visible="false" /></center>
                    <uc2:WULoading ID="WULoading1" runat="server" />
                    <!--=====秀出查詢無資料的訊息======-->
                    <Ajax:ConfirmButtonExtender ID="ConfirmShowMsg" runat="server" DisplayModalPopupID="Mpe_Msg" TargetControlID="Btn_ShowMsg">
                    </Ajax:ConfirmButtonExtender>
                    <Ajax:ModalPopupExtender ID="Mpe_Msg" runat="server" PopupControlID="PnlShowMsg" TargetControlID="Btn_ShowMsg" OkControlID="Btn_ShowMsg_Confirm"
                        BackgroundCssClass="modalBackground">
                    </Ajax:ModalPopupExtender>
                    <asp:Panel ID="PnlShowMsg" runat="server" CssClass="modalPopup" Style="display: none">
                        <div class="header">
                            錯誤提示
                        </div>
                        <div id="Div_ShowMsg" class="body" runat="server">
                        </div>
                        <div class="footer" align="center">
                            <asp:Button ID="Btn_ShowMsg_Confirm" runat="server" Text="確認" CssClass="yes" />
                        </div>
                    </asp:Panel>
                    <!--===========================-->
                    <!--=====秀出申請查詢結果的訊息======-->
                    <Ajax:ConfirmButtonExtender ID="QuiryOk" runat="server" DisplayModalPopupID="MpeQuiryOk" TargetControlID="Btn_ShowMsg">
                    </Ajax:ConfirmButtonExtender>
                    <Ajax:ModalPopupExtender ID="MpeQuiryOk" runat="server" PopupControlID="PnlQuiryOk" TargetControlID="Btn_ShowMsg" OkControlID="Btn_Quiry_Ok" BackgroundCssClass="modalBackground">
                    </Ajax:ModalPopupExtender>
                    <asp:Panel ID="PnlQuiryOk" runat="server" CssClass="modalPopup_Apply" Style="display: none; background-color: White">
                        <div class="header">
                            查詢申請結果
                        </div>
                        <table width="883" border="0">
                            <tr>
                                <td width="10">&nbsp;</td>
                                <td width="130">
                                    <div align="right" class="td1">申請人姓名：</div>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Lb_Name" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div align="right" class="td1">申請獎項：</div>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Lb_Award" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div align="right" class="td1">申請進度狀態：</div>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Lb_Process" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div align="right" class="td1">說明：</div>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Lb_Description" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                        <div class="footer" align="center">
                            <asp:Button ID="Btn_Quiry_Ok" runat="server" Text="結束查詢" CssClass="no" Width="90" />
                        </div>
                    </asp:Panel>
                    <!--=============================-->
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
                    <!--Jay-->
                    <script>               
                        $(function () {
                            $('form').validate({
                                rules: {                    
                                    <%=Txt_ApplyNo.UniqueID %>: { required: true},                                        
                                <%=Txt_No.UniqueID %>: { required: true},
                                <%=TxtBox_VerifyCode.UniqueID %>: { required: true},
                            },            
                        });//$('form')                         
                    });//ready      
       
                    //提交
                    function submit1(){
                        if ($('form').valid()) {            
                            ShowProgressBar();
                            return true;
                        }else{
                            return false;
                        }
                    }
                    </script>
                </div>
                <!-- table-->

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
