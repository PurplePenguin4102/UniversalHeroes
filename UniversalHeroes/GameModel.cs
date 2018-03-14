using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalHeroes
{
    public class GameModel
    {
        public void UpdateGame(object state)
        {
            var gameState = state as List<ActorBase>;
            foreach (var actor in gameState)
            {
                actor.UpdateActor();
            }
        }
    }
}
