﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Player : Entity
    {
        public Player() : this('@')
        {
            
        }
        public Player(string imageName) : base('@', imageName)
        {
            PlayerInput.AddKeyEvent(MoveRight, 100); //D
            PlayerInput.AddKeyEvent(MoveLeft, 97); //A
            PlayerInput.AddKeyEvent(MoveUp, 119); //W
            PlayerInput.AddKeyEvent(MoveDown, 115); //S
        }
        public Player(char icon) : base(icon)
        {
            PlayerInput.AddKeyEvent(MoveRight, 100); //D
            PlayerInput.AddKeyEvent(MoveLeft, 97); //A
            PlayerInput.AddKeyEvent(MoveUp, 119); //W
            PlayerInput.AddKeyEvent(MoveDown, 115); //S
        }
        private void MoveRight()
        {
            if (X + 1 >= MyScene.SizeX)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.East);
                    X = 0;
                }
            }
            else if (!MyScene.GetCollision(X + 1, Y))
            {
                X++;
            }
        }
        private void MoveLeft()
        {
            if (X - 1 < 0)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.West);
                    X = MyScene.SizeX - 1;
                }
            }
            else if (!MyScene.GetCollision(X - 1, Y))
            {
                X--;
            }
        }
        private void MoveUp()
        {
            if (Y - 1 < 0)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.North);
                    Y = MyScene.SizeY - 1;
                }
            }
            else if (!MyScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }
        private void MoveDown()
        {
            if (Y + 1 >= MyScene.SizeY)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.South);
                    Y = 0;
                }
            }
            else if (!MyScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }
        private void Travel(Room destination)
        {
            if (destination == null)
            {
                return;
            }
            MyScene.RemoveEntity(this);
            destination.AddEntity(this);
            Game.CurrentScene = destination;
        }
    }
}
