<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImportarSIRE_VentasPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImportarSIRE_VentasPrincipal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsultadet = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsultaiguales = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnComparar = New System.Windows.Forms.Button()
        Me.BtnExportarVentas = New System.Windows.Forms.Button()
        Me.BtnRegistrarSire = New System.Windows.Forms.Button()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtLibro = New Ks.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta_SisireNoRegistroV = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta_igualcondatodiff = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta_SiregistroVNOsire = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.BtnExportarExcel = New System.Windows.Forms.Button()
        Me.BtnExportarSire = New System.Windows.Forms.Button()
        Me.BtnExportarRegVentas = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnVistaPrevia = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsultadet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsultaiguales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta_SisireNoRegistroV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta_igualcondatodiff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta_SiregistroVNOsire, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel3.Location = New System.Drawing.Point(0, 607)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1306, 26)
        Me.Panel3.TabIndex = 147
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
        Me.tblconsulta.Location = New System.Drawing.Point(25, 36)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(428, 115)
        Me.tblconsulta.TabIndex = 146
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
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
        Me.tblconsultadet.Location = New System.Drawing.Point(470, 36)
        Me.tblconsultadet.Name = "tblconsultadet"
        Me.tblconsultadet.PictureCurrentRow = CType(resources.GetObject("tblconsultadet.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsultadet.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsultadet.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsultadet.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsultadet.PrintInfo.PageSettings = CType(resources.GetObject("tblconsultadet.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsultadet.Size = New System.Drawing.Size(785, 115)
        Me.tblconsultadet.TabIndex = 148
        Me.tblconsultadet.TabStop = False
        Me.tblconsultadet.Text = "C1TrueDBGrid1"
        Me.tblconsultadet.UseColumnStyles = False
        Me.tblconsultadet.PropBag = resources.GetString("tblconsultadet.PropBag")
        '
        'tblconsultaiguales
        '
        Me.tblconsultaiguales.AllowUpdate = False
        Me.tblconsultaiguales.AllowUpdateOnBlur = False
        Me.tblconsultaiguales.AlternatingRows = True
        Me.tblconsultaiguales.FilterBar = True
        Me.tblconsultaiguales.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsultaiguales.Images.Add(CType(resources.GetObject("tblconsultaiguales.Images"), System.Drawing.Image))
        Me.tblconsultaiguales.LinesPerRow = 1
        Me.tblconsultaiguales.Location = New System.Drawing.Point(12, 205)
        Me.tblconsultaiguales.Name = "tblconsultaiguales"
        Me.tblconsultaiguales.PictureCurrentRow = CType(resources.GetObject("tblconsultaiguales.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsultaiguales.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsultaiguales.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsultaiguales.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsultaiguales.PrintInfo.PageSettings = CType(resources.GetObject("tblconsultaiguales.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsultaiguales.Size = New System.Drawing.Size(630, 115)
        Me.tblconsultaiguales.TabIndex = 149
        Me.tblconsultaiguales.TabStop = False
        Me.tblconsultaiguales.Text = "C1TrueDBGrid1"
        Me.tblconsultaiguales.UseColumnStyles = False
        Me.tblconsultaiguales.PropBag = resources.GetString("tblconsultaiguales.PropBag")
        '
        'btnComparar
        '
        Me.btnComparar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComparar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnComparar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnComparar.Location = New System.Drawing.Point(493, 157)
        Me.btnComparar.Name = "btnComparar"
        Me.btnComparar.Size = New System.Drawing.Size(258, 23)
        Me.btnComparar.TabIndex = 157
        Me.btnComparar.Text = "Comparar Sire vs Registro Ventas"
        Me.btnComparar.UseVisualStyleBackColor = True
        '
        'BtnExportarVentas
        '
        Me.BtnExportarVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarVentas.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.BtnExportarVentas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnExportarVentas.Location = New System.Drawing.Point(690, 523)
        Me.BtnExportarVentas.Name = "BtnExportarVentas"
        Me.BtnExportarVentas.Size = New System.Drawing.Size(93, 24)
        Me.BtnExportarVentas.TabIndex = 158
        Me.BtnExportarVentas.Text = "Exportar"
        Me.BtnExportarVentas.UseVisualStyleBackColor = True
        '
        'BtnRegistrarSire
        '
        Me.BtnRegistrarSire.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistrarSire.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.BtnRegistrarSire.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRegistrarSire.Location = New System.Drawing.Point(549, 323)
        Me.BtnRegistrarSire.Name = "BtnRegistrarSire"
        Me.BtnRegistrarSire.Size = New System.Drawing.Size(93, 24)
        Me.BtnRegistrarSire.TabIndex = 159
        Me.BtnRegistrarSire.Text = "Registrar"
        Me.BtnRegistrarSire.UseVisualStyleBackColor = True
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(86, 157)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 21)
        Me.btnhelp_0.TabIndex = 182
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(114, 159)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(208, 18)
        Me.lblhelp_0.TabIndex = 181
        Me.lblhelp_0.Text = "???"
        '
        'txtLibro
        '
        Me.txtLibro.BackColor = System.Drawing.Color.White
        Me.txtLibro.Location = New System.Drawing.Point(50, 157)
        Me.txtLibro.Name = "txtLibro"
        Me.txtLibro.NroDecimales = CType(0, Short)
        Me.txtLibro.SelectGotFocus = True
        Me.txtLibro.Size = New System.Drawing.Size(36, 20)
        Me.txtLibro.TabIndex = 180
        Me.txtLibro.Tabulado = True
        Me.txtLibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Libro"
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
        Me.tblhelp.Location = New System.Drawing.Point(114, 161)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(286, 116)
        Me.tblhelp.TabIndex = 197
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'tblconsulta_SisireNoRegistroV
        '
        Me.tblconsulta_SisireNoRegistroV.AllowUpdate = False
        Me.tblconsulta_SisireNoRegistroV.AllowUpdateOnBlur = False
        Me.tblconsulta_SisireNoRegistroV.AlternatingRows = True
        Me.tblconsulta_SisireNoRegistroV.FilterBar = True
        Me.tblconsulta_SisireNoRegistroV.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_SisireNoRegistroV.Images.Add(CType(resources.GetObject("tblconsulta_SisireNoRegistroV.Images"), System.Drawing.Image))
        Me.tblconsulta_SisireNoRegistroV.LinesPerRow = 1
        Me.tblconsulta_SisireNoRegistroV.Location = New System.Drawing.Point(15, 353)
        Me.tblconsulta_SisireNoRegistroV.Name = "tblconsulta_SisireNoRegistroV"
        Me.tblconsulta_SisireNoRegistroV.PictureCurrentRow = CType(resources.GetObject("tblconsulta_SisireNoRegistroV.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_SisireNoRegistroV.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_SisireNoRegistroV.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_SisireNoRegistroV.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_SisireNoRegistroV.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_SisireNoRegistroV.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_SisireNoRegistroV.Size = New System.Drawing.Size(630, 122)
        Me.tblconsulta_SisireNoRegistroV.TabIndex = 198
        Me.tblconsulta_SisireNoRegistroV.TabStop = False
        Me.tblconsulta_SisireNoRegistroV.Text = "C1TrueDBGrid1"
        Me.tblconsulta_SisireNoRegistroV.UseColumnStyles = False
        Me.tblconsulta_SisireNoRegistroV.PropBag = resources.GetString("tblconsulta_SisireNoRegistroV.PropBag")
        '
        'tblconsulta_igualcondatodiff
        '
        Me.tblconsulta_igualcondatodiff.AllowUpdate = False
        Me.tblconsulta_igualcondatodiff.AllowUpdateOnBlur = False
        Me.tblconsulta_igualcondatodiff.AlternatingRows = True
        Me.tblconsulta_igualcondatodiff.FilterBar = True
        Me.tblconsulta_igualcondatodiff.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_igualcondatodiff.Images.Add(CType(resources.GetObject("tblconsulta_igualcondatodiff.Images"), System.Drawing.Image))
        Me.tblconsulta_igualcondatodiff.LinesPerRow = 1
        Me.tblconsulta_igualcondatodiff.Location = New System.Drawing.Point(664, 205)
        Me.tblconsulta_igualcondatodiff.Name = "tblconsulta_igualcondatodiff"
        Me.tblconsulta_igualcondatodiff.PictureCurrentRow = CType(resources.GetObject("tblconsulta_igualcondatodiff.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_igualcondatodiff.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_igualcondatodiff.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_igualcondatodiff.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_igualcondatodiff.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_igualcondatodiff.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_igualcondatodiff.Size = New System.Drawing.Size(591, 115)
        Me.tblconsulta_igualcondatodiff.TabIndex = 199
        Me.tblconsulta_igualcondatodiff.TabStop = False
        Me.tblconsulta_igualcondatodiff.Text = "C1TrueDBGrid2"
        Me.tblconsulta_igualcondatodiff.UseColumnStyles = False
        Me.tblconsulta_igualcondatodiff.PropBag = resources.GetString("tblconsulta_igualcondatodiff.PropBag")
        '
        'tblconsulta_SiregistroVNOsire
        '
        Me.tblconsulta_SiregistroVNOsire.AllowUpdate = False
        Me.tblconsulta_SiregistroVNOsire.AllowUpdateOnBlur = False
        Me.tblconsulta_SiregistroVNOsire.AlternatingRows = True
        Me.tblconsulta_SiregistroVNOsire.FilterBar = True
        Me.tblconsulta_SiregistroVNOsire.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_SiregistroVNOsire.Images.Add(CType(resources.GetObject("tblconsulta_SiregistroVNOsire.Images"), System.Drawing.Image))
        Me.tblconsulta_SiregistroVNOsire.Images.Add(CType(resources.GetObject("tblconsulta_SiregistroVNOsire.Images1"), System.Drawing.Image))
        Me.tblconsulta_SiregistroVNOsire.Images.Add(CType(resources.GetObject("tblconsulta_SiregistroVNOsire.Images2"), System.Drawing.Image))
        Me.tblconsulta_SiregistroVNOsire.LinesPerRow = 1
        Me.tblconsulta_SiregistroVNOsire.Location = New System.Drawing.Point(664, 353)
        Me.tblconsulta_SiregistroVNOsire.Name = "tblconsulta_SiregistroVNOsire"
        Me.tblconsulta_SiregistroVNOsire.PictureCurrentRow = CType(resources.GetObject("tblconsulta_SiregistroVNOsire.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_SiregistroVNOsire.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_SiregistroVNOsire.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_SiregistroVNOsire.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_SiregistroVNOsire.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_SiregistroVNOsire.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_SiregistroVNOsire.Size = New System.Drawing.Size(591, 122)
        Me.tblconsulta_SiregistroVNOsire.TabIndex = 200
        Me.tblconsulta_SiregistroVNOsire.TabStop = False
        Me.tblconsulta_SiregistroVNOsire.Text = "C1TrueDBGrid3"
        Me.tblconsulta_SiregistroVNOsire.UseColumnStyles = False
        Me.tblconsulta_SiregistroVNOsire.PropBag = resources.GetString("tblconsulta_SiregistroVNOsire.PropBag")
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarExcel.Image = CType(resources.GetObject("BtnExportarExcel.Image"), System.Drawing.Image)
        Me.BtnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnExportarExcel.Location = New System.Drawing.Point(1233, 205)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Size = New System.Drawing.Size(22, 22)
        Me.BtnExportarExcel.TabIndex = 202
        Me.BtnExportarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportarExcel.UseVisualStyleBackColor = True
        '
        'BtnExportarSire
        '
        Me.BtnExportarSire.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarSire.Image = CType(resources.GetObject("BtnExportarSire.Image"), System.Drawing.Image)
        Me.BtnExportarSire.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnExportarSire.Location = New System.Drawing.Point(621, 356)
        Me.BtnExportarSire.Name = "BtnExportarSire"
        Me.BtnExportarSire.Size = New System.Drawing.Size(23, 22)
        Me.BtnExportarSire.TabIndex = 206
        Me.BtnExportarSire.UseVisualStyleBackColor = True
        '
        'BtnExportarRegVentas
        '
        Me.BtnExportarRegVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarRegVentas.Image = CType(resources.GetObject("BtnExportarRegVentas.Image"), System.Drawing.Image)
        Me.BtnExportarRegVentas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnExportarRegVentas.Location = New System.Drawing.Point(1229, 352)
        Me.BtnExportarRegVentas.Name = "BtnExportarRegVentas"
        Me.BtnExportarRegVentas.Size = New System.Drawing.Size(24, 22)
        Me.BtnExportarRegVentas.TabIndex = 207
        Me.BtnExportarRegVentas.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 329)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 208
        Me.Label3.Text = "Sire [SI] - Reg. Ven [NO]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(661, 329)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 13)
        Me.Label4.TabIndex = 209
        Me.Label4.Text = "Reg. Ven [SI] - Sire [NO]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Reg. Ven = SIRE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(661, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 13)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Reg. Ven = SIRE con Diferencias"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.Button1.Location = New System.Drawing.Point(664, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 212
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(1246, 31)
        Me.Label6.TabIndex = 213
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(25, 548)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1121, 10)
        Me.GroupBox3.TabIndex = 282
        Me.GroupBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 529)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 281
        Me.Label8.Text = "Reg.Ventas"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(258, 529)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(412, 13)
        Me.Label9.TabIndex = 280
        Me.Label9.Text = "Archivo Anexo 03 - Remplazar propuesta de SIRE - Con datos del registro de compra" & _
            "s"
        '
        'BtnVistaPrevia
        '
        Me.BtnVistaPrevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVistaPrevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.BtnVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnVistaPrevia.Location = New System.Drawing.Point(109, 523)
        Me.BtnVistaPrevia.Name = "BtnVistaPrevia"
        Me.BtnVistaPrevia.Size = New System.Drawing.Size(119, 24)
        Me.BtnVistaPrevia.TabIndex = 279
        Me.BtnVistaPrevia.Text = "Vista Previa"
        Me.BtnVistaPrevia.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(134, 504)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1012, 10)
        Me.GroupBox1.TabIndex = 278
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 504)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 277
        Me.Label7.Text = "Registro Ventas"
        '
        'Frm_ImportarSIRE_VentasPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1306, 633)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnVistaPrevia)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnExportarRegVentas)
        Me.Controls.Add(Me.BtnExportarSire)
        Me.Controls.Add(Me.BtnExportarExcel)
        Me.Controls.Add(Me.tblconsulta_SiregistroVNOsire)
        Me.Controls.Add(Me.tblconsulta_igualcondatodiff)
        Me.Controls.Add(Me.tblconsulta_SisireNoRegistroV)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txtLibro)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnRegistrarSire)
        Me.Controls.Add(Me.BtnExportarVentas)
        Me.Controls.Add(Me.btnComparar)
        Me.Controls.Add(Me.tblconsultaiguales)
        Me.Controls.Add(Me.tblconsultadet)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Label6)
        Me.Name = "Frm_ImportarSIRE_VentasPrincipal"
        Me.Text = "Importar Ventas"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsultadet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsultaiguales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta_SisireNoRegistroV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta_igualcondatodiff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta_SiregistroVNOsire, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsultadet As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsultaiguales As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnComparar As System.Windows.Forms.Button
    Friend WithEvents BtnExportarVentas As System.Windows.Forms.Button
    Friend WithEvents BtnRegistrarSire As System.Windows.Forms.Button
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtLibro As KS.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsulta_SisireNoRegistroV As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsulta_igualcondatodiff As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsulta_SiregistroVNOsire As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents BtnExportarSire As System.Windows.Forms.Button
    Friend WithEvents BtnExportarRegVentas As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
