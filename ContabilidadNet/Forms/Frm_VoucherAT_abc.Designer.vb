<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_VoucherAT_abc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_VoucherAT_abc))
        Me.txtSaldoDolares = New KS.UserControl.ksTextBox()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.lnkNuevo = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lnkmodificar = New System.Windows.Forms.LinkLabel()
        Me.txtTotalHaberDolares = New KS.UserControl.ksTextBox()
        Me.txtTotalDebeDolares = New KS.UserControl.ksTextBox()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.txtSaldoSoles = New KS.UserControl.ksTextBox()
        Me.txtTotalHaberSoles = New KS.UserControl.ksTextBox()
        Me.txtTotalDebeSoles = New KS.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lnkeliminar = New System.Windows.Forms.LinkLabel()
        Me.mskfecha = New System.Windows.Forms.MaskedTextBox()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtlibro = New KS.UserControl.ksTextBox()
        Me.lnkver = New System.Windows.Forms.LinkLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnultimo = New System.Windows.Forms.Button()
        Me.btnsiguiente = New System.Windows.Forms.Button()
        Me.btnanterior = New System.Windows.Forms.Button()
        Me.btnprimero = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtNoVoucher = New KS.UserControl.ksTextBox()
        Me.grbmantodet = New System.Windows.Forms.GroupBox()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnreferencias = New System.Windows.Forms.Button()
        Me.btnDetraccion = New System.Windows.Forms.Button()
        Me.grbdatoscab = New System.Windows.Forms.GroupBox()
        Me.txtDescri = New KS.UserControl.ksTextBox()
        Me.btncancelaat = New System.Windows.Forms.Button()
        Me.btngenerarat = New System.Windows.Forms.Button()
        Me.grbdatosdet = New System.Windows.Forms.GroupBox()
        Me.cbomoneda = New System.Windows.Forms.ComboBox()
        Me.lblhelp_3 = New System.Windows.Forms.Label()
        Me.btnhelp_3 = New System.Windows.Forms.Button()
        Me.txtCtaCte = New KS.UserControl.ksTextBox()
        Me.lblctacte = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTipCambio = New KS.UserControl.ksTextBox()
        Me.txtimporte = New KS.UserControl.ksTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcomprobante = New KS.UserControl.ksTextBox()
        Me.btnhelp_2 = New System.Windows.Forms.Button()
        Me.lblhelp_2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNoDoc = New KS.UserControl.ksTextBox()
        Me.txtTipDoc = New KS.UserControl.ksTextBox()
        Me.txtasientotipo = New KS.UserControl.ksTextBox()
        Me.lblasientotipo = New System.Windows.Forms.Label()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lbltotalregistros = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.grbmantodet.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbdatoscab.SuspendLayout()
        Me.grbdatosdet.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSaldoDolares
        '
        Me.txtSaldoDolares.Location = New System.Drawing.Point(933, 566)
        Me.txtSaldoDolares.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSaldoDolares.Name = "txtSaldoDolares"
        Me.txtSaldoDolares.NroDecimales = CType(2, Short)
        Me.txtSaldoDolares.SelectGotFocus = True
        Me.txtSaldoDolares.Size = New System.Drawing.Size(148, 26)
        Me.txtSaldoDolares.TabIndex = 226
        Me.txtSaldoDolares.Tabulado = True
        Me.txtSaldoDolares.Text = "0.00"
        Me.txtSaldoDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoDolares.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(105, 2)
        Me.btngrabar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(36, 37)
        Me.btngrabar.TabIndex = 2
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'lnkNuevo
        '
        Me.lnkNuevo.AutoSize = True
        Me.lnkNuevo.Location = New System.Drawing.Point(3, 6)
        Me.lnkNuevo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lnkNuevo.Name = "lnkNuevo"
        Me.lnkNuevo.Size = New System.Drawing.Size(66, 20)
        Me.lnkNuevo.TabIndex = 193
        Me.lnkNuevo.TabStop = True
        Me.lnkNuevo.Text = "Agregar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(507, 569)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 20)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Total Dolares"
        '
        'lnkmodificar
        '
        Me.lnkmodificar.AutoSize = True
        Me.lnkmodificar.Location = New System.Drawing.Point(72, 6)
        Me.lnkmodificar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lnkmodificar.Name = "lnkmodificar"
        Me.lnkmodificar.Size = New System.Drawing.Size(73, 20)
        Me.lnkmodificar.TabIndex = 202
        Me.lnkmodificar.TabStop = True
        Me.lnkmodificar.Text = "Modificar"
        '
        'txtTotalHaberDolares
        '
        Me.txtTotalHaberDolares.Location = New System.Drawing.Point(783, 566)
        Me.txtTotalHaberDolares.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotalHaberDolares.Name = "txtTotalHaberDolares"
        Me.txtTotalHaberDolares.NroDecimales = CType(2, Short)
        Me.txtTotalHaberDolares.SelectGotFocus = True
        Me.txtTotalHaberDolares.Size = New System.Drawing.Size(148, 26)
        Me.txtTotalHaberDolares.TabIndex = 225
        Me.txtTotalHaberDolares.Tabulado = True
        Me.txtTotalHaberDolares.Text = "0.00"
        Me.txtTotalHaberDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalHaberDolares.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtTotalDebeDolares
        '
        Me.txtTotalDebeDolares.Location = New System.Drawing.Point(633, 566)
        Me.txtTotalDebeDolares.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotalDebeDolares.Name = "txtTotalDebeDolares"
        Me.txtTotalDebeDolares.NroDecimales = CType(2, Short)
        Me.txtTotalDebeDolares.SelectGotFocus = True
        Me.txtTotalDebeDolares.Size = New System.Drawing.Size(148, 26)
        Me.txtTotalDebeDolares.TabIndex = 224
        Me.txtTotalDebeDolares.Tabulado = True
        Me.txtTotalDebeDolares.Text = "0.00"
        Me.txtTotalDebeDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDebeDolares.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(138, 2)
        Me.btncancelar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(36, 37)
        Me.btncancelar.TabIndex = 3
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'txtSaldoSoles
        '
        Me.txtSaldoSoles.Location = New System.Drawing.Point(933, 535)
        Me.txtSaldoSoles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSaldoSoles.Name = "txtSaldoSoles"
        Me.txtSaldoSoles.NroDecimales = CType(2, Short)
        Me.txtSaldoSoles.SelectGotFocus = True
        Me.txtSaldoSoles.Size = New System.Drawing.Size(148, 26)
        Me.txtSaldoSoles.TabIndex = 223
        Me.txtSaldoSoles.Tabulado = True
        Me.txtSaldoSoles.Text = "0.00"
        Me.txtSaldoSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoSoles.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtTotalHaberSoles
        '
        Me.txtTotalHaberSoles.Location = New System.Drawing.Point(783, 535)
        Me.txtTotalHaberSoles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotalHaberSoles.Name = "txtTotalHaberSoles"
        Me.txtTotalHaberSoles.NroDecimales = CType(2, Short)
        Me.txtTotalHaberSoles.SelectGotFocus = True
        Me.txtTotalHaberSoles.Size = New System.Drawing.Size(148, 26)
        Me.txtTotalHaberSoles.TabIndex = 222
        Me.txtTotalHaberSoles.Tabulado = True
        Me.txtTotalHaberSoles.Text = "0.00"
        Me.txtTotalHaberSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalHaberSoles.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtTotalDebeSoles
        '
        Me.txtTotalDebeSoles.Location = New System.Drawing.Point(633, 535)
        Me.txtTotalDebeSoles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotalDebeSoles.Name = "txtTotalDebeSoles"
        Me.txtTotalDebeSoles.NroDecimales = CType(2, Short)
        Me.txtTotalDebeSoles.SelectGotFocus = True
        Me.txtTotalDebeSoles.Size = New System.Drawing.Size(148, 26)
        Me.txtTotalDebeSoles.TabIndex = 221
        Me.txtTotalDebeSoles.Tabulado = True
        Me.txtTotalDebeSoles.Text = "0.00"
        Me.txtTotalDebeSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDebeSoles.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(525, 542)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 220
        Me.Label5.Text = "Total Soles"
        '
        'lnkeliminar
        '
        Me.lnkeliminar.AutoSize = True
        Me.lnkeliminar.Location = New System.Drawing.Point(150, 6)
        Me.lnkeliminar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lnkeliminar.Name = "lnkeliminar"
        Me.lnkeliminar.Size = New System.Drawing.Size(65, 20)
        Me.lnkeliminar.TabIndex = 203
        Me.lnkeliminar.TabStop = True
        Me.lnkeliminar.Text = "Eliminar"
        '
        'mskfecha
        '
        Me.mskfecha.Location = New System.Drawing.Point(534, 28)
        Me.mskfecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.mskfecha.Mask = "00/00/0000"
        Me.mskfecha.Name = "mskfecha"
        Me.mskfecha.Size = New System.Drawing.Size(100, 26)
        Me.mskfecha.TabIndex = 2
        Me.mskfecha.ValidatingType = GetType(Date)
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
        Me.tblconsulta.Location = New System.Drawing.Point(9, 289)
        Me.tblconsulta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(1079, 239)
        Me.tblconsulta.TabIndex = 217
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(351, -3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(309, 25)
        Me.GroupBox1.TabIndex = 205
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DETALLES DE VOUCHER"
        '
        'txtlibro
        '
        Me.txtlibro.Location = New System.Drawing.Point(54, 28)
        Me.txtlibro.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtlibro.Name = "txtlibro"
        Me.txtlibro.NroDecimales = CType(0, Short)
        Me.txtlibro.SelectGotFocus = True
        Me.txtlibro.Size = New System.Drawing.Size(40, 26)
        Me.txtlibro.TabIndex = 0
        Me.txtlibro.Tabulado = True
        Me.txtlibro.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'lnkver
        '
        Me.lnkver.AutoSize = True
        Me.lnkver.Location = New System.Drawing.Point(219, 6)
        Me.lnkver.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lnkver.Name = "lnkver"
        Me.lnkver.Size = New System.Drawing.Size(34, 20)
        Me.lnkver.TabIndex = 204
        Me.lnkver.TabStop = True
        Me.lnkver.Text = "Ver"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 601)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1100, 48)
        Me.Panel3.TabIndex = 216
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.btnultimo)
        Me.Panel8.Controls.Add(Me.btnsiguiente)
        Me.Panel8.Controls.Add(Me.btnanterior)
        Me.Panel8.Controls.Add(Me.btnprimero)
        Me.Panel8.Location = New System.Drawing.Point(357, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(276, 46)
        Me.Panel8.TabIndex = 1
        '
        'btnultimo
        '
        Me.btnultimo.Location = New System.Drawing.Point(177, 3)
        Me.btnultimo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnultimo.Name = "btnultimo"
        Me.btnultimo.Size = New System.Drawing.Size(45, 37)
        Me.btnultimo.TabIndex = 3
        Me.btnultimo.Text = ">>"
        Me.btnultimo.UseVisualStyleBackColor = True
        '
        'btnsiguiente
        '
        Me.btnsiguiente.Location = New System.Drawing.Point(132, 3)
        Me.btnsiguiente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnsiguiente.Name = "btnsiguiente"
        Me.btnsiguiente.Size = New System.Drawing.Size(45, 37)
        Me.btnsiguiente.TabIndex = 2
        Me.btnsiguiente.Text = ">"
        Me.btnsiguiente.UseVisualStyleBackColor = True
        '
        'btnanterior
        '
        Me.btnanterior.Location = New System.Drawing.Point(87, 3)
        Me.btnanterior.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnanterior.Name = "btnanterior"
        Me.btnanterior.Size = New System.Drawing.Size(45, 37)
        Me.btnanterior.TabIndex = 1
        Me.btnanterior.Text = "<"
        Me.btnanterior.UseVisualStyleBackColor = True
        '
        'btnprimero
        '
        Me.btnprimero.Location = New System.Drawing.Point(45, 3)
        Me.btnprimero.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnprimero.Name = "btnprimero"
        Me.btnprimero.Size = New System.Drawing.Size(45, 37)
        Me.btnprimero.TabIndex = 0
        Me.btnprimero.Text = "<<"
        Me.btnprimero.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(477, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(642, 34)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Glosa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(312, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Numero"
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(72, 2)
        Me.btneliminar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(36, 37)
        Me.btneliminar.TabIndex = 1
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(39, 2)
        Me.btnmodificar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(36, 37)
        Me.btnmodificar.TabIndex = 0
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(6, 2)
        Me.btnnuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(36, 37)
        Me.btnnuevo.TabIndex = 50
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Libro"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(96, 28)
        Me.btnhelp_0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(33, 34)
        Me.btnhelp_0.TabIndex = 5
        Me.btnhelp_0.TabStop = False
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(129, 31)
        Me.lblhelp_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(168, 28)
        Me.lblhelp_0.TabIndex = 6
        Me.lblhelp_0.Text = "???"
        '
        'txtNoVoucher
        '
        Me.txtNoVoucher.Location = New System.Drawing.Point(378, 28)
        Me.txtNoVoucher.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNoVoucher.MaxLength = 5
        Me.txtNoVoucher.Name = "txtNoVoucher"
        Me.txtNoVoucher.NroDecimales = CType(0, Short)
        Me.txtNoVoucher.SelectGotFocus = True
        Me.txtNoVoucher.Size = New System.Drawing.Size(91, 26)
        Me.txtNoVoucher.TabIndex = 1
        Me.txtNoVoucher.Tabulado = True
        Me.txtNoVoucher.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'grbmantodet
        '
        Me.grbmantodet.Controls.Add(Me.GroupBox1)
        Me.grbmantodet.Controls.Add(Me.lnkver)
        Me.grbmantodet.Controls.Add(Me.lnkNuevo)
        Me.grbmantodet.Controls.Add(Me.lnkmodificar)
        Me.grbmantodet.Controls.Add(Me.lnkeliminar)
        Me.grbmantodet.Location = New System.Drawing.Point(12, 255)
        Me.grbmantodet.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbmantodet.Name = "grbmantodet"
        Me.grbmantodet.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbmantodet.Size = New System.Drawing.Size(1065, 37)
        Me.grbmantodet.TabIndex = 229
        Me.grbmantodet.TabStop = False
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(1038, -2)
        Me.btnsalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(36, 37)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnreferencias)
        Me.Panel1.Controls.Add(Me.btnDetraccion)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 46)
        Me.Panel1.TabIndex = 6
        '
        'btnreferencias
        '
        Me.btnreferencias.Image = Global.ContabilidadNet.My.Resources.Resources.referencias
        Me.btnreferencias.Location = New System.Drawing.Point(573, 2)
        Me.btnreferencias.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnreferencias.Name = "btnreferencias"
        Me.btnreferencias.Size = New System.Drawing.Size(36, 37)
        Me.btnreferencias.TabIndex = 56
        Me.btnreferencias.UseVisualStyleBackColor = True
        '
        'btnDetraccion
        '
        Me.btnDetraccion.Image = Global.ContabilidadNet.My.Resources.Resources.registrar
        Me.btnDetraccion.Location = New System.Drawing.Point(536, 0)
        Me.btnDetraccion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDetraccion.Name = "btnDetraccion"
        Me.btnDetraccion.Size = New System.Drawing.Size(36, 37)
        Me.btnDetraccion.TabIndex = 54
        Me.btnDetraccion.UseVisualStyleBackColor = True
        '
        'grbdatoscab
        '
        Me.grbdatoscab.Controls.Add(Me.txtDescri)
        Me.grbdatoscab.Controls.Add(Me.mskfecha)
        Me.grbdatoscab.Controls.Add(Me.txtlibro)
        Me.grbdatoscab.Controls.Add(Me.Label4)
        Me.grbdatoscab.Controls.Add(Me.Label3)
        Me.grbdatoscab.Controls.Add(Me.Label2)
        Me.grbdatoscab.Controls.Add(Me.Label1)
        Me.grbdatoscab.Controls.Add(Me.btnhelp_0)
        Me.grbdatoscab.Controls.Add(Me.lblhelp_0)
        Me.grbdatoscab.Controls.Add(Me.txtNoVoucher)
        Me.grbdatoscab.Location = New System.Drawing.Point(9, 80)
        Me.grbdatoscab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbdatoscab.Name = "grbdatoscab"
        Me.grbdatoscab.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbdatoscab.Size = New System.Drawing.Size(1068, 68)
        Me.grbdatoscab.TabIndex = 1
        Me.grbdatoscab.TabStop = False
        Me.grbdatoscab.Text = "Datos de cabecera del voucher"
        '
        'txtDescri
        '
        Me.txtDescri.Location = New System.Drawing.Point(693, 28)
        Me.txtDescri.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDescri.MaxLength = 80
        Me.txtDescri.Name = "txtDescri"
        Me.txtDescri.NroDecimales = CType(0, Short)
        Me.txtDescri.SelectGotFocus = True
        Me.txtDescri.Size = New System.Drawing.Size(358, 26)
        Me.txtDescri.TabIndex = 3
        Me.txtDescri.Tabulado = True
        Me.txtDescri.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'btncancelaat
        '
        Me.btncancelaat.Location = New System.Drawing.Point(939, 200)
        Me.btncancelaat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btncancelaat.Name = "btncancelaat"
        Me.btncancelaat.Size = New System.Drawing.Size(112, 35)
        Me.btncancelaat.TabIndex = 4
        Me.btncancelaat.Text = "Cancelar"
        Me.btncancelaat.UseVisualStyleBackColor = True
        '
        'btngenerarat
        '
        Me.btngenerarat.Location = New System.Drawing.Point(939, 166)
        Me.btngenerarat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btngenerarat.Name = "btngenerarat"
        Me.btngenerarat.Size = New System.Drawing.Size(112, 35)
        Me.btngenerarat.TabIndex = 3
        Me.btngenerarat.Text = "Generar"
        Me.btngenerarat.UseVisualStyleBackColor = True
        '
        'grbdatosdet
        '
        Me.grbdatosdet.BackColor = System.Drawing.SystemColors.Control
        Me.grbdatosdet.Controls.Add(Me.cbomoneda)
        Me.grbdatosdet.Controls.Add(Me.lblhelp_3)
        Me.grbdatosdet.Controls.Add(Me.btnhelp_3)
        Me.grbdatosdet.Controls.Add(Me.txtCtaCte)
        Me.grbdatosdet.Controls.Add(Me.lblctacte)
        Me.grbdatosdet.Controls.Add(Me.Label7)
        Me.grbdatosdet.Controls.Add(Me.txtTipCambio)
        Me.grbdatosdet.Controls.Add(Me.txtimporte)
        Me.grbdatosdet.Controls.Add(Me.Label17)
        Me.grbdatosdet.Controls.Add(Me.Label12)
        Me.grbdatosdet.Controls.Add(Me.Label11)
        Me.grbdatosdet.Controls.Add(Me.Label9)
        Me.grbdatosdet.Controls.Add(Me.txtcomprobante)
        Me.grbdatosdet.Controls.Add(Me.btnhelp_2)
        Me.grbdatosdet.Controls.Add(Me.lblhelp_2)
        Me.grbdatosdet.Controls.Add(Me.Label10)
        Me.grbdatosdet.Controls.Add(Me.txtNoDoc)
        Me.grbdatosdet.Controls.Add(Me.txtTipDoc)
        Me.grbdatosdet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbdatosdet.Location = New System.Drawing.Point(9, 145)
        Me.grbdatosdet.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbdatosdet.Name = "grbdatosdet"
        Me.grbdatosdet.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grbdatosdet.Size = New System.Drawing.Size(924, 98)
        Me.grbdatosdet.TabIndex = 2
        Me.grbdatosdet.TabStop = False
        Me.grbdatosdet.Text = "Datos para generar del detalle del voucher"
        '
        'cbomoneda
        '
        Me.cbomoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomoneda.FormattingEnabled = True
        Me.cbomoneda.Items.AddRange(New Object() {"S", "D"})
        Me.cbomoneda.Location = New System.Drawing.Point(300, 25)
        Me.cbomoneda.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbomoneda.Name = "cbomoneda"
        Me.cbomoneda.Size = New System.Drawing.Size(61, 28)
        Me.cbomoneda.TabIndex = 1
        '
        'lblhelp_3
        '
        Me.lblhelp_3.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_3.Location = New System.Drawing.Point(258, 58)
        Me.lblhelp_3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblhelp_3.Name = "lblhelp_3"
        Me.lblhelp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_3.Size = New System.Drawing.Size(156, 31)
        Me.lblhelp_3.TabIndex = 259
        Me.lblhelp_3.Text = "???"
        '
        'btnhelp_3
        '
        Me.btnhelp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_3.Location = New System.Drawing.Point(225, 58)
        Me.btnhelp_3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnhelp_3.Name = "btnhelp_3"
        Me.btnhelp_3.Size = New System.Drawing.Size(33, 34)
        Me.btnhelp_3.TabIndex = 260
        Me.btnhelp_3.TabStop = False
        Me.btnhelp_3.Text = ":::"
        Me.btnhelp_3.UseVisualStyleBackColor = True
        '
        'txtCtaCte
        '
        Me.txtCtaCte.Location = New System.Drawing.Point(75, 58)
        Me.txtCtaCte.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCtaCte.Name = "txtCtaCte"
        Me.txtCtaCte.NroDecimales = CType(0, Short)
        Me.txtCtaCte.SelectGotFocus = True
        Me.txtCtaCte.Size = New System.Drawing.Size(148, 26)
        Me.txtCtaCte.TabIndex = 4
        Me.txtCtaCte.Tabulado = True
        Me.txtCtaCte.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'lblctacte
        '
        Me.lblctacte.AutoSize = True
        Me.lblctacte.Location = New System.Drawing.Point(12, 65)
        Me.lblctacte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblctacte.Name = "lblctacte"
        Me.lblctacte.Size = New System.Drawing.Size(65, 20)
        Me.lblctacte.TabIndex = 257
        Me.lblctacte.Text = "Cta.Cte"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(396, 31)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 255
        Me.Label7.Text = "Tip.Cambio"
        '
        'txtTipCambio
        '
        Me.txtTipCambio.Location = New System.Drawing.Point(486, 25)
        Me.txtTipCambio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.NroDecimales = CType(4, Short)
        Me.txtTipCambio.SelectGotFocus = True
        Me.txtTipCambio.Size = New System.Drawing.Size(109, 26)
        Me.txtTipCambio.TabIndex = 2
        Me.txtTipCambio.Tabulado = True
        Me.txtTipCambio.Text = "0.0000"
        Me.txtTipCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipCambio.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtimporte
        '
        Me.txtimporte.Location = New System.Drawing.Point(765, 25)
        Me.txtimporte.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.NroDecimales = CType(2, Short)
        Me.txtimporte.SelectGotFocus = True
        Me.txtimporte.Size = New System.Drawing.Size(151, 26)
        Me.txtimporte.TabIndex = 3
        Me.txtimporte.Tabulado = True
        Me.txtimporte.Text = "0.00"
        Me.txtimporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtimporte.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(234, 31)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 20)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Moneda"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(702, 31)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 20)
        Me.Label12.TabIndex = 250
        Me.Label12.Text = "Importe"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(696, 65)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 20)
        Me.Label11.TabIndex = 249
        Me.Label11.Text = "Nº  Doc"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 34)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 20)
        Me.Label9.TabIndex = 248
        Me.Label9.Text = "Comprobante"
        '
        'txtcomprobante
        '
        Me.txtcomprobante.Location = New System.Drawing.Point(117, 25)
        Me.txtcomprobante.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtcomprobante.Name = "txtcomprobante"
        Me.txtcomprobante.NroDecimales = CType(0, Short)
        Me.txtcomprobante.SelectGotFocus = True
        Me.txtcomprobante.Size = New System.Drawing.Size(106, 26)
        Me.txtcomprobante.TabIndex = 0
        Me.txtcomprobante.Tabulado = True
        Me.txtcomprobante.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_2
        '
        Me.btnhelp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_2.Location = New System.Drawing.Point(534, 58)
        Me.btnhelp_2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnhelp_2.Name = "btnhelp_2"
        Me.btnhelp_2.Size = New System.Drawing.Size(33, 34)
        Me.btnhelp_2.TabIndex = 246
        Me.btnhelp_2.TabStop = False
        Me.btnhelp_2.Text = ":::"
        Me.btnhelp_2.UseVisualStyleBackColor = True
        '
        'lblhelp_2
        '
        Me.lblhelp_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_2.Location = New System.Drawing.Point(567, 62)
        Me.lblhelp_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblhelp_2.Name = "lblhelp_2"
        Me.lblhelp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_2.Size = New System.Drawing.Size(123, 28)
        Me.lblhelp_2.TabIndex = 245
        Me.lblhelp_2.Text = "???"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(417, 65)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 20)
        Me.Label10.TabIndex = 244
        Me.Label10.Text = "Tip Doc"
        '
        'txtNoDoc
        '
        Me.txtNoDoc.Location = New System.Drawing.Point(765, 58)
        Me.txtNoDoc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNoDoc.Name = "txtNoDoc"
        Me.txtNoDoc.NroDecimales = CType(0, Short)
        Me.txtNoDoc.SelectGotFocus = True
        Me.txtNoDoc.Size = New System.Drawing.Size(151, 26)
        Me.txtNoDoc.TabIndex = 6
        Me.txtNoDoc.Tabulado = True
        Me.txtNoDoc.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'txtTipDoc
        '
        Me.txtTipDoc.Location = New System.Drawing.Point(486, 58)
        Me.txtTipDoc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTipDoc.Name = "txtTipDoc"
        Me.txtTipDoc.NroDecimales = CType(0, Short)
        Me.txtTipDoc.SelectGotFocus = True
        Me.txtTipDoc.Size = New System.Drawing.Size(46, 26)
        Me.txtTipDoc.TabIndex = 5
        Me.txtTipDoc.Tabulado = True
        Me.txtTipDoc.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'txtasientotipo
        '
        Me.txtasientotipo.Location = New System.Drawing.Point(120, 49)
        Me.txtasientotipo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtasientotipo.Name = "txtasientotipo"
        Me.txtasientotipo.NroDecimales = CType(0, Short)
        Me.txtasientotipo.SelectGotFocus = True
        Me.txtasientotipo.Size = New System.Drawing.Size(145, 26)
        Me.txtasientotipo.TabIndex = 0
        Me.txtasientotipo.Tabulado = True
        Me.txtasientotipo.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'lblasientotipo
        '
        Me.lblasientotipo.AutoSize = True
        Me.lblasientotipo.Location = New System.Drawing.Point(15, 52)
        Me.lblasientotipo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblasientotipo.Name = "lblasientotipo"
        Me.lblasientotipo.Size = New System.Drawing.Size(97, 20)
        Me.lblasientotipo.TabIndex = 5
        Me.lblasientotipo.Text = "Asiento Tipo"
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(267, 46)
        Me.btnhelp_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(33, 34)
        Me.btnhelp_1.TabIndex = 235
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(303, 49)
        Me.lblhelp_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(774, 28)
        Me.lblhelp_1.TabIndex = 233
        Me.lblhelp_1.Text = "???"
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
        Me.tblhelp.Location = New System.Drawing.Point(300, 237)
        Me.tblhelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(509, 214)
        Me.tblhelp.TabIndex = 236
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'lbltotalregistros
        '
        Me.lbltotalregistros.AutoSize = True
        Me.lbltotalregistros.Location = New System.Drawing.Point(186, 542)
        Me.lbltotalregistros.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltotalregistros.Name = "lbltotalregistros"
        Me.lbltotalregistros.Size = New System.Drawing.Size(18, 20)
        Me.lbltotalregistros.TabIndex = 238
        Me.lbltotalregistros.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 542)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(158, 20)
        Me.Label8.TabIndex = 237
        Me.Label8.Text = "Total de registros"
        '
        'Frm_VoucherAT_abc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 649)
        Me.Controls.Add(Me.lbltotalregistros)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.txtasientotipo)
        Me.Controls.Add(Me.grbdatosdet)
        Me.Controls.Add(Me.lblasientotipo)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.grbdatoscab)
        Me.Controls.Add(Me.txtSaldoDolares)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotalHaberDolares)
        Me.Controls.Add(Me.txtTotalDebeDolares)
        Me.Controls.Add(Me.txtSaldoSoles)
        Me.Controls.Add(Me.txtTotalHaberSoles)
        Me.Controls.Add(Me.txtTotalDebeSoles)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grbmantodet)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btngenerarat)
        Me.Controls.Add(Me.btncancelaat)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Frm_VoucherAT_abc"
        Me.Text = "Frm_VoucherAT_abc"
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.grbmantodet.ResumeLayout(False)
        Me.grbmantodet.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grbdatoscab.ResumeLayout(False)
        Me.grbdatoscab.PerformLayout()
        Me.grbdatosdet.ResumeLayout(False)
        Me.grbdatosdet.PerformLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSaldoDolares As Ks.UserControl.ksTextBox
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents lnkNuevo As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lnkmodificar As System.Windows.Forms.LinkLabel
    Friend WithEvents txtTotalHaberDolares As Ks.UserControl.ksTextBox
    Friend WithEvents txtTotalDebeDolares As Ks.UserControl.ksTextBox
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents txtSaldoSoles As Ks.UserControl.ksTextBox
    Friend WithEvents txtTotalHaberSoles As Ks.UserControl.ksTextBox
    Friend WithEvents txtTotalDebeSoles As Ks.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lnkeliminar As System.Windows.Forms.LinkLabel
    Friend WithEvents mskfecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtlibro As Ks.UserControl.ksTextBox
    Friend WithEvents lnkver As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnultimo As System.Windows.Forms.Button
    Friend WithEvents btnsiguiente As System.Windows.Forms.Button
    Friend WithEvents btnanterior As System.Windows.Forms.Button
    Friend WithEvents btnprimero As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtNoVoucher As Ks.UserControl.ksTextBox
    Friend WithEvents grbmantodet As System.Windows.Forms.GroupBox
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grbdatoscab As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescri As Ks.UserControl.ksTextBox
    Friend WithEvents grbdatosdet As System.Windows.Forms.GroupBox
    Friend WithEvents txtasientotipo As KS.UserControl.ksTextBox
    Friend WithEvents lblasientotipo As System.Windows.Forms.Label
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txtimporte As Ks.UserControl.ksTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcomprobante As Ks.UserControl.ksTextBox
    Friend WithEvents btnhelp_2 As System.Windows.Forms.Button
    Public WithEvents lblhelp_2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNoDoc As Ks.UserControl.ksTextBox
    Friend WithEvents txtTipDoc As Ks.UserControl.ksTextBox
    Friend WithEvents btngenerarat As System.Windows.Forms.Button
    Friend WithEvents btncancelaat As System.Windows.Forms.Button
    Friend WithEvents txtTipCambio As KS.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents lblhelp_3 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_3 As System.Windows.Forms.Button
    Friend WithEvents txtCtaCte As KS.UserControl.ksTextBox
    Friend WithEvents lblctacte As System.Windows.Forms.Label
    Friend WithEvents cbomoneda As System.Windows.Forms.ComboBox
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnDetraccion As System.Windows.Forms.Button
    Friend WithEvents lbltotalregistros As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnreferencias As System.Windows.Forms.Button
End Class
