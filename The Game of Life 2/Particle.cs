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

        public Particle()
        {
            x = 0;
            y = 0;
            val = false;
        }
        public Particle(bool val) : this()
        {
            this.val = val;
        }

        public Particle(int x, int y, bool val) : this(val)
        {
            this.x = x;
            this.y = y;            
        }

    }
}
