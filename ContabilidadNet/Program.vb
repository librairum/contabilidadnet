Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports System.IO

Module Program
    Public Sub Main()
        Dim configuracion As ActualizacionSistema = New ActualizacionSistema()
        If configuracion.EsModoActualiza() = True Then
            Application.Run(New frmSplash())
        Else
            'Application.Run(New Frm_Login())
            Application.Run(New MDIPrincipal())
        End If
    End Sub

End Module
