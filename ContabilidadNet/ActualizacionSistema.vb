Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Configuration
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Data.SqlClient
Public Class ActualizacionSistema
    Private nombreArchivoLocal As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name & ".exe.config"
    Private cn As SqlConnection
    Public Sub New()
    End Sub
    Private Function LeerXml(ByVal rutaArchivo As String, ByVal nombreNodo As String) As String
        Dim xml As XmlDocument
        Dim nodo As XmlNode
        Dim valor As String = ""

        Try
            xml = New XmlDocument()
            xml.Load(rutaArchivo)
            nodo = xml.DocumentElement.SelectSingleNode("//configuration/appSettings/add[@key='" & nombreNodo & "']").Attributes("value")
            valor = nodo.Value.ToString()
        Catch exIO As IOException
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            MessageBox.Show("Error al obtener ruta origen version web :" & ex.Message)
            'Util.ShowError("Error al obtener ruta origen version web :" & ex.Message)
        End Try

        Return valor
    End Function
    Private Function LeerXMLConexionWeb() As String
        Dim xml As XmlDocument = New XmlDocument()
        Dim rutaArchivo As String = "", valor As String = ""

        Try
            rutaArchivo = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            xml.Load(rutaArchivo)
            Dim nodo As XmlNode = xml.DocumentElement.SelectSingleNode("//configuration/connectionStrings/add[@name='cnnInventarioWeb']").Attributes("connectionString")
            valor = nodo.Value.ToString()
        Catch ex As Exception
            MessageBox.Show("Error al leer xml:" & ex.Message & "ruta de archivo configuracion: " & rutaArchivo & " nodo : cnnInventarioWeb")
        End Try

        Return valor
    End Function
    Friend Function ObtenerNombreArchivoActualizacion() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "VersionFTP")
        Catch ex As Exception
            ' Util.ShowError("Error al obtener nombre de archivo  actualizacion, detalle : " & ex.Message)
            MessageBox.Show(("Error al obtener nombre de archivo  actualizacion, detalle : " & ex.Message))
        End Try

        Return valor
    End Function
    Friend Function ObtenerRutaFTPActualizacion() As String
        Dim valor As String = "", ServidorFTP As String = "", nombreCarpetaParaActualizacion As String = "", nombreEmpresa As String = "", nombreModulo As String = ""
        Dim RutaFtp As String
        Try
            ServidorFTP = ObtenerDireccionFTP()
            nombreEmpresa = ObtenerNombreEmpresa()
            nombreModulo = ObtenerNombreModulo()
            nombreCarpetaParaActualizacion = ObtenerNombreCarpetaActualizacion()

            ' / : BackSlash cuando es direccion web
            RutaFtp = ServidorFTP + "/" + nombreEmpresa + "/" + nombreModulo + "/" + nombreCarpetaParaActualizacion
            valor = RutaFtp.Replace("\", "/")
        Catch exIO As IOException
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            MessageBox.Show("Error al obtener ruta origen version web :" & ex.Message)
            'Util.ShowError("Error al obtener ruta origen version web :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerRutaLocalActualizacion() As String
        Dim valor As String = "", rutaAppData As String = "", nombreCarpetaParaActualizacion As String = "", nombreEmpresa As String = "", nombreModulo As String = ""
        Dim RutaActualizacionLocal As String
        Try
            rutaAppData = ObtenerRutaAppData()
            nombreEmpresa = ObtenerNombreEmpresa()
            nombreModulo = ObtenerNombreModulo()
            nombreCarpetaParaActualizacion = ObtenerNombreCarpetaActualizacion()

            ' \ : Slash cuando es direccion local
            RutaActualizacionLocal = rutaAppData + "\" + nombreEmpresa + "\" + nombreModulo + "\" + nombreCarpetaParaActualizacion
            'valor = Path.Combine(rutaAppData, nombreArchivoActualizacion)
            valor = RutaActualizacionLocal
        Catch exIO As IOException
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al obtener ruta destino version web :" & ex.Message)
            MessageBox.Show("Error al obtener ruta destino version web :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerRutaAppData() As String
        Dim valor As String = "", rutaAppData As String = "", nombreEmpresa As String = "", nombreModulo As String = ""
        Try
            rutaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            valor = rutaAppData
        Catch exIO As IOException
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al obtener ruta AppData :" & ex.Message)
            MessageBox.Show("Error al obtener ruta AppData :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerNombreEmpresa() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "empresa")
        Catch exIO As IOException
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al obtenerm nombre de empresa :" & ex.Message)
            MessageBox.Show("Error al obtenerm nombre de empresa :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerNombreModulo() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "modulo")
        Catch exIO As IOException
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al obtener nombre de modulo :" & ex.Message)
            MessageBox.Show("Error al obtener nombre de modulo :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerUsuario() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "usuario")
        Catch exIO As IOException
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al obtener usuario :" & ex.Message)
            MessageBox.Show("Error al obtener usuario :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerClave() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "clave")
        Catch exIO As IOException
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al obtener clave :" & ex.Message)
            MessageBox.Show("Error al obtener clave :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerNombreActualizador() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "nombreActualizacion")
        Catch exIO As IOException
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al obtener nombre de actualizador:" & ex.Message)
            MessageBox.Show("Error al obtener nombre de actualizador:" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerDireccionFTP() As String
        Dim valor As String = "", rutaConfig As String = "", urlweb As String = ""
        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            urlweb = LeerXml(rutaConfig, "urlweb")
            valor = urlweb
            'valor = valor.Replace("\", "/")
        Catch exIO As IOException
            MessageBox.Show("Error al obtener direccion FTP : " & exIO.Message)
        Catch ex As Exception
            MessageBox.Show("Error al obtener direccion FTP:" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerVersionUsuario() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "versionUsuario")
        Catch exIO As IOException
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            MessageBox.Show("Error al obtener version :" & ex.Message)
            'Util.ShowError("Error al obtener version :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerVersion() As String
        Dim valor As String = "", rutaConfig As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "version")
        Catch exIO As IOException
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            MessageBox.Show("Error al obtener version :" & ex.Message)
            'Util.ShowError("Error al obtener version :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerVersionWeb(RutaLocalActualizacion As String, ArchivoNombre As String) As String
        Dim valor As String = "", rutaAppData As String = "", rutaConfigWeb As String = "", nombreArchivoActualizacion As String = ""

        Try
            rutaConfigWeb = Path.Combine(RutaLocalActualizacion, ArchivoNombre)
            valor = LeerXml(rutaConfigWeb, "version")
        Catch exIO As IOException
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            MessageBox.Show("Error al obtener version web:" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function EsModoActualiza() As Boolean
        Dim valor As String = "", rutaConfiguracion As String = ""
        Dim estado As Boolean = False

        Try
            rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfiguracion, "modoActualiza")

            If valor = "NO" Then
                estado = False
            ElseIf valor = "SI" Then
                estado = True
            End If

        Catch exIO As IOException
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al leer nodo actualiza:" & ex.Message)
            MessageBox.Show("Error al leer nodo actualiza:" & ex.Message)
        End Try

        Return estado
    End Function
    Friend Function ObtenerRutaParche() As String
        Dim valor As String = "", rutaAppData As String = "", nombreCarpeta As String = ""

        Try
            rutaAppData = ObtenerRutaAppData()
            nombreCarpeta = ObtenerNombreCarpetaActualizacion()
            valor = Path.Combine(rutaAppData, nombreCarpeta)
        Catch ex As Exception
            MessageBox.Show("Error en obtener ruta de parche :" & ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerNombreCarpetaActualizacion() As String
        Dim rutaConfig As String = "", valor As String = ""

        Try
            rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfig, "CarpetaActualizacion")
        Catch ex As Exception
            MessageBox.Show("Error Inesperado", ex.Message)
        End Try

        Return valor
    End Function
    Friend Function ObtenerNombreZip() As String
        Dim valor As String = "", rutaConfiguracion As String = ""
        rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal)
        valor = LeerXml(rutaConfiguracion, "nombreZip")
        Return valor
    End Function
    Friend Function ObtenerRutaDondeEstaInstaladoElPrograma() As String
        Dim valor As String = ""
        Dim rutaProgramaInstalado As String = ""
        rutaProgramaInstalado = Path.Combine(Application.StartupPath, nombreArchivoLocal)
        valor = LeerXml(rutaProgramaInstalado, "RutaDondeEstaInstaladoElPrograma")
        Return valor
    End Function
    Friend Function ObtenerRutaParaProbarActualizacion() As String
        Dim valor As String = "", RutaParaProbarActualizacion As String = ""
        RutaParaProbarActualizacion = Path.Combine(Application.StartupPath, nombreArchivoLocal)
        valor = LeerXml(RutaParaProbarActualizacion, "RutaParaProbarActualizacion")
        Return valor
    End Function
    Friend Function EsModoDesarrollo() As Boolean
        Dim valor As String = "", rutaConfiguracion As String = ""
        Dim estado As Boolean = False

        Try
            rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            valor = LeerXml(rutaConfiguracion, "modoDesarrollo")

            If valor = "NO" Then
                estado = False
            ElseIf valor = "SI" Then
                estado = True
            End If

        Catch exIO As IOException
            'Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            MessageBox.Show("Error al gestionar archivo : " & exIO.Message)
        Catch ex As Exception
            'Util.ShowError("Error al leer nodo actualiza:" & ex.Message)
            MessageBox.Show("Error al leer nodo actualiza:" & ex.Message)
        End Try

        Return estado
    End Function
    Friend Function ObtenerVersionBasedeDatos() As String
        Dim valor As String = "", rutaConfiguracion As String = ""
        rutaConfiguracion = Path.Combine(ObtenerRutaAppData(), nombreArchivoLocal)
        valor = LeerXml(rutaConfiguracion, "versionbd")
        Return valor
    End Function
    Friend Function ObtenerNombreScript() As String
        Dim valor As String = "", rutaConfiguracion As String = ""
        rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal)
        valor = LeerXml(rutaConfiguracion, "nombreScript")
        Return valor
    End Function
    Friend Function ObtenerTipoEjecucion() As String
        Dim valor As String = "", rutaConfiguracion As String = ""
        rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal)
        valor = LeerXml(rutaConfiguracion, "modoEjecucion")
        Return valor
    End Function
    Friend Function ObtenerCadenaConexion() As String
        Dim valor As String = "", rutaConfiguracion As String = ""
        Dim xml As XmlDocument = New XmlDocument()

        Try
            rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal)
            xml.Load(rutaConfiguracion)
            Dim nodo As XmlNode = xml.DocumentElement.SelectSingleNode("//configuration/connectionStrings/add[@name='cnnInventario']").Attributes("connectionString")
            valor = nodo.Value.ToString()
        Catch ex As Exception
            MessageBox.Show("Error al leer xml : " & ex.Message)
        End Try

        Return valor
    End Function
End Class
