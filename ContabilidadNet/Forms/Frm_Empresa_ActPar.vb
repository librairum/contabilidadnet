Option Strict On
Option Explicit On
Public Class Frm_Empresa_ActPar

    Function ValidaPeriodo(ByVal anio As String) As Boolean
        Dim valor As String
        ValidaPeriodo = False
        Try
            ' Obtengo el Tipo de Cambio de la Cuenta
            valor = CType(objSql.TraerValor("Spu_Glo_Trae_Valperiodo", gbcodempresa, anio, ""), String)

            If valor.Trim <> "" Then
                ValidaPeriodo = True
            Else
                MessageBox.Show("VALIDAR :: Periodo no valido, verifique que exista el periodo", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ValidaPeriodo = False
        End Try
    End Function
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If IsNumeric(txtejerActivo.Text) = False Then MessageBox.Show("VALIDAR :: Año Invalido", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If ValidaPeriodo(txtejerActivo.Text.Trim) = False Then Exit Sub

            'If MessageBox.Show("¿Esta Seguro de efectuar los cambios ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            a = objSql.Ejecutar2("Sp_Glo_Upd_PeriodoTrabajo", gbc_sistema, gbNameUser, gbcodempresa.Trim + txtejerActivo.Text.Trim + gbmes, gbmoneda, gbSaldos, gbTipoImpresora, gbAjuste)

            If Funciones.Funciones.MensajesdelSQl(a) = True Then

                gbsaltaractualizaperiodo = "S"
                'Actualizar 
                MessageBox.Show("Periodo Cambiado Con Exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Global.System.Windows.Forms.Application.Exit()
            
                'gbllenadodecombo = False
                'gbano = txtejerActivo.Text
                'Mod_BaseDatos.LlenarComboPeriodos(MDIPrincipal.cboperiodos, gbcodempresa, txtejerActivo.Text)

                'MDIPrincipal.cboperiodos.DataSource = Nothing
                'MDIPrincipal.cboperiodos.Items.Clear()

                'MDIPrincipal.cboperiodos.DataSource = objSql.TraerDataTable("Spu_Con_Help_ccb03per_1", gbcodempresa, txtejerActivo.Text.Trim).DefaultView
                'MDIPrincipal.cboperiodos.ValueMember = "ccb03cod"
                'MDIPrincipal.cboperiodos.DisplayMember = "ccb03des"

                'MDIPrincipal.cboperiodos.SelectedValue = txtejerActivo.Text.Trim
                'MDIPrincipal.cboperiodos.Refresh()
                'MDIPrincipal.Refresh()
                'MDIPrincipal.cboperiodos.Refresh()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Frm_Empresa_ActParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtejerActivo.Text = gbano
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            '==
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btnmas, "Mas")
            Mod_Mantenimiento.tooltiptext(btnmenos, "Menos")
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            '==
            Me.Text = "Actualizar parametros"
            '==
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnmas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmas.Click
        Try
            txtejerActivo.Text = CType(CType(txtejerActivo.Text, Integer) + 1, String)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnmenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmenos.Click
        Try
            txtejerActivo.Text = CType(CType(txtejerActivo.Text, Integer) - 1, String)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
End Class