Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Windows

Module Globales
#Region "CONSTANTES"
    Public Const APP_CONST_MSG_SISTEMA As String = "SGCI Mesa de Dinero"
    Public Const APP_CONST_MSG_ELIMINA As String = "¿ Esté seguro de eliminar la información ?"
    Public Const APP_CONST_MSG_CONFIRMAR As String = "¿ Esté seguro de confirmación la Orden ?"
    Public Const APP_CONST_MSG_REVERSAR As String = "¿ Esté seguro de anular la confirmación de Orden ?"
    Public Const APP_CONST_INSERT As String = "I"
    Public Const APP_CONST_UPDATE As String = "U"
    Public Const APP_CONST_ANULAR As String = "A"
    Public Const APP_CONST_DELETE As String = "D"

    Public Const APP_CONST_TBL_ksMONEDA As String = "ksMONEDA"
    Public Const APP_CONST_TBL_ksTIPCUST As String = "ksTIPCUST"
    Public Const APP_CONST_TBL_ksFAMILIA As String = "ksFAMILIA"
    Public Const APP_CONST_TBL_ksFRECUENCIA As String = "ksFRECUENCIA"
    Public Const APP_CONST_TBL_ksMERCADO As String = "ksMERCADO"

    ' CONSTANTES PARA INSTRUMENTOS
    Public Const APP_ACCIONES As String = "ACCI"
    Public Const APP_BONO As String = "BONO"
    Public Const APP_CER_SUS_PREF As String = "CSPR"
    Public Const APP_CER_DEPOSITO As String = "CDPS"
    Public Const APP_CER_DEPPLAZO As String = "DPLZ"
    Public Const APP_FONDOSLOCAL As String = "FDLC"
    Public Const APP_FONDOEXTRAN As String = "FDLC"
    Public Const APP_INS_CORPLAZ As String = "ICPL"
    Public Const APP_LET_HIPOTEC As String = "LTHP"
    Public Const APP_OPE_REPORTE As String = "OPRT"
    Public Const APP_FOR_MONEDAS As String = "FRWD"

    ' CONSTANTES PARA ESTADO DE ORDEN
    Public Const APP_CONST_ESTADO_PENDIENTE As String = "P"
    Public Const APP_CONST_ESTADO_CONFIRMAD As String = "C"
    Public Const APP_CONST_ESTADO_ANULADO As String = "A"
    Public Const APP_CONST_ESTADO_TODOS As String = "T"
    'Constantes del modulo

    Public Const gbc_sistema = "CONTABILID"
    'Constantes a capturar
    Public Const gbc_MensajeValidar As String = "VALIDAR :: "
    Public Const gbc_MensajeError As String = "ERROR :: "
    Public Const gbc_MensajeOK As String = "OK :: "

    'Constantes de tooltiptext
    Public Const gbc_Ttp_ImpDir As String = "Imprimir"
    Public Const gbc_Ttp_ImpVp As String = "Vista Previa"
    Public Const gbc_Ttp_Salir As String = "Salir"
    Public Const gbc_Ttp_SelecTodasFilas As String = "Seleccioanar todas las filas"

    Public Const gbc_Ttp_Nuevo As String = "Nuevo"
    Public Const gbc_Ttp_Insertar As String = "Insertar"
    Public Const gbc_Ttp_Modificar As String = "Modificar"
    Public Const gbc_Ttp_Eliminar As String = "Eliminar"
    Public Const gbc_Ttp_Ver As String = "Ver"

    Public Const gbc_Ttp_Guardar As String = "Guardar"
    Public Const gbc_Ttp_Cancelar As String = "Cancelar"
    Public Const gbc_Ttp_Nuevoxcopia As String = "Crear Nueva Empresa Basada x Copia"

    'Mesanjes Standar
    Public Const gbm_repnodisenimpiny As String = "Reporte no disnonible para impresora inyeccion"
    Public Const gbm_repnodisenimpmat As String = "Reporte no disponible para impresora matricial"
#End Region

