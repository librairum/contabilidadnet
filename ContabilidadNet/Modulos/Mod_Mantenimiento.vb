Module Mod_Mantenimiento
    Sub HabyDesControles(ByVal f As Control, ByVal valor As Boolean)
        Try
            'Botones de ayuda
            For Each ctlControl As Control In f.Controls
                'Botones
                If TypeOf ctlControl Is Button Then
                    'CType(ctlControl, System.Windows.Forms.Button).Enabled = valor
                    If CType(ctlControl, System.Windows.Forms.Button).Name.Substring(0, 7).ToString.ToUpper = "btnhelp".ToUpper Then
                        CType(ctlControl, System.Windows.Forms.Button).Enabled = valor
                    End If
                    'textbox
                ElseIf TypeOf ctlControl Is TextBox Then
                    CType(ctlControl, System.Windows.Forms.TextBox).ReadOnly = Not valor
                ElseIf TypeOf ctlControl Is CheckBox Then
                    CType(ctlControl, System.Windows.Forms.CheckBox).Enabled = valor
                ElseIf TypeOf ctlControl Is RadioButton Then
                    CType(ctlControl, System.Windows.Forms.RadioButton).Enabled = valor
                    'controles dentro de panel's
                ElseIf TypeOf ctlControl Is MaskedTextBox Then
                    CType(ctlControl, System.Windows.Forms.MaskedTextBox).ReadOnly = Not valor
                ElseIf TypeOf ctlControl Is ComboBox Then
                    CType(ctlControl, System.Windows.Forms.ComboBox).Enabled = valor
                    'controles dentro de panel's
                ElseIf TypeOf ctlControl Is Panel Then
                    HabyDesControles(CType(ctlControl, System.Windows.Forms.Panel), valor)
                    'controles dentro de Group box
                ElseIf TypeOf ctlControl Is GroupBox Then
                    HabyDesControles(CType(ctlControl, System.Windows.Forms.GroupBox), valor)
                    'controles dentro de Tab's
                ElseIf TypeOf ctlControl Is TabControl Then
                    HabyDesControles(CType(ctlControl, System.Windows.Forms.TabControl), valor)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LimpiarControles(ByVal f As Control)
        Try

            'Limpiar 
            For Each ctlControl In f.Controls
                'Si es texto
                If TypeOf ctlControl Is TextBox Then
                    CType(ctlControl, System.Windows.Forms.TextBox).Text = ""
                    'Si es label
                ElseIf TypeOf ctlControl Is ComboBox Then
                    CType(ctlControl, System.Windows.Forms.ComboBox).Text = ""
                ElseIf TypeOf ctlControl Is MaskedTextBox Then
                    CType(ctlControl, System.Windows.Forms.MaskedTextBox).Text = ""
                ElseIf TypeOf ctlControl Is CheckBox Then
                    CType(ctlControl, System.Windows.Forms.CheckBox).Checked = False
                ElseIf TypeOf ctlControl Is RadioButton Then
                    CType(ctlControl, System.Windows.Forms.RadioButton).Checked = False
                ElseIf TypeOf ctlControl Is Label Then
                    'Se verificac que es mayor que 7 por que cuando la longitud del nombre del label es menor,sale un error de indice
                    If CType(ctlControl, System.Windows.Forms.Label).Name.Length >= 7 Then
                        If CType(ctlControl, System.Windows.Forms.Label).Name.Substring(0, 7).ToString.ToUpper = "lblhelp".ToUpper Then
                            CType(ctlControl, System.Windows.Forms.Label).Text = "???"
                        End If
                    End If
                ElseIf TypeOf ctlControl Is Panel Then
                    LimpiarControles(CType(ctlControl, System.Windows.Forms.Panel))
                ElseIf TypeOf ctlControl Is GroupBox Then
                    LimpiarControles(CType(ctlControl, System.Windows.Forms.GroupBox))
                ElseIf TypeOf ctlControl Is TabControl Then
                    LimpiarControles(CType(ctlControl, System.Windows.Forms.TabControl))
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LimpiarFiltro(ByVal grilla As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try

            For Each Col In grilla.Columns
                Col.FilterText = ""
            Next Col
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub InsertarFilas(ByVal flag As String, ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Nombrecampo As String)

        Dim valor As String
        Dim i As Integer

        Try
            If tbl.RowCount > 0 Then
                'For Each row As Integer In tbl.Rows
                For i = 1 To tbl.RowCount
                    valor = tbl.Columns(Nombrecampo).CellValue(i).ToString
                    'Llamamr al Sp que inserta fila
                    Mod_BaseDatos.InsertaRangoImpresion(flag, valor)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub seleccionartodaslasfilasdelagrilla(ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim i As Integer
        '
        Try
            For i = 0 To tbl.RowCount
                tbl.SelectedRows.Add(i)
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub seleccionartodaslasfilasdelagrilla_sinfiladefiltro(ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim i As Integer
        '
        Try
            tbl.SelectedRows.Clear()

            For i = 1 To tbl.RowCount
                tbl.SelectedRows.Add(i)
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub InsertarFilasSelecionadas(ByVal flag As String, ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Nombrecampo As String)
        Dim valor As String
        Try
            If tbl.SelectedRows.Count > 0 Then
                For Each row As Integer In tbl.SelectedRows
                    valor = tbl.Columns(Nombrecampo).CellValue(row).ToString
                    'Llamar al Sp que inserta fila
                    If valor.ToString.Trim <> "" Then
                        Mod_BaseDatos.InsertaRangoImpresion(flag, valor)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub InsertarFilasSelecionadas2(ByVal flag As String, ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Nombrecampo1 As String, ByVal Nombrecampo2 As String)
        Dim valor As String
        Dim valor2 As String
        Dim valortotal As String
        Try
            If tbl.SelectedRows.Count > 0 Then
                For Each row As Integer In tbl.SelectedRows
                    valor = tbl.Columns(Nombrecampo1).CellValue(row).ToString
                    valor2 = tbl.Columns(Nombrecampo2).CellValue(row).ToString
                    valortotal = gbano + gbmes + valor + valor2
                    'Llamar al Sp que inserta fila
                    If valor.ToString.Trim <> "" Then
                        Mod_BaseDatos.InsertaRangoImpresion(flag, valortotal)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub InsertarFilasSelecionadas2col(ByVal flag As String, ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Nombrecampo As String, ByVal Nombrecampo2 As String)
        Dim valor1 As String
        Dim valor2 As String
        Dim valor As String
        Try
            If tbl.SelectedRows.Count > 0 Then
                For Each row As Integer In tbl.SelectedRows
                    'valor = tbl.Columns(Nombrecampo).CellValue(row)
                    valor = ""
                    valor1 = ""
                    valor2 = ""

                    valor1 = tbl.Columns(Nombrecampo).CellValue(row).ToString
                    valor2 = tbl.Columns(Nombrecampo2).CellValue(row).ToString
                    valor = valor1 + valor2
                    'Llamamr al Sp que inserta fila
                    Mod_BaseDatos.InsertaRangoImpresion(flag, valor)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub InsertarFilasSelecionadasmasvalor(ByVal flag As String, ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Nombrecampo As String, ByVal otrovalor As String)
        Dim valor As String
        Try
            If tbl.SelectedRows.Count > 0 Then
                For Each row As Integer In tbl.SelectedRows
                    valor = otrovalor.Trim + tbl.Columns(Nombrecampo).CellValue(row).ToString
                    'Llamamr al Sp que inserta fila
                    Mod_BaseDatos.InsertaRangoImpresion(flag, valor)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function Periodocerrado() As Boolean
        Try
            Periodocerrado = False
            If gbflagestadoperiodo = "0" Then ' Si el periodo esta cerrado
                Periodocerrado = True
            Else
                Periodocerrado = False
            End If
        Catch ex As Exception
            Periodocerrado = True
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Sub Centrar(ByVal Objeto As Object)
        ' Centrar un Formulario ...
        If TypeOf Objeto Is Form Then
            Dim frm As Form = CType(Objeto, Form)

            With Screen.PrimaryScreen.WorkingArea ' Dimensiones de la pantalla sin el TaskBar
                frm.Top = (.Height - frm.Height) \ 2
                frm.Left = (.Width - frm.Width) \ 2
            End With

            ' Centrar un control dentro del contenedor
        Else
            ' referencia al control
            Dim c As Control = CType(Objeto, Control)

            'le  establece el top y el Left dentro del Parent
            With c
                .Top = (.Parent.ClientSize.Height - c.Height) \ 2
                .Left = (.Parent.ClientSize.Width - c.Width) \ 2
            End With
        End If
    End Sub

    Public Sub formatearformulario(ByVal form As Form)
        form.MinimizeBox = False
        form.MaximizeBox = False
    End Sub
    Public Sub ocultarbotonespercerrado(ByVal formulario As Control)
        Try
            If Periodocerrado() = True Then
                For Each ctlControl In formulario.Controls
                    'Si es texto
                    If TypeOf ctlControl Is Button Then
                        If CType(ctlControl, System.Windows.Forms.Button).Name.ToUpper = "BTNNUEVO" Or _
                            CType(ctlControl, System.Windows.Forms.Button).Name.ToUpper = "BTNMODIFICAR" Or _
                            CType(ctlControl, System.Windows.Forms.Button).Name.ToUpper = "BTNINSERTAR" Or _
                            CType(ctlControl, System.Windows.Forms.Button).Name.ToUpper = "BTNELIMINAR" Then

                            CType(ctlControl, System.Windows.Forms.Button).Visible = False

                        End If
                        'Si los botones estan dentro de un panel tamnien los encuentra
                    ElseIf TypeOf ctlControl Is Panel Then
                        ocultarbotonespercerrado(CType(ctlControl, System.Windows.Forms.Panel))
                    ElseIf TypeOf ctlControl Is GroupBox Then
                        ocultarbotonespercerrado(CType(ctlControl, System.Windows.Forms.GroupBox))
                    ElseIf TypeOf ctlControl Is TabControl Then
                        ocultarbotonespercerrado(CType(ctlControl, System.Windows.Forms.TabControl))
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub EsquinaSuperiorIzquierda(ByVal Objeto As Object)
        ' Centrar un Formulario ...
        If TypeOf Objeto Is Form Then
            Dim frm As Form = CType(Objeto, Form)

            With Screen.PrimaryScreen.WorkingArea ' Dimensiones de la pantalla sin el TaskBar
                frm.Top = 0 '(.Height - frm.Height) \ 2
                frm.Left = 0 '(.Width - frm.Width) \ 2
            End With

            ' Centrar un control dentro del contenedor
        Else
            ' referencia al control
            Dim c As Control = CType(Objeto, Control)

            'le  establece el top y el Left dentro del Parent
            With c
                .Top = 0 '(.Parent.ClientSize.Height - c.Height) \ 2
                .Left = 0 '(.Parent.ClientSize.Width - c.Width) \ 2
            End With
        End If
    End Sub
    Public Sub tooltiptext(ByVal control As Button, ByVal texto As String)
        MDIPrincipal.ToolTip.SetToolTip(control, texto)
    End Sub

    Public Sub sombrearcontrol(ByVal control As MaskedTextBox)
        control.SelectionStart = 0
        control.SelectionLength = Len(control.Text)
        If control.ReadOnly = False Then
            control.BackColor = Color.Orange
        End If
    End Sub
    Public Sub Dessombrearcontrol(ByVal control As MaskedTextBox)
        'control.SelectionStart = 0
        'control.SelectionLength = Len(control.Text)
        'If control.ReadOnly = False Then
        control.BackColor = Color.White
        'End If
    End Sub
    Sub Formatodegrilla(ByVal tbl As C1.Win.C1TrueDBGrid.C1TrueDBGrid)

        tbl.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
        tbl.FilterBar = True
        tbl.AllowFilter = True
        tbl.ColumnFooters = True

        tbl.Splits(0).FooterStyle.BackColor = System.Drawing.SystemColors.Control
    End Sub

End Module
