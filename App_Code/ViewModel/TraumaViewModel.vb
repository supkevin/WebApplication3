Imports Microsoft.VisualBasic
Public Class TraumaViewModel
#Region " Private variables "
    Private _Trauma_Code As String
    Private _Trauma_Name As String
    Private _Description As String
    Private _Last_Update As DateTime

#End Region
#Region " Properties "
    Public Property Trauma_Code() As String
        Get
            Return _Trauma_Code
        End Get
        Set(ByVal Value As String)
            _Trauma_Code = Value
        End Set
    End Property

    Public Property Trauma_Name() As String
        Get
            Return _Trauma_Name
        End Get
        Set(ByVal Value As String)
            _Trauma_Name = Value
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

    Public Property Last_Update() As DateTime
        Get
            Return _Last_Update
        End Get
        Set(ByVal Value As DateTime)
            _Last_Update = Value
        End Set
    End Property


#End Region

End Class
'Public Class TraumaViewModel
'    Public Trauma_Code As String
'    Public Trauma_Name As String
'    Public Description As String
'End Class
