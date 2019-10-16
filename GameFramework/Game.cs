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
