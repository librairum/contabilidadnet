Public Class BarraAccion

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

    ' Metodos

    Public Overridable Sub Listar(ByVal Grilla As Object, ByVal BindingNavigator As Object)

        Dim dataSource As New BindingSource(Grilla.DataSource, Nothing)
        BindingNavigator.BindingSource = dataSource
        Grilla.DataSource = BindingNavigator.BindingSource
    End Sub

    Public Overridable Sub Nuevo()

    End Sub

    Public Overridable Sub Editar()

    End Sub

    Public Overridable Sub Eliminar()

    End Sub

    Public Overridable Sub Buscar()

    End Sub

    Public Overridable Sub Preliminar()

    End Sub

    Public Overridable Sub Imprimir()

    End Sub

    Public Overridable Sub Exportar()

    End Sub

    Public Overridable Sub Generar()

    End Sub

    Public Overridable Sub Guardar()

    End Sub

    Public Overridable Sub Cancelar()

    End Sub

    Public Overridable Sub Confirmar()

    End Sub

    Public Overridable Sub Reversar()

    End Sub

    Public Overridable Sub Anular()

    End Sub

    Public Overridable Sub Salir()

    End Sub

    Public Overridable Sub Ficha()
        If tbDetalle.Text = "Ficha" Then
            tbDetalle.Text = "Lista"
            MostrarFicha(True)
        Else
            tbDetalle.Text = "Ficha"
            MostrarFicha(False)
        End If
    End Sub

    Private Sub BarraProceso(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    tbNuevo.Click, tbEliminar.Click, tbEditar.Click, tbRefrescar.Click, _
                    tbPreliminar.Click, tbImprimir.Click, tbExcel.Click, _
                    tbGenerar.Click, tbGuardar.Click, tbConfirmar.Click, tbReversar.Click, tbCancelar.Click, _
                    tbAnular.Click, tbSalir.Click, tbDetalle.Click

        ' ****************************************************************
        ' Autor     : Edgar Huarcaya C
        ' Objetivo  : Opciones de la barra
        ' Fecha     : 13 Dic 2008
        ' ****************************************************************
        Select Case CType(sender, ToolStripButton).Name
            Case "tbNuevo"
                Nuevo()

            Case "tbEliminar"
                Eliminar()

            Case "tbEditar"
                Editar()

            Case "tbRefrescar"
                Listar(Nothing, Nothing)

            Case "tbPreliminar"
                Preliminar()

            Case "tbImprimir"
                Imprimir()

            Case "tbExcel"
                Exportar()

            Case "tbGenerar"
                Generar()

            Case "tbGuardar"
                Guardar()

            Case "tbCancelar"
                Cancelar()

            Case "tbConfirmar"
                Confirmar()

            Case "tbReversar"
                Reversar()

            Case "tbAnular"
                Anular()

            Case "tbDetalle"
                Ficha()

            Case "tbSalir"
                Salir()

        End Select
    End Sub

    Public Overridable Sub InicializarOpciones()

    End Sub

    Public Overridable Sub CargarFomulario(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    ''' <summary>Metodo que habilita y deshabilita el boton de mantenimiento</summary>
    ''' <remarks>
    ''' <creadopor>Edgar Huarcaya C.</creadopor>
    ''' <fechacreacion>18/12/2008</fechacreacion>
    ''' <empresa>Key Solutions S.R.L</empresa>
    ''' <fechamodificacion></fechamodificacion>
    ''' </remarks>
    Public Overridable Sub HabilitarEnabled(ByVal pblnEstado As Boolean)
        ueRefrescarEnabled = pblnEstado
        ueNuevoEnabled = pblnEstado
        ueEditarEnabled = pblnEstado
        ueEliminarEnabled = pblnEstado
        ueDetalleEnabled = pblnEstado

        ueGuardarEnabled = Not pblnEstado
        ueCancelarEnabled = Not pblnEstado
    End Sub

    ''' <summary>Metodo que visualiza y oculta el boton de mantenimiento</summary>
    ''' <remarks>
    ''' <creadopor>Edgar Huarcaya C.</creadopor>
    ''' <fechacreacion>18/12/2008</fechacreacion>
    ''' <empresa>Key Solutions S.R.L</empresa>
    ''' <fechamodificacion></fechamodificacion>
    ''' </remarks>
    Public Overridable Sub HabilitarVisible(ByVal pblnEstado As Boolean)
        ueRefrescarVisible = pblnEstado
        ueNuevoVisible = pblnEstado
        ueEditarVisible = pblnEstado
        ueEliminarVisible = pblnEstado
        ueEditarVisible = pblnEstado

        ueGuardarVisible = Not pblnEstado
        ueCancelarVisible = Not pblnEstado
    End Sub

    Public Overridable Sub ValorInicial()

    End Sub

    Public Overridable Sub Limpiar()

    End Sub

    Public Overridable Sub FormatearGrilla()

    End Sub

    Public Overridable Sub MostrarFicha(ByVal pblnEstado As Boolean)

    End Sub

    Public Overridable Sub EnlazarData()

    End Sub

    ''' <summary>Metodo que valida los cambos de cajas de textos, combos, label, etc.</summary>
    ''' <remarks>
    ''' <creadopor>Edgar Huarcaya C.</creadopor>
    ''' <fechacreacion>20/12/2008</fechacreacion>
    ''' <empresa>Key Solutions S.R.L</empresa>
    ''' <fechamodificacion></fechamodificacion>
    ''' </remarks>
    Public Function ValidarCampo(ByVal parrControles As ArrayList) As Boolean
        Dim blnRetorno As Boolean = True
        Try
            Dim i As Integer, c As Control = Nothing
            For i = 0 To parrControles.Count - 1
                If TypeOf (parrControles(i)) Is Control Then
                    c = CType(parrControles(i), Control)
                    If TypeOf (c) Is TextBox Or TypeOf (c) Is Ks.UserControl.ksTextBox Then
                        If c.Text = "" And c.Visible = True Then
                            Throw New Exception("Falta ingresar el campo: " & c.Tag.ToString)
                            If c.Visible And c.Enabled = True Then c.Focus()
                            blnRetorno = False
                            Exit For
                        End If
                    End If

                    If TypeOf (c) Is ComboBox Or TypeOf (c) Is Ks.UserControl.ksComboBox Then
                        If c.Text = "" And c.Visible = True Then
                            Throw New Exception("Falta seleccionar el campo: " & c.Tag.ToString)
                            If c.Visible And c.Enabled = True Then c.Focus()
                            blnRetorno = False
                            Exit For
                        End If
                    End If
                End If
            Next

            ' Retorno
            Return blnRetorno
        Catch ex As Exception
        End Try
    End Function
End Class
