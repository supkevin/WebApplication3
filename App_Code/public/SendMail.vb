Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System
'Imports System.Web.HttpContext

Public Class SendMail

    Public Sub SendMail(ByRef Mailto As String, ByVal MailBody As String, ByVal AttFile As String)
        Dim Db As GDataBase = New GDataBase()
        Dim Wlog As WriteLog = New WriteLog()
        Dim MailHost As String = String.Empty
        Dim SqlStr As String = "Select sendmail_host From SERVICE"
        Dim Conn As SqlConnection = Db.DBConnection()
        Dim MailArg As MailMessage = New MailMessage()
        Dim SendMail As SmtpClient = New SmtpClient()
        Dim MailFrom As String = String.Empty
        Dim Uid As String = String.Empty
        Dim Pwd As String = String.Empty

        If Conn Is Nothing Then
            Wlog.WriteErrMsg("取得資料庫連線發生錯誤")
            Return
        End If

        Dim Comm As SqlCommand
        Dim Sr As SqlDataReader
        SqlStr = "Select sendmail_host,sendmail_from,mail_uid,mail_password From SERVICE"
        Comm = New SqlCommand(SqlStr, Conn)
        Try
            Sr = Comm.ExecuteReader()
            If Sr.Read() Then
                MailHost = Sr(0)
                MailFrom = Sr(1)
                If Sr(2) <> Nothing And Sr(3) <> Nothing Then
                    Uid = Sr(2)
                    Pwd = Sr(3)
                End If
            End If

            MailArg.To.Add(Mailto)       '收件者
            'tc 0823 改名稱
            'MailArg.From = New MailAddress(MailFrom) '發信者
            MailArg.From = New MailAddress(MailFrom, "陽光基金會", System.Text.Encoding.UTF8) '發信者

            MailArg.Subject = "陽光基金會-獎助學金線上申請收件通知"                     '主旨
            MailArg.Body = MailBody                  '郵件內容
            MailArg.IsBodyHtml = True
            SendMail.Host = MailHost                 '郵件主機
            'tc 0823 測試用hotmail用587，其他用25
            If MailHost = "smtp.live.com" Or MailHost = "smtp.gmail.com" Then
                SendMail.Port = 587              '使用gmail發信,一般是25
                SendMail.Credentials = New System.Net.NetworkCredential(Uid, Pwd) '使用gmail發信
                SendMail.EnableSsl = True  '使用gmail發信
            Else
                SendMail.Port = 25    '基金會使用
                SendMail.Credentials = New System.Net.NetworkCredential(Uid, Pwd) '使用gmail發信
                SendMail.EnableSsl = False
            End If

            'SendMail.Timeout = 1000
            'SendMail.DeliveryMethod = SmtpDeliveryMethod.Network
            'SendMail.ServicePoint.MaxIdleTime = 1000

            'tc 20160621 檢查PDF是否已經產生完成了
            Dim t = 0
            Dim PDF_FLAG = True
            Do Until myPDF.PDF_Exist(AttFile)
                t = t + 1
                'System.Threading.Thread.Sleep(3000) '等待3秒
                System.Threading.Thread.Sleep(8000) '2017/9/11 gin 因偶爾會發生PDF無法產生,所以增加秒數
                '超過5次就取消
                If t > 5 Then
                    '記錄無附件
                    MailArg.Body += "<P>附件無法產生</P>"
                    PDF_FLAG = False
                    Exit Do
                End If
            Loop

            'tc 20160621 附上PDF檔案
            If PDF_FLAG Then
                Dim FullFileName As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + AttFile + ".pdf"
                Dim data As New Attachment(FullFileName)
                MailArg.Attachments.Add(data)
            End If

            SendMail.Send(MailArg)
            MailArg.Dispose()

            'tc 20160621 記錄email已寄出
            myPDF.CreateFile(AttFile + ".e")

            'tc 20160621 將PDF刪除
            myPDF.Delete(AttFile)

        Catch ex As Exception
            Wlog.WriteErrMsg("執行Email發送時發生錯誤，原因為：" + ex.Message().ToString())
        End Try

        Db.DBClose(Conn)
        Comm.Dispose()

    End Sub
End Class
