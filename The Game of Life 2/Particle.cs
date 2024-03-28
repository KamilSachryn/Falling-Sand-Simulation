using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game_of_Life_2
{
    class Particle
    {

        public int x;
        public int y;
        public bool val;

        public Particle(int x, int y, bool val)
        {
            this.x = x;
            this.y = y;    
            this.val = val;
        }

    }
}
