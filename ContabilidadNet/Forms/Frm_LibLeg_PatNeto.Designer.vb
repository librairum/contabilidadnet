<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LibLeg_PatNeto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LibLeg_PatNeto))
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnimportar = New System.Windows.Forms.Button()
        Me.btninsertar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCapitalAdicional = New Ks.UserControl.ksTextBox()
        Me.txtAccionesInversion = New Ks.UserControl.ksTextBox()
        Me.txtdescripcion = New Ks.UserControl.ksTextBox()
        Me.txtcapital = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtExcedenteRevalua = New Ks.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtreservalegal = New Ks.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtotrasreservas = New Ks.UserControl.ksTextBox()
        Me.txtresultadoAcum = New Ks.UserControl.ksTextBox()
        Me.txttotal = New Ks.UserControl.ksTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCodigoPLE = New Ks.UserControl.ksTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtResultadoNoRealizado = New Ks.UserControl.ksTextBox()
        Me.txtDifeConversion = New Ks.UserControl.ksTextBox()
        Me.txtAjustePatrimonio = New Ks.UserControl.ksTextBox()
        Me.txtResultadoNetoEjercicio = New Ks.UserControl.ksTextBox()
        Me.txtResultadoEjercicio = New Ks.UserControl.ksTextBox()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.tblhelp.Location = New System.Drawing.Point(284, 249)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(340, 140)
        Me.tblhelp.TabIndex = 0
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
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
        Me.btnsalir.Location = New System.Drawing.Point(664, 2)
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
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(48, 2)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 13
        Me.btnmodificar.UseVisualStyleBackColor = True
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
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(338, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 28)
        Me.Label8.TabIndex = 379
        Me.Label8.Text = "Reserva legal"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(256, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 28)
        Me.Label7.TabIndex = 378
        Me.Label7.Text = "Excedente de  Revaluacion"
        '
        'txtCapitalAdicional
        '
        Me.txtCapitalAdicional.Location = New System.Drawing.Point(92, 96)
        Me.txtCapitalAdicional.Name = "txtCapitalAdicional"
        Me.txtCapitalAdicional.NroDecimales = CType(0, Short)
        Me.txtCapitalAdicional.SelectGotFocus = True
        Me.txtCapitalAdicional.Size = New System.Drawing.Size(80, 20)
        Me.txtCapitalAdicional.TabIndex = 5
        Me.txtCapitalAdicional.Tabulado = True
        Me.txtCapitalAdicional.Text = "0.00"
        Me.txtCapitalAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCapitalAdicional.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtAccionesInversion
        '
        Me.txtAccionesInversion.Location = New System.Drawing.Point(174, 96)
        Me.txtAccionesInversion.Name = "txtAccionesInversion"
        Me.txtAccionesInversion.NroDecimales = CType(0, Short)
        Me.txtAccionesInversion.SelectGotFocus = True
        Me.txtAccionesInversion.Size = New System.Drawing.Size(80, 20)
        Me.txtAccionesInversion.TabIndex = 6
        Me.txtAccionesInversion.Tabulado = True
        Me.txtAccionesInversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAccionesInversion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtdescripcion
        '
        Me.txtdescripcion.Location = New System.Drawing.Point(72, 38)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.NroDecimales = CType(0, Short)
        Me.txtdescripcion.SelectGotFocus = True
        Me.txtdescripcion.Size = New System.Drawing.Size(594, 20)
        Me.txtdescripcion.TabIndex = 3
        Me.txtdescripcion.Tabulado = True
        Me.txtdescripcion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtcapital
        '
        Me.txtcapital.Location = New System.Drawing.Point(9, 96)
        Me.txtcapital.Name = "txtcapital"
        Me.txtcapital.NroDecimales = CType(0, Short)
        Me.txtcapital.SelectGotFocus = True
        Me.txtcapital.Size = New System.Drawing.Size(80, 20)
        Me.txtcapital.TabIndex = 4
        Me.txtcapital.Tabulado = True
        Me.txtcapital.Text = "0.00"
        Me.txtcapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtcapital.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 28)
        Me.Label3.TabIndex = 372
        Me.Label3.Text = "Capital"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(8, 42)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(63, 13)
        Me.Label32.TabIndex = 373
        Me.Label32.Text = "Descripcion"
        '
        'txtExcedenteRevalua
        '
        Me.txtExcedenteRevalua.Location = New System.Drawing.Point(256, 96)
        Me.txtExcedenteRevalua.Name = "txtExcedenteRevalua"
        Me.txtExcedenteRevalua.NroDecimales = CType(0, Short)
        Me.txtExcedenteRevalua.SelectGotFocus = True
        Me.txtExcedenteRevalua.Size = New System.Drawing.Size(80, 20)
        Me.txtExcedenteRevalua.TabIndex = 7
        Me.txtExcedenteRevalua.Tabulado = True
        Me.txtExcedenteRevalua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtExcedenteRevalua.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(174, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 28)
        Me.Label2.TabIndex = 371
        Me.Label2.Text = "Acciones de Inversion"
        '
        'txtreservalegal
        '
        Me.txtreservalegal.Location = New System.Drawing.Point(338, 96)
        Me.txtreservalegal.Name = "txtreservalegal"
        Me.txtreservalegal.NroDecimales = CType(0, Short)
        Me.txtreservalegal.SelectGotFocus = True
        Me.txtreservalegal.Size = New System.Drawing.Size(80, 20)
        Me.txtreservalegal.TabIndex = 8
        Me.txtreservalegal.Tabulado = True
        Me.txtreservalegal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtreservalegal.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(92, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 28)
        Me.Label1.TabIndex = 370
        Me.Label1.Text = "Capital Adicional"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 396)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(700, 28)
        Me.Panel3.TabIndex = 1
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
        Me.Panel1.Size = New System.Drawing.Size(700, 31)
        Me.Panel1.TabIndex = 2
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
        Me.tblconsulta.Location = New System.Drawing.Point(5, 214)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(658, 152)
        Me.tblconsulta.TabIndex = 368
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(420, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 28)
        Me.Label4.TabIndex = 380
        Me.Label4.Text = "Otras Reservas"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(502, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 28)
        Me.Label5.TabIndex = 381
        Me.Label5.Text = "Resultados Acumulados"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(584, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 28)
        Me.Label6.TabIndex = 382
        Me.Label6.Text = "Total"
        Me.Label6.Visible = False
        '
        'txtotrasreservas
        '
        Me.txtotrasreservas.Location = New System.Drawing.Point(420, 96)
        Me.txtotrasreservas.Name = "txtotrasreservas"
        Me.txtotrasreservas.NroDecimales = CType(0, Short)
        Me.txtotrasreservas.SelectGotFocus = True
        Me.txtotrasreservas.Size = New System.Drawing.Size(80, 20)
        Me.txtotrasreservas.TabIndex = 9
        Me.txtotrasreservas.Tabulado = True
        Me.txtotrasreservas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtotrasreservas.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtresultadoAcum
        '
        Me.txtresultadoAcum.Location = New System.Drawing.Point(502, 96)
        Me.txtresultadoAcum.Name = "txtresultadoAcum"
        Me.txtresultadoAcum.NroDecimales = CType(0, Short)
        Me.txtresultadoAcum.SelectGotFocus = True
        Me.txtresultadoAcum.Size = New System.Drawing.Size(80, 20)
        Me.txtresultadoAcum.TabIndex = 10
        Me.txtresultadoAcum.Tabulado = True
        Me.txtresultadoAcum.Text = "0.00"
        Me.txtresultadoAcum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtresultadoAcum.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txttotal
        '
        Me.txttotal.Location = New System.Drawing.Point(584, 96)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.NroDecimales = CType(0, Short)
        Me.txttotal.SelectGotFocus = True
        Me.txttotal.Size = New System.Drawing.Size(80, 20)
        Me.txttotal.TabIndex = 11
        Me.txttotal.Tabulado = True
        Me.txttotal.Text = "0.00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotal.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        Me.txttotal.Visible = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 21)
        Me.Label10.TabIndex = 388
        Me.Label10.Text = "Codigo PLE"
        '
        'txtCodigoPLE
        '
        Me.txtCodigoPLE.Location = New System.Drawing.Point(72, 176)
        Me.txtCodigoPLE.Name = "txtCodigoPLE"
        Me.txtCodigoPLE.NroDecimales = CType(0, Short)
        Me.txtCodigoPLE.SelectGotFocus = True
        Me.txtCodigoPLE.Size = New System.Drawing.Size(80, 20)
        Me.txtCodigoPLE.TabIndex = 17
        Me.txtCodigoPLE.Tabulado = True
        Me.txtCodigoPLE.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 28)
        Me.Label11.TabIndex = 390
        Me.Label11.Text = "Resultados No Realizados"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(90, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 28)
        Me.Label12.TabIndex = 391
        Me.Label12.Text = "Diferencia Conversion"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(174, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 28)
        Me.Label13.TabIndex = 392
        Me.Label13.Text = "Ajuste Patrimonio"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(256, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 28)
        Me.Label14.TabIndex = 393
        Me.Label14.Text = "Resultado Neto Ejercicio"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(335, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 28)
        Me.Label15.TabIndex = 394
        Me.Label15.Text = "Resultado Ejercicio"
        '
        'txtResultadoNoRealizado
        '
        Me.txtResultadoNoRealizado.Location = New System.Drawing.Point(6, 150)
        Me.txtResultadoNoRealizado.Name = "txtResultadoNoRealizado"
        Me.txtResultadoNoRealizado.NroDecimales = CType(0, Short)
        Me.txtResultadoNoRealizado.SelectGotFocus = True
        Me.txtResultadoNoRealizado.Size = New System.Drawing.Size(80, 20)
        Me.txtResultadoNoRealizado.TabIndex = 12
        Me.txtResultadoNoRealizado.Tabulado = True
        Me.txtResultadoNoRealizado.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtDifeConversion
        '
        Me.txtDifeConversion.Location = New System.Drawing.Point(90, 150)
        Me.txtDifeConversion.Name = "txtDifeConversion"
        Me.txtDifeConversion.NroDecimales = CType(0, Short)
        Me.txtDifeConversion.SelectGotFocus = True
        Me.txtDifeConversion.Size = New System.Drawing.Size(80, 20)
        Me.txtDifeConversion.TabIndex = 13
        Me.txtDifeConversion.Tabulado = True
        Me.txtDifeConversion.Text = "0.00"
        Me.txtDifeConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDifeConversion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtAjustePatrimonio
        '
        Me.txtAjustePatrimonio.Location = New System.Drawing.Point(174, 150)
        Me.txtAjustePatrimonio.Name = "txtAjustePatrimonio"
        Me.txtAjustePatrimonio.NroDecimales = CType(0, Short)
        Me.txtAjustePatrimonio.SelectGotFocus = True
        Me.txtAjustePatrimonio.Size = New System.Drawing.Size(80, 20)
        Me.txtAjustePatrimonio.TabIndex = 14
        Me.txtAjustePatrimonio.Tabulado = True
        Me.txtAjustePatrimonio.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtResultadoNetoEjercicio
        '
        Me.txtResultadoNetoEjercicio.Location = New System.Drawing.Point(255, 150)
        Me.txtResultadoNetoEjercicio.Name = "txtResultadoNetoEjercicio"
        Me.txtResultadoNetoEjercicio.NroDecimales = CType(0, Short)
        Me.txtResultadoNetoEjercicio.SelectGotFocus = True
        Me.txtResultadoNetoEjercicio.Size = New System.Drawing.Size(80, 20)
        Me.txtResultadoNetoEjercicio.TabIndex = 15
        Me.txtResultadoNetoEjercicio.Tabulado = True
        Me.txtResultadoNetoEjercicio.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtResultadoEjercicio
        '
        Me.txtResultadoEjercicio.Location = New System.Drawing.Point(338, 150)
        Me.txtResultadoEjercicio.Name = "txtResultadoEjercicio"
        Me.txtResultadoEjercicio.NroDecimales = CType(0, Short)
        Me.txtResultadoEjercicio.SelectGotFocus = True
        Me.txtResultadoEjercicio.Size = New System.Drawing.Size(80, 20)
        Me.txtResultadoEjercicio.TabIndex = 16
        Me.txtResultadoEjercicio.Tabulado = True
        Me.txtResultadoEjercicio.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Frm_LibLeg_PatNeto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 424)
        Me.Controls.Add(Me.txtResultadoEjercicio)
        Me.Controls.Add(Me.txtResultadoNetoEjercicio)
        Me.Controls.Add(Me.txtAjustePatrimonio)
        Me.Controls.Add(Me.txtDifeConversion)
        Me.Controls.Add(Me.txtResultadoNoRealizado)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.txtresultadoAcum)
        Me.Controls.Add(Me.txtotrasreservas)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCapitalAdicional)
        Me.Controls.Add(Me.txtAccionesInversion)
        Me.Controls.Add(Me.txtdescripcion)
        Me.Controls.Add(Me.txtcapital)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtExcedenteRevalua)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtreservalegal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCodigoPLE)
        Me.Name = "Frm_LibLeg_PatNeto"
        Me.Text = "Frm_LibLeg_PatNeto"
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnimportar As System.Windows.Forms.Button
    Friend WithEvents btninsertar As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCapitalAdicional As KS.UserControl.ksTextBox
    Friend WithEvents txtAccionesInversion As KS.UserControl.ksTextBox
    Friend WithEvents txtdescripcion As KS.UserControl.ksTextBox
    Friend WithEvents txtcapital As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtExcedenteRevalua As KS.UserControl.ksTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtreservalegal As KS.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtotrasreservas As KS.UserControl.ksTextBox
    Friend WithEvents txtresultadoAcum As KS.UserControl.ksTextBox
    Friend WithEvents txttotal As KS.UserControl.ksTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPLE As Ks.UserControl.ksTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtResultadoNoRealizado As Ks.UserControl.ksTextBox
    Friend WithEvents txtDifeConversion As Ks.UserControl.ksTextBox
    Friend WithEvents txtAjustePatrimonio As Ks.UserControl.ksTextBox
    Friend WithEvents txtResultadoNetoEjercicio As Ks.UserControl.ksTextBox
    Friend WithEvents txtResultadoEjercicio As Ks.UserControl.ksTextBox
End Class
