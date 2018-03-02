Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions
Imports System

Public Class CkString
    Function CkChar(ByVal Cstring As String) As String
        Dim Nstring As String = String.Empty
        Nstring = Regex.Replace(Cstring, "%", "")
        Nstring = Regex.Replace(Nstring, "/", "")
        Nstring = Regex.Replace(Nstring, "\?", "")
        ' Nstring = Regex.Replace(Nstring, "-", "")
        Nstring = Regex.Replace(Nstring, "'", "")
        Nstring = Regex.Replace(Nstring, "=", "")
        Nstring = Regex.Replace(Nstring, " ", "")
        Nstring = Regex.Replace(Nstring, """", "")
        Nstring = Regex.Replace(Nstring, "&", "")
        Nstring = Regex.Replace(Nstring, "\*", "")
        CkChar = Nstring
    End Function
    Function CkOtherChar(ByVal Cstring As String) As String
        Dim Nstring As String = String.Empty
        Nstring = Regex.Replace(Cstring, "%", "")
        Nstring = Regex.Replace(Nstring, "/", "")
        Nstring = Regex.Replace(Nstring, "\?", "")
        'Nstring = Regex.Replace(Nstring, "-", "")
        Nstring = Regex.Replace(Nstring, "'", "")
        Nstring = Regex.Replace(Nstring, "=", "")
        Nstring = Regex.Replace(Nstring, " ", "")
        Nstring = Regex.Replace(Nstring, """", "")
        Nstring = Regex.Replace(Nstring, "&", "")
        Nstring = Regex.Replace(Nstring, "\*", "")
        CkOtherChar = Nstring
    End Function
    Function CkUid(ByRef UserId As String) As String '檢查身分證字號
        Dim Ck_String As Integer() = New Integer(9) {}
        Dim CkCount As Integer

        If UserId.Length = 10 Then
            UserId = UserId.ToUpper()
            For i As Integer = 1 To UserId.Length - 1
                Ck_String(i) = Convert.ToInt32(UserId.Substring(i, 1))
            Next

            Select Case UserId.Substring(0, 1).ToUpper()
                Case "A"
                    Ck_String(0) = 10
                    Exit Select
                Case "B"
                    Ck_String(0) = 11
                    Exit Select
                Case "C"
                    Ck_String(0) = 12
                    Exit Select
                Case "D"
                    Ck_String(0) = 13
                    Exit Select
                Case "E"
                    Ck_String(0) = 14
                    Exit Select
                Case "F"
                    Ck_String(0) = 15
                    Exit Select
                Case "G"
                    Ck_String(0) = 16
                    Exit Select
                Case "H"
                    Ck_String(0) = 17
                    Exit Select
                Case "I"
                    Ck_String(0) = 34
                    Exit Select
                Case "J"
                    Ck_String(0) = 18
                    Exit Select
                Case "K"
                    Ck_String(0) = 19
                    Exit Select
                Case "L"
                    Ck_String(0) = 20
                    Exit Select
                Case "M"
                    Ck_String(0) = 21
                    Exit Select
                Case "N"
                    Ck_String(0) = 22
                    Exit Select
                Case "O"
                    Ck_String(0) = 35
                    Exit Select
                Case "P"
                    Ck_String(0) = 23
                    Exit Select
                Case "Q"
                    Ck_String(0) = 24
                    Exit Select
                Case "R"
                    Ck_String(0) = 25
                    Exit Select
                Case "S"
                    Ck_String(0) = 26
                    Exit Select
                Case "T"
                    Ck_String(0) = 27
                    Exit Select
                Case "U"
                    Ck_String(0) = 28
                    Exit Select
                Case "V"
                    Ck_String(0) = 29
                    Exit Select
                Case "W"
                    Ck_String(0) = 32
                    Exit Select
                Case "X"
                    Ck_String(0) = 30
                    Exit Select
                Case "Y"
                    Ck_String(0) = 31
                    Exit Select
                Case "Z"
                    Ck_String(0) = 32
                    Exit Select
            End Select

            If Ck_String(1) = 1 OrElse Ck_String(1) = 2 Then
                CkCount = ((Ck_String(0) \ 10) * 1) + ((Ck_String(0) Mod 10) * 9)
                Dim k As Integer = 8

                For j As Integer = 1 To 8
                    CkCount += Ck_String(j) * k
                    k -= 1
                Next

                CkCount += Ck_String(9)

                If CkCount Mod 10 <> 0 Then
                    Return "X 不正確"
                Else
                    Return "V 正確"
                End If
            Else
                Return "X 第2碼錯誤"
            End If
        Else
            Return "X 長度錯誤"

        End If
    End Function
    Function CkIsNumber(ByVal Ckstr As String) As String '檢查是否為數字,y是n否
        Dim Result As String = "y"
        Dim IsNum As Integer

        If Ckstr.Trim() = String.Empty Then
            Result = "n"
            Return Result
        Else
            For i As Integer = 0 To Ckstr.Length - 1
                If Not Integer.TryParse(Ckstr.Substring(i, 1), IsNum) Then '檢查是否為數字
                    Result = "n"
                    Exit For
                End If
            Next
            Return Result
        End If
    End Function
End Class

