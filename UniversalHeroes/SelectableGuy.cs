using Windows.UI;
using Windows.Foundation;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace UniversalHeroes
{
    public class SelectableGuy : ActorBase
    {
        public double Gravity { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 CenterOfGuy { get => new Vector2((float)(Left + Width / 2), (float)(Top + Height / 2)); }
        public bool Selected { get; set; }
        public Color Colour { get; set; }
        private CanvasControl _canvas;

        public override void RenderGeometry(CanvasControl canvas)
        {
            _canvas = canvas;
            Geometry = CanvasGeometry.CreateRectangle(_canvas, Left, Top, Width, Height);
            Brush = new CanvasSolidColorBrush(canvas, Colour);
            base.RenderGeometry(canvas);
        }

        public void UpdateGeometry()
        {
            if (Geometry != null)
            {
                Geometry = CanvasGeometry.CreateRectangle(_canvas, Left, Top, Width, Height);
            }
        }

        public SelectableGuy(int top, int left, int width, int height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public override void UpdateActor(Rect gameField)
        {
            ApplyForces();
            UpdateSquarePosition(gameField);
            base.UpdateActor(gameField);
        }

        private void UpdateSquarePosition(Rect gameField)
        {
            Top += YSpeed;
            if (Left + XSpeed < 0 || Left + Width + XSpeed > gameField.Right)
            {
                XSpeed *= -1;
            }
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



        public override void ResolveCollisions()
        {
            if (Collided)
            {
                foreach (var actor in _actorCollisions)
                {
                    var bound = actor.Geometry.ComputeBounds();
                    if (bound.Top < Top || bound.Top > Top)
                    {
                        YSpeed *= -1;
                        YSpeed = YSpeed * 0.6f;
                        XSpeed = XSpeed * 0.6f;
                        CancelYForce = true;
                        Top = (float)bound.Top - Height;
                        if (System.Math.Abs(YSpeed) > 2)
                        {
                            Top -= 0.1f;
                        }
                    }
                    if (bound.Left > Left || bound.Left < Left)
                    {
                        //XSpeed *= -1;
                        CancelXForce = true;
                    }
                }
            }
            else
            {
                CancelXForce = CancelYForce = false;
            }
            UpdateGeometry();
            base.ResolveCollisions();
        }
    }
}
