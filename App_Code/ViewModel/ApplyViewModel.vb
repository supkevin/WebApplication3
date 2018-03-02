Imports Microsoft.VisualBasic

Public Class ApplyViewModel

#Region " Private variables "
    Private _Apply_No As String
    Private _Apply_Date As Date
    Private _Name As String
    Private _Sex As String
    Private _Id_No As String
    Private _Birthday As Date?
    Private _Czip As String
    Private _Caddress As String
    Private _Rzip As String
    Private _Raddress As String
    Private _Tel1 As String
    Private _Tel2 As String
    Private _Mobile As String
    Private _Email As String
    Private _School As String
    Private _Department As String
    Private _Grade As Integer
    Private _Apply_Times As String
    Private _Groups As String
    Private _Score As Single
    Private _Awards As String
    Private _Parents_Name As String
    Private _Parents As String
    Private _Trauma_Type As String
    Private _Trauma_Remark As String
    Private _Apply_Mode As String
    Private _Recommend As String
    Private _Rec_Name As String
    Private _Rec_Position As String
    Private _Rec_Tel As String
    Private _Bank_Code As String
    Private _Account_No As String
    Private _Account_Name As String
    Private _Certificate_Date As Date?
    Private _Certificate_Code As String
    Private _Short_Certificates As String
    Private _Notice_Remark As String
    Private _Notice_Sms As Date?
    Private _Notice_Email As Date?
    Private _Completed_Date As Date?
    Private _Status_Code As String
    Private _Review1_Date As Date?
    Private _Review1_Person As String
    Private _Review1_Result As String
    Private _Review1_Remark As String
    Private _Unqualified_Code As String
    Private _Review2_Date As Date?
    Private _Review2_Person As String
    Private _Review2_Result As String
    Private _Review2_Remark As String
    Private _Ceremony_Attend As String
    Private _Ceremony_Session As String
    Private _Ceremony_Remark As String
    Private _Service_Hour As Integer
    Private _Service_Date As Date?
    Private _Service_Area As String
    Private _Service_remark As String
    Private _Last_Update As Date?

#End Region

