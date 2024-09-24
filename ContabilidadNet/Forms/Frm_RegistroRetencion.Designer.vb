<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegistroRetencion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegistroRetencion))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.mskFecFin = New System.Windows.Forms.MaskedTextBox()
        Me.mskFecIni = New System.Windows.Forms.MaskedTextBox()
        Me.optTipoImpre_0 = New System.Windows.Forms.RadioButton()
        Me.optTipoImpre_1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtPagina = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoAnalisi = New System.Windows.Forms.ComboBox()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Fecha Inicial"
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
        Me.Panel1.Size = New System.Drawing.Size(604, 31)
        Me.Panel1.TabIndex = 209
        '
        'btnexportar
        '
        Me.btnexportar.Image = Global.ContabilidadNet.My.Resources.Resources.exportar
        Me.btnexportar.Location = New System.Drawing.Point(94, 2)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(24, 24)
        Me.btnexportar.TabIndex = 21
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(292, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(267, 2)
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
        Me.mskFecFin.Location = New System.Drawing.Point(78, 96)
        Me.mskFecFin.Name = "mskFecFin"
        Me.mskFecFin.Size = New System.Drawing.Size(80, 20)
        Me.mskFecFin.TabIndex = 12
        '
        'mskFecIni
        '
        Me.mskFecIni.Location = New System.Drawing.Point(78, 74)
        Me.mskFecIni.Name = "mskFecIni"
        Me.mskFecIni.Size = New System.Drawing.Size(80, 20)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboperiodos)
        Me.GroupBox2.Controls.Add(Me.mskFecFin)
        Me.GroupBox2.Controls.Add(Me.mskFecIni)
        Me.GroupBox2.Controls.Add(Me.optTipoImpre_0)
        Me.GroupBox2.Controls.Add(Me.optTipoImpre_1)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(164, 126)
        Me.GroupBox2.TabIndex = 212
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rango de impresion"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 322)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(604, 28)
        Me.Panel3.TabIndex = 210
        '
        'txtPagina
        '
        Me.txtPagina.Location = New System.Drawing.Point(122, 194)
        Me.txtPagina.Name = "txtPagina"
        Me.txtPagina.NroDecimales = CType(0, Short)
        Me.txtPagina.SelectGotFocus = True
        Me.txtPagina.Size = New System.Drawing.Size(44, 20)
        Me.txtPagina.TabIndex = 214
        Me.txtPagina.Tabulado = True
        Me.txtPagina.Text = "0"
        Me.txtPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPagina.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "Iniciar con Nro Pagina :"
        '
        'cboTipoAnalisi
        '
        Me.cboTipoAnalisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAnalisi.FormattingEnabled = True
        Me.cboTipoAnalisi.Location = New System.Drawing.Point(172, 38)
        Me.cboTipoAnalisi.Name = "cboTipoAnalisi"
        Me.cboTipoAnalisi.Size = New System.Drawing.Size(428, 21)
        Me.cboTipoAnalisi.TabIndex = 216
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
        Me.tblconsulta.Location = New System.Drawing.Point(172, 60)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(428, 258)
        Me.tblconsulta.TabIndex = 217
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(173, 61)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 236
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'Frm_RegistroRetencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 350)
        Me.Controls.Add(Me.btnseleccionartodo_0)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.cboTipoAnalisi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPagina)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_RegistroRetencion"
        Me.Text = "Frm_RegistroRetencion"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents mskFecFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskFecIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents optTipoImpre_0 As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoImpre_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtPagina As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAnalisi As System.Windows.Forms.ComboBox
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
End Class
