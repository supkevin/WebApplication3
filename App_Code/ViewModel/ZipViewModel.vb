Imports Microsoft.VisualBasic
Public Class ZipViewModel
#Region " Private variables "
    Private _Zip_Code As String
    Private _Center_Code As String
    Private _County_Code As String
    Private _County_Name As String
    Private _Town_Code As String
    Private _Town_Name As String

#End Region
#Region " Properties "
    Public Property Zip_Code() As String
        Get
            Return _Zip_Code
        End Get
        Set(ByVal Value As String)
            _Zip_Code = Value
        End Set
    End Property

    Public Property Center_Code() As String
        Get
            Return _Center_Code
        End Get
        Set(ByVal Value As String)
            _Center_Code = Value
        End Set
    End Property

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

    Public Property Town_Code() As String
        Get
            Return _Town_Code
        End Get
        Set(ByVal Value As String)
            _Town_Code = Value
        End Set
    End Property

    Public Property Town_Name() As String
        Get
            Return _Town_Name
        End Get
        Set(ByVal Value As String)
            _Town_Name = Value
        End Set
    End Property


#End Region

End Class
'Public Class ZipViewModel
'    Public Zip_Code As String
'    Public Center_Code As String
'    Public County_Code As String
'    Public County_Name As String
'    Public Town_Code As String
'    Public Town_Name As String
'End Class

