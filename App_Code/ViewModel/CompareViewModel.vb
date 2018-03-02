Imports Microsoft.VisualBasic

Public Class CompareViewModel
#Region " Private variables "
    Private _Id_No As String
    Private _Apply_Name As String
    Private _Apply_Sex As String
    Private _Apply_Birthday As Date
    Private _Apply_Czip As String
    Private _Apply_Caddress As String
    Private _Apply_Rzip As String
    Private _Apply_Raddress As String
    Private _Apply_Tel1 As String
    Private _Apply_Tel2 As String
    Private _Apply_Mobile As String
    Private _Apply_Email As String
    Private _Case_Name As String
    Private _Case_Sex As String
    Private _Case_Birthday As Date
    Private _Case_Czip As String
    Private _Case_Caddress As String
    Private _Case_Rzip As String
    Private _Case_Raddress As String
    Private _Case_Tel1 As String
    Private _Case_Tel2 As String
    Private _Case_Mobile As String
    Private _Case_Email As String
    Private _Compare_Date As Date
    Private _Compare_Result As String
    Private _Restore As String
    Private _Last_Update As Date

#End Region
#Region " Properties "
    Public Property Id_No() As String
        Get
            Return _Id_No
        End Get
        Set(ByVal Value As String)
            _Id_No = Value
        End Set
    End Property

    Public Property Apply_Name() As String
        Get
            Return _Apply_Name
        End Get
        Set(ByVal Value As String)
            _Apply_Name = Value
        End Set
    End Property

    Public Property Apply_Sex() As String
        Get
            Return _Apply_Sex
        End Get
        Set(ByVal Value As String)
            _Apply_Sex = Value
        End Set
    End Property

    Public Property Apply_Birthday() As Date
        Get
            Return _Apply_Birthday
        End Get
        Set(ByVal Value As Date)
            _Apply_Birthday = Value
        End Set
    End Property

    Public Property Apply_Czip() As String
        Get
            Return _Apply_Czip
        End Get
        Set(ByVal Value As String)
            _Apply_Czip = Value
        End Set
    End Property

    Public Property Apply_Caddress() As String
        Get
            Return _Apply_Caddress
        End Get
        Set(ByVal Value As String)
            _Apply_Caddress = Value
        End Set
    End Property

    Public Property Apply_Rzip() As String
        Get
            Return _Apply_Rzip
        End Get
        Set(ByVal Value As String)
            _Apply_Rzip = Value
        End Set
    End Property

    Public Property Apply_Raddress() As String
        Get
            Return _Apply_Raddress
        End Get
        Set(ByVal Value As String)
            _Apply_Raddress = Value
        End Set
    End Property

    Public Property Apply_Tel1() As String
        Get
            Return _Apply_Tel1
        End Get
        Set(ByVal Value As String)
            _Apply_Tel1 = Value
        End Set
    End Property

    Public Property Apply_Tel2() As String
        Get
            Return _Apply_Tel2
        End Get
        Set(ByVal Value As String)
            _Apply_Tel2 = Value
        End Set
    End Property

    Public Property Apply_Mobile() As String
        Get
            Return _Apply_Mobile
        End Get
        Set(ByVal Value As String)
            _Apply_Mobile = Value
        End Set
    End Property

    Public Property Apply_Email() As String
        Get
            Return _Apply_Email
        End Get
        Set(ByVal Value As String)
            _Apply_Email = Value
        End Set
    End Property

    Public Property Case_Name() As String
        Get
            Return _Case_Name
        End Get
        Set(ByVal Value As String)
            _Case_Name = Value
        End Set
    End Property

    Public Property Case_Sex() As String
        Get
            Return _Case_Sex
        End Get
        Set(ByVal Value As String)
            _Case_Sex = Value
        End Set
    End Property

    Public Property Case_Birthday() As Date
        Get
            Return _Case_Birthday
        End Get
        Set(ByVal Value As Date)
            _Case_Birthday = Value
        End Set
    End Property

    Public Property Case_Czip() As String
        Get
            Return _Case_Czip
        End Get
        Set(ByVal Value As String)
            _Case_Czip = Value
        End Set
    End Property

    Public Property Case_Caddress() As String
        Get
            Return _Case_Caddress
        End Get
        Set(ByVal Value As String)
            _Case_Caddress = Value
        End Set
    End Property

    Public Property Case_Rzip() As String
        Get
            Return _Case_Rzip
        End Get
        Set(ByVal Value As String)
            _Case_Rzip = Value
        End Set
    End Property

    Public Property Case_Raddress() As String
        Get
            Return _Case_Raddress
        End Get
        Set(ByVal Value As String)
            _Case_Raddress = Value
        End Set
    End Property

    Public Property Case_Tel1() As String
        Get
            Return _Case_Tel1
        End Get
        Set(ByVal Value As String)
            _Case_Tel1 = Value
        End Set
    End Property

    Public Property Case_Tel2() As String
        Get
            Return _Case_Tel2
        End Get
        Set(ByVal Value As String)
            _Case_Tel2 = Value
        End Set
    End Property

    Public Property Case_Mobile() As String
        Get
            Return _Case_Mobile
        End Get
        Set(ByVal Value As String)
            _Case_Mobile = Value
        End Set
    End Property

    Public Property Case_Email() As String
        Get
            Return _Case_Email
        End Get
        Set(ByVal Value As String)
            _Case_Email = Value
        End Set
    End Property

    Public Property Compare_Date() As Date
        Get
            Return _Compare_Date
        End Get
        Set(ByVal Value As Date)
            _Compare_Date = Value
        End Set
    End Property

    Public Property Compare_Result() As String
        Get
            Return _Compare_Result
        End Get
        Set(ByVal Value As String)
            _Compare_Result = Value
        End Set
    End Property

    Public Property Restore() As String
        Get
            Return _Restore
        End Get
        Set(ByVal Value As String)
            _Restore = Value
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
