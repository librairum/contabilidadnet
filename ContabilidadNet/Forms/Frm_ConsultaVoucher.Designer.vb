<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConsultaVoucher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConsultaVoucher))
        Me.chkglosa = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTitulo = New Ks.UserControl.ksTextBox()
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tblconsulta_1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.mskfechafin = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskfechaini = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        Me.tabOpciones.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblconsulta_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkglosa
        '
        Me.chkglosa.AutoSize = True
        Me.chkglosa.Location = New System.Drawing.Point(488, 6)
        Me.chkglosa.Name = "chkglosa"
        Me.chkglosa.Size = New System.Drawing.Size(109, 17)
        Me.chkglosa.TabIndex = 19
        Me.chkglosa.Text = "Agrupar por glosa"
        Me.chkglosa.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Titulo del reporte"
        '
        'txtTitulo
        '
        Me.txtTitulo.BackColor = System.Drawing.Color.White
        Me.txtTitulo.Location = New System.Drawing.Point(94, 6)
        Me.txtTitulo.Multiline = True
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.NroDecimales = CType(0, Short)
        Me.txtTitulo.SelectGotFocus = True
        Me.txtTitulo.Size = New System.Drawing.Size(384, 34)
        Me.txtTitulo.TabIndex = 17
        Me.txtTitulo.Tabulado = True
        Me.txtTitulo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
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
        Me.Panel1.Size = New System.Drawing.Size(624, 31)
        Me.Panel1.TabIndex = 5
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(302, 0)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(278, 0)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(594, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 309)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(624, 28)
        Me.Panel3.TabIndex = 201
        '
        'tabOpciones
        '
        Me.tabOpciones.Controls.Add(Me.TabPage1)
        Me.tabOpciones.Controls.Add(Me.TabPage2)
        Me.tabOpciones.Location = New System.Drawing.Point(2, 40)
        Me.tabOpciones.Name = "tabOpciones"
        Me.tabOpciones.SelectedIndex = 0
        Me.tabOpciones.Size = New System.Drawing.Size(612, 264)
        Me.tabOpciones.TabIndex = 203
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnseleccionartodo_0)
        Me.TabPage1.Controls.Add(Me.tblconsulta)
        Me.TabPage1.Controls.Add(Me.txtTitulo)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.chkglosa)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(604, 238)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Comprobantes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(4, 44)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 207
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
        Me.tblconsulta.Location = New System.Drawing.Point(4, 42)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(594, 196)
        Me.tblconsulta.TabIndex = 15
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnseleccionartodo_1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.tblconsulta_1)
        Me.TabPage2.Controls.Add(Me.mskfechafin)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.mskfechaini)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(604, 238)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cuentas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_1
        '
        Me.btnseleccionartodo_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_1.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_1.Location = New System.Drawing.Point(4, 32)
        Me.btnseleccionartodo_1.Name = "btnseleccionartodo_1"
        Me.btnseleccionartodo_1.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_1.TabIndex = 208
        Me.btnseleccionartodo_1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Fecha Fin:"
        '
        'tblconsulta_1
        '
        Me.tblconsulta_1.AllowUpdate = False
        Me.tblconsulta_1.AllowUpdateOnBlur = False
        Me.tblconsulta_1.AlternatingRows = True
        Me.tblconsulta_1.FilterBar = True
        Me.tblconsulta_1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_1.Images.Add(CType(resources.GetObject("tblconsulta_1.Images"), System.Drawing.Image))
        Me.tblconsulta_1.LinesPerRow = 1
        Me.tblconsulta_1.Location = New System.Drawing.Point(4, 30)
        Me.tblconsulta_1.Name = "tblconsulta_1"
        Me.tblconsulta_1.PictureCurrentRow = CType(resources.GetObject("tblconsulta_1.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_1.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_1.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_1.Size = New System.Drawing.Size(512, 202)
        Me.tblconsulta_1.TabIndex = 16
        Me.tblconsulta_1.TabStop = False
        Me.tblconsulta_1.Text = "C1TrueDBGrid2"
        Me.tblconsulta_1.UseColumnStyles = False
        Me.tblconsulta_1.PropBag = resources.GetString("tblconsulta_1.PropBag")
        '
        'mskfechafin
        '
        Me.mskfechafin.Location = New System.Drawing.Point(208, 6)
        Me.mskfechafin.Mask = "00/00/0000"
        Me.mskfechafin.Name = "mskfechafin"
        Me.mskfechafin.Size = New System.Drawing.Size(68, 20)
        Me.mskfechafin.TabIndex = 21
        Me.mskfechafin.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Fecha inicio:"
        '
        'mskfechaini
        '
        Me.mskfechaini.Location = New System.Drawing.Point(76, 4)
        Me.mskfechaini.Mask = "00/00/0000"
        Me.mskfechaini.Name = "mskfechaini"
        Me.mskfechaini.Size = New System.Drawing.Size(68, 20)
        Me.mskfechaini.TabIndex = 20
        Me.mskfechaini.ValidatingType = GetType(Date)
        '
        'Frm_ConsultaVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 337)
        Me.Controls.Add(Me.tabOpciones)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_ConsultaVoucher"
        Me.Text = "Frm_ConsultaVoucher"
        Me.Panel1.ResumeLayout(False)
        Me.tabOpciones.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.tblconsulta_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtTitulo As Ks.UserControl.ksTextBox
    Friend WithEvents chkglosa As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tabOpciones As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta_1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mskfechafin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskfechaini As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_1 As System.Windows.Forms.Button
End Class
