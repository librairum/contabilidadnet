Imports System.IO
Public Class Frm_Voucher_ImportarCajas
#Region "Region"
    Private Function conexionaexcel(ByVal ruta As String) As DataTable
        'Crear la cadena de conexion
        Dim sql As String
        'Dim cad_con_excel As String = "Provider=Microsoft.Jet.OLEDB.4.0; Extended Properties='Excel 8.0';Data Source=" + ruta
        Dim cad_con_excel As String = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml;HDR=No';Data Source=" + ruta
        Dim obj_con_excel As New OleDb.OleDbConnection(cad_con_excel)
        sql = "SELECT f1,f2,f3,f4,f5,f6,f7,f8,f9,f10,f11,f12,f13,f14,f15,f16,f17,f18,f19,f20 FROM [Hoja1$]"
        Dim obj_dataadapter As New OleDb.OleDbDataAdapter(sql, obj_con_excel)
        Dim obj_datatable As New DataTable("Hoja1")
        obj_dataadapter.Fill(obj_datatable)

        Return obj_datatable
    End Function

#End Region
#Region "Region"
    Private Sub inicioControlesDiseno()
        'Formulario
        Me.Text = ""
        'Grilla princiapal
        Mod_Mantenimiento.Formatodegrilla(tblconsulta)
        tblconsulta.ColumnFooters = False
        'Grilla de la ayuda
        tblhelp.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
        Me.tblhelp.FilterBar = True
        Me.tblhelp.AllowFilter = True
        '
        Mod_Mantenimiento.tooltiptext(btncancelar, gbc_Ttp_Cancelar)
    End Sub

#End Region
#Region "Variables"
    Dim Vista As New DataView
    Private FilaDeTabla As DataRowView
    Dim filaactual As Integer
    Dim VistaHelp As DataView
    Dim flag As String
#End Region

