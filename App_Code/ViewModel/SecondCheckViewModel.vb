Imports Microsoft.VisualBasic
Imports System.ComponentModel

Public Class SecondCheckViewModel

#Region " Private variables "
    Private _Apply_No As String
    Private _Status_Code As String
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

    Public Property Status_Code() As String
        Get
            Return _Status_Code
        End Get
        Set(ByVal Value As String)
            _Status_Code = Value
        End Set
    End Property

    Public Property Review2_Date() As Date?
        Get
            Return _Review2_Date
        End Get
        Set(ByVal Value As Date?)
            _Review2_Date = Value
        End Set
    End Property

    Public Property Review2_Person() As String
        Get
            Return _Review2_Person
        End Get
        Set(ByVal Value As String)
            _Review2_Person = Value
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

    Public Property Review2_Remark() As String
        Get
            Return _Review2_Remark
        End Get
        Set(ByVal Value As String)
            _Review2_Remark = Value
        End Set
    End Property

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
    Public Review2_PersonName As String
#End Region

End Class
