Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Web.Configuration.WebConfigurationManager
Imports System.Net.Configuration
Imports System.Web
Imports System.IO
Imports System.Web.Configuration

Public Class MsgResult
    Public MsgID As String = ""
    Public StatusCode As String = "99"
    Public AccountPoint As String = ""
    Public MsgError As String = ""
End Class

Public Class SmsHelper
    Private Shared _Smtp As SmtpClient
    Private Shared MSG_USER As String = WebConfigurationManager.AppSettings("MSG_USER")
    Private Shared MSG_PWD As String = WebConfigurationManager.AppSettings("MSG_PWD")
    Private Shared SEND_MSG As String = WebConfigurationManager.AppSettings("SEND_MSG")

    Public Shared ReadOnly Property Smtp() As SmtpClient
        Get
            If IsNothing(_Smtp) Then
                _Smtp = New SmtpClient()
                _Smtp.EnableSsl = True
            End If
            Return _Smtp
        End Get
    End Property

    'Private Shared Function GenerateMessage(ByVal notify As NotifyViewModel) As MailMessage
    '    Dim result As New MailMessage
    '    'result.Sender =  
    '    result.Subject = ""
    '    result.Body = notify.Message
    '    result.To.Add(notify.Receiver)

    '    Return result
    'End Function

    Public Shared Sub Send(ByVal notify As NotifyViewModel)
        Dim m As String = GenerateMessage(notify)
        Try

            Dim result As MsgResult = GetResponseResult(m)

            If (result.MsgError <> "") Then
                Throw New Exception(result.MsgError)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Shared Function GetResponseResult(ByVal URL As String) As MsgResult
        Dim responseData As String = ""
        Dim responseResult As MsgResult = Nothing
        Dim line As String = ""
        Dim response As Net.HttpWebResponse
        Dim request As Net.HttpWebRequest

        Try

            request = Net.WebRequest.Create(URL)
            response = request.GetResponse()
            If response.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = _
                  New IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.Default)
                'responseData = responseStream.ReadToEnd()
                '回傳字串轉換成物件
                responseResult = ConvertResult(responseStream)
            End If
            response.Close()
        Catch e As Exception
            responseData = "An error occurred: " & e.Message
        End Try
        Return responseResult
    End Function

    Private Shared Function ConvertResult(ByVal responseStream As StreamReader) As MsgResult
        Dim result As New MsgResult
        Dim line As String = ""
        Dim nameValue As String()

        'While (line = responseStream.ReadLine())
        While (Not responseStream.EndOfStream)
            line = responseStream.ReadLine()
            '序號行不處理
            If (line.StartsWith("[")) Then Continue While
            nameValue = line.Split("=")

            If (Not nameValue.Length = 2) Then
                Throw New Exception("回傳格式錯誤!" + responseStream.ReadToEnd())
            End If

            Select Case nameValue(0).Trim()
                Case "msgid"
                    result.MsgID = nameValue(1).Trim()
                Case "statuscode"
                    result.StatusCode = nameValue(1).Trim()
                Case "AccountPoint"
                    result.AccountPoint = nameValue(1).Trim()
                Case "Error"
                    result.MsgError = nameValue(1).Trim()
            End Select
        End While

        Return result
    End Function


#Region "產生簡訊網址"

    '產生簡訊網址
    Private Shared Function GenerateMessage(ByVal info As NotifyViewModel) As String
        Dim sb As New StringBuilder
        'sb.Append("http://smexpress.mitake.com.tw:9600/SmSendGet.asp?username=Test001")
        'sb.Append("&password=TestPwd&dstaddr=09001234567&DestName= 王先生")
        'sb.Append("&dlvtime=20060811093000&vldtime=20060812093000&smbody=%C2%B2 主BOT%B4%FA%B")
        'sb.Append("8%D5&response=http://192.168.1.200/smreply.asp")

        sb.Append("http://smexpress.mitake.com.tw:9600/SmSendGet.asp?")
        sb.AppendFormat("username={0}", MSG_USER)
        sb.AppendFormat("&password={0}", MSG_PWD)

        sb.AppendFormat("&dstaddr={0}", info.Receiver)     
        sb.AppendFormat("&DestName={0}", "")
        sb.AppendFormat("&dlvtime={0:yyyyMMddHHmmss}", DateTime.Now)
        sb.AppendFormat("&vldtime={0:yyyyMMddHHmmss}", DateTime.Now.AddMinutes(24))
        sb.AppendFormat("&smbody={0}", HttpUtility.UrlEncode(info.Message))
        'sb.AppendFormat("&smbody={0}", info.MSMBody)
        sb.AppendFormat("&response={0}", "")
        sb.AppendFormat("&encoding={0}", "UTF8")
        System.Diagnostics.Debug.Write(sb.ToString())

        Return sb.ToString()
    End Function
#End Region
End Class
