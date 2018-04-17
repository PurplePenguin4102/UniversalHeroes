﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
        public virtual void UpdateActor() {}
        public List<Force> ForcesApplied { get; set; } = new List<Force>();
        public ICanvasBrush Brush { get; set; }
        public CanvasGeometry Geometry { get; set; }

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
    }
}
