Option Explicit On
Option Strict On

Imports System.IO

Public Class Frm_LibLeg_104RegistroCosto
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim Vista As DataView
    Dim FilaDeTabla As DataRowView
    Dim filaactual As Integer

    'Variable para 
    Dim AccPerCon As String
    Dim VarImpChe As String

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
    'Public Property p_RegistroActivo() As DataRowView
    '    Get
    '        Return RegistroActivo
    '    End Get
    '    Set(ByVal value As DataRowView)
    '        RegistroActivo = value
    '    End Set
    'End Property
#End Region
#Region "Traer Informacion de Base de Datos"

    Sub TraeTrabEnCurso()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_cc25trabajosencurso", gbcodempresa, gbano, "*", "cc25codigo").DefaultView
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
            filaactual = Me.BindingContext(Vista).Position
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub
    Sub Nuevo()
        Me.accionMante = "N"
        Me.HabilitarMantenimiento(True)
        LimpiarControles(Me)
        '
        'txtCodigo.Focus()
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            'txtDescri.Focus()
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
            btnimportar.Visible = Not valor
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Public Sub refrescarGrilla()
        Me.cargarDatos()
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
            Me.TraeTrabEnCurso()
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
    Public Sub CrearColumnas()
        Dim dt As DataTable = New DataTable
        Try

            dt.Columns.Add("co07ITEM", GetType(String))
            dt.Columns.Add("co07DESCRIPCION", GetType(String))
            dt.Columns.Add("co07ASIENTOTIPOCOD", GetType(String))
            dt.Columns.Add("ccc03des", GetType(String))
            dt.Columns.Add("co07NOMENCLATURA", GetType(String))
            tblconsulta.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub
    Sub cargarDatos()
        Try

            Vista = objSql.TraerDataTable("Spu_Con_Trae_lc104RegCosCentroCosto", gbcodempresa, gbano).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.capturarfilaactual()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


