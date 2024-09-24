<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LibLeg_41remu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LibLeg_41remu))
        Me.txtimporte = New Ks.UserControl.ksTextBox()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.txttrabajador = New Ks.UserControl.ksTextBox()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.txtcuenta = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtnombrecuenta = New Ks.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimportar = New System.Windows.Forms.Button()
        Me.btninsertar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtorigen_1 = New System.Windows.Forms.RadioButton()
        Me.rbtorigen_0 = New System.Windows.Forms.RadioButton()
        Me.txttipdoc = New Ks.UserControl.ksTextBox()
        Me.txtnumdoc = New Ks.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtimporte
        '
        Me.txtimporte.Location = New System.Drawing.Point(76, 104)
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.NroDecimales = CType(0, Short)
        Me.txtimporte.SelectGotFocus = True
        Me.txtimporte.Size = New System.Drawing.Size(88, 20)
        Me.txtimporte.TabIndex = 337
        Me.txtimporte.Tabulado = True
        Me.txtimporte.Text = "0.00"
        Me.txtimporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtimporte.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(165, 81)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 353
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(187, 83)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(303, 18)
        Me.lblhelp_1.TabIndex = 352
        Me.lblhelp_1.Text = "???"
        '
        'txttrabajador
        '
        Me.txttrabajador.Location = New System.Drawing.Point(76, 82)
        Me.txttrabajador.Name = "txttrabajador"
        Me.txttrabajador.NroDecimales = CType(0, Short)
        Me.txttrabajador.SelectGotFocus = True
        Me.txttrabajador.Size = New System.Drawing.Size(88, 20)
        Me.txttrabajador.TabIndex = 336
        Me.txttrabajador.Tabulado = True
        Me.txttrabajador.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(165, 34)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 351
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'txtcuenta
        '
        Me.txtcuenta.Location = New System.Drawing.Point(76, 34)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.NroDecimales = CType(0, Short)
        Me.txtcuenta.SelectGotFocus = True
        Me.txtcuenta.Size = New System.Drawing.Size(88, 20)
        Me.txtcuenta.TabIndex = 334
        Me.txtcuenta.Tabulado = True
        Me.txtcuenta.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 346
        Me.Label3.Text = "Cuenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 347
        Me.Label4.Text = "Origen"
        '
        'txtnombrecuenta
        '
        Me.txtnombrecuenta.Location = New System.Drawing.Point(188, 34)
        Me.txtnombrecuenta.Name = "txtnombrecuenta"
        Me.txtnombrecuenta.NroDecimales = CType(0, Short)
        Me.txtnombrecuenta.SelectGotFocus = True
        Me.txtnombrecuenta.Size = New System.Drawing.Size(396, 20)
        Me.txtnombrecuenta.TabIndex = 338
        Me.txtnombrecuenta.Tabulado = True
        Me.txtnombrecuenta.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 345
        Me.Label2.Text = "Importe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 344
        Me.Label1.Text = "Trabajador"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 304)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(587, 28)
        Me.Panel3.TabIndex = 341
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnimportar)
        Me.Panel1.Controls.Add(Me.btninsertar)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(587, 31)
        Me.Panel1.TabIndex = 340
        '
        'btnimportar
        '
        Me.btnimportar.Image = Global.ContabilidadNet.My.Resources.Resources.Copy1
        Me.btnimportar.Location = New System.Drawing.Point(93, 2)
        Me.btnimportar.Name = "btnimportar"
        Me.btnimportar.Size = New System.Drawing.Size(24, 24)
        Me.btnimportar.TabIndex = 42
        Me.btnimportar.UseVisualStyleBackColor = True
        '
        'btninsertar
        '
        Me.btninsertar.Image = Global.ContabilidadNet.My.Resources.Resources.Insertar
        Me.btninsertar.Location = New System.Drawing.Point(26, 2)
        Me.btninsertar.Name = "btninsertar"
        Me.btninsertar.Size = New System.Drawing.Size(24, 24)
        Me.btninsertar.TabIndex = 41
        Me.btninsertar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(167, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 6
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(562, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(145, 2)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 1
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(70, 2)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 14
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(4, 2)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 12
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(48, 2)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 13
        Me.btnmodificar.UseVisualStyleBackColor = True
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
        Me.tblhelp.Location = New System.Drawing.Point(174, 168)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(340, 140)
        Me.tblhelp.TabIndex = 343
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
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
        Me.tblconsulta.Location = New System.Drawing.Point(12, 127)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(572, 175)
        Me.tblconsulta.TabIndex = 342
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtorigen_1)
        Me.GroupBox1.Controls.Add(Me.rbtorigen_0)
        Me.GroupBox1.Location = New System.Drawing.Point(78, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(156, 22)
        Me.GroupBox1.TabIndex = 354
        Me.GroupBox1.TabStop = False
        '
        'rbtorigen_1
        '
        Me.rbtorigen_1.AutoSize = True
        Me.rbtorigen_1.Location = New System.Drawing.Point(72, 2)
        Me.rbtorigen_1.Name = "rbtorigen_1"
        Me.rbtorigen_1.Size = New System.Drawing.Size(83, 17)
        Me.rbtorigen_1.TabIndex = 1
        Me.rbtorigen_1.TabStop = True
        Me.rbtorigen_1.Text = "Contabilidad"
        Me.rbtorigen_1.UseVisualStyleBackColor = True
        '
        'rbtorigen_0
        '
        Me.rbtorigen_0.AutoSize = True
        Me.rbtorigen_0.Location = New System.Drawing.Point(4, 2)
        Me.rbtorigen_0.Name = "rbtorigen_0"
        Me.rbtorigen_0.Size = New System.Drawing.Size(63, 17)
        Me.rbtorigen_0.TabIndex = 0
        Me.rbtorigen_0.TabStop = True
        Me.rbtorigen_0.Text = "Planillas"
        Me.rbtorigen_0.UseVisualStyleBackColor = True
        '
        'txttipdoc
        '
        Me.txttipdoc.Location = New System.Drawing.Point(493, 82)
        Me.txttipdoc.Name = "txttipdoc"
        Me.txttipdoc.NroDecimales = CType(0, Short)
        Me.txttipdoc.SelectGotFocus = True
        Me.txttipdoc.Size = New System.Drawing.Size(22, 20)
        Me.txttipdoc.TabIndex = 355
        Me.txttipdoc.Tabulado = True
        Me.txttipdoc.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtnumdoc
        '
        Me.txtnumdoc.Location = New System.Drawing.Point(516, 82)
        Me.txtnumdoc.Name = "txtnumdoc"
        Me.txtnumdoc.NroDecimales = CType(0, Short)
        Me.txtnumdoc.SelectGotFocus = True
        Me.txtnumdoc.Size = New System.Drawing.Size(69, 20)
        Me.txtnumdoc.TabIndex = 356
        Me.txtnumdoc.Tabulado = True
        Me.txtnumdoc.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(501, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 357
        Me.Label5.Text = "Tipo y Nº Doc."
        '
        'Frm_LibLeg_41remu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 332)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtnumdoc)
        Me.Controls.Add(Me.txttipdoc)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtimporte)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.txttrabajador)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.txtcuenta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtnombrecuenta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Name = "Frm_LibLeg_41remu"
        Me.Text = "Frm_LibLeg_41remu"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents txtimporte As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Friend WithEvents btninsertar As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txttrabajador As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Friend WithEvents txtcuenta As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnimportar As System.Windows.Forms.Button
    Friend WithEvents txtnombrecuenta As KS.UserControl.ksTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtorigen_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtorigen_0 As System.Windows.Forms.RadioButton
    Friend WithEvents txttipdoc As KS.UserControl.ksTextBox
    Friend WithEvents txtnumdoc As KS.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
