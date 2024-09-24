
Option Strict On
Option Explicit On
Public Class Frm_EEFF_Comp
    Private Sub iniciarcontroles()
        rbttipoacum_0.Checked = True
        cboPeriodos.SelectedIndex = CType(gbmes, Integer)
    End Sub
    Private Sub Frm_EEFF_Comp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Estados Financiero comparativos"
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Mod_BaseDatos.LlenarComboPeriodos(cboPeriodos, gbcodempresa, gbano)
            iniciarcontroles()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesbalance As String
        Dim flagacumulado As String
        Dim anioant As String
        anioant = CStr(CInt(gbmes) - 1)
        'LLeno el rango de valores
        Try
            mesbalance = Funciones.Funciones.derecha(cboPeriodos.SelectedValue.ToString, 2)

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            '
            flagacumulado = If(rbttipoacum_0.Checked = True, "A", "M")

            If rbttraecuentas_0.Checked = True Then
                nombredereporte = "Rpt_BalgenComparativoNew.rpt"
                ds = objSql.TraerDataSet("Spu_Con_Rep_BalGenComparativoNew", gbcodempresa, gbano, mesbalance, anioant, gbmoneda).Copy()
                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("monedades", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            Else
                nombredereporte = If(gbTipoImpresora = "I", "Rpt_EGyPResumido.Rpt", "Rpt_EGyPResumido.Rpt")
                Dim flagegyp As String
                flagegyp = If(rbttraecuentas_1.Checked = True, "F", "N")
                ds = objSql.TraerDataSet("Spu_Con_Rep_EstGyPResumido", gbcodempresa, gbano, gbmoneda, flagegyp, flagacumulado, gbmes).Copy()

                'Formulas de reporte
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("monedadesc", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("TipoEGP", flagegyp))
            End If

            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub
End Class