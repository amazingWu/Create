using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Documents;

namespace PhoneApp1.MyLei
{
    class ImageButton:Button
    {
        public static readonly DependencyProperty ImageSourceProperty =
   DependencyProperty.Register(
       "ImageSource",
       typeof(ImageSource),
       typeof(ImageButton),
       null);


        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }

        }  
    }
}
