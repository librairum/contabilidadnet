
Option Explicit On
Option Strict On
Public Class Frm_Buscador
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
    Private Sub TraeBusquedaDEt()
        'objSql = New ServDatos.AccesoDatos.DatosSQLServer(ConfigurationManager.ConnectionStrings("CadenaConexionPla").ConnectionString)
        'tbldetalle.DataSource = objSql.TraerDataTable("Spu_Con_Trae_ccdBusqueda", gbcodempresa, gbano, gbmes, "01", "M").DefaultView
    End Sub
    Private Sub TraeBusqueda(ByVal cadenabusqueda As String)
        Dim flag As String

        Try
            If txtcadenabusqueda.Text.Trim = "" Then MessageBox.Show(gbc_MensajeValidar + "Cadena de busqueda vacia", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

            flag = If(rbtopcion_0.Checked = True, "A", "M")

            Cursor.Current = Cursors.WaitCursor

            Vista = objSql.TraerDataTable("Spu_Con_Trae_ccdBusqueda", gbcodempresa, gbano, gbmes, cadenabusqueda, flag).DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region
    Private Sub Frm_Buscador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.EsquinaSuperiorIzquierda(Me)
            '
            Me.Text = "Buscador Contable"
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub
    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Try
            filaactual = Me.BindingContext(Vista).Position ' 
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click

        Me.TraeBusqueda(txtcadenabusqueda.Text.Trim)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TraeBusquedaDEt()
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class