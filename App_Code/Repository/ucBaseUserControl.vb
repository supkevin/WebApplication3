Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls

Public Class ucBaseUserControl
    Inherits System.Web.UI.UserControl

    Protected _ReadOnly As Boolean
    Public Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
        End Set
    End Property
End Class
