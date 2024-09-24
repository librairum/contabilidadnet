<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EEGGyPP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_EEGGyPP))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnConfigurar = New System.Windows.Forms.Button()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.btvistaprevia = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.rbtEstado_0 = New System.Windows.Forms.RadioButton()
        Me.cboperiodos = New System.Windows.Forms.ComboBox()
        Me.rbtEstado_1 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbttiprepcom_1 = New System.Windows.Forms.RadioButton()
        Me.rbttiprepcom_0 = New System.Windows.Forms.RadioButton()
        Me.tabEGyP = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblconsulta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tblconsulta_1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tblconsulta_2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.rbttiprepcom_1_PLE = New System.Windows.Forms.RadioButton()
        Me.rbttiprepcom_0_PLE = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.tabEGyP.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblconsulta_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.tblconsulta_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnConfigurar)
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btvistaprevia)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(903, 47)
        Me.Panel1.TabIndex = 206
        '
        'btnConfigurar
        '
        Me.btnConfigurar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnConfigurar.Image = Global.ContabilidadNet.My.Resources.Resources.Configurar
        Me.btnConfigurar.Location = New System.Drawing.Point(6, 0)
        Me.btnConfigurar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnConfigurar.Name = "btnConfigurar"
        Me.btnConfigurar.Size = New System.Drawing.Size(36, 37)
        Me.btnConfigurar.TabIndex = 53
        Me.btnConfigurar.UseVisualStyleBackColor = True
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(453, 3)
        Me.btnimprimir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(36, 37)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(417, 3)
        Me.btvistaprevia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(36, 37)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(987, 3)
        Me.btnsalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(36, 37)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'rbtEstado_0
        '
        Me.rbtEstado_0.AutoSize = True
        Me.rbtEstado_0.Checked = True
        Me.rbtEstado_0.Location = New System.Drawing.Point(21, 15)
        Me.rbtEstado_0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtEstado_0.Name = "rbtEstado_0"
        Me.rbtEstado_0.Size = New System.Drawing.Size(184, 24)
        Me.rbtEstado_0.TabIndex = 32
        Me.rbtEstado_0.TabStop = True
        Me.rbtEstado_0.Text = "GG y PP Por Función"
        Me.rbtEstado_0.UseVisualStyleBackColor = True
        '
        'cboperiodos
        '
        Me.cboperiodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperiodos.FormattingEnabled = True
        Me.cboperiodos.Location = New System.Drawing.Point(78, 52)
        Me.cboperiodos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboperiodos.Name = "cboperiodos"
        Me.cboperiodos.Size = New System.Drawing.Size(175, 28)
        Me.cboperiodos.TabIndex = 31
        '
        'rbtEstado_1
        '
        Me.rbtEstado_1.AutoSize = True
        Me.rbtEstado_1.Location = New System.Drawing.Point(222, 15)
        Me.rbtEstado_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtEstado_1.Name = "rbtEstado_1"
        Me.rbtEstado_1.Size = New System.Drawing.Size(204, 24)
        Me.rbtEstado_1.TabIndex = 33
        Me.rbtEstado_1.Text = "GG y PP Por Naturaleza"
        Me.rbtEstado_1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 514)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(903, 43)
        Me.Panel3.TabIndex = 207
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 20)
        Me.Label1.TabIndex = 211
        Me.Label1.Text = "Periodo"
        '
        'rbttiprepcom_1
        '
        Me.rbttiprepcom_1.AutoSize = True
        Me.rbttiprepcom_1.Location = New System.Drawing.Point(207, 15)
        Me.rbttiprepcom_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbttiprepcom_1.Name = "rbttiprepcom_1"
        Me.rbttiprepcom_1.Size = New System.Drawing.Size(204, 24)
        Me.rbttiprepcom_1.TabIndex = 33
        Me.rbttiprepcom_1.Text = "GG y PP Por Naturaleza"
        Me.rbttiprepcom_1.UseVisualStyleBackColor = True
        '
        'rbttiprepcom_0
        '
        Me.rbttiprepcom_0.AutoSize = True
        Me.rbttiprepcom_0.Checked = True
        Me.rbttiprepcom_0.Location = New System.Drawing.Point(21, 15)
        Me.rbttiprepcom_0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbttiprepcom_0.Name = "rbttiprepcom_0"
        Me.rbttiprepcom_0.Size = New System.Drawing.Size(184, 24)
        Me.rbttiprepcom_0.TabIndex = 32
        Me.rbttiprepcom_0.TabStop = True
        Me.rbttiprepcom_0.Text = "GG y PP Por Función"
        Me.rbttiprepcom_0.UseVisualStyleBackColor = True
        '
        'tabEGyP
        '
        Me.tabEGyP.Controls.Add(Me.TabPage1)
        Me.tabEGyP.Controls.Add(Me.TabPage2)
        Me.tabEGyP.Controls.Add(Me.TabPage3)
        Me.tabEGyP.Location = New System.Drawing.Point(9, 86)
        Me.tabEGyP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabEGyP.Name = "tabEGyP"
        Me.tabEGyP.SelectedIndex = 0
        Me.tabEGyP.Size = New System.Drawing.Size(861, 418)
        Me.tabEGyP.TabIndex = 213
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.rbtEstado_1)
        Me.TabPage1.Controls.Add(Me.tblconsulta)
        Me.TabPage1.Controls.Add(Me.rbtEstado_0)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Size = New System.Drawing.Size(853, 385)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Normal"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.tblconsulta.Location = New System.Drawing.Point(6, 49)
        Me.tblconsulta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tblconsulta.Name = "tblconsulta"
        Me.tblconsulta.PictureCurrentRow = CType(resources.GetObject("tblconsulta.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta.Size = New System.Drawing.Size(755, 319)
        Me.tblconsulta.TabIndex = 211
        Me.tblconsulta.TabStop = False
        Me.tblconsulta.Text = "C1TrueDBGrid1"
        Me.tblconsulta.UseColumnStyles = False
        Me.tblconsulta.PropBag = resources.GetString("tblconsulta.PropBag")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tblconsulta_1)
        Me.TabPage2.Controls.Add(Me.rbttiprepcom_1)
        Me.TabPage2.Controls.Add(Me.rbttiprepcom_0)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Size = New System.Drawing.Size(853, 385)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Comparativo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tblconsulta_1
        '
        Me.tblconsulta_1.AllowUpdate = False
        Me.tblconsulta_1.AllowUpdateOnBlur = False
        Me.tblconsulta_1.AlternatingRows = True
        Me.tblconsulta_1.FilterBar = True
        Me.tblconsulta_1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_1.Images.Add(CType(resources.GetObject("tblconsulta_1.Images"), System.Drawing.Image))
        Me.tblconsulta_1.LinesPerRow = 1
        Me.tblconsulta_1.Location = New System.Drawing.Point(21, 55)
        Me.tblconsulta_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tblconsulta_1.Name = "tblconsulta_1"
        Me.tblconsulta_1.PictureCurrentRow = CType(resources.GetObject("tblconsulta_1.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_1.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_1.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_1.Size = New System.Drawing.Size(791, 270)
        Me.tblconsulta_1.TabIndex = 322
        Me.tblconsulta_1.TabStop = False
        Me.tblconsulta_1.Text = "C1TrueDBGrid1"
        Me.tblconsulta_1.UseColumnStyles = False
        Me.tblconsulta_1.PropBag = resources.GetString("tblconsulta_1.PropBag")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tblconsulta_2)
        Me.TabPage3.Controls.Add(Me.rbttiprepcom_1_PLE)
        Me.TabPage3.Controls.Add(Me.rbttiprepcom_0_PLE)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(853, 385)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Comparativo - PLE"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tblconsulta_2
        '
        Me.tblconsulta_2.AllowUpdate = False
        Me.tblconsulta_2.AllowUpdateOnBlur = False
        Me.tblconsulta_2.AlternatingRows = True
        Me.tblconsulta_2.FilterBar = True
        Me.tblconsulta_2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblconsulta_2.Images.Add(CType(resources.GetObject("tblconsulta_2.Images"), System.Drawing.Image))
        Me.tblconsulta_2.LinesPerRow = 1
        Me.tblconsulta_2.Location = New System.Drawing.Point(20, 58)
        Me.tblconsulta_2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tblconsulta_2.Name = "tblconsulta_2"
        Me.tblconsulta_2.PictureCurrentRow = CType(resources.GetObject("tblconsulta_2.PictureCurrentRow"), System.Drawing.Image)
        Me.tblconsulta_2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblconsulta_2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblconsulta_2.PreviewInfo.ZoomFactor = 75.0R
        Me.tblconsulta_2.PrintInfo.PageSettings = CType(resources.GetObject("tblconsulta_2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblconsulta_2.Size = New System.Drawing.Size(791, 270)
        Me.tblconsulta_2.TabIndex = 325
        Me.tblconsulta_2.TabStop = False
        Me.tblconsulta_2.Text = "C1TrueDBGrid1"
        Me.tblconsulta_2.UseColumnStyles = False
        Me.tblconsulta_2.PropBag = resources.GetString("tblconsulta_2.PropBag")
        '
        'rbttiprepcom_1_PLE
        '
        Me.rbttiprepcom_1_PLE.AutoSize = True
        Me.rbttiprepcom_1_PLE.Location = New System.Drawing.Point(206, 18)
        Me.rbttiprepcom_1_PLE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbttiprepcom_1_PLE.Name = "rbttiprepcom_1_PLE"
        Me.rbttiprepcom_1_PLE.Size = New System.Drawing.Size(204, 24)
        Me.rbttiprepcom_1_PLE.TabIndex = 324
        Me.rbttiprepcom_1_PLE.Text = "GG y PP Por Naturaleza"
        Me.rbttiprepcom_1_PLE.UseVisualStyleBackColor = True
        '
        'rbttiprepcom_0_PLE
        '
        Me.rbttiprepcom_0_PLE.AutoSize = True
        Me.rbttiprepcom_0_PLE.Checked = True
        Me.rbttiprepcom_0_PLE.Location = New System.Drawing.Point(20, 18)
        Me.rbttiprepcom_0_PLE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbttiprepcom_0_PLE.Name = "rbttiprepcom_0_PLE"
        Me.rbttiprepcom_0_PLE.Size = New System.Drawing.Size(184, 24)
        Me.rbttiprepcom_0_PLE.TabIndex = 323
        Me.rbttiprepcom_0_PLE.TabStop = True
        Me.rbttiprepcom_0_PLE.Text = "GG y PP Por Función"
        Me.rbttiprepcom_0_PLE.UseVisualStyleBackColor = True
        '
        'Frm_EEGGyPP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 557)
        Me.Controls.Add(Me.tabEGyP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cboperiodos)
        Me.Controls.Add(Me.Panel3)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Frm_EEGGyPP"
        Me.Text = "Frm_EEGGyPP"
        Me.Panel1.ResumeLayout(False)
        Me.tabEGyP.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.tblconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.tblconsulta_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.tblconsulta_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents rbtEstado_0 As System.Windows.Forms.RadioButton
    Friend WithEvents cboperiodos As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbtEstado_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConfigurar As System.Windows.Forms.Button
    Friend WithEvents rbttiprepcom_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbttiprepcom_0 As System.Windows.Forms.RadioButton
    Friend WithEvents tabEGyP As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta_1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents tblconsulta_2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents rbttiprepcom_1_PLE As System.Windows.Forms.RadioButton
    Friend WithEvents rbttiprepcom_0_PLE As System.Windows.Forms.RadioButton
End Class
