Option Strict On
Option Explicit On
Public Class Frm_Analisis6con9

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#Region "Base de Datos"
    Private Sub LlenarCuentas(ByVal Longitud As Integer)
        Try
            Vista = objSql.TraerDataTable("Sp_Con_Help_Cuentas_analisis", gbcodempresa, gbano, "*", Longitud, "6").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String
        Dim mesini As String
        Dim mesFin As String
        Dim flagdistr As String
        Dim titulo As String
        Dim opcion As String
        Dim longitud6 As String
        Dim longitud9 As String


        mesini = Funciones.Funciones.derecha(cboperiodos_0.SelectedValue.ToString, 2)
        mesFin = Funciones.Funciones.derecha(cboperiodos_1.SelectedValue.ToString, 2)

        longitud6 = cbolencta6.SelectedValue.ToString
        longitud9 = cbolencta9.SelectedValue.ToString

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '========================================
            flagtiporeporte = "ANALISIS"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            '========================================
            If rbtTiporeporte_0.Checked = True Then   '9 con la 6 y 9
                If rbtTipoImpre_1.Checked = True Then 'Acumulados
                    titulo = "REPORTE DE GASTOS 6/9 (RESUMIDO-ACUMULADO)"
                    opcion = "1"
                    nombredereporte = "Rep_AnalisisCosto_Resumido_Acumulado.rpt"
                Else    'por meses
                    titulo = "REPORTE DE GASTOS 6/9 (RESUMIDO-POR MESES)"
                    opcion = "2"
                    nombredereporte = "Rep_AnalisisCosto_Resumido_Meses.rpt"
                End If
            Else    'Agrupado ABC
                'If optTipoImpre(1).Value = True Then    'Acumulado
                titulo = "REPORTE DE GASTOS 6/9 (AGRUPADO)"
                opcion = "1"
                nombredereporte = "rep_analisiscosto_resumido_acumulado_ABC.Rpt"
            End If


            flagdistr = If(rbtdistribucion_0.Checked = True, "N", "S")

            'Sp que trae datos del reporte
            ds = objSql.TraerDataSet("Sp_Con_Rep_AnalisisCostos", gbcodempresa, gbano, mesini, gbNameUser, opcion, longitud6, longitud9, mesFin, flagdistr).Copy()

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("titulo", titulo))

            'Visualizar reportes
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

    Private Sub Frm_Analisis6con9_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)

            Me.Text = "Analisis de Gastos de clase 6 y la clase 9 "
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)

            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos_0, gbcodempresa, gbano)
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos_1, gbcodempresa, gbano)

            Mod_BaseDatos.LlenarComboNivelPlaCtas(cbolencta6, gbcodempresa, gbano)
            Mod_BaseDatos.LlenarComboNivelPlaCtas(cbolencta9, gbcodempresa, gbano)


            Me.LlenarCuentas(2) ' pOr defecto que vaya el nivel 2
            cboperiodos_0.SelectedIndex = CType(gbmes, Integer)
            cboperiodos_1.SelectedIndex = CType(gbmes, Integer)
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

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub cbolencta6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbolencta6.SelectedIndexChanged
        'Llenar ceuentas
        Dim longitud As String
        longitud = cbolencta6.SelectedValue.ToString
        If IsNumeric(longitud) = True Then
            Call LlenarCuentas(CInt(longitud))
        End If
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub
End Class