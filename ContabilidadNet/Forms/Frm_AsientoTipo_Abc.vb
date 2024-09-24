Option Strict On
Option Explicit On
Public Class Frm_AsientoTipo_Abc

#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Private accionManteDet As String
    Private insertar As Boolean
    Private posicion_Insercion As Integer
    Private Norden_Final As Integer
    Private Norden As Integer

    Dim VistaHelp As DataView
    Dim Vista As DataView
    Dim frmOrigen As Frm_AsientoTipo
    Dim nombredeobjeto As String = "Distribucion de Costos"
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
    Sub CargaDetalleAsiTipo()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Detalle_Asi_Tipo", gbcodempresa, gbano, txtCodigo.Text).DefaultView
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
            VistaHelp = objSql.TraerDataTable(query, gbcodempresa, gbano, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function TraeMaxOrden(ByVal numero As String) As Integer
        ' Obtengo la Descripcion
        TraeMaxOrden = 0
        Try
            TraeMaxOrden = CType(objSql.TraerValor("Spu_Con_Trae_MaxNumorden", gbcodempresa, gbano, numero, 0), Integer)
        Catch ex As Exception
            TraeMaxOrden = 0
        End Try
    End Function

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
            txtCodigo.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub NuevoDet()
        Try
            Me.accionManteDet = "N"
            Me.HabilitarMantenimientoDet(True)
            LimpiarControlesDet()
            txtcuenta.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesDet()
        Try
            txtcuenta.Text = ""
            lblhelp_1.Text = ""
            cbocargoabono.Text = ""
            cbocolumna.Text = ""
            txtformula.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            'Controles que no se puedn modificar
        Catch ex As Exception

        End Try
    End Sub

    Sub modificarDet()
        Try
            Me.accionManteDet = "M"
            Me.HabilitarMantenimientoDet(True)
            'Controles que no se puedn modificar
        Catch ex As Exception

        End Try
    End Sub
    Sub eliminar()
        Try
            Beep()
            If MessageBox.Show("¿ Estás Seguro de Eliminar el Asiento : " & txtDescri.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Con_Del_Asiento_Tipo", gbcodempresa, gbano, txtCodigo.Text.Trim, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
            Else
                'No hago nada
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub eliminarDet()
        Try
            Beep()
            If MessageBox.Show("¿ Estás Seguro de Eliminar el Detalle : " & txtcuenta.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim campoorden As Integer
            campoorden = CType(FilaDeTabla("ccd03ord").ToString, Integer)

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_ccd03astip", gbcodempresa, gbano, txtCodigo.Text, campoorden, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                'Me.tblconsulta_RowColChange()
            Else
                'No hago nada
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            'Mod_Mantenimiento.HabyDesControles(Me, valor)
            txtCodigo.ReadOnly = Not valor
            txtDescri.ReadOnly = Not valor
            txtlibro.ReadOnly = Not valor
            btnhelp_0.Enabled = valor

            'Perosnalizar habilitacion
            btnnuevo.Visible = Not valor
            btnmodificar.Visible = Not valor
            btneliminar.Visible = Not valor
            btnsalir.Visible = Not valor
            'Otros Controles
            'Bloque controles de segumiento
            btnanterior.Visible = Not valor
            btnsiguiente.Visible = Not valor
            btnprimero.Visible = Not valor
            btnultimo.Visible = Not valor

            tblconsulta.Enabled = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
            txtCodigo.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
            'Deshabilito 
            GbxDetalle.Enabled = Not valor

        Catch ex As Exception
        End Try
    End Sub
    Sub DeshabilitarCabecera(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            txtCodigo.ReadOnly = True
            txtDescri.ReadOnly = True
            txtlibro.ReadOnly = True
            btnhelp_0.Enabled = False

            'Perosnalizar habilitacion
            btnnuevo.Visible = valor
            btnmodificar.Visible = valor
            btneliminar.Visible = valor
            '
            btngrabar.Visible = False
            btncancelar.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Sub HabilitarMantenimientoDet(ByVal valor As Boolean)
        Try
            '
            Me.DeshabilitarCabecera(Not valor)
            'Perosnalizar habilitacion
            lnkNuevo.Visible = Not valor
            lnkmodificar.Visible = Not valor
            lnkeliminar.Visible = Not valor
            lnkinsertar.Visible = Not valor
            '
            lnkgrabar.Visible = valor
            lnkcancelar.Visible = valor

            'los campos que no deben modificar, 
            'LLamar a la habiltacion gloabl
            txtcuenta.ReadOnly = Not valor
            btnhelp_1.Enabled = valor

            txtformula.ReadOnly = Not valor
            cbocargoabono.Enabled = valor
            cbocolumna.Enabled = valor

            tblconsulta.Enabled = Not valor

            txtcuenta.ReadOnly = If((Me.accionManteDet Is "M"), True, Not valor)
            btnhelp_1.Enabled = If((Me.accionManteDet Is "M"), False, valor)
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtCodigo.Text = filaactiva("ccc03cod").ToString
                txtDescri.Text = filaactiva("ccc03des").ToString
                txtlibro.Text = filaactiva("ccc03lib").ToString
                Me.TraeDameDescripcion(0)

                Me.CargaDetalleAsiTipo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub cargarDatosDet(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtcuenta.Text = filaactiva("ccd03cta").ToString
                Me.TraeDameDescripcion(1)
                Norden = CType(filaactiva("ccd03ord").ToString, Integer)
                txtformula.Text = filaactiva("ccd03desformula").ToString
                cbocargoabono.Text = filaactiva("ccd03ca").ToString
                cbocolumna.Text = filaactiva("ccd03afin").ToString
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
                Case 1
                    If txtcuenta.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(gbano + txtcuenta.Text.Trim, "C1")
                    End If
            End Select

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

            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()
                Case 1
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.traecuenta("sp_Con_Help_Cuentas_HabYMov")
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
                    txtcuenta.Text = tblhelp.Columns("ccm01cta").Value.ToString
                    lblhelp_1.Text = tblhelp.Columns("ccm01des").Value.ToString
                    txtcuenta.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub refrescarGrilla()
        CargaDetalleAsiTipo()
    End Sub

#End Region

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        'Cargar la fila actual
        If frmOrigen.tblconsulta.RowCount > 0 Then
            cargarDatos(RegistroActivo)
            'Poner en modo ver
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
    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Me.TraerAyuda(1, btnhelp_1)
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'Valido libro

            If txtCodigo.Text.Trim = "" Then Beep() : MessageBox.Show("VALIDACION :: Código no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCodigo.Focus() : Exit Sub
            If txtDescri.Text.Trim = "" Then Beep() : MessageBox.Show("VALIDACION :: Descripcion no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtDescri.Focus() : Exit Sub

            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            'El valor 001 y 01 son fijos
            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Cabecera_Asi_Tipo", gbcodempresa, gbano, txtCodigo.Text.Trim, txtDescri.Text.Trim, txtlibro.Text, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Cabecera_Asi_Tipo", gbcodempresa, gbano, txtCodigo.Text.Trim, txtDescri.Text.Trim, txtlibro.Text, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            '

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
                frmOrigen.Posicionar("ccc03cod", txtCodigo.Text.Trim)
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

    Private Sub Frm_AsientoTipo_Abc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializo mi formulario desde donde se cargo 
        Try
            Me.inicioControlesDiseno()
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)

            Me.Text = "Detalle de asiento tipo "

            '
            frmOrigen = CType(Me.Owner, Frm_AsientoTipo)
            '
            If Me.accionMante = "N" Then
                Me.Nuevo()
            ElseIf Me.accionMante = "M" Then
                Me.cargarDatos(RegistroActivo)
                Me.modificar()
            ElseIf Me.accionMante = "V" Then
                Me.cargarDatos(RegistroActivo)
                Me.HabilitarMantenimiento(False)
                Me.HabilitarMantenimientoDet(False)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        eliminar()
    End Sub
    Private Sub lnkNuevo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNuevo.LinkClicked
        Me.NuevoDet()
        insertar = False
    End Sub

    Private Sub lnkmodificar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkmodificar.LinkClicked
        Me.modificarDet()
        insertar = False
    End Sub

    Private Sub lnkeliminar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkeliminar.LinkClicked
        Me.eliminaDetalle()
    End Sub
    Sub eliminaDetalle()
        Try
            Beep()
            If MessageBox.Show("¿ Estás Seguro de Eliminar el Detalle : " & txtcuenta.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim campoorden As Integer
            campoorden = CType(FilaDeTabla("ccd03ord").ToString, Integer)

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_ccd03astip", gbcodempresa, gbano, txtCodigo.Text, campoorden, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                'Me.tblconsulta_RowColChange()
            Else
                'No hago nada
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblconsulta.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp.Tag, Integer)
        Try
            If tblhelp.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Try
            Me.capturarfilaactual()
            Me.cargarDatosDet(FilaDeTabla)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub lnkcancelar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkcancelar.LinkClicked
        'Cargar la fila actual
        Me.CargaDetalleAsiTipo()
        Me.tblconsulta_RowColChange(Nothing, Nothing)
        Me.HabilitarMantenimientoDet(False)
    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

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

    Private Sub lnkgrabar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkgrabar.LinkClicked
        Try
            'Valido libro
            If (lblhelp_1.Text = "" Or lblhelp_1.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Cuenta No valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtcuenta.Focus() : Exit Sub
            If cbocargoabono.Text = "" Then Beep() : MessageBox.Show("VALIDACION :: Cargo Abono no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : cbocargoabono.Focus() : Exit Sub

            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            'El valor 001 y 01 son fijos

            If accionManteDet = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Detalle_Asi_Tipo", gbcodempresa, gbano, txtCodigo.Text.Trim, 0, txtcuenta.Text.Trim, cbocolumna.Text, cbocargoabono.Text, "S", "N", "", txtformula.Text.Trim, "")
            ElseIf accionManteDet = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Detalle_Asi_Tipo", gbcodempresa, gbano, txtCodigo.Text.Trim, CType(Norden, Integer), txtcuenta.Text.Trim, cbocolumna.Text, cbocargoabono.Text, "S", "N", "", txtformula.Text.Trim, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            '
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                'Si se inserta
                If insertar = True Then
                    Dim b As Array = Array.CreateInstance(GetType(Object), 2, 10)
                    'El valor 001 y 01 son fijos
                    If accionManteDet = "N" Then
                        b = objSql.Ejecutar2("Spu_Con_Upd_Nordenccd03astip", gbcodempresa, gbano, txtCodigo.Text.Trim, posicion_Insercion, Norden_Final)
                    End If
                End If

                Me.refrescarGrilla()
                Me.tblconsulta_RowColChange(Nothing, Nothing)
                Me.HabilitarMantenimientoDet(False)
            Else
                'No hago nada
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lnkinsertar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkinsertar.LinkClicked
        Try

            Me.NuevoDet()
            insertar = True
            posicion_Insercion = 0
            Norden_Final = 0

            posicion_Insercion = Norden
            Norden_Final = CType(TraeMaxOrden(txtCodigo.Text), Integer)
            If Norden_Final = 0 Then
                MessageBox.Show("ERROR ::No existen registros", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                insertar = False
            End If

        Catch ex As Exception
            insertar = False
        End Try
    End Sub

    Private Sub txtcuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcuenta.KeyDown
        Me.TraerAyuda(1, btnhelp_1)
    End Sub

    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Me.TraeDameDescripcion(1)
    End Sub

    Private Sub txtcuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged

    End Sub

    Private Sub cbocargoabono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbocargoabono.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub cbocargoabono_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocargoabono.SelectedIndexChanged

    End Sub

    Private Sub cbocolumna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbocolumna.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub cbocolumna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocolumna.SelectedIndexChanged

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

    Private Sub txtlibro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlibro.KeyDown
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub txtlibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibro.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub

    Private Sub txtlibro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlibro.TextChanged

    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class