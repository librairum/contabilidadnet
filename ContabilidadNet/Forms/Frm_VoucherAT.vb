Option Explicit On
Option Strict On
Public Class Frm_VoucherAT

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
    Private Sub TraerVoucher()
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Vouchers", gbcodempresa, gbano, gbmes, "AST", "Ccc01subd,ccc01numer ASC", "*", "*").DefaultView
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
    Private Sub Frm_VoucherAT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Vouchers tipo"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btnver, gbc_Ttp_Ver)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Me.TraerVoucher()
            Mod_Mantenimiento.ocultarbotonespercerrado(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Try

            Dim _Frm_VoucherAT_Abc As New Frm_VoucherAT_abc
            _Frm_VoucherAT_Abc.p_accionMante = "N"
            _Frm_VoucherAT_Abc.Owner = Me
            _Frm_VoucherAT_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Dim _Frm_VoucherAT_Abc As New Frm_VoucherAT_abc

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            'captura la fila actual 
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_VoucherAT_Abc.p_accionMante = "M"
            _Frm_VoucherAT_Abc.p_RegistroActivo = FilaDeTabla
            _Frm_VoucherAT_Abc.Owner = Me
            _Frm_VoucherAT_Abc.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnver.Click
        If Funciones.Funciones.FormIsOpen("Frm_VoucherAT_abc") Then Exit Sub
        Dim _Frm_VoucherAT_Abc As New Frm_VoucherAT_abc

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_VoucherAT_Abc.p_accionMante = "V"
            _Frm_VoucherAT_Abc.p_RegistroActivo = FilaDeTabla
            _Frm_VoucherAT_Abc.MdiParent = MDIPrincipal.ParentForm
            _Frm_VoucherAT_Abc.Owner = Me
            _Frm_VoucherAT_Abc.Show()
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
        Me.TraerVoucher()
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
            Me.TraerVoucher()
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
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click



        Dim libro As String
        Dim numero As String
        Dim opcionproceso As String
        opcionproceso = "ELIVOUMAS"

        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
        Try
            If tblconsulta.SelectedRows.Count > 1 Then
                If MessageBox.Show("¿ Está seguro de Eliminar Voucher masivo?  : ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub

                ' Eliminacion x seleccion
                If MessageBox.Show("¿ Confirme para Eliminar Vouchers masivo ?  : ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub

                ' Eliminacion en bloque

                Mod_Mantenimiento.InsertarFilasSelecionadas2(opcionproceso, tblconsulta, tblconsulta.Columns(1).DataField, tblconsulta.Columns(2).DataField)


                a = objSql.Ejecutar2("Spu_Con_Del_VouchersMasivo", gbcodempresa, gbano, gbmes, gbNameUser, opcionproceso, "")

                'Elimnar rango de impresion
                Mod_BaseDatos.EliminaRangoImpresion(opcionproceso)


            
            Else
                capturarfilaactual()
                libro = FilaDeTabla("ccc01subd").ToString
                numero = FilaDeTabla("ccc01numer").ToString
                If MessageBox.Show("¿ Está seguro de Eliminar  ?  : " & libro & " " & numero, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
                If MessageBox.Show("¿ Confirme para Eliminar  Voucher ?  : " & libro & " " & numero, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
                a = objSql.Ejecutar2("sp_Con_Del_Voucher", gbcodempresa, gbano, gbmes, libro, numero, "")

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
            End If
            Me.TraerVoucher()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnver_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblconsulta_PaddingChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblconsulta.PaddingChanged

    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub

    'Private Sub tblconsulta_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tblconsulta.Paint

    'End Sub
End Class