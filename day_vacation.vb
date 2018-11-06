Imports System.Data.Odbc
Imports System.Data
Imports System.Globalization
Imports System.String

Public Class day_vacation
    Sub tampil()
        konek()
        da = New Odbc.OdbcDataAdapter("Select id, date, percent, created_at FROM day_vacation", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "day_vacation")
        DTVacation.DataSource = (ds.Tables("day_vacation"))
    End Sub

    Sub Delete()
        Dim Delete As String = DTVacation.Item(0, DTVacation.CurrentRow.Index).Value
        If Delete = "" Then
            MsgBox("The Data To Delete Has Not Been Selected!")
        Else
            Try
                If (MessageBox.Show("Are You Sure Want To Delete This Data With id = " & Delete & " ...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK) Then
                    konek()
                    cmd = New OdbcCommand("delete from day_vacation where id = '" & Delete & "'", conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Success To Deleted!", vbInformation, "Success")
                    conn.Close()
                    tampil()
                End If
            Catch ex As Exception
                MsgBox("Data Failed To Delete!!", vbInformation, "Failed")
            End Try
        End If
    End Sub

    Sub Clean()
        DateVacation.Text = ""
        txtPercent.Text = ""
        txtSearch.Text = ""
        btnSearch.Enabled = True
        btnUpdate.Enabled = False
    End Sub
    Sub ubahin()
        Try
            konek()
            Dim Update As New Odbc.OdbcCommand
            Update.Connection = conn
            Update.CommandType = CommandType.Text
            Update.CommandText = "update day_vacation set date = '" & DateVacation.Text & "', percent = '" & txtPercent.Text & "' WHERE id = '" & LabelID.Text & "'"
            Update.ExecuteNonQuery()
            MsgBox("Data Success To Changed")
            Clean()
        Catch ex As Exception
            MsgBox("Data Failed To Change!")
        End Try
    End Sub
    Sub Save()
        'String userInput = "MM/dd/yyyy";
        'DateTime.ParseExact("11/11/2011", userInput, CultureInfo.CurrentCulture)
        'Dim dat As String = Val(DateVacation.Value)
        'Dim DateVacation As DateTime = DateTime.ParseExact(Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
        'Dim reformatted As String = DateVacation.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
        'String todaysDate = DateTime.Now.ToString("MM/dd/yyyy");
        'Dim dat As DateTime = DateTime.ParseExact("20140118", "yyyyMMdd", CultureInfo.InvariantCulture)
        'DateVacation.Value = dat
        'Dim dat As String = Convert.ToString(DateVacation)

        'DateVacation.Value = Date.Parse(Me.Text)
        'Dim tgl As String = ""
        'DateVacation.CostumFormat = "yyyy->"
        konek()
        sql = "insert into day_vacation(date,percent) values('" & DateVacation.Text & "', '" & txtPercent.Text & "')"
        cmd = New OdbcCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Data Provided!", vbInformation, "Success")
            Me.Show()
        Catch ex As Exception
            MsgBox("Data Failed To Save!", vbInformation, "Failed")
        End Try
    End Sub
    Sub aweu()
        Label2.Text = Format(Now, "yyy-MM-dd")
        Label4.Text = Format(Now, "hh: MM:ss")
    End Sub
    Private Sub Vacation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aweu()
        tampil()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Save()
        tampil()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ubahin()
        tampil()
        Clean()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Clean()
        tampil()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnSearch.Enabled = True
        btnInsert.Enabled = True
    End Sub

    Private Sub DTVacation_MouseClick(sender As Object, e As MouseEventArgs) Handles DTVacation.MouseClick
        DateVacation.Text = DTVacation.CurrentRow.Cells(1).Value.ToString
        txtPercent.Text = DTVacation.CurrentRow.Cells(2).Value.ToString
        LabelID.Text = DTVacation.CurrentRow.Cells(0).Value.ToString
        btnSearch.Enabled = True
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnInsert.Enabled = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
        tampil()
    End Sub

    Sub Search()
        Dim kd = txtSearch.Text

        Try
            ds.Tables(0).PrimaryKey = New DataColumn() {(ds.Tables(0).Columns("id"))}
            Dim row As DataRow
            row = ds.Tables(0).Rows.Find(kd)
            txtPercent.Text = row("percent")
            DateVacation.Text = row("date")
        Catch ex As Exception
            MsgBox("Data Not Found!")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
        tampil()
        btnSearch.Enabled = True
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub txtPercent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPercent.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub DateVacation_ValueChanged(sender As Object, e As EventArgs) Handles DateVacation.ValueChanged
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        aweu()
    End Sub
End Class