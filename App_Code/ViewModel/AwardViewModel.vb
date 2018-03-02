Imports Microsoft.VisualBasic
Public Class AwardViewModel
#Region " Private variables "
    Private _Award_Code As String
    Private _Award_Name As String
    Private _Award_Co As String
    Private _Award_Recipient As String
    Private _Bonus_G1 As Integer
    Private _Bonus_G2 As Integer
    Private _Bonus_G3 As Integer
    Private _Bonus_G4 As Integer
    Private _Bonus_G5 As Integer
    Private _Bonus_G6 As Integer
    Private _First_Certificates As String
    Private _Again_Certificates As String
    Private _Description As String
    Private _Stop_Sign As String
    Private _Last_Update As Date

#End Region
#Region " Properties "
    Public Property Award_Code() As String
        Get
            Return _Award_Code
        End Get
        Set(ByVal Value As String)
            _Award_Code = Value
        End Set
    End Property

    Public Property Award_Name() As String
        Get
            Return _Award_Name
        End Get
        Set(ByVal Value As String)
            _Award_Name = Value
        End Set
    End Property

    Public Property Award_Co() As String
        Get
            Return _Award_Co
        End Get
        Set(ByVal Value As String)
            _Award_Co = Value
        End Set
    End Property

    Public Property Award_Recipient() As String
        Get
            Return _Award_Recipient
        End Get
        Set(ByVal Value As String)
            _Award_Recipient = Value
        End Set
    End Property

    Public Property Bonus_G1() As Integer
        Get
            Return _Bonus_G1
        End Get
        Set(ByVal Value As Integer)
            _Bonus_G1 = Value
        End Set
    End Property

    Public Property Bonus_G2() As Integer
        Get
            Return _Bonus_G2
        End Get
        Set(ByVal Value As Integer)
            _Bonus_G2 = Value
        End Set
    End Property

    Public Property Bonus_G3() As Integer
        Get
            Return _Bonus_G3
        End Get
        Set(ByVal Value As Integer)
            _Bonus_G3 = Value
        End Set
    End Property

    Public Property Bonus_G4() As Integer
        Get
            Return _Bonus_G4
        End Get
        Set(ByVal Value As Integer)
            _Bonus_G4 = Value
        End Set
    End Property

    Public Property Bonus_G5() As Integer
        Get
            Return _Bonus_G5
        End Get
        Set(ByVal Value As Integer)
            _Bonus_G5 = Value
        End Set
    End Property

    Public Property Bonus_G6() As Integer
        Get
            Return _Bonus_G6
        End Get
        Set(ByVal Value As Integer)
            _Bonus_G6 = Value
        End Set
    End Property

    Public Property First_Certificates() As String
        Get
            Return _First_Certificates
        End Get
        Set(ByVal Value As String)
            _First_Certificates = Value
        End Set
    End Property

    Public Property Again_Certificates() As String
        Get
            Return _Again_Certificates
        End Get
        Set(ByVal Value As String)
            _Again_Certificates = Value
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

    Public Property Stop_Sign() As String
        Get
            Return _Stop_Sign
        End Get
        Set(ByVal Value As String)
            _Stop_Sign = Value
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
'Public Class AwardViewModel
'    Public Award_Code As String
'    Public Award_Name As String
'    Public Award_Co As String
'    Public Award_Recipient As String
'    Public Bonus_G1 As Integer
'    Public Bonus_G2 As Integer
'    Public Bonus_G3 As Integer
'    Public Bonus_G4 As Integer
'    Public Bonus_G5 As Integer
'    Public Bonus_G6 As Integer
'    Public First_Certificates As String
'    Public Again_Certificates As String
'    Public Description As String
'    Public Stop_Sign As String
'End Class
