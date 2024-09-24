Namespace AccesoDatos
    Public MustInherit Class gDatos
        ' Clase Abstracta de metodos comunes
        ' para luego ser heredado a otras clases

#Region "Declaracion de variables"
        Protected mServidor As String
        Protected mBaseDatos As String
        Protected mConexion As System.Data.IDbConnection
        Protected mCadenaConexion As String
#End Region

#Region "Constructores"

#End Region

#Region "Propiedades"
        'Nombre de Servidor de la Base de Datos
        Public Property Servidor() As String
            Get
                Return mServidor
            End Get
            Set(ByVal Value As String)
                mServidor = Value
            End Set
        End Property
        'Nombre de la Base de Datos
        Public Property BaseDatos() As String
            Get
                Return mBaseDatos
            End Get
            Set(ByVal Value As String)
                mBaseDatos = Value
            End Set
        End Property
        'Definicion de la Cadena de Conexion
        Public MustOverride Property CadenaConexon() As String

#End Region

#Region "Privadas"
        ' Devuelve un Objeto Conexion
        Public ReadOnly Property Conexion() As Data.IDbConnection
            Get
                If mConexion Is Nothing Then  ' Si no existe
                    ' Llama al método de la clase que lo hereda
                    mConexion = CrearConexion(Me.CadenaConexon)
                End If

                With mConexion
                    ' Controla que la conexion no este abierta
                    If .State <> ConnectionState.Open Then .Open()
                End With
                Return mConexion
            End Get
        End Property
#End Region

#Region "Lecturas"
        Public Overloads Function TraerDataSet(ByVal strStoreProc As String) As Data.DataSet
            ' Se crea un Dataset luego será retornado
            Dim mDataSet As New System.Data.DataSet
            CrearDataAdapter(strStoreProc).Fill(mDataSet)
            Return mDataSet
        End Function

        Public Overloads Function TraerDataSet(ByVal strStoreProc As String, ByVal ParamArray Args As Object()) As Data.DataSet
            ' Se crea un Dataset luego será retornado
            Dim mDataSet As New System.Data.DataSet
            CrearDataAdapter(strStoreProc, Args).Fill(mDataSet)
            Return mDataSet
        End Function

        Public Overloads Function TraerDataTable(ByVal strStoreProc As String) As Data.DataTable
            ' Devuelve DataTable
            Return TraerDataSet(strStoreProc).Tables(0).Copy
        End Function

        Public Overloads Function TraerDataTable(ByVal strStoreProc As String, ByVal ParamArray Args As Object()) As Data.DataTable
            ' Devuelve DataTable
            Return TraerDataSet(strStoreProc, Args).Tables(0).Copy
        End Function

        Public Overloads Function TraerValor(ByVal strStoreProc As String) As Object
            With Comando(strStoreProc)
                .ExecuteNonQuery()
                Dim oPar As System.Data.IDbDataParameter
                For Each oPar In .Parameters
                    If oPar.Direction = ParameterDirection.InputOutput _
                        Or oPar.Direction = ParameterDirection.Output Then
                        Return oPar.Value
                    End If
                Next
            End With
        End Function

        Public Overloads Function TraerValor(ByVal strStoreProc As String, ByVal ParamArray Args As Object()) As Object
            Dim mCom As System.Data.IDbCommand = Comando(strStoreProc)
            ' Invoco al metodo cargar paramatros
            CargarParametros(mCom, Args)
            With mCom
                .ExecuteNonQuery()
                Dim oPar As System.Data.IDbDataParameter
                For Each oPar In .Parameters
                    If oPar.Direction = ParameterDirection.InputOutput _
                        Or oPar.Direction = ParameterDirection.Output Then
                        Return oPar.Value
                    End If
                Next
            End With
        End Function
#End Region

#Region "Acciones"
        Protected MustOverride Function CrearConexion(ByVal strCadena As String) As Data.IDbConnection
        Protected MustOverride Function Comando(ByVal strStoreProc As String) As Data.IDbCommand
        Protected MustOverride Function CrearDataAdapter(ByVal strStoreProc As String, ByVal ParamArray Args As Object()) As Data.IDbDataAdapter
        Protected MustOverride Function CargarParametros(ByVal objComando As Data.IDbCommand, ByVal Args As Object())

        Public Overloads Sub cerrarconexion()
            If Conexion.State = ConnectionState.Open Then
                mConexion.Close()
            End If
        End Sub
        Public Overloads Function Ejecutar(ByVal strStoreProc As String) As Integer
            Return Comando(strStoreProc).ExecuteNonQuery
        End Function

        Public Overloads Function Ejecutar(ByVal strStoreProc As String, ByVal ParamArray Args As Object()) As Integer
            Dim mCom As System.Data.SqlClient.SqlCommand = Comando(strStoreProc)
            Dim intResp As Integer
            CargarParametros(mCom, Args)
            intResp = mCom.ExecuteNonQuery
            Dim i As Integer
            For i = 0 To mCom.Parameters.Count - 1
                With mCom.Parameters(i)
                    If .Direction = ParameterDirection.InputOutput Or _
                        .Direction = ParameterDirection.Output Then
                        Args.SetValue(.Value, i - 1)
                    End If
                End With
            Next
            Return intResp
        End Function
        Public Overloads Function Ejecutar2(ByVal strStoreProc As String, ByVal ParamArray Args As Object()) As Array
            Dim mCom As System.Data.SqlClient.SqlCommand = Comando(strStoreProc)
            CargarParametros(mCom, Args)
            mCom.ExecuteNonQuery()
            'Dim oPar As System.Data.SqlClient.SqlDataAdapter
            Dim i As Integer
            Dim contadorparsal As Integer  'contador de parametros de salida
            'creo array de 2 columnas por 10 filas
            Dim myObjArray As Array = Array.CreateInstance(GetType(Object), 2, 10)
            contadorparsal = 0
            '=======
            For i = 0 To mCom.Parameters.Count - 1
                With mCom.Parameters(i)
                    If .Direction = ParameterDirection.InputOutput Or _
                        .Direction = ParameterDirection.Output Then
                        Args.SetValue(.Value, i - 1)
                    End If

                    If .Direction = ParameterDirection.ReturnValue Then
                        myObjArray.SetValue(mCom.Parameters("@RETURN_VALUE").ParameterName, 0, contadorparsal)
                        myObjArray.SetValue(mCom.Parameters("@RETURN_VALUE").Value, 1, contadorparsal)
                        contadorparsal = contadorparsal + 1
                    End If

                    'Si es un parametro de salida o el parametro rel RETURN
                    If (.Direction = ParameterDirection.InputOutput Or _
                        .Direction = ParameterDirection.Output) Then
                        myObjArray.SetValue(.ParameterName, 0, contadorparsal) 'Agrego nombre del parametro
                        myObjArray.SetValue(.Value, 1, contadorparsal)           'Agrego valor del parametro
                        contadorparsal = contadorparsal + 1 ' incrementa los parametros salida en 1
                    End If
                End With
            Next
            '================
            Return myObjArray
        End Function
