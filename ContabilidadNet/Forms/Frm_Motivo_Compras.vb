Option Explicit On
Option Strict On
Public Class Frm_Motivo_Compras
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
        '  txtCodigo.Focus()
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            txtDescri.Focus()
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
            ' txtCodigo.ReadOnly = If(Me.accionMante = "M", True, Not valor)
        Catch ex As Exception
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Public Sub refrescarGrilla()
        Me.TraeTrabEnCurso()
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

            Vista = objSql.TraerDataTable("Spu_Con_Trae_co07MotivosDocPorPagar", gbcodempresa, gbano).DefaultView
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
        Frm_Motivo_Compras_Load(Nothing, Nothing)
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

      Private Sub Frm_Motivo_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtCodigo.Text = tblconsulta.Item(tblconsulta.Row, "co07ITEM").ToString().Trim()
                txtDescri.Text = tblconsulta.Item(tblconsulta.Row, "CO07DESCRIPCION").ToString().Trim()
                txtAsientoTipoCod.Text = tblconsulta.Item(tblconsulta.Row, "CO07ASIENTOTIPOCOD").ToString().Trim()
                txtNomenclatura.Text = tblconsulta.Item(tblconsulta.Row, "CO07NOMENCLATURA").ToString().Trim()
                If txtAsientoTipoCod.Text = "" Then
                    lblhelp_0.Text = ""
                Else
                    lblhelp_0.Text = DameDescripcion(txtAsientoTipoCod.Text.ToString().Trim(), "AT")
                End If

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
            If MessageBox.Show("AVISO :: Esta seguro de Eliminar el REGISTRO : " & txtCodigo.Text.Trim, "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ITEM = Convert.ToInt32(txtCodigo.Text.ToString())
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_co07MotivosDocPorPagar", gbcodempresa, txtDescri.Text.ToString.Trim(), ITEM, msgretorno)
            Cursor.Current = Cursors.WaitCursor
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                ' String mensaje = a(1,2)
                lblhelp_0.Text = ""
                Frm_Motivo_Compras_Load(Nothing, Nothing)

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
            txtCodigo.Text = tblconsulta.Item(tblconsulta.Row, "co07ITEM").ToString().Trim()
            txtDescri.Text = tblconsulta.Item(tblconsulta.Row, "CO07DESCRIPCION").ToString().Trim()

            If txtAsientoTipoCod.Text = "" Then
                lblhelp_0.Text = ""
            Else
                lblhelp_0.Text = DameDescripcion(txtAsientoTipoCod.Text.ToString().Trim(), "AT")
            End If
            txtAsientoTipoCod.Text = tblconsulta.Item(tblconsulta.Row, "CO07ASIENTOTIPOCOD").ToString().Trim()
            txtNomenclatura.Text = tblconsulta.Item(tblconsulta.Row, "CO07NOMENCLATURA").ToString().Trim()

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
            If txtDescri.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Descripcion no valida", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtDescri.Focus() : Exit Sub

            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            Cursor.Current = Cursors.WaitCursor

            If accionMante = "N" Then
                a = objSql.Ejecutar2("Spu_Con_Ins_co07MotivosDocPorPagar", gbcodempresa, txtDescri.Text.ToString.ToString().Trim(), txtAsientoTipoCod.Text.ToString().Trim(), txtNomenclatura.Text.ToString.Trim(), MsgRetorno)
            ElseIf accionMante = "M" Then
                Dim ITEM = Convert.ToInt32(txtCodigo.Text.ToString())
                a = objSql.Ejecutar2("Spu_Con_Upd_co07MotivosDocPorPagar", gbcodempresa, txtDescri.Text.ToString.ToString().Trim(), ITEM, txtAsientoTipoCod.Text.ToString().Trim(), txtNomenclatura.Text.ToString().Trim(), MsgRetorno)
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.cargarDatos()
                Frm_Motivo_Compras_Load(Nothing, Nothing)
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
                'Case 0
                '    'CONCEPTO
                '    tblhelp_0.Columns(0).DataField = "CO07ITEM"
                '    tblhelp_0.Columns(1).DataField = "CO07DESCRIPCION"
                '    tblhelp_0.Columns(2).DataField = "CO07ASIENTOTIPOCOD"
                '    tblhelp_0.Columns(3).DataField = "ccc03des"
                '    tblhelp_0.Columns(4).DataField = "ccc03lib"
                '    tblhelp_0.Columns(5).DataField = "CO07NOMENCLATURA"
                '    Me.TraerConcepto_AsientoTipo(descripcion, tblhelp1_bloque)
                '    tblhelp_0.Visible = True

                'Case 1
                '    'CENTRO COSTO
                '    tblhelp_0.Columns(0).DataField = "ccb02cod"
                '    tblhelp_0.Columns(1).DataField = "ccb02des"
                '    Me.TraerCentroCosto(tblhelp1_bloque)

                '    tblhelp_0.Visible = True
                '    tblhelp_0.Focus()
                Case 2
                    'ASIENTO TIPO
                    tblhelp_0.Columns(0).DataField = "ccc03cod"
                    tblhelp_0.Columns(1).DataField = "ccc03des"
                    tblhelp_0.Columns(2).DataField = "ccc03lib"
                    Me.TraerAsientoTipo(tblhelp_0)
                    tblhelp_0.Visible = True
                    tblhelp_0.Focus()

            End Select

            tblhelp_0.Tag = index.ToString
            '  tblhelp1_bloque.Refresh()


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
                'Case 0
                '    'CONCEPTO
                '    tblconsulta(RowIndex, "Concepto") = tblhelp_p.Columns("CO07DESCRIPCION").Value.ToString
                '    tblconsulta(RowIndex, "Asiento_Tipo") = tblhelp_p.Columns("CO07ASIENTOTIPOCOD").Value.ToString
                '    tblconsulta(RowIndex, "Desc_asiento_tip") = tblhelp_p.Columns("ccc03des").Value.ToString
                '    tblconsulta(RowIndex, "Libro") = tblhelp_p.Columns("ccc03lib").Value.ToString
                '    tblconsulta(RowIndex, "Nro_Voucher") = tblhelp_p.Columns("CO07NOMENCLATURA").Value.ToString

                '    tblconsulta(RowIndex, "ccc01subd") = tblhelp_p.Columns("ccc03lib").Value.ToString ' Libro
                '    tblconsulta(RowIndex, "ccc01deta") = tblhelp_p.Columns("CO07DESCRIPCION").Value.ToString ' Concepto


                '    ' txtLibro.Focus()
                'Case 1
                '    'CENTRO COSTO
                '    tblconsulta(RowIndex, "Centro_Costo") = tblhelp_p.Columns("ccb02cod").Value.ToString
                '    ' tblconsulta(RowIndex, 27) = tblhelp_p.Columns("ccb02des").Value.ToString
                '    ' txtLibro.Focus()
                Case 2
                    'ASIENTO TIPO
                    txtAsientoTipoCod.Text = tblhelp_p.Columns("Codigo").Value.ToString()
                    lblhelp_0.Text = tblhelp_p.Columns("Descripcion").Value.ToString()

            End Select

            Vista.Dispose()
            tblhelp_0.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Try
            TraerAyuda(2, "", btnhelp_0)
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
        Try
            AsignarAyuda(2, tblhelp_0)
        Catch ex As Exception

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

    Private Sub Frm_Motivo_Ventas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If tblhelp_0.Visible = True Then
                If e.KeyCode = Keys.Escape Then
                    tblhelp_0.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAsientoTipoCod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAsientoTipoCod.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                TraerAyuda(2, "", btnhelp_0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Try
            Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla(tblconsulta)
            CopiarPorta()
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

                registrosSeleccionados(j) = tblconsulta.Item(filaSeleccionada, "co08ITEM").ToString() + " " + tblconsulta.Item(filaSeleccionada, "co08DESCRIPCION").ToString() + " " + tblconsulta.Item(filaSeleccionada, "co08ASIENTOTIPOCOD").ToString() + " " + tblconsulta.Item(filaSeleccionada, "ccc03des").ToString() + " " + tblconsulta.Item(filaSeleccionada, "co08NOMENCLATURA").ToString()
                j += 1

            Next
            Dim datos As String = String.Join(vbCrLf, registrosSeleccionados.Select(Function(x) String.Join(vbTab, x)))
            System.Windows.Forms.Clipboard.SetDataObject(datos, False)
        Catch ex As Exception

        End Try
    End Sub
End Class