Option Explicit On
Option Strict On

Imports System.Text
Imports C1.Win.C1TrueDBGrid

Public Class Frm_TipodeCambio
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim Vista As DataView
    Dim FilaDeTabla As DataRowView
    Dim filaactual As Integer
#End Region

#Region "CONSTRUCTOR"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByVal pdr As DataRow, ByVal pstrAccion As String)
        Me.New()
        'mdr = pdr
        'mstrAccion = pstrAccion
    End Sub
#End Region

#Region "PROPIEDADES"
    Public Property p_accionMante() As String
        Get
            Return accionMante
        End Get
        Set(ByVal value As String)
            accionMante = value
        End Set
    End Property
    Public Property p_RegistroActivo() As DataRowView
        Get
            Return RegistroActivo
        End Get
        Set(ByVal value As DataRowView)
            RegistroActivo = value
        End Set
    End Property
#End Region
#Region "Traer Informacion de Base de Datos"

    Sub TraeTipodeCambio()
        Try
            Vista = objSql.TraerDataTable("sp_Glo_Trae_Tipos_Cambio", "Fecha Desc").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
#Region "Metodos de Mantenimiento"
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub
    Sub Nuevo()
        Me.accionMante = "N"
        Me.HabilitarMantenimiento(True)
        LimpiarControles(Me)
        '
        mskFecDoc.Focus()
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            txtComBan.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            Mod_Mantenimiento.HabyDesControles(Me, valor)
            'Perosnalizar habilitacion
            btnnuevo.Visible = Not valor
            btnmodificar.Visible = Not valor
            btneliminar.Visible = Not valor
            btnsalir.Visible = Not valor
            tblconsulta.Enabled = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
            mskFecDoc.ReadOnly = If(Me.accionMante = "M", True, Not valor)

        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Public Sub refrescarGrilla()
        Me.TraeTipodeCambio()
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
            Me.TraeTipodeCambio()
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
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                mskFecDoc.Text = filaactiva("Fecha").ToString
                txtComBan.Text = filaactiva("ComBan").ToString
                txtVenBan.Text = filaactiva("VenBan").ToString
                txtCuota.Text = filaactiva("Cuota").ToString
                txtSafp.Text = filaactiva("Safp").ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


#End Region
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        'me.cargarDatos()
        Me.HabilitarMantenimiento(False)
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Me.modificar()
    End Sub

    Sub Posicionar(ByVal campo As String, ByVal ValorCampo As String, ByVal Grilla As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal vista1 As DataView)
        Try
            campo = Trim(campo)
            ValorCampo = Trim(ValorCampo)
            '
            vista1.Sort = campo
            Dim fila As Integer = vista1.Find(ValorCampo)
            If fila <> -1 Then
                With Grilla
                    .Bookmark = fila
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Frm_TipodeCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Tipo de cambio"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Me.TraeTipodeCambio()
            HabilitarMantenimiento(False)
            '
            If Me.accionMante = "N" Then
                Me.Nuevo()
            ElseIf Me.accionMante = "M" Then
                Me.cargarDatos(RegistroActivo)
                Me.modificar()
            Else
                Me.cargarDatos(RegistroActivo)
            End If

            ' Mod_Mantenimiento.ocultarbotonespercerrado(Me)
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub eliminar()
        Dim CodigoActivo As String
        Dim CodigoActivoAnt As String
        Dim filaAnterior As Integer
        Dim FilaDeTablaAnterior As DataRowView

        Try
            '=============Validaciones ============
            'Capturo la fila anterior para posicionarme despues de la eliminacion
            If filaactual > 0 Then
                filaAnterior = filaactual - 1
            Else
                filaAnterior = filaactual
            End If
            FilaDeTablaAnterior = Vista.Table.DefaultView.Item(filaAnterior)

            CodigoActivoAnt = FilaDeTablaAnterior("Fecha").ToString
            CodigoActivo = FilaDeTabla("Fecha").ToString
            '
            Beep()
            If MessageBox.Show("AVISO :: Esta seguro de Eliminar el REGISTRO : " & mskFecDoc.Text, "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("sp_Glo_Del_Tipo_Cambio", mskFecDoc.Text, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("Fecha", CodigoActivoAnt, tblconsulta, Vista)
            Else
                'No hago nada
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Me.eliminar()
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Try
            Me.capturarfilaactual()
            Me.cargarDatos(FilaDeTabla)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'Valido fecha
            If Not IsDate(mskFecDoc.Text) Then MessageBox.Show("VALIDACION :: Fecha no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : mskFecDoc.Focus() : Exit Sub
            '
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            If accionMante = "N" Then
                'a = objSql.Ejecutar2("sp_Glo_Ins_Tipo_Cambio", mskFecDoc.Text, CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtCuota.Text, Double), CType(txtSafp.Text, Double), gbNameUser, mskFecDoc.Text, "I", "")
                a = objSql.Ejecutar2("sp_Glo_Ins_Tipo_Cambio", mskFecDoc.Text, CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtCuota.Text, Double), CType(txtSafp.Text, Double), "")
            ElseIf accionMante = "M" Then
                'a = objSql.Ejecutar2("sp_Glo_Upd_Tipo_Cambio", mskFecDoc.Text, CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtCuota.Text, Double), CType(txtSafp.Text, Double), gbNameUser, mskFecDoc.Text, "M", "")
                a = objSql.Ejecutar2("sp_Glo_Upd_Tipo_Cambio", mskFecDoc.Text, CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtComBan.Text, Double), CType(txtVenBan.Text, Double), CType(txtCuota.Text, Double), CType(txtSafp.Text, Double), "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("Fecha", mskFecDoc.Text, tblconsulta, Vista)
                Me.HabilitarMantenimiento(False)
            Else
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub mskFecDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFecDoc.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
    Public Shared Function ConvertiraXMLdinamico(ByVal lista As IEnumerable(Of String)) As String
        Dim sb As New StringBuilder()
        sb.Append("<DataSet>")

        ' Recorrer filas
        For Each fila As String In lista
            ' Recorrer columnas
            Dim celdas As String() = fila.Split("|"c)
            sb.Append("<tbl>")

            ' Recorrer columnas
            Dim initagcampo As String = "", endtagcampo As String = ""
            For i As Integer = 0 To celdas.Length - 1
                initagcampo = "<campo" & (i + 1).ToString() & ">"
                endtagcampo = "</campo" & (i + 1).ToString() & ">"
                sb.Append(initagcampo)

                celdas(i) = celdas(i).Replace("&", "&amp;")
                sb.Append(celdas(i).ToString())
                sb.Append(endtagcampo)
            Next

            sb.Append("</tbl>")
        Next

        sb.Append("</DataSet>")
        Return sb.ToString()
    End Function
    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Try
            Dim objR As New Ks.Com.Win.CystalReports.Net.File
            Dim nombredereporte As String
            Dim ds As System.Data.DataSet
            Dim Rutareporte As String
            Dim flagtiporeporte As String = "RPTTIC"

            Dim flag As String = "0"


            If (tblconsulta.SelectedRows.Count <> tblconsulta.RowCount) Then

                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
                flag = "0" 'filtro
            Else
                flag = "1" 'todo
            End If

            Rutareporte = gbRutaReportes()
            nombredereporte = "Rpt_TipoCambio.rpt"
            ' Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString


            ds = objSql.TraerDataSet("Spu_Con_Rep_TipoCambio", gbcodempresa, gbNameUser, flagtiporeporte, flag).Copy()
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, Nothing, enmWindowState.Maximizado)

            'Elimnar rango de impresion
            Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte)

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla_sinfiladefiltro(tblconsulta)
    End Sub
End Class