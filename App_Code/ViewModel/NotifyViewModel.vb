Imports Microsoft.VisualBasic

Public Class MailNotifyViewModel
    Inherits NotifyViewModel
    Public Sub New()
        Me.Type = 2
    End Sub

End Class
Public Class SmsNotifyViewModel
    Inherits NotifyViewModel
    Public Sub New()
        Me.Type = 1
    End Sub
End Class

Public Class NotifyViewModel

#Region " Private variables "
    Private _SeqNo As Integer
    Private _Type As Integer
    Private _Apply_No As String
    Private _Message As String
    Private _Receiver As String
    Private _HasError As Integer
    Private _Creator As String
    Private _CreateTime As DateTime?

#End Region
#Region " Properties "

    'Public Property SeqNo() As Integer
    '    Get
    '        Return _SeqNo
    '    End Get
    '    Set(ByVal Value As Integer)
    '        _SeqNo = Value
    '    End Set
    'End Property

    Public Property Type() As Integer
        Get
            Return _Type
        End Get
        Set(ByVal Value As Integer)
            _Type = Value
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

    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal Value As String)
            _Message = Value
        End Set
    End Property

    Public Property Receiver() As String
        Get
            Return _Receiver
        End Get
        Set(ByVal Value As String)
            _Receiver = Value
        End Set
    End Property

    Public Property HasError() As Integer
        Get
            Return _HasError
        End Get
        Set(ByVal Value As Integer)
            _HasError = Value
        End Set
    End Property

    'Public Property Creator() As String
    '    Get
    '        Return _Creator
    '    End Get
    '    Set(ByVal Value As String)
    '        _Creator = Value
    '    End Set
    'End Property

    'Public Property CreateTime() As DateTime?
    '    Get
    '        Return _CreateTime
    '    End Get
    '    Set(ByVal Value As DateTime?)
    '        _CreateTime = Value
    '    End Set
    'End Property

    Public SeqNo As Integer             'Identity
    Public Creator As String
    Public CreateTime As DateTime?
#End Region

End Class
