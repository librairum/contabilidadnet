<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblServidor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBaseDatos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblModulo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTerminal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.TlsMoneda = New System.Windows.Forms.ToolStrip()
        Me.TlsMoneda_btn_0 = New System.Windows.Forms.ToolStripButton()
        Me.TlsMoneda_btn_1 = New System.Windows.Forms.ToolStripButton()
        Me.TlsSaldos = New System.Windows.Forms.ToolStrip()
        Me.TlsSaldos_btn_0 = New System.Windows.Forms.ToolStripButton()
        Me.TlsSaldos_btn_1 = New System.Windows.Forms.ToolStripButton()
        Me.TlsImpresora = New System.Windows.Forms.ToolStrip()
        Me.TlsImpresora_btn_0 = New System.Windows.Forms.ToolStripButton()
        Me.TlsImpresora_btn_1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbAnailisCuenta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbplancuentas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbbuscador = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtipcamconsulta = New System.Windows.Forms.ToolStripButton()
        Me.btnrefrescar = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Menu = New System.Windows.Forms.MenuStrip()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.GrBoxCambiarPeriodo = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnmenos = New System.Windows.Forms.Button()
        Me.btnmas = New System.Windows.Forms.Button()
        Me.txtejerActivo = New Ks.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip.SuspendLayout()
        Me.TlsMoneda.SuspendLayout()
        Me.TlsSaldos.SuspendLayout()
        Me.TlsImpresora.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GrBoxCambiarPeriodo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblServidor, Me.lblBaseDatos, Me.lblModulo, Me.lblTerminal, Me.lblUsuario, Me.lblFecha})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 423)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(890, 22)
        Me.StatusStrip.TabIndex = 26
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = False
        Me.lblServidor.Image = CType(resources.GetObject("lblServidor.Image"), System.Drawing.Image)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(120, 17)
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.AutoSize = False
        Me.lblBaseDatos.Image = CType(resources.GetObject("lblBaseDatos.Image"), System.Drawing.Image)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(120, 17)
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = False
        Me.lblModulo.Image = CType(resources.GetObject("lblModulo.Image"), System.Drawing.Image)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(120, 17)
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = False
        Me.lblTerminal.Image = CType(resources.GetObject("lblTerminal.Image"), System.Drawing.Image)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(120, 17)
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = False
        Me.lblUsuario.Image = CType(resources.GetObject("lblUsuario.Image"), System.Drawing.Image)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(120, 17)
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = False
        Me.lblFecha.Image = CType(resources.GetObject("lblFecha.Image"), System.Drawing.Image)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(120, 17)
        '
        'cboperiodos
        '
        Me.cboperiodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos.FormattingEnabled = True
        Me.cboperiodos.Location = New System.Drawing.Point(8, 26)
        Me.cboperiodos.Name = "cboperiodos"
        Me.cboperiodos.Size = New System.Drawing.Size(184, 21)
        Me.cboperiodos.TabIndex = 28
        '
        'TlsMoneda
        '
        Me.TlsMoneda.Dock = System.Windows.Forms.DockStyle.None
        Me.TlsMoneda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TlsMoneda_btn_0, Me.TlsMoneda_btn_1})
        Me.TlsMoneda.Location = New System.Drawing.Point(195, 24)
        Me.TlsMoneda.Name = "TlsMoneda"
        Me.TlsMoneda.Size = New System.Drawing.Size(58, 25)
        Me.TlsMoneda.Stretch = True
        Me.TlsMoneda.TabIndex = 37
        Me.TlsMoneda.Text = "ToolStrip2"
        '
        'TlsMoneda_btn_0
        '
        Me.TlsMoneda_btn_0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TlsMoneda_btn_0.Image = Global.ContabilidadNet.My.Resources.Resources.Soles
        Me.TlsMoneda_btn_0.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlsMoneda_btn_0.Name = "TlsMoneda_btn_0"
        Me.TlsMoneda_btn_0.Size = New System.Drawing.Size(23, 22)
        Me.TlsMoneda_btn_0.ToolTipText = "Moneda Soles"
        '
        'TlsMoneda_btn_1
        '
        Me.TlsMoneda_btn_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TlsMoneda_btn_1.Image = Global.ContabilidadNet.My.Resources.Resources.Dolares
        Me.TlsMoneda_btn_1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlsMoneda_btn_1.Name = "TlsMoneda_btn_1"
        Me.TlsMoneda_btn_1.Size = New System.Drawing.Size(23, 22)
        Me.TlsMoneda_btn_1.ToolTipText = "Moneda Dolares"
        '
        'TlsSaldos
        '
        Me.TlsSaldos.Dock = System.Windows.Forms.DockStyle.None
        Me.TlsSaldos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TlsSaldos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TlsSaldos_btn_0, Me.TlsSaldos_btn_1})
        Me.TlsSaldos.Location = New System.Drawing.Point(251, 24)
        Me.TlsSaldos.Name = "TlsSaldos"
        Me.TlsSaldos.Size = New System.Drawing.Size(58, 25)
        Me.TlsSaldos.Stretch = True
        Me.TlsSaldos.TabIndex = 38
        Me.TlsSaldos.Text = "ToolStrip3"
        '
        'TlsSaldos_btn_0
        '
        Me.TlsSaldos_btn_0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TlsSaldos_btn_0.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TlsSaldos_btn_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TlsSaldos_btn_0.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlsSaldos_btn_0.Name = "TlsSaldos_btn_0"
        Me.TlsSaldos_btn_0.Size = New System.Drawing.Size(23, 22)
        Me.TlsSaldos_btn_0.Text = "A"
        Me.TlsSaldos_btn_0.ToolTipText = "Saldo Acumulado"
        '
        'TlsSaldos_btn_1
        '
        Me.TlsSaldos_btn_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TlsSaldos_btn_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TlsSaldos_btn_1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlsSaldos_btn_1.Name = "TlsSaldos_btn_1"
        Me.TlsSaldos_btn_1.Size = New System.Drawing.Size(23, 22)
        Me.TlsSaldos_btn_1.Text = "M"
        Me.TlsSaldos_btn_1.ToolTipText = "Saldo del Mes"
        '
        'TlsImpresora
        '
        Me.TlsImpresora.Dock = System.Windows.Forms.DockStyle.None
        Me.TlsImpresora.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TlsImpresora_btn_0, Me.TlsImpresora_btn_1})
        Me.TlsImpresora.Location = New System.Drawing.Point(312, 24)
        Me.TlsImpresora.Name = "TlsImpresora"
        Me.TlsImpresora.Size = New System.Drawing.Size(58, 25)
        Me.TlsImpresora.Stretch = True
        Me.TlsImpresora.TabIndex = 39
        Me.TlsImpresora.Text = "ToolStrip4"
        '
        'TlsImpresora_btn_0
        '
        Me.TlsImpresora_btn_0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TlsImpresora_btn_0.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.TlsImpresora_btn_0.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlsImpresora_btn_0.Name = "TlsImpresora_btn_0"
        Me.TlsImpresora_btn_0.Size = New System.Drawing.Size(23, 22)
        Me.TlsImpresora_btn_0.ToolTipText = "Impresora Inyeccion"
        '
        'TlsImpresora_btn_1
        '
        Me.TlsImpresora_btn_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TlsImpresora_btn_1.Image = Global.ContabilidadNet.My.Resources.Resources.matricial
        Me.TlsImpresora_btn_1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlsImpresora_btn_1.Name = "TlsImpresora_btn_1"
        Me.TlsImpresora_btn_1.Size = New System.Drawing.Size(23, 22)
        Me.TlsImpresora_btn_1.ToolTipText = "Impresora Matricial"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(890, 25)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAnailisCuenta, Me.ToolStripSeparator1, Me.tsbplancuentas, Me.ToolStripSeparator2, Me.tsbbuscador, Me.ToolStripSeparator3, Me.tsbtipcamconsulta, Me.btnrefrescar})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(458, 26)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(134, 23)
        Me.ToolStrip1.TabIndex = 205
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbAnailisCuenta
        '
        Me.tsbAnailisCuenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAnailisCuenta.Image = Global.ContabilidadNet.My.Resources.Resources.Verificarcuentas1
        Me.tsbAnailisCuenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnailisCuenta.Name = "tsbAnailisCuenta"
        Me.tsbAnailisCuenta.Size = New System.Drawing.Size(23, 20)
        Me.tsbAnailisCuenta.ToolTipText = "Analizar Cuenta por Movimiento"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'tsbplancuentas
        '
        Me.tsbplancuentas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbplancuentas.Image = Global.ContabilidadNet.My.Resources.Resources.Plactas1
        Me.tsbplancuentas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbplancuentas.Name = "tsbplancuentas"
        Me.tsbplancuentas.Size = New System.Drawing.Size(23, 20)
        Me.tsbplancuentas.ToolTipText = "Plan de Cuentas"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'tsbbuscador
        '
        Me.tsbbuscador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbbuscador.Image = Global.ContabilidadNet.My.Resources.Resources.analizacuenta1
        Me.tsbbuscador.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbbuscador.ImageTransparentColor = System.Drawing.Color.Indigo
        Me.tsbbuscador.Name = "tsbbuscador"
        Me.tsbbuscador.Size = New System.Drawing.Size(23, 20)
        Me.tsbbuscador.Text = "ToolStripButton3"
        Me.tsbbuscador.ToolTipText = "Buscador Contable"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'tsbtipcamconsulta
        '
        Me.tsbtipcamconsulta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtipcamconsulta.Image = Global.ContabilidadNet.My.Resources.Resources.money_dollar
        Me.tsbtipcamconsulta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtipcamconsulta.Name = "tsbtipcamconsulta"
        Me.tsbtipcamconsulta.Size = New System.Drawing.Size(23, 20)
        Me.tsbtipcamconsulta.ToolTipText = "Consulta de tipo de cambio"
        '
        'btnrefrescar
        '
        Me.btnrefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnrefrescar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnrefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnrefrescar.Name = "btnrefrescar"
        Me.btnrefrescar.Size = New System.Drawing.Size(23, 20)
        Me.btnrefrescar.Text = "Cambiar Periodo"
        '
        'Menu
        '
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(890, 24)
        Me.Menu.TabIndex = 207
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources._exit
        Me.btnsalir.Location = New System.Drawing.Point(706, 24)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(25, 24)
        Me.btnsalir.TabIndex = 41
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'GrBoxCambiarPeriodo
        '
        Me.GrBoxCambiarPeriodo.Controls.Add(Me.Panel3)
        Me.GrBoxCambiarPeriodo.Controls.Add(Me.Panel1)
        Me.GrBoxCambiarPeriodo.Controls.Add(Me.btnmenos)
        Me.GrBoxCambiarPeriodo.Controls.Add(Me.btnmas)
        Me.GrBoxCambiarPeriodo.Controls.Add(Me.txtejerActivo)
        Me.GrBoxCambiarPeriodo.Controls.Add(Me.Label1)
        Me.GrBoxCambiarPeriodo.Location = New System.Drawing.Point(474, 70)
        Me.GrBoxCambiarPeriodo.Name = "GrBoxCambiarPeriodo"
        Me.GrBoxCambiarPeriodo.Size = New System.Drawing.Size(257, 120)
        Me.GrBoxCambiarPeriodo.TabIndex = 209
        Me.GrBoxCambiarPeriodo.TabStop = False
        Me.GrBoxCambiarPeriodo.Text = "Cambiar Periodo"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 91)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(251, 26)
        Me.Panel3.TabIndex = 242
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(251, 31)
        Me.Panel1.TabIndex = 241
        '
        'Button2
        '
        Me.Button2.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.Button2.Location = New System.Drawing.Point(220, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 24)
        Me.Button2.TabIndex = 21
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(2, 0)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 17
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.Button1.Location = New System.Drawing.Point(250, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 20
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnmenos
        '
        Me.btnmenos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnmenos.Image = CType(resources.GetObject("btnmenos.Image"), System.Drawing.Image)
        Me.btnmenos.Location = New System.Drawing.Point(200, 70)
        Me.btnmenos.Name = "btnmenos"
        Me.btnmenos.Size = New System.Drawing.Size(22, 14)
        Me.btnmenos.TabIndex = 240
        Me.btnmenos.UseVisualStyleBackColor = True
        '
        'btnmas
        '
        Me.btnmas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnmas.Image = CType(resources.GetObject("btnmas.Image"), System.Drawing.Image)
        Me.btnmas.Location = New System.Drawing.Point(200, 54)
        Me.btnmas.Name = "btnmas"
        Me.btnmas.Size = New System.Drawing.Size(22, 16)
        Me.btnmas.TabIndex = 239
        Me.btnmas.UseVisualStyleBackColor = True
        '
        'txtejerActivo
        '
        Me.txtejerActivo.Location = New System.Drawing.Point(130, 54)
        Me.txtejerActivo.MaxLength = 80
        Me.txtejerActivo.Multiline = True
        Me.txtejerActivo.Name = "txtejerActivo"
        Me.txtejerActivo.NroDecimales = CType(0, Short)
        Me.txtejerActivo.SelectGotFocus = True
        Me.txtejerActivo.Size = New System.Drawing.Size(70, 30)
        Me.txtejerActivo.TabIndex = 238
        Me.txtejerActivo.Tabulado = True
        Me.txtejerActivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtejerActivo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Ejercicio activo"
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 445)
        Me.Controls.Add(Me.GrBoxCambiarPeriodo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnsalir)
        Me.Controls.Add(Me.TlsImpresora)
        Me.Controls.Add(Me.TlsSaldos)
        Me.Controls.Add(Me.TlsMoneda)
        Me.Controls.Add(Me.cboperiodos)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDIPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.TlsMoneda.ResumeLayout(False)
        Me.TlsMoneda.PerformLayout()
        Me.TlsSaldos.ResumeLayout(False)
        Me.TlsSaldos.PerformLayout()
        Me.TlsImpresora.ResumeLayout(False)
        Me.TlsImpresora.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GrBoxCambiarPeriodo.ResumeLayout(False)
        Me.GrBoxCambiarPeriodo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Protected WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Protected WithEvents lblServidor As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents lblBaseDatos As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents lblModulo As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents lblTerminal As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents lblUsuario As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents lblFecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents TlsMoneda As System.Windows.Forms.ToolStrip
    Friend WithEvents TlsMoneda_btn_0 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TlsMoneda_btn_1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TlsSaldos As System.Windows.Forms.ToolStrip
    Friend WithEvents TlsSaldos_btn_0 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TlsSaldos_btn_1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TlsImpresora As System.Windows.Forms.ToolStrip
    Friend WithEvents TlsImpresora_btn_0 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TlsImpresora_btn_1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAnailisCuenta As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbplancuentas As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbbuscador As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Menu As System.Windows.Forms.MenuStrip
    Friend WithEvents tsbtipcamconsulta As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnrefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GrBoxCambiarPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents btnmenos As System.Windows.Forms.Button
    Friend WithEvents btnmas As System.Windows.Forms.Button
    Friend WithEvents txtejerActivo As Ks.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
