﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Empresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Empresa))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnver = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCopiar = New System.Windows.Forms.Button()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 315)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 26)
        Me.Panel3.TabIndex = 150
        '
        'btnver
        '
        Me.btnver.Image = Global.ContabilidadNet.My.Resources.Resources.Detalles
        Me.btnver.Location = New System.Drawing.Point(65, 1)
        Me.btnver.Name = "btnver"
        Me.btnver.Size = New System.Drawing.Size(24, 24)
        Me.btnver.TabIndex = 15
        Me.btnver.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.ContabilidadNet.My.Resources.Resources.delete
        Me.btneliminar.Location = New System.Drawing.Point(44, 1)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(24, 24)
        Me.btneliminar.TabIndex = 14
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(23, 1)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 13
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.ContabilidadNet.My.Resources.Resources.add
        Me.btnnuevo.Location = New System.Drawing.Point(1, 1)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnnuevo.TabIndex = 12
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(440, 0)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdate = False
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(2, 38)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(460, 272)
        Me.tblconsulta.TabIndex = 149
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnCopiar)
        Me.Panel1.Controls.Add(Me.btnver)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 31)
        Me.Panel1.TabIndex = 148
        '
        'btnCopiar
        '
        Me.btnCopiar.Image = Global.ContabilidadNet.My.Resources.Resources.Copy1
        Me.btnCopiar.Location = New System.Drawing.Point(222, 2)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(24, 24)
        Me.btnCopiar.TabIndex = 44
        Me.btnCopiar.UseVisualStyleBackColor = True
        '
        'Frm_Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 341)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tblconsulta)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Empresa"
        Me.Text = "Frm_Empresa"
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnver As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
End Class
