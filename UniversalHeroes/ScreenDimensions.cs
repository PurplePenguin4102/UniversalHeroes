using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace UniversalHeroes
{
    public class ScreenDimensions : INotifyPropertyChanged
    {
        public ScreenDimensions(int width, int height)
        {
            _height = height;
            _width = width;
        }
        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScreenDimensions"));
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private double _width;
        public double Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScreenDimensions"));
                }
            }
        }
        public override bool Equals(object obj)
        {
            var sd = obj as ScreenDimensions;
            if (sd == null)
                return base.Equals(obj);
            return sd.Height == Height && sd.Width == Width;
        }

        public override int GetHashCode()
        {
            return Height.GetHashCode() + 15_485_863 * Width.GetHashCode();
        }
    }
}
