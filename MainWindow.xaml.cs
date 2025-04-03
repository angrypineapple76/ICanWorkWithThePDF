using ICanWorkWithThePDF.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace ICanWorkWithThePDF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static string CurrentPath;
        public static MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
            RemoveFiles("*.pdf");
            viewModel.MainFrameVM = new View.HomePage();
            
        }
        static MainWindow()
        {
            CurrentPath = Uri.UnescapeDataString(new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
        }
        private void RemoveFiles(string extension)
        {
            string[] files = Directory.GetFiles(CurrentPath, extension);
            foreach (string text in files)
            {
                if (!text.Contains("MagicCadTemplate"))
                {
                    try
                    {
                        File.Delete(text);
                    }
                    catch (IOException)
                    {
                        break;
                    }
                }
            }
        }

    }
}
