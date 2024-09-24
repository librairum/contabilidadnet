<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegistrarLib102CostoMensual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegistrarLib102CostoMensual))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btngrabar = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btn_help0 = New System.Windows.Forms.Button()
        Me.btnimportar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tblhelp_0 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblhelp_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 323)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1104, 31)
        Me.Panel3.TabIndex = 189
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btngrabar)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Controls.Add(Me.btn_help0)
        Me.Panel1.Controls.Add(Me.btnimportar)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1104, 33)
        Me.Panel1.TabIndex = 191
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ContabilidadNet.My.Resources.Resources.cancel
        Me.btncancelar.Location = New System.Drawing.Point(147, 4)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(24, 24)
        Me.btncancelar.TabIndex = 47
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = Global.ContabilidadNet.My.Resources.Resources.accept
        Me.btngrabar.Location = New System.Drawing.Point(125, 4)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(24, 24)
        Me.btngrabar.TabIndex = 46
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.ContabilidadNet.My.Resources.Resources.edit
        Me.btnmodificar.Location = New System.Drawing.Point(29, 3)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(24, 24)
        Me.btnmodificar.TabIndex = 48
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btn_help0
        '
        Me.btn_help0.Location = New System.Drawing.Point(187, 4)
        Me.btn_help0.Name = "btn_help0"
        Me.btn_help0.Size = New System.Drawing.Size(24, 24)
        Me.btn_help0.TabIndex = 45
        Me.btn_help0.UseVisualStyleBackColor = True
        '
        'btnimportar
        '
        Me.btnimportar.Image = Global.ContabilidadNet.My.Resources.Resources.Copy1
        Me.btnimportar.Location = New System.Drawing.Point(54, 3)
        Me.btnimportar.Name = "btnimportar"
        Me.btnimportar.Size = New System.Drawing.Size(24, 24)
        Me.btnimportar.TabIndex = 44
        Me.btnimportar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(711, 3)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'tblconsulta
        '
        Me.tblconsulta.AllowUpdateOnBlur = False
        Me.tblconsulta.AlternatingRows = True
        Me.tblconsulta.FetchRowStyles = True
        Me.tblconsulta.FilterBar = True
        Me.tblconsulta.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images1"), System.Drawing.Image))
        Me.tblconsulta.Images.Add(CType(resources.GetObject("tblconsulta.Images2"), System.Drawing.Image))
        Me.tblconsulta.LinesPerRow = 1
        Me.tblconsulta.Location = New System.Drawing.Point(9, 75)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.ScrollTips = True
        Me.tblconsulta.Size = New System.Drawing.Size(1083, 242)
        Me.tblconsulta.TabIndex = 201
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'tblhelp_0
        '
        Me.tblhelp_0.AllowUpdate = False
        Me.tblhelp_0.AllowUpdateOnBlur = False
        Me.tblhelp_0.AlternatingRows = True
        Me.tblhelp_0.FilterBar = True
        Me.tblhelp_0.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblhelp_0.Images.Add(CType(resources.GetObject("tblhelp_0.Images"), System.Drawing.Image))
        Me.tblhelp_0.LinesPerRow = 1
        Me.tblhelp_0.Location = New System.Drawing.Point(337, 38)
        Me.tblhelp_0.Name = "tblhelp_0"
        Me.tblhelp_0.PictureCurrentRow = CType(resources.GetObject("tblhelp_0.PictureCurrentRow"), System.Drawing.Image)
        Me.tblhelp_0.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblhelp_0.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblhelp_0.PreviewInfo.ZoomFactor = 75.0R
        Me.tblhelp_0.PrintInfo.PageSettings = CType(resources.GetObject("tblhelp_0.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblhelp_0.Size = New System.Drawing.Size(308, 130)
        Me.tblhelp_0.TabIndex = 254
        Me.tblhelp_0.TabStop = False
        Me.tblhelp_0.Text = "C1TrueDBGrid1"
        Me.tblhelp_0.UseColumnStyles = False
        Me.tblhelp_0.Visible = False
        Me.tblhelp_0.PropBag = resources.GetString("tblhelp_0.PropBag")
        '
        'Frm_RegistrarLib102CostoMensual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1104, 354)
        Me.Controls.Add(Me.tblhelp_0)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tblconsulta)
        Me.Name = "Frm_RegistrarLib102CostoMensual"
        Me.Text = "Lib 102 - Registro Costo Mensual"
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblhelp_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Public WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnimportar As System.Windows.Forms.Button
    Friend WithEvents btn_help0 As System.Windows.Forms.Button
    Friend WithEvents tblhelp_0 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button


End Class
