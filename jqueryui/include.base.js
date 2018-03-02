$(function () {
	$('.datepicker').datepicker(); //初始化

	////fancybox 開法統一在此設定
	//$('.fancybox').fancybox({
	//	type: 'iframe',		//'iframe'
	//	minHeight: 400,
	//	closeBtn: false, // 是否顯示關閉按紐
	//	helpers: {
	//		// 防點擊背景時關閉
	//		overlay: { closeClick: false }
	//	},
	//	keys: {
	//		// 防點擊ESC時關閉
	//		close: null
	//	},
	//	onUpdate: function () {
	//		console.log('onUpdate');
	//		//$("iframe.fancybox-iframe");//IE存檔後再按關閉會有無法關閉的情形			
	//	},
	//	beforeLoad: function () {
	//		alert('uuu');
	//		console.log('beforeLoad');
	//	},
	//	afterClose: function () {
	//		console.log('afterClose');
	//		//利用AspNetPager1.CurrentPageIndex fancybox 關閉時重新捉一次資料
	//		//__doPostBack('AspNetPager1', $('#<%=txtCurrentPageIndex%>').val());
	//	},
	//});//$('.fancybox').fancybox(
});//$(function-
var x;
function showmsg(message) {
	bootbox.confirm(message, function (result) {
		if (result == true) {
			__doPostBack('link1', '');
		}

		bootbox.hideAll();
	});
	return false;
}//showmsg

