Public Class ksComboBox
    Inherits System.Windows.Forms.ComboBox

#Region "Constructor"
    Public Sub New()
        ' Invoco Contructor de la clase Base
        MyBase.New()
        InicializaControl()
    End Sub
#End Region

#Region "Propiedades"
    Private mBlnTabulado As Boolean
    Private mBlnRequiereDatoGuardar As Boolean
    Private mBlnLimpiaControl As Boolean

    Public Property ueTabulado() As Boolean
        ' Propiedad que indica si el control 
        ' ejecuta el TabIndex
        ' cuando se presiona la tecla
        ' Enter o de Avance
        Get
            Return mBlnTabulado
        End Get
        Set(ByVal Value As Boolean)
            mBlnTabulado = Value
        End Set
    End Property

    Public Property ueRequiereDatoGuardar() As Boolean
        ' Indica si al guardar requiere dato
        Get
            Return mBlnRequiereDatoGuardar
        End Get
        Set(ByVal value As Boolean)
            mBlnRequiereDatoGuardar = value
        End Set
    End Property

    Public Property ueLimpiaControl() As Boolean
        Get
            Return mBlnLimpiaControl
        End Get
        Set(ByVal value As Boolean)
            mBlnLimpiaControl = value
        End Set
    End Property

#End Region

#Region "Valores Iniciales del control"
    Private Sub InicializaControl()
        ueTabulado = True
        mBlnRequiereDatoGuardar = True
        ueLimpiaControl = True
    End Sub
#End Region

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        If mBlnTabulado = True Then
            Dim intTecla As Integer
            intTecla = Asc(e.KeyChar)
            If intTecla = 13 Then SendKeys.Send("{tab}") : Exit Sub
        End If
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)
        If MyBase.Enabled = False Then  ' verde: 247, 250, 255
            MyBase.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
            MyBase.ForeColor = Color.Black
        Else
            MyBase.BackColor = Color.White
            MyBase.ForeColor = Color.Black
        End If
    End Sub
End Class
