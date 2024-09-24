Public Class KsBarra
    Inherits System.Windows.Forms.UserControl

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

        ' Inicilizo la Propiedades de Botones
        InicializaBotones(True, True)
    End Sub

    'UserControl1 reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents ilComun As System.Windows.Forms.ImageList
    Friend WithEvents tlbComun As System.Windows.Forms.ToolBar
    Friend WithEvents tbAlta As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbBaja As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbCambio As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSep01 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbVista As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbArchivo As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSep04 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbAyuda As System.Windows.Forms.ToolBarButton
    Friend WithEvents gbComun As System.Windows.Forms.GroupBox
    Friend WithEvents Sep05 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbAceptar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbGuardar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbAnular As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbConfirmar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbReversar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbCalcular As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbCancelar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KsBarra))
        Me.ilComun = New System.Windows.Forms.ImageList(Me.components)
        Me.tlbComun = New System.Windows.Forms.ToolBar
        Me.tbAlta = New System.Windows.Forms.ToolBarButton
        Me.tbBaja = New System.Windows.Forms.ToolBarButton
        Me.tbCambio = New System.Windows.Forms.ToolBarButton
        Me.tbSep01 = New System.Windows.Forms.ToolBarButton
        Me.tbActualizar = New System.Windows.Forms.ToolBarButton
        Me.tbAnular = New System.Windows.Forms.ToolBarButton
        Me.tbConfirmar = New System.Windows.Forms.ToolBarButton
        Me.tbReversar = New System.Windows.Forms.ToolBarButton
        Me.tbVista = New System.Windows.Forms.ToolBarButton
        Me.tbImprimir = New System.Windows.Forms.ToolBarButton
        Me.tbArchivo = New System.Windows.Forms.ToolBarButton
        Me.tbBuscar = New System.Windows.Forms.ToolBarButton
        Me.tbSep04 = New System.Windows.Forms.ToolBarButton
        Me.tbGuardar = New System.Windows.Forms.ToolBarButton
        Me.tbAceptar = New System.Windows.Forms.ToolBarButton
        Me.tbCancelar = New System.Windows.Forms.ToolBarButton
        Me.Sep05 = New System.Windows.Forms.ToolBarButton
        Me.tbCalcular = New System.Windows.Forms.ToolBarButton
        Me.tbAyuda = New System.Windows.Forms.ToolBarButton
        Me.tbCerrar = New System.Windows.Forms.ToolBarButton
        Me.gbComun = New System.Windows.Forms.GroupBox
        Me.SuspendLayout()
        '
        'ilComun
        '
        Me.ilComun.ImageStream = CType(resources.GetObject("ilComun.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilComun.TransparentColor = System.Drawing.Color.Transparent
        Me.ilComun.Images.SetKeyName(0, "Alta")
        Me.ilComun.Images.SetKeyName(1, "Baja")
        Me.ilComun.Images.SetKeyName(2, "Cambio")
        Me.ilComun.Images.SetKeyName(3, "")
        Me.ilComun.Images.SetKeyName(4, "")
        Me.ilComun.Images.SetKeyName(5, "")
        Me.ilComun.Images.SetKeyName(6, "")
        Me.ilComun.Images.SetKeyName(7, "")
        Me.ilComun.Images.SetKeyName(8, "")
        Me.ilComun.Images.SetKeyName(9, "")
        Me.ilComun.Images.SetKeyName(10, "")
        Me.ilComun.Images.SetKeyName(11, "")
        Me.ilComun.Images.SetKeyName(12, "")
        Me.ilComun.Images.SetKeyName(13, "")
        Me.ilComun.Images.SetKeyName(14, "")
        Me.ilComun.Images.SetKeyName(15, "")
        Me.ilComun.Images.SetKeyName(16, "")
        Me.ilComun.Images.SetKeyName(17, "")
        Me.ilComun.Images.SetKeyName(18, "")
        Me.ilComun.Images.SetKeyName(19, "")
        Me.ilComun.Images.SetKeyName(20, "")
        Me.ilComun.Images.SetKeyName(21, "")
        Me.ilComun.Images.SetKeyName(22, "")
        Me.ilComun.Images.SetKeyName(23, "")
        Me.ilComun.Images.SetKeyName(24, "")
        Me.ilComun.Images.SetKeyName(25, "Excel")
        Me.ilComun.Images.SetKeyName(26, "")
        Me.ilComun.Images.SetKeyName(27, "")
        Me.ilComun.Images.SetKeyName(28, "Guardar16x16")
        Me.ilComun.Images.SetKeyName(29, "Refrescar16x16")
        Me.ilComun.Images.SetKeyName(30, "Imprimir16x16")
        Me.ilComun.Images.SetKeyName(31, "Preliminar16x16")
        Me.ilComun.Images.SetKeyName(32, "OK16x16")
        Me.ilComun.Images.SetKeyName(33, "Anular16x16")
        Me.ilComun.Images.SetKeyName(34, "Cancelar16x16")
        Me.ilComun.Images.SetKeyName(35, "Buscar16x16")
        Me.ilComun.Images.SetKeyName(36, "Nuevo16x16")
        Me.ilComun.Images.SetKeyName(37, "Editar16x16")
        Me.ilComun.Images.SetKeyName(38, "Eliminar16x16")
        Me.ilComun.Images.SetKeyName(39, "Ayuda16x16")
        Me.ilComun.Images.SetKeyName(40, "calculadora16x16")
        Me.ilComun.Images.SetKeyName(41, "Confirmar_16x16.gif")
        Me.ilComun.Images.SetKeyName(42, "Reversar_16x16.gif")
        '
        'tlbComun
        '
        Me.tlbComun.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbComun.AutoSize = False
        Me.tlbComun.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbAlta, Me.tbBaja, Me.tbCambio, Me.tbSep01, Me.tbActualizar, Me.tbAnular, Me.tbConfirmar, Me.tbReversar, Me.tbVista, Me.tbImprimir, Me.tbArchivo, Me.tbBuscar, Me.tbSep04, Me.tbGuardar, Me.tbAceptar, Me.tbCancelar, Me.Sep05, Me.tbCalcular, Me.tbAyuda, Me.tbCerrar})
        Me.tlbComun.ButtonSize = New System.Drawing.Size(25, 25)
        Me.tlbComun.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.tlbComun.DropDownArrows = True
        Me.tlbComun.ImageList = Me.ilComun
        Me.tlbComun.Location = New System.Drawing.Point(0, 0)
        Me.tlbComun.Name = "tlbComun"
        Me.tlbComun.ShowToolTips = True
        Me.tlbComun.Size = New System.Drawing.Size(512, 30)
        Me.tlbComun.TabIndex = 6
        '
        'tbAlta
        '
        Me.tbAlta.ImageKey = "Nuevo16x16"
        Me.tbAlta.Name = "tbAlta"
        Me.tbAlta.Tag = "Alta"
        Me.tbAlta.ToolTipText = "Nuevo"
        '
        'tbBaja
        '
        Me.tbBaja.ImageKey = "Eliminar16x16"
        Me.tbBaja.Name = "tbBaja"
        Me.tbBaja.Tag = "Baja"
        Me.tbBaja.ToolTipText = "Eliminar"
        '
        'tbCambio
        '
        Me.tbCambio.ImageKey = "Editar16x16"
        Me.tbCambio.Name = "tbCambio"
        Me.tbCambio.Tag = "Cambio"
        Me.tbCambio.ToolTipText = "Modificar"
        '
        'tbSep01
        '
        Me.tbSep01.Name = "tbSep01"
        Me.tbSep01.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbActualizar
        '
        Me.tbActualizar.ImageKey = "Refrescar16x16"
        Me.tbActualizar.Name = "tbActualizar"
        Me.tbActualizar.Tag = "Actualizar"
        Me.tbActualizar.ToolTipText = "Refrescar"
        '
        'tbAnular
        '
        Me.tbAnular.ImageKey = "Anular16x16"
        Me.tbAnular.Name = "tbAnular"
        Me.tbAnular.Tag = "Anular"
        Me.tbAnular.ToolTipText = "Anular"
        '
        'tbConfirmar
        '
        Me.tbConfirmar.ImageKey = "Confirmar_16x16.gif"
        Me.tbConfirmar.Name = "tbConfirmar"
        Me.tbConfirmar.Tag = "Confirmar"
        Me.tbConfirmar.ToolTipText = "Confirmar"
        '
        'tbReversar
        '
        Me.tbReversar.ImageKey = "Reversar_16x16.gif"
        Me.tbReversar.Name = "tbReversar"
        Me.tbReversar.Tag = "Reversar"
        Me.tbReversar.ToolTipText = "Reversar"
        '
        'tbVista
        '
        Me.tbVista.ImageKey = "Preliminar16x16"
        Me.tbVista.Name = "tbVista"
        Me.tbVista.Tag = "Vista"
        Me.tbVista.ToolTipText = "Vista Preliminar"
        '
        'tbImprimir
        '
        Me.tbImprimir.ImageKey = "Imprimir16x16"
        Me.tbImprimir.Name = "tbImprimir"
        Me.tbImprimir.Tag = "Imprimir"
        Me.tbImprimir.ToolTipText = "Imprimir"
        '
        'tbArchivo
        '
        Me.tbArchivo.ImageIndex = 10
        Me.tbArchivo.Name = "tbArchivo"
        Me.tbArchivo.Tag = "Archivo"
        Me.tbArchivo.ToolTipText = "Exportar Archivo"
        '
        'tbBuscar
        '
        Me.tbBuscar.ImageKey = "Buscar16x16"
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Tag = "Buscar"
        '
        'tbSep04
        '
        Me.tbSep04.Name = "tbSep04"
        Me.tbSep04.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbGuardar
        '
        Me.tbGuardar.ImageKey = "Guardar16x16"
        Me.tbGuardar.Name = "tbGuardar"
        Me.tbGuardar.Tag = "Guardar"
        Me.tbGuardar.ToolTipText = "Guardar"
        '
        'tbAceptar
        '
        Me.tbAceptar.ImageKey = "OK16x16"
        Me.tbAceptar.Name = "tbAceptar"
        Me.tbAceptar.Tag = "Aceptar"
        Me.tbAceptar.ToolTipText = "Actualizar Información"
        '
        'tbCancelar
        '
        Me.tbCancelar.ImageKey = "Cancelar16x16"
        Me.tbCancelar.Name = "tbCancelar"
        Me.tbCancelar.Tag = "Cancelar"
        Me.tbCancelar.ToolTipText = "Cancelar"
        '
        'Sep05
        '
        Me.Sep05.Name = "Sep05"
        Me.Sep05.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbCalcular
        '
        Me.tbCalcular.ImageKey = "calculadora16x16"
        Me.tbCalcular.Name = "tbCalcular"
        Me.tbCalcular.Tag = "Calcular"
        Me.tbCalcular.ToolTipText = "Calcular"
        '
        'tbAyuda
        '
        Me.tbAyuda.ImageKey = "Ayuda16x16"
        Me.tbAyuda.Name = "tbAyuda"
        Me.tbAyuda.Tag = "Ayuda"
        Me.tbAyuda.ToolTipText = "Ayuda"
        '
        'tbCerrar
        '
        Me.tbCerrar.ImageIndex = 11
        Me.tbCerrar.Name = "tbCerrar"
        Me.tbCerrar.Tag = "Cerrar"
        Me.tbCerrar.ToolTipText = "Cerrar Ventana"
        '
        'gbComun
        '
        Me.gbComun.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbComun.Location = New System.Drawing.Point(0, 30)
        Me.gbComun.Name = "gbComun"
        Me.gbComun.Size = New System.Drawing.Size(512, 2)
        Me.gbComun.TabIndex = 7
        Me.gbComun.TabStop = False
        '
        'KsBarra
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.gbComun)
        Me.Controls.Add(Me.tlbComun)
        Me.Name = "KsBarra"
        Me.Size = New System.Drawing.Size(512, 36)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' ***************** KsBarra VERSION 1.0 *****************************
    ' Objetivo          : Control que permitirá mantenimiento
    ' Fecha Creacion    : 12, 14 de Julio 2008
    ' Fecha Modicacion  :
    ' Creado por        : Edgar Huarcaya C.
    ' Modificado por    : 
    ' Para              : Key Solutions S.R.L
    ' *******************************************************************
