using ICanWorkWithThePDF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ICanWorkWithThePDF.ViewModel
{
    public class SplitViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ModelObject> filesList = new ObservableCollection<ModelObject>();
        public ObservableCollection<ModelObject> FilesList
        {
            get { return filesList; }
            set { filesList = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
