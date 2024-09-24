Option Strict On
Option Explicit On
Public Class Frm_Previsualizar_SireCompras

#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim VistaHelp As DataView
    Dim Vista As DataView
    Dim frmOrigen As Frm_RegistrarCompras
    Dim nombredeobjeto As String = "Detalle de Sire"
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
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
    Private Sub inicioControlesDiseno()
        'Formulario
        Me.Text = ""
        'Grilla princiapal
        Mod_Mantenimiento.Formatodegrilla(tblconsulta)
        tblconsulta.ColumnFooters = False


        'Grilla de la ayuda
        'tblhelp.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
        ''Me.tblhelp.FilterBar = True
        ''Me.tblhelp.AllowFilter = True
        ' ''
        Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
        Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
        Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
        Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
        Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
        Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
        Mod_Mantenimiento.tooltiptext(btnDetraccion, "Registrar Detraccion")
        Mod_Mantenimiento.tooltiptext(btnreferencias, "Registrar Referencias")
        Mod_Mantenimiento.tooltiptext(btnpagoplanillas, "Registrar Pago Planillas")

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
    Public Property P_FilaDeTabla() As DataRowView
        Get
            Return FilaDeTabla
        End Get
        Set(ByVal value As DataRowView)
            FilaDeTabla = value
        End Set
    End Property
