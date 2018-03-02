Imports Microsoft.VisualBasic

Public Class CustomDataAttribute : Inherits Attribute
    Private _name As String

    Public Sub New(ByVal name As String)
        Me.Name = name
    End Sub

    Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property
End Class