#Region "Metodos Privadas"
    Private Sub InicializaBotones(ByVal pBolTbVisible As Boolean, _
                                 ByVal pBolTbEnabled As Boolean)

        ' ******************************************
        ' Inicializo los Valores del Control
        ' La propiedad Visible y Enabled
        ' de los Botones
        ' ******************************************

        ' Propiedad Visible
        AltaVisible = pBolTbVisible
        BajaVisible = pBolTbVisible
        CambioVisible = pBolTbVisible
        GuardarVisible = pBolTbVisible
        ActualizarVisible = pBolTbVisible
        PreliminarVisible = pBolTbVisible
        ImprimirVisible = pBolTbVisible
        ExpArchivoVisible = pBolTbVisible
        BuscarVisible = pBolTbVisible
        CerrarVisible = pBolTbVisible
        AyudaVisible = pBolTbVisible
        AceptarVisible = pBolTbVisible
        CancelarVisible = pBolTbVisible
        AnularVisible = pBolTbVisible
        ConfirmarVisible = pBolTbVisible
        ReversarVisible = pBolTbVisible
        CalcularVisible = pBolTbVisible

        ' Propiedad Enabled
        AltaEnabled = pBolTbEnabled
        BajaEnabled = pBolTbEnabled
        CambioEnabled = pBolTbEnabled
        GuardarEnabled = pBolTbEnabled
        ActualizarEnabled = pBolTbEnabled
        PreliminarEnabled = pBolTbEnabled
        ImprimirEnabled = pBolTbEnabled
        ExpArchivoEnabled = pBolTbEnabled
        BuscarEnabled = pBolTbEnabled
        CerrarEnabled = pBolTbEnabled
        AyudaEnabled = pBolTbEnabled
        AceptarEnabled = pBolTbEnabled
        CancelarEnabled = pBolTbEnabled
        AnularEnabled = pBolTbEnabled
        ConfirmarEnabled = pBolTbEnabled
        ReversarEnabled = pBolTbEnabled
        CalcularEnabled = pBolTbEnabled
    End Sub
