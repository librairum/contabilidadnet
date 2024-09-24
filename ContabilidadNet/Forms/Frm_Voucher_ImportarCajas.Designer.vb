<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Voucher_ImportarCajas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Voucher_ImportarCajas))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnvalidar = New System.Windows.Forms.Button
        Me.btnImportar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.tblvalidacion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tblgeneravoucher = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Btngenerarvoucher = New System.Windows.Forms.Button
        Me.btngrabavoucher = New System.Windows.Forms.Button
        Me.btnhelp_0 = New System.Windows.Forms.Button
        Me.lblhelp_1 = New System.Windows.Forms.Label
        Me.txtCuentaprov = New Ks.UserControl.ksTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnhelp_1 = New System.Windows.Forms.Button
        Me.lblhelp_0 = New System.Windows.Forms.Label
        Me.txtlibroproveedores = New Ks.UserControl.ksTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNoVoucherprov = New Ks.UserControl.ksTextBox
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grbdatosvouchercaja = New System.Windows.Forms.GroupBox
        Me.txtNoVouchercaja = New Ks.UserControl.ksTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnhelp_2 = New System.Windows.Forms.Button
        Me.lblhelp_2 = New System.Windows.Forms.Label
        Me.txtlibrocaja = New Ks.UserControl.ksTextBox
        Me.btnhelp_3 = New System.Windows.Forms.Button
        Me.lblhelp_3 = New System.Windows.Forms.Label
        Me.txtCuentacaja = New Ks.UserControl.ksTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grbvalidaciones = New System.Windows.Forms.GroupBox
        Me.btncancelar1 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblvalidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblgeneravoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbdatosvouchercaja.SuspendLayout()
        Me.grbvalidaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(958, 29)
        Me.Panel1.TabIndex = 152
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(902, 0)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 22
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnvalidar
        '
        Me.btnvalidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnvalidar.Image = Global.ContabilidadNet.My.Resources.Resources.Verificarcuentas
        Me.btnvalidar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnvalidar.Location = New System.Drawing.Point(253, 205)
        Me.btnvalidar.Name = "btnvalidar"
        Me.btnvalidar.Size = New System.Drawing.Size(256, 24)
        Me.btnvalidar.TabIndex = 24
        Me.btnvalidar.Text = "Paso 3 : Validar Inconsistencias"
        Me.btnvalidar.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnImportar.Location = New System.Drawing.Point(6, 35)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(203, 24)
        Me.btnImportar.TabIndex = 23
        Me.btnImportar.Text = "Paso 1 : Importar Archivo"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-318, -142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 17)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Registros Importados"
        '
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdate = False
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images1"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images2"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(6, 61)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(928, 134)
        Me.tblconsulta.TabIndex = 153
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 473)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(958, 26)
        Me.Panel3.TabIndex = 154
        '
        'tblvalidacion
        '
        Me.tblvalidacion.AllowUpdate = False
        Me.tblvalidacion.AllowUpdateOnBlur = False
        Me.tblvalidacion.AlternatingRows = True
        Me.tblvalidacion.FilterBar = True
        Me.tblvalidacion.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblvalidacion.Images.Add(CType(resources.GetObject("tblvalidacion.Images"), System.Drawing.Image))
        Me.tblvalidacion.Images.Add(CType(resources.GetObject("tblvalidacion.Images1"), System.Drawing.Image))
        Me.tblvalidacion.Images.Add(CType(resources.GetObject("tblvalidacion.Images2"), System.Drawing.Image))
        Me.tblvalidacion.LinesPerRow = 1
        Me.tblvalidacion.Location = New System.Drawing.Point(8, 35)
        Me.tblvalidacion.Name = "tblvalidacion"
        Me.tblvalidacion.PictureCurrentRow = CType(resources.GetObject("tblvalidacion.PictureCurrentRow"), System.Drawing.Image)
        Me.tblvalidacion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblvalidacion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblvalidacion.PreviewInfo.ZoomFactor = 75
        Me.tblvalidacion.PrintInfo.PageSettings = CType(resources.GetObject("tblvalidacion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblvalidacion.Size = New System.Drawing.Size(790, 153)
        Me.tblvalidacion.TabIndex = 157
        Me.tblvalidacion.TabStop = False
        Me.tblvalidacion.Text = "C1TrueDBGrid1"
        Me.tblvalidacion.UseColumnStyles = False
        Me.tblvalidacion.PropBag = resources.GetString("tblvalidacion.PropBag")
        '
        'tblgeneravoucher
        '
        Me.tblgeneravoucher.AllowUpdate = False
        Me.tblgeneravoucher.AllowUpdateOnBlur = False
        Me.tblgeneravoucher.AlternatingRows = True
        Me.tblgeneravoucher.FilterBar = True
        Me.tblgeneravoucher.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblgeneravoucher.Images.Add(CType(resources.GetObject("tblgeneravoucher.Images"), System.Drawing.Image))
        Me.tblgeneravoucher.Images.Add(CType(resources.GetObject("tblgeneravoucher.Images1"), System.Drawing.Image))
        Me.tblgeneravoucher.Images.Add(CType(resources.GetObject("tblgeneravoucher.Images2"), System.Drawing.Image))
        Me.tblgeneravoucher.LinesPerRow = 1
        Me.tblgeneravoucher.Location = New System.Drawing.Point(0, 282)
        Me.tblgeneravoucher.Name = "tblgeneravoucher"
        Me.tblgeneravoucher.PictureCurrentRow = CType(resources.GetObject("tblgeneravoucher.PictureCurrentRow"), System.Drawing.Image)
        Me.tblgeneravoucher.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblgeneravoucher.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblgeneravoucher.PreviewInfo.ZoomFactor = 75
        Me.tblgeneravoucher.PrintInfo.PageSettings = CType(resources.GetObject("tblgeneravoucher.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblgeneravoucher.Size = New System.Drawing.Size(912, 146)
        Me.tblgeneravoucher.TabIndex = 158
        Me.tblgeneravoucher.TabStop = False
        Me.tblgeneravoucher.Text = "C1TrueDBGrid1"
        Me.tblgeneravoucher.UseColumnStyles = False
        Me.tblgeneravoucher.PropBag = resources.GetString("tblgeneravoucher.PropBag")
        '
        'Btngenerarvoucher
        '
        Me.Btngenerarvoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btngenerarvoucher.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.Btngenerarvoucher.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btngenerarvoucher.Location = New System.Drawing.Point(0, 206)
        Me.Btngenerarvoucher.Name = "Btngenerarvoucher"
        Me.Btngenerarvoucher.Size = New System.Drawing.Size(204, 22)
        Me.Btngenerarvoucher.TabIndex = 159
        Me.Btngenerarvoucher.Text = "Paso 2 :  Generar Voucher"
        Me.Btngenerarvoucher.UseVisualStyleBackColor = True
        '
        'btngrabavoucher
        '
        Me.btngrabavoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngrabavoucher.Image = Global.ContabilidadNet.My.Resources.Resources.Verificarcuentas
        Me.btngrabavoucher.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btngrabavoucher.Location = New System.Drawing.Point(0, 440)
        Me.btngrabavoucher.Name = "btngrabavoucher"
        Me.btngrabavoucher.Size = New System.Drawing.Size(252, 24)
        Me.btngrabavoucher.TabIndex = 160
        Me.btngrabavoucher.Text = "Paso 4 : Grabar Voucher generado"
        Me.btngrabavoucher.UseVisualStyleBackColor = True
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(78, 232)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 204
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(171, 258)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(228, 18)
        Me.lblhelp_1.TabIndex = 203
        Me.lblhelp_1.Text = "???"
        '
        'txtCuentaprov
        '
        Me.txtCuentaprov.Location = New System.Drawing.Point(49, 256)
        Me.txtCuentaprov.Name = "txtCuentaprov"
        Me.txtCuentaprov.NroDecimales = CType(0, Short)
        Me.txtCuentaprov.SelectGotFocus = True
        Me.txtCuentaprov.Size = New System.Drawing.Size(100, 20)
        Me.txtCuentaprov.TabIndex = 201
        Me.txtCuentaprov.Tabulado = True
        Me.txtCuentaprov.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 202
        Me.Label7.Text = "Cuenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 211
        Me.Label4.Text = "Libro"
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(150, 254)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 212
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(99, 236)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(112, 18)
        Me.lblhelp_0.TabIndex = 210
        Me.lblhelp_0.Text = "???"
        '
        'txtlibroproveedores
        '
        Me.txtlibroproveedores.Location = New System.Drawing.Point(49, 234)
        Me.txtlibroproveedores.Name = "txtlibroproveedores"
        Me.txtlibroproveedores.NroDecimales = CType(0, Short)
        Me.txtlibroproveedores.SelectGotFocus = True
        Me.txtlibroproveedores.Size = New System.Drawing.Size(28, 20)
        Me.txtlibroproveedores.TabIndex = 209
        Me.txtlibroproveedores.Tabulado = True
        Me.txtlibroproveedores.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(268, 242)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 218
        Me.Label9.Text = "Nro Voucher"
        '
        'txtNoVoucherprov
        '
        Me.txtNoVoucherprov.Location = New System.Drawing.Point(336, 237)
        Me.txtNoVoucherprov.MaxLength = 5
        Me.txtNoVoucherprov.Name = "txtNoVoucherprov"
        Me.txtNoVoucherprov.NroDecimales = CType(0, Short)
        Me.txtNoVoucherprov.SelectGotFocus = True
        Me.txtNoVoucherprov.Size = New System.Drawing.Size(62, 20)
        Me.txtNoVoucherprov.TabIndex = 221
        Me.txtNoVoucherprov.Tabulado = True
        Me.txtNoVoucherprov.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
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
        Me.tblhelp.Location = New System.Drawing.Point(594, 306)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(340, 140)
        Me.tblhelp.TabIndex = 223
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'grbdatosvouchercaja
        '
        Me.grbdatosvouchercaja.Controls.Add(Me.txtNoVouchercaja)
        Me.grbdatosvouchercaja.Controls.Add(Me.Label10)
        Me.grbdatosvouchercaja.Controls.Add(Me.Label6)
        Me.grbdatosvouchercaja.Controls.Add(Me.btnhelp_2)
        Me.grbdatosvouchercaja.Controls.Add(Me.lblhelp_2)
        Me.grbdatosvouchercaja.Controls.Add(Me.txtlibrocaja)
        Me.grbdatosvouchercaja.Controls.Add(Me.btnhelp_3)
        Me.grbdatosvouchercaja.Controls.Add(Me.lblhelp_3)
        Me.grbdatosvouchercaja.Controls.Add(Me.txtCuentacaja)
        Me.grbdatosvouchercaja.Controls.Add(Me.Label3)
        Me.grbdatosvouchercaja.Location = New System.Drawing.Point(501, 216)
        Me.grbdatosvouchercaja.Name = "grbdatosvouchercaja"
        Me.grbdatosvouchercaja.Size = New System.Drawing.Size(411, 60)
        Me.grbdatosvouchercaja.TabIndex = 224
        Me.grbdatosvouchercaja.TabStop = False
        Me.grbdatosvouchercaja.Text = "Oculto hasta nuevo aviso"
        Me.grbdatosvouchercaja.Visible = False
        '
        'txtNoVouchercaja
        '
        Me.txtNoVouchercaja.Location = New System.Drawing.Point(347, 14)
        Me.txtNoVouchercaja.MaxLength = 5
        Me.txtNoVouchercaja.Name = "txtNoVouchercaja"
        Me.txtNoVouchercaja.NroDecimales = CType(0, Short)
        Me.txtNoVouchercaja.SelectGotFocus = True
        Me.txtNoVouchercaja.Size = New System.Drawing.Size(62, 20)
        Me.txtNoVouchercaja.TabIndex = 232
        Me.txtNoVouchercaja.Tabulado = True
        Me.txtNoVouchercaja.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(279, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 231
        Me.Label10.Text = "Nro Voucher"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 229
        Me.Label6.Text = "Libro"
        '
        'btnhelp_2
        '
        Me.btnhelp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_2.Location = New System.Drawing.Point(87, 12)
        Me.btnhelp_2.Name = "btnhelp_2"
        Me.btnhelp_2.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_2.TabIndex = 230
        Me.btnhelp_2.Text = ":::"
        Me.btnhelp_2.UseVisualStyleBackColor = True
        '
        'lblhelp_2
        '
        Me.lblhelp_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_2.Location = New System.Drawing.Point(109, 14)
        Me.lblhelp_2.Name = "lblhelp_2"
        Me.lblhelp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_2.Size = New System.Drawing.Size(112, 18)
        Me.lblhelp_2.TabIndex = 228
        Me.lblhelp_2.Text = "???"
        '
        'txtlibrocaja
        '
        Me.txtlibrocaja.Location = New System.Drawing.Point(59, 12)
        Me.txtlibrocaja.Name = "txtlibrocaja"
        Me.txtlibrocaja.NroDecimales = CType(0, Short)
        Me.txtlibrocaja.SelectGotFocus = True
        Me.txtlibrocaja.Size = New System.Drawing.Size(28, 20)
        Me.txtlibrocaja.TabIndex = 227
        Me.txtlibrocaja.Tabulado = True
        Me.txtlibrocaja.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_3
        '
        Me.btnhelp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_3.Location = New System.Drawing.Point(159, 34)
        Me.btnhelp_3.Name = "btnhelp_3"
        Me.btnhelp_3.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_3.TabIndex = 226
        Me.btnhelp_3.Text = ":::"
        Me.btnhelp_3.UseVisualStyleBackColor = True
        '
        'lblhelp_3
        '
        Me.lblhelp_3.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_3.Location = New System.Drawing.Point(181, 36)
        Me.lblhelp_3.Name = "lblhelp_3"
        Me.lblhelp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_3.Size = New System.Drawing.Size(228, 18)
        Me.lblhelp_3.TabIndex = 225
        Me.lblhelp_3.Text = "???"
        '
        'txtCuentacaja
        '
        Me.txtCuentacaja.Location = New System.Drawing.Point(59, 34)
        Me.txtCuentacaja.Name = "txtCuentacaja"
        Me.txtCuentacaja.NroDecimales = CType(0, Short)
        Me.txtCuentacaja.SelectGotFocus = True
        Me.txtCuentacaja.Size = New System.Drawing.Size(100, 20)
        Me.txtCuentacaja.TabIndex = 223
        Me.txtCuentacaja.Tabulado = True
        Me.txtCuentacaja.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 224
        Me.Label3.Text = "Cuenta"
        '
        'grbvalidaciones
        '
        Me.grbvalidaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grbvalidaciones.Controls.Add(Me.btncancelar1)
        Me.grbvalidaciones.Controls.Add(Me.tblvalidacion)
        Me.grbvalidaciones.Location = New System.Drawing.Point(155, 94)
        Me.grbvalidaciones.Name = "grbvalidaciones"
        Me.grbvalidaciones.Size = New System.Drawing.Size(807, 197)
        Me.grbvalidaciones.TabIndex = 225
        Me.grbvalidaciones.TabStop = False
        Me.grbvalidaciones.Text = "Validaciones"
        '
        'btncancelar1
        '
        Me.btncancelar1.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar1.Location = New System.Drawing.Point(774, 5)
        Me.btncancelar1.Name = "btncancelar1"
        Me.btncancelar1.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar1.TabIndex = 158
        Me.btncancelar1.UseVisualStyleBackColor = True
        '
        'Frm_Voucher_ImportarCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 499)
        Me.Controls.Add(Me.grbvalidaciones)
        Me.Controls.Add(Me.grbdatosvouchercaja)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.txtNoVoucherprov)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txtlibroproveedores)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.txtCuentaprov)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btngrabavoucher)
        Me.Controls.Add(Me.btnvalidar)
        Me.Controls.Add(Me.Btngenerarvoucher)
        Me.Controls.Add(Me.tblgeneravoucher)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_Voucher_ImportarCajas"
        Me.Text = "Frm_Voucher_ImportarCajas"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblvalidacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblgeneravoucher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbdatosvouchercaja.ResumeLayout(False)
        Me.grbdatosvouchercaja.PerformLayout()
        Me.grbvalidaciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnvalidar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tblvalidacion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tblgeneravoucher As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Btngenerarvoucher As System.Windows.Forms.Button
    Friend WithEvents btngrabavoucher As System.Windows.Forms.Button
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaprov As Ks.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtlibroproveedores As Ks.UserControl.ksTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNoVoucherprov As Ks.UserControl.ksTextBox
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grbdatosvouchercaja As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoVouchercaja As KS.UserControl.ksTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_2 As System.Windows.Forms.Button
    Public WithEvents lblhelp_2 As System.Windows.Forms.Label
    Friend WithEvents txtlibrocaja As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_3 As System.Windows.Forms.Button
    Public WithEvents lblhelp_3 As System.Windows.Forms.Label
    Friend WithEvents txtCuentacaja As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grbvalidaciones As System.Windows.Forms.GroupBox
    Friend WithEvents btncancelar1 As System.Windows.Forms.Button
End Class
