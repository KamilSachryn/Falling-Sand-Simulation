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

        public Tuple<int, int> getTuple()
        {
            return new Tuple<int, int>(x, y);
        }
            

    }

    class ParticleSameCoords : EqualityComparer<Particle>
    {

        public override bool Equals(Particle x, Particle y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;

            return (x.x == y.x && x.y == y.y);
        }

        public override int GetHashCode(Particle obj)
        {
            int hCode = obj.x ^ obj.y;
            return hCode.GetHashCode();
        }
    }
}
