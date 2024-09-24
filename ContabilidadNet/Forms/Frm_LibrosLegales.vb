Option Strict On
Option Explicit On

Imports System.IO
'LIBROS LEGALES - WILLIAM
Public Class Frm_LibrosLegales
#Region "Declaraciones"
    Dim ctaselec As String = ""
    'Dim libro31 As String = rbtrepauxiliares_1.Text
#End Region
#Region "Base Datos"
    Public Shared Function TraeValorCuentas(ByVal MesCosto As String, ByVal CuentaCosto As String) As Double
        Dim tablaDet As DataTable
        Try
            'Trae detalle de asiento tipo
            tablaDet = objSql.TraerDataTable("Spu_Con_Trae_ImpxCta", gbcodempresa, gbano, MesCosto, CuentaCosto)

            'Recorrro la tabla traido y le actualizo los valores calculados segun las formulas
            For Each fila As DataRow In tablaDet.Rows
                TraeValorCuentas = CDbl(fila("importe").ToString.ToUpper)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

#End Region
    ' Función para contar la cantidad de CheckBox marcados
    Private Function ContarCheckBoxMarcados(ByVal tabPage As TabPage) As Integer
        Dim contador As Integer = 0
        Dim checkBoxes As New List(Of CheckBox)
        ' Verificar si el TabPage no es nulo
        If tabPage IsNot Nothing Then
            ' Recorrer los controles dentro del TabPage
           For Each control As Control In tabPage.Controls
                If TypeOf control Is CheckBox Then
                    'checkBoxes.Add(DirectCast(control, CheckBox).Checked)
                    If TypeOf control Is CheckBox AndAlso control IsNot checkBoxes AndAlso DirectCast(control, CheckBox).Checked Then
                        contador += 1
                    End If
                End If
            Next
        End If
        Return contador

    End Function
    Sub imprimir_verant(ByVal flagimpresion As String)

        Dim tabPageActual As TabPage = tbcliblegales.SelectedTab

        'VALIDAR SI TIENE MAS DE 2 CHECKBOX ACTIVOS'
        Dim contador = ContarCheckBoxMarcados(tabPageActual)

        If tabPageActual.Name = "TabPage2" Then
            If contador <> 1 Then
                MessageBox.Show("Para visualizar un Reporte, tiene que seleccionar solo un Libro", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        'If contador > 1 Then
        '    MessageBox.Show("Para visualizar un Reporte, tiene que seleccionar solo un Libro", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'ElseIf contador = 0 Then
        '    MessageBox.Show("ERROR:: Seleccione un libro para visualizar un reporte", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If


        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String = ""
        Dim MesReporte As String = ""
        Dim cuenta As String = ""

        Dim nivel As Integer
        Dim PeriodoPenPago As String

        'Variables para reporte de costos
        Dim MesCostoIni As String = ""
        Dim MesCostoFin As String = ""
        Dim prodter_ini As Double = 0
        Dim prodter_Fin As Double = 0
        Dim prodProcMina_Ini As Double = 0
        Dim prodProcMina_Fin As Double = 0
        Dim prodProcPlanta_Ini As Double = 0
        Dim prodProcPLanta_Fin As Double = 0

        Dim mesbalance As String
        Dim AnioBalAnt As String

        Dim ajusinviniprodproc As Double = 0
        Dim ajusinviniprodterm As Double = 0

        Try

            Cursor.Current = Cursors.WaitCursor
            If (rbttipolibro_0.Enabled = False And rbttipolibro_1.Enabled = False) Then Cursor.Current = Cursors.Default : Exit Sub
            ' Direcciono la Salida hacia Impresora o Pantalla

            Rutareporte = gbRutaReportes()
            ' Obtengo el Mes seleccionado


            Select Case tbcliblegales.SelectedIndex
                Case 0
                    'No hay nada
                Case 1
                    MesReporte = Funciones.Funciones.derecha(cboPeriodos.SelectedValue.ToString, 2)
                    If rbtrepauxiliares_1.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_BalanceCom_PLE_31.Rpt", "Rpt_BalanceCom_PLE_31.Rpt")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_BalGenCom_PLE", gbcodempresa, gbano, MesReporte, gbano, gbmoneda).Copy()
                        'El año anterior pero parael legal no se usa
                        mesbalance = Funciones.Funciones.derecha(cboPeriodos.SelectedValue.ToString, 2)
                        AnioBalAnt = CStr(CInt(gbano) - 1)
                        'Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        Dim Fecha_balance As String
                        Fecha_balance = Funciones.Funciones.Formatofechacontable(MesReporte, gbano)
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
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_1.Text))

                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("fecha", Fecha_balance))
                        ''
                    ElseIf rbtrepauxiliares_2.Checked = True Then
                        'Libro 3.2
                        'Cuenta 10 Caja Bancos
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal32.rpt", "")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_32_Saldo10", gbcodempresa, gbano, gbmes, "10").Copy()
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_2.Text))
                    ElseIf rbtrepauxiliares_3.Checked = True Then
                        'Cuenta 12 -
                        'If rbttipolibro_0.Checked = True Then
                        ' Asigno el Nombre del Reporte
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal33.rpt", "")
                        cuenta = "12"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, cuenta).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_3.Text))

                    ElseIf rbtrepauxiliares_4.Checked = True Then
                        'Cuenta 14 -
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal34.rpt", "")
                        cuenta = "14"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, cuenta).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_4.Text))


                    ElseIf rbtrepauxiliares_5.Checked = True Then

                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal35.rpt", "")


                        cuenta = "16"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, cuenta).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_5.Text))

                        'ElseIf rbtrepauxiliares_51.Checked = True Then
                        '    If rbttipolibro_0.Checked = True Then
                        '        ' Asigno el Nombre del Reporte
                        '        nombredereporte = If(gbTipoImpresora = "I", "Rpt_AuxLibInvBalCtaCte_Res.rpt", "Rpt_AuxLibInvBalCtaCte_Res.rpt")

                        '    Else
                        '        nombredereporte = If(gbTipoImpresora = "I", "Rpt_AuxLibInvBalCtaCte.rpt", "Rpt_AuxLibInvBalCtaCte.rpt")

                        '    End If
                        '    cuenta = "17"
                        '    ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal", gbcodempresa, gbano, cuenta, MesReporte).Copy()

                        '    ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("cuenta", cuenta))

                    ElseIf rbtrepauxiliares_6.Checked = True Then
                        '=====Libro 3.7

                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal36.rpt", "")


                        cuenta = "19"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE ", gbcodempresa, gbano, gbmes, cuenta).Copy()
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_6.Text))


                    ElseIf rbtrepauxiliares_7.Checked = True Then
                        '=====Libro 3.8
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal37.rpt", "")
                        cuenta = "19"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_37_Saldo2021", gbcodempresa, gbano, gbmes).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_7.Text))


                    ElseIf rbtrepauxiliares_8.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal38.rpt", "")
                        cuenta = "19"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_38_Saldo3031", gbcodempresa, gbano, gbmes).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_8.Text))


                    ElseIf rbtrepauxiliares_9.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal39.rpt", "")
                        cuenta = "19"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_39_Saldo34", gbcodempresa, gbano, gbmes).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_9.Text))


                    ElseIf rbtrepauxiliares_10.Checked = True Then
                        MessageBox.Show("Libro Anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Cursor.Current = Cursors.Default : Exit Sub
                    ElseIf rbtrepauxiliares_11.Checked = True Then
                        'cuenta 41
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_libInvBal311.rpt", "")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_311_Saldo41", gbcodempresa, gbano, gbmes).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_11.Text))

                    ElseIf rbtrepauxiliares_12.Checked = True Then
                        'cuenta 42

                        ' Asigno el Nombre del Reporte
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_libInvBal312.rpt", "")

                        cuenta = "42"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, cuenta).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_12.Text))

                        'ElseIf rbtrepauxiliares_121.Checked = True Then
                        '    'cuenta 42
                        '    If rbttipolibro_0.Checked = True Then
                        '        ' Asigno el Nombre del Reporte
                        '        nombredereporte = If(gbTipoImpresora = "I", "Rpt_AuxLibInvBalCtaCte_Res.rpt", "Rpt_AuxLibInvBalCtaCte_Res.rpt")

                        '    Else
                        '        nombredereporte = If(gbTipoImpresora = "I", "Rpt_AuxLibInvBalCtaCte.rpt", "Rpt_AuxLibInvBalCtaCte.rpt")

                        '    End If

                        '    cuenta = "43"
                        '    ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal", gbcodempresa, gbano, cuenta, MesReporte).Copy()

                        '    ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("cuenta", cuenta))


                        'ElseIf rbtrepauxiliares_122.Checked = True Then
                        '    'cuenta 44

                        '    nombredereporte = "Rpt_LibInvBal44.rpt"
                        '    ds = objSql.TraerDataSet("Spu_Con_Rep_lib44", gbcodempresa, gbano, MesReporte).Copy()

                        '    ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        '    arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))


                    ElseIf rbtrepauxiliares_13.Checked = True Then

                        'cuenta 42
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_libInvBal313.rpt", "")
                        ' Asigno el Nombre del Reporte
                        '    nombredereporte = If(gbTipoImpresora = "I", "Rpt_AuxLibInvBalCtaCte_Res.rpt", "Rpt_AuxLibInvBalCtaCte_Res.rpt")

                        'Else
                        '    nombredereporte = If(gbTipoImpresora = "I", "Rpt_AuxLibInvBalCtaCte.rpt", "Rpt_AuxLibInvBalCtaCte.rpt")


                        cuenta = "46"
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, cuenta).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_13.Text))

                    ElseIf rbtrepauxiliares_14.Checked = True Then
                        ' Cuenta 47
                        cuenta = "47"
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_libInvBal314.rpt", "")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, cuenta).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_14.Text))


                    ElseIf rbtrepauxiliares_15.Checked = True Then
                        ' Cuenta 49
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_libInvBal315.rpt", "")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_315_Saldo37y49", gbcodempresa, gbano, gbmes).Copy()


                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_15.Text))


                    ElseIf rbtrepauxiliares_16.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_libInvBal316.rpt", "")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_31601_Saldo50", gbcodempresa, gbano, gbmes).Copy()


                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_16.Text))

                    ElseIf rbtrepauxiliares_162.Checked Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_libInvBal3162.rpt", "")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_31602_Cta50Det", gbcodempresa, gbano, gbmes).Copy()


                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_162.Text))

                    ElseIf rbtrepauxiliares_17.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal17.rpt", "Rpt_LibInvBal17.rpt")

                        ds = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_317_BalComp", gbcodempresa, gbano, gbmes).Copy()
                        '
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_17.Text))

                        '
                    ElseIf rbtrepauxiliares_18.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_FlujoEfectivo.rpt", "Rpt_FlujoEfectivo.rpt")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_FlujoEfectivo", gbcodempresa, gbano, MesReporte).Copy()

                        'Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_18.Text))


                    ElseIf rbtrepauxiliares_19.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_EstCamPatNeto.rpt", "Rpt_EstCamPatNeto.rpt")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_EstCamPatNeto", gbcodempresa, gbano, MesReporte).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_19.Text))

                    ElseIf rbtrepauxiliares_20.Checked = True Then

                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal320.rpt", "")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_EGyPCom_PLE", gbcodempresa, gbano, gbmes, "", "F", "S").Copy()
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_20.Text))

                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Anio", gbano))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Mes", gbmes))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("AnioAnt", Anioanterior))


                    ElseIf rbtrepauxiliares_23.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_EstGanyPer.rpt", "Rpt_EstGanyPer.rpt")
                        ds = objSql.TraerDataSet("Spu_Con_EstGanPerPorFuncion", gbcodempresa, "F", gbano, MesReporte).Copy()
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_23.Text))


                    ElseIf rbtrepauxiliares_24.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal324.rpt", "Rpt_LibInvBal324.rpt")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_ResultIntegrales", gbcodempresa, gbano, gbmes).Copy()
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_24.Text))

                    ElseIf rbtrepauxiliares_25.Checked = True Then
                        nombredereporte = If(gbTipoImpresora = "I", "Rpt_LibInvBal325.rpt", "Rpt_LibInvBal325.rpt")
                        ds = objSql.TraerDataSet("Spu_Con_Rep_FlujEfectivo_MetodIndirecto", gbcodempresa, gbano, gbmes).Copy()
                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", rbtrepauxiliares_25.Text))

                    End If

                    '
                Case 2
                    'No hay reportes

                Case 3
                    'MesReporte = Funciones.Funciones.derecha(cboperiodos2.SelectedValue.ToString, 2)
                    'MesCostoIni = Funciones.Funciones.derecha(cbocosto103_ini.SelectedValue.ToString, 2)
                    'MesCostoFin = Funciones.Funciones.derecha(cbocosto103_fin.SelectedValue.ToString, 2)

                    ''Traer parametros para costtos
                    'prodter_ini = TraeValorCuentas(MesCostoIni, txtinvprodter.Text)
                    'prodter_Fin = TraeValorCuentas(MesCostoFin, txtinvprodter.Text)
                    ''
                    'prodProcMina_Ini = TraeValorCuentas(MesCostoIni, txtinvproprocMina.Text)
                    'prodProcMina_Fin = TraeValorCuentas(MesCostoFin, txtinvproprocMina.Text)
                    'prodProcPlanta_Ini = TraeValorCuentas(MesCostoIni, txtinvproprocPlanta.Text)
                    'prodProcPLanta_Fin = TraeValorCuentas(MesCostoFin, txtinvproprocPlanta.Text)

                    If (rbtrepauxiliares_1004.Checked = True) Then

                        nombredereporte = "Rep_LibLegCosto104.Rpt"
                        ds = objSql.TraerDataSet("Spu_Con_Exp_lc104RegCosCentroCosto", gbcodempresa, gbano).Copy()
                        'nombredereporte = If(gbTipoImpresora = "I", "Rpt_CostosDetalle.rpt", "Rpt_CostosDetalle.rpt")
                        'ds = objSql.TraerDataSet("Spu_Con_Rep_CostosDet", gbcodempresa, gbano, "90", MesReporte).Copy()

                        '' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + gbmes))


                    ElseIf (rbtrepauxiliares_1001.Checked = True) Then
                        'ajusinviniprodproc = Convert.ToDouble(txtajusinviniprodproc.Text)
                        'ajusinviniprodterm = Convert.ToDouble(txtajusinviniprodterm.Text)

                        'nombredereporte = If(gbTipoImpresora = "I", "RepCostosLegal_101.rpt", "RepCostosLegal_101.rpt")
                        'ds = objSql.TraerDataSet("spu_con_rep_formatosunat101", gbcodempresa, gbano, prodProcMina_Ini.ToString, prodProcMina_Fin.ToString, prodProcPlanta_Ini.ToString, _
                        '                         prodProcPLanta_Fin.ToString, prodter_ini.ToString, prodter_Fin.ToString, MesReporte, ajusinviniprodproc.ToString, ajusinviniprodterm.ToString).Copy()




                        '' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))

                        nombredereporte = "Rep_LibLegCosto101.Rpt"

                        ds = objSql.TraerDataSet("Spu_Con_Rep_LibLegCosto101", gbcodempresa, gbano).Copy()
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + gbmes))


                    ElseIf (rbtrepauxiliares_1002.Checked = True) Then

                        nombredereporte = "Rep_LibLegCosto102.Rpt"

                        ds = objSql.TraerDataSet("Spu_Con_Rep_lc102RegCosCostoMensual", gbcodempresa, gbano).Copy()
                        arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + gbmes))


                        'nombredereporte = If(gbTipoImpresora = "I", "RepCostosLegal_102.rpt", "RepCostosLegal_102.rpt")
                        'ds = objSql.TraerDataSet("spu_con_rep_formatosunat102", gbcodempresa, gbano, MesReporte).Copy()


                        '' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboPeriodos.Text))

                    ElseIf (rbtrepauxiliares_1003.Checked = True) Then
                        'ajusinviniprodproc = Convert.ToDouble(txtajusinviniprodproc.Text)
                        'ajusinviniprodterm = Convert.ToDouble(txtajusinviniprodterm.Text)

                        nombredereporte = If(gbTipoImpresora = "I", "Rep_LibLegCosto103.rpt", "Rep_LibLegCosto103.rpt")
                        ds = objSql.TraerDataSet("Spu_Con_Trae_lc103RegCosProdValAnual", gbcodempresa, gbano).Copy()

                        ' Asigno los Valores de set_Formulas Fijas a Mostrarse en el Reporte
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                        'arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                        arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + gbmes))

                    Else
                        MessageBox.Show("Opcion Seleccionada No Valida") : Cursor.Current = Cursors.Default : Exit Sub
                    End If
        
                Case 4
                 
            End Select

            '===
            'Visualizar reportes
            If flagimpresion = "P" Then
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            Else
                objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            End If

            'Elimnar rango de impresion
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Frm_LibrosLegales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim nivel As Integer = 2
        Dim moneda As String = "S"
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            ' Me.Text = "Libro Legales"


            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            '
            'Llena combo 
            Mod_BaseDatos.LlenarComboPeriodos(cboPeriodos, gbcodempresa, gbano)
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos2, gbcodempresa, gbano)
            '
            'Mod_BaseDatos.LlenarComboPeriodos(cbocosto103_ini, gbcodempresa, gbano)
            'Mod_BaseDatos.LlenarComboPeriodos(cbocosto103_fin, gbcodempresa, gbano)


            Mod_BaseDatos.LlenarComboCodLibro(cboCodOportunidadEEFF, "67", "glo01codigo", "*")
            '
            cboPeriodos.SelectedIndex = CInt(gbmes)
            cboperiodos2.SelectedIndex = CInt(gbmes)

            ''
            'cbocosto103_ini.SelectedIndex = 0
            'cbocosto103_fin.SelectedIndex = CInt(gbmes)

            '
            'rbtrepauxiliares_1.Checked = True
            'cargar por defecto el tab1
            btnPlantilla_1.Visible = True ' No se muestra el boton por que se configura desde la opcion balance general
            tbcliblegales.SelectedTab = TabPage2
            'Cuentas por defecto
            'txtinvprodter.Text = "21"
            'txtinvproprocMina.Text = "23211"
            'txtinvproprocPlanta.Text = "23221"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
