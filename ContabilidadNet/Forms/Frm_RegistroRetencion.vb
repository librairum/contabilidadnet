Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_RegistroRetencion

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#Region "Base de Datos"
    Private Sub TraerCtaCte(ByVal tipoanlisis As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Cuentas_Corrientes_New", gbcodempresa, tipoanlisis, "ccm02cod", "*", "*").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
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

        mesdelibrocaja = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "LIBCAJA"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            nombredereporte = "LibCaja.Rpt"
            flagopcionreporte = If(optTipoImpre_0.Checked = True, "1", "2")
            mesdelibrocaja = If(optTipoImpre_0.Checked = True, mesdelibrocaja, mesdelibrocaja.Substring(4, 2))
            'Sp que trae datoas del reporte
            ds = objSql.TraerDataSet("sp_Con_Rep_LibroCaja", gbcodempresa, gbano, mesdelibrocaja, gbmoneda, gbNameUser, flagopcionreporte, mskFecIni.Text, mskFecFin.Text).Copy()
            'Formulas de reporte
            Dim monedaMay As String
            monedaMay = If(gbmoneda = "S", "Nuevos Soles", If(gbmoneda = "D", "Dolares", "Dolar Promedio")) & "'"

            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))

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

        mesdeRegRetencion = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
        'LLeno el rango de valores
        Try
      
            Rutareporte = gbRutaReportes

            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "REGRET1"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If


            nombredereporte = "RegCompRet.Rpt"


            flagtipoimpresion = If(optTipoImpre_0.Checked = True, "P", "F")
            tipanlisiregretencion = cboTipoAnalisi.SelectedValue.ToString

            ds = objSql.TraerDataSet("Sp_Con_Rep_RegistroAfectosRetenciones", gbcodempresa, gbano, mesdeRegRetencion, tipanlisiregretencion, mskFecIni.Text, mskFecFin.Text, flagtipoimpresion).Copy()



            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NomPeriodo", cboperiodos.Text))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Pagina", CDbl(txtPagina.Text)))


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

    Private Sub Frm_RegistroRetencion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Registro de comprobantes de retencion"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnexportar, "Genera archivo para PDT")
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            '
            Me.TraerTipoAnalis(cboTipoAnalisi)
            cboTipoAnalisi.SelectedIndex = 0
            '
            Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)

            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
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
    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs)
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub cboTipoAnalisi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAnalisi.SelectedIndexChanged
        Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Me.ExportarArchivo()
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

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class