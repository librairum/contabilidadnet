<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ueBarraLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ueBarraLista))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tbNumeroRegistros = New System.Windows.Forms.ToolStripButton
        Me.txtRegistros = New System.Windows.Forms.ToolStripTextBox
        Me.tbBuscar = New System.Windows.Forms.ToolStripButton
        Me.tbFiltrar = New System.Windows.Forms.ToolStripButton
        Me.tbExcel = New System.Windows.Forms.ToolStripButton
        Me.tbImprimir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbNumeroRegistros, Me.txtRegistros, Me.tbBuscar, Me.tbFiltrar, Me.tbExcel, Me.tbImprimir})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 8)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(454, 31)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbNumeroRegistros
        '
        Me.tbNumeroRegistros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbNumeroRegistros.Image = CType(resources.GetObject("tbNumeroRegistros.Image"), System.Drawing.Image)
        Me.tbNumeroRegistros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbNumeroRegistros.Name = "tbNumeroRegistros"
        Me.tbNumeroRegistros.Size = New System.Drawing.Size(83, 28)
        Me.tbNumeroRegistros.Text = "N° de registros"
        '
        'txtRegistros
        '
        Me.txtRegistros.BackColor = System.Drawing.Color.White
        Me.txtRegistros.Name = "txtRegistros"
        Me.txtRegistros.ReadOnly = True
        Me.txtRegistros.Size = New System.Drawing.Size(50, 31)
        Me.txtRegistros.Text = "0"
        Me.txtRegistros.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbBuscar
        '
        Me.tbBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbBuscar.Image = CType(resources.GetObject("tbBuscar.Image"), System.Drawing.Image)
        Me.tbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(28, 28)
        Me.tbBuscar.Tag = "Buscar"
        Me.tbBuscar.ToolTipText = "Buscar"
        Me.tbBuscar.Visible = False
        '
        'tbFiltrar
        '
        Me.tbFiltrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbFiltrar.Image = CType(resources.GetObject("tbFiltrar.Image"), System.Drawing.Image)
        Me.tbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbFiltrar.Name = "tbFiltrar"
        Me.tbFiltrar.Size = New System.Drawing.Size(28, 28)
        Me.tbFiltrar.Tag = "Filtrar"
        Me.tbFiltrar.ToolTipText = "Filtrar"
        '
        'tbExcel
        '
        Me.tbExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbExcel.Image = CType(resources.GetObject("tbExcel.Image"), System.Drawing.Image)
        Me.tbExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbExcel.Name = "tbExcel"
        Me.tbExcel.Size = New System.Drawing.Size(28, 28)
        Me.tbExcel.Tag = "Excel"
        Me.tbExcel.ToolTipText = "Exportar a excel"
        '
        'tbImprimir
        '
        Me.tbImprimir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbImprimir.Image = CType(resources.GetObject("tbImprimir.Image"), System.Drawing.Image)
        Me.tbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbImprimir.Name = "tbImprimir"
        Me.tbImprimir.Size = New System.Drawing.Size(28, 28)
        Me.tbImprimir.Tag = "Imprimir"
        Me.tbImprimir.ToolTipText = "Imprimir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 8)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'ueBarraLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "ueBarraLista"
        Me.Size = New System.Drawing.Size(454, 39)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbNumeroRegistros As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtRegistros As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
