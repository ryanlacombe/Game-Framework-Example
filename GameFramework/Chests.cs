using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Chests : Entity
    {
        public Chests() : this('#')
        {

        }
        public Chests(string imageName) : base('#', imageName)
        {
            OnUpdate += TouchPlayer;
        }
        public Chests(char icon) : base (icon)
        {

        }
        private void TouchPlayer()
        {
            //Get the List of Entities in our space
            List<Entity> touched = MyScene.GetEntities(X, Y);

            //Check if any of them are Players      
            bool hit = false;
            foreach (Entity e in touched)
            {
                if (e is Player)
                {
                    hit = true;
                    break;
                }
            }

            //If we hit a Player, remove this Enemy from the Scene
            if (hit)
            {
                MyScene.RemoveEntity(this);
            }

        }
    }
}
