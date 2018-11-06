Imports System.Data.Odbc
Imports System.Data


Public Class floor
    Sub Ubah()
        Try
            konek()
            Dim Ubah As New Odbc.OdbcCommand
            Ubah.Connection = conn
            Ubah.CommandType = CommandType.Text
            Ubah.CommandText = "update floor set name = '" & txtFloor.Text & "' WHERE id = '" & LabelID.Text & "' "
            Ubah.ExecuteNonQuery()
            MsgBox("Data Success To Changed!")
            Clean()
        Catch ex As Exception

        End Try
    End Sub

    Sub tampiling()
        konek()
        da = New Odbc.OdbcDataAdapter("Select id,name,created_at FROM floor", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "Floor Rooms")
        DTFloor.DataSource = (ds.Tables("Floor Rooms"))

    End Sub
    Sub Save()
        konek()
        sql = "insert into floor(name) values('" & txtFloor.Text & "')"
        cmd = New OdbcCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Data Provided!", vbInformation, "Success")
            Me.Show()

        Catch ex As Exception
            MsgBox("Failed To Save!", vbInformation, "Failed")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
        tampiling()
    End Sub
    Sub Time()
        Label4.Text = Format(Now, "yy-MM-dd")
        Label5.Text = Format(Now, "hh:MM:ss")
    End Sub

    Private Sub FDayVacation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampiling()
    End Sub

    Private Sub DTFloor_MouseClick(sender As Object, e As MouseEventArgs) Handles DTFloor.MouseClick
        txtFloor.Text = DTFloor.CurrentRow.Cells(1).Value.ToString
        LabelID.Text = DTFloor.CurrentRow.Cells(0).Value.ToString
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Sub Clean()
        txtFloor.Text = ""
        txtSearch.Text = ""
        btnSave.Enabled = True
        btnUpdate.Enabled = False
    End Sub
    Sub Delete()
        Dim Delete As String = DTFloor.Item(0, DTFloor.CurrentRow.Index).Value
        If Delete = "" Then
            MsgBox("The Data To Delete Has Not Been Selected!")
        Else
            Try
                If (MessageBox.Show("Are You Sure Want To Delete This Data With id = " & Delete & " ...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK) Then
                    konek()
                    cmd = New OdbcCommand("delete from floor where id = '" & Delete & "'", conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Success To Deleted!", vbInformation, "Deleted")
                    conn.Close()
                    tampiling()
                End If
            Catch ex As Exception
                MsgBox("Data Failed To Delete!", vbInformation, "Failed")
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clean()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Ubah()
        tampiling()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
        tampiling()
    End Sub

    Sub Search()
        Dim kd = txtSearch.Text

        Try
            ds.Tables(0).PrimaryKey = New DataColumn() {(ds.Tables(0).Columns("id"))}
            Dim row As DataRow
            row = ds.Tables(0).Rows.Find(kd)
            txtFloor.Text = row("name")
        Catch ex As Exception
            MsgBox("Data Not Found!")
        End Try
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
        tampiling()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Time()
    End Sub


    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtFloor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFloor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z,a-z]" _
            OrElse KeyAscii = Keys.Back _
             OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub txtFloor_TextChanged(sender As Object, e As EventArgs) Handles txtFloor.TextChanged
        btnSave.Enabled = True
    End Sub
End Class