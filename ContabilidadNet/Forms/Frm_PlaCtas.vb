Option Explicit On
Option Strict On
Public Class Frm_PlaCtas
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Private HijoActivo As Integer
    Dim filaactual As Integer
    Dim flagcontrolcbonivel As Boolean
#Region "Propiedades"
    Public Property P_FilaDeTabla() As DataRowView
        Get
            Return FilaDeTabla
        End Get
        Set(ByVal value As DataRowView)
            FilaDeTabla = value
        End Set
    End Property
    Public Property P_HijoActivo() As Integer
        Get
            Return HijoActivo
        End Get
        Set(ByVal value As Integer)
            HijoActivo = value
        End Set
    End Property
#End Region
#Region "Metodos"
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub TraerPlanctas(ByVal nivel As Integer)
        Try
            Cursor.Current = Cursors.WaitCursor
            Vista = objSql.TraerDataTable("sp_Con_Trae_Plan_Cuentas_New", gbcodempresa, gbano, "ccm01cta", "*", nivel).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)

            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Frm_CtaCte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nivel As Integer
        Try

            Me.Text = "Plan de cuentas"
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)

            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btnver, gbc_Ttp_Ver)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnimprimir, gbc_Ttp_ImpDir)
            Mod_Mantenimiento.tooltiptext(btvistaprevia, gbc_Ttp_ImpVp)
            Mod_Mantenimiento.tooltiptext(btnCopiarCtas, "Crear Cuentas basados en otras cuentas existentes")
            Mod_Mantenimiento.tooltiptext(btnseleccionartodo_0, gbc_Ttp_SelecTodasFilas)

            flagcontrolcbonivel = False
            Mod_BaseDatos.LlenarComboNivelPlaCtas(cboniveles, gbcodempresa, gbano)
            cboniveles.Text = "Nivel 12"
            nivel = CType(cboniveles.SelectedValue.ToString, Integer)
            flagcontrolcbonivel = True
            Me.TraerPlanctas(nivel)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ''
    End Sub
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        If Funciones.Funciones.FormIsOpen("Frm_PlaCtas_Abc") Then Exit Sub
        Dim _Frm_PlaCtas_Abc As New Frm_PlaCtas_Abc()
        Try
            _Frm_PlaCtas_Abc.p_accionMante = "N"
            _Frm_PlaCtas_Abc.Owner = Me
            _Frm_PlaCtas_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Dim FilaDeTabla As DataRowView
        Dim filaactual As Integer
        If Funciones.Funciones.FormIsOpen("Frm_PlaCtas_Abc") Then Exit Sub

        Dim _Frm_PlaCtas_Abc As New Frm_PlaCtas_Abc()

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_PlaCtas_Abc.Owner = Me
            _Frm_PlaCtas_Abc.p_accionMante = "M"
            _Frm_PlaCtas_Abc.p_RegistroActivo = FilaDeTabla
            _Frm_PlaCtas_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnver.Click
        'Validar si esta abierto
        If Funciones.Funciones.FormIsOpen("Frm_PlaCtas_Abc") Then Exit Sub
        '
        Dim _Frm_PlaCtas_Abc As New Frm_PlaCtas_Abc
        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_PlaCtas_Abc.p_accionMante = "V"
            _Frm_PlaCtas_Abc.p_RegistroActivo = FilaDeTabla
            _Frm_PlaCtas_Abc.Owner = Me
            _Frm_PlaCtas_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblconsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblconsulta.DoubleClick
        Me.btnver_Click(Nothing, Nothing)
    End Sub

    Private Sub btnsiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsiguiente.Click
        Me.grilla_registro_siguiente()
    End Sub
    Public Sub grilla_registro_siguiente()
        Try
            tblconsulta.MoveNext()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub grilla_registro_Anterior()
        Try
            tblconsulta.MovePrevious()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub grilla_registro_Primero()
        'Mover a la siguiente fila de la grilla
        Try
            tblconsulta.MoveFirst()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub grilla_registro_Ultimo()
        'Mover a la siguiente fila de la grilla
        Try
            tblconsulta.MoveLast()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub refrescarGrilla()
        Me.TraerPlanctas(12)
    End Sub
    Public Sub refrescarGrillaConFiltro()
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim i As Integer = 0
        Try

            Dim myObjArray As Array = Array.CreateInstance(GetType(Object), 50, 2)  '50columnas x 2 fila

            'Guardar estado de filtro
            For Each dc In Me.tblconsulta.Columns
                If CType(dc.FilterText, String) <> "" Then
                    myObjArray.SetValue(dc.DataField, i, 0) 'Agrego valor del parametro
                    myObjArray.SetValue(dc.FilterText, i, 1) 'Agrego nombre del parametro
                End If
                i = i + 1
            Next dc

            'refresacar desde la base de datos
            Me.TraerPlanctas(12)
            'Aplicar el filtro guardado
            'Inicilizo i a 0
            i = 0
            For Each dc In Me.tblconsulta.Columns
                If CType(dc.FilterText, String) <> "" Then
                    'Si estan filtrados por el mismo campo
                    If dc.DataField = myObjArray.GetValue(i, 0).ToString Then
                        dc.FilterText = myObjArray.GetValue(i, 1).ToString
                    End If
                End If
                i = i + 1
            Next dc
        Catch ex As Exception
        End Try
    End Sub
    Sub Posicionar(ByVal campo As String, ByVal ValorCampo As String)
        Try
            campo = Trim(campo)
            ValorCampo = Trim(ValorCampo)
            '
            Vista.Sort = campo
            Dim fila As Integer = Vista.Find(ValorCampo)
            If fila <> -1 Then
                With tblconsulta
                    .Bookmark = fila
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Me.capturarfilaactual()
    End Sub
    Private Sub btnanterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnanterior.Click
        Me.grilla_registro_Anterior()
    End Sub
    Private Sub btnprimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprimero.Click
        Me.grilla_registro_Primero()
    End Sub
    Private Sub btnultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnultimo.Click
        Me.grilla_registro_Ultimo()
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        '
        Dim codigo As String

        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
        Try

            codigo = FilaDeTabla("ccm01cta").ToString

            If MessageBox.Show("¿ Está seguro de Eliminar ?" & codigo, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
            a = objSql.Ejecutar2("sp_Con_Del_Cuenta", gbcodempresa, gbano, codigo, "")

            'Armar Identificador de Fila
            Dim i As Integer
            If a.GetValue(1, 0).ToString <> "-1" Then 'Lee la variable RETURN_VALUES
                'Otros Mnsajes
                For i = 1 To a.GetUpperBound(0)
                    MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Next
                Me.refrescarGrillaConFiltro()
            Else
                For i = 1 To a.GetUpperBound(0)
                    MessageBox.Show(a.GetValue(1, i).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnver_Click(Nothing, Nothing)
        End If
    End Sub
    Sub imprimir(ByVal flagimpresion As String)
        Dim objR As New Ks.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of Ks.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String = ""
        Dim nombredereporte As String = ""
        Dim Rutareporte As String
        'LLeno el rango de valores
        Try
            flagtiporeporte = "PLANCTAS"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Cursor.Current = Cursors.WaitCursor
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show(gbc_MensajeValidar + "Seleccione registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            Rutareporte = gbRutaReportes
            '========================================
            nombredereporte = If(gbTipoImpresora = "I", "planctar_it.Rpt", "planctar.Rpt")

            'Sp que trae datos del reporte
            ds = objSql.TraerDataSet("sp_Con_Rep_Plan_Cuentas", gbcodempresa, "ccm01cta", gbNameUser, gbano).Copy()
            '
            arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))

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
        Dim Rutareporte As String
        'LLeno el rango de valores
        Try

            flagtiporeporte = "PLANCTAS"
            'Inserto los valores selecioandos
            If tblconsulta.SelectedRows.Count > 0 Then
                Cursor.Current = Cursors.WaitCursor
                Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            Else
                MessageBox.Show(gbc_MensajeValidar + "Seleccione registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            Rutareporte = gbRutaReportes
            '========================================
            nombredereporte = If(gbTipoImpresora = "I", "planctar_it.Rpt", "planctar.Rpt")
            'Sp que trae datos del reporte
            'Sp que trae datos del reporte
            ds = objSql.TraerDataSet("sp_Con_Rep_Plan_Cuentas", gbcodempresa, "ccm01cta", gbNameUser, gbano).Copy()
            '
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))

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
    Private Sub cboniveles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboniveles.SelectedIndexChanged
        Dim nivel As Integer
        Try
            If flagcontrolcbonivel = True Then
                nivel = CType(cboniveles.SelectedValue.ToString, Integer)
                Me.TraerPlanctas(nivel)
            End If
        Catch ex As Exception
            MessageBox.Show(gbc_MensajeError + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Me.imprimir_verant("P")
    End Sub

    Private Sub btnCopiarCtas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiarCtas.Click
        If Funciones.Funciones.FormIsOpen("Frm_PlaCtas_Copiar") Then Exit Sub
        Dim _Frm_PlaCtas_Copiar As New Frm_PlaCtas_Copiar

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then MessageBox.Show(gbc_MensajeValidar + "No existen Cuentas", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            '
            If FilaDeTabla("ccm01mov").ToString = "S" Then MessageBox.Show(gbc_MensajeValidar + "Solo se pueden copiar cuentas Madres", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            _Frm_PlaCtas_Copiar.Owner = Me
            _Frm_PlaCtas_Copiar.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
    End Sub
End Class