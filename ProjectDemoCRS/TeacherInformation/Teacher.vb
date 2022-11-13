Imports System.Data.OleDb
Public Class Teacher
    Friend Structure TeacherRecord
        Dim teacherID, ic, name, phone, email As String
        Dim dob As Date
    End Structure

    Private con As New OleDb.OleDbConnection
    Friend Function getTeacherRecord(teacherID) As TeacherRecord
        Dim dr As OleDbDataReader
        Dim teacherRec As New TeacherRecord
        Try
            Dim sql As String
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()
            sql = "select * FROM teacher WHERE (TeacherID = '" & teacherID & "')"
            MessageBox.Show(sql)
            Debug.WriteLine(sql)
            Dim cmd As New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                teacherRec.teacherID = dr("TeacherID").ToString
                teacherRec.ic = dr("icNumber").ToString
                teacherRec.name = dr("name").ToString
                teacherRec.phone = dr("phoneNumber").ToString
                teacherRec.email = dr("email").ToString
                teacherRec.dob = dr("dateOfBirth")
                con.Close()
                Return teacherRec
            End If
        Catch
            MessageBox.Show("Error accessing student record for student with matric :" & teacherID)
            con.Close()
            Return teacherRec
        End Try
        Return teacherRec
    End Function
End Class