#Region "Ayuda"
    Sub TraeLibros()
        Try
            VistaHelp = objSql.TraerDataTable("sp_Con_Help_Libros_Todos", gbcodempresa, gbano, "", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub traecuenta(ByVal query As String)
        Try
            VistaHelp = objSql.TraerDataTable(query, gbcodempresa, gbano, "*", "*").DefaultView
            tblhelp.SetDataBinding(VistaHelp, Nothing, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraerAyuda(ByVal index As Integer, ByVal boton As Button)
        Dim x, y As Integer
        'Muestro el Help
        Try
            x = boton.Location.X + 20 'Tamaño de boton + 20
            y = boton.Location.Y      'La misma latura del boton 

            tblhelp.Location = New Point(x, y)

            '
            Dim columna2 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna2 = tblhelp.Columns(2)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            Dim columna3 As C1.Win.C1TrueDBGrid.C1DataColumn
            columna3 = tblhelp.Columns(3)
            tblhelp.Splits(0).DisplayColumns(columna2).Width = 0

            Mod_Mantenimiento.LimpiarFiltro(tblhelp)

            tblhelp.Columns(0).Caption = "Código"
            tblhelp.Columns(1).Caption = "Descripción"



            Select Case index
                Case 0
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()
                Case 1
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.traecuenta("sp_Con_Help_Cuentas_HabYMov")
                    txtCuentaprov.Focus()
                Case 2
                    tblhelp.Columns(0).DataField = "ccb02cod"
                    tblhelp.Columns(1).DataField = "ccb02des"
                    Me.TraeLibros()

                Case 3
                    tblhelp.Columns(0).DataField = "ccm01cta"
                    tblhelp.Columns(1).DataField = "ccm01des"
                    tblhelp.Columns(2).DataField = "ccm01mov"
                    Me.traecuenta("sp_Con_Help_Cuentas_HabYMov")
            End Select

            tblhelp.Tag = index.ToString
            tblhelp.Refresh()
            tblhelp.Visible = True
            tblhelp.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub TraeDameDescripcion(ByVal indice As Integer)
        Try
            Select Case indice
                Case 0
                    If txtlibroproveedores.Text = "" Then
                        lblhelp_0.Text = ""
                    Else
                        lblhelp_0.Text = Mod_BaseDatos.DameDescripcion(gbano + txtlibroproveedores.Text, "LI")
                    End If

                Case 1
                    If txtCuentaprov.Text = "" Then
                        lblhelp_1.Text = ""
                    Else
                        lblhelp_1.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuentaprov.Text, "C3")
                    End If

                Case 2
                    If txtlibrocaja.Text = "" Then
                        lblhelp_2.Text = ""
                    Else
                        lblhelp_2.Text = Mod_BaseDatos.DameDescripcion(gbano + txtlibrocaja.Text, "LI")
                    End If

                Case 3
                    If txtCuentacaja.Text = "" Then
                        lblhelp_3.Text = ""
                    Else
                        lblhelp_3.Text = Mod_BaseDatos.DameDescripcion(gbano + txtCuentacaja.Text, "C3")
                    End If

            End Select

            'VistaHelp.Dispose()
            'tblhelp.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub AsignarAyuda(ByVal indice As Integer, ByVal tblhelp_p As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Select Case indice
                Case 0
                    txtlibroproveedores.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_0.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtlibroproveedores.Focus()

                Case 1
                    If tblhelp_p.Columns("ccm01mov").Value.ToString = "S" Then
                        txtCuentaprov.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                        lblhelp_1.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                        txtCuentaprov.Focus()
                    Else
                        txtCuentaprov.Text = ""
                        lblhelp_1.Text = ""
                        MessageBox.Show("AVISO :: La Cuenta no es de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCuentaprov.Focus()
                    End If
                Case 2
                    txtlibrocaja.Text = tblhelp_p.Columns("ccb02cod").Value.ToString
                    lblhelp_2.Text = tblhelp_p.Columns("ccb02des").Value.ToString
                    txtlibrocaja.Focus()
                Case 3
                    If tblhelp_p.Columns("ccm01mov").Value.ToString = "S" Then
                        txtCuentacaja.Text = tblhelp_p.Columns("ccm01cta").Value.ToString
                        lblhelp_3.Text = tblhelp_p.Columns("ccm01des").Value.ToString
                        txtCuentacaja.Focus()
                    Else
                        txtCuentacaja.Text = ""
                        lblhelp_3.Text = ""
                        MessageBox.Show("AVISO :: La Cuenta no es de movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCuentacaja.Focus()
                    End If
            End Select

            VistaHelp.Dispose()
            tblhelp_p.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub traeImportacion()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_Voucher_importar", gbcodempresa, gbNameUser).DefaultView
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
    Private Sub traevouchergerados(ByVal libro_proveedores As String, ByVal libro_caja As String, ByVal voucher_proveedoresNum As String, ByVal voucher_CajaNum As String, ByVal cuenta_Proveedores As String, ByVal cuenta_caja As String, ByVal flag As String)
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_VoucherCaja", gbcodempresa, gbano, gbmes, libro_proveedores, libro_caja, voucher_proveedoresNum, voucher_CajaNum, cuenta_Proveedores, cuenta_caja, gbNameUser, flag).DefaultView
            tblgeneravoucher.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '
            Me.tblgeneravoucher.Columns(0).FooterText = "# Registros"
            Me.tblgeneravoucher.Columns(1).FooterText = tblgeneravoucher.RowCount.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ValidarImpVoucher()
        Try
            Vista = objSql.TraerDataTable("Spu_Con_Trae_ValImpVoucher", gbcodempresa, gbano, gbmes, "", "IC").DefaultView
            tblvalidacion.SetDataBinding(Vista, Nothing, True)
            '
            Me.capturarfilaactual()
            '
            Me.tblvalidacion.Columns(0).FooterText = "# Registros"
            Me.tblvalidacion.Columns(1).FooterText = tblvalidacion.RowCount.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub capturarfilaactual()
        Try
            filaactual = Me.BindingContext(Vista).Position '
            FilaDeTabla = Vista.Table.DefaultView.Item(filaactual)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ImportarArchivo()
        Dim openFD As New OpenFileDialog()
        Dim FilePath As String
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim nombredearchivo As String = ""
        Dim rutadearchivo As String = ""
        Dim myStream As Stream

        'Declarar campos
        Dim f1 As String
        Dim f2 As String
        Dim f3 As String
        Dim f4 As String
        Dim f5 As String
        Dim f6 As String
        Dim f7 As String
        Dim f8 As String
        Dim f9 As String
        Dim f10 As String
        Dim f11 As String
        Dim f12 As String
        Dim f13 As String
        Dim f14 As String
        Dim f15 As String
        Dim f16 As String
        Dim f17 As String
        Dim f18 As String
        Dim f19 As String
        Dim f20 As String


        Dim nRegistro As Integer

        Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
        Dim b As Array = Array.CreateInstance(GetType(Object), 2, 10)

        'Limpiar grilla
        tblconsulta.DataSource = Nothing
        tblvalidacion.DataSource = Nothing
        tblgeneravoucher.DataSource = Nothing

        With openFD
            .Title = "Seleccionar Archivos a importar"
            .Filter = "Todos los archivos (*.*)|*.*|(*.xls)|*.xlsx|(*.csv)|*.csv"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.CurrentDirectory
            .InitialDirectory = ""
        End With

        If openFD.ShowDialog() = DialogResult.OK Then
            myStream = openFD.OpenFile()
            If (myStream IsNot Nothing) Then
                'Code to write the stream goes here.
                nombredearchivo = CType(myStream, System.IO.FileStream).Name
                myStream.Close()
            End If
        End If

        FilePath = nombredearchivo
        If nombredearchivo = "" Then Exit Sub
        'Eliminar filas insertadas
        b = objSql.Ejecutar2("Spu_Con_Del_TablaParaImportar", gbcodempresa, gbNameUser, flag)


        Try
            'Trae detalle de asiento tipo
            Dim tablaDet As DataTable
            tablaDet = conexionaexcel(nombredearchivo)
            tblconsulta.DataSource = tablaDet

            'Recorrro la tabla traido y le actualizo los valores calculados segun las formulas
            For Each row As DataRow In tablaDet.Rows
                '===
                f1 = ""
                f2 = ""
                f3 = ""
                f4 = ""
                f5 = ""
                f6 = ""
                f7 = ""
                f8 = ""
                f9 = ""
                f10 = ""
                f11 = ""
                f12 = ""
                f13 = ""
                f14 = ""
                f15 = ""
                f16 = ""
                f17 = ""
                f18 = ""
                f19 = ""
                f20 = ""
                '====
                f1 = row("f1").ToString()
                f2 = row("f2").ToString()
                f3 = row("f3").ToString()
                f4 = row("f4").ToString()
                f5 = row("f5").ToString()
                f6 = row("f6").ToString()
                f7 = row("f7").ToString()
                f8 = row("f8").ToString()
                f9 = row("f9").ToString()
                f10 = row("f10").ToString()
                f11 = row("f11").ToString()
                f12 = row("f12").ToString()
                f13 = row("f13").ToString()
                f14 = row("f14").ToString()
                f15 = row("f15").ToString()
                f16 = row("f16").ToString()
                f17 = row("f17").ToString()
                f18 = row("f18").ToString()
                f19 = row("f19").ToString()
                f20 = row("f20").ToString()

                a = objSql.Ejecutar2("Spu_Con_Ins_TablaParaImportar", gbcodempresa, gbNameUser, flag, f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, "")
                nRegistro = nRegistro + 1
            Next

            'Muestro mensaje
            MessageBox.Show("OK :: Se importaron " + nRegistro.ToString() + "   Registros   ")

            'Trae datos insertados
            ' Me.traeImportacion()
            '
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Me.ImportarArchivo()
    End Sub
    Private Sub btnvalidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvalidar.Click
        grbvalidaciones.Visible = False
        Me.ValidarImpVoucher()
        grbvalidaciones.Visible = True
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub btngrabavoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabavoucher.Click
        Try
            'Validar los datos ue se importo
            Me.ValidarImpVoucher()
            '
            If tblvalidacion.RowCount > 0 Then
                grbvalidaciones.Visible = True
                MsgBox("ERROR :: Corriga las validaciones de la importacion") : Exit Sub
            Else

                If MsgBox("Esta seguro de generar voucher SI/NO", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then Exit Sub
            End If


            'Si todo Ok
            Dim a As Array = Array.CreateInstance(GetType(Object), 2, 10)
            Cursor.Current = Cursors.WaitCursor
            a = objSql.Ejecutar2("Spu_Con_Ins_VoucherImpCaja", gbcodempresa, gbano, gbmes, "", "")
            '
            Funciones.Funciones.MensajesdelSQl(a)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Btngenerarvoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btngenerarvoucher.Click
        'Capturar y pasar los datos
        'Validar los datos
        Dim libro_proveedores As String
        Dim libro_caja As String
        Dim voucher_proveedoresNum As String
        Dim voucher_CajaNum As String
        Dim cuenta_Proveedores As String
        Dim cuenta_caja As String

        'Validar
        If (lblhelp_0.Text = "" Or lblhelp_0.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Libro no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtlibroproveedores.Focus() : Exit Sub
        If (lblhelp_1.Text = "" Or lblhelp_1.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Cuenta no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCuentaprov.Focus() : Exit Sub
        'If (lblhelp_2.Text = "" Or lblhelp_2.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Libro no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtlibrocaja.Focus() : Exit Sub
        'If (lblhelp_3.Text = "" Or lblhelp_3.Text = "???") Then Beep() : MessageBox.Show("VALIDACION :: Cuenta no Valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCuentacaja.Focus() : Exit Sub

        libro_proveedores = txtlibroproveedores.Text
        libro_caja = txtlibrocaja.Text
        voucher_proveedoresNum = txtNoVoucherprov.Text
        voucher_CajaNum = txtNoVouchercaja.Text
        cuenta_Proveedores = txtCuentaprov.Text
        cuenta_caja = txtCuentacaja.Text

        'Validar
        Me.traevouchergerados(libro_proveedores, libro_caja, voucher_proveedoresNum, voucher_CajaNum, cuenta_Proveedores, cuenta_caja, flag)

    End Sub

    Private Sub btnhelp_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_0.Click
        Me.TraerAyuda(0, btnhelp_0)
    End Sub

    Private Sub btnhelp_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhelp_1.Click
        Me.TraerAyuda(1, btnhelp_1)
    End Sub

    Private Sub btnhelp_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TraerAyuda(2, btnhelp_2)
    End Sub

    Private Sub btnhelp_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TraerAyuda(3, btnhelp_3)
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

    Private Sub txtlibroproveedores_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlibroproveedores.LostFocus
        'Traer Ayuda
        Me.TraeDameDescripcion(0)
    End Sub
    Private Sub Frm_Voucher_ImportarCajas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            inicioControlesDiseno()
            '
            Mod_Mantenimiento.formatearformulario(Me)
            Mod_Mantenimiento.Centrar(Me)
            '
            Me.Text = "Importar y Generar voucher de Provvedores y Caja"
            '
            txtlibroproveedores.Text = "06"
            Me.TraeDameDescripcion(0)
            txtCuentaprov.Text = "4211101"
            Me.TraeDameDescripcion(1)
            txtNoVoucherprov.Text = "PA"
            '
            txtlibrocaja.Text = "01"
            Me.TraeDameDescripcion(2)
            txtCuentacaja.Text = "1011201"
            Me.TraeDameDescripcion(3)
            txtNoVouchercaja.Text = "CH"
            '
            flag = "EXCELCAJA"
            grbvalidaciones.Visible = False
            grbdatosvouchercaja.Visible = False
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btncancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar1.Click
        grbvalidaciones.Visible = False
    End Sub
End Class