#Region "Variables para cadena de conexion"
    Public gbStrServidor As String              ' Nombre de Servidor
    Public gbStrBaseDatos As String             ' Nombre de Base de datos
    Public gbStrUserId As String                ' User Id
    Public gbStrPassword As String              ' Password
    Public gbStrConexion As String              ' Variable apra Cadena de conexion
    Public gbStrModuloCodigo As String

    Public objSql As ServDatos.AccesoDatos.DatosSQLServer
    Public gbRutaAplicacion As String
    '
    Public gbcodempresa As String = ""
    Public gbRucEmpresa As String = ""
    Public gbNomEmpresa As String = ""
    Public gbano As String = ""
    Public gbmes As String = ""
    Public gbperiodo As String = ""
    Public gbFecProvision As String = ""
    Public gbmoneda As String = ""
    Public gbNameUser As String = ""
    Public gbMontoRetencion As Double = 0
    Public gbTCUsar As String = ""
    Public gbigv As Double = 0
    Public gbSaldos As String = ""
    Public gbTipoImpresora As String = ""
    Public gbAjuste As String = ""
    Public gbDirEmpresa As String
    Public gbRepEmpresa As String
    Public gbCarEmpresa As String
    Public gbConEmpresa As String
    Public gbMatEmpresa As String
    'Public gbRutaReportes As String
    Public gbAccPerCerr As String = ""
    Public gbCuentaPerDifCam As String
    Public gbCuentaGanDifCam As String
    Public gbCenCosPerDifCam As String
    Public gbCenGesPerDifCam As String
    Public gbCenCosGanDifCam As String
    Public gbCenGesGanDifCam As String
    Public gbModifTC As String
    Public gbEmpresaPlanilla As String
    Public gbAgenteRetencion As String
    Public gbTasaRetencion As Double
    Public gbTiporeporte As String
    Public gbflagestadoperiodo As String
    '===
    Public gbllenadodecombo As Boolean = False ' Como a la hora de llenar el combo se tenia problemas son el eveno selectindexchanged, se utilizo esta variabvkle para bloquear dicho vento

    '===
    Public gbOdbcrep_nombre As String
    Public gbOdbcrep_Usuario As String
    Public gbOdbcrep_password As String
    '===
    Public gbNombreModulo As String
    Public gbversionUsuario As String
    '--===
    Public gbsaltaractualizaperiodo As String = ""
#End Region

    Public Sub InicializarAplicacion()
        Dim objConfig As NameValueCollection
        objConfig = System.Configuration.ConfigurationManager.AppSettings ' Abre archivo de configuracion
        gbRutaAplicacion = System.Environment.CurrentDirectory
        ' Son metodos de tipo shared
        ' ya no se instancia
        gbStrServidor = objConfig.Item("Servidor")
        gbStrBaseDatos = objConfig.Item("BaseDatos")
        gbStrUserId = objConfig.Item("UserId")
        gbStrPassword = objConfig.Item("Password")
        'gbRutaReportes = objConfig.Item("RutaReportes")
        '==
        gbOdbcrep_nombre = objConfig.Item("gbOdbcrep_nombre")
        gbOdbcrep_Usuario = objConfig.Item("gbOdbcrep_Usuario")
        gbOdbcrep_password = objConfig.Item("gbOdbcrep_password")

        '==
        gbNombreModulo = objConfig.Item("modulo")
        gbversionUsuario = objConfig.Item("versionUsuario")



        ' Obtengo cadena de conexion
        gbStrConexion = getCadenaConexion(gbStrServidor, gbStrBaseDatos, gbStrPassword, gbStrUserId)
        iniciarObjetoConexionBd()
    End Sub
    Public Function getCadenaConexion(ByVal pStrServidor As String, _
                                ByVal pStrBaseDatos As String, _
                                ByVal pStrPassword As String, _
                                ByVal pStrUserId As String) As String

        Dim sCadena As New System.Text.StringBuilder(" Data Source = <Servidor>;" & _
                                                     " Initial Catalog = <BaseDatos>;" & _
                                                     " Password =<Password>;" & _
                                                     " User Id = <UserId>; packet size = 4096")
        sCadena.Replace("<Servidor>", pStrServidor)
        sCadena.Replace("<BaseDatos>", pStrBaseDatos)
        sCadena.Replace("<Password>", pStrPassword)
        sCadena.Replace("<UserId>", pStrUserId)
        Return sCadena.ToString
    End Function
    Public Sub iniciarObjetoConexionBd()
        Try
            objSql = New ServDatos.AccesoDatos.DatosSQLServer(gbStrConexion)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function gbRutaReportes() As String
        'Dim sCadena As String
        'Return String.Format("{0}{1}", Application.StartupPath, "\Reportes\")
        Dim RutaReportes As String = System.IO.Directory.GetCurrentDirectory.ToString & "\Reportes\"
        Return RutaReportes
    End Function

End Module
