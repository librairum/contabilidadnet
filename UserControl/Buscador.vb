'Option Explicit On
'Option Strict On
'Option Compare Binary

Public Class Buscador

    ' Busqueda para DataGrid
    Private mDT As DataTable, mDGV As DataGridView, mArr As New ArrayList

    ' Busqueda para ListView
    Private mListaView As ListView

    Private mStrCampo As String, mStrValor As String

    'Busqueda con BindingSource
    Private mbinData As System.Windows.Forms.BindingSource

#Region "CONSTRUCTOR"

    Public Sub New(ByVal pDT As DataTable, ByVal pDGV As DataGridView)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        mDT = pDT
        mDGV = pDGV

        ' Lleno campos de Busqueda
        prcLlenarBusqueda(mDGV)
    End Sub

    Public Sub New(ByVal vbinData As System.Windows.Forms.BindingSource, ByVal pDGV As DataGridView)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        mbinData = vbinData
        mDGV = pDGV

        ' Lleno campos de Busqueda
        prcLlenarBusqueda(mDGV)
    End Sub

    Public Sub New(ByVal pListView As ListView)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        mListaView = mListaView

        ' Lleno campos de Busqueda
    End Sub

#End Region

    Public ReadOnly Property Campo() As String
        Get
            Return mStrCampo
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return mStrValor
        End Get
    End Property

    Private Sub prcBuscar()
        If mDGV Is Nothing Then Exit Sub
        If mbinData Is Nothing And mDT Is Nothing Then Exit Sub

        Dim objDv As DataView = Nothing

        Try
            If mDGV IsNot Nothing Then
                'objDv = mDT.DefaultView

                ' 'objDv.RowFilter = Campo & " like'" & Valor & "%'"
                'mDGV.DataSource = objDv
                ' Else
                'objDv = mbinData.DataSource

                If TypeOf mbinData.DataSource Is System.Data.DataTable Then
                    Dim dtTabla As System.Data.DataTable
                    dtTabla = CType(mbinData.DataSource, System.Data.DataTable)

                    objDv = dtTabla.DefaultView
                    objDv.RowFilter = Campo & " like'" & Valor & "%'"
                    mDGV.DataSource = objDv

                ElseIf TypeOf mbinData.DataSource Is System.Windows.Forms.BindingSource Then
                    'Dim dtTabla As System.Data.DataTable
                    'dtTabla = CType(mbinData.DataSource, System.Data.DataTable)

                    'objDv = dtTabla.DefaultView
                    Dim db As System.Windows.Forms.BindingSource
                    db = mbinData.DataSource

                    db.Filter = Campo & " like'" & Valor & "%'"
                    mDGV.DataSource = db

                End If

            End If

            'Me.Close()
        Catch ex As Exception

        Finally
            objDv = Nothing
        End Try
    End Sub

    Private Sub prcBuscar1()
        If mDGV Is Nothing Then Exit Sub
        If mbinData Is Nothing And mDT Is Nothing Then Exit Sub
        Try

            Dim objDv As DataView
            objDv = mDT.DefaultView

            Dim objDR As DataRowView = Nothing

            Dim s As String = txtValor.Text.Trim

            'objDR = mDT.Rows.Find(strCodigo)

            'objDv.RowFilter = Campo & " like'" & Valor & "%'"
            'mDGV.DataSource = objDv


        Catch ex As Exception

        End Try
    End Sub

    Public Sub prcRefrescarCombo()
        Dim i As Integer
        Dim strValor As String = String.Empty
        Dim objEntidad As New Entidad(String.Empty, String.Empty)
        cboCampo.Items.Clear()

        For i = 0 To mArr.Count - 1
            objEntidad = CType(mArr(i), Entidad)
            If Not objEntidad Is Nothing Then
                strValor = objEntidad.Descripcion & Space(400) & objEntidad.Codigo
                cboCampo.Items.Add(strValor)
            End If
        Next

        ' Muestro los valores del campo
        If cboCampo.Items.Count > 0 Then
            cboCampo.SelectedIndex = 0
        End If
    End Sub

    Public Sub prcLlenarBusqueda(ByVal objDataGridView As System.Windows.Forms.DataGridView)
        ' Lleno el combo de Filtro
        Dim i As Integer = 0, strNombreCampo As String = "", strTituloCampo As String = ""
        Try

            For i = 0 To objDataGridView.Columns.Count - 1
                If objDataGridView.Columns(i).Visible = True Then
                    strNombreCampo = objDataGridView.Columns(i).Name
                    strTituloCampo = objDataGridView.Columns(i).HeaderText
                    prcAgregarCombo(strNombreCampo, strTituloCampo)
                End If
            Next

            ' Invoco refrescar el combo
            prcRefrescarCombo()

        Catch ex As Exception
            Throw New Exception("prcLlenarBusqueda: " & ex.Message, ex)
        End Try
    End Sub

    Public Sub prcLimpiarCombo(ByVal pStrCodigo As String, ByVal pStrDescripcion As String)
        mArr.Clear()
    End Sub

    Public Sub prcAgregarCombo(ByVal pStrCodigo As String, ByVal pStrDescripcion As String)
        mArr.Add(New Entidad(pStrCodigo, pStrDescripcion))
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCampo.SelectedIndexChanged
        If cboCampo.SelectedIndex > -1 Then
            mStrCampo = Mid(cboCampo.Text, 350, 500).Trim
        Else
            mStrCampo = String.Empty
        End If
    End Sub

    Private Sub txtValor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor.GotFocus
        Me.txtValor.SelectionStart = 0
        Me.txtValor.SelectionLength = Len(Me.txtValor.Text)
    End Sub

    Private Sub txtValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress
        If Asc(e.KeyChar) = 13 Then
            prcBuscar()
        End If
    End Sub

    Private Sub txtValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValor.TextChanged
        mStrValor = txtValor.Text.Trim
        prcBuscar()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        prcBuscar()
    End Sub

    Private Sub frmBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    'Public Sub Copiar()
    '    If Me.DataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0 Then

    '        Try
    '            ' Añadimos la selección al Portapapeles.
    '            '
    '            Clipboard.SetDataObject( _
    '            Me.DataGridView1.GetClipboardContent())

    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)

    '        End Try

    '    End If

    '    ' Comprobamos si existe el formato CSV en el Portapapeles
    '    '
    '    Dim data As IDataObject = Clipboard.GetDataObject

    '    If Not data.GetDataPresent("CSV", False) Then Return

    '    Try
    '        ' Obtenemos el texto del Portapapeles, y con él construimos
    '        ' un array de valores alfanuméricos como producto de obtener
    '        ' los valores separados por tabulaciones.
    '        '
    '        Dim text() As String = Split(Clipboard.GetText, vbTab)

    '        If text.Length = 0 Then Return

    '        ' Referenciamos el objeto DataTable enlazado con
    '        ' el control DataGridView.
    '        '
    '        Dim dt As DataTable = _
    '        DirectCast(DataGridView1.DataSource, DataTable)

    '        ' Creamos un nuevo objeto DataRow
    '        '
    '        Dim dr As DataRow = dt.NewRow

    '        ' Conforme recorremos los elementos del array...
    '        For x As Int32 = 0 To DataGridView1.ColumnCount - 1
    '            ' ... añadimos los valores a las columnas
    '            dr.Item(x) = text(x)
    '        Next

    '        ' Añadimos el objeto DataRow a la colección de
    '        ' filas del objeto DataTable.
    '        '
    '        dt.Rows.Add(dr)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)

    '    End Try
    'End Sub
End Class