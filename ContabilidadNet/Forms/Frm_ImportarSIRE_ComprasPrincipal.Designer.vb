<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImportarSIRE_ComprasPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImportarSIRE_ComprasPrincipal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtLibro = New Ks.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnComparar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.BtnExportarSire = New System.Windows.Forms.Button()
        Me.btnExportarRegVentas = New System.Windows.Forms.Button()
        Me.BtnExportarExcel = New System.Windows.Forms.Button()
        Me.tblconsulta_SIregistroCNOsire = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.BtnRegistrar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.tblconsultaiguales = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsultadet = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta_igualcondatodiff = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta_SIsireNOregistroC = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnVistaPrevia = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta_SIregistroCNOsire, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsultaiguales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsultadet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta_igualcondatodiff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta_SIsireNOregistroC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnImportar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1306, 30)
        Me.Panel1.TabIndex = 145
        '
        'btnImportar
        '
        Me.btnImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnImportar.Location = New System.Drawing.Point(6, 1)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(93, 24)
        Me.btnImportar.TabIndex = 23
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 578)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1306, 26)
        Me.Panel3.TabIndex = 147
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(649, 329)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 13)
        Me.Label4.TabIndex = 167
        Me.Label4.Text = "Reg. Com [SI] - Sire [NO]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 329)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 13)
        Me.Label3.TabIndex = 166
        Me.Label3.Text = "Sire [SI] - Reg. Com [NO]"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(74, 12)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 21)
        Me.btnhelp_0.TabIndex = 178
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(102, 12)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(208, 18)
        Me.lblhelp_0.TabIndex = 177
        Me.lblhelp_0.Text = "???"
        '
        'txtLibro
        '
        Me.txtLibro.BackColor = System.Drawing.Color.White
        Me.txtLibro.Location = New System.Drawing.Point(38, 12)
        Me.txtLibro.Name = "txtLibro"
        Me.txtLibro.NroDecimales = CType(0, Short)
        Me.txtLibro.SelectGotFocus = True
        Me.txtLibro.Size = New System.Drawing.Size(36, 20)
        Me.txtLibro.TabIndex = 176
        Me.txtLibro.Tabulado = True
        Me.txtLibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "Libro"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Reg. Com = SIRE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(649, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 13)
        Me.Label2.TabIndex = 207
        Me.Label2.Text = "Reg. Com = SIRE con Diferencias"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnComparar)
        Me.GroupBox2.Controls.Add(Me.txtLibro)
        Me.GroupBox2.Controls.Add(Me.lblhelp_0)
        Me.GroupBox2.Controls.Add(Me.btnhelp_0)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1279, 33)
        Me.GroupBox2.TabIndex = 266
        Me.GroupBox2.TabStop = False
        '
        'btnComparar
        '
        Me.btnComparar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComparar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnComparar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnComparar.Location = New System.Drawing.Point(316, 8)
        Me.btnComparar.Name = "btnComparar"
        Me.btnComparar.Size = New System.Drawing.Size(251, 24)
        Me.btnComparar.TabIndex = 168
        Me.btnComparar.Text = "Comparar Sire vs Registro Compras"
        Me.btnComparar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 267
        Me.Label6.Text = "Reg. Com = SIRE"
        '
        'tblhelp
        '
        Me.tblhelp.AllowUpdate = False
        Me.tblhelp.AllowUpdateOnBlur = False
        Me.tblhelp.AlternatingRows = True
        Me.tblhelp.FilterBar = True
        Me.tblhelp.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblhelp.Images.Add(CType(resources.GetObject("tblhelp.Images"), System.Drawing.Image))
        Me.tblhelp.LinesPerRow = 1
        Me.tblhelp.Location = New System.Drawing.Point(167, 143)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(286, 116)
        Me.tblhelp.TabIndex = 196
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'BtnExportarSire
        '
        Me.BtnExportarSire.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarSire.Image = CType(resources.GetObject("BtnExportarSire.Image"), System.Drawing.Image)
        Me.BtnExportarSire.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnExportarSire.Location = New System.Drawing.Point(609, 346)
        Me.BtnExportarSire.Name = "BtnExportarSire"
        Me.BtnExportarSire.Size = New System.Drawing.Size(23, 22)
        Me.BtnExportarSire.TabIndex = 205
        Me.BtnExportarSire.UseVisualStyleBackColor = True
        '
        'btnExportarRegVentas
        '
        Me.btnExportarRegVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarRegVentas.Image = CType(resources.GetObject("btnExportarRegVentas.Image"), System.Drawing.Image)
        Me.btnExportarRegVentas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnExportarRegVentas.Location = New System.Drawing.Point(1251, 345)
        Me.btnExportarRegVentas.Name = "btnExportarRegVentas"
        Me.btnExportarRegVentas.Size = New System.Drawing.Size(23, 23)
        Me.btnExportarRegVentas.TabIndex = 204
        Me.btnExportarRegVentas.UseVisualStyleBackColor = True
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarExcel.Image = CType(resources.GetObject("BtnExportarExcel.Image"), System.Drawing.Image)
        Me.BtnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnExportarExcel.Location = New System.Drawing.Point(1251, 185)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Size = New System.Drawing.Size(23, 22)
        Me.BtnExportarExcel.TabIndex = 203
        Me.BtnExportarExcel.UseVisualStyleBackColor = True
        '
        'tblconsulta_SIregistroCNOsire
        '
        Me.tblconsulta_SIregistroCNOsire.AllowUpdate = False
        Me.tblconsulta_SIregistroCNOsire.AllowUpdateOnBlur = False
        Me.tblconsulta_SIregistroCNOsire.AlternatingRows = True
        Me.tblconsulta_SIregistroCNOsire.FilterBar = True
        Me.tblconsulta_SIregistroCNOsire.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_SIregistroCNOsire.Images.Add(CType(resources.GetObject("tblconsulta_SIregistroCNOsire.Images"), System.Drawing.Image))
        Me.tblconsulta_SIregistroCNOsire.Images.Add(CType(resources.GetObject("tblconsulta_SIregistroCNOsire.Images1"), System.Drawing.Image))
        Me.tblconsulta_SIregistroCNOsire.Images.Add(CType(resources.GetObject("tblconsulta_SIregistroCNOsire.Images2"), System.Drawing.Image))
        Me.tblconsulta_SIregistroCNOsire.LinesPerRow = 1
        Me.tblconsulta_SIregistroCNOsire.Location = New System.Drawing.Point(652, 346)
        Me.tblconsulta_SIregistroCNOsire.Name = "tblconsulta_SIregistroCNOsire"
        Me.tblconsulta_SIregistroCNOsire.PictureCurrentRow = CType(resources.GetObject("tblconsulta_SIregistroCNOsire.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_SIregistroCNOsire.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_SIregistroCNOsire.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_SIregistroCNOsire.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_SIregistroCNOsire.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_SIregistroCNOsire.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_SIregistroCNOsire.Size = New System.Drawing.Size(622, 135)
        Me.tblconsulta_SIregistroCNOsire.TabIndex = 199
        Me.tblconsulta_SIregistroCNOsire.TabStop = False
        Me.tblconsulta_SIregistroCNOsire.Text = "C1TrueDBGrid1"
        Me.tblconsulta_SIregistroCNOsire.UseColumnStyles = False
        Me.tblconsulta_SIregistroCNOsire.PropBag = resources.GetString("tblconsulta_SIregistroCNOsire.PropBag")
        '
        'BtnRegistrar
        '
        Me.BtnRegistrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistrar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRegistrar.Location = New System.Drawing.Point(539, 322)
        Me.BtnRegistrar.Name = "BtnRegistrar"
        Me.BtnRegistrar.Size = New System.Drawing.Size(93, 24)
        Me.BtnRegistrar.TabIndex = 170
        Me.BtnRegistrar.Text = "Registrar"
        Me.BtnRegistrar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnExportar.Location = New System.Drawing.Point(730, 517)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(96, 24)
        Me.btnExportar.TabIndex = 169
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'tblconsultaiguales
        '
        Me.tblconsultaiguales.AllowUpdate = False
        Me.tblconsultaiguales.AllowUpdateOnBlur = False
        Me.tblconsultaiguales.AlternatingRows = True
        Me.tblconsultaiguales.FilterBar = True
        Me.tblconsultaiguales.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsultaiguales.Images.Add(CType(resources.GetObject("tblconsultaiguales.Images"), System.Drawing.Image))
        Me.tblconsultaiguales.Images.Add(CType(resources.GetObject("tblconsultaiguales.Images1"), System.Drawing.Image))
        Me.tblconsultaiguales.Images.Add(CType(resources.GetObject("tblconsultaiguales.Images2"), System.Drawing.Image))
        Me.tblconsultaiguales.LinesPerRow = 1
        Me.tblconsultaiguales.Location = New System.Drawing.Point(25, 182)
        Me.tblconsultaiguales.Name = "tblconsultaiguales"
        Me.tblconsultaiguales.PictureCurrentRow = CType(resources.GetObject("tblconsultaiguales.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsultaiguales.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsultaiguales.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsultaiguales.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsultaiguales.PrintInfo.PageSettings = CType(resources.GetObject("tblconsultaiguales.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsultaiguales.Size = New System.Drawing.Size(607, 134)
        Me.tblconsultaiguales.TabIndex = 163
        Me.tblconsultaiguales.TabStop = False
        Me.tblconsultaiguales.Text = "C1TrueDBGrid1"
        Me.tblconsultaiguales.UseColumnStyles = False
        Me.tblconsultaiguales.PropBag = resources.GetString("tblconsultaiguales.PropBag")
        '
        'tblconsultadet
        '
        Me.tblconsultadet.AllowUpdate = False
        Me.tblconsultadet.AllowUpdateOnBlur = False
        Me.tblconsultadet.AlternatingRows = True
        Me.tblconsultadet.FilterBar = True
        Me.tblconsultadet.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsultadet.Images.Add(CType(resources.GetObject("tblconsultadet.Images"), System.Drawing.Image))
        Me.tblconsultadet.Images.Add(CType(resources.GetObject("tblconsultadet.Images1"), System.Drawing.Image))
        Me.tblconsultadet.Images.Add(CType(resources.GetObject("tblconsultadet.Images2"), System.Drawing.Image))
        Me.tblconsultadet.LinesPerRow = 1
        Me.tblconsultadet.Location = New System.Drawing.Point(471, 36)
        Me.tblconsultadet.Name = "tblconsultadet"
        Me.tblconsultadet.PictureCurrentRow = CType(resources.GetObject("tblconsultadet.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsultadet.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsultadet.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsultadet.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsultadet.PrintInfo.PageSettings = CType(resources.GetObject("tblconsultadet.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsultadet.Size = New System.Drawing.Size(815, 95)
        Me.tblconsultadet.TabIndex = 148
        Me.tblconsultadet.TabStop = False
        Me.tblconsultadet.Text = "C1TrueDBGrid1"
        Me.tblconsultadet.UseColumnStyles = False
        Me.tblconsultadet.PropBag = resources.GetString("tblconsultadet.PropBag")
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
        Me.tblconsulta.Location = New System.Drawing.Point(0, 36)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(453, 95)
        Me.tblconsulta.TabIndex = 146
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'tblconsulta_igualcondatodiff
        '
        Me.tblconsulta_igualcondatodiff.AllowUpdate = False
        Me.tblconsulta_igualcondatodiff.AllowUpdateOnBlur = False
        Me.tblconsulta_igualcondatodiff.AlternatingRows = True
        Me.tblconsulta_igualcondatodiff.FilterBar = True
        Me.tblconsulta_igualcondatodiff.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_igualcondatodiff.Images.Add(CType(resources.GetObject("tblconsulta_igualcondatodiff.Images"), System.Drawing.Image))
        Me.tblconsulta_igualcondatodiff.Images.Add(CType(resources.GetObject("tblconsulta_igualcondatodiff.Images1"), System.Drawing.Image))
        Me.tblconsulta_igualcondatodiff.Images.Add(CType(resources.GetObject("tblconsulta_igualcondatodiff.Images2"), System.Drawing.Image))
        Me.tblconsulta_igualcondatodiff.LinesPerRow = 1
        Me.tblconsulta_igualcondatodiff.Location = New System.Drawing.Point(653, 183)
        Me.tblconsulta_igualcondatodiff.Name = "tblconsulta_igualcondatodiff"
        Me.tblconsulta_igualcondatodiff.PictureCurrentRow = CType(resources.GetObject("tblconsulta_igualcondatodiff.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_igualcondatodiff.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_igualcondatodiff.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_igualcondatodiff.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_igualcondatodiff.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_igualcondatodiff.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_igualcondatodiff.Size = New System.Drawing.Size(623, 134)
        Me.tblconsulta_igualcondatodiff.TabIndex = 268
        Me.tblconsulta_igualcondatodiff.TabStop = False
        Me.tblconsulta_igualcondatodiff.Text = "C1TrueDBGrid1"
        Me.tblconsulta_igualcondatodiff.UseColumnStyles = False
        Me.tblconsulta_igualcondatodiff.PropBag = resources.GetString("tblconsulta_igualcondatodiff.PropBag")
        '
        'tblconsulta_SIsireNOregistroC
        '
        Me.tblconsulta_SIsireNOregistroC.AllowUpdate = False
        Me.tblconsulta_SIsireNOregistroC.AllowUpdateOnBlur = False
        Me.tblconsulta_SIsireNOregistroC.AlternatingRows = True
        Me.tblconsulta_SIsireNOregistroC.FilterBar = True
        Me.tblconsulta_SIsireNOregistroC.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_SIsireNOregistroC.Images.Add(CType(resources.GetObject("tblconsulta_SIsireNOregistroC.Images"), System.Drawing.Image))
        Me.tblconsulta_SIsireNOregistroC.LinesPerRow = 1
        Me.tblconsulta_SIsireNOregistroC.Location = New System.Drawing.Point(25, 345)
        Me.tblconsulta_SIsireNOregistroC.Name = "tblconsulta_SIsireNOregistroC"
        Me.tblconsulta_SIsireNOregistroC.PictureCurrentRow = CType(resources.GetObject("tblconsulta_SIsireNOregistroC.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_SIsireNOregistroC.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_SIsireNOregistroC.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_SIsireNOregistroC.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_SIsireNOregistroC.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_SIsireNOregistroC.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_SIsireNOregistroC.Size = New System.Drawing.Size(607, 136)
        Me.tblconsulta_SIsireNOregistroC.TabIndex = 269
        Me.tblconsulta_SIsireNOregistroC.TabStop = False
        Me.tblconsulta_SIsireNOregistroC.Text = "C1TrueDBGrid1"
        Me.tblconsulta_SIsireNOregistroC.UseColumnStyles = False
        Me.tblconsulta_SIsireNOregistroC.PropBag = resources.GetString("tblconsulta_SIsireNOregistroC.PropBag")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 498)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 270
        Me.Label7.Text = "Registro Compras"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(134, 498)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1012, 10)
        Me.GroupBox1.TabIndex = 271
        Me.GroupBox1.TabStop = False
        '
        'BtnVistaPrevia
        '
        Me.BtnVistaPrevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVistaPrevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.BtnVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnVistaPrevia.Location = New System.Drawing.Point(109, 517)
        Me.BtnVistaPrevia.Name = "BtnVistaPrevia"
        Me.BtnVistaPrevia.Size = New System.Drawing.Size(119, 24)
        Me.BtnVistaPrevia.TabIndex = 272
        Me.BtnVistaPrevia.Text = "Vista Previa"
        Me.BtnVistaPrevia.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(260, 523)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(412, 13)
        Me.Label9.TabIndex = 274
        Me.Label9.Text = "Archivo Anexo 11 - Remplazar propuesta de SIRE - Con datos del registro de compra" & _
            "s"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 523)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "Reg.Compras"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(25, 542)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1121, 10)
        Me.GroupBox3.TabIndex = 276
        Me.GroupBox3.TabStop = False
        '
        'Frm_ImportarSIRE_ComprasPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1306, 604)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnVistaPrevia)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BtnExportarSire)
        Me.Controls.Add(Me.tblconsulta_SIsireNOregistroC)
        Me.Controls.Add(Me.BtnExportarExcel)
        Me.Controls.Add(Me.tblconsulta_igualcondatodiff)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExportarRegVentas)
        Me.Controls.Add(Me.tblconsulta_SIregistroCNOsire)
        Me.Controls.Add(Me.BtnRegistrar)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tblconsultaiguales)
        Me.Controls.Add(Me.tblconsultadet)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tblconsulta)
        Me.Name = "Frm_ImportarSIRE_ComprasPrincipal"
        Me.Text = "Importar Compras"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta_SIregistroCNOsire, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsultaiguales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsultadet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta_igualcondatodiff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta_SIsireNOregistroC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsultadet As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnRegistrar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnComparar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tblconsultaiguales As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtLibro As KS.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsulta_SIregistroCNOsire As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents btnExportarRegVentas As System.Windows.Forms.Button
    Friend WithEvents BtnExportarSire As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tblconsulta_igualcondatodiff As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsulta_SIsireNOregistroC As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
