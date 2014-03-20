using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        private const int InitialSize = 2;

        public Grass(Point location)
            : base(location, Grass.InitialSize)
        {
        }

        // The Grass should grow by 1 at each time unit
        // (i.e. by as much as the timeElapsed parameter is in the Update method), if it IsAlive.
        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}