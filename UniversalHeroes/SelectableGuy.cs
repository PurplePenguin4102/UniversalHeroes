﻿using System;
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
using Windows.UI;
using Windows.Foundation;

namespace UniversalHeroes
{
    public class SelectableGuy : ActorBase
    {
        public double Gravity { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Selected { get; set; }
        public Color Colour { get; set; }

        public SelectableGuy(int top, int left, int width, int height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public override void UpdateActor()
        {
            ApplyForces();
            UpdateSquarePosition();
            base.UpdateActor();
        }

        private void UpdateSquarePosition()
        {
            Top += YSpeed;
            Left += XSpeed;
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
                }
            }
        }

        public bool ContainsPoint(Point clickedAt)
        {
            return Left < clickedAt.X 
                && clickedAt.X < Left + Width
                && Top < clickedAt.Y 
                && clickedAt.Y < Top + Height;
        }

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
    }
}
