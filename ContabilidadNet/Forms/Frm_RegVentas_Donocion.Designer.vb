<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegVentas_Donocion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegVentas_Donocion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.txtCuenta = New Ks.UserControl.ksTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCtaCte = New Ks.UserControl.ksTextBox()
        Me.btnhelp_2 = New System.Windows.Forms.Button()
        Me.lblhelp_2 = New System.Windows.Forms.Label()
        Me.lblctacte = New System.Windows.Forms.Label()
        Me.btnhelp_3 = New System.Windows.Forms.Button()
        Me.lblhelp_3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTipDoc = New Ks.UserControl.ksTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNoDoc = New Ks.UserControl.ksTextBox()
        Me.mskFecDoc = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTipCambio = New Ks.UserControl.ksTextBox()
        Me.cbomoneda = New System.Windows.Forms.ComboBox()
        Me.txtHaber_1 = New Ks.UserControl.ksTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDebe_1 = New Ks.UserControl.ksTextBox()
        Me.txtHaber_0 = New Ks.UserControl.ksTextBox()
        Me.txtDebe_0 = New Ks.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtlibro = New Ks.UserControl.ksTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNoVoucher = New Ks.UserControl.ksTextBox()
        Me.txttotal_0 = New Ks.UserControl.ksTextBox()
        Me.txttotal_1 = New Ks.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtInafecto_0 = New Ks.UserControl.ksTextBox()
        Me.txtInafecto_1 = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 33)
        Me.Panel1.TabIndex = 13
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(91, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 6
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(702, 4)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(69, 2)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 0
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(47, 2)
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
        Me.btnmodificar.Location = New System.Drawing.Point(26, 2)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 13
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 347)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(748, 26)
        Me.Panel3.TabIndex = 164
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(150, 57)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 204
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(172, 60)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(154, 18)
        Me.lblhelp_1.TabIndex = 203
        Me.lblhelp_1.Text = "???"
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(50, 57)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.NroDecimales = CType(0, Short)
        Me.txtCuenta.SelectGotFocus = True
        Me.txtCuenta.Size = New System.Drawing.Size(100, 20)
        Me.txtCuenta.TabIndex = 2
        Me.txtCuenta.Tabulado = True
        Me.txtCuenta.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 202
        Me.Label7.Text = "Cuenta"
        '
        'txtCtaCte
        '
        Me.txtCtaCte.Location = New System.Drawing.Point(50, 79)
        Me.txtCtaCte.Name = "txtCtaCte"
        Me.txtCtaCte.NroDecimales = CType(0, Short)
        Me.txtCtaCte.SelectGotFocus = True
        Me.txtCtaCte.Size = New System.Drawing.Size(100, 20)
        Me.txtCtaCte.TabIndex = 3
        Me.txtCtaCte.Tabulado = True
        Me.txtCtaCte.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_2
        '
        Me.btnhelp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_2.Location = New System.Drawing.Point(150, 79)
        Me.btnhelp_2.Name = "btnhelp_2"
        Me.btnhelp_2.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_2.TabIndex = 211
        Me.btnhelp_2.Text = ":::"
        Me.btnhelp_2.UseVisualStyleBackColor = True
        '
        'lblhelp_2
        '
        Me.lblhelp_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_2.Location = New System.Drawing.Point(172, 81)
        Me.lblhelp_2.Name = "lblhelp_2"
        Me.lblhelp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_2.Size = New System.Drawing.Size(154, 18)
        Me.lblhelp_2.TabIndex = 210
        Me.lblhelp_2.Text = "???"
        '
        'lblctacte
        '
        Me.lblctacte.AutoSize = True
        Me.lblctacte.Location = New System.Drawing.Point(6, 82)
        Me.lblctacte.Name = "lblctacte"
        Me.lblctacte.Size = New System.Drawing.Size(42, 13)
        Me.lblctacte.TabIndex = 208
        Me.lblctacte.Text = "Cta Cte"
        '
        'btnhelp_3
        '
        Me.btnhelp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_3.Location = New System.Drawing.Point(84, 100)
        Me.btnhelp_3.Name = "btnhelp_3"
        Me.btnhelp_3.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_3.TabIndex = 215
        Me.btnhelp_3.Text = ":::"
        Me.btnhelp_3.UseVisualStyleBackColor = True
        '
        'lblhelp_3
        '
        Me.lblhelp_3.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_3.Location = New System.Drawing.Point(106, 102)
        Me.lblhelp_3.Name = "lblhelp_3"
        Me.lblhelp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_3.Size = New System.Drawing.Size(218, 18)
        Me.lblhelp_3.TabIndex = 214
        Me.lblhelp_3.Text = "???"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 213
        Me.Label10.Text = "Tip Doc"
        '
        'txtTipDoc
        '
        Me.txtTipDoc.Location = New System.Drawing.Point(50, 101)
        Me.txtTipDoc.Name = "txtTipDoc"
        Me.txtTipDoc.NroDecimales = CType(0, Short)
        Me.txtTipDoc.SelectGotFocus = True
        Me.txtTipDoc.Size = New System.Drawing.Size(34, 20)
        Me.txtTipDoc.TabIndex = 4
        Me.txtTipDoc.Tabulado = True
        Me.txtTipDoc.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 217
        Me.Label9.Text = "Nº  Doc"
        '
        'txtNoDoc
        '
        Me.txtNoDoc.Location = New System.Drawing.Point(50, 125)
        Me.txtNoDoc.Name = "txtNoDoc"
        Me.txtNoDoc.NroDecimales = CType(0, Short)
        Me.txtNoDoc.SelectGotFocus = True
        Me.txtNoDoc.Size = New System.Drawing.Size(76, 20)
        Me.txtNoDoc.TabIndex = 5
        Me.txtNoDoc.Tabulado = True
        Me.txtNoDoc.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'mskFecDoc
        '
        Me.mskFecDoc.Location = New System.Drawing.Point(250, 125)
        Me.mskFecDoc.Mask = "00/00/0000"
        Me.mskFecDoc.Name = "mskFecDoc"
        Me.mskFecDoc.Size = New System.Drawing.Size(78, 20)
        Me.mskFecDoc.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(198, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 219
        Me.Label1.Text = "FecDoc"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(2, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 224
        Me.Label17.Text = "Moneda"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(184, 148)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 223
        Me.Label12.Text = "Tip.Cambio"
        '
        'txtTipCambio
        '
        Me.txtTipCambio.Location = New System.Drawing.Point(250, 147)
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.NroDecimales = CType(4, Short)
        Me.txtTipCambio.SelectGotFocus = True
        Me.txtTipCambio.Size = New System.Drawing.Size(76, 20)
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
        Me.cbomoneda.Location = New System.Drawing.Point(50, 147)
        Me.cbomoneda.Name = "cbomoneda"
        Me.cbomoneda.Size = New System.Drawing.Size(48, 21)
        Me.cbomoneda.TabIndex = 7
        '
        'txtHaber_1
        '
        Me.txtHaber_1.Location = New System.Drawing.Point(189, 248)
        Me.txtHaber_1.Name = "txtHaber_1"
        Me.txtHaber_1.NroDecimales = CType(2, Short)
        Me.txtHaber_1.SelectGotFocus = True
        Me.txtHaber_1.Size = New System.Drawing.Size(137, 20)
        Me.txtHaber_1.TabIndex = 13
        Me.txtHaber_1.Tabulado = True
        Me.txtHaber_1.Text = "0.00"
        Me.txtHaber_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHaber_1.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(-2, 209)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 230
        Me.Label16.Text = "Base Imp"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(23, 251)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 13)
        Me.Label15.TabIndex = 229
        Me.Label15.Text = "IGV"
        '
        'txtDebe_1
        '
        Me.txtDebe_1.Location = New System.Drawing.Point(189, 205)
        Me.txtDebe_1.Name = "txtDebe_1"
        Me.txtDebe_1.NroDecimales = CType(2, Short)
        Me.txtDebe_1.SelectGotFocus = True
        Me.txtDebe_1.Size = New System.Drawing.Size(137, 20)
        Me.txtDebe_1.TabIndex = 12
        Me.txtDebe_1.Tabulado = True
        Me.txtDebe_1.Text = "0.00"
        Me.txtDebe_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebe_1.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtHaber_0
        '
        Me.txtHaber_0.Location = New System.Drawing.Point(50, 248)
        Me.txtHaber_0.Name = "txtHaber_0"
        Me.txtHaber_0.NroDecimales = CType(2, Short)
        Me.txtHaber_0.SelectGotFocus = True
        Me.txtHaber_0.Size = New System.Drawing.Size(137, 20)
        Me.txtHaber_0.TabIndex = 11
        Me.txtHaber_0.Tabulado = True
        Me.txtHaber_0.Text = "0.00"
        Me.txtHaber_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHaber_0.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtDebe_0
        '
        Me.txtDebe_0.Location = New System.Drawing.Point(50, 205)
        Me.txtDebe_0.Name = "txtDebe_0"
        Me.txtDebe_0.NroDecimales = CType(2, Short)
        Me.txtDebe_0.SelectGotFocus = True
        Me.txtDebe_0.Size = New System.Drawing.Size(137, 20)
        Me.txtDebe_0.TabIndex = 9
        Me.txtDebe_0.Tabulado = True
        Me.txtDebe_0.Text = "0.00"
        Me.txtDebe_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebe_0.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Libro"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(76, 35)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 234
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(96, 35)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(102, 18)
        Me.lblhelp_0.TabIndex = 232
        Me.lblhelp_0.Text = "???"
        '
        'txtlibro
        '
        Me.txtlibro.Location = New System.Drawing.Point(50, 35)
        Me.txtlibro.Name = "txtlibro"
        Me.txtlibro.NroDecimales = CType(0, Short)
        Me.txtlibro.SelectGotFocus = True
        Me.txtlibro.Size = New System.Drawing.Size(28, 20)
        Me.txtlibro.TabIndex = 0
        Me.txtlibro.Tabulado = True
        Me.txtlibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(204, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Nº Voucher"
        '
        'txtNoVoucher
        '
        Me.txtNoVoucher.Location = New System.Drawing.Point(266, 36)
        Me.txtNoVoucher.MaxLength = 5
        Me.txtNoVoucher.Name = "txtNoVoucher"
        Me.txtNoVoucher.NroDecimales = CType(0, Short)
        Me.txtNoVoucher.SelectGotFocus = True
        Me.txtNoVoucher.Size = New System.Drawing.Size(62, 20)
        Me.txtNoVoucher.TabIndex = 1
        Me.txtNoVoucher.Tabulado = True
        Me.txtNoVoucher.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txttotal_0
        '
        Me.txttotal_0.Location = New System.Drawing.Point(50, 270)
        Me.txttotal_0.Name = "txttotal_0"
        Me.txttotal_0.NroDecimales = CType(2, Short)
        Me.txttotal_0.SelectGotFocus = True
        Me.txttotal_0.Size = New System.Drawing.Size(137, 20)
        Me.txttotal_0.TabIndex = 12
        Me.txttotal_0.Tabulado = True
        Me.txttotal_0.Text = "0.00"
        Me.txttotal_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotal_0.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txttotal_1
        '
        Me.txttotal_1.Location = New System.Drawing.Point(189, 269)
        Me.txttotal_1.Name = "txttotal_1"
        Me.txttotal_1.NroDecimales = CType(2, Short)
        Me.txttotal_1.SelectGotFocus = True
        Me.txttotal_1.Size = New System.Drawing.Size(137, 20)
        Me.txttotal_1.TabIndex = 14
        Me.txttotal_1.Tabulado = True
        Me.txttotal_1.Text = "0.00"
        Me.txttotal_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotal_1.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-2, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "Imp Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(148, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 240
        Me.Label6.Text = "Monto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(229, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 241
        Me.Label8.Text = "Monto Equivalente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(50, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 10)
        Me.GroupBox1.TabIndex = 242
        Me.GroupBox1.TabStop = False
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
        Me.tblconsulta.Location = New System.Drawing.Point(332, 36)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(400, 274)
        Me.tblconsulta.TabIndex = 163
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
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
        Me.tblhelp.Location = New System.Drawing.Point(348, 118)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(340, 140)
        Me.tblhelp.TabIndex = 243
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'txtInafecto_0
        '
        Me.txtInafecto_0.Location = New System.Drawing.Point(50, 226)
        Me.txtInafecto_0.Name = "txtInafecto_0"
        Me.txtInafecto_0.NroDecimales = CType(2, Short)
        Me.txtInafecto_0.SelectGotFocus = True
        Me.txtInafecto_0.Size = New System.Drawing.Size(137, 20)
        Me.txtInafecto_0.TabIndex = 10
        Me.txtInafecto_0.Tabulado = True
        Me.txtInafecto_0.Text = "0.00"
        Me.txtInafecto_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtInafecto_0.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtInafecto_1
        '
        Me.txtInafecto_1.Location = New System.Drawing.Point(189, 226)
        Me.txtInafecto_1.Name = "txtInafecto_1"
        Me.txtInafecto_1.NroDecimales = CType(2, Short)
        Me.txtInafecto_1.SelectGotFocus = True
        Me.txtInafecto_1.Size = New System.Drawing.Size(137, 20)
        Me.txtInafecto_1.TabIndex = 245
        Me.txtInafecto_1.Tabulado = True
        Me.txtInafecto_1.Text = "0.00"
        Me.txtInafecto_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtInafecto_1.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 246
        Me.Label3.Text = "Inafect"
        '
        'Frm_RegVentas_Donocion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 373)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtInafecto_1)
        Me.Controls.Add(Me.txtInafecto_0)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txttotal_1)
        Me.Controls.Add(Me.txttotal_0)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNoVoucher)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txtlibro)
        Me.Controls.Add(Me.txtHaber_1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtDebe_1)
        Me.Controls.Add(Me.txtHaber_0)
        Me.Controls.Add(Me.txtDebe_0)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTipCambio)
        Me.Controls.Add(Me.cbomoneda)
        Me.Controls.Add(Me.mskFecDoc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNoDoc)
        Me.Controls.Add(Me.btnhelp_3)
        Me.Controls.Add(Me.lblhelp_3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTipDoc)
        Me.Controls.Add(Me.txtCtaCte)
        Me.Controls.Add(Me.btnhelp_2)
        Me.Controls.Add(Me.lblhelp_2)
        Me.Controls.Add(Me.lblctacte)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_RegVentas_Donocion"
        Me.Text = "Frm_RegVentas_Donocion"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As KS.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCtaCte As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_2 As System.Windows.Forms.Button
    Public WithEvents lblhelp_2 As System.Windows.Forms.Label
    Friend WithEvents lblctacte As System.Windows.Forms.Label
    Friend WithEvents btnhelp_3 As System.Windows.Forms.Button
    Public WithEvents lblhelp_3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTipDoc As KS.UserControl.ksTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNoDoc As KS.UserControl.ksTextBox
    Friend WithEvents mskFecDoc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTipCambio As KS.UserControl.ksTextBox
    Friend WithEvents cbomoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtHaber_1 As KS.UserControl.ksTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDebe_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtHaber_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtDebe_0 As KS.UserControl.ksTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtlibro As KS.UserControl.ksTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNoVoucher As KS.UserControl.ksTextBox
    Friend WithEvents txttotal_0 As KS.UserControl.ksTextBox
    Friend WithEvents txttotal_1 As KS.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtInafecto_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtInafecto_1 As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
