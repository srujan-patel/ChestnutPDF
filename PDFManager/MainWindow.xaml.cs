using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

//syncfusion
using Syncfusion.DocIO;
using Syncfusion.DocToPDFConverter;
using Syncfusion.DocIO.DLS;

//for working with our theme
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;

//for working with processes and diagnostics
using System.Diagnostics;


//to work with images
using System.Drawing;

//for saving and reading files
using System.IO;
using System.Windows;








namespace PDFManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
