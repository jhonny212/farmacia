Imports WindowsApp1.BLL
Public Class UI
    Public bll As New BLL()
    Private Sub Limpiar()
        c_nombre.Clear()
        c_edad.Clear()
        c_cui.Clear()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fallo As Boolean = False
        Dim nombre, edad, cui As String
        nombre = c_nombre.Text
        edad = c_edad.Text
        cui = c_cui.Text
        If cui.Length = 0 Then
            MsgBox("Ingrese un cui")
            fallo = True
        End If
        If edad.Length = 0 Then
            MsgBox("Ingrese una edad")
            fallo = True
        End If
        If nombre.Length = 0 Then
            MsgBox("Ingrese un nombre")
            fallo = True
        End If
        If fallo = False Then
            Dim val As Integer = bll.insert(nombre, edad, cui)
            If val <> 0 Then
                MsgBox("Cliente registrado")
            Else
                MsgBox("No se registro el cliente")
            End If
        End If
        Limpiar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fallo As Boolean = False
        Dim cui As String
        cui = c_cui.Text
        If cui.Length = 0 Then
            MsgBox("Ingrese un cui")
            fallo = True
        End If
        If fallo = False Then
            Dim val As Integer = bll.delete(cui)
            If val <> 0 Then
                MsgBox("Cliente eliminado")
            Else
                MsgBox("No se pudo eliminar el cliente")
            End If
        End If
        Limpiar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fallo As Boolean = False
        Dim nombre, edad, cui As String
        nombre = c_nombre.Text
        edad = c_edad.Text
        cui = c_cui.Text
        If cui.Length = 0 Then
            MsgBox("Ingrese un cui")
            fallo = True
        End If
        If edad.Length = 0 Then
            MsgBox("Ingrese una edad")
            fallo = True
        End If
        If nombre.Length = 0 Then
            MsgBox("Ingrese un nombre")
            fallo = True
        End If
        If fallo = False Then
            Dim val As Integer = bll.update(cui, edad, nombre)
            If val <> 0 Then
                MsgBox("Dato actualizado")
            Else
                MsgBox("No se pudo actualizar el cliente")
            End If
        End If
        Limpiar()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim nombre, edad, cui As String
        nombre = c_nombre.Text
        edad = c_edad.Text
        cui = c_cui.Text
        Dim filtros As String = ""
        If cui.Length <> 0 Then
            filtros = "cui = '" + cui + "'"
        End If

        If nombre.Length <> 0 Then
            If filtros.Length <> 0 Then
                filtros = filtros + " AND "
            End If
            filtros = filtros + "nombre = '" + nombre + "'"
        End If

        If edad.Length <> 0 Then
            If filtros.Length <> 0 Then
                filtros = filtros + " AND "
            End If
            filtros = filtros + "edad = '" + edad + "'"
        End If

        If filtros.Length = 0 Then
            bll.select_("", Me.DataGridView1)
        Else
            bll.select_(" WHERE " + filtros, Me.DataGridView1)
        End If
        Limpiar()
    End Sub
End Class
