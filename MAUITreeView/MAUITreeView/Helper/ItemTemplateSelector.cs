using Syncfusion.Maui.TreeView;
using Syncfusion.TreeView.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITreeView
{
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
}
