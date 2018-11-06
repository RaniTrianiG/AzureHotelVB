Imports System.Data.Odbc
Imports System.Data

Public Class CheckIn
    Sub penggunaan()
        konek()
        Try
            cmd = New OdbcCommand("select code from checkin order by code", conn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cmbCode.Items.Add(dr("code"))
            End While
        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal, karena " & ex.Message)
        End Try
    End Sub
    Sub tampil()
        konek()
        da = New Odbc.OdbcDataAdapter("select * from checkin", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "checkin")
        DTCheckIn.DataSource = (ds.Tables("checkin"))
    End Sub

    Private Sub CheckIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        penggunaan()
        tampil()
    End Sub

    Private Sub cmbCode_SelectedIndexChanged(sender As Object, e As EventArgs)
        penggunaan()
        konek()

        Try
            cmd = New OdbcCommand("select * from checkin where code ='" & cmbCode.Text & "'", conn)
            dr = cmd.ExecuteReader()
            dr.Read()
            cmbCode.Text = dr("code")

        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal, karena " & ex.Message)
        End Try
    End Sub
End Class