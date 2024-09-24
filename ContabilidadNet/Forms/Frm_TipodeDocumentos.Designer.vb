<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TipodeDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_TipodeDocumentos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCodigo = New Ks.UserControl.ksTextBox()
        Me.txtDescri = New Ks.UserControl.ksTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtOperacion_1 = New System.Windows.Forms.RadioButton()
        Me.rbtOperacion_0 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtReferencia_3 = New System.Windows.Forms.RadioButton()
        Me.rbtReferencia_2 = New System.Windows.Forms.RadioButton()
        Me.rbtReferencia_1 = New System.Windows.Forms.RadioButton()
        Me.rbtReferencia_0 = New System.Windows.Forms.RadioButton()
        Me.chkretencion = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripcion"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(7, 50)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.NroDecimales = CType(0, Short)
        Me.txtCodigo.SelectGotFocus = True
        Me.txtCodigo.Size = New System.Drawing.Size(39, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Tabulado = True
        Me.txtCodigo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtDescri
        '
        Me.txtDescri.Location = New System.Drawing.Point(46, 50)
        Me.txtDescri.Name = "txtDescri"
        Me.txtDescri.NroDecimales = CType(4, Short)
        Me.txtDescri.SelectGotFocus = True
        Me.txtDescri.Size = New System.Drawing.Size(474, 20)
        Me.txtDescri.TabIndex = 2
        Me.txtDescri.Tabulado = True
        Me.txtDescri.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
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
        Me.Panel1.Size = New System.Drawing.Size(526, 31)
        Me.Panel1.TabIndex = 158
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(88, 2)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 6
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(66, 2)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 0
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(492, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(45, 2)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 14
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(24, 2)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 13
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(2, 2)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 12
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 256)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(526, 26)
        Me.Panel3.TabIndex = 160
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
        Me.tblconsulta.Location = New System.Drawing.Point(4, 114)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(516, 134)
        Me.tblconsulta.TabIndex = 159
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtOperacion_1)
        Me.GroupBox2.Controls.Add(Me.rbtOperacion_0)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 38)
        Me.GroupBox2.TabIndex = 162
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operacion a realizar"
        '
        'rbtOperacion_1
        '
        Me.rbtOperacion_1.AutoSize = True
        Me.rbtOperacion_1.Location = New System.Drawing.Point(64, 16)
        Me.rbtOperacion_1.Name = "rbtOperacion_1"
        Me.rbtOperacion_1.Size = New System.Drawing.Size(53, 17)
        Me.rbtOperacion_1.TabIndex = 165
        Me.rbtOperacion_1.TabStop = True
        Me.rbtOperacion_1.Text = "Resta"
        Me.rbtOperacion_1.UseVisualStyleBackColor = True
        '
        'rbtOperacion_0
        '
        Me.rbtOperacion_0.AutoSize = True
        Me.rbtOperacion_0.Location = New System.Drawing.Point(10, 16)
        Me.rbtOperacion_0.Name = "rbtOperacion_0"
        Me.rbtOperacion_0.Size = New System.Drawing.Size(52, 17)
        Me.rbtOperacion_0.TabIndex = 164
        Me.rbtOperacion_0.TabStop = True
        Me.rbtOperacion_0.Text = "Suma"
        Me.rbtOperacion_0.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtReferencia_3)
        Me.GroupBox3.Controls.Add(Me.rbtReferencia_2)
        Me.GroupBox3.Controls.Add(Me.rbtReferencia_1)
        Me.GroupBox3.Controls.Add(Me.rbtReferencia_0)
        Me.GroupBox3.Location = New System.Drawing.Point(134, 72)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 38)
        Me.GroupBox3.TabIndex = 163
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Referencia del documento"
        '
        'rbtReferencia_3
        '
        Me.rbtReferencia_3.AutoSize = True
        Me.rbtReferencia_3.Location = New System.Drawing.Point(186, 17)
        Me.rbtReferencia_3.Name = "rbtReferencia_3"
        Me.rbtReferencia_3.Size = New System.Drawing.Size(65, 17)
        Me.rbtReferencia_3.TabIndex = 169
        Me.rbtReferencia_3.TabStop = True
        Me.rbtReferencia_3.Text = "Ninguno"
        Me.rbtReferencia_3.UseVisualStyleBackColor = True
        '
        'rbtReferencia_2
        '
        Me.rbtReferencia_2.AutoSize = True
        Me.rbtReferencia_2.Location = New System.Drawing.Point(124, 17)
        Me.rbtReferencia_2.Name = "rbtReferencia_2"
        Me.rbtReferencia_2.Size = New System.Drawing.Size(63, 17)
        Me.rbtReferencia_2.TabIndex = 168
        Me.rbtReferencia_2.TabStop = True
        Me.rbtReferencia_2.Text = "Servicio"
        Me.rbtReferencia_2.UseVisualStyleBackColor = True
        '
        'rbtReferencia_1
        '
        Me.rbtReferencia_1.AutoSize = True
        Me.rbtReferencia_1.Location = New System.Drawing.Point(66, 17)
        Me.rbtReferencia_1.Name = "rbtReferencia_1"
        Me.rbtReferencia_1.Size = New System.Drawing.Size(56, 17)
        Me.rbtReferencia_1.TabIndex = 167
        Me.rbtReferencia_1.TabStop = True
        Me.rbtReferencia_1.Text = "Debito"
        Me.rbtReferencia_1.UseVisualStyleBackColor = True
        '
        'rbtReferencia_0
        '
        Me.rbtReferencia_0.AutoSize = True
        Me.rbtReferencia_0.Location = New System.Drawing.Point(8, 17)
        Me.rbtReferencia_0.Name = "rbtReferencia_0"
        Me.rbtReferencia_0.Size = New System.Drawing.Size(58, 17)
        Me.rbtReferencia_0.TabIndex = 166
        Me.rbtReferencia_0.TabStop = True
        Me.rbtReferencia_0.Text = "Credito"
        Me.rbtReferencia_0.UseVisualStyleBackColor = True
        '
        'chkretencion
        '
        Me.chkretencion.Location = New System.Drawing.Point(397, 72)
        Me.chkretencion.Name = "chkretencion"
        Me.chkretencion.Size = New System.Drawing.Size(121, 38)
        Me.chkretencion.TabIndex = 164
        Me.chkretencion.Text = "Documento Afecto a retencion"
        Me.chkretencion.UseVisualStyleBackColor = True
        '
        'Frm_TipodeDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 282)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkretencion)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtDescri)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Frm_TipodeDocumentos"
        Me.Text = "Frm_TipodeDocumentos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As KS.UserControl.ksTextBox
    Friend WithEvents txtDescri As KS.UserControl.ksTextBox
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtOperacion_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtOperacion_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtReferencia_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtReferencia_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtReferencia_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtReferencia_0 As System.Windows.Forms.RadioButton
    Friend WithEvents chkretencion As System.Windows.Forms.CheckBox
End Class
