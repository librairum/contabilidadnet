Option Strict On
Option Explicit On
Public Class Frm_VoucherAT_abc

#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim VistaHelp As DataView
    Dim VistaATdet As DataView
    Dim Vista As DataView
    Dim frmOrigen As Frm_VoucherAT
    Dim nombredeobjeto As String = "Detalle de Voucher"
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim tablaDet As DataTable
    Dim tipoanalis As String
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
        tblhelp.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
        Me.tblhelp.FilterBar = True
        Me.tblhelp.AllowFilter = True
        '
        Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
        Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
        Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
        Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
        Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
        Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
        Mod_Mantenimiento.tooltiptext(btnDetraccion, "Registrar Detraccion")
        '
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
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traetipodoc()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Tipos_Documentos", gbcodempresa, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub trae_ctacte()
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_help_ccm02cta", gbcodempresa).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeAsientoTipo()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Asientos_Tipo", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeDetAsientoTipo()
        Try
            VistaATdet = objSql.TraerDataTable("sp_Con_Trae_Detalle_Asi_Tipo", gbcodempresa, gbano, txtasientotipo.Text).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function traeNumeradorAutomatico(ByVal valorini As String) As String
        traeNumeradorAutomatico = ""
        Try
            traeNumeradorAutomatico = CType(objSql.TraerValor("Spu_Con_Trae_CorrelativoVoucher", gbcodempresa, gbano, gbmes, txtlibro.Text, valorini.Trim, ""), String)
        Catch ex As Exception
            traeNumeradorAutomatico = ""
        End Try

    End Function
    Sub CargaDetalleVoucher()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Detalle_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.capturarfilaactual()
            lbltotalregistros.Text = tblconsulta.RowCount.ToString
            Me.Traetotaldevoucher()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim tipoDoc As String = "", nroDoc As String = "", tipoMoneda As String = "", tipoAnalisis As String = "",
        codctaCte As String = "", numeroComprobante As String = "", fechaDocCadena As String = ""
    Dim tipoCambio As Double = 0, importeTotal As Double = 0
    Dim fechaDoc As DateTime
    Sub TraerDatoaGeneraVoucher()
        Try
            'Vista = objSql.TraerDataTable("Sp_Con_Trae_DatoGeneraVoucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text).DefaultView;
            tablaDet = objSql.TraerDataTable("Sp_Con_Trae_DatoGeneraVoucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text)
            Dim tablaDetTipDoc As New DataTable

            tipoDoc = ""
            nroDoc = ""
            tipoMoneda = ""
            tipoAnalisis = ""
            codctaCte = ""
            tipoCambio = 0
            importeTotal = 0
            numeroComprobante = ""
            'Dim tipoMoneda As String = tablaDet.Rows
            tipoDoc = tablaDet.Rows(0)(5).ToString
            nroDoc = tablaDet.Rows(0)(6).ToString
            tipoMoneda = tablaDet.Rows(0)(7).ToString
            tipoCambio = CDbl(tablaDet.Rows(0)(8))
            tipoAnalisis = tablaDet.Rows(0)(9).ToString
            codctaCte = tablaDet.Rows(0)(10).ToString
            importeTotal = CDbl(tablaDet.Rows(0)(11))
            numeroComprobante = tablaDet.Rows(0)(12).ToString
            fechaDoc = CDate(tablaDet.Rows(0)(13))

            Me.txtTipDoc.Text = tipoDoc
            Me.txtimporte.Text = importeTotal.ToString()
            'Me.cbomoneda.SelectedValue = tipoMoneda
            Me.cbomoneda.Text = tipoMoneda
            Me.txtNoDoc.Text = nroDoc
            Me.txtTipCambio.Text = tipoCambio.ToString
            Me.txtCtaCte.Text = codctaCte
            Me.txtcomprobante.Text = numeroComprobante
            Me.fechaDocCadena = fechaDoc.ToString("dd/MM/yyyy")
            Dim datosCuenta As New DataView
            datosCuenta = objSql.TraerDataTable("Spu_Con_help_ccm02cta", gbcodempresa).DefaultView
            datosCuenta.RowFilter = "ccm02cod = '" & codctaCte & "'"
            For Each rowView As DataRowView In datosCuenta
                Dim nombreCuenta As String = rowView("ccm02nom").ToString
                lblhelp_3.Text = nombreCuenta
                'Console.WriteLine(nombreCuenta)
            Next
            'dataview
            Dim dvTipoDocumento As New DataView
            dvTipoDocumento = objSql.TraerDataTable("sp_Con_Help_Tipos_Documentos", gbcodempresa, "*", "*").DefaultView
            dvTipoDocumento.RowFilter = "ccb02cod='" & txtTipDoc.Text & "'"
            For Each rw As DataRowView In dvTipoDocumento
                Dim nombreTipDoc As String = rw("ccb02des").ToString
                lblhelp_2.Text = nombreTipDoc
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SeteaVoucher()
        Try
            txtNoVoucher.Enabled = (Mod_BaseDatos.DameDescripcion(gbano + txtlibro.Text, "LN") = "S")
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
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub
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
    Sub NuevoAT()
        Try
            Me.accionMante = "N"
            'Muestro campos pra generar asiento tipo
            Me.HabilitarMantenimiento(True)
            LimpiarControles(Me)
            'Limpiar grilla de detalles del voucher
            tblconsulta.SetDataBinding(Nothing, "", True)
            'Deshabilitar, por que se genera con el boton GEnerar
            btngrabar.Visible = False
            btncancelar.Visible = False

            'Habilita
            grbdatosdet.Enabled = True
            btngenerarat.Enabled = True
            btncancelaat.Enabled = True
            'Deshabilto mantenimiento
            grbmantodet.Enabled = False
            tipoanalis = ""

            'fOCO
            txtasientotipo.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)

            'Habilita
            If Me.accionMante = "M" Then
                grbdatosdet.Enabled = True
            Else
                grbdatosdet.Enabled = False
            End If

            btngenerarat.Enabled = False
            btncancelaat.Enabled = False
            'Deshabilto mantenimiento
            grbmantodet.Enabled = False
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
            Dim i As Integer
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                'Otros Mnsajes
                For i = 1 To a.GetUpperBound(0)
                    MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Next
                Me.frmOrigen.refrescarGrilla()
                Me.Close()
            Else
                For i = 1 To a.GetUpperBound(0)
                    MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Next
            End If

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
            btnsalir.Visible = Not valor
            '
            'Bloque controles de segumiento
            btnanterior.Visible = Not valor
            btnsiguiente.Visible = Not valor
            btnprimero.Visible = Not valor
            btnultimo.Visible = Not valor

            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
            txtlibro.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
            txtNoVoucher.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
            mskfecha.Enabled = If((Me.accionMante Is "M"), False, valor)
            '
            tblconsulta.Enabled = Not valor
            'campos a generar voucher
            Me.txtNoDoc.Enabled = If((Me.accionMante Is "M"), True, Not valor)
            Me.txtTipDoc.Enabled = If((Me.accionMante Is "M"), True, Not valor)
            Me.txtTipCambio.Enabled = If((Me.accionMante Is "M"), True, Not valor)
            Me.cbomoneda.Enabled = If((Me.accionMante Is "M"), True, Not valor)
            Me.txtcomprobante.Enabled = If((Me.accionMante Is "M"), True, Not valor)
            Me.mskfecha.Enabled = If((Me.accionMante Is "M"), True, Not valor)
            txtimporte.Enabled = False
            '
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Private Function VoucherCuadrado() As Boolean
        VoucherCuadrado = True
        'Si se esta eliminando

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
                txtasientotipo.Text = filaactiva("ccc01astip").ToString
                TraeDameDescripcion(1)
                txtlibro.Text = filaactiva("ccc01subd").ToString
                TraeDameDescripcion(0)
                txtNoVoucher.Text = filaactiva("ccc01numer").ToString
                mskfecha.Text = filaactiva("ccc01fecha").ToString
                txtDescri.Text = filaactiva("ccc01deta").ToString
                'obtener nombre de la cta cte
                
                'cargar datos de la cuenta contable 42 y mostrar informacion de numero documento, tipo documento, tipo de cambio, 
                Me.CargaDetalleVoucher()
                Me.TraerDatoaGeneraVoucher()
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
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtlibro.Text.Trim, "LI")
                    End If
                Case 1
                    If txtasientotipo.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(txtasientotipo.Text.Trim, "AT")
                    End If
                Case 1
                    If txtTipDoc.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = Mod_BaseDatos.DameDescripcion(txtTipDoc.Text, "TD")
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

            Mod_Mantenimiento.LimpiarFiltro(tblhelp)
            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"
            '
            Dim columna2 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna2 = tblhelp.Columns(2)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            Dim columna3 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna3 = tblhelp.Columns(3)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"


            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()
                Case 1 'Asientos Tipo
                    tblhelp.Columns(0).DataField = "ccc03cod"
                    tblhelp.Columns(1).DataField = "ccc03des"
                    Me.TraeAsientoTipo()
                Case 2 'Tipo de documento
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.traetipodoc()
                Case 3 'Trae Cta Cte
                    tblhelp.Splits(0).DisplayColumns(2).Width = 1000

                    tblhelp.Columns(0).Caption = ""

                    tblhelp.Columns(0).Caption = "Codigo"
                    tblhelp.Columns(1).Caption = "Descripcion"
                    tblhelp.Columns(2).Caption = "Tipo"
                    tblhelp.Columns(3).Caption = ""

                    tblhelp.Columns(0).DataField = "ccm02cod"
                    tblhelp.Columns(1).DataField = "ccm02nom"
                    tblhelp.Columns(2).DataField = "ccb17desc"
                    tblhelp.Columns(3).DataField = "ccm02tipana"

                    Me.trae_ctacte()
            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub traeconfigAT(ByVal numasitip As String)
        Try
            'Libro por defecto
            txtlibro.Text = Mod_BaseDatos.DameDescripcion(txtasientotipo.Text, "LA")
            Me.TraeDameDescripcion(0)
            'Descripcion de la glosa
            txtDescri.Text = lblhelp_1.Text
            '
            txtNoVoucher.Text = Me.traeNumeradorAutomatico(txtNoVoucher.Text.Trim)
            '

        Catch ex As Exception

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
                    txtasientotipo.Text = tblhelp.Columns("ccc03cod").Value.ToString
                    lblhelp_1.Text = tblhelp.Columns("ccc03des").Value.ToString
                    'Trae valores de configuracion del asiento tipo
                    Me.traeconfigAT(txtasientotipo.Text)
                Case 2
                    txtTipDoc.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_2.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtNoDoc.Focus()
                Case 3

                    txtCtaCte.Text = tblhelp_p.Columns("ccm02cod").Value.ToString
                    lblhelp_3.Text = tblhelp_p.Columns("ccm02nom").Value.ToString
                    tipoanalis = tblhelp_p.Columns("ccm02tipana").Value.ToString
                    txtCtaCte.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub refrescarGrilla()
        CargaDetalleVoucher()
    End Sub

