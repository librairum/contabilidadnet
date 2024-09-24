Public Class Mod_BaseDatos
    Public Shared Sub LlenarComboPeriodos(ByVal cbo As Object, ByVal empresa As String, ByVal anio As String)
        Try
            cbo.DisplayMember = "ccb03des"
            cbo.ValueMember = "ccb03cod"
            cbo.DataSource = objSql.TraerDataTable("Spu_Con_Help_ccb03per", empresa, anio).DefaultView
            'Poner el valor de combo en el mes 
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub LlenarComboNivelPlaCtas(ByVal cbo As Object, ByVal empresa As String, ByVal anio As String)
        Try
            cbo.ValueMember = "cc26codigo"
            cbo.DisplayMember = "cc26descripcion"
            cbo.DataSource = objSql.TraerDataTable("Spu_Con_Help_NivelPlaCtas", empresa, anio).DefaultView
            'Poner el valor de combo en el mes 
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub LlenarComboCodLibro(ByVal cbo As Object, ByVal glo01codigotabla As String, ByVal cCampo As String, ByVal cFiltro As String)
        Try
            cbo.ValueMember = "glo01codigo"
            cbo.DisplayMember = "glo01descripcion"
            cbo.DataSource = objSql.TraerDataTable("Spu_Glo_Trae_glo01tablas_Det", glo01codigotabla, cCampo, cFiltro).DefaultView
            'Poner el valor de combo en el mes 
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    
    Public Shared Function DameDescripcion(ByVal cCodigoBus As String, ByVal cFlag As String) As String
        ' Obtengo la Descripcion
        Try
            DameDescripcion = CType(objSql.TraerValor("sp_Con_Dame_Descripcion", gbcodempresa, cCodigoBus, cFlag, "CT"), String)
        Catch ex As Exception
            DameDescripcion = ""
        End Try
    End Function
    Public Shared Function DameTCCuenta(ByVal fecha As String, ByVal cuenta As String) As String
        DameTCCuenta = "1.000"
        Try
            'Validar que es fecha
            If IsDate(fecha) = False Then
                DameTCCuenta = "1.000"
                MessageBox.Show("::ERROR : Fecha no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            End If
            ' Obtengo el Tipo de Cambio de la Cuenta
            DameTCCuenta = CType(objSql.TraerValor("sp_Con_Dame_TiCambio_Cuenta", gbcodempresa, gbano, cuenta, fecha, 0), String)
        Catch ex As Exception
            DameTCCuenta = "1.000"
        End Try
    End Function
    Public Shared Function DameTCFecha(ByVal fecha As String, ByVal TipoMercado As String, ByVal TipoCambio As String) As String
        'TipoMercado =  B:ancario, P :aralelo, S :afp, C :uota()
        'TipoCambio  =  C:ompra, V:enta

        DameTCFecha = "1.000"
        Try
            'Validar que es fecha
            If IsDate(fecha) = False Then
                DameTCFecha = "1.000"
                MessageBox.Show("::ERROR : Fecha no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            End If
            ' Obtengo el Tipo de Cambio de la Cuenta
            DameTCFecha = CType(objSql.TraerValor("sp_Glo_Trae_TiCambio_Fecha", fecha, TipoMercado, TipoCambio, 0), String)
        Catch ex As Exception
            DameTCFecha = "1.000"
        End Try
    End Function
    Public Shared Sub InsertaRangoImpresion(ByVal flag As String, ByVal valor As String)
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Con_Ins_Rango_Impresion", gbcodempresa, gbNameUser, flag, valor, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub EliminaRangoImpresion(ByVal flag As String)
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Con_Del_Rango_Impresion", gbcodempresa, gbNameUser, flag, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub actualisaperiododeusuario(ByVal anio As String, ByVal mes As String)
        Try
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Sp_Glo_Upd_PeriodoTrabajo", gbc_sistema, gbNameUser, gbcodempresa & anio & mes, gbmoneda, gbSaldos, gbTipoImpresora, gbAjuste)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Function Estadodeperiodo() As String
        Estadodeperiodo = ""
        Try
            ' Obtengo el Tipo de Cambio de la Cuenta
            Estadodeperiodo = CType(objSql.TraerValor("sp_Con_Dame_Estado_Periodo", gbcodempresa, gbano, gbmes, 0, 0), String)
        Catch ex As Exception
            Estadodeperiodo = ""
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Shared Function TraeGlo01tablas(ByVal tabla As String) As DataView
        TraeGlo01tablas = Nothing
        Try
            TraeGlo01tablas = objSql.TraerDataTable("Sp_Glo_Trae_glo01tablas", tabla, "GLO", "*", "*").DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Shared Function TraeCtaCte(ByVal emprea As String, ByVal tipoanalisis As String) As DataView
        TraeCtaCte = Nothing
        Try
            TraeCtaCte = objSql.TraerDataTable("sp_Con_Trae_Cuentas_Corrientes_New", emprea, tipoanalisis, "*", "*", "*").DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Shared Function TraeGlo01tablas2(ByVal tabla As String) As DataView
        TraeGlo01tablas2 = Nothing
        Try
            TraeGlo01tablas2 = objSql.TraerDataTable("Spu_Glo_Help_Glo02TablasLibros_Det", tabla, "*", "*").DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Shared Function EsProveedoraRetener(ByVal tipoctacte As String, ByVal rucctatcte As String) As Boolean
        Dim tipostr As String
        Try
            tipostr = Mod_BaseDatos.DameDescripcion(gbcodempresa + tipoctacte + rucctatcte, "AGERETE")
            'Si no es numeroco es falso
            If Not IsNumeric(tipostr) Then
                EsProveedoraRetener = False
            Else
                'Si su valor es distincto de cero quiere decir quie es agente o buen aportador , etc y no hay que retenerle
                If CInt(tipostr) <> 0 Then
                    EsProveedoraRetener = False
                Else
                    EsProveedoraRetener = True
                End If
            End If

            Exit Function
        Catch ex As Exception
            EsProveedoraRetener = False
        End Try
    End Function
End Class
