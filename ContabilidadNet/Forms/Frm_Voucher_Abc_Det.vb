Option Explicit On
Option Strict On
Imports Funciones.Funciones
Public Class Frm_Voucher_Abc_Det
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Dim correlativo As Integer
    Private accionMante As String
    Dim VistaHelp As DataView
    Dim frmOrigen As Frm_Voucher_Abc
    Dim cOldCuenta As String
    Dim tipoctacte As String
    Dim tipoctaorigenodetino As String
    '
    Dim libro As String
    Dim nrovoucher As String

    'Variables para los ultimos valores
    Dim uv_Concepto As String
    Dim uv_comprobante As String
    Dim uv_CtaCte As String
    Dim uv_moneda As String
    Dim uv_TipDoc As String
    Dim uv_NoDoc As String
    Dim uv_mskFecDoc As String
    '
    Dim uv_TipDocMod As String
    Dim uv_NoDocMod As String
    Dim uv_mskFecDocMod As String
    '==
    Dim uv_txtAfectoRetencion As String
    Dim uv_txtTipoTransaccion As String
    Dim uv_lblhelp_7 As String
    Dim uv_txtNroRetencion As String
    Dim uv_mskFechaRetencion As String
    Dim uv_mskFechaPagoRetencion As String
    Dim uv_txtTipoDocRet As String
    Dim uv_lblhelp_8 As String

    'Para la insercion
    Dim Insertar As Boolean
    Dim posicion_Insercion As Integer
    Dim Norden_Final As Integer

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
    Sub trae_centros_de_gestion()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_CenGes_Tipo_SoloMo", gbcodempresa, "*", "*", "").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub trae_ctacte(ByVal tipoanalisis As String)
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_CtaCte_Por_Tipo", gbcodempresa, "*", "*", tipoanalisis).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub trae_documentos_pendientes(ByVal cuenta As String, ByVal ctacte As String, ByVal fecdoc As String)
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Docum_Pendientes", gbcodempresa, cuenta, ctacte, fecdoc, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub trae_DocXCtaCteyCtaCble(ByVal cuenta As String, ByVal ctacteana As String, ByVal ctactenum As String)
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Trae_DocXCtaCteyCtaCble", gbcodempresa, gbano, cuenta, ctacteana, ctactenum).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub trae_centrodecostos()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_CenCos_SoloMov", gbcodempresa, "*", "*", gbano).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub traetipodoc(ByVal campo As String, ByVal filtro As String)
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Tipos_Documentos", gbcodempresa, "*", "*").DefaultView
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

    Sub traeAmarre(ByVal codigo As String)
        Try
            'Se pasa la longitud a 2 de la 61 segun la srma lola
            VistaHelp = objSql.TraerDataTable("Spu_Con_Trae_Ctaselamarrae", gbcodempresa, gbano, codigo, 2).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traecuenta_1(ByVal query As String)
        Try
            VistaHelp = objSql.TraerDataTable(query, gbcodempresa, gbano, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeTipoTransaccion()
        Try
            VistaHelp = objSql.TraerDataTable("Sp_Con_Help_Transaccion", gbcodempresa, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeMaquinas()
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Help_ccmmaquinas", gbcodempresa, gbano).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeTrabajosescurso()
        Try
            VistaHelp = objSql.TraerDataTable("Spu_Con_Help_cc25trabajosencurso", gbcodempresa, gbano).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeTiposdeDocumentos()
        ' Abro y asigno los valores del Data Control de Tipos de Documentos
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Tipos_Documentos", gbcodempresa, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function DameNroOrdenFinal(ByVal ccd01emp As String, ByVal ccd01ano As String, ByVal ccd01mes As String, ByVal ccd01subd As String, ByVal ccd01numer As String) As Integer
        DameNroOrdenFinal = 0
        Try
            DameNroOrdenFinal = CType(objSql.TraerValor("Spu_Con_Trae_NordenFinal", ccd01emp, ccd01ano, ccd01mes, ccd01subd, ccd01numer, 0), Integer)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
#End Region

#Region "Metodos de Mantenimiento"
    Sub Nuevo()
        Me.accionMante = "N"
        Me.HabilitarMantenimiento(True)
        LimpiarControlesf()

        'Valores por defecto
        cbomoneda.Text = "S" ' Por defecto la mioneda es soles
        mskFecDoc.Text = frmOrigen.mskfecha.Text
        txtConcepto.Text = frmOrigen.txtDescri.Text
        mskFechaRetencion.Text = mskFecDoc.Text  'Por defecto toma la fehca de voucher
        mskFechaPagoRetencion.Text = mskFecDoc.Text  'Por defecto toma la fehca de voucher

        txtTipCambio.Text = "1.0000" 'Por defecto el tipo de cambio es 1
        txtCuenta.Focus()
        ''
    End Sub
    Sub modificar()
        Try
            'Si la cuenta tiene amarra no se puede modificar
            If tipoctaorigenodetino = "D" Then
                Beep() : MessageBox.Show("Cuenta No se puede Modificar; debe modificar el Origen de la Cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            txtDebe_0.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Sub inhabilitarretencion()
        txtAfectoRetencion.Text = "N"
        txtAfectoRetencion.Text = ""
        txtAfectoRetencion.Enabled = False
        txtTipoTransaccion.Text = ""
        txtTipoTransaccion.Enabled = False
        btnhelp_7.Text = ""
        btnhelp_7.Enabled = False
        txtNroRetencion.Text = ""
        txtNroRetencion.Enabled = False
        mskFechaRetencion.Text = ""
        mskFechaRetencion.Enabled = False
        mskFechaPagoRetencion.Text = ""
        mskFechaPagoRetencion.Enabled = False
        txtTipoDocRet.Text = ""
        txtTipoDocRet.Enabled = False
        btnhelp_8.Text = ""
        btnhelp_8.Enabled = False
    End Sub
    Sub habilitarretencion(ByVal xlibro As String, ByVal tipodoc As String)
        Dim xTDRet As String
        Try
            'Todo lo inhabilito
            Me.inhabilitarretencion()
            'Si cumple que es del libro y ademas que no es agente y tipo de documento es afecto
            If xlibro = "B" Or xlibro = "O" Then
                If Mod_BaseDatos.EsProveedoraRetener(tipoctacte, txtCtaCte.Text) = True Then
                    'Verifica s el tipo de documento es afecto a retencion
                    xTDRet = Mod_BaseDatos.DameDescripcion(tipodoc, "T2")
                    If xTDRet = "S" Then
                        txtAfectoRetencion.Enabled = True
                        txtAfectoRetencion.Text = "S"
                        txtTipoTransaccion.Enabled = True
                        txtTipoTransaccion.Text = "01"
                        txtTipoDocRet.Enabled = True
                        txtTipoDocRet.Text = "20"
                        btnhelp_8.Enabled = True
                        btnhelp_7.Enabled = True

                        txtNroRetencion.Enabled = True
                        txtNroRetencion.Text = uv_txtNroRetencion
                        'Leasigno el valor anterior
                        mskFechaRetencion.Enabled = True
                        mskFechaRetencion.Text = mskFecDoc.Text
                        mskFechaPagoRetencion.Enabled = True
                        mskFechaPagoRetencion.Text = mskFecDoc.Text
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            Mod_Mantenimiento.HabyDesControles(Me, valor)
            'Perosnalizar habilitacion
            btnnuevo.Visible = Not valor
            btninsertar.Visible = Not valor
            btnmodificar.Visible = Not valor
            btneliminar.Visible = Not valor
            btnsalir.Visible = Not valor
            btnprimero.Visible = Not valor
            btnanterior.Visible = Not valor
            btnsiguiente.Visible = Not valor
            btnultimo.Visible = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor
            '
            'Cargar variables globales
            Me.Muestroopcionxcuenta()
            'los campos que no deben modificar, 
            txtCuenta.ReadOnly = If((Me.accionMante = "M"), True, Not valor)

        Catch ex As Exception
        End Try
    End Sub
    Sub inicializaValores()
        'Oculto las opciones configurables por cuenta
        Me.ocultoopcionxcuenta()
    End Sub
    Sub ocultoopcionxcuenta()
        Try
            'Oculto Todos los 
            lblmaquina.Visible = False
            txtmaquina.Visible = False
            btnhelp_9.Visible = False
            lblhelp_9.Visible = False
            '
            lblctacte.Visible = False
            txtCtaCte.Visible = False
            btnhelp_1.Visible = False
            lblhelp_1.Visible = False

            '
            lblccosto.Visible = False
            txtCenCos.Visible = False
            btnhelp_2.Visible = False
            lblhelp_2.Visible = False

            '
            lblcenges.Visible = False
            txtCenGes.Visible = False
            btnhelp_3.Visible = False
            lblhelp_3.Visible = False

            lbltraencurso.Visible = False
            txttrabaencurso.Visible = False
            lblhelp_10.Visible = False
            btnhelp_10.Visible = False

            '
            lblamarre.Visible = False
            txtamarre.Visible = False
            btnhelp_6.Visible = False
            lblhelp_6.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Sub LimpiarControlesf()
        'Iniciar variables gloabales de la clase
        correlativo = 0
        tipoctaorigenodetino = ""
        cOldCuenta = ""
        tipoctacte = ""
        '
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Sub Muestroopcionxcuenta()

        Dim lUtilAmarre As String
        Dim lUtilTercer As String
        Dim lUtilCenCos As String
        Dim lUtilCenGes As String
        Dim lUtilMaquina As String
        Dim lUtilTraencurso As String
        Dim FlagConCta As String ' longitud 4 
        Try

            If cOldCuenta = txtCuenta.Text Then Exit Sub

            'Inicializo
            FlagConCta = "NNNN"
            lUtilTercer = ""
            lUtilCenCos = "N"
            lUtilCenGes = ""
            lUtilAmarre = "N"
            lUtilTraencurso = "N"
            lUtilMaquina = "N"

            'Si la cuenta es diferente de vacio
            If lblhelp_0.Text <> "???" And lblhelp_0.Text <> "" Then
                lUtilTercer = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text.Trim, "UT")
                lUtilCenGes = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text.Trim, "UG")
                FlagConCta = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text.Trim, "CONFC")
                '
                lUtilCenCos = FlagConCta.ToString.Trim.Substring(0, 1)
                lUtilAmarre = FlagConCta.ToString.Trim.Substring(1, 1)
                lUtilTraencurso = FlagConCta.ToString.Trim.Substring(2, 1)
                lUtilMaquina = FlagConCta.ToString.Trim.Substring(3, 1)

            End If

            'Muestro las columnas segun lo traido
            ' Verifico si Pide selecionar cuentas de Amarre
            lblamarre.Visible = (lUtilAmarre.Trim = "S")
            txtamarre.Visible = (lUtilAmarre.Trim = "S")
            btnhelp_6.Visible = (lUtilAmarre.Trim = "S")
            lblhelp_6.Visible = (lUtilAmarre.Trim = "S")
            If txtamarre.Visible = False Then
                txtamarre.Text = "" : lblhelp_6.Text = ""
            End If
            'Centro de Costos
            ' Verifico si pido Centro de Costo
            lblccosto.Visible = (lUtilCenCos.Trim = "S")
            txtCenCos.Visible = (lUtilCenCos.Trim = "S")
            btnhelp_1.Visible = (lUtilCenCos.Trim = "S")
            lblhelp_1.Visible = (lUtilCenCos.Trim = "S")
            If txtCenCos.Visible = False Then
                txtCenCos.Text = "" : lblhelp_1.Text = ""
            End If

            ' Verifico si pido Cuenta Corriente
            lblctacte.Visible = (lUtilTercer.Trim <> "")
            txtCtaCte.Visible = (lUtilTercer.Trim <> "")
            btnhelp_3.Visible = (lUtilTercer.Trim <> "")
            lblhelp_3.Visible = (lUtilTercer.Trim <> "")
            If txtCtaCte.Visible = False Then
                txtCtaCte.Text = "" : lblhelp_3.Text = ""
            End If
            'Verifico si muestra boton de documentos pendientes
            btnhelp_5.Visible = (lUtilTercer <> "")

            'Verifico maquinas
            lblmaquina.Visible = (lUtilMaquina.Trim = "S")
            txtmaquina.Visible = (lUtilMaquina.Trim = "S")
            btnhelp_9.Visible = (lUtilMaquina.Trim = "S")
            lblhelp_9.Visible = (lUtilMaquina.Trim = "S")
            If txtmaquina.Visible = False Then
                txtmaquina.Text = "" : lblhelp_9.Text = ""
            End If
            'verifico trabajos en curso
            lbltraencurso.Visible = (lUtilTraencurso.Trim = "S")
            txttrabaencurso.Visible = (lUtilTraencurso.Trim = "S")
            btnhelp_10.Visible = (lUtilTraencurso.Trim = "S")
            lblhelp_10.Visible = (lUtilTraencurso.Trim = "S")
            If txttrabaencurso.Visible = False Then
                txttrabaencurso.Text = "" : btnhelp_10.Text = ""
            End If
            'Centro de gestion -- Deshabiltado por que no se usa
            ' Verifico si pido Centro de Gestion
            'lblcenges.Visible = (lUtilCenGes <> "")
            'txtCenGes.Visible = (lUtilCenGes <> "")
            'btnhelp_2.Visible = (lUtilCenGes <> "")
            'lblhelp_2.Visible = (lUtilCenGes <> "")
            'txtCenGes.Text = "" : lblhelp_2.Text = ""
        Catch ex As Exception

        End Try
    End Sub
    Sub ValoresXdefCuenta()
        Try
            'Solo ingresa si la aciones nuevo
            If Me.accionMante <> "N" Then Exit Sub
            ' Muestro el Afecto o Inafecto Igv por Default

            'Muestra columnas
            cbocolumna.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text.Trim, "COLR")
            '
            cbomoneda.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text, "UD")
            ' Muestro el Centro de Costo por Default
            If txtCenCos.Visible = True Then
                txtCenCos.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text, "FC")
                If txtCenCos.Text <> "" Then lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCenCos.Text, "T1")
            End If
            '
            tipoctacte = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text.Trim, "UT")
            ' Muestro listado de cuentas de Amarre
            If txtamarre.Visible = True Then
                Me.btnhelp_6_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then

                correlativo = CInt(filaactiva("ccd01ord").ToString)
                tipoctaorigenodetino = filaactiva("ccd01ama").ToString
                'Cargo Campos de Cuenta y Glosa
                txtCuenta.Text = filaactiva("ccd01cta").ToString
                Me.TraeDameDescripcion(0)
                Me.Muestroopcionxcuenta()
                txtConcepto.Text = filaactiva("ccd01con").ToString
                txtcomprobante.Text = filaactiva("ccd01Comprobante").ToString
                ' Cargo el Centros de Costo, Centros de Gestión y Cuenta Corriente
                txtCenCos.Text = filaactiva("ccd01cc").ToString
                Me.TraeDameDescripcion(1)

                txtmaquina.Text = filaactiva("ccd01codmaquina").ToString
                Me.TraeDameDescripcion(9)
                txttrabaencurso.Text = filaactiva("ccd01codtraencurso").ToString()
                Me.TraeDameDescripcion(10)

                txtCenGes.Text = filaactiva("ccd01cg").ToString
                TraeDameDescripcion(2)
                tipoctacte = filaactiva("ccd01ana").ToString
                txtCtaCte.Text = filaactiva("ccd01cod").ToString
                Me.TraeDameDescripcion(3)
                'Cargo Cuenta Que Jalo el Amarre
                txtamarre.Text = filaactiva("ccd01ams").ToString
                Me.TraeDameDescripcion(6)

                cbocolumna.Text = filaactiva("ccd01afin").ToString
                cbomoneda.Text = filaactiva("ccd01dn").ToString

                ' Cargo campos de Documento
                txtTipDoc.Text = filaactiva("ccd01tipdoc").ToString
                TraeDameDescripcion(4)
                txtNoDoc.Text = filaactiva("ccd01ndoc").ToString
                txtaniodua.Text = filaactiva("ccd01aniodua").ToString
                TxtNroPago.Text = filaactiva("ccd01nropago").ToString

                mskFecDoc.Text = filaactiva("ccd01fedoc").ToString
                mskFecVenc.Text = filaactiva("ccd01feven").ToString
                mskFecPag.Text = filaactiva("ccd01fecpago").ToString
                '
                txtdocmodtip.Text = filaactiva("ccd01cqmtipo").ToString
                TraeDameDescripcion(11)
                txtdocmodNum.Text = filaactiva("ccd01cqmnumero").ToString
                MskdocmodFecha.Text = filaactiva("ccd01cqmfecha").ToString

                ' Cargo los Montos
                txtTipCambio.Text = filaactiva("ccd01tc").ToString

                txtDebe_0.Text = If(cbomoneda.Text = "S", filaactiva("ccd01deb").ToString, filaactiva("ccd01car").ToString)
                txtHaber_0.Text = If(cbomoneda.Text = "S", filaactiva("ccd01hab").ToString, filaactiva("ccd01abo").ToString)
                txtDebe_1.Text = If(cbomoneda.Text = "S", filaactiva("ccd01car").ToString, filaactiva("ccd01deb").ToString)
                txtHaber_1.Text = If(cbomoneda.Text = "S", filaactiva("ccd01abo").ToString, filaactiva("ccd01hab").ToString)

                txtAfectoRetencion.Text = filaactiva("ccd01AfectoReteccion").ToString
                txtTipoTransaccion.Text = filaactiva("ccd01TipoTransaccion").ToString
                TraeDameDescripcion(7)
                txtNroRetencion.Text = filaactiva("ccd01NroDocRetencion").ToString
                mskFechaRetencion.Text = filaactiva("ccd01FechaRetencion").ToString
                mskFechaPagoRetencion.Text = filaactiva("ccd01FechaPagoRetencion").ToString
                txtTipoDocRet.Text = filaactiva("ccd01TipoDocRetencion").ToString
                Me.TraeDameDescripcion(8)
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

            '
            Dim columna2 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna2 = tblhelp.Columns(2)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            Dim columna3 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna3 = tblhelp.Columns(3)
            tblhelp.Splits(0).DisplayColumns(columna3).Width = 0

            Dim columna4 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna4 = tblhelp.Columns(4)
            tblhelp.Splits(0).DisplayColumns(columna4).Width = 0

            Dim columna5 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna5 = tblhelp.Columns(5)
            tblhelp.Splits(0).DisplayColumns(columna5).Width = 0

            Dim columna6 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna6 = tblhelp.Columns(6)
            tblhelp.Splits(0).DisplayColumns(columna6).Width = 0

            Dim columna7 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna7 = tblhelp.Columns(7)
            tblhelp.Splits(0).DisplayColumns(columna7).Width = 0

            Dim columna8 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna8 = tblhelp.Columns(8)
            tblhelp.Splits(0).DisplayColumns(columna8).Width = 0

            Dim columna9 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna9 = tblhelp.Columns(9)
            tblhelp.Splits(0).DisplayColumns(columna9).Width = 0

            Mod_Mantenimiento.LimpiarFiltro(tblhelp)

            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"



            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.traecuenta("sp_Con_Help_Cuentas_HabYMov")
                    txtCuenta.Focus()
                Case 1
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.trae_centrodecostos()
                Case 2
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.trae_centros_de_gestion()
                Case 3
                    tblhelp.Columns(0).DataField = "ccm02cod"
                    tblhelp.Columns(1).DataField = "ccm02nom"
                    Me.trae_ctacte(tipoctacte)
                Case 4
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.traetipodoc("ccb02cod", "*")
                Case 5
                    tblhelp.Columns(0).Caption = "Doc Tipo"
                    tblhelp.Columns(0).DataField = "DocTipo"

                    tblhelp.Columns(1).Caption = "Doc Nro"
                    tblhelp.Columns(1).DataField = "DocNro"

                    tblhelp.Splits(0).DisplayColumns(columna2).Width = 50
                    tblhelp.Columns(2).Caption = "Moneda"
                    tblhelp.Columns(2).DataField = "DocMoneda"

                    tblhelp.Splits(0).DisplayColumns(columna3).Width = 50
                    tblhelp.Columns(3).Caption = "Fecha"
                    tblhelp.Columns(3).DataField = "DocFecha"

                    tblhelp.Splits(0).DisplayColumns(columna4).Width = 50
                    tblhelp.Columns(4).Caption = "Debe"
                    tblhelp.Columns(4).DataField = "Docdebe"

                    tblhelp.Splits(0).DisplayColumns(columna5).Width = 50
                    tblhelp.Columns(5).Caption = "Haber"
                    tblhelp.Columns(5).DataField = "DocHaber"

                    tblhelp.Splits(0).DisplayColumns(columna6).Width = 50
                    tblhelp.Columns(6).Caption = "Cargo"
                    tblhelp.Columns(6).DataField = "DocCargo"

                    tblhelp.Splits(0).DisplayColumns(columna7).Width = 50
                    tblhelp.Columns(7).Caption = "Abono"
                    tblhelp.Columns(7).DataField = "DocAbono"

                    tblhelp.Splits(0).DisplayColumns(columna8).Width = 50
                    tblhelp.Columns(8).Caption = "Saldo S/."
                    tblhelp.Columns(8).DataField = "DocSaldoSoles"

                    tblhelp.Splits(0).DisplayColumns(columna9).Width = 50
                    tblhelp.Columns(9).Caption = "Saldo US$"
                    tblhelp.Columns(9).DataField = "DocSaldoDolares"
                    Me.trae_DocXCtaCteyCtaCble(txtCuenta.Text, tipoctacte, txtCtaCte.Text)
                Case 6
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    If txtCuenta.Visible = True Then
                        Me.traeAmarre("61")
                    End If
                Case 7
                    tblhelp.Columns(0).DataField = "cc01Codigo"
                    tblhelp.Columns(1).DataField = "cc01descripcion"
                    Me.TraeTipoTransaccion()
                Case 8
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeTiposdeDocumentos()
                Case 9
                    tblhelp.Columns(0).DataField = "ccmmcodigo"
                    tblhelp.Columns(1).DataField = "ccmmdescripcion"
                    Me.TraeMaquinas()
                Case 10
                    tblhelp.Columns(0).DataField = "cc25codigo"
                    tblhelp.Columns(1).DataField = "cc25descripcion"
                    Me.TraeTrabajosescurso()
                Case 11
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
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtCuenta.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuenta.Text, "C3")
                    End If

                Case 1
                    If txtCenCos.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCenCos.Text, "T1")
                    End If


                Case 2
                    If txtCenGes.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = Mod_BaseDatos.DameDescripcion("" & txtCenGes.Text, "G1")
                    End If
                Case 3
                    If txtCtaCte.Text = "" Then
                        lblhelp_3.Text = ""
                    Else
                        lblhelp_3.Text = Mod_BaseDatos.DameDescripcion(tipoctacte & txtCtaCte.Text, "CR")
                    End If
                Case 4
                    If txtTipDoc.Text = "" Then
                        lblhelp_4.Text = ""
                    Else
                        lblhelp_4.Text = Mod_BaseDatos.DameDescripcion(txtTipDoc.Text, "TD")
                    End If
                Case 6
                    If txtamarre.Text = "" Then
                        lblhelp_6.Text = ""
                    Else
                        lblhelp_6.Text = Mod_BaseDatos.DameDescripcion(gbano + txtamarre.Text.Trim, "C3")
                    End If
                Case 7
                    If txtTipoTransaccion.Text = "" Then
                        lblhelp_7.Text = ""
                    Else
                        lblhelp_7.Text = Mod_BaseDatos.DameDescripcion(txtTipoTransaccion.Text, "TT")
                    End If

                Case 8
                    If txtTipoDocRet.Text = "" Then
                        lblhelp_8.Text = ""
                    Else
                        lblhelp_8.Text = Mod_BaseDatos.DameDescripcion(txtTipoDocRet.Text, "TD")
                    End If

                Case 9
                    If txtmaquina.Text = "" Then
                        lblhelp_9.Text = ""
                    Else
                        lblhelp_9.Text = Mod_BaseDatos.DameDescripcion(gbano & txtmaquina.Text, "MAQ")
                    End If
                Case 10
                    If txttrabaencurso.Text = "" Then
                        lblhelp_10.Text = ""
                    Else
                        lblhelp_10.Text = Mod_BaseDatos.DameDescripcion(txttrabaencurso.Text, "TEC")
                    End If
                Case 11
                    If txtdocmodtip.Text = "" Then
                        lblhelp_11.Text = ""
                    Else
                        lblhelp_11.Text = Mod_BaseDatos.DameDescripcion(txtdocmodtip.Text, "TD")
                    End If
            End Select

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    If tblhelp.Columns("ccm01mov").Value.ToString = "S" Then
                        txtCuenta.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                        lblhelp_0.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                        txtCuenta.Focus()
                    Else
                        txtCuenta.Text = ""
                        lblhelp_0.Text = ""
                        MessageBox.Show("AVISO :: La Cuenta no es de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCuenta.Focus()
                    End If
                Case 1
                    txtCenCos.Text = tblhelp.Columns("ccb02cod").Value.ToString
                    lblhelp_1.Text = tblhelp.Columns("ccb02des").Value.ToString
                    txtmaquina.Focus()
                Case 2
                    txtCenGes.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_2.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtCtaCte.Focus()
                Case 3
                    txtCtaCte.Text = tblhelp_p.Columns("ccm02cod").Value.ToString
                    lblhelp_3.Text = tblhelp_p.Columns("ccm02nom").Value.ToString
                    txtCtaCte.Focus()
                Case 4
                    txtTipDoc.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_4.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtNoDoc.Focus()
                Case 5
                    txtTipDoc.Text = tblhelp.Columns("DocTipo").Value.ToString
                    txtNoDoc.Text = tblhelp.Columns("DocNro").Value.ToString

                    If cbomoneda.Text = "S" Then
                        If CType(tblhelp.Columns("DocSaldoSoles").Value.ToString, Double) < 0 Then
                            txtDebe_0.Text = (CType(tblhelp.Columns("DocSaldoSoles").Value, Double) * -1).ToString()
                        Else
                            txtHaber_0.Text = tblhelp.Columns("DocSaldoSoles").Value.ToString()
                        End If
                    Else
                        If CType(tblhelp.Columns("DocSaldoDolares").Value.ToString, Double) < 0 Then
                            txtDebe_0.Text = (CType(tblhelp.Columns("DocSaldoDolares").Value, Double) * -1).ToString()
                        Else
                            txtHaber_0.Text = tblhelp.Columns("DocSaldoDolares").Value.ToString()
                        End If
                    End If

                    Me.CalculaEquivalentes("D")
                    Me.CalculaEquivalentes("H")
                    mskFecDoc.Focus()
                Case 6
                    txtamarre.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                    lblhelp_6.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                    txtcomprobante.Focus()
                Case 7
                    txtTipoTransaccion.Text = tblhelp.Columns("cc01Codigo").Value.ToString
                    lblhelp_7.Text = tblhelp.Columns("cc01descripcion").Value.ToString
                    txtTipoDocRet.Focus()
                Case 8
                    txtTipoDocRet.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_8.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtTipoDocRet.Focus()
                Case 9
                    txtmaquina.Text = tblhelp_p.Columns("ccmmcodigo").Value.ToString
                    lblhelp_9.Text = tblhelp_p.Columns("ccmmdescripcion").Value.ToString
                    txtmaquina.Focus()
                Case 10
                    txttrabaencurso.Text = tblhelp_p.Columns("cc25codigo").Value.ToString
                    lblhelp_10.Text = tblhelp_p.Columns("cc25descripcion").Value.ToString
                    txtTipDoc.Focus()
                Case 11
                    txtdocmodtip.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_11.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtdocmodNum.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

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
    Private Sub btnhelp_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_6.Click
        Me.TraerAyuda(6, btnhelp_6)
    End Sub
    Private Sub btnhelp_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_7.Click
        Me.TraerAyuda(7, btnhelp_7)
    End Sub
    Private Sub btnhelp_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_8.Click
        Me.TraerAyuda(8, btnhelp_8)
    End Sub
    Private Sub btnhelp_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_9.Click
        Me.TraerAyuda(9, btnhelp_9)
    End Sub
    Private Sub btnhelp_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_10.Click
        Me.TraerAyuda(10, btnhelp_10)
    End Sub
    Private Sub btnhelp_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_11.Click
        Me.TraerAyuda(11, btnhelp_11)
    End Sub
    Sub capturavaloresanteriores()
        ' Si esta insertando que insert
        cOldCuenta = txtCuenta.Text

        uv_Concepto = txtConcepto.Text
        uv_comprobante = txtcomprobante.Text
        uv_CtaCte = txtCtaCte.Text
        uv_moneda = cbomoneda.Text
        uv_TipDoc = txtTipDoc.Text
        uv_NoDoc = txtNoDoc.Text
        uv_mskFecDoc = mskFecDoc.Text
        '
        uv_TipDocMod = txtdocmodtip.Text
        uv_NoDocMod = txtdocmodNum.Text
        uv_mskFecDocMod = MskdocmodFecha.Text

        '
        uv_txtAfectoRetencion = txtAfectoRetencion.Text
        uv_txtTipoTransaccion = txtTipoTransaccion.Text
        uv_lblhelp_7 = lblhelp_7.Text
        uv_txtNroRetencion = txtNroRetencion.Text
        uv_mskFechaRetencion = mskFechaRetencion.Text
        uv_mskFechaPagoRetencion = mskFechaPagoRetencion.Text
        uv_txtTipoDocRet = txtTipoDocRet.Text
        uv_lblhelp_8 = lblhelp_8.Text

    End Sub
    Sub AsignavaloresAnterior()

        txtConcepto.Text = uv_Concepto
        txtcomprobante.Text = uv_comprobante
        txtCtaCte.Text = uv_CtaCte
        cbomoneda.Text = uv_moneda
        txtTipDoc.Text = uv_TipDoc
        txtNoDoc.Text = uv_NoDoc
        mskFecDoc.Text = uv_mskFecDoc
        '
        txtdocmodtip.Text = uv_TipDocMod
        txtdocmodNum.Text = uv_NoDocMod
        MskdocmodFecha.Text = uv_mskFecDocMod

        'Datos de la retencion
        txtAfectoRetencion.Text = uv_txtAfectoRetencion
        txtTipoTransaccion.Text = uv_txtTipoTransaccion
        lblhelp_7.Text = uv_lblhelp_7
        txtNroRetencion.Text = uv_txtNroRetencion
        mskFechaRetencion.Text = uv_mskFechaRetencion
        mskFechaPagoRetencion.Text = uv_mskFechaPagoRetencion
        txtTipoDocRet.Text = uv_txtTipoDocRet
        lblhelp_8.Text = uv_lblhelp_8

    End Sub

    Private Function validar_fecha_vs_mesperiodo(ByVal fechaingresada As String, ByVal periododevalidacion As String) As Boolean
        Dim mesdelafecha As String
        Dim aniodelafecha As String
        Try
            validar_fecha_vs_mesperiodo = False
            If Funciones.Funciones.derecha(periododevalidacion, 2) = "13" Then
                If IsDate(fechaingresada) = True Then
                    mesdelafecha = CType(DatePart(DateInterval.Month, CDate(fechaingresada)), String)
                    If mesdelafecha.Length = 2 Then
                        mesdelafecha = mesdelafecha
                    Else
                        mesdelafecha = "0" + mesdelafecha
                    End If
                    aniodelafecha = CType(DatePart(DateInterval.Year, CDate(fechaingresada)), String)

                    If CDbl(aniodelafecha + mesdelafecha) <> CDbl(periododevalidacion) Then
                        validar_fecha_vs_mesperiodo = True
                        MessageBox.Show("La Fecha De Retencion No es Valida" + vbCrLf + "Posiblemente No Pertenesca Al Periodo Actual", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Function
                    End If
                Else
                    validar_fecha_vs_mesperiodo = True
                    MessageBox.Show("La Fecha De Retencion No es Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End If
            End If
        Catch ex As Exception
            validar_fecha_vs_mesperiodo = False
        End Try
    End Function
    Private Sub CalculaEquivalentes(ByVal flagdh As String)
        Try
            txtDebe_0.Text = If(IsNumeric(txtDebe_0.Text) = True, txtDebe_0.Text, "0")
            txtDebe_1.Text = If(IsNumeric(txtDebe_1.Text) = True, txtDebe_1.Text, "0")
            txtHaber_0.Text = If(IsNumeric(txtHaber_0.Text) = True, txtHaber_0.Text, "0")
            txtHaber_1.Text = If(IsNumeric(txtHaber_1.Text) = True, txtHaber_1.Text, "0")
            'Calculo los Valores Equivalentes
            If cbomoneda.Text = "S" Then
                If CType(txtTipCambio.Text, Double) > 0 Then
                    If flagdh = "D" Then
                        txtDebe_1.Text = CType((CType(txtDebe_0.Text, Double) / CType(txtTipCambio.Text, Double)), String)
                    ElseIf flagdh = "H" Then 'Si es haber
                        txtHaber_1.Text = CType((CType(txtHaber_0.Text, Double) / CType(txtTipCambio.Text, Double)), String)
                    End If
                Else
                    txtDebe_1.Text = "0"
                    txtHaber_1.Text = "0"
                End If
            ElseIf cbomoneda.Text = "D" Then
                If flagdh = "D" Then
                    txtDebe_1.Text = CType((CType(txtDebe_0.Text, Double) * CType(txtTipCambio.Text, Double)), String)
                Else
                    txtHaber_1.Text = CType((CType(txtHaber_0.Text, Double) * CType(txtTipCambio.Text, Double)), String)
                End If
            Else 'Si no es soles ni dolares
                txtDebe_1.Text = "0"
                txtHaber_1.Text = "0"
                MessageBox.Show(":: AVISO : Moneda no valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            '===Si cualquiera de los valores es negativo, lo transformo a cero
            If ((CType(txtDebe_0.Text, Double) < 0) Or (CType(txtDebe_1.Text, Double) < 0) Or _
                (CType(txtHaber_0.Text, Double) < 0) Or (CType(txtHaber_1.Text, Double) < 0)) Then
                txtHaber_0.Text = "0"
                txtHaber_1.Text = "0"
                txtDebe_0.Text = "0"
                txtDebe_1.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show(gbc_MensajeError & "No se pudo calcular equivalente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function ValidaIngreso() As Boolean
        'Funcion: 
        Try
            ValidaIngreso = False
            'Valido que hayan selecioado
            If txtCuenta.Text = "" Then Beep() : MessageBox.Show("VALIDAR :: Debe Seleccionar Cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCuenta.Focus() : Exit Function
            If (lblhelp_0.Text = "???" Or lblhelp_0.Text = "") Then Beep() : MessageBox.Show("VALIDAR :: No existe la Cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCuenta.Focus() : Exit Function
            'If txtcomprobante.Text = "" Then Beep() : MessageBox.Show("VALIDAR :: Ingrese nùmero de comprobante", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtcomprobante.Focus() : Exit Function

            'Valido que se ingrese ayudas validas
            If txtCenCos.Visible And (lblhelp_1.Text = "???" Or lblhelp_1.Text = "") Then Beep() : MessageBox.Show("VALIDAR :: No existe el Centro de Costo", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCenCos.Focus() : Exit Function
            If txtCenGes.Visible And (lblhelp_2.Text = "???" Or lblhelp_2.Text = "") Then Beep() : MessageBox.Show("VALIDAR :: No existe el Centro de Gestión", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCenGes.Focus() : Exit Function
            If txtCtaCte.Visible And (lblhelp_3.Text = "???" Or lblhelp_3.Text = "") Then Beep() : MessageBox.Show("VALIDAR :: No existe el Cuenta Correntista", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCtaCte.Focus() : Exit Function
            If txtmaquina.Visible And (lblhelp_9.Text = "???" Or lblhelp_9.Text = "") Then Beep() : MessageBox.Show("VALIDAR :: No existe el Cuenta Destino", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtmaquina.Focus() : Exit Function
            If txttrabaencurso.Visible And (lblhelp_10.Text = "???" Or lblhelp_10.Text = "") Then Beep() : MessageBox.Show("VALIDAR :: No existe trabajo en curso", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txttrabaencurso.Focus() : Exit Function
            'If Left(txtCuenta, 1) = "9" Then
            If txtConcepto.Text.Trim = "" Then Beep() : MessageBox.Show("VALIDAR :: Ingrese Concepto de Detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtConcepto.Focus() : Exit Function
            'End If

            'Si muestra cuenta corriente debe exigir tipo y numero de docuemento
            If txtCtaCte.Visible = True Then
                If (lblhelp_4.Text = "" Or lblhelp_4.Text = "???") Then Beep() : MessageBox.Show("VALIDAR :: Tipo de Documento no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtTipDoc.Focus() : Exit Function
                If txtNoDoc.Text = "" Then Beep() : MessageBox.Show("VALIDAR :: Debe Ingresar Número de Documento", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNoDoc.Focus() : Exit Function
            End If

            'Si el amamrre esta visible debe exigir el amarre
            If txtamarre.Visible And (lblhelp_6.Text = "???" Or lblhelp_6.Text = "") Then Beep() : MessageBox.Show(" VALIDAR :: No existe Cuenta De Amarre", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtamarre.Focus() : Exit Function

            'Validar tipo de cambio se numero y mayor a cero
            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then MessageBox.Show("VALIDAR :: Tipo de Cambio No Válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtTipCambio.Focus() : Exit Function

            'Validar que se ingrese solo el debe o el haber
            If (IsNumeric(txtDebe_0.Text) = False Or _
               IsNumeric(txtDebe_1.Text) = False Or _
                IsNumeric(txtHaber_0.Text) = False Or _
                IsNumeric(txtHaber_1.Text) = False) Then
                Beep() : MessageBox.Show("VALIDAR :: Importe no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            End If

            If (CDbl(txtDebe_0.Text) <> 0 And CDbl(txtHaber_0.Text) <> 0) Then Beep() : MessageBox.Show("Debe Ingresar sólo el Debe o el Haber", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If (CDbl(txtDebe_1.Text) <> 0 And CDbl(txtHaber_1.Text) <> 0) Then Beep() : MessageBox.Show("Debe Ingresar sólo el Debe o el Haber", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function

            'Si todo pasa 
            ValidaIngreso = True
        Catch ex As Exception
            ValidaIngreso = False
        End Try
    End Function

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
    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCenCos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCenCos.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCenGes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCenGes.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCtaCte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCtaCte.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtTipDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipDoc.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_4_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtNoDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoDoc.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_5_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtamarre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtamarre.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_6_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtTipoTransaccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoTransaccion.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_7_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txttrabaencurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttrabaencurso.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_10_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtmaquina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmaquina.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_9_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtTipoDocRet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoDocRet.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_8_Click(Nothing, Nothing)
        End If
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

    Private Sub Frm_Voucher_Abc_Det_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Detalle de voucher"
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btninsertar, gbc_Ttp_Insertar)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)


            Me.inicializaValores()
            'Inicializo mi formulario desde donde se cargo 

            frmOrigen = CType(Me.Owner, Frm_Voucher_Abc)

            HabilitarMantenimiento(False)
            'Capturo datos de cabecera de ese formualrio
            libro = frmOrigen.txtlibro.Text
            nrovoucher = frmOrigen.txtNoVoucher.Text
            '
            If Me.accionMante = "N" Then
                Me.Nuevo()
            ElseIf Me.accionMante = "I" Then
                Me.cargarDatos(RegistroActivo)
                Me.insertarRegistro()
            ElseIf Me.accionMante = "M" Then
                Me.cargarDatos(RegistroActivo)
                Me.modificar()
            ElseIf Me.accionMante = "V" Then
                Me.cargarDatos(RegistroActivo)
            End If
            'Tiene y anda con fierro
            Mod_Mantenimiento.ocultarbotonespercerrado(Me)
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub

    Private Sub mskFecDoc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFecDoc.GotFocus
        Mod_Mantenimiento.sombrearcontrol(mskFecDoc)
    End Sub
    Private Sub mskFecDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFecDoc.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskFecPag_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFecPag.GotFocus
        Mod_Mantenimiento.sombrearcontrol(mskFecPag)
    End Sub
    Private Sub mskFecPag_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFecPag.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskFecVenc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFecVenc.GotFocus
        Mod_Mantenimiento.sombrearcontrol(mskFecVenc)
    End Sub

    Private Sub mskFecVenc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFecVenc.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskFechaRetencion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFechaRetencion.GotFocus
        Mod_Mantenimiento.sombrearcontrol(mskFechaRetencion)
    End Sub
    Private Sub mskFechaRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFechaRetencion.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskFechaPagoRetencion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFechaPagoRetencion.GotFocus
        Mod_Mantenimiento.sombrearcontrol(mskFechaPagoRetencion)
    End Sub
    Private Sub mskFechaPagoRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFechaPagoRetencion.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub txtDebe_0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDebe_0.LostFocus
        Me.CalculaEquivalentes("D")
    End Sub
    Private Sub txtHaber_0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHaber_0.LostFocus
        Me.CalculaEquivalentes("H")
    End Sub
    Private Sub txtCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuenta.LostFocus
        'Traer Ayuda
        Me.TraeDameDescripcion(0)
        'Si no es una cuenat valida no trae nada
        If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then Exit Sub
        'Obtiene la configuracion de la cuenta
        Me.Muestroopcionxcuenta()
        'Obtiene los valores por default
        Me.ValoresXdefCuenta()
        'Convertir a mayusculas
        'If Funciones.Funciones.izquierda(txtCuenta.Text, 1) = "9" And libro = "06" Then
        'txtConcepto.Text = lblhelp_0.Text.ToUpper
        'End If

    End Sub

    Private Sub btnhelp_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_5.Click
        Me.TraerAyuda(5, btnhelp_5)
    End Sub


    Private Sub mskFecDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFecDoc.LostFocus
        ' Muestro el Tipo de Cambio de la Cuenta - Fecha de Documento
        Try
            If gbFecProvision = "D" Then
                If Funciones.Funciones.EsValidaFechaPoranio(mskFecDoc.Text, gbano) = False Then mskFecDoc.Focus() : Exit Sub
                'Libro 09 de 4ta categoria y se toma el tipo de cambio anterior
                txtTipCambio.Text = Mod_BaseDatos.DameTCCuenta(mskFecDoc.Text, txtCuenta.Text)
                Me.CalculaEquivalentes("D")
                Me.CalculaEquivalentes("H")
                'Mensaje si es que no existe tipod e cambio
                If CType(txtTipCambio.Text, Double) = 1 Then
                    MessageBox.Show("No existe Tipo de Cambio a la fecha : " & CStr(mskFecDoc.Text), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If mskFecVenc.Enabled = True Then mskFecVenc.Focus()
                End If


            End If

            'Si en el libro el flag esta marcado como, editar tipo de cambio se habilita el tipo de cambio
            If Mod_BaseDatos.DameDescripcion(gbano & libro, "HYDTC") = "0" Then
                txtTipCambio.Enabled = False
            Else
                txtTipCambio.Enabled = True
            End If
            '
            Mod_Mantenimiento.Dessombrearcontrol(mskFecDoc)
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mskFechaPagoRetencion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFechaPagoRetencion.LostFocus
        Dim Periodo As String
        Try
            Periodo = gbano + gbmes
            If txtAfectoRetencion.Text.Trim = "S" Then
                Me.validar_fecha_vs_mesperiodo(mskFechaPagoRetencion.Text, Periodo)
            End If
            '
            Mod_Mantenimiento.Dessombrearcontrol(mskFechaPagoRetencion)
            '
            btngrabar.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub mskFechaRetencion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFechaRetencion.LostFocus
        Dim Periodo As String
        Try
            Periodo = gbano + gbmes
            If txtAfectoRetencion.Text.Trim = "S" Then
                Me.validar_fecha_vs_mesperiodo(mskFechaPagoRetencion.Text, Periodo)
                mskFechaPagoRetencion.Text = mskFechaRetencion.Text
            End If
            Mod_Mantenimiento.Dessombrearcontrol(mskFechaRetencion)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtamarre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamarre.LostFocus
        Me.TraeDameDescripcion(6)
    End Sub
    Private Sub txtmoneda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CalculaEquivalentes("D")
        Me.CalculaEquivalentes("H")
    End Sub

    Private Sub txtCenCos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCenCos.LostFocus
        Me.TraeDameDescripcion(1)
    End Sub

    Private Sub txtCenGes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCenGes.LostFocus
        Me.TraeDameDescripcion(2)
    End Sub
    Private Sub txtCtaCte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtaCte.LostFocus
        Dim xlibro As String
        Try
            '
            Me.TraeDameDescripcion(3)

            '
            If ((lblhelp_3.Text <> "" And lblhelp_3.Text <> "???") And (lblhelp_4.Text <> "" And lblhelp_4.Text <> "???")) Then
                xlibro = Mod_BaseDatos.DameDescripcion(gbano + libro, "L1")
                Me.habilitarretencion(libro, txtTipDoc.Text)
            Else
                Me.inhabilitarretencion()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtTipDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipDoc.LostFocus
        Dim xlibro As String
        Try

            Me.TraeDameDescripcion(4)
            'Validar que exista cta cte y Tipo de documento
            If ((lblhelp_3.Text <> "" And lblhelp_3.Text <> "???") And (lblhelp_4.Text <> "" And lblhelp_4.Text <> "???")) Then
                xlibro = Mod_BaseDatos.DameDescripcion(gbano + libro, "L1")
                Me.habilitarretencion(xlibro, txtTipDoc.Text)
            Else
                Me.inhabilitarretencion()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtTipoTransaccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoTransaccion.LostFocus
        Me.TraeDameDescripcion(7)
    End Sub
    Private Sub txtTipoDocRet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoDocRet.LostFocus
        Me.TraeDameDescripcion(8)
    End Sub

    Private Sub txtmaquina_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmaquina.LostFocus
        Me.TraeDameDescripcion(9)
    End Sub
    Private Sub txttrabaencurso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttrabaencurso.LostFocus
        Me.TraeDameDescripcion(10)
    End Sub

    Private Sub txtHaber_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHaber_1.KeyDown
        MessageBox.Show("Entra tab")
    End Sub


    Private Sub txtHaber_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHaber_1.KeyPress
        MessageBox.Show("Entra tab")
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Me.modificar()
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        frmOrigen.eliminarDetalle()
        Me.Close()
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            Dim moneda As String
            Dim nDebSol As Double = 0
            Dim nHabSol As Double = 0
            Dim nDebDol As Double = 0
            Dim nHabDol As Double = 0
            '
            Dim cFecDoc As String = ""
            Dim cFecVen As String = ""
            Dim cFecPag As String = ""
            Dim cFecrete As String = ""
            Dim cFecDocMod As String = ""
            Dim cFecretepago As String = ""

            'Validar que las fechas de la retencion pertenescan al periodo
            If txtAfectoRetencion.Text.Trim = "S" Then
                If Funciones.Funciones.EsValidaFechaPorPer(mskFechaRetencion.Text, gbano & gbmes) = False Then : Exit Sub
                    If Funciones.Funciones.EsValidaFechaPorPer(mskFechaPagoRetencion.Text, gbano & gbmes) = False Then : Exit Sub
                    End If
                End If
            End If
            'Validaciones
            If ValidaIngreso() = False Then Exit Sub

            moneda = cbomoneda.Text
            nDebSol = If(moneda = "S", CDbl(txtDebe_0.Text), CDbl(txtDebe_1.Text))
            nHabSol = If(moneda = "S", CDbl(txtHaber_0.Text), CDbl(txtHaber_1.Text))
            nDebDol = If(moneda = "S", CDbl(txtDebe_1.Text), CDbl(txtDebe_0.Text))
            nHabDol = If(moneda = "S", CDbl(txtHaber_1.Text), CDbl(txtHaber_0.Text))

            cFecDoc = If(IsDate(mskFecDoc.Text) = True, mskFecDoc.Text, "")
            cFecVen = If(IsDate(mskFecVenc.Text) = True, mskFecVenc.Text, "")
            cFecPag = If(IsDate(mskFecPag.Text) = True, mskFecPag.Text, "")
            cFecDocMod = If(IsDate(MskdocmodFecha.Text) = True, MskdocmodFecha.Text, "")
            cFecrete = If(IsDate(mskFechaRetencion.Text) = True, mskFechaRetencion.Text, "")
            cFecretepago = If(IsDate(mskFechaPagoRetencion.Text) = True, mskFechaPagoRetencion.Text, "")

            '====
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            '=================================
            Dim columna As String
            '=================================
            columna = cbocolumna.Text
            'Cuando es Insercion se pasa en blanco, si es Actualizacioon se pasa el correlativo
            'ordeninsercion = If(Me.accionMante = "I", 0, correlativo)
            '=====
            If Me.accionMante = "N" Then
                a = objSql.Ejecutar2("sp_Con_Ins_Detalle_Voucher", gbcodempresa, gbano, gbmes, libro, nrovoucher, _
                                    txtCuenta.Text, nDebSol, nHabSol, txtConcepto.Text, txtTipDoc.Text, txtNoDoc.Text, _
                                    cFecDoc, cFecVen, txtCtaCte.Text, moneda, CDbl(txtTipCambio.Text), columna, _
                                    txtCenCos.Text, txtCenGes.Text, "", "", nDebDol, nHabDol, "N", "", _
                                    txtAfectoRetencion.Text, txtTipoTransaccion.Text, txtNroRetencion.Text, _
                                    cFecrete, cFecretepago, _
                                    txtTipoDocRet.Text, TxtNroPago.Text, cFecPag, "", txtamarre.Text, _
                                    txtcomprobante.Text, txtaniodua.Text, txttrabaencurso.Text, txtmaquina.Text, _
                                    txtdocmodtip.Text, txtdocmodNum.Text, cFecDocMod, _
                                    0, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("sp_Con_Upd_Detalle_Voucher", gbcodempresa, gbano, gbmes, libro, nrovoucher, _
                                    txtCuenta.Text, nDebSol, nHabSol, txtConcepto.Text, txtTipDoc.Text, txtNoDoc.Text, _
                                    cFecDoc, cFecVen, txtCtaCte.Text, moneda, CDbl(txtTipCambio.Text), columna, _
                                    txtCenCos.Text, txtCenGes.Text, "", "", nDebDol, nHabDol, "N", correlativo, _
                                    txtAfectoRetencion.Text, txtTipoTransaccion.Text, txtNroRetencion.Text, _
                                    cFecrete, cFecretepago, _
                                    txtTipoDocRet.Text, TxtNroPago.Text, cFecPag, "", txtamarre.Text, _
                                    txtcomprobante.Text, txtaniodua.Text, txttrabaencurso.Text, txtmaquina.Text, _
                                    txtdocmodtip.Text, txtdocmodNum.Text, cFecDocMod, _
                                    0, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            'Armar Identificador de Fila
            Dim i As Integer
            Dim correlativoIns As Integer 'Para el ultimo correaltvo que se genero en la base ded adtos
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                'Otros Mnsajes
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        If a.GetValue(0, i).ToString = "@ccd01ord" Then
                            correlativoIns = CInt(a.GetValue(1, i).ToString)
                        Else
                            'Insertar
                            If Insertar = True Then
                                Dim r As Array = Array.CreateInstance(GetType(Object), 2, 10)
                                r = objSql.Ejecutar2("Spu_Con_Upd_NordenAsientos", gbcodempresa, gbano, gbmes, libro, nrovoucher, posicion_Insercion, Norden_Final)
                                'El correlativo 
                                correlativoIns = posicion_Insercion
                                '
                                posicion_Insercion = 0 : Insertar = False : Norden_Final = 0
                                If Funciones.Funciones.MensajesdelSQl(r) = False Then
                                    MessageBox.Show("No se Pudo Insertaren la posicion indicada; Se insertara al final", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            End If
                            'Mensaje despues de la insercion
                            MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If
                    End If
                Next

                'Refresca grilla
                Me.frmOrigen.refrescarGrilla()

                'Posicionar
                If Me.accionMante = "N" Then
                    Me.frmOrigen.Posicionar("ccd01ord", CStr(correlativoIns), frmOrigen.tblconsulta)
                ElseIf Me.accionMante = "M" Then
                    Me.frmOrigen.Posicionar("ccd01ord", CStr(correlativo), frmOrigen.tblconsulta)
                End If

                '===
                Me.capturavaloresanteriores()
                '===
                If Me.accionMante = "N" Then
                    Me.Nuevo()
                    Me.AsignavaloresAnterior()
                    Exit Sub
                End If

                Me.HabilitarMantenimiento(False)

            Else 'Fallo la ejecucion Sql 
                'Mensajes de Fallo
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "PRUEBA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        cargarDatos(frmOrigen.P_FilaDeTabla)
        HabilitarMantenimiento(False)
    End Sub
    Private Sub cbomoneda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbomoneda.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub
    Private Sub cbocolumna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbocolumna.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub
    Private Sub txtHaber_1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHaber_1.LostFocus
        If (txtAfectoRetencion.Text = "S" And txtAfectoRetencion.Enabled = True) Then
            txtAfectoRetencion.Focus()
        End If
    End Sub
    Private Sub txtAfectoRetencion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAfectoRetencion.LostFocus
        If txtAfectoRetencion.Text = "N" Then
            btngrabar.Focus()
        End If
    End Sub
    Sub insertarRegistro()
        Try
            'Si la cuenta tiene amarra no se puede modificar
            If tipoctaorigenodetino = "D" Then
                Beep() : MessageBox.Show("Cuenta No se puede Insertar; Seleccione la Cuenta de Origen", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            posicion_Insercion = 0
            Norden_Final = 0
            '
            posicion_Insercion = correlativo
            Norden_Final = DameNroOrdenFinal(gbcodempresa, gbano, gbmes, libro, nrovoucher)
            Insertar = True
            '
            Me.Nuevo()
            '
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btninsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsertar.Click
        Me.insertarRegistro()
    End Sub



    Private Sub txtCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuenta.TextChanged

    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

    End Sub

    Private Sub mskFecPag_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFecPag.LostFocus
        Mod_Mantenimiento.Dessombrearcontrol(mskFecPag)
    End Sub

    Private Sub mskFecPag_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskFecPag.MaskInputRejected

    End Sub

    Private Sub mskFecVenc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFecVenc.LostFocus
        Mod_Mantenimiento.Dessombrearcontrol(mskFecVenc)
    End Sub

    Private Sub mskFecVenc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskFecVenc.MaskInputRejected

    End Sub

    Private Sub mskFechaRetencion_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskFechaRetencion.MaskInputRejected

    End Sub

    Private Sub mskFechaPagoRetencion_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskFechaPagoRetencion.MaskInputRejected

    End Sub

    Private Sub txtmaquina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmaquina.TextChanged

    End Sub

    Private Sub cbocolumna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocolumna.SelectedIndexChanged

    End Sub

    Private Sub txtDebe_0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebe_0.TextChanged

    End Sub

    Private Sub txtTipCambio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipCambio.TextChanged

    End Sub

    Private Sub mskFecDoc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskFecDoc.MaskInputRejected

    End Sub

    Private Sub txtdocmodtip_Leave(sender As System.Object, e As System.EventArgs) Handles txtdocmodtip.Leave
        If (txtdocmodtip.Text <> "") Then
            Me.TraeDameDescripcion(11)
        End If
    End Sub
End Class