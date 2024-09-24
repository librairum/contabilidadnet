Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_RegCompras
#Region "Declaraciones"
    Dim VistaHelp As DataView
#End Region
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

        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Sp_Con_Rep_RegistroCompras", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, "1", "3", "S")

        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==
        nombredearchivo = Funciones.Funciones.NombreLibroelectronico("080100", gbRucEmpresa, gbano, gbmes, "", "", FlagtieneRegistros, "S")

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
            Dim campo_22 As String = ""
            Dim campo_23 As String = ""
            Dim campo_24 As String = ""
            Dim campo_25 As String = ""
            Dim campo_26 As String = ""
            Dim campo_27 As String = ""
            Dim campo_28 As String = ""
            Dim campo_29 As String = ""
            Dim campo_30 As String = ""
            Dim campo_31 As String = ""
            Dim campo_32 As String = ""
            Dim campo_33 As String = ""
            Dim campo_34 As String = ""
            Dim campo_35 As String = ""
            Dim campo_36 As String = ""
            Dim campo_37 As String = ""
            Dim campo_38 As String = ""
            Dim campo_39 As String = ""
            Dim campo_40 As String = ""
            Dim campo_41 As String = ""
            Dim campo_42 As String = ""


            Dim dr As DataRow

            For Each dr In dt.Tables(0).Rows
                'Obtenemos los datos del dataset
                campo_01 = dr("periodo").ToString
                campo_02 = dr("CodigoUnicoOperacion").ToString
                campo_03 = dr("NumcorrelativoAsicont").ToString
                campo_04 = dr("Fecha_Emision").ToString
                campo_05 = dr("Fecha_VencoPago").ToString
                campo_06 = dr("Tipo_Documento").ToString
                campo_07 = dr("SerieDocNac").ToString
                campo_08 = dr("AnioDua").ToString
                campo_09 = dr("NumeroDocNac").ToString
                campo_10 = ""
                campo_11 = dr("TipDocCtaCte").ToString
                campo_12 = dr("Ruc_Cuenta_Corriente").ToString
                campo_13 = dr("Nombre_Cuenta_Corriente").ToString
                campo_14 = dr("Columna01").ToString
                campo_15 = dr("Columna06").ToString
                campo_16 = dr("Columna02").ToString
                campo_17 = dr("Columna07").ToString
                campo_18 = dr("Columna03").ToString
                campo_19 = dr("Columna08").ToString
                campo_20 = dr("Columna04").ToString
                campo_21 = "0"
                campo_22 = dr("Columna05").ToString
                campo_23 = dr("Columna09").ToString 'CStr(CDate(dr("RucProveedor").ToString).ToString("dd/MM/yyyy"))
                campo_24 = dr("Columna10").ToString
                campo_25 = dr("MonedaTipo").ToString

                campo_26 = dr("TipoDeCambio").ToString
                campo_27 = dr("Referenciafecha").ToString
                campo_28 = dr("ReferenciaTipo").ToString
                campo_29 = dr("ReferenciaSerDoc").ToString
                campo_30 = dr("CodigoDependenciaaduanera").ToString
                campo_31 = dr("ReferenciaNumDoc").ToString
                campo_32 = dr("FecPago").ToString
                campo_33 = dr("NroPago").ToString
                campo_34 = dr("afectoaretencion").ToString

                campo_35 = dr("Bienoservicio").ToString
                campo_36 = dr("IdentificacionContrato").ToString
                campo_37 = dr("TipoCambioInconsistencia").ToString
                campo_38 = dr("ProvNoHabidosInconsistencia").ToString
                campo_39 = dr("ProvRenunciarionInconsistencia").ToString
                campo_40 = dr("DNIutilizadosInconsistencia").ToString
                campo_41 = dr("CancelacionMedioPago").ToString

                campo_42 = dr("FlagdeAjuste").ToString

                Dim linea As String = ""

                linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & _
                campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & _
                campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) & _
                campo_16 & Chr(124) & campo_17 & Chr(124) & campo_18 & Chr(124) & campo_19 & Chr(124) & _
                campo_20 & Chr(124) & campo_21 & Chr(124) & campo_22 & Chr(124) & campo_23 & Chr(124) & _
                campo_24 & Chr(124) & campo_25 & Chr(124) & campo_26 & Chr(124) & campo_27 & Chr(124) & _
                campo_28 & Chr(124) & campo_29 & Chr(124) & campo_30 & Chr(124) & campo_31 & Chr(124) & _
                campo_32 & Chr(124) & campo_33 & Chr(124) & campo_34 & Chr(124) & campo_35 & Chr(124) & _
                campo_36 & Chr(124) & campo_37 & Chr(124) & campo_38 & Chr(124) & campo_39 & Chr(124) & _
                campo_40 & Chr(124) & campo_41 & Chr(124) & campo_42 & Chr(124)

                'Escribimos la línea en el achivo de texto
                strStreamWriter.WriteLine(linea)

            Next

            strStreamWriter.Close()
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub ExportarArchivo_Formato82()
        '
        Dim FlagtieneRegistros As String
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim ds As New DataSet

        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Sp_Con_Rep_RegistroCompras", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, "1", "4", "S")

        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==
        nombredearchivo = Funciones.Funciones.NombreLibroelectronico("080200", gbRucEmpresa, gbano, gbmes, "", "", FlagtieneRegistros, "S")

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
            Dim campo_22 As String = ""
            Dim campo_23 As String = ""
            Dim campo_24 As String = ""
            Dim campo_25 As String = ""
            Dim campo_26 As String = ""
            Dim campo_27 As String = ""
            Dim campo_28 As String = ""
            Dim campo_29 As String = ""
            Dim campo_30 As String = ""
            Dim campo_31 As String = ""
            Dim campo_32 As String = ""
            Dim campo_33 As String = ""
            Dim campo_34 As String = ""
            Dim campo_35 As String = ""
            Dim campo_36 As String = ""



            Dim dr As DataRow

            For Each dr In dt.Tables(0).Rows
                'Obtenemos los datos del dataset
                campo_01 = dr("periodo").ToString
                campo_02 = dr("CodigoUnicoOperacion").ToString
                campo_03 = dr("NumcorrelativoAsicont").ToString
                campo_04 = dr("Fecha_Emision").ToString
                campo_05 = dr("Tipo_Documento").ToString
                campo_06 = dr("SerieDocNac").ToString
                campo_07 = dr("NumeroDocNac").ToString
                campo_08 = dr("ValorAdquisiciones").ToString
                campo_09 = dr("OtrosConceptosAdicionales").ToString
                campo_10 = dr("Columna10").ToString

                campo_11 = dr("CreditoFiscalTipCompPago").ToString
                campo_12 = dr("CreditoFiscalSerieCompPago").ToString
                campo_13 = dr("CreditoFiscalAniodua").ToString
                campo_14 = dr("CreditoFiscalNumeroCompPago").ToString

                campo_15 = "0" ' Las importaciones no tienen IGV
                campo_16 = dr("MonedaTipo").ToString
                campo_17 = dr("TipoDeCambio").ToString

                campo_18 = dr("SujNoDomiPais").ToString
                campo_19 = dr("SujNoDomiRazonSocial").ToString
                campo_20 = dr("SujNoDomiDomicilio").ToString
                campo_21 = dr("SujNoDomiIdentificacionNro").ToString

                campo_22 = dr("BeneEfecPagoIdentifcaFiscalNro").ToString
                campo_23 = dr("BeneEfecPagoRazonSocial").ToString
                campo_24 = dr("BeneEfecPagoPais").ToString
                campo_25 = dr("VinculoContriConResidente").ToString

                campo_26 = "0" 'No es Obligatorio
                campo_27 = "0" 'No es Obligatorio
                campo_28 = "0" 'No es Obligatorio
                campo_29 = "0" 'No es Obligatorio
                campo_30 = "0" 'No es Obligatorio

                campo_31 = dr("ConvenioEvitarDoble").ToString
                campo_32 = dr("ExonercionAplicada").ToString
                campo_33 = dr("TipodeRenta").ToString
                campo_34 = dr("Modalidaddelservicio").ToString
                campo_35 = dr("AplicacionpenulparrafoIR").ToString
                campo_36 = dr("FlagdeAjuste").ToString

                Dim linea As String = ""

                linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & _
                campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & _
                campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) & _
                campo_16 & Chr(124) & campo_17 & Chr(124) & campo_18 & Chr(124) & campo_19 & Chr(124) & _
                campo_20 & Chr(124) & campo_21 & Chr(124) & campo_22 & Chr(124) & campo_23 & Chr(124) & _
                campo_24 & Chr(124) & campo_25 & Chr(124) & campo_26 & Chr(124) & campo_27 & Chr(124) & _
                campo_28 & Chr(124) & campo_29 & Chr(124) & campo_30 & Chr(124) & campo_31 & Chr(124) & _
                campo_32 & Chr(124) & campo_33 & Chr(124) & campo_34 & Chr(124) & campo_35 & Chr(124) & _
                campo_36 & Chr(124) 

                'Escribimos la línea en el achivo de texto
                strStreamWriter.WriteLine(linea)

            Next

            strStreamWriter.Close()

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "Mantenimiento"
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
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txtLibro.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtLibro.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtLibro.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtLibro.Text.Trim, "LC")
                    End If
            End Select

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
#Region "Base de datos"
    Private Sub traer_libros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Por_Tipo", gbcodempresa, gbano, "ccb02cod", "*", "C").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub Frm_RegCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sstabregcompras.TabIndex = 0
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Mod_Mantenimiento.tooltiptext(btnexportar, "Exportar Archivo al PLE")
            Me.Text = "Registro de compras"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblhelp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp.Tag, Integer)
        Try
            If tblhelp.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.tblhelp_DoubleClick(Nothing, Nothing)
            End If
            If tblhelp.Visible = True Then
                If e.KeyCode = Keys.Escape Then
                    tblhelp.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
    '    tblhelp.Tag = ""
    '    tblhelp.Visible = False
    'End Sub

    Private Sub txtLibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLibro.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)

        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim flagordena As String
        Dim flagfiltro As String
        Dim nombreper As String

        'LLeno el rango de valores
        Try
            'Validaciones
            If lblhelp_0.Text = "" Or lblhelp_0.Text = "???" Then Beep() : MessageBox.Show("Libro de compras no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtLibro.Focus() : Exit Sub
            If Not IsNumeric(txtPagina.Text) Then Beep() : MessageBox.Show("Número de Página es no válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPagina.Focus() : Exit Sub

            nombreper = "PERIODO : " + gbano + "-" + gbmes

            'Rutareporte = gbRutaAplicacion + "\reports\"
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor

            ' Asigno el Nombre del Reporte

            If sstabregcompras.SelectedIndex = 0 Then
                nombredereporte = "regCompr_new_a3.Rpt"

                flagordena = "1"
                flagfiltro = "*" + "N"
            Else
                If chkagrupa.Checked = True Then
                    nombredereporte = "regcompr_new_por_tipdoc_a3.rpt"
                Else
                    nombredereporte = "regCompr_new_a3.Rpt"
                End If

                flagordena = If(chkordena.Checked = True, "2", "1")
                flagfiltro = If(rbtfiltro_1.Checked = True, "1", If(rbtfiltro_2.Checked = True, "2", "*"))
            End If

            ds = objSql.TraerDataSet("sp_Con_Rep_RegistroCompras", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, flagordena, flagfiltro, "S").Copy()

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Pagina", CType(txtPagina.Text, Integer)))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("nro_formulario", txtnroformulario.Text.Trim))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("nro_orden", txtnroorden.Text.Trim))

            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub
    Private Sub btnregdonaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnregdonaciones.Click
        If Funciones.Funciones.FormIsOpen("Frm_Regcomprasnroformulario") Then Exit Sub
        Dim _Frm_Regcomprasnroformulario As New Frm_Regcomprasnroformulario
        Try
            _Frm_Regcomprasnroformulario.MdiParent = MDIPrincipal.ParentForm
            _Frm_Regcomprasnroformulario.Owner = Me
            _Frm_Regcomprasnroformulario.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Try
            Me.ExportarArchivo()
            Me.ExportarArchivo_Formato82()

            MessageBox.Show("Los archivos se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub lblhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblhelp_0.Click

    End Sub

    Private Sub txtLibro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLibro.TextChanged

    End Sub
    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        Try
            tblhelp.Visible = False
            VistaHelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtLibro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLibro.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                TraerAyuda(0, btnhelp_0)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class