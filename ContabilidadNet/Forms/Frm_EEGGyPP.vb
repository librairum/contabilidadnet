Option Strict On
Option Explicit On
Public Class Frm_EEGGyPP

    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Sub TraeEstructura(ByVal Tiporeporte As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_cc01estructEGyPComp", gbcodempresa, Tiporeporte, gbano).DefaultView
            tblconsulta_1.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeEstructura_tblconsulta2(ByVal Tiporeporte As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_cc01estructEGyPComp_PLE", gbcodempresa, Tiporeporte, gbano).DefaultView
            tblconsulta_2.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraeEstadoggypp(ByVal tipoestado As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Config_EstadoGGyPP", gbcodempresa, gbano, tipoestado).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim nombredereporte As String = ""
        Dim Rutareporte As String
        Dim mesdeEstadoggyperd As String

        Dim perio_estgayper As String
        Dim Fecha_estgayper As String
        Dim Fecha_estgaypercom As String


        mesdeEstadoggyperd = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)

        'LLeno el rango de valores
        Try

            Rutareporte = gbRutaReportes
            Cursor.Current = Cursors.WaitCursor
            '========================================
            '========================================
            If tabEGyP.SelectedIndex = 0 Then 'El normal
                If gbAjuste = "N" Then
                    nombredereporte = If(gbTipoImpresora = "I", "EstGaPer_it.Rpt", "EstGaPer.Rpt")
                Else
                    nombredereporte = If(gbTipoImpresora = "I", "EsGaPeAj.Rpt", "EsGaPeAj_it.Rpt")
                End If

                Dim Tipodeestado As String
                Tipodeestado = If(rbtEstado_0.Checked = True, "F", "N")

                'Sp que trae datos del reporte
                'Data del reporte
                ds = objSql.TraerDataSet("sp_Con_Rep_Estado_GGPP", gbcodempresa, gbano, mesdeEstadoggyperd, gbmoneda, Tipodeestado, gbSaldos).Copy()

                'Formulas de reporte
                
                perio_estgayper = "ESTADO DE GANANCIAS Y PERDIDAS " & If(gbAjuste = "N", "", "AJUSTADOS ") & "AL " & Funciones.Funciones.Formatofechacontable(mesdeEstadoggyperd, gbano)
                Fecha_estgayper = "LIMA, " & Funciones.Funciones.Formatofechacontable(mesdeEstadoggyperd, gbano)

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Direccion", gbDirEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", perio_estgayper))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Fecha", Fecha_estgayper))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa$))

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Anio", gbano))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Mes", mesdeEstadoggyperd))


            ElseIf tabEGyP.SelectedIndex = 1 Then 'Es el comprativo
                'Ruta y nombre de reporte
                nombredereporte = If(gbTipoImpresora = "I", "Rpt_EGyPComparativo.Rpt", "rpt_egypcomparativo_carta.Rpt")
                'Procedimiento
                Dim Anioanterior As String
                Dim tiporeporte As String
                Dim titulo As String

                Anioanterior = CStr(CInt(gbano) - 1)
                tiporeporte = If(rbttiprepcom_0.Checked = True, "F", "N")
                titulo = "ESTADO DE GANANCIAS Y PERDIDAS" + If(rbttiprepcom_0.Checked = True, " POR FUNCION)", " POR NATURALEZA")

                ds = objSql.TraerDataSet("Spu_Con_Rep_EGyPCom", gbcodempresa, gbano, mesdeEstadoggyperd, Anioanterior, tiporeporte, gbmoneda).Copy()

                'Formulas
                Fecha_estgaypercom = Funciones.Funciones.Formatofechacontable(mesdeEstadoggyperd, gbano)

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa$))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("fecha", Fecha_estgaypercom))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", titulo))

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Anio", gbano))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Mes", mesdeEstadoggyperd))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("AnioAnt", Anioanterior))


                'AL TAB 2 COMPARATIVO PLE 
            ElseIf tabEGyP.SelectedIndex = 2 Then 'Es el comprativo
                'Ruta y nombre de reporte
                nombredereporte = If(gbTipoImpresora = "I", "Rpt_EGyPComparativo.Rpt", "rpt_egypcomparativo_carta.Rpt")
                'Procedimiento
                Dim Anioanterior As String
                Dim tiporeporte As String
                Dim titulo As String

                Anioanterior = CStr(CInt(gbano) - 1)
                tiporeporte = If(rbttiprepcom_0_PLE.Checked = True, "F", "N")
                titulo = "ESTADO DE GANANCIAS Y PERDIDAS" + If(rbttiprepcom_0_PLE.Checked = True, " POR FUNCION)", " POR NATURALEZA")

                ds = objSql.TraerDataSet("Spu_Con_Rep_EGyPCom_PLE", gbcodempresa, gbano, mesdeEstadoggyperd, Anioanterior, tiporeporte, gbmoneda).Copy()

                'Formulas
                Fecha_estgaypercom = Funciones.Funciones.Formatofechacontable(mesdeEstadoggyperd, gbano)

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("ruc", gbRucEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", cboperiodos.Text))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Representante", gbRepEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Cargo", gbCarEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Contador", gbConEmpresa))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Matricula", gbMatEmpresa$))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("fecha", Fecha_estgaypercom))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Moneda", Funciones.Funciones.DescripcionMoneda(gbmoneda)))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Titulo", titulo))

                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Anio", gbano))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Mes", mesdeEstadoggyperd))
                arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("AnioAnt", Anioanterior))

            End If

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
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Me.imprimir_verant("I")
    End Sub

    Private Sub Frm_EEGGyPP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Me.Text = "Estado de Ganancias y Perdidas"
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnConfigurar, "Configurar")
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            'Llena combo periodos
            Mod_BaseDatos.LlenarComboPeriodos(cboperiodos, gbcodempresa, gbano)
            '
            cboperiodos.SelectedIndex = CType(gbmes, Integer)

            tabEGyP.SelectedTab = tabEGyP.TabPages(1)
            '
            Me.TraeEstadoggypp("N")
            Me.TraeEstructura("N")
            Me.TraeEstructura_tblconsulta2("F")

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

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs)

    End Sub

    Private Sub rbtEstado_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtEstado_0.Click
        Me.TraeEstadoggypp("F")
    End Sub

    Private Sub rbtEstado_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtEstado_1.Click
        Me.TraeEstadoggypp("N")
    End Sub

    Private Sub btnConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigurar.Click
        Dim tiporep As String = ""

        If tabEGyP.SelectedIndex = 0 Then 'EGyP  Normal


        ElseIf tabEGyP.SelectedIndex = 1 Then 'EGyP comparativos

            If rbttiprepcom_0.Checked = True Then
                tiporep = "F"
            Else
                tiporep = "N"
            End If

            If Funciones.Funciones.FormIsOpen("Frm_EEGGyPPCom_Conf") Then Exit Sub
            Dim _Frm_EEGGyPPCom_Conf As New Frm_EEGGyPPCom_Conf

            Try
                _Frm_EEGGyPPCom_Conf.MdiParent = MDIPrincipal.ParentForm
                _Frm_EEGGyPPCom_Conf.p_Tiporeporte = tiporep
                _Frm_EEGGyPPCom_Conf.Owner = Me
                _Frm_EEGGyPPCom_Conf.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        ElseIf tabEGyP.SelectedIndex = 2 Then

            If rbttiprepcom_0_PLE.Checked = True Then
                tiporep = "F"
            Else
                tiporep = "N"
            End If
            If Funciones.Funciones.FormIsOpen("Frm_EEGGyPPCom_Conf_PLE") Then Exit Sub
            Dim _Frm_EEGGyPPCom_Conf_PLE As New Frm_EEGGyPPCom_Conf_PLE
            Try
                _Frm_EEGGyPPCom_Conf_PLE.MdiParent = MDIPrincipal.ParentForm
                _Frm_EEGGyPPCom_Conf_PLE.p_Tiporeporte = tiporep
                _Frm_EEGGyPPCom_Conf_PLE.Owner = Me
                _Frm_EEGGyPPCom_Conf_PLE.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub rbttiprepcom_0_PLE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbttiprepcom_0_PLE.CheckedChanged
        Me.TraeEstructura_tblconsulta2("F")
    End Sub

    Private Sub rbttiprepcom_1_PLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbttiprepcom_1_PLE.Click
        Me.TraeEstructura_tblconsulta2("N")
    End Sub
End Class