'Esta clase la utilizo para guardar en un objeto el nombre del parametro del reporte y el valor
Namespace Ks.Com.Win.CystalReports.Net
    Public Class ParametrosReportes
        Private _NombreParamtero As String
        Public Property Nombre() As String
            Get
                Return _NombreParamtero
            End Get
            Set(ByVal value As String)
                _NombreParamtero = value
            End Set
        End Property

        Private _ValorParamtero As Object
        Public Property Valor() As Object
            Get
                Return _ValorParamtero
            End Get
            Set(ByVal value As Object)
                _ValorParamtero = value
            End Set
        End Property

        Sub New(ByVal Nombre As String, ByVal Valor As Object)
            Me.Nombre = Nombre
            Me.Valor = Valor
        End Sub
    End Class
End Namespace