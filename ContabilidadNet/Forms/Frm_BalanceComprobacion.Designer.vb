<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BalanceComprobacion
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboPeriodos = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbTipoBalance_1 = New System.Windows.Forms.RadioButton()
        Me.rdbTipoBalance_0 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkMovim = New System.Windows.Forms.CheckBox()
        Me.cbonivel = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPeriodos)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 46)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'cboPeriodos
        '
        Me.cboPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodos.FormattingEnabled = True
        Me.cboPeriodos.Location = New System.Drawing.Point(8, 18)
        Me.cboPeriodos.Name = "cboPeriodos"
        Me.cboPeriodos.Size = New System.Drawing.Size(184, 21)
        Me.cboPeriodos.TabIndex = 29
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbTipoBalance_1)
        Me.GroupBox2.Controls.Add(Me.rdbTipoBalance_0)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 68)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de balance"
        '
        'rdbTipoBalance_1
        '
        Me.rdbTipoBalance_1.AutoSize = True
        Me.rdbTipoBalance_1.Location = New System.Drawing.Point(12, 42)
        Me.rdbTipoBalance_1.Name = "rdbTipoBalance_1"
        Me.rdbTipoBalance_1.Size = New System.Drawing.Size(114, 17)
        Me.rdbTipoBalance_1.TabIndex = 1
        Me.rdbTipoBalance_1.TabStop = True
        Me.rdbTipoBalance_1.Text = "Balance de trabajo"
        Me.rdbTipoBalance_1.UseVisualStyleBackColor = True
        '
        'rdbTipoBalance_0
        '
        Me.rdbTipoBalance_0.AutoSize = True
        Me.rdbTipoBalance_0.Checked = True
        Me.rdbTipoBalance_0.Location = New System.Drawing.Point(12, 22)
        Me.rdbTipoBalance_0.Name = "rdbTipoBalance_0"
        Me.rdbTipoBalance_0.Size = New System.Drawing.Size(130, 17)
        Me.rdbTipoBalance_0.TabIndex = 0
        Me.rdbTipoBalance_0.TabStop = True
        Me.rdbTipoBalance_0.Text = "Balance de resultados"
        Me.rdbTipoBalance_0.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.chkMovim)
        Me.GroupBox3.Controls.Add(Me.cbonivel)
        Me.GroupBox3.Location = New System.Drawing.Point(208, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 116)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Imprimir Cuentas de"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "A nivel"
        '
        'chkMovim
        '
        Me.chkMovim.AutoSize = True
        Me.chkMovim.Checked = True
        Me.chkMovim.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMovim.Location = New System.Drawing.Point(10, 72)
        Me.chkMovim.Name = "chkMovim"
        Me.chkMovim.Size = New System.Drawing.Size(172, 17)
        Me.chkMovim.TabIndex = 30
        Me.chkMovim.Text = "Incluye cuentas de movimiento"
        Me.chkMovim.UseVisualStyleBackColor = True
        '
        'cbonivel
        '
        Me.cbonivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbonivel.FormattingEnabled = True
        Me.cbonivel.Items.AddRange(New Object() {"2", "3", "4", "5", "7", "9", "12", "Todos"})
        Me.cbonivel.Location = New System.Drawing.Point(52, 34)
        Me.cbonivel.Name = "cbonivel"
        Me.cbonivel.Size = New System.Drawing.Size(134, 21)
        Me.cbonivel.TabIndex = 29
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 32)
        Me.Panel1.TabIndex = 5
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(188, 3)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(376, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(164, 3)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 163)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(422, 28)
        Me.Panel3.TabIndex = 198
        '
        'Frm_BalanceComprobacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 191)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_BalanceComprobacion"
        Me.Text = "Frm_BalanceComprobacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboPeriodos As System.Windows.Forms.ComboBox
    Friend WithEvents rdbTipoBalance_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTipoBalance_0 As System.Windows.Forms.RadioButton
    Friend WithEvents chkMovim As System.Windows.Forms.CheckBox
    Friend WithEvents cbonivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
