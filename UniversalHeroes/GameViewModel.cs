using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UniversalHeroes
{
    public class GameViewModel
    {
        private static int boxDim = 50;
        public SelectableGuy YellowGuy { get; set; } = new SelectableGuy(100, 100) { Colour = Colours.Yellow };
        public SelectableGuy RedGuy { get; set; } = new SelectableGuy(100, 120 + boxDim) { Colour = Colours.Red };
        public SelectableGuy GreenGuy { get; set; } = new SelectableGuy(120, 100) { Colour = Colours.Green };
        public SelectableGuy BlueGuy { get; set; } = new SelectableGuy(120, 120) { Colour = Colours.Blue };

        public ScreenDimensions ScreenDimensions { get; set; } = new ScreenDimensions(height:1000, width:1450);
        public GameModel GameModel { get; set; } = new GameModel();

        private Timer _uiUpdateTimer;
        private List<ActorBase> actors;

        public GameViewModel()
        {
            actors = new List<ActorBase>() { YellowGuy, GreenGuy, BlueGuy, RedGuy };
            _uiUpdateTimer = new Timer(GameModel.UpdateGame, actors, 0, 1);
        }
    }
}
