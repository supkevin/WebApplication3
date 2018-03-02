Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.Net
Imports System.IO
Imports System


Public Class GDataBase


    Dim Wlog As New WriteLog

    Public Function DBConnection() As SqlConnection
        'Dim SQL_DB_NAME = setupDB.Default.SQL_DB_NAME
        'Dim SQL_SERVER_NAME = setupDB.Default.SQL_SERVER_NAME
        'Dim SQL_ID = setupDB.Default.SQL_ID
        'Dim SQL_PASSWORD = setupDB.Default.SQL_PASSWORD
        'Dim connStr As String = "Database=" & SQL_DB_NAME & ";" & _
        '    "Data Source=" & SQL_SERVER_NAME & ";" & _
        '    "User Id=" & SQL_ID & ";Password=" & SQL_PASSWORD
        Dim connection As New SqlConnection
        Dim ConnStr As String
        ConnStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Try
            connection.ConnectionString = ConnStr
            connection.Open()

            Return connection
        Catch ex As Exception
            Wlog.WriteErrMsg(ex.Message.ToString)
            connection = Nothing
            Return connection
        End Try

    End Function



#Region "通用函數"

    Public Function DataReader(ByVal SqlCommand As String, ByVal connection As SqlConnection) As SqlDataReader
        'tc v2 add
        If connection Is Nothing Then
            Me.DBConnection()
        End If
        'tc v2 end

        Dim Comm As New SqlCommand(SqlCommand, connection)
        Dim wDataReader As SqlDataReader
        Try
            wDataReader = Comm.ExecuteReader()
        Catch ex As Exception
            Wlog.WriteErrMsg(ex.Message.ToString)
            Throw
        End Try

        DataReader = wDataReader

    End Function
    Public Function SqlDataSet(ByVal SqlCommand As String, ByVal connection As SqlConnection) As DataSet
        'tc v2 add
        If connection Is Nothing Then
            Me.DBConnection()
        End If
        'tc v2 end

        Dim Comm As New SqlCommand(SqlCommand, connection)
        Dim wDataReader As SqlDataAdapter = New SqlDataAdapter(Comm)
        Dim objDS As DataSet = New DataSet()
        wDataReader.Fill(objDS)

        SqlDataSet = objDS
    End Function
    Public Function GetValue(ByVal SqlCommand As String, ByVal connection As SqlConnection) As String

        Dim dr As SqlDataReader = DataReader(SqlCommand, connection)
        GetValue = ""
        If dr.Read() Then
            'tc v2 避免null值
            GetValue = dr(0).ToString()
        End If
        dr.Close()
        'tc v2 add
        Me.DBClose(connection)
    End Function


    Public Function DataReaderCK(ByVal Conn As SqlConnection, ByVal SqlStr As String) As Boolean

        If SqlStr.Trim() = String.Empty Then
            Return False
        End If

        Dim Comm As SqlCommand = New SqlCommand(SqlStr, Conn)
        Dim Sr As SqlDataReader

        Sr = Comm.ExecuteReader()

        If Sr.Read() Then
            DataReaderCK = True
        Else
            DataReaderCK = False
        End If
        Sr.Close()
        Comm.Dispose()
    End Function
    Function ExecuteQuery(ByVal SqlCommand As String, ByVal connection As SqlConnection) As Integer
        'tc v2 add
        If connection Is Nothing Then
            Me.DBConnection()
        End If
        'tc v2 end

        Dim cmd As SqlCommand = New SqlCommand(SqlCommand, connection)

        Try
            cmd.ExecuteNonQuery() 'Executes SQL Commands Non-Querys only
        Catch ex As Exception
            Wlog.WriteErrMsg(ex.Message.ToString)
        End Try

        'tc v2 add
        Me.DBClose(connection)

    End Function
    Public Sub DBClose(ByVal connection As SqlConnection)
        'tc v2 add
        If connection Is Nothing Then
            Exit Sub
        End If
        'tc v2 end 
        connection.Close()
        'tc v2 必須多加dispose
        'connection.Dispose()
        connection = Nothing
    End Sub

    Public Function SqlReader(ByVal SqlCommand As String, ByVal connection As SqlConnection) As DataTable
        'tc v2 add
        If connection Is Nothing Then
            Me.DBConnection()
        End If
        'tc v2 end

        Dim Command As New SqlClient.SqlCommand(SqlCommand, connection)
        Dim wSqlReader As SqlDataReader

        Try
            wSqlReader = Command.ExecuteReader()
        Catch ex As Exception
            Wlog.WriteErrMsg(ex.Message.ToString)
            Return New DataTable
        End Try

        Dim dt As New DataTable()
        dt.Load(wSqlReader)

        'tc v2 add
        SqlReader = dt
        Me.DBClose(connection)
    End Function
#End Region

End Class

Module vbGDataBase
    Public Sub fExecuteSQL(ByVal strSQL As String, ByVal connection As SqlConnection)
        Dim db As New GDataBase
        db.DBConnection()
        db.ExecuteQuery(strSQL, connection)
        db.DBClose(connection)
    End Sub

    Public Function fGetValue(ByVal strSQL As String, ByVal connection As SqlConnection) As String
        Dim result As String
        Dim db As New GDataBase
        db.DBConnection()
        result = db.GetValue(strSQL, connection)
        db.DBClose(connection)
        Return result
    End Function
End Module