#End Region
#Region "Traer Informacion de Base de Datos"
    Sub TraeLibros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            'tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function DameDescripcion(ByVal cCodigoBus As String, ByVal cFlag As String) As String
        ' Obtengo la Descripcion
        Try
            DameDescripcion = CType(objSql.TraerValor("sp_Con_Dame_Descripcion", gbcodempresa, cCodigoBus, cFlag, ""), String)
        Catch ex As Exception
            DameDescripcion = ""
        End Try
    End Function
    Sub CargaDetalleVoucher()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Detalle_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.capturarfilaactual()
            '
            lbltotalregistros.Text = tblconsulta.RowCount.ToString
            Me.Traetotaldevoucher()
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SeteaVoucher()
        Try
            txtNoVoucher.Enabled = (DameDescripcion(gbano + txtlibro.Text, "LN") = "S")
            If txtNoVoucher.Enabled = True Then txtNoVoucher.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub Traetotaldevoucher()
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Con_Dame_Total_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text, 0, 0, 0, 0)
            'Asigno los valores de la vista
            txtTotalDebeSoles.Text = a.GetValue(1, 1).ToString
            txtTotalHaberSoles.Text = a.GetValue(1, 2).ToString
            txtTotalDebeDolares.Text = a.GetValue(1, 3).ToString
            txtTotalHaberDolares.Text = a.GetValue(1, 4).ToString

            txtSaldoSoles.Text = CType(CType(txtTotalDebeSoles.Text, Double) - CType(txtTotalHaberSoles.Text, Double), String)
            txtSaldoDolares.Text = CType(CType(txtTotalDebeDolares.Text, Double) - CType(txtTotalHaberDolares.Text, Double), String)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Metodos de Mantenimiento"

    Sub Nuevo()
        Try
            Me.accionMante = "N"
            Me.HabilitarMantenimiento(True)
            LimpiarControles(Me)
            'Limpiar grilla de detalles del voucher
            tblconsulta.SetDataBinding(Nothing, "", True)
            'fOCO
            txtlibro.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
        Catch ex As Exception

        End Try
    End Sub
    Sub eliminar()
        Try
            Beep()
            If MessageBox.Show("¿ Va a Eliminar El VOUCHER Esta Seguro : " & txtlibro.Text & "/" & txtNoVoucher.Text & "?", "ELIMINA VOCUHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            If MessageBox.Show("¿ Confirme la Eliminacion Del Voucher : " & txtlibro.Text & "/" & txtNoVoucher.Text & "?", "ELIMNA VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Con_Del_Voucher", gbcodempresa$, gbano$, gbmes$, txtlibro.Text.Trim, txtNoVoucher.Text.Trim, "")
            'Armar Identificador de Fila
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                'frmOrigen.refrescarGrillaConFiltro()
                Me.Close()
            Else
                'No hago nada
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
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

            If Periodocerrado() = True Then
                btnnuevo.Visible = False
                btnmodificar.Visible = False
                btneliminar.Visible = False
            End If

            btnsalir.Visible = Not valor
            'Bloque controles de segumiento
            btnanterior.Visible = Not valor
            btnsiguiente.Visible = Not valor
            btnprimero.Visible = Not valor
            btnultimo.Visible = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor
            '
            btnDetraccion.Visible = Not valor
            btnreferencias.Visible = Not valor
            btnpagoplanillas.Visible = Not valor
            '
            'lnkNuevo.Visible = Not valor
            'lnkeliminar.Visible = Not valor
            'lnkmodificar.Visible = Not valor
            'lnkInsertar.Visible = Not valor
            'lnkver.Visible = Not valor

            'los campos que no deben modificar, 
            txtlibro.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
            btnhelp_0.Enabled = If((Me.accionMante Is "M"), False, valor)
            txtNoVoucher.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
            tblconsulta.Enabled = Not valor
        Catch ex As Exception
        End Try
    End Sub
    Public Sub CrearColumnas()
        Dim dt As DataTable = New DataTable
        Try

            dt.Columns.Add("SireCAR_SUNAT", GetType(String))
            dt.Columns.Add("Fecha_emision", GetType(String))
            dt.Columns.Add("Fecha_VctoPago", GetType(String))
            dt.Columns.Add("Tipo_CPDoc", GetType(String))
            dt.Columns.Add("Serie_CDP", GetType(String))
            dt.Columns.Add("Nro_CP", GetType(String))
            dt.Columns.Add("Tipo_Doc_Identidad", GetType(String))
            dt.Columns.Add("Nro_Doc_Identidad", GetType(String))
            dt.Columns.Add("Razon_Social_2", GetType(String))
            dt.Columns.Add("BI_Gravado_DG", GetType(Decimal))
            dt.Columns.Add("IGV_IPM_DG", GetType(Decimal))
            dt.Columns.Add("BI_Gravado_DGNG", GetType(Decimal))
            dt.Columns.Add("IGV_IPM_DGNG", GetType(Decimal))
            dt.Columns.Add("BI_Gravado_DNG", GetType(Decimal))
            dt.Columns.Add("IGV_IPM_DNG", GetType(Decimal))
            dt.Columns.Add("Valor_Adq_NG", GetType(Decimal))
            dt.Columns.Add("ISC", GetType(Decimal))
            dt.Columns.Add("ICBPER", GetType(Decimal))
            dt.Columns.Add("Otros_Trib_Cargos", GetType(Decimal))
            dt.Columns.Add("Total_CP", GetType(Decimal))
            dt.Columns.Add("Moneda", GetType(String))
            dt.Columns.Add("Tipo_Cambio", GetType(Decimal))
            dt.Columns.Add("Fecha_Emision_Doc_Modificado", GetType(String))
            dt.Columns.Add("Tipo_CP_Modificado", GetType(String))
            dt.Columns.Add("Serie_CP_Modificado", GetType(String))
            dt.Columns.Add("Nro_CP_Modificado", GetType(String))
            dt.Columns.Add("Concepto", GetType(String))
            dt.Columns.Add("Centro_Costo", GetType(String))
            dt.Columns.Add("Asiento_Tipo", GetType(String))
            dt.Columns.Add("Desc_asiento_tip", GetType(String))
            dt.Columns.Add("Libro", GetType(String))
            dt.Columns.Add("Nro_voucher", GetType(String))
            dt.Columns.Add("Refrescar_Nro_Voucher", GetType(String))
            dt.Columns.Add("Previsualizar", GetType(String))
            dt.Columns.Add("Contabilizar", GetType(String))

            tblconsulta.DataSource = dt

            Me.tblconsulta.InsertHorizontalSplit(1)
            ' Ocultar columnas en el C1TrueDBGrid
            Me.tblconsulta.Splits(0).SplitSize = 3
            Me.tblconsulta.Splits(0).DisplayColumns("SireCAR_SUNAT").Visible = False
            Me.tblconsulta.Splits(1).SplitSize = 1
            Me.tblconsulta.Splits(1).DisplayColumns("SireCAR_SUNAT").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Fecha_emision").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Fecha_VctoPago").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_CPDoc").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Serie_CDP").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Nro_CP").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_Doc_Identidad").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Nro_Doc_Identidad").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Razon_Social_2").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("BI_Gravado_DG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("IGV_IPM_DG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("BI_Gravado_DGNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("IGV_IPM_DGNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("BI_Gravado_DNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("IGV_IPM_DNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Valor_Adq_NG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ISC").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ICBPER").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Otros_Trib_Cargos").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Total_CP").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Moneda").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_Cambio").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Fecha_Emision_Doc_Modificado").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_CP_Modificado").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Serie_CP_Modificado").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Nro_CP_Modificado").Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Private Function VoucherCuadrado() As Boolean
        VoucherCuadrado = True
        Try
            If Me.accionMante = "E" Then VoucherCuadrado = True : Exit Function
            ' Verifico que el Voucher este cuadrado o que tenga Detalle
            If tblconsulta.RowCount > 0 Then
                If CDbl(txtSaldoSoles.Text) <> 0 Or CDbl(txtSaldoDolares.Text) <> 0 Then
                    MessageBox.Show("El Voucher no se Encuentra Cuadrado, por favor verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    VoucherCuadrado = False
                End If
            Else
                If Me.accionMante <> "E" Then
                    MsgBox("El Voucher no tiene Ingresado Cuentas, por favor Ingrese Alguna Cuenta", vbCritical)
                    VoucherCuadrado = False
                End If
            End If
        Catch ex As Exception
            VoucherCuadrado = False
        End Try
    End Function
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtlibro.Text = filaactiva("ccc01subd").ToString ' 
                TraeDameDescripcion(0)
                txtNoVoucher.Text = filaactiva("ccc01numer").ToString ' Voucher
                mskfecha.Text = filaactiva("ccc01fecha").ToString ' Fecha
                txtDescri.Text = filaactiva("ccc01deta").ToString ' Concepto
                Me.CargaDetalleVoucher()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            'tblhelp.Location = New Point(x, y)

            'Mod_Mantenimiento.LimpiarFiltro(tblhelp)
            'tblhelp.Columns(0).Caption = "Código"
            'tblhelp.Columns(1).Caption = "Descripción"

            'Select Case index
            '    Case 0
            '        tblhelp.Columns(0).DataField = "ccb02cod"
            '        tblhelp.Columns(1).DataField = "ccb02des"
            '        Me.TraeLibros()
            'End Select

            'tblhelp.Tag = index.ToString
            'tblhelp.Refresh()
            'tblhelp.Visible = True
            'tblhelp.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub refrescarGrilla()
        CargaDetalleVoucher()
    End Sub
#End Region

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        'Cargar la fila actual
        If frmOrigen.tblconsulta.RowCount > 0 Then
            'cargarDatos(frmOrigen.P_FilaDeTabla)
            Me.HabilitarMantenimiento(False)
        Else
            Me.Dispose()
            Me.Close()
        End If
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        If Not VoucherCuadrado() Then Exit Sub
        Me.modificar()
    End Sub
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'Valido libro
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Libro no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtlibro.Focus() : Exit Sub
            If txtNoVoucher.Text.Trim = "" Then Beep() : MessageBox.Show("VALIDACION :: Numero de voucher no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNoVoucher.Focus() : Exit Sub
            If txtDescri.Text.Trim = "" Then Beep() : MessageBox.Show("VALIDACION :: Ingrese una descripcion", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtDescri.Focus() : Exit Sub
            'Validar que la fecha del voucher pertenesca al periodo
            Dim periodo As String
            periodo = gbano + gbmes
            If Funciones.Funciones.EsValidaFechaPorPer(mskfecha.Text, periodo) = False Then mskfecha.Focus() : Exit Sub
            '
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Cabecera_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, mskfecha.Text, txtDescri.Text, "", "N", txtNoVoucher.Text, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Cabecera_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text, mskfecha.Text, txtDescri.Text, "")
            Else
                MessageBox.Show("VALIDA :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            ' Se hizo todo el codig por que se nesecitava personalizar
            Dim i As Integer
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                'Otros Mnsajes
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        If CType(a.GetValue(0, i), String) = "@cMsgRetorno" Then
                            MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Next
                'Si todo esta bien
                'Buscar y posicionar, despues de la accion
                'frmOrigen.refrescarGrilla()
                'frmOrigen.Posicionar("codigo", txtlibro.Text.Trim + txtNoVoucher.Text.Trim)
                Me.HabilitarMantenimiento(False)
                'Cargar el nuevo detalle
                If accionMante = "N" Then
                    Me.lnkNuevo_LinkClicked(Nothing, Nothing)
                End If
            Else 'Fallo la ejecucion Sql 
                'Mensajes de Fallo
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next
                '
            End If

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Sub Posicionar(ByVal campo As String, ByVal ValorCampo As String, ByVal Grilla As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            campo = Trim(campo)
            ValorCampo = Trim(ValorCampo)
            '
            Vista.Sort = campo
            Dim fila As Integer = Vista.Find(ValorCampo)
            If fila <> -1 Then
                With Grilla
                    .Bookmark = fila
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtlibro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlibro.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub btnsiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsiguiente.Click
        'frmOrigen.grilla_registro_siguiente()
        'Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub btnanterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnanterior.Click
        'frmOrigen.grilla_registro_Anterior()
        'Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub btnultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnultimo.Click
        'frmOrigen.grilla_registro_Ultimo()
        'Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub btnprimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprimero.Click
        'frmOrigen.grilla_registro_Primero()
        'Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub Frm_Voucher_Abc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If VoucherCuadrado() = False Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub Frm_Voucher_Abc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializo mi formulario desde donde se cargo 
        Try
            inicioControlesDiseno()
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)

            Me.Text = "Cabecera de voucher"

            frmOrigen = CType(Me.Owner, Frm_RegistrarCompras)
            '
            If Me.accionMante = "N" Then
                Me.Nuevo()
            ElseIf Me.accionMante = "M" Then
                Me.cargarDatos(RegistroActivo)
                Me.modificar()
            ElseIf Me.accionMante = "V" Then
                Me.cargarDatos(RegistroActivo)
                Me.HabilitarMantenimiento(False)
            End If
            '
            Mod_Mantenimiento.ocultarbotonespercerrado(Me)

            'If Periodocerrado() = True Then
            '    lnkNuevo.Visible = False
            '    lnkmodificar.Visible = False
            '    lnkeliminar.Visible = False
            '    lnkInsertar.Visible = False

            '    btnDetraccion.Visible = False
            '    btnpagoplanillas.Visible = False
            '    btnreferencias.Visible = False
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblhelp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
     
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'tblhelp.Visible = False
            VistaHelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtlibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibro.LostFocus
        TraeDameDescripcion(0)
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        eliminar()
    End Sub
    Public Sub grilla_registro_siguiente()
        Try
            tblconsulta.MoveNext()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub grilla_registro_Anterior()
        Try
            tblconsulta.MovePrevious()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub grilla_registro_Primero()
        'Mover a la siguiente fila de la grilla
        Try
            tblconsulta.MoveFirst()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub grilla_registro_Ultimo()
        'Mover a la siguiente fila de la grilla
        Try
            tblconsulta.MoveLast()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lnkNuevo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            Dim _Frm_Voucher_Abc_Det As New Frm_Voucher_Abc_Det
            _Frm_Voucher_Abc_Det.p_accionMante = "N"
            _Frm_Voucher_Abc_Det.Owner = Me
            _Frm_Voucher_Abc_Det.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lnkmodificar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim _Frm_Voucher_Abc_Det As New Frm_Voucher_Abc_Det
        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            If FilaDeTabla Is Nothing Then Exit Sub

            '
            _Frm_Voucher_Abc_Det.p_accionMante = "M"
            _Frm_Voucher_Abc_Det.p_RegistroActivo = FilaDeTabla
            _Frm_Voucher_Abc_Det.Owner = Me
            _Frm_Voucher_Abc_Det.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lnkeliminar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.eliminarDetalle()
    End Sub
    Sub eliminarDetalle()
        Dim correlativoDet As Integer
        Dim correlativoDetAnt As Integer
        Dim cuenta As String
        Dim descripcion As String
        Dim filaAnterior As Integer
        Dim FilaDeTablaAnterior As DataRowView

        Try
            '=============Validaciones ============
            'Validar que no se elimine una cuenta de destino
            If (FilaDeTabla("ccd01ama").ToString) = "D" Then
                MessageBox.Show("VALIDACION :: No se puede Eliminar;Elimine el origen de la cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            'Capturo la fila anterior para posicionarme despues de la eliminacion
            If filaactual > 0 Then
                filaAnterior = filaactual - 1
            Else
                filaAnterior = filaactual
            End If
            FilaDeTablaAnterior = Vista.Table.DefaultView.Item(filaAnterior)
            'Capturo el correlativo a eliminar
            correlativoDetAnt = CType(FilaDeTablaAnterior("ccd01ord").ToString, Integer)
            correlativoDet = CType(FilaDeTabla("ccd01ord").ToString, Integer)
            cuenta = FilaDeTabla("ccd01cta").ToString
            descripcion = FilaDeTabla("ccm01des").ToString
            '
            Beep()
            If MessageBox.Show("AVISO :: Esta seguro de Eliminar el REGISTRO " & cuenta & "-" & descripcion & " ?", "ELIMINAR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Con_Del_Detalle_Voucher", gbcodempresa$, gbano$, gbmes$, txtlibro.Text.Trim, txtNoVoucher.Text.Trim, correlativoDet, "")
            If MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("ccd01ord", CStr(correlativoDetAnt), tblconsulta)
            Else
                'No hago nada
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function MensajesdelSQl(ByVal a As Array) As Boolean
        Dim i As Integer
        Try
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                'Otros Mnsajes
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
                'Si todo esta bien
                MensajesdelSQl = True
            Else 'Fallo la ejecucion Sql 
                'Mensajes de Fallo
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next
                MensajesdelSQl = False
            End If
        Catch ex As Exception
            MensajesdelSQl = False
        End Try
    End Function

    Private Sub lnkver_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If Funciones.Funciones.FormIsOpen("Frm_Voucher_Abc_Det") Then Exit Sub
        Dim _Frm_Voucher_Abc_Det As New Frm_Voucher_Abc_Det
        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            If FilaDeTabla Is Nothing Then Exit Sub
            '
            _Frm_Voucher_Abc_Det.p_accionMante = "V"
            _Frm_Voucher_Abc_Det.p_RegistroActivo = FilaDeTabla
            _Frm_Voucher_Abc_Det.Owner = Me
            _Frm_Voucher_Abc_Det.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblconsulta.DoubleClick
        Me.lnkver_LinkClicked(Nothing, Nothing)
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Me.capturarfilaactual()
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        lbltotalregistros.Text = tblconsulta.RowCount.ToString
    End Sub
    Private Sub mskfecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskfecha.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub
    Private Sub tblconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            lnkver_LinkClicked(Nothing, Nothing)
        End If
    End Sub



    Private Sub txtDescri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescri.TextChanged

    End Sub

    Private Sub btnDetraccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetraccion.Click
        'Validar si esta abierto

        If Funciones.Funciones.FormIsOpen("Frm_Voucher_Detraccion") Then Exit Sub
        '
        Dim _Frm_Voucher_Detraccion As New Frm_Voucher_Detraccion

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_Voucher_Detraccion.p_FormularioPadre = Me.Name
            _Frm_Voucher_Detraccion.p_accionMante = "V"
            _Frm_Voucher_Detraccion.p_RegistroActivo = FilaDeTabla
            _Frm_Voucher_Detraccion.Owner = Me
            _Frm_Voucher_Detraccion.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnpagoplanillas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpagoplanillas.Click
        'Validar si esta abierto
        If Funciones.Funciones.FormIsOpen("Frm_Voucher_PagoPlanillas") Then Exit Sub
        '
        Dim _Frm_Voucher_PagoPlanillas As New Frm_Voucher_PagoPlanillas
        Try
            '_Frm_Voucher_PagoPlanillas.p_FormularioPadre = Me.Name
            '_Frm_Voucher_PagoPlanillas.p_accionMante = "V"
            '_Frm_Voucher_PagoPlanillas.p_RegistroActivo = FilaDeTabla
            _Frm_Voucher_PagoPlanillas.Owner = Me
            _Frm_Voucher_PagoPlanillas.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub lnkInsertar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim _Frm_Voucher_Abc_Det As New Frm_Voucher_Abc_Det
        Try
            If tblconsulta.RowCount < 1 Then Exit Sub
            If FilaDeTabla Is Nothing Then Exit Sub

            _Frm_Voucher_Abc_Det.p_accionMante = "I"
            _Frm_Voucher_Abc_Det.p_RegistroActivo = FilaDeTabla
            _Frm_Voucher_Abc_Det.Owner = Me
            _Frm_Voucher_Abc_Det.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnreferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreferencias.Click
        'Validar si esta abierto
        If Funciones.Funciones.FormIsOpen("Frm_ComprobantequeModifica") Then Exit Sub
        '

        Dim _Frm_ComprobantequeModifica As New Frm_ComprobantequeModifica

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_ComprobantequeModifica.p_FormularioPadre = Me.Name
            _Frm_ComprobantequeModifica.p_accionMante = "V"
            _Frm_ComprobantequeModifica.p_RegistroActivo = FilaDeTabla
            _Frm_ComprobantequeModifica.Owner = Me
            _Frm_ComprobantequeModifica.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtlibro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlibro.TextChanged

    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class