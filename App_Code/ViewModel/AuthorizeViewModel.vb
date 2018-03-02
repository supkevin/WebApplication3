Public Class AuthorizeViewModel

#Region " Private variables "
    Private _Auth_Code As Integer
    Private _Role As String
    Private _Page_Path As String
    Private _Page_Name As String
    Private _Group_Code As Integer
    Private _Sort_Order As Integer
#End Region

#Region " Properties "
    Public Property Auth_Code() As Integer
        Get
            Return _Auth_Code
        End Get
        Set(ByVal Value As Integer)
            _Auth_Code = Value
        End Set
    End Property

    Public Property Group_Code() As Integer
        Get
            Return _Group_Code
        End Get
        Set(ByVal Value As Integer)
            _Group_Code = Value
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

    Public Property Page_Path() As String
        Get
            Return _Page_Path
        End Get
        Set(ByVal Value As String)
            _Page_Path = Value
        End Set
    End Property

    Public Property Page_Name() As String
        Get
            Return _Page_Name
        End Get
        Set(ByVal Value As String)
            _Page_Name = Value
        End Set
    End Property

    Public Property Sort_Order() As Integer
        Get
            Return _Sort_Order
        End Get
        Set(ByVal Value As Integer)
            _Sort_Order = Value
        End Set
    End Property
#End Region

End Class