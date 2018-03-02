Imports Microsoft.VisualBasic
Imports System

Public Class WriteLog
    Sub WriteErrMsg(ByVal ErrMsg As String)
        Dim FileName As String = String.Empty
        Dim DirName As String = String.Empty

        DirName = System.Web.HttpContext.Current.Server.MapPath("~")
        If Right(DirName, 1) <> "\" Then
            DirName += "\"
        End If

        FileName = DirName & Now.Date.ToString("yyyyMM") & "_ErrMsg.txt"

        'ErrMsg = Now.Date.ToString("yyyy/MM/dd HH:mm:ss") & " Error Message : " & ErrMsg
        ErrMsg = String.Format("{0:yyyy/MM/dd HH:mm:ss} Error Message:{1}", Now, ErrMsg)    'tc 160825 顯示時分

        Dim Sw As System.IO.StreamWriter

        Try
            Sw = New System.IO.StreamWriter(FileName, True)
            Sw.WriteLine(ErrMsg)
            Sw.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
