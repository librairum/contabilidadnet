Option Explicit On
Option Strict On
Public Class Frm_PlaCtas_Copiar

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
    Sub TraePlactasModelo()
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Trae_PlanCuentasModelo", gbcodempresa, gbano, "ccm01cta", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Metodos de Mantenimiento"
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
            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraePlactasModelo()
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

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'me.cargarDatos()
        Me.Close()
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If txtcuenta.Text = "" Then Beep() : MessageBox.Show("Ingrese Código de Cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtcuenta.Focus() : Exit Sub
            If txtdescripcion.Text = "" Then Beep() : MessageBox.Show("Ingrese Descripcion de ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtdescripcion.Focus() : Exit Sub
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then MessageBox.Show(gbc_MensajeError + "Cuenta Modelo no Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtctamodelo.Focus() : Exit Sub
            '
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("Spu_Con_Ins_CuentaGrupal", gbcodempresa, gbano, txtctamodelo.Text, txtcuenta.Text, txtdescripcion.Text, "")
            'Llamo al mensaje del SQL
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                'Si todo esta Ok cierro e formualario
                Me.frmOrigen.refrescarGrillaConFiltro()
                Me.frmOrigen.Posicionar("ccm01cta", txtcuenta.Text.Trim)
            End If
            '
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txtctamodelo.Text = tblhelp.Columns("ccm01cta").Value.ToString
                    lblhelp_0.Text = tblhelp.Columns("ccm01des").Value.ToString
                    txtctamodelo.Focus()
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
                    If txtctamodelo.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtctamodelo.Text.Trim, "CT")
                    End If

            End Select
        Catch ex As Exception
            MessageBox.Show("ERROR :: Inesperado", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub Frm_PlaCtas_Copiar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializo mi formulario desde donde se cargo 
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Me.Text = "Copiar cuentas por bloques"

            '
            frmOrigen = CType(Me.Owner, Frm_PlaCtas)
            txtctamodelo.Text = frmOrigen.P_FilaDeTabla("ccm01cta").ToString
            lblhelp_0.Text = frmOrigen.P_FilaDeTabla("ccm01des").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtctamodelo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtctamodelo.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtctamodelo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctamodelo.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub

    Private Sub txtctamodelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctamodelo.TextChanged

    End Sub
End Class