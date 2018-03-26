using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace UniversalHeroes
{
    public class BorderBezierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var border = value as Border;
            if (border.ActualHeight == 0)
                return new Point(0, 0);
            return new Point(border.Width, 700);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
