Option Strict On
Option Explicit On
Public Class Frm_BalanceComprobacion

    Private Sub Frm_BalanceComprobacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nivel As Integer = 2
        Try

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Balance de comprobacion"
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Mod_BaseDatos.LlenarComboPeriodos(cboPeriodos, gbcodempresa, gbano)
            cboPeriodos.SelectedIndex = CType(gbmes, Integer)
            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim flagmovimiento As String
        Dim nivel As Integer
        Dim mesdebalcom As String = ""
        Dim mesdebalcomDes As String = ""
        Dim titulobalcom As String = ""
        Dim fechabalcom As String = ""
        'LLeno el rango de valores
        Try
            mesdebalcom = Funciones.Funciones.derecha(cboPeriodos.SelectedValue.ToString, 2)
            mesdebalcomDes = cboPeriodos.SelectedValue.ToString

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            flagmovimiento = If(chkMovim.Checked = True, "S", "N")
            nivel = CType(If(IsNumeric(cbonivel.Text) = True, cbonivel.Text, "18"), Integer)
            If rdbTipoBalance_0.Checked = True Then
                nombredereporte = If(gbTipoImpresora = "I", "BalCompr_tr.rpt", "BalCompr.rpt")
                ds = objSql.TraerDataSet("sp_Con_Rep_BalanceResultados", gbcodempresa, gbano, mesdebalcom, gbmoneda, flagmovimiento, nivel, gbSaldos).Copy()
            Else
                nombredereporte = If(gbTipoImpresora = "I", "BalComTr_it.rpt", "BalComTr.rpt")
                ds = objSql.TraerDataSet("sp_Con_Rep_BalanceAnalitico", gbcodempresa, gbano, mesdebalcom, gbmoneda, flagmovimiento, nivel).Copy()
            End If

            'Formulas de reporte
            titulobalcom = "BALANCE DE COMPROBACION"
            fechabalcom = "Al " + Funciones.Funciones.NumeroDiasMes(mesdebalcom, gbano) + "/" + mesdebalcom + "/" + gbano

            '
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", mesdebalcomDes))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Titulo", titulobalcom))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Fecha", fechabalcom))

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
        Dim flagmovimiento As String
        Dim nivel As Integer
        Dim mesdebalcom As String = ""
        Dim mesdebalcomDes As String = ""
        Dim titulobalcom As String = ""
        Dim fechabalcom As String = ""
        'LLeno el rango de valores
        Try
            'Destino del reporte

            mesdebalcom = Funciones.Funciones.derecha(cboPeriodos.SelectedValue.ToString, 2)
            mesdebalcomDes = cboPeriodos.SelectedValue.ToString

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            flagmovimiento = If(chkMovim.Checked = True, "S", "N")
            nivel = CType(If(IsNumeric(cbonivel.Text) = True, cbonivel.Text, "18"), Integer)

            'Formulas de reporte
            titulobalcom = "BALANCE DE COMPROBACION"
            fechabalcom = "Al " + Funciones.Funciones.NumeroDiasMes(mesdebalcom, gbano) + "/" + mesdebalcom + "/" + gbano

            If rdbTipoBalance_0.Checked = True Then
                nombredereporte = If(gbTipoImpresora = "I", "BalCompr_it.rpt", "BalCompr.rpt")
                ds = objSql.TraerDataSet("sp_Con_Rep_BalanceResultados", gbcodempresa, gbano, mesdebalcom, gbmoneda, flagmovimiento, CStr(nivel), gbSaldos).Copy()
                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", mesdebalcomDes))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", titulobalcom))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Fecha", fechabalcom))
            Else
                nombredereporte = If(gbTipoImpresora = "I", "BalComTr_it.rpt", "BalComTr.rpt")
                '
                ds = objSql.TraerDataSet("sp_Con_Rep_BalanceAnalitico", gbcodempresa, gbano, mesdebalcom, gbmoneda, flagmovimiento, CStr(nivel), gbSaldos).Copy()
                'Formulas de reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", mesdebalcomDes))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", titulobalcom))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Fecha", fechabalcom))

            End If

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
End Class