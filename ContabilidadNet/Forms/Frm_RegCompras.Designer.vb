<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegCompras))
        Me.sstabregcompras = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtPagina = New KS.UserControl.ksTextBox()
        Me.txtLibro = New KS.UserControl.ksTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtnroorden = New KS.UserControl.ksTextBox()
        Me.txtnroformulario = New KS.UserControl.ksTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtfiltro_2 = New System.Windows.Forms.RadioButton()
        Me.rbtfiltro_1 = New System.Windows.Forms.RadioButton()
        Me.chkordena = New System.Windows.Forms.CheckBox()
        Me.chkagrupa = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnregdonaciones = New System.Windows.Forms.Button()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.sstabregcompras.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'sstabregcompras
        '
        Me.sstabregcompras.Controls.Add(Me.TabPage1)
        Me.sstabregcompras.Controls.Add(Me.TabPage2)
        Me.sstabregcompras.Location = New System.Drawing.Point(2, 38)
        Me.sstabregcompras.Name = "sstabregcompras"
        Me.sstabregcompras.SelectedIndex = 0
        Me.sstabregcompras.Size = New System.Drawing.Size(329, 146)
        Me.sstabregcompras.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnhelp_0)
        Me.TabPage1.Controls.Add(Me.lblhelp_0)
        Me.TabPage1.Controls.Add(Me.txtPagina)
        Me.TabPage1.Controls.Add(Me.txtLibro)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(321, 120)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro de compras"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.tblhelp.Location = New System.Drawing.Point(206, 223)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(286, 116)
        Me.tblhelp.TabIndex = 195
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(74, 4)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 174
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(96, 5)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(208, 18)
        Me.lblhelp_0.TabIndex = 173
        Me.lblhelp_0.Text = "???"
        '
        'txtPagina
        '
        Me.txtPagina.Location = New System.Drawing.Point(252, 28)
        Me.txtPagina.Name = "txtPagina"
        Me.txtPagina.NroDecimales = CType(0, Short)
        Me.txtPagina.SelectGotFocus = True
        Me.txtPagina.Size = New System.Drawing.Size(52, 20)
        Me.txtPagina.TabIndex = 4
        Me.txtPagina.Tabulado = True
        Me.txtPagina.Text = "0"
        Me.txtPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPagina.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtLibro
        '
        Me.txtLibro.BackColor = System.Drawing.Color.White
        Me.txtLibro.Location = New System.Drawing.Point(38, 6)
        Me.txtLibro.Name = "txtLibro"
        Me.txtLibro.NroDecimales = CType(0, Short)
        Me.txtLibro.SelectGotFocus = True
        Me.txtLibro.Size = New System.Drawing.Size(36, 20)
        Me.txtLibro.TabIndex = 3
        Me.txtLibro.Tabulado = True
        Me.txtLibro.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtnroorden)
        Me.GroupBox1.Controls.Add(Me.txtnroformulario)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 50)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos para no domiciliados"
        '
        'txtnroorden
        '
        Me.txtnroorden.Location = New System.Drawing.Point(196, 12)
        Me.txtnroorden.Name = "txtnroorden"
        Me.txtnroorden.NroDecimales = CType(0, Short)
        Me.txtnroorden.SelectGotFocus = True
        Me.txtnroorden.Size = New System.Drawing.Size(96, 20)
        Me.txtnroorden.TabIndex = 3
        Me.txtnroorden.Tabulado = True
        Me.txtnroorden.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'txtnroformulario
        '
        Me.txtnroformulario.Location = New System.Drawing.Point(74, 14)
        Me.txtnroformulario.Name = "txtnroformulario"
        Me.txtnroformulario.NroDecimales = CType(0, Short)
        Me.txtnroformulario.SelectGotFocus = True
        Me.txtnroformulario.Size = New System.Drawing.Size(60, 20)
        Me.txtnroformulario.TabIndex = 2
        Me.txtnroformulario.Tabulado = True
        Me.txtnroformulario.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(140, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nro Orden"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nro Formulario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(84, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ingresar numero de pagina inicial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Libro"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.chkordena)
        Me.TabPage2.Controls.Add(Me.chkagrupa)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(321, 120)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Opciones Avanzadas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtfiltro_2)
        Me.GroupBox2.Controls.Add(Me.rbtfiltro_1)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(287, 68)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtrar por"
        '
        'rbtfiltro_2
        '
        Me.rbtfiltro_2.AutoSize = True
        Me.rbtfiltro_2.Location = New System.Drawing.Point(6, 42)
        Me.rbtfiltro_2.Name = "rbtfiltro_2"
        Me.rbtfiltro_2.Size = New System.Drawing.Size(238, 17)
        Me.rbtfiltro_2.TabIndex = 6
        Me.rbtfiltro_2.TabStop = True
        Me.rbtfiltro_2.Text = "Filtrar Documentos sin retencion ò detraccion"
        Me.rbtfiltro_2.UseVisualStyleBackColor = True
        '
        'rbtfiltro_1
        '
        Me.rbtfiltro_1.AutoSize = True
        Me.rbtfiltro_1.Location = New System.Drawing.Point(6, 19)
        Me.rbtfiltro_1.Name = "rbtfiltro_1"
        Me.rbtfiltro_1.Size = New System.Drawing.Size(185, 17)
        Me.rbtfiltro_1.TabIndex = 5
        Me.rbtfiltro_1.TabStop = True
        Me.rbtfiltro_1.Text = "Filtrar documentos con detraccion"
        Me.rbtfiltro_1.UseVisualStyleBackColor = True
        '
        'chkordena
        '
        Me.chkordena.AutoSize = True
        Me.chkordena.Location = New System.Drawing.Point(14, 6)
        Me.chkordena.Name = "chkordena"
        Me.chkordena.Size = New System.Drawing.Size(125, 17)
        Me.chkordena.TabIndex = 1
        Me.chkordena.Text = "Ordenar por Voucher"
        Me.chkordena.UseVisualStyleBackColor = True
        '
        'chkagrupa
        '
        Me.chkagrupa.AutoSize = True
        Me.chkagrupa.Location = New System.Drawing.Point(146, 6)
        Me.chkagrupa.Name = "chkagrupa"
        Me.chkagrupa.Size = New System.Drawing.Size(172, 17)
        Me.chkagrupa.TabIndex = 0
        Me.chkagrupa.Text = "Agrupar por tipo de documento"
        Me.chkagrupa.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 371)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(830, 28)
        Me.Panel3.TabIndex = 138
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnexportar)
        Me.Panel1.Controls.Add(Me.btnregdonaciones)
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 31)
        Me.Panel1.TabIndex = 139
        '
        'btnexportar
        '
        Me.btnexportar.Image = Global.ContabilidadNet.My.Resources.Resources.exportar
        Me.btnexportar.Location = New System.Drawing.Point(238, 0)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(24, 24)
        Me.btnexportar.TabIndex = 22
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'btnregdonaciones
        '
        Me.btnregdonaciones.Image = Global.ContabilidadNet.My.Resources.Resources.Plactas2
        Me.btnregdonaciones.Location = New System.Drawing.Point(8, 0)
        Me.btnregdonaciones.Name = "btnregdonaciones"
        Me.btnregdonaciones.Size = New System.Drawing.Size(24, 24)
        Me.btnregdonaciones.TabIndex = 21
        Me.btnregdonaciones.UseVisualStyleBackColor = True
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(164, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(141, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(316, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Frm_RegCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 399)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.sstabregcompras)
        Me.Name = "Frm_RegCompras"
        Me.Text = "Frm_RegCompras"
        Me.sstabregcompras.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sstabregcompras As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtLibro As KS.UserControl.ksTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPagina As KS.UserControl.ksTextBox
    Friend WithEvents txtnroorden As KS.UserControl.ksTextBox
    Friend WithEvents txtnroformulario As KS.UserControl.ksTextBox
    Friend WithEvents chkordena As System.Windows.Forms.CheckBox
    Friend WithEvents chkagrupa As System.Windows.Forms.CheckBox
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnregdonaciones As System.Windows.Forms.Button
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtfiltro_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtfiltro_1 As System.Windows.Forms.RadioButton
End Class
