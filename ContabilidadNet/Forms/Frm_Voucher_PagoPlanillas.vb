Option Explicit On
Option Strict On

Public Class Frm_Voucher_PagoPlanillas
#Region "Declaraciones"
    Dim Vista As New DataView
    Dim Vistahelp As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim frmOrigen As Frm_Voucher_Abc
    Private _countries As New Hashtable()
    Private _cities As New Hashtable()
#End Region

#Region "Propiedades"
    Public Property P_FilaDeTabla() As DataRowView
        Get
            Return FilaDeTabla
        End Get
        Set(ByVal value As DataRowView)
            FilaDeTabla = value
        End Set
    End Property
#End Region

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
#Region "Base de datos"
    Sub TraeLibros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traecuenta(ByVal query As String)
        Try
            Vistahelp = objSql.TraerDataTable(query, gbcodempresa, gbano, "*", "*").DefaultView
            tblhelp.SetDataBinding(Vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traeTipoProceso(ByVal campo As String, ByVal filtro As String)
        Try
            Vistahelp = objSql.TraerDataTable("Spu_Con_Trae_TipoProceso", campo, filtro).DefaultView
            tblhelp.SetDataBinding(Vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traeclaseplanilla(ByVal campo As String, ByVal filtro As String)
        Try
            Vistahelp = objSql.TraerDataTable("Spu_Con_Trae_Placlaseplanilla", campo, filtro).DefaultView
            tblhelp.SetDataBinding(Vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traeperiodopagopla(ByVal CodigoClaPlanilla As String, ByVal campo As String, ByVal filtro As String)
        Try
            Vistahelp = objSql.TraerDataTable("Spu_Con_Trae_Plaperiodopago", gbEmpresaPlanilla, CodigoClaPlanilla, campo, filtro).DefaultView
            tblhelp.SetDataBinding(Vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traeperiodopago()
        Try
            Vistahelp = objSql.TraerDataTable("Spu_Con_Help_ccb03perTodos", gbcodempresa).DefaultView
            tblhelp.SetDataBinding(Vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traeConceptosPago(ByVal CodigoClaPlanilla As String, ByVal codperiodo As String, ByVal campo As String, ByVal filtro As String)
        Try
            Vistahelp = objSql.TraerDataTable("Spu_Con_Trae_PlaConxPla", gbEmpresaPlanilla, CodigoClaPlanilla, codperiodo, campo, filtro).DefaultView
            tblhelp.SetDataBinding(Vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerImportes(ByVal CodigoClaPlanilla As String, ByVal codperiodo As String, ByVal CodConcepto As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ImpConcepto", gbEmpresaPlanilla, CodigoClaPlanilla, codperiodo, CodConcepto).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            'Pintar el total
            Me.calcTotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerImportesVaca(ByVal CodigoClaPlanilla As String, ByVal codperiodo As String)
        Dim anio As String
        Dim mes As String
        anio = Funciones.Funciones.izquierda(codperiodo, 4)
        mes = Funciones.Funciones.derecha(codperiodo, 2)

        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ProvVacaciones", gbEmpresaPlanilla, CodigoClaPlanilla, anio, mes).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)

            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            'Pintar el total
            Me.calcTotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerImportesGrati(ByVal CodigoClaPlanilla As String, ByVal codperiodo As String)
        Dim anio As String
        Dim mes As String
        anio = Funciones.Funciones.izquierda(codperiodo, 4)
        mes = Funciones.Funciones.derecha(codperiodo, 2)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ProvGratificaciones", gbEmpresaPlanilla, CodigoClaPlanilla, anio, mes).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            'Pintar el total
            Me.calcTotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerImportesCTS(ByVal CodigoClaPlanilla As String, ByVal codperiodo As String)
        Dim anio As String
        Dim mes As String
        anio = Funciones.Funciones.izquierda(codperiodo, 4)
        mes = Funciones.Funciones.derecha(codperiodo, 2)

        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ProvCTS", gbEmpresaPlanilla, CodigoClaPlanilla, anio, mes).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            'Pintar el total
            Me.calcTotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region


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
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()
                Case 1
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.traecuenta("sp_Con_Help_Cuentas_HabYMov")
                    txtCuenta.Focus()
                Case 2
                    tblhelp.Columns(0).DataField = "CodigoClasePlanilla"
                    tblhelp.Columns(1).DataField = "Descripcion"
                    Me.traeclaseplanilla("CodigoClasePlanilla", "*")
                Case 3
                    If txttipocalculo.Text = "01" Then
                        tblhelp.Columns(0).DataField = "CodigoPeriodo"
                        tblhelp.Columns(1).DataField = "Descripcion"
                        Me.traeperiodopagopla(Trim(txtclaseplanilla.Text), "CodigoPeriodo", "*")
                    Else
                        tblhelp.Columns(0).DataField = "ccb03cod"
                        tblhelp.Columns(1).DataField = "ccb03des"
                        Me.traeperiodopago()
                    End If
                Case 4
                    tblhelp.Columns(0).DataField = "CodigoConcepto"
                    tblhelp.Columns(1).DataField = "Descripcion"
                    Me.traeConceptosPago(Trim(txtclaseplanilla.Text), Trim(txtplanilla.Text), "CodigoConcepto", "*")
                Case 5
                    tblhelp.Columns(0).DataField = "CodigoTipoProceso"
                    tblhelp.Columns(1).DataField = "Descripcion"
                    Me.traeTipoProceso("CodigoTipoProceso", "*")

            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub muestraconcepto(ByVal valor As Boolean)
        txtcodconcepto.Visible = valor
        btnhelp_4.Visible = valor
        lblhelp_4.Visible = valor
        lblconcepto.Visible = valor
    End Sub
    Private Sub Frm_Voucher_PagoPlanillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Registrar Voucher de planillas"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '===Cargar datos del padre

            frmOrigen = CType(Me.Owner, Frm_Voucher_Abc)
            '
            txtlibro.Text = frmOrigen.txtlibro.Text
            TraeDameDescripcion(0)
            txtNoVoucher.Text = frmOrigen.txtNoVoucher.Text
            mskfecha.Text = frmOrigen.mskfecha.Text
            txtTipCambio.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "V")
            '===
            frmOrigen = CType(Me.Owner, Frm_Voucher_Abc)
            '===
            Mod_Mantenimiento.ocultarbotonespercerrado(Me)

            'Ocular generacion de voucher si el periodo esta cerrado
            If Periodocerrado() = True Then
                btngenerar.Visible = False
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Try
            filaactual = Me.BindingContext(Vista).Position ' 
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btntraerimportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntraerimportes.Click
        If txttipocalculo.Text = "01" Then
            Me.TraerImportes(txtclaseplanilla.Text, txtplanilla.Text, txtcodconcepto.Text)
        ElseIf txttipocalculo.Text = "02" Then '
            Me.TraerImportesVaca(txtclaseplanilla.Text, txtplanilla.Text)
        ElseIf txttipocalculo.Text = "03" Then
            Me.TraerImportesGrati(txtclaseplanilla.Text, txtplanilla.Text)
        ElseIf txttipocalculo.Text = "04" Then
            Me.TraerImportesCTS(txtclaseplanilla.Text, txtplanilla.Text)
        End If
    End Sub

    Private Sub btnhelp_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_2.Click
        Me.TraerAyuda(2, btnhelp_2)
    End Sub

    Private Sub btnhelp_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_3.Click
        Me.TraerAyuda(3, btnhelp_3)
    End Sub

    Private Sub btnhelp_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_4.Click
        Me.TraerAyuda(4, btnhelp_4)
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Me.TraerAyuda(1, btnhelp_1)
    End Sub
    Private Sub calcTotal()
        Dim total As Double
        Try


            total = 0
            ' clear our counters
            Me._countries.Clear()
            Me._cities.Clear()
            ' get the total # of rows in the grid
            Dim rows As Integer = Me.tblconsulta.Splits(0).Rows.Count

            ' now compute the number of unique values for the country and city columns
            Dim i As Integer

            For i = 0 To rows - 1
                total = total + CDbl(Me.tblconsulta(i, "Importe").ToString())
            Next i

            Me.tblconsulta.Columns("Importe").FooterText = Format(total, "###,###,###,##0.00")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub '_calcFooter
    Private Sub btngenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngenerar.Click
        Dim nDebSol As Double
        Dim nHabSol As Double
        Dim nDebDol As Double
        Dim nHabDol As Double
        Dim Erro As Integer = 0

        Dim moneda As String
        '
        Dim ctipdoc As String = ""
        Dim cndoc As String = ""
        Dim cFecDoc As String = ""
        Dim cFecVen As String = ""
        Dim cFecPag As String = ""
        Dim ctacte As String = ""

        Try
            'Valido que exista Datos

            If lblhelp_0.Text = "" Or lblhelp_0.Text = "???" Then MessageBox.Show(gbc_MensajeValidar + "Libro no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If lblhelp_1.Text = "" Or lblhelp_1.Text = "???" Then MessageBox.Show(gbc_MensajeValidar + "Cuenta no Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then Exit Sub
            '
            If Trim(cbomoneda.Text) = "" Then MsgBox("Moneda No valido", vbCritical) : Exit Sub


            If (btncargoabono_0.Checked = False And btncargoabono_1.Checked = False) Then
                MessageBox.Show("Debe seleccionar si se carga o Abona") : Exit Sub
            End If

            moneda = cbomoneda.Text
            cFecDoc = mskfecha.Text

            If tblconsulta.RowCount <= 0 Then MessageBox.Show(gbc_MensajeValidar + "No Existe detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            Dim rows As Integer = Me.tblconsulta.Splits(0).Rows.Count

            ' now compute the number of unique values for the country and city columns
            Dim i As Integer

            For i = 0 To rows - 1
                'Inicio valores
                nDebSol = 0
                nHabSol = 0
                nDebDol = 0
                nHabDol = 0
                ctipdoc = ""
                cndoc = ""
                ctacte = ""

                '=====
                ctipdoc = txtTipDoc.Text
                ctacte = Funciones.Funciones.derecha(Me.tblconsulta(i, "CodigoEmpleado").ToString.Trim, 4)
                cndoc = txtNoDoc.Text
                '=====
                If cbomoneda.Text = "S" Then
                    If btncargoabono_0.Checked = True Then
                        nDebSol = CType(Me.tblconsulta(i, "Importe").ToString(), Double)
                        nHabSol = 0
                        '
                        nDebDol = nDebSol / CType(txtTipCambio.Text, Double)
                        nHabDol = 0
                    Else
                        nDebSol = 0
                        nHabSol = CType(Me.tblconsulta(i, "Importe").ToString(), Double)
                        '
                        nDebDol = 0
                        nHabDol = nHabSol / CType(txtTipCambio.Text, Double)
                    End If
                ElseIf cbomoneda.Text = "D" Then
                    If btncargoabono_0.Checked = True Then
                        nDebDol = CType(Me.tblconsulta(i, "Importe").ToString(), Double)
                        nHabDol = 0

                        nDebSol = nDebDol * CType(txtTipCambio.Text, Double)
                        nHabSol = 0
                    Else
                        nHabDol = CType(Me.tblconsulta(i, "Importe").ToString(), Double)
                        nDebDol = 0

                        nHabSol = nDebDol# * CType(txtTipCambio.Text, Double)
                        nDebSol = 0
                    End If
                Else
                    MsgBox("Moneda No Valida", vbCritical) : Exit Sub
                End If


                a = objSql.Ejecutar2("sp_Con_Ins_Detalle_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text, _
                            txtCuenta.Text, nDebSol, nHabSol, txtConcepto.Text, ctipdoc, cndoc, _
                            cFecDoc, cFecVen, ctacte, moneda, CDbl(txtTipCambio.Text), "", _
                            "", "", "", "", nDebDol, nHabDol, "N", "", _
                            "N", "", "", "", "", "", "", cFecPag, "", "", _
                            txtcomprobante.Text, "", "", "", "", "", "", 0, "")

                If a.GetValue(1, 0).ToString = "-1" Then 'Lee la variable RETURN_VALUES
                    Erro = Erro + 1
                End If

            Next
            '
            If Erro <> 0 Then
                MessageBox.Show(gbc_MensajeError + "Error Inesperado", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                frmOrigen.refrescarGrilla()
            End If
            '
            Cursor.Current = Cursors.Default
            '
        Catch ex As Exception
            Cursor.Current = Cursors.Default
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
                    If txtCuenta.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text, "C3")
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
                    txtlibro.Text = tblhelp.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp.Columns("ccb02des").Value.ToString
                    txtlibro.Focus()
                Case 1
                    If tblhelp.Columns("ccm01mov").Value.ToString = "S" Then
                        txtCuenta.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                        lblhelp_1.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                        txtCuenta.Focus()
                    Else
                        txtCuenta.Text = ""
                        lblhelp_1.Text = ""
                        MessageBox.Show("AVISO :: La Cuenta no es de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCuenta.Focus()
                    End If
                Case 2
                    txtclaseplanilla.Text = tblhelp_p.Columns("CodigoClasePlanilla").Value.ToString
                    lblhelp_2.Text = tblhelp_p.Columns("Descripcion").Value.ToString
                    txtclaseplanilla.Focus()
                Case 3
                    If txttipocalculo.Text = "01" Then
                        txtplanilla.Text = tblhelp_p.Columns("CodigoPeriodo").Value.ToString
                        lblhelp_3.Text = tblhelp_p.Columns("Descripcion").Value.ToString
                        txtplanilla.Focus()
                    Else
                        txtplanilla.Text = tblhelp_p.Columns("ccb03cod").Value.ToString
                        lblhelp_3.Text = tblhelp_p.Columns("ccb03des").Value.ToString
                        txtplanilla.Focus()
                    End If

                Case 4
                    txtcodconcepto.Text = tblhelp_p.Columns("CodigoConcepto").Value.ToString
                    lblhelp_4.Text = tblhelp_p.Columns("Descripcion").Value.ToString
                    txtcodconcepto.Focus()
                Case 5
                    txttipocalculo.Text = tblhelp_p.Columns("CodigoTipoProceso").Value.ToString
                    lblhelp_5.Text = tblhelp_p.Columns("Descripcion").Value.ToString
                    txttipocalculo.Focus()
            End Select

            Vistahelp.Dispose()
            tblhelp.Visible = False
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
        Try
            tblhelp.Visible = False
            VistaHelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mskfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskfecha.LostFocus
        txtTipCambio.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "V")
    End Sub

    Private Sub txtclaseplanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtclaseplanilla.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtplanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtplanilla.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_3_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtcodconcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodconcepto.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_4_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtlibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibro.LostFocus
        TraeDameDescripcion(0)
    End Sub

    Private Sub txtlibro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlibro.TextChanged

    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuenta.LostFocus
        TraeDameDescripcion(1)
    End Sub

    Private Sub txtCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuenta.TextChanged

    End Sub

    Private Sub btnhelp_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_5.Click
        Me.TraerAyuda(5, btnhelp_5)
    End Sub

    Private Sub txttipocalculo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttipocalculo.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_5_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txttipocalculo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipocalculo.LostFocus
        If txttipocalculo.Text <> "01" Then
            Me.muestraconcepto(False)
        Else
            Me.muestraconcepto(True)
        End If
    End Sub

    Private Sub txttipocalculo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipocalculo.TextChanged

    End Sub

    Private Sub txtclaseplanilla_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtclaseplanilla.TextChanged

    End Sub
End Class