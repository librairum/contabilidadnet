<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cuenta_Analisis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cuenta_Analisis))
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnimprimir = New System.Windows.Forms.Button
        Me.btvistaprevia = New System.Windows.Forms.Button
        Me.btnsalir = New System.Windows.Forms.Button
        Me.txtDebAnt_0 = New KS.UserControl.ksTextBox
        Me.txtDebAnt_1 = New KS.UserControl.ksTextBox
        Me.txtHabAnt_0 = New KS.UserControl.ksTextBox
        Me.txtHabAnt_1 = New KS.UserControl.ksTextBox
        Me.txtSalAnt_0 = New KS.UserControl.ksTextBox
        Me.txtSalAnt_1 = New KS.UserControl.ksTextBox
        Me.txtDebMes_0 = New KS.UserControl.ksTextBox
        Me.txtHabMes_0 = New KS.UserControl.ksTextBox
        Me.txtDebMes_1 = New KS.UserControl.ksTextBox
        Me.txtHabMes_1 = New KS.UserControl.ksTextBox
        Me.txtSalMes_0 = New KS.UserControl.ksTextBox
        Me.txtSalMes_1 = New KS.UserControl.ksTextBox
        Me.txtSalAct_1 = New KS.UserControl.ksTextBox
        Me.txtSalAct_0 = New KS.UserControl.ksTextBox
        Me.txtHabAct_1 = New KS.UserControl.ksTextBox
        Me.txtDebAct_1 = New KS.UserControl.ksTextBox
        Me.txtHabAct_0 = New KS.UserControl.ksTextBox
        Me.txtDebAct_0 = New KS.UserControl.ksTextBox
        Me.btnhelp_0 = New System.Windows.Forms.Button
        Me.lblhelp_0 = New System.Windows.Forms.Label
        Me.txtCuenta = New KS.UserControl.ksTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnconsultar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbtanalisis_1 = New System.Windows.Forms.RadioButton
        Me.rbtanalisis_0 = New System.Windows.Forms.RadioButton
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdate = False
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.ExtendRightColumn = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(2, 136)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(734, 219)
        Me.tblconsulta.TabIndex = 191
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(744, 30)
        Me.Panel1.TabIndex = 2
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(349, 1)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 22
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(326, 1)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 21
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(692, 1)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 0
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'txtDebAnt_0
        '
        Me.txtDebAnt_0.Location = New System.Drawing.Point(179, 114)
        Me.txtDebAnt_0.MaxLength = 5
        Me.txtDebAnt_0.Name = "txtDebAnt_0"
        Me.txtDebAnt_0.NroDecimales = CType(2, Short)
        Me.txtDebAnt_0.SelectGotFocus = True
        Me.txtDebAnt_0.Size = New System.Drawing.Size(92, 20)
        Me.txtDebAnt_0.TabIndex = 193
        Me.txtDebAnt_0.Tabulado = True
        Me.txtDebAnt_0.Text = "0.00"
        Me.txtDebAnt_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebAnt_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtDebAnt_1
        '
        Me.txtDebAnt_1.ForeColor = System.Drawing.Color.Green
        Me.txtDebAnt_1.Location = New System.Drawing.Point(459, 114)
        Me.txtDebAnt_1.MaxLength = 5
        Me.txtDebAnt_1.Name = "txtDebAnt_1"
        Me.txtDebAnt_1.NroDecimales = CType(2, Short)
        Me.txtDebAnt_1.SelectGotFocus = True
        Me.txtDebAnt_1.Size = New System.Drawing.Size(92, 20)
        Me.txtDebAnt_1.TabIndex = 194
        Me.txtDebAnt_1.Tabulado = True
        Me.txtDebAnt_1.Text = "0.00"
        Me.txtDebAnt_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebAnt_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtHabAnt_0
        '
        Me.txtHabAnt_0.Location = New System.Drawing.Point(272, 114)
        Me.txtHabAnt_0.MaxLength = 5
        Me.txtHabAnt_0.Name = "txtHabAnt_0"
        Me.txtHabAnt_0.NroDecimales = CType(2, Short)
        Me.txtHabAnt_0.SelectGotFocus = True
        Me.txtHabAnt_0.Size = New System.Drawing.Size(92, 20)
        Me.txtHabAnt_0.TabIndex = 195
        Me.txtHabAnt_0.Tabulado = True
        Me.txtHabAnt_0.Text = "0.00"
        Me.txtHabAnt_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHabAnt_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtHabAnt_1
        '
        Me.txtHabAnt_1.ForeColor = System.Drawing.Color.Green
        Me.txtHabAnt_1.Location = New System.Drawing.Point(553, 114)
        Me.txtHabAnt_1.MaxLength = 5
        Me.txtHabAnt_1.Name = "txtHabAnt_1"
        Me.txtHabAnt_1.NroDecimales = CType(2, Short)
        Me.txtHabAnt_1.SelectGotFocus = True
        Me.txtHabAnt_1.Size = New System.Drawing.Size(92, 20)
        Me.txtHabAnt_1.TabIndex = 196
        Me.txtHabAnt_1.Tabulado = True
        Me.txtHabAnt_1.Text = "0.00"
        Me.txtHabAnt_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHabAnt_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtSalAnt_0
        '
        Me.txtSalAnt_0.Location = New System.Drawing.Point(366, 114)
        Me.txtSalAnt_0.MaxLength = 5
        Me.txtSalAnt_0.Name = "txtSalAnt_0"
        Me.txtSalAnt_0.NroDecimales = CType(2, Short)
        Me.txtSalAnt_0.SelectGotFocus = True
        Me.txtSalAnt_0.Size = New System.Drawing.Size(92, 20)
        Me.txtSalAnt_0.TabIndex = 197
        Me.txtSalAnt_0.Tabulado = True
        Me.txtSalAnt_0.Text = "0.00"
        Me.txtSalAnt_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSalAnt_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtSalAnt_1
        '
        Me.txtSalAnt_1.ForeColor = System.Drawing.Color.Green
        Me.txtSalAnt_1.Location = New System.Drawing.Point(646, 114)
        Me.txtSalAnt_1.MaxLength = 5
        Me.txtSalAnt_1.Name = "txtSalAnt_1"
        Me.txtSalAnt_1.NroDecimales = CType(2, Short)
        Me.txtSalAnt_1.SelectGotFocus = True
        Me.txtSalAnt_1.Size = New System.Drawing.Size(92, 20)
        Me.txtSalAnt_1.TabIndex = 198
        Me.txtSalAnt_1.Tabulado = True
        Me.txtSalAnt_1.Text = "0.00"
        Me.txtSalAnt_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSalAnt_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtDebMes_0
        '
        Me.txtDebMes_0.Location = New System.Drawing.Point(181, 363)
        Me.txtDebMes_0.MaxLength = 5
        Me.txtDebMes_0.Name = "txtDebMes_0"
        Me.txtDebMes_0.NroDecimales = CType(2, Short)
        Me.txtDebMes_0.SelectGotFocus = True
        Me.txtDebMes_0.Size = New System.Drawing.Size(92, 20)
        Me.txtDebMes_0.TabIndex = 199
        Me.txtDebMes_0.Tabulado = True
        Me.txtDebMes_0.Text = "0.00"
        Me.txtDebMes_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebMes_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtHabMes_0
        '
        Me.txtHabMes_0.Location = New System.Drawing.Point(274, 363)
        Me.txtHabMes_0.MaxLength = 5
        Me.txtHabMes_0.Name = "txtHabMes_0"
        Me.txtHabMes_0.NroDecimales = CType(2, Short)
        Me.txtHabMes_0.SelectGotFocus = True
        Me.txtHabMes_0.Size = New System.Drawing.Size(92, 20)
        Me.txtHabMes_0.TabIndex = 200
        Me.txtHabMes_0.Tabulado = True
        Me.txtHabMes_0.Text = "0.00"
        Me.txtHabMes_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHabMes_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtDebMes_1
        '
        Me.txtDebMes_1.ForeColor = System.Drawing.Color.Green
        Me.txtDebMes_1.Location = New System.Drawing.Point(461, 363)
        Me.txtDebMes_1.MaxLength = 5
        Me.txtDebMes_1.Name = "txtDebMes_1"
        Me.txtDebMes_1.NroDecimales = CType(2, Short)
        Me.txtDebMes_1.SelectGotFocus = True
        Me.txtDebMes_1.Size = New System.Drawing.Size(92, 20)
        Me.txtDebMes_1.TabIndex = 201
        Me.txtDebMes_1.Tabulado = True
        Me.txtDebMes_1.Text = "0.00"
        Me.txtDebMes_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebMes_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtHabMes_1
        '
        Me.txtHabMes_1.ForeColor = System.Drawing.Color.Green
        Me.txtHabMes_1.Location = New System.Drawing.Point(554, 363)
        Me.txtHabMes_1.MaxLength = 5
        Me.txtHabMes_1.Name = "txtHabMes_1"
        Me.txtHabMes_1.NroDecimales = CType(2, Short)
        Me.txtHabMes_1.SelectGotFocus = True
        Me.txtHabMes_1.Size = New System.Drawing.Size(92, 20)
        Me.txtHabMes_1.TabIndex = 202
        Me.txtHabMes_1.Tabulado = True
        Me.txtHabMes_1.Text = "0.00"
        Me.txtHabMes_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHabMes_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtSalMes_0
        '
        Me.txtSalMes_0.Location = New System.Drawing.Point(368, 363)
        Me.txtSalMes_0.MaxLength = 5
        Me.txtSalMes_0.Name = "txtSalMes_0"
        Me.txtSalMes_0.NroDecimales = CType(2, Short)
        Me.txtSalMes_0.SelectGotFocus = True
        Me.txtSalMes_0.Size = New System.Drawing.Size(92, 20)
        Me.txtSalMes_0.TabIndex = 203
        Me.txtSalMes_0.Tabulado = True
        Me.txtSalMes_0.Text = "0.00"
        Me.txtSalMes_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSalMes_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtSalMes_1
        '
        Me.txtSalMes_1.ForeColor = System.Drawing.Color.Green
        Me.txtSalMes_1.Location = New System.Drawing.Point(648, 363)
        Me.txtSalMes_1.MaxLength = 5
        Me.txtSalMes_1.Name = "txtSalMes_1"
        Me.txtSalMes_1.NroDecimales = CType(2, Short)
        Me.txtSalMes_1.SelectGotFocus = True
        Me.txtSalMes_1.Size = New System.Drawing.Size(92, 20)
        Me.txtSalMes_1.TabIndex = 204
        Me.txtSalMes_1.Tabulado = True
        Me.txtSalMes_1.Text = "0.00"
        Me.txtSalMes_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSalMes_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtSalAct_1
        '
        Me.txtSalAct_1.ForeColor = System.Drawing.Color.Green
        Me.txtSalAct_1.Location = New System.Drawing.Point(648, 384)
        Me.txtSalAct_1.MaxLength = 5
        Me.txtSalAct_1.Name = "txtSalAct_1"
        Me.txtSalAct_1.NroDecimales = CType(2, Short)
        Me.txtSalAct_1.SelectGotFocus = True
        Me.txtSalAct_1.Size = New System.Drawing.Size(92, 20)
        Me.txtSalAct_1.TabIndex = 210
        Me.txtSalAct_1.Tabulado = True
        Me.txtSalAct_1.Text = "0.00"
        Me.txtSalAct_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSalAct_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtSalAct_0
        '
        Me.txtSalAct_0.Location = New System.Drawing.Point(368, 384)
        Me.txtSalAct_0.MaxLength = 5
        Me.txtSalAct_0.Name = "txtSalAct_0"
        Me.txtSalAct_0.NroDecimales = CType(2, Short)
        Me.txtSalAct_0.SelectGotFocus = True
        Me.txtSalAct_0.Size = New System.Drawing.Size(92, 20)
        Me.txtSalAct_0.TabIndex = 209
        Me.txtSalAct_0.Tabulado = True
        Me.txtSalAct_0.Text = "0.00"
        Me.txtSalAct_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSalAct_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtHabAct_1
        '
        Me.txtHabAct_1.ForeColor = System.Drawing.Color.Green
        Me.txtHabAct_1.Location = New System.Drawing.Point(554, 384)
        Me.txtHabAct_1.MaxLength = 5
        Me.txtHabAct_1.Name = "txtHabAct_1"
        Me.txtHabAct_1.NroDecimales = CType(2, Short)
        Me.txtHabAct_1.SelectGotFocus = True
        Me.txtHabAct_1.Size = New System.Drawing.Size(92, 20)
        Me.txtHabAct_1.TabIndex = 208
        Me.txtHabAct_1.Tabulado = True
        Me.txtHabAct_1.Text = "0.00"
        Me.txtHabAct_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHabAct_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtDebAct_1
        '
        Me.txtDebAct_1.ForeColor = System.Drawing.Color.Green
        Me.txtDebAct_1.Location = New System.Drawing.Point(461, 384)
        Me.txtDebAct_1.MaxLength = 5
        Me.txtDebAct_1.Name = "txtDebAct_1"
        Me.txtDebAct_1.NroDecimales = CType(2, Short)
        Me.txtDebAct_1.SelectGotFocus = True
        Me.txtDebAct_1.Size = New System.Drawing.Size(92, 20)
        Me.txtDebAct_1.TabIndex = 207
        Me.txtDebAct_1.Tabulado = True
        Me.txtDebAct_1.Text = "0.00"
        Me.txtDebAct_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebAct_1.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtHabAct_0
        '
        Me.txtHabAct_0.Location = New System.Drawing.Point(274, 384)
        Me.txtHabAct_0.MaxLength = 5
        Me.txtHabAct_0.Name = "txtHabAct_0"
        Me.txtHabAct_0.NroDecimales = CType(2, Short)
        Me.txtHabAct_0.SelectGotFocus = True
        Me.txtHabAct_0.Size = New System.Drawing.Size(92, 20)
        Me.txtHabAct_0.TabIndex = 206
        Me.txtHabAct_0.Tabulado = True
        Me.txtHabAct_0.Text = "0.00"
        Me.txtHabAct_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHabAct_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'txtDebAct_0
        '
        Me.txtDebAct_0.Location = New System.Drawing.Point(181, 384)
        Me.txtDebAct_0.MaxLength = 5
        Me.txtDebAct_0.Name = "txtDebAct_0"
        Me.txtDebAct_0.NroDecimales = CType(2, Short)
        Me.txtDebAct_0.SelectGotFocus = True
        Me.txtDebAct_0.Size = New System.Drawing.Size(92, 20)
        Me.txtDebAct_0.TabIndex = 205
        Me.txtDebAct_0.Tabulado = True
        Me.txtDebAct_0.Text = "0.00"
        Me.txtDebAct_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebAct_0.ValorAceptado = KS.UserControl.ValorPermitido.enmVNumero
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(141, 48)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 214
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(160, 50)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(226, 18)
        Me.lblhelp_0.TabIndex = 213
        Me.lblhelp_0.Text = "???"
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(40, 48)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.NroDecimales = CType(0, Short)
        Me.txtCuenta.SelectGotFocus = True
        Me.txtCuenta.Size = New System.Drawing.Size(100, 20)
        Me.txtCuenta.TabIndex = 0
        Me.txtCuenta.Tabulado = True
        Me.txtCuenta.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(0, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 212
        Me.Label7.Text = "Cuenta"
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
        Me.tblhelp.Location = New System.Drawing.Point(186, 194)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(340, 140)
        Me.tblhelp.TabIndex = 215
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'btnconsultar
        '
        Me.btnconsultar.Location = New System.Drawing.Point(392, 48)
        Me.btnconsultar.Name = "btnconsultar"
        Me.btnconsultar.Size = New System.Drawing.Size(60, 23)
        Me.btnconsultar.TabIndex = 1
        Me.btnconsultar.Text = "Consultar"
        Me.btnconsultar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(4, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(722, 9)
        Me.GroupBox1.TabIndex = 217
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(182, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 218
        Me.Label1.Text = "Debe"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(276, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "Haber"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(366, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "Saldo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(462, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "Cargo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(560, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "Abono"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(648, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 223
        Me.Label6.Text = "Saldo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(49, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 16)
        Me.Label8.TabIndex = 224
        Me.Label8.Text = "Acum al Mes Anterior"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(64, 363)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 18)
        Me.Label9.TabIndex = 225
        Me.Label9.Text = "Acum - del Mes"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(64, 386)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 18)
        Me.Label10.TabIndex = 226
        Me.Label10.Text = "Acum - al Mes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtanalisis_1)
        Me.GroupBox2.Controls.Add(Me.rbtanalisis_0)
        Me.GroupBox2.Location = New System.Drawing.Point(456, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(269, 51)
        Me.GroupBox2.TabIndex = 227
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones "
        '
        'rbtanalisis_1
        '
        Me.rbtanalisis_1.AutoSize = True
        Me.rbtanalisis_1.Location = New System.Drawing.Point(6, 30)
        Me.rbtanalisis_1.Name = "rbtanalisis_1"
        Me.rbtanalisis_1.Size = New System.Drawing.Size(263, 17)
        Me.rbtanalisis_1.TabIndex = 1
        Me.rbtanalisis_1.Text = "Análisis del Movimiento - Acumulado al Mes Actual"
        Me.rbtanalisis_1.UseVisualStyleBackColor = True
        '
        'rbtanalisis_0
        '
        Me.rbtanalisis_0.AutoSize = True
        Me.rbtanalisis_0.Checked = True
        Me.rbtanalisis_0.Location = New System.Drawing.Point(5, 15)
        Me.rbtanalisis_0.Name = "rbtanalisis_0"
        Me.rbtanalisis_0.Size = New System.Drawing.Size(213, 17)
        Me.rbtanalisis_0.TabIndex = 0
        Me.rbtanalisis_0.TabStop = True
        Me.rbtanalisis_0.Text = "Análisis del Movimiento - del Mes Actual"
        Me.rbtanalisis_0.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(4, 138)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 228
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'Frm_Cuenta_Analisis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 413)
        Me.Controls.Add(Me.btnseleccionartodo_0)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnconsultar)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSalAct_1)
        Me.Controls.Add(Me.txtSalAct_0)
        Me.Controls.Add(Me.txtHabAct_1)
        Me.Controls.Add(Me.txtDebAct_1)
        Me.Controls.Add(Me.txtHabAct_0)
        Me.Controls.Add(Me.txtDebAct_0)
        Me.Controls.Add(Me.txtSalMes_1)
        Me.Controls.Add(Me.txtSalMes_0)
        Me.Controls.Add(Me.txtHabMes_1)
        Me.Controls.Add(Me.txtDebMes_1)
        Me.Controls.Add(Me.txtHabMes_0)
        Me.Controls.Add(Me.txtDebMes_0)
        Me.Controls.Add(Me.txtSalAnt_1)
        Me.Controls.Add(Me.txtSalAnt_0)
        Me.Controls.Add(Me.txtHabAnt_1)
        Me.Controls.Add(Me.txtHabAnt_0)
        Me.Controls.Add(Me.txtDebAnt_1)
        Me.Controls.Add(Me.txtDebAnt_0)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Name = "Frm_Cuenta_Analisis"
        Me.Text = "Frm_Cuenta_Analisis"
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents txtDebAnt_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtDebAnt_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtHabAnt_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtHabAnt_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtSalAnt_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtSalAnt_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtDebMes_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtHabMes_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtDebMes_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtHabMes_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtSalMes_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtSalMes_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtSalAct_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtSalAct_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtHabAct_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtDebAct_1 As KS.UserControl.ksTextBox
    Friend WithEvents txtHabAct_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtDebAct_0 As Ks.UserControl.ksTextBox
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As Ks.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnconsultar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtanalisis_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtanalisis_0 As System.Windows.Forms.RadioButton
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
End Class
