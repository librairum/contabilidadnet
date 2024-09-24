Imports System.IO
Public Class Frm_Voucher_Importar
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
    Private Sub ValidarImpVoucher()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ValImpVoucher", gbcodempresa, gbano, gbmes, gbNameUser, "IV").DefaultView
            tblvalidacion.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '
            Me.tblvalidacion.Columns(0).FooterText = "# Registros"
            Me.tblvalidacion.Columns(1).FooterText = tblvalidacion.RowCount.ToString

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
        Dim openFD As New OpenFileDialog()
        Dim FilePath As String
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim myStream As Stream

        'Declarar campos
        Dim Tipo As String
        Dim Anio As String
        Dim mes As String
        Dim libro As String
        Dim nrovoucher As String
        Dim fecha As String
        Dim glosa As String
        Dim comprobante As String
        Dim tip_cambio As String
        Dim ctaCble As String
        Dim moneda As String
        Dim debe As String
        Dim haber As String
        Dim cargo As String
        Dim abono As String
        Dim ctacte_tipo As String
        Dim ctacte_ruc As String
        Dim docu_tipo As String
        Dim docu_nro As String
        Dim columnarcyrv As String

        Dim cTexto As String
        Dim NCampo As Integer
        Dim nRegistro As Integer


        Dim Posicionseparador_fin As Int16
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
        End If

        FilePath = nombredearchivo
        If nombredearchivo = "" Then Exit Sub
        Dim objReader As New StreamReader(FilePath)
        'Se abre el archivo y si este no existe se crea
        'strStreamW = File.OpenWrite(FilePath)
        'strStreamWriter = New StreamWriter(strStreamW, _
        'System.Text.Encoding.ASCII)


        'Eliminar filas insertadas
        b = objSql.Ejecutar2("Spu_Con_Del_Voucher_importar", gbcodempresa, gbNameUser)

        Try
            Cursor.Current = Cursors.WaitCursor

            nRegistro = 0
            Do
                sLine = objReader.ReadLine()

                If Not sLine Is Nothing Then
                    'arrText.Add(sLine)
                    NCampo = 1
                    cTexto = sLine

                    'Iniciar Variables
                    Tipo = ""
                    Anio = ""
                    mes = ""
                    libro = ""
                    nrovoucher = ""
                    fecha = ""

                    glosa = ""
                    comprobante = ""
                    tip_cambio = "1"
                    ctaCble = ""
                    moneda = ""
                    debe = "0"
                    haber = "0"
                    cargo = "0"
                    abono = "0"
                    ctacte_tipo = ""
                    docu_nro = ""
                    docu_tipo = ""
                    ctacte_ruc = ""

                    '"C|2012|05|01|BD001|10/05/2012|Prueba ||||||||||||"	String

                    'Pasar la linea al texto
                    cTexto = sLine
                    '
                    While cTexto.IndexOf("|") >= 0

                        Posicionseparador_fin = cTexto.IndexOf("|")

                        If NCampo = 1 Then
                            Tipo = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If


                        If NCampo = 2 Then
                            Anio = cTexto.Substring(0, Posicionseparador_fin).Trim()

                        End If

                        If NCampo = 3 Then
                            mes = cTexto.Substring(0, Posicionseparador_fin).Trim()

                        End If

                        If NCampo = 4 Then
                            libro = cTexto.Substring(0, Posicionseparador_fin).Trim()

                        End If


                        If NCampo = 5 Then
                            nrovoucher = cTexto.Substring(0, Posicionseparador_fin).Trim()

                        End If

                        If NCampo = 6 Then
                            fecha = cTexto.Substring(0, Posicionseparador_fin).Trim()
                            fecha = IIf(IsDate(fecha) = False, "Null", fecha)
                        End If



                        If NCampo = 7 Then
                            glosa = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If

                        If NCampo = 8 Then
                            comprobante = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If


                        If NCampo = 9 Then
                            tip_cambio = cTexto.Substring(0, Posicionseparador_fin).Trim()
                            tip_cambio = IIf(tip_cambio = "", "0", tip_cambio)
                        End If

                        If NCampo = 10 Then
                            ctaCble = cTexto.Substring(0, Posicionseparador_fin).Trim()

                        End If

                        If NCampo = 11 Then
                            moneda = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If

                        If NCampo = 12 Then
                            debe = cTexto.Substring(0, Posicionseparador_fin).Trim()
                            debe = IIf(debe = "", "0", debe)
                        End If

                        If NCampo = 13 Then
                            haber = cTexto.Substring(0, Posicionseparador_fin).Trim()
                            haber = IIf(haber = "", "0", haber)
                        End If

                        If NCampo = 14 Then
                            cargo = cTexto.Substring(0, Posicionseparador_fin).Trim()
                            cargo = IIf(cargo = "", "0", cargo)
                        End If
                        If NCampo = 15 Then
                            abono = cTexto.Substring(0, Posicionseparador_fin).Trim()
                            abono = IIf(abono = "", "0", abono)
                        End If
                        If NCampo = 16 Then
                            ctacte_tipo = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If
                        If NCampo = 17 Then
                            ctacte_ruc = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If

                        If NCampo = 18 Then
                            docu_tipo = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If

                        If NCampo = 19 Then
                            docu_nro = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If

                        If NCampo = 20 Then
                            columnarcyrv = cTexto.Substring(0, Posicionseparador_fin).Trim()
                        End If

                        cTexto = cTexto.Substring(Posicionseparador_fin + 1, cTexto.Length - (Posicionseparador_fin + 1))

                        NCampo = NCampo + 1
                    End While
                    'Incremento el nro de regsitros
                    nRegistro = nRegistro + 1
                    'Inseto regsitros

                    a = objSql.Ejecutar2("Spu_Con_Ins_Voucher_importar", nRegistro, gbcodempresa, Anio, mes, libro, nrovoucher, Tipo, fecha, glosa, comprobante, tip_cambio, ctaCble, moneda, debe, haber, cargo, abono, ctacte_tipo, ctacte_ruc, docu_tipo, docu_nro, columnarcyrv, gbNameUser, "")
                    'If Funciones.Funciones.MensajesdelSQl(a) = False Then
                    'MessageBox.Show("OK :: Se importaron ")
                    'End If
                End If
            Loop Until sLine Is Nothing
            'Cierro
            objReader.Close()

            'Muestro mensaje
            MessageBox.Show("OK :: Se importaron " + nRegistro.ToString() + "   Registros   ")

            'Trae datos insertados
            Me.traeImportacion()
            '
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Me.ImportarArchivo()
    End Sub
    Private Sub btnvalidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvalidar.Click
        Me.ValidarImpVoucher()
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'Validar los datos ue se importo
            Me.ValidarImpVoucher()
            '
            If tblvalidacion.RowCount > 0 Then
                MsgBox("Corriga las validaciones de la importacion") : Exit Sub
            End If


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

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Frm_Voucher_Importar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class