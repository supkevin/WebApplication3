<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Apply_inquiry.aspx.vb" Inherits="Pages_Apply_inquiry" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="Ajax" %>
<%@ Register src="../foot.ascx" tagname="foot" tagprefix="uc1" %>
<%@ Register src="WULoading.ascx" tagname="WULoading" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申請進度查詢</title>
    <!--Jay-->
    <link href="../jqueryui/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Site.css" rel="stylesheet" type="text/css" />
    <!--Jay-->
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link  href="../Style/ApplySheet.css"  rel="Stylesheet" type="text/css" />
    <link  href="../Style/ConfirmMsg.css"  rel="Stylesheet" type="text/css" />    
</head>
<script language="javascript" type="text/javascript">
    function changeCode() {
        var imgNode = document.getElementById("vimg");
        imgNode.src = "BuildVerifyChart.aspx?t=" + (new Date()).valueOf(); 
    }  
</script>
<body>
    <div id="wrapper1">
    <form id="form1" runat="server" class="form-inline" role="form" method="post">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate> 

    <div id="header1"><div id="fromtitle">
            <img src="../Images/quiry.png" alt="" />
            <asp:Label ID="Lb_Apply_cate" runat="server" Text="獎助學金申請進度查詢" CssClass="title1"></asp:Label>
    </div></div>    
    <hr />

    <div class="table1">
    <table width="891" border="1">
       <tr>
         <td width="1000">
           <table width="883" border="0">
              <tr>
                <td width="69">&nbsp;</td>
                <td width="215"><b>請輸入查詢條件：</b></td>
                <td colspan="2">&nbsp;</td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td><div align="right" class="td1">收件編號：</div></td>
                <td colspan="2"><asp:TextBox ID="Txt_ApplyNo" runat="server" CssClass="td2" Font-Size="Larger" placeholder="請輸入" ></asp:TextBox></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td><div align="right" class="td1">身分證號後五碼：</div></td>
                <td colspan="2"><asp:TextBox ID="Txt_No" runat="server" CssClass="td2" 
                   Font-Size="Larger"  placeholder="請輸入"></asp:TextBox></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td><div align="right" class="td1">圖形認證碼：</div></td>
                <td colspan="2">
                    <asp:TextBox ID="TxtBox_VerifyCode" runat="server" CssClass="td2" Font-Size="Larger" MaxLength="5"  placeholder="請輸入"></asp:TextBox>
                </td>
              </tr>              
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>                
                <td width="100">
                    <label><img src="BuildVerifyChart.aspx" id="vimg" onclick="changeCode()" alt="" runat="server" /></label>
                </td>
                <td>
                <div align="left">&nbsp;<input type="button" class="Btn1" value="重新產生" onclick="changeCode()" title="重新產生" /></div>
                </td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2"><label>
                    <asp:Button ID="Btn_Ok" runat="server" Text="送出資料" OnClientClick="return submit1();"
                    CssClass="Btn"/></label>
                </td>
               </tr>
            </table>
          </td>
         </tr>
        </table>        
        <center><asp:Button ID="Btn_ShowMsg" runat="server" Text="ShowMsg" CssClass="Btn" Visible="false" /></center>
        <uc2:WULoading ID="WULoading1" runat="server" />
        <!--=====秀出查詢無資料的訊息======--> 
        <Ajax:ConfirmButtonExtender ID="ConfirmShowMsg" runat="server" DisplayModalPopupID="Mpe_Msg" TargetControlID="Btn_ShowMsg">
        </Ajax:ConfirmButtonExtender>
        <Ajax:ModalPopupExtender ID="Mpe_Msg" runat="server" PopupControlID="PnlShowMsg" TargetControlID="Btn_ShowMsg"  OkControlID = "Btn_ShowMsg_Confirm"
                     BackgroundCssClass="modalBackground" >
        </Ajax:ModalPopupExtender>
        <asp:Panel ID="PnlShowMsg" runat="server" CssClass="modalPopup" Style="display: none">
                    <div class="header">
                        錯誤提示
                    </div>
                    <div id="Div_ShowMsg" class="body" runat="server">                        
                    </div>
                    <div class="footer" align="center">
                        <asp:Button ID="Btn_ShowMsg_Confirm" runat="server" Text="確認" CssClass="yes"/>                        
                    </div>
        </asp:Panel>
        <!--===========================--> 
        <!--=====秀出申請查詢結果的訊息======--> 
        <Ajax:ConfirmButtonExtender ID="QuiryOk" runat="server" DisplayModalPopupID="MpeQuiryOk" TargetControlID="Btn_ShowMsg">
        </Ajax:ConfirmButtonExtender>
        <Ajax:ModalPopupExtender ID="MpeQuiryOk" runat="server" PopupControlID="PnlQuiryOk" TargetControlID="Btn_ShowMsg" OkControlID="Btn_Quiry_Ok" BackgroundCssClass="modalBackground" >
        </Ajax:ModalPopupExtender>
        <asp:Panel ID="PnlQuiryOk" runat="server" CssClass="modalPopup_Apply" Style="display: none;background-color:White">
                    <div class="header">
                        查詢申請結果
                    </div>
            <table width="883" border="0">              
              <tr>
                <td width="10">&nbsp;</td>
                <td width="130"><div align="right" class="td1">申請人姓名：</div></td>
                <td colspan="2"><asp:Label ID="Lb_Name" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td><div align="right" class="td1">申請獎項：</div></td>
                <td colspan="2"><asp:Label ID="Lb_Award" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td><div align="right" class="td1">申請進度狀態：</div></td>
                <td colspan="2">
                   <asp:Label ID="Lb_Process" runat="server" Text=""></asp:Label>
                </td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td><div align="right" class="td1">說明：</div></td>
                <td colspan="2"><asp:Label ID="Lb_Description" runat="server" Text=""></asp:Label></td>
               </tr>
            </table>
                    <div class="footer" align="center">                        
                        <asp:Button ID="Btn_Quiry_Ok" runat="server" Text="結束查詢" CssClass="no" Width="90"/>
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
    </div> <!-- table-->

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
    </div> <!-- war -->
    <uc1:foot ID="foot1" runat="server" />
</body>
</html>
