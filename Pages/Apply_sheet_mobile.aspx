<%@ Page Language="VB" AutoEventWireup="True" MaintainScrollPositionOnPostback="true"
    CodeFile="Apply_sheet_mobile.aspx.vb" Inherits="Pages_Apply_sheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="~/Pages/WULoading.ascx" TagName="wuloading" TagPrefix="uc" %>
<%@ Register Src="rpt1.ascx" TagName="rpt1" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <!--kevin-->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>陽光獎助學金線上申請作業-手機版</title>
    <!--tc-->

    <script src="../scripts/apply.js" type="text/javascript"></script>

    <!--tc-->
    <!--Jay-->
    <link href="../jqueryui/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Site.css" rel="stylesheet" type="text/css" />
    <!--Jay-->
    <link href="../Style/ApplySheet.css" rel="Stylesheet" type="text/css" />
    <link href="../Style/ConfirmMsg.css" rel="Stylesheet" type="text/css" />
    <!--kevin-->
    <link href="../Style/bootstrap/css/bootstrap.min.css" rel="Stylesheet" type="text/css" />
    <link href="../Style/css/apply-sheet-mobile.css" rel="Stylesheet" type="text/css" />
    <link href="../Style/css/Contact-Form-Clean.css" rel="Stylesheet" type="text/css" />
    <link href="../Style/css/Navigation-Clean1.css" rel="Stylesheet" type="text/css" />

    <script src="../scripts/jquery-1.8.3.min.js" type="text/javascript"> </script>

    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .container {
            background-color: #F2D596;
            padding: 0px;
        }

        @media (min-width:1200px) {
            body {
                background-color: #fff;
                height: 2070px;
            }

            .container {
                max-width: 960px;
                padding: 10px;
            }

            .form-control {
                width: 94%;
            }
            #Lb_Apply_cate{
                font-size:24px;
            }
        }

        @media (min-width:992px) {
            body {
                background-color: #fff;
                height: 2070px;
            }

            .container {
                max-width: 960px;
                padding: 10px;
            }

            .form-control {
                width: 94%;
            }
            #Lb_Apply_cate{
                font-size:24px;
            }
        }




        @media (max-width:767px) {
            body {
                font-size: 16px;
                padding: 0px;
            }
            .container {
                padding: 5px;
            }

            .form-control {
                width: 98%;
            }

            .info {
                font-size: 12px;
                margin-top: -10px;
                text-align: center;
            }
        }

        }

        .cp {
            display: block;
            margin-top: 1em;
            margin-bottom: 1em;
            margin-left: 0;
            margin-right: 0;
        }

        .cred {
            color: #FF0000;
        }

        .ctr {
            display: table-row;
            vertical-align: inherit;
            border: 2px solid #000000;
            width: auto;
        }

        .ctd {
            border: 2px solid #000000;
            display: table-cell;
            vertical-align: middle;
            padding-left: 5px;
        }

        .ctd1 {
            border: 2px solid #000000;
            display: table-cell;
            vertical-align: middle;
            text-align: center;
            /*width: 80px;*/
            background-color: #CCCCCC;
        }

        .cstrong {
            font-weight: bold;
        }
        /* Jas's CSS ToolTip */ a.jastips {
            z-index: 9;
            color: #690;
            border-bottom: 1px dotted #690;
            text-decoration: none;
        }

            a.jastips:hover {
                position: relative;
                z-index: 99;
                cursor: help;
            }

            a.jastips span {
                display: none;
            }

            a.jastips:hover span {
                display: block;
                position: absolute;
                float: left;
                top: -2.25em;
                left: 0;
                width: 100%;
                background: #666;
                border: 1px solid #000;
                color: #fff;
                padding: 1px 5px;
                /*margin: 60px 0px 0px 100px;*/
                z-index: 9;
            }
        /* end of Jas's CSS ToolTip */
    </style>
    <style>
        /* CSS */ .zipcode {
            background-color: lightgrey;
            margin: 5px 0px 5px 0px;
            width: 90px; /*background-color: #c00;*/ /*color: #fff;*/
        }

        .county {
            margin: 5px; /*
            background-color: #4169E1;
            color: #fff;*/
        }

        .district {
            margin: 5px; /*
            background-color: #008000;
            color: #fff;*/
        }

        .tabletest {
            width: 100%;
            margin: -15px;
            margin-right: 20px;
        }
    </style>
</head>

<script language="javascript" type="text/javascript">
    /*
    function changeCode() {
    var imgNode = document.getElementById("vimg");
    imgNode.src = "BuildVerifyChart.aspx?t=" + (new Date()).valueOf();
    }
    */
    function NewWindow(str_value) {
        if (str_value == '') {
            alert("獎項類別無法取得!");
            return false;
        }
        //alert("str_value=" + str_value);

        ShowProgressBar();
        window.open("Apply_Save.aspx?m=" + str_value, "_blank");
    }
    function BackApply() {
        //window.location = "Apply_sheet.aspx";
        window.location = "<%= BackToHome %>";
    }
    
      