3:      Me.imprimir_verant("P")
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnPlantilla_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_1.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_Balgen") Then Exit Sub
        Dim _Frm_LibLeg_Balgen As New Frm_LibLeg_Balgen
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_Balgen.Owner = Me
        _Frm_LibLeg_Balgen.Show()
    End Sub

    Private Sub btnPlantilla_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_7.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_2021") Then Exit Sub
        Dim _Frm_LibLeg_2021 As New Frm_LibLeg_2021
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_2021.Owner = Me
        _Frm_LibLeg_2021.Show()
    End Sub

    Private Sub btnPlantilla_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_8.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_31Valores") Then Exit Sub
        Dim _Frm_LibLeg_31Valores As New Frm_LibLeg_31Valores
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_31Valores.Owner = Me
        _Frm_LibLeg_31Valores.Show()
    End Sub

    Private Sub btnPlantilla_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_9.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_34Intangibles") Then Exit Sub
        Dim _Frm_LibLeg_34Intangibles As New Frm_LibLeg_34Intangibles
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_34Intangibles.Owner = Me
        _Frm_LibLeg_34Intangibles.Show()
    End Sub

    Private Sub btnPlantilla_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_11.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_41remu") Then Exit Sub
        Dim _Frm_LibLeg_41remu As New Frm_LibLeg_41remu
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_41remu.Owner = Me
        _Frm_LibLeg_41remu.Show()
    End Sub



    Private Sub btnPlantilla_18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_18.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_FluEfe") Then Exit Sub
        Dim _Frm_LibLeg_FluEfe As New Frm_LibLeg_FluEfe
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_FluEfe.Owner = Me
        _Frm_LibLeg_FluEfe.Show()
    End Sub

    Private Sub btnPlantilla_19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_19.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_PatNeto") Then Exit Sub
        Dim _Frm_LibLeg_PatNeto As New Frm_LibLeg_PatNeto
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_PatNeto.Owner = Me
        _Frm_LibLeg_PatNeto.Show()
    End Sub

    Private Sub btnPlantilla_16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_16.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_50capital") Then Exit Sub
        Dim _Frm_LibLeg_50capital As New Frm_LibLeg_50capital
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_50capital.Owner = Me
        _Frm_LibLeg_50capital.Show()
    End Sub

    Private Sub btnPlantilla_20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_20.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibEstadoResultado") Then Exit Sub
        Dim _Frm_LibLeg_EGyP As New Frm_LibEstadoResultado
        '_Frm_LibLeg_Balgen.MdiParent = Me
        Frm_LibEstadoResultado.Owner = Me
        Frm_LibEstadoResultado.Show()
    End Sub

    Private Sub HabyDeshopciones(ByVal Index As Integer)
        Select Case Index
            Case 1
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                ' grbnivel.Visible = False
                'cbonivel.Enabled = False
                ctaselec = ""

            Case 2
                rbttipolibro_0.Enabled = False
                rbttipolibro_0.Checked = False
                rbttipolibro_1.Enabled = False
                rbttipolibro_1.Enabled = False

                'grbnivel.Visible = False

                ctaselec = ""
            Case 3
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True

                '.Visible = False
                ctaselec = "12"
            Case 4
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True

                'grbnivel.Visible = False
                ctaselec = "14"
            Case 5
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True

                'grbnivel.Visible = False
                ctaselec = "16"
            Case 51
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True

                'grbnivel.Visible = False
                ctaselec = "17"
            Case 6
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True
                rbttipolibro_1.Enabled = True

                ' grbnivel.Visible = False
                ctaselec = "422"
            Case 7
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                'grbnivel.Visible = False
                ctaselec = "20"
            Case 8
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                'grbnivel.Visible = False
                ctaselec = "31"
            Case 9
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                ' grbnivel.Visible = False
                ctaselec = "34"
            Case 10
                rbttipolibro_0.Enabled = False
                rbttipolibro_0.Checked = False
                rbttipolibro_1.Enabled = False
                rbttipolibro_1.Enabled = False

                'grbnivel.Visible = False
            Case 11
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                ' grbnivel.Visible = False
                ctaselec = "41"
            Case 12
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True

                ' grbnivel.Visible = False
                ctaselec = "42"
            Case 121
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True

                ' grbnivel.Visible = False
                ctaselec = "43"
            Case 122
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = True

                ' grbnivel.Visible = False
                ctaselec = "44"
            Case 13
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                ' grbnivel.Visible = False
                ctaselec = "46"
            Case 14
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                ' grbnivel.Visible = False
                ctaselec = "47"
            Case 15
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                ' grbnivel.Visible = False
                ctaselec = "49"
            Case 16
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                ' grbnivel.Visible = False
                ctaselec = "50"
            Case 17
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False
                'cmbPeriodos.ListIndex = 5
                ' grbnivel.Visible = True
        
                'nivel = CType(cboniveles.SelectedValue.ToString, Integer)
                ctaselec = ""
            Case 18
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                '  grbnivel.Visible = False
                ctaselec = ""
            Case 19
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                'grbnivel.Visible = False
                ctaselec = ""
            Case 20
                rbttipolibro_0.Enabled = True
                rbttipolibro_0.Checked = True
                rbttipolibro_1.Enabled = False

                'grbnivel.Visible = False
                ctaselec = ""
            Case Else
                ' grbnivel.Visible = False

        End Select
        Me.muestrayocultabotones(Index)
    End Sub
    Sub muestrayocultabotones(ByVal indice As Integer)
        '
        Try
            'Desactivar todas las palntillas
            For Each objcontrol As Control In Me.Controls
                If TypeOf objcontrol Is Button Then
                    If CType(objcontrol, System.Windows.Forms.Button).Name.Substring(0, 12).ToString.ToUpper = "btnPlantilla".ToUpper Then
                        CType(objcontrol, System.Windows.Forms.Button).Enabled = False
                    End If
                End If
            Next

            'Activar la plantilla segunel indice
            Select Case indice
                Case 1
                    btnPlantilla_1.Enabled = True
                Case 7
                    btnPlantilla_7.Enabled = True
                Case 8
                    btnPlantilla_8.Enabled = True
                Case 9
                    btnPlantilla_9.Enabled = True
                Case 11
                    btnPlantilla_11.Enabled = True

                Case 16
                    btnPlantilla_16.Enabled = True
                Case 18
                    btnPlantilla_18.Enabled = True
                Case 19
                    btnPlantilla_19.Enabled = True
                Case 20
                    btnPlantilla_20.Enabled = True
                Case 401
                    btnPlantilla_401.Enabled = True
                Case 501
                    btnPlantilla_501.Enabled = True
                Case 601
                    btnPlantilla_601.Enabled = True
                Case 801
                    btnPlantilla_801.Enabled = True
                Case 1401
                    btnPlantilla_1401.Enabled = True
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub rbtrepauxiliares_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(1)
    End Sub
    Private Sub rbtrepauxiliares_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(2)
    End Sub
    Private Sub rbtrepauxiliares_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(3)
    End Sub
    Private Sub rbtrepauxiliares_4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(4)
    End Sub
    Private Sub rbtrepauxiliares_5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(5)
    End Sub
    Private Sub rbtrepauxiliares_6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(6)
    End Sub
    Private Sub rbtrepauxiliares_7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(7)
    End Sub
    Private Sub rbtrepauxiliares_8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(8)
    End Sub
    Private Sub rbtrepauxiliares_9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(9)
    End Sub
    Private Sub rbtrepauxiliares_10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(10)
    End Sub
    Private Sub rbtrepauxiliares_11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(11)
    End Sub
    Private Sub rbtrepauxiliares_12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(12)
    End Sub
    Private Sub rbtrepauxiliares_13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(13)
    End Sub
    Private Sub rbtrepauxiliares_14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(14)
    End Sub
    Private Sub rbtrepauxiliares_15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(15)
    End Sub
    Private Sub rbtrepauxiliares_16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(16)
    End Sub
    Private Sub rbtrepauxiliares_17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(17)
    End Sub
    Private Sub rbtrepauxiliares_18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(18)
    End Sub
    Private Sub rbtrepauxiliares_19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(19)
    End Sub
    Private Sub rbtrepauxiliares_20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(20)
    End Sub

    Private Sub btnPlantilla_401_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_401.Click
        If Funciones.Funciones.FormIsOpen("Frm_RegistroRetencionLib41") Then Exit Sub
        Dim _Frm_RegComprasLibLegal41 As New Frm_RegistroRetencionLib41
        _Frm_RegComprasLibLegal41.Show()
    End Sub

    Private Sub btnPlantilla_501_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_501.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibroDiario") Then Exit Sub
        Dim _Frm_LibroDiario As New Frm_LibroDiario
        _Frm_LibroDiario.Show()
    End Sub

    Private Sub btnPlantilla_601_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_601.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibroMayor") Then Exit Sub
        Dim _Frm_LibroMayor As New Frm_LibroMayor
        _Frm_LibroMayor.Show()
    End Sub

    Private Sub btnPlantilla_801_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_801.Click
        If Funciones.Funciones.FormIsOpen("Frm_RegCompras") Then Exit Sub
        Dim _Frm_RegCompras As New Frm_RegCompras
        _Frm_RegCompras.Show()

    End Sub

    Private Sub btnPlantilla_1401_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_1401.Click
        If Funciones.Funciones.FormIsOpen("Frm_RegVentas") Then Exit Sub
        Dim _Frm_RegVentas As New Frm_RegVentas
        _Frm_RegVentas.Show()
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub rbtrepauxiliares_51_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(51)
    End Sub

    Private Sub rbtrepauxiliares_121_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(121)
    End Sub

    Private Sub rbtrepauxiliares_122_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.HabyDeshopciones(122)
    End Sub

    Private Sub KsTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub btnPlantilla_122_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_122.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_44ctas") Then Exit Sub
        Dim _Frm_LibLeg_44ctas As New Frm_LibLeg_44ctas
        '_Frm_LibLeg_Balgen.MdiParent = Me
        _Frm_LibLeg_44ctas.Owner = Me
        _Frm_LibLeg_44ctas.Show()
    End Sub


    'LIBROS ELECTRONICOS PARA EXPORTAR'
    'EXPORTAR ARCHIVOS LIBROS ELECTRONICOS'
