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



//asposeIO

using Aspose.Pdf;

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
using System.Runtime.CompilerServices;

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
            if (pathTextbox.Text == String.Empty)
            {
                MessageBox.Show("Please Select a file for conversion", "File Error" , MessageBoxButton.OK);
            }
            switch (optionsCombobox.SelectedIndex)  //whichver option is selected from the combobox options
            {
                case 0://DOC to PDF
                    {
                        ConvertDocToPDF(pathTextbox.Text);

                        break;
                    }
                case 1:
                    {

                        break;
                    }
                case 2: //PNG to PDF
                    {
                        ConvertPngToPDF(pathTextbox.Text);


                        break;
                    }
                default:
                    MessageBox.Show("Please Select an option to continue", "Option Not Selected", MessageBoxButton.OK);
                    return;

            }
            OpenDirectory(pathTextbox.Text);
        }

        private void selectFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog open =new OpenFileDialog();//open a new file dialog
            bool? result =open.ShowDialog(); //nullable

            if (result.HasValue && result.Value)//if value exists and it is true
            {

                pathTextbox.Text = open.FileName;//display the entire directory of the selected file

            }
            


        }

        private void ConvertDocToPDF(string path)//using syncfusion
        {
           
            try { 
                Document pdfDoc = new Document(path);// open the doc file        
            
                string newSavePath = path.Split('.')[0] + ".docx";
                pdfDoc.Save(newSavePath, SaveFormat.DocX);
                pdfDoc.Dispose();

            }




            catch (Exception ex)
            
            {
                MessageBox.Show(ex.Message, "Conversion Failure...", MessageBoxButton.OK);
            }



        }

        private void ConvertPngToPDF(string path)
        {
            // Load input PNG file
            System.Drawing.Image srcImage = System.Drawing.Image.FromFile(path);
            int h = srcImage.Height;
            int w = srcImage.Width;

            // Initialize new Document
            Document doc = new Document();
            Aspose.Pdf.Page page = doc.Pages.Add();
            Aspose.Pdf.Image image = new Aspose.Pdf.Image();
            image.File = (path);

            // Set page dimensions
            page.PageInfo.Height = (h);
            page.PageInfo.Width = (w);
            page.PageInfo.Margin.Bottom = (0);
            page.PageInfo.Margin.Top = (0);
            page.PageInfo.Margin.Right = (0);
            page.PageInfo.Margin.Left = (0);
            page.Paragraphs.Add(image);

            string newSavePath = path.Split('.')[0] + ".pdf";
            // Save output PDF
            doc.Save(newSavePath);

        }



        private void OpenDirectory(string folderPath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                Arguments = folderPath.Substring(0, folderPath.LastIndexOf('\\')), //we only want the folder path excluding the filename
            

            FileName = "explorer.exe"

            };
            Process.Start(startInfo);
        }
    }
}
