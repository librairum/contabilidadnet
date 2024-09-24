<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ksBarraB
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ksBarraB))
        Me.ilComun = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cboCampo = New System.Windows.Forms.ToolStripComboBox
        Me.txtValor = New System.Windows.Forms.ToolStripTextBox
        Me.tbFiltrar = New System.Windows.Forms.ToolStripButton
        Me.tbBuscar = New System.Windows.Forms.ToolStripButton
        Me.tbRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ilComun
        '
        Me.ilComun.ImageStream = CType(resources.GetObject("ilComun.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilComun.TransparentColor = System.Drawing.Color.Transparent
        Me.ilComun.Images.SetKeyName(0, "")
        Me.ilComun.Images.SetKeyName(1, "")
        Me.ilComun.Images.SetKeyName(2, "")
        Me.ilComun.Images.SetKeyName(3, "")
        Me.ilComun.Images.SetKeyName(4, "")
        Me.ilComun.Images.SetKeyName(5, "")
        Me.ilComun.Images.SetKeyName(6, "")
        Me.ilComun.Images.SetKeyName(7, "")
        Me.ilComun.Images.SetKeyName(8, "")
        Me.ilComun.Images.SetKeyName(9, "")
        Me.ilComun.Images.SetKeyName(10, "")
        Me.ilComun.Images.SetKeyName(11, "")
        Me.ilComun.Images.SetKeyName(12, "")
        Me.ilComun.Images.SetKeyName(13, "")
        Me.ilComun.Images.SetKeyName(14, "")
        Me.ilComun.Images.SetKeyName(15, "")
        Me.ilComun.Images.SetKeyName(16, "")
        Me.ilComun.Images.SetKeyName(17, "")
        Me.ilComun.Images.SetKeyName(18, "")
        Me.ilComun.Images.SetKeyName(19, "")
        Me.ilComun.Images.SetKeyName(20, "")
        Me.ilComun.Images.SetKeyName(21, "")
        Me.ilComun.Images.SetKeyName(22, "")
        Me.ilComun.Images.SetKeyName(23, "")
        Me.ilComun.Images.SetKeyName(24, "")
        Me.ilComun.Images.SetKeyName(25, "")
        Me.ilComun.Images.SetKeyName(26, "")
        Me.ilComun.Images.SetKeyName(27, "")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.283186!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboCampo, Me.txtValor, Me.tbFiltrar, Me.tbBuscar, Me.tbRefrescar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(661, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(93, 22)
        Me.ToolStripLabel1.Text = "Consultar por"
        '
        'cboCampo
        '
        Me.cboCampo.BackColor = System.Drawing.Color.White
        Me.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCampo.DropDownWidth = 150
        Me.cboCampo.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cboCampo.Name = "cboCampo"
        Me.cboCampo.Size = New System.Drawing.Size(160, 25)
        Me.cboCampo.Tag = "Campo"
        Me.cboCampo.ToolTipText = "Seleccione campo"
        '
        'txtValor
        '
        Me.txtValor.BackColor = System.Drawing.Color.White
        Me.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(132, 25)
        Me.txtValor.Tag = "Valor"
        Me.txtValor.ToolTipText = "Ingrese valor"
        '
        'tbFiltrar
        '
        Me.tbFiltrar.Image = CType(resources.GetObject("tbFiltrar.Image"), System.Drawing.Image)
        Me.tbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbFiltrar.Name = "tbFiltrar"
        Me.tbFiltrar.Size = New System.Drawing.Size(64, 22)
        Me.tbFiltrar.Tag = "Filtrar"
        Me.tbFiltrar.Text = "Filtrar"
        Me.tbFiltrar.ToolTipText = "Filtrar"
        '
        'tbBuscar
        '
        Me.tbBuscar.Image = CType(resources.GetObject("tbBuscar.Image"), System.Drawing.Image)
        Me.tbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(72, 22)
        Me.tbBuscar.Tag = "Buscar"
        Me.tbBuscar.Text = "Buscar"
        '
        'tbRefrescar
        '
        Me.tbRefrescar.Image = CType(resources.GetObject("tbRefrescar.Image"), System.Drawing.Image)
        Me.tbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbRefrescar.Name = "tbRefrescar"
        Me.tbRefrescar.Size = New System.Drawing.Size(90, 22)
        Me.tbRefrescar.Text = "Actualizar"
        '
        'ksBarraB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ksBarraB"
        Me.Size = New System.Drawing.Size(661, 27)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilComun As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cboCampo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtValor As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tbFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tbBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbRefrescar As System.Windows.Forms.ToolStripButton

End Class