#End Region

#Region "Propiedades Visible de Botones"
    ' **********************************
    ' Propiedades Visible de Botones
    ' **********************************
    Private mBolAltaVisible As Boolean
    Private mBolBajaVisible As Boolean
    Private mBolCambiosVisible As Boolean
    Private mBolGuardarVisible As Boolean
    Private mBolActualizarVisible As Boolean
    Private mBolVistaVisible As Boolean
    Private mBolImprimirVisible As Boolean
    Private mBolArchivoVisible As Boolean
    Private mBolBuscarVisible As Boolean
    Private mBolCerrarVisible As Boolean
    Private mBolAyudaVisible As Boolean
    Private mBolAceptarVisible As Boolean
    Private mBolCancelarVisible As Boolean
    Private mBolAnularVisible As Boolean
    Private mBolConfirmarVisible As Boolean
    Private mBolReversarVisible As Boolean
    Private mBolCalcularVisible As Boolean

    Public Property AltaVisible() As Boolean
        Get
            Return mBolAltaVisible
        End Get
        Set(ByVal Value As Boolean)
            tbAlta.Visible = Value
            mBolAltaVisible = Value
        End Set
    End Property

    Public Property BajaVisible() As Boolean
        Get
            Return mBolBajaVisible
        End Get
        Set(ByVal Value As Boolean)
            tbBaja.Visible = Value
            mBolBajaVisible = Value
        End Set
    End Property

    Public Property CambioVisible() As Boolean
        Get
            Return mBolCambiosVisible
        End Get
        Set(ByVal Value As Boolean)
            tbCambio.Visible = Value
            mBolCambiosVisible = Value
        End Set
    End Property

    Public Property GuardarVisible() As Boolean
        Get
            Return mBolGuardarVisible
        End Get
        Set(ByVal value As Boolean)
            tbGuardar.Visible = value
            mBolGuardarVisible = value
        End Set
    End Property

    Public Property ActualizarVisible() As Boolean
        Get
            Return mBolActualizarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbActualizar.Visible = Value
            mBolActualizarVisible = Value
        End Set
    End Property

    Public Property PreliminarVisible() As Boolean
        Get
            Return mBolVistaVisible
        End Get
        Set(ByVal Value As Boolean)
            tbVista.Visible = Value
            mBolVistaVisible = Value
        End Set
    End Property

    Public Property ImprimirVisible() As Boolean
        Get
            Return mBolImprimirVisible
        End Get
        Set(ByVal Value As Boolean)
            tbImprimir.Visible = Value
            mBolImprimirVisible = Value
        End Set
    End Property

    Public Property ExpArchivoVisible() As Boolean
        Get
            Return mBolArchivoVisible
        End Get
        Set(ByVal Value As Boolean)
            tbArchivo.Visible = Value
            mBolArchivoVisible = Value
        End Set
    End Property

    Public Property BuscarVisible() As Boolean
        Get
            Return mBolBuscarVisible
        End Get
        Set(ByVal value As Boolean)
            tbBuscar.Visible = value
            mBolBuscarVisible = value
        End Set
    End Property

    Public Property CerrarVisible() As Boolean
        Get
            Return mBolCerrarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbCerrar.Visible = Value
            mBolCerrarVisible = Value
        End Set
    End Property

    Public Property AyudaVisible() As Boolean
        Get
            Return mBolAyudaVisible
        End Get
        Set(ByVal Value As Boolean)
            tbAyuda.Visible = Value
            mBolAyudaVisible = Value
        End Set
    End Property

    Public Property AceptarVisible() As Boolean
        Get
            Return mBolAceptarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbAceptar.Visible = Value
            mBolAceptarVisible = Value
        End Set
    End Property

    Public Property CancelarVisible() As Boolean
        Get
            Return mBolCancelarVisible
        End Get
        Set(ByVal Value As Boolean)
            tbCancelar.Visible = Value
            mBolCancelarVisible = Value
        End Set
    End Property

    Public Property AnularVisible() As Boolean
        Get
            Return mBolAnularVisible
        End Get
        Set(ByVal value As Boolean)
            tbAnular.Visible = value
            mBolAnularVisible = value
        End Set
    End Property

    Public Property ConfirmarVisible() As Boolean
        Get
            Return mBolConfirmarVisible
        End Get
        Set(ByVal value As Boolean)
            tbConfirmar.Visible = value
            mBolConfirmarVisible = value
        End Set
    End Property

    Public Property ReversarVisible() As Boolean
        Get
            Return mBolReversarVisible
        End Get
        Set(ByVal value As Boolean)
            tbReversar.Visible = value
            mBolReversarVisible = value
        End Set
    End Property

    Public Property CalcularVisible() As Boolean
        Get
            Return mBolCalcularVisible
        End Get
        Set(ByVal value As Boolean)
            tbCalcular.Visible = value
            mBolCalcularVisible = value
        End Set
    End Property
