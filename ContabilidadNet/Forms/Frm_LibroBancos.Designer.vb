<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LibroBancos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LibroBancos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtMoneda_0 = New System.Windows.Forms.RadioButton()
        Me.rbtMoneda_1 = New System.Windows.Forms.RadioButton()
        Me.rbtMoneda_2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.mskFecFin = New System.Windows.Forms.MaskedTextBox()
        Me.mskFecIni = New System.Windows.Forms.MaskedTextBox()
        Me.optTipoImpre_0 = New System.Windows.Forms.RadioButton()
        Me.optTipoImpre_1 = New System.Windows.Forms.RadioButton()
        Me.chkResumido = New System.Windows.Forms.CheckBox()
        Me.txtTitulo = New Ks.UserControl.ksTextBox()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 31)
        Me.Panel1.TabIndex = 5
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(342, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(696, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(318, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 320)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(724, 28)
        Me.Panel3.TabIndex = 202
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_0)
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_1)
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_2)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 78)
        Me.GroupBox1.TabIndex = 203
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Moneda"
        '
        'rbtMoneda_0
        '
        Me.rbtMoneda_0.AutoSize = True
        Me.rbtMoneda_0.Checked = True
        Me.rbtMoneda_0.Location = New System.Drawing.Point(6, 14)
        Me.rbtMoneda_0.Name = "rbtMoneda_0"
        Me.rbtMoneda_0.Size = New System.Drawing.Size(51, 17)
        Me.rbtMoneda_0.TabIndex = 11
        Me.rbtMoneda_0.TabStop = True
        Me.rbtMoneda_0.Text = "Soles"
        Me.rbtMoneda_0.UseVisualStyleBackColor = True
        '
        'rbtMoneda_1
        '
        Me.rbtMoneda_1.AutoSize = True
        Me.rbtMoneda_1.Location = New System.Drawing.Point(6, 34)
        Me.rbtMoneda_1.Name = "rbtMoneda_1"
        Me.rbtMoneda_1.Size = New System.Drawing.Size(61, 17)
        Me.rbtMoneda_1.TabIndex = 10
        Me.rbtMoneda_1.Text = "Dolares"
        Me.rbtMoneda_1.UseVisualStyleBackColor = True
        '
        'rbtMoneda_2
        '
        Me.rbtMoneda_2.AutoSize = True
        Me.rbtMoneda_2.Location = New System.Drawing.Point(6, 54)
        Me.rbtMoneda_2.Name = "rbtMoneda_2"
        Me.rbtMoneda_2.Size = New System.Drawing.Size(98, 17)
        Me.rbtMoneda_2.TabIndex = 9
        Me.rbtMoneda_2.Text = "Soles y Dolares"
        Me.rbtMoneda_2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboperiodos)
        Me.GroupBox2.Controls.Add(Me.mskFecFin)
        Me.GroupBox2.Controls.Add(Me.mskFecIni)
        Me.GroupBox2.Controls.Add(Me.optTipoImpre_0)
        Me.GroupBox2.Controls.Add(Me.optTipoImpre_1)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(152, 118)
        Me.GroupBox2.TabIndex = 204
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rango de Impresion"
        '
        'cboperiodos
        '
        Me.cboperiodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos.FormattingEnabled = True
        Me.cboperiodos.Location = New System.Drawing.Point(18, 30)
        Me.cboperiodos.Name = "cboperiodos"
        Me.cboperiodos.Size = New System.Drawing.Size(124, 21)
        Me.cboperiodos.TabIndex = 30
        '
        'mskFecFin
        '
        Me.mskFecFin.Location = New System.Drawing.Point(52, 94)
        Me.mskFecFin.Name = "mskFecFin"
        Me.mskFecFin.Size = New System.Drawing.Size(84, 20)
        Me.mskFecFin.TabIndex = 12
        '
        'mskFecIni
        '
        Me.mskFecIni.Location = New System.Drawing.Point(52, 72)
        Me.mskFecIni.Name = "mskFecIni"
        Me.mskFecIni.Size = New System.Drawing.Size(84, 20)
        Me.mskFecIni.TabIndex = 11
        '
        'optTipoImpre_0
        '
        Me.optTipoImpre_0.AutoSize = True
        Me.optTipoImpre_0.Checked = True
        Me.optTipoImpre_0.Location = New System.Drawing.Point(4, 14)
        Me.optTipoImpre_0.Name = "optTipoImpre_0"
        Me.optTipoImpre_0.Size = New System.Drawing.Size(79, 17)
        Me.optTipoImpre_0.TabIndex = 8
        Me.optTipoImpre_0.TabStop = True
        Me.optTipoImpre_0.Text = "Por periodo"
        Me.optTipoImpre_0.UseVisualStyleBackColor = True
        '
        'optTipoImpre_1
        '
        Me.optTipoImpre_1.AutoSize = True
        Me.optTipoImpre_1.Location = New System.Drawing.Point(6, 52)
        Me.optTipoImpre_1.Name = "optTipoImpre_1"
        Me.optTipoImpre_1.Size = New System.Drawing.Size(76, 17)
        Me.optTipoImpre_1.TabIndex = 6
        Me.optTipoImpre_1.Text = "Por fechas"
        Me.optTipoImpre_1.UseVisualStyleBackColor = True
        '
        'chkResumido
        '
        Me.chkResumido.AutoSize = True
        Me.chkResumido.Location = New System.Drawing.Point(6, 302)
        Me.chkResumido.Name = "chkResumido"
        Me.chkResumido.Size = New System.Drawing.Size(73, 17)
        Me.chkResumido.TabIndex = 205
        Me.chkResumido.Text = "Resumido"
        Me.chkResumido.UseVisualStyleBackColor = True
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New System.Drawing.Point(2, 234)
        Me.txtTitulo.Multiline = True
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.NroDecimales = CType(0, Short)
        Me.txtTitulo.SelectGotFocus = True
        Me.txtTitulo.Size = New System.Drawing.Size(152, 66)
        Me.txtTitulo.TabIndex = 206
        Me.txtTitulo.Tabulado = True
        Me.txtTitulo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
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
        Me.tblconsulta.Location = New System.Drawing.Point(164, 34)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(552, 282)
        Me.tblconsulta.TabIndex = 207
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(165, 35)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 229
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'Frm_LibroBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 348)
        Me.Controls.Add(Me.btnseleccionartodo_0)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.txtTitulo)
        Me.Controls.Add(Me.chkResumido)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_LibroBancos"
        Me.Text = "Frm_LibroBancos"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtMoneda_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMoneda_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMoneda_2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents mskFecFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFecIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents optTipoImpre_0 As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoImpre_1 As System.Windows.Forms.RadioButton
    Friend WithEvents chkResumido As System.Windows.Forms.CheckBox
    Friend WithEvents txtTitulo As KS.UserControl.ksTextBox
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
End Class
