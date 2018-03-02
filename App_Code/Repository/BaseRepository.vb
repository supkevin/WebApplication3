Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Configuration
Imports System.Diagnostics
Imports System.Web.SessionState.HttpSessionState

<DebuggerStepThrough()> _
Public Class BaseRepository
    Implements IDisposable
    Dim _Log As WriteLog = New WriteLog()

    Protected Sub WriteError(ByVal message As String)
        _Log.WriteErrMsg(message)
    End Sub

    Private _CurrentUser As UserViewModel = Nothing
    Private Function GetCurrentUser() As UserViewModel
        If IsNothing(System.Web.HttpContext.Current.User) Then
            Throw New NullReferenceException("System.Web.HttpContext.Current.User")
        End If

        Dim u As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
        Dim obj As Object = JsonHelper.JsonToObject(Of UserViewModel)(u.Ticket.UserData)
        Dim result As UserViewModel = CType(obj, UserViewModel)
        Return result
    End Function

    '目前登入的使用者
    Protected ReadOnly Property CurrentUser() As UserViewModel
        Get
            If (IsNothing(_CurrentUser)) Then
                _CurrentUser = GetCurrentUser()
            End If
            Return _CurrentUser
        End Get
    End Property

    'Protected ReadOnly Property UserID() As String
    '    Get
    '        Return System.Web.HttpContext.Current.Session("User_id")
    '    End Get
    'End Property
    'Protected ReadOnly Property UserName() As String
    '    Get
    '        Return System.Web.HttpContext.Current.Session("User_name")
    '    End Get
    'End Property


    Private Function CreateConnection() As SqlConnection
        Dim connstring As String = _
        WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim conn As New SqlConnection(connstring)
        conn.Open()
        Return conn
    End Function
    'Protected Function GetDataReader(ByVal command As String) As DataTable
    '    'Return _Db.SqlReader(command, Nothing)

    '    Dim Comm As New SqlCommand(command, _Conn)
    '    Dim wDataReader As SqlDataReader
    '    Try
    '        wDataReader = Comm.ExecuteReader()
    '    Catch ex As Exception
    '        Wlog.WriteErrMsg(ex.Message.ToString)
    '        Throw
    '    End Try

    'End Function

    'Public Function DataReader(ByVal command As String) As SqlDataReader
    '    Dim Comm As New SqlCommand(command, _Conn)
    '    Dim wDataReader As SqlDataReader
    '    Try
    '        wDataReader = Comm.ExecuteReader()
    '    Catch ex As Exception
    '        Wlog.WriteErrMsg(ex.Message.ToString)
    '        Throw
    '    End Try
    'End Function
    Protected Function GetDataTable(ByVal command As String) As DataTable
        Try
            Using conn As SqlConnection = CreateConnection()
                Dim comm As New SqlCommand(command, conn)
                Dim reader As SqlDataReader
                reader = comm.ExecuteReader()
                Dim dt As New DataTable()
                dt.Load(reader)
                Return dt
            End Using
        Catch ex As Exception
            WriteError(String.Format("{0}:{1}", command, ex.ToString()))
            Throw
        Finally

        End Try
    End Function

    Public Function GetObjectList(Of TResult As Class)(ByVal command As String) As List(Of TResult)
        Dim result As New List(Of TResult)
        Dim table As DataTable = Me.GetDataTable(command)
        result = DBHelper.DataTableToList(Of TResult)(table)
        Return result
    End Function


    Function ExecuteQuery(ByVal command As String) As Integer
        Dim result As Integer = 0
        Try
            Using conn As SqlConnection = CreateConnection()
                Dim comm As New SqlCommand(command, conn)
                result = comm.ExecuteNonQuery()
                Return result
            End Using
        Catch ex As Exception
            WriteError(String.Format("{0}:{1}", command, ex.ToString()))
            Throw
        Finally

        End Try
    End Function

    Function ExecuteScalar(ByVal command As String) As Object
        Dim result As Object
        Try
            Using conn As SqlConnection = CreateConnection()
                Dim comm As New SqlCommand(command, conn)
                result = comm.ExecuteScalar()
                Return result
            End Using
        Catch ex As Exception
            WriteError(String.Format("{0}:{1}", command, ex.ToString()))
            Throw
        Finally

        End Try
    End Function

    Protected Function ConvertValue(ByVal value As Object) As Object
        Dim t As String = value.GetType().Name
        Try
            Select Case t
                Case "DateTime"
                    Return Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm")
                Case Else
                    Return Convert.ToString(value)
            End Select
        Catch ex As Exception
            Throw New Exception(String.Format("{0}:{1}", value, ex.ToString()))
        End Try
    End Function

#Region "IDisposable"

    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。

                ''判斷連線是否有關閉
                'If (_Conn.State <> ConnectionState.Closed) Then
                '    _Conn.Close()
                'End If

                'If IsNothing(_Conn) = False Then
                '    _Conn = Nothing
                'End If

                'If IsNothing(_Db) = False Then
                '    _Db = Nothing
                'End If
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。            
        End If
        Me.disposedValue = True
    End Sub
#End Region

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
