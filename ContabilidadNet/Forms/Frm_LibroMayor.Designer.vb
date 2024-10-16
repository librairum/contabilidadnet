<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LibroMayor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LibroMayor))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_verReporteReducido = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.tabOpciones = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.cboPerfin = New System.Windows.Forms.ComboBox()
        Me.mskFecFin = New System.Windows.Forms.MaskedTextBox()
        Me.mskFecIni = New System.Windows.Forms.MaskedTextBox()
        Me.cboPerini = New System.Windows.Forms.ComboBox()
        Me.optTipoImpre_0 = New System.Windows.Forms.RadioButton()
        Me.optTipoImpre_2 = New System.Windows.Forms.RadioButton()
        Me.optTipoImpre_1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtMoneda_0 = New System.Windows.Forms.RadioButton()
        Me.rbtMoneda_1 = New System.Windows.Forms.RadioButton()
        Me.rbtMoneda_2 = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnseleccionartodo_1 = New System.Windows.Forms.Button()
        Me.tblconsulta1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtTipRep_1 = New System.Windows.Forms.RadioButton()
        Me.rbtTipRep_0 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtNivel_0 = New System.Windows.Forms.RadioButton()
        Me.rbtNivel_1 = New System.Windows.Forms.RadioButton()
        Me.rbtNivel_6 = New System.Windows.Forms.RadioButton()
        Me.rbtNivel_5 = New System.Windows.Forms.RadioButton()
        Me.rbtNivel_4 = New System.Windows.Forms.RadioButton()
        Me.rbtNivel_3 = New System.Windows.Forms.RadioButton()
        Me.rbtNivel_2 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.tabOpciones.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblconsulta1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btn_verReporteReducido)
        Me.Panel1.Controls.Add(Me.btnexportar)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 31)
        Me.Panel1.TabIndex = 4
        '
        'btn_verReporteReducido
        '
        Me.btn_verReporteReducido.Image = CType(resources.GetObject("btn_verReporteReducido.Image"), System.Drawing.Image)
        Me.btn_verReporteReducido.Location = New System.Drawing.Point(358, 0)
        Me.btn_verReporteReducido.Name = "btn_verReporteReducido"
        Me.btn_verReporteReducido.Size = New System.Drawing.Size(24, 24)
        Me.btn_verReporteReducido.TabIndex = 26
        Me.btn_verReporteReducido.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.Image = Global.ContabilidadNet.My.Resources.Resources.exportar
        Me.btnexportar.Location = New System.Drawing.Point(541, 2)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(24, 24)
        Me.btnexportar.TabIndex = 25
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(420, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 24)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Legal-Carta"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(334, 0)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(310, 0)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(700, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'tabOpciones
        '
        Me.tabOpciones.Controls.Add(Me.TabPage1)
        Me.tabOpciones.Controls.Add(Me.TabPage2)
        Me.tabOpciones.Location = New System.Drawing.Point(0, 40)
        Me.tabOpciones.Name = "tabOpciones"
        Me.tabOpciones.SelectedIndex = 0
        Me.tabOpciones.Size = New System.Drawing.Size(726, 291)
        Me.tabOpciones.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnseleccionartodo_0)
        Me.TabPage1.Controls.Add(Me.tblconsulta)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(718, 265)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Analitico"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(155, 8)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 15
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdate = False
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(154, 6)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(558, 252)
        Me.tblconsulta.TabIndex = 14
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboperiodos)
        Me.GroupBox2.Controls.Add(Me.cboPerfin)
        Me.GroupBox2.Controls.Add(Me.mskFecFin)
        Me.GroupBox2.Controls.Add(Me.mskFecIni)
        Me.GroupBox2.Controls.Add(Me.cboPerini)
        Me.GroupBox2.Controls.Add(Me.optTipoImpre_0)
        Me.GroupBox2.Controls.Add(Me.optTipoImpre_2)
        Me.GroupBox2.Controls.Add(Me.optTipoImpre_1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(152, 188)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rango de Impresión"
        '
        'cboperiodos
        '
        Me.cboperiodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos.FormattingEnabled = True
        Me.cboperiodos.Location = New System.Drawing.Point(18, 35)
        Me.cboperiodos.Name = "cboperiodos"
        Me.cboperiodos.Size = New System.Drawing.Size(124, 21)
        Me.cboperiodos.TabIndex = 30
        '
        'cboPerfin
        '
        Me.cboPerfin.FormattingEnabled = True
        Me.cboPerfin.Location = New System.Drawing.Point(20, 97)
        Me.cboPerfin.Name = "cboPerfin"
        Me.cboPerfin.Size = New System.Drawing.Size(121, 21)
        Me.cboPerfin.TabIndex = 13
        '
        'mskFecFin
        '
        Me.mskFecFin.Location = New System.Drawing.Point(50, 162)
        Me.mskFecFin.Mask = "00/00/0000"
        Me.mskFecFin.Name = "mskFecFin"
        Me.mskFecFin.Size = New System.Drawing.Size(86, 20)
        Me.mskFecFin.TabIndex = 12
        '
        'mskFecIni
        '
        Me.mskFecIni.Location = New System.Drawing.Point(50, 140)
        Me.mskFecIni.Mask = "00/00/0000"
        Me.mskFecIni.Name = "mskFecIni"
        Me.mskFecIni.Size = New System.Drawing.Size(82, 20)
        Me.mskFecIni.TabIndex = 11
        '
        'cboPerini
        '
        Me.cboPerini.FormattingEnabled = True
        Me.cboPerini.Location = New System.Drawing.Point(20, 75)
        Me.cboPerini.Name = "cboPerini"
        Me.cboPerini.Size = New System.Drawing.Size(121, 21)
        Me.cboPerini.TabIndex = 10
        '
        'optTipoImpre_0
        '
        Me.optTipoImpre_0.AutoSize = True
        Me.optTipoImpre_0.Checked = True
        Me.optTipoImpre_0.Location = New System.Drawing.Point(4, 19)
        Me.optTipoImpre_0.Name = "optTipoImpre_0"
        Me.optTipoImpre_0.Size = New System.Drawing.Size(79, 17)
        Me.optTipoImpre_0.TabIndex = 8
        Me.optTipoImpre_0.TabStop = True
        Me.optTipoImpre_0.Text = "Por periodo"
        Me.optTipoImpre_0.UseVisualStyleBackColor = True
        '
        'optTipoImpre_2
        '
        Me.optTipoImpre_2.AutoSize = True
        Me.optTipoImpre_2.Location = New System.Drawing.Point(4, 59)
        Me.optTipoImpre_2.Name = "optTipoImpre_2"
        Me.optTipoImpre_2.Size = New System.Drawing.Size(124, 17)
        Me.optTipoImpre_2.TabIndex = 7
        Me.optTipoImpre_2.Text = "Por rango de periodo"
        Me.optTipoImpre_2.UseVisualStyleBackColor = True
        '
        'optTipoImpre_1
        '
        Me.optTipoImpre_1.AutoSize = True
        Me.optTipoImpre_1.Location = New System.Drawing.Point(6, 121)
        Me.optTipoImpre_1.Name = "optTipoImpre_1"
        Me.optTipoImpre_1.Size = New System.Drawing.Size(76, 17)
        Me.optTipoImpre_1.TabIndex = 6
        Me.optTipoImpre_1.Text = "Por fechas"
        Me.optTipoImpre_1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_0)
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_1)
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(120, 66)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuentas"
        '
        'rbtMoneda_0
        '
        Me.rbtMoneda_0.AutoSize = True
        Me.rbtMoneda_0.Location = New System.Drawing.Point(6, 14)
        Me.rbtMoneda_0.Name = "rbtMoneda_0"
        Me.rbtMoneda_0.Size = New System.Drawing.Size(51, 17)
        Me.rbtMoneda_0.TabIndex = 11
        Me.rbtMoneda_0.Text = "Soles"
        Me.rbtMoneda_0.UseVisualStyleBackColor = True
        '
        'rbtMoneda_1
        '
        Me.rbtMoneda_1.AutoSize = True
        Me.rbtMoneda_1.Location = New System.Drawing.Point(6, 30)
        Me.rbtMoneda_1.Name = "rbtMoneda_1"
        Me.rbtMoneda_1.Size = New System.Drawing.Size(61, 17)
        Me.rbtMoneda_1.TabIndex = 10
        Me.rbtMoneda_1.Text = "Dolares"
        Me.rbtMoneda_1.UseVisualStyleBackColor = True
        '
        'rbtMoneda_2
        '
        Me.rbtMoneda_2.AutoSize = True
        Me.rbtMoneda_2.Checked = True
        Me.rbtMoneda_2.Location = New System.Drawing.Point(6, 48)
        Me.rbtMoneda_2.Name = "rbtMoneda_2"
        Me.rbtMoneda_2.Size = New System.Drawing.Size(98, 17)
        Me.rbtMoneda_2.TabIndex = 9
        Me.rbtMoneda_2.TabStop = True
        Me.rbtMoneda_2.Text = "Soles y Dolares"
        Me.rbtMoneda_2.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnseleccionartodo_1)
        Me.TabPage2.Controls.Add(Me.tblconsulta1)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(718, 265)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "General"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_1
        '
        Me.btnseleccionartodo_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_1.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_1.Location = New System.Drawing.Point(153, 12)
        Me.btnseleccionartodo_1.Name = "btnseleccionartodo_1"
        Me.btnseleccionartodo_1.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_1.TabIndex = 17
        Me.btnseleccionartodo_1.UseVisualStyleBackColor = True
        '
        'tblconsulta1
        '
        Me.tblconsulta1.AllowUpdate = False
        Me.tblconsulta1.AllowUpdateOnBlur = False
        Me.tblconsulta1.AlternatingRows = True
        Me.tblconsulta1.FilterBar = True
        Me.tblconsulta1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta1.Images.Add(CType(resources.GetObject("tblconsulta1.Images"), System.Drawing.Image))
        Me.tblconsulta1.LinesPerRow = 1
        Me.tblconsulta1.Location = New System.Drawing.Point(152, 10)
        Me.tblconsulta1.Name = "tblconsulta1"
        Me.tblconsulta1.PictureCurrentRow = CType(resources.GetObject("tblconsulta1.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta1.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta1.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta1.Size = New System.Drawing.Size(568, 248)
        Me.tblconsulta1.TabIndex = 16
        Me.tblconsulta1.TabStop = False
        Me.tblconsulta1.Text = "C1TrueDBGrid2"
        Me.tblconsulta1.UseColumnStyles = False
        Me.tblconsulta1.PropBag = resources.GetString("tblconsulta1.PropBag")
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.rbtTipRep_1)
        Me.GroupBox4.Controls.Add(Me.rbtTipRep_0)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 156)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(148, 100)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 50)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "El Reporte de Saldos Trabaja con cuentas >= a 7 digitos y que su septimo digito t" & _
            "iene que ser impar;y es basicamente para la 915,916,917"
        '
        'rbtTipRep_1
        '
        Me.rbtTipRep_1.AutoSize = True
        Me.rbtTipRep_1.Location = New System.Drawing.Point(12, 28)
        Me.rbtTipRep_1.Name = "rbtTipRep_1"
        Me.rbtTipRep_1.Size = New System.Drawing.Size(98, 17)
        Me.rbtTipRep_1.TabIndex = 7
        Me.rbtTipRep_1.TabStop = True
        Me.rbtTipRep_1.Text = "Reporte Saldos"
        Me.rbtTipRep_1.UseVisualStyleBackColor = True
        '
        'rbtTipRep_0
        '
        Me.rbtTipRep_0.AutoSize = True
        Me.rbtTipRep_0.Checked = True
        Me.rbtTipRep_0.Location = New System.Drawing.Point(12, 12)
        Me.rbtTipRep_0.Name = "rbtTipRep_0"
        Me.rbtTipRep_0.Size = New System.Drawing.Size(101, 17)
        Me.rbtTipRep_0.TabIndex = 6
        Me.rbtTipRep_0.TabStop = True
        Me.rbtTipRep_0.Text = "Reporte general"
        Me.rbtTipRep_0.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtNivel_0)
        Me.GroupBox3.Controls.Add(Me.rbtNivel_1)
        Me.GroupBox3.Controls.Add(Me.rbtNivel_6)
        Me.GroupBox3.Controls.Add(Me.rbtNivel_5)
        Me.GroupBox3.Controls.Add(Me.rbtNivel_4)
        Me.GroupBox3.Controls.Add(Me.rbtNivel_3)
        Me.GroupBox3.Controls.Add(Me.rbtNivel_2)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(146, 146)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'rbtNivel_0
        '
        Me.rbtNivel_0.AutoSize = True
        Me.rbtNivel_0.Checked = True
        Me.rbtNivel_0.Location = New System.Drawing.Point(14, 16)
        Me.rbtNivel_0.Name = "rbtNivel_0"
        Me.rbtNivel_0.Size = New System.Drawing.Size(130, 17)
        Me.rbtNivel_0.TabIndex = 13
        Me.rbtNivel_0.TabStop = True
        Me.rbtNivel_0.Text = "Cuenta hasta 2 digitos"
        Me.rbtNivel_0.UseVisualStyleBackColor = True
        '
        'rbtNivel_1
        '
        Me.rbtNivel_1.AutoSize = True
        Me.rbtNivel_1.Location = New System.Drawing.Point(14, 32)
        Me.rbtNivel_1.Name = "rbtNivel_1"
        Me.rbtNivel_1.Size = New System.Drawing.Size(130, 17)
        Me.rbtNivel_1.TabIndex = 12
        Me.rbtNivel_1.TabStop = True
        Me.rbtNivel_1.Text = "Cuenta hasta 3 digitos"
        Me.rbtNivel_1.UseVisualStyleBackColor = True
        '
        'rbtNivel_6
        '
        Me.rbtNivel_6.AutoSize = True
        Me.rbtNivel_6.Location = New System.Drawing.Point(14, 120)
        Me.rbtNivel_6.Name = "rbtNivel_6"
        Me.rbtNivel_6.Size = New System.Drawing.Size(138, 17)
        Me.rbtNivel_6.TabIndex = 7
        Me.rbtNivel_6.TabStop = True
        Me.rbtNivel_6.Text = "Cuenta mas de 9 digitos"
        Me.rbtNivel_6.UseVisualStyleBackColor = True
        '
        'rbtNivel_5
        '
        Me.rbtNivel_5.AutoSize = True
        Me.rbtNivel_5.Location = New System.Drawing.Point(14, 102)
        Me.rbtNivel_5.Name = "rbtNivel_5"
        Me.rbtNivel_5.Size = New System.Drawing.Size(130, 17)
        Me.rbtNivel_5.TabIndex = 8
        Me.rbtNivel_5.TabStop = True
        Me.rbtNivel_5.Text = "Cuenta hasta 9 digitos"
        Me.rbtNivel_5.UseVisualStyleBackColor = True
        '
        'rbtNivel_4
        '
        Me.rbtNivel_4.AutoSize = True
        Me.rbtNivel_4.Location = New System.Drawing.Point(14, 84)
        Me.rbtNivel_4.Name = "rbtNivel_4"
        Me.rbtNivel_4.Size = New System.Drawing.Size(130, 17)
        Me.rbtNivel_4.TabIndex = 9
        Me.rbtNivel_4.TabStop = True
        Me.rbtNivel_4.Text = "Cuenta hasta 7 digitos"
        Me.rbtNivel_4.UseVisualStyleBackColor = True
        '
        'rbtNivel_3
        '
        Me.rbtNivel_3.AutoSize = True
        Me.rbtNivel_3.Location = New System.Drawing.Point(14, 66)
        Me.rbtNivel_3.Name = "rbtNivel_3"
        Me.rbtNivel_3.Size = New System.Drawing.Size(130, 17)
        Me.rbtNivel_3.TabIndex = 10
        Me.rbtNivel_3.TabStop = True
        Me.rbtNivel_3.Text = "Cuenta hasta 5 digitos"
        Me.rbtNivel_3.UseVisualStyleBackColor = True
        '
        'rbtNivel_2
        '
        Me.rbtNivel_2.AutoSize = True
        Me.rbtNivel_2.Location = New System.Drawing.Point(14, 48)
        Me.rbtNivel_2.Name = "rbtNivel_2"
        Me.rbtNivel_2.Size = New System.Drawing.Size(130, 17)
        Me.rbtNivel_2.TabIndex = 11
        Me.rbtNivel_2.TabStop = True
        Me.rbtNivel_2.Text = "Cuenta hasta 4 digitos"
        Me.rbtNivel_2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 333)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(735, 28)
        Me.Panel3.TabIndex = 201
        '
        'Frm_LibroMayor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 361)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tabOpciones)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_LibroMayor"
        Me.Text = "Frm_LibroMayor"
        Me.Panel1.ResumeLayout(False)
        Me.tabOpciones.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tblconsulta1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents tabOpciones As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents cboPerfin As System.Windows.Forms.ComboBox
    Friend WithEvents mskFecFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFecIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboPerini As System.Windows.Forms.ComboBox
    Friend WithEvents optTipoImpre_0 As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoImpre_2 As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoImpre_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtMoneda_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMoneda_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMoneda_2 As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtTipRep_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipRep_0 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtNivel_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNivel_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNivel_6 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNivel_5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNivel_4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNivel_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNivel_2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_1 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents btn_verReporteReducido As System.Windows.Forms.Button
End Class
