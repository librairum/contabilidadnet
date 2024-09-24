Option Strict On
Option Explicit On
Public Class Frm_Produccion_TipoGastos

    Dim Vista As New DataView
    Dim VistaHelp As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#Region "Mantenimiento"
    Sub TraerAyuda(ByVal index As Integer, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp.Location = New Point(x, y)
            Mod_Mantenimiento.LimpiarFiltro(tblhelp)
            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"

            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "cctcodigo"
                    tblhelp.Columns(1).DataField = "cctdescripcion"
                    Me.TraeTipgastoygasto("cctcodigo", "*")
            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txttipogasto.Text = tblhelp_p.Columns("cctcodigo").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("cctdescripcion").Value.ToString
                    txttipogasto.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txttipogasto.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txttipogasto.Text.Trim, "TIPGAS")
                    End If
            End Select

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
#Region "Base de Datos"
    Private Sub TraePlanctastipgastos(ByVal cCampo As String, ByVal cFiltro As String, ByVal nivel As Integer, ByVal flag As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_AreaSeccionCcosto", gbcodempresa, gbano, cCampo, cFiltro, nivel, flag).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)

            'If Not IsNothing(tblconsulta.Columns(0)) = True Then
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraeTipgastoygasto(ByVal cCampo As String, ByVal cFiltro As String)
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Trae_TipGastoGasto", gbcodempresa, gbano, cCampo, cFiltro).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

    Sub imprimir_verant(ByVal flagimpresion As String)

        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesdegastos As String
        Dim flagtiporeporte As String

        ' Asigno los Valores de Formulas Fijas a Mostrarse en el Reporte
        Dim nivelCosto As Integer
        Dim titulo As String
        Dim tipo As String

        mesdegastos = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try

            tipo = If(rbttiporeport_0.Checked = True, "T", Trim(txttipogasto.Text))
            If tipo = "" Then MessageBox.Show(gbc_MensajeValidar + "Tipo de Gasto NO valido") : Exit Sub

            'Destino del reporte
            flagtiporeporte = "CTAGAS"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            Rutareporte = gbRutaReportes
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count < 0 Then
                MessageBox.Show("AVISO :: No exiten registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            nombredereporte = "rep_areas_gastos_3.Rpt"

            nivelCosto = CInt(cboniveles.Text)

            ds = objSql.TraerDataSet("Sp_Con_Rep_GastosGenerales", gbcodempresa, gbano, gbNameUser, tipo, mesdegastos, CStr(nivelCosto)).Copy()



            If rbttiporeport_0.Checked = True Then
                titulo = "TIPO DE GASTOS POR AREAS - ACUMULADOS AL PERIODO " & gbano & "/" & mesdegastos
            Else
                titulo = lblhelp_0.Text & " POR AREAS - ACUMULADOS AL PERIODO  " & gbano & "/" & mesdegastos
            End If

            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Nivelccosto", nivelCosto))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("titulo", titulo))



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

    Private Sub Frm_Produccion_TipoGastos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Analisis por tipo de Gastos"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)

            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
            cboperiodos.SelectedIndex = CType(gbmes, Integer)
            '
            cboniveles.SelectedIndex = 1
            '
            Me.TraePlanctastipgastos("ccm01cta", "*", 2, "T")
            '
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
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub tblhelp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp.Tag, Integer)
        Try
            If tblhelp.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub

    Private Sub rbttraecuentas_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbttraecuentas_0.CheckedChanged

    End Sub

    Private Sub rbttraecuentas_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbttraecuentas_1.CheckedChanged

    End Sub

    Private Sub rbttraecuentas_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbttraecuentas_2.CheckedChanged

    End Sub

    Private Sub cboniveles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboniveles.SelectedIndexChanged
        Dim flag As String
        If Not IsNumeric((cboniveles.Text)) Then MessageBox.Show(gbc_MensajeValidar + "Nivel no Valido") : Exit Sub

        flag = If(rbttraecuentas_0.Checked = True, "T", If(rbttraecuentas_1.Checked = True, "G", "D"))
        Me.TraePlanctastipgastos("", "*", CInt(cboniveles.Text), flag)
    End Sub

    Private Sub rbttraecuentas_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbttraecuentas_0.Click
        If Not IsNumeric((cboniveles.Text)) Then MessageBox.Show(gbc_MensajeValidar + "Nivel no Valido") : Exit Sub
        Me.TraePlanctastipgastos("", "*", CInt(cboniveles.Text), "T")
    End Sub

    Private Sub rbttraecuentas_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbttraecuentas_1.Click
        If Not IsNumeric((cboniveles.Text)) Then MessageBox.Show(gbc_MensajeValidar + "Nivel no Valido") : Exit Sub
        Me.TraePlanctastipgastos("", "*", CInt(cboniveles.Text), "G")
    End Sub

    Private Sub rbttraecuentas_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbttraecuentas_2.Click
        If Not IsNumeric((cboniveles.Text)) Then MessageBox.Show(gbc_MensajeValidar + "Nivel no Valido") : Exit Sub
        Me.TraePlanctastipgastos("", "*", CInt(cboniveles.Text), "D")
    End Sub

    Private Sub rbttiporeport_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbttiporeport_1.CheckedChanged

    End Sub

    Private Sub rbttiporeport_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbttiporeport_0.CheckedChanged

    End Sub

    Private Sub rbttiporeport_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbttiporeport_0.Click
        gbxdetalle.Enabled = False
    End Sub

    Private Sub rbttiporeport_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbttiporeport_1.Click
        gbxdetalle.Enabled = True
    End Sub

    Private Sub txttipogasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttipogasto.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txttipogasto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipogasto.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub

    Private Sub txttipogasto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipogasto.TextChanged

    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange

    End Sub
End Class