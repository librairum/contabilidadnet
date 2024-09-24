Option Strict On
Option Explicit On
Public Class Frm_Empresa_Abc
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim VistaHelp As DataView
    Dim frmOrigen As Frm_Empresa
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
#End Region
#Region "Metodos de Mantenimiento"
    Sub Nuevo()
        Me.accionMante = "N"
        Me.HabilitarMantenimiento(True)
        LimpiarControles(Me)
        '
        'Valores por defecto
        rbtTCUsar_0.Checked = True
        rbtFecha_0.Checked = True
        txtCodigo.Focus()
    End Sub
    Sub modificar()
        Me.accionMante = "M"
        Me.HabilitarMantenimiento(True)
        'No se puede modificar año por aca
        txtperiodo.ReadOnly = True
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
            'Bloque controles de segumiento
            btnanterior.Visible = Not valor
            btnsiguiente.Visible = Not valor
            btnprimero.Visible = Not valor
            btnultimo.Visible = Not valor

            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
            txtCodigo.ReadOnly = If(Me.accionMante = "M", True, Not valor)
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

                txtCodigo.Text = filaactiva("Codigo").ToString
                txtNombre.Text = filaactiva("Nombre").ToString
                txtDireccion.Text = filaactiva("Direccion").ToString
                txtruc.Text = filaactiva("Ruc").ToString
                txtperiodo.Text = filaactiva("Ejercicio").ToString
                txtRepresentante.Text = filaactiva("Representante").ToString
                txtCargo.Text = filaactiva("Cargo").ToString
                txtContador.Text = filaactiva("Contador").ToString
                txtMatricula.Text = filaactiva("Matricula").ToString

                chkModifTC.Checked = If(filaactiva("ModifTC").ToString = "S", True, False)
                chkBiMoneda.Checked = If(filaactiva("BiMoneda").ToString = "S", True, False)

                If filaactiva("TCUsar").ToString = "B" Then
                    rbtTCUsar_0.Checked = True
                ElseIf filaactiva("TCUsar").ToString = "S" Then
                    rbtTCUsar_1.Checked = True
                End If

                If filaactiva("FecProvision").ToString = "V" Then
                    rbtFecha_0.Checked = True
                ElseIf filaactiva("FecProvision").ToString = "D" Then
                    rbtFecha_1.Checked = True
                End If

                chkTipoAgente.Checked = If(filaactiva("FlagRetencion").ToString = "S", True, False)
                txtMontoRetencion.Text = filaactiva("ImpRetencion").ToString
                txtTasaRetencion.Text = filaactiva("TasaRetencion").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


#End Region
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        'me.cargarDatos()
        Me.HabilitarMantenimiento(False)
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Me.modificar()
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim clave As String
        Dim flagModifTC As String
        Dim flagBiMoneda As String
        Dim flagTCUsar As String
        Dim flagFecha As String
        Dim flagTipoAgente As String
        Try

            If txtCodigo.Text = "" Then Beep() : MessageBox.Show("Ingrese Código ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCodigo.Focus() : Exit Sub
            If txtNombre.Text = "" Then Beep() : MessageBox.Show("Ingrese Descripcion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNombre.Focus() : Exit Sub
            If txtDireccion.Text = "" Then Beep() : MessageBox.Show("Ingrese Direccion", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtDireccion.Focus() : Exit Sub
            If txtruc.Text = "" Then Beep() : MessageBox.Show("Ingrese RUC", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtruc.Focus() : Exit Sub
            '

            flagTCUsar = If(rbtTCUsar_0.Checked = True, "B", "S")
            flagFecha = If(rbtFecha_0.Checked = True, "V", "D")
            flagTipoAgente = If(chkTipoAgente.Checked = True, "S", "N")
            clave = ""


            flagModifTC = If(chkModifTC.Checked = True, "S", "N")
            flagBiMoneda = If(chkBiMoneda.Checked = True, "S", "N")

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Empresa", gbc_sistema, txtCodigo.Text, txtNombre.Text, txtDireccion.Text, txtRepresentante.Text, txtCargo.Text, txtContador.Text, _
                                    txtMatricula.Text, txtperiodo.Text, clave, flagModifTC, flagTCUsar, _
                                    "", "", "", "", "", "", "", "", _
                                    flagBiMoneda, flagFecha, flagTipoAgente, CDbl(txtMontoRetencion.Text), CDbl(txtTasaRetencion.Text), txtruc.Text, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Empresa", gbc_sistema, txtCodigo.Text, txtNombre.Text, txtDireccion.Text, txtRepresentante.Text, txtCargo.Text, txtContador.Text, _
                                    txtMatricula.Text, txtperiodo.Text, clave, flagModifTC, flagTCUsar, _
                                    "", "", "", "", "", "", "", "", _
                                    flagBiMoneda, flagFecha, flagTipoAgente, CDbl(txtMontoRetencion.Text), CDbl(txtTasaRetencion.Text), txtruc.Text, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
                frmOrigen.Posicionar("Codigo", txtCodigo.Text.Trim)
                Me.HabilitarMantenimiento(False)
            Else
                'No hago nada
            End If
        Catch ex As Exception
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

    Private Sub Frm_PlaCtas_Abc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Inicializo mi formulario desde donde se cargo 
            frmOrigen = CType(Me.Owner, Frm_Empresa)
            HabilitarMantenimiento(False)
            Me.Text = "Detalle de empresa"
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)


            If Me.accionMante = "N" Then
                Nuevo()
            ElseIf Me.accionMante = "M" Then
                cargarDatos(RegistroActivo)
                modificar()
            ElseIf Me.accionMante = "V" Then
                cargarDatos(RegistroActivo)
            End If
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            If MessageBox.Show("¿ Está seguro de Eliminar ?" & txtCodigo.Text.Trim, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
            a = objSql.Ejecutar2("sp_Glo_Del_Empresa", gbc_sistema, txtCodigo.Text, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
                frmOrigen.Posicionar("Codigo", txtCodigo.Text.Trim)
            Else
                'No hago nada
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class