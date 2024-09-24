Option Strict On
Option Explicit On
Public Class Frm_Empresa


#Region "Declaraciones"
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#End Region

#Region "Propiedades"
    Public Property P_FilaDeTabla() As DataRowView
        Get
            Return FilaDeTabla
        End Get
        Set(ByVal value As DataRowView)
            FilaDeTabla = value
        End Set
    End Property
#End Region

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
#Region "Base de Datos"
    Private Sub TraeEmpresas()
        Try
            Vista = objSql.TraerDataTable("sp_Glo_Trae_Empresas", gbc_sistema, "Codigo ASC").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


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

    Private Sub Frm_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Me.Text = "Maestro de empresas"

            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btnver, gbc_Ttp_Ver)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            Mod_Mantenimiento.tooltiptext(btnCopiar, gbc_Ttp_Nuevoxcopia)
            '
            Me.TraeEmpresas()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        If Funciones.Funciones.FormIsOpen("Frm_Empresa_Abc") Then Exit Sub
        Dim _Frm_Empresa_Abc As New Frm_Empresa_Abc
        Try
            _Frm_Empresa_Abc.p_accionMante = "N"
            _Frm_Empresa_Abc.Owner = Me
            _Frm_Empresa_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        If Funciones.Funciones.FormIsOpen("Frm_Empresa_Abc") Then Exit Sub
        Dim _Frm_Empresa_Abc As New Frm_Empresa_Abc

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_Empresa_Abc.p_accionMante = "M"
            _Frm_Empresa_Abc.p_RegistroActivo = FilaDeTabla
            _Frm_Empresa_Abc.Owner = Me
            _Frm_Empresa_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnver.Click
        If Funciones.Funciones.FormIsOpen("Frm_Empresa_Abc") Then Exit Sub
        Dim _Frm_Empresa_Abc As New Frm_Empresa_Abc

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_Empresa_Abc.p_accionMante = "V"
            _Frm_Empresa_Abc.p_RegistroActivo = FilaDeTabla
            _Frm_Empresa_Abc.MdiParent = MDIPrincipal.ParentForm
            _Frm_Empresa_Abc.Owner = Me
            _Frm_Empresa_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblconsulta.DoubleClick
        Me.btnver_Click(Nothing, Nothing)
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
        Me.TraeEmpresas()
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
            Me.TraeEmpresas()
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
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Me.capturarfilaactual()
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        '
        Dim codigo As String
        Try

            codigo = FilaDeTabla("Codigo").ToString

            If MessageBox.Show("¿ Está seguro de Eliminar ?  : " & codigo, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub

            Cursor.Current = Cursors.WaitCursor

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            'a = objSql.Ejecutar2("sp_Glo_Del_Empresa", gbc_sistema, codigo, "") : Se implemneto un metodo que borra
            a = objSql.Ejecutar2("Spu_Sis_Del_Empresa", codigo, gbc_sistema, "")
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
            Else
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub tblconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnver_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
    Private Sub btnCopiar_Click(sender As System.Object, e As System.EventArgs) Handles btnCopiar.Click
        Dim codigo As String
        Dim nombreempresa As String
        Try

            codigo = FilaDeTabla("Codigo").ToString
            nombreempresa = FilaDeTabla("Nombre").ToString

            If MessageBox.Show("¿ Está seguro de Crear una Nueva Empresa basada en : " & nombreempresa, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub

            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)

            a = objSql.Ejecutar2("Spu_Con_Ins_EmpresaNuevaCopia", codigo, gbano, "")

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
            Else
                'No hago nada
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class