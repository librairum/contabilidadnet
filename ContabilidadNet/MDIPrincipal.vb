Option Strict On
Option Explicit On
Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI.Docking

Public Class MDIPrincipal
#Region "Globales"
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub LlenarCombo(ByVal cbo As ComboBox, ByVal empresa As String, ByVal anio As String)
        Try
            cbo.ValueMember = "ccb03cod"
            cbo.DisplayMember = "ccb03des"
            cbo.DataSource = objSql.TraerDataTable("Spu_Con_Help_ccb03per", empresa, anio).DefaultView
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LlenarCombo_1(ByVal empresa As String, ByVal anio As String)
        Try
            cboperiodos.ValueMember = "ccb03cod"
            cboperiodos.DisplayMember = "ccb03des"
            cboperiodos.DataSource = objSql.TraerDataTable("Spu_Con_Help_ccb03per", empresa, anio).DefaultView
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub pValorInicial()
        Try
            InicializarAplicacion()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Public Function PantallaVisible(ByVal NombreFormActivo As String) As Boolean
        ' Barro todas las Pantallas cargadas en el Sistema
        PantallaVisible = False
        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name = NombreFormActivo Then
                PantallaVisible = True
                Exit Function
            End If
        Next
    End Function

    'Private Sub MDIPrincipal_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    'Me.BackgroundImage = Image.FromFile("C:\vita.JPEG")
    '    'Me.BackgroundImageLayout = ImageLayout.Stretch
    'End Sub
    Private Sub MDIPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim anio As String
        Dim mes As String
        anio = Funciones.Funciones.izquierda(cboperiodos.SelectedValue.ToString, 4)
        mes = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
        If gbsaltaractualizaperiodo = "" Then
            Mod_BaseDatos.actualisaperiododeusuario(anio, mes)
        End If
    End Sub
    Sub SalirDelSistema()
        If MessageBox.Show("¿ Esta seguro de salir del sistema ?", "Salir del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Global.System.Windows.Forms.Application.Exit()
        End If
    End Sub

    Private Sub MDIPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Inicio Conexion
            Me.pValorInicial()
            '

            GrBoxCambiarPeriodo.Visible = False
            ToolTip.ShowAlways = True
            ToolTip.Active = True
            ToolTip.AutomaticDelay = 200
            ToolTip.ToolTipIcon = ToolTipIcon.None
            ToolTip.ToolTipTitle = ""
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            'Cargar formulario Login
            If Funciones.Funciones.FormIsOpen("Frm_Login") Then Exit Sub
            Dim _Frm_Login As New Frm_Login
            If _Frm_Login.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                End
            End If

            'Cargar seleccioar empresa
            If Funciones.Funciones.FormIsOpen("Frm_Empresa_Seleccionar") Then Exit Sub
            Dim _Frm_Empresa_Seleccionar As New Frm_Empresa_Seleccionar

            If _Frm_Empresa_Seleccionar.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                End
            End If

            'Llenar combo con
            gbllenadodecombo = False
            LlenarCombo(cboperiodos, gbcodempresa, gbano)
            gbllenadodecombo = True

            ' Solo si exiet mes lo posiciono 
            If CType(gbmes, Integer) >= 1 Then
                cboperiodos.SelectedIndex = CType(gbmes, Integer)
            End If

            '
            Me.Text = gbNomEmpresa
            Me.lblModulo.Text = gbNombreModulo + "  " + gbversionUsuario

            'If (cboperiodos.SelectedIndex >= 1) Then
            'Else
            '    MessageBox.Show("No existen Periodos Para el Año : " & gbano & " ,Comuniquese con administrador del sistema")
            '    End
            'End If
            '
            TlsMoneda_btn_0.Checked = If(gbmoneda = "S", True, False) 'Soles
            TlsMoneda_btn_1.Checked = If(gbmoneda = "D", True, False) 'Dolares
            '
            TlsSaldos_btn_0.Checked = If(gbSaldos = "A", True, False) 'Aculuado 
            TlsSaldos_btn_1.Checked = If(gbSaldos = "M", True, False) 'Mensual

            TlsImpresora_btn_0.Checked = If(gbTipoImpresora = "I", True, False) 'Inyeccion
            TlsImpresora_btn_1.Checked = If(gbTipoImpresora = "M", True, False) 'Matricial

            'Set Dockpanel properties
            'DockPanel.ActiveAutoHideContent = Nothing
            'DockPanel.Parent = Me
            'DockPanel.SuspendLayout(True)
            'DockPanel.ResumeLayout(True, True)
            'Traer un datetabel con los valores
            'Dim menu As New MenuStrip
            Dim menu_nivel1 As ToolStripMenuItem = Nothing
            Dim menu_nivel2 As ToolStripMenuItem = Nothing
            Dim menu_nivel3 As ToolStripMenuItem = Nothing
            Dim menu_separator As ToolStripSeparator = Nothing
            '
            Dim dt As DataTable
            Dim filadetablas As DataRow


            'Traemos la configuracion de la base de datos
            dt = objSql.TraerDataTable("Spu_Glo_Trae_MenuxUsuario", gbcodempresa, gbc_sistema, gbNameUser)
            'Agregamos el menu al formulario
            Menu.Parent = Me
            'Recorremos las data traida
            Dim codigomenu, nombre As String
            Dim nivel1, nivel2, nivel3 As String

            For Each filadetablas In dt.Rows
                nombre = ""
                codigomenu = ""
                nivel1 = ""
                nivel2 = ""
                nivel3 = ""
                '
                nombre = filadetablas("texto").ToString()
                codigomenu = filadetablas("codigomenu").ToString()
                nivel1 = codigomenu.Substring(0, 2)
                nivel2 = codigomenu.Substring(2, 2)
                nivel3 = codigomenu.Substring(4, 2)


                If nivel1 <> "00" And nivel2 = "00" And nivel3 = "00" Then
                    menu_nivel1 = New ToolStripMenuItem(nombre, Nothing, AddressOf OnclickMenuitem, codigomenu)
                    Menu.Items.Add(menu_nivel1)
                ElseIf nivel2 <> "00" And nivel3 = "00" Then
                    If (nombre = "-" Or nombre = "_") Then
                        'menu_nivel2 = New ToolStripMenuItem(nombre, Nothing, AddressOf OnclickMenuitem, codigomenu)
                        menu_separator = New ToolStripSeparator
                        menu_nivel1.DropDownItems.Add(menu_separator)
                    Else
                        menu_nivel2 = New ToolStripMenuItem(nombre, Nothing, AddressOf OnclickMenuitem, codigomenu)
                        menu_nivel1.DropDownItems.Add(menu_nivel2)
                    End If
                ElseIf nivel3 <> "00" Then
                    menu_nivel3 = New ToolStripMenuItem(nombre, Nothing, AddressOf OnclickMenuitem, codigomenu)
                    menu_nivel2.DropDownItems.Add(menu_nivel3)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub OnclickMenuitem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim codigo As String
        Dim nivel1, nivel2, nivel3 As String
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

        codigo = item.Name

        nivel1 = codigo.Substring(0, 2)
        nivel2 = codigo.Substring(2, 2)
        nivel3 = codigo.Substring(4, 2)

        If (nivel1 <> "00" And nivel2 = "00" And nivel3 = "00") Then
            'No se hace nada por que el nivel 1 es titulo
        ElseIf nivel2 <> "00" And nivel3 = "00" Then
            Select Case nivel1
                Case "01" ',Maestros
                    Select Case nivel2
                        Case "01"
                            If Funciones.Funciones.FormIsOpen("Frm_PlaCtas") Then Exit Sub
                            Dim _Frm_PlaCtas As New Frm_PlaCtas
                            _Frm_PlaCtas.MdiParent = Me
                            _Frm_PlaCtas.Show()
                        Case "02"
                            'Separador
                        Case "03"
                            If Funciones.Funciones.FormIsOpen("Frm_TipodeCambio") Then Exit Sub
                            Dim _Frm_TipodeCambio As New Frm_TipodeCambio
                            _Frm_TipodeCambio.MdiParent = Me
                            _Frm_TipodeCambio.Show()
                        Case "04"
                            If Funciones.Funciones.FormIsOpen("Frm_TipoAnalisis") Then Exit Sub
                            Dim _Frm_TipoAnalisis As New Frm_TipoAnalisis
                            _Frm_TipoAnalisis.MdiParent = Me
                            _Frm_TipoAnalisis.Show()
                        Case "05"
                            If Funciones.Funciones.FormIsOpen("Frm_CtaCte") Then Exit Sub
                            Dim _Frm_CtaCte As New Frm_CtaCte
                            _Frm_CtaCte.MdiParent = Me
                            _Frm_CtaCte.Show()
                        Case "06"
                            'separador
                        Case "07"
                            If Funciones.Funciones.FormIsOpen("Frm_CCostos") Then Exit Sub
                            Dim _Frm_CCostos As New Frm_CCostos
                            _Frm_CCostos.MdiParent = Me
                            _Frm_CCostos.Show()
                        Case "08"
                            If Funciones.Funciones.FormIsOpen("Frm_Maquinas") Then Exit Sub
                            Dim _Frm_Maquinas As New Frm_Maquinas
                            _Frm_Maquinas.MdiParent = Me
                            _Frm_Maquinas.Show()
                        Case "09"
                            If Funciones.Funciones.FormIsOpen("Frm_Libros") Then Exit Sub
                            Dim _Frm_Libros As New Frm_Libros
                            _Frm_Libros.MdiParent = Me
                            _Frm_Libros.Show()
                        Case "10"
                            'Separador
                        Case "11"
                            If Funciones.Funciones.FormIsOpen("Frm_AsientoTipo") Then Exit Sub
                            Dim _Frm_AsientoTipo As New Frm_AsientoTipo
                            _Frm_AsientoTipo.MdiParent = Me
                            _Frm_AsientoTipo.Show()
                        Case "12"
                            If Funciones.Funciones.FormIsOpen("Frm_Referencias") Then Exit Sub
                            Dim _Frm_Referencias As New Frm_Referencias
                            Frm_Referencias.MdiParent = Me
                            Frm_Referencias.Show()
                        Case "13"
                            If Funciones.Funciones.FormIsOpen("Frm_AgenteRetenedores") Then Exit Sub
                            Dim _Frm_AgenteRetenedores As New Frm_AgenteRetenedores
                            _Frm_AgenteRetenedores.MdiParent = Me
                            _Frm_AgenteRetenedores.Show()
                        Case "14"
                            If Funciones.Funciones.FormIsOpen("Frm_BuenosAportadores") Then Exit Sub
                            Dim _Frm_BuenosAportadores As New Frm_BuenosAportadores
                            _Frm_BuenosAportadores.MdiParent = Me
                            _Frm_BuenosAportadores.Show()
                        Case "15"
                            If Funciones.Funciones.FormIsOpen("Frm_TablasGlobales") Then Exit Sub
                            Dim _Frm_TablasGlobales As New Frm_TablasGlobales
                            _Frm_TablasGlobales.MdiParent = Me
                            _Frm_TablasGlobales.Show()
                        Case "16"
                            If Funciones.Funciones.FormIsOpen("Frm_TipodeDocumentos") Then Exit Sub
                            Dim _Frm_TipodeDocumentos As New Frm_TipodeDocumentos
                            _Frm_TipodeDocumentos.MdiParent = Me
                            _Frm_TipodeDocumentos.Show()
                        Case "17"
                            If Funciones.Funciones.FormIsOpen("Frm_TipodeGasto") Then Exit Sub
                            Dim _Frm_TipodeGasto As New Frm_TipodeGasto
                            _Frm_TipodeGasto.MdiParent = Me
                            _Frm_TipodeGasto.Show()
                        Case "18"
                            If Funciones.Funciones.FormIsOpen("Frm_Gastos") Then Exit Sub
                            Dim _Frm_Gastos As New Frm_Gastos
                            _Frm_Gastos.MdiParent = Me
                            _Frm_Gastos.Show()
                        Case "19"
                            If Funciones.Funciones.FormIsOpen("Frm_TrabEnCurso") Then Exit Sub
                            Dim _Frm_TrabEnCurso As New Frm_TrabEnCurso
                            _Frm_TrabEnCurso.MdiParent = Me
                            _Frm_TrabEnCurso.Show()
                        Case "20"
                            '---------------------/---------------------------/-----------------
                            If Funciones.Funciones.FormIsOpen("Frm_Motivo_Compras") Then Exit Sub
                            Dim Frm_Motivo_Compras As New Frm_Motivo_Compras
                            Frm_Motivo_Compras.MdiParent = Me
                            Frm_Motivo_Compras.Show()

                        Case "21"
                            If Funciones.Funciones.FormIsOpen("Frm_Motivo_Ventas") Then Exit Sub
                            Dim Frm_Motivo_Ventas As New Frm_Motivo_Ventas
                            Frm_Motivo_Ventas.MdiParent = Me
                            Frm_Motivo_Ventas.Show()
                    End Select
                Case "02" 'Procesecos
                    Select Case nivel2
                        Case "01"
                            If Funciones.Funciones.FormIsOpen("Frm_Voucher") Then Exit Sub
                            Dim _Frm_Voucher As New Frm_Voucher
                            _Frm_Voucher.MdiParent = Me
                            _Frm_Voucher.Show()
                        Case "02"
                            'Separador
                        Case "03"
                            If Funciones.Funciones.FormIsOpen("Frm_VoucherAT") Then Exit Sub
                            Dim _Frm_VoucherAT As New Frm_VoucherAT
                            _Frm_VoucherAT.MdiParent = Me
                            _Frm_VoucherAT.Show()
                        Case "04"
                            'Separador
                        Case "05"
                            If Funciones.Funciones.FormIsOpen("Frm_GeneraVoucherDist") Then Exit Sub
                            Dim _Frm_GeneraVoucherDist As New Frm_GeneraVoucherDist
                            _Frm_GeneraVoucherDist.MdiParent = Me
                            _Frm_GeneraVoucherDist.Show()
                        Case "06"
                            'separador
                        Case "07"
                            If Funciones.Funciones.FormIsOpen("Frm_AjusxDifCambio") Then Exit Sub
                            Dim _Frm_AjusxDifCambio As New Frm_AjusxDifCambio
                            _Frm_AjusxDifCambio.MdiParent = Me
                            _Frm_AjusxDifCambio.Show()
                        Case "08"
                            'separador
                        Case "09"
                            If Funciones.Funciones.FormIsOpen("Frm_Voucher_Importar") Then Exit Sub
                            Dim _Frm_Voucher_Importar As New Frm_Voucher_Importar
                            _Frm_Voucher_Importar.MdiParent = Me
                            _Frm_Voucher_Importar.Show()
                        Case "10"
                            'separador
                        Case "11"
                            If Funciones.Funciones.FormIsOpen("Frm_Voucher_Cierres") Then Exit Sub
                            Dim _Frm_Voucher_Cierres As New Frm_Voucher_Cierres
                            _Frm_Voucher_Cierres.MdiParent = Me
                            _Frm_Voucher_Cierres.Show()
                        Case "12"
                            'separador
                        Case "13"
                            'SIRE VENTAS
                            'Frm_ImportarSIRE_Compras
                            If Funciones.Funciones.FormIsOpen("Frm_ImportarSIRE_ComprasPrincipal") Then Exit Sub
                            Dim Frm_ImportarSIRE_ComprasPrincipal As New Frm_ImportarSIRE_ComprasPrincipal
                            Frm_ImportarSIRE_ComprasPrincipal.MdiParent = Me
                            Frm_ImportarSIRE_ComprasPrincipal.Show()
                            'If Funciones.Funciones.FormIsOpen("Frm_Voucher_ImportarCajas") Then Exit Sub
                            'Dim _Frm_Voucher_ImportarCajas As New Frm_Voucher_ImportarCajas
                            '_Frm_Voucher_ImportarCajas.MdiParent = Me
                            '_Frm_Voucher_ImportarCajas.Show()
                        Case "14"
                            'COMPRAS
                            If Funciones.Funciones.FormIsOpen("Frm_ImportarSIRE_VentasPrincipal") Then Exit Sub
                            Dim Frm_ImportarSIRE_VentasPrincipal As New Frm_ImportarSIRE_VentasPrincipal
                            Frm_ImportarSIRE_VentasPrincipal.MdiParent = Me
                            Frm_ImportarSIRE_VentasPrincipal.Show()
                    End Select
                Case "03" 'Reportes
                    Select Case nivel2
                        Case "01"
                            If Funciones.Funciones.FormIsOpen("Frm_LibroMayor") Then Exit Sub
                            Dim _Frm_LibroMayor As New Frm_LibroMayor
                            _Frm_LibroMayor.MdiParent = Me
                            _Frm_LibroMayor.Show()
                        Case "02"
                            'Separacion
                        Case "03"
                            If Funciones.Funciones.FormIsOpen("Frm_RegCompras") Then Exit Sub
                            Dim _Frm_RegCompras As New Frm_RegCompras
                            _Frm_RegCompras.MdiParent = Me
                            _Frm_RegCompras.Show()
                        Case "04"
                            If Funciones.Funciones.FormIsOpen("Frm_RegVentas") Then Exit Sub
                            Dim _Frm_RegVentas As New Frm_RegVentas
                            _Frm_RegVentas.MdiParent = Me
                            _Frm_RegVentas.Show()
                        Case "05"
                            If Funciones.Funciones.FormIsOpen("Frm_RegistroRetencionLib41") Then Exit Sub
                            Dim Frm_RegistroRetencionLib41 As New Frm_RegistroRetencionLib41
                            Frm_RegistroRetencionLib41.MdiParent = Me
                            Frm_RegistroRetencionLib41.Show()

                            'If Funciones.Funciones.FormIsOpen("Frm_RegistroRetencion") Then Exit Sub
                            'Dim _Frm_RegistroRetencion As New Frm_RegistroRetencion
                            '_Frm_RegistroRetencion.MdiParent = Me
                            '_Frm_RegistroRetencion.Show()
                        Case "06"
                            'separador
                        Case "07"

                            If Funciones.Funciones.FormIsOpen("Frm_BalanceGeneral") Then Exit Sub
                            Dim _Frm_BalanceGeneral As New Frm_BalanceGeneral
                            _Frm_BalanceGeneral.MdiParent = Me
                            _Frm_BalanceGeneral.Show()
                        Case "08"
                            If Funciones.Funciones.FormIsOpen("Frm_EEGGyPP") Then Exit Sub
                            Dim _Frm_EEGGyPP As New Frm_EEGGyPP
                            _Frm_EEGGyPP.MdiParent = Me
                            _Frm_EEGGyPP.Show()
                        Case "09"
                            If Funciones.Funciones.FormIsOpen("Frm_BalanceComprobacion") Then Exit Sub
                            Dim _Frm_BalanceComprobacion As New Frm_BalanceComprobacion
                            _Frm_BalanceComprobacion.MdiParent = Me
                            _Frm_BalanceComprobacion.Show()
                        Case "10"
                            'separador
                        Case "11"
                            If Funciones.Funciones.FormIsOpen("Frm_LibroCaja") Then Exit Sub
                            Dim _Frm_LibroCaja As New Frm_LibroCaja
                            _Frm_LibroCaja.MdiParent = Me
                            _Frm_LibroCaja.Show()
                        Case "12"
                            If Funciones.Funciones.FormIsOpen("Frm_LibroDiario") Then Exit Sub
                            Dim _Frm_LibroDiario As New Frm_LibroDiario
                            _Frm_LibroDiario.MdiParent = Me
                            _Frm_LibroDiario.Show()
                        Case "13"
                            If Funciones.Funciones.FormIsOpen("Frm_LibroBancos") Then Exit Sub
                            Dim _Frm_LibroBancos As New Frm_LibroBancos
                            _Frm_LibroBancos.MdiParent = Me
                            _Frm_LibroBancos.Show()
                        Case "14"
                            'separador
                        Case "15"
                            If Funciones.Funciones.FormIsOpen("Frm_LibrosLegales") Then Exit Sub
                            Dim _Frm_LibInvBal As New Frm_LibrosLegales
                            _Frm_LibInvBal.MdiParent = Me
                            _Frm_LibInvBal.Show()
                        Case "16"
                            If Funciones.Funciones.FormIsOpen("Frm_VoucherArchivoPlano") Then Exit Sub
                            Dim _Frm_VoucherArchivoPlano As New Frm_VoucherArchivoPlano
                            _Frm_VoucherArchivoPlano.MdiParent = Me
                            _Frm_VoucherArchivoPlano.Show()

                        Case "17"
                            If Funciones.Funciones.FormIsOpen("Frm_PDB") Then Exit Sub
                            Dim _Frm_PDB As New Frm_PDB
                            _Frm_PDB.MdiParent = Me
                            _Frm_PDB.Show()

                    End Select

                Case "04" ' Reportes internos
                    Select Case nivel2
                        Case "01"
                            If Funciones.Funciones.FormIsOpen("Frm_Distribucion_Rep") Then Exit Sub
                            Dim _Frm_Distribucion_Rep As New Frm_Distribucion_Rep
                            _Frm_Distribucion_Rep.MdiParent = Me
                            _Frm_Distribucion_Rep.Show()
                        Case "02"
                            If Funciones.Funciones.FormIsOpen("Frm_ConsultaVoucher") Then Exit Sub
                            Dim _Frm_ConsultaVoucher As New Frm_ConsultaVoucher
                            _Frm_ConsultaVoucher.MdiParent = Me
                            _Frm_ConsultaVoucher.Show()
                        Case "03"
                            If Funciones.Funciones.FormIsOpen("Frm_AnaCtaCte") Then Exit Sub
                            Dim _Frm_AnaCtaCte As New Frm_AnaCtaCte
                            _Frm_AnaCtaCte.MdiParent = Me
                            _Frm_AnaCtaCte.Show()
                        Case "04"
                            If Funciones.Funciones.FormIsOpen("Frm_Analisis6con9") Then Exit Sub
                            Dim _Frm_Analisis6con9 As New Frm_Analisis6con9
                            _Frm_Analisis6con9.MdiParent = Me
                            _Frm_Analisis6con9.Show()
                        Case "05"
                            If Funciones.Funciones.FormIsOpen("Frm_MayorPorMeses") Then Exit Sub
                            Dim _Frm_MayorPorMeses As New Frm_MayorPorMeses
                            _Frm_MayorPorMeses.MdiParent = Me
                            _Frm_MayorPorMeses.Show()
                        Case "06"
                            'separador
                        Case "07"
                            If Funciones.Funciones.FormIsOpen("Frm_DifCamAlmacenes") Then Exit Sub
                            Dim _Frm_DifCamAlmacenes As New Frm_DifCamAlmacenes
                            _Frm_DifCamAlmacenes.MdiParent = Me
                            _Frm_DifCamAlmacenes.Show()
                        Case "08"
                            'separador
                        Case "09"
                            If Funciones.Funciones.FormIsOpen("Frm_RegCompAnual") Then Exit Sub
                            Dim _Frm_RegCompAnual As New Frm_RegComprasAnual
                            _Frm_RegCompAnual.MdiParent = Me
                            _Frm_RegCompAnual.Show()
                        Case "10"
                            If Funciones.Funciones.FormIsOpen("Frm_RegVentasAnual") Then Exit Sub
                            Dim _Frm_RegVentasAnual As New Frm_RegVentasAnual
                            _Frm_RegVentasAnual.MdiParent = Me
                            _Frm_RegVentasAnual.Show()
                        Case "11"
                            'separador
                        Case "12"
                            If Funciones.Funciones.FormIsOpen("Frm_TrabEnCurso_Analisis") Then Exit Sub
                            Dim _Frm_TrabEnCurso_Analisis As New Frm_TrabEnCurso_Analisis
                            _Frm_TrabEnCurso_Analisis.MdiParent = Me
                            _Frm_TrabEnCurso_Analisis.Show()
                        Case "13"
                            If Funciones.Funciones.FormIsOpen("Frm_Maquinas_Analisis") Then Exit Sub
                            Dim _Frm_Maquinas_Analisis As New Frm_Maquinas_Analisis
                            _Frm_Maquinas_Analisis.MdiParent = Me
                            _Frm_Maquinas_Analisis.Show()
                        Case "14"
                            'Separador
                        Case "15"
                            If Funciones.Funciones.FormIsOpen("Frm_RankingCtaCte") Then Exit Sub
                            Dim _Frm_RankingCtaCte As New Frm_RankingCtaCte
                            _Frm_RankingCtaCte.MdiParent = Me
                            _Frm_RankingCtaCte.Show()
                        Case "16"
                            If Funciones.Funciones.FormIsOpen("Frm_DAOT") Then Exit Sub
                            Dim _Frm_DAOT As New Frm_DAOT
                            _Frm_DAOT.MdiParent = Me
                            _Frm_DAOT.Show()
                    End Select
                Case "05" ' Reportes internos
                    Select Case nivel2
                        Case "01"
                            If Funciones.Funciones.FormIsOpen("Frm_Produccion_Costos") Then Exit Sub
                            Dim _Frm_Produccion_Costos As New Frm_Produccion_Costos
                            _Frm_Produccion_Costos.MdiParent = Me
                            _Frm_Produccion_Costos.Show()
                        Case "02"
                            'separador
                        Case "03"
                            If Funciones.Funciones.FormIsOpen("Frm_Produccion_AnalisisGastos") Then Exit Sub
                            Dim _Frm_Produccion_AnalisisGastos As New Frm_Produccion_AnalisisGastos
                            _Frm_Produccion_AnalisisGastos.MdiParent = Me
                            _Frm_Produccion_AnalisisGastos.Show()
                        Case "04"
                            If Funciones.Funciones.FormIsOpen("Frm_Produccion_TipoGastos") Then Exit Sub
                            Dim _Frm_Produccion_TipoGastos As New Frm_Produccion_TipoGastos
                            _Frm_Produccion_TipoGastos.MdiParent = Me
                            _Frm_Produccion_TipoGastos.Show()
                        Case "05"
                            'separador
                        Case "06"
                            If Funciones.Funciones.FormIsOpen("Frm_EEFF_Comp") Then Exit Sub
                            Dim _Frm_EEFF_Comp As New Frm_EEFF_Comp
                            _Frm_EEFF_Comp.MdiParent = Me
                            _Frm_EEFF_Comp.Show()
                    End Select
                Case "06" ' Utilitarios
                    Select Case nivel2
                        Case "01"
                            'ABRIR LABEL
                            GrBoxCambiarPeriodo.Visible = True
                            txtejerActivo.Text = gbano
                            'If Funciones.Funciones.FormIsOpen("Frm_Empresa_ActPar") Then Exit Sub
                            'Dim _Frm_Empresa_ActPar As New Frm_Empresa_ActPar
                            '_Frm_Empresa_ActPar.MdiParent = Me
                            '_Frm_Empresa_ActPar.Show()

                            'ABRIR OTRO FORMULARIO DE CAMBIAR PERIODO
                            'GrBoxCambiarPeriodo.Show()
                        Case "02"
                            If Funciones.Funciones.FormIsOpen("Frm_mayoriza") Then Exit Sub
                            Dim _Frm_mayoriza As New Frm_mayoriza
                            _Frm_mayoriza.MdiParent = Me
                            _Frm_mayoriza.Show()
                        Case "03" 'Validacion contables
                            Me.ValidacionContabilidad_verant()
                        Case "04"
                            If Funciones.Funciones.FormIsOpen("Frm_Buscador") Then Exit Sub
                            Dim _Frm_Buscador As New Frm_Buscador
                            _Frm_Buscador.MdiParent = Me
                            _Frm_Buscador.Show()
                        Case "05"
                            'separador
                        Case "06"
                            If Funciones.Funciones.FormIsOpen("Frm_Empresa") Then Exit Sub
                            Dim _Frm_Empresa As New Frm_Empresa
                            _Frm_Empresa.MdiParent = Me
                            _Frm_Empresa.Show()
                        Case "07"
                            If Funciones.Funciones.FormIsOpen("Frm_Periodos") Then Exit Sub
                            Dim _Frm_Periodos As New Frm_Periodos
                            _Frm_Periodos.MdiParent = Me
                            _Frm_Periodos.Show()
                        Case "08"
                            'separador
                        Case "09"
                            If Funciones.Funciones.FormIsOpen("Frm_usuarios") Then Exit Sub
                            Dim _Frm_usuarios As New Frm_usuarios
                            _Frm_usuarios.MdiParent = Me
                            _Frm_usuarios.Show()
                        Case "10"
                            If Funciones.Funciones.FormIsOpen("Frm_Usuarios_CambioPassword") Then Exit Sub
                            Dim _Frm_Usuarios_CambioPassword As New Frm_Usuarios_CambioPassword
                            _Frm_Usuarios_CambioPassword.MdiParent = Me
                            _Frm_Usuarios_CambioPassword.Show()
                        Case "11"
                            If Funciones.Funciones.FormIsOpen("Frm_Usuarios_ConfigSeg") Then Exit Sub
                            Dim _Frm_Usuarios_ConfigSeg As New Frm_Usuarios_ConfigSeg
                            _Frm_Usuarios_ConfigSeg.MdiParent = Me
                            _Frm_Usuarios_ConfigSeg.Show()
                        Case "12"
                            'Separador
                        Case "13"
                            If Funciones.Funciones.FormIsOpen("Frm_Aperturaperiodo") Then Exit Sub
                            Dim _Frm_Aperturaperiodo As New Frm_Aperturaperiodo
                            _Frm_Aperturaperiodo.MdiParent = Me
                            _Frm_Aperturaperiodo.Show()
                    End Select
                Case "07" ' Salir
                    Select Case nivel2
                        Case "01"
                            Me.SalirDelSistema()
                    End Select
            End Select

        ElseIf nivel3 <> "00" Then
            'seleccionartodaslasfilasdelagrilla carga la opcion del nivel 3
        End If
    End Sub

    Private Sub ValidacionContabilidad()
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor
            nombredereporte = "Rpt_ErrorresContables.rpt"
            'Sp que trae datoas del reporte
            ds = objSql.TraerDataSet("Sp_Con_Trae_ErroresContables", gbcodempresa, gbano, gbmes).Copy()
            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            'Visualizar reportes
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ValidacionContabilidad_verant()
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)

        Dim nombredereporte As String
        Dim Rutareporte As String
        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor
            nombredereporte = "Rpt_ErrorresContables.rpt"

            'Sp que trae datoas del reporte
            ds = objSql.TraerDataSet("Sp_Con_Trae_ErroresContables", gbcodempresa, gbano, gbmes).Copy()

            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa$))


            'Visualizar reportes
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MDIPrincipal_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        Dim nombreformactivo As String = ""
        'Captura el formulario que se esta activando
        'If Me.ActiveMdiChild.P_HijoActivo > 0 Then
        'Frm_PlaCtas_Abc.BringToFront()
        'End If

        'If Not (Me.ActiveMdiChild Is Nothing) Then
        'nombreformactivo = Me.ActiveMdiChild.Name
        'End If


        'Si el formulario tiene un hijo cargado,le devuelvo el enfoque al hijo
        'Caso contrario lo dejo pasar

        'For Each formhijos As Form In MdiChildren
        'If ((formhijos.Name = Funciones.Funciones.izquierda(nombreformactivo, formhijos.Name.Length)) And (formhijos.Name <> nombreformactivo)) Then
        'Exit Sub
        'End If
        'Next
    End Sub


    Private Sub cboperiodos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboperiodos.SelectedIndexChanged
        Try
            If gbllenadodecombo = True Then
                gbmes = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
                ' gbano = Funciones.Funciones.izquierda(cboperiodos.SelectedValue.ToString, 4)
                gbperiodo = gbano & gbmes
            End If
            'Valido estado de periodo
            gbflagestadoperiodo = Mod_BaseDatos.Estadodeperiodo
            If Periodocerrado() = True Then
                MessageBox.Show("AVISO :: " + "El Periodo que esta Seleccionando se Encuentra Cerrado, por lo tanto solo podra Consultar los Movimientos del mismo", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(gbc_MensajeError + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TlsMoneda_btn_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsMoneda_btn_0.Click
        If TlsMoneda_btn_0.Checked = False Then
            TlsMoneda_btn_0.Checked = True
            gbmoneda = "S"
            TlsMoneda_btn_1.Checked = False
        End If
    End Sub
    Private Sub TlsMoneda_btn_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsMoneda_btn_1.Click
        If TlsMoneda_btn_1.Checked = False Then
            TlsMoneda_btn_1.Checked = True
            gbmoneda = "D"
            TlsMoneda_btn_0.Checked = False
        End If
    End Sub
    Private Sub TlsSaldos_btn_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsSaldos_btn_0.Click
        If TlsSaldos_btn_0.Checked = False Then
            TlsSaldos_btn_0.Checked = True
            gbSaldos = "A"
            TlsSaldos_btn_1.Checked = False
        End If
    End Sub
    Private Sub TlsSaldos_btn_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsSaldos_btn_1.Click
        If TlsSaldos_btn_1.Checked = False Then
            TlsSaldos_btn_1.Checked = True
            gbSaldos = "M"
            TlsSaldos_btn_0.Checked = False
        End If
    End Sub
    Private Sub TlsImpresora_btn_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsImpresora_btn_0.Click
        If TlsImpresora_btn_0.Checked = False Then
            TlsImpresora_btn_0.Checked = True
            gbTipoImpresora = "I" 'Inyeccion
            TlsImpresora_btn_1.Checked = False
        End If
    End Sub
    Private Sub TlsImpresora_btn_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsImpresora_btn_1.Click
        If TlsImpresora_btn_1.Checked = False Then
            TlsImpresora_btn_1.Checked = True
            gbTipoImpresora = "M" 'Matricial
            TlsImpresora_btn_0.Checked = False
        End If
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.SalirDelSistema()

        'If Funciones.Funciones.FormIsOpen("Frm_Empresa_Seleccionar") Then Exit Sub
        'Dim _Frm_Empresa_Seleccionar As New Frm_Empresa_Seleccionar

        'If _Frm_Empresa_Seleccionar.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
        '    End
        'End If

    End Sub
    Private Sub tsbAnailisCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnailisCuenta.Click
        If Funciones.Funciones.FormIsOpen("Frm_Cuenta_Analisis") Then Exit Sub
        Dim _Frm_Cuenta_Analisis As New Frm_Cuenta_Analisis
        _Frm_Cuenta_Analisis.MdiParent = Me
        _Frm_Cuenta_Analisis.Show()
    End Sub

    Private Sub tsbplancuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbplancuentas.Click
        If Funciones.Funciones.FormIsOpen("Frm_PlaCtas") Then Exit Sub
        Dim _Frm_PlaCtas As New Frm_PlaCtas
        _Frm_PlaCtas.MdiParent = Me
        _Frm_PlaCtas.Show()
    End Sub


    Private Sub tsbbuscador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbbuscador.Click
        If Funciones.Funciones.FormIsOpen("Frm_Buscador") Then Exit Sub
        Dim _Frm_Buscador As New Frm_Buscador
        _Frm_Buscador.MdiParent = Me
        _Frm_Buscador.Show()
    End Sub



    Private Sub PruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _fmenu As New fmenu
        _fmenu.MdiParent = Me
        _fmenu.Show()
    End Sub

    Private Sub tsbtipcamconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtipcamconsulta.Click
        If Funciones.Funciones.FormIsOpen("Frm_TipoCambioConsulta") Then Exit Sub
        Dim _Frm_TipoCambioConsulta As New Frm_TipoCambioConsulta
        _Frm_TipoCambioConsulta.MdiParent = Me
        _Frm_TipoCambioConsulta.Show()

    End Sub

    Private Sub btnrefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefrescar.Click

        GrBoxCambiarPeriodo.Visible = True
        txtejerActivo.Text = gbano
    End Sub
    Function ValidaPeriodo(ByVal anio As String) As Boolean
        Dim valor As String
        ValidaPeriodo = False
        Try
            ' Obtengo el Tipo de Cambio de la Cuenta
            valor = CType(objSql.TraerValor("Spu_Glo_Trae_Valperiodo", gbcodempresa, anio, ""), String)

            If valor.Trim <> "" Then
                ValidaPeriodo = True
            Else
                MessageBox.Show("VALIDAR :: Periodo no valido, verifique que exista el periodo", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ValidaPeriodo = False
        End Try
    End Function

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            ' llenar combo con nuevo perido

            Dim mesanterior As String

            ' capturar mes inicial y posiciono despues de cambiar de periodo
            mesanterior = gbmes

            If ValidaPeriodo(txtejerActivo.Text) = False Then Exit Sub

            LlenarCombo_1(gbcodempresa, txtejerActivo.Text)


           

            If CType(mesanterior, Integer) >= 1 Then
                cboperiodos.SelectedIndex = CType(mesanterior, Integer)
            End If

            'Vuelvo a capturar variables globales 
            gbano = Funciones.Funciones.izquierda(cboperiodos.SelectedValue.ToString, 4)
            gbmes = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
            gbperiodo = gbano & gbmes

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            a = objSql.Ejecutar2("Sp_Glo_Upd_PeriodoTrabajo", gbc_sistema, gbNameUser, gbcodempresa.Trim + gbano + gbmes, gbmoneda, gbSaldos, gbTipoImpresora, gbAjuste)

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                'Actualizar 
                MessageBox.Show("Periodo Cambiado Con Exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Global.System.Windows.Forms.Application.Exit()

            End If


            'Valido estado de periodo
            gbflagestadoperiodo = Mod_BaseDatos.Estadodeperiodo
            If Periodocerrado() = True Then
                MessageBox.Show("AVISO :: " + "El Periodo que esta Seleccionando se Encuentra Cerrado, por lo tanto solo podra Consultar los Movimientos del mismo", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            GrBoxCambiarPeriodo.Visible = False
            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            GrBoxCambiarPeriodo.Visible = False
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GrBoxCambiarPeriodo.Visible = False

    End Sub

    Private Sub btnmenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmenos.Click
        Try
            txtejerActivo.Text = CType(CType(txtejerActivo.Text, Integer) - 1, String)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnmas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmas.Click
        Try
            txtejerActivo.Text = CType(CType(txtejerActivo.Text, Integer) + 1, String)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MDIPrincipal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class