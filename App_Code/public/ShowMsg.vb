Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class ShowMsg
    Public Sub ShowMsg(ByVal Btn As Button, ByVal Msg As String)

        ScriptManager.RegisterClientScriptBlock(Btn, Me.GetType(), "click", "alert('" + Msg + "');", True)
    End Sub
End Class
