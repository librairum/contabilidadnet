Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_LibroMayor

    Dim Vista As New DataView
    Dim Vista1 As New DataView
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

        dt = objSql.TraerDataSet("Sp_Con_Rep_LibroMayorAnaliticoPLE", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==


        nombredearchivo = Funciones.Funciones.NombreLibroelectronico("060100", gbRucEmpresa, gbano, gbmes, "", "", FlagtieneRegistros, "S")
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
#End Region
    Private Sub AbreAnalitico(ByVal moneda As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Help_Cuentas_Por_Moneda", gbcodempresa, gbano, moneda, "ccm01cta", "*").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)

            If Not IsNothing(tblconsulta.Columns(0)) = True Then
                Me.tblconsulta.Columns(0).FooterText = "# Registros"
                Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AbreGeneral(ByVal nivel As Integer)
        Try
            Vista1 = objSql.TraerDataTable("sp_Con_Help_Cuentas_Por_Nivel", gbcodempresa, gbano, nivel, "ccm01cta", "*").DefaultView
            tblconsulta1.SetDataBinding(Vista1, Nothing, True)
            
            If Not IsNothing(tblconsulta1.Columns(0)) = True Then
                Me.tblconsulta1.Columns(0).FooterText = "# Registros"
                Me.tblconsulta1.Columns(1).FooterText = tblconsulta1.RowCount.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""
        Dim mesdemayor As String = ""
        Dim flagrep As String = ""
        Dim fechaini As String = ""
        Dim fechafin As String = ""
        Dim perixopcion As String = ""

        mesdemayor = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes

            If tabOpciones.SelectedIndex = 0 Then 'Es el libro analitico
                'Validar que las fechas esten bien
                If optTipoImpre_1.Checked = True Then
                    If (IsDate(mskFecIni.Text) = False Or IsDate(mskFecFin.Text) = False) Then MessageBox.Show("VALIDAR:: Fechas no Validas", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
                '=========Inserto Filas seleecionadas
                flagtiporeporte = "LIBMAYORAN"
                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

                '
                nombredereporte = If(gbTipoImpresora = "I", "mayanali_it.rpt", "mayanali.rpt")

                'Sp que trae datoas del reporte
                If optTipoImpre_0.Checked = True Then
                    flagrep = "1"
                    perixopcion = cboperiodos.Text
                ElseIf optTipoImpre_1.Checked = True Then
                    flagrep = "2"
                    fechaini = mskFecIni.Text
                    fechafin = mskFecFin.Text
                    perixopcion = fechaini + " a " + fechafin
                ElseIf optTipoImpre_2.Checked = True Then
                    flagrep = "3"

                    fechaini = Funciones.Funciones.derecha(cboPerini.Text, 2)
                    fechafin = Funciones.Funciones.derecha(cboPerfin.Text, 2)
                    'perixopcion = fechaini + " a " + fechafin                    
                    perixopcion = cboPerini.Text + " a " + cboPerfin.Text
                End If

                ds = objSql.TraerDataSet("sp_Con_Rep_LibroMayorAnalitico", gbcodempresa, gbano, mesdemayor, gbmoneda, gbNameUser, flagrep, fechaini, fechafin).Copy()
                'Formulas de reporte
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", perixopcion))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Tipo", flagrep))
            Else
                '=========Inserto Filas seleecionadas
                flagtiporeporte = "LIBMAYORGE"
                'Inserto los valores selecioandos
                If tblconsulta1.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta1, tblconsulta1.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

                If rbtTipRep_0.Checked = True Then
                    'MayGener_it.Rpt
                    nombredereporte = "MayGener.rpt"
                Else
                    nombredereporte = "maygener_Saldos.rpt"
                    'maygener_Saldos_it.Rpt
                End If

                'Sp que trae datoas del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_LibroMayorGeneral", gbcodempresa, gbano, mesdemayor, gbmoneda, gbNameUser).Copy()

                'Formulas de reporte

                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
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
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""
        Dim mesdemayor As String = ""
        Dim flagrep As String = ""
        Dim fechaini As String = ""
        Dim fechafin As String = ""
        Dim perixopcion As String = ""
        Dim flagimpresioncarta As String = ""

        If flagimpresion = "PC" Then
            flagimpresion = "P"
            flagimpresioncarta = "CARTA"
        End If

        mesdemayor = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
        'LLeno el rango de valores
        Try

            Rutareporte = gbRutaReportes

            If tabOpciones.SelectedIndex = 0 Then 'Es el libro analitico
                'Validar que las fechas esten bien
                If optTipoImpre_1.Checked = True Then
                    If (IsDate(mskFecIni.Text) = False Or IsDate(mskFecFin.Text) = False) Then MessageBox.Show("VALIDAR:: Fechas no Validas", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
                '=========Inserto Filas seleecionadas
                flagtiporeporte = "LIBMAYORAN"

                'Inserto los valores selecioandos
                If tblconsulta.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

                If optTipoImpre_2.Checked = True Then
                    If esReporteReducido = False Then
                        nombredereporte = "MayorAnali_Periodos.rpt"
                    Else
                        nombredereporte = "MayorAnali_Periodos_reducido.rpt"
                    End If
                Else
                    If flagimpresioncarta = "CARTA" Then
                        nombredereporte = "mayanali_it_carta.rpt"
                    Else
                        If esReporteReducido = False Then
                            nombredereporte = If(gbTipoImpresora = "I", "mayanali_it.rpt", "mayanali.rpt")
                        Else
                            nombredereporte = If(gbTipoImpresora = "I", "mayanali_it_reducido.rpt", "mayanali.rpt")
                        End If

                    End If
                End If


                If optTipoImpre_0.Checked = True Then
                    flagrep = "1"
                    fechaini = mskFecIni.Text
                    fechafin = mskFecFin.Text
                    perixopcion = cboperiodos.Text
                ElseIf optTipoImpre_1.Checked = True Then
                    flagrep = "2"
                    fechaini = mskFecIni.Text
                    fechafin = mskFecFin.Text
                    perixopcion = fechaini + " a " + fechafin
                ElseIf optTipoImpre_2.Checked = True Then
                    flagrep = "3"
                    'comanteado 01/10/2024
                    fechaini = Funciones.Funciones.derecha(cboPerini.SelectedValue.ToString, 2)
                    fechafin = Funciones.Funciones.derecha(cboPerfin.SelectedValue.ToString, 2)
                    'perixopcion = fechaini + " a " + fechafin                    
                    perixopcion = cboPerini.Text + " a " + cboPerfin.Text
                End If

                'Parametros
                ds = objSql.TraerDataSet("sp_Con_Rep_LibroMayorAnalitico", gbcodempresa, gbano, mesdemayor, gbmoneda, gbNameUser, flagrep, fechaini, fechafin).Copy()
                'Formulas de reporte
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", perixopcion))

                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", perixopcion))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("tipo", flagrep))

            Else
                '=========Inserto Filas seleecionadas
                flagtiporeporte = "LIBMAYORGE"
                'Inserto los valores selecioandos
                If tblconsulta1.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta1, tblconsulta1.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

                If rbtTipRep_0.Checked = True Then
                    'MayGener_it.Rpt
                    nombredereporte = If(gbTipoImpresora = "I", "MayGener_it.rpt", "MayGener.rpt")

                Else
                    nombredereporte = If(gbTipoImpresora = "I", "maygener_Saldos_it.rpt", "maygener_Saldos.rpt")

                    'maygener_Saldos_it.Rpt
                End If

                'Sp que trae datoas del reporte
                'Sp que trae datoas del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_LibroMayorGeneral", gbcodempresa, gbano, mesdemayor, gbmoneda, gbNameUser).Copy()
                'Formulas de reporte
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))

            End If
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
    Private Sub Frm_LibroMayor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nivel As Integer = 2
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Libro mayor"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Mod_Mantenimiento.Formatodegrilla(tblconsulta1)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_1, gbc_Ttp_SelecTodasFilas)
            '
            'Me.AbreAnalitico("*")
            'Me.AbreGeneral(nivel)

            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
            Mod_BaseDatos.LlenarComboPeriodos(cboPerini, gbcodempresa, gbano)
            Mod_BaseDatos.LlenarComboPeriodos(cboPerfin, gbcodempresa, gbano)
            '
            cboperiodos.SelectedIndex = CType(gbmes, Integer)
            '
            mskFecIni.Text = "01" & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano
            mskFecFin.Text = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) & "/" & If(gbmes = "00", "01", gbmes) & "/" & gbano

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub btnseleccionartodo_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_1.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta1)
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta1_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta1.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verAnt("I")
    End Sub
    Private Sub rbtMoneda_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoneda_0.CheckedChanged
        Me.AbreAnalitico("S")
    End Sub

    Private Sub rbtMoneda_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoneda_1.CheckedChanged
        Me.AbreAnalitico("D")
    End Sub

    Private Sub rbtMoneda_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoneda_2.CheckedChanged
        Me.AbreAnalitico("*")
    End Sub
    Private Sub rbtNivel_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNivel_0.CheckedChanged
        Me.AbreGeneral(2)
    End Sub
    Private Sub rbtNivel_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNivel_1.CheckedChanged
        Me.AbreGeneral(3)
    End Sub
    Private Sub rbtNivel_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNivel_2.CheckedChanged
        Me.AbreGeneral(4)
    End Sub
    Private Sub rbtNivel_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNivel_3.CheckedChanged
        Me.AbreGeneral(5)
    End Sub
    Private Sub rbtNivel_4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNivel_4.CheckedChanged
        Me.AbreGeneral(7)
    End Sub
    Private Sub rbtNivel_5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNivel_5.CheckedChanged
        Me.AbreGeneral(9)
    End Sub
    Private Sub rbtNivel_6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNivel_6.CheckedChanged
        Me.AbreGeneral(0)
    End Sub

    Private Sub optTipoImpre_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipoImpre_0.CheckedChanged
        cboperiodos.Enabled = True

        cboPerini.Enabled = False
        cboPerini.Enabled = False
        mskFecIni.Enabled = False
        mskFecFin.Enabled = False
    End Sub

    Private Sub optTipoImpre_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipoImpre_2.CheckedChanged
        cboperiodos.Enabled = False

        cboPerini.Enabled = True
        cboPerini.Enabled = True
        mskFecIni.Enabled = False
        mskFecFin.Enabled = False
    End Sub

    Private Sub optTipoImpre_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipoImpre_1.CheckedChanged
        cboperiodos.Enabled = False
        cboPerini.Enabled = False
        cboPerini.Enabled = False
        mskFecIni.Enabled = True
        mskFecFin.Enabled = True
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.imprimir_verAnt("PC")
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Me.ExportarArchivo()
    End Sub
    Dim esReporteReducido As Boolean = False
    Private Sub btn_verReporteReducido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_verReporteReducido.Click
        esReporteReducido = True
        Me.imprimir_verant("P")
        esReporteReducido = False
    End Sub
End Class