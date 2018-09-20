using System.Numerics;
namespace UniversalHeroes
{
    public class Force
    {
        public Vector2 Direction { get; private set; }
        public bool IsGlobal { get; set; }

        public Force(float X, float Y)
        {
            Direction = new Vector2(X, Y);
        }
    }
}
