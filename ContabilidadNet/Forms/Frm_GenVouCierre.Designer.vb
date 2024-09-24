<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GenVouCierre
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
        Me.txtTipCamAperPas = New Ks.UserControl.ksTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipCamAperAct = New Ks.UserControl.ksTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txttipocambio = New Ks.UserControl.ksTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtProceso_2 = New System.Windows.Forms.RadioButton()
        Me.rbtProceso_0 = New System.Windows.Forms.RadioButton()
        Me.rbtProceso_1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Ks.UserControl.ksTextBox()
        Me.txtfecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnhelp_0 = New System.Windows.Forms.Button()
        Me.lblhelp_0 = New System.Windows.Forms.Label()
        Me.txtlibro = New Ks.UserControl.ksTextBox()
        Me.cboPeriodos = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTipCamAperPas)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtTipCamAperAct)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txttipocambio)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.rbtProceso_2)
        Me.GroupBox2.Controls.Add(Me.rbtProceso_0)
        Me.GroupBox2.Controls.Add(Me.rbtProceso_1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(194, 160)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de proceso"
        '
        'txtTipCamAperPas
        '
        Me.txtTipCamAperPas.Location = New System.Drawing.Point(101, 131)
        Me.txtTipCamAperPas.Name = "txtTipCamAperPas"
        Me.txtTipCamAperPas.NroDecimales = CType(4, Short)
        Me.txtTipCamAperPas.SelectGotFocus = True
        Me.txtTipCamAperPas.Size = New System.Drawing.Size(74, 20)
        Me.txtTipCamAperPas.TabIndex = 200
        Me.txtTipCamAperPas.Tabulado = True
        Me.txtTipCamAperPas.Text = "0.0000"
        Me.txtTipCamAperPas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipCamAperPas.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "T.Cambio"
        '
        'txtTipCamAperAct
        '
        Me.txtTipCamAperAct.Location = New System.Drawing.Point(101, 109)
        Me.txtTipCamAperAct.Name = "txtTipCamAperAct"
        Me.txtTipCamAperAct.NroDecimales = CType(4, Short)
        Me.txtTipCamAperAct.SelectGotFocus = True
        Me.txtTipCamAperAct.Size = New System.Drawing.Size(74, 20)
        Me.txtTipCamAperAct.TabIndex = 198
        Me.txtTipCamAperAct.Tabulado = True
        Me.txtTipCamAperAct.Text = "0.0000"
        Me.txtTipCamAperAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipCamAperAct.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "T.Cambio"
        '
        'txttipocambio
        '
        Me.txttipocambio.Location = New System.Drawing.Point(104, 40)
        Me.txttipocambio.Name = "txttipocambio"
        Me.txttipocambio.NroDecimales = CType(4, Short)
        Me.txttipocambio.SelectGotFocus = True
        Me.txttipocambio.Size = New System.Drawing.Size(74, 20)
        Me.txttipocambio.TabIndex = 196
        Me.txttipocambio.Tabulado = True
        Me.txttipocambio.Text = "0.0000"
        Me.txttipocambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttipocambio.ValorAceptado = Ks.UserControl.ValorPermitido.enmVNumero
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 197
        Me.Label1.Text = "T.Cambio"
        '
        'rbtProceso_2
        '
        Me.rbtProceso_2.AutoSize = True
        Me.rbtProceso_2.Location = New System.Drawing.Point(9, 87)
        Me.rbtProceso_2.Name = "rbtProceso_2"
        Me.rbtProceso_2.Size = New System.Drawing.Size(158, 17)
        Me.rbtProceso_2.TabIndex = 2
        Me.rbtProceso_2.Text = "Ajustar Por Saldo de Cuenta"
        Me.rbtProceso_2.UseVisualStyleBackColor = True
        '
        'rbtProceso_0
        '
        Me.rbtProceso_0.AutoSize = True
        Me.rbtProceso_0.Checked = True
        Me.rbtProceso_0.Location = New System.Drawing.Point(8, 20)
        Me.rbtProceso_0.Name = "rbtProceso_0"
        Me.rbtProceso_0.Size = New System.Drawing.Size(139, 17)
        Me.rbtProceso_0.TabIndex = 0
        Me.rbtProceso_0.TabStop = True
        Me.rbtProceso_0.Text = "Ajustar Por Documentos"
        Me.rbtProceso_0.UseVisualStyleBackColor = True
        '
        'rbtProceso_1
        '
        Me.rbtProceso_1.AutoSize = True
        Me.rbtProceso_1.Location = New System.Drawing.Point(8, 64)
        Me.rbtProceso_1.Name = "rbtProceso_1"
        Me.rbtProceso_1.Size = New System.Drawing.Size(158, 17)
        Me.rbtProceso_1.TabIndex = 1
        Me.rbtProceso_1.Text = "Ajustar Por Saldo de Cuenta"
        Me.rbtProceso_1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtDescripcion)
        Me.GroupBox3.Controls.Add(Me.txtfecha)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.btnhelp_0)
        Me.GroupBox3.Controls.Add(Me.lblhelp_0)
        Me.GroupBox3.Controls.Add(Me.txtlibro)
        Me.GroupBox3.Controls.Add(Me.cboPeriodos)
        Me.GroupBox3.Location = New System.Drawing.Point(216, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(501, 160)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos del voucher a generar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 219
        Me.Label7.Text = "Descripcion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 218
        Me.Label6.Text = "Descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(74, 109)
        Me.txtDescripcion.MaxLength = 80
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.NroDecimales = CType(0, Short)
        Me.txtDescripcion.SelectGotFocus = True
        Me.txtDescripcion.Size = New System.Drawing.Size(256, 45)
        Me.txtDescripcion.TabIndex = 217
        Me.txtDescripcion.Tabulado = True
        Me.txtDescripcion.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'txtfecha
        '
        Me.txtfecha.Location = New System.Drawing.Point(74, 85)
        Me.txtfecha.Mask = "00/00/0000"
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(68, 20)
        Me.txtfecha.TabIndex = 216
        Me.txtfecha.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 215
        Me.Label5.Text = "Periodo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "Libro"
        '
        'btnhelp_0
        '
        Me.btnhelp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnhelp_0.Location = New System.Drawing.Point(78, 59)
        Me.btnhelp_0.Name = "btnhelp_0"
        Me.btnhelp_0.Size = New System.Drawing.Size(22, 22)
        Me.btnhelp_0.TabIndex = 214
        Me.btnhelp_0.Text = ":::"
        Me.btnhelp_0.UseVisualStyleBackColor = True
        '
        'lblhelp_0
        '
        Me.lblhelp_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblhelp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblhelp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblhelp_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblhelp_0.Location = New System.Drawing.Point(104, 59)
        Me.lblhelp_0.Name = "lblhelp_0"
        Me.lblhelp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhelp_0.Size = New System.Drawing.Size(98, 18)
        Me.lblhelp_0.TabIndex = 212
        Me.lblhelp_0.Text = "???"
        '
        'txtlibro
        '
        Me.txtlibro.Location = New System.Drawing.Point(50, 59)
        Me.txtlibro.Name = "txtlibro"
        Me.txtlibro.NroDecimales = CType(0, Short)
        Me.txtlibro.SelectGotFocus = True
        Me.txtlibro.Size = New System.Drawing.Size(28, 20)
        Me.txtlibro.TabIndex = 211
        Me.txtlibro.Tabulado = True
        Me.txtlibro.ValorAceptado = Ks.UserControl.ValorPermitido.enmVTodos
        '
        'cboPeriodos
        '
        Me.cboPeriodos.FormattingEnabled = True
        Me.cboPeriodos.Location = New System.Drawing.Point(57, 26)
        Me.cboPeriodos.Name = "cboPeriodos"
        Me.cboPeriodos.Size = New System.Drawing.Size(121, 21)
        Me.cboPeriodos.TabIndex = 0
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
        Me.Panel1.Size = New System.Drawing.Size(731, 31)
        Me.Panel1.TabIndex = 6
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(258, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(234, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(668, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 219)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(731, 26)
        Me.Panel3.TabIndex = 197
        '
        'Frm_GenVouCierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 245)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Frm_GenVouCierre"
        Me.Text = "Frm_GenVouCierre"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtProceso_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtProceso_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbtProceso_2 As System.Windows.Forms.RadioButton
    Friend WithEvents txtTipCamAperPas As KS.UserControl.ksTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTipCamAperAct As KS.UserControl.ksTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttipocambio As KS.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPeriodos As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnhelp_0 As System.Windows.Forms.Button
    Public WithEvents lblhelp_0 As System.Windows.Forms.Label
    Friend WithEvents txtlibro As Ks.UserControl.ksTextBox
    Friend WithEvents txtfecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As Ks.UserControl.ksTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