#Region "LibrosINVBALAN"
    '3.1 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro31INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_BalGenCom_PLE", gbcodempresa, gbano, gbmes, "2022", "S")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030100", gbRucEmpresa, gbano, gbmes, dia, "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""

            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow
                For i As Integer = dt.Tables(0).Rows.Count - 1 To 0 Step -1
                    ' Obtener el valor en la columna "campo2" de la fila actual
                    Dim valorCampo2 As String = Convert.ToString(dt.Tables(0).Rows(i)("CodRubroPleActivo"))

                    ' Verificar si el valor en la columna "campo2" es vacío y eliminar la fila
                    If String.IsNullOrEmpty(valorCampo2) Then
                        dt.Tables(0).Rows.RemoveAt(i)
                    End If

                Next
                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("campo_01_Periodo").ToString
                    campo_02 = dr("campo_02_Códigocatálogo").ToString
                    campo_03 = dr("campo_03_NumcorrelativoAsicont").ToString
                    campo_04 = dr("campo_04_SaldoRubroContable").ToString
                    campo_05 = dr("campo_05_estado_operacion").ToString
                    campo_06 = dr("campo_06_Libreutilizacion").ToString

                    Dim CodRuboPle As String = dr("CodRubroPleActivo").ToString



                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor



            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 3.1")
            Return
        End Try

    End Sub
    'LIBRO 3.2'
    '3.2 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro32INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String

        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_32_Saldo10", gbcodempresa, gbano, gbmes, "10")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030200", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)

                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("campo_1").ToString & Chr(124)
                    campo_02 = dr("campo_2").ToString & Chr(124)
                    campo_03 = dr("campo_3").ToString & Chr(124)
                    campo_04 = dr("campo_4").ToString & Chr(124)
                    campo_05 = dr("campo_5").ToString & Chr(124)
                    campo_06 = dr("campo_6").ToString & Chr(124)
                    campo_07 = dr("campo_7").ToString & Chr(124)
                    campo_08 = dr("campo_8").ToString & Chr(124)

                    Dim linea As String = ""
                    linea = campo_01 & campo_02 & campo_03 & campo_04 & campo_05 & campo_06 & campo_07 & campo_08


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)

                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un Problema al exportar el Libro 3.2")

        End Try

    End Sub
    '3.3 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro33INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, "12")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030300", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CUO").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocIdentidad").ToString
                    campo_05 = dr("NumeroDocIdentidad").ToString
                    campo_06 = dr("NombresORazonSolcial").ToString
                    campo_07 = dr("FechaEmisionOFechaInicioDoc").ToString
                    campo_08 = dr("Monto").ToString
                    campo_09 = dr("EstadoDeOperacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try



    End Sub
    '3.4 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro34INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, "14")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030400", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CUO").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocIdentidad").ToString
                    campo_05 = dr("NumeroDocIdentidad").ToString
                    campo_06 = dr("NombresORazonSolcial").ToString
                    campo_07 = dr("FechaEmisionOFechaInicioDoc").ToString
                    campo_08 = dr("Monto").ToString
                    campo_09 = dr("EstadoDeOperacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.5 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro35INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, "16")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030500", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CUO").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocIdentidad").ToString
                    campo_05 = dr("NumeroDocIdentidad").ToString
                    campo_06 = dr("NombresORazonSolcial").ToString
                    campo_07 = dr("FechaEmisionOFechaInicioDoc").ToString
                    campo_08 = dr("Monto").ToString
                    campo_09 = dr("EstadoDeOperacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try



    End Sub
    Private Sub Libro36INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, "19")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030600", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CUO").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocIdentidad").ToString
                    campo_05 = dr("NumeroDocIdentidad").ToString
                    campo_06 = dr("NombresORazonSolcial").ToString

                    campo_07 = dr("DocumentoTipo").ToString
                    campo_08 = dr("DocumentoSerie").ToString
                    campo_09 = dr("DocumentoCorrelativo").ToString

                    campo_10 = dr("FechaEmisionOFechaInicioDoc").ToString
                    campo_11 = dr("Monto").ToString
                    campo_12 = dr("EstadoDeOperacion").ToString


                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.7 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro37INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_37_Saldo2021", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030700", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""
            Dim campo_13 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Tipo_de_existencia").ToString
                    campo_04 = dr("Codigo_propio_existencia").ToString
                    campo_05 = dr("codigo_del_catalogo_utilizado").ToString
                    campo_06 = dr("Codigo_Existencia_catalogo_utilizado").ToString

                    campo_07 = dr("Descripcion_existencia").ToString
                    campo_08 = dr("Codigo_UniMed_existencia").ToString
                    campo_09 = dr("Codigo_metodo_valuacion").ToString

                    campo_10 = dr("Cantidad_existencia").ToString
                    campo_11 = dr("Costo_unitarioexistencia").ToString
                    campo_12 = dr("Costo_total").ToString
                    campo_13 = dr("Estado_operacion").ToString


                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124) &
                    campo_10 & Chr(124) &
                    campo_11 & Chr(124) &
                    campo_12 & Chr(124) &
                    campo_13 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub Libro38INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_38_Saldo3031", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030800", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Unico_Operacion").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocumentoIdentidadEmisor").ToString
                    campo_05 = dr("NumeroDocumentoIdentidadEmisor").ToString
                    campo_06 = dr("Apellidos_y_NombresEmisor").ToString

                    campo_07 = dr("Codigo_del_Titulo").ToString
                    campo_08 = dr("Valor_nominal_unitario_Titulo").ToString
                    campo_09 = dr("Cantidad_Titulos").ToString

                    campo_10 = dr("Valor_en_libros_Costototal_Titulos").ToString
                    campo_11 = dr("Valor_en_Libros_Provision_totalTitulos").ToString
                    campo_12 = dr("Indica_estado_operacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124) &
                    campo_10 & Chr(124) &
                    campo_11 & Chr(124) &
                    campo_12 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.9 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro39INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_39_Saldo34", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("030900", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""


            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Unico_Operacion").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("Fecha_inicio_operacion").ToString
                    campo_05 = dr("codigo_Cuenta_Contable").ToString
                    campo_06 = dr("Descripcion_intangible").ToString
                    campo_07 = dr("Valor_contable_intangible").ToString
                    campo_08 = dr("Amortizacion_contable_acumulada").ToString
                    campo_09 = dr("Estado_operacion").ToString




                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.11 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro311INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_311_Saldo41", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031100", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""


            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Unico_Operacion").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("Codigo_cuenta_contable").ToString
                    campo_05 = dr("Tipo_Documento_Identidad").ToString
                    campo_06 = dr("Numero_Documento_Identidad_trabajador").ToString
                    campo_07 = dr("Codigo_trabajador").ToString
                    campo_08 = dr("Apellidos_y_Nombres_trabajador").ToString
                    campo_09 = dr("Saldo_Final").ToString
                    campo_10 = dr("Estado_operacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124) &
                    campo_10 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try
    End Sub
    '3.12 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro312INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, "42")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031200", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CUO").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocIdentidad").ToString
                    campo_05 = dr("NumeroDocIdentidad").ToString
                    campo_07 = dr("FechaEmisionOFechaInicioDoc").ToString
                    campo_06 = dr("NombresORazonSolcial").ToString
                    campo_08 = dr("Monto").ToString
                    campo_09 = dr("EstadoDeOperacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.13 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro313INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, "46")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031300", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CUO").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocIdentidad").ToString
                    campo_05 = dr("NumeroDocIdentidad").ToString
                    campo_06 = dr("FechaEmisionOFechaInicioDoc").ToString
                    campo_07 = dr("NombresORazonSolcial").ToString
                    campo_08 = dr("Codigo_Cuenta_Contable").ToString
                    campo_09 = dr("Monto").ToString
                    campo_10 = dr("EstadoDeOperacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124) &
                    campo_10 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.14 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro314INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_PLE", gbcodempresa, gbano, gbmes, "47")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031400", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("CUO").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("TipoDocIdentidad").ToString
                    campo_05 = dr("NumeroDocIdentidad").ToString
                    campo_06 = dr("NombresORazonSolcial").ToString
                    campo_07 = dr("Monto").ToString
                    campo_08 = dr("EstadoDeOperacion").ToString



                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.15 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro315INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_315_Saldo37y49", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031500", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Unico_Operacion").ToString
                    campo_03 = dr("Correlativo").ToString
                    campo_04 = dr("Tipo_Comprobante_Pago_relacionado").ToString
                    campo_05 = dr("serie_comprobante_pago_relacionada").ToString
                    campo_06 = dr("Numero_Comprobante_Pago_relacionado").ToString
                    campo_07 = dr("Codigo_cuenta_contable").ToString
                    campo_08 = dr("Concepto_operacion").ToString
                    campo_09 = dr("Saldo_Final").ToString
                    campo_10 = dr("Adiciones").ToString
                    campo_11 = dr("Deducciones").ToString
                    campo_12 = dr("Estado_operacion").ToString

                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124) &
                    campo_10 & Chr(124) &
                    campo_11 & Chr(124) &
                    campo_12 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try


    End Sub
    '3.16 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro316_1_INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_31601_Saldo50", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031601", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Importe_Capital_Social").ToString
                    campo_03 = dr("Valor_nominal_por_accion").ToString
                    campo_04 = dr("Numero_acciones_suscritas").ToString
                    campo_05 = dr("Numero_acciones_pagadas").ToString
                    campo_06 = dr("Estado_operacion").ToString


                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Libro316_2_INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_31602_Cta50Det", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try

            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"

            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes

            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031602", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""


            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Tipo_Documento_Identidad_accionista").ToString
                    campo_03 = dr("Numero_Documento_Identidad_accionista").ToString
                    campo_04 = dr("Codigo_tipos_acciones").ToString
                    campo_05 = dr("ApellidosyNombres_accionista").ToString
                    campo_06 = dr("Numero_acciones").ToString
                    campo_07 = dr("Porcentaje_Total_participacion_acciones").ToString
                    campo_08 = dr("Estado_operacion").ToString

                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)
        End Try
    End Sub
    '3.17 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro317INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_AuxLibInvBal_317_BalComp", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031700", gbRucEmpresa, gbano, gbmes, dia, "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

         
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""
            Dim campo_13 As String = ""
            Dim campo_14 As String = ""
            Dim campo_15 As String = ""
            Dim campo_16 As String = ""
            Dim campo_17 As String = ""
            Dim campo_18 As String = ""
            Dim campo_19 As String = ""
            Dim campo_20 As String = ""
            Dim campo_21 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_cuenta_Contable").ToString
                    campo_03 = dr("DebeInicial").ToString
                    campo_04 = dr("HaberInicial").ToString
                    campo_05 = dr("DebeAcumulado").ToString
                    campo_06 = dr("HaberAcumulado").ToString
                    campo_07 = dr("SumasDelMayorDebe").ToString
                    campo_08 = dr("SumasDelMayorHaber").ToString
                    campo_09 = dr("Saldo_Deudor").ToString
                    campo_10 = dr("Saldo_Acreedor").ToString
                    campo_11 = dr("Transferencias_y_cancelaciones_debe").ToString
                    campo_12 = dr("Transferencias_y_cancelaciones_haber").ToString
                    'campo_13 = dr("Ajustes_por_adecuacion_debe").ToString
                    'campo_14 = dr("Ajustes_por_adecuacion_haber").ToString
                    campo_15 = dr("Cuentas_Del_balance_Activo").ToString
                    campo_16 = dr("Cuentas_Del_balance_Pasivo").ToString
                    campo_17 = dr("Resultados_por_Naturaleza_Perdidas").ToString
                    campo_18 = dr("Resultados_por_Naturaleza_Ganancias").ToString
                    campo_19 = dr("Adiciones").ToString
                    campo_20 = dr("Deducciones").ToString
                    campo_21 = dr("EstadoOperacion").ToString

                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124) &
                    campo_06 & Chr(124) &
                    campo_07 & Chr(124) &
                    campo_08 & Chr(124) &
                    campo_09 & Chr(124) &
                    campo_10 & Chr(124) &
                    campo_11 & Chr(124) &
                    campo_12 & Chr(124) &
                    campo_15 & Chr(124) &
                    campo_16 & Chr(124) &
                    campo_17 & Chr(124) &
                     campo_18 & Chr(124) &
                    campo_19 & Chr(124) &
                    campo_20 & Chr(124) &
                    campo_21 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.18 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro318INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String


        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_FlujoEfectivo", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==


        'Poner cursor en modo espera
        Cursor.Current = Cursors.WaitCursor


        Try
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes


            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031800", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)
 

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            'RECORRER SP 
            Dim dr As DataRow
            For i As Integer = dt.Tables(0).Rows.Count - 1 To 0 Step -1
                ' Obtener el valor en la columna "campo2" de la fila actual
                Dim valorCampo2 As String = Convert.ToString(dt.Tables(0).Rows(i)("Cod_Rubro"))

                ' Verificar si el valor en la columna "campo2" es vacío y eliminar la fila
                If String.IsNullOrEmpty(valorCampo2) Then
                    dt.Tables(0).Rows.RemoveAt(i)
                End If

            Next
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Cod_Rubro").ToString
                    campo_04 = dr("Saldo_Rubro_Contable").ToString
                    campo_05 = dr("Estado_operacion").ToString

                    Dim linea As String = ""
                    linea =
                    campo_01 & Chr(124) &
                    campo_02 & Chr(124) &
                    campo_03 & Chr(124) &
                    campo_04 & Chr(124) &
                    campo_05 & Chr(124)
                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using
            'END RECORRIDO SP 
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)

        End Try

    End Sub
    '3.19 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro319INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_EstCamPatNeto", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("031900", gbRucEmpresa, gbano, gbmes, dia, valorcboCodOportunidadEEFF, FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

      
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""
            Dim campo_13 As String = ""
            Dim campo_14 As String = ""
            Dim campo_15 As String = ""
            Dim campo_16 As String = ""
            Dim campo_17 As String = ""

            Dim dr As DataRow
            For i As Integer = dt.Tables(0).Rows.Count - 1 To 0 Step -1
                ' Obtener el valor en la columna "campo2" de la fila actual
                Dim valorCampo2 As String = Convert.ToString(dt.Tables(0).Rows(i)("Cod_Rubro"))

                ' Verificar si el valor en la columna "campo2" es vacío y eliminar la fila
                If String.IsNullOrEmpty(valorCampo2) Then
                    dt.Tables(0).Rows.RemoveAt(i)
                End If

            Next

            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Cod_Rubro").ToString
                    campo_04 = dr("Capital").ToString
                    campo_05 = dr("Acciones_Inversion").ToString
                    campo_06 = dr("Capital_Adicional").ToString
                    campo_07 = dr("ResultadosNoRealizados").ToString
                    campo_08 = dr("Reservas_Legales").ToString
                    campo_09 = dr("Otras_Reservas").ToString
                    campo_10 = dr("Resultados_Acumulados").ToString
                    campo_11 = dr("Diferencia_Conversion").ToString
                    campo_12 = dr("Ajuste_Patrimonio").ToString
                    campo_13 = dr("Resultado_Neto_Ejercicio").ToString
                    campo_14 = dr("Excedente_Revaluacion").ToString
                    campo_15 = dr("Resultado_Ejercicio").ToString
                    campo_16 = dr("Estado_operacion").ToString



                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                    campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124) &
                    campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & campo_12 & Chr(124) & campo_13 & Chr(124) & campo_14 & Chr(124) & campo_15 & Chr(124) &
                    campo_16 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR :: Hubo un problema al generar el Libro 3.19")

        End Try

    End Sub
    '3.20 LIBRO DE INVENTARIOS Y BALANCES'
    Private Sub Libro320INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_EGyPCom_PLE", gbcodempresa, gbano, gbmes, "", "F", "S")
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
                     dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("032000", gbRucEmpresa, gbano, gbmes, dia, "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)




            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    '    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Cod_Rubro").ToString
                    campo_04 = dr("Saldo_Rubro_Contable").ToString
                    campo_05 = dr("Estado_operacion").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                    campo_04 & Chr(124) & campo_05 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using


            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR :: Hubo un problema al generar el libro 3.20")
            Return
        End Try

    End Sub
    '3.23 LIBRO DE INVENTARIOS Y BALANCES
    Private Sub Libro323INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_ResultIntegrales", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "0"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("032300", gbRucEmpresa, gbano, gbmes, dia, "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)




            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    '    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Cod_Rubro").ToString
                    campo_04 = dr("Saldo_Rubro_Contable").ToString
                    campo_05 = dr("Estado_operacion").ToString


                    Dim linea As String = ""
                    linea = "Texto Complementario"


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using


            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR :: Hubo un problema al generar el libro 3.20")
            Return
        End Try

    End Sub
    '3.24 LIBRO DE INVENTARIOS Y BALANCES
    Private Sub Libro324INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_ResultIntegrales", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("032400", gbRucEmpresa, gbano, gbmes, dia, "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)




            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""

            Dim dr As DataRow
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    '    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Cod_Rubro").ToString
                    campo_04 = dr("Saldo_Rubro_Contable").ToString
                    campo_05 = dr("Estado_operacion").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                    campo_04 & Chr(124) & campo_05 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using


            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR :: Hubo un problema al generar el libro 3.20")
            Return
        End Try

    End Sub
    '3.25 LIBRO DE INVENTARIOS Y BALANCES
    Private Sub Libro325INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_FlujEfectivo_MetodIndirecto", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("032500", gbRucEmpresa, gbano, gbmes, dia, "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)




            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor

            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""

            Dim dr As DataRow
            For i As Integer = dt.Tables(0).Rows.Count - 1 To 0 Step -1
                ' Obtener el valor en la columna "campo2" de la fila actual
                Dim valorCampo2 As String = Convert.ToString(dt.Tables(0).Rows(i)("Cod_Rubro"))

                ' Verificar si el valor en la columna "campo2" es vacío y eliminar la fila
                If String.IsNullOrEmpty(valorCampo2) Then
                    dt.Tables(0).Rows.RemoveAt(i)
                End If

            Next
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    '    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Cod_Rubro").ToString
                    campo_04 = dr("Saldo_Rubro_Contable").ToString
                    campo_05 = dr("Estado_operacion").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                    campo_04 & Chr(124) & campo_05 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using


            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR :: Hubo un problema al generar el libro 3.20")
            Return
        End Try

    End Sub
