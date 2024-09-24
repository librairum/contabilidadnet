Option Explicit On
Option Strict On

Public Class Frm_CtaCte
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

#Region "Traer Informacion de Base de Datos"
    Private Sub TraerCtaCte(ByVal tipoanlisis As String)
        Try
            Vista = objSql.TraerDataTable("sp_Con_Trae_Cuentas_Corrientes_New", gbcodempresa, tipoanlisis, "ccm02cod", "*", "*").DefaultView
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
    Private Sub TraerTipoAnalis(ByVal cbo As ComboBox)
        Try
            cbo.DataSource = objSql.TraerDataTable("sp_Con_Trae_Tipos_Analisis", gbcodempresa, "ccb17cdgo ASC").DefaultView
            cbo.DisplayMember = "ccb17desc"
            cbo.ValueMember = "ccb17cdgo"
            'Poner el valor de combo en el mes 
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
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub Frm_CtaCte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Iniciar filtro
        Try

            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            Me.Text = "Cuentas corrientes"
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btnver, gbc_Ttp_Ver)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)
            '

            Me.TraerTipoAnalis(cboTipoAnalisi)
            cboTipoAnalisi.SelectedIndex = 0

            Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)

        Catch ex As Exception
            MessageBox.Show("ERROR ::" & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''
    End Sub
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Try
            Dim _Frm_Abc_CtaCte As New Frm_CtaCte_Abc()
            _Frm_Abc_CtaCte.p_accionMante = "N"
            _Frm_Abc_CtaCte.Owner = Me
            _Frm_Abc_CtaCte.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Dim FilaDeTabla As DataRowView
        Dim filaactual As Integer
        Dim _Frm_Abc_CtaCte As New Frm_CtaCte_Abc()

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_Abc_CtaCte.p_accionMante = "M"
            _Frm_Abc_CtaCte.p_RegistroActivo = FilaDeTabla
            _Frm_Abc_CtaCte.Owner = Me
            _Frm_Abc_CtaCte.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnver.Click

        Dim _Frm_Abc_CtaCte As New Frm_CtaCte_Abc()

        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            '
            filaactual = Me.BindingContext(Vista).Position ' El position no funciona, solo devuelve la fila a del gridview
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
            '
            _Frm_Abc_CtaCte.p_accionMante = "V"
            _Frm_Abc_CtaCte.p_RegistroActivo = FilaDeTabla
            '_Frm_Abc_CtaCte.MdiParent = Me.MdiParent
            _Frm_Abc_CtaCte.Owner = Me
            _Frm_Abc_CtaCte.Show()
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
        Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)
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
            Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)
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
        Dim TipoAnalisis As String

        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
        Try

            codigo = FilaDeTabla("ccm02cod").ToString
            TipoAnalisis = FilaDeTabla("ccm02tipana").ToString

            If MessageBox.Show("¿ Está seguro de Eliminar ? : " & codigo, "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then Exit Sub
            a = objSql.Ejecutar2("sp_Con_Del_Cuenta_Corriente", gbcodempresa, TipoAnalisis, codigo, "")

            'Armar Identificador de Fila
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
            Else
                'No hago nada
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnver_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub


    Private Sub cboTipoAnalisi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAnalisi.SelectedIndexChanged
        Me.TraerCtaCte(cboTipoAnalisi.SelectedValue.ToString)
    End Sub
End Class