#End Region
#Region "Transacciones"
        Protected mTransaccion As System.Data.IDbTransaction
        Protected EnTransaccion As Boolean

        Public Sub IniciarTransaction()
            mTransaccion = Me.Conexion.BeginTransaction
            EnTransaccion = True
        End Sub

        Public Sub TerminarTransaccion()
            Try
                mTransaccion.Commit()
            Catch ex As System.Exception
                Throw ex
            Finally
                EnTransaccion = False
                mTransaccion = Nothing
            End Try
        End Sub
        Public Sub AbortarTransaction()
            Try
                mTransaccion.Rollback()
            Catch ex As System.Exception
                Throw ex
            Finally
                mTransaccion = Nothing
                EnTransaccion = False
            End Try
        End Sub
#End Region

    End Class

    Public Class DatosSQLServer
        ' Clase derivada especificamente para SQL Server
        Inherits ServDatos.AccesoDatos.gDatos
        Shared mColComando As New System.Collections.Hashtable

        Public Overrides Property CadenaConexon() As String
            Get
                If Len(MyBase.mCadenaConexion) = 0 Then
                    If Len(Me.mServidor) <> 0 And Len(Me.mBaseDatos) Then
                        Dim sCadena As New System.Text.StringBuilder( _
                        " Data Source = <Servidor>;" & _
                        " Initial Catalog = <BaseDatos>;" & _
                        " Password ='';" & _
                        " User Id = sa; packet size = 4096")
                        sCadena.Replace("<Servidor>", mServidor)
                        sCadena.Replace("<BaseDatos>", mBaseDatos)
                        mCadenaConexion = sCadena.ToString
                    Else
                        Throw New System.Exception("No se puede establecer cadena de conexión")
                    End If
                End If
                Return mCadenaConexion
            End Get
            Set(ByVal Value As String)
                mCadenaConexion = Value
            End Set
        End Property

        Protected Overrides Function CargarParametros(ByVal objComando As System.Data.IDbCommand, ByVal Args() As Object) As Object
            Dim i As Integer
            With objComando
                For i = 0 To Args.GetUpperBound(0)
                    .Parameters(i + 1).value = Args(i)
                Next
            End With
        End Function

        Protected Overrides Function Comando(ByVal strStoreProc As String) As System.Data.IDbCommand
            Dim mComando As System.Data.SqlClient.SqlCommand


            If mColComando.Contains(strStoreProc) Then
                mComando = CType(mColComando.Item(strStoreProc), System.Data.SqlClient.SqlCommand)
            Else
                Using oConexion2 As New System.Data.SqlClient.SqlConnection(CadenaConexon)
                    oConexion2.Open()
                    mComando = New System.Data.SqlClient.SqlCommand(strStoreProc, oConexion2)
                    mComando.CommandType = CommandType.StoredProcedure
                    System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(mComando)
                    oConexion2.Close()
                    oConexion2.Dispose()
                    mColComando.Add(strStoreProc, mComando)
                End Using
            End If

            With mComando
                .CommandTimeout = 600 '5 Minutos como maxim
                .Connection = Me.Conexion
                .Transaction = MyBase.mTransaccion
            End With
            Return mComando

        End Function
        Protected Overrides Function CrearConexion(ByVal strCadena As String) As System.Data.IDbConnection
            Return New System.Data.SqlClient.SqlConnection(strCadena)
        End Function
        Protected Overrides Function CrearDataAdapter(ByVal strStoreProc As String, ByVal ParamArray Args() As Object) As System.Data.IDbDataAdapter
            Dim mCom As System.Data.SqlClient.SqlCommand = Comando(strStoreProc)
            ' Si se ha recibido argumentos,
            ' se procede a asignar los valores correspondientes
            If Not Args Is Nothing Then
                CargarParametros(mCom, Args)
            End If
            Return New System.Data.SqlClient.SqlDataAdapter(mCom)
        End Function
        Sub New()

        End Sub
        Sub New(ByVal CadenaConexion As String)
            Me.New()
            Me.CadenaConexon = CadenaConexion
        End Sub
        Sub New(ByVal pStrServidor As String, ByVal pStrBaseDatos As String)
            Me.New()
            Me.BaseDatos = pStrBaseDatos
            Me.Servidor = pStrServidor
        End Sub
    End Class
End Namespace