#End Region

#Region "Propiedades Enabled de Botones"
    ' ***************************************
    ' Propiedades Eneabled de los Botones
    ' ***************************************
    Private mBolAltaEnabled As Boolean
    Private mBolBajaEnabled As Boolean
    Private mBolCambiosEnabled As Boolean
    Private mBolGuardarEnabled As Boolean
    Private mBolActualizarEnabled As Boolean
    Private mBolVistaEnabled As Boolean
    Private mBolImprimirEnabled As Boolean
    Private mBolArchivoEnabled As Boolean
    Private mBolBuscarEnabled As Boolean
    Private mBolCerrarEnabled As Boolean
    Private mBolAyudaEnabled As Boolean
    Private mBolAceptarEnabled As Boolean
    Private mBolCancelarEnabled As Boolean
    Private mBolAnularEnabled As Boolean
    Private mBolConfirmarEnabled As Boolean
    Private mBolReversarEnabled As Boolean
    Private mBolCalcularEnabled As Boolean

    Public Property AltaEnabled() As Boolean
        Get
            Return mBolAltaEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbAlta.Enabled = Value
            mBolAltaEnabled = Value
        End Set
    End Property

    Public Property BajaEnabled() As Boolean
        Get
            Return mBolBajaEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbBaja.Enabled = Value
            mBolBajaEnabled = Value
        End Set
    End Property

    Public Property CambioEnabled() As Boolean
        Get
            Return mBolCambiosEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbCambio.Enabled = Value
            mBolCambiosEnabled = Value
        End Set
    End Property

    Public Property GuardarEnabled() As Boolean
        Get
            Return mBolGuardarEnabled
        End Get
        Set(ByVal value As Boolean)
            tbGuardar.Enabled = value
            mBolGuardarEnabled = value
        End Set
    End Property

    Public Property ActualizarEnabled() As Boolean
        Get
            Return mBolActualizarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbActualizar.Enabled = Value
            mBolActualizarEnabled = Value
        End Set
    End Property

    Public Property PreliminarEnabled() As Boolean
        Get
            Return mBolVistaEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbVista.Enabled = Value
            mBolVistaEnabled = Value
        End Set
    End Property

    Public Property ImprimirEnabled() As Boolean
        Get
            Return mBolImprimirEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbImprimir.Enabled = Value
            mBolImprimirEnabled = Value
        End Set
    End Property

    Public Property ExpArchivoEnabled() As Boolean
        Get
            Return mBolArchivoEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbArchivo.Enabled = Value
            mBolArchivoEnabled = Value
        End Set
    End Property

    Public Property BuscarEnabled() As Boolean
        Get
            Return mBolBuscarEnabled
        End Get
        Set(ByVal value As Boolean)
            tbBuscar.Enabled = value
            mBolBuscarEnabled = value
        End Set
    End Property

    Public Property CerrarEnabled() As Boolean
        Get
            Return mBolCerrarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbCerrar.Enabled = Value
            mBolCerrarEnabled = Value
        End Set
    End Property

    Public Property AyudaEnabled() As Boolean
        Get
            Return mBolAyudaEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbAyuda.Enabled = Value
            mBolAyudaEnabled = Value
        End Set
    End Property

    Public Property AceptarEnabled() As Boolean
        Get
            Return mBolAceptarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbAceptar.Enabled = Value
            mBolAceptarEnabled = Value
        End Set
    End Property

    Public Property CancelarEnabled() As Boolean
        Get
            Return mBolCancelarEnabled
        End Get
        Set(ByVal Value As Boolean)
            tbCancelar.Enabled = Value
            mBolCancelarEnabled = Value
        End Set
    End Property

    Public Property AnularEnabled() As Boolean
        Get
            Return mBolAnularEnabled
        End Get
        Set(ByVal value As Boolean)
            tbAnular.Enabled = value
            mBolAnularEnabled = value
        End Set
    End Property

    Public Property ConfirmarEnabled() As Boolean
        Get
            Return mBolConfirmarEnabled
        End Get
        Set(ByVal value As Boolean)
            tbConfirmar.Enabled = value
            mBolConfirmarEnabled = value
        End Set
    End Property

    Public Property ReversarEnabled() As Boolean
        Get
            Return mBolReversarEnabled
        End Get
        Set(ByVal value As Boolean)
            tbReversar.Enabled = value
            mBolReversarEnabled = value
        End Set
    End Property

    Public Property CalcularEnabled() As Boolean
        Get
            Return mBolCalcularEnabled
        End Get
        Set(ByVal value As Boolean)
            tbCalcular.Enabled = value
            mBolCalcularEnabled = value
        End Set
    End Property
