Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_RegistroRetencionLib41

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim VistaHelp As DataView
    Dim filaactual As Integer
#Region "Base de Datos"
    Private Sub TraerCtaCte(ByVal tipoanlisis As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Cuentas_Corrientes_New", gbcodempresa, tipoanlisis, "ccm02cod", "*", "*").DefaultView
            '  tblconsulta.SetDataBinding(Vista, Nothing, True)
            ' Me.tblconsulta.Columns(0).FooterText = "# Registros"
            ' Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerTipoAnalis(ByVal cbo As ComboBox)
        Try
            cbo.DataSource = objSql.TraerDataTable("sp_Con_Trae_Tipos_Analisis", gbcodempresa, "ccb17cdgo ASC").DefaultView
            cbo.DisplayMember = "ccb17desc"
            cbo.ValueMember = "ccb17cdgo"
            'Poner el valor de combo en el mes 
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String
        Dim flagopcionreporte As String
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesdelibrocaja As String

        ' mesdelibrocaja = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "LIBCAJA"
            'Inserto los valores selecioandos
            ' If tblconsulta.SelectedRows.Count > 0 Then
            'Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            ' Else
            ' MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            ' End If

            nombredereporte = "LibCaja.Rpt"
            ' flagopcionreporte = If(optTipoImpre_0.Checked = True, "1", "2")
            ' mesdelibrocaja = If(optTipoImpre_0.Checked = True, mesdelibrocaja, mesdelibrocaja.Substring(4, 2))
            'Sp que trae datoas del reporte
            '   ds = objSql.TraerDataSet("sp_Con_Rep_LibroCaja", gbcodempresa, gbano, mesdelibrocaja, gbmoneda, gbNameUser, flagopcionreporte, mskFecIni.Text, mskFecFin.Text).Copy()
            'Formulas de reporte
            Dim monedaMay As String
            monedaMay = If(gbmoneda = "S", "Nuevos Soles", If(gbmoneda = "D", "Dolares", "Dolar Promedio")) & "'"

            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            '   arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))

            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If

            'Elimnar rango de impresion
            Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objR = Nothing
        End Try
    End Sub
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesdeRegRetencion As String
        Dim flagtipoimpresion As String
        Dim tipanlisiregretencion As String

        ' mesdeRegRetencion = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
        'LLeno el rango de valores
        Try

            Rutareporte = gbRutaReportes

            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "REGRET1"
            'Inserto los valores selecioandos
            'If tblconsulta.SelectedRows.Count > 0 Then
            '    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            'Else
            '    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            'End If


            nombredereporte = "Rpt_LibInvBal41Art34.Rpt"


            ' flagtipoimpresion = If(optTipoImpre_0.Checked = True, "P", "F")
            '   tipanlisiregretencion = cboTipoAnalisi.SelectedValue.ToString

            ds = objSql.TraerDataSet("Spu_Con_Rep_RegistroRetenciones", gbcodempresa, gbano, gbmes).Copy()



            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            ' arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", "4 Estructura del Libro de Retenciones inciso e) y f) del Art. 34° de la LIR"))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + gbmes))
            ' arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Pagina", ""))



            'Visualizar reportes
            'If flagimpresion = "P" Then
            '    objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            'Else
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            'End If

            'Elimnar rango de impresion
            '  Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub Frm_RegistroRetencion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Registro de comprobantes de retencion"
            '
            ' Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnexportar, "Genera archivo para PDT")
            '  Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            '
            ' Me.TraerTipoAnalis(cboTipoAnalisi)
            ' cboTipoAnalisi.SelectedIndex = 0
            '
            ' Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)

            'Llena combo 
            '  ' Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
            'cboperiodos.SelectedIndex = CType(gbmes, Integer)
            '
            '  mskFecIni.Text = "01" & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano
            ' mskFecFin.Text = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs)
        '  Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub cboTipoAnalisi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '   Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        '   Me.ExportarArchivo()
        Me.ExportarLibro41RetencionesINVBAL()
    End Sub
    Private Sub ExportarLibro41RetencionesINVBAL()
        Dim folderBrowserDialog1 As New FolderBrowserDialog()
        folderBrowserDialog1.Description = "Seleccionar Carpeta para Guardar Archivos"
        folderBrowserDialog1.ShowNewFolderButton = True
        If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim folderPath As String = folderBrowserDialog1.SelectedPath

        Else
            Return

        End If
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_RegistroRetenciones", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            '  Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("040100", gbRucEmpresa, gbano, gbmes, dia, "01", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Unico_Operacion").ToString
                    campo_03 = dr("ProveedorDocCorrelativo").ToString
                    campo_04 = dr("RetencionFecha").ToString
                    campo_05 = dr("ProveedorDocTipo").ToString
                    campo_06 = dr("ProveedorDocNro").ToString
                    campo_07 = dr("ProveedorDescripcion").ToString
                    campo_08 = dr("ProveedorDocImportePagado").ToString
                    campo_09 = dr("ProveedorDocImporteRetenido").ToString
                    campo_10 = dr("EstadoOperacion").ToString




                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            MsgBox("EXITO:: El archivo se exportó correctamente", MsgBoxStyle.Information)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 4.1 Retenciones")
            Return
        End Try

    End Sub
    Private Sub ExportarArchivo()
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim ds As New DataSet

        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Try
            nombredearchivo = "0626" + gbRucEmpresa + gbano + gbmes + ".txt"
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.FileName = nombredearchivo
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                myStream = saveFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    'Code to write the stream goes here.
                    nombredearchivo = CType(myStream, System.IO.FileStream).Name
                    myStream.Close()
                End If
            End If


            Dim FilePath As String

            FilePath = nombredearchivo

            'Se abre el archivo y si este no existe se crea
            strStreamW = File.OpenWrite(FilePath)
            strStreamWriter = New StreamWriter(strStreamW, _
            System.Text.Encoding.ASCII)

            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            '======Traer los datos
            Dim dt As New DataSet
            dt = objSql.TraerDataSet("Sp_Con_Trae_DatosRetencionesPDT", gbcodempresa, gbano, gbmes)


            Dim RucProveedor As String = ""
            Dim RazonSocial As String = ""
            Dim ApePaterno As String = ""
            Dim ApeMaterno As String = ""
            Dim Nombres As String = ""
            Dim SerieCompRet As String = ""
            Dim NumCompRet As String = ""
            Dim FecCompRet As String = ""
            Dim MontoPagCompRet As String = ""
            Dim TipoCompPago As String = ""
            Dim SerieCompPago As String = ""
            Dim NumCompPago As String = ""
            Dim FecCompPago As String = ""
            Dim TotalCompPago As String = ""

            Dim dr As DataRow

            For Each dr In dt.Tables(0).Rows
                'Obtenemos los datos del dataset
                RucProveedor = dr("RucProveedor").ToString
                RazonSocial = dr("RazonSocial").ToString
                ApePaterno = dr("ApePaterno").ToString
                ApeMaterno = dr("ApeMaterno").ToString
                Nombres = dr("Nombres").ToString
                SerieCompRet = dr("SerieCompRet").ToString
                NumCompRet = dr("NumCompRet").ToString
                FecCompRet = dr("FecCompRet").ToString
                FecCompRet = CStr(CDate(FecCompRet).ToString("dd/MM/yyyy"))
                MontoPagCompRet = dr("MontoPagCompRet").ToString
                TipoCompPago = dr("TipoCompPago").ToString
                SerieCompPago = dr("SerieCompPago").ToString
                NumCompPago = dr("NumCompPago").ToString
                FecCompPago = dr("FecCompPago").ToString
                FecCompPago = CStr(CDate(FecCompPago).ToString("dd/MM/yyyy"))
                TotalCompPago = dr("TotalCompPago").ToString

                If Funciones.Funciones.izquierda(RucProveedor, 2) = "10" Then
                    RazonSocial = ""
                End If
                Dim linea As String = ""

                linea = RucProveedor & Chr(124) & RazonSocial & Chr(124) & ApePaterno & Chr(124) & _
                ApeMaterno & Chr(124) & Nombres & Chr(124) & SerieCompRet & Chr(124) & NumCompRet & Chr(124) & _
                FecCompRet & Chr(124) & MontoPagCompRet & Chr(124) & TipoCompPago & Chr(124) & SerieCompPago & Chr(124) & _
                NumCompPago & Chr(124) & FecCompPago & Chr(124) & TotalCompPago & Chr(124)


                'Escribimos la línea en el achivo de texto
                strStreamWriter.WriteLine(linea)

            Next

            strStreamWriter.Close()
            MessageBox.Show("El archivo se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Try


            Me.TraerAyuda(0, btnhelp_0)
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
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Por_Tipo", gbcodempresa, gbano, "ccb02cod", "", "T").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        Try
            If tblhelp.Visible = True Then
                If e.KeyCode = Keys.Escape Then
                    tblhelp.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tblhelp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.DoubleClick
        Try
            AsignarAyuda(2, tblhelp)
        Catch ex As Exception

        End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim RowIndex As Integer
        Try
            ' RowIndex = tblconsulta.Row
            Select Case indice
                'Case 0
                '    'CONCEPTO
                '    tblconsulta(RowIndex, "Concepto") = tblhelp_p.Columns("CO07DESCRIPCION").Value.ToString
                '    tblconsulta(RowIndex, "Asiento_Tipo") = tblhelp_p.Columns("CO07ASIENTOTIPOCOD").Value.ToString
                '    tblconsulta(RowIndex, "Desc_asiento_tip") = tblhelp_p.Columns("ccc03des").Value.ToString
                '    tblconsulta(RowIndex, "Libro") = tblhelp_p.Columns("ccc03lib").Value.ToString
                '    tblconsulta(RowIndex, "Nro_Voucher") = tblhelp_p.Columns("CO07NOMENCLATURA").Value.ToString

                '    tblconsulta(RowIndex, "ccc01subd") = tblhelp_p.Columns("ccc03lib").Value.ToString ' Libro
                '    tblconsulta(RowIndex, "ccc01deta") = tblhelp_p.Columns("CO07DESCRIPCION").Value.ToString ' Concepto


                '    ' txtLibro.Focus()
                'Case 1
                '    'CENTRO COSTO
                '    tblconsulta(RowIndex, "Centro_Costo") = tblhelp_p.Columns("ccb02cod").Value.ToString
                '    ' tblconsulta(RowIndex, 27) = tblhelp_p.Columns("ccb02des").Value.ToString
                '    ' txtLibro.Focus()
                Case 2
                    'ASIENTO TIPO

                    txtLibro.Text = tblhelp.Columns("Código").Value.ToString()
                    lblhelp_0.Text = tblhelp.Columns("Descripción").Value.ToString()

            End Select

            Vista.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub optTipoImpre_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cboperiodos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub optTipoImpre_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub mskFecFin_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub
    Private Sub mskFecIni_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class