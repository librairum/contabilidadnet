' ***************************
' Numeraciones
' ***************************
Public Enum ValorPermitido
    enmVTodos = 0
    enmVNumero = 1
    enmVLetras = 2
End Enum

Public Class ksTextBox
    ' Hereda de la clase 
    ' System.Windows.Forms.TextBox
    Inherits System.Windows.Forms.TextBox

    Public Sub New()
        ' Invoco Contructor de la clase Base
        MyBase.New()
        InicializaControl()
    End Sub

#Region "Propiedades"
    Private enmValorPermitido As ValorPermitido
    Private mIntNroDecimal As Short
    Private mBlnTabulado As Boolean
    Private mBlnSelectGotFocus As Boolean

    ' Propiedad para personalizar el tipo de dato ingresado
    Public Property ValorAceptado() As ValorPermitido
        Get
            Return enmValorPermitido
        End Get
        Set(ByVal Value As ValorPermitido)
            enmValorPermitido = Value

            ' Verifico la propiedad seleccionada
            ' Si es numerico o solo letras
            ' Limpia el Cuadro de Texto
            If enmValorPermitido = ValorPermitido.enmVLetras Then
                MyBase.Text = ""
                MyBase.TextAlign = HorizontalAlignment.Left
                Exit Property
            End If
            If enmValorPermitido = ValorPermitido.enmVNumero Then
                MyBase.Text = "0"
                If IsNumeric(MyBase.Text) Then
                    MyBase.Text = FormateaValor(CType(MyBase.Text, Double))
                End If
                MyBase.TextAlign = HorizontalAlignment.Right
                Exit Property
            End If
        End Set
    End Property

    ' Propiedades que para guardar Nor. decimales
    ' cuando el tipo de dato es numerico
    Public Property NroDecimales() As Short
        Get
            Return mIntNroDecimal
        End Get
        Set(ByVal Value As Short)
            mIntNroDecimal = Value
            If IsNumeric(Me.Text) And enmValorPermitido = ValorPermitido.enmVNumero Then
                Me.Text = FormateaValor(CType(Me.Text, Double))
            End If
        End Set
    End Property

    Public Property Tabulado() As Boolean
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

    Public Property SelectGotFocus() As Boolean
        ' Indica que al posicionar en el control
        ' se selecciona el contenido del Texto
        Get
            Return mBlnSelectGotFocus
        End Get
        Set(ByVal Value As Boolean)
            mBlnSelectGotFocus = Value
        End Set
    End Property
#End Region

#Region "Funciones privadas"
    Private Function Mascara(ByVal intCantidad As Integer) As String
        Dim i As Integer, strCadena As String = "", strMarcara As String = ""
        If intCantidad <= 0 Then Return "###,###,###,##0"
        For i = 1 To intCantidad
            strCadena = strCadena & "0"
        Next

        strMarcara = "###,###,###,##0." & strCadena

        Return strMarcara
    End Function

    Private Function Mascara1(ByVal intCantidad As Integer) As String
        Dim i As Integer, strCadena As String = "", strMarcara As String = ""
        If intCantidad <= 0 Then Return "###########0"
        For i = 1 To intCantidad
            strCadena = strCadena & "0"
        Next

        strMarcara = "###########0." & strCadena

        Return strMarcara
    End Function

    Public Function FormateaValor(ByVal pDblValor As Double, Optional ByVal pBlnGotFocus As Boolean = False) As String
        Dim strValor As String = ""
        Dim strMasrcara As String

        If pBlnGotFocus = False Then
            strMasrcara = Mascara(NroDecimales)
        Else
            strMasrcara = Mascara1(NroDecimales)
        End If

        strValor = Format(pDblValor, strMasrcara)

        Return strValor
    End Function
#End Region

#Region "Valores Iniciales del control"
    Private Sub InicializaControl()
        Tabulado = True
        SelectGotFocus = True
        ValorAceptado = ValorPermitido.enmVTodos
    End Sub
