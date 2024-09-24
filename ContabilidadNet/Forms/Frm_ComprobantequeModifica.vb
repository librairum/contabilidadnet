Option Explicit On
Option Strict On
Public Class Frm_ComprobantequeModifica

#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim VistaHelp As DataView

    Dim frmOrigen As Frm_Voucher_Abc
    Dim frmOrigen1 As Frm_VoucherAT_abc
    Dim FilaDeTabla As DataRowView
    Dim filaactual As Integer

    'Variable para 
    Dim AccPerCon As String
    Dim VarImpChe As String
    Dim FormularioPadre As String
    '
    Dim voucherlibro As String
    Dim vouchernumero As String
    Dim vouchernroorden As Integer

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

    Public Property p_FormularioPadre() As String
        Get
            Return FormularioPadre
        End Get
        Set(ByVal value As String)
            FormularioPadre = value
        End Set
    End Property
#End Region
#Region "Traer Informacion de Base de Datos"

    Sub traetipodoc(ByVal campo As String, ByVal filtro As String)
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Tipos_Documentos", gbcodempresa, "*", "*").DefaultView
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
                    txttasa.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    TxtNroPago.Focus()
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
                    If txttasa.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(txttasa.Text, "TD")
                    End If
            End Select

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
#Region "Metodos de Mantenimiento"
    Sub Nuevo()
        Me.accionMante = "N"
        Me.HabilitarMantenimiento(True)
        LimpiarControles(Me)
        '
        txttasa.Focus()
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            txttasa.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            Mod_Mantenimiento.HabyDesControles(Me, valor)
            'Perosnalizar habilitacion
            btnmodificar.Visible = Not valor
            btneliminar.Visible = Not valor
            btnsalir.Visible = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
            'txttasa.ReadOnly = If(Me.accionMante = "M", True, Not valor)
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
                voucherlibro = filaactiva("ccd01subd").ToString
                vouchernumero = filaactiva("ccd01numer").ToString
                vouchernroorden = CInt(filaactiva("ccd01ord").ToString)
                txttasa.Text = filaactiva("ccd01cqmtipo").ToString
                Me.TraeDameDescripcion(0)
                TxtNroPago.Text = filaactiva("ccd01cqmnumero").ToString
                MskFecPago.Text = filaactiva("ccd01cqmfecha").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region
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

    Private Sub Frm_ComprobantequeModifica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            Me.Text = "Registrar Comprobantes que modifica"
            '
            Mod_Mantenimiento.tooltiptext(btnmodificar, "Agregar o Modificar")
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            HabilitarMantenimiento(False)
            '
            If FormularioPadre = "Frm_Voucher_Abc" Then
                frmOrigen = CType(Me.Owner, Frm_Voucher_Abc)
            Else
                frmOrigen1 = CType(Me.Owner, Frm_VoucherAT_abc)
            End If

            If Me.accionMante = "M" Then
                Me.cargarDatos(RegistroActivo)
                Me.modificar()
            Else
                Me.cargarDatos(RegistroActivo)
            End If
            Centrar(Me)
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub eliminar()
        Try
            '=============Validaciones ============
            'Capturo la fila anterior para posicionarme despues de la eliminacion

            '
            Beep()
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Upd_Comprobantequemodifica", gbcodempresa, gbano, gbmes, voucherlibro, vouchernumero, vouchernroorden, "", "", "", "")

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescagrillapadre()
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Me.eliminar()
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click

        Try
            'Valido usuario y clave
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then MessageBox.Show(gbc_MensajeValidar + "Tipo Doc No valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txttasa.Focus() : Exit Sub
            If TxtNroPago.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Numero Doc No valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : TxtNroPago.Focus() : Exit Sub
            If Not IsDate(MskFecPago.Text) Then MessageBox.Show(gbc_MensajeValidar + "Fecha Doc no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : MskFecPago.Focus() : Exit Sub


            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor

            '

            If accionMante = "M" Then
                a = objSql.Ejecutar2("Spu_Con_Upd_Comprobantequemodifica", gbcodempresa, gbano, gbmes, voucherlibro, vouchernumero, vouchernroorden, txttasa.Text, TxtNroPago.Text, MskFecPago.Text, "")
                ' Asigno los Valores a los Parametros del Query
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescagrillapadre()
                Me.Close()
            Else
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Sub refrescagrillapadre()
        If p_FormularioPadre = "Frm_Voucher_Abc" Then
            Frm_Voucher_Abc.refrescarGrilla()
        Else
            Frm_VoucherAT_abc.refrescarGrilla()
        End If
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
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

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

    End Sub

    Private Sub txttasa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttasa.LostFocus
        TraeDameDescripcion(0)
    End Sub

    Private Sub txttasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttasa.TextChanged

    End Sub

    Private Sub MskFecPago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MskFecPago.GotFocus
        Mod_Mantenimiento.sombrearcontrol(MskFecPago)
    End Sub

    Private Sub MskFecPago_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MskFecPago.MaskInputRejected

    End Sub
End Class