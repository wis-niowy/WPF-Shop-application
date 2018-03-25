using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace IV_sem___lab6___WPF2
{
    /// <summary>
    /// Interaction logic for PicWindow.xaml
    /// </summary>
    public partial class PicWindow : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ImageData imageData;
        public ImageData ImageData
        {
            get
            {
                return imageData;
            }
            set
            {
                imageData = value;
                NotifyPropertyChanged("ImageData");
            }
        }
        private Uri imageUri;
        public Uri ImageUri
        {
            get
            {
                return imageUri;
            }
            set
            {
                imageUri = value;
                NotifyPropertyChanged("ImageUri");
            }
        }

        public PicWindow()
        {
            InitializeComponent();
        }
        public PicWindow(string filePath)
        {
            InitializeComponent();
            imageUri = new Uri(filePath);
        }
        public PicWindow(Uri filePath)
        {
            InitializeComponent();
            imageUri = filePath;
        }
    }

}
