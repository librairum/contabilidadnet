<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Produccion_Costos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Produccion_Costos))
        Me.rbtMoneda_1 = New System.Windows.Forms.RadioButton()
        Me.rbtMoneda_0 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btndatosproducion = New System.Windows.Forms.Button()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.rbtEstado_0 = New System.Windows.Forms.RadioButton()
        Me.rbtEstado_1 = New System.Windows.Forms.RadioButton()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbtOpcion_1 = New System.Windows.Forms.RadioButton()
        Me.rbtOpcion_0 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.rbttiprepcosto_1 = New System.Windows.Forms.RadioButton()
        Me.rbttiprepcosto_0 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbtMoneda_1
        '
        Me.rbtMoneda_1.AutoSize = True
        Me.rbtMoneda_1.Location = New System.Drawing.Point(74, 16)
        Me.rbtMoneda_1.Name = "rbtMoneda_1"
        Me.rbtMoneda_1.Size = New System.Drawing.Size(51, 17)
        Me.rbtMoneda_1.TabIndex = 11
        Me.rbtMoneda_1.Text = "Soles"
        Me.rbtMoneda_1.UseVisualStyleBackColor = True
        '
        'rbtMoneda_0
        '
        Me.rbtMoneda_0.AutoSize = True
        Me.rbtMoneda_0.Checked = True
        Me.rbtMoneda_0.Location = New System.Drawing.Point(8, 16)
        Me.rbtMoneda_0.Name = "rbtMoneda_0"
        Me.rbtMoneda_0.Size = New System.Drawing.Size(61, 17)
        Me.rbtMoneda_0.TabIndex = 10
        Me.rbtMoneda_0.TabStop = True
        Me.rbtMoneda_0.Text = "Dolares"
        Me.rbtMoneda_0.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btndatosproducion)
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 31)
        Me.Panel1.TabIndex = 209
        '
        'btndatosproducion
        '
        Me.btndatosproducion.Image = Global.ContabilidadNet.My.Resources.Resources.registrar
        Me.btndatosproducion.Location = New System.Drawing.Point(6, 2)
        Me.btndatosproducion.Name = "btndatosproducion"
        Me.btndatosproducion.Size = New System.Drawing.Size(24, 24)
        Me.btndatosproducion.TabIndex = 55
        Me.btndatosproducion.UseVisualStyleBackColor = True
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(322, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(299, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(576, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'rbtEstado_0
        '
        Me.rbtEstado_0.AutoSize = True
        Me.rbtEstado_0.Checked = True
        Me.rbtEstado_0.Location = New System.Drawing.Point(7, 14)
        Me.rbtEstado_0.Name = "rbtEstado_0"
        Me.rbtEstado_0.Size = New System.Drawing.Size(88, 17)
        Me.rbtEstado_0.TabIndex = 8
        Me.rbtEstado_0.TabStop = True
        Me.rbtEstado_0.Text = "Gastos 90,92"
        Me.rbtEstado_0.UseVisualStyleBackColor = True
        '
        'rbtEstado_1
        '
        Me.rbtEstado_1.AutoSize = True
        Me.rbtEstado_1.Location = New System.Drawing.Point(8, 60)
        Me.rbtEstado_1.Name = "rbtEstado_1"
        Me.rbtEstado_1.Size = New System.Drawing.Size(73, 17)
        Me.rbtEstado_1.TabIndex = 6
        Me.rbtEstado_1.Text = "Gastos 91"
        Me.rbtEstado_1.UseVisualStyleBackColor = True
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
        Me.tblconsulta.Location = New System.Drawing.Point(168, 36)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(438, 306)
        Me.tblconsulta.TabIndex = 213
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.rbtEstado_0)
        Me.GroupBox2.Controls.Add(Me.rbtEstado_1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(162, 86)
        Me.GroupBox2.TabIndex = 212
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de estado"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbtOpcion_1)
        Me.GroupBox4.Controls.Add(Me.rbtOpcion_0)
        Me.GroupBox4.Location = New System.Drawing.Point(24, 33)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(102, 21)
        Me.GroupBox4.TabIndex = 212
        Me.GroupBox4.TabStop = False
        '
        'rbtOpcion_1
        '
        Me.rbtOpcion_1.AutoSize = True
        Me.rbtOpcion_1.Location = New System.Drawing.Point(54, 2)
        Me.rbtOpcion_1.Name = "rbtOpcion_1"
        Me.rbtOpcion_1.Size = New System.Drawing.Size(48, 17)
        Me.rbtOpcion_1.TabIndex = 11
        Me.rbtOpcion_1.Text = "Mina"
        Me.rbtOpcion_1.UseVisualStyleBackColor = True
        '
        'rbtOpcion_0
        '
        Me.rbtOpcion_0.AutoSize = True
        Me.rbtOpcion_0.Checked = True
        Me.rbtOpcion_0.Location = New System.Drawing.Point(6, 2)
        Me.rbtOpcion_0.Name = "rbtOpcion_0"
        Me.rbtOpcion_0.Size = New System.Drawing.Size(47, 17)
        Me.rbtOpcion_0.TabIndex = 10
        Me.rbtOpcion_0.TabStop = True
        Me.rbtOpcion_0.Text = "Lima"
        Me.rbtOpcion_0.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_1)
        Me.GroupBox1.Controls.Add(Me.rbtMoneda_0)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 36)
        Me.GroupBox1.TabIndex = 211
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Moneda"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 344)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(617, 28)
        Me.Panel3.TabIndex = 210
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboperiodos)
        Me.GroupBox3.Controls.Add(Me.rbttiprepcosto_1)
        Me.GroupBox3.Controls.Add(Me.rbttiprepcosto_0)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(162, 88)
        Me.GroupBox3.TabIndex = 214
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Gastos y costos por mes"
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
        'rbttiprepcosto_1
        '
        Me.rbttiprepcosto_1.AutoSize = True
        Me.rbttiprepcosto_1.Checked = True
        Me.rbttiprepcosto_1.Location = New System.Drawing.Point(4, 14)
        Me.rbttiprepcosto_1.Name = "rbttiprepcosto_1"
        Me.rbttiprepcosto_1.Size = New System.Drawing.Size(71, 17)
        Me.rbttiprepcosto_1.TabIndex = 8
        Me.rbttiprepcosto_1.TabStop = True
        Me.rbttiprepcosto_1.Text = "Al mes de"
        Me.rbttiprepcosto_1.UseVisualStyleBackColor = True
        '
        'rbttiprepcosto_0
        '
        Me.rbttiprepcosto_0.AutoSize = True
        Me.rbttiprepcosto_0.Location = New System.Drawing.Point(4, 54)
        Me.rbttiprepcosto_0.Name = "rbttiprepcosto_0"
        Me.rbttiprepcosto_0.Size = New System.Drawing.Size(114, 17)
        Me.rbttiprepcosto_0.TabIndex = 6
        Me.rbttiprepcosto_0.Text = "Comparativo Anual"
        Me.rbttiprepcosto_0.UseVisualStyleBackColor = True
        '
        'Frm_Produccion_Costos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 372)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_Produccion_Costos"
        Me.Text = "Frm_Produccion_Costos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtMoneda_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMoneda_0 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents rbtEstado_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtEstado_1 As System.Windows.Forms.RadioButton
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtOpcion_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtOpcion_0 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents rbttiprepcosto_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbttiprepcosto_0 As System.Windows.Forms.RadioButton
    Friend WithEvents btndatosproducion As System.Windows.Forms.Button
End Class
