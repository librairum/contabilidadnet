Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_RegComprasAnual
#Region "Declaraciones"
    Dim VistaHelp As DataView
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
    Private Sub Frm_RegComprasAnual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sstabregcompras.TabIndex = 0
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
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
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub

    Private Sub txtLibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLibro.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New Ks.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of Ks.Com.Win.CystalReports.Net.FormulasReportes)

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

            nombreper = "PERIODO : " + gbano

            'Rutareporte = gbRutaAplicacion + "\reports\"
            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor

            ' Asigno el Nombre del Reporte
            nombredereporte = "regcompr_new_a3_Anual.rpt"
            flagordena = "1"
            flagfiltro = "*"

            
            ds = objSql.TraerDataSet("Sp_Con_Rep_RegistroCompras_anual", gbcodempresa, gbano, gbmes, txtLibro.Text.Trim, flagordena, flagfiltro, gbmoneda).Copy()

            'Formulas de reporte
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Pagina", CType(txtPagina.Text, Integer)))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("nro_formulario", txtnroformulario.Text.Trim))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("nro_orden", txtnroorden.Text.Trim))

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
 
End Class