using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Enemy : Entity
    {
        private Direction _facing;

        public Enemy() : this('e')
        {

        }
        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.North;
            OnUpdate += Move;
        }
        private void Move()
        {
            switch(_facing)
            {
                case Direction.North:
                    MoveUp();
                    break;
                case Direction.South:
                    MoveDown();
                    break;
                case Direction.East:
                    MoveRight();
                    break;
                case Direction.West:
                    MoveLeft();
                    break;
            }
        }
        private void MoveUp()
        {
            if (!MyScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
            else
            {
                _facing++;
            }
        }
        private void MoveDown()
        {
            if (!MyScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
            else
            {
                _facing++;
            }
        }
        private void MoveRight()
        {
            if (!MyScene.GetCollision(X + 1, Y))
            {
                X++;
            }
            else
            {
                _facing++;
            }
        }
        private void MoveLeft()
        {
            if (!MyScene.GetCollision(X - 1, Y))
            {
                X--;
            }
            else
            {
                _facing = Direction.North;
            }
        }
    }
}
