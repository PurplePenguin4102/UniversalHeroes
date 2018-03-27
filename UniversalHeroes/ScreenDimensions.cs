using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;

namespace UniversalHeroes
{
    public class ScreenDimensions : INotifyPropertyChanged
    {
        public ScreenDimensions(int width, int height)
        {
            var r = new Random();
            _height = height;
            _width = width;
            _point1Mod = 300 * r.NextDouble();
            _point2Mod = 400 * r.NextDouble();
            _point3Mod = 300 * r.NextDouble();
        }

        private double _point1Mod;
        private double _point2Mod;
        private double _point3Mod;

        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    RecalculatePoints();
                }
            }
        }

        private double _width;
        public double Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                    RecalculatePoints();
                }
            }
        }

        private void RecalculatePoints()
        {
            Point1 = new Point(0, Height - _point1Mod);
            Point2 = new Point(Width / 2, Height - _point2Mod);
            Point3 = new Point(Width, Height - _point3Mod);
            LinePath1 = new Point(Width, Height);
            LinePath2 = new Point(0, Height);
        }

        private Point _point1;
        public Point Point1
        {
            get => _point1;
            set
            {
                _point1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Point1"));
            }
        }


        private Point _point2;
        public Point Point2
        {
            get => _point2;
            set
            {
                _point2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Point2"));
            }
        }

        private Point _point3;
        public Point Point3
        {
            get => _point3;
            set
            {
                _point3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Point3"));
            }
        }

        private Point _linePath1;
        public Point LinePath1
        {
            get => _linePath1;
            set
            {
                _linePath1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LinePath1"));
            }
        }

        private Point _linePath2;
        public Point LinePath2
        {
            get => _linePath2;
            set
            {
                _linePath2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LinePath2"));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

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
