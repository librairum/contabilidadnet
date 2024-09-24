Option Strict On
Option Explicit On
Imports System.IO
Public Class Frm_VoucherArchivoPlano

    Dim Vista As New DataView
    Dim Vista1 As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer

    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)

        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim nombreperinicio As String
        Dim nombreperfinal As String
        Dim perinicio As String
        Dim perfinal As String


        'LLeno el rango de valores
        Try
            'Validaciones
        
            perinicio = Funciones.Funciones.derecha(cboPerini.SelectedValue.ToString, 2)
            perfinal = Funciones.Funciones.derecha(cboPerfin.SelectedValue.ToString, 2)

            If perinicio = "" Then Beep() : MessageBox.Show("Periodo Final NO valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : cboPerini.Focus() : Exit Sub
            If perfinal = "" Then Beep() : MessageBox.Show("Periodo Inicio NO válido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : cboPerfin.Focus() : Exit Sub

            nombreperinicio = gbano + "-" + perinicio
            nombreperfinal = gbano + "-" + perfinal
            'Rutareporte = gbRutaAplicacion + "\reports\"
            Rutareporte = gbRutaReportes()
            Cursor.Current = Cursors.WaitCursor

            ' Asigno el Nombre del Reporte
            nombredereporte = "Rep_VoucherConDet.Rpt"

            ds = objSql.TraerDataSet("Spu_Con_Rep_ccd", gbcodempresa, gbano, "*", "*", "*", "*", perinicio, perfinal).Copy()

            'Formulas de reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("perinicio", nombreperinicio))
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("perfinal", nombreperfinal))

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
    Private Sub Frm_VoucherArchivoPlano_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nivel As Integer = 2
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Voucher Archivo Plano"
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboPerini, gbcodempresa, gbano)
            Mod_BaseDatos.LlenarComboPeriodos(cboPerfin, gbcodempresa, gbano)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub btvistaprevia_Click(sender As System.Object, e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub
End Class