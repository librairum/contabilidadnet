<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Libros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Libros))
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCodigo = New KS.UserControl.ksTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescri = New KS.UserControl.ksTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkNumerManual = New System.Windows.Forms.CheckBox()
        Me.chkamarre = New System.Windows.Forms.CheckBox()
        Me.chkmodtipcam = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtTipo_2 = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_3 = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_0 = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_4 = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_1 = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_5 = New System.Windows.Forms.RadioButton()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(632, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
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
        Me.tblconsulta.Location = New System.Drawing.Point(332, 38)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(330, 200)
        Me.tblconsulta.TabIndex = 147
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(91, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 6
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(69, 2)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 5
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(47, 2)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 14
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(26, 2)
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 244)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(670, 26)
        Me.Panel3.TabIndex = 148
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
        Me.Panel1.Size = New System.Drawing.Size(670, 31)
        Me.Panel1.TabIndex = 146
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(46, 18)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.NroDecimales = CType(0, Short)
        Me.txtCodigo.SelectGotFocus = True
        Me.txtCodigo.Size = New System.Drawing.Size(24, 20)
        Me.txtCodigo.TabIndex = 42
        Me.txtCodigo.Tabulado = True
        Me.txtCodigo.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Libro"
        '
        'txtDescri
        '
        Me.txtDescri.Location = New System.Drawing.Point(72, 18)
        Me.txtDescri.Name = "txtDescri"
        Me.txtDescri.NroDecimales = CType(4, Short)
        Me.txtDescri.SelectGotFocus = True
        Me.txtDescri.Size = New System.Drawing.Size(240, 20)
        Me.txtDescri.TabIndex = 44
        Me.txtDescri.Tabulado = True
        Me.txtDescri.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtDescri)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 200)
        Me.GroupBox1.TabIndex = 149
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkNumerManual)
        Me.GroupBox3.Controls.Add(Me.chkamarre)
        Me.GroupBox3.Controls.Add(Me.chkmodtipcam)
        Me.GroupBox3.Location = New System.Drawing.Point(46, 122)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(266, 70)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        '
        'chkNumerManual
        '
        Me.chkNumerManual.AutoSize = True
        Me.chkNumerManual.Location = New System.Drawing.Point(6, 16)
        Me.chkNumerManual.Name = "chkNumerManual"
        Me.chkNumerManual.Size = New System.Drawing.Size(127, 17)
        Me.chkNumerManual.TabIndex = 51
        Me.chkNumerManual.Text = "Numeración Manual  "
        Me.chkNumerManual.UseVisualStyleBackColor = True
        '
        'chkamarre
        '
        Me.chkamarre.AutoSize = True
        Me.chkamarre.Location = New System.Drawing.Point(6, 34)
        Me.chkamarre.Name = "chkamarre"
        Me.chkamarre.Size = New System.Drawing.Size(165, 17)
        Me.chkamarre.TabIndex = 52
        Me.chkamarre.Text = "NO Jalar Cuentas De Destino"
        Me.chkamarre.UseVisualStyleBackColor = True
        '
        'chkmodtipcam
        '
        Me.chkmodtipcam.AutoSize = True
        Me.chkmodtipcam.Location = New System.Drawing.Point(6, 52)
        Me.chkmodtipcam.Name = "chkmodtipcam"
        Me.chkmodtipcam.Size = New System.Drawing.Size(195, 17)
        Me.chkmodtipcam.TabIndex = 53
        Me.chkmodtipcam.Text = "Permite Modificar el Tipo de Cambio"
        Me.chkmodtipcam.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtTipo_5)
        Me.GroupBox2.Controls.Add(Me.rbtTipo_2)
        Me.GroupBox2.Controls.Add(Me.rbtTipo_3)
        Me.GroupBox2.Controls.Add(Me.rbtTipo_0)
        Me.GroupBox2.Controls.Add(Me.rbtTipo_4)
        Me.GroupBox2.Controls.Add(Me.rbtTipo_1)
        Me.GroupBox2.Location = New System.Drawing.Point(46, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(266, 78)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Libro"
        '
        'rbtTipo_2
        '
        Me.rbtTipo_2.AutoSize = True
        Me.rbtTipo_2.Location = New System.Drawing.Point(8, 58)
        Me.rbtTipo_2.Name = "rbtTipo_2"
        Me.rbtTipo_2.Size = New System.Drawing.Size(128, 17)
        Me.rbtTipo_2.TabIndex = 48
        Me.rbtTipo_2.TabStop = True
        Me.rbtTipo_2.Text = "Retenciones 4ta. Cat."
        Me.rbtTipo_2.UseVisualStyleBackColor = True
        '
        'rbtTipo_3
        '
        Me.rbtTipo_3.AutoSize = True
        Me.rbtTipo_3.Location = New System.Drawing.Point(8, 38)
        Me.rbtTipo_3.Name = "rbtTipo_3"
        Me.rbtTipo_3.Size = New System.Drawing.Size(61, 17)
        Me.rbtTipo_3.TabIndex = 49
        Me.rbtTipo_3.TabStop = True
        Me.rbtTipo_3.Text = "Bancos"
        Me.rbtTipo_3.UseVisualStyleBackColor = True
        '
        'rbtTipo_0
        '
        Me.rbtTipo_0.AutoSize = True
        Me.rbtTipo_0.Location = New System.Drawing.Point(8, 18)
        Me.rbtTipo_0.Name = "rbtTipo_0"
        Me.rbtTipo_0.Size = New System.Drawing.Size(66, 17)
        Me.rbtTipo_0.TabIndex = 46
        Me.rbtTipo_0.TabStop = True
        Me.rbtTipo_0.Text = "Compras"
        Me.rbtTipo_0.UseVisualStyleBackColor = True
        '
        'rbtTipo_4
        '
        Me.rbtTipo_4.AutoSize = True
        Me.rbtTipo_4.Location = New System.Drawing.Point(143, 55)
        Me.rbtTipo_4.Name = "rbtTipo_4"
        Me.rbtTipo_4.Size = New System.Drawing.Size(50, 17)
        Me.rbtTipo_4.TabIndex = 50
        Me.rbtTipo_4.TabStop = True
        Me.rbtTipo_4.Text = "Otros"
        Me.rbtTipo_4.UseVisualStyleBackColor = True
        '
        'rbtTipo_1
        '
        Me.rbtTipo_1.AutoSize = True
        Me.rbtTipo_1.Location = New System.Drawing.Point(143, 18)
        Me.rbtTipo_1.Name = "rbtTipo_1"
        Me.rbtTipo_1.Size = New System.Drawing.Size(58, 17)
        Me.rbtTipo_1.TabIndex = 47
        Me.rbtTipo_1.TabStop = True
        Me.rbtTipo_1.Text = "Ventas"
        Me.rbtTipo_1.UseVisualStyleBackColor = True
        '
        'rbtTipo_5
        '
        Me.rbtTipo_5.AutoSize = True
        Me.rbtTipo_5.Location = New System.Drawing.Point(143, 38)
        Me.rbtTipo_5.Name = "rbtTipo_5"
        Me.rbtTipo_5.Size = New System.Drawing.Size(85, 17)
        Me.rbtTipo_5.TabIndex = 51
        Me.rbtTipo_5.TabStop = True
        Me.rbtTipo_5.Text = "Retenciones"
        Me.rbtTipo_5.UseVisualStyleBackColor = True
        '
        'Frm_Libros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 270)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Libros"
        Me.Text = "Frm_Libros"
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCodigo As KS.UserControl.ksTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescri As KS.UserControl.ksTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkmodtipcam As System.Windows.Forms.CheckBox
    Friend WithEvents chkamarre As System.Windows.Forms.CheckBox
    Friend WithEvents chkNumerManual As System.Windows.Forms.CheckBox
    Friend WithEvents rbtTipo_4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_0 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtTipo_5 As System.Windows.Forms.RadioButton
End Class
