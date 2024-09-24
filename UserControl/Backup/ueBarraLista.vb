Public Class ueBarraLista
    Private mArr As New ArrayList
    Private mStrCampo As String
    Private mStrValor As String
    Private mDT As Object

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' Inicilizo la Propiedades de Botones
        InicializaBotones(True)
    End Sub

#Region "Metodos Privadas"
    Private Sub InicializaBotones(ByVal pBolTbVisible As Boolean)

        ' ******************************************
        ' Inicializo los Valores del Control
        ' La propiedad Visible y Enabled
        ' de los Botones
        ' ******************************************

        ' Propiedad Visible
        ueImprimirVisible = pBolTbVisible
        ueExcelVisible = pBolTbVisible
        ueFiltrarVisible = pBolTbVisible

    End Sub
#End Region

#Region "Propiedades Visible de Botones"
    ' **********************************
    ' Propiedades Visible de Botones
    ' **********************************

    Private mBolImprimirVisible As Boolean
    Private mBolExcelVisible As Boolean
    Private mBolFiltrarVisible As Boolean

    Public Property ueImprimirVisible() As Boolean
        Get
            Return mBolImprimirVisible
        End Get
        Set(ByVal value As Boolean)
            tbImprimir.Visible = value
            mBolImprimirVisible = value
        End Set
    End Property

    Public Property ueExcelVisible() As Boolean
        Get
            Return mBolExcelVisible
        End Get
        Set(ByVal Value As Boolean)
            tbExcel.Visible = Value
            mBolExcelVisible = Value
        End Set
    End Property

    Public Property ueFiltrarVisible() As Boolean
        Get
            Return mBolFiltrarVisible
        End Get
        Set(ByVal value As Boolean)
            tbFiltrar.Visible = value
            mBolFiltrarVisible = value
        End Set
    End Property
#End Region

#Region "Eventos del Control"
    ' *******************************
    ' Eventos del control
    ' *******************************
    Public Event ueBuscar()
    Public Event ueImprimir()
    Public Event ueExcel()
    Public Event ueFiltrar()
#End Region

#Region "Funcionalidad del Control"
    Private Sub Menu(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                     tbImprimir.Click, tbExcel.Click, tbFiltrar.Click

        ' ****************************************************************
        ' Autor     : Edgar Huarcaya C
        ' Objetivo  : Opciones de la barra
        ' Fecha     : 27 Jul 2008
        ' ****************************************************************
        Select Case CType(sender, ToolStripButton).Name

            Case "tbBuscar" : RaiseEvent ueBuscar()
            Case "tbImprimir" : RaiseEvent ueImprimir()
            Case "tbExcel" : RaiseEvent ueExcel()
            Case "tbFiltrar" : RaiseEvent ueFiltrar()
        End Select
    End Sub

    Public Sub ueSetData(ByVal objDT As Object)
        mDT = objDT
        ueRefresh()
    End Sub

    Public Sub ueRefresh()
        If Not mDT Is Nothing Then
            txtRegistros.Text = mDT.rows.count
        End If
    End Sub

#End Region

End Class
