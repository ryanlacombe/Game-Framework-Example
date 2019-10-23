using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class Game
    {
        public static bool gameOver = false;
        private static Scene _currentscene;
        public static readonly int SizeX = 16;
        public static readonly int SizeY = 16;

        public Game()
        {
            RL.InitWindow(640, 480, "Small Game");
            RL.SetTargetFPS(15);
        }
        //The Scene we are currently running
        public static Scene CurrentScene
        {
            set
            {
                _currentscene = value;
                _currentscene.Start();
            }
            get
            {

                return _currentscene;

            }
        }
        private void Init()
        {
            Room startingRoom = new Room(8, 6);
            Room otherRoom = new Room(12, 6);

            Enemy enemy = new Enemy("tile191.png");
            void OtherRoomStart()
            {
                enemy.X = 4;
                enemy.Y = 4;
            }

            otherRoom.OnStart += OtherRoomStart;

            startingRoom.North = otherRoom;
            //Add Walls to the startingRoom
            startingRoom.AddEntity(new Wall(2, 2));
            //north walls
            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    startingRoom.AddEntity(new Wall(i, 0));
                }
            }
            //south walls
            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                startingRoom.AddEntity(new Wall(i, startingRoom.SizeY - 1));
            }
            //east walls
            for (int i = 1; i < startingRoom.SizeY - 1; i++)
            {
                startingRoom.AddEntity(new Wall(startingRoom.SizeX - 1, i));
            }
            //west walls
            for (int i = 1; i < startingRoom.SizeY - 1; i++)
            {
                startingRoom.AddEntity(new Wall(0, i));
            }
            //Add Walls to the otherRoom
            //north walls
            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                otherRoom.AddEntity(new Wall(i, 0));
            }
            //south walls
            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(i, otherRoom.SizeY - 1));
                }
            }
            //east walls
            for (int i = 1; i < otherRoom.SizeY - 1; i++)
            {
                otherRoom.AddEntity(new Wall(otherRoom.SizeX - 1, i));
            }
            //west walls
            for (int i = 1; i < otherRoom.SizeY - 1; i++)
            {
                otherRoom.AddEntity(new Wall(0, i));
            }

            //Create a Player, position it, and add it to startingRoom
            Player player = new Player("tile190.png");
            player.X = 4;
            player.Y = 3;
            startingRoom.AddEntity(player);
            //Add enemy to otherRoom
            otherRoom.AddEntity(enemy);

            CurrentScene = startingRoom;

        }
        public void Run()
        {
            Init();
            //PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape);

            while (!gameOver && !RL.WindowShouldClose())
            {
                _currentscene.Update();
                RL.BeginDrawing();
                _currentscene.Draw();
                RL.EndDrawing();

                PlayerInput.ReadKey();
            }
            RL.CloseWindow();
        }
        public void Quit()
        {
            gameOver = true;
        }       
        private Enemy _enemy = new Enemy();
        
        private void StartOtherRoom()
        {

        }
    }
}
