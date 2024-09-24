<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Analisis6con9
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Analisis6con9))
        Me.rbtdistribucion_1 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.rbtdistribucion_0 = New System.Windows.Forms.RadioButton()
        Me.rbtTipoImpre_0 = New System.Windows.Forms.RadioButton()
        Me.rbtTipoImpre_1 = New System.Windows.Forms.RadioButton()
        Me.rbtTiporeporte_0 = New System.Windows.Forms.RadioButton()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboperiodos_0 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboperiodos_1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbolencta9 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtTiporeporte_1 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbolencta6 = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbtdistribucion_1
        '
        Me.rbtdistribucion_1.AutoSize = True
        Me.rbtdistribucion_1.Location = New System.Drawing.Point(93, 20)
        Me.rbtdistribucion_1.Name = "rbtdistribucion_1"
        Me.rbtdistribucion_1.Size = New System.Drawing.Size(79, 17)
        Me.rbtdistribucion_1.TabIndex = 33
        Me.rbtdistribucion_1.Text = "Distribuidos"
        Me.rbtdistribucion_1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 31)
        Me.Panel1.TabIndex = 206
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(318, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(294, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(610, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'rbtdistribucion_0
        '
        Me.rbtdistribucion_0.AutoSize = True
        Me.rbtdistribucion_0.Checked = True
        Me.rbtdistribucion_0.Location = New System.Drawing.Point(11, 20)
        Me.rbtdistribucion_0.Name = "rbtdistribucion_0"
        Me.rbtdistribucion_0.Size = New System.Drawing.Size(81, 17)
        Me.rbtdistribucion_0.TabIndex = 32
        Me.rbtdistribucion_0.TabStop = True
        Me.rbtdistribucion_0.Text = "Sin distribuir"
        Me.rbtdistribucion_0.UseVisualStyleBackColor = True
        '
        'rbtTipoImpre_0
        '
        Me.rbtTipoImpre_0.AutoSize = True
        Me.rbtTipoImpre_0.Location = New System.Drawing.Point(12, 32)
        Me.rbtTipoImpre_0.Name = "rbtTipoImpre_0"
        Me.rbtTipoImpre_0.Size = New System.Drawing.Size(75, 17)
        Me.rbtTipoImpre_0.TabIndex = 13
        Me.rbtTipoImpre_0.Text = "Por Meses"
        Me.rbtTipoImpre_0.UseVisualStyleBackColor = True
        '
        'rbtTipoImpre_1
        '
        Me.rbtTipoImpre_1.AutoSize = True
        Me.rbtTipoImpre_1.Checked = True
        Me.rbtTipoImpre_1.Location = New System.Drawing.Point(12, 14)
        Me.rbtTipoImpre_1.Name = "rbtTipoImpre_1"
        Me.rbtTipoImpre_1.Size = New System.Drawing.Size(78, 17)
        Me.rbtTipoImpre_1.TabIndex = 12
        Me.rbtTipoImpre_1.TabStop = True
        Me.rbtTipoImpre_1.Text = "Acumulado"
        Me.rbtTipoImpre_1.UseVisualStyleBackColor = True
        '
        'rbtTiporeporte_0
        '
        Me.rbtTiporeporte_0.AutoSize = True
        Me.rbtTiporeporte_0.Checked = True
        Me.rbtTiporeporte_0.Location = New System.Drawing.Point(6, 17)
        Me.rbtTiporeporte_0.Name = "rbtTiporeporte_0"
        Me.rbtTiporeporte_0.Size = New System.Drawing.Size(84, 17)
        Me.rbtTiporeporte_0.TabIndex = 15
        Me.rbtTiporeporte_0.TabStop = True
        Me.rbtTiporeporte_0.Text = "Nivel de la 9"
        Me.rbtTiporeporte_0.UseVisualStyleBackColor = True
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
        Me.tblconsulta.Location = New System.Drawing.Point(210, 87)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(428, 249)
        Me.tblconsulta.TabIndex = 210
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'cboperiodos_0
        '
        Me.cboperiodos_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos_0.FormattingEnabled = True
        Me.cboperiodos_0.Location = New System.Drawing.Point(46, 50)
        Me.cboperiodos_0.Name = "cboperiodos_0"
        Me.cboperiodos_0.Size = New System.Drawing.Size(106, 21)
        Me.cboperiodos_0.TabIndex = 31
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtTipoImpre_0)
        Me.GroupBox2.Controls.Add(Me.rbtTipoImpre_1)
        Me.GroupBox2.Controls.Add(Me.cboperiodos_1)
        Me.GroupBox2.Controls.Add(Me.cboperiodos_0)
        Me.GroupBox2.Location = New System.Drawing.Point(40, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(156, 95)
        Me.GroupBox2.TabIndex = 209
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'cboperiodos_1
        '
        Me.cboperiodos_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos_1.FormattingEnabled = True
        Me.cboperiodos_1.Location = New System.Drawing.Point(46, 72)
        Me.cboperiodos_1.Name = "cboperiodos_1"
        Me.cboperiodos_1.Size = New System.Drawing.Size(106, 21)
        Me.cboperiodos_1.TabIndex = 34
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.rbtTiporeporte_0)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbolencta9)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rbtTiporeporte_1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 248)
        Me.GroupBox1.TabIndex = 208
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de reporte"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(144, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = "Digitos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 13)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "D,E,F.. = Otros (344,399,etc.)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 213
        Me.Label3.Text = "C=921,922,923"
        '
        'cbolencta9
        '
        Me.cbolencta9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbolencta9.FormattingEnabled = True
        Me.cbolencta9.Location = New System.Drawing.Point(40, 34)
        Me.cbolencta9.Name = "cbolencta9"
        Me.cbolencta9.Size = New System.Drawing.Size(102, 21)
        Me.cbolencta9.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "B=924"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 211
        Me.Label1.Text = "A=90,93"
        '
        'rbtTiporeporte_1
        '
        Me.rbtTiporeporte_1.AutoSize = True
        Me.rbtTiporeporte_1.Location = New System.Drawing.Point(7, 157)
        Me.rbtTiporeporte_1.Name = "rbtTiporeporte_1"
        Me.rbtTiporeporte_1.Size = New System.Drawing.Size(131, 17)
        Me.rbtTiporeporte_1.TabIndex = 16
        Me.rbtTiporeporte_1.Text = "Agrupado para el DAC"
        Me.rbtTiporeporte_1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 345)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(644, 28)
        Me.Panel3.TabIndex = 207
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtdistribucion_0)
        Me.GroupBox3.Controls.Add(Me.rbtdistribucion_1)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 38)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 45)
        Me.GroupBox3.TabIndex = 215
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'cbolencta6
        '
        Me.cbolencta6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbolencta6.FormattingEnabled = True
        Me.cbolencta6.Location = New System.Drawing.Point(64, 18)
        Me.cbolencta6.Name = "cbolencta6"
        Me.cbolencta6.Size = New System.Drawing.Size(102, 21)
        Me.cbolencta6.TabIndex = 217
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.cbolencta6)
        Me.GroupBox4.Location = New System.Drawing.Point(210, 40)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(428, 45)
        Me.GroupBox4.TabIndex = 218
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Opciones"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(168, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 219
        Me.Label7.Text = "Digitos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 218
        Me.Label6.Text = "Cuenta 6 "
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(210, 88)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 219
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'Frm_Analisis6con9
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 373)
        Me.Controls.Add(Me.btnseleccionartodo_0)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_Analisis6con9"
        Me.Text = "Frm_Analisis6con9"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtdistribucion_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents rbtdistribucion_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipoImpre_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipoImpre_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTiporeporte_0 As System.Windows.Forms.RadioButton
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboperiodos_0 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cbolencta9 As System.Windows.Forms.ComboBox
    Friend WithEvents cboperiodos_1 As System.Windows.Forms.ComboBox
    Friend WithEvents rbtTiporeporte_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbolencta6 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
End Class
