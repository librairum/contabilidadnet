Public Class ksBarraM

    Private mArr As New ArrayList
    Private mStrCampo As String
    Private mStrValor As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' Inicilizo la Propiedades de Botones
        InicializaBotones(True, True)
        Me.Dock = DockStyle.Top
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
        ueNuevoVisible = pBolTbVisible
        ueEliminarVisible = pBolTbVisible
        ueEditarVisible = pBolTbVisible
        ueRefrescarVisible = pBolTbVisible
        mBolBuscarVisible = pBolTbVisible
        uePreliminarVisible = pBolTbVisible
        ueImprimirVisible = pBolTbVisible
        ueExcelVisible = pBolTbVisible

        ueGuardarVisible = pBolTbVisible
        ueCancelarVisible = pBolTbVisible
        ueConfirmarVisible = pBolTbVisible
        ueReversarVisible = pBolTbVisible

        'ueCerrarVisible = pBolTbVisible
        ueAyudaVisible = pBolTbVisible
        ueDetalleVisible = pBolTbVisible

        ' Propiedad Enabled
        ueNuevoEnabled = pBolTbEnabled
        ueEliminarEnabled = pBolTbEnabled
        ueEditarEnabled = pBolTbEnabled
        ueRefrescarEnabled = pBolTbEnabled

        uePreliminarEnabled = pBolTbEnabled
        ueImprimirEnabled = pBolTbEnabled
        ueExcelEnabled = pBolTbEnabled

        ueGenerarEnabled = pBolTbEnabled
        ueGuardarEnabled = pBolTbEnabled
        ueCancelarEnabled = pBolTbEnabled

        ueConfirmarEnabled = pBolTbEnabled
        ueReversarEnabled = pBolTbEnabled
        ueAnularEnabled = pBolTbEnabled

        'ueCerrarEnabled = pBolTbEnabled
        ueAyudaEnabled = pBolTbEnabled
        ueDetalleEnabled = pBolTbEnabled

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

#End Region

#Region "Propiedades Visible de Botones"
    ' **********************************
    ' Propiedades Visible de Botones
    ' **********************************
    Private mBolNuevoVisible As Boolean
    Private mBolEliminarVisible As Boolean
    Private mBolEditarVisible As Boolean
    Private mBolRefescarVisible As Boolean

    Private mBolBuscarVisible As Boolean
    Private mBolPreliminarVisible As Boolean
    Private mBolImprimirVisible As Boolean
    Private mBolExcelVisible As Boolean
    Private mBolGenerarVisible As Boolean
    Private mBolGuardarVisible As Boolean
    Private mBolCancelarVisible As Boolean
    Private mBolConfirmarVisible As Boolean
    Private mBolReversarVisible As Boolean
    Private mBolAnularVisible As Boolean

    Private mBolCerrarVisible As Boolean
    Private mBolAyudaVisible As Boolean
    Private mBolDetalleVisible As Boolean

    Public Property ueNuevoVisible() As Boolean
        Get
            Return mBolNuevoVisible
        End Get
        Set(ByVal Value As Boolean)
            tbNuevo.Visible = Value
            mBolNuevoVisible = Value
        End Set
    End Property

    Public Property ueEliminarVisible() As Boolean
        Get
            Return mBolEliminarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbEliminar.Visible = Value
            mBolEliminarVisible = Value
        End Set
    End Property

    Public Property ueEditarVisible() As Boolean
        Get
            Return mBolEditarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbEditar.Visible = Value
            mBolEditarVisible = Value
        End Set
    End Property

    Public Property ueRefrescarVisible() As Boolean
        Get
            Return mBolRefescarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbRefrescar.Visible = Value
            mBolRefescarVisible = Value
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

    Public Property uePreliminarVisible() As Boolean
        Get
            Return mBolPreliminarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbPreliminar.Visible = Value
            mBolPreliminarVisible = Value
        End Set
    End Property

    Public Property ueImprimirVisible() As Boolean
        Get
            Return mBolImprimirVisible
        End Get
        Set(ByVal Value As Boolean)
            tbImprimir.Visible = Value
            mBolImprimirVisible = Value
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

    Public Property ueGenerarVisible() As Boolean
        Get
            Return mBolGenerarVisible
        End Get
        Set(ByVal value As Boolean)
            tbGenerar.Visible = value
            mBolGenerarVisible = value
        End Set
    End Property

    Public Property ueGuardarVisible() As Boolean
        Get
            Return mBolGuardarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbGuardar.Visible = Value
            mBolGuardarVisible = Value
        End Set
    End Property

    Public Property ueCancelarVisible() As Boolean
        Get
            Return mBolCancelarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbCancelar.Visible = Value
            mBolCancelarVisible = Value
        End Set
    End Property

    Public Property ueConfirmarVisible() As Boolean
        Get
            Return mBolConfirmarVisible
        End Get
        Set(ByVal value As Boolean)
            tbConfirmar.Visible = value
            mBolConfirmarVisible = value
        End Set
    End Property

    Public Property ueReversarVisible() As Boolean
        Get
            Return mBolReversarVisible
        End Get
        Set(ByVal value As Boolean)
            tbReversar.Visible = value
            mBolReversarVisible = value
        End Set
    End Property

    Public Property ueAnularVisible() As Boolean
        Get
            Return mBolAnularVisible
        End Get
        Set(ByVal value As Boolean)
            mBolAnularVisible = value
            tbAnular.Visible = value
        End Set
    End Property

    'Public Property ueCerrarVisible() As Boolean
    '    Get
    '        Return mBolCerrarVisible
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        tbCerrar.Visible = Value
    '        mBolCerrarVisible = Value
    '    End Set
    'End Property

    Public Property ueAyudaVisible() As Boolean
        Get
            Return mBolAyudaVisible
        End Get
        Set(ByVal Value As Boolean)
            tbAyuda.Visible = Value
            mBolAyudaVisible = Value
        End Set
    End Property

    Public Property ueDetalleVisible() As Boolean
        Get
            Return mBolDetalleVisible
        End Get
        Set(ByVal value As Boolean)
            tbDetalle.Visible = value
            mBolDetalleVisible = value
        End Set
    End Property
