# how-to-customize-the-item-template-based-on-the-node-in-.net-maui-treeview
This repository demonstrates how to customize the item template based on the node type in the .NET MAUI TreeView (SfTreeView) control. It provides a sample implementation using DataTemplateSelector to dynamically apply different templates for parent and child nodes, enabling flexible and context-aware UI customization.

## Sample
You can customize the ItemTemplate based on the node by using DataTemplateSelector in .NET MAUI TreeView.

### XAML
```xaml
<ContentPage.BindingContext>
    <local:FileManagerViewModel x:Name="viewModel"/>
</ContentPage.BindingContext>

<ContentPage.Resources>
    <ResourceDictionary>
        <local:ItemTemplateSelector x:Key="ItemTemplateSelector" />
    </ResourceDictionary>
</ContentPage.Resources>

<ContentPage.Content>
    <syncfusion:SfTreeView x:Name="treeView" Indentation="15"
                           AutoExpandMode="AllNodesExpanded" 
                           ItemTemplateContextType="Node" 
                           ChildPropertyName="SubFiles"
                           ItemHeight="25"
                           ItemsSource="{Binding ImageNodeInfo}" 
                           ItemTemplate="{StaticResource ItemTemplateSelector}"/>

</ContentPage.Content>
```

### DataTemplateSelector
```csharp
public class ItemTemplateSelector : DataTemplateSelector
{
    public DataTemplate _ParentTemplate { get; set; }
    public DataTemplate _ChildTemplate { get; set; }
    public ItemTemplateSelector()
    {
        this._ParentTemplate = new DataTemplate(typeof(ParentTemplate));
        this._ChildTemplate = new DataTemplate(typeof(ChildTemplate));
    }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var node = item as TreeViewNode;
        var treeviewItem = node.Content as FileManager;
        if (treeviewItem == null)
            return null;
        if (treeviewItem.SubFiles != null)
            return _ParentTemplate;
        else
            return _ChildTemplate;
    }
}
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements).

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.