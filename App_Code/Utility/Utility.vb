
Public Module Utility

    Public DATE_FORMAT As String = "yyyy-MM-dd"
    Public DATE_TIME_FORMAT As String = "yyyy-MM-dd HH:mm:ss"

    Public Function HexStringToInt(ByVal value As String) As Integer
        Dim result As Integer = 0
        If value.ToUpper().StartsWith("0X") Then
            'value = value.Substring(2)
            value = value.ToUpper().Replace("0X", "")
        End If
        'Return Int32.Parse(value, System.Globalization.NumberStyles.HexNumber)
        result = Integer.Parse(value, System.Globalization.NumberStyles.HexNumber)
        Return result
    End Function

    Public Function ReplaceNewLine(ByVal remark As String) As String
        Dim result As String = ""
        result = remark.Replace("\n", "<br/>")
        result = result.Replace("\r", "<br/>").Replace(vbNewLine, "<br/>")
        Return result
    End Function

    Public Function ConvertDateTimeString(ByVal d As DateTime?) As String
        Dim result As String = ""
        If d.HasValue Then
            result = d.Value.ToString(Utility.DATE_TIME_FORMAT)
        End If
        Return result
    End Function

    Public Function ConvertDateString(ByVal d As DateTime?) As String
        Dim result As String = ""
        If d.HasValue Then
            result = d.Value.ToString(Utility.DATE_FORMAT)
        End If
        Return result
    End Function

    'Public Function Convert2Date(ByVal d As String) As Date
    '    If String.IsNullOrEmpty(d) Then Return Nothing
    '    Return CType(d, Date)
    'End Function

    Public Function Convert2Date(ByVal d As String) As Date?
        If String.IsNullOrEmpty(d) Then Return Nothing
        Return CType(d, Date)
    End Function

    Public Function Convert2DateTime(ByVal d As String) As DateTime?
        If String.IsNullOrEmpty(d) Then Return Nothing
        Return CType(d, DateTime)
    End Function

    Public Function Convert2Decimal(ByVal d As String) As Decimal
        If String.IsNullOrEmpty(d) Then Return 0
        Return CType(d, Decimal)
    End Function
End Module
