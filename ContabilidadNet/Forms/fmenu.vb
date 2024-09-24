Public Class fmenu
    Private Sub OnclickMenuitem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        MessageBox.Show(item.Text)
    End Sub
    Private Sub fmenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim menu As New MenuStrip
        Dim menu_item As ToolStripMenuItem = Nothing
        Dim menu_subitem As ToolStripMenuItem = Nothing
        Dim menu_separator As ToolStripSeparator = Nothing
        '
        menu.Parent = Me
        menu_item = New ToolStripMenuItem("item1", Nothing, AddressOf OnclickMenuitem, "Nombre")
        '
        menu.Items.Add(menu_item)

    End Sub
End Class