using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;
using Windows.UI;

namespace UniversalHeroes
{
    public class GameModel
    {
        public List<ActorBase> Actors;

        public GameModel()
        {
            Actors = new List<ActorBase>()
            {
                new SelectableGuy(100, 100, 50, 50) {Colour = Color.FromArgb(0xff, 0xff, 0x13, 0x00)},
                new SelectableGuy(100, 150, 50, 50) {Colour = Color.FromArgb(0xff, 0xff, 0xdb, 0x00)},
                new SelectableGuy(150, 100, 50, 50) {Colour = Color.FromArgb(0xff, 0x4e, 0x00, 0xf9)},
                new SelectableGuy(150, 150, 50, 50) {Colour = Color.FromArgb(0xff, 0x00, 0xfa, 0x42)}
            };
        }

        public void UpdateGame(object state)
        {
            foreach (var actor in Actors)
            {
                actor.UpdateActor();
            }
        }
    }
}
