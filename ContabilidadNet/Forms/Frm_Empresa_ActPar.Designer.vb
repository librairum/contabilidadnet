<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Empresa_ActPar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Empresa_ActPar))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtejerActivo = New Ks.UserControl.ksTextBox()
        Me.btnmas = New System.Windows.Forms.Button()
        Me.btnmenos = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(278, 26)
        Me.Panel3.TabIndex = 231
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
        Me.Panel1.Size = New System.Drawing.Size(278, 31)
        Me.Panel1.TabIndex = 230
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(2, 0)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 17
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(250, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 233
        Me.Label1.Text = "Ejercicio activo"
        '
        'txtejerActivo
        '
        Me.txtejerActivo.Location = New System.Drawing.Point(104, 34)
        Me.txtejerActivo.MaxLength = 80
        Me.txtejerActivo.Multiline = True
        Me.txtejerActivo.Name = "txtejerActivo"
        Me.txtejerActivo.NroDecimales = CType(0, Short)
        Me.txtejerActivo.SelectGotFocus = True
        Me.txtejerActivo.Size = New System.Drawing.Size(70, 30)
        Me.txtejerActivo.TabIndex = 234
        Me.txtejerActivo.Tabulado = True
        Me.txtejerActivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtejerActivo.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'btnmas
        '
        Me.btnmas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnmas.Image = CType(resources.GetObject("btnmas.Image"), System.Drawing.Image)
        Me.btnmas.Location = New System.Drawing.Point(174, 34)
        Me.btnmas.Name = "btnmas"
        Me.btnmas.Size = New System.Drawing.Size(22, 16)
        Me.btnmas.TabIndex = 235
        Me.btnmas.UseVisualStyleBackColor = True
        '
        'btnmenos
        '
        Me.btnmenos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnmenos.Image = CType(resources.GetObject("btnmenos.Image"), System.Drawing.Image)
        Me.btnmenos.Location = New System.Drawing.Point(174, 50)
        Me.btnmenos.Name = "btnmenos"
        Me.btnmenos.Size = New System.Drawing.Size(22, 14)
        Me.btnmenos.TabIndex = 236
        Me.btnmenos.UseVisualStyleBackColor = True
        '
        'Frm_Empresa_ActPar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 95)
        Me.Controls.Add(Me.btnmenos)
        Me.Controls.Add(Me.btnmas)
        Me.Controls.Add(Me.txtejerActivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Empresa_ActPar"
        Me.Text = "Frm_Empresa_ActParametros"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtejerActivo As KS.UserControl.ksTextBox
    Friend WithEvents btnmas As System.Windows.Forms.Button
    Friend WithEvents btnmenos As System.Windows.Forms.Button
End Class
