Imports Microsoft.VisualBasic
Imports System.IO.File
Imports System.IO

Public Module myPDF
    Public Sub Delete(ByVal CApplyNo As String)
        If CApplyNo = "" Then
            Exit Sub
        End If
        If IsFinish(CApplyNo) Then
            Dim FileNamePDF As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".pdf"
            Dim FileNameF As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".f"
            Dim FileNameE As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".e"
            Dim FileNameD As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".d"
            FileIO.FileSystem.DeleteFile(FileNamePDF)
            FileIO.FileSystem.DeleteFile(FileNameF)
            FileIO.FileSystem.DeleteFile(FileNameE)
            FileIO.FileSystem.DeleteFile(FileNameD)
        End If
    End Sub

    Public Function PDF_Exist(ByVal CApplyNo As String) As Boolean
        If CApplyNo = "" Then
            Return False
        End If
        '必需要有.f檔，才代表PDF產生完畢 'tc 20160705
        Dim FileNameF As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".f"
        Dim FileNamePDF As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".pdf"
        If FileIO.FileSystem.FileExists(FileNameF) And FileIO.FileSystem.FileExists(FileNamePDF) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function IsFinish(ByVal CApplyNo As String) As Boolean
        '必需下載完成
        Dim FileNameD As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".d"
        '必需email寄出
        Dim FileNameE As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + CApplyNo + ".e"
        If FileIO.FileSystem.FileExists(FileNameD) And FileIO.FileSystem.FileExists(FileNameE) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub CreateFile(ByVal FileName As String)
        'PDF下載完成後，另外產生 .d 檔做記錄。
        Dim DownLoadOKFileName As String = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + FileName
        Dim fileStream = New System.IO.FileStream(DownLoadOKFileName, FileMode.Create)
        fileStream.Close() '   //切記開了要關,不然會被佔用而無法修改喔!!
    End Sub


End Module