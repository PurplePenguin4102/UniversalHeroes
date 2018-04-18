using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace UniversalHeroes
{
    public class ActorBase
    {
        public float XSpeed { get; set; }
        public float YSpeed { get; set; }
        public string Name { get; set; }
        public virtual void UpdateActor(Rect gameField) {}
        public List<Force> ForcesApplied { get; set; } = new List<Force>();
        public ICanvasBrush Brush { get; set; }
        public CanvasGeometry Geometry { get; set; }
        public bool Collided { get; set; }
        private List<ActorBase> _actorCollisions = new List<ActorBase>();

        public virtual void RenderGeometry(CanvasControl canvas)
        {

        }

        public void ApplyForces()
        {
            if (ForcesApplied.Any())
            {
                var dir = ForcesApplied
                    .Select(v => v.Direction)
                    .Aggregate((v1, v2) => Vector2.Add(v1, v2));
                XSpeed += dir.X;
                YSpeed += dir.Y;
            }
        }

        public void RegisterCollision(ActorBase collider)
        {
            Collided = true;
            _actorCollisions.Add(collider);
        }

        public virtual void ResolveCollisions()
        {
            _actorCollisions.Clear();
        }
    }
}
