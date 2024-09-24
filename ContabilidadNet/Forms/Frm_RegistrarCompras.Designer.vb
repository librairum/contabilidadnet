<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegistrarCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegistrarCompras))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.button_help_top = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.btn_Contabilizar_Bloque = New System.Windows.Forms.Button()
        Me.GrRegistrarBloque = New System.Windows.Forms.GroupBox()
        Me.txtNomenclatura = New KS.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.txtCentroCosto = New KS.UserControl.ksTextBox()
        Me.txtLibro = New KS.UserControl.ksTextBox()
        Me.txtAsientoDesc = New KS.UserControl.ksTextBox()
        Me.BtnCentroCosto = New System.Windows.Forms.Button()
        Me.txtAsientoCod = New KS.UserControl.ksTextBox()
        Me.BtnAsientoT = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtConcepto = New KS.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblhelp1_bloque = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        Me.GrRegistrarBloque.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.tblhelp1_bloque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 323)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1104, 31)
        Me.Panel3.TabIndex = 189
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.button_help_top)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1104, 31)
        Me.Panel1.TabIndex = 191
        '
        'button_help_top
        '
        Me.button_help_top.Image = Global.ContabilidadNet.My.Resources.Resources._16__Grid_select_grid_2_
        Me.button_help_top.Location = New System.Drawing.Point(662, 2)
        Me.button_help_top.Name = "button_help_top"
        Me.button_help_top.Size = New System.Drawing.Size(24, 24)
        Me.button_help_top.TabIndex = 55
        Me.button_help_top.UseVisualStyleBackColor = True
        Me.button_help_top.Visible = False
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
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(393, 47)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 200
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        Me.btnhelp_0.Visible = False
        '
        'btn_Contabilizar_Bloque
        '
        Me.btn_Contabilizar_Bloque.Image = CType(resources.GetObject("btn_Contabilizar_Bloque.Image"), System.Drawing.Image)
        Me.btn_Contabilizar_Bloque.Location = New System.Drawing.Point(1018, 46)
        Me.btn_Contabilizar_Bloque.Name = "btn_Contabilizar_Bloque"
        Me.btn_Contabilizar_Bloque.Size = New System.Drawing.Size(61, 23)
        Me.btn_Contabilizar_Bloque.TabIndex = 203
        Me.btn_Contabilizar_Bloque.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Contabilizar_Bloque.UseVisualStyleBackColor = True
        '
        'GrRegistrarBloque
        '
        Me.GrRegistrarBloque.Controls.Add(Me.txtNomenclatura)
        Me.GrRegistrarBloque.Controls.Add(Me.Label5)
        Me.GrRegistrarBloque.Controls.Add(Me.Panel4)
        Me.GrRegistrarBloque.Controls.Add(Me.txtCentroCosto)
        Me.GrRegistrarBloque.Controls.Add(Me.txtLibro)
        Me.GrRegistrarBloque.Controls.Add(Me.txtAsientoDesc)
        Me.GrRegistrarBloque.Controls.Add(Me.BtnCentroCosto)
        Me.GrRegistrarBloque.Controls.Add(Me.txtAsientoCod)
        Me.GrRegistrarBloque.Controls.Add(Me.BtnAsientoT)
        Me.GrRegistrarBloque.Controls.Add(Me.Label4)
        Me.GrRegistrarBloque.Controls.Add(Me.Label3)
        Me.GrRegistrarBloque.Controls.Add(Me.Label2)
        Me.GrRegistrarBloque.Controls.Add(Me.Panel2)
        Me.GrRegistrarBloque.Controls.Add(Me.txtConcepto)
        Me.GrRegistrarBloque.Controls.Add(Me.Label1)
        Me.GrRegistrarBloque.Location = New System.Drawing.Point(387, 75)
        Me.GrRegistrarBloque.Name = "GrRegistrarBloque"
        Me.GrRegistrarBloque.Size = New System.Drawing.Size(431, 174)
        Me.GrRegistrarBloque.TabIndex = 210
        Me.GrRegistrarBloque.TabStop = False
        Me.GrRegistrarBloque.Text = "Registrar Bloque SIRE"
        Me.GrRegistrarBloque.Visible = False
        '
        'txtNomenclatura
        '
        Me.txtNomenclatura.Location = New System.Drawing.Point(235, 77)
        Me.txtNomenclatura.MaxLength = 80
        Me.txtNomenclatura.Multiline = True
        Me.txtNomenclatura.Name = "txtNomenclatura"
        Me.txtNomenclatura.NroDecimales = CType(0, Short)
        Me.txtNomenclatura.SelectGotFocus = True
        Me.txtNomenclatura.Size = New System.Drawing.Size(61, 18)
        Me.txtNomenclatura.TabIndex = 253
        Me.txtNomenclatura.Tabulado = True
        Me.txtNomenclatura.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 252
        Me.Label5.Text = "Nomenclatura"
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btncancelar)
        Me.Panel4.Controls.Add(Me.btngrabar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(425, 29)
        Me.Panel4.TabIndex = 241
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(29, 0)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 22
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(2, 0)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 17
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'txtCentroCosto
        '
        Me.txtCentroCosto.Location = New System.Drawing.Point(89, 77)
        Me.txtCentroCosto.MaxLength = 80
        Me.txtCentroCosto.Multiline = True
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.NroDecimales = CType(0, Short)
        Me.txtCentroCosto.SelectGotFocus = True
        Me.txtCentroCosto.Size = New System.Drawing.Size(39, 18)
        Me.txtCentroCosto.TabIndex = 251
        Me.txtCentroCosto.Tabulado = True
        Me.txtCentroCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCentroCosto.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'txtLibro
        '
        Me.txtLibro.Location = New System.Drawing.Point(305, 103)
        Me.txtLibro.MaxLength = 80
        Me.txtLibro.Multiline = True
        Me.txtLibro.Name = "txtLibro"
        Me.txtLibro.NroDecimales = CType(0, Short)
        Me.txtLibro.SelectGotFocus = True
        Me.txtLibro.Size = New System.Drawing.Size(38, 19)
        Me.txtLibro.TabIndex = 250
        Me.txtLibro.Tabulado = True
        Me.txtLibro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLibro.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'txtAsientoDesc
        '
        Me.txtAsientoDesc.Location = New System.Drawing.Point(160, 103)
        Me.txtAsientoDesc.MaxLength = 80
        Me.txtAsientoDesc.Multiline = True
        Me.txtAsientoDesc.Name = "txtAsientoDesc"
        Me.txtAsientoDesc.NroDecimales = CType(0, Short)
        Me.txtAsientoDesc.SelectGotFocus = True
        Me.txtAsientoDesc.Size = New System.Drawing.Size(113, 18)
        Me.txtAsientoDesc.TabIndex = 249
        Me.txtAsientoDesc.Tabulado = True
        Me.txtAsientoDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAsientoDesc.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'BtnCentroCosto
        '
        Me.BtnCentroCosto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnCentroCosto.Location = New System.Drawing.Point(131, 77)
        Me.BtnCentroCosto.Name = "BtnCentroCosto"
        Me.BtnCentroCosto.Size = New System.Drawing.Size(25, 21)
        Me.BtnCentroCosto.TabIndex = 248
        Me.BtnCentroCosto.Text = ":::"
        Me.BtnCentroCosto.UseVisualStyleBackColor = True
        '
        'txtAsientoCod
        '
        Me.txtAsientoCod.Location = New System.Drawing.Point(89, 101)
        Me.txtAsientoCod.MaxLength = 80
        Me.txtAsientoCod.Multiline = True
        Me.txtAsientoCod.Name = "txtAsientoCod"
        Me.txtAsientoCod.NroDecimales = CType(0, Short)
        Me.txtAsientoCod.SelectGotFocus = True
        Me.txtAsientoCod.Size = New System.Drawing.Size(39, 18)
        Me.txtAsientoCod.TabIndex = 247
        Me.txtAsientoCod.Tabulado = True
        Me.txtAsientoCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAsientoCod.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'BtnAsientoT
        '
        Me.BtnAsientoT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnAsientoT.Location = New System.Drawing.Point(131, 99)
        Me.BtnAsientoT.Name = "BtnAsientoT"
        Me.BtnAsientoT.Size = New System.Drawing.Size(25, 22)
        Me.BtnAsientoT.TabIndex = 246
        Me.BtnAsientoT.Text = ":::"
        Me.BtnAsientoT.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(277, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 245
        Me.Label4.Text = "Libro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 244
        Me.Label3.Text = "Centro Costo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 243
        Me.Label2.Text = "Asiento Tipo"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 145)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(425, 26)
        Me.Panel2.TabIndex = 242
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(92, 55)
        Me.txtConcepto.MaxLength = 80
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.NroDecimales = CType(0, Short)
        Me.txtConcepto.SelectGotFocus = True
        Me.txtConcepto.Size = New System.Drawing.Size(254, 18)
        Me.txtConcepto.TabIndex = 238
        Me.txtConcepto.Tabulado = True
        Me.txtConcepto.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Motivo Compras"
        '
        'tblhelp1_bloque
        '
        Me.tblhelp1_bloque.AllowUpdate = False
        Me.tblhelp1_bloque.AllowUpdateOnBlur = False
        Me.tblhelp1_bloque.AlternatingRows = True
        Me.tblhelp1_bloque.FilterBar = True
        Me.tblhelp1_bloque.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblhelp1_bloque.Images.Add(CType(resources.GetObject("tblhelp1_bloque.Images"), System.Drawing.Image))
        Me.tblhelp1_bloque.LinesPerRow = 1
        Me.tblhelp1_bloque.Location = New System.Drawing.Point(69, 107)
        Me.tblhelp1_bloque.Name = "tblhelp1_bloque"
        Me.tblhelp1_bloque.PictureCurrentRow = CType(resources.GetObject("tblhelp1_bloque.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp1_bloque.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp1_bloque.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp1_bloque.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp1_bloque.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp1_bloque.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp1_bloque.Size = New System.Drawing.Size(308, 130)
        Me.tblhelp1_bloque.TabIndex = 252
        Me.tblhelp1_bloque.TabStop = False
        Me.tblhelp1_bloque.Text = "C1TrueDBGrid1"
        Me.tblhelp1_bloque.UseColumnStyles = False
        Me.tblhelp1_bloque.Visible = False
        Me.tblhelp1_bloque.PropBag = resources.GetString("tblhelp1_bloque.PropBag")
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
        Me.tblhelp.Location = New System.Drawing.Point(740, 78)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(339, 95)
        Me.tblhelp.TabIndex = 202
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.FetchRowStyles = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images1"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images2"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(9, 75)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.ScrollTips = True
        Me.tblconsulta.Size = New System.Drawing.Size(1071, 213)
        Me.tblconsulta.TabIndex = 201
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AllowUpdate = False
        Me.C1TrueDBGrid1.AllowUpdateOnBlur = False
        Me.C1TrueDBGrid1.AlternatingRows = True
        Me.C1TrueDBGrid1.FilterBar = True
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images1"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images2"), System.Drawing.Image))
        Me.C1TrueDBGrid1.LinesPerRow = 1
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(1109, 120)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PictureCurrentRow = CType(resources.GetObject("C1TrueDBGrid1.PictureCurrentRow"), System.Drawing.Image)
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(162, 154)
        Me.C1TrueDBGrid1.TabIndex = 253
        Me.C1TrueDBGrid1.TabStop = False
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.UseColumnStyles = False
        Me.C1TrueDBGrid1.Visible = False
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'Frm_RegistrarCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1104, 354)
        Me.Controls.Add(Me.C1TrueDBGrid1)
        Me.Controls.Add(Me.tblhelp1_bloque)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.GrRegistrarBloque)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.btn_Contabilizar_Bloque)
        Me.Name = "Frm_RegistrarCompras"
        Me.Text = "Registrar Documentos SIRE"
        Me.Panel1.ResumeLayout(False)
        Me.GrRegistrarBloque.ResumeLayout(False)
        Me.GrRegistrarBloque.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.tblhelp1_bloque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents button_help_top As System.Windows.Forms.Button
    Friend WithEvents btn_Contabilizar_Bloque As System.Windows.Forms.Button
    Friend WithEvents GrRegistrarBloque As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents txtConcepto As Ks.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAsientoT As System.Windows.Forms.Button
    Friend WithEvents BtnCentroCosto As System.Windows.Forms.Button
    Friend WithEvents txtAsientoCod As Ks.UserControl.ksTextBox
    Friend WithEvents txtAsientoDesc As Ks.UserControl.ksTextBox
    Friend WithEvents txtLibro As Ks.UserControl.ksTextBox
    Friend WithEvents txtCentroCosto As Ks.UserControl.ksTextBox
    Friend WithEvents tblhelp1_bloque As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtNomenclatura As KS.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid


End Class
