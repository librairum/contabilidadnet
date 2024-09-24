<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BalanceGeneral
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
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboPeriodos = New System.Windows.Forms.ComboBox()
        Me.btnConfigurar = New System.Windows.Forms.Button()
        Me.rbtformato_0 = New System.Windows.Forms.RadioButton()
        Me.rbtformato_1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtformato_1_PLE = New System.Windows.Forms.RadioButton()
        Me.btnConfigurarPLE = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(313, 33)
        Me.Panel1.TabIndex = 6
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(162, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(140, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(390, 4)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 181)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(313, 28)
        Me.Panel3.TabIndex = 199
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(15, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 6)
        Me.GroupBox1.TabIndex = 200
        Me.GroupBox1.TabStop = False
        '
        'cboPeriodos
        '
        Me.cboPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodos.FormattingEnabled = True
        Me.cboPeriodos.Location = New System.Drawing.Point(68, 36)
        Me.cboPeriodos.Name = "cboPeriodos"
        Me.cboPeriodos.Size = New System.Drawing.Size(180, 21)
        Me.cboPeriodos.TabIndex = 29
        '
        'btnConfigurar
        '
        Me.btnConfigurar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnConfigurar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfigurar.Location = New System.Drawing.Point(149, 40)
        Me.btnConfigurar.Name = "btnConfigurar"
        Me.btnConfigurar.Size = New System.Drawing.Size(75, 22)
        Me.btnConfigurar.TabIndex = 54
        Me.btnConfigurar.Text = "Configurar"
        Me.btnConfigurar.UseVisualStyleBackColor = True
        '
        'rbtformato_0
        '
        Me.rbtformato_0.AutoSize = True
        Me.rbtformato_0.Location = New System.Drawing.Point(5, 19)
        Me.rbtformato_0.Name = "rbtformato_0"
        Me.rbtformato_0.Size = New System.Drawing.Size(97, 17)
        Me.rbtformato_0.TabIndex = 201
        Me.rbtformato_0.Text = "Formato normal"
        Me.rbtformato_0.UseVisualStyleBackColor = True
        '
        'rbtformato_1
        '
        Me.rbtformato_1.AutoSize = True
        Me.rbtformato_1.Location = New System.Drawing.Point(5, 42)
        Me.rbtformato_1.Name = "rbtformato_1"
        Me.rbtformato_1.Size = New System.Drawing.Size(124, 17)
        Me.rbtformato_1.TabIndex = 202
        Me.rbtformato_1.Text = "Formato comparativo"
        Me.rbtformato_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtformato_1_PLE)
        Me.GroupBox2.Controls.Add(Me.btnConfigurar)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.btnConfigurarPLE)
        Me.GroupBox2.Controls.Add(Me.rbtformato_0)
        Me.GroupBox2.Controls.Add(Me.rbtformato_1)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(244, 110)
        Me.GroupBox2.TabIndex = 203
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Formatos"
        '
        'rbtformato_1_PLE
        '
        Me.rbtformato_1_PLE.AutoSize = True
        Me.rbtformato_1_PLE.Location = New System.Drawing.Point(5, 73)
        Me.rbtformato_1_PLE.Name = "rbtformato_1_PLE"
        Me.rbtformato_1_PLE.Size = New System.Drawing.Size(86, 17)
        Me.rbtformato_1_PLE.TabIndex = 205
        Me.rbtformato_1_PLE.Text = "Formato PLE"
        Me.rbtformato_1_PLE.UseVisualStyleBackColor = True
        '
        'btnConfigurarPLE
        '
        Me.btnConfigurarPLE.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnConfigurarPLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfigurarPLE.Location = New System.Drawing.Point(145, 75)
        Me.btnConfigurarPLE.Name = "btnConfigurarPLE"
        Me.btnConfigurarPLE.Size = New System.Drawing.Size(75, 22)
        Me.btnConfigurarPLE.TabIndex = 203
        Me.btnConfigurarPLE.Text = "Configurar"
        Me.btnConfigurarPLE.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "Periodo"
        '
        'Frm_BalanceGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 209)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPeriodos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_BalanceGeneral"
        Me.Text = "Frm_BalanceGeneral"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboPeriodos As System.Windows.Forms.ComboBox
    Friend WithEvents btnConfigurar As System.Windows.Forms.Button
    Friend WithEvents rbtformato_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtformato_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConfigurarPLE As System.Windows.Forms.Button
    Friend WithEvents rbtformato_1_PLE As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
