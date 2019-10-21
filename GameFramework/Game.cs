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
        private static Scene _currentscene;

        public Game()
        {
            
        }
        public void Init()
        {
            Room startingRoom = new Room();
            Room NorthRoom = new Room();
            Room SouthRoom = new Room();
            Room WestRoom = new Room();
            Room EastRoom = new Room();

            startingRoom.North = NorthRoom;
            startingRoom.South = SouthRoom;
            startingRoom.East = WestRoom;
            startingRoom.West = EastRoom;

            NorthRoom.South = startingRoom;
            SouthRoom.North = startingRoom;
            WestRoom.West = startingRoom;
            EastRoom.East = startingRoom;

            Player player = new Player();
            player.X = 3;
            player.Y = 3;
            Entity enemy = new Entity('e');      
            enemy.X = 5;
            enemy.Y = 1;
            startingRoom.AddEntity(new Wall(0, 0));
            startingRoom.AddEntity(new Wall(0, 1));
            NorthRoom.AddEntity(new Wall(0, 2));
            startingRoom.AddEntity(new Wall(0, 3));
            startingRoom.AddEntity(new Wall(0, 4));
            startingRoom.AddEntity(new Wall(0, 5));
            startingRoom.AddEntity(new Wall(1, 0));
            startingRoom.AddEntity(new Wall(2, 0));
            startingRoom.AddEntity(new Wall(3, 0));
            startingRoom.AddEntity(new Wall(4, 0));
            startingRoom.AddEntity(new Wall(5, 0));
            startingRoom.AddEntity(new Wall(6, 0));
            startingRoom.AddEntity(new Wall(7, 0));
            startingRoom.AddEntity(new Wall(8, 0));
            startingRoom.AddEntity(new Wall(9, 0));
            startingRoom.AddEntity(new Wall(10, 0));
            startingRoom.AddEntity(new Wall(11, 0));
            startingRoom.AddEntity(new Wall(12, 0));

            startingRoom.AddEntity(player);

            NorthRoom.AddEntity(enemy);

            startingRoom.Start();

            _currentscene = startingRoom;
        }
        public void Run()
        {
            Init();
            PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape);

            while (!gameOver)
            {
                _currentscene.Update();
                _currentscene.Draw();
                PlayerInput.ReadKey();
            }
        }
        public void Quit()
        {
            gameOver = true;
        }
        public static Scene CurrentScene
        {
            set
            {
                _currentscene = value;
            }
            get
            {
                return _currentscene;
            }
        }
    }
}
