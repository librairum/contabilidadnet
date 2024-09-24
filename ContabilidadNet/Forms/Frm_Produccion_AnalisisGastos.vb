
Option Strict On
Option Explicit On

Public Class Frm_Produccion_AnalisisGastos
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
    Dim contador As Integer = 0
#Region "Base de Datos"
    Sub Traeplancta(ByVal cCampo As String, ByVal cFiltro As String, ByVal nive As Double)
        Dim flag As String

        Try
            ' Abro y asigno los valores del Data Control de Empresas
            flag = If(rbttraecuentas_0.Checked = True, "T", If(rbttraecuentas_1.Checked = True, "G", "D"))

            If nive = 3 Then
                '
                Vista = objSql.TraerDataTable("Spu_Con_Trae_AreaSeccionCcosto", gbcodempresa, gbano, cCampo, cFiltro, nive, flag).DefaultView
                tblPlanCuentas_0.SetDataBinding(Vista, Nothing, True)
                'Bueno lo unica forma de ver las estrellas
                Me.tblPlanCuentas_0.Columns(0).FooterText = "# Registros"
                Me.tblPlanCuentas_0.Columns(1).FooterText = tblPlanCuentas_0.RowCount.ToString
            ElseIf nive = 5 Then
                '
                Vista = objSql.TraerDataTable("Spu_Con_Trae_AreaSeccionCcosto", gbcodempresa, gbano, cCampo, cFiltro, nive, flag).DefaultView
                tblPlanCuentas_1.SetDataBinding(Vista, Nothing, True)
                'Bueno lo unica forma de ver las estrellas
                Me.tblPlanCuentas_1.Columns(0).FooterText = "# Registros"
                Me.tblPlanCuentas_1.Columns(1).FooterText = tblPlanCuentas_0.RowCount.ToString
            ElseIf nive = 7 Then
                '
                Vista = objSql.TraerDataTable("Spu_Con_Trae_AreaSeccionCcosto", gbcodempresa, gbano, cCampo, cFiltro, nive, flag).DefaultView
                tblPlanCuentas_2.SetDataBinding(Vista, Nothing, True)
                'Bueno lo unica forma de ver las estrellas
                Me.tblPlanCuentas_2.Columns(0).FooterText = "# Registros"
                Me.tblPlanCuentas_2.Columns(1).FooterText = tblPlanCuentas_0.RowCount.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeTipgastoygasto(ByVal cCampo As String, ByVal cFiltro As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_TipGastoPlanCta", gbcodempresa, gbano, cCampo, cFiltro).DefaultView
            tblPlanCuentas_3.SetDataBinding(Vista, Nothing, True)

            'If Not IsNothing(tblconsulta.Columns(0)) = True Then
            Me.tblPlanCuentas_3.Columns(0).FooterText = "# Registros"
            Me.tblPlanCuentas_3.Columns(1).FooterText = tblPlanCuentas_0.RowCount.ToString
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub Traegasto(ByVal cCampo As String, ByVal cFiltro As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_GastosPlanCta", gbcodempresa, gbano, cCampo, cFiltro).DefaultView
            tblPlanCuentas_4.SetDataBinding(Vista, Nothing, True)

            'If Not IsNothing(tblconsulta.Columns(0)) = True Then
            Me.tblPlanCuentas_4.Columns(0).FooterText = "# Registros"
            Me.tblPlanCuentas_4.Columns(1).FooterText = tblPlanCuentas_0.RowCount.ToString
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
#Region "Declaraciones"
    Dim mayor, mayor2, mayor3 As Integer
#End Region
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim flagtiporeporte1 As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String
        Dim posi_ini_1, posi_fin_1, posi_ini_2, posi_fin_2, posi_ini_3, posi_fin_3, posi_ini_4, posi_fin_4, posi_ini_5, posi_fin_5 As Integer
        Dim valor1, valor2 As Integer
        Dim flagrep As String

        Dim f_Nivel_area As String = ""
        Dim f_Nivel_Seccion As String = ""
        Dim f_Nivel_Ccosto As String = ""
        Dim f_Nivel_TipoGasto As String = ""
        Dim f_Nivel_Gasto As String = ""

        Dim p_Nivel_3 As String = ""
        Dim p_Nivel_5 As String = ""
        Dim p_Nivel_7 As String = ""
        Dim p_Nivel_9 As String = ""
        Dim p_Nivel_12 As String = ""

        'LLeno el rango de valores
        Try

            Rutareporte = gbRutaReportes
            'Validar titulo
            If txttitulo.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Debe Ingresar el Titulo del Reporte", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            posi_ini_1 = 1 : posi_ini_2 = 1 : posi_ini_3 = 1 : posi_ini_4 = 1 : posi_ini_5 = 1
            posi_fin_1 = 1 : posi_fin_2 = 1 : posi_fin_3 = 1 : posi_fin_4 = 1 : posi_fin_5 = 1

            'Recorro la grilla, busco don esta el area y recupero el nivel
            Me.Llenarordendegrupos()


            'Establecer los valores para pasar las formulas al reporte
            f_Nivel_area = buscarenarray(a, "AREA")
            f_Nivel_area = If(IsNumeric(f_Nivel_area) = False, "-1", f_Nivel_area)

            f_Nivel_Seccion = buscarenarray(a, "Seccion")
            f_Nivel_Seccion = If(IsNumeric(f_Nivel_Seccion) = False, "-1", f_Nivel_Seccion)

            f_Nivel_Ccosto = buscarenarray(a, "C.Costo")
            f_Nivel_Ccosto = If(IsNumeric(f_Nivel_Ccosto) = False, "-1", f_Nivel_Ccosto)

            f_Nivel_TipoGasto = buscarenarray(a, "Tipo Gasto")
            f_Nivel_TipoGasto = If(IsNumeric(f_Nivel_TipoGasto) = False, "-1", f_Nivel_TipoGasto)

            f_Nivel_Gasto = buscarenarray(a, "Gasto")
            f_Nivel_Gasto = If(IsNumeric(f_Nivel_Gasto) = False, "-1", f_Nivel_Gasto)

            Dim sumadeorden As Integer
            sumadeorden = CInt(f_Nivel_area.ToString) + CInt(f_Nivel_Seccion.ToString) + CInt(f_Nivel_Ccosto.ToString) + CInt(f_Nivel_TipoGasto.ToString) + CInt(f_Nivel_Gasto.ToString)

            ' Validar que haya seleccionado alguna Agrupacion
            If (sumadeorden <= -5) Then MessageBox.Show(gbc_MensajeValidar + "No a Selecionado Ninguna Agrupacion", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            'Establecer orden para el Procedimiento Almacenado
            p_Nivel_3 = CStr(If(CInt(f_Nivel_area) <> -1, 1, 0))
            p_Nivel_5 = CStr(If(CInt(f_Nivel_Seccion) <> -1, 2, 0))
            p_Nivel_7 = CStr(If(CInt(f_Nivel_Ccosto) <> -1, 3, 0))
            p_Nivel_9 = CStr(If(CInt(f_Nivel_TipoGasto) <> -1, 4, 0))
            p_Nivel_12 = CStr(If(CInt(f_Nivel_Gasto) <> -1, 5, 0))

            'Determimar el nivel mayor
            If CInt(p_Nivel_3) > CInt(p_Nivel_5) Then
                mayor = CInt(p_Nivel_3)
            Else
                mayor = CInt(p_Nivel_5)
            End If

            If mayor > CInt(p_Nivel_7) Then
                mayor = mayor
            Else
                mayor = CInt(p_Nivel_7)
            End If

            If CInt(p_Nivel_9) > CInt(p_Nivel_12) Then
                mayor2 = CInt(p_Nivel_9)
            Else
                mayor2 = CInt(p_Nivel_12)
            End If
            '=======
            mayor = mayor - 1
            mayor2 = mayor2 - 1

            '======
            If f_Nivel_area = "0" Then ' Si el nivel del area es cero,entonces pa primera agrupacion es de la posicion 1 a 3
                posi_ini_1 = 1 : posi_fin_1 = 3
            ElseIf f_Nivel_area = "1" Then ' Si el nivel del area es "1",entonces pa Segunda posicion agrupacion es de la posicion 1 al 3
                posi_ini_2 = 1 : posi_fin_2 = 3
            ElseIf f_Nivel_area = "2" Then
                posi_ini_3 = 1 : posi_fin_3 = 3
            ElseIf f_Nivel_area = "3" Then
                posi_ini_4 = 1 : posi_fin_4 = 3
            ElseIf f_Nivel_area = "4" Then
                posi_ini_5 = 1 : posi_fin_5 = 3
            End If

            'Seccion :
            If f_Nivel_Seccion = "0" Then
                posi_ini_1 = 1 : posi_fin_1 = 5
            ElseIf f_Nivel_Seccion = "1" Then
                posi_ini_2 = 1 : posi_fin_2 = 5
            ElseIf f_Nivel_Seccion = "2" Then
                posi_ini_3 = 1 : posi_fin_3 = 5
            ElseIf f_Nivel_Seccion = "3" Then
                posi_ini_4 = 1 : posi_fin_4 = 5
            ElseIf f_Nivel_Seccion = "4" Then
                posi_ini_5 = 1 : posi_fin_5 = 5
            End If

            'C.Costo
            If f_Nivel_Ccosto = "0" Then
                posi_ini_1 = 1 : posi_fin_1 = 7
            ElseIf f_Nivel_Ccosto = "1" Then
                posi_ini_2 = 1 : posi_fin_2 = 7
            ElseIf f_Nivel_Ccosto = "2" Then
                posi_ini_3 = 1 : posi_fin_3 = 7
            ElseIf f_Nivel_Ccosto = "3" Then
                posi_ini_4 = 1 : posi_fin_4 = 7
            ElseIf f_Nivel_Ccosto = "4" Then
                posi_ini_5 = 1 : posi_fin_5 = 7
            End If

            'Tipo de gasto
            If f_Nivel_TipoGasto = "0" Then
                posi_ini_1 = 8 : posi_fin_1 = 2
            ElseIf f_Nivel_TipoGasto = "1" Then
                posi_ini_2 = 8 : posi_fin_2 = 2
            ElseIf f_Nivel_TipoGasto = "2" Then
                posi_ini_3 = 8 : posi_fin_3 = 2
            ElseIf f_Nivel_TipoGasto = "3" Then
                posi_ini_4 = 8 : posi_fin_4 = 2
            ElseIf f_Nivel_TipoGasto = "4" Then
                posi_ini_5 = 8 : posi_fin_5 = 2
            End If

            'Gasto
            If f_Nivel_Gasto = "0" Then
                posi_ini_1 = 8 : posi_fin_1 = 5
            ElseIf f_Nivel_Gasto = "1" Then
                posi_ini_2 = 8 : posi_fin_2 = 5
            ElseIf f_Nivel_Gasto = "2" Then
                posi_ini_3 = 8 : posi_fin_3 = 5
            ElseIf f_Nivel_Gasto = "3" Then
                posi_ini_4 = 8 : posi_fin_4 = 5
            ElseIf f_Nivel_Gasto = "4" Then
                posi_ini_5 = 8 : posi_fin_5 = 5
            End If

            '
            flagtiporeporte = "CTAGAS"

            Cursor.Current = Cursors.WaitCursor


            If mayor >= 0 Then
                If mayor = 0 Then 'Insertar Area
                    If tblPlanCuentas_0.SelectedRows.Count > 0 Then
                        'Solo guarda lo selecionado
                        Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblPlanCuentas_0, tblPlanCuentas_0.Columns(0).DataField)
                    Else 'Caso contrario guarda todos
                        Mod_Mantenimiento.InsertarFilas(flagtiporeporte, tblPlanCuentas_0, tblPlanCuentas_0.Columns(0).DataField)
                    End If
                ElseIf mayor = 1 Then 'Insertar Seccion
                    If tblPlanCuentas_1.SelectedRows.Count > 0 Then
                        'Solo guarda lo selecionado
                        Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblPlanCuentas_1, tblPlanCuentas_1.Columns(0).DataField)
                    Else 'Caso contrario guarda todos
                        Mod_Mantenimiento.InsertarFilas(flagtiporeporte, tblPlanCuentas_1, tblPlanCuentas_1.Columns(0).DataField)
                    End If
                ElseIf mayor = 2 Then ' Insertra Ccosto
                    If tblPlanCuentas_2.SelectedRows.Count > 0 Then
                        'Solo guarda lo selecionado
                        Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblPlanCuentas_2, tblPlanCuentas_2.Columns(0).DataField)
                    Else 'Caso contrario guarda todos
                        Mod_Mantenimiento.InsertarFilas(flagtiporeporte, tblPlanCuentas_2, tblPlanCuentas_2.Columns(0).DataField)
                    End If
                End If
            End If
            ' Si no se a seleccionado un tipo de gasto
            flagtiporeporte1 = "CTAGAS1"

            If (mayor2 >= 0) Then
                If mayor2 = 3 Then 'Insertar tipo de gasto
                    If tblPlanCuentas_3.SelectedRows.Count > 0 Then
                        'Solo guarda lo selecionado
                        Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte1, tblPlanCuentas_3, tblPlanCuentas_3.Columns(0).DataField)
                    Else 'Caso contrario guarda todos
                        Mod_Mantenimiento.InsertarFilas(flagtiporeporte1, tblPlanCuentas_3, tblPlanCuentas_3.Columns(0).DataField)
                    End If
                ElseIf mayor2 = 4 Then 'Inserta gastos
                    If tblPlanCuentas_4.SelectedRows.Count > 0 Then
                        'Solo guarda lo selecionado
                        Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte1, tblPlanCuentas_4, tblPlanCuentas_4.Columns(0).DataField)
                    Else 'Caso contrario guarda todos
                        Mod_Mantenimiento.InsertarFilas(flagtiporeporte1, tblPlanCuentas_4, tblPlanCuentas_4.Columns(0).DataField)
                    End If
                End If
            End If

            
            '===
            'Asigno los Valores de Formulas Fijas a Mostrarse en el Reporte
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_ini_1", posi_ini_1))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_fin_1", posi_fin_1))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_ini_2", posi_ini_2))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_fin_2", posi_fin_2))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_ini_3", posi_ini_3))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_fin_3", posi_fin_3))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_ini_4", posi_ini_4))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_fin_4", posi_fin_4))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_ini_5", posi_ini_5))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("posi_fin_5", posi_fin_5))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("titulo", txttitulo.Text))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("almes", CInt(gbmes)))

            '0:3
            '1:5
            '2:7
            'mayor1()
            '3:2
            '4:7
            '=
            valor1 = If(mayor = -1, -1, If(mayor = 0, 3, If(mayor = 1, 5, 7)))
            valor2 = If(mayor2 = -1, -1, If(mayor2 = 3, 2, 5))

            flagrep = If(rbtreporte_0.Checked = True, "M", "A")

            '=====
            If rbtreporte_0.Checked = True Then
                nombredereporte = "Rpt_CostosMultifuncional.Rpt"
            Else
                nombredereporte = "Rpt_CostosMultifuncional_Acum.Rpt"
            End If

            ds = objSql.TraerDataSet("Sp_Con_Rep_GastosPersonal_mes_a_mes", gbcodempresa, gbano, gbNameUser, CStr(valor1), CStr(valor2), flagrep, gbmes).Copy()


            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If

            'Elimnar rango de impresion
            Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte)
            '==
            Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte1)
            '==
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub
    Private Sub Frm_Produccion_AnalisisGastos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Costos y Gastos"
            txttitulo.Text = "DIGITE AQUI EL TITULO DEL REPORTE"
            '
            Mod_Mantenimiento.Formatodegrilla(tblPlanCuentas_0)
            Mod_Mantenimiento.Formatodegrilla(tblPlanCuentas_1)
            Mod_Mantenimiento.Formatodegrilla(tblPlanCuentas_2)
            Mod_Mantenimiento.Formatodegrilla(tblPlanCuentas_3)
            Mod_Mantenimiento.Formatodegrilla(tblPlanCuentas_4)
            '
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_1, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_2, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_3, gbc_Ttp_SelecTodasFilas)
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_4, gbc_Ttp_SelecTodasFilas)
            '==
            mayor = -1
            mayor2 = -1

            ' Abro y asigno los valores del Data Control de Cuentas
            Me.Traeplancta("ccm01cta", "*", 3)
            Me.Traeplancta("ccm01cta", "*", 5)
            Me.Traeplancta("ccm01cta", "*", 7)

            'Abro y asigno los valores del Data Control de Cuentas
            Me.TraeTipgastoygasto("cctcodigo", "*")
            Me.Traegasto("ccgcodigo", "*")
            'Call sstabareas_Click(sstabareas.Tab)
            txttitulo.Text = "Digite aqui el titulo del reporte"
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

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblPlanCuentas_0.AfterFilter
        Me.tblPlanCuentas_0.Columns(1).FooterText = tblPlanCuentas_0.RowCount.ToString
    End Sub
    Private Sub tabareas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabareas.Click
        If tabareas.SelectedIndex = mayor Then
            tabareas.SelectTab(mayor)
        Else
            mayor3 = tabareas.SelectedIndex
        End If
    End Sub
    Sub Llenarordendegrupos()
        Dim contadorparsal As Integer = 0
        Try
            'Limpio Array
            Array.Clear(a, 0, 20)
            'Vuelvo a llenar
            For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In tblagrupa.GroupedColumns
                a.SetValue(col.Caption, 0, contadorparsal)              'Agrego nombre del parametro
                a.SetValue(contadorparsal, 1, contadorparsal)           'Agrego valor del parametro
                contadorparsal = contadorparsal + 1
            Next
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function buscarenarray(ByVal array As Array, ByVal valorabuscar As String) As String
        'Recorro la grilla, busco donde esta el area y recupero el nivel
        Dim i As Integer
        buscarenarray = ""
        Try
            For i = 0 To 9
                If CType(a.GetValue(0, i), String) Is Nothing Then
                    Exit For
                Else
                    If a.GetValue(0, i).ToString.ToUpper.Trim = valorabuscar.ToUpper.Trim Then
                        buscarenarray = a.GetValue(1, i).ToString
                    End If
                End If
            Next
        Catch ex As Exception
            buscarenarray = ""
        End Try
    End Function
    Private Sub rbttraecuentas_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbttraecuentas_0.Click, rbttraecuentas_1.Click, rbttraecuentas_2.Click
        '
        Me.Traeplancta("ccm01cta", "*", 3)
        Me.Traeplancta("ccm01cta", "*", 5)
        Me.Traeplancta("ccm01cta", "*", 7)
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblPlanCuentas_0)
    End Sub
    Private Sub btnseleccionartodo_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_1.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblPlanCuentas_1)
    End Sub
    Private Sub btnseleccionartodo_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_2.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblPlanCuentas_2)
    End Sub
    Private Sub btnseleccionartodo_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_3.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblPlanCuentas_3)
    End Sub
    Private Sub btnseleccionartodo_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_4.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblPlanCuentas_4)
    End Sub
    Sub ActivarTab()
        Dim contadorparsal As Integer = 0
        Dim Mayortabccosto As String = ""
        Dim Mayortabgasto As String = ""
        Try

            'Determinar orden de las posiciones
            For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In tblagrupa.GroupedColumns

                If (col.Caption.ToUpper = "AREA" Or col.Caption.ToUpper = "SECCION" Or col.Caption.ToUpper = "C.COSTO") Then
                    Mayortabccosto = col.Caption.ToUpper
                End If

                If (col.Caption.ToUpper = "TIPO GASTO" Or col.Caption.ToUpper = "GASTO") Then
                    Mayortabgasto = col.Caption.ToUpper
                End If
            Next


            Select Case Mayortabccosto
                Case "AREA"
                    tabareas.SelectedTab = TabPage1
                Case "SECCION"
                    tabareas.SelectedTab = TabPage2
                Case "C.COSTO"
                    tabareas.SelectedTab = TabPage3
            End Select

            Select Case Mayortabgasto
                Case "TIPO GASTO"
                    tabgastos.SelectedTab = TabPage4
                Case "GASTO"
                    tabgastos.SelectedTab = TabPage5
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblagrupa_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tblagrupa.Paint
        ActivarTab()
    End Sub

    Private Sub tblPlanCuentas_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblPlanCuentas_0.Click

    End Sub

    Private Sub tblPlanCuentas_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblPlanCuentas_3.Click

    End Sub

    Private Sub tblPlanCuentas_3_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblPlanCuentas_3.RowColChange

    End Sub
End Class