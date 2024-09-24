Option Strict On
Option Explicit On
Public Class Frm_Periodos_Abc
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim VistaHelp As DataView
    Dim frmOrigen As Frm_Periodos
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
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            Mod_Mantenimiento.HabyDesControles(Me, valor)
            'Perosnalizar habilitacion
            btnmodificar.Visible = Not valor
            'Bloque controles de segumiento
            btnanterior.Visible = Not valor
            btnsiguiente.Visible = Not valor
            btnprimero.Visible = Not valor
            btnultimo.Visible = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
            txtperiodo.ReadOnly = If(Me.accionMante = "M", True, Not valor)
        Catch ex As Exception
        End Try
    End Sub
    Sub Iniciarcontroles()
        Me.cargarDatos(RegistroActivo)
        Me.HabilitarMantenimiento(False)
    End Sub
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                ' Asigno los Tipos de Cambio
                txtperiodo.Text = filaactiva("ccb03cod").ToString
                txtdescripcion.Text = filaactiva("ccb03des").ToString
                txtTC.Text = filaactiva("ccb03tc").ToString
                txtIPM.Text = filaactiva("ccb03ipm").ToString
                txtCorrMon_0.Text = filaactiva("ccb03cms").ToString
                txtCorrMon_1.Text = filaactiva("ccb03cmd").ToString
                txtFactor_0.Text = filaactiva("ccb03fa00").ToString
                txtFactor_1.Text = filaactiva("ccb03fa01").ToString
                txtFactor_2.Text = filaactiva("ccb03fa02").ToString
                txtFactor_3.Text = filaactiva("ccb03fa03").ToString
                txtFactor_4.Text = filaactiva("ccb03fa04").ToString
                txtFactor_5.Text = filaactiva("ccb03fa05").ToString
                txtFactor_6.Text = filaactiva("ccb03fa06").ToString
                txtFactor_7.Text = filaactiva("ccb03fa07").ToString
                txtFactor_8.Text = filaactiva("ccb03fa08").ToString
                txtFactor_9.Text = filaactiva("ccb03fa09").ToString
                txtFactor_10.Text = filaactiva("ccb03fa10").ToString
                txtFactor_11.Text = filaactiva("ccb03fa11").ToString
                txtFactor_12.Text = filaactiva("ccb03fa12").ToString
                txttipoperiodo.Text = filaactiva("ccb03tipoperiodo").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


#End Region
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim periodo As String
        Try
            'Validar
            If Funciones.Funciones.Esnumeromayoracero(txtTC.Text) = False Then txtTC.Focus() : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(txtIPM.Text) = False Then txtIPM.Focus() : Exit Sub
            If IsNumeric(txtCorrMon_0.Text) = False Then txtCorrMon_0.Focus() : Exit Sub
            If IsNumeric(txtCorrMon_1.Text) = False Then txtCorrMon_1.Focus() : Exit Sub

            For Each co As Control In Me.Controls
                If Funciones.Funciones.izquierda(co.Name.ToUpper, 9) = "TXTFACTOR" Then
                    If Funciones.Funciones.Esnumeromayoracero(co.Text) = False Then
                        MessageBox.Show(gbc_MensajeValidar + " Valor no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit For
                    End If
                End If
            Next

            ' Periodo Modificado

            periodo = txtperiodo.Text

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            If accionMante = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Factores_Ajuste", gbcodempresa, periodo, txtdescripcion.Text, CDbl(txtTC.Text), CDbl(txtIPM.Text), CDbl(txtCorrMon_0.Text), CDbl(txtCorrMon_1.Text), _
                                     CDbl(txtFactor_0.Text), CDbl(txtFactor_1.Text), CDbl(txtFactor_2.Text), CDbl(txtFactor_3.Text), CDbl(txtFactor_4.Text), CDbl(txtFactor_5.Text), CDbl(txtFactor_6.Text), _
                                    CDbl(txtFactor_7.Text), CDbl(txtFactor_8.Text), CDbl(txtFactor_9.Text), CDbl(txtFactor_10.Text), CDbl(txtFactor_11.Text), CDbl(txtFactor_12.Text), txttipoperiodo.Text, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
                frmOrigen.Posicionar("ccb03cod", periodo)
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
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Detalle de Periodos"

            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)

            frmOrigen = CType(Me.Owner, Frm_Periodos)
            HabilitarMantenimiento(False)
            '
            If Me.accionMante = "M" Then
                cargarDatos(RegistroActivo)
                HabilitarMantenimiento(True)
            ElseIf Me.accionMante = "V" Then
                cargarDatos(RegistroActivo)
            End If

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

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Me.modificar()
    End Sub
    Sub modificar()
        Me.accionMante = "M"
        Me.HabilitarMantenimiento(True)
    End Sub

End Class
