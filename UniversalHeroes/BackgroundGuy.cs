using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;

namespace UniversalHeroes
{
    public class BackgroundGuy : ActorBase
    {
        public BackgroundGuy()
        {
            
        }

        public Color Colour { get; set; } = Color.FromArgb(0xff, 0x0, 0x0, 0x0);
        public CanvasGeometry Geometry { get; set; }
    }
}
