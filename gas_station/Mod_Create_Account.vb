Imports System.Data.SQLite

Module Mod_Create_Account
    Dim sqliteDataAdapter As SQLiteDataAdapter

    Dim dataSet As DataSet


    Public Sub Create_Account(ByVal firstname As String, ByVal lastname As String, ByVal userName As String, ByVal passWord As String, ByVal usertype_id As Integer, ByVal status_id As Integer)

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("INSERT INTO tbl_user VALUES(null,'" & firstname & "','" & lastname & "','" & userName & "','" & passWord & "'," & usertype_id & "," & status_id & ")", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "tbl_user")

            MessageBox.Show("Created Successfully!")

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)

        Finally

            SQLite_Close_Connection()

        End Try

    End Sub
    Public Sub Load_User()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT tbl_user.user_id AS 'ID',tbl_usertype.usertype, tbl_user.firstname AS 'FIRST NAME', tbl_user.lastname AS 'LAST NAME', tbl_status.statuses AS 'STATUS'
                                                    FROM tbl_user INNER JOIN tbl_usertype ON tbl_usertype.usertype_id = tbl_user.usertype_id INNER JOIN tbl_status ON tbl_status.status_id = tbl_user.status_id", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "tbl_user")

            Form_Manage_User.dgvUser.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)
            SQLite_Close_Connection()
        End Try

    End Sub
    Public Sub Toggle_User_Status(ByVal user_id As Integer)
        Try
            SQLite_Open_Connection()
            dataSet = New DataSet
            Dim currentUserstatus, newUserstatus As Integer

            Using cmd As New SQLiteCommand("SELECT status_id FROM tbl_user WHERE user_id = @user_id", sqliteConnection)
                cmd.Parameters.AddWithValue("@user_id", user_id)
                currentUserstatus = CInt(cmd.ExecuteScalar())
            End Using


            If currentUserstatus = 2 Then
                newUserstatus = 1
            Else
                newUserstatus = 2
            End If

            Using cmd As New SQLiteCommand("UPDATE tbl_user SET status_id = @newUserstatus WHERE user_id = @user_id", sqliteConnection)
                cmd.Parameters.AddWithValue("@newUserstatus", newUserstatus)
                cmd.Parameters.AddWithValue("@user_id", user_id)
                cmd.ExecuteNonQuery()
            End Using

            If newUserstatus = 2 Then
                MessageBox.Show("User Disabled.")
            Else
                MessageBox.Show("User Enabled.")
            End If

        Catch ex As SQLiteException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub
End Module
