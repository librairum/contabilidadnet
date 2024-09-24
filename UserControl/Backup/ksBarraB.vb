Public Class ksBarraB
    Private mArr As New ArrayList
    Private mStrCampo As String
    Private mStrValor As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' Inicilizo la Propiedades de Botones
        InicializaBotones(True, True)
        'Me.Dock = DockStyle.Top
    End Sub

#Region "Metodos Privadas"
    Private Sub InicializaBotones(ByVal pBolTbVisible As Boolean, _
                                 ByVal pBolTbEnabled As Boolean)

        ' ******************************************
        ' Inicializo los Valores del Control
        ' La propiedad Visible y Enabled
        ' de los Botones
        ' ******************************************

        ' Propiedad Visible
        mBolFiltrarVisible = pBolTbVisible
        mBolBuscarVisible = pBolTbVisible
        mbolRefrescarVisible = pBolTbVisible

    End Sub
#End Region

#Region "Busqueda"
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

    Public Sub prcLimpiarCombo(ByVal pStrCodigo As String, ByVal pStrDescripcion As String)
        mArr.Clear()
    End Sub

    Public Sub prcAgregarCombo(ByVal pStrCodigo As String, ByVal pStrDescripcion As String)
        mArr.Add(New ueEntidad(pStrCodigo, pStrDescripcion))
    End Sub

    Public Sub prcRefrescarCombo()
        Dim i As Integer, strValor As String = "", objEntidad As New ueEntidad("", "")
        cboCampo.Items.Clear()

        For i = 0 To mArr.Count - 1
            objEntidad = mArr(i)
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
#End Region

#Region "Propiedades Visible de Botones"
    ' **********************************
    ' Propiedades Visible de Botones
    ' **********************************
    Private mBolFiltrarVisible As Boolean
    Private mBolBuscarVisible As Boolean
    Private mbolRefrescarVisible As Boolean

    Public Property ueFiltrarVisible() As Boolean
        Get
            Return mBolFiltrarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbFiltrar.Visible = Value
            mBolFiltrarVisible = Value
        End Set
    End Property

    Public Property ueBuscarVisible() As Boolean
        Get
            Return mBolBuscarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbBuscar.Visible = Value
            mBolBuscarVisible = Value
        End Set
    End Property

    Public Property ueRefrescarVisible() As Boolean
        Get
            Return mbolRefrescarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbRefrescar.Visible = Value
            mbolRefrescarVisible = Value
        End Set
    End Property
#End Region

#Region "Eventos del Control"
    ' *******************************
    ' Eventos del control
    ' *******************************
    Public Event ueFiltrar()
    Public Event ueBuscar()
    Public Event ueRefrescar()

#End Region

#Region "Funcionalidad del Control"
    Private Sub Menu(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbFiltrar.Click, tbBuscar.Click, tbRefrescar.Click
        ' ****************************************************************
        ' Autor     : Edgar Huarcaya C
        ' Objetivo  : Opciones de la barra
        ' Fecha     : 27 Jul 2008
        ' ****************************************************************
        Select Case CType(sender, ToolStripButton).Name

            Case "tbFiltrar" : RaiseEvent ueFiltrar()
            Case "tbBuscar" : RaiseEvent ueBuscar()
            Case "tbRefrescar" : RaiseEvent ueRefrescar()

        End Select
    End Sub

#End Region

    Private Sub cboCampo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCampo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtValor.Focus()
        End If
    End Sub

    Private Sub cboCampo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCampo.SelectedIndexChanged
        If cboCampo.SelectedIndex > -1 Then
            mStrCampo = Mid(cboCampo.Text, 350, 500).Trim
        Else
            mStrCampo = ""
        End If
    End Sub

    Private Sub txtValor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor.GotFocus
        Me.txtValor.SelectionStart = 0
        Me.txtValor.SelectionLength = Len(Me.txtValor.Text)
    End Sub

    Private Sub txtValor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor.TextChanged
        mStrValor = txtValor.Text.Trim
    End Sub

    Private Sub txtValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress
        If Asc(e.KeyChar) = 13 Then
            RaiseEvent ueFiltrar()
        End If
    End Sub

End Class
