Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Image
Imports System.Web

Partial Class Pages_BuildVerifyChart
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim Bmp As Bitmap = New Bitmap(100, 30)
        Dim Graps As Graphics = Graphics.FromImage(Bmp)

        Graps.Clear(Color.White)
        Graps.TextRenderingHint = TextRenderingHint.AntiAlias

        Dim Fnt As Font = New Font("Courier New", 20, FontStyle.Bold)

        Dim Rdm As Random = New Random()
        Dim Number As Integer
        Dim ChkCode As String = String.Empty
        Dim Code As Char
        Dim ChkNumCount As Integer = 0

        For i As Integer = 0 To 50
            Number = Rdm.Next

            'tc 20160621 取消 Mod 2，避免有可能無法產生5個數字。
            'If Number Mod 2 = 0 Then '數字
            Code = CChar(ChrW(Asc("0") + (Number Mod 10)))
            ChkCode += Code.ToString()
            ChkNumCount += 1
            'Else                     '字母
            'Code = CChar(ChrW(Asc("A") + (Number Mod 26)))
            'End If

            If ChkNumCount = 5 Then '設定五個字
                Exit For
            End If
        Next

        '背景噪音點
        For k As Integer = 0 To 10
            Dim x1 As Integer = Rdm.[Next](Bmp.Width)
            Dim x2 As Integer = Rdm.[Next](Bmp.Width)
            Dim y1 As Integer = Rdm.[Next](Bmp.Height)
            Dim y2 As Integer = Rdm.[Next](Bmp.Height)
            Graps.DrawLine(New Pen(Color.Blue), x1, y1, x2, y2)
        Next

        '前景噪音點
        For j As Integer = 0 To 100
            Dim x As Integer = Rdm.[Next](Bmp.Width)
            Dim y As Integer = Rdm.[Next](Bmp.Height)
            Bmp.SetPixel(x, y, Color.FromArgb(Rdm.Next))
        Next

        Session("BuildVerifyChart") = ChkCode

        Graps.DrawString(ChkCode, Fnt, Brushes.Black, 2, 2)

        Graps.DrawRectangle(New Pen(Color.Black), 0, 0, Bmp.Width - 1, Bmp.Height - 1)
        Response.ContentType = "image/gif"
        Bmp.Save(Response.OutputStream, Imaging.ImageFormat.Gif)

        Fnt.Dispose()
        Graps.Dispose()
        Bmp.Dispose()

        'Response.End()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page_Init(sender, e)
    End Sub
End Class
