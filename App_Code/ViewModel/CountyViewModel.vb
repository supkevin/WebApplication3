Imports Microsoft.VisualBasic

Public Class CountyViewModel

#Region " Private variables "
    Private _County_Code As String
    Private _County_Name As String
#End Region

#Region " Properties "
    Public Property County_Code() As String
        Get
            Return _County_Code
        End Get
        Set(ByVal Value As String)
            _County_Code = Value
        End Set
    End Property
    Public Property County_Name() As String
        Get
            Return _County_Name
        End Get
        Set(ByVal Value As String)
            _County_Name = Value
        End Set
    End Property
#End Region
End Class
