Option Strict On
Option Explicit On
Public Class Frm_LibroCaja

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Private Sub Traectaslibrocaja(ByVal moneda As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Help_Cuentas_Caja", gbcodempresa, gbano, moneda).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)

            If Not IsNothing(tblconsulta.Columns(0)) = True Then
                Me.tblconsulta.Columns(0).FooterText = "# Registros"
                Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String
        Dim flagopcionreporte As String
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesdelibrocaja As String

        mesdelibrocaja = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "LIBCAJA"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            nombredereporte = "LibCaja.Rpt"
            flagopcionreporte = If(optTipoImpre_0.Checked = True, "1", "2")
            mesdelibrocaja = If(optTipoImpre_0.Checked = True, mesdelibrocaja, mesdelibrocaja.Substring(4, 2))
            'Sp que trae datoas del reporte
            ds = objSql.TraerDataSet("sp_Con_Rep_LibroCaja", gbcodempresa, gbano, mesdelibrocaja, gbmoneda, gbNameUser, flagopcionreporte, mskFecIni.Text, mskFecFin.Text).Copy()
            'Formulas de reporte
            Dim monedaMay As String
            monedaMay = If(gbmoneda = "S", "Nuevos Soles", If(gbmoneda = "D", "Dolares", "Dolar Promedio")) & "'"

            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))

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
        Dim flagopcionreporte As String
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesdelibrocaja As String
        Dim monedaMay As String

        mesdelibrocaja = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "LIBCAJA"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            nombredereporte = "LibCaja.Rpt"
            flagopcionreporte = If(optTipoImpre_0.Checked = True, "1", "2")
            ds = objSql.TraerDataSet("sp_Con_Rep_LibroCaja", gbcodempresa, gbano, mesdelibrocaja, gbmoneda, gbNameUser, flagopcionreporte, mskFecIni.Text, mskFecFin.Text).Copy()

            'Formulas de reporte
            monedaMay = If(gbmoneda = "S", "Nuevos Soles", If(gbmoneda = "D", "Dolares", "Dolar Promedio")) & "'"

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))

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

    Private Sub Frm_LibroCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Libro caja"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)

            '
            Me.Traectaslibrocaja("S")

            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
            cboperiodos.SelectedIndex = CType(gbmes, Integer)
            '
            mskFecIni.Text = "01" & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano
            mskFecFin.Text = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub rbtMoneda_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoneda_0.CheckedChanged
        Me.Traectaslibrocaja("S")
    End Sub

    Private Sub rbtMoneda_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoneda_1.CheckedChanged
        Me.Traectaslibrocaja("D")
    End Sub

    Private Sub rbtMoneda_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoneda_2.CheckedChanged
        Me.Traectaslibrocaja("*")
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
End Class