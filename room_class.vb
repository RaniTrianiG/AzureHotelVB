Imports System.Data.Odbc
Imports System.Data

Public Class fAwal
    Sub diubah()
        Try
            konek()
            Dim Update As New Odbc.OdbcCommand
            Update.Connection = conn
            Update.CommandType = CommandType.Text
            Update.CommandText = "update room_class set name = '" & txtClass.Text & "', rate_day_1 = '" & txtPrice1.Text & "', rate_day_2 = '" & txtPrice2.Text & "', rate_day_3 = '" & txtPrice3.Text & "', rate_day_4 = '" & txtPrice4.Text & "', rate_day_5 = '" & txtPrice5.Text & "', rate_day_6 = '" & txtPrice6.Text & "', rate_day_7 = '" & txtPrice7.Text & "', description = '" & txtDesc.Text & "' WHERE id = '" & LabelID.Text & "'"
            Update.ExecuteNonQuery()
            MsgBox("Data Success To Changed")
            Bersih()
        Catch ex As Exception
            MsgBox("Data Failed To Change!")
        End Try
    End Sub
    Sub Delete()
        Dim Delete As String = DTClasses.Item(0, DTClasses.CurrentRow.Index).Value
        If Delete = "" Then
            MsgBox("The Data To Delete Has Not Been Selected!")
        Else
            Try
                If (MessageBox.Show("Are You Sure Want To Delete This Data With id = " & Delete & " ...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK) Then
                    konek()
                    cmd = New OdbcCommand("delete from room_class where id = '" & Delete & "'", conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Success To Deleted!", vbInformation, "Success")
                    conn.Close()
                    Tampil()
                End If
            Catch ex As Exception
                MsgBox("Data Failed To Delete!!", vbInformation, "Failed")
            End Try
        End If
    End Sub
    Sub Tampil()
        konek()
        da = New Odbc.OdbcDataAdapter("Select id, name, rate_day_1, rate_day_2, rate_day_3, rate_day_4, rate_day_5, rate_day_6, rate_day_7, description, created_at FROM room_class", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "Classes Room")
        DTClasses.DataSource = (ds.Tables("Classes Room"))
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
    Sub Waktu()
        Label1.Text = Format(Now, "yyy-MM-dd")
        Label2.Text = Format(Now, "hh: MM:ss")
    End Sub

    Sub Bersih()
        txtClass.Text = ""
        txtPrice1.Text = ""
        txtPrice2.Text = ""
        txtPrice3.Text = ""
        txtPrice4.Text = ""
        txtPrice5.Text = ""
        txtPrice6.Text = ""
        txtPrice7.Text = ""
        txtDesc.Text = ""
        txtSearch.Text = ""
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Sub Cari()
        Dim kd = txtSearch.Text

        Try
            ds.Tables(0).PrimaryKey = New DataColumn() {(ds.Tables(0).Columns("id"))}
            Dim row As DataRow
            row = ds.Tables(0).Rows.Find(kd)
            txtClass.Text = row("name")
            txtPrice1.Text = row("rate_day_1")
            txtPrice2.Text = row("rate_day_2")
            txtPrice3.Text = row("rate_day_3")
            txtPrice4.Text = row("rate_day_4")
            txtPrice5.Text = row("rate_day_5")
            txtPrice6.Text = row("rate_day_6")
            txtPrice7.Text = row("rate_day_7")
            txtDesc.Text = row("description")
        Catch ex As Exception
            MsgBox("Data Not Found!")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Waktu()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
        Tampil()
    End Sub

    Private Sub fAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampil()
    End Sub

    Sub Save()

        konek()
        sql = "insert into room_class(name,rate_day_1,rate_day_2,rate_day_3,rate_day_4,rate_day_5,rate_day_6,rate_day_7,description) values('" & txtClass.Text & "', '" & txtPrice1.Text & "', '" & txtPrice2.Text & "', '" & txtPrice3.Text & "', '" & txtPrice4.Text & "', '" & txtPrice5.Text & "', '" & txtPrice6.Text & "', '" & txtPrice7.Text & "', '" & txtDesc.Text & "')"
        cmd = New OdbcCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Data Provided!", vbInformation, "Success")
            Me.Show()
        Catch ex As Exception
            MsgBox("Failed To Save!", vbInformation, "Failed")
        End Try
    End Sub

    Private Sub DTClasses_MouseClick(sender As Object, e As MouseEventArgs) Handles DTClasses.MouseClick
        txtClass.Text = DTClasses.CurrentRow.Cells(1).Value.ToString
        txtPrice1.Text = DTClasses.CurrentRow.Cells(2).Value.ToString
        txtPrice2.Text = DTClasses.CurrentRow.Cells(3).Value.ToString
        txtPrice3.Text = DTClasses.CurrentRow.Cells(4).Value.ToString
        txtPrice4.Text = DTClasses.CurrentRow.Cells(5).Value.ToString
        txtPrice5.Text = DTClasses.CurrentRow.Cells(6).Value.ToString
        txtPrice6.Text = DTClasses.CurrentRow.Cells(7).Value.ToString
        txtPrice7.Text = DTClasses.CurrentRow.Cells(8).Value.ToString
        txtDesc.Text = DTClasses.CurrentRow.Cells(9).Value.ToString
        LabelID.Text = DTClasses.CurrentRow.Cells(0).Value.ToString
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Bersih()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        diubah()
        Tampil()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
        Tampil()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Cari()
        Tampil()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub


    Private Sub txtPrice1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPrice2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPrice3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPrice4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPrice5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice5.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPrice6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice6.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPrice7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice7.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtClass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClass.KeyPress
        'Dim KeyAscii As Short = Asc(e.KeyChar)
        'If (e.KeyChar Like "[A-Z,a-z]" _
        '    OrElse KeyAscii = Keys.Back _
        '    OrElse KeyAscii = Keys.Space _
        '  OrElse KeyAscii = Keys.Return _
        ' OrElse KeyAscii = Keys.Delete) Then
        'KeyAscii = 0
        'End If

        'e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub txtDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesc.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z,a-z]" _
            OrElse KeyAscii = Keys.Back _
             OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub txtClass_TextChanged(sender As Object, e As EventArgs) Handles txtClass.TextChanged
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub
End Class
