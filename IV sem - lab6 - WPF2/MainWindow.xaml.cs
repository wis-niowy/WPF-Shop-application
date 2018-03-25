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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.IO;

namespace IV_sem___lab6___WPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Uri> imageUriList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            imageUriList = new ObservableCollection<Uri>();
            this.LoadDirectories();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Simple image browser", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OpenImageMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML files (.jpg, .gif, .png) | *.jpg; *.gif; *.png";
            DialogResult result = ofd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                PicWindow newWindow = new PicWindow(ofd.FileName);
                newWindow.Show();
            }
        }

        private void OpenFolderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            List<string> extList = new List<string>() {".jpg", ".gif", ".png" };
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
                FileInfo[] files = dir.GetFiles("*.*");

                foreach (var file in files)
                {
                    if (extList.Contains(file.Extension))
                    {
                        imageUriList.Add(new Uri(file.FullName));
                    }
                }
                
            }
        }

        private void ImageItemButton_DoubleClick(object sender, RoutedEventArgs e)
        {
            Uri clickedPicture = (Uri)(sender as System.Windows.Controls.Button).Tag;
            PicWindow window = new PicWindow(clickedPicture);
            Action popWindow = () => window.Show();

            this.Dispatcher.BeginInvoke(popWindow);
        }

        private void TreeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox cb = sender as System.Windows.Controls.CheckBox;
            //if (cb.IsChecked == true)
                
        }

        

    }
    
}
