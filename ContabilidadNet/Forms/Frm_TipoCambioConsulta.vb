Option Explicit On
Option Strict On

Public Class Frm_TipoCambioConsulta
#Region "DECLARACIONES"
    Dim RegistroActivo As DataRowView
    Dim Vista As DataView


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


#Region "Traer Informacion de Base de Datos"

    Sub TraeTipodeCambio()
        Try
            Vista = objSql.TraerDataTable("sp_Glo_Trae_Tipos_Cambio", "Fecha Desc").DefaultView
            tblconsulta.SetDataBinding(Vista, Nothing, True)
            '
            Me.tblconsulta.Columns(0).FooterText = "# Registros"
            Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Metodos de Mantenimiento"

    Public Sub refrescarGrilla()
        Me.TraeTipodeCambio()
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
            Me.TraeTipodeCambio()
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
#End Region
    
    Private Sub Frm_TipodeCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Consulta Tipo de cambio"
            '
            Mod_Mantenimiento.Formatodegrilla(tblconsulta)
            '
            Mod_Mantenimiento.tooltiptext(btnsalir, gbc_Ttp_Salir)

            Me.TraeTipodeCambio()
        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvistaprevia.Click
        Try
            Dim objR As New KS.Com.Win.CystalReports.Net.File
            Dim nombredereporte As String
            Dim ds As System.Data.DataSet
            Dim Rutareporte As String
            Dim flagtiporeporte As String = "RPTTIC"

            Dim flag As String = "0"


            If (tblconsulta.SelectedRows.Count <> tblconsulta.RowCount) Then

                If tblconsulta.SelectedRows.Count > 0 Then
                    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
                Else
                    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                End If
                flag = "0" 'filtro
            Else
                flag = "1" 'todo
            End If

            Rutareporte = gbRutaReportes()
            nombredereporte = "Rpt_TipoCambio.rpt"
            ' Me.tblconsulta.Columns(1).FooterText = tblconsulta.RowCount.ToString


            ds = objSql.TraerDataSet("Spu_Con_Rep_TipoCambio", gbcodempresa, gbNameUser, flagtiporeporte, flag).Copy()
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, Nothing, enmWindowState.Maximizado)

            'Elimnar rango de impresion
            Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte)

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnseleccionartodo_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseleccionartodo_0.Click
        Mod_Mantenimiento.seleccionartodaslasfilasdelagrilla_sinfiladefiltro(tblconsulta)
    End Sub
End Class