<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WULoading.ascx.vb" Inherits="Pages_WULoading" %>
<!-- 顯示連線中 -->
<div id="divProgress" style="text-align:center; display: none; position: fixed; top: 50%;  left: 50%;" >
    <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/loading.gif" />
    <br />
    <!--<font color="#1B3563" size="20px">資料處理中，請稍後。</font>-->
    <font color="#000080" size="16px">資料處理中，請稍後。</font>
</div>
<!--<div id="divMaskFrame" style="background-color: #F2F4F7; display: none; left: 0px;
    position: absolute; top: 0px;">
</div>-->
<div id="divMaskFrame" style="background-color: #A9A9A9; display: none; left: 0px;
    position: fixed; top: 0px;">
</div>


<Script language ="javascript" >
// 顯示讀取遮罩
function ShowProgressBar() {
    displayProgress();
    displayMaskFrame();
}
// 隱藏讀取遮罩
function HideProgressBar() {
    var progress = $('#divProgress');
    var maskFrame = $("#divMaskFrame");
    progress.hide();
    maskFrame.hide();
}
// 顯示讀取畫面
function displayProgress() {
    var w = $(window).width();
    var h = $(window).height();
    var progress = $('#divProgress');
    progress.css({ "z-index": 999999, "top": (h / 2) - (progress.height() / 2), "left": (w / 2) - (progress.width() / 2) });
    progress.show();
}
// 顯示遮罩畫面
function displayMaskFrame() {
    var w = $(window).width();
    var h = $(window).height();
    var maskFrame = $("#divMaskFrame");
    maskFrame.css({ "z-index": 999998, "opacity": 0.7, "width": w, "height": h});
    maskFrame.show();
}
</script>