#End Region

#Region "Propiedades Enabled de Botones"

    ' ***************************************
    ' Propiedades Eneabled de los Botones
    ' ***************************************

    Private mBolNuevoEnabled As Boolean
    Private mBolEliminarEnabled As Boolean
    Private mBolEditarEnabled As Boolean
    Private mBolRefrescarEnabled As Boolean

    Private mBolPreliminarEnabled As Boolean
    Private mBolImprimirEnabled As Boolean
    Private mBolExcelEnabled As Boolean

    Private mBolGenerarEnabled As Boolean
    Private mBolGuardarEnabled As Boolean
    Private mBolCancelarEnabled As Boolean

    Private mBolConfirmarEnabled As Boolean
    Private mBolReversarEnabled As Boolean
    Private mBolAnularEnabled As Boolean

    Private mBolCerrarEnabled As Boolean
    Private mBolAyudaEnabled As Boolean
    Private mBolDetalleEnabled As Boolean

    Public Property ueNuevoEnabled() As Boolean
        Get
            Return mBolNuevoEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbNuevo.Enabled = Value
            mBolNuevoEnabled = Value
        End Set
    End Property

    Public Property ueEliminarEnabled() As Boolean
        Get
            Return mBolEliminarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbEliminar.Enabled = Value
            mBolEliminarEnabled = Value
        End Set
    End Property

    Public Property ueEditarEnabled() As Boolean
        Get
            Return mBolEditarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbEditar.Enabled = Value
            mBolEditarEnabled = Value
        End Set
    End Property

    Public Property ueRefrescarEnabled() As Boolean
        Get
            Return mBolRefrescarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbRefrescar.Enabled = Value
            mBolRefrescarEnabled = Value
        End Set
    End Property

    Public Property uePreliminarEnabled() As Boolean
        Get
            Return mBolPreliminarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbPreliminar.Enabled = Value
            mBolPreliminarEnabled = Value
        End Set
    End Property

    Public Property ueImprimirEnabled() As Boolean
        Get
            Return mBolImprimirEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbImprimir.Enabled = Value
            mBolImprimirEnabled = Value
        End Set
    End Property

    Public Property ueExcelEnabled() As Boolean
        Get
            Return mBolExcelEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbExcel.Enabled = Value
            mBolExcelEnabled = Value
        End Set
    End Property

    Public Property ueGenerarEnabled() As Boolean
        Get
            Return mBolGenerarEnabled
        End Get
        Set(ByVal value As Boolean)
            mBolGenerarEnabled = value
            tbGenerar.Enabled = value
        End Set
    End Property

    Public Property ueGuardarEnabled() As Boolean
        Get
            Return mBolGuardarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbGuardar.Enabled = Value
            mBolGuardarEnabled = Value
        End Set
    End Property

    Public Property ueCancelarEnabled() As Boolean
        Get
            Return mBolCancelarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbCancelar.Enabled = Value
            mBolCancelarEnabled = Value
        End Set
    End Property

    Public Property ueConfirmarEnabled() As Boolean
        Get
            Return mBolConfirmarEnabled
        End Get
        Set(ByVal value As Boolean)
            tbConfirmar.Enabled = value
            mBolConfirmarEnabled = value
        End Set
    End Property

    Public Property ueReversarEnabled() As Boolean
        Get
            Return mBolReversarEnabled
        End Get
        Set(ByVal value As Boolean)
            tbReversar.Enabled = value
            mBolReversarEnabled = value
        End Set
    End Property

    Public Property ueAnularEnabled() As Boolean
        Get
            Return mBolAnularEnabled
        End Get
        Set(ByVal value As Boolean)
            mBolAnularEnabled = value
            tbAnular.Enabled = value
        End Set
    End Property

    'Public Property ueCerrarEnabled() As Boolean
    '    Get
    '        Return mBolCerrarEnabled
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        tbCerrar.Enabled = Value
    '        mBolCerrarEnabled = Value
    '    End Set
    'End Property

    Public Property ueAyudaEnabled() As Boolean
        Get
            Return mBolAyudaEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbAyuda.Enabled = Value
            mBolAyudaEnabled = Value
        End Set
    End Property

    Public Property ueDetalleEnabled() As Boolean
        Get
            Return mBolDetalleEnabled
        End Get
        Set(ByVal value As Boolean)
            tbDetalle.Enabled = value
            mBolDetalleEnabled = value
        End Set
    End Property
