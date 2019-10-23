﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Wall : Entity
    {
        public Wall(int x, int y) : base('█', "tile012.png")
        {
            X = x;
            Y = y;
            Solid = true;
        }
    }
}
