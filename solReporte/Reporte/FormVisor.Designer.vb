Namespace Ks.Com.Win.CystalReports.Net.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FormVisor
        Inherits System.Windows.Forms.Form

        'Form reemplaza a Dispose para limpiar la lista de componentes.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Requerido por el Diseñador de Windows Forms
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        'Se puede modificar usando el Diseñador de Windows Forms.  
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer
            Me.SuspendLayout()
            '
            'crv
            '
            Me.crv.ActiveViewIndex = -1
            Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.crv.Dock = System.Windows.Forms.DockStyle.Fill
            Me.crv.Location = New System.Drawing.Point(0, 0)
            Me.crv.Name = "crv"
            Me.crv.SelectionFormula = ""
            Me.crv.Size = New System.Drawing.Size(671, 421)
            Me.crv.TabIndex = 0
            Me.crv.ViewTimeSelectionFormula = ""
            '
            'FormVisor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(671, 421)
            Me.Controls.Add(Me.crv)
            Me.Name = "FormVisor"
            Me.Text = "Reporte"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer

    End Class
End Namespace