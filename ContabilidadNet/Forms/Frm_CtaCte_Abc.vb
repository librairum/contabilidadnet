Option Explicit On
Option Strict On

Public Class Frm_CtaCte_Abc

#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim VistaHelp As DataView
    Dim frmOrigen As Frm_CtaCte
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
    Sub TraeDepartamento()

        Try
            VistaHelp = objSql.TraerDataTable("Sp_Glo_Trae_Departamento", "CodigoDepartamento asc", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeProvincia(ByVal coddepartamento As String)
       
        Try
            VistaHelp = objSql.TraerDataTable("Sp_Glo_Trae_Provincia", coddepartamento, "CodigoProvincia asc", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeDistrito(ByVal coddepartamento As String, ByVal codprovincia As String)
        Try
            VistaHelp = objSql.TraerDataTable("Sp_Glo_Trae_distrito", coddepartamento, codprovincia, "CodigoDistrito asc", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeFormaPago()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_FormaPago", gbcodempresa, "Co02codigo", "*").DefaultView
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
        Me.accionMante = "N"
        Me.HabilitarMantenimiento(True)
        Mod_Mantenimiento.LimpiarControles(Me)
        Me.ValoresXdefecto()
        Me.habilitaTipoPersona("J")
        'Ubicar el puntero
        txtTipoAnalisis.Focus()
    End Sub
    Sub modificar()
        Me.accionMante = "M"
        Me.HabilitarMantenimiento(True)
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
            txtcodigo.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
            txtTipoAnalisis.ReadOnly = If((Me.accionMante Is "M"), True, Not valor)
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
                'txtcodigo.Text = filaactiva("COD_ANAL").ToString & ""
                'txtApeMat.Text = filaactiva("COD_ANAL").ToString & ""
                txtTipoAnalisis.Text = filaactiva("ccm02tipana").ToString
                Me.TraeDameDescripcion(1)
                tipoanalisis = filaactiva("ccm02tipana").ToString
                txtcodigo.Text = filaactiva("ccm02cod").ToString
                txtNombre.Text = (filaactiva("ccm02nom")).ToString
                txtDireccion.Text = (filaactiva("ccm02dir")).ToString
                txttipdoc.Text = (filaactiva("ccm02tipdocidentidad")).ToString
                Me.TraeDameDescripcion(2)
                chkHabilitar.Checked = If(filaactiva("ccm02activo").ToString = "N", False, True)
                mskfecha.Text = filaactiva("ccm02fec").ToString
                txtRuc.Text = (filaactiva("ccm02ruc")).ToString
                txtTelefono.Text = filaactiva("ccm02tel").ToString
                txtfax.Text = filaactiva("ccm02Fax").ToString
                txtCorreoElectronico.Text = (filaactiva("ccm02correo")).ToString
                TxtRubro.Text = (filaactiva("ccm02rubpro")).ToString
                txtAtencion.Text = (filaactiva("ccm02Aten")).ToString
                TxtFormaPago.Text = (filaactiva("ccm02ForPag")).ToString
                Me.TraeDameDescripcion(8)
                txtsituacionsunat.Text = (filaactiva("ccm02EstadoContribuyente")).ToString
                Me.TraeDameDescripcion(6)
                txtsituaciondomicilio.Text = (filaactiva("ccm02SituacionDomicilio")).ToString
                Me.TraeDameDescripcion(7)
                txtcoddepartamento.Text = (filaactiva("ccm02coddepartamento")).ToString
                Me.TraeDameDescripcion(3)
                txtcodprovincia.Text = (filaactiva("ccm02codprovincia")).ToString
                Me.TraeDameDescripcion(4)
                txtcoddistrito.Text = (filaactiva("ccm02coddistrito")).ToString
                Me.TraeDameDescripcion(5)
                ' Se hizo por que habian cuentas correintes que no traian sus 4 flag y salia un error

                Dim flagsretencion As String = ""
                flagsretencion = filaactiva("ccm02TipoAgenteRetencion").ToString

                If flagsretencion.Trim.Length = 0 Then
                    flagsretencion = "0000"
                ElseIf flagsretencion.Trim.Length = 3 Then
                    flagsretencion = flagsretencion & "0"
                ElseIf flagsretencion.Trim.Length = 2 Then
                    flagsretencion = flagsretencion.Trim & "00"
                ElseIf flagsretencion.Trim.Length = 1 Then
                    flagsretencion = flagsretencion.Trim & "000"
                End If

                chktiposunat_0.Checked = If(flagsretencion.ToString.Substring(0, 1) = "1", True, False)
                chktiposunat_1.Checked = If(flagsretencion.ToString.Substring(1, 1) = "1", True, False)
                chktiposunat_2.Checked = If(flagsretencion.ToString.Substring(2, 1) = "1", True, False)
                chktiposunat_3.Checked = If(flagsretencion.ToString.Substring(3, 1) = "1", True, False)

                rbtipopersona_j.Checked = If(filaactiva("ccm02TipoRuc").ToString = "1", True, False)
                rbtipopersona_n.Checked = If(filaactiva("ccm02TipoRuc").ToString = "2", True, False)
                rbtipopersona_nd.Checked = If(filaactiva("ccm02TipoRuc").ToString = "3", True, False)

                rbmoneda_s.Checked = If(filaactiva("ccm02Moneda").ToString = "S", True, False)
                rbmoneda_d.Checked = If(filaactiva("ccm02Moneda").ToString = "D", True, False)

                txtNom.Text = (filaactiva("ccm02Nombres")).ToString
                txtApePat.Text = (filaactiva("ccm02ApePaterno")).ToString
                txtApeMat.Text = (filaactiva("ccm02ApeMaterno")).ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Falta ver como si sale un error salte al otro punto y no salga
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

                Case 2
                    tblhelp.Columns(0).DataField = "glo01codigo"
                    tblhelp.Columns(1).DataField = "glo01descripcion"
                    Me.TraeGlo01tablas("05")
                Case 3
                    tblhelp.Columns(0).DataField = "CodigoDepartamento"
                    tblhelp.Columns(1).DataField = "Descripcion"
                    Me.TraeDepartamento()
                Case 4
                    tblhelp.Columns(0).DataField = "CodigoProvincia"
                    tblhelp.Columns(1).DataField = "Descripcion"
                    Me.TraeProvincia(txtcoddepartamento.Text)
                Case 5
                    tblhelp.Columns(0).DataField = "CodigoDistrito"
                    tblhelp.Columns(1).DataField = "Descripcion"
                    Me.TraeDistrito(txtcoddepartamento.Text, txtcodprovincia.Text)
                Case 6
                    tblhelp.Columns(0).DataField = "glo01codigo"
                    tblhelp.Columns(1).DataField = "glo01descripcion"
                    Me.TraeGlo01tablas("07")
                Case 7
                    tblhelp.Columns(0).DataField = "glo01codigo"
                    tblhelp.Columns(1).DataField = "glo01descripcion"
                    Me.TraeGlo01tablas("08")
                Case 8
                    tblhelp.Columns(0).DataField = "Co02codigo"
                    tblhelp.Columns(1).DataField = "Co02descripcion"
                    Me.TraeFormaPago()
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
                    'Nada
                Case 2
                    txttipdoc.Text = Funciones.Funciones.derecha(tblhelp.Columns("glo01codigo").Value.ToString, 1)
                    lblhelp_2.Text = tblhelp.Columns("glo01descripcion").Value.ToString
                    txttipdoc.Focus()
                Case 3
                    txtcoddepartamento.Text = tblhelp.Columns("CodigoDepartamento").Value.ToString
                    lblhelp_3.Text = tblhelp.Columns("descripcion").Value.ToString
                    txtcodprovincia.Text = "" : lblhelp_4.Text = "???"
                    txtcoddistrito.Text = "" : lblhelp_5.Text = "???"
                    txtcoddepartamento.Focus()
                Case 4
                    txtcodprovincia.Text = tblhelp.Columns("CodigoProvincia").Value.ToString
                    lblhelp_4.Text = tblhelp.Columns("descripcion").Value.ToString
                    txtcoddistrito.Text = "" : lblhelp_5.Text = "???"
                    txtcodprovincia.Focus()
                Case 5
                    txtcoddistrito.Text = tblhelp.Columns("CodigoDistrito").Value.ToString
                    lblhelp_5.Text = tblhelp.Columns("descripcion").Value.ToString
                    txtcoddistrito.Focus()
                Case 6
                    txtsituacionsunat.Text = tblhelp.Columns("glo01codigo").Value.ToString
                    lblhelp_6.Text = tblhelp.Columns("glo01descripcion").Value.ToString
                    txtsituacionsunat.Focus()
                Case 7
                    txtsituaciondomicilio.Text = tblhelp.Columns("glo01codigo").Value.ToString
                    lblhelp_7.Text = tblhelp.Columns("glo01descripcion").Value.ToString
                    txtsituacionsunat.Focus()
                Case 8
                    TxtFormaPago.Text = tblhelp.Columns("Co02codigo").Value.ToString
                    lblhelp_8.Text = tblhelp.Columns("Co02descripcion").Value.ToString
                    btngrabar.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeDameDescripcion(ByVal indice As Integer)
        'lbldistrito.Text = DameDescripcion(Trim(txtcoddepartamento.Text) & Trim(txtcodprovincia.Text) & Trim(txtcoddistrito.Text), "DISTRI")

        Try
            Select Case indice
                Case 1
                    If txtTipoAnalisis.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(txtTipoAnalisis.Text, "TA")
                    End If
                Case 2
                    If txttipdoc.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = Mod_BaseDatos.DameDescripcion("05" & txttipdoc.Text.Trim, "GLX")
                    End If
                Case 3
                    If txtcoddepartamento.Text = "" Then
                        lblhelp_3.Text = ""
                    Else
                        lblhelp_3.Text = Mod_BaseDatos.DameDescripcion(txtcoddepartamento.Text.Trim, "DEPA").ToString
                    End If
                Case 4
                    If txtcodprovincia.Text = "" Then
                        lblhelp_4.Text = ""
                    Else
                        lblhelp_4.Text = Mod_BaseDatos.DameDescripcion(txtcoddepartamento.Text.Trim & txtcodprovincia.Text.Trim, "PROVI")
                    End If
                Case 5
                    If txtcoddistrito.Text = "" Then
                        lblhelp_5.Text = ""
                    Else
                        lblhelp_5.Text = Mod_BaseDatos.DameDescripcion(txtcoddepartamento.Text.Trim & txtcodprovincia.Text.Trim & txtcoddistrito.Text.Trim, "DISTRI")
                    End If
                Case 6
                    If txtsituacionsunat.Text = "" Then
                        lblhelp_6.Text = ""
                    Else
                        lblhelp_6.Text = Mod_BaseDatos.DameDescripcion("07" & txtsituacionsunat.Text.Trim, "GL")
                    End If
                Case 7
                    If txtsituaciondomicilio.Text = "" Then
                        lblhelp_7.Text = ""
                    Else
                        lblhelp_7.Text = Mod_BaseDatos.DameDescripcion("08" & txtsituaciondomicilio.Text.Trim, "GL")
                    End If
                Case 8
                    If TxtFormaPago.Text = "" Then
                        lblhelp_8.Text = ""
                    Else
                        lblhelp_8.Text = Mod_BaseDatos.DameDescripcion(TxtFormaPago.Text.Trim, "FO")
                    End If
            End Select

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
    Sub ValoresXdefecto()
        Try
            '
            txtTipoAnalisis.Text = frmOrigen.cboTipoAnalisi.SelectedValue.ToString
            txtsituacionsunat.Text = "01"
            Me.TraeDameDescripcion(6)
            '
            txtsituaciondomicilio.Text = "01"
            Me.TraeDameDescripcion(7)
            '
            TxtFormaPago.Text = "04"
            Me.TraeDameDescripcion(8)
            chkHabilitar.Checked = False
            rbtipopersona_j.Checked = True
            '
            rbmoneda_s.Checked = True
            mskfecha.Text = CType(Date.Today, String)

        Catch ex As Exception
            MessageBox.Show("ERROR :: No se pudo inicializar valores", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub habilitaTipoPersona(ByVal flagtipper As String)
        Try
            If (flagtipper.ToUpper = "J" Or flagtipper.ToUpper = "ND") Then
                txtNombre.Enabled = True
                txtApePat.Enabled = False
                txtApeMat.Enabled = False
                txtNom.Enabled = False
                txtNombre.Focus()
            ElseIf flagtipper.ToUpper = "N" Then
                txtNombre.Enabled = False
                txtApePat.Enabled = True
                txtApeMat.Enabled = True
                txtNom.Enabled = True
                txtApePat.Focus()
            End If
        Catch ex As Exception

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
    Private Sub btnhelp_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_8.Click
        Me.TraerAyuda(8, btnhelp_8)
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try

            If txtcodigo.Text = "" Then Beep() : MessageBox.Show("Ingrese Código de Cuenta Corriente", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtcodigo.Focus() : Exit Sub

            'If optTipoPersona(0).Value Then
            If rbtipopersona_j.Checked = True Or rbtipopersona_nd.Checked = True Then
                If txtNombre.Text = "" Then Beep() : MessageBox.Show("Ingrese Nombre de Cuenta Corriente", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNombre.Focus() : Exit Sub
            Else
                If txtApePat.Text = "" Then Beep() : MessageBox.Show("Ingrese Apellido Paterno de Cuenta Corriente", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtApePat.Focus() : Exit Sub
                If txtApeMat.Text = "" Then Beep() : MessageBox.Show("Ingrese Apellido Materno de Cuenta Corriente", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtApeMat.Focus() : Exit Sub
                If txtNom.Text = "" Then Beep() : MessageBox.Show("Ingrese Nombre de Cuenta Corriente", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNom.Focus() : Exit Sub
                txtNombre.Text = txtApePat.Text + " " + txtApeMat.Text + " " + txtNom.Text
            End If
            'Validar la fecha
            If Not IsDate(mskfecha.Text) Then
                Beep() : MessageBox.Show("Fecha no Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : mskfecha.Focus() : Exit Sub

            End If
            Dim LongitudDoc As Integer
            LongitudDoc = CType(Mod_BaseDatos.DameDescripcion("05" & txttipdoc.Text.Trim, "GLXL"), Integer)

            'Si sale 
            If LongitudDoc <> 0 Then
                If Not IsNumeric(LongitudDoc) Then MessageBox.Show("Longitud de Docuento NO Valida, Modifique en Tablas Globales", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                'Validar segun el tipo de documento
                If (Not IsNumeric(txtRuc.Text) Or Len(Trim(txtRuc.Text)) <> CInt(LongitudDoc)) Then MessageBox.Show("Numero Doc debe contener " & LongitudDoc, "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            '
            If (lblhelp_6.Text = "" Or lblhelp_6.Text = "???") Then MessageBox.Show("Estado Proveedor No valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If (lblhelp_7.Text = "" Or lblhelp_7.Text = "???") Then MessageBox.Show("Situacion Domiciliario No Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If (lblhelp_2.Text = "" Or lblhelp_2.Text = "???") Then MessageBox.Show("Tipo de Documento No Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

            Dim Moneda As String
            Dim habilitado As String
            Dim FlagReteSunat As String
            Dim tipopersona As String
            Dim tipodocu As String

            Moneda = If(rbmoneda_d.Checked = True, "D", "S")
            habilitado = If(chkHabilitar.Checked = True, "S", "N")
            FlagReteSunat = If(chktiposunat_0.Checked = True, "1", "0") + If(chktiposunat_1.Checked = True, "1", "0") + If(chktiposunat_2.Checked = True, "1", "0") + If(chktiposunat_3.Checked = True, "1", "0")
            tipopersona = If(rbtipopersona_j.Checked = True, "1", If(rbtipopersona_n.Checked = True, "2", "3"))
            tipodocu = Funciones.Funciones.derecha(txttipdoc.Text.Trim, 1)

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Cuenta_Corriente", gbcodempresa, txtTipoAnalisis.Text, txtcodigo.Text, txtNombre.Text, txtDireccion.Text _
                                    , txtTelefono.Text, mskfecha.Text, txtRuc.Text, txtfax.Text, TxtRubro.Text, txtAtencion.Text, _
                                    Moneda, TxtFormaPago.Text, habilitado, txtCorreoElectronico.Text, FlagReteSunat, tipopersona, txtApePat.Text, _
                                    txtApeMat.Text, txtNom.Text, txtsituacionsunat.Text, txtsituaciondomicilio.Text, txtcoddepartamento.Text, txtcodprovincia.Text, _
                                    txtcoddistrito.Text, txtnombrecomercial.Text, tipodocu, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Cuenta_Corriente", gbcodempresa, txtTipoAnalisis.Text, txtcodigo.Text, txtNombre.Text, txtDireccion.Text _
                                    , txtTelefono.Text, mskfecha.Text, txtRuc.Text, txtfax.Text, TxtRubro.Text, txtAtencion.Text, _
                                    Moneda, TxtFormaPago.Text, habilitado, txtCorreoElectronico.Text, FlagReteSunat, tipopersona, txtApePat.Text, _
                                    txtApeMat.Text, txtNom.Text, txtsituacionsunat.Text, txtsituaciondomicilio.Text, txtcoddepartamento.Text, txtcodprovincia.Text, _
                                    txtcoddistrito.Text, txtnombrecomercial.Text, tipodocu, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            'Armar Identificador de Fila
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
                frmOrigen.Posicionar("ccm02cod", txtcodigo.Text.Trim)
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
    Private Sub txttipdoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttipdoc.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtcoddepartamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcoddepartamento.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtcodprovincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprovincia.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_4_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtcoddistrito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcoddistrito.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_5_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtsituacionsunat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsituacionsunat.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_6_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtsituaciondomicilio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsituaciondomicilio.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_7_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtFormaPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFormaPago.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_8_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
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
    Private Sub Frm_CtaCte_Abc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializo mi formulario desde donde se cargo 
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)

            Me.Text = "Deatelle de cuentas corrientes"

            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            '
            frmOrigen = CType(Me.Owner, Frm_CtaCte)
            Me.HabilitarMantenimiento(False)

            If Me.accionMante = "N" Then
                Me.Nuevo()
            ElseIf Me.accionMante = "M" Then
                Me.cargarDatos(RegistroActivo)
                Me.modificar()
            ElseIf Me.accionMante = "V" Then
                Me.cargarDatos(RegistroActivo)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtTipoAnalisis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoAnalisis.LostFocus
        Me.TraeDameDescripcion(1)
    End Sub

    Private Sub txtcoddepartamento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcoddepartamento.LostFocus
        Me.TraeDameDescripcion(3)
    End Sub

    Private Sub txtcodprovincia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodprovincia.LostFocus
        Me.TraeDameDescripcion(4)
    End Sub

    Private Sub txtcoddistrito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcoddistrito.LostFocus
        Me.TraeDameDescripcion(5)
    End Sub

    Private Sub rbtipopersona_j_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtipopersona_j.CheckedChanged
        Me.habilitaTipoPersona("J")
    End Sub

    Private Sub rbtipopersona_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtipopersona_n.CheckedChanged
        Me.habilitaTipoPersona("N")
    End Sub

    Private Sub txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodigo.TextChanged
        txtRuc.Text = txtcodigo.Text
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Me.eliminar()
    End Sub
    Private Sub eliminar()
        '
        Dim codigo As String
        Dim TipoAnalisis As String

        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
        Try

            codigo = txtcodigo.Text.Trim
            TipoAnalisis = txtTipoAnalisis.Text.Trim

            If MessageBox.Show("¿ Está seguro de Eliminar ? : " & codigo, "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("sp_Con_Del_Cuenta_Corriente", gbcodempresa, TipoAnalisis, codigo, "")

            'Armar Identificador de Fila
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                frmOrigen.refrescarGrilla()
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

    Private Sub TxtFormaPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFormaPago.TextChanged

    End Sub

    Private Sub txtcoddepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcoddepartamento.TextChanged

    End Sub

    Private Sub txtcodprovincia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodprovincia.TextChanged

    End Sub

    Private Sub rbtipopersona_nd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtipopersona_nd.CheckedChanged
        Me.habilitaTipoPersona("ND")
    End Sub
End Class