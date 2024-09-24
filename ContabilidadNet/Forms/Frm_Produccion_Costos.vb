Option Strict On
Option Explicit On
Public Class Frm_Produccion_Costos

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Private Sub CargaEstrucCostos(ByVal tipo As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ccr01EstCostos", gbcodempresa, gbano, tipo).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)

            'If Not IsNothing(tblconsulta.Columns(0)) = True Then
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            'End If

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
        Dim mesdecostos As String

        Dim tipo As String
        mesdecostos = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        tipo = If(rbtEstado_0.Checked = True, "F", "V")

        'LLeno el rango de valores
        Try
            Rutareporte = gbRutaReportes
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count < 0 Then
                MessageBox.Show("AVISO :: No exiten registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            If rbttiprepcosto_1.Checked = True Then
                If rbtMoneda_0.Checked = True Then
                    If rbtEstado_0.Checked = True Then
                        If rbtOpcion_1.Checked = True Then
                            nombredereporte = "repgastosycostos_mina.Rpt"
                        Else
                            nombredereporte = "RepGastosyCostos.Rpt"
                        End If
                    Else
                        nombredereporte = "RepGastosyCostos.Rpt"
                    End If
                Else
                    If rbtEstado_0.Checked = True Then
                        If rbtOpcion_1.Checked = True Then
                            nombredereporte = "repgastosycostos_mina_Sol.Rpt"
                        Else
                            nombredereporte = "RepGastosyCostos_Sol.Rpt"
                        End If
                    Else
                        nombredereporte = "RepGastosyCostos_Sol.Rpt"
                    End If
                End If
                ds = objSql.TraerDataSet("Spu_Con_rep_GastosYCostos", gbcodempresa, gbano, mesdecostos, tipo).Copy()

                ' Asigno los Valores de Formulas Fijas a Mostrarse en el Reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("periodo", cboperiodos.Text))
            Else
                nombredereporte = "repgastosycostos_PorMes.Rpt"
                ds = objSql.TraerDataSet("Spu_Con_rep_GastosYCostos_PorMeses", gbcodempresa, gbano, tipo, mesdecostos).Copy()

                ' Asigno los Valores de Formulas Fijas a Mostrarse en el Reporte
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("periodo", cboperiodos.Text))
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
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub Frm_Produccion_Costos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Costos y Gastos"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btndatosproducion, "Registrar Tonelaje y Tipos de Cambio")

            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
            cboperiodos.SelectedIndex = CType(gbmes, Integer)
            '
            Me.CargaEstrucCostos("F")
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

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub rbtEstado_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtEstado_0.Click
        ' Coloco el Titulo a la grilla
        Call CargaEstrucCostos("F")
    End Sub

    Private Sub rbtEstado_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtEstado_1.Click
        Call CargaEstrucCostos("V")
    End Sub

    Private Sub btndatosproducion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndatosproducion.Click
        If Funciones.Funciones.FormIsOpen("Frm_Produccion_Datos") Then Exit Sub
        Dim _Frm_Produccion_Datos As New Frm_Produccion_Datos

        Try
            _Frm_Produccion_Datos.MdiParent = MDIPrincipal.ParentForm
            _Frm_Produccion_Datos.Owner = Me
            _Frm_Produccion_Datos.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class