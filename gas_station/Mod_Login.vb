Imports System.Data.SQLite

Module Mod_Login
    Public LoggedInUserId, LoggedInusertypeId, LoggedInuserstatus As Integer
    Public LoggedInusertype As String

    Public Function ValidateLogin(username As String, password As String) As Boolean
        Try
            SQLite_Open_Connection()
            Dim query As String = "SELECT tbl_user.user_id, tbl_user.firstname, tbl_user.lastname, tbl_user.username, tbl_user.password, tbl_user.usertype_id,tbl_usertype.usertype, tbl_user.status_id FROM tbl_user
            INNER JOIN tbl_usertype ON tbl_usertype.usertype_id = tbl_user.usertype_id 
            WHERE tbl_user.username = @username AND tbl_user.password = @password AND tbl_user.status_id != 0"
            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)

                Dim reader As SQLiteDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    If Not reader.IsDBNull(reader.GetOrdinal("user_id")) Then
                        LoggedInUserId = Convert.ToInt32(reader("user_id"))
                        Form_Main.txtUserID.Text = LoggedInUserId
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("usertype_id")) Then
                        LoggedInusertypeId = Convert.ToInt32(reader("usertype_id"))
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("usertype")) Then
                        LoggedInusertype = Convert.ToString(reader("usertype"))

                        'Form_Main.txtUsertype.Text = LoggedInusertype
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("status_id")) Then
                        LoggedInuserstatus = Convert.ToInt32(reader("status_id"))
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("firstname")) Then
                        Dim firstName As String = reader("firstname").ToString().ToUpper()
                        Form_Main.txtFname.Text = firstName
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("lastname")) Then
                        Dim lastName As String = reader("lastname").ToString().ToUpper()
                        Form_Main.txtLname.Text = lastName
                    End If
                    reader.Close()
                    Return True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.ToString())
            Return False
        Finally
            SQLite_Close_Connection()
        End Try

        Return False
    End Function

    Public Function IsAdminUser(username As String) As Boolean
        Try
            SQLite_Open_Connection()

            Dim query As String = "SELECT tbl_usertype.usertype_id, tbl_usertype.usertype FROM tbl_usertype INNER JOIN tbl_user ON tbl_usertype.usertype_id = tbl_user.usertype_id WHERE tbl_user.username = @username;"
            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@username", username)

                Dim result As Object = cmd.ExecuteScalar()

                Return If(result IsNot Nothing AndAlso result IsNot DBNull.Value, Convert.ToBoolean(result), False)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            SQLite_Close_Connection()
        End Try
    End Function
End Module
