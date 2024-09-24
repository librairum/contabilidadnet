<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Produccion_TipoGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Produccion_TipoGastos))
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboniveles = New System.Windows.Forms.ComboBox()
        Me.rbttraecuentas_2 = New System.Windows.Forms.RadioButton()
        Me.rbttraecuentas_1 = New System.Windows.Forms.RadioButton()
        Me.rbttraecuentas_0 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.rbttiporeport_1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gbxdetalle = New System.Windows.Forms.GroupBox()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txttipogasto = New Ks.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.rbttiporeport_0 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gbxdetalle.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboperiodos
        '
        Me.cboperiodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos.FormattingEnabled = True
        Me.cboperiodos.Location = New System.Drawing.Point(52, 20)
        Me.cboperiodos.Name = "cboperiodos"
        Me.cboperiodos.Size = New System.Drawing.Size(132, 21)
        Me.cboperiodos.TabIndex = 30
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cboniveles)
        Me.GroupBox4.Controls.Add(Me.rbttraecuentas_2)
        Me.GroupBox4.Controls.Add(Me.rbttraecuentas_1)
        Me.GroupBox4.Controls.Add(Me.rbttraecuentas_0)
        Me.GroupBox4.Location = New System.Drawing.Point(196, 38)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(496, 48)
        Me.GroupBox4.TabIndex = 212
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Visualizar cuentas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "Nivel"
        '
        'cboniveles
        '
        Me.cboniveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboniveles.FormattingEnabled = True
        Me.cboniveles.Items.AddRange(New Object() {"2", "3", "5", "7"})
        Me.cboniveles.Location = New System.Drawing.Point(44, 22)
        Me.cboniveles.Name = "cboniveles"
        Me.cboniveles.Size = New System.Drawing.Size(84, 21)
        Me.cboniveles.TabIndex = 145
        '
        'rbttraecuentas_2
        '
        Me.rbttraecuentas_2.AutoSize = True
        Me.rbttraecuentas_2.Location = New System.Drawing.Point(324, 22)
        Me.rbttraecuentas_2.Name = "rbttraecuentas_2"
        Me.rbttraecuentas_2.Size = New System.Drawing.Size(136, 17)
        Me.rbttraecuentas_2.TabIndex = 12
        Me.rbttraecuentas_2.Text = "Gastos distribuibles (91)"
        Me.rbttraecuentas_2.UseVisualStyleBackColor = True
        '
        'rbttraecuentas_1
        '
        Me.rbttraecuentas_1.AutoSize = True
        Me.rbttraecuentas_1.Location = New System.Drawing.Point(191, 22)
        Me.rbttraecuentas_1.Name = "rbttraecuentas_1"
        Me.rbttraecuentas_1.Size = New System.Drawing.Size(130, 17)
        Me.rbttraecuentas_1.TabIndex = 11
        Me.rbttraecuentas_1.Text = "Gastos no distribuibles"
        Me.rbttraecuentas_1.UseVisualStyleBackColor = True
        '
        'rbttraecuentas_0
        '
        Me.rbttraecuentas_0.AutoSize = True
        Me.rbttraecuentas_0.Checked = True
        Me.rbttraecuentas_0.Location = New System.Drawing.Point(131, 22)
        Me.rbttraecuentas_0.Name = "rbttraecuentas_0"
        Me.rbttraecuentas_0.Size = New System.Drawing.Size(55, 17)
        Me.rbttraecuentas_0.TabIndex = 10
        Me.rbttraecuentas_0.TabStop = True
        Me.rbttraecuentas_0.Text = "Todas"
        Me.rbttraecuentas_0.UseVisualStyleBackColor = True
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
        Me.Panel1.Size = New System.Drawing.Size(702, 31)
        Me.Panel1.TabIndex = 215
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(297, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(274, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(666, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
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
        Me.tblconsulta.Location = New System.Drawing.Point(196, 89)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(498, 230)
        Me.tblconsulta.TabIndex = 219
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'rbttiporeport_1
        '
        Me.rbttiporeport_1.AutoSize = True
        Me.rbttiporeport_1.Location = New System.Drawing.Point(8, 36)
        Me.rbttiporeport_1.Name = "rbttiporeport_1"
        Me.rbttiporeport_1.Size = New System.Drawing.Size(70, 17)
        Me.rbttiporeport_1.TabIndex = 6
        Me.rbttiporeport_1.Text = "Detallado"
        Me.rbttiporeport_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gbxdetalle)
        Me.GroupBox2.Controls.Add(Me.rbttiporeport_0)
        Me.GroupBox2.Controls.Add(Me.rbttiporeport_1)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 124)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opcion de reporte"
        '
        'gbxdetalle
        '
        Me.gbxdetalle.Controls.Add(Me.lblhelp_0)
        Me.gbxdetalle.Controls.Add(Me.txttipogasto)
        Me.gbxdetalle.Controls.Add(Me.Label1)
        Me.gbxdetalle.Controls.Add(Me.btnhelp_0)
        Me.gbxdetalle.Location = New System.Drawing.Point(18, 54)
        Me.gbxdetalle.Name = "gbxdetalle"
        Me.gbxdetalle.Size = New System.Drawing.Size(154, 58)
        Me.gbxdetalle.TabIndex = 228
        Me.gbxdetalle.TabStop = False
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(56, 34)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(94, 18)
        Me.lblhelp_0.TabIndex = 223
        Me.lblhelp_0.Text = "???"
        '
        'txttipogasto
        '
        Me.txttipogasto.BackColor = System.Drawing.Color.White
        Me.txttipogasto.Location = New System.Drawing.Point(6, 32)
        Me.txttipogasto.Name = "txttipogasto"
        Me.txttipogasto.NroDecimales = CType(0, Short)
        Me.txttipogasto.SelectGotFocus = True
        Me.txttipogasto.Size = New System.Drawing.Size(28, 20)
        Me.txttipogasto.TabIndex = 222
        Me.txttipogasto.Tabulado = True
        Me.txttipogasto.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "Tipo de Gasto"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(34, 32)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 224
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'rbttiporeport_0
        '
        Me.rbttiporeport_0.AutoSize = True
        Me.rbttiporeport_0.Checked = True
        Me.rbttiporeport_0.Location = New System.Drawing.Point(7, 16)
        Me.rbttiporeport_0.Name = "rbttiporeport_0"
        Me.rbttiporeport_0.Size = New System.Drawing.Size(70, 17)
        Me.rbttiporeport_0.TabIndex = 8
        Me.rbttiporeport_0.TabStop = True
        Me.rbttiporeport_0.Text = "Resumen"
        Me.rbttiporeport_0.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 323)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(702, 24)
        Me.Panel3.TabIndex = 216
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
        Me.tblhelp.Location = New System.Drawing.Point(38, 194)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(286, 116)
        Me.tblhelp.TabIndex = 225
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "Al Mes"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cboperiodos)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 186)
        Me.GroupBox1.TabIndex = 227
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(196, 90)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 235
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'Frm_Produccion_TipoGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 347)
        Me.Controls.Add(Me.btnseleccionartodo_0)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_Produccion_TipoGastos"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbxdetalle.ResumeLayout(False)
        Me.gbxdetalle.PerformLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbttraecuentas_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbttraecuentas_0 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents rbttiporeport_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbttiporeport_0 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbttraecuentas_2 As System.Windows.Forms.RadioButton
    Friend WithEvents cboniveles As System.Windows.Forms.ComboBox
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttipogasto As KS.UserControl.ksTextBox
    Friend WithEvents gbxdetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
End Class
