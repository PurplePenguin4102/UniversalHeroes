using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;


namespace UniversalHeroes
{
    public class GameModel
    {
        public async void UpdateGame(object state)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                var gameState = state as List<ActorBase>;
                foreach (var actor in gameState)
                {
                    actor.UpdateActor();
                }
            });
        }
    }
}
