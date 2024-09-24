
Option Strict On
Option Explicit On
Public Class Frm_Produccion_Datos
#Region "DECLARACIONES"
    Dim tablaDet As DataTable
    Dim accionMante As String

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
    Public Property p_accionMante() As String
        Get
            Return accionMante
        End Get
        Set(ByVal value As String)
            accionMante = value
        End Set
    End Property
    
#End Region
#Region "Traer Informacion de Base de Datos"
    Sub Cargardatos()
        'Trae detalle de asiento tipo

        tablaDet = objSql.TraerDataTable("Sp_Con_Trae_cc21produccion", gbcodempresa, gbano, "000")

        'Recorrro la tabla traido y le actualizo los valores calculados segun las formulas
        For Each fila As DataRow In tablaDet.Rows
            txtFactor_1.Text = fila("cc21Pro_01").ToString
            txtTipcambio_1.Text = fila("cc21pro_TipCam_Mes_01").ToString
            txtTipcambioAcum_1.Text = fila("cc21pro_TipCam_Acum_01").ToString
            '
            txtFactor_2.Text = fila("cc21Pro_02").ToString
            txtTipcambio_2.Text = fila("cc21pro_TipCam_Mes_02").ToString
            txtTipcambioAcum_2.Text = fila("cc21pro_TipCam_Acum_02").ToString
            '
            txtFactor_3.Text = fila("cc21Pro_03").ToString
            txtTipcambio_3.Text = fila("cc21pro_TipCam_Mes_03").ToString
            txtTipcambioAcum_3.Text = fila("cc21pro_TipCam_Acum_03").ToString
            '
            txtFactor_4.Text = fila("cc21Pro_04").ToString
            txtTipcambio_4.Text = fila("cc21pro_TipCam_Mes_04").ToString
            txtTipcambioAcum_4.Text = fila("cc21pro_TipCam_Acum_04").ToString
            '
            txtFactor_5.Text = fila("cc21Pro_05").ToString
            txtTipcambio_5.Text = fila("cc21pro_TipCam_Mes_05").ToString
            txtTipcambioAcum_5.Text = fila("cc21pro_TipCam_Acum_05").ToString
            '
            txtFactor_6.Text = fila("cc21Pro_06").ToString
            txtTipcambio_6.Text = fila("cc21pro_TipCam_Mes_06").ToString
            txtTipcambioAcum_6.Text = fila("cc21pro_TipCam_Acum_06").ToString
            '
            txtFactor_7.Text = fila("cc21Pro_07").ToString
            txtTipcambio_7.Text = fila("cc21pro_TipCam_Mes_07").ToString
            txtTipcambioAcum_7.Text = fila("cc21pro_TipCam_Acum_07").ToString
            '
            txtFactor_8.Text = fila("cc21Pro_08").ToString
            txtTipcambio_8.Text = fila("cc21pro_TipCam_Mes_08").ToString
            txtTipcambioAcum_8.Text = fila("cc21pro_TipCam_Acum_08").ToString
            '
            txtFactor_9.Text = fila("cc21Pro_09").ToString
            txtTipcambio_9.Text = fila("cc21pro_TipCam_Mes_09").ToString
            txtTipcambioAcum_9.Text = fila("cc21pro_TipCam_Acum_09").ToString
            '
            txtFactor_10.Text = fila("cc21Pro_10").ToString
            txtTipcambio_10.Text = fila("cc21pro_TipCam_Mes_10").ToString
            txtTipcambioAcum_10.Text = fila("cc21pro_TipCam_Acum_10").ToString
            '
            txtFactor_11.Text = fila("cc21Pro_11").ToString
            txtTipcambio_11.Text = fila("cc21pro_TipCam_Mes_11").ToString
            txtTipcambioAcum_11.Text = fila("cc21pro_TipCam_Acum_11").ToString
            '
            txtFactor_12.Text = fila("cc21Pro_12").ToString
            txtTipcambio_12.Text = fila("cc21pro_TipCam_Mes_12").ToString
            txtTipcambioAcum_12.Text = fila("cc21pro_TipCam_Acum_12").ToString

            txtFactor_13.Text = fila("cc21Pro_13").ToString
            txtTipcambio_13.Text = fila("cc21pro_TipCam_Mes_13").ToString
            txtTipcambioAcum_13.Text = fila("cc21pro_TipCam_Acum_13").ToString

            txtFactor_14.Text = fila("cc21Pro_14").ToString
            txtTipcambio_14.Text = fila("cc21pro_TipCam_Mes_14").ToString
            txtTipcambioAcum_14.Text = fila("cc21pro_TipCam_Acum_14").ToString

            txtFactor_15.Text = fila("cc21Pro_15").ToString
            txtTipcambio_15.Text = fila("cc21pro_TipCam_Mes_15").ToString
            txtTipcambioAcum_15.Text = fila("cc21pro_TipCam_Acum_15").ToString

        Next

        ' Cambio el Puntero del Mouse

        Exit Sub
