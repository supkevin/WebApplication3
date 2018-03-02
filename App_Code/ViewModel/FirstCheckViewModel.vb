Imports Microsoft.VisualBasic
Imports System.ComponentModel

Public Class FirstCheckViewModel

#Region " Private variables "
    Private _Apply_No As String
    'Private _Apply_Date As Date
    'Private _Name As String
    'Private _Sex As String
    'Private _Id_No As String
    'Private _Birthday As Date?
    'Private _Czip As String
    'Private _Caddress As String
    'Private _Rzip As String
    'Private _Raddress As String
    'Private _Tel1 As String
    'Private _Tel2 As String
    'Private _Mobile As String
    'Private _Email As String
    'Private _School As String
    'Private _Department As String
    'Private _Grade As Integer
    'Private _Apply_Times As String
    'Private _Groups As String
    Private _Score As Decimal
    'Private _Awards As String
    'Private _Parents_Name As String
    'Private _Parents As String
    'Private _Trauma_Type As String
    'Private _Apply_Mode As String
    'Private _Recommend As String
    'Private _Rec_Name As String
    'Private _Rec_Position As String
    'Private _Rec_Tel As String
    'Private _Bank_Code As String
    'Private _Account_No As String
    'Private _Account_Name As String
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
    'Private _Review2_Date As Date?
    'Private _Review2_Person As String
    'Private _Review2_Result As String
    'Private _Review2_Remark As String
    'Private _Ceremony_Attend As String
    'Private _Ceremony_Session As String
    'Private _Ceremony_Remark As String
    'Private _Service_Hour As Integer
    'Private _Service_Date As Date?
    'Private _Service_Area As String
    'Private _Service_remark As String
    'Private _Last_Update As Date?

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


    Public Property Score() As Decimal
        Get
            Return _Score
        End Get
        Set(ByVal Value As Decimal)
            _Score = Value
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

    Public Property Short_Certificates() As String
        Get
            Return _Short_Certificates
        End Get
        Set(ByVal Value As String)
            _Short_Certificates = Value
        End Set
    End Property

    Public Property Notice_Remark() As String
        Get
            Return _Notice_Remark
        End Get
        Set(ByVal Value As String)
            _Notice_Remark = Value
        End Set
    End Property

    Public Property Notice_Sms() As Date?
        Get
            Return _Notice_Sms
        End Get
        Set(ByVal Value As Date?)
            _Notice_Sms = Value
        End Set
    End Property

    Public Property Notice_Email() As Date?
        Get
            Return _Notice_Email
        End Get
        Set(ByVal Value As Date?)
            _Notice_Email = Value
        End Set
    End Property

    Public Property Completed_Date() As Date?
        Get
            Return _Completed_Date
        End Get
        Set(ByVal Value As Date?)
            _Completed_Date = Value
        End Set
    End Property

    Public Property Status_Code() As String
        Get
            Return _Status_Code
        End Get
        Set(ByVal Value As String)
            _Status_Code = Value
        End Set
    End Property

    Public Property Review1_Date() As Date?
        Get
            Return _Review1_Date
        End Get
        Set(ByVal Value As Date?)
            _Review1_Date = Value
        End Set
    End Property

    Public Property Review1_Person() As String
        Get
            Return _Review1_Person
        End Get
        Set(ByVal Value As String)
            _Review1_Person = Value
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

    Public Property Review1_Remark() As String
        Get
            Return _Review1_Remark
        End Get
        Set(ByVal Value As String)
            _Review1_Remark = Value
        End Set
    End Property

    Public Property Unqualified_Code() As String
        Get
            Return _Unqualified_Code
        End Get
        Set(ByVal Value As String)
            _Unqualified_Code = Value
        End Set
    End Property

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

    'Public Property Review2_Result() As String
    '    Get
    '        Return _Review2_Result
    '    End Get
    '    Set(ByVal Value As String)
    '        _Review2_Result = Value
    '    End Set
    'End Property

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

    'Fake Property
    Public Review1_PersonName As String  '初審人員姓名
    Public Email As String               '申請人郵件
    Public Mobile As String              '申請人手機
#End Region

End Class
