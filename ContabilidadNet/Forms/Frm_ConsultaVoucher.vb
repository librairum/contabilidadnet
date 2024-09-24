Option Strict On
Option Explicit On

Public Class Frm_ConsultaVoucher
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Private Sub Traectas()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Help_Cuentas_Todas", gbcodempresa, gbano, "", "*").DefaultView
            tblconsulta_1.SetDataBinding(Vista, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraeVoucher()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Vouchers", gbcodempresa, gbano, gbmes, "ALL", "ccc01subd, ccc01numer", "*", "").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""


        Try
            If tabOpciones.SelectedIndex = 0 Then 'Vouchers

                'Validar()
                If txtTitulo.Text.Trim = "" Then MessageBox.Show("VALIDAR:: Ingrese un titulo", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                '
                flagtiporeporte = "CONVOUCOMP"
                If tblconsulta.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas2col(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField, tblconsulta.Columns(1).DataField)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

                If chkglosa.Checked = True Then
                    nombredereporte = "MovVoVou_glosa.Rpt"
                    ds = objSql.TraerDataSet("Sp_Con_Rep_VoucherGlosa", gbcodempresa, gbano, gbmes, gbmoneda, gbNameUser).Copy()
                Else
                    nombredereporte = "MovVoVou.Rpt"
                    ds = objSql.TraerDataSet("sp_Con_Rep_CsVoucher_Comprob", gbcodempresa, gbano, gbmes, gbmoneda, gbNameUser).Copy()
                End If

                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbmes))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Titulo", txtTitulo.Text))

            ElseIf tabOpciones.SelectedIndex = 1 Then 'Cuentas

                If (IsDate(mskfechaini.Text) = False Or IsDate(mskfechafin.Text) = False) Then MessageBox.Show("VALIDAR:: Fechas no validas", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

                nombredereporte = "MovVoCta.Rpt"
                flagtiporeporte = "CONVOUCUEN"
                If tblconsulta_1.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta_1, tblconsulta_1.Columns(0).DataField)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
                ds = objSql.TraerDataSet("sp_Con_Rep_CsVoucher_Cuentas", gbcodempresa, gbmoneda, mskfechaini.Text, mskfechafin.Text, gbNameUser).Copy()

                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbmes))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Titulo", txtTitulo.Text))
            End If

            Rutareporte = gbRutaReportes

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
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""
        Dim Periodo As String = ""


        Try
            Rutareporte = gbRutaReportes
            Periodo = gbano + gbmes

            If tabOpciones.SelectedIndex = 0 Then 'Vouchers

                'Validar()
                If txtTitulo.Text.Trim = "" Then MessageBox.Show("VALIDAR:: Ingrese un titulo", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                '
                flagtiporeporte = "CONVOUCOMP"
                If tblconsulta.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas2col(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField, tblconsulta.Columns(1).DataField)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

                If chkglosa.Checked = True Then
                    nombredereporte = "MovVoVou_glosa.Rpt"
                    ds = objSql.TraerDataSet("Sp_Con_Rep_VoucherGlosa", gbcodempresa, gbano, gbmes, gbmoneda, gbNameUser).Copy()
                Else
                    nombredereporte = "MovVoVou.Rpt"
                    ds = objSql.TraerDataSet("sp_Con_Rep_CsVoucher_Comprob", gbcodempresa, gbano, gbmes, gbmoneda, gbNameUser).Copy()
                End If

                'Formulas de reporte
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", Periodo))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", txtTitulo.Text))

            ElseIf tabOpciones.SelectedIndex = 1 Then 'Cuentas

                If (IsDate(mskfechaini.Text) = False Or IsDate(mskfechafin.Text) = False) Then MessageBox.Show("VALIDAR:: Fechas no validas", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

                nombredereporte = "MovVoCta.Rpt"
                ds = objSql.TraerDataSet("sp_Con_Rep_CsVoucher_Cuentas", gbcodempresa, gbmoneda, mskfechaini.Text, mskfechafin.Text, gbNameUser).Copy()

                flagtiporeporte = "CONVOUCUEN"
                If tblconsulta_1.SelectedRows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta_1, tblconsulta_1.Columns(0).DataField)
                Else
                    MessageBox.Show("VALIDAR :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                'arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("RucEmpresa", gbRucEmpresa))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", Periodo))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contabilidad", gbmoneda))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", txtTitulo.Text))
            End If

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

    Private Sub Frm_ConsultaVoucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_1, gbc_Ttp_SelecTodasFilas)
            '
            Me.Text = "Consultas de movimientos"

            Me.Traectas()
            Me.TraeVoucher()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    
    Private Sub mskfechaini_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskfechaini.MaskInputRejected

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub



    Private Sub tblconsulta_1_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta_1.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta_1.Click

    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub

    Private Sub btnseleccionartodo_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_1.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta_1)
    End Sub
End Class