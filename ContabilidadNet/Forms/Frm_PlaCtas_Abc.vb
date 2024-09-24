Option Explicit On
Option Strict On
Public Class Frm_PlaCtas_Abc

#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim VistaHelp As DataView
    Dim frmOrigen As Frm_PlaCtas
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
    Function DameDescripcion(ByVal cCodigoBus As String, ByVal cFlag As String) As String
        ' Obtengo la Descripcion
        Try
            DameDescripcion = CType(objSql.TraerValor("sp_Con_Dame_Descripcion", gbcodempresa, cCodigoBus, cFlag, ""), String)
        Catch ex As Exception
            DameDescripcion = ""
        End Try
    End Function
    Sub TraeCentroCostos()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_CenCos_SoloMov", gbcodempresa, "", "*", gbano).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeTipoCtaCte()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Tipos_Analisis", gbcodempresa, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeCuentas()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Cuentas_HabYMov", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraeGlo01tablas(ByVal tabla As String)
        Try
            VistaHelp = objSql.TraerDataTable("Sp_Glo_Trae_glo01tablas", tabla, "GLO", "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
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
            '
            'Valores por defecto
            rbtMoneda_0.Checked = True
            rbtTipCam_1.Checked = True
            rbtamarre_0.Checked = True
            rbtamarre_2.Enabled = False
            chkHabilita.Checked = False
            txtcuenta.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub modificar()
        Me.accionMante = "M"
        Me.HabilitarMantenimiento(True)
        'Deshabilto opcion de seleccionar a solicitud de contabilidad
        rbtamarre_2.Enabled = False

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
            txtcuenta.ReadOnly = If(Me.accionMante = "M", True, Not valor)

        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Sub Iniciarcontroles()
        Me.cargarDatos(RegistroActivo)
        Me.HabilitarMantenimiento(False)
    End Sub
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtcuenta.Text = filaactiva("ccm01cta").ToString
                txtdescripcion.Text = filaactiva("ccm01des").ToString
                ' Muestro el Tipo de Moneda
                rbtMoneda_0.Checked = If(filaactiva("ccm01dn").ToString = "S", True, False)
                rbtMoneda_1.Checked = If(filaactiva("ccm01dn").ToString = "D", True, False)
                '
                chkHabilita.Checked = If(filaactiva("ccm01hab").ToString = "S", False, True)
                chkReclasif.Checked = If(filaactiva("ccm01rec").ToString = "S", True, False)
                ' Coloco los Valores de Balance
                txtbalance.Text = filaactiva("ccm01bal").ToString
                TraeDameDescripcion(1)
                ' Coloco los Valores de Clase
                txtclase.Text = filaactiva("ccm01cla").ToString
                TraeDameDescripcion(0)

                'Muestro el Tipo de Moneda
                rbtTipCam_0.Checked = If(filaactiva("ccm01tc").ToString = "C", True, False)
                rbtTipCam_1.Checked = If(filaactiva("ccm01tc").ToString = "V", True, False)
                'Ubico el Tipo de Analisis
                txttipoanalisis.Text = filaactiva("ccm01ana").ToString
                TraeDameDescripcion(3)

                'Veo que tipo de Amarre Tiene
                If filaactiva("ccm01ams").ToString = "D" Then
                    rbtamarre_1.Checked = True
                ElseIf filaactiva("ccm01ams").ToString = "S" Then
                    rbtamarre_2.Checked = True
                Else
                    rbtamarre_0.Checked = True
                End If

                ' Ubico Amarre al Debe
                txtamarradebe.Text = filaactiva("ccm01amd").ToString
                TraeDameDescripcion(4)
                ' Ubico Amarre al Haber
                txtamarrehaber.Text = filaactiva("ccm01amh").ToString
                TraeDameDescripcion(5)

                ' Coloco los Valores de Ajustes y Movimiento
                chkAjDif.Checked = If(filaactiva("ccm01aj").ToString = "S", True, False)
                chkAjInf.Checked = If(filaactiva("ccm01axi").ToString = "S", True, False)

                chkeximaquina.Checked = If(filaactiva("ccm01flagmaquina").ToString = "S", True, False)
                chkexitraencurso.Checked = If(filaactiva("ccm01flagTrabajoCurso").ToString = "S", True, False)

                ' Coloco los Valores de Costo de Cuentas
                txtcosto.Text = filaactiva("ccm01fv").ToString
                ' Coloco los Valores de Flujo de Efectivo
                txtflujoefectivo.Text = filaactiva("ccm01flu").ToString
                ' Ubico Cuenta de Saldo
                txtsaldarcon.Text = filaactiva("ccm01salda").ToString
                TraeDameDescripcion(9)
                '
                chkCenCos.Checked = If(filaactiva("ccm01cc").ToString = "S", True, False)
                '
                txtcentrocosto.Text = filaactiva("ccm01defcc").ToString
                TraeDameDescripcion(2)

                txtcentrogestion.Text = filaactiva("ccm01defcg").ToString
                'lblhelp_8.Text = DameDescripcion("" & txtcentrogestion.Text, "G1")

                'mskPorcentaje = filaactiva"ccm01porc")
                rbtAfeccion_0.Checked = If(filaactiva("ccm01defai").ToString = "A", True, False)
                rbtAfeccion_1.Checked = If(filaactiva("ccm01defai").ToString = "I", True, False)
                rbtAfeccion_2.Checked = If(filaactiva("ccm01defai").ToString = "", True, False)

                chkctaretencion.Checked = If(filaactiva("ccm01CtaRetencion").ToString = "S", True, False)
                '
                cbocolreg.Text = filaactiva("ccm01ColReg").ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
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


            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "glo01codigo"
                    tblhelp.Columns(1).DataField = "glo01descripcion"
                    Me.TraeGlo01tablas("68")
                Case 1
                    tblhelp.Columns(0).DataField = "glo01codigo"
                    tblhelp.Columns(1).DataField = "glo01descripcion"
                    Me.TraeGlo01tablas("30")
                Case 2
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeCentroCostos()
                Case 3
                    tblhelp.Columns(0).DataField = "ccb17cdgo"
                    tblhelp.Columns(1).DataField = "ccb17desc"
                    Me.TraeTipoCtaCte()
                Case 4
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.TraeCuentas()
                Case 5
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.TraeCuentas()
                Case 9
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.TraeCuentas()
            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.cancelar()
    End Sub
    Sub cancelar()
        Me.HabilitarMantenimiento(False)
        Me.cargarDatos(frmOrigen.P_FilaDeTabla)
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
    Private Sub btnhelp_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_2.Click
        Me.TraerAyuda(2, btnhelp_2)
    End Sub
    Private Sub btnhelp_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_3.Click
        Me.TraerAyuda(3, btnhelp_3)
    End Sub
    Private Sub btnhelp_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_4.Click
        Me.TraerAyuda(4, btnhelp_4)
    End Sub
    Private Sub btnhelp_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_5.Click
        Me.TraerAyuda(5, btnhelp_5)
    End Sub
    Private Sub btnhelp_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_6.Click
        Me.TraerAyuda(6, btnhelp_6)
    End Sub
    Private Sub btnhelp_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_7.Click
        Me.TraerAyuda(7, btnhelp_7)
    End Sub
    Private Sub btnhelp_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_9.Click
        Me.TraerAyuda(9, btnhelp_9)
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If txtcuenta.Text = "" Then Beep() : MessageBox.Show("Ingrese Código de Cuenta Corriente", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtcuenta.Focus() : Exit Sub
            If txtdescripcion.Text = "" Then Beep() : MessageBox.Show("Ingrese Descripcion de Cuenta Corriente", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtdescripcion.Focus() : Exit Sub
            '
            Dim Moneda As String
            Dim dist1 As Double = 100.0
            Dim dist2 As Double = 100.0
            Dim porcentaje As Double = 0.0
            Dim AjusDifCambio As String
            Dim AjusPorInflacion As String
            Dim Flagcentrodecosto As String
            Dim FlagReclasifica As String

            Dim Flagtipocam As String
            Dim FlagHabilita As String
            Dim FlagAfecto As String
            Dim FlagRetencion As String
            Dim FlagTipoAmarre As String
            Dim periodo As String
            Dim fechaUsuario As String

            Dim FlagExiMaquinaria As String
            Dim FlagExiTraenCurso As String



            Moneda = If(rbtMoneda_0.Checked = True, "S", "D")
            AjusDifCambio = If(chkAjDif.Checked = True, "S", "N")
            AjusPorInflacion = If(chkAjInf.Checked = True, "S", "N")
            Flagcentrodecosto = If(chkCenCos.Checked = True, "S", "N")
            Flagtipocam = If(rbtTipCam_0.Checked = True, "C", "V")
            FlagReclasifica = If(chkReclasif.Checked = True, "S", "N")
            FlagHabilita = If(chkHabilita.Checked = True, "N", "S")
            FlagAfecto = If(rbtAfeccion_0.Checked = True, "A", If(rbtAfeccion_0.Checked = True, "I", ""))
            FlagRetencion = If(chkctaretencion.Checked = True, "S", "N")
            FlagTipoAmarre = If(rbtamarre_0.Checked = True, "N", If(rbtamarre_1.Checked = True, "D", "S"))

            If rbtamarre_1.Checked = True Then
                If txtamarradebe.Text = "" Or txtamarrehaber.Text = "" Then
                    MessageBox.Show("VALIDAR :: DEBE y HABER son obligatorios cuando selecciona Cuentas Destino Directa", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

            End If
            periodo = gbano + gbmes
            fechaUsuario = Funciones.Funciones.FormatearFecha(Date.Today, Funciones.Funciones.enmTipoFormatoFecha.enmFechaLarga)

            FlagExiMaquinaria = If(chkeximaquina.Checked = True, "S", "N")
            FlagExiTraenCurso = If(chkexitraencurso.Checked = True, "S", "N")

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Cuenta", gbcodempresa, gbano, txtcuenta.Text, txtdescripcion.Text, Moneda, txtamarradebe.Text, txtamarrehaber.Text, _
                                    txtclase.Text, txtsaldarcon.Text, txttipoanalisis.Text, txtbalance.Text, CType(dist1, Double), CType(dist2, Double), _
                                    AjusDifCambio, AjusPorInflacion, Flagcentrodecosto, txtcosto.Text, txtcentrogestion.Text, Flagtipocam, FlagReclasifica, _
                                    txtflujoefectivo.Text, FlagHabilita, CType(porcentaje, Double), txtcentrocosto.Text, txtcentrogestion.Text, FlagAfecto, FlagRetencion, _
                                    periodo, fechaUsuario, FlagTipoAmarre, FlagExiMaquinaria, FlagExiTraenCurso, cbocolreg.Text, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Cuenta", gbcodempresa, gbano, txtcuenta.Text, txtdescripcion.Text, Moneda, txtamarradebe.Text, txtamarrehaber.Text, _
                                     txtclase.Text, txtsaldarcon.Text, txttipoanalisis.Text, txtbalance.Text, dist1, dist2, _
                                    AjusDifCambio, AjusPorInflacion, Flagcentrodecosto, txtcosto.Text, txtcentrogestion.Text, Flagtipocam, FlagReclasifica, _
                                    txtflujoefectivo.Text, FlagHabilita, porcentaje, txtcentrocosto.Text, txtcentrogestion.Text, FlagAfecto, FlagRetencion, _
                                    periodo, fechaUsuario, FlagTipoAmarre, FlagExiMaquinaria, FlagExiTraenCurso, cbocolreg.Text, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            '
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                'Otros Mensajes
                Me.frmOrigen.refrescarGrillaConFiltro()
                Me.frmOrigen.Posicionar("ccm01cta", txtcuenta.Text.Trim)
            End If
            If accionMante = "A" Then
                Me.Nuevo()
            Else
                Me.cancelar()
            End If

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
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
    Private Sub txtcosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcosto.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_6_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtflujoefectivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtflujoefectivo.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_7_Click(Nothing, Nothing)
        End If
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txtclase.Text = tblhelp.Columns("glo01codigo").Value.ToString
                    lblhelp_0.Text = tblhelp.Columns("glo01descripcion").Value.ToString
                    txtclase.Focus()
                Case 1
                    txtbalance.Text = tblhelp.Columns("glo01codigo").Value.ToString
                    lblhelp_1.Text = tblhelp.Columns("glo01descripcion").Value.ToString
                    txtbalance.Focus()
                Case 2
                    txtcentrocosto.Text = tblhelp.Columns("ccb02cod").Value.ToString
                    lblhelp_2.Text = tblhelp.Columns("ccb02des").Value.ToString
                    txtcentrocosto.Focus()
                Case 3
                    txttipoanalisis.Text = tblhelp.Columns("ccb17cdgo").Value.ToString
                    lblhelp_3.Text = tblhelp.Columns("ccb17desc").Value.ToString
                    txttipoanalisis.Focus()
                Case 4
                    If tblhelp.Columns("ccm01mov").Value.ToString <> "S" Then MessageBox.Show("Validacion:: La cueenta debe ser de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                    txtamarradebe.Text = tblhelp.Columns("ccm01cta").Value.ToString
                    lblhelp_4.Text = tblhelp.Columns("ccm01des").Value.ToString
                    txtamarradebe.Focus()
                Case 5
                    If tblhelp.Columns("ccm01mov").Value.ToString <> "S" Then MessageBox.Show("Validacion:: La cueenta debe ser de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                    txtamarrehaber.Text = tblhelp.Columns("ccm01cta").Value.ToString
                    lblhelp_5.Text = tblhelp.Columns("ccm01des").Value.ToString
                    txtamarrehaber.Focus()
                Case 9
                    If tblhelp.Columns("ccm01mov").Value.ToString <> "S" Then MessageBox.Show("Validacion:: La cueenta debe ser de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                    txtsaldarcon.Text = tblhelp.Columns("ccm01cta").Value.ToString
                    lblhelp_9.Text = tblhelp.Columns("ccm01des").Value.ToString
                    txtsaldarcon.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Frm_PlaCtas_Abc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Detalle del plan de cuentas"
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            frmOrigen = CType(Me.Owner, Frm_PlaCtas)
            HabilitarMantenimiento(False)
            '
            If Me.accionMante = "N" Then
                Nuevo()
            ElseIf Me.accionMante = "M" Then
                cargarDatos(RegistroActivo)
                modificar()
            ElseIf Me.accionMante = "V" Then
                cargarDatos(RegistroActivo)
            End If

        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbtamarre_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtamarre_1.CheckedChanged
        Dim che As RadioButton
        Dim indice As String
        che = CType(sender, RadioButton)
        indice = Funciones.Funciones.derecha(che.Name, 1)
        habydeshabAmarre(True)

        'If indice = "2" Then 'Seleccionar
        '    habydeshabAmarre(True)
        'ElseIf indice = "0" Then 'Ninguno
        '    habydeshabAmarre(False)

        '    txtamarradebe.Text = ""
        '    txtamarrehaber.Text = ""

        'ElseIf indice = "1" Then 'Directo
        '    habydeshabAmarre(True)
        'End If
    End Sub
    Private Sub rbtamarre_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtamarre_0.CheckedChanged
        Dim che As RadioButton
        Dim indice As String
        che = CType(sender, RadioButton)
        indice = Funciones.Funciones.derecha(che.Name, 1)
        habydeshabAmarre(False)

        txtamarradebe.Text = ""
        txtamarrehaber.Text = ""
        lblhelp_4.Text = ""
        lblhelp_5.Text = ""
        'If indice = "2" Then 'Seleccionar
        '    habydeshabAmarre(True)
        'ElseIf indice = "0" Then 'Ninguno
        '    habydeshabAmarre(False)

        '    txtamarradebe.Text = ""
        '    txtamarrehaber.Text = ""

        'ElseIf indice = "1" Then 'Directo
        '    habydeshabAmarre(True)
        'End If
    End Sub
    Private Sub rbtamarre_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtamarre_2.CheckedChanged
        Dim che As RadioButton
        Dim indice As String
        che = CType(sender, RadioButton)
        indice = Funciones.Funciones.derecha(che.Name, 1)
        habydeshabAmarre(True)

        'If indice = "2" Then 'Seleccionar
        '    habydeshabAmarre(True)
        'ElseIf indice = "0" Then 'Ninguno
        '    habydeshabAmarre(False)

        '    txtamarradebe.Text = ""
        '    txtamarrehaber.Text = ""

        'ElseIf indice = "1" Then 'Directo
        '    habydeshabAmarre(True)
        'End If
    End Sub
    Private Sub habydeshabAmarre(ByVal valor As Boolean)


        txtamarradebe.Enabled = valor
        txtamarrehaber.Enabled = valor
        btnhelp_4.Enabled = valor
        btnhelp_5.Enabled = valor
    End Sub
    Private Sub txtclase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtclase.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)

        End If
    End Sub

    Private Sub txtbalance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbalance.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txttipoanalisis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttipoanalisis.KeyDown

        If e.KeyCode = Keys.F1 Then
            btnhelp_3_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtsaldarcon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsaldarcon.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_9_Click(Nothing, Nothing)
        End If
    End Sub


    Private Sub txtamarradebe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtamarradebe.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_4_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtamarrehaber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtamarrehaber.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_5_Click(Nothing, Nothing)
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

    Private Sub txtclase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtclase.LostFocus
        TraeDameDescripcion(0)
    End Sub
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try


            Select Case indice
                Case 0
                    If txtclase.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = DameDescripcion("68" & txtclase.Text.Trim, "GL")
                    End If
                Case 1
                    If txtbalance.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = DameDescripcion("30" & txtbalance.Text.Trim, "GL")
                    End If
                Case 2
                    If txtcentrocosto.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = DameDescripcion(gbano + txtcentrocosto.Text, "T1")
                    End If
                Case 3
                    If txttipoanalisis.Text = "" Then
                        lblhelp_3.Text = ""
                    Else
                        lblhelp_3.Text = DameDescripcion(txttipoanalisis.Text, "TA")
                    End If
                Case 4
                    If txtamarradebe.Text = "" Then
                        lblhelp_4.Text = ""
                    Else
                        lblhelp_4.Text = DameDescripcion(gbano + txtamarradebe.Text, "C3")
                    End If
                Case 5
                    If txtamarrehaber.Text = "" Then
                        lblhelp_5.Text = ""
                    Else
                        lblhelp_5.Text = DameDescripcion(gbano + txtamarrehaber.Text, "C3")
                    End If
                Case 9
                    If txtsaldarcon.Text = "" Then
                        lblhelp_9.Text = ""
                    Else
                        lblhelp_9.Text = DameDescripcion(gbano + txtsaldarcon.Text, "C3")
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show("ERROR :: Inesperado", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtclase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtclase.TextChanged

    End Sub

    Private Sub txtbalance_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbalance.LostFocus
        TraeDameDescripcion(1)
    End Sub

    Private Sub txtamarradebe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamarradebe.LostFocus
        TraeDameDescripcion(4)
    End Sub

    Private Sub txtamarrehaber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamarrehaber.LostFocus
        TraeDameDescripcion(5)
    End Sub

    Private Sub txttipoanalisis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipoanalisis.LostFocus
        TraeDameDescripcion(3)
    End Sub

    Private Sub txtcentrocosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcentrocosto.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If

    End Sub
    Private Sub txtcentrocosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentrocosto.LostFocus
        TraeDameDescripcion(2)
    End Sub

    Private Sub txtcentrocosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentrocosto.TextChanged

    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            If MessageBox.Show("¿ Está seguro de Eliminar ?" & txtcuenta.Text.Trim, "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
            a = objSql.Ejecutar2("sp_Con_Del_Cuenta", gbcodempresa, gbano, txtcuenta.Text.Trim, "")

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrillaConFiltro()
                Me.Close()
            Else
                'No hago nada
            End If
            'Armar Identificador de Fila
        Catch ex As Exception
        End Try
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

    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub

    Private Sub txtsaldarcon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsaldarcon.LostFocus
        TraeDameDescripcion(9)
    End Sub

    Private Sub txtsaldarcon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsaldarcon.TextChanged

    End Sub
End Class