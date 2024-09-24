<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EEGGyPP_Conf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_EEGGyPP_Conf))
        Me.lnkeliminar = New System.Windows.Forms.LinkLabel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboimprimir = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GbxDetalle = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdescripcion = New Ks.UserControl.ksTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbotipo = New System.Windows.Forms.ComboBox()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcuenta = New Ks.UserControl.ksTextBox()
        Me.lnkgrabar = New System.Windows.Forms.LinkLabel()
        Me.lnkcancelar = New System.Windows.Forms.LinkLabel()
        Me.lnkinsertar = New System.Windows.Forms.LinkLabel()
        Me.lnkNuevo = New System.Windows.Forms.LinkLabel()
        Me.lnkmodificar = New System.Windows.Forms.LinkLabel()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxDetalle.SuspendLayout()
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
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(534, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 315)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(566, 31)
        Me.Panel3.TabIndex = 258
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 29)
        Me.Panel1.TabIndex = 257
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
        Me.tblhelp.Location = New System.Drawing.Point(80, 88)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(350, 146)
        Me.tblhelp.TabIndex = 262
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'cboimprimir
        '
        Me.cboimprimir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboimprimir.FormattingEnabled = True
        Me.cboimprimir.Items.AddRange(New Object() {"Si", "No"})
        Me.cboimprimir.Location = New System.Drawing.Point(80, 110)
        Me.cboimprimir.Name = "cboimprimir"
        Me.cboimprimir.Size = New System.Drawing.Size(42, 21)
        Me.cboimprimir.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 278
        Me.Label10.Text = "Imprimir"
        '
        'GbxDetalle
        '
        Me.GbxDetalle.Controls.Add(Me.tblhelp)
        Me.GbxDetalle.Controls.Add(Me.Label2)
        Me.GbxDetalle.Controls.Add(Me.txtdescripcion)
        Me.GbxDetalle.Controls.Add(Me.cboimprimir)
        Me.GbxDetalle.Controls.Add(Me.Label10)
        Me.GbxDetalle.Controls.Add(Me.Label8)
        Me.GbxDetalle.Controls.Add(Me.cbotipo)
        Me.GbxDetalle.Controls.Add(Me.btnhelp_1)
        Me.GbxDetalle.Controls.Add(Me.Label4)
        Me.GbxDetalle.Controls.Add(Me.txtcuenta)
        Me.GbxDetalle.Controls.Add(Me.lnkgrabar)
        Me.GbxDetalle.Controls.Add(Me.lnkcancelar)
        Me.GbxDetalle.Controls.Add(Me.lnkinsertar)
        Me.GbxDetalle.Controls.Add(Me.lnkNuevo)
        Me.GbxDetalle.Controls.Add(Me.lnkmodificar)
        Me.GbxDetalle.Controls.Add(Me.lnkeliminar)
        Me.GbxDetalle.Location = New System.Drawing.Point(6, 26)
        Me.GbxDetalle.Name = "GbxDetalle"
        Me.GbxDetalle.Size = New System.Drawing.Size(554, 136)
        Me.GbxDetalle.TabIndex = 260
        Me.GbxDetalle.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 281
        Me.Label2.Text = "Descripcion"
        '
        'txtdescripcion
        '
        Me.txtdescripcion.Location = New System.Drawing.Point(80, 89)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.NroDecimales = CType(0, Short)
        Me.txtdescripcion.SelectGotFocus = True
        Me.txtdescripcion.Size = New System.Drawing.Size(470, 20)
        Me.txtdescripcion.TabIndex = 279
        Me.txtdescripcion.Tabulado = True
        Me.txtdescripcion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "Tipo"
        '
        'cbotipo
        '
        Me.cbotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipo.FormattingEnabled = True
        Me.cbotipo.Items.AddRange(New Object() {"C-Cuenta", "A-Acumulado"})
        Me.cbotipo.Location = New System.Drawing.Point(80, 45)
        Me.cbotipo.Name = "cbotipo"
        Me.cbotipo.Size = New System.Drawing.Size(42, 21)
        Me.cbotipo.TabIndex = 1
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(220, 66)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 273
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 272
        Me.Label4.Text = "Cuenta"
        '
        'txtcuenta
        '
        Me.txtcuenta.Location = New System.Drawing.Point(80, 67)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.NroDecimales = CType(0, Short)
        Me.txtcuenta.SelectGotFocus = True
        Me.txtcuenta.Size = New System.Drawing.Size(140, 20)
        Me.txtcuenta.TabIndex = 0
        Me.txtcuenta.Tabulado = True
        Me.txtcuenta.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
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
        'lnkmodificar
        '
        Me.lnkmodificar.AutoSize = True
        Me.lnkmodificar.Location = New System.Drawing.Point(53, 24)
        Me.lnkmodificar.Name = "lnkmodificar"
        Me.lnkmodificar.Size = New System.Drawing.Size(50, 13)
        Me.lnkmodificar.TabIndex = 202
        Me.lnkmodificar.TabStop = True
        Me.lnkmodificar.Text = "Modificar"
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
        Me.tblconsulta.Location = New System.Drawing.Point(4, 166)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(556, 146)
        Me.tblconsulta.TabIndex = 261
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Frm_EEGGyPP_Conf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 346)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GbxDetalle)
        Me.Controls.Add(Me.tblconsulta)
        Me.Name = "Frm_EEGGyPP_Conf"
        Me.Text = "Frm_EEGGyPP_Conf"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxDetalle.ResumeLayout(False)
        Me.GbxDetalle.PerformLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkeliminar As System.Windows.Forms.LinkLabel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboimprimir As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbotipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As KS.UserControl.ksTextBox
    Friend WithEvents lnkgrabar As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkcancelar As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkinsertar As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNuevo As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkmodificar As System.Windows.Forms.LinkLabel
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdescripcion As KS.UserControl.ksTextBox
End Class
