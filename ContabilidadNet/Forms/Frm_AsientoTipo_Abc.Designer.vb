<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AsientoTipo_Abc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AsientoTipo_Abc))
        Me.lnkeliminar = New System.Windows.Forms.LinkLabel()
        Me.lnkmodificar = New System.Windows.Forms.LinkLabel()
        Me.lnkNuevo = New System.Windows.Forms.LinkLabel()
        Me.lnkinsertar = New System.Windows.Forms.LinkLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GbxDetalle = New System.Windows.Forms.GroupBox()
        Me.cbocolumna = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtformula = New Ks.UserControl.ksTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbocargoabono = New System.Windows.Forms.ComboBox()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcuenta = New Ks.UserControl.ksTextBox()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.lnkgrabar = New System.Windows.Forms.LinkLabel()
        Me.lnkcancelar = New System.Windows.Forms.LinkLabel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnultimo = New System.Windows.Forms.Button()
        Me.btnsiguiente = New System.Windows.Forms.Button()
        Me.btnanterior = New System.Windows.Forms.Button()
        Me.btnprimero = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtDescri = New Ks.UserControl.ksTextBox()
        Me.txtCodigo = New Ks.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtlibro = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GbxDetalle.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkeliminar
        '
        Me.lnkeliminar.AutoSize = True
        Me.lnkeliminar.Location = New System.Drawing.Point(104, 24)
        Me.lnkeliminar.Name = "lnkeliminar"
        Me.lnkeliminar.Size = New System.Drawing.Size(43, 13)
        Me.lnkeliminar.TabIndex = 203
        Me.lnkeliminar.TabStop = True
        Me.lnkeliminar.Text = "Eliminar"
        '
        'lnkmodificar
        '
        Me.lnkmodificar.AutoSize = True
        Me.lnkmodificar.Location = New System.Drawing.Point(52, 24)
        Me.lnkmodificar.Name = "lnkmodificar"
        Me.lnkmodificar.Size = New System.Drawing.Size(50, 13)
        Me.lnkmodificar.TabIndex = 202
        Me.lnkmodificar.TabStop = True
        Me.lnkmodificar.Text = "Modificar"
        '
        'lnkNuevo
        '
        Me.lnkNuevo.AutoSize = True
        Me.lnkNuevo.Location = New System.Drawing.Point(7, 24)
        Me.lnkNuevo.Name = "lnkNuevo"
        Me.lnkNuevo.Size = New System.Drawing.Size(44, 13)
        Me.lnkNuevo.TabIndex = 193
        Me.lnkNuevo.TabStop = True
        Me.lnkNuevo.Text = "Agregar"
        '
        'lnkinsertar
        '
        Me.lnkinsertar.AutoSize = True
        Me.lnkinsertar.Location = New System.Drawing.Point(148, 24)
        Me.lnkinsertar.Name = "lnkinsertar"
        Me.lnkinsertar.Size = New System.Drawing.Size(42, 13)
        Me.lnkinsertar.TabIndex = 204
        Me.lnkinsertar.TabStop = True
        Me.lnkinsertar.Text = "Insertar"
        '
        'GroupBox4
        '
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(162, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(206, 16)
        Me.GroupBox4.TabIndex = 205
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DETALLES DE ASIENTO TIPO"
        '
        'GbxDetalle
        '
        Me.GbxDetalle.Controls.Add(Me.cbocolumna)
        Me.GbxDetalle.Controls.Add(Me.Label10)
        Me.GbxDetalle.Controls.Add(Me.txtformula)
        Me.GbxDetalle.Controls.Add(Me.Label9)
        Me.GbxDetalle.Controls.Add(Me.Label8)
        Me.GbxDetalle.Controls.Add(Me.cbocargoabono)
        Me.GbxDetalle.Controls.Add(Me.btnhelp_1)
        Me.GbxDetalle.Controls.Add(Me.Label4)
        Me.GbxDetalle.Controls.Add(Me.txtcuenta)
        Me.GbxDetalle.Controls.Add(Me.lblhelp_1)
        Me.GbxDetalle.Controls.Add(Me.lnkgrabar)
        Me.GbxDetalle.Controls.Add(Me.lnkcancelar)
        Me.GbxDetalle.Controls.Add(Me.GroupBox4)
        Me.GbxDetalle.Controls.Add(Me.lnkinsertar)
        Me.GbxDetalle.Controls.Add(Me.lnkNuevo)
        Me.GbxDetalle.Controls.Add(Me.lnkmodificar)
        Me.GbxDetalle.Controls.Add(Me.lnkeliminar)
        Me.GbxDetalle.Location = New System.Drawing.Point(22, 100)
        Me.GbxDetalle.Name = "GbxDetalle"
        Me.GbxDetalle.Size = New System.Drawing.Size(558, 90)
        Me.GbxDetalle.TabIndex = 207
        Me.GbxDetalle.TabStop = False
        '
        'cbocolumna
        '
        Me.cbocolumna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocolumna.FormattingEnabled = True
        Me.cbocolumna.Items.AddRange(New Object() {"", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cbocolumna.Location = New System.Drawing.Point(179, 65)
        Me.cbocolumna.Name = "cbocolumna"
        Me.cbocolumna.Size = New System.Drawing.Size(42, 21)
        Me.cbocolumna.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(129, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 278
        Me.Label10.Text = "Columna"
        '
        'txtformula
        '
        Me.txtformula.Location = New System.Drawing.Point(269, 65)
        Me.txtformula.MaxLength = 80
        Me.txtformula.Name = "txtformula"
        Me.txtformula.NroDecimales = CType(0, Short)
        Me.txtformula.SelectGotFocus = True
        Me.txtformula.Size = New System.Drawing.Size(283, 20)
        Me.txtformula.TabIndex = 3
        Me.txtformula.Tabulado = True
        Me.txtformula.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(223, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 276
        Me.Label9.Text = "Formula"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "Cargo/Abono"
        '
        'cbocargoabono
        '
        Me.cbocargoabono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocargoabono.FormattingEnabled = True
        Me.cbocargoabono.Items.AddRange(New Object() {"C", "A"})
        Me.cbocargoabono.Location = New System.Drawing.Point(81, 65)
        Me.cbocargoabono.Name = "cbocargoabono"
        Me.cbocargoabono.Size = New System.Drawing.Size(42, 21)
        Me.cbocargoabono.TabIndex = 1
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(221, 43)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 273
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 272
        Me.Label4.Text = "Cuenta"
        '
        'txtcuenta
        '
        Me.txtcuenta.Location = New System.Drawing.Point(81, 43)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.NroDecimales = CType(0, Short)
        Me.txtcuenta.SelectGotFocus = True
        Me.txtcuenta.Size = New System.Drawing.Size(140, 20)
        Me.txtcuenta.TabIndex = 0
        Me.txtcuenta.Tabulado = True
        Me.txtcuenta.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(243, 45)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(309, 18)
        Me.lblhelp_1.TabIndex = 271
        Me.lblhelp_1.Text = "???"
        '
        'lnkgrabar
        '
        Me.lnkgrabar.AutoSize = True
        Me.lnkgrabar.Location = New System.Drawing.Point(202, 24)
        Me.lnkgrabar.Name = "lnkgrabar"
        Me.lnkgrabar.Size = New System.Drawing.Size(39, 13)
        Me.lnkgrabar.TabIndex = 4
        Me.lnkgrabar.TabStop = True
        Me.lnkgrabar.Text = "Grabar"
        '
        'lnkcancelar
        '
        Me.lnkcancelar.AutoSize = True
        Me.lnkcancelar.Location = New System.Drawing.Point(242, 24)
        Me.lnkcancelar.Name = "lnkcancelar"
        Me.lnkcancelar.Size = New System.Drawing.Size(49, 13)
        Me.lnkcancelar.TabIndex = 253
        Me.lnkcancelar.TabStop = True
        Me.lnkcancelar.Text = "Cancelar"
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 324)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(598, 31)
        Me.Panel3.TabIndex = 193
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 29)
        Me.Panel1.TabIndex = 192
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(86, 0)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(64, 0)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 0
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(564, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(42, 0)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 2
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(22, 0)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 3
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(0, 0)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 4
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(408, 36)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(170, 18)
        Me.lblhelp_0.TabIndex = 197
        Me.lblhelp_0.Text = "???"
        '
        'txtDescri
        '
        Me.txtDescri.Location = New System.Drawing.Point(76, 36)
        Me.txtDescri.MaxLength = 80
        Me.txtDescri.Name = "txtDescri"
        Me.txtDescri.NroDecimales = CType(0, Short)
        Me.txtDescri.SelectGotFocus = True
        Me.txtDescri.Size = New System.Drawing.Size(274, 20)
        Me.txtDescri.TabIndex = 1
        Me.txtDescri.Tabulado = True
        Me.txtDescri.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(12, 36)
        Me.txtCodigo.MaxLength = 5
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.NroDecimales = CType(0, Short)
        Me.txtCodigo.SelectGotFocus = True
        Me.txtCodigo.Size = New System.Drawing.Size(62, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Tabulado = True
        Me.txtCodigo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Codigo"
        '
        'txtlibro
        '
        Me.txtlibro.Location = New System.Drawing.Point(356, 36)
        Me.txtlibro.Name = "txtlibro"
        Me.txtlibro.NroDecimales = CType(0, Short)
        Me.txtlibro.SelectGotFocus = True
        Me.txtlibro.Size = New System.Drawing.Size(28, 20)
        Me.txtlibro.TabIndex = 2
        Me.txtlibro.Tabulado = True
        Me.txtlibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(78, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "Libro"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(386, 34)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 201
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnhelp_0)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtlibro)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.txtDescri)
        Me.GroupBox1.Controls.Add(Me.lblhelp_0)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 60)
        Me.GroupBox1.TabIndex = 201
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Cabecera"
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
        Me.tblhelp.Location = New System.Drawing.Point(506, 192)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(362, 138)
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
        Me.tblconsulta.Location = New System.Drawing.Point(22, 194)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(556, 120)
        Me.tblconsulta.TabIndex = 208
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Frm_AsientoTipo_Abc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 355)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.GbxDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_AsientoTipo_Abc"
        Me.Text = "Frm_AsientoTipo_Abc"
        Me.GbxDetalle.ResumeLayout(False)
        Me.GbxDetalle.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lnkeliminar As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkmodificar As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNuevo As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkinsertar As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnultimo As System.Windows.Forms.Button
    Friend WithEvents btnsiguiente As System.Windows.Forms.Button
    Friend WithEvents btnanterior As System.Windows.Forms.Button
    Friend WithEvents btnprimero As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtDescri As KS.UserControl.ksTextBox
    Friend WithEvents txtCodigo As KS.UserControl.ksTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtlibro As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbocolumna As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtformula As KS.UserControl.ksTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbocargoabono As System.Windows.Forms.ComboBox
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As KS.UserControl.ksTextBox
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents lnkgrabar As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkcancelar As System.Windows.Forms.LinkLabel
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
