Public Class ksDataGridView
    Inherits System.Windows.Forms.DataGridView

    Private docMenu As ContextMenuStrip

    Public Sub New()
        ' Invoco Contructor de la clase Base
        MyBase.New()
        InicializarControl()
    End Sub

    Private Sub InicializarControl()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle

        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.AllowUserToOrderColumns = True
        Me.AllowUserToResizeColumns = False
        Me.AllowUserToResizeRows = False
        Me.AutoGenerateColumns = False

        Me.BackgroundColor = System.Drawing.SystemColors.Control

        'Me.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))

        'Borde de Grilla
        'Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        Me.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText

        'Comentado
        'Me.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single

        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control

        'Color de columnas
        'Me.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue

        ' DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))

        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]

        Me.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1

        Me.ColumnHeadersHeight = 20
        Me.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        'Comentado y Agregado
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]

        Me.DefaultCellStyle = DataGridViewCellStyle5

        Me.MultiSelect = True
        'Me.ReadOnly = True

        Me.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        ' DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control

        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.NullValue = Nothing

        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]

        Me.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.RowHeadersWidth = 25
        Me.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing

        'Style 7
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(229, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.RowsDefaultCellStyle = DataGridViewCellStyle7

        'Fin de Style

        'Comentado
        'Me.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect

        'Agregado
        'Me.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(229, Byte), Integer))
        'Me.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(228, Byte), Integer))
        'Me.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(251, Byte), Integer))

        'Agregado
        Me.GridColor = System.Drawing.Color.FromArgb(CType(CType(86, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer))
        'Me.GridColor = Color.Gainsboro
        'Me.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(217, Byte), Integer))

        '*******************************************************************
        'Inicializo ContextMenu
        '*******************************************************************

        docMenu = New ContextMenuStrip()

        'Create some menu items.
        Dim buscarLabel As New ToolStripMenuItem()
        buscarLabel.Text = "Buscar..."
        buscarLabel.Name = "buscar"
        AddHandler buscarLabel.Click, AddressOf MenuItemClick

        Dim exportarLabel As New ToolStripMenuItem()
        exportarLabel.Text = "Exportar a excel..."
        exportarLabel.Name = "exportarexcel"
        AddHandler exportarLabel.Click, AddressOf MenuItemClick

        Dim copiarSeleccionTodosLabel As New ToolStripMenuItem()
        copiarSeleccionTodosLabel.Text = "Copiar selección"
        AddHandler copiarSeleccionTodosLabel.Click, AddressOf MenuItemClick

        Dim copiarTodosLabel As New ToolStripMenuItem()
        copiarTodosLabel.Text = "Copiar filas y títulos"
        AddHandler copiarTodosLabel.Click, AddressOf MenuItemClick

        Dim copiarTituloLabel As New ToolStripMenuItem()
        copiarTituloLabel.Text = "Copiar sólo títulos"
        AddHandler copiarTituloLabel.Click, AddressOf MenuItemClick

        Dim inmovilizarLabel As New ToolStripMenuItem()
        inmovilizarLabel.Text = "Inmovilizar columna"
        AddHandler inmovilizarLabel.Click, AddressOf MenuItemClick
        'Add the menu items to the menu.
        docMenu.Items.AddRange(New ToolStripMenuItem() _
            {buscarLabel, exportarLabel, copiarSeleccionTodosLabel, copiarTodosLabel, copiarTituloLabel, inmovilizarLabel})

        ' Set the ContextMenuStrip property to the ContextMenuStrip.
        MyBase.ContextMenuStrip = docMenu
        'Me.ContextMenuStrip = docMenu
    End Sub

    Public Sub MenuItemClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.DataSource Is Nothing Then Exit Sub
        If Me.Rows.Count = 0 Then Exit Sub

        Dim menu As ToolStripMenuItem
        menu = CType(sender, ToolStripMenuItem)

        Select Case menu.Name
            Case "buscar"

                Dim frmBuscar As Buscador

                Dim dt As Object
                dt = Me.DataSource
                Dim dtData As System.Data.DataTable = Nothing
                Dim dtDataBin As System.Windows.Forms.BindingSource = Nothing

                If TypeOf (dt) Is System.Data.DataTable Then
                    'DataTable
                    dtData = CType(Me.DataSource, System.Data.DataTable)
                    frmBuscar = New Buscador(dtData, Me)

                ElseIf TypeOf (dt) Is System.Windows.Forms.BindingSource Then
                    dtDataBin = CType(Me.DataSource, System.Windows.Forms.BindingSource)

                    frmBuscar = New Buscador(dtDataBin, Me)
                Else
                    'No es ninguno sale del metodo
                    If dtData IsNot Nothing Then dt.Dispose()
                    dtData = Nothing
                    dtDataBin = Nothing
                    frmBuscar = Nothing
                    Exit Sub
                End If

                If dt Is Nothing Then
                    If dt IsNot Nothing Then dt.Dispose()
                    dt = Nothing
                    dtData = Nothing
                    dtDataBin = Nothing
                    Exit Sub
                End If

                'Muestro la Pantalla
                frmBuscar.ShowDialog()
                frmBuscar.Dispose()
                frmBuscar = Nothing

                'If dt IsNot Nothing Then dt.Dispose()
                dt = Nothing

            Case "exportarexcel"
                ExportarExcel()

        End Select
    End Sub

    Public Sub ExportarExcel()
        If Me.Rows.Count = 0 Then Exit Sub
        Dim Archivo As String
        Dim objSaveDialog As New System.Windows.Forms.SaveFileDialog
        objSaveDialog.Filter = "Excel files (*.xls) | *.xls |Excel files (*.xlsx) | *.xlsx"
        objSaveDialog.RestoreDirectory = True
        objSaveDialog.ShowDialog()
        Archivo = objSaveDialog.FileName

        If Archivo = String.Empty Then
            Exit Sub
        End If

        'If System.IO.Directory.Exists(Archivo) = False Then
        '    MessageBox.Show("Directorio no es válido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    objSaveDialog.Dispose()
        '    objSaveDialog = Nothing
        '    Exit Sub
        'End If

        Dim xExcel As Object
        Try

            Dim Filas As Integer = Me.Rows.Count
            Dim Columnas As Integer = Me.Columns.Count

            'Dim Archivo As String = Application.StartupPath & "\Plantilla.xlt"
            Dim f, c

            ' xExcel = GetObject(, "Excel.Application")

            'If Err.Number = 429 Then
            'Err.Clear()
            xExcel = CreateObject("Excel.Application")
            'End If
            xExcel.Workbooks.Add()
            'xLibro = xExcel.Workbooks(1).Worksheets(1)

            'xBook = xExcel.Workbooks.Add

            ' CABECERA
            For c = 0 To Me.Columns.Count - 1
                xExcel.Cells(1, c + 1).Value = Me.Columns(c).HeaderText.ToString.ToUpper
            Next

            Dim xFilas As Integer = 1

            ' FILAS
            For f = 0 To Me.Rows.Count - 1
                xFilas += 1
                For c = 0 To Columnas - 1
                    xExcel.Cells(xFilas, c + 1).Value = Me.Item(Me.Columns(c).Index, f).Value.ToString
                Next
            Next

            xExcel.Workbooks(1).SaveAs(Archivo)
            'xBook.SaveAs(Archivo)
            xExcel.Quit()
            If xExcel IsNot Nothing Then
                xExcel = Nothing
            End If

            'xExcel.Visible = True

            objSaveDialog.Dispose()
            objSaveDialog = Nothing

            MessageBox.Show("Se exportó satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            xExcel = Nothing
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    
End Class
