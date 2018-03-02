Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System
Imports System.Data.SqlClient
Imports System.Data

Public Class ZipRepository
    Inherits BaseRepository

    Public Function GetAll() As List(Of ZipViewModel)                
        Return MyBase.GetObjectList(Of ZipViewModel)("SELECT * FROM Zip")
    End Function

    Public Function GetByKey(ByVal zipCode As String) As ZipViewModel
        Dim result As New ZipViewModel
        Dim sql As String = String.Format("SELECT * FROM Zip Where Zip_Code='{0}'", zipCode)
        Dim temp = MyBase.GetObjectList(Of ZipViewModel)(sql)
        If temp.Count > 0 Then
            result = temp(0)
        End If
        Return result
    End Function

    Public Function GetCounty() As List(Of CountyViewModel)        
        Dim sql As String = "SELECT DISTINCT County_Code, County_Name FROM Zip"
        Return MyBase.GetObjectList(Of CountyViewModel)(sql)
    End Function

    Public Function GetTown(ByVal county As String) As List(Of ZipViewModel)
        Dim sql As String = "SELECT * " & _
                            " FROM Zip" & _
                            " WHERE County_Name='{0}'"

        Return MyBase.GetObjectList(Of ZipViewModel)(String.Format(sql, county))
    End Function
End Class
