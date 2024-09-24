<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Usuarios_CambioPassword
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
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword_2 = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPassword_0 = New Ks.UserControl.ksTextBox()
        Me.txtPassword_1 = New Ks.UserControl.ksTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtusuario = New Ks.UserControl.ksTextBox()
        Me.txtnombreusario = New Ks.UserControl.ksTextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(296, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(6, 0)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 5
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 148)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(330, 26)
        Me.Panel3.TabIndex = 148
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 29)
        Me.Panel1.TabIndex = 146
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPassword_2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtPassword_0)
        Me.GroupBox1.Controls.Add(Me.txtPassword_1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 86)
        Me.GroupBox1.TabIndex = 150
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Confirme Password"
        '
        'txtPassword_2
        '
        Me.txtPassword_2.Location = New System.Drawing.Point(146, 62)
        Me.txtPassword_2.Name = "txtPassword_2"
        Me.txtPassword_2.NroDecimales = CType(0, Short)
        Me.txtPassword_2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword_2.SelectGotFocus = True
        Me.txtPassword_2.Size = New System.Drawing.Size(92, 20)
        Me.txtPassword_2.TabIndex = 41
        Me.txtPassword_2.Tabulado = True
        Me.txtPassword_2.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Nuevo Password"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(50, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Password Anterior"
        '
        'txtPassword_0
        '
        Me.txtPassword_0.Location = New System.Drawing.Point(146, 18)
        Me.txtPassword_0.Name = "txtPassword_0"
        Me.txtPassword_0.NroDecimales = CType(0, Short)
        Me.txtPassword_0.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtPassword_0.SelectGotFocus = True
        Me.txtPassword_0.Size = New System.Drawing.Size(92, 20)
        Me.txtPassword_0.TabIndex = 0
        Me.txtPassword_0.Tabulado = True
        Me.txtPassword_0.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtPassword_1
        '
        Me.txtPassword_1.Location = New System.Drawing.Point(146, 40)
        Me.txtPassword_1.Name = "txtPassword_1"
        Me.txtPassword_1.NroDecimales = CType(0, Short)
        Me.txtPassword_1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword_1.SelectGotFocus = True
        Me.txtPassword_1.Size = New System.Drawing.Size(92, 20)
        Me.txtPassword_1.TabIndex = 1
        Me.txtPassword_1.Tabulado = True
        Me.txtPassword_1.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Usuario"
        '
        'txtusuario
        '
        Me.txtusuario.Enabled = False
        Me.txtusuario.Location = New System.Drawing.Point(50, 32)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.NroDecimales = CType(0, Short)
        Me.txtusuario.SelectGotFocus = True
        Me.txtusuario.Size = New System.Drawing.Size(88, 20)
        Me.txtusuario.TabIndex = 153
        Me.txtusuario.Tabulado = True
        Me.txtusuario.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtnombreusario
        '
        Me.txtnombreusario.Enabled = False
        Me.txtnombreusario.Location = New System.Drawing.Point(140, 32)
        Me.txtnombreusario.Name = "txtnombreusario"
        Me.txtnombreusario.NroDecimales = CType(0, Short)
        Me.txtnombreusario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtnombreusario.SelectGotFocus = True
        Me.txtnombreusario.Size = New System.Drawing.Size(182, 20)
        Me.txtnombreusario.TabIndex = 154
        Me.txtnombreusario.Tabulado = True
        Me.txtnombreusario.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'Frm_Usuarios_CambioPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 174)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.txtnombreusario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Usuarios_CambioPassword"
        Me.Text = "Frm_Usuarios_CambioPassword"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword_2 As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPassword_0 As KS.UserControl.ksTextBox
    Friend WithEvents txtPassword_1 As KS.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtusuario As KS.UserControl.ksTextBox
    Friend WithEvents txtnombreusario As KS.UserControl.ksTextBox
End Class
