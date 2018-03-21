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
        private CoreDispatcher dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
        public async void UpdateGame(object state)
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal,
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
