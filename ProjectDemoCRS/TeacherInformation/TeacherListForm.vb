Public Class TeacherListForm
    Public conn As New OleDb.OleDbConnection
    Dim ds As New DataSet
    Dim dataAdapter As New OleDb.OleDbDataAdapter

    Dim sqlString As String
    Dim mIDString As String
    Dim teacherMdl As New Teacher

    Private Sub TeacherListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disableButton()

        'you can use multiple option in connecting to the database - the following are 3 example to set the connection string
        ' conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\ihsanTuitionCenterDb.accdb"
        conn.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
        ' conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\UTM\SEM I20212022\DDWC2653 VBNetLabDemo
        '\DemoProject\ProjectDemoCRS\ProjectDemoCRS\bin\Debug\ihsanTuitionCenterDb.accdb"

        Try
            'opens the connection
            conn.Open()
            If conn.State = ConnectionState.Open Then
                MsgBox("MS Database Connected!")
                displayAllTeacher()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'close the connection
        conn.Close()
    End Sub
    Private Sub disableButton()
        With Me
            .AddTeacherButton.Enabled = False
            .updateTeacherButton.Enabled = False
            .DeleteTeacherButton.Enabled = False
            .RegistrationButton.Enabled = False
        End With
    End Sub
    Private Sub enableButton()
        With Me
            .AddTeacherButton.Enabled = True
            .updateTeacherButton.Enabled = True
            .DeleteTeacherButton.Enabled = True
            .RegistrationButton.Enabled = True
        End With
    End Sub
    Private Sub displayAllTeacher()
        clearStudentGrid()
        sqlString = "Select * from teacher"
        dataAdapter = New OleDb.OleDbDataAdapter(sqlString, conn)
        dataAdapter.Fill(ds, "ihsanTuitionCenterDb")
        Me.StudentDataGridView.DataMember = "ihsanTuitionCenterDb"
        StudentDataGridView.DataSource = ds
    End Sub
    Private Sub clearStudentGrid()
        Me.ds.Clear() 'clear the original data
    End Sub
End Class