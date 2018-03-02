Imports System.Data.SqlClient
Partial Class _default
    Inherits System.Web.UI.Page
    Dim Sh As New ShowMsg

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If Request.UrlReferrer = Nothing Then
            'Response.Redirect("~/default.aspx")
            '   End If
            InitPage()
        End If
    End Sub
    Private Sub InitPage()
      
            OutDate.Visible = True
       
    End Sub

    'Protected Sub Btn_Desc_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Desc_Cancel.Click
    '    Response.Redirect("Pages\Apply_link.aspx")
    'End Sub

   
End Class
