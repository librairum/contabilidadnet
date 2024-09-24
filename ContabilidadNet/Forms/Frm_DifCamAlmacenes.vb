
Option Strict On
Option Explicit On
Public Class Frm_DifCamAlmacenes

    Private Sub Frm_DifCamAlmacenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Diferencia de cambio - almacenes"
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesbalance As String
        Dim nombreper As String
        'LLeno el rango de valores
        Try
            'Destino del reporte
            mesbalance = gbmes

            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then Exit Sub

            nombreper = "PERIODO : " + gbano + "-" + gbmes

            Rutareporte = gbRutaReportes

            Cursor.Current = Cursors.WaitCursor
            nombredereporte = "Rpt_DifCamAlmacenes.rpt"
            ds = objSql.TraerDataSet("Spu_Con_Rep_DifCambioAlmacenes", gbcodempresa, gbano, mesbalance, txtTipCambio.Text).Copy()

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", nombreper))

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

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub mskfecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskfecha.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskfecha.LostFocus
        txtTipCambio.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "C")
    End Sub

    Private Sub mskfecha_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskfecha.MaskInputRejected

    End Sub
End Class