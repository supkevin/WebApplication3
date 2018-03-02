Imports Microsoft.VisualBasic

Public Enum DropDownMode
    None = 0
    SelectOne
    ShowAll
End Enum

Public Enum CodeNameType
    Awards = 0
    ApplyTimes
    ApplyMode
    Center
    CeremonyAttend
    Certificate
    CertificateCode
    Groups
    Parents
    Progress
    ReviewResult
    Trauma
    UnqualifiedCode
End Enum

Public Class GlobalConst
    Private Shared _Groups As Dictionary(Of String, String)
    Private Shared _ApplyTimes As Dictionary(Of String, String)
    Private Shared _ReviewResult As Dictionary(Of String, String)
    Private Shared _CertificateCode As Dictionary(Of String, String)
    Private Shared _Ceremony As Dictionary(Of String, String)
    Private Shared _UnqualifiedCode As Dictionary(Of String, String)
    Private Shared _Parents As Dictionary(Of String, String)
    Private Shared _ApplyMode As Dictionary(Of String, String)
    Private Shared _Awards As Dictionary(Of String, String)
    Private Shared _Center As Dictionary(Of String, String)
    Private Shared _Trauma As Dictionary(Of String, String)
    Private Shared _Certificate As Dictionary(Of String, String)
    Private Shared _Sex As Dictionary(Of String, String)
    Private Shared _Progress As Dictionary(Of String, String)

    Private Sub New() ' In this case, the Sub does nothing 

    End Sub

    Public Shared ReadOnly Property Groups() As Dictionary(Of String, String)
        Get
            If _Groups Is Nothing Then
                _Groups = New Dictionary(Of String, String)
                _Groups.Add("1", "國小組")
                _Groups.Add("2", "國中組")
                _Groups.Add("3", "高中組")
                _Groups.Add("4", "大專組(不含五專1~3年級)")
                _Groups.Add("5", "研究所碩士班")
                _Groups.Add("6", "博士班")
            End If
            Return _Groups
        End Get
    End Property

    Public Shared ReadOnly Property ApplyTimes() As Dictionary(Of String, String)
        Get
            If _ApplyTimes Is Nothing Then
                _ApplyTimes = New Dictionary(Of String, String)
                _ApplyTimes.Add("1", "初次申請")
                _ApplyTimes.Add("2", "多次申請")
            End If
            Return _ApplyTimes
        End Get
    End Property

    Public Shared ReadOnly Property ReviewResult() As Dictionary(Of String, String)
        Get
            If _ReviewResult Is Nothing Then
                _ReviewResult = New Dictionary(Of String, String)
                _ReviewResult.Add("Y", "合格")
                _ReviewResult.Add("N", "不合格")
            End If
            Return _ReviewResult
        End Get
    End Property

    Public Shared ReadOnly Property CertificateCode() As Dictionary(Of String, String)
        Get
            If _CertificateCode Is Nothing Then
                _CertificateCode = New Dictionary(Of String, String)
                _CertificateCode.Add("Y", "資料齊全")
                _CertificateCode.Add("N", "資料未齊備")
            End If
            Return _CertificateCode
        End Get
    End Property
    Public Shared ReadOnly Property CeremonyAttend() As Dictionary(Of String, String)
        Get
            If _Ceremony Is Nothing Then
                _Ceremony = New Dictionary(Of String, String)
                _Ceremony.Add("Y", "出席")
                _Ceremony.Add("N", "未出席")
            End If
            Return _Ceremony
        End Get
    End Property
    Public Shared ReadOnly Property UnqualifiedCode() As Dictionary(Of String, String)
        Get
            If _UnqualifiedCode Is Nothing Then
                _UnqualifiedCode = New Dictionary(Of String, String)
                _UnqualifiedCode.Add("0", "無")
                _UnqualifiedCode.Add("1", "申請逾時")
                _UnqualifiedCode.Add("2", "申請文件不齊備")
                _UnqualifiedCode.Add("3", "成績未達標準")
                _UnqualifiedCode.Add("4", "資格不符")
                _UnqualifiedCode.Add("5", "非本會服務對象")
            End If
            Return _UnqualifiedCode
        End Get
    End Property

    Public Shared ReadOnly Property ApplyMode() As Dictionary(Of String, String)
        Get
            If _ApplyMode Is Nothing Then
                _ApplyMode = New Dictionary(Of String, String)
                _ApplyMode.Add("1", "自行申請")
                _ApplyMode.Add("2", "單位推薦")
            End If
            Return _ApplyMode
        End Get
    End Property

    Public Shared ReadOnly Property Parents() As Dictionary(Of String, String)
        Get
            If _Parents Is Nothing Then
                _Parents = New Dictionary(Of String, String)
                _Parents.Add("1", "父")
                _Parents.Add("2", "母")
            End If
            Return _Parents
        End Get
    End Property

    Public Shared ReadOnly Property Awards() As Dictionary(Of String, String)
        Get
            If _Awards Is Nothing Then
                _Awards = New Dictionary(Of String, String)
                Using res As New CodeNameRepository(CodeNameType.Awards)
                    For Each u In res.GetAll()
                        _Awards.Add(u.Code, u.Name)
                    Next
                End Using
            End If
            Return _Awards
        End Get
    End Property
    Public Shared ReadOnly Property Center() As Dictionary(Of String, String)
        Get
            If _Center Is Nothing Then
                _Center = New Dictionary(Of String, String)
                Using res As New CodeNameRepository(CodeNameType.Center)
                    For Each u In res.GetAll()
                        _Center.Add(u.Code, u.Name)
                    Next
                End Using
            End If
            Return _Center
        End Get
    End Property

    Public Shared ReadOnly Property Progress() As Dictionary(Of String, String)
        Get
            If _Progress Is Nothing Then
                _Progress = New Dictionary(Of String, String)
                Using res As New CodeNameRepository(CodeNameType.Progress)
                    For Each u In res.GetAll()
                        _Progress.Add(u.Code, u.Name)
                    Next
                End Using
            End If
            Return _Progress
        End Get
    End Property
    Public Shared ReadOnly Property Trauma() As Dictionary(Of String, String)
        Get
            If _Trauma Is Nothing Then
                _Trauma = New Dictionary(Of String, String)
                Using res As New CodeNameRepository(CodeNameType.Trauma)
                    For Each u In res.GetAll()
                        _Trauma.Add(u.Code, u.Name)
                    Next
                End Using
            End If
            Return _Trauma
        End Get
    End Property
    Public Shared ReadOnly Property Certificate() As Dictionary(Of String, String)
        Get
            If _Certificate Is Nothing Then
                _Certificate = New Dictionary(Of String, String)
                Using res As New CodeNameRepository(CodeNameType.Certificate)
                    For Each u In res.GetAll()
                        _Certificate.Add(u.Code, u.Name)
                    Next
                End Using
            End If
            Return _Certificate
        End Get
    End Property
    Public Shared ReadOnly Property Sex() As Dictionary(Of String, String)
        Get
            If _Sex Is Nothing Then
                _Sex = New Dictionary(Of String, String)
                _Sex.Add("M", "男")
                _Sex.Add("F", "女")
            End If
            Return _Sex
        End Get
    End Property

    ''' <summary>
    ''' 唯讀TextBox樣式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property StyleUnderLine() As String
        Get
            Return "border-style:none;border-bottom-style:solid;border-width:thin;background-color:Transparent;"
        End Get
    End Property

    Private Shared Function ConvertNameValue( _
            ByVal source As Dictionary(Of String, String), ByVal wanted As String) As String

        Dim result As String = ""
        Dim target As KeyValuePair(Of String, String) = _
                  ( _
                   From u In source _
                   Where u.Key = wanted _
                   Select u _
                   ).FirstOrDefault

        If IsNothing(target) = False Then
            result = target.Value
        End If

        Return result
    End Function

    Public Shared Function ConvertApplyTimes(ByVal value As String) As String
        Return ConvertNameValue(GlobalConst.ApplyTimes, value)
    End Function

    Public Shared Function ConvertGroups(ByVal value As String) As String
        Return ConvertNameValue(GlobalConst.Groups, value)
    End Function

    Public Shared Function ConvertReviewResult(ByVal value As String) As String
        Return ConvertNameValue(GlobalConst.ReviewResult, value)
    End Function
    Public Shared Function ConvertCertificateCode(ByVal value As String) As String
        Return ConvertNameValue(GlobalConst.CertificateCode, value)
    End Function
    Public Shared Function ConvertApplyMode(ByVal value As String) As String
        Return ConvertNameValue(GlobalConst.ApplyMode, value)
    End Function

    Public Shared Function ConvertAwards(ByVal value As String) As String

        Return ConvertNameValue(GlobalConst.Awards, value)
    End Function
    Public Shared Function ConvertSex(ByVal value As String) As String

        Return ConvertNameValue(GlobalConst.Sex, value)
    End Function

    Public Shared Function ConvertProgress(ByVal value As String) As String
        Return ConvertNameValue(GlobalConst.Progress, value)
    End Function
End Class