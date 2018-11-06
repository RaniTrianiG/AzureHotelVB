Imports System.Data.Odbc
Imports System.Data

Module koneksi
    Public conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public dr As OdbcDataReader
    Public ds As DataSet
    Public cmd As OdbcCommand
    Public sql As String
    Public strcon As String
    Public Sub konek()
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=hotel_dev;server=localhost;user=root;"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
