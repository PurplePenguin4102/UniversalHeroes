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
        public override void RenderGeometry(CanvasControl canvas)
        {
            Geometry = CanvasGeometry.CreateCircle(canvas, new Vector2(600f,600f), 12f);
            Brush = new CanvasSolidColorBrush(canvas, Colour);
            base.RenderGeometry(canvas);
        }

        public Color Colour { get; set; } = Color.FromArgb(0xff, 0x0, 0x0, 0x0);
    }
}
