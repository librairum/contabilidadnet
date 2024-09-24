Public NotInheritable Class ueEntidad
    Private _Codigo As String
    Private _Descripcion As String

    Public Sub New(ByVal pStrCodigo As String, ByVal pStrDescripcion As String)
        _Codigo = pStrCodigo
        _Descripcion = pStrDescripcion
    End Sub

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
End Class
