
Partial Class MasterPage_main
    Inherits System.Web.UI.MasterPage

    Protected Sub mainMenu_MenuItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles mainMenu.MenuItemDataBound
        'Dim MainMenu As Menu = DirectCast(sender, Menu)
        'Dim ItemToRemove As MenuItem = MainMenu.FindItem(MapNode.Title)
        Dim MapNode As SiteMapNode = DirectCast(e.Item.DataItem, SiteMapNode)

        If MapNode.Title = "Product Review-QC" OrElse MapNode.Title = "Product Review-QA" _
            OrElse MapNode.Title = "Product Review-Produksi" OrElse MapNode.Title = "Report" Then
            Dim ItemParent As MenuItem = e.Item.Parent

            If ItemParent IsNot Nothing Then
                ItemParent.ChildItems.Remove(e.Item)
            End If

        End If
    End Sub

End Class

