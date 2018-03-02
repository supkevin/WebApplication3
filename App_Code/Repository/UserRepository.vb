Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System
Imports System.Data.SqlClient
Imports System.Data

Public Class UserRepository
    Inherits BaseRepository

    Public Function Authenticate(ByVal userID As String, ByVal password As String) As UserViewModel
        Dim temp As New List(Of UserViewModel)
        Dim result As UserViewModel = Nothing

        Dim sql As String = "SELECT * " _
                            + " FROM [User] WITH(NOLOCK)" _
                            + " Where 1=1 " _
                            + " AND [User_ID]='{0}' AND [Password]='{1}'"

        sql = String.Format(sql, userID, password)

        temp = MyBase.GetObjectList(Of UserViewModel)(sql)
        If temp.Count > 0 Then
            result = temp(0)
        End If

        Return result
    End Function
End Class
