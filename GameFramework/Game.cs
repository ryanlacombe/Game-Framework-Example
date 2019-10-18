﻿using System;
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
            _currentscene.AddEntity(new Wall(0,0));
            _currentscene.AddEntity(new Wall(0, 1));
            _currentscene.AddEntity(new Wall(1, 0));
            _currentscene.AddEntity(new Wall(0, 2));
            _currentscene.AddEntity(new Wall(2, 0));
            _currentscene.AddEntity(new Wall(3, 0));
            Player player = new Player('@');
            player.X = 3;
            player.Y = 2;
            _currentscene.AddEntity(player);
            Entity enemy = new Entity('#');
            enemy.X = 4;
            enemy.Y = 4;
            _currentscene.AddEntity(enemy);
            _currentscene.Start();

            while (!gameOver)
            {
                _currentscene.Update();
                _currentscene.Draw();
                PlayerInput.ReadKey();
            }
        }
        public Scene CurrentScene
        {
            get
            {
                return _currentscene;
            }
        }
    }
}
