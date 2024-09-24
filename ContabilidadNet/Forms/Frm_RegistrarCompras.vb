Imports System.IO
Imports System.Text
Imports C1.Win.C1TrueDBGrid.BaseGrid

Public Class Frm_RegistrarCompras
    Dim Vista As New DataView
    Dim VistaFrmVOucher As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
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

#Region "Metodos"
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub

#End Region

    '#Region "Mantenimiento"
    Sub TraerAyudaVisible(ByVal index As Integer, ByVal descripcion As String, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp.Location = New Point(x, y)
            Mod_Mantenimiento.LimpiarFiltro(tblhelp)
            tblhelp.Columns(0).Caption = "Codigo"
            tblhelp.Columns(1).Caption = "Descripcion"
            tblhelp.Columns(2).Caption = "Asiento_Tipo_Cod"
            tblhelp.Columns(3).Caption = "Asiento_Tipo_Desc"
            tblhelp.Columns(4).Caption = "Libro"
            tblhelp.Columns(5).Caption = "NOMENCLATURA"

            Select Case index
                Case 0
                    'CONCEPTO
                    tblhelp.Columns(0).DataField = "CO07ITEM"
                    tblhelp.Columns(1).DataField = "CO07DESCRIPCION"
                    tblhelp.Columns(2).DataField = "CO07ASIENTOTIPOCOD"
                    tblhelp.Columns(3).DataField = "ccc03des"
                    tblhelp.Columns(4).DataField = "ccc03lib"
                    tblhelp.Columns(5).DataField = "CO07NOMENCLATURA"
                    Me.TraerConcepto_AsientoTipo(descripcion, tblhelp)
                    tblhelp.Visible = True
                Case 1
                    'CENTRO COSTO
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraerCentroCosto(tblhelp)
                    tblhelp.Visible = True
                    tblhelp.Focus()
                Case 2
                    'ASIENTO TIPO
                    tblhelp.Columns(0).DataField = "ccc03cod"
                    tblhelp.Columns(1).DataField = "ccc03des"
                    tblhelp.Columns(2).DataField = "ccc03lib"
                    Me.TraerAsientoTipo(tblhelp)
                    tblhelp.Visible = True
                    tblhelp.Focus()

            End Select

            tblhelp.Tag = index.ToString
            ' tblhelp.Refresh()
     
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerAyuda(ByVal index As Integer, ByVal descripcion As String, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp1_bloque.Location = New Point(x, y)
            Mod_Mantenimiento.LimpiarFiltro(tblhelp1_bloque)
            tblhelp1_bloque.Columns(0).Caption = "Codigo"
            tblhelp1_bloque.Columns(1).Caption = "Descripcion"
            tblhelp1_bloque.Columns(2).Caption = "Asiento_Tipo_Cod"
            tblhelp1_bloque.Columns(3).Caption = "Asiento_Tipo_Desc"
            tblhelp1_bloque.Columns(4).Caption = "NOMENCLATURA"

            Select Case index
                Case 0
                    'CONCEPTO
                    tblhelp1_bloque.Columns(0).DataField = "CO07ITEM"
                    tblhelp1_bloque.Columns(1).DataField = "CO07DESCRIPCION"
                    tblhelp1_bloque.Columns(2).DataField = "CO07ASIENTOTIPOCOD"
                    tblhelp1_bloque.Columns(3).DataField = "ccc03des"
                    tblhelp1_bloque.Columns(4).DataField = "ccc03lib"
                    tblhelp1_bloque.Columns(5).DataField = "CO07NOMENCLATURA"
                    Me.TraerConcepto_AsientoTipo(descripcion, tblhelp1_bloque)
                    tblhelp1_bloque.Visible = True
                 
                Case 1
                    'CENTRO COSTO
                    tblhelp1_bloque.Columns(0).DataField = "ccb02cod"
                    tblhelp1_bloque.Columns(1).DataField = "ccb02des"
                    Me.TraerCentroCosto(tblhelp1_bloque)

                    tblhelp1_bloque.Visible = True
                    tblhelp1_bloque.Focus()
                Case 2
                    'ASIENTO TIPO
                    tblhelp1_bloque.Columns(0).DataField = "ccc03cod"
                    tblhelp1_bloque.Columns(1).DataField = "ccc03des"
                    tblhelp1_bloque.Columns(2).DataField = "ccc03lib"
                    Me.TraerAsientoTipo(tblhelp1_bloque)
                    tblhelp1_bloque.Visible = True
                    tblhelp1_bloque.Focus()

            End Select

            tblhelp1_bloque.Tag = index.ToString
            '  tblhelp1_bloque.Refresh()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerCentroCosto(ByVal TipoGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_CentroCosto", gbcodempresa, gbano).DefaultView
            TipoGrid.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerAsientoTipo(ByVal TipoGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ComAsientosTipo", gbcodempresa, gbano, "", "*").DefaultView
            TipoGrid.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TraerConcepto_AsientoTipo(ByVal Descripcion As String, ByVal TipoGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_MotivoDoc_AsientoTipo", gbcodempresa, gbano, Descripcion).DefaultView
            TipoGrid.SetDataBinding(Vista, Nothing, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Frm_RegistrarCompras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            'Dim formulario As Frm_ImportarSIRE_ComprasPrincipal = CType(Application.OpenForms("Frm_ImportarSIRfE_ComprasPrincipal"), Frm_ImportarSIRE_ComprasPrincipal)

            'If formulario IsNot Nothing Then
            Frm_ImportarSIRE_ComprasPrincipal.CompararSireVsCompras_RegistrarSire()

            'End If


        Catch ex As Exception

        End Try

    End Sub


    Private Sub Frm_RegistrarCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            btn_Contabilizar_Bloque.FlatStyle = FlatStyle.Flat
            btn_Contabilizar_Bloque.ForeColor = System.Drawing.Color.Black
            btn_Contabilizar_Bloque.FlatAppearance.BorderColor = System.Drawing.Color.Gray
            btn_Contabilizar_Bloque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray

            CrearColumnas()
            Cargar()
            ' Dim traerColumnaInteger As Integer = Convert.ToInt32(tblconsulta(0, "Previsualizar"))
            AddHandler Me.tblconsulta.FetchCellStyle, AddressOf tblconsulta_FetchCellStyle
            tblconsulta.Splits(1).DisplayColumns(25).Style.BackColor = Color.SandyBrown
            tblconsulta.Splits(1).DisplayColumns(26).Style.BackColor = Color.SandyBrown
            tblconsulta.Splits(1).DisplayColumns(27).Style.BackColor = Color.SandyBrown

            Mod_Mantenimiento.tooltiptext(btn_Contabilizar_Bloque, "Insertar en Bloque")
            '   Mod_Mantenimiento.tooltiptext(btnEliminarBloque, "Eliminar en Bloque")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CrearColumnas()
        Dim dt As DataTable = New DataTable
        Try


            dt.Columns.Add("Fecha_emision", GetType(String))
            dt.Columns.Add("Fecha_VctoPago", GetType(String))
            dt.Columns.Add("Tipo_CPDoc", GetType(String))
            dt.Columns.Add("Serie_CDP", GetType(String))
            dt.Columns.Add("Nro_CP", GetType(String))
            dt.Columns.Add("Tipo_Doc_Identidad", GetType(String))
            dt.Columns.Add("Nro_Doc_Identidad", GetType(String))
            dt.Columns.Add("Razon_Social_2", GetType(String))
            dt.Columns.Add("BI_Gravado_DG", GetType(Decimal))
            dt.Columns.Add("IGV_IPM_DG", GetType(Decimal))
            dt.Columns.Add("BI_Gravado_DGNG", GetType(Decimal))
            dt.Columns.Add("IGV_IPM_DGNG", GetType(Decimal))
            dt.Columns.Add("BI_Gravado_DNG", GetType(Decimal))
            dt.Columns.Add("IGV_IPM_DNG", GetType(Decimal))
            dt.Columns.Add("Valor_Adq_NG", GetType(Decimal))
            dt.Columns.Add("ISC", GetType(Decimal))
            dt.Columns.Add("ICBPER", GetType(Decimal))
            dt.Columns.Add("Otros_Trib_Cargos", GetType(Decimal))
            dt.Columns.Add("Total_CP", GetType(Decimal))
            dt.Columns.Add("Moneda", GetType(String))
            dt.Columns.Add("Tipo_Cambio", GetType(Decimal))
            dt.Columns.Add("Fecha_Emision_Doc_Modificado", GetType(String))
            dt.Columns.Add("Tipo_CP_Modificado", GetType(String))
            dt.Columns.Add("Serie_CP_Modificado", GetType(String))
            dt.Columns.Add("Nro_CP_Modificado", GetType(String))
            dt.Columns.Add("Concepto", GetType(String))
            dt.Columns.Add("Centro_Costo", GetType(String))
            dt.Columns.Add("Asiento_Tipo", GetType(String))
            dt.Columns.Add("Desc_asiento_tip", GetType(String))
            dt.Columns.Add("Libro", GetType(String))
            dt.Columns.Add("Nro_voucher", GetType(String))
            dt.Columns.Add("Refrescar_Nro_Voucher", GetType(String))
            dt.Columns.Add("Contabilizar", GetType(String))
            dt.Columns.Add("Previsualizar", GetType(String))
            ' FRMVOUCHER_ABC
            dt.Columns.Add("ccc01subd", GetType(String)) ' Libro
            dt.Columns.Add("ccc01numer", GetType(String)) ' Voucher
            dt.Columns.Add("ccc01fecha", GetType(String)) ' Fecha
            dt.Columns.Add("ccc01deta", GetType(String)) ' Concepto
            dt.Columns.Add("SireCAR_SUNAT", GetType(String))
            tblconsulta.DataSource = dt

            Me.tblconsulta.InsertHorizontalSplit(1)
            ' Ocultar columnas en el C1TrueDBGrid
            Me.tblconsulta.Splits(0).SplitSize = 3
            Me.tblconsulta.Splits(1).SplitSize = 1
            Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ccc01numer").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ccc01fecha").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ccc01fecha").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ccc01deta").Visible = False

            Me.tblconsulta.Splits(1).DisplayColumns("SireCAR_SUNAT").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Fecha_emision").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Fecha_VctoPago").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_CPDoc").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Serie_CDP").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Nro_CP").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_Doc_Identidad").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Nro_Doc_Identidad").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Razon_Social_2").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("BI_Gravado_DG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("IGV_IPM_DG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("BI_Gravado_DGNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("IGV_IPM_DGNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("BI_Gravado_DNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("IGV_IPM_DNG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Valor_Adq_NG").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ISC").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("ICBPER").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Otros_Trib_Cargos").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Total_CP").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Moneda").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_Cambio").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Fecha_Emision_Doc_Modificado").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Tipo_CP_Modificado").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Serie_CP_Modificado").Visible = False
            Me.tblconsulta.Splits(1).DisplayColumns("Nro_CP_Modificado").Visible = False
            'OTROS 
            'Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").Visible = False
            'Me.tblconsulta.Splits(1).DisplayColumns("ccc01numer").Visible = False
            'Me.tblconsulta.Splits(1).DisplayColumns("ccc01fecha").Visible = False
            'Me.tblconsulta.Splits(1).DisplayColumns("ccc01deta").Visible = False



            ' Establecer la longitud de cada columna individualmente
            tblconsulta.Splits(0).DisplayColumns("Fecha_emision").Width = 65
            tblconsulta.Splits(0).DisplayColumns("Fecha_VctoPago").Width = 60
            tblconsulta.Splits(0).DisplayColumns("Tipo_CPDoc").Width = 45
            tblconsulta.Splits(0).DisplayColumns("Serie_CDP").Width = 40
            tblconsulta.Splits(0).DisplayColumns("Nro_CP").Width = 55
            tblconsulta.Splits(0).DisplayColumns("Tipo_Doc_Identidad").Width = 50
            tblconsulta.Splits(0).DisplayColumns("Nro_Doc_Identidad").Width = 90
            tblconsulta.Splits(0).DisplayColumns("Razon_Social_2").Width = 250
            tblconsulta.Splits(0).DisplayColumns("BI_Gravado_DG").Width = 100
            tblconsulta.Splits(0).DisplayColumns("IGV_IPM_DG").Width = 120
            tblconsulta.Splits(0).DisplayColumns("BI_Gravado_DGNG").Width = 100
            tblconsulta.Splits(0).DisplayColumns("IGV_IPM_DGNG").Width = 120
            tblconsulta.Splits(0).DisplayColumns("BI_Gravado_DNG").Width = 100
            tblconsulta.Splits(0).DisplayColumns("IGV_IPM_DNG").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Valor_Adq_NG").Width = 100
            tblconsulta.Splits(0).DisplayColumns("ISC").Width = 100
            tblconsulta.Splits(0).DisplayColumns("ICBPER").Width = 100
            tblconsulta.Splits(0).DisplayColumns("Otros_Trib_Cargos").Width = 100
            tblconsulta.Splits(0).DisplayColumns("Total_CP").Width = 100
            tblconsulta.Splits(0).DisplayColumns("Moneda").Width = 80
            tblconsulta.Splits(0).DisplayColumns("Tipo_Cambio").Width = 100
            tblconsulta.Splits(0).DisplayColumns("Fecha_Emision_Doc_Modificado").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Tipo_CP_Modificado").Width = 100
            tblconsulta.Splits(0).DisplayColumns("Serie_CP_Modificado").Width = 80
            tblconsulta.Splits(0).DisplayColumns("Nro_CP_Modificado").Width = 80
            tblconsulta.Splits(0).DisplayColumns("Concepto").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Centro_Costo").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Asiento_Tipo").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Desc_asiento_tip").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Libro").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Nro_voucher").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Refrescar_Nro_Voucher").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Contabilizar").Width = 120
            tblconsulta.Splits(0).DisplayColumns("Previsualizar").Width = 120
            tblconsulta.Splits(0).DisplayColumns("ccc01subd").Width = 100
            tblconsulta.Splits(0).DisplayColumns("ccc01Fnumer").Width = 100
            tblconsulta.Splits(0).DisplayColumns("ccc01fecha").Width = 100
            tblconsulta.Splits(0).DisplayColumns("ccc01deta").Width = 100
            tblconsulta.Splits(0).DisplayColumns("SireCAR_SUNAT").Width = 100

            tblconsulta.Columns(0).Caption = "Fecha"
            tblconsulta.Columns(1).Caption = "FechaVcto"
            tblconsulta.Columns(2).Caption = "TipDoc"
            tblconsulta.Columns(3).Caption = "Serie"
            tblconsulta.Columns(4).Caption = "NrDoc"
            tblconsulta.Columns(5).Caption = "TipoIden"
            tblconsulta.Columns(6).Caption = "NrDocIdentidad"
            tblconsulta.Columns(7).Caption = "RazonSocial"
            'tblconsulta.Columns(8).Caption = "RazonSocial"

            'tblconsulta.Columns(0).BackColor = Color.PapayaWhip
            'tblconsulta.Style.BackColor




        Catch ex As Exception

        End Try
    End Sub
    Private Sub Cargar()
        Dim FechaEmision As String
        Dim rowIndex As Integer
        Dim newRow As DataRow
        Dim dt As DataTable
        Dim columnaRefrescarVoucher As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim columnaContabilizar As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim columnaPrevisualizar As C1.Win.C1TrueDBGrid.C1DisplayColumn

        Dim columnContabilizar As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim columnPrevisualizar As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim columnRefrescarNroVoucher As C1.Win.C1TrueDBGrid.C1DataColumn

        'Imagenes 
        Dim RefrescarImage As String
        Dim Check_conta As String
        Dim Lupa As String
        Try



            ' Obtener los datos del DataTable
            dt = objSql.TraerDataTable("Spu_Con_Trae_SireVsRegCompras", gbcodempresa, gbano, gbmes, "SIRESI_COMPRASNO")
            Dim count As Integer = dt.Rows.Count.ToString()
            rowIndex = tblconsulta.Row
            ' Obtener el DataTable del DataSource del C1TrueDBGrid
            Dim datatableC1TRUE As DataTable = DirectCast(tblconsulta.DataSource, DataTable)
            datatableC1TRUE.Clear()

            ' Verificar si el DataTable no está vacío
            If dt.Rows.Count > 0 Then
                '  Me.tblconsulta.Splits(1).FilterBarStyle.BackgroundImage = Nothing

                For Each fila As DataRow In dt.Rows
                    ' Agregar una fila al DataTable del C1TrueDBGrid
                    newRow = datatableC1TRUE.NewRow()
                    datatableC1TRUE.Rows.Add(newRow)

                    ' Asignar la fecha de emisión de la fila actual del DataTable al C1TrueDBGrid
                    newRow("SireCAR_SUNAT") = fila("SireCAR_SUNAT")
                    newRow("Fecha_emision") = fila("SireFecha_emision")
                    newRow("Fecha_VctoPago") = fila("SireFecha_VctoPago")
                    newRow("Tipo_CPDoc") = fila("SireTipo_CPDoc")
                    newRow("Serie_CDP") = fila("SireSerie_CDP")
                    newRow("Nro_CP") = fila("SireNro_CP")
                    newRow("Tipo_Doc_Identidad") = fila("SireTipo_Doc_Identidad")
                    newRow("Nro_Doc_Identidad") = fila("SireNro_Doc_Identidad")
                    newRow("Razon_Social_2") = fila("SireRazon_Social_2")
                    newRow("BI_Gravado_DG") = fila("SireBI_Gravado_DG")
                    newRow("IGV_IPM_DG") = fila("SireIGV_IPM_DG")
                    newRow("BI_Gravado_DGNG") = fila("SireBI_Gravado_DGNG")
                    newRow("IGV_IPM_DGNG") = fila("SireIGV_IPM_DGNG")
                    newRow("BI_Gravado_DNG") = fila("SireBI_Gravado_DNG")
                    newRow("IGV_IPM_DNG") = fila("SireIGV_IPM_DNG")
                    newRow("Valor_Adq_NG") = fila("SireValor_Adq_NG")
                    newRow("ISC") = fila("SireISC")
                    newRow("ICBPER") = fila("SireICBPER")
                    newRow("Otros_Trib_Cargos") = fila("SireOtros_Trib_Cargos")
                    newRow("Total_CP") = fila("SireTotal_CP")
                    newRow("Moneda") = fila("SireMoneda")
                    newRow("Tipo_Cambio") = fila("SireTipo_Cambio")
                    newRow("Fecha_Emision_Doc_Modificado") = fila("SireFecha_Emision_Doc_Modificado")
                    newRow("Tipo_CP_Modificado") = fila("SireTipo_CP_Modificado")
                    newRow("Serie_CP_Modificado") = fila("SireSerie_CP_Modificado")
                    newRow("Nro_CP_Modificado") = fila("SireNro_CP_Modificado")

                    newRow("ccc01fecha") = fila("SireFecha_emision")

                    Me.tblconsulta.Splits(1).DisplayColumns("Refrescar_Nro_Voucher").Button = True
                    Me.tblconsulta.Splits(1).DisplayColumns("Refrescar_Nro_Voucher").ButtonText = True

                    Me.tblconsulta.Splits(1).DisplayColumns("Previsualizar").Button = True
                    Me.tblconsulta.Splits(1).DisplayColumns("Previsualizar").ButtonText = True

                    Me.tblconsulta.Splits(1).DisplayColumns("Previsualizar").ButtonText = True

                    Me.tblconsulta.Splits(1).DisplayColumns("Contabilizar").Button = True
                    Me.tblconsulta.Splits(1).DisplayColumns("Contabilizar").ButtonText = True





                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").Button = True
                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").ButtonText = True

                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").Button = True
                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").ButtonText = True

                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01fecha").Button = True
                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01fecha").ButtonText = True

                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01deta").Button = True
                    Me.tblconsulta.Splits(1).DisplayColumns("ccc01deta").ButtonText = True




                    'Poner imagen en la celda 
                    columnaRefrescarVoucher = Me.tblconsulta.Splits(1).DisplayColumns("Refrescar_Nro_Voucher")
                    columnaContabilizar = Me.tblconsulta.Splits(1).DisplayColumns("Contabilizar")
                    columnaPrevisualizar = Me.tblconsulta.Splits(1).DisplayColumns("Previsualizar")


                    'Asignar Imagenes a
                    RefrescarImage = Path.Combine(Application.StartupPath, "Iconos\refrescar.png").ToString()
                    If File.Exists(RefrescarImage) Then
                        columnaRefrescarVoucher.Style.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Iconos\refrescar.png").ToString())
                        columnaRefrescarVoucher.Width = 18
                    Else
                        newRow("Refrescar_Nro_Voucher") = "R"
                        columnaRefrescarVoucher.Width = 18
                    End If

                    'columnaContabilizar
                    Check_conta = Path.Combine(Application.StartupPath, "Iconos\check_conta.png").ToString()
                    If File.Exists(Check_conta) Then
                        columnaContabilizar.Style.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Iconos\check_conta.png").ToString())
                        columnaContabilizar.Width = 18
                    Else
                        newRow("Contabilizar") = "C"
                        columnaContabilizar.Width = 18
                    End If

                    'columnaPrevisualizar
                    Lupa = Path.Combine(Application.StartupPath, "Iconos\lupa16.png").ToString()
                    If File.Exists(Lupa) Then
                        columnaPrevisualizar.Style.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Iconos\lupa16.png").ToString())
                        columnaPrevisualizar.Width = 18
                    Else
                        newRow("Previsualizar") = "P"
                        columnaPrevisualizar.Width = 18
                    End If

                Next
                VistaFrmVOucher = datatableC1TRUE.DefaultView
                'Actualizar total de registros
                Me.tblconsulta.ColumnFooters = True
                Me.tblconsulta.Columns(1).FooterText = "# Registros"
                Me.tblconsulta.Columns(2).FooterText = tblconsulta.RowCount.ToString
            Else

                ' Manejar el caso en que el DataTable esté vacío
                Console.WriteLine("El DataTable está vacío.")
            End If



            columnContabilizar = tblconsulta.Columns("Contabilizar")
            columnPrevisualizar = tblconsulta.Columns("Previsualizar")
            columnRefrescarNroVoucher = tblconsulta.Columns("Refrescar_Nro_Voucher")

            columnContabilizar.Caption = ""
            columnPrevisualizar.Caption = ""
            columnRefrescarNroVoucher.Caption = ""






            



        Catch ex As Exception
            MessageBox.Show("CARGAR:: ERROR")
        End Try
    End Sub
    Private Sub GuardarxBloque(ByVal TipoInsercion As String)
        Dim glosa As String = ""
        Dim xmlCadena As String = ""
        Dim valor As String = ""
        Dim rowindex As Integer
        Dim columnaFechaEmision As Integer = -1 ' Variable para almacenar el índice de la columna "Fecha_Emision"
        Dim filaSeleccionada As Integer
        Try
            rowindex = tblconsulta.Row
            'VALIDACIONES
            'If tblconsulta.SelectedRows.Count = 0 Then
            '    MessageBox.Show("Seleccionar documentos para generar voucher", "ERROR", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '    Return
            'End If
            If TipoInsercion = "UNITARIO" Then


                If tblconsulta.Item(tblconsulta.Row, "Asiento_Tipo").ToString() = "" _
                 OrElse tblconsulta.Item(tblconsulta.Row, "Libro").ToString() = "" _
                 OrElse tblconsulta.Item(tblconsulta.Row, "Nro_voucher").ToString() = "" Then
                    MessageBox.Show("Validacion:: Debe Ingresar :Asiento Tipo, Libro y Nro Voucher", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Return
                End If
                'END VALIDACIONES

                Dim registrosSeleccionados As New List(Of String) ' Declarar una lista para almacenar las variables

                'Dim j As Integer = 0
                'For Each filaSeleccionada In tblconsulta.SelectedRows

                registrosSeleccionados.Add(tblconsulta.Item(tblconsulta.Row, "SireCAR_SUNAT") & "|" &
                                            tblconsulta.Item(tblconsulta.Row, "Concepto") & "|" &
                                           tblconsulta.Item(tblconsulta.Row, "Centro_Costo") & "|" &
                                           tblconsulta.Item(tblconsulta.Row, "Asiento_Tipo") & "|" &
                                       tblconsulta.Item(tblconsulta.Row, "Libro") & "|" &
                                            tblconsulta.Item(tblconsulta.Row, "Nro_voucher"))

                'j += 1
                'Next


                xmlCadena = Funciones.Funciones.ConvertiraXMLdinamico(registrosSeleccionados)

                Dim mensaje As String = ""
                Dim flag As Integer = 0

                Dim dt As Array = objSql.Ejecutar2("Spu_Con_Ins_VoucherSireCompras", gbcodempresa, gbano, gbmes, xmlCadena, flag, "")

                mensaje = dt(1, 2)
                flag = dt(1, 1)
                If flag = -1 Then
                    MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                GrRegistrarBloque.Visible = False
            ElseIf TipoInsercion = "BLOQUE" Then


                If txtAsientoCod.Text = "" _
                 OrElse txtLibro.Text = "" _
                 OrElse txtNomenclatura.Text = "" _
                 OrElse txtAsientoDesc.Text = "" Then
                    MessageBox.Show("Validacion:: Debe Ingresar : Asiento Tipo, Libro y Nro Voucher", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Return
                End If

                'END VALIDACIONES
                'EXTRAER LETRA Y NUMERO
                Dim Letra As String = Funciones.Funciones.ExtraerLetras(txtNomenclatura.Text.Trim())
                Dim Numero As String = Funciones.Funciones.ExtraerParteNumerica(txtNomenclatura.Text.Trim())

                Dim rellenarceros As String = Funciones.Funciones.AgregarCeros(Numero)


                Dim registrosSeleccionados(tblconsulta.SelectedRows.Count - 1) As String
                Dim contador As Integer = 0
                Dim PrimerRecorido As Boolean = True
                Dim numeroConvertido As Integer = 0
                Dim ResultadoVoucher As String = ""
                Dim j As Integer = 0
                For Each filaSeleccionada In tblconsulta.SelectedRows


                    If PrimerRecorido Then
                        If Integer.TryParse(Numero, numeroConvertido) Then
                            ResultadoVoucher = Letra + numeroConvertido.ToString(rellenarceros)
                            PrimerRecorido = False
                        End If
                    Else
                        If Integer.TryParse(Numero, numeroConvertido) Then


                            numeroConvertido += 1
                            Numero = numeroConvertido.ToString()
                            ResultadoVoucher = Letra + numeroConvertido.ToString(rellenarceros)
                        End If
                    End If


                    registrosSeleccionados(j) = tblconsulta.Item(filaSeleccionada, "SireCAR_SUNAT") & "|" &
                                                txtConcepto.Text.ToString() & "|" &
                                               txtCentroCosto.Text.ToString() & "|" &
                                               txtAsientoCod.Text.ToString() & "|" &
                                           txtLibro.Text.ToString() & "|" &
                                           ResultadoVoucher.ToString()

                    tblconsulta.Item(filaSeleccionada, "Concepto") = txtConcepto.Text.ToString()
                    tblconsulta.Item(filaSeleccionada, "Centro_Costo") = txtCentroCosto.Text.ToString()
                    tblconsulta.Item(filaSeleccionada, "Asiento_Tipo") = txtAsientoCod.Text.ToString()
                    tblconsulta.Item(filaSeleccionada, "Desc_asiento_tip") = txtAsientoDesc.Text.ToString()
                    tblconsulta.Item(filaSeleccionada, "Libro") = txtLibro.Text.ToString()
                    tblconsulta.Item(filaSeleccionada, "Nro_voucher") = ResultadoVoucher.ToString()


                    tblconsulta.Item(filaSeleccionada, "ccc01subd") = txtLibro.Text.ToString()
                    tblconsulta.Item(filaSeleccionada, "ccc01numer") = ResultadoVoucher.ToString()
                    tblconsulta.Item(filaSeleccionada, "ccc01deta") = txtConcepto.Text.ToString()
                    j += 1



                Next


                xmlCadena = Funciones.Funciones.ConvertiraXMLdinamico(registrosSeleccionados)

                Dim mensaje As String = ""
                Dim flag As Integer = 0

                Dim dt As Array = objSql.Ejecutar2("Spu_Con_Ins_VoucherSireCompras", gbcodempresa, gbano, gbmes, xmlCadena, flag, "")
                mensaje = dt(1, 2)
                MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GrRegistrarBloque.Visible = False
            End If
            'CARGAR LA TBLCONSULTA Y VER EL CAMBIO




        Catch ex As Exception
            MessageBox.Show("Error al guardar Voucher contable.:" & ex.Message)
        End Try
    End Sub
    Public Shared Function ConvertiraXMLdinamico(ByVal lista As IEnumerable(Of String)) As String
        Dim sb As New StringBuilder()
        sb.Append("<DataSet>")

        ' recorrer filas
        For Each fila As String In lista
            ' recorrer columnas

            Dim celdas As String() = fila.Split("|"c)
            sb.Append("<tbl>")

            ' recorrer columnas
            Dim initagcampo As String = "", endtagcampo As String = ""
            For i As Integer = 0 To celdas.Length - 1
                initagcampo = "<campo" & (i + 1).ToString() & ">"
                endtagcampo = "</campo" & (i + 1).ToString() & ">"
                sb.Append(initagcampo)

                celdas(i) = celdas(i).Replace("&", "&amp;")
                sb.Append(celdas(i))
                sb.Append(endtagcampo)
            Next

            sb.Append("</tbl>")
        Next

        sb.Append("</DataSet>")
        Return sb.ToString()
    End Function

    Private Sub tblconsulta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tblconsulta.KeyPress
        Dim COlIndex As Integer
        Dim RowIndex As Integer
        Dim Descripcion As String
        Dim Nomenclatura As String
        Dim a As Array
        Dim NuevoNroVoucher As String
        Try
            COlIndex = tblconsulta.Col
            If COlIndex = 25 Then
                ' Descripcion = tblconsulta.Item(RowIndex, COlIndex).ToString()
                Descripcion = tblconsulta.Editor.Text.ToString()
                TraerAyudaVisible(0, Descripcion, btnsalir)

            End If
            'tblconsulta()
        Catch ex As Exception

        End Try
    End Sub
  

    Private Sub tblhelp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp.DoubleClick
   
        Dim indice As Integer
        indice = CType(tblhelp.Tag, Integer)
        Try
            If tblhelp.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim RowIndex As Integer
        Try
            RowIndex = tblconsulta.Row
            Select Case indice
                Case 0
                    'CONCEPTO
                    tblconsulta(RowIndex, "Concepto") = tblhelp_p.Columns("CO07DESCRIPCION").Value.ToString
                    tblconsulta(RowIndex, "Asiento_Tipo") = tblhelp_p.Columns("CO07ASIENTOTIPOCOD").Value.ToString
                    tblconsulta(RowIndex, "Desc_asiento_tip") = tblhelp_p.Columns("ccc03des").Value.ToString
                    tblconsulta(RowIndex, "Libro") = tblhelp_p.Columns("ccc03lib").Value.ToString
                    tblconsulta(RowIndex, "Nro_Voucher") = tblhelp_p.Columns("CO07NOMENCLATURA").Value.ToString

                    tblconsulta(RowIndex, "ccc01subd") = tblhelp_p.Columns("ccc03lib").Value.ToString ' Libro
                    tblconsulta(RowIndex, "ccc01deta") = tblhelp_p.Columns("CO07DESCRIPCION").Value.ToString ' Concepto


                    ' txtLibro.Focus()
                Case 1
                    'CENTRO COSTO
                    tblconsulta(RowIndex, "Centro_Costo") = tblhelp_p.Columns("ccb02cod").Value.ToString
                    ' tblconsulta(RowIndex, 27) = tblhelp_p.Columns("ccb02des").Value.ToString
                    ' txtLibro.Focus()
                Case 2
                    'ASIENTO TIPO
                    tblconsulta(RowIndex, "Asiento_Tipo") = tblhelp_p.Columns("ccc03cod").Value.ToString
                    tblconsulta(RowIndex, "Desc_asiento_tip") = tblhelp_p.Columns("ccc03des").Value.ToString
                    tblconsulta(RowIndex, "Libro") = tblhelp_p.Columns("ccc03lib").Value.ToString

                    tblconsulta(RowIndex, "ccc01subd") = tblhelp_p.Columns("ccc03lib").Value.ToString ' Libro

                    ' txtLibro.Focus()

            End Select

            Vista.Dispose()
            tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AsignarAyudaText(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim RowIndex As Integer
        Try
            RowIndex = tblconsulta.Row
            Select Case indice
                Case 0
                    'CONCEPTO
                    txtConcepto.Text = tblhelp1_bloque.Columns("CO07DESCRIPCION").Value.ToString
                    txtAsientoCod.Text = tblhelp1_bloque.Columns("CO07ASIENTOTIPOCOD").Value.ToString
                    txtAsientoDesc.Text = tblhelp1_bloque.Columns("ccc03des").Value.ToString
                    txtLibro.Text = tblhelp1_bloque.Columns("ccc03lib").Value.ToString
                    txtNomenclatura.Text = tblhelp1_bloque.Columns("CO07NOMENCLATURA").Value.ToString

                    ' txtLibro.Focus()
                Case 1
                    'CENTRO COSTO
                    txtCentroCosto.Text = tblhelp1_bloque.Columns("ccb02cod").Value.ToString
                    ' tblconsulta(RowIndex, 27) = tblhelp_p.Columns("ccb02des").Value.ToString
                    ' txtLibro.Focus()
                Case 2
                    'ASIENTO TIPO
                    txtAsientoCod.Text = tblhelp1_bloque.Columns("ccc03cod").Value.ToString
                    txtAsientoDesc.Text = tblhelp1_bloque.Columns("ccc03des").Value.ToString
                    txtLibro.Text = tblhelp1_bloque.Columns("ccc03lib").Value.ToString



                    ' txtLibro.Focus()

            End Select

            Vista.Dispose()
            tblhelp1_bloque.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblconsulta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblconsulta.KeyDown
        Dim RowIndex As Integer
        Dim ColIndex As Integer
        Dim Nomenclatura As String
        Dim NuevoNroVoucher As String
        Dim a As Array
        Try

            ColIndex = tblconsulta.Col

            'Validar si el tbhelp esta abierto
            If e.KeyCode = Keys.Escape Then
                If tblhelp.Visible = True Then
                    tblhelp.Visible = False
                End If
            End If
            If e.KeyCode = Keys.F1 Then
                If ColIndex = 26 Then ' si es centro costo
                    TraerAyudaVisible(1, "", btnsalir)

                ElseIf ColIndex = 27 Then ' si es asiento tipo
                    TraerAyudaVisible(2, "", btnsalir)
                End If

            End If
            If e.KeyCode = Keys.Enter Then


                If ColIndex = 30 Then
                    Nomenclatura = tblconsulta.Item(RowIndex, "Nro_voucher").ToString().ToUpper()
                    a = objSql.Ejecutar2("Sp_Con_Traer_NroVoucher", gbcodempresa, gbano, gbmes, tblconsulta.Item(RowIndex, "Libro").ToString(), Nomenclatura.Trim(), "")
                    NuevoNroVoucher = a(1, 1)
                    tblconsulta(RowIndex, "Nro_voucher") = NuevoNroVoucher
                    tblconsulta(RowIndex, "ccc01numer") = NuevoNroVoucher
                ElseIf ColIndex = 25 Then
                    tblhelp.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcepto.TextChanged

        Try
            If txtConcepto.Text = "" Then
                If tblhelp1_bloque.Visible = True Then
                    tblhelp1_bloque.Visible = False


                End If
            Else
                TraerAyuda(0, txtConcepto.Text.ToString(), BtnCentroCosto)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tblhelp1_bloque_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp1_bloque.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp1_bloque.Tag, Integer)
        Try
            If tblhelp1_bloque.RowCount < 1 Then Exit Sub
            Me.AsignarAyudaText(indice, tblhelp1_bloque)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCentroCosto.Click
        Try

            TraerAyuda(1, txtConcepto.Text.ToString(), BtnCentroCosto)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAsientoT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsientoT.Click
        Try
            TraerAyuda(2, txtConcepto.Text.ToString(), BtnAsientoT)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Contabilizar_Bloque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Contabilizar_Bloque.Click
        Try
            'PINTAR UNA FILA 
            Dim rowindex As Integer = tblconsulta.Row

            'tblconsulta.Splits(0).Style.BackColor = Color.LightGray
            'tblconsulta.Style.BackColor = Color.LightGreen
            'tblconsulta.Splits(1).Style.BackColor.LightGray
            txtConcepto.Text = ""
            txtCentroCosto.Text = ""
            txtAsientoCod.Text = ""
            txtAsientoDesc.Text = ""
            txtLibro.Text = ""
            txtNomenclatura.Text = ""
            If tblconsulta.SelectedRows.Count <= 1 Then
                MessageBox.Show("VALIDACION:: Debe seleccionar mas de 1 fila", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return

            End If
            GrRegistrarBloque.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim TipoInsercion As String
        Dim NuevoNroVoucher As String
        Dim a As Array
        Dim rowIndex As Integer
        Try

            If txtAsientoCod.Text = "" _
              OrElse txtLibro.Text = "" _
              OrElse txtNomenclatura.Text = "" _
              OrElse txtAsientoDesc.Text = "" Then
                MessageBox.Show("Validacion:: Debe Ingresar : Asiento Tipo, Libro y Nro Voucher", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Return
            End If

            a = objSql.Ejecutar2("Sp_Con_Traer_NroVoucher", gbcodempresa, gbano, gbmes, txtLibro.Text.ToString(), txtNomenclatura.Text.Trim(), "")
            NuevoNroVoucher = a(1, 1)
            txtNomenclatura.Text = NuevoNroVoucher.ToUpper()
            TipoInsercion = "BLOQUE"
            GuardarxBloque(TipoInsercion)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            GrRegistrarBloque.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblconsulta_ButtonClick(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tblconsulta.ButtonClick
        Dim rowIndex As Integer
        Dim colIndex As Integer
        Dim NuevoNroVoucher As String
        Dim Nomenclatura As String
        Dim OpcionInsercion As String
        Dim flag As Integer
        Dim msgretorno As String
        Dim a As Array
        Try
            rowIndex = tblconsulta.Row
            colIndex = tblconsulta.Col
            NuevoNroVoucher = ""
            If colIndex = 31 Then
                Nomenclatura = tblconsulta.Item(rowIndex, "Nro_voucher").ToString().ToUpper()
                a = objSql.Ejecutar2("Sp_Con_Traer_NroVoucher", gbcodempresa, gbano, gbmes, tblconsulta.Item(rowIndex, "Libro").ToString(), Nomenclatura.Trim(), "")
                NuevoNroVoucher = a(1, 1)
                tblconsulta(rowIndex, "Nro_voucher") = NuevoNroVoucher
                tblconsulta(rowIndex, "ccc01numer") = NuevoNroVoucher

            ElseIf colIndex = 33 Then


                If tblconsulta.Item(tblconsulta.Row, "Asiento_Tipo").ToString() = "" _
                OrElse tblconsulta.Item(tblconsulta.Row, "Libro").ToString() = "" _
                OrElse tblconsulta.Item(tblconsulta.Row, "Nro_Voucher").ToString() = "" Then
                    Return
                Else

                    a = objSql.Ejecutar2("Spu_Con_Trae_VoucherExistente", gbcodempresa, gbano, gbmes, tblconsulta.Item(tblconsulta.Row, "Libro").ToString(), tblconsulta.Item(tblconsulta.Row, "Nro_voucher").ToString(), flag, "")
                    flag = a(1, 1)
                    msgretorno = a(1, 2)
                    If flag = -1 Then
                        tblconsulta.Item(tblconsulta.Row, "Concepto") = ""
                        tblconsulta.Item(tblconsulta.Row, "Centro_Costo") = ""
                        tblconsulta.Item(tblconsulta.Row, "Asiento_Tipo") = ""
                        tblconsulta.Item(tblconsulta.Row, "Desc_asiento_tip") = ""
                        tblconsulta.Item(tblconsulta.Row, "Libro") = ""
                        tblconsulta.Item(tblconsulta.Row, "Nro_voucher") = ""

                        MessageBox.Show(msgretorno, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    If Funciones.Funciones.FormIsOpen("Frm_Voucher_Abc") Then Exit Sub
                    Dim _Frm_Voucher_Abc As New Frm_Voucher_Abc
                    'filaactual = Me.BindingContext(VistaFrmVOucher).Position ' El position no funciona, solo devuelve la fila a del gridview
                    FilaDeTabla = VistaFrmVOucher.Table.DefaultView.Item(rowIndex)
                    '
                    _Frm_Voucher_Abc.p_accionMante = "V"
                    _Frm_Voucher_Abc.p_RegistroActivo = FilaDeTabla
                    _Frm_Voucher_Abc.Owner = Me
                    _Frm_Voucher_Abc.Show()
                End If

            ElseIf colIndex = 32 Then


                tblconsulta.BackColor = Color.LightBlue

                OpcionInsercion = "UNITARIO"
                GuardarxBloque(OpcionInsercion)
                GrRegistrarBloque.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Sub CargaDetalleVoucher()
    '    Try
    '        Vista = objSql.TraerDataTable("sp_Con_Trae_Detalle_Voucher", gbcodempresa, gbano, gbmes, txtlibro.Text, txtNoVoucher.Text).DefaultView
    '        tblconsulta.SetDataBinding(Vista, Nothing, True)
    '        Me.capturarfilaactual()
    '        '
    '        lbltotalregistros.Text = tblconsulta.RowCount.ToString
    '        Me.Traetotaldevoucher()
    '        '
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub tblconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblconsulta.Click
    '    Try
    '        If tblconsulta.Item(tblconsulta.Row, "Concepto").ToString() = "" _
    '         OrElse tblconsulta.Item(tblconsulta.Row, "Libro").ToString() = "" _
    '         OrElse tblconsulta.Item(tblconsulta.Row, "Nro_Voucher").ToString() = "" Then
    '            Return
    '        Else
    '            Dim _Frm_Voucher_Abc As New Frm_Voucher_Abc
    '            filaactual = Me.BindingContext(VistaFrmVOucher).Position ' El position no funciona, solo devuelve la fila a del gridview
    '            FilaDeTabla = VistaFrmVOucher.Table.DefaultView.Item(filaactual)
    '            '
    '            _Frm_Voucher_Abc.p_accionMante = "V"
    '            _Frm_Voucher_Abc.p_RegistroActivo = FilaDeTabla
    '            _Frm_Voucher_Abc.Owner = Me
    '            _Frm_Voucher_Abc.Show()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub BtnGNroVucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub Frm_RegistrarCompras_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    Try
    '        Frm_ImportarSIRE_ComprasPrincipal.CompararSireVsCompras_RegistrarSire()
    '        Cargar()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        'Try
        '    Frm_ImportarSIRE_ComprasPrincipal.CompararSireVsCompras()
        'Catch ex As Exception

        'End Try
        Me.Close()
    End Sub

    Private Sub txtConcepto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConcepto.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                If tblhelp1_bloque.Visible = True Then
                    tblhelp1_bloque.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblconsulta_FetchCellStyle(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tblconsulta.FetchCellStyle
        Try
            ' Verificar si es la columna deseada
            If e.Col = tblconsulta.Col Then
                ' Cargar la imagen que deseas agregar a las celdas
                Dim image As Image = image.FromFile("C:\Users\sistemas\Desktop\PROYECTOS\ContabilidadNEt\ContabilidadNet\Resources\refrescar.png") ' Reemplaza la ruta con la ruta real de tu imagen

                ' Establecer la imagen de fondo de la celda actual
                e.CellStyle.BackgroundImage = image
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Try
            GrRegistrarBloque.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCentroCosto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnCentroCosto.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                If tblhelp1_bloque.Visible = True Then
                    tblhelp1_bloque.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAsientoT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAsientoT.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                If tblhelp1_bloque.Visible = True Then
                    tblhelp1_bloque.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblconsulta_FormatText(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FormatTextEventArgs) Handles tblconsulta.FormatText
        Try
            If (e.Value = "Refrescar_Nro_Voucher") Then

                e.Value = "Canada"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblhelp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.tblhelp_DoubleClick(Nothing, Nothing)
            ElseIf e.KeyCode = Keys.Escape Then
                If tblhelp.Visible = True Then
                    tblhelp.Visible = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblhelp1_bloque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp1_bloque.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.tblhelp1_bloque_DoubleClick(Nothing, Nothing)

            Else If e.KeyCode = Keys.Escape
            If tblhelp1_bloque.Visible = True Then
                tblhelp1_bloque.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminarBloque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim registrosSeleccionados(tblconsulta.SelectedRows.Count - 1) As String
            Dim contador As Integer = 0
            Dim PrimerRecorido As Boolean = True
            Dim numeroConvertido As Integer = 0
            Dim ResultadoVoucher As String = ""
            Dim j As Integer = 0
            Dim xmlCadena As String = ""
            Dim flag As Integer
            Dim msgretorno As String
            Dim a As Array
            'VERIFICAR SI SELECCIONO LOS REGISTROS
            If tblconsulta.SelectedRows.Count = 0 Then
                MessageBox.Show("Validacion:: Debe Seleccionar Registros para la eliminacion de los Vouchers", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            For Each filaSeleccionada In tblconsulta.SelectedRows

                'VERIFICAR SI ESTAN HAY DATO EN LOS CAMPOS DE LIBRO Y VOUCHER
                If tblconsulta.Item(filaSeleccionada, "Libro").ToString() = "" _
        OrElse tblconsulta.Item(filaSeleccionada, "Nro_voucher").ToString() = "" Then
                    MessageBox.Show("Validacion:: Debe Ingresar :Libro y Nro Voucher para eliminar los Vouchers", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Return
                End If


                'ccc01emp, ccc01ano, ccc01mes, ccc01subd(LIBRO), ccc01numer(nrovoucher)
                registrosSeleccionados(j) = tblconsulta.Item(filaSeleccionada, "Libro") & "|" &
                                            tblconsulta.Item(filaSeleccionada, "Nro_Voucher")
                'tblconsulta.Item(filaSeleccionada, "Concepto") = txtConcepto.Text.ToString()
                'tblconsulta.Item(filaSeleccionada, "Centro_Costo") = txtCentroCosto.Text.ToString()
                'tblconsulta.Item(filaSeleccionada, "Asiento_Tipo") = txtAsientoCod.Text.ToString()
                'tblconsulta.Item(filaSeleccionada, "Desc_asiento_tip") = txtAsientoDesc.Text.ToString()
                'tblconsulta.Item(filaSeleccionada, "Libro") = txtLibro.Text.ToString()
                'tblconsulta.Item(filaSeleccionada, "Nro_voucher") = ResultadoVoucher.ToString()


                'tblconsulta.Item(filaSeleccionada, "ccc01subd") = txtLibro.Text.ToString()
                'tblconsulta.Item(filaSeleccionada, "ccc01numer") = ResultadoVoucher.ToString()
                'tblconsulta.Item(filaSeleccionada, "ccc01deta") = txtConcepto.Text.ToString()
                j += 1



            Next
            xmlCadena = Funciones.Funciones.ConvertiraXMLdinamico(registrosSeleccionados)



            Dim dt As Array = objSql.Ejecutar2("sp_Con_Del_Voucher_xml", gbcodempresa, gbano, gbmes, xmlCadena, flag, "")
            msgretorno = dt(1, 2)

            MessageBox.Show(msgretorno, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GrRegistrarBloque.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click

    End Sub
End Class