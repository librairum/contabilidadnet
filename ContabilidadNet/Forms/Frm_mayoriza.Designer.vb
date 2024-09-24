<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_mayoriza
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnInicia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkMayoriza_0 = New System.Windows.Forms.CheckBox()
        Me.chkMayoriza_1 = New System.Windows.Forms.CheckBox()
        Me.chkMayoriza_2 = New System.Windows.Forms.CheckBox()
        Me.chkMayoriza_3 = New System.Windows.Forms.CheckBox()
        Me.chkMayoriza_4 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnInicia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 31)
        Me.Panel1.TabIndex = 4
        '
        'btnInicia
        '
        Me.btnInicia.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnInicia.Location = New System.Drawing.Point(4, 2)
        Me.btnInicia.Name = "btnInicia"
        Me.btnInicia.Size = New System.Drawing.Size(54, 24)
        Me.btnInicia.TabIndex = 22
        Me.btnInicia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(362, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Periodo"
        '
        'cboperiodos
        '
        Me.cboperiodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos.FormattingEnabled = True
        Me.cboperiodos.Location = New System.Drawing.Point(58, 20)
        Me.cboperiodos.Name = "cboperiodos"
        Me.cboperiodos.Size = New System.Drawing.Size(146, 21)
        Me.cboperiodos.TabIndex = 29
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 151)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(397, 28)
        Me.Panel3.TabIndex = 200
        '
        'chkMayoriza_0
        '
        Me.chkMayoriza_0.AutoSize = True
        Me.chkMayoriza_0.Location = New System.Drawing.Point(6, 18)
        Me.chkMayoriza_0.Name = "chkMayoriza_0"
        Me.chkMayoriza_0.Size = New System.Drawing.Size(65, 17)
        Me.chkMayoriza_0.TabIndex = 201
        Me.chkMayoriza_0.Text = "Cuentas"
        Me.chkMayoriza_0.UseVisualStyleBackColor = True
        '
        'chkMayoriza_1
        '
        Me.chkMayoriza_1.AutoSize = True
        Me.chkMayoriza_1.Enabled = False
        Me.chkMayoriza_1.Location = New System.Drawing.Point(6, 36)
        Me.chkMayoriza_1.Name = "chkMayoriza_1"
        Me.chkMayoriza_1.Size = New System.Drawing.Size(107, 17)
        Me.chkMayoriza_1.TabIndex = 202
        Me.chkMayoriza_1.Text = "Centros de Costo"
        Me.chkMayoriza_1.UseVisualStyleBackColor = True
        '
        'chkMayoriza_2
        '
        Me.chkMayoriza_2.AutoSize = True
        Me.chkMayoriza_2.Enabled = False
        Me.chkMayoriza_2.Location = New System.Drawing.Point(6, 54)
        Me.chkMayoriza_2.Name = "chkMayoriza_2"
        Me.chkMayoriza_2.Size = New System.Drawing.Size(116, 17)
        Me.chkMayoriza_2.TabIndex = 203
        Me.chkMayoriza_2.Text = "Centros de Gestión"
        Me.chkMayoriza_2.UseVisualStyleBackColor = True
        '
        'chkMayoriza_3
        '
        Me.chkMayoriza_3.AutoSize = True
        Me.chkMayoriza_3.Enabled = False
        Me.chkMayoriza_3.Location = New System.Drawing.Point(6, 72)
        Me.chkMayoriza_3.Name = "chkMayoriza_3"
        Me.chkMayoriza_3.Size = New System.Drawing.Size(125, 17)
        Me.chkMayoriza_3.TabIndex = 204
        Me.chkMayoriza_3.Text = "Centros de Directorio"
        Me.chkMayoriza_3.UseVisualStyleBackColor = True
        '
        'chkMayoriza_4
        '
        Me.chkMayoriza_4.AutoSize = True
        Me.chkMayoriza_4.Enabled = False
        Me.chkMayoriza_4.Location = New System.Drawing.Point(6, 90)
        Me.chkMayoriza_4.Name = "chkMayoriza_4"
        Me.chkMayoriza_4.Size = New System.Drawing.Size(121, 17)
        Me.chkMayoriza_4.TabIndex = 205
        Me.chkMayoriza_4.Text = "Ajustes por Inflación"
        Me.chkMayoriza_4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkMayoriza_0)
        Me.GroupBox1.Controls.Add(Me.chkMayoriza_4)
        Me.GroupBox1.Controls.Add(Me.chkMayoriza_1)
        Me.GroupBox1.Controls.Add(Me.chkMayoriza_3)
        Me.GroupBox1.Controls.Add(Me.chkMayoriza_2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(156, 112)
        Me.GroupBox1.TabIndex = 206
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mayorizar"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboperiodos)
        Me.GroupBox2.Location = New System.Drawing.Point(176, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(212, 58)
        Me.GroupBox2.TabIndex = 207
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodo"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(172, 104)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(214, 32)
        Me.ProgressBar1.TabIndex = 208
        '
        'Frm_mayoriza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 179)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_mayoriza"
        Me.Text = "Frm_mayoriza"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnInicia As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkMayoriza_0 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMayoriza_1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMayoriza_2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMayoriza_3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMayoriza_4 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
