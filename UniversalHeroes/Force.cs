using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UniversalHeroes
{
    public class Force
    {
        public Vector2 Direction { get; private set; }

        public Force(float X, float Y)
        {
            Direction = new Vector2(X, Y);
        }
    }
}
