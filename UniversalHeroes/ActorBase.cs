using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalHeroes
{
    public class ActorBase
    {
        protected int XSpeed { get; set; }
        protected int YSpeed { get; set; }
        public string Name { get; set; }
        public virtual void UpdateActor() {}
    }
}
