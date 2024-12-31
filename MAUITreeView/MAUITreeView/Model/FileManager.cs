using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITreeView
{
    public class FileManager : INotifyPropertyChanged
    {
        #region Fields

        private string itemName;
        private string imageIcon;
        private Color nodeColor = Colors.Transparent;
        private ObservableCollection<FileManager> subFiles;

        #endregion

        #region Constructor
        public FileManager()
        {
        }

        #endregion

        #region Properties
        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                RaisedOnPropertyChanged("SubFiles");
            }
        }

        public string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                RaisedOnPropertyChanged("ItemName");
            }
        }
        public string ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisedOnPropertyChanged("ImageIcon");
            }
        }

        public Color NodeColor
        {
            get { return nodeColor; }
            set
            {
                nodeColor = value;
                RaisedOnPropertyChanged("NodeColor");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}
