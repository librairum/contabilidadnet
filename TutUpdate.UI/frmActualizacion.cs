using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Windows.Forms;

//Referencia

using System.Net;
using System.IO;
using System.Xml;


using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

//Libreria de .zip
using Ionic.Zip;

using System.Data.SqlClient;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace TutUpdate.UI
{
    public partial class frmActualizacion : Form
    {

        bool procesoOK = false;
        private string _flagEjecucion = "", _cadenaConexion = "", 
                        _carpetaEmpresa = "", _carpetaModulo = "", 
                        _nombreEjecutable = "", _archivoConfiguracion = "",
                        _versionAnteriorPrograma = "", 
                        _RutaParaProbarActualizacion = "",
                        _ModoDesarrollo = "", _nombreCarpetaParche = "",
                        _nombreScript = "", _nombreZip = "";

        private SqlConnection cn;
        public frmActualizacion(string parametros)
        {
            InitializeComponent();
            //Importante : Datos para prueba
                //1. Cambiar a esta linea en program.cs : Application.Run(new frmActualizacion("a b|c|d"));
                //2. Pasar los parametros en duro como linea abajo
                                //parametros = @"Local|Data§Source=william;Initial§catalog=MasterCon_v4;Integrated§Security=false;§user§id=sa;§password=sasasa;|MasterCon|MasterCon|ContabilidadNet.exe|ContabilidadNet.exe.config|1|C:\Program§Files§(x86)\MasterCon\MasterCon|SI|ArchivosParaActualizacion|Actualizacion.sql|Debug.zip";
                //3. Despues de los cambios copiar los siguinetes archivos al Bin del programa a actualziar
                        //Ionic.Zip.dll
                        //TutUpdate.UI.exe
                        //TutUpdate.UI.exe.config
            
            string[] datos = parametros.Split('|');
            
            this._flagEjecucion = datos[0].ToUpper();
            this._cadenaConexion = datos[1].Replace('§', ' ');
            this._carpetaEmpresa = datos[2].Replace('§', ' ');
            this._carpetaModulo = datos[3];
            this._nombreEjecutable = datos[4];
            this._archivoConfiguracion = datos[5];
            this._versionAnteriorPrograma = datos[6];
            this._RutaParaProbarActualizacion = datos[7].Replace('§', ' ');
            this._ModoDesarrollo = datos[8];
            this._nombreCarpetaParche = datos[9];
            this._nombreScript = datos[10];
            this._nombreZip = datos[11];
            
            backgroundWorker1.WorkerReportsProgress = true;
            //configuracion = new ActualizacionSistema(this._cadenaConexion, this._carpetaEmpresa, this._carpetaModulo,
            //                this._nombreEjecutable, this._archivoConfiguracion, this._versionPrograma, 
            //                this._nombreCarpetaParche, this._nombreScript, this._nombreZip);
        }
        private void frmActualizacion_Load(object sender, EventArgs e)
        {                               
            try
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync();
                    this.pgbProgreso.Enabled = true;
                }                                
                //configuracion.CerrarProcesoPrograma();
                CerrarProcesoPrograma();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer SQL, detalle:" + ex.Message, 
                                "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmActualizacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            //configuracion.CargarAplicacion();
            string rutaEjecutable = "";
            try
            {
                rutaEjecutable = Path.Combine(Application.StartupPath, this._nombreEjecutable);

                if (File.Exists(rutaEjecutable) == true)
                {
                    System.Diagnostics.Process.Start(rutaEjecutable);
                }
                System.Windows.Forms.Application.Exit();
            }
            catch (IOException exIO)
            {
                MessageBox.Show("Error al buscar ruta de ejecutable, detalle : " +
                    exIO.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar aplicacion, detalle : " + ex.Message, "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            try
            {
                if (procesoOK == true)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MensajeError("Error background_workCompleted : " + ex.Message);
            }

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    // Remplazo los archivos del BIN
                    if (ActualizarArchivos() == false)
                    {
                        Application.Exit();
                    }

                    // Ejecuta Script, si BD Local
                    if (this._flagEjecucion == "LOCAL" || this._flagEjecucion == "HIBRIDO")
                    {
                        if (ActualizarBaseDatos() == false)
                        {
                            Application.Exit();
                        }
                    }
                    
                }                                
                procesoOK = true;
            }
            catch (Exception ex)
            {
                MensajeError("DownloadFile:" + ex.Message);
                Application.Exit();
            }

        }
        private string ObtenerRutaParche()
        {
            string valor = "", rutaAppData = "";
            try
            {
                rutaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //Ruta de parche AppData/NombreEmpresa/Modulo/(Archivos de actualziacion : debug.zip, actualizacion.config y 
                //credenciales.txt

                valor = Path.Combine(rutaAppData, this._carpetaEmpresa, this._carpetaModulo, this._nombreCarpetaParche);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en obtener ruta de parche :" + ex.Message);
            }
            return valor;
        }
        private void CerrarProcesoPrograma()
        {
            try
            {
                string nombreProceso = "";

                nombreProceso = this._nombreEjecutable.Substring(0, this._nombreEjecutable.Length - 4);

                //Buscar proceso y finalizarlo
                foreach (System.Diagnostics.Process proceso
                        in System.Diagnostics.Process.GetProcessesByName(nombreProceso))
                {
                    proceso.Kill();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar metodo cerrar proceso, detalle : " +
                     ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ActualizarBaseDatos()
        {
            string contenidoSQL = "";         
            //lee la ultima version desde el archivo actualizacion.config                                                
            
            bool operacionExitoso = false;
            try
            {
                contenidoSQL = LeerSQL(this._nombreScript);
                //contenidoSQL = configuracion.LeerSQL(this._nombreScript);
                //Si no encontro la linea con la version en el script , entonces, salta la ejecucion del script.
                if (contenidoSQL != "")
                {                    
                    //MessageBox.Show("Operacion exitosa", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //operacionExitoso = configuracion.EjecutarSQL(contenidoSQL);
                    operacionExitoso = EjecutarSQL(contenidoSQL);
                }
            }
            catch (SqlException exSql)
            {
                MessageBox.Show("Error al ejecutar procedimiento sql, detalle : " + exSql.Message, "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar procedimiento sql, detalle : " + ex.Message, "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return operacionExitoso;
        }
        private bool ActualizarArchivos()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool exito = false;
            try
            {
                //Leer las rutas de despliegue
                string rutaOrigen = "", rutaDestino = "";
                //Obtener la ruta de la descargar desde AppConfig                
                //rutaOrigen = Path.Combine(configuracion.ObtenerRutaParche(), this._nombreZip);
                rutaOrigen = Path.Combine(ObtenerRutaParche(), this._nombreZip);

                // === Capturar Ruta Destino
                if (_ModoDesarrollo=="SI")
                {
                    rutaDestino = _RutaParaProbarActualizacion;
                }
                else
                {
                       rutaDestino = Application.StartupPath;
                       if (rutaDestino.Contains("bin\\Debug") == true)
                    {
                        MessageBox.Show("Mensaje : No Se puede reamplazar Archivos de carpeta Bin/Debug, Cambie ModoDesarrollo a SI" + rutaDestino ,
                            "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Application.Exit();
                    }
                }

                // Validar que exista ruta donde esta instalado el sistema
                if (Directory.Exists(rutaDestino) == false)
                {
                    MessageBox.Show("VALIDAR : Ruta de instalacion No existe" + rutaDestino,
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }

                string rutaArchivoZip = rutaOrigen;
                ZipFile archivoZip = ZipFile.Read(rutaArchivoZip);
                archivoZip.ExtractAll(rutaDestino, ExtractExistingFileAction.OverwriteSilently);

                exito = true;
                procesoOK = true;
            }
            catch (Exception ex)
            {

                MensajeError("Error en metodo UpdateFile:" + ex.Message);
                exito = false; procesoOK = false;
            }
            Cursor.Current = Cursors.WaitCursor;
            return exito;
        }
        #region "Actualizacion de base de datos"
        private int EncontrarLineaEjecucion(string nombreArchivo, string nuevaVersionBaseDatos)
        {
            string rutaArchivo = Path.Combine(ObtenerRutaParche(), nombreArchivo);
            int nroFilaArchivo = -1;
            string[] lineas = File.ReadLines(rutaArchivo).ToArray();
            for (int x = 0; x < lineas.Length; x++)
            {
                if (nuevaVersionBaseDatos.ToUpper() == lineas[x].ToUpper())
                {
                    nroFilaArchivo = x;
                    break;
                }
            }
            return nroFilaArchivo;
        }
        private string LeerSQL(string nombreArchivo)
        {
            string contenidoArchivo = "", prefijoBD = "--@V";
            //Buscar la linea de fin 
            string marcador = prefijoBD + this._versionAnteriorPrograma + " End";
            string rutaArchivo = Path.Combine(ObtenerRutaParche(), nombreArchivo);

            int posicionLinea = EncontrarLineaEjecucion(nombreArchivo, marcador);
            if (posicionLinea == -1)
            {
                return "";
            }

            int cantidadLineas = File.ReadLines(rutaArchivo).ToArray().Length - posicionLinea;

            string[] contenido = new string[cantidadLineas];
            StringBuilder sb = new StringBuilder();
            try
            {
                rutaArchivo = Path.Combine(ObtenerRutaParche(), nombreArchivo);
                contenido = File.ReadLines(rutaArchivo).Skip(posicionLinea).ToArray();
                for (int x = 0; x < contenido.Length; x++)
                {
                    sb.AppendLine(contenido[x]);
                }

                //Agregar linea de actualizacion de base de datos
                //sb.AppendLine("Update BDAtributos "+
                //              " set VersionBD = " + this.ObtenerNuevaVersion() + ","+
                //                " VersionBDFecha = getdate(), VersionBDHora = getdate()" +
                //                " where VersionBD = " + this._versionPrograma);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer lineas de texto, detalle : " + ex.Message);
            }
            contenidoArchivo = sb.ToString();

            return contenidoArchivo;
        }
        private bool EjecutarSQL(string comando)
        {

            bool operacionExitosa = false;
            SqlCommand cmd = new SqlCommand();

            //conexion  cadena desencriptado.
            //cn = new SqlConnection(Rijndael.Desencriptar(this._cadenaConexion));
            cn = new SqlConnection(this._cadenaConexion);
            cn.Open();

            Server servidor = new Server(new ServerConnection(cn));

            servidor.ConnectionContext.BeginTransaction();

            try
            {

                //if (servidor.ConnectionContext.ExecuteNonQuery(comando) > 0) // Verificar afecto filas en la base de datos
                //{
                //    //Exitoso
                //    servidor.ConnectionContext.CommitTransaction();
                //    operacionExitosa = true;
                //}
                servidor.ConnectionContext.ExecuteNonQuery(comando);
                servidor.ConnectionContext.CommitTransaction();
                operacionExitosa = true;

            }
            catch (SqlException exSQL)
            {
                servidor.ConnectionContext.RollBackTransaction();
                MessageBox.Show("Error al conectar o ejecutar commando SQL, detalle:" + exSQL.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                servidor.ConnectionContext.RollBackTransaction();
                MessageBox.Show("Error en metodo Ejecutar SQL, detalle:" + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                cn.Close();
                cn.Dispose();

            }
            return operacionExitosa;
        }
        #endregion

        #region "Util"
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeAlerta(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void MensajeInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void pgbProgreso_Click(object sender, EventArgs e)
        {

        }

    }
}
