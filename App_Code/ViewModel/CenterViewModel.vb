Imports Microsoft.VisualBasic

Public Class CertificateViewModel

#Region " Private variables "
    Private _Certificate_Code As String
    Private _Certificate_Name As String
    Private _Description As String
    Private _Last_Update As Date

#End Region
#Region " Properties "
    Public Property Certificate_Code() As String
        Get
            Return _Certificate_Code
        End Get
        Set(ByVal Value As String)
            _Certificate_Code = Value
        End Set
    End Property

    Public Property Certificate_Name() As String
        Get
            Return _Certificate_Name
        End Get
        Set(ByVal Value As String)
            _Certificate_Name = Value
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