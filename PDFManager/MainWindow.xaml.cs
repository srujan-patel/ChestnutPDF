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
using Aspose.Pdf.Text;
using Aspose.Pdf.Operators;

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
                MessageBox.Show("Please Select a file for conversion", "File Error", MessageBoxButton.OK);
            }
            switch (optionsCombobox.SelectedIndex)  //whichver option is selected from the combobox options
            {
                case 0://DOC to PDF
                    {
                        ConvertDocToPDF(pathTextbox.Text);

                        break;
                    }
                case 1: //image to PDF
                    {
                        imageTOPDF(pathTextbox.Text);

                        break;
                    }
                case 2:
                    {
                        ConverthtmltoPDF(pathTextbox.Text);
                        break;
                    }
                case 3:
                    {
                        ConvertLatexToPDF(pathTextbox.Text);
                        break;
                    }
                case 4: {
                        ConvertEpubToPDF(pathTextbox.Text);
                        break; }

                default:
                    MessageBox.Show("Please Select an option to continue", "Option Not Selected", MessageBoxButton.OK);
                    return;

            }
            OpenDirectory(pathTextbox.Text);
        }


        private void selectFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();//open a new file dialog
            bool? result = open.ShowDialog(); //nullable

            if (result.HasValue && result.Value)//if value exists and it is true
            {

                pathTextbox.Text = open.FileName;//display the entire directory of the selected file

            }



        }

        private void ConvertDocToPDF(string path)//using syncfusion
        {

            try
            {
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

        private void ConvertEpubToPDF(string path)
        {
            try
            {
                EpubLoadOptions option = new EpubLoadOptions();
                Document pdfDocument = new Document(path, option);
                string newSavePath = path.Split('.')[0] + ".pdf";

                pdfDocument.Save(newSavePath);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Conversion Failure...", MessageBoxButton.OK);

            }

        }

        private void ConvertOthersToPDF(string path) // works for png, jpeg, jpg, GIFs, BMP, DICOM, TIFF images...
        {
            try
            {// Load Input Image
                System.Drawing.Image srcImage = System.Drawing.Image.FromFile(path);
                int h = srcImage.Height;
                int w = srcImage.Width;

                // Initialize new Document
                Document doc = new Document();
                Aspose.Pdf.Page page = doc.Pages.Add();
                Aspose.Pdf.Image image = new Aspose.Pdf.Image();
                image.File = (path);

                // Set page dimensions as the image dimensions
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
                doc.Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Conversion Failure...", MessageBoxButton.OK); }

        }

        private void imageTOPDF(string path)
        {
            FileInfo fileName = new FileInfo(path);
            string extension = fileName.Extension;
            switch (extension)
            {

                case ".cgm":
                    {

                        try
                        {
                            CgmLoadOptions option = new CgmLoadOptions();
                            string newSavePath = path.Split('.')[0] + ".pdf";
                            Document pdfDocument = new Document(path, option);
                            pdfDocument.Save(newSavePath);
                            break;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Conversion Failure", MessageBoxButton.OK);

                        }
                        break;

                    }

                case ".emf":
                    {
                        try
                        {

                            var doc = new Document();

                            // Spcify path of input EMF image file

                            var page = doc.Pages.Add();
                            string file = path;
                            FileStream filestream = new FileStream(file, FileMode.Open, FileAccess.Read);
                            BinaryReader reader = new BinaryReader(filestream);
                            long numBytes = new FileInfo(file).Length;
                            byte[] bytearray = reader.ReadBytes((int)numBytes);
                            Stream stream = new MemoryStream(bytearray);
                            var b = new Bitmap(stream);

                            // Specify page dimesion properties
                            page.PageInfo.Margin.Bottom = 0;
                            page.PageInfo.Margin.Top = 0;
                            page.PageInfo.Margin.Left = 0;
                            page.PageInfo.Margin.Right = 0;
                            page.PageInfo.Width = b.Width;
                            page.PageInfo.Height = b.Height;
                            var image = new Aspose.Pdf.Image();
                            image.File = path;
                            page.Paragraphs.Add(image);

                            //Save output PDF document
                            string newSavePath = path.Split('.')[0] + ".pdf";
                            doc.Save(newSavePath);
                        }

                        catch (Exception ex) { MessageBox.Show(ex.Message, "Conversion Failure... ", MessageBoxButton.OK); }

                        break;
                    }


                case ".svg":
                    {
                        try
                        {
                            SvgLoadOptions option = new SvgLoadOptions();
                            Document pdfDocument = new Document(path, option);
                            string newSavePath = path.Split('.')[0] + ".pdf";
                            pdfDocument.Save(newSavePath);

                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Conversion Failure... ", MessageBoxButton.OK); }
                        break;
                    }

                default:
                    {
                        ConvertOthersToPDF(path);
                        break;
                    }

            }

        }

        private void ConvertLatexToPDF(string path)
        {
            try
            {
                // Instantiate Latex Load option object
                TeXLoadOptions options = new TeXLoadOptions();
                // Create Document object
                Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(path, options);
                // Save the output in PDF file
                string newSavePath = path.Split('.')[0] + ".pdf";

                pdfDocument.Save(newSavePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Conversion Failure", MessageBoxButton.OK);

            }
        }

      

        private void ConverthtmltoPDF(string path)
        {
            try
            {
                HtmlLoadOptions options = new HtmlLoadOptions();
                Document pdfDocument = new Document(path, options);
                string newSavePath = path.Split('.')[0] + ".pdf";
                pdfDocument.Save(newSavePath);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Conversion Failure... ", MessageBoxButton.OK); }

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

        private void myMainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            myMainWindow.Width= e.NewSize.Width;
            myMainWindow.Height= e.NewSize.Height;

            double xChange =1, yChange =1;

            if (e.PreviousSize.Width != 0)
            {
                xChange = (e.NewSize.Width / e.PreviousSize.Width);

            }

            if (e.PreviousSize.Height != 0)
            {
                yChange = (e.NewSize.Height / e.NewSize.Height);
            }
            foreach(FrameworkElement fe in myGrid.Children)
            {
                if (fe is Grid==false) {

                    fe.Height = fe.ActualHeight * yChange;
                    fe.Width= fe.ActualWidth * xChange;
                    Canvas.SetTop(fe, Canvas.GetTop(fe) * yChange);
                    Canvas.SetLeft(fe, Canvas.GetLeft(fe)* xChange);

                
                }
            }
        }
    }
}
