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
        private static int boxDim = 50;
        public SelectableGuy YellowGuy { get; set; } = new SelectableGuy(100, 100) { Colour = Colours.Yellow, Name="YellowGuy" };
        public SelectableGuy RedGuy { get; set; } = new SelectableGuy(100, 120) { Colour = Colours.Red, Name = "RedGuy" };
        public SelectableGuy GreenGuy { get; set; } = new SelectableGuy(120, 100) { Colour = Colours.Green, Name = "GreenGuy" };
        public SelectableGuy BlueGuy { get; set; } = new SelectableGuy(120, 120) { Colour = Colours.Blue, Name = "BlueGuy" };

        public GroundGuy GroundGuy { get; set; } = new GroundGuy(height:1000, width:1450);
        public GameModel GameModel { get; set; } = new GameModel();

        private Timer _uiUpdateTimer;
        public List<ActorBase> Actors;

        public GameViewModel()
        {
            Actors = new List<ActorBase>() { YellowGuy, GreenGuy, BlueGuy, RedGuy };
            _uiUpdateTimer = new Timer(GameModel.UpdateGame, Actors, 0, 1);
        }
    }
}
