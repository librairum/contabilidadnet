<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AnaCtaCte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AnaCtaCte))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tabOpciones = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnseleccionartodo_1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbocuentas = New System.Windows.Forms.ComboBox()
        Me.tblconsulta1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnseleccionartodo_2 = New System.Windows.Forms.Button()
        Me.tblconsulta2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtAnalisis_7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisis_6 = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtAnalisis_5 = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisis_4 = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisis_2 = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisis_3 = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisis_1 = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisis_0 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.tabOpciones.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblconsulta1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.tblconsulta2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(701, 31)
        Me.Panel1.TabIndex = 7
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(366, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(342, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(668, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 329)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(701, 28)
        Me.Panel3.TabIndex = 200
        '
        'tabOpciones
        '
        Me.tabOpciones.Controls.Add(Me.TabPage1)
        Me.tabOpciones.Controls.Add(Me.TabPage2)
        Me.tabOpciones.Controls.Add(Me.TabPage3)
        Me.tabOpciones.Location = New System.Drawing.Point(208, 38)
        Me.tabOpciones.Name = "tabOpciones"
        Me.tabOpciones.SelectedIndex = 0
        Me.tabOpciones.Size = New System.Drawing.Size(492, 284)
        Me.tabOpciones.TabIndex = 201
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnseleccionartodo_0)
        Me.TabPage1.Controls.Add(Me.tblconsulta)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(484, 258)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Por Cuentas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(6, 8)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 205
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
        Me.tblconsulta.Location = New System.Drawing.Point(4, 6)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(472, 246)
        Me.tblconsulta.TabIndex = 14
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnseleccionartodo_1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.cbocuentas)
        Me.TabPage2.Controls.Add(Me.tblconsulta1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(484, 258)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Por CtaCte X CtaCtble"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_1
        '
        Me.btnseleccionartodo_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_1.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_1.Location = New System.Drawing.Point(2, 28)
        Me.btnseleccionartodo_1.Name = "btnseleccionartodo_1"
        Me.btnseleccionartodo_1.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_1.TabIndex = 198
        Me.btnseleccionartodo_1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Cuenta"
        '
        'cbocuentas
        '
        Me.cbocuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocuentas.FormattingEnabled = True
        Me.cbocuentas.Location = New System.Drawing.Point(44, 4)
        Me.cbocuentas.Name = "cbocuentas"
        Me.cbocuentas.Size = New System.Drawing.Size(140, 21)
        Me.cbocuentas.TabIndex = 30
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
        Me.tblconsulta1.Location = New System.Drawing.Point(2, 26)
        Me.tblconsulta1.Name = "tblconsulta1"
        Me.tblconsulta1.PictureCurrentRow = CType(resources.GetObject("tblconsulta1.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta1.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta1.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta1.Size = New System.Drawing.Size(474, 224)
        Me.tblconsulta1.TabIndex = 16
        Me.tblconsulta1.TabStop = False
        Me.tblconsulta1.Text = "C1TrueDBGrid2"
        Me.tblconsulta1.UseColumnStyles = False
        Me.tblconsulta1.PropBag = resources.GetString("tblconsulta1.PropBag")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnseleccionartodo_2)
        Me.TabPage3.Controls.Add(Me.tblconsulta2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(484, 258)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Por Cta Cte"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_2
        '
        Me.btnseleccionartodo_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_2.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_2.Location = New System.Drawing.Point(6, 18)
        Me.btnseleccionartodo_2.Name = "btnseleccionartodo_2"
        Me.btnseleccionartodo_2.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_2.TabIndex = 198
        Me.btnseleccionartodo_2.UseVisualStyleBackColor = True
        '
        'tblconsulta2
        '
        Me.tblconsulta2.AllowUpdate = False
        Me.tblconsulta2.AllowUpdateOnBlur = False
        Me.tblconsulta2.AlternatingRows = True
        Me.tblconsulta2.FilterBar = True
        Me.tblconsulta2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta2.Images.Add(CType(resources.GetObject("tblconsulta2.Images"), System.Drawing.Image))
        Me.tblconsulta2.LinesPerRow = 1
        Me.tblconsulta2.Location = New System.Drawing.Point(5, 17)
        Me.tblconsulta2.Name = "tblconsulta2"
        Me.tblconsulta2.PictureCurrentRow = CType(resources.GetObject("tblconsulta2.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta2.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta2.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta2.Size = New System.Drawing.Size(475, 229)
        Me.tblconsulta2.TabIndex = 17
        Me.tblconsulta2.TabStop = False
        Me.tblconsulta2.Text = "C1TrueDBGrid2"
        Me.tblconsulta2.UseColumnStyles = False
        Me.tblconsulta2.PropBag = resources.GetString("tblconsulta2.PropBag")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_7)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_6)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_5)
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_4)
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_2)
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_3)
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_1)
        Me.GroupBox3.Controls.Add(Me.rbtAnalisis_0)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 61)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 256)
        Me.GroupBox3.TabIndex = 204
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rbtAnalisis_7
        '
        Me.rbtAnalisis_7.AutoSize = True
        Me.rbtAnalisis_7.Location = New System.Drawing.Point(8, 206)
        Me.rbtAnalisis_7.Name = "rbtAnalisis_7"
        Me.rbtAnalisis_7.Size = New System.Drawing.Size(190, 17)
        Me.rbtAnalisis_7.TabIndex = 9
        Me.rbtAnalisis_7.Text = "Analisis de Cancelados - Resumido"
        Me.rbtAnalisis_7.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(264, -124)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(187, 17)
        Me.RadioButton1.TabIndex = 8
        Me.RadioButton1.Text = "Analisis de Pendientes - Resumido"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbtAnalisis_6
        '
        Me.rbtAnalisis_6.AutoSize = True
        Me.rbtAnalisis_6.Location = New System.Drawing.Point(7, 187)
        Me.rbtAnalisis_6.Name = "rbtAnalisis_6"
        Me.rbtAnalisis_6.Size = New System.Drawing.Size(187, 17)
        Me.rbtAnalisis_6.TabIndex = 7
        Me.rbtAnalisis_6.Text = "Analisis de Pendientes - Resumido"
        Me.rbtAnalisis_6.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(2, 173)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(199, 10)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(0, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 10)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(4, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 10)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rbtAnalisis_5
        '
        Me.rbtAnalisis_5.AutoSize = True
        Me.rbtAnalisis_5.Location = New System.Drawing.Point(6, 152)
        Me.rbtAnalisis_5.Name = "rbtAnalisis_5"
        Me.rbtAnalisis_5.Size = New System.Drawing.Size(187, 17)
        Me.rbtAnalisis_5.TabIndex = 3
        Me.rbtAnalisis_5.Text = "Detallado de Ajus X Dif de Cambio"
        Me.rbtAnalisis_5.UseVisualStyleBackColor = True
        '
        'rbtAnalisis_4
        '
        Me.rbtAnalisis_4.AutoSize = True
        Me.rbtAnalisis_4.Location = New System.Drawing.Point(6, 132)
        Me.rbtAnalisis_4.Name = "rbtAnalisis_4"
        Me.rbtAnalisis_4.Size = New System.Drawing.Size(189, 17)
        Me.rbtAnalisis_4.TabIndex = 1
        Me.rbtAnalisis_4.Text = "Resumido de Ajus X Dif de Cambio"
        Me.rbtAnalisis_4.UseVisualStyleBackColor = True
        '
        'rbtAnalisis_2
        '
        Me.rbtAnalisis_2.AutoSize = True
        Me.rbtAnalisis_2.Location = New System.Drawing.Point(6, 56)
        Me.rbtAnalisis_2.Name = "rbtAnalisis_2"
        Me.rbtAnalisis_2.Size = New System.Drawing.Size(104, 17)
        Me.rbtAnalisis_2.TabIndex = 2
        Me.rbtAnalisis_2.Text = "Análisis Histórico"
        Me.rbtAnalisis_2.UseVisualStyleBackColor = True
        '
        'rbtAnalisis_3
        '
        Me.rbtAnalisis_3.AutoSize = True
        Me.rbtAnalisis_3.Location = New System.Drawing.Point(6, 90)
        Me.rbtAnalisis_3.Name = "rbtAnalisis_3"
        Me.rbtAnalisis_3.Size = New System.Drawing.Size(137, 17)
        Me.rbtAnalisis_3.TabIndex = 0
        Me.rbtAnalisis_3.Text = "Listado de Documentos"
        Me.rbtAnalisis_3.UseVisualStyleBackColor = True
        '
        'rbtAnalisis_1
        '
        Me.rbtAnalisis_1.AutoSize = True
        Me.rbtAnalisis_1.Location = New System.Drawing.Point(6, 38)
        Me.rbtAnalisis_1.Name = "rbtAnalisis_1"
        Me.rbtAnalisis_1.Size = New System.Drawing.Size(134, 17)
        Me.rbtAnalisis_1.TabIndex = 1
        Me.rbtAnalisis_1.Text = "Análisis de Cancelados"
        Me.rbtAnalisis_1.UseVisualStyleBackColor = True
        '
        'rbtAnalisis_0
        '
        Me.rbtAnalisis_0.AutoSize = True
        Me.rbtAnalisis_0.Checked = True
        Me.rbtAnalisis_0.Location = New System.Drawing.Point(6, 20)
        Me.rbtAnalisis_0.Name = "rbtAnalisis_0"
        Me.rbtAnalisis_0.Size = New System.Drawing.Size(131, 17)
        Me.rbtAnalisis_0.TabIndex = 0
        Me.rbtAnalisis_0.TabStop = True
        Me.rbtAnalisis_0.Text = "Análisis de Pendientes"
        Me.rbtAnalisis_0.UseVisualStyleBackColor = True
        '
        'Frm_AnaCtaCte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 357)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tabOpciones)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_AnaCtaCte"
        Me.Text = "Frm_AnaCtaCte"
        Me.Panel1.ResumeLayout(False)
        Me.tabOpciones.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.tblconsulta1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.tblconsulta2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tabOpciones As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cbocuentas As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtAnalisis_4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnalisis_3 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAnalisis_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnalisis_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnalisis_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnalisis_5 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_1 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_2 As System.Windows.Forms.Button
    Friend WithEvents rbtAnalisis_6 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnalisis_7 As System.Windows.Forms.RadioButton
End Class
