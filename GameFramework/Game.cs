using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Game
    {
        public static bool gameOver = false;
        private Scene _currentscene;

        public Game()
        {
            _currentscene = new Scene();
        }
        public void Run()
        {
            Entity player = new Entity('@');
            player.X = 6;
            _currentscene.AddEntity(player);
            Entity enemy = new Entity('#');
            enemy.X = 4;
            _currentscene.AddEntity(enemy);
            _currentscene.Start();

            while (!gameOver)
            {
                _currentscene.Update();
                _currentscene.Draw();
                Console.ReadKey();
            }
        }
    }
}
