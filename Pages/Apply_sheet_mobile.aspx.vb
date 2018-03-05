Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Net
Imports System
Imports System.Data
Imports System.Configuration

Public Enum ErrorCode
    DB_Cannot_Connect = 1
End Enum


Partial Class Pages_Apply_sheet
    Inherits System.Web.UI.Page
    Dim CkStr As CkString = New CkString()
    Dim ErrMsg As String = String.Empty
    Dim ErrMsgTitle As String = "下列欄位資料填寫不正確，請修改。<br />"
    Dim InserStr As String = String.Empty
    Dim InserColName As String = String.Empty
    Dim InserValues As String = String.Empty
    Dim ErrMsgList As List(Of String) = New List(Of String)
    Dim InserColNameList As List(Of String) = New List(Of String)
    Dim InserValuesList As List(Of String) = New List(Of String)
    Dim AppleMode As String = String.Empty
    Dim Birthday_y As String = String.Empty
    Dim Birthday_m As String = String.Empty
    Dim Birthday_d As String = String.Empty
    Dim InserDataStr As String = String.Empty
    Dim CApplyNo As String = String.Empty '收件編號
    Dim Wlog As WriteLog = New WriteLog()
    'tc 160822 回首頁網址
    'Jay 170819 改為捉設定檔
    protected ReadOnly BackToHome As String =
       ConfigurationManager.AppSettings("BackToHome").ToString()

    'tc 160822 申請截止日期
    'Jay 170819 改為兩段申請日,捉設定檔
    Private ReadOnly OutOfApplyDate_1 As String =
       ConfigurationManager.AppSettings("OutOfApplyDate_1").ToString()

    Private ReadOnly OutOfApplyDate_2 As String =
       ConfigurationManager.AppSettings("OutOfApplyDate_2").ToString()

    '2017/9/7 gin 申請開始日期
    Private ReadOnly OutOfApplyDate_0 As String =
       ConfigurationManager.AppSettings("OutOfApplyDate_0").ToString()

    'tc 160822 Session timeout設定，單位分
    Const SessionTimeOut As Integer = 15
    'tc 0823獎項名稱
    Const AwardZ As String = "仁寶電腦-陽光電腦獎助學金"
    Const AwardZ1 As String = "電腦優秀獎助學金"
    Const AwardZ2 As String = "電腦傑出才藝獎"

    Private Sub SetAwardName()
        'tc 0823 設定獎項名稱
        Lb_PApplyItem_Z1.Text = AwardZ1
        Lb_PApplyItem_Z2.Text = AwardZ2
    End Sub

    Private Function IsTimeOut() As Boolean
        'tc 160822 已產生認證碼之後才進行 time out 檢查
        If Not IsPostBack Then
            Exit Function
        End If
        Dim flag As Boolean = False
        '檢查認證碼Session是否time out
        If Session("BuildVerifyChart") Is Nothing Then
            flag = True
        Else
            If Session("BuildVerifyChart") = "" Then
                flag = True
            End If
        End If
        'flag = True
        '提示timeout，請重新輸入
        If flag Then
            Div_ShowMsg.InnerHtml = "閒置過久，請重新申請。"
            Btn_ShowMsg_Confirm.Text = "回到申請頁"
            Btn_ShowMsg_Confirm.CssClass = ""
            Btn_ShowMsg_Confirm.OnClientClick = "window.open('" + BackToHome + "', '_self');"
            Mpe_Msg.Show()
        End If
        Return flag
    End Function

    Private Sub IsOutOfDate()
        ''tc 160822 超出申請日
        ''非期間內無法申請。
        'If DateTime.Now > OutOfApplyDate Then
        '    Response.Redirect("OutOfApplyDate.aspx")
        'End If
        Dim startDate As DateTime = CType(OutOfApplyDate_0, DateTime) '2017/9/7 gin 申請開始日期
        Dim expireDate As DateTime = CType(OutOfApplyDate_1, DateTime)
        Dim m As String = Request.QueryString("m")
        Dim t As String = Request.QueryString("t")

        Select Case m
            Case "1", "2"
                Select Case t
                    Case "1", "2"
                        expireDate = OutOfApplyDate_2
                    Case Else
                        expireDate = OutOfApplyDate_1
                End Select
        End Select

        If DateTime.Now < startDate Then '2017/9/7 gin 申請開始日期
            Response.Redirect("OutOfApplyDate.aspx")
        End If

        If DateTime.Now > expireDate.AddDays(1) Then '2017/9/30 gin 日期計算到當天晚上
            Response.Redirect("OutOfApplyDate.aspx")
        End If

        'If DateTime.Now > expireDate Then
        '    Response.Redirect("OutOfApplyDate.aspx")
        'End If

    End Sub

    Public Function GetAddress() As String
        'tc 0823 多加縣市的資訊到地址欄
        Return TxtBox_Address_Bak.Text + TxtBox_Address.Text
    End Function

    Public Function GetAddressR() As String
        'tc 0823 戶籍同聯絡地址處理
        If CkBox_RAddress.Checked Then
            'zip code 同樣
            TxtBox_RZip.Text = TxtBox_Zid.Text
            '地址相同
            TxtBox_RAddress.Text = TxtBox_Address.Text
            Return TxtBox_Address_Bak.Text + TxtBox_Address.Text
        End If

        '縣市處理
        Return TxtBox_RAddress_Bak.Text + TxtBox_RAddress.Text
    End Function

    Private Sub test_data()
        Txt_Name.Text = "蔡O洲"
        Txt_Id.Text = "A122044221"
        Lb_Id.Text = "V 正確"
        DpDownList_Year.SelectedValue = "100"
        DpDownList_Month.SelectedValue = "10"
        DpDownList_Day.SelectedValue = "10"
        RdButton_Sex.SelectedValue = "M"
        TxtBox_Zid.Text = "241"
        TxtBox_Address.Text = "正義北路XXX巷XX號X樓"
        TxtBox_RZip.Text = TxtBox_Zid.Text
        'CkBox_RAddress.Text = TxtBox_Address.Text
        TxtBox_RAddress.Text = TxtBox_Address.Text
        TxtBox_Tel_1.Text = "01-12345678"
        TxtBox_Tel_2.Text = "01-22345678"
        TxtBox_Mobile.Text = "0952-123456"
        TxtBox_Email.Text = "tsaitsungchou@gmail.com"
        RdButton_Damage.SelectedValue = "F2"

        TxtBox_School.Text = "台北商業大學"
        TxtBox_Dep.Text = "資管系"
        TxtBox_Grage.Text = "5"
        RdButton_ApplyTimes.SelectedValue = "1"
        DpDownList_Awards.SelectedValue = "4"
        '多組測試 S2 / S5
        RdButton_Apply_Item_S.SelectedValue = "S2"

        '仁寶
        RdButton_Apply_Item_Z.SelectedValue = "Z1"

        '明閱
        RdButton_Apply_Item_M.SelectedValue = "M1"
        TxtBox_PName_M.Text = "蔡爸爸"
        RdButton_Parents_M.SelectedValue = "1"

        RdButton_Mode.SelectedValue = "1"
        '銀行
        TxtBox_Account_Name.Text = "蔡O洲"
        TxtBox_Bank.Text = "0290005"
        TxtBox_Account_No.Text = "000010001"
        TxtBox_VerifyCode.Text = Session("BuildVerifyChart")
    End Sub

    Private Sub test_data2()
        TxtBox_VerifyCode.Text = Session("BuildVerifyChart")
    End Sub

    Private Sub Show_Award_In_Mpe_Apply() 'tc 20160621 add
        '明閱
        If RdButton_Apply_Item_M1.Checked Then
            Lb_PApplyItem_S1.Visible = False
            Lb_PApplyItem_Z1.Visible = False
            Lb_PApplyItem_M1.Visible = True
        End If

        '仁寶
        If RdButton_Apply_Item_Z1.Checked Then
            Lb_PApplyItem_S1.Visible = False
            Lb_PApplyItem_Z1.Visible = True
            Lb_PApplyItem_M1.Visible = False
        End If

        '陽光
        If RdButton_Apply_Item_S1.Checked Then
            Lb_PApplyItem_S1.Visible = True
            Lb_PApplyItem_Z1.Visible = False
            Lb_PApplyItem_M1.Visible = False
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'tc 20160714 填表頁面time out時間，先設定為15分鐘。
        Session.Timeout = SessionTimeOut

        If IsPostBack Then
            'tc 160822 第二次登入時，檢查session是否timeout
            IsTimeOut()
        Else
            'tc 160822 第一次登入時，查檢是否超過申請期限
            IsOutOfDate()
            SetAwardName() 'tc 0823 設定獎項名稱

            If Not Request.QueryString("m") = Nothing Then '要判斷申請者是申請哪種獎項
                ViewState("AppleMode") = Request.QueryString("m").ToString()
            End If

            If ViewState("AppleMode") = "0" Then
                Page.Title = "獎助學金線上申請作業-陽光"
                Lb_Apply_cate.Text = "陽光獎助學金線上申請作業"
            ElseIf ViewState("AppleMode") = "1" Then
                Page.Title = "獎助學金線上申請作業-仁寶"
                'tc 0823
                'Lb_Apply_cate.Text = "仁寶電腦獎助學金線上申請作業"
                Lb_Apply_cate.Text = AwardZ

                'tc 160822 沒有明閱了，合併到陽光中
                'ElseIf ViewState("AppleMode") = "2" Then
                '   Page.Title = "獎助學金線上申請作業-明閱"
                '  Lb_Apply_cate.Text = "明閱科技陽光獎助學金線上申請作業"
            Else  '假如都沒有讓他預設是陽光  CHC 0807
                ViewState("AppleMode") = "0"
                Page.Title = "獎助學金線上申請作業-陽光"
                Lb_Apply_cate.Text = "陽光獎助學金線上申請作業"
            End If
            'tc 20160705 記錄申請獎項
            Btn_Apply_Save.OnClientClick = String.Format("NewWindow('{0}')", ViewState("AppleMode"))

            InitCtr("F")
            InitDropdownlist()
            Session("Request_UrlReferrer") = False
        End If
    End Sub

    Private Function GetUrl(ByVal ReqUrl As String) As String '取得Url
        If ReqUrl = String.Empty Then
            Return String.Empty
        End If

        Dim Result As String
        Dim Scount As Integer

        Scount = ReqUrl.LastIndexOf("/")
        Result = ReqUrl.Substring(Scount + 1, ReqUrl.Count - (Scount + 1)).ToLower
        Return Result
    End Function
    Protected Sub Txt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Id.TextChanged
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.ID = "Txt_Id" Then '檢查身分證是否正確
            Lb_Id.Text = CkStr.CkUid(txt.Text)
            Lb_Id.Visible = True
            If Lb_Id.Text = "V 正確" Then
                Lb_Id.ForeColor = Drawing.Color.Blue
            Else
                Lb_Id.ForeColor = Drawing.Color.Red
            End If
        Else '其餘的文字輸入，要檢查是否有非法字元，有的話直接以空字串取代
            txt.Text = CkStr.CkChar(txt.Text)
        End If
        '2017/11/2 gin 判斷如果2年內有申請過,就顯示申請的類別
        If Txt_Id.Text <> "" Then
            lblTrauma_Old.Text = Trauma_Old(Txt_Id.Text, DateTime.Now.Year)
            If lblTrauma_Old.Text <> "" Then '有資料就顯示
                lblTrauma_Old.Visible = True
            Else
                lblTrauma_Old.Visible = False
            End If
        End If

    End Sub
    Protected Sub InitCtr(ByVal Cate As String)
        Lb_Id.Visible = False
        ExcInitControls(Me.Page, Cate)
    End Sub

    '2016-08-21 Jay 增加一個btnFake取代原Btn_Ok
    Protected Sub Btn_Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Ok.Click, btnFake.Click
        Dim ErrMsgTitle As String = "下列欄位資料填寫不正確，請修改。<br />"
        ErrMsg = String.Empty
        InserColName = String.Empty
        InserValues = String.Empty
        Dim CkHasApply As List(Of String) = New List(Of String)
        Dim NInsertValues = String.Empty
        Dim NInsertDataStr = String.Empty

        Dim u As String = Request.ServerVariables("HTTP_USER_AGENT")
        Dim b As New Regex("(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase)
        Dim v As New Regex("1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase)

        If b.IsMatch(u) Or v.IsMatch(Left(u, 4)) Then
            GetAddressR() 'tc 0823同聯絡地址處理
            CkInputData(Me.Page) '檢查必填欄位
            If ErrMsg <> String.Empty Then
                'Session("BuildVerifyChart") = String.Empty   'tc 20160705 不取消
                TxtBox_VerifyCode.Text = String.Empty
                Mpe_Msg.Show()
                ErrMsgTitle = ErrMsgTitle + ErrMsg
                Div_ShowMsg.InnerHtml = ErrMsgTitle
                imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
            Else '資料填寫完成，進行新增資料
                If Lb_Id.Text <> "V 正確" Then
                    Div_ShowChart.InnerHtml = "身分證號碼驗證錯誤，請重新輸入！"
                    Mpe_Chart.Show()
                    imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
                Else
                    CkHasApply = CkIsApply()
                    If CkHasApply.Count = 0 Then '檢查年度內是否已經申請過
                        'Session("BuildVerifyChart") = String.Empty 'tc 20160705 不取消
                        Session("Request_UrlReferrer") = True
                        If InserColName <> String.Empty And InserValues <> String.Empty Then
                            InserValues += Birthday_y + "/" + Birthday_m + "/" + Birthday_d + "','"
                            InserColName += DefineAll.DpDownList_Birthday_CName + ","

                            CApplyNo = GetRecNo() '產生收件編號
                            InserValues += CApplyNo + "','"
                            InserColName += DefineAll.ApplyNo_CName + ","
                            Session("CApplyNo") = CApplyNo

                            InserValues += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" '申請日期
                            InserColName += DefineAll.ApplyDate_CName + ","

                            InserValues += "1','"   '處理狀態，預設值為1
                            InserColName += "status_code,"

                            InserColName = InserColName.Substring(0, InserColName.Length - 1)
                            InserValues = InserValues.Substring(0, InserValues.Length - 2)
                            'CHC 08/29 加上難字處理 
                            InserValues = InserValues.Replace("','", "',N'")

                            InserDataStr = "Insert Into APPLY(" + InserColName + ")"
                            'CHC 08/29 加上難字處理
                            'InserDataStr += "Values('" + InserValues + ")"
                            InserDataStr += "Values(N'" + InserValues + ")"

                            ViewState("InserDataStr") = InserDataStr
                            'tc 20160621 show獎項
                            Show_Award_In_Mpe_Apply()
                            Mpe_Apply.Show()
                        End If
                    Else '已經申請過該獎項
                        'Session("BuildVerifyChart") = String.Empty   'tc 20160705
                        '  Div_ShowChart.InnerHtml = "您已於" + CkHasApply(1) + "<br/>申請「" + CkHasApply(2) + "」獎項申請<BR />收件編號：" + CkHasApply(0) + "，請確認。<br/>"
                        Div_ShowChart.InnerHtml = "您已於" + CkHasApply(1) + "<br/>申請「" + CkHasApply(2) + "」。<br/>收件編號：" + CkHasApply(0) + "，請確認。<br/>"
                        'tc 20160714 多加不能申請原因說明
                        Div_ShowChart.InnerHtml += CkHasApply(3)
                        Mpe_Chart.Show()
                        imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
                    End If
                End If
            End If
        ElseIf TxtBox_VerifyCode.Text.Trim() = String.Empty Then
            Mpe_Chart.Show()
            Div_ShowChart.InnerHtml = "請填寫圖形認證碼"
            imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
        Else
            If Not Session("BuildVerifyChart") = Nothing Then
                If TxtBox_VerifyCode.Text.Trim() = Session("BuildVerifyChart") Then
                    GetAddressR() 'tc 0823同聯絡地址處理
                    CkInputData(Me.Page) '檢查必填欄位
                    If ErrMsg <> String.Empty Then
                        'Session("BuildVerifyChart") = String.Empty   'tc 20160705 不取消
                        TxtBox_VerifyCode.Text = String.Empty
                        Mpe_Msg.Show()
                        ErrMsgTitle = ErrMsgTitle + ErrMsg
                        Div_ShowMsg.InnerHtml = ErrMsgTitle
                        imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
                    Else '資料填寫完成，進行新增資料
                        If Lb_Id.Text <> "V 正確" Then
                            Div_ShowChart.InnerHtml = "身分證號碼驗證錯誤，請重新輸入！"
                            Mpe_Chart.Show()
                            imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
                        Else
                            CkHasApply = CkIsApply()
                            If CkHasApply.Count = 0 Then '檢查年度內是否已經申請過
                                'Session("BuildVerifyChart") = String.Empty 'tc 20160705 不取消
                                Session("Request_UrlReferrer") = True
                                If InserColName <> String.Empty And InserValues <> String.Empty Then
                                    InserValues += Birthday_y + "/" + Birthday_m + "/" + Birthday_d + "','"
                                    InserColName += DefineAll.DpDownList_Birthday_CName + ","

                                    CApplyNo = GetRecNo() '產生收件編號
                                    InserValues += CApplyNo + "','"
                                    InserColName += DefineAll.ApplyNo_CName + ","
                                    Session("CApplyNo") = CApplyNo

                                    InserValues += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" '申請日期
                                    InserColName += DefineAll.ApplyDate_CName + ","

                                    InserValues += "1','"   '處理狀態，預設值為1
                                    InserColName += "status_code,"

                                    InserColName = InserColName.Substring(0, InserColName.Length - 1)
                                    InserValues = InserValues.Substring(0, InserValues.Length - 2)
                                    'CHC 08/29 加上難字處理 
                                    InserValues = InserValues.Replace("','", "',N'")

                                    InserDataStr = "Insert Into APPLY(" + InserColName + ")"
                                    'CHC 08/29 加上難字處理
                                    'InserDataStr += "Values('" + InserValues + ")"
                                    InserDataStr += "Values(N'" + InserValues + ")"

                                    ViewState("InserDataStr") = InserDataStr
                                    'tc 20160621 show獎項
                                    Show_Award_In_Mpe_Apply()
                                    Mpe_Apply.Show()
                                End If
                            Else '已經申請過該獎項
                                'Session("BuildVerifyChart") = String.Empty   'tc 20160705
                                '  Div_ShowChart.InnerHtml = "您已於" + CkHasApply(1) + "<br/>申請「" + CkHasApply(2) + "」獎項申請<BR />收件編號：" + CkHasApply(0) + "，請確認。<br/>"
                                Div_ShowChart.InnerHtml = "您已於" + CkHasApply(1) + "<br/>申請「" + CkHasApply(2) + "」。<br/>收件編號：" + CkHasApply(0) + "，請確認。<br/>"
                                'tc 20160714 多加不能申請原因說明
                                Div_ShowChart.InnerHtml += CkHasApply(3)
                                Mpe_Chart.Show()
                                imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
                            End If
                        End If
                    End If
                Else
                    'Session("BuildVerifyChart") = String.Empty   'tc 20160705
                    TxtBox_VerifyCode.Text = String.Empty
                    Div_ShowChart.InnerHtml = "認證碼錯誤！請重新填入圖形認證碼"
                    Mpe_Chart.Show()
                    imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
                End If
            Else
                Div_ShowChart.InnerHtml = "請重新填入圖形認證碼"
                Mpe_Chart.Show()
                imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
            End If
        End If

    End Sub
    Protected Sub ExcInitControls(ByVal ParentControls As Control, ByVal Acate As String) '將頁面重新初始化
        Dim txt As TextBox
        Dim ReBtn As RadioButton
        Dim ReBtnList As RadioButtonList
        Dim DlList As DropDownList

        If Acate = "F" Then
            If ViewState("AppleMode") = "0" Then '把沒有申請的獎項隱藏
                Table_Apply_Item_S.Visible = True
                Table_Apply_Item_Z.Visible = False
                Table_Apply_Item_M.Visible = False
            ElseIf ViewState("AppleMode") = "1" Then
                Table_Apply_Item_S.Visible = False
                Table_Apply_Item_Z.Visible = True
                Table_Apply_Item_M.Visible = False
            ElseIf ViewState("AppleMode") = "2" Then
                Table_Apply_Item_S.Visible = False
                Table_Apply_Item_Z.Visible = False
                Table_Apply_Item_M.Visible = True
            End If
        Else
            'tc 20160714
            'If ViewState("CkApplyOther") = "S4" Or ViewState("CkApplyOther") = "S5" Then
            If "S4,S5,S6".Contains(ViewState("CkApplyOther")) Then
                Table_Apply_Item_S.Visible = True
                Table_Apply_Item_Z.Visible = False
                Table_Apply_Item_M.Visible = False
            ElseIf ViewState("CkApplyOther") = "Z1" Then
                Table_Apply_Item_S.Visible = False
                Table_Apply_Item_Z.Visible = True
                Table_Apply_Item_M.Visible = False
            ElseIf ViewState("CkApplyOther") = "M1" Then
                Table_Apply_Item_S.Visible = False
                Table_Apply_Item_Z.Visible = False
                Table_Apply_Item_M.Visible = True
            End If
        End If

        Dim Ctr As Control
        For Each Ctr In ParentControls.Controls
            If TypeOf Ctr Is TextBox Then '清空文字方塊
                txt = CType(Ctr, TextBox)
                txt.Text = String.Empty
            End If

            If TypeOf Ctr Is DropDownList Then
                DlList = CType(Ctr, DropDownList)
                DlList.Controls.Clear()
            End If

            If TypeOf Ctr Is RadioButton Then
                ReBtn = CType(Ctr, RadioButton)
                ReBtn.Checked = False
            End If

            If TypeOf Ctr Is RadioButtonList Then
                ReBtnList = CType(Ctr, RadioButtonList)
                ReBtnList.SelectedIndex = -1
            End If
            If Ctr.Controls.Count > 0 Then
                ExcInitControls(Ctr, Acate)
            End If
        Next
    End Sub

    Private Sub CkInputData(ByVal ParentControls As Control) '檢查必填欄位
        Dim txt As TextBox
        'Dim ReBtn As RadioButton
        Dim ReBtnList As RadioButtonList
        Dim DlList As DropDownList
        Dim CkBox As CheckBox
        Dim Ctr As Control
        For Each Ctr In ParentControls.Controls
            If TypeOf Ctr Is TextBox Then '此處是檢查文字輸入對話框
                txt = CType(Ctr, TextBox)
                If txt.Text.Trim() = String.Empty Then '沒有輸入資料
                    If txt.ID = DefineAll.Txt_Id_Id Then '身分證號碼
                        ErrMsg += DefineAll.Txt_Id_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.Txt_Id_Name)
                    End If
                    'CHC 0929 判斷不可空白
                    If txt.ID = DefineAll.TxtBox_Bank_Id Then '帳戶
                        ErrMsg += DefineAll.TxtBox_Bank_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.Txt_Id_Name)
                    End If
                    If txt.ID = DefineAll.Txt_Name_Id Then '姓名
                        ErrMsg += DefineAll.Txt_Name_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.Txt_Name_Name)
                    End If
                    'If txt.ID = DefineAll.Txt_OldName_Id Then '2017/9/4 gin 改名前之姓名 
                    '    InserColName += DefineAll.Txt_OldName_Name + ","
                    '    InserValues += "','"
                    '    Lb_OldName_Confirm.Text = String.Empty
                    '    Session("Lb_OldName_Confirm") = String.Empty
                    'End If
                    If txt.ID = DefineAll.TxtBox_Account_No_Id Then '匯款帳號
                        ErrMsg += DefineAll.TxtBox_Account_No_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Account_No_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_Account_Name_Id Then '戶名
                        ErrMsg += DefineAll.TxtBox_Account_Name_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Account_Name_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_Zid_Id Then '聯絡郵遞區號
                        ErrMsg += DefineAll.TxtBox_Zid_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Zid_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_RZip_Id Then '戶籍郵遞區號
                        ErrMsg += DefineAll.TxtBox_RZip_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_RZip_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_Tel_1_Id Then '電話(日)
                        ErrMsg += DefineAll.TxtBox_Tel_1_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Tel_1_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_Tel_2_Id Then '電話(夜)
                        ErrMsg += DefineAll.TxtBox_Tel_2_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Tel_2_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_Mobile_Id Then '手機
                        ErrMsg += DefineAll.TxtBox_Mobile_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Mobile_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_Email_Id Then '電子信箱
                        ErrMsg += DefineAll.TxtBox_Email_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Email_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_School_Id Then '學校名稱
                        ErrMsg += DefineAll.TxtBox_School_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_School_Name)
                    End If
                    If txt.ID = DefineAll.TxtBox_Dep_Id Then '科系名稱
                        InserColName += DefineAll.TxtBox_Dep_CName + ","
                        InserValues += "','"
                        Lb_Dep.Text = String.Empty
                        Session("Lb_Dep") = String.Empty
                    End If
                    If txt.ID = DefineAll.TxtBox_Damage_Id Then '損傷類別, 其他
                        '2017/8/31 gin
                        If Session("RdButton_Damage_Confirm") = "F6" Then
                            ErrMsg += DefineAll.TxtBox_Damage_Name + "－不可空白<br />"
                        End If
                        '2017/8/31 gin
                        InserColName += DefineAll.TxtBox_Damage_CName + ","
                        InserValues += "','"
                        Lb_Damage.Text = String.Empty
                        Session("Lb_Damage") = String.Empty
                    End If
                    If txt.ID = DefineAll.TxtBox_Grage_Id Then '年級
                        '     InserColName += DefineAll.TxtBox_Grage_CName + ","
                        '    InserValues += "','"
                        '   Lb_Grade_Confirm.Text = String.Empty
                        '  Session("Lb_Grade_Confirm") = String.Empty
                        ErrMsg += DefineAll.TxtBox_Grage_CName + "，不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Grage_CName)
                    End If


                    If txt.ID = DefineAll.TxtBox_Address_Id Then '聯絡地址
                        ErrMsg += DefineAll.TxtBox_Address_Name + "－不可空白<br />"
                        ErrMsgList.Add(DefineAll.TxtBox_Address_Name)
                    End If
                Else '如果有資料，檢查格式是否正確
                    If txt.ID = DefineAll.Txt_Id_Id Then '身分證號碼
                        InserColName += DefineAll.Txt_Id_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Id_Confirm.Text = txt.Text.Trim() '確認申請資料畫面
                        Session("Lb_Id_Confirm") = txt.Text.Trim() '確認申請資料畫面
                    End If
                    If txt.ID = DefineAll.Txt_Name_Id Then '姓名
                        InserColName += DefineAll.Txt_Name_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Name_Confirm.Text = txt.Text.Trim() '確認申請資料畫面
                        Session("Lb_Name_Confirm") = txt.Text.Trim() '確認申請資料畫面
                    End If
                    If txt.ID = DefineAll.Txt_OldName_Id Then '2017/9/4 gin 改名前之姓名 
                        InserColName += DefineAll.Txt_OldName_CName + ","
                        InserValues += txt.Text.Trim() + "','"
                        Lb_OldName_Confirm.Text = txt.Text.Trim()
                        Session("Lb_OldName_Confirm") = txt.Text.Trim()
                    End If
                    If txt.ID = DefineAll.TxtBox_Account_No_Id Then '匯款帳號
                        InserColName += DefineAll.TxtBox_Account_No_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Account.Text = txt.Text.Trim() '確認申請資料畫面
                        Session("Lb_Account") = txt.Text.Trim() '確認申請資料畫面
                    End If

                    If txt.ID = DefineAll.TxtBox_Account_Name_Id Then '戶名
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        If txt.Text <> Txt_Name.Text Then
                            ErrMsg += DefineAll.TxtBox_Account_Name_Name + "－限本人<br />"
                            ErrMsgList.Add(DefineAll.TxtBox_Account_Name_Name)
                        End If
                        InserColName += DefineAll.TxtBox_Account_Name_CName + ","
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Account_Name.Text = txt.Text.Trim() '確認申請資料畫面
                        Session("Lb_Account_Name") = txt.Text.Trim() '確認申請資料畫面
                    End If

                    If txt.ID = DefineAll.TxtBox_Zid_Id Then '聯絡郵遞區號
                        InserColName += DefineAll.TxtBox_Zid_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Session("Lb_Zid_Name") = txt.Text.Trim()
                    End If
                    If txt.ID = DefineAll.TxtBox_Address_Id Then '聯絡地址
                        InserColName += DefineAll.TxtBox_Address_CName + ","
                        txt.Text = CkStr.CkOtherChar(txt.Text.Trim()) '取代非法字元
                        'tc 0823 多加縣市
                        'InserValues += txt.Text.Trim() + "','"
                        'Lb_Address.Text = TxtBox_Zid.Text + " " + txt.Text.Trim() '確認申請資料畫面
                        'Session("Lb_Address") = TxtBox_Zid.Text + " " + txt.Text.Trim()
                        InserValues += GetAddress.Trim() + "','"
                        Lb_Address.Text = TxtBox_Zid.Text + " " + GetAddress.Trim() '確認申請資料畫面
                        Session("Lb_Address") = Lb_Address.Text
                    End If
                    If txt.ID = DefineAll.TxtBox_RZip_Id Then '戶籍郵遞區號
                        InserColName += DefineAll.TxtBox_RZip_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Session("Lb_RZid_Name") = txt.Text.Trim()
                    End If
                    If txt.ID = DefineAll.TxtBox_RAddress_Id Then '戶籍聯絡地址
                        InserColName += DefineAll.TxtBox_RAddress_CName + ","
                        txt.Text = CkStr.CkOtherChar(txt.Text.Trim()) '取代非法字元
                        'tc 0823 多加縣市 + 同地址處理
                        'InserValues += txt.Text.Trim() + "','"
                        'Lb_RAddress.Text = TxtBox_RZip.Text + " " + txt.Text.Trim() '確認申請資料畫面
                        'Session("Lb_RAddress") = TxtBox_RZip.Text + " " + txt.Text.Trim()
                        InserValues += GetAddressR().Trim() + "','"
                        Lb_RAddress.Text = TxtBox_RZip.Text + " " + GetAddressR().Trim() '確認申請資料畫面
                        Session("Lb_RAddress") = Lb_RAddress.Text
                    End If


                    If txt.ID = DefineAll.TxtBox_Tel_1_Id Then '電話(日)
                        'If CkStr.CkIsNumber(txt.Text.Trim()) = "y" Then
                        InserColName += DefineAll.TxtBox_Tel_1_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Tel_D.Text = txt.Text.Trim()       '確認申請資料畫面
                        Session("Lb_Tel_D") = txt.Text.Trim()
                        ' Else
                        '    ErrMsg += DefineAll.TxtBox_Tel_1_Name + "－只能輸入數字<br />"
                        ' End If

                    End If

                    If txt.ID = DefineAll.TxtBox_Tel_2_Id Then '電話(夜)
                        'If CkStr.CkIsNumber(txt.Text.Trim()) = "y" Then
                        InserColName += DefineAll.TxtBox_Tel_2_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Tel_N.Text = txt.Text.Trim()
                        Session("Lb_Tel_N") = txt.Text.Trim()
                        ' Else
                        '    ErrMsg += DefineAll.TxtBox_Tel_2_Name + "－只能輸入數字<br />"
                        ' End If
                    End If

                    If txt.ID = DefineAll.TxtBox_Mobile_Id Then '手機
                        '  If CkStr.CkIsNumber(txt.Text.Trim()) = "y" Then
                        InserColName += DefineAll.TxtBox_Mobile_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Mobile_Confirm.Text = txt.Text.Trim()
                        Session("Lb_Mobile_Confirm") = txt.Text.Trim()
                        'Else
                        '   ErrMsg += DefineAll.TxtBox_Mobile_Name + "－只能輸入數字<br />"
                        'End If
                    End If

                    Dim rgx As New Regex("[a-zA-Z0-9._%-]+@[a-zA-Z0-9._%-]+\.[a-zA-Z]{2,4}", RegexOptions.IgnoreCase)
                    If txt.ID = DefineAll.TxtBox_Email_Id Then '電子信箱
                        Dim matches As MatchCollection = rgx.Matches(txt.Text)
                        If matches.Count > 0 Then
                            InserColName += DefineAll.TxtBox_Email_CName + ","
                            txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                            InserValues += txt.Text.Trim() + "','"
                            Lb_Email.Text = txt.Text.Trim()
                            Session("Lb_Email") = txt.Text.Trim()
                        Else
                            ErrMsg += DefineAll.TxtBox_Email_Name + ",不合法<br />"
                        End If

                    End If
                    If txt.ID = DefineAll.TxtBox_School_Id Then '學校名稱
                        InserColName += DefineAll.TxtBox_School_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_School.Text = txt.Text.Trim()
                        Session("Lb_School") = txt.Text.Trim()
                    End If
                    If txt.ID = DefineAll.TxtBox_Dep_Id Then '科系名稱
                        InserColName += DefineAll.TxtBox_Dep_CName + ","
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Dep.Text = txt.Text.Trim()
                        Session("Lb_Dep") = txt.Text.Trim()
                    End If
                    If txt.ID = DefineAll.TxtBox_Damage_Id Then '損傷類別, 其他

                        InserColName += DefineAll.TxtBox_Damage_CName + ","
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Damage.Text = txt.Text.Trim()
                        Session("Lb_Damage") = txt.Text.Trim()

                        '損傷類別其他時, 才需輸入其他欄位
                        If Session("RdButton_Damage_Confirm") <> "F6" Then
                            Lb_Damage.Text = ""
                            Session("Lb_Damage") = ""
                            TxtBox_Damage.Text = "" '2017/8/30 gin 增加清空txtbox
                        End If
                    End If

                    If txt.ID = DefineAll.TxtBox_Grage_Id Then '年級
                        If CkStr.CkIsNumber(txt.Text.Trim()) = "y" Then
                            InserColName += DefineAll.TxtBox_Grage_CName + ","
                            txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                            InserValues += txt.Text.Trim() + "','"
                            Lb_Grade_Confirm.Text = txt.Text.Trim()
                            Session("Lb_Grade_Confirm") = txt.Text.Trim()
                        Else
                            ErrMsg += DefineAll.TxtBox_Grage_Name + "－只能輸入數字<br />"
                        End If
                    End If
                    If txt.ID = DefineAll.TxtBox_Bank_Id Then '銀行代碼

                        InserColName += DefineAll.TxtBox_Bank_CName + ","
                        txt.Text = CkStr.CkChar(txt.Text.Trim()) '取代非法字元
                        InserValues += txt.Text.Trim() + "','"
                        Lb_Bank_No.Text = txt.Text.Trim()
                        Session("Lb_Bank_No") = txt.Text.Trim()


                    End If
                End If
            End If

            If TypeOf Ctr Is DropDownList Then
                DlList = CType(Ctr, DropDownList)
                If DlList.SelectedIndex = -1 Then '出生年月日、郵遞區號、申請組別、銀行代碼
                    If DlList.ID = DefineAll.DpDownList_Year_Id Then '出生年月日的年
                        ErrMsg += DefineAll.DpDownList_Year_Name + "－不可空白<br />"
                    End If
                    If DlList.ID = DefineAll.DpDownList_Month_Id Then '出生年月日的月
                        ErrMsg += DefineAll.DpDownList_Month_Name + "－不可空白<br />"
                    End If
                    If DlList.ID = DefineAll.DpDownList_Day_Id Then '出生年月日的日
                        ErrMsg += DefineAll.DpDownList_Day_Name + "－不可空白<br />"
                    End If
                    If DlList.ID = DefineAll.DpDownList_Awards_Id Then '申請組別
                        ErrMsg += DefineAll.DpDownList_Awards_Name + "－不可空白<br />"
                    End If
                    'If DlList.ID = DefineAll.DpDownList_Bank_Code_Id Then '銀行代碼
                    '    ErrMsg += DefineAll.DpDownList_Bank_Code_Name + "－不可空白<br />"
                    'End If
                Else
                    'If DlList.ID = DefineAll.DpDownList_Year_Id Then '出生年月日的年
                    '    Birthday_y = DlList.SelectedValue
                    '    Lb_Birthday_Y.Text = DlList.SelectedValue
                    '    Session("Lb_Birthday_Y") = DlList.SelectedValue
                    'End If

                    '2017/9/12 gin 生日的西元年度改顯示為民國
                    If DlList.ID = DefineAll.DpDownList_Year_Id Then '出生年月日的年
                        Birthday_y = DlList.SelectedValue + 1911
                        Lb_Birthday_Y.Text = DlList.SelectedValue
                        Session("Lb_Birthday_Y") = DlList.SelectedValue
                    End If
                    If DlList.ID = DefineAll.DpDownList_Month_Id Then '出生年月日的月
                        Birthday_m = DlList.SelectedValue
                        Lb_Birthday_M.Text = DlList.SelectedValue
                        Session("Lb_Birthday_M") = DlList.SelectedValue
                    End If
                    If DlList.ID = DefineAll.DpDownList_Day_Id Then '出生年月日的日
                        Birthday_d = DlList.SelectedValue
                        Lb_Birthday_D.Text = DlList.SelectedValue
                        Session("Lb_Birthday_D") = DlList.SelectedValue
                    End If
                    If DlList.ID = DefineAll.DpDownList_Awards_Id Then '申請組別
                        InserValues += DlList.SelectedValue + "','"
                        InserColName += DefineAll.DpDownList_Awards_CName + ","
                        DpDownList_Awards_Confirm.SelectedValue = DlList.SelectedValue
                        Session("DpDownList_Awards_Confirm") = DlList.SelectedValue
                    End If
                End If
            End If

            'If TypeOf Ctr Is RadioButton Then
            '    ReBtn = CType(Ctr, RadioButton)
            '    ReBtn.Checked = False
            'End If

            'tc 0823 不做判斷，已在前面處理過了
            'If TypeOf Ctr Is CheckBox Then
            '    CkBox = CType(Ctr, CheckBox)
            '    If CkBox.Checked = True Then '處理同聯絡地址，若有勾選需檢查戶籍地址是否有輸入資料
            '        If CkBox.ID = DefineAll.CkBox_RAddress_Id Then '戶籍聯絡地址
            '            If TxtBox_RAddress.Text.Trim() = String.Empty Then
            '                ErrMsg += DefineAll.TxtBox_RAddress_Name + "－不可空白<br />"
            '            End If
            '        End If
            '    End If
            'End If

            If TypeOf Ctr Is RadioButtonList Then
                ReBtnList = CType(Ctr, RadioButtonList)
                If ReBtnList.SelectedIndex = -1 Then
                    If ReBtnList.ID = DefineAll.RdButton_Sex_Id Then '性別
                        ErrMsg += DefineAll.RdButton_Sex_Name + "－不可空白<br />"
                    End If
                    If ReBtnList.ID = DefineAll.RdButton_Damage_Id Then '損傷類別
                        ErrMsg += DefineAll.RdButton_Damage_Name + "－不可空白<br />"
                    End If
                    If ReBtnList.ID = DefineAll.RdButton_Mode_Id Then '申請方式
                        ErrMsg += DefineAll.RdButton_Mode_Name + "－不可空白<br />"
                    End If

                    If ReBtnList.ID = DefineAll.RdButton_ApplyTimes_Id Then '申請次數
                        ErrMsg += DefineAll.RdButton_ApplyTimes_Name + "－不可空白<br />"
                    End If

                    If ViewState("AppleMode") = "0" Then '陽光獎項
                        If ReBtnList.ID = DefineAll.RdButton_Apply_Item_S_Id Then
                            ErrMsg += DefineAll.RdButton_Apply_Item_S_Name + "－不可空白<br />"
                        End If
                    ElseIf ViewState("AppleMode") = "1" Then '仁寶獎項
                        If ReBtnList.ID = DefineAll.RdButton_Apply_Item_Z_Id Then
                            ErrMsg += DefineAll.RdButton_Apply_Item_Z_Name + "－不可空白<br />"
                        End If
                    ElseIf ViewState("AppleMode") = "2" Then '明閱獎項
                        If ReBtnList.ID = DefineAll.RdButton_Apply_Item_M_Id Then
                            ErrMsg += DefineAll.RdButton_Apply_Item_M_Name + "－不可空白<br />"
                        End If
                    End If
                Else
                    If ReBtnList.ID = DefineAll.RdButton_Sex_Id Then '性別                        
                        InserValues += ReBtnList.SelectedValue + "','"
                        InserColName += DefineAll.RdButton_Sex_CName + ","
                        RdButton_Sex_Confirm.SelectedValue = ReBtnList.SelectedValue '確認申請資料的性別
                        Session("RdButton_Sex_Confirm") = ReBtnList.SelectedValue
                    End If
                    If ReBtnList.ID = DefineAll.RdButton_Damage_Id Then '損傷類別
                        InserValues += ReBtnList.SelectedValue + "','"
                        InserColName += DefineAll.RdButton_Damage_CName + ","
                        RdButton_Damage_Confirm.SelectedValue = ReBtnList.SelectedValue '確認申請資料的損傷類別
                        Session("RdButton_Damage_Confirm") = ReBtnList.SelectedValue



                    End If
                    If ReBtnList.ID = DefineAll.RdButton_ApplyTimes_Id Then '申請次數
                        InserValues += ReBtnList.SelectedValue + "','"
                        InserColName += DefineAll.RdButton_ApplyTimes_CName + ","
                        RdButton_ApplyTime_Confirm.SelectedValue = ReBtnList.SelectedValue '確認申請資料的申請次數
                        Session("RdButton_ApplyTime_Confirm") = ReBtnList.SelectedValue
                    End If


                    If ViewState("AppleMode") = "0" Then '陽光獎項
                        If ReBtnList.ID = DefineAll.RdButton_Apply_Item_S_Id Then
                            'tc 20160714 多加第六項
                            If ReBtnList.SelectedValue = "S5" Or ReBtnList.SelectedValue = "S6" Then '選擇「陽光子女助學金」，則「子女助學金之損傷者姓名」與「親屬關係」為必填
                                If TxtBox_PName.Text.Trim() = String.Empty Then
                                    ErrMsg += DefineAll.TxtBox_PName_Name + "－不可空白<br />"
                                Else
                                    If RdButton_Parents.SelectedIndex = -1 Then
                                        ErrMsg += DefineAll.RdButton_Parents_Name + "－不可空白<br />"
                                    Else
                                        InserValues += TxtBox_PName.Text.Trim() + "','"                     '子女助學金之損傷者姓名
                                        InserColName += DefineAll.TxtBox_PName_CName + ","
                                        InserValues += RdButton_Parents.SelectedValue + "','"               '子女助學金之親屬關係
                                        InserColName += DefineAll.RdButton_Parents_CName + ","

                                        RdButton_Parents_Confirm.SelectedValue = RdButton_Parents.SelectedValue
                                        Lb_PName.Text = TxtBox_PName.Text.Trim()

                                        Session("RdButton_Parents_Confirm") = RdButton_Parents.SelectedValue
                                        Session("Lb_PName") = TxtBox_PName.Text.Trim()
                                        Session("AppleMode") = ReBtnList.SelectedValue
                                    End If
                                End If
                                RdButton_Apply_Item_S1.Checked = False
                                RdButton_Apply_Item_S2.Checked = False
                                RdButton_Apply_Item_S3.Checked = False
                                RdButton_Apply_Item_S4.Checked = False
                                'tc 20160714 modify
                                If ReBtnList.SelectedValue = "S5" Then
                                    RdButton_Apply_Item_S5.Checked = True
                                    RdButton_Apply_Item_S6.Checked = False
                                Else
                                    RdButton_Apply_Item_S5.Checked = False
                                    RdButton_Apply_Item_S6.Checked = True
                                End If

                                InserValues += ReBtnList.SelectedValue + "','"
                                InserColName += DefineAll.RdButton_Apply_Item_S_CName + ","
                            Else
                                ' 非子女的清掉父母選擇值
                                Session("RdButton_Parents_Confirm") = ""
                                Session("Lb_PName") = ""
                                Lb_PName.Text = ""
                                RdButton_Parents_Confirm.SelectedIndex = -1

                                If ReBtnList.SelectedValue = "S1" Then    '確認申請資料的陽光獎項
                                    RdButton_Apply_Item_S1.Checked = True
                                    RdButton_Apply_Item_S2.Checked = False
                                    RdButton_Apply_Item_S3.Checked = False
                                    RdButton_Apply_Item_S4.Checked = False
                                    RdButton_Apply_Item_S5.Checked = False
                                    RdButton_Apply_Item_S6.Checked = False
                                    Session("AppleMode") = ReBtnList.SelectedValue
                                    InserValues += ReBtnList.SelectedValue + "','"
                                    InserColName += DefineAll.RdButton_Apply_Item_S_CName + ","
                                ElseIf ReBtnList.SelectedValue = "S2" Then
                                    RdButton_Apply_Item_S1.Checked = False
                                    RdButton_Apply_Item_S2.Checked = True
                                    RdButton_Apply_Item_S3.Checked = False
                                    RdButton_Apply_Item_S4.Checked = False
                                    RdButton_Apply_Item_S5.Checked = False
                                    RdButton_Apply_Item_S6.Checked = False
                                    Session("AppleMode") = ReBtnList.SelectedValue
                                    InserValues += ReBtnList.SelectedValue + "','"
                                    InserColName += DefineAll.RdButton_Apply_Item_S_CName + ","
                                ElseIf ReBtnList.SelectedValue = "S3" Then

                                    If DpDownList_Awards.SelectedValue <= "2" Then
                                        'tc 0823 文字修改
                                        'ErrMsg += DpDownList_Awards.SelectedItem.Text + "，升學獎學金只接受大學以上(高中升大學)<br />"
                                        ErrMsg += "升學獎學金之申請組別不符<br />"
                                    Else
                                        RdButton_Apply_Item_S1.Checked = False
                                        RdButton_Apply_Item_S2.Checked = False
                                        RdButton_Apply_Item_S3.Checked = True
                                        RdButton_Apply_Item_S4.Checked = False
                                        RdButton_Apply_Item_S5.Checked = False
                                        RdButton_Apply_Item_S6.Checked = False
                                        Session("AppleMode") = ReBtnList.SelectedValue
                                        InserValues += ReBtnList.SelectedValue + "','"
                                        InserColName += DefineAll.RdButton_Apply_Item_S_CName + ","
                                    End If
                                ElseIf ReBtnList.SelectedValue = "S4" Then
                                    RdButton_Apply_Item_S1.Checked = False
                                    RdButton_Apply_Item_S2.Checked = False
                                    RdButton_Apply_Item_S3.Checked = False
                                    RdButton_Apply_Item_S4.Checked = True
                                    RdButton_Apply_Item_S5.Checked = False
                                    RdButton_Apply_Item_S6.Checked = False
                                    Session("AppleMode") = ReBtnList.SelectedValue
                                    InserValues += ReBtnList.SelectedValue + "','"
                                    InserColName += DefineAll.RdButton_Apply_Item_S_CName + ","
                                End If
                            End If
                        End If
                        RdButton_Apply_Item_Z1.Visible = "False"  '獎項的第一欄控制項
                        RdButton_Apply_Item_Z2.Visible = "False"  '獎項的第二欄控制項
                        RdButton_Apply_Item_M1.Visible = "False"
                        Lb_PApplyItem_Z1.Visible = "False"        '獎項的第一欄名稱
                        Lb_PApplyItem_M1.Visible = "False"
                        Lb_PApplyItem_Z2.Visible = "False"        '獎項的第二欄名稱

                        Tb_PName.Visible = True '損傷者姓名、親屬關係欄位
                    ElseIf ViewState("AppleMode") = "1" Then '仁寶獎項
                        If ReBtnList.ID = DefineAll.RdButton_Apply_Item_Z_Id Then '仁寶獎項
                            If ReBtnList.SelectedValue = "Z1" Then    '確認申請資料的陽光獎項
                                RdButton_Apply_Item_Z1.Checked = True
                                RdButton_Apply_Item_Z2.Checked = False
                                InserValues += ReBtnList.SelectedValue + "','"
                                InserColName += DefineAll.RdButton_Apply_Item_Z_CName + ","
                                Session("AppleMode") = ReBtnList.SelectedValue
                            ElseIf ReBtnList.SelectedValue = "Z2" Then
                                RdButton_Apply_Item_Z1.Checked = False
                                RdButton_Apply_Item_Z2.Checked = True
                                InserValues += ReBtnList.SelectedValue + "','"
                                InserColName += DefineAll.RdButton_Apply_Item_Z_CName + ","
                                Session("AppleMode") = ReBtnList.SelectedValue
                            End If
                        End If

                        RdButton_Apply_Item_Z1.Visible = True  '獎項的第一欄控制項
                        RdButton_Apply_Item_Z2.Visible = True
                        Lb_PApplyItem_Z1.Visible = True
                        Lb_PApplyItem_Z2.Visible = True

                        RdButton_Apply_Item_S1.Visible = False  '獎項的第一欄控制項
                        RdButton_Apply_Item_S2.Visible = False  '獎項的第二欄控制項
                        RdButton_Apply_Item_S3.Visible = False  '獎項的第三欄控制項
                        RdButton_Apply_Item_S4.Visible = False  '獎項的第四欄控制項
                        RdButton_Apply_Item_S5.Visible = False  '獎項的第五欄控制項
                        RdButton_Apply_Item_S6.Visible = False  'tc 20160714 獎項的第六欄控制項
                        RdButton_Apply_Item_M1.Visible = False  '獎項的第一欄控制項

                        Lb_PApplyItem_S1.Visible = False        '獎項的第一欄名稱
                        Lb_PApplyItem_S2.Visible = False
                        Lb_PApplyItem_S3.Visible = False
                        Lb_PApplyItem_S4.Visible = False
                        Lb_PApplyItem_S5.Visible = False
                        Lb_PApplyItem_S6.Visible = False  'tc 20160714
                        Lb_PApplyItem_M1.Visible = False

                        Tb_PName.Visible = False '損傷者姓名、親屬關係欄位
                    ElseIf ViewState("AppleMode") = "2" Then '明閱獎項
                        If ReBtnList.ID = DefineAll.RdButton_Apply_Item_M_Id Then
                            If ReBtnList.SelectedValue = "M1" Then '選擇「明閱科技_陽光子女特殊才藝獎助學金」，則「子女助學金之損傷者姓名」與「親屬關係」為必填
                                If TxtBox_PName_M.Text.Trim() = String.Empty Then
                                    ErrMsg += DefineAll.TxtBox_PName_M_Name + "－不可空白<br />"
                                Else
                                    If RdButton_Parents_M.SelectedIndex = -1 Then
                                        ErrMsg += DefineAll.RdButton_Parents_Name + "－不可空白<br />"
                                    Else
                                        InserValues += TxtBox_PName_M.Text.Trim() + "','"                     '子女助學金之損傷者姓名
                                        InserColName += DefineAll.TxtBox_PName_CName + ","
                                        InserValues += RdButton_Parents_M.SelectedValue + "','"                  '子女助學金之親屬關係
                                        InserColName += DefineAll.RdButton_Parents_CName + ","

                                        RdButton_Apply_Item_M1.Checked = True
                                        RdButton_Parents_Confirm.SelectedValue = RdButton_Parents_M.SelectedValue '確認畫面的親屬關係
                                        Lb_PName.Text = TxtBox_PName_M.Text.Trim()                                '確認畫面的損傷者姓名
                                        Session("AppleMode") = ReBtnList.SelectedValue
                                        Session("RdButton_Parents_Confirm") = RdButton_Parents_M.SelectedValue
                                        Session("Lb_PName") = TxtBox_PName_M.Text.Trim()

                                        InserValues += ReBtnList.SelectedValue + "','"
                                        InserColName += DefineAll.RdButton_Apply_Item_Z_CName + ","
                                    End If
                                End If
                            End If
                        End If

                        RdButton_Apply_Item_M1.Visible = True  '獎項的第一欄控制項

                        RdButton_Apply_Item_Z1.Visible = False  '獎項的第一欄控制項
                        RdButton_Apply_Item_Z2.Visible = False

                        RdButton_Apply_Item_S1.Visible = False  '獎項的第一欄控制項
                        RdButton_Apply_Item_S2.Visible = False  '獎項的第二欄控制項
                        RdButton_Apply_Item_S3.Visible = False  '獎項的第三欄控制項
                        RdButton_Apply_Item_S4.Visible = False  '獎項的第四欄控制項
                        RdButton_Apply_Item_S5.Visible = False  '獎項的第五欄控制項
                        RdButton_Apply_Item_S6.Visible = False  'tc 20160714 獎項的第六欄控制項


                        Lb_PApplyItem_S1.Visible = True        '獎項的第一欄名稱
                        Lb_PApplyItem_S2.Visible = False
                        Lb_PApplyItem_S3.Visible = False
                        Lb_PApplyItem_S4.Visible = False
                        Lb_PApplyItem_S5.Visible = False
                        Lb_PApplyItem_S6.Visible = False  'tc 20160714
                        Lb_PApplyItem_Z1.Visible = False
                        Lb_PApplyItem_Z2.Visible = False

                        Tb_PName.Visible = True '損傷者姓名、親屬關係欄位
                    End If

                    If ReBtnList.ID = DefineAll.RdButton_Mode_Id Then
                        Session("RdButton_Mode_Confirm") = ReBtnList.SelectedValue
                        If ReBtnList.SelectedValue = "2" Then '選擇「單位推薦」，則「推薦單位」與「推薦人姓名」與「推薦人職務」與「推薦人電話」為必填
                            If TxtBox_Recommend.Text.Trim() = String.Empty Then '推薦單位
                                ErrMsg += DefineAll.TxtBox_Recommend_Name + "－不可空白<br />"
                            Else
                                InserValues += TxtBox_Recommend.Text.Trim() + "','"
                                InserColName += DefineAll.TxtBox_Recommend_CName + ","
                                Lb_recommend.Text = TxtBox_Recommend.Text.Trim()
                                Session("Lb_recommend") = TxtBox_Recommend.Text.Trim()
                            End If
                            If TxtBox_Rec_Name.Text.Trim() = String.Empty Then '推薦人姓名
                                ErrMsg += DefineAll.TxtBox_Rec_Name_Name + "－不可空白<br />"
                            Else
                                InserValues += TxtBox_Rec_Name.Text.Trim() + "','"
                                InserColName += DefineAll.TxtBox_Rec_Name_CName + ","
                                Lb_Rec_Name.Text = TxtBox_Rec_Name.Text.Trim()
                                Session("Lb_Rec_Name") = TxtBox_Rec_Name.Text.Trim()
                            End If
                            If TxtBox_Rec_Position.Text.Trim() = String.Empty Then '推薦人職務
                                ErrMsg += DefineAll.TxtBox_Rec_Position_Name + "－不可空白<br />"
                            Else
                                InserValues += TxtBox_Rec_Position.Text.Trim() + "','"
                                InserColName += DefineAll.TxtBox_Rec_Position_CName + ","
                                Lb_Rec_Position.Text = TxtBox_Rec_Position.Text.Trim()
                                Session("Lb_Rec_Position") = TxtBox_Rec_Position.Text.Trim()
                            End If
                            If TxtBox_Rec_Tel.Text.Trim() = String.Empty Then '推薦人電話
                                ErrMsg += DefineAll.TxtBox_Rec_Tel_Name + "－不可空白<br />"
                            Else
                                If CkStr.CkIsNumber(TxtBox_Rec_Tel.Text.Trim()) = "y" Then
                                    InserValues += TxtBox_Rec_Tel.Text.Trim() + "','"
                                    InserColName += DefineAll.TxtBox_Rec_Tel_CName + ","
                                    Lb_Rec_Tel.Text = TxtBox_Rec_Tel.Text.Trim()
                                    Session("Lb_Rec_Tel") = TxtBox_Rec_Tel.Text.Trim()
                                Else
                                    ErrMsg += DefineAll.TxtBox_Rec_Tel_Name + "－只能輸入數字<br />"
                                End If
                            End If
                            InserValues += ReBtnList.SelectedValue + "','"
                            InserColName += DefineAll.RdButton_Mode_CName + ","
                            RdButton_Mode_Confirm.SelectedValue = ReBtnList.SelectedValue
                        Else
                            Lb_recommend.Text = String.Empty
                            Lb_Rec_Name.Text = String.Empty
                            Lb_Rec_Position.Text = String.Empty
                            Lb_Rec_Tel.Text = String.Empty
                            InserValues += ReBtnList.SelectedValue + "','"
                            InserColName += DefineAll.RdButton_Mode_CName + ","
                            RdButton_Mode_Confirm.SelectedValue = ReBtnList.SelectedValue
                        End If
                    End If
                End If
            End If

            If Ctr.Controls.Count > 0 Then '如果控制項內涵子控制項，繼續往下做檢查(遞迴圈)
                CkInputData(Ctr)
            End If
        Next
    End Sub
    Private Sub InitDropdownlist()
        'Dim DdlistYear As Integer = 1911
        Dim DdlistYear As Integer = DateTime.Now.Year - 1911 - 70
        Dim DdlistMonth As Integer = 12
        Dim DllistDay As Integer = 31

        DpDownList_Year.Items.Add(New ListItem("請選擇", ""))
        'For i As Integer = DateTime.Now.Year To DdlistYear Step -1
        '    DpDownList_Year.Items.Add(i)
        'Next

        '2017/9/12 gin 生日的西元年度改顯示為民國
        For i As Integer = DateTime.Now.Year - 1911 To DdlistYear Step -1
            DpDownList_Year.Items.Add(i)
        Next

        DpDownList_Year.SelectedIndex = -1

        DpDownList_Month.Items.Add(New ListItem("請選擇", ""))
        For i As Integer = 1 To DdlistMonth
            DpDownList_Month.Items.Add(i)
        Next
        DpDownList_Month.SelectedIndex = -1

        DpDownList_Day.Items.Add(New ListItem("請選擇", ""))
        For i As Integer = 1 To DllistDay
            DpDownList_Day.Items.Add(i)
        Next
        DpDownList_Day.SelectedIndex = -1

        If ViewState("AppleMode") = "1" Then
            DpDownList_Awards.Items.Clear()
            DpDownList_Awards.Items.Add(New ListItem("3高中組", 3))
            DpDownList_Awards.Items.Add(New ListItem("4大學組", 4))
            DpDownList_Awards.Items.Add(New ListItem("5碩士組", 5))
            DpDownList_Awards.Items.Add(New ListItem("6博士組", 6))
        End If


        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()

        Dim SqlStr As String = "SELECT substring([bank_code],1,3) as BankCode,(substring([bank_code],1,3) +  bank_referred) as BankName FROM BANK " + _
                               "Where bank_name Not Like '%郵局' Group By substring([bank_code],1,3), bank_referred Order by BankCode"

        If Conn Is Nothing Then
            'tc 0823 無法連線至DB，提示錯誤訊息
            'Sh.ShowMsg(Btn_Login, "資料庫連接異常，請洽系統管理員")
            ShowError(ErrorCode.DB_Cannot_Connect)
            Return
        End If

        Dim DataTb As DataTable = New DataTable()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlStr, Conn)
        Da.Fill(DataTb)

        SqlStr = "Select bank_referred as BankCode, '700' + bank_referred as BankName FROM BANK Where bank_name Like '%郵局' Group By bank_referred "
        Da = New SqlDataAdapter(SqlStr, Conn)
        Da.Fill(DataTb)

        'Dim Dt As SqlDataReader = Db.DataReader(SqlStr, Conn)
        DpDownList_Bank_Code.DataSource = DataTb
        DpDownList_Bank_Code.DataTextField = "BankName"
        DpDownList_Bank_Code.DataValueField = "BankCode"
        DpDownList_Bank_Code.DataBind()
        'Dt.Close()

        DpDownList_Bank_Code.Items.Insert(0, "請選擇")
        DpDownList_Bank_Code.SelectedIndex = 0


        '  SqlStr = "SELECT distinct county_name FROM ZIP"
        SqlStr = "SELECT  distinct left(zip_code,1)+ county_name as cnorder, county_name FROM ZIP order by cnorder  "
        Dim ZDt As SqlDataReader = Db.DataReader(SqlStr, Conn)

        DpDownList_City.DataSource = ZDt
        DpDownList_City.DataTextField = "county_name"
        DpDownList_City.DataValueField = "county_name"
        DpDownList_City.DataBind()
        ZDt.Close()

        DpDownList_City.Items.Insert(0, "請選擇")
        DpDownList_City.SelectedIndex = 0

        Dim RDt As SqlDataReader = Db.DataReader(SqlStr, Conn)
        DpDownList_RCity.DataSource = RDt
        DpDownList_RCity.DataTextField = "county_name"
        DpDownList_RCity.DataValueField = "county_name"
        DpDownList_RCity.DataBind()
        RDt.Close()

        Db.DBClose(Conn)
        DpDownList_RCity.Items.Insert(0, "請選擇")
        DpDownList_RCity.SelectedIndex = 0
    End Sub

    Public Sub ShowError(ByVal ErrorCode As ErrorCode)
        'tc 0823 錯誤訊息代碼轉換成文字
        Dim str As String = ""
        Select Case ErrorCode
            Case ErrorCode.DB_Cannot_Connect
                str = "無法連接資料庫，請洽系統管理員。"
            Case Else
                str = "未知錯誤"
        End Select
        '顯示錯誤訊息畫面
        Div_ShowMsg.InnerHtml = str
        Btn_ShowMsg_Confirm.Text = "回到申請頁"
        Btn_ShowMsg_Confirm.CssClass = ""
        Btn_ShowMsg_Confirm.OnClientClick = "window.open('" + BackToHome + "', '_self');"
        Mpe_Msg.Show()
    End Sub

    Protected Sub DpDownList_Bank_Code_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DpDownList_Bank_Code.SelectedIndexChanged
        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()
        Dim SqlStr As String
        Dim SelectStr = DpDownList_Bank_Code.SelectedItem
        If Right(DpDownList_Bank_Code.SelectedValue, 2) = "郵局" Then
            SqlStr = "SELECT bank_code as BankCode,(bank_code +  bank_name) as BankName FROM BANK " + _
                                                      "Where bank_referred = '" + DpDownList_Bank_Code.SelectedValue + _
                                                      "' Order by BankCode"
        Else
            SqlStr = "SELECT bank_code as BankCode,(bank_code +  bank_name) as BankName FROM BANK " + _
                                          "Where bank_code like '" + DpDownList_Bank_Code.SelectedValue + "%' " + _
                                          "And bank_name Not Like '%郵局'  Order by BankCode"
        End If

        If Conn Is Nothing Then
            'Sh.ShowMsg(Btn_Login, "資料庫連接異常，請洽系統管理員")
            Return
        End If

        Dim Dt As SqlDataReader = Db.DataReader(SqlStr, Conn)
        DpDownList_Bank_Name.DataSource = Dt
        DpDownList_Bank_Name.DataTextField = "BankName"
        DpDownList_Bank_Name.DataValueField = "BankCode"
        DpDownList_Bank_Name.DataBind()
        Dt.Close()
        Db.DBClose(Conn)
        TxtBox_Bank.Text = String.Empty
        DpDownList_Bank_Name.Items.Insert(0, "請選擇")
        DpDownList_Bank_Name.SelectedIndex = 0
        'tc 160825 銀行代碼清空
        TxtBox_Bank.Text = ""
    End Sub

    Protected Sub DpDownList_Bank_Name_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DpDownList_Bank_Name.SelectedIndexChanged
        If DpDownList_Bank_Name.SelectedIndex <> -1 And DpDownList_Bank_Name.SelectedIndex <> 0 Then
            TxtBox_Bank.Text = DpDownList_Bank_Name.SelectedValue.Trim()
        Else
            TxtBox_Bank.Text = String.Empty
        End If
    End Sub

    Protected Sub DpDownList_City_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DpDownList_City.SelectedIndexChanged
        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()

        Dim SqlStr As String = "Select zip_code,town_name From zip Where county_name='" + DpDownList_City.SelectedValue + "' " + _
                               "Order by zip_code"

        If Conn Is Nothing Then
            'Sh.ShowMsg(Btn_Login, "資料庫連接異常，請洽系統管理員")
            Return
        End If


        Dim Dt As SqlDataReader = Db.DataReader(SqlStr, Conn)
        DpDownList_Downtown.DataSource = Dt
        DpDownList_Downtown.DataTextField = "town_name"
        DpDownList_Downtown.DataValueField = "zip_code"
        DpDownList_Downtown.DataBind()
        Dt.Close()
        Db.DBClose(Conn)
        TxtBox_Zid.Text = String.Empty
        DpDownList_Downtown.Items.Insert(0, "請選擇")
        DpDownList_Downtown.SelectedIndex = 0
    End Sub

    Protected Sub DpDownList_Downtown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DpDownList_Downtown.SelectedIndexChanged
        If DpDownList_Downtown.SelectedIndex <> -1 And DpDownList_Downtown.SelectedIndex <> 0 Then
            TxtBox_Zid.Text = DpDownList_Downtown.SelectedValue.Trim()
        Else
            TxtBox_Zid.Text = String.Empty
        End If
        'chc 增加預帶地址
        If TxtBox_Address.Text = "" Or TxtBox_Address.Text.Length <= 10 Then
            TxtBox_Address.Text = DpDownList_City.Text.Trim & DpDownList_Downtown.SelectedItem.Text.Trim
        End If
    End Sub

    Protected Sub CkBox_RAddress_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox_RAddress.CheckedChanged
        If CkBox_RAddress.Checked Then
            If TxtBox_Address.Text <> String.Empty Then
                TxtBox_RAddress.Text = TxtBox_Address.Text.Trim()
            End If
            If TxtBox_Zid.Text <> String.Empty Then
                TxtBox_RZip.Text = TxtBox_Zid.Text
            End If
        End If
    End Sub

    Protected Sub DpDownList_RCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DpDownList_RCity.SelectedIndexChanged
        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()

        Dim SqlStr As String = "Select zip_code,town_name From zip Where county_name='" + DpDownList_RCity.SelectedValue + "' " + _
                               "Order by zip_code"

        If Conn Is Nothing Then
            'Sh.ShowMsg(Btn_Login, "資料庫連接異常，請洽系統管理員")
            Return
        End If

        Dim Dt As SqlDataReader = Db.DataReader(SqlStr, Conn)
        DpDownList_RDowntown.DataSource = Dt
        DpDownList_RDowntown.DataTextField = "town_name"
        DpDownList_RDowntown.DataValueField = "zip_code"
        DpDownList_RDowntown.DataBind()
        Dt.Close()
        Db.DBClose(Conn)
        TxtBox_RZip.Text = String.Empty
        DpDownList_RDowntown.Items.Insert(0, "請選擇")
        DpDownList_RDowntown.SelectedIndex = 0
    End Sub

    Protected Sub DpDownList_RDowntown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DpDownList_RDowntown.SelectedIndexChanged
        If DpDownList_RDowntown.SelectedIndex <> -1 And DpDownList_RDowntown.SelectedIndex <> 0 Then
            TxtBox_RZip.Text = DpDownList_RDowntown.SelectedValue.Trim()
        Else
            TxtBox_RZip.Text = String.Empty
        End If
        'chc 增加預帶地址
        If TxtBox_RAddress.Text = "" Or TxtBox_RAddress.Text.Length <= 10 Then
            TxtBox_RAddress.Text = DpDownList_RCity.Text.Trim & DpDownList_RDowntown.SelectedItem.Text.Trim
        End If
    End Sub

    Protected Sub RdButton_Mode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdButton_Mode.SelectedIndexChanged
        If RdButton_Mode.SelectedIndex <> -1 Then
            If RdButton_Mode.SelectedValue = "1" Then
                TxtBox_Recommend.Text = String.Empty
                TxtBox_Rec_Name.Text = String.Empty
                TxtBox_Rec_Position.Text = String.Empty
                TxtBox_Rec_Tel.Text = String.Empty
            End If
        End If
    End Sub
    Private Function CkIsApply() As List(Of String) '檢查年度內是否已經申請過該獎項
        Dim ApplyItem As String = String.Empty
        Dim ApplyName As String = String.Empty
        Dim Qresult As List(Of String) = New List(Of String)

        Dim CkApplyItem As String = String.Empty '20160523 Add By Sam Shen 判斷是否可以申請其他獎項，S4→Z1，S5→M1
        If Not ViewState("AppleMode") = Nothing Then
            If ViewState("AppleMode") = "0" Then
                ApplyItem = RdButton_Apply_Item_S.SelectedValue
            ElseIf ViewState("AppleMode") = "1" Then
                ApplyItem = RdButton_Apply_Item_Z.SelectedValue
            ElseIf ViewState("AppleMode") = "2" Then
                ApplyItem = RdButton_Apply_Item_M.SelectedValue
            End If
        Else
            Return Qresult
        End If

        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()
        Dim Conn2 As SqlConnection = Db.DBConnection()

        Dim SqlStr As String = "Select award_name From AWARD Where award_code='" + ApplyItem + "'"

        Dim Comm As SqlCommand = New SqlCommand(SqlStr, Conn)
        ApplyName = Comm.ExecuteScalar()

        'tc 20160714 	(一)~(五)類「陽光傷友獎學金」之申請類別只能選擇一項，不得重複申請。
        Dim SameAward1 As String = "'S1','S2','S3','S4'"
        Dim SameAward2 As String = "'S5','S6'"
        'tc 160822 仁寶只能二選一
        Dim SameAward3 As String = "'Z1','Z2'"

        If SameAward1.Contains(ApplyItem) Then 'CHC S1-S4 不得重覆申請 S1-S6
            SqlStr = "Select apply_no,apply_date, awards From APPLY Where id_no='" + Txt_Id.Text.Trim() + "' And awards IN ({0}) And " + _
                     "YEAR(apply_date)='" + DateTime.Now.Year.ToString() + "'"
            SqlStr = String.Format(SqlStr, SameAward1 & "," & SameAward2) '申請過5-6，不可再申請1-4
            'SqlStr = String.Format(SqlStr, SameAward1) 'tc 160822 傷友與子女可以分別請 
        ElseIf SameAward2.Contains(ApplyItem) Then   'CHC S5-S6 不得重覆申請S1-S4 及自己
            SqlStr = "Select apply_no,apply_date, awards From APPLY Where id_no='" + Txt_Id.Text.Trim() + "' And awards IN ({0}) And " + _
                     "YEAR(apply_date)='" + DateTime.Now.Year.ToString() + "'"
            'SqlStr = String.Format(SqlStr, SameAward1 & ",'" & ApplyItem & "'")
            SqlStr = String.Format(SqlStr, SameAward1 & "," & SameAward2) '申請1-4，不可再申請5,6。傷友子女，只能申請陽光的 5, 6 項其中的一項。
        ElseIf SameAward3.Contains(ApplyItem) Then 'tc 160822 仁寶只能二選一
            SqlStr = "Select apply_no,apply_date, awards From APPLY Where id_no='" + Txt_Id.Text.Trim() + "' And awards IN ({0}) And " + _
                     "YEAR(apply_date)='" + DateTime.Now.Year.ToString() + "'"
            SqlStr = String.Format(SqlStr, SameAward3)
        Else
            SqlStr = "Select apply_no,apply_date, awards From APPLY Where id_no='" + Txt_Id.Text.Trim() + "' And awards='" + ApplyItem + "' And " + _
                     "YEAR(apply_date)='" + DateTime.Now.Year.ToString() + "'"
        End If


        If Conn Is Nothing Then
            Wlog.WriteErrMsg("錯誤原因為資料庫連接異常")
            Return Qresult
        End If

        Comm = New SqlCommand(SqlStr, Conn)
        Dim Sr As SqlDataReader

        Try
            Sr = Comm.ExecuteReader()
            If Sr.Read() Then
                Qresult.Add(Sr(0).ToString())
                Qresult.Add(Sr(1).ToString())

                SqlStr = "Select award_name From AWARD Where award_code='" + Sr(2).ToString() + "'"
                Dim Comm2 As SqlCommand = New SqlCommand(SqlStr, Conn2)
                ApplyName = Comm2.ExecuteScalar()

                Qresult.Add(ApplyName)
                Qresult.Add("")
                'tc 0823 獎助學金已申請過，本人就不得重複申請。
                Qresult(3) = "「陽光獎助學金」<br/>只能選擇一項，不得重複申請。"
                'tc 20160714 	(一)~(五)類「陽光傷友獎學金」之申請類別只能選擇一項，不得重複申請。
                'If SameAward1.Contains(Sr(2).ToString()) Then
                '    Qresult(3) = "申請過(一)~(四)類「陽光傷友獎學金」者，不得重複申請。"
                'End If
                'If SameAward2.Contains(Sr(2).ToString()) Then
                '    Qresult(3) = "申請「陽光子女獎學金」者，只得重複申請另一子女獎學金。"
                'End If

                'tc 160822 仁寶只能二選一
                If SameAward3.Contains(Sr(2).ToString()) Then
                    Qresult(3) = String.Format("「{0}」，只能申請一次。", AwardZ)
                End If
            End If

            Sr.Close()
        Catch ex As Exception
            Wlog.WriteErrMsg("錯誤原因為-" + ex.Message.ToString())
        End Try

        Db.DBClose(Conn)
        Return Qresult
    End Function
    Private Function CkIsApplyOther() As List(Of String) '檢查年度內是否已經申請其他獎項
        Dim ApplyItem As String = String.Empty
        Dim ApplyName As String = String.Empty
        Dim Qresult As List(Of String) = New List(Of String)

        Dim CkApplyItem As String = String.Empty '20160523 Add By Sam Shen 判斷是否可以申請其他獎項，S4→Z1，S5→M1

        If Not ViewState("AppleMode") = Nothing Then
            If ViewState("AppleMode") = "0" Then
                ApplyItem = RdButton_Apply_Item_S.SelectedValue
                If ApplyItem = "S1" Or ApplyItem = "S2" Or ApplyItem = "S3" Or ApplyItem = "S4" Then
                    'chc 160801 只有高中以上才能申請電腦獎學金
                    If DpDownList_Awards.SelectedValue >= "3" Then
                        CkApplyItem = "'Z1','Z2'"
                    End If

                ElseIf ApplyItem = "S5" Then
                    CkApplyItem = "'S6'"
                Else
                    CkApplyItem = "'S5'"
                End If
            ElseIf ViewState("AppleMode") = "1" Then
                ApplyItem = RdButton_Apply_Item_Z.SelectedValue
                CkApplyItem = "'S1','S2','S3','S4'"
            ElseIf ViewState("AppleMode") = "2" Then
                ApplyItem = RdButton_Apply_Item_M.SelectedValue
                CkApplyItem = "'S5'"
            End If
        Else
            Return Qresult
        End If

        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()

        Dim Comm As SqlCommand

        '系統自動判斷是否申請其他獎項
        Dim CkSqlStr = "Select apply_no,apply_date From APPLY Where id_no='" + Txt_Id.Text.Trim() + "' And awards IN(" + CkApplyItem + ") And " + _
                 "YEAR(apply_date)='" + DateTime.Now.Year.ToString() + "'"

        If Conn Is Nothing Then
            Wlog.WriteErrMsg("錯誤原因為資料庫連接異常")
            Return Qresult
        End If

        Dim Sr As SqlDataReader

        Try

            Comm = New SqlCommand(CkSqlStr, Conn)
            Sr = Comm.ExecuteReader()

            If Sr.Read() Then
                Qresult.Add("n")
            Else
                Qresult.Add("y")
                Qresult.Add(ApplyItem)
            End If

            Sr.Close()
        Catch ex As Exception
            Wlog.WriteErrMsg("錯誤原因為-" + ex.Message.ToString())
        End Try

        Db.DBClose(Conn)
        Return Qresult
    End Function

    Private Function GetRecNo() As String '產生收件編號
        '收件編號(西元年+區域碼+流水號)
        '區域碼以連絡地址郵遞區號所屬區域中心編定
        Dim ApplyNo As String = String.Empty
        Dim GetNo As Integer
        Dim AreaNo As String = String.Empty  '區域代碼
        Dim Zip As String = String.Empty       '郵遞區號
        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()
        'TxtBox_RZip
        'Zip = TxtBox_Zid.Text.Trim()
        Zip = TxtBox_RZip.Text.Trim()


        '先取得區域代碼
        Dim SqlStr As String = "Select center_code From ZIP Where zip_code='" + Zip + "'"
        Dim Comm As SqlCommand = New SqlCommand(SqlStr, Conn)
        AreaNo = Comm.ExecuteScalar()

        ApplyNo = DateTime.Now.Year.ToString + AreaNo

        SqlStr = "Select apply_no From APPLY Where apply_no Like '" + ApplyNo + "%' Order By apply_no Desc"

        Comm = New SqlCommand(SqlStr, Conn)
        ApplyNo = Comm.ExecuteScalar()

        Db.DBClose(Conn)
        Comm.Dispose()

        If ApplyNo = String.Empty Then
            GetNo = 0
        Else
            If ApplyNo.Length = 9 Then
                ApplyNo = ApplyNo.Substring(5, 4)
                Try
                    GetNo = Convert.ToInt32(ApplyNo)
                Catch ex As Exception
                    GetNo = 0
                End Try
            Else
                GetNo = 0
            End If
        End If
        GetNo += 1

        If GetNo < 10 Then
            ApplyNo = DateTime.Now.Year.ToString() + AreaNo + "000" + GetNo.ToString()
            Return ApplyNo
        ElseIf GetNo < 100 Then
            ApplyNo = DateTime.Now.Year.ToString() + AreaNo + "00" + GetNo.ToString()
            Return ApplyNo
        ElseIf GetNo < 1000 Then
            ApplyNo = DateTime.Now.Year.ToString() + AreaNo + "0" + GetNo.ToString()
            Return ApplyNo
        ElseIf GetNo < 10000 Then
            ApplyNo = DateTime.Now.Year.ToString() + AreaNo + GetNo.ToString()
            Return ApplyNo
        Else
            Return String.Empty
        End If
    End Function

    Protected Sub BtnYes_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnYes_Confirm.Click '確認提出申請
        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()

        'CHC 0830 再判斷一次
        Dim CkHasApply As List(Of String) = New List(Of String)
        CkHasApply = CkIsApply()

        If CkHasApply.Count <> 0 Then '檢查年度內是否已經申請過
            '已經申請過該獎項
            'Session("BuildVerifyChart") = String.Empty   'tc 20160705
            '  Div_ShowChart.InnerHtml = "您已於" + CkHasApply(1) + "<br/>申請「" + CkHasApply(2) + "」獎項申請<BR />收件編號：" + CkHasApply(0) + "，請確認。<br/>"
            Div_ShowChart.InnerHtml = "您已於" + CkHasApply(1) + "<br/>申請「" + CkHasApply(2) + "」。<br/>收件編號：" + CkHasApply(0) + "，請確認。<br/>"
            'tc 20160714 多加不能申請原因說明
            Div_ShowChart.InnerHtml += CkHasApply(3)
            Mpe_Chart.Show()
            imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
            Return
        End If

        InserDataStr = ViewState("InserDataStr")
        CApplyNo = Session("CApplyNo")
        'tc 160825 多人同時申請，CApplyNo有可能重複
        'lock table
        '取出最大號
        Dim newApplyNo = GetRecNo()
        '最大號<>目前 CApplyNo，則替換CApplyNo=最大號
        If CApplyNo <> newApplyNo Then
            InserDataStr = Replace(InserDataStr, CApplyNo, newApplyNo)
            CApplyNo = newApplyNo
        End If
        Dim Comm As SqlCommand = New SqlCommand(InserDataStr, Conn)
        Session("CApplyNo") = CApplyNo
        'unlock table

        Try
            If Comm.ExecuteNonQuery() = 1 Then
                Dim SqlStr As String = "SELECT notify_date FROM SERVICE"
                Comm = New SqlCommand(SqlStr, Conn)
                Dim NotifyDate As String = Comm.ExecuteScalar()

                If NotifyDate <> String.Empty Then
                    NotifyDate = Convert.ToDateTime(NotifyDate).Date.ToString("yyyy/MM/dd")
                End If
                'tc 20160714 內網因志杰編號時, 有使用center 最後流水號
                SqlStr = "update center set apply_lastnum =" & CInt(CApplyNo.Substring(5)) & " where center_code='" & CApplyNo.Substring(4, 1) & "' "
                Comm = New SqlCommand(SqlStr, Conn)
                Comm.ExecuteNonQuery()
                'tc 0823 文字修改
                Div_ApplyOk.InnerHtml = "您的申請書已建檔完成，收件編號：" + CApplyNo + "。<BR />申請書檔案請務必儲存並列印，連同應備文件於<BR />截止日期" + NotifyDate + "前" + _
                                        "寄回本會以備審核。<BR />(以郵戳為憑，逾期則視同放棄)<BR >請按儲存申請書按鈕。"
                '   "以郵戳為憑，逾期則視同放棄)<BR >寄回本會以備審核。<BR />請按儲存申請書按鈕，不儲存請按結束按鈕。"
                MpeAppleOk.Show()
            Else

            End If
        Catch ex As Exception
            Wlog.WriteErrMsg("新增申請書時發生錯誤，錯誤原因為-" + ex.Message.ToString())
            Div_ShowMsg.InnerHtml = "新增申請書時發生錯誤，若有疑問，<BR />請洽本基金會。"
            Mpe_Msg.Show()
        End Try
        Db.DBClose(Conn)
        Comm.Dispose()
    End Sub
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)
    '    'MyBase.VerifyRenderingInServerForm(control)
    'End Sub

    Private Sub ExcSendMail()
        Dim ApplyItem As String = String.Empty     '申請獎項
        Dim ApplyTime As String = String.Empty     '申請次數
        Dim EmailAddress As String = String.Empty  '郵件地址
        Dim MailBody As String = String.Empty
        Dim GetSeviceDescription As String = String.Empty
        Dim SqlStr As String = String.Empty
        Dim ISqlStr As String = String.Empty
        Dim GetApplyTime As String = String.Empty
        Dim Smail As SendMail = New SendMail()

        ApplyItem = Session("AppleMode")
        ApplyTime = Session("RdButton_ApplyTime_Confirm")
        EmailAddress = Session("Lb_Email")

        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()
        Dim Comm As SqlCommand

        If ApplyTime = "1" Then '初次申請
            ISqlStr = "Select first_certificates From AWARD Where award_code='" + ApplyItem + "'"
        Else
            ISqlStr = "Select again_certificates From AWARD Where award_code='" + ApplyItem + "'"
        End If

        Try
            Comm = New SqlCommand(ISqlStr, Conn)
            GetApplyTime = Comm.ExecuteScalar() '取得應備文件代號

            If GetApplyTime = String.Empty Then
                Db.DBClose(Conn)
                Return
            End If

            Dim ATime As String()
            ATime = GetApplyTime.Split(",")
            ISqlStr = "Select certificate_name,description From CERTIFICATE Where certificate_code in('"

            For i As Integer = 0 To ATime.Count - 1
                ISqlStr = ISqlStr + ATime(i) + "','"
            Next
            ISqlStr = ISqlStr.Substring(0, ISqlStr.Length - 2) + ")"
            Dim Sr As SqlDataReader
            'Dim GConDescription As String = "<li>"
            Dim GConDescription As String = ""
            Comm = New SqlCommand(ISqlStr, Conn)
            Sr = Comm.ExecuteReader()

            While Sr.Read()
                'tc 160825 不加:
                'GConDescription = GConDescription + "&nbsp;&nbsp;&nbsp;&nbsp;●" + Sr(0) + "：" + Sr(1) + "<br>"
                GConDescription = GConDescription + "&nbsp;&nbsp;&nbsp;&nbsp;●" + Sr(0) + Sr(1) + "<br>"
            End While

            '   GConDescription = GConDescription.Substring(0, GConDescription.Length - 4) '取得應備文件的設定值
            Sr.Close()

            SqlStr = "Select nonservice_explain From SERVICE"
            Comm = New SqlCommand(SqlStr, Conn)
            GetSeviceDescription = Comm.ExecuteScalar() '取得應備文件所設定的說明內容

            MailBody = "<span><strong>獎助學金線上申請</strong></span><span >收件通知</span></p>"
            MailBody += "<table width=""1015"" border=""1"">"
            MailBody += "<tr>"
            MailBody += "<td width=""1005"" height=""361"" align=""left"" valign=""top""><p >●<span >您的線上申請書已收到， 收件編號：<span>" + Session("CApplyNo") + "</span><strong>(請記錄，以便於查詢申請進度)</strong></span></p>"
            MailBody += "<p>●請準備下列書面證明文件：</p>"
            MailBody += "<ul>"
            MailBody += GConDescription
            MailBody += "</ul>"
            MailBody += GetSeviceDescription
            MailBody += "</td></tr></table>"
            'tc 20160705 test 'todo
            Smail.SendMail(EmailAddress, MailBody, DefineAll.PDF_PRE_NAME + Session("CApplyNo"))
            Comm.Dispose()
            Div_SendMail.InnerHtml = MailBody
            MpeSendMail.Show()
        Catch ex As Exception
            Wlog.WriteErrMsg("取得發信內容設定值發生錯誤，錯誤原因為-" + ex.Message.ToString())
        End Try
        Db.DBClose(Conn)
    End Sub

    Protected Sub Btn_Apply_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Apply_Save.Click
        ExcSendMail()
    End Sub

    'Protected Sub Btn_Apply_End_E_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Apply_End_E.Click
    '    ExcSendMail()
    'End Sub

    Protected Sub Btn_CkApply_Item_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_CkApply_Item.Click
        'tc 20160714 暫不自動提示
        Exit Sub

        Dim CkResult As List(Of String) = CkIsApplyOther()
        Dim CkApplyItem As String = String.Empty

        If CkResult.Count = 1 Then '代表已經有申請過其他項目
            Div_CkApply_Other.InnerHtml = "經系統檢查，已無其他獎項可申請。"
            'Btn_CkApplyOther_Ok.Enabled = False
            Btn_CkApplyOther_Ok.Visible = False 'tc 20160621
            MpeCkApplyOther.Show()
        Else                       '代表還可以申請其他項目
            If CkResult(1) = "S1" Or CkResult(1) = "S2" Or CkResult(1) = "S3" Or CkResult(1) = "S4" Then
                Div_CkApply_Other.InnerHtml = "經系統檢查，您可申請仁寶電腦所提供獎項。<BR />繼續申請請按<繼續申請其他獎項>，否則請按<結束>。"
                Btn_CkApplyOther_Ok.Enabled = True
                ViewState("CkApplyOther") = "Z1"
                MpeCkApplyOther.Show()
            ElseIf CkResult(1) = "S5" Then
                'tc 20160714 
                'Div_CkApply_Other.InnerHtml = "經系統檢查，您可申請明閱科技所提供獎項。<BR />繼續申請請按<繼續申請其他獎項>，否則請按<結束>。"
                Div_CkApply_Other.InnerHtml = "經系統檢查，您可申請明閱科技-陽光子女特殊才藝獎學金。<BR />繼續申請請按<繼續申請其他獎項>，否則請按<結束>。"
                Btn_CkApplyOther_Ok.Enabled = True
                'ViewState("CkApplyOther") = "M1"
                ViewState("CkApplyOther") = "S6"   'tc 20160714
                MpeCkApplyOther.Show()
            ElseIf CkResult(1) = "Z1" Or CkResult(1) = "Z2" Then
                Div_CkApply_Other.InnerHtml = "經系統檢查，您可申請陽光基金會所提供獎項。<BR />繼續申請請按<繼續申請其他獎項>，否則請按<結束>。"
                ViewState("CkApplyOther") = "S4"
                Btn_CkApplyOther_Ok.Enabled = True
                MpeCkApplyOther.Show()
            ElseIf CkResult(1) = "S6" Then
                Div_CkApply_Other.InnerHtml = "經系統檢查，您可申請陽光子女助學金獎項。<BR />繼續申請請按<繼續申請其他獎項>，否則請按<結束>。"
                ViewState("CkApplyOther") = "S5"
                Btn_CkApplyOther_Ok.Enabled = True
                MpeCkApplyOther.Show()
            End If
        End If
    End Sub

    Protected Sub Btn_CkApplyOther_Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_CkApplyOther_Ok.Click
        If ViewState("CkApplyOther") = "S4" Or ViewState("CkApplyOther") = "S5" Then
            Page.Title = "獎助學金線上申請作業-陽光"
            Lb_Apply_cate.Text = "陽光獎助學金線上申請作業"
            ViewState("AppleMode") = "0"
        ElseIf ViewState("CkApplyOther") = "Z1" Then
            Page.Title = "獎助學金線上申請作業-仁寶"
            'tc 0823 文字修改
            'Lb_Apply_cate.Text = "仁寶電腦獎助學金線上申請作業"
            Lb_Apply_cate.Text = AwardZ
            ViewState("AppleMode") = "1"
        ElseIf ViewState("CkApplyOther") = "M1" Then
            Page.Title = "獎助學金線上申請作業-明閱"
            Lb_Apply_cate.Text = "明閱科技陽光獎助學金線上申請作業"
            ViewState("AppleMode") = "2"
        End If
        'tc 20160705 申請書種類記錄
        Btn_Apply_Save.OnClientClick = String.Format("NewWindow('{0}')", ViewState("AppleMode"))

        InitCtr("A")
        InitDropdownlist()

        Txt_Name.Text = Session("Lb_Name_Confirm") '姓名
        Txt_OldName.Text = Session("Lb_OldName_Confirm") '2017/9/4 gin 改名前之姓名
        Txt_Id.Text = Session("Lb_Id_Confirm") '身分證號碼
        DpDownList_Year.SelectedValue = Session("Lb_Birthday_Y") '出生年月日的年
        DpDownList_Month.SelectedValue = Session("Lb_Birthday_M") '出生年月日的月
        DpDownList_Day.SelectedValue = Session("Lb_Birthday_D") '出生年月日的日

        TxtBox_Zid.Text = Session("Lb_Zid_Name") '聯絡地址郵遞區號
        TxtBox_Address.Text = Session("Lb_Address") '聯絡地址

        TxtBox_RZip.Text = Session("Lb_RZid_Name") '戶籍地址郵遞區號
        TxtBox_RAddress.Text = Session("Lb_RAddress") '戶籍聯絡地址

        TxtBox_Tel_1.Text = Session("Lb_Tel_D") '電話(日)
        TxtBox_Tel_2.Text = Session("Lb_Tel_N") '電話(夜)

        TxtBox_Mobile.Text = Session("Lb_Mobile_Confirm") '手機

        TxtBox_Email.Text = Session("Lb_Email") '電子信箱
        TxtBox_School.Text = Session("Lb_School") '學校名稱

        TxtBox_Dep.Text = Session("Lb_Dep") '科系名稱
        TxtBox_Grage.Text = Session("Lb_Grade_Confirm") '年級


        DpDownList_Awards.SelectedValue = Session("DpDownList_Awards_Confirm") '申請組別

        RdButton_Sex.SelectedValue = Session("RdButton_Sex_Confirm") '性別

        RdButton_Damage.SelectedValue = Session("RdButton_Damage_Confirm") '確認申請資料的損傷類別

        RdButton_ApplyTimes.SelectedValue = Session("RdButton_ApplyTime_Confirm") '申請次數

        TxtBox_Account_Name.Text = Session("Lb_Account_Name") '戶名
        TxtBox_Bank.Text = Session("Lb_Bank_No") '銀行代號
        TxtBox_Account_No.Text = Session("Lb_Account") ''匯款帳號

        If Session("RdButton_Mode_Confirm") = "2" Then
            TxtBox_Recommend.Text = Session("Lb_recommend")
            TxtBox_Rec_Name.Text = Session("Lb_Rec_Name")
            TxtBox_Rec_Position.Text = Session("Lb_Rec_Position")
            TxtBox_Rec_Tel.Text = Session("Lb_Rec_Tel")
        Else
            TxtBox_Recommend.Text = String.Empty
            TxtBox_Rec_Name.Text = String.Empty
            TxtBox_Rec_Position.Text = String.Empty
            TxtBox_Rec_Tel.Text = String.Empty
        End If
        RdButton_Mode.SelectedValue = Session("RdButton_Mode_Confirm")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        test_data()
        test_data2()
    End Sub

    Protected Sub btn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn2.Click
        test_data()
        test_data2()
        RdButton_Apply_Item_Z.SelectedValue = "Z1"
    End Sub

    Protected Sub btn3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn3.Click
        test_data()
        test_data2()
        RdButton_Apply_Item_S.SelectedValue = "S6"
        TxtBox_PName.Text = "蔡爸爸"
        RdButton_Parents.SelectedValue = "1"
    End Sub

    Protected Sub btnChangeCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeCode.Click
        imgCode.ImageUrl = "BuildVerifyChart.aspx?" + Now.ToString
    End Sub

    Protected Sub lblMyLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMyLink.Click
        If TxtBox_VerifyCode.Text = "abba" Then
            btn1.Visible = True
            btn2.Visible = True
            btn3.Visible = True
        End If
    End Sub
    Public Function Trauma_Old(ByVal id As String, ByVal year As Integer) As String
        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()
        Dim dt As DataTable
        Dim str As String = "select (year(apply_date)-1911) year,trauma_type,b.trauma_name,trauma_remark  from apply a left join trauma b on a.trauma_type =b.trauma_code "
        str += " where id_no='" & id & "' and year(apply_date ) in (" & year - 1 & "," & year - 2 & ") "
        str += " order by apply_date "
        dt = Db.SqlReader(str, Conn)

        Dim apply_Year = ""
        Dim trauma_type = ""
        Dim trauma_name = ""
        Dim trauma_remark = ""
        For Each row As DataRow In dt.Rows
            apply_Year = row.Item("year")
            trauma_type = row.Item("trauma_type")
            trauma_name = row.Item("trauma_name")
            trauma_remark = row.Item("trauma_remark")
        Next
        Dim remark As String = ""
        If dt.Rows.Count <> 0 Then
            remark = "備註:" & apply_Year & "年申請損傷類別:" & trauma_name
            If trauma_type = "F6" Then '如果選項是其他,就加顯示其他的內容
                remark += ":" & trauma_remark & "。"
            End If
        End If
        Db.DBClose(Conn)
        Return remark
    End Function
End Class
