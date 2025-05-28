Option Strict On
Option Explicit On
Public Class Frm_Empresa_Seleccionar

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
            '
            Me.capturarfilaactual()
            '
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
            Me.Text = "Seleccionar empresa"

            Me.TraeEmpresas()
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            ''
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub tblconsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblconsulta.DoubleClick
        Me.btnver_Click(Nothing, Nothing)
    End Sub
    Public Sub refrescarGrilla()
        Me.TraeEmpresas()
    End Sub
    Private Sub tblconsulta_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tblconsulta.AfterFilter
        Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
    End Sub

    Private Sub tblconsulta_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tblconsulta.RowColChange
        Me.capturarfilaactual()
    End Sub

    Private Sub tblconsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnver_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnver.Click
        Try
            'VAlidar que la grilla ternga datos
            If tblconsulta.RowCount < 1 Then Exit Sub
            ' Capturo los Valores de la Empresa
            gbcodempresa = FilaDeTabla("Codigo").ToString
            gbNomEmpresa = FilaDeTabla("Nombre").ToString.ToUpper
            gbDirEmpresa = FilaDeTabla("Direccion").ToString
            gbRepEmpresa = FilaDeTabla("Representante").ToString
            gbCarEmpresa = FilaDeTabla("Cargo").ToString
            gbConEmpresa = FilaDeTabla("Contador").ToString
            gbMatEmpresa = FilaDeTabla("Matricula").ToString
            gbRucEmpresa = FilaDeTabla("Ruc").ToString

            ' Capturo Valores para la Diferencia de Cambio
            gbCuentaPerDifCam = FilaDeTabla("CuentaPerdida").ToString
            gbCenCosPerDifCam = FilaDeTabla("CenCosPerdida").ToString
            gbCenGesPerDifCam = FilaDeTabla("CenGesPerdida").ToString
            gbCuentaGanDifCam = FilaDeTabla("CuentaGanancia").ToString
            gbCenCosGanDifCam = FilaDeTabla("CenCosGanancia").ToString
            gbCenGesGanDifCam = FilaDeTabla("CenGesGanancia").ToString

            ' Otros
            gbModifTC = FilaDeTabla("ModifTC").ToString()
            gbTCUsar = FilaDeTabla("TCUsar").ToString()
            gbFecProvision = FilaDeTabla("FecProvision").ToString()
            gbEmpresaPlanilla = "000001"

            'Bueno la 
            gbAgenteRetencion = FilaDeTabla("FlagRetencion").ToString() 'aTexto(dcEmpresas.Resultset("FlagRetencion"))
            gbMontoRetencion = CType(FilaDeTabla("ImpRetencion").ToString, Double)
            gbTasaRetencion = CType(FilaDeTabla("TasaRetencion").ToString, Double)

            '

            'Nota: el año se toma de usuario , en caso el usuaro no tenga año se le asigna el de la empresa
            If (gbano = "") Then
                gbano = FilaDeTabla("Ejercicio").ToString()
            End If
            MDIPrincipal.ToolTip1.SetToolTip(btnver, "Modifcar")

            MDIPrincipal.Text = gbNomEmpresa


            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click

    End Sub
End Class