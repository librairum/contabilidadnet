Option Explicit On
Option Strict On

Public Class Frm_Voucher_Cierres
#Region "Declaraciones"
    Dim Vista As New DataView
    Dim Vistahelp As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim frmOrigen As Frm_Voucher_Abc
    Private _countries As New Hashtable()
    Private _cities As New Hashtable()
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
#Region "Base de datos"
    Sub TraeLibros()
        Try
            Vistahelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(Vistahelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region


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
            ' ===
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
    Private Sub Frm_Voucher_Cierres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            Me.Text = "Generar Voucher de Cierre"
            'Ocular generacion de voucher si el periodo esta cerrado
            If Periodocerrado() = True Then
                btnGenVou.Visible = False
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
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

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txtlibro.Text = tblhelp.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp.Columns("ccb02des").Value.ToString
                    txtlibro.Focus()
                Case 1
                    txtlibro.Text = tblhelp.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp.Columns("ccb02des").Value.ToString
                    txtlibro.Focus()
            End Select

            Vistahelp.Dispose()
            tblhelp.Visible = False
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
        Try
            tblhelp.Visible = False
            Vistahelp.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mskfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskfecha.LostFocus
        txtTipCambio_Aper_Act.Text = Mod_BaseDatos.DameTCFecha(mskfecha.Text, "B", "V")
    End Sub
    Private Sub btnGenVou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenVou.Click
        Dim moneda As String
        Dim anioaperurar As String

        '
        Try
            'Valido que exista Datos
            If lblhelp_0.Text = "" Or lblhelp_0.Text = "???" Then MessageBox.Show(gbc_MensajeValidar + "Libro no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            '
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            '=====
            If rbtopcion_0.Checked = True Then
                If Funciones.Funciones.Esnumeromayoracero(txtTipCambio_gastos.Text) = False Then Exit Sub
                a = objSql.Ejecutar2("Sp_Con_Gen_Vouch_Cierre_Cta_GastosNew", gbcodempresa, gbano, gbmes, gbmoneda, txtlibro.Text, mskfecha.Text, txtDescripcion.Text, CDbl(txtTipCambio_gastos.Text), "")
            ElseIf rbtopcion_1.Checked = True Then
                a = objSql.Ejecutar2("sp_Con_Gen_Vouch_Cierre_Cta_Inventario", gbcodempresa, gbano, gbmes, txtlibro.Text, mskfecha.Text, txtDescripcion.Text.Trim(), "")
            ElseIf rbtopcion_2.Checked = True Then
                If Funciones.Funciones.Esnumeromayoracero(txtTipCambio_Aper_Act.Text) = False Then Exit Sub
                If Funciones.Funciones.Esnumeromayoracero(txtTipCambio_Aper_Act.Text) = False Then Exit Sub
                anioaperurar = CStr(CInt(gbano) + 1)
                a = objSql.Ejecutar2("Sp_Con_Gen_Vouch_Apertura", gbcodempresa, anioaperurar, "00", txtlibro.Text, mskfecha.Text, txtDescripcion.Text, CDbl(txtTipCambio_Aper_Act.Text), CDbl(txtTipCambio_Aper_Pas.Text), "")
            End If

            Funciones.Funciones.MensajesdelSQl(a)
            '
            Cursor.Current = Cursors.Default
            '
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class