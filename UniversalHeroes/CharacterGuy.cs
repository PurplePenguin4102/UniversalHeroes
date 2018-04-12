using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace UniversalHeroes
{
    public class CharacterGuy
    {
        public float Left { get; set; } = 0;
        public float Top { get; set; } = 0;
        public int Width { get; set; } = 50;
        public int Height { get; set; } = 50;
        public Color Colour { get; set; } = Color.FromArgb(0xff, 0xff, 0xd7, 0);
    }
}
