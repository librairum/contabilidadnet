Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Funciones
    Public Enum enmTipoFormatoFecha
        enmAnioMesDia = 0
        enmFechaLarga = 1
        enmFechaCorta = 2
    End Enum

    Public Shared Function EsValidaFechaPoranio(ByVal fecha As String, ByVal Ano As String) As Boolean
        Dim anio As String
        EsValidaFechaPoranio = False
        Try
            '::Funcion : Valida que sea una fecha y ademas que el año de la fecha debe ser igual año de parametro
            'Devuelve vacio si todo esta bien, en caso contrario devuelve el error

            If Not IsDate(fecha) Then
                EsValidaFechaPoranio = False
                MessageBox.Show("VALIDACION :: Fecha No Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
            '
            anio = CStr(DatePart(DateInterval.Year, CDate(fecha)))


            If anio <> Ano Then
                If MessageBox.Show("La fecha debe pertencer al año " + vbCrLf + "¿Esta seguro de usar la fecha", "Salir del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EsValidaFechaPoranio = True
                Else
                    EsValidaFechaPoranio = False
                End If
            Else
                EsValidaFechaPoranio = True
            End If

        Catch es As Exception
            EsValidaFechaPoranio = False
        End Try
    End Function
    Public Shared Function EsValidaFechaPorPer(ByVal fecha As String, ByVal periodo As String) As Boolean
        Dim periododefecha As String
        Dim anio As String
        Dim mes As String

        Try
            ':: Funcion : Valida que sea una fecha y ademas que el año + mes de la fecha debe ser igual al periodo
            'Devuelve vacio si todo esta bien, en caso contrario devuelve el error
            EsValidaFechaPorPer = False

            'Validar que sea la fecha
            If Not IsDate(fecha) Then
                EsValidaFechaPorPer = False
                MessageBox.Show("VALIDACION :: Fecha No Valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            anio = CStr(DatePart(DateInterval.Year, CDate(fecha)))
            mes = Mesa2digitos(fecha)


            If Funciones.derecha(periodo, 2) = "00" Then
                periodo = Funciones.izquierda(periodo, 4) + "01"
            ElseIf CInt(Funciones.derecha(periodo, 2)) >= 13 Then
                periodo = Funciones.izquierda(periodo, 4) + "12"
            End If

            periododefecha = anio + mes

            If periododefecha <> periodo Then
                EsValidaFechaPorPer = False
                MessageBox.Show("VALIDACION :: La Fecha debe pertenece al Periodo", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                EsValidaFechaPorPer = True
            End If
            '
        Catch es As Exception
            EsValidaFechaPorPer = False
        End Try
    End Function
    Public Shared Function Mesa2digitos(ByVal fecha As DateTime) As String
        Dim mes As Integer
        Try
            'Valido que sea fecha    
            If Not IsDate(fecha) Then
                Mesa2digitos = ""
                Exit Function
            End If
            '
            mes = DatePart(DateInterval.Month, CDate(fecha))
            '
            If mes < 10 Then
                Mesa2digitos = "0" + CStr(mes)
            Else
                Mesa2digitos = CStr(mes)
            End If

            Return Mesa2digitos
        Catch ex As Exception
            Mesa2digitos = ""
        End Try
    End Function
    Public Shared Function derecha(ByVal texto As String, ByVal longitud As Integer) As String
        Try
            'Elimino espacios enblanco
            texto = texto.ToString.Trim
            derecha = texto.ToString.Substring(texto.ToString.Length - longitud, longitud)
            Return derecha
        Catch ex As Exception
            derecha = ""
        End Try
    End Function
    Public Shared Function izquierda(ByVal texto As String, ByVal longitud As Integer) As String
        Try
            'Elimino espacios enblanco
            texto = texto.ToString.Trim
            izquierda = texto.ToString.Substring(0, longitud)
            Return izquierda
        Catch ex As Exception
            izquierda = ""
        End Try
    End Function
    Public Shared Function FormatoFecha(ByVal penmTipoFormato As enmTipoFormatoFecha) As String
        If penmTipoFormato = enmTipoFormatoFecha.enmAnioMesDia Then
            Return "{0:yyyyMMdd}"

        ElseIf penmTipoFormato = enmTipoFormatoFecha.enmFechaLarga Then
            Return "{0:dd/MM/yyyy}"

        Else
            Return "{0:dd/MM/yy}"
        End If
    End Function
    Public Shared Function FormatearFecha(ByVal pdteFecha As Date, ByVal penmTipoFormato As enmTipoFormatoFecha) As String
        Return String.Format(FormatoFecha(penmTipoFormato), pdteFecha)
    End Function
    Public Shared Function DescripcionMoneda(ByVal moneda As String) As String
        DescripcionMoneda = ""
        Try
            If moneda = "S" Then
                DescripcionMoneda = "Nuevos Soles"
            ElseIf moneda = "D" Then
                DescripcionMoneda = "Dolares"
            End If
        Catch ex As Exception
            DescripcionMoneda = "Moneda no valida"
        End Try
    End Function

    Public Shared Function FormIsOpen(ByVal FormABuscar As String) As Boolean
        'Public Shared Function FormIsOpen(ByVal FormABuscar As String, Optional ByVal NameAlias As Integer = 0) As Boolean
        Try

            Dim lEncontrado As Boolean = False
            Dim form As System.Windows.Forms.Form

            For Each form In Application.OpenForms
                'If (form.Name = FormABuscar And NameAlias = form.Tag) Then
                If (form.Name = FormABuscar) Then
                    form.WindowState = FormWindowState.Normal
                    form.Activate()
                    lEncontrado = True
                    Exit For
                End If
            Next

            Return lEncontrado

        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function MensajesdelSQl(ByVal a As Array) As Boolean
        Dim i As Integer
        Try
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                'Otros Mnsajes
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
                'Si todo esta bien
                MensajesdelSQl = True
            Else 'Fallo la ejecucion Sql 
                'Mensajes de Fallo
                For i = 1 To 9
                    If CType(a.GetValue(0, i), String) Is Nothing Then
                        Exit For
                    Else
                        MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next
                MensajesdelSQl = False
            End If
        Catch ex As Exception
            MensajesdelSQl = False
        End Try
    End Function
    Public Shared Function Esnumeromayoracero(ByVal numero As String) As Boolean
        Try
            Esnumeromayoracero = False
            If IsNumeric(numero) = True Then
                If numero <= 0 Then
                    Esnumeromayoracero = False
                    MessageBox.Show("VALIDACION :: Numero menor que cero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Esnumeromayoracero = True
                End If
            Else
                Esnumeromayoracero = False
                MessageBox.Show("VALIDACION :: Numero no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Esnumeromayoracero = False
        End Try
    End Function
    Public Shared Function NumeroDiasMes(ByVal MesProceso As String, ByVal AnoProceso As String) As String
        Dim nMesProceso As Integer
        Dim nAnoProceso As Integer

        NumeroDiasMes = "00"

        Try
            nMesProceso = CType(MesProceso, Integer)
            nAnoProceso = CType(AnoProceso, Integer)

            If nMesProceso = 1 Or nMesProceso = 3 Or nMesProceso = 5 Or nMesProceso = 7 Or nMesProceso = 8 Or _
               nMesProceso = 10 Or nMesProceso = 12 Or nMesProceso = 13 Or nMesProceso = 14 Or nMesProceso = 15 Or nMesProceso = 16 Or nMesProceso = 17 Or nMesProceso = 18 Then
                NumeroDiasMes = "31"
            ElseIf nMesProceso = 4 Or nMesProceso = 6 Or nMesProceso = 9 Or nMesProceso = 11 Then
                NumeroDiasMes = "30"
            ElseIf nMesProceso = 2 Then
                If nAnoProceso / 4 = Int(nAnoProceso / 4) Then
                    NumeroDiasMes = "29"
                Else
                    NumeroDiasMes = "28"
                End If
            ElseIf nMesProceso = 0 Then
                NumeroDiasMes = "01"
            End If
        Catch ex As Exception
            NumeroDiasMes = "00"
        End Try

    End Function
    Public Shared Function Formatofechacontable(ByVal MesProceso As String, ByVal anio As String) As String
        Formatofechacontable = ""
        Try
            Formatofechacontable = NumeroDiasMes(MesProceso, anio) + " de " + NombredeMes(MesProceso) + " de " + anio
        Catch ex As Exception
        End Try
    End Function
    Public Shared Function NombredeMes(ByVal MesProceso As String) As String
        NombredeMes = ""
        Try
            NombredeMes = MesProceso

            Select Case MesProceso
                Case "01"
                    NombredeMes = "Enero"
                Case "02"
                    NombredeMes = "Febrero"
                Case "03"
                    NombredeMes = "Marzo"
                Case "04"
                    NombredeMes = "Abril"
                Case "05"
                    NombredeMes = "Mayo"
                Case "06"
                    NombredeMes = "Junio"
                Case "07"
                    NombredeMes = "Julio"
                Case "08"
                    NombredeMes = "Agosto"
                Case "09"
                    NombredeMes = "Setiembre"
                Case "10"
                    NombredeMes = "Octubre"
                Case "11"
                    NombredeMes = "Noviembre"
                Case "12"
                    NombredeMes = "Diciembre"
                Case Else
                    If CInt(MesProceso) < 1 Then ' Si es menor que 01 entonceb es apertura y todo eso sale con mes de enero
                        NombredeMes = "Enero"
                    ElseIf CInt(MesProceso) > 12 Then
                        NombredeMes = "Diciembre" 'Si es mayor que 12, entonces son periodo 13,14,15 y todo eso es diciembre
                    Else
                        NombredeMes = MesProceso
                    End If
            End Select
        Catch ex As Exception
            MesProceso = MesProceso
        End Try
    End Function
    Public Shared Function Encripta(ByVal cClave As String) As String
        Dim cRetorno As String
        Dim nLetra As Integer
        Dim i As Integer

        Try
            cClave = cClave.Trim
            cRetorno = ""
            For i = 1 To cClave.Length - 1
                nLetra = Asc(Mid(cClave, i, 1)) + Asc(Mid(cClave, i + 1, 1))
                cRetorno = cRetorno & Chr(nLetra)
            Next i%
            Encripta = cRetorno & derecha(cClave, 1)

        Catch ex As Exception
            Encripta = cClave
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Shared Function Desencripta(ByVal cClave As String) As String
        Dim cRetorno As String
        Dim nLetra As Integer
        Dim i As Integer
        Try
            cClave = cClave.Trim
            cRetorno$ = derecha(cClave, 1)
            For i = cClave.Length - 1 To 1 Step -1
                nLetra = Asc(Mid(cClave, i, 1)) - Asc(Mid(cRetorno, 1, 1))
                cRetorno$ = Chr(nLetra) & cRetorno
            Next i%
            Desencripta = cRetorno
        Catch ex As Exception
            Desencripta = cClave
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Shared Function ImportaExcel(ByVal RutaExcel As String, ByVal Grilla As DataGridView) As DataSet
        Dim ConnectionStringExcel As String
        Try
            ' Construimos la cadena de conexión  
            ConnectionStringExcel = "Data Source=C:\Mis documentos\Libro1.xls;" & "Provider=Microsoft.Jet.OLEDB.4.0;" & "Extended Properties='Excel 8.0;'"
            Dim objconn As New OleDbConnection(ConnectionStringExcel)
            objconn.Open()

            ' Construimos la consulta SQL de selección  
            Dim sql As String = "SELECT * from [Hoja1$]"
            Dim objcmdselect As New OleDbCommand(sql, objconn)

            ' Creamos el adaptador de datos  
            Dim objAdapter1 As New OleDbDataAdapter
            objAdapter1.SelectCommand = objcmdselect

            ' Creamos el objeto DataTable  
            Dim objdtaset1 As New DataSet
            objAdapter1.Fill(objdtaset1, "XLData")

            ' Asignamos el origen de datos al control DataGridView  
            ImportaExcel = objdtaset1.Clone()
            objconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Shared Function NombreLibroelectronico(ByVal identificadorlibro As String, ByVal Rucempresa As String, ByVal anio As String, ByVal mes As String, ByVal dia As String, ByVal CodigoOportunidadEEFF As String, ByVal Flagconosininformacion As String, ByVal moneda As String) As String
        Dim Nombre01_02 As String
        Dim Nombre03_13 As String
        Dim Nombre14_17 As String
        Dim Nombre18_19 As String
        Dim Nombre20_21 As String
        Dim Nombre22_27 As String
        Dim Nombre28_29 As String
        Dim Nombre30_30 As String
        Dim Nombre31_31 As String
        Dim Nombre32_32 As String
        Dim Nombre33_33 As String

        NombreLibroelectronico = ""

        Nombre01_02 = "LE"
        Nombre03_13 = Rucempresa
        Nombre14_17 = anio
        '
        '08  Registro Compras
        '14  Registro Ventas

        If ((identificadorlibro.Substring(0, 2) = "08") Or (identificadorlibro.Substring(0, 2) = "14") Or (identificadorlibro.Substring(0, 2) = "05") Or (identificadorlibro.Substring(0, 2) = "06") Or (identificadorlibro.Substring(0, 2) = "03") Or (identificadorlibro.Substring(0, 2) = "04")) Then
            Nombre18_19 = mes
        Else
            Nombre18_19 = "00"
        End If

        If ((identificadorlibro.Substring(0, 2) = "08") Or (identificadorlibro.Substring(0, 2) = "14") Or (identificadorlibro.Substring(0, 2) = "05") Or (identificadorlibro.Substring(0, 2) = "06") Or (identificadorlibro.Substring(0, 2) = "04")) Then
            Nombre20_21 = "00"
        Else
            Nombre20_21 = dia
        End If

        Nombre22_27 = identificadorlibro

        If identificadorlibro.Substring(0, 2) = "03" Then
            Nombre28_29 = CodigoOportunidadEEFF
        Else
            Nombre28_29 = "00"
        End If

        Nombre30_30 = "1"
        Nombre31_31 = Flagconosininformacion

        If moneda = "S" Then
            Nombre32_32 = "1"
        ElseIf moneda = "1" Then
            Nombre32_32 = "2"
        End If

        Nombre33_33 = "1"

        Try

            NombreLibroelectronico = Nombre01_02 + Nombre03_13 + Nombre14_17 + Nombre18_19 + Nombre20_21 + Nombre22_27
            NombreLibroelectronico = NombreLibroelectronico + Nombre28_29 + Nombre30_30 + Nombre31_31 + Nombre32_32 + Nombre33_33

        Catch ex As Exception
            NombreLibroelectronico = ""
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Shared Function ConvertiraXMLdinamico(ByVal lista As IEnumerable(Of String)) As String
        Dim sb As New StringBuilder()
        sb.Append("<DataSet>")

        ' recorrer filas
        For Each fila As String In lista
            ' recorrer columnas

            Dim celdas As String() = fila.Split("|"c)
            sb.Append("<tbl>")

            ' recorrer columnas
            Dim initagcampo As String = "", endtagcampo As String = ""
            For i As Integer = 0 To celdas.Length - 1
                initagcampo = "<campo" & (i + 1).ToString() & ">"
                endtagcampo = "</campo" & (i + 1).ToString() & ">"
                sb.Append(initagcampo)

                celdas(i) = celdas(i).Replace("&", "&amp;")
                sb.Append(celdas(i))
                sb.Append(endtagcampo)
            Next

            sb.Append("</tbl>")
        Next

        sb.Append("</DataSet>")
        Return sb.ToString()
    End Function
    Public Shared Function ConcatenarArrayList(ByVal lista As ArrayList, ByVal separador As String) As String
        Dim sb As New StringBuilder()

        For Each elemento In lista
            ' Verificar el tipo de dato y convertirlo a cadena si es necesario
            Dim valor As String = If(TypeOf elemento Is String, elemento.ToString(), CStr(elemento))
            sb.Append(valor).Append(separador)
        Next

        ' Eliminar el último separador si es necesario
        If sb.Length > 0 Then
            sb.Length -= separador.Length
        End If

        Return sb.ToString()
    End Function
    'metodo 1809
    Public Shared Function ConvertiraXMLdinamico(ByVal lista As ArrayList) As String
        Dim sb As New StringBuilder()
        sb.Append("<DataSet>")

        ' Loop through rows (cast to IEnumerable for iteration)
        For Each fila As String In lista.Cast(Of String)()
            ' Loop through columns
            Dim celdas As String() = fila.Split("|")
            sb.Append("<tbl>")

            ' Loop through columns again
            Dim initagcampo As String = ""
            Dim endtagcampo As String = ""
            For i As Integer = 0 To celdas.Length - 1
                initagcampo = "<campo" & (i + 1).ToString() & ">"
                endtagcampo = "</campo" & (i + 1).ToString() & ">"
                sb.Append(initagcampo)

                celdas(i) = celdas(i).Replace("&", "&amp;")
                sb.Append(celdas(i))
                sb.Append(endtagcampo)
            Next

            sb.Append("</tbl>")
        Next

        sb.Append("</DataSet>")
        Return sb.ToString()
    End Function
    Public Shared Function ExtraerParteNumerica(ByVal texto As String) As String
        ' Define una expresión regular para encontrar los dígitos en el texto
        Dim regex As New RegularExpressions.Regex("\d+")
        ' Encuentra todas las coincidencias de dígitos en el texto
        Dim coincidencias As MatchCollection = regex.Matches(texto)

        ' Concatena todas las coincidencias encontradas para obtener la parte numérica
        Dim parteNumerica As String = ""
        For Each coincidencia As Match In coincidencias
            parteNumerica &= coincidencia.Value
        Next
        Return parteNumerica
    End Function
    Public Shared Function ExtraerLetras(ByVal texto As String) As String
        ' Define una expresión regular para encontrar las letras en el texto
        Dim regex As New Regex("[a-zA-Z]+")

        ' Encuentra todas las coincidencias de letras en el texto
        Dim coincidencias As MatchCollection = regex.Matches(texto)

        ' Concatena todas las coincidencias encontradas para obtener las letras
        Dim letras As String = ""
        For Each coincidencia As Match In coincidencias
            letras &= coincidencia.Value
        Next

        ' Retorna las letras encontradas
        Return letras
    End Function

    Public Shared Function AgregarCeros(ByVal longitudDeseada As String) As String
        Dim longitudActual As Integer = longitudDeseada.Length


        ' Retornar el número formateado
        Return New String("0"c, longitudActual)
    End Function

End Class