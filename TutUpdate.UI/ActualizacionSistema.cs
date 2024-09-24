using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Data.SqlClient;



using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace TutUpdate.UI
{
    public class ActualizacionSistema
    {
        
        private SqlConnection cn;
        private string _carpetaEmpresa = "", _cadenaConexion ="", _nombreEjecutable = "", _carpetaModulo = "", 
                     _archivoConfig = "", _versionPrograma = "", _carpetaParche = "", _nombreZip = "", _nombreScript = "";
        public ActualizacionSistema(string cadenaConexion, string carpetaEmpresa, string carpetaModulo, 
                                    string nombreEjecutable, string archivoConfig, string versionPrograma,
            string carpetaParche, string nombreZip, string nombreScript)
        {
            this._cadenaConexion = cadenaConexion;
            this._carpetaEmpresa = carpetaEmpresa;
            this._carpetaModulo = carpetaModulo;
            this._nombreEjecutable = nombreEjecutable;
            this._archivoConfig = archivoConfig;
            this._versionPrograma = versionPrograma;
            this._carpetaParche = carpetaParche;
            this._nombreZip = nombreZip;
            this._nombreScript = nombreScript;
        }
        public ActualizacionSistema()
        { 
            
        }
        

        /// <summary>
        /// Metodo para traer una ruta armado de nuestro AppData segun el modulo instalado.
        /// </summary>
        /// <returns>Retorno la siguiente ruta : C:\Users\Sistemas\AppData\Roaming\Minera Deisi\Asistencia\PatchFiles</returns>     
        //internal string ObtenerRutaParche()
        //{
        //    string valor = "", rutaAppData = "";
        //    try
        //    {                                
        //        rutaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //        //Ruta de parche AppData/NombreEmpresa/Modulo/(Archivos de actualziacion : debug.zip, actualizacion.config y 
        //        //credenciales.txt
        //        valor = Path.Combine(rutaAppData, this._carpetaEmpresa, this._carpetaModulo, this._carpetaParche);                                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error en obtener ruta de parche :" + ex.Message);
        //    }
        //    return valor;
        //}

        //internal void CerrarProcesoPrograma()
        //{
        //    try
        //    {
        //        string nombreProceso = "";

        //        nombreProceso = this._nombreEjecutable.Substring(0, this._nombreEjecutable.Length - 4);
                
        //        //Buscar proceso y finalizarlo
        //        foreach(System.Diagnostics.Process proceso 
        //                in System.Diagnostics.Process.GetProcessesByName(nombreProceso))
        //        {
        //            proceso.Kill();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al ejecutar metodo cerrar proceso, detalle : " +
        //             ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        //    }
        //}
        //internal string CargarAplicacion()
        //{
        //    string rutaEjecutable = "";
        //    try
        //    {
        //        rutaEjecutable = Path.Combine(Application.StartupPath, this._nombreEjecutable);

        //        if (File.Exists(rutaEjecutable) == true)
        //        {
        //            System.Diagnostics.Process.Start(rutaEjecutable);
        //        }
        //        System.Windows.Forms.Application.Exit();
        //    }
        //    catch (IOException exIO)
        //    {
        //        MessageBox.Show("Error al buscar ruta de ejecutable, detalle : " +
        //            exIO.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar aplicacion, detalle : " + ex.Message, "Sistema",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return rutaEjecutable;
        //}
       
        #region "Actualizacion de base de datos"
        //private int EncontrarLineaEjecucion(string nombreArchivo, string nuevaVersionBaseDatos)
        //{
        //    string rutaArchivo = Path.Combine(ObtenerRutaParche(), nombreArchivo);
        //    int nroFilaArchivo = -1;
        //    string[] lineas = File.ReadLines(rutaArchivo).ToArray();
        //    for (int x = 0; x < lineas.Length; x++)
        //    {
        //        if (nuevaVersionBaseDatos.ToUpper() == lineas[x].ToUpper())
        //        {
        //            nroFilaArchivo = x;
        //            break;
        //        }
        //    }
        //    return nroFilaArchivo;
        //}
        //internal string LeerSQL(string nombreArchivo)
        //{
        //    string contenidoArchivo = "", prefijoBD = "--@V";
        //    //Buscar la linea de fin 
        //    string marcador = prefijoBD +  this._versionPrograma + " End";
        //    string rutaArchivo = Path.Combine(ObtenerRutaParche(), nombreArchivo);

        //    int posicionLinea = EncontrarLineaEjecucion(nombreArchivo, marcador);
        //    if (posicionLinea == -1)
        //    {
        //        return "";
        //    }

        //    int cantidadLineas = File.ReadLines(rutaArchivo).ToArray().Length - posicionLinea;

        //    string[] contenido = new string[cantidadLineas];
        //    StringBuilder sb = new StringBuilder();
        //    try
        //    {
        //        rutaArchivo = Path.Combine(ObtenerRutaParche(), nombreArchivo);
        //        contenido = File.ReadLines(rutaArchivo).Skip(posicionLinea).ToArray();
        //        for (int x = 0; x < contenido.Length; x++)
        //        {
        //            sb.AppendLine(contenido[x]);
        //        }
                
        //        //Agregar linea de actualizacion de base de datos
        //        //sb.AppendLine("Update BDAtributos "+
        //        //              " set VersionBD = " + this.ObtenerNuevaVersion() + ","+
        //        //                " VersionBDFecha = getdate(), VersionBDHora = getdate()" +
        //        //                " where VersionBD = " + this._versionPrograma);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al leer lineas de texto, detalle : " + ex.Message);
        //    }            
        //    contenidoArchivo = sb.ToString();

        //    return contenidoArchivo;
        //}
        //internal bool EjecutarSQL(string comando)
        //{

        //    bool operacionExitosa = false;
        //    SqlCommand cmd = new SqlCommand();
            
        //    //conexion  cadena desencriptado.
        //    //cn = new SqlConnection(Rijndael.Desencriptar(this._cadenaConexion));
        //    cn = new SqlConnection(this._cadenaConexion);
        //    cn.Open();

        //    Server servidor = new Server(new ServerConnection(cn));
            
        //    servidor.ConnectionContext.BeginTransaction();
            
        //    try
        //    {                
                
        //        //if (servidor.ConnectionContext.ExecuteNonQuery(comando) > 0) // Verificar afecto filas en la base de datos
        //        //{
        //        //    //Exitoso
        //        //    servidor.ConnectionContext.CommitTransaction();
        //        //    operacionExitosa = true;
        //        //}
        //        servidor.ConnectionContext.ExecuteNonQuery(comando);
        //        servidor.ConnectionContext.CommitTransaction();
        //        operacionExitosa = true;

        //    }
        //    catch (SqlException exSQL)
        //    {
        //        servidor.ConnectionContext.RollBackTransaction();
        //        MessageBox.Show("Error al conectar o ejecutar commando SQL, detalle:" + exSQL.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        servidor.ConnectionContext.RollBackTransaction();
        //        MessageBox.Show("Error en metodo Ejecutar SQL, detalle:" + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        cn.Close();
        //        cn.Dispose();

        //    }
        //    return operacionExitosa;
        //}
        #endregion

    }
}
