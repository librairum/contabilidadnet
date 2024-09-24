<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EEFF_Comp
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbttraecuentas_2 = New System.Windows.Forms.RadioButton()
        Me.rbttraecuentas_0 = New System.Windows.Forms.RadioButton()
        Me.rbttraecuentas_1 = New System.Windows.Forms.RadioButton()
        Me.cboPeriodos = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbttipoacum_1 = New System.Windows.Forms.RadioButton()
        Me.rbttipoacum_0 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbttraecuentas_2)
        Me.GroupBox2.Controls.Add(Me.rbttraecuentas_0)
        Me.GroupBox2.Controls.Add(Me.rbttraecuentas_1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 94)
        Me.GroupBox2.TabIndex = 207
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selecione opcion"
        '
        'rbttraecuentas_2
        '
        Me.rbttraecuentas_2.AutoSize = True
        Me.rbttraecuentas_2.Location = New System.Drawing.Point(8, 66)
        Me.rbttraecuentas_2.Name = "rbttraecuentas_2"
        Me.rbttraecuentas_2.Size = New System.Drawing.Size(124, 17)
        Me.rbttraecuentas_2.TabIndex = 203
        Me.rbttraecuentas_2.Text = "EGyP por Naturaleza"
        Me.rbttraecuentas_2.UseVisualStyleBackColor = True
        '
        'rbttraecuentas_0
        '
        Me.rbttraecuentas_0.AutoSize = True
        Me.rbttraecuentas_0.Checked = True
        Me.rbttraecuentas_0.Location = New System.Drawing.Point(8, 21)
        Me.rbttraecuentas_0.Name = "rbttraecuentas_0"
        Me.rbttraecuentas_0.Size = New System.Drawing.Size(104, 17)
        Me.rbttraecuentas_0.TabIndex = 201
        Me.rbttraecuentas_0.TabStop = True
        Me.rbttraecuentas_0.Text = "Balance General"
        Me.rbttraecuentas_0.UseVisualStyleBackColor = True
        '
        'rbttraecuentas_1
        '
        Me.rbttraecuentas_1.AutoSize = True
        Me.rbttraecuentas_1.Location = New System.Drawing.Point(8, 44)
        Me.rbttraecuentas_1.Name = "rbttraecuentas_1"
        Me.rbttraecuentas_1.Size = New System.Drawing.Size(111, 17)
        Me.rbttraecuentas_1.TabIndex = 202
        Me.rbttraecuentas_1.Text = "EGyP por Funcion"
        Me.rbttraecuentas_1.UseVisualStyleBackColor = True
        '
        'cboPeriodos
        '
        Me.cboPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodos.FormattingEnabled = True
        Me.cboPeriodos.Location = New System.Drawing.Point(8, 18)
        Me.cboPeriodos.Name = "cboPeriodos"
        Me.cboPeriodos.Size = New System.Drawing.Size(166, 21)
        Me.cboPeriodos.TabIndex = 29
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPeriodos)
        Me.GroupBox1.Location = New System.Drawing.Point(198, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 44)
        Me.GroupBox1.TabIndex = 206
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(200, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 137)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(388, 28)
        Me.Panel3.TabIndex = 205
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(178, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
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
        Me.Panel1.Size = New System.Drawing.Size(388, 33)
        Me.Panel1.TabIndex = 204
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(356, 4)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbttipoacum_1)
        Me.GroupBox3.Controls.Add(Me.rbttipoacum_0)
        Me.GroupBox3.Location = New System.Drawing.Point(198, 83)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(182, 47)
        Me.GroupBox3.TabIndex = 208
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seleccione opcion"
        '
        'rbttipoacum_1
        '
        Me.rbttipoacum_1.AutoSize = True
        Me.rbttipoacum_1.Checked = True
        Me.rbttipoacum_1.Location = New System.Drawing.Point(94, 24)
        Me.rbttipoacum_1.Name = "rbttipoacum_1"
        Me.rbttipoacum_1.Size = New System.Drawing.Size(77, 17)
        Me.rbttipoacum_1.TabIndex = 203
        Me.rbttipoacum_1.TabStop = True
        Me.rbttipoacum_1.Text = "Mes a Mes"
        Me.rbttipoacum_1.UseVisualStyleBackColor = True
        '
        'rbttipoacum_0
        '
        Me.rbttipoacum_0.AutoSize = True
        Me.rbttipoacum_0.Checked = True
        Me.rbttipoacum_0.Location = New System.Drawing.Point(12, 24)
        Me.rbttipoacum_0.Name = "rbttipoacum_0"
        Me.rbttipoacum_0.Size = New System.Drawing.Size(78, 17)
        Me.rbttipoacum_0.TabIndex = 202
        Me.rbttipoacum_0.TabStop = True
        Me.rbttipoacum_0.Text = "Acumalado"
        Me.rbttipoacum_0.UseVisualStyleBackColor = True
        '
        'Frm_EEFF_Comp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 165)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_EEFF_Comp"
        Me.Text = "Frm_EEFF_Comp"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbttraecuentas_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbttraecuentas_1 As System.Windows.Forms.RadioButton
    Friend WithEvents cboPeriodos As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents rbttraecuentas_2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbttipoacum_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbttipoacum_0 As System.Windows.Forms.RadioButton
End Class
