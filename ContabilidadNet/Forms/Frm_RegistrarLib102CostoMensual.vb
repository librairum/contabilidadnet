Imports System.IO
Imports System.Text
Imports C1.Win.C1TrueDBGrid.BaseGrid

Public Class Frm_RegistrarLib102CostoMensual
    Dim Vista As New DataView
    Private accionMante As String
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

            'tblhelp.Location = New Point(x, y)
            'Mod_Mantenimiento.LimpiarFiltro(tblhelp)
            'tblhelp.Columns(0).Caption = "Codigo"
            'tblhelp.Columns(1).Caption = "Descripcion"
            'tblhelp.Columns(2).Caption = "Asiento_Tipo_Cod"
            'tblhelp.Columns(3).Caption = "Asiento_Tipo_Desc"
            'tblhelp.Columns(4).Caption = "Libro"
            'tblhelp.Columns(5).Caption = "NOMENCLATURA"

            Select Case index
                Case 0
                    'CONCEPTO
                    'tblhelp.Columns(0).DataField = "CO07ITEM"
                    'tblhelp.Columns(1).DataField = "CO07DESCRIPCION"
                    'tblhelp.Columns(2).DataField = "CO07ASIENTOTIPOCOD"
                    'tblhelp.Columns(3).DataField = "ccc03des"
                    'tblhelp.Columns(4).DataField = "ccc03lib"
                    'tblhelp.Columns(5).DataField = "CO07NOMENCLATURA"
                    'Me.TraerConcepto_AsientoTipo(descripcion, tblhelp)
                    '   tblhelp.Visible = True
                Case 1
                    'CENTRO COSTO
                    'tblhelp.Columns(0).DataField = "ccb02cod"
                    'tblhelp.Columns(1).DataField = "ccb02des"
                    'Me.TraerCentroCosto(tblhelp)
                    'tblhelp.Visible = True
                    'tblhelp.Focus()
                Case 2
                    'ASIENTO TIPO
                    'tblhelp.Columns(0).DataField = "ccc03cod"
                    'tblhelp.Columns(1).DataField = "ccc03des"
                    'tblhelp.Columns(2).DataField = "ccc03lib"
                    'Me.TraerAsientoTipo(tblhelp)
                    'tblhelp.Visible = True
                    'tblhelp.Focus()

            End Select

            ' tblhelp.Tag = index.ToString
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
            tblhelp_0.Columns(0).Caption = "Codigo"
            tblhelp_0.Columns(1).Caption = "Descripcion"
            'tblhelp1_bloque.Location = New Point(x, y)
            'Mod_Mantenimiento.LimpiarFiltro(tblhelp1_bloque)
            'tblhelp1_bloque.Columns(0).Caption = "Codigo"
            'tblhelp1_bloque.Columns(1).Caption = "Descripcion"
            'tblhelp1_bloque.Columns(2).Caption = "Asiento_Tipo_Cod"
            'tblhelp1_bloque.Columns(3).Caption = "Asiento_Tipo_Desc"
            'tblhelp1_bloque.Columns(4).Caption = "NOMENCLATURA"

            Select Case index
                Case 0
                    'CONCEPTO
                    tblhelp_0.Splits(0).DisplayColumns("Codigo").Visible = False
                    tblhelp_0.Columns(1).DataField = "lc102Anio"
                    ' tblhelp_0.Columns(1).DataField = "lc102Anio"
                    Me.TraerConcepto_AsientoTipo(descripcion, tblhelp_0)
                    Me.Traeimportacion()
                    tblhelp_0.Visible = True
                    tblhelp_0.Focus()

                Case 1
                    'CENTRO COSTO
                    'tblhelp1_bloque.Columns(0).DataField = "ccb02cod"
                    'tblhelp1_bloque.Columns(1).DataField = "ccb02des"
                    'Me.TraerCentroCosto(tblhelp1_bloque)

                    'tblhelp1_bloque.Visible = True
                    'tblhelp1_bloque.Focus()
                Case 2
                    'ASIENTO TIPO
                    'tblhelp1_bloque.Columns(0).DataField = "ccc03cod"
                    'tblhelp1_bloque.Columns(1).DataField = "ccc03des"
                    'tblhelp1_bloque.Columns(2).DataField = "ccc03lib"
                    'Me.TraerAsientoTipo(tblhelp1_bloque)
                    'tblhelp1_bloque.Visible = True
                    'tblhelp1_bloque.Focus()

            End Select

            ' tblhelp1_bloque.Tag = index.ToString
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



    Private Sub Frm_RegistrarLib102CostoMensual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '  tblconsulta.Enabled = False
            'btn_Contabilizar_Bloque.FlatStyle = FlatStyle.Flat
            'btn_Contabilizar_Bloque.ForeColor = System.Drawing.Color.Black
            'btn_Contabilizar_Bloque.FlatAppearance.BorderColor = System.Drawing.Color.Gray
            'btn_Contabilizar_Bloque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
            HabilitarMantenimiento(False)
            btn_help0.Visible = False
            CrearColumnas()
            Cargar()
            ' Dim traerColumnaInteger As Integer = Convert.ToInt32(tblconsulta(0, "Previsualizar"))
            'AddHandler Me.tblconsulta.FetchCellStyle, AddressOf tblconsulta_FetchCellStyle
            'tblconsulta.Splits(1).DisplayColumns(25).Style.BackColor = Color.SandyBrown
            'tblconsulta.Splits(1).DisplayColumns(26).Style.BackColor = Color.SandyBrown
            'tblconsulta.Splits(1).DisplayColumns(27).Style.BackColor = Color.SandyBrown

            'Mod_Mantenimiento.tooltiptext(btn_Contabilizar_Bloque, "Insertar en Bloque")
            ''   Mod_Mantenimiento.tooltiptext(btnEliminarBloque, "Eliminar en Bloque")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CrearColumnas()
        Dim dt As DataTable = New DataTable
        Try


            dt.Columns.Add("lc102Correlativo", GetType(Integer))
            dt.Columns.Add("lc102Descripcion", GetType(String))
            dt.Columns.Add("lc102CtaCble", GetType(String))
            dt.Columns.Add("lc102Importe_01", GetType(Decimal))
            dt.Columns.Add("lc102Importe_02", GetType(Decimal))
            dt.Columns.Add("lc102Importe_03", GetType(Decimal))
            dt.Columns.Add("lc102Importe_04", GetType(Decimal))
            dt.Columns.Add("lc102Importe_05", GetType(Decimal))
            dt.Columns.Add("lc102Importe_06", GetType(Decimal))
            dt.Columns.Add("lc102Importe_07", GetType(Decimal))
            dt.Columns.Add("lc102Importe_08", GetType(Decimal))
            dt.Columns.Add("lc102Importe_09", GetType(Decimal))
            dt.Columns.Add("lc102Importe_10", GetType(Decimal))
            dt.Columns.Add("lc102Importe_11", GetType(Decimal))
            dt.Columns.Add("lc102Importe_12", GetType(Decimal))
            dt.Columns.Add("TotalImportes", GetType(Decimal))
            tblconsulta.DataSource = dt

            tblconsulta.Columns("lc102Correlativo").Caption = "Item"
            tblconsulta.Columns("lc102Descripcion").Caption = "Descripción"
            tblconsulta.Columns("lc102CtaCble").Caption = "Cuenta Contable"
            tblconsulta.Columns("lc102Importe_01").Caption = "ENERO"
            tblconsulta.Columns("lc102Importe_02").Caption = "FEBRERO"
            tblconsulta.Columns("lc102Importe_03").Caption = "MARZO"
            tblconsulta.Columns("lc102Importe_04").Caption = "ABRIL"
            tblconsulta.Columns("lc102Importe_05").Caption = "MAYO"
            tblconsulta.Columns("lc102Importe_06").Caption = "JUNIO"
            tblconsulta.Columns("lc102Importe_07").Caption = "JULIO"
            tblconsulta.Columns("lc102Importe_08").Caption = "AGOSTO"
            tblconsulta.Columns("lc102Importe_09").Caption = "SETIEMBRE"
            tblconsulta.Columns("lc102Importe_10").Caption = "OCTUBRE"
            tblconsulta.Columns("lc102Importe_11").Caption = "NOVIEMBRE"
            tblconsulta.Columns("lc102Importe_12").Caption = "DICIEMBRE"


            tblconsulta.Columns("lc102Importe_01").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_02").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_03").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_04").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_05").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_06").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_07").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_08").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_09").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_10").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_11").NumberFormat = "Standard"
            tblconsulta.Columns("lc102Importe_12").NumberFormat = "Standard"
            tblconsulta.Columns("TotalImportes").NumberFormat = "Standard"

            tblconsulta.Columns("TotalImportes").Caption = "Total Importes"


            tblconsulta.Splits(0).DisplayColumns("lc102Correlativo").Width = 50
            tblconsulta.Splits(0).DisplayColumns("lc102Descripcion").Width = 230



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
        Dim columnaActualizar As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim columnaCancelar As C1.Win.C1TrueDBGrid.C1DisplayColumn

        
        'Imagenes 
        Dim RefrescarImage As String
        Dim Check_conta As String
        Dim Lupa As String
        Try

            
            ' Obtener los datos del DataTable
            dt = New DataTable
            dt = objSql.TraerDataTable("Spu_Con_Trae_lc102RegCosCostoMensual", gbcodempresa, gbano)
            Dim count As Integer = dt.Rows.Count.ToString()
            rowIndex = tblconsulta.Row
            ' Obtener el DataTable del DataSource del C1TrueDBGrid
            
            Dim datatableC1TRUE As DataTable = DirectCast(tblconsulta.DataSource, DataTable)
            
            ' Verificar si el DataTable no está vacío
            If dt.Rows.Count > 0 Then
                '  Me.tblconsulta.Splits(1).FilterBarStyle.BackgroundImage = Nothing

                For Each fila As DataRow In dt.Rows
                    ' Agregar una fila al DataTable del C1TrueDBGrid
                    newRow = datatableC1TRUE.NewRow()
                    datatableC1TRUE.Rows.Add(newRow)

                    ' Asignar la fecha de emisión de la fila actual del DataTable al C1TrueDBGrid
                    newRow("lc102Correlativo") = fila("lc102Correlativo")
                    newRow("lc102Descripcion") = fila("lc102Descripcion")
                    newRow("lc102CtaCble") = fila("lc102CtaCble")
                    newRow("lc102Importe_01") = fila("lc102Importe_01")
                    newRow("lc102Importe_02") = fila("lc102Importe_02")
                    newRow("lc102Importe_03") = fila("lc102Importe_03")
                    newRow("lc102Importe_04") = fila("lc102Importe_04")
                    newRow("lc102Importe_05") = fila("lc102Importe_05")
                    newRow("lc102Importe_06") = fila("lc102Importe_06")
                    newRow("lc102Importe_07") = fila("lc102Importe_07")
                    newRow("lc102Importe_08") = fila("lc102Importe_08")
                    newRow("lc102Importe_09") = fila("lc102Importe_09")
                    newRow("lc102Importe_10") = fila("lc102Importe_10")
                    newRow("lc102Importe_11") = fila("lc102Importe_11")
                    newRow("lc102Importe_12") = fila("lc102Importe_12")
                    
                    newRow("TotalImportes") = fila("TotalImportes")


                    'Me.tblconsulta.Splits(1).DisplayColumns("Previsualizar").Button = True
                    'Me.tblconsulta.Splits(1).DisplayColumns("Previsualizar").ButtonText = True

                    'Me.tblconsulta.Splits(1).DisplayColumns("Previsualizar").ButtonText = True

                    'Me.tblconsulta.Splits(1).DisplayColumns("Contabilizar").Button = True
                    'Me.tblconsulta.Splits(1).DisplayColumns("Contabilizar").ButtonText = True





                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").Button = True
                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").ButtonText = True

                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").Button = True
                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01subd").ButtonText = True

                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01fecha").Button = True
                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01fecha").ButtonText = True

                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01deta").Button = True
                    'Me.tblconsulta.Splits(1).DisplayColumns("ccc01deta").ButtonText = True




                    ''Poner imagen en la celda 


                    ''Asignar Imagenes a
                    'RefrescarImage = Path.Combine(Application.StartupPath, "Iconos\refrescar.png").ToString()
                    'If File.Exists(RefrescarImage) Then
                    '    columnaRefrescarVoucher.Style.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Iconos\refrescar.png").ToString())
                    '    columnaRefrescarVoucher.Width = 18
                    'Else
                    '    newRow("Refrescar_Nro_Voucher") = "R"
                    '    columnaRefrescarVoucher.Width = 18
                    'End If

                    ''columnaContabilizar

                    ''columnaPrevisualizar
                    'Lupa = Path.Combine(Application.StartupPath, "Iconos\lupa16.png").ToString()
                    'If File.Exists(Lupa) Then
                    '    columnaPrevisualizar.Style.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Iconos\lupa16.png").ToString())
                    '    columnaPrevisualizar.Width = 18
                    'Else
                    '    newRow("Previsualizar") = "P"
                    '    columnaPrevisualizar.Width = 18
                    'End If

                Next
                'VistaFrmVOucher = datatableC1TRUE.DefaultView
                ''Actualizar total de registros
                'Me.tblconsulta.ColumnFooters = True
                'Me.tblconsulta.Columns(1).FooterText = "# Registros"
                'Me.tblconsulta.Columns(2).FooterText = tblconsulta.RowCount.ToString
                
            Else

                ' Manejar el caso en que el DataTable esté vacío
                Console.WriteLine("El DataTable está vacío.")
            End If



            'columnContabilizar = tblconsulta.Columns("Contabilizar")
            'columnPrevisualizar = tblconsulta.Columns("Previsualizar")
            'columnRefrescarNroVoucher = tblconsulta.Columns("Refrescar_Nro_Voucher")

            'columnContabilizar.Caption = ""
            'columnPrevisualizar.Caption = ""
            'columnRefrescarNroVoucher.Caption = ""










        Catch ex As Exception
            MessageBox.Show("CARGAR:: ERROR")
        End Try
    End Sub
    Function CalcularTotalImportes(ByVal grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Decimal
        ' Declarar una variable para almacenar el total
        Dim totalImportes As Decimal = 0

        ' Iterar a través de las columnas del grid
        For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In grid.Columns
            ' Verificar si la columna es de tipo Decimal (importes)
            If col.DataType.Equals(GetType(Decimal)) AndAlso col.DataField.StartsWith("lc102Importe_") Then
                ' Sumar el valor de la columna actual a totalImportes
                For i As Integer = 0 To grid.RowCount - 1
                    totalImportes += Convert.ToDecimal(grid(i, col.DataField))
                Next
            End If
        Next

        ' Devolver el total calculado
        Return totalImportes
    End Function
    'Private Sub GuardarxBloque(ByVal TipoInsercion As String)
    '    Dim glosa As String = ""
    '    Dim xmlCadena As String = ""
    '    Dim valor As String = ""
    '    Dim rowindex As Integer
    '    Dim columnaFechaEmision As Integer = -1 ' Variable para almacenar el índice de la columna "Fecha_Emision"
    '    Dim filaSeleccionada As Integer
    '    Try
    '        rowindex = tblconsulta.Row
    '        'VALIDACIONES
    '        'If tblconsulta.SelectedRows.Count = 0 Then
    '        '    MessageBox.Show("Seleccionar documentos para generar voucher", "ERROR", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '        '    Return
    '        'End If
    '        If TipoInsercion = "UNITARIO" Then


    '            If tblconsulta.Item(tblconsulta.Row, "Asiento_Tipo").ToString() = "" _
    '             OrElse tblconsulta.Item(tblconsulta.Row, "Libro").ToString() = "" _
    '             OrElse tblconsulta.Item(tblconsulta.Row, "Nro_voucher").ToString() = "" Then
    '                MessageBox.Show("Validacion:: Debe Ingresar :Asiento Tipo, Libro y Nro Voucher", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '                Return
    '            End If
    '            'END VALIDACIONES

    '            Dim registrosSeleccionados As New List(Of String) ' Declarar una lista para almacenar las variables

    '            'Dim j As Integer = 0
    '            'For Each filaSeleccionada In tblconsulta.SelectedRows

    '            registrosSeleccionados.Add(tblconsulta.Item(tblconsulta.Row, "SireCAR_SUNAT") & "|" &
    '                                        tblconsulta.Item(tblconsulta.Row, "Concepto") & "|" &
    '                                       tblconsulta.Item(tblconsulta.Row, "Centro_Costo") & "|" &
    '                                       tblconsulta.Item(tblconsulta.Row, "Asiento_Tipo") & "|" &
    '                                   tblconsulta.Item(tblconsulta.Row, "Libro") & "|" &
    '                                        tblconsulta.Item(tblconsulta.Row, "Nro_voucher"))

    '            'j += 1
    '            'Next


    '            xmlCadena = Funciones.Funciones.ConvertiraXMLdinamico(registrosSeleccionados)

    '            Dim mensaje As String = ""
    '            Dim flag As Integer = 0

    '            Dim dt As Array = objSql.Ejecutar2("Spu_Con_Ins_VoucherSireCompras", gbcodempresa, gbano, gbmes, xmlCadena, flag, "")

    '            mensaje = dt(1, 2)
    '            flag = dt(1, 1)
    '            If flag = -1 Then
    '                MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Return
    '            Else
    '                MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If

    '            ' GrRegistrarBloque.Visible = False
    '        ElseIf TipoInsercion = "BLOQUE" Then


    '            'If txtAsientoCod.Text = "" _
    '            ' OrElse txtLibro.Text = "" _
    '            ' OrElse txtNomenclatura.Text = "" _
    '            ' OrElse txtAsientoDesc.Text = "" Then
    '            '    MessageBox.Show("Validacion:: Debe Ingresar : Asiento Tipo, Libro y Nro Voucher", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '            '    Return
    '            'End If

    '            'END VALIDACIONES
    '            'EXTRAER LETRA Y NUMERO
    '            Dim Letra As String = Funciones.Funciones.ExtraerLetras(txtNomenclatura.Text.Trim())
    '            Dim Numero As String = Funciones.Funciones.ExtraerParteNumerica(txtNomenclatura.Text.Trim())

    '            Dim rellenarceros As String = Funciones.Funciones.AgregarCeros(Numero)


    '            Dim registrosSeleccionados(tblconsulta.SelectedRows.Count - 1) As String
    '            Dim contador As Integer = 0
    '            Dim PrimerRecorido As Boolean = True
    '            Dim numeroConvertido As Integer = 0
    '            Dim ResultadoVoucher As String = ""
    '            Dim j As Integer = 0
    '            For Each filaSeleccionada In tblconsulta.SelectedRows


    '                If PrimerRecorido Then
    '                    If Integer.TryParse(Numero, numeroConvertido) Then
    '                        ResultadoVoucher = Letra + numeroConvertido.ToString(rellenarceros)
    '                        PrimerRecorido = False
    '                    End If
    '                Else
    '                    If Integer.TryParse(Numero, numeroConvertido) Then


    '                        numeroConvertido += 1
    '                        Numero = numeroConvertido.ToString()
    '                        ResultadoVoucher = Letra + numeroConvertido.ToString(rellenarceros)
    '                    End If
    '                End If


    '                registrosSeleccionados(j) = tblconsulta.Item(filaSeleccionada, "SireCAR_SUNAT") & "|" &
    '                                            txtConcepto.Text.ToString() & "|" &
    '                                           txtCentroCosto.Text.ToString() & "|" &
    '                                           txtAsientoCod.Text.ToString() & "|" &
    '                                       txtLibro.Text.ToString() & "|" &
    '                                       ResultadoVoucher.ToString()

    '                tblconsulta.Item(filaSeleccionada, "Concepto") = txtConcepto.Text.ToString()
    '                tblconsulta.Item(filaSeleccionada, "Centro_Costo") = txtCentroCosto.Text.ToString()
    '                tblconsulta.Item(filaSeleccionada, "Asiento_Tipo") = txtAsientoCod.Text.ToString()
    '                tblconsulta.Item(filaSeleccionada, "Desc_asiento_tip") = txtAsientoDesc.Text.ToString()
    '                tblconsulta.Item(filaSeleccionada, "Libro") = txtLibro.Text.ToString()
    '                tblconsulta.Item(filaSeleccionada, "Nro_voucher") = ResultadoVoucher.ToString()


    '                tblconsulta.Item(filaSeleccionada, "ccc01subd") = txtLibro.Text.ToString()
    '                tblconsulta.Item(filaSeleccionada, "ccc01numer") = ResultadoVoucher.ToString()
    '                tblconsulta.Item(filaSeleccionada, "ccc01deta") = txtConcepto.Text.ToString()
    '                j += 1



    '            Next


    '            xmlCadena = Funciones.Funciones.ConvertiraXMLdinamico(registrosSeleccionados)

    '            Dim mensaje As String = ""
    '            Dim flag As Integer = 0

    '            Dim dt As Array = objSql.Ejecutar2("Spu_Con_Ins_VoucherSireCompras", gbcodempresa, gbano, gbmes, xmlCadena, flag, "")
    '            mensaje = dt(1, 2)
    '            MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            ''  GrRegistrarBloque.Visible = False
    '        End If
    '        'CARGAR LA TBLCONSULTA Y VER EL CAMBIO




    '    Catch ex As Exception
    '        MessageBox.Show("Error al guardar Voucher contable.:" & ex.Message)
    '    End Try
    'End Sub

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


    Private Sub tblhelp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim indice As Integer
        'indice = CType(tblhelp.Tag, Integer)
        'Try
        '    If tblhelp.RowCount < 1 Then Exit Sub
        '    Me.AsignarAyuda(indice, tblhelp)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim RowIndex As Integer
        Try
            RowIndex = tblconsulta.Row
            Select Case indice
                Case 0
                    Dim anioanterior As String
                    anioanterior = tblhelp_0.Columns(1).Value.ToString

                    If MessageBox.Show("¿Esta Seguro de importar datos del año : " & anioanterior, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
                        Cursor.Current = Cursors.WaitCursor
                        '  Frm_LibLeg_101RegistroCosto_Load(Nothing, Nothing)
                        a = objSql.Ejecutar2("Spu_Con_Ins_PerAntlc102RegCosCostoMensual", gbcodempresa, gbano, anioanterior, "")
                        If Funciones.Funciones.MensajesdelSQl(a) = True Then
                            Me.Cargar()
                            tblhelp_0.Visible = False
                        Else
                            'No hago nada
                            tblhelp_0.Visible = False
                        End If
                        ' Me.cargarDatos()
                    
                        Cursor.Current = Cursors.Default
                    End If


                    ' txtLibro.Focus()
                Case 1
                Case 2

            End Select

            Vista.Dispose()
            '  tblhelp.Visible = False
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
                    'txtConcepto.Text = tblhelp1_bloque.Columns("CO07DESCRIPCION").Value.ToString
                    'txtAsientoCod.Text = tblhelp1_bloque.Columns("CO07ASIENTOTIPOCOD").Value.ToString
                    'txtAsientoDesc.Text = tblhelp1_bloque.Columns("ccc03des").Value.ToString
                    'txtLibro.Text = tblhelp1_bloque.Columns("ccc03lib").Value.ToString
                    'txtNomenclatura.Text = tblhelp1_bloque.Columns("CO07NOMENCLATURA").Value.ToString

                    ' txtLibro.Focus()
                Case 1
                    'CENTRO COSTO
                    'txtCentroCosto.Text = tblhelp1_bloque.Columns("ccb02cod").Value.ToString

                    ' tblconsulta(RowIndex, 27) = tblhelp_p.Columns("ccb02des").Value.ToString
                    ' txtLibro.Focus()
                Case 2
                    'ASIENTO TIPO
                    'txtAsientoCod.Text = tblhelp1_bloque.Columns("ccc03cod").Value.ToString
                    'txtAsientoDesc.Text = tblhelp1_bloque.Columns("ccc03des").Value.ToString
                    'txtLibro.Text = tblhelp1_bloque.Columns("ccc03lib").Value.ToString



                    ' txtLibro.Focus()

            End Select

            Vista.Dispose()
            '  tblhelp1_bloque.Visible = False
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
            'If e.KeyCode = Keys.Escape Then
            '    If tblhelp.Visible = True Then
            '        tblhelp.Visible = False
            '    End If
            'End If
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
                    ' tblhelp.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Try
        '    If txtConcepto.Text = "" Then
        '        If tblhelp1_bloque.Visible = True Then
        '            tblhelp1_bloque.Visible = False


        '        End If
        '    Else
        '        TraerAyuda(0, txtConcepto.Text.ToString(), BtnCentroCosto)
        '    End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub tblhelp1_bloque_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim indice As Integer
        '    indice = CType(tblhelp1_bloque.Tag, Integer)
        Try
            ' If tblhelp1_bloque.RowCount < 1 Then Exit Sub
            'Me.AsignarAyudaText(indice, tblhelp1_bloque)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            '  TraerAyuda(1, txtConcepto.Text.ToString(), BtnCentroCosto)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAsientoT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '  TraerAyuda(2, txtConcepto.Text.ToString(), BtnAsientoT)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Contabilizar_Bloque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'PINTAR UNA FILA 
            Dim rowindex As Integer = tblconsulta.Row

            'tblconsulta.Splits(0).Style.BackColor = Color.LightGray
            'tblconsulta.Style.BackColor = Color.LightGreen
            'tblconsulta.Splits(1).Style.BackColor.LightGray
            'txtConcepto.Text = ""
            'txtCentroCosto.Text = ""
            'txtAsientoCod.Text = ""
            'txtAsientoDesc.Text = ""
            'txtLibro.Text = ""
            'txtNomenclatura.Text = ""
            If tblconsulta.SelectedRows.Count <= 1 Then
                MessageBox.Show("VALIDACION:: Debe seleccionar mas de 1 fila", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return

            End If
            ' GrRegistrarBloque.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TipoInsercion As String
        Dim NuevoNroVoucher As String
        Dim a As Array
        Dim rowIndex As Integer
        Dim lc102Importe_01 As Decimal
        Dim lc102Importe_02 As Decimal
        Dim lc102Importe_03 As Decimal
        Dim lc102Importe_04 As Decimal
        Dim lc102Importe_05 As Decimal
        Dim lc102Importe_06 As Decimal
        Dim lc102Importe_07 As Decimal
        Dim lc102Importe_08 As Decimal
        Dim lc102Importe_09 As Decimal
        Dim lc102Importe_10 As Decimal
        Dim lc102Importe_11 As Decimal
        Dim lc102Importe_12 As Decimal
        Dim Correlativo As String
        Dim CtaContable As String
        Try

            rowIndex = tblconsulta.Row
            'INSERTAR DATOS DEL LIBRO 102+
            Correlativo = tblconsulta.Item(rowIndex, "lc102Correlativo").ToString()
            CtaContable = tblconsulta.Item(rowIndex, "lc102CtaCble").ToString()
            lc102Importe_01 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_01").ToString())
            lc102Importe_02 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_02").ToString())
            lc102Importe_03 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_03").ToString())
            lc102Importe_04 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_04").ToString())
            lc102Importe_05 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_05").ToString())
            lc102Importe_06 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_06").ToString())
            lc102Importe_07 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_07").ToString())
            lc102Importe_08 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_08").ToString())
            lc102Importe_09 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_09").ToString())
            lc102Importe_10 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_10").ToString())
            lc102Importe_11 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_11").ToString())
            lc102Importe_12 = Convert.ToDecimal(tblconsulta.Item(rowIndex, "lc102Importe_12").ToString())


            a = objSql.Ejecutar2("Spu_Con_Upd_lc102RegCosCostoMensual", gbcodempresa, gbano, Correlativo, CtaContable.ToString().Trim(), lc102Importe_01, lc102Importe_02, lc102Importe_03, lc102Importe_04, lc102Importe_05, lc102Importe_06, lc102Importe_07, lc102Importe_08, lc102Importe_09, lc102Importe_10, lc102Importe_11, lc102Importe_12, "")

            If Funciones.Funciones.MensajesdelSQl(a) = True Then

                Me.Cargar()
                ' Frm_LibLeg_101RegistroCosto_Load(Nothing, Nothing)
                ' Me.Posicionar("co07ITEM", txtCodigo.Text.Trim, tblconsulta, Vista)



            Else
                'No hago nada
            End If
            'END INSERTAR DATOS 


            'If txtAsientoCod.Text = "" _
            '  OrElse txtLibro.Text = "" _
            '  OrElse txtNomenclatura.Text = "" _
            '  OrElse txtAsientoDesc.Text = "" Then
            '    MessageBox.Show("Validacion:: Debe Ingresar : Asiento Tipo, Libro y Nro Voucher", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'Return
            'End If

            'ao = objSql.Ejecutar2("Sp_Con_Traer_NroVoucher", gbcodempresa, gbano, gbmes, txtLibro.Text.ToString(), txtNomenclatura.Text.Trim(), "")
            'NuevoNroVoucher = a(1, 1)
            'txtNomenclatura.Text = NuevoNroVoucher.ToUpper()
            'TipoInsercion = "BLOQUE"
            'GuardarxBloque(TipoInsercion)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '  GrRegistrarBloque.Visible = False
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
            If colIndex = 15 Then
                btngrabar_Click(Nothing, Nothing)
            ElseIf colIndex = 16 Then
                eliminar()

            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub eliminar()
        Dim CodigoActivo As String
        Dim CodigoActivoAnt As String
        Dim filaAnterior As Integer
        Dim FilaDeTablaAnterior As DataRowView
        Dim ITEM As Integer
        Dim flag As Integer
        Dim msgretorno As String = ""
        Try
            '=============Validaciones ============
            'Capturo la fila anterior para posicionarme despues de la eliminacion
            'If filaactual > 0 Then
            '    filaAnterior = filaactual - 1
            'Else
            '    filaAnterior = filaactual
            'End If
            'FilaDeTablaAnterior = Vista.Table.DefaultView.Item(filaAnterior)

            'CodigoActivoAnt = FilaDeTablaAnterior("co09ITEM").ToString
            'CodigoActivo = FilaDeTabla("co09ITEM").ToString
            ''
            Beep()
            If "" = Windows.Forms.DialogResult.No Then Exit Sub
            'Me.accionMante = "E"
            ' ITEM = Convert.ToInt32(txtCodigo.Text.ToString())
            ' Asigno los Valores a los Parametros del Query
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            ' a = objSql.Ejecutar2("Spu_Con_Del_lc101RegCosEstCosto", gbcodempresa, gbano, txtCodigo.Text.ToString.Trim, "")
            Cursor.Current = Cursors.WaitCursor
            If Funciones.Funciones.MensajesdelSQl(a) = True Then
                ' String mensaje = a(1,2)
                'lblhelp_0.Text = ""
                'Frm_LibLeg_101RegistroCosto_Load(Nothing, Nothing)

                ' Me.Posicionar("cc25codigo", txtCodigo.Text.Trim, tblconsulta, Vista)
            Else
                'No hago nada
            End If
            Cursor.Current = Cursors.Default
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

    Private Sub txtConcepto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            'If e.KeyCode = Keys.Escape Then
            '    If tblhelp1_bloque.Visible = True Then
            '        tblhelp1_bloque.Visible = False
            '    End If
            'End If
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

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '   GrRegistrarBloque.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCentroCosto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            'If e.KeyCode = Keys.Escape Then
            '    If tblhelp1_bloque.Visible = True Then
            '        tblhelp1_bloque.Visible = False
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAsientoT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            'If e.KeyCode = Keys.Escape Then
            '    If tblhelp1_bloque.Visible = True Then
            '        tblhelp1_bloque.Visible = False
            '    End If
            'End If
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

    Private Sub tblhelp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            'If e.KeyCode = Keys.Enter Then
            '    Me.tblhelp_DoubleClick(Nothing, Nothing)
            'ElseIf e.KeyCode = Keys.Escape Then
            '    If tblhelp.Visible = True Then
            '        tblhelp.Visible = False
            '    End If

            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblhelp1_bloque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                Me.tblhelp1_bloque_DoubleClick(Nothing, Nothing)

            ElseIf e.KeyCode = Keys.Escape Then
                'If tblhelp1_bloque.Visible = True Then
                '    tblhelp1_bloque.Visible = False
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
            '   GrRegistrarBloque.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Libro102INVBAL()

        Dim folderBrowserDialog1 As New FolderBrowserDialog()
        folderBrowserDialog1.Description = "Seleccionar Carpeta para Guardar Archivos"
        folderBrowserDialog1.ShowNewFolderButton = True
        If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim folderPath As String = folderBrowserDialog1.SelectedPath

        Else
            Return

        End If

        Dim FlagtieneRegistros As String
        Dim nombredearchivo As String = ""
        Dim dia As String
        'DATATABLE'
        Dim dt As New DataSet
        dt = objSql.TraerDataSet("Spu_Con_Exp_lc102RegCosCostoMensual", gbcodempresa, gbano, gbmes)
        '======
        If dt.Tables(0).Rows.Count > 0 Then
            FlagtieneRegistros = "1"
        Else
            FlagtieneRegistros = "0"
        End If
        '==

        Try
            '  Dim valorcboCodOportunidadEEFF As String = DirectCast(cboCodOportunidadEEFF.SelectedItem, DataRowView)("glo01codigo").ToString()
            Dim strStreamWriter As StreamWriter
            nombredearchivo = nombredearchivo + ".txt"
            dia = Funciones.Funciones.NumeroDiasMes(gbmes, gbano) ' Ojo siempre se asume que es el ultimo dia del mes
            nombredearchivo = Funciones.Funciones.NombreLibroelectronico("100200", gbRucEmpresa, gbano, gbmes, "00", "07", FlagtieneRegistros, "S")
            nombredearchivo = nombredearchivo + ".txt"

            Dim selectedFolder As String = folderBrowserDialog1.SelectedPath

            Dim FilePath As String = Path.Combine(selectedFolder, nombredearchivo)

            Dim campo_01 As String = ""
            Dim campo_02 As String = ""
            Dim campo_03 As String = ""
            Dim campo_04 As String = ""
            Dim campo_05 As String = ""
            Dim campo_06 As String = ""
            Dim campo_07 As String = ""
            Dim campo_08 As String = ""

            Using sw As StreamWriter = New StreamWriter(FilePath)
                ' Escribir contenido en el archivo
                Dim dr As DataRow

                For Each dr In dt.Tables(0).Rows

                    'Obtenemos los datos del dataset
                    campo_01 = dr("Periodo").ToString
                    campo_02 = dr("Costo_Materiales").ToString
                    campo_03 = dr("CostoManoObaDirecta").ToString
                    campo_04 = dr("Otros_CostosDirectos").ToString
                    campo_05 = dr("GastosProduccionIndirecto_MatSuministros").ToString
                    campo_06 = dr("GastosProduccionIndirecto_ManoObraDirecta").ToString
                    campo_07 = dr("Otros_GastosProduccionIndirecto").ToString
                    campo_08 = dr("Estado_Operacion").ToString


                    Dim linea As String = ""
                    linea = campo_01 & Chr(124) & campo_02 & Chr(124) & campo_03 & Chr(124) & campo_04 & Chr(124) & campo_05 & Chr(124) & campo_06 & Chr(124) & campo_07 & Chr(124) & campo_08 & Chr(124)


                    'Escribimos la línea en el achivo de texto
                    sw.WriteLine(linea)
                Next

                'sw.WriteLine("Hola, este es un ejemplo de contenido.")
                MsgBox("EXITO :: El archivo se exporto correctamente", MsgBoxStyle.Information, "Mensaje")
                'sw.WriteLine("Puedes escribir tus propios datos aquí.")
            End Using
            'Poner cursor en modo espera
            Cursor.Current = Cursors.WaitCursor



            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'strStreamWriter.Close()
            Cursor.Current = Cursors.Default
            MsgBox("ERROR:: Hubo un problema al generar el libro 3.1")
            Return
        End Try

    End Sub
    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Libro102INVBAL()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btvistaprevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.imprimir_verant("P")
        Catch ex As Exception

        End Try
    End Sub
    Sub imprimir_verant(ByVal flagimpresion As String)
        Dim objR As New KS.Com.Win.CystalReports.Net.File
        Dim ds As System.Data.DataSet
        Dim arrFormulas As New List(Of KS.Com.Win.CystalReports.Net.FormulasReportes)
        Dim flagtiporeporte As String
        Dim nombredereporte As String
        Dim Rutareporte As String
        Dim mesdeRegRetencion As String
        Dim flagtipoimpresion As String
        Dim tipanlisiregretencion As String

        ' mesdeRegRetencion = Funciones.Funciones.derecha(cboperiodos.SelectedValue.ToString, 2)
        'LLeno el rango de valores
        Try

            Rutareporte = gbRutaReportes()

            Cursor.Current = Cursors.WaitCursor
            '=========Inserto Filas seleecionadas
            flagtiporeporte = "REGRET1"
            'Inserto los valores selecioandos
            'If tblconsulta.SelectedRows.Count > 0 Then
            '    Mod_Mantenimiento.InsertarFilasSelecionadas(flagtiporeporte, tblconsulta, tblconsulta.Columns(0).DataField)
            'Else
            '    MessageBox.Show("AVISO :: No selecciono registros para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            'End If


            nombredereporte = "Rep_LibLegCosto102.Rpt"


            ' flagtipoimpresion = If(optTipoImpre_0.Checked = True, "P", "F")
            '   tipanlisiregretencion = cboTipoAnalisi.SelectedValue.ToString

            ds = objSql.TraerDataSet("Spu_Con_Rep_lc102RegCosCostoMensual", gbcodempresa, gbano).Copy()



            'Formulas de reporte
            '  arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("NombreEmpresa", gbNomEmpresa))
            ' arrFormulas.Add(New Ks.Com.Win.CystalReports.Net.FormulasReportes("Titulo", "Libro de Retenciones inciso e) y f) del Art. 34° de la LIR"))
            arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Periodo", gbano + gbmes))
            ' arrFormulas.Add(New KS.Com.Win.CystalReports.Net.FormulasReportes("Pagina", ""))



            'Visualizar reportes
            'If flagimpresion = "P" Then
            '    objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            'Else
            objR.VistaPrevia(Rutareporte, nombredereporte, ds.Tables(0), Nothing, arrFormulas, enmWindowState.Maximizado)
            'End If

            'Elimnar rango de impresion
            '  Mod_BaseDatos.EliminaRangoImpresion(flagtiporeporte)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("ERROR :: Ocurrio un error al mostrar el reporte" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Insertar_Bloque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    InsertarLibro_Bloque()
        'Catch ex As Exception

        'End Try
    End Sub
    Sub InsertarLibro_Bloque()
        Try
            Dim registrosSeleccionados As New List(Of String)()
            Dim contador As Integer = 0
            Dim xmlCadena As String = ""
            Dim PrimerRecorido As Boolean = True
            Dim numeroConvertido As Integer = 0
            Dim ResultadoVoucher As String = ""
            Dim j As Integer = 0
                Dim dataTable As DataTable = DirectCast(tblconsulta.DataSource, DataTable)
            For Each filaSeleccionada In dataTable.Rows


                Dim registro As String = filaSeleccionada("lc102Correlativo").ToString() & "|" &
                                  filaSeleccionada("lc102Descripcion").ToString() & "|" &
                                  filaSeleccionada("lc102CtaCble").ToString() & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_01")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_02")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_03")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_04")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_05")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_06")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_07")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_08")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_09")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_10")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_11")) & "|" &
                                  Convert.ToDecimal(filaSeleccionada("lc102Importe_12"))

                registrosSeleccionados.Add(registro)



            Next


            xmlCadena = Funciones.Funciones.ConvertiraXMLdinamico(registrosSeleccionados)
            Dim dt As Array = objSql.Ejecutar2("Spu_Con_Ins_lc102RegCosCostoMensual_XML", gbcodempresa, gbano, xmlCadena, "")
            If Funciones.Funciones.MensajesdelSQl(dt) = True Then
                ' Me.Posicionar("co07ITEM", txtCodigo.Text.Trim, tblconsulta, Vista)

                Frm_RegistrarLib102CostoMensual_Load(Nothing, Nothing)
            Else
                'No hago nada
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnimportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimportar.Click
        Try
            Me.TraerAyuda(0, "", btn_help0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Traeimportacion()
        Try
            Vista = objSql.TraerDataTable("[Spu_Con_Trae_lc102RegCosCostoMensualxanio]", gbcodempresa).DefaultView
            tblhelp_0.SetDataBinding(Vista, Nothing, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblhelp_0_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblhelp_0.DoubleClick
        Dim indice As Integer
        indice = CType(tblhelp_0.Tag, Integer)
        Try
            If tblhelp_0.RowCount < 1 Then Exit Sub
            Me.AsignarAyuda(indice, tblhelp_0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tblhelp_0_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblhelp_0.KeyDown
        Try
            If tblhelp_0.Visible = True Then
                If e.KeyCode = Keys.Escape Then
                    tblhelp_0.Visible = False
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                tblhelp_0_DoubleClick(Nothing, Nothing)
                tblhelp_0.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Try
            Me.modificar()
        Catch ex As Exception

        End Try
    
    End Sub
    Sub modificar()
        Try
            Me.accionMante = "M"
            Me.HabilitarMantenimiento(True)
            ' txtDescri.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub HabilitarMantenimiento(ByVal valor As Boolean)
        Try
            'LLamar a la habiltacion global
            '   Mod_Mantenimiento.HabyDesControles(Me, valor)
            'Perosnalizar habilitacion
            ' btnnuevo.Visible = Not valor
            btnmodificar.Visible = Not valor
            '  btneliminar.Visible = Not valor
            btnsalir.Visible = Not valor
            tblconsulta.Enabled = valor
            btnimportar.Visible = Not valor
            btngrabar.Visible = valor
            btncancelar.Visible = valor

            'los campos que no deben modificar, 
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btngrabar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            InsertarLibro_Bloque()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Try
            Frm_RegistrarLib102CostoMensual_Load(Nothing, Nothing)
            Me.HabilitarMantenimiento(False)
        Catch ex As Exception

        End Try
    End Sub
End Class