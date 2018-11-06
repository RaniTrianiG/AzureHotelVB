Imports System.Data.Odbc
Imports System.Data

Public Class Menu1
    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub RoomManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomManagementToolStripMenuItem.Click
        Room.Show()
    End Sub

    Private Sub RoomClassManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomClassManagementToolStripMenuItem.Click
        fAwal.Show()
    End Sub

    Private Sub FloorManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FloorManagementToolStripMenuItem.Click
        floor.Show()
    End Sub

    Private Sub DayVacationManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DayVacationManagementToolStripMenuItem.Click
        day_vacation.Show()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Show()
    End Sub
End Class