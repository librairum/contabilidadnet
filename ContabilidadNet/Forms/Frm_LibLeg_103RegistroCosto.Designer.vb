<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LibLeg_103RegistroCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LibLeg_103RegistroCosto))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimportar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.txtCodAgrupDescripcion = New KS.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtInvFinalProducProceso = New KS.UserControl.ksTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtInvInicialProducProceso = New KS.UserControl.ksTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGastoOtrosIndirecto = New KS.UserControl.ksTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtGastoManoObraIndirecta = New KS.UserControl.ksTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtGastoMatIndirecto = New KS.UserControl.ksTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCostoOtrosDirectos = New KS.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCostoManoObraDirecta = New KS.UserControl.ksTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCostoMatDirectos = New KS.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodAgrup = New KS.UserControl.ksTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.txtCodAgrupAyuda = New KS.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tblhelp_0 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tblhelp_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnimportar)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(971, 31)
        Me.Panel1.TabIndex = 154
        '
        'btnimportar
        '
        Me.btnimportar.Image = Global.ContabilidadNet.My.Resources.Resources.Copy1
        Me.btnimportar.Location = New System.Drawing.Point(70, 2)
        Me.btnimportar.Name = "btnimportar"
        Me.btnimportar.Size = New System.Drawing.Size(24, 24)
        Me.btnimportar.TabIndex = 44
        Me.btnimportar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(148, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 6
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(126, 2)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 0
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(448, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
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
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(27, 2)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 13
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(5, 2)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 3
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'txtCodAgrupDescripcion
        '
        Me.txtCodAgrupDescripcion.Location = New System.Drawing.Point(444, 14)
        Me.txtCodAgrupDescripcion.Name = "txtCodAgrupDescripcion"
        Me.txtCodAgrupDescripcion.NroDecimales = CType(4, Short)
        Me.txtCodAgrupDescripcion.SelectGotFocus = True
        Me.txtCodAgrupDescripcion.Size = New System.Drawing.Size(313, 20)
        Me.txtCodAgrupDescripcion.TabIndex = 4
        Me.txtCodAgrupDescripcion.Tabulado = True
        Me.txtCodAgrupDescripcion.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(381, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripcion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnseleccionartodo_0)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.tblconsulta)
        Me.GroupBox1.Controls.Add(Me.txtCodAgrup)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblhelp_0)
        Me.GroupBox1.Controls.Add(Me.btnhelp_0)
        Me.GroupBox1.Controls.Add(Me.txtCodAgrupAyuda)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCodAgrupDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(954, 389)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 9)
        Me.Label14.TabIndex = 253
        Me.Label14.Text = "INVENTARIOS:"
        '
        'txtInvFinalProducProceso
        '
        Me.txtInvFinalProducProceso.Location = New System.Drawing.Point(539, 94)
        Me.txtInvFinalProducProceso.Name = "txtInvFinalProducProceso"
        Me.txtInvFinalProducProceso.NroDecimales = CType(2, Short)
        Me.txtInvFinalProducProceso.SelectGotFocus = True
        Me.txtInvFinalProducProceso.Size = New System.Drawing.Size(111, 20)
        Me.txtInvFinalProducProceso.TabIndex = 8
        Me.txtInvFinalProducProceso.Tabulado = True
        Me.txtInvFinalProducProceso.Text = "0.00"
        Me.txtInvFinalProducProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtInvFinalProducProceso.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(352, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(183, 13)
        Me.Label12.TabIndex = 251
        Me.Label12.Text = "Inventario final Productos en proceso"
        '
        'txtInvInicialProducProceso
        '
        Me.txtInvInicialProducProceso.Location = New System.Drawing.Point(257, 94)
        Me.txtInvInicialProducProceso.Name = "txtInvInicialProducProceso"
        Me.txtInvInicialProducProceso.NroDecimales = CType(2, Short)
        Me.txtInvInicialProducProceso.SelectGotFocus = True
        Me.txtInvInicialProducProceso.Size = New System.Drawing.Size(87, 20)
        Me.txtInvInicialProducProceso.TabIndex = 7
        Me.txtInvInicialProducProceso.Tabulado = True
        Me.txtInvInicialProducProceso.Text = "0.00"
        Me.txtInvInicialProducProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtInvInicialProducProceso.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(72, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(192, 13)
        Me.Label13.TabIndex = 249
        Me.Label13.Text = "Inventario Inicial Productos en Proceso"
        '
        'txtGastoOtrosIndirecto
        '
        Me.txtGastoOtrosIndirecto.Location = New System.Drawing.Point(777, 63)
        Me.txtGastoOtrosIndirecto.Name = "txtGastoOtrosIndirecto"
        Me.txtGastoOtrosIndirecto.NroDecimales = CType(2, Short)
        Me.txtGastoOtrosIndirecto.SelectGotFocus = True
        Me.txtGastoOtrosIndirecto.Size = New System.Drawing.Size(118, 20)
        Me.txtGastoOtrosIndirecto.TabIndex = 6
        Me.txtGastoOtrosIndirecto.Tabulado = True
        Me.txtGastoOtrosIndirecto.Text = "0.00"
        Me.txtGastoOtrosIndirecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGastoOtrosIndirecto.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(662, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 13)
        Me.Label9.TabIndex = 247
        Me.Label9.Text = "Otros Gastos Indirecto"
        '
        'txtGastoManoObraIndirecta
        '
        Me.txtGastoManoObraIndirecta.Location = New System.Drawing.Point(539, 63)
        Me.txtGastoManoObraIndirecta.Name = "txtGastoManoObraIndirecta"
        Me.txtGastoManoObraIndirecta.NroDecimales = CType(2, Short)
        Me.txtGastoManoObraIndirecta.SelectGotFocus = True
        Me.txtGastoManoObraIndirecta.Size = New System.Drawing.Size(111, 20)
        Me.txtGastoManoObraIndirecta.TabIndex = 5
        Me.txtGastoManoObraIndirecta.Tabulado = True
        Me.txtGastoManoObraIndirecta.Text = "0.00"
        Me.txtGastoManoObraIndirecta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGastoManoObraIndirecta.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(352, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 13)
        Me.Label10.TabIndex = 245
        Me.Label10.Text = "Gasto Mano de obra Indirecta"
        '
        'txtGastoMatIndirecto
        '
        Me.txtGastoMatIndirecto.Location = New System.Drawing.Point(257, 63)
        Me.txtGastoMatIndirecto.Name = "txtGastoMatIndirecto"
        Me.txtGastoMatIndirecto.NroDecimales = CType(2, Short)
        Me.txtGastoMatIndirecto.SelectGotFocus = True
        Me.txtGastoMatIndirecto.Size = New System.Drawing.Size(87, 20)
        Me.txtGastoMatIndirecto.TabIndex = 4
        Me.txtGastoMatIndirecto.Tabulado = True
        Me.txtGastoMatIndirecto.Text = "0.00"
        Me.txtGastoMatIndirecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGastoMatIndirecto.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(72, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(168, 13)
        Me.Label11.TabIndex = 243
        Me.Label11.Text = "Materiales y Suministros Indirectos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 9)
        Me.Label8.TabIndex = 242
        Me.Label8.Text = "COSTOS DIRECTOS:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 9)
        Me.Label7.TabIndex = 241
        Me.Label7.Text = "GASTOS PRODUCCION INDIRECTOS:"
        '
        'txtCostoOtrosDirectos
        '
        Me.txtCostoOtrosDirectos.Location = New System.Drawing.Point(775, 31)
        Me.txtCostoOtrosDirectos.Name = "txtCostoOtrosDirectos"
        Me.txtCostoOtrosDirectos.NroDecimales = CType(2, Short)
        Me.txtCostoOtrosDirectos.SelectGotFocus = True
        Me.txtCostoOtrosDirectos.Size = New System.Drawing.Size(118, 20)
        Me.txtCostoOtrosDirectos.TabIndex = 3
        Me.txtCostoOtrosDirectos.Tabulado = True
        Me.txtCostoOtrosDirectos.Text = "0.00"
        Me.txtCostoOtrosDirectos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCostoOtrosDirectos.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(663, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "Otros Costos Directos"
        '
        'txtCostoManoObraDirecta
        '
        Me.txtCostoManoObraDirecta.Location = New System.Drawing.Point(539, 31)
        Me.txtCostoManoObraDirecta.Name = "txtCostoManoObraDirecta"
        Me.txtCostoManoObraDirecta.NroDecimales = CType(2, Short)
        Me.txtCostoManoObraDirecta.SelectGotFocus = True
        Me.txtCostoManoObraDirecta.Size = New System.Drawing.Size(111, 20)
        Me.txtCostoManoObraDirecta.TabIndex = 2
        Me.txtCostoManoObraDirecta.Tabulado = True
        Me.txtCostoManoObraDirecta.Text = "0.00"
        Me.txtCostoManoObraDirecta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCostoManoObraDirecta.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(352, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 13)
        Me.Label6.TabIndex = 237
        Me.Label6.Text = "Costo Mano de Obra Directa"
        '
        'txtCostoMatDirectos
        '
        Me.txtCostoMatDirectos.Location = New System.Drawing.Point(257, 31)
        Me.txtCostoMatDirectos.Name = "txtCostoMatDirectos"
        Me.txtCostoMatDirectos.NroDecimales = CType(2, Short)
        Me.txtCostoMatDirectos.SelectGotFocus = True
        Me.txtCostoMatDirectos.Size = New System.Drawing.Size(87, 20)
        Me.txtCostoMatDirectos.TabIndex = 1
        Me.txtCostoMatDirectos.Tabulado = True
        Me.txtCostoMatDirectos.Text = "0.00"
        Me.txtCostoMatDirectos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCostoMatDirectos.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(72, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 13)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "Costo Materiales y Sumi Directos"
        '
        'txtCodAgrup
        '
        Me.txtCodAgrup.Location = New System.Drawing.Point(319, 14)
        Me.txtCodAgrup.Name = "txtCodAgrup"
        Me.txtCodAgrup.NroDecimales = CType(0, Short)
        Me.txtCodAgrup.SelectGotFocus = True
        Me.txtCodAgrup.Size = New System.Drawing.Size(56, 20)
        Me.txtCodAgrup.TabIndex = 3
        Me.txtCodAgrup.Tabulado = True
        Me.txtCodAgrup.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 233
        Me.Label4.Text = "Codigo"
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(131, 15)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(148, 18)
        Me.lblhelp_0.TabIndex = 2
        Me.lblhelp_0.Text = "???"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(105, 13)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 231
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'txtCodAgrupAyuda
        '
        Me.txtCodAgrupAyuda.Location = New System.Drawing.Point(68, 14)
        Me.txtCodAgrupAyuda.Name = "txtCodAgrupAyuda"
        Me.txtCodAgrupAyuda.NroDecimales = CType(4, Short)
        Me.txtCodAgrupAyuda.SelectGotFocus = True
        Me.txtCodAgrupAyuda.Size = New System.Drawing.Size(34, 20)
        Me.txtCodAgrupAyuda.TabIndex = 1
        Me.txtCodAgrupAyuda.Tabulado = True
        Me.txtCodAgrupAyuda.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Cod Agrup"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 429)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(971, 26)
        Me.Panel3.TabIndex = 1
        '
        'tblhelp_0
        '
        Me.tblhelp_0.AllowUpdate = False
        Me.tblhelp_0.AllowUpdateOnBlur = False
        Me.tblhelp_0.AlternatingRows = True
        Me.tblhelp_0.FilterBar = True
        Me.tblhelp_0.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblhelp_0.Images.Add(CType(resources.GetObject("tblhelp_0.Images"), System.Drawing.Image))
        Me.tblhelp_0.LinesPerRow = 1
        Me.tblhelp_0.Location = New System.Drawing.Point(324, 293)
        Me.tblhelp_0.Name = "tblhelp_0"
        Me.tblhelp_0.PictureCurrentRow = CType(resources.GetObject("tblhelp_0.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp_0.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp_0.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp_0.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp_0.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp_0.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp_0.Size = New System.Drawing.Size(308, 130)
        Me.tblhelp_0.TabIndex = 0
        Me.tblhelp_0.TabStop = False
        Me.tblhelp_0.Text = "C1TrueDBGrid1"
        Me.tblhelp_0.UseColumnStyles = False
        Me.tblhelp_0.Visible = False
        Me.tblhelp_0.PropBag = resources.GetString("tblhelp_0.PropBag")
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
        Me.tblconsulta.Location = New System.Drawing.Point(11, 164)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(943, 173)
        Me.tblconsulta.TabIndex = 155
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(11, 164)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 254
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Location = New System.Drawing.Point(96, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(795, 10)
        Me.GroupBox2.TabIndex = 254
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Location = New System.Drawing.Point(167, 51)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(743, 10)
        Me.GroupBox3.TabIndex = 255
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Location = New System.Drawing.Point(80, 83)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(827, 10)
        Me.GroupBox4.TabIndex = 255
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.GroupBox3)
        Me.GroupBox5.Controls.Add(Me.txtCostoMatDirectos)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtCostoManoObraDirecta)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.txtInvFinalProducProceso)
        Me.GroupBox5.Controls.Add(Me.txtCostoOtrosDirectos)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtInvInicialProducProceso)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.txtGastoOtrosIndirecto)
        Me.GroupBox5.Controls.Add(Me.txtGastoMatIndirecto)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtGastoManoObraIndirecta)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 41)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(941, 117)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        '
        'Frm_LibLeg_103RegistroCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 455)
        Me.Controls.Add(Me.tblhelp_0)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_LibLeg_103RegistroCosto"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tblhelp_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents txtCodAgrupDescripcion As KS.UserControl.ksTextBox
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodAgrupAyuda As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents tblhelp_0 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
    Friend WithEvents txtCodAgrup As Ks.UserControl.ksTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCostoMatDirectos As KS.UserControl.ksTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCostoManoObraDirecta As KS.UserControl.ksTextBox
    Friend WithEvents txtCostoOtrosDirectos As KS.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGastoOtrosIndirecto As KS.UserControl.ksTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtGastoManoObraIndirecta As KS.UserControl.ksTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtGastoMatIndirecto As KS.UserControl.ksTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtInvFinalProducProceso As KS.UserControl.ksTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtInvInicialProducProceso As KS.UserControl.ksTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnimportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
