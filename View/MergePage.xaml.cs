using ICanWorkWithThePDF.Classes;
using ICanWorkWithThePDF.ViewModel;
using Microsoft.Win32;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace ICanWorkWithThePDF.View
{
    /// <summary>
    /// Логика взаимодействия для MergePage.xaml
    /// </summary>
    public partial class MergePage : Page
    {
        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;
        public MergeViewModel context;
        public MergePage()
        {
            InitializeComponent();
            context = new MergeViewModel();
            this.DataContext = context;
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "PDF files(*.pdf)|*.pdf|All files(*.*)|*.*";
            saveFileDialog.Filter = "PDF files(*.pdf)|*.pdf|All files(*.*)|*.*";
            FilesView.ItemsSource = context.FilesList;
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.viewModel.MainFrameVM = new View.HomePage();
        }

        private void btnMerge_Click(object sender, RoutedEventArgs e)
        {
            string[] filesArray = new string[context.FilesList.Count];
            for (int i = 0; i < context.FilesList.Count; i++)
            {
                filesArray[i] = context.FilesList[i].Path;
            }
            PdfDocumentBase doc = Spire.Pdf.PdfDocument.MergeFiles(filesArray);
            doc.Save("OUTPUT.pdf", FileFormat.PDF);
            saveFileDialog.ShowDialog();
            string outDir = saveFileDialog.FileName;
            Helpers.RemoveWaterMarckAndSave("OUTPUT.pdf", outDir);
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
    }
}
