Imports System.Data.SqlClient
Partial Class Pages_Apply_inquiry
    Inherits System.Web.UI.Page
    Dim Wlog As WriteLog = New WriteLog()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitCn()
        End If
    End Sub
    Private Sub InitCn()
        Txt_ApplyNo.Text = String.Empty
        Txt_No.Text = String.Empty
        TxtBox_VerifyCode.Text = String.Empty
    End Sub

    Private Function CheckRequire() As Boolean
        Dim ErrMsg As String = ""
        Dim ErrMsgTitle As String = "下列欄位資料不可空白，請修改。<br />"

        If Txt_ApplyNo.Text.Trim() = String.Empty Then
            ErrMsg += "收件編號，不可空白。<Br />"
        End If
        If Txt_No.Text.Trim() = String.Empty Then
            ErrMsg += "身分證號後五碼，不可空白。<Br />"
        End If

        If ErrMsg <> "" Then
            Div_ShowMsg.InnerHtml = ErrMsgTitle + ErrMsg
            Mpe_Msg.Show()
            Return False
        End If

        Return True

    End Function

    Private Function CheckData() As Boolean
        Dim result As Boolean = False

        If TxtBox_VerifyCode.Text.Trim() = String.Empty Then
            Div_ShowMsg.InnerHtml = "請填寫圖形認證碼"
            Mpe_Msg.Show()
            Return False
        End If

        If TxtBox_VerifyCode.Text.Trim() <> Session("BuildVerifyChart") Then
            TxtBox_VerifyCode.Text = String.Empty
            Div_ShowMsg.InnerHtml = "認證碼錯誤！請重新產生並填寫圖形認證碼"
            Mpe_Msg.Show()
            'tc 160822 重新產生認證碼
            vimg.Src = "BuildVerifyChart.aspx?" + Now.ToString
            Return False
        End If

        Return True
    End Function

    Protected Sub Btn_Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Ok.Click
        'System.Threading.Thread.Sleep(1000)
        If (CheckRequire() <> True) Then Return
        If (CheckData() <> True) Then Return

        Dim CkStr As CkString = New CkString()
        Dim Db As New GDataBase
        Dim Conn As SqlConnection = Db.DBConnection()
        Dim SqlStr As String
        Dim Dr As SqlDataReader

        Dim ApplyName As String = String.Empty
        Dim ApplyItem As String = String.Empty
        Dim ProcessEm As String = String.Empty '進度說明文字
        Dim IdNo As String = String.Empty
        Dim Status As String = String.Empty

        Dim Comm As SqlCommand = Nothing

        If Conn Is Nothing Then
            'Sh.ShowMsg(Btn_Login, "資料庫連接異常，請洽系統管理員")
            Return
        End If

        Try
            SqlStr = "Select process_explain From SERVICE"
            Comm = New SqlCommand(SqlStr, Conn)
            ProcessEm = Comm.ExecuteScalar()

            Dim template As String = _
                    "Select name,award_name,id_no,status_content" _
                 + " From APPLY " _
                 + " LEFT JOIN AWARD ON Apply.awards = AWard.award_code" _
                 + " LEFT JOIN PROGRESS ON APPLY.status_code = PROGRESS.status_code" _
                 + " WHERE apply_no='{0}'"

            SqlStr = String.Format(template, CkStr.CkChar(Txt_ApplyNo.Text.Trim()).ToUpper())

            Dr = Db.DataReader(SqlStr, Conn)

            If Dr.Read() Then
                ApplyName = Dr("name").ToString()
                ApplyItem = Dr("award_name").ToString()
                IdNo = Dr("id_no").ToString()
                Status = Dr("status_content").ToString()

                If IdNo.Trim() <> String.Empty And IdNo.Length = 10 Then
                    If IdNo.Substring(5, 5) = Txt_No.Text.Trim() Then
                        Lb_Name.Text = ApplyName
                        Lb_Award.Text = ApplyItem
                        Lb_Process.Text = Status
                        Lb_Description.Text = ProcessEm
                        MpeQuiryOk.Show()
                        InitCn()
                    Else
                        Div_ShowMsg.InnerHtml = "身分證號後五碼錯誤，請重新輸入。"
                        Mpe_Msg.Show()
                        InitCn()
                    End If
                Else
                    Div_ShowMsg.InnerHtml = "身分證號後五碼錯誤，請重新輸入。"
                    Mpe_Msg.Show()
                    InitCn()
                End If
            Else
                Div_ShowMsg.InnerHtml = "查無資料，請確認資料是否正確後再請重新輸入。"
                Mpe_Msg.Show()
                InitCn()
            End If  'If Dr.Read() Then
        Catch ex As Exception
            Wlog.WriteErrMsg("查詢處理說明的資料發生錯誤，原因為：" + ex.Message().ToString())
            Div_ShowMsg.InnerHtml = "查詢資料發生錯誤，請稍後再查。"
            Mpe_Msg.Show()
            InitCn()
        Finally
            Db.DBClose(Conn)
            Comm.Dispose()
        End Try
        'tc 160822 認證碼重新產生
        vimg.Src = "BuildVerifyChart.aspx?" + Now.ToString
    End Sub

