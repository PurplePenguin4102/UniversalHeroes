using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalHeroes
{
    public class GameViewModel
    {
        private YellowGuy _yellowGuy = new YellowGuy();
        public YellowGuy YellowGuy { get; set; }
    }
}
