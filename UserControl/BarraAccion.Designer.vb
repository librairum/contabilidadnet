<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarraAccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarraAccion))
        Me.ilComun = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tbRefrescar = New System.Windows.Forms.ToolStripButton
        Me.tbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tbEditar = New System.Windows.Forms.ToolStripButton
        Me.tbEliminar = New System.Windows.Forms.ToolStripButton
        Me.tbDetalle = New System.Windows.Forms.ToolStripButton
        Me.tbBuscar = New System.Windows.Forms.ToolStripButton
        Me.tbPreliminar = New System.Windows.Forms.ToolStripButton
        Me.tbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tbExcel = New System.Windows.Forms.ToolStripButton
        Me.tbGenerar = New System.Windows.Forms.ToolStripButton
        Me.tbGuardar = New System.Windows.Forms.ToolStripButton
        Me.tbCancelar = New System.Windows.Forms.ToolStripButton
        Me.tbConfirmar = New System.Windows.Forms.ToolStripButton
        Me.tbReversar = New System.Windows.Forms.ToolStripButton
        Me.tbAnular = New System.Windows.Forms.ToolStripButton
        Me.tbAyuda = New System.Windows.Forms.ToolStripButton
        Me.tbSalir = New System.Windows.Forms.ToolStripButton
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
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbRefrescar, Me.tbNuevo, Me.tbEditar, Me.tbEliminar, Me.tbDetalle, Me.tbBuscar, Me.tbPreliminar, Me.tbImprimir, Me.tbExcel, Me.tbGenerar, Me.tbGuardar, Me.tbCancelar, Me.tbConfirmar, Me.tbReversar, Me.tbAnular, Me.tbAyuda, Me.tbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(512, 44)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbRefrescar
        '
        Me.tbRefrescar.Image = CType(resources.GetObject("tbRefrescar.Image"), System.Drawing.Image)
        Me.tbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbRefrescar.Name = "tbRefrescar"
        Me.tbRefrescar.Size = New System.Drawing.Size(57, 41)
        Me.tbRefrescar.Tag = "Refrescar"
        Me.tbRefrescar.Text = "Refrescar"
        Me.tbRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbRefrescar.ToolTipText = "Refrescar"
        '
        'tbNuevo
        '
        Me.tbNuevo.Image = CType(resources.GetObject("tbNuevo.Image"), System.Drawing.Image)
        Me.tbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbNuevo.Name = "tbNuevo"
        Me.tbNuevo.Size = New System.Drawing.Size(43, 41)
        Me.tbNuevo.Tag = "Nuevo"
        Me.tbNuevo.Text = "Nuevo"
        Me.tbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbNuevo.ToolTipText = "Nuevo"
        '
        'tbEditar
        '
        Me.tbEditar.Image = CType(resources.GetObject("tbEditar.Image"), System.Drawing.Image)
        Me.tbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbEditar.Name = "tbEditar"
        Me.tbEditar.Size = New System.Drawing.Size(38, 41)
        Me.tbEditar.Tag = "Editar"
        Me.tbEditar.Text = "Editar"
        Me.tbEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbEditar.ToolTipText = "Editar"
        '
        'tbEliminar
        '
        Me.tbEliminar.Image = CType(resources.GetObject("tbEliminar.Image"), System.Drawing.Image)
        Me.tbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbEliminar.Name = "tbEliminar"
        Me.tbEliminar.Size = New System.Drawing.Size(47, 41)
        Me.tbEliminar.Tag = "Eliminar"
        Me.tbEliminar.Text = "Eliminar"
        Me.tbEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbEliminar.ToolTipText = "Eliminar"
        '
        'tbDetalle
        '
        Me.tbDetalle.Image = CType(resources.GetObject("tbDetalle.Image"), System.Drawing.Image)
        Me.tbDetalle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbDetalle.Name = "tbDetalle"
        Me.tbDetalle.Size = New System.Drawing.Size(37, 41)
        Me.tbDetalle.Text = "Ficha"
        Me.tbDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbDetalle.Visible = False
        '
        'tbBuscar
        '
        Me.tbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbBuscar.Image = CType(resources.GetObject("tbBuscar.Image"), System.Drawing.Image)
        Me.tbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(28, 41)
        Me.tbBuscar.Tag = "Buscar"
        Me.tbBuscar.ToolTipText = "Filtrar"
        Me.tbBuscar.Visible = False
        '
        'tbPreliminar
        '
        Me.tbPreliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbPreliminar.Image = CType(resources.GetObject("tbPreliminar.Image"), System.Drawing.Image)
        Me.tbPreliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbPreliminar.Name = "tbPreliminar"
        Me.tbPreliminar.Size = New System.Drawing.Size(28, 41)
        Me.tbPreliminar.Tag = "Preliminar"
        Me.tbPreliminar.ToolTipText = "Preliminar"
        Me.tbPreliminar.Visible = False
        '
        'tbImprimir
        '
        Me.tbImprimir.Image = CType(resources.GetObject("tbImprimir.Image"), System.Drawing.Image)
        Me.tbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbImprimir.Name = "tbImprimir"
        Me.tbImprimir.Size = New System.Drawing.Size(46, 41)
        Me.tbImprimir.Tag = "Imprimir"
        Me.tbImprimir.Text = "Imprimir"
        Me.tbImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbImprimir.ToolTipText = "Imprimir"
        Me.tbImprimir.Visible = False
        '
        'tbExcel
        '
        Me.tbExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbExcel.Image = CType(resources.GetObject("tbExcel.Image"), System.Drawing.Image)
        Me.tbExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbExcel.Name = "tbExcel"
        Me.tbExcel.Size = New System.Drawing.Size(28, 41)
        Me.tbExcel.Tag = "Excel"
        Me.tbExcel.Text = "ToolStripButton1"
        Me.tbExcel.ToolTipText = "Exportar a excel"
        Me.tbExcel.Visible = False
        '
        'tbGenerar
        '
        Me.tbGenerar.Image = CType(resources.GetObject("tbGenerar.Image"), System.Drawing.Image)
        Me.tbGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbGenerar.Name = "tbGenerar"
        Me.tbGenerar.Size = New System.Drawing.Size(49, 41)
        Me.tbGenerar.Tag = "Generar"
        Me.tbGenerar.Text = "Generar"
        Me.tbGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbGenerar.ToolTipText = "Generar"
        Me.tbGenerar.Visible = False
        '
        'tbGuardar
        '
        Me.tbGuardar.Image = CType(resources.GetObject("tbGuardar.Image"), System.Drawing.Image)
        Me.tbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbGuardar.Name = "tbGuardar"
        Me.tbGuardar.Size = New System.Drawing.Size(49, 41)
        Me.tbGuardar.Tag = "Guardar"
        Me.tbGuardar.Text = "Guardar"
        Me.tbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbGuardar.ToolTipText = "Guardar"
        '
        'tbCancelar
        '
        Me.tbCancelar.Image = CType(resources.GetObject("tbCancelar.Image"), System.Drawing.Image)
        Me.tbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbCancelar.Name = "tbCancelar"
        Me.tbCancelar.Size = New System.Drawing.Size(53, 41)
        Me.tbCancelar.Tag = "Cancelar"
        Me.tbCancelar.Text = "Cancelar"
        Me.tbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbCancelar.ToolTipText = "Cancelar"
        '
        'tbConfirmar
        '
        Me.tbConfirmar.Image = CType(resources.GetObject("tbConfirmar.Image"), System.Drawing.Image)
        Me.tbConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbConfirmar.Name = "tbConfirmar"
        Me.tbConfirmar.Size = New System.Drawing.Size(55, 41)
        Me.tbConfirmar.Tag = "Confirmar"
        Me.tbConfirmar.Text = "Confirmar"
        Me.tbConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbConfirmar.ToolTipText = "Confirmar"
        Me.tbConfirmar.Visible = False
        '
        'tbReversar
        '
        Me.tbReversar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.00885!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbReversar.Image = CType(resources.GetObject("tbReversar.Image"), System.Drawing.Image)
        Me.tbReversar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbReversar.Name = "tbReversar"
        Me.tbReversar.Size = New System.Drawing.Size(53, 41)
        Me.tbReversar.Tag = "Reversar"
        Me.tbReversar.Text = "Reversar"
        Me.tbReversar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbReversar.ToolTipText = "Reversar"
        Me.tbReversar.Visible = False
        '
        'tbAnular
        '
        Me.tbAnular.Image = CType(resources.GetObject("tbAnular.Image"), System.Drawing.Image)
        Me.tbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbAnular.Name = "tbAnular"
        Me.tbAnular.Size = New System.Drawing.Size(41, 41)
        Me.tbAnular.Tag = "Anular"
        Me.tbAnular.Text = "Anular"
        Me.tbAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.tbAnular.ToolTipText = "Anular"
        Me.tbAnular.Visible = False
        '
        'tbAyuda
        '
        Me.tbAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbAyuda.Image = CType(resources.GetObject("tbAyuda.Image"), System.Drawing.Image)
        Me.tbAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbAyuda.Name = "tbAyuda"
        Me.tbAyuda.Size = New System.Drawing.Size(28, 41)
        Me.tbAyuda.Tag = "Ayuda"
        Me.tbAyuda.ToolTipText = "Ayuda"
        Me.tbAyuda.Visible = False
        '
        'tbSalir
        '
        Me.tbSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbSalir.Image = CType(resources.GetObject("tbSalir.Image"), System.Drawing.Image)
        Me.tbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSalir.Name = "tbSalir"
        Me.tbSalir.Size = New System.Drawing.Size(31, 41)
        Me.tbSalir.Text = "Salir"
        Me.tbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'BarraAccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "BarraAccion"
        Me.Size = New System.Drawing.Size(512, 44)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilComun As System.Windows.Forms.ImageList
    Friend WithEvents tbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbDetalle As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbPreliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbConfirmar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbReversar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbSalir As System.Windows.Forms.ToolStripButton
    Protected WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip

End Class
