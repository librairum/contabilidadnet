<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MayorPorMeses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MayorPorMeses))
        Me.rbtdelmesoacum_0 = New System.Windows.Forms.RadioButton()
        Me.rbtdelmesoacum_1 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboniveles = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtdebehaber_5 = New System.Windows.Forms.RadioButton()
        Me.rbtdebehaber_4 = New System.Windows.Forms.RadioButton()
        Me.rbtdebehaber_3 = New System.Windows.Forms.RadioButton()
        Me.rbtdebehaber_2 = New System.Windows.Forms.RadioButton()
        Me.rbtdebehaber_0 = New System.Windows.Forms.RadioButton()
        Me.rbtdebehaber_1 = New System.Windows.Forms.RadioButton()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbtdelmesoacum_0
        '
        Me.rbtdelmesoacum_0.AutoSize = True
        Me.rbtdelmesoacum_0.Checked = True
        Me.rbtdelmesoacum_0.Location = New System.Drawing.Point(17, 21)
        Me.rbtdelmesoacum_0.Name = "rbtdelmesoacum_0"
        Me.rbtdelmesoacum_0.Size = New System.Drawing.Size(80, 17)
        Me.rbtdelmesoacum_0.TabIndex = 11
        Me.rbtdelmesoacum_0.TabStop = True
        Me.rbtdelmesoacum_0.Text = "Del Periodo"
        Me.rbtdelmesoacum_0.UseVisualStyleBackColor = True
        '
        'rbtdelmesoacum_1
        '
        Me.rbtdelmesoacum_1.AutoSize = True
        Me.rbtdelmesoacum_1.Location = New System.Drawing.Point(17, 41)
        Me.rbtdelmesoacum_1.Name = "rbtdelmesoacum_1"
        Me.rbtdelmesoacum_1.Size = New System.Drawing.Size(78, 17)
        Me.rbtdelmesoacum_1.TabIndex = 10
        Me.rbtdelmesoacum_1.Text = "Acumulado"
        Me.rbtdelmesoacum_1.UseVisualStyleBackColor = True
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
        Me.Panel1.Size = New System.Drawing.Size(652, 31)
        Me.Panel1.TabIndex = 208
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
        Me.btnsalir.Location = New System.Drawing.Point(624, 2)
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
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdate = False
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(126, 36)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(522, 282)
        Me.tblconsulta.TabIndex = 214
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtdelmesoacum_0)
        Me.GroupBox1.Controls.Add(Me.rbtdelmesoacum_1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(118, 67)
        Me.GroupBox1.TabIndex = 210
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de analisis"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cboniveles)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 324)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(652, 28)
        Me.Panel3.TabIndex = 209
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(442, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "Hasta el Nivel"
        '
        'cboniveles
        '
        Me.cboniveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboniveles.FormattingEnabled = True
        Me.cboniveles.Location = New System.Drawing.Point(522, 4)
        Me.cboniveles.Name = "cboniveles"
        Me.cboniveles.Size = New System.Drawing.Size(124, 21)
        Me.cboniveles.TabIndex = 145
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtdebehaber_5)
        Me.GroupBox2.Controls.Add(Me.rbtdebehaber_4)
        Me.GroupBox2.Controls.Add(Me.rbtdebehaber_3)
        Me.GroupBox2.Controls.Add(Me.rbtdebehaber_2)
        Me.GroupBox2.Controls.Add(Me.rbtdebehaber_0)
        Me.GroupBox2.Controls.Add(Me.rbtdebehaber_1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(114, 189)
        Me.GroupBox2.TabIndex = 215
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de importe"
        '
        'rbtdebehaber_5
        '
        Me.rbtdebehaber_5.AutoSize = True
        Me.rbtdebehaber_5.Location = New System.Drawing.Point(16, 130)
        Me.rbtdebehaber_5.Name = "rbtdebehaber_5"
        Me.rbtdebehaber_5.Size = New System.Drawing.Size(82, 17)
        Me.rbtdebehaber_5.TabIndex = 15
        Me.rbtdebehaber_5.Text = "Saldo (U$S)"
        Me.rbtdebehaber_5.UseVisualStyleBackColor = True
        '
        'rbtdebehaber_4
        '
        Me.rbtdebehaber_4.AutoSize = True
        Me.rbtdebehaber_4.Location = New System.Drawing.Point(16, 58)
        Me.rbtdebehaber_4.Name = "rbtdebehaber_4"
        Me.rbtdebehaber_4.Size = New System.Drawing.Size(79, 17)
        Me.rbtdebehaber_4.TabIndex = 14
        Me.rbtdebehaber_4.Text = "Saldo  (S/.)"
        Me.rbtdebehaber_4.UseVisualStyleBackColor = True
        '
        'rbtdebehaber_3
        '
        Me.rbtdebehaber_3.AutoSize = True
        Me.rbtdebehaber_3.Location = New System.Drawing.Point(16, 112)
        Me.rbtdebehaber_3.Name = "rbtdebehaber_3"
        Me.rbtdebehaber_3.Size = New System.Drawing.Size(86, 17)
        Me.rbtdebehaber_3.TabIndex = 13
        Me.rbtdebehaber_3.Text = "Abono (U$S)"
        Me.rbtdebehaber_3.UseVisualStyleBackColor = True
        '
        'rbtdebehaber_2
        '
        Me.rbtdebehaber_2.AutoSize = True
        Me.rbtdebehaber_2.Location = New System.Drawing.Point(16, 94)
        Me.rbtdebehaber_2.Name = "rbtdebehaber_2"
        Me.rbtdebehaber_2.Size = New System.Drawing.Size(86, 17)
        Me.rbtdebehaber_2.TabIndex = 12
        Me.rbtdebehaber_2.Text = "Cargo  (U$S)"
        Me.rbtdebehaber_2.UseVisualStyleBackColor = True
        '
        'rbtdebehaber_0
        '
        Me.rbtdebehaber_0.AutoSize = True
        Me.rbtdebehaber_0.Checked = True
        Me.rbtdebehaber_0.Location = New System.Drawing.Point(16, 18)
        Me.rbtdebehaber_0.Name = "rbtdebehaber_0"
        Me.rbtdebehaber_0.Size = New System.Drawing.Size(75, 17)
        Me.rbtdebehaber_0.TabIndex = 11
        Me.rbtdebehaber_0.TabStop = True
        Me.rbtdebehaber_0.Text = "Debe (S/.)"
        Me.rbtdebehaber_0.UseVisualStyleBackColor = True
        '
        'rbtdebehaber_1
        '
        Me.rbtdebehaber_1.AutoSize = True
        Me.rbtdebehaber_1.Location = New System.Drawing.Point(16, 38)
        Me.rbtdebehaber_1.Name = "rbtdebehaber_1"
        Me.rbtdebehaber_1.Size = New System.Drawing.Size(81, 17)
        Me.rbtdebehaber_1.TabIndex = 10
        Me.rbtdebehaber_1.Text = "Haber  (S/.)"
        Me.rbtdebehaber_1.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(127, 36)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 232
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'Frm_MayorPorMeses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 352)
        Me.Controls.Add(Me.btnseleccionartodo_0)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_MayorPorMeses"
        Me.Text = "Frm_MayorPorMeses"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtdelmesoacum_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtdelmesoacum_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtdebehaber_5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtdebehaber_4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtdebehaber_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtdebehaber_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtdebehaber_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtdebehaber_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboniveles As System.Windows.Forms.ComboBox
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
End Class
