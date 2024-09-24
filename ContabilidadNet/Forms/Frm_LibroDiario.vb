Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_LibroDiario

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#Region "Procedimientos"


    Private Sub ExportarArchivo()
        '
        Dim FlagtieneRegistros As String
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim ds As New DataSet
        Dim flagtiporeporte As String = ""
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_LibDiarioPLE", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==


        nombredearchivo = Funciones.Funciones.NombreLibroelectronico("050100", gbRucEmpresa, gbano, gbmes, "", "", FlagtieneRegistros, "S")
        '60100:  LERRRRRRRRRRRAAAAMM0006010000OIM1.TXT()



        Try
            nombredearchivo = nombredearchivo + ".txt"
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
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""
            Dim campo_13 As String = ""
            Dim campo_14 As String = ""
            Dim campo_15 As String = ""
            Dim campo_16 As String = ""
            Dim campo_17 As String = ""
            Dim campo_18 As String = ""
            Dim campo_19 As String = ""
            Dim campo_20 As String = ""
            Dim campo_21 As String = ""



            Dim dr As DataRow

            For Each dr In dt.Tables(0).Rows
                'Obtenemos los datos del dataset
                campo_01 = dr("Periodo").ToString
                campo_02 = dr("Correlativo").ToString
                campo_03 = dr("NumcorrelativoAsicont").ToString
                campo_04 = dr("ccd01cta").ToString
                campo_05 = dr("CodigoUnidadOperacion").ToString
                campo_06 = dr("CodigoCentroCosto").ToString
                campo_07 = dr("MonedaTipo").ToString

                campo_08 = dr("TipoDocumentoEmisor").ToString
                campo_09 = dr("NumeroDocumentoEmisor").ToString
                campo_10 = dr("TipDocAsociadoOperacion").ToString
                campo_11 = dr("TipDocAsociadoOperacionSerie").ToString
                campo_12 = dr("TipDocAsociadoOperacionNumero").ToString
                campo_13 = dr("FechaContable").ToString
                campo_14 = dr("FechaVencimiento").ToString
                campo_15 = dr("FechaOperacion").ToString

                campo_16 = dr("ccd01con").ToString
                campo_17 = dr("GlosaReferencial").ToString
                campo_18 = dr("SaldoDeudor").ToString
                campo_19 = dr("SaldoAcreedor").ToString
                campo_20 = dr("DatoEstructurado").ToString
                campo_21 = dr("estadooperacion").ToString

                Dim linea As String = ""
                linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & _
                campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & _
                campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) & _
                campo_16 & Chr(124) & campo_17 & Chr(124) & campo_18 & Chr(124) & campo_19 & Chr(124) & _
                campo_20 & Chr(124) & campo_21 & Chr(124)


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

    Private Sub ExportarArchivoPlaCtas()
        '
        Dim FlagtieneRegistros As String
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim ds As New DataSet
        Dim flagtiporeporte As String = ""
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Trae_PlactasLibroElec", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==


        nombredearchivo = Funciones.Funciones.NombreLibroelectronico("050300", gbRucEmpresa, gbano, gbmes, "", "", FlagtieneRegistros, "S")
        '60100:  LERRRRRRRRRRRAAAAMM0006010000OIM1.TXT()
        Try
            nombredearchivo = nombredearchivo + ".txt"
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
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""



            Dim dr As DataRow

            For Each dr In dt.Tables(0).Rows
                'Obtenemos los datos del dataset
                campo_01 = dr("Periodo").ToString
                campo_02 = dr("Cuenta_codigo").ToString
                campo_03 = dr("Cuenta_descripcion").ToString
                campo_04 = dr("plancuenta_codigo").ToString
                campo_05 = dr("plancuenta_descripcion").ToString
                campo_06 = dr("CuentaContableCorporativaCodigo").ToString
                campo_07 = dr("CuentaContableCorporativaDescripcion").ToString
                campo_08 = dr("Estado_operacion").ToString


                Dim linea As String = ""

                linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & _
                campo_07 & Chr(124) & campo_08 & Chr(124)

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
#End Region
    Private Sub Traectaslibrodiario()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim flagopcionreporte As String
        Dim nombredereporte As String = ""
        Dim Rutareporte As String
        Dim mesdelibrodiario As String

        mesdelibrodiario = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor
            '========================================
            If RbtTipoReporte_0.Checked = True Then
                flagtiporeporte = "LIBDIARI"
                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            ElseIf rbtTipoReporte_1.Checked = True Then
                flagtiporeporte = "RESDIARI"
                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            End If

            flagopcionreporte = If(optTipoImpre_0.Checked = True, "1", "2")
            '========================================
            If RbtTipoReporte_0.Checked = True Then
                nombredereporte = "libdiari.Rpt"
                'Sp que trae datos del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_LibroDiario", gbcodempresa, gbano, mesdelibrodiario, gbmoneda, gbNameUser, flagopcionreporte, mskFecIni.Text, mskFecFin.Text).Copy()
                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Rango", gbmoneda))

            ElseIf rbtTipoReporte_1.Checked = True Then
                nombredereporte = "libdiariRes.Rpt"
                'Sp que trae datos del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_DiarioResumen", gbcodempresa, gbano, mesdelibrodiario, gbmoneda, TxtNivel.Text.Trim, gbNameUser).Copy()
                '

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbmoneda))
                If optTipoImpre_1.Checked = True Then
                    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("opciontitulo", "1"))
                Else
                    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("opciontitulo", "0"))
                End If
            ElseIf RbtTipoReporte_2.Checked = True Then
                nombredereporte = "Rpt_LibDiario.Rpt"
                'Sp que trae datos del reporte
                ds = objSql.TraerDataSet("Spu_Con_Rep_LibDiario", gbcodempresa, gbano, mesdelibrodiario).Copy()
                '
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("monedacontabilidad", gbmoneda))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Ruc", gbRucEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
            End If
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
        Dim flagtiporeporte As String = ""
        Dim flagopcionreporte As String
        Dim nombredereporte As String = ""
        Dim Rutareporte As String
        Dim mesdelibrodiario As String

        mesdelibrodiario = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor
            '========================================
            If RbtTipoReporte_0.Checked = True Then
                flagtiporeporte = "LIBDIARI"
                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            ElseIf rbtTipoReporte_1.Checked = True Then
                flagtiporeporte = "RESDIARI"
                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
            End If

            flagopcionreporte = If(optTipoImpre_0.Checked = True, "1", "2")

            '========================================
            If RbtTipoReporte_0.Checked = True Then
                nombredereporte = "libdiari.Rpt"
                ds = objSql.TraerDataSet("sp_Con_Rep_LibroDiario", gbcodempresa, gbano, mesdelibrodiario, gbmoneda, gbNameUser, flagopcionreporte, mskFecIni.Text, mskFecFin.Text).Copy()

                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Rango", gbmoneda))
            ElseIf rbtTipoReporte_1.Checked = True Then
                nombredereporte = "libdiariRes.Rpt"
                ds = objSql.TraerDataSet("sp_Con_Rep_DiarioResumen", gbcodempresa, gbano, mesdelibrodiario, gbmoneda, TxtNivel.Text.Trim, gbNameUser).Copy()

                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))


                If optTipoImpre_1.Checked = True Then
                    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("opciontitulo", "1"))
                Else
                    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("opciontitulo", "0"))
                End If



            ElseIf RbtTipoReporte_2.Checked = True Then
                nombredereporte = "Rpt_LibDiario.Rpt"
                'Sp que trae datos del reporte
                ds = objSql.TraerDataSet("Spu_Con_Rep_LibDiario", gbcodempresa, gbano, mesdelibrodiario).Copy()
                '
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("monedacontabilidad", gbmoneda))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Ruc", gbRucEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))

                nombredereporte = "Rpt_LibDiario.Rpt"

            End If
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
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub Frm_LibroDiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Text = "Libro diario"
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Me.Traectaslibrodiario()
            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)

            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnexportar, "Exportar  5.1 Libro diario y 5.3 Libro Diario- Detalle Plan Cuentas")

            cboperiodos.SelectedIndex = CType(gbmes, Integer)
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            mskFecIni.Text = "01" & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano
            mskFecFin.Text = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano

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
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        'LIbro  Diario
        Me.ExportarArchivo()
        'Plan de cuentas
        Me.ExportarArchivoPlaCtas()
    End Sub
End Class