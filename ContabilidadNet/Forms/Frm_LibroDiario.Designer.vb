<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LibroDiario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LibroDiario))
        Me.optTipoImpre_0 = New System.Windows.Forms.RadioButton()
        Me.RbtTipoReporte_2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtdiario_1 = New System.Windows.Forms.RadioButton()
        Me.rbtdiario_0 = New System.Windows.Forms.RadioButton()
        Me.TxtNivel = New Ks.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.rbtTipoReporte_1 = New System.Windows.Forms.RadioButton()
        Me.RbtTipoReporte_0 = New System.Windows.Forms.RadioButton()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.mskFecFin = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.mskFecIni = New System.Windows.Forms.MaskedTextBox()
        Me.optTipoImpre_1 = New System.Windows.Forms.RadioButton()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'optTipoImpre_0
        '
        Me.optTipoImpre_0.AutoSize = True
        Me.optTipoImpre_0.Checked = True
        Me.optTipoImpre_0.Location = New System.Drawing.Point(8, 20)
        Me.optTipoImpre_0.Name = "optTipoImpre_0"
        Me.optTipoImpre_0.Size = New System.Drawing.Size(79, 17)
        Me.optTipoImpre_0.TabIndex = 32
        Me.optTipoImpre_0.TabStop = True
        Me.optTipoImpre_0.Text = "Por periodo"
        Me.optTipoImpre_0.UseVisualStyleBackColor = True
        '
        'RbtTipoReporte_2
        '
        Me.RbtTipoReporte_2.AutoSize = True
        Me.RbtTipoReporte_2.Location = New System.Drawing.Point(8, 112)
        Me.RbtTipoReporte_2.Name = "RbtTipoReporte_2"
        Me.RbtTipoReporte_2.Size = New System.Drawing.Size(98, 17)
        Me.RbtTipoReporte_2.TabIndex = 15
        Me.RbtTipoReporte_2.Text = "Nuevo Formato"
        Me.RbtTipoReporte_2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtdiario_1)
        Me.GroupBox3.Controls.Add(Me.rbtdiario_0)
        Me.GroupBox3.Controls.Add(Me.TxtNivel)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(54, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(134, 54)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        '
        'rbtdiario_1
        '
        Me.rbtdiario_1.AutoSize = True
        Me.rbtdiario_1.Location = New System.Drawing.Point(62, 36)
        Me.rbtdiario_1.Name = "rbtdiario_1"
        Me.rbtdiario_1.Size = New System.Drawing.Size(58, 17)
        Me.rbtdiario_1.TabIndex = 14
        Me.rbtdiario_1.Text = "Auxiliar"
        Me.rbtdiario_1.UseVisualStyleBackColor = True
        '
        'rbtdiario_0
        '
        Me.rbtdiario_0.AutoSize = True
        Me.rbtdiario_0.Location = New System.Drawing.Point(2, 34)
        Me.rbtdiario_0.Name = "rbtdiario_0"
        Me.rbtdiario_0.Size = New System.Drawing.Size(52, 17)
        Me.rbtdiario_0.TabIndex = 13
        Me.rbtdiario_0.Text = "Diario"
        Me.rbtdiario_0.UseVisualStyleBackColor = True
        '
        'TxtNivel
        '
        Me.TxtNivel.Location = New System.Drawing.Point(74, 18)
        Me.TxtNivel.Name = "TxtNivel"
        Me.TxtNivel.NroDecimales = CType(0, Short)
        Me.TxtNivel.SelectGotFocus = True
        Me.TxtNivel.Size = New System.Drawing.Size(44, 20)
        Me.TxtNivel.TabIndex = 1
        Me.TxtNivel.Tabulado = True
        Me.TxtNivel.Text = "0"
        Me.TxtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNivel.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº de digitos"
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
        Me.tblconsulta.Location = New System.Drawing.Point(206, 36)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(512, 272)
        Me.tblconsulta.TabIndex = 215
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'rbtTipoReporte_1
        '
        Me.rbtTipoReporte_1.AutoSize = True
        Me.rbtTipoReporte_1.Location = New System.Drawing.Point(12, 40)
        Me.rbtTipoReporte_1.Name = "rbtTipoReporte_1"
        Me.rbtTipoReporte_1.Size = New System.Drawing.Size(72, 17)
        Me.rbtTipoReporte_1.TabIndex = 13
        Me.rbtTipoReporte_1.Text = "Resumido"
        Me.rbtTipoReporte_1.UseVisualStyleBackColor = True
        '
        'RbtTipoReporte_0
        '
        Me.RbtTipoReporte_0.AutoSize = True
        Me.RbtTipoReporte_0.Checked = True
        Me.RbtTipoReporte_0.Location = New System.Drawing.Point(12, 20)
        Me.RbtTipoReporte_0.Name = "RbtTipoReporte_0"
        Me.RbtTipoReporte_0.Size = New System.Drawing.Size(70, 17)
        Me.RbtTipoReporte_0.TabIndex = 12
        Me.RbtTipoReporte_0.TabStop = True
        Me.RbtTipoReporte_0.Text = "Detallado"
        Me.RbtTipoReporte_0.UseVisualStyleBackColor = True
        '
        'cboperiodos
        '
        Me.cboperiodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos.FormattingEnabled = True
        Me.cboperiodos.Location = New System.Drawing.Point(16, 40)
        Me.cboperiodos.Name = "cboperiodos"
        Me.cboperiodos.Size = New System.Drawing.Size(118, 21)
        Me.cboperiodos.TabIndex = 31
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(696, 1)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(278, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbtTipoReporte_2)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.rbtTipoReporte_1)
        Me.GroupBox2.Controls.Add(Me.RbtTipoReporte_0)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 132)
        Me.GroupBox2.TabIndex = 214
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de reporte"
        '
        'mskFecFin
        '
        Me.mskFecFin.Location = New System.Drawing.Point(16, 104)
        Me.mskFecFin.Name = "mskFecFin"
        Me.mskFecFin.Size = New System.Drawing.Size(116, 20)
        Me.mskFecFin.TabIndex = 35
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.mskFecFin)
        Me.GroupBox1.Controls.Add(Me.mskFecIni)
        Me.GroupBox1.Controls.Add(Me.optTipoImpre_1)
        Me.GroupBox1.Controls.Add(Me.optTipoImpre_0)
        Me.GroupBox1.Controls.Add(Me.cboperiodos)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 132)
        Me.GroupBox1.TabIndex = 213
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de impresion"
        '
        'mskFecIni
        '
        Me.mskFecIni.Location = New System.Drawing.Point(16, 82)
        Me.mskFecIni.Name = "mskFecIni"
        Me.mskFecIni.Size = New System.Drawing.Size(116, 20)
        Me.mskFecIni.TabIndex = 34
        '
        'optTipoImpre_1
        '
        Me.optTipoImpre_1.AutoSize = True
        Me.optTipoImpre_1.Location = New System.Drawing.Point(8, 64)
        Me.optTipoImpre_1.Name = "optTipoImpre_1"
        Me.optTipoImpre_1.Size = New System.Drawing.Size(76, 17)
        Me.optTipoImpre_1.TabIndex = 33
        Me.optTipoImpre_1.Text = "Por fechas"
        Me.optTipoImpre_1.UseVisualStyleBackColor = True
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(302, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnexportar)
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 32)
        Me.Panel1.TabIndex = 211
        '
        'btnexportar
        '
        Me.btnexportar.Image = Global.ContabilidadNet.My.Resources.Resources.exportar
        Me.btnexportar.Location = New System.Drawing.Point(349, 3)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(24, 24)
        Me.btnexportar.TabIndex = 26
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 321)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(724, 28)
        Me.Panel3.TabIndex = 212
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(207, 38)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 230
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'Frm_LibroDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 349)
        Me.Controls.Add(Me.btnseleccionartodo_0)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_LibroDiario"
        Me.Text = "Frm_LibroDiario"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optTipoImpre_0 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtTipoReporte_2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtdiario_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtdiario_0 As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNivel As KS.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents rbtTipoReporte_1 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtTipoReporte_0 As System.Windows.Forms.RadioButton
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents mskFecFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mskFecIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents optTipoImpre_1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
    Friend WithEvents btnexportar As System.Windows.Forms.Button
End Class
