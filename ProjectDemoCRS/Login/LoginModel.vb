Imports System.Data.SqlClient
Public Class LoginModel

    Dim conn As New SqlConnection("Data Source=C:\Users\user\Documents\VB\PROJECT\ProjectDemoCRS1.1\ProjectDemoCRS\bin\Debug\ihsanTuitionCenterDb.accdb")
    Public Function checkLogin(user As UserClass) As Boolean

        Return True
    End Function
End Class