#End Region
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        'me.cargarDatos()
        Frm_LibLeg_104RegistroCosto_Load(Nothing, Nothing)
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

    Private Sub Frm_LibLeg_104RegistroCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            cargarDatos()
            cargarFila(FilaDeTabla)
            HabilitarMantenimiento(False)
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub cargarFila(ByVal filaactiva As DataRowView)

        Try
            Dim Importe As Decimal
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtSede.Text = tblconsulta.Item(tblconsulta.Row, "lc104UnidadOperacionCod").ToString().Trim()
                lblhelp_0.Text = tblconsulta.Item(tblconsulta.Row, "lc104UnidadOperacionDes").ToString().Trim()
                'txtCuentaContable.Text = tblconsulta.Item(tblconsulta.Row, "lc101CtaCble").ToString().Trim()

                'Importe = Convert.ToDecimal(tblconsulta.Item(tblconsulta.Row, "lc101CtaCble").ToString().Trim())
                txtCCosto.Text = tblconsulta.Item(tblconsulta.Row, "lc104CentroCostoCod").ToString.Trim
                lblhelp_1.Text = (tblconsulta.Item(tblconsulta.Row, "lc104CentroCostoDesc")).ToString.Trim
                'If txtCuentaContable.Text = "" Then
                '    lblhelp_0.Text = ""
                'Else
                '    lblhelp_0.Text = DameDescripcion(txtCuentaContable.Text.ToString().Trim(), "AT")
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub eliminar()
        Dim CodigoActivo As String
        Dim CodigoActivoAnt As String
        Dim filaAnterior As Integer
        Dim FilaDeTablaAnterior As DataRowView
        Dim ITEM As Integer
        Dim flag As Integer
        Dim msgretorno As String = ""
        Try
            '=============Validaciones ============
            'Capturo la fila anterior para posicionarme despues de la eliminacion
            'If filaactual > 0 Then
            '    filaAnterior = filaactual - 1
            'Else
            '    filaAnterior = filaactual
            'End If
            'FilaDeTablaAnterior = Vista.Table.DefaultView.Item(filaAnterior)

            'CodigoActivoAnt = FilaDeTablaAnterior("co09ITEM").ToString
            'CodigoActivo = FilaDeTabla("co09ITEM").ToString
            ''
            Beep()
            If MessageBox.Show("AVISO :: Esta seguro de Eliminar el REGISTRO : " & tblconsulta.Item(tblconsulta.Row, "lc104Correlativo").ToString().Trim(), "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            '  ITEM = Convert.ToInt32(txtCodigo.Text.ToString())
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_lc104RegCosCentroCosto", gbcodempresa, gbano, tblconsulta.Item(tblconsulta.Row, "lc104Correlativo").ToString(), "")
            Cursor.Current = Cursors.WaitCursor
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                ' String mensaje = a(1,2)
                lblhelp_0.Text = ""
                Frm_LibLeg_104RegistroCosto_Load(Nothing, Nothing)

                ' Me.Posicionar("cc25codigo", txtCodigo.Text.Trim, tblconsulta, Vista)
            Else
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
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
            txtSede.Text = tblconsulta.Item(tblconsulta.Row, "lc104UnidadOperacionCod").ToString().Trim()
            lblhelp_0.Text = tblconsulta.Item(tblconsulta.Row, "lc104UnidadOperacionDes").ToString().Trim()

       
            txtCCosto.Text = tblconsulta.Item(tblconsulta.Row, "lc104CentroCostoCod").ToString().Trim()
            lblhelp_1.Text = tblconsulta.Item(tblconsulta.Row, "lc104CentroCostoDesc").ToString().Trim()

            Me.cargarFila(FilaDeTabla)
        Catch ex As Exception
        End Try
    End Sub
    Function DameDescripcion(ByVal cCodigoBus As String, ByVal cFlag As String) As String
        ' Obtengo la Descripcion
        Try
            DameDescripcion = CType(objSql.TraerValor("sp_Con_Dame_Descripcion", gbcodempresa, cCodigoBus, cFlag, ""), String)
        Catch ex As Exception
            DameDescripcion = ""
        End Try
    End Function
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim clave As String = ""
        Try
            Dim flag As Integer = 0
            Dim MsgRetorno As String = ""
            'Valido usuario y clave
            '   If txtCodigo.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Codigo no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCodigo.Focus() : Exit Sub
            If txtSede.Text.Trim = "" Then MessageBox.Show("Seleccione una sede", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtSede.Focus() : Exit Sub
            
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            Cursor.Current = Cursors.WaitCursor

            If accionMante = "N" Then
                a = objSql.Ejecutar2("Spu_Con_Ins_lc104RegCosCentroCosto", gbcodempresa, gbano, txtSede.Text.ToString.Trim(), lblhelp_0.Text.ToString.Trim, txtCCosto.Text.ToString.Trim, lblhelp_1.Text.ToString.Trim, "")
            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("Spu_Con_Upd_lc104RegCosCentroCosto", gbcodempresa, gbano, tblconsulta.Item(tblconsulta.Row, "lc104Correlativo").ToString().Trim(), txtSede.Text.ToString.Trim(), lblhelp_0.Text.ToString.Trim, txtCCosto.Text.ToString.Trim, lblhelp_1.Text.ToString.Trim, "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.cargarDatos()
                Frm_LibLeg_104RegistroCosto_Load(Nothing, Nothing)
                ' Me.Posicionar("co07ITEM", txtCodigo.Text.Trim, tblconsulta, Vista)

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
    Sub CopiarPortapapeles()
        Try
            Dim strTemp As String

            Dim row As Long

            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Dim cols As Integer, rows As Long

            If tblconsulta.SelectedRows.Count > 0 Then

                For Each row In Me.tblconsulta.SelectedRows

                    ' Copy everything here.

                    For Each col In tblconsulta.SelectedCols

                        strTemp = strTemp & col.CellText(CInt(row)) & vbTab

                    Next

                    strTemp = strTemp & vbCrLf

                Next
            End If

            System.Windows.Forms.Clipboard.SetDataObject(strTemp, False)
        Catch ex As Exception

        End Try

    End Sub
    Sub CopiarPorta()
        Dim filaSeleccionada As Integer
        Dim j As Integer = 0
        Try
            Dim registrosSeleccionados(tblconsulta.SelectedRows.Count - 1) As String

            ' Obtener texto de las filas seleccionadas
            Dim selectedText As String = ""
            For Each filaSeleccionada In tblconsulta.SelectedRows

                registrosSeleccionados(j) = tblconsulta.Item(filaSeleccionada, "co07ITEM").ToString() + " " + tblconsulta.Item(filaSeleccionada, "co07DESCRIPCION").ToString() + " " + tblconsulta.Item(filaSeleccionada, "co07ASIENTOTIPOCOD").ToString() + " " + tblconsulta.Item(filaSeleccionada, "ccc03des").ToString() + " " + tblconsulta.Item(filaSeleccionada, "co07NOMENCLATURA").ToString()
                j += 1

            Next
            Dim datos As String = String.Join(vbCrLf, registrosSeleccionados.Select(Function(x) String.Join(vbTab, x)))
            System.Windows.Forms.Clipboard.SetDataObject(datos, False)
        Catch ex As Exception

        End Try
    End Sub

    Sub TraerAsientoTipo(ByVal TipoGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ComAsientosTipo", gbcodempresa, gbano, "", "*").DefaultView
            TipoGrid.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerAyuda(ByVal index As Integer, ByVal descripcion As String, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp_0.Location = New Point(x, y)
            Mod_Mantenimiento.LimpiarFiltro(tblhelp_0)
            tblhelp_0.Columns(0).Caption = "Codigo"
            tblhelp_0.Columns(1).Caption = "Descripcion"

            Select Case index
                'SEDE
                Case 0
                    tblhelp_0.Splits(0).DisplayColumns("Codigo").Visible = True
                    tblhelp_0.Columns(0).DataField = "FAC63CODESTAB"
                    tblhelp_0.Columns(1).DataField = "FAC63DESESTAB"
                    Me.TraerSede(tblhelp_0)
                    tblhelp_0.Visible = True
                    tblhelp_0.Focus()
                    'CENTRO COSTO
                Case 1
                    '    'CENTRO COSTO
                    tblhelp_0.Splits(0).DisplayColumns("Codigo").Visible = True
                    tblhelp_0.Columns(0).DataField = "ccb02cod"
                    tblhelp_0.Columns(1).DataField = "ccb02des"
                    Me.TraerCentroCosto(tblhelp_0)

                    tblhelp_0.Visible = True
                    tblhelp_0.Focus()
                    '    tblhelp_0.Focus()
                    'Case 2
                    '    'ASIENTO TIPO
                    '    tblhelp_0.Splits(0).DisplayColumns("Codigo").Visible = True
                    '    tblhelp_0.Columns(0).DataField = "ccc03cod"
                    '    tblhelp_0.Columns(1).DataField = "ccc03des"
                    '    tblhelp_0.Columns(2).DataField = "ccc03lib"
                    '    Me.TraerAsientoTipo(tblhelp_0)
                    '    tblhelp_0.Visible = True
                    '    tblhelp_0.Focus()

                Case 3
                    'IMPORTACION LIBRO 101
                    tblhelp_0.Splits(0).DisplayColumns("Codigo").Visible = False
                    ' tblhelp_0.Columns(0).DataField = "lc101Empresa"
                    tblhelp_0.Columns(1).DataField = "lc104Anio"
                    Me.Traeimportacion()
                    tblhelp_0.Visible = True
                    tblhelp_0.Focus()

            End Select

            tblhelp_0.Tag = index.ToString
            '  tblhelp1_bloque.Refresh()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerSede(ByVal TipoGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Vista = objSql.TraerDataTable("Spu_Fact_Help_FAC63_ESTABLECIMIENTOS", gbcodempresa, "", "*").DefaultView
            TipoGrid.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerCentroCosto(ByVal TipoGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_CentroCosto", gbcodempresa, gbano).DefaultView
            TipoGrid.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim RowIndex As Integer
        Try
            RowIndex = tblconsulta.Row
            Select Case indice
                'SEDE
                Case 0
                    '    '
                    txtSede.Text = tblhelp_0.Columns("FAC63CODESTAB").Value.ToString()
                    lblhelp_0.Text = tblhelp_0.Columns("FAC63DESESTAB").Value.ToString()

                Case 1
                    '    'CENTRO COSTO
                    txtCCosto.Text = tblhelp_0.Columns("ccb02cod").Value.ToString
                    lblhelp_1.Text = tblhelp_0.Columns("ccb02des").Value.ToString
                    '    ' txtLibro.Focus()
                Case 3
                    Dim anioanterior As String
                    anioanterior = tblhelp_0.Columns(1).Value.ToString

                    If MessageBox.Show("¿Esta Seguro de importar datos del año : " & anioanterior, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
                        Cursor.Current = Cursors.WaitCursor
                        Frm_LibLeg_104RegistroCosto_Load(Nothing, Nothing)
                        a = objSql.Ejecutar2("Spu_Con_Ins_PerAntlc104RegCosCentroCosto", gbcodempresa, gbano, anioanterior, "")
                        If Funciones.Funciones.MensajesdelSQl(a) = True Then
                            Frm_LibLeg_104RegistroCosto_Load(Nothing, Nothing)
                            tblhelp_0.Visible = False
                        Else
                            'No hago nada
                            tblhelp_0.Visible = False
                            cargarDatos()
                        End If

                        Cursor.Current = Cursors.Default
                    End If
            End Select

            '            Vista.Dispose()
            tblhelp_0.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Try
            TraerAyuda(0, "", btnhelp_0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp_0.LostFocus
        Try
            tblhelp_0.Visible = False
            Vista.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_0_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp_0.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp_0.Tag, Integer)
        Try
            If tblhelp_0.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp_0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_0_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp_0.KeyDown
        Try
            If tblhelp_0.Visible = True Then
                If e.KeyCode = Keys.Escape Then
                    tblhelp_0.Visible = False
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                tblhelp_0_DoubleClick(Nothing, Nothing)
                tblhelp_0.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Frm_Motivo_Compras_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If tblhelp_0.Visible = True Then
                If e.KeyCode = Keys.Escape Then
                    tblhelp_0.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'CopiarPortapapeles()
            CopiarPorta()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Try
            Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnimportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimportar.Click
        Try
            Me.TraerAyuda(3, "", btnhelp_0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Traeimportacion()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_lc104RegCosCentroCostoxanio", gbcodempresa).DefaultView
            tblhelp_0.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSede_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSede.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                TraerAyuda(0, "", btnhelp_0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_help1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Try
            TraerAyuda(1, "", btnhelp_1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCCosto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCCosto.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                TraerAyuda(1, "", btnhelp_1)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class