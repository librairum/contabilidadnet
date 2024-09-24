Option Strict On
Option Explicit On
Public Class Frm_Distribucion_Rep
#Region "Declaraciones"
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#End Region
    Private Sub TraectaDistribuibles()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_cdicabeceraVoucher", gbcodempresa, gbano).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Frm_Distribucion_Rep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Me.Text = "Reporte de distribucion"
            '
            Me.TraectaDistribuibles()
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim arrparameter As New List(Of KS.Com.Win.CystalReports.Net.ParametrosReportes)
        Dim flagtiporeporte As String
        Dim nombredereporte As String
        Dim Rutareporte As String

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "CONAXIDIS"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            nombredereporte = "RptLibAuxDistribucion.rpt"
            'Sp que trae datoas del reporte
            ds = objSql.TraerDataSet("Spu_Con_Rep_LibAuxDistribucion", gbcodempresa, gbano, gbmes, gbNameUser).Copy()

            'Formulas de reporte
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrparameter.Add(New Ks.Com.Win.CystalReports.Net.ParametrosReportes("ccd01ano", gbano))

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
        Finally
            objR = Nothing
        End Try
    End Sub
    Sub imprimir_verant(ByVal flagimpresion As String)

        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String
        Dim nombredereporte As String
        Dim Rutareporte As String

        'LLeno el rango de valores
        Try

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "CONAXIDIS"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(1).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            nombredereporte = "RptLibAuxDistribucion.rpt"
            ds = objSql.TraerDataSet("Spu_Con_Rep_LibAuxDistribucion", gbcodempresa, gbano, gbmes, gbNameUser).Copy()

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
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

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange

    End Sub
End Class