
Option Strict On
Option Explicit On
Public Class Frm_RankingCtaCte
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
                ds = objSql.TraerDataSet("Spu_Con_Rep_RankigProv", gbcodempresa, gbano, txtLibro.Text, gbmoneda, "01", gbmes).Copy()
                '01 = Siempre inicia de enero
                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("TipoMoneda", gbmoneda))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + " - " + gbmes))

            ElseIf rbtTipoImpre_1.Checked = True Then
                nombredereporte = "Rpt_RankingClientes.rpt"
                ds = objSql.TraerDataSet("Spu_Con_Rep_RankigClientes", gbcodempresa, gbano, txtLibro.Text, gbmoneda).Copy()

                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("TipoMoneda", gbmoneda))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + " - " + gbmes))
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
End Class