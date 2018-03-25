using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace UniversalHeroes
{
    public class ColourBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var param = (Colours)value;
            return new SolidColorBrush(new Color
            {
                A = 0xFF,
                R = (byte)(((int)param & 0xFF0000) >> 16),
                G = (byte)(((int)param & 0x00FF00) >> 8),
                B = (byte)(((int)param & 0x0000FF) >> 0)
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
