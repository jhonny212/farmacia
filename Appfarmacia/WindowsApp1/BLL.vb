Imports System.Data.SqlClient
Imports System.Windows.Forms.DataGridView
Public Class BLL
    Dim con As New SqlConnection(My.Settings.DAL)
    Public Function insert(Nombre As String, Edad As String, Cui As String) As Integer
        Dim valores As String = "'" + Cui + "','" + Nombre + "','" + Edad + "'"
        Dim sql As String = "INSERT INTO Cliente (cui,nombre,edad) VALUES (" + valores + ")"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim cant As Integer = 0
        Try
            cant = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        con.Close()
        Return cant
    End Function
    Public Function delete(Cui As String) As Integer
        Dim sql As String = "DELETE FROM Cliente WHERE cui = '" + Cui + "'"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim cant As Integer = 0
        Try
            cant = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        con.Close()
        Return cant
    End Function

    Public Function update(Cui As String, Edad As String, Nombre As String) As Integer
        Dim valores As String = "nombre = '" + Nombre + "', edad = '" + Edad + "'"
        Dim sql As String = "UPDATE Cliente SET " + valores + " WHERE cui = " + Cui + ""
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim cant As Integer = 0
        Try
            cant = cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        con.Close()
        Return cant
    End Function

    Public Sub select_(filtros As String, grid As DataGridView)
        Dim sql As String = "SELECT * FROM Cliente" + filtros
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds, "Cliente")
            grid.DataSource = ds.Tables("Cliente")
        Catch ex As Exception

        End Try
        con.Close()
    End Sub
End Class
