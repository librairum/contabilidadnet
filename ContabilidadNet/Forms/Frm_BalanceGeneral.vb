Option Strict On
Option Explicit On
Public Class Frm_BalanceGeneral

    Private Sub Frm_BalanceGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Balance General"
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Mod_BaseDatos.LlenarComboPeriodos(cboPeriodos, gbcodempresa, gbano)

            cboPeriodos.SelectedIndex = CType(gbmes, Integer)
            rbtformato_1.Checked = True
            btnConfigurar.Enabled = True

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
        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            If gbAjuste = "N" Then
                nombredereporte = If(gbTipoImpresora = "I", "balGener_it.rpt", "balGener.rpt")
            Else
                nombredereporte = "balGenAj.rpt"
            End If

            'Data del reporte
            ds = objSql.TraerDataSet("sp_Con_Rep_BalanceGeneral", gbcodempresa, gbano, gbmes, gbmoneda, gbSaldos).Copy()

            'Formulas de reporte
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            'arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Direccion", gbDirEmpresa$))
            'arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbmes))
            'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", gbRucEmpresa))
            'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
            'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
            'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
            'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa))

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
        Dim mesbalance As String
        Dim AnioBalAnt As String
        'LLeno el rango de valores
        Try
            mesbalance = Funciones.Funciones.derecha(cboPeriodos.SelectedValue.ToString, 2)
            AnioBalAnt = CStr(CInt(gbano) - 1)

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            ' Asigno el Nombre del Reporte
            '
            If rbtformato_1.Checked = True Then
                nombredereporte = If(gbTipoImpresora = "I", "Rpt_Balance.Rpt", "Rpt_Balance_carta.Rpt")

                'Data del reporte
                ds = objSql.TraerDataSet("Spu_Con_Rep_BalGenCom", gbcodempresa, gbano, mesbalance, AnioBalAnt, gbmoneda).Copy()

                'Formulas de reporte
                Dim Fecha_balance As String
                Fecha_balance = Funciones.Funciones.Formatofechacontable(mesbalance, gbano)

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("fecha", Fecha_balance))

                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Anio", gbano))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Mes", mesbalance))
                arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("AnioAnt", AnioBalAnt))

            ElseIf rbtformato_1_PLE.Checked = True Then
                nombredereporte = If(gbTipoImpresora = "I", "Rpt_BalanceCom_PLE.Rpt", "Rpt_Balance_carta.Rpt")

                'Data del reporte
                ds = objSql.TraerDataSet("Spu_Con_Rep_BalGenCom_PLE", gbcodempresa, gbano, mesbalance, AnioBalAnt, gbmoneda).Copy()

                'Formulas de reporte
                Dim Fecha_balance As String
                Fecha_balance = Funciones.Funciones.Formatofechacontable(mesbalance, gbano)

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("fecha", Fecha_balance))

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Anio", gbano))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Mes", mesbalance))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("AnioAnt", AnioBalAnt))
         

            ElseIf rbtformato_0.Checked = True Then

                nombredereporte = If(gbTipoImpresora = "I", "Balance.Rpt", "Balance.Rpt")
                'Data del reporte
                ds = objSql.TraerDataSet("Spu_Con_Rep_BalGenCom", gbcodempresa, gbano, mesbalance, AnioBalAnt, gbmoneda).Copy()

                'Formulas de reporte
                Dim Fecha_balance As String
                Fecha_balance = Funciones.Funciones.Formatofechacontable(mesbalance, gbano)
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("fecha", Fecha_balance))
                '
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Anio", gbano))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Mes", mesbalance))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("AnioAnt", AnioBalAnt))
                '
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

    Private Sub btnConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigurar.Click


        Try
            If Funciones.Funciones.FormIsOpen("Frm_BalanceGeneral_Conf") Then Exit Sub
            Dim _Frm_BalanceGeneral_Conf As New Frm_BalanceGeneral_Conf
            _Frm_BalanceGeneral_Conf.MdiParent = MDIPrincipal.ParentForm
            _Frm_BalanceGeneral_Conf.Owner = Me
            _Frm_BalanceGeneral_Conf.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub rbtformato_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtformato_1.CheckedChanged
        'Capturar el valor del check
        If rbtformato_0.Checked = False Then
            btnConfigurar.Enabled = True
        Else
            btnConfigurar.Enabled = False
        End If

      
    End Sub

    Private Sub btnConfigurarPLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigurarPLE.Click
        If Funciones.Funciones.FormIsOpen("Frm_BalanceGeneral_Conf_PLE") Then Exit Sub
        Dim _Frm_BalanceGeneral_Conf_PLE As New Frm_BalanceGeneral_Conf_PLE

        Try
            _Frm_BalanceGeneral_Conf_PLE.MdiParent = MDIPrincipal.ParentForm
            _Frm_BalanceGeneral_Conf_PLE.Owner = Me
            _Frm_BalanceGeneral_Conf_PLE.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class