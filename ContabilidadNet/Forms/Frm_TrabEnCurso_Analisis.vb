Option Strict On
Option Explicit On
Public Class Frm_TrabEnCurso_Analisis

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Private Sub Traetrabajosencurso()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_cc25trabajosencurso", gbcodempresa, gbano, "*", "").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)

        Dim flagtiporeporte As String = ""
        Dim flagopcionreporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '========================================

            flagtiporeporte = "REPTRACUR"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If rbtopcion_0.Checked = True Then
                flagopcionreporte = "M" 'Mes
            ElseIf rbtopcion_1.Checked = True Then
                flagopcionreporte = "A" 'Anual
            ElseIf rbtopcion_2.Checked = True Then
                flagopcionreporte = "H" 'Historico
            End If

            '========================================
            nombredereporte = "rpt_tracursoAnalisis.Rpt"

            'Sp que trae datos del reporte
            ds = objSql.TraerDataSet("Spu_Con_Rep_TrabEnCurso", gbcodempresa, gbano, gbmes, gbNameUser, flagtiporeporte, flagopcionreporte, gbmoneda).Copy()

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("opcion", flagopcionreporte))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("mes", gbano))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("anio", gbmes))

            
            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If

            'Elimnar rango de impresion
            Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub Frm_TrabEnCurso_Analisis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Text = "Analisis de Trabajo en curso"
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Me.Traetrabajosencurso()

            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class