#Region " Properties "
    Public Property Apply_No() As String
        Get
            Return _Apply_No
        End Get
        Set(ByVal Value As String)
            _Apply_No = Value
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

    Public Property Id_No() As String
        Get
            Return _Id_No
        End Get
        Set(ByVal Value As String)
            _Id_No = Value
        End Set
    End Property

    Public Property Birthday() As Date?
        Get
            Return _Birthday
        End Get
        Set(ByVal Value As Date?)
            _Birthday = Value
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

    Public Property Grade() As Integer
        Get
            Return _Grade
        End Get
        Set(ByVal Value As Integer)
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

    Public Property Groups() As String
        Get
            Return _Groups
        End Get
        Set(ByVal Value As String)
            _Groups = Value
        End Set
    End Property

    'Public Property Score() As Single
    '    Get
    '        Return _Score
    '    End Get
    '    Set(ByVal Value As Single)
    '        _Score = Value
    '    End Set
    'End Property

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

    Public Property Parents() As String
        Get
            Return _Parents
        End Get
        Set(ByVal Value As String)
            _Parents = Value
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

    Public Property Trauma_Remark() As String
        Get
            Return _Trauma_Remark
        End Get
        Set(ByVal Value As String)
            _Trauma_Remark = Value
        End Set
    End Property

    Public Property Apply_Mode() As String
        Get
            Return _Apply_Mode
        End Get
        Set(ByVal Value As String)
            _Apply_Mode = Value
        End Set
    End Property

    Public Property Recommend() As String
        Get
            Return _Recommend
        End Get
        Set(ByVal Value As String)
            _Recommend = Value
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

    Public Property Rec_Position() As String
        Get
            Return _Rec_Position
        End Get
        Set(ByVal Value As String)
            _Rec_Position = Value
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

    Public Property Bank_Code() As String
        Get
            Return _Bank_Code
        End Get
        Set(ByVal Value As String)
            _Bank_Code = Value
        End Set
    End Property

    Public Property Account_No() As String
        Get
            Return _Account_No
        End Get
        Set(ByVal Value As String)
            _Account_No = Value
        End Set
    End Property

    Public Property Account_Name() As String
        Get
            Return _Account_Name
        End Get
        Set(ByVal Value As String)
            _Account_Name = Value
        End Set
    End Property

    Public Property Certificate_Date() As Date?
        Get
            Return _Certificate_Date
        End Get
        Set(ByVal Value As Date?)
            _Certificate_Date = Value
        End Set
    End Property

    Public Property Certificate_Code() As String
        Get
            Return _Certificate_Code
        End Get
        Set(ByVal Value As String)
            _Certificate_Code = Value
        End Set
    End Property

    'Public Property Short_Certificates() As String
    '    Get
    '        Return _Short_Certificates
    '    End Get
    '    Set(ByVal Value As String)
    '        _Short_Certificates = Value
    '    End Set
    'End Property

    'Public Property Notice_Remark() As String
    '    Get
    '        Return _Notice_Remark
    '    End Get
    '    Set(ByVal Value As String)
    '        _Notice_Remark = Value
    '    End Set
    'End Property

    'Public Property Notice_Sms() As Date?
    '    Get
    '        Return _Notice_Sms
    '    End Get
    '    Set(ByVal Value As Date?)
    '        _Notice_Sms = Value
    '    End Set
    'End Property

    'Public Property Notice_Email() As Date?
    '    Get
    '        Return _Notice_Email
    '    End Get
    '    Set(ByVal Value As Date?)
    '        _Notice_Email = Value
    '    End Set
    'End Property

    'Public Property Completed_Date() As Date?
    '    Get
    '        Return _Completed_Date
    '    End Get
    '    Set(ByVal Value As Date?)
    '        _Completed_Date = Value
    '    End Set
    'End Property

    Public Property Status_Code() As String
        Get
            Return _Status_Code
        End Get
        Set(ByVal Value As String)
            _Status_Code = Value
        End Set
    End Property

    'Public Property Review1_Date() As Date?
    '    Get
    '        Return _Review1_Date
    '    End Get
    '    Set(ByVal Value As Date?)
    '        _Review1_Date = Value
    '    End Set
    'End Property

    'Public Property Review1_Person() As String
    '    Get
    '        Return _Review1_Person
    '    End Get
    '    Set(ByVal Value As String)
    '        _Review1_Person = Value
    '    End Set
    'End Property

    Public Property Review1_Result() As String
        Get
            Return _Review1_Result
        End Get
        Set(ByVal Value As String)
            _Review1_Result = Value
        End Set
    End Property

    Public Property Review1_Remark() As String
        Get
            Return _Review1_Remark
        End Get
        Set(ByVal Value As String)
            _Review1_Remark = Value
        End Set
    End Property

    'Public Property Unqualified_Code() As String
    '    Get
    '        Return _Unqualified_Code
    '    End Get
    '    Set(ByVal Value As String)
    '        _Unqualified_Code = Value
    '    End Set
    'End Property

    'Public Property Review2_Date() As Date?
    '    Get
    '        Return _Review2_Date
    '    End Get
    '    Set(ByVal Value As Date?)
    '        _Review2_Date = Value
    '    End Set
    'End Property

    'Public Property Review2_Person() As String
    '    Get
    '        Return _Review2_Person
    '    End Get
    '    Set(ByVal Value As String)
    '        _Review2_Person = Value
    '    End Set
    'End Property

    Public Property Review2_Result() As String
        Get
            Return _Review2_Result
        End Get
        Set(ByVal Value As String)
            _Review2_Result = Value
        End Set
    End Property

    'Public Property Review2_Remark() As String
    '    Get
    '        Return _Review2_Remark
    '    End Get
    '    Set(ByVal Value As String)
    '        _Review2_Remark = Value
    '    End Set
    'End Property

    'Public Property Ceremony_Attend() As String
    '    Get
    '        Return _Ceremony_Attend
    '    End Get
    '    Set(ByVal Value As String)
    '        _Ceremony_Attend = Value
    '    End Set
    'End Property

    'Public Property Ceremony_Session() As String
    '    Get
    '        Return _Ceremony_Session
    '    End Get
    '    Set(ByVal Value As String)
    '        _Ceremony_Session = Value
    '    End Set
    'End Property

    'Public Property Ceremony_Remark() As String
    '    Get
    '        Return _Ceremony_Remark
    '    End Get
    '    Set(ByVal Value As String)
    '        _Ceremony_Remark = Value
    '    End Set
    'End Property

    'Public Property Service_Hour() As Integer
    '    Get
    '        Return _Service_Hour
    '    End Get
    '    Set(ByVal Value As Integer)
    '        _Service_Hour = Value
    '    End Set
    'End Property

    'Public Property Service_Date() As Date?
    '    Get
    '        Return _Service_Date
    '    End Get
    '    Set(ByVal Value As Date?)
    '        _Service_Date = Value
    '    End Set
    'End Property

    'Public Property Service_Area() As String
    '    Get
    '        Return _Service_Area
    '    End Get
    '    Set(ByVal Value As String)
    '        _Service_Area = Value
    '    End Set
    'End Property

    'Public Property Service_remark() As String
    '    Get
    '        Return _Service_remark
    '    End Get
    '    Set(ByVal Value As String)
    '        _Service_remark = Value
    '    End Set
    'End Property

    'Public Property Last_Update() As Date?
    '    Get
    '        Return _Last_Update
    '    End Get
    '    Set(ByVal Value As Date?)
    '        _Last_Update = Value
    '    End Set
    'End Property


#End Region

End Class
