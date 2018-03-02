Imports Microsoft.VisualBasic

Public Class CenterViewModel

#Region " Private variables "
    Private _Center_Code As String
    Private _Center_Name As String
    Private _Center_Referred As String
    Private _Center_Address As String
    Private _Center_Tel As String
    Private _Center_Fax As String
    Private _Center_Email As String
    Private _Center_Staff1 As String
    Private _Center_Staff2 As String
    Private _Apply_Lastnum As Integer
    Private _Receipt_Lastnum As Integer
    Private _Last_Update As Date

#End Region
#Region " Properties "
    Public Property Center_Code() As String
        Get
            Return _Center_Code
        End Get
        Set(ByVal Value As String)
            _Center_Code = Value
        End Set
    End Property

    Public Property Center_Name() As String
        Get
            Return _Center_Name
        End Get
        Set(ByVal Value As String)
            _Center_Name = Value
        End Set
    End Property

    Public Property Center_Referred() As String
        Get
            Return _Center_Referred
        End Get
        Set(ByVal Value As String)
            _Center_Referred = Value
        End Set
    End Property

    Public Property Center_Address() As String
        Get
            Return _Center_Address
        End Get
        Set(ByVal Value As String)
            _Center_Address = Value
        End Set
    End Property

    Public Property Center_Tel() As String
        Get
            Return _Center_Tel
        End Get
        Set(ByVal Value As String)
            _Center_Tel = Value
        End Set
    End Property

    Public Property Center_Fax() As String
        Get
            Return _Center_Fax
        End Get
        Set(ByVal Value As String)
            _Center_Fax = Value
        End Set
    End Property

    Public Property Center_Email() As String
        Get
            Return _Center_Email
        End Get
        Set(ByVal Value As String)
            _Center_Email = Value
        End Set
    End Property

    Public Property Center_Staff1() As String
        Get
            Return _Center_Staff1
        End Get
        Set(ByVal Value As String)
            _Center_Staff1 = Value
        End Set
    End Property

    Public Property Center_Staff2() As String
        Get
            Return _Center_Staff2
        End Get
        Set(ByVal Value As String)
            _Center_Staff2 = Value
        End Set
    End Property

    Public Property Apply_Lastnum() As Integer
        Get
            Return _Apply_Lastnum
        End Get
        Set(ByVal Value As Integer)
            _Apply_Lastnum = Value
        End Set
    End Property

    Public Property Receipt_Lastnum() As Integer
        Get
            Return _Receipt_Lastnum
        End Get
        Set(ByVal Value As Integer)
            _Receipt_Lastnum = Value
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

'Public Class CenterViewModel
'    Public Center_Code As String
'    Public Center_Name As String
'    Public Center_Referred As String
'    Public Center_Address As String
'    Public Center_Tel As String
'    Public Center_Fax As String
'    Public Center_Email As String
'    Public Center_Staff1 As String
'    Public Center_Staff2 As String
'    Public Apply_Lastnum As String
'    Public Receipt_Lastnum As String
'End Class
