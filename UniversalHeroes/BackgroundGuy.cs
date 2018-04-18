using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Windows.Foundation;
using Windows.UI;
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
