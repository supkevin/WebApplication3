Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls

Public Class ucBaseCodeName
    Inherits System.Web.UI.UserControl

    Private _ShowCode As Boolean
    Private _Mode As DropDownMode
    Private _ReadOnly As Boolean
    Private _RepeatDirection As RepeatDirection
    Private _TypeNo As CodeNameType
    Private _Source As ListControl

    Public Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
        End Set
    End Property

    Public WriteOnly Property Mode() As DropDownMode
        Set(ByVal value As DropDownMode)
            _Mode = value
        End Set
    End Property

    Public Property TypeNo() As CodeNameType
        Get
            Return _TypeNo
        End Get
        Set(ByVal value As CodeNameType)
            _TypeNo = value
        End Set
    End Property

    Public Property ShowCode() As Boolean
        Get
            Return _ShowCode
        End Get
        Set(ByVal value As Boolean)
            _ShowCode = value
        End Set
    End Property

    Public Property RepeatDirection() As RepeatDirection
        Get
            Return _RepeatDirection
        End Get
        Set(ByVal value As RepeatDirection)
            _RepeatDirection = value
        End Set
    End Property

    Private Function Convert2CodeName(ByVal source As Dictionary(Of String, String)) As List(Of CodeNameViewModel)
        Dim result As New List(Of CodeNameViewModel)
        For Each u As KeyValuePair(Of String, String) In source
            result.Add(New CodeNameViewModel With {.Code = u.Key, .Name = u.Value})
        Next
        Return result
    End Function

    'Protected Function GetSource() As List(Of CodeNameViewModel)
    '    Dim result As New List(Of CodeNameViewModel)

    '    Select Case _TypeNo
    '        Case CodeNameType.ApplyTimes
    '            result = Convert2CodeName(GlobalConst.ApplyTimes)
    '        Case CodeNameType.ApplyMode
    '            result = Convert2CodeName(GlobalConst.ApplyMode)
    '        Case CodeNameType.ReviewResult
    '            result = Convert2CodeName(GlobalConst.ReviewResult)
    '        Case CodeNameType.CeremonyAttend
    '            result = Convert2CodeName(GlobalConst.CeremonyAttend)
    '        Case CodeNameType.CertificateCode
    '            result = Convert2CodeName(GlobalConst.CertificateCode)
    '        Case CodeNameType.Groups
    '            result = Convert2CodeName(GlobalConst.Groups)
    '        Case CodeNameType.Parents
    '            result = Convert2CodeName(GlobalConst.Parents)
    '        Case CodeNameType.UnqualifiedCode
    '            result = Convert2CodeName(GlobalConst.UnqualifiedCode)
    '        Case CodeNameType.Awards
    '            result = Convert2CodeName(GlobalConst.Awards)
    '        Case CodeNameType.Center
    '            result = Convert2CodeName(GlobalConst.Center)
    '        Case CodeNameType.Trauma
    '            result = Convert2CodeName(GlobalConst.Trauma)
    '        Case CodeNameType.Certificate
    '            result = Convert2CodeName(GlobalConst.Certificate)       
    '    End Select

    '    Dim txt As String = ""

    '    Select Case _Mode
    '        Case DropDownMode.SelectOne
    '            txt = "請選擇"
    '        Case DropDownMode.ShowAll
    '            txt = "全部"
    '    End Select

    '    If Not String.IsNullOrEmpty(txt) Then
    '        result.Insert(0, New CodeNameViewModel() With {.Code = "", _
    '                                                    .Name = txt})
    '    End If       
    '    Return result
    'End Function

    'Protected Function GetSource() As Dictionary(Of String, String)
    '    Dim result As New Dictionary(Of String, String)

    '    Select Case _TypeNo
    '        Case CodeNameType.ApplyTimes
    '            result = GlobalConst.ApplyTimes
    '        Case CodeNameType.ApplyMode
    '            result = GlobalConst.ApplyMode
    '        Case CodeNameType.ReviewResult
    '            result = GlobalConst.ReviewResult
    '        Case CodeNameType.CeremonyAttend
    '            result = GlobalConst.CeremonyAttend
    '        Case CodeNameType.CertificateCode
    '            result = GlobalConst.CertificateCode
    '        Case CodeNameType.Groups
    '            result = GlobalConst.Groups
    '        Case CodeNameType.Parents
    '            result = GlobalConst.Parents
    '        Case CodeNameType.UnqualifiedCode
    '            result = GlobalConst.UnqualifiedCode
    '        Case CodeNameType.Awards
    '            result = GlobalConst.Awards
    '        Case CodeNameType.Center
    '            result = GlobalConst.Center
    '        Case CodeNameType.Trauma
    '            result = GlobalConst.Trauma
    '        Case CodeNameType.Certificate
    '            result = GlobalConst.Certificate
    '    End Select

    '    Dim txt As String = ""

    '    Select Case _Mode
    '        Case DropDownMode.SelectOne
    '            txt = "請選擇"
    '        Case DropDownMode.ShowAll
    '            txt = "全部"
    '    End Select

    '    If Not String.IsNullOrEmpty(txt) Then
    '        result.Add("", txt)
    '    End If
    '    Return result
    'End Function

    Protected Function GetSource() As List(Of KeyValuePair(Of String, String))
        Dim result As New List(Of KeyValuePair(Of String, String))

        Select Case _TypeNo
            Case CodeNameType.ApplyTimes
                result.AddRange(GlobalConst.ApplyTimes)
            Case CodeNameType.ApplyMode
                result.AddRange(GlobalConst.ApplyMode)
            Case CodeNameType.ReviewResult
                result.AddRange(GlobalConst.ReviewResult)
            Case CodeNameType.CeremonyAttend
                result.AddRange(GlobalConst.CeremonyAttend)
            Case CodeNameType.CertificateCode
                result.AddRange(GlobalConst.CertificateCode)
            Case CodeNameType.Groups
                result.AddRange(GlobalConst.Groups)
            Case CodeNameType.Parents
                result.AddRange(GlobalConst.Parents)
            Case CodeNameType.UnqualifiedCode
                result.AddRange(GlobalConst.UnqualifiedCode)
            Case CodeNameType.Awards
                result.AddRange(GlobalConst.Awards)
            Case CodeNameType.Center
                result.AddRange(GlobalConst.Center)
            Case CodeNameType.Trauma
                result.AddRange(GlobalConst.Trauma)
            Case CodeNameType.Certificate
                result.AddRange(GlobalConst.Certificate)
        End Select

        Dim txt As String = ""

        Select Case _Mode
            Case DropDownMode.SelectOne
                txt = "請選擇"
            Case DropDownMode.ShowAll
                txt = "全部"
        End Select

        If Not String.IsNullOrEmpty(txt) Then
            result.Insert(0, New KeyValuePair(Of String, String)("", txt))
        End If
        Return result
    End Function


    'Protected Function GenerateListItem(ByVal info As CodeNameViewModel) As ListItem
    '    Dim template As String = "{0}-{1}"
    '    If (Me.ShowCode) Then
    '        Return New ListItem( _
    '            String.Format(template, info.Code, info.Name), info.Code)
    '    Else
    '        Return New ListItem(info.Name, info.Code)
    '    End If
    'End Function

    Protected Function GenerateListItem(ByVal info As KeyValuePair(Of String, String)) As ListItem
        Dim template As String = "{0}-{1}"
        If (Me.ShowCode) Then
            Return New ListItem( _
                String.Format(template, info.Key, info.Value), info.Value)
        Else
            Return New ListItem(info.Value, info.Key)
        End If
    End Function
End Class
