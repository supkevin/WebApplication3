Imports Microsoft.VisualBasic

Public Class PublicServiceViewModel

#Region " Private variables "
    Private _Service_Hour As Integer
    Private _Service_Date As Date?
    Private _Service_Area As String
    Private _Service_remark As String
#End Region

#Region " Properties "
    Public Property Service_Hour() As Integer
        Get
            Return _Service_Hour
        End Get
        Set(ByVal Value As Integer)
            _Service_Hour = Value
        End Set
    End Property

    Public Property Service_Date() As Date?
        Get
            Return _Service_Date
        End Get
        Set(ByVal Value As Date?)
            _Service_Date = Value
        End Set
    End Property

    Public Property Service_Area() As String
        Get
            Return _Service_Area
        End Get
        Set(ByVal Value As String)
            _Service_Area = Value
        End Set
    End Property

    Public Property Service_remark() As String
        Get
            Return _Service_remark
        End Get
        Set(ByVal Value As String)
            _Service_remark = Value
        End Set
    End Property


#End Region

End Class
