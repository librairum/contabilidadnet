﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BalanceGeneral_Conf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BalanceGeneral_Conf))
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btninsertar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.txtfuente = New Ks.UserControl.ksTextBox()
        Me.btnhelp_3 = New System.Windows.Forms.Button()
        Me.lblhelp_3 = New System.Windows.Forms.Label()
        Me.txtsubgrupo = New Ks.UserControl.ksTextBox()
        Me.btnhelp_2 = New System.Windows.Forms.Button()
        Me.lblhelp_2 = New System.Windows.Forms.Label()
        Me.txtgrupo = New Ks.UserControl.ksTextBox()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txttipofila = New Ks.UserControl.ksTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtformula1 = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdescripcion = New Ks.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtformula = New Ks.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.tblconsulta.Location = New System.Drawing.Point(4, 142)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(738, 158)
        Me.tblconsulta.TabIndex = 216
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 303)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(753, 28)
        Me.Panel3.TabIndex = 214
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Panel1.Size = New System.Drawing.Size(753, 31)
        Me.Panel1.TabIndex = 7
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
        Me.btncancelar.Location = New System.Drawing.Point(118, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 6
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(720, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(96, 2)
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
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(4, 2)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 12
        Me.btnnuevo.UseVisualStyleBackColor = True
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
        'tblhelp
        '
        Me.tblhelp.AllowUpdate = False
        Me.tblhelp.AllowUpdateOnBlur = False
        Me.tblhelp.AlternatingRows = True
        Me.tblhelp.FilterBar = True
        Me.tblhelp.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblhelp.Images.Add(CType(resources.GetObject("tblhelp.Images"), System.Drawing.Image))
        Me.tblhelp.LinesPerRow = 1
        Me.tblhelp.Location = New System.Drawing.Point(388, 156)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(340, 140)
        Me.tblhelp.TabIndex = 272
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(396, 34)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 307
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(418, 36)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(164, 18)
        Me.lblhelp_1.TabIndex = 306
        Me.lblhelp_1.Text = "???"
        '
        'txtfuente
        '
        Me.txtfuente.Location = New System.Drawing.Point(369, 34)
        Me.txtfuente.Name = "txtfuente"
        Me.txtfuente.NroDecimales = CType(0, Short)
        Me.txtfuente.SelectGotFocus = True
        Me.txtfuente.Size = New System.Drawing.Size(26, 20)
        Me.txtfuente.TabIndex = 1
        Me.txtfuente.Tabulado = True
        Me.txtfuente.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_3
        '
        Me.btnhelp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_3.Location = New System.Drawing.Point(397, 56)
        Me.btnhelp_3.Name = "btnhelp_3"
        Me.btnhelp_3.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_3.TabIndex = 304
        Me.btnhelp_3.Text = ":::"
        Me.btnhelp_3.UseVisualStyleBackColor = True
        '
        'lblhelp_3
        '
        Me.lblhelp_3.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_3.Location = New System.Drawing.Point(419, 56)
        Me.lblhelp_3.Name = "lblhelp_3"
        Me.lblhelp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_3.Size = New System.Drawing.Size(164, 18)
        Me.lblhelp_3.TabIndex = 303
        Me.lblhelp_3.Text = "???"
        '
        'txtsubgrupo
        '
        Me.txtsubgrupo.Location = New System.Drawing.Point(369, 56)
        Me.txtsubgrupo.Name = "txtsubgrupo"
        Me.txtsubgrupo.NroDecimales = CType(0, Short)
        Me.txtsubgrupo.SelectGotFocus = True
        Me.txtsubgrupo.Size = New System.Drawing.Size(26, 20)
        Me.txtsubgrupo.TabIndex = 3
        Me.txtsubgrupo.Tabulado = True
        Me.txtsubgrupo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_2
        '
        Me.btnhelp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_2.Location = New System.Drawing.Point(117, 56)
        Me.btnhelp_2.Name = "btnhelp_2"
        Me.btnhelp_2.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_2.TabIndex = 301
        Me.btnhelp_2.Text = ":::"
        Me.btnhelp_2.UseVisualStyleBackColor = True
        '
        'lblhelp_2
        '
        Me.lblhelp_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_2.Location = New System.Drawing.Point(139, 58)
        Me.lblhelp_2.Name = "lblhelp_2"
        Me.lblhelp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_2.Size = New System.Drawing.Size(164, 18)
        Me.lblhelp_2.TabIndex = 300
        Me.lblhelp_2.Text = "???"
        '
        'txtgrupo
        '
        Me.txtgrupo.Location = New System.Drawing.Point(90, 56)
        Me.txtgrupo.Name = "txtgrupo"
        Me.txtgrupo.NroDecimales = CType(0, Short)
        Me.txtgrupo.SelectGotFocus = True
        Me.txtgrupo.Size = New System.Drawing.Size(26, 20)
        Me.txtgrupo.TabIndex = 2
        Me.txtgrupo.Tabulado = True
        Me.txtgrupo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(117, 34)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 298
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(139, 36)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(164, 18)
        Me.lblhelp_0.TabIndex = 297
        Me.lblhelp_0.Text = "???"
        '
        'txttipofila
        '
        Me.txttipofila.Location = New System.Drawing.Point(90, 34)
        Me.txttipofila.Name = "txttipofila"
        Me.txttipofila.NroDecimales = CType(0, Short)
        Me.txttipofila.SelectGotFocus = True
        Me.txttipofila.Size = New System.Drawing.Size(26, 20)
        Me.txttipofila.TabIndex = 0
        Me.txttipofila.Tabulado = True
        Me.txttipofila.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(0, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 295
        Me.Label7.Text = "Formula Año Ant"
        '
        'txtformula1
        '
        Me.txtformula1.Location = New System.Drawing.Point(90, 120)
        Me.txtformula1.Name = "txtformula1"
        Me.txtformula1.NroDecimales = CType(0, Short)
        Me.txtformula1.SelectGotFocus = True
        Me.txtformula1.Size = New System.Drawing.Size(494, 20)
        Me.txtformula1.TabIndex = 6
        Me.txtformula1.Tabulado = True
        Me.txtformula1.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 290
        Me.Label3.Text = "Tipo de Fila"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(325, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 293
        Me.Label6.Text = "Fuente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(309, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 292
        Me.Label5.Text = "Sub Grupo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 291
        Me.Label4.Text = "Grupo"
        '
        'txtdescripcion
        '
        Me.txtdescripcion.Location = New System.Drawing.Point(90, 78)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.NroDecimales = CType(0, Short)
        Me.txtdescripcion.SelectGotFocus = True
        Me.txtdescripcion.Size = New System.Drawing.Size(494, 20)
        Me.txtdescripcion.TabIndex = 4
        Me.txtdescripcion.Tabulado = True
        Me.txtdescripcion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 289
        Me.Label2.Text = "Formula Año"
        '
        'txtformula
        '
        Me.txtformula.Location = New System.Drawing.Point(90, 99)
        Me.txtformula.Name = "txtformula"
        Me.txtformula.NroDecimales = CType(0, Short)
        Me.txtformula.SelectGotFocus = True
        Me.txtformula.Size = New System.Drawing.Size(494, 20)
        Me.txtformula.TabIndex = 5
        Me.txtformula.Tabulado = True
        Me.txtformula.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Descripcion"
        '
        'Frm_BalanceGeneral_Conf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 331)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.txtfuente)
        Me.Controls.Add(Me.btnhelp_3)
        Me.Controls.Add(Me.lblhelp_3)
        Me.Controls.Add(Me.txtsubgrupo)
        Me.Controls.Add(Me.btnhelp_2)
        Me.Controls.Add(Me.lblhelp_2)
        Me.Controls.Add(Me.txtgrupo)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txttipofila)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtformula1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtdescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtformula)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel3)
        Me.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Name = "Frm_BalanceGeneral_Conf"
        Me.Text = "Frm_BalanceGeneral_Nuevo"
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btninsertar As System.Windows.Forms.Button
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txtfuente As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_3 As System.Windows.Forms.Button
    Public WithEvents lblhelp_3 As System.Windows.Forms.Label
    Friend WithEvents txtsubgrupo As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_2 As System.Windows.Forms.Button
    Public WithEvents lblhelp_2 As System.Windows.Forms.Label
    Friend WithEvents txtgrupo As KS.UserControl.ksTextBox
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txttipofila As KS.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtformula1 As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdescripcion As KS.UserControl.ksTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtformula As KS.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
