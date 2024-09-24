Option Explicit On
Option Strict On

Public Class Frm_Usuarios_CambioPassword
#Region "DECLARACIONES"
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
#End Region
#Region "Traer Informacion de Base de Datos"
#End Region
#Region "Metodos de Mantenimiento"

#End Region
    

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub


    Private Sub Frm_Usuarios_CambioPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            Me.Text = "Cambios de password de usuarios"
            '
            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            '
            txtusuario.Text = gbNameUser
            txtnombreusario.Text = gbNameUser
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
   
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim clave As String = ""
        Dim nuevaclave As String = ""
        Try
            'Valido usuario y clave
            If txtPassword_0.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Debe Ingresar Password Anterior", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPassword_0.Focus() : Exit Sub
            If txtPassword_1.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Debe Ingresar Nuevo Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPassword_1.Focus() : Exit Sub
            If txtPassword_2.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Debe Confirmar Nuevo Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPassword_2.Focus() : Exit Sub

            'Validar que las 2 nuevas caves sean iguales
            If (txtPassword_1.Text.Trim <> txtPassword_2.Text.Trim) = True Then MessageBox.Show(gbc_MensajeValidar + "Confirmación de Password debe ser igual al Nuevo Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPassword_2.Focus() : Exit Sub

            '' Obtengo los Datos del Usuario
            Dim tabla As DataTable

            tabla = objSql.TraerDataSet("sp_Glo_Trae_Datos_Usuario", gbc_sistema, gbNameUser).Tables(0)

            For Each fila As DataRow In tabla.Rows
                clave = Funciones.Funciones.Desencripta(fila("Clave").ToString)
                'Si la clave antigua es la correcta
                If clave.Trim <> txtPassword_0.Text.Trim Then MessageBox.Show(gbc_MensajeValidar + "Password anterior incorrecto", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtPassword_0.Focus() : Exit Sub

                'captuar la nueva clave
                nuevaclave = txtPassword_1.Text.Trim
                'encripta la nueva clave
                nuevaclave = Funciones.Funciones.Encripta(nuevaclave)
                'Actualiza la nuva clave
                Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
                a = objSql.Ejecutar2("sp_Glo_Upd_Password_Usuario", gbc_sistema, gbNameUser, nuevaclave, "")
                If Funciones.Funciones.MensajesdelSQl(a) = True Then
                    'Si todo Ok descarga el formualrio
                    Me.Close()
                End If
            Next

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class