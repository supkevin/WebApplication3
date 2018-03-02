Imports Microsoft.VisualBasic
Public Class ProgressViewModel
#Region " Private variables "
    Private _Status_Code As String
    Private _Status_Content As String
    Private _Description As String
    Private _Last_Update As Date

#End Region
#Region " Properties "
    Public Property Status_Code() As String
        Get
            Return _Status_Code
        End Get
        Set(ByVal Value As String)
            _Status_Code = Value
        End Set
    End Property

    Public Property Status_Content() As String
        Get
            Return _Status_Content
        End Get
        Set(ByVal Value As String)
            _Status_Content = Value
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
'Public Class ProgressViewModel
'    Public Status_Code As String
'    Public Status_Content As String
'    Public Description As String
'End Class
