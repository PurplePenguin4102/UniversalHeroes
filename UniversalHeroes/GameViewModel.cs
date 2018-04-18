using System.Threading;

namespace UniversalHeroes
{
    public class GameViewModel
    {
        public GameModel GameModel { get; set; } = new GameModel();

        private Timer GameLoop;
        private object state;

        public void StartGame()
        {
            GameLoop = new Timer(GameModel.UpdateGame, state, 0, 1);
        }
    }
}
