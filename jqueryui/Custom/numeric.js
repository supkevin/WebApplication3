/****
****   名稱:numeric.js
****   目的:數字欄位專用 keypress 排除非數字鍵
****   備註:2016-03-04 初版
****/

var specialKeys = new Array();
specialKeys.push(8); //Backspace    
$(function () {
    //為避免影響其他控制項改為只捉實際控制項而非由class
    var control = ".numeric";   
    $(control).bind("keypress", function (e) {
        //alert('o');
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        ////不秀錯誤訊息
        //$(".error").css("display", ret ? "none" : "inline");
        return ret;
    });
    $(control).bind("paste", function (e) {
        return false;
    });
    $(control).bind("drop", function (e) {
        return false;
    });

    //轉換為money格式
    $(control).keyup(function (e) {
        $(this).val(format($(this).val()));
    });

    $(control).click(function (e) {
        $(this).select();
    });

    var format = function (num) {
        var str = num.toString().replace("$", ""), parts = false, output = [], i = 1, formatted = null;
        if (str.indexOf(".") > 0) {
            parts = str.split(".");
            str = parts[0];
        }
        str = str.split("").reverse();
        for (var j = 0, len = str.length; j < len; j++) {
            if (str[j] != ",") {
                output.push(str[j]);
                if (i % 3 == 0 && j < (len - 1)) {
                    output.push(",");
                }
                i++;
            }
        }
        formatted = output.reverse().join("");

        //2016-02-16 改為不帶$
        //return ("$" + formatted + ((parts) ? "." + parts[1].substr(0, 2) : ""));
        return (formatted + ((parts) ? "." + parts[1].substr(0, 2) : ""));
    };
});// $(function ()   