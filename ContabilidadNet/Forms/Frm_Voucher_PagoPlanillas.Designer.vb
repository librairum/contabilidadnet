<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Voucher_PagoPlanillas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Voucher_PagoPlanillas))
        Me.mskfecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtNoVoucher = New Ks.UserControl.ksTextBox()
        Me.txtlibro = New Ks.UserControl.ksTextBox()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.txtCuenta = New Ks.UserControl.ksTextBox()
        Me.txtcomprobante = New Ks.UserControl.ksTextBox()
        Me.txtConcepto = New Ks.UserControl.ksTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTipCambio = New Ks.UserControl.ksTextBox()
        Me.cbomoneda = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnhelp_2 = New System.Windows.Forms.Button()
        Me.lblhelp_2 = New System.Windows.Forms.Label()
        Me.txtclaseplanilla = New Ks.UserControl.ksTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnhelp_3 = New System.Windows.Forms.Button()
        Me.lblhelp_3 = New System.Windows.Forms.Label()
        Me.txtplanilla = New Ks.UserControl.ksTextBox()
        Me.lblconcepto = New System.Windows.Forms.Label()
        Me.btnhelp_4 = New System.Windows.Forms.Button()
        Me.lblhelp_4 = New System.Windows.Forms.Label()
        Me.txtcodconcepto = New Ks.UserControl.ksTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btntraerimportes = New System.Windows.Forms.Button()
        Me.btngenerar = New System.Windows.Forms.Button()
        Me.btncargoabono_0 = New System.Windows.Forms.RadioButton()
        Me.btncargoabono_1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnhelp_5 = New System.Windows.Forms.Button()
        Me.lblhelp_5 = New System.Windows.Forms.Label()
        Me.txttipocalculo = New Ks.UserControl.ksTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNoDoc = New Ks.UserControl.ksTextBox()
        Me.txtTipDoc = New Ks.UserControl.ksTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mskfecha
        '
        Me.mskfecha.Location = New System.Drawing.Point(580, 76)
        Me.mskfecha.Mask = "00/00/0000"
        Me.mskfecha.Name = "mskfecha"
        Me.mskfecha.Size = New System.Drawing.Size(68, 20)
        Me.mskfecha.TabIndex = 7
        Me.mskfecha.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(540, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 219
        Me.Label5.Text = "Fecha"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(427, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 218
        Me.Label9.Text = "Numero"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(441, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 217
        Me.Label10.Text = "Libro"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(502, 54)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 220
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(522, 56)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(218, 18)
        Me.lblhelp_0.TabIndex = 216
        Me.lblhelp_0.Text = "???"
        '
        'txtNoVoucher
        '
        Me.txtNoVoucher.Location = New System.Drawing.Point(474, 76)
        Me.txtNoVoucher.MaxLength = 5
        Me.txtNoVoucher.Name = "txtNoVoucher"
        Me.txtNoVoucher.NroDecimales = CType(0, Short)
        Me.txtNoVoucher.SelectGotFocus = True
        Me.txtNoVoucher.Size = New System.Drawing.Size(62, 20)
        Me.txtNoVoucher.TabIndex = 6
        Me.txtNoVoucher.Tabulado = True
        Me.txtNoVoucher.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtlibro
        '
        Me.txtlibro.Location = New System.Drawing.Point(474, 55)
        Me.txtlibro.Name = "txtlibro"
        Me.txtlibro.NroDecimales = CType(0, Short)
        Me.txtlibro.SelectGotFocus = True
        Me.txtlibro.Size = New System.Drawing.Size(28, 20)
        Me.txtlibro.TabIndex = 5
        Me.txtlibro.Tabulado = True
        Me.txtlibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(574, 141)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 228
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(594, 142)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(150, 18)
        Me.lblhelp_1.TabIndex = 227
        Me.lblhelp_1.Text = "???"
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(474, 142)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.NroDecimales = CType(0, Short)
        Me.txtCuenta.SelectGotFocus = True
        Me.txtCuenta.Size = New System.Drawing.Size(102, 20)
        Me.txtCuenta.TabIndex = 12
        Me.txtCuenta.Tabulado = True
        Me.txtCuenta.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtcomprobante
        '
        Me.txtcomprobante.Location = New System.Drawing.Point(634, 98)
        Me.txtcomprobante.Name = "txtcomprobante"
        Me.txtcomprobante.NroDecimales = CType(0, Short)
        Me.txtcomprobante.SelectGotFocus = True
        Me.txtcomprobante.Size = New System.Drawing.Size(110, 20)
        Me.txtcomprobante.TabIndex = 10
        Me.txtcomprobante.Tabulado = True
        Me.txtcomprobante.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(474, 120)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.NroDecimales = CType(0, Short)
        Me.txtConcepto.SelectGotFocus = True
        Me.txtConcepto.Size = New System.Drawing.Size(272, 20)
        Me.txtConcepto.TabIndex = 11
        Me.txtConcepto.Tabulado = True
        Me.txtConcepto.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(430, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 222
        Me.Label7.Text = "Cuenta"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(545, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "Nº Comprobante"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(437, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "Glosa"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(425, 100)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 232
        Me.Label17.Text = "Moneda"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(650, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 231
        Me.Label12.Text = "T.C"
        '
        'txtTipCambio
        '
        Me.txtTipCambio.Location = New System.Drawing.Point(676, 76)
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.NroDecimales = CType(4, Short)
        Me.txtTipCambio.SelectGotFocus = True
        Me.txtTipCambio.Size = New System.Drawing.Size(64, 20)
        Me.txtTipCambio.TabIndex = 8
        Me.txtTipCambio.Tabulado = True
        Me.txtTipCambio.Text = "0.0000"
        Me.txtTipCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipCambio.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'cbomoneda
        '
        Me.cbomoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomoneda.FormattingEnabled = True
        Me.cbomoneda.Items.AddRange(New Object() {"S", "D"})
        Me.cbomoneda.Location = New System.Drawing.Point(474, 97)
        Me.cbomoneda.Name = "cbomoneda"
        Me.cbomoneda.Size = New System.Drawing.Size(40, 21)
        Me.cbomoneda.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "Planilla"
        '
        'btnhelp_2
        '
        Me.btnhelp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_2.Location = New System.Drawing.Point(102, 73)
        Me.btnhelp_2.Name = "btnhelp_2"
        Me.btnhelp_2.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_2.TabIndex = 236
        Me.btnhelp_2.Text = ":::"
        Me.btnhelp_2.UseVisualStyleBackColor = True
        '
        'lblhelp_2
        '
        Me.lblhelp_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_2.Location = New System.Drawing.Point(124, 76)
        Me.lblhelp_2.Name = "lblhelp_2"
        Me.lblhelp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_2.Size = New System.Drawing.Size(174, 18)
        Me.lblhelp_2.TabIndex = 234
        Me.lblhelp_2.Text = "???"
        '
        'txtclaseplanilla
        '
        Me.txtclaseplanilla.Location = New System.Drawing.Point(76, 75)
        Me.txtclaseplanilla.Name = "txtclaseplanilla"
        Me.txtclaseplanilla.NroDecimales = CType(0, Short)
        Me.txtclaseplanilla.SelectGotFocus = True
        Me.txtclaseplanilla.Size = New System.Drawing.Size(28, 20)
        Me.txtclaseplanilla.TabIndex = 1
        Me.txtclaseplanilla.Tabulado = True
        Me.txtclaseplanilla.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Periodo"
        '
        'btnhelp_3
        '
        Me.btnhelp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_3.Location = New System.Drawing.Point(160, 95)
        Me.btnhelp_3.Name = "btnhelp_3"
        Me.btnhelp_3.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_3.TabIndex = 240
        Me.btnhelp_3.Text = ":::"
        Me.btnhelp_3.UseVisualStyleBackColor = True
        '
        'lblhelp_3
        '
        Me.lblhelp_3.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_3.Location = New System.Drawing.Point(182, 96)
        Me.lblhelp_3.Name = "lblhelp_3"
        Me.lblhelp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_3.Size = New System.Drawing.Size(116, 18)
        Me.lblhelp_3.TabIndex = 238
        Me.lblhelp_3.Text = "???"
        '
        'txtplanilla
        '
        Me.txtplanilla.Location = New System.Drawing.Point(76, 96)
        Me.txtplanilla.Name = "txtplanilla"
        Me.txtplanilla.NroDecimales = CType(0, Short)
        Me.txtplanilla.SelectGotFocus = True
        Me.txtplanilla.Size = New System.Drawing.Size(84, 20)
        Me.txtplanilla.TabIndex = 2
        Me.txtplanilla.Tabulado = True
        Me.txtplanilla.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'lblconcepto
        '
        Me.lblconcepto.AutoSize = True
        Me.lblconcepto.Location = New System.Drawing.Point(4, 123)
        Me.lblconcepto.Name = "lblconcepto"
        Me.lblconcepto.Size = New System.Drawing.Size(53, 13)
        Me.lblconcepto.TabIndex = 243
        Me.lblconcepto.Text = "Concepto"
        '
        'btnhelp_4
        '
        Me.btnhelp_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_4.Location = New System.Drawing.Point(160, 117)
        Me.btnhelp_4.Name = "btnhelp_4"
        Me.btnhelp_4.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_4.TabIndex = 244
        Me.btnhelp_4.Text = ":::"
        Me.btnhelp_4.UseVisualStyleBackColor = True
        '
        'lblhelp_4
        '
        Me.lblhelp_4.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_4.Location = New System.Drawing.Point(182, 118)
        Me.lblhelp_4.Name = "lblhelp_4"
        Me.lblhelp_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_4.Size = New System.Drawing.Size(118, 18)
        Me.lblhelp_4.TabIndex = 242
        Me.lblhelp_4.Text = "???"
        '
        'txtcodconcepto
        '
        Me.txtcodconcepto.Location = New System.Drawing.Point(76, 117)
        Me.txtcodconcepto.Name = "txtcodconcepto"
        Me.txtcodconcepto.NroDecimales = CType(0, Short)
        Me.txtcodconcepto.SelectGotFocus = True
        Me.txtcodconcepto.Size = New System.Drawing.Size(84, 20)
        Me.txtcodconcepto.TabIndex = 3
        Me.txtcodconcepto.Tabulado = True
        Me.txtcodconcepto.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 325)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(752, 26)
        Me.Panel3.TabIndex = 247
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
        Me.Panel1.Size = New System.Drawing.Size(752, 31)
        Me.Panel1.TabIndex = 248
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(702, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btntraerimportes
        '
        Me.btntraerimportes.Location = New System.Drawing.Point(304, 110)
        Me.btntraerimportes.Name = "btntraerimportes"
        Me.btntraerimportes.Size = New System.Drawing.Size(101, 28)
        Me.btntraerimportes.TabIndex = 4
        Me.btntraerimportes.Text = "Mostrar Importes"
        Me.btntraerimportes.UseVisualStyleBackColor = True
        '
        'btngenerar
        '
        Me.btngenerar.Location = New System.Drawing.Point(504, 228)
        Me.btngenerar.Name = "btngenerar"
        Me.btngenerar.Size = New System.Drawing.Size(196, 28)
        Me.btngenerar.TabIndex = 16
        Me.btngenerar.Text = "Generar Detalle de Voucher"
        Me.btngenerar.UseVisualStyleBackColor = True
        '
        'btncargoabono_0
        '
        Me.btncargoabono_0.AutoSize = True
        Me.btncargoabono_0.Location = New System.Drawing.Point(4, 4)
        Me.btncargoabono_0.Name = "btncargoabono_0"
        Me.btncargoabono_0.Size = New System.Drawing.Size(53, 17)
        Me.btncargoabono_0.TabIndex = 0
        Me.btncargoabono_0.TabStop = True
        Me.btncargoabono_0.Text = "Cargo"
        Me.btncargoabono_0.UseVisualStyleBackColor = True
        '
        'btncargoabono_1
        '
        Me.btncargoabono_1.AutoSize = True
        Me.btncargoabono_1.Location = New System.Drawing.Point(56, 5)
        Me.btncargoabono_1.Name = "btncargoabono_1"
        Me.btncargoabono_1.Size = New System.Drawing.Size(56, 17)
        Me.btncargoabono_1.TabIndex = 1
        Me.btncargoabono_1.TabStop = True
        Me.btncargoabono_1.Text = "Abono"
        Me.btncargoabono_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btncargoabono_1)
        Me.GroupBox2.Controls.Add(Me.btncargoabono_0)
        Me.GroupBox2.Location = New System.Drawing.Point(474, 199)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(270, 25)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
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
        Me.tblhelp.Location = New System.Drawing.Point(98, 128)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(340, 140)
        Me.tblhelp.TabIndex = 256
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
        Me.tblconsulta.Location = New System.Drawing.Point(3, 144)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(405, 177)
        Me.tblconsulta.TabIndex = 245
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 249
        Me.Label3.Text = "Tipo Calculo"
        '
        'btnhelp_5
        '
        Me.btnhelp_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_5.Location = New System.Drawing.Point(102, 51)
        Me.btnhelp_5.Name = "btnhelp_5"
        Me.btnhelp_5.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_5.TabIndex = 252
        Me.btnhelp_5.Text = ":::"
        Me.btnhelp_5.UseVisualStyleBackColor = True
        '
        'lblhelp_5
        '
        Me.lblhelp_5.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_5.Location = New System.Drawing.Point(124, 54)
        Me.lblhelp_5.Name = "lblhelp_5"
        Me.lblhelp_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_5.Size = New System.Drawing.Size(176, 18)
        Me.lblhelp_5.TabIndex = 251
        Me.lblhelp_5.Text = "???"
        '
        'txttipocalculo
        '
        Me.txttipocalculo.Location = New System.Drawing.Point(76, 53)
        Me.txttipocalculo.Name = "txttipocalculo"
        Me.txttipocalculo.NroDecimales = CType(0, Short)
        Me.txttipocalculo.SelectGotFocus = True
        Me.txttipocalculo.Size = New System.Drawing.Size(28, 20)
        Me.txttipocalculo.TabIndex = 0
        Me.txttipocalculo.Tabulado = True
        Me.txttipocalculo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(426, 177)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 285
        Me.Label13.Text = "Tip Doc"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(508, 178)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 284
        Me.Label14.Text = "Nº  Doc"
        '
        'txtNoDoc
        '
        Me.txtNoDoc.Location = New System.Drawing.Point(555, 176)
        Me.txtNoDoc.Name = "txtNoDoc"
        Me.txtNoDoc.NroDecimales = CType(0, Short)
        Me.txtNoDoc.SelectGotFocus = True
        Me.txtNoDoc.Size = New System.Drawing.Size(76, 20)
        Me.txtNoDoc.TabIndex = 14
        Me.txtNoDoc.Tabulado = True
        Me.txtNoDoc.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtTipDoc
        '
        Me.txtTipDoc.Location = New System.Drawing.Point(474, 174)
        Me.txtTipDoc.Name = "txtTipDoc"
        Me.txtTipDoc.NroDecimales = CType(0, Short)
        Me.txtTipDoc.SelectGotFocus = True
        Me.txtTipDoc.Size = New System.Drawing.Size(32, 20)
        Me.txtTipDoc.TabIndex = 13
        Me.txtTipDoc.Tabulado = True
        Me.txtTipDoc.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(414, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(3, 291)
        Me.GroupBox1.TabIndex = 291
        Me.GroupBox1.TabStop = False
        '
        'Frm_Voucher_PagoPlanillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 351)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNoDoc)
        Me.Controls.Add(Me.txtTipDoc)
        Me.Controls.Add(Me.btnhelp_5)
        Me.Controls.Add(Me.lblhelp_5)
        Me.Controls.Add(Me.txttipocalculo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btngenerar)
        Me.Controls.Add(Me.btntraerimportes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.lblconcepto)
        Me.Controls.Add(Me.btnhelp_4)
        Me.Controls.Add(Me.lblhelp_4)
        Me.Controls.Add(Me.txtcodconcepto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnhelp_3)
        Me.Controls.Add(Me.lblhelp_3)
        Me.Controls.Add(Me.txtplanilla)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnhelp_2)
        Me.Controls.Add(Me.lblhelp_2)
        Me.Controls.Add(Me.txtclaseplanilla)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTipCambio)
        Me.Controls.Add(Me.cbomoneda)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtcomprobante)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mskfecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txtNoVoucher)
        Me.Controls.Add(Me.txtlibro)
        Me.Name = "Frm_Voucher_PagoPlanillas"
        Me.Text = "Frm_Voucher_PagoPlanillas"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mskfecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtNoVoucher As Ks.UserControl.ksTextBox
    Friend WithEvents txtlibro As Ks.UserControl.ksTextBox
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As Ks.UserControl.ksTextBox
    Friend WithEvents txtcomprobante As Ks.UserControl.ksTextBox
    Friend WithEvents txtConcepto As Ks.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTipCambio As Ks.UserControl.ksTextBox
    Friend WithEvents cbomoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_2 As System.Windows.Forms.Button
    Public WithEvents lblhelp_2 As System.Windows.Forms.Label
    Friend WithEvents txtclaseplanilla As Ks.UserControl.ksTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_3 As System.Windows.Forms.Button
    Public WithEvents lblhelp_3 As System.Windows.Forms.Label
    Friend WithEvents txtplanilla As Ks.UserControl.ksTextBox
    Friend WithEvents lblconcepto As System.Windows.Forms.Label
    Friend WithEvents btnhelp_4 As System.Windows.Forms.Button
    Public WithEvents lblhelp_4 As System.Windows.Forms.Label
    Friend WithEvents txtcodconcepto As Ks.UserControl.ksTextBox
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btntraerimportes As System.Windows.Forms.Button
    Friend WithEvents btngenerar As System.Windows.Forms.Button
    Friend WithEvents btncargoabono_0 As System.Windows.Forms.RadioButton
    Friend WithEvents btncargoabono_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_5 As System.Windows.Forms.Button
    Public WithEvents lblhelp_5 As System.Windows.Forms.Label
    Friend WithEvents txttipocalculo As KS.UserControl.ksTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNoDoc As KS.UserControl.ksTextBox
    Friend WithEvents txtTipDoc As KS.UserControl.ksTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
