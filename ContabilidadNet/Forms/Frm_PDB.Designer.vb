<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PDB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PDB))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtLibrocompra = New KS.UserControl.ksTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tblhelp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnhelp_1 = New System.Windows.Forms.Button()
        Me.lblhelp_1 = New System.Windows.Forms.Label()
        Me.txtLibroventas = New KS.UserControl.ksTextBox()
        Me.chktipodecambio = New System.Windows.Forms.CheckBox()
        Me.chkCompras = New System.Windows.Forms.CheckBox()
        Me.chkVentas = New System.Windows.Forms.CheckBox()
        Me.txtrutacompras = New System.Windows.Forms.TextBox()
        Me.txtrutaventas = New System.Windows.Forms.TextBox()
        Me.txtrutatipodecambio = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Libro Compras"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(301, 70)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 230
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(331, 73)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(146, 18)
        Me.lblhelp_0.TabIndex = 229
        Me.lblhelp_0.Text = "???"
        '
        'txtLibrocompra
        '
        Me.txtLibrocompra.BackColor = System.Drawing.Color.White
        Me.txtLibrocompra.Location = New System.Drawing.Point(265, 71)
        Me.txtLibrocompra.Name = "txtLibrocompra"
        Me.txtLibrocompra.NroDecimales = CType(0, Short)
        Me.txtLibrocompra.SelectGotFocus = True
        Me.txtLibrocompra.Size = New System.Drawing.Size(36, 20)
        Me.txtLibrocompra.TabIndex = 228
        Me.txtLibrocompra.Tabulado = True
        Me.txtLibrocompra.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnexportar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(716, 33)
        Me.Panel1.TabIndex = 226
        '
        'btnexportar
        '
        Me.btnexportar.Image = Global.ContabilidadNet.My.Resources.Resources.exportar
        Me.btnexportar.Location = New System.Drawing.Point(4, 1)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(24, 24)
        Me.btnexportar.TabIndex = 22
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(675, 4)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 192)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(716, 28)
        Me.Panel3.TabIndex = 227
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
        Me.tblhelp.Location = New System.Drawing.Point(301, 115)
        Me.tblhelp.Name = "tblhelp"
        Me.tblhelp.PictureCurrentRow = CType(resources.GetObject("tblhelp.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp.Size = New System.Drawing.Size(286, 88)
        Me.tblhelp.TabIndex = 231
        Me.tblhelp.TabStop = False
        Me.tblhelp.Text = "C1TrueDBGrid1"
        Me.tblhelp.UseColumnStyles = False
        Me.tblhelp.Visible = False
        Me.tblhelp.PropBag = resources.GetString("tblhelp.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(188, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "Libro Ventas"
        '
        'btnhelp_1
        '
        Me.btnhelp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_1.Location = New System.Drawing.Point(301, 94)
        Me.btnhelp_1.Name = "btnhelp_1"
        Me.btnhelp_1.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_1.TabIndex = 238
        Me.btnhelp_1.Text = ":::"
        Me.btnhelp_1.UseVisualStyleBackColor = True
        '
        'lblhelp_1
        '
        Me.lblhelp_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_1.Location = New System.Drawing.Point(331, 93)
        Me.lblhelp_1.Name = "lblhelp_1"
        Me.lblhelp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_1.Size = New System.Drawing.Size(148, 18)
        Me.lblhelp_1.TabIndex = 237
        Me.lblhelp_1.Text = "???"
        '
        'txtLibroventas
        '
        Me.txtLibroventas.BackColor = System.Drawing.Color.White
        Me.txtLibroventas.Location = New System.Drawing.Point(265, 95)
        Me.txtLibroventas.Name = "txtLibroventas"
        Me.txtLibroventas.NroDecimales = CType(0, Short)
        Me.txtLibroventas.SelectGotFocus = True
        Me.txtLibroventas.Size = New System.Drawing.Size(36, 20)
        Me.txtLibroventas.TabIndex = 236
        Me.txtLibroventas.Tabulado = True
        Me.txtLibroventas.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'chktipodecambio
        '
        Me.chktipodecambio.AutoSize = True
        Me.chktipodecambio.Location = New System.Drawing.Point(12, 50)
        Me.chktipodecambio.Name = "chktipodecambio"
        Me.chktipodecambio.Size = New System.Drawing.Size(99, 17)
        Me.chktipodecambio.TabIndex = 239
        Me.chktipodecambio.Text = "Tipo de cambio"
        Me.chktipodecambio.UseVisualStyleBackColor = True
        '
        'chkCompras
        '
        Me.chkCompras.AutoSize = True
        Me.chkCompras.Location = New System.Drawing.Point(12, 72)
        Me.chkCompras.Name = "chkCompras"
        Me.chkCompras.Size = New System.Drawing.Size(148, 17)
        Me.chkCompras.TabIndex = 240
        Me.chkCompras.Text = "Comprobantes de Compra"
        Me.chkCompras.UseVisualStyleBackColor = True
        '
        'chkVentas
        '
        Me.chkVentas.AutoSize = True
        Me.chkVentas.Location = New System.Drawing.Point(12, 96)
        Me.chkVentas.Name = "chkVentas"
        Me.chkVentas.Size = New System.Drawing.Size(140, 17)
        Me.chkVentas.TabIndex = 241
        Me.chkVentas.Text = "Comprobantes de Venta"
        Me.chkVentas.UseVisualStyleBackColor = True
        '
        'txtrutacompras
        '
        Me.txtrutacompras.Location = New System.Drawing.Point(483, 73)
        Me.txtrutacompras.Name = "txtrutacompras"
        Me.txtrutacompras.Size = New System.Drawing.Size(217, 20)
        Me.txtrutacompras.TabIndex = 242
        '
        'txtrutaventas
        '
        Me.txtrutaventas.Location = New System.Drawing.Point(483, 93)
        Me.txtrutaventas.Name = "txtrutaventas"
        Me.txtrutaventas.Size = New System.Drawing.Size(217, 20)
        Me.txtrutaventas.TabIndex = 243
        '
        'txtrutatipodecambio
        '
        Me.txtrutatipodecambio.Location = New System.Drawing.Point(483, 47)
        Me.txtrutatipodecambio.Name = "txtrutatipodecambio"
        Me.txtrutatipodecambio.Size = New System.Drawing.Size(217, 20)
        Me.txtrutatipodecambio.TabIndex = 244
        '
        'Frm_PDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 220)
        Me.Controls.Add(Me.txtrutatipodecambio)
        Me.Controls.Add(Me.txtrutaventas)
        Me.Controls.Add(Me.txtrutacompras)
        Me.Controls.Add(Me.chkVentas)
        Me.Controls.Add(Me.chkCompras)
        Me.Controls.Add(Me.chktipodecambio)
        Me.Controls.Add(Me.btnhelp_1)
        Me.Controls.Add(Me.lblhelp_1)
        Me.Controls.Add(Me.txtLibroventas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tblhelp)
        Me.Controls.Add(Me.btnhelp_0)
        Me.Controls.Add(Me.lblhelp_0)
        Me.Controls.Add(Me.txtLibrocompra)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_PDB"
        Me.Text = "Frm_PDB"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtLibrocompra As Ks.UserControl.ksTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_1 As System.Windows.Forms.Button
    Public WithEvents lblhelp_1 As System.Windows.Forms.Label
    Friend WithEvents txtLibroventas As KS.UserControl.ksTextBox
    Friend WithEvents chktipodecambio As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompras As System.Windows.Forms.CheckBox
    Friend WithEvents chkVentas As System.Windows.Forms.CheckBox
    Friend WithEvents txtrutacompras As System.Windows.Forms.TextBox
    Friend WithEvents txtrutaventas As System.Windows.Forms.TextBox
    Friend WithEvents txtrutatipodecambio As System.Windows.Forms.TextBox
End Class
