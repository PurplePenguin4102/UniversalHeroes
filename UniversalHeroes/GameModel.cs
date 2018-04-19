using System;
using System.Threading;
using Microsoft.Graphics.Canvas.Geometry;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.System;
using Windows.UI;

namespace UniversalHeroes
{
    public class GameModel
    {
        public List<ActorBase> Actors { get; set; }
        public Queue<Point> ClickEvents { get; set; } = new Queue<Point>();
        public List<VirtualKey> KeyState { get; set; } = new List<VirtualKey>();
        public Rect Gamefield { get; set; }
        private bool updateRunning = false;

        public void GameInit()
        {
            Actors = new List<ActorBase>
            {
                new SelectableGuy(600, 100, 50, 50) {Colour = Color.FromArgb(0xff, 0xff, 0x13, 0x00), Name="Redguy"},
                new SelectableGuy(650, 200, 50, 50) {Colour = Color.FromArgb(0xff, 0xff, 0xdb, 0x00)},
                new SelectableGuy(650, 100, 50, 50) {Colour = Color.FromArgb(0xff, 0x4e, 0x00, 0xf9)},
                new SelectableGuy(650, 150, 50, 50) {Colour = Color.FromArgb(0xff, 0x00, 0xfa, 0x42)},
                new BackgroundGuy()
            };

            foreach (var actor in Actors)
            {
                actor.ForcesApplied.Add(new Force(0f, 0.9f));
            }
            Actors[0].XSpeed = 10f;
            Actors[0].YSpeed = -20f;
        }

        public void UpdateGame(object state)
        {
            if (updateRunning) return;

            updateRunning = true;
            Point clickedAt;
            if (ClickEvents.Any())
            {
                clickedAt = ClickEvents.Dequeue();
                var selectableGuys = Actors.OfType<SelectableGuy>();
                selectableGuys.Select(sg => sg.Selected = false); 
                var selectedGuy = selectableGuys.FirstOrDefault(sg => sg.ContainsPoint(clickedAt));
                if (selectedGuy != null) selectedGuy.Selected = true;
            }

            foreach (var actor in Actors)
            {
                actor.UpdateActor(Gamefield);
            }

            TestCollisions((act1, act2) => act1.Geometry.CompareWith(act2.Geometry) == CanvasGeometryRelation.Overlap);

            foreach (var actor in Actors)
            {
                actor.ResolveCollisions();
            }
            updateRunning = false;
        }


        private void TestCollisions(Func<ActorBase, ActorBase, bool> collisionTest)
        {
            for (int i = 0; i < Actors.Count(); i++)
            {
                if (Actors[i].Collided) continue;

                for (int j = 0; j < Actors.Count(); j++)
                {
                    if (j <= i) continue;

                    if (collisionTest(Actors[i], Actors[j]))
                    {
                        Actors[i].RegisterCollision(Actors[j]);
                        Actors[j].RegisterCollision(Actors[i]);
                    }
                }
            }
        }
    }
}
