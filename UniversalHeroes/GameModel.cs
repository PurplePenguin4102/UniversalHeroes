using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.System;
using Windows.UI;
using Windows.UI.Input;

namespace UniversalHeroes
{
    public class GameModel
    {
        public List<ActorBase> Actors { get; set; }
        public Queue<Point> ClickEvents { get; set; } = new Queue<Point>();
        public List<VirtualKey> KeyState { get; set; } = new List<VirtualKey>();
        public Rect Gamefield { get; set; } = new Rect(0f, 0f, 0f, 0f);

        public void GameInit()
        {
            Actors = new List<ActorBase>
            {
                new SelectableGuy(600, 100, 50, 50) {Colour = Color.FromArgb(0xff, 0xff, 0x13, 0x00), Name="Redguy"},
                new SelectableGuy(600, 150, 50, 50) {Colour = Color.FromArgb(0xff, 0xff, 0xdb, 0x00)},
                new SelectableGuy(650, 100, 50, 50) {Colour = Color.FromArgb(0xff, 0x4e, 0x00, 0xf9)},
                new SelectableGuy(650, 150, 50, 50) {Colour = Color.FromArgb(0xff, 0x00, 0xfa, 0x42)},
                new BackgroundGuy()
            };

            Actors[0].ForcesApplied.Add(new Force(0f, 0.3f));
            Actors[0].XSpeed = 5f;
            Actors[0].YSpeed = -15f;
        }

        public void UpdateGame(object state)
        {
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
        }
    }
}
