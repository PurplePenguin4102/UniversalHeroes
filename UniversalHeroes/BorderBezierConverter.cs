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
            var border = value as ScreenDimensions;
            if (border.Width == 0)
                return new Point(0, 0);
            switch (int.Parse((string)parameter))
            {
                case 1: return new Point(0, border.Height - 200);
                case 2: return new Point(border.Width / 2, border.Height - 400);
                case 3: return new Point(border.Width, border.Height - 300);
                case 4: return new Point(border.Width, border.Height);
                case 5: return new Point(0, border.Height);
            }
            return new Point(border.Width, border.Height);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
