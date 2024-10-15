Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Data.SqlClient
Public Class frmSplash
    Private configuracion As ActualizacionSistema = New ActualizacionSistema()
    Private rutaActualizacionFtp As String
    Private rutaActualizacionLocal As String
    Private NombreArchivoActualizacion As String
    Private detectoActualizacion As Boolean = False
    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        IniciarVentanaSplash()
    End Sub
    Private Sub frmSplash_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Function EncontroNuevoVersion() As Boolean
        Cursor.Current = Cursors.WaitCursor
        Dim encontro As Boolean = False
        Dim LocalUpdateFile As String = ""
        Try
            Dim RutaMasArchivoFTP As String
            RutaMasArchivoFTP = rutaActualizacionFtp + "/" + NombreArchivoActualizacion

            Dim RutaMasArchivoLocal As String
            RutaMasArchivoLocal = rutaActualizacionLocal + "\" + NombreArchivoActualizacion

            DescargaArchivo(RutaMasArchivoFTP, RutaMasArchivoLocal)

            'Verficar si ha descargado el archivo en ruta de actualzacion Local
            If Not File.Exists(RutaMasArchivoLocal) Then Throw New FileNotFoundException("No existe la ruta de Actualizacion local", LocalUpdateFile)


            Dim versionOnline As String = configuracion.ObtenerVersionWeb(rutaActualizacionLocal, NombreArchivoActualizacion)
            Dim versionLocal As String = configuracion.ObtenerVersion()

            If Convert.ToInt32(versionLocal) < Convert.ToInt32(versionOnline) Then
                encontro = True
            ElseIf Convert.ToInt32(versionLocal) = Convert.ToInt32(versionOnline) Then
                encontro = False
            End If

        Catch exWebException As WebException
            MessageBox.Show("Error al iniciar sesion en el servidor o descargar archivo de actualizacion:" & exWebException.Message)
        Catch exInputOutpu As System.IO.IOException
            MessageBox.Show("Error al gestionar archivo: " & exInputOutpu.Message)
        Catch ex As Exception
            MessageBox.Show("Error  en [buscar actualizaciones] : " & ex.Message)
            encontro = False
        End Try

        Cursor.Current = Cursors.[Default]
        Return encontro
    End Function
    Private Sub IniciarVentanaSplash()
        Try
            Dim LocalUpdateFile As String = ""

            CheckForIllegalCrossThreadCalls = False
            lblSistema.Text = configuracion.ObtenerNombreModulo()
            lblversion.Text = "V" & configuracion.ObtenerVersionUsuario()
            lblcopyright.Text = ""
            'Ruta de actualziacion FTP y Local
            'Ruta FTP, donde estan los archivos para actualizacion : FTP/Empresa/Modulo/ArchivosParaActualizacion
            rutaActualizacionFtp = configuracion.ObtenerRutaFTPActualizacion()
            'Ruta donde se instalo el archivo para actualizacion : appData/Empresa/Modulo/ArchivosParaActualizacion
            rutaActualizacionLocal = configuracion.ObtenerRutaLocalActualizacion()
            'Nombre Archivo de Actualizacion, se descarga desde  el FTP
            NombreArchivoActualizacion = configuracion.ObtenerNombreArchivoActualizacion()
            'Limpia Todos los archivos de la carpeta de actualizacion Local
            LimpiarArchivosDescargados(rutaActualizacionLocal)

        Catch exSql As System.Data.SqlClient.SqlException
            MessageBox.Show("Error conexion al servidor :" & exSql.Message)
        Catch ex As Exception
            MessageBox.Show("Error al cargar formulario: " & ex.Message)
        End Try
    End Sub
    Private Sub IniciarVentanaLogin()

        Dim frmIngreso As MDIPrincipal = New MDIPrincipal()
        frmIngreso.Show()
        Me.Hide()
    End Sub
    Private Sub IniciarActualizador()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim nombreEjecutable As String = "", rutaEjecutable As String = ""
            Dim tipoEjecucion As String = "", cadenaConexion As String = "", nombreCarpetaEmpresa As String = "",
                nombreCarpetaModulo As String = "", nombreEjecutableModulo As String = "",
                nombreConfig As String = "", versionprograma As String = "",
                RutaParaProbarActualizacion As String = "",
                modoDesarrollo As String = "",
                RutaDondeEstaINstaladoElPrograma As String = ""
            Dim nombreCarpetaParche As String = "", nombreScript As String = "", nombreZip As String = ""
            nombreEjecutable = configuracion.ObtenerNombreActualizador()
            rutaEjecutable = Path.Combine(Application.StartupPath, nombreEjecutable)
            tipoEjecucion = configuracion.ObtenerTipoEjecucion()
            'cadenaConexion = Rijndael.Desencriptar(configuracion.ObtenerCadenaConexion()).Replace(" "c, "_"c)
            If configuracion.ObtenerCadenaConexion().Contains("§") = True Then
                MsgBox("La cadena conexion contiene caracter prohibido")
                Return
            End If

            If configuracion.ObtenerNombreEmpresa().Contains("§") = True Then
                MsgBox("El nombre de empresa contiene caracter prohibido")
                Return
            End If
            cadenaConexion = (configuracion.ObtenerCadenaConexion()).Replace(" "c, "§"c)
            nombreCarpetaEmpresa = configuracion.ObtenerNombreEmpresa().Replace(" "c, "§"c)
            nombreCarpetaModulo = configuracion.ObtenerNombreModulo()
            nombreEjecutableModulo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name & ".exe"
            nombreConfig = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name & ".exe.config"
            versionprograma = configuracion.ObtenerVersion()
            'RutaParaProbarActualizacion = configuracion.ObtenerRutaParaProbarActualizacion().Replace(" "c, "§"c)
            RutaDondeEstaINstaladoElPrograma = configuracion.ObtenerRutaDondeEstaInstaladoElPrograma().Replace(" "c, "§"c)
            nombreCarpetaParche = configuracion.ObtenerNombreCarpetaActualizacion()
            nombreScript = configuracion.ObtenerNombreScript()
            nombreZip = configuracion.ObtenerNombreZip()

            If configuracion.EsModoDesarrollo() = True Then
                modoDesarrollo = "SI"
            Else
                modoDesarrollo = "NO"
            End If

            Dim datosconcatenados As String = tipoEjecucion & "|" & cadenaConexion & "|" & nombreCarpetaEmpresa & "|" & nombreCarpetaModulo & "|" &
                nombreEjecutableModulo & "|" & nombreConfig & "|" & versionprograma & "|" & RutaParaProbarActualizacion & "|" & modoDesarrollo &
                "|" & nombreCarpetaParche & "|" & nombreScript & "|" & nombreZip


            Process.Start(rutaEjecutable, datosconcatenados)

        Catch ex As Exception
            'Util.ShowError("Error al iniciarActualizar :" & ex.Message)
            MessageBox.Show("Error al iniciarActualizar :" & ex.Message)
        End Try

        Cursor.Current = Cursors.[Default]
    End Sub
    Private Sub LimpiarArchivosDescargados(ByVal rutaActualizacionLocalaborrar As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim files As String() = Directory.GetFiles(rutaActualizacionLocalaborrar)

            For Each f As String In files
                File.Delete(f)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al limpiar archivos descargos : " & ex.Message)
            Application.[Exit]()
        End Try

        Cursor.Current = Cursors.[Default]
    End Sub
    Private Function DescargarArchivosActualizacion() As Boolean
        Dim operacionExitoso As Boolean = False
        Try
            Dim nombreDebug As String = "", nombreScript As String = ""

            Dim RutaMasArchivoFTP As String
            Dim RutaMasArchivoLocal As String

            'Descargo Debug.zip
            nombreDebug = configuracion.ObtenerNombreZip()
            RutaMasArchivoFTP = rutaActualizacionFtp + "/" + nombreDebug
            RutaMasArchivoLocal = rutaActualizacionLocal + "\" + nombreDebug
            DescargaArchivo(RutaMasArchivoFTP, RutaMasArchivoLocal)

            'Descargo Script
            RutaMasArchivoFTP = ""
            RutaMasArchivoLocal = ""
            nombreScript = configuracion.ObtenerNombreScript()
            RutaMasArchivoFTP = rutaActualizacionFtp + "/" + nombreScript
            RutaMasArchivoLocal = rutaActualizacionLocal + "\" + nombreScript
            DescargaArchivo(RutaMasArchivoFTP, RutaMasArchivoLocal)

            operacionExitoso = True
        Catch ex As Exception
            MessageBox.Show("Error al descargar archivos de actualizacion , detalle : " & ex.Message)
        End Try

        Return operacionExitoso
    End Function
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try

            If detectoActualizacion = True Then
                Dim versionOnline As String = ""
                versionOnline = configuracion.ObtenerVersionWeb(rutaActualizacionLocal, NombreArchivoActualizacion)

                If MessageBox.Show(String.Format("Version {0} disponible," & vbLf & "Actualizar?", versionOnline), "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    If DescargarArchivosActualizacion() = True Then
                        IniciarActualizador()
                    End If
                Else
                    IniciarVentanaLogin()
                End If
            ElseIf detectoActualizacion = False Then
                IniciarVentanaLogin()
            End If

        Catch ex As Exception
            'Util.ShowError("Error [RunWorkCompleted]: " & ex.Message)
            MessageBox.Show("Error [RunWorkCompleted]: " & ex.Message)
            Application.[Exit]()
        End Try
    End Sub
    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Cursor.Current = Cursors.WaitCursor

        Try
            detectoActualizacion = EncontroNuevoVersion()
        Catch exSql As System.Data.SqlClient.SqlException
            MessageBox.Show("Error en conexion a base de datos, revisar detalle:" & exSql.Message)
        Catch ex As Exception
            MessageBox.Show("Error en proceso de actualizacion revisar detalle :" & ex.Message)
        End Try

        Cursor.Current = Cursors.[Default]
    End Sub
    Private Sub DescargaArchivo(ByVal RutaMasArchivoFTP As String, ByVal RutaMasArchivoLocal As String)
        Cursor.Current = Cursors.WaitCursor
        Dim user As String = "", pass As String = ""

        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(RutaMasArchivoFTP), FtpWebRequest)
            Dim clienteWeb As WebClient = New WebClient()
            user = configuracion.ObtenerUsuario()
            pass = configuracion.ObtenerClave()
            request.Credentials = New NetworkCredential(user, pass)
            request.UseBinary = True
            request.Method = WebRequestMethods.Ftp.DownloadFile
            Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream()

            If File.Exists(RutaMasArchivoLocal) Then
                File.Delete(RutaMasArchivoLocal)
            End If

            Dim writer As FileStream = New FileStream(RutaMasArchivoLocal, FileMode.Create)
            Dim length As Long = response.ContentLength
            Dim bufferSize As Integer = 2048
            Dim readCount As Integer
            Dim buffer As Byte() = New Byte(2047) {}
            readCount = responseStream.Read(buffer, 0, bufferSize)

            While readCount > 0
                writer.Write(buffer, 0, readCount)
                readCount = responseStream.Read(buffer, 0, bufferSize)
            End While

            responseStream.Close()
            response.Close()
            writer.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Dim mensaje As String = "Instale o Actualice como administrador: " & Environment.NewLine & "Clic derecho sobre icono del programa -> Ejecutar como administrador"
            MessageBox.Show(mensaje & " detalle: " & ex.Message, "Sistema")
            Application.[Exit]()
        End Try

        Cursor.Current = Cursors.[Default]
    End Sub

End Class