#End Region

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim intTecla As Integer
        ' Capturo la tacla presiona
        intTecla = Asc(e.KeyChar)

        If intTecla = 8 Or intTecla = 13 Or enmValorPermitido = ValorPermitido.enmVTodos Then
            ' Si la tecla 8 o 13 o todos
            ' Acepta cualquier caracter
            ' debe aceptar todos los datos 
            ' sin realizar ninguna accion
        End If

        If enmValorPermitido = ValorPermitido.enmVLetras Then
            ' Acepta solo letras
            If intTecla = 8 Or intTecla = 13 Or (intTecla >= 65 And intTecla <= 122) Then
                ' Se aceptan dichos caracteres sin realizar ninguna accion
            Else
                intTecla = 0
            End If
        End If

        If enmValorPermitido = ValorPermitido.enmVNumero Then
            ' Si el valor permitido es numerico
            Select Case intTecla
                Case 48 To 57, 8, 13 ' Digitos, BackSpace, Enter
                    ' Se aceptan dichos caracteres sin realizar ninguna accion
                    ' Verifica la cantidad de decimales

                    'If intTecla >= 48 And intTecla <= 57 Then
                    '    Dim intEntero As Integer
                    '    Dim dblDecimal As Double
                    '    Dim intDecimales As Integer
                    '    Dim strDecimales As String
                    '    Dim strCarac As String
                    '    strCarac = e.KeyChar
                    '    intEntero = Int(CType((Me.Text & strCarac), Decimal))
                    '    dblDecimal = Val(Me.Text & strCarac) - intEntero
                    '    strDecimales = Trim$(CType(dblDecimal, String))
                    '    strDecimales = Mid(strDecimales, 2, Len(strDecimales) - 2)
                    '    intDecimales = Len(strDecimales)
                    '    If mIntNroDecimal > intDecimales Then
                    '        intTecla = 0
                    '    End If
                    'End If

                    'If IsNumeric(Me.Text) Then
                    'Me.Text = FormateaValor(CType(Me.Text, Double))
                    'End If
                Case 45 ' Simbolo menos
                    ' Solo puede existir un simbolo menos en el número
                    If InStr(Me.Text, "-") <> 0 Then

                        ' Ubica la posicion de signo menos
                        intTecla = 0
                    End If

                    ' Simbolo se acepta el simbolo menos en la primera posicion
                    If Me.SelectionStart <> 0 Then
                        intTecla = 0
                    End If


                Case 46 ' Punto decimal
                    ' Solo se acepta un punto decimal en la expresion numérica
                    If InStr(Me.Text, ".") <> 0 Then
                        intTecla = 0
                    End If

                    If mIntNroDecimal = 0 Then
                        intTecla = 0
                    End If

                Case Else
                    ' Cualquier otro caracter
                    intTecla = 0

            End Select
        End If

        ' ***************************
        ' Manipula el evento
        ' ***************************
        If intTecla = 0 Then
            ' Desactiva la tecla pulsada
            ' Ignora la tecla pulsada
            e.Handled = True
        Else
            ' Acepta la tecla pulsada
            e.Handled = False
        End If
    End Sub

    Public Overrides Property Text() As String
        Get
            ' Retorno el Text de la clase base
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            If enmValorPermitido = ValorPermitido.enmVTodos Then
                ' Si la tecla 8 o 13 o todos
                ' Acepta cualquier caracter
                ' debe aceptar todos los datos 
                ' sin realizar ninguna accion
                MyBase.Text = Value
                Exit Property
            End If

            If enmValorPermitido = ValorPermitido.enmVLetras Then
                ' Si es solo letras entonces limpia
                MyBase.Text = ""
                Exit Property
            End If

            If enmValorPermitido = ValorPermitido.enmVNumero Then
                ' Si es solo numérico
                If IsNumeric(Value) And enmValorPermitido = ValorPermitido.enmVNumero Then
                    MyBase.Text = FormateaValor(CType(Value, Double))
                    Exit Property
                End If
            End If
            If Value = Nothing Then
                MyBase.Text = Value
                Exit Property
            End If
        End Set
    End Property

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If mBlnTabulado = True Then
            Dim intTecla As Integer
            intTecla = e.KeyCode

            If intTecla = 13 Or intTecla = 40 Then SendKeys.Send("{tab}") : Exit Sub
            If intTecla = 38 Then SendKeys.Send("+{tab}") : Exit Sub
            If e.KeyCode = Keys.F1 Then MyBase.OnKeyDown(e)
        End If
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        'If IsNumeric(Me.Text) And enmValorPermitido = ValorPermitido.enmVNumero Then
        'Me.Text = FormateaValor(CType(Me.Text, Double), True)
        'End If

        If mBlnSelectGotFocus = True Then
            Me.SelectionStart = 0
            Me.SelectionLength = Len(Me.Text)
        End If
        If Me.ReadOnly = False Then
            Me.BackColor = Color.Orange
            'Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        End If
    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        If IsNumeric(Me.Text) And enmValorPermitido = ValorPermitido.enmVNumero Then
            Me.Text = FormateaValor(CType(Me.Text, Double))
        End If
        If Me.ReadOnly = False Then
            Me.BackColor = Color.White
        End If
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)
        If MyBase.Enabled = False Then
            MyBase.BackColor = Color.White
            MyBase.ForeColor = Color.Black

        Else
            MyBase.BackColor = Color.White
            MyBase.ForeColor = Color.Black
        End If
    End Sub

    Protected Overrides Sub OnReadOnlyChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)
        If MyBase.ReadOnly = True Then  ' verde: 247, 250, 255
            MyBase.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
            MyBase.ForeColor = Color.Black
        Else
            MyBase.BackColor = Color.White
            MyBase.ForeColor = Color.Black
        End If
    End Sub
End Class
