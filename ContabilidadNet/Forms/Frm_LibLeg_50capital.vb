Option Strict On
Option Explicit On
Public Class Frm_LibLeg_50capital

#Region "DECLARACIONES"
    Dim registroactivocabecera As DataRow
    Private accionMante As String
    Private accionManteDet As String
    Private insertar As Boolean
    Private posicion_Insercion As Integer
    Private Norden_Final As Integer
    Private Norden As Integer

    Dim VistaHelp As DataView
    Dim VistaCab As DataTable
    Dim Vista As DataView

    Dim frmOrigen As Frm_AsientoTipo
    Dim nombredeobjeto As String = "Distribucion de Costos"
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim correlativo As Integer
    Dim CorrelativoDet As Integer
    Dim tipoanalisis As String

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
    Sub TraerDetalle()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_lc51capitalDet", gbcodempresa, gbano, gbmes).DefaultView
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

    Sub TraeEstructuraCab()
        Try
            VistaCab = objSql.TraerDataTable("Spu_Con_Trae_lc50capital", gbcodempresa, gbano, gbmes)

            If VistaCab.Rows.Count = 0 Then
                Return
            End If

            registroactivocabecera = VistaCab.Rows(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeCta(ByVal cta As String)
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Help_ccm01ctalc50", gbcodempresa, gbano, cta, "", "").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeCtaCte(ByVal tipoanalisis As String)
        Try
            tblhelp.SetDataBinding(Mod_BaseDatos.TraeCtaCte(gbcodempresa, tipoanalisis), Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub Traeimportacion()
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Trae_PerAntlc50capital", gbcodempresa).DefaultView
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
    Sub cargarDatos(ByVal filaactiva As DataRow)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                correlativo = CInt(filaactiva("lc50Correlativo").ToString)
                txtlc50capitalsocial.Text = filaactiva("lc50capitalsocial").ToString
                TraeDameDescripcion(0)
                txtlc50ValorNominal.Text = filaactiva("lc50ValorNominal").ToString
                txtlc50numaccsuscritas.Text = filaactiva("lc50numaccsuscritas").ToString
                txtlc50numaccpagadas.Text = filaactiva("lc50numaccpagadas").ToString
                txtlc50numaccosocios.Text = filaactiva("lc50numaccosocios").ToString
                '
                Me.TraerDetalle()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            txtlc50capitalsocial.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub NuevoDet()
        Try
            Me.accionManteDet = "N"
            Me.HabilitarMantenimientoDet(True)
            LimpiarControlesDet()
            txtlc50Cuenta.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesDet()
        Try
            txtlc50tipdoc.Text = ""
            txtlc50NumeroIdentidad.Text = ""
            txtlc50RazonSocial.Text = ""
            txtlc50TipodeAccion.Text = ""
            txtlc50Cuenta.Text = ""
            txtlc50NumAcciones.Text = "0.00"
            txtlc50Porcentaje.Text = "0.00"
            lblhelp_1.Text = ""
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
            If tblconsulta.Rows.Count > 0 Then
                MessageBox.Show("ERROR:: No se puede Eliminar el registro porque tiene un detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return

            End If
            If MessageBox.Show("¿ Estás Seguro de Eliminar : " & txtlc50Cuenta.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            a = objSql.Ejecutar2("Spu_Con_Del_lc50capital", gbcodempresa, gbano, gbmes, CorrelativoDet, "")
            Funciones.Funciones.MensajesdelSQl(a)
            cargarDatos(registroactivocabecera)
        Catch ex As Exception
        End Try
    End Sub
    Sub eliminarDet()
        Try
            Beep()
            If MessageBox.Show("¿ Estás Seguro de Eliminar el Detalle : " & txtlc50Cuenta.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim campoorden As Integer
            campoorden = CType(FilaDeTabla("lc51CorrelativoDet").ToString, Integer)

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_lc51capitalDet", gbcodempresa, gbano, gbmes, correlativo, CorrelativoDet)
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

            'Perosnalizar habilitacion
            btnnuevo.Visible = Not valor
            btnmodificar.Visible = Not valor
            btneliminar.Visible = Not valor
            btnsalir.Visible = Not valor
            btnimportar.Visible = Not valor
            'Otros Controles
            'Bloque controles de segumiento
            tblconsulta.Enabled = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor
            '
            btnhelp_0.Enabled = valor
            txtlc50capitalsocial.ReadOnly = Not valor
            txtlc50NumAcciones.ReadOnly = Not valor
            txtlc50ValorNominal.ReadOnly = Not valor
            txtlc50numaccosocios.ReadOnly = Not valor
            txtlc50numaccpagadas.ReadOnly = Not valor
            txtlc50numaccsuscritas.ReadOnly = Not valor
            'Deshabilito 
            GbxDetalle.Enabled = Not valor

        Catch ex As Exception
        End Try
    End Sub
    Sub DeshabilitarCabecera(ByVal valor As Boolean)
        Try
            'Perosnalizar habilitacion
            btnnuevo.Visible = valor
            btnmodificar.Visible = valor
            btneliminar.Visible = valor
            btnimportar.Visible = valor
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
            txtlc50NumeroIdentidad.ReadOnly = Not valor
            txtlc50tipdoc.ReadOnly = Not valor
            txtlc50RazonSocial.ReadOnly = Not valor
            btnhelp_1.Enabled = valor
            txtlc50TipodeAccion.ReadOnly = Not valor
            txtlc50NumAcciones.ReadOnly = Not valor
            txtlc50Porcentaje.ReadOnly = Not valor
            txtlc50Cuenta.ReadOnly = Not valor
            btnhelp_2.Enabled = valor
            'Grilla del detalle
            tblconsulta.Enabled = Not valor

            '==
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
                CorrelativoDet = CInt(filaactiva("lc51CorrelativoDet").ToString)
                txtlc50tipdoc.Text = filaactiva("lc51TipDocIdentidad").ToString
                txtlc50NumeroIdentidad.Text = filaactiva("lc51NumeroIdentidad").ToString
                txtlc50TipodeAccion.Text = filaactiva("lc51TipodeAccion").ToString
                txtlc50RazonSocial.Text = filaactiva("lc51RazonSocial").ToString
                txtlc50NumAcciones.Text = filaactiva("lc51NumAcciones").ToString
                txtlc50Porcentaje.Text = filaactiva("lc51Porcentaje").ToString
                txtlc50Cuenta.Text = filaactiva("lc51Cuenta").ToString
                TraeDameDescripcion(1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtlc50Cuenta.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + Trim(txtlc50capitalsocial.Text), "CT")
                    End If
                Case 1
                    If txtlc50Cuenta.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(gbano + txtlc50Cuenta.Text.Trim, "CT")
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtlc50Cuenta.Text.Trim, "CT")
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

            Dim columna2 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna2 = tblhelp.Columns(2)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraeCta("50")
                Case 1
                    tblhelp.Columns(0).DataField = "ccm02cod"
                    tblhelp.Columns(1).DataField = "ccm02nom"
                    tblhelp.Columns(2).DataField = "ccm02tipdocidentidad"
                    Me.TraeCtaCte(tipoanalisis)
                Case 2
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    Me.TraeCta("50")
                Case 3
                    tblhelp.Columns(0).DataField = "lc50Anio"
                    tblhelp.Columns(1).DataField = "lc50Mes"
                    Me.Traeimportacion()
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
                    txtlc50capitalsocial.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                    txtlc50capitalsocial.Focus()
                Case 1
                    txtlc50NumeroIdentidad.Text = tblhelp_p.Columns("ccm02cod").Value.ToString
                    txtlc50RazonSocial.Text = tblhelp_p.Columns("ccm02nom").Value.ToString
                    txtlc50tipdoc.Text = tblhelp_p.Columns("ccm02tipdocidentidad").Value.ToString
                    txtlc50TipodeAccion.Focus()
                Case 2
                    txtlc50Cuenta.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                    lblhelp_1.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                    txtlc50Cuenta.Focus()
                Case 3
                    Dim anioanterior As String
                    Dim mesanterior As String
                    anioanterior = tblhelp_p.Columns("lc50Anio").Value.ToString
                    mesanterior = tblhelp_p.Columns("lc50Mes").Value.ToString

                    If MessageBox.Show("¿Esta Seguro de importar datos del año : " & anioanterior, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
                        Cursor.Current = Cursors.WaitCursor

                        a = objSql.Ejecutar2("Spu_Con_Ins_PerAntlc50capital", gbcodempresa, gbano, gbmes, anioanterior, mesanterior, "")
                        Funciones.Funciones.MensajesdelSQl(a)
                        Cursor.Current = Cursors.Default
                        Me.refrescarGrilla()
                    End If

            End Select

            tblhelp_p.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub refrescarGrilla()
        TraerDetalle()
    End Sub

#End Region

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        'Cargar la fila actual
        cargarDatos(registroactivocabecera)
        'Poner en modo ver
        Me.HabilitarMantenimiento(False)

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
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then MsgBox("ERROR :: Cuenta No Valida ", vbCritical, "Error de Usuario") : Exit Sub
            'Validar importes
            If Funciones.Funciones.Esnumeromayoracero(txtlc50numaccosocios.Text) = False Then MessageBox.Show("Cantidad No Valido") : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(txtlc50numaccpagadas.Text) = False Then MessageBox.Show("Cantidad No Valido") : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(txtlc50numaccsuscritas.Text) = False Then MessageBox.Show("Cantidad No Valido") : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(txtlc50ValorNominal.Text) = False Then MessageBox.Show("Importe No Valido") : Exit Sub


            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            'El valor 001 y 01 son fijos
            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                a = objSql.Ejecutar2("Spu_Con_Ins_lc50capital", gbcodempresa, gbano, gbmes, correlativo, txtlc50capitalsocial.Text, CDbl(txtlc50ValorNominal.Text), CDbl(txtlc50numaccsuscritas.Text), CDbl(txtlc50numaccpagadas.Text), CDbl(txtlc50numaccosocios.Text).ToString, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("Spu_Con_Upd_lc50capital", gbcodempresa, gbano, gbmes, CorrelativoDet, txtlc50capitalsocial.Text, CDbl(txtlc50ValorNominal.Text), CDbl(txtlc50numaccsuscritas.Text), CDbl(txtlc50numaccpagadas.Text), CDbl(txtlc50numaccosocios.Text).ToString, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            '=======
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.HabilitarMantenimiento(False)
            End If

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Frm_LibLeg_50capital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)

            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            ' Me.Text = "Registrar documentos de venta por donaciones"
            '
            Me.Text = Frm_LibrosLegales.rbtrepauxiliares_16.Text
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btnimportar, "Importar configuracion de otro periodo")

            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            '
            tipoanalisis = "06"
            'Traer y llenar datos de cabecera
            Me.TraeEstructuraCab()
            Me.cargarDatos(registroactivocabecera)
            Me.TraerDetalle()
            'Poner en false
            HabilitarMantenimiento(False)
            HabilitarMantenimientoDet(False)
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            If MessageBox.Show("¿ Estás Seguro de Eliminar el Detalle : " & txtlc50Cuenta.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim campoorden As Integer
            campoorden = CType(FilaDeTabla("lc51CorrelativoDet").ToString, Integer)

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_lc51capitalDet", gbcodempresa, gbano, gbmes, correlativo, CorrelativoDet, "")
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
            TraerDatosCab()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TraerDatosCab()
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            VistaHelp = objSql.TraerDataTable("Spu_Con_Trae_lc50capitalDet_Fill", gbcodempresa, gbano, gbmes, CorrelativoDet).DefaultView
            If VistaHelp.Count = 0 Then
                Return
            End If
            txtlc50capitalsocial.Text = VistaHelp(0)("lc50capitalsocial").ToString()
            txtlc50ValorNominal.Text = VistaHelp(0)("lc50ValorNominal").ToString()
            txtlc50numaccsuscritas.Text = VistaHelp(0)("lc50numaccsuscritas").ToString()
            txtlc50numaccpagadas.Text = VistaHelp(0)("lc50numaccpagadas").ToString()
            txtlc50numaccosocios.Text = VistaHelp(0)("lc50numaccosocios").ToString()
            TraeDameDescripcion(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub lnkcancelar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkcancelar.LinkClicked
        'Cargar la fila actual
        Me.TraerDetalle()
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
            'Validacion
            If (lblhelp_1.Text = "" Or lblhelp_1.Text = "???") Then MessageBox.Show("ERROR :: Cuenta No Valido ") : Exit Sub
            If (txtlc50RazonSocial.Text = "" Or txtlc50RazonSocial.Text = "???") Then MessageBox.Show("ERROR :: Documento de Identidad No Valido ") : Exit Sub

            'Validar importes
            If Funciones.Funciones.Esnumeromayoracero(txtlc50NumAcciones.Text) = False Then MessageBox.Show("Numero de Acciones No Valida") : Exit Sub
            If Funciones.Funciones.Esnumeromayoracero(txtlc50Porcentaje.Text) = False Then MessageBox.Show("Numero No Valido") : Exit Sub

            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            '===
            If accionManteDet = "N" Then
                a = objSql.Ejecutar2("Spu_Con_Ins_lc51capitalDet", gbcodempresa, gbano, gbmes, correlativo, CorrelativoDet, txtlc50tipdoc.Text, txtlc50NumeroIdentidad.Text, txtlc50RazonSocial.Text, _
                                                                    txtlc50TipodeAccion.Text, CDbl(txtlc50NumAcciones.Text), CDbl(txtlc50Porcentaje.Text), txtlc50Cuenta.Text, "")
            ElseIf accionManteDet = "M" Then
                a = objSql.Ejecutar2("Spu_Con_Upd_lc51capitalDet", gbcodempresa, gbano, gbmes, correlativo, CorrelativoDet, txtlc50tipdoc.Text, txtlc50NumeroIdentidad.Text, txtlc50RazonSocial.Text, _
                                                                    txtlc50TipodeAccion.Text, CDbl(txtlc50NumAcciones.Text), CDbl(txtlc50Porcentaje.Text), txtlc50Cuenta.Text, "")
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
    Private Sub txtcuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlc50Cuenta.KeyDown
        Me.TraerAyuda(1, btnhelp_2)
    End Sub

    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlc50Cuenta.LostFocus
        Me.TraeDameDescripcion(1)
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
    Private Sub btnimportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimportar.Click
        Me.TraerAyuda(3, btnimportar)
    End Sub
    Private Sub btnhelp_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_2.Click
        Me.TraerAyuda(2, btnhelp_2)
    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

    End Sub


    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class