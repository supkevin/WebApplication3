Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports System.Web
Imports System.Net

'Partial Class Pages_Apply_Save
Public Class Pages_Apply_Save
    Inherits System.Web.UI.Page
    Public SaveFlag As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''tc 20160621 test
        'test_data()
        'Exit Sub

        If Not IsPostBack Then
            If Not Request.QueryString("m") = Nothing Then '要判斷申請者是申請哪種獎項
                ViewState("AppleMode") = Request.QueryString("m").ToString()

                If Session("Request_UrlReferrer") = True Then '判斷是否從apply_sheet.aspx導頁過來
                    Session("Request_UrlReferrer") = False
                    SaveFlag = True 'tc 20160621
                    InitC()
                Else
                    Response.Redirect("~/default.aspx")
                End If
            Else
                Response.Redirect("~/default.aspx")
            End If
        End If
    End Sub

    Private Sub InitC()
        Select Case ViewState("AppleMode")
            Case "0"
                'lblStatus.Text = "陽光申請表尚未確認。"
                rpt21.SetValues()
                rpt21.Visible = True
            Case "1"
                rpt11.SetValues()
                rpt11.Visible = True
            Case "2"
                lblStatus.Text = "明閱申請表尚未確認。"
                rpt11.Visible = False
            Case Else   '無法取得正確值
                SaveFlag = False
                Response.Write("錯誤網址內容")
        End Select
    End Sub

    Private Function GetUrl(ByVal ReqUrl As String) As String '取得Url
        If ReqUrl = String.Empty Then
            Return String.Empty
        End If

        Dim Result As String
        Dim Scount As Integer

        Scount = ReqUrl.LastIndexOf("/")
        Result = ReqUrl.Substring(Scount + 1, 16)
        Return Result
    End Function

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        Me.EnableViewState = False
        Dim sText As String = ""
        Dim oStringWriter As New StringWriter()
        Dim oHtmlWriter As New HtmlTextWriter(oStringWriter)
        MyBase.Render(oHtmlWriter)
        oHtmlWriter.Flush()
        oHtmlWriter.Close()
        sText = oStringWriter.ToString
        'tc 20160621 可下載
        If SaveFlag = True Then
            Dim myPDF As New PDF
            '  myPDF.Save(sText, Session("CApplyNo"))    'tc 20160621
            myPDF.Save(sText, DefineAll.PDF_PRE_NAME + Session("CApplyNo"))    'tc 20160621
            myPDF = Nothing
            DownloadPDF()
        End If
        'Response.Write(sText)
    End Sub

    Private Sub DownloadPDF()
        'tc 20160621
        'Dim FileName As String = Session("CApplyNo") + ".doc"
        Dim FileName As String = DefineAll.PDF_PRE_NAME + Session("CApplyNo") + ".pdf"
        Dim FullFileName As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + DefineAll.PDF_PRE_NAME + Session("CApplyNo") + ".pdf"
        Response.Write("<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />")
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
        'tc 20160621
        'Response.ContentType = "application/msword"
        Response.ContentType = "application/pdf"
        Response.Charset = "utf-8"
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName)

        ' 將檔案輸出
        '下載PDF檔案
        Response.WriteFile(FullFileName)
        '// 強制 Flush buffer 內容
        Response.Flush()

        'PDF下載完成後，另外產生 .d 檔做記錄。
        myPDF.CreateFile(DefineAll.PDF_PRE_NAME + Session("CApplyNo") + ".d")

        '刪除檔案
        myPDF.Delete(DefineAll.PDF_PRE_NAME + Session("CApplyNo"))

        Response.End()
    End Sub

End Class
