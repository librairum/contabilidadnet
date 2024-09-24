Public Class Frm_mayoriza
    Function MensajesdelSQl(ByVal a As Array) As Boolean
        Dim i As Integer
        Try
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                'Otros Mnsajes
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
                'Si todo esta bien
                MensajesdelSQl = True
            Else 'Fallo la ejecucion Sql 
                'Mensajes de Fallo
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next
                MensajesdelSQl = False
            End If
        Catch ex As Exception
            MensajesdelSQl = False
        End Try
    End Function
    Private Sub Frm_mayoriza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Mayorizar"

            Mod_Mantenimiento.tooltiptext(btnInicia, "Mayorizar Ahora")

            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
            cboperiodos.SelectedIndex = gbmes
            chkMayoriza_0.Checked = True

            If Periodocerrado() = True Then
                btnInicia.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MayorizaCuentas(ByVal procedimiento As String, ByVal mesdemayoriza As String)
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2(procedimiento, gbcodempresa, gbano, mesdemayoriza, "")
            Me.MensajesdelSQl(a)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Mayoriza()
        Dim mesamayorizar As String
        Dim sp As String = ""
        Try
            mesamayorizar = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

            If chkMayoriza_0.Checked = True Then
                sp = "sp_Con_Mayoriza_Batch_Cuentas"
                Me.MayorizaCuentas(sp, mesamayorizar)
            End If
            If chkMayoriza_1.Checked = True Then
                sp = "sp_Con_Mayoriza_Batch_CenCos"
                Me.MayorizaCuentas(sp, mesamayorizar)
            End If
            If chkMayoriza_2.Checked = True Then
                sp = "sp_Con_Mayoriza_Batch_CenGes"
                Me.MayorizaCuentas(sp, mesamayorizar)
            End If
            If chkMayoriza_3.Checked = True Then
                sp = "sp_Con_Mayoriza_Batch_CenDir"
                Me.MayorizaCuentas(sp, mesamayorizar)
            End If
            If chkMayoriza_4.Checked = True Then
                sp = "sp_Con_Mayoriza_Batch_AjusInf"
                Me.MayorizaCuentas(sp, mesamayorizar)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnInicia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicia.Click
        Try
            'validar
            If (chkMayoriza_0.Checked = False And chkMayoriza_1.Checked = False And chkMayoriza_2.Checked = False And _
                chkMayoriza_3.Checked = False And chkMayoriza_4.Checked = False) Then Beep() : MessageBox.Show("VALIDAR::Debe seleccionar una opcion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If MessageBox.Show("¿ Está Seguro de Mayorizar Período : " & cboperiodos.Text & " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

            ' Pregunto si Mayorizo el Mes
            Me.Mayoriza()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
End Class