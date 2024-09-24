Option Explicit On
Option Strict On
Option Compare Binary

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Namespace Ks.Com.Win.CystalReports.Net.Forms
    Public Class FormVisor
        Private mstrRuta As String
        Private mobjDataSource As Object
        Private marrParametersFields As List(Of ParametrosReportes)
        Private marrFormulas As List(Of FormulasReportes)

#Region "PROPIEDADES PUBLICAS"
        Public Property Ruta() As String
            Get
                Return mstrRuta
            End Get
            Set(ByVal value As String)
                mstrRuta = value
            End Set
        End Property

        Public Property DataSource() As Object
            Get
                Return mobjDataSource
            End Get
            Set(ByVal value As Object)
                mobjDataSource = value
            End Set
        End Property

        Public Property ParametersFields() As List(Of ParametrosReportes)
            Get
                Return marrParametersFields
            End Get
            Set(ByVal value As List(Of ParametrosReportes))
                marrParametersFields = value
            End Set
        End Property

        Public Property FormulasFields() As List(Of FormulasReportes)
            Get
                Return marrFormulas
            End Get
            Set(ByVal value As List(Of FormulasReportes))
                marrFormulas = value
            End Set
        End Property
#End Region

#Region "EVENTOS DE PANTALLA"
        Private Sub FormVisor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            pValorInicial()
        End Sub
#End Region

#Region "METODOS"

        ''' <summary>
        ''' Metodo que visualiza reporte
        ''' </summary>
        ''' <creadopor>William Rodriguez C.</creadopor>
        ''' <fechacreacion>27/03/2009</fechacreacion>
        ''' <empresa>Minera  Colquisir S.A</empresa>
        ''' <remarks></remarks>
        Private Sub pValorInicial()
            '****************************************************
            'Enlazo el reporte
            '****************************************************
            Me.crv.Dock = DockStyle.Fill
            Me.crv.ShowRefreshButton = False

            Dim rep As ReportDocument
            rep = New ReportDocument

            '*********************************************************************************************
            'Abro el reporte
            rep.Load(mstrRuta)
            rep.SetDataSource(mobjDataSource)

            '*********************************************************************************************
            'Capturo los parametros del reporte
            '*********************************************************************************************
            Dim objParameterFields As ParameterFields = rep.ParameterFields
            If marrParametersFields IsNot Nothing Then
                SetCurrentValuesForParameterField(rep, objParameterFields, marrParametersFields)
            End If

            '*********************************************************************************************
            'Capturo las Formulas y asigno los valores
            '*********************************************************************************************
            If marrFormulas IsNot Nothing Then
                SetCurrentValuesForFormulaField(rep, marrFormulas)
            End If

            'Dim Formulas As CrystalDecisions.CrystalReports.Engine.FormulaFieldDefinitions
            'Formulas = rep.DataDefinition.FormulaFields
            'rep.DataDefinition.FormulaFields("FCH_LIM").Text = "'PRUEBA'"
            '
            Me.crv.ReportSource = rep
        End Sub

        ''' <summary>
        ''' Metodo que asigna valor de formulas
        ''' </summary>
        ''' <param name="rep">Objeto ReportDocument</param>
        ''' <param name="myArrayList">Coleccione de Formula</param>
        ''' <creadopor>Edgar Huarcaya C.</creadopor>
        ''' <fechacreacion>27/03/2009</fechacreacion>
        ''' <empresa>Key Solutions S.R.L</empresa>
        ''' <remarks></remarks>
        Private Sub SetCurrentValuesForFormulaField(ByVal rep As ReportDocument, ByVal myArrayList As List(Of FormulasReportes))
            If myArrayList Is Nothing Then Exit Sub

            'En este bucle recorremos la lista de parametros del reporte y le asignamos valores
            For Each submittedValue As FormulasReportes In myArrayList
                'Asigno Parametros al Reporte
                rep.DataDefinition.FormulaFields(submittedValue.Nombre).Text = "'" & submittedValue.Valor.ToString & "'"
            Next
        End Sub

        ''' <summary>
        ''' Metodo que asigna valor de parametros
        ''' </summary>
        ''' <param name="rep">Objeto ReportDocument</param>
        ''' <param name="myParameterFields"></param>
        ''' <param name="myArrayList">Coleccione de Formula</param>
        ''' <creadopor>William Rodriguez  C.</creadopor>
        ''' <fechacreacion>27/03/2009</fechacreacion>
        ''' <empresa>Key Solutions S.R.L</empresa>
        ''' <remarks></remarks>
        Private Sub SetCurrentValuesForParameterField(ByVal rep As ReportDocument, ByVal myParameterFields As ParameterFields, ByVal myArrayList As List(Of ParametrosReportes))
            If myArrayList Is Nothing Then Exit Sub
            Dim currentParameterValues As ParameterValues = New ParameterValues()

            'En este bucle recorremos la lista de parametros del reporte y le asignamos valores
            For Each submittedValue As ParametrosReportes In myArrayList
                Dim myParameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
                myParameterDiscreteValue.Value = submittedValue.Valor
                currentParameterValues.Add(myParameterDiscreteValue)
                Dim myParameterField As ParameterField = myParameterFields(submittedValue.Nombre)
                myParameterField.CurrentValues = currentParameterValues

                'Asigno Parametros al Reporte
                rep.ParameterFields(submittedValue.Nombre).CurrentValues.Add(myParameterDiscreteValue)
            Next
        End Sub
#End Region

        Private Sub crv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crv.Load

        End Sub
    End Class
End Namespace
