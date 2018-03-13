using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace UniversalHeroes
{
    public class YellowGuy : INotifyPropertyChanged
    {
        public YellowGuy() { }

        private double _top;
        public double Top
        {
            get => _top;
            set
            {
                if (_top != value)
                {
                    _top = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _width = 20;
        public int Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _height = 20;
        public int Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _selected;
        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }


        private double _left;
        public double Left
        {
            get => _left;
            set
            {
                if (_left != value)
                {
                    _left = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private GuyCommands _command = GuyCommands.Stop;
        public GuyCommands Command
        {
            get => _command;
            set 
            {
                if (_command != value)
                {
                    _command = value;
                    ChangeSpeed();
                    NotifyPropertyChanged();
                    
                }

            }
        }

        private int xSpeed;
        private int ySpeed;
        private int xPos;
        private int yPos;

        private void ChangeSpeed()
        {
            switch (Command)
            {
                case GuyCommands.Stop: xSpeed = ySpeed = 0; break;
                case GuyCommands.GoLeft: xSpeed = -1; break;
                case GuyCommands.GoRight: xSpeed = 1; break;
                case GuyCommands.GoDown: ySpeed = -1; break;
                case GuyCommands.GoUp: ySpeed = 1; break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") => 
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