#End Region

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Dim MesReporte As String
        Dim Mescodigo_oportunidad As String
        Try


            Dim strStreamWriter As StreamWriter
            Dim tabPageActual As TabPage = tbcliblegales.SelectedTab
            Dim contador = ContarCheckBoxMarcados(tabPageActual)
            'VALIDAR SI TIENE MAS DE 2 CHECKBOX ACTIVOS'
            If tabPageActual.Name = "TabPage2" Then
                If contador = 0 Then
                    MessageBox.Show("ERROR:: Seleccione un libro para exportar los archivos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            MesReporte = Funciones.Funciones.derecha(cboPeriodos.SelectedValue.ToString, 2)
            'Mescodigo_oportunidad = Funciones.Funciones.derecha(cboCodOportunidadEEFF.SelectedValue.ToString, 2)
            Mescodigo_oportunidad = Mod_BaseDatos.DameDescripcion("67" + MesReporte, "MEC")
            If tabPageActual.Name = "TabPage2" Then
                If Mescodigo_oportunidad <> "" Then
                    If (MesReporte <> Mescodigo_oportunidad) Then
                        MessageBox.Show("Validar :: Mes del periodo debe ser igual al mes del codigo de oportunidad", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End If
            End If

            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Seleccionar Carpeta para Guardar Archivos"
            folderBrowserDialog.ShowNewFolderButton = True
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = folderBrowserDialog.SelectedPath

            Else
                Return

            End If


            Cursor.Current = Cursors.WaitCursor

            '3.1 LIBRO DE INVENTARIOS Y BALANCES - ESTADO DE SITUACIÓN FINANCIERA 				
            If tabPageActual.Name = "TabPage2" Then
                If (rbtrepauxiliares_1.Checked = True) Then
                    Libro31INVBAL(folderBrowserDialog)
                End If

                '3.2 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 10 EFECTIVO Y EQUIVALENTES DE EFECTIVO (PCGE) (2)
                If (rbtrepauxiliares_2.Checked = True) Then
                    Libro32INVBAL(folderBrowserDialog)
                End If

                '3.3 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 12 CUENTAS POR COBRAR COMERCIALES – TERCEROS Y 13
                If (rbtrepauxiliares_3.Checked = True) Then
                    Libro33INVBAL(folderBrowserDialog)
                End If

                '3.4 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 14 CUENTAS POR COBRAR AL PERSONAL, A LOS ACCIONISTAS
                If (rbtrepauxiliares_4.Checked = True) Then
                    Libro34INVBAL(folderBrowserDialog)
                End If

                '3.5 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 16 CUENTAS POR COBRAR DIVERSAS - TERCEROS O CUENTA 17 
                If (rbtrepauxiliares_5.Checked = True) Then
                    Libro35INVBAL(folderBrowserDialog)
                End If

                '3.6 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 19 ESTIMACIÓN DE CUENTAS DE COBRANZA DUDOSA (PCGE) (2)
                If (rbtrepauxiliares_6.Checked = True) Then
                    Libro36INVBAL(folderBrowserDialog)
                End If

                '3.7 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 20 - MERCADERIAS Y LA CUENTA 21 - PRODUCTOS TERMINADOS (PCGE) (2)							
                If (rbtrepauxiliares_7.Checked = True) Then
                    Libro37INVBAL(folderBrowserDialog)
                End If
                '3.8 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 30 INVERSIONES MOBILIARIAS  (PCGE) (2)
                If (rbtrepauxiliares_8.Checked = True) Then
                    Libro38INVBAL(folderBrowserDialog)
                End If
                '3.9 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 34 - INTANGIBLES (PCGE) (2)
                If (rbtrepauxiliares_9.Checked = True) Then
                    Libro39INVBAL(folderBrowserDialog)
                End If

                '3.10 no existe en excel de libros electronicos

                '3.11 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 34 - INTANGIBLES (PCGE) (2)
                If (rbtrepauxiliares_11.Checked = True) Then
                    Libro311INVBAL(folderBrowserDialog)
                End If

                '3.12 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 42 CUENTAS POR PAGAR COMERCIALES – TERCEROS Y LA CUENTA 43 
                If (rbtrepauxiliares_12.Checked = True) Then
                    Libro312INVBAL(folderBrowserDialog)
                End If

                '3.13  LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 46 CUENTAS POR PAGAR DIVERSAS – TERCEROS Y DE LA CUENTA 47 
                If (rbtrepauxiliares_13.Checked = True) Then
                    Libro313INVBAL(folderBrowserDialog)
                End If
                '3.14 LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 47 - BENEFICIOS SOCIALES DE LOS TRABAJADORES (PCGR)
                If (rbtrepauxiliares_14.Checked = True) Then
                    Libro314INVBAL(folderBrowserDialog)
                End If
                '3.15  LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 37 ACTIVO DIFERIDO Y DE LA CUENTA 49 PASIVO DIFERIDO (PCGE)   (2)
                If (rbtrepauxiliares_15.Checked = True) Then
                    Libro315INVBAL(folderBrowserDialog)
                End If
                If (rbtrepauxiliares_16.Checked = True) Then
                    Libro316_1_INVBAL(folderBrowserDialog)
                End If
                If rbtrepauxiliares_162.Checked = True Then
                    Libro316_2_INVBAL(folderBrowserDialog)
                End If

                If (rbtrepauxiliares_17.Checked = True) Then
                    Libro317INVBAL(folderBrowserDialog)
                End If
                If (rbtrepauxiliares_18.Checked = True) Then
                    Libro318INVBAL(folderBrowserDialog)
                End If
                If (rbtrepauxiliares_19.Checked = True) Then
                    Libro319INVBAL(folderBrowserDialog)
                End If
                If (rbtrepauxiliares_20.Checked = True) Then
                    Libro320INVBAL(folderBrowserDialog)
                End If
                If (rbtrepauxiliares_23.Checked = True) Then
                    Libro323INVBAL(folderBrowserDialog)
                End If
                If (rbtrepauxiliares_24.Checked = True) Then
                    Libro324INVBAL(folderBrowserDialog)
                End If
                If (rbtrepauxiliares_25.Checked = True) Then
                    Libro325INVBAL(folderBrowserDialog)
                End If
            End If
            If tabPageActual.Name = "TabPage3" Then
                If rbtrepauxiliares_401.Checked = True Then
                    ExportarLibro41RetencionesINVBAL(folderBrowserDialog)
                End If
            End If
            If tabPageActual.Name = "TabPage4" Then
                If rbtrepauxiliares_901.Checked = True Then
                    Libro901REGISCONSIGNACION(folderBrowserDialog, MesReporte)
                End If
                'LIBRO LEGAL 101
                If rbtrepauxiliares_1001.Checked = True Then
                    Libro101INVBAL(folderBrowserDialog)
                End If
                'END LIBRO LEGAL 101
                'LIBRO LEGAL 102
                If rbtrepauxiliares_1002.Checked = True Then
                    Libro102INVBAL(folderBrowserDialog)
                End If
                If rbtrepauxiliares_1003.Checked = True Then
                    Libro103INVBAL(folderBrowserDialog)
                End If
                If rbtrepauxiliares_1004.Checked = True Then
                    Libro104INVBAL(folderBrowserDialog)
                End If
                'END LIBRO LEGAL 102
            End If
       
            MessageBox.Show("Los archivos se generaron con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR :: Hubo algun problema al generar los archivos", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub Libro104INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)

        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Exp_lc104RegCosCentroCosto", gbcodempresa, gbano)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            '  Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            Dim strStreamWriter As StreamWriter
            nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("100400", gbRucEmpresa, gbano, "00", "00", "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""
            Dim campo_13 As String = ""
            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Nro_Correlativo").ToString
                    campo_03 = dr("Cod_UnidadOperacion").ToString
                    campo_04 = dr("Desc_UnidadOperacion").ToString
                    campo_05 = dr("Cod_CentroCosto").ToString
                    campo_06 = dr("Desc_CentroCosto").ToString
                    campo_07 = dr("Estado_Operacion").ToString
                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor



            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 10.4")
            Return
        End Try

    End Sub
    Private Sub Libro103INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)

        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Exp_lc103RegCosProdValAnual", gbcodempresa, gbano)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            '  Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            Dim strStreamWriter As StreamWriter
            nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("100300", gbRucEmpresa, gbano, "00", "00", "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Dim campo_11 As String = ""
            Dim campo_12 As String = ""
            Dim campo_13 As String = ""
            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Ejercicio").ToString
                    campo_02 = dr("Código_identificación_Proceso_informado").ToString
                    campo_03 = dr("Descripción_Proceso_informado").ToString
                    campo_04 = dr("Costos_Materiales_Suministros_Directos").ToString
                    campo_05 = dr("Costos_Mano_Obra_Directa").ToString
                    campo_06 = dr("Otros_Costos_Directos").ToString
                    campo_07 = dr("Gastos_Producción_Materiales_Suministros_Indirectos").ToString
                    campo_08 = dr("GastosProduccion_Mano_de_Obra_Indirecta").ToString
                    campo_09 = dr("Otros_Gastos_Producción_Indirectos").ToString
                    campo_10 = dr("Inventario_inicial_productos_proceso").ToString
                    campo_11 = dr("Inventario_final_productos_proceso").ToString
                    campo_12 = dr("Código_agrupamiento").ToString
                    campo_13 = dr("Estado_Operacion").ToString

                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124) & campo_11 & Chr(124) & campo_12 & Chr(124) & campo_13 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor



            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 10.3")
            Return
        End Try

    End Sub
    Private Sub Libro102INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)

        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Exp_lc102RegCosCostoMensual", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            '  Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            Dim strStreamWriter As StreamWriter
            nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("100200", gbRucEmpresa, gbano, gbmes, "00", "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""

            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Costo_Materiales").ToString
                    campo_03 = dr("CostoManoObaDirecta").ToString
                    campo_04 = dr("Otros_CostosDirectos").ToString
                    campo_05 = dr("GastosProduccionIndirecto_MatSuministros").ToString
                    campo_06 = dr("GastosProduccionIndirecto_ManoObraDirecta").ToString
                    campo_07 = dr("Otros_GastosProduccionIndirecto").ToString
                    campo_08 = dr("Estado_Operacion").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor



            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 10.2")
            Return
        End Try

    End Sub
    Private Sub Libro101INVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)


        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'

        '==

        Try
            Dim dt As New DataSet
            dt = objSql.TraerDataSet("Spu_Con_Exp_lc101RegCosEstCosto", gbcodempresa, gbano)
            '======
            If dt.Tables(0).Rows.Count > 0 Then
                FlagtieneRegistros = "1"
            Else
                FlagtieneRegistros = "0"
            End If

            '  Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            Dim strStreamWriter As StreamWriter
            nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("100100", gbRucEmpresa, gbano, "00", "00", "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Ejercicio").ToString
                    campo_02 = dr("Costo_inventarioinicial").ToString
                    campo_03 = dr("Costo_produccion").ToString
                    campo_04 = dr("Costo_inventariofinal_productosterminados").ToString
                    campo_05 = dr("Ajustes_diversos_contables").ToString
                    campo_06 = dr("Estado_Operacion").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor



            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 10.1")
            Return
        End Try

    End Sub
    Private Sub ExportarLibro41RetencionesINVBAL(ByVal folderBrowserDialog1 As FolderBrowserDialog)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_RegistroRetenciones", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            '  Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("040100", gbRucEmpresa, gbano, gbmes, dia, "01", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""
            Dim campo_09 As String = ""
            Dim campo_10 As String = ""
            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow
           
                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Unico_Operacion").ToString
                    campo_03 = dr("ProveedorDocCorrelativo").ToString
                    campo_04 = dr("RetencionFecha").ToString
                    campo_05 = dr("ProveedorDocTipo").ToString
                    campo_06 = dr("ProveedorDocNro").ToString
                    campo_07 = dr("ProveedorDescripcion").ToString
                    campo_08 = dr("ProveedorDocImportePagado").ToString
                    campo_09 = dr("ProveedorDocImporteRetenido").ToString
                    campo_10 = dr("EstadoOperacion").ToString




                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124) & campo_09 & Chr(124) & campo_10 & Chr(124)

                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor



            Cursor.Current = Cursors.Default
        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 4.1 Retenciones")
            Return
        End Try

    End Sub
    Private Sub Libro901REGISCONSIGNACION(ByVal folderBrowserDialog1 As FolderBrowserDialog, ByVal mesreporte As String)
        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Rep_FlujEfectivo_MetodIndirecto", gbcodempresa, gbano, mesreporte)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            dia = Funciones.Funciones.NumeroDiasMes(mesreporte, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            'nombredearchivo = nombredearchivo + ".txt"
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("032500", gbRucEmpresa, gbano, mesreporte, dia, "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)




            'Poner cursor en modo espera


            'integrar DATOS PARA LA EXPORTACION'
            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""

            Dim dr As DataRow
            For i As Integer = dt.Tables(0).Rows.Count - 1 To 0 Step -1
                ' Obtener el valor en la columna "campo2" de la fila actual
                Dim valorCampo2 As String = Convert.ToString(dt.Tables(0).Rows(i)("Cod_Rubro"))

                ' Verificar si el valor en la columna "campo2" es vacío y eliminar la fila
                If String.IsNullOrEmpty(valorCampo2) Then
                    dt.Tables(0).Rows.RemoveAt(i)
                End If

            Next
            Using sw As StreamWriter = New StreamWriter(FilePath)
                For Each dr In dt.Tables(0).Rows
                    '    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Codigo_Catalogo_Utilizado").ToString
                    campo_03 = dr("Cod_Rubro").ToString
                    campo_04 = dr("Saldo_Rubro_Contable").ToString
                    campo_05 = dr("Estado_operacion").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & _
                    campo_04 & Chr(124) & campo_05 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next
            End Using




        Catch ex As Exception
            'strStreamWriter.Close()

            MsgBox("ERROR :: Hubo un problema al generar el libro 3.20")
            Return
        End Try

    End Sub

    Private Sub chkSeleccionTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeleccionTodo.Click
        If chkSeleccionTodo.Checked = True Then

            Dim tabPageActual As TabPage = tbcliblegales.SelectedTab
            Dim checkBoxes As New List(Of CheckBox)
            ' Verificar si el TabPage no es nulo
            If tabPageActual IsNot Nothing Then
                ' Recorrer los controles dentro del TabPage
                For Each control As Control In tabPageActual.Controls
                    If TypeOf control Is CheckBox Then
                        DirectCast(control, CheckBox).Checked = True
                        'checkBoxes.Add(DirectCast(control, CheckBox).Checked)
                        'If TypeOf control Is CheckBox AndAlso control IsNot checkBoxes AndAlso DirectCast(control, CheckBox).Checked Then
                        '    contador += 1
                        'End If
                    End If
                Next
            End If
        Else
            Dim tabPageActual As TabPage = tbcliblegales.SelectedTab
            Dim checkBoxes As New List(Of CheckBox)
            ' Verificar si el TabPage no es nulo
            If tabPageActual IsNot Nothing Then
                ' Recorrer los controles dentro del TabPage
                For Each control As Control In tabPageActual.Controls
                    If TypeOf control Is CheckBox Then
                        DirectCast(control, CheckBox).Checked = False
                        
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btn_Plantilla315_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Plantilla315.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_3749ctas") Then Exit Sub
        Dim Frm_LibLeg_3749ctas As New Frm_LibLeg_3749ctas
        '_Frm_LibLeg_Balgen.MdiParent = Me
        Frm_LibLeg_3749ctas.Owner = Me
        Frm_LibLeg_3749ctas.Show()
    End Sub

    Private Sub btnPlantilla_24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_24.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_ResultIntegra") Then Exit Sub
        Dim Frm_LibLeg_ResultIntegra As New Frm_LibLeg_ResultIntegra
        '_Frm_LibLeg_Balgen.MdiParent = Me
        Frm_LibLeg_ResultIntegra.Owner = Me
        Frm_LibLeg_ResultIntegra.Show()
    End Sub

    Private Sub btnPlantilla_25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla_25.Click
        If Funciones.Funciones.FormIsOpen("Frm_LibLeg_FlujEfectivoMetIndirecto") Then Exit Sub
        Dim Frm_LibLeg_FlujEfectivoMetIndirecto As New Frm_LibLeg_FlujEfectivoMetIndirecto
        '_Frm_LibLeg_Balgen.MdiParent = Me
        Frm_LibLeg_FlujEfectivoMetIndirecto.Owner = Me
        Frm_LibLeg_FlujEfectivoMetIndirecto.Show()
    End Sub

    Private Sub BtnRegistroCosto101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistroCosto101.Click
        Try
            If Funciones.Funciones.FormIsOpen("FrmLibLeg_101RegistroCosto") Then Exit Sub
            Dim Frm_LibLeg_101RegistroCosto As New Frm_LibLeg_101RegistroCosto
            '_Frm_LibLeg_Balgen.MdiParent = Me
            Frm_LibLeg_101RegistroCosto.Owner = Me
            Frm_LibLeg_101RegistroCosto.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn102RegistroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn102RegistroCosto.Click
        Try
            If Funciones.Funciones.FormIsOpen("Frm_RegistrarLib102CostoMensual") Then Exit Sub
            Dim Frm_RegistrarLib102CostoMensual As New Frm_RegistrarLib102CostoMensual
            '_Frm_LibLeg_Balgen.MdiParent = Me
            Frm_RegistrarLib102CostoMensual.Owner = Me
            Frm_RegistrarLib102CostoMensual.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn103RegistroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn103RegistroCosto.Click
        Try
            If Funciones.Funciones.FormIsOpen("Frm_LibLeg_103RegistroCosto") Then Exit Sub
            Dim Frm_LibLeg_103RegistroCosto As New Frm_LibLeg_103RegistroCosto
            '_Frm_LibLeg_Balgen.MdiParent = Me
            Frm_LibLeg_103RegistroCosto.Owner = Me
            Frm_LibLeg_103RegistroCosto.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn104RegistroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn104RegistroCosto.Click
        Try
            If Funciones.Funciones.FormIsOpen("Frm_LibLeg_104RegistroCosto") Then Exit Sub
            Dim Frm_LibLeg_104RegistroCosto As New Frm_LibLeg_104RegistroCosto
            '_Frm_LibLeg_Balgen.MdiParent = Me
            Frm_LibLeg_104RegistroCosto.Owner = Me
            Frm_LibLeg_104RegistroCosto.Show()

        Catch ex As Exception

        End Try
    End Sub
End Class