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
    public class SelectableGuy : ActorBase, INotifyPropertyChanged, IGravityEnabled
    {
        public Colours Colour { get; set; }

        public SelectableGuy(int top, int left)
        {
            _top = top;
            _left = left;
        }

        public override void UpdateActor()
        {
            GravityEffectModifySpeed();
            UpdateSquarePosition();
            base.UpdateActor();
        }

        private void UpdateSquarePosition()
        {
            Top += YSpeed;
            Left += XSpeed;
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

        public double Gravity { get; set; }

        private void ChangeSpeed()
        {
            switch (Command)
            {
                case GuyCommands.Stop:      XSpeed = YSpeed = 0                       ; break;
                case GuyCommands.StopDown:  YSpeed = YSpeed != 0 ? YSpeed - 1 : 0     ; break;
                case GuyCommands.StopUp:    YSpeed = YSpeed != 0 ? YSpeed + 1 : 0     ; break;
                case GuyCommands.StopLeft:  XSpeed = XSpeed != 0 ? XSpeed + 1 : 0     ; break;
                case GuyCommands.StopRight: XSpeed = XSpeed != 0 ? XSpeed - 1 : 0     ; break;
                case GuyCommands.GoLeft:    XSpeed = XSpeed > -1 ? XSpeed - 1 : XSpeed; break;
                case GuyCommands.GoRight:   XSpeed = XSpeed < 1  ? XSpeed + 1 : XSpeed; break;
                case GuyCommands.GoDown:    YSpeed = YSpeed < 1  ? YSpeed + 1 : YSpeed; break;
                case GuyCommands.GoUp:      YSpeed = YSpeed > -1 ? YSpeed - 1 : YSpeed; break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") => 
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        public void GravityEffectModifySpeed()
        {
            //YSpeed++;
        }
    }
}
