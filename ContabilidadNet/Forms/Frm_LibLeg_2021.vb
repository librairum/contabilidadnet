﻿
Option Explicit On
Option Strict On
Public Class Frm_LibLeg_2021
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim Vista As DataView
    Dim vistahelp As DataView
    'Dim Vistahelp As DataView
    Dim FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim tipoctacte As String
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
    Sub TraeTablasGloables2(ByVal tabla As String)
        Try
            tblhelp.SetDataBinding(Mod_BaseDatos.TraeGlo01tablas2(tabla), Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub Traeimportacion()
        Try
            vistahelp = objSql.TraerDataTable("Spu_Con_Trae_PerAntlc2021MercayProdTer", gbcodempresa).DefaultView
            tblhelp.SetDataBinding(vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeEstructura()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_lc2021MercayProdTer", gbcodempresa, gbano, gbmes).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '
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
        txtProducto.Focus()
    End Sub
    Sub Insertar()
        Me.accionMante = "I"
        Me.HabilitarMantenimiento(True)
        LimpiarControles(Me)
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
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
            btninsertar.Visible = Not valor
            btnmodificar.Visible = Not valor
            btneliminar.Visible = Not valor
            btnimportar.Visible = Not valor
            btnsalir.Visible = Not valor

            tblconsulta.Enabled = Not valor
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LimpiarControlesf()
        Mod_Mantenimiento.LimpiarControles(Me)
    End Sub
    Public Sub refrescarGrilla()
        Me.TraeEstructura()
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
            Me.TraeEstructura()
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
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtProducto.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion("20" + txtProducto.Text, "GLO02")
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerAyuda(ByVal index As Integer, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp.Location = New Point(x, y)

            Mod_Mantenimiento.LimpiarFiltro(tblhelp)

            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"

            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "glo02Codigo"
                    tblhelp.Columns(1).DataField = "glo02descripcion"
                    Me.TraeTablasGloables2("20")
                Case 1 'Importar
                    tblhelp.Columns(0).DataField = "lc2021Anio"
                    tblhelp.Columns(1).DataField = "lc2021Mes"
                    Me.Traeimportacion()
            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txtProducto.Text = tblhelp.Columns("glo02Codigo").Value.ToString
                    lblhelp_0.Text = tblhelp.Columns("glo02descripcion").Value.ToString
                    txtProducto.Focus()
                Case 1
                    Dim anioanterior As String
                    Dim mesanterior As String

                    anioanterior = tblhelp.Columns("lc2021Anio").Value.ToString
                    mesanterior = tblhelp.Columns("lc2021Mes").Value.ToString


                    If MessageBox.Show("¿Esta Seguro de importar datos del año : " & anioanterior + " / " + mesanterior, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
                        Cursor.Current = Cursors.WaitCursor

                        a = objSql.Ejecutar2("Spu_Con_Ins_PerAntlc2021MercayProdTer", gbcodempresa, gbano, gbmes, anioanterior, mesanterior, "")
                        Funciones.Funciones.MensajesdelSQl(a)
                        Me.refrescarGrilla()
                        Cursor.Current = Cursors.Default
                    End If
            End Select

            'VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtProducto.Text = filaactiva("lc2021CodPro").ToString
                Me.TraeDameDescripcion(0)
                txtCantidad.Text = filaactiva("lc2021Cantidad").ToString
                txtcostouni.Text = filaactiva("lc2021CostoUnit").ToString
                txtcostototal.Text = filaactiva("lc2021CostoTot").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


#End Region
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.Nuevo()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.cargarDatos(FilaDeTabla)
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

    Private Sub tblhelp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp.Tag, Integer)
        Try
            If tblhelp.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        tblhelp.Tag = ""
        tblhelp.Visible = False
    End Sub

    Private Sub Frm_LibLeg_2021_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Me.Text = ""
            Me.Text = Frm_LibrosLegales.rbtrepauxiliares_7.Text

            Mod_Mantenimiento.Formatodegrilla(tblconsulta)

            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            'Me.Text = "Registrar documentos de venta por donaciones"
            '
            Mod_Mantenimiento.tooltiptext(btnnuevo, gbc_Ttp_Nuevo)
            Mod_Mantenimiento.tooltiptext(btninsertar, gbc_Ttp_Insertar)
            Mod_Mantenimiento.tooltiptext(btnmodificar, gbc_Ttp_Modificar)
            Mod_Mantenimiento.tooltiptext(btneliminar, gbc_Ttp_Eliminar)
            Mod_Mantenimiento.tooltiptext(btnimportar, "Importar configuracion de otro periodo")

            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Me.TraeEstructura()
            HabilitarMantenimiento(False)
            '
            Me.cargarDatos(RegistroActivo)
            '
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub eliminar()
        Dim identificador As String
        Dim identificadorAnt As String
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

            identificadorAnt = FilaDeTablaAnterior("lc2021CodPro").ToString
            identificador = FilaDeTabla("lc2021CodPro").ToString
            '
            Beep()
            If MessageBox.Show("AVISO :: Esta seguro de Eliminar el REGISTRO : " & txtProducto.Text, "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.accionMante = "E"
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Del_lc2021MercayProdTer", gbcodempresa, gbano, gbmes, txtProducto.Text, "")

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("lc2021CodPro", identificadorAnt, tblconsulta, Vista)
            Else
                'No hago nada
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor

            If String.IsNullOrEmpty(txtCantidad.Text) Then
                txtCantidad.Text = "0.00"
            End If
            If String.IsNullOrEmpty(txtcostouni.Text) Then
                txtcostouni.Text = "0.00"
            End If
            If String.IsNullOrEmpty(txtcostototal.Text) Then
                txtcostototal.Text = "0.00"
            End If

            If accionMante = "N" Then
                a = objSql.Ejecutar2("Spu_Con_Ins_lc2021MercayProdTer", gbcodempresa, gbano, gbmes, txtProducto.Text, CType(txtCantidad.Text, Double), CType(txtcostouni.Text, Double), CType(txtcostototal.Text, Double), "")

            ElseIf accionMante = "M" Then
                a = objSql.Ejecutar2("Spu_Con_Upd_lc2021MercayProdTer", gbcodempresa, gbano, gbmes, txtProducto.Text, CType(txtCantidad.Text, Double), CType(txtcostouni.Text, Double), CType(txtcostototal.Text, Double), "")
                ' Asigno los Valores a los Parametros del Query
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                Me.refrescarGrilla()
                Me.Posicionar("lc2021CodPro", txtProducto.Text, tblconsulta, Vista)
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

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub
    Private Sub btninsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsertar.Click
        Me.Insertar()
    End Sub

    Private Sub btnimportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimportar.Click
        Me.TraerAyuda(1, btnimportar)
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class