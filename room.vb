Imports System.Data.Odbc
Imports System.Data

Public Class Room
    Sub showing()
        konek()
        da = New Odbc.OdbcDataAdapter("Select id, name, floor_id, class_id, status, created_at FROM room", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "Room Management")
        DTRoom.DataSource = (ds.Tables("Room Management"))
    End Sub
    Sub bersihin()
        txtName.Text = ""
        txtStatus.Text = ""
        txtSearch.Text = ""
        cmbFloor.Text = ""
        cmbClass.Text = ""
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub
    Function getKode() As String
        Dim namaKamar As String = String.Empty
        Try
            cmd = New OdbcCommand("select * from  room", conn)
            dr = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            If dt.Rows.Count > 0 Then
                Dim conter As Integer = Convert.ToInt32(dt.Rows.Count + 1)
                namaKamar = "ROOM-" + conter.ToString
            Else
                namaKamar = "ROOM-1"
            End If
        Catch ex As Exception
            MessageBox.Show("Failed Connection, because " & ex.Message)
        End Try
        Return namaKamar
    End Function
    Sub masuk()
        konek()
        sql = "insert into room(name, floor_id, class_id) values('" & getKode() & "', '" & cmbFloor.Text & "', '" & cmbClass.Text & "')"
        cmd = New OdbcCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Data Provided!", vbInformation, "Success")
            Me.Show()
        Catch ex As Exception
            MsgBox("Failed To Save!", vbInformation, "Failed")
        End Try
    End Sub

    Sub perbarui()
        konek()
        Try
            konek()
            Dim Update As New Odbc.OdbcCommand
            Update.Connection = conn
            Update.CommandType = CommandType.Text
            Update.CommandText = "update room set name = '" & txtName.Text & "', floor_id = '" & cmbFloor.Text & "', class_id = '" & cmbClass.Text & "', status = '" & txtStatus.Text & "' WHERE id = '" & LabelID.Text & "'"
            Update.ExecuteNonQuery()
            MsgBox("Data Success To Changed")
            bersihin()
        Catch ex As Exception
            MsgBox("Data Failed To Change!")
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        showing()
        bersihin()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub Room_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtStatus.Text = "EMPTY"
        txtStatus.Enabled = False
        kdClass()
        kdFloor()
        showing()
        txtName.Enabled = False
        getKode()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label5.Text = Format(Now, "yyy-MM-dd")
        Label6.Text = Format(Now, "hh:MM:ss")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        masuk()
        showing()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        perbarui()
        showing()
    End Sub
    Sub hapusin()
        Dim Delete As String = DTRoom.Item(0, DTRoom.CurrentRow.Index).Value
        If Delete = "" Then
            MsgBox("The Data To Delete Has Not Been Selected!")
        Else
            Try
                If (MessageBox.Show("Are You Sure Want To Delete This Data With id = " & Delete & " ...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK) Then
                    konek()
                    cmd = New OdbcCommand("delete from room where id = '" & Delete & "'", conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Success To Deleted!", vbInformation, "Success")
                    conn.Close()
                    showing()
                End If
            Catch ex As Exception
                MsgBox("Data Failed To Delete!!", vbInformation, "Failed")
            End Try
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        hapusin()
        showing()
    End Sub

    Sub kdFloor()
        konek()
        Try
            cmd = New OdbcCommand("select id from floor order by id", conn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cmbFloor.Items.Add(dr("id"))
            End While
        Catch ex As Exception
            MessageBox.Show("Failed Connection, because " & ex.Message)
        End Try
    End Sub

    Private Sub cmbFloor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFloor.SelectedIndexChanged
        kdFloor()
        txtName.Text = getKode()
        konek()
        Try
            cmd = New OdbcCommand("select * from floor where id='" & cmbFloor.Text & "' ", conn)
            dr = cmd.ExecuteReader()
            dr.Read()
        Catch ex As Exception
            MessageBox.Show("Failed Connection, because " & ex.Message)
        End Try
    End Sub
    Sub kdClass()
        konek()
        Try
            cmd = New OdbcCommand("select id from room_class order by id", conn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cmbClass.Items.Add(dr("id"))
            End While
        Catch ex As Exception
            MessageBox.Show("Failed Connection, because " & ex.Message)
        End Try
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged
        kdClass()

        konek()
        Try
            cmd = New OdbcCommand("select * from room _class where id='" & cmbClass.Text & "' ", conn)
            dr = cmd.ExecuteReader()
            dr.Read()
        Catch ex As Exception
            MessageBox.Show("Failed Connection, because " & ex.Message)
        End Try
    End Sub
    Private Sub DTRoom_MouseClick(sender As Object, e As MouseEventArgs) Handles DTRoom.MouseClick
        LabelID.Text = DTRoom.CurrentRow.Cells(0).Value.ToString
        txtName.Text = DTRoom.CurrentRow.Cells(1).Value.ToString
        cmbFloor.Text = DTRoom.CurrentRow.Cells(2).Value.ToString
        cmbClass.Text = DTRoom.CurrentRow.Cells(3).Value.ToString
        txtStatus.Text = DTRoom.CurrentRow.Cells(4).Value.ToString
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        txtName.Enabled = True
    End Sub

    Sub cariin()
        Dim kd = txtSearch.Text

        Try
            ds.Tables(0).PrimaryKey = New DataColumn() {(ds.Tables(0).Columns("id"))}
            Dim row As DataRow
            row = ds.Tables(0).Rows.Find(kd)
            txtName.Text = row("name")
            cmbFloor.Text = row("floor_id")
            cmbClass.Text = row("class_id")
            txtStatus.Text = row("status")
        Catch ex As Exception
            MsgBox("Data Not Found!")
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        cariin()
        showing()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtStatus_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

End Class