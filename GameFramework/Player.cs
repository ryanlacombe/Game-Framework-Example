using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Player : Entity
    {
        public Player() : base('@')
        {
            
        }
        public Player(char icon) : base(icon)
        {
            PlayerInput.AddKeyEvent(MoveRight, ConsoleKey.RightArrow);
            PlayerInput.AddKeyEvent(MoveLeft, ConsoleKey.LeftArrow);
            PlayerInput.AddKeyEvent(MoveUp, ConsoleKey.UpArrow);
            PlayerInput.AddKeyEvent(MoveDown, ConsoleKey.DownArrow);
        }
        private void MoveRight()
        {
            
            if (!MyScene.GetCollision(X + 1, Y))
            {
                X++;
            }
        }
        private void MoveLeft()
        {
            
            if (!MyScene.GetCollision(X - 1, Y))
            {
                X--;
            }
        }
        private void MoveUp()
        {
            
            if (!MyScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }
        private void MoveDown()
        {
            
            if (!MyScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }

    }
}
