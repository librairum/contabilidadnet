<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Previsualizar_SireCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Previsualizar_SireCompras))
        Me.txtlibro = New Ks.UserControl.ksTextBox()
        Me.txtNoVoucher = New Ks.UserControl.ksTextBox()
        Me.txtDescri = New Ks.UserControl.ksTextBox()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnultimo = New System.Windows.Forms.Button()
        Me.btnsiguiente = New System.Windows.Forms.Button()
        Me.btnanterior = New System.Windows.Forms.Button()
        Me.btnprimero = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnreferencias = New System.Windows.Forms.Button()
        Me.btnpagoplanillas = New System.Windows.Forms.Button()
        Me.btnDetraccion = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.mskfecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalDebeSoles = New Ks.UserControl.ksTextBox()
        Me.txtTotalHaberSoles = New Ks.UserControl.ksTextBox()
        Me.txtSaldoSoles = New Ks.UserControl.ksTextBox()
        Me.txtSaldoDolares = New Ks.UserControl.ksTextBox()
        Me.txtTotalHaberDolares = New Ks.UserControl.ksTextBox()
        Me.txtTotalDebeDolares = New Ks.UserControl.ksTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbltotalregistros = New System.Windows.Forms.Label()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtlibro
        '
        Me.txtlibro.Location = New System.Drawing.Point(44, 32)
        Me.txtlibro.Name = "txtlibro"
        Me.txtlibro.NroDecimales = CType(0, Short)
        Me.txtlibro.SelectGotFocus = True
        Me.txtlibro.Size = New System.Drawing.Size(28, 20)
        Me.txtlibro.TabIndex = 10
        Me.txtlibro.Tabulado = True
        Me.txtlibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtNoVoucher
        '
        Me.txtNoVoucher.Location = New System.Drawing.Point(254, 32)
        Me.txtNoVoucher.MaxLength = 5
        Me.txtNoVoucher.Name = "txtNoVoucher"
        Me.txtNoVoucher.NroDecimales = CType(0, Short)
        Me.txtNoVoucher.SelectGotFocus = True
        Me.txtNoVoucher.Size = New System.Drawing.Size(62, 20)
        Me.txtNoVoucher.TabIndex = 11
        Me.txtNoVoucher.Tabulado = True
        Me.txtNoVoucher.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtDescri
        '
        Me.txtDescri.Location = New System.Drawing.Point(72, 54)
        Me.txtDescri.MaxLength = 80
        Me.txtDescri.Name = "txtDescri"
        Me.txtDescri.NroDecimales = CType(0, Short)
        Me.txtDescri.SelectGotFocus = True
        Me.txtDescri.Size = New System.Drawing.Size(652, 20)
        Me.txtDescri.TabIndex = 13
        Me.txtDescri.Tabulado = True
        Me.txtDescri.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(72, 32)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 200
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(94, 34)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(112, 18)
        Me.lblhelp_0.TabIndex = 175
        Me.lblhelp_0.Text = "???"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "Libro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "Numero"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Descripcion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "Fecha"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 341)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(732, 31)
        Me.Panel3.TabIndex = 189
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.btnultimo)
        Me.Panel8.Controls.Add(Me.btnsiguiente)
        Me.Panel8.Controls.Add(Me.btnanterior)
        Me.Panel8.Controls.Add(Me.btnprimero)
        Me.Panel8.Location = New System.Drawing.Point(238, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(184, 30)
        Me.Panel8.TabIndex = 1
        '
        'btnultimo
        '
        Me.btnultimo.Location = New System.Drawing.Point(118, 2)
        Me.btnultimo.Name = "btnultimo"
        Me.btnultimo.Size = New System.Drawing.Size(30, 24)
        Me.btnultimo.TabIndex = 3
        Me.btnultimo.Text = ">>"
        Me.btnultimo.UseVisualStyleBackColor = True
        '
        'btnsiguiente
        '
        Me.btnsiguiente.Location = New System.Drawing.Point(88, 2)
        Me.btnsiguiente.Name = "btnsiguiente"
        Me.btnsiguiente.Size = New System.Drawing.Size(30, 24)
        Me.btnsiguiente.TabIndex = 2
        Me.btnsiguiente.Text = ">"
        Me.btnsiguiente.UseVisualStyleBackColor = True
        '
        'btnanterior
        '
        Me.btnanterior.Location = New System.Drawing.Point(58, 2)
        Me.btnanterior.Name = "btnanterior"
        Me.btnanterior.Size = New System.Drawing.Size(30, 24)
        Me.btnanterior.TabIndex = 1
        Me.btnanterior.Text = "<"
        Me.btnanterior.UseVisualStyleBackColor = True
        '
        'btnprimero
        '
        Me.btnprimero.Location = New System.Drawing.Point(30, 2)
        Me.btnprimero.Name = "btnprimero"
        Me.btnprimero.Size = New System.Drawing.Size(30, 24)
        Me.btnprimero.TabIndex = 0
        Me.btnprimero.Text = "<<"
        Me.btnprimero.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnreferencias)
        Me.Panel1.Controls.Add(Me.btnpagoplanillas)
        Me.Panel1.Controls.Add(Me.btnDetraccion)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(732, 31)
        Me.Panel1.TabIndex = 191
        '
        'btnreferencias
        '
        Me.btnreferencias.Image = Global.ContabilidadNet.My.Resources.Resources.referencias
        Me.btnreferencias.Location = New System.Drawing.Point(320, 2)
        Me.btnreferencias.Name = "btnreferencias"
        Me.btnreferencias.Size = New System.Drawing.Size(24, 24)
        Me.btnreferencias.TabIndex = 55
        Me.btnreferencias.UseVisualStyleBackColor = True
        '
        'btnpagoplanillas
        '
        Me.btnpagoplanillas.Image = Global.ContabilidadNet.My.Resources.Resources.user
        Me.btnpagoplanillas.Location = New System.Drawing.Point(530, 2)
        Me.btnpagoplanillas.Name = "btnpagoplanillas"
        Me.btnpagoplanillas.Size = New System.Drawing.Size(24, 24)
        Me.btnpagoplanillas.TabIndex = 54
        Me.btnpagoplanillas.UseVisualStyleBackColor = True
        '
        'btnDetraccion
        '
        Me.btnDetraccion.Image = Global.ContabilidadNet.My.Resources.Resources.registrar
        Me.btnDetraccion.Location = New System.Drawing.Point(296, 2)
        Me.btnDetraccion.Name = "btnDetraccion"
        Me.btnDetraccion.Size = New System.Drawing.Size(24, 24)
        Me.btnDetraccion.TabIndex = 53
        Me.btnDetraccion.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(88, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 15
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(66, 2)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 14
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(692, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(45, 2)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 52
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(25, 2)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 51
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(3, 2)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 50
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'mskfecha
        '
        Me.mskfecha.Location = New System.Drawing.Point(360, 32)
        Me.mskfecha.Mask = "00/00/0000"
        Me.mskfecha.Name = "mskfecha"
        Me.mskfecha.Size = New System.Drawing.Size(68, 20)
        Me.mskfecha.TabIndex = 12
        Me.mskfecha.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(352, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 194
        Me.Label5.Text = "Total Soles"
        '
        'txtTotalDebeSoles
        '
        Me.txtTotalDebeSoles.Location = New System.Drawing.Point(424, 298)
        Me.txtTotalDebeSoles.Name = "txtTotalDebeSoles"
        Me.txtTotalDebeSoles.NroDecimales = CType(2, Short)
        Me.txtTotalDebeSoles.SelectGotFocus = True
        Me.txtTotalDebeSoles.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDebeSoles.TabIndex = 195
        Me.txtTotalDebeSoles.TabStop = False
        Me.txtTotalDebeSoles.Tabulado = False
        Me.txtTotalDebeSoles.Text = "0.00"
        Me.txtTotalDebeSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDebeSoles.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtTotalHaberSoles
        '
        Me.txtTotalHaberSoles.Location = New System.Drawing.Point(524, 298)
        Me.txtTotalHaberSoles.Name = "txtTotalHaberSoles"
        Me.txtTotalHaberSoles.NroDecimales = CType(2, Short)
        Me.txtTotalHaberSoles.SelectGotFocus = True
        Me.txtTotalHaberSoles.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalHaberSoles.TabIndex = 196
        Me.txtTotalHaberSoles.TabStop = False
        Me.txtTotalHaberSoles.Tabulado = False
        Me.txtTotalHaberSoles.Text = "0.00"
        Me.txtTotalHaberSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalHaberSoles.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtSaldoSoles
        '
        Me.txtSaldoSoles.Location = New System.Drawing.Point(624, 298)
        Me.txtSaldoSoles.Name = "txtSaldoSoles"
        Me.txtSaldoSoles.NroDecimales = CType(2, Short)
        Me.txtSaldoSoles.SelectGotFocus = True
        Me.txtSaldoSoles.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoSoles.TabIndex = 197
        Me.txtSaldoSoles.TabStop = False
        Me.txtSaldoSoles.Tabulado = False
        Me.txtSaldoSoles.Text = "0.00"
        Me.txtSaldoSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoSoles.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtSaldoDolares
        '
        Me.txtSaldoDolares.ForeColor = System.Drawing.Color.Green
        Me.txtSaldoDolares.Location = New System.Drawing.Point(624, 318)
        Me.txtSaldoDolares.Name = "txtSaldoDolares"
        Me.txtSaldoDolares.NroDecimales = CType(2, Short)
        Me.txtSaldoDolares.SelectGotFocus = True
        Me.txtSaldoDolares.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoDolares.TabIndex = 200
        Me.txtSaldoDolares.TabStop = False
        Me.txtSaldoDolares.Tabulado = False
        Me.txtSaldoDolares.Text = "0.00"
        Me.txtSaldoDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoDolares.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtTotalHaberDolares
        '
        Me.txtTotalHaberDolares.ForeColor = System.Drawing.Color.Green
        Me.txtTotalHaberDolares.Location = New System.Drawing.Point(524, 318)
        Me.txtTotalHaberDolares.Name = "txtTotalHaberDolares"
        Me.txtTotalHaberDolares.NroDecimales = CType(2, Short)
        Me.txtTotalHaberDolares.SelectGotFocus = True
        Me.txtTotalHaberDolares.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalHaberDolares.TabIndex = 199
        Me.txtTotalHaberDolares.TabStop = False
        Me.txtTotalHaberDolares.Tabulado = False
        Me.txtTotalHaberDolares.Text = "0.00"
        Me.txtTotalHaberDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalHaberDolares.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtTotalDebeDolares
        '
        Me.txtTotalDebeDolares.ForeColor = System.Drawing.Color.Green
        Me.txtTotalDebeDolares.Location = New System.Drawing.Point(424, 318)
        Me.txtTotalDebeDolares.Name = "txtTotalDebeDolares"
        Me.txtTotalDebeDolares.NroDecimales = CType(2, Short)
        Me.txtTotalDebeDolares.SelectGotFocus = True
        Me.txtTotalDebeDolares.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDebeDolares.TabIndex = 198
        Me.txtTotalDebeDolares.TabStop = False
        Me.txtTotalDebeDolares.Tabulado = False
        Me.txtTotalDebeDolares.Text = "0.00"
        Me.txtTotalDebeDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDebeDolares.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(340, 322)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 201
        Me.Label6.Text = "Total Dolares"
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(283, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 16)
        Me.GroupBox1.TabIndex = 205
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DETALLES DE SIRE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(722, 36)
        Me.GroupBox2.TabIndex = 206
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 207
        Me.Label7.Text = "Total de registros"
        '
        'lbltotalregistros
        '
        Me.lbltotalregistros.AutoSize = True
        Me.lbltotalregistros.Location = New System.Drawing.Point(120, 304)
        Me.lbltotalregistros.Name = "lbltotalregistros"
        Me.lbltotalregistros.Size = New System.Drawing.Size(13, 13)
        Me.lbltotalregistros.TabIndex = 208
        Me.lbltotalregistros.Text = "0"
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
        Me.tblconsulta.Location = New System.Drawing.Point(2, 118)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(722, 178)
        Me.tblconsulta.TabIndex = 190
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Frm_Previsualizar_SireCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 372)
        Me.Controls.Add(Me.lbltotalregistros)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSaldoDolares)
        Me.Controls.Add(Me.txtTotalHaberDolares)
        Me.Controls.Add(Me.txtTotalDebeDolares)
        Me.Controls.Add(Me.txtSaldoSoles)
        Me.Controls.Add(Me.txtTotalHaberSoles)
        Me.Controls.Add(Me.txtTotalDebeSoles)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.mskfecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txtDescri)
        Me.Controls.Add(Me.txtNoVoucher)
        Me.Controls.Add(Me.txtlibro)
        Me.Name = "Frm_Previsualizar_SireCompras"
        Me.Text = "Frm_Voucher_Abc"
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtlibro As KS.UserControl.ksTextBox
    Friend WithEvents txtNoVoucher As KS.UserControl.ksTextBox
    Friend WithEvents txtDescri As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnultimo As System.Windows.Forms.Button
    Friend WithEvents btnsiguiente As System.Windows.Forms.Button
    Friend WithEvents btnanterior As System.Windows.Forms.Button
    Friend WithEvents btnprimero As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents mskfecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDebeSoles As KS.UserControl.ksTextBox
    Friend WithEvents txtTotalHaberSoles As KS.UserControl.ksTextBox
    Friend WithEvents txtSaldoSoles As KS.UserControl.ksTextBox
    Friend WithEvents txtSaldoDolares As KS.UserControl.ksTextBox
    Friend WithEvents txtTotalHaberDolares As KS.UserControl.ksTextBox
    Friend WithEvents txtTotalDebeDolares As KS.UserControl.ksTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDetraccion As System.Windows.Forms.Button
    Friend WithEvents btnpagoplanillas As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbltotalregistros As System.Windows.Forms.Label
    Friend WithEvents btnreferencias As System.Windows.Forms.Button
End Class
