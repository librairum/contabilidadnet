Option Strict On
Option Explicit On
Public Class Frm_Distribucion_Abc

#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Private accionManteDet As String

    Dim VistaHelp As DataView
    Dim Vista As DataView
    Dim frmOrigen As Frm_Distribucion
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
    Sub TraeLibros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
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

    Sub MostrarDetalleDistribucion()
        Try
            Me.capturarfilaactual()
            Me.cargarDatosDet(FilaDeTabla)
        Catch ex As Exception
        End Try
    End Sub

    Sub CargaDetalleDistribucion()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_cdiDetalle", gbcodempresa, gbano, gbmes, txtctaorigen.Text).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '
            MostrarDetalleDistribucion()
            txttotalporcentaje.Text = DameDescripcion(gbano + gbmes + txtctaorigen.Text.Trim, "SUMTIPNIVG")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeplanctaDistri()
        Try
            VistaHelp = objSql.TraerDataTable("Sp_Con_Trae_Plan_CuentasDistriBucion", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
            'me.Traetotaldevoucher()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeNivelDistri()
        Try
            VistaHelp = objSql.TraerDataTable("Sp_Con_Trae_cdCn01TipoNivel", gbcodempresa, gbano, "", "").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
            'me.Traetotaldevoucher()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeMaestroMaquinas()

        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Trae_ccmmaquinas", gbcodempresa, gbano, "", "").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
            'me.Traetotaldevoucher()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeGlo01tablas(ByVal tabla As String)
        Try
            VistaHelp = objSql.TraerDataTable("Sp_Glo_Trae_glo01tablas", tabla, "GLO", "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
            'me.Traetotaldevoucher()
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
            txtctaorigen.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub NuevoDet()
        Try
            Me.accionManteDet = "N"
            Me.HabilitarMantenimientoDet(True)
            LimpiarControlesDet()
            txtctadestino.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesDet()
        Try
            txtctadestino.Text = ""
            lblhelp_5.Text = ""
            txtporcentaje.Text = "0.00"
            txttipo.Text = ""
            lblhelp_6.Text = ""
            txtcorrelativo.Text = "0"
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
            If MessageBox.Show("¿ Estás Seguro de Eliminar la Cuenta : " & txtctaorigen.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_cdiCabecera", gbcodempresa, gbano, "", txtctaorigen.Text.Trim, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
            Else
                'No hago nada
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub eliminarDet()
        Try
            Beep()
            If MessageBox.Show("¿ Estás Seguro de Eliminar la Cuenta : " & txtctaorigen.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_cdiDetalle", gbcodempresa, gbano, gbmes, txtctaorigen.Text.Trim, txtcorrelativo.Text, txtctadestino.Text.Trim, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
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
            txtctaorigen.ReadOnly = valor
            btnhelp_0.Enabled = valor
            txtprioridad.ReadOnly = valor
            btnhelp_1.Enabled = valor
            txtctatransito.ReadOnly = valor
            btnhelp_2.Enabled = valor
            txtcodmaquina.ReadOnly = valor
            btnhelp_3.Enabled = valor
            txttiponivelgasto.ReadOnly = valor
            btnhelp_4.Enabled = valor

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
            'Otros Controles

            tblconsulta.Enabled = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
            txtctaorigen.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
            btnhelp_0.Enabled = If((Me.accionMante Is "M"), False, valor)

            'Deshabilito 
            GbxDetalle.Enabled = Not valor
        Catch ex As Exception
        End Try
    End Sub
    Sub DeshabilitarCabecera(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            txtctaorigen.ReadOnly = True
            btnhelp_0.Enabled = False
            txtprioridad.ReadOnly = True
            btnhelp_1.Enabled = False
            txtctatransito.ReadOnly = True
            btnhelp_2.Enabled = False
            txtcodmaquina.ReadOnly = True
            btnhelp_3.Enabled = False
            txttiponivelgasto.ReadOnly = True
            btnhelp_4.Enabled = False

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
            '
            lnkgrabar.Visible = valor
            lnkcancelar.Visible = valor

            'los campos que no deben modificar, 
            'LLamar a la habiltacion gloabl
            txtporcentaje.ReadOnly = Not valor
            txttipo.ReadOnly = Not valor
            lblhelp_6.Enabled = valor
            txtcorrelativo.ReadOnly = Not valor

            tblconsulta.Enabled = Not valor

            txtctadestino.ReadOnly = If((Me.accionManteDet Is "M"), True, Not valor)
            btnhelp_5.Enabled = If((Me.accionManteDet Is "M"), False, valor)
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
                txtctaorigen.Text = filaactiva("cdicCtaOrigen").ToString
                TraeDameDescripcion(0)
                Me.TraeDameDescripcion(0)

                txtprioridad.Text = filaactiva("cdicprioridad").ToString
                Me.TraeDameDescripcion(1)

                txtctatransito.Text = filaactiva("cdicCtaTransito").ToString
                Me.TraeDameDescripcion(2)

                txtcodmaquina.Text = filaactiva("cdicCodMaquina").ToString
                Me.TraeDameDescripcion(3)

                txttiponivelgasto.Text = filaactiva("cdictiponivelgasto").ToString
                Me.TraeDameDescripcion(4)

                '
                Me.CargaDetalleDistribucion()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub cargarDatosDet(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtctadestino.Text = filaactiva("cdidCtaDestino").ToString
                Me.TraeDameDescripcion(5)
                txtporcentaje.Text = filaactiva("cdidPorcentaje").ToString
                txttipo.Text = filaactiva("cdidtipo").ToString
                Me.TraeDameDescripcion(6)
                txtcorrelativo.Text = filaactiva("cdidcodigo").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtctaorigen.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtctaorigen.Text, "CT")
                    End If
                Case 1
                    If txtprioridad.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion("10" + txtprioridad.Text, "GL")
                    End If
                Case 2
                    If txtctatransito.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = Mod_BaseDatos.DameDescripcion(gbano + txtctatransito.Text.Trim, "CT")
                    End If
                Case 3
                    If txtcodmaquina.Text = "" Then
                        lblhelp_3.Text = ""
                    Else
                        lblhelp_3.Text = Mod_BaseDatos.DameDescripcion(gbano + txtcodmaquina.Text.Trim, "CODMAQ")
                    End If
                Case 4
                    If txttiponivelgasto.Text = "" Then
                        lblhelp_4.Text = ""
                    Else
                        lblhelp_4.Text = Mod_BaseDatos.DameDescripcion(gbano + txttiponivelgasto.Text, "TIPNIVG")
                    End If
                Case 5
                    If txtctadestino.Text = "" Then
                        lblhelp_5.Text = ""
                    Else
                        lblhelp_5.Text = Mod_BaseDatos.DameDescripcion(gbano + txtctadestino.Text, "CT")
                    End If
                Case 6
                    If txttipo.Text = "" Then
                        lblhelp_6.Text = ""
                    Else
                        lblhelp_6.Text = Mod_BaseDatos.DameDescripcion("11" + txttipo.Text, "GL")
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
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraeplanctaDistri()
                Case 1
                    tblhelp.Columns(0).DataField = "glo01codigo"
                    tblhelp.Columns(1).DataField = "glo01descripcion"
                    Me.TraeGlo01tablas("10")
                Case 2
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraeplanctaDistri()
                Case 3
                    tblhelp.Columns(1).DataField = "ccmmdescripcion"
                    tblhelp.Columns(0).DataField = "ccmmcodigo"
                    Me.TraeMaestroMaquinas()
                Case 4
                    tblhelp.Columns(0).DataField = "cdcn01tipo"
                    tblhelp.Columns(1).DataField = "cdcn01Descripcion"
                    Me.TraeNivelDistri()
                Case 5
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraeplanctaDistri()
                Case 6
                    tblhelp.Columns(0).DataField = "glo01codigo"
                    tblhelp.Columns(1).DataField = "glo01descripcion"
                    Me.TraeGlo01tablas("11")
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
                    txtctaorigen.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                    txtctaorigen.Focus()
                Case 1
                    txtprioridad.Text = tblhelp.Columns("glo01codigo").Value.ToString
                    lblhelp_1.Text = tblhelp.Columns("glo01descripcion").Value.ToString
                    txtprioridad.Focus()
                Case 2
                    txtctatransito.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                    lblhelp_2.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                    txtctatransito.Focus()
                Case 3
                    txtcodmaquina.Text = tblhelp_p.Columns("ccmmcodigo").Value.ToString
                    lblhelp_3.Text = tblhelp_p.Columns("ccmmdescripcion").Value.ToString
                    txtcodmaquina.Focus()
                Case 4
                    txttiponivelgasto.Text = tblhelp_p.Columns("cdcn01tipo").Value.ToString
                    lblhelp_4.Text = tblhelp_p.Columns("cdcn01Descripcion").Value.ToString
                    txttiponivelgasto.Focus()
                Case 5
                    txtctadestino.Text = tblhelp.Columns("ccm01cta").Value.ToString
                    lblhelp_5.Text = tblhelp.Columns("ccm01des").Value.ToString
                    txtctadestino.Focus()
                Case 6
                    txttipo.Text = tblhelp_p.Columns("glo01codigo").Value.ToString
                    lblhelp_6.Text = tblhelp_p.Columns("glo01descripcion").Value.ToString
                    txttipo.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub refrescarGrilla()
        CargaDetalleDistribucion()
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
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'Valido libro
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Código Errado De la Cuenta A distribuirse", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtctaorigen.Focus() : Exit Sub
            If (lblhelp_1.Text = "" Or lblhelp_1.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Código De Prioridad Errado", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtprioridad.Focus() : Exit Sub
            If (lblhelp_2.Text = "" Or lblhelp_2.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Código de Cuenta a Saldar Errado", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtctatransito.Focus() : Exit Sub

            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            'El valor 001 y 01 son fijos
            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                a = objSql.Ejecutar2("Spu_Con_Ins_cdiCabecera", gbcodempresa, gbano, "001", txtctaorigen.Text, txtctatransito.Text, CType(txtctaorigen.Text.Trim.Length, Integer), txtcodmaquina.Text, "01", txtprioridad.Text, txttiponivelgasto.Text, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("Spu_Con_Upd_cdiCabecera", gbcodempresa, gbano, "001", txtctaorigen.Text, txtctatransito.Text, CType(txtctaorigen.Text.Trim.Length, Integer), txtcodmaquina.Text, "01", txtprioridad.Text, txttiponivelgasto.Text, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            '

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
                frmOrigen.Posicionar("cdicCtaOrigen", txtctaorigen.Text.Trim)
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

    Private Sub Frm_Distribucion_Abc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializo mi formulario desde donde se cargo 
        Try
            inicioControlesDiseno()
            frmOrigen = CType(Me.Owner, Frm_Distribucion)

            Me.Text = "Detalle de distribucion"
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

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            Mod_Mantenimiento.ocultarbotonespercerrado(Me)

            If Periodocerrado() = True Then
                lnkNuevo.Visible = False
                lnkmodificar.Visible = False
                lnkeliminar.Visible = False
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
    End Sub
    Private Sub lnkmodificar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkmodificar.LinkClicked
        Me.modificarDet()
    End Sub

    Private Sub lnkeliminar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkeliminar.LinkClicked
        Me.eliminarDetalle()
    End Sub
    Sub eliminarDetalle()
        Try
            Beep()
            If MessageBox.Show("AVISO :: Esta seguro de Eliminar el REGISTRO " & txtctadestino.Text, "ELIMINAR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionManteDet = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_cdiDetalle", gbcodempresa$, gbano$, gbmes$, txtctaorigen.Text.Trim, txtcorrelativo.Text.Trim, txtctadestino.Text.Trim, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
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
        MostrarDetalleDistribucion()
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
    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        Try
            tblhelp.Visible = False
            VistaHelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub lnkgrabar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkgrabar.LinkClicked
        Try
            'Valido libro
            If (lblhelp_5.Text = "" Or lblhelp_5.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Código Errado De la Cuenta Destino", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtctadestino.Focus() : Exit Sub
            If (lblhelp_6.Text = "" Or lblhelp_6.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Código De Prioridad Errado", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txttipo.Focus() : Exit Sub


            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            'El valor 001 y 01 son fijos

            If accionManteDet = "N" Then
                a = objSql.Ejecutar2("Spu_Con_Ins_cdiDetalle", gbcodempresa, gbano, gbmes, txtctaorigen.Text, txtcorrelativo.Text, txtctadestino.Text, CType(txtporcentaje.Text.Trim, Double), txttipo.Text, "")
            ElseIf accionManteDet = "M" Then
                a = objSql.Ejecutar2("Spu_Con_Upd_cdiDetalle", gbcodempresa, gbano, gbmes, txtctaorigen.Text, txtcorrelativo.Text, txtctadestino.Text, CType(txtporcentaje.Text.Trim, Double), txttipo.Text, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            '

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
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

    Private Sub lnkcancelar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkcancelar.LinkClicked
        'Cargar la fila actual
        Me.CargaDetalleDistribucion()
        Me.HabilitarMantenimientoDet(False)
    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

    End Sub

    Private Sub txtctaorigen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtctaorigen.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtctaorigen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaorigen.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub

    Private Sub txtctaorigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctaorigen.TextChanged

    End Sub

    Private Sub txtprioridad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtprioridad.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtprioridad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprioridad.LostFocus
        Me.TraeDameDescripcion(1)
    End Sub

    Private Sub txtprioridad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprioridad.TextChanged

    End Sub

    Private Sub txtctatransito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtctatransito.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtctatransito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctatransito.LostFocus
        Me.TraeDameDescripcion(2)
    End Sub

    Private Sub txtctatransito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctatransito.TextChanged

    End Sub

    Private Sub txtcodmaquina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodmaquina.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtcodmaquina_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodmaquina.LostFocus
        Me.TraeDameDescripcion(3)
    End Sub

    Private Sub txtcodmaquina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodmaquina.TextChanged

    End Sub

    Private Sub txttiponivelgasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttiponivelgasto.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_4_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txttiponivelgasto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttiponivelgasto.LostFocus
        Me.TraeDameDescripcion(4)
    End Sub

    Private Sub txttiponivelgasto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttiponivelgasto.TextChanged

    End Sub

    Private Sub txtctadestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtctadestino.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_5_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtctadestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctadestino.LostFocus
        Me.TraeDameDescripcion(5)
    End Sub

    Private Sub txtctadestino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctadestino.TextChanged

    End Sub

    Private Sub txttipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttipo.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_6_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txttipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo.LostFocus
        Me.TraeDameDescripcion(6)
    End Sub

    Private Sub txttipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.TextChanged

    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class