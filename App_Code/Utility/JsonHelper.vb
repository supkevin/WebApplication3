Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class JsonHelper

    Public Shared Function ObjectToJson(ByVal obj As Object) As String
        Return JsonConvert.SerializeObject(obj, Formatting.Indented)
    End Function

    Public Shared Function JsonToObject(Of TResult)(ByVal json As String) As Object
        Return JsonConvert.DeserializeObject(Of TResult)(json)
    End Function
End Class