Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlClient

Public Module DBHelper

    Private Function ConverDBNull(ByVal value As Object) As Object
        Return New Object
    End Function

    Private Function ConvertValue(ByVal value As Object) As Object
        Dim t As String = value.GetType().Name
        Try
            Select Case t
                Case "DateTime"
                    Return Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss")
                Case Else
                    Return Convert.ToString(value)
            End Select
        Catch ex As Exception
            Throw New Exception(String.Format("{0}:{1}", value, ex.ToString()))
        End Try
    End Function

    Public Function DataTableToList(Of TResult As Class)(ByVal table As DataTable) As List(Of TResult)
        Dim result As List(Of TResult) = New List(Of TResult)()
        Dim message As New List(Of String)
        Dim t As Type = GetType(TResult)

        Dim props = t.GetProperties()

        For Each dr As DataRow In table.Rows
            '泛型
            Dim tr As TResult = Activator.CreateInstance(Of TResult)()

            '依據有的欄位對照欄位,欄位名稱與類別屬性要一致
            For Each f As PropertyInfo In props
                '
                If (f.Name = "Last_Update") Then Continue For

                Dim value As Object = dr(f.Name)

                'TODO:要依型別做預設值轉換,轉為Nothing目前OK
                If value Is DBNull.Value Then value = Nothing

                Try
                    t.InvokeMember(f.Name, BindingFlags.SetProperty, Nothing, tr, New Object() {value})
                Catch ex As Exception
                    message.Add(String.Format("{0}-{1}:{2}", t.Name, f.Name, ex.ToString()))
                End Try
            Next

            '設定欄位值
            For Each f As MemberInfo In t.GetFields()
                '
                If (f.Name = "Last_Update") Then Continue For

                Dim value As Object = dr(f.Name)

                'TODO:要依型別做預設值轉換,轉為Nothing目前OK
                If value Is DBNull.Value Then value = Nothing

                Try
                    t.InvokeMember(f.Name, BindingFlags.SetField, Nothing, tr, New Object() {value})
                Catch ex As Exception
                    message.Add(String.Format("{0}-{1}:{2}", t.Name, f.Name, ex.ToString()))
                End Try
            Next

            result.Add(tr)
        Next

        If message.Count <> 0 Then
            Throw New Exception(String.Join(";", message.ToArray()))
        End If

        Return result
    End Function
    Public Function GetFields(Of TResult As Class)(ByVal source As TResult, Optional ByVal type As Integer = 1) As String
        Dim sb As New StringBuilder
        Dim message As New List(Of String)
        Dim t As Type = GetType(TResult)
        Dim members = t.GetProperties()
        Dim value As Object

        For Each f As PropertyInfo In members
            value = _
            t.InvokeMember(f.Name, BindingFlags.GetProperty, System.Type.DefaultBinder, source, New Object() {})

            '沒值
            If IsNothing(value) Then Continue For

            Try
                Select Case type
                    Case 0
                        sb.AppendFormat(" {0},", f.Name)
                    Case 1
                        sb.AppendFormat(" {0}='{1}',", f.Name, ConvertValue(value))
                End Select
            Catch ex As Exception
                message.Add(String.Format("{0}-{1}:{2}", t.Name, f.Name, ex.ToString()))
            End Try
        Next

        Return sb.ToString()
    End Function

#Region "old version"
    'Public Function DataTableToList(Of TResult As Class)(ByVal table As DataTable) As List(Of TResult)
    '    Dim result As List(Of TResult) = New List(Of TResult)()
    '    Dim t As Type = GetType(TResult)
    '    'Dim m = t.GetMembers(BindingFlags.Public)
    '    Dim members = t.GetFields()

    '    Dim message As New List(Of String)

    '    For Each dr As DataRow In table.Rows
    '        '泛型
    '        Dim tr As TResult = Activator.CreateInstance(Of TResult)()

    '        '依據有的欄位對照欄位,欄位名稱與類別屬性要一致
    '        For Each f As FieldInfo In members
    '            Dim value As Object = dr(f.Name)

    '            'TODO:要依型別做預設值轉換
    '            If value Is DBNull.Value Then
    '                value = ""
    '            End If

    '            Try
    '                't.InvokeMember(f.Name, BindingFlags.SetField, System.Type.DefaultBinder, tr, New Object() {value})
    '                t.InvokeMember(f.Name, BindingFlags.SetField, Nothing, tr, New Object() {value})
    '            Catch ex As Exception
    '                message.Add(String.Format("{0}-{1}:{2}", t.Name, f.Name, ex.ToString()))
    '            End Try
    '        Next

    '        result.Add(tr)
    '    Next

    '    If message.Count <> 0 Then
    '        Throw New Exception(String.Join(";", message.ToArray()))
    '    End If

    '    Return result
    'End Function

    'Public Function GetFields(Of TResult As Class)(ByVal source As TResult, Optional ByVal type As Integer = 1) As String
    '    Dim sb As New StringBuilder
    '    Dim message As New List(Of String)
    '    Dim t As Type = GetType(TResult)
    '    Dim members = t.GetFields()
    '    Dim value As Object

    '    For Each f As FieldInfo In members
    '        value = _
    '        t.InvokeMember(f.Name, BindingFlags.GetField, System.Type.DefaultBinder, source, New Object() {})

    '        '沒值
    '        If IsNothing(value) Then Continue For

    '        Try
    '            Select Case type
    '                Case 0
    '                    sb.AppendFormat(" {0},", f.Name)
    '                Case 1
    '                    sb.AppendFormat(" {0}='{1}',", f.Name, ConvertValue(value))
    '            End Select
    '        Catch ex As Exception
    '            message.Add(String.Format("{0}-{1}:{2}", t.Name, f.Name, ex.ToString()))
    '        End Try
    '    Next

    '    Return sb.ToString()
    'End Function
#End Region
End Module
