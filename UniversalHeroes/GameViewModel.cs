﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UniversalHeroes
{
    public class GameViewModel
    {
        public YellowGuy YellowGuy { get; set; } = new YellowGuy();
        public GameModel GameModel { get; set; } = new GameModel();
        private List<ActorBase> actors = new List<ActorBase>();
        public GameViewModel()
        {
            actors.Add(YellowGuy);
            new Timer(GameModel.UpdateGame, actors, 0, 15);
        }
    }
}
