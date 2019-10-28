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
        private Camera3D _camera;

        public Game()
        {
            RL.InitWindow(640, 480, "Small Game");
            RL.SetTargetFPS(15);

            //Raylib.Vector3 cameraPosition = new Raylib.Vector3(0, -30, -50);
            //Raylib.Vector3 cameraTarget = new Raylib.Vector3(0, -10, -10);
            //Raylib.Vector3 cameraUp = new Raylib.Vector3(0, 0, 1);

            //_camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);
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
            Room otherRoom1 = new Room(12, 6);
            Room otherRoom2 = new Room(18, 22);
            Room otherRoom3 = new Room(6, 6);
            Room otherRoom4 = new Room(4, 18);

            Enemy enemy = new Enemy("tile191.png");
            void OtherRoomStart1()
            {
                enemy.X = 4;
                enemy.Y = 4;
            }
            Chests chest = new Chests("tile084.png");
            void OtherRoomStart2()
            {
                chest.X = 2;
                chest.Y = 2;
            }

            otherRoom1.OnStart += OtherRoomStart1;
            otherRoom3.OnStart += OtherRoomStart2;

            startingRoom.North = otherRoom1;
            startingRoom.South = otherRoom2;
            startingRoom.East = otherRoom3;
            startingRoom.West = otherRoom4;
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
                if (i != 6)
                {
                    startingRoom.AddEntity(new Wall(i, startingRoom.SizeY - 1));
                }
            }
            //east walls
            for (int i = 1; i < startingRoom.SizeY - 1; i++)
            {
                if (i != 1)
                {
                    startingRoom.AddEntity(new Wall(startingRoom.SizeX - 1, i));
                }
            }
            //west walls
            for (int i = 1; i < startingRoom.SizeY - 1; i++)
            {
                if (i != 2)
                {
                    startingRoom.AddEntity(new Wall(0, i));
                }
            }
            //ROOM 1
            //Add Walls to the otherRoom
            //north walls
            for (int i = 0; i < otherRoom1.SizeX; i++)
            {
                otherRoom1.AddEntity(new Wall(i, 0));
            }
            //south walls
            for (int i = 0; i < otherRoom1.SizeX; i++)
            {
                if (i != 2)
                {
                    otherRoom1.AddEntity(new Wall(i, otherRoom1.SizeY - 1));
                }
            }
            //east walls
            for (int i = 1; i < otherRoom1.SizeY - 1; i++)
            {
                otherRoom1.AddEntity(new Wall(otherRoom1.SizeX - 1, i));
            }
            //west walls
            for (int i = 1; i < otherRoom1.SizeY - 1; i++)
            {
                otherRoom1.AddEntity(new Wall(0, i));
            }
            //ROOM 2
            //north walls
            for (int i = 0; i < otherRoom2.SizeX; i++)
            {
                if (i != 6)
                {
                    otherRoom2.AddEntity(new Wall(i, 0));
                }
            }
            //south walls
            for (int i = 0; i < otherRoom2.SizeX; i++)
            {
                otherRoom2.AddEntity(new Wall(i, otherRoom2.SizeY - 1));               
            }
            //east walls
            for (int i = 1; i < otherRoom2.SizeY - 1; i++)
            {
                otherRoom2.AddEntity(new Wall(otherRoom2.SizeX - 1, i));
            }
            //west walls
            for (int i = 1; i < otherRoom2.SizeY - 1; i++)
            {
                otherRoom2.AddEntity(new Wall(0, i));
            }
            //ROOM 3
            //north walls
            for (int i = 0; i < otherRoom3.SizeX; i++)
            {
                otherRoom3.AddEntity(new Wall(i, 0));               
            }
            //south walls
            for (int i = 0; i < otherRoom3.SizeX; i++)
            {
                otherRoom3.AddEntity(new Wall(i, otherRoom3.SizeY - 1));
            }
            //east walls
            for (int i = 1; i < otherRoom3.SizeY - 1; i++)
            {
                otherRoom3.AddEntity(new Wall(otherRoom3.SizeX - 1, i));
            }
            //west walls
            for (int i = 1; i < otherRoom3.SizeY - 1; i++)
            {
                if (i != 1)
                {
                    otherRoom3.AddEntity(new Wall(0, i));
                }
            }
            //ROOM 4
            //north walls
            for (int i = 0; i < otherRoom4.SizeX; i++)
            {
                otherRoom4.AddEntity(new Wall(i, 0));
            }
            //south walls
            for (int i = 0; i < otherRoom4.SizeX; i++)
            {
                otherRoom4.AddEntity(new Wall(i, otherRoom4.SizeY - 1));
            }
            //east walls
            for (int i = 1; i < otherRoom4.SizeY - 1; i++)
            {
                if (i != 2)
                {
                    otherRoom4.AddEntity(new Wall(otherRoom4.SizeX - 1, i));
                }
            }
            //west walls
            for (int i = 1; i < otherRoom4.SizeY - 1; i++)
            {                                
                    otherRoom4.AddEntity(new Wall(0, i));                
            }

            //Create a Player, position it, and add it to startingRoom
            Player player = new Player("tile190.png");
            player.X = 4;
            player.Y = 3;
            startingRoom.AddEntity(player);
            //Add enemy to otherRoom
            otherRoom1.AddEntity(enemy);
            otherRoom3.AddEntity(chest);

            CurrentScene = startingRoom;

        }
        public void Run()
        {
            Init();
            //PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape);

            while (!gameOver && !RL.WindowShouldClose())
            {
                _currentscene.Update();

                int mouseX = (RL.GetMouseX() - 320 / 16);
                int mouseY = (RL.GetMouseY() - 240 / 32);
                //Raylib.Vector3 cameraPosition = new Raylib.Vector3(-10, -10, -10);
                //Raylib.Vector3 cameraTarget = new Raylib.Vector3(mouseX, 0, mouseY);
                //Raylib.Vector3 cameraUp = new Raylib.Vector3(0, 0, 1);

                //_camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);

                RL.BeginDrawing();
                //RL.BeginMode3D(_camera);
                _currentscene.Draw();
                //RL.EndMode3D();
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
