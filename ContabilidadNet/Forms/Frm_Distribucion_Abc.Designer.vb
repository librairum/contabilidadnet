<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Distribucion_Abc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Distribucion_Abc))
        Me.txttotalporcentaje = New Ks.UserControl.ksTextBox()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.lnkNuevo = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lnkmodificar = New System.Windows.Forms.LinkLabel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.txtporcentaje = New Ks.UserControl.ksTextBox()
        Me.lnkeliminar = New System.Windows.Forms.LinkLabel()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtctaorigen = New Ks.UserControl.ksTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnultimo = New System.Windows.Forms.Button()
        Me.btnsiguiente = New System.Windows.Forms.Button()
        Me.btnanterior = New System.Windows.Forms.Button()
        Me.btnprimero = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.GbxDetalle = New System.Windows.Forms.GroupBox()
        Me.lnkgrabar = New System.Windows.Forms.LinkLabel()
        Me.lnkcancelar = New System.Windows.Forms.LinkLabel()
        Me.txttipo = New Ks.UserControl.ksTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnhelp_6 = New System.Windows.Forms.Button()
        Me.lblhelp_6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtctadestino = New Ks.UserControl.ksTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnhelp_5 = New System.Windows.Forms.Button()
        Me.lblhelp_5 = New System.Windows.Forms.Label()
        Me.txtcorrelativo = New Ks.UserControl.ksTextBox()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtprioridad = New Ks.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.txtctatransito = New Ks.UserControl.ksTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnhelp_2 = New System.Windows.Forms.Button()
        Me.lblhelp_2 = New System.Windows.Forms.Label()
        Me.txtcodmaquina = New Ks.UserControl.ksTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnhelp_3 = New System.Windows.Forms.Button()
        Me.lblhelp_3 = New System.Windows.Forms.Label()
        Me.txttiponivelgasto = New Ks.UserControl.ksTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnhelp_4 = New System.Windows.Forms.Button()
        Me.lblhelp_4 = New System.Windows.Forms.Label()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GbxDetalle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txttotalporcentaje
        '
        Me.txttotalporcentaje.Location = New System.Drawing.Point(622, 318)
        Me.txttotalporcentaje.Name = "txttotalporcentaje"
        Me.txttotalporcentaje.NroDecimales = CType(2, Short)
        Me.txttotalporcentaje.SelectGotFocus = True
        Me.txttotalporcentaje.Size = New System.Drawing.Size(100, 20)
        Me.txttotalporcentaje.TabIndex = 226
        Me.txttotalporcentaje.Tabulado = True
        Me.txttotalporcentaje.Text = "0.00"
        Me.txttotalporcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotalporcentaje.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(66, 4)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 1
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'lnkNuevo
        '
        Me.lnkNuevo.AutoSize = True
        Me.lnkNuevo.Location = New System.Drawing.Point(2, 18)
        Me.lnkNuevo.Name = "lnkNuevo"
        Me.lnkNuevo.Size = New System.Drawing.Size(44, 13)
        Me.lnkNuevo.TabIndex = 193
        Me.lnkNuevo.TabStop = True
        Me.lnkNuevo.Text = "Agregar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(530, 320)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Total Dolares"
        '
        'lnkmodificar
        '
        Me.lnkmodificar.AutoSize = True
        Me.lnkmodificar.Location = New System.Drawing.Point(48, 18)
        Me.lnkmodificar.Name = "lnkmodificar"
        Me.lnkmodificar.Size = New System.Drawing.Size(50, 13)
        Me.lnkmodificar.TabIndex = 202
        Me.lnkmodificar.TabStop = True
        Me.lnkmodificar.Text = "Modificar"
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(88, 4)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 15
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'txtporcentaje
        '
        Me.txtporcentaje.Location = New System.Drawing.Point(86, 56)
        Me.txtporcentaje.Name = "txtporcentaje"
        Me.txtporcentaje.NroDecimales = CType(2, Short)
        Me.txtporcentaje.SelectGotFocus = True
        Me.txtporcentaje.Size = New System.Drawing.Size(86, 20)
        Me.txtporcentaje.TabIndex = 1
        Me.txtporcentaje.Tabulado = True
        Me.txtporcentaje.Text = "0.00"
        Me.txtporcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtporcentaje.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'lnkeliminar
        '
        Me.lnkeliminar.AutoSize = True
        Me.lnkeliminar.Location = New System.Drawing.Point(100, 18)
        Me.lnkeliminar.Name = "lnkeliminar"
        Me.lnkeliminar.Size = New System.Drawing.Size(43, 13)
        Me.lnkeliminar.TabIndex = 203
        Me.lnkeliminar.TabStop = True
        Me.lnkeliminar.Text = "Eliminar"
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
        Me.tblconsulta.Location = New System.Drawing.Point(20, 186)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(702, 126)
        Me.tblconsulta.TabIndex = 217
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(234, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 16)
        Me.GroupBox1.TabIndex = 205
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DETALLES DE DISTRIBUCION"
        '
        'txtctaorigen
        '
        Me.txtctaorigen.Location = New System.Drawing.Point(88, 32)
        Me.txtctaorigen.Name = "txtctaorigen"
        Me.txtctaorigen.NroDecimales = CType(0, Short)
        Me.txtctaorigen.SelectGotFocus = True
        Me.txtctaorigen.Size = New System.Drawing.Size(98, 20)
        Me.txtctaorigen.TabIndex = 0
        Me.txtctaorigen.Tabulado = True
        Me.txtctaorigen.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 340)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(750, 28)
        Me.Panel3.TabIndex = 216
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btncancelar)
        Me.Panel2.Controls.Add(Me.btngrabar)
        Me.Panel2.Controls.Add(Me.btneliminar)
        Me.Panel2.Controls.Add(Me.btnmodificar)
        Me.Panel2.Controls.Add(Me.btnnuevo)
        Me.Panel2.Location = New System.Drawing.Point(6, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(116, 26)
        Me.Panel2.TabIndex = 14
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(44, 4)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 52
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(24, 4)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 51
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(2, 4)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 50
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Cuenta Origen"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(186, 30)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 227
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(208, 32)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(274, 18)
        Me.lblhelp_0.TabIndex = 211
        Me.lblhelp_0.Text = "???"
        '
        'GbxDetalle
        '
        Me.GbxDetalle.Controls.Add(Me.lnkgrabar)
        Me.GbxDetalle.Controls.Add(Me.lnkcancelar)
        Me.GbxDetalle.Controls.Add(Me.txttipo)
        Me.GbxDetalle.Controls.Add(Me.Label15)
        Me.GbxDetalle.Controls.Add(Me.btnhelp_6)
        Me.GbxDetalle.Controls.Add(Me.lblhelp_6)
        Me.GbxDetalle.Controls.Add(Me.Label14)
        Me.GbxDetalle.Controls.Add(Me.txtctadestino)
        Me.GbxDetalle.Controls.Add(Me.Label12)
        Me.GbxDetalle.Controls.Add(Me.btnhelp_5)
        Me.GbxDetalle.Controls.Add(Me.lblhelp_5)
        Me.GbxDetalle.Controls.Add(Me.GroupBox1)
        Me.GbxDetalle.Controls.Add(Me.lnkNuevo)
        Me.GbxDetalle.Controls.Add(Me.lnkmodificar)
        Me.GbxDetalle.Controls.Add(Me.lnkeliminar)
        Me.GbxDetalle.Controls.Add(Me.txtporcentaje)
        Me.GbxDetalle.Controls.Add(Me.txtcorrelativo)
        Me.GbxDetalle.Location = New System.Drawing.Point(22, 102)
        Me.GbxDetalle.Name = "GbxDetalle"
        Me.GbxDetalle.Size = New System.Drawing.Size(702, 82)
        Me.GbxDetalle.TabIndex = 0
        Me.GbxDetalle.TabStop = False
        '
        'lnkgrabar
        '
        Me.lnkgrabar.AutoSize = True
        Me.lnkgrabar.Location = New System.Drawing.Point(160, 20)
        Me.lnkgrabar.Name = "lnkgrabar"
        Me.lnkgrabar.Size = New System.Drawing.Size(39, 13)
        Me.lnkgrabar.TabIndex = 250
        Me.lnkgrabar.TabStop = True
        Me.lnkgrabar.Text = "Grabar"
        '
        'lnkcancelar
        '
        Me.lnkcancelar.AutoSize = True
        Me.lnkcancelar.Location = New System.Drawing.Point(198, 20)
        Me.lnkcancelar.Name = "lnkcancelar"
        Me.lnkcancelar.Size = New System.Drawing.Size(49, 13)
        Me.lnkcancelar.TabIndex = 251
        Me.lnkcancelar.TabStop = True
        Me.lnkcancelar.Text = "Cancelar"
        '
        'txttipo
        '
        Me.txttipo.Location = New System.Drawing.Point(280, 56)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.NroDecimales = CType(0, Short)
        Me.txttipo.SelectGotFocus = True
        Me.txttipo.Size = New System.Drawing.Size(32, 20)
        Me.txttipo.TabIndex = 2
        Me.txttipo.Tabulado = True
        Me.txttipo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(230, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 248
        Me.Label15.Text = "Prioridad"
        '
        'btnhelp_6
        '
        Me.btnhelp_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_6.Location = New System.Drawing.Point(312, 56)
        Me.btnhelp_6.Name = "btnhelp_6"
        Me.btnhelp_6.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_6.TabIndex = 249
        Me.btnhelp_6.Text = ":::"
        Me.btnhelp_6.UseVisualStyleBackColor = True
        '
        'lblhelp_6
        '
        Me.lblhelp_6.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_6.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_6.Location = New System.Drawing.Point(334, 58)
        Me.lblhelp_6.Name = "lblhelp_6"
        Me.lblhelp_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_6.Size = New System.Drawing.Size(356, 18)
        Me.lblhelp_6.TabIndex = 247
        Me.lblhelp_6.Text = "???"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 232
        Me.Label14.Text = "Porcentaje"
        '
        'txtctadestino
        '
        Me.txtctadestino.Location = New System.Drawing.Point(86, 34)
        Me.txtctadestino.Name = "txtctadestino"
        Me.txtctadestino.NroDecimales = CType(0, Short)
        Me.txtctadestino.SelectGotFocus = True
        Me.txtctadestino.Size = New System.Drawing.Size(114, 20)
        Me.txtctadestino.TabIndex = 0
        Me.txtctadestino.Tabulado = True
        Me.txtctadestino.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 230
        Me.Label12.Text = "Cuenta Destino"
        '
        'btnhelp_5
        '
        Me.btnhelp_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_5.Location = New System.Drawing.Point(200, 34)
        Me.btnhelp_5.Name = "btnhelp_5"
        Me.btnhelp_5.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_5.TabIndex = 231
        Me.btnhelp_5.Text = ":::"
        Me.btnhelp_5.UseVisualStyleBackColor = True
        '
        'lblhelp_5
        '
        Me.lblhelp_5.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_5.Location = New System.Drawing.Point(222, 34)
        Me.lblhelp_5.Name = "lblhelp_5"
        Me.lblhelp_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_5.Size = New System.Drawing.Size(468, 18)
        Me.lblhelp_5.TabIndex = 229
        Me.lblhelp_5.Text = "???"
        '
        'txtcorrelativo
        '
        Me.txtcorrelativo.Location = New System.Drawing.Point(608, 12)
        Me.txtcorrelativo.Name = "txtcorrelativo"
        Me.txtcorrelativo.NroDecimales = CType(0, Short)
        Me.txtcorrelativo.SelectGotFocus = True
        Me.txtcorrelativo.Size = New System.Drawing.Size(86, 20)
        Me.txtcorrelativo.TabIndex = 252
        Me.txtcorrelativo.Tabulado = True
        Me.txtcorrelativo.Text = "0"
        Me.txtcorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtcorrelativo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(680, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 30)
        Me.Panel1.TabIndex = 5
        '
        'txtprioridad
        '
        Me.txtprioridad.Location = New System.Drawing.Point(568, 32)
        Me.txtprioridad.Name = "txtprioridad"
        Me.txtprioridad.NroDecimales = CType(0, Short)
        Me.txtprioridad.SelectGotFocus = True
        Me.txtprioridad.Size = New System.Drawing.Size(32, 20)
        Me.txtprioridad.TabIndex = 1
        Me.txtprioridad.Tabulado = True
        Me.txtprioridad.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(498, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "Prioridad"
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(600, 30)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 233
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(620, 32)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(124, 18)
        Me.lblhelp_1.TabIndex = 231
        Me.lblhelp_1.Text = "???"
        '
        'txtctatransito
        '
        Me.txtctatransito.Location = New System.Drawing.Point(88, 54)
        Me.txtctatransito.Name = "txtctatransito"
        Me.txtctatransito.NroDecimales = CType(0, Short)
        Me.txtctatransito.SelectGotFocus = True
        Me.txtctatransito.Size = New System.Drawing.Size(98, 20)
        Me.txtctatransito.TabIndex = 2
        Me.txtctatransito.Tabulado = True
        Me.txtctatransito.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Cuenta a saldar"
        '
        'btnhelp_2
        '
        Me.btnhelp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_2.Location = New System.Drawing.Point(186, 52)
        Me.btnhelp_2.Name = "btnhelp_2"
        Me.btnhelp_2.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_2.TabIndex = 237
        Me.btnhelp_2.Text = ":::"
        Me.btnhelp_2.UseVisualStyleBackColor = True
        '
        'lblhelp_2
        '
        Me.lblhelp_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_2.Location = New System.Drawing.Point(208, 54)
        Me.lblhelp_2.Name = "lblhelp_2"
        Me.lblhelp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_2.Size = New System.Drawing.Size(274, 18)
        Me.lblhelp_2.TabIndex = 235
        Me.lblhelp_2.Text = "???"
        '
        'txtcodmaquina
        '
        Me.txtcodmaquina.Location = New System.Drawing.Point(568, 54)
        Me.txtcodmaquina.Name = "txtcodmaquina"
        Me.txtcodmaquina.NroDecimales = CType(0, Short)
        Me.txtcodmaquina.SelectGotFocus = True
        Me.txtcodmaquina.Size = New System.Drawing.Size(32, 20)
        Me.txtcodmaquina.TabIndex = 3
        Me.txtcodmaquina.Tabulado = True
        Me.txtcodmaquina.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(498, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 240
        Me.Label8.Text = "Cod maquina"
        '
        'btnhelp_3
        '
        Me.btnhelp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_3.Location = New System.Drawing.Point(600, 52)
        Me.btnhelp_3.Name = "btnhelp_3"
        Me.btnhelp_3.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_3.TabIndex = 241
        Me.btnhelp_3.Text = ":::"
        Me.btnhelp_3.UseVisualStyleBackColor = True
        '
        'lblhelp_3
        '
        Me.lblhelp_3.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_3.Location = New System.Drawing.Point(622, 54)
        Me.lblhelp_3.Name = "lblhelp_3"
        Me.lblhelp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_3.Size = New System.Drawing.Size(122, 18)
        Me.lblhelp_3.TabIndex = 239
        Me.lblhelp_3.Text = "???"
        '
        'txttiponivelgasto
        '
        Me.txttiponivelgasto.Location = New System.Drawing.Point(88, 76)
        Me.txttiponivelgasto.Name = "txttiponivelgasto"
        Me.txttiponivelgasto.NroDecimales = CType(0, Short)
        Me.txttiponivelgasto.SelectGotFocus = True
        Me.txttiponivelgasto.Size = New System.Drawing.Size(98, 20)
        Me.txttiponivelgasto.TabIndex = 4
        Me.txttiponivelgasto.Tabulado = True
        Me.txttiponivelgasto.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 244
        Me.Label10.Text = "Tipo Nivel Gasto"
        '
        'btnhelp_4
        '
        Me.btnhelp_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_4.Location = New System.Drawing.Point(186, 72)
        Me.btnhelp_4.Name = "btnhelp_4"
        Me.btnhelp_4.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_4.TabIndex = 245
        Me.btnhelp_4.Text = ":::"
        Me.btnhelp_4.UseVisualStyleBackColor = True
        '
        'lblhelp_4
        '
        Me.lblhelp_4.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_4.Location = New System.Drawing.Point(208, 74)
        Me.lblhelp_4.Name = "lblhelp_4"
        Me.lblhelp_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_4.Size = New System.Drawing.Size(538, 18)
        Me.lblhelp_4.TabIndex = 243
        Me.lblhelp_4.Text = "???"
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
        Me.tblhelp.Location = New System.Drawing.Point(6, 206)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(362, 138)
        Me.tblhelp.TabIndex = 253
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'Frm_Distribucion_Abc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 368)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.txttiponivelgasto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnhelp_4)
        Me.Controls.Add(Me.lblhelp_4)
        Me.Controls.Add(Me.txtcodmaquina)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnhelp_3)
        Me.Controls.Add(Me.lblhelp_3)
        Me.Controls.Add(Me.txtctatransito)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnhelp_2)
        Me.Controls.Add(Me.lblhelp_2)
        Me.Controls.Add(Me.txtprioridad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.txttotalporcentaje)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.txtctaorigen)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.GbxDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Distribucion_Abc"
        Me.Text = "Frm_Distribucion_Abc"
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GbxDetalle.ResumeLayout(False)
        Me.GbxDetalle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txttotalporcentaje As KS.UserControl.ksTextBox
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents lnkNuevo As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lnkmodificar As System.Windows.Forms.LinkLabel
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents txtporcentaje As KS.UserControl.ksTextBox
    Friend WithEvents lnkeliminar As System.Windows.Forms.LinkLabel
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtctaorigen As KS.UserControl.ksTextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnultimo As System.Windows.Forms.Button
    Friend WithEvents btnsiguiente As System.Windows.Forms.Button
    Friend WithEvents btnanterior As System.Windows.Forms.Button
    Friend WithEvents btnprimero As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents GbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtprioridad As KS.UserControl.ksTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txtctatransito As KS.UserControl.ksTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_2 As System.Windows.Forms.Button
    Public WithEvents lblhelp_2 As System.Windows.Forms.Label
    Friend WithEvents txtcodmaquina As KS.UserControl.ksTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_3 As System.Windows.Forms.Button
    Public WithEvents lblhelp_3 As System.Windows.Forms.Label
    Friend WithEvents txttiponivelgasto As KS.UserControl.ksTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_4 As System.Windows.Forms.Button
    Public WithEvents lblhelp_4 As System.Windows.Forms.Label
    Friend WithEvents txttipo As KS.UserControl.ksTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_6 As System.Windows.Forms.Button
    Public WithEvents lblhelp_6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtctadestino As KS.UserControl.ksTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_5 As System.Windows.Forms.Button
    Public WithEvents lblhelp_5 As System.Windows.Forms.Label
    Friend WithEvents lnkgrabar As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkcancelar As System.Windows.Forms.LinkLabel
    Friend WithEvents txtcorrelativo As KS.UserControl.ksTextBox
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