</script>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </Ajax:ToolkitScriptManager>
            <div id="header">
                <nav class="navbar navbar-light navbar-expand-md navigation-clean" style="background-color: rgb(248,137,6);">
                    <a class="navbar-brand" href="#" style="color: rgb(248,245,245);">
                        <img src="../Images/write.png" alt="" /><asp:Label ID="Lb_Apply_cate" runat="server" Text=""></asp:Label></a>
                </nav>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <!--假Link控制是否Popup Modal-->
                    <asp:LinkButton ID="lnkFake" runat="server" Style="display: none"></asp:LinkButton>
                    <asp:Button ID="btnFake" runat="server" Text="btnFake" CssClass="Btn" Style="display: none" />

                    <div class="table1">
                        <p style="color: Red; text-align: center">
                            提醒您！有*符號為必填欄位
                        </p>
                        <div class="form-row">
                            <div class="form-group col-6">
                                <label for="Txt_tname">*姓名：</label>
                                <asp:TextBox ID="Txt_Name" runat="server" CssClass="form-control" placeholder="請輸入"
                                    MaxLength="20"></asp:TextBox>
                            </div>
                            <div class="form-group col-6">
                                <label for="Txt_OldName">改名前之姓名：</label>
                                <asp:TextBox ID="Txt_OldName" runat="server" CssClass="form-control"
                                    MaxLength="20"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <span class="info">多次申請者，若曾更改姓名，請再填寫改名前之姓名欄位。 </span>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-6">
                                <label for="sex">*性別：</label>
                                <asp:RadioButtonList ID="RdButton_Sex" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Value="M">男&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="F">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="form-group col-6">
                                <label for="Txt_Id">*身分證字號：</label>
                                <asp:TextBox ID="Txt_Id" runat="server" CssClass="form-control" placeholder="請輸入"
                                    MaxLength="10" AutoPostBack="True"></asp:TextBox><asp:Label ID="Lb_Id" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-4">
                                <label for="DpDownList_Year">*出生年月日：</label>
                                <asp:DropDownList ID="DpDownList_Year" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-4">
                                <label for="DpDownList_Month"></label>
                                <asp:DropDownList ID="DpDownList_Month" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-4">
                                <label for="DpDownList_Day"></label>
                                <asp:DropDownList ID="DpDownList_Day" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <label for="inputAddress">*居住地：</label>
                        </div>
                        <!--利用此隱藏欄位show錯誤訊息不可設為ReadOnly後端捉不到資料-->
                        <!--(start)jay(start)-->
                        <div id="txtCZipCode" class="form-row">
                        </div>
                        <div style="display: none">
                            <asp:DropDownList ID="DpDownList_City" runat="server" AutoPostBack="True">
                            </asp:DropDownList>&nbsp;
                                <asp:DropDownList ID="DpDownList_Downtown" runat="server"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                        </div>
                        <asp:TextBox ID="TxtBox_Zid" runat="server" ReadOnly="false"
                            Style="display: none"></asp:TextBox>
                        <div class="form-group">
                            <asp:TextBox ID="TxtBox_Address_Bak" runat="server"
                                Style="display: none" CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="TxtBox_Address" runat="server"
                                MaxLength="100" placeholder="請填寫完整地址" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <label for="inputAddress">*戶籍地：</label><asp:CheckBox ID="CkBox_RAddress" runat="server" Text="同聯絡地址"
                                onclick="CheckAdd(this);" />
                        </div>
                        <!--利用此隱藏欄位show錯誤訊息不可設為ReadOnly後端捉不到資料-->
                        <!--(start)jay(start)-->
                        <div id="txtRZipCode" class="form-row">
                        </div>
                        <div style="display: none">
                            <asp:DropDownList ID="DpDownList_RCity" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="DpDownList_RDowntown" runat="server"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <asp:TextBox ID="TxtBox_RZip" runat="server" ReadOnly="false"
                            Style="display: none"></asp:TextBox>
                        <div class="form-group">
                            <div id="SameAddress">
                                <!-- tc 記錄縣市用 -->
                                <asp:TextBox ID="TxtBox_RAddress_Bak" runat="server"
                                    Style="display: none"></asp:TextBox>

                                <asp:TextBox ID="TxtBox_RAddress" runat="server"
                                    MaxLength="100" placeholder="請填寫完整地址" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-6">
                                <label for="TxtBox_Tel_1">*電話(日)：</label>
                                <asp:TextBox ID="TxtBox_Tel_1" runat="server" MaxLength="20"
                                    placeholder="範例：07-5587166" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-6">
                                <label for="TxtBox_Tel_2">*電話(夜)：</label>
                                <asp:TextBox ID="TxtBox_Tel_2" runat="server" MaxLength="20"
                                    placeholder="範例：07-5587166" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-6">
                                <label for="TxtBox_Mobile">*手機：</label>
                                <asp:TextBox ID="TxtBox_Mobile" runat="server"
                                    MaxLength="15" placeholder="範例：0955-888999" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-6">
                                <label for="TxtBox_Email">*電子郵件信箱：</label>
                                <asp:TextBox ID="TxtBox_Email" runat="server" MaxLength="50"
                                    placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <table id="Table_Damage" runat="server">
                                <tr>
                                    <td>*損傷類別：
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="RdButton_Damage" runat="server" RepeatDirection="Vertical"
                                            RepeatLayout="Flow">
                                            <asp:ListItem Value="B0"> 灼燙傷</asp:ListItem>
                                            <asp:ListItem Value="F1"> 顏面損傷1.顱顏畸形(含小耳症)</asp:ListItem>
                                            <asp:ListItem Value="F2"> 顏面損傷2.腫瘤病變(含血管瘤)</asp:ListItem>
                                            <asp:ListItem Value="F3"> 顏面損傷3.口腔癌</asp:ListItem>
                                            <asp:ListItem Value="F4"> 顏面損傷4.嚴重外傷</asp:ListItem>
                                            <asp:ListItem Value="F5"> (含魚鱗癬症、胎記、太田母斑)<br>顏面損傷5.皮膚病變</asp:ListItem>
                                            <asp:ListItem Value="F6"> 顏面損傷6.其他</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:TextBox ID="TxtBox_Damage" runat="server"
                                            MaxLength="20" CssClass="form-control"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblTrauma_Old" runat="server" Text="lblTrauma_Old" Visible="False" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <label for="TxtBox_School">*<span class="bolder">現在</span>就讀(畢)學校：</label>
                            <asp:TextBox ID="TxtBox_School" runat="server"
                                MaxLength="50" placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-6">
                                <label for="TxtBox_Dep">科系名稱：</label>
                                <asp:TextBox ID="TxtBox_Dep" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-6">
                                <label for="TxtBox_Grage">*年級：</label>
                                <asp:TextBox ID="TxtBox_Grage" runat="server" MaxLength="1"
                                    placeholder="請輸入阿拉伯數字" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-7">
                                <label for="TxtBox_Dep">*申請次數：</label><br />
                                <asp:RadioButtonList ID="RdButton_ApplyTimes" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Value="1">初次申請</asp:ListItem>
                                    <asp:ListItem Value="2">多次申請</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="apply_groups" runat="server" class="form-group col-5">
                                <label for="TxtBox_Grage">*申請組別：</label>
                                <asp:DropDownList ID="DpDownList_Awards" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">1國小組</asp:ListItem>
                                    <asp:ListItem Value="2">2國中組</asp:ListItem>
                                    <asp:ListItem Value="3">3高中組</asp:ListItem>
                                    <asp:ListItem Value="4">4大學組</asp:ListItem>
                                    <asp:ListItem Value="5">5碩士組</asp:ListItem>
                                    <asp:ListItem Value="6">6博士組</asp:ListItem>
                                </asp:DropDownList>
                                <span class="info">(以成績單年級勾選)</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <table id="Table_Apply_Item_S" runat="server">
                                <tr>
                                    <td>*申請獎項：
                                            <!-- Button trigger modal -->
                                        <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#exampleModal">
                                            獎項條件及內容
                                        </button>

                                        <!-- Modal -->
                                        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel">獎項條件及內容</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <span>(一)特殊才藝優秀獎學金<br />
                                                            申請條件：<br />
                                                            凡特殊才藝(文學、音樂、美術、語言、體育、科技)獲105學年度個人校際以上比賽前三名(不包含校內舉辦之比賽)。<br />
                                                            獎助金額：<br />
                                                            (1)博士班  一萬元整 (2)碩士班  一萬元整(3)大專  一萬元整(4)高中(職)  陸仟元整(5)國中  參仟伍佰元整(6)國小  貳仟元整<br />
                                                            <br />
                                                        </span>
                                                        <span>(二)優秀獎學金<br />
                                                            申請條件：<br />
                                                            (1)國小學業(智育)105學年度總平均成績在90分以上者<br />
                                                            (2)國中、高中(職)、大專、研究所學業(智育)105學年度總平均成績在80分以上者<br />
                                                            獎助金額：<br />
                                                            (1)博士班  一萬元整 (2)碩士班  一萬元整(3)大專  一萬元整(4)高中(職)  陸仟元整(5)國中  參仟伍佰元整(6)國小  貳仟元整<br />
                                                            <br />
                                                        </span>
                                                        <span>(三)升學獎學金<br />
                                                            申請條件：<br />
                                                            (1)105學年度高中(職)考入公、私立大學(含二專)者<br />
                                                            (2)105學年度大專考入公、私立研究所者<br />
                                                            獎助金額：<br />
                                                            (1)高中升大學  一萬元整(2)大專升研究所  (碩士、博士)   一萬元整<br />
                                                            <br />
                                                        </span>
                                                        <span>(四)助學金<br />
                                                            申請條件：<br />
                                                            國小、國中、高中(職)、大專學業(智育)105學年度總平均在60分(丙等)以上者<br />
                                                            獎助金額：<br />
                                                            (1)大專以上  參仟伍佰元整(2)高中(職)  貳仟伍佰元整(3)國中  壹仟伍佰元整(4)國小  壹仟元整<br />
                                                            <br />
                                                        </span>
                                                        <span>(五)勇源-陽光子女助學金<br />
                                                            申請條件：<br />
                                                            顏損或遭重大燒傷之子女，於<br />
                                                            (1)國小學業(智育)105學年度總平均成績在80分以上者<br />
                                                            (2)國中、高中(職)、大專、研究所學業(智育) 105學年度總平均成績在70分以上者<br />
                                                            申請人提出申請時，傷友本人須健在，但死亡未滿一年者亦可申請。<br />
                                                            獎助金額：<br />
                                                            (1)大專以上  參仟伍佰元整(2)高中(職)   貳仟伍佰元整(3)國中  壹仟伍佰元整(4)國小  壹仟元整<br />
                                                            <br />
                                                        </span>
                                                        <span>(六)明閱科技-陽光子女特殊才藝獎學金<br />
                                                            申請條件：<br />
                                                            顏面損傷或重大燒傷者之子女，凡特殊才藝(文學、音樂、美術、語言、體育、科技)獲105學年度個人校際以上比賽前三名者(不包含校內舉辦之比賽)。<br />
                                                            申請人提出申請時，傷友本人須健在，但死亡未滿一年者亦可申請。<br />
                                                            獎助金額：<br />
                                                            (1)博士班  一萬元整 (2)碩士班  一萬元整(3)大專  一萬元整(4)高中(職)  陸仟元整(5)國中  參仟伍佰元整(6)國小  貳仟元整
                        <br />
                                                            <br />
                                                        </span>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="RdButton_Apply_Item_S" runat="server" RepeatDirection="Vertical"
                                            RepeatLayout="Flow" onclick="ApplyChange();">
                                            <asp:ListItem Value="S1">
                        (一)特殊才藝優秀獎學金
                        <%--<span>
                        申請條件：<br />
                        凡特殊才藝(文學、音樂、美術、語言、體育、科技)獲105學年度個人校際以上比賽前三名(不包含校內舉辦之比賽)。<br />
                        獎助金額：<br />
                        (1)博士班  一萬元整 (2)碩士班  一萬元整(3)大專  一萬元整(4)高中(職)  陸仟元整(5)國中  參仟伍佰元整(6)國小  貳仟元整
                        </span>--%>
                        </a></asp:ListItem>
                                            <asp:ListItem Value="S2">
                       (二)優秀獎學金
                        <%--<span>
                        申請條件：<br />
                        (1)國小學業(智育)105學年度總平均成績在90分以上者<br />
                        (2)國中、高中(職)、大專、研究所學業(智育)105學年度總平均成績在80分以上者<br />
                        獎助金額：<br />
                        (1)博士班  一萬元整 (2)碩士班  一萬元整(3)大專  一萬元整(4)高中(職)  陸仟元整(5)國中  參仟伍佰元整(6)國小  貳仟元整
                        </span>--%>
                        </a></asp:ListItem>
                                            <asp:ListItem Value="S3">
                        (三)升學獎學金
                        <%--<span>
                        申請條件：<br />
                        (1)105學年度高中(職)考入公、私立大學(含二專)者<br />
                        (2)105學年度大專考入公、私立研究所者<br />
                        獎助金額：<br />
                        (1)高中升大學  一萬元整(2)大專升研究所  (碩士、博士)   一萬元整<br />
                        </span>--%>
                        </a></asp:ListItem>
                                            <asp:ListItem Value="S4">
                        (四)助學金
                        <%--<span>
                        申請條件：<br />
                        國小、國中、高中(職)、大專學業(智育)105學年度總平均在60分(丙等)以上者<br />
                        獎助金額：<br />
                        (1)大專以上  參仟伍佰元整(2)高中(職)  貳仟伍佰元整(3)國中  壹仟伍佰元整(4)國小  壹仟元整
                        </span>--%>
                        </a></asp:ListItem>
                                            <asp:ListItem Value="S5">                    
                        (五)勇源-陽光子女助學金    
                        <%--<span>
                        申請條件：<br />
                        顏損或遭重大燒傷之子女，於<br />
                        (1)國小學業(智育)105學年度總平均成績在80分以上者<br />
                        (2)國中、高中(職)、大專、研究所學業(智育) 105學年度總平均成績在70分以上者<br />
                        申請人提出申請時，傷友本人須健在，但死亡未滿一年者亦可申請。<br />
                        獎助金額：<br />
                        (1)大專以上  參仟伍佰元整(2)高中(職)   貳仟伍佰元整(3)國中  壹仟伍佰元整(4)國小  壹仟元整
                        </span>--%>
                        </a></asp:ListItem>
                                            <asp:ListItem Value="S6">
                        (六)明閱科技-陽光子女特殊才藝獎學金
                        <%--<span>
                        申請條件：<br />
                        顏面損傷或重大燒傷者之子女，凡特殊才藝(文學、音樂、美術、語言、體育、科技)獲105學年度個人校際以上比賽前三名者(不包含校內舉辦之比賽)。<br />
                        申請人提出申請時，傷友本人須健在，但死亡未滿一年者亦可申請。<br />
                        獎助金額：<br />
                        (1)博士班  一萬元整 (2)碩士班  一萬元整(3)大專  一萬元整(4)高中(職)  陸仟元整(5)國中  參仟伍佰元整(6)國小  貳仟元整
                        </span>--%>
                        </a></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <!-- tc parent-->
                                        <div id="ShowParent" runat="server">
                                            <asp:Label ID="Label2" runat="server" Text="*子女助學金之親屬關係："></asp:Label>
                                            <asp:RadioButtonList ID="RdButton_Parents" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Value="1">父&nbsp&nbsp&nbsp</asp:ListItem>
                                                <asp:ListItem Value="2">母</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Text="*子女助學金之損傷者姓名"></asp:Label><asp:TextBox
                                                ID="TxtBox_PName" runat="server" MaxLength="20"
                                                placeholder="請輸入父(母)姓名" CssClass="form-control"></asp:TextBox><br />
                                        </div>
                                        <!--parent-->
                                    </td>
                                </tr>
                            </table>
                            <table id="Table_Apply_Item_Z" runat="server">
                                <tr>
                                    <td>*申請獎項：
                                            <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#exampleModal1">
                                                獎項條件及內容
                                            </button>
                                        <!-- Modal -->
                                        <div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel1">獎項條件及內容</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <span>電腦優秀獎助學金<br />
                                                            申請條件：<br />
                                                            申請資格：<br />
                                                            於105年7月1日至106年6月30日參加政府正式檢定且通過取得證明者。(校內舉辦之任何檢定不算在內)<br />
                                                            *上述資格申請時須附上「檢定合格證明」。<br />
                                                            *TQC檢定為企業人才技能認證，是財團法人中華民國電腦技能基金會針對企業用才需求，所提出來的一項整合性認證。故此檢定之通過「非」本獎項之獎助範疇<br />
                                                            獎項名額及獎金：<br />
                                                            電腦優秀獎助學金及電腦傑出才藝獎合計共錄取十位，以未請領陽光基金會當年度其他獎助學金者為優先，每名獎助金額為壹萬元。
                        <br />
                                                            <br />
                                                        </span>
                                                        <span>電腦傑出才藝獎<br />
                                                            申請資格：<br />
                                                            1.於105年7月1日至106年6月30日期間，參加國內外政府單位、學校或民間團體舉辦之各項電腦專才比賽獲得傑出優秀獎項者。<br />
                                                            2.在學學生申請此項時，須是校際比賽之獎項。<br />
                                                            獎項名額及獎金：<br />
                                                            電腦優秀獎助學金及電腦傑出才藝獎合計共錄取十位，以未請領陽光基金會當年度其他獎助學金者為優先，每名獎助金額為壹萬元。
                        <br />
                                                            <br />
                                                        </span>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="RdButton_Apply_Item_Z" runat="server" RepeatDirection="Vertical"
                                            RepeatLayout="Flow">
                                            <asp:ListItem Value="Z1">
                        電腦優秀獎助學金
                        <%--<span>
                        申請資格：<br />
                        於105年7月1日至106年6月30日參加政府正式檢定且通過取得證明者。(校內舉辦之任何檢定不算在內)<br />
                        *上述資格申請時須附上「檢定合格證明」。<br />
                        *TQC檢定為企業人才技能認證，是財團法人中華民國電腦技能基金會針對企業用才需求，所提出來的一項整合性認證。故此檢定之通過「非」本獎項之獎助範疇<br />
                        獎項名額及獎金：<br />
                        電腦優秀獎助學金及電腦傑出才藝獎合計共錄取十位，以未請領陽光基金會當年度其他獎助學金者為優先，每名獎助金額為壹萬元。
                        </span>--%>
                        </a></asp:ListItem>
                                            <asp:ListItem Value="Z2"> 
                        電腦傑出才藝獎
                        <%--<span>
                        申請資格：<br />
                        1.於105年7月1日至106年6月30日期間，參加國內外政府單位、學校或民間團體舉辦之各項電腦專才比賽獲得傑出優秀獎項者。<br />
                        2.在學學生申請此項時，須是校際比賽之獎項。<br />
                        獎項名額及獎金：<br />
                        電腦優秀獎助學金及電腦傑出才藝獎合計共錄取十位，以未請領陽光基金會當年度其他獎助學金者為優先，每名獎助金額為壹萬元。
                        </span>--%>
                        </a></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            <table id="Table_Apply_Item_M" runat="server">
                                <tr>
                                    <td>*申請獎項：
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="RdButton_Apply_Item_M" runat="server" RepeatDirection="Vertical"
                                            RepeatLayout="Flow">
                                            <asp:ListItem Value="M1">明閱科技_陽光子女特殊才藝獎助學金</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <asp:Label ID="Label10" runat="server" Text="子女助學金之損傷者姓名"></asp:Label><asp:TextBox
                                            ID="TxtBox_PName_M" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox><br />
                                        <asp:Label ID="Label11" runat="server" Text="子女助學金之親屬關係："></asp:Label>
                                        <asp:RadioButtonList ID="RdButton_Parents_M" runat="server" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow">
                                            <asp:ListItem Value="1">父&nbsp&nbsp&nbsp</asp:ListItem>
                                            <asp:ListItem Value="2">母</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <label for="RdButton_Mode">*申請方式：</label>
                            <asp:RadioButtonList ID="RdButton_Mode" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow" onclick="CheckRe();">
                                <asp:ListItem Value="1">自行申請&nbsp&nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="2">單位推薦</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <div id="recommend">
                                <div class="form-row">
                                    <div class="form-group col-6">
                                        <asp:Label ID="Label3" runat="server" Text="*推薦單位："></asp:Label><asp:TextBox
                                            ID="TxtBox_Recommend" runat="server" MaxLength="50"
                                            placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-6">
                                        <asp:Label ID="Label4" runat="server" Text="*推薦人姓名："></asp:Label><asp:TextBox
                                            ID="TxtBox_Rec_Name" runat="server" MaxLength="20"
                                            placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-6">
                                        <asp:Label ID="Label5" runat="server" Text="*推薦人職務："></asp:Label><asp:TextBox
                                            ID="TxtBox_Rec_Position" runat="server" MaxLength="20"
                                            placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-6">
                                        <asp:Label ID="Label6" runat="server" Text="*推薦人電話："></asp:Label><asp:TextBox
                                            ID="TxtBox_Rec_Tel" runat="server" MaxLength="20"
                                            placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!--推薦人-->
                            <div class="form-row">
                                <div class="form-group col-4">
                                    <asp:Label ID="Label7" runat="server" Text="戶名："></asp:Label><asp:TextBox
                                        ID="TxtBox_Account_Name" runat="server" MaxLength="20"
                                        placeholder="限本人" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-8">
                                    <asp:Label ID="Label9" runat="server" Text="銀行帳戶："></asp:Label><asp:TextBox
                                        ID="TxtBox_Account_No" runat="server" MaxLength="20"
                                        placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                                    <span class="info">(請只輸入數字,郵局請填局號+帳號共14碼)</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <div style="display: none">
                                    <asp:Label ID="Label8" runat="server" Text="銀行代碼："></asp:Label>
                                    <asp:DropDownList ID="DpDownList_Bank_Code" runat="server" AutoPostBack="True"
                                        onchange="ShowProgressBar();">
                                    </asp:DropDownList>
                                </div>
                                <div style="display: none">
                                    <asp:Label ID="Label12" runat="server" Text="分行代碼："></asp:Label>
                                    <asp:DropDownList ID="DpDownList_Bank_Name" runat="server" onchange="WriteBankCode();">
                                    </asp:DropDownList>
                                </div>
                                <!--(bank)Jay(bank)-->
                                <div style="display: inline; width: 100%">
                                    <asp:Label ID="Label13" runat="server" Text="" Style="display: none"></asp:Label>
                                    <div id="txtBank" style="display: inline"></div>
                                    <asp:TextBox runat="server"
                                        ID="TxtBox_Bank" Style="display: none" disabled="disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <!--(bank)Jay(bank)-->
                            </div>

                            <div class="form-row">
                                <div class="form-group col-4">
                                    <span onclick="document.getElementById('lblMyLink').click();">*圖形驗證碼：</span>
                                    <asp:LinkButton ID="lblMyLink" OnClick="lblMyLink_Click" runat="server" Style="display: none;">My Link</asp:LinkButton>
                                    <asp:TextBox ID="TxtBox_VerifyCode" runat="server"
                                        MaxLength="5" placeholder="請輸入" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-4">
                                    <br />
                                    <asp:Image ID="imgCode" runat="server" ImageUrl="BuildVerifyChart.aspx" onclick="ChgCode();"
                                        CssClass="imgCode" Height="32px" />
                                </div>
                                <div class="form-group col-4">
                                    <br />
                                    <input type="button" class="btn btn-primary" value="重新產生" onclick="ChgCode();" title="重新產生" />
                                    <asp:Button ID="btnChangeCode" runat="server" Text="重新產生" OnClientClick="ShowProgressBar();"
                                        Visible="false" CssClass="btn btn-primary" /></td>
                                </div>
                            </div>
                            <%--<table class="tabletest">                       
                       <%-- <tr id="apply_groups" runat="server">                                            
                    </table>--%>
                            <br />
                            <center>
                            <asp:Button ID="btn1" runat="server" Text="測試資料(陽光)" Visible="true" />
                            <asp:Button ID="btn2" runat="server" Text="測試資料(仁寶)" Visible="true" />
                            <asp:Button ID="btn3" runat="server" Text="測試資料(陽光6)" Visible="False" />
                            <asp:Button ID="Button2" runat="server" Text="ZipCode" Visible="False" OnClientClick="return showZipCode();" />
                            <asp:Button ID="Button3" runat="server" Text="btnFake" Visible="False" CssClass="Btn"
                                OnClientClick="return $('form').valid();" />
                            <asp:Button ID="Btn_Ok" runat="server" Text="送出資料" OnClientClick="return ShowModalPopup();" CssClass="btn btn-success"/></center>
                            <center>
                            <asp:Button ID="Btn_ShowMsg" runat="server" Text="ShowMsg" CssClass="Btn" Visible="false" /></center>
                            <asp:Button ID="Btn_Apply_End_H" runat="server" Text="結束" CssClass="no" Visible="false" />
                            <uc:wuloading ID="WULoading1" runat="server" />
                            <!--=====秀出是否送出資料確認的訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ComfirmOk" runat="server" DisplayModalPopupID="mpe"
                                TargetControlID="lnkFake">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
                                OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                                <div class="header">
                                    確認提示
                                </div>
                                <div class="body">
                                    你確定要送出申請？
                                </div>
                                <div class="footer" align="center">
                                    <asp:Button ID="btnYes" runat="server" Text="是" CssClass="yes" OnClientClick="return DoApply();" />
                                    <asp:Button ID="btnNo" runat="server" Text="否" CssClass="no" />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                            <!--=============================-->
                            <!--=====秀出申請成功確認的訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ConfirmApplyOk" runat="server" DisplayModalPopupID="MpeAppleOk"
                                TargetControlID="Btn_ShowMsg">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="MpeAppleOk" runat="server" PopupControlID="PnlApplyOk"
                                TargetControlID="Btn_ShowMsg" CancelControlID="Btn_Apply_End" BackgroundCssClass="modalBackground">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="PnlApplyOk" runat="server" CssClass="modalPopup_Apply_mobile" Style="display: none; background-color: White">
                                <div class="header">
                                    申請成功提示
                                </div>
                                <div id="Div_ApplyOk" class="body_Apply" runat="server">
                                </div>
                                <div class="footer" align="center">
                                    <asp:Button ID="Btn_Apply_Save" runat="server" Text="儲存申請書" CssClass="yes" Width="100" />
                                    <asp:Button ID="Btn_Apply_End" runat="server" Text="" Width="0" Height="0" BackColor="White"
                                        BorderColor="White" BorderWidth="0" Enabled="False" />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                            <!--=============================-->
                            <!--=====秀出申請發信訊息的訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ConfirmSendMail" runat="server" DisplayModalPopupID="MpeSendMail"
                                TargetControlID="Btn_ShowMsg">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="MpeSendMail" runat="server" PopupControlID="Pn1SendMail"
                                TargetControlID="Btn_ShowMsg" CancelControlID="Btn_SendMail_End" BackgroundCssClass="modalBackground">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="Pn1SendMail" runat="server" Style="display: none; background-color: White">
                                <div class="header">
                                    線上申請收件通知
                                </div>
                                <div id="Div_SendMail" runat="server">
                                </div>
                                <div class="footer" align="center">
                                    <!--
                            <asp:Button ID="Btn_CkApply_Item" runat="server" Text="繼續申請其他獎項" CssClass="yes" Width="140" />
                        -->
                                    <asp:Button ID="Btn_SendMail_End" runat="server" Text="結束" CssClass="no" OnClientClick="BackApply()" />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                            <!--=============================-->
                            <!--=====秀出系統自動判斷是否繼續申請其他獎項的訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ConfirmCkApplyOther" runat="server" DisplayModalPopupID="MpeCkApplyOther"
                                TargetControlID="Btn_ShowMsg">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="MpeCkApplyOther" runat="server" PopupControlID="PnlCkApplyOther"
                                TargetControlID="Btn_ShowMsg" CancelControlID="Btn_SendMail_End" BackgroundCssClass="modalBackground">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="PnlCkApplyOther" runat="server" Style="display: none; background-color: White">
                                <div class="header">
                                    系統提醒申請其他獎項通知
                                </div>
                                <div id="Div_CkApply_Other" runat="server" class="body_Apply">
                                </div>
                                <div class="footer" align="center">
                                    <asp:Button ID="Btn_CkApplyOther_Ok" runat="server" Text="申請其他獎項" CssClass="yes"
                                        Width="120" />
                                    <asp:Button ID="Btn_CkApplyOther_End" runat="server" Text="結束" CssClass="no" OnClientClick="BackApply()" />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                            <!--=============================-->
                            <!--=====秀出系統正在處理資料的訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ConfirmDataProcess" runat="server" DisplayModalPopupID="MpeDataprocess"
                                TargetControlID="Btn_ShowMsg">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="MpeDataprocess" runat="server" PopupControlID="PnlDataProcess"
                                TargetControlID="Btn_ShowMsg" CancelControlID="Btn_DataProcess_End" BackgroundCssClass="modalBackground">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="PnlDataProcess" runat="server" Style="display: none; background-color: White">
                                <div class="header">
                                    系統提示訊息
                                </div>
                                <div id="Div_DataProcess" runat="server" class="body_Apply">
                                    系統正在處理中，請稍候。
                                </div>
                                <div class="footer" align="center">
                                    <asp:Button ID="Btn_DataProcess_End" runat="server" Text="" Width="0" Height="0"
                                        BackColor="White" BorderColor="White" BorderWidth="0" Enabled="False" />
                                </div>
                            </asp:Panel>
                            <!--=============================-->
                            <!--=====秀出欄位未填的訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ConfirmShowMsg" runat="server" DisplayModalPopupID="Mpe_Msg"
                                TargetControlID="Btn_ShowMsg">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="Mpe_Msg" runat="server" PopupControlID="PnlShowMsg"
                                TargetControlID="Btn_ShowMsg" OkControlID="Btn_ShowMsg_Confirm" BackgroundCssClass="modalBackground">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="PnlShowMsg" runat="server" CssClass="modalPopup" Style="display: none">
                                <div class="header">
                                    錯誤提示
                                </div>
                                <div id="Div_ShowMsg" class="body" runat="server">
                                </div>
                                <div class="footer" align="center">
                                    <asp:Button ID="Btn_ShowMsg_Confirm" runat="server" Text="確認" CssClass="yes" />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                            <!--===========================-->
                            <!--=====秀出圖形認證碼未填的訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ConfirmChart" runat="server" DisplayModalPopupID="Mpe_Chart"
                                TargetControlID="Btn_ShowMsg">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="Mpe_Chart" runat="server" PopupControlID="Pn1_Chart"
                                TargetControlID="Btn_ShowMsg" OkControlID="Btn_Chart_Confirm" BackgroundCssClass="modalBackground">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="Pn1_Chart" runat="server" CssClass="modalPopup" Style="display: none">
                                <div class="header">
                                    <asp:Label ID="ShowChart_Title" runat="server" Text="錯誤提示"></asp:Label>
                                </div>
                                <div id="Div_ShowChart" class="body" runat="server">
                                </div>
                                <div class="footer" align="center">
                                    <asp:Button ID="Btn_Chart_Confirm" runat="server" Text="確認" CssClass="yes" />
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                            <!--===========================-->
                            <!--=====秀出確認申請書的畫面訊息======-->
                            <Ajax:ConfirmButtonExtender ID="ConfirmApply" runat="server" DisplayModalPopupID="Mpe_Apply"
                                TargetControlID="Btn_ShowMsg">
                            </Ajax:ConfirmButtonExtender>
                            <Ajax:ModalPopupExtender ID="Mpe_Apply" runat="server" PopupControlID="Pnl_Apply"
                                TargetControlID="Btn_ShowMsg" CancelControlID="BtnNo_Confirm" BackgroundCssClass="modalBackground"
                                RepositionMode="RepositionOnWindowScroll">
                            </Ajax:ModalPopupExtender>
                            <asp:Panel ID="Pnl_Apply" runat="server" ScrollBars="Vertical" Height="650" Style="z-index: 70000 !important;">
                                <div class="style19" style="background-color: #FFFFFF">
                                    <br />
                                    <div class="cred">
                                        <strong class="title2" style="font-weight: bold;">*您填寫的資料如下，請仔細確認 : </strong>
                                    </div>
                                    <br />
                                    <table width="100%" runat="server" id="tbl_confirm">
                                        <tr>
                                            <td width="100%">
                                                <p class="title1" style="text-align: center">
                                                    財團法人陽光社會福利基金會
                                                </p>
                                                <p class="title1" style="text-align: center">
                                                    獎助學金申請書
                                                </p>
                                                <p align="left" class="cp">
                                                    <span>申請日期：中華民國</span>&nbsp;&nbsp;<%=(DateTime.Now.Year - 1911).ToString()%>年&nbsp;&nbsp;<%=DateTime.Now.Month.ToString()%>月&nbsp;&nbsp;<%=DateTime.Now.Day.ToString()%>日
                                                </p>
                                                <table border="1" cellpadding="0" cellspacing="0" style="border-width: 100%; background-color: White">
                                                    <tr>
                                                        <td class="ctd1" rowspan="5" width="80">基本<br />
                                                            資料
                                                        </td>
                                                        <td class="ctd1">姓名
                                                        </td>
                                                        <td class="ctd" width="111">
                                                            <asp:Label ID="Lb_Name_Confirm" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="Lb_OldName_Confirm" runat="server" Text="" Visible="false"></asp:Label>
                                                        </td>
                                                        <td class="ctd1" width="94">身分證字號
                                                        </td>
                                                        <td class="ctd" colspan="2">
                                                            <asp:Label ID="Lb_Id_Confirm" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td class="ctd1" width="83">出生年月日
                                                        </td>
                                                        <td class="ctd">
                                                            <asp:Label ID="Lb_Birthday_Y" runat="server" Text=""></asp:Label>
                                                            年
                                                    <asp:Label ID="Lb_Birthday_M" runat="server" Text=""></asp:Label>
                                                            月
                                                    <asp:Label ID="Lb_Birthday_D" runat="server" Text=""></asp:Label>
                                                            日
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1">性別
                                                        </td>
                                                        <td class="ctd">
                                                            <asp:RadioButtonList ID="RdButton_Sex_Confirm" runat="server" RepeatDirection="Horizontal"
                                                                RepeatLayout="Flow" onclick="return false;">
                                                                <asp:ListItem Value="M">男</asp:ListItem>
                                                                <asp:ListItem Value="F">女</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td class="ctd1">
                                                            <strong><u>現 在</u></strong><br />
                                                            就讀(畢)<br />
                                                            學校
                                                        </td>
                                                        <td class="ctd" colspan="2">學校名稱：<asp:Label ID="Lb_School" runat="server" Text="Label"></asp:Label>
                                                            <br />
                                                            科系：<asp:Label ID="Lb_Dep" runat="server" Text="Label"></asp:Label>
                                                            <br />
                                                            年級：<asp:Label ID="Lb_Grade_Confirm" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                        <td class="ctd1">申請次數
                                                        </td>
                                                        <td class="ctd">
                                                            <asp:RadioButtonList ID="RdButton_ApplyTime_Confirm" runat="server" RepeatDirection="Horizontal"
                                                                RepeatLayout="Flow" CssClass="RadioBtn" onclick="return false;">
                                                                <asp:ListItem Value="1">初次申請</asp:ListItem>
                                                                <asp:ListItem Value="2">多次申請</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1">
                                                            <strong class="cstrong">聯絡地址 </strong>(獎助相關資料寄送處)
                                                        </td>
                                                        <td class="ctd" colspan="4">
                                                            <asp:Label ID="Lb_Address" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td class="ctd1">電話(日)
                                                        </td>
                                                        <td class="ctd">
                                                            <asp:Label ID="Lb_Tel_D" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1">
                                                            <strong class="cstrong">戶籍地址</strong>
                                                        </td>
                                                        <td class="ctd" colspan="4">
                                                            <asp:Label ID="Lb_RAddress" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td class="ctd1">電話(夜)
                                                        </td>
                                                        <td class="ctd">
                                                            <asp:Label ID="Lb_Tel_N" runat="server" Text=""> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1">電子郵件
                                                        </td>
                                                        <td colspan="4" class="ctd">
                                                            <asp:Label ID="Lb_Email" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td class="ctd1">手機
                                                        </td>
                                                        <td class="ctd">
                                                            <asp:Label ID="Lb_Mobile_Confirm" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1">申請<br />
                                                            組別
                                                        </td>
                                                        <td colspan="7" class="ctd">
                                                            <asp:RadioButtonList ID="DpDownList_Awards_Confirm" runat="server" RepeatDirection="Horizontal"
                                                                RepeatLayout="Flow" onclick="return false;">
                                                                <asp:ListItem Value="1">國小組</asp:ListItem>
                                                                <asp:ListItem Value="2">國中組</asp:ListItem>
                                                                <asp:ListItem Value="3">高中組</asp:ListItem>
                                                                <asp:ListItem Value="4">大專組(不含五專1~3年級)</asp:ListItem>
                                                                <asp:ListItem Value="5">研究所碩士班</asp:ListItem>
                                                                <asp:ListItem Value="6">博士班</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1" rowspan="6">申︵
                                                    <br />
                                                            請詳
                                                    <br />
                                                            獎見
                                                    <br />
                                                            項申
                                                    <br />
                                                            ︵請
                                                    <br />
                                                            勾簡
                                                    <br />
                                                            選章
                                                    <br />
                                                            一︶
                                                    <br />
                                                            種
                                                    <br />
                                                            ︶
                                                        </td>
                                                        <td class="ctd" colspan="5">
                                                            <asp:RadioButton ID="RdButton_Apply_Item_S1" runat="server" onclick="return false;" />
                                                            <asp:RadioButton ID="RdButton_Apply_Item_Z1" runat="server" onclick="return false;"
                                                                Visible="false" />
                                                            <asp:RadioButton ID="RdButton_Apply_Item_M1" runat="server" onclick="return false;"
                                                                Visible="false" />
                                                            <asp:Label ID="Lb_PApplyItem_S1" runat="server" Text="(一)特殊才藝優秀獎學金"></asp:Label>
                                                            <asp:Label ID="Lb_PApplyItem_Z1" runat="server" Text="(一)仁寶電腦_電腦優秀獎助學金" Visible="false"></asp:Label>
                                                            <asp:Label ID="Lb_PApplyItem_M1" runat="server" Text="明閱科技_陽光子女特殊才藝獎助學金" Visible="false"></asp:Label>
                                                        </td>
                                                        <td class="ctd1" rowspan="6">損傷類別
                                                        </td>
                                                        <td class="ctd" rowspan="6">
                                                            <asp:RadioButtonList ID="RdButton_Damage_Confirm" runat="server" RepeatDirection="Vertical"
                                                                RepeatLayout="Flow" onclick="return false;">
                                                                <asp:ListItem Value="B0">灼燙傷</asp:ListItem>
                                                                <asp:ListItem Value="F1">顏面損傷1.顱顏畸形(含小耳症)</asp:ListItem>
                                                                <asp:ListItem Value="F2">顏面損傷2.腫瘤病變(含血管瘤)</asp:ListItem>
                                                                <asp:ListItem Value="F3">顏面損傷3.口腔癌</asp:ListItem>
                                                                <asp:ListItem Value="F4">顏面損傷4.嚴重外傷</asp:ListItem>
                                                                <asp:ListItem Value="F5">顏面損傷5.皮膚病變(含魚鱗癬<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;症、胎記、太田母斑)</asp:ListItem>
                                                                <asp:ListItem Value="F6">顏面損傷6.其他</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <asp:Label ID="Lb_Damage" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd" colspan="5">
                                                            <asp:RadioButton ID="RdButton_Apply_Item_S2" runat="server" onclick="return false;" />
                                                            <asp:RadioButton ID="RdButton_Apply_Item_Z2" runat="server" Visible="false" onclick="return false;" />
                                                            <asp:Label ID="Lb_PApplyItem_S2" runat="server" Text="(二)優  秀  獎  學  金"></asp:Label>
                                                            <asp:Label ID="Lb_PApplyItem_Z2" runat="server" Text="(二)仁寶電腦_電腦傑出才藝獎助學金" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd" height="30" colspan="5">
                                                            <asp:RadioButton ID="RdButton_Apply_Item_S3" runat="server" onclick="return false;" />
                                                            <asp:Label ID="Lb_PApplyItem_S3" runat="server" Text="(三)升  學  獎  學  金"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd" colspan="5" height="27">
                                                            <asp:RadioButton ID="RdButton_Apply_Item_S4" runat="server" onclick="return false;" />
                                                            <asp:Label ID="Lb_PApplyItem_S4" runat="server" Text="(四)助      學      金"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd" colspan="4">
                                                            <asp:RadioButton ID="RdButton_Apply_Item_S5" runat="server" onclick="return false;" />
                                                            <asp:Label ID="Lb_PApplyItem_S5" runat="server" Text="(五)勇 源 - 陽 光 子 女 助 學 金"> </asp:Label>
                                                        </td>
                                                        <td class="ctd" valign="top" width="148" rowspan="2">
                                                            <table class="ctable" id="Tb_PName" runat="server" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>損傷者姓名(必填):<asp:Label ID="Lb_PName" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>親屬關係：<br />
                                                                        <asp:RadioButtonList ID="RdButton_Parents_Confirm" runat="server" RepeatDirection="Horizontal"
                                                                            RepeatLayout="Flow" onclick="return false;">
                                                                            <asp:ListItem Value="1">父</asp:ListItem>
                                                                            <asp:ListItem Value="2">母</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <tr>
                                                            <td class="ctd" colspan="4">
                                                                <asp:RadioButton ID="RdButton_Apply_Item_S6" runat="server" onclick="return false;" />
                                                                <asp:Label ID="Lb_PApplyItem_S6" runat="server" Text="(六)明閱科技-陽光子女特殊才藝獎學金"> </asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1">
                                                            <div class="cred">
                                                                獎金匯款銀行帳戶
                                                            </div>
                                                        </td>
                                                        <td class="ctd" colspan="7">
                                                            <p>
                                                                <span class="cred">戶名：<asp:Label ID="Lb_Account_Name" runat="server" Text=""></asp:Label>
                                                                </span>
                                                            </p>
                                                            <p class="cred">
                                                                銀行代碼：<asp:Label ID="Lb_Bank_No" runat="server" Text=""></asp:Label>
                                                            </p>
                                                            <p class="cred">
                                                                存戶帳號：<asp:Label ID="Lb_Account" runat="server" Text=""></asp:Label>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ctd1" width="39">申<br />
                                                            請<br />
                                                            人<br />
                                                        </td>
                                                        <td class="ctd" colspan="7">
                                                            <asp:RadioButtonList ID="RdButton_Mode_Confirm" runat="server" RepeatDirection="Vertical"
                                                                RepeatLayout="Flow" onclick="return false;">
                                                                <asp:ListItem Value="1">自行申請</asp:ListItem>
                                                                <asp:ListItem Value="2">單位推薦</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            推薦單位：<asp:Label ID="Lb_recommend" runat="server" Text="_____  "></asp:Label>
                                                            推薦人姓名：<asp:Label ID="Lb_Rec_Name" runat="server" Text="_____  "></asp:Label>
                                                            推薦人職務：<asp:Label ID="Lb_Rec_Position" runat="server" Text="_____  "></asp:Label>
                                                            推薦人電話：<asp:Label ID="Lb_Rec_Tel" runat="server" Text="_____  "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div align="center" class="footer">
                                        <asp:Button ID="BtnYes_Confirm" runat="server" CssClass="yes" Text="提出申請" Width="90"
                                            OnClientClick="ShowProgressBar();" />
                                        <asp:Button ID="BtnNo_Confirm" runat="server" CssClass="no" Text="返回修改" Width="90" />
                                        <br />
                                        <br />
                                    </div>
                                    <br />
                                </div>
                            </asp:Panel>
                        </div>
                        <!-- table1 -->
                        <!--===========================-->
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
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

            <script src="../scripts/jquery-twzipcode/jquery.twzipcode.js" type="text/javascript"></script>
            <!--TWBankCode-->
            <script src="../scripts/jquery-BankCode/jquery.BankCode.js" type="text/javascript"></script>
            <!--Jay-->

            <script>               
                $(function () {     
                    var sender;//觸發submit事件控制項
                    $('.datepicker').datepicker(); //初始化
            
                    $('input[data-loading-text]')
                     .on('click', function () {                               
                         var btn = $(this);
                         sender = btn;
                     });//$('input[data-loading-text]')
            
                    //            $('#<%=DpDownList_Bank_Code.UniqueID%>')
                    //            .on('change', function () {  
                    //                alert('change');
                    //                getBankBranch();
                    //            });
            
                    console.log('ok-2');
                    //前4碼數字必須要有[-]6碼數字
                    $.validator.addMethod("mobileno", function(phone_number, element) {
                        phone_number = phone_number.replace(/\s+/g, "");
                        return this.optional(element) || phone_number.length > 9 && 
                        phone_number.match(/^([0-9]{4,4})[ -]([0-9]{6,6})$/);
                    }, "手機號碼錯誤,格式：0955-888999");
  
                    //必須要有[-]
                    $.validator.addMethod("phoneno", function(phone_number, element) {
                        phone_number = phone_number.replace(/\s+/g, "");
                        return this.optional(element) || phone_number.length > 9 && 
                        phone_number.match(/^([0-9]{2,3})[ -]([0-9]{7,8})$/);
                    }, "電話號碼錯誤,格式：07-5587166");

                    var validator = $('form').validate({
                        ignore: [],
                        //radion button 秀在最後一個button後方
                        errorPlacement: function(error, element) {
                            var target = $(element);
                            if (element.is(':radio') || element.is(':checkbox')) {
                                target = $(element).parent();
                            }
                            error.insertAfter(target);
                        },
                        rules: { 
                            <%=Txt_Name.UniqueID %>: { required: true},
                            <%=RdButton_Sex.UniqueID %>: { required: true},                             
                            <%=Txt_Id.UniqueID %>: { required: true}, 
                            <%=DpDownList_Year.UniqueID %>: { required: true}, 
                            <%=DpDownList_Month.UniqueID %>: { required: true}, 
                            <%=DpDownList_Day.UniqueID %>: { required: true}, 
                 
                            <%=TxtBox_Zid.UniqueID %>: {required: true, maxlength:5}, //聯絡地址
                            <%=TxtBox_Address.UniqueID %>: {required: true, maxlength:100}, //聯絡地址
                 
                            //<%=TxtBox_RZip.UniqueID %>: {required: true, maxlength:5}, //聯絡地址
                            //<%=TxtBox_RAddress.UniqueID %>: {required: true, maxlength:100}, //聯絡地址
                 
                 <%=TxtBox_Tel_1.UniqueID %>:{ required: true,maxlength:20, phoneno:true}, //電話(日)
                            <%=TxtBox_Tel_2.UniqueID %>:{ required: true,maxlength:20, phoneno:true}, //電話(夜)
                 
                            <%=TxtBox_Mobile.UniqueID %>:{ required: true, maxlength:15, mobileno:true }, //手機
                            <%=TxtBox_Email.UniqueID %>:{ required: true, maxlength:50, email:true },//電子郵件信箱
                 
                            <%=RdButton_Damage.UniqueID %>:{ required: true, maxlength:20 },//損傷類別
                            <%=TxtBox_School.UniqueID %>:{ required: true, maxlength:50 },//學校名稱
                            <%=TxtBox_Grage.UniqueID %>:{ required: true, number:true, maxlength:1,range:[ 1, 10 ]},//年級
                 
                            <%=RdButton_ApplyTimes.UniqueID %>:{ required: true, maxlength:1},//申請次數                 
                            <%=DpDownList_Awards.UniqueID %>:{ required: true, maxlength:2 }, //申請組別
                 
                            <%=RdButton_Apply_Item_S.UniqueID %>:{ required: true},    //申請獎項
                            <%=TxtBox_Account_Name.UniqueID %>:{ required: true},    //戶名

                            <%=TxtBox_Account_No.UniqueID %>:{ required: true,maxlength:20, digits:true}, //銀行帳戶
                 
                 <%-- 
                    改為隱藏不檢核
                    '<%=DpDownList_Bank_Code.UniqueID%>': { required: true, maxlength:8 },
                    '<%=DpDownList_Bank_Name.UniqueID%>': { required: true, maxlength:20 },
                --%>               
                               
                            '<%=TxtBox_Bank.UniqueID%>': { required: true, maxlength:20 }, 
                            <%=TxtBox_Account_No.UniqueID%>: { required: true, maxlength:20, digits:true }, //銀行帳戶
                                
                            '<%=TxtBox_VerifyCode.UniqueID%>': { required: true},//圖形驗證碼                 
                        },
                        submitHandler: function (form)
                        {         
                            console.log(sender);
                    
                            try
                            {
                                sender.button('loading');  
                            }catch(e){}
                    
                            //不能把控制項設為disable後端無法觸發事件
                            $("form input[type=submit]")
                                .click(function() { return false })
                                .fadeTo(200, 0.5);
                            //這種寫法不能submit會重複submit
                            //console.log('submit');
                            //form.submit();
                        }
                    });//$('form')                         
                });//ready      
            </script>

            <script type="text/javascript">
                function ShowModalPopup() {
                    if (!$('form').valid()) {
                        //資料輸入不完整提示
                        Div_ShowMsg.innerHTML = "資料輸入不完整!";
                        $find("Mpe_Msg").show();
                        return false;
                    }
                    $find("mpe").show();                
                    return false;
                }
                function HideModalPopup() {
                    $find("mpe").hide();
                    return false;
                }

                function disableScroll() {
                    // lock scroll position, but retain settings for later
                    var scrollPosition = [
                        self.pageXOffset || document.documentElement.scrollLeft || document.body.scrollLeft,
                        self.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop
                    ];
                    var html = jQuery('html'); // it would make more sense to apply this to body, but IE7 won't have that
                    html.data('scroll-position', scrollPosition);
                    html.data('previous-overflow', html.css('overflow'));
                    html.css('overflow', 'hidden');
                }
                function restoreScroll(selectorOfWindow) {
                    // un-lock scroll position
                    var html = jQuery('html');
                    var scrollPosition = html.data('scroll-position');
                    html.css('overflow', html.data('previous-overflow'));
                    window.scrollTo(scrollPosition[0], scrollPosition[1]);
                }

                function DoApply() {
                    //處理中
                    ShowProgressBar();
                    console.log('DoApply');
                    $('#<%=btnFake.UniqueID%>').click();
                }
            
                //測試zip code
                function showZipCode() {
                    console.log($('#txtRZipCode').twzipcode('data'));
                    console.log($('#txtRZipCode').twzipcode('get').county.val());
                    console.log($('#txtRZipCode').twzipcode('get').district.val());
                    console.log($('#txtRZipCode').twzipcode('get').zipcode.val());
                    //$('#twzipcode').twzipcode('set', 110);
                }
            </script>

            <script>        
                $(function () {
                    //updatepanel postback後需重新設定一次郵遞區號 
                    init();
                });

                function init() {                  
                    //同聯絡地址
                    $('#<%=CkBox_RAddress.UniqueID%>')
                    .on('click', function () {                
                        if(!$(this).prop("checked")) return;                 
                        var source = $('#<%=TxtBox_Address.UniqueID%>');
                        var target = $('#<%=TxtBox_RAddress.UniqueID%>');
                        var zipcode = $('#txtCZipCode').twzipcode('get').zipcode.val(); 
                    
                        if(!zipcode) zipcode = 'zipcode';
                    
                        $('#txtRZipCode').twzipcode('set', zipcode);                
                        target.val(source.val());                
                    });      
            
                    //連絡地址
                    $('#txtCZipCode').twzipcode({
                        'css': ['county form-control col-4', 'district form-control col-4', 'zipcode form-control col-3'],
                        'readonly':true,
                        'onCountySelect': function () {
                            setAddress($('#txtCZipCode'),$('#<%=TxtBox_Address_Bak.UniqueID%>'),$('#<%=TxtBox_Zid.UniqueID%>'));             	       
                        },
                        'onDistrictSelect': function () {
                            setAddress($('#txtCZipCode'),$('#<%=TxtBox_Address_Bak.UniqueID%>'),$('#<%=TxtBox_Zid.UniqueID%>'));                         	       
                    },
                    });
                
                    //戶籍地址
                $('#txtRZipCode').twzipcode({
                    'css': ['county form-control col-4', 'district form-control col-4', 'zipcode form-control col-3'],
                    'readonly':true,
                    'onCountySelect': function () {
                        setAddress($('#txtRZipCode'),$('#<%=TxtBox_RAddress_Bak.UniqueID%>'),$('#<%=TxtBox_RZip.UniqueID%>'));             	       
                    },
                    'onDistrictSelect': function () {
                        setAddress($('#txtRZipCode'),$('#<%=TxtBox_RAddress_Bak.UniqueID%>'),$('#<%=TxtBox_RZip.UniqueID%>'));                         	       
                    },
                });

                $('#txtRZipCode').twzipcode('set',$('#<%=TxtBox_RZip.UniqueID%>').val());   
                    $('#txtCZipCode').twzipcode('set',$('#<%=TxtBox_Zid.UniqueID%>').val());    
                
                    //獎項申請變更，因為postback，所以必須再執行
                    ApplyChange();                
                    //推廌人
                    CheckRe();
                    CheckAdd();   //同聯絡地址
                    //
                    //$('#RdButton_Sex_Confirm').on('click',function(e){
                    //    $('#RdButton_Sex_Confirm').attr("disabled",true);
                    //    return false;
                    //    });
                    //}
                    //);
                
                    //銀行代碼
                    $('#txtBank').TWBankCode({
                        'css': ['county form-control', 'district  form-control', 'zipcode form-control'],
                        'readonly':true,
                        'onCountySelect': function () {
                            var bankcode = $('#txtBank').TWBankCode('get').zipcode.val();
                            $('#<%=TxtBox_Bank.UniqueID%>').val(bankcode);   
                        },
                        'onDistrictSelect': function () { 
                            var bankcode = $('#txtBank').TWBankCode('get').zipcode.val();
                            $('#<%=TxtBox_Bank.UniqueID%>').val(bankcode);                                            
                    },                  
                    });
                
                console.log('bankcode');
                console.log($('#<%=TxtBox_Bank.UniqueID%>').val());
                $('#txtBank').TWBankCode('set',$('#<%=TxtBox_Bank.UniqueID%>').val()); 
                }//init
            
                //合併到地址欄位
                function setAddress(source,target,zip){       
                    target.val('');
                    zip.val('');
                    var county = source.twzipcode('get').county.val();
                    var district = source.twzipcode('get').district.val(); 
                    var zipcode = source.twzipcode('get').zipcode.val(); 
                                               
                    if(zipcode)
                    {
                        target.val(county + district);
                        zip.val(zipcode);                
                    }
                } 
            
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {                
             
                    console.log("add_endRequest");
                    init();
                });

                //獎項申請變更
                function ApplyChange() {
                    var item = $('input[name=RdButton_Apply_Item_S]:checked').val();
                    if (item == 'S5' || item == 'S6') {
                        //alert('1');
                        $("#ShowParent").show();
                    } else {
                        //alert('2');
                        $("#ShowParent").hide();
                    }
                } 
                //推廌人
                function CheckRe() {
                    var item = $('input[name=RdButton_Mode]:checked').val();
                    if (item == '2') {
                        $('#recommend').show();
                    } else {
                        $('#recommend').hide();
                    }
                }
                //同聯絡地址
                function CheckAdd(){
                    var item = $('input[name=CkBox_RAddress]:checked').val(); //取得按鈕狀態
                    if (item) 
                    { 
                        //相同
                        $('#txtRZipCode').hide(); 
                        $('#SameAddress').hide();
                    }else{  
                        //不同
                        $('#txtRZipCode').show(); 
                        $('#SameAddress').show();
                    }
                }
                //取得分行代碼
                function WriteBankCode(){
                    var item=$('#DpDownList_Bank_Name').val();
                    $('#TxtBox_Bank').val(item);
                }
                //更新驗證碼
                function ChgCode(){
                    $('#imgCode').attr('src', 'BuildVerifyChart.aspx?'+Math.random());
                }

            </script>
        </div>
    </form>
</body>
</html>
