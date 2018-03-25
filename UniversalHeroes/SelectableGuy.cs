using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using System.ServiceModel;
using System.Threading;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace UniversalHeroes
{
    public class SelectableGuy : ActorBase, INotifyPropertyChanged
    {
        private int xSpeed;
        private int ySpeed;

         
        public Colours Colour { get; set; }

        public SelectableGuy(int top, int left)
        {
            _top = top;
            _left = left;
        }

        public override void UpdateActor()
        {
            UpdateSquarePosition();
            base.UpdateActor();
        }

        private void UpdateSquarePosition()
        {
            Top += ySpeed;
            Left += xSpeed;
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

        private void ChangeSpeed()
        {
            switch (Command)
            {
                case GuyCommands.Stop:      xSpeed = ySpeed = 0                       ; break;
                case GuyCommands.StopDown:  ySpeed = ySpeed != 0 ? ySpeed - 1 : 0     ; break;
                case GuyCommands.StopUp:    ySpeed = ySpeed != 0 ? ySpeed + 1 : 0     ; break;
                case GuyCommands.StopLeft:  xSpeed = xSpeed != 0 ? xSpeed + 1 : 0     ; break;
                case GuyCommands.StopRight: xSpeed = xSpeed != 0 ? xSpeed - 1 : 0     ; break;
                case GuyCommands.GoLeft:    xSpeed = xSpeed > -1 ? xSpeed - 1 : xSpeed; break;
                case GuyCommands.GoRight:   xSpeed = xSpeed < 1  ? xSpeed + 1 : xSpeed; break;
                case GuyCommands.GoDown:    ySpeed = ySpeed < 1  ? ySpeed + 1 : ySpeed; break;
                case GuyCommands.GoUp:      ySpeed = ySpeed > -1 ? ySpeed - 1 : ySpeed; break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") => 
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
