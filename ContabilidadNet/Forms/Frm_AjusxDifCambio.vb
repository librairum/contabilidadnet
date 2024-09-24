Option Strict On
Option Explicit On

Public Class Frm_AjusxDifCambio

#Region "Declaraciones"
    Dim Vista As New DataView
    Dim VistaHelp As DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#End Region
#Region "Traer Informacion de Base de Datos"
    Sub TraeLibros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerCuentas(ByVal moneda As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Help_Cuentas_AjDifCam", gbcodempresa, gbano, moneda).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerCuentasGanPer()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Cuentas_HabYMov", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
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
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()
                Case 1
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraerCuentasGanPer()
                Case 2
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraerCuentasGanPer()
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
                    txtlibro.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtlibro.Focus()
                Case 1
                    txtctaperdida.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                    lblhelp_1.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                    txtctaperdida.Focus()
                Case 2
                    txtctaganancia.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                    lblhelp_2.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                    txtctaganancia.Focus()
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
                    If txtlibro.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtlibro.Text, "LI")
                    End If
                Case 1
                    If txtctaperdida.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(gbano + txtctaperdida.Text.Trim, "C3")
                    End If
                Case 2
                    If txtctaganancia.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = Mod_BaseDatos.DameDescripcion(gbano + txtctaganancia.Text.Trim, "C3")
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Coloco la Fecha de Voucher
    Private Sub Valorespordefecto()
        Try
            mskfecha.Text = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) + "/" + gbmes + "/" + gbano
            txtDescripcion.Text = "AJUSTE POR DIFERENCIA DE CAMBIO PENDIENTES"
            txtTipCambio.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "V")
            txtctaperdida.Text = gbCuentaPerDifCam
            txtctaganancia.Text = gbCuentaGanDifCam
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

    Private Sub Frm_AjusxDifCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim moneda As String
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Me.Text = "Diferencia de cambio"
            Me.Valorespordefecto()
            moneda = If(gbmoneda = "S", "D", "S")
            Me.TraerCuentas(moneda)
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            '
            If Periodocerrado() = True Then
                btnGenVou.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        Try
            tblhelp.Visible = False
            VistaHelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub mskfecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskfecha.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskfecha.LostFocus
        txtTipCambio.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "C")
    End Sub

    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""
        Dim mesdemayor As String = ""
        Dim flagAjuste As String = ""
        Dim flagAnalisis As String = ""
        Dim desperiodo As String = ""
        Dim Titulo As String
        'LLeno el rango de valores
        Try
            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then MessageBox.Show("VALIDAR :: Tipo de Cambio no Valdo", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Barro el Arreglo de Cuentas Marcadas (Bookmarks)
            desperiodo = MDIPrincipal.cboperiodos.Text

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "REPDIFCAM"
            'Inserto los valores selecioandos

            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            ' Asigno los Valores de Formulas Fijas a Mostrarse en el Reporte
            flagAjuste = If(rbtAjuste_0.Checked = True, "D", "S")
            flagAnalisis = If(rbtanalisis_0.Checked = True, "P", "C")
            Titulo = "AJUSTE POR DIFERENCIA DE CAMBIO - " + If(rbtanalisis_0.Checked = True, "PENDIENTES", "CANCELADOS")

            nombredereporte = "AjDifCam.rpt"

            'Sp que trae datoas del reporte
            ds = objSql.TraerDataSet("sp_Con_Rep_DiferenciaCambio", gbcodempresa, gbano, gbmes, flagAjuste, flagAnalisis, CType(txtTipCambio.Text, Double), gbNameUser).Copy()

            'Formulas de reporte
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", desperiodo))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Titulo", Titulo))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Rango", txtTipCambio.Text))

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
        Dim mesdemayor As String = ""
        Dim flagAjuste As String = ""
        Dim flagAnalisis As String = ""
        Dim desperiodo As String = ""
        Dim Titulo As String
        'LLeno el rango de valores
        Try
          

            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then MessageBox.Show("VALIDAR :: Tipo de Cambio no Valdo", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Barro el Arreglo de Cuentas Marcadas (Bookmarks)
            desperiodo = "PERIODO : " + gbano + "-" + gbmes

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "REPDIFCAM"
            'Inserto los valores selecioandos

            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            ' Asigno los Valores de Formulas Fijas a Mostrarse en el Reporte
            flagAjuste = If(rbtAjuste_0.Checked = True, "D", "S")
            flagAnalisis = If(rbtanalisis_0.Checked = True, "P", "C")
            Titulo = "AJUSTE POR DIFERENCIA DE CAMBIO - " + If(rbtanalisis_0.Checked = True, "PENDIENTES", "CANCELADOS")

            nombredereporte = "AjDifCam.rpt"
            ds = objSql.TraerDataSet("sp_Con_Trae_TipoCambio_Impresion", gbcodempresa, gbano, gbmes, flagAjuste, flagAnalisis, txtTipCambio.Text, gbNameUser).Copy()


            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", desperiodo))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", Titulo))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Rango", txtTipCambio.Text))
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
    Private Sub btnGenVou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenVou.Click

        Dim flagtrango As String = ""
        Dim flagAjuste As String
        Dim flagAnalisis As String
        Try
            '==========Validar
            If tblconsulta.SelectedRows.Count <= 0 Then MessageBox.Show("VALIDAR :: No selecciono registros ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then MessageBox.Show("VALIDAR :: Libro no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If (lblhelp_1.Text = "" Or lblhelp_1.Text = "???") Then MessageBox.Show("VALIDAR :: Cuenta de perdida no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If (lblhelp_2.Text = "" Or lblhelp_2.Text = "???") Then MessageBox.Show("VALIDAR :: Cuenta de ganacia no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If Funciones.Funciones.EsValidaFechaPorPer(mskfecha.Text, gbano.Trim + gbmes.Trim) = False Then Exit Sub
            If txtDescripcion.Text = "" Then MessageBox.Show("VALIDAR :: Descripcion no valida ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

            'Crear
            If MessageBox.Show("¿ Esta Seguro de Generar el Voucher de Ajuste por Diferencia de Cambio : " + If(rbtanalisis_0.Checked = True, "Pendientes", "Cancelados"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            flagtrango = "VOUDIFCAM"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtrango, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            flagAjuste = If(rbtAjuste_0.Checked = True, "D", "S")
            flagAnalisis = If(rbtanalisis_0.Checked = True, "P", "C")

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("sp_Con_Gen_Vouch_Difer_Cambio", gbcodempresa, gbano, gbmes, txtlibro.Text, TxtNroVoucher.Text.Trim, mskfecha.Text, _
                                 txtDescripcion.Text.Trim, txtctaperdida.Text, "", "", txtctaganancia.Text, "", "", flagAjuste, flagAnalisis, CDbl(txtTipCambio.Text), gbNameUser, "")
            '
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                'No hago nada
            End If

            'Elimnar rango de impresion
            Mod_BaseDatos.EliminaRangoImpresion(flagtrango)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Me.TraerAyuda(1, btnhelp_1)
    End Sub

    Private Sub btnhelp_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_2.Click
        Me.TraerAyuda(2, btnhelp_2)
    End Sub

    Private Sub rbtanalisis_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtanalisis_1.CheckedChanged
        txtTipCambio.Enabled = False
    End Sub

    Private Sub rbtanalisis_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtanalisis_0.CheckedChanged
        txtTipCambio.Enabled = True
    End Sub
    Private Sub mskfecha_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskfecha.MaskInputRejected

    End Sub

    Private Sub txtlibro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlibro.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtctaperdida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtctaperdida.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtctaganancia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtctaganancia.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub txtctaperdida_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaperdida.LostFocus
        Me.TraeDameDescripcion(1)
    End Sub
    Private Sub txtlibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibro.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub
    Private Sub txtctaganancia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaganancia.LostFocus
        Me.TraeDameDescripcion(2)
    End Sub

    Private Sub txtctaganancia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctaganancia.TextChanged

    End Sub

    Private Sub txtlibro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlibro.TextChanged

    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

    End Sub

    Private Sub txtctaperdida_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctaperdida.TextChanged

    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange

    End Sub
End Class