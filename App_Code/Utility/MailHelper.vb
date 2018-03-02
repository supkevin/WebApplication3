Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Web.Configuration.WebConfigurationManager
Imports System.Net.Configuration

Public Class MailHelper
    Private Shared _Smtp As SmtpClient    
    Private Shared _SUBJECT As String = "財團法人陽光社會福利基金會獎助學金申請案補件通知"    
    Private Shared _SENDER As MailAddress

    Public Shared ReadOnly Property Sender() As MailAddress
        Get
            If IsNothing(_SENDER) Then
                Dim config As Configuration = OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath)
                Dim settings As MailSettingsSectionGroup = _
                    CType(config.GetSectionGroup("system.net/mailSettings"), MailSettingsSectionGroup)
                _SENDER = New MailAddress(settings.Smtp.Network.UserName, "administrator")
            End If
            Return _SENDER
        End Get
    End Property

    Public Shared ReadOnly Property Smtp() As SmtpClient     
        Get
            If IsNothing(_Smtp) Then
                _Smtp = New SmtpClient()
                _Smtp.EnableSsl = True
            End If
            Return _Smtp
        End Get
    End Property

    Private Shared Function GenerateMessage(ByVal notify As NotifyViewModel) As MailMessage
        Dim result As New MailMessage
        result.From = Sender        
        result.Subject = _SUBJECT
        result.Body = notify.Message
        result.To.Add(notify.Receiver)

        Return result
    End Function
    Public Shared Sub Send(ByVal notify As NotifyViewModel)
        Dim m As MailMessage = GenerateMessage(notify)
        Try

            Smtp.Send(m)
        Catch ex As Exception
            Throw
        End Try
    End Sub   
End Class
