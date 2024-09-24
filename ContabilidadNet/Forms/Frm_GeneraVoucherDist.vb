Option Explicit On
Option Strict On
Public Class Frm_GeneraVoucherDist
#Region "Declaraciones"
    Dim Vista As New DataView
    Dim VistaHelp As DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
#End Region
#Region "Traer Informacion de Base de Datos"
    Sub TraeLibros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerCtaDistribuibles()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_cdicabeceraVoucher", gbcodempresa, gbano).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Mantenimiento"
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
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()
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
                    txtlibro.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtlibro.Focus()
            End Select

            VistaHelp.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtlibro.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtlibro.Text, "LI")
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub Frm_GeneraVoucherDist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Me.Text = "Generar voucher de distribucion"
            '
            Me.TraerCtaDistribuibles()
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            If Periodocerrado() = True Then
                btnGenVou.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
    Private Sub tblhelp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblhelp.LostFocus
        Try
            tblhelp.Visible = False
            VistaHelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tblhelp_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnGenVou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenVou.Click
        Try
            'Validar que exista cuentas en la grilla
            If tblconsulta.RowCount <= 0 Then Beep() : MessageBox.Show("VALIDACION :: No existen cuentas para distribuir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            'Valido libro
            If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Libro NO Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtlibro.Focus() : Exit Sub
            'Valido Mes y tIpo de cambio
            'Validar que la fecha 
            Dim periodo As String
            periodo = gbano + gbmes
            If Funciones.Funciones.EsValidaFechaPorPer(mskfecha.Text, periodo) = False Then mskfecha.Focus() : Exit Sub
            'Valido Tip de Cambio
            If Funciones.Funciones.Esnumeromayoracero(txtTipCambio.Text) = False Then txtTipCambio.Focus() : Exit Sub
            '
            Cursor.Current = Cursors.WaitCursor
            'Ejecutar la insercion o Actualizacion
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            a = objSql.Ejecutar2("Spu_Con_Gen_VoucherDistribucion", gbcodempresa, gbano, gbmes, txtlibro.Text, CType(txtTipCambio.Text, Double), mskfecha.Text, "")
            '
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub mskfecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskfecha.KeyDown
        If (e.KeyCode = 13 Or e.KeyCode = 40) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyCode = 38) Then
            SendKeys.Send("+{tab}")
        End If
    End Sub

    Private Sub mskfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskfecha.LostFocus
        txtTipCambio.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "C")
    End Sub
    Private Sub btnConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigurar.Click
        If Funciones.Funciones.FormIsOpen("Frm_Distribucion") Then Exit Sub
        Dim _Frm_Distribucion As New Frm_Distribucion

        Try
            _Frm_Distribucion.MdiParent = MDIPrincipal.ParentForm
            _Frm_Distribucion.Owner = Me
            _Frm_Distribucion.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mskfecha_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskfecha.MaskInputRejected

    End Sub

    Private Sub txtlibro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlibro.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnhelp_0_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtlibro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibro.LostFocus
        Me.TraeDameDescripcion(0)
    End Sub

    Private Sub txtlibro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlibro.TextChanged

    End Sub

    Private Sub tblhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.Click

    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class