using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace UniversalHeroes
{
    public class BackgroundGuy : ActorBase
    {
        private CanvasControl _canvas;
        public override void RenderGeometry(CanvasControl canvas)
        {
            _canvas = canvas;
            Geometry = CanvasGeometry.CreateRectangle(_canvas, 0f, 0f, 0f, 0f);
            Brush = new CanvasSolidColorBrush(canvas, Colour);
            base.RenderGeometry(canvas);
        }

        public override void UpdateActor(Rect gameField)
        {
            if (Geometry != null)
            {
                Geometry = CanvasGeometry.CreateRectangle(_canvas, 0f, 700f, (float)gameField.Width, 20f);
            }

            base.UpdateActor(gameField);
        }

        public Color Colour { get; set; } = Color.FromArgb(0xff, 0x0, 0x0, 0x0);
    }
}
