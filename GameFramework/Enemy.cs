using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Enemy : Entity
    {
        public Enemy() : this('e')
        {

        }
        public Enemy(char icon) : base(icon)
        {

        }
    }
}
