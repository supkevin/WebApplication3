Imports Microsoft.VisualBasic

Public Class CodeNameViewModel
    Private _Code As String
    Private _Name As String

    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal Value As String)
            _Code = Value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal Value As String)
            _Name = Value
        End Set
    End Property

End Class