Imports Microsoft.VisualBasic
Public Class UserViewModel

#Region " Private variables "
    Private _User_Id As String
    Private _Password As String
    Private _User_Name As String
    Private _User_Tel As String
    Private _Center_Code As String
    Private _Role As String
    Private _Role_Name As String
    Private _Status As String
    Private _Remark As String
    Private _Last_Update As Date

#End Region

#Region " Properties "
    Public Property User_Id() As String
        Get
            Return _User_Id
        End Get
        Set(ByVal Value As String)
            _User_Id = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Public Property User_Name() As String
        Get
            Return _User_Name
        End Get
        Set(ByVal Value As String)
            _User_Name = Value
        End Set
    End Property

    Public Property User_Tel() As String
        Get
            Return _User_Tel
        End Get
        Set(ByVal Value As String)
            _User_Tel = Value
        End Set
    End Property

    Public Property Center_Code() As String
        Get
            Return _Center_Code
        End Get
        Set(ByVal Value As String)
            _Center_Code = Value
        End Set
    End Property

    Public Property Role() As String
        Get
            Return _Role
        End Get
        Set(ByVal Value As String)
            _Role = Value
        End Set
    End Property

    Public Property Role_Name() As String
        Get
            Return _Role_Name
        End Get
        Set(ByVal Value As String)
            _Role_Name = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal Value As String)
            _Status = Value
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