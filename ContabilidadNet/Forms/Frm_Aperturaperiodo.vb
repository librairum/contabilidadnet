Public Class Frm_Aperturaperiodo

    Private Sub Frm_Aperturaperiodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centra la Pantalla
        Mod_Mantenimiento.formatearformulario(Me)
        Mod_Mantenimiento.Centrar(Me)

        'Inicio Combos
        cboanoorigen.Items.Add(gbano)
        cboanofin.Items.Add((Convert.ToInt16(gbano) + 1).ToString())

    End Sub
    Private Sub btnInicia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicia.Click
        Try
            If MessageBox.Show(" Esta Seguro de Ejecutar este Proceso ?  ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

            'Validar
            If Funciones.Funciones.Esnumeromayoracero(cboanoorigen.Text) = False Then MessageBox.Show(gbc_MensajeValidar + " Año de inicio no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(cboanofin.Text) = False Then MessageBox.Show(gbc_MensajeValidar + " Año de fin no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            ' Cambio el Puntero del Mouse
            Cursor.Current = Cursors.WaitCursor

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Upd_TablasAnuales", gbcodempresa, cboanoorigen.Text, cboanofin.Text, "")

            'Ejecutar
            Funciones.Funciones.MensajesdelSQl(a)

            Cursor.Current = Cursors.Default
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
End Class