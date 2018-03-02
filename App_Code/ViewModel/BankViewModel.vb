Imports Microsoft.VisualBasic
Public Class BankViewModel

#Region " Private variables "
    Private _Bank_Code As String
    Private _Bank_Name As String
    Private _Bank_Referred As String
    Private _Last_Update As Date
#End Region

#Region " Properties "
    Public Property Bank_Code() As String
        Get
            Return _Bank_Code
        End Get
        Set(ByVal Value As String)
            _Bank_Code = Value
        End Set
    End Property

    Public Property Bank_Name() As String
        Get
            Return _Bank_Name
        End Get
        Set(ByVal Value As String)
            _Bank_Name = Value
        End Set
    End Property

    Public Property Bank_Referred() As String
        Get
            Return _Bank_Referred
        End Get
        Set(ByVal Value As String)
            _Bank_Referred = Value
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
'Public Class BankViewModel
'    Public Bank_Code As String
'    Public Bank_Name As String
'    Public Bank_Referred As String
'End Class
