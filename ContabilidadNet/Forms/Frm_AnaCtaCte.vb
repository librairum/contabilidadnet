Option Strict On
Option Explicit On
Public Class Frm_AnaCtaCte

    Dim Vista As New DataView
    Dim Vista1 As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Sub LlenarComboctas()
        Try
            cbocuentas.DataSource = objSql.TraerDataTable("sp_Con_Trae_PlanCuentas_ctacte", gbcodempresa, gbano, "", "*").DefaultView
            cbocuentas.DisplayMember = "ccm01cta"
            cbocuentas.ValueMember = "ccm01des"
        Catch ex As Exception
        End Try
    End Sub
    Sub traecuentas()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_PlanCuentas_ctacte", gbcodempresa, gbano, "", "*").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
        End Try
    End Sub
    Sub TraeCuentaCorrientexxCuenta()
        Dim cuenta As String
        Try
            If cbocuentas.Text = "" Then MessageBox.Show("VALIDAR:: No existen Cuentas", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            cuenta = Mod_BaseDatos.DameDescripcion(gbano + cbocuentas.Text, "UT")

            Vista1 = objSql.TraerDataTable("sp_Con_Trae_Cuentas_Corrientes_New", gbcodempresa, cuenta, "ccm02cod Asc", "ccm02cod", "*").DefaultView
            tblconsulta1.SetDataBinding(Vista1, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""

        Dim cAnalisis As String = ""
        Dim titu As String = ""
        Dim desperiodo As String
        Dim flagtab As String = ""
        Dim flagcuenta As String = ""
        Dim opcion As String = ""
        Dim desRango As String

        'LLeno el rango de valores
        Try
            desperiodo = MDIPrincipal.cboperiodos.Text
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            If tabOpciones.SelectedIndex = 0 Then 'Es el libro analitico
                '=========Inserto Filas seleecionadas
                flagtiporeporte = "ANCTACTECU"
                flagtab = "C"
                flagcuenta = ""
                desRango = ""
                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            Else
                '=========Inserto Filas seleecionadas
                flagtiporeporte = "ANCTACTETE"
                flagtab = "T"
                flagcuenta = cbocuentas.Text
                desRango = "Cuenta : " + cbocuentas.Text
                'Inserto los valores selecioandos
                cAnalisis = Mod_BaseDatos.DameDescripcion(gbano + cbocuentas.Text.Trim, "UT")
                If tblconsulta1.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadasmasvalor(flagtiporeporte, tblconsulta1, tblconsulta1.Columns(0).DataField, cAnalisis)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            End If

            '==========Imprimir reporte segun opcion ================
            opcion = If(rbtAnalisis_0.Checked = True, "1", If(rbtAnalisis_1.Checked = True, "2", "3"))
            If rbtAnalisis_3.Checked = True Then
                nombredereporte = "AnCtaCteHistorial.Rpt"
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - HISTORIAL"
            ElseIf rbtAnalisis_2.Checked = True Then
                nombredereporte = "AnCtaCteHis.Rpt"
                'Sp que trae datoas del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - HISTORICO"
            ElseIf rbtAnalisis_4.Checked = True Then
                nombredereporte = "anctacte_AjusxDifCambio_Res.rpt"
                'Sp que trae datoas del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte_Ajuste_TipCambio", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - AJUSTE POR TIPO CAMBIO (Resumido)"
            ElseIf rbtAnalisis_5.Checked = True Then
                nombredereporte = "anctacte_AjusxDifCambio.Rpt"
                'Sp que trae datoas del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte_Ajuste_TipCambio", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - AJUSTE POR TIPO CAMBIO (Detallado)"
            Else
                nombredereporte = "AnCtaCte.Rpt"
                'Sp que trae datoas del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE " & If(rbtAnalisis_0.Checked = True, "PENDIENTES", "CANCELADOS")
            End If

            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", desperiodo))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("titulo", titu))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Rango", desRango))

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
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""

        Dim cAnalisis As String = ""
        Dim titu As String = ""
        Dim desperiodo As String
        Dim flagtab As String = ""
        Dim flagcuenta As String = ""
        Dim opcion As String = ""
        Dim desRango As String

        'LLeno el rango de valores
        Try
            'Destino del reporte
            

            desperiodo = "PERIODO : " + gbano + "-" + gbmes

            Rutareporte = gbRutaReportes

            Cursor.Current = Cursors.WaitCursor

            If tabOpciones.SelectedIndex = 0 Then 'Ctas Ctable
                '=========Inserto Filas seleecionadas
                flagtiporeporte = "ANCTACTECU"
                flagtab = "C"
                flagcuenta = "*"
                desRango = ""
                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            Else 'si es por Cuenta Corriente
                '=========Inserto Filas seleecionadas ==========
                flagtiporeporte = "ANCTACTETE"
                flagtab = "T"
                flagcuenta = cbocuentas.Text.Trim
                desRango = "Cuenta : " + cbocuentas.Text

                'Inserto los valores selecioandos
                cAnalisis = Mod_BaseDatos.DameDescripcion(gbano + cbocuentas.Text.Trim, "UT")

                If tblconsulta1.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadasmasvalor(flagtiporeporte, tblconsulta1, tblconsulta1.Columns(0).DataField, cAnalisis)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            End If

            '==========Imprimir reporte segun opcion ================
            opcion = If(rbtAnalisis_0.Checked = True, "1", If(rbtAnalisis_1.Checked = True, "2", "3"))


            If rbtAnalisis_3.Checked = True Then
                nombredereporte = "AnCtaCteHistorial.Rpt"
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - HISTORIAL"
            ElseIf rbtAnalisis_2.Checked = True Then
                nombredereporte = "AnCtaCteHis.Rpt"
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - HISTORICO"
            ElseIf rbtAnalisis_4.Checked = True Then
                nombredereporte = "anctacte_AjusxDifCambio_Res.rpt"
                ds = objSql.TraerDataSet(" sp_Con_Rep_AnalisisCtaCte_Ajuste_TipCambio", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - AJUSTE POR TIPO CAMBIO (Resumido)"
            ElseIf rbtAnalisis_5.Checked = True Then
                nombredereporte = "anctacte_AjusxDifCambio.Rpt"
                ds = objSql.TraerDataSet(" sp_Con_Rep_AnalisisCtaCte_Ajuste_TipCambio", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                titu = "CUENTA CORRIENTE - AJUSTE POR TIPO CAMBIO (Detallado)"
            Else
                If (rbtAnalisis_0.Checked = True Or rbtAnalisis_1.Checked = True) Then
                    nombredereporte = "AnCtaCte.Rpt"
                    ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                    titu = "CUENTA CORRIENTE " & If(rbtAnalisis_0.Checked = True, "PENDIENTES", "CANCELADOS")
                ElseIf (rbtAnalisis_6.Checked = True Or rbtAnalisis_7.Checked = True) Then
                    nombredereporte = "AnCtaCte_Resumen.Rpt"
                    opcion = If(rbtAnalisis_6.Checked = True, "1", If(rbtAnalisis_7.Checked = True, "2", "3"))
                    ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaCte", gbcodempresa, gbano, gbmes, gbmoneda, flagtab, flagcuenta, gbNameUser, opcion).Copy()
                    'Sp que trae datoas del reporte
                    titu = "CUENTA CORRIENTE - RESUMEN " & If(rbtAnalisis_6.Checked = True, "PENDIENTES", "CANCELADOS")
                   
                End If
            End If
            '

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", desperiodo))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("titulo", titu))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Rango", desRango))

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
    Private Sub Frm_AnaCtaCte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            '
            Me.Text = "Analisis de cuenta corriente"

            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_1, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_2, gbc_Ttp_SelecTodasFilas)

            Me.traecuentas()
            Me.LlenarComboctas()

            
            '====
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub cbocuentas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocuentas.SelectedIndexChanged
        Dim cOldCuenta As String
        cOldCuenta = cbocuentas.Text
        Me.TraeCuentaCorrientexxCuenta()
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub
    Private Sub btnseleccionartodo_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_1.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta1)
    End Sub
    Private Sub btnseleccionartodo_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_2.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta2)
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class