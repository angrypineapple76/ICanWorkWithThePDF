using ICanWorkWithThePDF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ICanWorkWithThePDF.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        Page mainFrame;
        public Page MainFrameVM {  get { return mainFrame; } set { mainFrame = value;OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
