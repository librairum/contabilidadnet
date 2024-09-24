Option Explicit On
Option Strict On
Public Class Frm_EEGGyPP_Conf

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
    Dim frmOrigen As Frm_EEGGyPP
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim tipoeegyp As String
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
        ''

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
    Private Sub TraeEstadoggypp(ByVal tipoestado As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Config_EstadoGGyPP", gbcodempresa, gbano, tipoestado).DefaultView
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
    Function TraeMaxOrden(ByVal tipo As String) As Integer
        ' Obtengo la Descripcion
        TraeMaxOrden = 0
        Try
            TraeMaxOrden = CType(objSql.TraerValor("Spu_Con_Trae_EGyPNumMax", gbcodempresa, gbano, tipo, 0), Integer)
        Catch ex As Exception
            TraeMaxOrden = 0
        End Try
    End Function
    Sub traecuenta(ByVal query As String)
        Try
            VistaHelp = objSql.TraerDataTable(query, gbcodempresa, gbano, "*", "*").DefaultView
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
            txtdescripcion.Text = ""
            cbotipo.Text = ""
            cboimprimir.Text = ""
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
    Sub eliminarDet()
        Try
            Beep()
            If MessageBox.Show("¿ Estás Seguro de Eliminar el Detalle : " & txtcuenta.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim campoorden As Integer
            campoorden = CType(FilaDeTabla("ccd03ord").ToString, Integer)

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_ccd03astip", gbcodempresa, gbano, "", campoorden, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                'Me.tblconsulta_RowColChange()
            Else
                'No hago nada
            End If
        Catch ex As Exception
        End Try
    End Sub


    Sub HabilitarMantenimientoDet(ByVal valor As Boolean)
        Try
            '
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

            txtdescripcion.ReadOnly = valor
            cbotipo.Enabled = valor
            cboimprimir.Enabled = valor

            tblconsulta.Enabled = Not valor

            txtcuenta.ReadOnly = If((Me.accionManteDet Is "M"), True, Not valor)
            btnhelp_1.Enabled = If((Me.accionManteDet Is "M"), False, valor)
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Sub cargarDatosDet(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                Norden = CType(filaactiva("cct01ord").ToString, Integer)
                txtcuenta.Text = filaactiva("cct01cta").ToString
                txtdescripcion.Text = filaactiva("cct01des").ToString
                cbotipo.Text = filaactiva("cct01tip").ToString
                cboimprimir.Text = filaactiva("cct01imp").ToString
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

            Select Case index
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
                Case 1
                    txtcuenta.Text = tblhelp.Columns("ccm01cta").Value.ToString
                    txtdescripcion.Text = tblhelp.Columns("ccm01des").Value.ToString
                    txtdescripcion.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub refrescarGrilla()
        Me.TraeEstadoggypp(tipoeegyp)
    End Sub

#End Region



    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Me.TraerAyuda(1, btnhelp_1)
    End Sub


    Private Sub Frm_EEGGyPP_Conf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializo mi formulario desde donde se cargo 

        Try
            Me.inicioControlesDiseno()
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)

            Me.Text = "Configurar Estado de Ganancias y Perdidas"
            '
            frmOrigen = CType(Me.Owner, Frm_EEGGyPP)
            '
            tipoeegyp = ""

            Me.TraeEstadoggypp(tipoeegyp)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
            a = objSql.Ejecutar2("Spu_Con_Del_ccd03astip", gbcodempresa, "", campoorden, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                'Me.tblconsulta_RowColChange()
            Else
                'No hago nada
            End If
        Catch ex As Exception
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
        Me.capturarfilaactual()
    End Sub
    Sub CargaDetalleAsiTipo()

    End Sub

    Private Sub lnkcancelar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkcancelar.LinkClicked
        'Cargar la fila actual
        Me.CargaDetalleAsiTipo()
        Me.tblconsulta_RowColChange(Nothing, Nothing)
        Me.HabilitarMantenimientoDet(False)
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

            If cbotipo.Text = "" Then Beep() : MessageBox.Show(gbc_MensajeError + "Cargo Abono no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : cbotipo.Focus() : Exit Sub

            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            'El valor 001 y 01 son fijos

            If accionManteDet = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Detalle_Asi_Tipo", gbcodempresa, gbano, "".Trim, 0, txtcuenta.Text.Trim, cbotipo.Text, cboimprimir.Text, "S", "N", "", txtdescripcion.Text.Trim, "")
            ElseIf accionManteDet = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Detalle_Asi_Tipo", gbcodempresa, gbano, "", CType(Norden, Integer), txtcuenta.Text.Trim, cbotipo.Text, cboimprimir.Text, "S", "N", "", txtdescripcion.Text.Trim, "")
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
                        b = objSql.Ejecutar2("Spu_Con_Upd_Nordenccd03astip", gbcodempresa, gbano, "", posicion_Insercion, Norden_Final)
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
            Norden_Final = CType(TraeMaxOrden(tipoeegyp), Integer)
            If Norden_Final = 0 Then
                MessageBox.Show("ERROR ::No existen registros", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                insertar = False
            End If

        Catch ex As Exception
            insertar = False
        End Try
    End Sub



    Private Sub cbocargoabono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbotipo.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub cbocargoabono_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotipo.SelectedIndexChanged

    End Sub

    Private Sub cbocolumna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboimprimir.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub cbocolumna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboimprimir.SelectedIndexChanged

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

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub GbxDetalle_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GbxDetalle.Enter

    End Sub
End Class