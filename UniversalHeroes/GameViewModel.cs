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
        public GameModel GameModel { get; set; } = new GameModel();

        private Timer _uiUpdateTimer;
        public List<ActorBase> Actors;

        public GameViewModel()
        {
            Actors = new List<ActorBase>();
            _uiUpdateTimer = new Timer(GameModel.UpdateGame, Actors, 0, 1);
        }
    }
}
