Option Strict On
Option Explicit On
Imports System.IO

Public Class Frm_RegVentas
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
        'dt = objSql.TraerDataSet("Sp_Con_Rep_RegistroVentas", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, "1")
        dt = objSql.TraerDataSet("Sp_Con_Rep_RegistroVentas", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, gbmoneda)

        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==
        nombredearchivo = Funciones.Funciones.NombreLibroelectronico("140100", gbRucEmpresa, gbano, gbmes, "", "", FlagtieneRegistros, "S")

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
                campo_08 = dr("NumeroDocNac").ToString
                campo_09 = ""
                campo_10 = dr("TipDocCtaCte").ToString
                campo_11 = dr("Ruc_Cuenta_Corriente").ToString
                campo_12 = dr("Nombre_Cuenta_Corriente").ToString

                campo_13 = dr("columna09").ToString 'Valor facturado de la exportacion
                campo_14 = dr("columna01").ToString 'Base imponible de la operación gravada (4)
                campo_15 = "0" 'Descuento de la Base Imponible 

                campo_16 = dr("columna04").ToString 'Impuesto General a las Ventas y/o Impuesto de Promoción Municipal 
                campo_17 = "0" 'Descuento del Impuesto General a las Ventas y/o Impuesto de Promoción Municipal()
                campo_18 = dr("columna07").ToString 'Importe total de la operación exonerada
                campo_19 = dr("columna02").ToString 'Importe total de la operación inafecta 
                campo_20 = dr("columna03").ToString 'Impuesto Selectivo al Consumo, de ser elcaso.                campo_21 = "0" 'Base imponible de la operación gravada con el Impuesto a las Ventas del Arroz Pilado
                campo_22 = "0" 'Impuesto a las Ventas del Arroz Pilado 
                campo_23 = dr("columna08").ToString 'Impuesto al Consumo de las Bolsas de Plástico
                campo_24 = dr("columna05").ToString 'Otros conceptos, tributos y cargos que no forman parte de la base imponible 
                campo_25 = dr("columna06").ToString 'Importe total del comprobante de pago.
                campo_26 = dr("MonedaTipo").ToString
                campo_27 = dr("TipoDeCambio").ToString
                campo_28 = dr("Referenciafecha").ToString
                campo_29 = dr("ReferenciaTipo").ToString
                campo_30 = dr("ReferenciaSerDoc").ToString
                campo_31 = dr("ReferenciaNumDoc").ToString
                campo_32 = ""
                campo_33 = dr("TipoCambioInconsistencia").ToString
                campo_34 = dr("CancelacionMedioPago").ToString
                campo_35 = dr("FlagdeAjuste").ToString

                Dim linea As String = ""

                linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & _
                campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & _
                campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) & _
                campo_16 & Chr(124) & campo_17 & Chr(124) & campo_18 & Chr(124) & campo_19 & Chr(124) & _
                campo_20 & Chr(124) & campo_21 & Chr(124) & campo_22 & Chr(124) & campo_23 & Chr(124) & _
                campo_24 & Chr(124) & campo_25 & Chr(124) & campo_26 & Chr(124) & campo_27 & Chr(124) & _
                campo_28 & Chr(124) & campo_29 & Chr(124) & campo_30 & Chr(124) & campo_31 & Chr(124) & _
                campo_32 & Chr(124) & campo_33 & Chr(124) & campo_34 & Chr(124) & campo_35 & Chr(124)

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
#Region "Mantenimiento"
    Function DameDescripcion(ByVal cCodigoBus As String, ByVal cFlag As String) As String
        ' Obtengo la Descripcion
        Try
            DameDescripcion = CType(objSql.TraerValor("sp_Con_Dame_Descripcion", gbcodempresa, cCodigoBus, cFlag, ""), String)
        Catch ex As Exception
            DameDescripcion = ""
        End Try
    End Function
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
                        lblhelp_0.Text = DameDescripcion(gbano + txtLibro.Text.Trim, "LV")
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
#Region "Base de datos"
    Private Sub traer_libros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Por_Tipo", gbcodempresa, gbano, "ccb02cod", "*", "V").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub Frm_RegVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnregdonaciones, "Registrar Facturas Por Donacion")
            Me.Text = "Registro de ventas"
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
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
        If tblhelp.Visible = True Then
            If e.KeyCode = Keys.F1 Then
                tblhelp.Visible = False
            End If
        End If
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub

    Private Sub txtLibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLibro.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim nombreper As String
        'LLeno el rango de valores
        Try
            nombreper = "PERIODO : " + gbano + "-" + gbmes
            'Validaciones
            If lblhelp_0.Text = "" Or lblhelp_0.Text = "???" Then Beep() : MessageBox.Show("Libro de compras no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtLibro.Focus() : Exit Sub
            If Not IsNumeric(txtPagina.Text) Then Beep() : MessageBox.Show("Número de Página es no válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPagina.Focus() : Exit Sub

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            nombredereporte = "RegVenta_a3.Rpt"
            ds = objSql.TraerDataSet("sp_Con_Rep_RegistroVentas", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, gbmoneda).Copy()
            'Formulas de reporte
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Pagina", CType(txtPagina.Text, Integer)))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Moneda", gbmoneda))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))


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
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim nombreper As String
        Dim paginasini As Double = 0

        'LLeno el rango de valores
        Try
            nombreper = "PERIODO : " + gbano + "-" + gbmes
            'Validaciones
            If lblhelp_0.Text = "" Or lblhelp_0.Text = "???" Then Beep() : MessageBox.Show("Libro de ventas no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtLibro.Focus() : Exit Sub
            If Not IsNumeric(txtPagina.Text) Then Beep() : MessageBox.Show("Número de Página es no válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPagina.Focus() : Exit Sub

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            nombredereporte = "RegVenta_a3.Rpt"
            '
            ds = objSql.TraerDataSet("sp_Con_Rep_RegistroVentas", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, gbmoneda).Copy()

            'Formulas de reporte
            paginasini = CType(txtPagina.Text, Double)
            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Pagina", paginasini))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", gbmoneda))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            '
            'Visualizar reportes
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
    Private Sub txtLibro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLibro.TextChanged
    End Sub
    Private Sub btnvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnregdonaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnregdonaciones.Click
        If Funciones.Funciones.FormIsOpen("Frm_RegVentas_Donocion") Then Exit Sub
        Dim _Frm_RegVentas_Donocion As New Frm_RegVentas_Donocion

        Try
            _Frm_RegVentas_Donocion.MdiParent = MDIPrincipal.ParentForm
            _Frm_RegVentas_Donocion.Owner = Me
            _Frm_RegVentas_Donocion.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Me.ExportarArchivo()
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