#End Region

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.NuevoAT()

    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        If frmOrigen.tblconsulta.RowCount > 0 Then
            cargarDatos(frmOrigen.P_FilaDeTabla)
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
        Me.modificar()
    End Sub
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Function GrabarCabVoucher() As Boolean
        GrabarCabVoucher = False
        Try
            'Valido libro
            If (lblhelp_1.Text = "" Or lblhelp_1.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Libro no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtlibro.Focus() : GrabarCabVoucher = False : Exit Function
            If txtNoVoucher.Text.Trim = "" Then Beep() : MessageBox.Show("VALIDACION :: Numero de voucher no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNoVoucher.Focus() : GrabarCabVoucher = False : Exit Function
            If txtDescri.Text.Trim = "" Then Beep() : MessageBox.Show("VALIDACION :: Ingrese una descripcion", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtDescri.Focus() : GrabarCabVoucher = False : Exit Function
            'Validar que la fecha del voucher pertenesca al periodo
            Dim periodo As String
            periodo = gbano + gbmes
            If Funciones.Funciones.EsValidaFechaPorPer(mskfecha.Text, periodo) = False Then mskfecha.Focus() : GrabarCabVoucher = False : Exit Function
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Con_Ins_Cabecera_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, mskfecha.Text, txtDescri.Text, txtasientotipo.Text.Trim, "N", txtNoVoucher.Text, "")
            '
            ' Se hizo todo el codig por que se nesecitava personalizar
            Dim i As Integer
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                GrabarCabVoucher = True
                'Ubicar 
                frmOrigen.refrescarGrilla()
                frmOrigen.Posicionar("codigo", txtlibro.Text.Trim + txtNoVoucher.Text.Trim)
                Me.HabilitarMantenimiento(False)
            Else 'Fallo la ejecucion Sql 
                'Mensajes de Fallo
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) = "@cMsgRetorno" Then
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
                GrabarCabVoucher = False
            End If
        Catch ex As Exception
            GrabarCabVoucher = False
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Function ModificoCamposGenerarVoucher() As Boolean
        Dim flagExitosa As Boolean = False
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            If editoMoneda Or editoNroDocumento Or editoTipoCambio _
                Or editoTipoDocumento Or editoComprobante Or editoCtaCte Or editoFecha Then

                a = objSql.Ejecutar2("Sp_Con_Upd_DetalleVoucherMasivo", gbcodempresa, gbano, gbmes,
                                 txtlibro.Text, txtNoVoucher.Text,
                                    mskfecha.Text, txtDescri.Text, txtTipDoc.Text,
                                    txtNoDoc.Text, tipoAnalisis, txtCtaCte.Text, cbomoneda.Text,
                                    txtTipCambio.Text, txtcomprobante.Text, "")
                flagExitosa = True

            End If
            If flagExitosa = True Then
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
                    frmOrigen.refrescarGrilla()
                    'frmOrigen.Posicionar("codigo", txtlibro.Text.Trim + txtNoVoucher.Text.Trim)
                    Me.HabilitarMantenimiento(False)
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
            End If
            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        editoNroDocumento = False
        editoTipoCambio = False
        editoTipoCambio = False
        editoMoneda = False

    End Function
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
            Dim flagExitoso As Boolean = False

            If accionMante = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Cabecera_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, mskfecha.Text, txtDescri.Text, "", "N", txtNoVoucher.Text, "")
                flagExitoso = True
            ElseIf accionMante = "M" Then
                'codigo comentado por ivan 30/05
                'a = objSql.Ejecutar2("sp_Con_Upd_Cabecera_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text, mskfecha.Text, txtDescri.Text, "")
                'codigo comentado por ivna 30/05
                'ModificoCamposGenerarVoucher()

                If editoMoneda Or editoNroDocumento Or editoTipoCambio _
                Or editoTipoDocumento Or editoComprobante Or editoCtaCte Or editoFecha Then

                    a = objSql.Ejecutar2("Sp_Con_Upd_DetalleVoucherMasivo", gbcodempresa, gbano, gbmes,
                                     txtlibro.Text, txtNoVoucher.Text,
                                        mskfecha.Text, txtDescri.Text, txtTipDoc.Text,
                                        txtNoDoc.Text, tipoAnalisis, txtCtaCte.Text, cbomoneda.Text,
                                        txtTipCambio.Text, txtcomprobante.Text, "")
                    flagExitoso = True

                End If


            Else
                MessageBox.Show("VALIDA :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            ' Se hizo todo el codig por que se nesecitava personalizar
            If flagExitoso = True Then


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
                    frmOrigen.refrescarGrilla()
                    frmOrigen.Posicionar("codigo", txtlibro.Text.Trim + txtNoVoucher.Text.Trim)
                    Me.HabilitarMantenimiento(False)
                    'refrescar grilla detalle 
                    CargaDetalleVoucher()
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
        frmOrigen.grilla_registro_siguiente()
        Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub btnanterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnanterior.Click
        frmOrigen.grilla_registro_Anterior()
        Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub btnultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnultimo.Click
        frmOrigen.grilla_registro_Ultimo()
        Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub btnprimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprimero.Click
        frmOrigen.grilla_registro_Primero()
        Me.cargarDatos(frmOrigen.P_FilaDeTabla)
    End Sub

    Private Sub Frm_VoucherAT_abc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If VoucherCuadrado() = False Then
            e.Cancel = True
        End If
    End Sub
    Dim editoNroDocumento As Boolean = False, editoTipoDocumento As Boolean = False, editoTipoCambio As Boolean = False,
        editoMoneda As Boolean = False, editoComprobante As Boolean = False, editoCtaCte As Boolean = False, editoFecha As Boolean = False

    Private Sub Frm_VoucherAT_abc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializo mi formulario desde donde se cargo 
        Try
            inicioControlesDiseno()
            'inicio variables de edicion
            editoNroDocumento = False
            editoTipoCambio = False
            editoTipoCambio = False
            editoMoneda = False
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Cabecera de voucher tipo"
            '
            frmOrigen = CType(Me.Owner, Frm_VoucherAT)
            '
            If Me.accionMante = "N" Then
                Me.NuevoAT()
            ElseIf Me.accionMante = "M" Then
                Me.cargarDatos(RegistroActivo)
                Me.modificar()
            ElseIf Me.accionMante = "V" Then
                Me.cargarDatos(RegistroActivo)
                Me.HabilitarMantenimiento(False)
                'Habilita
                grbdatosdet.Enabled = False
                btngenerarat.Enabled = False
                btncancelaat.Enabled = False
                'Deshabilto mantenimiento
                grbmantodet.Enabled = True
            End If
            Mod_Mantenimiento.ocultarbotonespercerrado(Me)
            If Periodocerrado() = True Then
                lnkNuevo.Visible = False
                lnkmodificar.Visible = False
                lnkeliminar.Visible = False
                btngenerarat.Visible = False
                btncancelaat.Visible = False
                btnDetraccion.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtlibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibro.LostFocus
        TraeDameDescripcion(0)
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Me.eliminar()
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

    Private Sub lnkNuevo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNuevo.LinkClicked
        Try
            Dim _Frm_VoucherAT_abc_Det As New Frm_VoucherAT_abc_Det
            _Frm_VoucherAT_abc_Det.p_accionMante = "N"
            _Frm_VoucherAT_abc_Det.Owner = Me
            _Frm_VoucherAT_abc_Det.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lnkmodificar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkmodificar.LinkClicked
        Dim _Frm_VoucherAT_abc_Det As New Frm_VoucherAT_abc_Det
        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            If FilaDeTabla Is Nothing Then Exit Sub

            '
            _Frm_VoucherAT_abc_Det.p_accionMante = "M"
            _Frm_VoucherAT_abc_Det.p_RegistroActivo = FilaDeTabla
            _Frm_VoucherAT_abc_Det.Owner = Me
            _Frm_VoucherAT_abc_Det.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lnkeliminar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkeliminar.LinkClicked
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
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("sp_Con_Del_Detalle_Voucher", gbcodempresa$, gbano$, gbmes$, txtlibro.Text.Trim, txtNoVoucher.Text.Trim, correlativoDet, "")
            If MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("ccd01ord", CStr(correlativoDetAnt), tblconsulta)
            Else
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
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

    Private Sub lnkver_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkver.LinkClicked
        If Funciones.Funciones.FormIsOpen("Frm_VoucherAT_abc_Det") Then Exit Sub
        Dim _Frm_VoucherAT_abc_Det As New Frm_VoucherAT_abc_Det
        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            If FilaDeTabla Is Nothing Then Exit Sub
            '
            _Frm_VoucherAT_abc_Det.p_accionMante = "V"
            _Frm_VoucherAT_abc_Det.p_RegistroActivo = FilaDeTabla
            _Frm_VoucherAT_abc_Det.Owner = Me
            _Frm_VoucherAT_abc_Det.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblconsulta.DoubleClick
        Me.lnkver_LinkClicked(Nothing, Nothing)
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        lbltotalregistros.Text = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Me.capturarfilaactual()
    End Sub
    Private Sub mskfecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskfecha.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
            mskfecha_LostFocus(Nothing, Nothing)
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub
    Private Sub tblconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            lnkver_LinkClicked(Nothing, Nothing)
        End If
    End Sub
    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Me.TraerAyuda(1, btnhelp_1)
    End Sub

    Private Sub btnhelp_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_2.Click
        Me.TraerAyuda(2, btnhelp_2)
    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        Try
            tblhelp.Visible = False
            VistaHelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btngenerarat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngenerarat.Click
        Dim moneda As String
        Dim cuenta As String
        Dim cargoabono As String
        Dim columna As String
        Dim importe As Double
        Dim valor As String
        Dim valorDouble As Double
        Dim formula As String
        Dim nDebSol As Double = 0
        Dim nDebDol As Double = 0
        Dim nHabSol As Double = 0
        Dim nHabDol As Double = 0
        'Dll que resuelve formulas
        Dim mp As New MathFunctions.MathParser

        Try
            '===========Validar Datos de detalle
            If Funciones.Funciones.Esnumeromayoracero(txtimporte.Text) = False Then MessageBox.Show("VALIDAR :: Importe no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then MessageBox.Show("VALIDAR :: Importe no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If cbomoneda.Text = "" Then MessageBox.Show("VALIDAR :: Moneda no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            '
            moneda = cbomoneda.Text
            'Si tiene corriente debe exigir tupo y numero de docuemnto
            If (lblhelp_3.Text.Trim = "???" Or lblhelp_3.Text.Trim = "") = False Then
                If (lblhelp_2.Text = "" Or lblhelp_2.Text = "???") Then Beep() : MessageBox.Show("VALIDAR :: Tipo de Documento no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtTipDoc.Focus() : Exit Sub
                If txtNoDoc.Text = "" Then Beep() : MessageBox.Show("VALIDAR :: Debe Ingresar Número de Documento", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNoDoc.Focus() : Exit Sub
            End If

            'Trae detalle de asiento tipo
            tablaDet = objSql.TraerDataTable("Spu_Con_Trae_ccd03astipCal", gbcodempresa, gbano, txtasientotipo.Text.Trim)

            'Recorrro la tabla traido y le actualizo los valores calculados segun las formulas
            For Each fila As DataRow In tablaDet.Rows
                formula = fila("ccd03desformula").ToString.ToUpper
                valor = Me.descrifraformula2(formula)
                valorDouble = mp.Calculate(valor)
                fila("ccd03valor") = valorDouble
            Next

            'Grabar cabecera de voucher ' se hace a esta altuara para minimizar errores
            If Me.GrabarCabVoucher = False Then Exit Sub


            'Recorreo la tabla traida e inserto el detalle del voucher
            For Each fila As DataRow In tablaDet.Rows
                nDebSol = 0
                nDebDol = 0
                nHabSol = 0
                nHabDol = 0
                formula = ""
                cuenta = ""
                cargoabono = ""
                columna = ""
                '
                formula = fila("ccd03desformula").ToString
                cuenta = fila("ccd03cta").ToString
                cargoabono = fila("ccd03ca").ToString.ToUpper
                columna = fila("ccd03afin").ToString
                importe = CType(fila("ccd03valor").ToString, Double)

                If cargoabono = "C" Then
                    If moneda = "S" Then
                        nDebSol = importe
                        nDebDol = importe / CDbl(txtTipCambio.Text)
                    ElseIf moneda = "D" Then
                        nDebSol = importe * CDbl(txtTipCambio.Text)
                        nDebDol = importe
                    End If
                Else
                    If moneda = "S" Then
                        nHabSol = importe
                        nHabDol = importe / CDbl(txtTipCambio.Text)
                    ElseIf moneda = "D" Then
                        nHabSol = importe * CDbl(txtTipCambio.Text)
                        nHabDol = importe
                    End If
                End If
                'Inserto el detalle
                Me.InsertaDetalle(txtlibro.Text, txtNoVoucher.Text, cuenta, moneda, nDebSol, nHabSol, nDebDol, nHabDol, columna)
            Next

            'Carga los datos que se han genrado
            Me.cargarDatos(frmOrigen.P_FilaDeTabla)
            '
            grbdatosdet.Enabled = False
            btngenerarat.Enabled = False
            btncancelaat.Enabled = False
            'Deshabilto mantenimiento
            grbmantodet.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Sub InsertaDetalle(ByVal libro As String, ByVal nrovoucher As String, ByVal cuenta As String, ByVal moneda As String, ByVal nDebSol As Double, ByVal nHabSol As Double, ByVal nDebDol As Double, ByVal nHabDol As Double, ByVal columna As String)
        Try
            '
            Dim cAfecto As String = ""
            Dim cFecDoc As String = ""
            Dim cFecVen As String = ""
            Dim cFecPag As String = ""
            Dim cFecrete As String = ""
            Dim cFecretepago As String = ""


            cFecDoc = If(IsDate(mskfecha.Text) = True, mskfecha.Text, "")
            cFecVen = ""
            cFecPag = ""
            cFecrete = ""
            cFecretepago = ""

            '====
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            '=================================

            'Cuando es Insercion se pasa en blanco, si es Actualizacioon se pasa el correlativo
            'ordeninsercion = If(Me.accionMante = "I", 0, correlativo)
            '=====
            a = objSql.Ejecutar2("sp_Con_Ins_Detalle_Voucher", gbcodempresa, gbano, gbmes, libro, nrovoucher, _
                                    cuenta, nDebSol, nHabSol, txtDescri.Text, txtTipDoc.Text, txtNoDoc.Text, _
                                    cFecDoc, cFecVen, txtCtaCte.Text, moneda, CDbl(txtTipCambio.Text), columna, _
                                    "", "", "", "", nDebDol, nHabDol, "N", "", _
                                    "", "", "", _
                                    cFecrete, cFecretepago, _
                                    "", "", cFecPag, "", "", _
                                    txtcomprobante.Text, "", "", "", "", "", "", 0, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function descrifraformula2(ByVal formula As String) As String
        descrifraformula2 = formula
        Try
            If descrifraformula2.Trim = "" Then descrifraformula2 = "0" : Exit Function

            If formula.Contains("VALOR") = True Then
                descrifraformula2 = descrifraformula2.Replace("VALOR", traevalor("VALOR", ""))
            End If
            If formula.Contains("IGV") = True Then
                descrifraformula2 = descrifraformula2.Replace("IGV", traevalor("IGV", ""))
            End If
            Dim i As Integer
            Dim fila As String

            For i = 1 To 100
                fila = "F" + CType(i, String)
                If formula.Contains(fila) = True Then
                    descrifraformula2 = descrifraformula2.Replace(fila, traevalor(fila, CType(i, String)))
                End If
            Next

            'If formula.Contains("F1") = True Then
            ' descrifraformula2 = descrifraformula2.Replace("F1", traevalor("F1", "1"))
            'End If
        Catch ex As Exception
            descrifraformula2 = "0"
        End Try
    End Function
    Function descrifraformula(ByVal formula As String) As Double
        Dim i As Integer
        Dim caracter As String = ""
        Dim valor As String = ""
        Dim importe As String = ""
        Dim importe2 As String = ""

        descrifraformula = 0

        If formula = "" Then
            descrifraformula = 0 : Exit Function
        End If

        Try
            For i = 1 To formula.Length
                caracter = formula.Substring(i - 1, 1)
                If essigno(caracter) = False Then
                    valor = valor & caracter
                Else
                    importe2 = traevalor(valor, "")
                    importe = importe + importe2 + caracter
                End If
            Next i
            descrifraformula = 0
        Catch ex As Exception
            descrifraformula = 0
        End Try
    End Function
    Function Sumarvalores(ByVal importe1 As Double, ByVal signo As String, ByVal importe2 As Double) As Double
        Try
            Sumarvalores = 0
            Select Case signo
                Case "+"
                    Sumarvalores = importe1 + importe2
                Case "-"
                    Sumarvalores = importe1 - importe2
                Case "*"
                    Sumarvalores = importe1 * importe2
                Case "/"
                    Sumarvalores = importe1 / importe2
                Case Else
                    Sumarvalores = 0
            End Select
        Catch ex As Exception
            Sumarvalores = 0
        End Try
    End Function

    Function traevalor(ByVal Flagvalor As String, ByVal flagcodigo As String) As String

        Try
            traevalor = "0"

            If Funciones.Funciones.izquierda(Flagvalor.ToUpper, 1) = "F" Then
                Dim customerRow() As Data.DataRow
                customerRow = tablaDet.Select("ccd03ord = '" + flagcodigo + "'")
                traevalor = CType(customerRow(0)("ccd03valor"), String)
            ElseIf Flagvalor.ToUpper = "IGV" Then
                traevalor = CType((gbigv / 100), String)
            ElseIf Flagvalor.ToUpper = "VALOR" Then
                traevalor = CType(txtimporte.Text, String)
            Else
                If IsNumeric(Flagvalor) Then
                    traevalor = CType(Flagvalor, String)
                Else
                    traevalor = "0"
                End If
            End If
        Catch ex As Exception
            traevalor = "0"
        End Try
    End Function
    Function essigno(ByVal caracter As String) As Boolean
        Try
            essigno = False
            If caracter = "+" Or caracter = "-" Or caracter = "*" Or caracter = "/" Then
                essigno = True
            ElseIf caracter = "." Or caracter = "," Then
                essigno = True
            Else
                essigno = False
            End If
        Catch ex As Exception
            essigno = False
        End Try
    End Function

    Private Sub cbomoneda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbomoneda.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskfecha.LostFocus
        'Tipo de cambio de la venta
        Try
            txtTipCambio.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "V")

            If CType(txtTipCambio.Text, Double) <= 1 Then
                MessageBox.Show("VALIDAR :: No existe tipo de cambio", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            txtTipCambio.Text = "1.000"
            MessageBox.Show("VALIDAR :: No existe tipo de cambio", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btncancelaat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelaat.Click
        cargarDatos(frmOrigen.P_FilaDeTabla)
        Me.HabilitarMantenimiento(False)
        'Habilita
        grbdatosdet.Enabled = False
        btngenerarat.Enabled = False
        btncancelaat.Enabled = False
        'Deshabilto mantenimiento
        grbmantodet.Enabled = True
    End Sub

    Private Sub btnhelp_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_3.Click
        Me.TraerAyuda(3, btnhelp_3)
    End Sub

    Private Sub txtasientotipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtasientotipo.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtCtaCte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCtaCte.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_3_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtTipDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipDoc.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtTipDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipDoc.LostFocus
        Me.TraeDameDescripcion(2)
    End Sub
    Private Sub btnDetraccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetraccion.Click
        'Validar si esta abierto
        If Funciones.Funciones.FormIsOpen("Frm_Detraccion") Then Exit Sub
        '
        Dim _Frm_Detraccion As New Frm_Voucher_Detraccion

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_Detraccion.p_FormularioPadre = Me.Name
            _Frm_Detraccion.p_accionMante = "V"
            _Frm_Detraccion.p_RegistroActivo = FilaDeTabla
            _Frm_Detraccion.Owner = Me
            _Frm_Detraccion.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    

    Private Sub btnreferencias_Click(sender As System.Object, e As System.EventArgs) Handles btnreferencias.Click
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

    

    Private Sub txtNoDoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoDoc.Leave
        If nroDoc.Equals(txtNoDoc.Text) = False Then
            editoNroDocumento = True
        Else
            editoNroDocumento = False
        End If
    End Sub

    Private Sub txtTipDoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipDoc.Leave
        If tipoDoc.Equals(txtTipDoc.Text) = False Then
            editoTipoDocumento = True
        Else
            editoTipoDocumento = False
        End If
    End Sub

    Private Sub txtTipCambio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipCambio.Leave
        If CDbl(tipoCambio).Equals(CDbl(txtTipCambio.Text)) = False Then
            editoTipoCambio = True
        Else
            editoTipoCambio = False
        End If
    End Sub

    Private Sub cbomoneda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbomoneda.Leave
        If tipoMoneda.Equals(cbomoneda.Text) = False Then
            editoMoneda = True
        Else
            editoMoneda = False
        End If
    End Sub


    Private Sub txtcomprobante_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcomprobante.Leave
        If numeroComprobante.Equals(txtcomprobante.Text) = False Then
            editoComprobante = True
        Else
            editoComprobante = False
        End If
    End Sub

    Private Sub txtCtaCte_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCtaCte.Leave
        If codctaCte.Equals(txtCtaCte.Text) = False Then
            editoCtaCte = True
        Else
            editoCtaCte = False
        End If
    End Sub

    Private Sub mskfecha_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskfecha.Leave
        'obtener el tipo de cambio por fecha
        If fechaDocCadena.Equals(mskfecha.Text) = False Then
            editoFecha = True
            Dim tipoCambio As Double = 0
            tipoCambio = CType(objSql.TraerValor("Spu_Ban_Trae_TipoCambioxFecha", mskfecha.Text, 0), Double)
            txtTipCambio.Text = tipoCambio.ToString
            editoFecha = True

        Else
            editoFecha = False
        End If

        
    End Sub
End Class