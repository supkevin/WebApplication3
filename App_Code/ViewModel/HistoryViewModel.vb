Imports Microsoft.VisualBasic

Public Class HistoryViewModel

#Region " Private variables "
    Private _Apply_Year As String
    Private _Apply_No As String
    Private _Name As String
    Private _Sex As String
    Private _Birthday As Date
    Private _School As String
    Private _Department As String
    Private _Grade As String
    Private _Apply_Times As String
    Private _Czip As String
    Private _Caddress As String
    Private _Rzip As String
    Private _Raddress As String
    Private _Tel1 As String
    Private _Tel2 As String
    Private _Mobile As String
    Private _Email As String
    Private _Groups As String
    Private _Awards As String
    Private _Parents_Name As String
    Private _Trauma_Type As String
    Private _Rec_Name As String
    Private _Rec_Tel As String
    Private _Score As String
    Private _Bonus As Integer
    Private _Center_No As String
    Private _Apply_Date As Date
    Private _Review1_Result As String
    Private _Review2_Result As String
    Private _Remark As String
    Private _Last_Update As Date

#End Region

#Region " Properties "
    Public Property Apply_Year() As String
        Get
            Return _Apply_Year
        End Get
        Set(ByVal Value As String)
            _Apply_Year = Value
        End Set
    End Property

    Public Property Apply_No() As String
        Get
            Return _Apply_No
        End Get
        Set(ByVal Value As String)
            _Apply_No = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal Value As String)
            _Name = Value
        End Set
    End Property

    Public Property Sex() As String
        Get
            Return _Sex
        End Get
        Set(ByVal Value As String)
            _Sex = Value
        End Set
    End Property

    Public Property Birthday() As Date
        Get
            Return _Birthday
        End Get
        Set(ByVal Value As Date)
            _Birthday = Value
        End Set
    End Property

    Public Property School() As String
        Get
            Return _School
        End Get
        Set(ByVal Value As String)
            _School = Value
        End Set
    End Property

    Public Property Department() As String
        Get
            Return _Department
        End Get
        Set(ByVal Value As String)
            _Department = Value
        End Set
    End Property

    Public Property Grade() As String
        Get
            Return _Grade
        End Get
        Set(ByVal Value As String)
            _Grade = Value
        End Set
    End Property

    Public Property Apply_Times() As String
        Get
            Return _Apply_Times
        End Get
        Set(ByVal Value As String)
            _Apply_Times = Value
        End Set
    End Property

    Public Property Czip() As String
        Get
            Return _Czip
        End Get
        Set(ByVal Value As String)
            _Czip = Value
        End Set
    End Property

    Public Property Caddress() As String
        Get
            Return _Caddress
        End Get
        Set(ByVal Value As String)
            _Caddress = Value
        End Set
    End Property

    Public Property Rzip() As String
        Get
            Return _Rzip
        End Get
        Set(ByVal Value As String)
            _Rzip = Value
        End Set
    End Property

    Public Property Raddress() As String
        Get
            Return _Raddress
        End Get
        Set(ByVal Value As String)
            _Raddress = Value
        End Set
    End Property

    Public Property Tel1() As String
        Get
            Return _Tel1
        End Get
        Set(ByVal Value As String)
            _Tel1 = Value
        End Set
    End Property

    Public Property Tel2() As String
        Get
            Return _Tel2
        End Get
        Set(ByVal Value As String)
            _Tel2 = Value
        End Set
    End Property

    Public Property Mobile() As String
        Get
            Return _Mobile
        End Get
        Set(ByVal Value As String)
            _Mobile = Value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property

    Public Property Groups() As String
        Get
            Return _Groups
        End Get
        Set(ByVal Value As String)
            _Groups = Value
        End Set
    End Property

    Public Property Awards() As String
        Get
            Return _Awards
        End Get
        Set(ByVal Value As String)
            _Awards = Value
        End Set
    End Property

    Public Property Parents_Name() As String
        Get
            Return _Parents_Name
        End Get
        Set(ByVal Value As String)
            _Parents_Name = Value
        End Set
    End Property

    Public Property Trauma_Type() As String
        Get
            Return _Trauma_Type
        End Get
        Set(ByVal Value As String)
            _Trauma_Type = Value
        End Set
    End Property

    Public Property Rec_Name() As String
        Get
            Return _Rec_Name
        End Get
        Set(ByVal Value As String)
            _Rec_Name = Value
        End Set
    End Property

    Public Property Rec_Tel() As String
        Get
            Return _Rec_Tel
        End Get
        Set(ByVal Value As String)
            _Rec_Tel = Value
        End Set
    End Property

    Public Property Score() As String
        Get
            Return _Score
        End Get
        Set(ByVal Value As String)
            _Score = Value
        End Set
    End Property

    Public Property Bonus() As Integer
        Get
            Return _Bonus
        End Get
        Set(ByVal Value As Integer)
            _Bonus = Value
        End Set
    End Property

    Public Property Center_No() As String
        Get
            Return _Center_No
        End Get
        Set(ByVal Value As String)
            _Center_No = Value
        End Set
    End Property

    Public Property Apply_Date() As Date
        Get
            Return _Apply_Date
        End Get
        Set(ByVal Value As Date)
            _Apply_Date = Value
        End Set
    End Property

    Public Property Review1_Result() As String
        Get
            Return _Review1_Result
        End Get
        Set(ByVal Value As String)
            _Review1_Result = Value
        End Set
    End Property

    Public Property Review2_Result() As String
        Get
            Return _Review2_Result
        End Get
        Set(ByVal Value As String)
            _Review2_Result = Value
        End Set
    End Property

    Public Property Remark() As String
        Get
            Return _Remark
        End Get
        Set(ByVal Value As String)
            _Remark = Value
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
