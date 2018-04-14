using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UniversalHeroes
{
    public class ActorBase
    {
        protected float XSpeed { get; set; }
        protected float YSpeed { get; set; }
        public string Name { get; set; }
        public virtual void UpdateActor() {}
        public List<Force> ForcesApplied { get; set; } = new List<Force>();

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