mio:
        Resume Next
    End Sub
#End Region
#Region "Metodos de Mantenimiento"
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion gloabl
            Mod_Mantenimiento.HabyDesControles(Me, valor)
            'Perosnalizar habilitacion
            '
            btngrabar.Visible = valor
            btncancelar.Visible = valor

        Catch ex As Exception
        End Try
    End Sub
    Sub Iniciarcontroles()
        Me.HabilitarMantenimiento(True)
    End Sub
#End Region
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'Validar
            For Each co As Control In Me.Controls
                If Funciones.Funciones.izquierda(co.Name.ToUpper, 9) = "txtFactor" Then
                    If Funciones.Funciones.Esnumeromayoracero(co.Text) = False Then
                        MessageBox.Show(gbc_MensajeValidar + " Valor no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit For
                    End If
                End If
            Next

            ' Periodo Modificado
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            If accionMante = "M" Then
                a = objSql.Ejecutar2("Sp_Con_Upd_cc21produccion", gbcodempresa, gbano, "000", 0, 0, 0, _
                                    CDbl(txtFactor_1.Text), CDbl(txtTipcambio_1.Text), CDbl(txtTipcambioAcum_1.Text), _
                                    CDbl(txtFactor_2.Text), CDbl(txtTipcambio_2.Text), CDbl(txtTipcambioAcum_2.Text), _
                                    CDbl(txtFactor_3.Text), CDbl(txtTipcambio_3.Text), CDbl(txtTipcambioAcum_3.Text), _
                                    CDbl(txtFactor_4.Text), CDbl(txtTipcambio_4.Text), CDbl(txtTipcambioAcum_4.Text), _
                                    CDbl(txtFactor_5.Text), CDbl(txtTipcambio_5.Text), CDbl(txtTipcambioAcum_5.Text), _
                                    CDbl(txtFactor_6.Text), CDbl(txtTipcambio_6.Text), CDbl(txtTipcambioAcum_6.Text), _
                                    CDbl(txtFactor_7.Text), CDbl(txtTipcambio_7.Text), CDbl(txtTipcambioAcum_7.Text), _
                                    CDbl(txtFactor_8.Text), CDbl(txtTipcambio_8.Text), CDbl(txtTipcambioAcum_8.Text), _
                                    CDbl(txtFactor_9.Text), CDbl(txtTipcambio_9.Text), CDbl(txtTipcambioAcum_9.Text), _
                                    CDbl(txtFactor_10.Text), CDbl(txtTipcambio_10.Text), CDbl(txtTipcambioAcum_10.Text), _
                                    CDbl(txtFactor_11.Text), CDbl(txtTipcambio_11.Text), CDbl(txtTipcambioAcum_11.Text), _
                                    CDbl(txtFactor_12.Text), CDbl(txtTipcambio_12.Text), CDbl(txtTipcambioAcum_12.Text), _
                                    CDbl(txtFactor_13.Text), CDbl(txtTipcambio_13.Text), CDbl(txtTipcambioAcum_13.Text), _
                                    CDbl(txtFactor_14.Text), CDbl(txtTipcambio_14.Text), CDbl(txtTipcambioAcum_14.Text), _
                                    CDbl(txtFactor_15.Text), CDbl(txtTipcambio_15.Text), CDbl(txtTipcambioAcum_15.Text), _
                                    "")
            Else
                MessageBox.Show("ERROR :: No Eligio una opcion valida", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
            '
            Funciones.Funciones.MensajesdelSQl(a)
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Frm_Produccion_Datos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Inicializo mi formulario desde donde se cargo 
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            Me.Text = "Datos de produccion"

            Mod_Mantenimiento.tooltiptext(btngrabar, gbc_Ttp_Guardar)
            Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
            accionMante = "M"
            '
            HabilitarMantenimiento(True)
            '
            Me.Cargardatos()
            'Validar
            'For Each co As Control In Me.Controls
            'If TypeOf co Is TextBox Then
            'co.Text = "0"
            'End If
            'Next

        Catch ex As Exception
            MessageBox.Show(":: ERROR: Al cargar formulario" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
End Class
