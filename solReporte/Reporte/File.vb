Option Explicit On
Option Strict On
Option Compare Binary

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Enum enmWindowState
    Normal = 0
    Maximizado = 1
    Minimizado = 2
End Enum

Namespace Ks.Com.Win.CystalReports.Net
    Public Class File
        ''' <summary>
        ''' Metodo que devuelve Indicador de tipo de orden de inversion
        ''' </summary>
        ''' <param name="vstrRuta">Ruta donde se encuentra el reporte</param>
        ''' <param name="vstrNombreReporte">Nombre de reporte</param>
        ''' <param name="vdtData">Data table que contiene informacion</param>
        ''' <param name="varrParamertersFields">Coleccion de parametros de reporte</param>
        ''' <param name="varrFormulasFields">Coleccion de formulas de reporte</param>
        ''' <param name="vintWindowState">Indica el estado de ventana</param>
        ''' <creadopor>Edgar Huarcaya C.</creadopor>
        ''' <fechacreacion>27/03/2009</fechacreacion>
        ''' <empresa>Key Solutions S.R.L</empresa>
        ''' <remarks></remarks>
        '''  
        Public Sub VistaPrevia(ByVal vstrRuta As String, ByVal vstrNombreReporte As String, _
                              ByVal vdtData As DataTable, ByVal varrParamertersFields As List(Of ParametrosReportes), _
                              ByVal varrFormulasFields As List(Of FormulasReportes), _
                              ByVal vintWindowState As enmWindowState)
            Dim objVisor As New Ks.Com.Win.CystalReports.Net.Forms.FormVisor
            Dim strRuta As String
            Try


                strRuta = vstrRuta & "\" & vstrNombreReporte
                If System.IO.File.Exists(strRuta) = False Then
                    Throw New Exception("No existe reporte en ruta indicada")
                End If

                With objVisor
                    .Ruta = strRuta
                    .DataSource = vdtData
                    .ParametersFields = varrParamertersFields
                    .FormulasFields = varrFormulasFields
                End With

                Select Case vintWindowState
                    Case enmWindowState.Normal
                        objVisor.WindowState = FormWindowState.Normal

                    Case enmWindowState.Maximizado
                        objVisor.WindowState = FormWindowState.Maximized

                    Case enmWindowState.Minimizado
                        objVisor.WindowState = FormWindowState.Minimized

                End Select

                objVisor.Show()

            Catch ex As Exception
                Throw
            Finally
                objVisor = Nothing
            End Try
        End Sub

        Private Function AddDiscreteValue(ByVal paramValue As String, _
                                         ByVal paramValues As ParameterValues) As ParameterValues

            Dim paramDiscreteValue As New ParameterDiscreteValue()
            ' Establecer el valor discreto en el parámetro.
            paramDiscreteValue.Value = paramValue

            paramValues.Add(paramDiscreteValue)

            AddDiscreteValue = paramValues
        End Function

        Public Sub VistaPrevia(ByVal vstrRuta As String, ByVal vstrNombreReporte As String, _
                              ByVal vdsDatos As DataSet, ByVal varrParamertersFields As List(Of ParametrosReportes), _
                              ByVal varrFormulasFields As List(Of FormulasReportes), _
                              ByVal vintWindowState As enmWindowState)
            Dim objVisor As New Ks.Com.Win.CystalReports.Net.Forms.FormVisor
            Dim strRuta As String
            Try


                strRuta = vstrRuta & "\" & vstrNombreReporte
                If System.IO.File.Exists(strRuta) = False Then
                    Throw New Exception("No existe reporte en ruta indicada")
                End If

                With objVisor
                    .Ruta = strRuta
                    .DataSource = vdsDatos
                    .ParametersFields = varrParamertersFields
                    .FormulasFields = varrFormulasFields
                End With

                Select Case vintWindowState
                    Case enmWindowState.Normal
                        objVisor.WindowState = FormWindowState.Normal

                    Case enmWindowState.Maximizado
                        objVisor.WindowState = FormWindowState.Maximized

                    Case enmWindowState.Minimizado
                        objVisor.WindowState = FormWindowState.Minimized

                End Select

                objVisor.Show()

            Catch ex As Exception
                Throw
            Finally
                objVisor = Nothing
            End Try
        End Sub

    End Class
End Namespace