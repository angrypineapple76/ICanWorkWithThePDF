using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ICanWorkWithThePDF.Classes
{
    public class ModelObject
    {
        string path;
        BitmapImage previosImage;
        string name;
        public string Path {  get { return path; } set { path = value; } }
        public BitmapImage PreviosImage { get { return previosImage; } set { previosImage = value; } } 
        public string Name { get { return name; } set { name = value; } }
        public ModelObject(string path,BitmapImage img,string name)
        {
            this.Path = path;
            this.PreviosImage = img;
            this.Name = name;
        }
    }
}
