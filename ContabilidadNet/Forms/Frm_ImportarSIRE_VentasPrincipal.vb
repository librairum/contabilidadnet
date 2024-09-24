Imports System.IO
Imports System.Globalization
Imports System.Net.Mime.MediaTypeNames
Imports C1.C1Preview
Imports C1.Win.C1PrintPreview
Imports C1.C1PrintDocument
''


Imports C1.C1Excel
Imports Excel = Microsoft.Office.Interop.Excel
Imports C1.Win.C1TrueDBGrid
Imports Ionic.Zip
Imports System.Text

Public Class Frm_ImportarSIRE_VentasPrincipal
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
            Dim EliminarDataTable = objSql.Ejecutar("Spu_Con_Del_ImporTempSireVentas", gbcodempresa, gbano, gbmes, gbNameUser)


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
            'Decimal
            Dim valor13 As Decimal
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
            Dim valor25 As Decimal
            'End Decimal
            Dim valor26 As String = ""

            Dim valor27 As Decimal

            Dim valor28 As String = ""
            Dim valor29 As String = ""
            Dim valor30 As String = ""
            Dim valor31 As String = ""
            Dim valor32 As String = ""
            Dim valor33 As String = ""
            Dim valor34 As String = ""

            Dim valor35 As Decimal
            Dim valor36 As Decimal
            Dim valor37 As String = ""
            Dim valor38 As String = ""
            Dim valor39 As String = ""

            Dim posicion As Integer
            Dim listaRegistrosCompras As New List(Of String)
            Using reader As New StreamReader(FilePath)


                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim values As String() = line.Split(","c) ' Separar los valores por comas
                    If isFirstRow Then
                        isFirstRow = False
                        Dim cantidadColumnas As Integer = values.Length()
                        If cantidadColumnas <> 40 Then
                            Dim msgFormato = "ERROR:: El archivo SIRE Ventas no tiene un formato valido. Por Favor cargue el formato correcto que contiene 40 columnas"
                            MessageBox.Show(msgFormato, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                        Continue While
                    End If


                    'values(5)

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

                    If Decimal.TryParse(values(posicion + 13), 0) = False Then
                        posicion = 1
                    End If

                    'Valor Facturado Exportación
                    If Decimal.TryParse(values(posicion + 13), 0) = False Then
                        valor13 = 0
                    Else
                        valor13 = values(posicion + 13)
                    End If

                    'valor13 = values(posicion + 13)

                    'BI Gravada
                    If Decimal.TryParse(values(posicion + 14), 0) = False Then
                        valor14 = 0
                    Else
                        valor14 = values(posicion + 14)
                    End If

                    'Dscto BI
                    If Decimal.TryParse(values(posicion + 15), 0) = False Then
                        valor15 = 0
                    Else
                        valor15 = values(posicion + 15)
                    End If
                    'valor15 = values(posicion + 15)

                    'IGV / IPM
                    If Decimal.TryParse(values(posicion + 16), 0) = False Then
                        valor16 = 0
                    Else
                        valor16 = values(posicion + 16)
                    End If

                    'Dscto IGV / IPM
                    If Decimal.TryParse(values(posicion + 17), 0) = False Then
                        valor17 = 0
                    Else
                        valor17 = values(posicion + 17)
                    End If

                    'Mto Exonerado
                    If Decimal.TryParse(values(posicion + 18), 0) = False Then
                        valor18 = 0
                    Else
                        valor18 = values(posicion + 18)
                    End If

                    'Mto Inafecto
                    If Decimal.TryParse(values(posicion + 19), 0) = False Then
                        valor19 = 0
                    Else
                        valor19 = values(posicion + 19)
                    End If

                    'ISC
                    If Decimal.TryParse(values(posicion + 20), 0) = False Then
                        valor20 = 0
                    Else
                        valor20 = values(posicion + 20)
                    End If

                    'BI Grav IVAP
                    If Decimal.TryParse(values(posicion + 21), 0) = False Then
                        valor21 = 0
                    Else
                        valor21 = values(posicion + 21)
                    End If

                    'IVAP

                    If Decimal.TryParse(values(posicion + 22), 0) = False Then
                        valor2 = 0
                    Else
                        valor22 = values(posicion + 22)
                    End If

                    'ICBPER
                    If Decimal.TryParse(values(posicion + 23), 0) = False Then
                        valor23 = 0
                    Else
                        valor23 = values(posicion + 23)
                    End If
                    'valor23 = values(posicion + 23)

                    'Otros Tributos
                    If Decimal.TryParse(values(posicion + 24), 0) = False Then
                        valor24 = 0
                    Else
                        valor24 = values(posicion + 24)
                    End If



                    'Total CP

                    If Decimal.TryParse(values(posicion + 25), 0) = False Then
                        valor25 = 0
                    Else
                        valor25 = values(posicion + 25)
                    End If

                    'tipo de moneda PEN o USD
                    valor26 = values(posicion + 26)

                    'tipo de cambio
                    If Decimal.TryParse(values(posicion + 27), 0) = False Then
                        valor27 = 1
                    Else
                        valor27 = values(posicion + 27)
                    End If

                    'valor27 = values(posicion + 27)
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

                    Dim filaCadena As String
                    filaCadena = valor0 + "|" + valor1 + "|" + valor2 + "|" _
                                + valor3 + "|" + valor4 + "|" + valor5 + "|" + valor6 + "|" + valor7 + "|" _
                                + valor8 + "|" + valor9 + "|" + valor10 + "|" + valor11 + "|" + valor12 + "|" _
                                + valor13.ToString + "|" + valor14.ToString + "|" + valor15.ToString + "|" + valor16.ToString + "|" _
                                + valor17.ToString + "|" + valor18.ToString + "|" + valor19.ToString + "|" _
                                + valor20.ToString + "|" + valor21.ToString + "|" + valor22.ToString + "|" _
                                + valor23.ToString + "|" + valor24.ToString + "|" + valor25.ToString + "|" _
                                + valor26 + "|" + valor27.ToString + "|" _
                                + valor28 + "|" + valor29 + "|" + valor30 + "|" + valor31 + "|" + valor32 + "|" _
                                + valor33 + "|" + valor34 + "|" + valor35.ToString + "|" + valor36.ToString + "|" + valor37 + "|" _
                                + valor38 + "|" + valor39
                    listaRegistrosCompras.Add(filaCadena)
                    'z = objSql.Ejecutar("Spu_Con_Ins_cc40SireVentasTempImportacion",
                    '                    gbcodempresa,
                    '                    gbano,
                    '                    gbmes,
                    '                   gbNameUser,
                    '                          valor0,
                    '                          valor1,
                    '                          valor2,
                    '                          valor3,
                    '                          valor4,
                    '                          valor5,
                    '                          valor6,
                    '                          valor7,
                    '                          valor8,
                    '                          valor9,
                    '                          valor10,
                    '                           valor11,
                    '                           valor12,
                    '                           Decimal.Parse(valor13),
                    '                    Decimal.Parse(valor14),
                    '                    Decimal.Parse(valor15),
                    '                    Decimal.Parse(valor16),
                    '                    Decimal.Parse(valor17),
                    '                    Decimal.Parse(valor18),
                    '                    Decimal.Parse(valor19),
                    '                    Decimal.Parse(valor20),
                    '                    Decimal.Parse(valor21),
                    '                    Decimal.Parse(valor22),
                    '                    Decimal.Parse(valor23),
                    '                    Decimal.Parse(valor24),
                    '                    Decimal.Parse(valor25),
                    '                    valor26,
                    '                    Decimal.Parse(valor27),
                    '                    valor28,
                    '                    valor29,
                    '                    valor30,
                    '                    valor31,
                    '                    valor32,
                    '                    valor33,
                    '                    valor34,
                    '                    Decimal.Parse(valor35),
                    '                    Decimal.Parse(valor36),
                    '                    valor37,
                    '                    valor38,
                    '                    valor39,
                    '                                  flag,
                    '                                  "")
                    Cursor.Current = Cursors.WaitCursor
                End While
            End Using
            Dim xmldinamico As String = Funciones.Funciones.ConvertiraXMLdinamico(listaRegistrosCompras)
            z = objSql.Ejecutar("Spu_Con_Ins_ImportarTemporalSireVentas", gbcodempresa,
                              gbano,
                              gbmes,
                             gbNameUser, xmldinamico, flag, "")

            'llamas a la temporal que has importado
            Dim flagInsertar As Integer = 0
            Dim msgretorno As String = ""
            Dim InsertarOriginal As Array = objSql.Ejecutar2("Spu_Con_Ins_cc41SireVentasImportacion", gbcodempresa, gbano, gbmes, gbNameUser, flagInsertar, "")
            msgretorno = InsertarOriginal(1, 2)
            MessageBox.Show(msgretorno, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerCabeceraSireVentas()
            TraerImportacionVentas()


        Catch ex As Exception
            MessageBox.Show("ERROR:: No se pudo Importar los datos o el archivo a importar esta abierto, vuelva a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim EliminarDataTable = objSql.Ejecutar("Spu_Con_Del_ImporTempSireVentas", gbcodempresa, gbano, gbmes, gbNameUser)


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
            'Decimal
            Dim valor13 As Decimal
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
            Dim valor25 As Decimal
            'End Decimal
            Dim valor26 As String = ""

            Dim valor27 As Decimal

            Dim valor28 As String = ""
            Dim valor29 As String = ""
            Dim valor30 As String = ""
            Dim valor31 As String = ""
            Dim valor32 As String = ""
            Dim valor33 As String = ""
            Dim valor34 As String = ""

            Dim valor35 As Decimal
            Dim valor36 As Decimal
            Dim valor37 As String = ""
            Dim valor38 As String = ""
            Dim valor39 As String = ""

            Dim posicion As Integer

            Using reader As New StreamReader(FilePath)


                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim values As String() = line.Split(","c) ' Separar los valores por comas
                    If isFirstRow Then
                        isFirstRow = False
                        Dim cantidadColumnas As Integer = values.Length()
                        If cantidadColumnas <> 40 Then
                            Dim msgFormato = "ERROR:: El archivo SIRE Ventas no tiene un formato valido. Por Favor cargue el formato correcto que contiene 40 columnas"
                            MessageBox.Show(msgFormato, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                        Continue While
                    End If


                    'values(5)

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

                    If Decimal.TryParse(values(posicion + 13), 0) = False Then
                        posicion = 1
                    End If

                    'Valor Facturado Exportación
                    If Decimal.TryParse(values(posicion + 13), 0) = False Then
                        valor13 = 0
                    Else
                        valor13 = values(posicion + 13)
                    End If

                    'valor13 = values(posicion + 13)

                    'BI Gravada
                    If Decimal.TryParse(values(posicion + 14), 0) = False Then
                        valor14 = 0
                    Else
                        valor14 = values(posicion + 14)
                    End If

                    'Dscto BI
                    If Decimal.TryParse(values(posicion + 15), 0) = False Then
                        valor15 = 0
                    Else
                        valor15 = values(posicion + 15)
                    End If
                    'valor15 = values(posicion + 15)

                    'IGV / IPM
                    If Decimal.TryParse(values(posicion + 16), 0) = False Then
                        valor16 = 0
                    Else
                        valor16 = values(posicion + 16)
                    End If

                    'Dscto IGV / IPM
                    If Decimal.TryParse(values(posicion + 17), 0) = False Then
                        valor17 = 0
                    Else
                        valor17 = values(posicion + 17)
                    End If

                    'Mto Exonerado
                    If Decimal.TryParse(values(posicion + 18), 0) = False Then
                        valor18 = 0
                    Else
                        valor18 = values(posicion + 18)
                    End If

                    'Mto Inafecto
                    If Decimal.TryParse(values(posicion + 19), 0) = False Then
                        valor19 = 0
                    Else
                        valor19 = values(posicion + 19)
                    End If

                    'ISC
                    If Decimal.TryParse(values(posicion + 20), 0) = False Then
                        valor20 = 0
                    Else
                        valor20 = values(posicion + 20)
                    End If

                    'BI Grav IVAP
                    If Decimal.TryParse(values(posicion + 21), 0) = False Then
                        valor21 = 0
                    Else
                        valor21 = values(posicion + 21)
                    End If

                    'IVAP

                    If Decimal.TryParse(values(posicion + 22), 0) = False Then
                        valor2 = 0
                    Else
                        valor22 = values(posicion + 22)
                    End If

                    'ICBPER
                    If Decimal.TryParse(values(posicion + 23), 0) = False Then
                        valor23 = 0
                    Else
                        valor23 = values(posicion + 23)
                    End If
                    'valor23 = values(posicion + 23)

                    'Otros Tributos
                    If Decimal.TryParse(values(posicion + 24), 0) = False Then
                        valor24 = 0
                    Else
                        valor24 = values(posicion + 24)
                    End If



                    'Total CP

                    If Decimal.TryParse(values(posicion + 25), 0) = False Then
                        valor25 = 0
                    Else
                        valor25 = values(posicion + 25)
                    End If

                    'tipo de moneda PEN o USD
                    valor26 = values(posicion + 26)

                    'tipo de cambio
                    If Decimal.TryParse(values(posicion + 27), 0) = False Then
                        valor27 = 1
                    Else
                        valor27 = values(posicion + 27)
                    End If

                    'valor27 = values(posicion + 27)
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


                    z = objSql.Ejecutar("Spu_Con_Ins_cc40SireVentasTempImportacion",
                                        gbcodempresa,
                                        gbano,
                                        gbmes,
                                       gbNameUser,
                                              valor0,
                                              valor1,
                                              valor2,
                                              valor3,
                                              valor4,
                                              valor5,
                                              valor6,
                                              valor7,
                                              valor8,
                                              valor9,
                                              valor10,
                                               valor11,
                                               valor12,
                                               Decimal.Parse(valor13),
                                        Decimal.Parse(valor14),
                                        Decimal.Parse(valor15),
                                        Decimal.Parse(valor16),
                                        Decimal.Parse(valor17),
                                        Decimal.Parse(valor18),
                                        Decimal.Parse(valor19),
                                        Decimal.Parse(valor20),
                                        Decimal.Parse(valor21),
                                        Decimal.Parse(valor22),
                                        Decimal.Parse(valor23),
                                        Decimal.Parse(valor24),
                                        Decimal.Parse(valor25),
                                        valor26,
                                        Decimal.Parse(valor27),
                                        valor28,
                                        valor29,
                                        valor30,
                                        valor31,
                                        valor32,
                                        valor33,
                                        valor34,
                                        Decimal.Parse(valor35),
                                        Decimal.Parse(valor36),
                                        valor37,
                                        valor38,
                                        valor39,
                                                      flag,
                                                      "")
                    Cursor.Current = Cursors.WaitCursor
                End While
            End Using

            'llamas a la temporal que has importado
            Dim flagInsertar As Integer = 0
            Dim msgretorno As String = ""
            Dim InsertarOriginal As Array = objSql.Ejecutar2("Spu_Con_Ins_cc41SireVentasImportacion", gbcodempresa, gbano, gbmes, gbNameUser, flagInsertar, "")
            msgretorno = InsertarOriginal(1, 2)
            MessageBox.Show(msgretorno, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerCabeceraSireVentas()
            TraerImportacionVentas()


        Catch ex As Exception
            MessageBox.Show("ERROR:: No se pudo Importar los datos o el archivo a importar esta abierto, vuelva a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub TraerImportacionVentas()
        Try

            Dim periodo As String = gbano + gbmes
            Dim z As DataTable = objSql.TraerDataTable("Spu_Con_Trae_ImporTempSireVentas", gbcodempresa, gbano, gbmes, gbNameUser)
            tblconsultadet.DataSource = z
            Me.tblconsultadet.ColumnFooters = True
            Me.tblconsultadet.Columns(1).FooterText = "# Registros"
            Me.tblconsultadet.Columns(2).FooterText = tblconsultadet.RowCount.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TraerCabeceraSireVentas()
        Vista = objSql.TraerDataTable("Spu_Con_Trae_CabImporTempSireVentas", gbcodempresa, gbano, gbmes).DefaultView
        tblconsulta.SetDataBinding(Vista, Nothing, True)
        Me.tblconsulta.Columns(0).FooterText = "# Registros"
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub Frm_ImportarSIRE_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.Centrar(Me)
            tblhelp.Visible = False
            TraerCabeceraSireVentas()
            TraerImportacionVentas()


            'If tblconsultadet.RowCount > 0 Then
            '    'COMPARADOR SIRE
            '    Trae_SireVsRegVentasIGUAL()
            '    Trae_SireVsRegVentasIGUALCONDIFF()
            '    Trae_SireVsRegVentasSIRESI_VentasNO()
            '    Trae_SireVsRegVentasSI_SIRENO()
            '    'END COMPARADOR SIRE

            'End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Trae_SireVsRegVentasIGUAL()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegVentas", gbcodempresa, gbano, gbmes, "IGUAL").DefaultView
            tblconsultaiguales.SetDataBinding(Vista, Nothing, True)
            Me.capturarfilaactual()
            tblconsultaiguales.ColumnFooters = True
            Dim nombreColumnaBuscada As String = "Fecha"
            Dim nombreColumnaBuscada2 As String = "regvenMes"
            Dim numeroColumna As Integer = -1


            Me.tblconsultaiguales.Columns("Libro").FooterText = "#Registros"
            Me.tblconsultaiguales.Columns("Voucher").FooterText = tblconsultaiguales.RowCount.ToString
        Catch ex As Exception

        End Try



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
            Vista = objSql.TraerDataTable("sp_Con_Help_Libros_Por_Tipo", gbcodempresa, gbano, "ccb02cod", "*", "V").DefaultView
            tblhelp.SetDataBinding(Vista, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Trae_SireVsRegVentasIGUALCONDIFF()

        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegVentas", gbcodempresa, gbano, gbmes, "IGUAl_CON_DIF").DefaultView
            tblconsulta_igualcondatodiff.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            tblconsulta_igualcondatodiff.ColumnFooters = True

            Me.tblconsulta_igualcondatodiff.Columns("Observacion").FooterText = "# Registros"
            Me.tblconsulta_igualcondatodiff.Columns("Libro").FooterText = tblconsulta_igualcondatodiff.RowCount.ToString

        Catch ex As Exception

        End Try




    End Sub
    Private Sub Trae_SireVsRegVentasSIRESI_VentasNO()

        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegVentas", gbcodempresa, gbano, gbmes, "SIRESI_VENTASNO").DefaultView
            tblconsulta_SisireNoRegistroV.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            'Dim nombreColumnaBuscada As String = "Fecha"
            'Dim numeroColumna As Integer = -1
            'For i As Integer = 0 To tblconsulta_SisireNoRegistroV.Columns.Count - 1
            '    ' Verificar si el nombre de la columna actual coincide con el nombre buscado
            '    If tblconsulta_SisireNoRegistroV.Columns(i).Caption = nombreColumnaBuscada Then
            '        ' Si se encuentra la columna, almacenar su número de columna y salir del bucle

            '        numeroColumna = i
            '        MessageBox.Show("Fecha" + numeroColumna.ToString)
            '        Me.tblconsulta_SisireNoRegistroV.Columns(numeroColumna).FooterText = "#Registros"

            '        Exit For

            '    End If


            'Next
            tblconsulta_SisireNoRegistroV.ColumnFooters = True
            Me.tblconsulta_SisireNoRegistroV.Columns("SireRuc").FooterText = "# Registros"
            Me.tblconsulta_SisireNoRegistroV.Columns("SireRazon_Social").FooterText = tblconsulta_SisireNoRegistroV.RowCount.ToString
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Trae_SireVsRegVentasSI_SIRENO()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegVentas", gbcodempresa, gbano, gbmes, "VENTASSI_SIRENO").DefaultView
            tblconsulta_SiregistroVNOsire.SetDataBinding(Vista, Nothing, True)

            Me.capturarfilaactual()
            Dim nombreColumnaBuscada As String = "MES"
            Dim numeroColumna As Integer = -1


            tblconsulta_SiregistroVNOsire.ColumnFooters = True

            Me.tblconsulta_SiregistroVNOsire.Columns("Libro").FooterText = "#Registros"
            Me.tblconsulta_SiregistroVNOsire.Columns("Voucher").FooterText = tblconsulta_SiregistroVNOsire.RowCount.ToString
        Catch ex As Exception

        End Try



    End Sub
    Private Sub LlenarSireConRegVentas()
        Dim Libro As String = txtLibro.Text
        Vista = objSql.TraerDataTable("Spu_Con_Trae_ComparaRegVenVsSire", gbcodempresa, gbano, gbmes, Libro).DefaultView
        tblconsulta_SiregistroVNOsire.SetDataBinding(Vista, Nothing, True)

    End Sub



    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim periodo As String = gbano + gbmes
        Dim z As DataTable = objSql.TraerDataTable("Spu_Con_Trae_ImporTempSireVentas", gbcodempresa, gbano, gbmes, gbNameUser)
        tblconsultadet.DataSource = z
    End Sub

    Private Sub btnComparar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComparar.Click
        Try
            If tblconsultadet.RowCount = 0 Then
                MessageBox.Show("ERROR :: No se ha importado datos para el Registro de Ventas, vuelva a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                If txtLibro.Text = "" Then
                    MessageBox.Show("ERROR :: Es obligatorio seleccionar un libro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                ' compara o llena las tablas con los 4 estados 
                LlenarSireConRegVentas()
                'treas las comparaciones

                Trae_SireVsRegVentasIGUAL()
                Trae_SireVsRegVentasIGUALCONDIFF()
                Trae_SireVsRegVentasSI_SIRENO()
                Trae_SireVsRegVentasSIRESI_VentasNO()

            End If
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

    Private Sub tblconsulta_AfterFilter(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs)
        Me.tblconsulta.Columns(0).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarVentas.Click

        If txtLibro.Text = "" Then
            MessageBox.Show("ERROR :: Es obligatorio seleccionar un libro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            ExportarVentas()
        End If



    End Sub
    Private Sub ExportarVentas()
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
            dt = objSql.TraerDataSet("Spu_Con_Trae_SireVentasAnexo03", gbcodempresa, gbano, gbmes, txtLibro.Text)
            If dt.Tables.Count > 0 Then


                nombredearchivo = "LE" + dt.Tables(0).Rows(0)("ruc") + dt.Tables(0).Rows(0)("Periodo") + "0014040002" + "1" + "1" + "1" + "2"
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

            Dim archivoZip As String = selectedFolder + "\" + nombredearchivo + ".zip"
            Using sw As StreamWriter = New StreamWriter(FilePath)

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("RUC").ToString
                    campo_02 = dr("ID").ToString
                    campo_03 = dr("Periodo").ToString
                    campo_04 = dr("CAR_SUNAT").ToString
                    campo_05 = dr("Fecha_Emision").ToString
                    campo_06 = dr("Fecha_Vcto").ToString
                    campo_07 = dr("Tipo_CP").ToString
                    campo_08 = dr("Serie_CP").ToString
                    campo_09 = dr("Nro_CP").ToString
                    campo_10 = dr("Nro_Final").ToString
                    campo_11 = dr("TipoDoc_Cliente").ToString
                    campo_12 = dr("NroDocIdentidad").ToString
                    campo_13 = dr("Razon_Social").ToString
                    campo_14 = dr("Valor_Factor_Exportacion").ToString
                    campo_15 = dr("BI_Gravada").ToString
                    campo_16 = dr("Dscto_BI").ToString
                    campo_17 = dr("IGV_IPM").ToString
                    campo_18 = dr("Dscto_IGV_IPM").ToString
                    campo_19 = dr("Mto_Exonerado").ToString
                    campo_20 = dr("Mto_Inafecto").ToString
                    campo_21 = dr("ISC").ToString
                    campo_22 = dr("BI_Grav_IVAP").ToString
                    campo_23 = dr("IVAP").ToString
                    campo_24 = dr("ICBPER").ToString
                    campo_25 = dr("Otros_Atributos").ToString
                    campo_26 = dr("Total_CP").ToString
                    campo_27 = dr("Moneda").ToString
                    campo_28 = dr("Tipo_Cambio").ToString
                    campo_29 = dr("FechaEmision_Modificado").ToString
                    campo_30 = dr("TipoCP_Modificado").ToString
                    campo_31 = dr("SerieCP_Modificado").ToString
                    campo_32 = dr("NroCP_Modificado").ToString
                    campo_33 = dr("ID_PROYECTO").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) & campo_16 & Chr(124) & campo_17 & Chr(124) & campo_18 & Chr(124) & campo_19 & Chr(124) & campo_20 & Chr(124) & campo_21 & Chr(124) & campo_22 & Chr(124) & campo_23 & Chr(124) & campo_24 & Chr(124) & campo_25 & Chr(124) & campo_26 & Chr(124) & campo_27 & Chr(124) & campo_28 & Chr(124) & campo_29 & Chr(124) & campo_30 & Chr(124) & campo_31 & Chr(124) & campo_32 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)

                Next

                'Meter el txt al zip


                'END Meter el txt al zip


                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor
            Using zip As New ZipFile()
                zip.AddFile(FilePath, "")
                zip.Save(archivoZip)
            End Using
            MessageBox.Show("El archivo se genero con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar la exportacion de Ventas")
            Return
        End Try

    End Sub


    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


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

            Dim fileName As String = "MineraDeisi_sire_" + gbano + gbmes + "siredifVentas" + ".xlsx"
            Dim tempPath As String = Path.GetTempPath()
            Dim filePath As String = Path.Combine(tempPath, fileName)


            Dim saveFileDialog As New SaveFileDialog()
            'NOMBRE ARCHIVO
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            saveFileDialog.FileName = gbano + gbmes + "_Sire_VentasDiff" + ".xlsx"
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

            Process.Start("excel.exe", filePath)
        Catch ex As Exception
            MessageBox.Show("No se pudo exportar los datos")
        End Try
    End Sub

    Private Sub BtnExportarSire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarSire.Click
        Try
            If tblconsulta_SisireNoRegistroV.RowCount = 0 Then
                Return
            End If
            Dim excelApp As New Excel.Application()
            Dim save As Excel.Workbook = excelApp.Workbooks.Add()
            Dim dt As Excel.Worksheet = save.Sheets(1)

            ' Obtener el C1TrueDBGrid
            Dim grid As C1TrueDBGrid = tblconsulta_SisireNoRegistroV

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

            Dim fileName As String = "MineraDeisi_sire_" + gbano + gbmes + "RegistroSIRE" + ".xlsx"
            Dim tempPath As String = Path.GetTempPath()
            Dim filePath As String = Path.Combine(tempPath, fileName)


            Dim saveFileDialog As New SaveFileDialog()
            'If saveFileDialog.ShowDialog() = DialogResult.OK Then

            'Dim FilePath As String = Path.Combine(selectedFolder, NombreArchivo)
            save.SaveAs(filePath)

            MessageBox.Show("Datos exportados correctamente a Excel.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    Return
            'End If

            '' Cerrar Excel
            excelApp.Quit()

            Process.Start("excel.exe", filePath)
        Catch ex As Exception
            MessageBox.Show("No se pudo exportar los datos")
        End Try
    End Sub

    Private Sub BtnExportarRegVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarRegVentas.Click
        Try
            If tblconsulta_SiregistroVNOsire.RowCount = 0 Then
                Return
            End If
            Dim excelApp As New Excel.Application()
            Dim save As Excel.Workbook = excelApp.Workbooks.Add()
            Dim dt As Excel.Worksheet = save.Sheets(1)

            ' Obtener el C1TrueDBGrid
            Dim grid As C1TrueDBGrid = tblconsulta_SiregistroVNOsire


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

            Dim fileName As String = "MineraDeisi_sire_" + gbano + gbmes + "RegistroVentas" + ".xlsx"
            Dim tempPath As String = Path.GetTempPath()
            Dim filePath As String = Path.Combine(tempPath, fileName)


            Dim saveFileDialog As New SaveFileDialog()
            'If saveFileDialog.ShowDialog() = DialogResult.OK Then

            'Dim FilePath As String = Path.Combine(selectedFolder, NombreArchivo)
            save.SaveAs(filePath)

            MessageBox.Show("Datos exportados correctamente a Excel.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    Return
            'End If

            '' Cerrar Excel
            excelApp.Quit()

            Process.Start("excel.exe", filePath)
        Catch ex As Exception
            MessageBox.Show("No se pudo exportar los datos")
        End Try
    End Sub

    Private Sub BtnRegistrarSire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistrarSire.Click
        Try
            If tblconsulta_SisireNoRegistroV.RowCount = 0 Then
                Return
            End If

            Dim Frm_RegistrarVentas As New Frm_RegistrarVentas
            'Frm_RegistrarCompras.p_accionMante = "N"
            Frm_RegistrarVentas.Owner = Me
            Frm_RegistrarVentas.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Frm_ImportarSIRE_VentasPrincipal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                If tblhelp.Visible = True Then
                    tblhelp.Visible = False
                End If

            End If
        Catch ex As Exception

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
        Dim objR As New Ks.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of Ks.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim nombreper As String
        Dim paginasini As Double = 0
        Try
            nombreper = "PERIODO : " + gbano + "-" + gbmes
            'Validaciones
            If txtLibro.Text = "" Or txtLibro.Text = "???" Then Beep() : MessageBox.Show("Libro de ventas no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtLibro.Focus() : Exit Sub
            'If Not IsNumeric(txtPagina.Text) Then Beep() : MessageBox.Show("Número de Página es no válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPagina.Focus() : Exit Sub

            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            nombredereporte = "RegVenta_a3.Rpt"
            '
            ds = objSql.TraerDataSet("sp_Con_Rep_RegistroVentas", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, gbmoneda).Copy()

            'Formulas de reporte
            '  paginasini = CType(txtPagina.Text, Double)
            'Formulas de reporte
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Pagina", 1))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Moneda", gbmoneda))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            '
            'Visualizar reportes
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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