using ICanWorkWithThePDF.Classes;
using ICanWorkWithThePDF.ViewModel;
using Microsoft.Win32;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICanWorkWithThePDF.View
{
    /// <summary>
    /// Логика взаимодействия для SplitPage.xaml
    /// </summary>
    public partial class SplitPage : Page
    {
        Microsoft.Win32.OpenFileDialog openFileDialog;
        Microsoft.Win32.SaveFileDialog saveFileDialog;
        FolderBrowserDialog folderBrowserDialog;
        public SplitViewModel context;
        public SplitPage()
        {
            InitializeComponent();
            context = new SplitViewModel();
            this.DataContext = context;
            openFileDialog = new Microsoft.Win32.OpenFileDialog();
            saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
            openFileDialog.Filter = "PDF files(*.pdf)|*.pdf|All files(*.*)|*.*";
            saveFileDialog.Filter = "PDF files(*.pdf)|*.pdf|All files(*.*)|*.*";
            FilesView.ItemsSource = context.FilesList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.viewModel.MainFrameVM = new View.HomePage();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(fileName);
            System.Drawing.Image img = pdf.SaveAsImage(0, PdfImageType.Bitmap, 400, 300);
            pdf.Close();
            BitmapImage bitmap = new BitmapImage();
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Bmp);

                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(stream.ToArray());
                bitmap.EndInit();
            };
            context.FilesList.Add(new ModelObject(fileName, bitmap, fileName));
        }

        private void btnSplit_Click(object sender, RoutedEventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            string folderDir = folderBrowserDialog.SelectedPath;
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(((ModelObject)FilesView.SelectedItem).Path);
            document.Split(folderDir+"/split-{0}.pdf",1);
        }
    }
}
