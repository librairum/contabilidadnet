<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Voucher_Cierres
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Voucher_Cierres))
        Me.btnGenVou = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.mskfecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTipCambio_gastos = New Ks.UserControl.ksTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTipCambio_Aper_Pas = New Ks.UserControl.ksTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTipCambio_Aper_Act = New Ks.UserControl.ksTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbtopcion_2 = New System.Windows.Forms.RadioButton()
        Me.rbtopcion_1 = New System.Windows.Forms.RadioButton()
        Me.rbtopcion_0 = New System.Windows.Forms.RadioButton()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Ks.UserControl.ksTextBox()
        Me.txtlibro = New Ks.UserControl.ksTextBox()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenVou
        '
        Me.btnGenVou.Location = New System.Drawing.Point(314, 134)
        Me.btnGenVou.Name = "btnGenVou"
        Me.btnGenVou.Size = New System.Drawing.Size(102, 22)
        Me.btnGenVou.TabIndex = 6
        Me.btnGenVou.Text = "Generar Voucher"
        Me.btnGenVou.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(713, 31)
        Me.Panel1.TabIndex = 200
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
        'mskfecha
        '
        Me.mskfecha.Location = New System.Drawing.Point(66, 43)
        Me.mskfecha.Mask = "00/00/0000"
        Me.mskfecha.Name = "mskfecha"
        Me.mskfecha.Size = New System.Drawing.Size(68, 20)
        Me.mskfecha.TabIndex = 2
        Me.mskfecha.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 209
        Me.Label4.Text = "Libro"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txtTipCambio_gastos)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtTipCambio_Aper_Pas)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtTipCambio_Aper_Act)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.rbtopcion_2)
        Me.GroupBox1.Controls.Add(Me.rbtopcion_1)
        Me.GroupBox1.Controls.Add(Me.rbtopcion_0)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 182)
        Me.GroupBox1.TabIndex = 199
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 220
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(6, 61)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(218, 9)
        Me.GroupBox4.TabIndex = 221
        Me.GroupBox4.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(6, 98)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(222, 9)
        Me.GroupBox3.TabIndex = 220
        Me.GroupBox3.TabStop = False
        '
        'txtTipCambio_gastos
        '
        Me.txtTipCambio_gastos.Location = New System.Drawing.Point(92, 39)
        Me.txtTipCambio_gastos.Name = "txtTipCambio_gastos"
        Me.txtTipCambio_gastos.NroDecimales = CType(4, Short)
        Me.txtTipCambio_gastos.SelectGotFocus = True
        Me.txtTipCambio_gastos.Size = New System.Drawing.Size(74, 20)
        Me.txtTipCambio_gastos.TabIndex = 200
        Me.txtTipCambio_gastos.Tabulado = True
        Me.txtTipCambio_gastos.Text = "0.0000"
        Me.txtTipCambio_gastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipCambio_gastos.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(40, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 201
        Me.Label9.Text = "T.Cambio"
        '
        'txtTipCambio_Aper_Pas
        '
        Me.txtTipCambio_Aper_Pas.Location = New System.Drawing.Point(100, 159)
        Me.txtTipCambio_Aper_Pas.Name = "txtTipCambio_Aper_Pas"
        Me.txtTipCambio_Aper_Pas.NroDecimales = CType(4, Short)
        Me.txtTipCambio_Aper_Pas.SelectGotFocus = True
        Me.txtTipCambio_Aper_Pas.Size = New System.Drawing.Size(74, 20)
        Me.txtTipCambio_Aper_Pas.TabIndex = 198
        Me.txtTipCambio_Aper_Pas.Tabulado = True
        Me.txtTipCambio_Aper_Pas.Text = "0.0000"
        Me.txtTipCambio_Aper_Pas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipCambio_Aper_Pas.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 199
        Me.Label8.Text = "T.C Pasivo"
        '
        'txtTipCambio_Aper_Act
        '
        Me.txtTipCambio_Aper_Act.Location = New System.Drawing.Point(100, 136)
        Me.txtTipCambio_Aper_Act.Name = "txtTipCambio_Aper_Act"
        Me.txtTipCambio_Aper_Act.NroDecimales = CType(4, Short)
        Me.txtTipCambio_Aper_Act.SelectGotFocus = True
        Me.txtTipCambio_Aper_Act.Size = New System.Drawing.Size(74, 20)
        Me.txtTipCambio_Aper_Act.TabIndex = 196
        Me.txtTipCambio_Aper_Act.Tabulado = True
        Me.txtTipCambio_Aper_Act.Text = "0.0000"
        Me.txtTipCambio_Aper_Act.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipCambio_Aper_Act.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 197
        Me.Label12.Text = "T.C Activos"
        '
        'rbtopcion_2
        '
        Me.rbtopcion_2.AutoSize = True
        Me.rbtopcion_2.Location = New System.Drawing.Point(8, 112)
        Me.rbtopcion_2.Name = "rbtopcion_2"
        Me.rbtopcion_2.Size = New System.Drawing.Size(167, 17)
        Me.rbtopcion_2.TabIndex = 2
        Me.rbtopcion_2.TabStop = True
        Me.rbtopcion_2.Text = "Generar  Voucher de Apertura"
        Me.rbtopcion_2.UseVisualStyleBackColor = True
        '
        'rbtopcion_1
        '
        Me.rbtopcion_1.AutoSize = True
        Me.rbtopcion_1.Location = New System.Drawing.Point(6, 74)
        Me.rbtopcion_1.Name = "rbtopcion_1"
        Me.rbtopcion_1.Size = New System.Drawing.Size(173, 17)
        Me.rbtopcion_1.TabIndex = 1
        Me.rbtopcion_1.TabStop = True
        Me.rbtopcion_1.Text = "Generar  Voucher de inventario"
        Me.rbtopcion_1.UseVisualStyleBackColor = True
        '
        'rbtopcion_0
        '
        Me.rbtopcion_0.AutoSize = True
        Me.rbtopcion_0.Location = New System.Drawing.Point(8, 20)
        Me.rbtopcion_0.Name = "rbtopcion_0"
        Me.rbtopcion_0.Size = New System.Drawing.Size(160, 17)
        Me.rbtopcion_0.TabIndex = 0
        Me.rbtopcion_0.TabStop = True
        Me.rbtopcion_0.Text = "Generar  Voucher de Gastos"
        Me.rbtopcion_0.UseVisualStyleBackColor = True
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(94, 19)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 210
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(120, 21)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(304, 18)
        Me.lblhelp_0.TabIndex = 205
        Me.lblhelp_0.Text = "???"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(64, 65)
        Me.txtDescripcion.MaxLength = 80
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.NroDecimales = CType(0, Short)
        Me.txtDescripcion.SelectGotFocus = True
        Me.txtDescripcion.Size = New System.Drawing.Size(356, 43)
        Me.txtDescripcion.TabIndex = 3
        Me.txtDescripcion.Tabulado = True
        Me.txtDescripcion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtlibro
        '
        Me.txtlibro.Location = New System.Drawing.Point(66, 21)
        Me.txtlibro.Name = "txtlibro"
        Me.txtlibro.NroDecimales = CType(0, Short)
        Me.txtlibro.SelectGotFocus = True
        Me.txtlibro.Size = New System.Drawing.Size(28, 20)
        Me.txtlibro.TabIndex = 0
        Me.txtlibro.Tabulado = True
        Me.txtlibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
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
        Me.tblhelp.Location = New System.Drawing.Point(4, 42)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(362, 138)
        Me.tblhelp.TabIndex = 202
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tblhelp)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btnGenVou)
        Me.GroupBox2.Controls.Add(Me.lblhelp_0)
        Me.GroupBox2.Controls.Add(Me.btnhelp_0)
        Me.GroupBox2.Controls.Add(Me.txtlibro)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.mskfecha)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Location = New System.Drawing.Point(264, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(434, 180)
        Me.GroupBox2.TabIndex = 219
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Voucher"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 215
        Me.Label11.Text = "Glosa"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 214
        Me.Label10.Text = "Fecha"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 244)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(713, 26)
        Me.Panel3.TabIndex = 220
        '
        'Frm_Voucher_Cierres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 270)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Voucher_Cierres"
        Me.Text = "Frm_VoucherCierres"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenVou As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents mskfecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As KS.UserControl.ksTextBox
    Friend WithEvents txtlibro As KS.UserControl.ksTextBox
    Friend WithEvents rbtopcion_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtopcion_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtopcion_0 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTipCambio_gastos As KS.UserControl.ksTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTipCambio_Aper_Pas As KS.UserControl.ksTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTipCambio_Aper_Act As KS.UserControl.ksTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
