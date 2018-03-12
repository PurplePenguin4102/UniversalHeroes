using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace UniversalHeroes
{
    public class YellowGuy
    {
        public double Top { get; set; }
        public double Left { get; set; }
        public VirtualKey Command { get; set; }

        public YellowGuy()
        {
            Top = 0;
            Left = 0;
        }
    }
}
