
Partial Class Pages_TestPDF
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As New PDF
        a.SaveFromFile("rpt2.htm", "rpt2")
        Response.Redirect("rpt2.pdf")
    End Sub

    Protected Sub rpt0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rpt0.Click
        Dim a As New PDF
        a.SaveFromFile("rpt0.htm", "rpt0")
        Response.Redirect("rpt0.pdf")
    End Sub
End Class
