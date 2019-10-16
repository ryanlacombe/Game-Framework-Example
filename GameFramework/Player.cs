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
        }
        private void MoveRight()
        {
            X++;
            if (X >= MyScene.SizeX)
            {
                X--;
            }
        }
        private void MoveLeft()
        {
            X--;
            if (X < 0)
            {
                X++;
            }
        }

    }
}
