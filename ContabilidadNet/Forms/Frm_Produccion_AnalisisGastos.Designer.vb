<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Produccion_AnalisisGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Produccion_AnalisisGastos))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbtreporte_0 = New System.Windows.Forms.RadioButton
        Me.rbtreporte_1 = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnimprimir = New System.Windows.Forms.Button
        Me.btvistaprevia = New System.Windows.Forms.Button
        Me.btnsalir = New System.Windows.Forms.Button
        Me.tblPlanCuentas_0 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.rbttraecuentas_1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbttraecuentas_2 = New System.Windows.Forms.RadioButton
        Me.rbttraecuentas_0 = New System.Windows.Forms.RadioButton
        Me.tabareas = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnseleccionartodo_0 = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnseleccionartodo_1 = New System.Windows.Forms.Button
        Me.tblPlanCuentas_1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btnseleccionartodo_2 = New System.Windows.Forms.Button
        Me.tblPlanCuentas_2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tabgastos = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.btnseleccionartodo_3 = New System.Windows.Forms.Button
        Me.tblPlanCuentas_3 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.btnseleccionartodo_4 = New System.Windows.Forms.Button
        Me.tblPlanCuentas_4 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tblagrupa = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txttitulo = New KS.UserControl.ksTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tblPlanCuentas_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tabareas.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblPlanCuentas_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.tblPlanCuentas_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabgastos.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.tblPlanCuentas_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.tblPlanCuentas_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblagrupa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtreporte_0)
        Me.GroupBox3.Controls.Add(Me.rbtreporte_1)
        Me.GroupBox3.Location = New System.Drawing.Point(404, 54)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 36)
        Me.GroupBox3.TabIndex = 220
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opcion de reporte"
        '
        'rbtreporte_0
        '
        Me.rbtreporte_0.AutoSize = True
        Me.rbtreporte_0.Checked = True
        Me.rbtreporte_0.Location = New System.Drawing.Point(4, 14)
        Me.rbtreporte_0.Name = "rbtreporte_0"
        Me.rbtreporte_0.Size = New System.Drawing.Size(92, 17)
        Me.rbtreporte_0.TabIndex = 8
        Me.rbtreporte_0.TabStop = True
        Me.rbtreporte_0.Text = "Saldo por mes"
        Me.rbtreporte_0.UseVisualStyleBackColor = True
        '
        'rbtreporte_1
        '
        Me.rbtreporte_1.AutoSize = True
        Me.rbtreporte_1.Location = New System.Drawing.Point(102, 16)
        Me.rbtreporte_1.Name = "rbtreporte_1"
        Me.rbtreporte_1.Size = New System.Drawing.Size(111, 17)
        Me.rbtreporte_1.TabIndex = 6
        Me.rbtreporte_1.Text = "Acumulado al mes"
        Me.rbtreporte_1.UseVisualStyleBackColor = True
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
        Me.Panel1.Size = New System.Drawing.Size(753, 31)
        Me.Panel1.TabIndex = 215
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = Global.ContabilidadNet.My.Resources.Resources.printer
        Me.btnimprimir.Location = New System.Drawing.Point(352, 2)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(24, 24)
        Me.btnimprimir.TabIndex = 13
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btvistaprevia
        '
        Me.btvistaprevia.Image = Global.ContabilidadNet.My.Resources.Resources.preview
        Me.btvistaprevia.Location = New System.Drawing.Point(330, 2)
        Me.btvistaprevia.Name = "btvistaprevia"
        Me.btvistaprevia.Size = New System.Drawing.Size(24, 24)
        Me.btvistaprevia.TabIndex = 12
        Me.btvistaprevia.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.ContabilidadNet.My.Resources.Resources.salir
        Me.btnsalir.Location = New System.Drawing.Point(718, 2)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(24, 24)
        Me.btnsalir.TabIndex = 20
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'tblPlanCuentas_0
        '
        Me.tblPlanCuentas_0.AllowUpdate = False
        Me.tblPlanCuentas_0.AllowUpdateOnBlur = False
        Me.tblPlanCuentas_0.AlternatingRows = True
        Me.tblPlanCuentas_0.FilterBar = True
        Me.tblPlanCuentas_0.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblPlanCuentas_0.Images.Add(CType(resources.GetObject("tblPlanCuentas_0.Images"), System.Drawing.Image))
        Me.tblPlanCuentas_0.LinesPerRow = 1
        Me.tblPlanCuentas_0.Location = New System.Drawing.Point(2, 4)
        Me.tblPlanCuentas_0.Name = "tblPlanCuentas_0"
        Me.tblPlanCuentas_0.PictureCurrentRow = CType(resources.GetObject("tblPlanCuentas_0.PictureCurrentRow"), System.Drawing.Image)
        Me.tblPlanCuentas_0.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblPlanCuentas_0.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblPlanCuentas_0.PreviewInfo.ZoomFactor = 75
        Me.tblPlanCuentas_0.PrintInfo.PageSettings = CType(resources.GetObject("tblPlanCuentas_0.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblPlanCuentas_0.Size = New System.Drawing.Size(372, 194)
        Me.tblPlanCuentas_0.TabIndex = 219
        Me.tblPlanCuentas_0.TabStop = False
        Me.tblPlanCuentas_0.Text = "C1TrueDBGrid1"
        Me.tblPlanCuentas_0.UseColumnStyles = False
        Me.tblPlanCuentas_0.PropBag = resources.GetString("tblPlanCuentas_0.PropBag")
        '
        'rbttraecuentas_1
        '
        Me.rbttraecuentas_1.AutoSize = True
        Me.rbttraecuentas_1.Location = New System.Drawing.Point(74, 9)
        Me.rbttraecuentas_1.Name = "rbttraecuentas_1"
        Me.rbttraecuentas_1.Size = New System.Drawing.Size(132, 17)
        Me.rbttraecuentas_1.TabIndex = 6
        Me.rbttraecuentas_1.Text = "Gastos no Distribuibles"
        Me.rbttraecuentas_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbttraecuentas_2)
        Me.GroupBox2.Controls.Add(Me.rbttraecuentas_0)
        Me.GroupBox2.Controls.Add(Me.rbttraecuentas_1)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 26)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        '
        'rbttraecuentas_2
        '
        Me.rbttraecuentas_2.AutoSize = True
        Me.rbttraecuentas_2.Location = New System.Drawing.Point(218, 9)
        Me.rbttraecuentas_2.Name = "rbttraecuentas_2"
        Me.rbttraecuentas_2.Size = New System.Drawing.Size(135, 17)
        Me.rbttraecuentas_2.TabIndex = 9
        Me.rbttraecuentas_2.Text = "Gastos Distribuibles(91)"
        Me.rbttraecuentas_2.UseVisualStyleBackColor = True
        '
        'rbttraecuentas_0
        '
        Me.rbttraecuentas_0.AutoSize = True
        Me.rbttraecuentas_0.Checked = True
        Me.rbttraecuentas_0.Location = New System.Drawing.Point(10, 9)
        Me.rbttraecuentas_0.Name = "rbttraecuentas_0"
        Me.rbttraecuentas_0.Size = New System.Drawing.Size(55, 17)
        Me.rbttraecuentas_0.TabIndex = 8
        Me.rbttraecuentas_0.TabStop = True
        Me.rbttraecuentas_0.Text = "Todas"
        Me.rbttraecuentas_0.UseVisualStyleBackColor = True
        '
        'tabareas
        '
        Me.tabareas.Controls.Add(Me.TabPage1)
        Me.tabareas.Controls.Add(Me.TabPage2)
        Me.tabareas.Controls.Add(Me.TabPage3)
        Me.tabareas.Location = New System.Drawing.Point(18, 188)
        Me.tabareas.Name = "tabareas"
        Me.tabareas.SelectedIndex = 0
        Me.tabareas.Size = New System.Drawing.Size(388, 230)
        Me.tabareas.TabIndex = 221
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnseleccionartodo_0)
        Me.TabPage1.Controls.Add(Me.tblPlanCuentas_0)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(380, 204)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Area"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_0
        '
        Me.btnseleccionartodo_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_0.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_0.Location = New System.Drawing.Point(3, 5)
        Me.btnseleccionartodo_0.Name = "btnseleccionartodo_0"
        Me.btnseleccionartodo_0.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_0.TabIndex = 234
        Me.btnseleccionartodo_0.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnseleccionartodo_1)
        Me.TabPage2.Controls.Add(Me.tblPlanCuentas_1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(380, 204)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Seccion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_1
        '
        Me.btnseleccionartodo_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_1.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_1.Location = New System.Drawing.Point(6, 4)
        Me.btnseleccionartodo_1.Name = "btnseleccionartodo_1"
        Me.btnseleccionartodo_1.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_1.TabIndex = 234
        Me.btnseleccionartodo_1.UseVisualStyleBackColor = True
        '
        'tblPlanCuentas_1
        '
        Me.tblPlanCuentas_1.AllowUpdate = False
        Me.tblPlanCuentas_1.AllowUpdateOnBlur = False
        Me.tblPlanCuentas_1.AlternatingRows = True
        Me.tblPlanCuentas_1.FilterBar = True
        Me.tblPlanCuentas_1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblPlanCuentas_1.Images.Add(CType(resources.GetObject("tblPlanCuentas_1.Images"), System.Drawing.Image))
        Me.tblPlanCuentas_1.LinesPerRow = 1
        Me.tblPlanCuentas_1.Location = New System.Drawing.Point(4, 2)
        Me.tblPlanCuentas_1.Name = "tblPlanCuentas_1"
        Me.tblPlanCuentas_1.PictureCurrentRow = CType(resources.GetObject("tblPlanCuentas_1.PictureCurrentRow"), System.Drawing.Image)
        Me.tblPlanCuentas_1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblPlanCuentas_1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblPlanCuentas_1.PreviewInfo.ZoomFactor = 75
        Me.tblPlanCuentas_1.PrintInfo.PageSettings = CType(resources.GetObject("tblPlanCuentas_1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblPlanCuentas_1.Size = New System.Drawing.Size(374, 200)
        Me.tblPlanCuentas_1.TabIndex = 220
        Me.tblPlanCuentas_1.TabStop = False
        Me.tblPlanCuentas_1.Text = "C1TrueDBGrid1"
        Me.tblPlanCuentas_1.UseColumnStyles = False
        Me.tblPlanCuentas_1.PropBag = resources.GetString("tblPlanCuentas_1.PropBag")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnseleccionartodo_2)
        Me.TabPage3.Controls.Add(Me.tblPlanCuentas_2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(380, 204)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "C.Costos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_2
        '
        Me.btnseleccionartodo_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_2.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_2.Location = New System.Drawing.Point(4, 4)
        Me.btnseleccionartodo_2.Name = "btnseleccionartodo_2"
        Me.btnseleccionartodo_2.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_2.TabIndex = 234
        Me.btnseleccionartodo_2.UseVisualStyleBackColor = True
        '
        'tblPlanCuentas_2
        '
        Me.tblPlanCuentas_2.AllowUpdate = False
        Me.tblPlanCuentas_2.AllowUpdateOnBlur = False
        Me.tblPlanCuentas_2.AlternatingRows = True
        Me.tblPlanCuentas_2.FilterBar = True
        Me.tblPlanCuentas_2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblPlanCuentas_2.Images.Add(CType(resources.GetObject("tblPlanCuentas_2.Images"), System.Drawing.Image))
        Me.tblPlanCuentas_2.LinesPerRow = 1
        Me.tblPlanCuentas_2.Location = New System.Drawing.Point(2, 2)
        Me.tblPlanCuentas_2.Name = "tblPlanCuentas_2"
        Me.tblPlanCuentas_2.PictureCurrentRow = CType(resources.GetObject("tblPlanCuentas_2.PictureCurrentRow"), System.Drawing.Image)
        Me.tblPlanCuentas_2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblPlanCuentas_2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblPlanCuentas_2.PreviewInfo.ZoomFactor = 75
        Me.tblPlanCuentas_2.PrintInfo.PageSettings = CType(resources.GetObject("tblPlanCuentas_2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblPlanCuentas_2.Size = New System.Drawing.Size(372, 200)
        Me.tblPlanCuentas_2.TabIndex = 220
        Me.tblPlanCuentas_2.TabStop = False
        Me.tblPlanCuentas_2.Text = "C1TrueDBGrid1"
        Me.tblPlanCuentas_2.UseColumnStyles = False
        Me.tblPlanCuentas_2.PropBag = resources.GetString("tblPlanCuentas_2.PropBag")
        '
        'tabgastos
        '
        Me.tabgastos.Controls.Add(Me.TabPage4)
        Me.tabgastos.Controls.Add(Me.TabPage5)
        Me.tabgastos.Location = New System.Drawing.Point(412, 189)
        Me.tabgastos.Name = "tabgastos"
        Me.tabgastos.SelectedIndex = 0
        Me.tabgastos.Size = New System.Drawing.Size(338, 226)
        Me.tabgastos.TabIndex = 222
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnseleccionartodo_3)
        Me.TabPage4.Controls.Add(Me.tblPlanCuentas_3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(330, 200)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Tipo de Gasto"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_3
        '
        Me.btnseleccionartodo_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_3.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_3.Location = New System.Drawing.Point(8, 6)
        Me.btnseleccionartodo_3.Name = "btnseleccionartodo_3"
        Me.btnseleccionartodo_3.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_3.TabIndex = 234
        Me.btnseleccionartodo_3.UseVisualStyleBackColor = True
        '
        'tblPlanCuentas_3
        '
        Me.tblPlanCuentas_3.AllowUpdate = False
        Me.tblPlanCuentas_3.AllowUpdateOnBlur = False
        Me.tblPlanCuentas_3.AlternatingRows = True
        Me.tblPlanCuentas_3.FilterBar = True
        Me.tblPlanCuentas_3.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblPlanCuentas_3.Images.Add(CType(resources.GetObject("tblPlanCuentas_3.Images"), System.Drawing.Image))
        Me.tblPlanCuentas_3.LinesPerRow = 1
        Me.tblPlanCuentas_3.Location = New System.Drawing.Point(6, 4)
        Me.tblPlanCuentas_3.Name = "tblPlanCuentas_3"
        Me.tblPlanCuentas_3.PictureCurrentRow = CType(resources.GetObject("tblPlanCuentas_3.PictureCurrentRow"), System.Drawing.Image)
        Me.tblPlanCuentas_3.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblPlanCuentas_3.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblPlanCuentas_3.PreviewInfo.ZoomFactor = 75
        Me.tblPlanCuentas_3.PrintInfo.PageSettings = CType(resources.GetObject("tblPlanCuentas_3.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblPlanCuentas_3.Size = New System.Drawing.Size(324, 192)
        Me.tblPlanCuentas_3.TabIndex = 219
        Me.tblPlanCuentas_3.TabStop = False
        Me.tblPlanCuentas_3.Text = "C1TrueDBGrid1"
        Me.tblPlanCuentas_3.UseColumnStyles = False
        Me.tblPlanCuentas_3.PropBag = resources.GetString("tblPlanCuentas_3.PropBag")
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.btnseleccionartodo_4)
        Me.TabPage5.Controls.Add(Me.tblPlanCuentas_4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(330, 200)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Gasto"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'btnseleccionartodo_4
        '
        Me.btnseleccionartodo_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnseleccionartodo_4.Image = Global.ContabilidadNet.My.Resources.Resources.Seleccionartodo
        Me.btnseleccionartodo_4.Location = New System.Drawing.Point(8, 6)
        Me.btnseleccionartodo_4.Name = "btnseleccionartodo_4"
        Me.btnseleccionartodo_4.Size = New System.Drawing.Size(16, 16)
        Me.btnseleccionartodo_4.TabIndex = 236
        Me.btnseleccionartodo_4.UseVisualStyleBackColor = True
        '
        'tblPlanCuentas_4
        '
        Me.tblPlanCuentas_4.AllowUpdate = False
        Me.tblPlanCuentas_4.AllowUpdateOnBlur = False
        Me.tblPlanCuentas_4.AlternatingRows = True
        Me.tblPlanCuentas_4.FilterBar = True
        Me.tblPlanCuentas_4.GroupByCaption = "Drag a column header here to group by that column"
        Me.tblPlanCuentas_4.Images.Add(CType(resources.GetObject("tblPlanCuentas_4.Images"), System.Drawing.Image))
        Me.tblPlanCuentas_4.LinesPerRow = 1
        Me.tblPlanCuentas_4.Location = New System.Drawing.Point(6, 4)
        Me.tblPlanCuentas_4.Name = "tblPlanCuentas_4"
        Me.tblPlanCuentas_4.PictureCurrentRow = CType(resources.GetObject("tblPlanCuentas_4.PictureCurrentRow"), System.Drawing.Image)
        Me.tblPlanCuentas_4.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblPlanCuentas_4.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblPlanCuentas_4.PreviewInfo.ZoomFactor = 75
        Me.tblPlanCuentas_4.PrintInfo.PageSettings = CType(resources.GetObject("tblPlanCuentas_4.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblPlanCuentas_4.Size = New System.Drawing.Size(318, 194)
        Me.tblPlanCuentas_4.TabIndex = 220
        Me.tblPlanCuentas_4.TabStop = False
        Me.tblPlanCuentas_4.Text = "C1TrueDBGrid4"
        Me.tblPlanCuentas_4.UseColumnStyles = False
        Me.tblPlanCuentas_4.PropBag = resources.GetString("tblPlanCuentas_4.PropBag")
        '
        'tblagrupa
        '
        Me.tblagrupa.AllowFilter = False
        Me.tblagrupa.AllowUpdate = False
        Me.tblagrupa.AllowUpdateOnBlur = False
        Me.tblagrupa.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.tblagrupa.GroupByCaption = "Arrastre el orden de agrupamiento"
        Me.tblagrupa.Images.Add(CType(resources.GetObject("tblagrupa.Images"), System.Drawing.Image))
        Me.tblagrupa.LinesPerRow = 1
        Me.tblagrupa.Location = New System.Drawing.Point(8, 13)
        Me.tblagrupa.Name = "tblagrupa"
        Me.tblagrupa.PictureCurrentRow = CType(resources.GetObject("tblagrupa.PictureCurrentRow"), System.Drawing.Image)
        Me.tblagrupa.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tblagrupa.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tblagrupa.PreviewInfo.ZoomFactor = 75
        Me.tblagrupa.PrintInfo.PageSettings = CType(resources.GetObject("tblagrupa.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tblagrupa.Size = New System.Drawing.Size(366, 80)
        Me.tblagrupa.TabIndex = 232
        Me.tblagrupa.TabStop = False
        Me.tblagrupa.Text = "C1TrueDBGrid1"
        Me.tblagrupa.UseColumnStyles = False
        Me.tblagrupa.PropBag = resources.GetString("tblagrupa.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tblagrupa)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 96)
        Me.GroupBox1.TabIndex = 233
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agrupar por"
        '
        'txttitulo
        '
        Me.txttitulo.Location = New System.Drawing.Point(56, 32)
        Me.txttitulo.Name = "txttitulo"
        Me.txttitulo.NroDecimales = CType(0, Short)
        Me.txttitulo.SelectGotFocus = True
        Me.txttitulo.Size = New System.Drawing.Size(688, 20)
        Me.txttitulo.TabIndex = 234
        Me.txttitulo.Tabulado = True
        Me.txttitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txttitulo.ValorAceptado = KS.UserControl.ValorPermitido.enmVTodos
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "Titulo"
        '
        'Frm_Produccion_AnalisisGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 422)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txttitulo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tabgastos)
        Me.Controls.Add(Me.tabareas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Frm_Produccion_AnalisisGastos"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tblPlanCuentas_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabareas.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tblPlanCuentas_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.tblPlanCuentas_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabgastos.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.tblPlanCuentas_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.tblPlanCuentas_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblagrupa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtreporte_0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtreporte_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btvistaprevia As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents tblPlanCuentas_0 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents rbttraecuentas_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbttraecuentas_0 As System.Windows.Forms.RadioButton
    Friend WithEvents tabareas As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tblPlanCuentas_1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents tblPlanCuentas_2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tabgastos As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents tblPlanCuentas_3 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents tblPlanCuentas_4 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents rbttraecuentas_2 As System.Windows.Forms.RadioButton
    Friend WithEvents tblagrupa As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txttitulo As KS.UserControl.ksTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnseleccionartodo_0 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_1 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_2 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_3 As System.Windows.Forms.Button
    Friend WithEvents btnseleccionartodo_4 As System.Windows.Forms.Button
End Class
