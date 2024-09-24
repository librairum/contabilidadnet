Option Explicit On
Option Strict On
Public Class Frm_RegVentas_Donocion
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim Vista As DataView
    Dim Vistahelp As DataView
    Dim FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim tipoctacte As String
    'Variable para 
    Dim AccPerCon As String
    Dim VarImpChe As String

#End Region

#Region "CONSTRUCTOR"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByVal pdr As DataRow, ByVal pstrAccion As String)
        Me.New()
        'mdr = pdr
        'mstrAccion = pstrAccion
    End Sub
#End Region

#Region "PROPIEDADES"
    Public Property p_accionMante() As String
        Get
            Return accionMante
        End Get
        Set(ByVal value As String)
            accionMante = value
        End Set
    End Property
    Public Property p_RegistroActivo() As DataRowView
        Get
            Return RegistroActivo
        End Get
        Set(ByVal value As DataRowView)
            RegistroActivo = value
        End Set
    End Property
#End Region
#Region "Traer Informacion de Base de Datos"
    Sub TraeDocVentasdonaciones()
        Try
            Vista = objSql.TraerDataTable("Sp_Con_Trae_ccFacturasParaDonacion", gbcodempresa, gbano, gbmes, "").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '

            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traetipodoc(ByVal campo As String, ByVal filtro As String)
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Tipos_Documentos", gbcodempresa, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traecuenta(ByVal query As String)
        Try
            VistaHelp = objSql.TraerDataTable(query, gbcodempresa, gbano, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub trae_ctacte(ByVal tipoanalisis As String)
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_CtaCte_Por_Tipo", gbcodempresa, "*", "*", tipoanalisis).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub TraeLibros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Metodos de Mantenimiento"
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub
    Sub Nuevo()
        Me.accionMante = "N"
        Me.HabilitarMantenimiento(True)
        LimpiarControles(Me)
        '
        txtlibro.Focus()
    End Sub

    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            'Deshabilitra los controlwes que no se pueden modificar
            txtlibro.ReadOnly = True
            btnhelp_0.Enabled = False
            txtCtaCte.ReadOnly = True
            btnhelp_2.Enabled = False
            txtTipDoc.ReadOnly = True
            btnhelp_3.Enabled = False
            txtNoDoc.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            Mod_Mantenimiento.HabyDesControles(Me, valor)
            'Perosnalizar habilitacion
            btnnuevo.Visible = Not valor
            btnmodificar.Visible = Not valor
            btneliminar.Visible = Not valor
            btnsalir.Visible = Not valor
            tblconsulta.Enabled = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Public Sub refrescarGrilla()
        Me.TraeDocVentasdonaciones()
    End Sub
    Private Sub calcualtotales()
        If accionMante = "N" Then
            If IsNumeric(txtDebe_0.Text) And IsNumeric(txtHaber_0.Text) And IsNumeric(txtInafecto_0.Text) Then
                txttotal_0.Text = CStr(CDbl(txtDebe_0.Text) + CDbl(txtHaber_0.Text) + CDbl(txtInafecto_0.Text))
                txttotal_1.Text = CStr(CDbl(txtDebe_1.Text) + CDbl(txtHaber_1.Text) + CDbl(txtInafecto_1.Text))

            End If
        End If
    End Sub
    Private Sub CalculaEquivalentes(ByVal flagdh As String)
        Try
            txtDebe_0.Text = If(IsNumeric(txtDebe_0.Text) = True, txtDebe_0.Text, "0")
            txtDebe_1.Text = If(IsNumeric(txtDebe_1.Text) = True, txtDebe_1.Text, "0")
            txtInafecto_0.Text = If(IsNumeric(txtInafecto_0.Text) = True, txtInafecto_0.Text, "0")
            txtInafecto_1.Text = If(IsNumeric(txtInafecto_1.Text) = True, txtInafecto_1.Text, "0")
            txtHaber_0.Text = If(IsNumeric(txtHaber_0.Text) = True, txtHaber_0.Text, "0")
            txtHaber_1.Text = If(IsNumeric(txtHaber_1.Text) = True, txtHaber_1.Text, "0")
            txttotal_0.Text = If(IsNumeric(txttotal_0.Text) = True, txttotal_0.Text, "0")
            txttotal_1.Text = If(IsNumeric(txttotal_1.Text) = True, txttotal_1.Text, "0")


            'Calculo los Valores Equivalentes
            If cbomoneda.Text = "S" Then
                If CType(txtTipCambio.Text, Double) > 0 Then
                    txtDebe_1.Text = CType((CType(txtDebe_0.Text, Double) / CType(txtTipCambio.Text, Double)), String)
                    txtInafecto_1.Text = CType((CType(txtInafecto_0.Text, Double) / CType(txtTipCambio.Text, Double)), String)
                    txtHaber_1.Text = CType((CType(txtHaber_0.Text, Double) / CType(txtTipCambio.Text, Double)), String)
                    txttotal_1.Text = CType((CType(txttotal_1.Text, Double) / CType(txtTipCambio.Text, Double)), String)
                Else
                    txtDebe_1.Text = "0"
                    txtInafecto_1.Text = "0"
                    txtHaber_1.Text = "0"
                    txttotal_1.Text = "0"
                End If

            ElseIf cbomoneda.Text = "D" Then
                If CType(txtTipCambio.Text, Double) > 0 Then
                    txtDebe_1.Text = CType((CType(txtDebe_0.Text, Double) * CType(txtTipCambio.Text, Double)), String)
                    txtInafecto_1.Text = CType((CType(txtInafecto_0.Text, Double) * CType(txtTipCambio.Text, Double)), String)
                    txtHaber_1.Text = CType((CType(txtHaber_0.Text, Double) * CType(txtTipCambio.Text, Double)), String)
                    txttotal_1.Text = CType((CType(txttotal_0.Text, Double) * CType(txtTipCambio.Text, Double)), String)
                Else 'Si no es soles ni dolares
                    txtDebe_1.Text = "0"
                    txtInafecto_1.Text = "0"
                    txtHaber_1.Text = "0"
                    txttotal_1.Text = "0"
                End If
            Else
                MessageBox.Show(":: AVISO : Moneda no valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            '===Si cualquiera de los valores es negativo, lo transformo a cero
            If ((CType(txtDebe_0.Text, Double) < 0) Or (CType(txtDebe_1.Text, Double) < 0) Or _
                (CType(txtHaber_0.Text, Double) < 0) Or (CType(txtHaber_1.Text, Double) < 0) Or _
                (CType(txtInafecto_0.Text, Double) < 0) Or (CType(txtInafecto_1.Text, Double) < 0)) Then
                txtHaber_0.Text = "0"
                txtHaber_1.Text = "0"
                txtDebe_0.Text = "0"
                txtDebe_1.Text = "0"
                txtInafecto_0.Text = "0"
                txtInafecto_1.Text = "0"
            End If
            'Calcualr totales
            Me.calcualtotales()

        Catch ex As Exception
            MessageBox.Show(gbc_MensajeError & "No se pudo calcular equivalente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub refrescarGrillaConFiltro()
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim i As Integer = 0
        Try

            Dim myObjArray As Array = Array.CreateInstance(GetType(Object), 50, 2)  '50columnas x 2 fila

            'Guardar estado de filtro
            For Each dc In Me.tblconsulta.Columns
                If CType(dc.FilterText, String) <> "" Then
                    myObjArray.SetValue(dc.DataField, i, 0) 'Agrego valor del parametro
                    myObjArray.SetValue(dc.FilterText, i, 1) 'Agrego nombre del parametro
                End If
                i = i + 1
            Next dc

            'refresacar desde la base de datos
            Me.TraeDocVentasdonaciones()
            'Aplicar el filtro guardado
            'Inicilizo i a 0
            i = 0
            For Each dc In Me.tblconsulta.Columns
                If CType(dc.FilterText, String) <> "" Then
                    'Si estan filtrados por el mismo campo
                    If dc.DataField = myObjArray.GetValue(i, 0).ToString Then
                        dc.FilterText = myObjArray.GetValue(i, 1).ToString
                    End If
                End If
                i = i + 1
            Next dc
        Catch ex As Exception
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
                Case 2
                    If txtCtaCte.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = Mod_BaseDatos.DameDescripcion(tipoctacte & txtCtaCte.Text, "CR")
                    End If
                Case 3
                    If txtTipDoc.Text = "" Then
                        lblhelp_3.Text = ""
                    Else
                        lblhelp_3.Text = Mod_BaseDatos.DameDescripcion(txtTipDoc.Text, "TD")
                    End If

            End Select

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()
                Case 1
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.traecuenta("sp_Con_Help_Cuentas_HabYMov")
                Case 2
                    tblhelp.Columns(0).DataField = "ccm02cod"
                    tblhelp.Columns(1).DataField = "ccm02nom"
                    Me.trae_ctacte(tipoctacte)
                Case 3
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.traetipodoc("ccb02cod", "*")
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
                    txtNoVoucher.Focus()
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
                    txtCtaCte.Text = tblhelp_p.Columns("ccm02cod").Value.ToString
                    lblhelp_2.Text = tblhelp_p.Columns("ccm02nom").Value.ToString
                    txtTipDoc.Focus()
                Case 3
                    txtTipDoc.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_3.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtNoDoc.Focus()
            End Select

            Vistahelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtlibro.Text = filaactiva("Libro").ToString
                Me.TraeDameDescripcion(0)
                txtNoVoucher.Text = filaactiva("nrodevoucher").ToString
                txtCuenta.Text = filaactiva("cuentactble").ToString
                Me.TraeDameDescripcion(1)

                txtCtaCte.Text = filaactiva("Cuenta_Corriente").ToString
                tipoctacte = filaactiva("Analisis").ToString
                Me.TraeDameDescripcion(2)
                txtTipDoc.Text = filaactiva("Tipo_Documento").ToString
                Me.TraeDameDescripcion(3)
                txtNoDoc.Text = filaactiva("Numero_Documento").ToString
                mskFecDoc.Text = filaactiva("Fecha_documento").ToString
                cbomoneda.Text = filaactiva("moneda").ToString



                txtTipCambio.Text = filaactiva("tipodecambio").ToString

                If cbomoneda.Text = "S" Then
                    txtDebe_0.Text = filaactiva("base_imponible").ToString
                    txtInafecto_0.Text = filaactiva("base_inafecta").ToString
                    txtHaber_0.Text = filaactiva("Igv").ToString
                    txttotal_0.Text = filaactiva("Total").ToString

                    txtDebe_1.Text = filaactiva("base_imponibleDolares").ToString
                    txtInafecto_1.Text = filaactiva("base_inafectaDol").ToString
                    txtHaber_1.Text = filaactiva("IgvDolares").ToString
                    txttotal_1.Text = filaactiva("TotalDolares").ToString

                Else
                    txtDebe_1.Text = filaactiva("base_imponible").ToString
                    txtInafecto_1.Text = filaactiva("base_inafecta").ToString
                    txtHaber_1.Text = filaactiva("Igv").ToString
                    txttotal_1.Text = filaactiva("Total").ToString

                    txtDebe_0.Text = filaactiva("base_imponibleDolares").ToString
                    txtInafecto_0.Text = filaactiva("base_inafectaDol").ToString
                    txtHaber_0.Text = filaactiva("IgvDolares").ToString
                    txttotal_0.Text = filaactiva("TotalDolares").ToString
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


#End Region
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.cargarDatos(FilaDeTabla)
        Me.HabilitarMantenimiento(False)
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Me.modificar()
    End Sub

    Sub Posicionar(ByVal campo As String, ByVal ValorCampo As String, ByVal Grilla As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal vista1 As DataView)
        Try
            campo = Trim(campo)
            ValorCampo = Trim(ValorCampo)
            '
            vista1.Sort = campo
            Dim fila As Integer = vista1.Find(ValorCampo)
            If fila <> -1 Then
                With Grilla
                    .Bookmark = fila
                End With
            End If
        Catch ex As Exception
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
    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub
    Private Sub Frm_Maquinas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)

            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            Me.Text = "Registrar documentos de venta por donaciones"
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Me.TraeDocVentasdonaciones()
            HabilitarMantenimiento(False)
            '
            Me.cargarDatos(RegistroActivo)
            '
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub eliminar()
        Dim identificador As String
        Dim identificadorAnt As String
        Dim filaAnterior As Integer
        Dim FilaDeTablaAnterior As DataRowView

        Try
            '=============Validaciones ============
            'Capturo la fila anterior para posicionarme despues de la eliminacion
            If filaactual > 0 Then
                filaAnterior = filaactual - 1
            Else
                filaAnterior = filaactual
            End If
            FilaDeTablaAnterior = Vista.Table.DefaultView.Item(filaAnterior)

            identificadorAnt = FilaDeTablaAnterior("identificador").ToString
            identificador = FilaDeTabla("identificador").ToString
            '
            Beep()
            If MessageBox.Show("AVISO :: Esta seguro de Eliminar el REGISTRO : " & txtNoDoc.Text.Trim, "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Sp_Con_Del_ccFacturasParaDonacion", gbcodempresa, gbano, gbmes, txtlibro.Text, txtCtaCte.Text, txtTipDoc.Text, txtNoDoc.Text, "")

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("identificador", identificadorAnt, tblconsulta, Vista)
            Else
                'No hago nada
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Me.eliminar()
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Try
            Me.capturarfilaactual()
            Me.cargarDatos(FilaDeTabla)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim cFecDoc As String
        Try
            'Valida
            If (lblhelp_0.Text = "???" Or lblhelp_0.Text = "") Then Beep() : MessageBox.Show(gbc_MensajeValidar & "Libro no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtlibro.Focus() : Exit Sub
            If (lblhelp_1.Text = "???" Or lblhelp_1.Text = "") Then Beep() : MessageBox.Show(gbc_MensajeValidar & "Cuenta no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCuenta.Focus() : Exit Sub
            If (lblhelp_2.Text = "???" Or lblhelp_2.Text = "") Then Beep() : MessageBox.Show(gbc_MensajeValidar & "Cta Cte no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCtaCte.Focus() : Exit Sub
            If (lblhelp_3.Text = "???" Or lblhelp_3.Text = "") Then Beep() : MessageBox.Show(gbc_MensajeValidar & "Tip Doc no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtTipDoc.Focus() : Exit Sub
            '
            If txtNoDoc.Text = "" Then Beep() : MessageBox.Show(gbc_MensajeValidar & "Nro Doc no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNoDoc.Focus() : Exit Sub
            If txtNoVoucher.Text = "" Then Beep() : MessageBox.Show(gbc_MensajeValidar & "Nro Voucher no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNoVoucher.Focus() : Exit Sub

            cFecDoc = If(IsDate(mskFecDoc.Text) = True, mskFecDoc.Text, "")
            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then MessageBox.Show("VALIDAR :: Tipo de Cambio No Válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtTipCambio.Focus() : Exit Sub

          
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor

            '
            Dim base_imponible As Double
            Dim base_inafecta As Double
            Dim Igv As Double
            Dim Total As Double
            Dim base_imponibleDolares As Double
            Dim base_inafectaDol As Double
            Dim IgvDolares As Double
            Dim TotalDolares As Double
            Dim identificador As String
            Dim moneda As String

            identificador = txtlibro.Text.Trim + txtCtaCte.Text.Trim + txtTipDoc.Text.Trim + txtNoDoc.Text.Trim

            moneda = cbomoneda.Text
            If moneda = "S" Then 'es soles
                base_imponible = CDbl(txtDebe_0.Text)
                base_inafecta = CDbl(txtInafecto_0.Text)
                Igv = CDbl(txtHaber_0.Text)
                Total = CDbl(txttotal_0.Text)

                base_imponibleDolares = CDbl(txtDebe_1.Text)
                base_inafectaDol = CDbl(txtInafecto_1.Text)
                IgvDolares = CDbl(txtHaber_1.Text)
                TotalDolares = CDbl(txttotal_1.Text)

            Else
                base_imponible = CDbl(txtDebe_1.Text)
                base_inafecta = CDbl(txtInafecto_1.Text)
                Igv = CDbl(txtHaber_1.Text)
                Total = CDbl(txttotal_1.Text)

                base_imponibleDolares = CDbl(txtDebe_0.Text)
                base_inafectaDol = CDbl(txtDebe_0.Text)
                IgvDolares = CDbl(txtHaber_0.Text)
                TotalDolares = CDbl(txttotal_0.Text)
            End If


            If accionMante = "N" Then
                a = objSql.Ejecutar2("Sp_Con_Ins_ccFacturasParaDonacion", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text, txtCuenta.Text, tipoctacte, txtCtaCte.Text, txtTipDoc.Text, txtNoDoc.Text, cFecDoc, base_imponible, Igv, Total, base_imponibleDolares, IgvDolares, TotalDolares, txtTipCambio.Text, moneda, base_inafecta, base_inafectaDol, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("Sp_Con_Upd_ccFacturasParaDonacion", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text, txtCuenta.Text, tipoctacte, txtCtaCte.Text, txtTipDoc.Text, txtNoDoc.Text, cFecDoc, base_imponible, Igv, Total, base_imponibleDolares, IgvDolares, TotalDolares, txtTipCambio.Text, moneda, base_inafecta, base_inafectaDol, "")
                ' Asigno los Valores a los Parametros del Query
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("identificador", identificador, tblconsulta, Vista)
                Me.HabilitarMantenimiento(False)
            Else
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub mskFecDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFecDoc.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskFecDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFecDoc.LostFocus
        txtTipCambio.Text = Mod_BaseDatos.DameTCCuenta(mskFecDoc.Text, txtCuenta.Text)
    End Sub

    Private Sub mskFecDoc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskFecDoc.MaskInputRejected

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub
    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Me.TraerAyuda(1, btnhelp_1)
    End Sub
    Private Sub btnhelp_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_2.Click
        Me.TraerAyuda(2, btnhelp_2)
    End Sub
    Private Sub btnhelp_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_3.Click
        Me.TraerAyuda(3, btnhelp_3)
    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuenta.LostFocus
        'Trae tipo de centa corrinte
        tipoctacte = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text.Trim, "UT")

        Me.TraeDameDescripcion(1)
    End Sub
    Private Sub txtlibro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlibro.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtlibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibro.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub
    Private Sub txtCtaCte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCtaCte.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCtaCte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtaCte.LostFocus
        Me.TraeDameDescripcion(2)
    End Sub
    Private Sub txtTipDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipDoc.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtTipDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipDoc.LostFocus
        Me.TraeDameDescripcion(3)
    End Sub

    Private Sub cbomoneda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbomoneda.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub txtDebe_0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDebe_0.LostFocus
        Me.CalculaEquivalentes("D")
    End Sub
    Private Sub cbomoneda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbomoneda.LostFocus
        Me.CalculaEquivalentes("D")
    End Sub
    Private Sub txtHaber_0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHaber_0.LostFocus
        Me.CalculaEquivalentes("D")
    End Sub
    Private Sub txttotal_0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal_0.LostFocus
        Me.CalculaEquivalentes("D")
    End Sub
    Private Sub txtInafecto_0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInafecto_0.LostFocus
        Me.CalculaEquivalentes("D")
    End Sub

    Private Sub txtDebe_0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebe_0.TextChanged

    End Sub
End Class