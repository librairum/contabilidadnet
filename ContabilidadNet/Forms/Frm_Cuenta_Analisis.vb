Public Class Frm_Cuenta_Analisis
#Region "Declaraciones"
    Dim vista As DataView
    Dim vistahelp As DataView
    Private filaactiva As DataRowView
    Dim filaactual As Integer

#End Region
#Region "Mantenimiento"

    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)

        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String
        Dim tipoanalisis As String
        Dim nombreper As String

        'LLeno el rango de valores
        Try

            'Validar que existan regitrso para imprimir
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then MessageBox.Show(gbc_MensajeValidar + "Cuenta no Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If tblconsulta.RowCount < 0 Then MessageBox.Show(gbc_MensajeValidar + "No existen registros", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            '====
            Cursor.Current = Cursors.WaitCursor

            nombreper = "PERIODO : " + gbano + "-" + gbmes
            Rutareporte = gbRutaReportes
            '========================================
            If rbtanalisis_0.Checked = True Then
                tipoanalisis = gbmes
            Else
                tipoanalisis = "01"
            End If


            If gbTipoImpresora = "M" Then
                ds = objSql.TraerDataSet("sp_Con_Rep_AnalisisCtaMovim", gbcodempresa, gbano, tipoanalisis, gbmes, gbmoneda, txtCuenta.Text).Copy()
                nombredereporte = "AnMoCuen.Rpt"
            Else
                MessageBox.Show(gbc_MensajeValidar + gbm_repnodisenimpiny, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
            '
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))

            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Sub TraerAyuda(ByVal index As Integer, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp.Location = New Point(x, y)

            '
            Dim columna2 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna2 = tblhelp.Columns(2)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            Dim columna3 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna3 = tblhelp.Columns(3)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            Mod_Mantenimiento.LimpiarFiltro(tblhelp)

            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"



            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.traecuenta("sp_Con_Help_Cuentas_HabYMov")
                    txtCuenta.Focus()
            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtCuenta.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text, "C3")
                    End If
            End Select

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    If tblhelp.Columns("ccm01mov").Value.ToString = "S" Then
                        txtCuenta.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                        lblhelp_0.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                        txtCuenta.Focus()
                    Else
                        txtCuenta.Text = ""
                        lblhelp_0.Text = ""
                        MessageBox.Show("AVISO :: La Cuenta no es de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCuenta.Focus()
                    End If

            End Select
            vistahelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Traer Informacion de Base de Datos"
    Sub traeAnalisiCuenta(ByVal cuenta As String)
        Dim tipoanalisis As String
        Try
            Cursor.Current = Cursors.WaitCursor
            If rbtanalisis_0.Checked = True Then
                tipoanalisis = gbmes
            Else
                tipoanalisis = "01"
            End If
            vista = objSql.TraerDataTable("sp_Con_Rep_AnalisisCtaMovim", gbcodempresa, gbano, tipoanalisis, gbmes, gbmoneda, cuenta).DefaultView
            tblconsulta.SetDataBinding(vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub
#End Region
    Private Sub btnconsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconsultar.Click
        Me.mostraranalisis()
    End Sub
    Sub mostraranalisis()
        Try
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then MessageBox.Show(gbc_MensajeValidar + "Cuenta No Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            'Traer Analisis

            Me.traeAnalisiCuenta(txtCuenta.Text)
            'Mostrar Totale
            Me.Mostrartotales()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traecuenta(ByVal query As String)
        Try
            vistahelp = objSql.TraerDataTable(query, gbcodempresa, gbano, "*", "*").DefaultView
            tblhelp.SetDataBinding(vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub Mostrartotales()
        Try
            If vista.Count > 0 Then
                filaactual = Me.BindingContext(vista).Position ' El position no funciona, solo devuelve la fila a del gridview
                filaactiva = vista.Table.DefaultView.Item(filaactual)
            Else
                MessageBox.Show("No exite Movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If filaactiva Is Nothing Then Exit Sub

            txtDebAnt_0.Text = filaactiva("Saldo_Anterior_Debe").ToString
            txtHabAnt_0.Text = filaactiva("Saldo_Anterior_Haber").ToString
            txtSalAnt_0.Text = CDbl(txtDebAnt_0.Text) - CDbl(txtHabAnt_0.Text)
            txtDebAnt_1.Text = filaactiva("Saldo_Anterior_Cargo").ToString
            txtHabAnt_1.Text = filaactiva("Saldo_Anterior_Abono").ToString
            txtSalAnt_1.Text = CDbl(txtDebAnt_1.Text) - CDbl(txtHabAnt_1.Text)
            ' Muestro los Saldos al Mes
            txtDebAct_0.Text = filaactiva("Saldo_AlMes_Debe").ToString
            txtHabAct_0.Text = filaactiva("Saldo_AlMes_Haber").ToString
            txtSalAct_0.Text = CDbl(txtDebAct_0.Text) - CDbl(txtHabAct_0.Text)
            txtDebAct_1.Text = filaactiva("Saldo_AlMes_Cargo").ToString
            txtHabAct_1.Text = filaactiva("Saldo_AlMes_Abono").ToString
            txtSalAct_1.Text = CDbl(txtDebAct_1.Text) - CDbl(txtHabAct_1.Text)
            ' Muestro los Totales
            txtDebMes_0.Text = CDbl(txtDebAct_0.Text) - CDbl(txtDebAnt_0.Text)
            txtHabMes_0.Text = CDbl(txtHabAct_0.Text) - CDbl(txtHabAnt_0.Text)
            txtSalMes_0.Text = CDbl(txtDebMes_0.Text) - CDbl(txtHabMes_0.Text)
            txtDebMes_1.Text = CDbl(txtDebAct_1.Text) - CDbl(txtDebAnt_1.Text)
            txtHabMes_1.Text = CDbl(txtHabAct_1.Text) - CDbl(txtHabAnt_1.Text)
            txtSalMes_1.Text = CDbl(txtDebMes_1.Text) - CDbl(txtHabMes_1.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub Frm_Cuenta_Analisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            '

            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Enter Then
            Me.TraeDameDescripcion(0)
            Me.mostraranalisis()
        End If
    End Sub

    Private Sub txtCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuenta.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub

    Private Sub rbtanalisis_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtanalisis_1.Click
        Me.mostraranalisis()
    End Sub

    Private Sub rbtanalisis_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtanalisis_0.CheckedChanged

    End Sub

    Private Sub rbtanalisis_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtanalisis_0.Click
        Me.mostraranalisis()
    End Sub

    Private Sub txtCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuenta.TextChanged

    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
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