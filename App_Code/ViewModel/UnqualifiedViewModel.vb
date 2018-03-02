Imports Microsoft.VisualBasic

Public Class UnqualifiedViewModel
#Region " Private variables "
    Private _Unqualified_Code As String
    Private _Unqualified_Content As String
    Private _Description As String
    Private _Last_Update As Date

#End Region
#Region " Properties "
    Public Property Unqualified_Code() As String
        Get
            Return _Unqualified_Code
        End Get
        Set(ByVal Value As String)
            _Unqualified_Code = Value
        End Set
    End Property

    Public Property Unqualified_Content() As String
        Get
            Return _Unqualified_Content
        End Get
        Set(ByVal Value As String)
            _Unqualified_Content = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal Value As String)
            _Description = Value
        End Set
    End Property

    Public Property Last_Update() As Date
        Get
            Return _Last_Update
        End Get
        Set(ByVal Value As Date)
            _Last_Update = Value
        End Set
    End Property


#End Region

End Class
