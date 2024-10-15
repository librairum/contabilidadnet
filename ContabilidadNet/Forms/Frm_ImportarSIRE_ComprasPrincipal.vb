Imports System.IO
Imports System.Globalization
Imports Microsoft.Office.Interop
Imports C1.Win.C1TrueDBGrid
Imports Ionic.Zip
Imports System.IO.Compression
Imports System.IO.Compression.FileSystem
Imports System.Text

Public Class Frm_ImportarSIRE_ComprasPrincipal
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Private Sub traeImportacion()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_Voucher_importar", gbcodempresa, gbNameUser).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        Try
            tblhelp.Visible = False
            Vista.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ValidarImpVoucher()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ValImpVoucher", gbcodempresa, gbano, gbmes, gbNameUser, "IV").DefaultView
            'tblvalidacion.SetDataBinding(Vista, Nothing, True)
            ''
            'Me.capturarfilaactual()
            ''
            'Me.tblvalidacion.Columns(0).FooterText = "# Registros"
            'Me.tblvalidacion.Columns(1).FooterText = tblvalidacion.RowCount.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImportarArchivo()
        'Spu_Con_Ins_ImportarSireCompras
        Try

            Dim FilePath As String

            Dim openFD As New OpenFileDialog()

            Dim strStreamW As Stream
            Dim strStreamWriter As StreamWriter
            Dim nombredearchivo As String = ""
            Dim rutadearchivo As String = ""
            Dim myStream As Stream

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Dim b As Array = Array.CreateInstance(GetType(Object), 2, 10)


            Dim sLine As String = ""
            Dim arrText As New ArrayList()


            With openFD
                .Title = "Seleccionar Archivos a importar"
                .Filter = "Todos los archivos (*.*)|*.*|(*.txt)|*.txt|(*.csv)|*.csv"
                .Multiselect = False
                .InitialDirectory = ""

            End With

            If openFD.ShowDialog() = DialogResult.OK Then
                myStream = openFD.OpenFile()
                If (myStream IsNot Nothing) Then
                    'Code to write the stream goes here.
                    nombredearchivo = CType(myStream, System.IO.FileStream).Name
                    myStream.Close()
                End If

            Else
                Return
            End If

            'Ruta Archivo
            FilePath = nombredearchivo

            'Dim msgretorno As String = ""
            'Dim fechactual As DateTime = DateTime.Now
            'Dim fechaFormateada As String = fechactual.ToString("dd/MM/yyyy")
            'Dim dataTable As DataTable = CType(tblconsulta.DataSource, DataTable)
            'Dim enumerableRows As IEnumerable(Of DataRow) = dataTable.AsEnumerable()

            'Limpar tabal importacion por ewmpresa , usuario y periodo
            Dim Periodo As String = gbano + gbmes
            'Dim EliminarDataTable = objSql.Ejecutar("Spu_Con_Del_ImporTempSireCompras", gbcodempresa, gbano, gbmes, gbNameUser)
            Dim EliminarDataTable = objSql.Ejecutar("Spu_Con_Del_ImporTempSireCompras", gbcodempresa, gbano, gbmes)

            Dim flag As Integer = 0
            Dim z As Integer = 0
            Dim isFirstRow As Boolean = True
            Dim fecha As DateTime
            Dim fechaFormateada As String

            Dim valor0 As String = ""
            Dim valor1 As String = ""
            Dim valor2 As String = ""
            Dim valor3 As String = ""
            Dim valor4 As String = ""
            Dim valor5 As String = ""
            Dim valor6 As String = ""
            Dim valor7 As String = ""
            Dim valor8 As String = ""
            Dim valor9 As String = ""
            Dim valor10 As String = ""
            Dim valor11 As String = ""
            Dim valor12 As String = ""
            Dim valor13 As String = ""
            Dim valor14 As Decimal
            Dim valor15 As Decimal
            Dim valor16 As Decimal
            Dim valor17 As Decimal
            Dim valor18 As Decimal
            Dim valor19 As Decimal
            Dim valor20 As Decimal
            Dim valor21 As Decimal
            Dim valor22 As Decimal
            Dim valor23 As Decimal
            Dim valor24 As Decimal

            Dim valor25 As String = ""
            Dim valor26 As Decimal
            Dim valor27 As String = ""
            Dim valor28 As String = ""
            Dim valor29 As String = ""
            Dim valor30 As String = ""
            Dim valor31 As String = ""
            Dim valor32 As String = ""
            Dim valor33 As String = ""
            Dim valor34 As String = ""
            Dim valor35 As Decimal
            Dim valor36 As String = ""
            Dim valor37 As String = ""
            Dim valor38 As String = ""
            Dim valor39 As String = ""
            Dim valor40 As Decimal
            Dim valor41 As String = ""
            Dim valor42 As String = ""
            Dim valor43 As String = ""
            Dim valor44 As String = ""
            Dim valor45 As String = ""
            Dim valor46 As String = ""
            Dim valor47 As String = ""
            Dim valor48 As String = ""
            Dim valor49 As String = ""
            Dim valor50 As String = ""
            Dim valor51 As String = ""
            Dim valor52 As String = ""
            Dim valor53 As String = ""
            Dim valor54 As String = ""
            Dim valor55 As String = ""
            Dim valor56 As String = ""
            Dim valor57 As String = ""
            Dim valor58 As String = ""
            Dim valor59 As String = ""
            Dim valor60 As String = ""
            Dim valor61 As String = ""
            Dim valor62 As String = ""
            Dim valor63 As String = ""
            Dim valor64 As String = ""
            Dim valor65 As String = ""
            Dim valor66 As String = ""
            Dim valor67 As String = ""
            Dim valor68 As String = ""
            Dim valor69 As String = ""
            Dim valor70 As String = ""
            Dim valor71 As String = ""
            Dim valor72 As String = ""
            Dim valor73 As String = ""
            Dim valor74 As String = ""
            Dim valor75 As String = ""
            Dim valor76 As String = ""
            Dim valor77 As String = ""
            Dim valor78 As String = ""
            Dim valor79 As String = ""
            Dim posicion As Integer

            Dim listaRegistrosCompras As New List(Of String)
            Using reader As New StreamReader(FilePath)

                'nueva linea codigo 1809


                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim values As String() = line.Split(","c) ' Separar los valores por comas

                    If isFirstRow Then
                        isFirstRow = False

                        'En la primera fila valida que contenga las cloumnas indicadas
                        Dim cantidadColumnas As Integer = values.Length()
                        If cantidadColumnas <> 80 Then
                            Dim msgFormato = "ERROR:: El archivo SIRE compras no tiene un formato valido. Por Favor cargue el formato correcto que contiene 80 columnas"
                            MessageBox.Show(msgFormato, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        Continue While
                    End If



                    fecha = DateTime.ParseExact(values(4), "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    fechaFormateada = fecha.ToString("dd-MM-yyyy")

                    posicion = 0
                    'value_0 = values(posicion)
                    'value_1 = values(posicion + 1)
                    '' controlar el error de coma en descripcion del razon social
                    'value_30 = values(posicion + 1)



                    valor0 = values(posicion + 0)
                    valor1 = values(posicion + 1)
                    valor2 = values(posicion + 2)
                    valor3 = values(posicion + 3)
                    valor4 = values(posicion + 4)
                    valor5 = values(posicion + 5)
                    valor6 = values(posicion + 6)
                    valor7 = values(posicion + 7)
                    valor8 = values(posicion + 8)
                    valor9 = values(posicion + 9)
                    valor10 = values(posicion + 10)
                    valor11 = values(posicion + 11)
                    valor12 = values(posicion + 12)
                    valor13 = values(posicion + 13)

                    If Decimal.TryParse(values(posicion + 14), 0) = False Then
                        posicion = 1
                    End If

                    valor14 = values(posicion + 14)
                    'IGV / IPM DG
                    If Decimal.TryParse(values(posicion + 15), 0) = False Then
                        valor15 = 0
                    Else
                        valor15 = values(posicion + 15)
                    End If

                    'BI Gravado DGNG
                    If Decimal.TryParse(values(posicion + 16), 0) = False Then
                        valor16 = 0
                    Else
                        valor16 = values(posicion + 16)
                    End If
                    'valor16 = values(posicion + 16)
                    If Decimal.TryParse(values(posicion + 17), 0) = False Then
                        valor17 = 0
                    Else
                        valor17 = values(posicion + 17)
                    End If
                    'valor17 = values(posicion + 17)


                    If Decimal.TryParse(values(posicion + 18), 0) = False Then
                        valor18 = 0
                    Else
                        valor18 = values(posicion + 18)
                    End If

                    'IGV / IPM DNG
                    If Decimal.TryParse(values(posicion + 19), 0) = False Then
                        valor19 = 0
                    Else
                        valor19 = values(posicion + 19)
                    End If
                    'Valor(Adq.NG)
                    If Decimal.TryParse(values(posicion + 20), 0) = False Then
                        valor20 = 0
                    Else
                        valor20 = values(posicion + 20)
                    End If
                    'ISC
                    If Decimal.TryParse(values(posicion + 21), 0) = False Then
                        valor21 = 0
                    Else
                        valor21 = values(posicion + 21)
                    End If
                    'ICBPER
                    If Decimal.TryParse(values(posicion + 22), 0) = False Then
                        valor22 = 0
                    Else
                        valor22 = values(posicion + 22)
                    End If
                    'valor22 = values(posicion + 22)
                    'Otros Trib/ Cargos
                    If Decimal.TryParse(values(posicion + 23), 0) = False Then
                        valor23 = 0
                    Else
                        valor23 = values(posicion + 23)
                    End If


                    'valor23 = values(posicion + 23)
                    'Total CP
                    If Decimal.TryParse(values(posicion + 24), 0) = False Then
                        valor24 = 0
                    Else
                        valor24 = values(posicion + 24)
                    End If


                    valor25 = values(posicion + 25)
                    'valor26 = values(posicion + 26)

                    'tipo de cambio
                    If Decimal.TryParse(values(posicion + 26), 0) = False Then
                        valor26 = 1
                    Else
                        valor26 = values(posicion + 26)
                    End If
                    valor27 = values(posicion + 27)
                    valor28 = values(posicion + 28)
                    valor29 = values(posicion + 29)
                    valor30 = values(posicion + 30)
                    valor31 = values(posicion + 31)
                    valor32 = values(posicion + 32)
                    valor33 = values(posicion + 33)
                    valor34 = values(posicion + 34)
                    valor35 = values(posicion + 35)
                    valor36 = values(posicion + 36)
                    valor37 = values(posicion + 37)
                    valor38 = values(posicion + 38)
                    valor39 = values(posicion + 39)
                    valor40 = values(posicion + 40)
                    valor41 = values(posicion + 41)
                    valor42 = values(posicion + 42)
                    valor43 = values(posicion + 43)
                    valor44 = values(posicion + 44)
                    valor45 = values(posicion + 45)
                    valor46 = values(posicion + 46)
                    valor47 = values(posicion + 47)
                    valor48 = values(posicion + 48)
                    valor49 = values(posicion + 49)
                    valor50 = values(posicion + 50)
                    valor51 = values(posicion + 51)
                    valor52 = values(posicion + 52)
                    valor53 = values(posicion + 53)
                    valor54 = values(posicion + 54)
                    valor55 = values(posicion + 55)
                    valor56 = values(posicion + 56)
                    valor57 = values(posicion + 57)
                    valor58 = values(posicion + 58)
                    valor59 = values(posicion + 59)
                    valor60 = values(posicion + 60)
                    valor61 = values(posicion + 61)
                    valor62 = values(posicion + 62)
                    valor63 = values(posicion + 63)
                    valor64 = values(posicion + 64)
                    valor65 = values(posicion + 65)
                    valor66 = values(posicion + 66)
                    valor67 = values(posicion + 67)
                    valor68 = values(posicion + 68)
                    valor69 = values(posicion + 69)
                    valor70 = values(posicion + 70)
                    valor71 = values(posicion + 71)
                    valor72 = values(posicion + 72)
                    valor73 = values(posicion + 73)
                    valor74 = values(posicion + 74)
                    valor75 = values(posicion + 75)
                    valor76 = values(posicion + 76)
                    valor77 = values(posicion + 77)
                    valor78 = values(posicion + 78)
                    valor79 = values(posicion + 79)

                    Dim filaCadena As String
                    filaCadena = valor0 + "|" + valor1 + "|" + valor2 + "|" + valor3 + "|" + valor4 + "|" + valor5 + "|" + valor6 + "|" + valor7 + "|" _
                     + valor8 + "|" + valor9 + "|" + valor10 + "|" + valor11 + "|" + valor12 + "|" + valor13 + "|" + valor14.ToString() + "|" + valor15.ToString _
                     + "|" + valor16.ToString + "|" + valor17.ToString + "|" + valor18.ToString + "|" + valor19.ToString + "|" + valor20.ToString + "|" _
                     + valor21.ToString + "|" + valor22.ToString + "|" _
                     + valor23.ToString + "|" + valor24.ToString + "|" + valor25 + "|" _
                    + valor26.ToString + "|" + valor27 + "|" + valor28 + "|" + valor29 + "|" + valor30 + "|" + valor31 + "|" + valor32 + "|" + valor33 + "|" _
                    + valor34 + "|" + valor35.ToString + "|" + valor36 + "|" + valor37 + "|" + valor38 + "|" + valor39 + "|" + valor40.ToString + "|" + valor41 + "|" _
                    + valor42 + "|" + valor43 + "|" _
                    + valor44 + "|" + valor45 + "|" + valor46 + "|" + valor47 + "|" + valor48 + "|" + valor49 + "|" + valor50 + "|" + valor51 + "|" _
                    + valor52 + "|" _
                    + valor53 + "|" + valor54 + "|" + valor55 + "|" + valor56 + "|" + valor57 + "|" + valor58 + "|" + valor59 + "|" _
                    + valor60 + "|" + valor61 + "|" _
                    + valor62 + "|" + valor63 + "|" + valor64 + "|" + valor65 + "|" + valor66 + "|" + valor67 + "|" + valor68 + "|" + valor69 + "|" + valor70 + "|" _
                    + valor71 + "|" + valor72 + "|" + valor73 + "|" + valor74 + "|" + valor75 + "|" + valor76 + "|" + valor77 + "|" + valor78 + "|" + valor79

                    listaRegistrosCompras.Add(filaCadena)

                    Cursor.Current = Cursors.WaitCursor
                End While
            End Using

            Dim xmldinamico As String = Funciones.Funciones.ConvertiraXMLdinamico(listaRegistrosCompras)
            'procedimiento a recibir el xml
            z = objSql.Ejecutar("Spu_Con_Ins_ImportarTemporalSireCompras", gbcodempresa,
                                gbano,
                                gbmes,
                               gbNameUser, xmldinamico, flag, "")




            'llamas a la temporal que has importado
            Dim flagInsertar As Integer = 0
            Dim msgretorno As String = ""
            Dim InsertarOriginal As Array = objSql.Ejecutar2("Spu_Con_Ins_cc43SireComprasImportacion", gbcodempresa, gbano, gbmes, gbNameUser, flagInsertar, "")
            msgretorno = InsertarOriginal(1, 2)
            MessageBox.Show(msgretorno, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerCabeceraSireCompras()
            TraerImportacionCompras()


        Catch ex As Exception
            MessageBox.Show("ERROR:: No se pudo Importar los datos :" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ImportarArchivo2()
        Try

            Dim FilePath As String

            Dim openFD As New OpenFileDialog()

            Dim strStreamW As Stream
            Dim strStreamWriter As StreamWriter
            Dim nombredearchivo As String = ""
            Dim rutadearchivo As String = ""
            Dim myStream As Stream

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Dim b As Array = Array.CreateInstance(GetType(Object), 2, 10)


            Dim sLine As String = ""
            Dim arrText As New ArrayList()


            With openFD
                .Title = "Seleccionar Archivos a importar"
                .Filter = "Todos los archivos (*.*)|*.*|(*.txt)|*.txt|(*.csv)|*.csv"
                .Multiselect = False
                .InitialDirectory = ""

            End With

            If openFD.ShowDialog() = DialogResult.OK Then
                myStream = openFD.OpenFile()
                If (myStream IsNot Nothing) Then
                    'Code to write the stream goes here.
                    nombredearchivo = CType(myStream, System.IO.FileStream).Name
                    myStream.Close()
                End If

            Else
                Return
            End If

            'Ruta Archivo
            FilePath = nombredearchivo

            'Dim msgretorno As String = ""
            'Dim fechactual As DateTime = DateTime.Now
            'Dim fechaFormateada As String = fechactual.ToString("dd/MM/yyyy")
            'Dim dataTable As DataTable = CType(tblconsulta.DataSource, DataTable)
            'Dim enumerableRows As IEnumerable(Of DataRow) = dataTable.AsEnumerable()

            'Limpar tabal importacion por ewmpresa , usuario y periodo
            Dim Periodo As String = gbano + gbmes
            'Dim EliminarDataTable = objSql.Ejecutar("Spu_Con_Del_ImporTempSireCompras", gbcodempresa, gbano, gbmes, gbNameUser)
            Dim EliminarDataTable = objSql.Ejecutar("Spu_Con_Del_ImporTempSireCompras", gbcodempresa, gbano, gbmes)

            Dim flag As Integer = 0
            Dim z As Integer = 0
            Dim isFirstRow As Boolean = True
            Dim fecha As DateTime
            Dim fechaFormateada As String

            Dim valor0 As String = ""
            Dim valor1 As String = ""
            Dim valor2 As String = ""
            Dim valor3 As String = ""
            Dim valor4 As String = ""
            Dim valor5 As String = ""
            Dim valor6 As String = ""
            Dim valor7 As String = ""
            Dim valor8 As String = ""
            Dim valor9 As String = ""
            Dim valor10 As String = ""
            Dim valor11 As String = ""
            Dim valor12 As String = ""
            Dim valor13 As String = ""
            Dim valor14 As Decimal
            Dim valor15 As Decimal
            Dim valor16 As Decimal
            Dim valor17 As Decimal
            Dim valor18 As Decimal
            Dim valor19 As Decimal
            Dim valor20 As Decimal
            Dim valor21 As Decimal
            Dim valor22 As Decimal
            Dim valor23 As Decimal
            Dim valor24 As Decimal

            Dim valor25 As String = ""
            Dim valor26 As Decimal
            Dim valor27 As String = ""
            Dim valor28 As String = ""
            Dim valor29 As String = ""
            Dim valor30 As String = ""
            Dim valor31 As String = ""
            Dim valor32 As String = ""
            Dim valor33 As String = ""
            Dim valor34 As String = ""
            Dim valor35 As Decimal
            Dim valor36 As String = ""
            Dim valor37 As String = ""
            Dim valor38 As String = ""
            Dim valor39 As String = ""
            Dim valor40 As Decimal
            Dim valor41 As String = ""
            Dim valor42 As String = ""
            Dim valor43 As String = ""
            Dim valor44 As String = ""
            Dim valor45 As String = ""
            Dim valor46 As String = ""
            Dim valor47 As String = ""
            Dim valor48 As String = ""
            Dim valor49 As String = ""
            Dim valor50 As String = ""
            Dim valor51 As String = ""
            Dim valor52 As String = ""
            Dim valor53 As String = ""
            Dim valor54 As String = ""
            Dim valor55 As String = ""
            Dim valor56 As String = ""
            Dim valor57 As String = ""
            Dim valor58 As String = ""
            Dim valor59 As String = ""
            Dim valor60 As String = ""
            Dim valor61 As String = ""
            Dim valor62 As String = ""
            Dim valor63 As String = ""
            Dim valor64 As String = ""
            Dim valor65 As String = ""
            Dim valor66 As String = ""
            Dim valor67 As String = ""
            Dim valor68 As String = ""
            Dim valor69 As String = ""
            Dim valor70 As String = ""
            Dim valor71 As String = ""
            Dim valor72 As String = ""
            Dim valor73 As String = ""
            Dim valor74 As String = ""
            Dim valor75 As String = ""
            Dim valor76 As String = ""
            Dim valor77 As String = ""
            Dim valor78 As String = ""
            Dim valor79 As String = ""
            Dim posicion As Integer

            Dim listaRegistrosCompras As New List(Of String)
            Using reader As New StreamReader(FilePath)

                'nueva linea codigo 1809


                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim values As String() = line.Split(","c) ' Separar los valores por comas

                    If isFirstRow Then
                        isFirstRow = False

                        'En la primera fila valida que contenga las cloumnas indicadas
                        Dim cantidadColumnas As Integer = values.Length()
                        If cantidadColumnas <> 80 Then
                            Dim msgFormato = "ERROR:: El archivo SIRE compras no tiene un formato valido. Por Favor cargue el formato correcto que contiene 80 columnas"
                            MessageBox.Show(msgFormato, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        Continue While
                    End If



                    fecha = DateTime.ParseExact(values(4), "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    fechaFormateada = fecha.ToString("dd-MM-yyyy")

                    posicion = 0
                    'value_0 = values(posicion)
                    'value_1 = values(posicion + 1)
                    '' controlar el error de coma en descripcion del razon social
                    'value_30 = values(posicion + 1)



                    valor0 = values(posicion + 0)
                    valor1 = values(posicion + 1)
                    valor2 = values(posicion + 2)
                    valor3 = values(posicion + 3)
                    valor4 = values(posicion + 4)
                    valor5 = values(posicion + 5)
                    valor6 = values(posicion + 6)
                    valor7 = values(posicion + 7)
                    valor8 = values(posicion + 8)
                    valor9 = values(posicion + 9)
                    valor10 = values(posicion + 10)
                    valor11 = values(posicion + 11)
                    valor12 = values(posicion + 12)
                    valor13 = values(posicion + 13)

                    If Decimal.TryParse(values(posicion + 14), 0) = False Then
                        posicion = 1
                    End If

                    valor14 = values(posicion + 14)
                    'IGV / IPM DG
                    If Decimal.TryParse(values(posicion + 15), 0) = False Then
                        valor15 = 0
                    Else
                        valor15 = values(posicion + 15)
                    End If

                    'BI Gravado DGNG
                    If Decimal.TryParse(values(posicion + 16), 0) = False Then
                        valor16 = 0
                    Else
                        valor16 = values(posicion + 16)
                    End If
                    'valor16 = values(posicion + 16)
                    If Decimal.TryParse(values(posicion + 17), 0) = False Then
                        valor17 = 0
                    Else
                        valor17 = values(posicion + 17)
                    End If
                    'valor17 = values(posicion + 17)


                    If Decimal.TryParse(values(posicion + 18), 0) = False Then
                        valor18 = 0
                    Else
                        valor18 = values(posicion + 18)
                    End If

                    'IGV / IPM DNG
                    If Decimal.TryParse(values(posicion + 19), 0) = False Then
                        valor19 = 0
                    Else
                        valor19 = values(posicion + 19)
                    End If
                    'Valor(Adq.NG)
                    If Decimal.TryParse(values(posicion + 20), 0) = False Then
                        valor20 = 0
                    Else
                        valor20 = values(posicion + 20)
                    End If
                    'ISC
                    If Decimal.TryParse(values(posicion + 21), 0) = False Then
                        valor21 = 0
                    Else
                        valor21 = values(posicion + 21)
                    End If
                    'ICBPER
                    If Decimal.TryParse(values(posicion + 22), 0) = False Then
                        valor22 = 0
                    Else
                        valor22 = values(posicion + 22)
                    End If
                    'valor22 = values(posicion + 22)
                    'Otros Trib/ Cargos
                    If Decimal.TryParse(values(posicion + 23), 0) = False Then
                        valor23 = 0
                    Else
                        valor23 = values(posicion + 23)
                    End If


                    'valor23 = values(posicion + 23)
                    'Total CP
                    If Decimal.TryParse(values(posicion + 24), 0) = False Then
                        valor24 = 0
                    Else
                        valor24 = values(posicion + 24)
                    End If


                    valor25 = values(posicion + 25)
                    'valor26 = values(posicion + 26)

                    'tipo de cambio
                    If Decimal.TryParse(values(posicion + 26), 0) = False Then
                        valor26 = 1
                    Else
                        valor26 = values(posicion + 26)
                    End If
                    valor27 = values(posicion + 27)
                    valor28 = values(posicion + 28)
                    valor29 = values(posicion + 29)
                    valor30 = values(posicion + 30)
                    valor31 = values(posicion + 31)
                    valor32 = values(posicion + 32)
                    valor33 = values(posicion + 33)
                    valor34 = values(posicion + 34)
                    valor35 = values(posicion + 35)
                    valor36 = values(posicion + 36)
                    valor37 = values(posicion + 37)
                    valor38 = values(posicion + 38)
                    valor39 = values(posicion + 39)
                    valor40 = values(posicion + 40)
                    valor41 = values(posicion + 41)
                    valor42 = values(posicion + 42)
                    valor43 = values(posicion + 43)
                    valor44 = values(posicion + 44)
                    valor45 = values(posicion + 45)
                    valor46 = values(posicion + 46)
                    valor47 = values(posicion + 47)
                    valor48 = values(posicion + 48)
                    valor49 = values(posicion + 49)
                    valor50 = values(posicion + 50)
                    valor51 = values(posicion + 51)
                    valor52 = values(posicion + 52)
                    valor53 = values(posicion + 53)
                    valor54 = values(posicion + 54)
                    valor55 = values(posicion + 55)
                    valor56 = values(posicion + 56)
                    valor57 = values(posicion + 57)
                    valor58 = values(posicion + 58)
                    valor59 = values(posicion + 59)
                    valor60 = values(posicion + 60)
                    valor61 = values(posicion + 61)
                    valor62 = values(posicion + 62)
                    valor63 = values(posicion + 63)
                    valor64 = values(posicion + 64)
                    valor65 = values(posicion + 65)
                    valor66 = values(posicion + 66)
                    valor67 = values(posicion + 67)
                    valor68 = values(posicion + 68)
                    valor69 = values(posicion + 69)
                    valor70 = values(posicion + 70)
                    valor71 = values(posicion + 71)
                    valor72 = values(posicion + 72)
                    valor73 = values(posicion + 73)
                    valor74 = values(posicion + 74)
                    valor75 = values(posicion + 75)
                    valor76 = values(posicion + 76)
                    valor77 = values(posicion + 77)
                    valor78 = values(posicion + 78)
                    valor79 = values(posicion + 79)

                    Dim filaCadena As String
                    filaCadena = valor0 + "|" + valor1 + "|" + valor2 + "|" + valor3 + "|" + valor4 + "|" + valor5 + "|" + valor6 + "|" + valor7 + "|" _
                     + valor8 + "|" + valor9 + "|" + valor10 + "|" + valor11 + "|" + valor12 + "|" + valor13 + "|" + valor14.ToString() + "|" _
                     + valor15.ToString() + "|" + valor16.ToString() + "|" + valor17.ToString() + "|" + valor18.ToString() + "|" + valor19.ToString() + "|" _
                     + valor20.ToString() + "|" + valor21.ToString() + "|" + valor22.ToString() + "|" + valor23.ToString() + "|" + valor24.ToString() + "|" + valor25 + "|" _
                    + valor26.ToString() + "|" + valor27 + "|" + valor28 + "|" + valor29 + "|" + valor30 + "|" + valor31 + "|" + valor32 + "|" + valor33 + "|" _
                    + valor34 + "|" + valor35.ToString() + "|" + valor36 + "|" + valor37 + "|" + valor38 + "|" + valor39 + "|" + valor40.ToString() + "|" + valor41 + "|" _
                    + valor42 + "|" + valor43 + "|" + valor44 + "|" + valor45 + "|" + valor46 + "|" + valor47 + "|" + valor48 + "|" + valor49 + "|" _
                    + valor50 + "|" + valor51 + "|" + valor52 + "|" + valor53 + "|" + valor54 + "|" + valor55 + "|" + valor56 + "|" + valor57 + "|" _
                    + valor58 + "|" + valor59 + "|" + valor60 + "|" + valor61 + "|" + valor62 + "|" + valor63 + "|" + valor64 + "|" + valor65 + "|" _
                    + valor66 + "|" + valor67 + "|" + valor68 + "|" + valor69 + "|" + valor70 + "|" + valor71 + "|" + valor72 + "|" + valor73 + "|" _
                    + valor74 + "|" + valor75 + "|" + valor76 + "|" + valor77 + "|" + valor78 + "|" + valor79

                    listaRegistrosCompras.Add(filaCadena)

                    'z = objSql.Ejecutar("Spu_Con_Ins_cc42SireComprasTempImportacion",
                    '                    gbcodempresa,
                    '                    gbano,
                    '                    gbmes,
                    '                   gbNameUser,
                    '                valor0,
                    '                valor1,
                    '                valor2,
                    '                valor3,
                    '                valor4,
                    '                valor5,
                    '                valor6,
                    '                valor7,
                    '                valor8,
                    '                valor9,
                    '                valor10,
                    '                valor11,
                    '                valor12,
                    '                valor13,
                    '                Decimal.Parse(valor14),
                    '                Decimal.Parse(valor15),
                    '                Decimal.Parse(valor16),
                    '                Decimal.Parse(valor17),
                    '                Decimal.Parse(valor18),
                    '                Decimal.Parse(valor19),
                    '                Decimal.Parse(valor20),
                    '                Decimal.Parse(valor21),
                    '                Decimal.Parse(valor22),
                    '                Decimal.Parse(valor23),
                    '                Decimal.Parse(valor24),
                    '                valor25,
                    '                Decimal.Parse(valor26),
                    '                valor27,
                    '                valor28,
                    '                valor29,
                    '                valor30,
                    '                valor31,
                    '                valor32,
                    '                valor33,
                    '                valor34,
                    '                Decimal.Parse(valor35),
                    '                valor36,
                    '                valor37,
                    '                valor38,
                    '                valor39,
                    '                Decimal.Parse(valor40),
                    '                valor41,
                    '                valor42,
                    '                valor43,
                    '                valor44,
                    '                valor45,
                    '                valor46,
                    '                valor47,
                    '                valor48,
                    '                valor49,
                    '                valor50,
                    '                valor51,
                    '                valor52,
                    '                valor53,
                    '                valor54,
                    '                valor55,
                    '                valor56,
                    '                valor57,
                    '                valor58,
                    '                valor59,
                    '                valor60,
                    '                valor61,
                    '                valor62,
                    '                valor63,
                    '                valor64,
                    '                valor65,
                    '                valor66,
                    '                valor67,
                    '                valor68,
                    '                valor69,
                    '                valor70,
                    '                valor71,
                    '                valor72,
                    '                valor73,
                    '                valor74,
                    '                valor75,
                    '                valor76,
                    '                valor77,
                    '                valor78,
                    '                valor79,
                    '                                  flag,
                    '                                  "")

                    Cursor.Current = Cursors.WaitCursor
                End While
            End Using

            Dim xmldinamico As String = Funciones.Funciones.ConvertiraXMLdinamico(listaRegistrosCompras)
            'procedimiento a recibir el xml 

            'llamas a la temporal que has importado
            Dim flagInsertar As Integer = 0
            'Dim msgretorno As String = ""
            'Dim InsertarOriginal As Array = objSql.Ejecutar2("Spu_Con_Ins_cc43SireComprasImportacion", gbcodempresa, gbano, gbmes, gbNameUser, flagInsertar, "")
            'msgretorno = InsertarOriginal(1, 2)
            'MessageBox.Show(msgretorno, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'TraerCabeceraSireCompras()
            'TraerImportacionCompras()


        Catch ex As Exception
            MessageBox.Show("ERROR:: No se pudo Importar los datos :" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Dim numeroFilas As Integer = tblconsulta.RowCount
        If numeroFilas > 0 Then
            If MessageBox.Show("ADVERTENCIA ::Se reemplazaran los datos anteriores y se agregaran los nuevos, ¿Esta Seguro de importar los nuevos datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.ImportarArchivo()
        ElseIf numeroFilas = 0 Then
            Me.ImportarArchivo()

        End If


    End Sub
    Private Sub btnvalidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ValidarImpVoucher()
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Validar los datos ue se importo
            Me.ValidarImpVoucher()
            '
            'If tblvalidacion.RowCount > 0 Then
            '    MsgBox("Corriga las validaciones de la importacion") : Exit Sub
            'End If


            'Si todo Ok
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("Spu_Con_Ins_VoucherImp", gbcodempresa, gbano, gbmes, gbNameUser, "")
            '
            Funciones.Funciones.MensajesdelSQl(a)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub TraerImportacionCompras()
        Try

            Dim periodo As String = gbano + gbmes
            Dim z As DataTable = objSql.TraerDataTable("Spu_Con_Trae_ImporTempSireCompras", gbcodempresa, gbano, gbmes, gbNameUser)
            tblconsultadet.DataSource = z
            Me.tblconsultadet.ColumnFooters = True
            Me.tblconsultadet.Columns("RUC").FooterText = "#Registros"
            Me.tblconsultadet.Columns("RAZONSOCIAL").FooterText = tblconsultadet.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TraerCabeceraSireCompras()
        Vista = objSql.TraerDataTable("Spu_Con_Trae_CabImporTempSireCompras", gbcodempresa, gbano, gbmes).DefaultView
        tblconsulta.SetDataBinding(Vista, Nothing, True)
    End Sub
    Public Sub Frm_ImportarSIRE_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cargar()

            Mod_Mantenimiento.Centrar(Me)
        Catch ex As Exception

        End Try


    End Sub
    Public Sub Cargar()
        tblhelp.Visible = False
        TraerCabeceraSireCompras()
        TraerImportacionCompras()
    End Sub
    Private Sub Trae_SireVsRegComprasIGUAL()

        Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegCompras", gbcodempresa, gbano, gbmes, "IGUAL").DefaultView

        tblconsultaiguales.SetDataBinding(Vista, Nothing, True)
        '
        Me.capturarfilaactual()
        tblconsultaiguales.ColumnFooters = True
        Me.tblconsultaiguales.Columns("Numero").FooterText = "#Registros"
        Me.tblconsultaiguales.Columns("Fecha_Documento").FooterText = tblconsultaiguales.RowCount.ToString

    End Sub
    Sub TraerAyuda(ByVal index As Integer, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp.Location = New Point(x, y)
            Mod_Mantenimiento.LimpiarFiltro(tblhelp)
            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"

            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.traer_libros()
            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub traer_libros()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Help_Libros_Por_Tipo", gbcodempresa, gbano, "ccb02cod", "*", "C").DefaultView
            tblhelp.SetDataBinding(Vista, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Trae_SireVsRegComprasIGUALCONDIFF()
        Try


            Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegCompras", gbcodempresa, gbano, gbmes, "IGUAl_CON_DIF").DefaultView
            tblconsulta_igualcondatodiff.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            tblconsulta_igualcondatodiff.ColumnFooters = True
            Me.tblconsulta_igualcondatodiff.Columns("Numero").FooterText = "#Registros"
            Me.tblconsulta_igualcondatodiff.Columns("Fecha_Documento").FooterText = Vista.Count.ToString

        Catch ex As Exception

        End Try


    End Sub
    Private Sub Trae_SireVsRegComprasSIRESI_COMPRASNO()
        Try
            'trae
            Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegCompras", gbcodempresa, gbano, gbmes, "SIRESI_COMPRASNO").DefaultView


            tblconsulta_SIsireNOregistroC.DataSource = Nothing
            tblconsulta_SIsireNOregistroC.SetDataBinding(Vista, Nothing, True)

            'Carga
            tblconsulta_SIsireNOregistroC.ColumnFooters = True
            Me.tblconsulta_SIsireNOregistroC.Columns("SireRuc").FooterText = ""
            Me.tblconsulta_SIsireNOregistroC.Columns("SireRazonSocial").FooterText = ""
            'NUEVOS VALORES 
            Me.tblconsulta_SIsireNOregistroC.Columns("SireRuc").FooterText = "# Registros"
            Me.tblconsulta_SIsireNOregistroC.Columns("SireRazonSocial").FooterText = Vista.Count.ToString



            tblconsulta_SIsireNOregistroC.Refresh()
            Me.capturarfilaactual()


        Catch ex As Exception

        End Try

    End Sub
    Private Sub Trae_SireVsRegCOMPRASSI_SIRENO()
        Try


            Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegCompras", gbcodempresa, gbano, gbmes, "COMPRASSI_SIRENO").DefaultView
            tblconsulta_SIregistroCNOsire.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()



            tblconsulta_SIregistroCNOsire.ColumnFooters = True
            Me.tblconsulta_SIregistroCNOsire.Columns("Numero").FooterText = "#Registros"
            Me.tblconsulta_SIregistroCNOsire.Columns("Fecha_Documento").FooterText = tblconsulta_SIregistroCNOsire.RowCount.ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LlenarSireConRegCompras()
        Dim Libro As String = txtLibro.Text
        Vista = objSql.TraerDataTable("Spu_Con_Trae_ComparaRegComVsSire", gbcodempresa, gbano, gbmes, txtLibro.Text).DefaultView
        tblconsulta_SIregistroCNOsire.SetDataBinding(Vista, Nothing, True)

    End Sub



    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click
        Dim periodo As String = gbano + gbmes
        Dim z As DataTable = objSql.TraerDataTable("Spu_Con_Trae_ImporTempSireCompras", gbcodempresa, gbano, gbmes, gbNameUser)
        tblconsultadet.DataSource = z
    End Sub

    Private Sub btnComparar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComparar.Click
        Try
            CompararSireVsCompras()

        Catch ex As Exception
            MessageBox.Show("ERROR::" + ex.Message)
        End Try

    End Sub
    Public Sub CompararSireVsCompras()
        Try
            If tblconsultadet.RowCount = 0 Then
                MessageBox.Show("ERROR :: No se ha importado datos para el Registro de Compras, vuelva a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                If txtLibro.Text = "" Then
                    MessageBox.Show("ERROR :: Es obligatorio seleccionar un libro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                ' compara o llena las tablas con los 4 estados 
                LlenarSireConRegCompras()
                'treas las comparaciones

                Trae_SireVsRegComprasIGUAL()
                Trae_SireVsRegComprasIGUALCONDIFF()
                Trae_SireVsRegCOMPRASSI_SIRENO()
                Trae_SireVsRegComprasSIRESI_COMPRASNO()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CompararSireVsCompras_RegistrarSire()
        Try

            'If tblconsultadet.RowCount = 0 Then
            '    MessageBox.Show("ERROR :: No se ha importado datos para el Registro de Compras, vuelva a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Return
            'Else
            '    If txtLibro.Text = "" Then
            '        MessageBox.Show("ERROR :: Es obligatorio seleccionar un libro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Return
            '    End If
            ' compara o llena las tablas con los 4 estados 
            txtLibro.Text = "04"
            LlenarSireConRegCompras()
            'treas las comparaciones

            'Trae_SireVsRegComprasIGUAL()
            'Trae_SireVsRegComprasIGUALCONDIFF()
            'Trae_SireVsRegCOMPRASSI_SIRENO()
            Trae_SireVsRegComprasSIRESI_COMPRASNO()


            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txtLibro.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtLibro.Focus()
            End Select

            Vista.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp.Tag, Integer)
        Try
            If tblhelp.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(0).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If txtLibro.Text = "" Then
            MessageBox.Show("ERROR :: Es obligatorio seleccionar un libro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            ExportarCompras()
        End If

    End Sub
    Private Sub ExportarCompras()
        Dim nombredearchivo As String = ""


        Try
            Dim strStreamWriter As StreamWriter

            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Seleccionar Carpeta para Guardar Archivos"
            folderBrowserDialog.ShowNewFolderButton = True
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = folderBrowserDialog.SelectedPath

            Else
                Return

            End If


            Dim selectedFolder As String = folderBrowserDialog.SelectedPath
            Dim dt As New DataSet
            dt = objSql.TraerDataSet("Spu_Con_Trae_SireComprasAnexo11", gbcodempresa, gbano, gbmes, txtLibro.Text)
            If dt.Tables.Count > 0 Then


                nombredearchivo = "LE" + dt.Tables(0).Rows(0)("ruc") + dt.Tables(0).Rows(0)("Periodo") + "0008040002" + "1" + "1" + "1" + "2"
            Else
                Return
            End If
            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo + ".txt")

            Dim campo_01 As String
            Dim campo_02 As String
            Dim campo_03 As String
            Dim campo_04 As String
            Dim campo_05 As String
            Dim campo_06 As String
            Dim campo_07 As String
            Dim campo_08 As String
            Dim campo_09 As String
            Dim campo_10 As String
            Dim campo_11 As String
            Dim campo_12 As String
            Dim campo_13 As String
            Dim campo_14 As String
            Dim campo_15 As String
            Dim campo_16 As String
            Dim campo_17 As String
            Dim campo_18 As String
            Dim campo_19 As String
            Dim campo_20 As String
            Dim campo_21 As String
            Dim campo_22 As String
            Dim campo_23 As String
            Dim campo_24 As String
            Dim campo_25 As String
            Dim campo_26 As String
            Dim campo_27 As String
            Dim campo_28 As String
            Dim campo_29 As String
            Dim campo_30 As String
            Dim campo_31 As String
            Dim campo_32 As String
            Dim campo_33 As String
            Dim campo_34 As String
            Dim campo_35 As String
            Dim campo_36 As String
            Dim campo_37 As String


            Using sw As StreamWriter = New StreamWriter(FilePath)

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("RUC").ToString
                    campo_02 = dr("Nombre_Empresa").ToString
                    campo_03 = dr("Periodo").ToString
                    campo_04 = dr("CAR_SUNAT").ToString
                    campo_05 = dr("Fecha_Emision").ToString
                    campo_06 = dr("FecPago").ToString
                    campo_07 = dr("TipoCP").ToString
                    campo_08 = dr("Serie_CP").ToString
                    campo_09 = dr("Anio").ToString
                    campo_10 = dr("Nro_CP").ToString
                    campo_11 = dr("NroFinal").ToString
                    campo_12 = dr("TipoDocIdentidad").ToString
                    campo_13 = dr("NroDocIdentidad").ToString
                    campo_14 = dr("Nombre_Cuenta_Corriente").ToString
                    campo_15 = dr("BI_GRAVADO_DG").ToString
                    campo_16 = dr("IGV").ToString
                    campo_17 = dr("BI_GRAVADO_DGNG").ToString
                    campo_18 = dr("IGV_IMPDGNG").ToString
                    campo_19 = dr("BI_GRAVADO_DNG").ToString
                    campo_20 = dr("IGV_IMPDNG").ToString
                    campo_21 = dr("ValorAdq_NG").ToString
                    campo_22 = dr("ISC").ToString
                    campo_23 = dr("ICB_PER").ToString
                    campo_24 = dr("OTROSTRIB").ToString
                    campo_25 = dr("Total_CP").ToString
                    campo_26 = dr("Moneda").ToString
                    campo_27 = dr("TipoDeCambio").ToString
                    campo_28 = dr("Fecha_documento").ToString
                    campo_29 = dr("Tipo_CP_Modif").ToString
                    campo_30 = dr("Serie_CP_Modif").ToString
                    campo_31 = dr("COD_DAM").ToString
                    campo_32 = dr("Nro_CP").ToString
                    campo_33 = dr("Clasif_Bss_Sss").ToString
                    campo_34 = dr("ID_PROYECTO").ToString
                    campo_35 = dr("PorcPart").ToString
                    campo_36 = dr("IMB").ToString
                    campo_37 = dr("CAR_CP").ToString



                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) & campo_16 & Chr(124) & campo_17 & Chr(124) & campo_18 & Chr(124) & campo_19 & Chr(124) & campo_20 & Chr(124) & campo_21 & Chr(124) & campo_22 & Chr(124) & campo_23 & Chr(124) & campo_24 & Chr(124) & campo_25 & Chr(124) & campo_26 & Chr(124) & campo_27 & Chr(124) & campo_28 & Chr(124) & campo_29 & Chr(124) & campo_30 & Chr(124) & campo_31 & Chr(124) & campo_32 & Chr(124) & campo_33 & Chr(124) & campo_34 & Chr(124) & campo_35 & Chr(124) & campo_36 & Chr(124) & campo_37 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)

                Next
                'Convertir a zip el txt

                'Dim rutaArchivoZip As String = selectedFolder



                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Meter el txt al zip
            Dim archivoZip As String = selectedFolder + "\" + nombredearchivo + ".zip"
            Using zip As New ZipFile()
                zip.AddFile(FilePath, "")
                zip.Save(archivoZip)
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor
            MessageBox.Show("El archivo se genero con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar la exportacion de Compras")
            Return
        End Try

    End Sub
    Private Sub ExportarComprasSujetoNoDomiciliado()
        Dim nombredearchivo As String = ""


        Try
            Dim strStreamWriter As StreamWriter

            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Seleccionar Carpeta para Guardar Archivos"
            folderBrowserDialog.ShowNewFolderButton = True
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = folderBrowserDialog.SelectedPath

            Else
                Return

            End If


            Dim selectedFolder As String = folderBrowserDialog.SelectedPath
            Dim dt As New DataSet
            dt = objSql.TraerDataSet("Spu_Con_Trae_SireComprasAnexo09", gbcodempresa, gbano, gbmes, txtLibro.Text)
            If dt.Tables.Count > 0 Then


                nombredearchivo = "LE" + dt.Tables(0).Rows(0)("ruc") + dt.Tables(0).Rows(0)("Periodo") + "0008050002" + "1" + "1" + "1" + "2"
            Else
                Return
            End If
            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo + ".txt")

            Dim campo_01 As String
            Dim campo_02 As String
            Dim campo_03 As String
            Dim campo_04 As String
            Dim campo_05 As String
            Dim campo_06 As String
            Dim campo_07 As String
            Dim campo_08 As String
            Dim campo_09 As String
            Dim campo_10 As String
            Dim campo_11 As String
            Dim campo_12 As String
            Dim campo_13 As String
            Dim campo_14 As String
            Dim campo_15 As String
            Dim campo_16 As String
            Dim campo_17 As String
            Dim campo_18 As String
            Dim campo_19 As String
            Dim campo_20 As String
            Dim campo_21 As String
            Dim campo_22 As String
            Dim campo_23 As String
            Dim campo_24 As String
            Dim campo_25 As String
            Dim campo_26 As String
            Dim campo_27 As String
            Dim campo_28 As String
            Dim campo_29 As String
            Dim campo_30 As String
            Dim campo_31 As String
            Dim campo_32 As String
            Dim campo_33 As String
            Dim campo_34 As String
            Dim campo_35 As String
            Dim campo_36 As String
            Dim campo_37 As String


            Using sw As StreamWriter = New StreamWriter(FilePath)

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CAR_SUNAT").ToString
                    campo_03 = dr("TipoCP").ToString
                    campo_04 = dr("Serie_CP").ToString
                    campo_05 = dr("Nro_CP").ToString
                    campo_06 = dr("ValorAdq_NG").ToString
                    campo_07 = dr("Otros").ToString
                    campo_08 = dr("Total_CP").ToString
                    campo_09 = dr("Tipo_CP_Modif").ToString
                    campo_10 = dr("Serie_CP_Modif").ToString
                    campo_11 = dr("Anio").ToString
                    campo_12 = dr("Nro_CP").ToString
                    campo_13 = dr("Monto_Retencion").ToString
                    campo_14 = dr("Moneda").ToString
                    campo_15 = dr("TipoDeCambio").ToString
                    campo_16 = dr("Pais").ToString
                    campo_17 = dr("Razon_Social_Sujeto").ToString
                    campo_18 = dr("Domicilio").ToString
                    campo_19 = dr("ID_Sujeto").ToString
                    campo_20 = dr("ID_Beneficiario").ToString
                    campo_21 = dr("Razon_Social_Beneficiario").ToString
                    campo_22 = dr("Pais_Beneficiario").ToString
                    campo_23 = dr("Vinculo").ToString
                    campo_24 = dr("Rta_Bta").ToString
                    campo_25 = dr("Deduc_Costo").ToString
                    campo_26 = dr("Rta_Neta").ToString
                    campo_27 = dr("Tasa").ToString
                    campo_28 = dr("Impto").ToString
                    campo_29 = dr("Convenio").ToString
                    campo_30 = dr("Exoneracion").ToString
                    campo_31 = dr("Tipo_Rta").ToString
                    campo_32 = dr("Mod_Serv").ToString
                    campo_33 = dr("Art_76").ToString
                    campo_34 = dr("Car_Orig").ToString
                    campo_35 = dr("CLU").ToString



                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) & campo_16 & Chr(124) & campo_17 & Chr(124) & campo_18 & Chr(124) & campo_19 & Chr(124) & campo_20 & Chr(124) & campo_21 & Chr(124) & campo_22 & Chr(124) & campo_23 & Chr(124) & campo_24 & Chr(124) & campo_25 & Chr(124) & campo_26 & Chr(124) & campo_27 & Chr(124) & campo_28 & Chr(124) & campo_29 & Chr(124) & campo_30 & Chr(124) & campo_31 & Chr(124) & campo_32 & Chr(124) & campo_33 & Chr(124) & campo_34 & Chr(124) & campo_35 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor
            MessageBox.Show("El archivo se genero con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar la exportacion de Compras")
            Return
        End Try

    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        Try
            If tblconsulta_igualcondatodiff.RowCount = 0 Then
                Return
            End If
            Dim excelApp As New Excel.Application()
            Dim save As Excel.Workbook = excelApp.Workbooks.Add()
            Dim dt As Excel.Worksheet = save.Sheets(1)

            ' Obtener el C1TrueDBGrid
            Dim grid As C1TrueDBGrid = tblconsulta_igualcondatodiff

            ' Exportar los datos del C1TrueDBGrid a Excel
            For i As Integer = 0 To grid.Columns.Count - 1
                dt.Cells(1, i + 1) = grid.Columns(i).Caption
                Cursor.Current = Cursors.WaitCursor
            Next

            For i As Integer = 0 To grid.RowCount - 1
                For j As Integer = 0 To grid.Columns.Count - 1
                    dt.Cells(i + 2, j + 1) = grid(i, j).ToString()
                    Cursor.Current = Cursors.WaitCursor
                Next
            Next
            ' Guardar el archivo de Excel

            Dim fileName As String = "MineraDeisi_sire_" + gbano + gbmes + "siredifCompras" + ".xlsx"
            Dim tempPath As String = Path.GetTempPath()
            Dim filePath As String = Path.Combine(tempPath, fileName)


            Dim saveFileDialog As New SaveFileDialog()
            'NOMBRE ARCHIVO
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            saveFileDialog.FileName = gbano + gbmes + "_Sire_ComprasDiff" + ".xlsx"
            Dim NombreArchivo As String = saveFileDialog.FileName
            'END NOMBRE ARCHIVO
            'ABRIR EL ARCHIVO

            'If saveFileDialog.ShowDialog() = DialogResult.OK Then

            'Dim FilePath As String = Path.Combine(selectedFolder, NombreArchivo)
            save.SaveAs(filePath)

            MessageBox.Show("Datos exportados correctamente a Excel.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    Return
            'End If

            '' Cerrar Excel
            excelApp.Quit()

            Process.Start("excel.exe", """" + filePath + """")
        Catch ex As Exception
            MessageBox.Show("ERROR :: No se pudo exportar los datos:" + ex.Message)
        End Try
    End Sub

    Private Sub BtnExportarSire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarSire.Click
        Try
            If tblconsulta_SIsireNOregistroC.RowCount = 0 Then
                Return
            End If

            Dim excelApp As New Excel.Application()
            Dim save As Excel.Workbook = excelApp.Workbooks.Add()
            Dim dt As Excel.Worksheet = save.Sheets(1)

            ' Obtener el C1TrueDBGrid
            Dim grid As C1TrueDBGrid = tblconsulta_SIsireNOregistroC

            ' Exportar los datos del C1TrueDBGrid a Excel
            For i As Integer = 0 To grid.Columns.Count - 1
                dt.Cells(1, i + 1) = grid.Columns(i).Caption
                Cursor.Current = Cursors.WaitCursor
            Next

            For i As Integer = 0 To grid.RowCount - 1
                For j As Integer = 0 To grid.Columns.Count - 1
                    dt.Cells(i + 2, j + 1) = grid(i, j).ToString()
                    Cursor.Current = Cursors.WaitCursor
                Next
            Next
            ' Guardar el archivo de Excel

            Dim fileName As String = "MineraDeisi_sire_" + gbano + gbmes + "RegistroSire" + ".xlsx"
            Dim tempPath As String = Path.GetTempPath()
            Dim filePath As String = Path.Combine(tempPath, fileName)


            Dim saveFileDialog As New SaveFileDialog()
            'NOMBRE ARCHIVO
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            'END NOMBRE ARCHIVO
            'ABRIR EL ARCHIVO

            'If saveFileDialog.ShowDialog() = DialogResult.OK Then

            'Dim FilePath As String = Path.Combine(selectedFolder, NombreArchivo)
            save.SaveAs(filePath)

            MessageBox.Show("Datos exportados correctamente a Excel.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    Return
            'End If

            '' Cerrar Excel
            excelApp.Quit()

            Process.Start("excel.exe", """" + filePath + """")
        Catch ex As Exception
            MessageBox.Show("ERROR :: No se pudo exportar los datos")
        End Try
    End Sub

    Private Sub btnExportarRegVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarRegVentas.Click
        Try
            If tblconsulta_SIregistroCNOsire.RowCount = 0 Then
                Return
            End If

            Dim excelApp As New Excel.Application()
            Dim save As Excel.Workbook = excelApp.Workbooks.Add()
            Dim dt As Excel.Worksheet = save.Sheets(1)

            ' Obtener el C1TrueDBGrid
            Dim grid As C1TrueDBGrid = tblconsulta_SIregistroCNOsire

            ' Exportar los datos del C1TrueDBGrid a Excel
            For i As Integer = 0 To grid.Columns.Count - 1
                dt.Cells(1, i + 1) = grid.Columns(i).Caption
                Cursor.Current = Cursors.WaitCursor
            Next

            For i As Integer = 0 To grid.RowCount - 1
                For j As Integer = 0 To grid.Columns.Count - 1
                    dt.Cells(i + 2, j + 1) = grid(i, j).ToString()
                    Cursor.Current = Cursors.WaitCursor
                Next
            Next
            ' Guardar el archivo de Excel

            Dim fileName As String = "MineraDeisi_sire_" + gbano + gbmes + "RegistroCompras" + ".xlsx"
            Dim tempPath As String = Path.GetTempPath()
            Dim filePath As String = Path.Combine(tempPath, fileName)

            'MessageBox.Show("Ruta de archivo, varialbe filePath:" + filePath)
            Dim saveFileDialog As New SaveFileDialog()
            'NOMBRE ARCHIVO
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            'END NOMBRE ARCHIVO
            'ABRIR EL ARCHIVO

            'If saveFileDialog.ShowDialog() = DialogResult.OK Then

            'Dim FilePath As String = Path.Combine(selectedFolder, NombreArchivo)
            save.SaveAs(filePath)
            'MessageBox.Show("Se ejecuta el metodo SaveAs la ruta del archivo guardado es :" + filePath)
            MessageBox.Show("Datos exportados correctamente a Excel.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    Return
            'End If

            '' Cerrar Excel
            excelApp.Quit()
            'MessageBox.Show("Ruta desde se abrira el archivo excel , varialbe filePath:" + filePath)
            Process.Start("excel.exe", """" + filePath + """")
        Catch ex As Exception
            MessageBox.Show("ERROR :: No se pudo exportar los datos:" + ex.Message)
        End Try
    End Sub

    Private Sub BtnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistrar.Click
        Try
            If tblconsulta_SIsireNOregistroC.RowCount = 0 Then
                Return
            End If

            Dim Frm_RegistrarCompras As New Frm_RegistrarCompras
            'Frm_RegistrarCompras.p_accionMante = "N"
            Frm_RegistrarCompras.Owner = Me
            Frm_RegistrarCompras.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            CompararSireVsCompras_RegistrarSire()

        Catch ex As Exception
            MessageBox.Show("ERROR::" + ex.Message)
        End Try
    End Sub


    Private Sub tblhelp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                tblhelp_DoubleClick(Nothing, Nothing)
            ElseIf e.KeyCode = Keys.Escape Then
                If tblhelp.Visible = True Then
                    tblhelp.Visible = False
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVistaPrevia.Click
        Try
            Dim objR As New Ks.Com.Win.CystalReports.Net.File
            Dim ds As System.Data.DataSet
            Dim arrFormulas As New List(Of Ks.Com.Win.CystalReports.Net.FormulasReportes)

            Dim nombredereporte As String
            Dim Rutareporte As String
            Dim flagordena As String
            Dim flagfiltro As String
            Dim nombreper As String
            If txtLibro.Text = "" Then
                MessageBox.Show("ERROR :: Es obligatorio seleccionar un libro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'Mostrar el reporte Registro Compras

            nombreper = "PERIODO : " + gbano + "-" + gbmes

            'Rutareporte = gbRutaAplicacion + "\reports\"
            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor

            ' Asigno el Nombre del Reporte

            'If sstabregcompras.SelectedIndex = 0 Then
            nombredereporte = "regCompr_new_a3.Rpt"

            flagordena = "1"
            flagfiltro = "*" + "N"
            'Else
            '    If chkagrupa.Checked = True Then
            '        nombredereporte = "regcompr_new_por_tipdoc_a3.rpt"
            '    Else
            '        nombredereporte = "regCompr_new_a3.Rpt"
            '    End If

            '    flagordena = If(chkordena.Checked = True, "2", "1")
            '    flagfiltro = If(rbtfiltro_1.Checked = True, "1", If(rbtfiltro_2.Checked = True, "2", "*"))
            'End If

            ds = objSql.TraerDataSet("sp_Con_Rep_RegistroCompras", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, flagordena, flagfiltro, "S").Copy()

            'Formulas de reporte
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Pagina", 1))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("nro_formulario", ""))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("nro_orden", ""))

            'Visualizar reportes
            'If flagimpresion = "P" Then
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            'Else
            '    objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            'End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub


    Public Function ConvertiraXMLdinamico(ByVal lista As IEnumerable(Of String)) As String
        Dim sb As New StringBuilder()
        sb.Append("<DataSet>")

        ' Loop through rows
        For Each fila In lista
            ' Loop through columns
            Dim celdas() As String = fila.Split("|")
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


End Class