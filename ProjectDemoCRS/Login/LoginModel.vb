Public Class LoginModel
    Dim conn As New OleDb.OleDbConnection
    Dim sqlStr As String
    Public Function checkLogin(user As UserClass) As Boolean
        conn.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName


        If user.userName = "" Or user.password = "" Then
            MessageBox.Show("Enter All Credentials")
        End If

        sqlStr = "Select * FROM userTbl where userName='" & user.userName & "' and password='" & user.password & "'"
        conn.Open()

        Dim cmd1 As New OleDb.OleDbCommand(sqlStr, conn)
        Dim dr As OleDb.OleDbDataReader

        dr = cmd1.ExecuteReader

        If dr.Read Then
            MessageBox.Show("Successfully logged in")
            conn.Close()
            Return True
        Else
            MessageBox.Show("Wrong Credentials, try again")
            conn.Close()
            Return False
        End If

        Return False
    End Function
End Class
