<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Empresa_Abc
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnultimo = New System.Windows.Forms.Button()
        Me.btnsiguiente = New System.Windows.Forms.Button()
        Me.btnanterior = New System.Windows.Forms.Button()
        Me.btnprimero = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtFecha_1 = New System.Windows.Forms.RadioButton()
        Me.rbtFecha_0 = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbtTCUsar_0 = New System.Windows.Forms.RadioButton()
        Me.rbtTCUsar_1 = New System.Windows.Forms.RadioButton()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.txtCodigo = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New Ks.UserControl.ksTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkTipoAgente = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDireccion = New Ks.UserControl.ksTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTasaRetencion = New Ks.UserControl.ksTextBox()
        Me.txtMontoRetencion = New Ks.UserControl.ksTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRepresentante = New Ks.UserControl.ksTextBox()
        Me.txtCargo = New Ks.UserControl.ksTextBox()
        Me.txtContador = New Ks.UserControl.ksTextBox()
        Me.txtMatricula = New Ks.UserControl.ksTextBox()
        Me.txtperiodo = New Ks.UserControl.ksTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkBiMoneda = New System.Windows.Forms.CheckBox()
        Me.chkModifTC = New System.Windows.Forms.CheckBox()
        Me.txtruc = New Ks.UserControl.ksTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 213)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(651, 31)
        Me.Panel3.TabIndex = 229
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
        Me.btnultimo.Location = New System.Drawing.Point(116, 2)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtFecha_1)
        Me.GroupBox2.Controls.Add(Me.rbtFecha_0)
        Me.GroupBox2.Location = New System.Drawing.Point(300, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(150, 40)
        Me.GroupBox2.TabIndex = 228
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha de provisiones"
        '
        'rbtFecha_1
        '
        Me.rbtFecha_1.AutoSize = True
        Me.rbtFecha_1.Location = New System.Drawing.Point(72, 18)
        Me.rbtFecha_1.Name = "rbtFecha_1"
        Me.rbtFecha_1.Size = New System.Drawing.Size(80, 17)
        Me.rbtFecha_1.TabIndex = 17
        Me.rbtFecha_1.TabStop = True
        Me.rbtFecha_1.Text = "Documento"
        Me.rbtFecha_1.UseVisualStyleBackColor = True
        '
        'rbtFecha_0
        '
        Me.rbtFecha_0.AutoSize = True
        Me.rbtFecha_0.Location = New System.Drawing.Point(10, 18)
        Me.rbtFecha_0.Name = "rbtFecha_0"
        Me.rbtFecha_0.Size = New System.Drawing.Size(65, 17)
        Me.rbtFecha_0.TabIndex = 15
        Me.rbtFecha_0.TabStop = True
        Me.rbtFecha_0.Text = "Voucher"
        Me.rbtFecha_0.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(47, 130)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(35, 13)
        Me.Label22.TabIndex = 216
        Me.Label22.Text = "Cargo"
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(94, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 20
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(72, 2)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 17
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(48, 2)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 14
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbtTCUsar_0)
        Me.GroupBox4.Controls.Add(Me.rbtTCUsar_1)
        Me.GroupBox4.Location = New System.Drawing.Point(300, 106)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(150, 40)
        Me.GroupBox4.TabIndex = 227
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Cambio a Usar"
        '
        'rbtTCUsar_0
        '
        Me.rbtTCUsar_0.AutoSize = True
        Me.rbtTCUsar_0.Location = New System.Drawing.Point(8, 18)
        Me.rbtTCUsar_0.Name = "rbtTCUsar_0"
        Me.rbtTCUsar_0.Size = New System.Drawing.Size(67, 17)
        Me.rbtTCUsar_0.TabIndex = 22
        Me.rbtTCUsar_0.TabStop = True
        Me.rbtTCUsar_0.Text = "Bancario"
        Me.rbtTCUsar_0.UseVisualStyleBackColor = True
        '
        'rbtTCUsar_1
        '
        Me.rbtTCUsar_1.AutoSize = True
        Me.rbtTCUsar_1.Location = New System.Drawing.Point(88, 18)
        Me.rbtTCUsar_1.Name = "rbtTCUsar_1"
        Me.rbtTCUsar_1.Size = New System.Drawing.Size(52, 17)
        Me.rbtTCUsar_1.TabIndex = 19
        Me.rbtTCUsar_1.TabStop = True
        Me.rbtTCUsar_1.Text = "SAFP"
        Me.rbtTCUsar_1.UseVisualStyleBackColor = True
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 31)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 213)
        Me.Splitter1.TabIndex = 222
        Me.Splitter1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "Codigo"
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(6, 2)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 12
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(608, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 197
        Me.Label5.Text = "Direccion"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(38, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 210
        Me.Label10.Text = "Nombre"
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(28, 2)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 13
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(84, 32)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.NroDecimales = CType(0, Short)
        Me.txtCodigo.SelectGotFocus = True
        Me.txtCodigo.Size = New System.Drawing.Size(28, 20)
        Me.txtCodigo.TabIndex = 198
        Me.txtCodigo.Tabulado = True
        Me.txtCodigo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 196
        Me.Label3.Text = "Representante"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Location = New System.Drawing.Point(84, 52)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.NroDecimales = CType(0, Short)
        Me.txtNombre.SelectGotFocus = True
        Me.txtNombre.Size = New System.Drawing.Size(550, 20)
        Me.txtNombre.TabIndex = 199
        Me.txtNombre.Tabulado = True
        Me.txtNombre.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
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
        Me.Panel1.Size = New System.Drawing.Size(654, 31)
        Me.Panel1.TabIndex = 208
        '
        'chkTipoAgente
        '
        Me.chkTipoAgente.AutoSize = True
        Me.chkTipoAgente.Location = New System.Drawing.Point(4, 20)
        Me.chkTipoAgente.Name = "chkTipoAgente"
        Me.chkTipoAgente.Size = New System.Drawing.Size(186, 17)
        Me.chkTipoAgente.TabIndex = 221
        Me.chkTipoAgente.Text = "La Empresa es Agente Retenedor"
        Me.chkTipoAgente.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "CPC Nº"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 234
        Me.Label4.Text = "Contador"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.White
        Me.txtDireccion.Location = New System.Drawing.Point(84, 72)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.NroDecimales = CType(0, Short)
        Me.txtDireccion.SelectGotFocus = True
        Me.txtDireccion.Size = New System.Drawing.Size(550, 20)
        Me.txtDireccion.TabIndex = 235
        Me.txtDireccion.Tabulado = True
        Me.txtDireccion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTasaRetencion)
        Me.GroupBox3.Controls.Add(Me.txtMontoRetencion)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.chkTipoAgente)
        Me.GroupBox3.Location = New System.Drawing.Point(456, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(196, 84)
        Me.GroupBox3.TabIndex = 236
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Agente Retenedor"
        '
        'txtTasaRetencion
        '
        Me.txtTasaRetencion.BackColor = System.Drawing.Color.White
        Me.txtTasaRetencion.Location = New System.Drawing.Point(122, 62)
        Me.txtTasaRetencion.Name = "txtTasaRetencion"
        Me.txtTasaRetencion.NroDecimales = CType(0, Short)
        Me.txtTasaRetencion.SelectGotFocus = True
        Me.txtTasaRetencion.Size = New System.Drawing.Size(66, 20)
        Me.txtTasaRetencion.TabIndex = 238
        Me.txtTasaRetencion.Tabulado = True
        Me.txtTasaRetencion.Text = "0"
        Me.txtTasaRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTasaRetencion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'txtMontoRetencion
        '
        Me.txtMontoRetencion.BackColor = System.Drawing.Color.White
        Me.txtMontoRetencion.Location = New System.Drawing.Point(122, 40)
        Me.txtMontoRetencion.Name = "txtMontoRetencion"
        Me.txtMontoRetencion.NroDecimales = CType(2, Short)
        Me.txtMontoRetencion.SelectGotFocus = True
        Me.txtMontoRetencion.Size = New System.Drawing.Size(66, 20)
        Me.txtMontoRetencion.TabIndex = 237
        Me.txtMontoRetencion.Tabulado = True
        Me.txtMontoRetencion.Text = "0.00"
        Me.txtMontoRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMontoRetencion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 236
        Me.Label7.Text = "% Tasa Retencion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 235
        Me.Label6.Text = "Monto de Retencion"
        '
        'txtRepresentante
        '
        Me.txtRepresentante.BackColor = System.Drawing.Color.White
        Me.txtRepresentante.Location = New System.Drawing.Point(84, 106)
        Me.txtRepresentante.Name = "txtRepresentante"
        Me.txtRepresentante.NroDecimales = CType(0, Short)
        Me.txtRepresentante.SelectGotFocus = True
        Me.txtRepresentante.Size = New System.Drawing.Size(208, 20)
        Me.txtRepresentante.TabIndex = 239
        Me.txtRepresentante.Tabulado = True
        Me.txtRepresentante.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtCargo
        '
        Me.txtCargo.BackColor = System.Drawing.Color.White
        Me.txtCargo.Location = New System.Drawing.Point(84, 128)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.NroDecimales = CType(0, Short)
        Me.txtCargo.SelectGotFocus = True
        Me.txtCargo.Size = New System.Drawing.Size(208, 20)
        Me.txtCargo.TabIndex = 240
        Me.txtCargo.Tabulado = True
        Me.txtCargo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtContador
        '
        Me.txtContador.BackColor = System.Drawing.Color.White
        Me.txtContador.Location = New System.Drawing.Point(84, 150)
        Me.txtContador.Name = "txtContador"
        Me.txtContador.NroDecimales = CType(0, Short)
        Me.txtContador.SelectGotFocus = True
        Me.txtContador.Size = New System.Drawing.Size(208, 20)
        Me.txtContador.TabIndex = 241
        Me.txtContador.Tabulado = True
        Me.txtContador.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtMatricula
        '
        Me.txtMatricula.BackColor = System.Drawing.Color.White
        Me.txtMatricula.Location = New System.Drawing.Point(84, 172)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.NroDecimales = CType(0, Short)
        Me.txtMatricula.SelectGotFocus = True
        Me.txtMatricula.Size = New System.Drawing.Size(208, 20)
        Me.txtMatricula.TabIndex = 242
        Me.txtMatricula.Tabulado = True
        Me.txtMatricula.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.Color.White
        Me.txtperiodo.ForeColor = System.Drawing.Color.Black
        Me.txtperiodo.Location = New System.Drawing.Point(576, 32)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.NroDecimales = CType(0, Short)
        Me.txtperiodo.SelectGotFocus = True
        Me.txtperiodo.Size = New System.Drawing.Size(56, 20)
        Me.txtperiodo.TabIndex = 243
        Me.txtperiodo.Tabulado = True
        Me.txtperiodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtperiodo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(528, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 244
        Me.Label8.Text = "Periodo"
        '
        'chkBiMoneda
        '
        Me.chkBiMoneda.AutoSize = True
        Me.chkBiMoneda.Location = New System.Drawing.Point(458, 192)
        Me.chkBiMoneda.Name = "chkBiMoneda"
        Me.chkBiMoneda.Size = New System.Drawing.Size(171, 17)
        Me.chkBiMoneda.TabIndex = 245
        Me.chkBiMoneda.Text = "Activar Contabilidad BiMoneda"
        Me.chkBiMoneda.UseVisualStyleBackColor = True
        '
        'chkModifTC
        '
        Me.chkModifTC.AutoSize = True
        Me.chkModifTC.Location = New System.Drawing.Point(302, 192)
        Me.chkModifTC.Name = "chkModifTC"
        Me.chkModifTC.Size = New System.Drawing.Size(152, 17)
        Me.chkModifTC.TabIndex = 246
        Me.chkModifTC.Text = "Trabaja con Valores Cuota"
        Me.chkModifTC.UseVisualStyleBackColor = True
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.White
        Me.txtruc.Location = New System.Drawing.Point(206, 32)
        Me.txtruc.MaxLength = 11
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NroDecimales = CType(0, Short)
        Me.txtruc.SelectGotFocus = True
        Me.txtruc.Size = New System.Drawing.Size(170, 20)
        Me.txtruc.TabIndex = 247
        Me.txtruc.Tabulado = True
        Me.txtruc.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(171, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 248
        Me.Label9.Text = "RUC"
        '
        'Frm_Empresa_Abc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 244)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtruc)
        Me.Controls.Add(Me.chkModifTC)
        Me.Controls.Add(Me.chkBiMoneda)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtperiodo)
        Me.Controls.Add(Me.txtMatricula)
        Me.Controls.Add(Me.txtContador)
        Me.Controls.Add(Me.txtCargo)
        Me.Controls.Add(Me.txtRepresentante)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Empresa_Abc"
        Me.Text = "Frm_Empresa_Abc"
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnultimo As System.Windows.Forms.Button
    Friend WithEvents btnsiguiente As System.Windows.Forms.Button
    Friend WithEvents btnanterior As System.Windows.Forms.Button
    Friend WithEvents btnprimero As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtFecha_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFecha_0 As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtTCUsar_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTCUsar_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As KS.UserControl.ksTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkTipoAgente As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As KS.UserControl.ksTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTasaRetencion As KS.UserControl.ksTextBox
    Friend WithEvents txtMontoRetencion As KS.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRepresentante As KS.UserControl.ksTextBox
    Friend WithEvents txtCargo As KS.UserControl.ksTextBox
    Friend WithEvents txtContador As KS.UserControl.ksTextBox
    Friend WithEvents txtMatricula As KS.UserControl.ksTextBox
    Friend WithEvents txtperiodo As KS.UserControl.ksTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkBiMoneda As System.Windows.Forms.CheckBox
    Friend WithEvents chkModifTC As System.Windows.Forms.CheckBox
    Friend WithEvents txtruc As KS.UserControl.ksTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
