Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_PDB
#Region "Declaraciones"
    Dim VistaHelp As DataView
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#End Region
#Region "Base de datos"
    Private Sub traer_libros(ByVal tipolibro As String)
        Try


            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Por_Tipo", gbcodempresa, gbano, "ccb02cod", "*", tipolibro).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Mantenimiento"
    Sub LimpiarValores()
        txtLibrocompra.Text = "" : lblhelp_0.Text = ""
        'txtuits.Text = "0"
    End Sub
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
                    Me.traer_libros("C")
                Case 1
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.traer_libros("V")
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
                    txtLibrocompra.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtLibrocompra.Focus()
                Case 1
                    txtLibroventas.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_1.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtLibrocompra.Focus()
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
                    If txtLibrocompra.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = DameDescripcion(gbano + txtLibrocompra.Text.Trim, "LV")
                    End If
                Case 1
                    txtLibrocompra.Text = "04"
                    txtLibroventas.Text = "05"
                    lblhelp_0.Text = DameDescripcion(gbano + "04", "LI")
                    lblhelp_1.Text = DameDescripcion(gbano + "05", "LI")
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

    Sub imprimir_verant(ByVal flagimpresion As String)
        'Dim objR As New KS.Com.Win.CystalReports.Net.File
        'Dim ds As System.Data.DataSet
        'Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        'Dim nombredereporte As String = ""
        'Dim Rutareporte As String

        ''LLeno el rango de valores
        'Try

        '    Rutareporte = gbRutaReportes
        '    Cursor.Current = Cursors.WaitCursor
        '    '========================================
        '    If rbtTipoImpre_0.Checked = True Then
        '        nombredereporte = "Rpt_RankigProv.Rpt"
        '        ds = objSql.TraerDataSet("Spu_Con_Rep_RankigProv", gbcodempresa, gbano, txtLibrocompra.Text, gbmoneda).Copy()


        '        'Formulas de reporte
        '        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
        '    ElseIf rbtTipoImpre_1.Checked = True Then
        '        nombredereporte = "Rpt_RankingClientes.rpt"
        '        ds = objSql.TraerDataSet("Spu_Con_Rep_RankigClientes", gbcodempresa, gbano, txtLibrocompra.Text, gbmoneda).Copy()

        '        'Formulas de reporte
        '        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
        '    End If

        '    'Visualizar reportes
        '    If flagimpresion = "P" Then
        '        objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
        '    Else
        '        objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
        '    End If
        '    '===
        '    Cursor.Current = Cursors.Default
        'Catch ex As Exception
        '    Cursor.Current = Cursors.Default
        '    MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.imprimir_verant("I")
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
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        If chkCompras.Checked = False Then
            Return

        Else
            Me.TraerAyuda(0, btnhelp_0)
        End If

    End Sub
    Private Sub Frm_LibroDiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TraeDameDescripcion(1)
            Me.Text = "PDB"


            txtrutatipodecambio.Text = DameDescripcion("0200003", "RUTXDEFECTOPDB")
            txtrutacompras.Text = DameDescripcion("0200001", "RUTXDEFECTOPDB")
            txtrutaventas.Text = DameDescripcion("0200002", "RUTXDEFECTOPDB")

            'Llena combo 


            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnexportar, "Generar Archivo para PDB")

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            ' Iniciar controles
            chktipodecambio.Checked = True
            chkCompras.Checked = True
            chkVentas.Checked = True


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.imprimir_verant("P")
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Try

            'validar
            If (chkCompras.Checked = False And chkVentas.Checked = False And chktipodecambio.Checked = False) Then Beep() : MessageBox.Show("VALIDAR::Debe seleccionar una opcion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)


            Dim strStreamWriter As StreamWriter

            'Dim folderBrowserDialog As New FolderBrowserDialog()
            'folderBrowserDialog.Description = "Seleccionar Carpeta para Guardar Archivos"
            'folderBrowserDialog.ShowNewFolderButton = True
            'If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
            '    Dim folderPath As String = folderBrowserDialog.SelectedPath

            'Else
            '    Return
            'End If




            If chkCompras.Checked Then
                If Directory.Exists(txtrutacompras.Text) Then
                    ExportarCompras()

                Else
                    MessageBox.Show("La ruta para el archivo COMPRAS no existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            If chkVentas.Checked Then
                If Directory.Exists(txtrutaventas.Text) Then
                    ExportarVentas()

                Else
                    MessageBox.Show("La ruta para el archivo VENTAS no existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

            End If

                If chktipodecambio.Checked Then
                If Directory.Exists(txtrutatipodecambio.Text) Then
                    ExportarTipoCambio()

                Else
                    MessageBox.Show("La ruta para el archivo TIPO DE CAMBIO no existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                End If
                ' Pregunto si Mayorizo el Mes
                'Exportar()
                MessageBox.Show("Archivos generados exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Exportar()
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim ds As New DataSet
        Dim dt As New DataSet
        Dim dr As DataRow

        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Try
            nombredearchivo = "costos" + ".txt"
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
            dt = objSql.TraerDataSet("Spu_Con_Trae_DAOT", gbcodempresa, gbano, "00", gbmoneda, 23)


            Dim nNumero As Integer = 0
            Dim cNumero As String = ""
            Dim cImporte As String = ""
            Dim cTipPersona As String = ""
            Dim cTipoDocumento As String = ""
            Dim cRuc As String = ""
            Dim cRazonSocial As String = ""
            Dim cApePaterno As String = ""
            Dim cApeMaterno As String = ""
            Dim cPriNombreAux As String = ""
            Dim cPriNombre As String = ""
            Dim cSegNombre As String = ""
            Dim ctipodoc_declarante As String = ""
            Dim linea As String = ""

            For Each dr In dt.Tables(0).Rows
                nNumero = nNumero + 1
                cNumero = nNumero.ToString

                'Limpiar Valores
                cTipPersona = ""
                cTipoDocumento = ""
                cRuc = ""
                cImporte = ""
                cApePaterno = ""
                cApeMaterno = ""
                cPriNombre = ""
                cSegNombre = ""
                cPriNombreAux = ""
                cRazonSocial = ""
                ctipodoc_declarante = ""
                'Asignar nuevos valores
                cTipPersona = dr("TipodePersona").ToString
                cTipoDocumento = dr("ccm02tipdocidentidad").ToString
                cRuc = dr("Ruc_Cuenta_Corriente").ToString
                cImporte = dr("importeTotal").ToString
                cApePaterno = dr("ccm02ApePaterno").ToString
                cApeMaterno = dr("ccm02ApeMaterno").ToString
                cPriNombreAux = dr("ccm02Nombres").ToString
                cRazonSocial = dr("ccm02nom").ToString
                ctipodoc_declarante = dr("tipodoc_declarante").ToString

                If cPriNombreAux <> "" Then
                    If cPriNombreAux.IndexOf(" ") = -1 Then
                        cPriNombre = cPriNombreAux
                        cSegNombre = ""
                    Else
                        cPriNombre = cPriNombreAux.Substring(0, cPriNombreAux.IndexOf(" "))
                        cSegNombre = cPriNombreAux.Substring(cPriNombreAux.IndexOf(" ") + 1)
                    End If
                Else
                    cPriNombre = ""
                    cSegNombre = ""
                End If


                linea = cNumero & Chr(124) & ctipodoc_declarante & Chr(124) & gbRucEmpresa & Chr(124) & _
                    gbano & Chr(124) & cTipPersona & Chr(124) & cTipoDocumento & Chr(124) & cRuc & Chr(124) & _
                    cImporte & Chr(124) & cApePaterno & Chr(124) & cApeMaterno & Chr(124) & cPriNombre & Chr(124) & _
                    cSegNombre & Chr(124) & cRazonSocial & Chr(124)
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



    Private Sub ExportarCompras()

        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""

        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Sp_Con_exportaPDB", gbcodempresa, gbano, gbmes, txtLibrocompra.Text)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try


            Dim selectedFolder As String
            '= folderBrowserDialog1.SelectedPath
            selectedFolder = txtrutacompras.Text
            Dim FilePath As String = Path.Combine(selectedFolder, "C" + gbRucEmpresa + gbperiodo + ".txt")



            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim tipo_de_compra = ""
            Dim tipo_de_comprobante = ""
            Dim fecha_emision_o_pago = ""
            Dim num_serie_CompPago = ""
            Dim num_compPago = ""
            Dim tipo_de_persona = ""
            Dim tipo_de_documento = ""
            Dim numero_de_documento = ""
            Dim nombre_o_razon_social = ""
            Dim apellido_paterno = ""
            Dim apellido_materno = ""
            Dim nombre_1 = ""
            Dim nombre_2 = ""
            Dim tipo_de_moneda = ""
            Dim codigo_de_destino = ""
            Dim numero_de_destino = ""
            Dim base_imponible = ""
            Dim monto_ISC = ""
            Dim monto_IGV = ""
            Dim monto_Otros = ""
            Dim indicador_de_detracciones = ""
            Dim tasa = ""
            Dim num_de_constancia_detraccion = ""
            Dim indicador_de_retenciones = ""
            Dim dr_tipo_de_comprobante_de_pago = ""
            Dim dr_serie_del_comprobante = ""
            Dim dr_numero_del_comprobante = ""
            Dim dr_fecha_de_emision = ""
            Dim dr_Base_Imponible = ""
            Dim dr_Igv = ""
            Dim fechaOriginal As DateTime
            Using sw As StreamWriter = New StreamWriter(FilePath)
                Dim dr As DataRow

                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    tipo_de_compra = dr("tipo_de_compra").ToString
                    tipo_de_comprobante = dr("tipo_de_comprobante").ToString
                    fechaOriginal = DirectCast(dr("fecha_emision_o_pago"), DateTime)
                    fecha_emision_o_pago = fechaOriginal.ToString("dd/MM/yyyy")
                    num_serie_CompPago = dr("num_serie_CompPago").ToString
                    num_compPago = dr("num_compPago").ToString
                    tipo_de_persona = dr("tipo_de_persona").ToString
                    tipo_de_documento = dr("tipo_de_documento").ToString
                    numero_de_documento = dr("numero_de_documento").ToString
                    nombre_o_razon_social = dr("nombre_o_razon_social").ToString
                    apellido_paterno = dr("apellido_paterno").ToString
                    apellido_materno = dr("apellido_materno").ToString
                    nombre_1 = dr("nombre_1").ToString
                    nombre_2 = dr("nombre_2").ToString
                    tipo_de_moneda = dr("tipo_de_moneda").ToString
                    codigo_de_destino = dr("codigo_de_destino").ToString
                    numero_de_destino = dr("numero_de_destino").ToString
                    base_imponible = dr("base_imponible").ToString
                    monto_ISC = dr("monto_ISC").ToString
                    monto_IGV = dr("monto_IGV").ToString
                    monto_Otros = dr("monto_Otros").ToString
                    indicador_de_detracciones = dr("indicador_de_detracciones").ToString
                    tasa = dr("tasa").ToString
                    num_de_constancia_detraccion = dr("num_de_constancia_detraccion").ToString
                    indicador_de_retenciones = dr("indicador_de_retenciones").ToString
                    dr_tipo_de_comprobante_de_pago = dr("dr_tipo_de_comprobante_de_pago").ToString
                    dr_serie_del_comprobante = dr("dr_serie_del_comprobante").ToString
                    dr_numero_del_comprobante = dr("dr_numero_del_comprobante").ToString
                    dr_fecha_de_emision = dr("dr_fecha_de_emision").ToString
                    dr_Base_Imponible = dr("dr_Base_Imponible").ToString
                    dr_Igv = dr("dr_Igv").ToString


                    Dim linea As String = ""
                    linea = tipo_de_compra & Chr(124) & tipo_de_comprobante & Chr(124) & fecha_emision_o_pago & Chr(124) & num_serie_CompPago & Chr(124) & num_compPago & Chr(124) & tipo_de_persona & Chr(124) & tipo_de_documento & Chr(124) & numero_de_documento & Chr(124) & nombre_o_razon_social & Chr(124) & apellido_paterno & Chr(124) & apellido_materno & Chr(124) & nombre_1 & Chr(124) & nombre_2 & Chr(124) & tipo_de_moneda & Chr(124) & codigo_de_destino & Chr(124) & numero_de_destino & Chr(124) & base_imponible & Chr(124) & monto_ISC & Chr(124) & monto_IGV & Chr(124) & monto_Otros & Chr(124) & indicador_de_detracciones & Chr(124) & tasa & Chr(124) & num_de_constancia_detraccion & Chr(124) & indicador_de_retenciones & Chr(124) & dr_tipo_de_comprobante_de_pago & Chr(124) & dr_serie_del_comprobante & Chr(124) & dr_numero_del_comprobante & Chr(124) & dr_fecha_de_emision & Chr(124) & dr_Base_Imponible & Chr(124) & dr_Igv & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub ExportarTipoCambio()

        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim fecha As String

        fecha = "01" + "/" + gbmes + "/" + gbano

        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Sp_Con_Trae_TipCambio_PDB", "2", fecha)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try


            Dim selectedFolder As String '= folderBrowserDialog1.SelectedPath
            selectedFolder = txtrutatipodecambio.Text
            Dim FilePath As String = Path.Combine(selectedFolder, gbRucEmpresa + ".tc")



            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            'Dim Fecha = ""
            Dim ComBan = ""
            Dim VenBan = ""

            Using sw As StreamWriter = New StreamWriter(FilePath)
                Dim dr As DataRow
                Dim fechaOriginal As DateTime
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    fechaOriginal = DirectCast(dr("Fecha"), DateTime)
                    Fecha = fechaOriginal.ToString("dd/MM/yyyy")
                    ComBan = dr("ComBan").ToString
                    VenBan = dr("VenBan").ToString


                    Dim linea As String = ""
                    linea = Fecha & Chr(124) & ComBan & Chr(124) & VenBan & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub ExportarVentas()

        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""

        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Sp_Con_exportaPDBVentas", gbcodempresa, gbano, gbmes, txtLibroventas.Text)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try


            Dim selectedFolder As String '= folderBrowserDialog1.SelectedPath
            selectedFolder = txtrutaventas.Text
            Dim FilePath As String = Path.Combine(selectedFolder, "V" + gbRucEmpresa + gbperiodo + ".txt")



            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim tipo_de_compra = ""
            Dim tipo_de_comprobante = ""
            Dim fecha_emision_o_pago = ""
            Dim num_serie_CompPago = ""
            Dim num_compPago = ""
            Dim tipo_de_persona = ""
            Dim tipo_de_documento = ""
            Dim numero_de_documento = ""
            Dim nombre_o_razon_social = ""
            Dim apellido_paterno = ""
            Dim apellido_materno = ""
            Dim nombre_1 = ""
            Dim nombre_2 = ""
            Dim tipo_de_moneda = ""
            Dim codigo_de_destino = ""
            Dim numero_de_destino = ""
            Dim base_imponible = ""
            Dim monto_ISC = ""
            Dim monto_IGV = ""
            Dim monto_Otros = ""
            Dim indicador_de_Percepciones = ""
            Dim tipo_tasa_percepcion = ""
            Dim num_de_serie_percepcion = ""
            Dim num_de_Documento_percepcion = ""
            Dim dr_tipo_de_comprobante_de_pago = ""
            Dim dr_serie_del_comprobante = ""
            Dim dr_numero_del_comprobante = ""
            Dim dr_fecha_de_emision = ""
            Dim dr_Base_Imponible = ""
            Dim dr_Igv$ = ""

            Using sw As StreamWriter = New StreamWriter(FilePath)
                Dim dr As DataRow
                Dim fechaOriginal As DateTime
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    tipo_de_compra = dr("tipo_de_Venta").ToString
                    tipo_de_comprobante = dr("tipo_de_comprobante").ToString
                    fechaOriginal = DirectCast(dr("fecha_emision_o_pago"), DateTime)
                    fecha_emision_o_pago = fechaOriginal.ToString("dd/MM/yyyy")
                    num_serie_CompPago = dr("num_serie_CompPago").ToString
                    num_compPago = dr("num_compPago").ToString
                    tipo_de_persona = dr("tipo_de_persona").ToString
                    tipo_de_documento = dr("tipo_de_documento").ToString
                    numero_de_documento = dr("numero_de_documento").ToString
                    nombre_o_razon_social = dr("nombre_o_razon_social").ToString
                    apellido_paterno = dr("apellido_paterno").ToString
                    apellido_materno = dr("apellido_materno").ToString
                    nombre_1 = dr("nombre_1").ToString
                    nombre_2 = dr("nombre_2").ToString
                    tipo_de_moneda = dr("tipo_de_moneda").ToString
                    codigo_de_destino = dr("codigo_de_destino").ToString
                    numero_de_destino = dr("numero_de_destino").ToString
                    base_imponible = dr("base_imponible").ToString
                    monto_ISC = dr("monto_ISC").ToString
                    monto_IGV = dr("monto_IGV").ToString
                    monto_Otros = dr("monto_Otros").ToString
                    indicador_de_Percepciones = dr("indicador_de_Percepciones").ToString
                    tipo_tasa_percepcion = dr("tipo_tasa_percepcion").ToString
                    num_de_serie_percepcion = dr("num_de_serie_percepcion").ToString
                    num_de_Documento_percepcion = dr("num_de_Documento_percepcion").ToString
                    dr_tipo_de_comprobante_de_pago = dr("dr_tipo_de_comprobante_de_pago").ToString
                    dr_serie_del_comprobante = dr("dr_serie_del_comprobante").ToString
                    dr_numero_del_comprobante = dr("dr_numero_del_comprobante").ToString
                    dr_fecha_de_emision = dr("dr_fecha_de_emision").ToString
                    dr_Base_Imponible = dr("dr_Base_Imponible").ToString
                    dr_Igv = dr("dr_Igv").ToString



                    Dim linea As String = ""
                    linea = tipo_de_compra & Chr(124) & tipo_de_comprobante & Chr(124) & fecha_emision_o_pago & Chr(124) & num_serie_CompPago & Chr(124) & num_compPago & Chr(124) & tipo_de_persona & Chr(124) & tipo_de_documento & Chr(124) & numero_de_documento & Chr(124) & nombre_o_razon_social & Chr(124) & apellido_paterno & Chr(124) & apellido_materno & Chr(124) & nombre_1 & Chr(124) & nombre_2 & Chr(124) & tipo_de_moneda & Chr(124) & codigo_de_destino & Chr(124) & numero_de_destino & Chr(124) & base_imponible & Chr(124) & monto_ISC & Chr(124) & monto_IGV & Chr(124) & monto_Otros & Chr(124) & indicador_de_Percepciones & Chr(124) & tipo_tasa_percepcion & Chr(124) & num_de_serie_percepcion & Chr(124) & num_de_Documento_percepcion & Chr(124) & dr_tipo_de_comprobante_de_pago & Chr(124) & dr_serie_del_comprobante & Chr(124) & dr_numero_del_comprobante & Chr(124) & dr_fecha_de_emision & Chr(124) & dr_Base_Imponible & Chr(124) & dr_Igv & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
 
    Private Sub ExportarCostos()
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim ds As New DataSet
        Dim dt As New DataSet
        Dim dr As DataRow

        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Try
            nombredearchivo = "costos" + ".txt"
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
            dt = objSql.TraerDataSet("Spu_Con_Trae_DAOT", gbcodempresa, gbano, "01", gbmoneda, 0)


            Dim nNumero As Integer = 0
            Dim cNumero As String = ""
            Dim cImporte As String = ""
            Dim cTipPersona As String = ""
            Dim cTipoDocumento As String = ""
            Dim cRuc As String = ""
            Dim cRazonSocial As String = ""
            Dim cApePaterno As String = ""
            Dim cApeMaterno As String = ""
            Dim cPriNombreAux As String = ""
            Dim cPriNombre As String = ""
            Dim cSegNombre As String = ""
            Dim ctipodoc_declarante As String = ""
            Dim linea As String = ""

            For Each dr In dt.Tables(0).Rows
                nNumero = nNumero + 1
                cNumero = nNumero.ToString

                'Limpiar Valores
                cTipPersona = ""
                cTipoDocumento = ""
                cRuc = ""
                cImporte = ""
                cApePaterno = ""
                cApeMaterno = ""
                cPriNombre = ""
                cSegNombre = ""
                cPriNombreAux = ""
                cRazonSocial = ""
                ctipodoc_declarante = ""
                'Asignar nuevos valores
                cTipPersona = dr("TipodePersona").ToString
                cTipoDocumento = dr("ccm02tipdocidentidad").ToString
                cRuc = dr("Ruc_Cuenta_Corriente").ToString
                cImporte = dr("importeTotal").ToString
                cApePaterno = dr("ccm02ApePaterno").ToString
                cApeMaterno = dr("ccm02ApeMaterno").ToString
                cPriNombreAux = dr("ccm02Nombres").ToString
                cRazonSocial = dr("ccm02nom").ToString
                ctipodoc_declarante = dr("tipodoc_declarante").ToString

                If cPriNombreAux <> "" Then
                    If cPriNombreAux.IndexOf(" ") = -1 Then
                        cPriNombre = cPriNombreAux
                        cSegNombre = ""
                    Else
                        cPriNombre = cPriNombreAux.Substring(0, cPriNombreAux.IndexOf(" "))
                        cSegNombre = cPriNombreAux.Substring(cPriNombreAux.IndexOf(" ") + 1)
                    End If
                Else
                    cPriNombre = ""
                    cSegNombre = ""
                End If


                linea = cNumero & Chr(124) & ctipodoc_declarante & Chr(124) & gbRucEmpresa & Chr(124) & _
                    gbano & Chr(124) & cTipPersona & Chr(124) & cTipoDocumento & Chr(124) & cRuc & Chr(124) & _
                    cImporte & Chr(124) & cApePaterno & Chr(124) & cApeMaterno & Chr(124) & cPriNombre & Chr(124) & _
                    cSegNombre & Chr(124) & cRazonSocial & Chr(124)
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
    Private Sub ExportarIngresos()
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim ds As New DataSet

        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Try
            nombredearchivo = "ingresos" + ".txt"
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
            dt = objSql.TraerDataSet("Spu_Con_Trae_DAOTIngresos", gbcodempresa, gbano, "01", gbmoneda, 0)


            Dim dr As DataRow

            Dim nNumero As Integer = 0
            Dim cNumero As String = ""
            Dim cImporte As String = ""
            Dim cTipPersona As String = ""
            Dim cTipoDocumento As String = ""
            Dim cRuc As String = ""
            Dim cRazonSocial As String = ""
            Dim cApePaterno As String = ""
            Dim cApeMaterno As String = ""
            Dim cPriNombreAux As String = ""
            Dim cPriNombre As String = ""
            Dim cSegNombre As String = ""
            Dim ctipodoc_declarante As String = ""
            Dim linea As String = ""

            For Each dr In dt.Tables(0).Rows
                nNumero = nNumero + 1
                cNumero = nNumero.ToString

                'Limpiar Valores
                ctipodoc_declarante = ""
                cTipPersona = ""
                cTipoDocumento = ""
                cRuc = ""
                cImporte = ""
                cApePaterno = ""
                cApeMaterno = ""
                cPriNombre = ""
                cSegNombre = ""
                cPriNombreAux = ""
                cRazonSocial = ""

                'Asignar nuevos valores
                ctipodoc_declarante = dr("tipodoc_declarante").ToString
                cTipPersona = dr("TipodePersona").ToString
                cTipoDocumento = dr("ccm02tipdocidentidad").ToString
                cRuc = dr("Ruc_Cuenta_Corriente").ToString
                cImporte = dr("importeTotal").ToString
                cApePaterno = dr("ccm02ApePaterno").ToString
                cApeMaterno = dr("ccm02ApeMaterno").ToString
                cPriNombreAux = dr("ccm02Nombres").ToString
                cRazonSocial = dr("ccm02nom").ToString

                If cPriNombreAux <> "" Then
                    If cPriNombreAux.IndexOf(" ") = -1 Then
                        cPriNombre = cPriNombreAux
                        cSegNombre = ""
                    Else
                        cPriNombre = cPriNombreAux.Substring(0, cPriNombreAux.IndexOf(" "))
                        cSegNombre = cPriNombreAux.Substring(cPriNombreAux.IndexOf(" ") + 1)
                    End If
                Else
                    cPriNombre = ""
                    cSegNombre = ""
                End If


                linea = cNumero & Chr(124) & ctipodoc_declarante & Chr(124) & gbRucEmpresa & Chr(124) & _
                    gbano & Chr(124) & cTipPersona & Chr(124) & cTipoDocumento & Chr(124) & cRuc & Chr(124) & _
                    cImporte & Chr(124) & cApePaterno & Chr(124) & cApeMaterno & Chr(124) & cPriNombre & Chr(124) & _
                    cSegNombre & Chr(124) & cRazonSocial & Chr(124)
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
    Private Sub txtPagina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub rbtTipoImpre_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LimpiarValores()
    End Sub

    Private Sub rbtTipoImpre_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LimpiarValores()
    End Sub

    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        If chkVentas.Checked = False Then
            Return

        Else
            Me.TraerAyuda(1, btnhelp_1)
        End If

    End Sub

    Private Sub txtLibrocompra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLibrocompra.KeyDown
        'If e.KeyCode = Keys.Escape Then
        '    If txtLibrocompra.Text = String.Empty Then

        '        lblhelp_0.Text = ""
        '    End If
        'End If

    End Sub

    Private Sub txtLibroventas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLibroventas.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtLibroventas.Text = String.Empty Then

                lblhelp_1.Text = ""
            End If
        End If
    End Sub
End Class