Option Strict On
Option Explicit On
Public Class Frm_Login
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Sub asignarvariablesxusuario(ByVal fila As DataRow)
        Try
            gbNameUser = fila("Nombre").ToString
            'Capturo los Valores de la Contabilidad
            gbmoneda = fila("Moneda").ToString
            gbSaldos = fila("Saldos").ToString
            gbAjuste = fila("Ajuste").ToString
            gbperiodo = fila("Periodo").ToString
            '
            gbTipoImpresora = fila("TipoImp").ToString
            gbTiporeporte = fila("TipoImp").ToString 'Ya no se utiliza en la proxima depuracion sacarlo
            gbAccPerCerr = fila("AccPerCerr").ToString

            '
            gbano = Mid(gbperiodo$, 3, 4)

            If Not IsNumeric(gbano) Then
                gbano = CType(Date.Now.Year, String)
            End If

            If CInt(gbano) < 1000 Or CInt(gbano) > 9999 Then
                gbano = CType(Date.Now.Year, String)
            End If

            gbmes = Funciones.Funciones.derecha(gbperiodo, 2)

            If Not IsNumeric(gbmes) Then
                gbmes = CType(Date.Now.Month, String)
            End If

            If CInt(gbmes$) < 0 Or CInt(gbmes$) > 18 Then
                gbmes = CType(Date.Now.Month, String)
            End If
            'Por si el fomato del mes =1
            If gbmes.Length <> 2 Then
                gbmes = "0" + gbmes
            End If
            '

            gbperiodo = gbano + gbmes
            ''
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If Me.txtUsuario.Text.Trim.Trim.Length = 0 Then
                MessageBox.Show("Ingrese usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtUsuario.Focus()
                Exit Sub
            End If

            If Me.txtPassword.Text.Trim.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Password", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPassword.Focus()
                Exit Sub
            End If

            Dim strUserId As String = Me.txtUsuario.Text.Trim
            Dim strPassword As String = Me.txtPassword.Text.Trim
            'Trae detalle de asiento tipo
            Dim tabladet As DataTable
            tabladet = objSql.TraerDataTable("sp_Glo_Trae_Datos_Usuario", gbc_sistema, strUserId)
            'Recorrro la tabla traido y le actualizo los valores calculados segun las formulas
            Dim pasword As String
            If tabladet.Rows.Count > 0 Then
                For Each fila As DataRow In tabladet.Rows

                    pasword = fila("Clave").ToString
                    If Funciones.Funciones.Desencripta(pasword) = strPassword Then
                        Me.asignarvariablesxusuario(fila)
                        DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        MessageBox.Show(gbc_MensajeError + " Password erroneo", "Auntencticaion de usuario", MessageBoxButtons.OK)
                        txtPassword.Focus()
                    End If
                Next
            Else
                MessageBox.Show(gbc_MensajeError + " Usuario erroneo", "Auntencticaion de usuario", MessageBoxButtons.OK)
                txtUsuario.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Frm_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Auntenticacion"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class