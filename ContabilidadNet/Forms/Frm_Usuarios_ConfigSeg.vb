Option Explicit On
Option Strict On
Public Class Frm_Usuarios_ConfigSeg
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Private accionMante As String
    Dim Vista As DataView
    Dim FilaDeTabla As DataRowView
    Dim filaactual As Integer

#End Region
#Region "Traer Informacion de Base de Datos"

    Sub TraeUsuarios()
        Try
            Vista = objSql.TraerDataTable("sp_Glo_Trae_Usuarios", gbc_sistema, "Nombre ASC").DefaultView
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
    Private Sub AgregarPermiso(ByVal codigomenu As String)
        Dim usuarioaconfigurarar As String = ""
        Try
            '
            usuarioaconfigurarar = txtcodigo.Text.Trim
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("Spu_Glo_Ins_menuxusuario", gbcodempresa, gbc_sistema, codigomenu, usuarioaconfigurarar, "")
            '
            Funciones.Funciones.MensajesdelSQl(a)
            '
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub QuitarPermiso(ByVal codigomenu As String)
        Dim usuarioaconfigurarar As String = ""
        Try
            usuarioaconfigurarar = txtcodigo.Text.Trim
            '
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("Spu_Glo_Del_menuxusuario", gbcodempresa, gbc_sistema, codigomenu, usuarioaconfigurarar, "")
            '
            Funciones.Funciones.MensajesdelSQl(a)
            '
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Modulos"
    Private Sub cargarmenu(ByVal usuarioaconf As String)
        Dim dt As DataTable
        Dim filadetablas As DataRow
        Dim nivel1, nivel2, nivel3 As String
        Dim nodo_nivel1, nodo_nivel2, nodo_nivel3 As TreeNode
        Dim nombre, codigomenu, flagactivo As String
        'Configuro opcion para ver checkbox
        TreeViewseguridad.CheckBoxes = True

        'Limpio Treview
        TreeViewseguridad.Nodes.Clear()

        '
        Try

        
            dt = objSql.TraerDataTable("Spu_Glo_Trae_MenuxUsuarioConf", gbcodempresa, gbc_sistema, usuarioaconf)

            For Each filadetablas In dt.Rows

                nombre = ""
                codigomenu = ""
                flagactivo = ""
                nivel1 = ""
                nivel2 = ""
                nivel3 = ""

                nombre = filadetablas("texto").ToString()
                codigomenu = filadetablas("codigomenu").ToString()
                flagactivo = filadetablas("flag").ToString()

                nivel1 = codigomenu.Substring(0, 2)
                nivel2 = codigomenu.Substring(2, 2)
                nivel3 = codigomenu.Substring(4, 2)

                If (nombre = "_" Or nombre = "-") = False Then

                    If nivel1 <> "00" And nivel2 = "00" And nivel3 = "00" Then
                        nodo_nivel1 = New TreeNode


                        nodo_nivel1.Text = nombre
                        nodo_nivel1.Name = codigomenu

                        If flagactivo = "1" Then
                            nodo_nivel1.Checked = True
                        Else
                            nodo_nivel1.Checked = False
                        End If

                        crearNodos(Nothing, nodo_nivel1)
                    ElseIf nivel2 <> "00" And nivel3 = "00" Then
                        nodo_nivel2 = New TreeNode


                        nodo_nivel2.Text = nombre
                        nodo_nivel2.Name = codigomenu

                        If flagactivo = "1" Then
                            nodo_nivel2.Checked = True
                        Else
                            nodo_nivel2.Checked = False
                        End If

                        crearNodos(nodo_nivel1, nodo_nivel2)

                    ElseIf nivel3 <> "00" Then
                        nodo_nivel3 = New TreeNode


                        nodo_nivel3.Text = nombre
                        nodo_nivel3.Name = codigomenu

                        If flagactivo = "1" Then
                            nodo_nivel3.Checked = True
                        Else
                            nodo_nivel3.Checked = False
                        End If

                        crearNodos(nodo_nivel2, nodo_nivel3)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub crearNodos(ByVal Nodo_Padre As TreeNode, ByVal Nuevo_nodo As TreeNode)
        If Nodo_Padre Is Nothing Then
            TreeViewseguridad.Nodes.Add(Nuevo_nodo)
        Else
            Nodo_Padre.Nodes.Add(Nuevo_nodo)
        End If
    End Sub
    Sub cargarDatos(ByVal filaactiva As DataRowView)
        Try
            If filaactiva Is Nothing Then Exit Sub
            If Not filaactiva Is Nothing Then
                txtcodigo.Text = filaactiva("Nombre").ToString
                txtdescripcion.Text = filaactiva("Nombre").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR :: Al enlazar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub
#End Region
    Private Sub Frm_Usuarios_ConfigSeg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Usuarios"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Me.TraeUsuarios()
            '
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
   
    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Dim usuarioconf As String
        Try
            Me.capturarfilaactual()
            Me.cargarDatos(FilaDeTabla)

            usuarioconf = txtcodigo.Text.Trim
            Me.cargarmenu(usuarioconf)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub TreeViewseguridad_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewseguridad.AfterCheck
        Dim codigo As String
        codigo = e.Node.Name
        'Actualizo()
        If e.Node.Checked = True Then
            Me.AgregarPermiso(codigo)
        Else
            Me.QuitarPermiso(codigo)
        End If
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class