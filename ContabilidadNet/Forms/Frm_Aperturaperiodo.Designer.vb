<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Aperturaperiodo
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnInicia = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboanofin = New System.Windows.Forms.ComboBox()
        Me.cboanoorigen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 131)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(552, 28)
        Me.Panel3.TabIndex = 202
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
        Me.Panel1.Size = New System.Drawing.Size(552, 31)
        Me.Panel1.TabIndex = 201
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(518, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnInicia)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboanofin)
        Me.GroupBox1.Controls.Add(Me.cboanoorigen)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(538, 46)
        Me.GroupBox1.TabIndex = 203
        Me.GroupBox1.TabStop = False
        '
        'btnInicia
        '
        Me.btnInicia.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnInicia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnInicia.Location = New System.Drawing.Point(456, 17)
        Me.btnInicia.Name = "btnInicia"
        Me.btnInicia.Size = New System.Drawing.Size(74, 24)
        Me.btnInicia.TabIndex = 34
        Me.btnInicia.Text = "Procesar"
        Me.btnInicia.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnInicia.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(203, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Año Destino"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Año Origen"
        '
        'cboanofin
        '
        Me.cboanofin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboanofin.FormattingEnabled = True
        Me.cboanofin.Location = New System.Drawing.Point(270, 18)
        Me.cboanofin.Name = "cboanofin"
        Me.cboanofin.Size = New System.Drawing.Size(92, 21)
        Me.cboanofin.TabIndex = 31
        '
        'cboanoorigen
        '
        Me.cboanoorigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboanoorigen.FormattingEnabled = True
        Me.cboanoorigen.Location = New System.Drawing.Point(72, 18)
        Me.cboanoorigen.Name = "cboanoorigen"
        Me.cboanoorigen.Size = New System.Drawing.Size(94, 21)
        Me.cboanoorigen.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(374, 13)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "¡ Importante : Ejecute este proceso en horas de bajo concurrencia al sistema ¡"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(456, 558)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(374, 13)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "¡ Importante : Ejecute este proceso en horas de bajo concurrencia al sistema ¡"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(534, 13)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "¡ Importante :  NO EJECUTE este proceso SI esta implementando un Nuevo Plan de Cu" & _
    "entas en el Año Destino"
        '
        'Frm_Aperturaperiodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 159)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Aperturaperiodo"
        Me.Text = "Frm_Aperturaperiodo"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboanofin As System.Windows.Forms.ComboBox
    Friend WithEvents cboanoorigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnInicia As System.Windows.Forms.Button
End Class
