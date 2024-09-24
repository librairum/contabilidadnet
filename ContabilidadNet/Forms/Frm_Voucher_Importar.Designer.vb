<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Voucher_Importar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Voucher_Importar))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnvalidar = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tblvalidacion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblvalidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnvalidar)
        Me.Panel1.Controls.Add(Me.btnImportar)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 30)
        Me.Panel1.TabIndex = 145
        '
        'btnvalidar
        '
        Me.btnvalidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnvalidar.Image = Global.ContabilidadNet.My.Resources.Resources.Verificarcuentas
        Me.btnvalidar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnvalidar.Location = New System.Drawing.Point(154, 1)
        Me.btnvalidar.Name = "btnvalidar"
        Me.btnvalidar.Size = New System.Drawing.Size(179, 24)
        Me.btnvalidar.TabIndex = 24
        Me.btnvalidar.Text = "Validar Inconsistencias"
        Me.btnvalidar.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = Global.ContabilidadNet.My.Resources.Resources.ejecutar
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnImportar.Location = New System.Drawing.Point(6, 1)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(134, 24)
        Me.btnImportar.TabIndex = 23
        Me.btnImportar.Text = "Importar Archivo"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(902, 0)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 22
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(880, 0)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 21
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 660)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(946, 26)
        Me.Panel3.TabIndex = 147
        '
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdate = False
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images1"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images2"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(6, 72)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(930, 294)
        Me.tblconsulta.TabIndex = 146
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 373)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(361, 17)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "Listado de validacion de errores por importacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 17)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Registros Importados"
        '
        'tblvalidacion
        '
        Me.tblvalidacion.AllowUpdate = False
        Me.tblvalidacion.AllowUpdateOnBlur = False
        Me.tblvalidacion.AlternatingRows = True
        Me.tblvalidacion.FilterBar = True
        Me.tblvalidacion.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblvalidacion.Images.Add(CType(resources.GetObject("tblvalidacion.Images"), System.Drawing.Image))
        Me.tblvalidacion.Images.Add(CType(resources.GetObject("tblvalidacion.Images1"), System.Drawing.Image))
        Me.tblvalidacion.Images.Add(CType(resources.GetObject("tblvalidacion.Images2"), System.Drawing.Image))
        Me.tblvalidacion.LinesPerRow = 1
        Me.tblvalidacion.Location = New System.Drawing.Point(5, 394)
        Me.tblvalidacion.Name = "tblvalidacion"
        Me.tblvalidacion.PictureCurrentRow = CType(resources.GetObject("tblvalidacion.PictureCurrentRow"), System.Drawing.Image)
        Me.tblvalidacion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblvalidacion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblvalidacion.PreviewInfo.ZoomFactor = 75.0R
        Me.tblvalidacion.PrintInfo.PageSettings = CType(resources.GetObject("tblvalidacion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblvalidacion.Size = New System.Drawing.Size(930, 260)
        Me.tblvalidacion.TabIndex = 151
        Me.tblvalidacion.TabStop = False
        Me.tblvalidacion.Text = "C1TrueDBGrid1"
        Me.tblvalidacion.UseColumnStyles = False
        Me.tblvalidacion.PropBag = resources.GetString("tblvalidacion.PropBag")
        '
        'Frm_Voucher_Importar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 686)
        Me.Controls.Add(Me.tblvalidacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tblconsulta)
        Me.Name = "Frm_Voucher_Importar"
        Me.Text = "Frm_Voucher_Importar"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblvalidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnvalidar As System.Windows.Forms.Button
    Friend WithEvents tblvalidacion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