#End Region

#Region "Eventos del Control"
    ' *******************************
    ' Eventos del control
    ' *******************************
    Public Event Alta()
    Public Event Baja()
    Public Event Cambio()
    Public Event Guardar()
    Public Event Actualizar()
    Public Event VistaPreliminar()
    Public Event Imprimir()
    Public Event ExportaArchivo()
    Public Event Buscar()
    Public Event Cerrar()
    Public Event Ayuda()
    Public Event Aceptar()
    Public Event Cancelar()
    Public Event Anular()
    Public Event Confirmar()
    Public Event Reversar()
    Public Event Calcular()
#End Region

#Region "Funcionalidad del Control"
    Private Sub ProcesoBotones(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbComun.ButtonClick
        ' ***********************************
        ' Selecciono el Tag de cada Button
        ' Aunque puedo haber seleccionado
        ' el indice como:
        ' ToolBar1.Buttons.IndexOf(e.Button)
        ' ***********************************
        Select Case e.Button.Tag
            Case "Alta" : RaiseEvent Alta()
            Case "Baja" : RaiseEvent Baja()
            Case "Cambio" : RaiseEvent Cambio()
            Case "Guardar" : RaiseEvent Guardar()
            Case "Actualizar" : RaiseEvent Actualizar()
            Case "Vista" : RaiseEvent VistaPreliminar()
            Case "Imprimir" : RaiseEvent Imprimir()
            Case "Archivo" : RaiseEvent ExportaArchivo()
            Case "Buscar" : RaiseEvent Buscar()
            Case "Cerrar" : RaiseEvent Cerrar()
            Case "Ayuda" : RaiseEvent Ayuda()
            Case "Aceptar" : RaiseEvent Aceptar()
            Case "Cancelar" : RaiseEvent Cancelar()
            Case "Anular" : RaiseEvent Anular()
            Case "Confirmar" : RaiseEvent Confirmar()
            Case "Reversar" : RaiseEvent Reversar()
            Case "Calcular" : RaiseEvent Calcular()
        End Select
    End Sub

    Public Sub HabilitaVisible(Optional ByVal pBolEstado As Boolean = True)
        AltaVisible = pBolEstado
        BajaVisible = pBolEstado
        CambioVisible = pBolEstado
        ActualizarVisible = pBolEstado
        PreliminarVisible = pBolEstado
        ImprimirVisible = pBolEstado
        ExpArchivoVisible = pBolEstado
        BuscarVisible = pBolEstado
        AnularVisible = pBolEstado
        ConfirmarVisible = pBolEstado
        ReversarVisible = pBolEstado

        GuardarVisible = Not pBolEstado
        AceptarVisible = Not pBolEstado
        CancelarVisible = Not pBolEstado
    End Sub

    Public Sub HabilitaEnabled(Optional ByVal pBolEstado As Boolean = True)
        AltaEnabled = pBolEstado
        BajaEnabled = pBolEstado
        CambioEnabled = pBolEstado
        ActualizarEnabled = pBolEstado

        PreliminarEnabled = pBolEstado
        ImprimirEnabled = pBolEstado
        ExpArchivoEnabled = pBolEstado
        BuscarEnabled = pBolEstado

        AnularEnabled = pBolEstado
        ConfirmarEnabled = pBolEstado
        ReversarEnabled = pBolEstado

        GuardarEnabled = Not pBolEstado
        AceptarEnabled = Not pBolEstado
        CancelarEnabled = Not pBolEstado
    End Sub
#End Region

    Private Sub Barra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
