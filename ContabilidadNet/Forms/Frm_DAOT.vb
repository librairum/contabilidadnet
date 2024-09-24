Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_DAOT
#Region "Declaraciones"
    Dim VistaHelp As DataView
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#End Region
#Region "Base de datos"
    Private Sub traer_libros()
        Dim tipolibro As String


        Try
            If rbtTipoImpre_0.Checked = True Then
                tipolibro = "C"
            Else
                tipolibro = "V"
            End If

            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Por_Tipo", gbcodempresa, gbano, "ccb02cod", "*", tipolibro).DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Mantenimiento"
    Sub LimpiarValores()
        txtLibro.Text = "" : lblhelp_0.Text = ""
        txtuits.Text = "0"
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

    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String = ""
        Dim Rutareporte As String

        'LLeno el rango de valores
        Try
       
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '========================================
            If rbtTipoImpre_0.Checked = True Then
                nombredereporte = "Rpt_RankigProv.Rpt"
                ds = objSql.TraerDataSet("Spu_Con_Rep_RankigProv", gbcodempresa, gbano, txtLibro.Text, gbmoneda).Copy()


                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            ElseIf rbtTipoImpre_1.Checked = True Then
                nombredereporte = "Rpt_RankingClientes.rpt"
                ds = objSql.TraerDataSet("Spu_Con_Rep_RankigClientes", gbcodempresa, gbano, txtLibro.Text, gbmoneda).Copy()

                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            End If

            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If
            '===
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
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
        Me.TraerAyuda(0, btnhelp_0)
    End Sub
    Private Sub Frm_LibroDiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Text = "Ranking de Clientes/Proveedores"
            'Llena combo 

            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnexportar, "Generar Archivo para PDT")

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
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

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        If rbtTipoImpre_0.Checked = True Then
            Me.ExportarCostos()
        Else
            Me.ExportarIngresos()
        End If

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
            dt = objSql.TraerDataSet("Spu_Con_Trae_DAOT", gbcodempresa, gbano, txtLibro.Text, gbmoneda, txtuits.Text)


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
            dt = objSql.TraerDataSet("Spu_Con_Trae_DAOTIngresos", gbcodempresa, gbano, txtLibro.Text, gbmoneda, txtuits.Text)


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
    Private Sub txtPagina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuits.TextChanged

    End Sub

    Private Sub rbtTipoImpre_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoImpre_0.CheckedChanged
        Me.LimpiarValores()
    End Sub

    Private Sub rbtTipoImpre_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoImpre_1.CheckedChanged
        Me.LimpiarValores()
    End Sub
End Class