#Region "old version"
    'Protected Sub Btn_Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Ok.Click
    '    Dim CkStr As CkString = New CkString()
    '    If TxtBox_VerifyCode.Text.Trim() = String.Empty Then
    '        Div_ShowMsg.InnerHtml = "請填寫圖形認證碼"
    '        Mpe_Msg.Show()
    '    Else
    '        If TxtBox_VerifyCode.Text.Trim() = Session("BuildVerifyChart") Then
    '            Dim ErrMsgTitle As String = "下列欄位資料不可空白，請修改。<br />"
    '            Dim ErrMsg As String = String.Empty
    '            Dim Db As New GDataBase
    '            Dim Conn As SqlConnection = Db.DBConnection()
    '            Dim SqlStr As String
    '            Dim Dr As SqlDataReader

    '            Dim ApplyName As String = String.Empty
    '            Dim ApplyItem As String = String.Empty
    '            Dim ProcessEm As String = String.Empty '進度說明文字
    '            Dim IdNo As String = String.Empty
    '            Dim Status As String = String.Empty

    '            Dim Comm As SqlCommand

    '            If Txt_ApplyNo.Text.Trim() = String.Empty Then
    '                ErrMsg += "收件編號，不可空白。<Br />"
    '            End If
    '            If Txt_No.Text.Trim() = String.Empty Then
    '                ErrMsg += "身分證號後五碼，不可空白。<Br />"
    '            End If

    '            If Conn Is Nothing Then
    '                'Sh.ShowMsg(Btn_Login, "資料庫連接異常，請洽系統管理員")
    '                Return
    '            End If

    '            If ErrMsg = String.Empty Then
    '                Try
    '                    SqlStr = "Select process_explain From SERVICE"
    '                    Comm = New SqlCommand(SqlStr, Conn)
    '                    ProcessEm = Comm.ExecuteScalar()

    '                    SqlStr = "Select name,award_name,id_no,status_content From APPLY,AWARD,PROGRESS " _
    '                            + " Where Apply.awards=AWard.award_code And APPLY.status_code=PROGRESS.status_code " _
    '                            + " And apply_no='" + CkStr.CkChar(Txt_ApplyNo.Text.Trim()).ToUpper() + "'"

    '                    Dr = Db.DataReader(SqlStr, Conn)
    '                    If Dr.Read() Then
    '                        ApplyName = Dr(0).ToString()
    '                        ApplyItem = Dr(1).ToString()
    '                        IdNo = Dr(2).ToString()
    '                        Status = Dr(3).ToString()

    '                        Db.DBClose(Conn)
    '                        Comm.Dispose()

    '                        If IdNo.Trim() <> String.Empty And IdNo.Length = 10 Then
    '                            If IdNo.Substring(5, 5) = Txt_No.Text.Trim() Then
    '                                Lb_Name.Text = ApplyName
    '                                Lb_Award.Text = ApplyItem
    '                                Lb_Process.Text = Status
    '                                Lb_Description.Text = ProcessEm
    '                                MpeQuiryOk.Show()
    '                                InitCn()
    '                            Else
    '                                Div_ShowMsg.InnerHtml = "身分證號後五碼錯誤，請重新輸入。"
    '                                Mpe_Msg.Show()
    '                                InitCn()
    '                            End If
    '                        Else
    '                            Div_ShowMsg.InnerHtml = "身分證號後五碼錯誤，請重新輸入。"
    '                            Mpe_Msg.Show()
    '                            InitCn()
    '                        End If
    '                    Else
    '                        Div_ShowMsg.InnerHtml = "查無資料，請確認資料是否正確後再請重新輸入。"
    '                        Mpe_Msg.Show()
    '                        InitCn()
    '                    End If

    '                Catch ex As Exception
    '                    Wlog.WriteErrMsg("查詢處理說明的資料發生錯誤，原因為：" + ex.Message().ToString())
    '                    Div_ShowMsg.InnerHtml = "查詢資料發生錯誤，請稍後再查。"
    '                    Mpe_Msg.Show()
    '                    InitCn()
    '                End Try
    '            Else
    '                'Session("BuildVerifyChart") = String.Empty 'tc 20160705 不取消
    '                Div_ShowMsg.InnerHtml = ErrMsgTitle + ErrMsg
    '                Mpe_Msg.Show()
    '            End If
    '        Else '認證碼錯誤
    '            'Session("BuildVerifyChart") = String.Empty     'tc 20160705 不取消
    '            TxtBox_VerifyCode.Text = String.Empty
    '            Div_ShowMsg.InnerHtml = "認證碼錯誤！請重新產生並填寫圖形認證碼"
    '            Mpe_Msg.Show()
    '        End If
    '    End If
    'End Sub
#End Region

End Class