#End Region

#Region "Funcionalidad del Control"

    Private Sub Menu_M(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                     tbNuevo.Click, tbEliminar.Click, tbEditar.Click, tbRefrescar.Click, _
                     tbBuscar.Click, tbPreliminar.Click, tbImprimir.Click, tbExcel.Click, _
                     tbGenerar.Click, tbGuardar.Click, tbConfirmar.Click, tbReversar.Click, tbCancelar.Click, _
                     tbAnular.Click, tbAyuda.Click, tbSalir.Click, tbDetalle.Click
        ' ****************************************************************
        ' Autor     : Edgar Huarcaya C
        ' Objetivo  : Opciones de la barra
        ' Fecha     : 27 Jul 2008
        ' ****************************************************************
        Select Case CType(sender, ToolStripButton).Name

            Case "tbNuevo" : RaiseEvent ueNuevo()
            Case "tbEliminar" : RaiseEvent ueEliminar()
            Case "tbEditar" : RaiseEvent ueEditar()
            Case "tbRefrescar" : RaiseEvent ueRefrescar()

            Case "tbBuscar" : RaiseEvent ueBuscar()
            Case "tbPreliminar" : RaiseEvent uePreliminar()
            Case "tbImprimir" : RaiseEvent ueImprimir()

            Case "tbExcel" : RaiseEvent ueExcel()

            Case "tbGenerar" : RaiseEvent ueGenerar()
            Case "tbGuardar" : RaiseEvent ueGuardar()
            Case "tbCancelar" : RaiseEvent ueCancelar()

            Case "tbConfirmar" : RaiseEvent ueConfirmar()
            Case "tbReversar" : RaiseEvent ueReversar()
            Case "tbAnular" : RaiseEvent ueAnular()

            Case "tbSalir" : RaiseEvent ueCerrar()
            Case "tbAyuda" : RaiseEvent ueAyuda()
            Case "tbDetalle" : RaiseEvent ueDetalle()

        End Select
    End Sub

    Public Sub prcHabilitar(Optional ByVal pBlnEstado As Boolean = True)
        With Me
            .ueNuevoEnabled = pBlnEstado
            .ueEliminarEnabled = pBlnEstado
            .ueEditarEnabled = pBlnEstado
            .ueRefrescarEnabled = pBlnEstado
            .ueExcelEnabled = pBlnEstado

            .ueGuardarEnabled = Not pBlnEstado
            .ueCancelarEnabled = Not pBlnEstado
        End With
    End Sub

#End Region

#Region "Eventos del Control"

    ' *******************************
    ' Eventos del control
    '*******************************

    Public Event ueNuevo()
    Public Event ueEliminar()
    Public Event ueEditar()
    Public Event ueRefrescar()
    Public Event ueBuscar()
    Public Event uePreliminar()
    Public Event ueImprimir()
    Public Event ueExcel()

    Public Event ueGenerar()
    Public Event ueGuardar()
    Public Event ueCancelar()

    Public Event ueConfirmar()
    Public Event ueReversar()
    Public Event ueAnular()

    Public Event ueCerrar()
    Public Event ueAyuda()
    Public Event ueDetalle()

#End Region


    Public Sub prcNuevo(Optional ByVal pBlnEstado As Boolean = True)
        ueRefrescarEnabled = True
        ueNuevoEnabled = True
        ueEditarEnabled = True
        ueEliminarEnabled = True
        ueDetalleEnabled = True
        tbDetalle.Text = "Ficha"

        ueGuardarEnabled = False
        ueCancelarEnabled = False
    End Sub

    Public Sub prcGuardar()
        ueRefrescarEnabled = False
        ueNuevoEnabled = False
        ueEditarEnabled = False
        ueEliminarEnabled = False
        ueDetalleEnabled = False
        tbDetalle.Text = "Lista"

        ueGuardarEnabled = True
        ueCancelarEnabled = True
    End Sub

    Public Sub prcCancelar()
        ueRefrescarEnabled = False
        ueNuevoEnabled = False
        ueEditarEnabled = False
        ueEliminarEnabled = False
        ueDetalleEnabled = False
        tbDetalle.Text = "Lista"

        ueGuardarEnabled = True
        ueCancelarEnabled = True
    End Sub

    Public Sub prcFicha(Optional ByVal pBlnEstado As Boolean = True)
        If pBlnEstado = True Then
            tbDetalle.Text = "Lista"
        Else
            tbDetalle.Text = "Ficha"
        End If
    End Sub



End Class
