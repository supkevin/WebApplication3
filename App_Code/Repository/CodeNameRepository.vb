Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System
Imports System.Data.SqlClient
Imports System.Data

Public Class CodeNameRepository
    Inherits BaseRepository

    Private _Type As CodeNameType

    'Private Sub New()
    'End Sub

    Public Sub New(ByVal type As CodeNameType)
        _Type = type
    End Sub

    Public Function GetAll() As List(Of CodeNameViewModel)
        Dim command As String = ""

        Select Case _Type
            Case CodeNameType.Awards
                command = "SELECT Award_Code AS Code, Award_Name AS Name FROM Award"
            Case CodeNameType.Center
                command = "SELECT Center_Code AS Code, Center_Name AS Name FROM Center"
            Case CodeNameType.Trauma
                command = "SELECT Trauma_Code AS Code, Trauma_Name AS Name FROM Trauma"
            Case CodeNameType.Certificate
                command = "SELECT Certificate_Code AS Code, Certificate_Name AS Name FROM Certificate"
            Case CodeNameType.Progress
                command = "SELECT Status_Code AS Code, Status_Content AS Name FROM Progress"
        End Select

        Return MyBase.GetObjectList(Of CodeNameViewModel)(command)
    End Function
End Class
